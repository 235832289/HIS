using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace iCare
{
	public class frmDutyArrange : iCare.frmManageRecordForm
	{
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpFromDate;
		private System.Windows.Forms.Label lblTo;
		private System.Windows.Forms.Label lblFrom;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.MenuItem mniAuto;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpToDate;
		private System.Windows.Forms.Label lblCurrentDate;
		private System.Windows.Forms.Label lblDutyType;
		private System.Windows.Forms.Label lblRemark;
		private System.Windows.Forms.ContextMenu ctmAssign;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label lbltitle;
		private System.Windows.Forms.Label label1;
		private com.digitalwave.Utility.Controls.ctlComboBox ctlComboBox1;
		private System.Windows.Forms.ListView m_lsvOnDutyEmpList;
		private System.Windows.Forms.ListView m_lsvAllEmpList;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRemark;
		private System.Windows.Forms.Button m_cmdPrint;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboDutyType;
		private System.Windows.Forms.MonthCalendar m_mcdMain;
		private System.Windows.Forms.Button m_cmdSave;
		private System.Windows.Forms.Button m_cmdCancel;
		private System.ComponentModel.IContainer components = null;

		public frmDutyArrange()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_lsvAllEmpList,m_lsvOnDutyEmpList});
		}

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
			this.dtpFromDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblTo = new System.Windows.Forms.Label();
			this.lblFrom = new System.Windows.Forms.Label();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_txtRemark = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.mniAuto = new System.Windows.Forms.MenuItem();
			this.m_cmdPrint = new System.Windows.Forms.Button();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.dtpToDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblCurrentDate = new System.Windows.Forms.Label();
			this.m_cboDutyType = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblDutyType = new System.Windows.Forms.Label();
			this.lblRemark = new System.Windows.Forms.Label();
			this.m_mcdMain = new System.Windows.Forms.MonthCalendar();
			this.ctmAssign = new System.Windows.Forms.ContextMenu();
			this.m_lsvOnDutyEmpList = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.lbltitle = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ctlComboBox1 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_lsvAllEmpList = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.m_cmdSave = new System.Windows.Forms.Button();
			this.m_cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// dtpFromDate
			// 
			this.dtpFromDate.BorderColor = System.Drawing.Color.White;
			this.dtpFromDate.CustomFormat = "yyyy年MM月dd日";
			this.dtpFromDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.dtpFromDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.dtpFromDate.DropButtonForeColor = System.Drawing.Color.White;
			this.dtpFromDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpFromDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpFromDate.Location = new System.Drawing.Point(448, 416);
			this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpFromDate.Name = "dtpFromDate";
			this.dtpFromDate.Size = new System.Drawing.Size(132, 26);
			this.dtpFromDate.TabIndex = 467;
			this.dtpFromDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.dtpFromDate.TextForeColor = System.Drawing.Color.White;
			// 
			// lblTo
			// 
			this.lblTo.ForeColor = System.Drawing.Color.White;
			this.lblTo.Location = new System.Drawing.Point(420, 464);
			this.lblTo.Name = "lblTo";
			this.lblTo.Size = new System.Drawing.Size(24, 23);
			this.lblTo.TabIndex = 470;
			this.lblTo.Text = "到";
			// 
			// lblFrom
			// 
			this.lblFrom.ForeColor = System.Drawing.Color.White;
			this.lblFrom.Location = new System.Drawing.Point(420, 416);
			this.lblFrom.Name = "lblFrom";
			this.lblFrom.Size = new System.Drawing.Size(24, 23);
			this.lblFrom.TabIndex = 469;
			this.lblFrom.Text = "从";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "员工姓名";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 100;
			// 
			// m_txtRemark
			// 
			this.m_txtRemark.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtRemark.BorderColor = System.Drawing.Color.White;
			this.m_txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtRemark.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtRemark.ForeColor = System.Drawing.Color.White;
			this.m_txtRemark.Location = new System.Drawing.Point(428, 260);
			this.m_txtRemark.Name = "m_txtRemark";
			this.m_txtRemark.Size = new System.Drawing.Size(144, 26);
			this.m_txtRemark.TabIndex = 456;
			this.m_txtRemark.Text = "";
			// 
			// mniAuto
			// 
			this.mniAuto.Index = 0;
			this.mniAuto.Text = "安排人员";
			// 
			// m_cmdPrint
			// 
			this.m_cmdPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdPrint.Location = new System.Drawing.Point(424, 508);
			this.m_cmdPrint.Name = "m_cmdPrint";
			this.m_cmdPrint.Size = new System.Drawing.Size(156, 32);
			this.m_cmdPrint.TabIndex = 471;
			this.m_cmdPrint.Text = "列印班表";
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "备注";
			this.columnHeader5.Width = 100;
			// 
			// dtpToDate
			// 
			this.dtpToDate.BorderColor = System.Drawing.Color.White;
			this.dtpToDate.CustomFormat = "yyyy年MM月dd日";
			this.dtpToDate.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.dtpToDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.dtpToDate.DropButtonForeColor = System.Drawing.Color.White;
			this.dtpToDate.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpToDate.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpToDate.Location = new System.Drawing.Point(448, 460);
			this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpToDate.Name = "dtpToDate";
			this.dtpToDate.Size = new System.Drawing.Size(132, 26);
			this.dtpToDate.TabIndex = 468;
			this.dtpToDate.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.dtpToDate.TextForeColor = System.Drawing.Color.White;
			// 
			// lblCurrentDate
			// 
			this.lblCurrentDate.ForeColor = System.Drawing.Color.White;
			this.lblCurrentDate.Location = new System.Drawing.Point(592, 256);
			this.lblCurrentDate.Name = "lblCurrentDate";
			this.lblCurrentDate.Size = new System.Drawing.Size(356, 23);
			this.lblCurrentDate.TabIndex = 466;
			// 
			// m_cboDutyType
			// 
			this.m_cboDutyType.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboDutyType.BorderColor = System.Drawing.Color.White;
			this.m_cboDutyType.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboDutyType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDutyType.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboDutyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDutyType.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDutyType.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDutyType.ForeColor = System.Drawing.Color.White;
			this.m_cboDutyType.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboDutyType.ListForeColor = System.Drawing.Color.White;
			this.m_cboDutyType.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboDutyType.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboDutyType.Location = new System.Drawing.Point(428, 192);
			this.m_cboDutyType.Name = "m_cboDutyType";
			this.m_cboDutyType.SelectedIndex = -1;
			this.m_cboDutyType.SelectedItem = null;
			this.m_cboDutyType.Size = new System.Drawing.Size(144, 26);
			this.m_cboDutyType.TabIndex = 465;
			this.m_cboDutyType.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboDutyType.TextForeColor = System.Drawing.Color.White;
			// 
			// lblDutyType
			// 
			this.lblDutyType.AutoSize = true;
			this.lblDutyType.ForeColor = System.Drawing.Color.White;
			this.lblDutyType.Location = new System.Drawing.Point(428, 164);
			this.lblDutyType.Name = "lblDutyType";
			this.lblDutyType.Size = new System.Drawing.Size(55, 19);
			this.lblDutyType.TabIndex = 464;
			this.lblDutyType.Text = "班次：";
			// 
			// lblRemark
			// 
			this.lblRemark.AutoSize = true;
			this.lblRemark.ForeColor = System.Drawing.Color.White;
			this.lblRemark.Location = new System.Drawing.Point(428, 232);
			this.lblRemark.Name = "lblRemark";
			this.lblRemark.Size = new System.Drawing.Size(55, 19);
			this.lblRemark.TabIndex = 461;
			this.lblRemark.Text = "备注：";
			// 
			// m_mcdMain
			// 
			this.m_mcdMain.Location = new System.Drawing.Point(588, 64);
			this.m_mcdMain.Name = "m_mcdMain";
			this.m_mcdMain.TabIndex = 453;
			// 
			// ctmAssign
			// 
			this.ctmAssign.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mniAuto});
			// 
			// m_lsvOnDutyEmpList
			// 
			this.m_lsvOnDutyEmpList.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvOnDutyEmpList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvOnDutyEmpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.columnHeader1,
																								 this.columnHeader2,
																								 this.columnHeader4,
																								 this.columnHeader5});
			this.m_lsvOnDutyEmpList.ContextMenu = this.ctmAssign;
			this.m_lsvOnDutyEmpList.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvOnDutyEmpList.ForeColor = System.Drawing.Color.White;
			this.m_lsvOnDutyEmpList.FullRowSelect = true;
			this.m_lsvOnDutyEmpList.GridLines = true;
			this.m_lsvOnDutyEmpList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvOnDutyEmpList.Location = new System.Drawing.Point(592, 288);
			this.m_lsvOnDutyEmpList.Name = "m_lsvOnDutyEmpList";
			this.m_lsvOnDutyEmpList.Size = new System.Drawing.Size(392, 348);
			this.m_lsvOnDutyEmpList.TabIndex = 451;
			this.m_lsvOnDutyEmpList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = " 员工工号";
			this.columnHeader1.Width = 90;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "   班次";
			this.columnHeader4.Width = 100;
			// 
			// lbltitle
			// 
			this.lbltitle.AutoSize = true;
			this.lbltitle.Font = new System.Drawing.Font("SimSun", 26.25F);
			this.lbltitle.ForeColor = System.Drawing.Color.White;
			this.lbltitle.Location = new System.Drawing.Point(360, 16);
			this.lbltitle.Name = "lbltitle";
			this.lbltitle.Size = new System.Drawing.Size(319, 40);
			this.lbltitle.TabIndex = 452;
			this.lbltitle.Text = "人 员 工 作 安 排";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(32, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 19);
			this.label1.TabIndex = 473;
			this.label1.Text = "科室类别：";
			// 
			// ctlComboBox1
			// 
			this.ctlComboBox1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.ctlComboBox1.BorderColor = System.Drawing.Color.White;
			this.ctlComboBox1.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.ctlComboBox1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.ctlComboBox1.DropButtonForeColor = System.Drawing.Color.White;
			this.ctlComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ctlComboBox1.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ctlComboBox1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ctlComboBox1.ForeColor = System.Drawing.Color.White;
			this.ctlComboBox1.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.ctlComboBox1.ListForeColor = System.Drawing.Color.White;
			this.ctlComboBox1.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.ctlComboBox1.ListSelectedForeColor = System.Drawing.Color.White;
			this.ctlComboBox1.Location = new System.Drawing.Point(108, 68);
			this.ctlComboBox1.Name = "ctlComboBox1";
			this.ctlComboBox1.SelectedIndex = -1;
			this.ctlComboBox1.SelectedItem = null;
			this.ctlComboBox1.Size = new System.Drawing.Size(176, 26);
			this.ctlComboBox1.TabIndex = 474;
			this.ctlComboBox1.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.ctlComboBox1.TextForeColor = System.Drawing.Color.White;
			// 
			// m_lsvAllEmpList
			// 
			this.m_lsvAllEmpList.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_lsvAllEmpList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvAllEmpList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader8,
																							  this.columnHeader3,
																							  this.columnHeader6,
																							  this.columnHeader7});
			this.m_lsvAllEmpList.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvAllEmpList.ForeColor = System.Drawing.Color.White;
			this.m_lsvAllEmpList.FullRowSelect = true;
			this.m_lsvAllEmpList.GridLines = true;
			this.m_lsvAllEmpList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.m_lsvAllEmpList.Location = new System.Drawing.Point(32, 100);
			this.m_lsvAllEmpList.Name = "m_lsvAllEmpList";
			this.m_lsvAllEmpList.Size = new System.Drawing.Size(382, 536);
			this.m_lsvAllEmpList.TabIndex = 477;
			this.m_lsvAllEmpList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "序号";
			this.columnHeader8.Width = 50;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "员工工号";
			this.columnHeader3.Width = 80;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "员工姓名";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader6.Width = 100;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "职称";
			this.columnHeader7.Width = 150;
			// 
			// m_cmdSave
			// 
			this.m_cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdSave.Location = new System.Drawing.Point(460, 324);
			this.m_cmdSave.Name = "m_cmdSave";
			this.m_cmdSave.Size = new System.Drawing.Size(94, 32);
			this.m_cmdSave.TabIndex = 478;
			this.m_cmdSave.Text = ">>>";
			this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdCancel.Location = new System.Drawing.Point(460, 372);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Size = new System.Drawing.Size(94, 32);
			this.m_cmdCancel.TabIndex = 479;
			this.m_cmdCancel.Text = "<<<";
			// 
			// frmDutyArrange
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(1016, 733);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_cmdCancel,
																		  this.m_cmdSave,
																		  this.m_lsvAllEmpList,
																		  this.ctlComboBox1,
																		  this.label1,
																		  this.lblTo,
																		  this.lblFrom,
																		  this.m_txtRemark,
																		  this.m_cmdPrint,
																		  this.dtpToDate,
																		  this.lblCurrentDate,
																		  this.m_cboDutyType,
																		  this.lblDutyType,
																		  this.lblRemark,
																		  this.m_mcdMain,
																		  this.lbltitle,
																		  this.dtpFromDate,
																		  this.m_lsvOnDutyEmpList});
			this.Name = "frmDutyArrange";
			this.Text = "人员工作安排";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmDutyArrange_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmDutyArrange_Load(object sender, System.EventArgs e)
		{
			ListViewItem lviNewItem;
			lviNewItem = new ListViewItem("1");
			lviNewItem.SubItems.AddRange(new String[] {"00001","佘守章","主任医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);
			lviNewItem = new ListViewItem("2");
			lviNewItem.SubItems.AddRange(new String[] {"00002","彭梠宪","主任医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);
			lviNewItem = new ListViewItem("3");
			lviNewItem.SubItems.AddRange(new String[] {"00003","肖  辉","副主任医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);
			lviNewItem = new ListViewItem("4");
			lviNewItem.SubItems.AddRange(new String[] {"00004","肖建斌","副主任医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);
			lviNewItem = new ListViewItem("5");
			lviNewItem.SubItems.AddRange(new String[] {"00005","阮祥才","主治医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);
			lviNewItem = new ListViewItem("6");
			lviNewItem.SubItems.AddRange(new String[] {"00006","程傲冰","住院医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);
			lviNewItem = new ListViewItem("7");
			lviNewItem.SubItems.AddRange(new String[] {"00007","邬子林","住院医师"});
			m_lsvAllEmpList.Items.Add(lviNewItem);


			m_cboDutyType.AddRangeItems(new object [] {"中班","在/白班","夜班","人流室","疼痛AM","疼痛PM","补休"});

			ctlComboBox1.Focus();
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			if(m_lsvAllEmpList.SelectedItems.Count <=0)
				return;

			if(m_cboDutyType.SelectedIndex <0)
			{
				clsPublicFunction.ShowInformationMessageBox("请选择班次！");
				return;
			}

			string strID = m_lsvAllEmpList.SelectedItems[0].SubItems[1].Text;
			string strName =  m_lsvAllEmpList.SelectedItems[0].SubItems[2].Text;
			string strDutyType = m_cboDutyType.Text;
			string strRemark = m_txtRemark.Text.Trim();
			ListViewItem lviNew = new ListViewItem(strID);
			lviNew.SubItems.AddRange(new string []{strName,strDutyType,strRemark});
			m_lsvOnDutyEmpList.Items.Add(lviNew);
		}
	}
}

