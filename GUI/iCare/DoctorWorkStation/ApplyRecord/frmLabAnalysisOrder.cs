using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;

using iCareData;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;


namespace iCare
{
	public class frmLabAnalysisOrder : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Control Define
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.ListView lsvItemGroup;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.GroupBox grpItem;
		private System.Windows.Forms.ColumnHeader clmGroup;
		private System.Windows.Forms.Label label1;
		public com.digitalwave.Utility.Controls.ctlBorderTextBox txtRemark;
		private System.Windows.Forms.Label lblDignose;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TreeView trvGroup;
		public com.digitalwave.Utility.Controls.ctlBorderTextBox txtDignose;
		public com.digitalwave.Utility.Controls.ctlBorderTextBox txtSpecimen;
		public com.digitalwave.Utility.Controls.ctlTimePicker dtpCreateDate;
		public com.digitalwave.Utility.Controls.ctlTimePicker dtpSDate;
		public com.digitalwave.Utility.Controls.ctlBorderTextBox txtSDoc;
		protected System.Windows.Forms.ListView lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label txtAppDoc;
		private System.Windows.Forms.ContextMenu ctmGroupItem;
		private System.Windows.Forms.MenuItem mniDelete;
		private System.Windows.Forms.ImageList imgButton;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Constructor
		public frmLabAnalysisOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

