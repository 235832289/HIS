using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.GLS_WS.Logic;
using com.digitalwave.iCare.ValueObject;
using DigitalWave;
using com.digitalwave.iCare.gui.RIS;

namespace com.digitalwave.GLS_WS.UI
{
	/// <summary>
	/// frmProject 的摘要说明。
	/// </summary>
    public class frmProject : BaseForm
	{
		#region Control Declaration

		private System.Windows.Forms.Label lblHLine;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public Label lblTitle;
		private System.Windows.Forms.TextBox txtCheckNO;
		private System.Windows.Forms.TextBox txtBIHNO;
		private System.Windows.Forms.TextBox txtExtraNO;
		private System.Windows.Forms.DateTimePicker dpApplyDate;
		private System.Windows.Forms.TextBox txtBalance;
		private System.Windows.Forms.TextBox txtDeposit;
		private System.Windows.Forms.TextBox txtCardNo;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtAge;
		private System.Windows.Forms.TextBox txtTel;
		private System.Windows.Forms.TextBox txtBedNO;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.TextBox txtSummary;
		private System.Windows.Forms.TextBox txtDiagnose;
		private System.Windows.Forms.TextBox txtDoctorName;
		private System.Windows.Forms.TextBox txtDoctorNO;
        private System.Windows.Forms.DateTimePicker txtFinishDate;
        public TextBox txtChargeDetail;
		private System.Windows.Forms.ComboBox cbArea;
		private System.Windows.Forms.ComboBox cbSex;
		private PinkieControls.ButtonXP btnSave;
		private PinkieControls.ButtonXP btnPrint;
		private System.Windows.Forms.TextBox txtCLINICNO;
		private System.Windows.Forms.ComboBox cbDepartment;
		private System.Windows.Forms.ComboBox cbDIAGNOSEPART;
		private System.Windows.Forms.ComboBox cbDIAGNOSEAIM;
		private PinkieControls.ButtonXP btnExit;
		private PinkieControls.ButtonXP btnSubmit;
		private PinkieControls.ButtonXP btnReport;
		private System.Windows.Forms.ContextMenu cmReport;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private PinkieControls.ButtonXP btnPrintPreview;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		#region Windows 窗体设计器生成的代码

