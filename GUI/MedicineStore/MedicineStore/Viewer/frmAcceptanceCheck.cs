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
    /// 药品验收情况
    /// </summary>
    public partial class frmAcceptanceCheck : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药品ID
        /// </summary>
        internal string m_strMedicineID = string.Empty;
        /// <summary>
        /// 供应商列表
        /// </summary>
        internal DataTable m_dtbVendor = null;
        /// <summary>
        /// 当前验货情况
        /// </summary>
        internal clsMS_AcceptanceCheck_VO m_objACVO = null;
        /// <summary>
        /// 最近一次中标单位ID
        /// </summary>
        private string m_strLatestBidCompany = string.Empty;
        /// <summary>
        /// 最近一次批准文号
        /// </summary>
        private string m_strLastestLotNO = string.Empty;
        /// <summary>
        /// 是否第一次打开窗体(控制焦点用)
        /// </summary>
        private bool m_blnIsFirstLoad = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品验收情况
        /// </summary>
        private frmAcceptanceCheck()
        {
            InitializeComponent();
            m_cboApparentQuality.SelectedIndex = 1;
            m_cboBid.SelectedIndex = 1;
            m_cboExamResult.SelectedIndex = 1;
            m_cboPackQuality.SelectedIndex = 1;

            m_mthInitJumpControls();
        }

        /// <summary>
        /// 药品验收情况
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dtbVendor">供应商列表</param>
        public frmAcceptanceCheck(string p_strMedicineID, DataTable p_dtbVendor) : this()
        {
            m_strMedicineID = p_strMedicineID;
            m_dtbVendor = p_dtbVendor;
        } 
        #endregion

        #region 事件
        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            m_objACVO = ((clsCtl_AcceptanceCheck)objController).m_objGetCurrentVO();
            if (m_objACVO == null)
            {
                return;
            }
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_txtBidCompany_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AcceptanceCheck)objController).m_mthShowVendor(m_txtBidCompany.Text);
            }
        }

        private void m_txtExamerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AcceptanceCheck)objController).m_mthSetEmpToList(m_txtExamerID.Text, m_txtExamerID);
            }
        }

        private void m_cboBid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtBidCompany.Focus();
            }
        }

        private void m_bgwGetLasteInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_AcceptanceCheck)objController).m_mthGetLatestBidCompany(m_strMedicineID, out m_strLastestLotNO, out m_strLatestBidCompany);
        }

        private void m_bgwGetLasteInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ((clsCtl_AcceptanceCheck)objController).m_mthSetDefault(m_strLastestLotNO, m_strLatestBidCompany);
        } 
        #endregion

        #region 方法
        /// <summary>
        /// 控件跳转
        /// </summary>
        private void m_mthInitJumpControls()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthJumpControl(this, new Control[] {  m_cboApparentQuality, m_cboPackQuality, m_cboExamResult, m_txtExamerID }, Keys.Enter, false);
        }

        public override void CreateController()
        {
            this.objController = new clsCtl_AcceptanceCheck();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 设置验货内容至界面
        /// </summary>
        /// <param name="p_objACVO">验货内容</param>
        internal void m_mthSetACVOToUI(clsMS_AcceptanceCheck_VO p_objACVO)
        {
            if (p_objACVO == null)
            {
                return;
            }

            m_cboBid.SelectedIndex = p_objACVO.m_intBid;
            m_txtBidCompany.Text = p_objACVO.m_strBidCompanyName;
            m_txtBidCompany.Tag = p_objACVO.m_strBidCompany;
            m_txtApproveCode.Text = p_objACVO.m_strApproveCode;
            m_cboApparentQuality.SelectedIndex = p_objACVO.m_intApparentQuality;
            m_cboPackQuality.SelectedIndex = p_objACVO.m_intPackQuality;
            m_cboExamResult.SelectedIndex = p_objACVO.m_intExamResult;
            m_txtExamerID.Tag = p_objACVO.m_strExamerID;
            m_txtExamerID.Text = p_objACVO.m_strExamerName;
            txtTrade.Text = p_objACVO.m_strTrademark;
            cobGMP.SelectedIndex = p_objACVO.m_intGMPFlag;
        }
        #endregion

        private void frmAcceptanceCheck_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(m_txtBidCompany.Text))
            {
                m_txtApproveCode.Focus();
            }
            else
            {
                m_txtBidCompany.Focus();
            }
            //this.cobGMP.SelectedIndex = 0;
            m_blnIsFirstLoad = true;
        }

        private void m_txtApproveCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(m_txtExamerID.Text) || m_txtExamerID.Tag == null)
                {
                    m_txtExamerID.Focus();
                }
                else
                {
                    m_cmdOK.Focus();
                }
            }
        }

        private void m_cboBid_Enter(object sender, EventArgs e)
        {
            if (m_blnIsFirstLoad)
            {
                if (!string.IsNullOrEmpty(m_txtBidCompany.Text))
                {
                    m_txtApproveCode.Focus();
                }
                else
                {
                    m_txtBidCompany.Focus();
                }
                m_blnIsFirstLoad = false;
            }            
        }
    }
}