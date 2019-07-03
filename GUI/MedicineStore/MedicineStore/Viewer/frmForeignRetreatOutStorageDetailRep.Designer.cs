namespace com.digitalwave.iCare.gui.MedicineStore
{
    partial class frmForeignRetreatOutStorageDetailRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForeignRetreatOutStorageDetailRep));
            this.m_cmdExit = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.datWindow = new Sybase.DataWindow.DataWindowControl();
            this.m_cmdPrint = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdExit
            // 
            this.m_cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdExit.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_cmdExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdExit.ImageIndex = 1;
            this.m_cmdExit.ImageList = this.imageList1;
            this.m_cmdExit.Location = new System.Drawing.Point(119, 6);
            this.m_cmdExit.Name = "m_cmdExit";
            this.m_cmdExit.Size = new System.Drawing.Size(94, 32);
            this.m_cmdExit.TabIndex = 203;
            this.m_cmdExit.Text = "退出(&Q)";
            this.m_cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdExit.UseVisualStyleBackColor = true;
            this.m_cmdExit.Click += new System.EventHandler(this.m_cmdExit_Click_1);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Shell32 007.ico");
            this.imageList1.Images.SetKeyName(1, "Shell32 028.ico");
            this.imageList1.Images.SetKeyName(2, "Shell32 132.ico");
            this.imageList1.Images.SetKeyName(3, "Shell32 148.ico");
            this.imageList1.Images.SetKeyName(4, "Shell32 058.ico");
            this.imageList1.Images.SetKeyName(5, "m_cmdRefresh.Image.png");
            this.imageList1.Images.SetKeyName(6, "Shell32 137.ico");
            this.imageList1.Images.SetKeyName(7, "Shell32 177.ico");
            this.imageList1.Images.SetKeyName(8, "Shell32 136.ico");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.datWindow);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(821, 415);
            this.panel2.TabIndex = 6;
            // 
            // datWindow
            // 
            this.datWindow.DataWindowObject = "foreignretreatoutstorage_lj";
            this.datWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datWindow.LibraryList = "D:\\icare_ver2\\code\\BIN\\Debug\\pb_ms.pbl";
            this.datWindow.Location = new System.Drawing.Point(0, 0);
            this.datWindow.Name = "datWindow";
            this.datWindow.ScrollBars = Sybase.DataWindow.DataWindowScrollBars.VerticalAndHorizontalSplit;
            this.datWindow.Size = new System.Drawing.Size(821, 415);
            this.datWindow.TabIndex = 0;
            this.datWindow.Text = "dataWindowControl1";
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_cmdPrint.ImageIndex = 6;
            this.m_cmdPrint.ImageList = this.imageList1;
            this.m_cmdPrint.Location = new System.Drawing.Point(12, 6);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Size = new System.Drawing.Size(94, 32);
            this.m_cmdPrint.TabIndex = 202;
            this.m_cmdPrint.Text = "打印(&P)";
            this.m_cmdPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_cmdPrint.UseVisualStyleBackColor = true;
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdExit);
            this.panel1.Controls.Add(this.m_cmdPrint);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(821, 44);
            this.panel1.TabIndex = 5;
            // 
            // frmForeignRetreatOutStorageDetailRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 459);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmForeignRetreatOutStorageDetailRep";
            this.Text = "药库退货单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmForeignRetreatOutStorageDetailRep_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_cmdExit;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        public Sybase.DataWindow.DataWindowControl datWindow;
        private System.Windows.Forms.Button m_cmdPrint;
        private System.Windows.Forms.Panel panel1;

    }
}