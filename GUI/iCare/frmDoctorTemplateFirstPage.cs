using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using System.Xml;
using System.IO;
using System.Text;
using System.Data ;
using CrystalDecisions.CrystalReports.Engine ;

namespace iCare
{
	/// <summary>
	/// Summary description for frmDoctorTemplateFirstPage.
	/// </summary>
	public class frmDoctorTemplateFirstPage : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.TreeView trvEightSystem;
		private System.Windows.Forms.PictureBox m_picEightSystem;
		private System.Windows.Forms.Label label1;
		protected System.Windows.Forms.Label m_lblTempICD;
		protected System.Windows.Forms.Label m_lblTempID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtTempName;
		protected System.Windows.Forms.CheckBox m_chkEditable;
		protected System.Windows.Forms.GroupBox m_gpbAvailableIn;
		protected System.Windows.Forms.RadioButton m_rdbDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPublic;
		protected System.Windows.Forms.CheckedListBox m_lstDepartment;
		protected System.Windows.Forms.RadioButton m_rdbPrivate;
		protected System.Windows.Forms.Label lblTempIDTitle;
		protected System.Windows.Forms.Label lblTempName;
		protected System.Windows.Forms.Label lblTempICDTitle;
		private System.Windows.Forms.Label m_lblItem1;
		private System.Windows.Forms.Label m_lblItem2;
		private System.Windows.Forms.Label m_lblItem4;
		private System.Windows.Forms.Label m_lblItem3;
		private System.Windows.Forms.Label m_lblItem6;
		private System.Windows.Forms.Label m_lblItem7;
		private System.Windows.Forms.Label m_lblItem8;
		private System.Windows.Forms.Label m_lblItem5;
		private System.Windows.Forms.Label m_lblItem11;
		private System.Windows.Forms.Label m_lblItem12;
		private System.Windows.Forms.Label m_lblItem9;
		private System.Windows.Forms.Label m_lblItem13;
		private System.Windows.Forms.Label m_lblItem10;
		private System.Windows.Forms.Label m_lblItem14;
		private System.Windows.Forms.Label m_lblItem17;
		private System.Windows.Forms.Label m_lblItem15;
		private System.Windows.Forms.Label m_lblItem16;
		private System.Windows.Forms.Label m_lblItem18;
		private System.Windows.Forms.Label m_lblItem19;
		private System.Windows.Forms.ContextMenu ctmEightSystem;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDoctorTemplateFirstPage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.trvEightSystem,this.m_picEightSystem,this.trvEightSystem });	

			m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

		}
		protected ctlHighLightFocus m_objHighLight;

        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;
		private bool bolIfDrawSystem=false;
		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDoctorTemplateFirstPage));
			this.trvEightSystem = new System.Windows.Forms.TreeView();
			this.m_picEightSystem = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_lblTempICD = new System.Windows.Forms.Label();
			this.m_lblTempID = new System.Windows.Forms.Label();
			this.m_txtTempName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_chkEditable = new System.Windows.Forms.CheckBox();
			this.m_gpbAvailableIn = new System.Windows.Forms.GroupBox();
			this.m_rdbDepartment = new System.Windows.Forms.RadioButton();
			this.m_rdbPublic = new System.Windows.Forms.RadioButton();
			this.m_lstDepartment = new System.Windows.Forms.CheckedListBox();
			this.m_rdbPrivate = new System.Windows.Forms.RadioButton();
			this.lblTempIDTitle = new System.Windows.Forms.Label();
			this.lblTempName = new System.Windows.Forms.Label();
			this.lblTempICDTitle = new System.Windows.Forms.Label();
			this.m_lblItem1 = new System.Windows.Forms.Label();
			this.m_lblItem2 = new System.Windows.Forms.Label();
			this.m_lblItem4 = new System.Windows.Forms.Label();
			this.m_lblItem3 = new System.Windows.Forms.Label();
			this.m_lblItem6 = new System.Windows.Forms.Label();
			this.m_lblItem7 = new System.Windows.Forms.Label();
			this.m_lblItem8 = new System.Windows.Forms.Label();
			this.m_lblItem5 = new System.Windows.Forms.Label();
			this.m_lblItem11 = new System.Windows.Forms.Label();
			this.m_lblItem12 = new System.Windows.Forms.Label();
			this.m_lblItem9 = new System.Windows.Forms.Label();
			this.m_lblItem13 = new System.Windows.Forms.Label();
			this.m_lblItem10 = new System.Windows.Forms.Label();
			this.m_lblItem14 = new System.Windows.Forms.Label();
			this.m_lblItem15 = new System.Windows.Forms.Label();
			this.m_lblItem16 = new System.Windows.Forms.Label();
			this.m_lblItem17 = new System.Windows.Forms.Label();
			this.m_lblItem18 = new System.Windows.Forms.Label();
			this.m_lblItem19 = new System.Windows.Forms.Label();
			this.ctmEightSystem = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.m_gpbAvailableIn.SuspendLayout();
			this.SuspendLayout();
			// 
			// trvEightSystem
			// 
			this.trvEightSystem.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.trvEightSystem.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvEightSystem.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvEightSystem.ForeColor = System.Drawing.SystemColors.Window;
			this.trvEightSystem.ImageIndex = -1;
			this.trvEightSystem.ItemHeight = 18;
			this.trvEightSystem.Location = new System.Drawing.Point(4, 60);
			this.trvEightSystem.Name = "trvEightSystem";
			this.trvEightSystem.SelectedImageIndex = -1;
			this.trvEightSystem.ShowRootLines = false;
			this.trvEightSystem.Size = new System.Drawing.Size(232, 608);
			this.trvEightSystem.TabIndex = 511;
			this.trvEightSystem.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvEightSystem_AfterSelect);
			// 
			// m_picEightSystem
			// 
			this.m_picEightSystem.Location = new System.Drawing.Point(240, 200);
			this.m_picEightSystem.Name = "m_picEightSystem";
			this.m_picEightSystem.Size = new System.Drawing.Size(460, 468);
			this.m_picEightSystem.TabIndex = 512;
			this.m_picEightSystem.TabStop = false;
			this.m_picEightSystem.Paint += new System.Windows.Forms.PaintEventHandler(this.m_picEightSystem_Paint);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("SimSun", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(268, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(427, 40);
			this.label1.TabIndex = 513;
			this.label1.Text = "医生模板---八大系统分类";
			// 
			// m_lblTempICD
			// 
			this.m_lblTempICD.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lblTempICD.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblTempICD.ForeColor = System.Drawing.SystemColors.Window;
			this.m_lblTempICD.Location = new System.Drawing.Point(332, 112);
			this.m_lblTempICD.Name = "m_lblTempICD";
			this.m_lblTempICD.Size = new System.Drawing.Size(328, 20);
			this.m_lblTempICD.TabIndex = 516;
			// 
			// m_lblTempID
			// 
			this.m_lblTempID.Location = new System.Drawing.Point(332, 72);
			this.m_lblTempID.Name = "m_lblTempID";
			this.m_lblTempID.Size = new System.Drawing.Size(88, 19);
			this.m_lblTempID.TabIndex = 514;
			// 
			// m_txtTempName
			// 
			this.m_txtTempName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtTempName.BorderColor = System.Drawing.Color.White;
			this.m_txtTempName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtTempName.ForeColor = System.Drawing.Color.White;
			this.m_txtTempName.Location = new System.Drawing.Point(512, 68);
			this.m_txtTempName.Name = "m_txtTempName";
			this.m_txtTempName.Size = new System.Drawing.Size(148, 26);
			this.m_txtTempName.TabIndex = 515;
			this.m_txtTempName.Text = "";
			// 
			// m_chkEditable
			// 
			this.m_chkEditable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkEditable.Location = new System.Drawing.Point(244, 152);
			this.m_chkEditable.Name = "m_chkEditable";
			this.m_chkEditable.Size = new System.Drawing.Size(228, 32);
			this.m_chkEditable.TabIndex = 517;
			this.m_chkEditable.Text = "可否供他人修改(\"√\" 可)";
			// 
			// m_gpbAvailableIn
			// 
			this.m_gpbAvailableIn.Controls.AddRange(new System.Windows.Forms.Control[] {
																						   this.m_rdbDepartment,
																						   this.m_rdbPublic,
																						   this.m_lstDepartment,
																						   this.m_rdbPrivate});
			this.m_gpbAvailableIn.Location = new System.Drawing.Point(672, 72);
			this.m_gpbAvailableIn.Name = "m_gpbAvailableIn";
			this.m_gpbAvailableIn.Size = new System.Drawing.Size(344, 116);
			this.m_gpbAvailableIn.TabIndex = 518;
			this.m_gpbAvailableIn.TabStop = false;
			this.m_gpbAvailableIn.Text = "适用范围";
			// 
			// m_rdbDepartment
			// 
			this.m_rdbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbDepartment.Location = new System.Drawing.Point(12, 84);
			this.m_rdbDepartment.Name = "m_rdbDepartment";
			this.m_rdbDepartment.Size = new System.Drawing.Size(92, 22);
			this.m_rdbDepartment.TabIndex = 100;
			this.m_rdbDepartment.Text = "科室使用";
			// 
			// m_rdbPublic
			// 
			this.m_rdbPublic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbPublic.Location = new System.Drawing.Point(12, 52);
			this.m_rdbPublic.Name = "m_rdbPublic";
			this.m_rdbPublic.Size = new System.Drawing.Size(56, 26);
			this.m_rdbPublic.TabIndex = 95;
			this.m_rdbPublic.Text = "公用";
			// 
			// m_lstDepartment
			// 
			this.m_lstDepartment.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lstDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lstDepartment.CheckOnClick = true;
			this.m_lstDepartment.ForeColor = System.Drawing.Color.White;
			this.m_lstDepartment.Location = new System.Drawing.Point(112, 28);
			this.m_lstDepartment.Name = "m_lstDepartment";
			this.m_lstDepartment.Size = new System.Drawing.Size(224, 84);
			this.m_lstDepartment.TabIndex = 105;
			// 
			// m_rdbPrivate
			// 
			this.m_rdbPrivate.Checked = true;
			this.m_rdbPrivate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbPrivate.Location = new System.Drawing.Point(12, 24);
			this.m_rdbPrivate.Name = "m_rdbPrivate";
			this.m_rdbPrivate.Size = new System.Drawing.Size(56, 24);
			this.m_rdbPrivate.TabIndex = 90;
			this.m_rdbPrivate.TabStop = true;
			this.m_rdbPrivate.Text = "自用";
			// 
			// lblTempIDTitle
			// 
			this.lblTempIDTitle.AutoSize = true;
			this.lblTempIDTitle.Location = new System.Drawing.Point(244, 72);
			this.lblTempIDTitle.Name = "lblTempIDTitle";
			this.lblTempIDTitle.Size = new System.Drawing.Size(88, 19);
			this.lblTempIDTitle.TabIndex = 519;
			this.lblTempIDTitle.Text = "模板编号：";
			// 
			// lblTempName
			// 
			this.lblTempName.AutoSize = true;
			this.lblTempName.Location = new System.Drawing.Point(424, 72);
			this.lblTempName.Name = "lblTempName";
			this.lblTempName.Size = new System.Drawing.Size(88, 19);
			this.lblTempName.TabIndex = 520;
			this.lblTempName.Text = "模板名称：";
			// 
			// lblTempICDTitle
			// 
			this.lblTempICDTitle.AutoSize = true;
			this.lblTempICDTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblTempICDTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTempICDTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblTempICDTitle.Location = new System.Drawing.Point(244, 112);
			this.lblTempICDTitle.Name = "lblTempICDTitle";
			this.lblTempICDTitle.Size = new System.Drawing.Size(88, 19);
			this.lblTempICDTitle.TabIndex = 521;
			this.lblTempICDTitle.Text = "所属类别：";
			// 
			// m_lblItem1
			// 
			this.m_lblItem1.ContextMenu = this.ctmEightSystem;
			this.m_lblItem1.ForeColor = System.Drawing.Color.White;
			this.m_lblItem1.Location = new System.Drawing.Point(584, 200);
			this.m_lblItem1.Name = "m_lblItem1";
			this.m_lblItem1.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem1.TabIndex = 522;
			this.m_lblItem1.Text = "1";
			// 
			// m_lblItem2
			// 
			this.m_lblItem2.ContextMenu = this.ctmEightSystem;
			this.m_lblItem2.ForeColor = System.Drawing.Color.White;
			this.m_lblItem2.Location = new System.Drawing.Point(584, 224);
			this.m_lblItem2.Name = "m_lblItem2";
			this.m_lblItem2.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem2.TabIndex = 522;
			this.m_lblItem2.Text = "2";
			// 
			// m_lblItem4
			// 
			this.m_lblItem4.ContextMenu = this.ctmEightSystem;
			this.m_lblItem4.ForeColor = System.Drawing.Color.White;
			this.m_lblItem4.Location = new System.Drawing.Point(584, 272);
			this.m_lblItem4.Name = "m_lblItem4";
			this.m_lblItem4.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem4.TabIndex = 522;
			this.m_lblItem4.Text = "4";
			// 
			// m_lblItem3
			// 
			this.m_lblItem3.ContextMenu = this.ctmEightSystem;
			this.m_lblItem3.ForeColor = System.Drawing.Color.White;
			this.m_lblItem3.Location = new System.Drawing.Point(584, 248);
			this.m_lblItem3.Name = "m_lblItem3";
			this.m_lblItem3.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem3.TabIndex = 522;
			this.m_lblItem3.Text = "3";
			// 
			// m_lblItem6
			// 
			this.m_lblItem6.ContextMenu = this.ctmEightSystem;
			this.m_lblItem6.ForeColor = System.Drawing.Color.White;
			this.m_lblItem6.Location = new System.Drawing.Point(584, 320);
			this.m_lblItem6.Name = "m_lblItem6";
			this.m_lblItem6.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem6.TabIndex = 522;
			this.m_lblItem6.Text = "6";
			this.m_lblItem6.Click += new System.EventHandler(this.m_lblItem6_Click);
			// 
			// m_lblItem7
			// 
			this.m_lblItem7.ContextMenu = this.ctmEightSystem;
			this.m_lblItem7.ForeColor = System.Drawing.Color.White;
			this.m_lblItem7.Location = new System.Drawing.Point(584, 344);
			this.m_lblItem7.Name = "m_lblItem7";
			this.m_lblItem7.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem7.TabIndex = 522;
			this.m_lblItem7.Text = "7";
			// 
			// m_lblItem8
			// 
			this.m_lblItem8.ContextMenu = this.ctmEightSystem;
			this.m_lblItem8.ForeColor = System.Drawing.Color.White;
			this.m_lblItem8.Location = new System.Drawing.Point(584, 368);
			this.m_lblItem8.Name = "m_lblItem8";
			this.m_lblItem8.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem8.TabIndex = 522;
			this.m_lblItem8.Text = "8";
			// 
			// m_lblItem5
			// 
			this.m_lblItem5.ContextMenu = this.ctmEightSystem;
			this.m_lblItem5.ForeColor = System.Drawing.Color.White;
			this.m_lblItem5.Location = new System.Drawing.Point(584, 296);
			this.m_lblItem5.Name = "m_lblItem5";
			this.m_lblItem5.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem5.TabIndex = 522;
			this.m_lblItem5.Text = "5";
			this.m_lblItem5.Click += new System.EventHandler(this.m_lblItem5_Click);
			// 
			// m_lblItem11
			// 
			this.m_lblItem11.ContextMenu = this.ctmEightSystem;
			this.m_lblItem11.ForeColor = System.Drawing.Color.White;
			this.m_lblItem11.Location = new System.Drawing.Point(584, 440);
			this.m_lblItem11.Name = "m_lblItem11";
			this.m_lblItem11.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem11.TabIndex = 522;
			this.m_lblItem11.Text = "11";
			// 
			// m_lblItem12
			// 
			this.m_lblItem12.ContextMenu = this.ctmEightSystem;
			this.m_lblItem12.ForeColor = System.Drawing.Color.White;
			this.m_lblItem12.Location = new System.Drawing.Point(584, 464);
			this.m_lblItem12.Name = "m_lblItem12";
			this.m_lblItem12.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem12.TabIndex = 522;
			this.m_lblItem12.Text = "12";
			// 
			// m_lblItem9
			// 
			this.m_lblItem9.ContextMenu = this.ctmEightSystem;
			this.m_lblItem9.ForeColor = System.Drawing.Color.White;
			this.m_lblItem9.Location = new System.Drawing.Point(584, 392);
			this.m_lblItem9.Name = "m_lblItem9";
			this.m_lblItem9.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem9.TabIndex = 522;
			this.m_lblItem9.Text = "9";
			// 
			// m_lblItem13
			// 
			this.m_lblItem13.ContextMenu = this.ctmEightSystem;
			this.m_lblItem13.ForeColor = System.Drawing.Color.White;
			this.m_lblItem13.Location = new System.Drawing.Point(584, 488);
			this.m_lblItem13.Name = "m_lblItem13";
			this.m_lblItem13.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem13.TabIndex = 522;
			this.m_lblItem13.Text = "13";
			// 
			// m_lblItem10
			// 
			this.m_lblItem10.ContextMenu = this.ctmEightSystem;
			this.m_lblItem10.ForeColor = System.Drawing.Color.White;
			this.m_lblItem10.Location = new System.Drawing.Point(584, 416);
			this.m_lblItem10.Name = "m_lblItem10";
			this.m_lblItem10.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem10.TabIndex = 522;
			this.m_lblItem10.Text = "10";
			// 
			// m_lblItem14
			// 
			this.m_lblItem14.ContextMenu = this.ctmEightSystem;
			this.m_lblItem14.ForeColor = System.Drawing.Color.White;
			this.m_lblItem14.Location = new System.Drawing.Point(584, 512);
			this.m_lblItem14.Name = "m_lblItem14";
			this.m_lblItem14.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem14.TabIndex = 522;
			this.m_lblItem14.Text = "14";
			// 
			// m_lblItem15
			// 
			this.m_lblItem15.ContextMenu = this.ctmEightSystem;
			this.m_lblItem15.ForeColor = System.Drawing.Color.White;
			this.m_lblItem15.Location = new System.Drawing.Point(584, 536);
			this.m_lblItem15.Name = "m_lblItem15";
			this.m_lblItem15.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem15.TabIndex = 522;
			this.m_lblItem15.Text = "15";
			// 
			// m_lblItem16
			// 
			this.m_lblItem16.ContextMenu = this.ctmEightSystem;
			this.m_lblItem16.ForeColor = System.Drawing.Color.White;
			this.m_lblItem16.Location = new System.Drawing.Point(584, 560);
			this.m_lblItem16.Name = "m_lblItem16";
			this.m_lblItem16.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem16.TabIndex = 522;
			this.m_lblItem16.Text = "16";
			// 
			// m_lblItem17
			// 
			this.m_lblItem17.ContextMenu = this.ctmEightSystem;
			this.m_lblItem17.ForeColor = System.Drawing.Color.White;
			this.m_lblItem17.Location = new System.Drawing.Point(584, 584);
			this.m_lblItem17.Name = "m_lblItem17";
			this.m_lblItem17.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem17.TabIndex = 522;
			this.m_lblItem17.Text = "17";
			// 
			// m_lblItem18
			// 
			this.m_lblItem18.ContextMenu = this.ctmEightSystem;
			this.m_lblItem18.ForeColor = System.Drawing.Color.White;
			this.m_lblItem18.Location = new System.Drawing.Point(584, 608);
			this.m_lblItem18.Name = "m_lblItem18";
			this.m_lblItem18.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem18.TabIndex = 522;
			this.m_lblItem18.Text = "18";
			// 
			// m_lblItem19
			// 
			this.m_lblItem19.ContextMenu = this.ctmEightSystem;
			this.m_lblItem19.ForeColor = System.Drawing.Color.White;
			this.m_lblItem19.Location = new System.Drawing.Point(584, 632);
			this.m_lblItem19.Name = "m_lblItem19";
			this.m_lblItem19.Size = new System.Drawing.Size(112, 20);
			this.m_lblItem19.TabIndex = 522;
			this.m_lblItem19.Text = "19";
			// 
			// ctmEightSystem
			// 
			this.ctmEightSystem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						   this.menuItem1,
																						   this.menuItem2,
																						   this.menuItem4,
																						   this.menuItem3,
																						   this.menuItem5});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.Text = "疾  病";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "体  征";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 3;
			this.menuItem3.Text = "实验室检查";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "主要症状";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.Text = "特殊检查";
			// 
			// frmDoctorTemplateFirstPage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(1028, 733);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_lblItem18,
																		  this.m_lblItem19,
																		  this.m_lblItem17,
																		  this.m_lblItem15,
																		  this.m_lblItem16,
																		  this.m_lblItem14,
																		  this.m_lblItem11,
																		  this.m_lblItem12,
																		  this.m_lblItem9,
																		  this.m_lblItem13,
																		  this.m_lblItem10,
																		  this.m_lblItem6,
																		  this.m_lblItem7,
																		  this.m_lblItem8,
																		  this.m_lblItem5,
																		  this.m_lblItem4,
																		  this.m_lblItem3,
																		  this.m_lblItem2,
																		  this.m_lblItem1,
																		  this.m_lblTempICD,
																		  this.m_lblTempID,
																		  this.m_txtTempName,
																		  this.lblTempIDTitle,
																		  this.lblTempName,
																		  this.lblTempICDTitle,
																		  this.m_chkEditable,
																		  this.m_gpbAvailableIn,
																		  this.label1,
																		  this.m_picEightSystem,
																		  this.trvEightSystem});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDoctorTemplateFirstPage";
			this.Text = "医生模板";
			this.Load += new System.EventHandler(this.frmDoctorTemplateFirstPage_Load);
			this.m_gpbAvailableIn.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDoctorTemplateFirstPage_Load(object sender, System.EventArgs e)
		{
			TreeNode trdMainItem=new TreeNode();
			trdMainItem.Text ="医生模板---按八大系统分类";
			this.trvEightSystem.Nodes.Add(trdMainItem); 

			TreeNode trdItem=new TreeNode();
			trdItem.Text="消化系统";
			trdMainItem.Nodes.Add(trdItem); 
			trdItem=new TreeNode();
			trdItem.Text="心血管系统";
			trdMainItem.Nodes.Add(trdItem);
			trdItem=new TreeNode();
			trdItem.Text="内分泌系统";
			trdMainItem.Nodes.Add(trdItem); 
			trdItem=new TreeNode();
			trdItem.Text="血液淋巴系统";
			trdMainItem.Nodes.Add(trdItem); 
			trdItem=new TreeNode();
			trdItem.Text="神经系统";
			trdMainItem.Nodes.Add(trdItem); 
//			trdItem=new TreeNode();
//			trdItem.Text="生殖系统";
//			trdMainItem.Nodes.Add(trdItem); 
			trdItem=new TreeNode();
			trdItem.Text="泌尿生殖系统";
			trdMainItem.Nodes.Add(trdItem); 
			trdItem=new TreeNode();
			trdItem.Text="呼吸系统";
			trdMainItem.Nodes.Add(trdItem); 
			trdItem=new TreeNode();
			trdItem.Text="骨关节系统";
			trdMainItem.Nodes.Add(trdItem); 
			this.trvEightSystem.ExpandAll();
			this.m_lblItem1.Text="";
			this.m_lblItem2.Text =""; 
			this.m_lblItem3.Text="";
			this.m_lblItem4.Text="";
			this.m_lblItem5.Text="";
			this.m_lblItem6.Text="";
			this.m_lblItem7.Text="";
			this.m_lblItem8.Text="";
			this.m_lblItem9.Text="";
			this.m_lblItem10.Text="";
			this.m_lblItem11.Text="";
			this.m_lblItem12.Text="";
			this.m_lblItem13.Text="";
			this.m_lblItem14.Text="";
			this.m_lblItem15.Text="";
			this.m_lblItem16.Text="";
			this.m_lblItem17.Text="";
			this.m_lblItem18.Text="";
			this.m_lblItem19.Text="";
			
			m_objHighLight.m_mthAddControlInContainer(this);
			m_txtTempName.Focus();
//			trvEightSystem.Focus();
		}

		private string strGetFilePathHeader()//提取文件绝对路径的上级目录,Jacky-2002-11-30
		{
			string [] strFilePathAll =  Application.ExecutablePath.Split('\\') ;
			string strFilePathHeader="";
			if(strFilePathAll!=null)
				for(int i=0;i<strFilePathAll.Length-3;i++)
					strFilePathHeader+=strFilePathAll[i]+"\\\\";
			return strFilePathHeader;
		}

		private void trvEightSystem_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			Bitmap imgUser;

			switch(this.trvEightSystem.SelectedNode.Text)
			{
				case"内分泌系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "endocrine.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				case"消化系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "digestive.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				case"心血管系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "Cardiovascular.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				case"血液淋巴系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "lymphatic.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				case"神经系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "nervous.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
//				case"泌尿生殖系统":
//					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "reproductive.JPG");
//					this.m_picEightSystem.Image=imgUser;
//					this.bolIfDrawSystem=true;
//					break;
				case"泌尿生殖系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "urinary.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				case"呼吸系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "respiratory.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				case"骨关节系统":
					imgUser = new Bitmap(strGetFilePathHeader()+"picture\\"+ "skeletal.JPG");
					this.m_picEightSystem.Image=imgUser;
					this.bolIfDrawSystem=true;
					break;
				default:
					this.m_lblItem1.Text ="" ;
					this.m_lblItem2.Text ="" ;
					this.m_lblItem3.Text ="" ;
					this.m_lblItem4.Text ="" ;
					this.m_lblItem5.Text ="" ;
					this.m_lblItem6.Text ="" ;
					this.m_lblItem7.Text ="" ;
					this.m_lblItem8.Text ="" ;
					this.m_lblItem9.Text ="" ;
					this.m_lblItem10.Text ="" ;
					this.m_lblItem11.Text ="" ;
					this.m_lblItem12.Text ="" ;
					this.m_lblItem13.Text ="" ;
					this.m_lblItem14.Text ="" ;
					this.m_lblItem15.Text ="" ;
					this.m_lblItem16.Text ="" ;
					this.m_lblItem17.Text ="" ;
					this.m_lblItem18.Text ="" ;
					this.m_lblItem19.Text ="" ;
					this.m_picEightSystem.Image=null;
					break;
			}
			this.m_picEightSystem.Invalidate(); 

		}

		private void m_picEightSystem_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if(bolIfDrawSystem==true)
			{
				Pen mypen=new Pen(Color.White ,1);
				Graphics myg=e.Graphics;

				switch(this.trvEightSystem.SelectedNode.Text)
				{
					case("消化系统"):
						myg.DrawLine(mypen,150,40,360,10); 
						this.m_lblItem1.Text ="牙齿";
						myg.DrawLine(mypen,150,80,360,30); 
						this.m_lblItem2.Text ="食道";
						myg.DrawLine(mypen,120,120,360,50); 
						this.m_lblItem3.Text ="肝脏";
						myg.DrawLine(mypen,165,126,360,75); 
						this.m_lblItem4.Text ="胃";
						myg.DrawLine(mypen,137,142,360,100); 
						this.m_lblItem5.Text ="胰腺";
						myg.DrawLine(mypen,136,153,360,120); 
						this.m_lblItem6.Text ="大肠";
						myg.DrawLine(mypen,136,163,360,150); 
						this.m_lblItem7.Text ="小肠";
						myg.DrawLine(mypen,140,180,360,170); 
						this.m_lblItem8.Text ="直肠";
						this.m_lblItem9.Text="";
						this.m_lblItem10.Text="";
						this.m_lblItem11.Text="";
						this.m_lblItem12.Text="";
						this.m_lblItem13.Text="";
						this.m_lblItem14.Text="";
						this.m_lblItem15.Text="";
						this.m_lblItem16.Text="";
						this.m_lblItem17.Text="";
						this.m_lblItem18.Text="";
						this.m_lblItem19.Text="";
						bolIfDrawSystem=false;
						break;
					case("呼吸系统"):
						myg.DrawLine(mypen,143,52,360,10); 
						this.m_lblItem1.Text ="甲状腺软骨";
						myg.DrawLine(mypen,146,75,360,30); 
						this.m_lblItem2.Text ="气管";
						myg.DrawLine(mypen,150,91,360,50); 
						this.m_lblItem3.Text ="支气管";
						myg.DrawLine(mypen,123,96,360,80);
						this.m_lblItem4.Text ="左肺";
						myg.DrawLine(mypen,155,103,360,100); 
						this.m_lblItem5.Text ="右肺";
						myg.DrawLine(mypen,123,127,360,130); 
						this.m_lblItem6.Text ="横隔膜";
						myg.DrawLine(mypen,155,133,360,150); 
						this.m_lblItem7.Text ="胸膜";
						this.m_lblItem8.Text="";
						this.m_lblItem9.Text="";
						this.m_lblItem10.Text="";
						this.m_lblItem11.Text="";
						this.m_lblItem12.Text="";
						this.m_lblItem13.Text="";
						this.m_lblItem14.Text="";
						this.m_lblItem15.Text="";
						this.m_lblItem16.Text="";
						this.m_lblItem17.Text="";
						this.m_lblItem18.Text="";
						this.m_lblItem19.Text="";
						bolIfDrawSystem=false;
						break;
					case("心血管系统"):
						myg.DrawLine(mypen,140,35,360,10); 
						this.m_lblItem1.Text ="面目动脉";
						myg.DrawLine(mypen,153,40,360,30); 
						this.m_lblItem2.Text ="内部经动脉";
						myg.DrawLine(mypen,152,55,360,58); 
						this.m_lblItem3.Text ="动脉";
						myg.DrawLine(mypen,153,67,360,82);
						this.m_lblItem4.Text ="锁骨下动脉";
						myg.DrawLine(mypen,169,78,360,105); 
						this.m_lblItem5.Text ="液窝动脉";
						myg.DrawLine(mypen,195,105,360,160); 
						this.m_lblItem6.Text ="弓形大动脉";
						myg.DrawLine(mypen,150,78,360,135); 
						this.m_lblItem7.Text ="臂动脉";
						myg.DrawLine(mypen,155,90,360,185); 
						this.m_lblItem8.Text ="肺动脉";
						myg.DrawLine(mypen,235,155,360,205); 
						this.m_lblItem9.Text ="前臂深动脉";
						myg.DrawLine(mypen,280,193,360,230); 
						this.m_lblItem10.Text ="手掌动脉";
						myg.DrawLine(mypen,155,105,360,260); 
						this.m_lblItem11.Text ="心脏";
						myg.DrawLine(mypen,145,120,360,280); 
						this.m_lblItem12.Text ="腹部大动脉";
						myg.DrawLine(mypen,155,138,360,305); 
						this.m_lblItem13.Text ="肾动动脉";
						myg.DrawLine(mypen,160,175,360,330); 
						this.m_lblItem14.Text ="髂骨动脉";
						myg.DrawLine(mypen,161,210,357,350); 
						this.m_lblItem15.Text ="股骨动脉";
						myg.DrawLine(mypen,181,330,360,370); 
						this.m_lblItem16.Text ="前胫骨动脉";
						myg.DrawLine(mypen,185,383,360,395); 
						this.m_lblItem17.Text ="脚部深动脉";
						this.m_lblItem18.Text ="";
						this.m_lblItem19.Text ="";
						
						bolIfDrawSystem=false;
						break;
					case("内分泌系统"):
						myg.DrawLine(mypen,160,28,360,10); 
						this.m_lblItem1.Text ="脑垂体";
						myg.DrawLine(mypen,163,70,360,30); 
						this.m_lblItem2.Text ="甲状腺";
						myg.DrawLine(mypen,169,148,360,100); 
						this.m_lblItem5.Text ="肾上腺";
						myg.DrawLine(mypen,169,160,360,150); 
						this.m_lblItem7.Text ="胰腺";
						myg.DrawLine(mypen,169,240,360,225); 
						this.m_lblItem10.Text ="睾丸激素";
						this.m_lblItem3.Text ="";
						this.m_lblItem4.Text ="";
						this.m_lblItem6.Text ="";
						this.m_lblItem8.Text ="";
						this.m_lblItem9.Text ="";
						this.m_lblItem11.Text="";
						this.m_lblItem12.Text="";
						this.m_lblItem13.Text="";
						this.m_lblItem14.Text="";
						this.m_lblItem15.Text="";
						this.m_lblItem16.Text="";
						this.m_lblItem17.Text="";
						this.m_lblItem18.Text="";
						this.m_lblItem19.Text="";
						bolIfDrawSystem=false;
						break;
					case("血液淋巴系统"):
						myg.DrawLine(mypen,152,50,360,10); 
						this.m_lblItem1.Text ="颈部淋巴结";
						myg.DrawLine(mypen,150,55,360,30); 
						this.m_lblItem2.Text ="气管淋巴结";
						myg.DrawLine(mypen,169,78,360,58); 
						this.m_lblItem3.Text ="液窝淋巴结";
						myg.DrawLine(mypen,135,100,360,85);
						this.m_lblItem4.Text ="旁胸部淋巴结";
						myg.DrawLine(mypen,145,120,360,105); 
						this.m_lblItem5.Text ="胸部淋巴结";
						myg.DrawLine(mypen,150,145,360,130); 
						this.m_lblItem6.Text ="腰部淋巴结";
						myg.DrawLine(mypen,150,150,360,150); 
						this.m_lblItem7.Text ="大动脉淋巴结";
						myg.DrawLine(mypen,161,210,360,170); 
						this.m_lblItem8.Text ="腹股沟淋巴结";
						this.m_lblItem9.Text ="";
						this.m_lblItem10.Text ="";
						this.m_lblItem11.Text="";
						this.m_lblItem12.Text="";
						this.m_lblItem13.Text="";
						this.m_lblItem14.Text="";
						this.m_lblItem15.Text="";
						this.m_lblItem16.Text="";
						this.m_lblItem17.Text="";
						this.m_lblItem18.Text="";
						this.m_lblItem19.Text="";
						bolIfDrawSystem=false;
						break;
					case("神经系统"):
						myg.DrawLine(mypen,165,12,360,10); 
						this.m_lblItem1.Text ="脑神经";
						myg.DrawLine(mypen,178,78,360,30); 
						this.m_lblItem2.Text ="臂丛神经";
						myg.DrawLine(mypen,170,60,360,58); 
						this.m_lblItem3.Text ="交感神经";
						myg.DrawLine(mypen,160,67,360,85);
						this.m_lblItem4.Text ="脊索神经";
						myg.DrawLine(mypen,169,78,360,105); 
						this.m_lblItem5.Text ="桡神经";
						myg.DrawLine(mypen,215,135,360,150); 
						this.m_lblItem7.Text ="尺神经";
						myg.DrawLine(mypen,155,90,360,180); 
						this.m_lblItem8.Text ="肋间神经";
						myg.DrawLine(mypen,235,155,360,210); 
						this.m_lblItem9.Text ="骶丛神经";
						myg.DrawLine(mypen,270,193,360,230); 
						this.m_lblItem10.Text ="股神经";
						myg.DrawLine(mypen,155,105,360,260); 
						this.m_lblItem11.Text ="坐骨神经";
						myg.DrawLine(mypen,145,120,360,280); 
						this.m_lblItem12.Text ="胫股神经";
						myg.DrawLine(mypen,155,138,360,310); 
						this.m_lblItem13.Text ="腓神经";
						myg.DrawLine(mypen,160,175,360,330); 
						this.m_lblItem14.Text ="手皮肤神经";
						this.m_lblItem6.Text ="";
						this.m_lblItem15.Text="";
						this.m_lblItem16.Text="";
						this.m_lblItem17.Text="";
						this.m_lblItem18.Text="";
						this.m_lblItem19.Text="";
						bolIfDrawSystem=false;
						break;
					case("泌尿生殖系统"):
						myg.DrawLine(mypen,175,149,360,75);
						this.m_lblItem4.Text ="肾";
						myg.DrawLine(mypen,172,175,360,150); 
						this.m_lblItem7.Text ="输尿管";
						myg.DrawLine(mypen,169,215,360,200); 
						this.m_lblItem9.Text ="膀胱";
						myg.DrawLine(mypen,169,235,360,250); 
						this.m_lblItem11.Text ="尿道";
						this.m_lblItem1.Text="";
						this.m_lblItem2.Text="";
						this.m_lblItem3.Text="";
						
						this.m_lblItem5.Text="";
						this.m_lblItem8.Text="";
						this.m_lblItem10.Text ="";
						
						this.m_lblItem12.Text="";
						this.m_lblItem13.Text="";
						this.m_lblItem14.Text="";
						this.m_lblItem15.Text="";
						this.m_lblItem16.Text="";
						this.m_lblItem17.Text="";
						this.m_lblItem18.Text="";
						this.m_lblItem19.Text="";
						bolIfDrawSystem=false;
						break;
					case("骨关节系统"):
						myg.DrawLine(mypen,150,25,360,10); 
						this.m_lblItem1.Text ="头骨";
						myg.DrawLine(mypen,190,70,360,55); 
						this.m_lblItem2.Text ="脊椎";
						myg.DrawLine(mypen,160,70,360,25); 
						this.m_lblItem3.Text ="锁骨";
						myg.DrawLine(mypen,190,78,360,80);
						this.m_lblItem4.Text ="肩胛骨";
						myg.DrawLine(mypen,160,90,360,105); 
						this.m_lblItem5.Text ="胸骨";
						myg.DrawLine(mypen,260,175,360,150); 
						this.m_lblItem6.Text ="肱骨";
						myg.DrawLine(mypen,225,130,360,130); 
						this.m_lblItem7.Text ="尺骨";
						myg.DrawLine(mypen,268,180,360,180); 
						this.m_lblItem8.Text ="桡骨";
						myg.DrawLine(mypen,290,205,360,195); 
						this.m_lblItem9.Text ="掌骨";
						myg.DrawLine(mypen,290,220,360,220); 
						this.m_lblItem10.Text ="指骨";
						myg.DrawLine(mypen,172,120,360,250); 
						this.m_lblItem11.Text ="肋骨";
						myg.DrawLine(mypen,180,185,360,280); 
						this.m_lblItem12.Text ="骨盆";
						myg.DrawLine(mypen,189,270,360,300); 
						this.m_lblItem13.Text ="腿骨";
						myg.DrawLine(mypen,198,330,360,320); 
						this.m_lblItem14.Text ="胫骨";
						myg.DrawLine(mypen,205,355,357,340); 
						this.m_lblItem15.Text ="腓骨";
						myg.DrawLine(mypen,190,405,360,360); 
						this.m_lblItem16.Text ="跗骨";
						myg.DrawLine(mypen,190,420,360,385); 
						this.m_lblItem17.Text ="跖骨";
						myg.DrawLine(mypen,200,435,360,415); 
						this.m_lblItem18.Text ="趾骨";
						this.m_lblItem19.Text ="";
						bolIfDrawSystem=false;
						break;
					
				}
			}

		}

		
		private void m_lblItem5_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_lblItem6_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
