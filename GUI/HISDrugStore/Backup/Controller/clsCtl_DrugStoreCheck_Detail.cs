using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_DrugStoreCheck_Detail : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_DrugStoreCheckDetail m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private frmDrugStoreCheck_Detail m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint_lock = null;

        /// <summary>
        /// 当前盘点主记录
        /// </summary>
        private clsDS_Check_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前盘点明细
        /// </summary>
        private clsDS_StorageCheckDetail_VO[] m_objCurrentSubArr = null;
        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;
        /// <summary>
        /// 保存是否立即审核 0-否；1-是
        /// </summary>
        private string m_strCommit = "1";
        DataTable m_dtbMoney = null;
        /// <summary>
        /// 打印格式：0为三院 1为常平
        /// </summary>
        private string m_strPrintFormat = "0";
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_DrugStoreCheck_Detail()
        {
            m_objDomain = new clsDcl_DrugStoreCheckDetail();
            m_strCommit = this.m_objComInfo.m_lonGetModuleInfo("5005");
            m_strPrintFormat = this.m_objComInfo.m_lonGetModuleInfo("0433");
           
        }
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDrugStoreCheck_Detail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 插入新的一行药品
        /// <summary>
        /// 插入新的一行药品
        /// </summary>
        internal void m_mthInsertNewMedicineData()
        {
            try
            {
                if (m_objViewer.dtbDrugCheck_detail == null)
                {
                    return;
                }
                m_objViewer.dtbDrugCheck_detail.DefaultView.RowFilter = "";
                DataRow drNew = m_objViewer.dtbDrugCheck_detail.NewRow();
                m_objViewer.dtbDrugCheck_detail.Rows.Add(drNew);

                m_objViewer.m_dgvDetailInfo.Focus();
                if (m_objViewer.m_dgvDetailInfo.RowCount > 0)
                    m_objViewer.m_dgvDetailInfo.CurrentCell = m_objViewer.m_dgvDetailInfo["assistcode_chr", m_objViewer.m_dgvDetailInfo.RowCount - 1];
            }
            catch
            {
            }
        }
        #endregion

        #region 删除盘点明细
        /// <summary>
        /// 删除盘点明细
        /// </summary>
        internal void m_mthDeleteStoreCheck()
        {
            if (m_objViewer.m_dgvDetailInfo.CurrentCell == null)
                return;

            //20090915:在删除之前判断状态
            if (m_objCurrentMain != null)//检查盘点单状态
            {
                int intStatus = -1;
                clsDcl_DrugStoreCheck objDom = new clsDcl_DrugStoreCheck();
                objDom.m_lngCheckStatus(2, m_objCurrentMain.m_lngSERIESID_INT, out intStatus);
                if (intStatus == 3)
                {
                    MessageBox.Show("该药房盘点记录已入帐，不能删除", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (intStatus == 2)
                {
                    MessageBox.Show("该药房盘点记录已审核，不能删除", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (intStatus == -1)
                {
                    MessageBox.Show("该药房盘点记录已删除，不能删除", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            long lngRes = 0;
            long lngSeq = 0;
            int intCurrentRow = m_objViewer.m_dgvDetailInfo.CurrentCell.RowIndex;
            DataRowView drvCurrent = m_objViewer.m_dgvDetailInfo.Rows[intCurrentRow].DataBoundItem as DataRowView;
            DataRow drCurrent = drvCurrent.Row;
            
            if (long.TryParse(drvCurrent["SERIESID_INT"].ToString(), out lngSeq))
            {
                DataTable dtbCheckResult = null;
                lngRes = m_objDomain.m_lngGetCheckResult(lngSeq, out dtbCheckResult);

                if (dtbCheckResult != null && dtbCheckResult.Rows.Count > 0)// && double.TryParse(dtbCheckResult.Rows[0]["checkresult_int"].ToString(), out dblCheckResult))
                {
                    clsDS_StorageDetail_VO[] objStDetail = m_objStoreDetail(dtbCheckResult);

                    lngRes = m_objDomain.m_lngDeleteStoreCheckMedicine(objStDetail, m_objCurrentMain.m_strCHECKID_CHR, lngSeq);
                }
                if (lngRes > 0)
                {
                    m_objViewer.dtbDrugCheck_detail.Rows.Remove(drCurrent);
                    MessageBox.Show("删除成功", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除失败", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string strMedicineID = drCurrent["medicineid_chr"].ToString();
                m_objViewer.dtbDrugCheck_detail.Rows.Remove(drCurrent);
                if (m_objViewer.dtbDrugCheck_TrueDetail != null)
                {
                    DataRow[] drDelete = m_objViewer.dtbDrugCheck_TrueDetail.Select("medicineid_chr = '" + strMedicineID + "'");
                    if (drDelete != null)
                    {
                        foreach (DataRow dr in drDelete)
                        {
                            m_objViewer.dtbDrugCheck_TrueDetail.Rows.Remove(dr);
                        }
                    }
                }
                MessageBox.Show("删除成功", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsDS_StorageDetail_VO[] m_objStoreDetail(DataTable p_drData)
        {
            if (p_drData == null || p_drData.Rows.Count == 0)
            {
                return null;
            }
            clsDS_StorageDetail_VO[] objDetailArr = new clsDS_StorageDetail_VO[p_drData.Rows.Count];
            for (int i1 = 0; i1 < p_drData.Rows.Count; i1++)
            {
                objDetailArr[i1] = new clsDS_StorageDetail_VO();
                objDetailArr[i1].m_dblOPAVAILABLEGROSS_NUM = Convert.ToDouble(p_drData.Rows[i1]["opcheckresult_int"]);
                objDetailArr[i1].m_dblOPREALGROSS_INT = Convert.ToDouble(p_drData.Rows[i1]["opcheckresult_int"]);
                objDetailArr[i1].m_strLOTNO_VCHR = p_drData.Rows[i1]["LOTNO_VCHR"].ToString();
                objDetailArr[i1].m_strDSINSTOREID_VCHR = p_drData.Rows[i1]["indrugstoreid_vchr"].ToString();
                objDetailArr[i1].m_strMEDICINEID_CHR = p_drData.Rows[i1]["MEDICINEID_CHR"].ToString();
                objDetailArr[i1].m_strDRUGSTOREID_CHR = m_objViewer.m_strStoreDeptID;
                objDetailArr[i1].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData.Rows[i1]["VALIDPERIOD_DAT"]);
                double dblTemp = 0d;
                if (double.TryParse(p_drData.Rows[i1]["opcallprice_int"].ToString(), out dblTemp))
                {
                    objDetailArr[i1].m_dblOPWHOLESALEPRICE_INT = dblTemp;
                }
            }
            return objDetailArr;
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
            
            m_objDomain.m_lngGetEMP(p_strSearch, out dtbEmp);

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
            int X = p_txtEmp.Location.X;
            int Y = p_txtEmp.Location.Y + p_txtEmp.Size.Height;

            if ((X + m_ctlEMP.Size.Width) > m_objViewer.Size.Width)
            {
                X = p_txtEmp.Location.X - (X + m_ctlEMP.Size.Width - m_objViewer.Size.Width);
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

            if (Sender.Name == "m_txtMaker")
            {
                m_objViewer.m_txtFindMedicine.Focus();
            }
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
                m_ctlQueryMedicint_lock.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_lock_RefreshMedicine);
            }
            m_ctlQueryMedicint_lock.Location = new System.Drawing.Point(150, 40 + m_objViewer.m_txtFindMedicine.Height);
            m_ctlQueryMedicint_lock.Visible = true;
            m_ctlQueryMedicint_lock.BringToFront();
            m_ctlQueryMedicint_lock.Focus();
            m_ctlQueryMedicint_lock.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_lock_RefreshMedicine()
        {
            m_mthGetMedBaseInfo(m_objViewer.m_strStoreID, ref m_objViewer.m_dtbMedicineInfo);
            m_ctlQueryMedicint_lock.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineInfo;
        }
        

        private long m_ctlQueryMedicint_BeforeReturnInfo_lock(string p_strMedicineID)
        {
            long lngReturn = 1;

            //DataTable dtbMedicine = null;
            //long lngRes = m_objDomain.m_lngGetMedicineByMedicineID(p_strMedicineID, m_objViewer.m_strDrugID, m_objViewer.m_blnIsHospital, out dtbMedicine);
            //if (dtbMedicine == null || dtbMedicine.Rows.Count == 0)
            //{
            //    MessageBox.Show("未找到所选择药品的库存信息", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    m_ctlQueryMedicint_lock.Visible = true;
            //    m_ctlQueryMedicint_lock.Focus();
            //    return -1;
            //}
            //m_objViewer.m_txtFindMedicine.Text = dtbMedicine.Rows[0]["MEDICINENAME_VCHR"].ToString();
            //m_objViewer.m_txtFindMedicine.Tag = dtbMedicine.Rows[0]["MEDICINEID_CHR"].ToString();
            m_mthLocalizeRow(p_strMedicineID);
            m_objViewer.m_dgvDetailInfo.Focus();
            return lngReturn;
        }
        #endregion

        #region 定位行
        /// <summary>
        /// 定位行
        /// </summary>
        /// <param name="p_strSearch">搜索字符</param>
        internal void m_mthLocalizeRow(string p_strSearch)
        {
            if (p_strSearch.Trim().Length == 0) return;
            for (int iRow = 0; iRow < m_objViewer.m_dgvDetailInfo.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells["medicineid_chr"].Value != null
                    && m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells["medicineid_chr"].Value.ToString() == p_strSearch)
                {
                    m_objViewer.m_dgvDetailInfo.Rows[iRow].Selected = true;
                    m_objViewer.m_dgvDetailInfo.CurrentCell = m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[3];
                    break;
                }
            }
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

            if (m_objViewer.dtbDrugCheck_detail == null || m_objViewer.dtbDrugCheck_detail.Rows.Count == 0)
            {
                return;
            }

            m_dtbMoney = m_objViewer.dtbDrugCheck_detail.DefaultView.ToTable();
            int intRowsCount = m_dtbMoney.Rows.Count;
            double dblBalanceMoney = 0d;
            double dblBuyInMoney = 0d;
            double dblRetailMoney = 0d;
            double dblBM = 0d;
            double dblIM = 0d;
            double dblRM = 0d;
                        
            if (m_objViewer.intShowType == 1)//用这个速度快一点。
            {
                foreach (DataRow dr in m_objViewer.dtbDrugCheck_TrueDetail.Rows)
                {
                    if (dr["opretailprice_int"].ToString().Length == 0)
                        continue;
                    dblBM = Convert.ToDouble(dr["balance"]);
                    dblBalanceMoney += dblBM;
                    dblIM = Convert.ToDouble(dr["callmoney"]);
                    dblBuyInMoney += dblIM;
                    dblRM = Convert.ToDouble(dr["realmoney"]);
                    dblRetailMoney += dblRM;
                }
            }
            else
            {
                DataGridViewRow drgv = null;
                if (m_objViewer.m_dgvDetailInfo.Rows.Count == 0) return;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drgv = m_objViewer.m_dgvDetailInfo.Rows[iRow];
                    if (drgv.Cells["opretailprice_int"].Value.ToString().Length == 0)
                    {
                        continue;
                    }                 
                    if (drgv.Cells["m_dgvtxtBalance"].Value.ToString().Length > 0)
                    {
                        dblBM = Convert.ToDouble(drgv.Cells["m_dgvtxtBalance"].Value);
                        dblBalanceMoney += dblBM;
                    }

                    if (drgv.Cells["CALLPRICE_INT"].Value != DBNull.Value && drgv.Cells["CALLPRICE_INT"].Value.ToString().Length > 0
                        && drgv.Cells["OPCHECKGROSS_INT"].Value != DBNull.Value && drgv.Cells["OPCHECKGROSS_INT"].Value.ToString().Length > 0
                        && drgv.Cells["IPCHECKGROSS_INT"].Value != DBNull.Value && drgv.Cells["IPCHECKGROSS_INT"].Value.ToString().Length > 0
                        && drgv.Cells["packqty_dec"].Value != DBNull.Value && drgv.Cells["packqty_dec"].Value.ToString().Length > 0)
                    {
                        dblIM = Convert.ToDouble(drgv.Cells["CALLPRICE_INT"].Value) * Convert.ToDouble(drgv.Cells["OPCHECKGROSS_INT"].Value);
                        dblIM += Convert.ToDouble(drgv.Cells["CALLPRICE_INT"].Value) * Convert.ToDouble(drgv.Cells["IPCHECKGROSS_INT"].Value) / Convert.ToDouble(drgv.Cells["packqty_dec"].Value);
                        dblBuyInMoney += dblIM;
                    }
                    
                    if (drgv.Cells["opretailprice_int"].Value != DBNull.Value && drgv.Cells["opretailprice_int"].Value.ToString().Length > 0
                        && drgv.Cells["OPCHECKGROSS_INT"].Value != DBNull.Value && drgv.Cells["OPCHECKGROSS_INT"].Value.ToString().Length > 0
                        && drgv.Cells["IPCHECKGROSS_INT"].Value != DBNull.Value && drgv.Cells["IPCHECKGROSS_INT"].Value.ToString().Length > 0
                        && drgv.Cells["packqty_dec"].Value != DBNull.Value && drgv.Cells["packqty_dec"].Value.ToString().Length > 0)
                    {
                        dblRM = Convert.ToDouble(drgv.Cells["OPCHECKGROSS_INT"].Value) * Convert.ToDouble(drgv.Cells["opretailprice_int"].Value);
                        dblRM += Convert.ToDouble(drgv.Cells["IPCHECKGROSS_INT"].Value) * Convert.ToDouble(drgv.Cells["opretailprice_int"].Value) / Convert.ToDouble(drgv.Cells["packqty_dec"].Value);
                        dblRetailMoney += dblRM;
                    }                    
                }
            }

            //盈亏金额
            m_objViewer.m_lblBalanceMoney.Text = dblBalanceMoney.ToString("0.0000")+"元";

            //购入金额
            m_objViewer.m_lblBuyInSubMoney.Text = dblBuyInMoney.ToString("0.0000");

            //零售金额
            m_objViewer.m_lblRetailSubMoney.Text = dblRetailMoney.ToString("0.0000")+"元";
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
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_ctlQueryMedicint_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvDetailInfo.Location.X,
                rect.Y + m_objViewer.m_dgvDetailInfo.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvDetailInfo.Location.X,
                rect.Y + m_objViewer.m_dgvDetailInfo.Location.Y  - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthGetMedBaseInfo(m_objViewer.m_strStoreID, ref m_objViewer.m_dtbMedicineInfo);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineInfo;
        }

        void m_ctlQueryMedicint_ReturnInfo(clsMS_MedicintLeastElement_VO MS_VO)
        {
            m_mthInsertNewMedicineData();
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;

            DataTable dtbMedicine = null;
            long lngRes = m_objDomain.m_lngGetMedicineByMedicineID(p_strMedicineID, m_objViewer.m_strDrugID, m_objViewer.m_blnIsHospital, out dtbMedicine);

            if(dtbMedicine == null || dtbMedicine.Rows.Count == 0)
            {
                MessageBox.Show("未找到所选择药品的库存信息", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                return -1;
            }
            //if (m_objViewer.m_intCheckMode == 1)//广医三院模式
            //{
            DataTable m_dtbResult = null;
            DataTable m_dtbResultDetail = null;
            m_mthChangeToTotal(dtbMedicine, out m_dtbResult, out m_dtbResultDetail);
            if(m_dtbResult == null || m_dtbResult.Rows.Count == 0)
                return -1;
            int m_intRowsCount = m_dtbResult.Rows.Count;
            DataRow m_drTemp = null;
            StringBuilder sbFilter = new StringBuilder(100);
            for(int i2 = 0; i2 < m_intRowsCount; i2++)
            {
                m_drTemp = m_dtbResult.Rows[i2];
                sbFilter.Append("(MEDICINEID_CHR='");
                sbFilter.Append(m_drTemp["medicineid_chr"].ToString());
                sbFilter.Append("')");
                if(i2 != m_intRowsCount - 1)
                {
                    sbFilter.Append(" or ");
                }
            }
            DataRow[] m_drRowHas = m_objViewer.dtbDrugCheck_detail.Select(sbFilter.ToString());
            if(m_drRowHas != null && m_drRowHas.Length > 0)
            {

                if(m_drRowHas.Length == m_intRowsCount)
                {
                    MessageBox.Show("所选择药品的库存信息已存在于当前盘点记录中，不能重复添加", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_ctlQueryMedicint.Visible = true;
                    return -1;
                }
                else
                {
                    StringBuilder m_sbFilterHas = new StringBuilder(100);
                    for(int iRow = 0; iRow < m_drRowHas.Length; iRow++)
                    {
                        m_sbFilterHas.Append("(MEDICINEID_CHR='");
                        m_sbFilterHas.Append(m_drRowHas[iRow]["medicineid_chr"].ToString());
                        ;
                        m_sbFilterHas.Append("')");
                        if(iRow != m_drRowHas.Length - 1)
                        {
                            m_sbFilterHas.Append(" or ");
                        }
                    }
                    DataRow[] m_drRowDel = m_dtbResult.Select(m_sbFilterHas.ToString());
                    if(m_drRowDel != null)
                    {
                        foreach(DataRow dr in m_drRowDel)
                        {
                            m_dtbResult.Rows.Remove(dr);
                        }
                        m_mthMergeDataToUI(m_dtbResult, m_dtbResultDetail, true);
                    }
                }
            }
            else
            {
                m_mthMergeDataToUI(m_dtbResult, m_dtbResultDetail, true);
            }
            return lngReturn;
        }

        /// <summary>
        /// 将明细转换成统计
        /// </summary>
        /// <param name="p_dtbMedicine"></param>
        /// <param name="p_dtbResult"></param>
        /// <param name="p_dtbResultDetail">明细</param>//20080826 保存在盘点明细的改为库存明细信息，界面显示的是合计
        internal void m_mthChangeToTotal(DataTable p_dtbMedicine, out DataTable p_dtbResult,out DataTable p_dtbResultDetail)
        {
            p_dtbResult = null;
            p_dtbResultDetail = null;
            if (p_dtbMedicine == null || p_dtbMedicine.Rows.Count == 0) return;
            if (!p_dtbMedicine.Columns.Contains("CHECKRESULT_INT"))
            {
                p_dtbMedicine.Columns.Add("CHECKRESULT_INT", typeof(double));
            }
            p_dtbResult = p_dtbMedicine.Clone();            
            p_dtbResultDetail = p_dtbMedicine.Copy();
            p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["MEDICINEID_CHR"], p_dtbResult.Columns["opretailprice_int"] };
            
            string m_strMedicineID = string.Empty;
            double dblRetailPrice = 0d;//20090817:增加考虑不同价格的情况，不同价格的同一个药品要新增一行。
            DataRow m_drResult = null;
            for (int i1 = 0; i1 < p_dtbMedicine.Rows.Count; i1++)
            {
                if (p_dtbMedicine.Rows[i1]["MEDICINEID_CHR"].ToString() != m_strMedicineID || Convert.ToDouble(Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]).ToString("F4"))!= dblRetailPrice)//新纪录
                {
                    m_strMedicineID = p_dtbMedicine.Rows[i1]["MEDICINEID_CHR"].ToString();
                    dblRetailPrice = Convert.ToDouble(Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]).ToString("F4"));
                    m_drResult = p_dtbResult.NewRow();
                    m_drResult["MEDICINEID_CHR"] = m_strMedicineID;
                    if (m_objViewer.m_intCheckMode == 1)
                    {
                        m_drResult["LOTNO_VCHR"] = string.Empty;
                        m_drResult["indrugstoreid_vchr"] = string.Empty;
                        m_drResult["callmoney"] = 0;
                    }
                    else
                    {
                        m_drResult["LOTNO_VCHR"] = p_dtbMedicine.Rows[i1]["LOTNO_VCHR"];
                        m_drResult["indrugstoreid_vchr"] = p_dtbMedicine.Rows[i1]["indrugstoreid_vchr"];
                        m_drResult["callmoney"] = Math.Round(Convert.ToDouble(p_dtbMedicine.Rows[i1]["opcallprice_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                    }
                    m_drResult["MEDICINENAME_VCHR"] = p_dtbMedicine.Rows[i1]["MEDICINENAME_VCHR"];
                    m_drResult["assistcode_chr"] = p_dtbMedicine.Rows[i1]["assistcode_chr"];
                    m_drResult["MEDSPEC_VCHR"] = p_dtbMedicine.Rows[i1]["MEDSPEC_VCHR"];
                    m_drResult["UNIT_CHR"] = p_dtbMedicine.Rows[i1]["UNIT_CHR"];
                    m_drResult["OPUNIT_CHR"] = p_dtbMedicine.Rows[i1]["OPUNIT_CHR"];
                    m_drResult["IPUNIT_CHR"] = p_dtbMedicine.Rows[i1]["IPUNIT_CHR"];
                    m_drResult["VALIDPERIOD_DAT"] = p_dtbMedicine.Rows[i1]["VALIDPERIOD_DAT"];
                    m_drResult["PRODUCTORID_CHR"] = p_dtbMedicine.Rows[i1]["PRODUCTORID_CHR"];
                    m_drResult["RETAILPRICE_INT"] = p_dtbMedicine.Rows[i1]["RETAILPRICE_INT"];
                    //m_drResult["CALLPRICE_INT"] = 0;
                    //m_drResult["WHOLESALEPRICE_INT"] = 0;                    
                    m_drResult["medicinepreptype_chr"] = p_dtbMedicine.Rows[i1]["medicinepreptype_chr"];
                    m_drResult["medicinepreptypename_vchr"] = p_dtbMedicine.Rows[i1]["medicinepreptypename_vchr"];
                    m_drResult["balance"] = 0;
                    m_drResult["medicinetypeid_chr"] = p_dtbMedicine.Rows[i1]["medicinetypeid_chr"];
                    m_drResult["packqty_dec"] = p_dtbMedicine.Rows[i1]["packqty_dec"];
                    m_drResult["opchargeflg_int"] = p_dtbMedicine.Rows[i1]["opchargeflg_int"];
                    m_drResult["ipchargeflg_int"] = p_dtbMedicine.Rows[i1]["ipchargeflg_int"];
                    m_drResult["realgross_int"] = Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);
                    m_drResult["checkgross_int"] = Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);
                    m_drResult["iprealgross_int"] = p_dtbMedicine.Rows[i1]["iprealgross_int"];
                    m_drResult["oprealgross_int"] = p_dtbMedicine.Rows[i1]["oprealgross_int"];
                    m_drResult["ipretailprice_int"] = p_dtbMedicine.Rows[i1]["ipretailprice_int"];
                    m_drResult["opretailprice_int"] = p_dtbMedicine.Rows[i1]["opretailprice_int"];
                    m_drResult["ipcallprice_int"] = p_dtbMedicine.Rows[i1]["ipcallprice_int"];
                    m_drResult["opcallprice_int"] = p_dtbMedicine.Rows[i1]["opcallprice_int"];
                    m_drResult["dsinstoragedate_dat"] = p_dtbMedicine.Rows[i1]["dsinstoragedate_dat"];
                    //基本单位和最小单位的金额均以最小单位来计算
                    m_drResult["RETAILMONEY"] = Math.Round(Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]),8,MidpointRounding.AwayFromZero);
                    m_drResult["realmoney"] = m_drResult["RETAILMONEY"];
                    m_drResult["medicinetypename_vchr"] = p_dtbMedicine.Rows[i1]["medicinetypename_vchr"];
                    m_drResult["checkreason_vchr"] = p_dtbMedicine.Rows[i1]["checkreason_vchr"];
                    m_drResult["CHECKRESULT_INT"] = 0;
                    p_dtbResult.Rows.Add(m_drResult);

                }
                else
                {
                    m_drResult = p_dtbResult.Rows[p_dtbResult.Rows.Count - 1];                    
                    m_drResult["CHECKGROSS_INT"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["CHECKGROSS_INT"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);
                    m_drResult["realgross_int"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["realgross_int"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);
                    m_drResult["iprealgross_int"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["iprealgross_int"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]);
                    m_drResult["oprealgross_int"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["oprealgross_int"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["oprealgross_int"]);                   
                    m_drResult["RETAILMONEY"] = Math.Round(Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["RETAILMONEY"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]),8,MidpointRounding.AwayFromZero);
                    m_drResult["realmoney"] = m_drResult["RETAILMONEY"];
                    if (m_objViewer.m_intCheckMode == 0)
                    {
                        m_drResult["callmoney"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["callmoney"]) + Math.Round(Convert.ToDouble(p_dtbMedicine.Rows[i1]["opcallprice_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                    }
                }
                //p_dtbResult.AcceptChanges();
            }

            //库存明细
            for (int i1 = 0; i1 < p_dtbResultDetail.Rows.Count; i1++)
            {
                //基本单位和最小单位的金额均以最小单位来计算
                p_dtbResultDetail.Rows[i1]["RETAILMONEY"] = Math.Round(Convert.ToDouble(p_dtbResultDetail.Rows[i1]["iprealgross_int"]) * Convert.ToDouble(p_dtbResultDetail.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(p_dtbResultDetail.Rows[i1]["packqty_dec"]), 8,MidpointRounding.AwayFromZero);
                p_dtbResultDetail.Rows[i1]["realmoney"] = p_dtbResultDetail.Rows[i1]["RETAILMONEY"];
            }
            //p_dtbResultDetail.AcceptChanges();
        }
        #endregion

        #region 将库存药品信息合并至界面
        /// <summary>
        /// 将库存药品信息合并至界面
        /// </summary>
        /// <param name="p_dtbStorageMedicine">库存药品信息</param>
        /// <param name="p_dtbResultDetail">库存明细</param>
        /// <param name="p_blnManMake">是否手动添加的记录</param>
        internal void m_mthMergeDataToUI(DataTable p_dtbStorageMedicine,DataTable p_dtbResultDetail,bool p_blnManMake)
        {
            if (p_dtbStorageMedicine == null || p_dtbStorageMedicine.Rows.Count == 0)
            {
                return;
            }

            int intRowCount = p_dtbStorageMedicine.Rows.Count;

            //try
            //{
                //去除空行
                DataRow[] drNull = m_objViewer.dtbDrugCheck_detail.Select("MEDICINEID_CHR is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow dr in drNull)
                    {
                        m_objViewer.dtbDrugCheck_detail.Rows.Remove(dr);
                    }
                }

                DataTable dtbDetailCopy = m_objViewer.dtbDrugCheck_detail.Copy();//获取界面数据的拷贝

                if (m_objViewer.m_intCheckMode == 1)
                {
                    dtbDetailCopy.PrimaryKey = new DataColumn[] { dtbDetailCopy.Columns["MEDICINEID_CHR"] };
                }
                else
                {
                    dtbDetailCopy.PrimaryKey = new DataColumn[] { dtbDetailCopy.Columns["MEDICINEID_CHR"], dtbDetailCopy.Columns["LOTNO_VCHR"], dtbDetailCopy.Columns["indrugstoreid_vchr"] };
                }
                //dtbDetailCopy.AcceptChanges();

                DataTable dtbGetMedicine = m_objViewer.dtbDrugCheck_detail.Clone();
                dtbGetMedicine.BeginLoadData();
                DataRow drCurrent = null;
                DateTime dtmNow = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
                double dblTemp = 0;
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = p_dtbStorageMedicine.Rows[iRow];
                    DataRow drNew = dtbGetMedicine.NewRow();

                    drNew["medicinetypeid_chr"] = drCurrent["medicinetypeid_chr"].ToString();
                    drNew["MEDICINEID_CHR"] = drCurrent["MEDICINEID_CHR"].ToString();
                    drNew["MEDICINENAME_VCHR"] = drCurrent["medicinename_vchr"].ToString();
                    drNew["assistcode_chr"] = drCurrent["assistcode_chr"].ToString();
                    drNew["MEDSPEC_VCHR"] = drCurrent["MEDSPEC_VCHR"].ToString();
                    drNew["UNIT_CHR"] = drCurrent["unit_chr"].ToString();
                    drNew["OPUNIT_CHR"] = drCurrent["opunit_chr"].ToString();
                    drNew["IPUNIT_CHR"] = drCurrent["ipunit_chr"].ToString();
                    if (drCurrent["LOTNO_VCHR"].ToString() == "")
                    {
                        drNew["LOTNO_VCHR"] = "UNKNOWN";
                    }
                    else
                    {
                        drNew["LOTNO_VCHR"] = drCurrent["LOTNO_VCHR"].ToString();
                    }
                    drNew["VALIDPERIOD_DAT"] = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd");
                    drNew["PRODUCTORID_CHR"] = drCurrent["productorid_chr"].ToString();
                    drNew["packqty_dec"] = Convert.ToDouble(drCurrent["packqty_dec"]);
                    drNew["opchargeflg_int"] = drCurrent["opchargeflg_int"];
                    drNew["ipchargeflg_int"] = drCurrent["ipchargeflg_int"];

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

                    //if (m_objViewer.m_intCheckMode == 1)
                    //{
                    //    //if (double.TryParse(drCurrent["callmoney"].ToString(), out dblTemp))
                    //    //{
                    //    //    drNew["callmoney"] = dblTemp.ToString("0.0000");
                    //    //}
                    //    //else
                    //    //{
                    //    drNew["callmoney"] = 0;
                    //    //}
                    //    if (double.TryParse(drCurrent["RETAILMONEY"].ToString(), out dblTemp))
                    //    {
                    //        drNew["RETAILMONEY"] = dblTemp.ToString("0.0000");
                    //    }
                    //    else
                    //    {
                    //        drNew["RETAILMONEY"] = 0;
                    //    }
                    //    if (double.TryParse(drCurrent["realmoney"].ToString(), out dblTemp))
                    //    {
                    //        drNew["realmoney"] = dblTemp.ToString("0.0000");
                    //    }
                    //    else
                    //    {
                    //        drNew["realmoney"] = 0;
                    //    }

                    //    drNew["realgross_int"] = drCurrent["realgross_int"];
                    //    drNew["CHECKGROSS_INT"] = drCurrent["CHECKGROSS_INT"];
                    //    drNew["RETAILPRICE_INT"] = drCurrent["retailprice_int"];
                    //    //drNew["CALLPRICE_INT"] = drCurrent["wholesaleprice_int"];
                    //    //drNew["WHOLESALEPRICE_INT"] = drCurrent["wholesaleprice_int"];                        

                    //}
                    //else//默认模式
                    //{
                        drNew["realgross_int"] = drCurrent["realgross_int"].ToString().Length == 0 ? 0 : Math.Round(Convert.ToDouble(drCurrent["realgross_int"]), 2, MidpointRounding.AwayFromZero);
                        drNew["CHECKGROSS_INT"] = drCurrent["realgross_int"].ToString().Length == 0 ? 0 : Math.Round(Convert.ToDouble(drCurrent["realgross_int"]), 2, MidpointRounding.AwayFromZero);
                        drNew["RETAILPRICE_INT"] = Math.Round(Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);
                        drNew["RETAILMONEY"] = drCurrent["RETAILMONEY"];//drCurrent["realgross_int"].ToString().Length == 0 ? 0 : Math.Round(Convert.ToDouble(drCurrent["realgross_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 8, MidpointRounding.AwayFromZero);
                        drNew["realmoney"] = drCurrent["realmoney"];//drCurrent["realgross_int"].ToString().Length == 0 ? 0 : Math.Round(Convert.ToDouble(drCurrent["realgross_int"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 8, MidpointRounding.AwayFromZero);

                        drNew["callmoney"] = drCurrent["realgross_int"].ToString().Length == 0 ? 0 : Math.Round((Convert.ToDouble(drCurrent["realgross_int"]) * Convert.ToDouble(drCurrent["opcallprice_int"]) / Convert.ToDouble(drCurrent["packqty_dec"])), 8, MidpointRounding.AwayFromZero);
                        drNew["CALLPRICE_INT"] = drCurrent["callprice_int"].ToString().Length == 0 ? 0 : Math.Round(Convert.ToDouble(drCurrent["callprice_int"]), 4, MidpointRounding.AwayFromZero);
                    //}
                    drNew["STATUS_INT"] = 1;
                    drNew["indrugstoreid_vchr"] = drCurrent["indrugstoreid_vchr"].ToString();
                    drNew["medicinepreptypename_vchr"] = drCurrent["medicinepreptypename_vchr"].ToString();
                    drNew["medicinepreptype_chr"] = drCurrent["medicinepreptype_chr"].ToString();
                    drNew["balance"] = 0;

                    drNew["ipcheckgross_int"] = Convert.ToDouble(drCurrent["iprealgross_int"]) % Convert.ToDouble(drCurrent["packqty_dec"]);
                    drNew["opcheckgross_int"] = (int)(Convert.ToDouble(drCurrent["iprealgross_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]));
                    drNew["iprealgross_int"] = Convert.ToDouble(drCurrent["iprealgross_int"]) % Convert.ToDouble(drCurrent["packqty_dec"]);
                    drNew["oprealgross_int"] = (int)(Convert.ToDouble(drCurrent["iprealgross_int"]) / Convert.ToDouble(drCurrent["packqty_dec"]));
                    drNew["ipcheckresult_int"] = 0;
                    drNew["opcheckresult_int"] = 0;

                    drNew["ipretailprice_int"] = drCurrent["ipretailprice_int"];
                    drNew["opretailprice_int"] = drCurrent["opretailprice_int"];
                    drNew["ipcallprice_int"] = drCurrent["ipcallprice_int"];
                    drNew["opcallprice_int"] = drCurrent["opcallprice_int"];
                    drNew["dsinstoragedate_dat"] = drCurrent["dsinstoragedate_dat"];
                    drNew["medicinetypename_vchr"] = drCurrent["medicinetypename_vchr"].ToString();
                    drNew["checkreason_vchr"] = drCurrent["checkreason_vchr"].ToString();
                    dtbGetMedicine.LoadDataRow(drNew.ItemArray, false);
                }
                dtbGetMedicine.EndLoadData();

                dtbDetailCopy.AcceptChanges();

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

                    m_objViewer.dtbDrugCheck_detail.BeginLoadData();
                    for (int iRow = 0; iRow < dtbGetNewMedicine.Rows.Count; iRow++)
                    {
                        m_objViewer.dtbDrugCheck_detail.LoadDataRow(dtbGetNewMedicine.Rows[iRow].ItemArray, false);
                    }
                    m_objViewer.dtbDrugCheck_detail.EndLoadData();
                }

                if (m_objViewer.m_intCheckMode != 0)
                {
                    if (m_objViewer.dtbDrugCheck_TrueDetail == null)
                    {
                        m_objViewer.dtbDrugCheck_TrueDetail = p_dtbResultDetail.Clone();
                        m_objViewer.dtbDrugCheck_TrueDetail.Columns.Add("SERIESID_INT", typeof(System.Int64));
                    }
                    for (int i1 = 0; i1 < p_dtbResultDetail.Rows.Count; i1++)
                    {
                        m_objViewer.dtbDrugCheck_TrueDetail.Rows.Add(p_dtbResultDetail.Rows[i1].ItemArray);
                    }
                }
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
            //finally
            //{
            //    m_objViewer.m_lblMedicineType.Text = m_strShowMedicineType(m_objViewer.dtbDrugCheck_detail);
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
            if (m_objCurrentMain != null)//检查盘点单状态
            {
                int intStatus = -1;
                clsDcl_DrugStoreCheck objDom = new clsDcl_DrugStoreCheck();
                objDom.m_lngCheckStatus(2, m_objCurrentMain.m_lngSERIESID_INT, out intStatus);
                if (intStatus == 3)
                {
                    MessageBox.Show("该药房盘点记录已入帐，不能修改", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (intStatus == 2)
                {
                    MessageBox.Show("该药房盘点记录已审核，不能修改", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (intStatus == -1)
                {
                    MessageBox.Show("该药房盘点记录已删除，不能修改", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            //去除空行
            DataRow[] drNull = m_objViewer.dtbDrugCheck_detail.Select("MEDICINEID_CHR is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    m_objViewer.dtbDrugCheck_detail.Rows.Remove(dr);
                }
            }

            if (m_objViewer.m_dgvDetailInfo.Rows.Count == 0)
            {
                MessageBox.Show("请先录入盘点药品", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            DataTable dtbTempIn;
            if (m_objViewer.m_intAllowNegativeStorage == 0)
            {
                dtbTempIn = m_objViewer.dtbDrugCheck_detail.Copy();
                //如果出现有库存数量为负数的药品，则提示用户并限制不允许保存盘点表 20080602
                DataView dvTemp = dtbTempIn.DefaultView;
                dvTemp.RowFilter = "CHECKGROSS_INT < 0";// or realgross_int < 0";
                dtbTempIn = dvTemp.ToTable();
                if (dtbTempIn.Rows.Count > 0)
                {
                    return -2;
                }
            }

            //if (m_objViewer.m_intCheckMode == 1)
            //{
                //“暂调入库“的金额为零才允许保存，否则不允许保存盘点表       
            string m_strIsAllow = this.m_objViewer.objController.m_objComInfo.m_lonGetModuleInfo("5047");
            if (m_strIsAllow == "0")
            {
                DateTime m_dtmStartDate = DateTime.MinValue;
                DateTime m_dtmEndDate = DateTime.MinValue;
                bool m_blnExist = false;
                m_objDomain.m_lngGetCurrentAccountDate(m_objViewer.m_strStoreDeptID, out m_dtmStartDate, out m_dtmEndDate);
                m_objDomain.m_lngCheckExistTempIn(m_objViewer.m_strStoreDeptID, m_dtmStartDate, m_dtmEndDate, out m_blnExist);
                if (m_blnExist)
                {
                    return -4;
                }
            }
            //}

            //如果有业务单据未审核，不允许其保存盘点表
            //20090625:改为只有有值就不允许保存，不再加上当前单据的药品进行比较。
            //20090828: 增加判断是否存在药库已审核但药房未审核的请领单
            DataTable dtbTempOut;
            DataTable dtbAsk;
            m_objDomain.m_lngCheckUnAuditData(m_objViewer.m_strStoreDeptID, out dtbTempIn, out dtbTempOut,out dtbAsk);
            if (dtbTempIn != null && dtbTempIn.Rows.Count > 0)
            {
                return -3;
            }
            if (dtbTempOut != null && dtbTempOut.Rows.Count > 0)
            {
                return -3;
            }
            if (dtbAsk != null && dtbAsk.Rows.Count > 0)
            {
                return -5;
            }
           

            long lngRes = 0;
            try
            {                
                long lngMainSeq = 0;//主表序列
                bool blnIsAddNewCheck = m_objViewer.m_lngMainSEQ == 0;//是否新初始化盘点单

                clsDS_Check_VO objMain = GetObjMain();

                //20090824:将每次保存均改为删除再新增，确保程序万无一失
                //DataTable dtbModify = m_objViewer.dtbDrugCheck_detail.GetChanges(DataRowState.Modified);//修改过的记录
                clsDS_StorageCheckDetail_VO[] objModifyDetaiArr = null;// m_objDetailArr(dtbModify, lngMainSeq);

                long[] lngSubSEQ = null;
                DataRow[] drNew = m_objViewer.dtbDrugCheck_detail.Select();// ("SERIESID_INT is null");

                clsDS_StorageCheckDetail_VO[] objNewDetailArr = m_objDetailArr(drNew, lngMainSeq); 

                lngRes = m_objDomain.m_lngSaveStorageCheck(ref objMain, objModifyDetaiArr, objNewDetailArr,
                objMain.m_strASKERID_CHR, m_objViewer.m_strStoreDeptID, blnIsAddNewCheck,m_objViewer.m_blnIsHospital,m_strCommit, out lngSubSEQ);

                if (lngRes > 0)
                {
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtBillId.Text = objMain.m_strCHECKID_CHR;
                    lngMainSeq = objMain.m_lngSERIESID_INT;
                    m_objCurrentMain = objMain;
                    if (objMain.m_intSTATUS_INT != 1)
                    {
                        m_objViewer.m_btnSave.Enabled = false;
                        m_objViewer.m_btnDelete.Enabled = false;
                        //m_objViewer.m_btnFilterMed.Enabled = false;
                        m_objViewer.m_btnModify.Enabled = false;
                        m_objViewer.m_btnMissMedicine.Enabled = false;
                        m_objViewer.m_dgvDetailInfo.ReadOnly = true;
                        m_objViewer.m_btnImpMedicine.Enabled = false;
                    }

                    //没必要执行下面这个费时的操作了。
                    //if (m_objViewer.m_intCheckMode != 0)
                    //{
                    //    DataRow[] drNewDetail = m_objViewer.dtbDrugCheck_TrueDetail.Select("SERIESID_INT is null");
                    //    if (lngSubSEQ != null && drNewDetail != null && lngSubSEQ.Length == drNewDetail.Length)
                    //    {
                    //        for (int iSEQ = 0; iSEQ < lngSubSEQ.Length; iSEQ++)
                    //        {
                    //            drNewDetail[iSEQ]["SERIESID_INT"] = lngSubSEQ[iSEQ];
                    //            for (int i2 = 0; i2 < drNew.Length; i2++)
                    //            {
                    //                if (drNew[i2]["medicineid_chr"].ToString() == drNewDetail[iSEQ]["medicineid_chr"].ToString())
                    //                {
                    //                    drNew[i2]["SERIESID_INT"] = lngSubSEQ[iSEQ];
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    if (lngSubSEQ != null && drNew != null && lngSubSEQ.Length == drNew.Length)
                    //    {
                    //        for (int iSEQ = 0; iSEQ < lngSubSEQ.Length; iSEQ++)
                    //        {
                    //            drNew[iSEQ]["SERIESID_INT"] = lngSubSEQ[iSEQ];
                    //        }
                    //    }
                    //}

                    m_objViewer.dtbDrugCheck_detail.AcceptChanges();
                }
                else
                {
                    if (m_objViewer.intShowType == 0)
                    {
                        m_objCurrentMain.m_intSTATUS_INT = 1;
                        m_objViewer.timer1.Start();
                    }
                }                
            }
            catch(Exception ex)
            {                
                m_objCurrentMain.m_intSTATUS_INT = 1;
                m_objViewer.m_datCheck.Value = clsPub.CurrentDateTimeNow;
                m_objViewer.timer1.Start();
                MessageBox.Show(ex.Message);
            }
            return lngRes;
        }
        #endregion

        #region 获取当前主记录
        /// <summary>
        /// 获取当前主记录
        /// </summary>
        /// <returns></returns>
        private clsDS_Check_VO GetObjMain()
        {
            if (m_objCurrentMain == null || m_objViewer.intShowType == 0)
            {
                m_objCurrentMain = new clsDS_Check_VO();
                m_objCurrentMain.m_dtmASKDATE_DAT = m_objViewer.m_datCheck.Value;//Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));                
               m_objCurrentMain.m_intSTATUS_INT =this.m_strCommit=="1"?2:1;      //保存即审核          
              //  m_objCurrentMain.m_intSTATUS_INT = 1; 
            }

            m_objCurrentMain.m_lngSERIESID_INT = m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strCHECKID_CHR = m_objViewer.m_txtBillId.Text;
            m_objCurrentMain.m_strDRUGSTOREID_CHR = m_objViewer.m_strStoreDeptID;
            if (m_objViewer.m_txtMaker.Tag != null)
            {
                m_objCurrentMain.m_strASKERID_CHR = m_objViewer.m_txtMaker.Tag.ToString();
            }
            else
            {
                m_objCurrentMain.m_strASKERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            }
            if (this.m_strCommit == "1")
            {
                m_objCurrentMain.m_strEXAMERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                this.m_objCurrentMain.m_dtmEXAMDATE_DAT = m_objViewer.m_datCheck.Value;// clsPub.CurrentDateTimeNow;
            }
            m_objCurrentMain.m_dtmCHECKDATE_DAT = m_objViewer.m_datCheck.Value;// Convert.ToDateTime(m_objViewer.m_datCheck.Text);
            m_objViewer.timer1.Stop();
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
        private clsDS_StorageCheckDetail_VO[] m_objDetailArr(DataTable p_dtbData, long p_lngMainSEQ)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            List<clsDS_StorageCheckDetail_VO> lstDetail = new List<clsDS_StorageCheckDetail_VO>();
            DateTime dtmNow = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
            string strMedicineID = string.Empty;
            DataRow drTemp = null;
            if (m_objViewer.m_intCheckMode != 0)
            {
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = p_dtbData.Rows[iRow];                        
                    clsDS_StorageCheckDetail_VO objDetail = m_objDetail(drTemp, dtmNow, p_lngMainSEQ);
                    if (objDetail != null)
                    {
                        lstDetail.Add(objDetail);
                    }
                }
            }
            else
            {
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {

                    strMedicineID = Convert.ToString(p_dtbData.Rows[iRow]["medicineid_chr"]);
                    for (int i2 = 0; i2 < m_objViewer.dtbDrugCheck_detail.Rows.Count; i2++)
                    {
                        //drTemp = m_objViewer.dtbDrugCheck_TrueDetail.Rows[i2];dtbDrugCheck_detail
                        drTemp = m_objViewer.dtbDrugCheck_detail.Rows[i2];
                        if (Convert.ToString(drTemp["medicineid_chr"]) == strMedicineID)
                        {
                            clsDS_StorageCheckDetail_VO objDetail = m_objDetail(drTemp, dtmNow, p_lngMainSEQ);
                            if (objDetail != null)
                            {
                                lstDetail.Add(objDetail);
                            }
                        }
                    }
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
        private clsDS_StorageCheckDetail_VO[] m_objDetailArr(DataRow[] p_drDataArr, long p_lngMainSEQ)
        {
            if (p_drDataArr == null || p_drDataArr.Length == 0)
            {
                return null;
            }

            List<clsDS_StorageCheckDetail_VO> lstDetail = new List<clsDS_StorageCheckDetail_VO>();
            DateTime dtmNow = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
            string strMedicineID;
            DataRow[] drTemp = null;
            if (m_objViewer.m_intCheckMode == 0)
            {
                foreach (DataRow dr in p_drDataArr)
                {
                    clsDS_StorageCheckDetail_VO objDetail = m_objDetail(dr, dtmNow, p_lngMainSEQ);
                    if (objDetail != null)
                    {
                        lstDetail.Add(objDetail);
                    }
                }                   
            }
            else
            {
                for (int iRow = 0; iRow < p_drDataArr.Length; iRow++)
                {
                    strMedicineID = Convert.ToString(p_drDataArr[iRow]["medicineid_chr"]);
                    drTemp = m_objViewer.dtbDrugCheck_TrueDetail.Select("medicineid_chr = '" + strMedicineID + "'");
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        foreach (DataRow dr in drTemp)
                        {
                            dr["CHECKREASON_VCHR"] = p_drDataArr[iRow]["CHECKREASON_VCHR"];
                            clsDS_StorageCheckDetail_VO objDetail = m_objDetail(dr, dtmNow, p_lngMainSEQ);
                            if (objDetail != null)
                            {
                                lstDetail.Add(objDetail);
                            }
                        }
                    }
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
        private clsDS_StorageCheckDetail_VO m_objDetail(DataRow p_drData, DateTime p_dtmModifyDate, long p_lngMainSEQ)
        {
            if (p_drData == null)
            {
                return null;
            }

            DateTime dtmTemp = DateTime.MinValue;
            long lngTemp = 0;

            
            clsDS_StorageCheckDetail_VO objValue = new clsDS_StorageCheckDetail_VO();
            try
            {   
                //if (m_objViewer.m_blnIsHospital)
                //{
                //    if (Convert.ToInt16(p_drData["ipchargeflg_int"]) == 0)
                //    {
                //        objValue.m_dblCALLPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
                //        objValue.m_dblCURRENTGROSS_INT = Convert.ToDouble(p_drData["oprealgross_int"]);
                //        objValue.m_dblWHOLESALEPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
                //        objValue.m_dblCHECKGROSS_INT = Convert.ToDouble(p_drData["oprealgross_int"]);
                //    }
                //    else
                //    {
                //        objValue.m_dblCALLPRICE_INT = Convert.ToDouble(p_drData["ipcallprice_int"]);
                //        objValue.m_dblCURRENTGROSS_INT = Convert.ToDouble(p_drData["iprealgross_int"]);
                //        objValue.m_dblWHOLESALEPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
                //        objValue.m_dblCHECKGROSS_INT = Convert.ToDouble(p_drData["iprealgross_int"]);
                //    }
                //}
                //else
                //{
                //    if (Convert.ToInt16(p_drData["opchargeflg_int"]) == 0)
                //    {
                //        objValue.m_dblCALLPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
                //        objValue.m_dblCURRENTGROSS_INT = Convert.ToDouble(p_drData["oprealgross_int"]);
                //        objValue.m_dblWHOLESALEPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
                //        objValue.m_dblCHECKGROSS_INT = Convert.ToDouble(p_drData["oprealgross_int"]);
                //    }
                //    else
                //    {
                //        objValue.m_dblCALLPRICE_INT = Convert.ToDouble(p_drData["ipcallprice_int"]);
                //        objValue.m_dblCURRENTGROSS_INT = Convert.ToDouble(p_drData["iprealgross_int"]);
                //        objValue.m_dblWHOLESALEPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
                //        objValue.m_dblCHECKGROSS_INT = Convert.ToDouble(p_drData["iprealgross_int"]);
                //    }
                //}

                objValue.m_dblPACKQTY_DEC = Convert.ToDouble(p_drData["packqty_dec"]);
                
                if (m_objViewer.m_intCheckMode == 1)
                {
                    double dblOPTemp = p_drData["oprealgross_int"] == null ? 0 : Convert.ToDouble(p_drData["oprealgross_int"]);
                    double dblIPTemp = p_drData["iprealgross_int"] == null ? 0 : Convert.ToDouble(p_drData["iprealgross_int"]);
                    objValue.m_dblIPREALGROSS_INT = dblIPTemp % objValue.m_dblPACKQTY_DEC;
                    objValue.m_dblOPREALGROSS_INT = (int)(dblIPTemp / objValue.m_dblPACKQTY_DEC);
                    objValue.m_dblIPCHECKGROSS_INT = objValue.m_dblIPREALGROSS_INT;
                    objValue.m_dblOPCHECKGROSS_INT = objValue.m_dblOPREALGROSS_INT;
                    objValue.m_dblIPCHECKRESULT_INT = 0;//盘盈盘亏数量
                    objValue.m_dblOPCHECKRESULT_INT = 0;
                }
                else
                {
                    objValue.m_dblIPREALGROSS_INT = p_drData["iprealgross_int"] == null ? 0 : Convert.ToDouble(p_drData["iprealgross_int"]);
                    objValue.m_dblOPREALGROSS_INT = p_drData["oprealgross_int"] == null ? 0 : Convert.ToDouble(p_drData["oprealgross_int"]);
                    objValue.m_dblIPCHECKGROSS_INT = Convert.ToDouble(p_drData["ipcheckgross_int"]);
                    objValue.m_dblOPCHECKGROSS_INT = Convert.ToDouble(p_drData["opcheckgross_int"]);
                    objValue.m_dblIPCHECKRESULT_INT = Convert.ToDouble(p_drData["ipcheckresult_int"]);//盘盈盘亏数量
                    objValue.m_dblOPCHECKRESULT_INT = Convert.ToDouble(p_drData["opcheckresult_int"]);
                }
                
                
                objValue.m_dtmMODIFYDATE_DAT = Convert.ToDateTime(p_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (DateTime.TryParse(p_drData["VALIDPERIOD_DAT"].ToString(), out dtmTemp))
                {
                    objValue.m_dtmVALIDPERIOD_DAT = dtmTemp;
                }
                if (objValue.m_dblIPCHECKRESULT_INT == 0 && objValue.m_dblOPCHECKRESULT_INT == 0)
                {
                    objValue.m_intISZERO_INT = 0;
                }
                else
                {
                    objValue.m_intISZERO_INT = 1;
                }
                
                objValue.m_intSTATUS_INT = 1;
               
                if (long.TryParse(p_drData["SERIESID_INT"].ToString(), out lngTemp))
                {
                    objValue.m_lngSERIESID_INT = lngTemp;
                }
                objValue.m_lngSERIESID2_INT = p_lngMainSEQ;
                objValue.m_strCHECKREASON_VCHR = p_drData["CHECKREASON_VCHR"].ToString();
                if (p_drData["indrugstoreid_vchr"] != null)
                {
                    objValue.m_strINDRUGSTOREID_VCHR = p_drData["indrugstoreid_vchr"].ToString();// p_drData["indrugstoreid_vchr"].ToString();
                }
                if (p_drData["LOTNO_VCHR"].ToString() == "")
                {
                    objValue.m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objValue.m_strLOTNO_VCHR = p_drData["LOTNO_VCHR"].ToString();
                }
                objValue.m_strMedicineCode = p_drData["MEDICINEID_CHR"].ToString();
                objValue.m_strMEDICINENAME_VCHR = p_drData["MEDICINENAME_VCHR"].ToString();
                objValue.m_strMEDSPEC_VCHR = p_drData["MEDSPEC_VCHR"].ToString();
                objValue.m_strMODIFIER_CHR = m_objViewer.LoginInfo.m_strEmpID;
                objValue.m_strOPUNIT_CHR = p_drData["OPUNIT_CHR"].ToString();
                objValue.m_strIPUNIT_CHR = p_drData["IPUNIT_CHR"].ToString();
                objValue.m_strUNIT_CHR = p_drData["UNIT_CHR"].ToString();
                objValue.m_strPRODUCTORID_CHR = p_drData["PRODUCTORID_CHR"].ToString();
                
                objValue.m_dblOPCHARGEFLG_INT = Convert.ToDouble(p_drData["opchargeflg_int"]);
                objValue.m_dblIPCHARGEFLG_INT = Convert.ToDouble(p_drData["ipchargeflg_int"]);
                
                objValue.m_dblIPRETAILPRICE_INT = p_drData["ipretailprice_int"] == null ? 0 : Convert.ToDouble(p_drData["ipretailprice_int"]);
                objValue.m_dblOPRETAILPRICE_INT = p_drData["opretailprice_int"] == null ? 0 : Convert.ToDouble(p_drData["opretailprice_int"]);
                objValue.m_dblIPCALLPRICE_INT = p_drData["ipcallprice_int"] == null ? 0 : Convert.ToDouble(p_drData["ipcallprice_int"]);
                objValue.m_dblOPCALLPRICE_INT = p_drData["opcallprice_int"] == null ? 0 : Convert.ToDouble(p_drData["opcallprice_int"]);
                if (DateTime.TryParse(p_drData["dsinstoragedate_dat"].ToString(), out dtmTemp))
                {
                    objValue.m_dtmDSINSTORAGEDATE_DAT = dtmTemp;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return objValue;
        }
        #endregion

        #region 获取药品基本信息表
        /// <summary>
        /// 获取药品基本信息表
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthGetMedBaseInfo(string m_strMedStoreid,ref DataTable p_dtbMedicineInfo)
        {
            clsDcl_AskForMedDetail m_objDomain = new clsDcl_AskForMedDetail();
            m_objDomain.m_lngGetMedicineInfo(m_strMedStoreid,out p_dtbMedicineInfo);        
        }
        #endregion

        /// <summary>
        /// 初始化
        /// </summary>
        internal void m_mthLoad()
        {
            if (m_objViewer.intShowType == 0)
            {
                m_mthInitDataTable();
                //m_objViewer.m_datCheck.Text = clsPub.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
                m_objViewer.m_datCheck.Value = clsPub.ServerDateTimeNow;//取服务器时间而非界面时间
                m_objViewer.timer1.Start();
            }

            if (m_objViewer.m_objMain != null)
            {
                m_objViewer.m_datCheck.Text = m_objViewer.m_objMain.m_dtmCHECKDATE_DAT.ToString("yyyy年MM月dd日 HH:mm:ss");
                m_objViewer.m_txtBillId.Text = m_objViewer.m_objMain.m_strCHECKID_CHR;
                m_objViewer.m_txtMaker.Tag = m_objViewer.m_objMain.m_strASKERID_CHR;
                m_objViewer.m_txtMaker.Text = m_objViewer.m_objMain.m_strASKERNAME_VCHR;

                if (m_objViewer.m_objMain.m_intSTATUS_INT != 1)
                {
                    m_objViewer.m_btnSave.Enabled = false;
                    m_objViewer.m_btnDelete.Enabled = false;
                    //m_objViewer.m_btnFilterMed.Enabled = false;
                    m_objViewer.m_btnModify.Enabled = false;
                    m_objViewer.m_btnMissMedicine.Enabled = false;
                    m_objViewer.m_dgvDetailInfo.ReadOnly = true;
                    m_objViewer.m_btnImpMedicine.Enabled = false;
                }
                m_objViewer.m_lngMainSEQ = m_objViewer.m_objMain.m_lngSERIESID_INT;
                m_objCurrentMain = m_objViewer.m_objMain;
            }

            /*
            if (m_objViewer.intShowType == 1)
            {
                try
                {  
                    DataRow drRow = null;
                    for (int i1 = 0; i1 < m_objViewer.dtbDrugCheck_detail.Rows.Count; i1++)
                    {
                        drRow = m_objViewer.dtbDrugCheck_detail.Rows[i1];
                        //盈亏金额
                        drRow["balance"] = Math.Round((Convert.ToDouble(drRow["opcheckresult_int"]) * Convert.ToDouble(drRow["packqty_dec"]) + Convert.ToDouble(drRow["ipcheckresult_int"])) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                        //购入金额
                        drRow["callmoney"] = Math.Round((Convert.ToDouble(drRow["opcheckgross_int"]) * Convert.ToDouble(drRow["packqty_dec"]) + Convert.ToDouble(drRow["ipcheckgross_int"])) * Convert.ToDouble(drRow["opcallprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                        //帐面零售金额
                        drRow["retailmoney"] = Math.Round((Convert.ToDouble(drRow["oprealgross_int"]) * Convert.ToDouble(drRow["packqty_dec"]) + Convert.ToDouble(drRow["iprealgross_int"])) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                        //实盘零售金额
                        drRow["realmoney"] = Math.Round((Convert.ToDouble(drRow["opcheckgross_int"]) * Convert.ToDouble(drRow["packqty_dec"]) + Convert.ToDouble(drRow["ipcheckgross_int"])) * Convert.ToDouble(drRow["opretailprice_int"]) / Convert.ToDouble(drRow["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                    }                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }

                //m_objViewer.dtbDrugCheck_detail.AcceptChanges();
            }
             */ 
            m_objViewer.m_dgvDetailInfo.DataSource = m_objViewer.dtbDrugCheck_detail;

            DataRow drNew = m_objViewer.dtbDrugCheck_detail.NewRow();

            if (m_objViewer.dtbDrugCheck_detail.Rows.Count <= 0)
            {
                m_objViewer.dtbDrugCheck_detail.Rows.Add(drNew);
            }
            

            m_objViewer.m_dgvDetailInfo.Refresh();
            m_objViewer.m_lblMedicineType.Text = m_strShowMedicineType(m_objViewer.dtbDrugCheck_detail);
        }

        /// <summary>
        /// 初始化数据源
        /// </summary>
        internal void m_mthInitDataTable()
        {
            m_objViewer.dtbDrugCheck_detail = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"),new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCHR"), new DataColumn("assistcode_chr"),new DataColumn("MEDSPEC_VCHR"),
                new DataColumn("UNIT_CHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("IPUNIT_CHR"),new DataColumn("LOTNO_VCHR"),new DataColumn("VALIDPERIOD_DAT",typeof(DateTime)),new DataColumn("realgross_int",typeof(double)), new DataColumn("CHECKGROSS_INT",typeof(double)),new DataColumn("PRODUCTORID_CHR"),
                new DataColumn("RETAILPRICE_INT",typeof(double)), new DataColumn("CALLPRICE_INT",typeof(double)),new DataColumn("CHECKREASON_VCHR"),new DataColumn("CHECKRESULT_INT",typeof(double)),new DataColumn("ISZERO_INT"),
                new DataColumn("MODIFIER_CHR"),new DataColumn("MODIFYDATE_DAT"), new DataColumn("STATUS_INT"),new DataColumn("indrugstoreid_vchr"),new DataColumn("checkmedicineorder_chr"),new DataColumn("medicinepreptype_chr"),new DataColumn("medicinetypename_vchr"),
                new DataColumn("medicinepreptypename_vchr"),new DataColumn("balance"),new DataColumn("callmoney"),new DataColumn("RETAILMONEY",typeof(double)), new DataColumn("storagerackcode_vchr"),new DataColumn("medicinetypeid_chr"), new DataColumn("SERIESID2_INT"),
                new DataColumn("packqty_dec"),new DataColumn("opchargeflg_int",typeof(double)),new DataColumn("iprealgross_int",typeof(double)),new DataColumn("oprealgross_int",typeof(double)),new DataColumn("ipretailprice_int"),new DataColumn("opretailprice_int",typeof(double)),new DataColumn("realmoney",typeof(double)),
                new DataColumn("ipcallprice_int",typeof(double)),new DataColumn("opcallprice_int",typeof(double)),new DataColumn("dsinstoragedate_dat",typeof(DateTime)),new DataColumn("ipchargeflg_int",typeof(double)),new DataColumn("OPCHECKGROSS_INT",typeof(double)),new DataColumn("IPCHECKGROSS_INT",typeof(double)),
            new DataColumn("ipcheckresult_int",typeof(double)),new DataColumn("opcheckresult_int",typeof(double))};
            m_objViewer.dtbDrugCheck_detail.Columns.AddRange(dcColumns);
            
            //m_objViewer.dtbDrugCheck_detail.Columns["realmoney"].Expression = "RETAILMONEY";//实盘金额
            //if (m_objViewer.m_intCheckMode == 0)
            //{
            //    m_objViewer.dtbDrugCheck_detail.Columns["balance"].Expression = "CHECKRESULT_INT * retailprice_int";
            //    m_objViewer.dtbDrugCheck_detail.Columns["callmoney"].Expression = "checkgross_int * wholesaleprice_int";
            //    m_objViewer.dtbDrugCheck_detail.Columns["RETAILMONEY"].Expression = "checkgross_int * retailprice_int";
            //}
        }

        #region 从网格导出数据到Excel
        /// <summary>
        /// 从网格导出数据到Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
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
                //添加列标题
                for (int iOr = 0; iOr < m_objViewer.m_dgvDetailInfo.ColumnCount; iOr++)
                {
                    if (m_objViewer.m_dgvDetailInfo.Columns[iOr].Visible == false) continue;
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dgvDetailInfo.Columns[iOr].HeaderText.Replace("\n", "");
                }
                sw.WriteLine(str);
                //添加行文本
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvDetailInfo.Rows.Count; iOr++)
                {
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dgvDetailInfo.Columns.Count; jOr++)
                    {
                        if (m_objViewer.m_dgvDetailInfo.Columns[jOr].Visible == false) continue;
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        objStrBuilder.Append(m_objViewer.m_dgvDetailInfo.Rows[iOr].Cells[jOr].Value == null ? "" : m_objViewer.m_dgvDetailInfo.Rows[iOr].Cells[jOr].Value.ToString());
                    }
                    sw.WriteLine(objStrBuilder);
                }
                MessageBox.Show("导出成功！", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion

        #region 获取盘点模式，0为默认，1为广医三院
        /// <summary>
        /// #region 获取盘点模式，0为默认，1为广医三院
        /// </summary>
        /// <param name="p_intCheckMode">盘点模式</param>
        internal void m_mthGetCheckMode(out int p_intCheckMode)
        {
            m_objDomain.m_mthGetCheckMode(out p_intCheckMode);
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
            frmCheckRep.m_blnUseByDS = true;
            frmCheckRep.datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            
            if (m_strPrintFormat == "1")
            {
                frmCheckRep.datWindow.DataWindowObject = "ds_storagecheck_cp";
                frmCheckRep.m_blnUseByDS = false;
                frmCheckRep.m_intPrintType = 1;
            }
            else
            {
                frmCheckRep.datWindow.DataWindowObject = "ds_storagecheck";
            }
            DataTable dtbTem;
            DataTable dtbTemp = dtbStorageCheck_detail.Copy();
            dtbTemp.Columns.Add("medicinename_vch");
            foreach (DataRow dr in dtbTemp.Rows)
            {
                dr["medicinename_vch"] = dr["medicinename_vchr"];
            }            
            //dtbTemp.AcceptChanges();
            dtbTemp.Columns.Remove("medicinename_vchr");

            //m_objDomain.m_lngGetStoreCheck_DetailForPrint(m_objViewer.m_lngMainSEQ, out dtbTem);

            //if (m_objViewer.m_txtBillId.Text.Trim() == string.Empty)
            //{
            //    dtbTem.Merge(dtbTemp, true, MissingSchemaAction.Ignore);
            //}
            string strSubcheck = "";
            if (m_objViewer.m_chkOnlyShowGrossChange.Checked)
            {
                strSubcheck = "CHECKRESULT_INT <> 0";
            }
            if (m_objViewer.m_chkOnlyShowCURRENTGROSS.Checked)
            {
                if (strSubcheck.Length > 3)
                {
                    strSubcheck += " and (opcheckgross_int <> 0 or ipcheckgross_int <> 0) ";
                }
                else
                {
                    strSubcheck = " (opcheckgross_int <> 0 or ipcheckgross_int <> 0) ";
                }
            }
            if (m_objViewer.m_strFilter != "")
            {
                if (strSubcheck != "")
                {
                    strSubcheck += " and " + m_objViewer.m_strFilter;
                }
                else
                {
                    strSubcheck = m_objViewer.m_strFilter;
                }
            }
            if (strSubcheck.Length > 3)
            {
                dtbTemp.DefaultView.RowFilter = strSubcheck;
            }
            else
            {
                dtbTemp.DefaultView.RowFilter = string.Empty;
            }

            if (m_strPrintFormat == "1")
            {
                m_objDomain.m_lngGetStoreCheck_DetailForPrintCP(0, m_objViewer.m_blnIsHospital, out dtbTem);
            }
            else
            {
                m_objDomain.m_lngGetStoreCheck_DetailForPrint(0, m_objViewer.m_blnIsHospital, out dtbTem);
                //帐面金额：RetailMoney 实盘金额：realmoney 盈亏金额：balance
                dtbTem.Columns.Add("RetailMoney", typeof(double));
                dtbTem.Columns.Add("realmoney", typeof(double));
                dtbTem.Columns.Add("balance", typeof(double));
            }
            
            

            dtbTemp.Columns["REALGROSS_INT"].ColumnName = "currentgross_int";
            foreach (DataRow dr in dtbTemp.Rows)
            {
                dr["opunit_chr"] = dr["unit_chr"];
            }

            dtbTem.Merge(dtbTemp, true, MissingSchemaAction.Ignore);
            
            frmCheckRep.dtb = dtbTem.DefaultView.ToTable();
            double dblTotalPrice = 0d;
            for (int i1 = 0; i1 < dtbTem.Rows.Count; i1++)
            {
                if (Convert.ToString(dtbTem.Rows[i1]["realmoney"]).Length == 0) continue;
                dblTotalPrice += Convert.ToDouble(dtbTem.Rows[i1]["realmoney"]);
            }
            frmCheckRep.m_dblTotalPrice = dblTotalPrice;
            string strStorName = string.Empty; ;
            clsMedStore_VO objStore = clsPub.m_mthGetMedStoreNameByid(m_objViewer.m_strStoreID);
            if (objStore != null)
            {
                strStorName = objStore.m_strMedStoreName;
            }
            frmCheckRep.strStorageName = strStorName;
            if (m_objViewer.m_txtBillId.Text.Trim() == string.Empty)//未保存时打印
            {
                frmCheckRep.strCheckDate = Convert.ToDateTime(m_objViewer.m_datCheck.Text).ToString("yyyy年M月");
                frmCheckRep.strAskerName = m_objViewer.LoginInfo.m_strEmpName;
                frmCheckRep.strFhr = m_objViewer.LoginInfo.m_strEmpName;
                frmCheckRep.strExamerName = m_objViewer.LoginInfo.m_strEmpName;
            }
            else
            {
                frmCheckRep.strCheckDate = m_objCurrentMain.m_dtmCHECKDATE_DAT.ToString("yyyy年M月");
                frmCheckRep.strAskerName = m_objCurrentMain.m_strASKERNAME_VCHR;
                frmCheckRep.strFhr = m_objCurrentMain.m_strASKERNAME_VCHR;
                frmCheckRep.strExamerName = m_objCurrentMain.m_strEXAMERNAME_VCHR;
            }

            frmCheckRep.m_strHospitalName = m_objComInfo.m_strGetHospitalTitle();
            frmCheckRep.ShowDialog();
        }
        #endregion

        #region 显示药品类型
        Hashtable p_hstExist = new Hashtable();
        DataTable dtTypeName = null;
        DataRow[] p_drTypeName = null;
        int intIndex = 0;
        /// <summary>
        /// 显示药品类型
        /// </summary>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        internal string m_strShowMedicineType(DataTable dataTable)
        {
            string p_strTypeName = "";
            if (dataTable == null || dataTable.Rows.Count == 0)
                return p_strTypeName;
            p_hstExist.Clear();
            dtTypeName = dataTable.Copy();
            p_drTypeName = dtTypeName.Select(null, "medicinetypename_vchr", DataViewRowState.CurrentRows);
            if (p_drTypeName.Length > 0)
            {
                intIndex = 0;
                foreach (DataRow dr in p_drTypeName)
                {
                    if (dr["medicinetypename_vchr"].ToString() == "") continue;
                    if (!p_hstExist.ContainsValue(dr["medicinetypename_vchr"].ToString()))
                    {
                        p_hstExist.Add(intIndex, dr["medicinetypename_vchr"].ToString());
                        p_strTypeName += dr["medicinetypename_vchr"].ToString() + "、";
                        intIndex++;
                    }
                }
            }
            if (p_strTypeName.Length > 0)
                p_strTypeName = "药品类型：" + p_strTypeName.Substring(0, p_strTypeName.Length - 1);
            return p_strTypeName;
        }
        #endregion        
    
        /// <summary>
        /// 检查当前帐务期是否生成盘点单
        /// </summary>
        /// <param name="p_strCheckId">盘点单号</param>
        /// <param name="m_blnExist"></param>
        /// <returns></returns>
        internal long m_lngCheckExistBill(string p_strCheckId,out bool m_blnExist)
        {
            long lngRes = 0;
            DateTime m_dtmStartDate = DateTime.MinValue;
            DateTime m_dtmEndDate = DateTime.MinValue;
            m_objDomain.m_lngGetCurrentAccountDate(m_objViewer.m_strStoreDeptID, out m_dtmStartDate, out m_dtmEndDate);
            lngRes = m_objDomain.m_lngCheckExistBill(m_objViewer.m_strStoreDeptID, m_dtmStartDate, m_dtmEndDate,p_strCheckId, out m_blnExist);
            return lngRes;
        }

        #region 是否允许保存库存数为负数（只限于保存单据）0为不允许、1为允许
        /// <summary>
        /// 是否允许保存库存数为负数（只限于保存单据）
        /// </summary>
        /// <param name="m_intAllowNegativeStorage">是否允许保存库存数为负数（只限于保存单据）</param>
        internal void m_mthGetAllowNegativeStorage(out int m_intAllowNegativeStorage)
        {
            m_objDomain.m_mthGetAllowNegativeStorage(out m_intAllowNegativeStorage);
        }
        #endregion


        internal void m_mthChangeValueDate()
        {
            m_objDomain.m_mthChangeValueDate();
        }
    }
}
