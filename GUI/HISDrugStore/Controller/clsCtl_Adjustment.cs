using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.MedicineStore;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药品调价
    /// </summary>
    public class clsCtl_Adjustment : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_Adjustment m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmAdjustPrice m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 当前界面金额
        /// </summary>
        private DataTable m_dtbAllMoney = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品调价
        /// </summary>
        public clsCtl_Adjustment()
        {
            m_objDomain = new clsDcl_Adjustment();
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
            m_objViewer = (frmAdjustPrice)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo(string m_strMedStoreid)
        {
            //clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            //long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicineDict);
            clsPub.m_mthGetMedBaseInfo(m_strMedStoreid,out m_objViewer.m_dtbMedicineDict);
        }
        #endregion

        #region 获取调价主表信息
        /// <summary>
        /// 获取调价主表信息
        /// </summary>
        internal void m_mthGetAdjustMain()
        {
            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));

            long lngRes = 0;
            if (m_objViewer.m_txtMedicineName.Tag == null)
            {
                lngRes = m_objDomain.m_lngGetAdjustmentMain(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, out m_objViewer.m_dtbAdjustMain);
                lngRes = m_objDomain.m_lngGetAllMoney(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, out m_dtbAllMoney);
            }
            else
            {
                lngRes = m_objDomain.m_lngGetAdjustmentMain(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicineName.Tag.ToString(), dtmBegin, dtmEnd, out m_objViewer.m_dtbAdjustMain);
                lngRes = m_objDomain.m_lngGetAllMoney(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, m_objViewer.m_txtMedicineName.Tag.ToString(), out m_dtbAllMoney);
            }

            m_mthSetDataToUI();
        }

        private string m_strMainFilter()
        {
            string strFilter = string.Empty;
            if (!string.IsNullOrEmpty(m_objViewer.m_txtBillNumber.Text))
            {
                strFilter += "adjustpriceid_vchr like '" + m_objViewer.m_txtBillNumber.Text + "%'";
            }
            if (m_objViewer.m_cboDoseType.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilter))
                {
                    strFilter += " and ";
                }
                strFilter += "formstate_int =" + m_objViewer.m_cboDoseType.SelectedIndex.ToString();
            }
            return strFilter;
        }

        /// <summary>
        /// 设置数据至界面
        /// </summary>
        internal void m_mthSetDataToUI()
        {
            if (m_objViewer.m_dtbAdjustMain !=null)
            {
                string strFilter = m_strMainFilter();

                DataView dvMain = new DataView(m_objViewer.m_dtbAdjustMain);
                dvMain.RowFilter = strFilter;

                m_objViewer.m_dgvMainInfo.DataSource = dvMain;

                m_mthSetMainMoneyToUI();
            }
        } 
        #endregion

        #region 获取调价设置
        /// <summary>
        /// 获取调价设置
        /// </summary>
        internal void m_mthGetAdjustPriceSetting()
        {
            int intDiffLotNO = 0;//同一药品是否分批号调价

            long lngRes = m_objDomain.m_lngGetIsDiffLotNO(out intDiffLotNO);
            if (intDiffLotNO == 0)
            {
                m_objViewer.m_blnIsDiffLotNO = false;
            }
            else if (intDiffLotNO == 1)
            {
                m_objViewer.m_blnIsDiffLotNO = true;
            }

            int intIsChangeBase = 0;
            lngRes = m_objDomain.m_lngGetIsChangeBase(out intIsChangeBase);
            if (intIsChangeBase == 0)
            {
                m_objViewer.m_blnIsChangeBasePrice = false;
            }
            else if (intIsChangeBase == 1)
            {
                m_objViewer.m_blnIsChangeBasePrice = true;
            }
        }
        #endregion

        #region 获取调价明细
        /// <summary>
        /// 获取调价明细
        /// </summary>
        internal void m_mthGetAdjustDetail()
        {
            if (m_objViewer.m_dgvMainInfo.CurrentCell == null)
            {
                return;
            }

            int intCurrentIndex = m_objViewer.m_dgvMainInfo.CurrentCell.RowIndex;
            DataRowView drvSelected = m_objViewer.m_dgvMainInfo.Rows[intCurrentIndex].DataBoundItem as DataRowView;
            long lngSeriesId = Convert.ToInt64(drvSelected["SERIESID_INT"]);

            long lngRes = m_objDomain.m_lngGetAdjustmentDetail(lngSeriesId, out m_objViewer.m_dtbAdjustDetail);

            if (m_objViewer.m_dtbAdjustDetail != null && !m_objViewer.m_dtbAdjustDetail.Columns.Contains("banlance"))
            {
                m_objViewer.m_dtbAdjustDetail.Columns.Add("banlance", typeof(double));
                m_objViewer.m_dtbAdjustDetail.Columns["banlance"].Expression = "newretailprice_int - oldretailprice_int";
            }
            m_mthAdjustDetailRows(m_objViewer.m_dtbAdjustDetail);

            m_objViewer.m_dgvSubInfo.DataSource = m_objViewer.m_dtbAdjustDetail;
        } 
        #endregion

        #region 删除药品调价
        /// <summary>
        /// 删除药品调价
        /// </summary>
        internal void m_mthDeleteAdjust()
        {
            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            List<DataRow> lstDelete = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem;
                    int intState = Convert.ToInt32(drvCurrent["FORMSTATE_INT"]);
                    if (intState == 2 || intState == 3)//已审核或已入帐
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                    lstDelete.Add(drvCurrent.Row);
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核或已入账，将不能删除，是否继续？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条新制药品调价信息", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            long lngRes = m_objDomain.m_lngDeleteAdjustment(lngCheckRowIndex.ToArray());

            if (lngRes > 0)
            {
                MessageBox.Show("删除成功","药品调价",MessageBoxButtons.OK,MessageBoxIcon.Information);
                foreach (DataRow dr in lstDelete)
                {
                    m_objViewer.m_dtbAdjustMain.Rows.Remove(dr);
                }
                if (m_objViewer.m_dgvMainInfo.Rows.Count == 0)
                {
                    m_objViewer.m_dtbAdjustDetail.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region 审核药品调价
        /// <summary>
        /// 审核药品调价
        /// </summary>
        internal void m_mthCommit()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            List<DataRow> lstCommit = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem;
                    int intState = Convert.ToInt32(drvCurrent["FORMSTATE_INT"]);
                    if (intState == 2 || intState == 3)//已审核或已入帐
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                    lstCommit.Add(drvCurrent.Row);
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核或已入账，不能重复进行审核操作，是否继续？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条新制药品调价信息", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long lngRes = 0;

            DateTime dtmNow = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));//审核日期

            List<clsMS_MedicineInfoForAdjustPrice> objMedicine = new List<clsMS_MedicineInfoForAdjustPrice>();
            DataTable dtbDetail = null;
            for (int iRow = 0; iRow < lngCheckRowIndex.Count; iRow++)
            {
                lngRes = m_objDomain.m_lngGetAdjustmentDetail(lngCheckRowIndex[iRow], out dtbDetail);
                clsMS_MedicineInfoForAdjustPrice[] objAdjustArr = m_objAdjustPriceArr(dtbDetail, lstCommit[iRow], dtmNow);
                if (objAdjustArr != null && objAdjustArr.Length > 0)
                {
                    objMedicine.AddRange(objAdjustArr);
                }
            }

            lngRes = m_objDomain.m_lngCommitAdjustPrice(lngCheckRowIndex.ToArray(), m_objViewer.LoginInfo.m_strEmpID, dtmNow, objMedicine.ToArray(), m_objViewer.m_blnIsImmAccount,m_objViewer.m_blnIsChangeBasePrice);
            if (lngRes > 0)
            {
                foreach (DataRow dr in lstCommit)
                {
                    dr["statusdesc"] = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";
                    dr["formstate_int"] = m_objViewer.m_blnIsImmAccount ? 3 : 2;
                    dr["examerid_chr"] = m_objViewer.LoginInfo.m_strEmpID;
                    dr["examername"] = m_objViewer.LoginInfo.m_strEmpName;
                    dr["examdate_dat"] = dtmNow;
                }
                MessageBox.Show("审核成功","药品调价",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("审核失败","药品调价",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 获取调价药品信息
        /// </summary>
        /// <param name="p_dtbAdjustDetail">调价药品明细信息</param>
        /// <param name="p_drMain">调价药品主记录</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <returns></returns>
        private clsMS_MedicineInfoForAdjustPrice[] m_objAdjustPriceArr(DataTable p_dtbAdjustDetail, DataRow p_drMain,DateTime p_dtmCommitDate)
        {
            if (p_dtbAdjustDetail == null || p_dtbAdjustDetail.Rows.Count == 0 || p_drMain == null)
            {
                return null;
            }

            int intRowsCount = p_dtbAdjustDetail.Rows.Count;
            clsMS_MedicineInfoForAdjustPrice[] objAdjustPrice = new clsMS_MedicineInfoForAdjustPrice[intRowsCount];
            DataRow drTemp = null;
            for (int i = 0; i < intRowsCount; i++)
            {
                drTemp = p_dtbAdjustDetail.Rows[i];
                objAdjustPrice[i] = new clsMS_MedicineInfoForAdjustPrice();
                objAdjustPrice[i].m_dblNewRetailPrice = Convert.ToDouble(drTemp["newretailprice_int"]);
                objAdjustPrice[i].m_dblOldRetailPrice = Convert.ToDouble(drTemp["oldretailprice_int"]);
                objAdjustPrice[i].m_dtmAdjustDate = p_dtmCommitDate;
                objAdjustPrice[i].m_strAdjustManID = m_objViewer.LoginInfo.m_strEmpID;
                objAdjustPrice[i].m_strLotNO = drTemp["LOTNO_VCHR"].ToString();
                objAdjustPrice[i].m_strMedicineID = drTemp["MEDICINEID_CHR"].ToString();
                objAdjustPrice[i].m_strStorageID = m_objViewer.m_strStorageID;
                objAdjustPrice[i].m_strInStorageID = drTemp["INSTORAGEID_VCHR"].ToString();
                objAdjustPrice[i].m_lngAdjustDetaiSEQ = Convert.ToInt64(drTemp["SERIESID_INT"]);
                objAdjustPrice[i].m_dtmValidDate = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
                objAdjustPrice[i].m_dblInPrice = Convert.ToDouble(drTemp["CALLPRICE_INT"]);
            }
            return objAdjustPrice;
        }

        /// <summary>
        /// 获取调价药品信息(退审时新、旧零售价调换)
        /// </summary>
        /// <param name="p_dtbAdjustDetail">调价药品明细信息</param>
        /// <param name="p_drMain">调价药品主记录</param>
        /// <returns></returns>
        private clsMS_MedicineInfoForAdjustPrice[] m_objAdjustPriceForUnCommitArr(DataTable p_dtbAdjustDetail, DataRow p_drMain)
        {
            if (p_dtbAdjustDetail == null || p_dtbAdjustDetail.Rows.Count == 0 || p_drMain == null)
            {
                return null;
            }

            int intRowsCount = p_dtbAdjustDetail.Rows.Count;
            clsMS_MedicineInfoForAdjustPrice[] objAdjustPrice = new clsMS_MedicineInfoForAdjustPrice[intRowsCount];
            DataRow drTemp = null;
            for (int i = 0; i < intRowsCount; i++)
            {
                drTemp = p_dtbAdjustDetail.Rows[i];
                objAdjustPrice[i] = new clsMS_MedicineInfoForAdjustPrice();
                objAdjustPrice[i].m_dblNewRetailPrice = Convert.ToDouble(drTemp["oldretailprice_int"]);
                objAdjustPrice[i].m_dblOldRetailPrice = Convert.ToDouble(drTemp["newretailprice_int"]);
                objAdjustPrice[i].m_dtmAdjustDate = Convert.ToDateTime(p_drMain["ADJUSTPRICEDATE_DAT"]);
                objAdjustPrice[i].m_strAdjustManID = m_objViewer.LoginInfo.m_strEmpID;
                objAdjustPrice[i].m_strLotNO = drTemp["LOTNO_VCHR"].ToString();
                objAdjustPrice[i].m_strMedicineID = drTemp["MEDICINEID_CHR"].ToString();
                objAdjustPrice[i].m_strStorageID = m_objViewer.m_strStorageID;
                objAdjustPrice[i].m_strInStorageID = drTemp["INSTORAGEID_VCHR"].ToString();
                objAdjustPrice[i].m_lngAdjustDetaiSEQ = Convert.ToInt64(drTemp["SERIESID_INT"]);
                objAdjustPrice[i].m_dblInPrice = Convert.ToDouble(drTemp["CALLPRICE_INT"]);
                objAdjustPrice[i].m_dtmValidDate = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
            }
            return objAdjustPrice;
        }
        #endregion

        #region 退审药品调价
        /// <summary>
        /// 退审药品调价
        /// </summary>
        internal void m_mthUnCommit()
        {
            //return;//调价不允许退审
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            List<DataRow> lstCommit = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem;
                    int intState = Convert.ToInt32(drvCurrent["FORMSTATE_INT"]);
                    if (intState != 2)//非审核状态
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                        continue;
                    }
                    lngCheckRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                    lstCommit.Add(drvCurrent.Row);
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录非审核状态，不能执行退审操作，是否继续？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择审核状态药品调价信息", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long lngRes = 0;
            List<clsMS_MedicineInfoForAdjustPrice> objMedicine = new List<clsMS_MedicineInfoForAdjustPrice>();
            List<string> lstAdjustID = new List<string>();
            DataTable dtbDetail = null;
            for (int iRow = 0; iRow < lngCheckRowIndex.Count; iRow++)
            {
                lstAdjustID.Add(lstCommit[iRow]["ADJUSTPRICEID_VCHR"].ToString());
                //lstAdjustID.Add(lstCommit[iRow]["instorageid_vchr"].ToString());
                lngRes = m_objDomain.m_lngGetAdjustmentDetail(lngCheckRowIndex[iRow], out dtbDetail);
                clsMS_MedicineInfoForAdjustPrice[] objAdjustArr = m_objAdjustPriceForUnCommitArr(dtbDetail, lstCommit[iRow]);
                if (objAdjustArr != null && objAdjustArr.Length > 0)
                {
                    objMedicine.AddRange(objAdjustArr);
                }
            }

            lngRes = m_objDomain.m_lngUnCommitAdjustPrice(lngCheckRowIndex.ToArray(), objMedicine.ToArray(), lstAdjustID.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss")),m_objViewer.m_blnIsChangeBasePrice);
            if (lngRes > 0)
            {
                foreach (DataRow dr in lstCommit)
                {
                    dr["statusdesc"] = "新制";
                    dr["formstate_int"] = 1;
                    dr["examerid_chr"] = string.Empty;
                    dr["examername"] = string.Empty;
                    dr["examdate_dat"] = DBNull.Value;
                }
                MessageBox.Show("退审成功", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("退审失败", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicineDict, true);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineName.Location.X + m_objViewer.m_txtMedicineName.Size.Width + m_objViewer.gradientPanel2.Location.X - m_ctlQueryMedicint.Size.Width;
                Y = m_objViewer.m_txtMedicineName.Location.Y + m_objViewer.m_txtMedicineName.Size.Height + m_objViewer.gradientPanel2.Location.Y;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthGetMedicineInfo(m_objViewer.m_strMedstoreid);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineDict;
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            m_objViewer.m_txtMedicineName.Focus();
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtMedicineName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineName.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_btnFind.Focus();
        }
        #endregion

        #region 获取药品调价信息
        /// <summary>
        /// 获取药品主表内容
        /// </summary>
        /// <param name="p_drCurrent">选中药品主表内容</param>
        /// <returns></returns>
        internal clsDS_Adjustment_VO m_objMain(DataRow p_drCurrent)
        {
            if (p_drCurrent == null)
            {
                return null;
            }

            clsDS_Adjustment_VO objMain = new clsDS_Adjustment_VO();
            objMain.m_dtmADJUSTPRICEDATE_DAT = Convert.ToDateTime(p_drCurrent["ADJUSTPRICEDATE_DAT"]);
            if (p_drCurrent["EXAMDATE_DAT"] != DBNull.Value)
            {
                objMain.m_dtmEXAMDATE_DAT = Convert.ToDateTime(p_drCurrent["EXAMDATE_DAT"]);
            }
            else
            {
                objMain.m_dtmEXAMDATE_DAT = DateTime.MinValue;
            }
            if (p_drCurrent["INACCOUNTDATE_DAT"] != DBNull.Value)
            {
                objMain.m_dtmINACCOUNTDATE_DAT = Convert.ToDateTime(p_drCurrent["INACCOUNTDATE_DAT"]);
            }
            else
            {
                objMain.m_dtmINACCOUNTDATE_DAT = DateTime.MinValue;
            }

            objMain.m_dtmNEWDATE_DAT = Convert.ToDateTime(p_drCurrent["NEWDATE_DAT"]);
            objMain.m_intFORMSTATE_INT = Convert.ToInt32(p_drCurrent["FORMSTATE_INT"]);
            //objMain.m_intFORMTYPE_INT = Convert.ToInt32(p_drCurrent["FORMTYPE_INT"]);
            objMain.m_lngSERIESID_INT = Convert.ToInt64(p_drCurrent["SERIESID_INT"]);
            objMain.m_strADJUSTPRICEID_VCHR = p_drCurrent["ADJUSTPRICEID_VCHR"].ToString();
            objMain.m_strCOMMENT_VCHR = p_drCurrent["COMMENT_VCHR"].ToString();
            objMain.m_strCREATORID_CHR = p_drCurrent["CREATORID_CHR"].ToString();
            objMain.m_strCreatorName = p_drCurrent["creatorname"].ToString();
            objMain.m_strEXAMERID_CHR = p_drCurrent["EXAMERID_CHR"].ToString();
            objMain.m_strEXAMERName = p_drCurrent["examername"].ToString();
            //objMain.m_strDrugStoreid = m_objViewer.m_strStorageID;
            return objMain;
        }

        /// <summary>
        /// 获取药品调价明细
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        internal clsDS_Adjustment_Detail[] m_objDetail(long p_lngMainSEQ)
        {
            DataTable dtbDetail = null;
            long lngRes = m_objDomain.m_lngGetAdjustmentDetail(p_lngMainSEQ, out dtbDetail);

            if (dtbDetail == null || dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = dtbDetail.Rows.Count;
            long lngSEQ = 0;
            clsDS_Adjustment_Detail[] objDetail = new clsDS_Adjustment_Detail[intRowsCount];
            DataRow drTemp = null;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = dtbDetail.Rows[iRow];
                objDetail[iRow] = new clsDS_Adjustment_Detail();

                objDetail[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["validperiod_dat"]);
                objDetail[iRow].m_intSTATUS_INT = 1;
                objDetail[iRow].m_strLOTNO_VCHR = drTemp["lotno_vchr"].ToString();
                objDetail[iRow].m_strMEDICINEID_CHR = drTemp["medicineid_chr"].ToString();
                objDetail[iRow].m_strMEDICINENAME_VCHR = drTemp["medicinename_vch"].ToString();
                objDetail[iRow].m_strMEDSPEC_VCHR = drTemp["medspec_vchr"].ToString();
                objDetail[iRow].m_strREASON_VCHR = drTemp["reason_vchr"].ToString();
                objDetail[iRow].m_strOPUNIT_VCHR = drTemp["OPUNIT_VCHR"].ToString();
                objDetail[iRow].m_strMedicineCode = drTemp["assistcode_chr"].ToString();
                objDetail[iRow].m_strINSTORAGEID_VCHR = drTemp["INSTORAGEID_VCHR"].ToString();
                if (long.TryParse(drTemp["SERIESID_INT"].ToString(),out lngSEQ))
                {
                    objDetail[iRow].m_lngSERIESID_INT = lngSEQ;
                }

                objDetail[iRow].m_strPRODUCTORID_CHR = drTemp["productorid_chr"].ToString();
            }
            return objDetail;
        } 
        #endregion

        #region 显示主表总金额
        /// <summary>
        /// 显示主表总金额
        /// </summary>
        internal void m_mthSetMainMoneyToUI()
        {
            m_objViewer.m_lblMainMoney.Text = string.Empty;

            if (m_dtbAllMoney == null || m_dtbAllMoney.Rows.Count == 0)
            {
                return;
            }

            string strFilter = m_strMainFilter();
            DataRow[] drUI = m_dtbAllMoney.Select(strFilter);

            if (drUI == null || drUI.Length == 0)
            {
                return;
            }

            double dblMoney = 0d;
            for (int i = 0; i < drUI.Length; i++)
            {
                dblMoney += (Convert.ToDouble(drUI[i]["newretailprice_int"]) * Convert.ToDouble(drUI[i]["currentgross_int"]))
                    - (Convert.ToDouble(drUI[i]["oldretailprice_int"]) * Convert.ToDouble(drUI[i]["currentgross_int"]));
            }

            m_objViewer.m_lblMainMoney.Text = dblMoney.ToString("0.0000");
        } 
        #endregion

        #region 显示明细表金额
        /// <summary>
        /// 显示明细表金额
        /// </summary>
        internal void m_mthSetSubMoneyToUI()
        {
            m_objViewer.m_lblSubMoney.Text = string.Empty;
            m_objViewer.m_lblBeforeMoney.Text = string.Empty;
            m_objViewer.m_lblAfterMoney.Text = string.Empty;

            if (m_objViewer.m_dtbAdjustDetail == null || m_objViewer.m_dtbAdjustDetail.Rows.Count == 0)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtbAdjustDetail.Rows.Count;
            DataRow drCurrent = null;
            double dblBeforemoney = 0d;
            double dblAftermoney = 0d;
            double dblSubMoney = 0d;
            for (int i = 0; i < intRowsCount; i++)
            {
                drCurrent = m_objViewer.m_dtbAdjustDetail.Rows[i];

                double dblCurrentGross;
                if (double.TryParse(drCurrent["currentgross_int"].ToString(), out dblCurrentGross))
                {
                    double dblAM = Convert.ToDouble(drCurrent["newretailprice_int"]) * Convert.ToDouble(drCurrent["currentgross_int"]);
                    double dblBM = Convert.ToDouble(drCurrent["oldretailprice_int"]) * Convert.ToDouble(drCurrent["currentgross_int"]);

                    dblAftermoney += dblAM;
                    dblBeforemoney += dblBM;
                    dblSubMoney += (dblAM - dblBM);
                }
            }

            m_objViewer.m_lblSubMoney.Text = dblSubMoney.ToString("0.0000");
            m_objViewer.m_lblBeforeMoney.Text = dblBeforemoney.ToString("0.0000");
            m_objViewer.m_lblAfterMoney.Text = dblAftermoney.ToString("0.0000");
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
                MessageBox.Show("当前用户没有药库管理权限，不能入帐", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            List<string> lstAdjustPriceID = new List<string>();
            List<DataRow> lstCheckRow = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem;
                    int intState = Convert.ToInt32(drvCurrent["FORMSTATE_INT"]);
                    if (intState == 2)
                    {
                        lngCheckRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                        lstAdjustPriceID.Add(drvCurrent["ADJUSTPRICEID_VCHR"].ToString());
                        lstCheckRow.Add(drvCurrent.Row);
                    }
                    else
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(drvCurrent["SERIESID_INT"]));
                    }
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录不是审核状态，不能执行入帐操作，是否继续？", "药品调价", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条审核状态的药品调价信息", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long lngRes = 0;

            DateTime dtmNow = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));//审核日期

            lngRes = m_objDomain.m_lngInAccount(lstAdjustPriceID.ToArray(), lngCheckRowIndex.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, dtmNow);

            if (lngRes > 0)
            {
                foreach (DataRow dr in lstCheckRow)
                {
                    dr["INACCOUNTID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                    dr["FORMSTATE_INT"] = 3;
                    dr["INACCOUNTDATE_DAT"] = dtmNow;
                    dr["statusdesc"] = "入帐";
                }
                MessageBox.Show("入帐成功", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("入帐失败", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        } 
        #endregion

        #region 根据是否按批号显示调整明细行
        /// <summary>
        /// 根据是否按批号显示调整明细行
        /// </summary>
        /// <param name="p_dtbDetail">明细数据</param>
        internal void m_mthAdjustDetailRows(DataTable p_dtbDetail)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return;
            }

            List<DataRow> lstDRMedicine = new List<DataRow>();

            //只要是零售单价不同，不管是否分批号显示设置，均分开显示
            int intRowsCount = p_dtbDetail.Rows.Count;
            if (m_objViewer.m_blnIsDiffLotNO)
            {
                double dblGross = 0d;
                double LastPrice = 0d;
                DataRow drFirstRow = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    if (i > 0)
                    {
                        double dblCurrent = Convert.ToDouble(p_dtbDetail.Rows[i]["OLDRETAILPRICE_INT"]);
                        if (p_dtbDetail.Rows[i]["lotno_vchr"].ToString() == p_dtbDetail.Rows[i - 1]["lotno_vchr"].ToString() && p_dtbDetail.Rows[i]["MEDICINEID_CHR"].ToString() == p_dtbDetail.Rows[i - 1]["MEDICINEID_CHR"].ToString())
                        {
                            if (LastPrice != dblCurrent)
                            {
                                drFirstRow = p_dtbDetail.NewRow();
                                drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                                LastPrice = dblCurrent;
                                dblGross = 0;
                                lstDRMedicine.Add(drFirstRow);
                            }
                            else
                            {
                                dblGross += Convert.ToDouble(p_dtbDetail.Rows[i]["CURRENTGROSS_INT"]);
                                LastPrice = dblCurrent;
                                drFirstRow["CURRENTGROSS_INT"] = dblGross;
                                continue;
                            }
                        }
                        else
                        {
                            drFirstRow = p_dtbDetail.NewRow();
                            drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                            LastPrice = dblCurrent;
                            dblGross = 0;
                            lstDRMedicine.Add(drFirstRow);
                        }
                    }
                    else
                    {
                        drFirstRow = p_dtbDetail.NewRow();
                        drFirstRow.ItemArray = p_dtbDetail.Rows[0].ItemArray;
                        dblGross = Convert.ToDouble(p_dtbDetail.Rows[0]["CURRENTGROSS_INT"]);
                        LastPrice = Convert.ToDouble(p_dtbDetail.Rows[0]["OLDRETAILPRICE_INT"]);
                        lstDRMedicine.Add(drFirstRow);
                    }
                }
            }
            else
            {
                double dblGross = 0d;
                double LastPrice = 0d;
                DataRow drFirstRow = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    if (i > 0)
                    {
                        double dblCurrent = Convert.ToDouble(p_dtbDetail.Rows[i]["OLDRETAILPRICE_INT"]);
                        if (p_dtbDetail.Rows[i]["MEDICINEID_CHR"].ToString() == p_dtbDetail.Rows[i - 1]["MEDICINEID_CHR"].ToString())
                        {
                            if (LastPrice != dblCurrent)
                            {
                                drFirstRow = p_dtbDetail.NewRow();
                                drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                                LastPrice = dblCurrent;
                                dblGross = 0;
                                lstDRMedicine.Add(drFirstRow);
                            }
                            else
                            {
                                double douCurrentGross;
                                if (double.TryParse(p_dtbDetail.Rows[i]["CURRENTGROSS_INT"].ToString(), out douCurrentGross))
                                {
                                    dblGross += Convert.ToDouble(p_dtbDetail.Rows[i]["CURRENTGROSS_INT"]);
                                }
                                LastPrice = dblCurrent;
                                drFirstRow["CURRENTGROSS_INT"] = dblGross;
                                continue;
                            }
                        }
                        else
                        {
                            drFirstRow = p_dtbDetail.NewRow();
                            drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                            LastPrice = dblCurrent;
                            dblGross = 0;
                            lstDRMedicine.Add(drFirstRow);
                        }
                    }
                    else
                    {
                        drFirstRow = p_dtbDetail.NewRow();
                        drFirstRow.ItemArray = p_dtbDetail.Rows[0].ItemArray;
                        if (p_dtbDetail.Rows[0]["CURRENTGROSS_INT"] != DBNull.Value)
                        {
                            dblGross = Convert.ToDouble(p_dtbDetail.Rows[0]["CURRENTGROSS_INT"]);
                        }
                        else
                        {
                            dblGross = 0;
                        }
                        if (p_dtbDetail.Rows[0]["OLDRETAILPRICE_INT"] != DBNull.Value)
                        {
                            LastPrice = Convert.ToDouble(p_dtbDetail.Rows[0]["OLDRETAILPRICE_INT"]);
                        }
                        else
                        {
                            LastPrice = 0;
                        }
                        lstDRMedicine.Add(drFirstRow);
                    }
                }
            }

            p_dtbDetail.Rows.Clear();
            p_dtbDetail.BeginLoadData();
            for (int iRow = 0; iRow < lstDRMedicine.Count; iRow++)
            {
                p_dtbDetail.LoadDataRow(lstDRMedicine[iRow].ItemArray,true);
            }
            p_dtbDetail.EndLoadData();
        } 
        #endregion
    }
}
