using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
namespace iCare
{
	/// <summary>
	/// frmReLocate 的摘要说明。
	/// </summary>
	public class frmReLocate : System.Windows.Forms.Form
	{
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedArea2;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label68;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedDept2;
		private System.Windows.Forms.Label label59;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboPatientBedName2;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.Label label2;
		private		clsDepartmentManager m_objManagerDomain=new clsDepartmentManager();
		private	clsDepartmentHandlerDomain m_objHandlerDomain=new clsDepartmentHandlerDomain();
		private PinkieControls.ButtonXP m_cmdSubmit;
		private PinkieControls.ButtonXP m_cmdReLocate;
		 public static	 clsPatient objPatient = null;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmReLocate()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReLocate));
			this.m_cboPatientBedArea2 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label71 = new System.Windows.Forms.Label();
			this.label70 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.m_cboPatientBedDept2 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label59 = new System.Windows.Forms.Label();
			this.m_cboPatientBedName2 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label58 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_cmdSubmit = new PinkieControls.ButtonXP();
			this.m_cmdReLocate = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// m_cboPatientBedArea2
			// 
			this.m_cboPatientBedArea2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedArea2.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPatientBedArea2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedArea2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedArea2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedArea2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedArea2.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedArea2.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedArea2.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedArea2.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedArea2.Location = new System.Drawing.Point(70, 54);
			this.m_cboPatientBedArea2.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedArea2.Name = "m_cboPatientBedArea2";
			this.m_cboPatientBedArea2.SelectedIndex = -1;
			this.m_cboPatientBedArea2.SelectedItem = null;
			this.m_cboPatientBedArea2.Size = new System.Drawing.Size(110, 23);
			this.m_cboPatientBedArea2.TabIndex = 29586;
			this.m_cboPatientBedArea2.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedArea2.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedArea2.DropDown += new System.EventHandler(this.m_cboPatientBedArea2_DropDown);
			this.m_cboPatientBedArea2.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedArea2_SelectedIndexChanged);
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label71.ForeColor = System.Drawing.Color.Red;
			this.label71.Location = new System.Drawing.Point(180, 62);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(19, 15);
			this.label71.TabIndex = 29590;
			this.label71.Text = "***";
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label70.ForeColor = System.Drawing.Color.Red;
			this.label70.Location = new System.Drawing.Point(180, 98);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(19, 15);
			this.label70.TabIndex = 29589;
			this.label70.Text = "***";
			// 
			// label68
			// 
			this.label68.AutoSize = true;
			this.label68.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label68.ForeColor = System.Drawing.Color.Red;
			this.label68.Location = new System.Drawing.Point(180, 26);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(19, 15);
			this.label68.TabIndex = 29588;
			this.label68.Text = "***";
			// 
			// m_cboPatientBedDept2
			// 
			this.m_cboPatientBedDept2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedDept2.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPatientBedDept2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedDept2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedDept2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedDept2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedDept2.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedDept2.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedDept2.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedDept2.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedDept2.Location = new System.Drawing.Point(70, 18);
			this.m_cboPatientBedDept2.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedDept2.Name = "m_cboPatientBedDept2";
			this.m_cboPatientBedDept2.SelectedIndex = -1;
			this.m_cboPatientBedDept2.SelectedItem = null;
			this.m_cboPatientBedDept2.Size = new System.Drawing.Size(110, 23);
			this.m_cboPatientBedDept2.TabIndex = 29585;
			this.m_cboPatientBedDept2.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedDept2.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedDept2.DropDown += new System.EventHandler(this.m_cboPatientBedDept2_DropDown);
			this.m_cboPatientBedDept2.SelectedIndexChanged += new System.EventHandler(this.m_cboPatientBedDept2_SelectedIndexChanged);
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label59.Location = new System.Drawing.Point(22, 22);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(41, 19);
			this.label59.TabIndex = 29582;
			this.label59.Text = "科室:";
			this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cboPatientBedName2
			// 
			this.m_cboPatientBedName2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(202)), ((System.Byte)(229)), ((System.Byte)(232)));
			this.m_cboPatientBedName2.BorderColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboPatientBedName2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboPatientBedName2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboPatientBedName2.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedName2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboPatientBedName2.ForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.ListBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedName2.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboPatientBedName2.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboPatientBedName2.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboPatientBedName2.Location = new System.Drawing.Point(70, 90);
			this.m_cboPatientBedName2.m_BlnEnableItemEventMenu = true;
			this.m_cboPatientBedName2.Name = "m_cboPatientBedName2";
			this.m_cboPatientBedName2.SelectedIndex = -1;
			this.m_cboPatientBedName2.SelectedItem = null;
			this.m_cboPatientBedName2.Size = new System.Drawing.Size(110, 23);
			this.m_cboPatientBedName2.TabIndex = 29587;
			this.m_cboPatientBedName2.TextBackColor = System.Drawing.Color.White;
			this.m_cboPatientBedName2.TextForeColor = System.Drawing.Color.Black;
			this.m_cboPatientBedName2.DropDown += new System.EventHandler(this.m_cboPatientBedName2_DropDown);
			// 
			// label58
			// 
			this.label58.AutoSize = true;
			this.label58.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label58.Location = new System.Drawing.Point(22, 58);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(41, 19);
			this.label58.TabIndex = 29583;
			this.label58.Text = "病区:";
			this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(22, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 29584;
			this.label2.Text = "病床:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_cmdSubmit
			// 
			this.m_cmdSubmit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSubmit.DefaultScheme = true;
			this.m_cmdSubmit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSubmit.ForeColor = System.Drawing.Color.Black;
			this.m_cmdSubmit.Hint = "";
			this.m_cmdSubmit.Location = new System.Drawing.Point(210, 24);
			this.m_cmdSubmit.Name = "m_cmdSubmit";
			this.m_cmdSubmit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSubmit.Size = new System.Drawing.Size(106, 26);
			this.m_cmdSubmit.TabIndex = 10000005;
			this.m_cmdSubmit.Text = "确定";
			this.m_cmdSubmit.Click += new System.EventHandler(this.m_cmdSubmit_Click);
			// 
			// m_cmdReLocate
			// 
			this.m_cmdReLocate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdReLocate.DefaultScheme = true;
			this.m_cmdReLocate.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdReLocate.ForeColor = System.Drawing.Color.Black;
			this.m_cmdReLocate.Hint = "";
			this.m_cmdReLocate.Location = new System.Drawing.Point(210, 80);
			this.m_cmdReLocate.Name = "m_cmdReLocate";
			this.m_cmdReLocate.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdReLocate.Size = new System.Drawing.Size(106, 26);
			this.m_cmdReLocate.TabIndex = 10000006;
			this.m_cmdReLocate.Text = "取消";
			this.m_cmdReLocate.Click += new System.EventHandler(this.m_cmdReLocate_Click);
			// 
			// frmReLocate
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(342, 134);
			this.Controls.Add(this.m_cmdReLocate);
			this.Controls.Add(this.m_cmdSubmit);
			this.Controls.Add(this.m_cboPatientBedArea2);
			this.Controls.Add(this.label71);
			this.Controls.Add(this.label70);
			this.Controls.Add(this.label68);
			this.Controls.Add(this.m_cboPatientBedDept2);
			this.Controls.Add(this.label59);
			this.Controls.Add(this.m_cboPatientBedName2);
			this.Controls.Add(this.label58);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReLocate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "重新分配病床";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion
		
		private void m_mthAddPatientSub()
		{
					if(m_cboPatientBedDept2.Text.Trim()=="")
				{
					clsPublicFunction.ShowInformationMessageBox("你还没选择科室。");
						m_cboPatientBedDept2.Focus();
					return;
				 }
				if(m_cboPatientBedArea2.Text.Trim()=="")
				{
					clsPublicFunction.ShowInformationMessageBox("你还没选择病区。");
						 m_cboPatientBedArea2.Focus();
					return;
				}
			
				if(m_cboPatientBedName2.Text.Trim()=="")
				{
					clsPublicFunction.ShowInformationMessageBox("你还没选择病床。");
					 m_cboPatientBedName2.Focus();
					return;
				}
			   	
			
			if(m_objManagerDomain.m_lngRelocate(objPatient.m_StrInPatientID,objPatient.m_DtmLastOutDate.ToString(),((clsDeptInfo_ManageExplorer)m_cboPatientBedDept2.SelectedItem).m_strDeptID ,((clsAreaInfo_ManageExplorer)m_cboPatientBedArea2.SelectedItem).m_strAreaID ,((clsBedInfo)m_cboPatientBedName2.SelectedItem).m_strBedID )<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("无法让病人入院。");
				return ;
			}
			else
			{
				m_lngBedAddPatientToBed2();
				clsPublicFunction.ShowInformationMessageBox("病人已成功入院。");
				return;
			}
		}
		private void m_mthPatientLoadArea(Control p_ctlSender)
		{
			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
			//			if(m_cboPatientBedDept.SelectedItem==null) return;
			clsInPatientArea[] objAreaArr=null;
			this.Cursor=Cursors.WaitCursor;
			if(m_objManagerDomain.m_lngGetAllAreaInDept(((clsDeptInfo_ManageExplorer)m_cboPatientBedDept2.SelectedItem).m_strDeptID,
				out objAreaArr)<=0)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			if(objAreaArr==null)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			cboTemp.ClearItem();
			for(int i=0;i<objAreaArr.Length;i++)
			{
				clsAreaInfo_ManageExplorer objArea=new clsAreaInfo_ManageExplorer();
				objArea.m_strAreaID=objAreaArr[i].m_StrAreaID;
				objArea.m_strAreaName=objAreaArr[i].m_StrAreaName;
				cboTemp.AddItem(objArea);
			}
			this.Cursor=Cursors.Default;
		}

		private void m_cboPatientBedDept2_DropDown(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();
			m_cboPatientBedArea2.ClearItem();


			m_cboPatientBedArea2.SelectedIndex=-1;
			m_cboPatientBedName2.SelectedIndex=-1;
			m_mthPatientLoadDept(m_cboPatientBedDept2);
		}

		private void m_cboPatientBedDept2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();
			m_cboPatientBedArea2.ClearItem();

			m_cboPatientBedArea2.SelectedIndex=-1;
			m_cboPatientBedName2.SelectedIndex=-1;
		}

		private void m_cboPatientBedArea2_DropDown(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();
	
			m_cboPatientBedName2.SelectedIndex=-1;
			m_mthPatientLoadArea(m_cboPatientBedArea2);
		}

		private void m_cboPatientBedArea2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_cboPatientBedName2.ClearItem();

			m_cboPatientBedName2.SelectedIndex=-1;
		}
		private void m_mthPatientLoadBed(Control p_ctlSender)
		{
			ctlComboBox cboBed = p_ctlSender as ctlComboBox;
			ctlComboBox cboArea =  m_cboPatientBedArea2;
			
			if(cboArea.SelectedItem == null)
				return;

			clsInPatientBed[] objBedArr=null;
			clsPatient[] objPatientArr=null;
			this.Cursor=Cursors.WaitCursor;
			if(m_objManagerDomain.m_lngGetAllBedAndPatientInArea(((clsAreaInfo_ManageExplorer)cboArea.SelectedItem).m_strAreaID,
				out objBedArr,out objPatientArr)<=0)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			if(objBedArr==null || objPatientArr==null || objBedArr.Length<objPatientArr.Length)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			cboBed.ClearItem();
			for(int i=0;i<objBedArr.Length;i++)
			{
				if(objPatientArr[i]==null)
				{
					clsBedInfo objBed=new clsBedInfo();
					objBed.m_strBedID=objBedArr[i].m_StrBedID;
					objBed.m_strBedName=objBedArr[i].m_StrBedName;
					cboBed.AddItem(objBed);
				}
			}
			this.Cursor=Cursors.Default;
		}
