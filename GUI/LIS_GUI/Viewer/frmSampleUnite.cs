using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmSampleUnite 的摘要说明。
	/// </summary>
	public class frmSampleUnite : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		public com.digitalwave.iCare.gui.LIS.clsController_SampleUnite m_objController;
		#region FormControls
		internal System.Windows.Forms.ListView m_lsvSampleList;
		internal System.Windows.Forms.ColumnHeader m_chCheckDat;
		private System.Windows.Forms.ColumnHeader m_chDeviceSampleID;
		internal System.Windows.Forms.ListView m_lsvSampleResult;
		internal System.Windows.Forms.ColumnHeader m_chCheckResult;
		internal System.Windows.Forms.ContextMenu m_ctmBaseSample;
		internal System.Windows.Forms.MenuItem m_mniSetBaseSample;
		internal System.Windows.Forms.ColumnHeader m_chBaseSample;
		internal System.Windows.Forms.TextBox m_txtDeviceSampleID;
		internal System.Windows.Forms.DateTimePicker m_dtpCheckDate;
		private System.Windows.Forms.GroupBox m_grpQuery;
		internal System.Windows.Forms.ColumnHeader m_chItem;
		private System.Windows.Forms.Panel m_palBottom;
		private System.Windows.Forms.Panel m_palMiddle;
		internal PinkieControls.ButtonXP m_btnQuery;
		internal com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox m_cboLisDevice;
		internal System.Windows.Forms.Label m_lbCheckDevice;
		internal System.Windows.Forms.Label m_lbCheckDat;
		internal System.Windows.Forms.Label m_lbDeviceSampleID;
		internal com.digitalwave.iCare.gui.LIS.ctlLISDeviceModelComboBox m_cboDeviceModel;
		private System.Windows.Forms.Label m_lbDeviceModel;
		internal System.Windows.Forms.ListView m_lsvResultUnite;
		private System.Windows.Forms.ColumnHeader m_chUnitItem;
		internal System.Windows.Forms.ColumnHeader m_chUniteResult;
		internal PinkieControls.ButtonXP m_btnClear;
		internal PinkieControls.ButtonXP m_btnSave;
		internal PinkieControls.ButtonXP m_btnCancel;
		private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP btnClose;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmSampleUnite()
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
		#endregion

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.m_lsvSampleList = new System.Windows.Forms.ListView();
            this.m_chDeviceSampleID = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckDat = new System.Windows.Forms.ColumnHeader();
            this.m_chBaseSample = new System.Windows.Forms.ColumnHeader();
            this.m_ctmBaseSample = new System.Windows.Forms.ContextMenu();
            this.m_mniSetBaseSample = new System.Windows.Forms.MenuItem();
            this.m_lsvSampleResult = new System.Windows.Forms.ListView();
            this.m_chItem = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckResult = new System.Windows.Forms.ColumnHeader();
            this.m_btnClear = new PinkieControls.ButtonXP();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_txtDeviceSampleID = new System.Windows.Forms.TextBox();
            this.m_cboLisDevice = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.m_lbCheckDat = new System.Windows.Forms.Label();
            this.m_dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.m_lbCheckDevice = new System.Windows.Forms.Label();
            this.m_lbDeviceSampleID = new System.Windows.Forms.Label();
            this.m_cboDeviceModel = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceModelComboBox();
            this.m_lbDeviceModel = new System.Windows.Forms.Label();
            this.m_grpQuery = new System.Windows.Forms.GroupBox();
            this.m_btnQuery = new PinkieControls.ButtonXP();
            this.m_lsvResultUnite = new System.Windows.Forms.ListView();
            this.m_chUnitItem = new System.Windows.Forms.ColumnHeader();
            this.m_chUniteResult = new System.Windows.Forms.ColumnHeader();
            this.m_palBottom = new System.Windows.Forms.Panel();
            this.btnClose = new PinkieControls.ButtonXP();
            this.m_btnCancel = new PinkieControls.ButtonXP();
            this.m_palMiddle = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_grpQuery.SuspendLayout();
            this.m_palBottom.SuspendLayout();
            this.m_palMiddle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lsvSampleList
            // 
            this.m_lsvSampleList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvSampleList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chDeviceSampleID,
            this.m_chCheckDat,
            this.m_chBaseSample});
            this.m_lsvSampleList.ContextMenu = this.m_ctmBaseSample;
            this.m_lsvSampleList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvSampleList.FullRowSelect = true;
            this.m_lsvSampleList.GridLines = true;
            this.m_lsvSampleList.HideSelection = false;
            this.m_lsvSampleList.Location = new System.Drawing.Point(12, 20);
            this.m_lsvSampleList.MultiSelect = false;
            this.m_lsvSampleList.Name = "m_lsvSampleList";
            this.m_lsvSampleList.Size = new System.Drawing.Size(488, 454);
            this.m_lsvSampleList.TabIndex = 0;
            this.m_lsvSampleList.UseCompatibleStateImageBehavior = false;
            this.m_lsvSampleList.View = System.Windows.Forms.View.Details;
            this.m_lsvSampleList.SelectedIndexChanged += new System.EventHandler(this.m_lsvSampleList_SelectedIndexChanged);
            // 
            // m_chDeviceSampleID
            // 
            this.m_chDeviceSampleID.Text = "仪器样本号";
            this.m_chDeviceSampleID.Width = 96;
            // 
            // m_chCheckDat
            // 
            this.m_chCheckDat.Text = "检验时间";
            this.m_chCheckDat.Width = 150;
            // 
            // m_chBaseSample
            // 
            this.m_chBaseSample.Text = "基准样本";
            this.m_chBaseSample.Width = 72;
            // 
            // m_ctmBaseSample
            // 
            this.m_ctmBaseSample.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mniSetBaseSample});
            // 
            // m_mniSetBaseSample
            // 
            this.m_mniSetBaseSample.Index = 0;
            this.m_mniSetBaseSample.Text = "设为基准样本";
            this.m_mniSetBaseSample.Click += new System.EventHandler(this.m_mniSetBaseSample_Click);
            // 
            // m_lsvSampleResult
            // 
            this.m_lsvSampleResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvSampleResult.CheckBoxes = true;
            this.m_lsvSampleResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chItem,
            this.m_chCheckResult});
            this.m_lsvSampleResult.FullRowSelect = true;
            this.m_lsvSampleResult.GridLines = true;
            this.m_lsvSampleResult.HideSelection = false;
            this.m_lsvSampleResult.Location = new System.Drawing.Point(516, 20);
            this.m_lsvSampleResult.Name = "m_lsvSampleResult";
            this.m_lsvSampleResult.Size = new System.Drawing.Size(236, 454);
            this.m_lsvSampleResult.TabIndex = 1;
            this.m_lsvSampleResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvSampleResult.View = System.Windows.Forms.View.Details;
            this.m_lsvSampleResult.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.m_lsvSampleResult_ItemCheck);
            // 
            // m_chItem
            // 
            this.m_chItem.Text = "项目";
            this.m_chItem.Width = 120;
            // 
            // m_chCheckResult
            // 
            this.m_chCheckResult.Text = "仪器结果";
            this.m_chCheckResult.Width = 100;
            // 
            // m_btnClear
            // 
            this.m_btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnClear.DefaultScheme = true;
            this.m_btnClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnClear.Hint = "";
            this.m_btnClear.Location = new System.Drawing.Point(868, 32);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnClear.Size = new System.Drawing.Size(80, 32);
            this.m_btnClear.TabIndex = 3;
            this.m_btnClear.Text = "重置";
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(726, 13);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(80, 32);
            this.m_btnSave.TabIndex = 5;
            this.m_btnSave.Text = "确定";
            this.m_btnSave.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_txtDeviceSampleID
            // 
            this.m_txtDeviceSampleID.Location = new System.Drawing.Point(456, 36);
            this.m_txtDeviceSampleID.MaxLength = 20;
            this.m_txtDeviceSampleID.Name = "m_txtDeviceSampleID";
            this.m_txtDeviceSampleID.Size = new System.Drawing.Size(96, 23);
            this.m_txtDeviceSampleID.TabIndex = 12;
            // 
            // m_cboLisDevice
            // 
            this.m_cboLisDevice.DisplayMember = "DEVICENAME_VCHR";
            this.m_cboLisDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboLisDevice.DropDownWidth = 96;
            this.m_cboLisDevice.Location = new System.Drawing.Point(260, 36);
            this.m_cboLisDevice.Name = "m_cboLisDevice";
            this.m_cboLisDevice.Size = new System.Drawing.Size(104, 22);
            this.m_cboLisDevice.TabIndex = 10;
            this.m_cboLisDevice.ValueMember = "DEVICEID_CHR";
            // 
            // m_lbCheckDat
            // 
            this.m_lbCheckDat.AutoSize = true;
            this.m_lbCheckDat.Location = new System.Drawing.Point(564, 40);
            this.m_lbCheckDat.Name = "m_lbCheckDat";
            this.m_lbCheckDat.Size = new System.Drawing.Size(63, 14);
            this.m_lbCheckDat.TabIndex = 15;
            this.m_lbCheckDat.Text = "检验日期";
            // 
            // m_dtpCheckDate
            // 
            this.m_dtpCheckDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpCheckDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCheckDate.Location = new System.Drawing.Point(632, 36);
            this.m_dtpCheckDate.Name = "m_dtpCheckDate";
            this.m_dtpCheckDate.Size = new System.Drawing.Size(104, 23);
            this.m_dtpCheckDate.TabIndex = 13;
            // 
            // m_lbCheckDevice
            // 
            this.m_lbCheckDevice.AutoSize = true;
            this.m_lbCheckDevice.Location = new System.Drawing.Point(196, 40);
            this.m_lbCheckDevice.Name = "m_lbCheckDevice";
            this.m_lbCheckDevice.Size = new System.Drawing.Size(63, 14);
            this.m_lbCheckDevice.TabIndex = 11;
            this.m_lbCheckDevice.Text = "检验仪器";
            // 
            // m_lbDeviceSampleID
            // 
            this.m_lbDeviceSampleID.AutoSize = true;
            this.m_lbDeviceSampleID.Location = new System.Drawing.Point(376, 40);
            this.m_lbDeviceSampleID.Name = "m_lbDeviceSampleID";
            this.m_lbDeviceSampleID.Size = new System.Drawing.Size(77, 14);
            this.m_lbDeviceSampleID.TabIndex = 14;
            this.m_lbDeviceSampleID.Text = "仪器样本号";
            // 
            // m_cboDeviceModel
            // 
            this.m_cboDeviceModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDeviceModel.Location = new System.Drawing.Point(80, 36);
            this.m_cboDeviceModel.Name = "m_cboDeviceModel";
            this.m_cboDeviceModel.Size = new System.Drawing.Size(104, 22);
            this.m_cboDeviceModel.TabIndex = 9;
            this.m_cboDeviceModel.SelectedIndexChanged += new System.EventHandler(this.m_cboDeviceModel_SelectedIndexChanged);
            // 
            // m_lbDeviceModel
            // 
            this.m_lbDeviceModel.AutoSize = true;
            this.m_lbDeviceModel.Location = new System.Drawing.Point(16, 40);
            this.m_lbDeviceModel.Name = "m_lbDeviceModel";
            this.m_lbDeviceModel.Size = new System.Drawing.Size(63, 14);
            this.m_lbDeviceModel.TabIndex = 39;
            this.m_lbDeviceModel.Text = "仪器类型";
            // 
            // m_grpQuery
            // 
            this.m_grpQuery.Controls.Add(this.m_btnQuery);
            this.m_grpQuery.Controls.Add(this.m_lbDeviceModel);
            this.m_grpQuery.Controls.Add(this.m_cboDeviceModel);
            this.m_grpQuery.Controls.Add(this.m_cboLisDevice);
            this.m_grpQuery.Controls.Add(this.m_lbCheckDevice);
            this.m_grpQuery.Controls.Add(this.m_lbDeviceSampleID);
            this.m_grpQuery.Controls.Add(this.m_lbCheckDat);
            this.m_grpQuery.Controls.Add(this.m_txtDeviceSampleID);
            this.m_grpQuery.Controls.Add(this.m_dtpCheckDate);
            this.m_grpQuery.Controls.Add(this.m_btnClear);
            this.m_grpQuery.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_grpQuery.Location = new System.Drawing.Point(0, 0);
            this.m_grpQuery.Name = "m_grpQuery";
            this.m_grpQuery.Size = new System.Drawing.Size(1012, 84);
            this.m_grpQuery.TabIndex = 41;
            this.m_grpQuery.TabStop = false;
            this.m_grpQuery.Text = "查询";
            // 
            // m_btnQuery
            // 
            this.m_btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQuery.DefaultScheme = true;
            this.m_btnQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQuery.Hint = "";
            this.m_btnQuery.Location = new System.Drawing.Point(772, 32);
            this.m_btnQuery.Name = "m_btnQuery";
            this.m_btnQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQuery.Size = new System.Drawing.Size(80, 32);
            this.m_btnQuery.TabIndex = 41;
            this.m_btnQuery.Text = "添加";
            this.m_btnQuery.Click += new System.EventHandler(this.m_btnQuery_Click);
            // 
            // m_lsvResultUnite
            // 
            this.m_lsvResultUnite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvResultUnite.CheckBoxes = true;
            this.m_lsvResultUnite.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chUnitItem,
            this.m_chUniteResult});
            this.m_lsvResultUnite.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvResultUnite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.m_lsvResultUnite.FullRowSelect = true;
            this.m_lsvResultUnite.GridLines = true;
            this.m_lsvResultUnite.HideSelection = false;
            this.m_lsvResultUnite.Location = new System.Drawing.Point(-20, -2);
            this.m_lsvResultUnite.MultiSelect = false;
            this.m_lsvResultUnite.Name = "m_lsvResultUnite";
            this.m_lsvResultUnite.Size = new System.Drawing.Size(252, 454);
            this.m_lsvResultUnite.TabIndex = 42;
            this.m_lsvResultUnite.UseCompatibleStateImageBehavior = false;
            this.m_lsvResultUnite.View = System.Windows.Forms.View.Details;
            // 
            // m_chUnitItem
            // 
            this.m_chUnitItem.Text = "   项目";
            this.m_chUnitItem.Width = 135;
            // 
            // m_chUniteResult
            // 
            this.m_chUniteResult.Text = "仪器结果";
            this.m_chUniteResult.Width = 100;
            // 
            // m_palBottom
            // 
            this.m_palBottom.Controls.Add(this.btnClose);
            this.m_palBottom.Controls.Add(this.m_btnCancel);
            this.m_palBottom.Controls.Add(this.m_btnSave);
            this.m_palBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_palBottom.Location = new System.Drawing.Point(0, 565);
            this.m_palBottom.Name = "m_palBottom";
            this.m_palBottom.Size = new System.Drawing.Size(1012, 68);
            this.m_palBottom.TabIndex = 43;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(918, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(80, 32);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCancel.DefaultScheme = true;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCancel.Hint = "";
            this.m_btnCancel.Location = new System.Drawing.Point(822, 13);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancel.Size = new System.Drawing.Size(80, 32);
            this.m_btnCancel.TabIndex = 6;
            this.m_btnCancel.Text = "取消";
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_palMiddle
            // 
            this.m_palMiddle.Controls.Add(this.panel1);
            this.m_palMiddle.Controls.Add(this.m_lsvSampleList);
            this.m_palMiddle.Controls.Add(this.m_lsvSampleResult);
            this.m_palMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_palMiddle.Location = new System.Drawing.Point(0, 84);
            this.m_palMiddle.Name = "m_palMiddle";
            this.m_palMiddle.Size = new System.Drawing.Size(1012, 481);
            this.m_palMiddle.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.m_lsvResultUnite);
            this.panel1.Location = new System.Drawing.Point(764, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(234, 454);
            this.panel1.TabIndex = 43;
            // 
            // frmSampleUnite
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1012, 633);
            this.Controls.Add(this.m_palMiddle);
            this.Controls.Add(this.m_palBottom);
            this.Controls.Add(this.m_grpQuery);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmSampleUnite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "样本融合";
            this.Load += new System.EventHandler(this.frmSampleUnite_Load);
            this.m_grpQuery.ResumeLayout(false);
            this.m_grpQuery.PerformLayout();
            this.m_palBottom.ResumeLayout(false);
            this.m_palMiddle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region CreateController
		public override void CreateController()
		{
			m_objController = new clsController_SampleUnite();
			m_objController.Set_GUI_Apperance(this);
		}
		#endregion

		#region 根据仪器类别查询对应的仪器列表
		private void m_cboDeviceModel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_cboDeviceModel.Items.Count <= 0)
				return;
			this.m_cboLisDevice.m_mthShowDeviceByModelID(new string[] {this.m_cboDeviceModel.SelectedValue.ToString().Trim()});
		}
		#endregion

		#region 查询
		private void m_btnQuery_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthGetDeviceSampleListByViewer();
		}
		#endregion

		#region 设为基准样本
		private void m_mniSetBaseSample_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthSetToBaseSample();
		}
		#endregion

		#region 保存融合后的结果
		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthSave();
			this.DialogResult = DialogResult.OK;
			if(this.m_objController.m_blnShowDialog)
				this.Close();
		}
		#endregion

		#region 清空
		private void m_btnClear_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthClear();
		}
		#endregion

		#region 取消
		private void m_btnCancel_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthCancel();
			this.DialogResult = DialogResult.Cancel;
			if(this.m_objController.m_blnShowDialog)
				this.Close();
		}
		#endregion

		#region 融合仪器结果
		private void m_lsvSampleResult_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(e.CurrentValue == System.Windows.Forms.CheckState.Unchecked)
			{
				m_objController.m_mthUniteDeviceCheckResult(e.Index);
			}
		}
		#endregion

		#region 初始化
		private void frmSampleUnite_Load(object sender, System.EventArgs e)
		{
			if(this.m_cboDeviceModel.Items.Count > 0)
			{
				this.m_cboLisDevice.m_mthShowDeviceByModelID(new string[] {this.m_cboDeviceModel.SelectedValue.ToString().Trim()});
			}
		}
		#endregion

		#region 获取仪器样本信息对应的仪器检验结果
		private void m_lsvSampleList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_objController.m_mthGetDeviceDataByDeviceSampleInfo();
		}
		#endregion

		public DialogResult m_objShowDialog(string p_strDeviceID, int p_intImportReq)
		{
			return this.m_objController.m_mthShow(p_intImportReq.ToString(),p_strDeviceID);
		}
		public clsDeviceReslutVO[] m_objGetSyncretizedResults()
		{
			return this.m_objController.m_objDeviceResultArr;
		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
