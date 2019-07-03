using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls ;

namespace iCare
{
	/// <summary>
	/// Summary description for frmICUNursingRecord.
	/// </summary>
	public class frmICUNursingRecord : System.Windows.Forms.Form
	{
		#region 窗体自定义变量
		private System.Windows.Forms.TreeView trvICUNurseRecord;
		private System.Windows.Forms.Panel pnlRecord;
		private System.Windows.Forms.Splitter sptTrvAndRecord;
		private System.Windows.Forms.Label lblSex;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.Label lblInHospitalNoTitle;
		private System.Windows.Forms.Label lblNameTitle;
		private System.Windows.Forms.Label lblSexTitle;
		private System.Windows.Forms.Label lblAgeTitle;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblArea;
		private System.Windows.Forms.Label lblBedNo;
		private System.Windows.Forms.Label lblBedNoTitle;
		private System.Windows.Forms.Label lblAreaTitle;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblDepartmentTitle;
		private System.Windows.Forms.Label lblDepartment;
		private System.Windows.Forms.Label lblC;
		private System.Windows.Forms.Label lblO;
		private System.Windows.Forms.GroupBox gpbOutQty;
		private System.Windows.Forms.Label lblMl3Title;
		private System.Windows.Forms.Label lblMl4Title;
		private System.Windows.Forms.Label lblMl5Title;
		private System.Windows.Forms.Label lblMl6Title;
		private com.digitalwave.controls.ctlRichTextBox txtOutQtyLeadFluid;
		private com.digitalwave.controls.ctlRichTextBox txtOutQtyPuke;
		private System.Windows.Forms.Label lblOutQtyLeadFluidTitle;
		private System.Windows.Forms.Label lblOutQtyPukeTitle;
		private com.digitalwave.controls.ctlRichTextBox txtOutQtyDefecate;
		private com.digitalwave.controls.ctlRichTextBox txtOutQtyUrine;
		private System.Windows.Forms.Label lblOutQtyDefecateTitle;
		private System.Windows.Forms.Label lblOutQtyUrineTitle;
		private System.Windows.Forms.GroupBox gpbInQty;
		private System.Windows.Forms.Label lblMl2Title;
		private System.Windows.Forms.Label lblMl1Title;
		private com.digitalwave.controls.ctlRichTextBox txtInQtyFluid;
		private System.Windows.Forms.Label lblInQtyFoodTitle;
		private System.Windows.Forms.Label lblInQtyFluidTitle;
		private com.digitalwave.controls.ctlRichTextBox txtInQtyFood;
		private System.Windows.Forms.GroupBox gpbPupil;
		private System.Windows.Forms.GroupBox gpbPupilReflect;
		private System.Windows.Forms.Label lblCm3Title;
		private System.Windows.Forms.Label lblCm4Title;
		private com.digitalwave.controls.ctlRichTextBox txtPupilReflectRight;
		private System.Windows.Forms.Label lblPupilReflectLeftTitle;
		private System.Windows.Forms.Label lblPupilReflectRightTitle;
		private com.digitalwave.controls.ctlRichTextBox txtPupilReflectLeft;
		private System.Windows.Forms.GroupBox gpbPupilSize;
		private System.Windows.Forms.Label lblCm1Title;
		private System.Windows.Forms.Label lblCm2Title;
		private com.digitalwave.controls.ctlRichTextBox txtPupilSizeRight;
		private System.Windows.Forms.Label lblPupilSizeLeftTitle;
		private System.Windows.Forms.Label lblPupilSizeRightTitle;
		private com.digitalwave.controls.ctlRichTextBox txtPupilSizeLeft;
		private System.Windows.Forms.Label lblWardParamTitle;
		private System.Windows.Forms.Label lblBreathParmTitle;
		public System.Windows.Forms.ListView lsvWardParameter;
		public System.Windows.Forms.ListView lsvBreathParameter;
		private com.digitalwave.controls.ctlRichTextBox txtRecord;
		private System.Windows.Forms.Label lblRecordTitle;
		private com.digitalwave.controls.ctlRichTextBox txtTemperature;
		private System.Windows.Forms.Label lblTemperatureTitle;
		private System.Windows.Forms.ColumnHeader clmBreathParamName;
		private System.Windows.Forms.ColumnHeader clmBreathParamNum;
		private System.Windows.Forms.ColumnHeader clmWardParamName;
		private System.Windows.Forms.ColumnHeader clmWardParamNum;
		private com.digitalwave.controls.ctlRichTextBox txtInPatientNo;
		private System.Windows.Forms.Label lblDiagnosisTitle;
		private com.digitalwave.controls.ctlRichTextBox txtDiagnosis;
		private com.digitalwave.controls.ctlRichTextBox txtRecordNurse;
		private System.Windows.Forms.Label lblRecordNurse;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion 

