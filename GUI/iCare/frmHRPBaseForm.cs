//#define FunctionPrivilege
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using PrivilegeData;
using iCareData;
using iCare.iCareBaseForm;
using com.digitalwave.Utility.SQLConvert;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.emr.DigitalSign;//电子签名
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Security.Cryptography;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Emr.DigitalSign_srv;
using com.digitalwave.emr.EMR_CaseArchivingService;
using SO = com.digitalwave.Emr.StaticObject;
using com.digitalwave.iCare.Template.Client;
using com.digitalwave.emr.AssistModuleVO;
using com.digitalwave.emr.AssistModule;
using com.digitalwave.Emr.StaticObject;

namespace iCare
{
    /// <summary>
    /// Summary description for frmHRPBaseForm.
    /// </summary>
    public class frmHRPBaseForm : frmBaseForm, com.digitalwave.emr.AssistModule.infInactiveRecord
    {
        //		protected com.digitalwave.Utility.clsLogText m_objLog = new com.digitalwave.Utility.clsLogText();
        protected System.Windows.Forms.Label lblSex;
        protected System.Windows.Forms.Label lblAge;
        protected System.Windows.Forms.Label lblBedNoTitle;
        protected System.Windows.Forms.Label lblInHospitalNoTitle;
        protected System.Windows.Forms.Label lblNameTitle;
        protected System.Windows.Forms.Label lblSexTitle;
        protected System.Windows.Forms.Label lblAgeTitle;
        protected System.Windows.Forms.Label lblAreaTitle;
        protected System.Windows.Forms.ListView m_lsvInPatientID;
        protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtInPatientID;
        private System.Windows.Forms.ToolTip m_ttpTextInfo;
        protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientName;
        protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtBedNO;
        protected com.digitalwave.Utility.Controls.ctlComboBox m_cboArea;
        protected System.Windows.Forms.ListView m_lsvPatientName;
        protected System.Windows.Forms.ListView m_lsvBedNO;
        private System.Windows.Forms.ColumnHeader clmInPatientID_BaseForm;
        private System.Windows.Forms.ColumnHeader clmPatientName_BaseForm;
        private System.Windows.Forms.ColumnHeader clmBedNO_BaseForm;
        protected ctlComboBox m_cboDept;
        protected System.Windows.Forms.Label lblDept;
        protected PinkieControls.ButtonXP m_cmdNewTemplate;
        protected System.Windows.Forms.Button m_cmdNext;
        protected System.Windows.Forms.Button m_cmdPre;
        private System.Windows.Forms.Panel m_pnlFocus;
        protected System.Windows.Forms.Label m_lblForTitle;
        private System.ComponentModel.IContainer components;
        protected string m_strCanModifyTime = "";

        protected bool m_blnDeptOrAreaIsClear = true;

        private bool m_blnSetGetPatientByDept = true;
        //按住院号获取病人
        protected bool m_BlnSetGetPatientByDept
        {
            get { return m_blnSetGetPatientByDept; }
            set { m_blnSetGetPatientByDept = value; }
        }

        /// <summary>
        /// 保存最小元素集值
        /// </summary>
        public ArrayList m_arlMinElementColValue;
        /// <summary>
        /// 记录的唯一标识
        /// </summary>
        public virtual string m_StrRecordID
        {
            get { return ""; }
        }
        protected string m_strPatientID = "";
        protected System.Windows.Forms.CheckBox chkModifyWithoutMatk;

        public string m_StrPatientID
        {
            get { return m_strPatientID; }
            set { m_strPatientID = value; }
        }
        /// <summary>
        /// 回车跳转控制
        /// </summary>
        protected clsJumpControl m_objJump;
        /// <summary>
        /// 是否只读
        /// </summary>
        protected bool m_blnReadOnly = true;
        /// <summary>
        /// 剩余的归档时间
        /// </summary>
        protected string m_strTimeRemain = "";
        protected ToolTip m_tipMain;
        protected DateTime m_dtmCreatedDate;
        public DateTime m_DtmCreatedDate
        {
            get { return m_dtmCreatedDate; }
        }
        /// <summary>
        /// 表单类型
        /// 1医生工作站 2护士工作站
        /// 需要对上级验证时需指明表单类型方可列出合适类型的上级领导 比如科室主任或者护士长
        /// </summary>
        protected int intFormType;
        protected ExternalControlsLib.XPButton m_cmdModifyPatientInfo;
        /// <summary>
        /// 是否手动取消归档的病案，如是，则需护士长或科主任才能修改
        /// </summary>
        private bool m_blnIsCancelArchivedCase = false;
        protected Panel m_pnlNewBase;
        protected com.digitalwave.Controls.Domain.EmrControls.ctlAreaPatientSelected m_ctlAreaPatientSelection;
        protected com.digitalwave.Controls.Domain.EmrControls.ctlEmrPatientInfo m_ctlPatientInfo;

        /// <summary>
        /// 模板客户端
        /// </summary>
        private clsTemplateClient m_objTemplateClient = null;
        ///// <summary>
        ///// 获取模板客户端
        ///// </summary>
        //public clsTemplateClient m_ObjTemplateClient
        //{
        //    get
        //    {
        //        if (m_objTemplateClient == null)
        //        {
        //            if (m_ctlAreaPatientSelection.CurrentArea != null)
        //            {
        //                m_objTemplateClient = new clsTemplateClient(this, clsEMRLogin.LoginEmployee.m_strEMPID_CHR, 
        //                    m_ctlAreaPatientSelection.CurrentArea.m_strDEPTID_CHR, false, true);
        //            }
        //        }
        //        return m_objTemplateClient;
        //    }
        //}
        /// <summary>
        /// 获取模板客户端
        /// </summary>
        public clsTemplateClient m_ObjTemplateClient
        {
            get
            {
                string strDeptID = string.Empty;
                if (m_ObjCurrentEmrPatient != null)
                {
                    strDeptID = m_ObjCurrentEmrPatient.m_strDEPTID_CHR;
                }
                else if (m_ctlAreaPatientSelection.CurrentArea != null)
                {
                    strDeptID = m_ctlAreaPatientSelection.CurrentArea.m_strDEPTID_CHR;
                }

                if (m_objTemplateClient == null || (m_objTemplateClient.m_StrDepartmentID != strDeptID))
                {
                    m_objTemplateClient = new clsTemplateClient(this, clsEMRLogin.LoginEmployee.m_strEMPID_CHR,
                            strDeptID, false, true);
                }

                return m_objTemplateClient;
            }
        }
        //		private clsAdjustByDept m_objAdjustByDept;
        public frmHRPBaseForm()
        {
            InitializeComponent();
            m_arlMinElementColValue = new ArrayList();

            txtInPatientID.LostFocus += new EventHandler(m_mthPatientListControl);
            m_lsvInPatientID.LostFocus += new EventHandler(m_mthPatientListControl);
            m_txtPatientName.LostFocus += new EventHandler(m_lsvPatientName_LostFocus);
            m_lsvPatientName.LostFocus += new EventHandler(m_lsvPatientName_LostFocus);
            m_txtBedNO.LostFocus += new EventHandler(m_lsvBedNO_LostFocus);
            m_lsvBedNO.LostFocus += new EventHandler(m_lsvBedNO_LostFocus);
            //Liu RongGuo 2003.4.11
            m_strTemplatePath = m_strGetFilePathHeader() + "Templates\\\\";

            m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);

            m_objTempTool = new clsTemplatesetInvoke();

            m_strCanModifyTime = clsEMRLogin.StrCanModifyTime;
            chkModifyWithoutMatk.Checked = true;

            if (SO.clsEMR_StaticObject.s_intGetEmrSettingValue("3016") == 1) this.m_cmdModifyPatientInfo.Visible = true;

            if (!DesignMode && this.Site == null)
                m_ctlAreaPatientSelection.m_mthInit(com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment);
        }

        /// <summary>
        /// 用户不修改记录
        /// </summary>
        public const int c_intUserNotAllowToModify = -13;
        protected frmTemplatesetDialog m_frmSaveTemplateset;

        protected clsTemplatesetInvoke m_objTempTool;

        protected ctlHighLightFocus m_objHighLight;

        protected string m_strTemplatePath = "";

        protected clsSystemContext m_objCurrentContext
        {
            get
            {
                return clsSystemContext.s_ObjCurrentContext;
            }
        }

        protected bool m_blnCanTextChanged = true;

        public bool m_BlnIsMark
        {
            get { return !chkModifyWithoutMatk.Checked; }
        }

        public clsPatient m_objBaseCurrentPatient;

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
                if (m_arlMinElementColValue != null)
                {
                    m_arlMinElementColValue.Clear();
                    m_arlMinElementColValue = null;
                }
                m_objJump = null;
                //				objPIArr = null;
                if (m_frmSaveTemplateset != null)
                {
                    m_frmSaveTemplateset.Dispose();
                    m_frmSaveTemplateset = null;
                }
                m_objTempTool = null;
                m_objBaseCurrentPatient = null;
                if (m_arlRTB != null)
                {
                    m_arlRTB.Clear();
                    m_arlRTB = null;
                }

                if (m_frmSaveTemplateset != null)
                {
                    m_frmSaveTemplateset = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHRPBaseForm));
            this.lblSex = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblBedNoTitle = new System.Windows.Forms.Label();
            this.lblInHospitalNoTitle = new System.Windows.Forms.Label();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.lblSexTitle = new System.Windows.Forms.Label();
            this.lblAgeTitle = new System.Windows.Forms.Label();
            this.lblAreaTitle = new System.Windows.Forms.Label();
            this.txtInPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_lsvInPatientID = new System.Windows.Forms.ListView();
            this.clmInPatientID_BaseForm = new System.Windows.Forms.ColumnHeader();
            this.m_ttpTextInfo = new System.Windows.Forms.ToolTip(this.components);
            this.m_txtPatientName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtBedNO = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_cboArea = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_lsvPatientName = new System.Windows.Forms.ListView();
            this.clmPatientName_BaseForm = new System.Windows.Forms.ColumnHeader();
            this.m_lsvBedNO = new System.Windows.Forms.ListView();
            this.clmBedNO_BaseForm = new System.Windows.Forms.ColumnHeader();
            this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.lblDept = new System.Windows.Forms.Label();
            this.m_cmdNewTemplate = new PinkieControls.ButtonXP();
            this.m_cmdNext = new System.Windows.Forms.Button();
            this.m_cmdPre = new System.Windows.Forms.Button();
            this.m_pnlFocus = new System.Windows.Forms.Panel();
            this.m_lblForTitle = new System.Windows.Forms.Label();
            this.chkModifyWithoutMatk = new System.Windows.Forms.CheckBox();
            this.m_tipMain = new System.Windows.Forms.ToolTip(this.components);
            this.m_cmdModifyPatientInfo = new ExternalControlsLib.XPButton();
            this.m_pnlNewBase = new System.Windows.Forms.Panel();
            this.m_ctlPatientInfo = new com.digitalwave.Controls.Domain.EmrControls.ctlEmrPatientInfo();
            this.m_ctlAreaPatientSelection = new com.digitalwave.Controls.Domain.EmrControls.ctlAreaPatientSelected();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSex.ForeColor = System.Drawing.Color.Black;
            this.lblSex.Location = new System.Drawing.Point(628, 12);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(48, 19);
            this.lblSex.TabIndex = 498;
            // 
            // lblAge
            // 
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAge.ForeColor = System.Drawing.Color.Black;
            this.lblAge.Location = new System.Drawing.Point(736, 12);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(52, 19);
            this.lblAge.TabIndex = 497;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.AutoSize = true;
            this.lblBedNoTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBedNoTitle.ForeColor = System.Drawing.Color.Black;
            this.lblBedNoTitle.Location = new System.Drawing.Point(236, 16);
            this.lblBedNoTitle.Name = "lblBedNoTitle";
            this.lblBedNoTitle.Size = new System.Drawing.Size(42, 14);
            this.lblBedNoTitle.TabIndex = 495;
            this.lblBedNoTitle.Text = "床号:";
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.AutoSize = true;
            this.lblInHospitalNoTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInHospitalNoTitle.ForeColor = System.Drawing.Color.Black;
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(224, 48);
            this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
            this.lblInHospitalNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblInHospitalNoTitle.TabIndex = 494;
            this.lblInHospitalNoTitle.Text = "住院号:";
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNameTitle.ForeColor = System.Drawing.Color.Black;
            this.lblNameTitle.Location = new System.Drawing.Point(408, 16);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(42, 14);
            this.lblNameTitle.TabIndex = 493;
            this.lblNameTitle.Text = "姓名:";
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.AutoSize = true;
            this.lblSexTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSexTitle.ForeColor = System.Drawing.Color.Black;
            this.lblSexTitle.Location = new System.Drawing.Point(580, 12);
            this.lblSexTitle.Name = "lblSexTitle";
            this.lblSexTitle.Size = new System.Drawing.Size(42, 14);
            this.lblSexTitle.TabIndex = 492;
            this.lblSexTitle.Text = "性别:";
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.AutoSize = true;
            this.lblAgeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAgeTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAgeTitle.Location = new System.Drawing.Point(688, 12);
            this.lblAgeTitle.Name = "lblAgeTitle";
            this.lblAgeTitle.Size = new System.Drawing.Size(42, 14);
            this.lblAgeTitle.TabIndex = 491;
            this.lblAgeTitle.Text = "年龄:";
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.AutoSize = true;
            this.lblAreaTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAreaTitle.ForeColor = System.Drawing.Color.Black;
            this.lblAreaTitle.Location = new System.Drawing.Point(16, 48);
            this.lblAreaTitle.Name = "lblAreaTitle";
            this.lblAreaTitle.Size = new System.Drawing.Size(42, 14);
            this.lblAreaTitle.TabIndex = 490;
            this.lblAreaTitle.Text = "病区:";
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.AccessibleName = "NoDefault";
            this.txtInPatientID.BackColor = System.Drawing.Color.White;
            this.txtInPatientID.BorderColor = System.Drawing.Color.Transparent;
            this.txtInPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInPatientID.ForeColor = System.Drawing.Color.Black;
            this.txtInPatientID.Location = new System.Drawing.Point(280, 44);
            this.txtInPatientID.Name = "txtInPatientID";
            this.txtInPatientID.Size = new System.Drawing.Size(116, 23);
            this.txtInPatientID.TabIndex = 5;
            this.txtInPatientID.TextChanged += new System.EventHandler(this.txtInPatientID_TextChanged);
            this.txtInPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.BackColor = System.Drawing.Color.White;
            this.m_lsvInPatientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvInPatientID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmInPatientID_BaseForm});
            this.m_lsvInPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvInPatientID.ForeColor = System.Drawing.Color.Black;
            this.m_lsvInPatientID.FullRowSelect = true;
            this.m_lsvInPatientID.GridLines = true;
            this.m_lsvInPatientID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvInPatientID.Location = new System.Drawing.Point(280, 68);
            this.m_lsvInPatientID.Name = "m_lsvInPatientID";
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 104);
            this.m_lsvInPatientID.TabIndex = 6;
            this.m_lsvInPatientID.UseCompatibleStateImageBehavior = false;
            this.m_lsvInPatientID.View = System.Windows.Forms.View.Details;
            this.m_lsvInPatientID.DoubleClick += new System.EventHandler(this.m_lsvInPatientID_DoubleClick);
            this.m_lsvInPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // clmInPatientID_BaseForm
            // 
            this.clmInPatientID_BaseForm.Width = 100;
            // 
            // m_ttpTextInfo
            // 
            this.m_ttpTextInfo.AutomaticDelay = 200;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.AccessibleName = "NoDefault";
            this.m_txtPatientName.BackColor = System.Drawing.Color.White;
            this.m_txtPatientName.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPatientName.ForeColor = System.Drawing.Color.Black;
            this.m_txtPatientName.Location = new System.Drawing.Point(452, 12);
            this.m_txtPatientName.Name = "m_txtPatientName";
            this.m_txtPatientName.Size = new System.Drawing.Size(116, 23);
            this.m_txtPatientName.TabIndex = 3;
            this.m_txtPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.AccessibleName = "NoDefault";
            this.m_txtBedNO.BackColor = System.Drawing.Color.White;
            this.m_txtBedNO.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtBedNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBedNO.ForeColor = System.Drawing.Color.Black;
            this.m_txtBedNO.Location = new System.Drawing.Point(280, 12);
            this.m_txtBedNO.Name = "m_txtBedNO";
            this.m_txtBedNO.Size = new System.Drawing.Size(116, 23);
            this.m_txtBedNO.TabIndex = 1;
            this.m_txtBedNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // m_cboArea
            // 
            this.m_cboArea.AccessibleName = "NoDefault";
            this.m_cboArea.BackColor = System.Drawing.Color.White;
            this.m_cboArea.BorderColor = System.Drawing.Color.Black;
            this.m_cboArea.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboArea.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboArea.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboArea.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboArea.ForeColor = System.Drawing.Color.Black;
            this.m_cboArea.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboArea.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboArea.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboArea.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboArea.Location = new System.Drawing.Point(64, 44);
            this.m_cboArea.m_BlnEnableItemEventMenu = false;
            this.m_cboArea.Name = "m_cboArea";
            this.m_cboArea.SelectedIndex = -1;
            this.m_cboArea.SelectedItem = null;
            this.m_cboArea.SelectionStart = 0;
            this.m_cboArea.Size = new System.Drawing.Size(144, 23);
            this.m_cboArea.TabIndex = 0;
            this.m_cboArea.TabStop = false;
            this.m_cboArea.TextBackColor = System.Drawing.Color.White;
            this.m_cboArea.TextForeColor = System.Drawing.Color.Black;
            this.m_cboArea.SelectedIndexChanged += new System.EventHandler(this.m_cboArea_SelectedIndexChanged);
            this.m_cboArea.DropDown += new System.EventHandler(this.m_cboArea_DropDown);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.BackColor = System.Drawing.Color.White;
            this.m_lsvPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvPatientName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPatientName_BaseForm});
            this.m_lsvPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvPatientName.ForeColor = System.Drawing.Color.Black;
            this.m_lsvPatientName.FullRowSelect = true;
            this.m_lsvPatientName.GridLines = true;
            this.m_lsvPatientName.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvPatientName.Location = new System.Drawing.Point(452, 36);
            this.m_lsvPatientName.Name = "m_lsvPatientName";
            this.m_lsvPatientName.Size = new System.Drawing.Size(116, 104);
            this.m_lsvPatientName.TabIndex = 4;
            this.m_lsvPatientName.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientName.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientName.DoubleClick += new System.EventHandler(this.m_lsvPatientName_DoubleClick);
            this.m_lsvPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // clmPatientName_BaseForm
            // 
            this.clmPatientName_BaseForm.Width = 97;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.BackColor = System.Drawing.Color.White;
            this.m_lsvBedNO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvBedNO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmBedNO_BaseForm});
            this.m_lsvBedNO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvBedNO.ForeColor = System.Drawing.Color.Black;
            this.m_lsvBedNO.FullRowSelect = true;
            this.m_lsvBedNO.GridLines = true;
            this.m_lsvBedNO.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvBedNO.Location = new System.Drawing.Point(280, 36);
            this.m_lsvBedNO.Name = "m_lsvBedNO";
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 104);
            this.m_lsvBedNO.TabIndex = 2;
            this.m_lsvBedNO.UseCompatibleStateImageBehavior = false;
            this.m_lsvBedNO.View = System.Windows.Forms.View.Details;
            this.m_lsvBedNO.DoubleClick += new System.EventHandler(this.m_lsvBedNO_DoubleClick);
            this.m_lsvBedNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
            // 
            // clmBedNO_BaseForm
            // 
            this.clmBedNO_BaseForm.Width = 80;
            // 
            // m_cboDept
            // 
            this.m_cboDept.AccessibleName = "NoDefault";
            this.m_cboDept.BackColor = System.Drawing.Color.White;
            this.m_cboDept.BorderColor = System.Drawing.Color.Black;
            this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboDept.ForeColor = System.Drawing.Color.Black;
            this.m_cboDept.ListBackColor = System.Drawing.SystemColors.ControlLight;
            this.m_cboDept.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboDept.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboDept.Location = new System.Drawing.Point(64, 12);
            this.m_cboDept.m_BlnEnableItemEventMenu = false;
            this.m_cboDept.Name = "m_cboDept";
            this.m_cboDept.SelectedIndex = -1;
            this.m_cboDept.SelectedItem = null;
            this.m_cboDept.SelectionStart = 0;
            this.m_cboDept.Size = new System.Drawing.Size(144, 23);
            this.m_cboDept.TabIndex = 9999999;
            this.m_cboDept.TabStop = false;
            this.m_cboDept.TextBackColor = System.Drawing.Color.White;
            this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
            this.m_cboDept.SelectedIndexChanged += new System.EventHandler(this.m_cboDept_SelectedIndexChanged);
            this.m_cboDept.DropDown += new System.EventHandler(this.m_cboDept_DropDown);
            // 
            // lblDept
            // 
            this.lblDept.AccessibleName = "NoDefaultIn";
            this.lblDept.AutoSize = true;
            this.lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDept.ForeColor = System.Drawing.Color.Black;
            this.lblDept.Location = new System.Drawing.Point(16, 16);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(42, 14);
            this.lblDept.TabIndex = 500;
            this.lblDept.Text = "科室:";
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdNewTemplate.DefaultScheme = true;
            this.m_cmdNewTemplate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdNewTemplate.ForeColor = System.Drawing.Color.Black;
            this.m_cmdNewTemplate.Hint = "";
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(704, 48);
            this.m_cmdNewTemplate.Name = "m_cmdNewTemplate";
            this.m_cmdNewTemplate.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 32);
            this.m_cmdNewTemplate.TabIndex = 10000000;
            this.m_cmdNewTemplate.Text = "生成模板";
            this.m_cmdNewTemplate.Visible = false;
            this.m_cmdNewTemplate.Click += new System.EventHandler(this.m_blnNewTemplate_Click);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdNext.ForeColor = System.Drawing.Color.Black;
            this.m_cmdNext.Location = new System.Drawing.Point(196, 12);
            this.m_cmdNext.Name = "m_cmdNext";
            this.m_cmdNext.Size = new System.Drawing.Size(24, 21);
            this.m_cmdNext.TabIndex = 10000001;
            this.m_cmdNext.TabStop = false;
            this.m_cmdNext.Text = "↓";
            this.m_cmdNext.Visible = false;
            this.m_cmdNext.Click += new System.EventHandler(this.m_cmdNext_Click);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdPre.ForeColor = System.Drawing.Color.Black;
            this.m_cmdPre.Location = new System.Drawing.Point(156, 12);
            this.m_cmdPre.Name = "m_cmdPre";
            this.m_cmdPre.Size = new System.Drawing.Size(24, 21);
            this.m_cmdPre.TabIndex = 10000002;
            this.m_cmdPre.TabStop = false;
            this.m_cmdPre.Text = "<";
            this.m_cmdPre.Visible = false;
            this.m_cmdPre.Click += new System.EventHandler(this.m_cmdPre_Click);
            // 
            // m_pnlFocus
            // 
            this.m_pnlFocus.Location = new System.Drawing.Point(12, 16);
            this.m_pnlFocus.Name = "m_pnlFocus";
            this.m_pnlFocus.Size = new System.Drawing.Size(0, 0);
            this.m_pnlFocus.TabIndex = 0;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(448, 8);
            this.m_lblForTitle.Name = "m_lblForTitle";
            this.m_lblForTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_lblForTitle.Size = new System.Drawing.Size(16, 23);
            this.m_lblForTitle.TabIndex = 10000003;
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkModifyWithoutMatk.ForeColor = System.Drawing.Color.Red;
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(580, 44);
            this.chkModifyWithoutMatk.Name = "chkModifyWithoutMatk";
            this.chkModifyWithoutMatk.Size = new System.Drawing.Size(88, 24);
            this.chkModifyWithoutMatk.TabIndex = 10000004;
            this.chkModifyWithoutMatk.Text = "无痕迹修改";
            this.chkModifyWithoutMatk.Visible = false;
            this.chkModifyWithoutMatk.Click += new System.EventHandler(this.chkModifyWithoutMatk_Click);
            // 
            // m_tipMain
            // 
            this.m_tipMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_tipMain.IsBalloon = true;
            this.m_tipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.m_tipMain.ToolTipTitle = "温馨提示";
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.m_cmdModifyPatientInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdModifyPatientInfo.BtnShape = ExternalControlsLib.emunType.BtnShape.Rectangle;
            this.m_cmdModifyPatientInfo.BtnStyle = ExternalControlsLib.emunType.XPStyle.Blue;
            this.m_cmdModifyPatientInfo.ForeColor = System.Drawing.Color.Black;
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(629, 50);
            this.m_cmdModifyPatientInfo.Name = "m_cmdModifyPatientInfo";
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 30);
            this.m_cmdModifyPatientInfo.TabIndex = 10000000;
            this.m_cmdModifyPatientInfo.Text = "患者资料";
            this.m_tipMain.SetToolTip(this.m_cmdModifyPatientInfo, "点击查看和修改患者详细信息(快捷键Alt+P)");
            this.m_cmdModifyPatientInfo.UseVisualStyleBackColor = false;
            this.m_cmdModifyPatientInfo.Visible = false;
            this.m_cmdModifyPatientInfo.Click += new System.EventHandler(this.m_cmdModifyPatientInfo_Click);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.AccessibleName = "NoDefaultIn";
            this.m_pnlNewBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_pnlNewBase.Controls.Add(this.m_ctlPatientInfo);
            this.m_pnlNewBase.Controls.Add(this.m_ctlAreaPatientSelection);
            this.m_pnlNewBase.Location = new System.Drawing.Point(10, 7);
            this.m_pnlNewBase.Name = "m_pnlNewBase";
            this.m_pnlNewBase.Size = new System.Drawing.Size(785, 60);
            this.m_pnlNewBase.TabIndex = 10000005;
            this.m_pnlNewBase.Visible = false;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctlPatientInfo.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(0, 29);
            this.m_ctlPatientInfo.m_BlnIsShowAddres = false;
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = false;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = false;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = false;
            this.m_ctlPatientInfo.m_BlnIsShowOffice = false;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = false;
            this.m_ctlPatientInfo.m_BlnIsShowRelationName = false;
            this.m_ctlPatientInfo.m_BlnIsShowRelationPhone = false;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Name = "m_ctlPatientInfo";
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(783, 29);
            this.m_ctlPatientInfo.TabIndex = 10000006;
            // 
            // m_ctlAreaPatientSelection
            // 
            this.m_ctlAreaPatientSelection.AutoSize = false;
            this.m_ctlAreaPatientSelection.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_ctlAreaPatientSelection.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.m_ctlAreaPatientSelection.Location = new System.Drawing.Point(0, 0);
            this.m_ctlAreaPatientSelection.m_BlnIsInUse = true;
            this.m_ctlAreaPatientSelection.m_BlnIsShowArea = true;
            this.m_ctlAreaPatientSelection.m_BlnIsShowBorder = false;
            this.m_ctlAreaPatientSelection.m_BlnIsShowDefaultArea = true;
            this.m_ctlAreaPatientSelection.m_ClrEnd = System.Drawing.SystemColors.Control;
            this.m_ctlAreaPatientSelection.m_ClrStart = System.Drawing.SystemColors.Control;
            this.m_ctlAreaPatientSelection.Name = "m_ctlAreaPatientSelection";
            this.m_ctlAreaPatientSelection.Size = new System.Drawing.Size(783, 29);
            this.m_ctlAreaPatientSelection.TabIndex = 2;
            this.m_ctlAreaPatientSelection.evtAreaChanged += new com.digitalwave.Controls.Domain.EmrControls.AreaSelectedEventHandler(this.m_ctlAreaPatientSelection_evtAreaChanged);
            this.m_ctlAreaPatientSelection.evtBedChanged += new com.digitalwave.Controls.Domain.EmrControls.BedSelectedEventHandler(this.m_ctlAreaPatientSelection_evtBedChanged);
            this.m_ctlAreaPatientSelection.evtSessionSelected += new com.digitalwave.Controls.Domain.EmrControls.SelectedSessionEventHandler(this.m_ctlAreaPatientSelection_evtSessionSelected);
            this.m_ctlAreaPatientSelection.evtRefreshResult += new com.digitalwave.Controls.Domain.EmrControls.RefreshEventHandler(this.m_ctlAreaPatientSelection_evtRefreshResult);
            // 
            // frmHRPBaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(797, 502);
            this.Controls.Add(this.m_pnlNewBase);
            this.Controls.Add(this.chkModifyWithoutMatk);
            this.Controls.Add(this.m_lblForTitle);
            this.Controls.Add(this.m_lsvInPatientID);
            this.Controls.Add(this.m_lsvPatientName);
            this.Controls.Add(this.m_lsvBedNO);
            this.Controls.Add(this.m_pnlFocus);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblAreaTitle);
            this.Controls.Add(this.lblBedNoTitle);
            this.Controls.Add(this.m_txtBedNO);
            this.Controls.Add(this.lblInHospitalNoTitle);
            this.Controls.Add(this.txtInPatientID);
            this.Controls.Add(this.lblNameTitle);
            this.Controls.Add(this.m_txtPatientName);
            this.Controls.Add(this.lblAgeTitle);
            this.Controls.Add(this.lblSexTitle);
            this.Controls.Add(this.m_cmdModifyPatientInfo);
            this.Controls.Add(this.m_cmdNewTemplate);
            this.Controls.Add(this.m_cboDept);
            this.Controls.Add(this.m_cboArea);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.m_cmdPre);
            this.Controls.Add(this.m_cmdNext);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmHRPBaseForm";
            this.Deactivate += new System.EventHandler(this.frmHRPBaseForm_Deactivate);
            this.Enter += new System.EventHandler(this.frmHRPBaseForm_Enter);
            this.Click += new System.EventHandler(this.frmHRPBaseForm_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mth_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmHRPBaseForm_MouseDown);
            this.Load += new System.EventHandler(this.frmHRPBaseForm_Load);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 控制的操作
        /// <summary>
        /// 获取当前表单状态
        /// </summary>
        protected virtual enmFormState m_EnmCurrentFormState
        {
            get
            {
                //				throw new Exception("没有实现 m_EnmCurrentFormState 函数");
                return enmFormState.NowUser;
            }
        }

        private DateTime m_dtmPreSave;

        /// <summary>
        /// 获取当前窗体的SF
        /// </summary>
        /// <returns></returns>
        private PrivilegeData.enmPrivilegeSF m_enmGetPrivilegeSF()
        {
            try//审核将会重做
            {
                return (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF), this.GetType().Name);//此时的this为子窗体
            }
            catch
            {
                return PrivilegeData.enmPrivilegeSF.frmInPatientCaseHistory;
            }
        }
        private bool m_blnNeedContextMenu = true;
        protected bool m_BlnNeedContextMenu
        {
            get { return m_blnNeedContextMenu; }
            set { m_blnNeedContextMenu = value; }
        }

        /// <summary>
        /// 验证科主任或护士长
        /// </summary>
        /// <returns></returns>
        protected bool m_BlnCheckValidateByDirector()
        {
            bool blnValidate = false;

            System.Text.StringBuilder strMes = new System.Text.StringBuilder(100);
            strMes.Append("此病人的所有病历为只读，不能存盘。");
            strMes.Append(Environment.NewLine);
            strMes.Append("如需存盘需经过");
            if (m_EnmAppType == enmApproveType.Nurses)
            {
                strMes.Append("护士长");
                intFormType = 2;
            }
            else
            {
                strMes.Append("科主任");
                intFormType = 1;
            }
            strMes.Append("的批准。");
            strMes.Append(Environment.NewLine);
            strMes.Append("存盘请按【是】，取消请按【否】。");

            string strMessageInf = strMes.ToString();
            if (MDIParent.ShowInformationMessageBox(strMessageInf, System.Windows.Forms.MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;//((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID;
                frmValidateByDirector frm = new frmValidateByDirector(intFormType, strDeptIDTemp);
                frm.ShowDialog(this);
                blnValidate = frm.BlnValidateResult;
            }
            return blnValidate;
        }

        /// <summary>
        /// 获取审签病历
        /// </summary>
        protected clsEMR_CaseAuditVO m_objGetAuditCase()
        {
            com.digitalwave.emr.AssistModuleVO.clsEMR_CaseAuditVO objVO = new clsEMR_CaseAuditVO();
            objVO.m_strREGISTERID_CHR = m_ObjCurrentEmrPatientSession.m_strRegisterId;
            objVO.m_intSTATUS_INT = 0;
            objVO.m_strCREATORID = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR;
            objVO.m_strFORMID_VCHR = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI.ActiveMdiChild.Name;
            objVO.m_strFORMNAME_VCHR = this.AccessibleDescription;
            objVO.m_strDeptID = m_ObjCurrentEmrPatientSession.m_strDeptId;
            objVO.m_strAreaID = m_ObjCurrentEmrPatientSession.m_strAreaId;
            return objVO;
        }

        /// <summary>
        /// 添加审签病历
        /// </summary>
        /// <param name="p_objVO">审签病历</param>
        protected void m_mthAddAuditCase(clsEMR_CaseAuditVO p_objVO)
        {
            com.digitalwave.emr.AssistModuleSev.clsAuditCaseServ_Modify objServ =
                (com.digitalwave.emr.AssistModuleSev.clsAuditCaseServ_Modify)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.AssistModuleSev.clsAuditCaseServ_Modify));
            long lngRes = objServ.m_lngAddCaseAudit(p_objVO);
            objServ = null;
        }

        /// <summary>
        /// 删除审签病历
        /// </summary>
        /// <param name="p_objVO">审签病历</param>
        protected void m_mthDelAuditCase(clsEMR_CaseAuditVO p_objVO)
        {
            com.digitalwave.emr.AssistModuleSev.clsAuditCaseServ_Modify objServ =
                (com.digitalwave.emr.AssistModuleSev.clsAuditCaseServ_Modify)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.emr.AssistModuleSev.clsAuditCaseServ_Modify));
            long lngRes = objServ.m_lngDelCaseAudit(p_objVO);
            objServ = null;
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <returns>操作结果</returns>
        public long m_lngSave()
        {
            //			PrivilegeData.enmPrivilegeSF enmSF = m_enmGetPrivilegeSF();
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return 0;
			}			
