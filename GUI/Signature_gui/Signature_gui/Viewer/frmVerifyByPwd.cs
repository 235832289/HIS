using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.CryptographyLib;

namespace com.digitalwave.Emr.Signature_gui
{
    /// <summary>
    /// frmVerifyByPwd 的摘要说明。
    /// </summary>
    public class frmVerifyByPwd : System.Windows.Forms.Form
    {
        internal TextBox txtPwd;
        internal TextBox txtEmpNo;
        private Label label4;
        internal Label lblName;
        private Label label2;
        private Button btnOk;
        private Button btnCancel;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        string EmpId { get; set; }
        string Password { get; set; }

        public frmVerifyByPwd(string _empId)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //

            EmpId = _empId;
        }

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.txtEmpNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPwd
            // 
            this.txtPwd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPwd.Location = new System.Drawing.Point(68, 97);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(148, 27);
            this.txtPwd.TabIndex = 14;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // txtEmpNo
            // 
            this.txtEmpNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpNo.Location = new System.Drawing.Point(68, 49);
            this.txtEmpNo.Name = "txtEmpNo";
            this.txtEmpNo.ReadOnly = true;
            this.txtEmpNo.Size = new System.Drawing.Size(148, 27);
            this.txtEmpNo.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "密码：";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.ForeColor = System.Drawing.Color.Red;
            this.lblName.Location = new System.Drawing.Point(68, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(148, 20);
            this.lblName.TabIndex = 12;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "工号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("宋体", 10F);
            this.btnOk.Location = new System.Drawing.Point(231, 46);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 31);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "确定 (&O)";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10F);
            this.btnCancel.Location = new System.Drawing.Point(231, 94);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "取消 (&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmVerifyByPwd
            // 
            this.ClientSize = new System.Drawing.Size(327, 140);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.txtEmpNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label2);
            this.KeyPreview = true;
            this.Name = "frmVerifyByPwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "密码认证";
            this.Load += new System.EventHandler(this.frmVerifyByPwd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmVerifyByPwd_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        bool Verify()
        {
            if (this.txtPwd.Text.Trim() == this.Password)
                return true;
            else
                return false;
        }

        private void frmVerifyByPwd_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            clsEmployeeVO[] data = null;
            clsDigitalSign_domain svc = new clsDigitalSign_domain();
            svc.m_lngGetDocByDepID(this.EmpId, out data);
            if (data != null && data.Length > 0)
            {
                this.lblName.Text = data[0].strLastName;
                this.txtEmpNo.Text = data[0].strEmpNO;
                System.Data.DataTable dt = svc.GetEmpInfo(data[0].strEmpNO);
                if (dt != null && dt.Rows.Count > 0)
                {
                    clsSymmetricAlgorithm objAlgorithm = new clsSymmetricAlgorithm();
                    this.Password = objAlgorithm.m_strDecrypt(dt.Rows[0]["psw_chr"].ToString(), clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES);
                    if (this.Password == null)
                        this.Password = "";
                    objAlgorithm = null;
                }
            }
            svc = null;
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Verify())
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void frmVerifyByPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
