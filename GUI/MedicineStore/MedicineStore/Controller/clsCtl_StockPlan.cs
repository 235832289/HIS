using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsCtl_StockPlan : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_StockPlan m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmStockPlan m_objViewer;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商
        /// </summary>
        private DataTable m_dtbVendor = null;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_StockPlan()
        {
            m_objDomain = new clsDcl_StockPlan();
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
            m_objViewer = (frmStockPlan)frmMDI_Child_Base_in;
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

        #region 获取仓库名
        /// <summary>
        /// 获取仓库名
        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <returns></returns>
        internal string m_strStoreRoomName(string p_strStoreRoomID)
        {
            string strStoreRoomName = string.Empty;
            long lngRes = m_objDomain.m_lngGetStoreRoomName(p_strStoreRoomID, out strStoreRoomName);
            return strStoreRoomName;
        }
        #endregion

        #region 修改选定的入库单
        /// <summary>
        /// 修改选定的入库单
        /// </summary>
        /// <param name="p_objMain">主表</param>
        /// <param name="p_objSubVO">子表</param>
        internal void m_mthModifySelected(out clsMS_StockPlan_VO p_objMain, out clsMS_StockPlan_Detail_VO[] p_objSubVO)
        {
            p_objMain = null;
            p_objSubVO = null;
            #region 主表VO
            clsMS_StockPlan_VO objMain = null;
            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 1)
            {
                DataRowView drvMain = m_objViewer.m_dtvMainView[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index];
                //int intState = Convert.ToInt32(drvMain["STATE_INT"]);
                //if (intState != 1)
                //{
                //    MessageBox.Show("非新制表单不能修改", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                objMain = new clsMS_StockPlan_VO();
                objMain.m_lngSERIESID_INT = Convert.ToInt64(drvMain["SERIESID_INT"]);
                objMain.m_strSTOCKPLANID_VCHR = drvMain["STOCKPLANID_VCHR"].ToString();
                //objMain.m_strSTORAGENAME_VCHR = drvMain["STORAGENAME_VCHR"].ToString();
                objMain.m_lngSTATE_INT = Convert.ToInt32(drvMain["STATE_INT"]);
                objMain.m_strVENDORID_CHR = drvMain["VENDORID_CHR"].ToString();
                objMain.m_strVENDORNAME_VCHR = drvMain["vendorname_vchr"].ToString();
                objMain.m_strSTORAGEID_CHR = drvMain["STORAGEID_CHR"].ToString();
                objMain.m_datSTOCKPLAN_DAT = Convert.ToDateTime(drvMain["STOCKPLAN_DAT"]);
                objMain.m_datNEWORDER_DAT = Convert.ToDateTime(drvMain["NEWORDER_DAT"]);
                objMain.m_strCOMMENT_VCHR = drvMain["COMMENT_VCHR"].ToString();
                objMain.m_strMAKERID_CHR = drvMain["MAKERID_CHR"].ToString();
                objMain.m_strMAKERNAME_VCHR = drvMain["MAKERNAME"].ToString();
            }

            if (objMain == null)
            {
                return;
            }
            p_objMain = objMain;
            #endregion

            #region 子表VO
            clsMS_StockPlan_Detail_VO[] objSubVO = null;
            DataView dvSub = m_objViewer.m_dgvSubInfo.DataSource as DataView;
            if (dvSub != null && dvSub.Count > 0)
            {
                DataRowView drvCurrent = null;
                objSubVO = new clsMS_StockPlan_Detail_VO[dvSub.Count];
                DateTime dtTemp;
                for (int iRow = 0; iRow < m_objViewer.m_dgvSubInfo.Rows.Count; iRow++)
                {
                    drvCurrent = dvSub[iRow];
                    objSubVO[iRow] = new clsMS_StockPlan_Detail_VO();
                    objSubVO[iRow].m_lngSERIESID_INT = Convert.ToInt64(drvCurrent["SERIESID_INT"]);
                    objSubVO[iRow].m_lngSERIESID2_INT = Convert.ToInt64(drvCurrent["SERIESID2_INT"]);
                    objSubVO[iRow].m_strMEDICINEID_CHR = drvCurrent["MEDICINEID_CHR"].ToString();
                    objSubVO[iRow].m_strMEDICINENAME_VCHR = drvCurrent["MEDICINENAME_VCHR"].ToString();
                    objSubVO[iRow].m_strMEDSPEC_VCHR = drvCurrent["MEDSPEC_VCHR"].ToString();
                    objSubVO[iRow].m_dblAMOUNT = Convert.ToInt32(drvCurrent["AMOUNT"]);
                    objSubVO[iRow].m_strPRODUCTORID_CHR = drvCurrent["PRODUCTORID_CHR"].ToString();
                    objSubVO[iRow].m_strUNIT_VCHR = drvCurrent["UNIT_VCHR"].ToString();
                    objSubVO[iRow].m_strASSISTCODE_CHR = drvCurrent["ASSISTCODE_CHR"].ToString();
                    objSubVO[iRow].m_lngSTATUS = Convert.ToInt16(drvCurrent["STATUS"]);
                    objSubVO[iRow].m_dblCALLPRICE_INT = Convert.ToDouble(drvCurrent["CALLPRICE_INT"]);
                    objSubVO[iRow].m_dblSTOCKSUM = Convert.ToDouble(drvCurrent["STOCKSUM"]);
                    if (DateTime.TryParse(drvCurrent["LASTINSTORAGEDATE_DAT"].ToString(), out dtTemp))
                        objSubVO[iRow].m_datLASTINSTORAGEDATE_DAT = dtTemp;
                    objSubVO[iRow].m_strVENDORID_CHR = drvCurrent["VENDORID_CHR"].ToString();
                    objSubVO[iRow].m_strVENDORNAME_VCHR = drvCurrent["vendorname"].ToString();

                }
            }
            p_objSubVO = objSubVO;
            #endregion
        }
        #endregion

        #region 删除药品信息
        /// <summary>
        /// 删除药品信息
        /// </summary>
        internal void m_mthDeleteMedicine()
        {
            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    int intState = Convert.ToInt32(m_objViewer.m_dtvMainView[iSe]["STATE_INT"]);
                    if (intState == 2 || intState == 0)//已审核或已删除
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvMainView[iSe]["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvMainView[iSe]["SERIESID_INT"]));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核或已删除，将不能删除，是否继续？", "采购计划", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条新制采购计划信息", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "采购计划", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            long lngRes = m_objDomain.m_lngDeleteMainStockPlan(lngCheckRowIndex.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_cmdSearch.PerformClick();
                //StringBuilder stbFilter = new StringBuilder(50);
                //for (int iSer = 0; iSer < lngCheckRowIndex.Count; iSer++)
                //{
                //    stbFilter.Append(" SERIESID_INT = '");
                //    stbFilter.Append(lngCheckRowIndex[iSer]);
                //    stbFilter.Append("'");
                //    if (iSer < lngCheckRowIndex.Count - 1)
                //    {
                //        stbFilter.Append(" or ");
                //    }
                //}
                //DataRow[] drRemove = m_objViewer.m_dtbMainData.Select(stbFilter.ToString());
                //if (drRemove != null && drRemove.Length > 0)
                //{
                //    for (int iRev = 0; iRev < drRemove.Length; iRev++)
                //    {
                //        m_objViewer.m_dtbMainData.Rows.Remove(drRemove[iRev]);
                //    }
                //}

                //DataView dtvSub = m_objViewer.m_dgvSubInfo.DataSource as DataView;
                //if (dtvSub != null)
                //{
                //    dtvSub.Table.Rows.Clear();
                //}
            }
            else
            {
                MessageBox.Show("删除失败", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        /// <param name="p_drCommit">审核的行</param>
        internal void m_mthCommitMedicine(out DataRow[] p_drCommit)
        {
            p_drCommit = null;
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    if (drCheck["STATE_INT"].ToString() == "1")
                    {
                        lstCheck.Add(drCheck);
                    }
                }
            }

            DataRow[] drNew = lstCheck.ToArray();

            if (drNew == null || drNew.Length == 0)
            {
                MessageBox.Show("没有需审核的采购计划信息", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                long lngRes = 0;
                long lngSEQ = 0;
                clsDcl_StockPlan objSTDomain = new clsDcl_StockPlan();

                bool blnSaveComplete = true;
                DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                for (int iRow = 0; iRow < drNew.Length; iRow++)
                {
                    lngSEQ = Convert.ToInt64(drNew[iRow]["SERIESID_INT"]);
                    lngRes = m_objDomain.m_lngCommitStockPlan(lngSEQ, m_objViewer.LoginInfo.m_strEmpID, dtmNow);

                    if (lngRes <= 0)
                    {
                        blnSaveComplete = false;
                        break;
                    }
                }

                if (blnSaveComplete)
                {
                    p_drCommit = drNew;
                    System.Windows.Forms.MessageBox.Show("审核完成", "采购计划", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("审核失败", "采购计划", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                System.Windows.Forms.MessageBox.Show("审核失败", "采购计划", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        ///// <summary>
        ///// 设置审核人
        ///// </summary>
        ///// <param name="p_drCommit">数据</param>
        //private void m_mthSetCommitUser(DataRow[] p_drCommit)
        //{
        //    if (p_drCommit == null || p_drCommit.Length == 0)
        //    {
        //        return;
        //    }

        //    long[] lngSEQ = new long[p_drCommit.Length];
        //    for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
        //    {
        //        lngSEQ[iRow] = Convert.ToInt64(p_drCommit[iRow]["SERIESID_INT"]);
        //    }

        //    long lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSEQ);
        //}

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_drNew">数据</param>
        internal void m_mthUpdateUIAfterCommit(DataRow[] p_drNew)
        {
            if (p_drNew == null || p_drNew.Length == 0)
            {
                return;
            }

            for (int iRow = 0; iRow < p_drNew.Length; iRow++)
            {
                DataRow[] drTemp = m_objViewer.m_dtbMainData.Select("SERIESID_INT = " + Convert.ToInt64(p_drNew[iRow]["SERIESID_INT"]));
                if (drTemp.Length > 0)
                {
                    drTemp[0]["EXAMERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                    drTemp[0]["examername"] = m_objViewer.LoginInfo.m_strEmpName;
                    drTemp[0]["STATE_INT"] = 2;
                    drTemp[0]["EXAM_DAT"] = DateTime.Now;
                    drTemp[0]["statedesc"] = "审核";
                }
            }

            if (m_objViewer.m_dtvMainView.Count == 0)
            {
                m_objViewer.m_dtbSubData.Rows.Clear();
            }
        }
        #endregion

        #region 退审

        /// <summary>
        /// 退审
        /// </summary>
        internal void m_mthUnCommit()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能退审", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    if (drCheck["STATE_INT"].ToString() == "2")
                    {
                        lstCheck.Add(drCheck);
                    }
                }
            }

            DataRow[] drCommit = lstCheck.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有符合退审条件的采购计划信息", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<long> lstSEQ = new List<long>();//未做其它操作的入库序列号
            List<string> lstRigthInStorageID = new List<string>();//未做其它操作的入库单号
            List<DataRow> lstCommitRow = new List<DataRow>();//符合退审条件的行

            Hashtable hstWrongID = new Hashtable();

            for (int iRow = 0; iRow < drCommit.Length; iRow++)
            {
                lstSEQ.Add(Convert.ToInt64(drCommit[iRow]["SERIESID_INT"]));
                lstRigthInStorageID.Add(drCommit[iRow]["stockplanid_vchr"].ToString());
                lstCommitRow.Add(drCommit[iRow]);
            }

            if (lstRigthInStorageID.Count == 0)
            {
                MessageBox.Show("没有符合退审条件的采购计划信息", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            long[] lngSEQArr = lstSEQ.ToArray();
            string[] strInStorageIDArr = lstRigthInStorageID.ToArray();

            long lngRes = 0;

            lngRes = m_objDomain.m_lngUnCommit(lngSEQArr);
            if (lngRes > 0)
            {
                m_mthUpdateUIAfterUnCommit(lstCommitRow.ToArray());
                if (m_objViewer.m_dgvMainInfo.Rows.Count > 0)
                {
                    m_objViewer.m_dgvMainInfo.Rows[0].Selected = true;
                }
                else
                {
                    if (m_objViewer.m_dtbSubData != null)
                    {
                        m_objViewer.m_dtbSubData.Rows.Clear();
                    }
                }
                System.Windows.Forms.MessageBox.Show("退审完成", "采购计划", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("退审失败", "采购计划", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 退审后更新界面
        /// </summary>
        /// <param name="drData">序列</param>
        private void m_mthUpdateUIAfterUnCommit(DataRow[] drData)
        {
            if (drData == null || drData.Length == 0)
            {
                return;
            }

            for (int iRow = 0; iRow < drData.Length; iRow++)
            {
                drData[iRow]["examername"] = DBNull.Value;
                drData[iRow]["STATE_INT"] = 1;
                drData[iRow]["EXAM_DAT"] = DBNull.Value;
                drData[iRow]["statedesc"] = "新制";
            }
        }
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strStockPlanID">单据号</param>
        /// <param name="p_strMedicinePreptype">药品剂型</param>
        /// <param name="p_dtbValue">主表内容</param>
        internal void m_mthGetMainData(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName, string p_strStockPlanID, string p_strMedicinePreptype, out DataTable p_dtbValue)
        {
            long lngRes = m_objDomain.m_lngGetStockPlan(p_dtmBeginDate, p_dtmEndDate, p_strStorageID, p_strMedicineName, p_strVendorName, p_strStockPlanID, p_strMedicinePreptype, out p_dtbValue);


            if (p_dtbValue != null)
            {
                string strUnCommit = "STATE_INT = 1 and EXAMERID_CHR is not null";
                DataRow[] drUnCommit = p_dtbValue.Select(strUnCommit);
                if (drUnCommit != null && drUnCommit.Length > 0)
                {
                    for (int iRow = 0; iRow < drUnCommit.Length; iRow++)
                    {
                        drUnCommit[iRow]["EXAMERID_CHR"] = DBNull.Value;
                        drUnCommit[iRow]["examername"] = DBNull.Value;
                        drUnCommit[iRow]["EXAM_DAT"] = DBNull.Value;
                    }
                }
            }
        }
        #endregion


        #region 获取指定仓库的药品类型
        /// <summary>
        /// 获取指定仓库的药品类型
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMTVO">药品制剂类型</param>
        internal void m_mthGetStorageMedicineType(string p_strStorageID, out clsMS_MedicineType_VO[] p_objMTVO)
        {
            long lngRes = m_objDomain.m_lngGetStorageMedicineType(p_strStorageID, out p_objMTVO);
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


        #region 过滤
        /// <summary>
        /// 过滤主表信息
        /// </summary>
        internal void m_mthFilterMainData()
        {
            if (m_objViewer.m_dtbSubData != null)
            {
                m_objViewer.m_dtbSubData.Rows.Clear();
            }

            string strFilterMain = m_strMainFilter();

            m_objViewer.m_dtvMainView = new DataView(m_objViewer.m_dtbMainData);
            m_objViewer.m_dtvMainView.RowFilter = strFilterMain;
            m_objViewer.m_dgvMainInfo.DataSource = m_objViewer.m_dtvMainView;

            m_objViewer.m_dgvMainInfo.Refresh();

            if (m_objViewer.m_dgvMainInfo.Rows.Count > 0)
            {

                //m_objViewer.m_dgvMainInfo.Focus();
                if (m_objViewer.m_dgvMainInfo.CurrentCell == null)
                {
                    m_objViewer.m_dgvMainInfo.Rows[0].Selected = true;
                    m_objViewer.m_dgvMainInfo.CurrentCell = m_objViewer.m_dgvMainInfo.Rows[0].Cells[1];
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

        #region 过滤药品信息
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
                if (m_objViewer.m_cboBillState.SelectedIndex != 3)
                    strFilterMain += " STATE_INT = " + (m_objViewer.m_cboBillState.SelectedIndex).ToString();
                else
                    strFilterMain += " STATE_INT = 0 ";
            }
            return strFilterMain;
        }

        /// <summary>
        /// 过滤子表信息
        /// </summary>
        internal void m_mthFilterSubData()
        {
            string strFilterSub = string.Empty;
            if (!string.IsNullOrEmpty(m_objViewer.m_txtMedicineName.Text))
            {
                strFilterSub = "MEDICINENAME_VCHR like '" + m_objViewer.m_txtMedicineName.Text + "%'";
            }

            if (m_objViewer.m_cboDoseType.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterSub))
                {
                    strFilterSub += " and ";
                }
                clsMEDICINEPREPTYPE_VO objVo = m_objViewer.m_cboDoseType.SelectedItem as clsMEDICINEPREPTYPE_VO;
                if (objVo != null)
                {
                    strFilterSub += " MEDICINEPREPTYPE_CHR = '" + objVo.m_strMEDICINEPREPTYPE_CHR + "'";
                }
            }

            if (m_objViewer.m_dtbSubData != null)
            {
                DataView dtvSub = new DataView(m_objViewer.m_dtbSubData);
                dtvSub.RowFilter = strFilterSub;
                m_objViewer.m_dgvSubInfo.DataSource = dtvSub;
            }

            m_objViewer.m_dgvSubInfo.Refresh();
        }
        #endregion

        #region 设置药品类型
        /// <summary>
        /// 设置药品类型
        /// </summary>
        /// <param name="p_objMPVO"></param>
        internal void m_mthSetMedicineType(clsMS_MedicineType_VO[] p_objMPVO)
        {
            if (p_objMPVO == null || m_objViewer.m_cboDoseType.Items.Count > 0)
            {
                return;
            }

            clsMS_MedicineType_VO objAll = new clsMS_MedicineType_VO();
            objAll.m_strMedicineTypeID_CHR = "0";
            objAll.m_strMedicineTypeName_VCHR = "全部";

            m_objViewer.m_cboDoseType.Items.Add(objAll);
            m_objViewer.m_cboDoseType.Items.AddRange(p_objMPVO);

            m_objViewer.m_cboDoseType.SelectedIndex = 0;
        }
        #endregion

        #region 获取明细表内容
        /// <summary>
        /// 获取明细表内容
        /// </summary>
        /// <param name="p_lngSeries2ID">明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal void m_mthGetStockPlanDetail(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = m_objDomain.m_mthGetStockPlanDetail(p_lngSeries2ID, out p_dtbValue);
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

                int X = m_objViewer.panel1.Location.X + m_objViewer.m_txtMedicineName.Location.X;
                int Y = m_objViewer.panel1.Location.Y + m_objViewer.m_txtMedicineName.Location.Y + m_objViewer.m_txtMedicineName.Size.Height;

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
    }
}