            //m_objBorderTool = new clsBorderTool(Color.White);

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{trvTime,trvGroup,lsvItemGroup});

			m_objLabCheckItemAdminDomain = new clsLabCheckItemAdminDomain();

			m_objLabAnalysisOrderDomain = new clsLabAnalysisOrderDomain();

			m_mthInitializeGroup();

			TreeNode trvNode = new TreeNode("申请日期");
			trvNode.Tag = "0";
			trvTime.Nodes.Add(trvNode);

			m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);

			txtAppDoc.Text = MDIParent.strOperatorName;

			m_mthSetQuickKeys();
		}
		#endregion

		#region Member
		private clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
				
        //private clsBorderTool  m_objBorderTool;

		private clsLabCheckItemAdminDomain m_objLabCheckItemAdminDomain;

		private clsLabAnalysisOrderDomain m_objLabAnalysisOrderDomain;

		private bool m_blnCanSearch = true;

		private string m_strInPatientID;

		private string m_strInPatientDate;

		private clsPatient m_objSelectedPatient=null;

		private clsLabCheckOrderContent m_objLabCheckOrderContent = null;
		#endregion

		#region Dispose
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
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabAnalysisOrder));
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lsvItemGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.clmGroup = new System.Windows.Forms.ColumnHeader();
            this.ctmGroupItem = new System.Windows.Forms.ContextMenu();
            this.mniDelete = new System.Windows.Forms.MenuItem();
            this.trvGroup = new System.Windows.Forms.TreeView();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemark = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDignose = new System.Windows.Forms.Label();
            this.txtDignose = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpSDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSpecimen = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.txtSDoc = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lsvEmployee = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.txtAppDoc = new System.Windows.Forms.Label();
            this.imgButton = new System.Windows.Forms.ImageList(this.components);
            this.grpItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.AutoSize = true;
            this.m_lblForTitle.Location = new System.Drawing.Point(424, 16);
            this.m_lblForTitle.Size = new System.Drawing.Size(77, 14);
            this.m_lblForTitle.Text = "检验申请单";
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(839, 40);
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.trvTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.SystemColors.Window;
            this.trvTime.FullRowSelect = true;
            this.trvTime.HideSelection = false;
            this.trvTime.Location = new System.Drawing.Point(56, 112);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(228, 192);
            this.trvTime.TabIndex = 100;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // lsvItemGroup
            // 
            this.lsvItemGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lsvItemGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvItemGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.clmGroup});
            this.lsvItemGroup.ContextMenu = this.ctmGroupItem;
            this.lsvItemGroup.ForeColor = System.Drawing.Color.White;
            this.lsvItemGroup.FullRowSelect = true;
            this.lsvItemGroup.GridLines = true;
            this.lsvItemGroup.Location = new System.Drawing.Point(316, 68);
            this.lsvItemGroup.Name = "lsvItemGroup";
            this.lsvItemGroup.Size = new System.Drawing.Size(552, 204);
            this.lsvItemGroup.TabIndex = 220;
            this.lsvItemGroup.UseCompatibleStateImageBehavior = false;
            this.lsvItemGroup.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编  号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名  称";
            this.columnHeader2.Width = 250;
            // 
            // clmGroup
            // 
            this.clmGroup.Text = "所 属 组";
            this.clmGroup.Width = 200;
            // 
            // ctmGroupItem
            // 
            this.ctmGroupItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDelete});
            this.ctmGroupItem.Popup += new System.EventHandler(this.ctmGroupItem_Popup);
            // 
            // mniDelete
            // 
            this.mniDelete.Index = 0;
            this.mniDelete.Text = "移  除";
            this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
            // 
            // trvGroup
            // 
            this.trvGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.trvGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvGroup.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvGroup.ForeColor = System.Drawing.SystemColors.Window;
            this.trvGroup.FullRowSelect = true;
            this.trvGroup.HideSelection = false;
            this.trvGroup.Location = new System.Drawing.Point(16, 72);
            this.trvGroup.Name = "trvGroup";
            this.trvGroup.Size = new System.Drawing.Size(288, 200);
            this.trvGroup.TabIndex = 210;
            this.trvGroup.DoubleClick += new System.EventHandler(this.trvGroup_DoubleClick);
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.label2);
            this.grpItem.Controls.Add(this.trvGroup);
            this.grpItem.Controls.Add(this.lsvItemGroup);
            this.grpItem.Font = new System.Drawing.Font("宋体", 12F);
            this.grpItem.Location = new System.Drawing.Point(56, 312);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(892, 276);
            this.grpItem.TabIndex = 210;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "检验项目组";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(848, 36);
            this.label2.TabIndex = 514;
            this.label2.Text = "双击左边项目组树的检验项目向右边的列表添加需要的项目；右健单击项目列表中的项目，在弹出菜单中选择“移除”可以删除选中的检验项目。";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRemark
            // 
            this.txtRemark.AccessibleDescription = "备注";
            this.txtRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRemark.BorderColor = System.Drawing.Color.White;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemark.Font = new System.Drawing.Font("宋体", 12F);
            this.txtRemark.ForeColor = System.Drawing.Color.White;
            this.txtRemark.Location = new System.Drawing.Point(56, 624);
            this.txtRemark.MaxLength = 500;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRemark.Size = new System.Drawing.Size(892, 76);
            this.txtRemark.TabIndex = 230;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(60, 596);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 504;
            this.label1.Text = "备注:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDignose
            // 
            this.lblDignose.AutoSize = true;
            this.lblDignose.Font = new System.Drawing.Font("宋体", 12F);
            this.lblDignose.Location = new System.Drawing.Point(296, 180);
            this.lblDignose.Name = "lblDignose";
            this.lblDignose.Size = new System.Drawing.Size(80, 16);
            this.lblDignose.TabIndex = 505;
            this.lblDignose.Text = "诊   断：";
            this.lblDignose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDignose
            // 
            this.txtDignose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtDignose.BorderColor = System.Drawing.Color.White;
            this.txtDignose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDignose.Font = new System.Drawing.Font("宋体", 12F);
            this.txtDignose.ForeColor = System.Drawing.Color.White;
            this.txtDignose.Location = new System.Drawing.Point(384, 176);
            this.txtDignose.MaxLength = 255;
            this.txtDignose.Multiline = true;
            this.txtDignose.Name = "txtDignose";
            this.txtDignose.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDignose.Size = new System.Drawing.Size(568, 52);
            this.txtDignose.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(296, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 509;
            this.label3.Text = "申请日期：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpCreateDate
            // 
            this.dtpCreateDate.BorderColor = System.Drawing.Color.White;
            this.dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpCreateDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpCreateDate.DropButtonForeColor = System.Drawing.Color.White;
            this.dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpCreateDate.Font = new System.Drawing.Font("宋体", 12F);
            this.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCreateDate.Location = new System.Drawing.Point(388, 140);
            this.dtpCreateDate.m_BlnOnlyTime = false;
            this.dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCreateDate.Name = "dtpCreateDate";
            this.dtpCreateDate.ReadOnly = false;
            this.dtpCreateDate.Size = new System.Drawing.Size(212, 22);
            this.dtpCreateDate.TabIndex = 110;
            this.dtpCreateDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.dtpCreateDate.TextForeColor = System.Drawing.Color.White;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(620, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 511;
            this.label4.Text = "申请医师:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpSDate
            // 
            this.dtpSDate.BorderColor = System.Drawing.Color.White;
            this.dtpSDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpSDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.dtpSDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpSDate.DropButtonForeColor = System.Drawing.Color.White;
            this.dtpSDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpSDate.Font = new System.Drawing.Font("宋体", 12F);
            this.dtpSDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSDate.Location = new System.Drawing.Point(384, 240);
            this.dtpSDate.m_BlnOnlyTime = false;
            this.dtpSDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpSDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpSDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSDate.Name = "dtpSDate";
            this.dtpSDate.ReadOnly = false;
            this.dtpSDate.Size = new System.Drawing.Size(208, 22);
            this.dtpSDate.TabIndex = 140;
            this.dtpSDate.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.dtpSDate.TextForeColor = System.Drawing.Color.White;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(296, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 513;
            this.label5.Text = "送检日期：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(616, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 515;
            this.label7.Text = "送检医师:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(296, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 517;
            this.label8.Text = "送检物:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSpecimen
            // 
            this.txtSpecimen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtSpecimen.BorderColor = System.Drawing.Color.White;
            this.txtSpecimen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecimen.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSpecimen.ForeColor = System.Drawing.Color.White;
            this.txtSpecimen.Location = new System.Drawing.Point(384, 276);
            this.txtSpecimen.MaxLength = 100;
            this.txtSpecimen.Name = "txtSpecimen";
            this.txtSpecimen.Size = new System.Drawing.Size(568, 26);
            this.txtSpecimen.TabIndex = 200;
            // 
            // txtSDoc
            // 
            this.txtSDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtSDoc.BorderColor = System.Drawing.Color.White;
            this.txtSDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSDoc.Font = new System.Drawing.Font("宋体", 12F);
            this.txtSDoc.ForeColor = System.Drawing.Color.White;
            this.txtSDoc.Location = new System.Drawing.Point(708, 236);
            this.txtSDoc.MaxLength = 7;
            this.txtSDoc.Name = "txtSDoc";
            this.txtSDoc.Size = new System.Drawing.Size(148, 26);
            this.txtSDoc.TabIndex = 150;
            this.txtSDoc.Leave += new System.EventHandler(this.txtSDoc_Leave);
            this.txtSDoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSDoc_KeyDown);
            // 
            // lsvEmployee
            // 
            this.lsvEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lsvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lsvEmployee.Font = new System.Drawing.Font("宋体", 12F);
            this.lsvEmployee.ForeColor = System.Drawing.Color.White;
            this.lsvEmployee.FullRowSelect = true;
            this.lsvEmployee.GridLines = true;
            this.lsvEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvEmployee.Location = new System.Drawing.Point(708, 264);
            this.lsvEmployee.Name = "lsvEmployee";
            this.lsvEmployee.Size = new System.Drawing.Size(200, 104);
            this.lsvEmployee.TabIndex = 160;
            this.lsvEmployee.UseCompatibleStateImageBehavior = false;
            this.lsvEmployee.View = System.Windows.Forms.View.Details;
            this.lsvEmployee.DoubleClick += new System.EventHandler(this.lsvEmployee_DoubleClick);
            this.lsvEmployee.Leave += new System.EventHandler(this.lsvEmployee_Leave);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 100;
            // 
            // txtAppDoc
            // 
            this.txtAppDoc.Font = new System.Drawing.Font("宋体", 12F);
            this.txtAppDoc.Location = new System.Drawing.Point(708, 140);
            this.txtAppDoc.Name = "txtAppDoc";
            this.txtAppDoc.Size = new System.Drawing.Size(148, 23);
            this.txtAppDoc.TabIndex = 120;
            this.txtAppDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgButton
            // 
            this.imgButton.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgButton.ImageStream")));
            this.imgButton.TransparentColor = System.Drawing.Color.Transparent;
            this.imgButton.Images.SetKeyName(0, "");
            // 
            // frmLabAnalysisOrder
            // 
            this.AccessibleDescription = "检验申请单";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 713);
            this.Controls.Add(this.txtAppDoc);
            this.Controls.Add(this.lsvEmployee);
            this.Controls.Add(this.txtSDoc);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpSDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpCreateDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDignose);
            this.Controls.Add(this.lblDignose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.txtSpecimen);
            this.Name = "frmLabAnalysisOrder";
            this.Text = "检验申请单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLabAnalysisOrder_Load);
            this.Controls.SetChildIndex(this.txtSpecimen, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.grpItem, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblDignose, 0);
            this.Controls.SetChildIndex(this.txtDignose, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.dtpSDate, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.txtSDoc, 0);
            this.Controls.SetChildIndex(this.lsvEmployee, 0);
            this.Controls.SetChildIndex(this.txtAppDoc, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.grpItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Initialization
		/// <summary>
		/// 初始化项目组
		/// </summary>
		private void m_mthInitializeGroup()
		{
			Cursor.Current = Cursors.WaitCursor;

			TreeNode trvNode = new TreeNode("检验项目组");
			trvNode.Tag = "0";
			trvGroup.Nodes.Add(trvNode);

			//加载项目组
			clsLabCheckGroup[] objLabCheckGroupArr;

			long lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckGroups(out objLabCheckGroupArr);

			if(lngRes <= 0 || objLabCheckGroupArr == null || objLabCheckGroupArr.Length == 0)
				return;

			for(int i = 0; i < objLabCheckGroupArr.Length; i++)
			{
				if(objLabCheckGroupArr[i] != null)
				{
					trvNode = new TreeNode(objLabCheckGroupArr[i].m_strLabGroupName);
					trvNode.Tag = objLabCheckGroupArr[i];

					trvGroup.Nodes[0].Nodes.Add(trvNode);
				}
			}

			trvGroup.Nodes[0].Nodes.Add("未归类项目");

			//加载每个项目组中的子项
			for(int i = 0; i < trvGroup.Nodes[0].Nodes.Count; i++)
			{
				clsLabCheckGroup objLabCheckGroup = new clsLabCheckGroup();
				objLabCheckGroup = (clsLabCheckGroup)trvGroup.Nodes[0].Nodes[i].Tag;

				if(objLabCheckGroup != null) //加载已经定义项目组中的子项
				{
					clsLabCheckItem[] objLabCheckItemArr;

					lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckGroupItem(objLabCheckGroup.m_strLabGroupID,out objLabCheckItemArr);

					if(lngRes <= 0 || objLabCheckItemArr == null || objLabCheckItemArr.Length == 0)
						continue;

					for(int j = 0; j < objLabCheckItemArr.Length; j++)
					{
						if(objLabCheckItemArr[j] != null)
						{
							TreeNode trvSubNode = new TreeNode(objLabCheckItemArr[j].m_strLabItemDesc);
							trvSubNode.Tag = objLabCheckItemArr[j];
							trvGroup.Nodes[0].Nodes[i].Nodes.Add(trvSubNode);							
						}
					}//end for j
				}
				else   //加载未归类项目组中的子项
				{
					clsLabCheckItem[] objLabUnGroupItemArr;
					lngRes = m_objLabCheckItemAdminDomain.m_lngGetUnGroupLabCheckItems(out objLabUnGroupItemArr);

					if(lngRes <= 0 || objLabUnGroupItemArr == null || objLabUnGroupItemArr.Length == 0)
						continue;

					for(int j = 0; j < objLabUnGroupItemArr.Length; j++)
					{
						if(objLabUnGroupItemArr[j] != null)
						{
							TreeNode trvSubNode = new TreeNode(objLabUnGroupItemArr[j].m_strLabItemDesc);
							trvSubNode.Tag = objLabUnGroupItemArr[j];
							trvGroup.Nodes[0].Nodes[i].Nodes.Add(trvSubNode);							
						}
					}//end for j

				}
			}//end for i

			trvGroup.Nodes[0].Expand();

			Cursor.Current = Cursors.Default;
		}
		#endregion

		#region Event Handler
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthClearUpRecord();

			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
			{
				this.dtpCreateDate.Enabled = true;
				//				m_mthReadOnly(false);

				if(m_strInPatientID != null && m_strInPatientDate != null)
				{
					iCareData.clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = m_objInPaitentCaseDefault.lngGetAllInPatientCaseHisoryDefault(m_strInPatientID,m_strInPatientDate);
					if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
					{
						this.txtDignose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
					}					
				}

				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);

				return;
			}
			else
			{
				this.dtpCreateDate.Enabled = false;

				string strCreateDate = trvTime.SelectedNode.Tag.ToString();

				long lngRes = m_objLabAnalysisOrderDomain.m_lngGetRecordContentWithServ(m_strInPatientID,m_strInPatientDate,strCreateDate,out m_objLabCheckOrderContent);

				if(m_objLabCheckOrderContent != null)
				{
//					m_mthReadOnly(MDIParent.OperatorID != m_objLabCheckOrderContent.m_strCreateUserID);
				}
				m_mthDisplay();

				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );

			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trvGroup_DoubleClick(object sender, System.EventArgs e)
		{
			if(trvGroup.SelectedNode.Tag == null || trvGroup.SelectedNode == trvGroup.Nodes[0])
			{
				return;
			}
			else
			{
				if(trvGroup.SelectedNode.Parent == trvGroup.Nodes[0]) //已经归类的组节点
				{
					if(trvGroup.SelectedNode.Nodes.Count == 0)
						return;

					for(int i = 0; i < trvGroup.SelectedNode.Nodes.Count; i++)
					{
						bool blnAddToListView = true;
						for(int j = 0; j < lsvItemGroup.Items.Count; j++)
						{
							if(lsvItemGroup.Items[j].SubItems[0].Text.Trim() == ((clsLabCheckItem)trvGroup.SelectedNode.Nodes[i].Tag).m_strLabItemID.Trim())
							{
								blnAddToListView = false;
								break;
							}
						}

						if(!blnAddToListView)
							return;

						clsLabCheckGroupItem objLabCheckGroupItem = new clsLabCheckGroupItem();
						objLabCheckGroupItem.m_objLabCheckGroup = (clsLabCheckGroup)trvGroup.SelectedNode.Tag;
						objLabCheckGroupItem.m_objLabCheckItem = (clsLabCheckItem)trvGroup.SelectedNode.Nodes[i].Tag;

						ListViewItem lsvItem = new ListViewItem(new string[]{((clsLabCheckItem)trvGroup.SelectedNode.Nodes[i].Tag).m_strLabItemID,((clsLabCheckItem)trvGroup.SelectedNode.Nodes[i].Tag).m_strLabItemDesc,trvGroup.SelectedNode.Text});
						lsvItem.Tag = objLabCheckGroupItem;
						
						lsvItemGroup.Items.Add(lsvItem);
					}//end for
				}//end if
				else  //子节点 -- 最底一层的节点
				{
					bool blnAddToListView = true;
					for(int j = 0; j < lsvItemGroup.Items.Count; j++)
					{
						if(lsvItemGroup.Items[j].SubItems[0].Text.Trim() == ((clsLabCheckItem)trvGroup.SelectedNode.Tag).m_strLabItemID.Trim())
						{
							blnAddToListView = false;
							break;
						}
					}

					if(!blnAddToListView)
						return;

					clsLabCheckGroupItem objLabCheckGroupItem = new clsLabCheckGroupItem();
					objLabCheckGroupItem.m_objLabCheckGroup = (clsLabCheckGroup)trvGroup.SelectedNode.Parent.Tag;
					objLabCheckGroupItem.m_objLabCheckItem = (clsLabCheckItem)trvGroup.SelectedNode.Tag;

					ListViewItem lsvItem = new ListViewItem(new string[]{((clsLabCheckItem)trvGroup.SelectedNode.Tag).m_strLabItemID,((clsLabCheckItem)trvGroup.SelectedNode.Tag).m_strLabItemDesc,trvGroup.SelectedNode.Parent.Text});
					lsvItem.Tag = objLabCheckGroupItem;
						
					lsvItemGroup.Items.Add(lsvItem);
				}
			}//end if

			m_mthChangeListViewLastColumnWidth(lsvItemGroup,10);
		}

		private void mniDelete_Click(object sender, System.EventArgs e)
		{
			lsvItemGroup.SelectedItems[0].Remove();
		}

		private void ctmGroupItem_Popup(object sender, System.EventArgs e)
		{
			if(lsvItemGroup.Items.Count == 0 || lsvItemGroup.SelectedItems.Count == 0)
				mniDelete.Visible = false;
			else
				mniDelete.Visible = true;
		}

		private void txtSDoc_Leave(object sender, System.EventArgs e)
		{
			if(!lsvEmployee.Focused)
				lsvEmployee.Visible = false;
		}

		private void lsvEmployee_Leave(object sender, System.EventArgs e)
		{
			lsvEmployee.Visible = false;
		}
		#endregion

		#region Public Function
		public void Copy()
		{
			this.m_lngCopy();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Cut()
		{
			this.m_lngCut();
		}

		public void Delete()
		{
			this.m_lngDelete();
		}

		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
			this.m_lngPaste();
		}

		public void Print()
		{
			this.m_lngPrint();
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
			this.m_lngSave();
		}

		public void Undo()
		{
		
		}
		#endregion

		#region Override Function
		protected override long m_lngSubAddNew()
		{
			if(m_strInPatientID == null || m_strInPatientID == "")
			{
				clsPublicFunction.ShowInformationMessageBox("对不起，请输入病人住院编号！");
				return 0;
			}
			
			if(m_objLabCheckOrderContent != null) 
			{
//				if(!m_bolShowIfModify()) return -1;
				if(MDIParent.OperatorID.Trim() != m_objLabCheckOrderContent.m_strCreateUserID.Trim())
				{	
					clsPublicFunction.ShowInformationMessageBox("无法修改他人的申请单!");
					return -1;
				}
			}

			clsLabCheckOrderContent objContent = new clsLabCheckOrderContent();

			objContent.m_strInPatientID = m_strInPatientID;
			objContent.m_dtmInPatientDate = DateTime.Parse( m_strInPatientDate);
			objContent.m_dtmCreateDate = DateTime.Parse( dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
			objContent.m_dtmModifyDate = DateTime.Parse( m_strInPatientDate);
			objContent.m_strCreateUserID = MDIParent.strOperatorID;
			objContent.m_bytIfConfirm = 0;
			objContent.m_bytStatus = 0;

			string strBarCode ;

			if(m_objLabCheckOrderContent == null)
			{
				long lngRes1 = m_objLabAnalysisOrderDomain.m_lngGetMaxBarCode(out strBarCode);
				strBarCode = (int.Parse(strBarCode) + 1).ToString("0000000000");
			}
			else
			{
				strBarCode = m_objLabCheckOrderContent.m_strBarCode;
			}

			objContent.m_strBarCode = strBarCode;
			objContent.m_strSpecimen = txtSpecimen.Text.Trim();
			objContent.m_strDignose = txtDignose.Text.Trim();
			objContent.m_dtmSDate = DateTime.Parse( dtpSDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
			
			if(txtSDoc.Tag!=null && txtSDoc.Text.Trim()!="")
			{
				objContent.m_strSDocID=((clsEmployee)txtSDoc.Tag).m_StrEmployeeID;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("请送检医师签名!");
				txtSDoc.Focus();
			}		
			//objContent.m_strSDocID = (txtSDoc.Tag == null) ? "" : ((clsEmployee)txtSDoc.Tag).m_StrEmployeeID;
			objContent.m_strRecDocID = MDIParent.strOperatorID;
			objContent.m_strRemark = txtRemark.Text.Trim();

			string[] strItem_GroupIDArr = new string[lsvItemGroup.Items.Count];
			string[] strItem_IDArr = new string[lsvItemGroup.Items.Count];

			for(int i = 0; i < lsvItemGroup.Items.Count; i++)
			{
				clsLabCheckGroupItem objGroupItem = new clsLabCheckGroupItem();
				objGroupItem = (clsLabCheckGroupItem)lsvItemGroup.Items[i].Tag;

				if(objGroupItem.m_objLabCheckGroup == null)
				{
					strItem_GroupIDArr[i] = "";
				}
				else
				{
					strItem_GroupIDArr[i] = objGroupItem.m_objLabCheckGroup.m_strLabGroupID;
				}

				strItem_IDArr[i] = objGroupItem.m_objLabCheckItem.m_strLabItemID;
			}

			objContent.m_strItem_GroupIDArr = strItem_GroupIDArr;
			objContent.m_strItem_IDArr = strItem_IDArr;

			
			long lngRes = m_objLabAnalysisOrderDomain.m_lngAddNewRecord2DB(objContent);

			if(lngRes <= 0)
				return 0;

			if(m_objLabCheckOrderContent == null)
			{
				TreeNode trvNode = new TreeNode(objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
				trvNode.Tag = objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
				trvTime.Nodes[0].Nodes.Insert(0,trvNode);
				trvTime.SelectedNode = trvNode;
			}
			//liyi 2003-7-9 不知道以下代码有何用，故注释。
//			else 
//			{
//				TreeNode m_trnTempNode = trvTime.SelectedNode;
//				trvTime.SelectedNode = trvTime.Nodes[0];
//				trvTime.SelectedNode = m_trnTempNode;
//			}

			return 1;
		}

		protected override long m_lngSubDelete()
		{
			if(m_objLabCheckOrderContent == null || m_objSelectedPatient == null)
				return 0;

			m_objLabCheckOrderContent.m_bytStatus = 1;
			m_objLabCheckOrderContent.m_strDeActiveOperatorID = MDIParent.strOperatorID;
			
			long lngRes = m_objLabAnalysisOrderDomain.m_lngDeleteRecord2DB(m_objLabCheckOrderContent);
			if(lngRes > 0)
				trvTime.SelectedNode.Remove();

			return lngRes;
		}

		protected override long m_lngSubModify()
		{
			return m_lngSubAddNew();
		}



		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return m_blnCanSearch;
			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				return dtpCreateDate.Enabled==true;
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_objSelectedPatient = p_objSelectedPatient;

			m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
            m_strInPatientDate = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            txtInPatientID.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_StrHISInPatientID;
			m_mthLoadAllRecordTimeOfAPatient(m_strInPatientID ,m_strInPatientDate);

			trvTime.SelectedNode = trvTime.Nodes[0];
		}
		#endregion

		#region Private Method
		/// <summary>
		/// 
		/// </summary>
		private void m_mthDisplay()
		{
			if(m_objLabCheckOrderContent == null)
				return;

			dtpCreateDate.Value = m_objLabCheckOrderContent.m_dtmCreateDate;
			txtDignose.Text = m_objLabCheckOrderContent.m_strDignose;
			txtSpecimen.Text = m_objLabCheckOrderContent.m_strSpecimen;
			txtRemark.Text = m_objLabCheckOrderContent.m_strRemark;
			dtpSDate.Value = m_objLabCheckOrderContent.m_dtmSDate;

			clsEmployee objEmp1 = new clsEmployee(m_objLabCheckOrderContent.m_strCreateUserID);
			txtAppDoc.Text = objEmp1.m_StrFirstName;
			clsEmployee objEmp2 = new clsEmployee(m_objLabCheckOrderContent.m_strSDocID);
			txtSDoc.Text = objEmp2.m_StrFirstName;

			if(m_objLabCheckOrderContent.m_strItem_IDArr != null && m_objLabCheckOrderContent.m_strItem_IDArr.Length != 0)
			{
				for(int i = 0; i < m_objLabCheckOrderContent.m_strItem_IDArr.Length; i++)
				{
					clsLabCheckItem  objLabCheckItem ;
					long lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckItemsSpecial(m_objLabCheckOrderContent.m_strItem_IDArr[i], out objLabCheckItem);

					clsLabCheckGroup objLabCheckGroup;
					lngRes = m_objLabCheckItemAdminDomain.m_lngGetLabCheckGroupSpecial(m_objLabCheckOrderContent.m_strItem_GroupIDArr[i], out objLabCheckGroup);

					if(objLabCheckItem != null)
					{
						clsLabCheckGroupItem objLabCheckGroupItem = new clsLabCheckGroupItem();
						objLabCheckGroupItem.m_objLabCheckGroup = objLabCheckGroup;
						objLabCheckGroupItem.m_objLabCheckItem = objLabCheckItem;

						string strGroupDesc = (objLabCheckGroup == null) ? "未归类项目" : objLabCheckGroup.m_strLabGroupName.Trim();

						ListViewItem lsvItem = new ListViewItem(new string[]{objLabCheckItem.m_strLabItemID,objLabCheckItem.m_strLabItemDesc,strGroupDesc});
						lsvItem.Tag = objLabCheckGroupItem;
						lsvItemGroup.Items.Add(lsvItem);
					}
				}
			}
		}

		/// <summary>
		/// tag 0 根 
		/// </summary>
		/// <param name="p_strPatientID"></param>
		/// <param name="p_strPatientDate"></param>
		private void m_mthLoadAllRecordTimeOfAPatient(string p_strPatientID,string p_strPatientDate)
		{
			m_mthClearUpRecord();

			if(p_strPatientID ==null || p_strPatientID =="") 
				return ;


			this.trvTime.Nodes[0].Nodes.Clear();

			string[] strCreateDateArr;
			string[] strOpenDateArr;

			long lngRes = m_objLabAnalysisOrderDomain.m_lngGetRecordTimeList(p_strPatientID ,p_strPatientDate,out strCreateDateArr, out strOpenDateArr);

			if(strCreateDateArr == null) return ;

			for(int i=strCreateDateArr.Length-1;i>=0 ;i--)
			{
				TreeNode trnDate=new TreeNode(strCreateDateArr[i]);
				trnDate.Tag = strCreateDateArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate );
				
			}
			this.trvTime.ExpandAll();
			trvTime.SelectedNode = trvTime.Nodes[0];
		}

		/// <summary>
		/// 
		/// </summary>
		private void m_mthClearUpRecord()
		{
			dtpCreateDate.Value = DateTime.Now;
			dtpSDate.Value = DateTime.Now;

			txtAppDoc.Text = "";
			txtDignose.Text = "";
			txtSDoc.Text = "";
			txtSpecimen.Text = "";
			txtRemark.Text = "";

			lsvItemGroup.Items.Clear();

			m_objLabCheckOrderContent = null;

		}

		private void m_mthClearAll()
		{
			base.m_mthClearPatientBaseInfo();
			m_mthClearUpRecord();
			txtAppDoc.Text = MDIParent.strOperatorName;
			trvTime.Nodes[0].Nodes.Clear();
		}
		#endregion

		#region Print
		/// <summary>
		/// 
		/// </summary>
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;

		private clsLabAnalysisOrderPrintTool m_objPrintTool;

		protected override long m_lngSubPrint()
		{
			m_mthPrintFromDataSource();
			return 0;
		}

		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_objPrintTool.m_mthBeginPrint(e);				
		}

		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_objPrintTool.m_mthEndPrint(e);
		}

		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			m_objPrintTool.m_mthPrintPage(e);
		}
		
		private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
		private void m_mthStartPrint()
		{			
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

		private void m_mthPrintFromDataSource()
		{	
			m_objPrintTool = new clsLabAnalysisOrderPrintTool();

			m_objPrintTool.m_mthInitPrintTool(null);

            if (m_objBaseCurrentPatient == null) //没有选择病人，打印空报表
                m_objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                if (this.trvTime.SelectedNode == null || this.trvTime.SelectedNode == trvTime.Nodes[0]) //选择病人，但内容为空
                    m_objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                else
                    m_objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, dtpCreateDate.Value);
            }				
			m_objPrintTool.m_mthInitPrintContent();	
	
			//保存到文件
