using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace iCare
{
	public class frmBUltrasonicCheckReport : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.Label lblLiver;
		private System.Windows.Forms.Label lblLiverRight;
		private System.Windows.Forms.Label lblLeftLiver;
		private System.Windows.Forms.Label labLiverFace;
		private System.Windows.Forms.Label lblLiverIn;
		private System.Windows.Forms.Label lblDoorLiver;
		private System.Windows.Forms.TextBox txtRightSize;
		private System.Windows.Forms.Label lblLiverCM;
		private System.Windows.Forms.Label lblDoorLiverCM;
		private System.Windows.Forms.TextBox txtDoorLiver;
		private System.Windows.Forms.Label lblLiverStr;
		private System.Windows.Forms.CheckBox chkLiverStr1;
		private System.Windows.Forms.CheckBox chkLiverStr2;
		private System.Windows.Forms.CheckBox chkLiverFace1;
		private System.Windows.Forms.CheckBox chkLiverFace2;
		private System.Windows.Forms.CheckBox chkLiverFace3;
		private System.Windows.Forms.CheckBox chkLiverIn1;
		private System.Windows.Forms.CheckBox chkLiverIn2;
		private System.Windows.Forms.CheckBox chkLiverIn3;
		private System.Windows.Forms.CheckBox chkLiverIn4;
		private System.Windows.Forms.CheckBox chkLiverIn5;
		private System.Windows.Forms.Label lblBackLiverCM;
		private System.Windows.Forms.TextBox txtBackLiver;
		private System.Windows.Forms.Label lblBackLiver;
		private System.Windows.Forms.Label lblLeftSizeCM;
		private System.Windows.Forms.TextBox txtLeftSize;
		private System.Windows.Forms.Label lblLeftSize;
		private System.Windows.Forms.Label labLeftCM;
		private System.Windows.Forms.TextBox txtLeftLiver;
		private System.Windows.Forms.Label lblRightCM;
		private System.Windows.Forms.TextBox txtRigthSize;
		private System.Windows.Forms.Label lblRight;
		private System.Windows.Forms.Label lblCholecyst;
		private System.Windows.Forms.Label lblCholecystCM;
		private System.Windows.Forms.TextBox txtCholecyst;
		private System.Windows.Forms.Label lblCholecystSize;
		private System.Windows.Forms.Label lblCholecystCliff;
		private System.Windows.Forms.CheckBox chkCholecystCliff1;
		private System.Windows.Forms.CheckBox chkCholecystCliff2;
		private System.Windows.Forms.Label lblCholecystCliffCM;
		private System.Windows.Forms.TextBox txtDeepCholecystCliff;
		private System.Windows.Forms.Label lblDeepCholecystCliff;
		private System.Windows.Forms.Label lblSpleenSize1;
		private System.Windows.Forms.Label lbllSpleenSizeCM;
		private System.Windows.Forms.TextBox txtlSpleenSize1;
		private System.Windows.Forms.Label lblSpleenSize;
		private System.Windows.Forms.Label lblspleen;
		private System.Windows.Forms.Label lSpleenSize2CM;
		private System.Windows.Forms.TextBox txtSpleenSize2;
		private System.Windows.Forms.Label lbllSpleenSize2;
		private System.Windows.Forms.Label lbllSpleenReturn;
		private System.Windows.Forms.CheckBox chklSpleenReturn1;
		private System.Windows.Forms.CheckBox lSpleenReturn2;
		private System.Windows.Forms.CheckBox chkSpleenStr1;
		private System.Windows.Forms.Label lblSpleenStrCM;
		private System.Windows.Forms.TextBox txtSpleenStrSize;
		private System.Windows.Forms.Label lblSpleenStrSize;
		private System.Windows.Forms.Label lblSpleenStr;
		private System.Windows.Forms.Label lblPancreas;
		private System.Windows.Forms.CheckBox chkPancreas1;
		private System.Windows.Forms.CheckBox chkPancreas2;
		private System.Windows.Forms.CheckBox chkPancreas3;
		private System.Windows.Forms.CheckBox chkPancreas4;
		private System.Windows.Forms.Label lblPancreasCM;
		private System.Windows.Forms.TextBox txtPancreasHead;
		private System.Windows.Forms.Label lblPancreasHead;
		private System.Windows.Forms.Label lblPancreasbodyCM;
		private System.Windows.Forms.TextBox txtPancreasbody;
		private System.Windows.Forms.Label lblPancreasbody;
		private System.Windows.Forms.Label lbllPancreasEndCM;
		private System.Windows.Forms.TextBox txtlPancreasEnd;
		private System.Windows.Forms.Label lblPancreasEnd;
		private System.Windows.Forms.CheckBox chkPancreasHead1;
		private System.Windows.Forms.CheckBox chkPancreasBody1;
		private System.Windows.Forms.CheckBox chklPancreasEnd1;
		private System.Windows.Forms.Label lblPancreasInteCM;
		private System.Windows.Forms.TextBox txtPancreasInter;
		private System.Windows.Forms.Label lbllPancreasInter;
		private System.Windows.Forms.CheckBox chkPancreasInter1;
		private System.Windows.Forms.CheckBox chkPancreasInter2;
		private System.Windows.Forms.Label lblGauffer;
		private System.Windows.Forms.Label lblCholecystInter;
		private System.Windows.Forms.Label lblCholecystInterCM;
		private System.Windows.Forms.TextBox txtCholecystInter;
		private System.Windows.Forms.CheckBox chkCholecystInter1;
		private System.Windows.Forms.CheckBox chkCholecystInter2;
		private System.Windows.Forms.Label lblCholecystInter1;
		private System.Windows.Forms.Label lblstone;
		private System.Windows.Forms.CheckBox chklblCholecystInterLeft1;
		private System.Windows.Forms.CheckBox chklblCholecystInterLeft2;
		private System.Windows.Forms.Label lblCholecystInterLeft;
		private System.Windows.Forms.Label lblInterCM;
		private System.Windows.Forms.TextBox txtInter;
		private System.Windows.Forms.Label lblInter;
		private System.Windows.Forms.CheckBox chkstone1;
		private System.Windows.Forms.CheckBox chkstone2;
		private System.Windows.Forms.CheckBox chkstone3;
		private System.Windows.Forms.Label lblKidney;
		private System.Windows.Forms.Label lblKidneySizeCM;
		private System.Windows.Forms.TextBox txtKidneySize;
		private System.Windows.Forms.Label lblKidneySize;
		private System.Windows.Forms.CheckBox chkKidneySize1;
		private System.Windows.Forms.CheckBox chkKidneySize2;
		private System.Windows.Forms.CheckBox chkKidneySize3;
		private System.Windows.Forms.CheckBox chkKidneySize4;
		private System.Windows.Forms.CheckBox chkKidneySize5;
		private System.Windows.Forms.Label lblRightKidneySizeCM;
		private System.Windows.Forms.TextBox txtRightKidneySize;
		private System.Windows.Forms.Label lblRightKidneySize;
		private System.Windows.Forms.CheckBox chkRightKidneySize1;
		private System.Windows.Forms.CheckBox chkRightKidneySize2;
		private System.Windows.Forms.CheckBox chkRightKidneySize3;
		private System.Windows.Forms.CheckBox chkRightKidneySize4;
		private System.Windows.Forms.CheckBox chkRightKidneySize5;
		private System.Windows.Forms.Label lblBladder;
		private System.Windows.Forms.CheckBox chkBladder1;
		private System.Windows.Forms.CheckBox chkBladder2;
		private System.Windows.Forms.CheckBox chkBladder3;
		private System.Windows.Forms.Label lblProstate;
		private System.Windows.Forms.CheckBox chkProstate1;
		private System.Windows.Forms.Label lblProstateIncrCM;
		private System.Windows.Forms.TextBox txtProstateIncr;
		private System.Windows.Forms.Label lblProstateIncr;
		private System.Windows.Forms.CheckBox chkProstate2;
		private System.Windows.Forms.CheckBox chkProstate3;
		private System.Windows.Forms.CheckBox chkProstate4;
		private System.Windows.Forms.Label lblgland;
		private System.Windows.Forms.Label lblGlangCM;
		private System.Windows.Forms.TextBox txtGland;
		private System.Windows.Forms.Label lblGlandLeft;
		private System.Windows.Forms.Label lblGlandCM;
		private System.Windows.Forms.TextBox txtGlandSize;
		private System.Windows.Forms.Label lblGlandSize;
		private System.Windows.Forms.Label lblRightGlandCM;
		private System.Windows.Forms.TextBox txtRightGland;
		private System.Windows.Forms.Label lblRightGland;
		private System.Windows.Forms.Label lblRightGlandSizeCM;
		private System.Windows.Forms.TextBox txtRightGlandSize;
		private System.Windows.Forms.Label lblRightGlandSize;
		private System.Windows.Forms.Label lblBackGlandCM;
		private System.Windows.Forms.TextBox txtBackGland;
		private System.Windows.Forms.Label lblBackGland;
		private System.Windows.Forms.Label lblSpermary;
		private System.Windows.Forms.Label lblFSpermary;
		private System.Windows.Forms.Label lblLeftSpermaryCM;
		private System.Windows.Forms.TextBox txtLeftSpermary;
		private System.Windows.Forms.Label lblLeftSpermary;
		private System.Windows.Forms.Label lblSpermaryRightCM;
		private System.Windows.Forms.TextBox txtRigthSpermary;
		private System.Windows.Forms.Label lblRightSpermary;
		private System.Windows.Forms.Label lbllLeftFSpermaryCM;
		private System.Windows.Forms.TextBox txtlLeftFSpermary;
		private System.Windows.Forms.Label lblLeftFSpermary;
		private System.Windows.Forms.Label label78;
		private System.Windows.Forms.TextBox txtRightFSpermary;
		private System.Windows.Forms.Label lblRightFSpermary;
		private System.Windows.Forms.Label lblSpecialRecord;
		private System.Windows.Forms.TextBox txtBClinic;
		private System.Windows.Forms.TextBox txtSpecialRecord;
		private System.Windows.Forms.Label lblBClinic;
		private System.ComponentModel.IContainer components = null;

		public frmBUltrasonicCheckReport()
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
            this.lblLiver = new System.Windows.Forms.Label();
            this.lblLiverRight = new System.Windows.Forms.Label();
            this.lblLeftLiver = new System.Windows.Forms.Label();
            this.labLiverFace = new System.Windows.Forms.Label();
            this.lblLiverIn = new System.Windows.Forms.Label();
            this.lblDoorLiver = new System.Windows.Forms.Label();
            this.txtRightSize = new System.Windows.Forms.TextBox();
            this.lblLiverCM = new System.Windows.Forms.Label();
            this.lblSpleenSize1 = new System.Windows.Forms.Label();
            this.lbllSpleenSizeCM = new System.Windows.Forms.Label();
            this.txtlSpleenSize1 = new System.Windows.Forms.TextBox();
            this.lblDoorLiverCM = new System.Windows.Forms.Label();
            this.txtDoorLiver = new System.Windows.Forms.TextBox();
            this.lblLiverStr = new System.Windows.Forms.Label();
            this.chkLiverStr1 = new System.Windows.Forms.CheckBox();
            this.chkLiverStr2 = new System.Windows.Forms.CheckBox();
            this.chkLiverFace1 = new System.Windows.Forms.CheckBox();
            this.chkLiverFace2 = new System.Windows.Forms.CheckBox();
            this.chkLiverFace3 = new System.Windows.Forms.CheckBox();
            this.chkLiverIn1 = new System.Windows.Forms.CheckBox();
            this.chkLiverIn2 = new System.Windows.Forms.CheckBox();
            this.chkLiverIn3 = new System.Windows.Forms.CheckBox();
            this.chkLiverIn4 = new System.Windows.Forms.CheckBox();
            this.chkLiverIn5 = new System.Windows.Forms.CheckBox();
            this.lblBackLiverCM = new System.Windows.Forms.Label();
            this.txtBackLiver = new System.Windows.Forms.TextBox();
            this.lblBackLiver = new System.Windows.Forms.Label();
            this.lblLeftSizeCM = new System.Windows.Forms.Label();
            this.txtLeftSize = new System.Windows.Forms.TextBox();
            this.lblLeftSize = new System.Windows.Forms.Label();
            this.labLeftCM = new System.Windows.Forms.Label();
            this.txtLeftLiver = new System.Windows.Forms.TextBox();
            this.lblSpleenSize = new System.Windows.Forms.Label();
            this.lblspleen = new System.Windows.Forms.Label();
            this.lblRightCM = new System.Windows.Forms.Label();
            this.txtRigthSize = new System.Windows.Forms.TextBox();
            this.lblRight = new System.Windows.Forms.Label();
            this.lSpleenSize2CM = new System.Windows.Forms.Label();
            this.txtSpleenSize2 = new System.Windows.Forms.TextBox();
            this.lbllSpleenSize2 = new System.Windows.Forms.Label();
            this.lbllSpleenReturn = new System.Windows.Forms.Label();
            this.chklSpleenReturn1 = new System.Windows.Forms.CheckBox();
            this.lSpleenReturn2 = new System.Windows.Forms.CheckBox();
            this.chkSpleenStr1 = new System.Windows.Forms.CheckBox();
            this.lblSpleenStrCM = new System.Windows.Forms.Label();
            this.txtSpleenStrSize = new System.Windows.Forms.TextBox();
            this.lblSpleenStrSize = new System.Windows.Forms.Label();
            this.lblSpleenStr = new System.Windows.Forms.Label();
            this.lblPancreas = new System.Windows.Forms.Label();
            this.chkPancreas1 = new System.Windows.Forms.CheckBox();
            this.chkPancreas2 = new System.Windows.Forms.CheckBox();
            this.chkPancreas3 = new System.Windows.Forms.CheckBox();
            this.chkPancreas4 = new System.Windows.Forms.CheckBox();
            this.lblPancreasCM = new System.Windows.Forms.Label();
            this.txtPancreasHead = new System.Windows.Forms.TextBox();
            this.lblPancreasHead = new System.Windows.Forms.Label();
            this.lblPancreasbodyCM = new System.Windows.Forms.Label();
            this.txtPancreasbody = new System.Windows.Forms.TextBox();
            this.lblPancreasbody = new System.Windows.Forms.Label();
            this.lbllPancreasEndCM = new System.Windows.Forms.Label();
            this.txtlPancreasEnd = new System.Windows.Forms.TextBox();
            this.lblPancreasEnd = new System.Windows.Forms.Label();
            this.chkPancreasHead1 = new System.Windows.Forms.CheckBox();
            this.chkPancreasBody1 = new System.Windows.Forms.CheckBox();
            this.chklPancreasEnd1 = new System.Windows.Forms.CheckBox();
            this.lblPancreasInteCM = new System.Windows.Forms.Label();
            this.txtPancreasInter = new System.Windows.Forms.TextBox();
            this.lbllPancreasInter = new System.Windows.Forms.Label();
            this.chkPancreasInter1 = new System.Windows.Forms.CheckBox();
            this.chkPancreasInter2 = new System.Windows.Forms.CheckBox();
            this.lblCholecyst = new System.Windows.Forms.Label();
            this.lblCholecystCM = new System.Windows.Forms.Label();
            this.txtCholecyst = new System.Windows.Forms.TextBox();
            this.lblCholecystSize = new System.Windows.Forms.Label();
            this.lblCholecystCliff = new System.Windows.Forms.Label();
            this.chkCholecystCliff1 = new System.Windows.Forms.CheckBox();
            this.chkCholecystCliff2 = new System.Windows.Forms.CheckBox();
            this.lblCholecystCliffCM = new System.Windows.Forms.Label();
            this.txtDeepCholecystCliff = new System.Windows.Forms.TextBox();
            this.lblDeepCholecystCliff = new System.Windows.Forms.Label();
            this.lblGauffer = new System.Windows.Forms.Label();
            this.lblCholecystInter = new System.Windows.Forms.Label();
            this.lblCholecystInterCM = new System.Windows.Forms.Label();
            this.txtCholecystInter = new System.Windows.Forms.TextBox();
            this.chkCholecystInter1 = new System.Windows.Forms.CheckBox();
            this.chkCholecystInter2 = new System.Windows.Forms.CheckBox();
            this.lblCholecystInter1 = new System.Windows.Forms.Label();
            this.lblstone = new System.Windows.Forms.Label();
            this.chklblCholecystInterLeft1 = new System.Windows.Forms.CheckBox();
            this.chklblCholecystInterLeft2 = new System.Windows.Forms.CheckBox();
            this.lblCholecystInterLeft = new System.Windows.Forms.Label();
            this.lblInterCM = new System.Windows.Forms.Label();
            this.txtInter = new System.Windows.Forms.TextBox();
            this.lblInter = new System.Windows.Forms.Label();
            this.chkstone1 = new System.Windows.Forms.CheckBox();
            this.chkstone2 = new System.Windows.Forms.CheckBox();
            this.chkstone3 = new System.Windows.Forms.CheckBox();
            this.lblKidney = new System.Windows.Forms.Label();
            this.lblKidneySizeCM = new System.Windows.Forms.Label();
            this.txtKidneySize = new System.Windows.Forms.TextBox();
            this.lblKidneySize = new System.Windows.Forms.Label();
            this.chkKidneySize1 = new System.Windows.Forms.CheckBox();
            this.chkKidneySize2 = new System.Windows.Forms.CheckBox();
            this.chkKidneySize3 = new System.Windows.Forms.CheckBox();
            this.chkKidneySize4 = new System.Windows.Forms.CheckBox();
            this.chkKidneySize5 = new System.Windows.Forms.CheckBox();
            this.lblRightKidneySizeCM = new System.Windows.Forms.Label();
            this.txtRightKidneySize = new System.Windows.Forms.TextBox();
            this.lblRightKidneySize = new System.Windows.Forms.Label();
            this.chkRightKidneySize1 = new System.Windows.Forms.CheckBox();
            this.chkRightKidneySize2 = new System.Windows.Forms.CheckBox();
            this.chkRightKidneySize3 = new System.Windows.Forms.CheckBox();
            this.chkRightKidneySize4 = new System.Windows.Forms.CheckBox();
            this.chkRightKidneySize5 = new System.Windows.Forms.CheckBox();
            this.lblBladder = new System.Windows.Forms.Label();
            this.chkBladder1 = new System.Windows.Forms.CheckBox();
            this.chkBladder2 = new System.Windows.Forms.CheckBox();
            this.chkBladder3 = new System.Windows.Forms.CheckBox();
            this.lblProstate = new System.Windows.Forms.Label();
            this.chkProstate1 = new System.Windows.Forms.CheckBox();
            this.lblProstateIncrCM = new System.Windows.Forms.Label();
            this.txtProstateIncr = new System.Windows.Forms.TextBox();
            this.lblProstateIncr = new System.Windows.Forms.Label();
            this.chkProstate2 = new System.Windows.Forms.CheckBox();
            this.chkProstate3 = new System.Windows.Forms.CheckBox();
            this.chkProstate4 = new System.Windows.Forms.CheckBox();
            this.lblgland = new System.Windows.Forms.Label();
            this.lblGlangCM = new System.Windows.Forms.Label();
            this.txtGland = new System.Windows.Forms.TextBox();
            this.lblGlandLeft = new System.Windows.Forms.Label();
            this.lblGlandCM = new System.Windows.Forms.Label();
            this.txtGlandSize = new System.Windows.Forms.TextBox();
            this.lblGlandSize = new System.Windows.Forms.Label();
            this.lblRightGlandCM = new System.Windows.Forms.Label();
            this.txtRightGland = new System.Windows.Forms.TextBox();
            this.lblRightGland = new System.Windows.Forms.Label();
            this.lblRightGlandSizeCM = new System.Windows.Forms.Label();
            this.txtRightGlandSize = new System.Windows.Forms.TextBox();
            this.lblRightGlandSize = new System.Windows.Forms.Label();
            this.lblBackGlandCM = new System.Windows.Forms.Label();
            this.txtBackGland = new System.Windows.Forms.TextBox();
            this.lblBackGland = new System.Windows.Forms.Label();
            this.lblSpermary = new System.Windows.Forms.Label();
            this.lblFSpermary = new System.Windows.Forms.Label();
            this.lblLeftSpermaryCM = new System.Windows.Forms.Label();
            this.txtLeftSpermary = new System.Windows.Forms.TextBox();
            this.lblLeftSpermary = new System.Windows.Forms.Label();
            this.lblSpermaryRightCM = new System.Windows.Forms.Label();
            this.txtRigthSpermary = new System.Windows.Forms.TextBox();
            this.lblRightSpermary = new System.Windows.Forms.Label();
            this.lbllLeftFSpermaryCM = new System.Windows.Forms.Label();
            this.txtlLeftFSpermary = new System.Windows.Forms.TextBox();
            this.lblLeftFSpermary = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.txtRightFSpermary = new System.Windows.Forms.TextBox();
            this.lblRightFSpermary = new System.Windows.Forms.Label();
            this.lblSpecialRecord = new System.Windows.Forms.Label();
            this.txtBClinic = new System.Windows.Forms.TextBox();
            this.txtSpecialRecord = new System.Windows.Forms.TextBox();
            this.lblBClinic = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblAge
            // 
            this.lblAge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(836, 104);
            // 
            // lblDept
            // 
            this.lblDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(792, 40);
            // 
            // lblLiver
            // 
            this.lblLiver.AutoSize = true;
            this.lblLiver.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLiver.Location = new System.Drawing.Point(24, 216);
            this.lblLiver.Name = "lblLiver";
            this.lblLiver.Size = new System.Drawing.Size(47, 19);
            this.lblLiver.TabIndex = 501;
            this.lblLiver.Text = "肝脏";
            // 
            // lblLiverRight
            // 
            this.lblLiverRight.Location = new System.Drawing.Point(96, 208);
            this.lblLiverRight.Name = "lblLiverRight";
            this.lblLiverRight.Size = new System.Drawing.Size(64, 16);
            this.lblLiverRight.TabIndex = 502;
            this.lblLiverRight.Text = "右叶斜径";
            // 
            // lblLeftLiver
            // 
            this.lblLeftLiver.Location = new System.Drawing.Point(96, 240);
            this.lblLeftLiver.Name = "lblLeftLiver";
            this.lblLeftLiver.Size = new System.Drawing.Size(64, 16);
            this.lblLeftLiver.TabIndex = 503;
            this.lblLeftLiver.Text = "左叶厚径";
            // 
            // labLiverFace
            // 
            this.labLiverFace.Location = new System.Drawing.Point(96, 272);
            this.labLiverFace.Name = "labLiverFace";
            this.labLiverFace.Size = new System.Drawing.Size(48, 16);
            this.labLiverFace.TabIndex = 504;
            this.labLiverFace.Text = "肝表面";
            // 
            // lblLiverIn
            // 
            this.lblLiverIn.Location = new System.Drawing.Point(96, 296);
            this.lblLiverIn.Name = "lblLiverIn";
            this.lblLiverIn.Size = new System.Drawing.Size(64, 16);
            this.lblLiverIn.TabIndex = 505;
            this.lblLiverIn.Text = "肝内光点";
            // 
            // lblDoorLiver
            // 
            this.lblDoorLiver.Location = new System.Drawing.Point(96, 384);
            this.lblDoorLiver.Name = "lblDoorLiver";
            this.lblDoorLiver.Size = new System.Drawing.Size(96, 16);
            this.lblDoorLiver.TabIndex = 506;
            this.lblDoorLiver.Text = "门脉主干内径";
            // 
            // txtRightSize
            // 
            this.txtRightSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRightSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightSize.Location = new System.Drawing.Point(192, 200);
            this.txtRightSize.Name = "txtRightSize";
            this.txtRightSize.Size = new System.Drawing.Size(56, 23);
            this.txtRightSize.TabIndex = 507;
            // 
            // lblLiverCM
            // 
            this.lblLiverCM.Location = new System.Drawing.Point(248, 208);
            this.lblLiverCM.Name = "lblLiverCM";
            this.lblLiverCM.Size = new System.Drawing.Size(56, 24);
            this.lblLiverCM.TabIndex = 508;
            this.lblLiverCM.Text = "Cm,";
            // 
            // lblSpleenSize1
            // 
            this.lblSpleenSize1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpleenSize1.Location = new System.Drawing.Point(720, 200);
            this.lblSpleenSize1.Name = "lblSpleenSize1";
            this.lblSpleenSize1.Size = new System.Drawing.Size(56, 16);
            this.lblSpleenSize1.TabIndex = 509;
            this.lblSpleenSize1.Text = "厚";
            // 
            // lbllSpleenSizeCM
            // 
            this.lbllSpleenSizeCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lbllSpleenSizeCM.Location = new System.Drawing.Point(800, 192);
            this.lbllSpleenSizeCM.Name = "lbllSpleenSizeCM";
            this.lbllSpleenSizeCM.Size = new System.Drawing.Size(24, 24);
            this.lbllSpleenSizeCM.TabIndex = 511;
            this.lbllSpleenSizeCM.Text = "Cm";
            // 
            // txtlSpleenSize1
            // 
            this.txtlSpleenSize1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtlSpleenSize1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlSpleenSize1.Location = new System.Drawing.Point(744, 192);
            this.txtlSpleenSize1.Name = "txtlSpleenSize1";
            this.txtlSpleenSize1.Size = new System.Drawing.Size(48, 23);
            this.txtlSpleenSize1.TabIndex = 510;
            // 
            // lblDoorLiverCM
            // 
            this.lblDoorLiverCM.Location = new System.Drawing.Point(280, 392);
            this.lblDoorLiverCM.Name = "lblDoorLiverCM";
            this.lblDoorLiverCM.Size = new System.Drawing.Size(56, 24);
            this.lblDoorLiverCM.TabIndex = 513;
            this.lblDoorLiverCM.Text = "Cm";
            // 
            // txtDoorLiver
            // 
            this.txtDoorLiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtDoorLiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDoorLiver.Location = new System.Drawing.Point(216, 384);
            this.txtDoorLiver.Name = "txtDoorLiver";
            this.txtDoorLiver.Size = new System.Drawing.Size(56, 23);
            this.txtDoorLiver.TabIndex = 512;
            // 
            // lblLiverStr
            // 
            this.lblLiverStr.Location = new System.Drawing.Point(96, 416);
            this.lblLiverStr.Name = "lblLiverStr";
            this.lblLiverStr.Size = new System.Drawing.Size(64, 16);
            this.lblLiverStr.TabIndex = 514;
            this.lblLiverStr.Text = "肝内静脉";
            // 
            // chkLiverStr1
            // 
            this.chkLiverStr1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverStr1.Location = new System.Drawing.Point(200, 416);
            this.chkLiverStr1.Name = "chkLiverStr1";
            this.chkLiverStr1.Size = new System.Drawing.Size(96, 24);
            this.chkLiverStr1.TabIndex = 515;
            this.chkLiverStr1.Text = "清晰";
            // 
            // chkLiverStr2
            // 
            this.chkLiverStr2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverStr2.Location = new System.Drawing.Point(264, 416);
            this.chkLiverStr2.Name = "chkLiverStr2";
            this.chkLiverStr2.Size = new System.Drawing.Size(144, 24);
            this.chkLiverStr2.TabIndex = 516;
            this.chkLiverStr2.Text = "变细弯曲显示不清";
            // 
            // chkLiverFace1
            // 
            this.chkLiverFace1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkLiverFace1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverFace1.Location = new System.Drawing.Point(192, 264);
            this.chkLiverFace1.Name = "chkLiverFace1";
            this.chkLiverFace1.Size = new System.Drawing.Size(96, 24);
            this.chkLiverFace1.TabIndex = 518;
            this.chkLiverFace1.Text = "平滑";
            this.chkLiverFace1.UseVisualStyleBackColor = false;
            // 
            // chkLiverFace2
            // 
            this.chkLiverFace2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverFace2.Location = new System.Drawing.Point(288, 264);
            this.chkLiverFace2.Name = "chkLiverFace2";
            this.chkLiverFace2.Size = new System.Drawing.Size(96, 24);
            this.chkLiverFace2.TabIndex = 519;
            this.chkLiverFace2.Text = "粗糙";
            // 
            // chkLiverFace3
            // 
            this.chkLiverFace3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverFace3.Location = new System.Drawing.Point(384, 264);
            this.chkLiverFace3.Name = "chkLiverFace3";
            this.chkLiverFace3.Size = new System.Drawing.Size(96, 24);
            this.chkLiverFace3.TabIndex = 520;
            this.chkLiverFace3.Text = "凹凸不平";
            // 
            // chkLiverIn1
            // 
            this.chkLiverIn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkLiverIn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverIn1.Location = new System.Drawing.Point(192, 288);
            this.chkLiverIn1.Name = "chkLiverIn1";
            this.chkLiverIn1.Size = new System.Drawing.Size(96, 24);
            this.chkLiverIn1.TabIndex = 521;
            this.chkLiverIn1.Text = "分布均匀";
            this.chkLiverIn1.UseVisualStyleBackColor = false;
            // 
            // chkLiverIn2
            // 
            this.chkLiverIn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverIn2.Location = new System.Drawing.Point(288, 288);
            this.chkLiverIn2.Name = "chkLiverIn2";
            this.chkLiverIn2.Size = new System.Drawing.Size(96, 24);
            this.chkLiverIn2.TabIndex = 522;
            this.chkLiverIn2.Text = "细密";
            // 
            // chkLiverIn3
            // 
            this.chkLiverIn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverIn3.Location = new System.Drawing.Point(384, 288);
            this.chkLiverIn3.Name = "chkLiverIn3";
            this.chkLiverIn3.Size = new System.Drawing.Size(96, 24);
            this.chkLiverIn3.TabIndex = 523;
            this.chkLiverIn3.Text = "不均匀";
            // 
            // chkLiverIn4
            // 
            this.chkLiverIn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkLiverIn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverIn4.Location = new System.Drawing.Point(192, 312);
            this.chkLiverIn4.Name = "chkLiverIn4";
            this.chkLiverIn4.Size = new System.Drawing.Size(136, 24);
            this.chkLiverIn4.TabIndex = 524;
            this.chkLiverIn4.Text = "部分稍增强粗糙";
            this.chkLiverIn4.UseVisualStyleBackColor = false;
            // 
            // chkLiverIn5
            // 
            this.chkLiverIn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkLiverIn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLiverIn5.Location = new System.Drawing.Point(192, 336);
            this.chkLiverIn5.Name = "chkLiverIn5";
            this.chkLiverIn5.Size = new System.Drawing.Size(96, 24);
            this.chkLiverIn5.TabIndex = 525;
            this.chkLiverIn5.Text = "增强粗糙";
            this.chkLiverIn5.UseVisualStyleBackColor = false;
            // 
            // lblBackLiverCM
            // 
            this.lblBackLiverCM.Location = new System.Drawing.Point(280, 360);
            this.lblBackLiverCM.Name = "lblBackLiverCM";
            this.lblBackLiverCM.Size = new System.Drawing.Size(56, 24);
            this.lblBackLiverCM.TabIndex = 528;
            this.lblBackLiverCM.Text = "Cm";
            // 
            // txtBackLiver
            // 
            this.txtBackLiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtBackLiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackLiver.Location = new System.Drawing.Point(216, 360);
            this.txtBackLiver.Name = "txtBackLiver";
            this.txtBackLiver.Size = new System.Drawing.Size(56, 23);
            this.txtBackLiver.TabIndex = 527;
            // 
            // lblBackLiver
            // 
            this.lblBackLiver.Location = new System.Drawing.Point(96, 360);
            this.lblBackLiver.Name = "lblBackLiver";
            this.lblBackLiver.Size = new System.Drawing.Size(120, 16);
            this.lblBackLiver.TabIndex = 526;
            this.lblBackLiver.Text = "肝后部回声衰减";
            // 
            // lblLeftSizeCM
            // 
            this.lblLeftSizeCM.Location = new System.Drawing.Point(392, 232);
            this.lblLeftSizeCM.Name = "lblLeftSizeCM";
            this.lblLeftSizeCM.Size = new System.Drawing.Size(56, 24);
            this.lblLeftSizeCM.TabIndex = 533;
            this.lblLeftSizeCM.Text = "Cm";
            // 
            // txtLeftSize
            // 
            this.txtLeftSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtLeftSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeftSize.Location = new System.Drawing.Point(336, 232);
            this.txtLeftSize.Name = "txtLeftSize";
            this.txtLeftSize.Size = new System.Drawing.Size(56, 23);
            this.txtLeftSize.TabIndex = 532;
            // 
            // lblLeftSize
            // 
            this.lblLeftSize.Location = new System.Drawing.Point(272, 240);
            this.lblLeftSize.Name = "lblLeftSize";
            this.lblLeftSize.Size = new System.Drawing.Size(64, 16);
            this.lblLeftSize.TabIndex = 531;
            this.lblLeftSize.Text = "左叶长径";
            // 
            // labLeftCM
            // 
            this.labLeftCM.Location = new System.Drawing.Point(248, 240);
            this.labLeftCM.Name = "labLeftCM";
            this.labLeftCM.Size = new System.Drawing.Size(56, 24);
            this.labLeftCM.TabIndex = 530;
            this.labLeftCM.Text = "Cm,";
            // 
            // txtLeftLiver
            // 
            this.txtLeftLiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtLeftLiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeftLiver.Location = new System.Drawing.Point(192, 232);
            this.txtLeftLiver.Name = "txtLeftLiver";
            this.txtLeftLiver.Size = new System.Drawing.Size(56, 23);
            this.txtLeftLiver.TabIndex = 529;
            // 
            // lblSpleenSize
            // 
            this.lblSpleenSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpleenSize.Location = new System.Drawing.Point(640, 200);
            this.lblSpleenSize.Name = "lblSpleenSize";
            this.lblSpleenSize.Size = new System.Drawing.Size(64, 24);
            this.lblSpleenSize.TabIndex = 534;
            this.lblSpleenSize.Text = "正常大小";
            // 
            // lblspleen
            // 
            this.lblspleen.AutoSize = true;
            this.lblspleen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblspleen.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblspleen.Location = new System.Drawing.Point(560, 200);
            this.lblspleen.Name = "lblspleen";
            this.lblspleen.Size = new System.Drawing.Size(47, 19);
            this.lblspleen.TabIndex = 535;
            this.lblspleen.Text = "脾脏";
            // 
            // lblRightCM
            // 
            this.lblRightCM.Location = new System.Drawing.Point(392, 200);
            this.lblRightCM.Name = "lblRightCM";
            this.lblRightCM.Size = new System.Drawing.Size(48, 24);
            this.lblRightCM.TabIndex = 538;
            this.lblRightCM.Text = "Cm";
            // 
            // txtRigthSize
            // 
            this.txtRigthSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRigthSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRigthSize.Location = new System.Drawing.Point(336, 200);
            this.txtRigthSize.Name = "txtRigthSize";
            this.txtRigthSize.Size = new System.Drawing.Size(48, 23);
            this.txtRigthSize.TabIndex = 537;
            // 
            // lblRight
            // 
            this.lblRight.Location = new System.Drawing.Point(288, 208);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(56, 16);
            this.lblRight.TabIndex = 536;
            this.lblRight.Text = "右叶厚径";
            // 
            // lSpleenSize2CM
            // 
            this.lSpleenSize2CM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lSpleenSize2CM.Location = new System.Drawing.Point(920, 192);
            this.lSpleenSize2CM.Name = "lSpleenSize2CM";
            this.lSpleenSize2CM.Size = new System.Drawing.Size(24, 24);
            this.lSpleenSize2CM.TabIndex = 541;
            this.lSpleenSize2CM.Text = "Cm";
            // 
            // txtSpleenSize2
            // 
            this.txtSpleenSize2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtSpleenSize2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpleenSize2.Location = new System.Drawing.Point(872, 192);
            this.txtSpleenSize2.Name = "txtSpleenSize2";
            this.txtSpleenSize2.Size = new System.Drawing.Size(48, 23);
            this.txtSpleenSize2.TabIndex = 540;
            // 
            // lbllSpleenSize2
            // 
            this.lbllSpleenSize2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lbllSpleenSize2.Location = new System.Drawing.Point(840, 200);
            this.lbllSpleenSize2.Name = "lbllSpleenSize2";
            this.lbllSpleenSize2.Size = new System.Drawing.Size(24, 16);
            this.lbllSpleenSize2.TabIndex = 539;
            this.lbllSpleenSize2.Text = "长";
            // 
            // lbllSpleenReturn
            // 
            this.lbllSpleenReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lbllSpleenReturn.Location = new System.Drawing.Point(640, 232);
            this.lbllSpleenReturn.Name = "lbllSpleenReturn";
            this.lbllSpleenReturn.Size = new System.Drawing.Size(64, 16);
            this.lbllSpleenReturn.TabIndex = 542;
            this.lbllSpleenReturn.Text = "脾内回声";
            // 
            // chklSpleenReturn1
            // 
            this.chklSpleenReturn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chklSpleenReturn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chklSpleenReturn1.Location = new System.Drawing.Point(736, 224);
            this.chklSpleenReturn1.Name = "chklSpleenReturn1";
            this.chklSpleenReturn1.Size = new System.Drawing.Size(96, 24);
            this.chklSpleenReturn1.TabIndex = 543;
            this.chklSpleenReturn1.Text = "正常";
            this.chklSpleenReturn1.UseVisualStyleBackColor = false;
            // 
            // lSpleenReturn2
            // 
            this.lSpleenReturn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lSpleenReturn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lSpleenReturn2.Location = new System.Drawing.Point(848, 224);
            this.lSpleenReturn2.Name = "lSpleenReturn2";
            this.lSpleenReturn2.Size = new System.Drawing.Size(112, 24);
            this.lSpleenReturn2.TabIndex = 544;
            this.lSpleenReturn2.Text = "光点增强增粗";
            this.lSpleenReturn2.UseVisualStyleBackColor = false;
            // 
            // chkSpleenStr1
            // 
            this.chkSpleenStr1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkSpleenStr1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkSpleenStr1.Location = new System.Drawing.Point(736, 248);
            this.chkSpleenStr1.Name = "chkSpleenStr1";
            this.chkSpleenStr1.Size = new System.Drawing.Size(96, 24);
            this.chkSpleenStr1.TabIndex = 545;
            this.chkSpleenStr1.Text = "正常";
            this.chkSpleenStr1.UseVisualStyleBackColor = false;
            // 
            // lblSpleenStrCM
            // 
            this.lblSpleenStrCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpleenStrCM.Location = new System.Drawing.Point(944, 248);
            this.lblSpleenStrCM.Name = "lblSpleenStrCM";
            this.lblSpleenStrCM.Size = new System.Drawing.Size(48, 24);
            this.lblSpleenStrCM.TabIndex = 548;
            this.lblSpleenStrCM.Text = "Cm";
            // 
            // txtSpleenStrSize
            // 
            this.txtSpleenStrSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtSpleenStrSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpleenStrSize.Location = new System.Drawing.Point(896, 248);
            this.txtSpleenStrSize.Name = "txtSpleenStrSize";
            this.txtSpleenStrSize.Size = new System.Drawing.Size(48, 23);
            this.txtSpleenStrSize.TabIndex = 547;
            // 
            // lblSpleenStrSize
            // 
            this.lblSpleenStrSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpleenStrSize.Location = new System.Drawing.Point(848, 256);
            this.lblSpleenStrSize.Name = "lblSpleenStrSize";
            this.lblSpleenStrSize.Size = new System.Drawing.Size(40, 16);
            this.lblSpleenStrSize.TabIndex = 546;
            this.lblSpleenStrSize.Text = "增粗";
            // 
            // lblSpleenStr
            // 
            this.lblSpleenStr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpleenStr.Location = new System.Drawing.Point(640, 256);
            this.lblSpleenStr.Name = "lblSpleenStr";
            this.lblSpleenStr.Size = new System.Drawing.Size(80, 24);
            this.lblSpleenStr.TabIndex = 549;
            this.lblSpleenStr.Text = "脾静脉内径";
            // 
            // lblPancreas
            // 
            this.lblPancreas.AutoSize = true;
            this.lblPancreas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreas.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPancreas.Location = new System.Drawing.Point(560, 288);
            this.lblPancreas.Name = "lblPancreas";
            this.lblPancreas.Size = new System.Drawing.Size(47, 19);
            this.lblPancreas.TabIndex = 550;
            this.lblPancreas.Text = "胰腺";
            // 
            // chkPancreas1
            // 
            this.chkPancreas1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreas1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreas1.Location = new System.Drawing.Point(648, 288);
            this.chkPancreas1.Name = "chkPancreas1";
            this.chkPancreas1.Size = new System.Drawing.Size(96, 24);
            this.chkPancreas1.TabIndex = 551;
            this.chkPancreas1.Text = "正常大小";
            this.chkPancreas1.UseVisualStyleBackColor = false;
            // 
            // chkPancreas2
            // 
            this.chkPancreas2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreas2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreas2.Location = new System.Drawing.Point(736, 288);
            this.chkPancreas2.Name = "chkPancreas2";
            this.chkPancreas2.Size = new System.Drawing.Size(96, 24);
            this.chkPancreas2.TabIndex = 552;
            this.chkPancreas2.Text = "边缘不整";
            this.chkPancreas2.UseVisualStyleBackColor = false;
            // 
            // chkPancreas3
            // 
            this.chkPancreas3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreas3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreas3.Location = new System.Drawing.Point(824, 288);
            this.chkPancreas3.Name = "chkPancreas3";
            this.chkPancreas3.Size = new System.Drawing.Size(96, 24);
            this.chkPancreas3.TabIndex = 553;
            this.chkPancreas3.Text = "低回声";
            this.chkPancreas3.UseVisualStyleBackColor = false;
            // 
            // chkPancreas4
            // 
            this.chkPancreas4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreas4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreas4.Location = new System.Drawing.Point(904, 288);
            this.chkPancreas4.Name = "chkPancreas4";
            this.chkPancreas4.Size = new System.Drawing.Size(96, 24);
            this.chkPancreas4.TabIndex = 554;
            this.chkPancreas4.Text = "钙化点";
            this.chkPancreas4.UseVisualStyleBackColor = false;
            // 
            // lblPancreasCM
            // 
            this.lblPancreasCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreasCM.Location = new System.Drawing.Point(776, 320);
            this.lblPancreasCM.Name = "lblPancreasCM";
            this.lblPancreasCM.Size = new System.Drawing.Size(48, 24);
            this.lblPancreasCM.TabIndex = 557;
            this.lblPancreasCM.Text = "Cm";
            // 
            // txtPancreasHead
            // 
            this.txtPancreasHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtPancreasHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPancreasHead.Location = new System.Drawing.Point(728, 320);
            this.txtPancreasHead.Name = "txtPancreasHead";
            this.txtPancreasHead.Size = new System.Drawing.Size(48, 23);
            this.txtPancreasHead.TabIndex = 556;
            // 
            // lblPancreasHead
            // 
            this.lblPancreasHead.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreasHead.Location = new System.Drawing.Point(640, 328);
            this.lblPancreasHead.Name = "lblPancreasHead";
            this.lblPancreasHead.Size = new System.Drawing.Size(56, 16);
            this.lblPancreasHead.TabIndex = 555;
            this.lblPancreasHead.Text = "胰头";
            // 
            // lblPancreasbodyCM
            // 
            this.lblPancreasbodyCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreasbodyCM.Location = new System.Drawing.Point(776, 360);
            this.lblPancreasbodyCM.Name = "lblPancreasbodyCM";
            this.lblPancreasbodyCM.Size = new System.Drawing.Size(48, 24);
            this.lblPancreasbodyCM.TabIndex = 560;
            this.lblPancreasbodyCM.Text = "Cm";
            // 
            // txtPancreasbody
            // 
            this.txtPancreasbody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtPancreasbody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPancreasbody.Location = new System.Drawing.Point(728, 360);
            this.txtPancreasbody.Name = "txtPancreasbody";
            this.txtPancreasbody.Size = new System.Drawing.Size(48, 23);
            this.txtPancreasbody.TabIndex = 559;
            // 
            // lblPancreasbody
            // 
            this.lblPancreasbody.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreasbody.Location = new System.Drawing.Point(640, 368);
            this.lblPancreasbody.Name = "lblPancreasbody";
            this.lblPancreasbody.Size = new System.Drawing.Size(56, 16);
            this.lblPancreasbody.TabIndex = 558;
            this.lblPancreasbody.Text = "胰体";
            // 
            // lbllPancreasEndCM
            // 
            this.lbllPancreasEndCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lbllPancreasEndCM.Location = new System.Drawing.Point(776, 392);
            this.lbllPancreasEndCM.Name = "lbllPancreasEndCM";
            this.lbllPancreasEndCM.Size = new System.Drawing.Size(48, 24);
            this.lbllPancreasEndCM.TabIndex = 566;
            this.lbllPancreasEndCM.Text = "Cm";
            // 
            // txtlPancreasEnd
            // 
            this.txtlPancreasEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtlPancreasEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlPancreasEnd.Location = new System.Drawing.Point(728, 392);
            this.txtlPancreasEnd.Name = "txtlPancreasEnd";
            this.txtlPancreasEnd.Size = new System.Drawing.Size(48, 23);
            this.txtlPancreasEnd.TabIndex = 565;
            // 
            // lblPancreasEnd
            // 
            this.lblPancreasEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreasEnd.Location = new System.Drawing.Point(640, 400);
            this.lblPancreasEnd.Name = "lblPancreasEnd";
            this.lblPancreasEnd.Size = new System.Drawing.Size(56, 16);
            this.lblPancreasEnd.TabIndex = 564;
            this.lblPancreasEnd.Text = "胰尾";
            // 
            // chkPancreasHead1
            // 
            this.chkPancreasHead1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreasHead1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreasHead1.Location = new System.Drawing.Point(864, 320);
            this.chkPancreasHead1.Name = "chkPancreasHead1";
            this.chkPancreasHead1.Size = new System.Drawing.Size(96, 24);
            this.chkPancreasHead1.TabIndex = 567;
            this.chkPancreasHead1.Text = "钙化点";
            this.chkPancreasHead1.UseVisualStyleBackColor = false;
            // 
            // chkPancreasBody1
            // 
            this.chkPancreasBody1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreasBody1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreasBody1.Location = new System.Drawing.Point(864, 352);
            this.chkPancreasBody1.Name = "chkPancreasBody1";
            this.chkPancreasBody1.Size = new System.Drawing.Size(96, 24);
            this.chkPancreasBody1.TabIndex = 568;
            this.chkPancreasBody1.Text = "钙化点";
            this.chkPancreasBody1.UseVisualStyleBackColor = false;
            // 
            // chklPancreasEnd1
            // 
            this.chklPancreasEnd1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chklPancreasEnd1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chklPancreasEnd1.Location = new System.Drawing.Point(864, 384);
            this.chklPancreasEnd1.Name = "chklPancreasEnd1";
            this.chklPancreasEnd1.Size = new System.Drawing.Size(96, 24);
            this.chklPancreasEnd1.TabIndex = 569;
            this.chklPancreasEnd1.Text = "钙化点";
            this.chklPancreasEnd1.UseVisualStyleBackColor = false;
            // 
            // lblPancreasInteCM
            // 
            this.lblPancreasInteCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblPancreasInteCM.Location = new System.Drawing.Point(776, 424);
            this.lblPancreasInteCM.Name = "lblPancreasInteCM";
            this.lblPancreasInteCM.Size = new System.Drawing.Size(48, 24);
            this.lblPancreasInteCM.TabIndex = 572;
            this.lblPancreasInteCM.Text = "Cm";
            // 
            // txtPancreasInter
            // 
            this.txtPancreasInter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtPancreasInter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPancreasInter.Location = new System.Drawing.Point(728, 424);
            this.txtPancreasInter.Name = "txtPancreasInter";
            this.txtPancreasInter.Size = new System.Drawing.Size(48, 23);
            this.txtPancreasInter.TabIndex = 571;
            // 
            // lbllPancreasInter
            // 
            this.lbllPancreasInter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lbllPancreasInter.Location = new System.Drawing.Point(640, 432);
            this.lbllPancreasInter.Name = "lbllPancreasInter";
            this.lbllPancreasInter.Size = new System.Drawing.Size(72, 16);
            this.lbllPancreasInter.TabIndex = 570;
            this.lbllPancreasInter.Text = "胰管内径";
            // 
            // chkPancreasInter1
            // 
            this.chkPancreasInter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreasInter1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreasInter1.Location = new System.Drawing.Point(840, 424);
            this.chkPancreasInter1.Name = "chkPancreasInter1";
            this.chkPancreasInter1.Size = new System.Drawing.Size(96, 24);
            this.chkPancreasInter1.TabIndex = 573;
            this.chkPancreasInter1.Text = "未能显示";
            this.chkPancreasInter1.UseVisualStyleBackColor = false;
            // 
            // chkPancreasInter2
            // 
            this.chkPancreasInter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkPancreasInter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkPancreasInter2.Location = new System.Drawing.Point(928, 424);
            this.chkPancreasInter2.Name = "chkPancreasInter2";
            this.chkPancreasInter2.Size = new System.Drawing.Size(64, 24);
            this.chkPancreasInter2.TabIndex = 574;
            this.chkPancreasInter2.Text = "弯曲";
            this.chkPancreasInter2.UseVisualStyleBackColor = false;
            // 
            // lblCholecyst
            // 
            this.lblCholecyst.AutoSize = true;
            this.lblCholecyst.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCholecyst.Location = new System.Drawing.Point(24, 456);
            this.lblCholecyst.Name = "lblCholecyst";
            this.lblCholecyst.Size = new System.Drawing.Size(47, 19);
            this.lblCholecyst.TabIndex = 575;
            this.lblCholecyst.Text = "胆囊";
            // 
            // lblCholecystCM
            // 
            this.lblCholecystCM.Location = new System.Drawing.Point(208, 464);
            this.lblCholecystCM.Name = "lblCholecystCM";
            this.lblCholecystCM.Size = new System.Drawing.Size(24, 24);
            this.lblCholecystCM.TabIndex = 578;
            this.lblCholecystCM.Text = "Cm";
            // 
            // txtCholecyst
            // 
            this.txtCholecyst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtCholecyst.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCholecyst.Location = new System.Drawing.Point(144, 464);
            this.txtCholecyst.Name = "txtCholecyst";
            this.txtCholecyst.Size = new System.Drawing.Size(48, 23);
            this.txtCholecyst.TabIndex = 577;
            // 
            // lblCholecystSize
            // 
            this.lblCholecystSize.Location = new System.Drawing.Point(96, 472);
            this.lblCholecystSize.Name = "lblCholecystSize";
            this.lblCholecystSize.Size = new System.Drawing.Size(56, 16);
            this.lblCholecystSize.TabIndex = 576;
            this.lblCholecystSize.Text = "大小";
            // 
            // lblCholecystCliff
            // 
            this.lblCholecystCliff.Location = new System.Drawing.Point(96, 504);
            this.lblCholecystCliff.Name = "lblCholecystCliff";
            this.lblCholecystCliff.Size = new System.Drawing.Size(40, 16);
            this.lblCholecystCliff.TabIndex = 579;
            this.lblCholecystCliff.Text = "胆壁";
            // 
            // chkCholecystCliff1
            // 
            this.chkCholecystCliff1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCholecystCliff1.Location = new System.Drawing.Point(168, 496);
            this.chkCholecystCliff1.Name = "chkCholecystCliff1";
            this.chkCholecystCliff1.Size = new System.Drawing.Size(96, 24);
            this.chkCholecystCliff1.TabIndex = 580;
            this.chkCholecystCliff1.Text = "正常";
            // 
            // chkCholecystCliff2
            // 
            this.chkCholecystCliff2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCholecystCliff2.Location = new System.Drawing.Point(224, 496);
            this.chkCholecystCliff2.Name = "chkCholecystCliff2";
            this.chkCholecystCliff2.Size = new System.Drawing.Size(96, 24);
            this.chkCholecystCliff2.TabIndex = 581;
            this.chkCholecystCliff2.Text = "边缘模糊";
            // 
            // lblCholecystCliffCM
            // 
            this.lblCholecystCliffCM.Location = new System.Drawing.Point(400, 496);
            this.lblCholecystCliffCM.Name = "lblCholecystCliffCM";
            this.lblCholecystCliffCM.Size = new System.Drawing.Size(32, 16);
            this.lblCholecystCliffCM.TabIndex = 584;
            this.lblCholecystCliffCM.Text = "Cm";
            // 
            // txtDeepCholecystCliff
            // 
            this.txtDeepCholecystCliff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtDeepCholecystCliff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeepCholecystCliff.Location = new System.Drawing.Point(344, 496);
            this.txtDeepCholecystCliff.Name = "txtDeepCholecystCliff";
            this.txtDeepCholecystCliff.Size = new System.Drawing.Size(48, 23);
            this.txtDeepCholecystCliff.TabIndex = 583;
            // 
            // lblDeepCholecystCliff
            // 
            this.lblDeepCholecystCliff.Location = new System.Drawing.Point(320, 504);
            this.lblDeepCholecystCliff.Name = "lblDeepCholecystCliff";
            this.lblDeepCholecystCliff.Size = new System.Drawing.Size(24, 16);
            this.lblDeepCholecystCliff.TabIndex = 582;
            this.lblDeepCholecystCliff.Text = "厚";
            // 
            // lblGauffer
            // 
            this.lblGauffer.Location = new System.Drawing.Point(96, 528);
            this.lblGauffer.Name = "lblGauffer";
            this.lblGauffer.Size = new System.Drawing.Size(40, 16);
            this.lblGauffer.TabIndex = 585;
            this.lblGauffer.Text = "皱摺";
            // 
            // lblCholecystInter
            // 
            this.lblCholecystInter.Location = new System.Drawing.Point(96, 560);
            this.lblCholecystInter.Name = "lblCholecystInter";
            this.lblCholecystInter.Size = new System.Drawing.Size(96, 16);
            this.lblCholecystInter.TabIndex = 586;
            this.lblCholecystInter.Text = "胆总管内径";
            // 
            // lblCholecystInterCM
            // 
            this.lblCholecystInterCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblCholecystInterCM.Location = new System.Drawing.Point(224, 552);
            this.lblCholecystInterCM.Name = "lblCholecystInterCM";
            this.lblCholecystInterCM.Size = new System.Drawing.Size(56, 24);
            this.lblCholecystInterCM.TabIndex = 588;
            this.lblCholecystInterCM.Text = "Cm";
            // 
            // txtCholecystInter
            // 
            this.txtCholecystInter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtCholecystInter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCholecystInter.Location = new System.Drawing.Point(168, 552);
            this.txtCholecystInter.Name = "txtCholecystInter";
            this.txtCholecystInter.Size = new System.Drawing.Size(56, 23);
            this.txtCholecystInter.TabIndex = 587;
            // 
            // chkCholecystInter1
            // 
            this.chkCholecystInter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkCholecystInter1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCholecystInter1.Location = new System.Drawing.Point(296, 552);
            this.chkCholecystInter1.Name = "chkCholecystInter1";
            this.chkCholecystInter1.Size = new System.Drawing.Size(96, 24);
            this.chkCholecystInter1.TabIndex = 589;
            this.chkCholecystInter1.Text = "管壁正常";
            this.chkCholecystInter1.UseVisualStyleBackColor = false;
            // 
            // chkCholecystInter2
            // 
            this.chkCholecystInter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkCholecystInter2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCholecystInter2.Location = new System.Drawing.Point(392, 552);
            this.chkCholecystInter2.Name = "chkCholecystInter2";
            this.chkCholecystInter2.Size = new System.Drawing.Size(96, 24);
            this.chkCholecystInter2.TabIndex = 590;
            this.chkCholecystInter2.Text = "增强增厚";
            this.chkCholecystInter2.UseVisualStyleBackColor = false;
            // 
            // lblCholecystInter1
            // 
            this.lblCholecystInter1.Location = new System.Drawing.Point(96, 592);
            this.lblCholecystInter1.Name = "lblCholecystInter1";
            this.lblCholecystInter1.Size = new System.Drawing.Size(96, 16);
            this.lblCholecystInter1.TabIndex = 591;
            this.lblCholecystInter1.Text = "胆内胆管";
            // 
            // lblstone
            // 
            this.lblstone.Location = new System.Drawing.Point(96, 624);
            this.lblstone.Name = "lblstone";
            this.lblstone.Size = new System.Drawing.Size(96, 16);
            this.lblstone.TabIndex = 592;
            this.lblstone.Text = "结石部位";
            // 
            // chklblCholecystInterLeft1
            // 
            this.chklblCholecystInterLeft1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chklblCholecystInterLeft1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chklblCholecystInterLeft1.Location = new System.Drawing.Point(248, 584);
            this.chklblCholecystInterLeft1.Name = "chklblCholecystInterLeft1";
            this.chklblCholecystInterLeft1.Size = new System.Drawing.Size(96, 24);
            this.chklblCholecystInterLeft1.TabIndex = 593;
            this.chklblCholecystInterLeft1.Text = "正常";
            this.chklblCholecystInterLeft1.UseVisualStyleBackColor = false;
            // 
            // chklblCholecystInterLeft2
            // 
            this.chklblCholecystInterLeft2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chklblCholecystInterLeft2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chklblCholecystInterLeft2.Location = new System.Drawing.Point(320, 584);
            this.chklblCholecystInterLeft2.Name = "chklblCholecystInterLeft2";
            this.chklblCholecystInterLeft2.Size = new System.Drawing.Size(96, 24);
            this.chklblCholecystInterLeft2.TabIndex = 594;
            this.chklblCholecystInterLeft2.Text = "扩张";
            this.chklblCholecystInterLeft2.UseVisualStyleBackColor = false;
            // 
            // lblCholecystInterLeft
            // 
            this.lblCholecystInterLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblCholecystInterLeft.Location = new System.Drawing.Point(184, 592);
            this.lblCholecystInterLeft.Name = "lblCholecystInterLeft";
            this.lblCholecystInterLeft.Size = new System.Drawing.Size(56, 16);
            this.lblCholecystInterLeft.TabIndex = 595;
            this.lblCholecystInterLeft.Text = "左肝管";
            // 
            // lblInterCM
            // 
            this.lblInterCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblInterCM.Location = new System.Drawing.Point(496, 576);
            this.lblInterCM.Name = "lblInterCM";
            this.lblInterCM.Size = new System.Drawing.Size(48, 24);
            this.lblInterCM.TabIndex = 598;
            this.lblInterCM.Text = "Cm";
            // 
            // txtInter
            // 
            this.txtInter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtInter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInter.Location = new System.Drawing.Point(440, 576);
            this.txtInter.Name = "txtInter";
            this.txtInter.Size = new System.Drawing.Size(48, 23);
            this.txtInter.TabIndex = 597;
            // 
            // lblInter
            // 
            this.lblInter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblInter.Location = new System.Drawing.Point(400, 584);
            this.lblInter.Name = "lblInter";
            this.lblInter.Size = new System.Drawing.Size(56, 16);
            this.lblInter.TabIndex = 596;
            this.lblInter.Text = "内径";
            // 
            // chkstone1
            // 
            this.chkstone1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkstone1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkstone1.Location = new System.Drawing.Point(184, 616);
            this.chkstone1.Name = "chkstone1";
            this.chkstone1.Size = new System.Drawing.Size(96, 24);
            this.chkstone1.TabIndex = 599;
            this.chkstone1.Text = "肝内";
            this.chkstone1.UseVisualStyleBackColor = false;
            // 
            // chkstone2
            // 
            this.chkstone2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkstone2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkstone2.Location = new System.Drawing.Point(264, 616);
            this.chkstone2.Name = "chkstone2";
            this.chkstone2.Size = new System.Drawing.Size(96, 24);
            this.chkstone2.TabIndex = 600;
            this.chkstone2.Text = "胆囊";
            this.chkstone2.UseVisualStyleBackColor = false;
            // 
            // chkstone3
            // 
            this.chkstone3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkstone3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkstone3.Location = new System.Drawing.Point(360, 616);
            this.chkstone3.Name = "chkstone3";
            this.chkstone3.Size = new System.Drawing.Size(96, 24);
            this.chkstone3.TabIndex = 601;
            this.chkstone3.Text = "胆总管";
            this.chkstone3.UseVisualStyleBackColor = false;
            // 
            // lblKidney
            // 
            this.lblKidney.AutoSize = true;
            this.lblKidney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblKidney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblKidney.Location = new System.Drawing.Point(560, 488);
            this.lblKidney.Name = "lblKidney";
            this.lblKidney.Size = new System.Drawing.Size(47, 19);
            this.lblKidney.TabIndex = 602;
            this.lblKidney.Text = "肾脏";
            // 
            // lblKidneySizeCM
            // 
            this.lblKidneySizeCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblKidneySizeCM.Location = new System.Drawing.Point(776, 480);
            this.lblKidneySizeCM.Name = "lblKidneySizeCM";
            this.lblKidneySizeCM.Size = new System.Drawing.Size(24, 24);
            this.lblKidneySizeCM.TabIndex = 605;
            this.lblKidneySizeCM.Text = "Cm";
            // 
            // txtKidneySize
            // 
            this.txtKidneySize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtKidneySize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKidneySize.Location = new System.Drawing.Point(720, 480);
            this.txtKidneySize.Name = "txtKidneySize";
            this.txtKidneySize.Size = new System.Drawing.Size(48, 23);
            this.txtKidneySize.TabIndex = 604;
            // 
            // lblKidneySize
            // 
            this.lblKidneySize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblKidneySize.Location = new System.Drawing.Point(640, 488);
            this.lblKidneySize.Name = "lblKidneySize";
            this.lblKidneySize.Size = new System.Drawing.Size(64, 16);
            this.lblKidneySize.TabIndex = 603;
            this.lblKidneySize.Text = "左肾大小正常";
            // 
            // chkKidneySize1
            // 
            this.chkKidneySize1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkKidneySize1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKidneySize1.Location = new System.Drawing.Point(640, 520);
            this.chkKidneySize1.Name = "chkKidneySize1";
            this.chkKidneySize1.Size = new System.Drawing.Size(96, 24);
            this.chkKidneySize1.TabIndex = 606;
            this.chkKidneySize1.Text = "无光团";
            this.chkKidneySize1.UseVisualStyleBackColor = false;
            // 
            // chkKidneySize2
            // 
            this.chkKidneySize2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkKidneySize2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKidneySize2.Location = new System.Drawing.Point(720, 520);
            this.chkKidneySize2.Name = "chkKidneySize2";
            this.chkKidneySize2.Size = new System.Drawing.Size(96, 24);
            this.chkKidneySize2.TabIndex = 607;
            this.chkKidneySize2.Text = "积液";
            this.chkKidneySize2.UseVisualStyleBackColor = false;
            // 
            // chkKidneySize3
            // 
            this.chkKidneySize3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkKidneySize3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKidneySize3.Location = new System.Drawing.Point(792, 520);
            this.chkKidneySize3.Name = "chkKidneySize3";
            this.chkKidneySize3.Size = new System.Drawing.Size(96, 24);
            this.chkKidneySize3.TabIndex = 608;
            this.chkKidneySize3.Text = "占位";
            this.chkKidneySize3.UseVisualStyleBackColor = false;
            // 
            // chkKidneySize4
            // 
            this.chkKidneySize4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkKidneySize4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKidneySize4.Location = new System.Drawing.Point(864, 520);
            this.chkKidneySize4.Name = "chkKidneySize4";
            this.chkKidneySize4.Size = new System.Drawing.Size(96, 24);
            this.chkKidneySize4.TabIndex = 609;
            this.chkKidneySize4.Text = "外周滑";
            this.chkKidneySize4.UseVisualStyleBackColor = false;
            // 
            // chkKidneySize5
            // 
            this.chkKidneySize5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkKidneySize5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkKidneySize5.Location = new System.Drawing.Point(960, 520);
            this.chkKidneySize5.Name = "chkKidneySize5";
            this.chkKidneySize5.Size = new System.Drawing.Size(96, 24);
            this.chkKidneySize5.TabIndex = 610;
            this.chkKidneySize5.Text = "活动好";
            this.chkKidneySize5.UseVisualStyleBackColor = false;
            // 
            // lblRightKidneySizeCM
            // 
            this.lblRightKidneySizeCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightKidneySizeCM.Location = new System.Drawing.Point(800, 552);
            this.lblRightKidneySizeCM.Name = "lblRightKidneySizeCM";
            this.lblRightKidneySizeCM.Size = new System.Drawing.Size(48, 24);
            this.lblRightKidneySizeCM.TabIndex = 613;
            this.lblRightKidneySizeCM.Text = "Cm";
            // 
            // txtRightKidneySize
            // 
            this.txtRightKidneySize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRightKidneySize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightKidneySize.Location = new System.Drawing.Point(744, 552);
            this.txtRightKidneySize.Name = "txtRightKidneySize";
            this.txtRightKidneySize.Size = new System.Drawing.Size(48, 23);
            this.txtRightKidneySize.TabIndex = 612;
            // 
            // lblRightKidneySize
            // 
            this.lblRightKidneySize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightKidneySize.Location = new System.Drawing.Point(640, 560);
            this.lblRightKidneySize.Name = "lblRightKidneySize";
            this.lblRightKidneySize.Size = new System.Drawing.Size(96, 16);
            this.lblRightKidneySize.TabIndex = 611;
            this.lblRightKidneySize.Text = "右肾大小正常";
            // 
            // chkRightKidneySize1
            // 
            this.chkRightKidneySize1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkRightKidneySize1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRightKidneySize1.Location = new System.Drawing.Point(640, 584);
            this.chkRightKidneySize1.Name = "chkRightKidneySize1";
            this.chkRightKidneySize1.Size = new System.Drawing.Size(96, 24);
            this.chkRightKidneySize1.TabIndex = 614;
            this.chkRightKidneySize1.Text = "无光团";
            this.chkRightKidneySize1.UseVisualStyleBackColor = false;
            // 
            // chkRightKidneySize2
            // 
            this.chkRightKidneySize2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkRightKidneySize2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRightKidneySize2.Location = new System.Drawing.Point(744, 584);
            this.chkRightKidneySize2.Name = "chkRightKidneySize2";
            this.chkRightKidneySize2.Size = new System.Drawing.Size(96, 24);
            this.chkRightKidneySize2.TabIndex = 615;
            this.chkRightKidneySize2.Text = "积液";
            this.chkRightKidneySize2.UseVisualStyleBackColor = false;
            // 
            // chkRightKidneySize3
            // 
            this.chkRightKidneySize3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkRightKidneySize3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRightKidneySize3.Location = new System.Drawing.Point(832, 584);
            this.chkRightKidneySize3.Name = "chkRightKidneySize3";
            this.chkRightKidneySize3.Size = new System.Drawing.Size(96, 24);
            this.chkRightKidneySize3.TabIndex = 616;
            this.chkRightKidneySize3.Text = "占位";
            this.chkRightKidneySize3.UseVisualStyleBackColor = false;
            // 
            // chkRightKidneySize4
            // 
            this.chkRightKidneySize4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkRightKidneySize4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRightKidneySize4.Location = new System.Drawing.Point(920, 584);
            this.chkRightKidneySize4.Name = "chkRightKidneySize4";
            this.chkRightKidneySize4.Size = new System.Drawing.Size(96, 24);
            this.chkRightKidneySize4.TabIndex = 617;
            this.chkRightKidneySize4.Text = "外周滑";
            this.chkRightKidneySize4.UseVisualStyleBackColor = false;
            // 
            // chkRightKidneySize5
            // 
            this.chkRightKidneySize5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRightKidneySize5.Location = new System.Drawing.Point(992, 584);
            this.chkRightKidneySize5.Name = "chkRightKidneySize5";
            this.chkRightKidneySize5.Size = new System.Drawing.Size(96, 24);
            this.chkRightKidneySize5.TabIndex = 618;
            this.chkRightKidneySize5.Text = "活动好";
            // 
            // lblBladder
            // 
            this.lblBladder.AutoSize = true;
            this.lblBladder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblBladder.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBladder.Location = new System.Drawing.Point(560, 624);
            this.lblBladder.Name = "lblBladder";
            this.lblBladder.Size = new System.Drawing.Size(47, 19);
            this.lblBladder.TabIndex = 619;
            this.lblBladder.Text = "膀胱";
            // 
            // chkBladder1
            // 
            this.chkBladder1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkBladder1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBladder1.Location = new System.Drawing.Point(640, 624);
            this.chkBladder1.Name = "chkBladder1";
            this.chkBladder1.Size = new System.Drawing.Size(96, 24);
            this.chkBladder1.TabIndex = 620;
            this.chkBladder1.Text = "充盈好";
            this.chkBladder1.UseVisualStyleBackColor = false;
            // 
            // chkBladder2
            // 
            this.chkBladder2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkBladder2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBladder2.Location = new System.Drawing.Point(728, 624);
            this.chkBladder2.Name = "chkBladder2";
            this.chkBladder2.Size = new System.Drawing.Size(96, 24);
            this.chkBladder2.TabIndex = 621;
            this.chkBladder2.Text = "内未见光团";
            this.chkBladder2.UseVisualStyleBackColor = false;
            // 
            // chkBladder3
            // 
            this.chkBladder3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkBladder3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkBladder3.Location = new System.Drawing.Point(824, 624);
            this.chkBladder3.Name = "chkBladder3";
            this.chkBladder3.Size = new System.Drawing.Size(96, 24);
            this.chkBladder3.TabIndex = 622;
            this.chkBladder3.Text = "充盈欠佳";
            this.chkBladder3.UseVisualStyleBackColor = false;
            // 
            // lblProstate
            // 
            this.lblProstate.AutoSize = true;
            this.lblProstate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblProstate.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblProstate.Location = new System.Drawing.Point(560, 672);
            this.lblProstate.Name = "lblProstate";
            this.lblProstate.Size = new System.Drawing.Size(66, 19);
            this.lblProstate.TabIndex = 623;
            this.lblProstate.Text = "前列腺";
            // 
            // chkProstate1
            // 
            this.chkProstate1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkProstate1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProstate1.Location = new System.Drawing.Point(640, 664);
            this.chkProstate1.Name = "chkProstate1";
            this.chkProstate1.Size = new System.Drawing.Size(96, 24);
            this.chkProstate1.TabIndex = 624;
            this.chkProstate1.Text = "大小正常";
            this.chkProstate1.UseVisualStyleBackColor = false;
            // 
            // lblProstateIncrCM
            // 
            this.lblProstateIncrCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblProstateIncrCM.Location = new System.Drawing.Point(848, 664);
            this.lblProstateIncrCM.Name = "lblProstateIncrCM";
            this.lblProstateIncrCM.Size = new System.Drawing.Size(48, 24);
            this.lblProstateIncrCM.TabIndex = 627;
            this.lblProstateIncrCM.Text = "Cm";
            // 
            // txtProstateIncr
            // 
            this.txtProstateIncr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtProstateIncr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProstateIncr.Location = new System.Drawing.Point(768, 664);
            this.txtProstateIncr.Name = "txtProstateIncr";
            this.txtProstateIncr.Size = new System.Drawing.Size(48, 23);
            this.txtProstateIncr.TabIndex = 626;
            // 
            // lblProstateIncr
            // 
            this.lblProstateIncr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblProstateIncr.Location = new System.Drawing.Point(728, 664);
            this.lblProstateIncr.Name = "lblProstateIncr";
            this.lblProstateIncr.Size = new System.Drawing.Size(56, 16);
            this.lblProstateIncr.TabIndex = 625;
            this.lblProstateIncr.Text = "增大";
            // 
            // chkProstate2
            // 
            this.chkProstate2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkProstate2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProstate2.Location = new System.Drawing.Point(640, 696);
            this.chkProstate2.Name = "chkProstate2";
            this.chkProstate2.Size = new System.Drawing.Size(128, 24);
            this.chkProstate2.TabIndex = 628;
            this.chkProstate2.Text = "内点分布不均匀";
            this.chkProstate2.UseVisualStyleBackColor = false;
            // 
            // chkProstate3
            // 
            this.chkProstate3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkProstate3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProstate3.Location = new System.Drawing.Point(784, 696);
            this.chkProstate3.Name = "chkProstate3";
            this.chkProstate3.Size = new System.Drawing.Size(96, 24);
            this.chkProstate3.TabIndex = 629;
            this.chkProstate3.Text = "不均匀";
            this.chkProstate3.UseVisualStyleBackColor = false;
            // 
            // chkProstate4
            // 
            this.chkProstate4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.chkProstate4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProstate4.Location = new System.Drawing.Point(864, 696);
            this.chkProstate4.Name = "chkProstate4";
            this.chkProstate4.Size = new System.Drawing.Size(96, 24);
            this.chkProstate4.TabIndex = 630;
            this.chkProstate4.Text = "边缘整";
            this.chkProstate4.UseVisualStyleBackColor = false;
            // 
            // lblgland
            // 
            this.lblgland.AutoSize = true;
            this.lblgland.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblgland.Location = new System.Drawing.Point(24, 672);
            this.lblgland.Name = "lblgland";
            this.lblgland.Size = new System.Drawing.Size(47, 19);
            this.lblgland.TabIndex = 632;
            this.lblgland.Text = "状腺";
            // 
            // lblGlangCM
            // 
            this.lblGlangCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblGlangCM.Location = new System.Drawing.Point(208, 664);
            this.lblGlangCM.Name = "lblGlangCM";
            this.lblGlangCM.Size = new System.Drawing.Size(48, 24);
            this.lblGlangCM.TabIndex = 635;
            this.lblGlangCM.Text = "Cm宽";
            // 
            // txtGland
            // 
            this.txtGland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtGland.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGland.Location = new System.Drawing.Point(152, 664);
            this.txtGland.Name = "txtGland";
            this.txtGland.Size = new System.Drawing.Size(48, 23);
            this.txtGland.TabIndex = 634;
            // 
            // lblGlandLeft
            // 
            this.lblGlandLeft.Location = new System.Drawing.Point(96, 672);
            this.lblGlandLeft.Name = "lblGlandLeft";
            this.lblGlandLeft.Size = new System.Drawing.Size(56, 16);
            this.lblGlandLeft.TabIndex = 633;
            this.lblGlandLeft.Text = "左长";
            // 
            // lblGlandCM
            // 
            this.lblGlandCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblGlandCM.Location = new System.Drawing.Point(336, 672);
            this.lblGlandCM.Name = "lblGlandCM";
            this.lblGlandCM.Size = new System.Drawing.Size(48, 24);
            this.lblGlandCM.TabIndex = 638;
            this.lblGlandCM.Text = "Cm";
            // 
            // txtGlandSize
            // 
            this.txtGlandSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtGlandSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGlandSize.Location = new System.Drawing.Point(280, 664);
            this.txtGlandSize.Name = "txtGlandSize";
            this.txtGlandSize.Size = new System.Drawing.Size(48, 23);
            this.txtGlandSize.TabIndex = 637;
            // 
            // lblGlandSize
            // 
            this.lblGlandSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblGlandSize.Location = new System.Drawing.Point(256, 664);
            this.lblGlandSize.Name = "lblGlandSize";
            this.lblGlandSize.Size = new System.Drawing.Size(56, 16);
            this.lblGlandSize.TabIndex = 636;
            this.lblGlandSize.Text = "厚";
            // 
            // lblRightGlandCM
            // 
            this.lblRightGlandCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightGlandCM.Location = new System.Drawing.Point(208, 712);
            this.lblRightGlandCM.Name = "lblRightGlandCM";
            this.lblRightGlandCM.Size = new System.Drawing.Size(48, 24);
            this.lblRightGlandCM.TabIndex = 641;
            this.lblRightGlandCM.Text = "Cm宽";
            // 
            // txtRightGland
            // 
            this.txtRightGland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRightGland.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightGland.Location = new System.Drawing.Point(152, 712);
            this.txtRightGland.Name = "txtRightGland";
            this.txtRightGland.Size = new System.Drawing.Size(48, 23);
            this.txtRightGland.TabIndex = 640;
            // 
            // lblRightGland
            // 
            this.lblRightGland.Location = new System.Drawing.Point(96, 720);
            this.lblRightGland.Name = "lblRightGland";
            this.lblRightGland.Size = new System.Drawing.Size(56, 16);
            this.lblRightGland.TabIndex = 639;
            this.lblRightGland.Text = "右长";
            // 
            // lblRightGlandSizeCM
            // 
            this.lblRightGlandSizeCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightGlandSizeCM.Location = new System.Drawing.Point(336, 720);
            this.lblRightGlandSizeCM.Name = "lblRightGlandSizeCM";
            this.lblRightGlandSizeCM.Size = new System.Drawing.Size(48, 24);
            this.lblRightGlandSizeCM.TabIndex = 644;
            this.lblRightGlandSizeCM.Text = "Cm";
            // 
            // txtRightGlandSize
            // 
            this.txtRightGlandSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRightGlandSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightGlandSize.Location = new System.Drawing.Point(280, 712);
            this.txtRightGlandSize.Name = "txtRightGlandSize";
            this.txtRightGlandSize.Size = new System.Drawing.Size(48, 23);
            this.txtRightGlandSize.TabIndex = 643;
            // 
            // lblRightGlandSize
            // 
            this.lblRightGlandSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightGlandSize.Location = new System.Drawing.Point(256, 712);
            this.lblRightGlandSize.Name = "lblRightGlandSize";
            this.lblRightGlandSize.Size = new System.Drawing.Size(56, 16);
            this.lblRightGlandSize.TabIndex = 642;
            this.lblRightGlandSize.Text = "厚";
            // 
            // lblBackGlandCM
            // 
            this.lblBackGlandCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblBackGlandCM.Location = new System.Drawing.Point(208, 760);
            this.lblBackGlandCM.Name = "lblBackGlandCM";
            this.lblBackGlandCM.Size = new System.Drawing.Size(48, 24);
            this.lblBackGlandCM.TabIndex = 647;
            this.lblBackGlandCM.Text = "Cm";
            // 
            // txtBackGland
            // 
            this.txtBackGland.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtBackGland.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBackGland.Location = new System.Drawing.Point(152, 760);
            this.txtBackGland.Name = "txtBackGland";
            this.txtBackGland.Size = new System.Drawing.Size(48, 23);
            this.txtBackGland.TabIndex = 646;
            // 
            // lblBackGland
            // 
            this.lblBackGland.Location = new System.Drawing.Point(96, 768);
            this.lblBackGland.Name = "lblBackGland";
            this.lblBackGland.Size = new System.Drawing.Size(56, 16);
            this.lblBackGland.TabIndex = 645;
            this.lblBackGland.Text = "峡部厚";
            // 
            // lblSpermary
            // 
            this.lblSpermary.AutoSize = true;
            this.lblSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpermary.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpermary.Location = new System.Drawing.Point(560, 736);
            this.lblSpermary.Name = "lblSpermary";
            this.lblSpermary.Size = new System.Drawing.Size(47, 19);
            this.lblSpermary.TabIndex = 648;
            this.lblSpermary.Text = "睾丸";
            // 
            // lblFSpermary
            // 
            this.lblFSpermary.AutoSize = true;
            this.lblFSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblFSpermary.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFSpermary.Location = new System.Drawing.Point(560, 760);
            this.lblFSpermary.Name = "lblFSpermary";
            this.lblFSpermary.Size = new System.Drawing.Size(47, 19);
            this.lblFSpermary.TabIndex = 649;
            this.lblFSpermary.Text = "附睾";
            // 
            // lblLeftSpermaryCM
            // 
            this.lblLeftSpermaryCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblLeftSpermaryCM.Location = new System.Drawing.Point(728, 728);
            this.lblLeftSpermaryCM.Name = "lblLeftSpermaryCM";
            this.lblLeftSpermaryCM.Size = new System.Drawing.Size(48, 24);
            this.lblLeftSpermaryCM.TabIndex = 652;
            this.lblLeftSpermaryCM.Text = "Cm";
            // 
            // txtLeftSpermary
            // 
            this.txtLeftSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtLeftSpermary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeftSpermary.Location = new System.Drawing.Point(672, 728);
            this.txtLeftSpermary.Name = "txtLeftSpermary";
            this.txtLeftSpermary.Size = new System.Drawing.Size(48, 23);
            this.txtLeftSpermary.TabIndex = 651;
            // 
            // lblLeftSpermary
            // 
            this.lblLeftSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblLeftSpermary.Location = new System.Drawing.Point(640, 736);
            this.lblLeftSpermary.Name = "lblLeftSpermary";
            this.lblLeftSpermary.Size = new System.Drawing.Size(24, 16);
            this.lblLeftSpermary.TabIndex = 650;
            this.lblLeftSpermary.Text = "左";
            // 
            // lblSpermaryRightCM
            // 
            this.lblSpermaryRightCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblSpermaryRightCM.Location = new System.Drawing.Point(904, 728);
            this.lblSpermaryRightCM.Name = "lblSpermaryRightCM";
            this.lblSpermaryRightCM.Size = new System.Drawing.Size(48, 24);
            this.lblSpermaryRightCM.TabIndex = 655;
            this.lblSpermaryRightCM.Text = "Cm";
            // 
            // txtRigthSpermary
            // 
            this.txtRigthSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRigthSpermary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRigthSpermary.Location = new System.Drawing.Point(840, 728);
            this.txtRigthSpermary.Name = "txtRigthSpermary";
            this.txtRigthSpermary.Size = new System.Drawing.Size(48, 23);
            this.txtRigthSpermary.TabIndex = 654;
            // 
            // lblRightSpermary
            // 
            this.lblRightSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightSpermary.Location = new System.Drawing.Point(792, 736);
            this.lblRightSpermary.Name = "lblRightSpermary";
            this.lblRightSpermary.Size = new System.Drawing.Size(32, 16);
            this.lblRightSpermary.TabIndex = 653;
            this.lblRightSpermary.Text = "右";
            // 
            // lbllLeftFSpermaryCM
            // 
            this.lbllLeftFSpermaryCM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lbllLeftFSpermaryCM.Location = new System.Drawing.Point(728, 760);
            this.lbllLeftFSpermaryCM.Name = "lbllLeftFSpermaryCM";
            this.lbllLeftFSpermaryCM.Size = new System.Drawing.Size(64, 24);
            this.lbllLeftFSpermaryCM.TabIndex = 658;
            this.lbllLeftFSpermaryCM.Text = "Cm";
            // 
            // txtlLeftFSpermary
            // 
            this.txtlLeftFSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtlLeftFSpermary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtlLeftFSpermary.Location = new System.Drawing.Point(672, 760);
            this.txtlLeftFSpermary.Name = "txtlLeftFSpermary";
            this.txtlLeftFSpermary.Size = new System.Drawing.Size(48, 23);
            this.txtlLeftFSpermary.TabIndex = 657;
            // 
            // lblLeftFSpermary
            // 
            this.lblLeftFSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblLeftFSpermary.Location = new System.Drawing.Point(640, 768);
            this.lblLeftFSpermary.Name = "lblLeftFSpermary";
            this.lblLeftFSpermary.Size = new System.Drawing.Size(16, 16);
            this.lblLeftFSpermary.TabIndex = 656;
            this.lblLeftFSpermary.Text = "左";
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.label78.Location = new System.Drawing.Point(904, 760);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(48, 24);
            this.label78.TabIndex = 661;
            this.label78.Text = "Cm";
            // 
            // txtRightFSpermary
            // 
            this.txtRightFSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtRightFSpermary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightFSpermary.Location = new System.Drawing.Point(840, 760);
            this.txtRightFSpermary.Name = "txtRightFSpermary";
            this.txtRightFSpermary.Size = new System.Drawing.Size(48, 23);
            this.txtRightFSpermary.TabIndex = 660;
            // 
            // lblRightFSpermary
            // 
            this.lblRightFSpermary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.lblRightFSpermary.Location = new System.Drawing.Point(792, 768);
            this.lblRightFSpermary.Name = "lblRightFSpermary";
            this.lblRightFSpermary.Size = new System.Drawing.Size(40, 16);
            this.lblRightFSpermary.TabIndex = 659;
            this.lblRightFSpermary.Text = "右";
            // 
            // lblSpecialRecord
            // 
            this.lblSpecialRecord.AutoSize = true;
            this.lblSpecialRecord.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSpecialRecord.Location = new System.Drawing.Point(16, 824);
            this.lblSpecialRecord.Name = "lblSpecialRecord";
            this.lblSpecialRecord.Size = new System.Drawing.Size(85, 19);
            this.lblSpecialRecord.TabIndex = 662;
            this.lblSpecialRecord.Text = "特殊记录";
            // 
            // txtBClinic
            // 
            this.txtBClinic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtBClinic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBClinic.Location = new System.Drawing.Point(152, 928);
            this.txtBClinic.Multiline = true;
            this.txtBClinic.Name = "txtBClinic";
            this.txtBClinic.Size = new System.Drawing.Size(592, 104);
            this.txtBClinic.TabIndex = 663;
            // 
            // txtSpecialRecord
            // 
            this.txtSpecialRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.txtSpecialRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpecialRecord.Location = new System.Drawing.Point(152, 816);
            this.txtSpecialRecord.Multiline = true;
            this.txtSpecialRecord.Name = "txtSpecialRecord";
            this.txtSpecialRecord.Size = new System.Drawing.Size(592, 104);
            this.txtSpecialRecord.TabIndex = 664;
            // 
            // lblBClinic
            // 
            this.lblBClinic.AutoSize = true;
            this.lblBClinic.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBClinic.Location = new System.Drawing.Point(16, 928);
            this.lblBClinic.Name = "lblBClinic";
            this.lblBClinic.Size = new System.Drawing.Size(76, 19);
            this.lblBClinic.TabIndex = 665;
            this.lblBClinic.Text = "B超诊断";
            // 
            // frmBUltrasonicCheckReport
            // 
            this.AccessibleDescription = "B型超声显像检查报告";
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.ClientSize = new System.Drawing.Size(936, 661);
            this.Controls.Add(this.lblBClinic);
            this.Controls.Add(this.txtSpecialRecord);
            this.Controls.Add(this.txtBClinic);
            this.Controls.Add(this.lblSpecialRecord);
            this.Controls.Add(this.label78);
            this.Controls.Add(this.txtRightFSpermary);
            this.Controls.Add(this.lblRightFSpermary);
            this.Controls.Add(this.lbllLeftFSpermaryCM);
            this.Controls.Add(this.txtlLeftFSpermary);
            this.Controls.Add(this.lblLeftFSpermary);
            this.Controls.Add(this.lblSpermaryRightCM);
            this.Controls.Add(this.txtRigthSpermary);
            this.Controls.Add(this.lblRightSpermary);
            this.Controls.Add(this.lblLeftSpermaryCM);
            this.Controls.Add(this.txtLeftSpermary);
            this.Controls.Add(this.lblLeftSpermary);
            this.Controls.Add(this.lblFSpermary);
            this.Controls.Add(this.lblSpermary);
            this.Controls.Add(this.lblBackGlandCM);
            this.Controls.Add(this.txtBackGland);
            this.Controls.Add(this.lblBackGland);
            this.Controls.Add(this.lblRightGlandSizeCM);
            this.Controls.Add(this.txtRightGlandSize);
            this.Controls.Add(this.lblRightGlandSize);
            this.Controls.Add(this.lblRightGlandCM);
            this.Controls.Add(this.txtRightGland);
            this.Controls.Add(this.lblRightGland);
            this.Controls.Add(this.lblGlandCM);
            this.Controls.Add(this.txtGlandSize);
            this.Controls.Add(this.lblGlandSize);
            this.Controls.Add(this.lblGlangCM);
            this.Controls.Add(this.txtGland);
            this.Controls.Add(this.lblGlandLeft);
            this.Controls.Add(this.lblgland);
            this.Controls.Add(this.chkProstate4);
            this.Controls.Add(this.chkProstate3);
            this.Controls.Add(this.chkProstate2);
            this.Controls.Add(this.lblProstateIncrCM);
            this.Controls.Add(this.txtProstateIncr);
            this.Controls.Add(this.lblProstateIncr);
            this.Controls.Add(this.chkProstate1);
            this.Controls.Add(this.lblProstate);
            this.Controls.Add(this.chkBladder3);
            this.Controls.Add(this.chkBladder2);
            this.Controls.Add(this.chkBladder1);
            this.Controls.Add(this.lblBladder);
            this.Controls.Add(this.chkRightKidneySize5);
            this.Controls.Add(this.chkRightKidneySize4);
            this.Controls.Add(this.chkRightKidneySize3);
            this.Controls.Add(this.chkRightKidneySize2);
            this.Controls.Add(this.chkRightKidneySize1);
            this.Controls.Add(this.lblRightKidneySizeCM);
            this.Controls.Add(this.txtRightKidneySize);
            this.Controls.Add(this.lblRightKidneySize);
            this.Controls.Add(this.chkKidneySize5);
            this.Controls.Add(this.chkKidneySize4);
            this.Controls.Add(this.chkKidneySize3);
            this.Controls.Add(this.chkKidneySize2);
            this.Controls.Add(this.chkKidneySize1);
            this.Controls.Add(this.lblKidneySizeCM);
            this.Controls.Add(this.txtKidneySize);
            this.Controls.Add(this.lblKidneySize);
            this.Controls.Add(this.lblKidney);
            this.Controls.Add(this.chkstone3);
            this.Controls.Add(this.chkstone2);
            this.Controls.Add(this.chkstone1);
            this.Controls.Add(this.lblInterCM);
            this.Controls.Add(this.txtInter);
            this.Controls.Add(this.lblInter);
            this.Controls.Add(this.lblCholecystInterLeft);
            this.Controls.Add(this.chklblCholecystInterLeft2);
            this.Controls.Add(this.chklblCholecystInterLeft1);
            this.Controls.Add(this.lblstone);
            this.Controls.Add(this.lblCholecystInter1);
            this.Controls.Add(this.chkCholecystInter2);
            this.Controls.Add(this.chkCholecystInter1);
            this.Controls.Add(this.lblCholecystInterCM);
            this.Controls.Add(this.txtCholecystInter);
            this.Controls.Add(this.lblCholecystInter);
            this.Controls.Add(this.lblGauffer);
            this.Controls.Add(this.lblCholecystCliffCM);
            this.Controls.Add(this.txtDeepCholecystCliff);
            this.Controls.Add(this.lblDeepCholecystCliff);
            this.Controls.Add(this.chkCholecystCliff2);
            this.Controls.Add(this.chkCholecystCliff1);
            this.Controls.Add(this.lblCholecystCliff);
            this.Controls.Add(this.lblCholecystCM);
            this.Controls.Add(this.txtCholecyst);
            this.Controls.Add(this.lblCholecystSize);
            this.Controls.Add(this.lblCholecyst);
            this.Controls.Add(this.chkPancreasInter2);
            this.Controls.Add(this.chkPancreasInter1);
            this.Controls.Add(this.lblPancreasInteCM);
            this.Controls.Add(this.txtPancreasInter);
            this.Controls.Add(this.lbllPancreasInter);
            this.Controls.Add(this.chklPancreasEnd1);
            this.Controls.Add(this.chkPancreasBody1);
            this.Controls.Add(this.chkPancreasHead1);
            this.Controls.Add(this.lbllPancreasEndCM);
            this.Controls.Add(this.txtlPancreasEnd);
            this.Controls.Add(this.lblPancreasEnd);
            this.Controls.Add(this.lblPancreasbodyCM);
            this.Controls.Add(this.txtPancreasbody);
            this.Controls.Add(this.lblPancreasbody);
            this.Controls.Add(this.lblPancreasCM);
            this.Controls.Add(this.txtPancreasHead);
            this.Controls.Add(this.lblPancreasHead);
            this.Controls.Add(this.chkPancreas4);
            this.Controls.Add(this.chkPancreas3);
            this.Controls.Add(this.chkPancreas2);
            this.Controls.Add(this.chkPancreas1);
            this.Controls.Add(this.lblPancreas);
            this.Controls.Add(this.lblSpleenStr);
            this.Controls.Add(this.lblSpleenStrCM);
            this.Controls.Add(this.txtSpleenStrSize);
            this.Controls.Add(this.lblSpleenStrSize);
            this.Controls.Add(this.chkSpleenStr1);
            this.Controls.Add(this.lSpleenReturn2);
            this.Controls.Add(this.chklSpleenReturn1);
            this.Controls.Add(this.lbllSpleenReturn);
            this.Controls.Add(this.lSpleenSize2CM);
            this.Controls.Add(this.txtSpleenSize2);
            this.Controls.Add(this.lbllSpleenSize2);
            this.Controls.Add(this.lblRightCM);
            this.Controls.Add(this.txtRigthSize);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblspleen);
            this.Controls.Add(this.lblSpleenSize);
            this.Controls.Add(this.lblLeftSizeCM);
            this.Controls.Add(this.txtLeftSize);
            this.Controls.Add(this.lblLeftSize);
            this.Controls.Add(this.labLeftCM);
            this.Controls.Add(this.txtLeftLiver);
            this.Controls.Add(this.lblBackLiverCM);
            this.Controls.Add(this.txtBackLiver);
            this.Controls.Add(this.lblBackLiver);
            this.Controls.Add(this.chkLiverIn5);
            this.Controls.Add(this.chkLiverIn4);
            this.Controls.Add(this.chkLiverIn3);
            this.Controls.Add(this.chkLiverIn2);
            this.Controls.Add(this.chkLiverIn1);
            this.Controls.Add(this.chkLiverFace3);
            this.Controls.Add(this.chkLiverFace2);
            this.Controls.Add(this.chkLiverFace1);
            this.Controls.Add(this.chkLiverStr2);
            this.Controls.Add(this.chkLiverStr1);
            this.Controls.Add(this.lblLiverStr);
            this.Controls.Add(this.lblDoorLiverCM);
            this.Controls.Add(this.txtDoorLiver);
            this.Controls.Add(this.lbllSpleenSizeCM);
            this.Controls.Add(this.txtlSpleenSize1);
            this.Controls.Add(this.lblSpleenSize1);
            this.Controls.Add(this.lblLiverCM);
            this.Controls.Add(this.txtRightSize);
            this.Controls.Add(this.lblDoorLiver);
            this.Controls.Add(this.lblLiverIn);
            this.Controls.Add(this.labLiverFace);
            this.Controls.Add(this.lblLeftLiver);
            this.Controls.Add(this.lblLiverRight);
            this.Controls.Add(this.lblLiver);
            this.Name = "frmBUltrasonicCheckReport";
            this.Text = "B型超声显像检查报告";
            this.Load += new System.EventHandler(this.frmBUltrasonicCheckReport___Load);
            this.Controls.SetChildIndex(this.lblLiver, 0);
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
            this.Controls.SetChildIndex(this.lblLiverRight, 0);
            this.Controls.SetChildIndex(this.lblLeftLiver, 0);
            this.Controls.SetChildIndex(this.labLiverFace, 0);
            this.Controls.SetChildIndex(this.lblLiverIn, 0);
            this.Controls.SetChildIndex(this.lblDoorLiver, 0);
            this.Controls.SetChildIndex(this.txtRightSize, 0);
            this.Controls.SetChildIndex(this.lblLiverCM, 0);
            this.Controls.SetChildIndex(this.lblSpleenSize1, 0);
            this.Controls.SetChildIndex(this.txtlSpleenSize1, 0);
            this.Controls.SetChildIndex(this.lbllSpleenSizeCM, 0);
            this.Controls.SetChildIndex(this.txtDoorLiver, 0);
            this.Controls.SetChildIndex(this.lblDoorLiverCM, 0);
            this.Controls.SetChildIndex(this.lblLiverStr, 0);
            this.Controls.SetChildIndex(this.chkLiverStr1, 0);
            this.Controls.SetChildIndex(this.chkLiverStr2, 0);
            this.Controls.SetChildIndex(this.chkLiverFace1, 0);
            this.Controls.SetChildIndex(this.chkLiverFace2, 0);
            this.Controls.SetChildIndex(this.chkLiverFace3, 0);
            this.Controls.SetChildIndex(this.chkLiverIn1, 0);
            this.Controls.SetChildIndex(this.chkLiverIn2, 0);
            this.Controls.SetChildIndex(this.chkLiverIn3, 0);
            this.Controls.SetChildIndex(this.chkLiverIn4, 0);
            this.Controls.SetChildIndex(this.chkLiverIn5, 0);
            this.Controls.SetChildIndex(this.lblBackLiver, 0);
            this.Controls.SetChildIndex(this.txtBackLiver, 0);
            this.Controls.SetChildIndex(this.lblBackLiverCM, 0);
            this.Controls.SetChildIndex(this.txtLeftLiver, 0);
            this.Controls.SetChildIndex(this.labLeftCM, 0);
            this.Controls.SetChildIndex(this.lblLeftSize, 0);
            this.Controls.SetChildIndex(this.txtLeftSize, 0);
            this.Controls.SetChildIndex(this.lblLeftSizeCM, 0);
            this.Controls.SetChildIndex(this.lblSpleenSize, 0);
            this.Controls.SetChildIndex(this.lblspleen, 0);
            this.Controls.SetChildIndex(this.lblRight, 0);
            this.Controls.SetChildIndex(this.txtRigthSize, 0);
            this.Controls.SetChildIndex(this.lblRightCM, 0);
            this.Controls.SetChildIndex(this.lbllSpleenSize2, 0);
            this.Controls.SetChildIndex(this.txtSpleenSize2, 0);
            this.Controls.SetChildIndex(this.lSpleenSize2CM, 0);
            this.Controls.SetChildIndex(this.lbllSpleenReturn, 0);
            this.Controls.SetChildIndex(this.chklSpleenReturn1, 0);
            this.Controls.SetChildIndex(this.lSpleenReturn2, 0);
            this.Controls.SetChildIndex(this.chkSpleenStr1, 0);
            this.Controls.SetChildIndex(this.lblSpleenStrSize, 0);
            this.Controls.SetChildIndex(this.txtSpleenStrSize, 0);
            this.Controls.SetChildIndex(this.lblSpleenStrCM, 0);
            this.Controls.SetChildIndex(this.lblSpleenStr, 0);
            this.Controls.SetChildIndex(this.lblPancreas, 0);
            this.Controls.SetChildIndex(this.chkPancreas1, 0);
            this.Controls.SetChildIndex(this.chkPancreas2, 0);
            this.Controls.SetChildIndex(this.chkPancreas3, 0);
            this.Controls.SetChildIndex(this.chkPancreas4, 0);
            this.Controls.SetChildIndex(this.lblPancreasHead, 0);
            this.Controls.SetChildIndex(this.txtPancreasHead, 0);
            this.Controls.SetChildIndex(this.lblPancreasCM, 0);
            this.Controls.SetChildIndex(this.lblPancreasbody, 0);
            this.Controls.SetChildIndex(this.txtPancreasbody, 0);
            this.Controls.SetChildIndex(this.lblPancreasbodyCM, 0);
            this.Controls.SetChildIndex(this.lblPancreasEnd, 0);
            this.Controls.SetChildIndex(this.txtlPancreasEnd, 0);
            this.Controls.SetChildIndex(this.lbllPancreasEndCM, 0);
            this.Controls.SetChildIndex(this.chkPancreasHead1, 0);
            this.Controls.SetChildIndex(this.chkPancreasBody1, 0);
            this.Controls.SetChildIndex(this.chklPancreasEnd1, 0);
            this.Controls.SetChildIndex(this.lbllPancreasInter, 0);
            this.Controls.SetChildIndex(this.txtPancreasInter, 0);
            this.Controls.SetChildIndex(this.lblPancreasInteCM, 0);
            this.Controls.SetChildIndex(this.chkPancreasInter1, 0);
            this.Controls.SetChildIndex(this.chkPancreasInter2, 0);
            this.Controls.SetChildIndex(this.lblCholecyst, 0);
            this.Controls.SetChildIndex(this.lblCholecystSize, 0);
            this.Controls.SetChildIndex(this.txtCholecyst, 0);
            this.Controls.SetChildIndex(this.lblCholecystCM, 0);
            this.Controls.SetChildIndex(this.lblCholecystCliff, 0);
            this.Controls.SetChildIndex(this.chkCholecystCliff1, 0);
            this.Controls.SetChildIndex(this.chkCholecystCliff2, 0);
            this.Controls.SetChildIndex(this.lblDeepCholecystCliff, 0);
            this.Controls.SetChildIndex(this.txtDeepCholecystCliff, 0);
            this.Controls.SetChildIndex(this.lblCholecystCliffCM, 0);
            this.Controls.SetChildIndex(this.lblGauffer, 0);
            this.Controls.SetChildIndex(this.lblCholecystInter, 0);
            this.Controls.SetChildIndex(this.txtCholecystInter, 0);
            this.Controls.SetChildIndex(this.lblCholecystInterCM, 0);
            this.Controls.SetChildIndex(this.chkCholecystInter1, 0);
            this.Controls.SetChildIndex(this.chkCholecystInter2, 0);
            this.Controls.SetChildIndex(this.lblCholecystInter1, 0);
            this.Controls.SetChildIndex(this.lblstone, 0);
            this.Controls.SetChildIndex(this.chklblCholecystInterLeft1, 0);
            this.Controls.SetChildIndex(this.chklblCholecystInterLeft2, 0);
            this.Controls.SetChildIndex(this.lblCholecystInterLeft, 0);
            this.Controls.SetChildIndex(this.lblInter, 0);
            this.Controls.SetChildIndex(this.txtInter, 0);
            this.Controls.SetChildIndex(this.lblInterCM, 0);
            this.Controls.SetChildIndex(this.chkstone1, 0);
            this.Controls.SetChildIndex(this.chkstone2, 0);
            this.Controls.SetChildIndex(this.chkstone3, 0);
            this.Controls.SetChildIndex(this.lblKidney, 0);
            this.Controls.SetChildIndex(this.lblKidneySize, 0);
            this.Controls.SetChildIndex(this.txtKidneySize, 0);
            this.Controls.SetChildIndex(this.lblKidneySizeCM, 0);
            this.Controls.SetChildIndex(this.chkKidneySize1, 0);
            this.Controls.SetChildIndex(this.chkKidneySize2, 0);
            this.Controls.SetChildIndex(this.chkKidneySize3, 0);
            this.Controls.SetChildIndex(this.chkKidneySize4, 0);
            this.Controls.SetChildIndex(this.chkKidneySize5, 0);
            this.Controls.SetChildIndex(this.lblRightKidneySize, 0);
            this.Controls.SetChildIndex(this.txtRightKidneySize, 0);
            this.Controls.SetChildIndex(this.lblRightKidneySizeCM, 0);
            this.Controls.SetChildIndex(this.chkRightKidneySize1, 0);
            this.Controls.SetChildIndex(this.chkRightKidneySize2, 0);
            this.Controls.SetChildIndex(this.chkRightKidneySize3, 0);
            this.Controls.SetChildIndex(this.chkRightKidneySize4, 0);
            this.Controls.SetChildIndex(this.chkRightKidneySize5, 0);
            this.Controls.SetChildIndex(this.lblBladder, 0);
            this.Controls.SetChildIndex(this.chkBladder1, 0);
            this.Controls.SetChildIndex(this.chkBladder2, 0);
            this.Controls.SetChildIndex(this.chkBladder3, 0);
            this.Controls.SetChildIndex(this.lblProstate, 0);
            this.Controls.SetChildIndex(this.chkProstate1, 0);
            this.Controls.SetChildIndex(this.lblProstateIncr, 0);
            this.Controls.SetChildIndex(this.txtProstateIncr, 0);
            this.Controls.SetChildIndex(this.lblProstateIncrCM, 0);
            this.Controls.SetChildIndex(this.chkProstate2, 0);
            this.Controls.SetChildIndex(this.chkProstate3, 0);
            this.Controls.SetChildIndex(this.chkProstate4, 0);
            this.Controls.SetChildIndex(this.lblgland, 0);
            this.Controls.SetChildIndex(this.lblGlandLeft, 0);
            this.Controls.SetChildIndex(this.txtGland, 0);
            this.Controls.SetChildIndex(this.lblGlangCM, 0);
            this.Controls.SetChildIndex(this.lblGlandSize, 0);
            this.Controls.SetChildIndex(this.txtGlandSize, 0);
            this.Controls.SetChildIndex(this.lblGlandCM, 0);
            this.Controls.SetChildIndex(this.lblRightGland, 0);
            this.Controls.SetChildIndex(this.txtRightGland, 0);
            this.Controls.SetChildIndex(this.lblRightGlandCM, 0);
            this.Controls.SetChildIndex(this.lblRightGlandSize, 0);
            this.Controls.SetChildIndex(this.txtRightGlandSize, 0);
            this.Controls.SetChildIndex(this.lblRightGlandSizeCM, 0);
            this.Controls.SetChildIndex(this.lblBackGland, 0);
            this.Controls.SetChildIndex(this.txtBackGland, 0);
            this.Controls.SetChildIndex(this.lblBackGlandCM, 0);
            this.Controls.SetChildIndex(this.lblSpermary, 0);
            this.Controls.SetChildIndex(this.lblFSpermary, 0);
            this.Controls.SetChildIndex(this.lblLeftSpermary, 0);
            this.Controls.SetChildIndex(this.txtLeftSpermary, 0);
            this.Controls.SetChildIndex(this.lblLeftSpermaryCM, 0);
            this.Controls.SetChildIndex(this.lblRightSpermary, 0);
            this.Controls.SetChildIndex(this.txtRigthSpermary, 0);
            this.Controls.SetChildIndex(this.lblSpermaryRightCM, 0);
            this.Controls.SetChildIndex(this.lblLeftFSpermary, 0);
            this.Controls.SetChildIndex(this.txtlLeftFSpermary, 0);
            this.Controls.SetChildIndex(this.lbllLeftFSpermaryCM, 0);
            this.Controls.SetChildIndex(this.lblRightFSpermary, 0);
            this.Controls.SetChildIndex(this.txtRightFSpermary, 0);
            this.Controls.SetChildIndex(this.label78, 0);
            this.Controls.SetChildIndex(this.lblSpecialRecord, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.txtBClinic, 0);
            this.Controls.SetChildIndex(this.txtSpecialRecord, 0);
            this.Controls.SetChildIndex(this.lblBClinic, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmBUltrasonicCheckReport___Load(object sender, System.EventArgs e)
		{
			txtRightSize.Focus();
		}
	}
}

