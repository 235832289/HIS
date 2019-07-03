using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using PinkieControls;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmLisDeviceManage 的摘要说明。
	/// </summary>
	public class frmLisDeviceManage : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件声名
		internal System.Windows.Forms.ComboBox m_cboCategory;
		internal System.Windows.Forms.ColumnHeader clmDeviceModel;
		internal System.Windows.Forms.ListView m_lsvDeviceList;
		internal System.Windows.Forms.ListView m_lsvCheckItem;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ColumnHeader columnHeader1;
		internal System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ColumnHeader clmDeviceChckItemName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		internal System.Windows.Forms.ListView m_lsvBaseCheckItem;
		internal System.Windows.Forms.ComboBox m_cboCheckItemType;
		private PinkieControls.ButtonXP m_cmdAppend;
		internal System.Windows.Forms.TextBox m_txtDeviceItemName;
//		private System.Windows.Forms.Button m_cmdSave;
		private PinkieControls.ButtonXP m_cmdSave;
		private PinkieControls.ButtonXP m_cmdDelete;
		internal System.Windows.Forms.TextBox m_txtBaseCheckItemName;
		private System.Windows.Forms.TabControl m_tabDeviceManage;
		private System.Windows.Forms.TabPage m_tpDeviceCheckItemRelation;
		private System.Windows.Forms.TabPage m_tpDeviceSerial;
		private System.Windows.Forms.TabPage m_tpDevice;
		internal System.Windows.Forms.TabPage m_tpDeviceModel;
		private System.Windows.Forms.Label m_lbDeviceModel;
		internal System.Windows.Forms.TextBox m_txtDeviceModel;
		private System.Windows.Forms.Label m_lbDeviceCategory;
		internal System.Windows.Forms.ComboBox m_cboDeviceCategory;
		private System.Windows.Forms.Label m_lbVendor;
		internal System.Windows.Forms.ComboBox m_cboVendor;
		private System.Windows.Forms.Label m_lbStandardCode1;
		internal System.Windows.Forms.TextBox m_txtStandardCode1;
		private System.Windows.Forms.Label m_lbStandardCode2;
		internal System.Windows.Forms.TextBox m_txtStandardCode2;
		internal System.Windows.Forms.ListView m_lsvDeviceModel;
		private System.Windows.Forms.ColumnHeader m_chDeviceModelDec;
		private System.Windows.Forms.ColumnHeader m_chDeviceCategory;
		private System.Windows.Forms.ColumnHeader m_chVendor;
		private System.Windows.Forms.ColumnHeader m_chStandardCode1;
		private System.Windows.Forms.ColumnHeader m_chStandardCode2;
		internal PinkieControls.ButtonXP m_btnSaveDeviceModel;
		internal PinkieControls.ButtonXP m_btnDelDeviceModel;
		private System.Windows.Forms.Label m_lbSerialDeviceModel;
		internal System.Windows.Forms.ComboBox m_cboSerailDeviceModel;
		private System.Windows.Forms.Label m_lbComNo;
		internal System.Windows.Forms.ComboBox m_cboComNo;
		private System.Windows.Forms.Label m_lbBaulRate;
		internal System.Windows.Forms.TextBox m_txtBaulRate;
		private System.Windows.Forms.Label m_lbDataBit;
		private System.Windows.Forms.Label m_lbStopBit;
		private System.Windows.Forms.Label m_lbParity;
		private System.Windows.Forms.Label m_lbFlowControl;
		private System.Windows.Forms.Label m_lbReceiveBuffer;
		internal System.Windows.Forms.TextBox m_txtReceiveBuffer;
		private System.Windows.Forms.Label m_lbSendBuffer;
		internal System.Windows.Forms.TextBox m_txtSendBuffer;
		private System.Windows.Forms.Label m_lbSendCommand;
		internal System.Windows.Forms.TextBox m_txtSendCommand;
		private System.Windows.Forms.Label m_lbSendCommandInternal;
		internal System.Windows.Forms.TextBox m_txtSendCommandInternal;
		private System.Windows.Forms.Label m_lbDataAnalysisDll;
		internal System.Windows.Forms.TextBox m_txtDataAnalysisDll;
		private System.Windows.Forms.Label m_lbDataAnalysisNameSpace;
		internal System.Windows.Forms.TextBox m_txtDataAnalysisNameSpace;
		internal System.Windows.Forms.ListView m_lsvDeviceSerialSetUp;
		private System.Windows.Forms.ColumnHeader m_chSerialDeviceModel;
		private System.Windows.Forms.ColumnHeader m_chComNo;
		private System.Windows.Forms.ColumnHeader m_chBaulRate;
		private System.Windows.Forms.ColumnHeader m_chDataBit;
		private System.Windows.Forms.ColumnHeader m_chStopBit;
		private System.Windows.Forms.ColumnHeader m_chParity;
		private System.Windows.Forms.ColumnHeader m_chReceiveBuffer;
		private System.Windows.Forms.ColumnHeader m_chSendBuffer;
		private System.Windows.Forms.ColumnHeader m_chDllName;
		private System.Windows.Forms.ColumnHeader m_chNameSpace;
		internal PinkieControls.ButtonXP m_btnAddDeviceModel;
		private PinkieControls.ButtonXP m_btnAddDeviceSerial;
		private PinkieControls.ButtonXP m_btnSaveDeviceSerial;
		private PinkieControls.ButtonXP m_btnDelDeviceSerial;
		internal System.Windows.Forms.TextBox m_txtDeviceModelID;
		private System.Windows.Forms.Label m_lbDeviceModelName;
		internal System.Windows.Forms.ComboBox m_cboDeviceModelName;
		private System.Windows.Forms.Label m_lbReceiveComputerIP;
		internal System.Windows.Forms.TextBox m_txtDataReceiveComputerIP;
		private System.Windows.Forms.Label m_lbDeviceBeginDat;
		internal System.Windows.Forms.DateTimePicker m_dtpFromDat;
		private System.Windows.Forms.Label m_lbDeviceStopDat;
		internal System.Windows.Forms.DateTimePicker m_dtpToDat;
		private System.Windows.Forms.Label m_lbDeviceName;
		internal System.Windows.Forms.TextBox m_txtDeviceName;
		private System.Windows.Forms.Label m_lbDevicePlace;
		internal System.Windows.Forms.TextBox m_txtDevicePlace;
		private System.Windows.Forms.Label m_lbDept;
		internal System.Windows.Forms.CheckBox m_chkIsDataTrans;
		private System.Windows.Forms.Label m_lbDeviceIP;
		internal System.Windows.Forms.TextBox m_txtDeviceIP;
		internal com.digitalwave.Utility.ctlDeptTextBox m_txtDept;
		internal System.Windows.Forms.ListView m_lsvDevice;
		private System.Windows.Forms.ColumnHeader m_chDeviceName;
		private System.Windows.Forms.ColumnHeader m_chDeviceModel;
		private System.Windows.Forms.ColumnHeader m_chDevicePlace;
		private System.Windows.Forms.ColumnHeader m_chDept;
		private System.Windows.Forms.ColumnHeader m_chDataReceiveIP;
		private System.Windows.Forms.ColumnHeader m_chDeviceBeginDat;
		private System.Windows.Forms.ColumnHeader m_chDeviceEndDat;
		private PinkieControls.ButtonXP m_btnAddDevice;
		private PinkieControls.ButtonXP m_btnSaveDevice;
		private PinkieControls.ButtonXP m_btnDelDevice;
		internal System.Windows.Forms.CheckBox m_chkStopDat;
		private System.Windows.Forms.TabPage m_tpDeviceCheckItem;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ColumnHeader m_chDeviceModela;
		private System.Windows.Forms.GroupBox gpbDeviceModel;
		internal System.Windows.Forms.ListView m_lsvDeviceCheckItem;
		private System.Windows.Forms.ColumnHeader m_chDeviceCheckItemName;
		private System.Windows.Forms.ColumnHeader m_chHasGraph;
		private System.Windows.Forms.GroupBox m_gpbDeviceCheckItemDetail;
		private System.Windows.Forms.Label m_lbDeviceCheckItemName;
		internal System.Windows.Forms.TextBox m_txtDeviceCheckItemName;
		internal System.Windows.Forms.CheckBox m_chkHasGraph;
		private System.Windows.Forms.GroupBox m_gpbDeviceModel;
		private System.Windows.Forms.GroupBox m_gbpDevice;
		private System.Windows.Forms.GroupBox m_gpbDevicePara;
		private PinkieControls.ButtonXP m_btnAddDeviceCheckItem;
		private PinkieControls.ButtonXP m_btnSaveDeviceCheckItem;
		private PinkieControls.ButtonXP m_btnDelDeviceCheckItem;
		internal System.Windows.Forms.ComboBox m_cboDCIDeviceCategory;
		internal System.Windows.Forms.ListView m_lsvDCIDeviceModel;
		internal System.Windows.Forms.ColumnHeader m_chmCheckItemName;
		internal System.Windows.Forms.ColumnHeader m_chmEnglishName;
		internal System.Windows.Forms.ColumnHeader m_chmShortName;
		private System.Windows.Forms.ColumnHeader m_chmHasGraph;
		internal System.Windows.Forms.ListView m_lsvCheckItemDeviceCheckItem;
		internal System.Windows.Forms.TextBox m_txtRelationDeviceModel;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox m_txtSourceCheckItem;
		#endregion
		private System.Windows.Forms.ColumnHeader m_chDeviceCode;
		private System.Windows.Forms.Label m_lbDeviceCode;
		internal System.Windows.Forms.TextBox m_txtDeviceCode;
		internal System.Windows.Forms.ComboBox m_cboDataBit;
		internal System.Windows.Forms.ComboBox m_cboStopBit;
		internal System.Windows.Forms.ComboBox m_cboParity;
		internal System.Windows.Forms.ComboBox m_cboFlowControl;
		internal System.Windows.Forms.ComboBox m_cboBaulRate;
		private System.Windows.Forms.Label label7;
		internal System.Windows.Forms.CheckBox m_chkHex;
        private ButtonXP btnExit0;
        private ButtonXP btnExit1;
        private ButtonXP btnExit2;
        private ButtonXP btnExit3;
        private ButtonXP btnExit4;
        internal CheckBox m_chkQCItem;
        private ColumnHeader m_chQCItem;
        private TabPage m_tpSpecialDevice;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        internal CheckBox m_chkAutoRead;
        internal CheckBox m_chkMatterDriver;
        internal CheckBox m_chkHandDriver;
        internal TextBox m_txtSpecialDeviceClass;
        private Label label32;
        internal TextBox m_txtSpecialDeviceDll;
        private Label label31;
        internal TextBox m_txtSpecialDeviceOtherSet;
        private Label label30;
        internal TextBox m_txtSpecialDevicePath;
        private Label label29;
        internal TextBox m_txtSpecialDeviceInterval;
        private Label label28;
        private Label label27;
        internal TextBox m_txtSpecialDeviceDSN;
        private Label label26;
        internal ComboBox m_cboSpecialDeviceConnection;
        private Label label25;
        private Label label24;
        internal ComboBox m_cboSpecialDeviceModelID;
        private ButtonXP m_btnExitSpecialDevice;
        private ButtonXP m_btnDelSpecialDevice;
        private ButtonXP m_btnSaveSpecialDevice;
        private ButtonXP m_btnAddSpecialDevice;
        internal ListView m_lstSpecialDevice;
        private ColumnHeader m_chSpecialDeviceModel;
        private ColumnHeader m_chSpecialDeviceConnection;
        private ColumnHeader m_chSpecialDeviceDSN;
        private ColumnHeader m_chSpecialDeviceWork;
        private ColumnHeader m_chSpecialDeviceInterval;
        private ColumnHeader m_chSpecialDevicePict;
        private ColumnHeader m_chSpecialDeviceOtherSet;
        private ColumnHeader m_chSpecialDeviceDLL;
        private ColumnHeader m_thSpecialDeviceClass;


		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLisDeviceManage()
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
            this.m_tabDeviceManage = new System.Windows.Forms.TabControl();
            this.m_tpDeviceModel = new System.Windows.Forms.TabPage();
            this.btnExit0 = new PinkieControls.ButtonXP();
            this.m_gpbDeviceModel = new System.Windows.Forms.GroupBox();
            this.m_lbDeviceModel = new System.Windows.Forms.Label();
            this.m_txtStandardCode1 = new System.Windows.Forms.TextBox();
            this.m_cboDeviceCategory = new System.Windows.Forms.ComboBox();
            this.m_lbStandardCode2 = new System.Windows.Forms.Label();
            this.m_txtStandardCode2 = new System.Windows.Forms.TextBox();
            this.m_lbStandardCode1 = new System.Windows.Forms.Label();
            this.m_cboVendor = new System.Windows.Forms.ComboBox();
            this.m_lbVendor = new System.Windows.Forms.Label();
            this.m_lbDeviceCategory = new System.Windows.Forms.Label();
            this.m_txtDeviceModel = new System.Windows.Forms.TextBox();
            this.m_btnDelDeviceModel = new PinkieControls.ButtonXP();
            this.m_btnSaveDeviceModel = new PinkieControls.ButtonXP();
            this.m_btnAddDeviceModel = new PinkieControls.ButtonXP();
            this.m_lsvDeviceModel = new System.Windows.Forms.ListView();
            this.m_chDeviceModelDec = new System.Windows.Forms.ColumnHeader();
            this.m_chDeviceCategory = new System.Windows.Forms.ColumnHeader();
            this.m_chVendor = new System.Windows.Forms.ColumnHeader();
            this.m_chStandardCode1 = new System.Windows.Forms.ColumnHeader();
            this.m_chStandardCode2 = new System.Windows.Forms.ColumnHeader();
            this.m_tpDeviceSerial = new System.Windows.Forms.TabPage();
            this.btnExit1 = new PinkieControls.ButtonXP();
            this.m_gpbDevicePara = new System.Windows.Forms.GroupBox();
            this.m_chkHex = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtSendCommand = new System.Windows.Forms.TextBox();
            this.m_cboBaulRate = new System.Windows.Forms.ComboBox();
            this.m_cboFlowControl = new System.Windows.Forms.ComboBox();
            this.m_cboParity = new System.Windows.Forms.ComboBox();
            this.m_cboStopBit = new System.Windows.Forms.ComboBox();
            this.m_cboDataBit = new System.Windows.Forms.ComboBox();
            this.m_txtBaulRate = new System.Windows.Forms.TextBox();
            this.m_txtDataAnalysisNameSpace = new System.Windows.Forms.TextBox();
            this.m_lbBaulRate = new System.Windows.Forms.Label();
            this.m_lbComNo = new System.Windows.Forms.Label();
            this.m_lbDataAnalysisNameSpace = new System.Windows.Forms.Label();
            this.m_lbSerialDeviceModel = new System.Windows.Forms.Label();
            this.m_lbDataAnalysisDll = new System.Windows.Forms.Label();
            this.m_cboSerailDeviceModel = new System.Windows.Forms.ComboBox();
            this.m_lbSendCommand = new System.Windows.Forms.Label();
            this.m_txtSendBuffer = new System.Windows.Forms.TextBox();
            this.m_lbSendBuffer = new System.Windows.Forms.Label();
            this.m_cboComNo = new System.Windows.Forms.ComboBox();
            this.m_txtDeviceModelID = new System.Windows.Forms.TextBox();
            this.m_txtSendCommandInternal = new System.Windows.Forms.TextBox();
            this.m_lbFlowControl = new System.Windows.Forms.Label();
            this.m_lbDataBit = new System.Windows.Forms.Label();
            this.m_lbSendCommandInternal = new System.Windows.Forms.Label();
            this.m_lbReceiveBuffer = new System.Windows.Forms.Label();
            this.m_txtReceiveBuffer = new System.Windows.Forms.TextBox();
            this.m_txtDataAnalysisDll = new System.Windows.Forms.TextBox();
            this.m_lbStopBit = new System.Windows.Forms.Label();
            this.m_lbParity = new System.Windows.Forms.Label();
            this.m_btnDelDeviceSerial = new PinkieControls.ButtonXP();
            this.m_btnSaveDeviceSerial = new PinkieControls.ButtonXP();
            this.m_btnAddDeviceSerial = new PinkieControls.ButtonXP();
            this.m_lsvDeviceSerialSetUp = new System.Windows.Forms.ListView();
            this.m_chSerialDeviceModel = new System.Windows.Forms.ColumnHeader();
            this.m_chComNo = new System.Windows.Forms.ColumnHeader();
            this.m_chBaulRate = new System.Windows.Forms.ColumnHeader();
            this.m_chDataBit = new System.Windows.Forms.ColumnHeader();
            this.m_chStopBit = new System.Windows.Forms.ColumnHeader();
            this.m_chParity = new System.Windows.Forms.ColumnHeader();
            this.m_chReceiveBuffer = new System.Windows.Forms.ColumnHeader();
            this.m_chSendBuffer = new System.Windows.Forms.ColumnHeader();
            this.m_chDllName = new System.Windows.Forms.ColumnHeader();
            this.m_chNameSpace = new System.Windows.Forms.ColumnHeader();
            this.m_tpSpecialDevice = new System.Windows.Forms.TabPage();
            this.m_btnExitSpecialDevice = new PinkieControls.ButtonXP();
            this.m_btnDelSpecialDevice = new PinkieControls.ButtonXP();
            this.m_btnSaveSpecialDevice = new PinkieControls.ButtonXP();
            this.m_btnAddSpecialDevice = new PinkieControls.ButtonXP();
            this.m_lstSpecialDevice = new System.Windows.Forms.ListView();
            this.m_chSpecialDeviceModel = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDeviceConnection = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDeviceDSN = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDeviceWork = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDeviceInterval = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDevicePict = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDeviceOtherSet = new System.Windows.Forms.ColumnHeader();
            this.m_chSpecialDeviceDLL = new System.Windows.Forms.ColumnHeader();
            this.m_thSpecialDeviceClass = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.m_chkAutoRead = new System.Windows.Forms.CheckBox();
            this.m_chkMatterDriver = new System.Windows.Forms.CheckBox();
            this.m_chkHandDriver = new System.Windows.Forms.CheckBox();
            this.m_txtSpecialDeviceClass = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.m_txtSpecialDeviceDll = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.m_txtSpecialDeviceOtherSet = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.m_txtSpecialDevicePath = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.m_txtSpecialDeviceInterval = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.m_txtSpecialDeviceDSN = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.m_cboSpecialDeviceConnection = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_cboSpecialDeviceModelID = new System.Windows.Forms.ComboBox();
            this.m_tpDeviceCheckItem = new System.Windows.Forms.TabPage();
            this.m_gpbDeviceCheckItemDetail = new System.Windows.Forms.GroupBox();
            this.m_chkQCItem = new System.Windows.Forms.CheckBox();
            this.btnExit2 = new PinkieControls.ButtonXP();
            this.m_btnDelDeviceCheckItem = new PinkieControls.ButtonXP();
            this.m_btnSaveDeviceCheckItem = new PinkieControls.ButtonXP();
            this.m_btnAddDeviceCheckItem = new PinkieControls.ButtonXP();
            this.m_chkHasGraph = new System.Windows.Forms.CheckBox();
            this.m_txtDeviceCheckItemName = new System.Windows.Forms.TextBox();
            this.m_lbDeviceCheckItemName = new System.Windows.Forms.Label();
            this.gpbDeviceModel = new System.Windows.Forms.GroupBox();
            this.m_cboDCIDeviceCategory = new System.Windows.Forms.ComboBox();
            this.m_lsvDCIDeviceModel = new System.Windows.Forms.ListView();
            this.m_chDeviceModela = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lsvDeviceCheckItem = new System.Windows.Forms.ListView();
            this.m_chDeviceCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.m_chHasGraph = new System.Windows.Forms.ColumnHeader();
            this.m_chQCItem = new System.Windows.Forms.ColumnHeader();
            this.m_tpDeviceCheckItemRelation = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lsvCheckItemDeviceCheckItem = new System.Windows.Forms.ListView();
            this.m_chmCheckItemName = new System.Windows.Forms.ColumnHeader();
            this.m_chmEnglishName = new System.Windows.Forms.ColumnHeader();
            this.m_chmShortName = new System.Windows.Forms.ColumnHeader();
            this.m_lsvBaseCheckItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_cboCheckItemType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lsvCheckItem = new System.Windows.Forms.ListView();
            this.clmDeviceChckItemName = new System.Windows.Forms.ColumnHeader();
            this.m_chmHasGraph = new System.Windows.Forms.ColumnHeader();
            this.m_lsvDeviceList = new System.Windows.Forms.ListView();
            this.clmDeviceModel = new System.Windows.Forms.ColumnHeader();
            this.m_cboCategory = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnExit3 = new PinkieControls.ButtonXP();
            this.m_txtRelationDeviceModel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdAppend = new PinkieControls.ButtonXP();
            this.m_cmdDelete = new PinkieControls.ButtonXP();
            this.m_txtBaseCheckItemName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtDeviceItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtSourceCheckItem = new System.Windows.Forms.TextBox();
            this.m_tpDevice = new System.Windows.Forms.TabPage();
            this.btnExit4 = new PinkieControls.ButtonXP();
            this.m_gbpDevice = new System.Windows.Forms.GroupBox();
            this.m_txtDeviceCode = new System.Windows.Forms.TextBox();
            this.m_lbDeviceCode = new System.Windows.Forms.Label();
            this.m_chkIsDataTrans = new System.Windows.Forms.CheckBox();
            this.m_lbDept = new System.Windows.Forms.Label();
            this.m_lbDeviceIP = new System.Windows.Forms.Label();
            this.m_txtDeviceIP = new System.Windows.Forms.TextBox();
            this.m_lbDevicePlace = new System.Windows.Forms.Label();
            this.m_lbDeviceName = new System.Windows.Forms.Label();
            this.m_dtpToDat = new System.Windows.Forms.DateTimePicker();
            this.m_chkStopDat = new System.Windows.Forms.CheckBox();
            this.m_lbDeviceStopDat = new System.Windows.Forms.Label();
            this.m_dtpFromDat = new System.Windows.Forms.DateTimePicker();
            this.m_lbDeviceBeginDat = new System.Windows.Forms.Label();
            this.m_txtDataReceiveComputerIP = new System.Windows.Forms.TextBox();
            this.m_lbReceiveComputerIP = new System.Windows.Forms.Label();
            this.m_cboDeviceModelName = new System.Windows.Forms.ComboBox();
            this.m_txtDevicePlace = new System.Windows.Forms.TextBox();
            this.m_txtDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.m_lbDeviceModelName = new System.Windows.Forms.Label();
            this.m_txtDeviceName = new System.Windows.Forms.TextBox();
            this.m_btnDelDevice = new PinkieControls.ButtonXP();
            this.m_btnSaveDevice = new PinkieControls.ButtonXP();
            this.m_btnAddDevice = new PinkieControls.ButtonXP();
            this.m_lsvDevice = new System.Windows.Forms.ListView();
            this.m_chDeviceCode = new System.Windows.Forms.ColumnHeader();
            this.m_chDeviceName = new System.Windows.Forms.ColumnHeader();
            this.m_chDeviceModel = new System.Windows.Forms.ColumnHeader();
            this.m_chDept = new System.Windows.Forms.ColumnHeader();
            this.m_chDevicePlace = new System.Windows.Forms.ColumnHeader();
            this.m_chDataReceiveIP = new System.Windows.Forms.ColumnHeader();
            this.m_chDeviceBeginDat = new System.Windows.Forms.ColumnHeader();
            this.m_chDeviceEndDat = new System.Windows.Forms.ColumnHeader();
            this.m_tabDeviceManage.SuspendLayout();
            this.m_tpDeviceModel.SuspendLayout();
            this.m_gpbDeviceModel.SuspendLayout();
            this.m_tpDeviceSerial.SuspendLayout();
            this.m_gpbDevicePara.SuspendLayout();
            this.m_tpSpecialDevice.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.m_tpDeviceCheckItem.SuspendLayout();
            this.m_gpbDeviceCheckItemDetail.SuspendLayout();
            this.gpbDeviceModel.SuspendLayout();
            this.m_tpDeviceCheckItemRelation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.m_tpDevice.SuspendLayout();
            this.m_gbpDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tabDeviceManage
            // 
            this.m_tabDeviceManage.Controls.Add(this.m_tpDeviceModel);
            this.m_tabDeviceManage.Controls.Add(this.m_tpDeviceSerial);
            this.m_tabDeviceManage.Controls.Add(this.m_tpSpecialDevice);
            this.m_tabDeviceManage.Controls.Add(this.m_tpDeviceCheckItem);
            this.m_tabDeviceManage.Controls.Add(this.m_tpDeviceCheckItemRelation);
            this.m_tabDeviceManage.Controls.Add(this.m_tpDevice);
            this.m_tabDeviceManage.Location = new System.Drawing.Point(12, 12);
            this.m_tabDeviceManage.Name = "m_tabDeviceManage";
            this.m_tabDeviceManage.SelectedIndex = 0;
            this.m_tabDeviceManage.Size = new System.Drawing.Size(952, 640);
            this.m_tabDeviceManage.TabIndex = 15;
            // 
            // m_tpDeviceModel
            // 
            this.m_tpDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_tpDeviceModel.Controls.Add(this.btnExit0);
            this.m_tpDeviceModel.Controls.Add(this.m_gpbDeviceModel);
            this.m_tpDeviceModel.Controls.Add(this.m_btnDelDeviceModel);
            this.m_tpDeviceModel.Controls.Add(this.m_btnSaveDeviceModel);
            this.m_tpDeviceModel.Controls.Add(this.m_btnAddDeviceModel);
            this.m_tpDeviceModel.Controls.Add(this.m_lsvDeviceModel);
            this.m_tpDeviceModel.Location = new System.Drawing.Point(4, 23);
            this.m_tpDeviceModel.Name = "m_tpDeviceModel";
            this.m_tpDeviceModel.Size = new System.Drawing.Size(944, 613);
            this.m_tpDeviceModel.TabIndex = 1;
            this.m_tpDeviceModel.Text = "仪器型号";
            // 
            // btnExit0
            // 
            this.btnExit0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.btnExit0.DefaultScheme = true;
            this.btnExit0.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit0.Hint = "";
            this.btnExit0.Location = new System.Drawing.Point(852, 548);
            this.btnExit0.Name = "btnExit0";
            this.btnExit0.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit0.Size = new System.Drawing.Size(64, 28);
            this.btnExit0.TabIndex = 15;
            this.btnExit0.Text = "关闭";
            this.btnExit0.Click += new System.EventHandler(this.btnExit0_Click);
            // 
            // m_gpbDeviceModel
            // 
            this.m_gpbDeviceModel.Controls.Add(this.m_lbDeviceModel);
            this.m_gpbDeviceModel.Controls.Add(this.m_txtStandardCode1);
            this.m_gpbDeviceModel.Controls.Add(this.m_cboDeviceCategory);
            this.m_gpbDeviceModel.Controls.Add(this.m_lbStandardCode2);
            this.m_gpbDeviceModel.Controls.Add(this.m_txtStandardCode2);
            this.m_gpbDeviceModel.Controls.Add(this.m_lbStandardCode1);
            this.m_gpbDeviceModel.Controls.Add(this.m_cboVendor);
            this.m_gpbDeviceModel.Controls.Add(this.m_lbVendor);
            this.m_gpbDeviceModel.Controls.Add(this.m_lbDeviceCategory);
            this.m_gpbDeviceModel.Controls.Add(this.m_txtDeviceModel);
            this.m_gpbDeviceModel.Location = new System.Drawing.Point(16, 12);
            this.m_gpbDeviceModel.Name = "m_gpbDeviceModel";
            this.m_gpbDeviceModel.Size = new System.Drawing.Size(904, 80);
            this.m_gpbDeviceModel.TabIndex = 14;
            this.m_gpbDeviceModel.TabStop = false;
            // 
            // m_lbDeviceModel
            // 
            this.m_lbDeviceModel.Location = new System.Drawing.Point(8, 20);
            this.m_lbDeviceModel.Name = "m_lbDeviceModel";
            this.m_lbDeviceModel.Size = new System.Drawing.Size(64, 20);
            this.m_lbDeviceModel.TabIndex = 0;
            this.m_lbDeviceModel.Text = "仪器型号";
            // 
            // m_txtStandardCode1
            // 
            this.m_txtStandardCode1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtStandardCode1.Location = new System.Drawing.Point(116, 44);
            this.m_txtStandardCode1.MaxLength = 20;
            this.m_txtStandardCode1.Name = "m_txtStandardCode1";
            this.m_txtStandardCode1.Size = new System.Drawing.Size(120, 23);
            this.m_txtStandardCode1.TabIndex = 7;
            // 
            // m_cboDeviceCategory
            // 
            this.m_cboDeviceCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboDeviceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDeviceCategory.Location = new System.Drawing.Point(360, 16);
            this.m_cboDeviceCategory.Name = "m_cboDeviceCategory";
            this.m_cboDeviceCategory.Size = new System.Drawing.Size(121, 22);
            this.m_cboDeviceCategory.TabIndex = 3;
            // 
            // m_lbStandardCode2
            // 
            this.m_lbStandardCode2.Location = new System.Drawing.Point(256, 52);
            this.m_lbStandardCode2.Name = "m_lbStandardCode2";
            this.m_lbStandardCode2.Size = new System.Drawing.Size(84, 23);
            this.m_lbStandardCode2.TabIndex = 8;
            this.m_lbStandardCode2.Text = "国家标准码2";
            // 
            // m_txtStandardCode2
            // 
            this.m_txtStandardCode2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtStandardCode2.Location = new System.Drawing.Point(360, 44);
            this.m_txtStandardCode2.MaxLength = 20;
            this.m_txtStandardCode2.Name = "m_txtStandardCode2";
            this.m_txtStandardCode2.Size = new System.Drawing.Size(120, 23);
            this.m_txtStandardCode2.TabIndex = 9;
            // 
            // m_lbStandardCode1
            // 
            this.m_lbStandardCode1.Location = new System.Drawing.Point(8, 52);
            this.m_lbStandardCode1.Name = "m_lbStandardCode1";
            this.m_lbStandardCode1.Size = new System.Drawing.Size(84, 20);
            this.m_lbStandardCode1.TabIndex = 6;
            this.m_lbStandardCode1.Text = "国家标准码1";
            // 
            // m_cboVendor
            // 
            this.m_cboVendor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboVendor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboVendor.Location = new System.Drawing.Point(572, 16);
            this.m_cboVendor.Name = "m_cboVendor";
            this.m_cboVendor.Size = new System.Drawing.Size(121, 22);
            this.m_cboVendor.TabIndex = 5;
            this.m_cboVendor.Visible = false;
            // 
            // m_lbVendor
            // 
            this.m_lbVendor.Location = new System.Drawing.Point(508, 20);
            this.m_lbVendor.Name = "m_lbVendor";
            this.m_lbVendor.Size = new System.Drawing.Size(68, 16);
            this.m_lbVendor.TabIndex = 4;
            this.m_lbVendor.Text = "生产厂商";
            this.m_lbVendor.Visible = false;
            // 
            // m_lbDeviceCategory
            // 
            this.m_lbDeviceCategory.Location = new System.Drawing.Point(256, 20);
            this.m_lbDeviceCategory.Name = "m_lbDeviceCategory";
            this.m_lbDeviceCategory.Size = new System.Drawing.Size(64, 16);
            this.m_lbDeviceCategory.TabIndex = 2;
            this.m_lbDeviceCategory.Text = "仪器类别";
            // 
            // m_txtDeviceModel
            // 
            this.m_txtDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDeviceModel.Location = new System.Drawing.Point(116, 12);
            this.m_txtDeviceModel.MaxLength = 200;
            this.m_txtDeviceModel.Name = "m_txtDeviceModel";
            this.m_txtDeviceModel.Size = new System.Drawing.Size(120, 23);
            this.m_txtDeviceModel.TabIndex = 1;
            // 
            // m_btnDelDeviceModel
            // 
            this.m_btnDelDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnDelDeviceModel.DefaultScheme = true;
            this.m_btnDelDeviceModel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelDeviceModel.Hint = "";
            this.m_btnDelDeviceModel.Location = new System.Drawing.Point(764, 548);
            this.m_btnDelDeviceModel.Name = "m_btnDelDeviceModel";
            this.m_btnDelDeviceModel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelDeviceModel.Size = new System.Drawing.Size(64, 28);
            this.m_btnDelDeviceModel.TabIndex = 13;
            this.m_btnDelDeviceModel.Text = "删除";
            this.m_btnDelDeviceModel.Click += new System.EventHandler(this.m_btnDelDeviceModel_Click);
            // 
            // m_btnSaveDeviceModel
            // 
            this.m_btnSaveDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnSaveDeviceModel.DefaultScheme = true;
            this.m_btnSaveDeviceModel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveDeviceModel.Hint = "";
            this.m_btnSaveDeviceModel.Location = new System.Drawing.Point(676, 548);
            this.m_btnSaveDeviceModel.Name = "m_btnSaveDeviceModel";
            this.m_btnSaveDeviceModel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveDeviceModel.Size = new System.Drawing.Size(64, 28);
            this.m_btnSaveDeviceModel.TabIndex = 12;
            this.m_btnSaveDeviceModel.Text = "保存";
            this.m_btnSaveDeviceModel.Click += new System.EventHandler(this.m_btnSaveDeviceModel_Click);
            // 
            // m_btnAddDeviceModel
            // 
            this.m_btnAddDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnAddDeviceModel.DefaultScheme = true;
            this.m_btnAddDeviceModel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddDeviceModel.Hint = "";
            this.m_btnAddDeviceModel.Location = new System.Drawing.Point(588, 548);
            this.m_btnAddDeviceModel.Name = "m_btnAddDeviceModel";
            this.m_btnAddDeviceModel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddDeviceModel.Size = new System.Drawing.Size(64, 28);
            this.m_btnAddDeviceModel.TabIndex = 11;
            this.m_btnAddDeviceModel.Text = "添加";
            this.m_btnAddDeviceModel.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_lsvDeviceModel
            // 
            this.m_lsvDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvDeviceModel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chDeviceModelDec,
            this.m_chDeviceCategory,
            this.m_chVendor,
            this.m_chStandardCode1,
            this.m_chStandardCode2});
            this.m_lsvDeviceModel.FullRowSelect = true;
            this.m_lsvDeviceModel.GridLines = true;
            this.m_lsvDeviceModel.HideSelection = false;
            this.m_lsvDeviceModel.Location = new System.Drawing.Point(16, 104);
            this.m_lsvDeviceModel.Name = "m_lsvDeviceModel";
            this.m_lsvDeviceModel.Size = new System.Drawing.Size(904, 428);
            this.m_lsvDeviceModel.TabIndex = 10;
            this.m_lsvDeviceModel.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceModel.View = System.Windows.Forms.View.Details;
            this.m_lsvDeviceModel.DoubleClick += new System.EventHandler(this.m_lsvDeviceModel_DoubleClick);
            // 
            // m_chDeviceModelDec
            // 
            this.m_chDeviceModelDec.Text = "仪器型号";
            this.m_chDeviceModelDec.Width = 100;
            // 
            // m_chDeviceCategory
            // 
            this.m_chDeviceCategory.Text = "仪器类别";
            this.m_chDeviceCategory.Width = 100;
            // 
            // m_chVendor
            // 
            this.m_chVendor.Text = "生产厂商";
            this.m_chVendor.Width = 0;
            // 
            // m_chStandardCode1
            // 
            this.m_chStandardCode1.Text = "国家标准码1";
            this.m_chStandardCode1.Width = 100;
            // 
            // m_chStandardCode2
            // 
            this.m_chStandardCode2.Text = "国家标准码2";
            this.m_chStandardCode2.Width = 100;
            // 
            // m_tpDeviceSerial
            // 
            this.m_tpDeviceSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_tpDeviceSerial.Controls.Add(this.btnExit1);
            this.m_tpDeviceSerial.Controls.Add(this.m_gpbDevicePara);
            this.m_tpDeviceSerial.Controls.Add(this.m_btnDelDeviceSerial);
            this.m_tpDeviceSerial.Controls.Add(this.m_btnSaveDeviceSerial);
            this.m_tpDeviceSerial.Controls.Add(this.m_btnAddDeviceSerial);
            this.m_tpDeviceSerial.Controls.Add(this.m_lsvDeviceSerialSetUp);
            this.m_tpDeviceSerial.Location = new System.Drawing.Point(4, 21);
            this.m_tpDeviceSerial.Name = "m_tpDeviceSerial";
            this.m_tpDeviceSerial.Size = new System.Drawing.Size(944, 615);
            this.m_tpDeviceSerial.TabIndex = 2;
            this.m_tpDeviceSerial.Text = "仪器串口参数设置";
            // 
            // btnExit1
            // 
            this.btnExit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.btnExit1.DefaultScheme = true;
            this.btnExit1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit1.Hint = "";
            this.btnExit1.Location = new System.Drawing.Point(836, 556);
            this.btnExit1.Name = "btnExit1";
            this.btnExit1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit1.Size = new System.Drawing.Size(64, 28);
            this.btnExit1.TabIndex = 32;
            this.btnExit1.Text = "关闭";
            this.btnExit1.Click += new System.EventHandler(this.btnExit1_Click);
            // 
            // m_gpbDevicePara
            // 
            this.m_gpbDevicePara.Controls.Add(this.m_chkHex);
            this.m_gpbDevicePara.Controls.Add(this.label7);
            this.m_gpbDevicePara.Controls.Add(this.m_txtSendCommand);
            this.m_gpbDevicePara.Controls.Add(this.m_cboBaulRate);
            this.m_gpbDevicePara.Controls.Add(this.m_cboFlowControl);
            this.m_gpbDevicePara.Controls.Add(this.m_cboParity);
            this.m_gpbDevicePara.Controls.Add(this.m_cboStopBit);
            this.m_gpbDevicePara.Controls.Add(this.m_cboDataBit);
            this.m_gpbDevicePara.Controls.Add(this.m_txtBaulRate);
            this.m_gpbDevicePara.Controls.Add(this.m_txtDataAnalysisNameSpace);
            this.m_gpbDevicePara.Controls.Add(this.m_lbBaulRate);
            this.m_gpbDevicePara.Controls.Add(this.m_lbComNo);
            this.m_gpbDevicePara.Controls.Add(this.m_lbDataAnalysisNameSpace);
            this.m_gpbDevicePara.Controls.Add(this.m_lbSerialDeviceModel);
            this.m_gpbDevicePara.Controls.Add(this.m_lbDataAnalysisDll);
            this.m_gpbDevicePara.Controls.Add(this.m_cboSerailDeviceModel);
            this.m_gpbDevicePara.Controls.Add(this.m_lbSendCommand);
            this.m_gpbDevicePara.Controls.Add(this.m_txtSendBuffer);
            this.m_gpbDevicePara.Controls.Add(this.m_lbSendBuffer);
            this.m_gpbDevicePara.Controls.Add(this.m_cboComNo);
            this.m_gpbDevicePara.Controls.Add(this.m_txtDeviceModelID);
            this.m_gpbDevicePara.Controls.Add(this.m_txtSendCommandInternal);
            this.m_gpbDevicePara.Controls.Add(this.m_lbFlowControl);
            this.m_gpbDevicePara.Controls.Add(this.m_lbDataBit);
            this.m_gpbDevicePara.Controls.Add(this.m_lbSendCommandInternal);
            this.m_gpbDevicePara.Controls.Add(this.m_lbReceiveBuffer);
            this.m_gpbDevicePara.Controls.Add(this.m_txtReceiveBuffer);
            this.m_gpbDevicePara.Controls.Add(this.m_txtDataAnalysisDll);
            this.m_gpbDevicePara.Controls.Add(this.m_lbStopBit);
            this.m_gpbDevicePara.Controls.Add(this.m_lbParity);
            this.m_gpbDevicePara.Location = new System.Drawing.Point(20, 8);
            this.m_gpbDevicePara.Name = "m_gpbDevicePara";
            this.m_gpbDevicePara.Size = new System.Drawing.Size(888, 172);
            this.m_gpbDevicePara.TabIndex = 31;
            this.m_gpbDevicePara.TabStop = false;
            // 
            // m_chkHex
            // 
            this.m_chkHex.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkHex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_chkHex.Location = new System.Drawing.Point(832, 48);
            this.m_chkHex.Name = "m_chkHex";
            this.m_chkHex.Size = new System.Drawing.Size(44, 24);
            this.m_chkHex.TabIndex = 36;
            this.m_chkHex.Text = "Hex";
            this.m_chkHex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkHex.CheckedChanged += new System.EventHandler(this.m_chkHex_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(836, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 14);
            this.label7.TabIndex = 35;
            this.label7.Text = "ms";
            // 
            // m_txtSendCommand
            // 
            this.m_txtSendCommand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSendCommand.Location = new System.Drawing.Point(660, 48);
            this.m_txtSendCommand.MaxLength = 30;
            this.m_txtSendCommand.Name = "m_txtSendCommand";
            this.m_txtSendCommand.Size = new System.Drawing.Size(172, 23);
            this.m_txtSendCommand.TabIndex = 19;
            // 
            // m_cboBaulRate
            // 
            this.m_cboBaulRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboBaulRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboBaulRate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "56000",
            ""});
            this.m_cboBaulRate.Location = new System.Drawing.Point(600, 20);
            this.m_cboBaulRate.Name = "m_cboBaulRate";
            this.m_cboBaulRate.Size = new System.Drawing.Size(108, 22);
            this.m_cboBaulRate.TabIndex = 34;
            this.m_cboBaulRate.Visible = false;
            // 
            // m_cboFlowControl
            // 
            this.m_cboFlowControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFlowControl.Items.AddRange(new object[] {
            "NONE",
            "HARD",
            "XON/XOFF"});
            this.m_cboFlowControl.Location = new System.Drawing.Point(480, 76);
            this.m_cboFlowControl.Name = "m_cboFlowControl";
            this.m_cboFlowControl.Size = new System.Drawing.Size(108, 22);
            this.m_cboFlowControl.TabIndex = 33;
            // 
            // m_cboParity
            // 
            this.m_cboParity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboParity.Items.AddRange(new object[] {
            "NONE",
            "EVEN",
            "ODD",
            "MARK",
            "SPACE"});
            this.m_cboParity.Location = new System.Drawing.Point(480, 48);
            this.m_cboParity.Name = "m_cboParity";
            this.m_cboParity.Size = new System.Drawing.Size(108, 22);
            this.m_cboParity.TabIndex = 32;
            // 
            // m_cboStopBit
            // 
            this.m_cboStopBit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboStopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.m_cboStopBit.Location = new System.Drawing.Point(292, 48);
            this.m_cboStopBit.Name = "m_cboStopBit";
            this.m_cboStopBit.Size = new System.Drawing.Size(108, 22);
            this.m_cboStopBit.TabIndex = 31;
            // 
            // m_cboDataBit
            // 
            this.m_cboDataBit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.m_cboDataBit.Location = new System.Drawing.Point(104, 48);
            this.m_cboDataBit.Name = "m_cboDataBit";
            this.m_cboDataBit.Size = new System.Drawing.Size(108, 22);
            this.m_cboDataBit.TabIndex = 8;
            // 
            // m_txtBaulRate
            // 
            this.m_txtBaulRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtBaulRate.Location = new System.Drawing.Point(480, 20);
            this.m_txtBaulRate.MaxLength = 10;
            this.m_txtBaulRate.Name = "m_txtBaulRate";
            this.m_txtBaulRate.Size = new System.Drawing.Size(108, 23);
            this.m_txtBaulRate.TabIndex = 5;
            // 
            // m_txtDataAnalysisNameSpace
            // 
            this.m_txtDataAnalysisNameSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDataAnalysisNameSpace.Location = new System.Drawing.Point(136, 136);
            this.m_txtDataAnalysisNameSpace.MaxLength = 100;
            this.m_txtDataAnalysisNameSpace.Name = "m_txtDataAnalysisNameSpace";
            this.m_txtDataAnalysisNameSpace.Size = new System.Drawing.Size(724, 23);
            this.m_txtDataAnalysisNameSpace.TabIndex = 25;
            // 
            // m_lbBaulRate
            // 
            this.m_lbBaulRate.Location = new System.Drawing.Point(420, 24);
            this.m_lbBaulRate.Name = "m_lbBaulRate";
            this.m_lbBaulRate.Size = new System.Drawing.Size(56, 23);
            this.m_lbBaulRate.TabIndex = 4;
            this.m_lbBaulRate.Text = "波特率";
            // 
            // m_lbComNo
            // 
            this.m_lbComNo.AutoSize = true;
            this.m_lbComNo.Location = new System.Drawing.Point(244, 24);
            this.m_lbComNo.Name = "m_lbComNo";
            this.m_lbComNo.Size = new System.Drawing.Size(35, 14);
            this.m_lbComNo.TabIndex = 2;
            this.m_lbComNo.Text = "串口";
            // 
            // m_lbDataAnalysisNameSpace
            // 
            this.m_lbDataAnalysisNameSpace.Location = new System.Drawing.Point(16, 136);
            this.m_lbDataAnalysisNameSpace.Name = "m_lbDataAnalysisNameSpace";
            this.m_lbDataAnalysisNameSpace.Size = new System.Drawing.Size(120, 23);
            this.m_lbDataAnalysisNameSpace.TabIndex = 24;
            this.m_lbDataAnalysisNameSpace.Text = "数据分析对象类名";
            // 
            // m_lbSerialDeviceModel
            // 
            this.m_lbSerialDeviceModel.Location = new System.Drawing.Point(16, 24);
            this.m_lbSerialDeviceModel.Name = "m_lbSerialDeviceModel";
            this.m_lbSerialDeviceModel.Size = new System.Drawing.Size(64, 23);
            this.m_lbSerialDeviceModel.TabIndex = 0;
            this.m_lbSerialDeviceModel.Text = "仪器型号";
            // 
            // m_lbDataAnalysisDll
            // 
            this.m_lbDataAnalysisDll.Location = new System.Drawing.Point(16, 108);
            this.m_lbDataAnalysisDll.Name = "m_lbDataAnalysisDll";
            this.m_lbDataAnalysisDll.Size = new System.Drawing.Size(116, 23);
            this.m_lbDataAnalysisDll.TabIndex = 22;
            this.m_lbDataAnalysisDll.Text = "数据分析Dll名称";
            // 
            // m_cboSerailDeviceModel
            // 
            this.m_cboSerailDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboSerailDeviceModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSerailDeviceModel.Location = new System.Drawing.Point(104, 16);
            this.m_cboSerailDeviceModel.Name = "m_cboSerailDeviceModel";
            this.m_cboSerailDeviceModel.Size = new System.Drawing.Size(108, 22);
            this.m_cboSerailDeviceModel.TabIndex = 1;
            // 
            // m_lbSendCommand
            // 
            this.m_lbSendCommand.Location = new System.Drawing.Point(596, 52);
            this.m_lbSendCommand.Name = "m_lbSendCommand";
            this.m_lbSendCommand.Size = new System.Drawing.Size(68, 23);
            this.m_lbSendCommand.TabIndex = 18;
            this.m_lbSendCommand.Text = "发送命令";
            // 
            // m_txtSendBuffer
            // 
            this.m_txtSendBuffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSendBuffer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtSendBuffer.Location = new System.Drawing.Point(292, 76);
            this.m_txtSendBuffer.MaxLength = 10;
            this.m_txtSendBuffer.Name = "m_txtSendBuffer";
            this.m_txtSendBuffer.Size = new System.Drawing.Size(108, 23);
            this.m_txtSendBuffer.TabIndex = 17;
            // 
            // m_lbSendBuffer
            // 
            this.m_lbSendBuffer.Location = new System.Drawing.Point(216, 80);
            this.m_lbSendBuffer.Name = "m_lbSendBuffer";
            this.m_lbSendBuffer.Size = new System.Drawing.Size(80, 23);
            this.m_lbSendBuffer.TabIndex = 16;
            this.m_lbSendBuffer.Text = "发送缓冲区";
            // 
            // m_cboComNo
            // 
            this.m_cboComNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboComNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboComNo.Items.AddRange(new object[] {
            "NONE",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10"});
            this.m_cboComNo.Location = new System.Drawing.Point(292, 16);
            this.m_cboComNo.Name = "m_cboComNo";
            this.m_cboComNo.Size = new System.Drawing.Size(108, 22);
            this.m_cboComNo.TabIndex = 3;
            // 
            // m_txtDeviceModelID
            // 
            this.m_txtDeviceModelID.Location = new System.Drawing.Point(728, 20);
            this.m_txtDeviceModelID.Name = "m_txtDeviceModelID";
            this.m_txtDeviceModelID.ReadOnly = true;
            this.m_txtDeviceModelID.Size = new System.Drawing.Size(132, 23);
            this.m_txtDeviceModelID.TabIndex = 30;
            this.m_txtDeviceModelID.Visible = false;
            // 
            // m_txtSendCommandInternal
            // 
            this.m_txtSendCommandInternal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSendCommandInternal.Location = new System.Drawing.Point(660, 76);
            this.m_txtSendCommandInternal.MaxLength = 10;
            this.m_txtSendCommandInternal.Name = "m_txtSendCommandInternal";
            this.m_txtSendCommandInternal.Size = new System.Drawing.Size(172, 23);
            this.m_txtSendCommandInternal.TabIndex = 21;
            // 
            // m_lbFlowControl
            // 
            this.m_lbFlowControl.Location = new System.Drawing.Point(420, 80);
            this.m_lbFlowControl.Name = "m_lbFlowControl";
            this.m_lbFlowControl.Size = new System.Drawing.Size(56, 23);
            this.m_lbFlowControl.TabIndex = 12;
            this.m_lbFlowControl.Text = "流控制";
            // 
            // m_lbDataBit
            // 
            this.m_lbDataBit.Location = new System.Drawing.Point(16, 52);
            this.m_lbDataBit.Name = "m_lbDataBit";
            this.m_lbDataBit.Size = new System.Drawing.Size(52, 23);
            this.m_lbDataBit.TabIndex = 6;
            this.m_lbDataBit.Text = "数据位";
            // 
            // m_lbSendCommandInternal
            // 
            this.m_lbSendCommandInternal.Location = new System.Drawing.Point(596, 80);
            this.m_lbSendCommandInternal.Name = "m_lbSendCommandInternal";
            this.m_lbSendCommandInternal.Size = new System.Drawing.Size(100, 23);
            this.m_lbSendCommandInternal.TabIndex = 20;
            this.m_lbSendCommandInternal.Text = "发送间隔";
            // 
            // m_lbReceiveBuffer
            // 
            this.m_lbReceiveBuffer.Location = new System.Drawing.Point(16, 80);
            this.m_lbReceiveBuffer.Name = "m_lbReceiveBuffer";
            this.m_lbReceiveBuffer.Size = new System.Drawing.Size(80, 23);
            this.m_lbReceiveBuffer.TabIndex = 14;
            this.m_lbReceiveBuffer.Text = "接收缓冲区";
            // 
            // m_txtReceiveBuffer
            // 
            this.m_txtReceiveBuffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtReceiveBuffer.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.m_txtReceiveBuffer.Location = new System.Drawing.Point(104, 76);
            this.m_txtReceiveBuffer.MaxLength = 10;
            this.m_txtReceiveBuffer.Name = "m_txtReceiveBuffer";
            this.m_txtReceiveBuffer.Size = new System.Drawing.Size(108, 23);
            this.m_txtReceiveBuffer.TabIndex = 15;
            // 
            // m_txtDataAnalysisDll
            // 
            this.m_txtDataAnalysisDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDataAnalysisDll.Location = new System.Drawing.Point(136, 108);
            this.m_txtDataAnalysisDll.MaxLength = 100;
            this.m_txtDataAnalysisDll.Name = "m_txtDataAnalysisDll";
            this.m_txtDataAnalysisDll.Size = new System.Drawing.Size(724, 23);
            this.m_txtDataAnalysisDll.TabIndex = 23;
            // 
            // m_lbStopBit
            // 
            this.m_lbStopBit.Location = new System.Drawing.Point(236, 52);
            this.m_lbStopBit.Name = "m_lbStopBit";
            this.m_lbStopBit.Size = new System.Drawing.Size(56, 23);
            this.m_lbStopBit.TabIndex = 8;
            this.m_lbStopBit.Text = "停止位";
            // 
            // m_lbParity
            // 
            this.m_lbParity.Location = new System.Drawing.Point(420, 52);
            this.m_lbParity.Name = "m_lbParity";
            this.m_lbParity.Size = new System.Drawing.Size(56, 23);
            this.m_lbParity.TabIndex = 10;
            this.m_lbParity.Text = "校验位";
            // 
            // m_btnDelDeviceSerial
            // 
            this.m_btnDelDeviceSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnDelDeviceSerial.DefaultScheme = true;
            this.m_btnDelDeviceSerial.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelDeviceSerial.Hint = "";
            this.m_btnDelDeviceSerial.Location = new System.Drawing.Point(749, 556);
            this.m_btnDelDeviceSerial.Name = "m_btnDelDeviceSerial";
            this.m_btnDelDeviceSerial.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelDeviceSerial.Size = new System.Drawing.Size(64, 28);
            this.m_btnDelDeviceSerial.TabIndex = 29;
            this.m_btnDelDeviceSerial.Text = "删除";
            this.m_btnDelDeviceSerial.Click += new System.EventHandler(this.m_btnDelDeviceSerial_Click);
            // 
            // m_btnSaveDeviceSerial
            // 
            this.m_btnSaveDeviceSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnSaveDeviceSerial.DefaultScheme = true;
            this.m_btnSaveDeviceSerial.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveDeviceSerial.Hint = "";
            this.m_btnSaveDeviceSerial.Location = new System.Drawing.Point(662, 556);
            this.m_btnSaveDeviceSerial.Name = "m_btnSaveDeviceSerial";
            this.m_btnSaveDeviceSerial.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveDeviceSerial.Size = new System.Drawing.Size(64, 28);
            this.m_btnSaveDeviceSerial.TabIndex = 28;
            this.m_btnSaveDeviceSerial.Text = "保存";
            this.m_btnSaveDeviceSerial.Click += new System.EventHandler(this.m_btnSaveDeviceSerial_Click);
            // 
            // m_btnAddDeviceSerial
            // 
            this.m_btnAddDeviceSerial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnAddDeviceSerial.DefaultScheme = true;
            this.m_btnAddDeviceSerial.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddDeviceSerial.Hint = "";
            this.m_btnAddDeviceSerial.Location = new System.Drawing.Point(575, 556);
            this.m_btnAddDeviceSerial.Name = "m_btnAddDeviceSerial";
            this.m_btnAddDeviceSerial.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddDeviceSerial.Size = new System.Drawing.Size(64, 28);
            this.m_btnAddDeviceSerial.TabIndex = 27;
            this.m_btnAddDeviceSerial.Text = "添加";
            this.m_btnAddDeviceSerial.Click += new System.EventHandler(this.m_btnAddDeviceSerial_Click);
            // 
            // m_lsvDeviceSerialSetUp
            // 
            this.m_lsvDeviceSerialSetUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvDeviceSerialSetUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chSerialDeviceModel,
            this.m_chComNo,
            this.m_chBaulRate,
            this.m_chDataBit,
            this.m_chStopBit,
            this.m_chParity,
            this.m_chReceiveBuffer,
            this.m_chSendBuffer,
            this.m_chDllName,
            this.m_chNameSpace});
            this.m_lsvDeviceSerialSetUp.FullRowSelect = true;
            this.m_lsvDeviceSerialSetUp.GridLines = true;
            this.m_lsvDeviceSerialSetUp.HideSelection = false;
            this.m_lsvDeviceSerialSetUp.Location = new System.Drawing.Point(20, 188);
            this.m_lsvDeviceSerialSetUp.Name = "m_lsvDeviceSerialSetUp";
            this.m_lsvDeviceSerialSetUp.Size = new System.Drawing.Size(888, 348);
            this.m_lsvDeviceSerialSetUp.TabIndex = 26;
            this.m_lsvDeviceSerialSetUp.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceSerialSetUp.View = System.Windows.Forms.View.Details;
            this.m_lsvDeviceSerialSetUp.DoubleClick += new System.EventHandler(this.m_lsvDeviceSerialSetUp_DoubleClick);
            // 
            // m_chSerialDeviceModel
            // 
            this.m_chSerialDeviceModel.Text = "仪器型号";
            this.m_chSerialDeviceModel.Width = 109;
            // 
            // m_chComNo
            // 
            this.m_chComNo.Text = "串口";
            // 
            // m_chBaulRate
            // 
            this.m_chBaulRate.Text = "波特率";
            // 
            // m_chDataBit
            // 
            this.m_chDataBit.Text = "数据位";
            // 
            // m_chStopBit
            // 
            this.m_chStopBit.Text = "停止位";
            // 
            // m_chParity
            // 
            this.m_chParity.Text = "校验位";
            // 
            // m_chReceiveBuffer
            // 
            this.m_chReceiveBuffer.Text = "接收缓冲区";
            this.m_chReceiveBuffer.Width = 85;
            // 
            // m_chSendBuffer
            // 
            this.m_chSendBuffer.Text = "发送缓冲区";
            this.m_chSendBuffer.Width = 85;
            // 
            // m_chDllName
            // 
            this.m_chDllName.Text = "Dll名称";
            this.m_chDllName.Width = 109;
            // 
            // m_chNameSpace
            // 
            this.m_chNameSpace.Text = "名称空间";
            this.m_chNameSpace.Width = 192;
            // 
            // m_tpSpecialDevice
            // 
            this.m_tpSpecialDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_tpSpecialDevice.Controls.Add(this.m_btnExitSpecialDevice);
            this.m_tpSpecialDevice.Controls.Add(this.m_btnDelSpecialDevice);
            this.m_tpSpecialDevice.Controls.Add(this.m_btnSaveSpecialDevice);
            this.m_tpSpecialDevice.Controls.Add(this.m_btnAddSpecialDevice);
            this.m_tpSpecialDevice.Controls.Add(this.m_lstSpecialDevice);
            this.m_tpSpecialDevice.Controls.Add(this.groupBox4);
            this.m_tpSpecialDevice.Location = new System.Drawing.Point(4, 23);
            this.m_tpSpecialDevice.Name = "m_tpSpecialDevice";
            this.m_tpSpecialDevice.Size = new System.Drawing.Size(944, 613);
            this.m_tpSpecialDevice.TabIndex = 5;
            this.m_tpSpecialDevice.Text = "特殊仪器参数配置";
            // 
            // m_btnExitSpecialDevice
            // 
            this.m_btnExitSpecialDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnExitSpecialDevice.DefaultScheme = true;
            this.m_btnExitSpecialDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnExitSpecialDevice.Hint = "";
            this.m_btnExitSpecialDevice.Location = new System.Drawing.Point(848, 538);
            this.m_btnExitSpecialDevice.Name = "m_btnExitSpecialDevice";
            this.m_btnExitSpecialDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnExitSpecialDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnExitSpecialDevice.TabIndex = 40;
            this.m_btnExitSpecialDevice.Text = "关闭";
            this.m_btnExitSpecialDevice.Click += new System.EventHandler(this.m_btnExitSpecialDevice_Click);
            // 
            // m_btnDelSpecialDevice
            // 
            this.m_btnDelSpecialDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnDelSpecialDevice.DefaultScheme = true;
            this.m_btnDelSpecialDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelSpecialDevice.Hint = "";
            this.m_btnDelSpecialDevice.Location = new System.Drawing.Point(750, 538);
            this.m_btnDelSpecialDevice.Name = "m_btnDelSpecialDevice";
            this.m_btnDelSpecialDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelSpecialDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnDelSpecialDevice.TabIndex = 39;
            this.m_btnDelSpecialDevice.Text = "删除";
            this.m_btnDelSpecialDevice.Click += new System.EventHandler(this.m_btnDelSpecialDevice_Click);
            // 
            // m_btnSaveSpecialDevice
            // 
            this.m_btnSaveSpecialDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnSaveSpecialDevice.DefaultScheme = true;
            this.m_btnSaveSpecialDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveSpecialDevice.Hint = "";
            this.m_btnSaveSpecialDevice.Location = new System.Drawing.Point(652, 538);
            this.m_btnSaveSpecialDevice.Name = "m_btnSaveSpecialDevice";
            this.m_btnSaveSpecialDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveSpecialDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnSaveSpecialDevice.TabIndex = 38;
            this.m_btnSaveSpecialDevice.Text = "保存";
            this.m_btnSaveSpecialDevice.Click += new System.EventHandler(this.m_btnSaveSpecialDevice_Click);
            // 
            // m_btnAddSpecialDevice
            // 
            this.m_btnAddSpecialDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnAddSpecialDevice.DefaultScheme = true;
            this.m_btnAddSpecialDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddSpecialDevice.Hint = "";
            this.m_btnAddSpecialDevice.Location = new System.Drawing.Point(554, 538);
            this.m_btnAddSpecialDevice.Name = "m_btnAddSpecialDevice";
            this.m_btnAddSpecialDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddSpecialDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnAddSpecialDevice.TabIndex = 37;
            this.m_btnAddSpecialDevice.Text = "添加";
            this.m_btnAddSpecialDevice.Click += new System.EventHandler(this.m_btnAddSpecialDevice_Click);
            // 
            // m_lstSpecialDevice
            // 
            this.m_lstSpecialDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lstSpecialDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chSpecialDeviceModel,
            this.m_chSpecialDeviceConnection,
            this.m_chSpecialDeviceDSN,
            this.m_chSpecialDeviceWork,
            this.m_chSpecialDeviceInterval,
            this.m_chSpecialDevicePict,
            this.m_chSpecialDeviceOtherSet,
            this.m_chSpecialDeviceDLL,
            this.m_thSpecialDeviceClass});
            this.m_lstSpecialDevice.FullRowSelect = true;
            this.m_lstSpecialDevice.GridLines = true;
            this.m_lstSpecialDevice.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lstSpecialDevice.Location = new System.Drawing.Point(12, 223);
            this.m_lstSpecialDevice.MultiSelect = false;
            this.m_lstSpecialDevice.Name = "m_lstSpecialDevice";
            this.m_lstSpecialDevice.Size = new System.Drawing.Size(900, 304);
            this.m_lstSpecialDevice.TabIndex = 2;
            this.m_lstSpecialDevice.UseCompatibleStateImageBehavior = false;
            this.m_lstSpecialDevice.View = System.Windows.Forms.View.Details;
            this.m_lstSpecialDevice.DoubleClick += new System.EventHandler(this.m_lstSpecialDevice_DoubleClick);
            // 
            // m_chSpecialDeviceModel
            // 
            this.m_chSpecialDeviceModel.Text = "设备型号";
            this.m_chSpecialDeviceModel.Width = 100;
            // 
            // m_chSpecialDeviceConnection
            // 
            this.m_chSpecialDeviceConnection.Text = "联机方式";
            this.m_chSpecialDeviceConnection.Width = 100;
            // 
            // m_chSpecialDeviceDSN
            // 
            this.m_chSpecialDeviceDSN.Text = "联机DSN";
            this.m_chSpecialDeviceDSN.Width = 100;
            // 
            // m_chSpecialDeviceWork
            // 
            this.m_chSpecialDeviceWork.Text = "工作方式";
            this.m_chSpecialDeviceWork.Width = 100;
            // 
            // m_chSpecialDeviceInterval
            // 
            this.m_chSpecialDeviceInterval.Text = "轮值间隔";
            this.m_chSpecialDeviceInterval.Width = 100;
            // 
            // m_chSpecialDevicePict
            // 
            this.m_chSpecialDevicePict.Text = "图片路径";
            this.m_chSpecialDevicePict.Width = 100;
            // 
            // m_chSpecialDeviceOtherSet
            // 
            this.m_chSpecialDeviceOtherSet.Text = "其他参数设置";
            this.m_chSpecialDeviceOtherSet.Width = 100;
            // 
            // m_chSpecialDeviceDLL
            // 
            this.m_chSpecialDeviceDLL.Text = "DLL名称";
            this.m_chSpecialDeviceDLL.Width = 100;
            // 
            // m_thSpecialDeviceClass
            // 
            this.m_thSpecialDeviceClass.Text = "对象类名";
            this.m_thSpecialDeviceClass.Width = 90;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.m_txtSpecialDeviceClass);
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.m_txtSpecialDeviceDll);
            this.groupBox4.Controls.Add(this.label31);
            this.groupBox4.Controls.Add(this.m_txtSpecialDeviceOtherSet);
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.m_txtSpecialDevicePath);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.m_txtSpecialDeviceInterval);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.m_txtSpecialDeviceDSN);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.m_cboSpecialDeviceConnection);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.m_cboSpecialDeviceModelID);
            this.groupBox4.Location = new System.Drawing.Point(12, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(900, 203);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.m_chkAutoRead);
            this.groupBox6.Controls.Add(this.m_chkMatterDriver);
            this.groupBox6.Controls.Add(this.m_chkHandDriver);
            this.groupBox6.Location = new System.Drawing.Point(98, 44);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(256, 40);
            this.groupBox6.TabIndex = 27;
            this.groupBox6.TabStop = false;
            // 
            // m_chkAutoRead
            // 
            this.m_chkAutoRead.AutoSize = true;
            this.m_chkAutoRead.Location = new System.Drawing.Point(6, 14);
            this.m_chkAutoRead.Name = "m_chkAutoRead";
            this.m_chkAutoRead.Size = new System.Drawing.Size(82, 18);
            this.m_chkAutoRead.TabIndex = 7;
            this.m_chkAutoRead.Text = "自动读取";
            this.m_chkAutoRead.UseVisualStyleBackColor = true;
            this.m_chkAutoRead.CheckedChanged += new System.EventHandler(this.m_chkAutoRead_CheckedChanged);
            // 
            // m_chkMatterDriver
            // 
            this.m_chkMatterDriver.AutoSize = true;
            this.m_chkMatterDriver.Location = new System.Drawing.Point(170, 14);
            this.m_chkMatterDriver.Name = "m_chkMatterDriver";
            this.m_chkMatterDriver.Size = new System.Drawing.Size(82, 18);
            this.m_chkMatterDriver.TabIndex = 8;
            this.m_chkMatterDriver.Text = "事件驱动";
            this.m_chkMatterDriver.UseVisualStyleBackColor = true;
            // 
            // m_chkHandDriver
            // 
            this.m_chkHandDriver.AutoSize = true;
            this.m_chkHandDriver.Location = new System.Drawing.Point(90, 14);
            this.m_chkHandDriver.Name = "m_chkHandDriver";
            this.m_chkHandDriver.Size = new System.Drawing.Size(82, 18);
            this.m_chkHandDriver.TabIndex = 9;
            this.m_chkHandDriver.Text = "手工驱动";
            this.m_chkHandDriver.UseVisualStyleBackColor = true;
            // 
            // m_txtSpecialDeviceClass
            // 
            this.m_txtSpecialDeviceClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSpecialDeviceClass.Location = new System.Drawing.Point(139, 170);
            this.m_txtSpecialDeviceClass.MaxLength = 100;
            this.m_txtSpecialDeviceClass.Name = "m_txtSpecialDeviceClass";
            this.m_txtSpecialDeviceClass.Size = new System.Drawing.Size(724, 23);
            this.m_txtSpecialDeviceClass.TabIndex = 26;
            // 
            // label32
            // 
            this.label32.Location = new System.Drawing.Point(19, 171);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(120, 23);
            this.label32.TabIndex = 25;
            this.label32.Text = "数据分析对象类名";
            // 
            // m_txtSpecialDeviceDll
            // 
            this.m_txtSpecialDeviceDll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSpecialDeviceDll.Location = new System.Drawing.Point(139, 131);
            this.m_txtSpecialDeviceDll.MaxLength = 100;
            this.m_txtSpecialDeviceDll.Name = "m_txtSpecialDeviceDll";
            this.m_txtSpecialDeviceDll.Size = new System.Drawing.Size(724, 23);
            this.m_txtSpecialDeviceDll.TabIndex = 24;
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(19, 136);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(116, 23);
            this.label31.TabIndex = 23;
            this.label31.Text = "数据分析Dll名称";
            // 
            // m_txtSpecialDeviceOtherSet
            // 
            this.m_txtSpecialDeviceOtherSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSpecialDeviceOtherSet.Location = new System.Drawing.Point(119, 94);
            this.m_txtSpecialDeviceOtherSet.MaxLength = 2000;
            this.m_txtSpecialDeviceOtherSet.Name = "m_txtSpecialDeviceOtherSet";
            this.m_txtSpecialDeviceOtherSet.Size = new System.Drawing.Size(744, 23);
            this.m_txtSpecialDeviceOtherSet.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(19, 100);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(91, 14);
            this.label30.TabIndex = 14;
            this.label30.Text = "其他参数设置";
            // 
            // m_txtSpecialDevicePath
            // 
            this.m_txtSpecialDevicePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSpecialDevicePath.Location = new System.Drawing.Point(626, 53);
            this.m_txtSpecialDevicePath.MaxLength = 500;
            this.m_txtSpecialDevicePath.Name = "m_txtSpecialDevicePath";
            this.m_txtSpecialDevicePath.Size = new System.Drawing.Size(237, 23);
            this.m_txtSpecialDevicePath.TabIndex = 13;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(559, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 14);
            this.label29.TabIndex = 12;
            this.label29.Text = "图片路径";
            // 
            // m_txtSpecialDeviceInterval
            // 
            this.m_txtSpecialDeviceInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSpecialDeviceInterval.Enabled = false;
            this.m_txtSpecialDeviceInterval.Location = new System.Drawing.Point(426, 53);
            this.m_txtSpecialDeviceInterval.MaxLength = 10;
            this.m_txtSpecialDeviceInterval.Name = "m_txtSpecialDeviceInterval";
            this.m_txtSpecialDeviceInterval.Size = new System.Drawing.Size(100, 23);
            this.m_txtSpecialDeviceInterval.TabIndex = 11;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(360, 58);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 14);
            this.label28.TabIndex = 10;
            this.label28.Text = "轮值间隔";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(19, 58);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(63, 14);
            this.label27.TabIndex = 6;
            this.label27.Text = "工作方式";
            // 
            // m_txtSpecialDeviceDSN
            // 
            this.m_txtSpecialDeviceDSN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtSpecialDeviceDSN.Location = new System.Drawing.Point(626, 15);
            this.m_txtSpecialDeviceDSN.MaxLength = 500;
            this.m_txtSpecialDeviceDSN.Name = "m_txtSpecialDeviceDSN";
            this.m_txtSpecialDeviceDSN.Size = new System.Drawing.Size(237, 23);
            this.m_txtSpecialDeviceDSN.TabIndex = 5;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(554, 19);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 14);
            this.label26.TabIndex = 4;
            this.label26.Text = "联机DSN";
            // 
            // m_cboSpecialDeviceConnection
            // 
            this.m_cboSpecialDeviceConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboSpecialDeviceConnection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSpecialDeviceConnection.FormattingEnabled = true;
            this.m_cboSpecialDeviceConnection.Items.AddRange(new object[] {
            "",
            "ORACLE",
            "SQL",
            "ADO",
            "ODBC",
            "TEXT"});
            this.m_cboSpecialDeviceConnection.Location = new System.Drawing.Point(405, 16);
            this.m_cboSpecialDeviceConnection.Name = "m_cboSpecialDeviceConnection";
            this.m_cboSpecialDeviceConnection.Size = new System.Drawing.Size(121, 22);
            this.m_cboSpecialDeviceConnection.TabIndex = 3;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(310, 19);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(63, 14);
            this.label25.TabIndex = 2;
            this.label25.Text = "联机方式";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(19, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 1;
            this.label24.Text = "设备型号";
            // 
            // m_cboSpecialDeviceModelID
            // 
            this.m_cboSpecialDeviceModelID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboSpecialDeviceModelID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboSpecialDeviceModelID.FormattingEnabled = true;
            this.m_cboSpecialDeviceModelID.Location = new System.Drawing.Point(98, 16);
            this.m_cboSpecialDeviceModelID.Name = "m_cboSpecialDeviceModelID";
            this.m_cboSpecialDeviceModelID.Size = new System.Drawing.Size(191, 22);
            this.m_cboSpecialDeviceModelID.TabIndex = 0;
            // 
            // m_tpDeviceCheckItem
            // 
            this.m_tpDeviceCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_tpDeviceCheckItem.Controls.Add(this.m_gpbDeviceCheckItemDetail);
            this.m_tpDeviceCheckItem.Controls.Add(this.gpbDeviceModel);
            this.m_tpDeviceCheckItem.Location = new System.Drawing.Point(4, 21);
            this.m_tpDeviceCheckItem.Name = "m_tpDeviceCheckItem";
            this.m_tpDeviceCheckItem.Size = new System.Drawing.Size(944, 615);
            this.m_tpDeviceCheckItem.TabIndex = 4;
            this.m_tpDeviceCheckItem.Text = "仪器检验项目";
            // 
            // m_gpbDeviceCheckItemDetail
            // 
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_chkQCItem);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.btnExit2);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_btnDelDeviceCheckItem);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_btnSaveDeviceCheckItem);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_btnAddDeviceCheckItem);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_chkHasGraph);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_txtDeviceCheckItemName);
            this.m_gpbDeviceCheckItemDetail.Controls.Add(this.m_lbDeviceCheckItemName);
            this.m_gpbDeviceCheckItemDetail.Location = new System.Drawing.Point(8, 520);
            this.m_gpbDeviceCheckItemDetail.Name = "m_gpbDeviceCheckItemDetail";
            this.m_gpbDeviceCheckItemDetail.Size = new System.Drawing.Size(920, 56);
            this.m_gpbDeviceCheckItemDetail.TabIndex = 4;
            this.m_gpbDeviceCheckItemDetail.TabStop = false;
            // 
            // m_chkQCItem
            // 
            this.m_chkQCItem.AutoSize = true;
            this.m_chkQCItem.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkQCItem.Location = new System.Drawing.Point(376, 22);
            this.m_chkQCItem.Name = "m_chkQCItem";
            this.m_chkQCItem.Size = new System.Drawing.Size(82, 18);
            this.m_chkQCItem.TabIndex = 17;
            this.m_chkQCItem.Text = "质控项目";
            // 
            // btnExit2
            // 
            this.btnExit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExit2.DefaultScheme = true;
            this.btnExit2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit2.Hint = "";
            this.btnExit2.Location = new System.Drawing.Point(836, 16);
            this.btnExit2.Name = "btnExit2";
            this.btnExit2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit2.Size = new System.Drawing.Size(68, 30);
            this.btnExit2.TabIndex = 16;
            this.btnExit2.Text = "关闭";
            this.btnExit2.Click += new System.EventHandler(this.btnExit2_Click);
            // 
            // m_btnDelDeviceCheckItem
            // 
            this.m_btnDelDeviceCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnDelDeviceCheckItem.DefaultScheme = true;
            this.m_btnDelDeviceCheckItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelDeviceCheckItem.Hint = "";
            this.m_btnDelDeviceCheckItem.Location = new System.Drawing.Point(750, 16);
            this.m_btnDelDeviceCheckItem.Name = "m_btnDelDeviceCheckItem";
            this.m_btnDelDeviceCheckItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelDeviceCheckItem.Size = new System.Drawing.Size(68, 30);
            this.m_btnDelDeviceCheckItem.TabIndex = 5;
            this.m_btnDelDeviceCheckItem.Text = "删除";
            this.m_btnDelDeviceCheckItem.Click += new System.EventHandler(this.m_btnDelDeviceCheckItem_Click);
            // 
            // m_btnSaveDeviceCheckItem
            // 
            this.m_btnSaveDeviceCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnSaveDeviceCheckItem.DefaultScheme = true;
            this.m_btnSaveDeviceCheckItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveDeviceCheckItem.Hint = "";
            this.m_btnSaveDeviceCheckItem.Location = new System.Drawing.Point(662, 16);
            this.m_btnSaveDeviceCheckItem.Name = "m_btnSaveDeviceCheckItem";
            this.m_btnSaveDeviceCheckItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveDeviceCheckItem.Size = new System.Drawing.Size(68, 30);
            this.m_btnSaveDeviceCheckItem.TabIndex = 4;
            this.m_btnSaveDeviceCheckItem.Text = "保存";
            this.m_btnSaveDeviceCheckItem.Click += new System.EventHandler(this.m_btnSaveDeviceCheckItem_Click);
            // 
            // m_btnAddDeviceCheckItem
            // 
            this.m_btnAddDeviceCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnAddDeviceCheckItem.DefaultScheme = true;
            this.m_btnAddDeviceCheckItem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddDeviceCheckItem.Hint = "";
            this.m_btnAddDeviceCheckItem.Location = new System.Drawing.Point(574, 16);
            this.m_btnAddDeviceCheckItem.Name = "m_btnAddDeviceCheckItem";
            this.m_btnAddDeviceCheckItem.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddDeviceCheckItem.Size = new System.Drawing.Size(68, 30);
            this.m_btnAddDeviceCheckItem.TabIndex = 3;
            this.m_btnAddDeviceCheckItem.Text = "添加";
            this.m_btnAddDeviceCheckItem.Click += new System.EventHandler(this.m_btnAddDeviceCheckItem_Click);
            // 
            // m_chkHasGraph
            // 
            this.m_chkHasGraph.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkHasGraph.Location = new System.Drawing.Point(288, 19);
            this.m_chkHasGraph.Name = "m_chkHasGraph";
            this.m_chkHasGraph.Size = new System.Drawing.Size(60, 24);
            this.m_chkHasGraph.TabIndex = 2;
            this.m_chkHasGraph.Text = "图形";
            // 
            // m_txtDeviceCheckItemName
            // 
            this.m_txtDeviceCheckItemName.Location = new System.Drawing.Point(104, 20);
            this.m_txtDeviceCheckItemName.Name = "m_txtDeviceCheckItemName";
            this.m_txtDeviceCheckItemName.Size = new System.Drawing.Size(152, 23);
            this.m_txtDeviceCheckItemName.TabIndex = 1;
            // 
            // m_lbDeviceCheckItemName
            // 
            this.m_lbDeviceCheckItemName.AutoSize = true;
            this.m_lbDeviceCheckItemName.Location = new System.Drawing.Point(12, 24);
            this.m_lbDeviceCheckItemName.Name = "m_lbDeviceCheckItemName";
            this.m_lbDeviceCheckItemName.Size = new System.Drawing.Size(91, 14);
            this.m_lbDeviceCheckItemName.TabIndex = 0;
            this.m_lbDeviceCheckItemName.Text = "仪器项目名称";
            // 
            // gpbDeviceModel
            // 
            this.gpbDeviceModel.Controls.Add(this.m_cboDCIDeviceCategory);
            this.gpbDeviceModel.Controls.Add(this.m_lsvDCIDeviceModel);
            this.gpbDeviceModel.Controls.Add(this.label5);
            this.gpbDeviceModel.Controls.Add(this.m_lsvDeviceCheckItem);
            this.gpbDeviceModel.Location = new System.Drawing.Point(8, 8);
            this.gpbDeviceModel.Name = "gpbDeviceModel";
            this.gpbDeviceModel.Size = new System.Drawing.Size(920, 496);
            this.gpbDeviceModel.TabIndex = 3;
            this.gpbDeviceModel.TabStop = false;
            // 
            // m_cboDCIDeviceCategory
            // 
            this.m_cboDCIDeviceCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboDCIDeviceCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDCIDeviceCategory.Location = new System.Drawing.Point(92, 20);
            this.m_cboDCIDeviceCategory.Name = "m_cboDCIDeviceCategory";
            this.m_cboDCIDeviceCategory.Size = new System.Drawing.Size(132, 22);
            this.m_cboDCIDeviceCategory.TabIndex = 1;
            this.m_cboDCIDeviceCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboDCIDeviceCategory_SelectedIndexChanged);
            // 
            // m_lsvDCIDeviceModel
            // 
            this.m_lsvDCIDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvDCIDeviceModel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chDeviceModela});
            this.m_lsvDCIDeviceModel.FullRowSelect = true;
            this.m_lsvDCIDeviceModel.GridLines = true;
            this.m_lsvDCIDeviceModel.HideSelection = false;
            this.m_lsvDCIDeviceModel.Location = new System.Drawing.Point(16, 52);
            this.m_lsvDCIDeviceModel.MultiSelect = false;
            this.m_lsvDCIDeviceModel.Name = "m_lsvDCIDeviceModel";
            this.m_lsvDCIDeviceModel.Size = new System.Drawing.Size(404, 428);
            this.m_lsvDCIDeviceModel.TabIndex = 2;
            this.m_lsvDCIDeviceModel.UseCompatibleStateImageBehavior = false;
            this.m_lsvDCIDeviceModel.View = System.Windows.Forms.View.Details;
            this.m_lsvDCIDeviceModel.SelectedIndexChanged += new System.EventHandler(this.m_lsvDCIDeviceModel_SelectedIndexChanged);
            // 
            // m_chDeviceModela
            // 
            this.m_chDeviceModela.Text = "设备类型";
            this.m_chDeviceModela.Width = 150;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "仪器类别:";
            // 
            // m_lsvDeviceCheckItem
            // 
            this.m_lsvDeviceCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvDeviceCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chDeviceCheckItemName,
            this.m_chHasGraph,
            this.m_chQCItem});
            this.m_lsvDeviceCheckItem.FullRowSelect = true;
            this.m_lsvDeviceCheckItem.GridLines = true;
            this.m_lsvDeviceCheckItem.HideSelection = false;
            this.m_lsvDeviceCheckItem.Location = new System.Drawing.Point(444, 52);
            this.m_lsvDeviceCheckItem.MultiSelect = false;
            this.m_lsvDeviceCheckItem.Name = "m_lsvDeviceCheckItem";
            this.m_lsvDeviceCheckItem.Size = new System.Drawing.Size(444, 428);
            this.m_lsvDeviceCheckItem.TabIndex = 4;
            this.m_lsvDeviceCheckItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceCheckItem.View = System.Windows.Forms.View.Details;
            this.m_lsvDeviceCheckItem.DoubleClick += new System.EventHandler(this.m_lsvDeviceCheckItem_DoubleClick);
            // 
            // m_chDeviceCheckItemName
            // 
            this.m_chDeviceCheckItemName.Text = "仪器项目名称";
            this.m_chDeviceCheckItemName.Width = 150;
            // 
            // m_chHasGraph
            // 
            this.m_chHasGraph.Text = "是否有图";
            this.m_chHasGraph.Width = 120;
            // 
            // m_chQCItem
            // 
            this.m_chQCItem.Text = "质控项目";
            this.m_chQCItem.Width = 80;
            // 
            // m_tpDeviceCheckItemRelation
            // 
            this.m_tpDeviceCheckItemRelation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_tpDeviceCheckItemRelation.Controls.Add(this.groupBox2);
            this.m_tpDeviceCheckItemRelation.Controls.Add(this.groupBox1);
            this.m_tpDeviceCheckItemRelation.Controls.Add(this.groupBox3);
            this.m_tpDeviceCheckItemRelation.Controls.Add(this.m_txtSourceCheckItem);
            this.m_tpDeviceCheckItemRelation.Location = new System.Drawing.Point(4, 21);
            this.m_tpDeviceCheckItemRelation.Name = "m_tpDeviceCheckItemRelation";
            this.m_tpDeviceCheckItemRelation.Size = new System.Drawing.Size(944, 615);
            this.m_tpDeviceCheckItemRelation.TabIndex = 0;
            this.m_tpDeviceCheckItemRelation.Text = "仪器检验项目关系对应";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lsvCheckItemDeviceCheckItem);
            this.groupBox2.Controls.Add(this.m_lsvBaseCheckItem);
            this.groupBox2.Controls.Add(this.m_cboCheckItemType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(468, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(416, 512);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            // 
            // m_lsvCheckItemDeviceCheckItem
            // 
            this.m_lsvCheckItemDeviceCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvCheckItemDeviceCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chmCheckItemName,
            this.m_chmEnglishName,
            this.m_chmShortName});
            this.m_lsvCheckItemDeviceCheckItem.FullRowSelect = true;
            this.m_lsvCheckItemDeviceCheckItem.GridLines = true;
            this.m_lsvCheckItemDeviceCheckItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvCheckItemDeviceCheckItem.HideSelection = false;
            this.m_lsvCheckItemDeviceCheckItem.Location = new System.Drawing.Point(8, 256);
            this.m_lsvCheckItemDeviceCheckItem.MultiSelect = false;
            this.m_lsvCheckItemDeviceCheckItem.Name = "m_lsvCheckItemDeviceCheckItem";
            this.m_lsvCheckItemDeviceCheckItem.Size = new System.Drawing.Size(400, 248);
            this.m_lsvCheckItemDeviceCheckItem.TabIndex = 7;
            this.m_lsvCheckItemDeviceCheckItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvCheckItemDeviceCheckItem.View = System.Windows.Forms.View.Details;
            this.m_lsvCheckItemDeviceCheckItem.DoubleClick += new System.EventHandler(this.m_lsvCheckItemDeviceCheckItem_DoubleClick);
            // 
            // m_chmCheckItemName
            // 
            this.m_chmCheckItemName.Text = "检验项目名称";
            this.m_chmCheckItemName.Width = 100;
            // 
            // m_chmEnglishName
            // 
            this.m_chmEnglishName.Text = "英文名称";
            this.m_chmEnglishName.Width = 100;
            // 
            // m_chmShortName
            // 
            this.m_chmShortName.Text = "缩写";
            this.m_chmShortName.Width = 100;
            // 
            // m_lsvBaseCheckItem
            // 
            this.m_lsvBaseCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvBaseCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvBaseCheckItem.FullRowSelect = true;
            this.m_lsvBaseCheckItem.GridLines = true;
            this.m_lsvBaseCheckItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvBaseCheckItem.HideSelection = false;
            this.m_lsvBaseCheckItem.Location = new System.Drawing.Point(8, 48);
            this.m_lsvBaseCheckItem.MultiSelect = false;
            this.m_lsvBaseCheckItem.Name = "m_lsvBaseCheckItem";
            this.m_lsvBaseCheckItem.Size = new System.Drawing.Size(400, 204);
            this.m_lsvBaseCheckItem.TabIndex = 4;
            this.m_lsvBaseCheckItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvBaseCheckItem.View = System.Windows.Forms.View.Details;
            this.m_lsvBaseCheckItem.DoubleClick += new System.EventHandler(this.m_lsvBaseCheckItem_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "检验项目名称";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "英文名称";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "缩写";
            this.columnHeader3.Width = 100;
            // 
            // m_cboCheckItemType
            // 
            this.m_cboCheckItemType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboCheckItemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckItemType.Location = new System.Drawing.Point(112, 16);
            this.m_cboCheckItemType.Name = "m_cboCheckItemType";
            this.m_cboCheckItemType.Size = new System.Drawing.Size(132, 22);
            this.m_cboCheckItemType.TabIndex = 6;
            this.m_cboCheckItemType.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckItemType_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "检验项目类别:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_lsvCheckItem);
            this.groupBox1.Controls.Add(this.m_lsvDeviceList);
            this.groupBox1.Controls.Add(this.m_cboCategory);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 512);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "仪器类别:";
            // 
            // m_lsvCheckItem
            // 
            this.m_lsvCheckItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDeviceChckItemName,
            this.m_chmHasGraph});
            this.m_lsvCheckItem.FullRowSelect = true;
            this.m_lsvCheckItem.GridLines = true;
            this.m_lsvCheckItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvCheckItem.HideSelection = false;
            this.m_lsvCheckItem.Location = new System.Drawing.Point(8, 256);
            this.m_lsvCheckItem.MultiSelect = false;
            this.m_lsvCheckItem.Name = "m_lsvCheckItem";
            this.m_lsvCheckItem.Size = new System.Drawing.Size(404, 248);
            this.m_lsvCheckItem.TabIndex = 2;
            this.m_lsvCheckItem.UseCompatibleStateImageBehavior = false;
            this.m_lsvCheckItem.View = System.Windows.Forms.View.Details;
            this.m_lsvCheckItem.DoubleClick += new System.EventHandler(this.m_lsvCheckItem_DoubleClick);
            this.m_lsvCheckItem.SelectedIndexChanged += new System.EventHandler(this.m_lsvCheckItem_SelectedIndexChanged);
            // 
            // clmDeviceChckItemName
            // 
            this.clmDeviceChckItemName.Text = "仪器项目名称";
            this.clmDeviceChckItemName.Width = 137;
            // 
            // m_chmHasGraph
            // 
            this.m_chmHasGraph.Text = "是否有图";
            this.m_chmHasGraph.Width = 100;
            // 
            // m_lsvDeviceList
            // 
            this.m_lsvDeviceList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDeviceModel});
            this.m_lsvDeviceList.FullRowSelect = true;
            this.m_lsvDeviceList.GridLines = true;
            this.m_lsvDeviceList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvDeviceList.HideSelection = false;
            this.m_lsvDeviceList.Location = new System.Drawing.Point(8, 48);
            this.m_lsvDeviceList.MultiSelect = false;
            this.m_lsvDeviceList.Name = "m_lsvDeviceList";
            this.m_lsvDeviceList.Size = new System.Drawing.Size(404, 204);
            this.m_lsvDeviceList.TabIndex = 1;
            this.m_lsvDeviceList.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeviceList.View = System.Windows.Forms.View.Details;
            this.m_lsvDeviceList.SelectedIndexChanged += new System.EventHandler(this.m_lsvDeviceList_SelectedIndexChanged);
            // 
            // clmDeviceModel
            // 
            this.clmDeviceModel.Text = "仪器类型";
            this.clmDeviceModel.Width = 137;
            // 
            // m_cboCategory
            // 
            this.m_cboCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCategory.Location = new System.Drawing.Point(84, 16);
            this.m_cboCategory.Name = "m_cboCategory";
            this.m_cboCategory.Size = new System.Drawing.Size(132, 22);
            this.m_cboCategory.TabIndex = 0;
            this.m_cboCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCategory_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnExit3);
            this.groupBox3.Controls.Add(this.m_txtRelationDeviceModel);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.m_cmdSave);
            this.groupBox3.Controls.Add(this.m_cmdAppend);
            this.groupBox3.Controls.Add(this.m_cmdDelete);
            this.groupBox3.Controls.Add(this.m_txtBaseCheckItemName);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.m_txtDeviceItemName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(16, 540);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(872, 48);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            // 
            // btnExit3
            // 
            this.btnExit3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnExit3.DefaultScheme = true;
            this.btnExit3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit3.Hint = "";
            this.btnExit3.Location = new System.Drawing.Point(806, 12);
            this.btnExit3.Name = "btnExit3";
            this.btnExit3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit3.Size = new System.Drawing.Size(64, 28);
            this.btnExit3.TabIndex = 19;
            this.btnExit3.Text = "关闭";
            this.btnExit3.Click += new System.EventHandler(this.btnExit3_Click);
            // 
            // m_txtRelationDeviceModel
            // 
            this.m_txtRelationDeviceModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtRelationDeviceModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtRelationDeviceModel.Location = new System.Drawing.Point(80, 16);
            this.m_txtRelationDeviceModel.Name = "m_txtRelationDeviceModel";
            this.m_txtRelationDeviceModel.ReadOnly = true;
            this.m_txtRelationDeviceModel.Size = new System.Drawing.Size(104, 23);
            this.m_txtRelationDeviceModel.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 17;
            this.label6.Text = "仪器型号:";
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(678, 12);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(64, 28);
            this.m_cmdSave.TabIndex = 12;
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdAppend
            // 
            this.m_cmdAppend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdAppend.DefaultScheme = true;
            this.m_cmdAppend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAppend.Hint = "";
            this.m_cmdAppend.Location = new System.Drawing.Point(614, 12);
            this.m_cmdAppend.Name = "m_cmdAppend";
            this.m_cmdAppend.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAppend.Size = new System.Drawing.Size(64, 28);
            this.m_cmdAppend.TabIndex = 7;
            this.m_cmdAppend.Text = "添 加";
            this.m_cmdAppend.Click += new System.EventHandler(this.m_cmdAppend_Click);
            // 
            // m_cmdDelete
            // 
            this.m_cmdDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDelete.DefaultScheme = true;
            this.m_cmdDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDelete.Hint = "";
            this.m_cmdDelete.Location = new System.Drawing.Point(742, 12);
            this.m_cmdDelete.Name = "m_cmdDelete";
            this.m_cmdDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDelete.Size = new System.Drawing.Size(64, 28);
            this.m_cmdDelete.TabIndex = 15;
            this.m_cmdDelete.Text = "删除";
            this.m_cmdDelete.Click += new System.EventHandler(this.m_cmdDelete_Click);
            // 
            // m_txtBaseCheckItemName
            // 
            this.m_txtBaseCheckItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtBaseCheckItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBaseCheckItemName.Location = new System.Drawing.Point(507, 16);
            this.m_txtBaseCheckItemName.Name = "m_txtBaseCheckItemName";
            this.m_txtBaseCheckItemName.ReadOnly = true;
            this.m_txtBaseCheckItemName.Size = new System.Drawing.Size(104, 23);
            this.m_txtBaseCheckItemName.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "检验项目名称:";
            // 
            // m_txtDeviceItemName
            // 
            this.m_txtDeviceItemName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDeviceItemName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtDeviceItemName.Location = new System.Drawing.Point(295, 15);
            this.m_txtDeviceItemName.Name = "m_txtDeviceItemName";
            this.m_txtDeviceItemName.Size = new System.Drawing.Size(104, 23);
            this.m_txtDeviceItemName.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "仪器项目名称:";
            // 
            // m_txtSourceCheckItem
            // 
            this.m_txtSourceCheckItem.Location = new System.Drawing.Point(436, 584);
            this.m_txtSourceCheckItem.Name = "m_txtSourceCheckItem";
            this.m_txtSourceCheckItem.Size = new System.Drawing.Size(100, 23);
            this.m_txtSourceCheckItem.TabIndex = 19;
            this.m_txtSourceCheckItem.Visible = false;
            // 
            // m_tpDevice
            // 
            this.m_tpDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_tpDevice.Controls.Add(this.btnExit4);
            this.m_tpDevice.Controls.Add(this.m_gbpDevice);
            this.m_tpDevice.Controls.Add(this.m_btnDelDevice);
            this.m_tpDevice.Controls.Add(this.m_btnSaveDevice);
            this.m_tpDevice.Controls.Add(this.m_btnAddDevice);
            this.m_tpDevice.Controls.Add(this.m_lsvDevice);
            this.m_tpDevice.Location = new System.Drawing.Point(4, 21);
            this.m_tpDevice.Name = "m_tpDevice";
            this.m_tpDevice.Size = new System.Drawing.Size(944, 615);
            this.m_tpDevice.TabIndex = 3;
            this.m_tpDevice.Text = "仪器设备";
            // 
            // btnExit4
            // 
            this.btnExit4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.btnExit4.DefaultScheme = true;
            this.btnExit4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit4.Hint = "";
            this.btnExit4.Location = new System.Drawing.Point(848, 548);
            this.btnExit4.Name = "btnExit4";
            this.btnExit4.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit4.Size = new System.Drawing.Size(64, 28);
            this.btnExit4.TabIndex = 24;
            this.btnExit4.Text = "关闭";
            this.btnExit4.Click += new System.EventHandler(this.btnExit4_Click);
            // 
            // m_gbpDevice
            // 
            this.m_gbpDevice.Controls.Add(this.m_txtDeviceCode);
            this.m_gbpDevice.Controls.Add(this.m_lbDeviceCode);
            this.m_gbpDevice.Controls.Add(this.m_chkIsDataTrans);
            this.m_gbpDevice.Controls.Add(this.m_lbDept);
            this.m_gbpDevice.Controls.Add(this.m_lbDeviceIP);
            this.m_gbpDevice.Controls.Add(this.m_txtDeviceIP);
            this.m_gbpDevice.Controls.Add(this.m_lbDevicePlace);
            this.m_gbpDevice.Controls.Add(this.m_lbDeviceName);
            this.m_gbpDevice.Controls.Add(this.m_dtpToDat);
            this.m_gbpDevice.Controls.Add(this.m_chkStopDat);
            this.m_gbpDevice.Controls.Add(this.m_lbDeviceStopDat);
            this.m_gbpDevice.Controls.Add(this.m_dtpFromDat);
            this.m_gbpDevice.Controls.Add(this.m_lbDeviceBeginDat);
            this.m_gbpDevice.Controls.Add(this.m_txtDataReceiveComputerIP);
            this.m_gbpDevice.Controls.Add(this.m_lbReceiveComputerIP);
            this.m_gbpDevice.Controls.Add(this.m_cboDeviceModelName);
            this.m_gbpDevice.Controls.Add(this.m_txtDevicePlace);
            this.m_gbpDevice.Controls.Add(this.m_txtDept);
            this.m_gbpDevice.Controls.Add(this.m_lbDeviceModelName);
            this.m_gbpDevice.Controls.Add(this.m_txtDeviceName);
            this.m_gbpDevice.Location = new System.Drawing.Point(20, 0);
            this.m_gbpDevice.Name = "m_gbpDevice";
            this.m_gbpDevice.Size = new System.Drawing.Size(896, 120);
            this.m_gbpDevice.TabIndex = 23;
            this.m_gbpDevice.TabStop = false;
            // 
            // m_txtDeviceCode
            // 
            this.m_txtDeviceCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDeviceCode.Location = new System.Drawing.Point(88, 40);
            this.m_txtDeviceCode.MaxLength = 50;
            this.m_txtDeviceCode.Name = "m_txtDeviceCode";
            this.m_txtDeviceCode.Size = new System.Drawing.Size(116, 23);
            this.m_txtDeviceCode.TabIndex = 24;
            // 
            // m_lbDeviceCode
            // 
            this.m_lbDeviceCode.AutoSize = true;
            this.m_lbDeviceCode.Location = new System.Drawing.Point(24, 48);
            this.m_lbDeviceCode.Name = "m_lbDeviceCode";
            this.m_lbDeviceCode.Size = new System.Drawing.Size(63, 14);
            this.m_lbDeviceCode.TabIndex = 23;
            this.m_lbDeviceCode.Text = "仪器代号";
            // 
            // m_chkIsDataTrans
            // 
            this.m_chkIsDataTrans.Location = new System.Drawing.Point(636, 40);
            this.m_chkIsDataTrans.Name = "m_chkIsDataTrans";
            this.m_chkIsDataTrans.Size = new System.Drawing.Size(140, 24);
            this.m_chkIsDataTrans.TabIndex = 14;
            this.m_chkIsDataTrans.Text = "是否自动传输结果";
            // 
            // m_lbDept
            // 
            this.m_lbDept.AutoSize = true;
            this.m_lbDept.Location = new System.Drawing.Point(208, 44);
            this.m_lbDept.Name = "m_lbDept";
            this.m_lbDept.Size = new System.Drawing.Size(63, 14);
            this.m_lbDept.TabIndex = 12;
            this.m_lbDept.Text = "所属部门";
            // 
            // m_lbDeviceIP
            // 
            this.m_lbDeviceIP.AutoSize = true;
            this.m_lbDeviceIP.Location = new System.Drawing.Point(8, 72);
            this.m_lbDeviceIP.Name = "m_lbDeviceIP";
            this.m_lbDeviceIP.Size = new System.Drawing.Size(77, 14);
            this.m_lbDeviceIP.TabIndex = 15;
            this.m_lbDeviceIP.Text = "仪器IP地址";
            // 
            // m_txtDeviceIP
            // 
            this.m_txtDeviceIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDeviceIP.Location = new System.Drawing.Point(88, 64);
            this.m_txtDeviceIP.MaxLength = 16;
            this.m_txtDeviceIP.Name = "m_txtDeviceIP";
            this.m_txtDeviceIP.Size = new System.Drawing.Size(308, 23);
            this.m_txtDeviceIP.TabIndex = 16;
            // 
            // m_lbDevicePlace
            // 
            this.m_lbDevicePlace.AutoSize = true;
            this.m_lbDevicePlace.Location = new System.Drawing.Point(24, 92);
            this.m_lbDevicePlace.Name = "m_lbDevicePlace";
            this.m_lbDevicePlace.Size = new System.Drawing.Size(63, 14);
            this.m_lbDevicePlace.TabIndex = 10;
            this.m_lbDevicePlace.Text = "存放地点";
            // 
            // m_lbDeviceName
            // 
            this.m_lbDeviceName.AutoSize = true;
            this.m_lbDeviceName.Location = new System.Drawing.Point(24, 24);
            this.m_lbDeviceName.Name = "m_lbDeviceName";
            this.m_lbDeviceName.Size = new System.Drawing.Size(63, 14);
            this.m_lbDeviceName.TabIndex = 8;
            this.m_lbDeviceName.Text = "设备名称";
            // 
            // m_dtpToDat
            // 
            this.m_dtpToDat.Checked = false;
            this.m_dtpToDat.Enabled = false;
            this.m_dtpToDat.Location = new System.Drawing.Point(504, 40);
            this.m_dtpToDat.Name = "m_dtpToDat";
            this.m_dtpToDat.Size = new System.Drawing.Size(128, 23);
            this.m_dtpToDat.TabIndex = 7;
            // 
            // m_chkStopDat
            // 
            this.m_chkStopDat.Location = new System.Drawing.Point(400, 44);
            this.m_chkStopDat.Name = "m_chkStopDat";
            this.m_chkStopDat.Size = new System.Drawing.Size(16, 24);
            this.m_chkStopDat.TabIndex = 22;
            this.m_chkStopDat.CheckedChanged += new System.EventHandler(this.m_chkStopDat_CheckedChanged);
            // 
            // m_lbDeviceStopDat
            // 
            this.m_lbDeviceStopDat.AutoSize = true;
            this.m_lbDeviceStopDat.Location = new System.Drawing.Point(416, 48);
            this.m_lbDeviceStopDat.Name = "m_lbDeviceStopDat";
            this.m_lbDeviceStopDat.Size = new System.Drawing.Size(91, 14);
            this.m_lbDeviceStopDat.TabIndex = 6;
            this.m_lbDeviceStopDat.Text = "设备停用日期";
            // 
            // m_dtpFromDat
            // 
            this.m_dtpFromDat.Location = new System.Drawing.Point(504, 16);
            this.m_dtpFromDat.Name = "m_dtpFromDat";
            this.m_dtpFromDat.Size = new System.Drawing.Size(128, 23);
            this.m_dtpFromDat.TabIndex = 5;
            // 
            // m_lbDeviceBeginDat
            // 
            this.m_lbDeviceBeginDat.AutoSize = true;
            this.m_lbDeviceBeginDat.Location = new System.Drawing.Point(416, 24);
            this.m_lbDeviceBeginDat.Name = "m_lbDeviceBeginDat";
            this.m_lbDeviceBeginDat.Size = new System.Drawing.Size(91, 14);
            this.m_lbDeviceBeginDat.TabIndex = 4;
            this.m_lbDeviceBeginDat.Text = "设备启用日期";
            // 
            // m_txtDataReceiveComputerIP
            // 
            this.m_txtDataReceiveComputerIP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDataReceiveComputerIP.Location = new System.Drawing.Point(568, 64);
            this.m_txtDataReceiveComputerIP.MaxLength = 16;
            this.m_txtDataReceiveComputerIP.Name = "m_txtDataReceiveComputerIP";
            this.m_txtDataReceiveComputerIP.Size = new System.Drawing.Size(300, 23);
            this.m_txtDataReceiveComputerIP.TabIndex = 3;
            // 
            // m_lbReceiveComputerIP
            // 
            this.m_lbReceiveComputerIP.AutoSize = true;
            this.m_lbReceiveComputerIP.Location = new System.Drawing.Point(400, 68);
            this.m_lbReceiveComputerIP.Name = "m_lbReceiveComputerIP";
            this.m_lbReceiveComputerIP.Size = new System.Drawing.Size(161, 14);
            this.m_lbReceiveComputerIP.TabIndex = 2;
            this.m_lbReceiveComputerIP.Text = "接收数据的计算机IP地址";
            // 
            // m_cboDeviceModelName
            // 
            this.m_cboDeviceModelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_cboDeviceModelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDeviceModelName.Location = new System.Drawing.Point(272, 16);
            this.m_cboDeviceModelName.Name = "m_cboDeviceModelName";
            this.m_cboDeviceModelName.Size = new System.Drawing.Size(124, 22);
            this.m_cboDeviceModelName.TabIndex = 1;
            // 
            // m_txtDevicePlace
            // 
            this.m_txtDevicePlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDevicePlace.Location = new System.Drawing.Point(88, 88);
            this.m_txtDevicePlace.MaxLength = 100;
            this.m_txtDevicePlace.Name = "m_txtDevicePlace";
            this.m_txtDevicePlace.Size = new System.Drawing.Size(780, 23);
            this.m_txtDevicePlace.TabIndex = 11;
            // 
            // m_txtDept
            // 
            this.m_txtDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDept.EnableAutoValidation = true;
            this.m_txtDept.EnableEnterKeyValidate = true;
            this.m_txtDept.EnableEscapeKeyUndo = true;
            this.m_txtDept.EnableLastValidValue = true;
            this.m_txtDept.ErrorProvider = null;
            this.m_txtDept.ErrorProviderMessage = "Invalid value";
            this.m_txtDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDept.ForceFormatText = true;
            this.m_txtDept.Location = new System.Drawing.Point(272, 40);
            this.m_txtDept.m_StrDeptID = null;
            this.m_txtDept.m_StrDeptName = null;
            this.m_txtDept.Name = "m_txtDept";
            this.m_txtDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtDept.Size = new System.Drawing.Size(124, 23);
            this.m_txtDept.TabIndex = 17;
            // 
            // m_lbDeviceModelName
            // 
            this.m_lbDeviceModelName.AutoSize = true;
            this.m_lbDeviceModelName.Location = new System.Drawing.Point(208, 24);
            this.m_lbDeviceModelName.Name = "m_lbDeviceModelName";
            this.m_lbDeviceModelName.Size = new System.Drawing.Size(63, 14);
            this.m_lbDeviceModelName.TabIndex = 0;
            this.m_lbDeviceModelName.Text = "仪器型号";
            // 
            // m_txtDeviceName
            // 
            this.m_txtDeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(255)))));
            this.m_txtDeviceName.Location = new System.Drawing.Point(88, 16);
            this.m_txtDeviceName.MaxLength = 50;
            this.m_txtDeviceName.Name = "m_txtDeviceName";
            this.m_txtDeviceName.Size = new System.Drawing.Size(116, 23);
            this.m_txtDeviceName.TabIndex = 9;
            // 
            // m_btnDelDevice
            // 
            this.m_btnDelDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnDelDevice.DefaultScheme = true;
            this.m_btnDelDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDelDevice.Hint = "";
            this.m_btnDelDevice.Location = new System.Drawing.Point(769, 548);
            this.m_btnDelDevice.Name = "m_btnDelDevice";
            this.m_btnDelDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDelDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnDelDevice.TabIndex = 21;
            this.m_btnDelDevice.Text = "删除";
            this.m_btnDelDevice.Click += new System.EventHandler(this.m_btnDelDevice_Click);
            // 
            // m_btnSaveDevice
            // 
            this.m_btnSaveDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnSaveDevice.DefaultScheme = true;
            this.m_btnSaveDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSaveDevice.Hint = "";
            this.m_btnSaveDevice.Location = new System.Drawing.Point(689, 548);
            this.m_btnSaveDevice.Name = "m_btnSaveDevice";
            this.m_btnSaveDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSaveDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnSaveDevice.TabIndex = 20;
            this.m_btnSaveDevice.Text = "保存";
            this.m_btnSaveDevice.Click += new System.EventHandler(this.m_btnSaveDevice_Click);
            // 
            // m_btnAddDevice
            // 
            this.m_btnAddDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.m_btnAddDevice.DefaultScheme = true;
            this.m_btnAddDevice.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnAddDevice.Hint = "";
            this.m_btnAddDevice.Location = new System.Drawing.Point(609, 548);
            this.m_btnAddDevice.Name = "m_btnAddDevice";
            this.m_btnAddDevice.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnAddDevice.Size = new System.Drawing.Size(64, 28);
            this.m_btnAddDevice.TabIndex = 19;
            this.m_btnAddDevice.Text = "添加";
            this.m_btnAddDevice.Click += new System.EventHandler(this.m_btnAddDevice_Click);
            // 
            // m_lsvDevice
            // 
            this.m_lsvDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(199)))), ((int)(((byte)(214)))));
            this.m_lsvDevice.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_chDeviceCode,
            this.m_chDeviceName,
            this.m_chDeviceModel,
            this.m_chDept,
            this.m_chDevicePlace,
            this.m_chDataReceiveIP,
            this.m_chDeviceBeginDat,
            this.m_chDeviceEndDat});
            this.m_lsvDevice.FullRowSelect = true;
            this.m_lsvDevice.GridLines = true;
            this.m_lsvDevice.Location = new System.Drawing.Point(20, 124);
            this.m_lsvDevice.Name = "m_lsvDevice";
            this.m_lsvDevice.Size = new System.Drawing.Size(896, 408);
            this.m_lsvDevice.TabIndex = 18;
            this.m_lsvDevice.UseCompatibleStateImageBehavior = false;
            this.m_lsvDevice.View = System.Windows.Forms.View.Details;
            this.m_lsvDevice.DoubleClick += new System.EventHandler(this.m_lsvDevice_DoubleClick);
            // 
            // m_chDeviceCode
            // 
            this.m_chDeviceCode.Text = "仪器代号";
            this.m_chDeviceCode.Width = 86;
            // 
            // m_chDeviceName
            // 
            this.m_chDeviceName.Text = "仪器名称";
            this.m_chDeviceName.Width = 95;
            // 
            // m_chDeviceModel
            // 
            this.m_chDeviceModel.Text = "仪器型号";
            this.m_chDeviceModel.Width = 114;
            // 
            // m_chDept
            // 
            this.m_chDept.Text = "所属部门";
            this.m_chDept.Width = 101;
            // 
            // m_chDevicePlace
            // 
            this.m_chDevicePlace.Text = "存放地点";
            this.m_chDevicePlace.Width = 121;
            // 
            // m_chDataReceiveIP
            // 
            this.m_chDataReceiveIP.Text = "接收数据的计算机IP";
            this.m_chDataReceiveIP.Width = 150;
            // 
            // m_chDeviceBeginDat
            // 
            this.m_chDeviceBeginDat.Text = "设备启用时间";
            this.m_chDeviceBeginDat.Width = 106;
            // 
            // m_chDeviceEndDat
            // 
            this.m_chDeviceEndDat.Text = "设备停用时间";
            this.m_chDeviceEndDat.Width = 107;
            // 
            // frmLisDeviceManage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(174)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(1016, 697);
            this.Controls.Add(this.m_tabDeviceManage);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmLisDeviceManage";
            this.Text = "检验仪器管理";
            this.Load += new System.EventHandler(this.frmLisDeviceManage_Load);
            this.m_tabDeviceManage.ResumeLayout(false);
            this.m_tpDeviceModel.ResumeLayout(false);
            this.m_gpbDeviceModel.ResumeLayout(false);
            this.m_gpbDeviceModel.PerformLayout();
            this.m_tpDeviceSerial.ResumeLayout(false);
            this.m_gpbDevicePara.ResumeLayout(false);
            this.m_gpbDevicePara.PerformLayout();
            this.m_tpSpecialDevice.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.m_tpDeviceCheckItem.ResumeLayout(false);
            this.m_gpbDeviceCheckItemDetail.ResumeLayout(false);
            this.m_gpbDeviceCheckItemDetail.PerformLayout();
            this.gpbDeviceModel.ResumeLayout(false);
            this.gpbDeviceModel.PerformLayout();
            this.m_tpDeviceCheckItemRelation.ResumeLayout(false);
            this.m_tpDeviceCheckItemRelation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.m_tpDevice.ResumeLayout(false);
            this.m_gbpDevice.ResumeLayout(false);
            this.m_gbpDevice.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new frmLisDeviceManage());
		}


		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.LIS.clsController_LisDeviceManage();
			objController.Set_GUI_Apperance(this);
		}

		private void m_lsvDeviceList_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetCheckItemByModelID();
		}

		private void frmLisDeviceManage_Load(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetDeviceCategory();
			((clsController_LisDeviceManage)this.objController).m_mthGetCheckCategory();
			((clsController_LisDeviceManage)this.objController).m_mthGetDeviceCategoryWithoutAll();
			((clsController_LisDeviceManage)this.objController).m_mthGetAllDeviceModelList();
			((clsController_LisDeviceManage)this.objController).m_mthGetAllDeviceModelToCbo();
			this.m_cboComNo.SelectedIndex = 0;
			((clsController_LisDeviceManage)this.objController).m_mthGetAllDeviceSerial();
			((clsController_LisDeviceManage)this.objController).m_mthGetAllDeviceModel();
			((clsController_LisDeviceManage)this.objController).m_mthGetAllDevice();
            //2011-12-6
            ((clsController_LisDeviceManage)this.objController).m_mthGetAllSpecialDevice();
		}


		private void m_cboCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetDevice();
		}

		private void m_lsvCheckItem_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSetDeviceCheckItem();
		}

		private void m_cmdAppend_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthAppendDeviceCheckItem();
		}

		private void m_cboCheckItemType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetCheckItem();
		}

		private void m_lsvBaseCheckItem_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSetCheckItemRelation();
		}

		private void m_cmdSave_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthDoSave();
		}

		private void m_cmdDelete_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthDelCheckItemDeviceCheckItem();
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthClearDeviceModel();
		}

		private void m_lsvDeviceModel_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSetDeviceModel();
		}

		private void m_btnSaveDeviceModel_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSaveDeviceModel();
		}

		private void m_btnDelDeviceModel_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthDelDeviceModel();
		}

		private void m_btnAddDeviceSerial_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthClearDeviceSerial();
		}

		private void m_lsvDeviceSerialSetUp_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSetDeviceSerial();
		}

		private void m_btnSaveDeviceSerial_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSaveDeviceSerial();
		}

		private void m_btnDelDeviceSerial_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthDelDeviceSerial();
		}

		private void m_btnAddDevice_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthClearAllDevice();
		}

		private void m_btnSaveDevice_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSaveDevice();
		}

		private void m_btnDelDevice_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthDelDevice();
		}

		private void m_lsvDevice_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSetDevice();
		}

		private void m_chkStopDat_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.m_chkStopDat.Checked)
			{
				this.m_dtpToDat.Enabled = true;
			}
			else
			{
				this.m_dtpToDat.Enabled = false;
			}
		}

		#region 获取仪器类别
		private void m_cboDCIDeviceCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetDeviceCheckItemDevice();
		}
		#endregion

		#region 根据仪器型号获取仪器检验项目
		private void m_lsvDCIDeviceModel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetDeviceCheckItemByDeviceModelID();
		}
		#endregion

		#region 添加仪器仪器检验项目 童华 2004.07.19
		private void m_btnAddDeviceCheckItem_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthClearDeviceCheckItem();
		}
		#endregion

		#region 显示选中的仪器检验项目 童华 2004.07.19
		private void m_lsvDeviceCheckItem_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthShowDeviceCheckItem();
		}
		#endregion

		#region 保存仪器检验项目 童华 2004.07.20
		private void m_btnSaveDeviceCheckItem_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSaveDeviceCheckItem();
		}
		#endregion

		#region 删除仪器检验项目 童华 2004.07.20
		private void m_btnDelDeviceCheckItem_Click(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthDelDeviceCheckItem();
		}
		#endregion

		#region 根据仪器型号获取仪器项目（对应关系） 童华 2004.07.20
		private void m_lsvDeviceList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetCheckItemByModelID();
		}
		#endregion

		#region 获取仪器检验项目对应关系 童华 2004.07.20
		private void m_lsvCheckItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthGetCheckItemDeviceCheckItemRelation();
		}
		#endregion

		#region 显示选中的仪器检验项目关系 童华 2004.07.20
		private void m_lsvCheckItemDeviceCheckItem_DoubleClick(object sender, System.EventArgs e)
		{
			((clsController_LisDeviceManage)this.objController).m_mthSetCheckItemDeviceCheckItem();
		}
		#endregion

		private void m_chkHex_CheckedChanged(object sender, System.EventArgs e)
		{
			string str = this.m_txtSendCommand.Text;
			if(m_chkHex.Checked)
			{
				this.m_txtSendCommand.Text = com.digitalwave.Utility.clsHexConvert.m_strToHexString(str);
			}
			else
			{
				this.m_txtSendCommand.Text = com.digitalwave.Utility.clsHexConvert.m_strToTextString(str);
			}
		}

        private void btnExit0_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region 特殊仪器参数配置 2011-12-5
        private void m_btnAddSpecialDevice_Click(object sender, EventArgs e)
        {
            ((clsController_LisDeviceManage)this.objController).m_mthSetSpecialDeviceControl();
        }
        private void m_btnSaveSpecialDevice_Click(object sender, EventArgs e)
        {
            if (!m_chkAutoRead.Checked && !m_chkHandDriver.Checked && !m_chkMatterDriver.Checked)
            {
                MessageBox.Show(this, "至少选择一种工作方式", "特殊仪器维护提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (m_chkAutoRead.Checked)
            {
                if (string.IsNullOrEmpty(m_txtSpecialDeviceInterval.Text))
                {
                    MessageBox.Show(this, "请输入轮值间隔时间", "特殊仪器维护提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (string.IsNullOrEmpty(m_txtSpecialDeviceDll.Text) || string.IsNullOrEmpty(m_txtSpecialDeviceClass.Text))
            {
                MessageBox.Show(this, "数据分析dll，数据分析对象类名不能为空", "特殊仪器维护提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsController_LisDeviceManage)this.objController).m_mthAddSpecialDevice();
        }

        private void m_btnDelSpecialDevice_Click(object sender, EventArgs e)
        {
            ((clsController_LisDeviceManage)this.objController).m_mthDeleteSpecicalDevice();
        }

        private void m_btnExitSpecialDevice_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void m_lstSpecialDevice_DoubleClick(object sender, EventArgs e)
        {
            ((clsController_LisDeviceManage)this.objController).m_mthSetSpecialInfo();
        }


        private void m_chkAutoRead_CheckedChanged(object sender, EventArgs e)
        {
            if (m_chkAutoRead.Checked)
            {
                m_txtSpecialDeviceInterval.Enabled = true;
            }
            else
            {
                m_txtSpecialDeviceInterval.Enabled = false;
            }
        }
        #endregion


    }
}
