using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace iCare
{
	public class frmPathologyTissueCheckOrder : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.Label lblCheckObject;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtCheckObject;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtWhereBody;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtIllnessLong;
		private System.Windows.Forms.Label lblWhereBody;
		private System.Windows.Forms.Label lblIllnessLong;
		private System.Windows.Forms.Label lblIllnessResume;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtIllnessResume;
		private System.Windows.Forms.Label lblClinicCase;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtClinicCase;
		private System.Windows.Forms.Label lblOperationCase;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOperationCase;
		private System.Windows.Forms.Label lblApplyCheckIntent;
		private System.Windows.Forms.Label lblAssay;
		private System.Windows.Forms.Label lblBlood;
		private System.Windows.Forms.Label lblXRay;
		private System.Windows.Forms.Label lblBacilliBlood;
		private System.Windows.Forms.Label lblOther;
		private System.Windows.Forms.Label lblClinicDiagonse;
		private System.Windows.Forms.Label lblExplain_1;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtApplyCheckIntent;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtAssay;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtBlood;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtXRay;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtBacilliBlood;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtOther;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtClinicDiagonse;
		private System.Windows.Forms.Label lblDoc;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDoc;
		private System.Windows.Forms.Label lblExplain_2;
		private System.Windows.Forms.Label lblCheckDate;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtCheckDate;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtYear;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtMonth;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtDay;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtReceriveDate;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblMonth;
		private System.Windows.Forms.Label lblDay;
		private System.Windows.Forms.Label lblReceiveDate;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtAmorPm;
		private System.Windows.Forms.Label lblAmorPm;
		private System.Windows.Forms.Label lblClassify;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtClassify;
		private System.Windows.Forms.Label lblClinicNum;
		private System.Windows.Forms.Label label3;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox ctlBorderTextBox2;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtClinicNum;
		private System.ComponentModel.IContainer components = null;

		public frmPathologyTissueCheckOrder()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblCheckObject = new System.Windows.Forms.Label();
            this.m_txtCheckObject = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtWhereBody = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtIllnessLong = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblWhereBody = new System.Windows.Forms.Label();
            this.lblIllnessLong = new System.Windows.Forms.Label();
            this.lblIllnessResume = new System.Windows.Forms.Label();
            this.m_txtIllnessResume = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblClinicCase = new System.Windows.Forms.Label();
            this.m_txtClinicCase = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblOperationCase = new System.Windows.Forms.Label();
            this.m_txtOperationCase = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblApplyCheckIntent = new System.Windows.Forms.Label();
            this.lblAssay = new System.Windows.Forms.Label();
            this.lblBlood = new System.Windows.Forms.Label();
            this.lblXRay = new System.Windows.Forms.Label();
            this.lblBacilliBlood = new System.Windows.Forms.Label();
            this.lblOther = new System.Windows.Forms.Label();
            this.lblClinicDiagonse = new System.Windows.Forms.Label();
            this.lblExplain_1 = new System.Windows.Forms.Label();
            this.m_txtApplyCheckIntent = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtAssay = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtBlood = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtXRay = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtBacilliBlood = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtOther = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtClinicDiagonse = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblDoc = new System.Windows.Forms.Label();
            this.m_txtDoc = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblExplain_2 = new System.Windows.Forms.Label();
            this.lblCheckDate = new System.Windows.Forms.Label();
            this.m_txtCheckDate = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtYear = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtMonth = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtDay = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtReceriveDate = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblReceiveDate = new System.Windows.Forms.Label();
            this.m_txtAmorPm = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblAmorPm = new System.Windows.Forms.Label();
            this.lblClassify = new System.Windows.Forms.Label();
            this.m_txtClassify = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lblClinicNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlBorderTextBox2 = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtClinicNum = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.SuspendLayout();
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Size = new System.Drawing.Size(396, 48);
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(719, 34);
            // 
            // lblCheckObject
            // 
            this.lblCheckObject.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckObject.Location = new System.Drawing.Point(16, 268);
            this.lblCheckObject.Name = "lblCheckObject";
            this.lblCheckObject.Size = new System.Drawing.Size(64, 24);
            this.lblCheckObject.TabIndex = 501;
            this.lblCheckObject.Text = "检验物";
            // 
            // m_txtCheckObject
            // 
            this.m_txtCheckObject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtCheckObject.BorderColor = System.Drawing.Color.White;
            this.m_txtCheckObject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCheckObject.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtCheckObject.Location = new System.Drawing.Point(112, 260);
            this.m_txtCheckObject.Multiline = true;
            this.m_txtCheckObject.Name = "m_txtCheckObject";
            this.m_txtCheckObject.Size = new System.Drawing.Size(192, 32);
            this.m_txtCheckObject.TabIndex = 533;
            // 
            // m_txtWhereBody
            // 
            this.m_txtWhereBody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtWhereBody.BorderColor = System.Drawing.Color.White;
            this.m_txtWhereBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtWhereBody.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtWhereBody.Location = new System.Drawing.Point(436, 260);
            this.m_txtWhereBody.Multiline = true;
            this.m_txtWhereBody.Name = "m_txtWhereBody";
            this.m_txtWhereBody.Size = new System.Drawing.Size(184, 40);
            this.m_txtWhereBody.TabIndex = 534;
            // 
            // m_txtIllnessLong
            // 
            this.m_txtIllnessLong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtIllnessLong.BorderColor = System.Drawing.Color.White;
            this.m_txtIllnessLong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtIllnessLong.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtIllnessLong.Location = new System.Drawing.Point(712, 260);
            this.m_txtIllnessLong.Multiline = true;
            this.m_txtIllnessLong.Name = "m_txtIllnessLong";
            this.m_txtIllnessLong.Size = new System.Drawing.Size(168, 40);
            this.m_txtIllnessLong.TabIndex = 535;
            // 
            // lblWhereBody
            // 
            this.lblWhereBody.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWhereBody.Location = new System.Drawing.Point(312, 268);
            this.lblWhereBody.Name = "lblWhereBody";
            this.lblWhereBody.Size = new System.Drawing.Size(112, 24);
            this.lblWhereBody.TabIndex = 536;
            this.lblWhereBody.Text = "取自身体何处";
            // 
            // lblIllnessLong
            // 
            this.lblIllnessLong.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIllnessLong.Location = new System.Drawing.Point(632, 268);
            this.lblIllnessLong.Name = "lblIllnessLong";
            this.lblIllnessLong.Size = new System.Drawing.Size(72, 24);
            this.lblIllnessLong.TabIndex = 537;
            this.lblIllnessLong.Text = "患病久暂";
            // 
            // lblIllnessResume
            // 
            this.lblIllnessResume.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIllnessResume.Location = new System.Drawing.Point(16, 312);
            this.lblIllnessResume.Name = "lblIllnessResume";
            this.lblIllnessResume.Size = new System.Drawing.Size(652, 24);
            this.lblIllnessResume.TabIndex = 538;
            this.lblIllnessResume.Text = "病历撮要：（妇产科标本请注明末次月经日期、产次、经初潮日期及妇科之内外检结果）";
            // 
            // m_txtIllnessResume
            // 
            this.m_txtIllnessResume.AccessibleDescription = "病历撮要";
            this.m_txtIllnessResume.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtIllnessResume.BorderColor = System.Drawing.Color.White;
            this.m_txtIllnessResume.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtIllnessResume.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtIllnessResume.Location = new System.Drawing.Point(120, 344);
            this.m_txtIllnessResume.Multiline = true;
            this.m_txtIllnessResume.Name = "m_txtIllnessResume";
            this.m_txtIllnessResume.Size = new System.Drawing.Size(760, 88);
            this.m_txtIllnessResume.TabIndex = 539;
            // 
            // lblClinicCase
            // 
            this.lblClinicCase.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicCase.Location = new System.Drawing.Point(16, 444);
            this.lblClinicCase.Name = "lblClinicCase";
            this.lblClinicCase.Size = new System.Drawing.Size(88, 24);
            this.lblClinicCase.TabIndex = 540;
            this.lblClinicCase.Text = "临床所见：";
            // 
            // m_txtClinicCase
            // 
            this.m_txtClinicCase.AccessibleDescription = "临床所见";
            this.m_txtClinicCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtClinicCase.BorderColor = System.Drawing.Color.White;
            this.m_txtClinicCase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtClinicCase.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtClinicCase.Location = new System.Drawing.Point(120, 480);
            this.m_txtClinicCase.Multiline = true;
            this.m_txtClinicCase.Name = "m_txtClinicCase";
            this.m_txtClinicCase.Size = new System.Drawing.Size(760, 88);
            this.m_txtClinicCase.TabIndex = 541;
            // 
            // lblOperationCase
            // 
            this.lblOperationCase.AutoSize = true;
            this.lblOperationCase.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperationCase.Location = new System.Drawing.Point(16, 584);
            this.lblOperationCase.Name = "lblOperationCase";
            this.lblOperationCase.Size = new System.Drawing.Size(488, 16);
            this.lblOperationCase.TabIndex = 542;
            this.lblOperationCase.Text = "手术所见：（肿瘤标本请注明肿瘤大小、肿瘤位置、有无转移性瘤）";
            // 
            // m_txtOperationCase
            // 
            this.m_txtOperationCase.AccessibleDescription = "手术所见";
            this.m_txtOperationCase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtOperationCase.BorderColor = System.Drawing.Color.White;
            this.m_txtOperationCase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOperationCase.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOperationCase.Location = new System.Drawing.Point(120, 624);
            this.m_txtOperationCase.Multiline = true;
            this.m_txtOperationCase.Name = "m_txtOperationCase";
            this.m_txtOperationCase.Size = new System.Drawing.Size(760, 88);
            this.m_txtOperationCase.TabIndex = 544;
            // 
            // lblApplyCheckIntent
            // 
            this.lblApplyCheckIntent.AutoSize = true;
            this.lblApplyCheckIntent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplyCheckIntent.Location = new System.Drawing.Point(16, 768);
            this.lblApplyCheckIntent.Name = "lblApplyCheckIntent";
            this.lblApplyCheckIntent.Size = new System.Drawing.Size(120, 16);
            this.lblApplyCheckIntent.TabIndex = 545;
            this.lblApplyCheckIntent.Text = "申请检验目的：";
            // 
            // lblAssay
            // 
            this.lblAssay.AutoSize = true;
            this.lblAssay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAssay.Location = new System.Drawing.Point(16, 824);
            this.lblAssay.Name = "lblAssay";
            this.lblAssay.Size = new System.Drawing.Size(56, 16);
            this.lblAssay.TabIndex = 546;
            this.lblAssay.Text = "生化：";
            // 
            // lblBlood
            // 
            this.lblBlood.AutoSize = true;
            this.lblBlood.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBlood.Location = new System.Drawing.Point(16, 876);
            this.lblBlood.Name = "lblBlood";
            this.lblBlood.Size = new System.Drawing.Size(56, 16);
            this.lblBlood.TabIndex = 547;
            this.lblBlood.Text = "血液：";
            // 
            // lblXRay
            // 
            this.lblXRay.AutoSize = true;
            this.lblXRay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblXRay.Location = new System.Drawing.Point(16, 924);
            this.lblXRay.Name = "lblXRay";
            this.lblXRay.Size = new System.Drawing.Size(48, 16);
            this.lblXRay.TabIndex = 548;
            this.lblXRay.Text = "X光：";
            // 
            // lblBacilliBlood
            // 
            this.lblBacilliBlood.AutoSize = true;
            this.lblBacilliBlood.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBacilliBlood.Location = new System.Drawing.Point(16, 968);
            this.lblBacilliBlood.Name = "lblBacilliBlood";
            this.lblBacilliBlood.Size = new System.Drawing.Size(88, 16);
            this.lblBacilliBlood.TabIndex = 549;
            this.lblBacilliBlood.Text = "细菌血清：";
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOther.Location = new System.Drawing.Point(16, 1024);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(56, 16);
            this.lblOther.TabIndex = 550;
            this.lblOther.Text = "其它：";
            // 
            // lblClinicDiagonse
            // 
            this.lblClinicDiagonse.AutoSize = true;
            this.lblClinicDiagonse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicDiagonse.Location = new System.Drawing.Point(16, 1068);
            this.lblClinicDiagonse.Name = "lblClinicDiagonse";
            this.lblClinicDiagonse.Size = new System.Drawing.Size(88, 16);
            this.lblClinicDiagonse.TabIndex = 551;
            this.lblClinicDiagonse.Text = "临床诊断：";
            // 
            // lblExplain_1
            // 
            this.lblExplain_1.AutoSize = true;
            this.lblExplain_1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExplain_1.Location = new System.Drawing.Point(16, 1152);
            this.lblExplain_1.Name = "lblExplain_1";
            this.lblExplain_1.Size = new System.Drawing.Size(552, 16);
            this.lblExplain_1.TabIndex = 552;
            this.lblExplain_1.Text = "（若系再次送验的病例，请注明以前报告的病理诊断和医检列号，以便查对）";
            // 
            // m_txtApplyCheckIntent
            // 
            this.m_txtApplyCheckIntent.AccessibleDescription = "申请检验目的";
            this.m_txtApplyCheckIntent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtApplyCheckIntent.BorderColor = System.Drawing.Color.White;
            this.m_txtApplyCheckIntent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtApplyCheckIntent.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtApplyCheckIntent.Location = new System.Drawing.Point(120, 756);
            this.m_txtApplyCheckIntent.Multiline = true;
            this.m_txtApplyCheckIntent.Name = "m_txtApplyCheckIntent";
            this.m_txtApplyCheckIntent.Size = new System.Drawing.Size(760, 40);
            this.m_txtApplyCheckIntent.TabIndex = 553;
            // 
            // m_txtAssay
            // 
            this.m_txtAssay.AccessibleDescription = "生化";
            this.m_txtAssay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtAssay.BorderColor = System.Drawing.Color.White;
            this.m_txtAssay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtAssay.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtAssay.Location = new System.Drawing.Point(120, 808);
            this.m_txtAssay.Multiline = true;
            this.m_txtAssay.Name = "m_txtAssay";
            this.m_txtAssay.Size = new System.Drawing.Size(760, 40);
            this.m_txtAssay.TabIndex = 554;
            // 
            // m_txtBlood
            // 
            this.m_txtBlood.AccessibleDescription = "血液";
            this.m_txtBlood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBlood.BorderColor = System.Drawing.Color.White;
            this.m_txtBlood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBlood.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBlood.Location = new System.Drawing.Point(120, 860);
            this.m_txtBlood.Multiline = true;
            this.m_txtBlood.Name = "m_txtBlood";
            this.m_txtBlood.Size = new System.Drawing.Size(760, 40);
            this.m_txtBlood.TabIndex = 555;
            // 
            // m_txtXRay
            // 
            this.m_txtXRay.AccessibleDescription = "X光";
            this.m_txtXRay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtXRay.BorderColor = System.Drawing.Color.White;
            this.m_txtXRay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtXRay.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtXRay.Location = new System.Drawing.Point(120, 912);
            this.m_txtXRay.Multiline = true;
            this.m_txtXRay.Name = "m_txtXRay";
            this.m_txtXRay.Size = new System.Drawing.Size(760, 40);
            this.m_txtXRay.TabIndex = 556;
            // 
            // m_txtBacilliBlood
            // 
            this.m_txtBacilliBlood.AccessibleDescription = "细菌血清";
            this.m_txtBacilliBlood.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtBacilliBlood.BorderColor = System.Drawing.Color.White;
            this.m_txtBacilliBlood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtBacilliBlood.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtBacilliBlood.Location = new System.Drawing.Point(120, 964);
            this.m_txtBacilliBlood.Multiline = true;
            this.m_txtBacilliBlood.Name = "m_txtBacilliBlood";
            this.m_txtBacilliBlood.Size = new System.Drawing.Size(760, 40);
            this.m_txtBacilliBlood.TabIndex = 557;
            // 
            // m_txtOther
            // 
            this.m_txtOther.AccessibleDescription = "其它";
            this.m_txtOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtOther.BorderColor = System.Drawing.Color.White;
            this.m_txtOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOther.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtOther.Location = new System.Drawing.Point(120, 1016);
            this.m_txtOther.Multiline = true;
            this.m_txtOther.Name = "m_txtOther";
            this.m_txtOther.Size = new System.Drawing.Size(760, 40);
            this.m_txtOther.TabIndex = 558;
            // 
            // m_txtClinicDiagonse
            // 
            this.m_txtClinicDiagonse.AccessibleDescription = "临床诊断";
            this.m_txtClinicDiagonse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtClinicDiagonse.BorderColor = System.Drawing.Color.White;
            this.m_txtClinicDiagonse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtClinicDiagonse.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtClinicDiagonse.Location = new System.Drawing.Point(120, 1068);
            this.m_txtClinicDiagonse.Multiline = true;
            this.m_txtClinicDiagonse.Name = "m_txtClinicDiagonse";
            this.m_txtClinicDiagonse.Size = new System.Drawing.Size(480, 68);
            this.m_txtClinicDiagonse.TabIndex = 559;
            // 
            // lblDoc
            // 
            this.lblDoc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDoc.Location = new System.Drawing.Point(616, 1076);
            this.lblDoc.Name = "lblDoc";
            this.lblDoc.Size = new System.Drawing.Size(56, 24);
            this.lblDoc.TabIndex = 560;
            this.lblDoc.Text = "医师：";
            // 
            // m_txtDoc
            // 
            this.m_txtDoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtDoc.BorderColor = System.Drawing.Color.White;
            this.m_txtDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtDoc.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtDoc.Location = new System.Drawing.Point(692, 1072);
            this.m_txtDoc.Multiline = true;
            this.m_txtDoc.Name = "m_txtDoc";
            this.m_txtDoc.Size = new System.Drawing.Size(188, 28);
            this.m_txtDoc.TabIndex = 561;
            // 
            // lblExplain_2
            // 
            this.lblExplain_2.AutoSize = true;
            this.lblExplain_2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExplain_2.Location = new System.Drawing.Point(16, 1189);
            this.lblExplain_2.Name = "lblExplain_2";
            this.lblExplain_2.Size = new System.Drawing.Size(200, 16);
            this.lblExplain_2.TabIndex = 562;
            this.lblExplain_2.Text = "（以上各栏由送检人填写）";
            // 
            // lblCheckDate
            // 
            this.lblCheckDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckDate.Location = new System.Drawing.Point(24, 1232);
            this.lblCheckDate.Name = "lblCheckDate";
            this.lblCheckDate.Size = new System.Drawing.Size(72, 16);
            this.lblCheckDate.TabIndex = 563;
            this.lblCheckDate.Text = "送验日期";
            // 
            // m_txtCheckDate
            // 
            this.m_txtCheckDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtCheckDate.BorderColor = System.Drawing.Color.White;
            this.m_txtCheckDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtCheckDate.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtCheckDate.Location = new System.Drawing.Point(104, 1224);
            this.m_txtCheckDate.Multiline = true;
            this.m_txtCheckDate.Name = "m_txtCheckDate";
            this.m_txtCheckDate.Size = new System.Drawing.Size(120, 24);
            this.m_txtCheckDate.TabIndex = 564;
            // 
            // m_txtYear
            // 
            this.m_txtYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtYear.BorderColor = System.Drawing.Color.White;
            this.m_txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtYear.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtYear.Location = new System.Drawing.Point(264, 1224);
            this.m_txtYear.Multiline = true;
            this.m_txtYear.Name = "m_txtYear";
            this.m_txtYear.Size = new System.Drawing.Size(56, 24);
            this.m_txtYear.TabIndex = 565;
            // 
            // m_txtMonth
            // 
            this.m_txtMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtMonth.BorderColor = System.Drawing.Color.White;
            this.m_txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtMonth.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtMonth.Location = new System.Drawing.Point(352, 1224);
            this.m_txtMonth.Multiline = true;
            this.m_txtMonth.Name = "m_txtMonth";
            this.m_txtMonth.Size = new System.Drawing.Size(40, 24);
            this.m_txtMonth.TabIndex = 566;
            // 
            // m_txtDay
            // 
            this.m_txtDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtDay.BorderColor = System.Drawing.Color.White;
            this.m_txtDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtDay.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtDay.Location = new System.Drawing.Point(424, 1224);
            this.m_txtDay.Multiline = true;
            this.m_txtDay.Name = "m_txtDay";
            this.m_txtDay.Size = new System.Drawing.Size(40, 24);
            this.m_txtDay.TabIndex = 567;
            // 
            // m_txtReceriveDate
            // 
            this.m_txtReceriveDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtReceriveDate.BorderColor = System.Drawing.Color.White;
            this.m_txtReceriveDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtReceriveDate.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtReceriveDate.Location = new System.Drawing.Point(744, 1224);
            this.m_txtReceriveDate.Multiline = true;
            this.m_txtReceriveDate.Name = "m_txtReceriveDate";
            this.m_txtReceriveDate.Size = new System.Drawing.Size(136, 24);
            this.m_txtReceriveDate.TabIndex = 568;
            // 
            // lblYear
            // 
            this.lblYear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblYear.Location = new System.Drawing.Point(328, 1232);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(24, 16);
            this.lblYear.TabIndex = 569;
            this.lblYear.Text = "年";
            // 
            // lblMonth
            // 
            this.lblMonth.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMonth.Location = new System.Drawing.Point(400, 1232);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(24, 16);
            this.lblMonth.TabIndex = 570;
            this.lblMonth.Text = "月";
            // 
            // lblDay
            // 
            this.lblDay.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDay.Location = new System.Drawing.Point(472, 1232);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(24, 16);
            this.lblDay.TabIndex = 571;
            this.lblDay.Text = "日";
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblReceiveDate.Location = new System.Drawing.Point(608, 1232);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(124, 16);
            this.lblReceiveDate.TabIndex = 572;
            this.lblReceiveDate.Text = "本室收到日期：";
            // 
            // m_txtAmorPm
            // 
            this.m_txtAmorPm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtAmorPm.BorderColor = System.Drawing.Color.White;
            this.m_txtAmorPm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtAmorPm.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtAmorPm.Location = new System.Drawing.Point(496, 1224);
            this.m_txtAmorPm.Multiline = true;
            this.m_txtAmorPm.Name = "m_txtAmorPm";
            this.m_txtAmorPm.Size = new System.Drawing.Size(40, 24);
            this.m_txtAmorPm.TabIndex = 573;
            // 
            // lblAmorPm
            // 
            this.lblAmorPm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAmorPm.Location = new System.Drawing.Point(552, 1232);
            this.lblAmorPm.Name = "lblAmorPm";
            this.lblAmorPm.Size = new System.Drawing.Size(24, 16);
            this.lblAmorPm.TabIndex = 574;
            this.lblAmorPm.Text = "午";
            // 
            // lblClassify
            // 
            this.lblClassify.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClassify.Location = new System.Drawing.Point(16, 220);
            this.lblClassify.Name = "lblClassify";
            this.lblClassify.Size = new System.Drawing.Size(64, 24);
            this.lblClassify.TabIndex = 575;
            this.lblClassify.Text = "科别";
            // 
            // m_txtClassify
            // 
            this.m_txtClassify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtClassify.BorderColor = System.Drawing.Color.White;
            this.m_txtClassify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtClassify.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtClassify.Location = new System.Drawing.Point(112, 216);
            this.m_txtClassify.Multiline = true;
            this.m_txtClassify.Name = "m_txtClassify";
            this.m_txtClassify.Size = new System.Drawing.Size(192, 32);
            this.m_txtClassify.TabIndex = 576;
            // 
            // lblClinicNum
            // 
            this.lblClinicNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblClinicNum.Location = new System.Drawing.Point(316, 220);
            this.lblClinicNum.Name = "lblClinicNum";
            this.lblClinicNum.Size = new System.Drawing.Size(120, 24);
            this.lblClinicNum.TabIndex = 577;
            this.lblClinicNum.Text = "门诊/住院号数";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(584, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 578;
            this.label3.Text = "上次医检列号";
            // 
            // ctlBorderTextBox2
            // 
            this.ctlBorderTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.ctlBorderTextBox2.BorderColor = System.Drawing.Color.White;
            this.ctlBorderTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctlBorderTextBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.ctlBorderTextBox2.Location = new System.Drawing.Point(712, 212);
            this.ctlBorderTextBox2.Multiline = true;
            this.ctlBorderTextBox2.Name = "ctlBorderTextBox2";
            this.ctlBorderTextBox2.Size = new System.Drawing.Size(168, 32);
            this.ctlBorderTextBox2.TabIndex = 579;
            // 
            // m_txtClinicNum
            // 
            this.m_txtClinicNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_txtClinicNum.BorderColor = System.Drawing.Color.White;
            this.m_txtClinicNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtClinicNum.ForeColor = System.Drawing.SystemColors.Window;
            this.m_txtClinicNum.Location = new System.Drawing.Point(432, 216);
            this.m_txtClinicNum.Multiline = true;
            this.m_txtClinicNum.Name = "m_txtClinicNum";
            this.m_txtClinicNum.Size = new System.Drawing.Size(132, 32);
            this.m_txtClinicNum.TabIndex = 580;
            // 
            // frmPathologyTissueCheckOrder
            // 
            this.AccessibleDescription = "病理活体组织送验单";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(968, 709);
            this.Controls.Add(this.m_txtClinicNum);
            this.Controls.Add(this.ctlBorderTextBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblClinicNum);
            this.Controls.Add(this.m_txtClassify);
            this.Controls.Add(this.lblClassify);
            this.Controls.Add(this.lblAmorPm);
            this.Controls.Add(this.m_txtAmorPm);
            this.Controls.Add(this.lblReceiveDate);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.m_txtReceriveDate);
            this.Controls.Add(this.m_txtDay);
            this.Controls.Add(this.m_txtMonth);
            this.Controls.Add(this.m_txtYear);
            this.Controls.Add(this.m_txtCheckDate);
            this.Controls.Add(this.lblCheckDate);
            this.Controls.Add(this.lblExplain_2);
            this.Controls.Add(this.m_txtDoc);
            this.Controls.Add(this.lblDoc);
            this.Controls.Add(this.m_txtClinicDiagonse);
            this.Controls.Add(this.m_txtOther);
            this.Controls.Add(this.m_txtBacilliBlood);
            this.Controls.Add(this.m_txtXRay);
            this.Controls.Add(this.m_txtBlood);
            this.Controls.Add(this.m_txtAssay);
            this.Controls.Add(this.m_txtApplyCheckIntent);
            this.Controls.Add(this.lblExplain_1);
            this.Controls.Add(this.lblClinicDiagonse);
            this.Controls.Add(this.lblOther);
            this.Controls.Add(this.lblBacilliBlood);
            this.Controls.Add(this.lblXRay);
            this.Controls.Add(this.lblBlood);
            this.Controls.Add(this.lblAssay);
            this.Controls.Add(this.lblApplyCheckIntent);
            this.Controls.Add(this.m_txtOperationCase);
            this.Controls.Add(this.lblOperationCase);
            this.Controls.Add(this.m_txtClinicCase);
            this.Controls.Add(this.lblClinicCase);
            this.Controls.Add(this.m_txtIllnessResume);
            this.Controls.Add(this.lblIllnessResume);
            this.Controls.Add(this.lblIllnessLong);
            this.Controls.Add(this.lblWhereBody);
            this.Controls.Add(this.m_txtIllnessLong);
            this.Controls.Add(this.m_txtWhereBody);
            this.Controls.Add(this.m_txtCheckObject);
            this.Controls.Add(this.lblCheckObject);
            this.Name = "frmPathologyTissueCheckOrder";
            this.Text = "病理活体组织送验单";
            this.Load += new System.EventHandler(this.frmPathologyTissueCheckOrder_Load);
            this.Controls.SetChildIndex(this.lblCheckObject, 0);
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
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtCheckObject, 0);
            this.Controls.SetChildIndex(this.m_txtWhereBody, 0);
            this.Controls.SetChildIndex(this.m_txtIllnessLong, 0);
            this.Controls.SetChildIndex(this.lblWhereBody, 0);
            this.Controls.SetChildIndex(this.lblIllnessLong, 0);
            this.Controls.SetChildIndex(this.lblIllnessResume, 0);
            this.Controls.SetChildIndex(this.m_txtIllnessResume, 0);
            this.Controls.SetChildIndex(this.lblClinicCase, 0);
            this.Controls.SetChildIndex(this.m_txtClinicCase, 0);
            this.Controls.SetChildIndex(this.lblOperationCase, 0);
            this.Controls.SetChildIndex(this.m_txtOperationCase, 0);
            this.Controls.SetChildIndex(this.lblApplyCheckIntent, 0);
            this.Controls.SetChildIndex(this.lblAssay, 0);
            this.Controls.SetChildIndex(this.lblBlood, 0);
            this.Controls.SetChildIndex(this.lblXRay, 0);
            this.Controls.SetChildIndex(this.lblBacilliBlood, 0);
            this.Controls.SetChildIndex(this.lblOther, 0);
            this.Controls.SetChildIndex(this.lblClinicDiagonse, 0);
            this.Controls.SetChildIndex(this.lblExplain_1, 0);
            this.Controls.SetChildIndex(this.m_txtApplyCheckIntent, 0);
            this.Controls.SetChildIndex(this.m_txtAssay, 0);
            this.Controls.SetChildIndex(this.m_txtBlood, 0);
            this.Controls.SetChildIndex(this.m_txtXRay, 0);
            this.Controls.SetChildIndex(this.m_txtBacilliBlood, 0);
            this.Controls.SetChildIndex(this.m_txtOther, 0);
            this.Controls.SetChildIndex(this.m_txtClinicDiagonse, 0);
            this.Controls.SetChildIndex(this.lblDoc, 0);
            this.Controls.SetChildIndex(this.m_txtDoc, 0);
            this.Controls.SetChildIndex(this.lblExplain_2, 0);
            this.Controls.SetChildIndex(this.lblCheckDate, 0);
            this.Controls.SetChildIndex(this.m_txtCheckDate, 0);
            this.Controls.SetChildIndex(this.m_txtYear, 0);
            this.Controls.SetChildIndex(this.m_txtMonth, 0);
            this.Controls.SetChildIndex(this.m_txtDay, 0);
            this.Controls.SetChildIndex(this.m_txtReceriveDate, 0);
            this.Controls.SetChildIndex(this.lblYear, 0);
            this.Controls.SetChildIndex(this.lblMonth, 0);
            this.Controls.SetChildIndex(this.lblDay, 0);
            this.Controls.SetChildIndex(this.lblReceiveDate, 0);
            this.Controls.SetChildIndex(this.m_txtAmorPm, 0);
            this.Controls.SetChildIndex(this.lblAmorPm, 0);
            this.Controls.SetChildIndex(this.lblClassify, 0);
            this.Controls.SetChildIndex(this.m_txtClassify, 0);
            this.Controls.SetChildIndex(this.lblClinicNum, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.ctlBorderTextBox2, 0);
            this.Controls.SetChildIndex(this.m_txtClinicNum, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmPathologyTissueCheckOrder_Load(object sender, System.EventArgs e)
		{
			m_txtClassify.Focus();
		}
	}
}

