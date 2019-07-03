using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility;
using com.digitalwave.emr.HospitalManagerService;
using com.digitalwave.iCare.common;
using System.Data;
using iCareData;

namespace iCare.DoctorWorkStation
{
	/// <summary>
	/// 选择病人
	/// </summary>
	public class frmChoosePatient : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 域成员
			
		protected System.Windows.Forms.Label lblAreaTitle;
		protected System.Windows.Forms.Label lblDeptTitle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button button3;
		protected com.digitalwave.controls.ctlComboBox m_cboDept;
		private com.digitalwave.controls.ctlComboBox m_cboArea;
		private System.ComponentModel.Container components = null;
		#endregion

		#region 变量

		/// 当前科室 静态
		/// </summary>
		public static clsEmrDept_VO objpCurrentDepartment ;          
		/// <summary>
		/// 当前病区 静态
		/// </summary>
		public static clsEmrDept_VO objpCurrentArea;                 
		/// <summary>
		/// 当前病人 静态
		/// </summary>
		public static clsEmrInBedPatient_VO objpCurrentPatient;      

		/// 员工ID，非工号
		/// </summary>
		protected string strGEmployeeID;
        private Panel m_pnlOutDate;
        private Label label3;
        private Label label2;
        private DateTimePicker m_dtpOutPatientEnd;
        private DateTimePicker m_dtpOutPatientStart;
        private RadioButton m_rdbOutPatient;
        private RadioButton m_rdbInPatient;


		clsChoosePatientDomain m_objChoosePatientDomain;
        /// <summary>
        /// 病案归档期限
        /// </summary>
        private int m_intArchivingDeadline = 7;
        /// <summary>
        /// 查阅归档病案是否需要申请
        /// </summary>
        private bool m_blnIsWantRequest = true;
        private Button m_cmdSearchOut;
        /// <summary>
        /// 是否拥有病案室权限
        /// </summary>
        private bool m_blnHasCaseAdminRole = false;

		#endregion
		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		

		public frmChoosePatient()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			strGEmployeeID=LoginInfo.m_strEmpID;
			m_objChoosePatientDomain=new clsChoosePatientDomain();
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
            m_intArchivingDeadline = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3010");
            m_blnIsWantRequest = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3011") == 1 ? true : false;
            
