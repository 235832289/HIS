using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 导航数据
    /// </summary>
    /// <param name="p_strMedicineName">药品名称</param>
    /// <param name="p_intDirection">方向，1最前，2前面，3后面，4最后</param>
    public delegate void LocateMedicine(string p_strMedicineName, Int16 p_intDirection);
    /// <summary>
    /// 导航数据
    /// </summary>
    public partial class frmQueryNavigator : Form
    {
        /// <summary>
        /// 导航数据
        /// </summary>
        public frmQueryNavigator(string p_strMedicineName)
        {
            InitializeComponent();
            m_txtMedicine.Text = p_strMedicineName;
        }
        /// <summary>
        /// 点击按钮发生的事件
        /// </summary>
        public event LocateMedicine OnLocateMedicine;
        /// <summary>
        /// 药典数据表
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;
        ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 药品基本信息
        /// </summary>
        private clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();
        /// <summary>
        /// 之前查询的文本
        /// </summary>
        private string m_strOldInput = string.Empty;
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_txtMedicine_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_mthShowQueryMedicineForm(m_txtMedicine.Text.Trim());
                    break;
            }
        }

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.Location = new System.Drawing.Point(50, 22 + m_txtMedicine.Height);
            m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            m_ctlQueryMedicint.m_btnRefresh.Enabled = false;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                m_txtMedicine.Text = "";
                m_objMedicineBase.m_strMedicineID = "";
                m_objMedicineBase.m_strAssistCode = "";
                m_objMedicineBase.m_strMedicineName = "";
                m_objMedicineBase.m_strMedSpec = "";
                m_txtMedicine.Focus();
                return;
            }
            m_txtMedicine.Text = MS_VO.m_strMedicineName;
            m_txtMedicine.Tag = MS_VO.m_strMedicineID;
            m_objMedicineBase.m_strMedicineID = MS_VO.m_strMedicineID;
            m_objMedicineBase.m_strAssistCode = MS_VO.m_strMedicineCode;
            m_objMedicineBase.m_strMedicineName = MS_VO.m_strMedicineName;
            m_objMedicineBase.m_strMedSpec = MS_VO.m_strMedicineSpec;
            m_btnNext.PerformClick();
        }
        #endregion

        private void m_btnFirst_Click(object sender, EventArgs e)
        {
            if (OnLocateMedicine != null)
                OnLocateMedicine(this.m_txtMedicine.Text.Replace("'", "''").Trim(), 1);
        }

        private void m_btnPrev_Click(object sender, EventArgs e)
        {
            if (OnLocateMedicine != null)
                OnLocateMedicine(this.m_txtMedicine.Text.Replace("'", "''").Trim(), 2);
        }

        private void m_btnNext_Click(object sender, EventArgs e)
        {
            if (OnLocateMedicine != null)
            {
                if (m_strOldInput == m_txtMedicine.Text.Replace("'", "''").Trim())
                    OnLocateMedicine(this.m_txtMedicine.Text.Replace("'", "''").Trim(), 3);
                else
                {
                    OnLocateMedicine(this.m_txtMedicine.Text.Replace("'", "''").Trim(), 1);
                    m_strOldInput = m_txtMedicine.Text.Replace("'", "''").Trim();
                }
            }
        }

        private void m_btnLast_Click(object sender, EventArgs e)
        {
            if (OnLocateMedicine != null)
                OnLocateMedicine(this.m_txtMedicine.Text.Replace("'", "''").Trim(), 4);
        }

        private void frmQueryNavigator_Load(object sender, EventArgs e)
        {
            m_strOldInput = m_txtMedicine.Text.Replace("'", "''").Trim();
            m_btnNext.PerformClick();
            m_txtMedicine.Focus();
        }

        private void m_txtMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {                
                m_btnNext.PerformClick();                
            }
        }
    }
}