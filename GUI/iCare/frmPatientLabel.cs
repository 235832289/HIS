using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;
using PrivilegeData;
using com.digitalwave.emr.BEDExplorer;

namespace iCare
{
	/// <summary>
	/// Summary description for frmPatientLabel.
	/// </summary>
	public class frmPatientLabel : iCare.iCareBaseForm.frmBaseForm
	{
		private iCare.ctlDataGridPatientLabel dtgPatientLabel;
		public com.digitalwave.Utility.Controls.ctlComboBox m_cboDept;
		public com.digitalwave.Utility.Controls.ctlComboBox m_cboArea;
		protected System.Windows.Forms.Label lblAreaTitle;
		protected System.Windows.Forms.Label lblDept;
		private System.Windows.Forms.ListView lsvItem;
		private System.Drawing.Printing.PrintDocument pdPatientLabel;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// 部门中间层对象
		/// </summary>
		private clsDepartmentManager m_objDepartmentManager=new clsDepartmentManager();
		private PinkieControls.ButtonXP cmdShowAll;
		private PinkieControls.ButtonXP m_cmdClose;
		private PinkieControls.ButtonXP cmdPrint;
		private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn8;
		private PinkieControls.ButtonXP cmdClear;
		/// <summary>
		/// 登录员工的权限信息
		/// </summary>
//		private clsPrivilegeInfo[] objPIArr = clsLoginContext.s_ObjLoginContext.m_ObjPIArr;

		public frmPatientLabel()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();	

