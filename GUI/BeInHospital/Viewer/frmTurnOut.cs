using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 转出——界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-21
	/// </summary>
	public class frmTurnOut : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件-变量申明
        /// <summary>
        /// 科室ID
        /// </summary>
        internal string m_strDeptID;
        /// <summary>
        /// 病区ID
        /// </summary>
        internal string m_strAreaID;
        /// <summary>
        /// 病人信息
        /// </summary>
        internal clsBedManageVO m_objBedManage;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.TextBox m_txtDES;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP cmdCancel;
		private PinkieControls.ButtonXP cmdTurnOut;
        internal string m_strOpertorID;
        private System.Windows.Forms.Label label5;
		#endregion 

        internal TextBox m_txtInPatientID;
        private Label label6;
        internal TextBox m_txtBedCode;
        internal TextBox m_txtArea;
        internal TextBox m_txtName;
        private Label label58;
        internal ComboBox m_cobPrint;
        private GroupBox groupBox1;
        internal ControlLibrary.txtListView m_txtListArea;
        private IContainer components;

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号</param>
		/// <param name="p_strDeptID">部门科室ID号</param>
		/// <param name="p_strAreaID">病区ID</param>
		/// <param name="p_strBedID">病床流水号</param>
		public frmTurnOut(clsBedManageVO p_objBedManage,string p_strDepartID ,string p_strAreaID, string p_strAreaName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            m_strAreaID = p_strAreaID;
            m_strDeptID = p_strDepartID;
            m_txtArea.Text = p_strAreaName;
            m_objBedManage = p_objBedManage;
            m_txtName.Text = m_objBedManage.m_strNAME_VCHR;
            m_txtInPatientID.Text = m_objBedManage.m_strINPATIENTID_CHR;
            m_txtBedCode.Text = m_objBedManage.m_strCODE_CHR;
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
            this.components = new System.ComponentModel.Container();
            this.label10 = new System.Windows.Forms.Label();
            this.m_txtDES = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdTurnOut = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.label58 = new System.Windows.Forms.Label();
            this.m_cobPrint = new System.Windows.Forms.ComboBox();
            this.m_txtBedCode = new System.Windows.Forms.TextBox();
            this.m_txtArea = new System.Windows.Forms.TextBox();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_txtInPatientID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtListArea = new ControlLibrary.txtListView(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(28, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 14);
            this.label10.TabIndex = 10;
            this.label10.Text = "转入病区:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtDES
            // 
            this.m_txtDES.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDES.Location = new System.Drawing.Point(98, 195);
            this.m_txtDES.MaxLength = 9;
            this.m_txtDES.Multiline = true;
            this.m_txtDES.Name = "m_txtDES";
            this.m_txtDES.Size = new System.Drawing.Size(210, 45);
            this.m_txtDES.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(28, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 9;
            this.label4.Text = "转出病区:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(28, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "住 院 号:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "姓　　名:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdTurnOut
            // 
            this.cmdTurnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdTurnOut.DefaultScheme = true;
            this.cmdTurnOut.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdTurnOut.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdTurnOut.Hint = "";
            this.cmdTurnOut.Location = new System.Drawing.Point(110, 300);
            this.cmdTurnOut.Name = "cmdTurnOut";
            this.cmdTurnOut.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdTurnOut.Size = new System.Drawing.Size(78, 27);
            this.cmdTurnOut.TabIndex = 1;
            this.cmdTurnOut.Text = "确定(F2)";
            this.cmdTurnOut.Click += new System.EventHandler(this.cmdTurnOut_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(210, 300);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(78, 27);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "取消(Esc)";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(28, 259);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(70, 14);
            this.label58.TabIndex = 130;
            this.label58.Text = "打印选项:";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cobPrint
            // 
            this.m_cobPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cobPrint.Items.AddRange(new object[] {
            " 打印转区通知单",
            " 不打印"});
            this.m_cobPrint.Location = new System.Drawing.Point(98, 255);
            this.m_cobPrint.Name = "m_cobPrint";
            this.m_cobPrint.Size = new System.Drawing.Size(210, 22);
            this.m_cobPrint.TabIndex = 6;
            this.m_cobPrint.TabStop = false;
            // 
            // m_txtBedCode
            // 
            this.m_txtBedCode.Location = new System.Drawing.Point(98, 90);
            this.m_txtBedCode.Name = "m_txtBedCode";
            this.m_txtBedCode.ReadOnly = true;
            this.m_txtBedCode.Size = new System.Drawing.Size(210, 23);
            this.m_txtBedCode.TabIndex = 2;
            this.m_txtBedCode.TabStop = false;
            // 
            // m_txtArea
            // 
            this.m_txtArea.Location = new System.Drawing.Point(98, 124);
            this.m_txtArea.Name = "m_txtArea";
            this.m_txtArea.ReadOnly = true;
            this.m_txtArea.Size = new System.Drawing.Size(210, 23);
            this.m_txtArea.TabIndex = 0;
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(98, 56);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.ReadOnly = true;
            this.m_txtName.Size = new System.Drawing.Size(210, 23);
            this.m_txtName.TabIndex = 1;
            this.m_txtName.TabStop = false;
            // 
            // m_txtInPatientID
            // 
            this.m_txtInPatientID.Location = new System.Drawing.Point(98, 22);
            this.m_txtInPatientID.Name = "m_txtInPatientID";
            this.m_txtInPatientID.ReadOnly = true;
            this.m_txtInPatientID.Size = new System.Drawing.Size(210, 23);
            this.m_txtInPatientID.TabIndex = 0;
            this.m_txtInPatientID.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(28, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "床    位:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(28, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "备　　注:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtListArea);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label58);
            this.groupBox1.Controls.Add(this.m_txtDES);
            this.groupBox1.Controls.Add(this.m_cobPrint);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.m_txtBedCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.m_txtArea);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.m_txtInPatientID);
            this.groupBox1.Controls.Add(this.m_txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // m_txtListArea
            // 
            this.m_txtListArea.findDataMode = ControlLibrary.txtListView.findMode.fromDataSouse;
            this.m_txtListArea.Location = new System.Drawing.Point(98, 158);
            this.m_txtListArea.m_blnFocuseShow = true;
            this.m_txtListArea.m_blnPagination = false;
            this.m_txtListArea.m_dtbDataSourse = null;
            this.m_txtListArea.m_intDelayTime = 100;
            this.m_txtListArea.m_intPageRows = 10;
            this.m_txtListArea.m_ListViewAlign = ControlLibrary.txtListView.ListViewAlign.LeftBottom;
            this.m_txtListArea.m_listViewSize = new System.Drawing.Point(260, 100);
            this.m_txtListArea.m_strFieldsArr = new string[] {
        "code_vchr",
        "pycode_chr",
        "deptname_vchr"};
            this.m_txtListArea.m_strSaveField = "deptid_chr";
            this.m_txtListArea.m_strShowField = "deptname_vchr";
            this.m_txtListArea.m_strSQL = null;
            this.m_txtListArea.Name = "m_txtListArea";
            this.m_txtListArea.Size = new System.Drawing.Size(210, 23);
            this.m_txtListArea.TabIndex = 3;
            // 
            // frmTurnOut
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(354, 335);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdTurnOut);
            this.Controls.Add(this.cmdCancel);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmTurnOut";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转病区";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTurnOut_KeyDown);
            this.Load += new System.EventHandler(this.frmTurnOut_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region	设置窗体控制器
		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_TurnOut();
			objController.Set_GUI_Apperance(this);
		}
		#endregion

		#region 事件
		private void frmTurnOut_Load(object sender, System.EventArgs e)
		{
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtListArea });
			((clsCtl_TurnOut)this.objController).m_mthInit();
		}
		private void cmdTurnOut_Click(object sender, System.EventArgs e)
		{
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_TurnOut)this.objController).m_cmdTurnOut();
			this.Cursor =Cursors.Default;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmTurnOut_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2:
					cmdTurnOut_Click(sender,e);	
					break;
			}
		}
		#endregion 	


	}
}
