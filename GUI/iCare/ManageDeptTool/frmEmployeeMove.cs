using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmEmployeeMove.
	/// </summary>
	public class frmEmployeeMove : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox m_txtEmployeeID;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button m_cmdClose;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button m_cmdTurnIn;
		private System.Windows.Forms.Button m_cmdClose2;
		protected System.Windows.Forms.ListView m_lsvDarkEmployees;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ListView m_lsvCurDeptEmployees;
		private System.Windows.Forms.ColumnHeader clmID;
		private System.Windows.Forms.ColumnHeader clmName;
		private System.Windows.Forms.TextBox m_txtEmployeeName;
		private System.Windows.Forms.RadioButton m_rdbChargeNurse;
		private System.Windows.Forms.RadioButton m_rdbZZ;
		private System.Windows.Forms.RadioButton m_rdbZR;
		private System.Windows.Forms.RadioButton m_rdbNurse;
		private System.Windows.Forms.RadioButton m_rdbZY;
		private System.Windows.Forms.Button m_cmdTurnOut;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmEmployeeMove()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			m_mthInit();
		}

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEmployeeMove));
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtEmployeeName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtEmployeeID = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.m_lsvDarkEmployees = new System.Windows.Forms.ListView();
			this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
			this.m_cmdClose = new System.Windows.Forms.Button();
			this.m_cmdTurnIn = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_rdbChargeNurse = new System.Windows.Forms.RadioButton();
			this.m_rdbZZ = new System.Windows.Forms.RadioButton();
			this.m_rdbZR = new System.Windows.Forms.RadioButton();
			this.m_rdbNurse = new System.Windows.Forms.RadioButton();
			this.m_rdbZY = new System.Windows.Forms.RadioButton();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.m_lsvCurDeptEmployees = new System.Windows.Forms.ListView();
			this.clmID = new System.Windows.Forms.ColumnHeader();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.m_cmdClose2 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.m_cmdTurnOut = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label2.Font = new System.Drawing.Font("SimSun", 12F);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(216, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "员工姓名:";
			// 
			// m_txtEmployeeName
			// 
			this.m_txtEmployeeName.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtEmployeeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtEmployeeName.Font = new System.Drawing.Font("SimSun", 12F);
			this.m_txtEmployeeName.ForeColor = System.Drawing.Color.White;
			this.m_txtEmployeeName.Location = new System.Drawing.Point(304, 16);
			this.m_txtEmployeeName.Name = "m_txtEmployeeName";
			this.m_txtEmployeeName.TabIndex = 112;
			this.m_txtEmployeeName.Text = "";
			this.m_txtEmployeeName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtEmployeeName_KeyDown);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label1.Font = new System.Drawing.Font("SimSun", 12F);
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "员工ID:";
			// 
			// m_txtEmployeeID
			// 
			this.m_txtEmployeeID.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtEmployeeID.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_txtEmployeeID.Font = new System.Drawing.Font("SimSun", 12F);
			this.m_txtEmployeeID.ForeColor = System.Drawing.Color.White;
			this.m_txtEmployeeID.Location = new System.Drawing.Point(104, 16);
			this.m_txtEmployeeID.Name = "m_txtEmployeeID";
			this.m_txtEmployeeID.TabIndex = 111;
			this.m_txtEmployeeID.Text = "";
			this.m_txtEmployeeID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtEmployeeName_KeyDown);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(432, 341);
			this.tabControl1.TabIndex = 113;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.m_lsvDarkEmployees,
																				   this.m_cmdClose,
																				   this.m_cmdTurnIn,
																				   this.groupBox1,
																				   this.m_txtEmployeeName,
																				   this.label2,
																				   this.m_txtEmployeeID,
																				   this.label1});
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(424, 312);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "转入";
			// 
			// m_lsvDarkEmployees
			// 
			this.m_lsvDarkEmployees.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvDarkEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvDarkEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.columnHeader17,
																								 this.columnHeader18});
			this.m_lsvDarkEmployees.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvDarkEmployees.ForeColor = System.Drawing.Color.White;
			this.m_lsvDarkEmployees.FullRowSelect = true;
			this.m_lsvDarkEmployees.GridLines = true;
			this.m_lsvDarkEmployees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvDarkEmployees.Location = new System.Drawing.Point(304, 40);
			this.m_lsvDarkEmployees.MultiSelect = false;
			this.m_lsvDarkEmployees.Name = "m_lsvDarkEmployees";
			this.m_lsvDarkEmployees.Size = new System.Drawing.Size(102, 104);
			this.m_lsvDarkEmployees.TabIndex = 6092;
			this.m_lsvDarkEmployees.View = System.Windows.Forms.View.Details;
			this.m_lsvDarkEmployees.Visible = false;
			this.m_lsvDarkEmployees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvDarkEmployees_KeyDown);
			this.m_lsvDarkEmployees.DoubleClick += new System.EventHandler(this.m_lsvDarkEmployees_DoubleClick);
			// 
			// columnHeader17
			// 
			this.columnHeader17.Width = 0;
			// 
			// columnHeader18
			// 
			this.columnHeader18.Width = 102;
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdClose.ForeColor = System.Drawing.Color.White;
			this.m_cmdClose.Location = new System.Drawing.Point(344, 224);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Size = new System.Drawing.Size(64, 32);
			this.m_cmdClose.TabIndex = 502;
			this.m_cmdClose.Text = "关闭";
			this.m_cmdClose.Click += new System.EventHandler(this.m_mthClose);
			// 
			// m_cmdTurnIn
			// 
			this.m_cmdTurnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTurnIn.ForeColor = System.Drawing.Color.White;
			this.m_cmdTurnIn.Location = new System.Drawing.Point(248, 224);
			this.m_cmdTurnIn.Name = "m_cmdTurnIn";
			this.m_cmdTurnIn.Size = new System.Drawing.Size(64, 32);
			this.m_cmdTurnIn.TabIndex = 501;
			this.m_cmdTurnIn.Text = "确定";
			this.m_cmdTurnIn.Click += new System.EventHandler(this.m_cmdTurnIn_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_rdbChargeNurse,
																					this.m_rdbZZ,
																					this.m_rdbZR,
																					this.m_rdbNurse,
																					this.m_rdbZY});
			this.groupBox1.Location = new System.Drawing.Point(16, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(192, 208);
			this.groupBox1.TabIndex = 113;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "权限";
			// 
			// m_rdbChargeNurse
			// 
			this.m_rdbChargeNurse.Location = new System.Drawing.Point(24, 160);
			this.m_rdbChargeNurse.Name = "m_rdbChargeNurse";
			this.m_rdbChargeNurse.TabIndex = 10;
			this.m_rdbChargeNurse.Tag = "1";
			this.m_rdbChargeNurse.Text = "护士长";
			this.m_rdbChargeNurse.CheckedChanged += new System.EventHandler(this.m_rdbZY_CheckedChanged);
			// 
			// m_rdbZZ
			// 
			this.m_rdbZZ.Location = new System.Drawing.Point(24, 64);
			this.m_rdbZZ.Name = "m_rdbZZ";
			this.m_rdbZZ.TabIndex = 9;
			this.m_rdbZZ.Tag = "0";
			this.m_rdbZZ.Text = "主治医师";
			this.m_rdbZZ.CheckedChanged += new System.EventHandler(this.m_rdbZY_CheckedChanged);
			// 
			// m_rdbZR
			// 
			this.m_rdbZR.Location = new System.Drawing.Point(24, 96);
			this.m_rdbZR.Name = "m_rdbZR";
			this.m_rdbZR.TabIndex = 8;
			this.m_rdbZR.Tag = "0";
			this.m_rdbZR.Text = "主任医师";
			this.m_rdbZR.CheckedChanged += new System.EventHandler(this.m_rdbZY_CheckedChanged);
			// 
			// m_rdbNurse
			// 
			this.m_rdbNurse.Location = new System.Drawing.Point(24, 128);
			this.m_rdbNurse.Name = "m_rdbNurse";
			this.m_rdbNurse.TabIndex = 6;
			this.m_rdbNurse.Tag = "1";
			this.m_rdbNurse.Text = "护士";
			this.m_rdbNurse.CheckedChanged += new System.EventHandler(this.m_rdbZY_CheckedChanged);
			// 
			// m_rdbZY
			// 
			this.m_rdbZY.Location = new System.Drawing.Point(24, 32);
			this.m_rdbZY.Name = "m_rdbZY";
			this.m_rdbZY.TabIndex = 5;
			this.m_rdbZY.Tag = "0";
			this.m_rdbZY.Text = "住院医师";
			this.m_rdbZY.CheckedChanged += new System.EventHandler(this.m_rdbZY_CheckedChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.m_cmdTurnOut,
																				   this.m_lsvCurDeptEmployees,
																				   this.m_cmdClose2,
																				   this.label3});
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(424, 312);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "转出";
			// 
			// m_lsvCurDeptEmployees
			// 
			this.m_lsvCurDeptEmployees.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvCurDeptEmployees.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvCurDeptEmployees.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																									this.clmID,
																									this.clmName});
			this.m_lsvCurDeptEmployees.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvCurDeptEmployees.ForeColor = System.Drawing.Color.White;
			this.m_lsvCurDeptEmployees.FullRowSelect = true;
			this.m_lsvCurDeptEmployees.GridLines = true;
			this.m_lsvCurDeptEmployees.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvCurDeptEmployees.HideSelection = false;
			this.m_lsvCurDeptEmployees.Location = new System.Drawing.Point(24, 48);
			this.m_lsvCurDeptEmployees.MultiSelect = false;
			this.m_lsvCurDeptEmployees.Name = "m_lsvCurDeptEmployees";
			this.m_lsvCurDeptEmployees.Size = new System.Drawing.Size(200, 240);
			this.m_lsvCurDeptEmployees.TabIndex = 505;
			this.m_lsvCurDeptEmployees.View = System.Windows.Forms.View.Details;
			// 
			// clmID
			// 
			this.clmID.Text = "员工ID";
			this.clmID.Width = 0;
			// 
			// clmName
			// 
			this.clmName.Text = "员工姓名";
			this.clmName.Width = 200;
			// 
			// m_cmdClose2
			// 
			this.m_cmdClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdClose2.ForeColor = System.Drawing.Color.White;
			this.m_cmdClose2.Location = new System.Drawing.Point(344, 256);
			this.m_cmdClose2.Name = "m_cmdClose2";
			this.m_cmdClose2.Size = new System.Drawing.Size(64, 32);
			this.m_cmdClose2.TabIndex = 504;
			this.m_cmdClose2.Text = "关闭";
			this.m_cmdClose2.Click += new System.EventHandler(this.m_mthClose);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.label3.Font = new System.Drawing.Font("SimSun", 12F);
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(278, 19);
			this.label3.TabIndex = 1;
			this.label3.Text = "请选择要转出的员工，点击转出即可:";
			// 
			// m_cmdTurnOut
			// 
			this.m_cmdTurnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdTurnOut.ForeColor = System.Drawing.Color.White;
			this.m_cmdTurnOut.Location = new System.Drawing.Point(256, 256);
			this.m_cmdTurnOut.Name = "m_cmdTurnOut";
			this.m_cmdTurnOut.Size = new System.Drawing.Size(64, 32);
			this.m_cmdTurnOut.TabIndex = 506;
			this.m_cmdTurnOut.Text = "转出";
			this.m_cmdTurnOut.Click += new System.EventHandler(this.m_cmdTurnOut_Click);
			// 
			// frmEmployeeMove
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(432, 341);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmEmployeeMove";
			this.Text = "员工转入转出";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 初始化
		/// </summary>
		private void m_mthInit()
		{
			new ctlHighLightFocus(clsHRPColor.s_ClrHightLight).m_mthAddControlInContainer(this);
			new clsBorderTool(Color.White).m_mthChangedControlsArrayBorder(new Control[]{m_txtEmployeeID,m_txtEmployeeName,m_lsvCurDeptEmployees });

			m_rdbZY.Checked = true;

			m_lsvDarkEmployees.LostFocus += new EventHandler(m_lsvDarkEmployees_LostFocus);
			
			m_mthLoadCurDeptEmployees();
		}

		private void m_lsvDarkEmployees_LostFocus(object sender,EventArgs e)
		{
			m_lsvDarkEmployees.Visible = false;
		}

		/// <summary>
		/// 查找当前科室下所有员工
		/// </summary>
		private void m_mthLoadCurDeptEmployees()
		{
			clsEmployee[] objEmpArr ;
			objEmpArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeByDeptID(clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID);	
			if(objEmpArr !=null)
			{
				for(int i=0;i<objEmpArr.Length;i++)
				{
					ListViewItem lviNewItem;
					lviNewItem = new ListViewItem(new string[]{objEmpArr[i].m_StrEmployeeID,objEmpArr[i].m_StrFirstName});
						
					lviNewItem.Tag = objEmpArr[i];
					m_lsvCurDeptEmployees.Items.Add(lviNewItem);
				}
				clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvCurDeptEmployees,11);
			}
		}

		/// <summary>
		/// 模糊查询员工
		/// </summary>
		private void m_mthLoadDarkEmployees(TextBox p_txtInput)
		{
			clsEmployee[] objArr=new clsEmployeeManager().m_objGetAllEmployeeIDLikeArr(p_txtInput.Text.Trim(),null);
			if(objArr==null) 
			{
				return;
			}
			m_lsvDarkEmployees.Items.Clear();
			for(int i=0;i<objArr.Length;i++)
			{
				ListViewItem objItem=new ListViewItem(new string[]{objArr[i].m_StrEmployeeID,objArr[i].m_StrFirstName.Trim()});
				objItem.Tag=objArr[i];
				m_lsvDarkEmployees.Items.Add(objItem);
			}
			clsPublicFunction.s_mthChangeListViewLastColumnWidth(m_lsvDarkEmployees);
		}

		/// <summary>
		/// 对员工ListView进行排序
		/// </summary>
		/// <param name="p_lsvInput"></param>
		/// <param name="p_intColumn"></param>
		private void m_mthListViewSorting(ListView p_lsvInput,int p_intColumn)
		{
			clsListViewColumnSorter objSort = new clsListViewColumnSorter(true);
			objSort.m_IntColumn = p_intColumn;
			p_lsvInput.ListViewItemSorter = objSort;
			p_lsvInput.Sort();
		}

		private void m_txtEmployeeName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				TextBox txtEmployee = (TextBox)sender;
				m_mthLoadDarkEmployees(txtEmployee);
				if(m_lsvDarkEmployees.Items.Count>0)
				{
					m_mthListViewSorting(m_lsvDarkEmployees,(txtEmployee.Name=="m_txtEmployeeID") ? 0 : 1);
					m_lsvDarkEmployees.Visible = true;
					m_lsvDarkEmployees.BringToFront();
					m_lsvDarkEmployees.Items[0].Selected = true;
					m_lsvDarkEmployees.Focus();
					m_lsvDarkEmployees.Left = txtEmployee.Left;
					m_lsvDarkEmployees.Top = txtEmployee.Bottom;
				}
			}			
		}

		private void m_lsvDarkEmployees_DoubleClick(object sender, System.EventArgs e)
		{
			if(((ListView)sender).SelectedItems.Count==0) return;

			m_txtEmployeeID.Text=((ListView)sender).SelectedItems[0].SubItems[0].Text.Trim();
			m_txtEmployeeName.Text=((ListView)sender).SelectedItems[0].SubItems[1].Text.Trim();
			m_lsvDarkEmployees.Visible = false;
			m_txtEmployeeID.Focus();

		}

		private void m_lsvDarkEmployees_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
				m_lsvDarkEmployees_DoubleClick(m_lsvDarkEmployees,KeyEventArgs.Empty);
		}

		/// <summary>
		/// 员工输入是否有效
		/// </summary>
		/// <returns></returns>
		private bool m_blnDeptEmployeeInputValid()
		{
			m_txtEmployeeID.Text=m_txtEmployeeID.Text.Trim();
			m_txtEmployeeName.Text=m_txtEmployeeName.Text.Trim();
			if(m_txtEmployeeID.Text==null ||m_txtEmployeeID.Text=="")
			{
				clsPublicFunction.ShowInformationMessageBox("员工ID不能为空。");
				return false;
			}
			if(m_objHandlerDomain.m_lngCheckID_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,m_txtEmployeeID.Text)!=(long)enmOperationResult.Record_Already_Exist)
			{
				clsPublicFunction.ShowInformationMessageBox("员工不存在，无法调入。");
				return false;
			}
			clsEmployee objTempEmployee=new clsEmployee(m_txtEmployeeID.Text);
			if(objTempEmployee.m_StrStatus=="True" || objTempEmployee.m_StrStatus=="1")
			{
				clsPublicFunction.ShowInformationMessageBox("员工已不是医院职工，无法调入。");
				return false;
			}
			clsEmployee_BaseInfo[] objEmployeeArr=null;
			if(m_objManagerDomain.m_lngGetEmployeeArrInDept(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,out objEmployeeArr)<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法连接数据库。");
				return false;
			}
			if(objEmployeeArr==null) return true;
			for(int i=0;i<objEmployeeArr.Length;i++)
			{
				if(m_txtEmployeeID.Text.Trim()==objEmployeeArr[i].m_strEmployeeID.Trim())
				{
					clsPublicFunction.ShowInformationMessageBox("员工已在本科室任职，无法重复调入。");
					return false;
				}
			}

			return true;
		}

		/// <summary>
		/// 科室调入员工
		/// </summary>
		private void m_mthDeptAddEmployee()
		{
			if(!m_blnDeptEmployeeInputValid()) return;
			if(m_lngDeptAddEmployeeSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("转入失败。");
				return;
			}
		}

		clsDepartmentManager m_objManagerDomain=new clsDepartmentManager();
		clsDepartmentHandlerDomain m_objHandlerDomain=new clsDepartmentHandlerDomain();

		private long m_lngDeptAddEmployeeSub()
		{
			clsDept_Employee objDept=new clsDept_Employee();
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_dtmEndDate=DateTime.Parse("1900-1-1- 00:00:00");
			
			objDept.m_strDeptID=clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			objDept.m_strEmployeeID=m_txtEmployeeID.Text;
			
			long lngRes=1;
			lngRes=m_objHandlerDomain.m_lngAssignDept_Employee2(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,objDept,m_strRoleName);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法调入员工。");
				return lngRes;
			}

			#region 添加员工常用值
			clsDocAndNur obj = new clsDocAndNur();
			obj.m_intFlag = m_intFlag;
			obj.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			obj.m_strEmployeeID = m_txtEmployeeID.Text.Trim();
			obj.m_strEmployeeName = m_txtEmployeeName.Text.Trim();
			m_mthAddOrRemoveCommonEmployeesInDept(true,obj);
			#endregion

			return 1;
		}

		/// <summary>
		/// 添加或删除员工常用值
		/// </summary>
		private void m_mthAddOrRemoveCommonEmployeesInDept(bool p_blnAddOrRemove,clsDocAndNur p_objValue)
		{
			bool[] blnArr = new bool[1]{p_blnAddOrRemove};
			clsDocAndNur[] objArr = new clsDocAndNur[1];
			objArr[0] = p_objValue;
			long lngRes = new clsManageDocAndNurDomain().m_lngSave(blnArr,objArr);
			if(lngRes < 0)
				clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strSaveFail);
		}

		private string m_strRoleName = "";
		private int m_intFlag;
		private void m_rdbZY_CheckedChanged(object sender, System.EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			m_strRoleName = rb.Text;
			m_intFlag = Convert.ToInt32(rb.Tag);
		}

		private void m_cmdTurnIn_Click(object sender, System.EventArgs e)
		{
			m_mthDeptAddEmployee();

			m_mthClose(null,EventArgs.Empty);
		}

		/// <summary>
		/// 关闭窗体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthClose(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cmdTurnOut_Click(object sender, System.EventArgs e)
		{
			m_mthTurnOutEmployee();
		}

		/// <summary>
		/// 员工转出
		/// </summary>
		private void m_mthTurnOutEmployee()
		{
			if(m_lsvCurDeptEmployees.SelectedItems.Count<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择员工");
				return;
			}

			if(m_lngEmployeeDeleteDeptSub()<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法删除");
				return;
			}

			#region 删除员工常用值
			clsDocAndNur obj = new clsDocAndNur();
			obj.m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			obj.m_strEmployeeID = m_lsvCurDeptEmployees.SelectedItems[0].SubItems[0].Text;
			obj.m_strEmployeeName = m_lsvCurDeptEmployees.SelectedItems[0].SubItems[1].Text;
			m_mthAddOrRemoveCommonEmployeesInDept(false,obj);
			#endregion

			m_lsvCurDeptEmployees.SelectedItems[0].Remove();
		}

		private long m_lngEmployeeDeleteDeptSub()
		{
			clsDept_Employee objDept=new clsDept_Employee();
			objDept.m_dtmEndDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			objDept.m_strDeptID=clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
			objDept.m_strEmployeeID=m_lsvCurDeptEmployees.SelectedItems[0].SubItems[0].Text;
			return m_objHandlerDomain.m_lngDeleteDept_Employee(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,objDept);		
		}

	}
}
