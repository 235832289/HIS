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
    /// 药房入库处理控制层
    /// </summary>
    public class clsCtl_InStorage : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;   
        clsDcl_Instorage objDomain;
        /// <summary>
        /// 控制类对应界面
        /// </summary>
        frmInStorage m_objViewer;
        
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInStorage)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// constructor
        /// </summary>
        public clsCtl_InStorage()
        {
            objDomain = new clsDcl_Instorage();
        }
        #region 初始化借调部门信息
        /// <summary>
        /// 初始化借调部门信息
        /// </summary>
        public void m_mthBorrowDeptInfo()
        {
            long lngRes = -1;
            this.m_objViewer.m_dtBorrowDept = new DataTable();
            lngRes = clsPub.m_mthBorrowDeptInfo(out this.m_objViewer.m_dtBorrowDept);
            if (lngRes > 0)
            {
                this.m_objViewer.m_txtBorrowDept.m_mthInitDeptData(this.m_objViewer.m_dtBorrowDept);
            }
        }
        #endregion
        #region 获取当天药房入库主表信息
        /// <summary>
        /// 获取当天药房入库主表信息
        /// </summary>
        public void  m_mthGetCurrentDayInstoragenfo()
        {   

            long lngRes = 0;
            DataTable m_dtInstorage = new DataTable();
            DataTable m_dtOutstorage = new DataTable();
            lngRes = objDomain.m_lngGetCurrentDayInstoragenfo(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), out m_dtInstorage);
            DataView dvResult = m_dtInstorage.DefaultView;            
            string strFilter = string.Empty;
            foreach (string str in m_objViewer.m_strMedStoreDeptIDArr)
            {
                strFilter += "'" + str + "',";
            }
            dvResult.RowFilter = "drugstoreid_chr in (" + strFilter.Substring(0, strFilter.Length - 1) + ") and status_int<> 0 and formtype_int in (2,3,4,6)";           
            m_dtInstorage = dvResult.ToTable();
            if (lngRes > 0)
            {
                m_objViewer.m_dgvMain.DataSource = m_dtInstorage;
                if (m_dtInstorage != null && m_dtInstorage.Rows.Count > 0)
                {
                    double dblSummoney = 0d;
                    for (int i1 = 0; i1 < m_dtInstorage.Rows.Count; i1++)
                    {
                        this.objDomain.m_lngGetSumMoney(Convert.ToInt64(m_dtInstorage.Rows[i1]["seriesid_int"]), out dblSummoney);
                        m_dtInstorage.Rows[i1]["summoney"] = dblSummoney;
                    }
                }
                m_objViewer.m_dgvMain.DataSource = m_dtInstorage;
                ShowMainSumMoney();
                m_objViewer.m_dgvMain.Refresh();
            }
        }
        #endregion
        #region 根据查询条件获取药房入库主表信息
          /// <summary>
        /// 根据查询条件获取药房入库主表信息
          /// </summary>
        public void m_mthGetInstoragenfoByconditions()
        {
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

            long lngRes = 0;  
            DataTable m_dtInstorage = new DataTable();
            string m_strMakeOrderName = m_objViewer.m_txtMaker.Text;           
            string m_strTypeCode = this.m_objViewer.m_cboInstorageType.SelectItemValue;        
        
            int m_intStatus = 0;
            if (m_objViewer.m_cboStatus.SelectedIndex == 0)
                m_intStatus = -1;
            else
                m_intStatus = m_objViewer.m_cboStatus.SelectedIndex;

            string  m_strMedStoreID = this.m_objViewer.m_cboMedStore.SelectItemValue;
            string m_strBorrowDeptID =this.m_objViewer.m_txtBorrowDept.Text.Trim()!=string.Empty?this.m_objViewer.m_txtBorrowDept.StrItemId.Trim():string.Empty;
            string m_strBillID = this.m_objViewer.m_txtBillId.Text.Trim();
            this.m_objViewer.m_dgvMain.DataSource = null;
            this.m_objViewer.m_dgvDetail.DataSource = null;

            m_objViewer.m_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
            {
                if (m_objViewer.m_txtMedicineCode.Tag != null)
                {
                    m_objViewer.m_strMedicineID = m_objViewer.m_txtMedicineCode.Tag.ToString();
                }
            }
            else
            {
                m_objViewer.m_strMedicineID = m_objViewer.m_txtMedicineCode.Text.Trim();
            }

            lngRes = objDomain.m_lngGetInstoragenfoByconditions(m_objViewer.m_rbtCombine.Checked, m_strBeginTime, m_strEndTime, m_strMakeOrderName, m_strTypeCode, m_intStatus, m_strBorrowDeptID, m_strBillID, m_objViewer.m_strMedicineID, out m_dtInstorage);
            DataView dvResult = m_dtInstorage.DefaultView;
            if (string.IsNullOrEmpty(m_strMedStoreID))
            {                
                string strFilter = string.Empty;
                foreach (string str in m_objViewer.m_strMedStoreDeptIDArr)
                {
                    strFilter += "'"+str + "',";
                }
                dvResult.RowFilter = "drugstoreid_chr in (" + strFilter.Substring(0, strFilter.Length - 1) + ")";
            }
            else
            {
                dvResult.RowFilter = "drugstoreid_chr = '" + m_strMedStoreID + "'";
            }
            m_dtInstorage = dvResult.ToTable();
            if (lngRes > 0)
            {
                if (m_dtInstorage != null && m_dtInstorage.Rows.Count > 0)
                {
                    double dblSummoney = 0d;
                    for(int i1 = 0;i1 < m_dtInstorage.Rows.Count;i1++)
                    {
                        this.objDomain.m_lngGetSumMoney(Convert.ToInt64(m_dtInstorage.Rows[i1]["seriesid_int"]),out dblSummoney);
                        m_dtInstorage.Rows[i1]["summoney"] = dblSummoney;
                    }
                }
                m_objViewer.m_dgvMain.DataSource = m_dtInstorage;
                ShowMainSumMoney();
                m_objViewer.m_dgvMain.Refresh();
            }
            if (m_objViewer.m_dgvMain.Rows.Count > 0)
            {
                if (m_strBillID != "")
                {
                    for (int i1 = 0; i1 < m_objViewer.m_dgvMain.Rows.Count; i1++)
                    {
                        if (Convert.ToString(m_objViewer.m_dgvMain.Rows[i1].Cells["m_txtBillNo"].Value) == m_strBillID)
                        {
                            m_objViewer.m_dgvMain.Rows[i1].Selected = true;
                            m_objViewer.m_dgvMain.CurrentCell = m_objViewer.m_dgvMain.Rows[i1].Cells[2];
                            break;
                        }
                    }
                }
                if (m_objViewer.m_dgvMain.CurrentCell == null)
                {
                    m_objViewer.m_dgvMain.Rows[0].Selected = true;
                    m_objViewer.m_dgvMain.CurrentCell = m_objViewer.m_dgvMain.Rows[0].Cells[2];
                }
            }
        }

        private void ShowMainSumMoney()
        {
            double dblTmp = 0d;
            DataTable m_dtbMain = (DataTable)this.m_objViewer.m_dgvMain.DataSource;
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
        #region 根据流水号获取药房入库明细
        /// <summary>
        /// 根据流水号获取药房入库明细
        /// </summary>
        public void m_lngGetInstorageDetailByID()
        {
            long lngRes = 0;
            DataTable m_dtDetail = new DataTable();
            string m_strSeq = this.m_objViewer.m_dgvMain.Rows[this.m_objViewer.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value.ToString().Trim();
            lngRes = this.objDomain.m_lngGetInstorageDetailByID(m_objViewer.m_blnIsHospital,Convert.ToInt64(m_strSeq), out m_dtDetail);
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvDetail.DataSource = m_dtDetail;                
                ShowRetailMoney();
                this.m_objViewer.Refresh();
            }
          
        }
        private void ShowRetailMoney()
        {
            DataTable m_dtbDetail = (DataTable)this.m_objViewer.m_dgvDetail.DataSource;
            if (m_dtbDetail != null && m_dtbDetail.Rows.Count > 0)
            {
                double dblTemp = 0d;
                double dblTmp = 0d;
                for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    double.TryParse(Convert.ToString((Convert.ToDouble(m_dtbDetail.Rows[i1]["OPRETAILPRICE_INT"]) / Convert.ToDouble(m_dtbDetail.Rows[i1]["PACKQTY_DEC"])) * Convert.ToDouble(m_dtbDetail.Rows[i1]["IPAMOUNT_INT"])), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_objViewer.m_lblRetailMoney.Text = dblTemp.ToString("F4")+"元";
            }
            else
            {
                m_objViewer.m_lblRetailMoney.Text = "0.0000元";
            }
        }
        #endregion
        #region 根据流水号删除药房入库主表
        /// <summary>
        /// 根据流水号删除药房入库主表
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public void m_lngDelInstorage()
        {
            long lngRes = 0;
            long m_lngSeqid = 0;
            for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
            {
                if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value!=null&&this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                     m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                     lngRes = this.objDomain.m_lngDelInstorage(m_lngSeqid);
                     this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "删除";
                     //this.m_objViewer.m_dgvMain.Rows.Remove(this.m_objViewer.m_dgvMain.Rows[i]);
                     //break;
                }
            }
            DeleteRow();
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功！", "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
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
        #region 根据流水号进行药房入库审核
        /// <summary>
        /// 根据流水号进行药房入库审核
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public void m_mthInstorageExam()
        {
            int m_intTemp = 0;
            bool m_blnHasEnoughGross = true;
            string m_strMedName = string.Empty;
            try
            {
                long lngRes = 0;
                long m_lngSeqid = 0;
                clsDS_StorageDetail_VO[] m_objDetailVoArr = null;


                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                    {
                        m_intTemp = i;
                        m_objDetailVoArr = null;
                        m_blnHasEnoughGross = true;
                        m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                        lngRes = this.objDomain.m_lngInstorageExam(this.m_objViewer.LoginInfo.m_strEmpID, clsPub.CurrentDateTimeNow, m_lngSeqid, m_objDetailVoArr, 1, out m_blnHasEnoughGross,out m_strMedName);
                        if (lngRes > 0)
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "审核";
                        // lngRes = this.objDomain.m_lngGetInstorageDetailByID(m_lngSeqid, out m_objDetailVoArr,1);
                        //lngRes = this.objDomain.m_lngAddStorage(m_objDetailVoArr, 1);

                    }
                }
                if (lngRes > 0)
                {
                    MessageBox.Show("审核成功！", "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                //

                //if (m_blnHasEnoughGross == false)
                //{
                //    MessageBox.Show(string.Format("入库单据号为{0}的入库单存在库存不够冲减的药品记录，不能审核！\r\n该药品名称为：{1}", this.m_objViewer.m_dgvMain.Rows[m_intTemp].Cells["m_txtBillNo"].Value.ToString(),m_strMedName),"药房入库提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //}
                //else
                //{
                    MessageBox.Show(ex.Message, "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
        }
        #endregion
        #region 根据流水号进行药房入库退审
        /// <summary>
        /// 根据流水号进行药房入库退审
        /// </summary>
        /// <param name="m_lngSeqid"></param>
        /// <returns></returns>
        public void m_mthInstorageUnExam()
        {
            try
            {
                long lngRes = 0;
                long m_lngSeqid = 0;
                
                clsDS_StorageDetail_VO[] m_objDetailVoArr = null;
                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_objViewer.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                    {
                        m_objDetailVoArr = null;
                        m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value);
                        lngRes = this.objDomain.m_lngInstorageUnExam(m_lngSeqid);
                        this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "新制";
                    }
                }
                if (lngRes > 0)
                {
                    MessageBox.Show("退审成功！", "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        /// <summary>
        /// 获取入库明细
        /// </summary>
        /// <param name="lngSeqid"></param>
        /// <param name="m_objDetailVoArr"></param>
        public void m_mthGetInstorageDetailVoArrByid(long lngSeqid, out  clsDS_StorageDetail_VO[] m_objDetailVoArr)
        {
            long lngRes = 0;
            m_objDetailVoArr = null;
            lngRes = this.objDomain.m_lngGetInstorageDetailByID(lngSeqid, out m_objDetailVoArr, 0);
        }
        #region 药房入库入账
        public void m_mthInstorageAccount()
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
                        m_strChittyid=this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtBillNo"].Value.ToString();
                        m_strDrugStoreid = this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtMedStoreid"].Value.ToString();
                        lngRes = this.objDomain.m_lngInstorageInAccount(m_lngSeqid, this.m_objViewer.LoginInfo.m_strEmpID, m_strChittyid, m_strDrugStoreid);
                        if (lngRes > 0)
                        {
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "入账";
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["m_dgvInacountdate"].Value = clsPub.CurrentDateTimeNow;
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["inaccounterid_chr"].Value = this.m_objViewer.LoginInfo.m_strEmpID;
                            this.m_objViewer.m_dgvMain.Rows[i].Cells["inaccountername"].Value = this.m_objViewer.LoginInfo.m_strEmpName;
    
                        }
                    }
                }
                if (lngRes > 0)
                {
                    MessageBox.Show("入账成功！", "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 根据条件判断是否存在足够的库存退审
        /// <summary>
        /// 根据条件判断是否存在足够的库存退审
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strLotNo"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_dtmInstorage"></param>
        /// <param name="m_dblOPAmount"></param>
        /// <param name="m_blnEnough"></param>
        /// <returns></returns>
        public void  m_mthInstorageUnExamCheck(string m_strDurgStoreid, string m_strLotNo, string m_strMedicineid, DateTime m_dtmInstorage, double m_dblOPAmount, out bool m_blnEnough)
        {

            long lngRes = 0;
            lngRes=this.objDomain.m_lngInstorageUnExamCheck( m_strDurgStoreid,  m_strLotNo,  m_strMedicineid,  m_dtmInstorage,  m_dblOPAmount, out  m_blnEnough);
           
        }
        #endregion

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：0为药房入库单</param>
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

        #region 检查单据FormType
        /// <summary>
        /// 检查单据FormType
        /// </summary>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="p_intFormType">单据FormType值</param>
        /// <returns></returns>
        internal long m_lngCheckFormType(long p_lngSeq, out int p_intFormType)
        {
            long lngRes = 0;
            lngRes = objDomain.m_lngCheckFormType(p_lngSeq, out  p_intFormType);
            return lngRes;
        }
        #endregion
    }
}