#endif

            //			string s = "123";
            //			int i = int.Parse(s);
            //			PrivilegeData.enmPrivilegeSF enmSF = PrivilegeData.enmPrivilegeSF.BabyInjuryCaseEvaluation;

            //			if(m_objBaseCurrentPatient == null)
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("请先选择病人。");
            //				return -10;
            //			}
            //
            //			if(m_objBaseCurrentPatient.m_StrInPatientID != txtInPatientID.Text)
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("住院号与病人信息不一致，不能存盘。");
            //				return -11;
            //			}

            //			if(!new clsEmployeeSignTool().m_blnCheckSignRightMethod(this)) return -10;

            if (DateTime.Now.Second == m_dtmPreSave.Second)
            {
                System.Threading.Thread.Sleep(1000);
            }
            string strTimeRemaining;
            //			bool blnReadOnly=false;
            //			new clsInPatientArchivingDomain().lngIsReadOnly(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),out blnReadOnly,out strTimeRemaining);
            //			if(blnReadOnly)
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("此病人的所有病历为只读，不能存盘。");
            //				return (long)enmOperationResult.Not_permission;
            //			}
            try
            {
                bool blnHasDirectorRole = false;
                if (m_EnmAppType == enmApproveType.Nurses)
                {
                    blnHasDirectorRole = new clsApprove_FlowDomain().blnEmployeeMatchingRole(clsLoginContext.s_ObjLoginContext.m_StrEmployeeID, "护士长");
                }
                else
                {
                    blnHasDirectorRole = new clsApprove_FlowDomain().blnEmployeeMatchingRole(clsLoginContext.s_ObjLoginContext.m_StrEmployeeID, "科主任");
                }

                if (!blnHasDirectorRole)
                {
                    if (m_blnReadOnly)
                    {
                        if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_IntNeedRequestToSeeCase == 1)
                        {
                            return (long)enmOperationResult.Not_permission;
                        }
                        else
                        {
                            if (!m_BlnCheckValidateByDirector())
                            {
                                return (long)enmOperationResult.Not_permission;
                            }
                        }
                    }
                    else if (m_blnIsCancelArchivedCase)
                    {
                        if (!m_BlnCheckValidateByDirector())
                        {
                            return (long)enmOperationResult.Not_permission;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string strMes = e.Message;
            }


            if (m_BlnIsAddNew)
            {
                //				if(m_objCurrentContext.m_ObjControl.m_enmAddNewCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,m_EnmCurrentFormState)
                //					== enmDBControlCheckResult.Disable)
                //				{
                //					clsPublicFunction.s_mthShowNotPermitMessage();
                //					return -1;
                //				}
                //				else
                //				{
                this.Cursor = Cursors.WaitCursor;
                //					txtInPatientID.Focus();
                long lngRes = m_lngSubAddNew();
                if (lngRes > 0)
                {
                    m_mthAfterSuccessfulSave();
                }

                m_mthSaveMinElementValue();
                m_mthAddFormStatusForClosingSave();
                this.Cursor = Cursors.Default;
                m_dtmPreSave = DateTime.Now;
                return lngRes;
                //				}
            }
            else
            {
                //				if(m_objCurrentContext.m_ObjControl.m_enmModifyCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,m_EnmCurrentFormState)
                //					== enmDBControlCheckResult.Disable)
                //				{
                //					clsPublicFunction.s_mthShowNotPermitMessage();
                //					return -1;
                //				}
                if (!lngCanYouDoIt())
                {
                    clsPublicFunction.ShowInformationMessageBox("该单已被上级审核过，您无权修改！");
                    return -1;
                }
                else
                {
                    //					if(!clsPublicFunction.s_blnAskForModify())
                    //						return c_intUserNotAllowToModify;

                    this.Cursor = Cursors.WaitCursor;
                    //					txtInPatientID.Focus();
                    long lngRes = m_lngSubModify();
                    if (lngRes > 0)
                    {
                        m_mthAfterSuccessfulSave();
                    }
                    m_mthSaveMinElementValue();
                    m_mthAddFormStatusForClosingSave();
                    this.Cursor = Cursors.Default;
                    m_dtmPreSave = DateTime.Now;
                    return lngRes;
                }
            }
        }

        /// <summary>
        /// 成功保存后做的操作(新添及修改都将执行)
        /// </summary>
        protected virtual void m_mthAfterSuccessfulSave()
        {
            return;
        }

        protected bool m_blnNeedCheckArchive = true;
        protected virtual void m_mthIsReadOnly()
        {
            if (m_blnNeedCheckArchive)
            {
                m_blnReadOnly = false;
                m_strTimeRemain = "";
                if (m_objBaseCurrentPatient != null)
                {
                    m_mthCheckCaseArchiving(m_objBaseCurrentPatient.m_StrRegisterId, out m_blnReadOnly, out m_strTimeRemain);
                    m_mthPromtForArchiving(m_blnReadOnly, m_strTimeRemain);
                    if (m_blnReadOnly || m_blnIsCancelArchivedCase)
                    {
                        m_objBaseCurrentPatient.m_IntCharacter = 1;
                        m_mthSetIfCanSelectPatient(false);
                    }
                    else
                    {
                        m_objBaseCurrentPatient.m_IntCharacter = 0;
                        m_mthSetIfCanSelectPatient(true);
                    }
                }
            }
        }

        /// <summary>
        /// 检查病人病历是否已归档，并作相应提示
        /// </summary>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <param name="p_blnReadOnly">是否只读</param>
        /// <param name="p_strTimeRemain">剩余修改时间提示</param>
        private void m_mthCheckCaseArchiving(string p_strRegisterID, out bool p_blnReadOnly, out string p_strTimeRemain)
        {
            p_blnReadOnly = false;
            p_strTimeRemain = string.Empty;
            m_blnIsCancelArchivedCase = false;

            clsEMR_CaseArchivingService objServ =
                    (clsEMR_CaseArchivingService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_CaseArchivingService));

            clsEMR_CaseArchivingValue objVO = null;
            int intWorkDaysOnly = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3020");
            long lngRes = objServ.m_lngCheckFormReadOnly(null, p_strRegisterID, intWorkDaysOnly == 1, out objVO);

            if (objVO != null)
            {
                if (objVO.m_intARCHIVEDSTATUS_INT == 1 || objVO.m_intARCHIVEDSTATUS_INT == 2)
                {
                    p_blnReadOnly = true;
                    return;
                }

                if (objVO.m_intARCHIVEDSTATUS_INT == -1)
                {
                    m_blnIsCancelArchivedCase = true;
                }
                else
                {
                    m_blnIsCancelArchivedCase = false;

                    //string strDeadLine = "7";
                    //lngRes = new com.digitalwave.PublicMiddleTier.clsPublicMiddleTier().m_lngGetConfigBySettingID("3010", out strDeadLine);
                    int intDeadLine = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3010");
                    if (intDeadLine == -1)
                        intDeadLine = 7;

                    int intLeaveDay = (intDeadLine * 24 - objVO.m_intPassHour) / 24;
                    int intLeaveHour = (intDeadLine * 24 - objVO.m_intPassHour) % 24;

                    if (intLeaveDay < 0 || (intLeaveDay == 0 && intLeaveHour <= 0))
                    {
                        p_blnReadOnly = true;
                        return;
                    }

                    p_strTimeRemain = intLeaveDay.ToString() + "天" + intLeaveHour.ToString() + "小时";
                }
            }
        }


        /// <summary>
        /// 是否能打印当前页内容，与是否能显示病历内容一致
        /// </summary>
        protected bool m_blnCanPrint = false;
        /// <summary>
        /// 检查归档表，是否能显示病历内容
        /// </summary>
        /// <returns></returns>
        protected bool m_blnCanShowRecordContent()
        {
            bool blnCanShow = false;
            if (!m_blnReadOnly || com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_IntNeedRequestToSeeCase == 0)
            {
                blnCanShow = true;
            }
            else
            {
                int[] intStatusArr = null;
                long lngRes = new clsPublicDomain().m_lngGetSpecifyApproveInfo(SO::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR, m_objBaseCurrentPatient.m_StrRegisterId, out intStatusArr);
                if (intStatusArr != null && intStatusArr.Length > 0)
                {
                    for (int i1 = 0; i1 < intStatusArr.Length; i1++)
                    {
                        if (intStatusArr[i1] == 1)
                        {
                            blnCanShow = true;
                            break;
                        }
                    }
                }
                if (!blnCanShow)
                {
                    string strRoleID;
                    com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objServ =
                        (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));
                    lngRes = objServ.m_lngCheckRoleByEmpIDAndRoleName(SO::clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR, "病案室", out strRoleID);
                    if (!string.IsNullOrEmpty(strRoleID))
                    {
                        blnCanShow = true;
                    }
                }
            }
            m_blnCanPrint = blnCanShow;
            return blnCanShow;
        }

        /// <summary>
        /// 子窗体的添加操作。（注意，此操作不能被调用）
        /// </summary>
        /// <returns></returns>
        protected virtual long m_lngSubAddNew()
        {
            //			throw new Exception("没有实现 m_lngSubAddNew 函数");
            return 1;
        }

        /// <summary>
        /// 子窗体的修改操作。（注意，此操作不能被调用）
        /// </summary>
        /// <returns></returns>
        protected virtual long m_lngSubModify()
        {
            //			throw new Exception("没有实现 m_lngSubModify 函数");
            return 1;
        }

        /// <summary>
        /// 是否是添加新记录的操作。true，添加新记录；false,修改记录
        /// </summary>
        protected virtual bool m_BlnIsAddNew
        {
            get
            {
                //				throw new Exception("没有实现 m_BlnIsAddNew 函数");
                return true;
            }
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        /// <returns>操作结果</returns>
        public long m_lngDelete()
        {
            //			PrivilegeData.enmPrivilegeSF enmSF = m_enmGetPrivilegeSF();
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,enmSF,PrivilegeData.enmPrivilegeOperation.Delete))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return 0;
			}			
#endif
            //			if(m_objCurrentContext.m_ObjControl.m_enmDeleteCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,m_EnmCurrentFormState)
            //				== enmDBControlCheckResult.Disable)
            //			{
            //				clsPublicFunction.s_mthShowNotPermitMessage();
            //				return -1;
            //			}


            if (m_objBaseCurrentPatient == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择病人!");
                return -10;
            }
            ////验证删除
            //clsDeleteVerify objDeleteVerify = new clsDeleteVerify();
            //if (objDeleteVerify.m_mthIsDelete(null, null) == false)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("验证失败不能删除！");
            //    return -12;
            //}
            ////释放
            //objDeleteVerify = null;
            //if (m_objBaseCurrentPatient.m_StrHISInPatientID != txtInPatientID.Text)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("住院号与病人信息不一致，不能删除!");
            //    return -11;
            //}
            string strTimeRemaining;
            //bool blnReadOnly = false;
            //new clsInPatientArchivingDomain().lngIsReadOnly(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out blnReadOnly, out strTimeRemaining);
            if (m_blnReadOnly)
            {
                clsPublicFunction.ShowInformationMessageBox("此病人的所有病历为只读，不能删除!");
                return (long)enmOperationResult.Not_permission;
            }


            if (m_StrCurrentOpenDate == "" || m_StrCurrentOpenDate == null)
            {
                //clsPublicFunction.ShowInformationMessageBox("当前没有记录或记录本身为空");
                return -1;
            }
            if (!lngCanYouDoIt())
            {
                clsPublicFunction.ShowInformationMessageBox("该单已被上级审核过，您无权删除！");
                return -1;
            }

            if (!clsPublicFunction.s_blnAskForDelete())
                return -1;



            long lngRes = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lngRes = m_lngSubDelete();
                if (lngRes > 0)
                    chkModifyWithoutMatk.Checked = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return lngRes;

        }

        /// <summary>
        /// 子窗体的删除操作。（注意，此操作不能被调用）
        /// </summary>
        /// <returns></returns>
        protected virtual long m_lngSubDelete()
        {
            //			throw new Exception("没有实现 m_lngSubDelete 函数");
            return 1;
        }

        /// <summary>
        /// 打印操作
        /// </summary>
        /// <returns>操作结果</returns>
        public long m_lngPrint()
        {
            //			PrivilegeData.enmPrivilegeSF enmSF = m_enmGetPrivilegeSF();
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,enmSF,PrivilegeData.enmPrivilegeOperation.Print))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return 0;
			}			
