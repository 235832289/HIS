using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using com.digitalwave.iCare.ValueObject;  //iCareData.dll
using Microsoft.VisualBasic;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.LIS;
using System.Collections.Generic;


namespace com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class frmLIS_Data_Acquisition_Controller : System.Windows.Forms.Form
    {

        #region FormControl
        private System.Windows.Forms.GroupBox grpSerialParameters;
        private System.Windows.Forms.Label lblCOM;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Label lblReceiveBuffer;
        private System.Windows.Forms.Label lblSendBuffer;
        private System.Windows.Forms.Label lblInstrument;
        private System.Windows.Forms.Label lblDataBit;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.Label lblFlowControl;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Label lblStopBit;
        internal System.Windows.Forms.ListView lsvInstrument_Status;
        private System.Windows.Forms.ColumnHeader chdInstrumentName;
        private System.Windows.Forms.ColumnHeader chdStatus;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtComNum;
        internal com.digitalwave.controls.ctlComboBox m_cboInstrument;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtBaudRate;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtDataBit;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtStopBit;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtParity;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtFlowControl;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtReceiveBuffer;
        internal com.digitalwave.controls.ctlBorderTextBox m_txtSendBuffer;

        private System.ComponentModel.IContainer components;
        #endregion
        private com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.clsController_LIS_Data_Acquisition objLIS_Controller = null;
        private com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.clsInstrument_Connection_Info[] colInstrumentList = null;

        //2012-01-19 yongchao.li修改
        private List<clsInstrument_Connection_Info> colInstrumentList1 = null;

        private frmRealtimeMessage m_frmRealWindow;
        private System.Windows.Forms.ContextMenu m_ctmnuNotify;
        private System.Windows.Forms.MenuItem m_mnuControl;
        private System.Windows.Forms.MenuItem m_mnuRealWindow;
        private System.Windows.Forms.MenuItem m_mnuExit;
        private NotifyIcon m_objNotify;
        private bool m_blnIsExit = false;

        private readonly Point m_pitSwitchButtonBeginLocation = new Point(726, 38);
        private readonly int m_intSwitchButtonHeight = 16;
        private readonly int m_intSwitchButtonWidth = 42;
        private ArrayList m_arlNetThread = new ArrayList();
        private Sybase.DataWindow.DataStore dataStore1;
        /// <summary>
        /// 内存回收用
        /// </summary>
        private static System.Windows.Forms.Timer m_tmrReleaseMemory;

        //xing.chen add test code
        private com.digitalwave.Utility.clsLogText testLog = new com.digitalwave.Utility.clsLogText();

        public frmLIS_Data_Acquisition_Controller()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            m_frmRealWindow = new frmRealtimeMessage();
            //			m_frmRealWindow.ShowInTaskbar = false;
            m_frmRealWindow.WindowState = System.Windows.Forms.FormWindowState.Normal;
            m_frmRealWindow.Show();
            m_frmRealWindow.Hide();

            this.components = new System.ComponentModel.Container();

            m_objNotify = new NotifyIcon(this.components);
            m_objNotify.Text = "数据采集实时监控";

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLIS_Data_Acquisition_Controller));
            try
            {
                Icon ico = (Icon)resources.GetObject("$this.Icon");
                //				m_objNotify.Icon = new Icon("..\\..\\..\\Images\\接口图标32-24-16全套.ico");
                m_objNotify.Icon = ico;
            }
            catch
            {
                //				m_objNotify.Icon = new Icon("appicon.ico");
            }
            m_objNotify.ContextMenu = m_ctmnuNotify;
            m_objNotify.DoubleClick += new EventHandler(m_objNotify_DoubleClick);
            m_objNotify.Visible = true;
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLIS_Data_Acquisition_Controller));
            this.lblReceiveBuffer = new System.Windows.Forms.Label();
            this.lblSendBuffer = new System.Windows.Forms.Label();
            this.grpSerialParameters = new System.Windows.Forms.GroupBox();
            this.m_cboInstrument = new com.digitalwave.controls.ctlComboBox();
            this.m_txtSendBuffer = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtReceiveBuffer = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtFlowControl = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtParity = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtStopBit = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtDataBit = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtBaudRate = new com.digitalwave.controls.ctlBorderTextBox();
            this.m_txtComNum = new com.digitalwave.controls.ctlBorderTextBox();
            this.lblInstrument = new System.Windows.Forms.Label();
            this.lblDataBit = new System.Windows.Forms.Label();
            this.lblCOM = new System.Windows.Forms.Label();
            this.lblParity = new System.Windows.Forms.Label();
            this.lblFlowControl = new System.Windows.Forms.Label();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.lblStopBit = new System.Windows.Forms.Label();
            this.lsvInstrument_Status = new System.Windows.Forms.ListView();
            this.chdInstrumentName = new System.Windows.Forms.ColumnHeader();
            this.chdStatus = new System.Windows.Forms.ColumnHeader();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.m_ctmnuNotify = new System.Windows.Forms.ContextMenu();
            this.m_mnuControl = new System.Windows.Forms.MenuItem();
            this.m_mnuRealWindow = new System.Windows.Forms.MenuItem();
            this.m_mnuExit = new System.Windows.Forms.MenuItem();
            this.dataStore1 = new Sybase.DataWindow.DataStore(this.components);
            this.grpSerialParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReceiveBuffer
            // 
            this.lblReceiveBuffer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReceiveBuffer.ForeColor = System.Drawing.Color.White;
            this.lblReceiveBuffer.Location = new System.Drawing.Point(11, 260);
            this.lblReceiveBuffer.Name = "lblReceiveBuffer";
            this.lblReceiveBuffer.Size = new System.Drawing.Size(72, 16);
            this.lblReceiveBuffer.TabIndex = 11;
            this.lblReceiveBuffer.Text = "接收缓冲";
            // 
            // lblSendBuffer
            // 
            this.lblSendBuffer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSendBuffer.ForeColor = System.Drawing.Color.White;
            this.lblSendBuffer.Location = new System.Drawing.Point(11, 293);
            this.lblSendBuffer.Name = "lblSendBuffer";
            this.lblSendBuffer.Size = new System.Drawing.Size(77, 16);
            this.lblSendBuffer.TabIndex = 10;
            this.lblSendBuffer.Text = "发送缓冲";
            // 
            // grpSerialParameters
            // 
            this.grpSerialParameters.Controls.Add(this.m_cboInstrument);
            this.grpSerialParameters.Controls.Add(this.m_txtSendBuffer);
            this.grpSerialParameters.Controls.Add(this.m_txtReceiveBuffer);
            this.grpSerialParameters.Controls.Add(this.m_txtFlowControl);
            this.grpSerialParameters.Controls.Add(this.m_txtParity);
            this.grpSerialParameters.Controls.Add(this.m_txtStopBit);
            this.grpSerialParameters.Controls.Add(this.m_txtDataBit);
            this.grpSerialParameters.Controls.Add(this.m_txtBaudRate);
            this.grpSerialParameters.Controls.Add(this.m_txtComNum);
            this.grpSerialParameters.Controls.Add(this.lblInstrument);
            this.grpSerialParameters.Controls.Add(this.lblDataBit);
            this.grpSerialParameters.Controls.Add(this.lblCOM);
            this.grpSerialParameters.Controls.Add(this.lblParity);
            this.grpSerialParameters.Controls.Add(this.lblFlowControl);
            this.grpSerialParameters.Controls.Add(this.lblBaudRate);
            this.grpSerialParameters.Controls.Add(this.lblStopBit);
            this.grpSerialParameters.Controls.Add(this.lblReceiveBuffer);
            this.grpSerialParameters.Controls.Add(this.lblSendBuffer);
            this.grpSerialParameters.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grpSerialParameters.ForeColor = System.Drawing.Color.White;
            this.grpSerialParameters.Location = new System.Drawing.Point(40, 8);
            this.grpSerialParameters.Name = "grpSerialParameters";
            this.grpSerialParameters.Size = new System.Drawing.Size(232, 328);
            this.grpSerialParameters.TabIndex = 16;
            this.grpSerialParameters.TabStop = false;
            this.grpSerialParameters.Text = "串口通迅参数设置";
            // 
            // m_cboInstrument
            // 
            this.m_cboInstrument.BorderColor = System.Drawing.Color.White;
            this.m_cboInstrument.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
            this.m_cboInstrument.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboInstrument.DropButtonForeColor = System.Drawing.Color.White;
            this.m_cboInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.m_cboInstrument.flatFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.m_cboInstrument.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
            this.m_cboInstrument.ListBackColor = System.Drawing.Color.White;
            this.m_cboInstrument.ListForeColor = System.Drawing.Color.Black;
            this.m_cboInstrument.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboInstrument.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboInstrument.Location = new System.Drawing.Point(80, 32);
            this.m_cboInstrument.Name = "m_cboInstrument";
            this.m_cboInstrument.SelectedIndex = -1;
            this.m_cboInstrument.SelectedItem = null;
            this.m_cboInstrument.Size = new System.Drawing.Size(144, 26);
            this.m_cboInstrument.TabIndex = 29;
            this.m_cboInstrument.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
            this.m_cboInstrument.TextForeColor = System.Drawing.Color.White;
            this.m_cboInstrument.SelectedIndexChanged += new System.EventHandler(this.m_cboInstrument_SelectedIndexChanged);  // 
            // m_txtSendBuffer
            // 
            this.m_txtSendBuffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtSendBuffer.BorderColor = System.Drawing.Color.White;
            this.m_txtSendBuffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtSendBuffer.ForeColor = System.Drawing.Color.White;
            this.m_txtSendBuffer.Location = new System.Drawing.Point(80, 288);
            this.m_txtSendBuffer.Name = "m_txtSendBuffer";
            this.m_txtSendBuffer.ReadOnly = true;
            this.m_txtSendBuffer.Size = new System.Drawing.Size(144, 26);
            this.m_txtSendBuffer.TabIndex = 28;
            // 
            // m_txtReceiveBuffer
            // 
            this.m_txtReceiveBuffer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtReceiveBuffer.BorderColor = System.Drawing.Color.White;
            this.m_txtReceiveBuffer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReceiveBuffer.ForeColor = System.Drawing.Color.White;
            this.m_txtReceiveBuffer.Location = new System.Drawing.Point(80, 256);
            this.m_txtReceiveBuffer.Name = "m_txtReceiveBuffer";
            this.m_txtReceiveBuffer.ReadOnly = true;
            this.m_txtReceiveBuffer.Size = new System.Drawing.Size(144, 26);
            this.m_txtReceiveBuffer.TabIndex = 27;
            // 
            // m_txtFlowControl
            // 
            this.m_txtFlowControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtFlowControl.BorderColor = System.Drawing.Color.White;
            this.m_txtFlowControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtFlowControl.ForeColor = System.Drawing.Color.White;
            this.m_txtFlowControl.Location = new System.Drawing.Point(80, 224);
            this.m_txtFlowControl.Name = "m_txtFlowControl";
            this.m_txtFlowControl.ReadOnly = true;
            this.m_txtFlowControl.Size = new System.Drawing.Size(144, 26);
            this.m_txtFlowControl.TabIndex = 26;
            // 
            // m_txtParity
            // 
            this.m_txtParity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtParity.BorderColor = System.Drawing.Color.White;
            this.m_txtParity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtParity.ForeColor = System.Drawing.Color.White;
            this.m_txtParity.Location = new System.Drawing.Point(80, 192);
            this.m_txtParity.Name = "m_txtParity";
            this.m_txtParity.ReadOnly = true;
            this.m_txtParity.Size = new System.Drawing.Size(144, 26);
            this.m_txtParity.TabIndex = 25;
            // 
            // m_txtStopBit
            // 
            this.m_txtStopBit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtStopBit.BorderColor = System.Drawing.Color.White;
            this.m_txtStopBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtStopBit.ForeColor = System.Drawing.Color.White;
            this.m_txtStopBit.Location = new System.Drawing.Point(80, 160);
            this.m_txtStopBit.Name = "m_txtStopBit";
            this.m_txtStopBit.ReadOnly = true;
            this.m_txtStopBit.Size = new System.Drawing.Size(144, 26);
            this.m_txtStopBit.TabIndex = 24;
            // 
            // m_txtDataBit
            // 
            this.m_txtDataBit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtDataBit.BorderColor = System.Drawing.Color.White;
            this.m_txtDataBit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtDataBit.ForeColor = System.Drawing.Color.White;
            this.m_txtDataBit.Location = new System.Drawing.Point(80, 128);
            this.m_txtDataBit.Name = "m_txtDataBit";
            this.m_txtDataBit.ReadOnly = true;
            this.m_txtDataBit.Size = new System.Drawing.Size(144, 26);
            this.m_txtDataBit.TabIndex = 23;
            // 
            // m_txtBaudRate
            // 
            this.m_txtBaudRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtBaudRate.BorderColor = System.Drawing.Color.White;
            this.m_txtBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBaudRate.ForeColor = System.Drawing.Color.White;
            this.m_txtBaudRate.Location = new System.Drawing.Point(80, 96);
            this.m_txtBaudRate.Name = "m_txtBaudRate";
            this.m_txtBaudRate.ReadOnly = true;
            this.m_txtBaudRate.Size = new System.Drawing.Size(144, 26);
            this.m_txtBaudRate.TabIndex = 22;
            // 
            // m_txtComNum
            // 
            this.m_txtComNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.m_txtComNum.BorderColor = System.Drawing.Color.White;
            this.m_txtComNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtComNum.ForeColor = System.Drawing.Color.White;
            this.m_txtComNum.Location = new System.Drawing.Point(80, 64);
            this.m_txtComNum.Name = "m_txtComNum";
            this.m_txtComNum.ReadOnly = true;
            this.m_txtComNum.Size = new System.Drawing.Size(144, 26);
            this.m_txtComNum.TabIndex = 21;
            // 
            // lblInstrument
            // 
            this.lblInstrument.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInstrument.ForeColor = System.Drawing.Color.White;
            this.lblInstrument.Location = new System.Drawing.Point(11, 37);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(72, 16);
            this.lblInstrument.TabIndex = 20;
            this.lblInstrument.Text = "检验仪器";
            // 
            // lblDataBit
            // 
            this.lblDataBit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDataBit.ForeColor = System.Drawing.Color.White;
            this.lblDataBit.Location = new System.Drawing.Point(11, 132);
            this.lblDataBit.Name = "lblDataBit";
            this.lblDataBit.Size = new System.Drawing.Size(68, 16);
            this.lblDataBit.TabIndex = 7;
            this.lblDataBit.Text = "数据位";
            // 
            // lblCOM
            // 
            this.lblCOM.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCOM.ForeColor = System.Drawing.Color.White;
            this.lblCOM.Location = new System.Drawing.Point(11, 68);
            this.lblCOM.Name = "lblCOM";
            this.lblCOM.Size = new System.Drawing.Size(60, 16);
            this.lblCOM.TabIndex = 4;
            this.lblCOM.Text = "串  口";
            // 
            // lblParity
            // 
            this.lblParity.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblParity.ForeColor = System.Drawing.Color.White;
            this.lblParity.Location = new System.Drawing.Point(11, 196);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(60, 16);
            this.lblParity.TabIndex = 11;
            this.lblParity.Text = "校验位";
            // 
            // lblFlowControl
            // 
            this.lblFlowControl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFlowControl.ForeColor = System.Drawing.Color.White;
            this.lblFlowControl.Location = new System.Drawing.Point(11, 228);
            this.lblFlowControl.Name = "lblFlowControl";
            this.lblFlowControl.Size = new System.Drawing.Size(60, 16);
            this.lblFlowControl.TabIndex = 10;
            this.lblFlowControl.Text = "流控制";
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBaudRate.ForeColor = System.Drawing.Color.White;
            this.lblBaudRate.Location = new System.Drawing.Point(11, 98);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(60, 16);
            this.lblBaudRate.TabIndex = 4;
            this.lblBaudRate.Text = "波特率";
            // 
            // lblStopBit
            // 
            this.lblStopBit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStopBit.ForeColor = System.Drawing.Color.White;
            this.lblStopBit.Location = new System.Drawing.Point(11, 164);
            this.lblStopBit.Name = "lblStopBit";
            this.lblStopBit.Size = new System.Drawing.Size(60, 16);
            this.lblStopBit.TabIndex = 6;
            this.lblStopBit.Text = "停止位";
            // 
            // lsvInstrument_Status
            // 
            this.lsvInstrument_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.lsvInstrument_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvInstrument_Status.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdInstrumentName,
            this.chdStatus});
            this.lsvInstrument_Status.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvInstrument_Status.ForeColor = System.Drawing.Color.White;
            this.lsvInstrument_Status.FullRowSelect = true;
            this.lsvInstrument_Status.GridLines = true;
            this.lsvInstrument_Status.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvInstrument_Status.Location = new System.Drawing.Point(280, 16);
            this.lsvInstrument_Status.MultiSelect = false;
            this.lsvInstrument_Status.Name = "lsvInstrument_Status";
            this.lsvInstrument_Status.Size = new System.Drawing.Size(436, 320);
            this.lsvInstrument_Status.TabIndex = 17;
            this.lsvInstrument_Status.UseCompatibleStateImageBehavior = false;
            this.lsvInstrument_Status.View = System.Windows.Forms.View.Details;
            // 
            // chdInstrumentName
            // 
            this.chdInstrumentName.Text = "仪器名称";
            this.chdInstrumentName.Width = 138;
            // 
            // chdStatus
            // 
            this.chdStatus.Text = "状态";
            this.chdStatus.Width = 278;
            // 
            // cmdConnect
            // 
            this.cmdConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdConnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdConnect.ForeColor = System.Drawing.Color.White;
            this.cmdConnect.Location = new System.Drawing.Point(552, 344);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(96, 26);
            this.cmdConnect.TabIndex = 18;
            this.cmdConnect.Text = "采集数据";
            this.cmdConnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdDisconnect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdDisconnect.ForeColor = System.Drawing.Color.White;
            this.cmdDisconnect.Location = new System.Drawing.Point(664, 344);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(96, 26);
            this.cmdDisconnect.TabIndex = 19;
            this.cmdDisconnect.Text = "停止采集";
            this.cmdDisconnect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // m_ctmnuNotify
            // 
            this.m_ctmnuNotify.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.m_mnuControl,
            this.m_mnuRealWindow,
            this.m_mnuExit});
            // 
            // m_mnuControl
            // 
            this.m_mnuControl.Index = 0;
            this.m_mnuControl.Text = "数据采集控制台(&C)";
            this.m_mnuControl.Click += new System.EventHandler(this.m_mnuControl_Click);
            // 
            // m_mnuRealWindow
            // 
            this.m_mnuRealWindow.Index = 1;
            this.m_mnuRealWindow.Text = "数据采集实时监控(&R)";
            this.m_mnuRealWindow.Click += new System.EventHandler(this.m_mnuRealWindow_Click);
            // 
            // m_mnuExit
            // 
            this.m_mnuExit.Index = 2;
            this.m_mnuExit.Text = "退出(&X)";
            this.m_mnuExit.Click += new System.EventHandler(this.m_mnuExit_Click);
            // 
            // dataStore1
            // 
            this.dataStore1.DataWindowObject = null;
            this.dataStore1.LibraryList = null;
            // 
            // frmLIS_Data_Acquisition_Controller
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(102)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(776, 381);
            this.Controls.Add(this.cmdDisconnect);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.lsvInstrument_Status);
            this.Controls.Add(this.grpSerialParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLIS_Data_Acquisition_Controller";
            this.Text = "检验数据采集控制台";
            this.Load += new System.EventHandler(this.frmLIS_Data_Acquisition_Controller_Load);
            this.Closed += new System.EventHandler(this.frmLIS_Data_Acquisition_Controller_Closed);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLIS_Data_Acquisition_Controller_Closing);
            this.grpSerialParameters.ResumeLayout(false);
            this.grpSerialParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataStore1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region COM+远程调用配置与内存回收配置
            try
            {
                // 内存回收间隔
                int intReleaseMemoryInternal = 60000;
                CreateDynamicMiddleTierServersList(ref intReleaseMemoryInternal);
                if (intReleaseMemoryInternal > 0)
                {
                    m_tmrReleaseMemory = new System.Windows.Forms.Timer();
                    m_tmrReleaseMemory.Interval = intReleaseMemoryInternal;
                    m_tmrReleaseMemory.Enabled = true;
                    m_tmrReleaseMemory.Tick += new EventHandler(m_tmrReleaseMemory_Tick);
                }
            }
            catch (Exception err)
            {
                if (!System.Diagnostics.EventLog.SourceExists("iCare_LIS_Data_Acquisition"))
                {
                    System.Diagnostics.EventLog.CreateEventSource("iCare_LIS_Data_Acquisition", "iCareLog");
                }

                System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
                objLog.Source = "iCare_LIS_Data_Acquisition";
                objLog.WriteEntry(err.Message);
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogDetailError(err, false);
                MessageBox.Show("程序启动出错。请稍后再试或与管理员联系。", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            #region COM+远程调用配置
            //            try
            //            {
            ////				System.Runtime.Remoting.RemotingConfiguration.Configure("iCare.client.config");
            //            }
            //            catch(Exception err)
            //            {
            //                if(!System.Diagnostics.EventLog.SourceExists("iCare_LIS_Data_Acquisition"))
            //                {
            //                    System.Diagnostics.EventLog.CreateEventSource("iCare_LIS_Data_Acquisition", "iCareLog");				
            //                }

            //                System.Diagnostics.EventLog objLog = new System.Diagnostics.EventLog();
            //                objLog.Source = "iCare_LIS_Data_Acquisition";
            //                objLog.WriteEntry(err.Message);
            //                MessageBox.Show("程序启动出错。请稍后再试或与管理员联系。","iCare",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //                return;
            //            }
            #endregion

            Application.Run(new frmLIS_Data_Acquisition_Controller());
        }

        static void m_tmrReleaseMemory_Tick(object sender, EventArgs e)
        {
            com.digitalwave.Utility.clsFixMemory.FlushMemory(true);
        }

        /// <summary>
        /// 初始中间件列表
        /// </summary>
        /// <param name="p_intReleaseMemoryInternal"></param>
        private static void CreateDynamicMiddleTierServersList(ref int p_intReleaseMemoryInternal)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("LoginFile.xml");
            //设置回收内存的时间间隔,如果login file里面没有这个参数，默认就是60，000毫秒，如果这个参数设为0，就停止内存回收机制。
            System.Xml.XmlElement xml_elemRelease_Memory = xml["Main"]["Release_Memory"];
            if (xml_elemRelease_Memory != null)
            {
                string strReleaseMemoryTimeInternal = xml_elemRelease_Memory.Attributes["Time_Internal"].Value.Trim();
                p_intReleaseMemoryInternal = int.Parse(strReleaseMemoryTimeInternal);
            }
            else
            {
                p_intReleaseMemoryInternal = 60000;
            }
            xml_elemRelease_Memory = null;

            if (com.digitalwave.iCare.common.clsObjectGenerator.ltServers == null || com.digitalwave.iCare.common.clsObjectGenerator.ltServers.Count <= 0)
            {
                //中间件服务器
                XmlNodeList XmlNodes = xml.GetElementsByTagName("MiddleServers");
                System.Collections.Generic.List<string> lt = new System.Collections.Generic.List<string>();
                for (int i = 0; i < XmlNodes.Count; i++)
                {
                    for (int I = 0; I < XmlNodes[i].ChildNodes.Count; I++)
                    {
                        lt.Add(XmlNodes[i].ChildNodes[I].InnerText);
                    }
                }
                //当检测到有中间件服务器时，以三层方式运行
                if (lt.Count > 0)
                {
                    //注册通道
                    // Set up a client channel.
                    /*这是旧三层使用的代码，需要注册通道，新三层不使用，所以注释掉这段代码。
                    TcpClientChannel clientChannel = new TcpClientChannel();
                    ChannelServices.RegisterChannel(clientChannel, false);
                    */

                    //随机排列 实现一定的负载均衡
                    int[] a = RandomSort(lt.Count);
                    //更新objectgenerator lsServer列表
                    for (int i = 0; i < lt.Count; i++)
                    {
                        com.digitalwave.iCare.common.clsObjectGenerator.ltServers.Add(lt[a[i]]);
                    }
                }
            }
        }
        /// <summary>
        /// 随机排序
        /// 将一个递增队列打乱重新排序，基本上可以是平均分布
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int[] RandomSort(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }
            if (n == 1)
                return arr;
            int k = arr.Length;   //   要保存的位置  

            //生成种子
            byte[] rndBytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(rndBytes);
            Int32 intSeed = BitConverter.ToInt32(rndBytes, 0);

            Random rad = new Random(intSeed);
            for (int i = 0; i < k - 1; i++)   //   执行N-1次循环，随机产生要被打乱的数据所在的位置   
            {
                int idx = rad.Next(0, k - i);
                //   交换数据   
                int intswap = arr[idx];
                arr[idx] = arr[k - i - 1];
                arr[k - i - 1] = intswap;
            }
            return arr;
        }

        private void frmLIS_Data_Acquisition_Controller_Load(object sender, System.EventArgs e)
        {

            #region  2012-01-18 yongchao.li 修改 用于串口模式
            com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO[] objConfig_List1 = null;
            objLIS_Controller = new clsController_LIS_Data_Acquisition();
            m_frmRealWindow.m_objController = this.objLIS_Controller;
            objLIS_Controller.m_objViewer = this;
            //  objLIS_Controller.GetInstrumentSerialSetting(this, ref objConfig_List);
            objLIS_Controller.GetInstrumentSerialSetting(this, ref objConfig_List1);
            colInstrumentList1 = new List<clsInstrument_Connection_Info>();
            if (objConfig_List1 != null)
            {
                colInstrumentList = new clsInstrument_Connection_Info[objConfig_List1.Length];

                for (int i = 0; i < objConfig_List1.Length; i++)
                {
                    colInstrumentList[i] = new clsInstrument_Connection_Info();
                    com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO objConfig_VO = (clsLIS_Equip_ConfigVO)objConfig_List1[i];

                    colInstrumentList[i].objInstrument_Config_VO = objConfig_VO;
                    if (objConfig_VO.strSend_Command_Internal != null && objConfig_VO.strSend_Command != null)
                    {

                        colInstrumentList[i].objTimer = new System.Windows.Forms.Timer();
                        if (Microsoft.VisualBasic.Information.IsNumeric(objConfig_VO.strSend_Command_Internal))
                        {
                            colInstrumentList[i].objTimer.Interval = int.Parse(objConfig_VO.strSend_Command_Internal);
                        }
                        colInstrumentList[i].objTimer.Tick += new System.EventHandler(this.Timer_Tick);
                        //					this.hstConnected_Instrument.Add(objConfig_VO, objTimer);
                    }
                    //				else
                    //				{
                    //					this.hstConnected_Instrument.Add(objConfig_VO, null);
                    //				}

                }
            }
            int iCount = m_cboInstrument.GetItemsCount();
            for (int i = 0; i < iCount; i++)
            {
                m_cboInstrument.SelectedIndex = i;
                cmdConnect_Click(null, null);
            }

            #endregion

            #region 2012-01-19 yongchao.li 新增用于新接口模式
            com.digitalwave.iCare.ValueObject.clsLIS_Equip_Base[] objConfig_List = null;
            objLIS_Controller.GetInstrumentSerialSetting2(this, ref objConfig_List);
            objLIS_Controller = new clsController_LIS_Data_Acquisition();
            m_frmRealWindow.m_objController = this.objLIS_Controller;
            objLIS_Controller.m_objViewer = this;
            if (objConfig_List != null)
            {
                colInstrumentList = new clsInstrument_Connection_Info[objConfig_List.Length];

                for (int i = 0; i < objConfig_List.Length; i++)
                {
                    colInstrumentList[i] = new clsInstrument_Connection_Info();

                    com.digitalwave.iCare.ValueObject.clsLIS_Equip_DB_ConfigVO objConfig_VO = objConfig_List[i] as clsLIS_Equip_DB_ConfigVO;
                    colInstrumentList[i].objInstrument_Config_VO2 = objConfig_List[i];
                    if (colInstrumentList[i].objInstrument_Config_VO == null)
                    {
                        colInstrumentList[i].objInstrument_Config_DB = new clsLIS_Equip_DB_ConfigVO();
                        //colInstrumentList[i].objInstrument_Config_VO.strBaud_Rate = ((clsLIS_Equip_ConfigVO2)objConfig_List[i]).strBaud_Rate;
                        //colInstrumentList[i].objInstrument_Config_VO.strCOM_No = ((clsLIS_Equip_ConfigVO2)objConfig_List[i]).strCOM_No;
                        //colInstrumentList[i].objInstrument_Config_VO.strData_Acquisition_Computer_IP = ((clsLIS_Equip_ConfigVO2)objConfig_List[i]).strData_Acquisition_Computer_IP;
                        colInstrumentList[i].objInstrument_Config_DB.strData_Analysis_DLL = objConfig_List[i].strData_Analysis_DLL;
                        colInstrumentList[i].objInstrument_Config_DB.strData_Analysis_Namespace = objConfig_List[i].strData_Analysis_Namespace;
                        //colInstrumentList[i].objInstrument_Config_VO.strData_Bit = objConfig_List[i].strData_Bit;
                        //colInstrumentList[i].objInstrument_Config_VO.strFlow_Control = objConfig_List[i].strFlow_Control;
                        colInstrumentList[i].objInstrument_Config_DB.strLIS_Instrument_ID = objConfig_List[i].strLIS_Instrument_ID;
                        colInstrumentList[i].objInstrument_Config_DB.strLIS_Instrument_Model = objConfig_List[i].strLIS_Instrument_Model;
                        colInstrumentList[i].objInstrument_Config_DB.strLIS_Instrument_Name = objConfig_List[i].strLIS_Instrument_Name;
                        colInstrumentList[i].objInstrument_Config_DB.strLIS_Instrument_NO = objConfig_List[i].strLIS_Instrument_NO;
                        //colInstrumentList[i].objInstrument_Config_DB.strWORK_AUTO_INTERNAL_VCHR = objConfig_List[i].
                        //colInstrumentList[i].objInstrument_Config_VO.strParity = objConfig_List[i]).strParity;
                        //colInstrumentList[i].objInstrument_Config_VO.strReceive_Buffer = objConfig_List[i].strReceive_Buffer;
                        //colInstrumentList[i].objInstrument_Config_VO.strSend_Buffer = objConfig_List[i].strSend_Buffer;
                        //colInstrumentList[i].objInstrument_Config_VO.strSend_Command = ((clsLIS_Equip_ConfigVO2)objConfig_List[i]).strSend_Command;
                        //colInstrumentList[i].objInstrument_Config_VO.strSend_Command_Internal =objConfig_List[i].strSend_Command_Internal;
                        //colInstrumentList[i].objInstrument_Config_VO.strStop_Bit = ((clsLIS_Equip_ConfigVO2)objConfig_List[i]).strStop_Bit;
                    }
                    if (objConfig_VO != null)
                    {
                        if (objConfig_VO.strWORK_AUTO_INTERNAL_VCHR != null)
                        {

                            colInstrumentList[i].objTimer = new System.Windows.Forms.Timer();
                            if (Microsoft.VisualBasic.Information.IsNumeric(objConfig_VO.strWORK_AUTO_INTERNAL_VCHR))
                            {
                                colInstrumentList[i].objTimer.Interval = int.Parse(objConfig_VO.strWORK_AUTO_INTERNAL_VCHR);
                            }
                            colInstrumentList[i].objTimer.Tick += new System.EventHandler(this.Timer_Tick);
                            //					this.hstConnected_Instrument.Add(objConfig_VO, objTimer);
                        }
                    }

                    //				else
                    //				{
                    //					this.hstConnected_Instrument.Add(objConfig_VO, null);
                    //				}

                }
            }

            #endregion


        }

        private void m_cboInstrument_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //2012-01-19 yongchao.li修改 用于支持新接口模式
            if (this.m_cboInstrument.SelectedItem as clsLIS_Equip_ConfigVO != null)
            {
                objLIS_Controller.SelectInstrument2(this);
            }
            else
            {
                objLIS_Controller.SelectInstrument(this);
            }

        }

        private void cmdConnect_Click(object sender, System.EventArgs e)
        {
            //			long l = this.axDigitalSerial1.CheckCom(1);
            if (this.m_cboInstrument.SelectedItem != null)
            {

                #region 新接口模式
                long lngRes = 0;
                //////////////////////////////////////////////////////////////////////
                //clsLIS_Equip_Base objEquipBse2 = (clsLIS_Equip_Base)this.m_cboInstrument.SelectedItem;
                //clsLIS_Equip_Base objEquipBse2 = this.m_cboInstrument.SelectedItem as clsLIS_Equip_Base;
                clsLIS_Equip_DB_ConfigVO objEquipBse2 = this.m_cboInstrument.SelectedItem as clsLIS_Equip_DB_ConfigVO;
                if (objEquipBse2 == null)
                    return;
                
                string strInstrument_ID2 = objEquipBse2.strLIS_Instrument_ID;

                foreach (ListViewItem lvi in lsvInstrument_Status.Items)
                {
                    if (lvi.Name == strInstrument_ID2)
                    {
                        MessageBox.Show("这台仪器已经连接，请查看仪器状态列表！");
                        return;
                    }
                }
                /////////////////////////////////////////////////////////////////////
                if (this.m_cboInstrument.SelectedItem as clsLIS_Equip_ConfigVO != null)
                {
                    #region 串口形式读取数据
                    com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO objConfig_VO = (clsLIS_Equip_ConfigVO)this.m_cboInstrument.SelectedItem;
                    string strInstrument_ID = objConfig_VO.strLIS_Instrument_ID;
                    for (int i = 0; i < this.Controls.Count; i++)
                    {
                        if (this.Controls[i].Name == strInstrument_ID && this.Controls[i].GetType().Name == typeof(AxDIGITALSERIALLib.AxDigitalSerial).Name)
                        {
                            MessageBox.Show("这台仪器已经连接，请查看仪器状态列表！");
                            return;
                        }
                    }

                    if (objConfig_VO.strData_Analysis_Namespace.Contains("clsAU640_Duplex"))
                    {
                        clsAU640_Duplex objAU640_Duplex = new clsAU640_Duplex(objConfig_VO);
                        this.Controls.Add(objAU640_Duplex.m_objSerialPort);
                        lngRes = objAU640_Duplex.Start();
                        objAU640_Duplex.ShowResult += new LISResultSavedEvent(objAU640_Duplex_ShowResult);

                        if (lngRes > 0)
                        {
                            System.Windows.Forms.ListViewItem objItem = new ListViewItem();
                            objItem.Text = objConfig_VO.strLIS_Instrument_Name;
                            objItem.Tag = objConfig_VO.strLIS_Instrument_ID;
                            objItem.SubItems.Add("等待数据...");
                            this.lsvInstrument_Status.Items.Add(objItem);
                        }
                        return;
                    }
                    else if (objConfig_VO.strData_Analysis_Namespace.Contains("AU680_Duplex"))
                    {
                        AU680.AU680_Duplex au680 = new AU680.AU680_Duplex(objConfig_VO);
                        this.Controls.Add(au680.SerialPort);
                        lngRes = au680.Start();
                        au680.ShowResult += new AU680.LISResultSavedEvent(AU680_ShowResult);

                        if (lngRes > 0)
                        {
                            System.Windows.Forms.ListViewItem objItem = new ListViewItem();
                            objItem.Text = objConfig_VO.strLIS_Instrument_Name;
                            objItem.Tag = objConfig_VO.strLIS_Instrument_ID;
                            objItem.SubItems.Add("等待数据...");
                            this.lsvInstrument_Status.Items.Add(objItem);
                        }
                        return;
                    }
                    else if (objConfig_VO.strData_Analysis_Namespace.Contains("HLC723GX_Duplex"))
                    {
                        HLC723GX.HLC723GX_Duplex hlc723 = new HLC723GX.HLC723GX_Duplex(objConfig_VO);
                        this.Controls.Add(hlc723.SerialPort);
                        lngRes = hlc723.Start();
                        hlc723.ShowResult += new HLC723GX.LISResultSavedEvent(HLC723GX_ShowResult);

                        if (lngRes > 0)
                        {
                            System.Windows.Forms.ListViewItem objItem = new ListViewItem();
                            objItem.Text = objConfig_VO.strLIS_Instrument_Name;
                            objItem.Tag = objConfig_VO.strLIS_Instrument_ID;
                            objItem.SubItems.Add("等待数据...");
                            this.lsvInstrument_Status.Items.Add(objItem);
                        }
                        return;
                    }

                    AxDIGITALSERIALLib.AxDigitalSerial objDigitalSerial;

                    System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLIS_Data_Acquisition_Controller));

                    objDigitalSerial = new AxDIGITALSERIALLib.AxDigitalSerial();
                    ((System.ComponentModel.ISupportInitialize)(objDigitalSerial)).BeginInit();
                    objDigitalSerial.Enabled = true;
                    objDigitalSerial.Location = new System.Drawing.Point(296, 344);
                    objDigitalSerial.Name = strInstrument_ID;
                    objDigitalSerial.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("objDigitalSerial.OcxState")));
                    objDigitalSerial.Size = new System.Drawing.Size(100, 50);
                    objDigitalSerial.TabIndex = 100;
                    objDigitalSerial.Visible = false;
                    this.Controls.Add(objDigitalSerial);
                    ((System.ComponentModel.ISupportInitialize)(objDigitalSerial)).EndInit();

                    int intComNum = int.Parse(objConfig_VO.strCOM_No);
                    int intRes = 0;
                    if (intComNum == 0)
                    {
                        intRes = 0;
                    }
                    else
                    {
                        intRes = objDigitalSerial.CheckCom(intComNum);
                    }
                    bool blnOpenSuccess = false;
                    switch (intRes)
                    {
                        case 0:
                            #region 串口可打开
                            if (intComNum != 0)
                            {
                                if (objDigitalSerial.OpenCom(int.Parse(objConfig_VO.strCOM_No)) == 1)
                                {
                                    int intComSetup = 0;
                                    try
                                    {
                                        intComSetup = objDigitalSerial.ComSetup(int.Parse(objConfig_VO.strBaud_Rate),
                                        int.Parse(objConfig_VO.strData_Bit),
                                        double.Parse(objConfig_VO.strStop_Bit),
                                        int.Parse(objConfig_VO.strParity));
                                    }
                                    catch { }
                                    if (intComSetup == 0)
                                    {
                                        MessageBox.Show(this, "串口参数错误!", "数据采集");
                                        objDigitalSerial.CloseCom();
                                        break;
                                    }
                                    int intHandShakeSetup = 0;
                                    try
                                    {
                                        intHandShakeSetup = objDigitalSerial.HandShakeSetup(int.Parse(objConfig_VO.strFlow_Control));
                                    }
                                    catch { }
                                    if (intHandShakeSetup == 0)
                                    {
                                        MessageBox.Show(this, "串口流控制参数错误!", "数据采集");
                                        objDigitalSerial.CloseCom();
                                        break;
                                    }
                                    objDigitalSerial.SetRecvBuff(int.Parse(objConfig_VO.strReceive_Buffer));
                                    objDigitalSerial.SetSendBuff(int.Parse(objConfig_VO.strSend_Buffer));
                                    objDigitalSerial.DataComing += new System.EventHandler(this.axDigitalSerial_DataComing);

                                    //xing.chen add test code
                                    testLog.Log2File(@"D:\logInfo.txt", "DigitalSerial Open", DateTime.Now.ToLongTimeString());
                                    int iCount = this.Controls.Count;
                                    clsLIS_Data_Acquisition_SendCommend objSvc = clsLIS_Data_Acquisition_SendCommend.GetInstance(objDigitalSerial);
                                    if (iCount > this.Controls.Count)
                                    {
                                        this.Controls.Add(objDigitalSerial);
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            System.Windows.Forms.ListViewItem objItem = new ListViewItem();
                            objItem.Text = objConfig_VO.strLIS_Instrument_Name;
                            objItem.Tag = objConfig_VO.strLIS_Instrument_ID;
                            objItem.SubItems.Add("等待数据...");
                            this.lsvInstrument_Status.Items.Add(objItem);

                            for (int j = 0; j < this.colInstrumentList.Length; j++)
                            {
                                if (this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_ID == objConfig_VO.strLIS_Instrument_ID)
                                {
                                    if (objConfig_VO.strSend_Command_Internal != null && objConfig_VO.strSend_Command != null)
                                    {
                                        this.colInstrumentList[j].objTimer.Start();
                                    }
                                    object objAnalysis = this.objLIS_Controller.objGetDataAnalyzer(objConfig_VO.strData_Analysis_DLL, objConfig_VO.strData_Analysis_Namespace);
                                    if (objAnalysis == null)
                                        break;
                                    this.colInstrumentList[j].objDataAnalyzer = (com.digitalwave.iCare.middletier.LIS.infLISDataAnalysis)objAnalysis;

                                    #region 从各仪器分析配置文件中读取分析模式配置，并根分析模式进行配置
                                    try
                                    {
                                        System.Configuration.ConfigXmlDocument xmlConfig = new System.Configuration.ConfigXmlDocument();
                                        string strFilePath = System.AppDomain.CurrentDomain.BaseDirectory;
                                        strFilePath += "LIS_DataAnalyse\\";
                                        strFilePath += objConfig_VO.strData_Analysis_DLL;
                                        strFilePath = strFilePath.ToLower();
                                        strFilePath = strFilePath.Replace("dll", "config");

                                        xmlConfig.Load(strFilePath);
                                        string strAnalysisMode = xmlConfig["configuration"]["settings"]["analysisSettings"].SelectSingleNode("add[@key=\"mode\"]").Attributes["value"].Value;
                                        switch (strAnalysisMode)
                                        {
                                            case "manual":
                                                Button btnSwitch = new Button();
                                                btnSwitch.Text = "wait";
                                                btnSwitch.Location = new Point(this.m_pitSwitchButtonBeginLocation.X, this.m_pitSwitchButtonBeginLocation.Y + (objItem.Bounds.Height * objItem.Index));
                                                btnSwitch.Height = this.m_intSwitchButtonHeight;
                                                btnSwitch.Width = this.m_intSwitchButtonWidth;
                                                btnSwitch.Visible = true;
                                                btnSwitch.Enabled = true;
                                                btnSwitch.BackColor = Color.FromArgb(51, 102, 153);

                                                //											btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                                                btnSwitch.Font = new System.Drawing.Font("宋体", 8F);
                                                btnSwitch.ForeColor = System.Drawing.Color.White;
                                                btnSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                                                btnSwitch.Tag = colInstrumentList[j];
                                                btnSwitch.Click += new EventHandler(btnSwitch_Click);
                                                btnSwitch.Name = objConfig_VO.strLIS_Instrument_ID;
                                                this.Controls.Add(btnSwitch);
                                                btnSwitch.BringToFront();
                                                btnSwitch.Refresh();
                                                btnSwitch.Parent = this;
                                                btnSwitch.Show();
                                                break;
                                            case "auto.time":
                                                ((com.digitalwave.iCare.middletier.LIS.infLISDataAnalysisOver)this.colInstrumentList[j].objDataAnalyzer).evtAnalysisDataEnd += new EventHandler(DataAnalyzer_evtAnalysisDataEnd);
                                                break;
                                            case "manual.file":
                                                Button btnFile = new Button();
                                                btnFile.Text = "Change";
                                                btnFile.Location = new Point(this.m_pitSwitchButtonBeginLocation.X, this.m_pitSwitchButtonBeginLocation.Y + (objItem.Bounds.Height * objItem.Index));
                                                btnFile.Height = this.m_intSwitchButtonHeight;
                                                btnFile.Width = this.m_intSwitchButtonWidth;
                                                btnFile.BackColor = Color.FromArgb(51, 102, 153);
                                                btnFile.Font = new System.Drawing.Font("宋体", 8F);
                                                btnFile.ForeColor = System.Drawing.Color.White;
                                                btnFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                                                btnFile.Name = objConfig_VO.strLIS_Instrument_ID;
                                                btnFile.Tag = colInstrumentList[j];
                                                btnFile.Click += new EventHandler(btnFile_Click);
                                                this.Controls.Add(btnFile);
                                                break;
                                            //新增的监听网络模式 xing.chen 4/8/2005
                                            case "auto.network":
                                                string strIpAddress = ((com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase)objAnalysis).m_strGetConfig("/configuration/settings/analysisSettings/add[@key='IpAddress']");
                                                string strPort = ((com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase)objAnalysis).m_strGetConfig("/configuration/settings/analysisSettings/add[@key=\"Port\"]");
                                                clsController_NetWorkListener objListener = new clsController_NetWorkListener(strIpAddress, strPort);
                                                objListener.DataReceived += new DataReceivedEventHandler(objListener_DataReceived);
                                                objListener.Info += new DataReceivedEventHandler(objListener_Info);
                                                System.Threading.Thread objThread = new System.Threading.Thread(new System.Threading.ThreadStart(objListener.Start));
                                                objThread.Start();
                                                objThread.IsBackground = true;	//将此线程设置为后台线程，则主线程退出时此线程自动退出
                                                clsThreadInfo objThreadInfo = new clsThreadInfo();
                                                objThreadInfo.m_objConnectInfo = this.colInstrumentList[j];
                                                objThreadInfo.m_objThread = objThread;
                                                objThreadInfo.m_objListener = objListener;
                                                objThreadInfo.m_Item = objItem;
                                                this.m_arlNetThread.Add(objThreadInfo);
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.ToString());
                                    }
                                    #endregion

                                    blnOpenSuccess = true;
                                    break;
                                }
                            }
                            if (!blnOpenSuccess)
                            {
                                objDigitalSerial.CloseCom();
                            }
                            break;
                            #endregion
                        case -1:
                            MessageBox.Show(this, "指定的串口发生未知错误!", "数据采集");
                            break;
                        case 1:
                            MessageBox.Show(this, "串口没找到!", "数据采集");
                            break;
                        case 2:
                            MessageBox.Show(this, "指定的串口已被占用!", "数据采集");
                            break;
                        default:
                            break;
                    }
                    if (!blnOpenSuccess)
                    {
                        for (int i = 0; i < this.lsvInstrument_Status.Items.Count; i++)
                        {
                            if (lsvInstrument_Status.Items[i].Tag.ToString() == objConfig_VO.strLIS_Instrument_ID)
                            {
                                lsvInstrument_Status.Items.RemoveAt(i);
                            }
                        }
                        this.Controls.Remove(objDigitalSerial);
                        objDigitalSerial.Dispose();
                    }
                    #endregion
                }
                #endregion

                //clsLIS_Equip_Base objEquipBse2 = (clsLIS_Equip_Base)this.m_cboInstrument.SelectedItem;
                //if (objEquipBse2 == null)
                //    return;
                //string strInstrument_ID2 = objEquipBse2.strLIS_Instrument_ID;
                //foreach (ListViewItem lvi in lsvInstrument_Status.Items)
                //{
                //    if (lvi.Name == strInstrument_ID2)
                //    {
                //        MessageBox.Show("这台仪器已经连接，请查看仪器状态列表！");
                //        return;
                //    }
                //}

              

                object objDataAcquisition2 = objLIS_Controller.objGetDataAnalyzer(objEquipBse2.strData_Analysis_DLL, objEquipBse2.strData_Analysis_Namespace);
                
                if (objDataAcquisition2 is infLISDataAcquisition_TXT)
                {
                    #region 新接口模式 -- 读文本
                    infLISDataAcquisition_TXT objLISDataAcqu_DB = objDataAcquisition2 as infLISDataAcquisition_TXT;
                    objLISDataAcqu_DB.m_frmParent = this;
                    objLISDataAcqu_DB.m_objDeviceConfigVO = this.m_cboInstrument.SelectedItem as clsLIS_Equip_DB_ConfigVO;//objEquipBse2 as clsLIS_Equip_DB_ConfigVO;
                    objLISDataAcqu_DB.m_blnLogger = true;
                    lngRes = objLISDataAcqu_DB.m_lngInitDataAcquisition();
                    lngRes = objLISDataAcqu_DB.m_lngStartWork();
                    if (lngRes > 0)
                    {
                        objLISDataAcqu_DB.evnDataShow += new DataShowEventHandler(LISDataAcquisition_evnDataShow);
                        ListViewItem objItem = new ListViewItem();
                        objItem.Text = objEquipBse2.strLIS_Instrument_Name;
                        objItem.Name = objEquipBse2.strLIS_Instrument_ID;
                        objItem.Tag = objLISDataAcqu_DB;
                        objItem.SubItems.Add("等待数据...");
                        this.lsvInstrument_Status.Items.Add(objItem);

                        if (objLISDataAcqu_DB.m_objDeviceConfigVO.strWORK_MODULE_CHR.Substring(2, 1) == "1")
                        {
                            //手工操作
                            //Button btnWorkByHandle = new Button();
                            //btnWorkByHandle.Text = "...";
                            //btnWorkByHandle.Location = new Point(this.m_pitSwitchButtonBeginLocation.X, this.m_pitSwitchButtonBeginLocation.Y + (objItem.Bounds.Height * objItem.Index));
                            //btnWorkByHandle.Height = this.m_intSwitchButtonHeight;
                            //btnWorkByHandle.Width = this.m_intSwitchButtonWidth;
                            //btnWorkByHandle.Visible = true;
                            //btnWorkByHandle.Enabled = true;
                            //btnWorkByHandle.BackColor = Color.FromArgb(51, 102, 153);
                            //btnWorkByHandle.Font = new System.Drawing.Font("宋体", 8F);
                            //btnWorkByHandle.ForeColor = System.Drawing.Color.White;
                            //btnWorkByHandle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                            //btnWorkByHandle.Tag = objLISDataAcqu_DB;
                            //btnWorkByHandle.Click += new EventHandler(DataAcquisition_DB_WorkByHandle);
                            //btnWorkByHandle.Name = objEquipBse.strLIS_Instrument_ID;
                            //this.Controls.Add(btnWorkByHandle);
                            //btnWorkByHandle.BringToFront();
                            //btnWorkByHandle.Refresh();
                            //btnWorkByHandle.Parent = this;
                            //btnWorkByHandle.Show();
                        }
                    }
                    return;
                    #endregion
                }
                

                if (objDataAcquisition2 is infLISDataAcquisition_DB)
                {
                    #region 新接口模式 -- 读数据

                    infLISDataAcquisition_DB objLISDataAcqu_DB = objDataAcquisition2 as infLISDataAcquisition_DB;
                    objLISDataAcqu_DB.m_frmParent = this;
                    objLISDataAcqu_DB.m_objDeviceConfigVO = this.m_cboInstrument.SelectedItem as clsLIS_Equip_DB_ConfigVO; //objEquipBse2 as clsLIS_Equip_DB_ConfigVO;
                    objLISDataAcqu_DB.m_blnLogger = true;
                    lngRes = objLISDataAcqu_DB.m_lngInitDataAcquisition();
                    lngRes = objLISDataAcqu_DB.m_lngStartWork();
                    if (lngRes > 0)
                    {
                        objLISDataAcqu_DB.evnDataShow += new DataShowEventHandler(LISDataAcquisition_evnDataShow);
                        ListViewItem objItem = new ListViewItem();
                        objItem.Text = objEquipBse2.strLIS_Instrument_Name;
                        objItem.Name = objEquipBse2.strLIS_Instrument_ID;
                        objItem.Tag = objLISDataAcqu_DB;
                        objItem.SubItems.Add("等待数据...");
                        this.lsvInstrument_Status.Items.Add(objItem);

                        if (objLISDataAcqu_DB.m_objDeviceConfigVO.strWORK_MODULE_CHR.Substring(2, 1) == "1")
                        {
                            Button btnWorkByHandle = new Button();
                            btnWorkByHandle.Text = "...";
                            btnWorkByHandle.Location = new Point(this.m_pitSwitchButtonBeginLocation.X, this.m_pitSwitchButtonBeginLocation.Y + (objItem.Bounds.Height * objItem.Index));
                            btnWorkByHandle.Height = this.m_intSwitchButtonHeight;
                            btnWorkByHandle.Width = this.m_intSwitchButtonWidth;
                            btnWorkByHandle.Visible = true;
                            btnWorkByHandle.Enabled = true;
                            btnWorkByHandle.BackColor = Color.FromArgb(51, 102, 153);
                            btnWorkByHandle.Font = new System.Drawing.Font("宋体", 8F);
                            btnWorkByHandle.ForeColor = System.Drawing.Color.White;
                            btnWorkByHandle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                            btnWorkByHandle.Tag = objLISDataAcqu_DB;
                            //btnWorkByHandle.Click += new EventHandler(DataAcquisition_DB_WorkByHandle);
                            btnWorkByHandle.Name = objEquipBse2.strLIS_Instrument_ID;
                            this.Controls.Add(btnWorkByHandle);
                            btnWorkByHandle.BringToFront();
                            btnWorkByHandle.Refresh();
                            btnWorkByHandle.Parent = this;
                            btnWorkByHandle.Show();
                        }
                    }
                    return;
                    #endregion
                }

                #region 旧版本模式

                //com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO objConfig_VO = (clsLIS_Equip_ConfigVO)this.m_cboInstrument.SelectedItem;
                //string strInstrument_ID = objConfig_VO.strLIS_Instrument_ID;

                //for (int i = 0; i < this.Controls.Count; i++)
                //{
                //    if (this.Controls[i].Name == strInstrument_ID && this.Controls[i].GetType().Name == typeof(AxDIGITALSERIALLib.AxDigitalSerial).Name)
                //    {
                //        MessageBox.Show("这台仪器已经连接，请查看仪器状态列表！");
                //        return;
                //    }
                //}

                //if (objConfig_VO.strData_Analysis_Namespace.Contains("clsAU640_Duplex"))
                //{
                //    clsAU640_Duplex objAU640_Duplex = new clsAU640_Duplex(objConfig_VO);
                //    this.Controls.Add(objAU640_Duplex.m_objSerialPort);
                //    long lngRes = objAU640_Duplex.Start();
                //    objAU640_Duplex.ShowResult += new LISResultSavedEvent(objAU640_Duplex_ShowResult);

                //    if (lngRes > 0)
                //    {
                //        System.Windows.Forms.ListViewItem objItem = new ListViewItem();
                //        objItem.Text = objConfig_VO.strLIS_Instrument_Name;
                //        objItem.Tag = objConfig_VO.strLIS_Instrument_ID;
                //        objItem.SubItems.Add("等待数据...");
                //        this.lsvInstrument_Status.Items.Add(objItem);
                //    }
                //    return;
                //}

                //AxDIGITALSERIALLib.AxDigitalSerial objDigitalSerial;

                //System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLIS_Data_Acquisition_Controller));

                //objDigitalSerial = new AxDIGITALSERIALLib.AxDigitalSerial();
                //((System.ComponentModel.ISupportInitialize)(objDigitalSerial)).BeginInit();
                //objDigitalSerial.Enabled = true;
                //objDigitalSerial.Location = new System.Drawing.Point(296, 344);
                //objDigitalSerial.Name = strInstrument_ID;
                //objDigitalSerial.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("objDigitalSerial.OcxState")));
                //objDigitalSerial.Size = new System.Drawing.Size(100, 50);
                //objDigitalSerial.TabIndex = 100;
                //objDigitalSerial.Visible = false;
                //this.Controls.Add(objDigitalSerial);
                //((System.ComponentModel.ISupportInitialize)(objDigitalSerial)).EndInit();

                //int intComNum = int.Parse(objConfig_VO.strCOM_No);
                //int intRes = 0;
                //if(intComNum == 0)
                //{
                //    intRes = 0;
                //}
                //else
                //{
                //    intRes = objDigitalSerial.CheckCom(intComNum);
                //}
                //bool blnOpenSuccess = false;
                //switch(intRes)
                //{
                //    case 0:
                //        #region 串口可打开
                //        if(intComNum != 0)
                //        {
                //            if(objDigitalSerial.OpenCom(int.Parse(objConfig_VO.strCOM_No))==1)
                //            {
                //                int intComSetup = 0;
                //                try
                //                {
                //                    intComSetup = objDigitalSerial.ComSetup(int.Parse(objConfig_VO.strBaud_Rate),
                //                    int.Parse(objConfig_VO.strData_Bit),
                //                    double.Parse(objConfig_VO.strStop_Bit),
                //                    int.Parse(objConfig_VO.strParity));
                //                }
                //                catch{}
                //                if(intComSetup == 0)
                //                {
                //                    MessageBox.Show(this,"串口参数错误!","数据采集");
                //                    objDigitalSerial.CloseCom();
                //                    break;
                //                }
                //                int intHandShakeSetup = 0;
                //                try
                //                {
                //                    intHandShakeSetup = objDigitalSerial.HandShakeSetup(int.Parse(objConfig_VO.strFlow_Control));
                //                }
                //                catch{}
                //                if(intHandShakeSetup ==0)
                //                {
                //                    MessageBox.Show(this,"串口流控制参数错误!","数据采集");
                //                    objDigitalSerial.CloseCom();
                //                    break;
                //                }
                //                objDigitalSerial.SetRecvBuff(int.Parse(objConfig_VO.strReceive_Buffer));
                //                objDigitalSerial.SetSendBuff(int.Parse(objConfig_VO.strSend_Buffer));						
                //                objDigitalSerial.DataComing += new System.EventHandler(this.axDigitalSerial_DataComing);

                //                //xing.chen add test code
                //                testLog.Log2File(@"D:\logInfo.txt","DigitalSerial Open",DateTime.Now.ToLongTimeString());
                //                int iCount = this.Controls.Count;
                //                clsLIS_Data_Acquisition_SendCommend objSvc =clsLIS_Data_Acquisition_SendCommend.GetInstance(objDigitalSerial);
                //                if (iCount >this.Controls.Count)
                //                {
                //                    this.Controls.Add(objDigitalSerial);
                //                }
                //            }
                //            else
                //            {
                //                break;
                //            }
                //        }
                //        System.Windows.Forms.ListViewItem objItem = new ListViewItem();
                //        objItem.Text = objConfig_VO.strLIS_Instrument_Name;
                //        objItem.Tag = objConfig_VO.strLIS_Instrument_ID;
                //        objItem.SubItems.Add("等待数据...");
                //        this.lsvInstrument_Status.Items.Add(objItem);


                //        for(int j=0; j<this.colInstrumentList.Length; j++)
                //        {
                //            if(this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_ID == objConfig_VO.strLIS_Instrument_ID)
                //            {
                //                if(objConfig_VO.strSend_Command_Internal != null && objConfig_VO.strSend_Command != null)
                //                {
                //                    this.colInstrumentList[j].objTimer.Start();
                //                }
                //                object objAnalysis = this.objLIS_Controller.objGetDataAnalyzer(objConfig_VO.strData_Analysis_DLL, objConfig_VO.strData_Analysis_Namespace);
                //                if(objAnalysis == null)
                //                    break;
                //                this.colInstrumentList[j].objDataAnalyzer = (com.digitalwave.iCare.middletier.LIS.infLISDataAnalysis)objAnalysis;

                //                #region 从各仪器分析配置文件中读取分析模式配置，并根分析模式进行配置
                //                try
                //                {
                //                    System.Configuration.ConfigXmlDocument xmlConfig = new System.Configuration.ConfigXmlDocument();
                //                    string strFilePath = System.AppDomain.CurrentDomain.BaseDirectory;
                //                    strFilePath += "LIS_DataAnalyse\\";
                //                    strFilePath += objConfig_VO.strData_Analysis_DLL;
                //                    strFilePath = strFilePath.ToLower();
                //                    strFilePath = strFilePath.Replace("dll","config");

                //                    xmlConfig.Load(strFilePath);
                //                    string strAnalysisMode = xmlConfig["configuration"]["settings"]["analysisSettings"].SelectSingleNode("add[@key=\"mode\"]").Attributes["value"].Value;
                //                    switch(strAnalysisMode)
                //                    {
                //                        case "manual":
                //                            Button btnSwitch = new Button();
                //                            btnSwitch.Text = "wait";
                //                            btnSwitch.Location = new Point(this.m_pitSwitchButtonBeginLocation.X,this.m_pitSwitchButtonBeginLocation.Y + (objItem.Bounds.Height * objItem.Index));
                //                            btnSwitch.Height = this.m_intSwitchButtonHeight;
                //                            btnSwitch.Width = this.m_intSwitchButtonWidth;
                //                            btnSwitch.Visible = true;
                //                            btnSwitch.Enabled = true;
                //                            btnSwitch.BackColor = Color.FromArgb(51,102,153);

                //                            //											btnSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                //                            btnSwitch.Font = new System.Drawing.Font("宋体", 8F);
                //                            btnSwitch.ForeColor = System.Drawing.Color.White;
                //                            btnSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                //                            btnSwitch.Tag = colInstrumentList[j];
                //                            btnSwitch.Click += new EventHandler(btnSwitch_Click);
                //                            btnSwitch.Name = objConfig_VO.strLIS_Instrument_ID;
                //                            this.Controls.Add(btnSwitch);
                //                            btnSwitch.BringToFront();
                //                            btnSwitch.Refresh();
                //                            btnSwitch.Parent = this;
                //                            btnSwitch.Show();
                //                            break;
                //                        case "auto.time":
                //                            ((com.digitalwave.iCare.middletier.LIS.infLISDataAnalysisOver)this.colInstrumentList[j].objDataAnalyzer).evtAnalysisDataEnd += new EventHandler(DataAnalyzer_evtAnalysisDataEnd);
                //                            break;
                //                        case "manual.file":
                //                            Button btnFile = new Button();
                //                            btnFile.Text = "Change";
                //                            btnFile.Location = new Point(this.m_pitSwitchButtonBeginLocation.X,this.m_pitSwitchButtonBeginLocation.Y + (objItem.Bounds.Height * objItem.Index));
                //                            btnFile.Height = this.m_intSwitchButtonHeight;
                //                            btnFile.Width = this.m_intSwitchButtonWidth;
                //                            btnFile.BackColor = Color.FromArgb(51,102,153);
                //                            btnFile.Font = new System.Drawing.Font("宋体", 8F);
                //                            btnFile.ForeColor = System.Drawing.Color.White;
                //                            btnFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                //                            btnFile.Name = objConfig_VO.strLIS_Instrument_ID;
                //                            btnFile.Tag = colInstrumentList[j];
                //                            btnFile.Click += new EventHandler(btnFile_Click);
                //                            this.Controls.Add(btnFile);
                //                            break;
                //                        //新增的监听网络模式 xing.chen 4/8/2005
                //                        case "auto.network":
                //                            string strIpAddress = ((com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase)objAnalysis).m_strGetConfig("/configuration/settings/analysisSettings/add[@key='IpAddress']");
                //                            string strPort = ((com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase)objAnalysis).m_strGetConfig("/configuration/settings/analysisSettings/add[@key=\"Port\"]");
                //                            clsController_NetWorkListener objListener = new clsController_NetWorkListener(strIpAddress,strPort);
                //                            objListener.DataReceived += new DataReceivedEventHandler(objListener_DataReceived);
                //                            objListener.Info += new DataReceivedEventHandler(objListener_Info);
                //                            System.Threading.Thread objThread = new System.Threading.Thread(new System.Threading.ThreadStart(objListener.Start));
                //                            objThread.Start();
                //                            objThread.IsBackground = true;	//将此线程设置为后台线程，则主线程退出时此线程自动退出
                //                            clsThreadInfo objThreadInfo = new clsThreadInfo();
                //                            objThreadInfo.m_objConnectInfo = this.colInstrumentList[j];
                //                            objThreadInfo.m_objThread = objThread;
                //                            objThreadInfo.m_objListener = objListener;
                //                            objThreadInfo.m_Item = objItem;
                //                            this.m_arlNetThread.Add(objThreadInfo);
                //                            break;
                //                        default:
                //                            break;
                //                    }
                //                }
                //                catch(Exception ex){ 
                //                MessageBox.Show(ex.ToString());}
                //                #endregion

                //                blnOpenSuccess = true;
                //                break;
                //            }
                //        }
                //        if(!blnOpenSuccess)
                //        {
                //            objDigitalSerial.CloseCom();
                //        }
                //        break;
                //        #endregion
                //    case -1:
                //        MessageBox.Show(this,"指定的串口发生未知错误!","数据采集");
                //        break;
                //    case 1:
                //        MessageBox.Show(this,"串口没找到!","数据采集");
                //        break;
                //    case 2:
                //        MessageBox.Show(this,"指定的串口已被占用!","数据采集");
                //        break;
                //    default:
                //        break;
                //}
                //if(!blnOpenSuccess)
                //{
                //    for(int i=0;i<this.lsvInstrument_Status.Items.Count;i++)
                //    {
                //        if(lsvInstrument_Status.Items[i].Tag.ToString() == objConfig_VO.strLIS_Instrument_ID)
                //        {
                //            lsvInstrument_Status.Items.RemoveAt(i);
                //        }
                //    }
                //    this.Controls.Remove(objDigitalSerial);
                //    objDigitalSerial.Dispose();
                //}
                #endregion
            }

        }
        /// <summary>
        ///2012-01-18 yongchao.li 添加提供给读文本的方法 
        /// </summary>
        /// <param name="p_SampleDateKey"></param>
        /// <param name="p_objDeviceResultArr"></param>

        void LISDataAcquisition_evnDataShow(com.digitalwave.iCare.LIS.clsDeviceSampleDataKey p_SampleDateKey, clsLIS_Device_Test_ResultVO[] p_objDeviceResultArr)
        {
            clsDeviceSampleDataKey objSampleDateKey = new clsDeviceSampleDataKey();
            objSampleDateKey.intResultBeginIndex = p_SampleDateKey.intResultBeginIndex;
            objSampleDateKey.intResultEndIndex = p_SampleDateKey.intResultEndIndex;
            objSampleDateKey.strCheckDate = p_SampleDateKey.strCheckDate;
            objSampleDateKey.strCommingDateTime = p_SampleDateKey.strCommingDateTime;
            objSampleDateKey.strDeviceID = p_SampleDateKey.strDeviceID;
            objSampleDateKey.strDeviceName = p_SampleDateKey.strDeviceName;
            objSampleDateKey.strDeviceSampleID = p_SampleDateKey.strDeviceSampleID;

            m_mthShowMessage(objSampleDateKey, p_objDeviceResultArr);
        }

        void objAU640_Duplex_ShowResult(object sender, EventArgs e)
        {
            clsLIS_Device_Test_ResultVO[] objResultArr = (clsLIS_Device_Test_ResultVO[])sender;

            clsDeviceSampleDataKey objKey = new clsDeviceSampleDataKey();
            objKey.intResultBeginIndex = objResultArr[0].intIndex;
            objKey.intResultEndIndex = objResultArr[objResultArr.Length - 1].intIndex;
            objKey.strDeviceID = objResultArr[0].strDevice_ID;

            ListViewItem lvi = null;
            string strTemp = null;
            for (int idx = 0; idx < lsvInstrument_Status.Items.Count; idx++)
            {
                lvi = lsvInstrument_Status.Items[idx];
                strTemp = lvi.Tag.ToString();
                if (strTemp == objKey.strDeviceID)
                {
                    objKey.strDeviceName = lvi.Text;
                    break;
                }
            }
            objKey.strDeviceSampleID = objResultArr[0].strDevice_Sample_ID;
            objKey.strCheckDate = objResultArr[0].strCheck_Date;
            m_mthShowMessage(objKey, objResultArr);
        }

        void AU680_ShowResult(object sender, EventArgs e)
        {
            clsLIS_Device_Test_ResultVO[] objResultArr = (clsLIS_Device_Test_ResultVO[])sender;

            clsDeviceSampleDataKey objKey = new clsDeviceSampleDataKey();
            objKey.intResultBeginIndex = objResultArr[0].intIndex;
            objKey.intResultEndIndex = objResultArr[objResultArr.Length - 1].intIndex;
            objKey.strDeviceID = objResultArr[0].strDevice_ID;

            ListViewItem lvi = null;
            string strTemp = null;
            for (int idx = 0; idx < lsvInstrument_Status.Items.Count; idx++)
            {
                lvi = lsvInstrument_Status.Items[idx];
                strTemp = lvi.Tag.ToString();
                if (strTemp == objKey.strDeviceID)
                {
                    objKey.strDeviceName = lvi.Text;
                    break;
                }
            }
            objKey.strDeviceSampleID = objResultArr[0].strDevice_Sample_ID;
            objKey.strCheckDate = objResultArr[0].strCheck_Date;
            m_mthShowMessage(objKey, objResultArr);
        }

        void HLC723GX_ShowResult(object sender, EventArgs e)
        {
            clsLIS_Device_Test_ResultVO[] objResultArr = (clsLIS_Device_Test_ResultVO[])sender;

            clsDeviceSampleDataKey objKey = new clsDeviceSampleDataKey();
            objKey.intResultBeginIndex = objResultArr[0].intIndex;
            objKey.intResultEndIndex = objResultArr[objResultArr.Length - 1].intIndex;
            objKey.strDeviceID = objResultArr[0].strDevice_ID;

            ListViewItem lvi = null;
            string strTemp = null;
            for (int idx = 0; idx < lsvInstrument_Status.Items.Count; idx++)
            {
                lvi = lsvInstrument_Status.Items[idx];
                strTemp = lvi.Tag.ToString();
                if (strTemp == objKey.strDeviceID)
                {
                    objKey.strDeviceName = lvi.Text;
                    break;
                }
            }
            objKey.strDeviceSampleID = objResultArr[0].strDevice_Sample_ID;
            objKey.strCheckDate = objResultArr[0].strCheck_Date;
            m_mthShowMessage(objKey, objResultArr);
        }

        private void axDigitalSerial_DataComing(object sender, System.EventArgs e)
        {
            AxDIGITALSERIALLib.AxDigitalSerial objDigitalSerial = (AxDIGITALSERIALLib.AxDigitalSerial)sender;
            System.Windows.Forms.ListViewItem objLSV_Item = null;
            string strInstrument_ID = objDigitalSerial.Name;
            string strData_Received = objDigitalSerial.ReadBuff();

            //xing.chen add test code
            testLog.Log2File(@"D:\logInfo.txt", "DigitalSerial Received", DateTime.Now.ToLongTimeString());
            testLog.Log2File(@"D:\logData.txt", strData_Received);

            for (int i = 0; i < this.lsvInstrument_Status.Items.Count; i++)
            {
                objLSV_Item = this.lsvInstrument_Status.Items[i];
                string strListView_Instrument_ID = objLSV_Item.Tag.ToString();
                if (strListView_Instrument_ID == strInstrument_ID)
                {
                    objLSV_Item.SubItems[1].Text = "正在接收数据";
                    break;
                }
            }
            for (int j = 0; j < this.colInstrumentList.Length; j++)
            {
                if (this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_ID == strInstrument_ID)
                {
                    this.objLIS_Controller.DigitalSerial_DataComing(this.colInstrumentList[j].objDataAnalyzer, strData_Received, strInstrument_ID, this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_Name);
                    break;
                }
            }

            if (objLSV_Item != null)
            {
                objLSV_Item.SubItems[1].Text = "等待数据...";
            }
            #region Analysis Manual Mode
            Button btn = null;
            foreach (Control ctl in this.Controls)
            {
                if (ctl.GetType().Name == typeof(Button).Name && ctl.Name == strInstrument_ID)
                {
                    btn = (Button)ctl;
                    break;
                }
            }
            if (btn != null)
            {
                btn.BackColor = Color.LightSkyBlue;
                btn.Text = "Stop";
            }
            #endregion
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Timer objTimer = (System.Windows.Forms.Timer)sender;
            for (int i = 0; i < this.colInstrumentList.Length; i++)
            {
                if (this.colInstrumentList[i].objTimer != null)
                {
                    if (objTimer.Equals(this.colInstrumentList[i].objTimer))
                    {
                        string strInstrumen_ID = this.colInstrumentList[i].objInstrument_Config_VO.strLIS_Instrument_ID;


                        for (int j = 0; j < this.Controls.Count; j++)
                        {
                            if (strInstrumen_ID == this.Controls[j].Name)
                            {
                                MessageBox.Show("strInstrumen_ID-->" + strInstrumen_ID);
                                MessageBox.Show("this.Controls[j].Name-->" + this.Controls[j].Name);
                                AxDIGITALSERIALLib.AxDigitalSerial objDigitalSerial = (AxDIGITALSERIALLib.AxDigitalSerial)this.Controls[j];
                                string strSend_Command = this.colInstrumentList[i].objInstrument_Config_VO.strSend_Command;
                                strSend_Command = com.digitalwave.Utility.clsHexConvert.m_strToTextString(strSend_Command);
                                if (strSend_Command == null)
                                    break;
                                if (objDigitalSerial.IsOpen() == 1)
                                {
                                    int intRes = objDigitalSerial.SendData(strSend_Command);
                                }
                                break;
                            }
                        }
                        break;
                    }
                }
            }
        }

        private void cmdDisconnect_Click(object sender, System.EventArgs e)
        {
            //2012-01-19 yongchao.li 新增支持新接口模式
            if (this.lsvInstrument_Status.SelectedItems.Count > 0)
            {
                System.Windows.Forms.ListViewItem objLSV_Item = this.lsvInstrument_Status.SelectedItems[0];
                long lngRes = 0;
                if (objLSV_Item.Tag is infLISDataAcquisition)
                {
                    lngRes = ((infLISDataAcquisition)objLSV_Item.Tag).m_lngFinishWork();
                    if (lngRes > 0)
                    {
                        this.lsvInstrument_Status.Items.Remove(objLSV_Item);
                    }
                    return;
                }
                //网口
                //if (objLSV_Item.Tag is infLISDataAcquisition_Socket)
                //{
                //    lngRes = ((infLISDataAcquisition_Socket)objLSV_Item.Tag).m_lngFinishWork();
                //    if (lngRes > 0)
                //    {
                //        this.lsvInstrument_Status.Items.Remove(objLSV_Item);
                //    }
                //    return;
                //}

                if (objLSV_Item.Tag is infLISDataAcquisition_DB)
                {
                    infLISDataAcquisition_DB objLIS_DB = (infLISDataAcquisition_DB)objLSV_Item.Tag;
                    lngRes = objLIS_DB.m_lngFinishWork();
                    if (lngRes > 0)
                    {
                        this.lsvInstrument_Status.Items.Remove(objLSV_Item);
                        string strEquiInstrument_ID = objLIS_DB.m_objDeviceConfigVO.strLIS_Instrument_ID;
                        Button btn = null;
                        foreach (Control ctl in this.Controls)
                        {
                            if (ctl.GetType().Name == typeof(Button).Name && ctl.Name == strEquiInstrument_ID)
                            {
                                btn = (Button)ctl;
                                break;
                            }
                        }
                        if (btn != null)
                        {
                            this.Controls.Remove(btn);
                        }
                    }
                    return;
                }

                string strInstrument_ID = objLSV_Item.Tag != null ? objLSV_Item.Tag.ToString() : string.Empty;
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].Name == strInstrument_ID && this.Controls[i].GetType().Name == typeof(clsSerialPortIO).Name)
                    {
                        clsSerialPortIO objSP = (clsSerialPortIO)this.Controls[i];
                        objSP.Close();
                        this.Controls.RemoveAt(i);
                        objSP.Dispose();//非托管资源，要使用此方法释放
                        objSP = null;
                        this.lsvInstrument_Status.Items.Remove(objLSV_Item);

                        #region Analysis Manual Mode
                        Button btn = null;
                        foreach (Control ctl in this.Controls)
                        {
                            if (ctl.GetType().Name == typeof(Button).Name && ctl.Name == strInstrument_ID)
                            {
                                btn = (Button)ctl;
                                break;
                            }
                        }
                        if (btn != null)
                        {
                            this.Controls.Remove(btn);
                        }
                        break;
                        #endregion
                    }
                }

                //for (int j = 0; j < this.colInstrumentList1.Count; j++)
                for (int j = 0; j < this.colInstrumentList.Length; j++)
                {
                    if (this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_ID == strInstrument_ID)
                    {
                        if (this.colInstrumentList[j].objTimer != null)
                        {
                            this.colInstrumentList[j].objTimer.Stop();
                        }
                        this.colInstrumentList[j].objDataAnalyzer = null;
                        break;
                    }
                }
                for (int k = 0; k < this.m_arlNetThread.Count; k++)
                {
                    clsThreadInfo objInfo = (clsThreadInfo)this.m_arlNetThread[k];
                    if (objInfo.m_objConnectInfo.objInstrument_Config_VO.strLIS_Instrument_ID == strInstrument_ID)
                    {
                        objInfo.m_objListener.Stop();
                        //						objInfo.m_objThread.Abort();
                    }
                    this.m_arlNetThread.Remove(objInfo);
                    break;
                }
            }


            #region 旧版本模式
            //if (this.lsvInstrument_Status.SelectedItems.Count > 0)
            //{
            //    System.Windows.Forms.ListViewItem objLSV_Item = this.lsvInstrument_Status.SelectedItems[0];
            //    string strInstrument_ID = objLSV_Item.Tag.ToString();
            //    for (int i = 0; i < this.Controls.Count; i++)
            //    {
            //        if (this.Controls[i].Name == strInstrument_ID && this.Controls[i].GetType().Name == typeof(AxDIGITALSERIALLib.AxDigitalSerial).Name)
            //        {
            //            AxDIGITALSERIALLib.AxDigitalSerial objDigitalSerial = (AxDIGITALSERIALLib.AxDigitalSerial)this.Controls[i];
            //            objDigitalSerial.CloseCom();
            //            this.Controls.RemoveAt(i);
            //            objDigitalSerial.Dispose();//非托管资源，要使用此方法释放 刘彬
            //            objDigitalSerial = null;
            //            this.lsvInstrument_Status.Items.Remove(objLSV_Item);

            //            #region Analysis Manual Mode
            //            Button btn = null;
            //            foreach (Control ctl in this.Controls)
            //            {
            //                if (ctl.GetType().Name == typeof(Button).Name && ctl.Name == strInstrument_ID)
            //                {
            //                    btn = (Button)ctl;
            //                    break;
            //                }
            //            }
            //            if (btn != null)
            //            {
            //                this.Controls.Remove(btn);
            //            }
            //            break;
            //            #endregion
            //        }
            //    }

            //    for (int j = 0; j < this.colInstrumentList.Length; j++)
            //    {
            //        if (this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_ID == strInstrument_ID)
            //        {
            //            if (this.colInstrumentList[j].objTimer != null)
            //            {
            //                this.colInstrumentList[j].objTimer.Stop();
            //            }
            //            this.colInstrumentList[j].objDataAnalyzer = null;
            //            break;
            //        }
            //    }
            //    for (int k = 0; k < this.m_arlNetThread.Count; k++)
            //    {
            //        clsThreadInfo objInfo = (clsThreadInfo)this.m_arlNetThread[k];
            //        if (objInfo.m_objConnectInfo.objInstrument_Config_VO.strLIS_Instrument_ID == strInstrument_ID)
            //        {
            //            objInfo.m_objListener.Stop();
            //            //						objInfo.m_objThread.Abort();
            //        }
            //        this.m_arlNetThread.Remove(objInfo);
            //        break;
            //    }
            //}
            #endregion

        }


        private void frmLIS_Data_Acquisition_Controller_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!this.m_blnIsExit)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void frmLIS_Data_Acquisition_Controller_Closed(object sender, System.EventArgs e)
        {
            this.m_objNotify.Visible = false;
        }


        #region Notify Icon
        private void m_objNotify_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_frmRealWindow.WindowState == FormWindowState.Minimized)
                this.m_frmRealWindow.WindowState = FormWindowState.Normal;
            this.m_frmRealWindow.Show();
            this.m_frmRealWindow.Activate();
        }

        private void m_mnuRealWindow_Click(object sender, System.EventArgs e)
        {
            if (this.m_frmRealWindow.WindowState == FormWindowState.Minimized)
                this.m_frmRealWindow.WindowState = FormWindowState.Normal;
            this.m_frmRealWindow.Show();
            this.m_frmRealWindow.Activate();
        }

        private void m_mnuExit_Click(object sender, System.EventArgs e)
        {
            this.m_blnIsExit = true;
            for (int i = 0; i < lsvInstrument_Status.Items.Count; i++)
            {
                lsvInstrument_Status.Items[i].Selected = true;
                cmdDisconnect_Click(null, null);
            }
            this.Close();
        }

        private void m_mnuControl_Click(object sender, System.EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Activate();

        }

        #endregion

        #region 仪器采集实时窗口
        public void m_mthShowMessage(clsDeviceSampleDataKey p_objDSDKey, clsLIS_Device_Test_ResultVO[] p_objResultVOArr)
        {
            this.m_frmRealWindow.m_mthShowMessage(true, p_objDSDKey, p_objResultVOArr);
        }

        #endregion

        #region Analysis Manual Mode
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsInstrument_Connection_Info obj = (clsInstrument_Connection_Info)btn.Tag;
            this.objLIS_Controller.DigitalSerial_DataComing(obj.objDataAnalyzer, "*GiveMe->Data!", obj.objInstrument_Config_VO.strLIS_Instrument_ID, obj.objInstrument_Config_VO.strLIS_Instrument_Name);
            btn.BackColor = Color.FromArgb(51, 102, 153);
            btn.Text = "w ait";

        }
        #endregion

        #region Analysis Auto.Time Mode
        private void DataAnalyzer_evtAnalysisDataEnd(object sender, System.EventArgs e)
        {
            com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase objAnalysis = (com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase)sender;
            for (int j = 0; j < this.colInstrumentList.Length; j++)
            {
                if (this.colInstrumentList[j].objDataAnalyzer == objAnalysis)
                {
                    this.objLIS_Controller.DigitalSerial_DataComing((com.digitalwave.iCare.middletier.LIS.infLISDataAnalysis)sender, "GiveLastSample!", this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_ID, this.colInstrumentList[j].objInstrument_Config_VO.strLIS_Instrument_Name);
                    break;
                }
            }
        }
        #endregion

        #region Analysis Auto.Network Mode xing.chen 16/8/2005
        private void objListener_DataReceived(object sender, clsDataReceivedEventArgs e)
        {
            foreach (clsThreadInfo obj in this.m_arlNetThread)
            {
                if (obj.m_objListener == (clsController_NetWorkListener)sender)
                {
                    this.objLIS_Controller.DigitalSerial_DataComing(obj.m_objConnectInfo.objDataAnalyzer, e.ReceiveData, obj.m_objConnectInfo.objInstrument_Config_VO.strLIS_Instrument_ID, obj.m_objConnectInfo.objInstrument_Config_VO.strLIS_Instrument_Name);
                }
            }
        }
        #endregion

        private void btnFile_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsInstrument_Connection_Info obj = (clsInstrument_Connection_Info)btn.Tag;
            if (obj.objInstrument_Config_VO.strData_Analysis_DLL == "SN695B.dll")
            {
                frmFileProcess frm = new frmFileProcess(obj.objInstrument_Config_VO.strData_Analysis_DLL);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.objLIS_Controller.DigitalSerial_DataComing(obj.objDataAnalyzer, "*GiveMe->Data!", obj.objInstrument_Config_VO.strLIS_Instrument_ID, obj.objInstrument_Config_VO.strLIS_Instrument_Name);
                }
            }
            else if (obj.objInstrument_Config_VO.strData_Analysis_DLL == "SymBIO.dll")
            {
                frmSymBIO frm = new frmSymBIO(obj.objInstrument_Config_VO.strData_Analysis_DLL);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    this.objLIS_Controller.DigitalSerial_DataComing(obj.objDataAnalyzer, "*GiveMe->Data!", obj.objInstrument_Config_VO.strLIS_Instrument_ID, obj.objInstrument_Config_VO.strLIS_Instrument_Name);
                }
            }
            else
            {
                frmSDS7300 frm = new frmSDS7300(((com.digitalwave.iCare.middletier.LIS.clsLISDataAnalysisBase)obj.objDataAnalyzer).m_strGetConfig("/configuration/settings/analysisSettings/add[@key='defaultpath']"));

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string strDeviceData = frm.m_mthSendData();

                    if (strDeviceData != null && strDeviceData.Trim() != "")
                    {
                        this.objLIS_Controller.DigitalSerial_DataComing(obj.objDataAnalyzer, strDeviceData, obj.objInstrument_Config_VO.strLIS_Instrument_ID, obj.objInstrument_Config_VO.strLIS_Instrument_Name);
                    }
                }
            }
        }

        private void objListener_Info(object sender, clsDataReceivedEventArgs e)
        {
            foreach (clsThreadInfo obj in this.m_arlNetThread)
            {
                if (obj.m_objListener == (clsController_NetWorkListener)sender)
                {
                    obj.m_Item.SubItems[1].Text = e.ReceiveData;
                }
            }
        }

    }
    public class clsThreadInfo
    {
        public System.Threading.Thread m_objThread;
        public clsInstrument_Connection_Info m_objConnectInfo;
        public clsController_NetWorkListener m_objListener;
        public System.Windows.Forms.ListViewItem m_Item;
    }
}
