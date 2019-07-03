using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsCtl_StorageCheck : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_StorageCheck m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmStorageCheck m_objViewer;
        internal DataView m_dtvCurrentMainVienPage1 = null;
        internal DataView m_dtvCurrentMainVienPage2 = null;
        /// <summary>
        /// 主表记录
        /// </summary>
        DataTable dtbStorageCheck = null;
        /// <summary>
        /// 明细表记录
        /// </summary>
        DataTable dtbStorageCheck_detail = null;
        /// <summary>
        /// 当前药品出库主表信息
        /// </summary>
        private clsMS_StorageCheck_VO m_objStorageCheck = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 盘点主表
        /// </summary>
        public clsCtl_StorageCheck()
        {
            m_objDomain = new clsDcl_StorageCheck();
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
            m_objViewer = (frmStorageCheck)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        internal void m_mthGetStorageCheck()
        {            
            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpBeginDatePage1.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpEndDatePage1.Text).ToString("yyyy-MM-dd 23:59:59"));
            
            m_objDomain.m_lngGetStorageCheck(dtmBegin, dtmEnd,m_objViewer.m_strStorageID, out dtbStorageCheck);

            m_mthSetDataToUI();

        }

        /// <summary>
        /// 设置数据至界面
        /// </summary>
        internal void m_mthSetDataToUI()
        { 
            if (dtbStorageCheck != null && dtbStorageCheck.Rows.Count > 0)
            {
                m_dtvCurrentMainVienPage1 = new DataView(dtbStorageCheck);

                if (string.IsNullOrEmpty(m_objViewer.m_txtChickID.Text))
                {
                    m_dtvCurrentMainVienPage1.RowFilter = "checkid_chr like '" + m_objViewer.m_txtChickID.Text + "%'";
                }

                if (m_objViewer.m_cboType.SelectedIndex > 0)
                {
                    m_dtvCurrentMainVienPage1.RowFilter = "status = " + m_objViewer.m_cboType.SelectedIndex.ToString();
                }

                m_objViewer.m_dgvMainInfo.DataSource = m_dtvCurrentMainVienPage1;
                m_objViewer.m_dgvMainInfo.Refresh();
            }            
        }
        #endregion

        #region 获取明细表内容
        /// <summary>
        /// 获取明细表内容
        /// </summary>
        internal void m_mthGetStorageCheck_detail()
        {
            if (m_objViewer.m_dgvMainInfo.CurrentCell == null)
            {
              // m_objViewer.m_dgvSubInfo.DataSource = null;
                return;
            }
            DataRowView drvSelected = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.CurrentCell.RowIndex];
            long lngSeriesId = Convert.ToInt64(drvSelected["SERIESID_INT"]);

            m_objDomain.m_lngGetStorageCheck_detail(lngSeriesId, out dtbStorageCheck_detail);

            m_dtvCurrentMainVienPage2 = new DataView(dtbStorageCheck_detail);

            m_mthSetCheckMoney();

            m_objViewer.m_dgvSubInfo.DataSource = m_dtvCurrentMainVienPage2;
            m_objViewer.m_dgvSubInfo.Refresh();
        }

        private void m_mthSetCheckMoney()
        {
            m_objViewer.m_lblBalanceMoney.Text = string.Empty;
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (dtbStorageCheck_detail == null || dtbStorageCheck_detail.Rows.Count == 0)
            {
                return;
            }

            int intRowsCount = dtbStorageCheck_detail.Rows.Count;
            double dblBalanceMoney = 0d;
            double dblBuyInMoney = 0d;
            double dblRetailMoney = 0d;
            DataRow drTemp = null;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = dtbStorageCheck_detail.Rows[iRow];
                dblBalanceMoney += Convert.ToDouble(drTemp["CHECKRESULT_INT"]) * Convert.ToDouble(drTemp["retailprice_int"]);
                dblBuyInMoney += Convert.ToDouble(drTemp["CHECKGROSS_INT"]) * Convert.ToDouble(drTemp["callprice_int"]);
                dblRetailMoney += Convert.ToDouble(drTemp["CHECKGROSS_INT"]) * Convert.ToDouble(drTemp["retailprice_int"]);
            }

            m_objViewer.m_lblBalanceMoney.Text = dblBalanceMoney.ToString("0.0000");
            m_objViewer.m_lblBuyInSubMoney.Text = dblBuyInMoney.ToString("0.0000");
            m_objViewer.m_lblRetailSubMoney.Text = dblRetailMoney.ToString("0.0000");
        }
        #endregion

        #region 显示明细窗体
        /// <summary>
        /// 显示明细窗体
        /// </summary>
        /// <param name="intShowType">窗体显示类型０：新制,１：修改</param>
        public void m_mthFrmStoDetail(int intShowType)
        {
            frmStorageCheck_detail frmStoDetail = new frmStorageCheck_detail(m_objViewer.m_strStorageID);
            if (intShowType == 1)
            {
                if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请先选择一行盘点信息","药品盘点",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                DataRowView drCurrent = m_objViewer.m_dgvMainInfo.SelectedRows[0].DataBoundItem as DataRowView;
                clsMS_StorageCheck_VO objMain = m_objMain(drCurrent.Row);
                frmStoDetail.m_objMain = objMain;
                frmStoDetail.dtbStorageCheck_detail = dtbStorageCheck_detail;
            }
            else
            {
                frmStoDetail.m_objMain = null;
                
                frmStoDetail.dtbStorageCheck_detail = new DataTable();
               
            }
            frmStoDetail.intShowType = intShowType;
            frmStoDetail.FormClosed += new FormClosedEventHandler(frmStoDetail_FormClosed);
            frmStoDetail.ShowDialog();
        }

        private void frmStoDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_mthGetStorageCheck();
        }

        #region 获取当前主记录
        /// <summary>
        /// 获取当前主记录
        /// </summary>
        /// <param name="p_drmain">数据</param>
        /// <returns></returns>
        private clsMS_StorageCheck_VO m_objMain(DataRow p_drmain)
        {
            if (p_drmain == null)
            {
                return null;
            }
            clsMS_StorageCheck_VO objMain = new clsMS_StorageCheck_VO();
            objMain.m_dtmAskDate_DAT = Convert.ToDateTime(p_drmain["askdate_dat"]);
            objMain.m_intStatus_INT = Convert.ToInt32(p_drmain["status"]);
            objMain.m_strStorageID_CHR = m_objViewer.m_strStorageID;
            objMain.m_strAskerID_CHR = p_drmain["askerid_chr"].ToString();
            objMain.m_strAskerName = p_drmain["askername"].ToString();
            objMain.m_lngSeriesID_INT = Convert.ToInt64(p_drmain["seriesid_int"]);
            objMain.m_dtmCheckDate = Convert.ToDateTime(p_drmain["checkdate_dat"]);
            objMain.m_strCheckID_CHR = p_drmain["checkid_chr"].ToString();
            return objMain;
        }
        #endregion
        #endregion

        #region 删除盘点记录
        /// <summary>
        /// 删除盘点记录
        /// </summary>
        internal void m_mthDeleteCheckStorage()
        {         
            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一条新制药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int intState = Convert.ToInt32(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index]["STATUS"]);
            if (intState != 1)
            {
                MessageBox.Show("只能删除新制药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "药品盘点", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            long lngSEQ = Convert.ToInt64(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index]["SERIESID_INT"]);

            long lngRes = m_objDomain.m_lngDeleteStorageCheck(lngSEQ);
            if (lngRes>0)
            {
                DataRow drDel = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index].Row;
                if (drDel != null)
                {
                    dtbStorageCheck.Rows.Remove(drDel);
                }

                if (m_dtvCurrentMainVienPage1.Count == 0 && dtbStorageCheck_detail != null)
                {
                    dtbStorageCheck_detail.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            objPDomain = null;
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

        #region 审核药品盘点
        /// <summary>
        /// 审核药品盘点
        /// </summary>
        internal void m_mthCommitStorageCheck()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择需审核的药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int intState = Convert.ToInt32(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index]["STATUS"]);
            if (intState != 1)
            {
                MessageBox.Show("只能审核新制药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m_dtvCurrentMainVienPage2.Count == 0)
            {
                return;
            }

            long lngRes = 0;

            DataRowView drvCurrentMain = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index];
            string strCheckID = drvCurrentMain["checkid_chr"].ToString();
            DateTime dtmCheckDate = Convert.ToDateTime(drvCurrentMain["askdate_dat"]);
            string strCreator = drvCurrentMain["askerid_chr"].ToString();
            long lngMainSEQ = Convert.ToInt64(drvCurrentMain["seriesid_int"]);

            List<clsMS_StorageDetail> lstStDetail = new List<clsMS_StorageDetail>();
            //clsDcl_StorageCheck_detail objSCDDomain = new clsDcl_StorageCheck_detail();
            List<clsMS_StorageCheckDetail_VO> lstDef = new List<clsMS_StorageCheckDetail_VO>();//盘亏
            List<clsMS_StorageCheckDetail_VO> lstSuf = new List<clsMS_StorageCheckDetail_VO>();//盘盈

            //盘亏
            DataRow[] drDef = dtbStorageCheck_detail.Select("CHECKRESULT_INT < 0");
            if (drDef != null && drDef.Length > 0)
            {
                lstDef.AddRange(m_objCheckDetail(drDef));
                lstStDetail.AddRange(m_objStorageDetailArr(drDef));
                //clsMS_OutStorage_VO objOutMain = null;
                //clsMS_OutStorageDetail_VO objOutDetail = null;
                //DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //for (int iRow = 0; iRow < drDef.Length; iRow++)
                //{
                //    objOutMain = m_objGetMainOSVO(drDef[iRow], dtmNow, strCheckID, strCreator, dtmCheckDate);
                //    objOutDetail = m_objGetOSDetail(drDef[iRow]);
                //    lngRes = objSCDDomain.m_lngSaveCheckToOutStorage(objOutMain, objOutDetail);
                //}
            }
            //盘盈
            DataRow[] drSuf = dtbStorageCheck_detail.Select("CHECKRESULT_INT > 0");
            if (drSuf != null && drSuf.Length > 0)
            {
                lstSuf.AddRange(m_objCheckDetail(drSuf));
                lstStDetail.AddRange(m_objStorageDetailArr(drSuf));
                //clsMS_InStorage_VO objInMain = null;
                //clsMS_InStorageDetail_VO objInDetail = null;
                //DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                //for (int iRow = 0; iRow < drSuf.Length; iRow++)
                //{
                //    objInMain = m_objGetMainISVO(drSuf[iRow], dtmNow, strCheckID,strCreator,dtmCheckDate);
                //    objInDetail = m_objGetISDetail(drSuf[iRow]);
                //    lngRes = objSCDDomain.m_lngSaveCheckToInStorage(objInMain, objInDetail);
                //}
            }

            //lngRes = objSCDDomain.m_lngAddStorageDetailGross(lstStDetail.ToArray());

            Hashtable hstMedicine = new Hashtable();
            List<string> lstMedicineID = new List<string>();
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
            //if (lstMedicineID.Count > 0)
            //{
            //    lngRes = objSCDDomain.m_lngUpdateStorageGross(lstMedicineID.ToArray(), m_objViewer.m_strStorageID);
            //}

            //lngRes = objSCDDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngMainSEQ);
            //objSCDDomain = null;
            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lngRes = m_objDomain.m_lngCommitStorageCheck(lngMainSEQ, lstDef.ToArray(), lstSuf.ToArray(), lstStDetail.ToArray(), lstMedicineID.ToArray(), m_objViewer.LoginInfo.m_strEmpID,
                dtmNow, strCheckID, strCreator, dtmCheckDate, m_objViewer.m_strStorageID, m_objViewer.m_blnIsImmAccount);
 
            if (lngRes > 0)
            {
                DataRow drCurrent = drvCurrentMain.Row;
                drCurrent["examdate_dat"] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                drCurrent["examername"] = m_objViewer.LoginInfo.m_strEmpName;
                drCurrent["status"] = m_objViewer.m_blnIsImmAccount ? 3 : 2;
                drCurrent["statusdesc"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";
                MessageBox.Show("审核成功","药品盘点",MessageBoxButtons.OK,MessageBoxIcon.Information);
                m_mthSetDataToUI();
            }
            else
            {
                MessageBox.Show("审核失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            objDetail.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drData["CALLPRICE_INT"]);
            objDetail.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData["VALIDPERIOD_DAT"]);
            objDetail.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            return objDetail;
        } 
        #endregion

        #region 获取入库VO
        /// <summary>
        /// 获取主表VO
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <param name="p_dtmNewDate">制单日期</param>
        /// <param name="p_strCheckID">盘点号</param>
        /// <param name="p_strCreatorID">创建者ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <returns></returns>
        private clsMS_InStorage_VO m_objGetMainISVO(DataRow p_drData, DateTime p_dtmNewDate, string p_strCheckID,string p_strCreatorID, DateTime p_dtmCheckDate)
        {
            clsMS_InStorage_VO objISMainVO = new clsMS_InStorage_VO();

            objISMainVO.m_dtmNEWORDER_DAT = p_dtmNewDate;
            objISMainVO.m_intSTATE_INT = 2;
            objISMainVO.m_lngSERIESID_INT = 0;
            objISMainVO.m_strINSTORAGEID_VCHR = p_strCheckID;
            objISMainVO.m_strVENDORID_CHR = p_drData["vendorid_chr"].ToString();
            objISMainVO.m_dtmINSTORAGEDATE_DAT = p_dtmCheckDate;
            objISMainVO.m_strBUYERID_CHAR = string.Empty;
            objISMainVO.m_strSTORAGERID_CHAR = string.Empty;
            objISMainVO.m_strACCOUNTERID_CHAR = string.Empty;
            objISMainVO.m_strMAKERID_CHR = p_strCreatorID;
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
        /// <param name="p_strCheckID">盘点号</param>
        /// <param name="p_strCreatorID">创建者ID</param>
        /// <param name="p_dtmCheckDate">盘点日期</param>
        /// <returns></returns>
        private clsMS_OutStorage_VO m_objGetMainOSVO(DataRow p_drData, DateTime p_dtmNewDate,string p_strCheckID,string p_strCreatorID, DateTime p_dtmCheckDate)
        {
            clsMS_OutStorage_VO objOutMain = new clsMS_OutStorage_VO();
            objOutMain.m_dtmASKDATE_DAT = p_dtmNewDate;
            objOutMain.m_intSTATUS = 2;

            objOutMain.m_strASKDEPT_CHR = string.Empty;
            objOutMain.m_intOutStorageTYPE_INT = 1;
            objOutMain.m_intFORMTYPE_INT = 3;
            objOutMain.m_strASKERID_CHR = p_strCreatorID;
            objOutMain.m_strCOMMENT_VCHR = p_drData["CHECKREASON_VCHR"].ToString();
            objOutMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            objOutMain.m_dtmOutStorageDate = p_dtmCheckDate;
            objOutMain.m_strOUTSTORAGEID_VCHR = p_strCheckID;
            return objOutMain;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_drDetail">子表数据</param>
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
                objCheck[iRow].m_lngSERIESID_INT = Convert.ToInt64(p_drData[iRow]["seriesid_int"]);
                objCheck[iRow].m_lngSERIESID2_INT = Convert.ToInt64(p_drData[iRow]["seriesid2_int"]);
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

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        internal void m_mthInAccount()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择需审核的药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int intState = Convert.ToInt32(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index]["STATUS"]);
            if (intState != 2)
            {
                MessageBox.Show("只能对审核状态的盘点入帐", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m_dtvCurrentMainVienPage2.Count == 0)
            {
                return;
            }

            long lngMainSEQ = Convert.ToInt64(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index]["SERIESID_INT"]);
            string strCheckID = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index]["CHECKID_CHR"].ToString();
            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            long lngRes = m_objDomain.m_lngInAccount(lngMainSEQ, strCheckID, m_objViewer.LoginInfo.m_strEmpID, dtmNow,m_objViewer.m_strStorageID);

            if (lngRes > 0)
            {
                DataRow drCurrent = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index].Row;
                drCurrent["INACCOUNTID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                drCurrent["STATUS"] = 3;
                drCurrent["INACCOUNTDATE_DAT"] = dtmNow;
                drCurrent["statusdesc"] = "入帐";
                MessageBox.Show("入帐成功", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("入帐失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
        #endregion
    }
}
