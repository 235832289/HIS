using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.clsGeneralNurseRecord_GXService;
using com.digitalwave.Utility.Controls;
using iCare.iCareBaseForm;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
    partial class frmAYQBabyAssessmentRecord_Rec
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label40 = new System.Windows.Forms.Label();
            this.m_dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.label32 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancle = new PinkieControls.ButtonXP();
            this.m_txtDoctorSign = new System.Windows.Forms.TextBox();
            this.m_ctlFaceColor = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlYeShi = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlSiZhiHuoDong = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlHuXi = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlPiFu = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlDaBian = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlFanYing = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlJinShi = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlHuangDan = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlXiaoBian = new com.digitalwave.controls.ctlRichTextBox();
            this.m_ctlQiBu = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(550, 23);
            this.lblSex.Size = new System.Drawing.Size(37, 10);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(535, 20);
            this.lblAge.Size = new System.Drawing.Size(41, 10);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(580, 23);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(571, 24);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(587, 30);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(545, 15);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(532, 15);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(510, 42);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(540, 15);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(116, 30);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(538, 22);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(535, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(554, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(540, 22);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(538, 15);
            this.m_lsvPatientName.Size = new System.Drawing.Size(116, 29);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(558, 21);
            this.m_lsvBedNO.Size = new System.Drawing.Size(116, 23);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(530, 17);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(587, 27);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(514, 15);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(73, 22);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(590, 21);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(574, 20);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(549, 6);
            this.m_lblForTitle.Size = new System.Drawing.Size(10, 13);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(298, 16);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(392, 14);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(549, 29);
            this.m_pnlNewBase.Size = new System.Drawing.Size(105, 12);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(103, 0);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label40.Location = new System.Drawing.Point(24, 21);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(42, 14);
            this.label40.TabIndex = 10000105;
            this.label40.Text = "日期:";
            // 
            // m_dtpRecordTime
            // 
            this.m_dtpRecordTime.AccessibleDescription = "记录日期";
            this.m_dtpRecordTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpRecordTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpRecordTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpRecordTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpRecordTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpRecordTime.Location = new System.Drawing.Point(69, 17);
            this.m_dtpRecordTime.m_BlnOnlyTime = false;
            this.m_dtpRecordTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpRecordTime.Name = "m_dtpRecordTime";
            this.m_dtpRecordTime.ReadOnly = false;
            this.m_dtpRecordTime.Size = new System.Drawing.Size(215, 22);
            this.m_dtpRecordTime.TabIndex = 10000106;
            this.m_dtpRecordTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpRecordTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label32.Location = new System.Drawing.Point(50, 67);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(49, 14);
            this.label32.TabIndex = 10000108;
            this.label32.Text = "面色：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label1.Location = new System.Drawing.Point(205, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 10000108;
            this.label1.Text = "呼吸：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label2.Location = new System.Drawing.Point(361, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 10000108;
            this.label2.Text = "反应：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label3.Location = new System.Drawing.Point(532, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 10000108;
            this.label3.Text = "进食：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(50, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 10000108;
            this.label4.Text = "腋温：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(205, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 10000108;
            this.label5.Text = "皮肤：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label6.Location = new System.Drawing.Point(361, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 10000108;
            this.label6.Text = "黄疸：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label7.Location = new System.Drawing.Point(532, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 10000108;
            this.label7.Text = "脐部：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label8.Location = new System.Drawing.Point(22, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 10000108;
            this.label8.Text = "四肢活动：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label9.Location = new System.Drawing.Point(205, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 14);
            this.label9.TabIndex = 10000108;
            this.label9.Text = "大便：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label10.Location = new System.Drawing.Point(361, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 10000108;
            this.label10.Text = "小便：";
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.AccessibleDescription = "签名(cmd)";
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(53, 193);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(75, 37);
            this.m_cmdDoctorSign.TabIndex = 10000115;
            this.m_cmdDoctorSign.Tag = "1";
            this.m_cmdDoctorSign.Text = "签名:";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.AccessibleDescription = "确定";
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(451, 193);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(74, 37);
            this.m_cmdOK.TabIndex = 10000114;
            this.m_cmdOK.Tag = "1";
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancle
            // 
            this.m_cmdCancle.AccessibleDescription = "取消";
            this.m_cmdCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancle.DefaultScheme = true;
            this.m_cmdCancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdCancle.Hint = "";
            this.m_cmdCancle.Location = new System.Drawing.Point(554, 193);
            this.m_cmdCancle.Name = "m_cmdCancle";
            this.m_cmdCancle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancle.Size = new System.Drawing.Size(75, 37);
            this.m_cmdCancle.TabIndex = 10000113;
            this.m_cmdCancle.Tag = "1";
            this.m_cmdCancle.Text = "取消";
            this.m_cmdCancle.Click += new System.EventHandler(this.m_cmdCancle_Click);
            // 
            // m_txtDoctorSign
            // 
            this.m_txtDoctorSign.AccessibleDescription = "签名(txt)";
            this.m_txtDoctorSign.Location = new System.Drawing.Point(135, 201);
            this.m_txtDoctorSign.Name = "m_txtDoctorSign";
            this.m_txtDoctorSign.ReadOnly = true;
            this.m_txtDoctorSign.Size = new System.Drawing.Size(100, 23);
            this.m_txtDoctorSign.TabIndex = 10000116;
            // 
            // m_ctlFaceColor
            // 
            this.m_ctlFaceColor.AccessibleDescription = "面色";
            this.m_ctlFaceColor.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlFaceColor.Location = new System.Drawing.Point(93, 64);
            this.m_ctlFaceColor.m_BlnIgnoreUserInfo = true;
            this.m_ctlFaceColor.m_BlnPartControl = false;
            this.m_ctlFaceColor.m_BlnReadOnly = false;
            this.m_ctlFaceColor.m_BlnUnderLineDST = false;
            this.m_ctlFaceColor.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlFaceColor.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlFaceColor.m_IntCanModifyTime = 500;
            this.m_ctlFaceColor.m_IntPartControlLength = 0;
            this.m_ctlFaceColor.m_IntPartControlStartIndex = 0;
            this.m_ctlFaceColor.m_StrUserID = "";
            this.m_ctlFaceColor.m_StrUserName = "";
            this.m_ctlFaceColor.Name = "m_ctlFaceColor";
            this.m_ctlFaceColor.Size = new System.Drawing.Size(100, 26);
            this.m_ctlFaceColor.TabIndex = 10000117;
            this.m_ctlFaceColor.Text = "";
            // 
            // m_ctlYeShi
            // 
            this.m_ctlYeShi.AccessibleDescription = "腋湿";
            this.m_ctlYeShi.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlYeShi.Location = new System.Drawing.Point(93, 103);
            this.m_ctlYeShi.m_BlnIgnoreUserInfo = true;
            this.m_ctlYeShi.m_BlnPartControl = false;
            this.m_ctlYeShi.m_BlnReadOnly = false;
            this.m_ctlYeShi.m_BlnUnderLineDST = false;
            this.m_ctlYeShi.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlYeShi.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlYeShi.m_IntCanModifyTime = 500;
            this.m_ctlYeShi.m_IntPartControlLength = 0;
            this.m_ctlYeShi.m_IntPartControlStartIndex = 0;
            this.m_ctlYeShi.m_StrUserID = "";
            this.m_ctlYeShi.m_StrUserName = "";
            this.m_ctlYeShi.Name = "m_ctlYeShi";
            this.m_ctlYeShi.Size = new System.Drawing.Size(100, 26);
            this.m_ctlYeShi.TabIndex = 10000117;
            this.m_ctlYeShi.Text = "";
            // 
            // m_ctlSiZhiHuoDong
            // 
            this.m_ctlSiZhiHuoDong.AccessibleDescription = "四肢活动";
            this.m_ctlSiZhiHuoDong.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlSiZhiHuoDong.Location = new System.Drawing.Point(93, 142);
            this.m_ctlSiZhiHuoDong.m_BlnIgnoreUserInfo = true;
            this.m_ctlSiZhiHuoDong.m_BlnPartControl = false;
            this.m_ctlSiZhiHuoDong.m_BlnReadOnly = false;
            this.m_ctlSiZhiHuoDong.m_BlnUnderLineDST = false;
            this.m_ctlSiZhiHuoDong.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlSiZhiHuoDong.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlSiZhiHuoDong.m_IntCanModifyTime = 500;
            this.m_ctlSiZhiHuoDong.m_IntPartControlLength = 0;
            this.m_ctlSiZhiHuoDong.m_IntPartControlStartIndex = 0;
            this.m_ctlSiZhiHuoDong.m_StrUserID = "";
            this.m_ctlSiZhiHuoDong.m_StrUserName = "";
            this.m_ctlSiZhiHuoDong.Name = "m_ctlSiZhiHuoDong";
            this.m_ctlSiZhiHuoDong.Size = new System.Drawing.Size(100, 26);
            this.m_ctlSiZhiHuoDong.TabIndex = 10000117;
            this.m_ctlSiZhiHuoDong.Text = "";
            // 
            // m_ctlHuXi
            // 
            this.m_ctlHuXi.AccessibleDescription = "呼吸";
            this.m_ctlHuXi.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlHuXi.Location = new System.Drawing.Point(248, 63);
            this.m_ctlHuXi.m_BlnIgnoreUserInfo = true;
            this.m_ctlHuXi.m_BlnPartControl = false;
            this.m_ctlHuXi.m_BlnReadOnly = false;
            this.m_ctlHuXi.m_BlnUnderLineDST = false;
            this.m_ctlHuXi.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlHuXi.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlHuXi.m_IntCanModifyTime = 500;
            this.m_ctlHuXi.m_IntPartControlLength = 0;
            this.m_ctlHuXi.m_IntPartControlStartIndex = 0;
            this.m_ctlHuXi.m_StrUserID = "";
            this.m_ctlHuXi.m_StrUserName = "";
            this.m_ctlHuXi.Name = "m_ctlHuXi";
            this.m_ctlHuXi.Size = new System.Drawing.Size(100, 26);
            this.m_ctlHuXi.TabIndex = 10000117;
            this.m_ctlHuXi.Text = "";
            // 
            // m_ctlPiFu
            // 
            this.m_ctlPiFu.AccessibleDescription = "皮肤";
            this.m_ctlPiFu.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlPiFu.Location = new System.Drawing.Point(248, 103);
            this.m_ctlPiFu.m_BlnIgnoreUserInfo = true;
            this.m_ctlPiFu.m_BlnPartControl = false;
            this.m_ctlPiFu.m_BlnReadOnly = false;
            this.m_ctlPiFu.m_BlnUnderLineDST = false;
            this.m_ctlPiFu.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlPiFu.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlPiFu.m_IntCanModifyTime = 500;
            this.m_ctlPiFu.m_IntPartControlLength = 0;
            this.m_ctlPiFu.m_IntPartControlStartIndex = 0;
            this.m_ctlPiFu.m_StrUserID = "";
            this.m_ctlPiFu.m_StrUserName = "";
            this.m_ctlPiFu.Name = "m_ctlPiFu";
            this.m_ctlPiFu.Size = new System.Drawing.Size(100, 26);
            this.m_ctlPiFu.TabIndex = 10000117;
            this.m_ctlPiFu.Text = "";
            // 
            // m_ctlDaBian
            // 
            this.m_ctlDaBian.AccessibleDescription = "大便";
            this.m_ctlDaBian.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlDaBian.Location = new System.Drawing.Point(248, 141);
            this.m_ctlDaBian.m_BlnIgnoreUserInfo = true;
            this.m_ctlDaBian.m_BlnPartControl = false;
            this.m_ctlDaBian.m_BlnReadOnly = false;
            this.m_ctlDaBian.m_BlnUnderLineDST = false;
            this.m_ctlDaBian.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlDaBian.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlDaBian.m_IntCanModifyTime = 500;
            this.m_ctlDaBian.m_IntPartControlLength = 0;
            this.m_ctlDaBian.m_IntPartControlStartIndex = 0;
            this.m_ctlDaBian.m_StrUserID = "";
            this.m_ctlDaBian.m_StrUserName = "";
            this.m_ctlDaBian.Name = "m_ctlDaBian";
            this.m_ctlDaBian.Size = new System.Drawing.Size(100, 26);
            this.m_ctlDaBian.TabIndex = 10000117;
            this.m_ctlDaBian.Text = "";
            // 
            // m_ctlFanYing
            // 
            this.m_ctlFanYing.AccessibleDescription = "反应";
            this.m_ctlFanYing.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlFanYing.Location = new System.Drawing.Point(404, 62);
            this.m_ctlFanYing.m_BlnIgnoreUserInfo = true;
            this.m_ctlFanYing.m_BlnPartControl = false;
            this.m_ctlFanYing.m_BlnReadOnly = false;
            this.m_ctlFanYing.m_BlnUnderLineDST = false;
            this.m_ctlFanYing.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlFanYing.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlFanYing.m_IntCanModifyTime = 500;
            this.m_ctlFanYing.m_IntPartControlLength = 0;
            this.m_ctlFanYing.m_IntPartControlStartIndex = 0;
            this.m_ctlFanYing.m_StrUserID = "";
            this.m_ctlFanYing.m_StrUserName = "";
            this.m_ctlFanYing.Name = "m_ctlFanYing";
            this.m_ctlFanYing.Size = new System.Drawing.Size(100, 26);
            this.m_ctlFanYing.TabIndex = 10000117;
            this.m_ctlFanYing.Text = "";
            // 
            // m_ctlJinShi
            // 
            this.m_ctlJinShi.AccessibleDescription = "进食";
            this.m_ctlJinShi.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlJinShi.Location = new System.Drawing.Point(574, 64);
            this.m_ctlJinShi.m_BlnIgnoreUserInfo = true;
            this.m_ctlJinShi.m_BlnPartControl = false;
            this.m_ctlJinShi.m_BlnReadOnly = false;
            this.m_ctlJinShi.m_BlnUnderLineDST = false;
            this.m_ctlJinShi.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlJinShi.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlJinShi.m_IntCanModifyTime = 500;
            this.m_ctlJinShi.m_IntPartControlLength = 0;
            this.m_ctlJinShi.m_IntPartControlStartIndex = 0;
            this.m_ctlJinShi.m_StrUserID = "";
            this.m_ctlJinShi.m_StrUserName = "";
            this.m_ctlJinShi.Name = "m_ctlJinShi";
            this.m_ctlJinShi.Size = new System.Drawing.Size(100, 26);
            this.m_ctlJinShi.TabIndex = 10000117;
            this.m_ctlJinShi.Text = "";
            // 
            // m_ctlHuangDan
            // 
            this.m_ctlHuangDan.AccessibleDescription = "黄疸";
            this.m_ctlHuangDan.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlHuangDan.Location = new System.Drawing.Point(404, 103);
            this.m_ctlHuangDan.m_BlnIgnoreUserInfo = true;
            this.m_ctlHuangDan.m_BlnPartControl = false;
            this.m_ctlHuangDan.m_BlnReadOnly = false;
            this.m_ctlHuangDan.m_BlnUnderLineDST = false;
            this.m_ctlHuangDan.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlHuangDan.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlHuangDan.m_IntCanModifyTime = 500;
            this.m_ctlHuangDan.m_IntPartControlLength = 0;
            this.m_ctlHuangDan.m_IntPartControlStartIndex = 0;
            this.m_ctlHuangDan.m_StrUserID = "";
            this.m_ctlHuangDan.m_StrUserName = "";
            this.m_ctlHuangDan.Name = "m_ctlHuangDan";
            this.m_ctlHuangDan.Size = new System.Drawing.Size(100, 26);
            this.m_ctlHuangDan.TabIndex = 10000117;
            this.m_ctlHuangDan.Text = "";
            // 
            // m_ctlXiaoBian
            // 
            this.m_ctlXiaoBian.AccessibleDescription = "小便";
            this.m_ctlXiaoBian.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlXiaoBian.Location = new System.Drawing.Point(403, 141);
            this.m_ctlXiaoBian.m_BlnIgnoreUserInfo = true;
            this.m_ctlXiaoBian.m_BlnPartControl = false;
            this.m_ctlXiaoBian.m_BlnReadOnly = false;
            this.m_ctlXiaoBian.m_BlnUnderLineDST = false;
            this.m_ctlXiaoBian.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlXiaoBian.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlXiaoBian.m_IntCanModifyTime = 500;
            this.m_ctlXiaoBian.m_IntPartControlLength = 0;
            this.m_ctlXiaoBian.m_IntPartControlStartIndex = 0;
            this.m_ctlXiaoBian.m_StrUserID = "";
            this.m_ctlXiaoBian.m_StrUserName = "";
            this.m_ctlXiaoBian.Name = "m_ctlXiaoBian";
            this.m_ctlXiaoBian.Size = new System.Drawing.Size(100, 26);
            this.m_ctlXiaoBian.TabIndex = 10000117;
            this.m_ctlXiaoBian.Text = "";
            // 
            // m_ctlQiBu
            // 
            this.m_ctlQiBu.AccessibleDescription = "脐部";
            this.m_ctlQiBu.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_ctlQiBu.Location = new System.Drawing.Point(574, 103);
            this.m_ctlQiBu.m_BlnIgnoreUserInfo = true;
            this.m_ctlQiBu.m_BlnPartControl = false;
            this.m_ctlQiBu.m_BlnReadOnly = false;
            this.m_ctlQiBu.m_BlnUnderLineDST = false;
            this.m_ctlQiBu.m_ClrDST = System.Drawing.Color.Red;
            this.m_ctlQiBu.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_ctlQiBu.m_IntCanModifyTime = 500;
            this.m_ctlQiBu.m_IntPartControlLength = 0;
            this.m_ctlQiBu.m_IntPartControlStartIndex = 0;
            this.m_ctlQiBu.m_StrUserID = "";
            this.m_ctlQiBu.m_StrUserName = "";
            this.m_ctlQiBu.Name = "m_ctlQiBu";
            this.m_ctlQiBu.Size = new System.Drawing.Size(100, 26);
            this.m_ctlQiBu.TabIndex = 10000117;
            this.m_ctlQiBu.Text = "";
            // 
            // frmAYQBabyAssessmentRecord_Rec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 270);
            this.Controls.Add(this.m_ctlSiZhiHuoDong);
            this.Controls.Add(this.m_ctlYeShi);
            this.Controls.Add(this.m_ctlDaBian);
            this.Controls.Add(this.m_ctlPiFu);
            this.Controls.Add(this.m_ctlQiBu);
            this.Controls.Add(this.m_ctlJinShi);
            this.Controls.Add(this.m_ctlXiaoBian);
            this.Controls.Add(this.m_ctlHuangDan);
            this.Controls.Add(this.m_ctlFanYing);
            this.Controls.Add(this.m_ctlHuXi);
            this.Controls.Add(this.m_ctlFaceColor);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancle);
            this.Controls.Add(this.m_txtDoctorSign);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.m_dtpRecordTime);
            this.Name = "frmAYQBabyAssessmentRecord_Rec";
            this.Text = "爱婴区婴儿评估表--评估内容";
            this.Load += new System.EventHandler(this.frmAYQBabyAssessmentRecord_Rec_Load);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_dtpRecordTime, 0);
            this.Controls.SetChildIndex(this.label40, 0);
            this.Controls.SetChildIndex(this.label32, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.m_txtDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_cmdCancle, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.m_cmdDoctorSign, 0);
            this.Controls.SetChildIndex(this.m_ctlFaceColor, 0);
            this.Controls.SetChildIndex(this.m_ctlHuXi, 0);
            this.Controls.SetChildIndex(this.m_ctlFanYing, 0);
            this.Controls.SetChildIndex(this.m_ctlHuangDan, 0);
            this.Controls.SetChildIndex(this.m_ctlXiaoBian, 0);
            this.Controls.SetChildIndex(this.m_ctlJinShi, 0);
            this.Controls.SetChildIndex(this.m_ctlQiBu, 0);
            this.Controls.SetChildIndex(this.m_ctlPiFu, 0);
            this.Controls.SetChildIndex(this.m_ctlDaBian, 0);
            this.Controls.SetChildIndex(this.m_ctlYeShi, 0);
            this.Controls.SetChildIndex(this.m_ctlSiZhiHuoDong, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label40;
        public com.digitalwave.Utility.Controls.ctlTimePicker m_dtpRecordTime;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private PinkieControls.ButtonXP m_cmdDoctorSign;
        private PinkieControls.ButtonXP m_cmdOK;
        private PinkieControls.ButtonXP m_cmdCancle;
        private System.Windows.Forms.TextBox m_txtDoctorSign;
        private clsEmployeeSignTool m_objSignTool;
        private clsAYQBabyAssessmentContentDomain m_objDomain;
        private clsAYQBabyAssessmentContent m_objCurrentRecord;
        private bool m_blnIsNew;
        private string m_strOpenTime;
        private string m_strInPatientDate;
        private string m_strMotherID;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private com.digitalwave.controls.ctlRichTextBox m_ctlFaceColor;
        private com.digitalwave.controls.ctlRichTextBox m_ctlYeShi;
        private com.digitalwave.controls.ctlRichTextBox m_ctlSiZhiHuoDong;
        private com.digitalwave.controls.ctlRichTextBox m_ctlHuXi;
        private com.digitalwave.controls.ctlRichTextBox m_ctlPiFu;
        private com.digitalwave.controls.ctlRichTextBox m_ctlDaBian;
        private com.digitalwave.controls.ctlRichTextBox m_ctlFanYing;
        private com.digitalwave.controls.ctlRichTextBox m_ctlJinShi;
        private com.digitalwave.controls.ctlRichTextBox m_ctlHuangDan;
        private com.digitalwave.controls.ctlRichTextBox m_ctlXiaoBian;
        private com.digitalwave.controls.ctlRichTextBox m_ctlQiBu;
    }
}