//			object objtemp=objPrintTool.m_objGetPrintInfo();
//			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
//		
//			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Create);
//		
//			objForm.Serialize(objStream,objtemp);
//		
//			objStream.Flush();
//			objStream.Close();
				
			m_mthStartPrint();
		}

		//		private void m_mthDemoPrint_FromFile()
		//		{	
		//			objPrintTool=new clsLabAnalysisOrderPrintTool();
		//			objPrintTool.m_mthInitPrintTool(null);	
		//		
		//			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
		//			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Open);
		//			object objtemp = objForm.Deserialize(objStream);//
		//			objStream.Close();
		//				
		//			objPrintTool.m_mthSetPrintContent(objtemp);		
		//		
		//			m_mthStartPrint();
		//		}
		//		private void m_mthStartPrint()
		//		{			
		//			PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
		//			ppdPrintPreview.Document = m_pdcPrintDocument;
		//			ppdPrintPreview.ShowDialog();
		//		}
		//		bool bbb=true;
		//		protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
		//		{
		//			if(bbb)
		//				m_mthDemoPrint_FromDataSource();
		//			else m_mthDemoPrint_FromFile();
		//			bbb= !bbb;
		//			return 1;
		//		}
		#endregion

		#region 键盘快捷键
		/// <summary>
		/// 是否处理医生的TextChanged事件
		/// </summary>
		private bool m_blnCanDoctorTextChanged = true;

		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					//					if(sender.GetType().Name!="ctlRichTextBox")
					//						SendKeys.Send(  "{tab}");
					if(((Control)sender).Name=="txtSDoc")
					{
						m_mthGetDoctorList(txtSDoc.Text);

						if(this.lsvEmployee .Items.Count==1 && (txtSDoc.Text==lsvEmployee.Items[0].SubItems[0].Text|| txtSDoc.Text==lsvEmployee.Items[0].SubItems[1].Text))
						{
							lsvEmployee.Items[0].Selected=true;
							lsvEmployee_DoubleClick(null,null);
							break;
						}
					}
					else if(((Control)sender).Name=="lsvEmployee")
					{
						lsvEmployee_DoubleClick(null,null);						
					}

					break;

				case 38:
					break;

				case 40:
					if(((Control)sender).Name=="txtSDoc" && lsvEmployee.Visible == true)
					{
						lsvEmployee.Focus();
						if(lsvEmployee.Items != null && lsvEmployee.Items.Count != 0)
						{
							lsvEmployee.Items[0].Selected = true;
							lsvEmployee.Items[0].Focused = true;
						}
					}
					break;	

				
				case 113://save
					this.m_lngSave(); 
					break;
				case 114://del
					this.m_lngDelete(); 
					break;
				case 115://print
					this.m_lngPrint();
					break;
				case 116://refresh
					m_mthClearAll();
					break;
				case 117://Search					
					break;
			}	
		}

		/// <summary>
		/// 显示医生列表
		/// </summary>
		/// <param name="p_strDoctorNameLike">医生号</param>
		private void m_mthGetDoctorList(string p_strDoctorNameLike)
		{
			
			/*
			 * 获取所有医生号和姓名，根据输入医生号的控件标志（m_bytListOnDoctor）,
			 * 在相应的位置显示ListView。
			 */
			if(!m_blnCanDoctorTextChanged)
				return;

			if(p_strDoctorNameLike.Length == 0)
			{
				lsvEmployee.Visible = false;
				return;
			}

			Cursor.Current = Cursors.WaitCursor;

			clsEmployee [] objDoctorArr = m_objCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,m_objCurrentContext.m_ObjDepartment);

			if(objDoctorArr == null)
			{
				lsvEmployee.Visible = false;
				return;
			}

			lsvEmployee.Items.Clear();

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrFirstName
								});
				lviDoctor.Tag = objDoctorArr[i];

				lsvEmployee.Items.Add(lviDoctor);
			}

			m_mthChangeListViewLastColumnWidth(lsvEmployee);

			lsvEmployee.BringToFront();
			lsvEmployee.Visible = true;

			Cursor.Current = Cursors.Default;
		}

		private void lsvEmployee_DoubleClick(object sender, System.EventArgs e)
		{
			/*
			 * 选择了医生后，在相应的输入框显示姓名，在输入框的Tag保存医生信息
			 */
			if(lsvEmployee.SelectedItems.Count <= 0)
				return;

			clsEmployee objEmp = (clsEmployee)lsvEmployee.SelectedItems[0].Tag;

			if(objEmp == null)
				return;

//			if(!m_blnCheckEmployeeSign(objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
//				return;

			m_blnCanDoctorTextChanged = false;
 
			txtSDoc.Text = objEmp.m_StrLastName;
			txtSDoc.Tag = objEmp;

			lsvEmployee.Visible = false;

			m_blnCanDoctorTextChanged = true;
		}
		#endregion

		private void txtSDoc_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		
		}

		private void frmLabAnalysisOrder_Load(object sender, System.EventArgs e)
		{
			lsvEmployee.Visible = false;
			txtDignose.Focus();
		}



		
	}	
}

