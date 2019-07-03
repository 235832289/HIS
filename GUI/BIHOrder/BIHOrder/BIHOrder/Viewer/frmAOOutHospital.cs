using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 出院附加单据编辑	界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-01-17
	/// </summary>
	public class frmAOOutHospital : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 控件申明
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.TextBox m_txtDESC_VCHR;
		private System.Windows.Forms.GroupBox groupBox3;
		internal PinkieControls.ButtonXP cmdOK;
		internal PinkieControls.ButtonXP cmdDel;
		private PinkieControls.ButtonXP cmdCanCel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label14;
		internal System.Windows.Forms.ComboBox m_cboTYPE_INT;
		internal System.Windows.Forms.ComboBox m_cboPSTATUS_INT;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label13;
		internal System.Windows.Forms.CheckBox m_chkISACTIVE_INT;
		internal System.Windows.Forms.TextBox m_lblPATIENTNAME_CHR;
		internal System.Windows.Forms.TextBox m_lblIDCARD_CHR;
		internal System.Windows.Forms.TextBox m_lblSEX_CHR;
		internal System.Windows.Forms.TextBox m_lblINPATIENTID_CHR;
		internal System.Windows.Forms.TextBox m_lblSTATUS_INT;
		internal System.Windows.Forms.TextBox m_lblACTIVEDATE_DAT;
		internal System.Windows.Forms.TextBox m_lblOUTBEDID_CHR;
		internal System.Windows.Forms.TextBox m_lblACTIVEEMPID_CHR;
		internal System.Windows.Forms.TextBox m_lblOUTAREAID_CHR;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// 登陆信息
		/// </summary>
		internal com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo=null;
		/// <summary>
		/// 附加单据ID
		/// </summary>
		internal string m_strAttachID ="";
		/// <summary>
		/// 医嘱ID
		/// </summary>
		internal string m_strOrderID ="";
		/// <summary>
		/// 编辑状态{0=增加;1=编辑;2=只读;}
		/// </summary>
		internal int m_intEditState=0;
		internal PinkieControls.ButtonXP cmdBecomeEffective;
		/// <summary>
		/// 病人ID
		/// </summary>
		internal string m_strPatientID ="";
		#endregion 

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public frmAOOutHospital()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strPatientID">病人ID</param>
		/// <param name="p_strOrderID">医嘱单ID</param>
		/// <param name="p_strAttachID">附加单据ID</param>
		/// <param name="p_intEditState">编辑状态{0=增加;1=编辑;2=只读;}</param>
		public frmAOOutHospital(string p_strPatientID,string p_strOrderID,string p_strAttachID,int p_intEditState)
		{
			m_strPatientID =p_strPatientID;
			m_strOrderID =p_strOrderID;
			m_strAttachID =p_strAttachID;
			m_intEditState =p_intEditState;
			InitializeComponent();
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
		#endregion 

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_lblINPATIENTID_CHR = new System.Windows.Forms.TextBox();
			this.m_lblSEX_CHR = new System.Windows.Forms.TextBox();
			this.m_lblIDCARD_CHR = new System.Windows.Forms.TextBox();
			this.m_lblPATIENTNAME_CHR = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.m_lblACTIVEEMPID_CHR = new System.Windows.Forms.TextBox();
			this.m_lblOUTBEDID_CHR = new System.Windows.Forms.TextBox();
			this.m_lblACTIVEDATE_DAT = new System.Windows.Forms.TextBox();
			this.m_lblSTATUS_INT = new System.Windows.Forms.TextBox();
			this.m_lblOUTAREAID_CHR = new System.Windows.Forms.TextBox();
			this.m_chkISACTIVE_INT = new System.Windows.Forms.CheckBox();
			this.m_cboTYPE_INT = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtDESC_VCHR = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.m_cboPSTATUS_INT = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmdCanCel = new PinkieControls.ButtonXP();
			this.cmdDel = new PinkieControls.ButtonXP();
			this.cmdBecomeEffective = new PinkieControls.ButtonXP();
			this.cmdOK = new PinkieControls.ButtonXP();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_lblINPATIENTID_CHR);
			this.groupBox1.Controls.Add(this.m_lblSEX_CHR);
			this.groupBox1.Controls.Add(this.m_lblIDCARD_CHR);
			this.groupBox1.Controls.Add(this.m_lblPATIENTNAME_CHR);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(368, 88);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "患者信息: ";
			// 
			// m_lblINPATIENTID_CHR
			// 
			this.m_lblINPATIENTID_CHR.Location = new System.Drawing.Point(208, 56);
			this.m_lblINPATIENTID_CHR.Name = "m_lblINPATIENTID_CHR";
			this.m_lblINPATIENTID_CHR.ReadOnly = true;
			this.m_lblINPATIENTID_CHR.Size = new System.Drawing.Size(144, 23);
			this.m_lblINPATIENTID_CHR.TabIndex = 3;
			this.m_lblINPATIENTID_CHR.Text = "";
			// 
			// m_lblSEX_CHR
			// 
			this.m_lblSEX_CHR.Location = new System.Drawing.Point(48, 56);
			this.m_lblSEX_CHR.Name = "m_lblSEX_CHR";
			this.m_lblSEX_CHR.ReadOnly = true;
			this.m_lblSEX_CHR.Size = new System.Drawing.Size(88, 23);
			this.m_lblSEX_CHR.TabIndex = 3;
			this.m_lblSEX_CHR.Text = "";
			// 
			// m_lblIDCARD_CHR
			// 
			this.m_lblIDCARD_CHR.Location = new System.Drawing.Point(208, 20);
			this.m_lblIDCARD_CHR.Name = "m_lblIDCARD_CHR";
			this.m_lblIDCARD_CHR.ReadOnly = true;
			this.m_lblIDCARD_CHR.Size = new System.Drawing.Size(144, 23);
			this.m_lblIDCARD_CHR.TabIndex = 3;
			this.m_lblIDCARD_CHR.Text = "";
			// 
			// m_lblPATIENTNAME_CHR
			// 
			this.m_lblPATIENTNAME_CHR.Location = new System.Drawing.Point(48, 20);
			this.m_lblPATIENTNAME_CHR.Name = "m_lblPATIENTNAME_CHR";
			this.m_lblPATIENTNAME_CHR.ReadOnly = true;
			this.m_lblPATIENTNAME_CHR.Size = new System.Drawing.Size(88, 23);
			this.m_lblPATIENTNAME_CHR.TabIndex = 3;
			this.m_lblPATIENTNAME_CHR.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "姓名：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(8, 60);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 19);
			this.label5.TabIndex = 2;
			this.label5.Text = "性别：";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(144, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(77, 19);
			this.label7.TabIndex = 2;
			this.label7.Text = "身份证号：";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(158, 60);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 19);
			this.label9.TabIndex = 2;
			this.label9.Text = "住院号：";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.m_lblACTIVEEMPID_CHR);
			this.groupBox2.Controls.Add(this.m_lblOUTBEDID_CHR);
			this.groupBox2.Controls.Add(this.m_lblACTIVEDATE_DAT);
			this.groupBox2.Controls.Add(this.m_lblSTATUS_INT);
			this.groupBox2.Controls.Add(this.m_lblOUTAREAID_CHR);
			this.groupBox2.Controls.Add(this.m_chkISACTIVE_INT);
			this.groupBox2.Controls.Add(this.m_cboTYPE_INT);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.m_txtDESC_VCHR);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.m_cboPSTATUS_INT);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label14);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label13);
			this.groupBox2.Location = new System.Drawing.Point(0, 100);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(536, 184);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "附加单据信息：";
			// 
			// m_lblACTIVEEMPID_CHR
			// 
			this.m_lblACTIVEEMPID_CHR.Location = new System.Drawing.Point(72, 80);
			this.m_lblACTIVEEMPID_CHR.Name = "m_lblACTIVEEMPID_CHR";
			this.m_lblACTIVEEMPID_CHR.ReadOnly = true;
			this.m_lblACTIVEEMPID_CHR.Size = new System.Drawing.Size(104, 23);
			this.m_lblACTIVEEMPID_CHR.TabIndex = 6;
			this.m_lblACTIVEEMPID_CHR.Text = "";
			// 
			// m_lblOUTBEDID_CHR
			// 
			this.m_lblOUTBEDID_CHR.Location = new System.Drawing.Point(424, 20);
			this.m_lblOUTBEDID_CHR.Name = "m_lblOUTBEDID_CHR";
			this.m_lblOUTBEDID_CHR.ReadOnly = true;
			this.m_lblOUTBEDID_CHR.Size = new System.Drawing.Size(104, 23);
			this.m_lblOUTBEDID_CHR.TabIndex = 6;
			this.m_lblOUTBEDID_CHR.Text = "";
			// 
			// m_lblACTIVEDATE_DAT
			// 
			this.m_lblACTIVEDATE_DAT.Location = new System.Drawing.Point(248, 80);
			this.m_lblACTIVEDATE_DAT.Name = "m_lblACTIVEDATE_DAT";
			this.m_lblACTIVEDATE_DAT.ReadOnly = true;
			this.m_lblACTIVEDATE_DAT.Size = new System.Drawing.Size(104, 23);
			this.m_lblACTIVEDATE_DAT.TabIndex = 6;
			this.m_lblACTIVEDATE_DAT.Text = "";
			// 
			// m_lblSTATUS_INT
			// 
			this.m_lblSTATUS_INT.Location = new System.Drawing.Point(248, 48);
			this.m_lblSTATUS_INT.Name = "m_lblSTATUS_INT";
			this.m_lblSTATUS_INT.ReadOnly = true;
			this.m_lblSTATUS_INT.Size = new System.Drawing.Size(104, 23);
			this.m_lblSTATUS_INT.TabIndex = 6;
			this.m_lblSTATUS_INT.Text = "";
			// 
			// m_lblOUTAREAID_CHR
			// 
			this.m_lblOUTAREAID_CHR.Location = new System.Drawing.Point(248, 20);
			this.m_lblOUTAREAID_CHR.Name = "m_lblOUTAREAID_CHR";
			this.m_lblOUTAREAID_CHR.ReadOnly = true;
			this.m_lblOUTAREAID_CHR.Size = new System.Drawing.Size(104, 23);
			this.m_lblOUTAREAID_CHR.TabIndex = 5;
			this.m_lblOUTAREAID_CHR.Text = "";
			// 
			// m_chkISACTIVE_INT
			// 
			this.m_chkISACTIVE_INT.Enabled = false;
			this.m_chkISACTIVE_INT.Location = new System.Drawing.Point(360, 47);
			this.m_chkISACTIVE_INT.Name = "m_chkISACTIVE_INT";
			this.m_chkISACTIVE_INT.Size = new System.Drawing.Size(88, 24);
			this.m_chkISACTIVE_INT.TabIndex = 4;
			this.m_chkISACTIVE_INT.Text = "是否生效";
			// 
			// m_cboTYPE_INT
			// 
			this.m_cboTYPE_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboTYPE_INT.Items.AddRange(new object[] {
															   "",
															   "治愈出院",
															   "转院",
															   "其它",
															   "死亡"});
			this.m_cboTYPE_INT.Location = new System.Drawing.Point(72, 21);
			this.m_cboTYPE_INT.Name = "m_cboTYPE_INT";
			this.m_cboTYPE_INT.Size = new System.Drawing.Size(104, 22);
			this.m_cboTYPE_INT.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(184, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(84, 19);
			this.label4.TabIndex = 0;
			this.label4.Text = "出院病区:  ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 19);
			this.label2.TabIndex = 0;
			this.label2.Text = "出院原因: ";
			// 
			// m_txtDESC_VCHR
			// 
			this.m_txtDESC_VCHR.Location = new System.Drawing.Point(24, 106);
			this.m_txtDESC_VCHR.Multiline = true;
			this.m_txtDESC_VCHR.Name = "m_txtDESC_VCHR";
			this.m_txtDESC_VCHR.Size = new System.Drawing.Size(504, 72);
			this.m_txtDESC_VCHR.TabIndex = 3;
			this.m_txtDESC_VCHR.Text = "出院附加单据";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(360, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(84, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "出院病号:  ";
			// 
			// m_cboPSTATUS_INT
			// 
			this.m_cboPSTATUS_INT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPSTATUS_INT.Enabled = false;
			this.m_cboPSTATUS_INT.Items.AddRange(new object[] {
																  "预出院",
																  "实际出院"});
			this.m_cboPSTATUS_INT.Location = new System.Drawing.Point(72, 49);
			this.m_cboPSTATUS_INT.Name = "m_cboPSTATUS_INT";
			this.m_cboPSTATUS_INT.Size = new System.Drawing.Size(104, 22);
			this.m_cboPSTATUS_INT.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(8, 52);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(77, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "出院类型: ";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(184, 52);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(84, 19);
			this.label11.TabIndex = 0;
			this.label11.Text = "状态标志:  ";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(5, 118);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(16, 48);
			this.label14.TabIndex = 0;
			this.label14.Text = "备  注 ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 81);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 0;
			this.label3.Text = "生效人: ";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(184, 81);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(84, 19);
			this.label13.TabIndex = 0;
			this.label13.Text = "生效时间:  ";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmdCanCel);
			this.groupBox3.Controls.Add(this.cmdDel);
			this.groupBox3.Controls.Add(this.cmdBecomeEffective);
			this.groupBox3.Controls.Add(this.cmdOK);
			this.groupBox3.Location = new System.Drawing.Point(368, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(168, 88);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "操作区";
			// 
			// cmdCanCel
			// 
			this.cmdCanCel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCanCel.DefaultScheme = true;
			this.cmdCanCel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdCanCel.Hint = "";
			this.cmdCanCel.Location = new System.Drawing.Point(84, 48);
			this.cmdCanCel.Name = "cmdCanCel";
			this.cmdCanCel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCanCel.Size = new System.Drawing.Size(79, 30);
			this.cmdCanCel.TabIndex = 46;
			this.cmdCanCel.Text = "取消(Ecs)";
			this.cmdCanCel.Click += new System.EventHandler(this.cmdCanCel_Click);
			// 
			// cmdDel
			// 
			this.cmdDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdDel.DefaultScheme = true;
			this.cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdDel.Hint = "";
			this.cmdDel.Location = new System.Drawing.Point(4, 48);
			this.cmdDel.Name = "cmdDel";
			this.cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdDel.Size = new System.Drawing.Size(79, 30);
			this.cmdDel.TabIndex = 45;
			this.cmdDel.Text = "删除(F4)";
			this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
			// 
			// cmdBecomeEffective
			// 
			this.cmdBecomeEffective.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdBecomeEffective.DefaultScheme = true;
			this.cmdBecomeEffective.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdBecomeEffective.Enabled = false;
			this.cmdBecomeEffective.Hint = "";
			this.cmdBecomeEffective.Location = new System.Drawing.Point(84, 16);
			this.cmdBecomeEffective.Name = "cmdBecomeEffective";
			this.cmdBecomeEffective.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdBecomeEffective.Size = new System.Drawing.Size(79, 30);
			this.cmdBecomeEffective.TabIndex = 44;
			this.cmdBecomeEffective.Text = "生效(F3)";
			this.cmdBecomeEffective.Click += new System.EventHandler(this.cmdBecomeEffective_Click);
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdOK.DefaultScheme = true;
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdOK.Hint = "";
			this.cmdOK.Location = new System.Drawing.Point(4, 16);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdOK.Size = new System.Drawing.Size(79, 30);
			this.cmdOK.TabIndex = 43;
			this.cmdOK.Text = "保存(F2)";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// frmAOOutHospital
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(536, 285);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Name = "frmAOOutHospital";
			this.Text = "出院附加单据编辑窗口";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAOOutHospital_KeyDown);
			this.Load += new System.EventHandler(this.frmAOOutHospital_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_AOOutHospital();
			objController.Set_GUI_Apperance(this);
		}

		#region 事件
		private void frmAOOutHospital_Load(object sender, System.EventArgs e)
		{
			m_objLoginInfo = this.LoginInfo;
			((clsCtl_AOOutHospital)this.objController).m_strOperatorID =m_objLoginInfo.m_strEmpID;
			((clsCtl_AOOutHospital)this.objController).m_LoadData();
			((clsCtl_AOOutHospital)this.objController).m_Initialization();
		}

		private void frmAOOutHospital_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.None)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2://保存
					if(cmdOK.Enabled) cmdOK_Click(sender,e);
					break;
				case Keys.F3://提交
					if(cmdBecomeEffective.Enabled) cmdBecomeEffective_Click(sender,e);
					break;
				case Keys.F4://删除
					if(cmdDel.Enabled) cmdDel_Click(sender,e);
					break;
			}
		}

		private void cmdCanCel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			((clsCtl_AOOutHospital)this.objController).m_OK();
		}

		private void cmdDel_Click(object sender, System.EventArgs e)
		{
			((clsCtl_AOOutHospital)this.objController).m_Del();		
		}

		private void cmdBecomeEffective_Click(object sender, System.EventArgs e)
		{
			((clsCtl_AOOutHospital)this.objController).m_BecomeEffective();
		}
		#endregion

		#region 方法	反射用	[执行医嘱时以便附加单据自动提交] 
		/// <summary>
		/// 提交医嘱附加单据	根据医嘱ID
		/// </summary>
		/// <param name="p_strOrderID">医嘱ID</param>
		public long m_lngCommitAttachOrder(string p_strOrderID)
		{
			long lngRes =0;
			clsDcl_ExecuteOrder objTem =new clsDcl_ExecuteOrder();
			try
			{
				lngRes =objTem.m_lngCommitAttachOrder_Leave(p_strOrderID,1);
			}
			catch{}
			return lngRes;
		}
		#endregion 
	}
}