//		private void m_mthPatientLoadArea(Control p_ctlSender)
//		{
//			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
//			//			if(m_cboPatientBedDept.SelectedItem==null) return;
//			bool blnIsNull = cboTemp.Name == "m_cboPatientBedDept" ? m_cboPatientBedDept.SelectedItem==null : m_cboPatientBedDept2.SelectedItem == null;
//			if(blnIsNull) return;
//			clsInPatientArea[] objAreaArr=null;
//			this.Cursor=Cursors.WaitCursor;
//			if(m_objManagerDomain.m_lngGetAllAreaInDept(((clsDeptInfo_ManageExplorer)m_cboPatientBedDept2.SelectedItem).m_strDeptID,
//				out objAreaArr)<=0)
//			{
//				this.Cursor=Cursors.Default;
//				return;
//			}
//			if(objAreaArr==null)
//			{
//				this.Cursor=Cursors.Default;
//				return;
//			}
//			cboTemp.ClearItem();
//			for(int i=0;i<objAreaArr.Length;i++)
//			{
//				clsAreaInfo_ManageExplorer objArea=new clsAreaInfo_ManageExplorer();
//				objArea.m_strAreaID=objAreaArr[i].m_StrAreaID;
//				objArea.m_strAreaName=objAreaArr[i].m_StrAreaName;
//				cboTemp.AddItem(objArea);
//			}
//			this.Cursor=Cursors.Default;
//		}
		private void m_mthPatientLoadDept(Control p_ctlSender)
		{
			this.Cursor=Cursors.WaitCursor;
			clsDepartment[] objDeptArr=m_objManagerDomain.m_objGetAllInDeptArr();
			if(objDeptArr==null)
			{
				this.Cursor=Cursors.Default;
				return;
			}
			ctlComboBox cboTemp = p_ctlSender as ctlComboBox; //
			//			m_cboPatientBedDept.ClearItem();
			cboTemp.ClearItem();
			for(int i=0;i<objDeptArr.Length;i++)
			{
				clsDeptInfo_ManageExplorer objDept=new clsDeptInfo_ManageExplorer();
				objDept.m_strDeptID=objDeptArr[i].m_StrDeptID;
				objDept.m_strDeptName=objDeptArr[i].m_StrDeptName;
				
				cboTemp.AddItem(objDept);
			}
			this.Cursor=Cursors.Default;
		}

		private void m_cboPatientBedName2_DropDown(object sender, System.EventArgs e)
		{
			m_mthPatientLoadBed((Control)sender);
		}

		private void m_cmdSubmit_Click(object sender, System.EventArgs e)
		{

					m_mthAddPatientSub();
					this.Close();
		}
		private long m_lngBedAddPatientToBed2()
		{
			
			clsDeptAndAreaInfo[] objDeptAndAreaInfoArr=null;
			long lngRes=m_objManagerDomain.m_lngGetAllDeptAndAreaInfoArr(out objDeptAndAreaInfoArr);
			if(lngRes<=0)
			{
				clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
				return lngRes;
			}
			else if(objDeptAndAreaInfoArr==null ) return -1;
			
			clsInDeptInfo objDept=new clsInDeptInfo();
			
			objDept.m_dtmModifyDate=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());
			for(int i1=0;i1<objDeptAndAreaInfoArr.Length;i1++)
			{
				int intIndex = -1;
				for(int j2=0;j2<objDeptAndAreaInfoArr[i1].m_objAreaArr.Length;j2++)
				{
					if (objDeptAndAreaInfoArr[i1].m_objAreaArr[j2].m_StrAreaName == m_cboPatientBedArea2.Text)
					{
						intIndex = j2;
						break;
					}
				}
				if (intIndex != -1)
				{
					objDept.m_strArea_ID=objDeptAndAreaInfoArr[i1].m_objAreaArr[intIndex].m_StrAreaID;
					break;
				}

			}
			for(int i1=0;i1<objDeptAndAreaInfoArr.Length;i1++)
			{
				if (objDeptAndAreaInfoArr[i1].m_objDept.m_StrDeptName == m_cboPatientBedDept2.Text)
				{
					objDept.m_strInDeptID=objDeptAndAreaInfoArr[i1].m_objDept.m_StrDeptID;
					break;
				}
			}
			clsInPatientBed[] objBedArr=null;
			clsPatient[] objPatientArr=null;
			if(m_objManagerDomain.m_lngGetAllBedAndPatientInArea(objDept.m_strArea_ID,out objBedArr,out objPatientArr)<=0)
				return -1;
			if(objBedArr==null || objPatientArr==null || objBedArr.Length<objPatientArr.Length)
				return -1;
			for(int i=0;i<objBedArr.Length;i++)
			{
				if(objPatientArr[i] == null && objBedArr[i].m_StrBedName == m_cboPatientBedName2.Text)
				{
					objDept.m_strBed_ID = objBedArr[i].m_StrBedID;
					break;
				}
			}
			objDept.m_strInPatientID=objPatient.m_StrInPatientID.Trim();
			clsInPatientRoom[] objRoomArr=null;
			lngRes=1;
			lngRes=m_objManagerDomain.m_lngGetAllRoomInArea(objDept.m_strArea_ID,out objRoomArr);
			if(lngRes<=0) return lngRes;
			if(objRoomArr==null||objRoomArr.Length!=1) return (long)enmOperationResult.DB_Fail;
			objDept.m_strRoom_ID=objRoomArr[0].m_StrRoomID;

			lngRes=m_objHandlerDomain.m_lngAssignPatientToBed(objDept);
			if(lngRes<=0) return lngRes;
			return lngRes;
		}
		private void m_cmdReLocate_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	
		private class clsAreaInfo_ManageExplorer
		{
			public string m_strAreaID;
			public string m_strAreaName;
			public override string ToString()

			{
				return m_strAreaName;
			}
		}

		/// <summary>
		/// 记录科室信息
		/// </summary>
		private class clsDeptInfo_ManageExplorer
		{
			public string m_strDeptID;
			public string m_strDeptName;
			public override string ToString()
			{
				return m_strDeptName;
			}
		}

		/// <summary>
		/// 记录病床和在上面的病人的信息
		/// </summary>
		private class clsBedInfo
		{
			public string m_strBedID;
			public string m_strBedName;
			public string m_strBedInPatientID;
			//public string m_strBedInPatientDate;
			public string m_strBedInPatientName;
			public string m_strBedBeginDate;
			public string m_strBedEndDate;
			public clsPatientBaseInfo m_objPatientBaseInfo;
			public override string ToString()
			{
				return m_strBedName;
			}
		}

	}

			
}
