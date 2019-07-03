using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public delegate void OnSave(clsDS_StorageHistory_VO objHistory);
    public partial class frmEditAvailableStorage : Form
    {
        public frmEditAvailableStorage()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 药品ID
        /// </summary>
        internal string m_strMedicineID = string.Empty;
        /// <summary>
        /// 修改记录
        /// </summary>
        internal clsDS_StorageHistory_VO m_objHistory;
        /// <summary>
        /// 门诊单位数量
        /// </summary>
        internal int m_intOPChargeFlage = 0;
        /// <summary>
        /// 住院单位数量
        /// </summary>
        internal int m_intIPChargeFlage = 0;
        /// <summary>
        /// 包装量
        /// </summary>
        internal double m_dblPackQty = 0;
        /// <summary>
        /// 是否住院单位
        /// </summary>
        internal bool m_blnIsHospital = false;
        #endregion
        public event OnSave OnSaveAmount;
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_blnCheckAvailiable() && OnSaveAmount != null)
            {
                OnSaveAmount(m_objHistory);
                this.DialogResult = DialogResult.OK;
                return;
            }
            this.DialogResult = DialogResult.None;
        }

        private bool m_blnCheckAvailiable()
        {
            double m_dblNewAmount = 0d;
            if (double.TryParse(m_txtNewAmount.Text.Trim(), out m_dblNewAmount))
            {
                if (Convert.ToDouble(m_txtOldAmount.Text) == m_dblNewAmount)
                {
                    MessageBox.Show("修改前后数量相同，不能保存！", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtNewAmount.Focus();
                    m_txtNewAmount.SelectAll();
                    return false;
                }
                if (m_blnIsHospital)
                {
                    if (m_intIPChargeFlage == 0)
                    {
                        m_objHistory.m_dblNEWOPAVAILABLEGROSS_NUM = m_dblNewAmount;
                        m_objHistory.m_dblNEWIPAVAILABLEGROSS_NUM = m_dblNewAmount * m_dblPackQty;
                    }
                    else
                    {
                        m_objHistory.m_dblNEWIPAVAILABLEGROSS_NUM = m_dblNewAmount;
                        m_objHistory.m_dblNEWOPAVAILABLEGROSS_NUM = Math.Round(m_dblNewAmount / m_dblPackQty,2);
                    }
                }
                else
                {
                    if (m_intOPChargeFlage == 0)
                    {
                        m_objHistory.m_dblNEWOPAVAILABLEGROSS_NUM = m_dblNewAmount;
                        m_objHistory.m_dblNEWIPAVAILABLEGROSS_NUM = m_dblNewAmount * m_dblPackQty;
                    }
                    else
                    {
                        m_objHistory.m_dblNEWIPAVAILABLEGROSS_NUM = m_dblNewAmount;
                        m_objHistory.m_dblNEWOPAVAILABLEGROSS_NUM = Math.Round(m_dblNewAmount / m_dblPackQty,2);
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("必须填写正确数量！", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtNewAmount.Focus();
                m_txtNewAmount.SelectAll();
            }
            return false;
        }

        private void m_txtNewAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                m_btnSave.Focus();
        }

        private void m_txtNewAmount_Leave(object sender, EventArgs e)
        {
            double m_dblNewAmount = 0d;
            if (double.TryParse(m_txtNewAmount.Text.Trim(), out m_dblNewAmount))
            {
                m_txtNewAmount.Text = m_dblNewAmount.ToString("F2");
            }
        }

    }
}