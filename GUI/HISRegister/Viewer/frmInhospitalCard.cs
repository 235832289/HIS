using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmInhospitalCard 的摘要说明。
	/// </summary>
	public class frmInhospitalCard : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label64;
		private System.Windows.Forms.Label label65;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label72;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label68;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.Label label75;
		private com.digitalwave.controls.exTextBox txtInsurance;
		private System.Windows.Forms.CheckBox chk_Insurance;
		private System.Windows.Forms.Label lbeTimes;
		private com.digitalwave.controls.exTextBox txtNo;
		private com.digitalwave.controls.exTextBox txtWork;
		private com.digitalwave.controls.exTextBox txtName;
		private System.Windows.Forms.CheckBox chk_Man;
		private System.Windows.Forms.CheckBox chk_Woman;
		private com.digitalwave.controls.NumTextBox txtAgeYear;
		private com.digitalwave.controls.NumTextBox txtAgeMonth;
		private com.digitalwave.controls.NumTextBox txtAgeDay;
		private com.digitalwave.controls.NumTextBox txtAge;
		private System.Windows.Forms.CheckBox chk_Married;
		private System.Windows.Forms.CheckBox chk_NotMarry;
		private com.digitalwave.controls.exTextBox txtBornPlace;
		private com.digitalwave.controls.exTextBox txtCounty;
		private com.digitalwave.controls.exTextBox txtNationality;
		private com.digitalwave.controls.exTextBox txtCountry;
		private com.digitalwave.controls.exTextBox txtID;
		private com.digitalwave.controls.exTextBox txtTel;
		private com.digitalwave.controls.exTextBox txtAddress;
		private com.digitalwave.controls.exTextBox txtPostalcode;
		private com.digitalwave.controls.exTextBox txtHomeAddress;
		private com.digitalwave.controls.exTextBox txtAddress2;
		private com.digitalwave.controls.exTextBox txtRelation;
		private System.Windows.Forms.Label label222;
		private com.digitalwave.controls.exTextBox txtLinkman;
		private com.digitalwave.controls.NumTextBox txtInDay;
		private com.digitalwave.controls.NumTextBox txtInMonth;
		private com.digitalwave.controls.NumTextBox txtInYear;
		private com.digitalwave.controls.exTextBox txtDepartment;
		private System.Windows.Forms.CheckBox chk_Urgent;
		private System.Windows.Forms.CheckBox chk_danger;
		private System.Windows.Forms.CheckBox chk_Normal;
		private com.digitalwave.controls.NumTextBox txtMoney;
		private com.digitalwave.controls.exTextBox txtDiag;
		private com.digitalwave.controls.exTextBox txtDocNO;
		private com.digitalwave.controls.exTextBox txtDiag2;
		private com.digitalwave.controls.exTextBox txtRemark;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btPrint;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.Label lbeHospitalTitle;
		private com.digitalwave.controls.exTextBox txtPostalcode2;
		private com.digitalwave.controls.exTextBox txtTel2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private com.digitalwave.controls.NumTextBox txtHour;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		internal com.digitalwave.controls.ctlTextBoxFind m_txtAREAID_CHR;
		internal com.digitalwave.controls.ctlTextBoxFind m_txtOutPatientDoctor;
		internal System.Windows.Forms.ComboBox cmbNationality;
		internal System.Windows.Forms.ComboBox cmbCountry;
		private clsT_Opr_Bih_Register_VO objOBRVO=null;
		public frmInhospitalCard()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			objOBRVO =new clsT_Opr_Bih_Register_VO();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInhospitalCard));
			this.lbeHospitalTitle = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lbeTimes = new System.Windows.Forms.Label();
			this.txtInsurance = new com.digitalwave.controls.exTextBox();
			this.txtNo = new com.digitalwave.controls.exTextBox();
			this.txtWork = new com.digitalwave.controls.exTextBox();
			this.txtName = new com.digitalwave.controls.exTextBox();
			this.chk_Insurance = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.chk_Man = new System.Windows.Forms.CheckBox();
			this.chk_Woman = new System.Windows.Forms.CheckBox();
			this.txtAgeYear = new com.digitalwave.controls.NumTextBox();
			this.txtAgeMonth = new com.digitalwave.controls.NumTextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.txtAgeDay = new com.digitalwave.controls.NumTextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.label31 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.txtAge = new com.digitalwave.controls.NumTextBox();
			this.label33 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.chk_Married = new System.Windows.Forms.CheckBox();
			this.chk_NotMarry = new System.Windows.Forms.CheckBox();
			this.label35 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.txtBornPlace = new com.digitalwave.controls.exTextBox();
			this.label38 = new System.Windows.Forms.Label();
			this.label39 = new System.Windows.Forms.Label();
			this.txtCounty = new com.digitalwave.controls.exTextBox();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.txtNationality = new com.digitalwave.controls.exTextBox();
			this.label42 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.txtCountry = new com.digitalwave.controls.exTextBox();
			this.label44 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.txtID = new com.digitalwave.controls.exTextBox();
			this.label46 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.txtPostalcode = new com.digitalwave.controls.exTextBox();
			this.label48 = new System.Windows.Forms.Label();
			this.label49 = new System.Windows.Forms.Label();
			this.txtTel = new com.digitalwave.controls.exTextBox();
			this.label56 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.txtAddress = new com.digitalwave.controls.exTextBox();
			this.label50 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.txtPostalcode2 = new com.digitalwave.controls.exTextBox();
			this.label54 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.txtHomeAddress = new com.digitalwave.controls.exTextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtTel2 = new com.digitalwave.controls.exTextBox();
			this.txtAddress2 = new com.digitalwave.controls.exTextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.txtRelation = new com.digitalwave.controls.exTextBox();
			this.label222 = new System.Windows.Forms.Label();
			this.txtLinkman = new com.digitalwave.controls.exTextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label28 = new System.Windows.Forms.Label();
			this.txtInDay = new com.digitalwave.controls.NumTextBox();
			this.label52 = new System.Windows.Forms.Label();
			this.label53 = new System.Windows.Forms.Label();
			this.txtInMonth = new com.digitalwave.controls.NumTextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.txtInYear = new com.digitalwave.controls.NumTextBox();
			this.label59 = new System.Windows.Forms.Label();
			this.label60 = new System.Windows.Forms.Label();
			this.label61 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.txtDepartment = new com.digitalwave.controls.exTextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.chk_Urgent = new System.Windows.Forms.CheckBox();
			this.chk_danger = new System.Windows.Forms.CheckBox();
			this.label27 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.chk_Normal = new System.Windows.Forms.CheckBox();
			this.txtMoney = new com.digitalwave.controls.NumTextBox();
			this.label66 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.txtDiag = new com.digitalwave.controls.exTextBox();
			this.label72 = new System.Windows.Forms.Label();
			this.label67 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.txtDocNO = new com.digitalwave.controls.exTextBox();
			this.label73 = new System.Windows.Forms.Label();
			this.txtDiag2 = new com.digitalwave.controls.exTextBox();
			this.label74 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.txtRemark = new com.digitalwave.controls.exTextBox();
			this.btSave = new System.Windows.Forms.Button();
			this.btPrint = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtHour = new com.digitalwave.controls.NumTextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.m_txtAREAID_CHR = new com.digitalwave.controls.ctlTextBoxFind();
			this.m_txtOutPatientDoctor = new com.digitalwave.controls.ctlTextBoxFind();
			this.cmbNationality = new System.Windows.Forms.ComboBox();
			this.cmbCountry = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// lbeHospitalTitle
			// 
			this.lbeHospitalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lbeHospitalTitle.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbeHospitalTitle.Location = new System.Drawing.Point(8, 8);
			this.lbeHospitalTitle.Name = "lbeHospitalTitle";
			this.lbeHospitalTitle.Size = new System.Drawing.Size(792, 48);
			this.lbeHospitalTitle.TabIndex = 0;
			this.lbeHospitalTitle.Text = "住院卡";
			this.lbeHospitalTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(40, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(99, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "医疗付款方式:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(492, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "次住院";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(580, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 19);
			this.label4.TabIndex = 6;
			this.label4.Text = "病案号:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(40, 116);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 19);
			this.label5.TabIndex = 8;
			this.label5.Text = "姓名:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(428, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(20, 19);
			this.label6.TabIndex = 3;
			this.label6.Text = "第";
			// 
			// label7
			// 
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Location = new System.Drawing.Point(40, 96);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(716, 1);
			this.label7.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Location = new System.Drawing.Point(80, 132);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 1);
			this.label8.TabIndex = 25;
			// 
			// lbeTimes
			// 
			this.lbeTimes.AutoSize = true;
			this.lbeTimes.Location = new System.Drawing.Point(460, 64);
			this.lbeTimes.Name = "lbeTimes";
			this.lbeTimes.Size = new System.Drawing.Size(12, 19);
			this.lbeTimes.TabIndex = 4;
			this.lbeTimes.Text = "1";
			// 
			// txtInsurance
			// 
			this.txtInsurance.BackColor = System.Drawing.Color.White;
			this.txtInsurance.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInsurance.Enabled = false;
			this.txtInsurance.Location = new System.Drawing.Point(248, 64);
			this.txtInsurance.MaxLength = 20;
			this.txtInsurance.Name = "txtInsurance";
			this.txtInsurance.SendTabKey = true;
			this.txtInsurance.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtInsurance.Size = new System.Drawing.Size(156, 16);
			this.txtInsurance.TabIndex = 2;
			this.txtInsurance.Text = "";
			// 
			// txtNo
			// 
			this.txtNo.BackColor = System.Drawing.Color.White;
			this.txtNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNo.Location = new System.Drawing.Point(644, 64);
			this.txtNo.MaxLength = 16;
			this.txtNo.Name = "txtNo";
			this.txtNo.ReadOnly = true;
			this.txtNo.SendTabKey = true;
			this.txtNo.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtNo.Size = new System.Drawing.Size(88, 16);
			this.txtNo.TabIndex = 7;
			this.txtNo.Text = "";
			// 
			// txtWork
			// 
			this.txtWork.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtWork.Location = new System.Drawing.Point(80, 151);
			this.txtWork.MaxLength = 30;
			this.txtWork.Name = "txtWork";
			this.txtWork.SendTabKey = true;
			this.txtWork.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtWork.Size = new System.Drawing.Size(88, 16);
			this.txtWork.TabIndex = 31;
			this.txtWork.Text = "";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtName.Location = new System.Drawing.Point(80, 116);
			this.txtName.MaxLength = 12;
			this.txtName.Name = "txtName";
			this.txtName.SendTabKey = true;
			this.txtName.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtName.Size = new System.Drawing.Size(88, 16);
			this.txtName.TabIndex = 9;
			this.txtName.Text = "";
			// 
			// chk_Insurance
			// 
			this.chk_Insurance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Insurance.Location = new System.Drawing.Point(160, 64);
			this.chk_Insurance.Name = "chk_Insurance";
			this.chk_Insurance.Size = new System.Drawing.Size(88, 24);
			this.chk_Insurance.TabIndex = 1;
			this.chk_Insurance.Text = " 医保号:";
			this.chk_Insurance.CheckedChanged += new System.EventHandler(this.chk_Insurance_CheckedChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(176, 116);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(48, 23);
			this.label11.TabIndex = 10;
			this.label11.Text = "性别:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(336, 116);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(34, 19);
			this.label12.TabIndex = 13;
			this.label12.Text = "出生";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(408, 116);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(20, 19);
			this.label13.TabIndex = 15;
			this.label13.Text = "年";
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(446, 151);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(34, 19);
			this.label17.TabIndex = 37;
			this.label17.Text = "民族";
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(40, 151);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(41, 19);
			this.label18.TabIndex = 30;
			this.label18.Text = "职业:";
			// 
			// label20
			// 
			this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label20.Location = new System.Drawing.Point(368, 132);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(40, 1);
			this.label20.TabIndex = 26;
			// 
			// label22
			// 
			this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label22.Location = new System.Drawing.Point(80, 168);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(88, 1);
			this.label22.TabIndex = 44;
			// 
			// chk_Man
			// 
			this.chk_Man.Checked = true;
			this.chk_Man.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_Man.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Man.Location = new System.Drawing.Point(216, 112);
			this.chk_Man.Name = "chk_Man";
			this.chk_Man.Size = new System.Drawing.Size(56, 24);
			this.chk_Man.TabIndex = 11;
			this.chk_Man.Text = "1.男";
			this.chk_Man.CheckedChanged += new System.EventHandler(this.chk_Man_CheckedChanged);
			// 
			// chk_Woman
			// 
			this.chk_Woman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Woman.Location = new System.Drawing.Point(272, 112);
			this.chk_Woman.Name = "chk_Woman";
			this.chk_Woman.Size = new System.Drawing.Size(56, 24);
			this.chk_Woman.TabIndex = 12;
			this.chk_Woman.Text = "2.女";
			this.chk_Woman.CheckedChanged += new System.EventHandler(this.chk_Woman_CheckedChanged);
			// 
			// txtAgeYear
			// 
			this.txtAgeYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAgeYear.Location = new System.Drawing.Point(368, 116);
			this.txtAgeYear.MaxLength = 4;
			this.txtAgeYear.Name = "txtAgeYear";
			this.txtAgeYear.SendTabKey = true;
			this.txtAgeYear.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtAgeYear.Size = new System.Drawing.Size(40, 16);
			this.txtAgeYear.TabIndex = 14;
			this.txtAgeYear.Text = "1980";
			// 
			// txtAgeMonth
			// 
			this.txtAgeMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAgeMonth.Location = new System.Drawing.Point(428, 116);
			this.txtAgeMonth.MaxLength = 2;
			this.txtAgeMonth.Name = "txtAgeMonth";
			this.txtAgeMonth.SendTabKey = true;
			this.txtAgeMonth.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtAgeMonth.Size = new System.Drawing.Size(24, 16);
			this.txtAgeMonth.TabIndex = 16;
			this.txtAgeMonth.Text = "12";
			// 
			// label29
			// 
			this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label29.Location = new System.Drawing.Point(428, 132);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(24, 1);
			this.label29.TabIndex = 27;
			// 
			// txtAgeDay
			// 
			this.txtAgeDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAgeDay.Location = new System.Drawing.Point(484, 116);
			this.txtAgeDay.MaxLength = 2;
			this.txtAgeDay.Name = "txtAgeDay";
			this.txtAgeDay.SendTabKey = true;
			this.txtAgeDay.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtAgeDay.Size = new System.Drawing.Size(24, 16);
			this.txtAgeDay.TabIndex = 18;
			this.txtAgeDay.Text = "12";
			// 
			// label30
			// 
			this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label30.Location = new System.Drawing.Point(484, 132);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(24, 1);
			this.label30.TabIndex = 28;
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(460, 116);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(20, 19);
			this.label31.TabIndex = 17;
			this.label31.Text = "月";
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(516, 116);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(20, 19);
			this.label32.TabIndex = 19;
			this.label32.Text = "日";
			// 
			// txtAge
			// 
			this.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAge.Location = new System.Drawing.Point(576, 116);
			this.txtAge.MaxLength = 3;
			this.txtAge.Name = "txtAge";
			this.txtAge.SendTabKey = true;
			this.txtAge.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtAge.Size = new System.Drawing.Size(32, 16);
			this.txtAge.TabIndex = 21;
			this.txtAge.Text = "120";
			this.txtAge.Leave += new System.EventHandler(this.txtAge_Leave);
			// 
			// label33
			// 
			this.label33.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label33.Location = new System.Drawing.Point(576, 132);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(20, 1);
			this.label33.TabIndex = 29;
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(544, 116);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(34, 19);
			this.label34.TabIndex = 20;
			this.label34.Text = "年龄";
			// 
			// chk_Married
			// 
			this.chk_Married.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Married.Location = new System.Drawing.Point(712, 116);
			this.chk_Married.Name = "chk_Married";
			this.chk_Married.Size = new System.Drawing.Size(52, 24);
			this.chk_Married.TabIndex = 24;
			this.chk_Married.Text = "2.已";
			this.chk_Married.CheckedChanged += new System.EventHandler(this.chk_Married_CheckedChanged);
			// 
			// chk_NotMarry
			// 
			this.chk_NotMarry.Checked = true;
			this.chk_NotMarry.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_NotMarry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_NotMarry.Location = new System.Drawing.Point(660, 116);
			this.chk_NotMarry.Name = "chk_NotMarry";
			this.chk_NotMarry.Size = new System.Drawing.Size(52, 24);
			this.chk_NotMarry.TabIndex = 23;
			this.chk_NotMarry.Text = "1.未";
			this.chk_NotMarry.CheckedChanged += new System.EventHandler(this.chk_NotMarry_CheckedChanged);
			// 
			// label35
			// 
			this.label35.Location = new System.Drawing.Point(616, 116);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(48, 23);
			this.label35.TabIndex = 22;
			this.label35.Text = "婚姻:";
			// 
			// label36
			// 
			this.label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label36.Location = new System.Drawing.Point(224, 168);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(76, 1);
			this.label36.TabIndex = 45;
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(176, 151);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(48, 19);
			this.label37.TabIndex = 32;
			this.label37.Text = "出生地";
			// 
			// txtBornPlace
			// 
			this.txtBornPlace.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtBornPlace.Location = new System.Drawing.Point(224, 151);
			this.txtBornPlace.MaxLength = 30;
			this.txtBornPlace.Name = "txtBornPlace";
			this.txtBornPlace.SendTabKey = true;
			this.txtBornPlace.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtBornPlace.Size = new System.Drawing.Size(76, 16);
			this.txtBornPlace.TabIndex = 33;
			this.txtBornPlace.Text = "";
			// 
			// label38
			// 
			this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label38.Location = new System.Drawing.Point(348, 168);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(72, 1);
			this.label38.TabIndex = 46;
			// 
			// label39
			// 
			this.label39.AutoSize = true;
			this.label39.Location = new System.Drawing.Point(300, 151);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(48, 19);
			this.label39.TabIndex = 34;
			this.label39.Text = "省(市)";
			// 
			// txtCounty
			// 
			this.txtCounty.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCounty.Location = new System.Drawing.Point(348, 151);
			this.txtCounty.MaxLength = 20;
			this.txtCounty.Name = "txtCounty";
			this.txtCounty.SendTabKey = true;
			this.txtCounty.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtCounty.Size = new System.Drawing.Size(72, 16);
			this.txtCounty.TabIndex = 35;
			this.txtCounty.Text = "";
			// 
			// label40
			// 
			this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label40.Location = new System.Drawing.Point(482, 168);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(44, 1);
			this.label40.TabIndex = 47;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(424, 151);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(20, 19);
			this.label41.TabIndex = 36;
			this.label41.Text = "县";
			// 
			// txtNationality
			// 
			this.txtNationality.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtNationality.Location = new System.Drawing.Point(482, 151);
			this.txtNationality.MaxLength = 10;
			this.txtNationality.Name = "txtNationality";
			this.txtNationality.SendTabKey = true;
			this.txtNationality.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtNationality.Size = new System.Drawing.Size(66, 16);
			this.txtNationality.TabIndex = 39;
			this.txtNationality.Text = "";
			this.txtNationality.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtNationality_MouseUp);
			this.txtNationality.Enter += new System.EventHandler(this.txtNationality_Enter);
			// 
			// label42
			// 
			this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label42.Location = new System.Drawing.Point(574, 168);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(44, 1);
			this.label42.TabIndex = 48;
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(542, 151);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(34, 19);
			this.label43.TabIndex = 40;
			this.label43.Text = "国籍";
			// 
			// txtCountry
			// 
			this.txtCountry.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtCountry.Location = new System.Drawing.Point(578, 151);
			this.txtCountry.MaxLength = 10;
			this.txtCountry.Name = "txtCountry";
			this.txtCountry.SendTabKey = true;
			this.txtCountry.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtCountry.Size = new System.Drawing.Size(54, 16);
			this.txtCountry.TabIndex = 41;
			this.txtCountry.Text = "中国";
			this.txtCountry.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtCountry_MouseUp);
			this.txtCountry.Enter += new System.EventHandler(this.txtCountry_Enter);
			// 
			// label44
			// 
			this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label44.Location = new System.Drawing.Point(681, 168);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(75, 1);
			this.label44.TabIndex = 49;
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(632, 151);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(48, 19);
			this.label45.TabIndex = 42;
			this.label45.Text = "身份证";
			// 
			// txtID
			// 
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtID.Location = new System.Drawing.Point(672, 151);
			this.txtID.MaxLength = 18;
			this.txtID.Name = "txtID";
			this.txtID.SendTabKey = true;
			this.txtID.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtID.Size = new System.Drawing.Size(84, 16);
			this.txtID.TabIndex = 43;
			this.txtID.Text = "";
			// 
			// label46
			// 
			this.label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label46.Location = new System.Drawing.Point(683, 204);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(73, 1);
			this.label46.TabIndex = 82;
			// 
			// label47
			// 
			this.label47.AutoSize = true;
			this.label47.Location = new System.Drawing.Point(624, 186);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(63, 19);
			this.label47.TabIndex = 54;
			this.label47.Text = "邮政编码";
			// 
			// txtPostalcode
			// 
			this.txtPostalcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPostalcode.Location = new System.Drawing.Point(684, 186);
			this.txtPostalcode.MaxLength = 6;
			this.txtPostalcode.Name = "txtPostalcode";
			this.txtPostalcode.SendTabKey = true;
			this.txtPostalcode.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtPostalcode.Size = new System.Drawing.Size(72, 16);
			this.txtPostalcode.TabIndex = 55;
			this.txtPostalcode.Text = "529300";
			// 
			// label48
			// 
			this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label48.Location = new System.Drawing.Point(496, 204);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(120, 1);
			this.label48.TabIndex = 79;
			// 
			// label49
			// 
			this.label49.AutoSize = true;
			this.label49.Location = new System.Drawing.Point(456, 186);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(34, 19);
			this.label49.TabIndex = 52;
			this.label49.Text = "电话";
			// 
			// txtTel
			// 
			this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTel.Location = new System.Drawing.Point(496, 186);
			this.txtTel.MaxLength = 20;
			this.txtTel.Name = "txtTel";
			this.txtTel.SendTabKey = true;
			this.txtTel.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtTel.Size = new System.Drawing.Size(120, 16);
			this.txtTel.TabIndex = 53;
			this.txtTel.Text = "";
			// 
			// label56
			// 
			this.label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label56.Location = new System.Drawing.Point(148, 204);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(296, 1);
			this.label56.TabIndex = 67;
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Location = new System.Drawing.Point(40, 186);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(113, 19);
			this.label58.TabIndex = 50;
			this.label58.Text = "工作单位及地址:";
			// 
			// txtAddress
			// 
			this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAddress.Location = new System.Drawing.Point(152, 186);
			this.txtAddress.MaxLength = 50;
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.SendTabKey = true;
			this.txtAddress.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtAddress.Size = new System.Drawing.Size(288, 16);
			this.txtAddress.TabIndex = 51;
			this.txtAddress.Text = "";
			// 
			// label50
			// 
			this.label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label50.Location = new System.Drawing.Point(682, 236);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(74, 1);
			this.label50.TabIndex = 91;
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(624, 216);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(63, 19);
			this.label51.TabIndex = 90;
			this.label51.Text = "邮政编码";
			// 
			// txtPostalcode2
			// 
			this.txtPostalcode2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPostalcode2.Location = new System.Drawing.Point(688, 216);
			this.txtPostalcode2.MaxLength = 6;
			this.txtPostalcode2.Name = "txtPostalcode2";
			this.txtPostalcode2.SendTabKey = true;
			this.txtPostalcode2.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtPostalcode2.Size = new System.Drawing.Size(68, 16);
			this.txtPostalcode2.TabIndex = 57;
			this.txtPostalcode2.Text = "529300";
			// 
			// label54
			// 
			this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label54.Location = new System.Drawing.Point(120, 236);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(492, 1);
			this.label54.TabIndex = 85;
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(40, 221);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(70, 19);
			this.label55.TabIndex = 84;
			this.label55.Text = "户口地址:";
			// 
			// txtHomeAddress
			// 
			this.txtHomeAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtHomeAddress.Location = new System.Drawing.Point(120, 216);
			this.txtHomeAddress.MaxLength = 50;
			this.txtHomeAddress.Name = "txtHomeAddress";
			this.txtHomeAddress.SendTabKey = true;
			this.txtHomeAddress.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtHomeAddress.Size = new System.Drawing.Size(496, 16);
			this.txtHomeAddress.TabIndex = 56;
			this.txtHomeAddress.Text = "";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(624, 256);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(34, 19);
			this.label10.TabIndex = 104;
			this.label10.Text = "电话";
			// 
			// txtTel2
			// 
			this.txtTel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTel2.Location = new System.Drawing.Point(668, 256);
			this.txtTel2.MaxLength = 18;
			this.txtTel2.Name = "txtTel2";
			this.txtTel2.SendTabKey = true;
			this.txtTel2.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtTel2.Size = new System.Drawing.Size(88, 16);
			this.txtTel2.TabIndex = 61;
			this.txtTel2.Text = "";
			// 
			// txtAddress2
			// 
			this.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtAddress2.Location = new System.Drawing.Point(380, 256);
			this.txtAddress2.Name = "txtAddress2";
			this.txtAddress2.SendTabKey = true;
			this.txtAddress2.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtAddress2.Size = new System.Drawing.Size(240, 16);
			this.txtAddress2.TabIndex = 60;
			this.txtAddress2.Text = "";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(340, 256);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(34, 19);
			this.label16.TabIndex = 98;
			this.label16.Text = "地址";
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(216, 256);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(34, 19);
			this.label19.TabIndex = 96;
			this.label19.Text = "关系";
			// 
			// txtRelation
			// 
			this.txtRelation.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRelation.Location = new System.Drawing.Point(264, 256);
			this.txtRelation.MaxLength = 16;
			this.txtRelation.Name = "txtRelation";
			this.txtRelation.SendTabKey = true;
			this.txtRelation.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtRelation.Size = new System.Drawing.Size(72, 16);
			this.txtRelation.TabIndex = 59;
			this.txtRelation.Text = "";
			// 
			// label222
			// 
			this.label222.AutoSize = true;
			this.label222.Location = new System.Drawing.Point(40, 256);
			this.label222.Name = "label222";
			this.label222.Size = new System.Drawing.Size(84, 19);
			this.label222.TabIndex = 93;
			this.label222.Text = "联系人姓名:";
			// 
			// txtLinkman
			// 
			this.txtLinkman.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtLinkman.Location = new System.Drawing.Point(120, 256);
			this.txtLinkman.MaxLength = 16;
			this.txtLinkman.Name = "txtLinkman";
			this.txtLinkman.SendTabKey = true;
			this.txtLinkman.SetFocusColor = System.Drawing.Color.White;
			this.txtLinkman.Size = new System.Drawing.Size(88, 16);
			this.txtLinkman.TabIndex = 58;
			this.txtLinkman.Text = "";
			// 
			// label14
			// 
			this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label14.Location = new System.Drawing.Point(124, 276);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(84, 1);
			this.label14.TabIndex = 105;
			// 
			// label15
			// 
			this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label15.Location = new System.Drawing.Point(264, 276);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(76, 1);
			this.label15.TabIndex = 106;
			// 
			// label21
			// 
			this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label21.Location = new System.Drawing.Point(380, 276);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(240, 1);
			this.label21.TabIndex = 107;
			// 
			// label24
			// 
			this.label24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label24.Location = new System.Drawing.Point(669, 276);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(87, 1);
			this.label24.TabIndex = 108;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(260, 300);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(20, 19);
			this.label28.TabIndex = 200;
			this.label28.Text = "日";
			// 
			// txtInDay
			// 
			this.txtInDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInDay.Location = new System.Drawing.Point(228, 300);
			this.txtInDay.MaxLength = 2;
			this.txtInDay.Name = "txtInDay";
			this.txtInDay.SendTabKey = true;
			this.txtInDay.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtInDay.Size = new System.Drawing.Size(24, 16);
			this.txtInDay.TabIndex = 66;
			this.txtInDay.Text = "12";
			// 
			// label52
			// 
			this.label52.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label52.Location = new System.Drawing.Point(228, 320);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(24, 1);
			this.label52.TabIndex = 121;
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(206, 300);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(20, 19);
			this.label53.TabIndex = 65;
			this.label53.Text = "月";
			// 
			// txtInMonth
			// 
			this.txtInMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInMonth.Location = new System.Drawing.Point(176, 300);
			this.txtInMonth.MaxLength = 2;
			this.txtInMonth.Name = "txtInMonth";
			this.txtInMonth.SendTabKey = true;
			this.txtInMonth.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtInMonth.Size = new System.Drawing.Size(24, 16);
			this.txtInMonth.TabIndex = 63;
			this.txtInMonth.Text = "12";
			// 
			// label57
			// 
			this.label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label57.Location = new System.Drawing.Point(172, 320);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(24, 1);
			this.label57.TabIndex = 118;
			// 
			// txtInYear
			// 
			this.txtInYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInYear.Location = new System.Drawing.Point(112, 300);
			this.txtInYear.MaxLength = 4;
			this.txtInYear.Name = "txtInYear";
			this.txtInYear.SendTabKey = true;
			this.txtInYear.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtInYear.Size = new System.Drawing.Size(40, 16);
			this.txtInYear.TabIndex = 62;
			this.txtInYear.Text = "1980";
			// 
			// label59
			// 
			this.label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label59.Location = new System.Drawing.Point(112, 320);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(40, 1);
			this.label59.TabIndex = 114;
			// 
			// label60
			// 
			this.label60.AutoSize = true;
			this.label60.Location = new System.Drawing.Point(152, 300);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(20, 19);
			this.label60.TabIndex = 64;
			this.label60.Text = "年";
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(40, 300);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(63, 19);
			this.label61.TabIndex = 112;
			this.label61.Text = "入院日期";
			// 
			// label62
			// 
			this.label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label62.Location = new System.Drawing.Point(475, 320);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(112, 1);
			this.label62.TabIndex = 132;
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(396, 300);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(70, 19);
			this.label63.TabIndex = 68;
			this.label63.Text = "入院科别:";
			// 
			// txtDepartment
			// 
			this.txtDepartment.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDepartment.Location = new System.Drawing.Point(480, 300);
			this.txtDepartment.Name = "txtDepartment";
			this.txtDepartment.SendTabKey = true;
			this.txtDepartment.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtDepartment.Size = new System.Drawing.Size(112, 16);
			this.txtDepartment.TabIndex = 69;
			this.txtDepartment.Text = "";
			// 
			// label25
			// 
			this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label25.Location = new System.Drawing.Point(644, 320);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(112, 1);
			this.label25.TabIndex = 135;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(592, 300);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(41, 19);
			this.label26.TabIndex = 70;
			this.label26.Text = "病室:";
			// 
			// chk_Urgent
			// 
			this.chk_Urgent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Urgent.Location = new System.Drawing.Point(623, 328);
			this.chk_Urgent.Name = "chk_Urgent";
			this.chk_Urgent.Size = new System.Drawing.Size(75, 24);
			this.chk_Urgent.TabIndex = 75;
			this.chk_Urgent.Text = "2.急";
			this.chk_Urgent.Click += new System.EventHandler(this.chk_Urgent_CheckedChanged);
			// 
			// chk_danger
			// 
			this.chk_danger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_danger.Location = new System.Drawing.Point(548, 328);
			this.chk_danger.Name = "chk_danger";
			this.chk_danger.Size = new System.Drawing.Size(75, 24);
			this.chk_danger.TabIndex = 74;
			this.chk_danger.Text = "1.危";
			this.chk_danger.Click += new System.EventHandler(this.chk_danger_CheckedChanged);
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(440, 328);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(84, 19);
			this.label27.TabIndex = 73;
			this.label27.Text = "入院时情况:";
			// 
			// label64
			// 
			this.label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label64.Location = new System.Drawing.Point(108, 348);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(124, 1);
			this.label64.TabIndex = 137;
			// 
			// label65
			// 
			this.label65.AutoSize = true;
			this.label65.Location = new System.Drawing.Point(40, 328);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(41, 19);
			this.label65.TabIndex = 136;
			this.label65.Text = "按金:";
			// 
			// chk_Normal
			// 
			this.chk_Normal.Checked = true;
			this.chk_Normal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_Normal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.chk_Normal.Location = new System.Drawing.Point(698, 328);
			this.chk_Normal.Name = "chk_Normal";
			this.chk_Normal.Size = new System.Drawing.Size(75, 24);
			this.chk_Normal.TabIndex = 76;
			this.chk_Normal.Text = "3.一般";
			this.chk_Normal.Click += new System.EventHandler(this.chk_Normal_CheckedChanged);
			// 
			// txtMoney
			// 
			this.txtMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtMoney.Location = new System.Drawing.Point(108, 328);
			this.txtMoney.Name = "txtMoney";
			this.txtMoney.SendTabKey = true;
			this.txtMoney.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtMoney.Size = new System.Drawing.Size(120, 16);
			this.txtMoney.TabIndex = 72;
			this.txtMoney.Text = "";
			this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(248, 328);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(20, 19);
			this.label66.TabIndex = 144;
			this.label66.Text = "元";
			// 
			// label69
			// 
			this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label69.Location = new System.Drawing.Point(637, 376);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(119, 1);
			this.label69.TabIndex = 149;
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(524, 356);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(99, 19);
			this.label70.TabIndex = 79;
			this.label70.Text = "门(急)诊医生:";
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(40, 356);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(99, 19);
			this.label71.TabIndex = 77;
			this.label71.Text = "门(急)诊诊断:";
			// 
			// txtDiag
			// 
			this.txtDiag.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDiag.Location = new System.Drawing.Point(144, 356);
			this.txtDiag.MaxLength = 30;
			this.txtDiag.Name = "txtDiag";
			this.txtDiag.SendTabKey = true;
			this.txtDiag.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtDiag.Size = new System.Drawing.Size(368, 16);
			this.txtDiag.TabIndex = 78;
			this.txtDiag.Text = "";
			// 
			// label72
			// 
			this.label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label72.Location = new System.Drawing.Point(144, 376);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(368, 1);
			this.label72.TabIndex = 153;
			// 
			// label67
			// 
			this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label67.Location = new System.Drawing.Point(637, 404);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(119, 1);
			this.label67.TabIndex = 156;
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Location = new System.Drawing.Point(524, 384);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(70, 19);
			this.label68.TabIndex = 155;
			this.label68.Text = "医生工号:";
			// 
			// txtDocNO
			// 
			this.txtDocNO.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDocNO.Location = new System.Drawing.Point(637, 384);
			this.txtDocNO.Name = "txtDocNO";
			this.txtDocNO.SendTabKey = true;
			this.txtDocNO.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtDocNO.Size = new System.Drawing.Size(119, 16);
			this.txtDocNO.TabIndex = 82;
			this.txtDocNO.Text = "";
			// 
			// label73
			// 
			this.label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label73.Location = new System.Drawing.Point(144, 404);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(368, 1);
			this.label73.TabIndex = 158;
			// 
			// txtDiag2
			// 
			this.txtDiag2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDiag2.Location = new System.Drawing.Point(144, 384);
			this.txtDiag2.MaxLength = 30;
			this.txtDiag2.Name = "txtDiag2";
			this.txtDiag2.SendTabKey = true;
			this.txtDiag2.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtDiag2.Size = new System.Drawing.Size(368, 16);
			this.txtDiag2.TabIndex = 81;
			this.txtDiag2.Text = "";
			// 
			// label74
			// 
			this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label74.Location = new System.Drawing.Point(80, 436);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(676, 1);
			this.label74.TabIndex = 161;
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.Location = new System.Drawing.Point(40, 416);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(41, 19);
			this.label75.TabIndex = 160;
			this.label75.Text = "备注:";
			// 
			// txtRemark
			// 
			this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRemark.Location = new System.Drawing.Point(80, 416);
			this.txtRemark.MaxLength = 50;
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.SendTabKey = true;
			this.txtRemark.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtRemark.Size = new System.Drawing.Size(672, 16);
			this.txtRemark.TabIndex = 83;
			this.txtRemark.Text = "";
			// 
			// btSave
			// 
			this.btSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btSave.Location = new System.Drawing.Point(108, 464);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(144, 36);
			this.btSave.TabIndex = 84;
			this.btSave.Text = "保存(&S)";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btPrint
			// 
			this.btPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btPrint.Location = new System.Drawing.Point(326, 464);
			this.btPrint.Name = "btPrint";
			this.btPrint.Size = new System.Drawing.Size(144, 36);
			this.btPrint.TabIndex = 85;
			this.btPrint.Text = "打印(&P)";
			this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
			// 
			// btCancel
			// 
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btCancel.Location = new System.Drawing.Point(544, 464);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(144, 36);
			this.btCancel.TabIndex = 86;
			this.btCancel.Text = "退出(ESC)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(316, 300);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 19);
			this.label1.TabIndex = 163;
			this.label1.Text = "时";
			// 
			// txtHour
			// 
			this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtHour.Location = new System.Drawing.Point(284, 300);
			this.txtHour.MaxLength = 2;
			this.txtHour.Name = "txtHour";
			this.txtHour.SendTabKey = true;
			this.txtHour.SetFocusColor = System.Drawing.Color.LightGray;
			this.txtHour.Size = new System.Drawing.Size(24, 16);
			this.txtHour.TabIndex = 67;
			this.txtHour.Text = "12";
			// 
			// label9
			// 
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label9.Location = new System.Drawing.Point(284, 320);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(24, 1);
			this.label9.TabIndex = 164;
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.printDocument1;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Location = new System.Drawing.Point(282, 0);
			this.printPreviewDialog1.MinimumSize = new System.Drawing.Size(375, 250);
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.TransparencyKey = System.Drawing.Color.Empty;
			this.printPreviewDialog1.Visible = false;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// m_txtAREAID_CHR
			// 
			this.m_txtAREAID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtAREAID_CHR.intHeight = 120;
			this.m_txtAREAID_CHR.isHide = 2;
			this.m_txtAREAID_CHR.isTxt = 1;
			this.m_txtAREAID_CHR.isUpOrDn = 0;
			this.m_txtAREAID_CHR.isValuse = 2;
			this.m_txtAREAID_CHR.Location = new System.Drawing.Point(644, 300);
			this.m_txtAREAID_CHR.m_IsHaveParent = false;
			this.m_txtAREAID_CHR.m_strParentName = "";
			this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
			this.m_txtAREAID_CHR.Size = new System.Drawing.Size(112, 21);
			this.m_txtAREAID_CHR.TabIndex = 70;
			this.m_txtAREAID_CHR.txtValuse = "";
			this.m_txtAREAID_CHR.VsLeftOrRight = 0;
			// 
			// m_txtOutPatientDoctor
			// 
			this.m_txtOutPatientDoctor.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtOutPatientDoctor.intHeight = 150;
			this.m_txtOutPatientDoctor.isHide = 2;
			this.m_txtOutPatientDoctor.isTxt = 1;
			this.m_txtOutPatientDoctor.isUpOrDn = 0;
			this.m_txtOutPatientDoctor.isValuse = 2;
			this.m_txtOutPatientDoctor.Location = new System.Drawing.Point(636, 356);
			this.m_txtOutPatientDoctor.m_IsHaveParent = false;
			this.m_txtOutPatientDoctor.m_strParentName = "";
			this.m_txtOutPatientDoctor.Name = "m_txtOutPatientDoctor";
			this.m_txtOutPatientDoctor.Size = new System.Drawing.Size(119, 24);
			this.m_txtOutPatientDoctor.TabIndex = 201;
			this.m_txtOutPatientDoctor.txtValuse = "";
			this.m_txtOutPatientDoctor.VsLeftOrRight = 0;
			// 
			// cmbNationality
			// 
			this.cmbNationality.Location = new System.Drawing.Point(254, 504);
			this.cmbNationality.Name = "cmbNationality";
			this.cmbNationality.Size = new System.Drawing.Size(120, 22);
			this.cmbNationality.TabIndex = 202;
			// 
			// cmbCountry
			// 
			this.cmbCountry.Location = new System.Drawing.Point(422, 504);
			this.cmbCountry.Name = "cmbCountry";
			this.cmbCountry.Size = new System.Drawing.Size(112, 22);
			this.cmbCountry.TabIndex = 203;
			// 
			// frmInhospitalCard
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(804, 528);
			this.Controls.Add(this.cmbCountry);
			this.Controls.Add(this.cmbNationality);
			this.Controls.Add(this.chk_Married);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtHour);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.txtRemark);
			this.Controls.Add(this.txtDiag2);
			this.Controls.Add(this.txtDiag);
			this.Controls.Add(this.txtMoney);
			this.Controls.Add(this.txtAddress2);
			this.Controls.Add(this.txtRelation);
			this.Controls.Add(this.txtLinkman);
			this.Controls.Add(this.txtHomeAddress);
			this.Controls.Add(this.txtAddress);
			this.Controls.Add(this.txtWork);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btPrint);
			this.Controls.Add(this.btSave);
			this.Controls.Add(this.txtPostalcode);
			this.Controls.Add(this.txtPostalcode2);
			this.Controls.Add(this.chk_NotMarry);
			this.Controls.Add(this.label74);
			this.Controls.Add(this.label75);
			this.Controls.Add(this.label73);
			this.Controls.Add(this.label67);
			this.Controls.Add(this.label68);
			this.Controls.Add(this.txtDocNO);
			this.Controls.Add(this.label72);
			this.Controls.Add(this.label69);
			this.Controls.Add(this.label70);
			this.Controls.Add(this.label71);
			this.Controls.Add(this.label66);
			this.Controls.Add(this.chk_Normal);
			this.Controls.Add(this.chk_Urgent);
			this.Controls.Add(this.chk_danger);
			this.Controls.Add(this.label27);
			this.Controls.Add(this.label64);
			this.Controls.Add(this.label65);
			this.Controls.Add(this.label25);
			this.Controls.Add(this.label26);
			this.Controls.Add(this.label62);
			this.Controls.Add(this.label63);
			this.Controls.Add(this.txtDepartment);
			this.Controls.Add(this.label28);
			this.Controls.Add(this.txtInDay);
			this.Controls.Add(this.label52);
			this.Controls.Add(this.label53);
			this.Controls.Add(this.txtInMonth);
			this.Controls.Add(this.label57);
			this.Controls.Add(this.txtInYear);
			this.Controls.Add(this.label59);
			this.Controls.Add(this.label60);
			this.Controls.Add(this.label61);
			this.Controls.Add(this.label24);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtTel2);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label222);
			this.Controls.Add(this.label50);
			this.Controls.Add(this.label51);
			this.Controls.Add(this.label54);
			this.Controls.Add(this.label55);
			this.Controls.Add(this.label46);
			this.Controls.Add(this.label47);
			this.Controls.Add(this.label48);
			this.Controls.Add(this.label49);
			this.Controls.Add(this.txtTel);
			this.Controls.Add(this.label56);
			this.Controls.Add(this.label58);
			this.Controls.Add(this.label44);
			this.Controls.Add(this.label45);
			this.Controls.Add(this.txtID);
			this.Controls.Add(this.label42);
			this.Controls.Add(this.label43);
			this.Controls.Add(this.txtCountry);
			this.Controls.Add(this.label40);
			this.Controls.Add(this.label41);
			this.Controls.Add(this.txtNationality);
			this.Controls.Add(this.label38);
			this.Controls.Add(this.label39);
			this.Controls.Add(this.txtCounty);
			this.Controls.Add(this.label36);
			this.Controls.Add(this.label37);
			this.Controls.Add(this.txtBornPlace);
			this.Controls.Add(this.label35);
			this.Controls.Add(this.txtAge);
			this.Controls.Add(this.label33);
			this.Controls.Add(this.label34);
			this.Controls.Add(this.label32);
			this.Controls.Add(this.txtAgeDay);
			this.Controls.Add(this.label30);
			this.Controls.Add(this.label31);
			this.Controls.Add(this.txtAgeMonth);
			this.Controls.Add(this.label29);
			this.Controls.Add(this.txtAgeYear);
			this.Controls.Add(this.chk_Woman);
			this.Controls.Add(this.chk_Man);
			this.Controls.Add(this.label22);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label20);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.chk_Insurance);
			this.Controls.Add(this.txtNo);
			this.Controls.Add(this.txtInsurance);
			this.Controls.Add(this.lbeTimes);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbeHospitalTitle);
			this.Controls.Add(this.m_txtAREAID_CHR);
			this.Controls.Add(this.m_txtOutPatientDoctor);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmInhospitalCard";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "住院卡";
			this.Load += new System.EventHandler(this.frmInhospitalCard_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmInhospitalCard_Load(object sender, System.EventArgs e)
		{
			this.m_mthHandleCheckBoxControl();
			if(this.objSvc==null)
			{
			this.objSvc =new clsDcl_DoctorWorkstation();
			}
			this.m_mthGetInhospitalTimes();
			LoadAreaID();
			m_mthSetTxtStyle(m_txtAREAID_CHR);
			m_mthLoadMainDoctor();
			m_mthFillcomBoBox();
			m_mthSetTxtStyle(m_txtOutPatientDoctor);
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void m_mthHandleCheckBoxControl()
		{
			foreach(System.Windows.Forms.Control c in this.Controls)
			{
				if(c is CheckBox)
				{
				c.KeyDown +=new KeyEventHandler(Control_KeyDown);
				}
			}
		}

		

		private void Control_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			SendKeys.SendWait("{Tab}");
			}
		}
		#region 性别选择
		private void chk_Man_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_Man.Checked)
			{
				chk_Woman.Checked =false;
			}
			else
			{
				chk_Woman.Checked =true;
			}
		}

		private void chk_Woman_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_Woman.Checked)
			{
				chk_Man.Checked =false;
			}
			else
			{
				chk_Man.Checked =true;
			}
		}
		#endregion
		#region 婚姻选择
		private void chk_Married_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_Married.Checked)
			{
				chk_NotMarry.Checked =false;
			}
			else
			{
				chk_NotMarry.Checked =true;
			}
		}

		private void chk_NotMarry_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_NotMarry.Checked)
			{
				chk_Married.Checked =false;
			}
			else
			{
				chk_Married.Checked =true;
			}
		}
		#endregion
		#region 入情况选择
		private void chk_danger_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_danger.Checked)
			{
				chk_Urgent.Checked =false;
				chk_Normal.Checked =false;
			}
			else
			{
				chk_Urgent.Checked =true;
//				chk_Normal.Checked =true;
			}
		}

		private void chk_Urgent_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_Urgent.Checked)
			{
				chk_danger.Checked =false;
				chk_Normal.Checked =false;
			}
			else
			{
//				chk_danger.Checked =true;
				chk_Normal.Checked =true;
			}
		}

		private void chk_Normal_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_Normal.Checked)
			{
				chk_Urgent.Checked =false;
				chk_danger.Checked =false;
			}
			else
			{
//				chk_Urgent.Checked =true;
				chk_danger.Checked =true;
			}
		}
	
		#endregion

		private void chk_Insurance_CheckedChanged(object sender, System.EventArgs e)
		{
			if(chk_Insurance.Checked)
			{
				this.txtInsurance.Enabled =true;
			}
			else
			{
				this.txtInsurance.Enabled =false;
			}
		}
		#region 自定义属性
		/// <summary>
		/// 医保号
		/// </summary>
		public string InsuranceNo
		{
			set
			{
			this.txtInsurance.Text =value;
			}
			get
			{
			return this.txtInsurance.Text;
			}
		}
		/// <summary>
		/// 入院次数
		/// </summary>
		public string InHospitalTimes
		{
			set
			{
			this.lbeTimes.Text =value;
			}
			get
			{
			return this.lbeTimes.Text;
			}
		}
		/// <summary>
		/// 病案号
		/// </summary>
		public string strNo
		{
			set
			{
			this.txtNo.Text =value;
			}
			get
			{
			return this.txtNo.Text;
			}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string PatientName
		{
			set
			{
			this.txtName.Text =value;
			}
			get
			{
			return this.txtName.Text;
			}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set
			{
				if(value.IndexOf("男")>-1)
				{
					this.chk_Man.Checked=true;
				}
				else
				{
				this.chk_Woman.Checked =true;
				}
			}
			get
			{
				if(this.chk_Man.Checked)
				{
					return "男";
				}
				else
				{
				return "女";
				}
			}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public string BirthDay
		{
			set
			{
				try
				{
				DateTime d =DateTime.Parse(value);
				this.txtAgeYear.Text =d.Year.ToString();
				this.txtAgeMonth.Text =d.Month.ToString();
				this.txtAgeDay.Text =d.Day.ToString();
				}
				catch
				{
					this.txtAgeYear.Text =DateTime.Now.Year.ToString();
					this.txtAgeMonth.Text =DateTime.Now.Month.ToString();
					this.txtAgeDay.Text =DateTime.Now.Day.ToString();
				}
			}
			get
			{
				return this.txtAgeYear.Text.PadLeft(4,'1')+"-"+this.txtAgeMonth.Text.PadLeft(2,'0')+"-"+this.txtAgeDay.Text.PadLeft(2,'0');
			}
		}
		/// <summary>
		/// 年龄
		/// </summary>
		public string Age
		{
			get
			{
			return this.txtAge.Text;
			}
			set
			{
			this.txtAge.Text =value;
			}
		}
		/// <summary>
		/// 婚否
		/// </summary>
		public string Marry
		{
			set
			{
				if(value.IndexOf("未")>-1||value=="1")
				{
					this.chk_Married.Checked=false;
				}
				else
				{
					this.chk_NotMarry.Checked =true;
				}
			}
			get
			{
				if(this.chk_Married.Checked)
				{
					return "未";
				}
				else
				{
					return "已";
				}
			}
		}
		/// <summary>
		/// 职业
		/// </summary>
		public string Work
		{
			set
			{
			this.txtWork.Text =value;
			}
			get
			{
			return this.txtWork.Text;
			}
		}
		/// <summary>
		/// 出生地
		/// </summary>
		public string BirthPlace
		{
			set
			{
			this.txtBornPlace.Text =value;
			}
			get
			{
			return this.txtBornPlace.Text;
			}
		}
		/// <summary>
		/// 县
		/// </summary>
		public string County
		{
			set
			{
				this.txtCounty.Text =value;
			}
			get
			{
				return this.txtCounty.Text;
			}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string Nationality
		{
			set
			{
				this.txtNationality.Text =value;
			}
			get
			{
				return this.txtNationality.Text;
			}
		}
		/// <summary>
		/// 国籍
		/// </summary>
		public string Country
		{
			set
			{
				this.txtCountry.Text =value;
			}
			get
			{
				return this.txtCountry.Text;
			}
		}
		/// <summary>
		/// 身份证
		/// </summary>
		public string PID
		{
			set
			{
				this.txtID.Text =value;
			}
			get
			{
				return this.txtID.Text;
			}
		}
		/// <summary>
		/// 工作地址
		/// </summary>
		public string WorkAddress
		{
			set
			{
			this.txtAddress.Text=value;
			}
			get
			{
			return this.txtAddress.Text;
			}
		}
		/// <summary>
		/// 工作电话
		/// </summary>
		public string WorkTel
		{
			set
			{
				this.txtTel.Text=value;
			}
			get
			{
				return this.txtTel.Text;
			}
		}
		/// <summary>
		/// 工作邮政编码
		/// </summary>
		public string WorkPostalcode
		{
			set
			{
				this.txtPostalcode.Text=value;
			}
			get
			{
				return this.txtPostalcode.Text;
			}
		}
		/// <summary>
		/// 家庭地址
		/// </summary>
		public string HomeAddress
		{
			set
			{
				this.txtHomeAddress.Text=value;
			}
			get
			{
				return this.txtHomeAddress.Text;
			}
		}
		/// <summary>
		/// 家庭邮政编码
		/// </summary>
		public string HomePostalcode
		{
			set
			{
				this.txtPostalcode2.Text=value;
			}
			get
			{
				return this.txtPostalcode2.Text;
			}
		}
		/// <summary>
		/// 联系人
		/// </summary>
		public string LinkMan
		{
			set
			{
				this.txtLinkman.Text=value;
			}
			get
			{
				return this.txtLinkman.Text;
			}
		}
		/// <summary>
		/// 关系
		/// </summary>
		public string Relation
		{
			set
			{
				this.txtRelation.Text=value;
			}
			get
			{
				return this.txtRelation.Text;
			}
		}
		/// <summary>
		/// 联系人地址
		/// </summary>
		public string RelationAddress
		{
			set
			{
				this.txtAddress2.Text=value;
			}
			get
			{
				return this.txtAddress2.Text;
			}
		}
		/// <summary>
		/// 联系人电话
		/// </summary>
		public string RelationTel
		{
			set
			{
				this.txtTel2.Text=value;
			}
			get
			{
				return this.txtTel2.Text;
			}
		}
		/// <summary>
		/// 入院日期
		/// </summary>
		public string InhospitalDate
		{
			set
			{
				try
				{
					DateTime d =DateTime.Parse(value);
					this.txtInYear.Text =d.Year.ToString();
					this.txtInMonth.Text =d.Month.ToString();
					this.txtInDay.Text =d.Day.ToString();
					this.txtHour.Text =d.Hour.ToString();
				}
				catch
				{
					this.txtInYear.Text =DateTime.Now.Year.ToString();
					this.txtInMonth.Text =DateTime.Now.Month.ToString();
					this.txtInDay.Text =DateTime.Now.Day.ToString();
					this.txtInDay.Text =DateTime.Now.Hour.ToString();
				}
			}
			get
			{
				return this.txtInYear.Text.PadLeft(4,'1')+"-"+this.txtInMonth.Text.PadLeft(2,'0')+"-"+this.txtInDay.Text.PadLeft(2,'0')+" "+this.txtHour.Text;
			}
		}
		/// <summary>
		/// 科室
		/// </summary>
		public string Department
		{
			set
			{
			this.txtDepartment.Text =value;
			}
			get
			{
			return this.txtDepartment.Text;
			}
		}
		/// <summary>
		/// 病室
		/// </summary>
		public string Room
		{
			set
			{
				this.m_txtAREAID_CHR.txtValuse =value;
			}
			get
			{
				return this.m_txtAREAID_CHR.txtValuse;
			}
		}
		/// <summary>
		/// 按金
		/// </summary>
		public string Money
		{
			set
			{
			 this.txtMoney.Text =value;
			}
			get
			{
			return this.txtMoney.Text;
			}
		}
	/// <summary>
	/// 入院情况
	/// </summary>
		public string InHospitalCase
		{
			set
			{
				switch(value)
				{
					case "危":
						this.chk_danger.Checked =true;
						this.chk_Urgent.Checked =false;
						this.chk_Normal.Checked =false;
						break;
					case "急":
						this.chk_danger.Checked =false;
						this.chk_Urgent.Checked =true;
						this.chk_Normal.Checked =false;
						break;
					default:
						this.chk_danger.Checked =false;
						this.chk_Urgent.Checked =false;
						this.chk_Normal.Checked =true;
						break;
				}
			}
			get
			{
				string ret ="一般";
				if(chk_danger.Checked)
				{
				ret ="危";
				}
				if(chk_Urgent.Checked)
				{
					ret ="急";
				}
			return ret;
			}
		}
		/// <summary>
		/// 诊断
		/// </summary>
		public string Diag
		{
			set
			{
				if(value.Length>30)
				{
					this.txtDiag.Text =value.Substring(0,30);
					this.txtDiag2.Text =value.Substring(30,value.Length -30);
				}
				else
				{
				this.txtDiag.Text =value;
				}
			}
			get
			{
			return this.txtDiag.Text+this.txtDiag2.Text;
			}
		}
		/// <summary>
		/// 医生工号
		/// </summary>
		public string DoctorNo
		{
			set
			{
			 this.txtDocNO.Text =value;
			}
			get
			{
			return this.txtDocNO.Text;
			}
		}
		/// <summary>
		/// 医生名称
		/// </summary>
		public string DoctorName
		{
			set
			{
				this.m_txtOutPatientDoctor.txtValuse =value;
			}
			get
			{
				return this.m_txtOutPatientDoctor.txtValuse;
			}
		}
		private string _doctorID ="";
		/// <summary>
		/// 医生ID
		/// </summary>
		public string DoctorID
		{
			set
			{
				_doctorID =value;
			}
			get
			{
				return _doctorID;
			}
		}
		private string _ICDCode ="";
		/// <summary>
		/// ICD码
		/// </summary>
		public string ICDCode
		{
			set
			{
				_ICDCode =value;
			}
			get
			{
				return _ICDCode;
			}
		}
		private string _ICDName ="";
		/// <summary>
		/// ICD名称
		/// </summary>
		public string ICDName
		{
			set
			{
				_ICDName =value;
			}
			get
			{
				return _ICDName;
			}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set
			{
			this.txtRemark.Text =value;
			}
			get
			{
			return this.txtRemark.Text;
			}
		}
		private string _patientID="";
		/// <summary>
		/// 病人ID
		/// </summary>
		public string PatientID
		{
			set
			{
				_patientID =value;
			}
			get
			{
				return _patientID;
			}
		}
		public clsDcl_DoctorWorkstation DataServer
		{
			set
			{
			this.objSvc= value;
			}
		}
		private string _INPATIENTID="";
		/// <summary>
		/// 住院号
		/// </summary>
		public string InpatientID
		{
			set
			{
				_INPATIENTID =value;
			}
			get
			{
				return _INPATIENTID;
			}
		}
		/// <summary>
		/// 医院标题
		/// </summary>
		public string HospitalTitle
		{
			set
			{
			this.lbeHospitalTitle.Text =value+"住院卡";
			}
			get
			{
			return this.lbeHospitalTitle.Text;
			}
		}
		#endregion
		private clsDcl_DoctorWorkstation objSvc;


		/// <summary>
		/// 控件赋值给Vo {住院信息}
		/// </summary>
		private bool ValueToVoForBIHInfo()
		{
			if(this.btSave.Tag==null)
			{
				//入院登记流水号(200409010001)
				objOBRVO.m_strREGISTERID_CHR = "";
			}
			else
			{
				objOBRVO.m_strREGISTERID_CHR = this.btSave.Tag.ToString();
			}
			//病人ＩＤ
			objOBRVO.m_strPATIENTID_CHR = this.PatientID;
			//是否预约
			objOBRVO.m_intISBOOKING_INT = 0;
			//住院号
			objOBRVO.m_strINPATIENTID_CHR = InpatientID;
			if(objOBRVO.m_strINPATIENTID_CHR == "")
			{
				string p_strTemp;
				if(objSvc.m_lngGetInpatientID(out p_strTemp)>0)
				{
					objOBRVO.m_strINPATIENTID_CHR = p_strTemp;
					InpatientID = p_strTemp;
				}
				else
				{
					MessageBox.Show("获取住院号失败!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}
			}
			objOBRVO.m_strINPATIENT_DAT =DateTime.Now.ToString();
			//入院科室、入院病区、入院病床
			objOBRVO.m_strDEPTID_CHR = "";
			objOBRVO.m_strBEDID_CHR = "";
			objOBRVO.m_strAREAID_CHR ="";
			//入院病区
			if(m_txtAREAID_CHR.Tag!=null)
			{
				objOBRVO.m_strAREAID_CHR = ((string)m_txtAREAID_CHR.Tag).ToString();
			}
			else
			{
				MessageBox.Show("请选择入院病区!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				m_txtAREAID_CHR.Focus();
				return false;
			}
			//门诊医生
			if(m_txtOutPatientDoctor.Tag!=null)
			{
				objOBRVO.m_strMZDOCTOR_CHR = ((string)m_txtOutPatientDoctor.Tag).ToString();
			}
			else
			{
				objOBRVO.m_strMZDOCTOR_CHR = DoctorID;
			}
			objOBRVO.m_strCASEDOCTOR_CHR = "";
			//入院方式 {１门诊、２急诊、３他院转入}
			objOBRVO.m_intTYPE_INT = 1;
			//入院诊断
			objOBRVO.m_strDIAGNOSE_VCHR = "";
//			//费用下限
//			try
//			{
//				Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY.Text.Trim());
//			}
//			catch
//			{
//				m_objViewer.m_txtLIMITRATE_MNY.Focus();
//				MessageBox.Show(this.m_objViewer,"请输入有效数字");
//				return false;
//			}
			objOBRVO.m_dblLIMITRATE_MNY = 0;
//			//入院次数
//			string[] registeridArr;
//			long lngRes = m_objRegister.m_lngGetRegisteridByInpatientID(m_strInPatientID,out registeridArr);
//			//
//			try
//			{
//				Convert.ToInt32(m_objViewer.m_txtINPATIENTCOUNT_INT.Text.Trim());
//			}
//			catch
//			{
//				m_objViewer.m_txtINPATIENTCOUNT_INT.Focus();
//				MessageBox.Show("请输入有效数字");
//				return false;
//			}
//			int a =0;
//			if(this.m_intPStatus==-1||this.m_intPStatus==3)
//			{
//				a = int.Parse(m_objViewer.m_txtINPATIENTCOUNT_INT.Text.Trim())-1;
//			}
//			else
//			{
//				a = int.Parse(m_objViewer.m_txtINPATIENTCOUNT_INT.Text.Trim());
//			}
//			if(registeridArr.Length>a)
//			{
//				MessageBox.Show(this.m_objViewer,"非法的住院次数!!");
//				m_objViewer.m_txtINPATIENTCOUNT_INT.Focus();
//				return false;
//			}
			objOBRVO.m_intINPATIENTCOUNT_INT =int.Parse(this.InHospitalTimes);
			//病情　｛１危、２急、３普通｝
			if(this.chk_danger.Checked)
			{
				objOBRVO.m_intSTATE_INT =1;
			}
			if(this.chk_Urgent.Checked)
			{
				objOBRVO.m_intSTATE_INT =2;
			}
			if(this.chk_Normal.Checked)
			{
				objOBRVO.m_intSTATE_INT =3;
			}
			//状态　｛－１历史、０无效、１有效｝
			objOBRVO.m_intSTATUS_INT = 2;
			//操作人、操作时间
			objOBRVO.m_strOPERATORID_CHR = this.DoctorID;
			objOBRVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			//患者在院状态	{0=未上床;1=已上床;2=预出院;3=实际出院}
			objOBRVO.m_intPSTATUS_INT =0;
			
			//备注
			objOBRVO.DES_VCHR = this.Remark;
			//住院号类型
			objOBRVO.m_intINPATIENTNOTYPE_INT = 1;
			//门诊诊断
			objOBRVO.m_strMZDIAGNOSE_VCHR = this.Diag;
			objOBRVO.m_strDIAGNOSEID_CHR="";
			objOBRVO.m_strCLINICSAYPREPAY = txtMoney.Text.Trim();			
			#region 入院诊断ICD10 glzhang	2005.08.10
			objOBRVO.m_strICD10DIAGID_VCHR = this.ICDCode;
			objOBRVO.m_strICD10DIAGTEXT_VCHR = this.ICDName;
			#endregion

			return true;
		}
		private void m_mthGetInhospitalTimes()
		{
			DataTable dt;
			long ret =this.objSvc.m_mthFindInhospitalTimesByID(this.PatientID,out dt);
			if(ret>0&&dt.Rows.Count>0)
			{
				this.strNo =dt.Rows[0]["INPATIENTID_CHR"].ToString();
				this.Work =dt.Rows[0]["OCCUPATION_VCHR"].ToString();
				this.WorkAddress =dt.Rows[0]["EMPLOYER_VCHR"].ToString()+dt.Rows[0]["OFFICEADDRESS_VCHR"].ToString();
				this.WorkPostalcode =dt.Rows[0]["OFFICEPC_VCHR"].ToString();
				this.WorkTel =dt.Rows[0]["OFFICEPHONE_VCHR"].ToString();
				this.Relation =dt.Rows[0]["PATIENTRELATION_VCHR"].ToString();
				this.RelationAddress =dt.Rows[0]["CONTACTPERSONADDRESS_VCHR"].ToString();
				this.RelationTel =dt.Rows[0]["CONTACTPERSONPHONE_VCHR"].ToString();
				this.PID =dt.Rows[0]["IDCARD_CHR"].ToString();
				this.Nationality =dt.Rows[0]["RACE_VCHR"].ToString();
				this.Marry =dt.Rows[0]["MARRIED_CHR"].ToString();
				this.LinkMan =dt.Rows[0]["CONTACTPERSONLASTNAME_VCHR"].ToString();
//				this.InsuranceNo =dt.Rows[0]["INPATIENTID_CHR"].ToString();
				this.InpatientID =dt.Rows[0]["INPATIENTID_CHR"].ToString();
				this.HomePostalcode =dt.Rows[0]["HOMEPC_CHR"].ToString();
				this.HomeAddress =dt.Rows[0]["HOMEADDRESS_VCHR"].ToString();
				this.County =dt.Rows[0]["NATIVEPLACE_VCHR"].ToString();
				this.Country =dt.Rows[0]["NATIONALITY_VCHR"].ToString();
				this.BirthPlace =dt.Rows[0]["BIRTHPLACE_VCHR"].ToString();
				this.InhospitalDate =DateTime.Now.ToString();
			
//				this.BirthDay =dt.Rows[0]["INPATIENTID_CHR"].ToString();

				
				if(dt.Rows[0]["TIMES"].ToString().Trim()!="")
				{
					this.InHospitalTimes =(int.Parse(dt.Rows[0]["TIMES"].ToString())+1).ToString();
				}
				else
				{
				this.InHospitalTimes ="1";
				}

			}
			else
			{
				this.InHospitalTimes ="1";
			}
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			long ret =-1;
			if(this.ValueToVoForBIHInfo() == true)
			{
				if(this.btSave.Tag==null)
				{
					DataTable p_dtbResult;
					ret=this.objSvc.m_lngGetPatientInHospitalInfo(PatientID,0,out p_dtbResult);
					if(ret>0 && p_dtbResult.Rows.Count<1)
					{
						ret =this.objSvc.m_mthAddInHospitalApply(out this.objOBRVO.m_strREGISTERID_CHR,this.objOBRVO);
					}
					else
					{
						MessageBox.Show("当前病人已有在院信息!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
					}
				}
				else
				{
					ret =this.objSvc.m_mthUpdateInHospitalApply(this.objOBRVO.m_strREGISTERID_CHR,this.objOBRVO);
				}
				if(ret>0)
				{
					this.btSave.Tag =this.objOBRVO.m_strREGISTERID_CHR;
					MessageBox.Show("保存成功","提示");
				}
				else
				{
					MessageBox.Show("保存失败","提示");
				}
			}
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			clsApplyInHospitalPrint_VO vo =new clsApplyInHospitalPrint_VO();
			vo.Age =this.Age;
			vo.BirthDay_Day =this.txtAgeDay.Text;
			vo.BirthDay_Month =this.txtAgeMonth.Text;
			vo.BirthDay_Year =this.txtAgeYear.Text;
			vo.BirthPlace =this.BirthPlace;
			vo.Country =this.Country;
			vo.County =this.County;
			vo.Department =this.Department;
			vo.Diag =this.Diag;
			vo.DoctorName =this.DoctorName;
			vo.DoctorNo =this.DoctorNo;
			vo.HomeAddress =this.HomeAddress;
			vo.HomePostalcode =this.HomePostalcode;
			vo.HospitalTitle =this.HospitalTitle;
			vo.ICDCode =this.ICDCode;
			vo.ICDName =this.ICDName;
			vo.InHospitalCase=this.InHospitalCase;
			vo.InhospitalDate_Day=this.txtInDay.Text;
			vo.InhospitalDate_Hour =this.txtHour.Text;
			vo.InhospitalDate_Month =this.txtInMonth.Text;
			vo.InhospitalDate_Year =this.txtInYear.Text;
			vo.InHospitalTimes =this.InHospitalTimes;
			vo.InpatientID =this.InpatientID;
			vo.InsuranceNo =this.InsuranceNo;
			vo.LinkMan =this.LinkMan;
			vo.Marry =this.Marry;
			vo.Money =this.Money;
			vo.Nationality =this.Nationality;
			vo.PatientName =vo.PatientName;
			vo.PID =this.PID;
			vo.Relation =this.Relation;
			vo.RelationAddress =this.RelationAddress;
			vo.RelationTel =this.RelationTel;
			vo.Remark =this.Remark;
			vo.Room =this.Room;
			vo.Sex =this.Sex;
			vo.PatientName =this.PatientName;
			vo.strNo=this.strNo;
			vo.Work =this.Work;
			vo.WorkPostalcode =this.WorkPostalcode;
			vo.WorkTel =this.WorkTel;
			vo.WorkAddress =this.WorkAddress;
			clsPrintApplyInHospital objPrint =new clsPrintApplyInHospital(vo);
			objPrint.m_mthBegionPrint(e);
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
			this.printPreviewDialog1.ShowDialog();
		}

		#region 载入科室对应的病区	glzhang	2005.10.11
		/// <summary>
		/// 载入科室对应的病区	glzhang	2005.10.11
		/// </summary>
		public void LoadAreaID()
		{
			DataTable dtbTemp = new DataTable();
			
			dtbTemp.Columns.Add(" 病区编号 ");
			dtbTemp.Columns.Add(" 病区名称 ");
			dtbTemp.Columns.Add("id");
			
			DataRow dtRTemp;
			//科室ID为空则返回
			//			if(m_objViewer.m_txtDEPTID_CHR.Value.Trim()=="") return;

			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] ResultArr = null;
			string strFilter = "WHERE Trim(attributeid) = '0000003' AND STATUS_INT = 1 AND (Trim(lower(shortno_chr)) LIKE '"+m_txtAREAID_CHR.txtValuse.ToString().Trim().ToLower()+"%' or Trim(lower(DEPTNAME_VCHR)) like '"+m_txtAREAID_CHR.txtValuse.ToString().Trim().ToLower()+"%' or Trim(lower(PYCODE_CHR)) like '"+m_txtAREAID_CHR.txtValuse.ToString().Trim().ToLower()+"%' or Trim(lower(WBCODE_CHR)) like '"+m_txtAREAID_CHR.txtValuse.ToString().Trim().ToLower()+"%')";
			long lngRes = objSvc.m_lngGetAreaInfo(strFilter,out ResultArr);

			if(lngRes>0&&ResultArr.Length >0)
			{
				for(int i = 0; i < ResultArr.Length; i++)
				{
					dtRTemp = dtbTemp.NewRow();
					dtRTemp[0] =ResultArr[i].m_strCODE_VCHR;
					dtRTemp[1] =ResultArr[i].m_strDEPTNAME_VCHR;
					dtRTemp[2] =ResultArr[i].m_strDEPTID_CHR;
					dtbTemp.Rows.Add(dtRTemp);
				}
				m_txtAREAID_CHR.m_GetDataTable = dtbTemp;
			}
				
		}

		/// <summary>
		/// 设置文本框样式 
		/// </summary>
		/// <param name="p_conTemp"></param>
		public void m_mthSetTxtStyle(Control p_conTemp)
		{
			foreach(Control m_control in p_conTemp.Controls)
			{
				if(m_control.Controls.Count>1)
				{
					m_mthSetTxtStyle(m_control);
				}
				if (m_control is TextBox)
				{
					TextBox m_txtTemp = (TextBox)m_control;
					m_txtTemp.BorderStyle = System.Windows.Forms.BorderStyle.None;
					break;
				}
			}
		}
		#endregion

		#region 加载下拉框
		private void m_mthFillcomBoBox()
		{
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(2,out objResultArr);
			this.cmbCountry.Items.Add("");
			this.cmbNationality.Items.Add("");
			for(int i=0;i<objResultArr.Length;i++)
			{
				this.cmbCountry.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
			clscommanInfo.m_mthGetAID_DICT_InfoArr(1,out objResultArr);
			for(int i=0;i<objResultArr.Length;i++)
			{
				this.cmbNationality.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
			
		    cmbNationality.KeyDown+=new KeyEventHandler(cmbNationality_KeyDown);
			cmbNationality.Leave+=new EventHandler(cmbNationality_Leave);
			cmbNationality.Visible =false;
			cmbCountry.Visible =false;
			this.txtCountry.Controls.Add(cmbCountry);
			cmbCountry.Size =this.txtCountry.Size;
			cmbCountry.Dock =DockStyle.Fill;
			cmbCountry.KeyDown+=new KeyEventHandler(cmbCountry_KeyDown);
			cmbCountry.Leave+=new EventHandler(cmbCountry_Leave);
		}
		#endregion
		#region 载入门诊医生信息	glzhang		2005.07.12
		/// <summary>
		/// 载入门诊医生信息	glzhang		2005.07.12
		/// </summary>
		public void m_mthLoadMainDoctor()
		{
			DataTable tempTable = new DataTable();

			DataRow tempRow;
			com.digitalwave.iCare.ValueObject.clsEmployee_VO[] DataResultArr =null;
			long lngRes = objSvc.m_lngGetMainDoctor(m_txtOutPatientDoctor.Text.ToString().Trim().ToUpper(),out DataResultArr);
			if(lngRes>0&&DataResultArr.Length >0)
			{
				tempTable.Columns.Add("编号	");
				tempTable.Columns.Add("医生	");
				tempTable.Columns.Add("ID");
				for(int i = 0;i<DataResultArr.Length;i++)
				{
					tempRow = tempTable.NewRow();
					tempRow[0]=DataResultArr[i].m_strEMPNO_CHR;
					tempRow[1] = DataResultArr[i].m_strLASTNAME_VCHR;
					tempRow[2] = DataResultArr[i].m_strEMPID_CHR;
					tempTable.Rows.Add(tempRow);
				}
				m_txtOutPatientDoctor.m_GetDataTable = tempTable;
				tempTable.Dispose();
			}
		}
		#endregion

		private void txtAge_Leave(object sender, System.EventArgs e)
		{
			try
			{
				if(this.txtAge.Text.Trim()=="")
				{
					return;
				}
				int age =int.Parse(this.txtAge.Text);
				if(age<0||age>150)
				{
					this.txtAge.Text ="0";
					 MessageBox.Show("年龄输入有误！");
					this.txtAge.Focus();
					
					return;
				}
				DateTime dt =DateTime.Now.AddYears(-age);
				this.BirthDay =dt.ToString();

			}
			catch
			{
				this.txtAge.Text ="0";
				 MessageBox.Show("年龄输入有误！");
				this.txtAge.Focus();
				
			}
		}


		private void txtNationality_Enter(object sender, System.EventArgs e)
		{
			m_mthShowA();
		}

		private void cmbNationality_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			this.txtCountry.Focus();
			}
		}

		private void cmbNationality_Leave(object sender, EventArgs e)
		{
              this.txtNationality.Text =this.cmbNationality.Text;
			cmbNationality.Visible =false;
		}

		private void cmbCountry_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.txtID.Focus();
			}
		}

		private void cmbCountry_Leave(object sender, EventArgs e)
		{
			 this.txtCountry.Text =this.cmbCountry.Text;
			this.cmbCountry.Visible =false;
		}

		private void txtCountry_Enter(object sender, System.EventArgs e)
		{
			m_mthShowB();
		}

		private void txtNationality_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_mthShowA();
		}

		private void txtCountry_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			m_mthShowB();
		}
		private void m_mthShowA()
		{
			this.txtNationality.Controls.Add(cmbNationality);
			cmbNationality.Size =this.txtNationality.Size;
			cmbNationality.Dock =DockStyle.Fill;
			cmbNationality.Show();
			cmbNationality.BringToFront();
			cmbNationality.Focus();
			cmbNationality.Select();
			cmbNationality.Text =this.txtNationality.Text.Trim();
		}
		private void m_mthShowB()
		{
			this.txtCountry.Controls.Add(cmbCountry);
			cmbCountry.Size =this.txtCountry.Size;
			cmbCountry.Dock =DockStyle.Fill;
			cmbCountry.Show();
			cmbCountry.BringToFront();
			cmbCountry.Focus();
			cmbCountry.Select();
			cmbNationality.Text =txtCountry.Text;
		}
	}
}
