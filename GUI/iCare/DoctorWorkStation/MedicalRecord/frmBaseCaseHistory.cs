using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using iCareData;
using HRP;
using com.digitalwave.Utility.Controls;
//using com.digitalwave.controls;
using System.Drawing.Printing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
	public class frmBaseCaseHistory : frmHRPBaseForm,PublicFunction
	{
		private System.ComponentModel.IContainer components = null;

		public frmBaseCaseHistory()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明表单类型为医生工作站
            intFormType = 1;
			// TODO: Add any initialization after the InitializeComponent call
			m_objDomain = m_objGetDomain();
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlBorder(trvTime);

			m_blnCanTreeAfterSelect = true;
			
		}

		public PinkieControls.ButtonXP m_cmdCreateID;

		protected bool m_blnCanTreeAfterSelect;

		// 病程记录的领域层实例
		protected clsBaseCaseHistoryDomain m_objDomain;

		protected clsInPatientCaseHistoryContent m_objReAddNewOld;

		// 保存当前显示的记录内容的变量
		protected clsInPatientCaseHistoryContent m_objCurrentRecordContent;

		protected TreeNode m_trnRoot;

		protected clsPatient m_objCurrentPatient;

        //protected clsBorderTool m_objBorderTool;

		// 打印报表的内容文档
		//		protected PrintDocument m_pdcPrintDocument;

		protected DateTime m_dtmFirstPrintDate;

		// 标记是否首次打印
		protected bool m_blnIsFirstPrint;
		public System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
		private System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
		public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		public System.Windows.Forms.Label lblCreateDate;
		protected System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		public System.Windows.Forms.Label lblNativePlace;
		public System.Windows.Forms.Label m_lblNativePlace;
		public System.Windows.Forms.Label lblOccupation;
		public System.Windows.Forms.Label m_lblOccupation;
		public System.Windows.Forms.Label m_lblMarriaged;
		public System.Windows.Forms.Label lblMarriaged;
		public System.Windows.Forms.Label m_lblCreateUserName;
		public System.Windows.Forms.Label m_lblLinkMan;
		public System.Windows.Forms.Label lblLinkMan;
		public System.Windows.Forms.Label lblAddress;
        public System.Windows.Forms.Label m_lblAddress;
        protected Label lblNation;
        protected Label m_lblNation;

		protected bool m_blnAlreadySetPrintTools = false;


		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.trvTime = new System.Windows.Forms.TreeView();
            this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblCreateDate = new System.Windows.Forms.Label();
            this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.lblNativePlace = new System.Windows.Forms.Label();
            this.m_lblNativePlace = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.m_lblOccupation = new System.Windows.Forms.Label();
            this.m_lblMarriaged = new System.Windows.Forms.Label();
            this.lblMarriaged = new System.Windows.Forms.Label();
            this.m_lblCreateUserName = new System.Windows.Forms.Label();
            this.m_lblLinkMan = new System.Windows.Forms.Label();
            this.lblLinkMan = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.m_lblAddress = new System.Windows.Forms.Label();
            this.m_cmdCreateID = new PinkieControls.ButtonXP();
            this.lblNation = new System.Windows.Forms.Label();
            this.m_lblNation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(616, 57);
            this.lblSex.Size = new System.Drawing.Size(34, 19);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(700, 57);
            this.lblAge.Size = new System.Drawing.Size(36, 19);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(405, 20);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(390, 57);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(572, 18);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(572, 57);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(654, 57);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(212, 57);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(452, 74);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(76, 104);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(452, 55);
            this.txtInPatientID.Size = new System.Drawing.Size(76, 23);
            this.txtInPatientID.TabIndex = 3;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(622, 18);
            this.m_txtPatientName.Size = new System.Drawing.Size(112, 23);
            this.m_txtPatientName.TabIndex = 2;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(452, 16);
            this.m_txtBedNO.Size = new System.Drawing.Size(76, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(262, 53);
            this.m_cboArea.Size = new System.Drawing.Size(126, 23);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(622, 42);
            this.m_lsvPatientName.Size = new System.Drawing.Size(98, 104);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(452, 38);
            this.m_lsvBedNO.Size = new System.Drawing.Size(76, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(262, 14);
            this.m_cboDept.Size = new System.Drawing.Size(126, 23);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(212, 14);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(682, 298);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(528, 18);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(618, 14);
            this.m_lblForTitle.Visible = true;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.SystemColors.Window;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(20, 14);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(182, 62);
            this.trvTime.TabIndex = 4;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
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
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(166, 88);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(222, 22);
            this.m_dtpCreateDate.TabIndex = 5;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.AutoSize = true;
            this.lblCreateDate.Font = new System.Drawing.Font("宋体", 10.5F);
            this.lblCreateDate.Location = new System.Drawing.Point(86, 92);
            this.lblCreateDate.Name = "lblCreateDate";
            this.lblCreateDate.Size = new System.Drawing.Size(70, 14);
            this.lblCreateDate.TabIndex = 532;
            this.lblCreateDate.Text = "记录日期:";
            // 
            // m_pdcPrintDocument
            // 
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.AutoSize = true;
            this.lblNativePlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNativePlace.Location = new System.Drawing.Point(402, 152);
            this.lblNativePlace.Name = "lblNativePlace";
            this.lblNativePlace.Size = new System.Drawing.Size(42, 14);
            this.lblNativePlace.TabIndex = 543;
            this.lblNativePlace.Text = "籍贯:";
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblNativePlace.Location = new System.Drawing.Point(452, 151);
            this.m_lblNativePlace.Name = "m_lblNativePlace";
            this.m_lblNativePlace.Size = new System.Drawing.Size(76, 20);
            this.m_lblNativePlace.TabIndex = 542;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOccupation.Location = new System.Drawing.Point(114, 122);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(42, 14);
            this.lblOccupation.TabIndex = 541;
            this.lblOccupation.Text = "职业:";
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblOccupation.Location = new System.Drawing.Point(162, 121);
            this.m_lblOccupation.Name = "m_lblOccupation";
            this.m_lblOccupation.Size = new System.Drawing.Size(226, 20);
            this.m_lblOccupation.TabIndex = 545;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblMarriaged.Location = new System.Drawing.Point(452, 121);
            this.m_lblMarriaged.Name = "m_lblMarriaged";
            this.m_lblMarriaged.Size = new System.Drawing.Size(76, 20);
            this.m_lblMarriaged.TabIndex = 544;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.AutoSize = true;
            this.lblMarriaged.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMarriaged.Location = new System.Drawing.Point(402, 122);
            this.lblMarriaged.Name = "lblMarriaged";
            this.lblMarriaged.Size = new System.Drawing.Size(42, 14);
            this.lblMarriaged.TabIndex = 535;
            this.lblMarriaged.Text = "婚否:";
            // 
            // m_lblCreateUserName
            // 
            this.m_lblCreateUserName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblCreateUserName.Location = new System.Drawing.Point(622, 151);
            this.m_lblCreateUserName.Name = "m_lblCreateUserName";
            this.m_lblCreateUserName.Size = new System.Drawing.Size(88, 20);
            this.m_lblCreateUserName.TabIndex = 536;
            this.m_lblCreateUserName.Visible = false;
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblLinkMan.Location = new System.Drawing.Point(452, 90);
            this.m_lblLinkMan.Name = "m_lblLinkMan";
            this.m_lblLinkMan.Size = new System.Drawing.Size(76, 20);
            this.m_lblLinkMan.TabIndex = 539;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.AutoSize = true;
            this.lblLinkMan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLinkMan.Location = new System.Drawing.Point(390, 91);
            this.lblLinkMan.Name = "lblLinkMan";
            this.lblLinkMan.Size = new System.Drawing.Size(56, 14);
            this.lblLinkMan.TabIndex = 540;
            this.lblLinkMan.Text = "联系人:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAddress.Location = new System.Drawing.Point(114, 152);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.TabIndex = 537;
            this.lblAddress.Text = "地址:";
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblAddress.Location = new System.Drawing.Point(162, 151);
            this.m_lblAddress.Name = "m_lblAddress";
            this.m_lblAddress.Size = new System.Drawing.Size(226, 20);
            this.m_lblAddress.TabIndex = 538;
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdCreateID.DefaultScheme = true;
            this.m_cmdCreateID.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCreateID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCreateID.Hint = "";
            this.m_cmdCreateID.Location = new System.Drawing.Point(529, 143);
            this.m_cmdCreateID.Name = "m_cmdCreateID";
            this.m_cmdCreateID.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCreateID.Size = new System.Drawing.Size(84, 28);
            this.m_cmdCreateID.TabIndex = 10000080;
            this.m_cmdCreateID.Tag = "1";
            this.m_cmdCreateID.Text = "病史记录者:";
            // 
            // lblNation
            // 
            this.lblNation.AutoSize = true;
            this.lblNation.Location = new System.Drawing.Point(522, 96);
            this.lblNation.Name = "lblNation";
            this.lblNation.Size = new System.Drawing.Size(42, 14);
            this.lblNation.TabIndex = 10000081;
            this.lblNation.Text = "民族:";
            // 
            // m_lblNation
            // 
            this.m_lblNation.Location = new System.Drawing.Point(564, 96);
            this.m_lblNation.Name = "m_lblNation";
            this.m_lblNation.Size = new System.Drawing.Size(30, 14);
            this.m_lblNation.TabIndex = 10000082;
            // 
            // frmBaseCaseHistory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(792, 673);
            this.Controls.Add(this.lblNativePlace);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.lblMarriaged);
            this.Controls.Add(this.lblLinkMan);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblNation);
            this.Controls.Add(this.m_lblNation);
            this.Controls.Add(this.lblCreateDate);
            this.Controls.Add(this.m_cmdCreateID);
            this.Controls.Add(this.m_lblNativePlace);
            this.Controls.Add(this.m_lblOccupation);
            this.Controls.Add(this.m_lblMarriaged);
            this.Controls.Add(this.m_lblCreateUserName);
            this.Controls.Add(this.m_lblLinkMan);
            this.Controls.Add(this.m_lblAddress);
            this.Controls.Add(this.m_dtpCreateDate);
            this.Controls.Add(this.trvTime);
            this.Name = "frmBaseCaseHistory";
            this.Load += new System.EventHandler(this.frmBaseCaseHistory_Load);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
            this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
            this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
            this.Controls.SetChildIndex(this.m_lblOccupation, 0);
            this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
            this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
            this.Controls.SetChildIndex(this.lblCreateDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lblNation, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblNation, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.lblLinkMan, 0);
            this.Controls.SetChildIndex(this.lblMarriaged, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblNativePlace, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

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

				m_objDomain= null;
				m_objReAddNewOld = null;
				m_objCurrentRecordContent = null;
				m_objCurrentPatient = null;
                //m_objBorderTool = null;
			}
			base.Dispose( disposing );
		}
		// 获取选择已经删除记录的窗体标题
		public virtual void m_strReloadFormTitle()
		{
			//由子窗体重载实现
		}

		// 清空界面
		protected void m_mthClearAll()
		{
			//清空病人基本信息          
			base.m_mthClearPatientBaseInfo();
		
			//清空时间列表树
            //if(this.trvTime .Nodes[0].Nodes.Count >0)
            //    trvTime.Nodes[0].Nodes.Clear();
		
			//重置当前病人变量
			m_objCurrentPatient = null;
		
			//清空当前记录。
			m_mthClearPatientRecordInfo();
		}

		// 清空病人记录所有信息。
		protected void m_mthClearPatientRecordInfo()
		{
			//把记录时间恢复到当前时间      
			
			m_mthEnableModify(true);
		                       
			//清空记录内容                       
			m_mthClearRecordInfo();
		
			//清空保存当前记录的变量
			m_objCurrentRecordContent = null;        
		
			//清空（重置）辅助信息 
			m_objReAddNewOld = null;

			m_mthSetModifyControl(null,true);
			
		}

		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected virtual void m_mthClearRecordInfo()
		{
			this.m_dtpCreateDate.Text =DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");  
			//清空具体记录内容，由子窗体重载实现

			//			m_mthSetModifyControl(null,true);
		}

		// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		protected void m_mthEnablePatientSelect(bool p_blnEnable)
		{
			//设置病人选择信息的 Enable = p_blnEnable
		
			//设置时间列表树的 Enable = p_blnEnable
		
			//设置记录时间的 Enable = p_blnEnable              
		
			m_mthEnablePatientSelectSub(p_blnEnable) ;
		}

		// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
		protected virtual void m_mthEnablePatientSelectSub(bool p_blnEnable)
		{
		
		}

		// 是否允许修改记录时间等记录信息。
		protected void m_mthEnableModify(bool p_blnEnable)
		{
			//设置记录时间的 Enable = p_blnEnable
			
			//设置具体记录的特殊控制
			m_mthEnableModifySub(p_blnEnable);
		}

		// 是否允许修改特殊记录的记录信息。
		protected virtual void m_mthEnableModifySub(bool p_blnEnable)
		{
			//具体记录的特殊控制,根据子窗体的需要重载实现
			if(p_blnEnable)
			{
				this.m_dtpCreateDate.Enabled =true;

			}
			else
			{
				this.m_dtpCreateDate.Enabled =false;
			}

		}

		#region Alex mark 2003-5-16
		//		// 设置是否控制修改（修改留痕迹）。
		//		protected virtual void m_mthSetModifyControl(clsInPatientCaseHistoryContent p_objRecordContent,
		//			bool p_blnReset)
		//		{
		//			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
		//		}
		#endregion

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(clsInPatientCaseHistoryContent p_objRecordContent,
			bool p_blnReset)
		{
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_blnReset==true)
			{
				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);
			}
			else if(p_objRecordContent!=null)
			{
                bool blnTemp = m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID.Trim());
				m_mthSetRichTextModifyColor(this,Color.Red);
                m_mthSetRichTextCanModifyLast(this, blnTemp);
			}

			m_mthSetModifyControlSub(p_objRecordContent,p_blnReset);
		}

		protected virtual void m_mthSetModifyControlSub(clsInPatientCaseHistoryContent p_objRecordContent,
			bool p_blnReset)
		{

		}
        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            clsPeopleInfo objInfo = p_objSelectedPatient.m_ObjPeopleInfo;
            //lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrSex;
            //lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrAge;


            this.m_lblAddress.Text = objInfo.m_StrHomeAddress;
            this.m_lblLinkMan.Text = objInfo.m_StrLinkManFirstName;
            this.m_lblMarriaged.Text = objInfo.m_StrMarried;
            this.m_lblOccupation.Text = objInfo.m_StrOccupation;
            this.m_lblNation.Text = objInfo.m_StrNation;
            this.m_lblNativePlace.Text = objInfo.m_StrNativePlace; 
        }
		// 设置病人表单信息
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{

			//判断病人信息是否为null，如果是，直接返回。
			if(p_objSelectedPatient == null)
				return;   	
		
			//清空病人记录信息
			m_mthClearPatientRecordInfo();
		
			//记录病人信息
			m_objCurrentPatient =p_objSelectedPatient;
            //m_mthOnlySetPatientInfo(p_objSelectedPatient);
            //this.m_lblAddress .Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeAddress;
            //this.m_lblLinkMan.Text =m_objCurrentPatient.m_ObjPeopleInfo.m_StrLinkManFirstName;
            //this.m_lblMarriaged.Text =m_objCurrentPatient.m_ObjPeopleInfo.m_StrMarried;
            //this.m_lblOccupation.Text =m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;
            //this.m_lblNation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrNation;
            ////			this.m_lblCreateUserName.Text =MDIParent.strOperatorName;
            ////籍贯
            //this.m_lblNativePlace.Text =m_objCurrentPatient.m_ObjPeopleInfo.m_StrNativePlace; 

			//获取病人记录列表
            //string [] strInPatientDateListArr=null;
            //string [] strCreateTimeListArr=null;
            //string [] strOpenTimeListArr=null;
            //long lngRes = m_objDomain.m_lngGetRecordTimeList(p_objSelectedPatient.m_StrInPatientID,out strInPatientDateListArr, out strCreateTimeListArr,out strOpenTimeListArr);
		
			//			if(lngRes <= 0 || strOpenTimeListArr == null || strCreateTimeListArr==null)
			//				return;  
            //if(lngRes <= 0 )
            //    return;

			//清空时间列表树的时间节点   
            //if(trvTime.Nodes[0].Nodes.Count >0)
            //    trvTime.Nodes[0].Nodes.Clear();

            ////添加查询到的入院时间到时间树上
            ////			if(strCreateTimeListArr!=null)
            ////			{
            //for(int i=p_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount()-1;i>=0;i--)
            //{			
            //    TreeNode trnRecordDate = new TreeNode(p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss"));
            //    if(strOpenTimeListArr!=null)
            //    {
            //        for(int j2=0;j2<strInPatientDateListArr.Length;j2++)
            //        {
            //            if (DateTime.Parse(strInPatientDateListArr[j2]) == p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i).m_DtmEMRInDate)
            //            {
            //                trnRecordDate.Tag =(string)strOpenTimeListArr[j2];
            //                break;
            //            }
            //        }
            //    }
            //    trvTime.Nodes[0].Nodes.Add(trnRecordDate);	
            //    trvTime.ExpandAll();	
            //}			

            ////选中默认节点
            //for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
            //{
            //    if(trvTime.Nodes[0].Nodes[i].Text == p_objSelectedPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss"))
            //        trvTime.SelectedNode = trvTime.Nodes[0].Nodes[i];
            //}
            //if(trvTime.Nodes[0].Nodes.Count>0 && (trvTime.SelectedNode==null || trvTime.SelectedNode.Text.Length==4))//本处需要此句调用默然选中树节点事件				
            //    trvTime.SelectedNode=trvTime.Nodes[0].Nodes[0];

            //if(!m_dtpCreateDate.Enabled)
            //    m_EnmFormEditStatus = MDIParent.enmFormEditStatus.Modify;

			//			}

			//展开树显示所有时间节点
			//			trvTime.ExpandAll();
		
			//			//添加查询到的时间到时间树上 
			//			if(strCreateTimeListArr!=null)
			//			{
			//				for(int i=0;i<strCreateTimeListArr.Length;i++)
			//				{
			//					TreeNode trnRecordDate = new TreeNode(strCreateTimeListArr[i]);
			//					trnRecordDate.Tag =(string)strOpenTimeListArr[i];
			//					trvTime.Nodes[0].Nodes .Add(trnRecordDate);
			//
			//				}
			//			}
			//			//展开树显示所有时间节点。
			
			
		}

		// 从界面获取特殊记录的值。如果界面值出错，返回null。
		protected virtual clsInPatientCaseHistoryContent m_objGetContentFromGUI()
		{
			//重界面获取表单值，由子窗体重载实现
			return null;
		}
        //获取记录创建者，删除记录时判断是否有权限删除
        protected virtual clsInPatientCaseHistoryContent m_objGetCreateUserFromGUI()
        {
            //重界面获取表单值，由子窗体重载实现
            return null;
        }
		protected virtual clsPictureBoxValue[] m_objGetPicContentFromGUI()
		{
			//重界面获取表单值，由子窗体重载实现
			return null;
		}

		// 把特殊记录的值显示到界面上。
		protected virtual void m_mthSetGUIFromContent(clsInPatientCaseHistoryContent p_objContent,clsPictureBoxValue[] p_objPicValueArr)
		{
			//把表单值赋值到界面，由子窗体重载实现
			this.m_dtpCreateDate.Text =p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");   

		}

		// 设置选择了的记录信息。
		protected void m_mthSetSelectedRecord(clsPatient p_objPatient)
		{
			//检查参数
			if(p_objPatient==null /*|| p_strRecordTime==null || p_strRecordTime==""*/)  
			{
				m_objCurrentRecordContent = null;
				return ;
			}

			clsBaseCaseHistoryInfo  objContent =null;  
			clsPictureBoxValue[] objPicValueArr = null;
			//获取记录
			//			long lngRes = m_objDomain.m_lngGetRecordContent(p_objPatient.m_StrInPatientID ,p_objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate .ToString("yyyy-MM-dd HH:mm:ss") ,/*p_strRecordTime ,*/ out objContent,out objPicValueArr);
            long lngRes = m_objDomain.m_lngGetRecordContent(p_objPatient.m_StrInPatientID, p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),/*p_strRecordTime ,*/ out objContent, out objPicValueArr);
		
			if(lngRes <= 0 || objContent == null)
			{
				m_objCurrentRecordContent = null;
				return;                            
			}
			
			//设置记录时间     
			m_objCurrentRecordContent =(clsInPatientCaseHistoryContent )objContent;

            m_dtmCreatedDate = m_objCurrentRecordContent.m_dtmOpenDate;
			m_mthSetGUIFromContent((clsInPatientCaseHistoryContent )objContent,objPicValueArr);
			this.m_dtpCreateDate.Text =((clsInPatientCaseHistoryContent )objContent).m_dtmCreateDate.ToString("yyyy年MM月dd日 HH:mm:ss"); 
			this.m_lblCreateUserName.Text=m_objCurrentRecordContent.m_strCreateName;
			m_mthEnableModify(false);
		
			//			m_mthSetModifyControl((clsInPatientCaseHistoryContent )objContent,true);
			m_mthSetModifyControl((clsInPatientCaseHistoryContent)objContent,false);//Alex 2003-5-16			

		}

		// 获取病程记录的领域层实例
		protected virtual clsBaseCaseHistoryDomain m_objGetDomain()
		{
			//获取病程记录的领域层实例，由子窗体重载实现
			return null;
		}

		// 是否新添加记录。true，新添加；false，修改。
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return m_objCurrentRecordContent == null;
			}
		
		}
		/// <summary>
		/// 添加记录
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubAddNew()
		{
            long lngRes = 0;
			if(m_objReAddNewOld != null)
                lngRes = m_lngReAddNew();
			else
                lngRes = m_lngAddNewRecord();

            if (lngRes > 0 && com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strTECHNICALRANK_CHR == "见习医师")
            {
                clsEMR_CaseAuditVO objAuditVO = m_objGetAuditCase();
                objAuditVO.m_dtmCREATEDATE = m_objCurrentRecordContent.m_dtmOpenDate;
                m_mthAddAuditCase(objAuditVO);
            }
            return lngRes;
		}

		private string m_strGetTemplateSetID()
		{
			foreach(Control ctlSub in this.Controls)
			{
				if(ctlSub.Name=="m_lstTemplate" && ctlSub.Tag!=null)
					return ctlSub.Tag.ToString();
			}
			return "";
		}

		// 添加新记录的数据库保存。
		protected long m_lngAddNewRecord()
		{

			//检查当前病人变量是否为null
			if(m_objCurrentPatient==null )
				return (long)enmOperationResult .Parameter_Error;
 
//            if(trvTime.SelectedNode == null || trvTime.SelectedNode.Equals(trvTime.Nodes[0]))
//            {
//#if !Debug
//                clsPublicFunction.ShowInformationMessageBox("请选择病人入院日期。");
//#endif
//                return -7;
//            }

            if (m_ObjCurrentEmrPatientSession == null)
            {
#if !Debug
				clsPublicFunction.ShowInformationMessageBox("请选择病人入院日期。");
#endif
				return -7;
            }

			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			
			//从界面获取记录信息
			clsInPatientCaseHistoryContent  objContent = m_objGetContentFromGUI();     
		           
			//获取画图信息
			clsPictureBoxValue [] objPicValueArr = m_objGetPicContentFromGUI();

			string strDiseaseID = new clsTemplateDomain().m_strGetAssociateIDBySetID(m_strGetTemplateSetID(),(int)enmAssociate.Disease);

			//界面输入值出错
			if(objContent == null)
				return (long)enmOperationResult.Parameter_Error;
					
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
			objContent.m_bytIfConfirm =0;
			objContent.m_bytStatus =0;
			objContent.m_dtmInPatientDate =m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmModifyDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			objContent.m_dtmOpenDate =DateTime.Parse( m_objPDomain.m_strGetServerTime()); 
			//objContent.m_strCreateUserID =MDIParent.strOperatorID;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strModifyUserID =objContent.m_strModifyUserID;
			objContent.m_dtmCreateDate=DateTime.Parse(this.m_dtpCreateDate.Text );
			 
			//保存记录
			clsPreModifyInfo p_objModifyInfo=null;

            #region 多签名时验证所有签名者 并保存

                //数字签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" + objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); ;
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            if (objContent.objSignerArr != null)
            {
                ArrayList objSignerArr = new ArrayList();
                for (int i = 0; i < objContent.objSignerArr.Length; i++)
                {
                    if (objContent.objSignerArr[i].controlName == "lsvSign" || objContent.objSignerArr[i].controlName == "txtSign")
                        objSignerArr.Add(objContent.objSignerArr[i].objEmployee);
                }
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(objContent, objSign_VO) == -1)
                    return -1;
            }
            else
            {
                objContent.m_strModifyUserID = MDIParent.OperatorID;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                    return -1;
            }
            #endregion	


           
			long lngRes = m_objDomain.m_lngAddNewRecord(objContent,objPicValueArr,strDiseaseID,out p_objModifyInfo);
		     
			//根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    //保存体格检查内容
                    //					lngRes = m_lngSubAddNewRecordAfterMain(objContent);

                    m_objCurrentRecordContent = objContent;
                    m_dtmCreatedDate = objContent.m_dtmOpenDate;

                    m_mthHandleAddRecordSucceed();

                    this.m_dtpCreateDate.Enabled = false;
                    break;
                //...
                case enmOperationResult.Record_Already_Exist:
                    m_mthShowRecordTimeDouble();
                    return lngRes;
            }  
            //this.trvTime.ExpandAll(); 
			//返回结果
			return lngRes;
		}

		protected virtual long m_lngSubAddNewRecordAfterMain(clsInPatientCaseHistoryContent p_objNewContent)
		{
			return (long)enmOperationResult.DB_Succeed;
		}

		protected virtual void m_mthHandleAddRecordSucceed()
		{
			//添加节点到时间列表树,并选中
            //TreeNode tndNewNode=new TreeNode();
            //tndNewNode.Text =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss")  ;
            //tndNewNode.Tag =(string)m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") ;
            //this.trvTime.Nodes[0].Nodes.Add(tndNewNode);  
            //m_blnCanTreeAfterSelect = false;
            //this.trvTime.SelectedNode =tndNewNode;				
            //m_blnCanTreeAfterSelect = true;
		}

		protected override long m_lngSubModify()
		{
			//窗体只读。
			//检查当前病人变量是否为null
			if(m_objCurrentPatient ==null)
				return (long)enmOperationResult .Parameter_Error ;
			//获取服务器时间
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			//从界面获取记录信息
			clsInPatientCaseHistoryContent  objContent = m_objGetContentFromGUI();     

			//获取画图信息
			clsPictureBoxValue [] objPicValueArr = m_objGetPicContentFromGUI();

			//获取病名
			string strDiseaseID = new clsTemplateDomain().m_strGetAssociateIDBySetID(m_strGetTemplateSetID(),(int)enmAssociate.Disease);
		           
			//界面输入值出错           
			if(objContent == null)
				return (long)enmOperationResult .Parameter_Error;
		
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmModifyDate）
			objContent.m_bytIfConfirm =0;
			objContent.m_bytStatus =0;
			objContent.m_dtmInPatientDate =m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmModifyDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			objContent.m_dtmCreateDate=DateTime.Parse(this.m_dtpCreateDate.Text );
			objContent.m_strCreateUserID =MDIParent.strOperatorID;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strModifyUserID =objContent.m_strModifyUserID;

			//设置已有记录的开始使用时间
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate ;  //m_objCurrentRecordContent为点击某个记录时间的记录即当前记录
		
			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20

                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" + objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                return -1;

			//修改记录
			clsPreModifyInfo m_objModifyInfo;
			long lngRes = m_objDomain.m_lngModifyRecord(m_objCurrentRecordContent,objContent,objPicValueArr,strDiseaseID,out m_objModifyInfo);
		        
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:

                    m_objCurrentRecordContent = objContent;
                    m_dtmCreatedDate = objContent.m_dtmOpenDate;
					break;   
					//...
			}  
			//展开树显示所有时间节点。
			//			trvTime.ExpandAll();
			//返回结果
			return lngRes;
		}		

		protected virtual long m_lngSubModifyRecordAfterMain(clsInPatientCaseHistoryContent p_objNewContent)
		{
			return (long)enmOperationResult.DB_Succeed;
		}

		protected override long m_lngSubDelete()
		{
			//检查当前病人变量是否为null  
			if(m_objCurrentPatient ==null || m_ObjCurrentEmrPatientSession == null)
			{
				clsPublicFunction.ShowInformationMessageBox("未选定病人,无法删除!");//崔汉瑜，2003-5-27
				return (long)enmOperationResult.Parameter_Error; 
			}
			//检查当前记录是否为null
			if(m_objCurrentRecordContent==null)
			{
				clsPublicFunction.ShowInformationMessageBox("当前记录内容为空,无法删除!");//崔汉瑜，2003-5-27
				return (long)enmOperationResult.Parameter_Error; 
			}
			//获取服务器时间      
			clsPublicDomain m_objPDomain=new clsPublicDomain() ;
			
			//删除记录
            clsInPatientCaseHistoryContent objContent = m_objGetContentFromGUI();
            //clsInPatientCaseHistoryContent objContent = new clsInPatientCaseHistoryContent();
			objContent.m_bytStatus =0;
			objContent.m_dtmCreateDate=DateTime.Parse(this.m_dtpCreateDate.Text );
			objContent.m_dtmInPatientDate =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate;
			objContent.m_strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
			objContent.m_strDeActivedOperatorID =MDIParent.OperatorID ;
			objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate ;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strDeptId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, objContent.m_strCreateUserID.Trim(), clsEMRLogin.LoginEmployee, 1);
            if (!blnIsAllow)
                return -1;
			
			//设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
			objContent.m_dtmDeActivedDate =DateTime.Parse(m_objPDomain.m_strGetServerTime()); 
			
			clsPreModifyInfo m_objModifyInfo=null;

			long lngRes = m_objDomain.m_lngDeleteRecord(objContent,out m_objModifyInfo);
		
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
                case enmOperationResult.DB_Succeed:
                    clsEMR_CaseAuditVO objAuditVO = m_objGetAuditCase();
                    objAuditVO.m_dtmCREATEDATE = m_objCurrentRecordContent.m_dtmOpenDate;
                    m_mthDelAuditCase(objAuditVO);
					//清空记录信息  
                    m_objCurrentRecordContent = null;
                    m_dtmCreatedDate = DateTime.Now;   
					m_mthClearPatientRecordInfo();
					//选中根节点
					m_blnCanTreeAfterSelect = false;
					//					this.trvTime.SelectedNode =this.trvTime.Nodes[0];
					m_mthUnEnableRichTextBox();  
					m_blnCanTreeAfterSelect = true;
					break;   
					//...
			}  
		
			//返回结果
			return lngRes;
		}

		protected void m_mthUseReAddNew(clsPatient p_objPatient,string p_strRecordTime)
		{
			//检查参数
			if(p_objPatient==null || p_strRecordTime=="")
				return ;
 
			clsBaseCaseHistoryInfo  objContent=null;     
			clsPictureBoxValue[] objPicValueArr = null;
			//获取记录
            long lngRes = m_objDomain.m_lngGetRecordContent(p_objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_StrEMRInPatientID, p_objPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd hh:mm:ss"),/*p_strRecordTime,*/   out objContent, out objPicValueArr);
		
			if(lngRes <= 0 || objContent == null)
				return;          
			                               
			m_objReAddNewOld = (clsInPatientCaseHistoryContent )objContent;	                               
			m_objCurrentRecordContent = null;         
		
			//设置时间,并使之不能修改
		
			m_mthReAddNewRecord((clsInPatientCaseHistoryContent )objContent);
			

		}

		// 把选择时间记录内容重新整理为完全正确的内容。
		protected virtual void m_mthReAddNewRecord(clsInPatientCaseHistoryContent p_objRecordContent)
		{
			//把选择时间记录内容重新整理为完全正确的内容，有子窗体重载实现。
		}

		// 作废重做的数据库保存。
		protected long m_lngReAddNew()
		{
			//检查当前病人变量是否为null
		
			//获取服务器时间
		
			//从界面获取记录信息
			clsInPatientCaseHistoryContent objContent = m_objGetContentFromGUI();     
		           
			//界面输入值出错           
			if(objContent == null)
				return -1;
		
			//设置 clsInPatientCaseHistoryContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
		
			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" + objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                return -1;
			//作废重做记录
			clsPreModifyInfo m_objModifyInfo=null;
			long lngRes = m_objDomain.m_lngReAddNewRecord(m_objReAddNewOld,objContent,out m_objModifyInfo);
			
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
                    m_objCurrentRecordContent = objContent;
                    m_dtmCreatedDate = objContent.m_dtmOpenDate;
					m_objReAddNewOld = null;
					break;   
					//...
			}  
		
			//返回结果
			return lngRes;

		}

		// 设置双划线
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
			{
				if(m_txtFocusedRichTextBox is com.digitalwave.Utility.Controls.ctlRichTextBox)
					((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtFocusedRichTextBox).m_mthSelectionDoubleStrikeThough(true);	
				else if(m_txtFocusedRichTextBox is com.digitalwave.controls.ctlRichTextBox)
					((com.digitalwave.controls.ctlRichTextBox)m_txtFocusedRichTextBox).m_mthSelectionDoubleStrikeThough(true);
			}
		}

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(Control p_objRichTextBox)
		{
			if(p_objRichTextBox is com.digitalwave.Utility.Controls.ctlRichTextBox)
			{
                //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	(com.digitalwave.Utility.Controls.ctlRichTextBox)p_objRichTextBox });
				//设置右键菜单			
				//			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_objRichTextBox).GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
			
				//设置其他属性			
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = MDIParent.strOperatorID.Trim();
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = MDIParent.strOperatorName.Trim();
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_objRichTextBox).m_ClrOldPartInsertText = Color.Black;
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_objRichTextBox).m_ClrDST = Color.Red;
			}
			else if(p_objRichTextBox is com.digitalwave.controls.ctlRichTextBox)
			{
                //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	(com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox });
				//设置右键菜单			
				//			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
				((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
			
				//设置其他属性			
				((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = MDIParent.strOperatorID.Trim();
				((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = MDIParent.strOperatorName.Trim();
				((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_ClrOldPartInsertText = Color.Black;
				((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_ClrDST = Color.Red;
			}
		}

		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().FullName=="com.digitalwave.controls.ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
			}
			else if(p_ctlControl.GetType().FullName=="com.digitalwave.Utility.Controls.ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl);
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
		private Control m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((Control)(sender));		
		}
		#endregion ctlRichTextBox的双划线、其他属性设置
		
		// 打印

		#region 外部打印				
		protected virtual void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);

			if(ppdPrintPreview != null)
				while(!ppdPrintPreview.m_blnHandlePrint(e))
					objPrintTool.m_mthPrintPage(e);
		}

		protected virtual void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthBeginPrint(e);				
		}

		protected virtual void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			objPrintTool.m_mthEndPrint(e);
		}

		protected infPrintRecord objPrintTool;
		private void m_mthPrint_FromDataSource()
		{
            if (clsEMRLogin.m_StrCurrentHospitalNO == "440104001")//市一
			{
                objPrintTool = new clsInPatientCaseHistoryPrintTool();
			}
            else if (clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
            {
                objPrintTool = new clsInPatientCaseHistory_GXPrintTool();
            }
            else//其他
            {
                objPrintTool = new clsInPatientCaseHistory_F2PrintTool();
            }
			objPrintTool.m_mthInitPrintTool(null);
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,DateTime.MinValue,DateTime.MinValue);
            else if (m_objCurrentRecordContent == null)//(this.trvTime.SelectedNode ==null || this.trvTime.SelectedNode==trvTime.Nodes[0] || trvTime.SelectedNode.Tag==null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate, DateTime.MinValue);
			else
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,
                    m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate,
                    m_objCurrentRecordContent.m_dtmOpenDate);
			//				objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient,m_objBaseCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate,DateTime.Parse(trvTime.SelectedNode.Tag.ToString()));
												
			objPrintTool.m_mthInitPrintContent();					
			
								
			m_mthStartPrint();
		}				
		#endregion 外部打印

		protected override long m_lngSubPrint()
		{
			m_mthPrint_FromDataSource();
			return 1;

			//			/*如果没有设置过打印变量，设置打印变量
			//			 * 设置打印变量的时候会在m_mthInitPrintTool里面将m_objPrintContext赋值，所以打印完之后应
			//			 * 将m_blnAlreadySetPrintTools设为false
			//			 */       
			//			if(!m_blnAlreadySetPrintTools)
			//			{
			//				m_mthInitPrintTool();
			//				m_blnAlreadySetPrintTools = true;
			//			}  		
			//
			//			//检查是否有打印内容，如果有，打印有内容报表，否则打印空报表——空报表不赋值。
			//			if(m_objCurrentRecordContent != null)
			//			{	
			//
			//				//检查内容是否最新，获取最新内容和首次打印时间   
			//				clsBaseCaseHistoryInfo  objNewCaseInfo; 
			//				long lngRes = m_objDomain.m_lngGetPrintInfo(m_objCurrentRecordContent.m_strInPatientID,m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss")  ,m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objCurrentRecordContent.m_dtmModifyDate,out objNewCaseInfo,out m_dtmFirstPrintDate,out m_blnIsFirstPrint);
			//				if(lngRes <= 0)
			//					return lngRes;  
			//			
			//				//如果没有内容是最新内容，把当前内容记录到objNewTrackInfo中
			//				if(objNewCaseInfo == null)
			//				{
			//					objNewCaseInfo = m_objCurrentRecordContent;
			//				}
			//		
			//				//设置表单内容到打印中
			//				m_mthSetPrintContent((clsInPatientCaseHistoryContent )objNewCaseInfo,m_dtmFirstPrintDate);
			//			}  
			//				
			//			//开始打印
			//			m_mthStartPrint();
			//		
			//			return 1;
		}

		// 设置打印内容。
		protected virtual void m_mthSetPrintContent(clsInPatientCaseHistoryContent p_objContent,DateTime p_dtmFirstPrintDate)
		{
			//缺省不做任何动作，子窗体重载以提供操作。
		}

		// 初始化打印变量
		protected virtual void m_mthInitPrintTool()
		{
			
			//缺省不做任何动作，子窗体重载以提供操作
			//初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
		}

		// 释放打印变量
		protected virtual void m_mthDisposePrintTools()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
		}

		// 开始打印。
		protected PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
		//		private PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
		protected virtual void m_mthStartPrint()
		{
			//缺省使用打印预览，子窗体重载提供新的实现
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

		// 打印开始后，在打印页之前的操作
		protected void m_mthBeginPrint(PrintEventArgs p_objPrintArg)
		{
			m_mthBeginPrintSub(p_objPrintArg);
		}

		// 打印开始后，在打印页之前的操作
		protected virtual void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		// 打印页
		protected void m_mthPrintPage(PrintPageEventArgs p_objPrintPageArg)
		{
			m_mthPrintPageSub(p_objPrintPageArg);
		}

		// 打印页
		protected virtual void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
		
		}

		// 打印结束时的操作
		protected void m_mthEndPrint(PrintEventArgs p_objPrintArg)
		{
			//如果打印成功，并且不是打印空报表，并且需要更新首次打印时间，更新首次打印时间。
			if(!p_objPrintArg.Cancel && m_objCurrentRecordContent != null && m_blnIsFirstPrint)
			{
				m_objDomain.m_lngUpdateFirstPrintDate(m_objCurrentRecordContent.m_strInPatientID,m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss")  ,m_dtmFirstPrintDate);
				m_blnIsFirstPrint = false;
			}                          
		
			m_mthEndPrintSub(p_objPrintArg);
		}

		// 打印结束时的操作
		protected virtual void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			//由子窗体重载以提供操作
		}

		// 显示已经删除的记录让用户选择，并把用户选择的内容重新整理为完全正确的内容，显示在界面。
		protected void m_mthLoadDeleteRecord()
		{
			//			frmSelectDeleteRecord frmSel = new frmSelectDeleteRecord(m_objDomain,m_objCurrentPatient,m_strReloadFormTitle(),MDIParent.OperatorID);
			//		
			//			if(frmSel.ShowDialog() == DialogResult.OK)
			//			{   
			//			
			//				clsInPatientCaseHistoryContent objContent = frmSel.m_objGetDeleteRecord();              
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

		public void Copy()
		{
			m_lngCopy();
		}

		public void Cut()
		{
			m_lngCut();
		}
		public void Verify()
		{
			try
			{
				//检查当前病人变量是否为null 
				if(m_objCurrentPatient == null)
				{
					clsPublicFunction.ShowInformationMessageBox("未选定病人,无法验证!");
				}
				string strInPatientID =m_objCurrentPatient.m_StrInPatientID ;
				string strInPatientDate =m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
				string strRecordID=strInPatientID.Trim()+"-"+strInPatientDate;
				long lngRes=m_lngSignVerify(this.Name.Trim(),strRecordID);
			}
			catch (Exception exp)
			{ 
				MessageBox.Show("签名验证出现异常："+exp.Message,"Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
 			
		}
		public void Delete()
        {
            if (m_blnReadOnly)
            {
                clsPublicFunction.ShowInformationMessageBox("此病历为只读，不能删除！");
                return;
            }
            //指明表单类型为医生工作站
            //intFormType = 1;
			long m_lngRe=m_lngDelete(); 
			if(m_lngRe>0)

			{
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                //if(this.trvTime.SelectedNode!=null)
                //{
                //    this.trvTime_AfterSelect(this.trvTime,new TreeViewEventArgs(this.trvTime.SelectedNode));
                //}
			}

		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			m_lngPaste();
		}

		public void Print()
		{
			m_lngPrint(); 
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			long m_lngRe=m_lngSave(); 
			if(m_lngRe==99)
			{
				return;
			}
			if(m_lngRe>0)
			{
                //if(this.trvTime.SelectedNode!=null)
                //{
                //    m_blnNeedCheckArchive = false;
                //    this.trvTime_AfterSelect(this.trvTime,new TreeViewEventArgs(this.trvTime.SelectedNode));
                //    m_blnNeedCheckArchive = true;
                //}
                m_blnNeedCheckArchive = false;
                m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
                m_blnNeedCheckArchive = true;
				clsPublicFunction.ShowInformationMessageBox("保存成功！");
			}
			else
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
		}


		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}		
		public void Undo()
		{
		
		}

		protected virtual void m_mthUnEnableRichTextBox()
		{
		}

		protected virtual void m_mthEnableRichTextBox()
		{
		}


		protected virtual void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(!m_blnCanTreeAfterSelect)
				return;

			m_mthRecordChangedToSave();

			try
            {
                DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text);

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;
                //DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text);
                //m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmInDate;
                //m_objCurrentPatient.m_DtmSelectedInDate = dtmInDate;
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_objCurrentPatient.m_ObjPeopleInfo = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_ObjPeopleInfo;

                DateTime dtmEMRInDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_DtmEMRInDate;
                string strEMRInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrEMRInPatientID;

                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(trvTime.SelectedNode.Text);
                if (dtmEMRInDate != new DateTime(1900, 1, 1))
                {
                    m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                    m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                }
                if (string.IsNullOrEmpty(m_objBaseCurrentPatient.m_StrRegisterId))
                {
                    string strRegisterID = string.Empty;
                    long lngRes = new clsPublicDomain().m_lngGetRegisterID(m_objCurrentPatient.m_StrPatientID, Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;

                }

//				MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate = dtmInDate;
				m_mthClearRecordInfo();
                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				m_mthEnableRichTextBox();
			
                //m_mthSetSelectedRecord(m_objCurrentPatient,(string)this.trvTime.SelectedNode.Tag );
				if(m_objCurrentRecordContent!=null)
				{
					this.m_dtpCreateDate.Enabled=false;

					//当前处于修改记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
				}
				else
				{
					m_mthSetNewRecord();
					//当前处于新增记录状态
					MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
				}
			}
			catch (Exception exp)
			{
				string strtemp=exp.Message;
				m_mthClearRecordInfo();

				m_mthUnEnableRichTextBox();

				m_objCurrentRecordContent =null;
				m_mthEnableModify(true);
				this.m_dtpCreateDate.Enabled =true;
				this.m_dtpCreateDate.Text =DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");  
				
				m_mthSetNullPrintContext();

				//当前处于禁止输入状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.None );
			}
			finally
			{
				m_mthDoAfterSelect();
				m_mthAddFormStatusForClosingSave();
			}
		}

		/// <summary>
		/// 处理新添记录
		/// </summary>
		protected virtual void m_mthSetNewRecord()
		{
		}

		protected virtual void m_mthSetNullPrintContext()
		{
		}

		private void frmBaseCaseHistory_Load(object sender, System.EventArgs e)
		{
			//			m_mthSetRichTextBoxAttribInControl(this);

		}

		
		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		protected void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")			
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}						
			#endregion			
		}
		
		
		protected void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().FullName;			
			if(strTypeName=="com.digitalwave.Utility.Controls.ctlRichTextBox")
			{				
				((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			else if(strTypeName=="com.digitalwave.controls.ctlRichTextBox")
			{
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="System.Windows.Forms.DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}			
		/// <summary>
		/// 输入框内，内容颜色的设置方法
		/// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
		/// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
		/// </summary>
		/// <returns></returns>
		protected bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}

		/// <summary>
		/// 选择树节点后的操作
		/// </summary>
		protected virtual void m_mthDoAfterSelect()
		{
			return;
		}

        /// <summary>
        /// 重写获取记录创建者属性
        /// 返回指定记录创建者ID
        /// </summary>
        protected override string m_StrRecorder_ID
        {
            get
            {
                clsInPatientCaseHistoryContent objContent = m_objGetCreateUserFromGUI();//m_objGetContentFromGUI();
                return objContent.m_strCreateUserID.Trim();
            }
        }
		/// <summary>
		/// 提供子窗体的手动资源释放
		/// </summary>
//		protected override void m_mthReleaseSub()
//		{
//			if(m_objBorderTool != null)
////				m_objBorderTool.m_mthClear();
//			base.m_mthReleaseSub();
//		}
        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null)
            {
                return;
            }

            if (!m_blnCanTreeAfterSelect)
                return;

            m_mthRecordChangedToSave();

            try
            {               
                string strEMRInPatientID = p_objSelectedSession.m_strEMRInpatientId;

                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

                m_objBaseCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_mthClearRecordInfo();
                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                m_mthEnableRichTextBox();

                m_mthSetSelectedRecord(m_objCurrentPatient);
                if (m_objCurrentRecordContent != null)
                {
                    this.m_dtpCreateDate.Enabled = false;

                    //当前处于修改记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
                }
                else
                {
                    m_mthSetNewRecord();
                    //当前处于新增记录状态
                    MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                }
            }
            catch (Exception exp)
            {
                string strtemp = exp.Message;
                m_mthClearRecordInfo();

                m_mthUnEnableRichTextBox();

                m_objCurrentRecordContent = null;
                m_mthEnableModify(true);
                this.m_dtpCreateDate.Enabled = true;
                this.m_dtpCreateDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");

                m_mthSetNullPrintContext();

                //当前处于禁止输入状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.None);
            }
            finally
            {
                m_mthDoAfterSelect();
                m_mthAddFormStatusForClosingSave();
            }
        }
		
	}
}

