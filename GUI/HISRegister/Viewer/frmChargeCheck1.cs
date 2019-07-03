using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmChargeCheck1 的摘要说明。
	/// </summary>
	public class frmChargeCheck1 : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal com.digitalwave.controls.ctlDataGridView DgChargeCheck;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel2;
		internal PinkieControls.ButtonXP m_btnQulReg;
		private System.Windows.Forms.Label label11;
		internal System.Windows.Forms.DateTimePicker m_datFirstdate;
		internal System.Windows.Forms.DateTimePicker m_datLastdate;
		private System.Windows.Forms.Label label13;
		internal PinkieControls.ButtonXP btnESC;
		internal PinkieControls.ButtonXP btnOther;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ComboBox PatienType;
		private System.Drawing.Printing.PrintDocument printDocument1;
		internal PinkieControls.ButtonXP buttonXP1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChargeCheck1()
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.DgChargeCheck = new com.digitalwave.controls.ctlDataGridView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnESC = new PinkieControls.ButtonXP();
			this.btnOther = new PinkieControls.ButtonXP();
			this.panel2 = new System.Windows.Forms.Panel();
			this.PatienType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_btnQulReg = new PinkieControls.ButtonXP();
			this.label11 = new System.Windows.Forms.Label();
			this.m_datFirstdate = new System.Windows.Forms.DateTimePicker();
			this.m_datLastdate = new System.Windows.Forms.DateTimePicker();
			this.label13 = new System.Windows.Forms.Label();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DgChargeCheck)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.DgChargeCheck);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(936, 352);
			this.panel1.TabIndex = 2;
			// 
			// DgChargeCheck
			// 
			this.DgChargeCheck.CaptionVisible = false;
			this.DgChargeCheck.DataMember = "";
			this.DgChargeCheck.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DgChargeCheck.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.DgChargeCheck.Location = new System.Drawing.Point(0, 0);
			this.DgChargeCheck.m_clrBack = System.Drawing.Color.White;
			this.DgChargeCheck.m_clrBackB = System.Drawing.Color.WhiteSmoke;
			this.DgChargeCheck.m_clrFore = System.Drawing.Color.Black;
			this.DgChargeCheck.m_clrForeB = System.Drawing.Color.Black;
			this.DgChargeCheck.Name = "DgChargeCheck";
			this.DgChargeCheck.ReadOnly = true;
			this.DgChargeCheck.Size = new System.Drawing.Size(932, 348);
			this.DgChargeCheck.TabIndex = 71;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.buttonXP1);
			this.groupBox1.Controls.Add(this.btnESC);
			this.groupBox1.Controls.Add(this.btnOther);
			this.groupBox1.Location = new System.Drawing.Point(0, 416);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(936, 64);
			this.groupBox1.TabIndex = 56;
			this.groupBox1.TabStop = false;
			// 
			// btnESC
			// 
			this.btnESC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnESC.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnESC.DefaultScheme = true;
			this.btnESC.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnESC.Hint = "";
			this.btnESC.Location = new System.Drawing.Point(152, 15);
			this.btnESC.Name = "btnESC";
			this.btnESC.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnESC.Size = new System.Drawing.Size(128, 41);
			this.btnESC.TabIndex = 54;
			this.btnESC.Text = "退出查询（ESC）";
			// 
			// btnOther
			// 
			this.btnOther.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnOther.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnOther.DefaultScheme = true;
			this.btnOther.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnOther.Hint = "";
			this.btnOther.Location = new System.Drawing.Point(704, 15);
			this.btnOther.Name = "btnOther";
			this.btnOther.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnOther.Size = new System.Drawing.Size(132, 41);
			this.btnOther.TabIndex = 53;
			this.btnOther.Text = "打印发票（&P）";
			this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.PatienType);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.m_btnQulReg);
			this.panel2.Controls.Add(this.label11);
			this.panel2.Controls.Add(this.m_datFirstdate);
			this.panel2.Controls.Add(this.m_datLastdate);
			this.panel2.Controls.Add(this.label13);
			this.panel2.Location = new System.Drawing.Point(0, 360);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(936, 48);
			this.panel2.TabIndex = 2;
			// 
			// PatienType
			// 
			this.PatienType.Items.AddRange(new object[] {
															"全部",
															"自费",
															"医保",
															"公费",
															"其它"});
			this.PatienType.Location = new System.Drawing.Point(816, 11);
			this.PatienType.Name = "PatienType";
			this.PatienType.Size = new System.Drawing.Size(96, 22);
			this.PatienType.TabIndex = 49;
			this.PatienType.SelectedIndexChanged += new System.EventHandler(this.PatienType_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(736, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 48;
			this.label1.Text = "病人类型";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_btnQulReg
			// 
			this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnQulReg.DefaultScheme = true;
			this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnQulReg.Hint = "";
			this.m_btnQulReg.Location = new System.Drawing.Point(616, 6);
			this.m_btnQulReg.Name = "m_btnQulReg";
			this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnQulReg.Size = new System.Drawing.Size(104, 32);
			this.m_btnQulReg.TabIndex = 45;
			this.m_btnQulReg.Text = "查询(&F)";
			this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
			// 
			// label11
			// 
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(120, 11);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 23);
			this.label11.TabIndex = 46;
			this.label11.Text = "开始日期";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_datFirstdate
			// 
			this.m_datFirstdate.Location = new System.Drawing.Point(216, 11);
			this.m_datFirstdate.Name = "m_datFirstdate";
			this.m_datFirstdate.Size = new System.Drawing.Size(128, 23);
			this.m_datFirstdate.TabIndex = 43;
			// 
			// m_datLastdate
			// 
			this.m_datLastdate.Location = new System.Drawing.Point(472, 11);
			this.m_datLastdate.Name = "m_datLastdate";
			this.m_datLastdate.Size = new System.Drawing.Size(128, 23);
			this.m_datLastdate.TabIndex = 44;
			// 
			// label13
			// 
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(368, 11);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(64, 23);
			this.label13.TabIndex = 47;
			this.label13.Text = "截止日期";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// buttonXP1
			// 
			this.buttonXP1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(426, 16);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(132, 41);
			this.buttonXP1.TabIndex = 56;
			this.buttonXP1.Text = "生成处方文件（&S）";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// frmChargeCheck1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(936, 485);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmChargeCheck1";
			this.Text = "发票查询";
			this.Load += new System.EventHandler(this.frmChargeCheck1_Load);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DgChargeCheck)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlChargeCheck1();
			objController.Set_GUI_Apperance(this);
		}
		private void frmChargeCheck1_Load(object sender, System.EventArgs e)
		{
			((clsControlChargeCheck1)this.objController).m_frmLoad();
			PatienType.SelectedIndex=0;
		
		}

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			((clsControlChargeCheck1)this.objController).m_frmLoad();
		}

		private void PatienType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsControlChargeCheck1)this.objController).m_mthFindData();
		}

		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
		
		}

		private void btnOther_Click(object sender, System.EventArgs e)
		{
			((clsControlChargeCheck1)this.objController).m_mthPrintReport();
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			clsCreatFile creatFile=new clsCreatFile(((clsControlChargeCheck1)this.objController).m_mthGetAll());
			creatFile.m_mthCreatFile();
		}
	}
}
