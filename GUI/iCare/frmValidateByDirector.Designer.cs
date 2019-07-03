namespace iCare
{
    partial class frmValidateByDirector
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidateByDirector));
            this.label3 = new System.Windows.Forms.Label();
            this.lblM = new System.Windows.Forms.Label();
            this.btnDirector = new PinkieControls.ButtonXP();
            this.txtDirectror = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(0, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 2);
            this.label3.TabIndex = 8;
            // 
            // lblM
            // 
            this.lblM.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblM.ForeColor = System.Drawing.Color.Red;
            this.lblM.Location = new System.Drawing.Point(0, 93);
            this.lblM.Name = "lblM";
            this.lblM.Size = new System.Drawing.Size(338, 32);
            this.lblM.TabIndex = 7;
            this.lblM.Text = "    提示：要继续进行操作，需要本科室领导(科主任/护士长)进行签名确认方可进行。否则只能中止或取消操作";
            // 
            // btnDirector
            // 
            this.btnDirector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnDirector.DefaultScheme = true;
            this.btnDirector.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDirector.ForeColor = System.Drawing.Color.Black;
            this.btnDirector.Hint = "";
            this.btnDirector.Location = new System.Drawing.Point(2, 12);
            this.btnDirector.Name = "btnDirector";
            this.btnDirector.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDirector.Size = new System.Drawing.Size(86, 28);
            this.btnDirector.TabIndex = 10000008;
            this.btnDirector.Text = "上级领导签名";
            // 
            // txtDirectror
            // 
            this.txtDirectror.BackColor = System.Drawing.Color.White;
            this.txtDirectror.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDirectror.Location = new System.Drawing.Point(94, 16);
            this.txtDirectror.Name = "txtDirectror";
            this.txtDirectror.ReadOnly = true;
            this.txtDirectror.Size = new System.Drawing.Size(94, 23);
            this.txtDirectror.TabIndex = 10000009;
            this.toolTip1.SetToolTip(this.txtDirectror, "单击按钮选择上级领导签名");
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(180, 52);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10000010;
            this.btnOk.Text = "确认";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(261, 52);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10000011;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmValidateByDirector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 125);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtDirectror);
            this.Controls.Add(this.btnDirector);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblM);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmValidateByDirector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "科主任/护士长签名确认";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblM;
        private PinkieControls.ButtonXP btnDirector;
        private System.Windows.Forms.TextBox txtDirectror;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}