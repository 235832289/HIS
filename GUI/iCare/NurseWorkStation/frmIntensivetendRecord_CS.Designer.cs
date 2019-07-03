namespace iCare
{
    partial class frmIntensivetendRecord_CS
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
            this.label1 = new System.Windows.Forms.Label();
            this.clmRecordDateofDay = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmCreateTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcBoxTemperature = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTemperature = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHeartRate = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRespiration = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBloodPress = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSPO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcMind = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPupilSizeLeft = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPupilSizeRight = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPupilReflectLeft = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcPupilReflectRight = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFontanel = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFace = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSkinColor = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSkinEdema = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSkinLasticity = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSkinPattern = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSkinEdemaPosition = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSkinEdemaProperty = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInceptKind = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInceptMete = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEductionKind = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEductionMete = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.clmRecordSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgtsStyles
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmRecordDateofDay,
																										 this.clmCreateTime,
                                                                                                         this.m_dtcBoxTemperature,
																										 this.m_dtcTemperature,
																										 this.m_dtcHeartRate,
																										 this.m_dtcRespiration,
																										 this.m_dtcBloodPress,
																										 this.m_dtcSPO2,
                                                                                                         this.m_dtcMind,
                                                                                                         this.m_dtcPupilSizeLeft,
                                                                                                         this.m_dtcPupilSizeRight,
																										 this.m_dtcPupilReflectLeft,
																										 this.m_dtcPupilReflectRight,
                                                                                                         this.m_dtcFontanel,
                                                                                                         this.m_dtcFace,
                                                                                                         this.m_dtcSkinColor,
                                                                                                         this.m_dtcSkinEdema,
                                                                                                         this.m_dtcSkinLasticity,
                                                                                                         this.m_dtcSkinPattern,
                                                                                                         this.m_dtcSkinEdemaPosition,
                                                                                                         this.m_dtcSkinEdemaProperty,      
																										 this.m_dtcInceptKind,
																										 this.m_dtcInceptMete,
																										 this.m_dtcEductionKind,
																										 this.m_dtcEductionMete,
                                                                                                         this.m_dtcContent,
																										 this.clmRecordSign,
																										 });
            this.dgtsStyles.RowHeaderWidth = 15;
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(15, 78);
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(783, 495);
            this.m_dtgRecordDetail.CurrentCellChanged += new System.EventHandler(this.m_dtgRecordDetail_CurrentCellChanged);
            this.m_dtgRecordDetail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_dtgRecordDetail_MouseUp);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(841, 23);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(25, 10);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(845, 25);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(850, 24);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(853, 20);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(820, 23);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(845, 23);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(853, 24);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(845, 24);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(834, 23);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(856, 33);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(18, 10);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(856, 24);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(856, 21);
            this.m_txtPatientName.Size = new System.Drawing.Size(10, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(848, 20);
            this.m_txtBedNO.Size = new System.Drawing.Size(18, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(837, 24);
            this.m_cboArea.Size = new System.Drawing.Size(21, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(848, 20);
            this.m_lsvPatientName.Size = new System.Drawing.Size(10, 14);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(856, 21);
            this.m_lsvBedNO.Size = new System.Drawing.Size(18, 10);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(853, 15);
            this.m_cboDept.Size = new System.Drawing.Size(21, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(832, 23);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(835, 12);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(842, 12);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(848, 17);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(845, 14);
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(730, 36);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(793, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(791, 29);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 585);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(623, 14);
            this.label1.TabIndex = 10000006;
            this.label1.Text = "注：SpO2指经皮血氧饱和度（脉动血氧饱和度）；瞳孔对光反射用符号表示：灵敏+  迟钝±  消失-";
            // 
            // clmRecordDateofDay
            // 
            this.clmRecordDateofDay.Format = "";
            this.clmRecordDateofDay.FormatInfo = null;
            this.clmRecordDateofDay.MappingName = "RecordDateofDay";
            this.clmRecordDateofDay.Width = 80;
            // 
            // clmCreateTime
            // 
            this.clmCreateTime.Format = "";
            this.clmCreateTime.FormatInfo = null;
            this.clmCreateTime.MappingName = "RecordTime";
            this.clmCreateTime.Width = 60;
            // 
            // m_dtcBoxTemperature
            // 
            this.m_dtcBoxTemperature.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBoxTemperature.m_BlnGobleSet = true;
            this.m_dtcBoxTemperature.m_BlnUnderLineDST = false;
            this.m_dtcBoxTemperature.MappingName = "BoxTemperature";
            this.m_dtcBoxTemperature.Width = 50;
            // 
            // m_dtcTemperature
            // 
            this.m_dtcTemperature.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcTemperature.m_BlnGobleSet = true;
            this.m_dtcTemperature.m_BlnUnderLineDST = false;
            this.m_dtcTemperature.MappingName = "Temperature";
            this.m_dtcTemperature.Width = 50;
            // 
            // m_dtcHeartRate
            // 
            this.m_dtcHeartRate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcHeartRate.m_BlnGobleSet = true;
            this.m_dtcHeartRate.m_BlnUnderLineDST = false;
            this.m_dtcHeartRate.MappingName = "HeartRate";
            this.m_dtcHeartRate.Width = 50;
            // 
            // m_dtcRespiration
            // 
            this.m_dtcRespiration.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcRespiration.m_BlnGobleSet = true;
            this.m_dtcRespiration.m_BlnUnderLineDST = false;
            this.m_dtcRespiration.MappingName = "Respiration";
            this.m_dtcRespiration.Width = 50;
            // 
            // m_dtcBloodPress
            // 
            this.m_dtcBloodPress.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcBloodPress.m_BlnGobleSet = true;
            this.m_dtcBloodPress.m_BlnUnderLineDST = false;
            this.m_dtcBloodPress.MappingName = "BloodPress";
            this.m_dtcBloodPress.Width = 60;
            // 
            // m_dtcSPO2
            // 
            this.m_dtcSPO2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSPO2.m_BlnGobleSet = true;
            this.m_dtcSPO2.m_BlnUnderLineDST = false;
            this.m_dtcSPO2.MappingName = "SPO2";
            this.m_dtcSPO2.Width = 50;
            // 
            // m_dtcMind
            // 
            this.m_dtcMind.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcMind.m_BlnGobleSet = true;
            this.m_dtcMind.m_BlnUnderLineDST = false;
            this.m_dtcMind.MappingName = "Mind";
            this.m_dtcMind.Width = 50;
            // 
            // m_dtcPupilSizeLeft
            // 
            this.m_dtcPupilSizeLeft.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPupilSizeLeft.m_BlnGobleSet = true;
            this.m_dtcPupilSizeLeft.m_BlnUnderLineDST = false;
            this.m_dtcPupilSizeLeft.MappingName = "Pupil_SizeLeft";
            this.m_dtcPupilSizeLeft.Width = 50;
            // 
            // m_dtcPupilSizeRight
            // 
            this.m_dtcPupilSizeRight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPupilSizeRight.m_BlnGobleSet = true;
            this.m_dtcPupilSizeRight.m_BlnUnderLineDST = false;
            this.m_dtcPupilSizeRight.MappingName = "Pupil_SizeRight";
            this.m_dtcPupilSizeRight.Width = 50;
            // 
            // m_dtcPupilReflectLeft
            // 
            this.m_dtcPupilReflectLeft.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPupilReflectLeft.m_BlnGobleSet = true;
            this.m_dtcPupilReflectLeft.m_BlnUnderLineDST = false;
            this.m_dtcPupilReflectLeft.MappingName = "Pupil_ReflectLeft";
            this.m_dtcPupilReflectLeft.Width = 50;
            // 
            // m_dtcPupilReflectRight
            // 
            this.m_dtcPupilReflectRight.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcPupilReflectRight.m_BlnGobleSet = true;
            this.m_dtcPupilReflectRight.m_BlnUnderLineDST = false;
            this.m_dtcPupilReflectRight.MappingName = "Pupil_ReflectRight";
            this.m_dtcPupilReflectRight.Width = 50;
            // 
            // m_dtcFontanel
            // 
            this.m_dtcFontanel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFontanel.m_BlnGobleSet = true;
            this.m_dtcFontanel.m_BlnUnderLineDST = false;
            this.m_dtcFontanel.MappingName = "Fontanel";
            this.m_dtcFontanel.Width = 50;
            // 
            // m_dtcFace
            // 
            this.m_dtcFace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFace.m_BlnGobleSet = true;
            this.m_dtcFace.m_BlnUnderLineDST = false;
            this.m_dtcFace.MappingName = "Face";
            this.m_dtcFace.Width = 50;
            // 
            // m_dtcSkinColor
            // 
            this.m_dtcSkinColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSkinColor.m_BlnGobleSet = true;
            this.m_dtcSkinColor.m_BlnUnderLineDST = false;
            this.m_dtcSkinColor.MappingName = "SkinColor";
            this.m_dtcSkinColor.Width = 50;
            // 
            // m_dtcSkinEdema
            // 
            this.m_dtcSkinEdema.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSkinEdema.m_BlnGobleSet = true;
            this.m_dtcSkinEdema.m_BlnUnderLineDST = false;
            this.m_dtcSkinEdema.MappingName = "SkinEdema";
            this.m_dtcSkinEdema.Width = 50;
            // 
            // m_dtcSkinLasticity
            // 
            this.m_dtcSkinLasticity.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSkinLasticity.m_BlnGobleSet = true;
            this.m_dtcSkinLasticity.m_BlnUnderLineDST = false;
            this.m_dtcSkinLasticity.MappingName = "SkinLasticity";
            this.m_dtcSkinLasticity.Width = 50;
            // 
            // m_dtcSkinPattern
            // 
            this.m_dtcSkinPattern.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSkinPattern.m_BlnGobleSet = true;
            this.m_dtcSkinPattern.m_BlnUnderLineDST = false;
            this.m_dtcSkinPattern.MappingName = "SkinPattern";
            this.m_dtcSkinPattern.Width = 50;
            // 
            // m_dtcSkinEdemaPosition
            // 
            this.m_dtcSkinEdemaPosition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSkinEdemaPosition.m_BlnGobleSet = true;
            this.m_dtcSkinEdemaPosition.m_BlnUnderLineDST = false;
            this.m_dtcSkinEdemaPosition.MappingName = "SkinEdemaPosition";
            this.m_dtcSkinEdemaPosition.Width = 50;
            // 
            // m_dtcSkinEdemaProperty
            // 
            this.m_dtcSkinEdemaProperty.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSkinEdemaProperty.m_BlnGobleSet = true;
            this.m_dtcSkinEdemaProperty.m_BlnUnderLineDST = false;
            this.m_dtcSkinEdemaProperty.MappingName = "SkinEdemaProperty";
            this.m_dtcSkinEdemaProperty.Width = 50;
            // 
            // m_dtcInceptKind
            // 
            this.m_dtcInceptKind.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInceptKind.m_BlnGobleSet = true;
            this.m_dtcInceptKind.m_BlnUnderLineDST = false;
            this.m_dtcInceptKind.MappingName = "Incept_Kind";
            this.m_dtcInceptKind.Width = 50;
            // 
            // m_dtcInceptMete
            // 
            this.m_dtcInceptMete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcInceptMete.m_BlnGobleSet = true;
            this.m_dtcInceptMete.m_BlnUnderLineDST = false;
            this.m_dtcInceptMete.MappingName = "Incept_Mete";
            this.m_dtcInceptMete.Width = 50;
            // 
            // m_dtcEductionKind
            // 
            this.m_dtcEductionKind.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEductionKind.m_BlnGobleSet = true;
            this.m_dtcEductionKind.m_BlnUnderLineDST = false;
            this.m_dtcEductionKind.MappingName = "Eduction_Kind";
            this.m_dtcEductionKind.Width = 50;
            // 
            // m_dtcEductionMete
            // 
            this.m_dtcEductionMete.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcEductionMete.m_BlnGobleSet = true;
            this.m_dtcEductionMete.m_BlnUnderLineDST = false;
            this.m_dtcEductionMete.MappingName = "Eduction_Mete";
            this.m_dtcEductionMete.Width = 50;
            // 
            // m_dtcContent
            // 
            this.m_dtcContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcContent.m_BlnGobleSet = true;
            this.m_dtcContent.m_BlnUnderLineDST = false;
            this.m_dtcContent.MappingName = "Content";
            this.m_dtcContent.Width = 250;
            // 
            // clmRecordSign
            // 
            this.clmRecordSign.Format = "";
            this.clmRecordSign.FormatInfo = null;
            this.clmRecordSign.MappingName = "RecordSign";
            this.clmRecordSign.Width = 120;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(10, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 505);
            this.panel1.TabIndex = 10000007;
            // 
            // frmIntensivetendRecord_CS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 666);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmIntensivetendRecord_CS";
            this.Text = "护理记录(新生儿科)";
            this.Load += new System.EventHandler(this.frmIntensivetendRecord_CS_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}