#endif

            //			if(m_objCurrentContext.m_ObjControl.m_enmPrintCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,m_EnmCurrentFormState)
            //				== enmDBControlCheckResult.Disable)
            //			{
            //				clsPublicFunction.s_mthShowNotPermitMessage();
            //				return -1;
            //			}
            //			else
            //			{
            if (m_objBaseCurrentPatient != null && !m_blnCanPrint)
            {
                clsPublicFunction.ShowInformationMessageBox("此病人病历已归档，当前用户没有查看的权限，不能打印！");
                return 0;
            }

            if (!clsPublicFunction.m_blnCheckCanPrint(this.GetType().Namespace, this.Name, clsEMR_StaticObject.s_ObjCurrentEmployee.m_strRoleIDArr))
            {
                clsPublicFunction.ShowInformationMessageBox("当前登陆用户没有权限打印此单！");
                return 0;
            }

            this.Cursor = Cursors.WaitCursor;
            long lngRes = 0;
            if (m_dlgHandleSaveBeforePrint() != DialogResult.Cancel)
                lngRes = m_lngSubPrint();
            this.Cursor = Cursors.Default;

            return lngRes;
            //			}
        }

        /// <summary>
        /// 打印前提示保存
        /// </summary>
        protected virtual DialogResult m_dlgHandleSaveBeforePrint()
        {

            DialogResult dlgResult = DialogResult.None;
            if (!MDIParent.s_ObjSaveCue.m_blnCheckStatusSame(this))
            {
                dlgResult = clsPublicFunction.ShowQuestionMessageBox("[" + this.Text + "]做了改动，是否保存？", MessageBoxButtons.YesNoCancel);

                if (dlgResult == DialogResult.Yes)
                    m_lngSave();
            }
            return dlgResult;
        }

        /// <summary>
        /// 子窗体的打印操作。（注意，此操作不能被调用）
        /// </summary>
        /// <returns></returns>
        protected virtual long m_lngSubPrint()
        {
            //			throw new Exception("没有实现 m_lngSubPrint 函数");
            return 1;
        }
        #endregion

        #region Copy,Cut,Paste
        /// <summary>
        /// 复制操作
        /// </summary>
        /// <returns>操作结果</returns>
        public long m_lngCopy()
        {
            Control ctlControl = this.ActiveControl;
            string strTypeName = ctlControl.GetType().FullName;
            //			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
            //			{
            switch (strTypeName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    if (((ctlRichTextBox)ctlControl).Text != "")
                    {
                        ((ctlRichTextBox)ctlControl).Copy();
                        return 1;
                    }
                    break;

                case "com.digitalwave.controls.ctlRichTextBox":
                    if (((com.digitalwave.controls.ctlRichTextBox)ctlControl).Text != "")
                    {
                        ((com.digitalwave.controls.ctlRichTextBox)ctlControl).Copy();
                        return 1;
                    }
                    break;

                case "System.Windows.Forms.RichTextBox":
                case "iCare.CustomForm.ctlRichTextBox":
                case "com.digitalwave.Utility.Controls.ctlTemplateEditer":
                    if (((RichTextBox)ctlControl).Text != "")
                    {
                        ((RichTextBox)ctlControl).Copy();
                        return 1;
                    }
                    break;

                case "System.Windows.Forms.TextBox":
                    if (((TextBox)ctlControl).Text != "")
                    {
                        ((TextBox)ctlControl).Copy();
                        return 1;
                    }
                    break;

                case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                    if (((ctlBorderTextBox)ctlControl).Text != "")
                    {
                        ((ctlBorderTextBox)ctlControl).Copy();
                        return 1;
                    }
                    break;

                case "System.Windows.Forms.DataGridTextBox":
                    if (((DataGridTextBox)ctlControl).Text != "")
                    {
                        ((DataGridTextBox)ctlControl).Copy();
                        return 1;
                    }
                    break;

                default:
                    Clipboard.SetDataObject("");
                    break;
            }
            //			}

            return 0;
        }

        /// <summary>
        /// 剪切操作
        /// </summary>
        /// <returns>操作结果</returns>
        public long m_lngCut()
        {
            Control ctlControl = this.ActiveControl;
            string strTypeName = ctlControl.GetType().FullName;
            //			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
            //			{
            switch (strTypeName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    if (((ctlRichTextBox)ctlControl).Text != "")
                    {
                        ((ctlRichTextBox)ctlControl).m_mthCut();
                        return 1;
                    }
                    break;

                case "com.digitalwave.controls.ctlRichTextBox":
                    if (((com.digitalwave.controls.ctlRichTextBox)ctlControl).Text != "")
                    {
                        ((com.digitalwave.controls.ctlRichTextBox)ctlControl).Cut();
                        return 1;
                    }
                    break;

                case "System.Windows.Forms.RichTextBox":
                case "iCare.CustomForm.ctlRichTextBox":
                    if (((RichTextBox)ctlControl).Text != "")
                    {
                        ((RichTextBox)ctlControl).Cut();
                        return 1;
                    }
                    break;

                case "System.Windows.Forms.TextBox":
                    if (((TextBox)ctlControl).Text != "")
                    {
                        ((TextBox)ctlControl).Cut();
                        return 1;
                    }
                    break;

                case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                    if (((ctlBorderTextBox)ctlControl).Text != "")
                    {
                        ((ctlBorderTextBox)ctlControl).Cut();
                        return 1;
                    }
                    break;

                case "System.Windows.Forms.DataGridTextBox":
                    if (((DataGridTextBox)ctlControl).Text != "")
                    {
                        ((DataGridTextBox)ctlControl).Cut();
                        return 1;
                    }
                    break;
            }
            //			}

            return 0;
        }

        /// <summary>
        /// 粘贴操作
        /// </summary>
        /// <returns>操作结果</returns>
        public long m_lngPaste()
        {
            Control ctlControl = this.ActiveControl;
            string strTypeName = ctlControl.GetType().FullName;

            //			if(strTypeName == "ctlRichTextBox" || strTypeName == "RichTextBox" || strTypeName == "TextBox" || strTypeName == "ctlBorderTextBox" || strTypeName == "DataGridTextBox")
            //			{
            switch (strTypeName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    ((ctlRichTextBox)ctlControl).Paste();
                    return 1;

                case "com.digitalwave.controls.ctlRichTextBox":
                    ((TextBoxBase)ctlControl).Paste();
                    return 1;

                case "System.Windows.Forms.RichTextBox":
                case "iCare.CustomForm.ctlRichTextBox":
                    ((RichTextBox)ctlControl).Paste();
                    return 1;

                case "System.Windows.Forms.TextBox":
                    ((TextBox)ctlControl).Paste();
                    return 1;

                case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                    ((ctlBorderTextBox)ctlControl).Paste();
                    return 1;

                case "System.Windows.Forms.DataGridTextBox":
                    ((DataGridTextBox)ctlControl).Paste();
                    return 1;
            }
            //			}

            return 0;
        }
        #endregion

        protected virtual clsPatient[] m_objGetPatientByInPatientID()
        {
            return m_objCurrentContext.m_ObjPatientManager.m_objGetAllPatientLike(txtInPatientID.Text.Trim());
        }

        protected void m_mthAddRichTemplate(RichTextBox p_txtControl)
        {
            m_objTempTool.m_mthAddTextBox(this, p_txtControl, m_strGetCurFormName(), p_txtControl.Name);
        }

        protected virtual void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
        {
            //重置可用模板的控件的个数，避免多次选择表单后数组越界--wf20080109
            m_objTempTool.m_IntTemplateNumber = 0;
            m_mthSetRichTemplateInContainer(p_ctlContainer);
        }

        protected void m_mthSetRichTemplateInContainer(Control p_ctlContainer)
        {
            foreach (Control ctlChild in p_ctlContainer.Controls)
            {
                if ((ctlChild.Name == "" && ctlChild.GetType().FullName != "System.Windows.Forms.TabPage") || ctlChild.GetType().Name == "ctlTimePicker" || ctlChild.GetType().Name == "ctlPaintContainer" || ctlChild.GetType().Name == "DataGrid")
                    continue;
                switch (ctlChild.GetType().FullName)
                {
                    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                        m_mthAddRichTemplate((RichTextBox)ctlChild);
                        m_mthAddRichTextInfo((ctlRichTextBox)ctlChild);
                        break;
                    case "com.digitalwave.controls.ctlRichTextBox":
                        m_mthAddRichTemplate((RichTextBox)ctlChild);
                        m_mthAddRichTextInfo((com.digitalwave.controls.ctlRichTextBox)ctlChild);
                        break;
                    case "System.Windows.Forms.RichTextBox":
                    case "iCare.CustomForm.ctlRichTextBox":
                        m_mthAddRichTemplate((RichTextBox)ctlChild);
                        break;
                    case "com.digitalwave.Utility.Controls.ctlComboBox":
                    case "com.digitalwave.Controls.ctlComboBox":
                        m_mthAssociateComboBoxItemEvent(ctlChild);
                        break;
                    case "System.Windows.Forms.RadioButton":
                        ((System.Windows.Forms.RadioButton)ctlChild).MouseDown += new MouseEventHandler(m_mthrdb_MouseDown);
                        break;
                    default:
                        m_mthSetRichTemplateInContainer(ctlChild);
                        break;
                }
            }
        }

        private void m_mthPatientListControl(object sender, EventArgs e)
        {
            if ((!txtInPatientID.Focused) && (!m_lsvInPatientID.Focused))
            {
                m_lsvInPatientID.Visible = false;
            }
        }

        private void m_lsvPatientName_LostFocus(object sender, EventArgs e)
        {
            if (!m_lsvPatientName.Focused)
            {
                m_lsvPatientName.Visible = false;
            }
        }

        private void m_lsvBedNO_LostFocus(object sender, EventArgs e)
        {
            if (!m_lsvBedNO.Focused)
            {
                m_lsvBedNO.Visible = false;
            }
        }

        /// <summary>
        /// 查找病人，缺省查找所有病人，（可覆盖提供新的实现）。
        /// </summary>
        /// <returns></returns>
        protected virtual clsPatient[] m_objGetPatient()
        {
            if (m_cboDept.GetItemsCount() > 0 && m_cboArea.GetItemsCount() <= 0)
                return null;//广西版本暂时屏蔽住院号模糊查询
            if (m_cboArea.SelectedItem == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择病区!");
                return null;
            }
            return m_objCurrentContext.m_ObjPatientManager.m_objGetInPatientByAreaIDLike(((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID, txtInPatientID.Text);
            //return m_objCurrentContext.m_ObjPatientManager.m_objGetInPatientByDeptIDLike(MDIParent.s_ObjDepartment,txtInPatientID.Text);
        }

        /// <summary>
        /// 查找病人，却省查找所有病人，（可覆盖提供新的实现）。
        /// </summary>
        /// <returns></returns>
        protected virtual clsPatient[] m_objGetPatientByPatientName()
        {
            if (m_cboArea.SelectedItem == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择病区!");
                return null;
            }
            return m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikePatientName_InArea(((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID, m_txtPatientName.Text);
            //return m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikePatientName(MDIParent.s_ObjDepartment,m_txtPatientName.Text);
        }

        /// <summary>
        /// 是否查找所有床号，默认为否
        /// </summary>
        private bool m_blnGetAllBedNo = false;

        /// <summary>
        /// 查找病人，却省查找所有病人，（可覆盖提供新的实现）。
        /// </summary>
        /// <returns></returns>
        protected virtual clsPatient[] m_objGetPatientByBedNO()
        {
            //if (this.m_cboArea.SelectedItem != null)
            //{
            //    if (m_blnGetAllBedNo)
            //        return m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_InArea(((clsInPatientArea)(this.m_cboArea.SelectedItem)).m_strAreaNewID, "");

            //    else
            //        return m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_InArea(((clsInPatientArea)(this.m_cboArea.SelectedItem)).m_strAreaNewID, m_txtBedNO.Text);
            //}
            //else if (this.m_cboDept.SelectedItem != null)
            //{
            //    if (m_blnGetAllBedNo)
            //        return m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_NoArea(((clsDepartment)(this.m_cboDept.SelectedItem)).m_strDeptNewID, "");
            //    else
            //        return m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_NoArea(((clsDepartment)(this.m_cboDept.SelectedItem)).m_strDeptNewID, m_txtBedNO.Text);
            //}
            string strId = "";
            if (this.m_cboArea.SelectedItem != null)
                strId = ((clsInPatientArea)(this.m_cboArea.SelectedItem)).m_strAreaNewID;
            else if (this.m_cboDept.SelectedItem != null)
                strId = ((clsDepartment)(this.m_cboDept.SelectedItem)).m_strDeptNewID;
            com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objServ = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            clsEmrBed_VO[] objResultArr = null;
            long lngRes = 0;
            if (m_blnGetAllBedNo)
                lngRes = objServ.m_lngGetInBedInfo(strId, false, out objResultArr);
            else
                lngRes = objServ.m_lngGetBedInfoLikeBedCode(strId, false, m_txtBedNO.Text.Trim(), out objResultArr);
            if (lngRes > 0 && objResultArr != null)
            {
                clsPatient[] objPatientArr = new clsPatient[objResultArr.Length];
                for (int i = 0; i < objResultArr.Length; i++)
                    objPatientArr[i] = new clsPatient(objResultArr[i]);
                return objPatientArr;
            }
            return null;
        }

        private void m_lsvInPatientID_DoubleClick(object sender, System.EventArgs e)
        {
            if (m_lsvInPatientID.SelectedItems.Count <= 0)
                return;

            clsPatient objPatient = (clsPatient)m_lsvInPatientID.SelectedItems[0].Tag;
            #region 转换VO
            //更新com.digitalwave.BEDExplorer.frmHRPExplorer.objpCurrentPatient
            //因为只需要通过m_strINPATIENTID_CHR来构造旧的clspatient
            //过渡使用
            clsHospitalManagerDomain objMain = new clsHospitalManagerDomain();
            clsEmrInBedPatient_VO objPatientTemp;
            if (m_cboArea.Text.Trim().Length == 0)
                objMain.m_lngGetSpecialMinPatinetInfoByDeptID(objPatient.m_StrPatientID, out objPatientTemp);
            else
                objMain.m_lngGetSpecialMinPatinetInfo(objPatient.m_StrPatientID, out objPatientTemp);
            frmHRPExplorer.objpCurrentPatient = objPatientTemp;

            if (objPatient.m_strDeptNewID == null)
                objPatient.m_strDeptNewID = ((clsDepartment)m_cboDept.SelectedItem).m_strDeptNewID;
            clsEmrDept_VO objDeptNew;
            objMain.m_lngGetSpecialDeptInfo(objPatient.m_strDeptNewID, out objDeptNew);
            frmHRPExplorer.objpCurrentDepartment = objDeptNew;

            if (objPatient.m_strAreaNewID == null)
            {
                if (m_cboArea.GetItemsCount() > 0)
                {
                    objPatient.m_strAreaNewID = ((clsInPatientArea)m_cboArea.SelectedItem).m_strAreaNewID;
                }
                else
                    objPatient.m_strAreaNewID = "";
            }
            clsEmrDept_VO objAreNew;
            objMain.m_lngGetSpecialAreaInfo(objPatient.m_strAreaNewID, out objAreNew);
            frmHRPExplorer.objpCurrentArea = objAreNew;
            #endregion
            m_mthSetPatientInfo(objPatient);
            MDIParent.s_ObjCurrentPatient = objPatient;
            m_lsvInPatientID.Visible = false;
        }

        /// <summary>
        /// 设置完病人的所有信息后光标定位
        /// </summary>
        protected virtual void m_mthSetFocusAfterSetPatientInfo()
        {
            this.m_txtBedNO.Focus();
        }

        /// <summary>
        /// 设置病人的所有信息
        /// </summary>
        /// <param name="p_objSelectedPatient">病人</param>
        protected void m_mthSetPatientInfo(clsPatient p_objSelectedPatient)
        {
            string strTempBedCode = p_objSelectedPatient.m_strBedCode;
            if (p_objSelectedPatient == null /*|| p_objSelectedPatient.m_ObjPeopleInfo == null*/)
            {
                m_mthShowNoPatient();
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            clsPatient p_objSelectedPatient2;
            p_objSelectedPatient2 = p_objSelectedPatient;

            string strTempBedCode1 = p_objSelectedPatient2.m_strBedCode;
            m_objBaseCurrentPatient = p_objSelectedPatient;
            //数据检索时需要得到当前选择的入院时间，不能用最后的入院时间，除非未予赋值
            //			if(m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue)
            //				m_objBaseCurrentPatient.m_DtmSelectedInDate=m_objBaseCurrentPatient.m_DtmLastInDate;
            MDIParent.s_ObjCurrentPatient = m_objBaseCurrentPatient;
            //m_mthIsReadOnly();
            //m_mthSetPatientBaseInfo(p_objSelectedPatient);

            if (this.GetType().Name == "frmOutHospital" || this.GetType().Name == "frmDeathRecord" || this.GetType().Name == "frmDeathCaseDiscuss")
            {
                m_mthSetPatientInHospitalDate(p_objSelectedPatient);
            }

            //m_blnNeedCheckArchive = false;
            if (!(this is frmDiseaseTrackBase) && !(this is frmThreeMeasureRecordGN) && !(this is frmThreeMeasureRecord))
            {
                m_mthSetPatientFormInfo(p_objSelectedPatient2);//继承自frmDiseaseTrackBase的窗体在m_mthPerformSessionChanged内做此操作
            }
            //m_blnNeedCheckArchive = true;

            m_mthSetFocusAfterSetPatientInfo();

            if (m_objBaseCurrentPatient == null)//因为执行上面两个函数可能会改变当前值
                m_objBaseCurrentPatient = p_objSelectedPatient;

            m_blnPatientSelected = true;
            if (this.GetType().Name != "frmInPatientCaseHistoryArchiving")
            {
                string strTimeRemaing = null;
                bool blnIsReadOnly = false;
                if (m_objBaseCurrentPatient == null)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }
                //if (new clsInPatientArchivingDomain().lngIsReadOnly(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyy-MM-dd HH:mm:ss"), out blnIsReadOnly, out strTimeRemaing) <= 0)
                //{
                //    this.Cursor = Cursors.Default;
                //    return;
                //}
                //else
                //{
                //m_mthPromtForArchiving(blnIsReadOnly, strTimeRemaing);
                //}
            }
            this.Cursor = Cursors.Default;

            //当前处于新增记录状态（DataGrid形式的记录单不需要）
            if (!(this is frmRecordsBase) && !(this is frmDiseaseTrackBase))
                MDIParent.m_mthChangeFormText(this, m_enmFormEditStatus);

            m_mthAddFormStatusForClosingSave();

            if (p_objSelectedPatient.m_IntCharacter == 1)
            {
                m_mthSetIfCanSelectPatient(false);
            }
        }

        /// <summary>
        /// 归档提示
        /// </summary>
        /// <param name="p_blnIfReadOnly"></param>
        /// <param name="p_strTimeRemaing"></param>
        protected virtual void m_mthPromtForArchiving(bool p_blnIfReadOnly, string p_strTimeRemaing)
        {
            if (p_blnIfReadOnly)
            {
                //clsPublicFunction.ShowInformationMessageBox("此病人的所有病历为只读，不能修改。");
            }
            else if (p_strTimeRemaing != null && p_strTimeRemaing.Trim().Length != 0)
            {
                clsPublicFunction.ShowInformationMessageBox("此病人的所有病历在" + p_strTimeRemaing + "后将自动归档，若要修改请注意时间。");
            }
        }

        private MDIParent.enmFormEditStatus m_enmFormEditStatus = MDIParent.enmFormEditStatus.AddNew;
        protected MDIParent.enmFormEditStatus m_EnmFormEditStatus
        {
            set
            {
                m_enmFormEditStatus = value;
            }
        }

        /// <summary>
        /// 记录设置窗体当前状态，以在窗体关闭时有保存提示。如果不需要保存提示，重载该函数。
        /// </summary>
        protected virtual void m_mthAddFormStatusForClosingSave()
        {
            //记录设置窗体当前状态
            MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);
        }

        /// <summary>
        /// 如果记录内容改变，保存记录。
        /// </summary>
        protected void m_mthRecordChangedToSave()
        {
            //保存窗体记录
            MDIParent.s_ObjSaveCue.m_mthHandleRecordAfterSelect(this);
        }

        /// <summary>
        /// 设置病人的基本住院信息（可覆盖提供新的实现）
        /// </summary>
        /// <param name="p_objSelectedPatient">病人</param>
        protected virtual void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
        {
            if (p_objSelectedPatient.m_ObjPeopleInfo == null)
            {
                m_mthShowNoPatient();
                return;
            }
            string strTempBedCode = p_objSelectedPatient.m_strBedCode;
            //这个开关的作用是以防对m_cboArea赋值后触发其SelectedIndexChanged事件
            m_blnCanTextChanged = false;

            if (p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo != null)
            {
                if (p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo == null)
                    return;
                //清空
                m_cboDept.ClearItem();

                //获取科室
                string str1 = p_objSelectedPatient.m_strDeptNewID;
                string str2;
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO objDeptNew;
                objDomain.m_lngGetSpecialDeptInfo(str1, out objDeptNew);
                str1 = objDeptNew.m_strSHORTNO_CHR.Trim();
                str2 = objDeptNew.m_strDEPTNAME_VCHR.Trim();
                string str11 = objDeptNew.m_strDEPTID_CHR.Trim();
                clsDepartment objDeptTemp = new clsDepartment(str1, str2);
                //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                objDeptTemp.m_strDeptNewID = str11;
                m_cboDept.AddItem(objDeptTemp);
                m_cboDept.SelectedIndex = -1;
                m_cboDept.SelectedIndex = 0;

                //获取病区
                int intCount = m_cboArea.GetItemsCount();
                if (intCount > 0)
                {
                    for (int i = 0; i < intCount; i++)
                    {
                        if (((clsInPatientArea)m_cboArea.GetItem(i)).m_strAreaNewID == p_objSelectedPatient.m_strAreaNewID)
                        {
                            m_cboArea.SelectedIndex = i;
                            break;
                        }
                    }
                }
                //m_cboArea.ClearItem();
                //string str3 = p_objSelectedPatient.m_strAreaNewID;
                //if (str3 != null && str3.Trim().Length != 0)//病区不为空
                //{
                //    string str4;
                //    clsEmrDept_VO objAreNew;
                //    objDomain.m_lngGetSpecialAreaInfo(str3, out objAreNew);
                //    str3 = objAreNew.m_strSHORTNO_CHR;
                //    str4 = objAreNew.m_strDEPTNAME_VCHR;
                //    clsInPatientArea objInPatientArea = new clsInPatientArea(str3, str4, objAreNew.m_strDEPTID_CHR);
                //    //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                //    objInPatientArea.m_strAreaNewID = objAreNew.m_strDEPTID_CHR;
                //    m_cboArea.AddItem(objInPatientArea);
                //    m_cboArea.SelectedIndex = 0;
                //}


                m_txtBedNO.Text = p_objSelectedPatient.m_strBedCode;

                #region RegionName
                //m_cboArea.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
                //m_txtBedNO.Text=p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
                #endregion

            }
            else
            {
                m_txtBedNO.Text = "";
            }
            txtInPatientID.Text = p_objSelectedPatient.m_StrHISInPatientID;
            m_txtPatientName.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
            try
            {
                lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrSex.Trim();
                lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrAge.Trim();
                //lblSex.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrSex.Trim();
                //lblAge.Text = p_objSelectedPatient.m_ObjPeopleInfo.m_StrAge.Trim();

            }
            catch (Exception)
            {

                //throw;
            }
            lblAge.AutoSize = true;

            m_blnCanTextChanged = true;
        }

        /// <summary>
        /// 清空病人基本住院信息的界面（可覆盖提供新的实现）
        /// </summary>
        protected virtual void m_mthClearPatientBaseInfo()
        {
            m_blnCanTextChanged = false;

            txtInPatientID.Text = "";
            m_txtPatientName.Text = "";
            lblSex.Text = "";
            lblAge.Text = "";
            m_cboArea.Text = "";
            m_txtBedNO.Text = "";

            m_objBaseCurrentPatient = null;

            m_blnPatientSelected = false;

            m_blnCanTextChanged = true;
        }


        /// <summary>
        /// 设置病人表单信息，必须覆盖
        /// </summary>
        /// <param name="p_objSelectedPatient">病人</param>
        protected virtual void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            //			throw new Exception("没有实现 m_mthSetPatientFormInfo 函数");
        }
        /// <summary>
        /// 仅设置病人的基本信息，若病历需要显示病人的基本信息须覆盖
        /// </summary>
        /// <param name="p_objSelectedPatient">病人</param>
        protected virtual void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            //lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrSex.Trim();
            //lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrAge.Trim();
        }

        /// <summary>
        /// 是否有相关联模板
        /// </summary>
        protected bool m_blnHaveAssociateTemplate;

        /// <summary>
        /// 自动调用与病名关联的套装模板
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected void m_mthSetSpecialPatientTemplateSet(clsPatient p_objSelectedPatient)
        {
            if (p_objSelectedPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                m_mthShowNoPatient();
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            #region old

            //			clsTemplatesetContentValue[][] objArr;
            //				objArr = new clsTemplateDomain().m_lngGetSpecialPatientTemplateSet(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),this.Name,(int)enmAssociate.Disease);
            //
            //				if(objArr == null || objArr.Length <= 0)
            //				{
            //					m_blnHaveAssociateTemplate = false;
            //					this.Cursor = Cursors.Default;
            //					return;
            //				}
            //				else
            //				{
            //					m_blnHaveAssociateTemplate = true;
            //
            //					m_arlRTB.Clear();
            //					m_mthAddRichTextBox(this);
            //					RichTextBox[] RTBArr = (RichTextBox[])m_arlRTB.ToArray(typeof(RichTextBox));
            //
            //					for(int i=0;i<objArr.Length;i++)
            //					{
            //						#region 替换数据复用内容
            //						ArrayList arlTemp = new ArrayList();
            //						for(int i1=0;i1<objArr[i].Length;i1++)
            //							arlTemp.Add(objArr[i][i1].m_strContent);
            //						string[] strContentArr = (string[])arlTemp.ToArray(typeof(string));
            //						clsDataShareTool.s_mthReplaceDataShareValue(p_objSelectedPatient,strContentArr);
            //						#endregion
            //						for(int i1=0;i1<objArr[i].Length;i1++)
            //						{
            //							for(int j=0;j<RTBArr.Length;j++)
            //							{
            //								if(RTBArr[j]!=null && RTBArr[j].Name==objArr[i][i1].m_strControl_ID)
            //								{
            //									switch(RTBArr[j].GetType().Name)
            //									{
            //										case "RichTextBox":
            //											if(RTBArr[j].Text=="")
            //												RTBArr[j].Text = strContentArr[i1].TrimEnd();
            //											else 
            //												RTBArr[j].Text += "\r\n" + strContentArr[i1].TrimEnd();
            //											break;
            //										case "ctlRichTextBox":
            //											int intLength=((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).Text.Length ;
            //											if(RTBArr[j].Text=="")
            //												((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText (strContentArr[i1].TrimEnd(),intLength);
            //											else
            //												((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText ("\r\n" + strContentArr[i1].TrimEnd(),intLength);
            //											break;
            //									}
            //								}
            //							}
            //						}
            //					}
            //				}
            #endregion

            m_mthLoadAndShowTemplateSet(p_objSelectedPatient);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 自动调用与手术名称关联的套装模板
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected void m_mthSetSpecialPatientTemplateSet(clsPatient p_objSelectedPatient, enmAssociate p_enmType)
        {
            if (p_objSelectedPatient == null || p_objSelectedPatient.m_ObjPeopleInfo == null)
            {
                m_mthShowNoPatient();
                return;
            }
            this.Cursor = Cursors.WaitCursor;

            clsTemplatesetContentValue[][] objArr;
            try
            {
                objArr = new clsTemplateDomain().m_lngGetSpecialPatientTemplateSet(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), this.Name, (int)p_enmType);

                if (objArr == null || objArr.Length <= 0)
                {
                    m_blnHaveAssociateTemplate = false;
                    this.Cursor = Cursors.Default;
                    return;
                }
                else
                {
                    m_blnHaveAssociateTemplate = true;

                    m_arlRTB.Clear();
                    m_mthAddRichTextBox(this);
                    RichTextBox[] RTBArr = (RichTextBox[])m_arlRTB.ToArray(typeof(RichTextBox));

                    for (int i = 0; i < objArr.Length; i++)
                    {
                        #region 替换数据复用内容
                        ArrayList arlTemp = new ArrayList();
                        for (int i1 = 0; i1 < objArr[i].Length; i1++)
                            arlTemp.Add(objArr[i][i1].m_strContent);
                        string[] strContentArr = (string[])arlTemp.ToArray(typeof(string));
                        com.digitalwave.Emr.Utility.DataShare.clsDataShareReplace.s_mthReplaceDataShareValue(p_objSelectedPatient, ref strContentArr);
                        #endregion
                        for (int i1 = 0; i1 < objArr[i].Length; i1++)
                        {
                            for (int j = 0; j < RTBArr.Length; j++)
                            {
                                if (RTBArr[j] != null && RTBArr[j].Name == objArr[i][i1].m_strControl_ID)
                                {
                                    switch (RTBArr[j].GetType().FullName)
                                    {
                                        case "System.Windows.Forms.RichTextBox":
                                            if (RTBArr[j].Text == "")
                                                RTBArr[j].Text = strContentArr[i1].TrimEnd();
                                            else
                                                RTBArr[j].Text += "\r\n" + strContentArr[i1].TrimEnd();
                                            break;
                                        case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                                            int intLength = ((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).Text.Length;
                                            if (RTBArr[j].Text == "")
                                                ((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText(strContentArr[i1].TrimEnd(), intLength);
                                            else
                                                ((com.digitalwave.Utility.Controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText("\r\n" + strContentArr[i1].TrimEnd(), intLength);
                                            break;
                                        case "com.digitalwave.controls.ctlRichTextBox":
                                            int intLength1 = ((com.digitalwave.controls.ctlRichTextBox)RTBArr[j]).Text.Length;
                                            if (RTBArr[j].Text == "")
                                                ((com.digitalwave.controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText(strContentArr[i1].TrimEnd(), intLength1);
                                            else
                                                ((com.digitalwave.controls.ctlRichTextBox)RTBArr[j]).m_mthInsertText("\r\n" + strContentArr[i1].TrimEnd(), intLength1);
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    //					clsDataShareTool.s_mthSetDataShare(p_objSelectedPatient,RTBArr);

                }
            }
            catch
            {
            }

            this.Cursor = Cursors.Default;
        }

        private ArrayList m_arlRTB = new ArrayList();
        private void m_mthAddRichTextBox(Control p_ctl)
        {
            foreach (Control ctlSub in p_ctl.Controls)
            {
                switch (ctlSub.GetType().FullName)
                {
                    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                        m_arlRTB.Add(ctlSub);
                        break;
                    case "com.digitalwave.controls.ctlRichTextBox":
                        m_arlRTB.Add(ctlSub);
                        break;
                    case "System.Windows.Forms.RichTextBox":
                        m_arlRTB.Add(ctlSub);
                        break;
                }

                if (ctlSub.HasChildren)
                {
                    m_mthAddRichTextBox(ctlSub);
                }
            }

        }


        /// <summary>
        /// 设置病人入院日期，必须覆盖
        /// </summary>
        /// <param name="p_objSelectedPatient">病人</param>
        protected virtual void m_mthSetPatientInHospitalDate(clsPatient p_objSelectedPatient)
        {
            //			throw new Exception("没有实现 m_mthSetPatient 函数");
        }

        private void frmHRPBaseForm_Load(object sender, System.EventArgs e)
        {
            if (DesignMode || this.Site != null) return;
            try
            {
                m_lsvInPatientID.Visible = false;
                m_lsvPatientName.Visible = false;
                m_lsvBedNO.Visible = false;
                m_cmdNewTemplate.Visible = false;
                m_lsvInPatientID.BringToFront();
                m_lsvPatientName.BringToFront();
                m_lsvBedNO.BringToFront();

                m_objHighLight.m_mthAddControlInContainer(this);

                m_ctlAreaPatientSelection.Focus();
                //刘颖源增加，用于初始化模板控件
                //				m_objTempTool.m_mthInitTemplateControls (this);
                //if (m_blnNeedContextMenu)
                //    m_mthAddRichTemplateInContainer(this);
                //刘颖源增加，用于保存套装模板的支持，2003-9-10 12:35
                //m_frmSaveTemplateset = new frmTemplatesetDialog(this);

                m_cmdPre.Visible = false;
                m_lsvBedNO.Left = m_txtBedNO.Left;
                m_lsvBedNO.Top = m_txtBedNO.Bottom;

                //用于关联下拉框控件项目事件
                //				m_mthAssociateComboBoxItemEvent(this);

                m_mthInitJump(m_objJump);
            }
            catch
            {
                //				throw new Exception("HRPBaseForm Load Exception");
            }

        }

        /// <summary>
        /// 是否处理病人号内容改变事件，必须覆盖
        /// </summary>
        protected virtual bool m_BlnCanTextChanged
        {
            get
            {
                //throw new Exception("没有实现 m_BlnCanTextChanged 函数");
                return true;
            }
        }

        /// <summary>
        /// 设置到窗体病人
        /// </summary>
        /// <param name="p_objPatient">病人</param>
        public void m_mthSetPatient(clsPatient p_objPatient)
        {
            if (p_objPatient == null) return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (m_ctlAreaPatientSelection.m_BlnIsInUse)
                {
                    m_ctlAreaPatientSelection.m_mthSetPatient(p_objPatient.m_strAreaNewID, p_objPatient.m_StrPatientID, p_objPatient.m_StrRegisterId);
                    com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient = m_ctlAreaPatientSelection.CurrentBed.m_objInbedPatient;
                }
                else
                    m_mthSetPatientInfo(p_objPatient);
            }
            catch (Exception ex)
            {
                new com.digitalwave.Utility.clsLogText().LogDetailError(ex, false);
            }
            finally { this.Cursor = Cursors.Default; }
        }

        /// <summary>
        /// 显示数据库有误信息（可覆盖提供新的实现）
        /// </summary>
        protected virtual void m_mthShowDBError()
        {
            clsPublicFunction.ShowInformationMessageBox("对不起，数据库有误！");
        }

        /// <summary>
        /// 显示记录已被删除信息（可覆盖提供新的实现）
        /// </summary>
        protected virtual void m_mthShowRecordDeleted(string p_strDeleteUserID, string p_strDeleteTime)
        {
            if (p_strDeleteUserID == null || p_strDeleteUserID == "")
                return;
            if (p_strDeleteTime == null || p_strDeleteTime == "")
                return;
            string m_strDeleteTime;
            string m_strDeleteUserName;
            try
            {
                m_strDeleteUserName = new clsEmployee(p_strDeleteUserID).m_StrFirstName;
                m_strDeleteTime = DateTime.Parse(p_strDeleteTime).ToString("yyyy年MM月dd日 HH:mm:ss");
            }
            catch
            {
                return;
            }

            clsPublicFunction.ShowInformationMessageBox("对不起，该记录已被 " + m_strDeleteUserName + " 于 " + m_strDeleteTime + " 删除！");
        }

        /// <summary>
        /// 显示记录已被他人修改信息（可覆盖提供新的实现）
        /// </summary>
        protected virtual bool m_bolShowRecordModified(string p_strModifyUserID, string p_strModifyTime)
        {
            //			clsPublicFunction.ShowInformationMessageBox("对不起，该记录已被他人修改！");
            if (p_strModifyUserID == null || p_strModifyUserID == "")
                return false;
            if (p_strModifyTime == null || p_strModifyTime == "")
                return false;
            string m_strModifyTime;
            string m_strModifyUserName;
            try
            {
                m_strModifyUserName = new clsEmployee(p_strModifyUserID).m_StrFirstName;
                m_strModifyTime = DateTime.Parse(p_strModifyTime).ToString("yyyy年MM月dd日 HH:mm:ss");
            }
            catch
            {
                return false;
            }
            if (clsPublicFunction.ShowQuestionMessageBox("对不起，该记录已被 " + m_strModifyUserName + " 于 " + m_strModifyTime + " 修改，是否更新记录？") == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 显示记录已被他人生成信息（可覆盖提供新的实现）
        /// </summary>
        protected virtual void m_mthShowRecordTimeDouble()
        {
            clsPublicFunction.ShowInformationMessageBox("对不起，该时间已经被其他用户生成过记录，您若要修改，请关闭当前窗体，再重新打开！");
        }

        //		/// <summary>
        //		/// 提示是否修改此记录信息（可覆盖提供新的实现）
        //		/// </summary>
        //		protected virtual bool m_bolShowIfModify()
        //		{
        //			if(clsPublicFunction.ShowQuestionMessageBox("是否修改此记录信息？") == DialogResult.Yes)
        //			{
        //				return true;
        //			}
        //			else
        //			{
        //				return false;
        //			}
        //		}

        /// <summary>
        /// 提示没有该病人（可覆盖提供新的实现）
        /// </summary>
        protected virtual void m_mthShowNoPatient()
        {
            clsPublicFunction.ShowInformationMessageBox("对不起，没有此病人！");
        }

        /// <summary>
        /// 提示没有该病人（可覆盖提供新的实现）
        /// </summary>
        protected virtual void m_mthShowNotPermitted()
        {
            clsPublicFunction.ShowInformationMessageBox("对不起，您的权限不够！");
        }

        private readonly DateTime m_dtmEmptyDate = new DateTime(1900, 1, 1);

        protected void m_mthAddRichTextInfo(Control p_ctlTextBox)
        {
            if (p_ctlTextBox is com.digitalwave.Utility.Controls.ctlRichTextBox)
            {
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlTextBox).m_evtMouseEnterDeleteText += new EventHandler(m_mthHandleMouseEnterDeleteText);
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlTextBox).m_evtMouseEnterInsertText += new EventHandler(m_mthHandleMouseEnterInsertText);
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlTextBox).MouseLeave += new EventHandler(m_mthHandleMouseLeaveControl);
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlTextBox).m_IntCanModifyTime = clsEMR_StaticObject.s_IntCanModifyTime;
            }
            else if (p_ctlTextBox is com.digitalwave.controls.ctlRichTextBox)
            {
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlTextBox).m_evtMouseEnterDeleteText += new EventHandler(m_mthHandleMouseEnterDeleteText);
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlTextBox).m_evtMouseEnterInsertText += new EventHandler(m_mthHandleMouseEnterInsertText);
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlTextBox).MouseLeave += new EventHandler(m_mthHandleMouseLeaveControl);
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlTextBox).m_IntCanModifyTime = clsEMR_StaticObject.s_IntCanModifyTime;
            }

        }

        private void m_mthHandleMouseLeaveControl(object p_objSender, EventArgs p_objArg)
        {
            m_ttpTextInfo.RemoveAll();
        }

        private void m_mthHandleMouseEnterDeleteText(object p_objSender, EventArgs p_objArg)
        {
            string strName = "";
            DateTime dtmDeleteTime = DateTime.MinValue;
            if (p_objArg is com.digitalwave.Utility.Controls.clsDoubleStrikeThoughEventArg)
            {
                com.digitalwave.Utility.Controls.clsDoubleStrikeThoughEventArg objarg = p_objArg as com.digitalwave.Utility.Controls.clsDoubleStrikeThoughEventArg;
                strName = objarg.m_strUserName;
                dtmDeleteTime = objarg.m_dtmDeleteTime;
            }
            else if (p_objArg is com.digitalwave.controls.clsDoubleStrikeThoughEventArg)
            {
                com.digitalwave.controls.clsDoubleStrikeThoughEventArg objarg = p_objArg as com.digitalwave.controls.clsDoubleStrikeThoughEventArg;
                strName = objarg.m_strUserName;
                dtmDeleteTime = objarg.m_dtmDeleteTime;
            }
            //			clsDoubleStrikeThoughEventArg objArg = (clsDoubleStrikeThoughEventArg)p_objArg;

            string strInfo = "用户姓名 : " +
                strName + "\r\n删除时间 : ";

            if (dtmDeleteTime != m_dtmEmptyDate && dtmDeleteTime != DateTime.MinValue)
            {
                strInfo += dtmDeleteTime.ToLongDateString() + " " + dtmDeleteTime.ToLongTimeString();
            }
            else
            {
                strInfo += "----年--月--日 --:--:--";
            }

            m_ttpTextInfo.SetToolTip((Control)p_objSender, strInfo);
        }

        private void m_mthHandleMouseEnterInsertText(object p_objSender, EventArgs p_objArg)
        {
            //			com.digitalwave.Utility.Controls.clsInsertEventArg objArg = (com.digitalwave.Utility.Controls.clsInsertEventArg)p_objArg;

            string strName = "";
            DateTime dtmInsertTime = DateTime.MinValue;
            int intUserSeq = -1;
            if (p_objArg is com.digitalwave.Utility.Controls.clsInsertEventArg)
            {
                com.digitalwave.Utility.Controls.clsInsertEventArg objarg = p_objArg as com.digitalwave.Utility.Controls.clsInsertEventArg;
                strName = objarg.m_strUserName;
                dtmInsertTime = objarg.m_dtmInsertTime;
                intUserSeq = objarg.m_intUserSeq;
            }
            else if (p_objArg is com.digitalwave.controls.clsInsertEventArg)
            {
                com.digitalwave.controls.clsInsertEventArg objarg = p_objArg as com.digitalwave.controls.clsInsertEventArg;
                strName = objarg.m_strUserName;
                dtmInsertTime = objarg.m_dtmInsertTime;
                intUserSeq = objarg.m_intUserSeq;
            }

            if (intUserSeq == 1)
            {
                return;
            }

            string strInfo = "用户姓名 : " +
                strName + "\r\n添加时间 : ";

            if (dtmInsertTime != m_dtmEmptyDate && dtmInsertTime != DateTime.MinValue)
            {
                strInfo += dtmInsertTime.ToLongDateString() + " " + dtmInsertTime.ToLongTimeString();
            }
            else
            {
                strInfo += "----年--月--日 --:--:--";
            }

            m_ttpTextInfo.SetToolTip((Control)p_objSender, strInfo);
        }

        private void frmHRPBaseForm_Click(object sender, System.EventArgs e)
        {
            m_mthSetCanScroll();
        }

        /// <summary>
        /// 使窗体可以滚动
        /// </summary>
        protected void m_mthSetCanScroll()
        {
            //			m_lblForTitle.Focus();
            //			txtInPatientID.Focus();
            //			txtInPatientID.SelectionLength = 0;
        }

        /// <summary>
        /// 2003.4.11 Liu RongGuo  ---获取路径
        /// </summary>
        /// <returns></returns>
        public string m_strGetFilePathHeader()
        {
            string[] strFilePathAll = Application.ExecutablePath.Split('\\');
            string strFilePathHeader = "";
            if (strFilePathAll != null)
                for (int i = 0; i < strFilePathAll.Length - 3; i++)
                    strFilePathHeader += strFilePathAll[i] + "\\\\";
            return strFilePathHeader;
        }

        /// <summary>
        /// 得到当前要查找的病人住院号
        /// </summary>
        public void m_mthGetInPatientIDArr()
        {
            if (txtInPatientID.Text == "")
            {
                m_lsvInPatientID.Visible = false;
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            //clsPatient [] objPatientArr = m_objGetPatient();

            #region 麻醉系统添加
            clsPatient[] objPatientArr = null;
            if (m_blnSetGetPatientByDept)
                objPatientArr = m_objGetPatient();
            else
                objPatientArr = m_objGetPatientByInPatientID();
            #endregion 麻醉系统添加


            m_lsvInPatientID.Items.Clear();

            if (objPatientArr == null || objPatientArr.Length == 0)
            {
                this.Cursor = Cursors.Default;
                m_lsvInPatientID.Visible = false;
                //				m_mthClearAllInfo(this);//清空除当前控件以外的所有窗体内容.
                //				m_mthShowNoPatient();
                return;
            }

            for (int i = 0; i < objPatientArr.Length; i++)
            {
                ListViewItem lviPatient = new ListViewItem(
                    new string[]{
									objPatientArr[i].m_StrInPatientID,
				});
                lviPatient.Tag = objPatientArr[i];

                m_lsvInPatientID.Items.Add(lviPatient);
            }

            m_mthChangeListViewLastColumnWidth(m_lsvInPatientID);
            m_lsvInPatientID.Visible = true;

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 得到当前要查找的病人姓名
        /// </summary>
        private void m_mthGetPatientNameArr()
        {
            if (m_txtPatientName.Text == "")
            {
                m_lsvPatientName.Visible = false;
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            clsPatient[] objPatientArr = m_objGetPatientByPatientName();

            m_lsvPatientName.Items.Clear();

            if (objPatientArr == null || objPatientArr.Length == 0)
            {
                this.Cursor = Cursors.Default;
                m_lsvPatientName.Visible = false;
                m_mthClearAllInfo(this);//清空除当前控件以外的所有窗体内容.
                m_mthShowNoPatient();
                return;
            }

            for (int i = 0; i < objPatientArr.Length; i++)
            {
                ListViewItem lviPatient = new ListViewItem(
                    new string[]{
									objPatientArr[i].m_StrName,
				});
                lviPatient.Tag = objPatientArr[i];

                m_lsvPatientName.Items.Add(lviPatient);
            }

            m_mthChangeListViewLastColumnWidth(m_lsvPatientName);
            m_lsvPatientName.Visible = true;

            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 得到当前要查找的病人床号
        /// </summary>
        private void m_mthGetBedNOArr()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsPatient[] objPatientArr = m_objGetPatientByBedNO();

                m_lsvBedNO.Items.Clear();

                if (objPatientArr == null || objPatientArr.Length == 0)
                {
                    this.Cursor = Cursors.Default;
                    m_lsvBedNO.Visible = false;
                    //m_mthClearAllInfo(this);
                    m_mthClearAllInfo(this);//清空除当前控件以外的所有窗体内容.
                    m_mthShowNoPatient();
                    return;
                }

                //不论输入ID还是Name,显示为按照Name查找				
                for (int i = 0; i < objPatientArr.Length; i++)
                {
                    ListViewItem lviPatient = new ListViewItem(
                        new string[]{
										objPatientArr[i].m_strBedCode
									});
                    lviPatient.Tag = objPatientArr[i];

                    m_lsvBedNO.Items.Add(lviPatient);
                }

                m_mthChangeListViewLastColumnWidth(m_lsvBedNO);

                m_lsvBedNO.Visible = true;

            }
            catch (Exception exp)
            {
                string strError = exp.Message;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }






        }

        /// <summary>
        /// 当显示的行数大于6时，减小最后一列的宽度，以显示滚动条,Jacky-2003-7-21
        /// </summary>
        /// <param name="p_lsvControl"></param>
        public void m_mthChangeListViewLastColumnWidth(ListView p_lsvControl)
        {
            clsPublicFunction.s_mthChangeListViewLastColumnWidth(p_lsvControl);
        }

        public void m_mthChangeListViewLastColumnWidth(ListView p_lsvControl, int p_intRows)
        {
            clsPublicFunction.s_mthChangeListViewLastColumnWidth(p_lsvControl, p_intRows);
        }

        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {// enter	//Arrow Up //Arrow Down	
                case 13:// enter	

                    if (((Control)sender).Name == "txtInPatientID")
                    {
                        if (!txtInPatientID.ReadOnly)
                        {
                            m_mthGetInPatientIDArr();
                            if (m_lsvInPatientID.Items.Count == 1 && txtInPatientID.Text.Length == 7)
                            {
                                //								m_lsvInPatientID.Items[0].Selected=true;
                                //								m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);
                                //								m_lsvInPatientID.Visible = false;
                                break;
                            }
                        }
                    }
                    else if (((Control)sender).Name == "m_lsvInPatientID")
                    {
                        if (m_lsvInPatientID.SelectedItems.Count == 1)
                        {
                            //							m_mthSetPatientInfo((clsPatient)m_lsvInPatientID.SelectedItems[0].Tag);
                            //							m_lsvInPatientID.Visible = false;
                            m_lsvInPatientID_DoubleClick(null, null);
                            break;
                        }
                    }

//					else if( ((Control)sender).Name=="m_txtPatientName")
                    //					{
                    //						if(!m_txtPatientName.ReadOnly)
                    //						{
                    //							m_mthGetPatientNameArr();
                    //							if(m_lsvPatientName.Items.Count==1 && m_txtPatientName.Text==m_lsvPatientName.Items[0].SubItems[0].Text)
                    //							{
                    //								m_lsvPatientName.Items[0].Selected=true;
                    //								m_mthSetPatientInfo((clsPatient)m_lsvPatientName.SelectedItems[0].Tag);
                    //								m_lsvPatientName.Visible = false;
                    //								break;
                    //							}
                    //						}
                    //					}
                    else if (((Control)sender).Name == "m_lsvPatientName")
                    {
                        if (m_lsvPatientName.SelectedItems.Count == 1)
                        {
                            m_mthSetPatientInfo((clsPatient)m_lsvPatientName.SelectedItems[0].Tag);
                            m_lsvPatientName.Visible = false;
                            break;
                        }
                    }

                    else if (((Control)sender).Name == "m_txtBedNO")
                    {
                        //if (!m_txtBedNO.ReadOnly)
                        //{
                        //m_mthGetBedNOArr();
                        //    if (m_lsvBedNO.Items.Count == 1 && m_txtBedNO.Text == m_lsvBedNO.Items[0].SubItems[0].Text)
                        //    {
                        //        m_lsvBedNO.Items[0].Selected = true;
                        //        m_lsvBedNO_DoubleClick(null, null);
                        //        //m_mthSetPatientInfo((clsPatient)m_lsvBedNO.SelectedItems[0].Tag);
                        //        m_lsvBedNO.Visible = false;
                        //    }
                        //}
                    }
                    else if (((Control)sender).Name == "m_lsvBedNO")
                    {
                        if (m_lsvBedNO.SelectedItems.Count == 1)
                        {
                            //m_mthSetPatientInfo((clsPatient)m_lsvBedNO.SelectedItems[0].Tag);
                            m_lsvBedNO.Items[0].Selected = true;
                            m_lsvBedNO_DoubleClick(null, null);
                            m_lsvBedNO.Visible = false;
                            break;
                        }
                    }

                    break;

                case 38://Arrow Up
                    if (((Control)sender).Name == "m_lsvInPatientID")
                    {
                        if (m_lsvInPatientID.Items.Count > 0 && m_lsvInPatientID.Items[0].Selected)
                            txtInPatientID.Focus();
                    }
                    else if (((Control)sender).Name == "m_lsvPatientName")
                    {
                        if (m_lsvPatientName.Items.Count > 0 && m_lsvPatientName.Items[0].Selected)
                            m_txtPatientName.Focus();
                    }
                    else if (((Control)sender).Name == "m_lsvBedNO")
                    {
                        if (m_lsvBedNO.Items.Count > 0 && m_lsvBedNO.Items[0].Selected)
                            m_txtBedNO.Focus();
                    }
                    break;
                case 40://Arrow Down				
                    if (((Control)sender).Name == "txtInPatientID")
                    {
                        m_mthGetInPatientIDArr();
                        //m_lsvInPatientID.Visible=true;						
                        if (m_lsvInPatientID.Visible && m_lsvInPatientID.Items.Count > 0)
                        {
                            m_lsvInPatientID.Focus();
                            m_lsvInPatientID.Items[0].Selected = true;
                            m_lsvInPatientID.Items[0].Focused = true;
                        }

                    }

//					else if( ((Control)sender).Name=="m_txtPatientName")
                    //					{
                    //						m_mthGetPatientNameArr();
                    //						//m_lsvPatientName.Visible=true;						
                    //						if( m_lsvPatientName.Items.Count>0)
                    //						{
                    //							m_lsvPatientName.Focus();
                    //							m_lsvPatientName.Items[0].Selected=true;
                    //							m_lsvPatientName.Items[0].Focused=true;
                    //						}						
                    //					}
                    else if (((Control)sender).Name == "m_txtBedNO")
                    {
                        m_mthGetBedNOArr();
                        //m_lsvBedNO.Visible=true;						
                        if (m_lsvBedNO.Items.Count > 0)
                        {
                            m_lsvBedNO.Focus();
                            m_lsvBedNO.Items[0].Selected = true;
                            m_lsvBedNO.Items[0].Focused = true;
                        }
                    }
                    break;
            }
        }

        private void m_lsvBedNO_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (m_lsvBedNO.SelectedItems.Count <= 0)
                    return;

                if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
                    return;

                if (m_blnCheckRecordBase(this))
                    return;

                clsPatient objPatient = (clsPatient)m_lsvBedNO.SelectedItems[0].Tag;

                string strTemp = objPatient.m_StrPatientID;
                string strTempDeptID = objPatient.m_strDeptNewID;
                string strTempAreaID = objPatient.m_strAreaNewID;
                string strBedCode = objPatient.m_strBedCode;

                if (m_blnCheckSamePatientForm(objPatient.m_StrInPatientID))
                    return;

                #region 转换VO
                //更新com.digitalwave.BEDExplorer.frmHRPExplorer.objpCurrentPatient
                //因为只需要通过m_strINPATIENTID_CHR来构造旧的clspatient
                //过渡使用
                clsHospitalManagerDomain objMain = new clsHospitalManagerDomain();
                clsEmrInBedPatient_VO objPatientTemp;
                if (m_cboArea.Text.Trim().Length == 0)
                    objMain.m_lngGetSpecialMinPatinetInfoByDeptID(strTemp, out objPatientTemp);
                else
                    objMain.m_lngGetSpecialMinPatinetInfo(strTemp, out objPatientTemp);
                frmHRPExplorer.objpCurrentPatient = objPatientTemp;

                clsEmrDept_VO objDeptNew;
                objMain.m_lngGetSpecialDeptInfo(strTempDeptID, out objDeptNew);
                frmHRPExplorer.objpCurrentDepartment = objDeptNew;

                clsEmrDept_VO objAreNew;
                objMain.m_lngGetSpecialAreaInfo(strTempAreaID, out objAreNew);
                frmHRPExplorer.objpCurrentArea = objAreNew;
                #endregion

                m_mthSetPatientInfo(objPatient);
                //MDIParent.s_ObjCurrentPatient = objPatient;


                m_lsvBedNO.Visible = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void m_lsvPatientName_DoubleClick(object sender, System.EventArgs e)
        {
            try
            {
                if (m_lsvPatientName.SelectedItems.Count <= 0)
                    return;

                m_mthSetPatientInfo((clsPatient)m_lsvPatientName.SelectedItems[0].Tag);
                m_lsvPatientName.Visible = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        /// <summary>
        /// 清空除当前控件以外的所有窗体内容,(可覆盖提供新的实现)
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_blnReadOnly"></param>
        protected virtual void m_mthClearAllInfo(Control p_ctlControl)
        {
            try
            {
                string strTypeName = p_ctlControl.GetType().Name;
                if (strTypeName == "ctlRichTextBox")
                {
                    if (p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
                        ((iCare.CustomForm.ctlRichTextBox)p_ctlControl).Text = "";
                    else if (p_ctlControl is com.digitalwave.Utility.Controls.ctlRichTextBox)
                        ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
                    else if (p_ctlControl is com.digitalwave.controls.ctlRichTextBox)
                        ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
                }
                else if (strTypeName == "ctlBorderTextBox" && p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtPatientName" && p_ctlControl.Name != "m_txtBedNO")
                    ((ctlBorderTextBox)p_ctlControl).Text = "";
                else if (strTypeName == "TreeView")
                {
                    if (((TreeView)p_ctlControl).Nodes.Count > 0)
                        ((TreeView)p_ctlControl).Nodes[0].Nodes.Clear();
                }
                else if (strTypeName == "ListView")
                    ((ListView)p_ctlControl).Items.Clear();
                else if (strTypeName == "DateTimePicker")
                    ((DateTimePicker)p_ctlControl).Value = DateTime.Now;

                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlTimePicker")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        m_mthClearAllInfo(subcontrol);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        /// <summary>
        /// 设置窗体中控件的只读属性,
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_blnReadOnly"></param>
        protected virtual void m_mthSetControlReadOnly(Control p_ctlControl, bool p_blnReadOnly)
        {
            #region 设置窗体中控件的只读属性,Jacky-2003-6-11
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
            {
                if (p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
                    ((iCare.CustomForm.ctlRichTextBox)p_ctlControl).ReadOnly = p_blnReadOnly;
                else if (p_ctlControl is com.digitalwave.Utility.Controls.ctlRichTextBox)
                    ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_BlnReadOnly = p_blnReadOnly;
                else if (p_ctlControl is com.digitalwave.controls.ctlRichTextBox)
                    ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnReadOnly = p_blnReadOnly;
            }
            else if (strTypeName == "ctlBorderTextBox" && p_ctlControl.Name != "txtInPatientID" && p_ctlControl.Name != "m_txtBedNO" && p_ctlControl.Name != "m_txtPatientName")
                ((ctlBorderTextBox)p_ctlControl).ReadOnly = p_blnReadOnly;
            else if (strTypeName == "RichTextBox")
                ((RichTextBox)p_ctlControl).ReadOnly = p_blnReadOnly;
            else if (strTypeName == "DataGrid")
                ((DataGrid)p_ctlControl).ReadOnly = p_blnReadOnly;
            else if (strTypeName == "CheckBox" || strTypeName == "RadioButton")
                p_ctlControl.Enabled = !p_blnReadOnly;
            else if (strTypeName == "ctlComboBox" && p_ctlControl.Name != "m_cboDept" && p_ctlControl.Name != "m_cboArea")
                ((ctlComboBox)p_ctlControl).Enabled = !p_blnReadOnly;

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetControlReadOnly(subcontrol, p_blnReadOnly);
                }
            }
            #endregion
        }

        private void m_cboArea_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            MDIParent.s_ObjCurrInPatientArea = (clsInPatientArea)m_cboArea.SelectedItem;
            m_mthSetOutPatientRevisitList();
        }
        protected virtual void m_mthSetOutPatientRevisitList()
        {
        }

        private void m_mthClearPatientBaseInfoButArea()
        {
            m_blnCanTextChanged = false;

            //txtInPatientID.Text = "";
            //m_txtPatientName.Text = "";
            //lblSex.Text = "";
            //lblAge.Text = "";
            //m_txtBedNO.Text = "";

            m_objBaseCurrentPatient = null;

            m_blnPatientSelected = false;

            m_blnCanTextChanged = true;
        }

        private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            try
            {
                m_objTemplateClient = null;
                this.Cursor = Cursors.WaitCursor;
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO[] objAreaInfoArr = null;
                long lngRes = objDomain.m_lngGetAreaInfo(((clsDepartment)(m_cboDept.SelectedItem)).m_strDeptNewID, out objAreaInfoArr);
                if (objAreaInfoArr != null)
                {
                    m_cboArea.ClearItem();
                    clsInPatientArea objSelect = null;
                    for (int i = 0; i < objAreaInfoArr.Length; i++)
                    {
                        //转换为旧的
                        clsInPatientArea objAreaTemp = new clsInPatientArea(objAreaInfoArr[i].m_strSHORTNO_CHR, objAreaInfoArr[i].m_strDEPTNAME_VCHR, objAreaInfoArr[i].m_strDEPTID_CHR);
                        //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                        objAreaTemp.m_strAreaNewID = objAreaInfoArr[i].m_strDEPTID_CHR;
                        m_cboArea.AddItem(objAreaTemp);
                        if (i == 0)
                            objSelect = objAreaTemp;
                    }
                    m_cboArea.SelectedItem = objSelect;
                }

                MDIParent.s_ObjCurrDepartment = (clsDepartment)m_cboDept.SelectedItem;
                //			if(m_cboDept.GetItemsCount()>0)
                //			{
                //				com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment=(clsEmrDept_VO)m_cboDept.SelectedItem;
                //			}
                if (m_cboArea.GetItemsCount() > 0)
                {
                    //com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea=(clsEmrDept_VO)m_cboArea.SelectedItem;
                    MDIParent.s_ObjCurrInPatientArea = (clsInPatientArea)m_cboArea.SelectedItem;
                }


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }

        protected bool m_blnCheckEmployeeSign(string p_strEmployeeID, string p_strEmployeeName)
        {
            //暂不用员工签名验证
            return true;


            //			frmCheckSign objCheck = new frmCheckSign(p_strEmployeeID,p_strEmployeeName);
            //
            //			objCheck.ShowDialog(this);
            //
            //			if(objCheck.m_LngRes > 0 && objCheck.m_BlnIsPass)
            //			{
            //				return true;
            //			}
            //			else if(objCheck.m_LngRes > 0 && !objCheck.m_BlnIsPass)
            //			{
            //				clsPublicFunction.ShowInformationMessageBox("验证失败，该员工不能签名。");
            //				return false;
            //			}
            //			else
            //			{
            //				return false;
            //			}
        }

        #region 审核
        public long m_lngApprove()
        {
            #region old
            //			if(!m_BlnCanApprove || m_StrCurrentOpenDate=="")
            //				return 1;
            //			
            //			string strFormID = ((int)m_enmGetPrivilegeSF()).ToString();
            //
            //			long lngEff=0;
            //			lngEff = new clsApprove_FlowDomain().lngApproveDocument(clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrEmployeeID,strFormID,m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),m_StrCurrentOpenDate,((clsDepartment)this.m_cboDept.SelectedItem).m_StrDeptID,ref lngEff);
            //			
            //			#region 根据结果做不同的处理
            //			switch((enmApproveResult)lngEff)
            //			{
            //				case enmApproveResult.DB_Succeed:					
            //					clsPublicFunction.ShowInformationMessageBox("审核成功!");
            //					break;
            //				case enmApproveResult.System_Not_Define:					
            //					clsPublicFunction.ShowInformationMessageBox("系统没有定义该单的审核流程（应该在数据库中定义）!");
            //					break;
            //				case enmApproveResult.Document_Has_Been_Finished:					
            //					clsPublicFunction.ShowInformationMessageBox("此单已经经过终审，不能再往下审核!");
            //					break;
            //				case enmApproveResult.No_Purview:					
            //					clsPublicFunction.ShowInformationMessageBox("对不起，您的权限不够，无权审核此单!");
            //					break;
            //				case enmApproveResult.EmployeeID_Error:					
            //					clsPublicFunction.ShowInformationMessageBox("员工号错误!");
            //					break;
            //				case enmApproveResult.Not_Found_Approve_Info:					
            //					clsPublicFunction.ShowInformationMessageBox("对不起，退审必须首先被审核过。\n此单目前并没有被审核过!");
            //					break;
            //				case enmApproveResult.Is_Top_Level:					
            //					clsPublicFunction.ShowInformationMessageBox("已经退回到最上一级!");
            //					break;
            //				case enmApproveResult.Document_Has_Been_Deleted:					
            //					clsPublicFunction.ShowInformationMessageBox("该单已经删除!");
            //					break;
            //				default:
            //					break;
            //			}
            //			#endregion 根据结果做不同的处理
            //
            //			return 1;
            #endregion old

            string strCurrUserID = MDIParent.OperatorID; //当前用户
            string strCreateUserID = m_StrRecorder_ID; //表单建立用户

            string strCurrUserLevel = ""; //当前用户审核级别
            string strCreateUserLevel = ""; //表单建立用户审核级别
            string StrCurrentOpenDate = "";//当前记录创建时间

            int intCurrAppNo = 0;

            if (m_EnmAppType == enmApproveType.none)
                return -1;
            new clsApprove_FlowDomain().m_mthGetUserLevel(strCurrUserID, ref strCurrUserLevel, m_EnmAppType);
            new clsApprove_FlowDomain().m_mthGetUserLevel(m_StrRecorder_ID, ref strCreateUserLevel, m_EnmAppType);
            StrCurrentOpenDate = m_StrCurrentOpenDate;
            if (StrCurrentOpenDate.Trim().Length == 0)
                return -1;
            if (new clsApprove_FlowDomain().m_blnCanAuditing(Name, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString(), StrCurrentOpenDate, strCurrUserLevel, strCreateUserLevel, ref intCurrAppNo, true) == 1)
            {
                new clsApprove_FlowDomain().m_mthExecAuditing(Name, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString(), StrCurrentOpenDate, strCurrUserLevel);
                clsPublicFunction.ShowInformationMessageBox("审核成功!");
            }
            else
            {
                MessageBox.Show("不能审核此单！", "提示");
                return -1;
            }

            return 1;

            //			else if(m_EnmAppType=enmApproveType.CaseHistory)
            //			{
            //				m_mthGetUserLevel(strCurrUserID,strCurrUserLevel,1);
            //				m_mthGetUserLevel(m_StrRecorder_ID,strCreateUserLevel,1);
            //				if(m_blnCanAuditing(Name,1,MDIParent.s_ObjCurrentPatient.m_StrInPatientID,MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate,m_StrCurrentOpenDate,strCurrUserLevel,strCreateUserLevel))
            //				{
            //					m_mthExecAuditing(Name,MDIParent.s_ObjCurrentPatient.m_StrInPatientID,MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate,m_StrCurrentOpenDate,strCurrUserLevel);
            //				}
            //				else
            //				{
            //					MessageBox.Show ("没有审核权限！","提示");
            //					return -1;
            //				}
            //			}
            //			else if(m_EnmAppType=enmApproveType.Nurses)
            //			{
            //				m_mthGetUserLevel(strCurrUserID,strCurrUserLevel,2);
            //				m_mthGetUserLevel(m_StrRecorder_ID,strCreateUserLevel,2);
            //				if(m_blnCanAuditing(Name,2,MDIParent.s_ObjCurrentPatient.m_StrInPatientID,MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate,m_StrCurrentOpenDate,strCurrUserLevel,strCreateUserLevel))
            //				{
            //					m_mthExecAuditing(Name,MDIParent.s_ObjCurrentPatient.m_StrInPatientID,MDIParent.s_ObjCurrentPatient.m_DtmSelectedInDate,m_StrCurrentOpenDate,strCurrUserLevel);
            //				}
            //				else
            //				{
            //					MessageBox.Show ("没有审核权限！","提示");
            //					return -1;
            //				}
            //			}
        }

        public long m_lngUnApprove()
        {
            #region old
            //			if(!m_BlnCanApprove || m_StrCurrentOpenDate=="")
            //				return 1;
            //
            //			string strFormID = ((int)m_enmGetPrivilegeSF()).ToString();
            //
            //			long lngEff=0;
            //			lngEff = new clsApprove_FlowDomain().lngUntreadDocumentOneLevel(clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrEmployeeID,strFormID,m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),m_StrCurrentOpenDate,((clsDepartment)this.m_cboDept.SelectedItem).m_StrDeptID,ref lngEff);
            //			
            //			#region 根据结果做不同的处理
            //			switch((enmApproveResult)lngEff)
            //			{
            //				case enmApproveResult.DB_Succeed:					
            //					clsPublicFunction.ShowInformationMessageBox("退审成功!");
            //					break;
            //				case enmApproveResult.System_Not_Define:					
            //					clsPublicFunction.ShowInformationMessageBox("系统没有定义该单的审核流程（应该在数据库中定义）!");
            //					break;
            //				case enmApproveResult.Document_Has_Been_Finished:					
            //					clsPublicFunction.ShowInformationMessageBox("单已经经过终审，不能再往下审核!");
            //					break;
            //				case enmApproveResult.No_Purview:					
            //					clsPublicFunction.ShowInformationMessageBox("对不起，您的权限不够，无权审核此单!");
            //					break;
            //				case enmApproveResult.EmployeeID_Error:					
            //					clsPublicFunction.ShowInformationMessageBox("员工号错误!");
            //					break;
            //				case enmApproveResult.Not_Found_Approve_Info:					
            //					clsPublicFunction.ShowInformationMessageBox("对不起，退审必须首先被审核过。\n此单目前并没有被审核过!");
            //					break;
            //				case enmApproveResult.Is_Top_Level:					
            //					clsPublicFunction.ShowInformationMessageBox("已经退回到最上一级!");
            //					break;
            //				case enmApproveResult.Document_Has_Been_Deleted:					
            //					clsPublicFunction.ShowInformationMessageBox("该单已经删除!");
            //					break;
            //				default:
            //					break;
            //			}
            //			#endregion 根据结果做不同的处理
            //
            //			return 1;
            #endregion old
            string strCurrUserID = MDIParent.OperatorID; //当前用户
            string strCreateUserID = m_StrRecorder_ID; //表单建立用户

            string strCurrUserLevel = ""; //当前用户审核级别
            string strCreateUserLevel = ""; //表单建立用户审核级别
            int intCurrAppNo = 0;
            long lngRet;

            if (m_EnmAppType == enmApproveType.none)
                return -1;
            new clsApprove_FlowDomain().m_mthGetUserLevel(strCurrUserID, ref strCurrUserLevel, m_EnmAppType);
            new clsApprove_FlowDomain().m_mthGetUserLevel(m_StrRecorder_ID, ref strCreateUserLevel, m_EnmAppType);

            if (new clsApprove_FlowDomain().m_blnCanAuditing(Name, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString(), m_StrCurrentOpenDate, strCurrUserLevel, strCreateUserLevel, ref intCurrAppNo, true) != -1)
            {
                lngRet = new clsApprove_FlowDomain().m_lngBackAuditing(Name, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString(), m_StrCurrentOpenDate, intCurrAppNo);
                if (lngRet == -99)
                    clsPublicFunction.ShowInformationMessageBox("当前记录不能退审!");
                else
                    clsPublicFunction.ShowInformationMessageBox("退审成功!");
            }
            else
            {
                MessageBox.Show("不能退审此单！", "提示");
                return -1;
            }

            return 1;

        }

        public long m_lngDeleteDocument()
        {
            if (!m_BlnCanApprove || m_StrCurrentOpenDate == "")
                return 1;

            string strFormID = ((int)m_enmGetPrivilegeSF()).ToString();

            long lngEff = 0;
            lngEff = new clsApprove_FlowDomain().lngDeleteDocument(clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrEmployeeID, strFormID, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), m_StrCurrentOpenDate, ((clsDepartment)this.m_cboDept.SelectedItem).m_StrDeptID, ref lngEff);

            return 1;
        }

        public virtual bool lngCanYouDoIt()
        {

            string strCurrUserID = MDIParent.OperatorID; //当前用户
            string strCreateUserID = m_StrRecorder_ID; //表单建立用户

            string strCurrUserLevel = ""; //当前用户审核级别
            string strCreateUserLevel = ""; //表单建立用户审核级别
            string StrCurrentOpenDate = "";//当前记录创建时间

            int intCurrAppNo = 0;

            if (m_EnmAppType == enmApproveType.none)
            {
                return true;
            }
            else
            {
                new clsApprove_FlowDomain().m_mthGetUserLevel(strCurrUserID, ref strCurrUserLevel, m_EnmAppType);
                new clsApprove_FlowDomain().m_mthGetUserLevel(m_StrRecorder_ID, ref strCreateUserLevel, m_EnmAppType);

                if (int.Parse(strCurrUserLevel) >= int.Parse(strCreateUserLevel))
                {
                    StrCurrentOpenDate = m_StrCurrentOpenDate;
                    if (StrCurrentOpenDate.Trim().Length == 0)
                        return false;
                    new clsApprove_FlowDomain().m_blnCanAuditing(Name, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString(), StrCurrentOpenDate, strCurrUserLevel, strCreateUserLevel, ref intCurrAppNo, false);
                    if (int.Parse(strCurrUserLevel) >= intCurrAppNo)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }


        }


        /// <summary>
        /// 是否支持审核。有些窗体比如申请单是不需要的。
        /// </summary>
        protected virtual bool m_BlnCanApprove
        {
            get
            {
                return false;
            }
        }
        #endregion


        #region 生成套装模板
        /// <summary>
        /// 生成套装模板
        /// </summary>
        public void m_mthNewTemplate()
        {
            //this.m_frmSaveTemplateset.mthShowSaveDialog(m_strGetCurFormName(), false);

            if (m_ObjTemplateClient != null)
            {
                m_ObjTemplateClient.m_mthCreateTemplate();
            }
        }

        /// <summary>
        /// 生成套装模板，并且对话框以本窗体为父窗体
        /// </summary>
        public void m_mthNewTemplateWithThis()
        {
            //this.m_frmSaveTemplateset.mthShowSaveDialog(this.Name, this, false);
            if (m_ObjTemplateClient != null)
            {
                m_ObjTemplateClient.m_mthCreateTemplate();
            }
        }

        private void m_blnNewTemplate_Click(object sender, System.EventArgs e)
        {
            m_mthNewTemplate();
        }
        #endregion 生成套装模板

        #region 生成常用值
        /// <summary>
        /// 生成常用值
        /// </summary>
        public void m_mthNewCommonUse()
        {
            //if (this.ActiveControl == null)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("请先选择要生成常用值的输入框！");
            //    return;
            //}
            //this.m_frmSaveTemplateset.m_CtlCurrent = this.ActiveControl;
            //this.m_frmSaveTemplateset.mthShowSaveDialog(this.Name, true);
            if (m_ObjTemplateClient != null)
            {
                m_ObjTemplateClient.m_mthCreateCommonUseTemplate();
            }
        }

        /// <summary>
        /// 生成常用值，并且对话框以本窗体为父窗体
        /// </summary>
        public void m_mthNewCommonUseWithThis()
        {
            //if (this.ActiveControl == null)
            //{
            //    clsPublicFunction.ShowInformationMessageBox("请先选择要生成常用值的输入框！", this);
            //    return;
            //}
            //this.m_frmSaveTemplateset.m_CtlCurrent = this.ActiveControl;
            //this.m_frmSaveTemplateset.mthShowSaveDialog(this.Name, this, true);
            if (m_ObjTemplateClient != null)
            {
                m_ObjTemplateClient.m_mthCreateCommonUseTemplate();
            }
        }
        #endregion

        #region 智能查询的动态调用
        /// <summary>
        /// 允许其他窗体用Reflection打该本窗体。后三个参数是定位一条有效记录所需的参数。
        /// </summary>
        /// <param name="p_frmInvoker">打开本窗体的窗体</param>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        public void m_mthLoadRecordByReflection(System.Windows.Forms.Form p_frmInvoker, string p_strInPatientID, string p_strInPatientDate, string p_strOpenDate)
        {
            this.MdiParent = p_frmInvoker.MdiParent;
            this.WindowState = FormWindowState.Maximized;
            this.Show();

            clsPatient objPatient = new clsPatient(p_strInPatientID);

            m_mthSetPatientInfo(objPatient);

            m_mthLoadRecord(p_strInPatientDate, p_strOpenDate);
        }

        /// <summary>
        /// 在设置病人后，设置病人指定的记录
        /// </summary>
        /// <param name="p_strInPatientDate">病人住院日期</param>
        /// <param name="p_strOpenDate">记录日期</param>
        protected virtual void m_mthLoadRecord(string p_strInPatientDate, string p_strOpenDate)
        {
        }
        #endregion 智能查询的动态调用

        private void m_cmdNext_Click(object sender, System.EventArgs e)
        {

            try
            {
                m_blnGetAllBedNo = true;
                m_mthGetBedNOArr();
                m_blnGetAllBedNo = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void m_cmdPre_Click(object sender, System.EventArgs e)
        {
            clsPatient objPatient;
            string strAreaID = ((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID;
            new clsDepartmentManager().m_lngGetPreviousPatientInfoInArea(strAreaID, m_txtBedNO.Text.Trim(), out objPatient);

            m_mthSetPatientInfo(objPatient);
        }

        #region 以病人为线索导向
        /// <summary>
        /// 使选择病人的功能无效
        /// </summary>
        /// <param name="p_blnDisable">使无效</param>
        public void m_mthDisableSelectPatient(bool p_blnDisable)
        {
            m_txtBedNO.ReadOnly = p_blnDisable;
            m_txtPatientName.ReadOnly = p_blnDisable;
            txtInPatientID.ReadOnly = p_blnDisable;

            m_cboArea.Enabled = !p_blnDisable;
            m_cboDept.Enabled = !p_blnDisable;
        }
        #endregion 以病人为线索导向

        private void frmHRPBaseForm_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            m_pnlFocus.Location = new Point(e.X - 10, e.Y - 10);
            m_pnlFocus.Focus();
        }

        protected bool m_blnDirectPrint;
        /// <summary>
        /// 是否直接打印
        /// </summary>
        public bool m_BlnDirectPrint
        {
            set
            {
                m_blnDirectPrint = value;
            }
        }

        public void m_mthSetBedFocus()
        {
            this.m_ctlAreaPatientSelection.Focus();
        }

        protected bool m_blnIfNewDeletedRecord = false;
        /// <summary>
        /// 是否新添一条删除记录
        /// </summary>
        public bool m_BlnIfNewDeletedRecord
        {
            set
            {
                m_blnIfNewDeletedRecord = value;
            }
        }

        /// <summary>
        /// 获取当前表单名,自定义表单特殊处理
        /// </summary>
        /// <returns></returns>
        private string m_strGetCurFormName()
        {
            string strFormName = this.Name;
            if (this is iCare.CustomForm.frmCustomFormBase)
                strFormName = ((iCare.CustomForm.frmCustomFormBase)this).m_strGetCurFormName();
            return strFormName;
        }

        #region 下拉框事件
        /// <summary>
        /// 绑定下拉框的项目事件
        /// </summary>
        /// <param name="p_ctlParent"></param>
        protected virtual void m_mthAssociateComboBoxItemEvent(Control p_ctlParent)
        {
            ctlComboBox cboOld = p_ctlParent as ctlComboBox;
            com.digitalwave.Controls.ctlComboBox cboNew = p_ctlParent as com.digitalwave.Controls.ctlComboBox;
            if (cboOld != null)
            {
                if (cboOld.m_blnEnableItemEventMenu == true)
                {
                    cboOld.DropDown += new System.EventHandler(m_mthComboBox_DropDown);
                    cboOld.evtAddItem += new System.EventHandler(m_mthComboBox_Additem);
                    cboOld.evtModifyItem += new System.EventHandler(m_mthComboBox_Modifyitem);
                    cboOld.evtDelItem += new System.EventHandler(m_mthComboBox_Deleteitem);
                }
            }
            else if (cboNew != null)
            {
                if (cboNew.m_BlnEnableItemEventMenu == true)
                {
                    cboNew.DropDown += new EventHandler(cboNew_DropDown);
                    cboNew.evtAddItem += new EventHandler(cboNew_evtAddItem);
                    cboNew.evtModifyItem += new EventHandler(cboNew_evtModifyItem);
                    cboNew.evtDelItem += new EventHandler(cboNew_evtDelItem);
                    cboNew.TextChanged += new EventHandler(cboNew_TextChanged);
                    cboNew.SelectedIndexChanged += new EventHandler(cboNew_SelectedIndexChanged);
                }
            }
        }

        void cboNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = ((com.digitalwave.Controls.ctlComboBox)sender).SelectedItem.ToString();
        }

        void cboNew_TextChanged(object sender, EventArgs e)
        {
            int i = ((com.digitalwave.Controls.ctlComboBox)sender).SelectedIndex;
        }

        /// <summary>
        /// 下拉栏添加项目
        /// 读取vo的deptid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthComboBox_Additem(object sender, System.EventArgs e)
        {
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择科室");
                return;
            }

            ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as ctlComboBox;
            if (cbo == null)
                return;
            if (cbo.Text == "")
                return;
            clsComboBoxValue objValue = new clsComboBoxValue();
            //objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
            objValue.m_strDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
            objValue.m_strTypeID = this.Name;
            objValue.m_strItemID = cbo.Name;
            objValue.m_strItemContent = cbo.Text;
            long lngRef = new clsComboBoxDomainOld().m_lngAddItemToDB(objValue);
            if (lngRef < 1)
                return;
            cbo.InsertItem(0, objValue.m_strItemContent);
            cbo.SelectedIndex = 0;

        }

        /// <summary>
        /// 下拉栏修改项目
        /// 读取vo的deptid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthComboBox_Modifyitem(object sender, System.EventArgs e)
        {
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择科室");
                return;
            }

            ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as ctlComboBox;
            if (cbo == null)
                return;
            if (cbo.Text == "" || cbo.SelectedItem == null)
                return;
            clsComboBoxValue objValue;
            objValue = new clsComboBoxValue();
            //objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
            objValue.m_strDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
            objValue.m_strTypeID = this.Name;
            objValue.m_strItemID = cbo.Name;
            objValue.m_strItemContent = cbo.SelectedItem.ToString();
            long lngRef = new clsComboBoxDomainOld().m_lngModifyItem(objValue, cbo.Text);
            if (lngRef < 1)
                return;
            string strText = cbo.Text;
            cbo.RemoveItem(cbo.SelectedItem);
            cbo.Update();
            cbo.InsertItem(0, strText);
            cbo.SelectedIndex = 0;
        }

        /// <summary>
        /// 下拉栏删除项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_mthComboBox_Deleteitem(object sender, System.EventArgs e)
        {
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择科室");
                return;
            }

            ctlComboBox cbo = ((MenuItem)sender).GetContextMenu().SourceControl as ctlComboBox;
            if (cbo == null)
                return;
            if (cbo.Text == "" || cbo.SelectedItem == null)
                return;
            clsComboBoxValue objValue;
            objValue = new clsComboBoxValue();
            //objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
            objValue.m_strDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
            objValue.m_strTypeID = this.Name;
            objValue.m_strItemID = cbo.Name;
            objValue.m_strItemContent = cbo.SelectedItem.ToString();
            long lngRef = new clsComboBoxDomainOld().m_lngDeleteItem(objValue);
            if (lngRef < 1)
                return;
            cbo.RemoveItem(cbo.SelectedItem);
            cbo.Update();
        }


        /// <summary>
        /// 设置下拉项目
        /// 根据当前科室ID获取
        /// </summary>
        /// <param name="p_cboSender"></param>
        private void m_mthSetComboBoxListItem(ctlComboBox p_cboSender)
        {
            if (p_cboSender == null)
                return;

            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择一个科室。");
                return;
            }

            clsComboBoxValue[] objValueArr = null;
            new clsComboBoxDomainOld().m_lngGetAllItem(m_ObjCurrentArea.m_strDEPTID_CHR, this.Name, p_cboSender.Name, out objValueArr);

            if (objValueArr == null)
                return;

            p_cboSender.ClearItem();
            for (int i = 0; i < objValueArr.Length; i++)
            {
                if (objValueArr[i].m_strItemContent != null && objValueArr[i].m_strItemContent != string.Empty)
                    p_cboSender.AddItem(objValueArr[i].m_strItemContent);
            }
        }

        private void m_mthComboBox_DropDown(object sender, System.EventArgs e)
        {
            m_mthSetComboBoxListItem((ctlComboBox)sender);
        }


        #region new

        void cboNew_evtDelItem(object sender, EventArgs e)
        {
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择科室");
                return;
            }

            com.digitalwave.Controls.ctlComboBox cbo = sender as com.digitalwave.Controls.ctlComboBox;
            if (cbo == null)
                return;
            if (cbo.SelectedItem == null)
                return;
            clsComboBoxValue objValue;
            objValue = new clsComboBoxValue();
            objValue.m_strDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
            objValue.m_strTypeID = this.Name;
            objValue.m_strItemID = cbo.Name;
            objValue.m_strItemContent = cbo.SelectedItem.ToString();
            long lngRef = new clsComboBoxDomainOld().m_lngDeleteItem(objValue);
            if (lngRef < 1)
                return;
            cbo.Items.Remove(cbo.SelectedItem);
            cbo.Update();
        }
        void cboNew_evtModifyItem(object sender, EventArgs e)
        {
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择科室");
                return;
            }

            com.digitalwave.Controls.ctlComboBox cbo = sender as com.digitalwave.Controls.ctlComboBox;
            if (cbo == null)
                return;
            if (cbo.Text.Trim() == "" || cbo.m_ObjCurrentItem == null)
                return;
            clsComboBoxValue objValue;
            objValue = new clsComboBoxValue();
            //objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
            objValue.m_strDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
            objValue.m_strTypeID = this.Name;
            objValue.m_strItemID = cbo.Name;
            objValue.m_strItemContent = cbo.m_ObjCurrentItem.ToString();
            long lngRef = new clsComboBoxDomainOld().m_lngModifyItem(objValue, cbo.Text.Trim());
            if (lngRef < 1)
                return;
            string strText = cbo.Text;
            cbo.Items.Remove(cbo.SelectedItem);
            cbo.Update();
            cbo.Items.Insert(0, strText);
            cbo.SelectedIndex = 0;
        }

        void cboNew_evtAddItem(object sender, EventArgs e)
        {
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择病区");
                return;
            }

            com.digitalwave.Controls.ctlComboBox cbo = sender as com.digitalwave.Controls.ctlComboBox;
            if (cbo == null)
                return;
            if (cbo.Text.Trim() == "")
                return;
            clsComboBoxValue objValue = new clsComboBoxValue();
            //objValue.m_strDeptID = MDIParent.s_ObjDepartment.m_StrDeptID;
            objValue.m_strDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;
            objValue.m_strTypeID = this.Name;
            objValue.m_strItemID = cbo.Name;
            objValue.m_strItemContent = cbo.Text.Trim();
            long lngRef = new clsComboBoxDomainOld().m_lngAddItemToDB(objValue);
            if (lngRef < 1)
                return;
            cbo.Items.Insert(0, objValue.m_strItemContent);
            cbo.SelectedIndex = 0;

        }

        void cboNew_DropDown(object sender, EventArgs e)
        {
            com.digitalwave.Controls.ctlComboBox cbo = sender as com.digitalwave.Controls.ctlComboBox;
            if (m_ObjCurrentArea == null)
            {
                clsPublicFunction.ShowInformationMessageBox("请先选择一个病区。");
                return;
            }

            clsComboBoxValue[] objValueArr = null;
            new clsComboBoxDomainOld().m_lngGetAllItem(m_ObjCurrentArea.m_strDEPTID_CHR, this.Name, cbo.Name, out objValueArr);

            if (objValueArr == null)
                return;

            cbo.Items.Clear();
            for (int i = 0; i < objValueArr.Length; i++)
            {
                if (objValueArr[i].m_strItemContent != null && objValueArr[i].m_strItemContent != string.Empty)
                    cbo.Items.Add(objValueArr[i].m_strItemContent);
            }
        }
        #endregion New
        #endregion Combox Event

        #region 给单选增加右键取消功能
        private void m_mthrdb_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (e.Button == MouseButtons.Right)
                rdb.Checked = false;

        }
        #endregion 给单选增加右键取消功能

        #region 加载显示疾病关联的模板
        private void m_mthLoadAndShowTemplateSet(clsPatient p_objSelectedPatient)
        {
            try
            {
                System.Data.DataTable dtRecords = null;
                string strSql = "";
                com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[] objValue;
                com.digitalwave.common.ICD10.Tool.clsIllnessQueryDomain objICD10InfDomain = new com.digitalwave.common.ICD10.Tool.clsIllnessQueryDomain();
                strSql = "select ID,ICD_Name from ticd10 where id in(select ICD_ID from tInPatient_ICD10 where InPatientID='" + p_objSelectedPatient.m_StrInPatientID + "' and InPatientDate=" + com.digitalwave.Utility.SQLConvert.clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(p_objSelectedPatient.m_DtmSelectedInDate) + ")";// to_date('" + p_objSelectedPatient.m_DtmSelectedInDate + "','yyyy-mm-dd hh24:mi:ss'))";
                objICD10InfDomain.m_lngGetMaxID(strSql, ref dtRecords);
                if (dtRecords != null || dtRecords.Rows.Count > 0)
                {
                    if (dtRecords.Rows.Count > 0)
                    {
                        objValue = new com.digitalwave.common.ICD10.ValueObject.clsICD10Inf[dtRecords.Rows.Count];
                        for (int i = 0; i <= dtRecords.Rows.Count - 1; i++)
                        {
                            objValue[i] = new com.digitalwave.common.ICD10.ValueObject.clsICD10Inf();
                            objValue[i].ICD10_ID = long.Parse(dtRecords.Rows[i]["ID"].ToString());
                            objValue[i].ICD10_Name = dtRecords.Rows[i]["ICD_Name"].ToString();
                        }
                        frmInvokeTemplateByICD10 frmTemp = new frmInvokeTemplateByICD10(objValue, this, true);
                        frmTemp.Show();
                        frmTemp.Focus();
                    }
                }
            }
            catch (Exception)
            { }

        }
        #endregion

        private void txtInPatientID_TextChanged(object sender, System.EventArgs e)
        {
            //			if(m_objBaseCurrentPatient!=null)
            //				m_mthLoadAndShowTemplateSet(m_objBaseCurrentPatient);

        }

        private void frmHRPBaseForm_Enter(object sender, System.EventArgs e)
        {
            if (this.m_objBaseCurrentPatient != null)
            {
                MDIParent.s_ObjCurrentPatient = this.m_objBaseCurrentPatient;
            }
        }

        /// <summary>
        /// 保存最小元素集值
        /// </summary>
        private void m_mthSaveMinElementValue()
        {
            iCare.CustomForm.clsMinElementColDomain objDomain = new iCare.CustomForm.clsMinElementColDomain();
            for (int i = 0; i < m_arlMinElementColValue.Count; i++)
            {
                clsMinElementValues obj = (clsMinElementValues)m_arlMinElementColValue[i];
                if (obj == null)
                    continue;

                obj.m_strFormClsName = this.Name;
                obj.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
                obj.m_dtmCreatedDate = m_dtmCreatedDate;
                if (obj.m_objElementValueArr == null || obj.m_objElementValueArr.Length <= 0)
                    continue;

                objDomain.m_lngSaveTemplateData(obj);
            }
            m_arlMinElementColValue.Clear();
        }

        /// <summary>
        /// 递归清空控件内容
        /// </summary>
        /// <param name="p_ctlInput">父控件</param>
        /// <param name="p_ctlNotArr">不需清空的控件</param>
        protected void m_mthClear_Recursive(Control p_ctlParent, Control[] p_ctlNotArr)
        {
            //不需清空
            if (p_ctlNotArr != null)
                foreach (Control ctl in p_ctlNotArr)
                    if (ctl.Name == p_ctlParent.Name)
                        return;

            switch (p_ctlParent.GetType().FullName)
            {
                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlParent).m_mthClearText();
                    return;
                case "com.digitalwave.controls.ctlRichTextBox":
                    ((com.digitalwave.controls.ctlRichTextBox)p_ctlParent).m_mthClearText();
                    return;
                case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                    ((com.digitalwave.Utility.Controls.ctlBorderTextBox)p_ctlParent).Text = "";
                    return;
                case "System.Windows.Forms.RichTextBox":
                    ((System.Windows.Forms.RichTextBox)p_ctlParent).Text = "";
                    return;
                case "System.Windows.Forms.CheckBox":
                    ((System.Windows.Forms.CheckBox)p_ctlParent).Checked = false;
                    return;
            }

            foreach (Control ctl in p_ctlParent.Controls)
                m_mthClear_Recursive(ctl, p_ctlNotArr);
        }
        /// <summary>
        /// 是否处理科室改变事件
        /// </summary>
        protected bool m_blnCanDeptSelectIndexChangeEventTakePlace = true;
        /// <summary>
        /// 是否处理病区改变事件
        /// </summary>
        protected bool m_blnCanAreaSelectIndexChangeEventTakePlace = true;

        protected void m_cboDept_DropDown(object sender, System.EventArgs e)
        {
            try
            {
                if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
                    return;

                if (m_blnCheckRecordBase(this))
                    return;

                m_blnCanDeptSelectIndexChangeEventTakePlace = false;
                //初始化清空
                m_cboDept.ClearItem();
                this.m_cboArea.ClearItem();
                this.m_cboArea.Text = "";
                this.m_mthClearPatientBaseInfoButArea();
                this.m_mthClearAllInfo(this);
                //获取科室
                clsManageExplorerDomain objDomain = new clsManageExplorerDomain();
                clsEmrDept_VO[] objDeptInfoArr = null;
                clsDepartment[] objOldDeptArr = null;
                long lngRes = objDomain.m_lngGetDeptInfo(clsEMRLogin.LoginInfo.m_strEmpID, out objDeptInfoArr, out objOldDeptArr);
                if (lngRes <= 0)
                {
                    if (lngRes == (long)iCareData.enmOperationResult.Not_permission)
                        clsPublicFunction.ShowInformationMessageBox("权限不足!");
                    else
                        clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
                    return;
                }
                if (objOldDeptArr != null)
                {
                    m_cboDept.AddRangeItems(objOldDeptArr);
                }

            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.LogDetailError(exp, false);
            }
            finally
            {
                m_blnCanDeptSelectIndexChangeEventTakePlace = true;
            }
        }

        protected void m_cboArea_DropDown(object sender, System.EventArgs e)
        {
            try
            {
                if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
                    return;

                if (m_blnCheckRecordBase(this))
                    return;

                m_blnCanAreaSelectIndexChangeEventTakePlace = false;
                //初始化清空
                this.Cursor = Cursors.WaitCursor;

                this.m_mthClearPatientBaseInfoButArea();
                this.m_mthClearAllInfo(this);
                //获取病区
                m_cboArea.ClearItem();
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO[] objAreaInfoArr = null;
                long lngRes = objDomain.m_lngGetAreaInfo(((clsDepartment)(m_cboDept.SelectedItem)).m_strDeptNewID, out objAreaInfoArr);

                //long lngRes=objDomain.m_lngGetAreaInfo(((clsEmrDept_VO)(m_cboDept.SelectedItem)).m_strDEPTID_CHR, out objAreaInfoArr);
                if (lngRes <= 0)
                {
                    if (lngRes == (long)iCareData.enmOperationResult.Not_permission)
                        clsPublicFunction.ShowInformationMessageBox("权限不足!");
                    else
                        clsPublicFunction.ShowInformationMessageBox("数据库连接失败!");
                    return;
                }
                if (objAreaInfoArr != null)
                {
                    m_cboArea.ClearItem();
                    for (int i = 0; i < objAreaInfoArr.Length; i++)
                    {
                        //转换为旧的
                        clsInPatientArea objAreaTemp = new clsInPatientArea(objAreaInfoArr[i].m_strSHORTNO_CHR, objAreaInfoArr[i].m_strDEPTNAME_VCHR, objAreaInfoArr[i].m_strDEPTID_CHR);
                        //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                        objAreaTemp.m_strAreaNewID = objAreaInfoArr[i].m_strDEPTID_CHR;
                        m_cboArea.AddItem(objAreaTemp);
                        //m_cboArea.AddItem(objAreaInfoArr[i]);

                    }
                }
            }
            catch (Exception exp)
            {
                string strErrMessage = exp.Message + "\n at Module:[" + exp.TargetSite.ReflectedType.Name + "]\n  Method:[" + exp.TargetSite.Name + "]";
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                objLogger.Log2File(MDIParent.s_strErrorFilePath, "Exception: \r\n" + strErrMessage);
            }
            finally
            {
                m_blnCanAreaSelectIndexChangeEventTakePlace = true;
                this.Cursor = Cursors.Default;
            }


            #region RegionName
            //			this.Cursor=Cursors.WaitCursor;
            //			m_cboArea.ClearItem();
            //			this.m_mthClearPatientBaseInfoButArea();
            //			this.m_mthClearAllInfo(this);
            //			clsInPatientArea[] objAreaArr;
            //			if(this.m_cboDept.SelectedItem==null)
            //			{
            //				this.Cursor=Cursors.Default;
            //				return;
            //			}
            //			new clsDepartmentManager().m_lngGetAllAreaInDept(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,out objAreaArr);
            //			if(objAreaArr !=null)
            //			{	
            //				this.m_cboArea.AddRangeItems(objAreaArr);
            //				//				this.m_cboArea.SelectedIndex = 0;
            //			}
            //			this.Cursor=Cursors.Default;
            #endregion
        }

        #region Property
        /// <summary>
        /// 获取当前记录的OpenDate，
        /// </summary>
        protected virtual string m_StrCurrentOpenDate
        {
            get
            {
                return "1900-1-1";
            }
        }
        /// <summary>
        /// 获取窗体类型
        /// </summary>
        protected virtual enmApproveType m_EnmAppType
        {
            get { return enmApproveType.none; }
        }
        /// <summary>
        /// 获取记录建立者
        /// </summary>
        protected virtual string m_StrRecorder_ID
        {
            get { return ""; }
        }
        /// <summary>
        /// 
        /// </summary>
        #endregion

        #region Jump Control
        protected virtual void m_mthInitJump(clsJumpControl p_objJump)
        {
            //			p_objJump=new clsJumpControl(this,new Control[]{m_txtOutPatientID,m_txtDept,m_txtArea},Keys.Enter);
        }
        #endregion

        #region 电子签名 created by tfzhang at 2005年11月1日 11:53:38

        /// <summary>
        /// 验证电子签名
        /// </summary>
        /// <param name="p_strFormID"></param>
        /// <returns></returns>
        public virtual long m_lngSignVerify(string p_strFormID, string p_strRecordID)
        {
            long lngRes = 0;
            try
            {
                if (p_strFormID == null || p_strFormID.Trim().Length == 0)
                    return 0;
                clsDigitalSign_domain objSvc = new clsDigitalSign_domain();
                clsEmrDigitalSign_VO objSign = new clsEmrDigitalSign_VO();
                clsDigitalSign clsSign = new clsDigitalSign();
                lngRes = objSvc.m_lngGetDigitalSign(p_strFormID, p_strRecordID, m_blnCheckPatientIsOut(m_objBaseCurrentPatient.m_StrRegisterId), out objSign);
                if (objSign == null)
                {
                    MessageBox.Show("尚未电子签名无需验证", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }
                string strContent = System.Text.Encoding.UTF8.GetString(objSign.m_bteCONTENT_TXT);
                //验证
                string strReturn = clsSign.verify(strContent, objSign.m_strDSCONTENT_TXT, 0);
                if (strReturn == null)
                {
                    MessageBox.Show("签名验证失败,请确认插入Key盘", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(strReturn, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exp)
            {
                string strTmp = exp.Message;
                lngRes = 0;
            }
            return lngRes;
        }


        //电子签名已移出单独模块

        /// <summary>
        /// 获得签名信息
        /// </summary>
        /// <param name="p_strFormID"></param>
        /// <param name="objSign"></param>
        /// <returns></returns>
        protected virtual long m_lngGetSign(string p_strFormID, out clsEmrDigitalSign_VO objSign)
        {
            objSign = null;
            return 0;
        }

        #endregion

        #region 无痕迹修改控制 create by tfzhang 2006-01-17
        /// <summary>
        /// 无痕迹修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkModifyWithoutMatk_Click(object sender, System.EventArgs e)
        {
            chkModifyWithoutMatk.Checked = m_mthModifyWithoutMark();
        }
        /// <summary>
        /// 无痕迹修改方法
        /// </summary>
        protected virtual bool m_mthModifyWithoutMark()
        {
            //todo
            return false;
        }
        #endregion


        #region 打开新窗体前询问是否保存原有窗体
        internal bool m_blnHasClosing = false;
        internal bool m_blnNotClickWindows = false;

        private void frmHRPBaseForm_Deactivate(object sender, EventArgs e)
        {
            if ((m_objBaseCurrentPatient != null && m_objBaseCurrentPatient.m_IntCharacter != 1)
                && !m_blnHasCheckSamePatient && !m_blnHasClosing && !this.TopLevel && !m_blnNotClickWindows)
            {
                m_blnIsSaveBeforeNewForm();
            }
            m_blnNotClickWindows = false;
        }

        /// <summary>
        /// 打开新窗体前询问是否保存原有窗体(点击"窗口"的列表时触发)
        /// </summary>
        /// <returns></returns>
        private void m_blnIsSaveBeforeNewForm()
        {

            DialogResult dlgResult = DialogResult.None;
            if (!MDIParent.s_ObjSaveCue.m_blnCheckStatusSame(this))
            {
                dlgResult = clsPublicFunction.ShowQuestionMessageBox("[" + this.Text + "]做了改动，是否保存？", MessageBoxButtons.YesNo);

                if (dlgResult == DialogResult.Yes)
                {
                    this.m_lngSave();
                    this.Close();
                }
            }
        }
        #endregion

        internal bool m_blnHasCheckSamePatient = false;
        private bool m_blnCheckSamePatientForm(string p_strInPatientID)
        {
            if (p_strInPatientID == null)
                return false;
            if (this.MdiParent == null || this.MdiParent.MdiChildren == null)
                return false;
            m_blnHasCheckSamePatient = false;
            for (int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
            {
                if (this.MdiParent.MdiChildren[i] is frmHRPBaseForm
                    && !this.MdiParent.MdiChildren[i].Equals(this)
                    && this.MdiParent.MdiChildren[i].Name == this.Name)
                {
                    if (((frmHRPBaseForm)this.MdiParent.MdiChildren[i]).m_objBaseCurrentPatient != null &&
                        ((frmHRPBaseForm)this.MdiParent.MdiChildren[i]).m_objBaseCurrentPatient.m_StrInPatientID == p_strInPatientID)
                    {
                        m_blnHasCheckSamePatient = true;
                        this.MdiParent.MdiChildren[i].Activate();
                        return true;
                    }
                }
            }
            return false;
        }

        private bool m_blnCheckRecordBase(Form p_frmRecordBase)
        {
            if (p_frmRecordBase is frmRecordsBase)
            {
                if (((frmRecordsBase)p_frmRecordBase).m_FrmCurrentSub != null)
                {
                    clsPublicFunction.ShowInformationMessageBox("请先关闭子窗体[" + ((frmRecordsBase)p_frmRecordBase).m_FrmCurrentSub.Text + "]");
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 提供子窗体的手动资源释放
        /// </summary>
        //		protected override void m_mthReleaseSub()
        //		{
        //			if(m_objTempTool != null)
        //				m_objTempTool.Release();
        //			if(m_objJump != null)
        //				m_objJump.Release();
        //			if(m_frmSaveTemplateset != null)
        //				m_frmSaveTemplateset.Release();
        //			if(m_objHighLight != null)
        //				m_objHighLight.m_mthClear();
        //		}
        #region 签名
        /// <summary>
        /// 赋值多签名
        /// </summary>
        /// <param name="p_lsvSign"></param>
        /// <param name="p_objSignerArr"></param>
        protected virtual void m_mthAddSignToListView(ListView p_lsvSign, clsEmrSigns_VO[] p_objSignerArr)
        {
            if (p_lsvSign != null && p_objSignerArr != null)
            {
                p_lsvSign.Items.Clear();
                for (int i = 0; i < p_objSignerArr.Length; i++)
                {
                    if (p_objSignerArr[i].controlName == p_lsvSign.Name)
                    {
                        ListViewItem lviNewItem = new ListViewItem(p_objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                        //ID 检查重复用
                        lviNewItem.SubItems.Add(p_objSignerArr[i].objEmployee.m_strEMPID_CHR);
                        //级别 排序用(200609011修改为按历史的级别排序，历史的级别在保存表单时保存到签名表－bhuang)
                        lviNewItem.SubItems.Add(p_objSignerArr[i].objEmployee.m_StrHistroyLevel);
                        lviNewItem.SubItems.Add(p_objSignerArr[i].m_dtmModiftDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        //tag均为对象
                        lviNewItem.Tag = p_objSignerArr[i].objEmployee;
                        //是按顺序保存故获取顺序也一样
                        p_lsvSign.Items.Add(lviNewItem);
                    }
                }
            }
        }
        /// <summary>
        /// 赋值多签名
        /// </summary>
        /// <param name="p_lsvSign"></param>
        /// <param name="p_objSignerArr"></param>
        protected virtual void m_mthAddSignToListView(ListView[] p_lsvSigns, clsEmrSigns_VO[] p_objSignerArr)
        {
            if (p_lsvSigns == null || p_objSignerArr == null || p_lsvSigns.Length == 0 || p_objSignerArr.Length == 0) return;

            for (int j2 = 0; j2 < p_lsvSigns.Length; j2++)
            {
                p_lsvSigns[j2].Items.Clear();
                for (int i = 0; i < p_objSignerArr.Length; i++)
                {
                    if (p_objSignerArr[i].controlName == p_lsvSigns[j2].Name)
                    {
                        ListViewItem lviNewItem = new ListViewItem(p_objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                        //ID 检查重复用
                        lviNewItem.SubItems.Add(p_objSignerArr[i].objEmployee.m_strEMPID_CHR);
                        //级别 排序用(200609011修改为按历史的级别排序，历史的级别在保存表单时保存到签名表－bhuang)
                        lviNewItem.SubItems.Add(p_objSignerArr[i].objEmployee.m_StrHistroyLevel);
                        lviNewItem.SubItems.Add(p_objSignerArr[i].m_dtmModiftDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        //tag均为对象
                        lviNewItem.Tag = p_objSignerArr[i].objEmployee;
                        //是按顺序保存故获取顺序也一样
                        p_lsvSigns[j2].Items.Add(lviNewItem);
                    }
                }
            }
        }
        /// <summary>
        /// 赋值多签名
        /// </summary>
        /// <param name="p_lsvSign"></param>
        /// <param name="p_objSignerArr"></param>
        /// <param name="p_intisshowlevel">获取历史记录时是否显示职称：0-显示，1-不显示</param>
        protected virtual void m_mthAddSignToListView(ListView[] p_lsvSigns, clsEmrSigns_VO[] p_objSignerArr,int p_intisshowlevel)
        {
            if (p_lsvSigns == null || p_objSignerArr == null || p_lsvSigns.Length == 0 || p_objSignerArr.Length == 0) return;

            for (int j2 = 0; j2 < p_lsvSigns.Length; j2++)
            {
                p_lsvSigns[j2].Items.Clear();
                for (int i = 0; i < p_objSignerArr.Length; i++)
                {
                    if (p_objSignerArr[i].controlName == p_lsvSigns[j2].Name)
                    {
                        ListViewItem lviNewItem = null;
                        if (p_intisshowlevel == 0)
                        {
                            lviNewItem = new ListViewItem(p_objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);
                        }
                        else if (p_intisshowlevel == 1)
                        {
                            lviNewItem = new ListViewItem(p_objSignerArr[i].objEmployee.m_strLASTNAME_VCHR);
                        }
                        else
                        {
                            lviNewItem = new ListViewItem(p_objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName);

                        }
                        //ID 检查重复用
                        lviNewItem.SubItems.Add(p_objSignerArr[i].objEmployee.m_strEMPID_CHR);
                        //级别 排序用(200609011修改为按历史的级别排序，历史的级别在保存表单时保存到签名表－bhuang)
                        lviNewItem.SubItems.Add(p_objSignerArr[i].objEmployee.m_StrHistroyLevel);
                        lviNewItem.SubItems.Add(p_objSignerArr[i].m_dtmModiftDate.ToString("yyyy-MM-dd HH:mm:ss"));
                        //tag均为对象
                        lviNewItem.Tag = p_objSignerArr[i].objEmployee;
                        //是按顺序保存故获取顺序也一样
                        p_lsvSigns[j2].Items.Add(lviNewItem);
                    }
                }
            }
        }
        /// <summary>
        /// 赋值单签名,根据工号，循环所有工号查询员工，较慢
        /// </summary>
        /// <param name="p_txtSignArr">放置签名的Text控件</param>
        /// <param name="p_strEmpArr">签名者ID数组</param>
        /// <param name="p_blnIsEnable">赋值后是否置控件的Enable属性</param>
        protected virtual void m_mthAddSignToTextBoxByEmpNo(TextBoxBase[] p_txtSignArr, string[] p_strEmpArr, bool[] p_blnIsEnable)
        {
            if (p_txtSignArr == null || p_strEmpArr == null || p_txtSignArr.Length != p_strEmpArr.Length)
                return;
            //根据工号获取签名信息
            //出于兼容考虑，过渡使用 tfzhang 2006-03-12
            com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            for (int i = 0; i < p_strEmpArr.Length; i++)
            {
                if (!string.IsNullOrEmpty(p_strEmpArr[i]))
                {
                    clsEmrEmployeeBase_VO objSign4 = null;
                    objEmployeeSign.m_lngGetEmpByNO(p_strEmpArr[i].Trim(), out objSign4);
                    if (objSign4 != null)
                    {
                        objSign4.m_strTechnicalRank = objSign4.m_strTECHNICALRANK_CHR;
                        p_txtSignArr[i].Text = objSign4.m_strGetTechnicalRankAndName;
                        p_txtSignArr[i].Tag = objSign4;
                        p_txtSignArr[i].Enabled = p_blnIsEnable[i];
                    }

                }
            }
        }
        /// <summary>
        /// 赋值签名到文本框。
        /// 根据员工Id＆应该姓名生成员工类。
        /// 由于绝大多数签名只需要用到Id和姓名，优化效率，使用了这种方法。
        /// 所以表单应该在获取记录时拿出员工Id＆姓名。
        /// </summary>
        /// <param name="p_txtSignArr"></param>
        /// <param name="p_strEmpArr">[Id][姓名][职称]</param>
        /// <param name="p_blnIsEnable"></param>
        /// <param name="p_blnIsIgnoreTag">是否忽略控件的Tag属性</param>
        protected virtual void m_mthAddSignToTextBoxByValue(TextBoxBase[] p_txtSignArr, string[][] p_strEmpArr, bool[] p_blnIsEnable, bool p_blnIsIgnoreTag)
        {
            if (p_txtSignArr == null || p_strEmpArr == null || p_txtSignArr.Length != p_strEmpArr.Length)
                return;
            for (int i = 0; i < p_strEmpArr.Length; i++)
            {
                clsEmrEmployeeBase_VO objSign4 = null;
                if (!string.IsNullOrEmpty(p_strEmpArr[i][0]))
                {
                    objSign4 = new clsEmrEmployeeBase_VO();
                    objSign4.m_strEMPID_CHR = p_strEmpArr[i][0];
                    objSign4.m_strLASTNAME_VCHR = p_strEmpArr[i][1];
                    if (!string.IsNullOrEmpty(p_strEmpArr[i][2]))
                        objSign4.m_strTechnicalRank = p_strEmpArr[i][2];

                }
                if (objSign4 != null || p_blnIsIgnoreTag)
                {
                    p_txtSignArr[i].Text = p_strEmpArr[i][1];
                    p_txtSignArr[i].Tag = objSign4;
                    p_txtSignArr[i].Enabled = p_blnIsEnable[i];
                }
            }
        }
        /// <summary>
        /// 赋值签名到文本框。
        /// </summary>
        /// <param name="p_txtSignArr"></param>
        /// <param name="p_objSignerArr"></param>
        /// <param name="p_blnIsEnable"></param>
        /// <param name="p_blnIsIgnoreTag"></param>
        protected virtual void m_mthAddSignToTextBoxBase(TextBoxBase[] p_txtSignArr, clsEmrSigns_VO[] p_objSignerArr, bool[] p_blnIsEnable, bool p_blnIsIgnoreTag)
        {
            if (p_txtSignArr == null || p_objSignerArr == null || p_objSignerArr.Length == 0)
                return;
            for (int i = 0; i < p_txtSignArr.Length; i++)
            {
                p_txtSignArr[i].Clear();
                p_txtSignArr[i].Tag = null;
                for (int j = 0; j < p_objSignerArr.Length; j++)
                {
                    if (p_objSignerArr[j].controlName == p_txtSignArr[i].Name && p_objSignerArr[j].objEmployee != null)
                    {
                        p_txtSignArr[i].Text = p_objSignerArr[j].objEmployee.m_strGetTechnicalRankAndName;
                        p_txtSignArr[i].Enabled = p_blnIsEnable[i];
                        if (!p_blnIsIgnoreTag)
                        {
                            p_txtSignArr[i].Tag = p_objSignerArr[j].objEmployee;
                        }
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 获取签名列表
        /// </summary>
        /// <param name="p_ctlSigners"></param>
        /// <param name="p_objSignerArr"></param>
        /// <param name="p_strUserIDList"></param>
        /// <param name="p_strUserNameList"></param>
        protected virtual void m_mthGetSignArr(Control[] p_ctlSigners, ref clsEmrSigns_VO[] p_objSignerArr, ref string p_strUserIDList, ref string p_strUserNameList)
        {
            if (p_ctlSigners == null)
                return;
            string strUserIDList = "";
            string strUserNameList = "";
            string strFormName = p_ctlSigners[0].FindForm().Name;
            List<clsEmrSigns_VO> arlSignerArr = new List<clsEmrSigns_VO>();
            for (int j = 0; j < p_ctlSigners.Length; j++)
            {
                if (p_ctlSigners[j] is ListView)
                {
                    ListView lsvSign = (ListView)p_ctlSigners[j];
                    for (int i = 0; i < lsvSign.Items.Count; i++)
                    {
                        clsEmrSigns_VO objSigner = m_objGetSign(lsvSign.Items[i].Tag, lsvSign.Name, strFormName, ref strUserIDList, ref strUserNameList);

                        DateTime dtmModify = DateTime.MinValue;
                        if (lsvSign.Items[i].SubItems.Count > 3 && DateTime.TryParse(lsvSign.Items[i].SubItems[3].Text, out dtmModify))
                        {
                            objSigner.m_dtmModiftDate = dtmModify;
                        }
                        else
                        {
                            objSigner.m_dtmModiftDate = DateTime.MinValue;
                        }
                        if (objSigner != null)
                            arlSignerArr.Add(objSigner);
                    }
                }
                else if (p_ctlSigners[j] is TextBoxBase)
                {
                    clsEmrSigns_VO objSigner = m_objGetSign(p_ctlSigners[j].Tag, p_ctlSigners[j].Name, strFormName, ref strUserIDList, ref strUserNameList);
                    if (objSigner != null)
                        arlSignerArr.Add(objSigner);
                }
                if (strUserNameList.EndsWith(","))
                    strUserNameList = strUserNameList.Remove(strUserNameList.Length - 1);
                if (strUserIDList.EndsWith(","))
                    strUserIDList = strUserIDList.Remove(strUserIDList.Length - 1);
            }
            if (arlSignerArr.Count > 0)
            {
                p_objSignerArr = new clsEmrSigns_VO[arlSignerArr.Count];
                p_objSignerArr = arlSignerArr.ToArray();
            }
            p_strUserNameList = strUserNameList;
            p_strUserIDList = strUserIDList;
        }
        private clsEmrSigns_VO m_objGetSign(object p_objEmp, string p_strControlName, string p_strFormName, ref string p_strUserIDList, ref string p_strUserNameList)
        {
            clsEmrSigns_VO objSigner = new clsEmrSigns_VO();
            objSigner.objEmployee = (clsEmrEmployeeBase_VO)p_objEmp;
            if (objSigner.objEmployee == null)
                return null;
            objSigner.controlName = p_strControlName;
            objSigner.m_strFORMID_VCHR = p_strFormName;
            objSigner.m_strREGISTERID_CHR = com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR;
            if (p_strControlName == "lsvSign")
            {
                //痕迹格式 0972,0324,
                p_strUserIDList = p_strUserIDList + objSigner.objEmployee.m_strEMPID_CHR + ",";
                p_strUserNameList = p_strUserNameList + objSigner.objEmployee.m_strLASTNAME_VCHR + ",";
            }
            return objSigner;
        }
        /// <summary>
        /// 获取和痕迹有关的签名字符串
        /// </summary>
        /// <param name="p_strUserIDList">格式 0000001,0000003,</param>
        /// <param name="p_strUserNameList"></param>
        protected virtual void m_mthGetSignUserList(ListView p_lsvSign, out string p_strUserIDList, out string p_strUserNameList)
        {
            p_strUserIDList = string.Empty;
            p_strUserNameList = string.Empty;
            if (p_lsvSign.Items.Count == 0)
                return;
            for (int i = 0; i < p_lsvSign.Items.Count; i++)
            {
                clsEmrSigns_VO objSigner = p_lsvSign.Items[0].Tag as clsEmrSigns_VO;
                if (objSigner != null)
                {
                    //痕迹格式 0972,0324,
                    p_strUserIDList = p_strUserIDList + objSigner.objEmployee.m_strEMPID_CHR + ",";
                    p_strUserNameList = p_strUserNameList + objSigner.objEmployee.m_strLASTNAME_VCHR + ",";
                }
            }
            if (p_strUserIDList.EndsWith(","))
                p_strUserIDList = p_strUserIDList.Remove(p_strUserIDList.Length - 1);
            if (p_strUserNameList.EndsWith(","))
                p_strUserNameList = p_strUserNameList.Remove(p_strUserNameList.Length - 1);
        }
        /// <summary>
        /// 多签名时验证所有签名者 并保存
        /// </summary>
        /// <param name="p_objValues">签名的内容</param>
        /// <param name="p_blnMarkStatus">true＝无痕迹，需验证所有签名者；false＝有痕迹</param>
        /// <param name="p_objSignArr">签名列表</param>
        /// <param name="p_strRecordId">记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20</param>
        /// <returns></returns>
        protected virtual long m_lngCheckSign(object p_objValues, bool p_blnMarkStatus, clsEmrSigns_VO[] p_objSignArr, string p_strRecordId)
        {
            #region 多签名时验证所有签名者 并保存

            //数字签名 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = p_strRecordId;// m_objBaseCurrentPatient.m_StrInPatientID.Trim() + "-" + m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;

            if (p_objSignArr != null)
            {
                ArrayList objSignerArr = new ArrayList();
                for (int i = 0; i < p_objSignArr.Length; i++)
                {
                    if (p_objSignArr[i].controlName == "lsvSign" || p_objSignArr[i].controlName == "m_txtSign")
                        objSignerArr.Add(p_objSignArr[i].objEmployee);
                }

                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, p_blnMarkStatus);
                if (objCheck.CheckSigner(p_objValues, objSign_VO) == -1)
                    return -1;
            }
            else
            {
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(p_objValues, objSign_VO) == -1)
                    return -1;
            }
            return 1;
            #endregion 多签名时验证所有签名者 并保存
        }

        #endregion 签名
        /// <summary>
        /// 设置是否可选择其它病人
        /// </summary>
        /// <param name="p_blnIfCanSelect">true可选false不可选</param>
        protected void m_mthSetIfCanSelectPatient(bool p_blnIfCanSelect)
        {
            m_cboArea.Enabled = p_blnIfCanSelect;
            m_cboDept.Enabled = p_blnIfCanSelect;
            m_cmdNext.Enabled = p_blnIfCanSelect;
            txtInPatientID.Enabled = p_blnIfCanSelect;
            m_txtBedNO.Enabled = p_blnIfCanSelect;
            m_txtPatientName.Enabled = p_blnIfCanSelect;
            m_ctlAreaPatientSelection.m_mthSetSubItemEnable(p_blnIfCanSelect, p_blnIfCanSelect, true, p_blnIfCanSelect);
        }


        #region 修改痕迹控制相关

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// 此方法从病程记录的基类搬过来,目前参数只适合病程记录,以后应改成适合所有的保存记录的病历表单.
        /// </summary>
        /// <param name="p_objRecordContent">表单数据实体</param>
        /// <param name="p_blnReset"></param>
        protected virtual void m_mthSetModifyControl(clsTrackRecordContent p_objRecordContent,
            bool p_blnReset)
        {
            if (m_blnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);

            //根据书写规范设置具体窗体的书写控制，由子窗体重载实现
            if (p_blnReset == true)
            {
                //加上麻醉的判断，会使部分电子病历表单的字体颜色变成白色
                //if(MDIParent.s_bolIAnaSystem)
                //    m_mthSetRichTextModifyColor(this,SystemColors.Info);
                //else
                m_mthSetRichTextModifyColor(this, clsHRPColor.s_ClrInputFore);

                m_mthSetRichTextCanModifyLast(this, true);
            }
            else if (p_objRecordContent != null)
            {
                bool blnTempCanMoify;
                if (this.Name == "frmICUNurseRecordContent" || this.Name == "frmWaitLayRecord_AcadCon_GX"
                    || this.Name == "frmOXTIntravenousDripCon")
                    blnTempCanMoify = m_blnGetCanModifyLast(p_objRecordContent.m_strRecordUserID, p_objRecordContent.m_dtmCreateDate, p_objRecordContent.m_intMarkStatus);
                else
                    blnTempCanMoify = m_blnGetCanModifyLast(p_objRecordContent.m_strModifyUserID, p_objRecordContent.m_dtmCreateDate, p_objRecordContent.m_intMarkStatus);
                if (blnTempCanMoify && blnIsModifyWithoutMark)//如果可以无痕迹修改则不红字
                    m_mthSetRichTextModifyColor(this, Color.Black);
                else//如果不可以无痕迹修改则红字
                    m_mthSetRichTextModifyColor(this, Color.Red);


                m_mthSetRichTextCanModifyLast(this, blnTempCanMoify);
            }
        }
        /// <summary>
        /// 设置窗体中控件输入文本的颜色
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_clrColor"></param>
        protected void m_mthSetRichTextModifyColor(Control p_ctlControl, System.Drawing.Color p_clrColor)
        {
            #region 设置控件输入文本的颜色,Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().FullName;
            if (strTypeName == "com.digitalwave.Utility.Controls.ctlRichTextBox")
                ((com.digitalwave.Utility.Controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;
            else if (strTypeName == "com.digitalwave.controls.ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;

            if (p_ctlControl.HasChildren && strTypeName != "System.Windows.Forms.DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextModifyColor(subcontrol, p_clrColor);
                }
            }
            #endregion
        }

        /// <summary>
        /// 设置控件输入文本的是否最后修改
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_blnCanModifyLast"></param>
        protected void m_mthSetRichTextCanModifyLast(Control p_ctlControl, bool p_blnCanModifyLast)
        {
            #region 设置控件输入文本的是否允许无痕迹修改 Jacky-2003-3-24
            string strTypeName = p_ctlControl.GetType().FullName;
            if (strTypeName == "com.digitalwave.controls.ctlRichTextBox")
            {

                if (blnIsModifyWithoutMark)
                    ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
                else
                    ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = false;
            }

            if (p_ctlControl.HasChildren && strTypeName != "System.Windows.Forms.DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextCanModifyLast(subcontrol, p_blnCanModifyLast);
                }
            }
            #endregion
        }
        /// <summary>
        /// 输入框内，内容颜色的设置方法
        /// 如果该记录的最后修改人就是当前的登陆人，可以修改该记录
        /// 否则，不可修改（其中6小时的控制，在liyi的richtextbox中已有控制）
        /// </summary>
        /// <param name="p_strModifyUserID">创建者签名字符串，可以包含多个签名者</param>
        /// <param name="p_dtmCreatDate">表单的创建时间</param>
        /// <param name="p_intMark">表单痕迹修改属性 1＝不可无痕迹修改 0＝可以痕迹修改</param>
        /// <returns></returns>
        protected bool m_blnGetCanModifyLast(string p_strModifyUserID, DateTime p_dtmCreatDate, int p_intMark)
        {
            //if (p_ModifyUserB.m_strUserID.IndexOf(p_ModifyUserA.m_strUserID.Trim())< 0)
            //if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
            //时效判断，以【创建时间】为基准,最大的时间在richtextbox控制
            //modify by tfzhang at 2006-01-17
            if (p_intMark == 0)
            {
                int intl = int.Parse(clsEMRLogin.StrCanModifyTime);
                //MessageBox.Show(p_dtmCreatDate.ToString());
                if (p_dtmCreatDate.AddHours(intl) >= DateTime.Now)
                {
                    //兼容其他继承该基类但尚未做修改的表单，过渡使用
                    if (this.Name == "frmGeneralNurseRecord"
                        || this.Name == "frmGeneralNurseRecord_GXRec"
                        || this.Name == "frmSubICUIntensiveTend"
                        || this.Name == "frmSubWatchItemRecord"
                        || this.Name == "frmSubICUBreath"
                        || this.Name == "frmPostPartum_AcadCon"
                        || this.Name == "frmPostartumSeeRecordCon"
                        || this.Name == "frmIntensiveTend_GXContent"
                        || this.Name == "frmQuickeningTutelar_AcadCon"
                        || this.Name == "frmCardiovascularTend_GX"
                        || this.Name == "frmICUNurseRecord_GXCon"
                        || this.Name == "frmIntensiveTend"
                        || this.Name == "frmIntensiveTend_FC"
                        || this.Name == "frmIntensiveTend_FContent"
                        || this.Name == "frmIntensiveTend_GX"
                        || this.Name == "frmIntensiveTend_GXContent"
                        || this.Name == "frmSurgeryICUWardshipEdit"
                        || this.Name == "frmVeinSpecialUseDrugCon"
                        || this.Name == "frmWaitLayRecord_AcadCon"
                        || this.Name == "frmConsultation"
                        || this.Name == "frmDeathCaseDiscuss"
                        || this.Name == "frmDeathRecord"
                        || this.Name == "frmDeathRecordIn24Hours"
                        || this.Name == "frmEMR_OutHospitalIn24Hours"
                        || this.Name == "frmOutHospital")
                    {
                        if (p_strModifyUserID == null || p_strModifyUserID.IndexOf(clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim()) >= 0
                            || p_strModifyUserID.IndexOf(clsEMRLogin.LoginEmployee.m_strEMPNO_CHR.Trim()) >= 0)
                        {
                            chkModifyWithoutMatk.Visible = true;
                            chkModifyWithoutMatk.Checked = true;
                            return true;
                        }
                        else
                        {
                            chkModifyWithoutMatk.Checked = false;
                            return false;
                        }
                    }
                    else
                    {
                        if (p_strModifyUserID == null || p_strModifyUserID.IndexOf(clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim()) >= 0
                            || p_strModifyUserID.IndexOf(clsEMRLogin.LoginEmployee.m_strEMPNO_CHR.Trim()) >= 0)
                        {
                            chkModifyWithoutMatk.Visible = true;
                            chkModifyWithoutMatk.Checked = true;
                            return true;
                        }
                        else
                        {
                            chkModifyWithoutMatk.Checked = false;
                            return false;
                        }
                    }

                }
                else
                {
                    chkModifyWithoutMatk.Visible = false;
                    chkModifyWithoutMatk.Checked = false;
                    return false;

                }
            }
            else
            {
                return false;
            }
        }



        #region 多人无痕迹设置Richtextbox的用户ID和用户姓名
        protected virtual bool blnIsModifyWithoutMark
        {
            get { return true; }
        }
        #region 签名者集合字段
        /// <summary>
        /// 签名者ID集合
        /// </summary>
        protected string strUserIDList = "";
        /// <summary>
        /// 签名者名称集合
        /// </summary>
        protected string strUserNameList = "";

        #endregion
        /// <summary>
        /// 多人无痕迹设置设置Richtextbox的用户ID和用户姓名
        /// </summary>
        /// <param name="p_objRichTextBox"></param>
        protected void m_mthSetRichTextBoxAttribWithIDandName(Control p_objRichTextBox)
        {
            if (p_objRichTextBox.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                //设置签名ID、签名姓名	
                //无痕迹修改则为签名者
                if (chkModifyWithoutMatk.Checked)
                {
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = strUserIDList;
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = strUserNameList;
                }
                else//有痕迹修改则为登陆者
                {
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim();
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = clsEMRLogin.LoginEmployee.m_strLASTNAME_VCHR.Trim();
                }
            }
        }
        /// <summary>
        /// 多人无痕迹循环处理设置
        /// </summary>
        /// <param name="p_ctlControl"></param>
        protected void m_mthSetRichTextBoxAttribInControlWithIDandName(Control p_ctlControl)
        {
            if (p_ctlControl.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                m_mthSetRichTextBoxAttribWithIDandName((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
            }

            if (p_ctlControl.HasChildren && p_ctlControl.GetType().Name != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextBoxAttribInControlWithIDandName(subcontrol);
                }
            }
        }
        #endregion 多人无痕迹设置Richtextbox的用户ID和用户姓名

        #endregion 修改痕迹控制相关
        /// <summary>
        /// 检查病人是否已经出过院(true＝出过院；false=未出过院)
        /// </summary>
        /// <param name="p_strRegisterId"></param>
        /// <returns></returns>
        protected bool m_blnCheckPatientIsOut(string p_strRegisterId)
        {
            clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
            bool blnIsOut = false;
            long lngRes = objDomain.m_lngCheckPatientIsOut(p_strRegisterId, out blnIsOut);
            return blnIsOut;
        }

        #region 修改患者资料
        private void m_cmdModifyPatientInfo_Click(object sender, EventArgs e)
        {
            if (m_objBaseCurrentPatient == null)
            {
                MessageBox.Show("请选择患者！");
                return;
            }
            frmEditPatientBasInfo objInfo = new frmEditPatientBasInfo(m_objBaseCurrentPatient.m_StrRegisterId, false);
            objInfo.FormClosed += new FormClosedEventHandler(objInfo_FormClosed);
            objInfo.ShowDialog(this);
        }

        private void objInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
            {
                return;
            }
            m_mthNewAreaSetPatient(m_ObjCurrentBed);
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }

        private void m_mth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.P)
            {
                m_cmdModifyPatientInfo.PerformClick();
            }
        }
        #endregion 修改患者资料

        #region 新的病区选择
        /// <summary>
        /// 病区选择改变后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctlAreaPatientSelection_evtAreaChanged(object sender, com.digitalwave.Controls.Domain.EmrControls.clsAreaDataEventArg e)
        {
            com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment = e.SelectedArea;
            com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjSelectArea = e.SelectedArea;

            if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }

            this.m_mthAreaChanged(e.SelectedArea);
        }

        /// <summary>
        /// 病区选择改变后事件
        /// 选择病区，由子窗体实现(特殊子窗体，如一般护理记录整体录入)
        /// </summary>
        /// <param name="p_objSelectedArea">选择的病区</param>
        protected virtual void m_mthAreaChanged(clsEmrDept_VO p_objSelectedArea)
        {
            //if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
            //    return;

            if (m_blnCheckRecordBase(this))
                return;
            this.m_mthClearPatientBaseInfoButArea();
            this.m_mthClearAllInfo(this);
        }
        /// <summary>
        /// 病床号改变后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctlAreaPatientSelection_evtBedChanged(object sender, com.digitalwave.Controls.Domain.EmrControls.clsBedDataEventArg e)
        {
            try
            {
                if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                this.m_mthNewAreaSetPatient(e.CurrentBed);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                e.Cancel = true;
            }
        }
        /// <summary>
        /// 设置患者信息
        /// </summary>
        /// <param name="p_objEmrBed"></param>
        private void m_mthNewAreaSetPatient(clsEmrBed_VO p_objEmrBed)
        {
            if (m_blnCheckRecordBase(this)) return;

            clsPatient objPatient = new clsPatient(p_objEmrBed);

            string strTemp = objPatient.m_StrPatientID;
            string strTempDeptID = objPatient.m_strDeptNewID;
            string strTempAreaID = objPatient.m_strAreaNewID;
            string strBedCode = objPatient.m_strBedCode;

            if (m_blnCheckSamePatientForm(objPatient.m_StrInPatientID))
                return;

            this.m_mthClearPatientBaseInfoButArea();
            this.m_mthClearAllInfo(this);

            #region 转换VO
            //更新com.digitalwave.BEDExplorer.frmHRPExplorer.objpCurrentPatient
            //因为只需要通过m_strINPATIENTID_CHR来构造旧的clspatient
            //过渡使用
            clsHospitalManagerDomain objMain = new clsHospitalManagerDomain();
            frmHRPExplorer.objpCurrentPatient = p_objEmrBed.m_objInbedPatient;

            clsEmrDept_VO objDeptNew;
            objMain.m_lngGetSpecialDeptInfo(strTempDeptID, out objDeptNew);
            frmHRPExplorer.objpCurrentDepartment = objDeptNew;

            clsEmrDept_VO objAreNew;
            objMain.m_lngGetSpecialAreaInfo(strTempAreaID, out objAreNew);
            frmHRPExplorer.objpCurrentArea = objAreNew;
            #endregion

            m_mthSetPatientInfo(objPatient);
            m_ctlPatientInfo.m_mthClearText();
            m_ctlPatientInfo.m_mthSetPatientBaseInfo(p_objEmrBed);
            m_mthAddFormStatusForClosingSave();
        }
        /// <summary>
        /// 入院日期改变后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_ctlAreaPatientSelection_evtSessionSelected(object sender, com.digitalwave.Controls.Domain.EmrControls.clsSessionEventArg e)
        {
            if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            this.m_mthPerformSessionChanged(e.SelectedSession, e.Index);
        }

        private void m_ctlAreaPatientSelection_evtRefreshResult(object sender, com.digitalwave.Controls.Domain.EmrControls.clsBedDataEventArg e)
        {
            if (m_objBaseCurrentPatient != null && m_dlgHandleSaveBeforePrint() == DialogResult.Cancel)
            {
                return;
            }
            m_mthNewAreaSetPatient(e.CurrentBed);
            m_mthPerformSessionChanged(m_ObjCurrentEmrPatientSession, 0);
        }
        /// <summary>
        /// 入院日期改变后事件触发执行(由子类实现)
        /// </summary>
        /// <param name="p_objSelectedSession">当前选择的住院记录</param>
        /// <param name="p_intIndex">当前记录在所有记录里的索引</param>
        protected virtual void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
        }

        /// <summary>
        /// 获取当前住院记录
        /// </summary>
        public clsEmrPatientSessionInfo_VO m_ObjCurrentEmrPatientSession
        {

            get
            {
                return m_ctlAreaPatientSelection.CurrentSessionInfo;
            }
        }

        /// <summary>
        /// 获取当前病人信息
        /// </summary>
        public clsEmrPatient_VO m_ObjCurrentEmrPatient
        {
            get
            {
                return m_ctlPatientInfo.CurrentEmrPatient;
            }
        }



        /// <summary>
        ///  获取当前床位（患者）
        /// </summary>
        protected clsEmrBed_VO m_ObjCurrentBed
        {
            get
            {
                return m_ctlAreaPatientSelection.CurrentBed;
            }
        }

        /// <summary>
        ///  获取当前病区
        /// </summary>
        protected clsEmrDept_VO m_ObjCurrentArea
        {
            get
            {
                return m_ctlAreaPatientSelection.CurrentArea;
            }
        }

        /// <summary>
        /// 获取最后一次住院记录
        /// </summary>
        protected clsEmrPatientSessionInfo_VO m_ObjLastEmrPatientSession
        {
            get
            {
                return m_ctlAreaPatientSelection.m_objGetLastPatientSession();
            }
        }
        #endregion 新的病区选择

        #region infInactiveRecord (作废重用逻辑)

        public bool m_blnReused(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (this.MdiParent == null)
            {
                this.MdiParent = clsEMR_StaticObject.s_FrmMDI;
                this.WindowState = FormWindowState.Maximized;
            }
            this.Activate();
            return m_blnSubReuse(p_objSelectedValue);
        }
        /// <summary>
        /// 由继承类实现作废重用的逻辑
        /// </summary>
        /// <param name="p_objSelectedValue"></param>
        /// <returns></returns>
        protected virtual bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            return false;
        }

        public void m_mthInitForm(clsEmrInBedPatient_VO p_objPatient)
        {
            m_mthSubInitForm(p_objPatient);
        }
        /// <summary>
        /// 设置患者
        /// </summary>
        /// <param name="p_objPatient"></param>
        protected virtual void m_mthSubInitForm(clsEmrInBedPatient_VO p_objPatient)
        {
            if (this.m_ObjCurrentEmrPatientSession != null && this.m_ObjCurrentEmrPatientSession.m_strRegisterId == p_objPatient.m_strREGISTERID_CHR) return;
            this.m_ctlAreaPatientSelection.m_mthSetPatient(p_objPatient.m_strAREAID_CHR, p_objPatient.m_strPATIENTID_CHR, p_objPatient.m_strREGISTERID_CHR);
        }

        public void m_mthPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            m_mthSubPreviewInactiveRecord(p_infOwner, p_objSelectedValue);
        }
        /// <summary>
        /// 由继承类实现预览的逻辑
        /// </summary>
        /// <param name="p_infOwner"></param>
        /// <param name="p_objSelectedValue"></param>
        protected virtual void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
        }

        public clsInactiveRecordInfo_VO[] m_objGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            return m_objSubGetAllInactiveInfo(p_objSelectedValue);
        }
        /// <summary>
        /// 由继承类实现获取所有作废记录逻辑
        /// </summary>
        /// <returns></returns>
        protected virtual clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            return null;
        }
        /// <summary>
        /// get sub form Type
        /// </summary>
        public Type m_typForm
        {
            get { return this.GetType(); }
        }

        public iCareData.clsEmrPatientSessionInfo_VO m_objGetSessionInfo
        {
            get { return m_ObjCurrentEmrPatientSession; }
        }

        #region 作废重做
        private bool m_blnPatientSelected = false;
        public void m_mthSearchDeactiveInfo()
        {
            if (m_IntFormID > -1)
            {
                m_blnPatientSelected = this.m_objBaseCurrentPatient != null;

                frmDeactiveRecord frmDeactive = new frmDeactiveRecord();
                frmDeactive.m_mthSetForm(this, m_objBaseCurrentPatient);
                frmDeactive.ShowDialog(this);
            }
        }
        /// <summary>
        /// 设置作废重做内容
        /// </summary>
        /// <param name="p_objPatient">病人（最后住院的信息）</param>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        public void m_mthSetDeactiveContent(clsPatient p_objPatient, DateTime p_dtmRecordDate, int p_intFormID)
        {
            if (p_objPatient == null)
                return;

            if (!m_blnPatientSelected)
            {
                m_mthSetPatient(p_objPatient);
            }

            m_mthGetDeactiveContent(p_dtmRecordDate, p_intFormID);
        }

        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected virtual void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
        }

        /// <summary>
        /// 窗体ID，只针对允许作废重做的窗体
        /// </summary>
        public virtual int m_IntFormID
        {
            get
            {
                return -1;
            }
        }
        #endregion
        /// <summary>
        /// 是否实现了新的作废重做逻辑，为了兼容旧版本
        /// </summary>
        public virtual bool m_blnIsNewSetInactiveForm
        {
            get { return false; }
        }
        #endregion
    }
}
