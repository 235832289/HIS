namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmAidChoosePayType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAidChoosePayType));
            this.label1 = new System.Windows.Forms.Label();
            this.txtVal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtPayType = new System.Windows.Forms.DataGridView();
            this.colZt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new PinkieControls.ButtonXP();
            this.btnOk = new PinkieControls.ButtonXP();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtPayType)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找(编号/名称)：";
            // 
            // txtVal
            // 
            this.txtVal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVal.Location = new System.Drawing.Point(126, 6);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(186, 26);
            this.txtVal.TabIndex = 0;
            this.txtVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVal_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtPayType);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 675);
            this.panel1.TabIndex = 2;
            // 
            // dtPayType
            // 
            this.dtPayType.AllowUserToAddRows = false;
            this.dtPayType.AllowUserToDeleteRows = false;
            this.dtPayType.AllowUserToResizeRows = false;
            this.dtPayType.BackgroundColor = System.Drawing.Color.White;
            this.dtPayType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtPayType.ColumnHeadersHeight = 28;
            this.dtPayType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colZt,
            this.colNo,
            this.colBh,
            this.colMc});
            this.dtPayType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtPayType.Location = new System.Drawing.Point(0, 36);
            this.dtPayType.MultiSelect = false;
            this.dtPayType.Name = "dtPayType";
            this.dtPayType.RowHeadersVisible = false;
            this.dtPayType.RowTemplate.Height = 23;
            this.dtPayType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtPayType.Size = new System.Drawing.Size(316, 597);
            this.dtPayType.TabIndex = 10;
            // 
            // colZt
            // 
            this.colZt.FalseValue = "F";
            this.colZt.HeaderText = "状态";
            this.colZt.Name = "colZt";
            this.colZt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colZt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colZt.TrueValue = "T";
            this.colZt.Width = 45;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "NO.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 45;
            // 
            // colBh
            // 
            this.colBh.HeaderText = "编号";
            this.colBh.Name = "colBh";
            this.colBh.ReadOnly = true;
            this.colBh.Width = 80;
            // 
            // colMc
            // 
            this.colMc.HeaderText = "名称";
            this.colMc.Name = "colMc";
            this.colMc.ReadOnly = true;
            this.colMc.Width = 120;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtVal);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(316, 36);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 633);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(316, 42);
            this.panel2.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.DefaultScheme = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Hint = "";
            this.btnCancel.Location = new System.Drawing.Point(216, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCancel.Size = new System.Drawing.Size(76, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "放弃(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.DefaultScheme = true;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOk.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOk.Hint = "";
            this.btnOk.Location = new System.Drawing.Point(112, 4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOk.Size = new System.Drawing.Size(76, 32);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "确定(&O)";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // frmAidChoosePayType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 675);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAidChoosePayType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择费别";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAidChoosePayType_KeyDown);
            this.Load += new System.EventHandler(this.frmAidChoosePayType_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtPayType)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        internal PinkieControls.ButtonXP btnCancel;
        internal PinkieControls.ButtonXP btnOk;
        private System.Windows.Forms.DataGridView dtPayType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colZt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMc;
    }
}