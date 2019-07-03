using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;

using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using HRP;


namespace iCare
{
	/// <summary>
	///  病程记录中特殊记录单的基窗体。
	/// 在此窗体处理保存、修改、删除、作废重做、保留痕迹、双划线功能清空界面的通用逻辑。
	/// 设置病程信息和获取病程信息的通用逻辑。
	/// 打印功能，读取已经删除的记录。
	/// </summary>
	public class frmTabTrackBase : iCare.frmHRPBaseForm,PublicFunction
	{
		protected System.Windows.Forms.TreeView m_trvCreateDate;
		protected System.Windows.Forms.Label lblCreateDateTitle;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		protected System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
		protected System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
		protected System.Drawing.Printing.PrintDocument m_pdtPintDocument;
		protected internal System.Windows.Forms.TabControl m_tabMain;
		protected internal System.Windows.Forms.TabPage tabPage1;
		private System.ComponentModel.IContainer components = null;

		public frmTabTrackBase()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool=new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_trvCreateDate});
			if(m_trvCreateDate.Nodes.Count==0)
				m_trvCreateDate.Nodes.Add("记录时间");
			m_trnRoot=m_trvCreateDate.Nodes[0];

			m_objDiseaseTrackDomain=m_objGetDiseaseTrackDomain();
		}

		// 病程记录的领域层实例
		protected clsDiseaseTrackDomain m_objDiseaseTrackDomain;

		protected clsTrackRecordContent m_objReAddNewOld;

		// 保存当前显示的记录内容的变量
		protected clsTrackRecordContent m_objCurrentRecordContent;

		protected TreeNode m_trnRoot;

		protected clsPatient m_objCurrentPatient;
		

        //protected clsBorderTool m_objBorderTool;

		// 打印报表的内容文档
		protected PrintDocument m_pdcPrintDocument;

		protected DateTime m_dtmFirstPrintDate;

		// 标记是否首次打印
		protected bool m_blnIsFirstPrint;

		protected bool m_blnAlreadySetPrintTools = false;

		/// <summary>
		/// 是否可以触发树节点的选中事件
		/// </summary>
		protected bool m_blnCanTreeNodeAfterSelectEventTakePlace=true; 

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblCreateDateTitle = new System.Windows.Forms.Label();
			this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.m_trvCreateDate = new System.Windows.Forms.TreeView();
			this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
			this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
			this.m_pdtPintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_tabMain = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.m_tabMain.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Location = new System.Drawing.Point(272, 16);
			this.m_lblForTitle.Visible = true;
			// 
			// lblSex
			// 
			this.lblSex.Visible = true;
			// 
			// lblAge
			// 
			this.lblAge.Visible = true;
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Visible = true;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Visible = true;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Visible = true;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Visible = true;
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Visible = true;
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(32, 80);
			this.lblAreaTitle.Visible = true;
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Visible = true;
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Visible = true;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Visible = true;
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Visible = true;
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(80, 76);
			this.m_cboArea.Visible = true;
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Visible = true;
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Visible = true;
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(80, 40);
			this.m_cboDept.Visible = true;
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(32, 48);
			this.lblDept.Visible = true;
			// 
			// lblCreateDateTitle
			// 
			this.lblCreateDateTitle.AutoSize = true;
			this.lblCreateDateTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCreateDateTitle.Location = new System.Drawing.Point(248, 20);
			this.lblCreateDateTitle.Name = "lblCreateDateTitle";
			this.lblCreateDateTitle.Size = new System.Drawing.Size(80, 19);
			this.lblCreateDateTitle.TabIndex = 6068;
			this.lblCreateDateTitle.Text = "记录时间:";
			// 
			// m_dtpCreateDate
			// 
			this.m_dtpCreateDate.BorderColor = System.Drawing.Color.White;
			this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.White;
			this.m_dtpCreateDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpCreateDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpCreateDate.Location = new System.Drawing.Point(328, 16);
			this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpCreateDate.Name = "m_dtpCreateDate";
			this.m_dtpCreateDate.Size = new System.Drawing.Size(208, 26);
			this.m_dtpCreateDate.TabIndex = 11;
			this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.White;
			// 
			// m_trvCreateDate
			// 
			this.m_trvCreateDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_trvCreateDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_trvCreateDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_trvCreateDate.ForeColor = System.Drawing.SystemColors.Window;
			this.m_trvCreateDate.HideSelection = false;
			this.m_trvCreateDate.ImageIndex = -1;
			this.m_trvCreateDate.ItemHeight = 18;
			this.m_trvCreateDate.Location = new System.Drawing.Point(8, 8);
			this.m_trvCreateDate.Name = "m_trvCreateDate";
			this.m_trvCreateDate.SelectedImageIndex = -1;
			this.m_trvCreateDate.Size = new System.Drawing.Size(232, 88);
			this.m_trvCreateDate.TabIndex = 10;
			this.m_trvCreateDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvCreateDate_AfterSelect);
			// 
			// m_cmuRichTextBoxMenu
			// 
			this.m_cmuRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								 this.mniDoubleStrikeOutDelete});
			// 
			// mniDoubleStrikeOutDelete
			// 
			this.mniDoubleStrikeOutDelete.Index = 0;
			this.mniDoubleStrikeOutDelete.Text = "双划线删除";
			this.mniDoubleStrikeOutDelete.Click += new System.EventHandler(this.mniDoubleStrikeOutDelete_Click);
			// 
			// m_pdtPintDocument
			// 
			this.m_pdtPintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdtPintDocument_BeginPrint);
			this.m_pdtPintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdtPintDocument_EndPrint);
			this.m_pdtPintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdtPintDocument_PrintPage);
			// 
			// m_tabMain
			// 
			this.m_tabMain.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tabPage1});
			this.m_tabMain.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_tabMain.Location = new System.Drawing.Point(16, 132);
			this.m_tabMain.Name = "m_tabMain";
			this.m_tabMain.SelectedIndex = 0;
			this.m_tabMain.Size = new System.Drawing.Size(972, 168);
			this.m_tabMain.TabIndex = 10000000;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.m_trvCreateDate,
																				   this.lblCreateDateTitle,
																				   this.m_dtpCreateDate});
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(964, 139);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// frmTabTrackBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1016, 741);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_cboDept,
																		  this.lblDept,
																		  this.m_lsvInPatientID,
																		  this.m_lsvPatientName,
																		  this.m_lsvBedNO,
																		  this.m_cboArea,
																		  this.m_txtBedNO,
																		  this.m_txtPatientName,
																		  this.lblSex,
																		  this.lblAge,
																		  this.lblBedNoTitle,
																		  this.lblInHospitalNoTitle,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblAgeTitle,
																		  this.lblAreaTitle,
																		  this.txtInPatientID,
																		  this.m_lblForTitle,
																		  this.m_tabMain});
			this.Name = "frmTabTrackBase";
			this.m_tabMain.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion		

		#region DataControl
		public void Save()
		{			
			this.m_lngSave();
		}
		
		public void Delete()
		{
			m_lngDelete();
		}
		public void Display(){}
		public void Display(string strInPatientID,string strInPatientDate)
		{
		}
		public void Print()
		{		
			this.m_lngPrint();				
		}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		#endregion

		/// <summary>
		/// 获取当前表单状态
		/// </summary>
		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser;
			}
		}
		/// <summary>
		/// 获取当前的特殊病程记录信息
		/// </summary>
		/// <returns></returns>
		public virtual clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
		{
			//获取当前的特殊病程记录信息，由子窗体重载实现
			return null;
		}

		public void m_mthSetDiseaseTrackInfoForAddNew(clsPatient p_objPatient)
		{
			//参数检查  
			if(p_objPatient==null)
				return;
			
			m_mthSetPatient(p_objPatient);

			m_mthEnablePatientSelect(false);
		}

		/// <summary>
		/// 设置病程记录信息，并显示修改。
		/// </summary>
		/// <param name="p_objPatient"></param>
		/// <param name="p_dtmRecordTime"></param>
		public void m_mthSetDiseaseTrackInfo(clsPatient p_objPatient,
			DateTime p_dtmRecordTime)
		{
			//参数检查  
			if(p_objPatient==null)
				return;
			
			m_mthSetPatient(p_objPatient);

			//设置记录信息
			m_mthSetSelectedRecord(p_objPatient,p_dtmRecordTime.ToString("yyyy-MM-dd HH:mm:ss"));    
		                        
			//不允许用户修改记录的基本信息                        
			m_mthEnablePatientSelect(false);
		}

		public void m_mthSetDeletedDiseaseTrackInfo(clsPatient p_objPatient,
			DateTime p_dtmRecordTime)
		{
			//参数检查  
			if(p_objPatient==null)
				return;
			
			m_mthSetPatient(p_objPatient);

			//设置记录信息
			m_mthSetSelectedDeletedRecord(p_objPatient,p_dtmRecordTime.ToString("yyyy-MM-dd HH:mm:ss"));    
		   
			m_mthEnablePatientSelect(false);

			//			m_mthEnablePatientSelectSub(false);
		}

		/// <summary>
		/// 清空界面
		/// </summary>
		protected void m_mthClearAll()
		{
			//清空病人基本信息            
			m_mthClearPatientBaseInfo();
			//清空时间列表树
			m_trnRoot.Nodes.Clear();
		
			//重置当前病人变量
			m_objCurrentPatient = null;
		
			//清空当前记录。
			m_mthClearPatientRecordInfo();
		}

		/// <summary>
		/// 清空病人记录所有信息。
		/// </summary>
		protected void m_mthClearPatientRecordInfo()
		{
			//把记录时间恢复到当前时间      
			m_dtpCreateDate.Value=DateTime.Now;

			m_mthEnableModify(true);

			m_mthSetModifyControl(null,true);
		                       
			//清空记录内容                       
			m_mthClearRecordInfo();
		
			//清空保存当前记录的变量
			m_objCurrentRecordContent = null;        
		
			//清空（重置）辅助信息 
			m_objReAddNewOld = null;
		}

		/// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected virtual void m_mthClearRecordInfo()
		{
			//清空具体记录内容，由子窗体重载实现
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected void m_mthEnablePatientSelect(bool p_blnEnable)
		{
			//设置病人选择信息的 Enable = p_blnEnable
			if(p_blnEnable==false)
			{				
				m_lblForTitle.Visible=false;
				lblAreaTitle.Visible=false;
				m_cboArea.Visible= false;
				lblBedNoTitle.Visible=false;
				m_txtBedNO.Visible= false;
				lblNameTitle.Visible=false;
				m_txtPatientName.Visible=false;
				lblInHospitalNoTitle.Visible=false;
				txtInPatientID.Visible=false;
				m_trvCreateDate.Visible=false;
				lblSexTitle.Visible=false;
				lblSex.Visible=false;
				lblAgeTitle.Visible=false;
				lblAge.Visible=false;
                //m_objBorderTool.m_mthUnChangedControlBorder(m_trvCreateDate);			
		
				m_cboArea.Enabled= p_blnEnable;
				m_txtBedNO.ReadOnly= !p_blnEnable;
				m_txtPatientName.ReadOnly=!p_blnEnable;
				txtInPatientID.ReadOnly=!p_blnEnable;			
		
				//设置时间列表树的 Enable = p_blnEnable			
				m_trvCreateDate.Enabled=p_blnEnable;	

			}

		
			m_mthEnablePatientSelectSub(p_blnEnable); 
		}

		/// <summary>
		/// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected virtual void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
		
		}

		/// <summary>
		/// 是否允许修改记录时间等记录信息。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected void m_mthEnableModify(bool p_blnEnable)
		{
			//设置记录时间的 Enable = p_blnEnable
			m_dtpCreateDate.Enabled=p_blnEnable;		

			//设置具体记录的特殊控制
			m_mthEnableModifySub(p_blnEnable);
		}

		/// <summary>
		/// 是否允许修改特殊记录的记录信息。
		/// </summary>
		/// <param name="p_blnEnable"></param>
		protected virtual void m_mthEnableModifySub(bool p_blnEnable)
		{
			//具体记录的特殊控制,根据子窗体的需要重载实现
		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(clsTrackRecordContent p_objRecordContent,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_blnReset==true)
			{
				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);
			}
			else if(p_objRecordContent!=null)
			{
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID));
			}

			m_mthSetModifyControlSub(p_objRecordContent,p_blnReset);
		}

		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
		/// </summary>
		/// <returns></returns>
		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}

		protected virtual void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
			bool p_blnReset)
		{

		}


		/// <summary>
		/// 设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			//判断病人信息是否为null，如果是，直接返回。
			if(p_objSelectedPatient == null)
				return;   	
		
			//清空病人记录信息
			m_mthClearPatientRecordInfo();
		
			//记录病人信息
			m_objCurrentPatient = p_objSelectedPatient;
		
			//清空时间列表树的时间节点     
			m_trnRoot.Nodes.Clear();

			//获取病人记录列表
			string [] strCreateTimeListArr;
			string [] strOpenTimeListArr;
			long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordTimeList(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strCreateTimeListArr, out strOpenTimeListArr);
		
			if(lngRes <= 0 || strCreateTimeListArr == null|| strOpenTimeListArr==null || strOpenTimeListArr.Length !=strCreateTimeListArr.Length)
				return; 		
		
			//添加查询到的时间到时间树上 
			for(int i=strCreateTimeListArr.Length-1;i>=0;i--)
			{
				TreeNode trnRecordDate = new TreeNode(strCreateTimeListArr[i]);
				trnRecordDate.Tag=strOpenTimeListArr[i];
				m_trnRoot.Nodes.Add(trnRecordDate);
			}
		
			//展开树显示所有时间节点。
			m_trnRoot.Expand();
		}

		/// <summary>
		/// 从界面获取特殊记录的值。如果界面值出错，返回null。
		/// </summary>
		/// <returns></returns>
		protected virtual clsTrackRecordContent m_objGetContentFromGUI()
		{
			//从界面获取表单值，由子窗体重载实现			
			return null;
		}

		/// <summary>
		/// 把特殊记录的值显示到界面上。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected virtual void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
		{
			//把表单值赋值到界面，由子窗体重载实现
		}

		protected virtual void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
		{
			//把表单值赋值到界面，由子窗体重载实现
		}	

		/// <summary>
		/// 设置选择了的记录信息。
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		/// <param name="p_strOpenDate"></param>
		protected void m_mthSetSelectedRecord(clsPatient p_objSelectedPatient,
			string p_strOpenDate)
		{
			//检查参数
			if(p_objSelectedPatient==null|| p_strOpenDate==null ||p_strOpenDate=="")
				return;
		              
			clsTrackRecordContent objContent;              
			//获取记录
			long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);
		
			if(lngRes <= 0 || objContent == null)
				return;
            
           
			//设置当前记录及记录时间 
			m_objCurrentPatient=  p_objSelectedPatient;
			txtInPatientID.Text=this.m_objCurrentPatient.m_StrHISInPatientID;
			m_dtpCreateDate.Value=objContent.m_dtmCreateDate;
			m_objCurrentRecordContent=objContent;
		
			m_mthSetGUIFromContent(objContent);
		
			m_mthEnableModify(false);
		
			m_mthSetModifyControl(objContent,false);
		

		}

		protected void m_mthSetSelectedDeletedRecord(clsPatient p_objSelectedPatient,
			string p_strOpenDate)
		{
			//检查参数
			if(p_objSelectedPatient==null|| p_strOpenDate==null ||p_strOpenDate=="")
				return;
		              
			clsTrackRecordContent objContent;              
			//获取记录
//			long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);
			long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(p_objSelectedPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);
		
			if(lngRes <= 0 || objContent == null)
				return;
            
           
			//设置当前记录及记录时间 
			m_objCurrentPatient=  p_objSelectedPatient;
			txtInPatientID.Text=this.m_objCurrentPatient.m_StrHISInPatientID;
			//			m_dtpCreateDate.Value=objContent.m_dtmCreateDate;

			//这一句如果不注释的话，m_BlnIsAddNew就会变成true了，那么就不是新添记录了
			//			m_objCurrentRecordContent=objContent;
		
			m_mthSetDeletedGUIFromContent(objContent);
		
			//			m_mthSetModifyControl(objContent,false);		

		}


		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected virtual clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
		{
			//获取病程记录的领域层实例，由子窗体重载实现			
			return null;
		}

		/// <summary>
		/// 是否新添加记录。true，新添加；false，修改。
		/// </summary>
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_objCurrentRecordContent == null;
			}		
		}

		protected override long m_lngSubAddNew()
		{
			if(m_objReAddNewOld != null)
				return m_lngReAddNew();
			else  
				return m_lngAddNewRecord();	

		}

		/// <summary>
		/// 添加新记录的数据库保存。
		/// </summary>
		/// <returns></returns>
		protected long m_lngAddNewRecord()
		{
			//检查当前病人变量是否为null
			if(m_objCurrentPatient==null)
			{
				m_mthShowNoPatient();
				return -1;
			}

			//获取服务器时间
			string strTimeNow=new clsPublicDomain().m_strGetServerTime();
		
			//从界面获取记录信息
			clsTrackRecordContent objContent = m_objGetContentFromGUI();     
		           
			//界面输入值出错           
			if(objContent == null)
				return -1;
		
			//设置 clsTrackRecordContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
			objContent.m_dtmOpenDate=DateTime.Parse(strTimeNow);
			objContent.m_dtmModifyDate=DateTime.Parse(strTimeNow);

			objContent.m_bytIfConfirm=0;
			objContent.m_bytStatus=0;
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate;
			objContent.m_strConfirmReason="";
			objContent.m_strConfirmReasonXML="";
			objContent.m_strCreateUserID=MDIParent.OperatorID;
			objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			objContent.m_strModifyUserID=MDIParent.OperatorID;

			//保存记录
			clsPreModifyInfo objModifyInfo=null;
			long lngRes = m_objDiseaseTrackDomain.m_lngAddNewRecord(objContent,out objModifyInfo);
		        
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecordContent = objContent;           
					
					//添加节点到时间列表树,并选中
					m_mthAddNode(m_objCurrentRecordContent.m_dtmCreateDate,m_objCurrentRecordContent.m_dtmOpenDate);
					break; 
 
				case enmOperationResult.DB_Fail:
					clsPublicFunction.ShowInformationMessageBox("对不起,添加失败!");
					break;
				case enmOperationResult.Parameter_Error:
					clsPublicFunction.ShowInformationMessageBox("参数错误!");
					break;
				case enmOperationResult.Record_Already_Exist:
					m_mthShowRecordTimeDouble();
					break;					
					//...
			}  
		
			//返回结果
			return lngRes;			
		}

		/// <summary>
		/// 添加节点到时间列表树,并选中
		/// </summary>
		/// <param name="strTime"></param>
		private void m_mthAddNode(DateTime p_dtmCreateDate,DateTime p_dtmOpenDate)
		{ 
			string strCreateDate=p_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");			
			TreeNode trnNode=new TreeNode(strCreateDate);	
			trnNode.Tag=p_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

			m_blnCanTreeNodeAfterSelectEventTakePlace=false;

			if(m_trnRoot.Nodes.Count==0 || trnNode.Text.CompareTo (m_trnRoot.LastNode.Text)<0)
			{
				m_trnRoot.Nodes.Add(trnNode);
				m_trvCreateDate.SelectedNode=m_trnRoot.LastNode;//
			}
			else 
			{
				for(int i=0;i<m_trnRoot.Nodes.Count;i++)
				{
					if(trnNode.Text.CompareTo (m_trnRoot.Nodes[i].Text)>0)
					{
						m_trnRoot.Nodes.Insert(i,trnNode);
						m_trvCreateDate.SelectedNode=m_trnRoot.Nodes[i];//
						break;
					}
				}
			}	
			m_blnCanTreeNodeAfterSelectEventTakePlace=true;
			m_dtpCreateDate.Enabled=false;
		}

		protected override long m_lngSubModify()
		{
			//检查当前病人变量是否为null
			if(m_objCurrentPatient==null)
			{
				m_mthShowNoPatient();
				return -1;
			}
			//获取服务器时间
			string strTimeNow=new clsPublicDomain().m_strGetServerTime();
			//从界面获取记录信息
			clsTrackRecordContent objContent = m_objGetContentFromGUI();     
		           
			//界面输入值出错           
			if(objContent == null)
				return -1;
		
			//设置 clsTrackRecordContent 的信息（使用服务器时间设置m_dtmModifyDate）			
			objContent.m_dtmModifyDate=DateTime.Parse(strTimeNow);
			//设置已有记录的开始使用时间
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate;   
			objContent.m_bytIfConfirm=0;
			objContent.m_bytStatus=0;
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate;
			objContent.m_strConfirmReason="";
			objContent.m_strConfirmReasonXML="";
			objContent.m_strCreateUserID=m_objCurrentRecordContent.m_strCreateUserID;
			objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			objContent.m_strModifyUserID=MDIParent.OperatorID;

			//修改记录
			clsPreModifyInfo objModifyInfo=null;
			long lngRes = m_objDiseaseTrackDomain.m_lngModifyRecord(m_objCurrentRecordContent,objContent,out objModifyInfo);
		        
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecordContent = objContent;
					break; 
				case enmOperationResult.DB_Fail:
					clsPublicFunction.ShowInformationMessageBox("对不起,修改失败!");
					break;
				case enmOperationResult.Parameter_Error:
					clsPublicFunction.ShowInformationMessageBox("参数错误!");
					break;
				case enmOperationResult.Record_Already_Modify:
					if(objModifyInfo !=null)
						m_bolShowRecordModified(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;	
				case enmOperationResult.Record_Already_Delete:
					if(objModifyInfo !=null)
						m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;
					//...
			}  
		
			//返回结果
			return lngRes;
		}

		protected override long m_lngSubDelete()
		{
			//检查当前病人变量是否为null          
			if(m_objCurrentPatient==null)
			{
				m_mthShowNoPatient();
				return -1;
			}
			//检查当前记录是否为null
			if(m_objCurrentRecordContent==null)
			{				
				return -1;
			}
		
			//获取服务器时间      
			string strTimeNow=new clsPublicDomain().m_strGetServerTime();
			//设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
			m_objCurrentRecordContent.m_dtmDeActivedDate=DateTime.Parse(strTimeNow);
			m_objCurrentRecordContent.m_strDeActivedOperatorID=MDIParent.OperatorID;
			
			//删除记录
			clsPreModifyInfo objModifyInfo=null;
			long lngRes = m_objDiseaseTrackDomain.m_lngDeleteRecord(m_objCurrentRecordContent,out objModifyInfo);
		
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecordContent = null;       
					
					m_blnCanTreeNodeAfterSelectEventTakePlace=false;
					//删除选中节点 
					m_trvCreateDate.SelectedNode.Remove();
					//清空记录信息   
					m_mthClearPatientRecordInfo();
					//选中根节点
					m_trvCreateDate.SelectedNode=m_trnRoot;
					m_blnCanTreeNodeAfterSelectEventTakePlace=true;
					break;   
				case enmOperationResult.DB_Fail:
					clsPublicFunction.ShowInformationMessageBox("对不起,删除失败!");
					break;
				case enmOperationResult.Parameter_Error:
					clsPublicFunction.ShowInformationMessageBox("参数错误!");
					break;
				case enmOperationResult.Record_Already_Modify:
					if(objModifyInfo !=null)
						m_bolShowRecordModified(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;	
				case enmOperationResult.Record_Already_Delete:
					if(objModifyInfo !=null)
						m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;
			}  
		
			//返回结果
			return lngRes;
		}

		protected void m_mthUseReAddNew(clsPatient p_objSelectedPatient,
			string p_strOpenDate)
		{
			//检查参数
			if(p_objSelectedPatient==null)
			{
				m_mthShowNoPatient();
				return;
			}			
			if(p_strOpenDate==null || p_strOpenDate=="")
			{	
				clsPublicFunction.ShowInformationMessageBox("请选择要作废的记录对应的记录时间!");
				return;
			}
         
			clsTrackRecordContent objContent;              
			//获取记录
			long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);
		
			if(lngRes <= 0 || objContent == null)
				return;          
			                               
			m_objReAddNewOld = objContent;	                               
			m_objCurrentRecordContent = null;         
		
			//设置时间,并使之不能修改
			m_dtpCreateDate.Enabled=false;
		
			m_mthReAddNewRecord(objContent);
			

		}

		/// <summary>
		/// 把选择时间记录内容重新整理为完全正确的内容。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		protected virtual void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
		}

		/// <summary>
		/// 作废重做的数据库保存。
		/// </summary>
		/// <returns></returns>
		protected long m_lngReAddNew()
		{
			//检查当前病人变量是否为null
			if(m_objCurrentPatient==null)
			{
				m_mthShowNoPatient();
				return -1;
			}
			//获取服务器时间
			string strTimeNow=new clsPublicDomain().m_strGetServerTime();
			//从界面获取记录信息
			clsTrackRecordContent objContent = m_objGetContentFromGUI();     
		           
			//界面输入值出错           
			if(objContent == null)
				return -1;
		
			//设置 clsTrackRecordContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
			objContent.m_dtmOpenDate=DateTime.Parse(strTimeNow);
			objContent.m_dtmModifyDate=DateTime.Parse(strTimeNow);
			objContent.m_bytIfConfirm=0;
			objContent.m_bytStatus=0;
			objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate;
			objContent.m_strConfirmReason="";
			objContent.m_strConfirmReasonXML="";
			objContent.m_strCreateUserID=MDIParent.OperatorID;
			objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			objContent.m_strModifyUserID=MDIParent.OperatorID;

			//作废重做记录
			clsPreModifyInfo objModifyInfo=null;
			long lngRes = m_objDiseaseTrackDomain.m_lngReAddNewRecord(m_objReAddNewOld,objContent,out objModifyInfo);
		        
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
					m_objCurrentRecordContent = objContent;  
					m_objReAddNewOld = null;
					break;
				case enmOperationResult.DB_Fail:
					clsPublicFunction.ShowInformationMessageBox("对不起,修改失败!");
					break;
				case enmOperationResult.Parameter_Error:
					clsPublicFunction.ShowInformationMessageBox("参数错误!");
					break;
				case enmOperationResult.Record_Already_Modify:
					if(objModifyInfo !=null)
						m_bolShowRecordModified(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;	
				case enmOperationResult.Record_Already_Delete:
					if(objModifyInfo !=null)
						m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;
					//...
			}  
		
			//返回结果
			return lngRes;

		}

		#region ctlRichTextBox的双划线、其他属性设置
		/// <summary>
		/// 设置双划线
		/// </summary>
		protected void m_mthSetRichTextBoxDoubleStrike()
		{
			//获取RichTextBox        
			//ctlRichTextBox objRichTextBox = (ctlRichTextBox)m_ctmRichTextBoxMenu.SourceControl;
		
			//objRichTextBox.m_mthSelectionDoubleStrikeThough(true);
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);			
		}

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(ctlRichTextBox p_objRichTextBox)
		{
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_objRichTextBox });
			//设置右键菜单			
