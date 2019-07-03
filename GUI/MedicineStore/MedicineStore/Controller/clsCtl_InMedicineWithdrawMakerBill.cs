using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.MedicineStore
{
    #region 药品内退制单控制类


    /// <summary>
    /// 药品内退制单控制类
    /// </summary>
    public class clsCtl_InMedicineWithdrawMakerBill : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 构造函数


        public clsCtl_InMedicineWithdrawMakerBill()
        {
            m_objDomain = new clsDcl_InMedicineWithdraw();
        }


        #endregion

        #region 字段

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_InMedicineWithdraw m_objDomain = null;

        //主表索引
        private int m_intSelectedMainRow = -1;

        /// <summary>
        /// 供应商
        /// </summary>
        private DataTable m_dtbVendor = null;

        /// <summary>
        /// 窗体
        /// </summary>
        internal com.digitalwave.iCare.gui.MedicineStore.frmInStorageMedicineWithdrawDetail m_objViewer;


        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;

        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;

        /// <summary>
        /// 当前药品入库主表信息
        /// </summary>
        private clsMS_InStorage_VO m_objCurrentMain = null;

        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);

            m_objViewer = (frmInStorageMedicineWithdrawDetail)frmMDI_Child_Base_in;
        }



        #endregion

        #region 设置药品信息至界面(外部传入VO，以进行修改)
        /// <summary>
        /// 设置药品信息至界面(外部传入VO，以进行修改)
        /// </summary>
        /// <param name="p_objISVO">主表信息</param>
        /// <param name="p_objDetailArr">子表信息</param>
        /// <param name="p_intSelectedSubRow">选中子表行</param>
        internal void m_mthSetMedicineDetailToUI(string p_strReturnDept, ref DataTable p_dtbMedicineDetail, clsMS_InStorage_VO p_objISVO, clsMS_InStorageDetail_VO[] p_objDetailArr, int p_intSelectedMainRow)
        {

            #region 主表

            m_intSelectedMainRow = p_intSelectedMainRow;
            if (p_objISVO == null)
            {
                return;
            }
            if (p_objISVO.m_intSTATE_INT == 2)
                m_objViewer.m_blnHasCommit = true;
            else
                m_objViewer.m_blnHasCommit = false;

            if (p_objISVO.m_intSTATE_INT == 3)
                m_objViewer.m_blnHasAccount = true;
            else
                m_objViewer.m_blnHasAccount = false;

            m_objViewer.m_lngMainSEQ = p_objISVO.m_lngSERIESID_INT;
            m_objViewer.m_dtpTransactDate.Text = p_objISVO.m_dtmINSTORAGEDATE_DAT.ToString("yyyy年MM月dd日");
            m_objViewer.m_txtInnerWithdrawBillNo.Text = p_objISVO.m_strINSTORAGEID_VCHR;
            m_objViewer.m_txtRemark.Text = p_objISVO.m_strCOMMNET_VCHR;
            m_objViewer.m_txtWithdrawDept.Text = p_strReturnDept;
            m_objViewer.m_txtWithdrawDept.Tag = p_objISVO.m_strRETURNDEPT_CHR;
            m_objCurrentMain = p_objISVO;

            //if (m_objViewer.m_intCommitFolow == 0)
            //{
            //    if (m_objViewer.m_blnHasCommit)
            //    {
            //        m_objViewer.panel1.Enabled = false;
            //    }
            //}
            //clsDcl_InMedicineWithdraw objPDomain = new clsDcl_InMedicineWithdraw();

            //bool blnHasDone = false;//此单入库后是否已做其它操作



            //string strOtherID = string.Empty;//其它操作的单据号

            //long lngRes = objPDomain.m_lngCheckHasDoneAfterInStorage(p_objISVO.m_strINSTORAGEID_VCHR, out blnHasDone, out strOtherID);
            //if (blnHasDone)
            //{
            //    m_objViewer.panel1.Enabled = false;
            //}
            //else
            //{
            //    if (p_objISVO.m_intSTATE_INT != 1)
            //    {
            //        m_objViewer.panel1.Enabled = false;
            //    }

            //    if (m_objViewer.m_intCommitFolow == 1 && p_objISVO.m_intSTATE_INT != 0 && p_objISVO.m_intSTATE_INT != 3)
            //    {
            //        m_objViewer.panel1.Enabled = true;
            //    }
            //}
            #endregion

            #region 子表
            if (p_objDetailArr == null)
            {
                return;
            }

            m_objViewer.m_dtbDetail = p_dtbMedicineDetail.Copy();
            m_objViewer.m_dtbDetail.AcceptChanges();
            m_objViewer.m_dgvMedicineDetail.DataSource = m_objViewer.m_dtbDetail;
            m_mthGetAllSubMoney();

            #endregion
        }
        #endregion

        #region 插入新的一行药品内退信息

        /// <summary>
        /// 插入新的一行药品内退信息
        /// </summary>
        internal void m_mthAddNewMedicineData()
        {
            if (m_objViewer.m_dtbDetail == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbDetail.NewRow();
            drNew["AMOUNT"] = 0;
            drNew["SortNum"] = m_objViewer.m_dtbDetail.Rows.Count + 1;
            m_objViewer.m_dtbDetail.Rows.Add(drNew);

            m_mthMakeSn();
            m_objViewer.m_dgvMedicineDetail.Focus();
            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[m_objViewer.m_intMedicineCodeColIndex, m_objViewer.m_dgvMedicineDetail.RowCount - 1];
        }
        #endregion

        #region 为DataGridView生成序号
        internal void m_mthMakeSn()
        {
            if (m_objViewer.m_dgvMedicineDetail.RowCount > 0)
            {
                for (int i1 = 0; i1 < m_objViewer.m_dgvMedicineDetail.RowCount; i1++)
                    m_objViewer.m_dgvMedicineDetail.Rows[i1].Cells[1].Value = i1 +1;
            }
        }
        #endregion

        #region 退审时获取当前库存、实际库存、可用库存


        /// <summary>
        /// 退审时获取当前库存、实际库存、可用库存


        /// </summary>
        /// <param name="p_objValueParam"></param>
        /// <param name="Query_dtbResult"></param>
        internal long m_lngCheckMedicineGross()
        {
            decimal decRealGross = 0;
            decimal decAvailGross = 0;
            //要退审的总数量


            decimal decTotalGross = 0;
            //返回的当前库存


            decimal decCurrGross = 0;
            //退药数量


            decimal decAmount = 0;
            clsMs_MedicineWithdrawNumQueryCondition_VO objValueParam = new clsMs_MedicineWithdrawNumQueryCondition_VO();
            DataTable Query_dtbResult = null;
            DataRow drCurrRow = null;
            DataRow drResult = null;
            //int intRowIndex = 0;
            //intRowIndex = m_objViewer.m_dgvMainInfo.CurrentRow.Index;

            objValueParam.m_strStorageID = m_objCurrentMain.m_strSTORAGEID_CHR;
            objValueParam.m_strInStorageID = m_objCurrentMain.m_strINSTORAGEID_VCHR;
            //获取库存
            m_objDomain.m_lngDclGetMedicineGross(ref objValueParam, ref  Query_dtbResult);

            if ((Query_dtbResult != null) && (Query_dtbResult.Rows.Count > 0))
            {
                DataRow[] drNew = null;


                //验证当前库存、可用库存和实际库存
                for (int i1 = 0; i1 < m_objViewer.m_dtbDetail.Rows.Count; i1++)
                {
                    drCurrRow = m_objViewer.m_dtbDetail.Rows[i1];

                    objValueParam.m_strMedicineID = drCurrRow["MEDICINEID_CHR"].ToString();
                    objValueParam.m_strLotNo = drCurrRow["LOTNO_VCHR"].ToString();
                    objValueParam.m_strInStorageID = drCurrRow["INSTORAGEID_VCHR"].ToString();

                    drNew = m_objViewer.m_dtbDetail.Select("medicineid_chr = '" + objValueParam.m_strMedicineID + "'");
                    decTotalGross = 0;
                    if ((drNew != null) && (drNew.Length > 0))
                    {
                        decimal.TryParse(drCurrRow["AMOUNT"].ToString(), out decAmount);
                        decTotalGross += decAmount;
                    }


                    for (int j1 = 0; j1 < Query_dtbResult.Rows.Count; j1++)
                    {
                        drResult = Query_dtbResult.Rows[j1];
                        //验证当前库存
                        if (objValueParam.m_strMedicineID == drResult["MEDICINEID_CHR"].ToString().Trim())
                        {
                            decimal.TryParse(Query_dtbResult.Rows[0]["currentgross_num"].ToString(), out decCurrGross);
                            if (decTotalGross > decCurrGross)
                                return -1;
                        }

                        //验证可用库存和实际库存


                        if ((objValueParam.m_strMedicineID == drResult["MEDICINEID_CHR"].ToString().Trim())
                            && (objValueParam.m_strLotNo == drResult["LOTNO_VCHR"].ToString().Trim())
                            && (objValueParam.m_strInStorageID == drResult["INSTORAGEID_VCHR"].ToString().Trim()))
                        {
                            decimal.TryParse(drResult["availagross_int"].ToString(), out decAvailGross);
                            decimal.TryParse(drResult["realgross_int"].ToString(), out decRealGross);
                            decimal.TryParse(drCurrRow["AMOUNT"].ToString(), out decAmount);
                            if ((decAmount > decAvailGross) || (decAmount > decRealGross))
                            {
                                return -1;
                            }
                        }

                    }//for                    

                }//for
                return 1;
            }
            else
            {
                return -1;
            }
        }
        #endregion


        #region 保存当前入库信息
        /// <summary>
        /// 保存当前入库信息
        /// </summary>
        internal long m_lngSaveInStorage()
        {
            long lngReturnCode = 0;
            //if (!m_objViewer.m_blnIsAdmin)
            //{
            //    MessageBox.Show("当前用户没有药库管理权限！不能保存", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}

            DateTime datOutTime;
            m_objDomain.m_mthGetAccountperiodTime(out datOutTime);
            if (Convert.ToDateTime(m_objViewer.m_dtpTransactDate.Tag) < datOutTime)
            {
                MessageBox.Show("办理日期不能小于上次帐务结转的结束日期。\r\n上次结转结束日期是：" + datOutTime.ToString("yyyy年MM月dd日"), "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_dtpTransactDate.Focus();
                return -1;
            }

            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1)
            {
                if (m_objCurrentMain.m_intSTATE_INT == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品内退记录已入帐，不能修改", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品内退记录已审核，不能修改", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            //20090721:保存、删除、审核单据时，均判断是否新制状态
            if (m_objViewer.m_txtInnerWithdrawBillNo.Text.Length > 0)
            {
                bool blnNewState = false;
                clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                clsDcl.m_lngCheckBillState(1, m_objViewer.m_txtInnerWithdrawBillNo.Text.Trim(), out blnNewState);
                if (!blnNewState)
                {
                    MessageBox.Show("该内退单不是新制状态，请关闭并刷新后重试", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -1;
                }
            }

            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1 && m_objCurrentMain.m_intSTATE_INT != 0)
            {
                m_objViewer.m_blnHasCommit = true;
            }

            if (m_objViewer.m_dtbDetail.Rows.Count == 0)
            {
                MessageBox.Show("请先录入药品信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.panel2.Focus();
                return -1;
            }

            long lngRes = 0;
            long lngMainSeq = 0;//主表序列
            bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true:false;
            bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true:false;
            string strInStorageID = string.Empty;//内退单据号

            clsMS_InStorage_VO objMain = m_objGetMainISVO();
            //新增
            DataTable dtbNew = m_objViewer.m_dtbDetail.GetChanges(DataRowState.Added);
            clsMS_InStorageDetail_VO[] objDetailNew = m_objGetNewDetail(dtbNew, lngMainSeq, objMain.m_strINSTORAGEID_VCHR, true);
            //修改库存
            DataTable dtbModify = m_objViewer.m_dtbDetail.GetChanges(DataRowState.Modified);
            clsMS_InStorageDetail_VO[] objDetailModify = m_objGetNewDetail(dtbModify, lngMainSeq, objMain.m_strINSTORAGEID_VCHR, false);

            clsMS_StorageDetail[] objOldMedicine = null;
            if (m_objViewer.m_blnHasCommit)
            {
                DataTable dtbOldMedicine = null;
                //获取明细数据
                lngRes = m_objDomain.m_lngDclGetWithdrawDetailData(m_objViewer.m_lngMainSEQ, ref dtbOldMedicine);
                objOldMedicine = m_objDetailVO(dtbOldMedicine);
            }
            clsMS_AccountDetail_VO[] objAccDetail = null;
            clsMS_StorageDetail[] objStDetail = null;
            if (m_objViewer.m_intCommitFolow == 1)
            {
                objStDetail = m_objDetailVO(m_objViewer.m_dtbDetail);
                objAccDetail = m_objAccDetail(m_objViewer.m_dtbDetail, objMain);
            }
            lngRes = m_objDomain.m_lngSave(objMain, objOldMedicine, ref objDetailNew, objDetailModify, objAccDetail, objStDetail, blnIsAddNew, m_objViewer.m_blnHasCommit, blnIsCommit, m_objViewer.m_blnIsImmAccount, out lngMainSeq, out strInStorageID);

            if (lngRes > 0)
            {
                m_objViewer.m_lngMainSEQ = lngMainSeq;
                objMain.m_lngSERIESID_INT = lngMainSeq;
                objMain.m_strINSTORAGEID_VCHR = strInStorageID;
                m_objViewer.m_txtInnerWithdrawBillNo.Text = strInStorageID;
                m_objCurrentMain = objMain;

                DataRow[] drNew = m_objViewer.m_dtbDetail.Select("SERIESID_INT is null");
                if (drNew != null && drNew.Length > 0 && drNew.Length == objDetailNew.Length)
                {
                    for (int iRow = 0; iRow < drNew.Length; iRow++)
                    {
                        drNew[iRow]["SERIESID_INT"] = objDetailNew[iRow].m_lngSERIESID_INT;
                        drNew[iRow]["SERIESID2_INT"] = objDetailNew[iRow].m_lngSERIESID_INT2;
                        drNew[iRow]["RUTURNNUM_INT"] = objDetailNew[iRow].m_intRUTURNNUM_INT;
                    }
                }

                if (m_objViewer.m_intCommitFolow == 1)
                {
                    m_objViewer.m_blnHasCommit = true;
                    if (m_objViewer.m_blnIsImmAccount)
                    {
                        m_objViewer.m_blnHasAccount = true;
                        m_objViewer.m_cmdSave.Enabled = false;
                        m_objViewer.m_cmdInsert.Enabled = false;
                        m_objViewer.m_cmdDelete.Enabled = false;
                        m_objViewer.m_cmdNextBill.Enabled = false;
                        m_objViewer.m_cmdOutStorageBill.Enabled = false;
                        m_objViewer.panel2.Enabled = false;
                        m_objViewer.m_dgvMedicineDetail.ReadOnly = true;
                        m_objViewer.m_dgvMedicineDetail.AllowUserToAddRows = false;
                        m_objViewer.m_cmdOutStorageBill.Enabled = false;
                    }
                    else
                    {
                        m_objViewer.m_blnHasAccount = false;
                        m_objViewer.m_cmdSave.Enabled = true;
                        m_objViewer.m_cmdInsert.Enabled = true;
                        m_objViewer.m_cmdDelete.Enabled = true;
                        m_objViewer.m_cmdNextBill.Enabled = true;
                        m_objViewer.m_cmdOutStorageBill.Enabled = true;
                        m_objViewer.panel2.Enabled = true;
                        m_objViewer.m_dgvMedicineDetail.ReadOnly = false;
                        m_objViewer.m_dgvMedicineDetail.AllowUserToAddRows = true;
                        m_objViewer.m_cmdOutStorageBill.Enabled = true;
                    }

                    if (m_objViewer.m_dtbMedinineMain.Rows.Count > 0 && m_intSelectedMainRow < m_objViewer.m_dtbMedinineMain.Rows.Count && m_intSelectedMainRow >= 0)
                    {
                        m_objViewer.m_dtbMedinineMain.Rows[m_intSelectedMainRow]["STATE_INT"] = m_objViewer.m_blnIsImmAccount ? 3 : 2;
                        m_objViewer.m_dtbMedinineMain.Rows[m_intSelectedMainRow]["STATEName"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";
                        m_objViewer.m_dtbMedinineMain.Rows[m_intSelectedMainRow]["EXAM_DAT"] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }                    
                }                

                m_objViewer.m_dtbDetail.AcceptChanges();

                DialogResult drResult = MessageBox.Show("保存成功，是否打印当前窗体记录?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return 1;
                }
            }
            else
            {
                MessageBox.Show("保存失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;


            int intPrintType;
            m_objDomain.m_lngGetPrinType(out intPrintType);

            DataTable temDtb = new DataTable();
            temDtb = m_objViewer.m_dtbDetail.Copy();
            clsCtl_Public clsPub = new clsCtl_Public();
            string strEMTname;
            int m_intShow;
            clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
            clsCtl_InMedicineWithdraw clsInwith = new clsCtl_InMedicineWithdraw();
            DataRow[] rows = m_objViewer.m_dtbMedinineMain.Select("instorageid_vchr = '" + m_objViewer.m_txtInnerWithdrawBillNo.Text + "'");
            if (rows == null || rows.Length == 0)
            {
                strEMTname = m_objViewer.LoginInfo.m_strEmpName;
            }
            else
            {
                strEMTname = rows[0][15].ToString();
            }
            if (intPrintType == 0)
            {
                dsData.DataWindowObject = "instoragemedicinewithdraw_lj";
                //按药品ID排序
                DataView dtv = new DataView();
                dtv = temDtb.DefaultView;
                dtv.Sort = "assistcode_chr";
                temDtb = dtv.ToTable();

                dsData.Modify("t_titel.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "内退单'");
            }
            else
            {
                //DataView dtv = new DataView();
                //dtv = temDtb.DefaultView;
                //dtv.Sort = "seriesid_int desc";
                //temDtb = dtv.ToTable();


                dsData.DataWindowObject = "instoragemedicinewithdraw_cs";
                dsData.Modify("t_titel.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "退库单(" + m_objViewer.m_strStoreRoomName + ")'");
                decimal decBug = Convert.ToDecimal(m_objViewer.m_lblBuyInSubMoney.Text);
                string mmm = new Money(decBug).ToString();
                dsData.Modify("t_bug.text='" + mmm + "'");
               
                m_objDon.m_lngGetIfShowInfo(out m_intShow);
                if(m_intShow == 0)
                    dsData.Modify("t_info.text=''"); 

                //使用External格式的报表打印

                dsData.Modify("m_storagename.text='" + m_objViewer.m_strStoreRoomName + "'");
                dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtInnerWithdrawBillNo.Text + "'");
                dsData.Modify("m_dtpdate.text='" + m_objViewer.m_dtpTransactDate.Text + "'");
                dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtWithdrawDept.Text + "'");
                dsData.Modify("m_txtman.text='" + strEMTname + "'");
                dsData.Modify("m_txtman2.text='" + strEMTname + "'");
                for (int i = 0; i < temDtb.Rows.Count; i++)
                {
                    DataRow dtr = temDtb.Rows[i];
                    int row = dsData.InsertRow(0);
                    dsData.SetItemString(row, "assistcode_chr", dtr["assistcode_chr"].ToString());
                    dsData.SetItemString(row, "medicinename_vch", dtr["medicinename_vch"].ToString());
                    dsData.SetItemString(row, "medspec_vchr", dtr["medspec_vchr"].ToString());
                    dsData.SetItemString(row, "opunit_chr", dtr["opunit_chr"].ToString());
                    dsData.SetItemSqlDouble(row, "AMOUNT", Convert.ToDouble(dtr["AMOUNT"]));
                    dsData.SetItemSqlDouble(row, "callprice_int", Convert.ToDouble(dtr["callprice_int"]));
                    dsData.SetItemSqlDouble(row, "callsum", Convert.ToDouble(dtr["callsum"]));
                    dsData.SetItemSqlDouble(row, "retailprice_int", Convert.ToDouble(dtr["retailprice_int"]));
                    dsData.SetItemSqlDouble(row, "retailsum", Convert.ToDouble(dtr["retailsum"]));
                }

               
                clsPub.ChoosePrintDialog_DataStore(dsData, true);
                return -1;
            }


            

            dsData.Modify("m_storagename.text='" + m_objViewer.m_strStoreRoomName + "'");
            dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtInnerWithdrawBillNo.Text + "'");
            dsData.Modify("m_dtpdate.text='" + m_objViewer.m_dtpTransactDate.Text + "'");
            dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtWithdrawDept.Text + "'");
            dsData.Modify("m_txtman.text='" + strEMTname + "'");
            dsData.Modify("m_txtman2.text='" + strEMTname + "'");
            //dsData.Modify("m_txtprovidername.text='" + strInaccountername_chr + "'");
            //dsData.Modify("t_commnet.text='" + strCommnet_vchr + "'");
          
            m_objDon.m_lngGetIfShowInfo(out m_intShow);
            if(m_intShow == 0)
                dsData.Modify("t_info.text=''"); 
            

            DataRow dro;
            if (temDtb.Rows.Count % 6 != 0)
            {
                int ros = 6 - temDtb.Rows.Count % 6;
                int i_valCount = temDtb.Rows.Count + ros;
                for (int i = 0; i < ros; i++)
                {
                    dro = temDtb.NewRow();
                    temDtb.Rows.Add(dro);
                }
            }
            dsData.Retrieve(temDtb);
            clsPub.ChoosePrintDialog_DataStore(dsData, true);

            return 1;
            //如果已审核则先退审

            //if (m_objViewer.m_intCommitFolow == 1)
            //{
            //    if (m_objViewer.m_lngMainSEQ > 0)
            //    {
            //        if (m_objViewer.m_blnHasCommit)
            //        {
            //            lngRes = m_mthUnCommit();
            //            if (lngRes < 0)
            //            {
            //                MessageBox.Show("保存失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                return -1;
            //            }
            //        }
            //    }
            //}
            //clsMS_InStorage_VO objMain = m_objGetMainISVO();
            //if (m_objViewer.m_lngMainSEQ == 0)
            //{
            //    string strInStorageID = string.Empty;//入库单据号


            //    lngRes = m_objDomain.m_lngAddNewInStorage(objMain, out lngMainSeq, out strInStorageID);
            //    m_objViewer.m_lngMainSEQ = lngMainSeq;
            //    objMain.m_lngSERIESID_INT = lngMainSeq;
            //    objMain.m_strINSTORAGEID_VCHR = strInStorageID;
            //    m_objViewer.m_txtInnerWithdrawBillNo.Text = strInStorageID;
            //}
            //else
            //{
            //    //修改入库主表
            //    lngRes = m_objDomain.m_lngModifyInStorage(objMain);
            //    lngMainSeq = m_objViewer.m_lngMainSEQ;
            //}

            //if (lngRes < 0)
            //{
            //    MessageBox.Show("保存失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}

            //DataTable dtbNew = m_objViewer.m_dtbDetail.GetChanges(DataRowState.Added);
            //clsMS_InStorageDetail_VO[] objDetailNew = m_objGetNewDetail(dtbNew, lngMainSeq, objMain.m_strINSTORAGEID_VCHR, true);
            //if (objDetailNew != null)
            //{
            //    lngRes = m_objDomain.m_lngAddInStorageDetail(ref objDetailNew);
            //    if (lngRes > 0)
            //    {
            //        ////增加可用库存
            //        //clsMS_StorageGrossForOut[] m_objOutArr = new clsMS_StorageGrossForOut[objDetailNew.Length];
            //        //for (int i1 = 0; i1 < objDetailNew.Length; i1++)
            //        //{
            //        //    m_objOutArr[i1] = new clsMS_StorageGrossForOut();
            //        //    m_objOutArr[i1].m_dblGross = objDetailNew[i1].m_dblAMOUNT;
            //        //    m_objOutArr[i1].m_strStorageID = objMain.m_strSTORAGEID_CHR;
            //        //    m_objOutArr[i1].m_strInStorageID = objDetailNew[i1].m_strInStorageID;
            //        //    m_objOutArr[i1].m_strMedicineID = objDetailNew[i1].m_strMEDICINEID_CHR;
            //        //    m_objOutArr[i1].m_strLotNO = objDetailNew[i1].m_strLOTNO_VCHR;
            //        //}
            //        //m_objDomain.m_lngAddStorageDetailAvailaGrossDcl(m_objOutArr);

            //        DataRow[] drNew = m_objViewer.m_dtbDetail.Select("SERIESID_INT is null");
            //        if (drNew != null && drNew.Length > 0 && drNew.Length == objDetailNew.Length)
            //        {
            //            for (int iRow = 0; iRow < drNew.Length; iRow++)
            //            {
            //                drNew[iRow]["SERIESID_INT"] = objDetailNew[iRow].m_lngSERIESID_INT;
            //                drNew[iRow]["SERIESID2_INT"] = objDetailNew[iRow].m_lngSERIESID_INT2;
            //                drNew[iRow]["RUTURNNUM_INT"] = objDetailNew[iRow].m_intRUTURNNUM_INT;
            //            }
            //        }
            //    }
            //}

            ////修改库存
            //DataTable dtbModify = m_objViewer.m_dtbDetail.GetChanges(DataRowState.Modified);
            //clsMS_InStorageDetail_VO[] objDetailModify = m_objGetNewDetail(dtbModify, lngMainSeq, objMain.m_strINSTORAGEID_VCHR, false);
            //if (objDetailModify != null)
            //{
            //    lngRes = m_objDomain.m_lngModifyInStorageDetail(objDetailModify);
            //    //增加可用库存
            //    //clsMS_StorageGrossForOut[] m_objDetailArr = null;
            //    //m_mthGetModifyData(ref dtbModify, out m_objDetailArr);
            //    //m_objDomain.m_lngAddStorageDetailAvailaGrossDcl(m_objDetailArr);
            //}
        }

        /// <summary>
        /// 获取帐本明细
        /// </summary>
        /// <param name="p_dtbDetail">当前药品数据</param>
        /// <param name="p_objInMain">内退主表</param>
        /// <returns></returns>
        private clsMS_AccountDetail_VO[] m_objAccDetail(DataTable p_dtbDetail,clsMS_InStorage_VO p_objInMain)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0 || p_objInMain == null)
            {
                return null;
            }

            int intRowsCount = p_dtbDetail.Rows.Count;
            clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[intRowsCount];
            int intAccState = m_objViewer.m_blnIsImmAccount ? 1 : 2;//入帐明细状态

            string strInEmp = m_objViewer.m_blnIsImmAccount ? p_objInMain.m_strMAKERID_CHR : string.Empty;//入账人


            DataRow drCurrent = null;
            for (int iAcc = 0; iAcc < intRowsCount; iAcc++)
            {
                drCurrent = p_dtbDetail.Rows[iAcc];
                objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                objAccArr[iAcc].m_dblAMOUNT_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objAccArr[iAcc].m_dblCALLPRICE_INT = Convert.ToDouble(drCurrent["CALLPRICE_INT"]);
                objAccArr[iAcc].m_dblOLDGROSS_INT = Convert.ToDouble(drCurrent["AVAILAGROSS_INT"]);//此字段保存的是实际库存

                objAccArr[iAcc].m_dblRETAILPRICE_INT = Convert.ToDouble(drCurrent["RETAILPRICE_INT"]);
                objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = Convert.ToDouble(drCurrent["WHOLESALEPRICE_INT"]);
                //objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                objAccArr[iAcc].m_intFORMTYPE_INT = 2;
                objAccArr[iAcc].m_intISEND_INT = 0;
                objAccArr[iAcc].m_intSTATE_INT = intAccState;
                objAccArr[iAcc].m_intTYPE_INT = 1;
                //objAccArr[iAcc].m_strCHITTYID_VCHR = p_strInStorageID;
                objAccArr[iAcc].m_strDEPTID_CHR = p_objInMain.m_strRETURNDEPT_CHR;
                objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                objAccArr[iAcc].m_strINSTORAGEID_VCHR = drCurrent["INSTORAGEID_VCHR"].ToString();

                if (drCurrent["LOTNO_VCHR"].ToString() == "")
                {
                    objAccArr[iAcc].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objAccArr[iAcc].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                }
                objAccArr[iAcc].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objAccArr[iAcc].m_strMEDICINENAME_VCH = drCurrent["MEDICINENAME_VCH"].ToString();
                objAccArr[iAcc].m_strMEDICINETYPEID_CHR = drCurrent["medicinetypeid_chr"].ToString();
                objAccArr[iAcc].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                objAccArr[iAcc].m_strOPUNIT_CHR = drCurrent["OPUNIT_CHR"].ToString();
                objAccArr[iAcc].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objAccArr[iAcc].m_dtmOperateDate = p_objInMain.m_dtmNEWORDER_DAT;
            }
            return objAccArr;
        }

        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_dtbDetail">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(DataTable p_dtbDetail)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = null;
            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_dtbDetail.Rows.Count];
            for (int iRow = 0; iRow < p_dtbDetail.Rows.Count; iRow++)
            {
                drCurrent = p_dtbDetail.Rows[iRow];
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objSubVO[iRow].m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                objSubVO[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();

                m_objDomain.m_lngGetMedicineTypeVisionm(drCurrent["MEDICINETYPEID_CHR"].ToString(), out m_objViewer.m_clsTypeVisVO);
                //if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && drCurrent["LOTNO_VCHR"].ToString() == "")
                //{
                if (drCurrent["LOTNO_VCHR"].ToString() =="")
                {
                    objSubVO[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objSubVO[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                }
                

                objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drCurrent["RETAILPRICE_INT"]);
                objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                if (drCurrent["WHOLESALEPRICE_INT"] != DBNull.Value)
                {
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drCurrent["WHOLESALEPRICE_INT"]);
                }
                objSubVO[iRow].m_dblREALGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
               // objSubVO[iRow].m_strOPUNIT_VCHR = drCurrent["OPUNIT_CHR"].ToString();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objSubVO[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objSubVO[iRow].m_strINSTORAGEID_VCHR = drCurrent["INSTORAGEID_VCHR"].ToString();
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                //objSubVO[iRow].m_strVENDORName = p_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
            }
            return objSubVO;
        }
        #endregion

        #region 保存时获取主表VO
        /// <summary>
        /// 获取主表VO
        /// </summary>
        /// <returns></returns>
        private clsMS_InStorage_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_InStorage_VO();
                m_objCurrentMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATE_INT = 1;
            }

            m_objCurrentMain.m_lngSERIESID_INT = m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strINSTORAGEID_VCHR = m_objViewer.m_txtInnerWithdrawBillNo.Text;

            //m_objCurrentMain.m_strVENDORID_CHR = m_objViewer.m_txtProviderName.Tag.ToString();
            //m_objCurrentMain.m_strVENDORName = m_objViewer.m_txtProviderName.Text;
            m_objCurrentMain.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(m_objViewer.m_dtpTransactDate.Text + DateTime.Now.TimeOfDay.ToString());


            m_objCurrentMain.m_strBUYERID_CHAR = string.Empty;


            //if (m_objViewer.m_txtStorageManager.Tag != null)
            //{
            //    m_objCurrentMain.m_strSTORAGERID_CHAR = m_objViewer.m_txtStorageManager.Tag.ToString();
            //}
            //else
            //{
            //    m_objCurrentMain.m_strSTORAGERID_CHAR = string.Empty;
            //}

            //if (m_objViewer.m_txtAccountant.Tag != null)
            //{
            //    m_objCurrentMain.m_strACCOUNTERID_CHAR = m_objViewer.m_txtAccountant.Tag.ToString();
            //}
            //else
            //{
            //    m_objCurrentMain.m_strACCOUNTERID_CHAR = string.Empty;
            //}

            m_objCurrentMain.m_strMAKERID_CHR = m_objViewer.LoginInfo.m_strEmpID;

            m_objCurrentMain.m_strSUPPLYCODE_VCHR = string.Empty;
            m_objCurrentMain.m_strCOMMNET_VCHR = m_objViewer.m_txtRemark.Text;
            //发票号


            //m_objCurrentMain.m_strINVOICECODE_VCHR = string.Empty;
            //m_objCurrentMain.m_dtmINVOICEDATER_DAT = null;
            m_objCurrentMain.m_intFORMTYPE_INT = 2;
            //m_objCurrentMain.m_intINSTORAGETYPE_INT = null;
            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            m_objCurrentMain.m_strRETURNDEPT_CHR = m_objViewer.ReturnDeptID;

            return m_objCurrentMain;
        }
        #endregion

        #region 保存时获取药品明细

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_dtbData"></param>
        /// <param name="p_lngMainSeq"></param>
        /// <param name="p_strInStorageID"></param>
        /// <param name="p_blnDataStauus">true:新增；false:修改</param>
        /// <returns></returns>
        private clsMS_InStorageDetail_VO[] m_objGetNewDetail(DataTable p_dtbData, long p_lngMainSeq, string p_strInStorageID, bool p_blnDataStauus)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            clsMS_InStorageDetail_VO[] objNewDetail = new clsMS_InStorageDetail_VO[intRowsCount];
            DataRow drCurrent = null;
            double dblTemp = 0d;
            decimal dcmTemp = 0m;
            int intTemp = 0;
            long lngTemp = 0;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                objNewDetail[iRow] = new clsMS_InStorageDetail_VO();
                drCurrent = p_dtbData.Rows[iRow];
                if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngTemp))
                {
                    objNewDetail[iRow].m_lngSERIESID_INT = lngTemp;
                }
                objNewDetail[iRow].m_lngSERIESID_INT2 = p_lngMainSeq;
                objNewDetail[iRow].m_intStatus = 1;
                objNewDetail[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objNewDetail[iRow].m_strMEDICINENAME_VCH = drCurrent["MEDICINENAME_VCH"].ToString();
                objNewDetail[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                if (double.TryParse(drCurrent["PACKAMOUNT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblPACKAMOUNT = dblTemp;
                }
                objNewDetail[iRow].m_strPACKUNIT_VCHR = drCurrent["PACKUNIT_VCHR"].ToString();
                if (decimal.TryParse(drCurrent["PACKCALLPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmPACKCALLPRICE_INT = dcmTemp;
                }
                if (double.TryParse(drCurrent["PACKCONVERT_INT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblPACKCONVERT_INT = dblTemp;
                }

                m_objDomain.m_lngGetMedicineTypeVisionm(drCurrent["MEDICINETYPEID_CHR"].ToString(), out m_objViewer.m_clsTypeVisVO);
                if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && drCurrent["LOTNO_VCHR"].ToString() == "")
                {
                    objNewDetail[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objNewDetail[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                }

                if (double.TryParse(drCurrent["AMOUNT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblAMOUNT = dblTemp;
                }
                if (decimal.TryParse(drCurrent["CALLPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmCALLPRICE_INT = dcmTemp;
                }
                if (decimal.TryParse(drCurrent["WHOLESALEPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmWHOLESALEPRICE_INT = dcmTemp;
                }
                if (decimal.TryParse(drCurrent["RETAILPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmRETAILPRICE_INT = dcmTemp;
                }
                objNewDetail[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();

                objNewDetail[iRow].m_strUNIT_VCHR = drCurrent["OPUNIT_CHR"].ToString();
                if (p_blnDataStauus)
                {
                    objNewDetail[iRow].m_intRUTURNNUM_INT = Convert.ToInt32(drCurrent["RUTURNNUM_INT"].ToString()) + 1;
                }
                else
                {
                    objNewDetail[iRow].m_intRUTURNNUM_INT = Convert.ToInt32(drCurrent["RUTURNNUM_INT"].ToString());
                }
                objNewDetail[iRow].m_strInStorageID = drCurrent["INSTORAGEID_VCHR"].ToString(); ;

                objNewDetail[iRow].m_strOUTSTORAGEID_VCHR = drCurrent["OUTSTORAGEID_VCHR"].ToString();
                //objNewDetail[iRow].m
                DateTime.TryParse(drCurrent["validperiod_dat"].ToString(),out objNewDetail[iRow].m_dtmVALIDPERIOD_DAT);
            }
            return objNewDetail;
        }
        #endregion

        #region 获取修改数量
        /// <summary>
        /// 获取修改数量
        /// </summary>
        /// <param name="dtbModify"></param>
        /// <param name="m_objDetailArr"></param>
        private void m_mthGetModifyData(ref DataTable dtbModify, out clsMS_StorageGrossForOut[] m_objDetailArr)
        {
            m_objDetailArr = new clsMS_StorageGrossForOut[dtbModify.Rows.Count];
            DataRow m_drDetailRow = null;
            double m_decOriginal = 0;
            double m_decCurrent = 0;
            double m_decCompute = 0;
            for (int i1 = 0; i1 < dtbModify.Rows.Count; i1++)
            {
                m_drDetailRow = dtbModify.Rows[i1];
                m_objDetailArr[i1] = new clsMS_StorageGrossForOut();
                m_decOriginal = Convert.ToDouble(m_drDetailRow["AMOUNT", DataRowVersion.Original].ToString());
                m_decCurrent = Convert.ToDouble(m_drDetailRow["AMOUNT", DataRowVersion.Current].ToString());
                m_decCompute = m_decCurrent - m_decOriginal;
                m_objDetailArr[i1].m_dblGross = m_decCompute;
                m_objDetailArr[i1].m_strStorageID = m_objViewer.m_strStorageID;
                m_objDetailArr[i1].m_strInStorageID = m_drDetailRow["INSTORAGEID_VCHR"].ToString();
                m_objDetailArr[i1].m_strMedicineID = m_drDetailRow["MEDICINEID_CHR"].ToString();
                m_objDetailArr[i1].m_strLotNO = m_drDetailRow["LOTNO_VCHR"].ToString();
            }
        }
        #endregion

        #region 删除入库明细
        /// <summary>
        /// 删除入库明细
        /// </summary>
        internal void m_mthDeleteInStorageDetail()
        {
            bool m_blnDelete = false;
            //if (!m_objViewer.m_blnIsAdmin)
            //{
            //    MessageBox.Show("当前用户没有药库管理权限", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1)
            {
                if (m_objCurrentMain.m_intSTATE_INT == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品内退记录已入帐，不能删除", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品内退记录已审核，不能删除", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            if (m_objViewer.m_dgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineDetail.SelectedCells[0].RowIndex;
            int intRowCount = 0;
            DataRow drCurrent = null;
            double m_decAmount = 0;
            long lngSEQ = 0;
            int i1 = 0;
            for (i1 = 0; i1 < m_objViewer.m_dtbDetail.Rows.Count; i1++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMedicineDetail.Rows[i1].Cells[0].Value))
                {
                    intRowCount++;
                }
            }

            clsMS_StorageDetail[] m_objOutArr = new clsMS_StorageDetail[1];
            m_objOutArr[0] = new clsMS_StorageDetail();
            i1 = 0;
            while (i1 < m_objViewer.m_dtbDetail.Rows.Count)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMedicineDetail.Rows[i1].Cells[0].Value))
                {
                    drCurrent = m_objViewer.m_dtbDetail.Rows[i1];
                    if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
                    {
                        //long lngRes = m_objDomain.m_lngDeleteInStorage(0, lngSEQ);
                        bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
                        long lngRes = m_objDomain.m_lngDeleteInStorage(lngSEQ, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(),
                            m_objViewer.m_strStorageID, string.Empty, Convert.ToDecimal(drCurrent["CALLPRICE_INT"]), blnIsCommit);
                        if (lngRes > 0)
                        {
                            ////修改库存明细可用库存
                            //double.TryParse(drCurrent["AMOUNT"].ToString(), out m_decAmount);
                            //m_objOutArr[0].m_dblAVAILAGROSS_INT = m_decAmount;
                            //m_objOutArr[0].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                            //m_objOutArr[0].m_strINSTORAGEID_VCHR = drCurrent["INSTORAGEID_VCHR"].ToString();
                            //m_objOutArr[0].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                            //m_objOutArr[0].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();

                            //m_objDomain.m_lngSubStorageDetailAvailaGrossDcl(m_objOutArr);
                            m_objViewer.m_dtbDetail.Rows.Remove(drCurrent);
                            m_blnDelete = true;
                        }
                        else
                        {
                            m_blnDelete = false;
                        }


                    }
                    else
                    {
                        i1++;
                    }

                }
                else
                {
                    i1++;
                }
            }//while 
            if (m_blnDelete)
            {
                MessageBox.Show("删除成功", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetExportDept(out p_dtbExportDept);
            objIRDomain = null;
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
            long lngRes = m_objDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        #region 审核内退药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        /// <param name="p_drCommit">审核的行</param>
        internal long  m_mthCommitMedicine()
        {
            if (m_objViewer.m_lngMainSEQ == 0)
            {
                //MessageBox.Show("没有需审核的药品内退信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            try
            {
                long lngRes = 0;
                long lngSEQ = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                DataTable dtbDetail = null;

                clsMS_StorageGrossForOut m_objStorageGrossForOut = new clsMS_StorageGrossForOut();
                clsMS_StorageGrossForOut[] m_objStorageGrossForOutArr = null;
                DataRow m_drResultRow = null;
                long[] lngSEQArr = new long[1];

                lngSEQ = m_objViewer.m_lngMainSEQ;
                //获取明细数据
                lngRes = m_objDomain.m_lngDclGetWithdrawDetailData(lngSEQ, ref dtbDetail);

                if (lngRes > 0)
                {
                    m_objStorageGrossForOutArr = new clsMS_StorageGrossForOut[dtbDetail.Rows.Count];
                    //设置审核人


                    lngSEQArr[0] = lngSEQ;
                    lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSEQArr);
                    if (lngRes <= 0)
                    {
                        //MessageBox.Show("审核失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return -1;
                    }

                    for (int j1 = 0; j1 < dtbDetail.Rows.Count; j1++)
                    {
                        m_drResultRow = dtbDetail.Rows[j1];
                        //增加库存主表当前库存
                        double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOut.m_dblGross);
                        m_objStorageGrossForOut.m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        m_objStorageGrossForOut.m_strStorageID = m_objViewer.m_strStorageID;

                        lngRes = m_objDomain.m_lngModifyStorageMain(m_objStorageGrossForOut);
                        if (lngRes <= 0)
                        {
                            //MessageBox.Show("审核失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return -1;
                        }
                        m_objStorageGrossForOutArr[j1] = new clsMS_StorageGrossForOut();
                        double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOutArr[j1].m_dblGross);
                        m_objStorageGrossForOutArr[j1].m_strStorageID = m_objViewer.m_strStorageID;
                        m_objStorageGrossForOutArr[j1].m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        m_objStorageGrossForOutArr[j1].m_strLotNO = m_drResultRow["LOTNO_VCHR"].ToString();
                        m_objStorageGrossForOutArr[j1].m_strInStorageID = m_drResultRow["INSTORAGEID_VCHR"].ToString();
                    }
                    //增加库存明细表可用库存

                    m_objDomain.m_lngAddStorageDetailAvailaGrossDcl(m_objStorageGrossForOutArr);
                    //增加库存明细表实际库存

                    lngRes = m_objDomain.m_lngDclAddStorageDetailRealGross(m_objStorageGrossForOutArr);
                    if (lngRes > 0)
                    {
                        m_objViewer.m_blnHasCommit = true;
                        m_objViewer.m_dtbMedinineMain.Rows[m_intSelectedMainRow]["STATE_INT"] = 2;
                        m_objViewer.m_dtbMedinineMain.Rows[m_intSelectedMainRow]["STATEName"] = "审核";
                        m_objViewer.m_dtbMedinineMain.Rows[m_intSelectedMainRow]["EXAM_DAT"] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                        return 1;
                        //m_objViewer.panel1.Enabled = false;
                    }
                    else if (lngRes <= 0)
                    {
                        //MessageBox.Show("审核失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return -1;
                    }

                }
                else
                {
                    //MessageBox.Show("没有需审核的药品入库信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -1;
                }


                //MessageBox.Show("审核完成", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


            }//try
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);                
            }
            return -1;
        }

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_dtbDetail">数据</param>
        /// <param name="p_strInID">入库单号</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(DataTable p_dtbDetail, string p_strInID, string p_strVendorID, string p_strVendorName)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = null;
            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_dtbDetail.Rows.Count];
            for (int iRow = 0; iRow < p_dtbDetail.Rows.Count; iRow++)
            {
                drCurrent = p_dtbDetail.Rows[iRow];
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objSubVO[iRow].m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                objSubVO[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                objSubVO[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drCurrent["RETAILPRICE_INT"]);
                objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                if (drCurrent["WHOLESALEPRICE_INT"] != DBNull.Value)
                {
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drCurrent["WHOLESALEPRICE_INT"]);
                }
                objSubVO[iRow].m_dblREALGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_strOPUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objSubVO[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_strInID;
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                objSubVO[iRow].m_strVENDORName = p_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
            }
            return objSubVO;
        }
        #endregion



        #region 设置审核人


        /// <summary>
        /// 设置审核人


        /// </summary>
        /// <param name="p_drCommit">数据</param>
        private void m_mthSetCommitUser(DataRow[] p_drCommit)
        {
            if (p_drCommit == null || p_drCommit.Length == 0)
            {
                return;
            }

            long[] lngSEQ = new long[p_drCommit.Length];
            for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
            {
                lngSEQ[iRow] = Convert.ToInt64(p_drCommit[iRow]["SERIESID_INT"]);
            }

            long lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSEQ);
        }
        #endregion


        #endregion

        #region 退审



        /// <summary>
        /// 退审

        /// </summary>
        /// <param name="p_drCurrent">选定药品数据</param>
        /// <param name="p_intRowIndex">第几行数据</param>
        internal long  m_mthUnCommit()
        {
            //if (!m_objViewer.m_blnIsAdmin)
            //{
            //    MessageBox.Show("当前用户没有药库管理权限，不能退审", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            try
            {
                long lngRes = 0;
                long lngSEQ = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                //List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                DataTable dtbDetail = null;
                //clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO
                clsMS_StorageGrossForOut m_objStorageGrossForOut = new clsMS_StorageGrossForOut();
                clsMS_StorageGrossForOut[] m_objStorageGrossForOutArr = null;
                long[] lngSEQArr = new long[1];
                DataRow m_drResultRow = null;
                clsMS_StorageDetail[] m_objOutArr = new clsMS_StorageDetail[1];
                m_objOutArr[0] = new clsMS_StorageDetail();


                lngSEQ = m_objViewer.m_lngMainSEQ;
                //获取明细数据
                lngRes = m_objDomain.m_lngDclGetWithdrawDetailData(lngSEQ, ref dtbDetail);

                if (lngRes > 0)
                {
                    m_objStorageGrossForOutArr = new clsMS_StorageGrossForOut[dtbDetail.Rows.Count];

                    lngSEQArr[0] = lngSEQ;
                    //设置审核人

                    lngRes = m_objDomain.m_lngUnCommit(lngSEQArr);
                    if (lngRes <= 0)
                    {
                        //MessageBox.Show("退审失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return -1;
                    }

                    for (int j1 = 0; j1 < dtbDetail.Rows.Count; j1++)
                    {
                        m_drResultRow = dtbDetail.Rows[j1];
                        //减少库存主表当前库存
                        double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOut.m_dblGross);
                        m_objStorageGrossForOut.m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        m_objStorageGrossForOut.m_strStorageID = m_objViewer.m_strStorageID;
                        lngRes = m_objDomain.m_lngSubModifyStorageMain(m_objStorageGrossForOut);
                        if (lngRes <= 0)
                        {
                            //MessageBox.Show("退审失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return -1;
                        }


                        m_objStorageGrossForOutArr[j1] = new clsMS_StorageGrossForOut();
                        double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objStorageGrossForOutArr[j1].m_dblGross);
                        m_objStorageGrossForOutArr[j1].m_strStorageID = m_objViewer.m_strStorageID;
                        m_objStorageGrossForOutArr[j1].m_strMedicineID = m_drResultRow["MEDICINEID_CHR"].ToString();
                        m_objStorageGrossForOutArr[j1].m_strLotNO = m_drResultRow["LOTNO_VCHR"].ToString();
                        m_objStorageGrossForOutArr[j1].m_strInStorageID = m_drResultRow["INSTORAGEID_VCHR"].ToString();

                        //修改库存明细可用库存
                        double.TryParse(m_drResultRow["AMOUNT"].ToString(), out m_objOutArr[0].m_dblAVAILAGROSS_INT);
                        m_objOutArr[0].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                        m_objOutArr[0].m_strINSTORAGEID_VCHR = m_drResultRow["INSTORAGEID_VCHR"].ToString();
                        m_objOutArr[0].m_strMEDICINEID_CHR = m_drResultRow["MEDICINEID_CHR"].ToString();
                        m_objOutArr[0].m_strLOTNO_VCHR = m_drResultRow["LOTNO_VCHR"].ToString();

                        m_objDomain.m_lngSubStorageDetailAvailaGrossDcl(m_objOutArr);

                    }
                    //减少库存明细表实际库存

                    lngRes = m_objDomain.m_lngDclSubStorageDetailRealGross(m_objStorageGrossForOutArr);

                    if (lngRes > 0)
                    {
                        //MessageBox.Show("退审完成", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_objViewer.m_blnHasCommit = false;
                        return 1;
                    }
                    else if (lngRes <= 0)
                    {
                        //MessageBox.Show("退审失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return -1;
                    }
                }
                else
                {
                    //MessageBox.Show("没有需退审的药品入库信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -1;
                }               

            }//try
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return -1;
        }
        #endregion

        #region 检查是否有药库管理权限
        /// <summary>
        /// 检查是否有药库管理权限
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有权限</param>
        internal void m_mthCheckHasAdminRole(string strEmpID, out bool p_blnHasRole)
        {
            long lngRes = m_objDomain.m_lngCheckEmpHasRole(strEmpID, out p_blnHasRole);
        }
        #endregion

        #region 计算明细金额
        /// <summary>
        /// 计算明细金额
        /// </summary>
        internal void m_mthGetAllSubMoney()
        {
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (m_objViewer.m_dtbDetail != null)
            {
                double dcmBuyIn = 0d;                
                double dcmRetailSale = 0d;
                double dblCallSum = 0d;
                double dblRetailSum = 0d;
                DataRow drTemp = null;
                for (int iM = 0; iM < m_objViewer.m_dtbDetail.Rows.Count; iM++)
                {
                    drTemp = m_objViewer.m_dtbDetail.Rows[iM];

                    double.TryParse(drTemp["callsum"].ToString(), out dblCallSum);
                    double.TryParse(drTemp["RetailSum"].ToString(), out dblRetailSum);
                    dcmBuyIn += dblCallSum;
                    //dcmWholeSale += Convert.ToDouble(drTemp["WHOLESALEPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                    dcmRetailSale += dblRetailSum;
                }

                m_objViewer.m_lblBuyInSubMoney.Text = dcmBuyIn.ToString("0.0000");
                m_objViewer.m_lblRetailSubMoney.Text = dcmRetailSale.ToString("0.0000");
                //m_objViewer.m_lblWholeSaleSubMoney.Text = dcmWholeSale.ToString("0.0000");
            }
        }
        #endregion

        #region 获取是否审核即入帐

        /// <summary>
        /// 获取是否审核即入帐

        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        internal void m_mthGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetIsImmAccount(out p_blnIsImmAccount);
            objPDDomain = null;
        }
        #endregion

        
        public long m_mthGetMedicineTypeVisionm(string p_strMedicineTypeID,out clsMS_MedicineTypeVisionmSet p_objTypeVO)
        {
           long res = m_objDomain.m_lngGetMedicineTypeVisionm(p_strMedicineTypeID, out p_objTypeVO); ;
           return res;
        }

        #region 获取药品是否已调价

        /// <summary>
        /// 获取药品是否已调价

        /// </summary>
        /// <param name="medicineid_chr">药品ID</param>
        /// <param name="lotno_vchr">批号</param>
        /// <param name="instorageid_vchr">入库单号</param>
        /// <param name="p_dblAdjustrice"></param>
        /// <returns></returns>
        public long m_mthGetAdjustrice(string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, out bool p_dblAdjustrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            p_dblAdjustrice = false;
            if (m_objCurrentMain == null)
                return lngRes;
            lngRes = objSvc.m_mthGetAdjustrice(objPrincipal, medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, m_objCurrentMain.m_dtmNEWORDER_DAT, out p_dblAdjustrice);
            return lngRes;
        }
        #endregion

    }

    #endregion
}
