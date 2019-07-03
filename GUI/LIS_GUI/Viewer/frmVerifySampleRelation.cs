using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for frmVerifySampleRelation.
	/// </summary>
	public class frmVerifySampleRelation : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region FormControls
		com.digitalwave.iCare.gui.LIS.clsController_VerifySampleRelation m_objController;
		private System.Windows.Forms.ColumnHeader chdSampleLocation;
		internal System.Windows.Forms.ListView m_lsvDeviceResultImpReq;
		private System.Windows.Forms.Label m_lbDevice;
		private System.Windows.Forms.Label m_lbCheckDat;
		internal System.Windows.Forms.DateTimePicker m_dtpCheckDatFrom;
		private System.Windows.Forms.Label m_lbTo;
		internal System.Windows.Forms.DateTimePicker m_dtpCheckDatTo;
		private System.Windows.Forms.ColumnHeader m_chmImportSeq;
		private System.Windows.Forms.ColumnHeader m_chmDeviceSampleID;
		private System.Windows.Forms.ColumnHeader m_chmCheckDat;
		internal PinkieControls.ButtonXP m_btnQry;
		internal com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox m_cboDevice;
		private System.Windows.Forms.ContextMenu m_ctmResultImportReq;
		private System.Windows.Forms.TabControl m_tbcBatchAdjust;
		private System.Windows.Forms.TabPage m_tbpAdjustResultImportReq;
		private System.Windows.Forms.TabPage m_tbpAdjustDeviceRelation;
		private System.Windows.Forms.GroupBox m_gpbResultImpReqQuery;
		private System.Windows.Forms.GroupBox m_gpbDeviceRelationQry;
		internal System.Windows.Forms.ColumnHeader m_chCheckDat;
		internal System.Windows.Forms.ColumnHeader m_chDeviceSampleNO;
		private System.Windows.Forms.Label m_lbCheckDevice;
		internal com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox m_cboCheckDevice;
		private System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP m_btnQryDeviceRelation;
		internal PinkieControls.ButtonXP m_btnInvalidatDeviceRelation;
		internal System.Windows.Forms.ListView m_lsvDeviceRelation;
		internal System.Windows.Forms.ColumnHeader m_chSeq;
		internal PinkieControls.ButtonXP m_btnCancelDeviceRelation;
		internal System.Windows.Forms.DateTimePicker m_dtpReceptDatTo;
		internal System.Windows.Forms.DateTimePicker m_dtpReceptDatFrom;
		private System.Windows.Forms.Label m_lbReceptDate;
		internal System.Windows.Forms.ColumnHeader m_chReceptDat;
		internal System.Windows.Forms.ColumnHeader m_chSampleStatus;
		private System.Windows.Forms.MenuItem m_mniSampleUnite;
		internal System.Windows.Forms.ListView m_lsvDeviceCheckResult;
		private System.Windows.Forms.ColumnHeader m_chCheckItem;
		private System.Windows.Forms.ColumnHeader m_chResult;
		private System.Windows.Forms.ColumnHeader m_chCheckNo;
		private System.Windows.Forms.ColumnHeader m_chBandStatus;
        private PinkieControls.ButtonXP btnExit;
        private PinkieControls.ButtonXP btnExit1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmVerifySampleRelation()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.chdSampleLocation = new System.Windows.Forms.ColumnHeader();
            this.m_lsvDeviceResultImpReq = new System.Windows.Forms.ListView();
            this.m_chmImportSeq = new System.Windows.Forms.ColumnHeader();
            this.m_chmDeviceSampleID = new System.Windows.Forms.ColumnHeader();
            this.m_chmCheckDat = new System.Windows.Forms.ColumnHeader();
            this.m_ctmResultImportReq = new System.Windows.Forms.ContextMenu();
            this.m_mniSampleUnite = new System.Windows.Forms.MenuItem();
            this.m_lbDevice = new System.Windows.Forms.Label();
            this.m_lbCheckDat = new System.Windows.Forms.Label();
            this.m_gpbResultImpReqQuery = new System.Windows.Forms.GroupBox();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_cboDevice = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.m_btnQry = new PinkieControls.ButtonXP();
            this.m_dtpCheckDatTo = new System.Windows.Forms.DateTimePicker();
            this.m_lbTo = new System.Windows.Forms.Label();
            this.m_dtpCheckDatFrom = new System.Windows.Forms.DateTimePicker();
            this.m_tbcBatchAdjust = new System.Windows.Forms.TabControl();
            this.m_tbpAdjustResultImportReq = new System.Windows.Forms.TabPage();
            this.m_lsvDeviceCheckResult = new System.Windows.Forms.ListView();
            this.m_chCheckItem = new System.Windows.Forms.ColumnHeader();
            this.m_chResult = new System.Windows.Forms.ColumnHeader();
            this.m_tbpAdjustDeviceRelation = new System.Windows.Forms.TabPage();
            this.m_btnCancelDeviceRelation = new PinkieControls.ButtonXP();
            this.m_btnInvalidatDeviceRelation = new PinkieControls.ButtonXP();
            this.m_lsvDeviceRelation = new System.Windows.Forms.ListView();
            this.m_chSeq = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckNo = new System.Windows.Forms.ColumnHeader();
            this.m_chDeviceSampleNO = new System.Windows.Forms.ColumnHeader();
            this.m_chBandStatus = new System.Windows.Forms.ColumnHeader();
            this.m_chSampleStatus = new System.Windows.Forms.ColumnHeader();
            this.m_chReceptDat = new System.Windows.Forms.ColumnHeader();
            this.m_chCheckDat = new System.Windows.Forms.ColumnHeader();
            this.m_gpbDeviceRelationQry = new System.Windows.Forms.GroupBox();
            this.btnExit1 = new PinkieControls.ButtonXP();
            this.m_btnQryDeviceRelation = new PinkieControls.ButtonXP();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpReceptDatTo = new System.Windows.Forms.DateTimePicker();
            this.m_dtpReceptDatFrom = new System.Windows.Forms.DateTimePicker();
            this.m_lbReceptDate = new System.Windows.Forms.Label();
            this.m_cboCheckDevice = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.m_lbCheckDevice = new System.Windows.Forms.Label();
            this.m_gpbResultImpReqQuery.SuspendLayout();
            this.m_tbcBatchAdjust.SuspendLayout();
            this.m_tbpAdjustResultImportReq.SuspendLayout();
            this.m_tbpAdjustDeviceRelation.SuspendLayout();
            this.m_gpbDeviceRelationQry.SuspendLayout();
            this.SuspendLayout();
            // 
            // chdSampleLocation
            // 
            this.chdSampleLocation.Text = "架位号";
            // 
            // m_lsvDeviceResultImpReq
            // 
            this.m_lsvDeviceResultImpReq.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.m_lsvDeviceResultImpReq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lsvDeviceResultImpReq.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chmImportSeq,
            this.m_chmDeviceSampleID,
            this.m_chmCheckDat});
            this.m_lsvDeviceResultImpReq.ContextMenu = this.m_ctmResultImportReq;
            this.m_lsvDeviceResultImpReq.FullRowSelect = true;
            this.m_lsvDeviceResultImpReq.GridLines = true;
            this.m_lsvDeviceResultImpReq.HideSelection = false;
            this.m_lsvDeviceResultImpReq.Location = new System.Drawing.Point(12, 80);
            this.m_lsvDeviceResultImpReq.MultiSelect = false;
            this.m_lsvDeviceResultImpReq.Name = "m_lsvDeviceResultImpReq";
            this.m_lsvDeviceResultImpReq.Size = new System.Drawing.Size(488, 420);
            this.m_lsvDeviceResultImpReq.TabIndex = 0;
            this.m_lsvDeviceResultImpReq.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceResultImpReq.View = System.Windows.Forms.View.Details;
            this.m_lsvDeviceResultImpReq.SelectedIndexChanged += new System.EventHandler(this.m_lsvDeviceResultImpReq_SelectedIndexChanged);
            // 
            // m_chmImportSeq
            // 
            this.m_chmImportSeq.Text = "序号";
            this.m_chmImportSeq.Width = 86;
            // 
            // m_chmDeviceSampleID
            // 
            this.m_chmDeviceSampleID.Text = "仪器标本号";
            this.m_chmDeviceSampleID.Width = 134;
            // 
            // m_chmCheckDat
            // 
            this.m_chmCheckDat.Text = "检验时间";
            this.m_chmCheckDat.Width = 177;
            // 
            // m_ctmResultImportReq
            // 
            this.m_ctmResultImportReq.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mniSampleUnite});
            // 
            // m_mniSampleUnite
            // 
            this.m_mniSampleUnite.Index = 0;
            this.m_mniSampleUnite.Text = "融合标本";
            this.m_mniSampleUnite.Click += new System.EventHandler(this.m_mniSampleUnite_Click);
            // 
            // m_lbDevice
            // 
            this.m_lbDevice.AutoSize = true;
            this.m_lbDevice.Location = new System.Drawing.Point(12, 28);
            this.m_lbDevice.Name = "m_lbDevice";
            this.m_lbDevice.Size = new System.Drawing.Size(42, 14);
            this.m_lbDevice.TabIndex = 1;
            this.m_lbDevice.Text = "仪器:";
            // 
            // m_lbCheckDat
            // 
            this.m_lbCheckDat.AutoSize = true;
            this.m_lbCheckDat.Location = new System.Drawing.Point(204, 28);
            this.m_lbCheckDat.Name = "m_lbCheckDat";
            this.m_lbCheckDat.Size = new System.Drawing.Size(70, 14);
            this.m_lbCheckDat.TabIndex = 2;
            this.m_lbCheckDat.Text = "检验时间:";
            // 
            // m_gpbResultImpReqQuery
            // 
            this.m_gpbResultImpReqQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbResultImpReqQuery.Controls.Add(this.btnExit);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_cboDevice);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_btnQry);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_dtpCheckDatTo);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_lbTo);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_dtpCheckDatFrom);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_lbDevice);
            this.m_gpbResultImpReqQuery.Controls.Add(this.m_lbCheckDat);
            this.m_gpbResultImpReqQuery.Location = new System.Drawing.Point(12, 8);
            this.m_gpbResultImpReqQuery.Name = "m_gpbResultImpReqQuery";
            this.m_gpbResultImpReqQuery.Size = new System.Drawing.Size(972, 64);
            this.m_gpbResultImpReqQuery.TabIndex = 3;
            this.m_gpbResultImpReqQuery.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(670, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(80, 30);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "退出(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_cboDevice
            // 
            this.m_cboDevice.DisplayMember = "DEVICENAME_VCHR";
            this.m_cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDevice.Location = new System.Drawing.Point(56, 24);
            this.m_cboDevice.Name = "m_cboDevice";
            this.m_cboDevice.Size = new System.Drawing.Size(121, 22);
            this.m_cboDevice.TabIndex = 7;
            this.m_cboDevice.ValueMember = "DEVICEID_CHR";
            // 
            // m_btnQry
            // 
            this.m_btnQry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQry.DefaultScheme = true;
            this.m_btnQry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQry.Hint = "";
            this.m_btnQry.Location = new System.Drawing.Point(576, 20);
            this.m_btnQry.Name = "m_btnQry";
            this.m_btnQry.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQry.Size = new System.Drawing.Size(80, 30);
            this.m_btnQry.TabIndex = 6;
            this.m_btnQry.Text = "查询";
            this.m_btnQry.Click += new System.EventHandler(this.m_btnQry_Click);
            // 
            // m_dtpCheckDatTo
            // 
            this.m_dtpCheckDatTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpCheckDatTo.Location = new System.Drawing.Point(428, 24);
            this.m_dtpCheckDatTo.Name = "m_dtpCheckDatTo";
            this.m_dtpCheckDatTo.Size = new System.Drawing.Size(124, 23);
            this.m_dtpCheckDatTo.TabIndex = 5;
            // 
            // m_lbTo
            // 
            this.m_lbTo.AutoSize = true;
            this.m_lbTo.Location = new System.Drawing.Point(404, 28);
            this.m_lbTo.Name = "m_lbTo";
            this.m_lbTo.Size = new System.Drawing.Size(21, 14);
            this.m_lbTo.TabIndex = 4;
            this.m_lbTo.Text = "至";
            // 
            // m_dtpCheckDatFrom
            // 
            this.m_dtpCheckDatFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpCheckDatFrom.Location = new System.Drawing.Point(280, 24);
            this.m_dtpCheckDatFrom.Name = "m_dtpCheckDatFrom";
            this.m_dtpCheckDatFrom.Size = new System.Drawing.Size(120, 23);
            this.m_dtpCheckDatFrom.TabIndex = 3;
            // 
            // m_tbcBatchAdjust
            // 
            this.m_tbcBatchAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tbcBatchAdjust.Controls.Add(this.m_tbpAdjustResultImportReq);
            this.m_tbcBatchAdjust.Controls.Add(this.m_tbpAdjustDeviceRelation);
            this.m_tbcBatchAdjust.Location = new System.Drawing.Point(8, 8);
            this.m_tbcBatchAdjust.Name = "m_tbcBatchAdjust";
            this.m_tbcBatchAdjust.SelectedIndex = 0;
            this.m_tbcBatchAdjust.Size = new System.Drawing.Size(1000, 544);
            this.m_tbcBatchAdjust.TabIndex = 9;
            // 
            // m_tbpAdjustResultImportReq
            // 
            this.m_tbpAdjustResultImportReq.Controls.Add(this.m_lsvDeviceCheckResult);
            this.m_tbpAdjustResultImportReq.Controls.Add(this.m_gpbResultImpReqQuery);
            this.m_tbpAdjustResultImportReq.Controls.Add(this.m_lsvDeviceResultImpReq);
            this.m_tbpAdjustResultImportReq.Location = new System.Drawing.Point(4, 23);
            this.m_tbpAdjustResultImportReq.Name = "m_tbpAdjustResultImportReq";
            this.m_tbpAdjustResultImportReq.Size = new System.Drawing.Size(992, 517);
            this.m_tbpAdjustResultImportReq.TabIndex = 0;
            this.m_tbpAdjustResultImportReq.Text = "调整结果数据";
            // 
            // m_lsvDeviceCheckResult
            // 
            this.m_lsvDeviceCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvDeviceCheckResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chCheckItem,
            this.m_chResult});
            this.m_lsvDeviceCheckResult.FullRowSelect = true;
            this.m_lsvDeviceCheckResult.GridLines = true;
            this.m_lsvDeviceCheckResult.HideSelection = false;
            this.m_lsvDeviceCheckResult.Location = new System.Drawing.Point(508, 80);
            this.m_lsvDeviceCheckResult.Name = "m_lsvDeviceCheckResult";
            this.m_lsvDeviceCheckResult.Size = new System.Drawing.Size(476, 420);
            this.m_lsvDeviceCheckResult.TabIndex = 4;
            this.m_lsvDeviceCheckResult.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceCheckResult.View = System.Windows.Forms.View.Details;
            // 
            // m_chCheckItem
            // 
            this.m_chCheckItem.Text = "检验项目";
            this.m_chCheckItem.Width = 134;
            // 
            // m_chResult
            // 
            this.m_chResult.Text = "检验结果";
            this.m_chResult.Width = 136;
            // 
            // m_tbpAdjustDeviceRelation
            // 
            this.m_tbpAdjustDeviceRelation.Controls.Add(this.m_btnCancelDeviceRelation);
            this.m_tbpAdjustDeviceRelation.Controls.Add(this.m_btnInvalidatDeviceRelation);
            this.m_tbpAdjustDeviceRelation.Controls.Add(this.m_lsvDeviceRelation);
            this.m_tbpAdjustDeviceRelation.Controls.Add(this.m_gpbDeviceRelationQry);
            this.m_tbpAdjustDeviceRelation.Location = new System.Drawing.Point(4, 23);
            this.m_tbpAdjustDeviceRelation.Name = "m_tbpAdjustDeviceRelation";
            this.m_tbpAdjustDeviceRelation.Size = new System.Drawing.Size(992, 517);
            this.m_tbpAdjustDeviceRelation.TabIndex = 1;
            this.m_tbpAdjustDeviceRelation.Text = "数据与样本关系调整";
            // 
            // m_btnCancelDeviceRelation
            // 
            this.m_btnCancelDeviceRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancelDeviceRelation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnCancelDeviceRelation.DefaultScheme = true;
            this.m_btnCancelDeviceRelation.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCancelDeviceRelation.Hint = "";
            this.m_btnCancelDeviceRelation.Location = new System.Drawing.Point(848, 464);
            this.m_btnCancelDeviceRelation.Name = "m_btnCancelDeviceRelation";
            this.m_btnCancelDeviceRelation.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCancelDeviceRelation.Size = new System.Drawing.Size(112, 32);
            this.m_btnCancelDeviceRelation.TabIndex = 8;
            this.m_btnCancelDeviceRelation.Text = "取消绑定";
            this.m_btnCancelDeviceRelation.Click += new System.EventHandler(this.m_btnCancelDeviceRelation_Click);
            // 
            // m_btnInvalidatDeviceRelation
            // 
            this.m_btnInvalidatDeviceRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnInvalidatDeviceRelation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnInvalidatDeviceRelation.DefaultScheme = true;
            this.m_btnInvalidatDeviceRelation.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnInvalidatDeviceRelation.Hint = "";
            this.m_btnInvalidatDeviceRelation.Location = new System.Drawing.Point(716, 464);
            this.m_btnInvalidatDeviceRelation.Name = "m_btnInvalidatDeviceRelation";
            this.m_btnInvalidatDeviceRelation.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnInvalidatDeviceRelation.Size = new System.Drawing.Size(112, 32);
            this.m_btnInvalidatDeviceRelation.TabIndex = 7;
            this.m_btnInvalidatDeviceRelation.Text = "作废关联";
            this.m_btnInvalidatDeviceRelation.Click += new System.EventHandler(this.m_btnInvalidatDeviceRelation_Click);
            // 
            // m_lsvDeviceRelation
            // 
            this.m_lsvDeviceRelation.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.m_lsvDeviceRelation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvDeviceRelation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chSeq,
            this.m_chCheckNo,
            this.m_chDeviceSampleNO,
            this.m_chBandStatus,
            this.m_chSampleStatus,
            this.m_chReceptDat,
            this.m_chCheckDat});
            this.m_lsvDeviceRelation.FullRowSelect = true;
            this.m_lsvDeviceRelation.GridLines = true;
            this.m_lsvDeviceRelation.HideSelection = false;
            this.m_lsvDeviceRelation.Location = new System.Drawing.Point(12, 80);
            this.m_lsvDeviceRelation.Name = "m_lsvDeviceRelation";
            this.m_lsvDeviceRelation.Size = new System.Drawing.Size(972, 372);
            this.m_lsvDeviceRelation.TabIndex = 1;
            this.m_lsvDeviceRelation.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceRelation.View = System.Windows.Forms.View.Details;
            // 
            // m_chSeq
            // 
            this.m_chSeq.Text = "序号";
            this.m_chSeq.Width = 80;
            // 
            // m_chCheckNo
            // 
            this.m_chCheckNo.Text = "检验编号";
            this.m_chCheckNo.Width = 150;
            // 
            // m_chDeviceSampleNO
            // 
            this.m_chDeviceSampleNO.Text = "仪器样本号";
            this.m_chDeviceSampleNO.Width = 100;
            // 
            // m_chBandStatus
            // 
            this.m_chBandStatus.Text = "绑定状态";
            this.m_chBandStatus.Width = 100;
            // 
            // m_chSampleStatus
            // 
            this.m_chSampleStatus.Text = "标本状态";
            this.m_chSampleStatus.Width = 80;
            // 
            // m_chReceptDat
            // 
            this.m_chReceptDat.Text = "关联时间";
            this.m_chReceptDat.Width = 150;
            // 
            // m_chCheckDat
            // 
            this.m_chCheckDat.Text = "仪器检验时间";
            this.m_chCheckDat.Width = 150;
            // 
            // m_gpbDeviceRelationQry
            // 
            this.m_gpbDeviceRelationQry.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_gpbDeviceRelationQry.Controls.Add(this.btnExit1);
            this.m_gpbDeviceRelationQry.Controls.Add(this.m_btnQryDeviceRelation);
            this.m_gpbDeviceRelationQry.Controls.Add(this.label1);
            this.m_gpbDeviceRelationQry.Controls.Add(this.m_dtpReceptDatTo);
            this.m_gpbDeviceRelationQry.Controls.Add(this.m_dtpReceptDatFrom);
            this.m_gpbDeviceRelationQry.Controls.Add(this.m_lbReceptDate);
            this.m_gpbDeviceRelationQry.Controls.Add(this.m_cboCheckDevice);
            this.m_gpbDeviceRelationQry.Controls.Add(this.m_lbCheckDevice);
            this.m_gpbDeviceRelationQry.Location = new System.Drawing.Point(12, 8);
            this.m_gpbDeviceRelationQry.Name = "m_gpbDeviceRelationQry";
            this.m_gpbDeviceRelationQry.Size = new System.Drawing.Size(972, 64);
            this.m_gpbDeviceRelationQry.TabIndex = 0;
            this.m_gpbDeviceRelationQry.TabStop = false;
            // 
            // btnExit1
            // 
            this.btnExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit1.DefaultScheme = true;
            this.btnExit1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit1.Hint = "";
            this.btnExit1.Location = new System.Drawing.Point(670, 20);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit1.Size = new System.Drawing.Size(80, 30);
            this.btnExit1.TabIndex = 7;
            this.btnExit1.Text = "退出(&C)";
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // m_btnQryDeviceRelation
            // 
            this.m_btnQryDeviceRelation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQryDeviceRelation.DefaultScheme = true;
            this.m_btnQryDeviceRelation.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQryDeviceRelation.Hint = "";
            this.m_btnQryDeviceRelation.Location = new System.Drawing.Point(575, 20);
            this.m_btnQryDeviceRelation.Name = "m_btnQryDeviceRelation";
            this.m_btnQryDeviceRelation.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQryDeviceRelation.Size = new System.Drawing.Size(80, 30);
            this.m_btnQryDeviceRelation.TabIndex = 6;
            this.m_btnQryDeviceRelation.Text = "查询";
            this.m_btnQryDeviceRelation.Click += new System.EventHandler(this.m_btnQryDeviceRelation_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(404, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "至";
            // 
            // m_dtpReceptDatTo
            // 
            this.m_dtpReceptDatTo.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpReceptDatTo.Location = new System.Drawing.Point(424, 24);
            this.m_dtpReceptDatTo.Name = "m_dtpReceptDatTo";
            this.m_dtpReceptDatTo.Size = new System.Drawing.Size(120, 23);
            this.m_dtpReceptDatTo.TabIndex = 4;
            // 
            // m_dtpReceptDatFrom
            // 
            this.m_dtpReceptDatFrom.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.m_dtpReceptDatFrom.Location = new System.Drawing.Point(280, 24);
            this.m_dtpReceptDatFrom.Name = "m_dtpReceptDatFrom";
            this.m_dtpReceptDatFrom.Size = new System.Drawing.Size(120, 23);
            this.m_dtpReceptDatFrom.TabIndex = 3;
            // 
            // m_lbReceptDate
            // 
            this.m_lbReceptDate.AutoSize = true;
            this.m_lbReceptDate.Location = new System.Drawing.Point(204, 28);
            this.m_lbReceptDate.Name = "m_lbReceptDate";
            this.m_lbReceptDate.Size = new System.Drawing.Size(70, 14);
            this.m_lbReceptDate.TabIndex = 2;
            this.m_lbReceptDate.Text = "关联时间:";
            // 
            // m_cboCheckDevice
            // 
            this.m_cboCheckDevice.DisplayMember = "DEVICENAME_VCHR";
            this.m_cboCheckDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckDevice.Location = new System.Drawing.Point(56, 24);
            this.m_cboCheckDevice.Name = "m_cboCheckDevice";
            this.m_cboCheckDevice.Size = new System.Drawing.Size(121, 22);
            this.m_cboCheckDevice.TabIndex = 1;
            this.m_cboCheckDevice.ValueMember = "DEVICEID_CHR";
            // 
            // m_lbCheckDevice
            // 
            this.m_lbCheckDevice.AutoSize = true;
            this.m_lbCheckDevice.Location = new System.Drawing.Point(12, 28);
            this.m_lbCheckDevice.Name = "m_lbCheckDevice";
            this.m_lbCheckDevice.Size = new System.Drawing.Size(42, 14);
            this.m_lbCheckDevice.TabIndex = 0;
            this.m_lbCheckDevice.Text = "仪器:";
            // 
            // frmVerifySampleRelation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1024, 573);
            this.Controls.Add(this.m_tbcBatchAdjust);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmVerifySampleRelation";
            this.Text = "批量调整";
            this.Load += new System.EventHandler(this.frmVerifySampleRelation_Load);
            this.m_gpbResultImpReqQuery.ResumeLayout(false);
            this.m_gpbResultImpReqQuery.PerformLayout();
            this.m_tbcBatchAdjust.ResumeLayout(false);
            this.m_tbpAdjustResultImportReq.ResumeLayout(false);
            this.m_tbpAdjustDeviceRelation.ResumeLayout(false);
            this.m_gpbDeviceRelationQry.ResumeLayout(false);
            this.m_gpbDeviceRelationQry.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		#region CreateController
		public override void CreateController()
		{
			m_objController = new com.digitalwave.iCare.gui.LIS.clsController_VerifySampleRelation();
			m_objController.Set_GUI_Apperance(this);
		}
		#endregion

		#region 查询
		private void m_btnQry_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthGetResultImportReqByCondition();
		}
		#endregion

		#region 根据条件查询仪器与样本之间的关系(标本状态：未作废，未审核和未退回) 童华 2004.07.26
		private void m_btnQryDeviceRelation_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthGetDeviceRelationVOArrByCondition();
		}
		#endregion

		#region 取消仪器样本关系
		private void m_btnCancelDeviceRelation_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthCancelDeviceRelation();
		}
		#endregion
 
		#region 作废仪器样本关系
		private void m_btnInvalidatDeviceRelation_Click(object sender, System.EventArgs e)
		{
			m_objController.m_mthInValidatDeviceRelation();
		}
		#endregion

		#region 初始化窗体
		private void frmVerifySampleRelation_Load(object sender, System.EventArgs e)
		{
			m_objController.m_mthOnViewerLoad();
		}
		#endregion

		#region 融合标本
		private void m_mniSampleUnite_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvDeviceResultImpReq.SelectedItems.Count <= 0)
				return;
			clsLisResultImportReq_VO objRecord = (clsLisResultImportReq_VO)this.m_lsvDeviceResultImpReq.SelectedItems[0].Tag;
			frmSampleUnite objfrmSampleUnite = new frmSampleUnite();
			objfrmSampleUnite.m_objController.m_mthShow(objRecord.m_strIMPORT_REQ_INT,objRecord.m_strDEVICEID_CHR);
		}
		#endregion		

		#region 查询仪器样本对应的仪器结果
		private void m_lsvDeviceResultImpReq_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_objController.m_mthGetDeviceResult();
		}
		#endregion

        #region 退出
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
	}
}
