using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品出库
    /// </summary>
    public class clsCtl_OutStorage : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_OutStorage m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmOutStorage m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null; 
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品出库
        /// </summary>
        public clsCtl_OutStorage()
        {
            m_objDomain = new clsDcl_OutStorage();
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
            m_objViewer = (frmOutStorage)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取主表内容（多类型）
        /// <summary>
        /// 获取主表内容（多类型）
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        internal void m_mthGetMainData(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, int p_intOutStorageType,out DataTable p_dtbOutStorage)
        {
            long lngRes = m_objDomain.m_lngGetOutStorageMain(p_strStorageID, p_dtmBegin, p_dtmEnd, p_strAskDeptName, p_strMedicine, p_strOutID, p_intOutStorageType,1, out p_dtbOutStorage);


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

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strAskDeptName">领药单位名</param>
        /// <param name="p_strMedicine">药品代码或名称</param>
        /// <param name="p_strOutID">单据号</param>
        /// <param name="p_dtbOutStorage">出库主表内容</param>
        internal void m_mthGetMainData(string p_strStorageID, DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strAskDeptName, string p_strMedicine,
            string p_strOutID, out DataTable p_dtbOutStorage)
        {
            long lngRes = m_objDomain.m_lngGetOutStorageMain(p_strStorageID, p_dtmBegin, p_dtmEnd, p_strAskDeptName, p_strMedicine, p_strOutID, 1, out p_dtbOutStorage);


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

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID,out m_objViewer.m_dtbMedicinDict);
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
                X = m_objViewer.m_txtMedicineNamePage1.Location.X + m_objViewer.panel4.Location.X;
                Y = m_objViewer.m_txtMedicineNamePage1.Location.Y + m_objViewer.m_txtMedicineNamePage1.Size.Height + m_objViewer.panel4.Location.Y;

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

            m_objViewer.m_txtMedicineNamePage1.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineNamePage1.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_txtAskIDPage1.Focus();
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

        #region 过滤主表信息
        /// <summary>
        /// 获取主表过滤条件
        /// </summary>
        /// <returns></returns>
        private string m_strGetMainFilter()
        {
            string strFilterMain = string.Empty;

            if (m_objViewer.m_cboOutStorageTypePage1.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterMain))
                {
                    strFilterMain += " and ";
                }
                strFilterMain += " OUTSTORAGETYPE_INT = " + m_objViewer.m_cboOutStorageTypePage1.SelectItemValue.ToString();
            }

            if (m_objViewer.m_cboStatusPage1.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterMain))
                {
                    strFilterMain += " and ";
                }
                strFilterMain += " STATUS = " + (m_objViewer.m_cboStatusPage1.SelectedIndex).ToString();
            }
            return strFilterMain;
        }

        /// <summary>
        /// 过滤主表信息
        /// </summary>
        internal void m_mthFilterMainDataPage1()
        {
            if (m_objViewer.m_dtbSubDataPage1 != null)
            {
                m_objViewer.m_dtbSubDataPage1.Rows.Clear();
            }

            string strFilterMain = m_strGetMainFilter();            

            m_objViewer.m_dtvCurrentMainVienPage1 = new DataView(m_objViewer.m_dtbMainDataPage1);
            m_objViewer.m_dtvCurrentMainVienPage1.RowFilter = strFilterMain;
            m_objViewer.m_dgvMainPage1.DataSource = m_objViewer.m_dtvCurrentMainVienPage1;

            m_objViewer.m_dgvMainPage1.Refresh();

            m_mthGetAllMoney();
            if (m_objViewer.m_dgvMainPage1.Rows.Count > 0)
            {
                if (m_objViewer.m_dgvMainPage1.CurrentCell == null)
                {
                    m_objViewer.m_dgvMainPage1.Rows[0].Selected = true;
                    m_objViewer.m_dgvMainPage1.CurrentCell = m_objViewer.m_dgvMainPage1.Rows[0].Cells[1];
                    m_objViewer.m_dgvMainPage1.CurrentCell.Selected = true;
                }
                else
                {
                    int intCurrentRow = m_objViewer.m_dgvMainPage1.CurrentCell.RowIndex;
                    m_objViewer.m_dgvMainPage1.Rows[intCurrentRow].Selected = true;
                    m_objViewer.m_dgvMainPage1.CurrentCell.Selected = true;
                }
            }
            else
            {
                if (m_objViewer.m_dtbSubDataPage1 != null)
                {
                    m_objViewer.m_dtbSubDataPage1.Rows.Clear();

                    m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
                    m_objViewer.m_lblWholeSaleSubMoney.Text = string.Empty;
                    m_objViewer.m_lblRetailSubMoney.Text = string.Empty;
                    m_objViewer.m_lblly.Text = string.Empty;
                }
            }
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
            long lngRes = m_objDomain.m_lngGetOutStorageDetail(p_lngMainSEQ, out p_dtbValue);
        } 
        #endregion

        #region 修改出库
        /// <summary>
        /// 修改出库
        /// </summary>
        internal void m_mthModifyPage1(out clsMS_OutStorage_VO p_objMain, out clsMS_OutStorageDetail_VO[] p_objDetail)
        {
            p_objMain = null;
            p_objDetail = null;

            #region 主表
            clsMS_OutStorage_VO objMain = null;
            if (m_objViewer.m_dgvMainPage1.SelectedRows.Count == 1)
            {
                DataRowView drvMain = m_objViewer.m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainPage1.SelectedRows[0].Index];
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
                objMain.m_strRECEIPTORID_CHR = drvMain["RECEIPTORID_CHR"].ToString();
                objMain.m_strRECEIPTORName = drvMain["receiptorname"].ToString();
            }

            if (objMain == null)
            {
                return;
            }
            p_objMain = objMain;
            #endregion

            #region 子表
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            DataView dvSub = m_objViewer.m_dgvSubPage1.DataSource as DataView;
            if (dvSub != null && dvSub.Count > 0)
            {
                DataRowView drvTemp = null;
                DateTime datTemp;
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

                    if (drvTemp["oldgross_int"] != DBNull.Value)
                    {
                        objDetailArr[iRow].m_dblOldGross = Convert.ToDouble(drvTemp["oldgross_int"]);
                    }
                    objDetailArr[iRow].m_strTYPECODE_CHR = drvTemp["typecode_vchr"].ToString();
                    if (DateTime.TryParse(drvTemp["producedate_dat"].ToString(), out datTemp))
                    {
                        objDetailArr[iRow].m_dtmPRODUCEDATE_DAT = datTemp;
                    }

                }
            }
            p_objDetail = objDetailArr;
            #endregion
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
            int m_intStatus = 0;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainPage1.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainPage1.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainPage1.Rows[iSe].DataBoundItem).Row;
                    //检查是否新制

                    m_objDomain.m_lngCheckStatus(Convert.ToInt64(drCheck["SERIESID_INT"]), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvCurrentMainVienPage1[iSe]["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvCurrentMainVienPage1[iSe]["SERIESID_INT"]));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核或已入账，将不能删除，是否继续？", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条新制药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            clsMS_StorageGrossForOut[] objGetOutValue = m_objGetOutValue(lngCheckRowIndex.ToArray());

            long lngRes = m_objDomain.m_lngDeleteMainOutStorage(lngCheckRowIndex.ToArray());
            if (lngRes > 0)
            {
                m_mthAddAvailaGross(objGetOutValue);
                MessageBox.Show("删除成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                DataRow[] drRemove = m_objViewer.m_dtbMainDataPage1.Select(stbFilter.ToString());
                if (drRemove != null && drRemove.Length > 0)
                {
                    for (int iRev = 0; iRev < drRemove.Length; iRev++)
                    {
                        m_objViewer.m_dtbMainDataPage1.Rows.Remove(drRemove[iRev]);
                    }
                }

                DataView dtvSub = m_objViewer.m_dgvSubPage1.DataSource as DataView;
                if (m_objViewer.m_dtvCurrentMainVienPage1.Count == 0 && dtvSub != null)
                {
                    dtvSub.Table.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            clsMS_StorageGrossForOut[] objSubArr = null;
            List<clsMS_StorageGrossForOut> lisDetail = new List<clsMS_StorageGrossForOut>();
            long lngRes = 0;
            DataTable dtbDetail = null;
            for (int iSEQ = 0; iSEQ < p_lngMainSeq.Length; iSEQ++)
            {
                lngRes = m_objDomain.m_lngGetOutStorageDetail(p_lngMainSeq[iSEQ], out dtbDetail);
                objSubArr = m_objGetDetail(dtbDetail);
                if (objSubArr != null && objSubArr.Length > 0)
                {
                    lisDetail.AddRange(objSubArr);
                }
            }

            if (lisDetail.Count > 0)
            {
                objSubArr = lisDetail.ToArray();
            }
            return objSubArr;
        }

        /// <summary>
        /// 删除未审核记录后库存表增加可用库存        /// </summary>
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

                m_objDomain.m_lngGetMedicineTypeVisionm(drvTemp["medicinetypeid_chr"].ToString(), out m_objViewer.m_clsTypeVisVO);
                if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && drvTemp["LOTNO_VCHR"].ToString() == "")
                {
                    objDetailArr[iRow].m_strLotNO = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLotNO = drvTemp["LOTNO_VCHR"].ToString();
                }
                objDetailArr[iRow].m_dblGross = Convert.ToDouble(drvTemp["NETAMOUNT_INT"]);
                objDetailArr[iRow].m_dblInPrice = Convert.ToDouble(drvTemp["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dtmValidDate = Convert.ToDateTime(drvTemp["VALIDPERIOD_DAT"]);
            }
            return objDetailArr;
        } 
        #endregion

        #region 检查是否有药库管理权限
        /// <summary>
        /// 检查是否有药库管理权限s
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有权限</param>
        internal void m_mthCheckHasAdminRole(string strEmpID, out bool p_blnHasRole)
        {
            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            long lngRes = objPDomain.m_lngCheckEmpHasRole(strEmpID, out p_blnHasRole);
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

        #region 审核出库
        /// <summary>
        /// 审核出库
        /// </summary>
        internal void m_mthCommitOutStorage()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            int m_intBillNo = 0;
            int m_intStatus = 0;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainPage1.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainPage1.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = m_objViewer.m_dtvCurrentMainVienPage1[iSe].Row;
                    
                    m_intBillNo++;
                    //检查是否新制

                    m_objDomain.m_lngCheckStatus(Convert.ToInt64(drCheck["SERIESID_INT"]), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        MessageBox.Show("您所选择的第" + (m_intBillNo) + "张出库单不是新制状态,不能进行审核！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    lstCheck.Add(drCheck);
                    
                }
            }

            if (lstCheck.Count == 0)
            {
                MessageBox.Show("请先选择需审核的药品出库信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] drNew = lstCheck.ToArray();

            if (drNew == null || drNew.Length == 0)
            {
                MessageBox.Show("没有需审核的药品出库信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string strCurrentOutStorageID = string.Empty;
            try
            {
                long[] lngMainSEQ = new long[drNew.Length];
                for (int iMSeq = 0; iMSeq < drNew.Length; iMSeq++)
                {
                    lngMainSEQ[iMSeq] = Convert.ToInt64(drNew[iMSeq]["SERIESID_INT"]);
                }

                clsMS_OutStorage_VO objMainTable = null;
                clsMS_OutStorageDetail_VO[] objSubTable = null;

                clsMS_StorageGrossForOut[] objSubArr = null;
                //List<clsMS_StorageGrossForOut> lisDetail = new List<clsMS_StorageGrossForOut>();
                clsMS_AccountDetail_VO[] objAccount = null;
                long lngRes = 0;
                DataTable dtbMain = null;
                DataTable dtbSub = null;
                DataTable dtbDetail = null;
                for (int iSEQ = 0; iSEQ < lngMainSEQ.Length; iSEQ++)
                {
                    strCurrentOutStorageID = drNew[iSEQ]["OUTSTORAGEID_VCHR"].ToString();
                    m_objDomain.m_mthGetOutStorage(lngMainSEQ[iSEQ], out dtbMain);
                    lngRes = m_objDomain.m_lngGetOutStorageDetail(lngMainSEQ[iSEQ], out dtbDetail);
                    dtbSub = dtbDetail.Copy();
                    objSubArr = m_objGetDetail(dtbDetail);
                    if (objSubArr != null && objSubArr.Length > 0)
                    {
                        objAccount = m_objAccountDetailArr(dtbDetail, Convert.ToInt32(drNew[iSEQ]["FORMTYPE"]), strCurrentOutStorageID, drNew[iSEQ]["ASKDEPT_CHR"].ToString());
                        lngRes = m_objDomain.m_lngCommitOutStorage(objSubArr,objAccount, m_objViewer.LoginInfo.m_strEmpID, lngMainSEQ[iSEQ], m_objViewer.m_blnIsImmAccount);

                        if (lngRes > 0)
                        {
                            m_mthUpdateUIAfterCommit(drNew[iSEQ]);
                        }

                        if (m_objDomain.m_mthHaveAddedIntoDrugStore(lngMainSEQ[iSEQ]) == false)
                        {
                            objMainTable = m_objGetMain(dtbMain);
                            objSubTable = m_objGetSub(dtbSub);
                            if (objMainTable != null && objSubTable != null && objSubTable.Length > 0)
                            {
                                m_objDomain.m_mthAddNewDrugStore(objMainTable, objSubTable);
                            }                            
                        }
                        
                        //lisDetail.AddRange(objSubArr);
                    }
                }


                if (lngRes > 0)
                {
                    MessageBox.Show("审核完成", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("审核失败", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                //if (lisDetail.Count > 0)
                //{
                //    clsDcl_Storage objSTDomain = new clsDcl_Storage();
                //    lngRes = objSTDomain.m_lngSubStorageDetailRealGross(lisDetail.ToArray());

                //    for (int iList = 0; iList < lisDetail.Count; iList++)
                //    {
                //        lngRes = objSTDomain.m_lngSubStorageGross(lisDetail[iList]);
                //    }

                //    if (lngRes > 0)
                //    {
                //        lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngMainSEQ);
                //    }

                //    if (lngRes > 0)
                //    {
                //        p_drCommit = drNew;
                //    }
                //}
            }
            catch (Exception objEx)
            {
                string strEx = objEx.Message;

                if (strEx == "出库数量超过实际库存量")
                {
                    MessageBox.Show("审核操作中止！" + Environment.NewLine 
                        + "出库单据号为" + strCurrentOutStorageID + "的出库单存在出库数量超过实际库存量的药品", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("审核失败", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }

                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }  
        }

        /// <summary>
        /// 转换子表
        /// </summary>
        /// <param name="dtbSub"></param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO[] m_objGetSub(DataTable dtbSub)
        {
            if (dtbSub == null)
            {
                return null;
            }
            int iCount = dtbSub.Rows.Count;
            DateTime datTemp;
            clsMS_OutStorageDetail_VO[] objSub = new clsMS_OutStorageDetail_VO[iCount];
            for (int i1 = 0; i1 < iCount; i1++)
            {
                objSub[i1] = new clsMS_OutStorageDetail_VO();
                objSub[i1].m_strMEDICINEID_CHR = dtbSub.Rows[i1]["medicineid_chr"].ToString();
                objSub[i1].m_strMEDICINENAME_VCH = dtbSub.Rows[i1]["medicinename_vch"].ToString();
                objSub[i1].m_strMEDSPEC_VCHR = dtbSub.Rows[i1]["medspec_vchr"].ToString();
                objSub[i1].m_dblNETAMOUNT_INT = Convert.ToDouble(dtbSub.Rows[i1]["netamount_int"]);
                objSub[i1].m_strOPUNIT_CHR = dtbSub.Rows[i1]["opunit_chr"].ToString();
                objSub[i1].m_decPackQty = Convert.ToDecimal(dtbSub.Rows[i1]["packqty_dec"]);
                objSub[i1].m_strIPUnit = dtbSub.Rows[i1]["ipunit_chr"].ToString();                
                objSub[i1].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(dtbSub.Rows[i1]["wholesaleprice_int"]);
                objSub[i1].m_dcmRETAILPRICE_INT = Convert.ToDecimal(dtbSub.Rows[i1]["retailprice_int"]);
                objSub[i1].m_strLOTNO_VCHR = dtbSub.Rows[i1]["lotno_vchr"].ToString();
                objSub[i1].m_dtmValidperiod_dat = Convert.ToDateTime(dtbSub.Rows[i1]["validperiod_dat"]);
                objSub[i1].m_strINSTORAGEID_VCHR = dtbSub.Rows[i1]["instorageid_vchr"].ToString();
                objSub[i1].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(dtbSub.Rows[i1]["instoragedate_dat"]);
                if (DateTime.TryParse(dtbSub.Rows[i1]["producedate_dat"].ToString(), out datTemp))
                {
                    objSub[i1].m_dtmPRODUCEDATE_DAT = datTemp;
                }
            }
            return objSub;
        }

        /// <summary>
        /// 转换主表
        /// </summary>
        /// <param name="dtbMain"></param>
        /// <returns></returns>
        private clsMS_OutStorage_VO m_objGetMain(DataTable dtbMain)
        {
            if (dtbMain == null)
            {
                return null;
            }
            clsMS_OutStorage_VO objMain = new clsMS_OutStorage_VO();
            
            objMain.m_dtmASKDATE_DAT = Convert.ToDateTime(dtbMain.Rows[0]["askdate_dat"]);
            objMain.m_dtmEXAMDATE_DAT = DateTime.Now;
            objMain.m_strEXPORTDEPT_CHR = dtbMain.Rows[0]["exportdept_chr"].ToString();
            objMain.m_strASKDEPT_CHR = dtbMain.Rows[0]["askdept_chr"].ToString();
            objMain.m_strASKERID_CHR = dtbMain.Rows[0]["askerid_chr"].ToString();
            objMain.m_strOUTSTORAGEID_VCHR = dtbMain.Rows[0]["outstorageid_vchr"].ToString();
            objMain.m_strEXAMERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            objMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                //dtbMain.Rows[i1]["examerid_chr"].ToString(); 
            
            return objMain;
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_drNew">数据</param>
        internal void m_mthUpdateUIAfterCommit(DataRow p_drNew)
        {
            if (p_drNew == null )
            {
                return;
            }

            p_drNew["EXAMERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
            p_drNew["examername"] = m_objViewer.LoginInfo.m_strEmpName;
            p_drNew["STATUS"] = m_objViewer.m_blnIsImmAccount ? 3:2;
            p_drNew["EXAMDATE_DAT"] = DateTime.Now;
            p_drNew["statusdesc"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";

            if (m_objViewer.m_dtvCurrentMainVienPage1.Count == 0)
            {
                m_objViewer.m_dtbSubDataPage1.Rows.Clear();
                m_mthGetAllSubMoney();
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
        /// <param name="p_strDeptID">申请部门ID</param>
        /// <returns></returns>
        private clsMS_AccountDetail_VO[] m_objAccountDetailArr(DataTable p_dtbOutDetail, int p_intOutType, string p_strOutStorageID, string p_strDeptID)
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
            DateTime datTemp;

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
                objAccArr[iAcc].m_strDEPTID_CHR = p_strDeptID;
                objAccArr[iAcc].m_strINACCOUNTID_CHR = strInEmp;
                objAccArr[iAcc].m_strINSTORAGEID_VCHR = drTemp["INSTORAGEID_VCHR"].ToString();

                m_objDomain.m_lngGetMedicineTypeVisionm(drTemp["medicinetypeid_chr"].ToString(), out m_objViewer.m_clsTypeVisVO);
                if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && drTemp["LOTNO_VCHR"].ToString() == "")
                {
                    objAccArr[iAcc].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objAccArr[iAcc].m_strLOTNO_VCHR = drTemp["LOTNO_VCHR"].ToString();
                }
                

                objAccArr[iAcc].m_strMEDICINEID_CHR = drTemp["MEDICINEID_CHR"].ToString();
                objAccArr[iAcc].m_strMEDICINENAME_VCH = drTemp["MEDICINENAME_VCH"].ToString();
                objAccArr[iAcc].m_strMEDICINETYPEID_CHR = drTemp["medicinetypeid_chr"].ToString();
                objAccArr[iAcc].m_strMEDSPEC_VCHR = drTemp["MEDSPEC_VCHR"].ToString();
                objAccArr[iAcc].m_strOPUNIT_CHR = drTemp["OPUNIT_CHR"].ToString();
                objAccArr[iAcc].m_dtmValidDate = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
                objAccArr[iAcc].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objAccArr[iAcc].m_dtmOperateDate = dtmNow;
                objAccArr[iAcc].m_strTYPECODE_CHR = drTemp["typecode_vchr"].ToString();
                if (DateTime.TryParse(drTemp["producedate_dat"].ToString(), out datTemp))
                {
                    objAccArr[iAcc].m_dtmPRODUCEDATE_DAT = datTemp;
                }
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
                MessageBox.Show("当前用户没有药库管理权限，不能退审", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheckRow = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainPage1.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainPage1.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = m_objViewer.m_dtvCurrentMainVienPage1[iSe].Row;
                    if (drCheck["STATUS"].ToString() == "2")
                    {
                        //20090810:检查是否有开药房入库单，如果有则不允许退审。
                        if (m_objDomain.m_mthHaveAddedIntoDrugStore(Convert.ToInt64(drCheck["seriesid_int"])) == false)
                        {                        
                            lstCheckRow.Add(drCheck);
                        }
                    }
                }
            }

            if (lstCheckRow.Count == 0)
            {
                MessageBox.Show("请先选择需退审的药品出库信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DataRow[] drCommit = lstCheckRow.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有符合退审条件的药品出库信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            long[] lngMainSEQ = new long[drCommit.Length];
            for (int iRow = 0; iRow < drCommit.Length; iRow++)
            {
                lngMainSEQ[iRow] = Convert.ToInt64(drCommit[iRow]["SERIESID_INT"]);
            }

            long lngRes = 0;

            clsMS_StorageGrossForOut[] objSubArr = null;
            DataTable dtbDetail = null;
            for (int iSEQ = 0; iSEQ < lngMainSEQ.Length; iSEQ++)
            {
                lngRes = m_objDomain.m_lngGetOutStorageDetail(lngMainSEQ[iSEQ], out dtbDetail);
                objSubArr = m_objGetDetail(dtbDetail);
                if (objSubArr != null && objSubArr.Length > 0)
                {
                    lngRes = m_objDomain.m_lngUnCommitOutStorage(objSubArr, lngMainSEQ[iSEQ], drCommit[iSEQ]["OUTSTORAGEID_VCHR"].ToString(), m_objViewer.m_strStorageID);

                    if (lngRes > 0)
                    {
                        m_mthUpdateUIAfterUnCommit(drCommit[iSEQ]);
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("子表内容出错！退审失败", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }
            }

            if (lngRes > 0)
	        {
                if (m_objViewer.m_dgvMainPage1.Rows.Count > 0)
                {
                    m_objViewer.m_dgvMainPage1.Rows[0].Selected = true;
                }
                else
                {
                    if (m_objViewer.m_dtbSubDataPage1 != null)
                    {
                        m_objViewer.m_dtbSubDataPage1.Rows.Clear();
                    }
                }
                System.Windows.Forms.MessageBox.Show("退审完成", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("退审失败", "药品出库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }          
        }

        /// <summary>
        /// 退审后更新界面
        /// </summary>
        /// <param name="p_drNew">数据</param>
        private void m_mthUpdateUIAfterUnCommit(DataRow p_drNew)
        {
            if (p_drNew == null)
            {
                return;
            }

            p_drNew["examername"] = DBNull.Value;
            p_drNew["STATUS"] = 1;
            p_drNew["EXAMDATE_DAT"] = DBNull.Value;
            p_drNew["statusdesc"] = "新制";
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

            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpBeginDatePage1.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpEndDatePage1.Text).ToString("yyyy-MM-dd 23:59:59"));

            if (m_objViewer.m_dtbAllMoney == null)
            {
                long lngRes = m_objDomain.m_lngGetAllInMoney(dtmBegin, dtmEnd, m_objViewer.m_strStorageID,1, out m_objViewer.m_dtbAllMoney);
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtbAllMoney.Rows.Count == 0)
            {
                m_objViewer.m_dtbAllMoney = null;
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtvCurrentMainVienPage1 != null)
            {
                //StringBuilder stbFilter = new StringBuilder(100);
                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                int intRowsCount = m_objViewer.m_dtvCurrentMainVienPage1.Count;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    hstMedicine.Add(Convert.ToInt64(m_objViewer.m_dtvCurrentMainVienPage1[iRow]["seriesid_int"]), m_objViewer.m_dtvCurrentMainVienPage1[iRow]["outstorageid_vchr"].ToString());
                }

                string strFilterResult = m_strGetMainFilter();

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

            if (m_objViewer.m_dtbSubDataPage1 != null)
            {
                double dcmBuyIn = 0d;
                double dcmWholeSale = 0d;
                double dcmRetailSale = 0d;
                DataRow drTemp = null;
                for (int iM = 0; iM < m_objViewer.m_dtbSubDataPage1.Rows.Count; iM++)
                {
                    drTemp = m_objViewer.m_dtbSubDataPage1.Rows[iM];
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
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainPage1.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainPage1.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = m_objViewer.m_dtvCurrentMainVienPage1[iSe].Row;
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

            long lngRes = m_objDomain.m_lngInAccount(lstOutStorageID.ToArray(), lstSeq.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, dtmNow);

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

        internal void m_mthStorageName()
        {
            string strStorageName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
            m_objViewer.Text = "药品出库(" + strStorageName + ")";
        }


        /// <summary>
        /// 获取出入库类型
        /// </summary>
        /// <param name="m_strImportType"></param>
        /// <returns></returns>
        internal void m_mthGetImpExpTypeInfo(string m_strImportType)
        {
            DataTable m_dtImpExpTypeInfo = new DataTable();
            long lngRes = -1;
            lngRes = m_objDomain.m_mthGetImpExpTypeInfo(out m_dtImpExpTypeInfo);
            if (lngRes > 0)
            {
                if (m_dtImpExpTypeInfo.Rows.Count == 0)
                {
                    MessageBox.Show("药库出库类型数据为空，请先维护药库出库类型数据！");
                    return;
                }
                DataView dv = m_dtImpExpTypeInfo.DefaultView;

                if (m_strImportType != "*")
                {
                    string[] strImpTypeArr = m_strImportType.Split('*');

                    string m_strFilter = "flag_int=1 and typecode_vchr in ({Conditions}) ";
                    string m_strConditions = "";
                    for (int i = 0; i < strImpTypeArr.Length; i++)
                    {
                        if (strImpTypeArr.Length == 1)
                        {
                            m_strConditions = "'" + strImpTypeArr[0] + "'";
                            break;
                        }
                        m_strConditions += "'" + strImpTypeArr[i] + "'";
                        if (i != strImpTypeArr.Length - 1)
                        {
                            m_strConditions += ",";
                        }
                    }
                    m_strFilter = m_strFilter.Replace("{Conditions}", m_strConditions);
                    dv.RowFilter = m_strFilter;
                }
                else
                {
                    dv.RowFilter = "flag_int=1";
                }
                DataTable dtTemp = dv.ToTable();
                this.m_objViewer.m_tmsShowNewMake.Items.Clear();
                ToolStripMenuItem mi;
                ToolStripSeparator Separator;
                this.m_objViewer.m_cboOutStorageTypePage1.Items.Clear();
                this.m_objViewer.m_cboOutStorageTypePage1.Item.Add("全部", "0");
                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    mi = new ToolStripMenuItem(string.Format("新制({0})", dtTemp.Rows[j]["typename_vchr"].ToString()));
                    mi = new ToolStripMenuItem(dtTemp.Rows[j]["typename_vchr"].ToString());
                    mi.Tag = dtTemp.Rows[j]["typecode_vchr"].ToString();
                    mi.Click += new EventHandler(mi_Click);
                    this.m_objViewer.m_tmsShowNewMake.Items.Add(mi);
                    if (j != dtTemp.Rows.Count - 1)
                    {
                        Separator = new ToolStripSeparator();
                        this.m_objViewer.m_tmsShowNewMake.Items.Add(Separator);
                    }
                    this.m_objViewer.m_cboOutStorageTypePage1.Item.Add(dtTemp.Rows[j]["typename_vchr"].ToString(), dtTemp.Rows[j]["typecode_vchr"].ToString());
                }
                this.m_objViewer.m_cboOutStorageTypePage1.SelectedIndex = 0;
            }
        }

        private void mi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = sender as ToolStripMenuItem;
            frmMedicineOut frmMO = new frmMedicineOut(this.m_objViewer.m_strStorageID,  Convert.ToInt16(mi.Tag),1);
            
            //frmMO.FormClosed += new FormClosedEventHandler(this.m_objViewer.frmMedicineOut_FormClosed);
            
            frmMO.Text = mi.Text.Replace("新制", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty);
            frmMO.ShowDialog();
        }
    }
}
