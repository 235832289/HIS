using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using com.digitalwave.emr.BEDExplorer;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
using com.digitalwave.Emr.Signature_gui;

namespace iCare
{
    /// <summary>
    /// 死亡记录（独立版）
    /// </summary>
    public class frmDeathRecord : iCare.frmDiseaseTrackBase
    {
        //		private clsEmployeeSignTool m_objSignTool;
        private System.Windows.Forms.TextBox m_txtCardiogramID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox m_txtXRayID;
        private System.Windows.Forms.TextBox m_txtUltrasonic;
        private System.Windows.Forms.TextBox m_txtMRIID;
        private System.Windows.Forms.TextBox m_txtBrainWaveID;
        private System.Windows.Forms.Label k;
        private System.Windows.Forms.Label lblFolk;
        private System.Windows.Forms.Label lblNative;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpDeadDate;
        private System.Windows.Forms.Label lblInHospitalDays;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpOperationDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalDiagnose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private com.digitalwave.controls.ctlRichTextBox m_txtInHospitalProcess;
        private System.Windows.Forms.Label label21;
        private com.digitalwave.controls.ctlRichTextBox m_txtDeadProcess;
        private System.Windows.Forms.Label label22;
        private com.digitalwave.controls.ctlRichTextBox m_txtDeadDiagnose;
        private System.Windows.Forms.Label label23;
        private com.digitalwave.controls.ctlRichTextBox m_txtDeadVirdict;
        private PinkieControls.ButtonXP m_cmdDoctorSign;
        private TextBox m_txtDoctorSign;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;

        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.controls.ctlRichTextBox m_txtOperationName;
        private System.Windows.Forms.Label m_lblInHospitalDate;
        private System.Windows.Forms.Label lblIsMarry;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        public frmDeathRecord()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
            m_mthSetRichTextBoxAttribInControl(this);

