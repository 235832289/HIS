using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 请领单查询控制类
    /// </summary>
    public class clsCtl_AskQuery : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 药房请领主界面
        /// </summary>
        private frmAskQuery m_objViewer;
        /// <summary>
        /// 药房请领主界面域控制层
        /// </summary>
        private clsDcl_AskForMedicine m_objDomain;
        private clsDcl_AskForMedDetail m_objDomainDetail;
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_AskQuery()
        {
            m_objDomain = new clsDcl_AskForMedicine();
            m_objDomainDetail = new clsDcl_AskForMedDetail();
        }
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAskQuery)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 获取请领部门信息
        /// </summary>
        public void m_mthGetApplyDeptInfo(out DataTable m_dtDept)
        {
            long lngRes = -1;
            m_dtDept=new DataTable ();
            lngRes = this.m_objDomain.m_lngGetApplyDept(out m_dtDept);
          
        }
        /// <summary>
        /// 获取出库部门信息
        /// </summary>
        public void m_mthGetExportDeptInfo()
        {
          
            this.m_objViewer.m_cboExportDept.Item.Add("全部", string.Empty);
            if (m_objViewer.m_dtExportDept != null)
            {
                foreach (DataRow dr in this.m_objViewer.m_dtExportDept.Rows)
                {
                    this.m_objViewer.m_cboExportDept.Item.Add(dr["medicineroomname"].ToString(), dr["medicineroomid"].ToString());
                }
                this.m_objViewer.m_dtExportDept.Dispose();
            }
            this.m_objViewer.m_cboExportDept.SelectedIndex = 0;
        }
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        int intX = 0;
        int intY = 0;
        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                if (m_objViewer.m_dtbMedicineInfo == null || m_objViewer.m_dtbMedicineInfo.Rows.Count == 0)
                {
                    clsPub.m_mthGetMedBaseInfo(m_objViewer.m_cboExportDept.SelectItemValue,out m_objViewer.m_dtbMedicineInfo);
                }
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedName.Location.X -10;
                Y = m_objViewer.m_txtMedName.Location.Y + m_objViewer.m_txtMedName.Height+20;
                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);
                intX = m_objViewer.Location.X;
                intY = m_objViewer.Location.Y;
                m_objViewer.Size = new System.Drawing.Size(930, 500);
                m_objViewer.Location = new System.Drawing.Point(50, intY);   
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
                m_ctlQueryMedicint.VisibleChanged += new EventHandler(m_ctlQueryMedicint_VisibleChanged);                
            }
            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        void m_ctlQueryMedicint_VisibleChanged(object sender, EventArgs e)
        {
            if (m_ctlQueryMedicint.Visible == false && m_objViewer.Size.Width == 930)
            {
                m_objViewer.Location = new System.Drawing.Point(intX, intY);
                m_objViewer.Size = new System.Drawing.Size(361, 361);
            }
            else if(m_ctlQueryMedicint.Visible == true && m_objViewer.Size.Width == 361)
            {
                m_objViewer.Size = new System.Drawing.Size(930, 500);
                m_objViewer.Location = new System.Drawing.Point(50, intY);                
            }
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            clsPub.m_mthGetMedBaseInfo(m_objViewer.m_cboExportDept.SelectItemValue,out m_objViewer.m_dtbMedicineInfo);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineInfo;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedName.Text = MS_VO.m_strMedicineName;
            m_objViewer.m_txtBillId.Focus();            
        }
        #endregion
        /// <summary>
        /// 根据输入条件查询药房请领主表信息
        /// </summary>
        public void m_mthGetAskInfoByConditions()
        {
            DataTable m_dtAskInfo = new DataTable();
            int m_intStatus = this.m_objViewer.m_cboStatus.SelectedIndex - 1;
            string m_strExpDept = this.m_objViewer.m_cboExportDept.SelectItemValue;
            try
            {
                this.m_objDomain.m_lngGetAskInfo(this.m_objViewer.m_datBegin.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_datEnd.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_cboAskDept.SelectItemValue, m_strExpDept, m_intStatus, this.m_objViewer.m_txtMedName.Text, this.m_objViewer.m_txtBillId.Text, out m_dtAskInfo);
                this.m_objViewer.m_dtAskMainInfo = m_dtAskInfo;
            }
            finally
            {
                m_dtAskInfo.Dispose();
            }
        }
        /// <summary>
        /// 根据输入条件查询药房请领主表信息
        /// </summary>
        public void m_mthGetAskInfoAndOutStorageInfoByConditions()
        {
            DataTable dtOutStorageInfo = new DataTable();
            DataTable dtAskInfo = new DataTable();
            DataTable dtTmp=new DataTable();
            int m_intStatus = this.m_objViewer.m_cboStatus.SelectedIndex - 1;
            string m_strExpDept = this.m_objViewer.m_cboExportDept.SelectItemValue;

            //20081201 查询单据类型：0为请领单号、1为药房入库单号、2为药库出库单号
            int m_intBillType = 0;
            if (m_objViewer.m_rbtInID.Checked)
                m_intBillType = 1;
            else if (m_objViewer.m_rbtOutID.Checked)
                m_intBillType = 2;

            try
            {
                long lngRes = this.m_objDomain.m_lngGetAskInfoAndOutStorageInfo(this.m_objViewer.m_datBegin.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_datEnd.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_cboAskDept.SelectItemValue, m_strExpDept, m_intStatus, this.m_objViewer.m_txtMedName.Text, this.m_objViewer.m_txtBillId.Text,m_intBillType, out dtAskInfo, out dtOutStorageInfo);
                //lngRes = this.m_objDomain.m_lngGetAllMoney(this.m_objViewer.m_datBegin.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_datEnd.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_cboAskDept.SelectItemValue, m_strExpDept, m_intStatus, this.m_objViewer.m_txtMedName.Text, this.m_objViewer.m_txtBillId.Text, out dtTmp);
                if (lngRes > 0)
                {
                    double dblSummoney = 0d;
                    long lngSieriesID = 0;
                    if (dtAskInfo != null && dtAskInfo.Rows.Count > 0)
                    {

                        for (int i1 = 0; i1 < dtAskInfo.Rows.Count; i1++)
                        {
                            this.m_objDomain.m_lngGetAskMoney(Convert.ToInt64(dtAskInfo.Rows[i1]["seriesid_int"]), out dblSummoney);
                            dtAskInfo.Rows[i1]["summoney"] = dblSummoney;
                        }
                    }
                    if (dtOutStorageInfo != null && dtOutStorageInfo.Rows.Count > 0)
                    {
                        dblSummoney = 0d;
                        for (int i1 = 0; i1 < dtOutStorageInfo.Rows.Count; i1++)
                        {
                            if(long.TryParse(dtOutStorageInfo.Rows[i1]["seriesid_int"].ToString(),out lngSieriesID))
                            {
                                this.m_objDomain.m_lngGetOutMoney(lngSieriesID, out dblSummoney);
                            }
                            
                            dtOutStorageInfo.Rows[i1]["summoney"] = dblSummoney;
                        }
                    }
                    if (dtAskInfo.Rows.Count > 0)
                    {
                        this.m_objViewer.m_dtAskMainInfo = dtAskInfo;
                        this.m_objViewer.m_dtOutStorageMainInfo = dtOutStorageInfo;
                        this.m_objViewer.m_dtAllMoney = dtTmp;
                        this.m_objViewer.Close();
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("查询不到满足条件的相关请领单，是否继续查询？", "请领单查询提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        if (dr == DialogResult.No)
                        {
                            this.m_objViewer.Close();
                        }
                    }
                }
            }
            finally
            {
                dtAskInfo.Dispose();
                dtOutStorageInfo.Dispose();
            }
            
        }
    }
}