			this.StartPosition = FormStartPosition.CenterParent;
			try
			{
//				m_blnCanDeptSelectIndexChangeEventTakePlace=false;
				//初始化清空
				m_cboDept.ClearItem();
				this.m_cboArea.ClearItem();
				this.m_cboArea.Text="";
				//获取科室
				clsHospitalManagerDomain objDomain=new clsHospitalManagerDomain();
				clsEmrDept_VO[] objDeptInfoArr=null;
				long lngRes=objDomain.m_lngGetDeptInfo( clsEMRLogin.LoginInfo.m_strEmpID, out objDeptInfoArr);
				if(lngRes<=0)
				{
					if(lngRes==(long)iCareData.enmOperationResult.Not_permission)
						clsPublicFunction.ShowInformationMessageBox("权限不足!");
					else
						clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
					return;
				}
				if (objDeptInfoArr!=null)
				{
					for (int i = 0; i < objDeptInfoArr.Length; i++)
					{
						//转换为旧的
						clsDepartment objDeptTemp= new clsDepartment(objDeptInfoArr[i].m_strSHORTNO_CHR,objDeptInfoArr[i].m_strDEPTNAME_VCHR);
						//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
						objDeptTemp.m_strDeptNewID=objDeptInfoArr[i].m_strDEPTID_CHR;
						m_cboDept.AddItem(objDeptTemp);
						//m_cboDept.AddItem(objDeptInfoArr[i]);
					}
				}

			}
			catch (Exception exp)
			{
				string strErrMessage=exp.Message+"\n at Module:["+exp.TargetSite.ReflectedType.Name+"]\n  Method:["+exp.TargetSite.Name+"]";
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				objLogger.Log2File(MDIParent.s_strErrorFilePath, "Exception: \r\n"+strErrMessage);
				MessageBox.Show(strErrMessage,"Error Message", MessageBoxButtons.OK,MessageBoxIcon.Error);
   
			}
			#region mark by bhuang
			//添加部门
//			clsDepartment[] objDeptArr;
//
//			objDeptArr=	m_objDepartmentManager.m_objGetAllInDeptArr();
//			
//			if(objDeptArr !=null)
//			{
//				string strDeptID = "";
//				for(int i=0;i<objDeptArr.Length;i++)
//				{
//					if(objPIArr != null)
//					{
//						for(int i1=0;i1<objPIArr.Length;i1++)
//						{
//							if(objPIArr[i1] == null)
//								continue;
//								
//							if((objPIArr[i1].m_objGetOISF(objDeptArr[i].m_StrDeptID,(int)PrivilegeData.enmPrivilegeSF.HRPExplorer,(int)PrivilegeData.enmPrivilegeOperation.Read) != null) && strDeptID!=objDeptArr[i].m_StrDeptID)
//							{
//								m_cboDept.AddItem(objDeptArr[i]);
//								strDeptID = objDeptArr[i].m_StrDeptID;
//							}
//						}							
//					}							
//				}
//				m_cboDept.SelectedIndex = 0;
//			}
			#endregion
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmPatientLabel));
			this.dtgPatientLabel = new iCare.ctlDataGridPatientLabel(this.components);
			this.lsvItem = new System.Windows.Forms.ListView();
			this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboArea = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblAreaTitle = new System.Windows.Forms.Label();
			this.lblDept = new System.Windows.Forms.Label();
			this.pdPatientLabel = new System.Drawing.Printing.PrintDocument();
			this.cmdShowAll = new PinkieControls.ButtonXP();
			this.m_cmdClose = new PinkieControls.ButtonXP();
			this.cmdPrint = new PinkieControls.ButtonXP();
			this.cmdClear = new PinkieControls.ButtonXP();
			this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
			this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
			this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dtgPatientLabel)).BeginInit();
			this.SuspendLayout();
			// 
			// dtgPatientLabel
			// 
			this.dtgPatientLabel.BackgroundColor = System.Drawing.SystemColors.GrayText;
			this.dtgPatientLabel.CaptionBackColor = System.Drawing.SystemColors.Control;
			this.dtgPatientLabel.CaptionForeColor = System.Drawing.Color.Black;
			this.dtgPatientLabel.CaptionText = "病人基本资料";
			this.dtgPatientLabel.DataMember = "";
			this.dtgPatientLabel.GridLineColor = System.Drawing.SystemColors.ControlLight;
			this.dtgPatientLabel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dtgPatientLabel.Location = new System.Drawing.Point(8, 56);
			this.dtgPatientLabel.m_LsvGridShow = this.lsvItem;
			this.dtgPatientLabel.Name = "dtgPatientLabel";
			this.dtgPatientLabel.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			this.dtgPatientLabel.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			this.dtgPatientLabel.Size = new System.Drawing.Size(812, 388);
			this.dtgPatientLabel.TabIndex = 0;
			this.dtgPatientLabel.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										this.dataGridTableStyle1});
			this.dtgPatientLabel.MouseEnter += new System.EventHandler(this.dtgPatientLabel_MouseEnter);
			// 
			// lsvItem
			// 
			this.lsvItem.FullRowSelect = true;
			this.lsvItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lsvItem.Location = new System.Drawing.Point(280, 196);
			this.lsvItem.Name = "lsvItem";
			this.lsvItem.TabIndex = 10000006;
			this.lsvItem.View = System.Windows.Forms.View.Details;
			// 
			// m_cboDept
			// 
			this.m_cboDept.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboDept.BorderColor = System.Drawing.Color.Black;
			this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.ForeColor = System.Drawing.Color.White;
			this.m_cboDept.ListBackColor = System.Drawing.Color.White;
			this.m_cboDept.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboDept.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboDept.Location = new System.Drawing.Point(56, 16);
			this.m_cboDept.m_BlnEnableItemEventMenu = true;
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.SelectedIndex = -1;
			this.m_cboDept.SelectedItem = null;
			this.m_cboDept.SelectionStart = -1;
			this.m_cboDept.Size = new System.Drawing.Size(180, 23);
			this.m_cboDept.TabIndex = 10000003;
			this.m_cboDept.TextBackColor = System.Drawing.Color.White;
			this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
			this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
			// 
			// m_cboArea
			// 
			this.m_cboArea.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboArea.BorderColor = System.Drawing.Color.Black;
			this.m_cboArea.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboArea.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboArea.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboArea.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboArea.ForeColor = System.Drawing.Color.White;
			this.m_cboArea.ListBackColor = System.Drawing.Color.White;
			this.m_cboArea.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboArea.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboArea.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboArea.Location = new System.Drawing.Point(292, 16);
			this.m_cboArea.m_BlnEnableItemEventMenu = true;
			this.m_cboArea.Name = "m_cboArea";
			this.m_cboArea.SelectedIndex = -1;
			this.m_cboArea.SelectedItem = null;
			this.m_cboArea.SelectionStart = -1;
			this.m_cboArea.Size = new System.Drawing.Size(180, 23);
			this.m_cboArea.TabIndex = 10000000;
			this.m_cboArea.TextBackColor = System.Drawing.Color.White;
			this.m_cboArea.TextForeColor = System.Drawing.Color.Black;
			this.m_cboArea.SelectedIndexChanged += new System.EventHandler(this.m_cboArea_SelectedIndexChanged);
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.AutoSize = true;
			this.lblAreaTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAreaTitle.ForeColor = System.Drawing.Color.Black;
			this.lblAreaTitle.Location = new System.Drawing.Point(244, 18);
			this.lblAreaTitle.Name = "lblAreaTitle";
			this.lblAreaTitle.Size = new System.Drawing.Size(41, 19);
			this.lblAreaTitle.TabIndex = 10000001;
			this.lblAreaTitle.Text = "病区:";
			this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDept
			// 
			this.lblDept.AutoSize = true;
			this.lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDept.ForeColor = System.Drawing.Color.Black;
			this.lblDept.Location = new System.Drawing.Point(8, 18);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(41, 19);
			this.lblDept.TabIndex = 10000002;
			this.lblDept.Text = "科室:";
			this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pdPatientLabel
			// 
			this.pdPatientLabel.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.pdPatientLabel_EndPrint);
			this.pdPatientLabel.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdPatientLabel_PrintPage);
			// 
			// cmdShowAll
			// 
			this.cmdShowAll.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdShowAll.DefaultScheme = true;
			this.cmdShowAll.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdShowAll.ForeColor = System.Drawing.Color.Black;
			this.cmdShowAll.Hint = "";
			this.cmdShowAll.Location = new System.Drawing.Point(476, 12);
			this.cmdShowAll.Name = "cmdShowAll";
			this.cmdShowAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdShowAll.Size = new System.Drawing.Size(84, 31);
			this.cmdShowAll.TabIndex = 10000009;
			this.cmdShowAll.Text = "显示全部";
			this.cmdShowAll.Click += new System.EventHandler(this.cmdShowAll_Click);
			// 
			// m_cmdClose
			// 
			this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdClose.DefaultScheme = true;
			this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdClose.ForeColor = System.Drawing.Color.Black;
			this.m_cmdClose.Hint = "";
			this.m_cmdClose.Location = new System.Drawing.Point(740, 12);
			this.m_cmdClose.Name = "m_cmdClose";
			this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdClose.Size = new System.Drawing.Size(84, 31);
			this.m_cmdClose.TabIndex = 10000010;
			this.m_cmdClose.Text = "关闭";
			this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
			// 
			// cmdPrint
			// 
			this.cmdPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdPrint.DefaultScheme = true;
			this.cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdPrint.ForeColor = System.Drawing.Color.Black;
			this.cmdPrint.Hint = "";
			this.cmdPrint.Location = new System.Drawing.Point(564, 12);
			this.cmdPrint.Name = "cmdPrint";
			this.cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdPrint.Size = new System.Drawing.Size(84, 31);
			this.cmdPrint.TabIndex = 10000011;
			this.cmdPrint.Text = "打印预览";
			this.cmdPrint.Click += new System.EventHandler(this.cmdPrint_Click);
			// 
			// cmdClear
			// 
			this.cmdClear.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdClear.DefaultScheme = true;
			this.cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdClear.ForeColor = System.Drawing.Color.Black;
			this.cmdClear.Hint = "";
			this.cmdClear.Location = new System.Drawing.Point(652, 12);
			this.cmdClear.Name = "cmdClear";
			this.cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdClear.Size = new System.Drawing.Size(84, 31);
			this.cmdClear.TabIndex = 10000012;
			this.cmdClear.Text = "清空";
			this.cmdClear.Click += new System.EventHandler(this.cmdClear_Click);
			// 
			// dataGridTableStyle1
			// 
			this.dataGridTableStyle1.DataGrid = this.dtgPatientLabel;
			this.dataGridTableStyle1.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																												  this.dataGridTextBoxColumn1,
																												  this.dataGridTextBoxColumn2,
																												  this.dataGridTextBoxColumn3,
																												  this.dataGridTextBoxColumn4,
																												  this.dataGridTextBoxColumn5,
																												  this.dataGridTextBoxColumn6,
																												  this.dataGridTextBoxColumn7,
																												  this.dataGridTextBoxColumn8});
			this.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridTableStyle1.MappingName = "";
			// 
			// dataGridTextBoxColumn1
			// 
			this.dataGridTextBoxColumn1.Format = "";
			this.dataGridTextBoxColumn1.FormatInfo = null;
			this.dataGridTextBoxColumn1.HeaderText = "姓名";
			this.dataGridTextBoxColumn1.MappingName = "lastname_vchr";
			this.dataGridTextBoxColumn1.Width = 75;
			// 
			// dataGridTextBoxColumn2
			// 
			this.dataGridTextBoxColumn2.Format = "";
			this.dataGridTextBoxColumn2.FormatInfo = null;
			this.dataGridTextBoxColumn2.HeaderText = "年龄";
			this.dataGridTextBoxColumn2.MappingName = "birth_dat";
			this.dataGridTextBoxColumn2.Width = 75;
			// 
			// dataGridTextBoxColumn3
			// 
			this.dataGridTextBoxColumn3.Format = "";
			this.dataGridTextBoxColumn3.FormatInfo = null;
			this.dataGridTextBoxColumn3.HeaderText = "性别";
			this.dataGridTextBoxColumn3.MappingName = "sex_chr";
			this.dataGridTextBoxColumn3.Width = 75;
			// 
			// dataGridTextBoxColumn4
			// 
			this.dataGridTextBoxColumn4.Format = "";
			this.dataGridTextBoxColumn4.FormatInfo = null;
			this.dataGridTextBoxColumn4.HeaderText = "病区";
			this.dataGridTextBoxColumn4.MappingName = "DEPTNAME_VCHR";
			this.dataGridTextBoxColumn4.Width = 75;
			// 
			// dataGridTextBoxColumn5
			// 
			this.dataGridTextBoxColumn5.Format = "";
			this.dataGridTextBoxColumn5.FormatInfo = null;
			this.dataGridTextBoxColumn5.HeaderText = "床号";
			this.dataGridTextBoxColumn5.MappingName = "CODE_CHR";
			this.dataGridTextBoxColumn5.Width = 75;
			// 
			// dataGridTextBoxColumn6
			// 
			this.dataGridTextBoxColumn6.Format = "";
			this.dataGridTextBoxColumn6.FormatInfo = null;
			this.dataGridTextBoxColumn6.HeaderText = "住院号";
			this.dataGridTextBoxColumn6.MappingName = "inpatientid_chr";
			this.dataGridTextBoxColumn6.Width = 75;
			// 
			// dataGridTextBoxColumn7
			// 
			this.dataGridTextBoxColumn7.Format = "";
			this.dataGridTextBoxColumn7.FormatInfo = null;
			this.dataGridTextBoxColumn7.HeaderText = "诊断";
			this.dataGridTextBoxColumn7.MappingName = "mzdiagnose_vchr";
			this.dataGridTextBoxColumn7.Width = 75;
			// 
			// dataGridTextBoxColumn8
			// 
			this.dataGridTextBoxColumn8.Format = "";
			this.dataGridTextBoxColumn8.FormatInfo = null;
			this.dataGridTextBoxColumn8.HeaderText = "打印张数";
			this.dataGridTextBoxColumn8.MappingName = "";
			this.dataGridTextBoxColumn8.Width = 75;
			// 
			// frmPatientLabel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(826, 451);
			this.Controls.Add(this.cmdClear);
			this.Controls.Add(this.cmdPrint);
			this.Controls.Add(this.m_cmdClose);
			this.Controls.Add(this.cmdShowAll);
			this.Controls.Add(this.lblAreaTitle);
			this.Controls.Add(this.lblDept);
			this.Controls.Add(this.m_cboDept);
			this.Controls.Add(this.m_cboArea);
			this.Controls.Add(this.dtgPatientLabel);
			this.Controls.Add(this.lsvItem);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmPatientLabel";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "病人标签";
			this.Load += new System.EventHandler(this.frmPatientLabel_Load);
			((System.ComponentModel.ISupportInitialize)(this.dtgPatientLabel)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

//		private stuPatientInfo[] m_stuPIArr = new stuPatientInfo[100];

		private void frmPatientLabel_Load(object sender, System.EventArgs e)
		{
			dtgPatientLabel.m_mthInitGrid();
			dtgPatientLabel.CurrentCell = new DataGridCell(0,1);

		
			
//			for(int i=0;i<m_stuPIArr.Length;i++)
//			{
//				m_stuPIArr[i].strName="王寿堂";
//				m_stuPIArr[i].strAge="50";
//				m_stuPIArr[i].strSex="男";
//				m_stuPIArr[i].strArea="耳鼻喉科病区一";
//				m_stuPIArr[i].strBed="+1";
//				m_stuPIArr[i].strInPatientID="666666";
//				m_stuPIArr[i].strDiagnose="喉炎中华人民共和国程序员为什么焦虑喉炎中华人民共和国程序员为什么焦虑";	
//			}

			//m_cboDept.Focus();
			
		}
		public static void Main()
		{
			Application.Run(new frmPatientLabel());
		}

		private clsPatientLabel[] m_objPatientLabel;

		private void cmdPrint_Click(object sender, System.EventArgs e)
		{
			m_objPatientLabel = dtgPatientLabel.m_objGetPatientLabel();
			if(m_objPatientLabel==null || m_objPatientLabel.Length<1)
			{
				clsPublicFunction.ShowInformationMessageBox("请输入病人或打印张数!");
				return;
			}

			PrintPreviewDialog ppdPatientLabel = new PrintPreviewDialog();
			ppdPatientLabel.Document = pdPatientLabel;
			ppdPatientLabel.ShowDialog();
		}

		/// <summary>
		/// 根据床号查找病人
		/// </summary>
		/// <returns></returns>
		public clsPatient [] m_objGetPatientByBedNO(string p_strBedNo)
		{			
			return clsSystemContext.s_ObjCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_InArea(((clsInPatientArea)(m_cboArea.SelectedItem)).m_StrAreaID,p_strBedNo);			
		}

		/// <summary>
		/// 根据住院号查找病人
		/// </summary>
		/// <returns></returns>
		public clsPatient[] m_objGetPatientByInPatientID(string p_strInPatientID)
		{
			return clsSystemContext.s_ObjCurrentContext.m_ObjPatientManager.m_objGetInPatientByAreaIDLike(((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID,p_strInPatientID);
		}

		/// <summary>
		/// 根据姓名查找病人
		/// </summary>
		/// <returns></returns>
//		public static clsPatient[] m_objGetPatientByInPatientName(string p_strInPatientName)
//		{
//			return m_objGetPatientByInPatientName1(p_strInPatientName);
//			
//		}
		public clsPatient[] m_objGetPatientByInPatientName1(string p_strInPatientName)
		{
			return clsSystemContext.s_ObjCurrentContext.m_ObjPatientManager.m_objGetPatientByLikePatientName_InArea(((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID,p_strInPatientName);
		}

		private ArrayList m_arlPatient = new ArrayList();
		private int m_intCurrent = 0;
		private clsPrintRichTextContext m_objDiagnose = new clsPrintRichTextContext(Color.Black,new Font("SimSun",8));
		private void pdPatientLabel_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			Font fntText = new Font("",8);
			int intPosY = (int)enmPosition.TopY;
			int intColumn = 1;
			
			for(int i=m_intCurrent;i<m_objPatientLabel.Length;i++)
			{
				m_objDiagnose.m_mthSetContextWithAllCorrect(m_objPatientLabel[i].strDiagnose,"<root/>");
				if(intColumn==1)
				{
					e.Graphics.DrawString("姓名:"+m_objPatientLabel[i].strName,fntText,Brushes.Black,(int)enmPosition.LeftX1,intPosY);
					e.Graphics.DrawString("年龄:"+m_objPatientLabel[i].strAge,fntText,Brushes.Black,(int)enmPosition.LeftX1+78,intPosY);
					e.Graphics.DrawString("性别:"+m_objPatientLabel[i].strSex,fntText,Brushes.Black,(int)enmPosition.LeftX1+133,intPosY);
					e.Graphics.DrawString("病区:"+m_objPatientLabel[i].strArea,fntText,Brushes.Black,(int)enmPosition.LeftX1+188,intPosY);
					e.Graphics.DrawString("床号:"+m_objPatientLabel[i].strBed,fntText,Brushes.Black,(int)enmPosition.LeftX1+320,intPosY);
					intPosY += (int)enmPosition.RowStep;
					e.Graphics.DrawString("住院号:"+m_objPatientLabel[i].strInPatientID,fntText,Brushes.Black,(int)enmPosition.LeftX1,intPosY);					
					e.Graphics.DrawString("诊断:",fntText,Brushes.Black,(int)enmPosition.LeftX1+88,intPosY);	
					int intRealHeight;
					Rectangle rtgBlock = new Rectangle((int)enmPosition.LeftX1+120,intPosY,250,15);					
					if(m_objDiagnose.m_blnPrintAllBySimSun(8,rtgBlock,e.Graphics,out intRealHeight,false))
						intPosY += (int)enmPosition.RowStep;
					else
						intPosY += (int)enmPosition.RowStep+5;
					if(intPosY>(int)enmPosition.BottomY)
					{
						intPosY = (int)enmPosition.TopY;
						intColumn ++;
					}
				}
				else if(intColumn==2)
				{
					e.Graphics.DrawString("姓名:"+m_objPatientLabel[i].strName,fntText,Brushes.Black,(int)enmPosition.LeftX2,intPosY);
					e.Graphics.DrawString("年龄:"+m_objPatientLabel[i].strAge,fntText,Brushes.Black,(int)enmPosition.LeftX2+78,intPosY);
					e.Graphics.DrawString("性别:"+m_objPatientLabel[i].strSex,fntText,Brushes.Black,(int)enmPosition.LeftX2+133,intPosY);
					e.Graphics.DrawString("病区:"+m_objPatientLabel[i].strArea,fntText,Brushes.Black,(int)enmPosition.LeftX2+188,intPosY);
					e.Graphics.DrawString("床号:"+m_objPatientLabel[i].strBed,fntText,Brushes.Black,(int)enmPosition.LeftX2+320,intPosY);
					intPosY += (int)enmPosition.RowStep;
					e.Graphics.DrawString("住院号:"+m_objPatientLabel[i].strInPatientID,fntText,Brushes.Black,(int)enmPosition.LeftX2,intPosY);
					e.Graphics.DrawString("诊断:",fntText,Brushes.Black,(int)enmPosition.LeftX2+88,intPosY);	
					int intRealHeight;
					Rectangle rtgBlock = new Rectangle((int)enmPosition.LeftX2+120,intPosY,250,15);					
					if(m_objDiagnose.m_blnPrintAllBySimSun(8,rtgBlock,e.Graphics,out intRealHeight,false))
						intPosY += (int)enmPosition.RowStep;
					else
						intPosY += (int)enmPosition.RowStep+5;
					if(intPosY>(int)enmPosition.BottomY)
					{
						intPosY = (int)enmPosition.TopY;
						e.HasMorePages = true;
						intColumn =1;
						m_intCurrent = i;	
						//如果不中断循环的话会继续打上面intColumn=1的东东
						//当跳出这个函数后，因为e.HasMorePages，所以会重新执行这个函数
						break;
					}
				}
			}
		}

		private void pdPatientLabel_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_intCurrent = 0;
		}

		private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				//初始化清空
				this.Cursor=Cursors.Default;
				m_cboArea.ClearItem();
				//获取病区

				clsHospitalManagerDomain objDomain=new clsHospitalManagerDomain();
				clsEmrDept_VO[] objAreaInfoArr=null;
				long lngRes=objDomain.m_lngGetAreaInfo(((clsDepartment)(m_cboDept.SelectedItem)).m_strDeptNewID, out objAreaInfoArr);

				//long lngRes=objDomain.m_lngGetAreaInfo(((clsEmrDept_VO)(m_cboDept.SelectedItem)).m_strDEPTID_CHR, out objAreaInfoArr);
				if(lngRes<=0)
				{
					if(lngRes==(long)iCareData.enmOperationResult.Not_permission)
						clsPublicFunction.ShowInformationMessageBox("权限不足!");
					else
						clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
					return;
				}
				if (objAreaInfoArr!=null)
				{
					m_cboArea.ClearItem();
					for (int i = 0; i < objAreaInfoArr.Length; i++)
					{
						//转换为旧的
						clsInPatientArea objAreaTemp= new clsInPatientArea(objAreaInfoArr[i].m_strSHORTNO_CHR,objAreaInfoArr[i].m_strDEPTNAME_VCHR,objAreaInfoArr[i].m_strDEPTID_CHR);
						//转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
						objAreaTemp.m_strAreaNewID=objAreaInfoArr[i].m_strDEPTID_CHR;
						m_cboArea.AddItem(objAreaTemp);
						//m_cboArea.AddItem(objAreaInfoArr[i]);

					}
					m_cboArea.SelectedIndex = 0;
				}
			}
			catch (Exception exp)
			{
				string strErrMessage=exp.Message+"\n at Module:["+exp.TargetSite.ReflectedType.Name+"]\n  Method:["+exp.TargetSite.Name+"]";
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				objLogger.Log2File(MDIParent.s_strErrorFilePath, "Exception: \r\n"+strErrMessage);
			}
			#region
//			this.Cursor=Cursors.WaitCursor;
//			this.m_cboArea.ClearItem();
//			clsInPatientArea[] objAreaArr;
//			m_objDepartmentManager.m_lngGetAllAreaInDept(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,out objAreaArr);
//			if(objAreaArr !=null)
//			{	
//				this.m_cboArea.AddRangeItems(objAreaArr);
//				this.m_cboArea.SelectedIndex = 0;
//			}			
//			this.Cursor=Cursors.Default;
			#endregion
		}

		private void cmdShowAll_Click(object sender, System.EventArgs e)
		{
			//先清空
			dtgPatientLabel.m_mthClear();

			string [,]  objPatientArr;
		
			if(m_cboArea.SelectedItem != null)
			{
				m_objDepartmentManager.m_lngGetAllBedAndPatientInArea(((clsInPatientArea)m_cboArea.SelectedItem).m_strAreaNewID,out objPatientArr);
			}
			else if(m_cboDept.SelectedItem != null)
			{
				m_objDepartmentManager.m_lngGetAllBedAndPatientInArea(((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID,out objPatientArr);
			}
			else
				return;

			dtgPatientLabel.m_mthAddRow(new object[]{"","","","","","",""});
			dtgPatientLabel.m_mthClear();
			string strAge=null;
			for(int i=0;i<objPatientArr.GetLength(0);i++)
			{
				
					string[] objValueArr = new string[8];				
					objValueArr[0] =  objPatientArr[i,0]!=null ?objPatientArr[i,0].ToString():"";
					
						
						if (objPatientArr[i,1]!=null)
						{
							DateTime m_dtmBirth=DateTime.Parse(objPatientArr[i,1].ToString());
							if((int)(DateTime.Now.Year - m_dtmBirth.Year)>0)
							{
								strAge= ((int)(DateTime.Now.Year - m_dtmBirth.Year)).ToString() + "岁";
								if (int.Parse(m_dtmBirth.Month.ToString()) != 12)
									strAge = ((int)(DateTime.Now.Year - m_dtmBirth.Year)).ToString() + "岁" + m_dtmBirth.Month.ToString() + "月";
								else
									strAge = ((int)(DateTime.Now.Year - m_dtmBirth.Year)+1).ToString() + "岁" + "0月";
							}
							else if((int)(DateTime.Now.Month - m_dtmBirth.Month)>0)
							{
								strAge = ((int)(DateTime.Now.Month - m_dtmBirth.Month)).ToString() + "月";
								if (int.Parse(m_dtmBirth.Month.ToString()) != 12)
									strAge= "0岁" + ((int)(DateTime.Now.Month - m_dtmBirth.Month)).ToString() + "月";
								else
									strAge= "1岁" + "0月";

							}
							else
							{
								strAge = ((int)(DateTime.Now.Day - m_dtmBirth.Day)).ToString() + "天";
								strAge = ((int)(DateTime.Now.Day - m_dtmBirth.Day)).ToString() + "天";
							}
						}
						else
						{
							strAge="未知";
							strAge="未知";
						}
							
					objValueArr[1] =strAge;	
					objValueArr[2] =objPatientArr[i,2]!=null ?objPatientArr[i,2].ToString():"";	
					objValueArr[3] = objPatientArr[i,3]!=null ?objPatientArr[i,3].ToString():"";	
					objValueArr[4] = objPatientArr[i,4]!=null ?objPatientArr[i,4].ToString():"";	
					objValueArr[5] = objPatientArr[i,5]!=null ?objPatientArr[i,5].ToString():"";	
					objValueArr[6] = objPatientArr[i,6]!=null ?objPatientArr[i,6].ToString():"";	
					objValueArr[7] = "";
					dtgPatientLabel.m_mthAddRow(objValueArr);
				
			}

		}

		private void cmdClear_Click(object sender, System.EventArgs e)
		{
			dtgPatientLabel.m_mthClear();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_cboArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.Default;

		}

		private void dtgPatientLabel_MouseEnter(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.Default;

		}
		
		
//		public struct stuPatientInfo
//		{
//			public string strName,strAge,strSex,strArea,strBed,strInPatientID,strDiagnose;
//			public int intQuantity;
//		}
		
		/// <summary>
		/// 打印的定位
		/// </summary>
		public enum enmPosition
		{
			/// <summary>
			/// 顶端
			/// </summary>
			TopY = 20,
			///<summary>
			/// 左端1
			/// </summary>
			LeftX1 = 10,
			///<summary>
			/// 左端2
			/// </summary>
			LeftX2 = LeftX1+400,
			/// <summary>
			/// 每行的步长
			/// </summary>
			RowStep = 25,
			/// <summary>
			/// 底端
			/// </summary>
			BottomY=1090		
		}
		
	}
}