            this.Text = "死亡记录";
            this.m_lblForTitle.Text = this.Text;

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, m_txtDoctorSign, 1, false, clsEMRLogin.LoginInfo.m_strEmpID);
        }

        /// <summary>
        /// 清理所有正在使用的资源。
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

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.m_txtCardiogramID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtXRayID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtUltrasonic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtMRIID = new System.Windows.Forms.TextBox();
            this.m_txtBrainWaveID = new System.Windows.Forms.TextBox();
            this.k = new System.Windows.Forms.Label();
            this.lblFolk = new System.Windows.Forms.Label();
            this.lblNative = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.m_dtpDeadDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInHospitalDays = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblIsMarry = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_dtpOperationDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtInHospitalDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtInHospitalProcess = new com.digitalwave.controls.ctlRichTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtDeadProcess = new com.digitalwave.controls.ctlRichTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_txtDeadDiagnose = new com.digitalwave.controls.ctlRichTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_txtDeadVirdict = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_txtOperationName = new com.digitalwave.controls.ctlRichTextBox();
            this.m_lblInHospitalDate = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(4, 35);
            this.m_trvCreateDate.Size = new System.Drawing.Size(194, 55);
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(318, 126);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(388, 122);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(222, 22);
            this.m_dtpCreateDate.TabIndex = 1900;
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(346, 517);
            this.m_dtpGetDataTime.TabIndex = 2000;
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.Location = new System.Drawing.Point(246, 519);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(266, 230);
            this.lblSex.Size = new System.Drawing.Size(52, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(300, 220);
            this.lblAge.Size = new System.Drawing.Size(84, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(352, 220);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(300, 224);
            this.lblInHospitalNoTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInHospitalNoTitle.Text = "住 院 号:";
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(295, 211);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(261, 224);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(281, 222);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(342, 219);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(415, 224);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(28, 18);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.AccessibleDescription = "住院号";
            this.txtInPatientID.Location = new System.Drawing.Point(327, 211);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.TabIndex = 400;
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(305, 211);
            this.m_txtPatientName.ReadOnly = true;
            this.m_txtPatientName.Size = new System.Drawing.Size(104, 23);
            this.m_txtPatientName.TabIndex = 1000;
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.AccessibleDescription = "床号";
            this.m_txtBedNO.Location = new System.Drawing.Point(355, 213);
            this.m_txtBedNO.Size = new System.Drawing.Size(16, 23);
            this.m_txtBedNO.TabIndex = 300;
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.AccessibleDescription = "病区";
            this.m_cboArea.Location = new System.Drawing.Point(333, 213);
            this.m_cboArea.Size = new System.Drawing.Size(20, 23);
            this.m_cboArea.TabIndex = 200;
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(400, 224);
            this.m_lsvPatientName.Size = new System.Drawing.Size(19, 18);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(370, 224);
            this.m_lsvBedNO.Size = new System.Drawing.Size(28, 18);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.AccessibleDescription = "科室";
            this.m_cboDept.Location = new System.Drawing.Point(317, 210);
            this.m_cboDept.Size = new System.Drawing.Size(10, 23);
            this.m_cboDept.TabIndex = 100;
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(317, 213);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(359, 210);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(12, 32);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(355, 219);
            this.m_cmdNext.Size = new System.Drawing.Size(20, 21);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(370, 221);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(259, 204);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(223, 210);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(724, 36);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(65, 26);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.label10);
            this.m_pnlNewBase.Controls.Add(this.lblInHospitalDays);
            this.m_pnlNewBase.Location = new System.Drawing.Point(3, 5);
            this.m_pnlNewBase.Size = new System.Drawing.Size(791, 86);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblInHospitalDays, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.label10, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(193, 29);
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowOccupy = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(596, 56);
            // 
            // m_txtCardiogramID
            // 
            this.m_txtCardiogramID.AccessibleDescription = "心电图号";
            this.m_txtCardiogramID.Location = new System.Drawing.Point(69, 95);
            this.m_txtCardiogramID.MaxLength = 12;
            this.m_txtCardiogramID.Name = "m_txtCardiogramID";
            this.m_txtCardiogramID.Size = new System.Drawing.Size(96, 23);
            this.m_txtCardiogramID.TabIndex = 500;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 10000006;
            this.label2.Text = "心电图号:";
            // 
            // m_txtXRayID
            // 
            this.m_txtXRayID.AccessibleDescription = "X光号";
            this.m_txtXRayID.Location = new System.Drawing.Point(213, 95);
            this.m_txtXRayID.MaxLength = 12;
            this.m_txtXRayID.Name = "m_txtXRayID";
            this.m_txtXRayID.Size = new System.Drawing.Size(102, 23);
            this.m_txtXRayID.TabIndex = 600;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(166, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 10000006;
            this.label1.Text = "X光号:";
            // 
            // m_txtUltrasonic
            // 
            this.m_txtUltrasonic.AccessibleDescription = "超声波号";
            this.m_txtUltrasonic.Location = new System.Drawing.Point(387, 95);
            this.m_txtUltrasonic.MaxLength = 12;
            this.m_txtUltrasonic.Name = "m_txtUltrasonic";
            this.m_txtUltrasonic.Size = new System.Drawing.Size(95, 23);
            this.m_txtUltrasonic.TabIndex = 700;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 10000006;
            this.label3.Text = "超声波号:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(648, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 10000006;
            this.label4.Text = "MRI号:";
            // 
            // m_txtMRIID
            // 
            this.m_txtMRIID.AccessibleDescription = "MRI号";
            this.m_txtMRIID.Location = new System.Drawing.Point(695, 95);
            this.m_txtMRIID.MaxLength = 12;
            this.m_txtMRIID.Name = "m_txtMRIID";
            this.m_txtMRIID.Size = new System.Drawing.Size(99, 23);
            this.m_txtMRIID.TabIndex = 900;
            // 
            // m_txtBrainWaveID
            // 
            this.m_txtBrainWaveID.AccessibleDescription = "脑电波号";
            this.m_txtBrainWaveID.Location = new System.Drawing.Point(549, 95);
            this.m_txtBrainWaveID.MaxLength = 12;
            this.m_txtBrainWaveID.Name = "m_txtBrainWaveID";
            this.m_txtBrainWaveID.Size = new System.Drawing.Size(98, 23);
            this.m_txtBrainWaveID.TabIndex = 800;
            // 
            // k
            // 
            this.k.Location = new System.Drawing.Point(359, 210);
            this.k.Name = "k";
            this.k.Size = new System.Drawing.Size(25, 23);
            this.k.TabIndex = 10000005;
            this.k.Visible = false;
            // 
            // lblFolk
            // 
            this.lblFolk.AccessibleDescription = "民族";
            this.lblFolk.Location = new System.Drawing.Point(440, 204);
            this.lblFolk.Name = "lblFolk";
            this.lblFolk.Size = new System.Drawing.Size(42, 23);
            this.lblFolk.TabIndex = 10000009;
            this.lblFolk.Visible = false;
            // 
            // lblNative
            // 
            this.lblNative.AccessibleDescription = "籍贯";
            this.lblNative.Location = new System.Drawing.Point(299, 210);
            this.lblNative.Name = "lblNative";
            this.lblNative.Size = new System.Drawing.Size(110, 23);
            this.lblNative.TabIndex = 10000009;
            this.lblNative.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 10000011;
            this.label9.Text = "民族:";
            this.label9.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AccessibleDescription = "职业";
            this.lblOccupation.Location = new System.Drawing.Point(295, 210);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(104, 23);
            this.lblOccupation.TabIndex = 10000009;
            this.lblOccupation.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(482, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 14);
            this.label12.TabIndex = 10000006;
            this.label12.Text = "脑电波号:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(276, 210);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 14);
            this.label13.TabIndex = 10000008;
            this.label13.Text = "职业:";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 216);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 10000010;
            this.label14.Text = "籍贯:";
            this.label14.Visible = false;
            // 
            // m_dtpDeadDate
            // 
            this.m_dtpDeadDate.AccessibleDescription = "死亡日期";
            this.m_dtpDeadDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpDeadDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpDeadDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpDeadDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpDeadDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpDeadDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpDeadDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpDeadDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpDeadDate.Location = new System.Drawing.Point(68, 122);
            this.m_dtpDeadDate.m_BlnOnlyTime = false;
            this.m_dtpDeadDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpDeadDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpDeadDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpDeadDate.Name = "m_dtpDeadDate";
            this.m_dtpDeadDate.ReadOnly = false;
            this.m_dtpDeadDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpDeadDate.TabIndex = 1100;
            this.m_dtpDeadDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpDeadDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 14);
            this.label8.TabIndex = 10000006;
            this.label8.Text = "死亡日期:";
            // 
            // lblInHospitalDays
            // 
            this.lblInHospitalDays.AccessibleDescription = "住院日数";
            this.lblInHospitalDays.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInHospitalDays.Location = new System.Drawing.Point(644, 58);
            this.lblInHospitalDays.Name = "lblInHospitalDays";
            this.lblInHospitalDays.Size = new System.Drawing.Size(51, 23);
            this.lblInHospitalDays.TabIndex = 10000009;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(276, 216);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 14);
            this.label11.TabIndex = 10000011;
            this.label11.Text = "婚否:";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(573, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 23);
            this.label10.TabIndex = 10000006;
            this.label10.Text = "住院日数:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 14);
            this.label7.TabIndex = 10000006;
            this.label7.Text = "入院日期:";
            this.label7.Visible = false;
            // 
            // lblIsMarry
            // 
            this.lblIsMarry.AccessibleDescription = "婚否";
            this.lblIsMarry.Location = new System.Drawing.Point(249, 207);
            this.lblIsMarry.Name = "lblIsMarry";
            this.lblIsMarry.Size = new System.Drawing.Size(40, 23);
            this.lblIsMarry.TabIndex = 10000009;
            this.lblIsMarry.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(0, 154);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 14);
            this.label16.TabIndex = 10000013;
            this.label16.Text = "手术名称:";
            // 
            // m_dtpOperationDate
            // 
            this.m_dtpOperationDate.AccessibleDescription = "手术日期";
            this.m_dtpOperationDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpOperationDate.CustomFormat = "yyyy年MM月dd日         ";
            this.m_dtpOperationDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpOperationDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpOperationDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpOperationDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpOperationDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpOperationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpOperationDate.Location = new System.Drawing.Point(630, 148);
            this.m_dtpOperationDate.m_BlnOnlyTime = false;
            this.m_dtpOperationDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Day;
            this.m_dtpOperationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpOperationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpOperationDate.Name = "m_dtpOperationDate";
            this.m_dtpOperationDate.ReadOnly = false;
            this.m_dtpOperationDate.Size = new System.Drawing.Size(155, 22);
            this.m_dtpOperationDate.TabIndex = 1300;
            this.m_dtpOperationDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpOperationDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(554, 153);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 14);
            this.label17.TabIndex = 10000006;
            this.label17.Text = "手术日期:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 183);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 14);
            this.label18.TabIndex = 10000014;
            this.label18.Text = "入院诊断:";
            // 
            // m_txtInHospitalDiagnose
            // 
            this.m_txtInHospitalDiagnose.AccessibleDescription = "入院诊断";
            this.m_txtInHospitalDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalDiagnose.Location = new System.Drawing.Point(68, 180);
            this.m_txtInHospitalDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalDiagnose.m_BlnPartControl = false;
            this.m_txtInHospitalDiagnose.m_BlnReadOnly = false;
            this.m_txtInHospitalDiagnose.m_BlnUnderLineDST = false;
            this.m_txtInHospitalDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalDiagnose.m_IntCanModifyTime = 6;
            this.m_txtInHospitalDiagnose.m_IntPartControlLength = 0;
            this.m_txtInHospitalDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalDiagnose.m_StrUserID = "";
            this.m_txtInHospitalDiagnose.m_StrUserName = "";
            this.m_txtInHospitalDiagnose.MaxLength = 2000;
            this.m_txtInHospitalDiagnose.Name = "m_txtInHospitalDiagnose";
            this.m_txtInHospitalDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalDiagnose.Size = new System.Drawing.Size(725, 62);
            this.m_txtInHospitalDiagnose.TabIndex = 1400;
            this.m_txtInHospitalDiagnose.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(772, 4);
            this.groupBox1.TabIndex = 10000016;
            this.groupBox1.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 260);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(735, 14);
            this.label19.TabIndex = 10000014;
            this.label19.Text = "住院经过:    (包括入院时主要病史及症状体征，有诊断意见的化验及器械检查结果，住院期间病情变化、检查及治疗";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(112, 280);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 14);
            this.label20.TabIndex = 10000017;
            this.label20.Text = "经过)";
            // 
            // m_txtInHospitalProcess
            // 
            this.m_txtInHospitalProcess.AccessibleDescription = "住院经过";
            this.m_txtInHospitalProcess.BackColor = System.Drawing.Color.White;
            this.m_txtInHospitalProcess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtInHospitalProcess.ForeColor = System.Drawing.Color.Black;
            this.m_txtInHospitalProcess.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtInHospitalProcess.Location = new System.Drawing.Point(88, 300);
            this.m_txtInHospitalProcess.m_BlnIgnoreUserInfo = false;
            this.m_txtInHospitalProcess.m_BlnPartControl = false;
            this.m_txtInHospitalProcess.m_BlnReadOnly = false;
            this.m_txtInHospitalProcess.m_BlnUnderLineDST = false;
            this.m_txtInHospitalProcess.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtInHospitalProcess.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtInHospitalProcess.m_IntCanModifyTime = 6;
            this.m_txtInHospitalProcess.m_IntPartControlLength = 0;
            this.m_txtInHospitalProcess.m_IntPartControlStartIndex = 0;
            this.m_txtInHospitalProcess.m_StrUserID = "";
            this.m_txtInHospitalProcess.m_StrUserName = "";
            this.m_txtInHospitalProcess.MaxLength = 2000;
            this.m_txtInHospitalProcess.Name = "m_txtInHospitalProcess";
            this.m_txtInHospitalProcess.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtInHospitalProcess.Size = new System.Drawing.Size(692, 48);
            this.m_txtInHospitalProcess.TabIndex = 1500;
            this.m_txtInHospitalProcess.Text = "";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 352);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(308, 14);
            this.label21.TabIndex = 10000018;
            this.label21.Text = "死亡经过:    (抢救经过、死亡时间、死亡原因)";
            // 
            // m_txtDeadProcess
            // 
            this.m_txtDeadProcess.AccessibleDescription = "死亡经过";
            this.m_txtDeadProcess.BackColor = System.Drawing.Color.White;
            this.m_txtDeadProcess.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadProcess.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadProcess.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadProcess.Location = new System.Drawing.Point(88, 372);
            this.m_txtDeadProcess.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadProcess.m_BlnPartControl = false;
            this.m_txtDeadProcess.m_BlnReadOnly = false;
            this.m_txtDeadProcess.m_BlnUnderLineDST = false;
            this.m_txtDeadProcess.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadProcess.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadProcess.m_IntCanModifyTime = 6;
            this.m_txtDeadProcess.m_IntPartControlLength = 0;
            this.m_txtDeadProcess.m_IntPartControlStartIndex = 0;
            this.m_txtDeadProcess.m_StrUserID = "";
            this.m_txtDeadProcess.m_StrUserName = "";
            this.m_txtDeadProcess.MaxLength = 2000;
            this.m_txtDeadProcess.Name = "m_txtDeadProcess";
            this.m_txtDeadProcess.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadProcess.Size = new System.Drawing.Size(692, 48);
            this.m_txtDeadProcess.TabIndex = 1600;
            this.m_txtDeadProcess.Text = "";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(12, 424);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(266, 14);
            this.label22.TabIndex = 10000018;
            this.label22.Text = "死后诊断:    (包括病理诊断、尸解结果)";
            // 
            // m_txtDeadDiagnose
            // 
            this.m_txtDeadDiagnose.AccessibleDescription = "死后诊断";
            this.m_txtDeadDiagnose.BackColor = System.Drawing.Color.White;
            this.m_txtDeadDiagnose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadDiagnose.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadDiagnose.Location = new System.Drawing.Point(88, 444);
            this.m_txtDeadDiagnose.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadDiagnose.m_BlnPartControl = false;
            this.m_txtDeadDiagnose.m_BlnReadOnly = false;
            this.m_txtDeadDiagnose.m_BlnUnderLineDST = false;
            this.m_txtDeadDiagnose.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadDiagnose.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadDiagnose.m_IntCanModifyTime = 6;
            this.m_txtDeadDiagnose.m_IntPartControlLength = 0;
            this.m_txtDeadDiagnose.m_IntPartControlStartIndex = 0;
            this.m_txtDeadDiagnose.m_StrUserID = "";
            this.m_txtDeadDiagnose.m_StrUserName = "";
            this.m_txtDeadDiagnose.MaxLength = 2000;
            this.m_txtDeadDiagnose.Name = "m_txtDeadDiagnose";
            this.m_txtDeadDiagnose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadDiagnose.Size = new System.Drawing.Size(692, 48);
            this.m_txtDeadDiagnose.TabIndex = 1700;
            this.m_txtDeadDiagnose.Text = "";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(12, 496);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(98, 14);
            this.label23.TabIndex = 10000018;
            this.label23.Text = "死亡讨论结论:";
            this.label23.Visible = false;
            // 
            // m_txtDeadVirdict
            // 
            this.m_txtDeadVirdict.AccessibleDescription = "死后诊断";
            this.m_txtDeadVirdict.BackColor = System.Drawing.Color.White;
            this.m_txtDeadVirdict.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDeadVirdict.ForeColor = System.Drawing.Color.Black;
            this.m_txtDeadVirdict.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDeadVirdict.Location = new System.Drawing.Point(88, 516);
            this.m_txtDeadVirdict.m_BlnIgnoreUserInfo = false;
            this.m_txtDeadVirdict.m_BlnPartControl = false;
            this.m_txtDeadVirdict.m_BlnReadOnly = false;
            this.m_txtDeadVirdict.m_BlnUnderLineDST = false;
            this.m_txtDeadVirdict.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDeadVirdict.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDeadVirdict.m_IntCanModifyTime = 6;
            this.m_txtDeadVirdict.m_IntPartControlLength = 0;
            this.m_txtDeadVirdict.m_IntPartControlStartIndex = 0;
            this.m_txtDeadVirdict.m_StrUserID = "";
            this.m_txtDeadVirdict.m_StrUserName = "";
            this.m_txtDeadVirdict.MaxLength = 2000;
            this.m_txtDeadVirdict.Name = "m_txtDeadVirdict";
            this.m_txtDeadVirdict.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDeadVirdict.Size = new System.Drawing.Size(692, 48);
            this.m_txtDeadVirdict.TabIndex = 1800;
            this.m_txtDeadVirdict.Text = "";
            this.m_txtDeadVirdict.Visible = false;
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(568, 517);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(56, 24);
            this.m_cmdDoctorSign.TabIndex = 10000019;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "医师:";
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleName = "NoDefault";
            this.m_txtDoctorSign.BackColor = System.Drawing.Color.White;
            this.m_txtDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDoctorSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtDoctorSign.Location = new System.Drawing.Point(644, 517);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(134, 23);
            this.m_txtDoctorSign.TabIndex = 2100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 100;
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.AccessibleDescription = "手术名称";
            this.m_txtOperationName.BackColor = System.Drawing.Color.White;
            this.m_txtOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperationName.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperationName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtOperationName.Location = new System.Drawing.Point(68, 150);
            this.m_txtOperationName.m_BlnIgnoreUserInfo = false;
            this.m_txtOperationName.m_BlnPartControl = false;
            this.m_txtOperationName.m_BlnReadOnly = false;
            this.m_txtOperationName.m_BlnUnderLineDST = false;
            this.m_txtOperationName.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtOperationName.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtOperationName.m_IntCanModifyTime = 6;
            this.m_txtOperationName.m_IntPartControlLength = 0;
            this.m_txtOperationName.m_IntPartControlStartIndex = 0;
            this.m_txtOperationName.m_StrUserID = "";
            this.m_txtOperationName.m_StrUserName = "";
            this.m_txtOperationName.MaxLength = 2000;
            this.m_txtOperationName.Name = "m_txtOperationName";
            this.m_txtOperationName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOperationName.Size = new System.Drawing.Size(468, 24);
            this.m_txtOperationName.TabIndex = 1200;
            this.m_txtOperationName.Text = "";
            // 
            // m_lblInHospitalDate
            // 
            this.m_lblInHospitalDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInHospitalDate.ForeColor = System.Drawing.Color.Black;
            this.m_lblInHospitalDate.Location = new System.Drawing.Point(285, 210);
            this.m_lblInHospitalDate.Name = "m_lblInHospitalDate";
            this.m_lblInHospitalDate.Size = new System.Drawing.Size(26, 23);
            this.m_lblInHospitalDate.TabIndex = 10000023;
            this.m_lblInHospitalDate.Visible = false;
            // 
            // frmDeathRecord
            // 
            this.AccessibleDescription = "死亡记录";
            this.ClientSize = new System.Drawing.Size(796, 673);
            this.Controls.Add(this.m_txtMRIID);
            this.Controls.Add(this.m_lblInHospitalDate);
            this.Controls.Add(this.m_txtOperationName);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_txtInHospitalDiagnose);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblFolk);
            this.Controls.Add(this.k);
            this.Controls.Add(this.m_txtCardiogramID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtXRayID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtUltrasonic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_txtBrainWaveID);
            this.Controls.Add(this.lblNative);
            this.Controls.Add(this.lblOccupation);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.m_dtpDeadDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblIsMarry);
            this.Controls.Add(this.m_dtpOperationDate);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.m_txtInHospitalProcess);
            this.Controls.Add(this.m_txtDeadProcess);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.m_txtDeadDiagnose);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.m_txtDeadVirdict);
            this.Name = "frmDeathRecord";
            this.Text = "死亡记录";
            this.Load += new System.EventHandler(this.frmDeathRecord_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_txtDeadVirdict, 0);
            this.Controls.SetChildIndex(this.label23, 0);
            this.Controls.SetChildIndex(this.m_txtDeadDiagnose, 0);
            this.Controls.SetChildIndex(this.label22, 0);
            this.Controls.SetChildIndex(this.m_txtDeadProcess, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalProcess, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.label17, 0);
            this.Controls.SetChildIndex(this.m_dtpOperationDate, 0);
            this.Controls.SetChildIndex(this.lblIsMarry, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.m_dtpDeadDate, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.lblOccupation, 0);
            this.Controls.SetChildIndex(this.lblNative, 0);
            this.Controls.SetChildIndex(this.m_txtBrainWaveID, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.m_txtUltrasonic, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_txtXRayID, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.m_txtCardiogramID, 0);
            this.Controls.SetChildIndex(this.k, 0);
            this.Controls.SetChildIndex(this.lblFolk, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label16, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
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
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtInHospitalDiagnose, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_txtOperationName, 0);
            this.Controls.SetChildIndex(this.m_lblInHospitalDate, 0);
            this.Controls.SetChildIndex(this.m_txtMRIID, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public override clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            clsDeathRecordInfo objTrackInfo = new clsDeathRecordInfo();

            objTrackInfo.m_ObjRecordContent = m_objCurrentRecordContent;//m_objGetContentFromGUI();
            //设置m_strTitle和m_dtmRecordTime
            objTrackInfo.m_DtmRecordTime = m_dtpCreateDate.Value;
            objTrackInfo.m_StrTitle = "死亡记录";

            return objTrackInfo;
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected override void m_mthClearRecordInfo()
        {
            //清空具体记录内容	
            m_strCurrentOpenDate = "";
            //lblInHospitalDays.Text = "";
            //m_lblInHospitalDate.Text = m_objBaseCurrentPatient.m_DtmLastHISInDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_txtCardiogramID.Text = "";
            m_txtXRayID.Text = "";
            m_txtUltrasonic.Text = "";
            m_txtMRIID.Text = "";
            m_txtBrainWaveID.Text = "";

            m_txtOperationName.m_mthClearText();
            m_txtInHospitalDiagnose.m_mthClearText();
            m_txtInHospitalProcess.m_mthClearText();
            m_txtDeadProcess.m_mthClearText();
            m_txtDeadDiagnose.m_mthClearText();
            m_txtDeadVirdict.m_mthClearText();

            m_txtDoctorSign.Clear();
            m_txtDoctorSign.Tag = null;
        }

        /// <summary>
        /// 设置是否控制修改（修改留痕迹）。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset">是否重置控制修改（修改留痕迹）。
        ///如果为true，忽略记录内容，把界面控制设置为不控制；
        ///否则根据记录内容进行设置。
        ///</param>
        protected override void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
            bool p_blnReset)
        {
            //根据书写规范设置具体窗体的书写控制

        }

        /// <summary>
        /// 提示没有该病人
        /// </summary>
        protected override void m_mthShowNoPatient()
        {
            clsPublicFunction.ShowInformationMessageBox("对不起，没有此病人！");
        }

        protected override void m_mthSetPatientBaseInfo(clsPatient p_objSelectedPatient)
        {
            if (p_objSelectedPatient.m_ObjPeopleInfo == null)
            {
                m_mthShowNoPatient();
                return;
            }
            //这个开关的作用是以防对m_cboArea赋值后触发其SelectedIndexChanged事件
            m_blnCanTextChanged = false;

            if (p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo != null)
            {
                //				m_cboDept.ClearItem();
                //				m_cboArea.ClearItem();
                //				m_cboDept.AddItem(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept);
                //				m_cboDept.SelectedIndex=0;
                //				clsInPatientArea objInPatientArea =new clsInPatientArea(p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName);
                //				m_cboArea.AddItem(objInPatientArea);
                //				m_cboArea.SelectedIndex=0;
                //				m_txtBedNO.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;				
                //使用新表 modified by tfzhang at 2005年10月17日 16:02:29
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
                m_cboDept.SelectedIndex = 0;

                //获取病区
                m_cboArea.ClearItem();
                string str3 = p_objSelectedPatient.m_strAreaNewID;
                if (str3.Trim().Length != 0)//病区不为空
                {
                    string str4;
                    clsEmrDept_VO objAreNew;
                    objDomain.m_lngGetSpecialAreaInfo(str3, out objAreNew);
                    str3 = objAreNew.m_strSHORTNO_CHR;
                    str4 = objAreNew.m_strDEPTNAME_VCHR;
                    clsInPatientArea objInPatientArea = new clsInPatientArea(str3, str4, objAreNew.m_strDEPTID_CHR);
                    //转换使用，新表的shortno＝旧表的ID，所以新加一个字段保存新表ID
                    objInPatientArea.m_strAreaNewID = objAreNew.m_strDEPTID_CHR;
                    m_cboArea.AddItem(objInPatientArea);
                    m_cboArea.SelectedIndex = 0;
                }

                m_txtBedNO.Text = p_objSelectedPatient.m_strBedCode;
            }
            else
            {
                m_txtBedNO.Text = "";
            }

            m_objCurrentPatient = p_objSelectedPatient;

            txtInPatientID.Text = m_objCurrentPatient.m_StrHISInPatientID;
            m_txtPatientName.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;
            //lblSex.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
            //lblAge.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge;
            //lblOccupation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;
            //lblNative.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeplace;
            //lblFolk.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrNation;
            //lblIsMarry.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrMarried;
            m_blnCanTextChanged = true;
        }
        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            //m_lblInHospitalDate.Text = p_objSelectedPatient.m_DtmLastHISInDate.ToString("yyyy-MM-dd HH:mm:ss");
            //lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrSex.Trim(); ;
            //lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrAge;
            //lblOccupation.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrOccupation;
            //lblNative.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrHomeplace;
            //lblFolk.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrNation;
            //lblIsMarry.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_ObjPeopleInfo.m_StrMarried;

            DateTime dtmEnd = m_dtmGetSetlectedOutDate();
            if (dtmEnd == DateTime.MinValue || dtmEnd == new DateTime(1900, 1, 1))
            {
                dtmEnd = DateTime.Now;   
            }

            TimeSpan ts = dtmEnd - m_objCurrentPatient.m_DtmSelectedHISInDate;
            lblInHospitalDays.Text = (ts.Days + 1).ToString() + "天";
 
        }

        #region  获取病人出院时间，暂时先在各个窗体查询
        /// <summary>
        /// 获取病人出院时间，暂时先在各个窗体查询
        /// </summary>
        /// <returns></returns>
        private DateTime m_dtmGetSetlectedOutDate()
        {
            DateTime dtmOutHospitalDate = new DateTime(1900, 1, 1);
            string strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            long lngRes = 0;
            com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));


            //lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);

            lngRes = objServ.m_lngGetOutHospitalDate(strRegisterID, out dtmOutHospitalDate);
            objServ = null;
            return dtmOutHospitalDate;
        }
        #endregion

        /// <summary>
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected override clsTrackRecordContent m_objGetContentFromGUI()
        {
            //界面参数校验
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                return null;
            
            //从界面获取表单值
            clsDeadRecord_VO objContent = new clsDeadRecord_VO();
            objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
            objContent.m_strModifyUserID = clsEMRLogin.LoginInfo.m_strEmpNo;
            #region 是否可以无痕迹修改
            if (chkModifyWithoutMatk.Checked)
                objContent.m_intMarkStatus = 0;
            else
                objContent.m_intMarkStatus = 1;
            #endregion
            objContent.m_strCardiogramID = m_txtCardiogramID.Text;
            objContent.m_strXRayID = m_txtXRayID.Text;
            objContent.m_strUltrasonicID = m_txtUltrasonic.Text;
            objContent.m_strMRIID = m_txtMRIID.Text;
            objContent.m_strBrainWaveID = m_txtBrainWaveID.Text;

            objContent.m_dtmDeadDate = m_dtpDeadDate.Value;
            objContent.m_dtmOperationDate = m_dtpOperationDate.Value;

            objContent.m_strOperationName = m_txtOperationName.Text;
            objContent.m_strOperationNameXML = m_txtOperationName.m_strGetXmlText();
            objContent.m_strInHospitalDiagnose = m_txtInHospitalDiagnose.Text;
            objContent.m_strInHospitalDiagnoseXML = m_txtInHospitalDiagnose.m_strGetXmlText();
            objContent.m_strInHospitalProcess = m_txtInHospitalProcess.Text;
            objContent.m_strInHospitalProcessXML = m_txtInHospitalProcess.m_strGetXmlText();
            objContent.m_strDeadProcess = m_txtDeadProcess.Text;
            objContent.m_strDeadProcessXML = m_txtDeadProcess.m_strGetXmlText();
            objContent.m_strDeadDiagnose = m_txtDeadDiagnose.Text;
            objContent.m_strDeadDiagnoseXML = m_txtDeadDiagnose.m_strGetXmlText();
            objContent.m_strDeadVerdict = m_txtDeadVirdict.Text;
            objContent.m_strDeadVerdictXML = m_txtDeadVirdict.m_strGetXmlText();

            if (m_txtDoctorSign.Tag != null && m_txtDoctorSign.Text.Trim() != "")
            {
                objContent.m_strDoctorID = ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();

                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDoctorID, out objEmpVO);
                m_txtDoctorSign.Text = objEmpVO.ToString();
                objContent.m_strDoctorName = m_txtDoctorSign.Text;
            }
            else
            {
                clsPublicFunction.ShowInformationMessageBox("必须医师签名!");
                return null;
            }

            return objContent;
        }


        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected override void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsDeadRecord_VO objContent = (clsDeadRecord_VO)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_strCurrentOpenDate = objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");
            lblOccupation.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrOccupation;
            lblNative.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrHomeplace;
            lblFolk.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrNation;
            lblIsMarry.Text = m_objCurrentPatient.m_ObjPeopleInfo.m_StrMarried;

            TimeSpan ts = objContent.m_dtmDeadDate - m_objCurrentPatient.m_DtmSelectedHISInDate;
            lblInHospitalDays.Text = (ts.Days + 1).ToString() + "天";

            m_txtCardiogramID.Text = objContent.m_strCardiogramID;
            m_txtXRayID.Text = objContent.m_strXRayID;
            m_txtUltrasonic.Text = objContent.m_strUltrasonicID;
            m_txtMRIID.Text = objContent.m_strMRIID;
            m_txtBrainWaveID.Text = objContent.m_strBrainWaveID;
            m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
            m_dtpOperationDate.Value = objContent.m_dtmOperationDate;

            m_txtOperationName.m_mthSetNewText(objContent.m_strOperationName, objContent.m_strOperationNameXML);
            m_txtInHospitalDiagnose.m_mthSetNewText(objContent.m_strInHospitalDiagnose, objContent.m_strInHospitalDiagnoseXML);
            m_txtInHospitalProcess.m_mthSetNewText(objContent.m_strInHospitalProcess, objContent.m_strInHospitalProcessXML);
            m_txtDeadDiagnose.m_mthSetNewText(objContent.m_strDeadDiagnose, objContent.m_strDeadDiagnoseXML);
            m_txtDeadProcess.m_mthSetNewText(objContent.m_strDeadProcess, objContent.m_strDeadProcessXML);
            m_txtDeadVirdict.m_mthSetNewText(objContent.m_strDeadVerdict, objContent.m_strDeadVerdictXML);

            #region 签名
            clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
            objEmployeeSign.m_lngGetEmpByNO(objContent.m_strDoctorID, out objEmpVO);
            if (objEmpVO != null)
            {
                m_txtDoctorSign.Tag = objEmpVO;
                m_txtDoctorSign.Text = objContent.m_strDoctorName;
            }
            #endregion 签名
        }

        /// <summary>
        /// 获取当前病人的作废内容
        /// </summary>
        /// <param name="p_dtmRecordDate">记录日期，此处表示CreateDate</param>
        /// <param name="p_intFormID">窗体ID</param>
        protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate, int p_intFormID)
        {
            if (m_objBaseCurrentPatient == null || m_objBaseCurrentPatient.m_StrInPatientID == null || m_objBaseCurrentPatient.m_DtmSelectedInDate == DateTime.MinValue || p_dtmRecordDate == DateTime.MinValue)
            {
                clsPublicFunction.ShowInformationMessageBox("参数错误！");
                return;
            }

            clsTrackRecordContent objContent = null;
            long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_dtmRecordDate.ToString("yyyy-MM-dd HH:mm:ss"), out objContent);
            if (lngRes > 0 && objContent != null)
            {
                m_mthSetDeletedGUIFromContent(objContent);
            }

        }

        public override int m_IntFormID
        {
            get
            {
                return 57;
            }
        }

        protected override void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
                return;
            clsDeadRecord_VO objContent = (clsDeadRecord_VO)p_objContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_txtCardiogramID.Text = objContent.m_strCardiogramID;
            m_txtXRayID.Text = objContent.m_strXRayID;
            m_txtUltrasonic.Text = objContent.m_strUltrasonicID;
            m_txtMRIID.Text = objContent.m_strMRIID;
            m_txtBrainWaveID.Text = objContent.m_strBrainWaveID;
            m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
            m_dtpOperationDate.Value = objContent.m_dtmOperationDate;

            m_txtOperationName.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOperationName, objContent.m_strOperationNameXML);
            m_txtInHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose, objContent.m_strInHospitalDiagnoseXML);
            m_txtInHospitalProcess.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalProcess, objContent.m_strInHospitalProcessXML);
            m_txtDeadDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose, objContent.m_strDeadDiagnoseXML);
            m_txtDeadProcess.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadProcess, objContent.m_strDeadProcessXML);
            m_txtDeadVirdict.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadVerdict, objContent.m_strDeadVerdictXML);
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected override clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.Death);
        }

        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected override void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
            clsDeadRecord_VO objContent = (clsDeadRecord_VO)p_objRecordContent;
            //把表单值赋值到界面，由子窗体重载实现
            m_txtCardiogramID.Text = objContent.m_strCardiogramID;
            m_txtXRayID.Text = objContent.m_strXRayID;
            m_txtUltrasonic.Text = objContent.m_strUltrasonicID;
            m_txtMRIID.Text = objContent.m_strMRIID;
            m_txtBrainWaveID.Text = objContent.m_strBrainWaveID;
            m_dtpDeadDate.Value = objContent.m_dtmDeadDate;
            m_dtpOperationDate.Value = objContent.m_dtmOperationDate;

            m_txtOperationName.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strOperationName, objContent.m_strOperationNameXML);
            m_txtInHospitalDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalDiagnose, objContent.m_strInHospitalDiagnoseXML);
            m_txtInHospitalProcess.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strInHospitalProcess, objContent.m_strInHospitalProcessXML);
            m_txtDeadDiagnose.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadDiagnose, objContent.m_strDeadDiagnoseXML);
            m_txtDeadProcess.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadProcess, objContent.m_strDeadProcessXML);
            m_txtDeadVirdict.Text = com.digitalwave.controls.ctlRichTextBox.s_strGetRightText(objContent.m_strDeadVerdict, objContent.m_strDeadVerdictXML);

        }

        // 获取选择已经删除记录的窗体标题
        public override string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "死亡记录";
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected override void m_mthSelectRootNode()
        {
            #region 初步诊断默认值
            if (m_objCurrentPatient != null && m_ObjCurrentEmrPatientSession != null)
            {
                DateTime dtmInDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;
                if (m_ObjLastEmrPatientSession != null)
                {
                    dtmInDate = m_ObjLastEmrPatientSession.m_dtmEMRInpatientDate;
                }

                clsInPatientCaseHisoryDefaultValue[] objInPatientCaseHisoryDefaultValueArr = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(m_objCurrentPatient.m_StrInPatientID, dtmInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                if (objInPatientCaseHisoryDefaultValueArr != null && objInPatientCaseHisoryDefaultValueArr.Length > 0)
                {
                    m_txtInHospitalDiagnose.Text = objInPatientCaseHisoryDefaultValueArr[0].m_strPrimaryDiagnose;
                }
            }
            #endregion 初步诊断默认值
        }

        #region 医师签名
        private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:// enter
                    break;

                case 38:
                case 40:
                    break;
                case 113://save
                    this.Save();
                    break;
                case 114://del
                    this.Delete();
                    break;
                case 115://print
                    this.Print();
                    break;
                case 116://refresh
                    m_mthClearUp();
                    break;
                case 117://Search					
                    break;
            }
        }

        #endregion 医师签名

        #region 添加键盘快捷键
        private void m_mthSetQuickKeys()
        {
            m_mthSetControlEvent(this);
        }

        private void m_mthSetControlEvent(Control p_ctlControl)
        {
            #region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName != "Lable" && strTypeName != "Button")
            {
                p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
                if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker" && strTypeName != "ctlComboBox")
                {
                    foreach (Control subcontrol in p_ctlControl.Controls)
                    {
                        m_mthSetControlEvent(subcontrol);
                    }
                }
            }
            #endregion
        }
        #region 清空窗体内容
        /// <summary>
        /// 清空除当前控件以外的所有窗体内容,(可覆盖提供新的实现)
        /// </summary>
        /// <param name="p_ctlControl"></param>
        /// <param name="p_blnReadOnly"></param>
        protected override void m_mthClearAllInfo(Control p_ctlControl)
        {
            if (p_ctlControl == null || m_lblInHospitalDate == null) return;
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
            {
                if (p_ctlControl is iCare.CustomForm.ctlRichTextBox)//自定义表单中的cltRichTextBox
                    ((iCare.CustomForm.ctlRichTextBox)p_ctlControl).Text = "";
                else
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
            m_lblInHospitalDate.Text = "";
            if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthClearAllInfo(subcontrol);
                }
            }
        }


        private void m_mthClearUpInControl(Control p_ctlControl)
        {
            string strTypeName = p_ctlControl.GetType().Name;
            if (strTypeName == "ctlRichTextBox")
                ((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_mthClearText();
            else if (strTypeName == "ctlBorderTextBox")
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

            if (p_ctlControl.HasChildren && strTypeName != "DataGrid" && strTypeName != "DateTimePicker")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthClearUpInControl(subcontrol);
                }
            }
        }

        private void m_mthClearUp()
        {
            m_mthClearUpInControl(this);
            m_lblInHospitalDate.Text = "";
            m_mthClearPatientBaseInfo();
        }
        #endregion

        #endregion

        private void cmdConfirm_Click(object sender, System.EventArgs e)
        {
            if (m_lngSave() > 0)
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void frmDeathRecord_Load(object sender, System.EventArgs e)
        {
            m_mthfrmLoad();
            if (m_objCurrentPatient != null)
            {
                m_lblInHospitalDate.Text = m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日");
            }

            this.m_dtpCreateDate.m_EnmVisibleFlag = MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
            this.m_dtpCreateDate.m_mthResetSize();

            m_trvCreateDate.Focus();
        }

        protected override void m_mthSetPatientInHospitalDate(clsPatient p_objSelectedPatient)
        {
            //判断病人信息是否为null，如果是，直接返回。
            if (p_objSelectedPatient == null)
                return;

            //记录病人信息
            m_objCurrentPatient = p_objSelectedPatient;
            m_lblInHospitalDate.Text = m_objCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日");

        }

        private void m_cmdClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
            clsInPatientCaseHisoryDefaultValue[] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString());
            if (objInPatientCaseDefaultValue != null && objInPatientCaseDefaultValue.Length > 0)
            {
                this.m_txtInHospitalDiagnose.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
            }
        }

        #region 审核
        private string m_strCurrentOpenDate = "";
        protected override string m_StrCurrentOpenDate
        {
            get
            {
                if (m_strCurrentOpenDate == "")
                {
                    clsPublicFunction.ShowInformationMessageBox("请先选择记录");
                    return "";
                }
                return m_strCurrentOpenDate;

            }
        }

        protected override bool m_BlnCanApprove
        {
            get
            {
                return true;
            }
        }
        #endregion


        #region 属性
        protected override enmApproveType m_EnmAppType
        {
            get { return enmApproveType.CaseHistory; }
        }
        protected override string m_StrRecorder_ID
        {
            get
            {
                if (m_txtDoctorSign.Tag != null)
                    return ((clsEmrEmployeeBase_VO)m_txtDoctorSign.Tag).m_strEMPNO_CHR.Trim();
                return "";
            }
        }
        #endregion 属性

        #region 外部打印.

        //System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private void m_mthfrmLoad()
        {
            if (m_pdcPrintDocument == null)
                this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
            this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
        }
        private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrintTool.m_mthPrintPage(e);
        }

        private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthBeginPrint(e);
        }

        private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            objPrintTool.m_mthEndPrint(e);
        }

        //		private bool m_blnHasInitPrintTool=false;
        clsDeathrecordPrintTool objPrintTool;
        private void m_mthDemoPrint_FromDataSource()
        {
            //			if(m_blnHasInitPrintTool==false)
            //			{
            objPrintTool = new clsDeathrecordPrintTool();
            objPrintTool.m_mthInitPrintTool(null);
            //				m_blnHasInitPrintTool=true;
            //			}
            if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
            else 
            {
                m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                if (m_objCurrentRecordContent == null)
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                else
                    objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objBaseCurrentPatient.m_DtmSelectedInDate, m_objCurrentRecordContent.m_dtmOpenDate);
            }
            objPrintTool.m_mthInitPrintContent();

            m_mthStartPrint_this();
        }

        private void m_mthStartPrint_this()
        {
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
        }

        protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
        {
            m_mthDemoPrint_FromDataSource();
            return 1;
        }
        #endregion 外部打印.

        protected override void m_mthInitJump(clsJumpControl p_objJump)
        {
            p_objJump = new clsJumpControl(this,
                new Control[]{m_cboDept,m_cboArea,m_txtBedNO,txtInPatientID,m_txtCardiogramID,m_txtXRayID,
								 m_txtUltrasonic,m_txtBrainWaveID,m_txtMRIID,m_txtPatientName,m_txtOperationName,
								 m_txtInHospitalDiagnose,m_txtInHospitalProcess,m_txtDeadProcess,m_txtDeadDiagnose,
								 m_txtDeadVirdict}, Keys.Enter);
            p_objJump.m_BlnCanCycle = false;
        }
    }
}