            if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr != null)
            {
                foreach (string strRole in com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleNameArr)
                {
                    if (strRole == "病案室")
                    {
                        m_blnHasCaseAdminRole = true;
                    }
                }
            }
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// 

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChoosePatient));
            this.lblAreaTitle = new System.Windows.Forms.Label();
            this.lblDeptTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cboDept = new com.digitalwave.controls.ctlComboBox();
            this.m_cboArea = new com.digitalwave.controls.ctlComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_rdbInPatient = new System.Windows.Forms.RadioButton();
            this.m_rdbOutPatient = new System.Windows.Forms.RadioButton();
            this.m_dtpOutPatientStart = new System.Windows.Forms.DateTimePicker();
            this.m_dtpOutPatientEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_pnlOutDate = new System.Windows.Forms.Panel();
            this.m_cmdSearchOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_pnlOutDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.AutoSize = true;
            this.lblAreaTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAreaTitle.Location = new System.Drawing.Point(307, 19);
            this.lblAreaTitle.Name = "lblAreaTitle";
            this.lblAreaTitle.Size = new System.Drawing.Size(42, 14);
            this.lblAreaTitle.TabIndex = 496;
            this.lblAreaTitle.Text = "病区:";
            // 
            // lblDeptTitle
            // 
            this.lblDeptTitle.AutoSize = true;
            this.lblDeptTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeptTitle.ForeColor = System.Drawing.Color.Black;
            this.lblDeptTitle.Location = new System.Drawing.Point(19, 19);
            this.lblDeptTitle.Name = "lblDeptTitle";
            this.lblDeptTitle.Size = new System.Drawing.Size(70, 14);
            this.lblDeptTitle.TabIndex = 497;
            this.lblDeptTitle.Text = "科    室:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_pnlOutDate);
            this.panel1.Controls.Add(this.m_rdbOutPatient);
            this.panel1.Controls.Add(this.m_rdbInPatient);
            this.panel1.Controls.Add(this.m_cboDept);
            this.panel1.Controls.Add(this.m_cboArea);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblAreaTitle);
            this.panel1.Controls.Add(this.lblDeptTitle);
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 149);
            this.panel1.TabIndex = 498;
            // 
            // m_cboDept
            // 
            this.m_cboDept.BorderColor = System.Drawing.Color.Black;
            this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.ListBackColor = System.Drawing.Color.White;
            this.m_cboDept.ListForeColor = System.Drawing.Color.Black;
            this.m_cboDept.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboDept.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboDept.Location = new System.Drawing.Point(89, 16);
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.SelectedIndex = -1;
            this.m_cboDept.SelectedItem = null;
            this.m_cboDept.Size = new System.Drawing.Size(192, 23);
            this.m_cboDept.TabIndex = 502;
            this.m_cboDept.TextBackColor = System.Drawing.Color.White;
            this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
            this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
            this.m_cboDept.Load += new System.EventHandler(this.m_cboDept11_Load);
            // 
            // m_cboArea
            // 
            this.m_cboArea.BorderColor = System.Drawing.Color.Black;
            this.m_cboArea.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboArea.DropButtonCursor = System.Windows.Forms.Cursors.Default;
            this.m_cboArea.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboArea.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArea.ListBackColor = System.Drawing.Color.White;
            this.m_cboArea.ListForeColor = System.Drawing.Color.Black;
            this.m_cboArea.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboArea.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboArea.Location = new System.Drawing.Point(355, 16);
            this.m_cboArea.Name = "m_cboArea";
            this.m_cboArea.SelectedIndex = -1;
            this.m_cboArea.SelectedItem = null;
            this.m_cboArea.Size = new System.Drawing.Size(192, 23);
            this.m_cboArea.TabIndex = 501;
            this.m_cboArea.TextBackColor = System.Drawing.Color.White;
            this.m_cboArea.TextForeColor = System.Drawing.Color.Black;
            this.m_cboArea.SelectedIndexChanged += new System.EventHandler(this.m_cboArea_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(339, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 32);
            this.button3.TabIndex = 500;
            this.button3.Text = "选择当前病人";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(83, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(192, 23);
            this.textBox1.TabIndex = 499;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 498;
            this.label1.Text = "当前病人:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(6, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 279);
            this.panel2.TabIndex = 499;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 32);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(8, 7);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(580, 224);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "住院号";
            this.columnHeader4.Width = 94;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "姓名";
            this.columnHeader1.Width = 103;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "性别";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "年龄";
            this.columnHeader3.Width = 129;
            // 
            // m_rdbInPatient
            // 
            this.m_rdbInPatient.AutoSize = true;
            this.m_rdbInPatient.Checked = true;
            this.m_rdbInPatient.Location = new System.Drawing.Point(3, 87);
            this.m_rdbInPatient.Name = "m_rdbInPatient";
            this.m_rdbInPatient.Size = new System.Drawing.Size(109, 18);
            this.m_rdbInPatient.TabIndex = 503;
            this.m_rdbInPatient.Text = "显示在院病人";
            this.m_rdbInPatient.UseVisualStyleBackColor = true;
            this.m_rdbInPatient.CheckedChanged += new System.EventHandler(this.m_rdbInPatient_CheckedChanged);
            // 
            // m_rdbOutPatient
            // 
            this.m_rdbOutPatient.AutoSize = true;
            this.m_rdbOutPatient.Location = new System.Drawing.Point(3, 115);
            this.m_rdbOutPatient.Name = "m_rdbOutPatient";
            this.m_rdbOutPatient.Size = new System.Drawing.Size(109, 18);
            this.m_rdbOutPatient.TabIndex = 503;
            this.m_rdbOutPatient.Text = "显示出院病人";
            this.m_rdbOutPatient.UseVisualStyleBackColor = true;
            this.m_rdbOutPatient.CheckedChanged += new System.EventHandler(this.m_rdbOutPatient_CheckedChanged);
            // 
            // m_dtpOutPatientStart
            // 
            this.m_dtpOutPatientStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpOutPatientStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutPatientStart.Location = new System.Drawing.Point(70, 6);
            this.m_dtpOutPatientStart.Name = "m_dtpOutPatientStart";
            this.m_dtpOutPatientStart.Size = new System.Drawing.Size(162, 23);
            this.m_dtpOutPatientStart.TabIndex = 504;
            this.m_dtpOutPatientStart.ValueChanged += new System.EventHandler(this.m_dtpOutPatientStart_ValueChanged);
            // 
            // m_dtpOutPatientEnd
            // 
            this.m_dtpOutPatientEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpOutPatientEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOutPatientEnd.Location = new System.Drawing.Point(250, 6);
            this.m_dtpOutPatientEnd.Name = "m_dtpOutPatientEnd";
            this.m_dtpOutPatientEnd.Size = new System.Drawing.Size(162, 23);
            this.m_dtpOutPatientEnd.TabIndex = 504;
            this.m_dtpOutPatientEnd.ValueChanged += new System.EventHandler(this.m_dtpOutPatientEnd_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 14);
            this.label2.TabIndex = 505;
            this.label2.Text = "~";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 505;
            this.label3.Text = "出院日期";
            // 
            // m_pnlOutDate
            // 
            this.m_pnlOutDate.Controls.Add(this.m_dtpOutPatientEnd);
            this.m_pnlOutDate.Controls.Add(this.m_cmdSearchOut);
            this.m_pnlOutDate.Controls.Add(this.label3);
            this.m_pnlOutDate.Controls.Add(this.m_dtpOutPatientStart);
            this.m_pnlOutDate.Controls.Add(this.label2);
            this.m_pnlOutDate.Enabled = false;
            this.m_pnlOutDate.Location = new System.Drawing.Point(118, 106);
            this.m_pnlOutDate.Name = "m_pnlOutDate";
            this.m_pnlOutDate.Size = new System.Drawing.Size(473, 35);
            this.m_pnlOutDate.TabIndex = 506;
            // 
            // m_cmdSearchOut
            // 
            this.m_cmdSearchOut.Location = new System.Drawing.Point(418, 6);
            this.m_cmdSearchOut.Name = "m_cmdSearchOut";
            this.m_cmdSearchOut.Size = new System.Drawing.Size(52, 25);
            this.m_cmdSearchOut.TabIndex = 1;
            this.m_cmdSearchOut.Text = "查询";
            this.m_cmdSearchOut.Click += new System.EventHandler(this.m_cmdSearchOut_Click);
            // 
            // frmChoosePatient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(609, 446);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmChoosePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择病人";
            this.Load += new System.EventHandler(this.frmChoosePatient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.m_pnlOutDate.ResumeLayout(false);
            this.m_pnlOutDate.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
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

		#region 事件
		private void frmChoosePatient_Load(object sender, System.EventArgs e)
		{
			try
			{
			this.m_mthGetCurrentPatient();
			//若无法获取员工ID，提示、退出
			if ((strGEmployeeID.Trim().Length)==0)
			{
				MessageBox.Show("员工未能正确设置");
				return;
			}

			//填充科室
			clsEmrDept_VO[] objDeptInfoArr=null;
			long lngRes=m_objChoosePatientDomain.m_lngGetDeptInfo( strGEmployeeID, out objDeptInfoArr);
			if(lngRes<=0)
			{
				MessageBox.Show("数据库连接失败!");
				return;
			}
			if (objDeptInfoArr!=null)
			{
				for (int i = 0; i < objDeptInfoArr.Length; i++)
				{
					m_cboDept.AddItem(objDeptInfoArr[i]);
				}
				m_cboDept.SelectedItem=objDeptInfoArr[0];
			}
	

			#region 记录当前科室病区
			if (objpCurrentDepartment!=null)
			{
				m_cboDept.SelectedItem=objpCurrentDepartment;
			}
			else
			{
				if(m_cboDept.GetItemsCount()>0)
				{
					objpCurrentDepartment=(clsEmrDept_VO)m_cboDept.SelectedItem;
				}
			}

			#endregion
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message,"Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		
		}
		#endregion

		
		
	
		private PrivilegeData.clsOISF[] m_objOISFArr;

        private void m_mthGetCurrentPatient()
		{
            clsEmrPatient_VO objPatient = null;
            if (MDIParent.m_objCurrentPatient != null)
            {
                objPatient = new clsEmrPatient_VO();
                objPatient.m_strHISInPatientID = MDIParent.m_objCurrentPatient.m_strHISInPatientID;
                objPatient.m_strEMRInPatientID = MDIParent.m_objCurrentPatient.m_strEMRInPatientID;
                objPatient.m_strINPATIENTID_CHR = MDIParent.m_objCurrentPatient.m_strINPATIENTID_CHR;
                objPatient.m_strLASTNAME_VCHR = MDIParent.m_objCurrentPatient.m_strLASTNAME_VCHR;
                objPatient.m_strSEX_CHR = MDIParent.m_objCurrentPatient.m_strSEX_CHR;
                objPatient.m_strPATIENTID_CHR = MDIParent.m_objCurrentPatient.m_strPATIENTID_CHR;
                objPatient.m_strBIRTH_DAT = MDIParent.m_objCurrentPatient.m_strBIRTH_DAT;
                objPatient.m_strMARRIED_CHR = "未知";
            }
            SetPatientInfo = objPatient;
		}
		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			#region old

			#endregion

			try
			{
				this.Cursor=Cursors.WaitCursor;
				clsEmrDept_VO[] objAreaInfoArr=null;
				long lngRes=m_objChoosePatientDomain.m_lngGetAreaInfo(((clsEmrDept_VO)(m_cboDept.SelectedItem)).m_strDEPTID_CHR, out objAreaInfoArr);

				if(lngRes<=0)
				{
					MessageBox.Show("数据库连接失败!");
					return;
				}
				if (objAreaInfoArr!=null)
				{
					m_cboArea.ClearItem();
					for (int i = 0; i < objAreaInfoArr.Length; i++)
					{
						m_cboArea.AddItem(objAreaInfoArr[i]);
 
					}
					m_cboArea.SelectedItem=objAreaInfoArr[0];
				}
				else//若不存在病区，则以科室ID去获取病床
				{
					m_cboArea.ClearItem();
				
				}

				#region 更新当前科室病区
				if(m_cboDept.GetItemsCount()>0)
				{
					objpCurrentDepartment=(clsEmrDept_VO)m_cboDept.SelectedItem;
				}
				if(m_cboArea.GetItemsCount()>0)
				{
					objpCurrentArea=(clsEmrDept_VO)m_cboArea.SelectedItem;
				}

				this.Cursor=Cursors.Default;
				#endregion
			
			}
			catch(Exception exp)
			{
				MessageBox.Show(exp.Message,"Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		
		
			
		}

		private void m_cboArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			#region  old
			clsDepartmentManager m_objDepartmentManager=new clsDepartmentManager();

			#endregion

			this.Cursor=Cursors.WaitCursor;
				
			if (m_cboArea.SelectedItem==null)
				return;

            clsEmrPatient_VO[] objPatientArr = null ;
            if (m_rdbInPatient.Checked)
            {
                m_objChoosePatientDomain.m_lngGetAllPatientInArea(((clsEmrDept_VO)(m_cboArea.SelectedItem)).m_strDEPTID_CHR, out objPatientArr);
            }
            else if(m_rdbOutPatient.Checked)
            {
                m_objChoosePatientDomain.m_lngGetAllPatientInArea(((clsEmrDept_VO)(m_cboArea.SelectedItem)).m_strDEPTID_CHR, m_dtpOutPatientStart.Value, m_dtpOutPatientEnd.Value, out objPatientArr);
            }
			
			if(objPatientArr!=null)
			{
				listView1.Items.Clear();
				ListViewItem lv;
				
				for(int i =0;i<objPatientArr.Length;i++)
				{
					if(objPatientArr[i]==null)
					{
						continue;
					}
				
					lv=new ListViewItem(objPatientArr[i].m_strHISInPatientID);
					lv.SubItems.Add(objPatientArr[i].m_strLASTNAME_VCHR);
                    if (objPatientArr[i].m_strSEX_CHR != null)
                    {
                        lv.SubItems.Add(objPatientArr[i].m_strSEX_CHR.Trim());
                    }
                    else
                    {
                        lv.SubItems.Add("");
                    }
					lv.SubItems.Add(objPatientArr[i].m_strAGELONG_CHR);
					lv.Tag=objPatientArr[i];
					listView1.Items.Add(lv);
				}
			}
			else
			{
				listView1.Items.Clear();
			}
				
			#region 更新当前病区
			if(m_cboArea.GetItemsCount()>0)
			{
				objpCurrentArea=(clsEmrDept_VO)m_cboArea.SelectedItem;
			}
			#endregion

			this.Cursor=Cursors.Default;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
				objPatient =(clsEmrPatient_VO)listView1.SelectedItems[0].Tag;
				if(objPatient==null)
				{
				objPatient =(clsEmrPatient_VO)button3.Tag;
				}
				if(objPatient==null)
				{
				MessageBox.Show("请选择病人");
				}
				this.DialogResult=DialogResult.OK;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;	
			this.Close();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			if(button3.Tag==null)
			{
			return;
			}
		objPatient =(clsEmrPatient_VO)button3.Tag;
		this.DialogResult=DialogResult.OK;
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			this.button1_Click(null,null);
		}

		private void m_cboDept11_Load(object sender, System.EventArgs e)
		{
		
		}

		private clsEmrPatient_VO objPatient;
		public clsEmrPatient_VO SetPatientInfo
		{
			set
			{
				
				
				objPatient =value;
			
			
				if(value==null)
				{
					this.button3.Enabled=false;
				}
				else
				{
					this.button3.Tag=value;
					this.textBox1.Text =objPatient.m_strLASTNAME_VCHR;
				}
			
			}
			get
			{
				return objPatient;
			}
		}

        private void m_rdbOutPatient_CheckedChanged(object sender, EventArgs e)
        {
            m_pnlOutDate.Enabled = m_rdbOutPatient.Checked;
            listView1.Items.Clear();
            if (m_rdbOutPatient.Checked)
            {
                m_dtpOutPatientStart.Value = DateTime.Now.AddDays(0 - m_intArchivingDeadline);
                m_dtpOutPatientEnd.Value = DateTime.Now;
                m_cboArea_SelectedIndexChanged(null, null);
            }
        }

        private void m_dtpOutPatientEnd_ValueChanged(object sender, EventArgs e)
        {
            if (m_dtpOutPatientEnd.Value > DateTime.Now)
            {
                clsPublicFunction.ShowInformationMessageBox("出院时间不能大于当前时间");
                m_dtpOutPatientEnd.Value = DateTime.Now;
                return;
            }
            DateTime dtmDeadLine = Convert.ToDateTime(DateTime.Now.AddDays(0 - m_intArchivingDeadline).ToString("yyyy-MM-dd 00:00:00"));
            if (m_blnIsWantRequest && m_dtpOutPatientEnd.Value < dtmDeadLine && !m_blnHasCaseAdminRole)
            {
                m_dtpOutPatientEnd.Value = DateTime.Now;
                clsPublicFunction.ShowInformationMessageBox("当前用户没有查看已归档病案的权限");
                return;
            } 
        }

        private void m_dtpOutPatientStart_ValueChanged(object sender, EventArgs e)
        {
            if (m_dtpOutPatientStart.Value > DateTime.Now)
            {
                clsPublicFunction.ShowInformationMessageBox("出院时间不能大于当前时间");
                m_dtpOutPatientStart.Value = DateTime.Now.AddDays(0 - m_intArchivingDeadline);
                return;
            }
            DateTime dtmDeadLine = Convert.ToDateTime(DateTime.Now.AddDays(0 - m_intArchivingDeadline).ToString("yyyy-MM-dd 00:00:00"));
            if (m_blnIsWantRequest && m_dtpOutPatientStart.Value < dtmDeadLine && !m_blnHasCaseAdminRole)
            {
                m_dtpOutPatientStart.Value = dtmDeadLine;
                clsPublicFunction.ShowInformationMessageBox("当前用户没有查看已归档病案的权限");
                return;
            } 
        }

        private void m_rdbInPatient_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (m_rdbInPatient.Checked)
            {
                m_cboArea_SelectedIndexChanged(null, null);
            }
        }

        private void m_cmdSearchOut_Click(object sender, EventArgs e)
        {
            m_cboArea_SelectedIndexChanged(null, null);
        }
	}
}
