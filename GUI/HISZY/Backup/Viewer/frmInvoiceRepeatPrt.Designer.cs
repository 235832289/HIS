namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmInvoiceRepeatPrt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoiceRepeatPrt));
            this.dwInvoice = new Sybase.DataWindow.DataWindowControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvInvoice = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnReturn = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnChange = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dwInvoice
            // 
            this.dwInvoice.BorderStyle = Sybase.DataWindow.DataWindowBorderStyle.None;
            this.dwInvoice.DataWindowObject = "";
            this.dwInvoice.LibraryList = "";
            this.dwInvoice.Location = new System.Drawing.Point(16, 51);
            this.dwInvoice.Name = "dwInvoice";
            this.dwInvoice.Size = new System.Drawing.Size(715, 408);
            this.dwInvoice.TabIndex = 0;
            this.dwInvoice.Text = "dataWindowControl1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dwInvoice);
            this.panel1.Location = new System.Drawing.Point(180, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 528);
            this.panel1.TabIndex = 1;
            // 
            // lsvInvoice
            // 
            this.lsvInvoice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lsvInvoice.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvInvoice.FullRowSelect = true;
            this.lsvInvoice.HideSelection = false;
            this.lsvInvoice.Location = new System.Drawing.Point(0, 44);
            this.lsvInvoice.MultiSelect = false;
            this.lsvInvoice.Name = "lsvInvoice";
            this.lsvInvoice.Size = new System.Drawing.Size(180, 528);
            this.lsvInvoice.SmallImageList = this.imageList1;
            this.lsvInvoice.TabIndex = 2;
            this.lsvInvoice.UseCompatibleStateImageBehavior = false;
            this.lsvInvoice.View = System.Windows.Forms.View.Details;
            this.lsvInvoice.SelectedIndexChanged += new System.EventHandler(this.lsvInvoice_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "状态";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "发票号";
            this.columnHeader3.Width = 110;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "a123.bmp");
            this.imageList1.Images.SetKeyName(1, "123.GIF");
            this.imageList1.Images.SetKeyName(2, "note.gif");
            this.imageList1.Images.SetKeyName(3, "letter.ico");
            // 
            // btnReturn
            // 
            this.btnReturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnReturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReturn.DefaultScheme = true;
            this.btnReturn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReturn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReturn.Hint = "";
            this.btnReturn.Location = new System.Drawing.Point(821, 6);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReturn.Size = new System.Drawing.Size(92, 32);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "返回(&R)";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(699, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(92, 32);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnChange
            // 
            this.btnChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChange.DefaultScheme = true;
            this.btnChange.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnChange.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnChange.Hint = "";
            this.btnChange.Location = new System.Drawing.Point(577, 6);
            this.btnChange.Name = "btnChange";
            this.btnChange.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnChange.Size = new System.Drawing.Size(92, 32);
            this.btnChange.TabIndex = 11;
            this.btnChange.Text = "换号(&C)";
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "发票列表：";
            // 
            // frmInvoiceRepeatPrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lsvInvoice);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmInvoiceRepeatPrt";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发票打印窗口";
            this.Load += new System.EventHandler(this.frmInvoiceRepeatPrt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvoiceRepeatPrt_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal Sybase.DataWindow.DataWindowControl dwInvoice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvInvoice;
        internal PinkieControls.ButtonXP btnReturn;
        internal PinkieControls.ButtonXP btnPrint;
        internal PinkieControls.ButtonXP btnChange;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}