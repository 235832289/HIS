using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// frmShowReports 的摘要说明。
    /// </summary>
    public class frmShowReports : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtSex;
        internal System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label4;
        private PinkieControls.ButtonXP btPrint;
        private PinkieControls.ButtonXP btClose;
        internal System.Drawing.Printing.PrintDocument printDocument1;
        internal System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        internal System.Windows.Forms.PictureBox m_picBadge;
        internal PinkieControls.ButtonXP btOpenImage;
        internal com.digitalwave.controls.Control.MyPrintPreViewControl printPreviewControl;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;
        private Label label5;
        internal TextBox m_txtInpatNo;
        internal com.digitalwave.controls.clsCardTextBox txtCardID;
        internal WebBrowser webBrowser;
        internal Label lblPacsHint;
        internal PictureBox picBL;
        internal FlowLayoutPanel fpnlBL;
        private string CardID = "";

        public frmShowReports()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
        }

        public frmShowReports(string p_strCardID)
        {
            InitializeComponent();

            CardID = p_strCardID;
        }

        #region 属性设置
        /// <summary>
        /// 设置病人卡号
        /// </summary>
        public string PatientCardID
        {
            set
            {
                this.txtCardID.Text = value;

            }
        }
        public string InHospitalNO
        {
            set
            {
                ((clsCtl_ShowReports)this.objController).m_mthFindPatientIDByInHospitalNo(value);
            }
        }
        public string PatientID
        {
            set
            {
                ((clsCtl_ShowReports)this.objController).m_mthLoadNodes(value);
            }
        }
        public string PatientSex
        {
            set
            {
                this.txtSex.Text = value;
            }
        }
        public string PatientName
        {
            set
            {
                this.txtName.Text = value;
            }
        }
        public string PatientAge
        {
            set
            {
                this.txtAge.Text = value;
            }
        }
        public bool ReadOnly
        {
            set
            {
                this.txtCardID.ReadOnly = value;
                this.txtName.ReadOnly = value;
                this.m_txtInpatNo.ReadOnly = value;
            }
        }
        #endregion
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
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_ShowReports();
            objController.Set_GUI_Apperance(this);
        }
        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowReports));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCardID = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtInpatNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btOpenImage = new PinkieControls.ButtonXP();
            this.btClose = new PinkieControls.ButtonXP();
            this.btPrint = new PinkieControls.ButtonXP();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.printPreviewControl = new com.digitalwave.controls.Control.MyPrintPreViewControl();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lblPacsHint = new System.Windows.Forms.Label();
            this.picBL = new System.Windows.Forms.PictureBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.m_picBadge = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.fpnlBL = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBadge)).BeginInit();
            this.fpnlBL.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtCardID);
            this.panel1.Controls.Add(this.m_txtInpatNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btOpenImage);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Controls.Add(this.btPrint);
            this.panel1.Controls.Add(this.txtAge);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSex);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 48);
            this.panel1.TabIndex = 0;
            // 
            // txtCardID
            // 
            this.txtCardID.Location = new System.Drawing.Point(60, 16);
            this.txtCardID.MaxLength = 18;
            this.txtCardID.Name = "txtCardID";
            this.txtCardID.PatientCard = "";
            this.txtCardID.PatientFlag = 0;
            this.txtCardID.Size = new System.Drawing.Size(100, 23);
            this.txtCardID.TabIndex = 15;
            this.txtCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCardID.YBCardText = "";
            this.txtCardID.CardKeyDown += new com.digitalwave.controls.clsCardTextBox.TxtKeyDownHandle(this.txtCardID1_CardKeyDown);
            // 
            // m_txtInpatNo
            // 
            this.m_txtInpatNo.Location = new System.Drawing.Point(228, 16);
            this.m_txtInpatNo.Name = "m_txtInpatNo";
            this.m_txtInpatNo.Size = new System.Drawing.Size(100, 23);
            this.m_txtInpatNo.TabIndex = 14;
            this.m_txtInpatNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtInpatNo_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "住院号:";
            // 
            // btOpenImage
            // 
            this.btOpenImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btOpenImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btOpenImage.DefaultScheme = true;
            this.btOpenImage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOpenImage.Hint = "";
            this.btOpenImage.Location = new System.Drawing.Point(705, 10);
            this.btOpenImage.Name = "btOpenImage";
            this.btOpenImage.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOpenImage.Size = new System.Drawing.Size(88, 32);
            this.btOpenImage.TabIndex = 12;
            this.btOpenImage.Text = "打开图像";
            this.btOpenImage.Click += new System.EventHandler(this.btOpenImage_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btClose.DefaultScheme = true;
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btClose.Hint = "";
            this.btClose.Location = new System.Drawing.Point(920, 10);
            this.btClose.Name = "btClose";
            this.btClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btClose.Size = new System.Drawing.Size(88, 32);
            this.btClose.TabIndex = 9;
            this.btClose.Text = "关闭(&C)";
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btPrint.DefaultScheme = true;
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btPrint.Hint = "";
            this.btPrint.Location = new System.Drawing.Point(811, 10);
            this.btPrint.Name = "btPrint";
            this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btPrint.Size = new System.Drawing.Size(88, 32);
            this.btPrint.TabIndex = 8;
            this.btPrint.Text = "打印(&P)";
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(628, 16);
            this.txtAge.Name = "txtAge";
            this.txtAge.ReadOnly = true;
            this.txtAge.Size = new System.Drawing.Size(56, 23);
            this.txtAge.TabIndex = 7;
            this.txtAge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(584, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "年龄:";
            // 
            // txtSex
            // 
            this.txtSex.Location = new System.Drawing.Point(520, 16);
            this.txtSex.Name = "txtSex";
            this.txtSex.ReadOnly = true;
            this.txtSex.Size = new System.Drawing.Size(56, 23);
            this.txtSex.TabIndex = 5;
            this.txtSex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(476, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(380, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(88, 23);
            this.txtName.TabIndex = 3;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡 号:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 584);
            this.panel2.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(0, 1);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(373, 578);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblPacsHint);
            this.panel3.Controls.Add(this.printPreviewControl);
            this.panel3.Controls.Add(this.fpnlBL);
            this.panel3.Controls.Add(this.webBrowser);
            this.panel3.Controls.Add(this.m_picBadge);
            this.panel3.Location = new System.Drawing.Point(208, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(806, 578);
            this.panel3.TabIndex = 2;
            // 
            // printPreviewControl
            // 
            this.printPreviewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printPreviewControl.Document = this.printDocument1;
            this.printPreviewControl.Location = new System.Drawing.Point(0, 0);
            this.printPreviewControl.Name = "printPreviewControl";
            this.printPreviewControl.ShowPannel = true;
            this.printPreviewControl.ShowPrintButton = true;
            this.printPreviewControl.Size = new System.Drawing.Size(352, 574);
            this.printPreviewControl.TabIndex = 39;
            this.printPreviewControl.Zoom = 1;
            this.printPreviewControl.Load += new System.EventHandler(this.printPreviewControl1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // lblPacsHint
            // 
            this.lblPacsHint.AutoSize = true;
            this.lblPacsHint.BackColor = System.Drawing.Color.White;
            this.lblPacsHint.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPacsHint.ForeColor = System.Drawing.Color.Blue;
            this.lblPacsHint.Location = new System.Drawing.Point(324, 284);
            this.lblPacsHint.Name = "lblPacsHint";
            this.lblPacsHint.Size = new System.Drawing.Size(289, 57);
            this.lblPacsHint.TabIndex = 1;
            this.lblPacsHint.Text = "报告未出，请以影像图片为准。\r\n\r\n(点击“打开图像”按钮浏览)";
            this.lblPacsHint.Visible = false;
            // 
            // picBL
            // 
            this.picBL.Location = new System.Drawing.Point(3, 3);
            this.picBL.Name = "picBL";
            this.picBL.Size = new System.Drawing.Size(52, 42);
            this.picBL.TabIndex = 41;
            this.picBL.TabStop = false;
            this.picBL.Visible = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Right;
            this.webBrowser.Location = new System.Drawing.Point(552, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(250, 574);
            this.webBrowser.TabIndex = 40;
            this.webBrowser.Visible = false;
            // 
            // m_picBadge
            // 
            this.m_picBadge.Image = ((System.Drawing.Image)(resources.GetObject("m_picBadge.Image")));
            this.m_picBadge.Location = new System.Drawing.Point(48, 32);
            this.m_picBadge.Name = "m_picBadge";
            this.m_picBadge.Size = new System.Drawing.Size(112, 48);
            this.m_picBadge.TabIndex = 38;
            this.m_picBadge.TabStop = false;
            this.m_picBadge.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(64, -24);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(260, 104);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.Leave += new System.EventHandler(this.listView1_Leave);
            this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 77;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 74;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 42;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 41;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 0;
            // 
            // fpnlBL
            // 
            this.fpnlBL.AutoScroll = true;
            this.fpnlBL.Controls.Add(this.picBL);
            this.fpnlBL.Dock = System.Windows.Forms.DockStyle.Right;
            this.fpnlBL.Location = new System.Drawing.Point(352, 0);
            this.fpnlBL.Name = "fpnlBL";
            this.fpnlBL.Size = new System.Drawing.Size(200, 574);
            this.fpnlBL.TabIndex = 42;
            // 
            // frmShowReports
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1022, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmShowReports";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人报告查询";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowReports_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBadge)).EndInit();
            this.fpnlBL.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void btClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //			switch(this.comboBox1.SelectedIndex)
            //			{
            //				case 0:
            //					this.printPreviewControl1.Zoom=0.5;
            //					break;
            //				case 1:
            //					this.printPreviewControl1.Zoom=1;
            //					break;
            //				case 2:
            //					this.printPreviewControl1.Zoom=1.5;
            //					break;
            //				case 3:
            //					this.printPreviewControl1.Zoom=2;
            //					break;
            //			}
        }

        private void frmShowReports_Load(object sender, System.EventArgs e)
        {
            this.Controls.Add(this.listView1);

            if (CardID != "")
            {
                txtCardID.Text = CardID;
                ((clsCtl_ShowReports)this.objController).m_mthFindPatientInfo(1, CardID);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsCtl_ShowReports)this.objController).m_mthPrintPreView(e);
        }

        private void treeView1_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_ShowReports)this.objController).m_mthDoubleClick();
        }

        private void btPrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (this.printPreviewControl.Visible)
                    this.printDocument1.Print();
                else
                    this.webBrowser.Print();
            }
            catch
            {
                MessageBox.Show("打印出错,请检查是否安装打印机!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (txtName.Text.Trim() != "" && e.KeyCode == Keys.Enter && txtName.ReadOnly == false)
            {
                ((clsCtl_ShowReports)this.objController).m_mthFindPatientInfo(2, txtName.Text);
            }
        }

        private void listView1_Leave(object sender, System.EventArgs e)
        {
            this.listView1.Hide();
        }

        private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.listView1_DoubleClick(null, null);
            }
        }

        private void listView1_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsCtl_ShowReports)this.objController).m_mthListViewDoubleClick();
        }

        private void btOpenImage_Click(object sender, System.EventArgs e)
        {
            ((clsCtl_ShowReports)this.objController).m_mthOpenImage();
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsCtl_ShowReports)this.objController).m_mthBeginPrint(e);
        }

        private void printPreviewControl1_Load(object sender, System.EventArgs e)
        {

        }

        private void m_txtInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_txtInpatNo.Text.Trim() != "" && e.KeyCode == Keys.Enter && m_txtInpatNo.ReadOnly == false)
            {
                string strPatCardNo = ((clsCtl_ShowReports)this.objController).m_strGetPatientIDByInPatNo(m_txtInpatNo.Text.Trim());
                if (string.IsNullOrEmpty(strPatCardNo))
                {
                    MessageBox.Show("该住院号不存在", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ((clsCtl_ShowReports)this.objController).m_mthFindPatientInfo(1, strPatCardNo);
                }
            }
        }

        private void txtCardID1_CardKeyDown(object sender, EventArgs e)
        {
            if (txtCardID.Text.Trim() != "" && txtCardID.ReadOnly == false)
            {
                txtCardID.Text = txtCardID.Text.PadLeft(10, '0');
                ((clsCtl_ShowReports)this.objController).m_mthFindPatientInfo(1, txtCardID.Text);
            }
        }

    }

    #region PacsBrowser
    /// <summary>
    /// PacsBrowser
    /// </summary>
    public class PacsBrowser
    {
        public PacsBrowser()
        {
        }

        public void Show()
        {
            try
            {
                foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                {
                    if (p.ProcessName.Trim().ToLower() == "bvpacscws")
                    {
                        return;
                    }
                }
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.StartInfo.FileName = Application.StartupPath + @"\PACSCWS\BVPACSCWS.exe";
                pro.StartInfo.Arguments = string.Empty;
                pro.Start();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("PACS阅片功能不可用。\r\n" + ex.Message, "系统提示");
            }
        }
    }

    #endregion
}