		public frmICUNursingRecord()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                                            {
            //                                                                this.lsvBreathParameter  ,
            //                                                                this.lsvWardParameter ,
            //});
            //#region 画RichTextBox 的白边
            //foreach(Control ctlTop in this.Controls )
            //{
            //    string typeName = ctlTop.GetType().Name;
            //    if(typeName == "Panel")
            //        foreach(Control ctlInPanel in ctlTop.Controls )
            //        {
            //            typeName=ctlInPanel.GetType().Name ;
            //            if(typeName =="ctlRichTextBox")
            //                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                                            {
            //                                                                ctlInPanel ,
            //                });
            //            if(typeName =="GroupBox")
            //                foreach(Control ctlGrp in ctlInPanel.Controls )
            //                {
            //                    typeName=ctlGrp.GetType().Name ;
            //                    if(typeName =="ctlRichTextBox")
            //                        m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                                            {
            //                                                                ctlGrp ,
            //                        });
            //                    if(typeName =="GroupBox")
            //                        foreach(Control ctlSubGrp in ctlGrp.Controls )
            //                        {
            //                            typeName=ctlSubGrp.GetType().Name ;
            //                            if(typeName =="ctlRichTextBox")
            //                                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]
            //                                                            {
            //                                                                ctlSubGrp ,
            //                                });
            //                        }
            //                }
            //        }
								
							
            //}
            //#endregion 
		}
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;

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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmICUNursingRecord));
			this.sptTrvAndRecord = new System.Windows.Forms.Splitter();
			this.trvICUNurseRecord = new System.Windows.Forms.TreeView();
			this.pnlRecord = new System.Windows.Forms.Panel();
			this.txtRecordNurse = new com.digitalwave.controls.ctlRichTextBox();
			this.lblRecordNurse = new System.Windows.Forms.Label();
			this.txtDiagnosis = new com.digitalwave.controls.ctlRichTextBox();
			this.lblDiagnosisTitle = new System.Windows.Forms.Label();
			this.txtInPatientNo = new com.digitalwave.controls.ctlRichTextBox();
			this.gpbOutQty = new System.Windows.Forms.GroupBox();
			this.lblMl3Title = new System.Windows.Forms.Label();
			this.lblMl4Title = new System.Windows.Forms.Label();
			this.lblMl5Title = new System.Windows.Forms.Label();
			this.lblMl6Title = new System.Windows.Forms.Label();
			this.txtOutQtyLeadFluid = new com.digitalwave.controls.ctlRichTextBox();
			this.txtOutQtyPuke = new com.digitalwave.controls.ctlRichTextBox();
			this.lblOutQtyLeadFluidTitle = new System.Windows.Forms.Label();
			this.lblOutQtyPukeTitle = new System.Windows.Forms.Label();
			this.txtOutQtyDefecate = new com.digitalwave.controls.ctlRichTextBox();
			this.txtOutQtyUrine = new com.digitalwave.controls.ctlRichTextBox();
			this.lblOutQtyDefecateTitle = new System.Windows.Forms.Label();
			this.lblOutQtyUrineTitle = new System.Windows.Forms.Label();
			this.gpbInQty = new System.Windows.Forms.GroupBox();
			this.lblMl2Title = new System.Windows.Forms.Label();
			this.lblMl1Title = new System.Windows.Forms.Label();
			this.txtInQtyFluid = new com.digitalwave.controls.ctlRichTextBox();
			this.lblInQtyFoodTitle = new System.Windows.Forms.Label();
			this.lblInQtyFluidTitle = new System.Windows.Forms.Label();
			this.txtInQtyFood = new com.digitalwave.controls.ctlRichTextBox();
			this.gpbPupil = new System.Windows.Forms.GroupBox();
			this.gpbPupilReflect = new System.Windows.Forms.GroupBox();
			this.lblCm3Title = new System.Windows.Forms.Label();
			this.lblCm4Title = new System.Windows.Forms.Label();
			this.txtPupilReflectRight = new com.digitalwave.controls.ctlRichTextBox();
			this.lblPupilReflectLeftTitle = new System.Windows.Forms.Label();
			this.lblPupilReflectRightTitle = new System.Windows.Forms.Label();
			this.txtPupilReflectLeft = new com.digitalwave.controls.ctlRichTextBox();
			this.gpbPupilSize = new System.Windows.Forms.GroupBox();
			this.lblCm1Title = new System.Windows.Forms.Label();
			this.lblCm2Title = new System.Windows.Forms.Label();
			this.txtPupilSizeRight = new com.digitalwave.controls.ctlRichTextBox();
			this.lblPupilSizeLeftTitle = new System.Windows.Forms.Label();
			this.lblPupilSizeRightTitle = new System.Windows.Forms.Label();
			this.txtPupilSizeLeft = new com.digitalwave.controls.ctlRichTextBox();
			this.lblWardParamTitle = new System.Windows.Forms.Label();
			this.lblBreathParmTitle = new System.Windows.Forms.Label();
			this.lsvWardParameter = new System.Windows.Forms.ListView();
			this.clmWardParamName = new System.Windows.Forms.ColumnHeader();
			this.clmWardParamNum = new System.Windows.Forms.ColumnHeader();
			this.lsvBreathParameter = new System.Windows.Forms.ListView();
			this.clmBreathParamName = new System.Windows.Forms.ColumnHeader();
			this.clmBreathParamNum = new System.Windows.Forms.ColumnHeader();
			this.txtRecord = new com.digitalwave.controls.ctlRichTextBox();
			this.lblRecordTitle = new System.Windows.Forms.Label();
			this.lblC = new System.Windows.Forms.Label();
			this.lblO = new System.Windows.Forms.Label();
			this.txtTemperature = new com.digitalwave.controls.ctlRichTextBox();
			this.lblTemperatureTitle = new System.Windows.Forms.Label();
			this.lblDepartmentTitle = new System.Windows.Forms.Label();
			this.lblDepartment = new System.Windows.Forms.Label();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblArea = new System.Windows.Forms.Label();
			this.lblBedNo = new System.Windows.Forms.Label();
			this.lblBedNoTitle = new System.Windows.Forms.Label();
			this.lblAreaTitle = new System.Windows.Forms.Label();
			this.lblSex = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblInHospitalNoTitle = new System.Windows.Forms.Label();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.lblAgeTitle = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.pnlRecord.SuspendLayout();
			this.gpbOutQty.SuspendLayout();
			this.gpbInQty.SuspendLayout();
			this.gpbPupil.SuspendLayout();
			this.gpbPupilReflect.SuspendLayout();
			this.gpbPupilSize.SuspendLayout();
			this.SuspendLayout();
			// 
			// sptTrvAndRecord
			// 
			this.sptTrvAndRecord.Location = new System.Drawing.Point(280, 0);
			this.sptTrvAndRecord.Name = "sptTrvAndRecord";
			this.sptTrvAndRecord.Size = new System.Drawing.Size(12, 753);
			this.sptTrvAndRecord.TabIndex = 4;
			this.sptTrvAndRecord.TabStop = false;
			// 
			// trvICUNurseRecord
			// 
			this.trvICUNurseRecord.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.trvICUNurseRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.trvICUNurseRecord.Cursor = System.Windows.Forms.Cursors.Default;
			this.trvICUNurseRecord.Dock = System.Windows.Forms.DockStyle.Left;
			this.trvICUNurseRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvICUNurseRecord.ForeColor = System.Drawing.Color.White;
			this.trvICUNurseRecord.HideSelection = false;
			this.trvICUNurseRecord.HotTracking = true;
			this.trvICUNurseRecord.ImageIndex = -1;
			this.trvICUNurseRecord.Indent = 22;
			this.trvICUNurseRecord.Location = new System.Drawing.Point(0, 0);
			this.trvICUNurseRecord.Name = "trvICUNurseRecord";
			this.trvICUNurseRecord.SelectedImageIndex = -1;
			this.trvICUNurseRecord.Size = new System.Drawing.Size(280, 753);
			this.trvICUNurseRecord.TabIndex = 3;
			// 
			// pnlRecord
			// 
			this.pnlRecord.AutoScroll = true;
			this.pnlRecord.Controls.Add(this.txtRecordNurse);
			this.pnlRecord.Controls.Add(this.lblRecordNurse);
			this.pnlRecord.Controls.Add(this.txtDiagnosis);
			this.pnlRecord.Controls.Add(this.lblDiagnosisTitle);
			this.pnlRecord.Controls.Add(this.txtInPatientNo);
			this.pnlRecord.Controls.Add(this.gpbOutQty);
			this.pnlRecord.Controls.Add(this.gpbInQty);
			this.pnlRecord.Controls.Add(this.gpbPupil);
			this.pnlRecord.Controls.Add(this.lblWardParamTitle);
			this.pnlRecord.Controls.Add(this.lblBreathParmTitle);
			this.pnlRecord.Controls.Add(this.lsvWardParameter);
			this.pnlRecord.Controls.Add(this.lsvBreathParameter);
			this.pnlRecord.Controls.Add(this.txtRecord);
			this.pnlRecord.Controls.Add(this.lblRecordTitle);
			this.pnlRecord.Controls.Add(this.lblC);
			this.pnlRecord.Controls.Add(this.lblO);
			this.pnlRecord.Controls.Add(this.txtTemperature);
			this.pnlRecord.Controls.Add(this.lblTemperatureTitle);
			this.pnlRecord.Controls.Add(this.lblDepartmentTitle);
			this.pnlRecord.Controls.Add(this.lblDepartment);
			this.pnlRecord.Controls.Add(this.lblYear);
			this.pnlRecord.Controls.Add(this.lblArea);
			this.pnlRecord.Controls.Add(this.lblBedNo);
			this.pnlRecord.Controls.Add(this.lblBedNoTitle);
			this.pnlRecord.Controls.Add(this.lblAreaTitle);
			this.pnlRecord.Controls.Add(this.lblSex);
			this.pnlRecord.Controls.Add(this.lblAge);
			this.pnlRecord.Controls.Add(this.lblInHospitalNoTitle);
			this.pnlRecord.Controls.Add(this.lblNameTitle);
			this.pnlRecord.Controls.Add(this.lblSexTitle);
			this.pnlRecord.Controls.Add(this.lblAgeTitle);
			this.pnlRecord.Controls.Add(this.lblName);
			this.pnlRecord.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlRecord.Location = new System.Drawing.Point(292, 0);
			this.pnlRecord.Name = "pnlRecord";
			this.pnlRecord.Size = new System.Drawing.Size(732, 753);
			this.pnlRecord.TabIndex = 6;
			// 
			// txtRecordNurse
			// 
			this.txtRecordNurse.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtRecordNurse.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRecordNurse.ForeColor = System.Drawing.Color.White;
			this.txtRecordNurse.Location = new System.Drawing.Point(104, 388);
			this.txtRecordNurse.m_BlnIgnoreUserInfo = false;
			this.txtRecordNurse.m_BlnPartControl = false;
			this.txtRecordNurse.m_BlnReadOnly = false;
			this.txtRecordNurse.m_BlnUnderLineDST = false;
			this.txtRecordNurse.m_ClrDST = System.Drawing.Color.Red;
			this.txtRecordNurse.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtRecordNurse.m_IntCanModifyTime = 6;
			this.txtRecordNurse.m_IntPartControlLength = 0;
			this.txtRecordNurse.m_IntPartControlStartIndex = 0;
			this.txtRecordNurse.m_StrUserID = "";
			this.txtRecordNurse.m_StrUserName = "";
			this.txtRecordNurse.Multiline = false;
			this.txtRecordNurse.Name = "txtRecordNurse";
			this.txtRecordNurse.Size = new System.Drawing.Size(140, 20);
			this.txtRecordNurse.TabIndex = 5992;
			this.txtRecordNurse.Text = "";
			// 
			// lblRecordNurse
			// 
			this.lblRecordNurse.AutoSize = true;
			this.lblRecordNurse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRecordNurse.Location = new System.Drawing.Point(12, 392);
			this.lblRecordNurse.Name = "lblRecordNurse";
			this.lblRecordNurse.Size = new System.Drawing.Size(55, 22);
			this.lblRecordNurse.TabIndex = 5991;
			this.lblRecordNurse.Text = "签名：";
			// 
			// txtDiagnosis
			// 
			this.txtDiagnosis.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtDiagnosis.ForeColor = System.Drawing.Color.White;
			this.txtDiagnosis.Location = new System.Drawing.Point(472, 52);
			this.txtDiagnosis.m_BlnIgnoreUserInfo = false;
			this.txtDiagnosis.m_BlnPartControl = false;
			this.txtDiagnosis.m_BlnReadOnly = false;
			this.txtDiagnosis.m_BlnUnderLineDST = false;
			this.txtDiagnosis.m_ClrDST = System.Drawing.Color.Red;
			this.txtDiagnosis.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtDiagnosis.m_IntCanModifyTime = 6;
			this.txtDiagnosis.m_IntPartControlLength = 0;
			this.txtDiagnosis.m_IntPartControlStartIndex = 0;
			this.txtDiagnosis.m_StrUserID = "";
			this.txtDiagnosis.m_StrUserName = "";
			this.txtDiagnosis.Multiline = false;
			this.txtDiagnosis.Name = "txtDiagnosis";
			this.txtDiagnosis.Size = new System.Drawing.Size(244, 20);
			this.txtDiagnosis.TabIndex = 5990;
			this.txtDiagnosis.Text = "";
			// 
			// lblDiagnosisTitle
			// 
			this.lblDiagnosisTitle.AutoSize = true;
			this.lblDiagnosisTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDiagnosisTitle.Location = new System.Drawing.Point(408, 52);
			this.lblDiagnosisTitle.Name = "lblDiagnosisTitle";
			this.lblDiagnosisTitle.Size = new System.Drawing.Size(55, 22);
			this.lblDiagnosisTitle.TabIndex = 5989;
			this.lblDiagnosisTitle.Text = "诊断：";
			// 
			// txtInPatientNo
			// 
			this.txtInPatientNo.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtInPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInPatientNo.ForeColor = System.Drawing.Color.White;
			this.txtInPatientNo.Location = new System.Drawing.Point(92, 20);
			this.txtInPatientNo.m_BlnIgnoreUserInfo = false;
			this.txtInPatientNo.m_BlnPartControl = false;
			this.txtInPatientNo.m_BlnReadOnly = false;
			this.txtInPatientNo.m_BlnUnderLineDST = false;
			this.txtInPatientNo.m_ClrDST = System.Drawing.Color.Red;
			this.txtInPatientNo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtInPatientNo.m_IntCanModifyTime = 6;
			this.txtInPatientNo.m_IntPartControlLength = 0;
			this.txtInPatientNo.m_IntPartControlStartIndex = 0;
			this.txtInPatientNo.m_StrUserID = "";
			this.txtInPatientNo.m_StrUserName = "";
			this.txtInPatientNo.Multiline = false;
			this.txtInPatientNo.Name = "txtInPatientNo";
			this.txtInPatientNo.Size = new System.Drawing.Size(116, 20);
			this.txtInPatientNo.TabIndex = 5988;
			this.txtInPatientNo.Text = "";
			// 
			// gpbOutQty
			// 
			this.gpbOutQty.Controls.Add(this.lblMl3Title);
			this.gpbOutQty.Controls.Add(this.lblMl4Title);
			this.gpbOutQty.Controls.Add(this.lblMl5Title);
			this.gpbOutQty.Controls.Add(this.lblMl6Title);
			this.gpbOutQty.Controls.Add(this.txtOutQtyLeadFluid);
			this.gpbOutQty.Controls.Add(this.txtOutQtyPuke);
			this.gpbOutQty.Controls.Add(this.lblOutQtyLeadFluidTitle);
			this.gpbOutQty.Controls.Add(this.lblOutQtyPukeTitle);
			this.gpbOutQty.Controls.Add(this.txtOutQtyDefecate);
			this.gpbOutQty.Controls.Add(this.txtOutQtyUrine);
			this.gpbOutQty.Controls.Add(this.lblOutQtyDefecateTitle);
			this.gpbOutQty.Controls.Add(this.lblOutQtyUrineTitle);
			this.gpbOutQty.Location = new System.Drawing.Point(208, 204);
			this.gpbOutQty.Name = "gpbOutQty";
			this.gpbOutQty.Size = new System.Drawing.Size(508, 84);
			this.gpbOutQty.TabIndex = 5987;
			this.gpbOutQty.TabStop = false;
			this.gpbOutQty.Text = "出量";
			// 
			// lblMl3Title
			// 
			this.lblMl3Title.AutoSize = true;
			this.lblMl3Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMl3Title.Location = new System.Drawing.Point(128, 28);
			this.lblMl3Title.Name = "lblMl3Title";
			this.lblMl3Title.Size = new System.Drawing.Size(22, 22);
			this.lblMl3Title.TabIndex = 6001;
			this.lblMl3Title.Text = "ml";
			// 
			// lblMl4Title
			// 
			this.lblMl4Title.AutoSize = true;
			this.lblMl4Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMl4Title.Location = new System.Drawing.Point(128, 52);
			this.lblMl4Title.Name = "lblMl4Title";
			this.lblMl4Title.Size = new System.Drawing.Size(22, 22);
			this.lblMl4Title.TabIndex = 6000;
			this.lblMl4Title.Text = "ml";
			// 
			// lblMl5Title
			// 
			this.lblMl5Title.AutoSize = true;
			this.lblMl5Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMl5Title.Location = new System.Drawing.Point(296, 28);
			this.lblMl5Title.Name = "lblMl5Title";
			this.lblMl5Title.Size = new System.Drawing.Size(22, 22);
			this.lblMl5Title.TabIndex = 5999;
			this.lblMl5Title.Text = "ml";
			// 
			// lblMl6Title
			// 
			this.lblMl6Title.AutoSize = true;
			this.lblMl6Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMl6Title.Location = new System.Drawing.Point(296, 52);
			this.lblMl6Title.Name = "lblMl6Title";
			this.lblMl6Title.Size = new System.Drawing.Size(22, 22);
			this.lblMl6Title.TabIndex = 5998;
			this.lblMl6Title.Text = "ml";
			// 
			// txtOutQtyLeadFluid
			// 
			this.txtOutQtyLeadFluid.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtOutQtyLeadFluid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutQtyLeadFluid.ForeColor = System.Drawing.Color.White;
			this.txtOutQtyLeadFluid.Location = new System.Drawing.Point(240, 52);
			this.txtOutQtyLeadFluid.m_BlnIgnoreUserInfo = false;
			this.txtOutQtyLeadFluid.m_BlnPartControl = false;
			this.txtOutQtyLeadFluid.m_BlnReadOnly = false;
			this.txtOutQtyLeadFluid.m_BlnUnderLineDST = false;
			this.txtOutQtyLeadFluid.m_ClrDST = System.Drawing.Color.Red;
			this.txtOutQtyLeadFluid.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtOutQtyLeadFluid.m_IntCanModifyTime = 6;
			this.txtOutQtyLeadFluid.m_IntPartControlLength = 0;
			this.txtOutQtyLeadFluid.m_IntPartControlStartIndex = 0;
			this.txtOutQtyLeadFluid.m_StrUserID = "";
			this.txtOutQtyLeadFluid.m_StrUserName = "";
			this.txtOutQtyLeadFluid.Multiline = false;
			this.txtOutQtyLeadFluid.Name = "txtOutQtyLeadFluid";
			this.txtOutQtyLeadFluid.Size = new System.Drawing.Size(52, 20);
			this.txtOutQtyLeadFluid.TabIndex = 5997;
			this.txtOutQtyLeadFluid.Text = "";
			// 
			// txtOutQtyPuke
			// 
			this.txtOutQtyPuke.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtOutQtyPuke.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutQtyPuke.ForeColor = System.Drawing.Color.White;
			this.txtOutQtyPuke.Location = new System.Drawing.Point(240, 28);
			this.txtOutQtyPuke.m_BlnIgnoreUserInfo = false;
			this.txtOutQtyPuke.m_BlnPartControl = false;
			this.txtOutQtyPuke.m_BlnReadOnly = false;
			this.txtOutQtyPuke.m_BlnUnderLineDST = false;
			this.txtOutQtyPuke.m_ClrDST = System.Drawing.Color.Red;
			this.txtOutQtyPuke.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtOutQtyPuke.m_IntCanModifyTime = 6;
			this.txtOutQtyPuke.m_IntPartControlLength = 0;
			this.txtOutQtyPuke.m_IntPartControlStartIndex = 0;
			this.txtOutQtyPuke.m_StrUserID = "";
			this.txtOutQtyPuke.m_StrUserName = "";
			this.txtOutQtyPuke.Multiline = false;
			this.txtOutQtyPuke.Name = "txtOutQtyPuke";
			this.txtOutQtyPuke.Size = new System.Drawing.Size(52, 20);
			this.txtOutQtyPuke.TabIndex = 5996;
			this.txtOutQtyPuke.Text = "";
			// 
			// lblOutQtyLeadFluidTitle
			// 
			this.lblOutQtyLeadFluidTitle.AutoSize = true;
			this.lblOutQtyLeadFluidTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOutQtyLeadFluidTitle.Location = new System.Drawing.Point(164, 52);
			this.lblOutQtyLeadFluidTitle.Name = "lblOutQtyLeadFluidTitle";
			this.lblOutQtyLeadFluidTitle.Size = new System.Drawing.Size(72, 22);
			this.lblOutQtyLeadFluidTitle.TabIndex = 5995;
			this.lblOutQtyLeadFluidTitle.Text = "引流液：";
			// 
			// lblOutQtyPukeTitle
			// 
			this.lblOutQtyPukeTitle.AutoSize = true;
			this.lblOutQtyPukeTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOutQtyPukeTitle.Location = new System.Drawing.Point(164, 28);
			this.lblOutQtyPukeTitle.Name = "lblOutQtyPukeTitle";
			this.lblOutQtyPukeTitle.Size = new System.Drawing.Size(72, 22);
			this.lblOutQtyPukeTitle.TabIndex = 5994;
			this.lblOutQtyPukeTitle.Text = "呕吐物：";
			// 
			// txtOutQtyDefecate
			// 
			this.txtOutQtyDefecate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtOutQtyDefecate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutQtyDefecate.ForeColor = System.Drawing.Color.White;
			this.txtOutQtyDefecate.Location = new System.Drawing.Point(72, 52);
			this.txtOutQtyDefecate.m_BlnIgnoreUserInfo = false;
			this.txtOutQtyDefecate.m_BlnPartControl = false;
			this.txtOutQtyDefecate.m_BlnReadOnly = false;
			this.txtOutQtyDefecate.m_BlnUnderLineDST = false;
			this.txtOutQtyDefecate.m_ClrDST = System.Drawing.Color.Red;
			this.txtOutQtyDefecate.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtOutQtyDefecate.m_IntCanModifyTime = 6;
			this.txtOutQtyDefecate.m_IntPartControlLength = 0;
			this.txtOutQtyDefecate.m_IntPartControlStartIndex = 0;
			this.txtOutQtyDefecate.m_StrUserID = "";
			this.txtOutQtyDefecate.m_StrUserName = "";
			this.txtOutQtyDefecate.Multiline = false;
			this.txtOutQtyDefecate.Name = "txtOutQtyDefecate";
			this.txtOutQtyDefecate.Size = new System.Drawing.Size(52, 20);
			this.txtOutQtyDefecate.TabIndex = 5993;
			this.txtOutQtyDefecate.Text = "";
			// 
			// txtOutQtyUrine
			// 
			this.txtOutQtyUrine.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtOutQtyUrine.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtOutQtyUrine.ForeColor = System.Drawing.Color.White;
			this.txtOutQtyUrine.Location = new System.Drawing.Point(72, 28);
			this.txtOutQtyUrine.m_BlnIgnoreUserInfo = false;
			this.txtOutQtyUrine.m_BlnPartControl = false;
			this.txtOutQtyUrine.m_BlnReadOnly = false;
			this.txtOutQtyUrine.m_BlnUnderLineDST = false;
			this.txtOutQtyUrine.m_ClrDST = System.Drawing.Color.Red;
			this.txtOutQtyUrine.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtOutQtyUrine.m_IntCanModifyTime = 6;
			this.txtOutQtyUrine.m_IntPartControlLength = 0;
			this.txtOutQtyUrine.m_IntPartControlStartIndex = 0;
			this.txtOutQtyUrine.m_StrUserID = "";
			this.txtOutQtyUrine.m_StrUserName = "";
			this.txtOutQtyUrine.Multiline = false;
			this.txtOutQtyUrine.Name = "txtOutQtyUrine";
			this.txtOutQtyUrine.Size = new System.Drawing.Size(52, 20);
			this.txtOutQtyUrine.TabIndex = 5992;
			this.txtOutQtyUrine.Text = "";
			// 
			// lblOutQtyDefecateTitle
			// 
			this.lblOutQtyDefecateTitle.AutoSize = true;
			this.lblOutQtyDefecateTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOutQtyDefecateTitle.Location = new System.Drawing.Point(12, 52);
			this.lblOutQtyDefecateTitle.Name = "lblOutQtyDefecateTitle";
			this.lblOutQtyDefecateTitle.Size = new System.Drawing.Size(55, 22);
			this.lblOutQtyDefecateTitle.TabIndex = 5991;
			this.lblOutQtyDefecateTitle.Text = "大便：";
			// 
			// lblOutQtyUrineTitle
			// 
			this.lblOutQtyUrineTitle.AutoSize = true;
			this.lblOutQtyUrineTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblOutQtyUrineTitle.Location = new System.Drawing.Point(12, 28);
			this.lblOutQtyUrineTitle.Name = "lblOutQtyUrineTitle";
			this.lblOutQtyUrineTitle.Size = new System.Drawing.Size(39, 22);
			this.lblOutQtyUrineTitle.TabIndex = 5990;
			this.lblOutQtyUrineTitle.Text = "尿：";
			// 
			// gpbInQty
			// 
			this.gpbInQty.Controls.Add(this.lblMl2Title);
			this.gpbInQty.Controls.Add(this.lblMl1Title);
			this.gpbInQty.Controls.Add(this.txtInQtyFluid);
			this.gpbInQty.Controls.Add(this.lblInQtyFoodTitle);
			this.gpbInQty.Controls.Add(this.lblInQtyFluidTitle);
			this.gpbInQty.Controls.Add(this.txtInQtyFood);
			this.gpbInQty.Location = new System.Drawing.Point(16, 204);
			this.gpbInQty.Name = "gpbInQty";
			this.gpbInQty.Size = new System.Drawing.Size(170, 84);
			this.gpbInQty.TabIndex = 5986;
			this.gpbInQty.TabStop = false;
			this.gpbInQty.Text = "入量";
			// 
			// lblMl2Title
			// 
			this.lblMl2Title.AutoSize = true;
			this.lblMl2Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMl2Title.Location = new System.Drawing.Point(128, 52);
			this.lblMl2Title.Name = "lblMl2Title";
			this.lblMl2Title.Size = new System.Drawing.Size(22, 22);
			this.lblMl2Title.TabIndex = 5982;
			this.lblMl2Title.Text = "ml";
			// 
			// lblMl1Title
			// 
			this.lblMl1Title.AutoSize = true;
			this.lblMl1Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblMl1Title.Location = new System.Drawing.Point(128, 28);
			this.lblMl1Title.Name = "lblMl1Title";
			this.lblMl1Title.Size = new System.Drawing.Size(22, 22);
			this.lblMl1Title.TabIndex = 5981;
			this.lblMl1Title.Text = "ml";
			// 
			// txtInQtyFluid
			// 
			this.txtInQtyFluid.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtInQtyFluid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInQtyFluid.ForeColor = System.Drawing.Color.White;
			this.txtInQtyFluid.Location = new System.Drawing.Point(68, 52);
			this.txtInQtyFluid.m_BlnIgnoreUserInfo = false;
			this.txtInQtyFluid.m_BlnPartControl = false;
			this.txtInQtyFluid.m_BlnReadOnly = false;
			this.txtInQtyFluid.m_BlnUnderLineDST = false;
			this.txtInQtyFluid.m_ClrDST = System.Drawing.Color.Red;
			this.txtInQtyFluid.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtInQtyFluid.m_IntCanModifyTime = 6;
			this.txtInQtyFluid.m_IntPartControlLength = 0;
			this.txtInQtyFluid.m_IntPartControlStartIndex = 0;
			this.txtInQtyFluid.m_StrUserID = "";
			this.txtInQtyFluid.m_StrUserName = "";
			this.txtInQtyFluid.Multiline = false;
			this.txtInQtyFluid.Name = "txtInQtyFluid";
			this.txtInQtyFluid.Size = new System.Drawing.Size(52, 20);
			this.txtInQtyFluid.TabIndex = 5980;
			this.txtInQtyFluid.Text = "";
			// 
			// lblInQtyFoodTitle
			// 
			this.lblInQtyFoodTitle.AutoSize = true;
			this.lblInQtyFoodTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInQtyFoodTitle.Location = new System.Drawing.Point(9, 28);
			this.lblInQtyFoodTitle.Name = "lblInQtyFoodTitle";
			this.lblInQtyFoodTitle.Size = new System.Drawing.Size(55, 22);
			this.lblInQtyFoodTitle.TabIndex = 5979;
			this.lblInQtyFoodTitle.Text = "进食：";
			// 
			// lblInQtyFluidTitle
			// 
			this.lblInQtyFluidTitle.AutoSize = true;
			this.lblInQtyFluidTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInQtyFluidTitle.Location = new System.Drawing.Point(8, 52);
			this.lblInQtyFluidTitle.Name = "lblInQtyFluidTitle";
			this.lblInQtyFluidTitle.Size = new System.Drawing.Size(55, 22);
			this.lblInQtyFluidTitle.TabIndex = 5978;
			this.lblInQtyFluidTitle.Text = "输液：";
			// 
			// txtInQtyFood
			// 
			this.txtInQtyFood.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtInQtyFood.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtInQtyFood.ForeColor = System.Drawing.Color.White;
			this.txtInQtyFood.Location = new System.Drawing.Point(68, 28);
			this.txtInQtyFood.m_BlnIgnoreUserInfo = false;
			this.txtInQtyFood.m_BlnPartControl = false;
			this.txtInQtyFood.m_BlnReadOnly = false;
			this.txtInQtyFood.m_BlnUnderLineDST = false;
			this.txtInQtyFood.m_ClrDST = System.Drawing.Color.Red;
			this.txtInQtyFood.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtInQtyFood.m_IntCanModifyTime = 6;
			this.txtInQtyFood.m_IntPartControlLength = 0;
			this.txtInQtyFood.m_IntPartControlStartIndex = 0;
			this.txtInQtyFood.m_StrUserID = "";
			this.txtInQtyFood.m_StrUserName = "";
			this.txtInQtyFood.Multiline = false;
			this.txtInQtyFood.Name = "txtInQtyFood";
			this.txtInQtyFood.Size = new System.Drawing.Size(52, 20);
			this.txtInQtyFood.TabIndex = 5977;
			this.txtInQtyFood.Text = "";
			// 
			// gpbPupil
			// 
			this.gpbPupil.Controls.Add(this.gpbPupilReflect);
			this.gpbPupil.Controls.Add(this.gpbPupilSize);
			this.gpbPupil.Location = new System.Drawing.Point(16, 116);
			this.gpbPupil.Name = "gpbPupil";
			this.gpbPupil.Size = new System.Drawing.Size(700, 80);
			this.gpbPupil.TabIndex = 5985;
			this.gpbPupil.TabStop = false;
			this.gpbPupil.Text = "瞳孔";
			// 
			// gpbPupilReflect
			// 
			this.gpbPupilReflect.Controls.Add(this.lblCm3Title);
			this.gpbPupilReflect.Controls.Add(this.lblCm4Title);
			this.gpbPupilReflect.Controls.Add(this.txtPupilReflectRight);
			this.gpbPupilReflect.Controls.Add(this.lblPupilReflectLeftTitle);
			this.gpbPupilReflect.Controls.Add(this.lblPupilReflectRightTitle);
			this.gpbPupilReflect.Controls.Add(this.txtPupilReflectLeft);
			this.gpbPupilReflect.Location = new System.Drawing.Point(312, 20);
			this.gpbPupilReflect.Name = "gpbPupilReflect";
			this.gpbPupilReflect.Size = new System.Drawing.Size(312, 52);
			this.gpbPupilReflect.TabIndex = 613;
			this.gpbPupilReflect.TabStop = false;
			this.gpbPupilReflect.Text = "反射";
			// 
			// lblCm3Title
			// 
			this.lblCm3Title.AutoSize = true;
			this.lblCm3Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCm3Title.Location = new System.Drawing.Point(116, 28);
			this.lblCm3Title.Name = "lblCm3Title";
			this.lblCm3Title.Size = new System.Drawing.Size(22, 22);
			this.lblCm3Title.TabIndex = 5988;
			this.lblCm3Title.Text = "cm";
			// 
			// lblCm4Title
			// 
			this.lblCm4Title.AutoSize = true;
			this.lblCm4Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCm4Title.Location = new System.Drawing.Point(256, 28);
			this.lblCm4Title.Name = "lblCm4Title";
			this.lblCm4Title.Size = new System.Drawing.Size(22, 22);
			this.lblCm4Title.TabIndex = 5987;
			this.lblCm4Title.Text = "cm";
			// 
			// txtPupilReflectRight
			// 
			this.txtPupilReflectRight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtPupilReflectRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPupilReflectRight.ForeColor = System.Drawing.Color.White;
			this.txtPupilReflectRight.Location = new System.Drawing.Point(200, 28);
			this.txtPupilReflectRight.m_BlnIgnoreUserInfo = false;
			this.txtPupilReflectRight.m_BlnPartControl = false;
			this.txtPupilReflectRight.m_BlnReadOnly = false;
			this.txtPupilReflectRight.m_BlnUnderLineDST = false;
			this.txtPupilReflectRight.m_ClrDST = System.Drawing.Color.Red;
			this.txtPupilReflectRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtPupilReflectRight.m_IntCanModifyTime = 6;
			this.txtPupilReflectRight.m_IntPartControlLength = 0;
			this.txtPupilReflectRight.m_IntPartControlStartIndex = 0;
			this.txtPupilReflectRight.m_StrUserID = "";
			this.txtPupilReflectRight.m_StrUserName = "";
			this.txtPupilReflectRight.Multiline = false;
			this.txtPupilReflectRight.Name = "txtPupilReflectRight";
			this.txtPupilReflectRight.Size = new System.Drawing.Size(52, 20);
			this.txtPupilReflectRight.TabIndex = 5986;
			this.txtPupilReflectRight.Text = "";
			// 
			// lblPupilReflectLeftTitle
			// 
			this.lblPupilReflectLeftTitle.AutoSize = true;
			this.lblPupilReflectLeftTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPupilReflectLeftTitle.Location = new System.Drawing.Point(16, 28);
			this.lblPupilReflectLeftTitle.Name = "lblPupilReflectLeftTitle";
			this.lblPupilReflectLeftTitle.Size = new System.Drawing.Size(39, 22);
			this.lblPupilReflectLeftTitle.TabIndex = 5985;
			this.lblPupilReflectLeftTitle.Text = "左：";
			// 
			// lblPupilReflectRightTitle
			// 
			this.lblPupilReflectRightTitle.AutoSize = true;
			this.lblPupilReflectRightTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPupilReflectRightTitle.Location = new System.Drawing.Point(156, 28);
			this.lblPupilReflectRightTitle.Name = "lblPupilReflectRightTitle";
			this.lblPupilReflectRightTitle.Size = new System.Drawing.Size(39, 22);
			this.lblPupilReflectRightTitle.TabIndex = 5984;
			this.lblPupilReflectRightTitle.Text = "右：";
			// 
			// txtPupilReflectLeft
			// 
			this.txtPupilReflectLeft.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtPupilReflectLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPupilReflectLeft.ForeColor = System.Drawing.Color.White;
			this.txtPupilReflectLeft.Location = new System.Drawing.Point(60, 28);
			this.txtPupilReflectLeft.m_BlnIgnoreUserInfo = false;
			this.txtPupilReflectLeft.m_BlnPartControl = false;
			this.txtPupilReflectLeft.m_BlnReadOnly = false;
			this.txtPupilReflectLeft.m_BlnUnderLineDST = false;
			this.txtPupilReflectLeft.m_ClrDST = System.Drawing.Color.Red;
			this.txtPupilReflectLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtPupilReflectLeft.m_IntCanModifyTime = 6;
			this.txtPupilReflectLeft.m_IntPartControlLength = 0;
			this.txtPupilReflectLeft.m_IntPartControlStartIndex = 0;
			this.txtPupilReflectLeft.m_StrUserID = "";
			this.txtPupilReflectLeft.m_StrUserName = "";
			this.txtPupilReflectLeft.Multiline = false;
			this.txtPupilReflectLeft.Name = "txtPupilReflectLeft";
			this.txtPupilReflectLeft.Size = new System.Drawing.Size(52, 20);
			this.txtPupilReflectLeft.TabIndex = 5983;
			this.txtPupilReflectLeft.Text = "";
			// 
			// gpbPupilSize
			// 
			this.gpbPupilSize.Controls.Add(this.lblCm1Title);
			this.gpbPupilSize.Controls.Add(this.lblCm2Title);
			this.gpbPupilSize.Controls.Add(this.txtPupilSizeRight);
			this.gpbPupilSize.Controls.Add(this.lblPupilSizeLeftTitle);
			this.gpbPupilSize.Controls.Add(this.lblPupilSizeRightTitle);
			this.gpbPupilSize.Controls.Add(this.txtPupilSizeLeft);
			this.gpbPupilSize.Location = new System.Drawing.Point(12, 20);
			this.gpbPupilSize.Name = "gpbPupilSize";
			this.gpbPupilSize.Size = new System.Drawing.Size(288, 52);
			this.gpbPupilSize.TabIndex = 612;
			this.gpbPupilSize.TabStop = false;
			this.gpbPupilSize.Text = "大小";
			// 
			// lblCm1Title
			// 
			this.lblCm1Title.AutoSize = true;
			this.lblCm1Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCm1Title.Location = new System.Drawing.Point(116, 28);
			this.lblCm1Title.Name = "lblCm1Title";
			this.lblCm1Title.Size = new System.Drawing.Size(22, 22);
			this.lblCm1Title.TabIndex = 5982;
			this.lblCm1Title.Text = "cm";
			// 
			// lblCm2Title
			// 
			this.lblCm2Title.AutoSize = true;
			this.lblCm2Title.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblCm2Title.Location = new System.Drawing.Point(248, 28);
			this.lblCm2Title.Name = "lblCm2Title";
			this.lblCm2Title.Size = new System.Drawing.Size(22, 22);
			this.lblCm2Title.TabIndex = 5981;
			this.lblCm2Title.Text = "cm";
			// 
			// txtPupilSizeRight
			// 
			this.txtPupilSizeRight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtPupilSizeRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPupilSizeRight.ForeColor = System.Drawing.Color.White;
			this.txtPupilSizeRight.Location = new System.Drawing.Point(188, 28);
			this.txtPupilSizeRight.m_BlnIgnoreUserInfo = false;
			this.txtPupilSizeRight.m_BlnPartControl = false;
			this.txtPupilSizeRight.m_BlnReadOnly = false;
			this.txtPupilSizeRight.m_BlnUnderLineDST = false;
			this.txtPupilSizeRight.m_ClrDST = System.Drawing.Color.Red;
			this.txtPupilSizeRight.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtPupilSizeRight.m_IntCanModifyTime = 6;
			this.txtPupilSizeRight.m_IntPartControlLength = 0;
			this.txtPupilSizeRight.m_IntPartControlStartIndex = 0;
			this.txtPupilSizeRight.m_StrUserID = "";
			this.txtPupilSizeRight.m_StrUserName = "";
			this.txtPupilSizeRight.Multiline = false;
			this.txtPupilSizeRight.Name = "txtPupilSizeRight";
			this.txtPupilSizeRight.Size = new System.Drawing.Size(52, 20);
			this.txtPupilSizeRight.TabIndex = 5980;
			this.txtPupilSizeRight.Text = "";
			// 
			// lblPupilSizeLeftTitle
			// 
			this.lblPupilSizeLeftTitle.AutoSize = true;
			this.lblPupilSizeLeftTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPupilSizeLeftTitle.Location = new System.Drawing.Point(9, 28);
			this.lblPupilSizeLeftTitle.Name = "lblPupilSizeLeftTitle";
			this.lblPupilSizeLeftTitle.Size = new System.Drawing.Size(39, 22);
			this.lblPupilSizeLeftTitle.TabIndex = 5979;
			this.lblPupilSizeLeftTitle.Text = "左：";
			// 
			// lblPupilSizeRightTitle
			// 
			this.lblPupilSizeRightTitle.AutoSize = true;
			this.lblPupilSizeRightTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblPupilSizeRightTitle.Location = new System.Drawing.Point(144, 28);
			this.lblPupilSizeRightTitle.Name = "lblPupilSizeRightTitle";
			this.lblPupilSizeRightTitle.Size = new System.Drawing.Size(39, 22);
			this.lblPupilSizeRightTitle.TabIndex = 5978;
			this.lblPupilSizeRightTitle.Text = "右：";
			// 
			// txtPupilSizeLeft
			// 
			this.txtPupilSizeLeft.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtPupilSizeLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtPupilSizeLeft.ForeColor = System.Drawing.Color.White;
			this.txtPupilSizeLeft.Location = new System.Drawing.Point(56, 28);
			this.txtPupilSizeLeft.m_BlnIgnoreUserInfo = false;
			this.txtPupilSizeLeft.m_BlnPartControl = false;
			this.txtPupilSizeLeft.m_BlnReadOnly = false;
			this.txtPupilSizeLeft.m_BlnUnderLineDST = false;
			this.txtPupilSizeLeft.m_ClrDST = System.Drawing.Color.Red;
			this.txtPupilSizeLeft.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtPupilSizeLeft.m_IntCanModifyTime = 6;
			this.txtPupilSizeLeft.m_IntPartControlLength = 0;
			this.txtPupilSizeLeft.m_IntPartControlStartIndex = 0;
			this.txtPupilSizeLeft.m_StrUserID = "";
			this.txtPupilSizeLeft.m_StrUserName = "";
			this.txtPupilSizeLeft.Multiline = false;
			this.txtPupilSizeLeft.Name = "txtPupilSizeLeft";
			this.txtPupilSizeLeft.Size = new System.Drawing.Size(52, 20);
			this.txtPupilSizeLeft.TabIndex = 5977;
			this.txtPupilSizeLeft.Text = "";
			// 
			// lblWardParamTitle
			// 
			this.lblWardParamTitle.AutoSize = true;
			this.lblWardParamTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblWardParamTitle.Location = new System.Drawing.Point(368, 416);
			this.lblWardParamTitle.Name = "lblWardParamTitle";
			this.lblWardParamTitle.Size = new System.Drawing.Size(105, 22);
			this.lblWardParamTitle.TabIndex = 5984;
			this.lblWardParamTitle.Text = "监护仪参数：";
			// 
			// lblBreathParmTitle
			// 
			this.lblBreathParmTitle.AutoSize = true;
			this.lblBreathParmTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBreathParmTitle.Location = new System.Drawing.Point(12, 416);
			this.lblBreathParmTitle.Name = "lblBreathParmTitle";
			this.lblBreathParmTitle.Size = new System.Drawing.Size(105, 22);
			this.lblBreathParmTitle.TabIndex = 5983;
			this.lblBreathParmTitle.Text = "呼吸机参数：";
			// 
			// lsvWardParameter
			// 
			this.lsvWardParameter.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lsvWardParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsvWardParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							   this.clmWardParamName,
																							   this.clmWardParamNum});
			this.lsvWardParameter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvWardParameter.ForeColor = System.Drawing.Color.White;
			this.lsvWardParameter.FullRowSelect = true;
			this.lsvWardParameter.GridLines = true;
			this.lsvWardParameter.Location = new System.Drawing.Point(368, 444);
			this.lsvWardParameter.MultiSelect = false;
			this.lsvWardParameter.Name = "lsvWardParameter";
			this.lsvWardParameter.Size = new System.Drawing.Size(348, 200);
			this.lsvWardParameter.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lsvWardParameter.TabIndex = 5982;
			this.lsvWardParameter.View = System.Windows.Forms.View.Details;
			// 
			// clmWardParamName
			// 
			this.clmWardParamName.Text = "参数";
			this.clmWardParamName.Width = 174;
			// 
			// clmWardParamNum
			// 
			this.clmWardParamNum.Text = "数值";
			this.clmWardParamNum.Width = 174;
			// 
			// lsvBreathParameter
			// 
			this.lsvBreathParameter.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lsvBreathParameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsvBreathParameter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.clmBreathParamName,
																								 this.clmBreathParamNum});
			this.lsvBreathParameter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvBreathParameter.ForeColor = System.Drawing.Color.White;
			this.lsvBreathParameter.FullRowSelect = true;
			this.lsvBreathParameter.GridLines = true;
			this.lsvBreathParameter.Location = new System.Drawing.Point(12, 444);
			this.lsvBreathParameter.MultiSelect = false;
			this.lsvBreathParameter.Name = "lsvBreathParameter";
			this.lsvBreathParameter.Size = new System.Drawing.Size(348, 200);
			this.lsvBreathParameter.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lsvBreathParameter.TabIndex = 5981;
			this.lsvBreathParameter.View = System.Windows.Forms.View.Details;
			// 
			// clmBreathParamName
			// 
			this.clmBreathParamName.Text = "参数";
			this.clmBreathParamName.Width = 174;
			// 
			// clmBreathParamNum
			// 
			this.clmBreathParamNum.Text = "数值";
			this.clmBreathParamNum.Width = 174;
			// 
			// txtRecord
			// 
			this.txtRecord.AccessibleDescription = "病程记录";
			this.txtRecord.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtRecord.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRecord.ForeColor = System.Drawing.Color.White;
			this.txtRecord.Location = new System.Drawing.Point(104, 304);
			this.txtRecord.m_BlnIgnoreUserInfo = false;
			this.txtRecord.m_BlnPartControl = false;
			this.txtRecord.m_BlnReadOnly = false;
			this.txtRecord.m_BlnUnderLineDST = false;
			this.txtRecord.m_ClrDST = System.Drawing.Color.Red;
			this.txtRecord.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtRecord.m_IntCanModifyTime = 6;
			this.txtRecord.m_IntPartControlLength = 0;
			this.txtRecord.m_IntPartControlStartIndex = 0;
			this.txtRecord.m_StrUserID = "";
			this.txtRecord.m_StrUserName = "";
			this.txtRecord.Name = "txtRecord";
			this.txtRecord.Size = new System.Drawing.Size(612, 80);
			this.txtRecord.TabIndex = 5974;
			this.txtRecord.Text = "";
			// 
			// lblRecordTitle
			// 
			this.lblRecordTitle.AutoSize = true;
			this.lblRecordTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRecordTitle.Location = new System.Drawing.Point(12, 304);
			this.lblRecordTitle.Name = "lblRecordTitle";
			this.lblRecordTitle.Size = new System.Drawing.Size(88, 22);
			this.lblRecordTitle.TabIndex = 5973;
			this.lblRecordTitle.Text = "病程记录：";
			// 
			// lblC
			// 
			this.lblC.AutoSize = true;
			this.lblC.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblC.Location = new System.Drawing.Point(148, 88);
			this.lblC.Name = "lblC";
			this.lblC.Size = new System.Drawing.Size(14, 22);
			this.lblC.TabIndex = 5940;
			this.lblC.Text = "C";
			// 
			// lblO
			// 
			this.lblO.AutoSize = true;
			this.lblO.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblO.Location = new System.Drawing.Point(140, 84);
			this.lblO.Name = "lblO";
			this.lblO.Size = new System.Drawing.Size(12, 19);
			this.lblO.TabIndex = 5941;
			this.lblO.Text = "o";
			// 
			// txtTemperature
			// 
			this.txtTemperature.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtTemperature.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtTemperature.ForeColor = System.Drawing.Color.White;
			this.txtTemperature.Location = new System.Drawing.Point(84, 88);
			this.txtTemperature.m_BlnIgnoreUserInfo = false;
			this.txtTemperature.m_BlnPartControl = false;
			this.txtTemperature.m_BlnReadOnly = false;
			this.txtTemperature.m_BlnUnderLineDST = false;
			this.txtTemperature.m_ClrDST = System.Drawing.Color.Red;
			this.txtTemperature.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.txtTemperature.m_IntCanModifyTime = 6;
			this.txtTemperature.m_IntPartControlLength = 0;
			this.txtTemperature.m_IntPartControlStartIndex = 0;
			this.txtTemperature.m_StrUserID = "";
			this.txtTemperature.m_StrUserName = "";
			this.txtTemperature.Multiline = false;
			this.txtTemperature.Name = "txtTemperature";
			this.txtTemperature.Size = new System.Drawing.Size(52, 20);
			this.txtTemperature.TabIndex = 5939;
			this.txtTemperature.Text = "";
			// 
			// lblTemperatureTitle
			// 
			this.lblTemperatureTitle.AutoSize = true;
			this.lblTemperatureTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblTemperatureTitle.Location = new System.Drawing.Point(16, 88);
			this.lblTemperatureTitle.Name = "lblTemperatureTitle";
			this.lblTemperatureTitle.Size = new System.Drawing.Size(55, 22);
			this.lblTemperatureTitle.TabIndex = 502;
			this.lblTemperatureTitle.Text = "体温：";
			// 
			// lblDepartmentTitle
			// 
			this.lblDepartmentTitle.AutoSize = true;
			this.lblDepartmentTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDepartmentTitle.Location = new System.Drawing.Point(212, 20);
			this.lblDepartmentTitle.Name = "lblDepartmentTitle";
			this.lblDepartmentTitle.Size = new System.Drawing.Size(55, 22);
			this.lblDepartmentTitle.TabIndex = 501;
			this.lblDepartmentTitle.Text = "科室：";
			// 
			// lblDepartment
			// 
			this.lblDepartment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDepartment.Location = new System.Drawing.Point(272, 20);
			this.lblDepartment.Name = "lblDepartment";
			this.lblDepartment.Size = new System.Drawing.Size(132, 20);
			this.lblDepartment.TabIndex = 500;
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblYear.Location = new System.Drawing.Point(376, 52);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(22, 22);
			this.lblYear.TabIndex = 499;
			this.lblYear.Text = "岁";
			// 
			// lblArea
			// 
			this.lblArea.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblArea.Location = new System.Drawing.Point(472, 20);
			this.lblArea.Name = "lblArea";
			this.lblArea.Size = new System.Drawing.Size(72, 19);
			this.lblArea.TabIndex = 498;
			// 
			// lblBedNo
			// 
			this.lblBedNo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBedNo.Location = new System.Drawing.Point(608, 20);
			this.lblBedNo.Name = "lblBedNo";
			this.lblBedNo.Size = new System.Drawing.Size(48, 19);
			this.lblBedNo.TabIndex = 497;
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.AutoSize = true;
			this.lblBedNoTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBedNoTitle.Location = new System.Drawing.Point(548, 20);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			this.lblBedNoTitle.Size = new System.Drawing.Size(55, 22);
			this.lblBedNoTitle.TabIndex = 496;
			this.lblBedNoTitle.Text = "床号：";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.AutoSize = true;
			this.lblAreaTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAreaTitle.Location = new System.Drawing.Point(408, 20);
			this.lblAreaTitle.Name = "lblAreaTitle";
			this.lblAreaTitle.Size = new System.Drawing.Size(55, 22);
			this.lblAreaTitle.TabIndex = 495;
			this.lblAreaTitle.Text = "病区：";
			// 
			// lblSex
			// 
			this.lblSex.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSex.Location = new System.Drawing.Point(224, 52);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(44, 19);
			this.lblSex.TabIndex = 494;
			// 
			// lblAge
			// 
			this.lblAge.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAge.Location = new System.Drawing.Point(332, 52);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(40, 19);
			this.lblAge.TabIndex = 493;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.AutoSize = true;
			this.lblInHospitalNoTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(16, 20);
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			this.lblInHospitalNoTitle.Size = new System.Drawing.Size(72, 22);
			this.lblInHospitalNoTitle.TabIndex = 492;
			this.lblInHospitalNoTitle.Text = "住院号：";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.Location = new System.Drawing.Point(16, 52);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(55, 22);
			this.lblNameTitle.TabIndex = 491;
			this.lblNameTitle.Text = "姓名：";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.Location = new System.Drawing.Point(164, 52);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(55, 22);
			this.lblSexTitle.TabIndex = 490;
			this.lblSexTitle.Text = "性别：";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.AutoSize = true;
			this.lblAgeTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAgeTitle.Location = new System.Drawing.Point(272, 52);
			this.lblAgeTitle.Name = "lblAgeTitle";
			this.lblAgeTitle.Size = new System.Drawing.Size(55, 22);
			this.lblAgeTitle.TabIndex = 489;
			this.lblAgeTitle.Text = "年龄：";
			// 
			// lblName
			// 
			this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblName.Location = new System.Drawing.Point(76, 52);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(84, 20);
			this.lblName.TabIndex = 488;
			// 
			// frmICUNursingRecord
			// 
			this.AccessibleDescription = "ICU危重病人护理记录";
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(1024, 753);
			this.Controls.Add(this.pnlRecord);
			this.Controls.Add(this.sptTrvAndRecord);
			this.Controls.Add(this.trvICUNurseRecord);
			this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.ForeColor = System.Drawing.Color.White;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmICUNursingRecord";
			this.Text = "ICU危重病人护理记录";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.frmICUNursingRecord_Load);
			this.pnlRecord.ResumeLayout(false);
			this.gpbOutQty.ResumeLayout(false);
			this.gpbInQty.ResumeLayout(false);
			this.gpbPupil.ResumeLayout(false);
			this.gpbPupilReflect.ResumeLayout(false);
			this.gpbPupilSize.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmICUNursingRecord_Load(object sender, System.EventArgs e)
		{
		trvICUNurseRecord.Focus();	
		}

	
	}
}
