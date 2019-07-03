using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmRegisterRepeatPrt : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private string OldNo = "";
        private string newno = "";
        /// <summary>
        /// 新号
        /// </summary>
        public string NewNo
        {
            get
            {
                return newno;
            }
        }
        private string prntype = "";
        /// <summary>
        /// 重打类型 1 原号 2 新号
        /// </summary>
        public string PrnType
        {
            get
            {
                return prntype;
            }
        }

        public frmRegisterRepeatPrt(string oldno)
        {
            InitializeComponent();
            OldNo = oldno;
        }

        private void frmRegisterRepeatPrt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRegisterRepeatPrt_Load(object sender, EventArgs e)
        {
            this.lblOldNo.Text = OldNo;

            this.rdo1.Checked = true;
            this.rdo2.Checked = false;
            this.txtNewNo.Text = "";
            this.txtNewNo.Enabled = false;
        }

        private void rdo1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdo1.Checked)
            {
                this.txtNewNo.Text = "";
                this.txtNewNo.Enabled = false;
            }
        }

        private void rdo2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdo2.Checked)
            {
                this.txtNewNo.Enabled = true;
                this.txtNewNo.Focus();
            }
        }

        #region 检查挂号发票表达式 true 通过 false 未通过
        /// <summary>
        /// 检查挂号发票表达式 true 通过 false 未通过
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
        public bool m_blnCheckInvoNoExpression(string InvoNo)
        {
            string Exp = "";
            bool ret = false;
                        
            try
            {
                if (File.Exists(Application.StartupPath + "\\LoginFile.xml"))
                {
                    //读取本地配置表达式
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Application.StartupPath + "\\LoginFile.xml");
                    XmlNode xn = doc.DocumentElement.SelectSingleNode("InvoiceExpression");
                    Exp = xn.InnerText;

                    //正则表达式比较
                    Regex r = new Regex(Exp);
                    Match m = r.Match(InvoNo);
                    if (m.Success)
                    {
                        ret = true;
                    }                    
                }
            }
            catch
            {
                return false;
            }

            return ret;
        }
        #endregion

        #region 检查挂号发票是否被使用 true 被使用 false 未被使用
        /// <summary>
        /// 检查挂号发票是否被使用 true 被使用 false 未被使用
        /// </summary>
        /// <param name="InvoNo"></param>
        /// <returns></returns>
        public bool m_blnCheckInvoNoIsUse(string InvoNo)
        {           
            clsDomainControl_Register domain = new clsDomainControl_Register();

            if (!domain.m_mthIsCanDo("0008"))
            {
                DataTable dt = null;
                long l = domain.m_lngCheckNO(InvoNo.Trim(), out dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    MessageBox.Show("该发票号" + InvoNo + "已于" + DateTime.Parse(dt.Rows[dt.Rows.Count - 1]["REGISTERDATE_DAT"].ToString()).ToString("yyyy-MM-dd") + "被" + dt.Rows[dt.Rows.Count - 1]["EMPNO_CHR"].ToString().Trim() + "使用\r\n\r\n请重新设置(与当前打印票据号相同)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNewNo.Focus();                    
                    return true;
                }
            }

            return false;
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            newno = this.txtNewNo.Text.Trim();

            if (this.rdo1.Checked)
            {
                prntype = "1";
            }
            else if (this.rdo2.Checked)
            {
                if (newno == "")
                {
                    MessageBox.Show("请输入新号码!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (!this.m_blnCheckInvoNoExpression(newno))
                {
                    MessageBox.Show("当前挂号发票的编号不符合编码规则，请重新设置(与当前打印票据号相同)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNewNo.Focus();
                    this.txtNewNo.SelectAll();
                    return;
                }

                if (this.m_blnCheckInvoNoIsUse(newno))
                {                    
                    this.txtNewNo.Focus();
                    this.txtNewNo.SelectAll();
                    return;
                }

                prntype = "2";
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}