		public static void Main()
		{		
			Application.Run(frmProject.Create());
			
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProject));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHLine = new System.Windows.Forms.Label();
            this.btnSave = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCheckNO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCLINICNO = new System.Windows.Forms.TextBox();
            this.txtBIHNO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtExtraNO = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtBedNO = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtDiagnose = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cbDIAGNOSEPART = new System.Windows.Forms.ComboBox();
            this.cbDIAGNOSEAIM = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtDoctorNO = new System.Windows.Forms.TextBox();
            this.txtFinishDate = new System.Windows.Forms.DateTimePicker();
            this.label40 = new System.Windows.Forms.Label();
            this.txtChargeDetail = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label43 = new System.Windows.Forms.Label();
            this.dpApplyDate = new System.Windows.Forms.DateTimePicker();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.cbSex = new System.Windows.Forms.ComboBox();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.btnExit = new PinkieControls.ButtonXP();
            this.btnSubmit = new PinkieControls.ButtonXP();
            this.btnReport = new PinkieControls.ButtonXP();
            this.cmReport = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.btnPrintPreview = new PinkieControls.ButtonXP();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(192, 88);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(216, 24);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "门诊通用检查申请单";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHLine
            // 
            this.lblHLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHLine.BackColor = System.Drawing.SystemColors.Desktop;
            this.lblHLine.Location = new System.Drawing.Point(0, 40);
            this.lblHLine.Name = "lblHLine";
            this.lblHLine.Size = new System.Drawing.Size(560, 1);
            this.lblHLine.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Hint = "";
            this.btnSave.Location = new System.Drawing.Point(12, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(72, 24);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存(&F2)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCheckNO);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCLINICNO);
            this.panel1.Controls.Add(this.txtBIHNO);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtExtraNO);
            this.panel1.Location = new System.Drawing.Point(408, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 112);
            this.panel1.TabIndex = 3;
            // 
            // txtCheckNO
            // 
            this.txtCheckNO.Location = new System.Drawing.Point(50, 9);
            this.txtCheckNO.Name = "txtCheckNO";
            this.txtCheckNO.Size = new System.Drawing.Size(64, 21);
            this.txtCheckNO.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "检查号";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "门诊号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCLINICNO
            // 
            this.txtCLINICNO.Location = new System.Drawing.Point(50, 33);
            this.txtCLINICNO.Name = "txtCLINICNO";
            this.txtCLINICNO.Size = new System.Drawing.Size(64, 21);
            this.txtCLINICNO.TabIndex = 1;
            // 
            // txtBIHNO
            // 
            this.txtBIHNO.Location = new System.Drawing.Point(50, 57);
            this.txtBIHNO.Name = "txtBIHNO";
            this.txtBIHNO.Size = new System.Drawing.Size(64, 21);
            this.txtBIHNO.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "住院号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "附加号";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExtraNO
            // 
            this.txtExtraNO.Location = new System.Drawing.Point(50, 81);
            this.txtExtraNO.Name = "txtExtraNO";
            this.txtExtraNO.Size = new System.Drawing.Size(64, 21);
            this.txtExtraNO.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 176);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(104, 21);
            this.txtName.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "姓    名";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "科    室";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(192, 176);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "性    别";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(192, 208);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 6;
            this.label12.Text = "病    区";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(424, 176);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(104, 21);
            this.txtAge.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(362, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "年    龄";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.GrayText;
            this.label15.Location = new System.Drawing.Point(8, 168);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(528, 1);
            this.label15.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.GrayText;
            this.label16.Location = new System.Drawing.Point(8, 200);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(528, 1);
            this.label16.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.GrayText;
            this.label17.Location = new System.Drawing.Point(8, 232);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(528, 1);
            this.label17.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.GrayText;
            this.label18.Location = new System.Drawing.Point(8, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(1, 512);
            this.label18.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.SystemColors.GrayText;
            this.label19.Location = new System.Drawing.Point(536, 168);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(1, 512);
            this.label19.TabIndex = 9;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(80, 240);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(160, 21);
            this.txtTel.TabIndex = 10;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(16, 240);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 12);
            this.label20.TabIndex = 6;
            this.label20.Text = "联系电话";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.GrayText;
            this.label21.Location = new System.Drawing.Point(72, 168);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(1, 96);
            this.label21.TabIndex = 9;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.GrayText;
            this.label22.Location = new System.Drawing.Point(192, 168);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(1, 64);
            this.label22.TabIndex = 9;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.GrayText;
            this.label23.Location = new System.Drawing.Point(248, 168);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(1, 96);
            this.label23.TabIndex = 9;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.GrayText;
            this.label24.Location = new System.Drawing.Point(360, 168);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(1, 96);
            this.label24.TabIndex = 9;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.SystemColors.GrayText;
            this.label25.Location = new System.Drawing.Point(416, 168);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1, 64);
            this.label25.TabIndex = 9;
            // 
            // txtBedNO
            // 
            this.txtBedNO.Location = new System.Drawing.Point(424, 208);
            this.txtBedNO.Name = "txtBedNO";
            this.txtBedNO.Size = new System.Drawing.Size(104, 21);
            this.txtBedNO.TabIndex = 9;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(362, 208);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 6;
            this.label26.Text = "床    号";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(280, 240);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 12);
            this.label27.TabIndex = 6;
            this.label27.Text = "家庭住址";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(368, 240);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(160, 21);
            this.txtAddress.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.GrayText;
            this.label28.Location = new System.Drawing.Point(8, 264);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(528, 1);
            this.label28.TabIndex = 8;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(16, 272);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 12);
            this.label29.TabIndex = 6;
            this.label29.Text = "病历摘要：";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSummary
            // 
            this.txtSummary.Location = new System.Drawing.Point(16, 289);
            this.txtSummary.Multiline = true;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSummary.Size = new System.Drawing.Size(512, 160);
            this.txtSummary.TabIndex = 12;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 464);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 6;
            this.label30.Text = "诊    断：";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.Location = new System.Drawing.Point(80, 464);
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.Size = new System.Drawing.Size(448, 21);
            this.txtDiagnose.TabIndex = 13;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.GrayText;
            this.label31.Location = new System.Drawing.Point(8, 456);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(528, 1);
            this.label31.TabIndex = 8;
            this.label31.Click += new System.EventHandler(this.label31_Click);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.GrayText;
            this.label32.Location = new System.Drawing.Point(8, 488);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(528, 1);
            this.label32.TabIndex = 8;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.SystemColors.GrayText;
            this.label33.Location = new System.Drawing.Point(8, 520);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(528, 1);
            this.label33.TabIndex = 8;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(16, 496);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(149, 12);
            this.label34.TabIndex = 6;
            this.label34.Text = "申请检查部位或送检组织：";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.GrayText;
            this.label36.Location = new System.Drawing.Point(8, 552);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(528, 1);
            this.label36.TabIndex = 8;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.SystemColors.GrayText;
            this.label37.Location = new System.Drawing.Point(8, 584);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(528, 1);
            this.label37.TabIndex = 8;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(16, 560);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(65, 12);
            this.label38.TabIndex = 6;
            this.label38.Text = "医生签名：";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(16, 528);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(149, 12);
            this.label35.TabIndex = 6;
            this.label35.Text = "申请检查目的或其它要发：";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDIAGNOSEPART
            // 
            this.cbDIAGNOSEPART.Location = new System.Drawing.Point(168, 496);
            this.cbDIAGNOSEPART.Name = "cbDIAGNOSEPART";
            this.cbDIAGNOSEPART.Size = new System.Drawing.Size(360, 20);
            this.cbDIAGNOSEPART.TabIndex = 14;
            // 
            // cbDIAGNOSEAIM
            // 
            this.cbDIAGNOSEAIM.Location = new System.Drawing.Point(168, 528);
            this.cbDIAGNOSEAIM.Name = "cbDIAGNOSEAIM";
            this.cbDIAGNOSEAIM.Size = new System.Drawing.Size(360, 20);
            this.cbDIAGNOSEAIM.TabIndex = 15;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(168, 560);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(65, 12);
            this.label39.TabIndex = 6;
            this.label39.Text = "医生工号：";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(80, 558);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.ReadOnly = true;
            this.txtDoctorName.Size = new System.Drawing.Size(64, 21);
            this.txtDoctorName.TabIndex = 16;
            this.txtDoctorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(376, 560);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(41, 12);
            this.label41.TabIndex = 6;
            this.label41.Text = "日期：";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label41.Visible = false;
            // 
            // txtDoctorNO
            // 
            this.txtDoctorNO.Location = new System.Drawing.Point(232, 558);
            this.txtDoctorNO.Name = "txtDoctorNO";
            this.txtDoctorNO.ReadOnly = true;
            this.txtDoctorNO.Size = new System.Drawing.Size(64, 21);
            this.txtDoctorNO.TabIndex = 17;
            this.txtDoctorNO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFinishDate
            // 
            this.txtFinishDate.Location = new System.Drawing.Point(416, 558);
            this.txtFinishDate.Name = "txtFinishDate";
            this.txtFinishDate.Size = new System.Drawing.Size(112, 21);
            this.txtFinishDate.TabIndex = 18;
            this.txtFinishDate.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(16, 592);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(65, 12);
            this.label40.TabIndex = 6;
            this.label40.Text = "收费信息：";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtChargeDetail
            // 
            this.txtChargeDetail.Location = new System.Drawing.Point(16, 608);
            this.txtChargeDetail.Multiline = true;
            this.txtChargeDetail.Name = "txtChargeDetail";
            this.txtChargeDetail.ReadOnly = true;
            this.txtChargeDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChargeDetail.Size = new System.Drawing.Size(512, 64);
            this.txtChargeDetail.TabIndex = 19;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.GrayText;
            this.label42.Location = new System.Drawing.Point(8, 680);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(528, 1);
            this.label42.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label43);
            this.panel2.Controls.Add(this.dpApplyDate);
            this.panel2.Controls.Add(this.txtBalance);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtDeposit);
            this.panel2.Controls.Add(this.txtCardNo);
            this.panel2.Location = new System.Drawing.Point(8, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 112);
            this.panel2.TabIndex = 2;
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(8, 8);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(56, 16);
            this.label43.TabIndex = 21;
            this.label43.Text = "诊疗卡号";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dpApplyDate
            // 
            this.dpApplyDate.Location = new System.Drawing.Point(64, 80);
            this.dpApplyDate.Name = "dpApplyDate";
            this.dpApplyDate.Size = new System.Drawing.Size(112, 21);
            this.dpApplyDate.TabIndex = 3;
            // 
            // txtBalance
            // 
            this.txtBalance.Location = new System.Drawing.Point(64, 56);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(112, 21);
            this.txtBalance.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "预 交 费";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "补 交 费";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "申请日期";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(64, 32);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(112, 21);
            this.txtDeposit.TabIndex = 1;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(64, 8);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(112, 21);
            this.txtCardNo.TabIndex = 0;
            // 
            // cbArea
            // 
            this.cbArea.Location = new System.Drawing.Point(256, 208);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(104, 20);
            this.cbArea.TabIndex = 8;
            // 
            // cbSex
            // 
            this.cbSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSex.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cbSex.Location = new System.Drawing.Point(256, 176);
            this.cbSex.Name = "cbSex";
            this.cbSex.Size = new System.Drawing.Size(104, 20);
            this.cbSex.TabIndex = 5;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(101, 8);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(72, 24);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "直接打印";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbDepartment
            // 
            this.cbDepartment.Location = new System.Drawing.Point(80, 208);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(104, 20);
            this.cbDepartment.TabIndex = 8;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(457, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(72, 24);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "退出(&ESC)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSubmit.DefaultScheme = true;
            this.btnSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSubmit.Hint = "";
            this.btnSubmit.Location = new System.Drawing.Point(279, 8);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSubmit.Size = new System.Drawing.Size(72, 24);
            this.btnSubmit.TabIndex = 20;
            this.btnSubmit.Text = "提交(&S)";
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnReport.DefaultScheme = true;
            this.btnReport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnReport.Enabled = false;
            this.btnReport.Hint = "";
            this.btnReport.Location = new System.Drawing.Point(368, 8);
            this.btnReport.Name = "btnReport";
            this.btnReport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnReport.Size = new System.Drawing.Size(72, 24);
            this.btnReport.TabIndex = 20;
            this.btnReport.Text = "报告(&R)";
            this.btnReport.Visible = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // cmReport
            // 
            this.cmReport.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "A";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "B";
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrintPreview.DefaultScheme = true;
            this.btnPrintPreview.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintPreview.Hint = "";
            this.btnPrintPreview.Location = new System.Drawing.Point(190, 8);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintPreview.Size = new System.Drawing.Size(72, 24);
            this.btnPrintPreview.TabIndex = 20;
            this.btnPrintPreview.Text = "打印预览";
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmProject
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(544, 693);
            this.Controls.Add(this.cbDIAGNOSEPART);
            this.Controls.Add(this.cbDIAGNOSEAIM);
            this.Controls.Add(this.txtFinishDate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtChargeDetail);
            this.Controls.Add(this.txtSummary);
            this.Controls.Add(this.txtDoctorNO);
            this.Controls.Add(this.txtDoctorName);
            this.Controls.Add(this.txtDiagnose);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtBedNO);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnPrintPreview);
            this.Controls.Add(this.cbSex);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblHLine);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cbDepartment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProject";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.frmProject_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmProject_Closing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		internal ProjectEditor editor = null;       	
		
		public frmProject()
		{
			InitializeComponent();		
			Initial();

		}	

		/// <summary>
		/// 初始化数据
		/// </summary>
		private void Initial()
		{           
			this.Text = lblTitle.Text;
		}

		/// <summary>
		/// 用静态方法创建对象，把私有成员与逻辑层绑定
		/// </summary>
		/// <returns></returns>
		public static frmProject Create()
		{		
			frmProject fm = new frmProject();
			//fm.editor = new ProjectEditor(fm);
			return fm;
		}				

		#region Events
        public string m_strFormTitle = string.Empty;
        /// <summary>
        /// 0-门诊;1-住院
        /// </summary>
        public int m_intFlag = 0;
		private void frmProject_Load(object sender, System.EventArgs e)
		{
            if (m_intFlag == 1)
            {
                this.Text = m_strFormTitle;
            }
		}
		private void label31_Click(object sender, System.EventArgs e)
		{
		
		}

		private void frmProject_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (m_intFlag == 1)
            {
                return;
            }
			if (editor.isChanged)
			{
				DialogResult d = this.ShowQuestion("申请单已更改，要保存吗？");
				if (d == DialogResult.Yes)
				{
					clsApplyForm.saveResult = editor.Save();
				}			
				else
				{
					e.Cancel = (d == DialogResult.Cancel);
				}
					
			}
		}		

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			this.editor.Print();						
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			clsApplyForm.saveResult = editor.Save();
		}


		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			//快捷方式
			switch(keyData)
			{
				case Keys.Escape:
					this.Close();	
					return true;
					break;
				case Keys.F2:
					if (btnSave.Enabled) 
					{
						this.btnSave_Click(null,null);
					}
					return true;
					break;
				case Keys.F4:
					this.btnPrint_Click(null, null);
					return true;
					break;
				default:
					return base.ProcessCmdKey (ref msg, keyData);
                
			}
		}

		#endregion

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			this.editor.Submit();
		}

		private void btnReport_Click(object sender, System.EventArgs e)
		{   
            
            //btnReport.ContextMenu = cmReport;
            //cmReport.Show(btnReport,new Point(0, btnReport.Height));
            //btnReport.ContextMenu = null;
            if (this.editor.m_intHeartType == 0) return;
            string strSQL = @"select a.*,b.patientcardid_chr,c.doctorname from t_opr_ris_cardiogram_report a,(select *
from t_bse_patientcard where status_int = 1 or status_int = 3) b,ar_common_apply c
where a.patient_id_chr=b.patientid_chr(+) and a.applyid_int = c.applyid  and c.applyid=" + this.editor.applyID;
            DataTable dtbResult = new DataTable();
            this.editor.m_mthGetDataTableBySQL(strSQL, ref dtbResult);
            if (dtbResult==null||dtbResult.Rows.Count == 0)
            {   
                clsDataQuery dq=new clsDataQuery();
                clsApplyRecord vo = dq.objGetVO(this.editor.applyID);
                frmCardiogramReport frmReport = new frmCardiogramReport();
                frmReport.m_mthSetShow(vo);
            }
            else
            {
                ReportVo = new clsRIS_CardiogramReport_VO();

                ReportVo.m_strCARD_ID_CHR = dtbResult.Rows[0]["patientcardid_chr"].ToString();
                ReportVo.m_strREPORT_ID_CHR = dtbResult.Rows[0]["REPORT_ID_CHR"].ToString().Trim();
                ReportVo.m_strMODIFY_DAT = Convert.ToDateTime(dtbResult.Rows[0]["MODIFY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                ReportVo.m_strREPORT_NO_CHR = dtbResult.Rows[0]["REPORT_NO_CHR"].ToString().Trim();
                ReportVo.m_strPATIENT_ID_CHR = dtbResult.Rows[0]["PATIENT_ID_CHR"].ToString().Trim();
                ReportVo.m_strPATIENT_NO_CHR = dtbResult.Rows[0]["PATIENT_NO_CHR"].ToString().Trim();
                ReportVo.m_strINPATIENT_NO_CHR = dtbResult.Rows[0]["INPATIENT_NO_CHR"].ToString().Trim();
                ReportVo.m_strPATIENT_NAME_VCHR = dtbResult.Rows[0]["PATIENT_NAME_VCHR"].ToString().Trim();
                ReportVo.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                ReportVo.m_strAGE_FLT = dtbResult.Rows[0]["AGE_FLT"].ToString().Trim();
                ReportVo.m_strCHECK_DAT = Convert.ToDateTime(dtbResult.Rows[0]["CHECK_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                ReportVo.m_strREPORT_DAT = Convert.ToDateTime(dtbResult.Rows[0]["REPORT_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
                ReportVo.m_strDEPT_ID_CHR = dtbResult.Rows[0]["DEPT_ID_CHR"].ToString().Trim();
                ReportVo.m_strDEPT_NAME_VCHR = dtbResult.Rows[0]["DEPT_NAME_VCHR"].ToString().Trim();
                ReportVo.m_intIS_INPATIENT_INT = Convert.ToInt32(dtbResult.Rows[0]["IS_INPATIENT_INT"].ToString().Trim());
                ReportVo.m_strBED_ID_CHR = dtbResult.Rows[0]["BED_ID_CHR"].ToString().Trim();
                ReportVo.m_strBED_NO_CHR = dtbResult.Rows[0]["BED_NO_CHR"].ToString().Trim();
                ReportVo.m_strCLINICAL_DIAGNOSE_VCHR = dtbResult.Rows[0]["CLINICAL_DIAGNOSE_VCHR"].ToString().Trim();
                ReportVo.m_strRHYTHM_VCHR = dtbResult.Rows[0]["RHYTHM_VCHR"].ToString().Trim();
                ReportVo.m_strHEART_RATE_VCHR = dtbResult.Rows[0]["HEART_RATE_VCHR"].ToString().Trim();
                ReportVo.m_strP_R_VCHR = dtbResult.Rows[0]["P_R_VCHR"].ToString().Trim();
                ReportVo.m_strQRS_VCHR = dtbResult.Rows[0]["QRS_VCHR"].ToString().Trim();
                ReportVo.m_strQ_T_VCHR = dtbResult.Rows[0]["Q_T_VCHR"].ToString().Trim();
                ReportVo.m_strSUMMARY1_VCHR = dtbResult.Rows[0]["SUMMARY1_VCHR"].ToString();//.ToString().Trim();
                ReportVo.m_strSUMMARY2_VCHR = dtbResult.Rows[0]["SUMMARY2_VCHR"].ToString();//.ToString().Trim();
                ReportVo.m_strREPORTOR_ID_CHR = dtbResult.Rows[0]["REPORTOR_ID_CHR"].ToString().Trim();
                ReportVo.m_strREPORTOR_NAME_VCHR = dtbResult.Rows[0]["REPORTOR_NAME_VCHR"].ToString().Trim();
                ReportVo.m_strCONFIRMER_ID_CHR = dtbResult.Rows[0]["CONFIRMER_ID_CHR"].ToString().Trim();
                ReportVo.m_strCONFIRMER_NAME_VCHR = dtbResult.Rows[0]["CONFIRMER_NAME_VCHR"].ToString().Trim();
                ReportVo.m_strHEART_ROOM_VCHR = dtbResult.Rows[0]["HEART_ROOM_VCHR"].ToString().Trim();
                ReportVo.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
                ReportVo.m_strOPERATOR_ID_CHR = dtbResult.Rows[0]["OPERATOR_ID_CHR"].ToString().Trim();
                ReportVo.m_strSUMMARY1_XML_VCHR = dtbResult.Rows[0]["SUMMARY1_XML_VCHR"].ToString().Trim();
                ReportVo.m_strSUMMARY2_XML_VCHR = dtbResult.Rows[0]["SUMMARY2_XML_VCHR"].ToString().Trim();
                ReportVo.m_strE_Axes_vchr = dtbResult.Rows[0]["E_AXES_VCHR"].ToString().Trim();
                ReportVo.m_strApplyDoctorName = dtbResult.Rows[0]["DOCTORNAME"].ToString().Trim();
                try
                {
                    ReportVo.m_intIsSpicalPatient = int.Parse(dtbResult.Rows[0]["SPECIALFLAG_INT"].ToString().Trim());

                }
                catch
                {
                    ReportVo.m_intIsSpicalPatient = 0;
                }
         
                ((Form)this.printPreviewDialog1).Text = "病人心电图报告";
                ((Form)this.printPreviewDialog1).Icon = this.Icon;
                ((Form)this.printPreviewDialog1).WindowState = FormWindowState.Maximized;
                this.printPreviewDialog1.PrintPreviewControl.Zoom = 1;
     
                this.printPreviewDialog1.ShowDialog();
                this.printPreviewDialog1.FormClosing += new FormClosingEventHandler(printPreviewDialog1_FormClosing);

            }

		}
        void printPreviewDialog1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }

        clsRIS_CardiogramReport_VO ReportVo;
		protected override bool ProcessDialogKey(Keys keyData)
		{
			if ((keyData == Keys.Enter) && (this.ActiveControl != txtSummary) )
			{
				System.Windows.Forms.SendKeys.Send("{tab}");
				return true;
			}
			else
			{
				return base.ProcessDialogKey (keyData);
			}
		}

		private void btnPrintPreview_Click(object sender, System.EventArgs e)
		{
			editor.PrintPreview();
		}

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            clsPrint_RISCardiogramReport objPrintReport = new clsPrint_RISCardiogramReport();
            objPrintReport.objReportVO = this.ReportVo;
            objPrintReport.m_mthInitPrintTool(null);
            objPrintReport.m_mthPrintPage(e);
        }
       
		
	}
}
