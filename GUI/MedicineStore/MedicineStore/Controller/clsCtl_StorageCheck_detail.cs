using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.IO;
using System.Drawing;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    class clsCtl_StorageCheck_detail : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_StorageCheck_detail m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmStorageCheck_detail m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint_lock = null;
        
        /// <summary>
        /// 当前盘点主记录

        /// </summary>
        private clsMS_StorageCheck_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前盘点明细
        /// </summary>
        private clsMS_StorageCheckDetail_VO[] m_objCurrentSubArr = null;
        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;
        #endregion

        #region 构造函数


        /// <summary>
        /// 盘点明细表

        /// </summary>
        public clsCtl_StorageCheck_detail()
        {
            m_objDomain = new clsDcl_StorageCheck_detail();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmStorageCheck_detail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化

        /// <summary>
        /// 初始化数据源
        /// </summary>
        internal void m_mthInitDataTable()
        {
            m_objViewer.dtbStorageCheck_detail = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"),new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCH"), new DataColumn("assistcode_chr"),new DataColumn("MEDSPEC_VCHR"),
                new DataColumn("OPUNIT_CHR"),new DataColumn("LOTNO_VCHR"),new DataColumn("VALIDPERIOD_DAT",typeof(DateTime)),new DataColumn("CURRENTGROSS_INT",typeof(double)), new DataColumn("CHECKGROSS_INT",typeof(double)),new DataColumn("PRODUCTORID_CHR"),
                new DataColumn("RETAILPRICE_INT",typeof(double)), new DataColumn("CALLPRICE_INT",typeof(double)),new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("CHECKREASON_VCHR"),new DataColumn("CHECKRESULT_INT",typeof(double)),new DataColumn("ISZERO_INT"),
                new DataColumn("MODIFIER_CHR"),new DataColumn("MODIFYDATE_DAT"), new DataColumn("STATUS_INT"),new DataColumn("INSTORAGEID_VCHR"),new DataColumn("checkmedicineorder_chr"),new DataColumn("medicinepreptype_chr"),
                new DataColumn("medicinepreptypename_vchr"),new DataColumn("balance"),new DataColumn("WholeSaleMoney"),new DataColumn("RetailMoney"), new DataColumn("vendorid_chr"),new DataColumn("storagerackcode_vchr"),new DataColumn("medicinetypeid_chr"), new DataColumn("SERIESID2_INT")};
            m_objViewer.dtbStorageCheck_detail.Columns.AddRange(dcColumns);

            m_objViewer.dtbStorageCheck_detail.Columns["balance"].Expression = "CHECKRESULT_INT * retailprice_int";
            m_objViewer.dtbStorageCheck_detail.Columns["WholeSaleMoney"].Expression = "checkgross_int * wholesaleprice_int";
            m_objViewer.dtbStorageCheck_detail.Columns["RetailMoney"].Expression = "checkgross_int * retailprice_int";
        }

        /// <summary>
        /// 初始化

        /// </summary>
        internal void m_mthLoad()
        {
            if (m_objViewer.intShowType == 0)
            {
                m_mthInitDataTable();
            }

            if (m_objViewer.m_objMain != null)
            {
                m_objViewer.m_txtCheckID.Text = m_objViewer.m_objMain.m_strCheckID_CHR;
                //m_objViewer.m_dtpCheckDate.Text = m_objViewer.m_objMain.m_dtmCheckDate.ToString("yyyy年MM月dd日");
                m_objViewer.m_txtCreator.Tag = m_objViewer.m_objMain.m_strAskerID_CHR;
                m_objViewer.m_txtCreator.Text = m_objViewer.m_objMain.m_strAskerName;

                if (m_objViewer.m_objMain.m_intStatus_INT != 1 && m_objViewer.m_intCommitFolow == 0)
                {
                    m_objViewer.m_cmdAddNew.Enabled = false;
                    m_objViewer.m_cmdDelete.Enabled = false;
                    m_objViewer.m_cmdGetMedicine.Enabled = false;
                    m_objViewer.m_cmdInsertRecord.Enabled = false;
                    m_objViewer.m_cmdMissMedicine.Enabled = false;
                    m_objViewer.m_dgvDetailInfo.ReadOnly = true;
                }
                m_objViewer.m_lngMainSEQ = m_objViewer.m_objMain.m_lngSeriesID_INT;
                m_objCurrentMain = m_objViewer.m_objMain;
            }

            if (m_objViewer.intShowType == 1)//从主窗体传进来的表缺少字段
            {
                try
                {
                    if (!m_objViewer.dtbStorageCheck_detail.Columns.Contains("balance"))
                    {
                        DataColumn dcBalance = m_objViewer.dtbStorageCheck_detail.Columns.Add("balance");
                        dcBalance.Expression = "CHECKRESULT_INT * retailprice_int";
                    }
                    if (!m_objViewer.dtbStorageCheck_detail.Columns.Contains("WholeSaleMoney"))
                    {
                        DataColumn dcWSM = m_objViewer.dtbStorageCheck_detail.Columns.Add("WholeSaleMoney");
                        dcWSM.Expression = "checkgross_int * wholesaleprice_int";
                    }
                    if (!m_objViewer.dtbStorageCheck_detail.Columns.Contains("RetailMoney"))
                    {
                        DataColumn dcRM = m_objViewer.dtbStorageCheck_detail.Columns.Add("RetailMoney");
                        dcRM.Expression = "checkgross_int * retailprice_int";
                    }
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }

                m_objViewer.dtbStorageCheck_detail.AcceptChanges();
            }
            m_objViewer.m_dgvDetailInfo.DataSource = m_objViewer.dtbStorageCheck_detail;

            DataRow drNew = m_objViewer.dtbStorageCheck_detail.NewRow();

            if (m_objViewer.dtbStorageCheck_detail.Rows.Count <= 0)
            {
                m_objViewer.dtbStorageCheck_detail.Rows.Add(drNew);
            }
            m_objViewer.m_dtpCheckDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_objViewer.m_dtpCheckDate.Value = DateTime.Now;

            m_objViewer.m_dgvDetailInfo.Refresh();
        }
        #endregion

        #region 将库存药品信息合并至界面
        /// <summary>
        /// 将库存药品信息合并至界面
        /// </summary>
        /// <param name="p_dtbStorageMedicine">库存药品信息</param>
        internal void m_mthMergeDataToUI(DataTable p_dtbStorageMedicine)
        {
            if (p_dtbStorageMedicine == null || p_dtbStorageMedicine.Rows.Count == 0)
            {
                return;
            }

            int intRowCount = p_dtbStorageMedicine.Rows.Count;
            
            try
            {
                //去除空行
                DataRow[] drNull = m_objViewer.dtbStorageCheck_detail.Select("MEDICINEID_CHR is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow dr in drNull)
                    {
                        m_objViewer.dtbStorageCheck_detail.Rows.Remove(dr);
                    }
                }

                DataTable dtbDetailCopy = m_objViewer.dtbStorageCheck_detail.Copy();//获取界面数据的拷贝

                dtbDetailCopy.PrimaryKey = new DataColumn[] { dtbDetailCopy.Columns["MEDICINEID_CHR"], dtbDetailCopy.Columns["LOTNO_VCHR"], dtbDetailCopy.Columns["INSTORAGEID_VCHR"] };
                dtbDetailCopy.AcceptChanges();

                DataTable dtbGetMedicine = m_objViewer.dtbStorageCheck_detail.Clone();
                dtbGetMedicine.BeginLoadData();
                DataRow drCurrent = null;
                DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = p_dtbStorageMedicine.Rows[iRow];
                    DataRow drNew = dtbGetMedicine.NewRow();

                    //DataRow[] drOld = m_objViewer.dtbStorageCheck_detail.Select("MEDICINEID_CHR='" + drCurrent["MEDICINEID_CHR"].ToString() + "' and LOTNO_VCHR='" + drCurrent["LOTNO_VCHR"].ToString() + "' and INSTORAGEID_VCHR='" + drCurrent["INSTORAGEID_VCHR"].ToString() + "'");
                    //if (drOld != null && drOld.Length > 0)
                    //{
                    //    drOld = null;
                    //    continue;
                    //}
                    drNew["medicinetypeid_chr"] = drCurrent["medicinetypeid_chr"].ToString();
                    drNew["MEDICINEID_CHR"] = drCurrent["MEDICINEID_CHR"].ToString();
                    drNew["MEDICINENAME_VCH"] = drCurrent["medicinename_vchr"].ToString();
                    drNew["assistcode_chr"] = drCurrent["assistcode_chr"].ToString();
                    drNew["MEDSPEC_VCHR"] = drCurrent["MEDSPEC_VCHR"].ToString();
                    drNew["OPUNIT_CHR"] = drCurrent["opunit_vchr"].ToString();
                    if (drCurrent["LOTNO_VCHR"].ToString() == "")
                    {
                        drNew["LOTNO_VCHR"] = "UNKNOWN";
                    }
                    else
                    {
                        drNew["LOTNO_VCHR"] = drCurrent["LOTNO_VCHR"].ToString();
                    }
                    drNew["VALIDPERIOD_DAT"] = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd");
                    drNew["CURRENTGROSS_INT"] = drCurrent["realgross_int"].ToString();
                    drNew["CHECKGROSS_INT"] = drCurrent["realgross_int"].ToString();
                    drNew["PRODUCTORID_CHR"] = drCurrent["productorid_chr"].ToString();
                    drNew["RETAILPRICE_INT"] = drCurrent["retailprice_int"].ToString();
                    drNew["CALLPRICE_INT"] = drCurrent["callprice_int"].ToString();
                    drNew["WHOLESALEPRICE_INT"] = drCurrent["wholesaleprice_int"].ToString();
                    drNew["CHECKRESULT_INT"] = 0;
                    if (drCurrent["realgross_int"] == null || drCurrent["realgross_int"].ToString() == "0")
                    {
                        drNew["ISZERO_INT"] = 0;
                    }
                    else
                    {
                        drNew["ISZERO_INT"] = 1;
                    }
                    drNew["MODIFYDATE_DAT"] = dtmNow;
                    drNew["STATUS_INT"] = 1;
                    drNew["INSTORAGEID_VCHR"] = drCurrent["INSTORAGEID_VCHR"].ToString();
                    drNew["checkmedicineorder_chr"] = drCurrent["checkmedicineorder_chr"].ToString();
                    drNew["medicinepreptypename_vchr"] = drCurrent["medicinepreptypename_vchr"].ToString();
                    drNew["medicinepreptype_chr"] = drCurrent["medicinepreptype_chr"].ToString();
                    drNew["balance"] = 0;
                    drNew["vendorid_chr"] = drCurrent["vendorid_chr"].ToString();
                    drNew["WholeSaleMoney"] = (Convert.ToDouble(drCurrent["realgross_int"]) * Convert.ToDouble(drCurrent["wholesaleprice_int"])).ToString("0.0000");
                    drNew["RetailMoney"] = (Convert.ToDouble(drCurrent["realgross_int"]) * Convert.ToDouble(drCurrent["retailprice_int"])).ToString("0.0000");
                    dtbGetMedicine.LoadDataRow(drNew.ItemArray, false);
                }
                dtbGetMedicine.EndLoadData();

                if (dtbDetailCopy.Rows.Count > 0)
                {
                    dtbDetailCopy.Merge(dtbGetMedicine, true);
                }
                else
                {
                    dtbDetailCopy = dtbGetMedicine.Copy();
                }

                DataTable dtbGetNewMedicine = dtbDetailCopy.GetChanges(DataRowState.Added);//原记录没有的新增药品
                //此做法是为了保持原有记录的DataRowState不发生变化

                if (dtbGetNewMedicine != null)
                {
                    int intRowsCount = dtbGetNewMedicine.Rows.Count;

                    m_objViewer.dtbStorageCheck_detail.BeginLoadData();
                    for (int iRow = 0; iRow < intRowCount; iRow++)
                    {
                        m_objViewer.dtbStorageCheck_detail.LoadDataRow(dtbGetNewMedicine.Rows[iRow].ItemArray, false);
                    }
                    m_objViewer.dtbStorageCheck_detail.EndLoadData();
                }
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            //if (m_objViewer.m_chkOrderByCheckOrderNum.Checked)
            //{
            //    m_objViewer.dtbStorageCheck_detail.DefaultView.Sort = "checkmedicineorder_chr asc";
            //}
            //else
            //{
            //    m_objViewer.dtbStorageCheck_detail.DefaultView.Sort = "assistcode_chr asc";
            //}
        }
        #endregion

        #region 保存盘点明细
        /// <summary>
        /// 保存盘点明细
        /// </summary>
        /// <returns></returns>
        internal long m_lngSaveDetail()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intStatus_INT > 1)
            {
                if (m_objCurrentMain.m_intStatus_INT == 3)
                {
                    MessageBox.Show("该药品盘点记录已入帐，不能修改", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objCurrentMain.m_intStatus_INT == 2 && m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品盘点记录已审核，不能修改", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            //去除空行
            DataRow[] drNull = m_objViewer.dtbStorageCheck_detail.Select("MEDICINEID_CHR is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    m_objViewer.dtbStorageCheck_detail.Rows.Remove(dr);
                }
            }

            if (m_objViewer.m_dgvDetailInfo.Rows.Count == 0)
            {
                MessageBox.Show("请先录入盘点药品", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            long lngRes = 0;
            long lngMainSeq = 0;//主表序列
            bool blnIsAddNewCheck = m_objViewer.m_lngMainSEQ == 0;//是否新初始化盘点单
            bool blnIsCommit = m_objViewer.m_intCommitFolow == 1;

            clsMS_StorageCheck_VO objMain = m_objMain();

            DataTable dtbModify = m_objViewer.dtbStorageCheck_detail.GetChanges(DataRowState.Modified);//修改过的记录
            #region 针对保存即审核流程，将库存数量回复回原始数量
            clsMS_StorageDetail[] objSTOld = null;
            if (!blnIsAddNewCheck && m_objViewer.m_intCommitFolow == 1 && dtbModify != null && dtbModify.Rows.Count > 0)
            {
                DataTable dtbCheckResult = null;
                lngRes = m_objDomain.m_lngGetCheckResult(m_objCurrentMain.m_strCheckID_CHR, out dtbCheckResult);

                List<DataRow> drHasChange = new List<DataRow>();
                if (dtbCheckResult != null)
                {
                    int intRowsCount = dtbCheckResult.Rows.Count;
                    for (int iCheck = 0; iCheck < intRowsCount; iCheck++)
                    {
                        DataRow[] drTemp = dtbModify.Select("seriesid_int=" + dtbCheckResult.Rows[iCheck]["seriesid_int"].ToString());
                        if (drTemp != null && drTemp.Length > 0)
                        {
                            drHasChange.Add(dtbCheckResult.Rows[iCheck]);
                        }
                    }
                }

                if (drHasChange.Count > 0)
                {
                    objSTOld = m_objStorageDetailArr(drHasChange.ToArray());
                    if (objSTOld != null && objSTOld.Length > 0)
                    {
                        for (int iOld = 0; iOld < objSTOld.Length; iOld++)
                        {
                            objSTOld[iOld].m_dblREALGROSS_INT = 0 - objSTOld[iOld].m_dblREALGROSS_INT;
                            objSTOld[iOld].m_dblAVAILAGROSS_INT = 0 - objSTOld[iOld].m_dblAVAILAGROSS_INT;
                        }
                    }
                }
            }
            #endregion

            #region 针对保存即审核流程，检查是否有不能修改的盘点记录
            DataRow[] drCantModify = null;//不能修改的盘点记录
            DataTable dtbHasOut = null;//有出库记录的盘盈药品

            if (m_objViewer.m_intCommitFolow == 1)
            {
                if (!blnIsAddNewCheck)
                {
                    lngRes = m_objDomain.m_lngGetHasOutCheckMedicine(m_objCurrentMain.m_strCheckID_CHR, out dtbHasOut);

                    if (dtbHasOut != null && dtbHasOut.Rows.Count > 0)
                    {
                        StringBuilder stbSQL = new StringBuilder(100);
                        DataRow drTemp = null;
                        int intOutCount = dtbHasOut.Rows.Count;
                        for (int iOut = 0; iOut < intOutCount; iOut++)
                        {
                            drTemp = dtbHasOut.Rows[iOut];
                            stbSQL.Append("(MEDICINEID_CHR='");
                            stbSQL.Append(drTemp["medicineid_chr"].ToString());
                            stbSQL.Append("' and LOTNO_VCHR='");
                            stbSQL.Append(drTemp["LOTNO_VCHR"].ToString());
                            stbSQL.Append("')");
                            if (iOut != intOutCount - 1)
                            {
                                stbSQL.Append(" or ");
                            }
                        }

                        drCantModify = dtbModify.Select(stbSQL.ToString());
                    }
                }
            }
            if (drCantModify != null && drCantModify.Length > 0)
            {
                StringBuilder stbHint = new StringBuilder(100);
                stbHint.Append("下列盘盈药品已出库，不能再对盘点数量进行修改:");
                for (int iWro = 0; iWro < drCantModify.Length; iWro++)
                {
                    stbHint.Append(drCantModify[iWro]["assistcode_chr"].ToString());
                    stbHint.Append(drCantModify[iWro]["MEDICINENAME_VCH"].ToString());
                }
                frmHintMessageBox frmHint = new frmHintMessageBox(stbHint.ToString());
                frmHint.ShowDialog();
                return -1;
            }
            #endregion

            clsMS_StorageCheckDetail_VO[] objModifyDetaiArr = m_objDetailArr(dtbModify, lngMainSeq);

            long[] lngSubSEQ = null;
            DataRow[] drNew = m_objViewer.dtbStorageCheck_detail.Select("SERIESID_INT is null");
            clsMS_StorageCheckDetail_VO[] objNewDetailArr = m_objDetailArr(drNew, lngMainSeq);

            #region 审核所需数据
            DataTable dtbNew = m_objViewer.dtbStorageCheck_detail.GetChanges(DataRowState.Added);
            List<clsMS_StorageDetail> lstStDetail = new List<clsMS_StorageDetail>();//修改过库存的药品库存明细
            clsMS_StorageCheckDetail_VO[] objDefCheckDetail = null;//盘亏
            clsMS_StorageCheckDetail_VO[] objSufCheckDetail = null;//盘盈
            List<string> lstMedicineID = new List<string>();//修改过的药品ID
            if (m_objViewer.m_intCommitFolow == 1)
            {
                bool blnHasAddNew = false;
                if (dtbNew != null && dtbNew.Rows.Count > 0)
                {
                    blnHasAddNew = true;
                }
                bool blnHasModify = false;
                if (dtbModify != null && dtbModify.Rows.Count > 0)
                {
                    blnHasModify = true;
                }

                //盘亏
                DataRow[] drDef = m_objViewer.dtbStorageCheck_detail.Select("CHECKRESULT_INT < 0");
                if (drDef != null && drDef.Length > 0)
                {
                    //检查是否是当前用户修改或添加


                    List<DataRow> HasModifyDef = new List<DataRow>();
                    DataRow[] drDelNew = null;
                    DataRow[] drDelMod = null;
                    for (int iDef = drDef.Length - 1; iDef >= 0; iDef--)
                    {
                        if (blnHasAddNew)
                        {
                            drDelNew = dtbNew.Select("MEDICINEID_CHR='" + drDef[iDef]["MEDICINEID_CHR"].ToString() + "' and LOTNO_VCHR = '" + drDef[iDef]["LOTNO_VCHR"].ToString() + "' and INSTORAGEID_VCHR = '" + drDef[iDef]["INSTORAGEID_VCHR"].ToString() + "'");
                            if (drDelNew != null && drDelNew.Length > 0)
                            {
                                HasModifyDef.Add(drDef[iDef]);
                                continue;
                            }
                        }

                        if (blnHasModify)
                        {
                            drDelMod = dtbModify.Select("SERIESID_INT=" + drDef[iDef]["SERIESID_INT"].ToString());
                            if (drDelMod != null && drDelMod.Length > 0)
                            {
                                HasModifyDef.Add(drDef[iDef]);
                                continue;
                            }
                        }
                    }

                    if (HasModifyDef.Count > 0)
                    {
                        drDef = HasModifyDef.ToArray();  
                        lstStDetail.AddRange(m_objStorageDetailArr(drDef));
                        objDefCheckDetail = m_objCheckDetail(drDef);
                    }
                }
                //盘盈
                DataRow[] drSuf = m_objViewer.dtbStorageCheck_detail.Select("CHECKRESULT_INT > 0");
                if (drSuf != null && drSuf.Length > 0)
                {
                    //检查是否是当前用户修改或添加


                    List<DataRow> HasModifySuf = new List<DataRow>();
                    DataRow[] drDelNew = null;
                    DataRow[] drDelMod = null;
                    for (int iSuf = drSuf.Length - 1; iSuf >= 0; iSuf--)
                    {
                        if (blnHasAddNew)
                        {
                            drDelNew = dtbNew.Select("MEDICINEID_CHR='" + drSuf[iSuf]["MEDICINEID_CHR"].ToString() + "' and LOTNO_VCHR = '" + drSuf[iSuf]["LOTNO_VCHR"].ToString() + "' and INSTORAGEID_VCHR = '" + drSuf[iSuf]["INSTORAGEID_VCHR"].ToString() + "'");
                            if (drDelNew != null && drDelNew.Length > 0)
                            {
                                HasModifySuf.Add(drSuf[iSuf]);
                                continue;
                            }
                        }
                        if (blnHasModify)
                        {
                            drDelMod = dtbModify.Select("SERIESID_INT=" + drSuf[iSuf]["SERIESID_INT"].ToString());
                            if (drDelMod != null && drDelMod.Length > 0)
                            {
                                HasModifySuf.Add(drSuf[iSuf]);
                                continue;
                            }
                        }
                    }

                    if (HasModifySuf.Count > 0)
                    {
                        drSuf = HasModifySuf.ToArray();
                        lstStDetail.AddRange(m_objStorageDetailArr(drSuf));
                        objSufCheckDetail = m_objCheckDetail(drSuf);
                    }
                }

                Hashtable hstMedicine = new Hashtable();
                if (objSTOld != null && objSTOld.Length > 0)
                {
                    for (int iMed = 0; iMed < objSTOld.Length; iMed++)
                    {
                        if (!hstMedicine.Contains(objSTOld[iMed].m_strMEDICINEID_CHR))
                        {
                            hstMedicine.Add(objSTOld[iMed].m_strMEDICINEID_CHR, objSTOld[iMed].m_strMEDICINENAME_VCHR);
                            lstMedicineID.Add(objSTOld[iMed].m_strMEDICINEID_CHR);
                        }
                    }
                }
                if (lstStDetail.Count > 0)
                {
                    for (int iMed = 0; iMed < lstStDetail.Count; iMed++)
                    {
                        if (!hstMedicine.Contains(lstStDetail[iMed].m_strMEDICINEID_CHR))
                        {
                            hstMedicine.Add(lstStDetail[iMed].m_strMEDICINEID_CHR, lstStDetail[iMed].m_strMEDICINENAME_VCHR);
                            lstMedicineID.Add(lstStDetail[iMed].m_strMEDICINEID_CHR);
                        }
                    }
                }
            }
            #endregion

            lngRes = m_objDomain.m_lngSaveStorageCheck(ref objMain, objSTOld, objModifyDetaiArr, objNewDetailArr, objDefCheckDetail, objSufCheckDetail, lstStDetail.ToArray(), lstMedicineID.ToArray(),
                objMain.m_strAskerID_CHR, m_objViewer.m_strStorageID, blnIsAddNewCheck, blnIsCommit, out lngSubSEQ);

            if (lngRes > 0)
            {
                m_objViewer.m_lngMainSEQ = objMain.m_lngSeriesID_INT;
                m_objViewer.m_txtCheckID.Text = objMain.m_strCheckID_CHR;
                lngMainSeq = objMain.m_lngSeriesID_INT;
                m_objCurrentMain = objMain;

                if (lngSubSEQ != null && drNew != null && lngSubSEQ.Length == drNew.Length)
                {
                    for (int iSEQ = 0; iSEQ < lngSubSEQ.Length; iSEQ++)
                    {
                        drNew[iSEQ]["SERIESID_INT"] = lngSubSEQ[iSEQ];
                    }
                }

                m_objViewer.dtbStorageCheck_detail.AcceptChanges();
            }
            return 1;
        }
        #endregion

        #region 获取当前主记录

        /// <summary>
        /// 获取当前主记录

        /// </summary>
        /// <returns></returns>
        private clsMS_StorageCheck_VO m_objMain()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_StorageCheck_VO();
                m_objCurrentMain.m_dtmAskDate_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (m_objViewer.m_intCommitFolow == 1)
                {
                    m_objCurrentMain.m_intStatus_INT = 2;
                }
                else
                {
                    m_objCurrentMain.m_intStatus_INT = 1;
                }
            }

            m_objCurrentMain.m_strStorageID_CHR = m_objViewer.m_strStorageID;
            if (m_objViewer.m_txtCreator.Tag != null)
            {
                m_objCurrentMain.m_strAskerID_CHR = m_objViewer.m_txtCreator.Tag.ToString();
            }
            else
            {
                m_objCurrentMain.m_strAskerID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            }

            m_objCurrentMain.m_dtmCheckDate = Convert.ToDateTime(m_objViewer.m_dtpCheckDate.Text);
            return m_objCurrentMain;
        }
        #endregion

        #region 获取盘点明细
        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="p_dtbData">明细数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_StorageCheckDetail_VO[] m_objDetailArr(DataTable p_dtbData, long p_lngMainSEQ)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            List<clsMS_StorageCheckDetail_VO> lstDetail = new List<clsMS_StorageCheckDetail_VO>();
            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                clsMS_StorageCheckDetail_VO objDetail = m_objDetail(p_dtbData.Rows[iRow], dtmNow, p_lngMainSEQ);
                if (objDetail != null)
                {
                    lstDetail.Add(objDetail);
                }
            }
            return lstDetail.ToArray();
        }

        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="p_drDataArr">盘点明细数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_StorageCheckDetail_VO[] m_objDetailArr(DataRow[] p_drDataArr, long p_lngMainSEQ)
        {
            if (p_drDataArr == null || p_drDataArr.Length == 0)
            {
                return null;
            }

            List<clsMS_StorageCheckDetail_VO> lstDetail = new List<clsMS_StorageCheckDetail_VO>();
            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            for (int iRow = 0; iRow < p_drDataArr.Length; iRow++)
            {
                clsMS_StorageCheckDetail_VO objDetail = m_objDetail(p_drDataArr[iRow], dtmNow, p_lngMainSEQ);
                if (objDetail != null)
                {
                    lstDetail.Add(objDetail);
                }
            }

            return lstDetail.ToArray();
        }

        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="p_drData">数据行</param>
        /// <param name="p_dtmModifyDate">修改日期(为了同时修改多行数据时保证修改日期统一)</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_StorageCheckDetail_VO m_objDetail(DataRow p_drData, DateTime p_dtmModifyDate, long p_lngMainSEQ)
        {
            if (p_drData == null)
            {
                return null;
            }

            //用来转换类型的临时变量

            double dblTemp = 0d;
            DateTime dtmTemp = DateTime.Now;
            int intTemp = 0;
            long lngTemp = 0;

            clsMS_StorageCheckDetail_VO objValue = new clsMS_StorageCheckDetail_VO();
            if (double.TryParse(p_drData["CALLPRICE_INT"].ToString(), out dblTemp))
            {
                objValue.m_dblCALLPRICE_INT = dblTemp;
            }
            if (double.TryParse(p_drData["CHECKGROSS_INT"].ToString(), out dblTemp))
            {
                objValue.m_dblCHECKGROSS_INT = dblTemp;
            }
            if (double.TryParse(p_drData["CHECKRESULT_INT"].ToString(), out dblTemp))
            {
                objValue.m_dblCHECKRESULT_INT = dblTemp;
            }
            if (double.TryParse(p_drData["CURRENTGROSS_INT"].ToString(), out dblTemp))
            {
                objValue.m_dblCURRENTGROSS_INT = dblTemp;
            }
            if (double.TryParse(p_drData["RETAILPRICE_INT"].ToString(), out dblTemp))
            {
                objValue.m_dblRETAILPRICE_INT = dblTemp;
            }
            if (double.TryParse(p_drData["WHOLESALEPRICE_INT"].ToString(), out dblTemp))
            {
                objValue.m_dblWHOLESALEPRICE_INT = dblTemp;
            }
            objValue.m_dtmMODIFYDATE_DAT = Convert.ToDateTime(p_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss"));
            if (DateTime.TryParse(p_drData["VALIDPERIOD_DAT"].ToString(), out dtmTemp))
            {
                objValue.m_dtmVALIDPERIOD_DAT = dtmTemp;
            }
            if (objValue.m_dblCHECKRESULT_INT == 0)
            {
                objValue.m_intISZERO_INT = 0;
            }
            else
            {
                objValue.m_intISZERO_INT = 1;
            }
            if (int.TryParse(p_drData["STATUS_INT"].ToString(), out intTemp))
            {
                objValue.m_intSTATUS_INT = intTemp;
            }
            if (long.TryParse(p_drData["SERIESID_INT"].ToString(), out lngTemp))
            {
                objValue.m_lngSERIESID_INT = lngTemp;
            }
            objValue.m_lngSERIESID2_INT = p_lngMainSEQ;
            objValue.m_strCHECKREASON_VCHR = p_drData["CHECKREASON_VCHR"].ToString();
            objValue.m_strINSTORAGEID_VCHR = p_drData["INSTORAGEID_VCHR"].ToString();
            if (p_drData["LOTNO_VCHR"].ToString() == "")
            {
                objValue.m_strLOTNO_VCHR = "UNKNOWN";
            }
            else
            {
                objValue.m_strLOTNO_VCHR = p_drData["LOTNO_VCHR"].ToString();
            }
            objValue.m_strMEDICINEID_CHR = p_drData["MEDICINEID_CHR"].ToString();
            objValue.m_strMEDICINENAME_VCH = p_drData["MEDICINENAME_VCH"].ToString();
            objValue.m_strMEDSPEC_VCHR = p_drData["MEDSPEC_VCHR"].ToString();
            objValue.m_strMODIFIER_CHR = m_objViewer.LoginInfo.m_strEmpID;
            objValue.m_strOPUNIT_CHR = p_drData["OPUNIT_CHR"].ToString();
            objValue.m_strPRODUCTORID_CHR = p_drData["PRODUCTORID_CHR"].ToString();
            objValue.m_strVendorID = p_drData["vendorid_chr"].ToString();

            return objValue;
        }
        #endregion

        #region 获取入库VO
        /// <summary>
        /// 获取主表VO
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <param name="p_dtmNewDate">制单日期</param>
        /// <returns></returns>
        private clsMS_InStorage_VO m_objGetMainISVO(DataRow p_drData, DateTime p_dtmNewDate)
        {
            clsMS_InStorage_VO objISMainVO = new clsMS_InStorage_VO();

            objISMainVO.m_dtmNEWORDER_DAT = p_dtmNewDate;
            objISMainVO.m_intSTATE_INT = 2;
            objISMainVO.m_lngSERIESID_INT = 0;
            objISMainVO.m_strINSTORAGEID_VCHR = m_objViewer.m_txtCheckID.Text;
            objISMainVO.m_strVENDORID_CHR = p_drData["vendorid_chr"].ToString();
            objISMainVO.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(m_objViewer.m_dtpCheckDate.Text);
            objISMainVO.m_strBUYERID_CHAR = string.Empty;
            objISMainVO.m_strSTORAGERID_CHAR = string.Empty;
            objISMainVO.m_strACCOUNTERID_CHAR = string.Empty;
            objISMainVO.m_strMAKERID_CHR = m_objCurrentMain.m_strAskerID_CHR;
            objISMainVO.m_strSUPPLYCODE_VCHR = string.Empty;
            objISMainVO.m_strCOMMNET_VCHR = p_drData["CHECKREASON_VCHR"].ToString();
            objISMainVO.m_strINVOICECODE_VCHR = string.Empty;
            objISMainVO.m_dtmINVOICEDATER_DAT = DateTime.MinValue;
            objISMainVO.m_intFORMTYPE_INT = 3;
            objISMainVO.m_intINSTORAGETYPE_INT = 1;
            objISMainVO.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            objISMainVO.m_intPAYSTATE_INT = 1;
            return objISMainVO;
        }

        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsMS_InStorageDetail_VO m_objGetISDetail(DataRow p_drData)
        {
            if (p_drData == null)
            {
                return null;
            }

            double dblTemp = 0d;
            decimal dcmTemp = 0m;

            clsMS_InStorageDetail_VO objNewDetail = new clsMS_InStorageDetail_VO();

            objNewDetail.m_intStatus = 1;
            objNewDetail.m_strMEDICINEID_CHR = p_drData["MEDICINEID_CHR"].ToString();
            objNewDetail.m_strMEDICINENAME_VCH = p_drData["MEDICINENAME_VCH"].ToString();
            objNewDetail.m_strMEDSPEC_VCHR = p_drData["MEDSPEC_VCHR"].ToString();
            objNewDetail.m_dblPACKAMOUNT = 0d;
            objNewDetail.m_strPACKUNIT_VCHR = string.Empty;
            objNewDetail.m_dcmPACKCALLPRICE_INT = 0m;
            objNewDetail.m_dblPACKCONVERT_INT = 0d;
            objNewDetail.m_strLOTNO_VCHR = p_drData["LOTNO_VCHR"].ToString();
            if (double.TryParse(p_drData["CHECKRESULT_INT"].ToString(), out dblTemp))
            {
                objNewDetail.m_dblAMOUNT = dblTemp;
            }
            if (decimal.TryParse(p_drData["CALLPRICE_INT"].ToString(), out dcmTemp))
            {
                objNewDetail.m_dcmCALLPRICE_INT = dcmTemp;
            }
            if (decimal.TryParse(p_drData["WHOLESALEPRICE_INT"].ToString(), out dcmTemp))
            {
                objNewDetail.m_dcmWHOLESALEPRICE_INT = dcmTemp;
            }
            if (decimal.TryParse(p_drData["RETAILPRICE_INT"].ToString(), out dcmTemp))
            {
                objNewDetail.m_dcmRETAILPRICE_INT = dcmTemp;
            }
            objNewDetail.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData["VALIDPERIOD_DAT"]);
            objNewDetail.m_intACCEPTANCE_INT = 1;
            objNewDetail.m_strAPPROVECODE_VCHR = string.Empty;
            objNewDetail.m_intAPPARENTQUALITY_INT = 1;
            objNewDetail.m_intPACKQUALITY_INT = 1;
            objNewDetail.m_intEXAMRUSULT_INT = 1;
            objNewDetail.m_strEXAMINER = string.Empty;
            objNewDetail.m_strPRODUCTORID_CHR = p_drData["PRODUCTORID_CHR"].ToString();
            objNewDetail.m_strACCEPTANCECOMPANY_CHR = string.Empty;
            objNewDetail.m_strUNIT_VCHR = p_drData["OPUNIT_CHR"].ToString();
            objNewDetail.m_strInStorageID = p_drData["INSTORAGEID_VCHR"].ToString();
            objNewDetail.m_intRUTURNNUM_INT = 0;

            return objNewDetail;
        }
        #endregion

        #region 获取出库VO
        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <param name="p_dtmNewDate">制单日期</param>
        /// <returns></returns>
        private clsMS_OutStorage_VO m_objGetMainOSVO(DataRow p_drData, DateTime p_dtmNewDate)
        {
            clsMS_OutStorage_VO objOutMain = new clsMS_OutStorage_VO();
            objOutMain.m_dtmASKDATE_DAT = p_dtmNewDate;
            objOutMain.m_intSTATUS = 2;

            objOutMain.m_strASKDEPT_CHR = string.Empty;
            objOutMain.m_intOutStorageTYPE_INT = 1;
            objOutMain.m_intFORMTYPE_INT = 3;
            objOutMain.m_strASKERID_CHR = m_objCurrentMain.m_strAskerID_CHR;
            objOutMain.m_strCOMMENT_VCHR = p_drData["CHECKREASON_VCHR"].ToString();
            objOutMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            objOutMain.m_dtmOutStorageDate = Convert.ToDateTime(m_objViewer.m_dtpCheckDate.Text);
            objOutMain.m_strOUTSTORAGEID_VCHR = m_objViewer.m_txtCheckID.Text;
            return objOutMain;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_drDetail">子表数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO m_objGetOSDetail(DataRow p_drDetail)
        {
            if (p_drDetail == null)
            {
                return null;
            }

            clsMS_OutStorageDetail_VO objDetail = new clsMS_OutStorageDetail_VO();
            objDetail.m_strMEDICINEID_CHR = p_drDetail["MEDICINEID_CHR"].ToString();
            objDetail.m_strMEDICINENAME_VCH = p_drDetail["MEDICINENAME_VCH"].ToString();
            objDetail.m_strMEDSPEC_VCHR = p_drDetail["MEDSPEC_VCHR"].ToString();
            objDetail.m_strOPUNIT_CHR = p_drDetail["OPUNIT_CHR"].ToString();
            objDetail.m_dblNETAMOUNT_INT = Math.Abs(Convert.ToDouble(p_drDetail["CHECKRESULT_INT"]));
            objDetail.m_strLOTNO_VCHR = p_drDetail["LOTNO_VCHR"].ToString();
            objDetail.m_strINSTORAGEID_VCHR = string.Empty;
            objDetail.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drDetail["CALLPRICE_INT"]);
            objDetail.m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drDetail["WHOLESALEPRICE_INT"]);
            objDetail.m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drDetail["RETAILPRICE_INT"]);
            objDetail.m_strVENDORID_CHR = p_drDetail["VENDORID_CHR"].ToString();
            //objDetail.m_strVendorName = p_drDetail["vendorname_vchr"].ToString();
            objDetail.m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail["validperiod_dat"]);
            objDetail.m_strProductorID_chr = p_drDetail["productorid_chr"].ToString();
            objDetail.m_dtmINSTORAGEDATE_DAT = DateTime.MinValue;
            objDetail.m_intStatus = 1;
            objDetail.m_intRETURNNUM_INT = 0;

            return objDetail;
        }
        #endregion
        #endregion

        #region 获取库存信息
        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="p_dtbData">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objStorageDetailArr(DataTable p_dtbData)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            List<clsMS_StorageDetail> lstDetail = new List<clsMS_StorageDetail>();
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                clsMS_StorageDetail objDetail = m_objStorageDetail(p_dtbData.Rows[iRow]);
                if (objDetail != null)
                {
                    lstDetail.Add(objDetail);
                }
            }
            return lstDetail.ToArray();
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objStorageDetailArr(DataRow[] p_drData)
        {
            if (p_drData == null || p_drData.Length == 0)
            {
                return null;
            }

            List<clsMS_StorageDetail> lstDetail = new List<clsMS_StorageDetail>();
            for (int iRow = 0; iRow < p_drData.Length; iRow++)
            {
                clsMS_StorageDetail objDetail = m_objStorageDetail(p_drData[iRow]);
                if (objDetail != null)
                {
                    lstDetail.Add(objDetail);
                }
            }

            return lstDetail.ToArray();
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail m_objStorageDetail(DataRow p_drData)
        {
            if (p_drData == null)
            {
                return null;
            }
            clsMS_StorageDetail objDetail = new clsMS_StorageDetail();
            objDetail.m_dblAVAILAGROSS_INT = Convert.ToDouble(p_drData["CHECKRESULT_INT"]);
            objDetail.m_dblREALGROSS_INT = Convert.ToDouble(p_drData["CHECKRESULT_INT"]);
            objDetail.m_strLOTNO_VCHR = p_drData["LOTNO_VCHR"].ToString();
            objDetail.m_strINSTORAGEID_VCHR = p_drData["instorageid_vchr"].ToString();
            objDetail.m_strMEDICINEID_CHR = p_drData["MEDICINEID_CHR"].ToString();
            objDetail.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            objDetail.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData["VALIDPERIOD_DAT"]);
            objDetail.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drData["CALLPRICE_INT"]);
            return objDetail;
        }
        #endregion

        #region 删除盘点明细
        /// <summary>
        /// 删除盘点明细
        /// </summary>
        internal void m_mthDeleteStorageCheck()
        {
            if (m_objViewer.m_dgvDetailInfo.CurrentCell == null)
                return;

            long lngRes = 0;
            long lngSeq = 0;
            int intCurrentRow = m_objViewer.m_dgvDetailInfo.CurrentCell.RowIndex;
            DataRowView drvCurrent = m_objViewer.m_dgvDetailInfo.Rows[intCurrentRow].DataBoundItem as DataRowView;
            DataRow drCurrent = drvCurrent.Row;

            bool blnIsCommit = m_objViewer.m_intCommitFolow == 1;
            if (long.TryParse(drvCurrent["SERIESID_INT"].ToString(), out lngSeq))
            {
                DataTable dtbCheckResult = null;
                lngRes = m_objDomain.m_lngGetCheckResult(lngSeq, out dtbCheckResult);

                double dblCheckResult = 0d;
                if (dtbCheckResult != null && dtbCheckResult.Rows.Count > 0 && double.TryParse(dtbCheckResult.Rows[0]["checkresult_int"].ToString(), out dblCheckResult))
                {
                    clsMS_StorageDetail objStDetail = m_objStorageDetail(drCurrent);
                    objStDetail.m_dblREALGROSS_INT = dblCheckResult;

                    lngRes = m_objDomain.m_lngDeleteStorageCheckMedicine(objStDetail, m_objCurrentMain.m_strCheckID_CHR, lngSeq, blnIsCommit);
                }     
                if (lngRes > 0)
	            {
		              m_objViewer.dtbStorageCheck_detail.Rows.Remove(drCurrent);
                      MessageBox.Show("删除成功", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
	            }
                else
                {
                    MessageBox.Show("删除失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.dtbStorageCheck_detail.Rows.Remove(drCurrent);
                MessageBox.Show("删除成功", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetCommitFlow(out p_intCommitFolw);
            objPDDomain = null;
        }
        #endregion

        #region 设置员工至列表


        /// <summary>
        /// 设置员工至列表

        /// </summary>
        /// <param name="p_strSearch">搜索字符串</param>
        /// <param name="p_txtEmp">员工控件</param>
        internal void m_mthSetEmpToList(string p_strSearch, TextBox p_txtEmp)
        {
            DataTable dtbEmp = null;
            clsDcl_Purchase_Detail objPDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDomain.m_lngGetEMP(p_strSearch, out dtbEmp);
            objPDomain = null;

            if (dtbEmp == null || dtbEmp.Rows.Count == 0)
            {
                p_txtEmp.Tag = null;
            }

            if (m_ctlEMP == null)
            {
                m_ctlEMP = new ctlQueryEmployee();
                m_ctlEMP.ReturnInfo += new ReturnEmpInfo(m_ctlEMP_ReturnInfo);
                m_objViewer.Controls.Add(m_ctlEMP);
            }
            m_ctlEMP.m_mthSetTxtBase(p_txtEmp);
            m_ctlEMP.BringToFront();
            int X = m_objViewer.panel2.Location.X + p_txtEmp.Location.X;
            int Y = m_objViewer.panel2.Location.Y + p_txtEmp.Location.Y + p_txtEmp.Size.Height;

            if ((X + m_ctlEMP.Size.Width) > m_objViewer.Size.Width)
            {
                X = m_objViewer.panel2.Location.X + p_txtEmp.Location.X - (X + m_ctlEMP.Size.Width - m_objViewer.Size.Width);
            }
            m_ctlEMP.Location = new System.Drawing.Point(X, Y);

            try
            {
                int intRowCount = dtbEmp.Rows.Count;
                DataRow drCurrent = null;
                List<ListViewItem> lstItems = new List<ListViewItem>();
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = dtbEmp.Rows[iRow];
                    ListViewItem lsi = new ListViewItem(drCurrent["EMPNO_CHR"].ToString());
                    lsi.SubItems.Add(drCurrent["LASTNAME_VCHR"].ToString());
                    lsi.Tag = drCurrent;
                    lstItems.Add(lsi);
                }
                m_ctlEMP.AddRange(lstItems.ToArray());
                if (lstItems.Count == 0)
                {
                    p_txtEmp.Tag = null;
                }
                m_ctlEMP.Visible = true;
                m_ctlEMP.Focus();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }

        private void m_ctlEMP_ReturnInfo(DataRow DR_EMP, TextBox Sender)
        {
            Sender.Tag = null;
            if (DR_EMP != null)
            {
                Sender.Tag = DR_EMP["EMPID_CHR"].ToString();
                Sender.Text = DR_EMP["LASTNAME_VCHR"].ToString();
            }

            if (Sender.Name == "m_txtCreator")
            {
                m_objViewer.m_dtpCheckDate.Focus();
            }
        }
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out p_dtbMedicineInfo);
            objIRDomain = null;
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvDetailInfo.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvDetailInfo.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvDetailInfo.Location.X,
                rect.Y + m_objViewer.m_dgvDetailInfo.Location.Y + rect.Height + m_objViewer.panel3.Location.Y);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvDetailInfo.Location.X,
                rect.Y + m_objViewer.m_dgvDetailInfo.Location.Y + m_objViewer.panel3.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;

            DataTable dtbMedicine = null;
            long lngRes = m_objDomain.m_lngGetMedicineByMedicineID(p_strMedicineID, m_objViewer.m_strStorageID, out dtbMedicine);

            if (dtbMedicine == null || dtbMedicine.Rows.Count == 0)
            {
                MessageBox.Show("未找到所选择药品的库存信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                return -1;
            }

            int intRowsCount = dtbMedicine.Rows.Count;
            DataRow drTemp = null;
            StringBuilder stbFilter = new StringBuilder(100);
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = dtbMedicine.Rows[iRow];
                stbFilter.Append("(MEDICINEID_CHR='");
                stbFilter.Append(drTemp["medicineid_chr"].ToString());
                stbFilter.Append("' and LOTNO_VCHR='");
                stbFilter.Append(drTemp["lotno_vchr"].ToString());
                stbFilter.Append("' and INSTORAGEID_VCHR='");
                stbFilter.Append(drTemp["instorageid_vchr"].ToString());
                stbFilter.Append("')");
                if (iRow != intRowsCount - 1)
                {
                    stbFilter.Append(" or ");
                }
            }
            DataRow[] drRowHas = m_objViewer.dtbStorageCheck_detail.Select(stbFilter.ToString());
            if (drRowHas != null && drRowHas.Length > 0)
            {
                if (drRowHas.Length == intRowsCount)
                {
                    MessageBox.Show("所选择药品的库存信息已存在于当前盘点记录中，不能重复添加", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_ctlQueryMedicint.Visible = true;
                    return -1;
                }
                else
                {
                    StringBuilder stbFilterHas = new StringBuilder(100);
                    for (int iRow = 0; iRow < drRowHas.Length; iRow++)
                    {
                        stbFilterHas.Append("(MEDICINEID_CHR='");
                        stbFilterHas.Append(drRowHas[iRow]["medicineid_chr"].ToString());
                        stbFilterHas.Append("' and LOTNO_VCHR='");
                        stbFilterHas.Append(drRowHas[iRow]["lotno_vchr"].ToString());
                        stbFilterHas.Append("' and INSTORAGEID_VCHR='");
                        stbFilterHas.Append(drRowHas[iRow]["instorageid_vchr"].ToString());
                        stbFilterHas.Append("')");
                        if (iRow != drRowHas.Length - 1)
                        {
                            stbFilter.Append(" or ");
                        }
                    }
                    DataRow[] drRowDel = dtbMedicine.Select(stbFilterHas.ToString());
                    if (drRowDel != null)
                    {
                        foreach (DataRow dr in drRowDel)
                        {
                            dtbMedicine.Rows.Remove(dr);
                        }
                        m_mthMergeDataToUI(dtbMedicine);
                    }
                }
            }
            else
            {
                m_mthMergeDataToUI(dtbMedicine);
            }
            return lngReturn;
        }
        #endregion




        #region 显示药品字典最小元素信息查询窗体(定位)
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体(定位)
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineForm_lock(string p_strSearchCon, DataTable p_dtbMedicint)
        {

            if (m_ctlQueryMedicint_lock == null)
            {
                m_ctlQueryMedicint_lock = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint_lock);

                m_ctlQueryMedicint_lock.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo_lock);
            }
            m_ctlQueryMedicint_lock.Location = new System.Drawing.Point(828 - m_ctlQueryMedicint_lock.Width + m_objViewer.m_txtLocalize.Width, 40 + m_objViewer.m_txtLocalize.Height);
            m_ctlQueryMedicint_lock.Visible = true;
            m_ctlQueryMedicint_lock.BringToFront();
            m_ctlQueryMedicint_lock.Focus();
            m_ctlQueryMedicint_lock.m_mthSetSearchText(p_strSearchCon);
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo_lock(string p_strMedicineID)
        {
            long lngReturn = 1;

            DataTable dtbMedicine = null;
            long lngRes = m_objDomain.m_lngGetMedicineByMedicineID(p_strMedicineID, m_objViewer.m_strStorageID, out dtbMedicine);

            if (dtbMedicine == null || dtbMedicine.Rows.Count == 0)
            {
                MessageBox.Show("未找到所选择药品的库存信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_ctlQueryMedicint_lock.Visible = true;
                m_ctlQueryMedicint_lock.Focus();
                return -1;
            }
            m_objViewer.m_txtLocalize.Text = dtbMedicine.Rows[0]["MEDICINENAME_VCHR"].ToString();
            m_mthLocalizeRow(dtbMedicine.Rows[0]["assistcode_chr"].ToString());
            m_objViewer.m_dgvDetailInfo.Focus();
            return lngReturn;
        }
        #endregion


        #region 插入新的一行药品出库信息

        /// <summary>
        /// 插入新的一行药品出库信息
        /// </summary>
        internal void m_mthInsertNewMedicineData()
        {
            if (m_objViewer.dtbStorageCheck_detail == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.dtbStorageCheck_detail.NewRow();
            m_objViewer.dtbStorageCheck_detail.Rows.Add(drNew);

            m_objViewer.m_dgvDetailInfo.Focus();
            m_objViewer.m_dgvDetailInfo.CurrentCell = m_objViewer.m_dgvDetailInfo[2, m_objViewer.m_dgvDetailInfo.RowCount - 1];
        }
        #endregion

        #region 计算总金额

        /// <summary>
        /// 计算总金额

        /// </summary>
        internal void m_mthSetCheckMoney()
        {

            m_objViewer.m_lblBalanceMoney.Text = string.Empty;
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (m_objViewer.dtbStorageCheck_detail == null || m_objViewer.dtbStorageCheck_detail.Rows.Count == 0)
            {
                return;
            }

            int intRowsCount = m_objViewer.dtbStorageCheck_detail.Rows.Count;
            double dblBalanceMoney = 0d;
            double dblBuyInMoney = 0d;
            double dblRetailMoney = 0d;
            DataRow drTemp = null;
            
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = m_objViewer.dtbStorageCheck_detail.Rows[iRow];
                if (drTemp.RowState == DataRowState.Deleted || drTemp.RowState == DataRowState.Detached || drTemp["retailprice_int"].ToString().Length == 0)
                {
                    continue;
                }
                double dblBM = Convert.ToDouble(drTemp["CHECKRESULT_INT"]) * Convert.ToDouble(drTemp["retailprice_int"]);
                dblBalanceMoney += dblBM;
                double dblIM = Convert.ToDouble(drTemp["checkgross_int"]) * Convert.ToDouble(drTemp["callprice_int"]);//wholesaleprice_int
                dblBuyInMoney += dblIM;
                double dblRM = Convert.ToDouble(drTemp["checkgross_int"]) * Convert.ToDouble(drTemp["retailprice_int"]);
                dblRetailMoney += dblRM;
            }

            //盈亏金额
            m_objViewer.m_lblBalanceMoney.Text = dblBalanceMoney.ToString("0.0000");

            //购入金额
            m_objViewer.m_lblBuyInSubMoney.Text = dblBuyInMoney.ToString("0.0000");

            //零售金额
            m_objViewer.m_lblRetailSubMoney.Text = dblRetailMoney.ToString("0.0000");
        }
        #endregion

        #region 定位行

        /// <summary>
        /// 定位行

        /// </summary>
        /// <param name="p_strSearch">搜索字符</param>
        internal void m_mthLocalizeRow(string p_strSearch)
        {
            for (int iRow = 0; iRow < m_objViewer.m_dgvDetailInfo.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[2].Value != null
                    && m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[2].Value.ToString() == p_strSearch)
                {
                    m_objViewer.m_dgvDetailInfo.Rows[iRow].Selected = true;
                    m_objViewer.m_dgvDetailInfo.CurrentCell = m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[7];
                    //m_objViewer.m_dgvDetailInfo.CurrentCell.Selected = true;
                    break;
                }
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dtbStorageCheck_detail"></param>
        internal void m_mthPrint(DataTable dtbStorageCheck_detail)
        {
            frmStorageCheckReport frmCheckRep = new frmStorageCheckReport();

            int intPrintType;
            m_objDomain.m_lngGetPrinRow(out intPrintType);
            if (intPrintType == 0)
            {
                frmCheckRep.datWindow.DataWindowObject = "storagecheck_lj";
            }
            if (intPrintType == 1)
            {
                frmCheckRep.datWindow.DataWindowObject = "storagecheck_cs";
            }

            DataTable dtbTem;
            string strSubcheck = "";
            m_objDomain.m_lngGetStorageCheck_detail(m_objViewer.m_lngMainSEQ, out dtbTem);

            if (dtbTem.Rows.Count < 1)
            {
                MessageBox.Show("请保存数据后再打印!", "药库盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (m_objViewer.m_chkOnlyShowGrossChange.Checked)
            {
                strSubcheck = "CHECKRESULT_INT <> 0";
            }
            if (m_objViewer.m_chkOnlyShowCURRENTGROSS.Checked)
            {
                if (strSubcheck.Length > 3)
                {
                    strSubcheck += " and " + "CURRENTGROSS_INT <> 0";
                }
                else
                {
                    strSubcheck = "CURRENTGROSS_INT <> 0";
                }
            }

            if (strSubcheck.Length > 3)
            {
                dtbTem.DefaultView.RowFilter = strSubcheck; ;
            }
            else
            {
                dtbTem.DefaultView.RowFilter = string.Empty;
            }
            frmCheckRep.dtb = dtbTem.DefaultView.ToTable();
            string strStorName;
            m_objDomain.m_lngGetStoreRoomName(m_objCurrentMain.m_strStorageID_CHR, out strStorName);
            frmCheckRep.strStorageName = strStorName; 
            frmCheckRep.strCheckDate = m_objCurrentMain.m_dtmCheckDate.ToString("yyyy年M月");
            frmCheckRep.strAskerName = m_objCurrentMain.m_strAskerName;
            frmCheckRep.strFhr = m_objCurrentMain.m_strAskerName;
            frmCheckRep.strExamerName = m_objCurrentMain.m_strExamerName;
            frmCheckRep.ShowDialog();
        }
        #endregion

        #region 将DataGridView显示的内容导入excel中 using System.IO
        /// <summary>
        /// 将DataGridView显示的内容导入excel中 
        /// </summary>
        /// <param name="dg">DataGridView</param>
        public void ExportDataGridViewToExcel(DataGridView dataGridview1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl   files   (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //写标题     
                for (int i = 0; i < dataGridview1.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dataGridview1.Columns[i].HeaderText;
                }

                sw.WriteLine(str);
                //写内容   
                for (int j = 0; j < dataGridview1.Rows.Count; j++)
                {
                    StringBuilder tempStr = new StringBuilder("");
                    for (int k = 0; k < dataGridview1.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            
                            tempStr.Append("\t");
                        }
                        tempStr.Append(dataGridview1.Rows[j].Cells[k].Value.ToString());

                    }
                    sw.WriteLine(tempStr.ToString());
                }
                MessageBox.Show("导出成功！", "药库盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion

        #region 获取盘点明细
        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="p_drData">盘点明细数据</param>
        /// <returns></returns>
        private clsMS_StorageCheckDetail_VO[] m_objCheckDetail(DataRow[] p_drData)
        {
            if (p_drData == null || p_drData.Length == 0)
            {
                return null;
            }

            long lngSEQTemp = 0;
            clsMS_StorageCheckDetail_VO[] objCheck = new clsMS_StorageCheckDetail_VO[p_drData.Length];
            for (int iRow = 0; iRow < p_drData.Length; iRow++)
            {
                objCheck[iRow] = new clsMS_StorageCheckDetail_VO();
                objCheck[iRow].m_dblCALLPRICE_INT = Convert.ToDouble(p_drData[iRow]["callprice_int"]);
                objCheck[iRow].m_dblCHECKGROSS_INT = Convert.ToDouble(p_drData[iRow]["checkgross_int"]);
                objCheck[iRow].m_dblCHECKRESULT_INT = Convert.ToDouble(p_drData[iRow]["checkresult_int"]);
                objCheck[iRow].m_dblCURRENTGROSS_INT = Convert.ToDouble(p_drData[iRow]["currentgross_int"]);
                objCheck[iRow].m_dblRETAILPRICE_INT = Convert.ToDouble(p_drData[iRow]["retailprice_int"]);
                objCheck[iRow].m_dblWHOLESALEPRICE_INT = Convert.ToDouble(p_drData[iRow]["wholesaleprice_int"]);
                objCheck[iRow].m_dtmMODIFYDATE_DAT = Convert.ToDateTime(p_drData[iRow]["modifydate_dat"]);
                objCheck[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData[iRow]["validperiod_dat"]);
                objCheck[iRow].m_intISZERO_INT = Convert.ToInt32(p_drData[iRow]["iszero_int"]);
                objCheck[iRow].m_intSTATUS_INT = Convert.ToInt32(p_drData[iRow]["status_int"]);
                if (long.TryParse(p_drData[iRow]["seriesid_int"].ToString(), out lngSEQTemp))
                {
                    objCheck[iRow].m_lngSERIESID_INT = lngSEQTemp;
                }
                //if (long.TryParse(p_drData[iRow]["seriesid2_int"].ToString(), out lngSEQTemp))
                //{
                //    objCheck[iRow].m_lngSERIESID2_INT = lngSEQTemp;
                //}
                objCheck[iRow].m_strCHECKREASON_VCHR = p_drData[iRow]["checkreason_vchr"].ToString();
                objCheck[iRow].m_strINSTORAGEID_VCHR = p_drData[iRow]["instorageid_vchr"].ToString();
                objCheck[iRow].m_strLOTNO_VCHR = p_drData[iRow]["lotno_vchr"].ToString();
                objCheck[iRow].m_strMedicineCode = p_drData[iRow]["assistcode_chr"].ToString();
                objCheck[iRow].m_strMEDICINEID_CHR = p_drData[iRow]["medicineid_chr"].ToString();
                objCheck[iRow].m_strMEDICINENAME_VCH = p_drData[iRow]["medicinename_vch"].ToString();
                objCheck[iRow].m_strMedicineTypeID = p_drData[iRow]["medicinetypeid_chr"].ToString();
                objCheck[iRow].m_strMEDSPEC_VCHR = p_drData[iRow]["medspec_vchr"].ToString();
                objCheck[iRow].m_strMODIFIER_CHR = p_drData[iRow]["modifier_chr"].ToString();
                objCheck[iRow].m_strOPUNIT_CHR = p_drData[iRow]["opunit_chr"].ToString();
                objCheck[iRow].m_strPRODUCTORID_CHR = p_drData[iRow]["productorid_chr"].ToString();
                objCheck[iRow].m_strVendorID = p_drData[iRow]["vendorid_chr"].ToString();
            }
            return objCheck;
        }
        #endregion
    }
}
