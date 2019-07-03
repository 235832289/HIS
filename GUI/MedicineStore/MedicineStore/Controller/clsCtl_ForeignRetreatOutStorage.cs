using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品外退
    /// </summary>
    public class clsCtl_ForeignRetreatOutStorage : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_ForeignRetreatOutStorage m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmForeignRetreatOutStorage m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询供应商控件

        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商

        /// </summary>
        private DataTable m_dtbVendor = null;
        #endregion

        #region 构造函数

        /// <summary>
        /// 药品外退
        /// </summary>
        public clsCtl_ForeignRetreatOutStorage()
        {
            m_objDomain = new clsDcl_ForeignRetreatOutStorage();
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
            m_objViewer = (frmForeignRetreatOutStorage)frmMDI_Child_Base_in;
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
            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            long lngRes = objPDomain.m_lngCheckEmpHasRole(strEmpID, out p_blnHasRole);
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 显示药品字典最小元素信息查询窗体

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineName.Location.X + m_objViewer.panel1.Location.X;
                Y = m_objViewer.m_txtMedicineName.Location.Y + m_objViewer.m_txtMedicineName.Size.Height + m_objViewer.panel1.Location.Y;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtMedicineName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineName.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_txtBillNumber.Focus();
        }
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strVendor">供应商ID或名称</param>
        /// <param name="p_strMedicine">药品ID或名称</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        internal void m_mthGetMainData(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strVendor, string p_strMedicine, out DataTable p_dtbOutStorage)
        {
            long lngRes = m_objDomain.m_lngGetOutStorageMain(p_strStorageID, p_dtmBegin, p_dtmEnd,p_strVendor,p_strMedicine,out p_dtbOutStorage);


            if (p_dtbOutStorage != null)
            {
                string strUnCommit = "STATUS = 1 and EXAMERID_CHR is not null";
                DataRow[] drUnCommit = p_dtbOutStorage.Select(strUnCommit);
                if (drUnCommit != null && drUnCommit.Length > 0)
                {
                    for (int iRow = 0; iRow < drUnCommit.Length; iRow++)
                    {
                        drUnCommit[iRow]["EXAMERID_CHR"] = DBNull.Value;
                        drUnCommit[iRow]["examername"] = DBNull.Value;
                        drUnCommit[iRow]["EXAMDATE_DAT"] = DBNull.Value;
                    }
                }
            }
        }
        #endregion

        #region 过滤主表信息
        /// <summary>
        /// 获取主表过滤条件
        /// </summary>
        /// <returns></returns>
        private string m_strMainFilter()
        {
            string strFilterMain = string.Empty;

            if (m_objViewer.m_cboBillState.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterMain))
                {
                    strFilterMain += " and ";
                }
                strFilterMain += " STATUS = " + (m_objViewer.m_cboBillState.SelectedIndex).ToString();
            }

            if (!string.IsNullOrEmpty(m_objViewer.m_txtBillNumber.Text))
            {
                if (!string.IsNullOrEmpty(strFilterMain))
                {
                    strFilterMain += "and ";
                }
                strFilterMain += " outstorageid_vchr like '" + m_objViewer.m_txtBillNumber.Text + "%'";
            }
            return strFilterMain;
        }

        /// <summary>
        /// 过滤主表信息
        /// </summary>
        internal void m_mthFilterMainDataPage1()
        {
            if (m_objViewer.m_dtbSubData != null)
            {
                m_objViewer.m_dtbSubData.Rows.Clear();
            }

            string strFilterMain = m_strMainFilter();

            m_objViewer.m_dtvCurrentMainView = new DataView(m_objViewer.m_dtbMainData);
            m_objViewer.m_dtvCurrentMainView.RowFilter = strFilterMain;
            m_objViewer.m_dgvMain.DataSource = m_objViewer.m_dtvCurrentMainView;

            m_objViewer.m_dgvMain.Refresh();

            m_mthGetAllMoney();
            if (m_objViewer.m_dgvMain.Rows.Count > 0)
            {
                if (m_objViewer.m_dgvMain.CurrentCell == null)
                {
                    m_objViewer.m_dgvMain.Rows[0].Selected = true;
                    m_objViewer.m_dgvMain.CurrentCell = m_objViewer.m_dgvMain.Rows[0].Cells[1];
                    m_objViewer.m_dgvMain.CurrentCell.Selected = true;
                }
                else
                {
                    int intCurrentRow = m_objViewer.m_dgvMain.CurrentCell.RowIndex;
                    m_objViewer.m_dgvMain.Rows[intCurrentRow].Selected = true;
                    m_objViewer.m_dgvMain.CurrentCell.Selected = true;
                }
            }
            else
            {
                if (m_objViewer.m_dtbSubData != null)
                {
                    m_objViewer.m_dtbSubData.Rows.Clear();
                }
            }
        }
        #endregion

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        internal void m_mthGetAllMoney()
        {
            m_objViewer.m_lblBuyInMoney.Text = string.Empty;
            m_objViewer.m_lblRetailMoney.Text = string.Empty;

            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));

            clsDcl_OutStorage objOSDomain = new clsDcl_OutStorage();
            if (m_objViewer.m_dtbAllMoney == null)
            {
                long lngRes = objOSDomain.m_lngGetAllInMoney(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, 2, out m_objViewer.m_dtbAllMoney);
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtbAllMoney.Rows.Count == 0)
            {
                m_objViewer.m_dtbAllMoney = null;
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtvCurrentMainView != null)
            {
                //StringBuilder stbFilter = new StringBuilder(100);
                int intRowsCount = m_objViewer.m_dtvCurrentMainView.Count;
                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    hstMedicine.Add(Convert.ToInt64(m_objViewer.m_dtvCurrentMainView[iRow]["seriesid_int"]), m_objViewer.m_dtvCurrentMainView[iRow]["outstorageid_vchr"].ToString());
                }

                string strFilterResult = m_strMainFilter();

                //if (!string.IsNullOrEmpty(strFilterResult))
                //{
                DataRow[] drAllMoney = m_objViewer.m_dtbAllMoney.Select(strFilterResult);

                if (drAllMoney != null && drAllMoney.Length > 0)
                {
                    decimal dcmBuyIn = 0m;
                    decimal dcmRetailSale = 0m;
                    for (int iM = 0; iM < drAllMoney.Length; iM++)
                    {
                        if (!hstMedicine.Contains(Convert.ToInt64(drAllMoney[iM]["seriesid_int"])))
                        {
                            continue;
                        }
                        dcmBuyIn += Convert.ToDecimal(drAllMoney[iM]["BuyInMoney"]);
                        dcmRetailSale += Convert.ToDecimal(drAllMoney[iM]["RetailPrice"]);
                    }

                    m_objViewer.m_lblBuyInMoney.Text = dcmBuyIn.ToString("0.0000");
                    m_objViewer.m_lblRetailMoney.Text = dcmRetailSale.ToString("0.0000");
                }
                //}
            }
        }

        /// <summary>
        /// 获取明细金额
        /// </summary>
        internal void m_mthGetAllSubMoney()
        {
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblWholeSaleSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (m_objViewer.m_dtbSubData != null)
            {
                double dcmBuyIn = 0d;
                double dcmWholeSale = 0d;
                double dcmRetailSale = 0d;
                DataRow drTemp = null;
                for (int iM = 0; iM < m_objViewer.m_dtbSubData.Rows.Count; iM++)
                {
                    drTemp = m_objViewer.m_dtbSubData.Rows[iM];
                    dcmBuyIn += Convert.ToDouble(drTemp["CALLPRICE_INT"]) * Convert.ToDouble(drTemp["netamount_int"]);
                    dcmWholeSale += Convert.ToDouble(drTemp["WHOLESALEPRICE_INT"]) * Convert.ToDouble(drTemp["netamount_int"]);
                    dcmRetailSale += Convert.ToDouble(drTemp["RETAILPRICE_INT"]) * Convert.ToDouble(drTemp["netamount_int"]);
                }

                m_objViewer.m_lblBuyInSubMoney.Text = dcmBuyIn.ToString("0.0000");
                m_objViewer.m_lblRetailSubMoney.Text = dcmRetailSale.ToString("0.0000");
                m_objViewer.m_lblWholeSaleSubMoney.Text = dcmWholeSale.ToString("0.0000");
                m_objViewer.m_lblly.Text = ((double)(dcmRetailSale - dcmBuyIn)).ToString("0.0000");
            }
        }
        #endregion

        #region 修改出库
        /// <summary>
        /// 修改出库
        /// </summary>
        internal void m_mthModify(out clsMS_OutStorage_VO p_objMain, out clsMS_OutStorageDetail_VO[] p_objDetail)
        {
            p_objMain = null;
            p_objDetail = null;

            #region 主表
            clsMS_OutStorage_VO objMain = null;
            if (m_objViewer.m_dgvMain.SelectedRows.Count == 1)
            {
                DataRowView drvMain = m_objViewer.m_dtvCurrentMainView[m_objViewer.m_dgvMain.SelectedRows[0].Index];
                objMain = new clsMS_OutStorage_VO();
                DateTime dtmTemp = DateTime.MinValue;
                if (DateTime.TryParse(drvMain["ASKDATE_DAT"].ToString(), out dtmTemp))
                {
                    objMain.m_dtmASKDATE_DAT = dtmTemp;
                }
                if (DateTime.TryParse(drvMain["OUTSTORAGEDATE_DAT"].ToString(), out dtmTemp))
                {
                    objMain.m_dtmOutStorageDate = dtmTemp;
                }
                else
                {
                    objMain.m_dtmOutStorageDate = DateTime.Now;
                }
                if (DateTime.TryParse(drvMain["EXAMDATE_DAT"].ToString(), out dtmTemp))
                {
                    objMain.m_dtmEXAMDATE_DAT = dtmTemp;
                }
                if (DateTime.TryParse(drvMain["INACCOUNTDATE_DAT"].ToString(), out dtmTemp))
                {
                    objMain.m_dtmINACCOUNTDATE_DAT = dtmTemp;
                }
                objMain.m_intFORMTYPE_INT = Convert.ToInt32(drvMain["FORMTYPE"]);
                objMain.m_intOutStorageTYPE_INT = Convert.ToInt32(drvMain["OUTSTORAGETYPE_INT"]);
                objMain.m_intSTATUS = Convert.ToInt32(drvMain["STATUS"]);
                objMain.m_lngSERIESID_INT = Convert.ToInt64(drvMain["SERIESID_INT"]);
                objMain.m_strASKDEPT_CHR = drvMain["ASKDEPT_CHR"].ToString().Trim();
                objMain.m_strASKDEPTName = drvMain["askdeptname"].ToString();
                objMain.m_strASKERID_CHR = drvMain["ASKERID_CHR"].ToString();
                objMain.m_strASKERName = drvMain["askername"].ToString();
                objMain.m_strASKID_VCHR = drvMain["ASKID_VCHR"].ToString();
                objMain.m_strCOMMENT_VCHR = drvMain["COMMENT_VCHR"].ToString();
                objMain.m_strEXAMERID_CHR = drvMain["EXAMERID_CHR"].ToString();
                objMain.m_strEXAMERName = drvMain["examername"].ToString();
                objMain.m_strEXPORTDEPT_CHR = drvMain["EXPORTDEPT_CHR"].ToString();
                objMain.m_strINACCOUNTID_CHR = drvMain["INACCOUNTID_CHR"].ToString();
                objMain.m_strOUTSTORAGEID_VCHR = drvMain["OUTSTORAGEID_VCHR"].ToString();
                objMain.m_strPARENTNID = drvMain["PARENTNID"].ToString();
                objMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            }

            if (objMain == null)
            {
                return;
            }
            p_objMain = objMain;
            #endregion

            #region 子表
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            DataView dvSub = m_objViewer.m_dgvDetail.DataSource as DataView;
            if (dvSub != null && dvSub.Count > 0)
            {
                DataRowView drvTemp = null;
                objDetailArr = new clsMS_OutStorageDetail_VO[dvSub.Count];

                for (int iRow = 0; iRow < dvSub.Count; iRow++)
                {
                    drvTemp = dvSub[iRow];
                    objDetailArr[iRow] = new clsMS_OutStorageDetail_VO();
                    objDetailArr[iRow].m_dblNETAMOUNT_INT = Convert.ToDouble(drvTemp["NETAMOUNT_INT"]);
                    objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drvTemp["CALLPRICE_INT"]);
                    objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drvTemp["RETAILPRICE_INT"]);
                    objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drvTemp["WHOLESALEPRICE_INT"]);
                    objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drvTemp["instoragedate_dat"]);
                    objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(drvTemp["validperiod_dat"]);
                    objDetailArr[iRow].m_lngSERIESID_INT = Convert.ToInt64(drvTemp["SERIESID_INT"]);
                    objDetailArr[iRow].m_lngSERIESID2_INT = Convert.ToInt64(drvTemp["SERIESID2_INT"]);
                    objDetailArr[iRow].m_strINSTORAGEID_VCHR = drvTemp["INSTORAGEID_VCHR"].ToString();
                    objDetailArr[iRow].m_strLOTNO_VCHR = drvTemp["LOTNO_VCHR"].ToString();
                    objDetailArr[iRow].m_strMEDICINEID_CHR = drvTemp["MEDICINEID_CHR"].ToString();
                    objDetailArr[iRow].m_strMEDICINENAME_VCH = drvTemp["MEDICINENAME_VCH"].ToString();
                    objDetailArr[iRow].m_strMEDSPEC_VCHR = drvTemp["MEDSPEC_VCHR"].ToString();
                    objDetailArr[iRow].m_strOPUNIT_CHR = drvTemp["OPUNIT_CHR"].ToString();
                    objDetailArr[iRow].m_strProductorID_chr = drvTemp["productorid_chr"].ToString();
                    objDetailArr[iRow].m_strVENDORID_CHR = drvTemp["VENDORID_CHR"].ToString();
                    objDetailArr[iRow].m_strVendorName = drvTemp["vendorname_vchr"].ToString();
                    if (drvTemp["askamount"] != DBNull.Value)
                    {
                        objDetailArr[iRow].m_dblAskAmount = Convert.ToDouble(drvTemp["askamount"]);
                    }
                    //if (drvTemp["inmoney"] != DBNull.Value)
                    //{
                    //    objDetailArr[iRow].m_dcmBuyInMoney = Convert.ToDecimal(drvTemp["inmoney"]);
                    //}
                    //if (drvTemp["retailmoney"] != DBNull.Value)
                    //{
                    //    objDetailArr[iRow].m_dcmRetailMoney = Convert.ToDecimal(drvTemp["retailmoney"]);
                    //}
                    if (drvTemp["realgross_int"] != DBNull.Value)
                    {
                        objDetailArr[iRow].m_dblRealGross = Convert.ToDouble(drvTemp["realgross_int"]);
                    }
                    if (drvTemp["availagross_int"] != DBNull.Value)
                    {
                        objDetailArr[iRow].m_dblAvailaGross = Convert.ToDouble(drvTemp["availagross_int"]);
                    }
                    objDetailArr[iRow].m_strStorageUnit = drvTemp["storageunit"].ToString();
                    objDetailArr[iRow].m_strMEDICINECode = drvTemp["assistcode_chr"].ToString();
                    objDetailArr[iRow].m_strMedicineTypeID_chr = drvTemp["medicinetypeid_chr"].ToString();
                }
            }
            p_objDetail = objDetailArr;
            #endregion
        } 
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        internal void m_mthGetOutStorageDetail(long p_lngMainSEQ, out DataTable p_dtbValue)
        {
            clsDcl_OutStorage objOSDomain = new clsDcl_OutStorage();
            long lngRes = objOSDomain.m_lngGetOutStorageDetail(p_lngMainSEQ, out p_dtbValue);
        }
        #endregion

        #region 删除出库药品信息
        /// <summary>
        /// 删除出库药品信息
        /// </summary>
        internal void m_mthDeleteOutStorage()
        {
            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            bool blnNewState = false;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                    clsDcl.m_lngCheckBillState(2, m_objViewer.m_dtvCurrentMainView[iSe]["OUTSTORAGEID_VCHR"].ToString(), out blnNewState);
                    if (!blnNewState)
                    {
                        MessageBox.Show("已选中的出库单，包含不是新制状态的单据，请刷新后重试", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    int intState = Convert.ToInt32(m_objViewer.m_dtvCurrentMainView[iSe]["STATUS"]);
                    if (intState == 2 || intState == 3)//已审核或已入帐

                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvCurrentMainView[iSe]["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvCurrentMainView[iSe]["SERIESID_INT"]));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                System.Windows.Forms.DialogResult drResultQ = System.Windows.Forms.MessageBox.Show("部分已选择记录已审核或已入账，将不能删除，是否继续？", "药品入库", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
                if (drResultQ == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择一条新制药品入库信息", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            System.Windows.Forms.DialogResult drResult = System.Windows.Forms.MessageBox.Show("是否删除选中记录？", "药品出库", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);
            if (drResult == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            clsMS_StorageGrossForOut[] objGetOutValue = m_objGetOutValue(lngCheckRowIndex.ToArray());

            clsDcl_OutStorage objOSDomain = new clsDcl_OutStorage();
            long lngRes = objOSDomain.m_lngDeleteMainOutStorage(lngCheckRowIndex.ToArray());
            objOSDomain = null;
            if (lngRes > 0)
            {
                m_mthAddAvailaGross(objGetOutValue);
                System.Windows.Forms.MessageBox.Show("删除成功", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                StringBuilder stbFilter = new StringBuilder(50);
                for (int iSer = 0; iSer < lngCheckRowIndex.Count; iSer++)
                {
                    stbFilter.Append(" SERIESID_INT = '");
                    stbFilter.Append(lngCheckRowIndex[iSer]);
                    stbFilter.Append("'");
                    if (iSer < lngCheckRowIndex.Count - 1)
                    {
                        stbFilter.Append(" or ");
                    }
                }
                DataRow[] drRemove = m_objViewer.m_dtbMainData.Select(stbFilter.ToString());
                if (drRemove != null && drRemove.Length > 0)
                {
                    for (int iRev = 0; iRev < drRemove.Length; iRev++)
                    {
                        m_objViewer.m_dtbMainData.Rows.Remove(drRemove[iRev]);
                    }
                }

                DataView dtvSub = m_objViewer.m_dgvDetail.DataSource as DataView;
                if (m_objViewer.m_dtvCurrentMainView.Count == 0 && dtvSub != null)
                {
                    dtvSub.Table.Rows.Clear();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("删除失败", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 删除未审核记录时库存表增加可用库存


        /// <summary>
        /// 从界面获取出库信息

        /// </summary>
        /// <param name="p_lngMainSeq"></param>
        /// <returns></returns>
        private clsMS_StorageGrossForOut[] m_objGetOutValue(long[] p_lngMainSeq)
        {
            if (p_lngMainSeq == null || p_lngMainSeq.Length == 0)
            {
                return null;
            }

            clsDcl_OutStorage objOSDomain = new clsDcl_OutStorage();
            clsMS_StorageGrossForOut[] objSubArr = null;
            List<clsMS_StorageGrossForOut> lisDetail = new List<clsMS_StorageGrossForOut>();
            long lngRes = 0;
            DataTable dtbDetail = null;
            for (int iSEQ = 0; iSEQ < p_lngMainSeq.Length; iSEQ++)
            {
                lngRes = objOSDomain.m_lngGetOutStorageDetail(p_lngMainSeq[iSEQ], out dtbDetail);
                objSubArr = m_objGetDetail(dtbDetail);
                if (objSubArr != null && objSubArr.Length > 0)
                {
                    lisDetail.AddRange(objSubArr);
                }
            }
            objOSDomain = null;

            if (lisDetail.Count > 0)
            {
                objSubArr = lisDetail.ToArray();
            }
            return objSubArr;
        }

        /// <summary>
        /// 删除未审核记录后库存表增加可用库存

        /// </summary>
        /// <param name="p_objGetOutValue">出库信息</param>
        private void m_mthAddAvailaGross(clsMS_StorageGrossForOut[] p_objGetOutValue)
        {
            if (p_objGetOutValue == null || p_objGetOutValue.Length == 0)
            {
                return;
            }

            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            long lngRes = objSTDomain.m_lngAddStorageDetailAvailaGross(p_objGetOutValue);
        }
        #endregion

        #region 获取库存子表VO
        /// <summary>
        /// 获取库存子表VO
        /// </summary>
        /// <param name="p_dtbDetail">出库子表数据</param>
        /// <returns></returns>
        private clsMS_StorageGrossForOut[] m_objGetDetail(DataTable p_dtbDetail)
        {
            clsMS_StorageGrossForOut[] objDetailArr = null;

            if (p_dtbDetail == null)
            {
                return null;
            }

            int intRowsCount = p_dtbDetail.Rows.Count;
            if (intRowsCount > 0)
            {
                objDetailArr = new clsMS_StorageGrossForOut[intRowsCount];
            }
            DataRow drvTemp = null;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drvTemp = p_dtbDetail.Rows[iRow];
                objDetailArr[iRow] = new clsMS_StorageGrossForOut();
                objDetailArr[iRow].m_strMedicineID = drvTemp["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strStorageID = m_objViewer.m_strStorageID;
                objDetailArr[iRow].m_strInStorageID = drvTemp["INSTORAGEID_VCHR"].ToString();
                objDetailArr[iRow].m_strLotNO = drvTemp["LOTNO_VCHR"].ToString();
                objDetailArr[iRow].m_dblGross = Convert.ToDouble(drvTemp["NETAMOUNT_INT"]);
                objDetailArr[iRow].m_dblInPrice = Convert.ToDouble(drvTemp["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dtmValidDate = Convert.ToDateTime(drvTemp["VALIDPERIOD_DAT"]);
            }
            return objDetailArr;
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

        #region 审核出库
        /// <summary>
        /// 审核出库
        /// </summary>
        internal void m_mthCommitOutStorage()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                System.Windows.Forms.MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            bool blnNewState = false;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = m_objViewer.m_dtvCurrentMainView[iSe].Row;

                    clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                    clsDcl.m_lngCheckBillState(2, drCheck["OUTSTORAGEID_VCHR"].ToString(), out blnNewState);
                    if (!blnNewState)
                    {
                        MessageBox.Show("已选中的外退单，包含不是新制状态的单据，请刷新后重试", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    
                    if (drCheck["STATUS"].ToString() == "1")
                    {
                        lstCheck.Add(drCheck);
                    }
                }
            }

            if (lstCheck.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择需审核的药品出库信息", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] drNew = lstCheck.ToArray();

            if (drNew == null || drNew.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("没有需审核的药品出库信息", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                string strCurrentOutStorageID = string.Empty;
                long[] lngMainSEQ = new long[drNew.Length];
                for (int iMSeq = 0; iMSeq < drNew.Length; iMSeq++)
                {
                    lngMainSEQ[iMSeq] = Convert.ToInt64(drNew[iMSeq]["SERIESID_INT"]);
                }

                clsDcl_OutStorage objOSDomain = new clsDcl_OutStorage();
                clsMS_StorageGrossForOut[] objSubArr = null;
                clsMS_AccountDetail_VO[] objAccount = null;
                long lngRes = 0;
                DataTable dtbDetail = null;
                for (int iSEQ = 0; iSEQ < lngMainSEQ.Length; iSEQ++)
                {
                    strCurrentOutStorageID = drNew[iSEQ]["OUTSTORAGEID_VCHR"].ToString();
                    lngRes = objOSDomain.m_lngGetOutStorageDetail(lngMainSEQ[iSEQ], out dtbDetail);
                    objSubArr = m_objGetDetail(dtbDetail);
                    if (objSubArr != null && objSubArr.Length > 0)
                    {
                        objAccount = m_objAccountDetailArr(dtbDetail, Convert.ToInt32(drNew[iSEQ]["FORMTYPE"]), strCurrentOutStorageID);
                        lngRes = objOSDomain.m_lngCommitOutStorage(objSubArr, objAccount, m_objViewer.LoginInfo.m_strEmpID, lngMainSEQ[iSEQ], m_objViewer.m_blnIsImmAccount);

                        if (lngRes > 0)
                        {
                            m_mthUpdateUIAfterCommit(drNew[iSEQ]);
                        }
                    }
                }

                //if (lisDetail.Count > 0)
                //{
                //    clsDcl_Storage objSTDomain = new clsDcl_Storage();
                //    lngRes = objSTDomain.m_lngSubStorageDetailRealGross(lisDetail.ToArray());

                //    for (int iList = 0; iList < lisDetail.Count; iList++)
                //    {
                //        lngRes = objSTDomain.m_lngSubStorageGross(lisDetail[iList]);
                //    }
                //    objSTDomain = null;

                //    if (lngRes > 0)
                //    {
                //        lngRes = objOSDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngMainSEQ);
                //    }

                //    if (lngRes > 0)
                //    {
                //        p_drCommit = drNew;
                //    }
                //}
                objOSDomain = null;

                if (lngRes > 0)
                {
                    MessageBox.Show("审核完成", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("审核失败", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_drNew">数据</param>
        internal void m_mthUpdateUIAfterCommit(DataRow p_drNew)
        {
            if (p_drNew == null)
            {
                return;
            }

            p_drNew["EXAMERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
            p_drNew["examername"] = m_objViewer.LoginInfo.m_strEmpName;
            p_drNew["STATUS"] = m_objViewer.m_blnIsImmAccount ? 3 : 2;
            p_drNew["EXAMDATE_DAT"] = DateTime.Now;
            p_drNew["statusdesc"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";

            if (m_objViewer.m_dtvCurrentMainView.Count == 0)
            {
                m_objViewer.m_dtbSubData.Rows.Clear();
            }
        }
        #endregion

        #region 获取入帐明细内容
        /// <summary>
        /// 获取入帐明细内容
        /// </summary>
        /// <param name="p_dtbOutDetail">出库明细</param>
        /// <param name="p_intOutType">出库类型</param>
        /// <param name="p_strOutStorageID">出库ID</param>
        /// <returns></returns>
        private clsMS_AccountDetail_VO[] m_objAccountDetailArr(DataTable p_dtbOutDetail, int p_intOutType, string p_strOutStorageID)
        {
            if (p_dtbOutDetail == null || p_dtbOutDetail.Rows.Count == 0)
            {
                return null;
            }

            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            int intRowsCount = p_dtbOutDetail.Rows.Count;
            clsMS_AccountDetail_VO[] objAccArr = new clsMS_AccountDetail_VO[intRowsCount];

            int intAccState = m_objViewer.m_blnIsImmAccount ? 1 : 2;//入帐明细状态

            DateTime dtmInDate = m_objViewer.m_blnIsImmAccount ? dtmNow : DateTime.MinValue;//入账日期
            string strInEmp = m_objViewer.m_blnIsImmAccount ? m_objViewer.LoginInfo.m_strEmpID : string.Empty;//入账人


            DataRow drTemp = null;
            for (int iAcc = 0; iAcc < intRowsCount; iAcc++)
            {
                drTemp = p_dtbOutDetail.Rows[iAcc];
                objAccArr[iAcc] = new clsMS_AccountDetail_VO();
                objAccArr[iAcc].m_dblAMOUNT_INT = Convert.ToDouble(drTemp["NETAMOUNT_INT"]);
                objAccArr[iAcc].m_dblCALLPRICE_INT = Convert.ToDouble(drTemp["CALLPRICE_INT"]);
                objAccArr[iAcc].m_dblOLDGROSS_INT = Convert.ToDouble(drTemp["realgross_int"]);
                objAccArr[iAcc].m_dblRETAILPRICE_INT = Convert.ToDouble(drTemp["retailprice_int"]);
                objAccArr[iAcc].m_dblWHOLESALEPRICE_INT = Convert.ToDouble(drTemp["wholesaleprice_int"]);
                objAccArr[iAcc].m_dtmINACCOUNTDATE_DAT = dtmInDate;
                objAccArr[iAcc].m_intFORMTYPE_INT = p_intOutType;
                objAccArr[iAcc].m_intISEND_INT = 0;
                objAccArr[iAcc].m_intSTATE_INT = intAccState;
                objAccArr[iAcc].m_intTYPE_INT = 2;
                objAccArr[iAcc].m_strCHITTYID_VCHR = p_strOutStorageID;
                objAccArr[iAcc].m_strDEPTID_CHR = drTemp["vendorid_chr"].ToString();
                objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                objAccArr[iAcc].m_strINSTORAGEID_VCHR = drTemp["INSTORAGEID_VCHR"].ToString();
                objAccArr[iAcc].m_strLOTNO_VCHR = drTemp["LOTNO_VCHR"].ToString();
                objAccArr[iAcc].m_strMEDICINEID_CHR = drTemp["MEDICINEID_CHR"].ToString();
                objAccArr[iAcc].m_strMEDICINENAME_VCH = drTemp["MEDICINENAME_VCH"].ToString();
                objAccArr[iAcc].m_strMEDICINETYPEID_CHR = drTemp["medicinetypeid_chr"].ToString();
                objAccArr[iAcc].m_strMEDSPEC_VCHR = drTemp["MEDSPEC_VCHR"].ToString();
                objAccArr[iAcc].m_strOPUNIT_CHR = drTemp["OPUNIT_CHR"].ToString();
                objAccArr[iAcc].m_dtmValidDate = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
                objAccArr[iAcc].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objAccArr[iAcc].m_dtmOperateDate = dtmNow;
            }
            return objAccArr;
        }
        #endregion

        #region 退审


        /// <summary>
        /// 退审

        /// </summary>
        internal void m_mthUnCommitOutStorage()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                System.Windows.Forms.MessageBox.Show("当前用户没有药库管理权限，不能退审", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheckRow = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = m_objViewer.m_dtvCurrentMainView[iSe].Row;
                    if (drCheck["STATUS"].ToString() == "2")
                    {
                        lstCheckRow.Add(drCheck);
                    }
                }
            }

            if (lstCheckRow.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择需退审的药品出库信息", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] drCommit = lstCheckRow.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("没有符合退审条件的药品出库信息", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                return;
            }

            long[] lngMainSEQ = new long[drCommit.Length];
            for (int iRow = 0; iRow < drCommit.Length; iRow++)
            {
                lngMainSEQ[iRow] = Convert.ToInt64(drCommit[iRow]["SERIESID_INT"]);
            }

            clsDcl_OutStorage objOSDomain = new clsDcl_OutStorage();
            //long lngRes = objOSDomain.m_lngUnCommit(lngMainSEQ);
            long lngRes = 0;

            clsMS_StorageGrossForOut[] objSubArr = null;
            //List<clsMS_StorageGrossForOut> lisDetail = new List<clsMS_StorageGrossForOut>();
            DataTable dtbDetail = null;
            for (int iSEQ = 0; iSEQ < lngMainSEQ.Length; iSEQ++)
            {
                lngRes = objOSDomain.m_lngGetOutStorageDetail(lngMainSEQ[iSEQ], out dtbDetail);
                objSubArr = m_objGetDetail(dtbDetail);
                if (objSubArr != null && objSubArr.Length > 0)
                {
                    lngRes = objOSDomain.m_lngUnCommitOutStorage(objSubArr, lngMainSEQ[iSEQ], drCommit[iSEQ]["OUTSTORAGEID_VCHR"].ToString(), m_objViewer.m_strStorageID);
                    if (lngRes > 0)
                    {
                        m_mthUpdateUIAfterUnCommit(drCommit[iSEQ]);
                    }
                }
            }

            if (lngRes > 0)
            {
                if (m_objViewer.m_dgvMain.Rows.Count > 0)
                {
                    m_objViewer.m_dgvMain.Rows[0].Selected = true;
                }
                else
                {
                    if (m_objViewer.m_dtbSubData != null)
                    {
                        m_objViewer.m_dtbSubData.Rows.Clear();
                    }
                }
                System.Windows.Forms.MessageBox.Show("退审完成", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("退审失败", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            objOSDomain = null;
        }

        /// <summary>
        /// 退审后更新界面
        /// </summary>
        /// <param name="p_drNew">数据</param>
        private void m_mthUpdateUIAfterUnCommit(DataRow p_drNew)
        {
            if (p_drNew == null )
            {
                return;
            }

            p_drNew["examername"] = DBNull.Value;
            p_drNew["STATUS"] = 1;
            p_drNew["EXAMDATE_DAT"] = DBNull.Value;
            p_drNew["statusdesc"] = "新制";
        }
        #endregion

        #region 显示供应商查询


        /// <summary>
        /// 获取供应商信息

        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }
        /// <summary>
        /// 显示供应商查询

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);
                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.panel1.Location.X + m_objViewer.m_txtProviderName.Location.X;
                int Y = m_objViewer.panel1.Location.Y + m_objViewer.m_txtProviderName.Location.Y + m_objViewer.m_txtProviderName.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProviderName.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProviderName.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProviderName.Text = MS_VO.m_strVendorName;

            m_objViewer.m_cboBillState.Focus();
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        internal void m_mthInAccount()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能入帐", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheckRow = new List<DataRow>();
            List<long> lstSeq = new List<long>();//主表序列
            List<string> lstOutStorageID = new List<string>();//出库单据号

            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = m_objViewer.m_dtvCurrentMainView[iSe].Row;
                    if (drCheck["STATUS"].ToString() == "2")
                    {
                        lstCheckRow.Add(drCheck);
                        lstSeq.Add(Convert.ToInt64(drCheck["SERIESID_INT"]));
                        lstOutStorageID.Add(drCheck["OUTSTORAGEID_VCHR"].ToString());
                    }
                }
            }

            if (lstCheckRow.Count == 0)
            {
                MessageBox.Show("请先选择需入帐的药品出库信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] drCommit = lstCheckRow.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有符合入帐条件的药品出库信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            clsDcl_OutStorage objODomain = new clsDcl_OutStorage();

            long lngRes = objODomain.m_lngInAccount(lstOutStorageID.ToArray(), lstSeq.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, dtmNow);

            if (lngRes > 0)
            {
                foreach (DataRow dr in drCommit)
                {
                    dr["INACCOUNTID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                    dr["STATUS"] = 3;
                    dr["INACCOUNTDATE_DAT"] = dtmNow;
                    dr["statusdesc"] = "入帐";
                }
                MessageBox.Show("入帐成功", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("入帐失败", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 设置窗体标题显示当前仓库名称
        /// <summary>
        /// 设置窗体标题显示当前仓库名称
        /// </summary>
        internal void m_mthGetStoreRoomName()
        {
            string strRoomName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strRoomName);
            m_objViewer.Text = "药品外退(" + strRoomName+")";
        }
        #endregion
    }
}