//			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
			p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
			
			//设置其他属性			
			p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
			p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
			p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
			p_objRichTextBox.m_ClrDST = Color.Red;
		}

		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((ctlRichTextBox)p_ctlControl);
			}

			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextBoxAttribInControl(subcontrol);						
				} 	
			}	
		}
		private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			m_mthSetRichTextBoxDoubleStrike();
		}
		private ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((ctlRichTextBox)(sender));
		}

		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")			
				((ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;				
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}						
			#endregion			
		}
		
		
		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{				
				((ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}	
		#endregion ctlRichTextBox的双划线、其他属性设置


		#region 打印
		private void m_pdtPintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthPrintPage(e);
		}

		private void m_pdtPintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_mthBeginPrint(e);
		}

		private void m_pdtPintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_mthEndPrint(e);
		}	

		protected override long m_lngSubPrint()
		{
			//检查是否有打印内容，如果有，打印有内容报表，否则打印空报表——空报表不赋值。
			if(m_objCurrentRecordContent != null)
			{
				//检查内容是否最新，获取最新内容和首次打印时间   
				clsTrackRecordContent objNewTrackInfo; 
				long lngRes = m_objDiseaseTrackDomain.m_lngGetPrintInfo(m_objCurrentRecordContent.m_strInPatientID,m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objCurrentRecordContent.m_dtmModifyDate,out objNewTrackInfo,out m_dtmFirstPrintDate,out m_blnIsFirstPrint);
				if(lngRes <= 0)
					return lngRes;  
			
				//如果以有内容是最新内容，把当前内容记录到objNewTrackInfo中
				if(objNewTrackInfo == null)
				{
					objNewTrackInfo = m_objCurrentRecordContent;
				}
			
				//设置表单内容到打印中
				m_mthSetPrintContent(objNewTrackInfo,m_dtmFirstPrintDate);
			}       
		
			//如果没有设置过打印变量，设置打印变量        
			if(!m_blnAlreadySetPrintTools)
			{
				m_mthInitPrintTool();
				m_blnAlreadySetPrintTools = true;
			}                     
		
			//开始打印
			m_mthStartPrint();
		
			return 1;
		}

		/// <summary>
		///  设置打印内容。
		/// </summary>
		/// <param name="p_objContent"></param>
		protected virtual void m_mthSetPrintContent(clsTrackRecordContent p_objContent,DateTime p_dtmFirstPrintDate)
		{
			//缺省不做任何动作，子窗体重载以提供操作。
		}

		/// <summary>
		/// 初始化打印变量
		/// </summary>
		protected virtual void m_mthInitPrintTool()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
		}

		/// <summary>
		/// 释放打印变量
		/// </summary>
		protected virtual void m_mthDisposePrintTools()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
		}

		/// <summary>
		/// 开始打印。
		/// </summary>
		protected virtual void m_mthStartPrint()
		{
			//缺省使用打印预览，子窗体重载提供新的实现
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

		/// <summary>
		/// 打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected void m_mthBeginPrint(PrintEventArgs p_objPrintArg)
		{
			m_mthBeginPrintSub(p_objPrintArg);
		}

		/// <summary>
		/// 打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected virtual void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected void m_mthPrintPage(PrintPageEventArgs p_objPrintPageArg)
		{
			m_mthPrintPageSub(p_objPrintPageArg);
		}

		/// <summary>
		/// 打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected virtual void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
		
		}

		/// <summary>
		/// 打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected void m_mthEndPrint(PrintEventArgs p_objPrintArg)
		{
			//如果打印成功，并且不是打印空报表，并且需要更新首次打印时间，更新首次打印时间。
			if(!p_objPrintArg.Cancel)
			{
				m_mthUpdateFirstPrintDate();
			}                          
		
			m_mthEndPrintSub(p_objPrintArg);
		}

		protected void m_mthUpdateFirstPrintDate()
		{
			if(m_objCurrentRecordContent != null && m_blnIsFirstPrint)
			{
				m_objDiseaseTrackDomain.m_lngUpdateFirstPrintDate(m_objCurrentRecordContent.m_strInPatientID,m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),m_dtmFirstPrintDate);
				m_blnIsFirstPrint = false;
			}
		}

		/// <summary>
		/// 打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected virtual void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			//由子窗体重载以提供操作
		}

		#endregion 打印

		// 显示已经删除的记录让用户选择，并把用户选择的内容重新整理为完全正确的内容，显示在界面。
		protected void m_mthLoadDeleteRecord()
		{
			//			frmSelectDeleteRecord frmSel = new frmSelectDeleteRecord(m_objDomain,m_objCurrentPatient,m_strReloadFormTitle(),MDIParent.OperatorID);
			//		
			//			if(frmSel.ShowDialog() == DialogResult.OK)
			//			{   
			//			
			//				clsTrackRecordContent objContent = frmSel.m_objGetDeleteRecord();              
			//			
			//				if(objContent == null)
			//					return;   
			//				         
			//				//提示会覆盖当前内容
			//				//如果用户不覆盖
			//				//return;
			//		              
			//				m_mthClearPatientRecordInfo();                     
			//			                             
			//				m_mthReAddNewRecord(objContent);
			//			}
		}

		// 获取选择已经删除记录的窗体标题
		public virtual string m_strReloadFormTitle()
		{
			//由子窗体重载实现
			return "";
		}

		private void m_trvCreateDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(m_blnCanTreeNodeAfterSelectEventTakePlace==false)
				return;

			m_mthClearPatientRecordInfo();
			if(m_trvCreateDate.SelectedNode==m_trnRoot)
			{
				m_mthSelectRootNode();
				return;
			}
			else if(m_trvCreateDate.SelectedNode.Tag !=null)
				m_mthSetSelectedRecord(m_objCurrentPatient,m_trvCreateDate.SelectedNode.Tag.ToString());
		}
		
		/// <summary>
		/// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
		/// </summary>
		protected virtual void m_mthSelectRootNode()
		{
		}
	}
}

