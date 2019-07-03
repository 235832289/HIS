namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmAntiConsultation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAntiConsultation));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.col1 = new System.Windows.Forms.ColumnHeader();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnDoct = new PinkieControls.ButtonXP();
            this.txtDoct = new System.Windows.Forms.TextBox();
            this.dtpDoct = new System.Windows.Forms.DateTimePicker();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.dwc = new Sybase.DataWindow.DataWindowControl();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbDel,
            this.toolStripSeparator3,
            this.tsbPrint,
            this.toolStripSeparator6,
            this.tsbClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(861, 39);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "工具栏";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(65, 36);
            this.tsbSave.Text = "保存";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbDel
            // 
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Size = new System.Drawing.Size(65, 36);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(65, 36);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(65, 36);
            this.tsbClose.Text = "关闭";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1});
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvHistory.Font = new System.Drawing.Font("宋体", 10F);
            this.lvHistory.Location = new System.Drawing.Point(0, 39);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(160, 792);
            this.lvHistory.TabIndex = 6;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.SelectedIndexChanged += new System.EventHandler(this.lvHistory_SelectedIndexChanged);
            // 
            // col1
            // 
            this.col1.Text = "申请记录";
            this.col1.Width = 135;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(363, 796);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 12);
            this.label12.TabIndex = 159;
            this.label12.Text = "会诊医师签名:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(577, 797);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 160;
            this.label13.Text = "签名日期:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(164, 644);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 161;
            this.label14.Text = "会诊意见:";
            // 
            // btnDoct
            // 
            this.btnDoct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnDoct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoct.DefaultScheme = true;
            this.btnDoct.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDoct.Font = new System.Drawing.Font("Arial Black", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoct.Hint = "";
            this.btnDoct.Location = new System.Drawing.Point(544, 789);
            this.btnDoct.Name = "btnDoct";
            this.btnDoct.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDoct.Size = new System.Drawing.Size(20, 28);
            this.btnDoct.TabIndex = 167;
            this.btnDoct.Text = "▼";
            // 
            // txtDoct
            // 
            this.txtDoct.Font = new System.Drawing.Font("宋体", 10F);
            this.txtDoct.Location = new System.Drawing.Point(448, 791);
            this.txtDoct.Name = "txtDoct";
            this.txtDoct.ReadOnly = true;
            this.txtDoct.Size = new System.Drawing.Size(95, 23);
            this.txtDoct.TabIndex = 166;
            // 
            // dtpDoct
            // 
            this.dtpDoct.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpDoct.CalendarForeColor = System.Drawing.Color.Black;
            this.dtpDoct.CalendarTitleForeColor = System.Drawing.Color.Black;
            this.dtpDoct.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDoct.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            this.dtpDoct.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDoct.Location = new System.Drawing.Point(640, 792);
            this.dtpDoct.Name = "dtpDoct";
            this.dtpDoct.Size = new System.Drawing.Size(172, 23);
            this.dtpDoct.TabIndex = 168;
            // 
            // txtCon
            // 
            this.txtCon.Font = new System.Drawing.Font("宋体", 10F);
            this.txtCon.Location = new System.Drawing.Point(220, 640);
            this.txtCon.Multiline = true;
            this.txtCon.Name = "txtCon";
            this.txtCon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCon.Size = new System.Drawing.Size(632, 136);
            this.txtCon.TabIndex = 173;
            // 
            // dwc
            // 
            this.dwc.DataWindowObject = "d_anticonsultation";
            this.dwc.LibraryList = "D:\\icare\\iCare_cs\\code\\Bin\\Debug\\pbreport.pbl";
            this.dwc.Location = new System.Drawing.Point(164, 40);
            this.dwc.Name = "dwc";
            this.dwc.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.Vertical;
            this.dwc.Size = new System.Drawing.Size(696, 592);
            this.dwc.TabIndex = 174;
            this.dwc.Text = "dataWindowControl1";
            // 
            // frmAntiConsultation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 831);
            this.Controls.Add(this.dwc);
            this.Controls.Add(this.txtCon);
            this.Controls.Add(this.dtpDoct);
            this.Controls.Add(this.btnDoct);
            this.Controls.Add(this.txtDoct);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.toolStrip);
            this.Name = "frmAntiConsultation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "特殊抗菌药会诊意见";
            this.Load += new System.EventHandler(this.frmAntiConsultation_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        internal PinkieControls.ButtonXP btnDoct;
        private System.Windows.Forms.TextBox txtDoct;
        private System.Windows.Forms.DateTimePicker dtpDoct;
        private System.Windows.Forms.TextBox txtCon;
        private Sybase.DataWindow.DataWindowControl dwc;
    }
}