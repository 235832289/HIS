﻿namespace iCare
{
    partial class frmNewBorthBabyGeneralNurseRecord_CS
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
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.clmRecordDateofDay = new System.Windows.Forms.DataGridTextBoxColumn();
            this.clmCreateTime = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcBoxTemperature = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcTemperature = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcHeartRate = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcRespiration = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcBloodPress = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcSAO2 = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcMind = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcFace = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcQianlu = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInceptKind = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcInceptMete = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEductionKind = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.m_dtcEductionMete = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.clmExecuteSign = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_dtcContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.clmRecordSign = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
																										 this.clmRecordDateofDay,
																										 this.clmCreateTime,
                                                                                                         this.m_dtcBoxTemperature,
																										 this.m_dtcTemperature,
																										 this.m_dtcHeartRate,
																										 this.m_dtcRespiration,
																										 //this.m_dtcBloodPress,
																										 this.m_dtcSAO2,
                                                                                                         this.m_dtcMind,
                                                                                                         this.m_dtcFace,
                                                                                                         this.m_dtcQianlu,
																										 this.m_dtcInceptKind,
																										 this.m_dtcInceptMete,
																										 this.m_dtcEductionKind,
																										 this.m_dtcEductionMete,
                                                                                                         this.clmExecuteSign,
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
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(786, 534);
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
            this.m_trvInPatientDate.Location = new System.Drawing.Point(80, 72);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(228, 10);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(90, 120);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(544, 271);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Visible = false;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(-12, 174);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(-12, 174);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(-1, 172);
            this.m_lblForTitle.Visible = false;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(723, 37);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 26);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(794, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(792, 29);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(10, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(795, 549);
            this.panel1.TabIndex = 10000006;
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
            this.m_dtcBloodPress.Width = 50;
            // 
            // m_dtcSAO2
            // 
            this.m_dtcSAO2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcSAO2.m_BlnGobleSet = true;
            this.m_dtcSAO2.m_BlnUnderLineDST = false;
            this.m_dtcSAO2.MappingName = "SAO2";
            this.m_dtcSAO2.Width = 50;
            // 
            // m_dtcMind
            // 
            this.m_dtcMind.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcMind.m_BlnGobleSet = true;
            this.m_dtcMind.m_BlnUnderLineDST = false;
            this.m_dtcMind.MappingName = "Mind";
            this.m_dtcMind.Width = 50;
            // 
            // m_dtcFace
            // 
            this.m_dtcFace.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcFace.m_BlnGobleSet = true;
            this.m_dtcFace.m_BlnUnderLineDST = false;
            this.m_dtcFace.MappingName = "Face";
            this.m_dtcFace.Width = 50;
            // 
            // m_dtcQianlu
            // 
            this.m_dtcQianlu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcQianlu.m_BlnGobleSet = true;
            this.m_dtcQianlu.m_BlnUnderLineDST = false;
            this.m_dtcQianlu.MappingName = "Qianlu";
            this.m_dtcQianlu.Width = 50;
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
            // clmExecuteSign
            // 
            this.clmExecuteSign.Format = "";
            this.clmExecuteSign.FormatInfo = null;
            this.clmExecuteSign.MappingName = "ExecuseSign";
            this.clmExecuteSign.Width = 120;
            // 
            // m_dtcContent
            // 
            this.m_dtcContent.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtcContent.m_BlnGobleSet = true;
            this.m_dtcContent.m_BlnUnderLineDST = false;
            this.m_dtcContent.MappingName = "Content";
            this.m_dtcContent.Width = 240;
            // 
            // clmRecordSign
            // 
            this.clmRecordSign.Format = "";
            this.clmRecordSign.FormatInfo = null;
            this.clmRecordSign.MappingName = "RecordAndDetailSign";
            this.clmRecordSign.Width = 120;
            // 
            // frmNewBorthBabyGeneralNurseRecord_CS
            // 
            this.ClientSize = new System.Drawing.Size(849, 645);
            this.Controls.Add(this.panel1);
            this.Name = "frmNewBorthBabyGeneralNurseRecord_CS";
            this.Text = "新生儿科一般患者护理记录";
            this.Load += new System.EventHandler(this.frmNewBorthBabyGeneralNurseRecord_CS_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
    }
}
