using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出库处理控制类
    /// </summary>
    public class clsCtl_OutStorage : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 初始化
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;   
        clsDcl_OutStorage objDomain;
        /// <summary>
        /// 控制类对应界面
        /// </summary>
        frmOutStorage m_objViewer;
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
        /// <summary>
        /// constructor
        /// </summary>
        public clsCtl_OutStorage()
        {
            objDomain = new clsDcl_OutStorage();
        }
        #endregion

        #region 获取药房出库主表信息
        /// <summary>
        /// 获取药房出库主表信息
        /// </summary>
        internal void m_mthGetCurrentDayOutstoragenfo()
        {
            long lngRes = 0;
            DataTable m_dtOutstorage = new DataTable();
            lngRes = objDomain.m_mthGetCurrentDayOutstoragenfo(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), out m_dtOutstorage);
            if (lngRes > 0)
            {
                m_objViewer.m_dgvMain.DataSource = m_dtOutstorage;
                ShowMainSumMoney();
                m_objViewer.m_dgvMain.Refresh();
            }
        }
        #endregion

        #region 初始化出库部门信息
        /// <summary>
        /// 初始化出库部门信息
        /// </summary>
        public void m_mthInstoreDeptInfo()
        {
            long lngRes = -1;
            this.m_objViewer.m_dtInstoreDept = new DataTable();
            lngRes = clsPub.m_mthBorrowDeptInfo(out this.m_objViewer.m_dtInstoreDept);            
            if(lngRes > 0)
                this.m_objViewer.m_txtBorrowDept.m_mthInitDeptData(this.m_objViewer.m_dtInstoreDept);               
        }

        #endregion

        #region 根据流水号获取药房出库明细
        /// <summary>
        /// 根据流水号获取药房出库明细
        /// </summary>
        public void m_lngGetOutstorageDetailByID()
        {
            long lngRes = 0;
            DataTable m_dtDetail = new DataTable();
            string m_strSeq = this.m_objViewer.m_dgvMain.Rows[this.m_objViewer.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value.ToString().Trim();
            lngRes = this.objDomain.m_lngGetOutstorageDetailByID(m_objViewer.m_blnIsHospital,Convert.ToInt64(m_strSeq), out m_dtDetail);
            if (lngRes > 0)
            {
                if (m_dtDetail != null && m_dtDetail.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < m_dtDetail.Rows.Count; i1++)
                    {
                        if (Convert.ToDateTime(m_dtDetail.Rows[i1]["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd") == "0001-01-01")
                        {
                            m_dtDetail.Rows[i1]["VALIDPERIOD_DAT"] = DBNull.Value;
                        }
                    }
                }
                this.m_objViewer.m_dgvDetail.DataSource = m_dtDetail;
                this.m_objViewer.m_dgvDetail.Refresh();
            }
        }
        #endregion

        #region 根据查询条件获取药房出库主表信息
        /// <summary>
        /// 根据查询条件获取药房出库主表信息
        /// </summary>
        public void m_mthGetOutstoragenfoByconditions()
        {
            long lngRes = 0;
            
            DateTime dtBeginTime = DateTime.MinValue;
            if (!DateTime.TryParse(m_objViewer.m_datBegin.Text, out dtBeginTime))
            {
                MessageBox.Show("请输入开始时间。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datBegin.Focus();
                return;
            }
            DateTime dtEndTime = DateTime.MinValue;
            if (!DateTime.TryParse(m_objViewer.m_datEnd.Text, out dtEndTime))
            {
                MessageBox.Show("请输入结束时间。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datEnd.Focus();
                return;
            }
            if (dtBeginTime > dtEndTime)
            {
                MessageBox.Show("开始时间不能大于结束时间。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datBegin.Focus();
                return;
            }
            string m_strBeginTime = dtBeginTime.ToString();
            string m_strEndTime = dtEndTime.ToString();


            DataTable m_dtOutstorage = new DataTable();
            string m_strMakeOrderName = m_objViewer.m_txtMaker.Text;           
            string m_strTypeCode = m_objViewer.m_cboOutstorageType.SelectItemValue;
            int m_intStatus = 0;
            if (m_objViewer.m_cboStatus.SelectedIndex == 0)
                m_intStatus = -1;
            else 
                m_intStatus = m_objViewer.m_cboStatus.SelectedIndex;

            string m_strMedStoreID = this.m_objViewer.m_cboMedStore.SelectItemValue;
            string m_strBorrowDeptID = this.m_objViewer.m_txtBorrowDept.Text.Trim() != string.Empty ? this.m_objViewer.m_txtBorrowDept.StrItemId.Trim() : string.Empty;
            string m_strBillID = this.m_objViewer.m_txtBillId.Text.Trim();
            this.m_objViewer.m_dgvMain.DataSource = null;
            this.m_objViewer.m_dgvDetail.DataSource = null;

            m_objViewer.m_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
            {
                if (m_objViewer.m_txtMedicineCode.Tag != null)
                    m_objViewer.m_strMedicineID = m_objViewer.m_txtMedicineCode.Tag.ToString();
            }
            else
            {
                m_objViewer.m_strMedicineID = m_objViewer.m_txtMedicineCode.Text.Trim();
            }
            

            lngRes = objDomain.m_mthGetOutstorageInfoByconditions(m_objViewer.m_rbtCombine.Checked,m_strBeginTime, m_strEndTime, m_strMakeOrderName, m_strTypeCode, m_intStatus, m_strMedStoreID, m_strBorrowDeptID, m_strBillID,m_objViewer.m_strMedicineID, out m_dtOutstorage);
            DataView dvResult = m_dtOutstorage.DefaultView;
            if (string.IsNullOrEmpty(m_strMedStoreID))
            {
                string strFilter = string.Empty;
                foreach (string str in m_objViewer.m_strMedStoreDeptIDArr)
                {
                    strFilter += "'" + str + "',";
                }
                dvResult.RowFilter = "drugstoreid_chr in (" + strFilter.Substring(0, strFilter.Length - 1) + ")";
            }
            else
            {
                dvResult.RowFilter = "drugstoreid_chr = '" + m_strMedStoreID + "'";
            }
            m_dtOutstorage = dvResult.ToTable();

            if (lngRes > 0)
            {
                //if (m_strMedStoreID == "" && m_objViewer.m_strMedStoreDeptIDArr.Length > 0)
                //{
                //    DataView dvResult = m_dtOutstorage.DefaultView;
                //    string strFilter = string.Empty;
                //    foreach (string s in m_objViewer.m_strMedStoreDeptIDArr)
                //    {
                //        strFilter += s + ",";
                //    }
                //    strFilter = strFilter.Substring(0, strFilter.Length - 1);
                //    dvResult.RowFilter = " drugstoreid_chr in (" + strFilter + ")";
                //    m_dtOutstorage = dvResult.ToTable();
                //}
                if (m_dtOutstorage != null && m_dtOutstorage.Rows.Count > 0)
                {
                    double dblSummoney = 0d;
                    for (int i1 = 0; i1 < m_dtOutstorage.Rows.Count; i1++)
                    {
                        if (Convert.ToDateTime(m_dtOutstorage.Rows[i1]["inaccount_dat"]).ToString("yyyy-MM-dd") == "0001-01-01")
                        {
                            m_dtOutstorage.Rows[i1]["inaccount_dat"] = DBNull.Value;
                        }
                        this.objDomain.m_lngGetSumMoney(Convert.ToInt64(m_dtOutstorage.Rows[i1]["seriesid_int"]), out dblSummoney);
                        m_dtOutstorage.Rows[i1]["summoney"] = dblSummoney;
                    }
                }

                m_objViewer.m_dgvMain.DataSource = m_dtOutstorage;
                ShowMainSumMoney();
                m_objViewer.m_dgvMain.Refresh();

                if (m_objViewer.m_dgvMain.Rows.Count > 0)
                {
                    for (int i1 = 0; i1 < m_objViewer.m_dgvMain.Rows.Count; i1++)
                    {
                        if (Convert.ToString(m_objViewer.m_dgvMain.Rows[i1].Cells["m_txtBillNo"].Value) == m_objViewer.m_strBillNo)
                        {
                            m_objViewer.m_dgvMain.CurrentCell = m_objViewer.m_dgvMain.Rows[i1].Cells[0];
                            m_objViewer.m_dgvMain.CurrentCell.Selected = true;
                        }
                    }
                }
                       
            }
        }

        private void ShowMainSumMoney()
        {
            double dblTmp = 0d;
            DataTable m_dtbMain = (DataTable)this.m_objViewer.m_dgvMain.DataSource;
            m_objViewer.m_lblAllRetailMoney.Text = "0.0000元";
            if (m_dtbMain != null && m_dtbMain.Rows.Count > 0)
            {
                double dblTemp = 0d;
                for (int i1 = 0; i1 < m_dtbMain.Rows.Count; i1++)
                {
                    double.TryParse(Convert.ToString(m_dtbMain.Rows[i1]["summoney"]), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_objViewer.m_lblAllRetailMoney.Text = dblTemp.ToString("F4")+"元";
            }
            else
            {
                m_objViewer.m_lblAllRetailMoney.Text = "0.0000元";
            }
        }
        #endregion

        #region 根据流水号删除药房出库主表
        /// <summary>
        /// 根据流水号删除药房出库主表
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public void m_lngDelOutstorage()
        {
            long lngRes = 0;
            long m_lngSeqid = 0;
            for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
            {
                if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                    m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                    lngRes = this.objDomain.m_lngDelOutstorage(m_lngSeqid);
                    this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "删除";
                }
            }

            //bool blnDel = DeleteRow();
            //while(!blnDel)
            //{
            //    blnDel = DeleteRow();
            //}
            DeleteRow();

            if (lngRes > 0)
            {
                MessageBox.Show("删除成功！", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private bool DeleteRow()
        {
            bool blnRes = false;
            int intNum = m_objViewer.m_dgvMain.Rows.Count;
            foreach (DataGridViewRow dr in m_objViewer.m_dgvMain.Rows)
            {
                if (dr.Cells["m_txtStatus"].Value.ToString() == "删除")
                {
                    if (dr.Index == intNum - 1)
                        blnRes = true;
                    m_objViewer.m_dgvMain.Rows.Remove(dr);
                    if (!blnRes)
                    {
                        return DeleteRow();
                    }
                }
                if (dr.Index == intNum - 1)
                    blnRes = true;
            }
            return blnRes;
        }
        #endregion

        #region 根据流水号进行药房出库审核
        /// <summary>
        /// 根据流水号进行药房出库审核
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public void m_mthOutstorageExam()
        {
            try
            {
                long lngRes = 0;
                long m_lngSeqid = 0;
                clsDS_UpdateStorageBySeriesID_VO[] m_objForUpdateArr = null;
                string strErrorInfo = string.Empty;
                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                    {
                        m_objForUpdateArr = null;
                        m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                        lngRes = this.objDomain.m_lngOutstorageExam(this.m_objViewer.LoginInfo.m_strEmpID, m_lngSeqid);
                        this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "审核";
                        lngRes = this.objDomain.m_lngGetOutstorageDetailByID(m_lngSeqid, out m_objForUpdateArr);
                        lngRes = this.objDomain.m_lngAddNewAccountDetail(m_objForUpdateArr);
                        lngRes = this.objDomain.m_lngSubtractStorage(m_objForUpdateArr, 2, out strErrorInfo);
                        this.objDomain.m_lngAddInstorage(m_lngSeqid);//增加入库单
                    }
                }
                if (lngRes > 0)
                {
                    MessageBox.Show("审核成功！", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 根据流水号进行药房出库退审
        /// <summary>
        /// 根据流水号进行药房出库退审
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public void m_mthOutstorageUnExam()
        {
            try
            {
                long lngRes = 0;
                long m_lngSeqid = 0;
                clsDS_UpdateStorageBySeriesID_VO[] m_objDetailVoArr = null;
                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                    {
                        m_objDetailVoArr = null;
                        m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                        lngRes = this.objDomain.m_lngOutstorageUnExam(m_lngSeqid);
                        this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "新制";
                        lngRes = this.objDomain.m_lngGetOutstorageDetailByID(m_lngSeqid, out m_objDetailVoArr);
                        if(m_objDetailVoArr.Length>0)
                        lngRes = this.objDomain.m_lngUpdateAccountDetail(m_objDetailVoArr[0].m_strDrugID,m_objDetailVoArr[0].m_strDSINSTOREID_VCHR);
                        lngRes = this.objDomain.m_lngAddStorage(m_objDetailVoArr, 1);
                    }
                }
                if (lngRes > 0)
                {
                    MessageBox.Show("退审成功！", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 药房出库入账
        /// <summary>
        ///  药房出库入账
        /// </summary>
        public void m_mthOutStorageInAccount()
        {
            try
            {
                long lngRes = 0;
                long m_lngSeqid = 0;
                string m_strChittyid;
                string m_strDrugStoreid;
                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                    {
                        m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                        m_strChittyid = this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtBillNo"].Value.ToString();
                        m_strDrugStoreid = this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtMedStoreid"].Value.ToString();
                        lngRes = this.objDomain.m_lngOutstorageInAccount(m_lngSeqid, this.m_objViewer.LoginInfo.m_strEmpID, m_strChittyid, m_strDrugStoreid);
                        if (lngRes > 0)
                        {
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "入账";
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_dgvtxtInaccountid"].Value = this.m_objViewer.LoginInfo.m_strEmpID;
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_dgvtxtInaccountName"].Value = this.m_objViewer.LoginInfo.m_strEmpName;
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_dgvdtmInaccountDate"].Value = clsPub.CurrentDateTimeNow;
                        }
                    }
                }
                if (lngRes > 0)
                {
                    MessageBox.Show("入账成功！", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：1为药房出库单</param>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(int p_intType, long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            lngRes = objDomain.m_lngCheckStatus(p_intType, p_lngSeq, out  m_intStatus);
            return lngRes;
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable m_dtMedicineInfo)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_dtMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineCode.Location.X;
                Y = m_objViewer.m_txtMedicineCode.Location.Y + m_objViewer.m_txtMedicineCode.Size.Height;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            clsPub.m_mthGetMedBaseInfo(m_objViewer.m_cboMedStore.SelectItemValue, out m_objViewer.m_dtMedicineInfo);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtMedicineInfo;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            if (m_objViewer.m_rbtSingle.Checked)
            {
                m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineName;
            }
            else
            {
                m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineCode;
            }
            
            m_objViewer.m_btnFind.Focus();
        }
        #endregion

        /// <summary>
        /// 是否住院药房
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {
            clsDcl_AskForMedicine objDom = new clsDcl_AskForMedicine();
            return objDom.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }
    }
}
