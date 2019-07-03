using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.Utility .Controls ;
using System.Xml;
using System.IO;
using System.Text;
using System.Data ;
using CrystalDecisions.CrystalReports.Engine ;
using iCareData;

namespace iCare
{
	public class frmOperationAgreedRecord : frmHRPBaseForm,PublicFunction 
	{
		#region Defined
		private System.Windows.Forms.Label lblIdeaAndWrite;
		private System.Windows.Forms.Label lblIdeaAndWriteText;
		private System.Windows.Forms.Label lblWrite;
		private System.Windows.Forms.Label lblRelation;
		private System.Windows.Forms.Label lblRelationSufferer;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.Label lblRelationID;
		private System.Windows.Forms.Label lbldate;
		private System.Windows.Forms.Label lblIntro;
		private System.Windows.Forms.Label lblbefore;
		private System.Windows.Forms.Label lblTheName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPhone;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRelation;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRelationID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRelationSufferer;
		private System.Windows.Forms.CheckBox m_chkNose_1;
		private System.Windows.Forms.CheckBox m_chkNose_2;
		private System.Windows.Forms.CheckBox m_chkNose_3;
		private System.Windows.Forms.CheckBox m_chkNose_4;
		private System.Windows.Forms.CheckBox m_chkNose_5;
		private System.Windows.Forms.CheckBox m_chkNose_6;
		private System.Windows.Forms.CheckBox m_chkNose_7;
		private System.Windows.Forms.CheckBox m_chkNose_8;
		private System.Windows.Forms.CheckBox m_chkNose_9;
		private System.Windows.Forms.CheckBox m_chkNose_10;
		private System.Windows.Forms.CheckBox m_chkNose_11;
		private System.Windows.Forms.CheckBox m_chkNose_12;
		private System.Windows.Forms.CheckBox m_chkNose_13;
		private System.Windows.Forms.CheckBox m_chkNose_14;
		private System.Windows.Forms.CheckBox m_chkNose_15;
		private System.Windows.Forms.CheckBox m_chkNose_16;
		private System.Windows.Forms.CheckBox m_chkNose_17;
		private System.Windows.Forms.CheckBox m_chkNose_18;
		private System.Windows.Forms.CheckBox m_chkNose_19;
		private System.Windows.Forms.CheckBox m_chkNose_20;
		private System.Windows.Forms.CheckBox m_chkNose_21;
		private System.Windows.Forms.CheckBox m_chkNose_22;
		private System.Windows.Forms.CheckBox m_chkNose_23;
		private System.Windows.Forms.CheckBox m_chkNose_24;
		private System.Windows.Forms.CheckBox m_chkNose_25;
		private System.Windows.Forms.CheckBox m_chkNose_26;
		private System.Windows.Forms.CheckBox m_chkNose_27;
		private System.Windows.Forms.CheckBox m_chkNose_28;
		private System.Windows.Forms.CheckBox m_chkNose_29;
		private System.Windows.Forms.CheckBox m_chkNose_30;
		private System.Windows.Forms.CheckBox m_chkNose_31;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_1;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_2;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_3;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_4;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_5;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_6;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_7;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_8;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_9;
		private System.Windows.Forms.CheckBox m_chkLarynxGullet_10;
		private System.Windows.Forms.CheckBox m_chkFauces_13;
		private System.Windows.Forms.CheckBox m_chkHead_11;
		private System.Windows.Forms.CheckBox m_chkHead_12;
		private System.Windows.Forms.CheckBox chkLarynxGullet_11;
		private System.Windows.Forms.CheckBox chkLarynxGullet_12;
		private System.Windows.Forms.CheckBox chkLarynxGullet_13;
		private System.Windows.Forms.CheckBox chkLarynxGullet_14;
		private System.Windows.Forms.CheckBox chkLarynxGullet_15;
		private System.Windows.Forms.CheckBox chkLarynxGullet_16;
		private System.Windows.Forms.CheckBox chkLarynxGullet_17;
		private System.Windows.Forms.CheckBox chkLarynxGullet_18;
		private System.Windows.Forms.CheckBox chkLarynxGullet_19;
		private System.Windows.Forms.CheckBox chkLarynxGullet_20;
		private System.Windows.Forms.CheckBox chkLarynxGullet_21;
		private System.Windows.Forms.CheckBox chkFauces_1;
		private System.Windows.Forms.CheckBox chkFauces_2;
		private System.Windows.Forms.CheckBox chkFauces_3;
		private System.Windows.Forms.CheckBox chkFauces_4;
		private System.Windows.Forms.CheckBox chkFauces_5;
		private System.Windows.Forms.CheckBox chkFauces_6;
		private System.Windows.Forms.CheckBox chkFauces_7;
		private System.Windows.Forms.CheckBox chkFauces_8;
		private System.Windows.Forms.CheckBox chkFauces_9;
		private System.Windows.Forms.CheckBox chkFauces_10;
		private System.Windows.Forms.CheckBox chkFauces_11;
		private System.Windows.Forms.CheckBox chkFauces_12;
		private System.Windows.Forms.CheckBox chkFauces_14;
		private System.Windows.Forms.CheckBox chkFauces_15;
		private System.Windows.Forms.CheckBox chkFauces_16;
		private System.Windows.Forms.CheckBox chkFauces_17;
		private System.Windows.Forms.CheckBox chkFauces_18;
		private System.Windows.Forms.CheckBox chkFauces_19;
		private System.Windows.Forms.CheckBox chkFauces_20;
		private System.Windows.Forms.CheckBox chkFauces_21;
		private System.Windows.Forms.CheckBox chkFauces_22;
		private System.Windows.Forms.CheckBox chkFauces_24;
		private System.Windows.Forms.CheckBox chkFauces_23;
		private System.Windows.Forms.CheckBox chkHead_1;
		private System.Windows.Forms.CheckBox chkHead_2;
		private System.Windows.Forms.CheckBox chkHead_3;
		private System.Windows.Forms.CheckBox chkHead_4;
		private System.Windows.Forms.CheckBox chkHead_5;
		private System.Windows.Forms.CheckBox chkHead_6;
		private System.Windows.Forms.CheckBox chkHead_7;
		private System.Windows.Forms.CheckBox chkHead_8;
		private System.Windows.Forms.CheckBox chkHead_9;
		private System.Windows.Forms.CheckBox chkHead_10;
		private System.Windows.Forms.CheckBox chkHead_13;
		private System.Windows.Forms.CheckBox chkHead_14;
		private System.Windows.Forms.CheckBox chkHead_15;
		private System.Windows.Forms.CheckBox chkHead_16;
		private System.Windows.Forms.CheckBox chkHead_17;
		private System.Windows.Forms.CheckBox chkHead_18;
		private System.Windows.Forms.CheckBox m_chkAuris_12;
		private System.Windows.Forms.CheckBox m_chkAuris_38;
		private System.Windows.Forms.CheckBox m_chkAuris_37;
		private System.Windows.Forms.CheckBox m_chkAuris_36;
		private System.Windows.Forms.CheckBox m_chkAuris_35;
		private System.Windows.Forms.CheckBox m_chkAuris_34;
		private System.Windows.Forms.CheckBox m_chkAuris_33;
		private System.Windows.Forms.CheckBox m_chkAuris_32;
		private System.Windows.Forms.CheckBox m_chkAuris_31;
		private System.Windows.Forms.CheckBox m_chkAuris_30;
		private System.Windows.Forms.CheckBox m_chkAuris_29;
		private System.Windows.Forms.CheckBox m_chkAuris_28;
		private System.Windows.Forms.CheckBox m_chkAuris_27;
		private System.Windows.Forms.CheckBox m_chkAuris_26;
		private System.Windows.Forms.CheckBox m_chkAuris_25;
		private System.Windows.Forms.CheckBox m_chkAuris_24;
		private System.Windows.Forms.CheckBox m_chkAuris_23;
		private System.Windows.Forms.CheckBox m_chkAuris_22;
		private System.Windows.Forms.CheckBox m_chkAuris_21;
		private System.Windows.Forms.CheckBox m_chkAuris_20;
		private System.Windows.Forms.CheckBox m_chkAuris_19;
		private System.Windows.Forms.CheckBox m_chkAuris_18;
		private System.Windows.Forms.CheckBox m_chkAuris_17;
		private System.Windows.Forms.CheckBox m_chkAuris_15;
		private System.Windows.Forms.CheckBox m_chkAuris_14;
		private System.Windows.Forms.CheckBox m_chkAuris_13;
		private System.Windows.Forms.CheckBox m_chkAuris_11;
		private System.Windows.Forms.CheckBox m_chkAuris_16;
		private System.Windows.Forms.CheckBox m_chkAuris_10;
		private System.Windows.Forms.CheckBox m_chkAuris_9;
		private System.Windows.Forms.CheckBox m_chkAuris_8;
		private System.Windows.Forms.CheckBox m_chkAuris_7;
		private System.Windows.Forms.CheckBox m_chkAuris_6;
		private System.Windows.Forms.CheckBox m_chkAuris_5;
		private System.Windows.Forms.CheckBox m_chkAuris_4;
		private System.Windows.Forms.CheckBox m_chkAuris_3;
		private System.Windows.Forms.CheckBox m_chkAuris_2;
		private System.Windows.Forms.CheckBox m_chkAuris_1;
		protected System.Windows.Forms.RichTextBox m_txtBeforeDisgone;
		protected System.Windows.Forms.RichTextBox m_txtOperationName;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtWriter;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpSignatoryTime;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.Label lblTalkDoctor;
		protected System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtSign;
		private System.ComponentModel.IContainer components = null;
		#endregion
		private System.Windows.Forms.CheckBox m_chkCheck1;
		private System.Windows.Forms.CheckBox m_chkCheck5;
		private System.Windows.Forms.CheckBox m_chkCheck3;
		private System.Windows.Forms.CheckBox m_chkCheck4;
		private System.Windows.Forms.CheckBox m_chkCheck2;
		private PinkieControls.ButtonXP m_cmdSign;
		private clsCommonUseToolCollection m_objCUTC;
		private Crownwood.Magic.Controls.TabControl tabControl1;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private Crownwood.Magic.Controls.TabPage tabPage2;
		private Crownwood.Magic.Controls.TabPage tabPage3;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private System.Windows.Forms.ImageList imageList1;

		private clsEmployeeSignTool m_objSignTool;

		#region 属性
		protected override enmApproveType m_EnmAppType
		{
			get{return enmApproveType.CaseHistory;}
		}
		protected override string m_StrRecorder_ID
		{
			get
			{
				if(m_txtSign.Tag != null)
					return ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID;
				return "";
			}
		}
		#endregion 属性

		public frmOperationAgreedRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			m_objSignTool = new clsEmployeeSignTool(listView1);
			m_objSignTool.m_mthAddControl(m_txtSign);

			m_objDomain=new clsOperationAgreedRecordDomain();

			m_objPublicDomain = new clsPublicDomain();

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.trvTime
            //                                                             ,m_txtBeforeDisgone
            //                                                             ,m_txtOperationName});	
            
			this.m_txtWriter.LostFocus+=new System.EventHandler(this.m_txtWriter_LostFocus);
            this.m_txtRelationID.LostFocus += new System.EventHandler(this.m_txtRelationID_LostFocus);

		    m_dtsRept = m_dtsInitdtsOperationAgreedDataSet();
//			m_rpdOrderRept = new ReportDocument();
//			m_rpdOrderRept.Load(m_strTemplatePath+"rptOperationAgree.rpt");

			trvTime.HideSelection=false;		
				
			//签名常用值
			m_objCUTC = new clsCommonUseToolCollection(this);
			m_objCUTC.m_mthBindEmployeeSign(new Control[]{this.m_cmdSign  },
				new Control[]{this.m_txtSign},new int[]{1});
		}


		private clsOperationAgreedRecordDomain m_objDomain;

		private clsPublicDomain m_objPublicDomain;

		private clsOperationAgreed m_objAgreed;

        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;

		private clsPatient m_objCurrentPatient;

		/// <summary>
		/// 报告单的报表类
		/// </summary>
		private ReportDocument m_rpdOrderRept;
		private DataSet m_dtsRept;
		private bool blnCanSearch=true; 

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperationAgreedRecord));
            this.m_chkNose_1 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_2 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_3 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_4 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_5 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_6 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_7 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_8 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_9 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_10 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_11 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_12 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_13 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_14 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_15 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_16 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_17 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_18 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_19 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_20 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_21 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_22 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_23 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_24 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_25 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_26 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_27 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_28 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_29 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_30 = new System.Windows.Forms.CheckBox();
            this.m_chkNose_31 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_1 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_2 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_3 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_4 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_5 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_6 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_7 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_8 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_9 = new System.Windows.Forms.CheckBox();
            this.m_chkLarynxGullet_10 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_11 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_12 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_13 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_14 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_15 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_16 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_17 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_18 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_19 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_20 = new System.Windows.Forms.CheckBox();
            this.chkLarynxGullet_21 = new System.Windows.Forms.CheckBox();
            this.chkFauces_1 = new System.Windows.Forms.CheckBox();
            this.chkFauces_2 = new System.Windows.Forms.CheckBox();
            this.chkFauces_3 = new System.Windows.Forms.CheckBox();
            this.chkFauces_4 = new System.Windows.Forms.CheckBox();
            this.chkFauces_5 = new System.Windows.Forms.CheckBox();
            this.chkFauces_6 = new System.Windows.Forms.CheckBox();
            this.chkFauces_7 = new System.Windows.Forms.CheckBox();
            this.chkFauces_8 = new System.Windows.Forms.CheckBox();
            this.chkFauces_9 = new System.Windows.Forms.CheckBox();
            this.chkFauces_10 = new System.Windows.Forms.CheckBox();
            this.chkFauces_11 = new System.Windows.Forms.CheckBox();
            this.chkFauces_12 = new System.Windows.Forms.CheckBox();
            this.m_chkFauces_13 = new System.Windows.Forms.CheckBox();
            this.chkFauces_14 = new System.Windows.Forms.CheckBox();
            this.chkFauces_15 = new System.Windows.Forms.CheckBox();
            this.chkFauces_16 = new System.Windows.Forms.CheckBox();
            this.chkFauces_17 = new System.Windows.Forms.CheckBox();
            this.chkFauces_18 = new System.Windows.Forms.CheckBox();
            this.chkFauces_19 = new System.Windows.Forms.CheckBox();
            this.chkFauces_20 = new System.Windows.Forms.CheckBox();
            this.chkFauces_21 = new System.Windows.Forms.CheckBox();
            this.chkFauces_22 = new System.Windows.Forms.CheckBox();
            this.chkFauces_24 = new System.Windows.Forms.CheckBox();
            this.chkFauces_23 = new System.Windows.Forms.CheckBox();
            this.chkHead_1 = new System.Windows.Forms.CheckBox();
            this.chkHead_2 = new System.Windows.Forms.CheckBox();
            this.chkHead_3 = new System.Windows.Forms.CheckBox();
            this.chkHead_4 = new System.Windows.Forms.CheckBox();
            this.chkHead_5 = new System.Windows.Forms.CheckBox();
            this.chkHead_6 = new System.Windows.Forms.CheckBox();
            this.chkHead_7 = new System.Windows.Forms.CheckBox();
            this.chkHead_8 = new System.Windows.Forms.CheckBox();
            this.chkHead_9 = new System.Windows.Forms.CheckBox();
            this.chkHead_10 = new System.Windows.Forms.CheckBox();
            this.m_chkHead_11 = new System.Windows.Forms.CheckBox();
            this.m_chkHead_12 = new System.Windows.Forms.CheckBox();
            this.chkHead_13 = new System.Windows.Forms.CheckBox();
            this.chkHead_14 = new System.Windows.Forms.CheckBox();
            this.chkHead_15 = new System.Windows.Forms.CheckBox();
            this.chkHead_16 = new System.Windows.Forms.CheckBox();
            this.chkHead_17 = new System.Windows.Forms.CheckBox();
            this.chkHead_18 = new System.Windows.Forms.CheckBox();
            this.lblIdeaAndWrite = new System.Windows.Forms.Label();
            this.lblIdeaAndWriteText = new System.Windows.Forms.Label();
            this.lblWrite = new System.Windows.Forms.Label();
            this.lblRelation = new System.Windows.Forms.Label();
            this.lblRelationSufferer = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblRelationID = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblbefore = new System.Windows.Forms.Label();
            this.lblTheName = new System.Windows.Forms.Label();
            this.m_txtBeforeDisgone = new System.Windows.Forms.RichTextBox();
            this.m_txtOperationName = new System.Windows.Forms.RichTextBox();
            this.m_txtWriter = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtPhone = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtRelation = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtRelationID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_txtRelationSufferer = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_chkAuris_12 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_38 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_37 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_36 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_35 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_34 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_33 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_32 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_31 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_30 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_29 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_28 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_27 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_26 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_25 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_24 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_23 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_22 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_21 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_20 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_19 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_18 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_17 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_15 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_14 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_13 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_11 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_16 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_10 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_9 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_8 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_7 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_6 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_5 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_4 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_3 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_2 = new System.Windows.Forms.CheckBox();
            this.m_chkAuris_1 = new System.Windows.Forms.CheckBox();
            this.dtpSignatoryTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.trvTime = new System.Windows.Forms.TreeView();
            this.lblTalkDoctor = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.m_txtSign = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.m_chkCheck1 = new System.Windows.Forms.CheckBox();
            this.m_chkCheck5 = new System.Windows.Forms.CheckBox();
            this.m_chkCheck3 = new System.Windows.Forms.CheckBox();
            this.m_chkCheck4 = new System.Windows.Forms.CheckBox();
            this.m_chkCheck2 = new System.Windows.Forms.CheckBox();
            this.m_cmdSign = new PinkieControls.ButtonXP();
            this.tabControl1 = new Crownwood.Magic.Controls.TabControl();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.m_pnlNewBase.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(251, 234);
            this.lblSex.Size = new System.Drawing.Size(36, 19);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(236, 226);
            this.lblAge.Size = new System.Drawing.Size(32, 19);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(245, 248);
            this.lblBedNoTitle.Size = new System.Drawing.Size(56, 14);
            this.lblBedNoTitle.Text = "床  号:";
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(236, 242);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(259, 234);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(218, 238);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(259, 231);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(215, 234);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(203, 242);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(76, 32);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(218, 251);
            this.txtInPatientID.Size = new System.Drawing.Size(84, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(203, 245);
            this.m_txtPatientName.Size = new System.Drawing.Size(76, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(230, 239);
            this.m_txtBedNO.Size = new System.Drawing.Size(56, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(230, 251);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(216, 251);
            this.m_lsvPatientName.Size = new System.Drawing.Size(76, 23);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(212, 242);
            this.m_lsvBedNO.Size = new System.Drawing.Size(80, 53);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(218, 251);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(245, 242);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(221, 224);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(248, 231);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(188, 235);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(298, 245);
            this.m_lblForTitle.Text = "耳鼻喉科手术知情同意书";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(451, 239);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(718, 38);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 22);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.m_txtOperationName);
            this.m_pnlNewBase.Controls.Add(this.lblTheName);
            this.m_pnlNewBase.Location = new System.Drawing.Point(0, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(793, 85);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblTheName, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_txtOperationName, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.None;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(192, 29);
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(599, 55);
            this.m_ctlPatientInfo.Visible = false;
            // 
            // m_chkNose_1
            // 
            this.m_chkNose_1.Location = new System.Drawing.Point(4, 32);
            this.m_chkNose_1.Name = "m_chkNose_1";
            this.m_chkNose_1.Size = new System.Drawing.Size(120, 24);
            this.m_chkNose_1.TabIndex = 4200;
            this.m_chkNose_1.Tag = "2";
            this.m_chkNose_1.Text = "1、矫型模脱出";
            // 
            // m_chkNose_2
            // 
            this.m_chkNose_2.Location = new System.Drawing.Point(276, 32);
            this.m_chkNose_2.Name = "m_chkNose_2";
            this.m_chkNose_2.Size = new System.Drawing.Size(120, 24);
            this.m_chkNose_2.TabIndex = 4300;
            this.m_chkNose_2.Tag = "2";
            this.m_chkNose_2.Text = "2、脑脊液鼻漏";
            // 
            // m_chkNose_3
            // 
            this.m_chkNose_3.Location = new System.Drawing.Point(492, 32);
            this.m_chkNose_3.Name = "m_chkNose_3";
            this.m_chkNose_3.Size = new System.Drawing.Size(104, 24);
            this.m_chkNose_3.TabIndex = 4400;
            this.m_chkNose_3.Tag = "2";
            this.m_chkNose_3.Text = "3、闭锁复发";
            // 
            // m_chkNose_4
            // 
            this.m_chkNose_4.Location = new System.Drawing.Point(4, 56);
            this.m_chkNose_4.Name = "m_chkNose_4";
            this.m_chkNose_4.Size = new System.Drawing.Size(124, 24);
            this.m_chkNose_4.TabIndex = 4500;
            this.m_chkNose_4.Tag = "2";
            this.m_chkNose_4.Text = "4、鼻粘膜撕裂";
            // 
            // m_chkNose_5
            // 
            this.m_chkNose_5.Location = new System.Drawing.Point(276, 56);
            this.m_chkNose_5.Name = "m_chkNose_5";
            this.m_chkNose_5.Size = new System.Drawing.Size(152, 24);
            this.m_chkNose_5.TabIndex = 4600;
            this.m_chkNose_5.Tag = "2";
            this.m_chkNose_5.Text = "5、刺入面部软组织";
            // 
            // m_chkNose_6
            // 
            this.m_chkNose_6.Location = new System.Drawing.Point(492, 56);
            this.m_chkNose_6.Name = "m_chkNose_6";
            this.m_chkNose_6.Size = new System.Drawing.Size(128, 24);
            this.m_chkNose_6.TabIndex = 4700;
            this.m_chkNose_6.Tag = "2";
            this.m_chkNose_6.Text = "6、刺破眶下壁";
            // 
            // m_chkNose_7
            // 
            this.m_chkNose_7.Location = new System.Drawing.Point(4, 80);
            this.m_chkNose_7.Name = "m_chkNose_7";
            this.m_chkNose_7.Size = new System.Drawing.Size(152, 24);
            this.m_chkNose_7.TabIndex = 4800;
            this.m_chkNose_7.Tag = "2";
            this.m_chkNose_7.Text = "7、窦内粘膜未穿破";
            // 
            // m_chkNose_8
            // 
            this.m_chkNose_8.Location = new System.Drawing.Point(276, 80);
            this.m_chkNose_8.Name = "m_chkNose_8";
            this.m_chkNose_8.Size = new System.Drawing.Size(176, 24);
            this.m_chkNose_8.TabIndex = 5000;
            this.m_chkNose_8.Tag = "2";
            this.m_chkNose_8.Text = "8、刺入对侧鼻粘膜下层";
            // 
            // m_chkNose_9
            // 
            this.m_chkNose_9.Location = new System.Drawing.Point(492, 80);
            this.m_chkNose_9.Name = "m_chkNose_9";
            this.m_chkNose_9.Size = new System.Drawing.Size(192, 24);
            this.m_chkNose_9.TabIndex = 5100;
            this.m_chkNose_9.Tag = "2";
            this.m_chkNose_9.Text = "9、刺破上颌窦后外壁";
            // 
            // m_chkNose_10
            // 
            this.m_chkNose_10.Location = new System.Drawing.Point(4, 104);
            this.m_chkNose_10.Name = "m_chkNose_10";
            this.m_chkNose_10.Size = new System.Drawing.Size(216, 24);
            this.m_chkNose_10.TabIndex = 5200;
            this.m_chkNose_10.Tag = "2";
            this.m_chkNose_10.Text = "10、窦内有息肉或窦口已封闭";
            // 
            // m_chkNose_11
            // 
            this.m_chkNose_11.Location = new System.Drawing.Point(276, 104);
            this.m_chkNose_11.Name = "m_chkNose_11";
            this.m_chkNose_11.Size = new System.Drawing.Size(216, 24);
            this.m_chkNose_11.TabIndex = 5300;
            this.m_chkNose_11.Tag = "2";
            this.m_chkNose_11.Text = "11、鼻腔粘连和鼻窦进路粘连";
            // 
            // m_chkNose_12
            // 
            this.m_chkNose_12.Location = new System.Drawing.Point(492, 104);
            this.m_chkNose_12.Name = "m_chkNose_12";
            this.m_chkNose_12.Size = new System.Drawing.Size(112, 24);
            this.m_chkNose_12.TabIndex = 5400;
            this.m_chkNose_12.Tag = "2";
            this.m_chkNose_12.Text = "12、视觉障碍";
            // 
            // m_chkNose_13
            // 
            this.m_chkNose_13.Location = new System.Drawing.Point(4, 128);
            this.m_chkNose_13.Name = "m_chkNose_13";
            this.m_chkNose_13.Size = new System.Drawing.Size(136, 24);
            this.m_chkNose_13.TabIndex = 5500;
            this.m_chkNose_13.Tag = "2";
            this.m_chkNose_13.Text = "13、鼻中隔穿孔";
            // 
            // m_chkNose_14
            // 
            this.m_chkNose_14.Location = new System.Drawing.Point(276, 128);
            this.m_chkNose_14.Name = "m_chkNose_14";
            this.m_chkNose_14.Size = new System.Drawing.Size(160, 24);
            this.m_chkNose_14.TabIndex = 5600;
            this.m_chkNose_14.Tag = "2";
            this.m_chkNose_14.Text = "14、面部肿胀及疼痛";
            // 
            // m_chkNose_15
            // 
            this.m_chkNose_15.Location = new System.Drawing.Point(492, 128);
            this.m_chkNose_15.Name = "m_chkNose_15";
            this.m_chkNose_15.Size = new System.Drawing.Size(112, 24);
            this.m_chkNose_15.TabIndex = 5700;
            this.m_chkNose_15.Tag = "2";
            this.m_chkNose_15.Text = "15、术侧上唇";
            // 
            // m_chkNose_16
            // 
            this.m_chkNose_16.Location = new System.Drawing.Point(4, 152);
            this.m_chkNose_16.Name = "m_chkNose_16";
            this.m_chkNose_16.Size = new System.Drawing.Size(272, 24);
            this.m_chkNose_16.TabIndex = 5800;
            this.m_chkNose_16.Tag = "2";
            this.m_chkNose_16.Text = "16、面颊及牙龈麻木感和上列牙齿酸痛";
            // 
            // m_chkNose_17
            // 
            this.m_chkNose_17.Location = new System.Drawing.Point(276, 152);
            this.m_chkNose_17.Name = "m_chkNose_17";
            this.m_chkNose_17.Size = new System.Drawing.Size(160, 24);
            this.m_chkNose_17.TabIndex = 5900;
            this.m_chkNose_17.Tag = "2";
            this.m_chkNose_17.Text = "17、上颌窦牙龈瘘管";
            // 
            // m_chkNose_18
            // 
            this.m_chkNose_18.Location = new System.Drawing.Point(492, 152);
            this.m_chkNose_18.Name = "m_chkNose_18";
            this.m_chkNose_18.Size = new System.Drawing.Size(240, 24);
            this.m_chkNose_18.TabIndex = 6000;
            this.m_chkNose_18.Tag = "2";
            this.m_chkNose_18.Text = "18、面颊脓肿及上颌窦内隐性脓肿";
            // 
            // m_chkNose_19
            // 
            this.m_chkNose_19.Location = new System.Drawing.Point(4, 176);
            this.m_chkNose_19.Name = "m_chkNose_19";
            this.m_chkNose_19.Size = new System.Drawing.Size(224, 24);
            this.m_chkNose_19.TabIndex = 6100;
            this.m_chkNose_19.Tag = "2";
            this.m_chkNose_19.Text = "19、眶内蜂窝织炎及眶内脓肿";
            // 
            // m_chkNose_20
            // 
            this.m_chkNose_20.Location = new System.Drawing.Point(276, 176);
            this.m_chkNose_20.Name = "m_chkNose_20";
            this.m_chkNose_20.Size = new System.Drawing.Size(140, 24);
            this.m_chkNose_20.TabIndex = 6200;
            this.m_chkNose_20.Tag = "2";
            this.m_chkNose_20.Text = "20、蝶腭动脉出血";
            // 
            // m_chkNose_21
            // 
            this.m_chkNose_21.Location = new System.Drawing.Point(492, 176);
            this.m_chkNose_21.Name = "m_chkNose_21";
            this.m_chkNose_21.Size = new System.Drawing.Size(96, 24);
            this.m_chkNose_21.TabIndex = 6300;
            this.m_chkNose_21.Tag = "2";
            this.m_chkNose_21.Text = "21、泪溢";
            // 
            // m_chkNose_22
            // 
            this.m_chkNose_22.Location = new System.Drawing.Point(4, 200);
            this.m_chkNose_22.Name = "m_chkNose_22";
            this.m_chkNose_22.Size = new System.Drawing.Size(88, 24);
            this.m_chkNose_22.TabIndex = 6400;
            this.m_chkNose_22.Tag = "2";
            this.m_chkNose_22.Text = "22、复视";
            // 
            // m_chkNose_23
            // 
            this.m_chkNose_23.Location = new System.Drawing.Point(276, 200);
            this.m_chkNose_23.Name = "m_chkNose_23";
            this.m_chkNose_23.Size = new System.Drawing.Size(128, 24);
            this.m_chkNose_23.TabIndex = 6500;
            this.m_chkNose_23.Tag = "2";
            this.m_chkNose_23.Text = "23、眶上神经痛";
            // 
            // m_chkNose_24
            // 
            this.m_chkNose_24.Location = new System.Drawing.Point(492, 200);
            this.m_chkNose_24.Name = "m_chkNose_24";
            this.m_chkNose_24.Size = new System.Drawing.Size(136, 24);
            this.m_chkNose_24.TabIndex = 6600;
            this.m_chkNose_24.Tag = "2";
            this.m_chkNose_24.Text = "24、鼻前庭狭窄";
            // 
            // m_chkNose_25
            // 
            this.m_chkNose_25.Location = new System.Drawing.Point(4, 224);
            this.m_chkNose_25.Name = "m_chkNose_25";
            this.m_chkNose_25.Size = new System.Drawing.Size(160, 24);
            this.m_chkNose_25.TabIndex = 6700;
            this.m_chkNose_25.Tag = "2";
            this.m_chkNose_25.Text = "25、上颌窦牙龈瘘管";
            // 
            // m_chkNose_26
            // 
            this.m_chkNose_26.Location = new System.Drawing.Point(276, 224);
            this.m_chkNose_26.Name = "m_chkNose_26";
            this.m_chkNose_26.Size = new System.Drawing.Size(168, 24);
            this.m_chkNose_26.TabIndex = 6800;
            this.m_chkNose_26.Tag = "2";
            this.m_chkNose_26.Text = "26、眶壁骨膜下脓肿";
            // 
            // m_chkNose_27
            // 
            this.m_chkNose_27.Location = new System.Drawing.Point(492, 224);
            this.m_chkNose_27.Name = "m_chkNose_27";
            this.m_chkNose_27.Size = new System.Drawing.Size(256, 24);
            this.m_chkNose_27.TabIndex = 6900;
            this.m_chkNose_27.Tag = "2";
            this.m_chkNose_27.Text = "27、眶壁血栓性静脉炎和静脉周围炎";
            // 
            // m_chkNose_28
            // 
            this.m_chkNose_28.Location = new System.Drawing.Point(4, 248);
            this.m_chkNose_28.Name = "m_chkNose_28";
            this.m_chkNose_28.Size = new System.Drawing.Size(144, 24);
            this.m_chkNose_28.TabIndex = 7000;
            this.m_chkNose_28.Tag = "2";
            this.m_chkNose_28.Text = "28、球后视神经炎";
            // 
            // m_chkNose_29
            // 
            this.m_chkNose_29.Location = new System.Drawing.Point(276, 248);
            this.m_chkNose_29.Name = "m_chkNose_29";
            this.m_chkNose_29.Size = new System.Drawing.Size(128, 24);
            this.m_chkNose_29.TabIndex = 7100;
            this.m_chkNose_29.Tag = "2";
            this.m_chkNose_29.Text = "29、面神经麻痹";
            // 
            // m_chkNose_30
            // 
            this.m_chkNose_30.Location = new System.Drawing.Point(492, 248);
            this.m_chkNose_30.Name = "m_chkNose_30";
            this.m_chkNose_30.Size = new System.Drawing.Size(88, 24);
            this.m_chkNose_30.TabIndex = 7200;
            this.m_chkNose_30.Tag = "2";
            this.m_chkNose_30.Text = "30、气脑";
            // 
            // m_chkNose_31
            // 
            this.m_chkNose_31.Location = new System.Drawing.Point(4, 268);
            this.m_chkNose_31.Name = "m_chkNose_31";
            this.m_chkNose_31.Size = new System.Drawing.Size(184, 24);
            this.m_chkNose_31.TabIndex = 7300;
            this.m_chkNose_31.Tag = "2";
            this.m_chkNose_31.Text = "31、颈内动脉破裂大出血";
            // 
            // m_chkLarynxGullet_1
            // 
            this.m_chkLarynxGullet_1.Location = new System.Drawing.Point(4, 32);
            this.m_chkLarynxGullet_1.Name = "m_chkLarynxGullet_1";
            this.m_chkLarynxGullet_1.Size = new System.Drawing.Size(88, 24);
            this.m_chkLarynxGullet_1.TabIndex = 7400;
            this.m_chkLarynxGullet_1.Tag = "3";
            this.m_chkLarynxGullet_1.Text = "1、失语";
            // 
            // m_chkLarynxGullet_2
            // 
            this.m_chkLarynxGullet_2.Location = new System.Drawing.Point(194, 32);
            this.m_chkLarynxGullet_2.Name = "m_chkLarynxGullet_2";
            this.m_chkLarynxGullet_2.Size = new System.Drawing.Size(104, 24);
            this.m_chkLarynxGullet_2.TabIndex = 7500;
            this.m_chkLarynxGullet_2.Tag = "3";
            this.m_chkLarynxGullet_2.Text = "2、喉痉挛";
            // 
            // m_chkLarynxGullet_3
            // 
            this.m_chkLarynxGullet_3.Location = new System.Drawing.Point(384, 32);
            this.m_chkLarynxGullet_3.Name = "m_chkLarynxGullet_3";
            this.m_chkLarynxGullet_3.Size = new System.Drawing.Size(104, 24);
            this.m_chkLarynxGullet_3.TabIndex = 7600;
            this.m_chkLarynxGullet_3.Tag = "3";
            this.m_chkLarynxGullet_3.Text = "3、声带水肿";
            // 
            // m_chkLarynxGullet_4
            // 
            this.m_chkLarynxGullet_4.Location = new System.Drawing.Point(574, 32);
            this.m_chkLarynxGullet_4.Name = "m_chkLarynxGullet_4";
            this.m_chkLarynxGullet_4.Size = new System.Drawing.Size(80, 24);
            this.m_chkLarynxGullet_4.TabIndex = 7700;
            this.m_chkLarynxGullet_4.Tag = "3";
            this.m_chkLarynxGullet_4.Text = "4、声嘶";
            // 
            // m_chkLarynxGullet_5
            // 
            this.m_chkLarynxGullet_5.Location = new System.Drawing.Point(4, 56);
            this.m_chkLarynxGullet_5.Name = "m_chkLarynxGullet_5";
            this.m_chkLarynxGullet_5.Size = new System.Drawing.Size(112, 24);
            this.m_chkLarynxGullet_5.TabIndex = 7800;
            this.m_chkLarynxGullet_5.Tag = "3";
            this.m_chkLarynxGullet_5.Text = "5、声带麻痹";
            // 
            // m_chkLarynxGullet_6
            // 
            this.m_chkLarynxGullet_6.Location = new System.Drawing.Point(194, 56);
            this.m_chkLarynxGullet_6.Name = "m_chkLarynxGullet_6";
            this.m_chkLarynxGullet_6.Size = new System.Drawing.Size(160, 24);
            this.m_chkLarynxGullet_6.TabIndex = 7900;
            this.m_chkLarynxGullet_6.Tag = "3";
            this.m_chkLarynxGullet_6.Text = "6、喉气管支气管炎";
            // 
            // m_chkLarynxGullet_7
            // 
            this.m_chkLarynxGullet_7.Location = new System.Drawing.Point(384, 56);
            this.m_chkLarynxGullet_7.Name = "m_chkLarynxGullet_7";
            this.m_chkLarynxGullet_7.Size = new System.Drawing.Size(168, 24);
            this.m_chkLarynxGullet_7.TabIndex = 8000;
            this.m_chkLarynxGullet_7.Tag = "3";
            this.m_chkLarynxGullet_7.Text = "7、咽喉气管食道狭窄";
            // 
            // m_chkLarynxGullet_8
            // 
            this.m_chkLarynxGullet_8.Location = new System.Drawing.Point(574, 56);
            this.m_chkLarynxGullet_8.Name = "m_chkLarynxGullet_8";
            this.m_chkLarynxGullet_8.Size = new System.Drawing.Size(120, 24);
            this.m_chkLarynxGullet_8.TabIndex = 8100;
            this.m_chkLarynxGullet_8.Tag = "3";
            this.m_chkLarynxGullet_8.Text = "8、套管脱出";
            // 
            // m_chkLarynxGullet_9
            // 
            this.m_chkLarynxGullet_9.Location = new System.Drawing.Point(4, 80);
            this.m_chkLarynxGullet_9.Name = "m_chkLarynxGullet_9";
            this.m_chkLarynxGullet_9.Size = new System.Drawing.Size(152, 24);
            this.m_chkLarynxGullet_9.TabIndex = 8200;
            this.m_chkLarynxGullet_9.Tag = "3";
            this.m_chkLarynxGullet_9.Text = "9、纵隔气肿及气胸";
            // 
            // m_chkLarynxGullet_10
            // 
            this.m_chkLarynxGullet_10.Location = new System.Drawing.Point(194, 80);
            this.m_chkLarynxGullet_10.Name = "m_chkLarynxGullet_10";
            this.m_chkLarynxGullet_10.Size = new System.Drawing.Size(136, 24);
            this.m_chkLarynxGullet_10.TabIndex = 8300;
            this.m_chkLarynxGullet_10.Tag = "3";
            this.m_chkLarynxGullet_10.Text = "10、急性肺水肿";
            // 
            // chkLarynxGullet_11
            // 
            this.chkLarynxGullet_11.Location = new System.Drawing.Point(384, 80);
            this.chkLarynxGullet_11.Name = "chkLarynxGullet_11";
            this.chkLarynxGullet_11.Size = new System.Drawing.Size(112, 24);
            this.chkLarynxGullet_11.TabIndex = 8400;
            this.chkLarynxGullet_11.Tag = "3";
            this.chkLarynxGullet_11.Text = "11、呼吸骤停";
            // 
            // chkLarynxGullet_12
            // 
            this.chkLarynxGullet_12.Location = new System.Drawing.Point(574, 80);
            this.chkLarynxGullet_12.Name = "chkLarynxGullet_12";
            this.chkLarynxGullet_12.Size = new System.Drawing.Size(170, 24);
            this.chkLarynxGullet_12.TabIndex = 8500;
            this.chkLarynxGullet_12.Tag = "3";
            this.chkLarynxGullet_12.Text = "12、咽气管食管瘘形成";
            // 
            // chkLarynxGullet_13
            // 
            this.chkLarynxGullet_13.Location = new System.Drawing.Point(4, 104);
            this.chkLarynxGullet_13.Name = "chkLarynxGullet_13";
            this.chkLarynxGullet_13.Size = new System.Drawing.Size(168, 24);
            this.chkLarynxGullet_13.TabIndex = 8600;
            this.chkLarynxGullet_13.Tag = "3";
            this.chkLarynxGullet_13.Text = "13、喉内肉芽形成";
            // 
            // chkLarynxGullet_14
            // 
            this.chkLarynxGullet_14.Location = new System.Drawing.Point(194, 104);
            this.chkLarynxGullet_14.Name = "chkLarynxGullet_14";
            this.chkLarynxGullet_14.Size = new System.Drawing.Size(152, 24);
            this.chkLarynxGullet_14.TabIndex = 8700;
            this.chkLarynxGullet_14.Tag = "3";
            this.chkLarynxGullet_14.Text = "14、空气栓塞";
            // 
            // chkLarynxGullet_15
            // 
            this.chkLarynxGullet_15.Location = new System.Drawing.Point(384, 104);
            this.chkLarynxGullet_15.Name = "chkLarynxGullet_15";
            this.chkLarynxGullet_15.Size = new System.Drawing.Size(112, 24);
            this.chkLarynxGullet_15.TabIndex = 8800;
            this.chkLarynxGullet_15.Tag = "3";
            this.chkLarynxGullet_15.Text = "15、咯血";
            // 
            // chkLarynxGullet_16
            // 
            this.chkLarynxGullet_16.Location = new System.Drawing.Point(574, 104);
            this.chkLarynxGullet_16.Name = "chkLarynxGullet_16";
            this.chkLarynxGullet_16.Size = new System.Drawing.Size(160, 24);
            this.chkLarynxGullet_16.TabIndex = 8850;
            this.chkLarynxGullet_16.Tag = "3";
            this.chkLarynxGullet_16.Text = "16、切牙损伤及脱落";
            // 
            // chkLarynxGullet_17
            // 
            this.chkLarynxGullet_17.Location = new System.Drawing.Point(4, 128);
            this.chkLarynxGullet_17.Name = "chkLarynxGullet_17";
            this.chkLarynxGullet_17.Size = new System.Drawing.Size(112, 24);
            this.chkLarynxGullet_17.TabIndex = 8900;
            this.chkLarynxGullet_17.Tag = "3";
            this.chkLarynxGullet_17.Text = "17、食管穿孔";
            // 
            // chkLarynxGullet_18
            // 
            this.chkLarynxGullet_18.Location = new System.Drawing.Point(194, 128);
            this.chkLarynxGullet_18.Name = "chkLarynxGullet_18";
            this.chkLarynxGullet_18.Size = new System.Drawing.Size(120, 24);
            this.chkLarynxGullet_18.TabIndex = 9000;
            this.chkLarynxGullet_18.Tag = "3";
            this.chkLarynxGullet_18.Text = "18、喉腐蚀伤";
            // 
            // chkLarynxGullet_19
            // 
            this.chkLarynxGullet_19.Location = new System.Drawing.Point(384, 128);
            this.chkLarynxGullet_19.Name = "chkLarynxGullet_19";
            this.chkLarynxGullet_19.Size = new System.Drawing.Size(128, 24);
            this.chkLarynxGullet_19.TabIndex = 9100;
            this.chkLarynxGullet_19.Tag = "3";
            this.chkLarynxGullet_19.Text = "19、胃肠穿孔";
            // 
            // chkLarynxGullet_20
            // 
            this.chkLarynxGullet_20.Location = new System.Drawing.Point(574, 128);
            this.chkLarynxGullet_20.Name = "chkLarynxGullet_20";
            this.chkLarynxGullet_20.Size = new System.Drawing.Size(160, 24);
            this.chkLarynxGullet_20.TabIndex = 9200;
            this.chkLarynxGullet_20.Tag = "3";
            this.chkLarynxGullet_20.Text = "20、胃瘢痕性挛缩";
            // 
            // chkLarynxGullet_21
            // 
            this.chkLarynxGullet_21.Location = new System.Drawing.Point(4, 152);
            this.chkLarynxGullet_21.Name = "chkLarynxGullet_21";
            this.chkLarynxGullet_21.Size = new System.Drawing.Size(120, 24);
            this.chkLarynxGullet_21.TabIndex = 9300;
            this.chkLarynxGullet_21.Tag = "3";
            this.chkLarynxGullet_21.Text = "21、幽门狭窄";
            // 
            // chkFauces_1
            // 
            this.chkFauces_1.Location = new System.Drawing.Point(4, 32);
            this.chkFauces_1.Name = "chkFauces_1";
            this.chkFauces_1.Size = new System.Drawing.Size(216, 24);
            this.chkFauces_1.TabIndex = 9400;
            this.chkFauces_1.Tag = "4";
            this.chkFauces_1.Text = "1、上、下呼吸道的急性炎症";
            // 
            // chkFauces_2
            // 
            this.chkFauces_2.Location = new System.Drawing.Point(204, 32);
            this.chkFauces_2.Name = "chkFauces_2";
            this.chkFauces_2.Size = new System.Drawing.Size(136, 24);
            this.chkFauces_2.TabIndex = 9500;
            this.chkFauces_2.Tag = "4";
            this.chkFauces_2.Text = "2、咽后壁脓肿";
            // 
            // chkFauces_3
            // 
            this.chkFauces_3.Location = new System.Drawing.Point(352, 32);
            this.chkFauces_3.Name = "chkFauces_3";
            this.chkFauces_3.Size = new System.Drawing.Size(160, 24);
            this.chkFauces_3.TabIndex = 9600;
            this.chkFauces_3.Tag = "4";
            this.chkFauces_3.Text = "3、咽鼓管咽口损伤";
            // 
            // chkFauces_4
            // 
            this.chkFauces_4.Location = new System.Drawing.Point(520, 32);
            this.chkFauces_4.Name = "chkFauces_4";
            this.chkFauces_4.Size = new System.Drawing.Size(180, 24);
            this.chkFauces_4.TabIndex = 9700;
            this.chkFauces_4.Tag = "4";
            this.chkFauces_4.Text = "4、咽壁损伤及软腭轻瘫";
            // 
            // chkFauces_5
            // 
            this.chkFauces_5.Location = new System.Drawing.Point(4, 56);
            this.chkFauces_5.Name = "chkFauces_5";
            this.chkFauces_5.Size = new System.Drawing.Size(96, 24);
            this.chkFauces_5.TabIndex = 9800;
            this.chkFauces_5.Tag = "4";
            this.chkFauces_5.Text = "5、肺脓肿";
            // 
            // chkFauces_6
            // 
            this.chkFauces_6.Location = new System.Drawing.Point(204, 56);
            this.chkFauces_6.Name = "chkFauces_6";
            this.chkFauces_6.Size = new System.Drawing.Size(104, 24);
            this.chkFauces_6.TabIndex = 9900;
            this.chkFauces_6.Tag = "4";
            this.chkFauces_6.Text = "6、心包炎";
            // 
            // chkFauces_7
            // 
            this.chkFauces_7.Location = new System.Drawing.Point(352, 56);
            this.chkFauces_7.Name = "chkFauces_7";
            this.chkFauces_7.Size = new System.Drawing.Size(96, 24);
            this.chkFauces_7.TabIndex = 10000;
            this.chkFauces_7.Tag = "4";
            this.chkFauces_7.Text = "7、胸膜炎";
            // 
            // chkFauces_8
            // 
            this.chkFauces_8.Location = new System.Drawing.Point(520, 56);
            this.chkFauces_8.Name = "chkFauces_8";
            this.chkFauces_8.Size = new System.Drawing.Size(96, 24);
            this.chkFauces_8.TabIndex = 10100;
            this.chkFauces_8.Tag = "4";
            this.chkFauces_8.Text = "8、风湿热";
            // 
            // chkFauces_9
            // 
            this.chkFauces_9.Location = new System.Drawing.Point(4, 80);
            this.chkFauces_9.Name = "chkFauces_9";
            this.chkFauces_9.Size = new System.Drawing.Size(136, 24);
            this.chkFauces_9.TabIndex = 10200;
            this.chkFauces_9.Tag = "4";
            this.chkFauces_9.Text = "9、扃桃体周脓肿";
            // 
            // chkFauces_10
            // 
            this.chkFauces_10.Location = new System.Drawing.Point(204, 80);
            this.chkFauces_10.Name = "chkFauces_10";
            this.chkFauces_10.Size = new System.Drawing.Size(120, 24);
            this.chkFauces_10.TabIndex = 10300;
            this.chkFauces_10.Tag = "4";
            this.chkFauces_10.Text = "10、咽旁脓肿";
            // 
            // chkFauces_11
            // 
            this.chkFauces_11.Location = new System.Drawing.Point(352, 80);
            this.chkFauces_11.Name = "chkFauces_11";
            this.chkFauces_11.Size = new System.Drawing.Size(112, 24);
            this.chkFauces_11.TabIndex = 10400;
            this.chkFauces_11.Tag = "4";
            this.chkFauces_11.Text = "11、咽后脓肿";
            // 
            // chkFauces_12
            // 
            this.chkFauces_12.Location = new System.Drawing.Point(520, 80);
            this.chkFauces_12.Name = "chkFauces_12";
            this.chkFauces_12.Size = new System.Drawing.Size(136, 24);
            this.chkFauces_12.TabIndex = 10500;
            this.chkFauces_12.Tag = "4";
            this.chkFauces_12.Text = "12、急性关节炎";
            // 
            // m_chkFauces_13
            // 
            this.m_chkFauces_13.Location = new System.Drawing.Point(4, 104);
            this.m_chkFauces_13.Name = "m_chkFauces_13";
            this.m_chkFauces_13.Size = new System.Drawing.Size(144, 24);
            this.m_chkFauces_13.TabIndex = 10600;
            this.m_chkFauces_13.Tag = "4";
            this.m_chkFauces_13.Text = "13、急性心内膜炎";
            // 
            // chkFauces_14
            // 
            this.chkFauces_14.Location = new System.Drawing.Point(204, 104);
            this.chkFauces_14.Name = "chkFauces_14";
            this.chkFauces_14.Size = new System.Drawing.Size(136, 24);
            this.chkFauces_14.TabIndex = 10700;
            this.chkFauces_14.Tag = "4";
            this.chkFauces_14.Text = "14、急性尿道炎";
            // 
            // chkFauces_15
            // 
            this.chkFauces_15.Location = new System.Drawing.Point(352, 104);
            this.chkFauces_15.Name = "chkFauces_15";
            this.chkFauces_15.Size = new System.Drawing.Size(136, 24);
            this.chkFauces_15.TabIndex = 10800;
            this.chkFauces_15.Tag = "4";
            this.chkFauces_15.Text = "15、急性睾丸炎";
            // 
            // chkFauces_16
            // 
            this.chkFauces_16.Location = new System.Drawing.Point(520, 104);
            this.chkFauces_16.Name = "chkFauces_16";
            this.chkFauces_16.Size = new System.Drawing.Size(160, 24);
            this.chkFauces_16.TabIndex = 10900;
            this.chkFauces_16.Tag = "4";
            this.chkFauces_16.Text = "16、亚急性甲状腺炎";
            // 
            // chkFauces_17
            // 
            this.chkFauces_17.Location = new System.Drawing.Point(4, 128);
            this.chkFauces_17.Name = "chkFauces_17";
            this.chkFauces_17.Size = new System.Drawing.Size(128, 24);
            this.chkFauces_17.TabIndex = 11000;
            this.chkFauces_17.Tag = "4";
            this.chkFauces_17.Text = "17、皮下气肿";
            // 
            // chkFauces_18
            // 
            this.chkFauces_18.Location = new System.Drawing.Point(204, 128);
            this.chkFauces_18.Name = "chkFauces_18";
            this.chkFauces_18.Size = new System.Drawing.Size(104, 24);
            this.chkFauces_18.TabIndex = 11100;
            this.chkFauces_18.Tag = "4";
            this.chkFauces_18.Text = "18、肺不张";
            // 
            // chkFauces_19
            // 
            this.chkFauces_19.Location = new System.Drawing.Point(352, 128);
            this.chkFauces_19.Name = "chkFauces_19";
            this.chkFauces_19.Size = new System.Drawing.Size(144, 24);
            this.chkFauces_19.TabIndex = 11200;
            this.chkFauces_19.Tag = "4";
            this.chkFauces_19.Text = "19、颈内静脉血栓";
            // 
            // chkFauces_20
            // 
            this.chkFauces_20.Location = new System.Drawing.Point(520, 128);
            this.chkFauces_20.Name = "chkFauces_20";
            this.chkFauces_20.Size = new System.Drawing.Size(176, 24);
            this.chkFauces_20.TabIndex = 11300;
            this.chkFauces_20.Tag = "4";
            this.chkFauces_20.Text = "20、颈部坏死性筋膜炎";
            // 
            // chkFauces_21
            // 
            this.chkFauces_21.Location = new System.Drawing.Point(4, 152);
            this.chkFauces_21.Name = "chkFauces_21";
            this.chkFauces_21.Size = new System.Drawing.Size(184, 24);
            this.chkFauces_21.TabIndex = 11400;
            this.chkFauces_21.Tag = "4";
            this.chkFauces_21.Text = "21、下行性坏死性纵隔炎";
            // 
            // chkFauces_22
            // 
            this.chkFauces_22.Location = new System.Drawing.Point(204, 152);
            this.chkFauces_22.Name = "chkFauces_22";
            this.chkFauces_22.Size = new System.Drawing.Size(112, 24);
            this.chkFauces_22.TabIndex = 11500;
            this.chkFauces_22.Tag = "4";
            this.chkFauces_22.Text = "22、颈部强直";
            // 
            // chkFauces_24
            // 
            this.chkFauces_24.Location = new System.Drawing.Point(520, 152);
            this.chkFauces_24.Name = "chkFauces_24";
            this.chkFauces_24.Size = new System.Drawing.Size(224, 24);
            this.chkFauces_24.TabIndex = 11700;
            this.chkFauces_24.Tag = "4";
            this.chkFauces_24.Text = "24、咽-迷走反射引起心跳骤停";
            // 
            // chkFauces_23
            // 
            this.chkFauces_23.Location = new System.Drawing.Point(352, 152);
            this.chkFauces_23.Name = "chkFauces_23";
            this.chkFauces_23.Size = new System.Drawing.Size(160, 24);
            this.chkFauces_23.TabIndex = 11600;
            this.chkFauces_23.Tag = "4";
            this.chkFauces_23.Text = "23、软腭及咽肌麻痹";
            // 
            // chkHead_1
            // 
            this.chkHead_1.Location = new System.Drawing.Point(4, 32);
            this.chkHead_1.Name = "chkHead_1";
            this.chkHead_1.Size = new System.Drawing.Size(120, 24);
            this.chkHead_1.TabIndex = 11800;
            this.chkHead_1.Tag = "5";
            this.chkHead_1.Text = "1、乳糜漏";
            // 
            // chkHead_2
            // 
            this.chkHead_2.Location = new System.Drawing.Point(184, 32);
            this.chkHead_2.Name = "chkHead_2";
            this.chkHead_2.Size = new System.Drawing.Size(120, 24);
            this.chkHead_2.TabIndex = 11900;
            this.chkHead_2.Tag = "5";
            this.chkHead_2.Text = "2、腮腺瘘";
            // 
            // chkHead_3
            // 
            this.chkHead_3.Location = new System.Drawing.Point(384, 32);
            this.chkHead_3.Name = "chkHead_3";
            this.chkHead_3.Size = new System.Drawing.Size(136, 24);
            this.chkHead_3.TabIndex = 12000;
            this.chkHead_3.Tag = "5";
            this.chkHead_3.Text = "3、颈总动脉破裂";
            // 
            // chkHead_4
            // 
            this.chkHead_4.Location = new System.Drawing.Point(548, 32);
            this.chkHead_4.Name = "chkHead_4";
            this.chkHead_4.Size = new System.Drawing.Size(144, 24);
            this.chkHead_4.TabIndex = 12100;
            this.chkHead_4.Tag = "5";
            this.chkHead_4.Text = "4、舌下神经麻痹";
            // 
            // chkHead_5
            // 
            this.chkHead_5.Location = new System.Drawing.Point(4, 56);
            this.chkHead_5.Name = "chkHead_5";
            this.chkHead_5.Size = new System.Drawing.Size(120, 24);
            this.chkHead_5.TabIndex = 12200;
            this.chkHead_5.Tag = "5";
            this.chkHead_5.Text = "5、神经损伤";
            // 
            // chkHead_6
            // 
            this.chkHead_6.Location = new System.Drawing.Point(184, 56);
            this.chkHead_6.Name = "chkHead_6";
            this.chkHead_6.Size = new System.Drawing.Size(120, 24);
            this.chkHead_6.TabIndex = 12300;
            this.chkHead_6.Tag = "5";
            this.chkHead_6.Text = "6、颅内血肿";
            // 
            // chkHead_7
            // 
            this.chkHead_7.Location = new System.Drawing.Point(384, 56);
            this.chkHead_7.Name = "chkHead_7";
            this.chkHead_7.Size = new System.Drawing.Size(120, 24);
            this.chkHead_7.TabIndex = 12400;
            this.chkHead_7.Tag = "5";
            this.chkHead_7.Text = "7、脑水肿";
            // 
            // chkHead_8
            // 
            this.chkHead_8.Location = new System.Drawing.Point(548, 56);
            this.chkHead_8.Name = "chkHead_8";
            this.chkHead_8.Size = new System.Drawing.Size(120, 24);
            this.chkHead_8.TabIndex = 12500;
            this.chkHead_8.Tag = "5";
            this.chkHead_8.Text = "8、纵隔气肿";
            // 
            // chkHead_9
            // 
            this.chkHead_9.Location = new System.Drawing.Point(4, 80);
            this.chkHead_9.Name = "chkHead_9";
            this.chkHead_9.Size = new System.Drawing.Size(176, 24);
            this.chkHead_9.TabIndex = 12600;
            this.chkHead_9.Tag = "5";
            this.chkHead_9.Text = "9、自发性眼震及眩晕";
            // 
            // chkHead_10
            // 
            this.chkHead_10.Location = new System.Drawing.Point(184, 80);
            this.chkHead_10.Name = "chkHead_10";
            this.chkHead_10.Size = new System.Drawing.Size(184, 24);
            this.chkHead_10.TabIndex = 12700;
            this.chkHead_10.Tag = "5";
            this.chkHead_10.Text = "10、同侧Horner综合症";
            // 
            // m_chkHead_11
            // 
            this.m_chkHead_11.Location = new System.Drawing.Point(384, 80);
            this.m_chkHead_11.Name = "m_chkHead_11";
            this.m_chkHead_11.Size = new System.Drawing.Size(144, 24);
            this.m_chkHead_11.TabIndex = 12800;
            this.m_chkHead_11.Tag = "5";
            this.m_chkHead_11.Text = "11、手臂神经痛";
            // 
            // m_chkHead_12
            // 
            this.m_chkHead_12.Location = new System.Drawing.Point(548, 80);
            this.m_chkHead_12.Name = "m_chkHead_12";
            this.m_chkHead_12.Size = new System.Drawing.Size(120, 24);
            this.m_chkHead_12.TabIndex = 12850;
            this.m_chkHead_12.Tag = "5";
            this.m_chkHead_12.Text = "12、膈神经痛";
            // 
            // chkHead_13
            // 
            this.chkHead_13.Location = new System.Drawing.Point(4, 104);
            this.chkHead_13.Name = "chkHead_13";
            this.chkHead_13.Size = new System.Drawing.Size(120, 24);
            this.chkHead_13.TabIndex = 12900;
            this.chkHead_13.Tag = "5";
            this.chkHead_13.Text = "13、吞咽困难";
            // 
            // chkHead_14
            // 
            this.chkHead_14.Location = new System.Drawing.Point(184, 104);
            this.chkHead_14.Name = "chkHead_14";
            this.chkHead_14.Size = new System.Drawing.Size(120, 24);
            this.chkHead_14.TabIndex = 13000;
            this.chkHead_14.Tag = "5";
            this.chkHead_14.Text = "14、喉阻塞";
            // 
            // chkHead_15
            // 
            this.chkHead_15.Location = new System.Drawing.Point(384, 104);
            this.chkHead_15.Name = "chkHead_15";
            this.chkHead_15.Size = new System.Drawing.Size(120, 24);
            this.chkHead_15.TabIndex = 13100;
            this.chkHead_15.Tag = "5";
            this.chkHead_15.Text = "15、呼吸困难";
            // 
            // chkHead_16
            // 
            this.chkHead_16.Location = new System.Drawing.Point(548, 104);
            this.chkHead_16.Name = "chkHead_16";
            this.chkHead_16.Size = new System.Drawing.Size(200, 24);
            this.chkHead_16.TabIndex = 13200;
            this.chkHead_16.Tag = "5";
            this.chkHead_16.Text = "16、颈交感神经麻痹综合症";
            // 
            // chkHead_17
            // 
            this.chkHead_17.Location = new System.Drawing.Point(4, 128);
            this.chkHead_17.Name = "chkHead_17";
            this.chkHead_17.Size = new System.Drawing.Size(120, 24);
            this.chkHead_17.TabIndex = 13300;
            this.chkHead_17.Tag = "5";
            this.chkHead_17.Text = "17、皮肤坏死";
            // 
            // chkHead_18
            // 
            this.chkHead_18.Location = new System.Drawing.Point(184, 128);
            this.chkHead_18.Name = "chkHead_18";
            this.chkHead_18.Size = new System.Drawing.Size(152, 24);
            this.chkHead_18.TabIndex = 13400;
            this.chkHead_18.Tag = "5";
            this.chkHead_18.Text = "18、渗出性胸膜炎";
            // 
            // lblIdeaAndWrite
            // 
            this.lblIdeaAndWrite.AutoSize = true;
            this.lblIdeaAndWrite.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIdeaAndWrite.Location = new System.Drawing.Point(16, 520);
            this.lblIdeaAndWrite.Name = "lblIdeaAndWrite";
            this.lblIdeaAndWrite.Size = new System.Drawing.Size(112, 14);
            this.lblIdeaAndWrite.TabIndex = 643;
            this.lblIdeaAndWrite.Text = "患方意见及签名:";
            // 
            // lblIdeaAndWriteText
            // 
            this.lblIdeaAndWriteText.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIdeaAndWriteText.Location = new System.Drawing.Point(16, 540);
            this.lblIdeaAndWriteText.Name = "lblIdeaAndWriteText";
            this.lblIdeaAndWriteText.Size = new System.Drawing.Size(756, 36);
            this.lblIdeaAndWriteText.TabIndex = 644;
            this.lblIdeaAndWriteText.Text = "我（家属）术前已认真看过上述告知内容，对上述对√的内容医生做了详细解释，我完全理解，对耳鼻喉科手术的并发症及手术风险有了正确的认识，经慎重考虑，我（家属）同意接受" +
                "本次手术。";
            // 
            // lblWrite
            // 
            this.lblWrite.AutoSize = true;
            this.lblWrite.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWrite.Location = new System.Drawing.Point(16, 580);
            this.lblWrite.Name = "lblWrite";
            this.lblWrite.Size = new System.Drawing.Size(98, 14);
            this.lblWrite.TabIndex = 645;
            this.lblWrite.Text = "患者本人签名:";
            // 
            // lblRelation
            // 
            this.lblRelation.AutoSize = true;
            this.lblRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRelation.Location = new System.Drawing.Point(16, 604);
            this.lblRelation.Name = "lblRelation";
            this.lblRelation.Size = new System.Drawing.Size(98, 14);
            this.lblRelation.TabIndex = 647;
            this.lblRelation.Text = "患者家属签名:";
            this.lblRelation.Click += new System.EventHandler(this.lblRelation_Click);
            // 
            // lblRelationSufferer
            // 
            this.lblRelationSufferer.AutoSize = true;
            this.lblRelationSufferer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRelationSufferer.Location = new System.Drawing.Point(304, 600);
            this.lblRelationSufferer.Name = "lblRelationSufferer";
            this.lblRelationSufferer.Size = new System.Drawing.Size(112, 14);
            this.lblRelationSufferer.TabIndex = 649;
            this.lblRelationSufferer.Text = "家属与患者关系:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhone.Location = new System.Drawing.Point(16, 624);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(98, 14);
            this.lblPhone.TabIndex = 651;
            this.lblPhone.Text = "患者联系电话:";
            // 
            // lblRelationID
            // 
            this.lblRelationID.AutoSize = true;
            this.lblRelationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRelationID.Location = new System.Drawing.Point(304, 624);
            this.lblRelationID.Name = "lblRelationID";
            this.lblRelationID.Size = new System.Drawing.Size(112, 14);
            this.lblRelationID.TabIndex = 653;
            this.lblRelationID.Text = "家属身份证号码:";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbldate.Location = new System.Drawing.Point(304, 580);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(70, 14);
            this.lbldate.TabIndex = 657;
            this.lbldate.Text = "签名日期:";
            this.lbldate.Click += new System.EventHandler(this.lbldate_Click);
            // 
            // lblIntro
            // 
            this.lblIntro.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblIntro.Location = new System.Drawing.Point(16, 139);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(768, 64);
            this.lblIntro.TabIndex = 540;
            this.lblIntro.Text = resources.GetString("lblIntro.Text");
            // 
            // lblbefore
            // 
            this.lblbefore.AutoSize = true;
            this.lblbefore.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbefore.Location = new System.Drawing.Point(12, 99);
            this.lblbefore.Name = "lblbefore";
            this.lblbefore.Size = new System.Drawing.Size(70, 14);
            this.lblbefore.TabIndex = 665;
            this.lblbefore.Text = "术前诊断:";
            // 
            // lblTheName
            // 
            this.lblTheName.AutoSize = true;
            this.lblTheName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTheName.Location = new System.Drawing.Point(196, 61);
            this.lblTheName.Name = "lblTheName";
            this.lblTheName.Size = new System.Drawing.Size(70, 14);
            this.lblTheName.TabIndex = 666;
            this.lblTheName.Text = "手术名称:";
            // 
            // m_txtBeforeDisgone
            // 
            this.m_txtBeforeDisgone.AccessibleDescription = "术前诊断";
            this.m_txtBeforeDisgone.BackColor = System.Drawing.Color.White;
            this.m_txtBeforeDisgone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtBeforeDisgone.ForeColor = System.Drawing.Color.Black;
            this.m_txtBeforeDisgone.Location = new System.Drawing.Point(84, 95);
            this.m_txtBeforeDisgone.Name = "m_txtBeforeDisgone";
            this.m_txtBeforeDisgone.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtBeforeDisgone.Size = new System.Drawing.Size(692, 40);
            this.m_txtBeforeDisgone.TabIndex = 520;
            this.m_txtBeforeDisgone.Text = "";
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.AccessibleDescription = "手术名称";
            this.m_txtOperationName.BackColor = System.Drawing.Color.White;
            this.m_txtOperationName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtOperationName.ForeColor = System.Drawing.Color.Black;
            this.m_txtOperationName.Location = new System.Drawing.Point(270, 57);
            this.m_txtOperationName.Name = "m_txtOperationName";
            this.m_txtOperationName.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtOperationName.Size = new System.Drawing.Size(516, 24);
            this.m_txtOperationName.TabIndex = 530;
            this.m_txtOperationName.Text = "";
            // 
            // m_txtWriter
            // 
            this.m_txtWriter.AccessibleDescription = "患者本人签名";
            this.m_txtWriter.BackColor = System.Drawing.Color.White;
            this.m_txtWriter.BorderColor = System.Drawing.Color.White;
            this.m_txtWriter.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtWriter.ForeColor = System.Drawing.Color.Black;
            this.m_txtWriter.Location = new System.Drawing.Point(124, 576);
            this.m_txtWriter.Name = "m_txtWriter";
            this.m_txtWriter.Size = new System.Drawing.Size(168, 23);
            this.m_txtWriter.TabIndex = 13500;
            // 
            // m_txtPhone
            // 
            this.m_txtPhone.AccessibleDescription = "患者联系电话";
            this.m_txtPhone.BackColor = System.Drawing.Color.White;
            this.m_txtPhone.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtPhone.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtPhone.ForeColor = System.Drawing.Color.Black;
            this.m_txtPhone.Location = new System.Drawing.Point(124, 624);
            this.m_txtPhone.Name = "m_txtPhone";
            this.m_txtPhone.Size = new System.Drawing.Size(168, 23);
            this.m_txtPhone.TabIndex = 13800;
            // 
            // m_txtRelation
            // 
            this.m_txtRelation.AccessibleDescription = "患者家属签名";
            this.m_txtRelation.BackColor = System.Drawing.Color.White;
            this.m_txtRelation.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtRelation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRelation.ForeColor = System.Drawing.Color.Black;
            this.m_txtRelation.Location = new System.Drawing.Point(124, 600);
            this.m_txtRelation.Name = "m_txtRelation";
            this.m_txtRelation.Size = new System.Drawing.Size(168, 23);
            this.m_txtRelation.TabIndex = 13600;
            // 
            // m_txtRelationID
            // 
            this.m_txtRelationID.AccessibleDescription = "家庭身份证号码";
            this.m_txtRelationID.BackColor = System.Drawing.Color.White;
            this.m_txtRelationID.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtRelationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRelationID.ForeColor = System.Drawing.Color.Black;
            this.m_txtRelationID.Location = new System.Drawing.Point(424, 624);
            this.m_txtRelationID.Name = "m_txtRelationID";
            this.m_txtRelationID.Size = new System.Drawing.Size(216, 23);
            this.m_txtRelationID.TabIndex = 13900;
            // 
            // m_txtRelationSufferer
            // 
            this.m_txtRelationSufferer.AccessibleDescription = "家属与患者关系";
            this.m_txtRelationSufferer.BackColor = System.Drawing.Color.White;
            this.m_txtRelationSufferer.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtRelationSufferer.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRelationSufferer.ForeColor = System.Drawing.Color.Black;
            this.m_txtRelationSufferer.Location = new System.Drawing.Point(424, 600);
            this.m_txtRelationSufferer.Name = "m_txtRelationSufferer";
            this.m_txtRelationSufferer.Size = new System.Drawing.Size(216, 23);
            this.m_txtRelationSufferer.TabIndex = 13700;
            // 
            // m_chkAuris_12
            // 
            this.m_chkAuris_12.Location = new System.Drawing.Point(556, 80);
            this.m_chkAuris_12.Name = "m_chkAuris_12";
            this.m_chkAuris_12.Size = new System.Drawing.Size(157, 24);
            this.m_chkAuris_12.TabIndex = 1650;
            this.m_chkAuris_12.Tag = "1";
            this.m_chkAuris_12.Text = "12、永久性鼓膜穿孔";
            // 
            // m_chkAuris_38
            // 
            this.m_chkAuris_38.Location = new System.Drawing.Point(184, 248);
            this.m_chkAuris_38.Name = "m_chkAuris_38";
            this.m_chkAuris_38.Size = new System.Drawing.Size(144, 24);
            this.m_chkAuris_38.TabIndex = 4100;
            this.m_chkAuris_38.Tag = "1";
            this.m_chkAuris_38.Text = "38、后半窥管损伤";
            // 
            // m_chkAuris_37
            // 
            this.m_chkAuris_37.Location = new System.Drawing.Point(4, 248);
            this.m_chkAuris_37.Name = "m_chkAuris_37";
            this.m_chkAuris_37.Size = new System.Drawing.Size(132, 24);
            this.m_chkAuris_37.TabIndex = 4000;
            this.m_chkAuris_37.Tag = "1";
            this.m_chkAuris_37.Text = "37、乙状窦损伤";
            // 
            // m_chkAuris_36
            // 
            this.m_chkAuris_36.Location = new System.Drawing.Point(556, 224);
            this.m_chkAuris_36.Name = "m_chkAuris_36";
            this.m_chkAuris_36.Size = new System.Drawing.Size(192, 24);
            this.m_chkAuris_36.TabIndex = 3900;
            this.m_chkAuris_36.Tag = "1";
            this.m_chkAuris_36.Text = "36、IX、X、XI脑神经损伤";
            // 
            // m_chkAuris_35
            // 
            this.m_chkAuris_35.Location = new System.Drawing.Point(372, 224);
            this.m_chkAuris_35.Name = "m_chkAuris_35";
            this.m_chkAuris_35.Size = new System.Drawing.Size(128, 24);
            this.m_chkAuris_35.TabIndex = 3800;
            this.m_chkAuris_35.Tag = "1";
            this.m_chkAuris_35.Text = "35、味觉改变";
            // 
            // m_chkAuris_34
            // 
            this.m_chkAuris_34.Location = new System.Drawing.Point(184, 224);
            this.m_chkAuris_34.Name = "m_chkAuris_34";
            this.m_chkAuris_34.Size = new System.Drawing.Size(116, 24);
            this.m_chkAuris_34.TabIndex = 3700;
            this.m_chkAuris_34.Tag = "1";
            this.m_chkAuris_34.Text = "34、外淋巴瘘";
            // 
            // m_chkAuris_33
            // 
            this.m_chkAuris_33.Location = new System.Drawing.Point(4, 224);
            this.m_chkAuris_33.Name = "m_chkAuris_33";
            this.m_chkAuris_33.Size = new System.Drawing.Size(148, 24);
            this.m_chkAuris_33.TabIndex = 3600;
            this.m_chkAuris_33.Tag = "1";
            this.m_chkAuris_33.Text = "33、鳄鱼泪综合症";
            // 
            // m_chkAuris_32
            // 
            this.m_chkAuris_32.Location = new System.Drawing.Point(556, 200);
            this.m_chkAuris_32.Name = "m_chkAuris_32";
            this.m_chkAuris_32.Size = new System.Drawing.Size(112, 24);
            this.m_chkAuris_32.TabIndex = 3500;
            this.m_chkAuris_32.Tag = "1";
            this.m_chkAuris_32.Text = "32、联带运动";
            // 
            // m_chkAuris_31
            // 
            this.m_chkAuris_31.Location = new System.Drawing.Point(372, 200);
            this.m_chkAuris_31.Name = "m_chkAuris_31";
            this.m_chkAuris_31.Size = new System.Drawing.Size(148, 24);
            this.m_chkAuris_31.TabIndex = 3400;
            this.m_chkAuris_31.Tag = "1";
            this.m_chkAuris_31.Text = "31、填塞物脱出";
            // 
            // m_chkAuris_30
            // 
            this.m_chkAuris_30.Location = new System.Drawing.Point(184, 200);
            this.m_chkAuris_30.Name = "m_chkAuris_30";
            this.m_chkAuris_30.Size = new System.Drawing.Size(116, 24);
            this.m_chkAuris_30.TabIndex = 3300;
            this.m_chkAuris_30.Tag = "1";
            this.m_chkAuris_30.Text = "30、外耳狭窄";
            // 
            // m_chkAuris_29
            // 
            this.m_chkAuris_29.Location = new System.Drawing.Point(4, 200);
            this.m_chkAuris_29.Name = "m_chkAuris_29";
            this.m_chkAuris_29.Size = new System.Drawing.Size(116, 24);
            this.m_chkAuris_29.TabIndex = 3200;
            this.m_chkAuris_29.Tag = "1";
            this.m_chkAuris_29.Text = "29、肌瓣坏死";
            // 
            // m_chkAuris_28
            // 
            this.m_chkAuris_28.Location = new System.Drawing.Point(556, 176);
            this.m_chkAuris_28.Name = "m_chkAuris_28";
            this.m_chkAuris_28.Size = new System.Drawing.Size(116, 24);
            this.m_chkAuris_28.TabIndex = 3100;
            this.m_chkAuris_28.Tag = "1";
            this.m_chkAuris_28.Text = "28、颞部水肿";
            // 
            // m_chkAuris_27
            // 
            this.m_chkAuris_27.Location = new System.Drawing.Point(372, 176);
            this.m_chkAuris_27.Name = "m_chkAuris_27";
            this.m_chkAuris_27.Size = new System.Drawing.Size(120, 24);
            this.m_chkAuris_27.TabIndex = 3000;
            this.m_chkAuris_27.Tag = "1";
            this.m_chkAuris_27.Text = "27、迷路瘘管";
            // 
            // m_chkAuris_26
            // 
            this.m_chkAuris_26.Location = new System.Drawing.Point(184, 176);
            this.m_chkAuris_26.Name = "m_chkAuris_26";
            this.m_chkAuris_26.Size = new System.Drawing.Size(180, 24);
            this.m_chkAuris_26.TabIndex = 2900;
            this.m_chkAuris_26.Tag = "1";
            this.m_chkAuris_26.Text = "26、胆脂瘤残留及复发";
            // 
            // m_chkAuris_25
            // 
            this.m_chkAuris_25.Location = new System.Drawing.Point(4, 176);
            this.m_chkAuris_25.Name = "m_chkAuris_25";
            this.m_chkAuris_25.Size = new System.Drawing.Size(128, 24);
            this.m_chkAuris_25.TabIndex = 2800;
            this.m_chkAuris_25.Tag = "1";
            this.m_chkAuris_25.Text = "25、鼓室粘连";
            // 
            // m_chkAuris_24
            // 
            this.m_chkAuris_24.Location = new System.Drawing.Point(556, 152);
            this.m_chkAuris_24.Name = "m_chkAuris_24";
            this.m_chkAuris_24.Size = new System.Drawing.Size(164, 24);
            this.m_chkAuris_24.TabIndex = 2700;
            this.m_chkAuris_24.Tag = "1";
            this.m_chkAuris_24.Text = "24、浆液性迷路炎";
            // 
            // m_chkAuris_23
            // 
            this.m_chkAuris_23.Location = new System.Drawing.Point(372, 152);
            this.m_chkAuris_23.Name = "m_chkAuris_23";
            this.m_chkAuris_23.Size = new System.Drawing.Size(96, 24);
            this.m_chkAuris_23.TabIndex = 2600;
            this.m_chkAuris_23.Tag = "1";
            this.m_chkAuris_23.Text = "23、耳鸣";
            // 
            // m_chkAuris_22
            // 
            this.m_chkAuris_22.Location = new System.Drawing.Point(184, 152);
            this.m_chkAuris_22.Name = "m_chkAuris_22";
            this.m_chkAuris_22.Size = new System.Drawing.Size(144, 24);
            this.m_chkAuris_22.TabIndex = 2500;
            this.m_chkAuris_22.Tag = "1";
            this.m_chkAuris_22.Text = "22、鼓膜位置异常";
            // 
            // m_chkAuris_21
            // 
            this.m_chkAuris_21.Location = new System.Drawing.Point(4, 152);
            this.m_chkAuris_21.Name = "m_chkAuris_21";
            this.m_chkAuris_21.Size = new System.Drawing.Size(112, 24);
            this.m_chkAuris_21.TabIndex = 2400;
            this.m_chkAuris_21.Tag = "1";
            this.m_chkAuris_21.Text = "21、迷路炎";
            // 
            // m_chkAuris_20
            // 
            this.m_chkAuris_20.Location = new System.Drawing.Point(556, 128);
            this.m_chkAuris_20.Name = "m_chkAuris_20";
            this.m_chkAuris_20.Size = new System.Drawing.Size(184, 24);
            this.m_chkAuris_20.TabIndex = 2300;
            this.m_chkAuris_20.Tag = "1";
            this.m_chkAuris_20.Text = "20、化脓性耳廓软骨膜炎";
            // 
            // m_chkAuris_19
            // 
            this.m_chkAuris_19.Location = new System.Drawing.Point(372, 128);
            this.m_chkAuris_19.Name = "m_chkAuris_19";
            this.m_chkAuris_19.Size = new System.Drawing.Size(168, 24);
            this.m_chkAuris_19.TabIndex = 2200;
            this.m_chkAuris_19.Tag = "1";
            this.m_chkAuris_19.Text = "19、听力无提高或下降";
            // 
            // m_chkAuris_18
            // 
            this.m_chkAuris_18.Location = new System.Drawing.Point(184, 128);
            this.m_chkAuris_18.Name = "m_chkAuris_18";
            this.m_chkAuris_18.Size = new System.Drawing.Size(112, 24);
            this.m_chkAuris_18.TabIndex = 2100;
            this.m_chkAuris_18.Tag = "1";
            this.m_chkAuris_18.Text = "18、再度粘连";
            // 
            // m_chkAuris_17
            // 
            this.m_chkAuris_17.Location = new System.Drawing.Point(4, 128);
            this.m_chkAuris_17.Name = "m_chkAuris_17";
            this.m_chkAuris_17.Size = new System.Drawing.Size(118, 24);
            this.m_chkAuris_17.TabIndex = 2050;
            this.m_chkAuris_17.Tag = "1";
            this.m_chkAuris_17.Text = "17、再度流脓";
            // 
            // m_chkAuris_15
            // 
            this.m_chkAuris_15.Location = new System.Drawing.Point(372, 104);
            this.m_chkAuris_15.Name = "m_chkAuris_15";
            this.m_chkAuris_15.Size = new System.Drawing.Size(140, 24);
            this.m_chkAuris_15.TabIndex = 1900;
            this.m_chkAuris_15.Tag = "1";
            this.m_chkAuris_15.Text = "15、颈静脉球损伤";
            // 
            // m_chkAuris_14
            // 
            this.m_chkAuris_14.Location = new System.Drawing.Point(184, 104);
            this.m_chkAuris_14.Name = "m_chkAuris_14";
            this.m_chkAuris_14.Size = new System.Drawing.Size(140, 24);
            this.m_chkAuris_14.TabIndex = 1800;
            this.m_chkAuris_14.Tag = "1";
            this.m_chkAuris_14.Text = "14、继发性胆脂瘤";
            // 
            // m_chkAuris_13
            // 
            this.m_chkAuris_13.Location = new System.Drawing.Point(4, 104);
            this.m_chkAuris_13.Name = "m_chkAuris_13";
            this.m_chkAuris_13.Size = new System.Drawing.Size(160, 24);
            this.m_chkAuris_13.TabIndex = 1700;
            this.m_chkAuris_13.Tag = "1";
            this.m_chkAuris_13.Text = "13、慢性化脓中耳炎";
            // 
            // m_chkAuris_11
            // 
            this.m_chkAuris_11.Location = new System.Drawing.Point(372, 80);
            this.m_chkAuris_11.Name = "m_chkAuris_11";
            this.m_chkAuris_11.Size = new System.Drawing.Size(120, 24);
            this.m_chkAuris_11.TabIndex = 1600;
            this.m_chkAuris_11.Tag = "1";
            this.m_chkAuris_11.Text = "11、鼓膜硬化";
            // 
            // m_chkAuris_16
            // 
            this.m_chkAuris_16.Location = new System.Drawing.Point(556, 104);
            this.m_chkAuris_16.Name = "m_chkAuris_16";
            this.m_chkAuris_16.Size = new System.Drawing.Size(164, 24);
            this.m_chkAuris_16.TabIndex = 2000;
            this.m_chkAuris_16.Tag = "1";
            this.m_chkAuris_16.Text = "16、外耳道炎性反应";
            // 
            // m_chkAuris_10
            // 
            this.m_chkAuris_10.Location = new System.Drawing.Point(184, 80);
            this.m_chkAuris_10.Name = "m_chkAuris_10";
            this.m_chkAuris_10.Size = new System.Drawing.Size(84, 24);
            this.m_chkAuris_10.TabIndex = 1500;
            this.m_chkAuris_10.Tag = "1";
            this.m_chkAuris_10.Text = "10、眩晕";
            // 
            // m_chkAuris_9
            // 
            this.m_chkAuris_9.Location = new System.Drawing.Point(4, 80);
            this.m_chkAuris_9.Name = "m_chkAuris_9";
            this.m_chkAuris_9.Size = new System.Drawing.Size(136, 24);
            this.m_chkAuris_9.TabIndex = 1400;
            this.m_chkAuris_9.Tag = "1";
            this.m_chkAuris_9.Text = "9、感音神经性聋";
            // 
            // m_chkAuris_8
            // 
            this.m_chkAuris_8.Location = new System.Drawing.Point(556, 56);
            this.m_chkAuris_8.Name = "m_chkAuris_8";
            this.m_chkAuris_8.Size = new System.Drawing.Size(104, 24);
            this.m_chkAuris_8.TabIndex = 1300;
            this.m_chkAuris_8.Tag = "1";
            this.m_chkAuris_8.Text = "8、中耳感染";
            // 
            // m_chkAuris_7
            // 
            this.m_chkAuris_7.Location = new System.Drawing.Point(372, 56);
            this.m_chkAuris_7.Name = "m_chkAuris_7";
            this.m_chkAuris_7.Size = new System.Drawing.Size(104, 24);
            this.m_chkAuris_7.TabIndex = 1200;
            this.m_chkAuris_7.Tag = "1";
            this.m_chkAuris_7.Text = "7、晕厥";
            // 
            // m_chkAuris_6
            // 
            this.m_chkAuris_6.Location = new System.Drawing.Point(184, 56);
            this.m_chkAuris_6.Name = "m_chkAuris_6";
            this.m_chkAuris_6.Size = new System.Drawing.Size(148, 24);
            this.m_chkAuris_6.TabIndex = 1100;
            this.m_chkAuris_6.Tag = "1";
            this.m_chkAuris_6.Text = "6、下颌关节囊损伤";
            // 
            // m_chkAuris_5
            // 
            this.m_chkAuris_5.Location = new System.Drawing.Point(4, 56);
            this.m_chkAuris_5.Name = "m_chkAuris_5";
            this.m_chkAuris_5.Size = new System.Drawing.Size(130, 24);
            this.m_chkAuris_5.TabIndex = 1000;
            this.m_chkAuris_5.Tag = "1";
            this.m_chkAuris_5.Text = "5、迷路损伤";
            // 
            // m_chkAuris_4
            // 
            this.m_chkAuris_4.Location = new System.Drawing.Point(556, 32);
            this.m_chkAuris_4.Name = "m_chkAuris_4";
            this.m_chkAuris_4.Size = new System.Drawing.Size(104, 24);
            this.m_chkAuris_4.TabIndex = 900;
            this.m_chkAuris_4.Tag = "1";
            this.m_chkAuris_4.Text = "4、面肌痉挛";
            // 
            // m_chkAuris_3
            // 
            this.m_chkAuris_3.Location = new System.Drawing.Point(372, 32);
            this.m_chkAuris_3.Name = "m_chkAuris_3";
            this.m_chkAuris_3.Size = new System.Drawing.Size(88, 24);
            this.m_chkAuris_3.TabIndex = 800;
            this.m_chkAuris_3.Tag = "1";
            this.m_chkAuris_3.Text = "3、面瘫";
            // 
            // m_chkAuris_2
            // 
            this.m_chkAuris_2.Location = new System.Drawing.Point(184, 32);
            this.m_chkAuris_2.Name = "m_chkAuris_2";
            this.m_chkAuris_2.Size = new System.Drawing.Size(128, 24);
            this.m_chkAuris_2.TabIndex = 700;
            this.m_chkAuris_2.Tag = "1";
            this.m_chkAuris_2.Text = "2、面神经损伤";
            // 
            // m_chkAuris_1
            // 
            this.m_chkAuris_1.Location = new System.Drawing.Point(4, 32);
            this.m_chkAuris_1.Name = "m_chkAuris_1";
            this.m_chkAuris_1.Size = new System.Drawing.Size(112, 24);
            this.m_chkAuris_1.TabIndex = 600;
            this.m_chkAuris_1.Tag = "1";
            this.m_chkAuris_1.Text = "1、皮下血肿";
            // 
            // dtpSignatoryTime
            // 
            this.dtpSignatoryTime.BorderColor = System.Drawing.Color.Black;
            this.dtpSignatoryTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpSignatoryTime.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpSignatoryTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpSignatoryTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpSignatoryTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpSignatoryTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpSignatoryTime.ForeColor = System.Drawing.Color.Black;
            this.dtpSignatoryTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSignatoryTime.Location = new System.Drawing.Point(424, 576);
            this.dtpSignatoryTime.m_BlnOnlyTime = false;
            this.dtpSignatoryTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpSignatoryTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpSignatoryTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpSignatoryTime.Name = "dtpSignatoryTime";
            this.dtpSignatoryTime.ReadOnly = false;
            this.dtpSignatoryTime.Size = new System.Drawing.Size(216, 22);
            this.dtpSignatoryTime.TabIndex = 15000;
            this.dtpSignatoryTime.TextBackColor = System.Drawing.Color.White;
            this.dtpSignatoryTime.TextForeColor = System.Drawing.Color.Black;
            // 
            // trvTime
            // 
            this.trvTime.BackColor = System.Drawing.Color.White;
            this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTime.ForeColor = System.Drawing.Color.Black;
            this.trvTime.HideSelection = false;
            this.trvTime.ItemHeight = 18;
            this.trvTime.Location = new System.Drawing.Point(3, 37);
            this.trvTime.Name = "trvTime";
            this.trvTime.ShowRootLines = false;
            this.trvTime.Size = new System.Drawing.Size(196, 53);
            this.trvTime.TabIndex = 510;
            this.trvTime.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvTime_AfterSelect);
            // 
            // lblTalkDoctor
            // 
            this.lblTalkDoctor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTalkDoctor.Location = new System.Drawing.Point(596, 624);
            this.lblTalkDoctor.Name = "lblTalkDoctor";
            this.lblTalkDoctor.Size = new System.Drawing.Size(156, 19);
            this.lblTalkDoctor.TabIndex = 720;
            this.lblTalkDoctor.Visible = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.ForeColor = System.Drawing.Color.Black;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.Location = new System.Drawing.Point(656, 492);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(108, 105);
            this.listView1.TabIndex = 10000041;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // m_txtSign
            // 
            this.m_txtSign.AccessibleName = "NoDefault";
            this.m_txtSign.BackColor = System.Drawing.Color.White;
            this.m_txtSign.BorderColor = System.Drawing.Color.Transparent;
            this.m_txtSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSign.ForeColor = System.Drawing.Color.Black;
            this.m_txtSign.Location = new System.Drawing.Point(656, 600);
            this.m_txtSign.Name = "m_txtSign";
            this.m_txtSign.Size = new System.Drawing.Size(108, 23);
            this.m_txtSign.TabIndex = 14000;
            // 
            // m_chkCheck1
            // 
            this.m_chkCheck1.BackColor = System.Drawing.Color.Transparent;
            this.m_chkCheck1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkCheck1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkCheck1.ForeColor = System.Drawing.Color.Black;
            this.m_chkCheck1.Location = new System.Drawing.Point(12, 4);
            this.m_chkCheck1.Name = "m_chkCheck1";
            this.m_chkCheck1.Size = new System.Drawing.Size(128, 28);
            this.m_chkCheck1.TabIndex = 599;
            this.m_chkCheck1.Tag = "tabPage1";
            this.m_chkCheck1.Text = "耳科手术并发症";
            this.m_chkCheck1.UseVisualStyleBackColor = false;
            this.m_chkCheck1.CheckedChanged += new System.EventHandler(this.m_mthGroupCheck);
            // 
            // m_chkCheck5
            // 
            this.m_chkCheck5.BackColor = System.Drawing.Color.Transparent;
            this.m_chkCheck5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkCheck5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkCheck5.ForeColor = System.Drawing.Color.Black;
            this.m_chkCheck5.Location = new System.Drawing.Point(4, 4);
            this.m_chkCheck5.Name = "m_chkCheck5";
            this.m_chkCheck5.Size = new System.Drawing.Size(128, 28);
            this.m_chkCheck5.TabIndex = 11799;
            this.m_chkCheck5.Tag = "tabPage5";
            this.m_chkCheck5.Text = "头颈外科并发症";
            this.m_chkCheck5.UseVisualStyleBackColor = false;
            this.m_chkCheck5.CheckedChanged += new System.EventHandler(this.m_mthGroupCheck);
            // 
            // m_chkCheck3
            // 
            this.m_chkCheck3.BackColor = System.Drawing.Color.Transparent;
            this.m_chkCheck3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkCheck3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkCheck3.ForeColor = System.Drawing.Color.Black;
            this.m_chkCheck3.Location = new System.Drawing.Point(12, 4);
            this.m_chkCheck3.Name = "m_chkCheck3";
            this.m_chkCheck3.Size = new System.Drawing.Size(216, 28);
            this.m_chkCheck3.TabIndex = 7399;
            this.m_chkCheck3.Tag = "tabPage3";
            this.m_chkCheck3.Text = "喉、气管、食道、手术并发症";
            this.m_chkCheck3.UseVisualStyleBackColor = false;
            this.m_chkCheck3.CheckedChanged += new System.EventHandler(this.m_mthGroupCheck);
            // 
            // m_chkCheck4
            // 
            this.m_chkCheck4.BackColor = System.Drawing.Color.Transparent;
            this.m_chkCheck4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkCheck4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkCheck4.ForeColor = System.Drawing.Color.Black;
            this.m_chkCheck4.Location = new System.Drawing.Point(12, 4);
            this.m_chkCheck4.Name = "m_chkCheck4";
            this.m_chkCheck4.Size = new System.Drawing.Size(136, 28);
            this.m_chkCheck4.TabIndex = 9399;
            this.m_chkCheck4.Tag = "tabPage4";
            this.m_chkCheck4.Text = "咽科手术并发症";
            this.m_chkCheck4.UseVisualStyleBackColor = false;
            this.m_chkCheck4.CheckedChanged += new System.EventHandler(this.m_mthGroupCheck);
            // 
            // m_chkCheck2
            // 
            this.m_chkCheck2.BackColor = System.Drawing.Color.Transparent;
            this.m_chkCheck2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.m_chkCheck2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_chkCheck2.ForeColor = System.Drawing.Color.Black;
            this.m_chkCheck2.Location = new System.Drawing.Point(12, 4);
            this.m_chkCheck2.Name = "m_chkCheck2";
            this.m_chkCheck2.Size = new System.Drawing.Size(128, 28);
            this.m_chkCheck2.TabIndex = 4199;
            this.m_chkCheck2.Tag = "tabPage2";
            this.m_chkCheck2.Text = "鼻科手术并发症";
            this.m_chkCheck2.UseVisualStyleBackColor = false;
            this.m_chkCheck2.CheckedChanged += new System.EventHandler(this.m_mthGroupCheck);
            // 
            // m_cmdSign
            // 
            this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSign.DefaultScheme = true;
            this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSign.Hint = "";
            this.m_cmdSign.Location = new System.Drawing.Point(652, 624);
            this.m_cmdSign.Name = "m_cmdSign";
            this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSign.Size = new System.Drawing.Size(112, 28);
            this.m_cmdSign.TabIndex = 13950;
            this.m_cmdSign.Tag = "1";
            this.m_cmdSign.Text = "谈话医生签名:";
            // 
            // tabControl1
            // 
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabControl1.IDEPixelArea = true;
            this.tabControl1.Location = new System.Drawing.Point(16, 199);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.PositionTop = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedTab = this.tabPage1;
            this.tabControl1.Size = new System.Drawing.Size(760, 318);
            this.tabControl1.TabIndex = 10000042;
            this.tabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3,
            this.tabPage4,
            this.tabPage5});
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.m_chkNose_1);
            this.tabPage2.Controls.Add(this.m_chkNose_2);
            this.tabPage2.Controls.Add(this.m_chkCheck2);
            this.tabPage2.Controls.Add(this.m_chkNose_3);
            this.tabPage2.Controls.Add(this.m_chkNose_4);
            this.tabPage2.Controls.Add(this.m_chkNose_5);
            this.tabPage2.Controls.Add(this.m_chkNose_6);
            this.tabPage2.Controls.Add(this.m_chkNose_7);
            this.tabPage2.Controls.Add(this.m_chkNose_8);
            this.tabPage2.Controls.Add(this.m_chkNose_9);
            this.tabPage2.Controls.Add(this.m_chkNose_10);
            this.tabPage2.Controls.Add(this.m_chkNose_11);
            this.tabPage2.Controls.Add(this.m_chkNose_12);
            this.tabPage2.Controls.Add(this.m_chkNose_13);
            this.tabPage2.Controls.Add(this.m_chkNose_14);
            this.tabPage2.Controls.Add(this.m_chkNose_15);
            this.tabPage2.Controls.Add(this.m_chkNose_16);
            this.tabPage2.Controls.Add(this.m_chkNose_17);
            this.tabPage2.Controls.Add(this.m_chkNose_18);
            this.tabPage2.Controls.Add(this.m_chkNose_19);
            this.tabPage2.Controls.Add(this.m_chkNose_20);
            this.tabPage2.Controls.Add(this.m_chkNose_21);
            this.tabPage2.Controls.Add(this.m_chkNose_22);
            this.tabPage2.Controls.Add(this.m_chkNose_23);
            this.tabPage2.Controls.Add(this.m_chkNose_24);
            this.tabPage2.Controls.Add(this.m_chkNose_25);
            this.tabPage2.Controls.Add(this.m_chkNose_26);
            this.tabPage2.Controls.Add(this.m_chkNose_27);
            this.tabPage2.Controls.Add(this.m_chkNose_28);
            this.tabPage2.Controls.Add(this.m_chkNose_29);
            this.tabPage2.Controls.Add(this.m_chkNose_30);
            this.tabPage2.Controls.Add(this.m_chkNose_31);
            this.tabPage2.ImageIndex = 8;
            this.tabPage2.ImageList = this.imageList1;
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(760, 293);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Title = "鼻科手术并发症";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.m_chkCheck1);
            this.tabPage1.Controls.Add(this.m_chkAuris_1);
            this.tabPage1.Controls.Add(this.m_chkAuris_2);
            this.tabPage1.Controls.Add(this.m_chkAuris_3);
            this.tabPage1.Controls.Add(this.m_chkAuris_4);
            this.tabPage1.Controls.Add(this.m_chkAuris_5);
            this.tabPage1.Controls.Add(this.m_chkAuris_6);
            this.tabPage1.Controls.Add(this.m_chkAuris_7);
            this.tabPage1.Controls.Add(this.m_chkAuris_8);
            this.tabPage1.Controls.Add(this.m_chkAuris_9);
            this.tabPage1.Controls.Add(this.m_chkAuris_10);
            this.tabPage1.Controls.Add(this.m_chkAuris_11);
            this.tabPage1.Controls.Add(this.m_chkAuris_12);
            this.tabPage1.Controls.Add(this.m_chkAuris_13);
            this.tabPage1.Controls.Add(this.m_chkAuris_14);
            this.tabPage1.Controls.Add(this.m_chkAuris_15);
            this.tabPage1.Controls.Add(this.m_chkAuris_16);
            this.tabPage1.Controls.Add(this.m_chkAuris_17);
            this.tabPage1.Controls.Add(this.m_chkAuris_18);
            this.tabPage1.Controls.Add(this.m_chkAuris_19);
            this.tabPage1.Controls.Add(this.m_chkAuris_20);
            this.tabPage1.Controls.Add(this.m_chkAuris_21);
            this.tabPage1.Controls.Add(this.m_chkAuris_22);
            this.tabPage1.Controls.Add(this.m_chkAuris_23);
            this.tabPage1.Controls.Add(this.m_chkAuris_24);
            this.tabPage1.Controls.Add(this.m_chkAuris_25);
            this.tabPage1.Controls.Add(this.m_chkAuris_26);
            this.tabPage1.Controls.Add(this.m_chkAuris_27);
            this.tabPage1.Controls.Add(this.m_chkAuris_28);
            this.tabPage1.Controls.Add(this.m_chkAuris_29);
            this.tabPage1.Controls.Add(this.m_chkAuris_30);
            this.tabPage1.Controls.Add(this.m_chkAuris_31);
            this.tabPage1.Controls.Add(this.m_chkAuris_32);
            this.tabPage1.Controls.Add(this.m_chkAuris_33);
            this.tabPage1.Controls.Add(this.m_chkAuris_34);
            this.tabPage1.Controls.Add(this.m_chkAuris_35);
            this.tabPage1.Controls.Add(this.m_chkAuris_36);
            this.tabPage1.Controls.Add(this.m_chkAuris_37);
            this.tabPage1.Controls.Add(this.m_chkAuris_38);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.ImageList = this.imageList1;
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(760, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "耳科手术并发症";
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.m_chkCheck3);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_1);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_2);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_3);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_4);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_5);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_6);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_7);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_8);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_9);
            this.tabPage3.Controls.Add(this.m_chkLarynxGullet_10);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_11);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_12);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_13);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_14);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_15);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_16);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_17);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_18);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_19);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_20);
            this.tabPage3.Controls.Add(this.chkLarynxGullet_21);
            this.tabPage3.ImageIndex = 8;
            this.tabPage3.ImageList = this.imageList1;
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(760, 293);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Title = "喉、气管、食道、手术并发症";
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage4.Controls.Add(this.chkFauces_2);
            this.tabPage4.Controls.Add(this.m_chkCheck4);
            this.tabPage4.Controls.Add(this.chkFauces_1);
            this.tabPage4.Controls.Add(this.chkFauces_3);
            this.tabPage4.Controls.Add(this.chkFauces_4);
            this.tabPage4.Controls.Add(this.chkFauces_5);
            this.tabPage4.Controls.Add(this.chkFauces_6);
            this.tabPage4.Controls.Add(this.chkFauces_7);
            this.tabPage4.Controls.Add(this.chkFauces_8);
            this.tabPage4.Controls.Add(this.chkFauces_9);
            this.tabPage4.Controls.Add(this.chkFauces_10);
            this.tabPage4.Controls.Add(this.chkFauces_11);
            this.tabPage4.Controls.Add(this.chkFauces_12);
            this.tabPage4.Controls.Add(this.m_chkFauces_13);
            this.tabPage4.Controls.Add(this.chkFauces_14);
            this.tabPage4.Controls.Add(this.chkFauces_15);
            this.tabPage4.Controls.Add(this.chkFauces_16);
            this.tabPage4.Controls.Add(this.chkFauces_17);
            this.tabPage4.Controls.Add(this.chkFauces_18);
            this.tabPage4.Controls.Add(this.chkFauces_19);
            this.tabPage4.Controls.Add(this.chkFauces_20);
            this.tabPage4.Controls.Add(this.chkFauces_21);
            this.tabPage4.Controls.Add(this.chkFauces_22);
            this.tabPage4.Controls.Add(this.chkFauces_23);
            this.tabPage4.Controls.Add(this.chkFauces_24);
            this.tabPage4.ImageIndex = 8;
            this.tabPage4.ImageList = this.imageList1;
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(760, 293);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Title = "咽科手术并发症";
            // 
            // tabPage5
            // 
            this.tabPage5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage5.Controls.Add(this.m_chkCheck5);
            this.tabPage5.Controls.Add(this.chkHead_1);
            this.tabPage5.Controls.Add(this.chkHead_2);
            this.tabPage5.Controls.Add(this.chkHead_3);
            this.tabPage5.Controls.Add(this.chkHead_4);
            this.tabPage5.Controls.Add(this.chkHead_5);
            this.tabPage5.Controls.Add(this.chkHead_6);
            this.tabPage5.Controls.Add(this.chkHead_7);
            this.tabPage5.Controls.Add(this.chkHead_8);
            this.tabPage5.Controls.Add(this.chkHead_9);
            this.tabPage5.Controls.Add(this.chkHead_10);
            this.tabPage5.Controls.Add(this.m_chkHead_11);
            this.tabPage5.Controls.Add(this.m_chkHead_12);
            this.tabPage5.Controls.Add(this.chkHead_13);
            this.tabPage5.Controls.Add(this.chkHead_14);
            this.tabPage5.Controls.Add(this.chkHead_15);
            this.tabPage5.Controls.Add(this.chkHead_16);
            this.tabPage5.Controls.Add(this.chkHead_17);
            this.tabPage5.Controls.Add(this.chkHead_18);
            this.tabPage5.ImageIndex = 8;
            this.tabPage5.ImageList = this.imageList1;
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(760, 293);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Title = "头颈外科并发症";
            // 
            // frmOperationAgreedRecord
            // 
            this.AccessibleDescription = "耳鼻喉科手术知情同意书";
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(801, 673);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblbefore);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblRelation);
            this.Controls.Add(this.lblWrite);
            this.Controls.Add(this.lblRelationID);
            this.Controls.Add(this.lblRelationSufferer);
            this.Controls.Add(this.lblIdeaAndWrite);
            this.Controls.Add(this.m_txtSign);
            this.Controls.Add(this.m_txtRelationSufferer);
            this.Controls.Add(this.m_txtRelationID);
            this.Controls.Add(this.m_txtRelation);
            this.Controls.Add(this.m_txtPhone);
            this.Controls.Add(this.m_txtWriter);
            this.Controls.Add(this.m_cmdSign);
            this.Controls.Add(this.lblTalkDoctor);
            this.Controls.Add(this.trvTime);
            this.Controls.Add(this.m_txtBeforeDisgone);
            this.Controls.Add(this.dtpSignatoryTime);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblIdeaAndWriteText);
            this.Controls.Add(this.lbldate);
            this.Name = "frmOperationAgreedRecord";
            this.Tag = "";
            this.Text = "耳鼻喉科手术知情同意书";
            this.Load += new System.EventHandler(this.frmOperationAgreedRecord_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lbldate, 0);
            this.Controls.SetChildIndex(this.lblIdeaAndWriteText, 0);
            this.Controls.SetChildIndex(this.lblIntro, 0);
            this.Controls.SetChildIndex(this.dtpSignatoryTime, 0);
            this.Controls.SetChildIndex(this.m_txtBeforeDisgone, 0);
            this.Controls.SetChildIndex(this.trvTime, 0);
            this.Controls.SetChildIndex(this.lblTalkDoctor, 0);
            this.Controls.SetChildIndex(this.m_cmdSign, 0);
            this.Controls.SetChildIndex(this.m_txtWriter, 0);
            this.Controls.SetChildIndex(this.m_txtPhone, 0);
            this.Controls.SetChildIndex(this.m_txtRelation, 0);
            this.Controls.SetChildIndex(this.m_txtRelationID, 0);
            this.Controls.SetChildIndex(this.m_txtRelationSufferer, 0);
            this.Controls.SetChildIndex(this.m_txtSign, 0);
            this.Controls.SetChildIndex(this.lblIdeaAndWrite, 0);
            this.Controls.SetChildIndex(this.lblRelationSufferer, 0);
            this.Controls.SetChildIndex(this.lblRelationID, 0);
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
            this.Controls.SetChildIndex(this.lblWrite, 0);
            this.Controls.SetChildIndex(this.lblRelation, 0);
            this.Controls.SetChildIndex(this.lblPhone, 0);
            this.Controls.SetChildIndex(this.lblbefore, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region 重载基类窗体
		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}
		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return blnCanSearch;
			}
		}

		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			if(p_objSelectedPatient == null)
				return;
			m_mthClearPatientBaseInfo();
			this.trvTime.Nodes[0].Nodes.Clear ();
			m_mthClearUpSheet();
			m_objAgreed =null;
			m_objCurrentPatient=null;

			txtInPatientID.Tag = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString();
			txtInPatientID.Text=p_objSelectedPatient.m_StrInPatientID;
			m_txtWriter.Text=p_objSelectedPatient.m_ObjPeopleInfo.m_StrFirstName;
			
			m_mthSetPatientBaseInfo(p_objSelectedPatient);
			m_objCurrentPatient=p_objSelectedPatient ;
			m_objBaseCurrentPatient=p_objSelectedPatient;

            m_mthIsReadOnly();
            m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();
			m_mthLoadAllTimeOfAPatient(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString());
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				return (this.trvTime.SelectedNode==trvTime.Nodes[0] || this.trvTime.SelectedNode == null);
			}
		}

		protected override long m_lngSubModify()
		{
			if(this.lblTalkDoctor.Text != MDIParent.strOperatorName)
				return -1;

			if(m_objAgreed==null) return -1;
						
			long lngSave=m_objDomain.lngSave(objOperationAgreedContent(false)); 
			if(lngSave>0)
			{
				m_mthClearUpSheet();

				TreeNode trnTempNode = trvTime.SelectedNode;
				trvTime.SelectedNode = trvTime.Nodes[0];
				trvTime.SelectedNode = trvTime.Nodes[0].FirstNode;
				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("修改失败！");
				return -5;
			}

			
		}

		protected override long m_lngSubAddNew()
		{
			m_objAgreed=new clsOperationAgreed();
//            string strDate="";

			long lngSave=m_objDomain.lngSave(objOperationAgreedContent(true)); 
			if(lngSave>0)
			{
				int intNodeIndex = -1;
				for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
				{
					if(DateTime.Parse(dtpSignatoryTime.Value.ToString("yyyy-MM-dd HH:mm:ss")) == (DateTime)(trvTime.Nodes[0].Nodes[i].Tag))
					{
						intNodeIndex = i;
						break;
					}
				}

				if(intNodeIndex == -1)
				{				
					m_mthAddNodeToTrv(this.dtpSignatoryTime.Value);
				}
				return 1;
			}
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("保存失败！");
				return -5;
			}
			
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <returns></returns>
		protected override long m_lngSubDelete()
		{
			if(this.lblTalkDoctor.Text != MDIParent.strOperatorName)
			{
				clsPublicFunction.ShowInformationMessageBox("对不起,无权删除他人的记录!");
				return 0;
			}

			if(m_objAgreed==null)
				return 0;

			long lngRes=m_objDomain.m_lngDeactive(MDIParent.OperatorID,m_objAgreed.strInPatientID,m_objAgreed.strInPatientDate,m_objAgreed.strCreateDate/*,m_objAgreed.strModifyDate*/);

			if(lngRes>0)
			{
				m_mthClearUpSheet();
				trvTime.SelectedNode.Remove();
			}
			return lngRes ;
		}
		
		protected override long m_lngSubPrint()
		{
//			if(this.trvTime.SelectedNode==null) return 1;
//			
//			if(this.trvTime.SelectedNode.Tag ==null || this.trvTime.SelectedNode.Tag.ToString() == "0")
//			{
//				clsPublicFunction.ShowInformationMessageBox("请选择要打印的申请单的日期！");
//				return 1;
//			}

			if(m_rpdOrderRept == null)
			{
				m_rpdOrderRept = new ReportDocument();
				m_rpdOrderRept.Load(m_strTemplatePath+"rptOperationAgree.rpt");
			}

			m_mthAddNewDataFordtsOperationAgreedDataSet(m_dtsRept);
			
			if(m_blnDirectPrint)
			{
				m_rpdOrderRept.PrintToPrinter(1,true,1,100);
			}
			else
			{
				frmCryReptView objView = new frmCryReptView(m_rpdOrderRept);
//				objView.MdiParent = this.MdiParent;
				objView.ShowDialog();
			}

			return 1;
		

		}

		#endregion 

		# region PublicFuction

		public void Save()
		{
			if(m_objCurrentPatient==null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");				
				return ;
			}

			m_lngSave();

		}

		public void Display()
		{
					

		}
		public void Delete()
		{
			m_lngDelete();

		}
		public void Display(string cardno,string sendcheckdate){}
		public void Display(string strInPatientID,string strInPatientDate,string strCreateDate)
		{
			m_objAgreed=m_objDomain.objDisplay( strInPatientID,strInPatientDate,strCreateDate);
			if(m_objAgreed==null) 
				return ;
			#region CheckBox
			this.m_chkAuris_1.Checked=(m_objAgreed.strAuris_1=="1"? true:false );
			this.m_chkAuris_2.Checked=(m_objAgreed.strAuris_2=="1"? true:false );
			this.m_chkAuris_3.Checked=(m_objAgreed.strAuris_3=="1"? true:false );

			this.m_chkAuris_4.Checked=(m_objAgreed.strAuris_4=="1"? true:false );
			this.m_chkAuris_5.Checked=(m_objAgreed.strAuris_5=="1"? true:false );
			this.m_chkAuris_6.Checked=(m_objAgreed.strAuris_6=="1"? true:false );
			
			this.m_chkAuris_7.Checked=(m_objAgreed.strAuris_7=="1"? true:false );
			this.m_chkAuris_8.Checked=(m_objAgreed.strAuris_8=="1"? true:false );
			this.m_chkAuris_9.Checked=(m_objAgreed.strAuris_9=="1"? true:false );
			
			this.m_chkAuris_10.Checked=(m_objAgreed.strAuris_10=="1"? true:false );
			this.m_chkAuris_11.Checked=(m_objAgreed.strAuris_11=="1"? true:false );
			this.m_chkAuris_12.Checked=(m_objAgreed.strAuris_12=="1"? true:false );
			
			this.m_chkAuris_13.Checked=(m_objAgreed.strAuris_13=="1"? true:false );
			this.m_chkAuris_14.Checked=(m_objAgreed.strAuris_14=="1"? true:false );
			this.m_chkAuris_15.Checked=(m_objAgreed.strAuris_15=="1"? true:false );
			
			this.m_chkAuris_16.Checked=(m_objAgreed.strAuris_16=="1"? true:false );
			this.m_chkAuris_17.Checked=(m_objAgreed.strAuris_17=="1"? true:false );
			this.m_chkAuris_18.Checked=(m_objAgreed.strAuris_18=="1"? true:false );
			
			this.m_chkAuris_19.Checked=(m_objAgreed.strAuris_19=="1"? true:false );
			this.m_chkAuris_20.Checked=(m_objAgreed.strAuris_20=="1"? true:false );
			this.m_chkAuris_21.Checked=(m_objAgreed.strAuris_21=="1"? true:false );
			
			this.m_chkAuris_22.Checked=(m_objAgreed.strAuris_22=="1"? true:false );
			this.m_chkAuris_23.Checked=(m_objAgreed.strAuris_23=="1"? true:false );
			this.m_chkAuris_24.Checked=(m_objAgreed.strAuris_24=="1"? true:false );
			
			this.m_chkAuris_25.Checked=(m_objAgreed.strAuris_25=="1"? true:false );
			this.m_chkAuris_26.Checked=(m_objAgreed.strAuris_26=="1"? true:false );
			this.m_chkAuris_27.Checked=(m_objAgreed.strAuris_27=="1"? true:false );
			
			this.m_chkAuris_28.Checked=(m_objAgreed.strAuris_28=="1"? true:false );
			this.m_chkAuris_29.Checked=(m_objAgreed.strAuris_29=="1"? true:false );
			this.m_chkAuris_30.Checked=(m_objAgreed.strAuris_30=="1"? true:false );

			this.m_chkAuris_31.Checked=(m_objAgreed.strAuris_31=="1"? true:false );
			this.m_chkAuris_32.Checked=(m_objAgreed.strAuris_32=="1"? true:false );
			this.m_chkAuris_33.Checked=(m_objAgreed.strAuris_33=="1"? true:false );
			
			this.m_chkAuris_34.Checked=(m_objAgreed.strAuris_34=="1"? true:false );
			this.m_chkAuris_35.Checked=(m_objAgreed.strAuris_35=="1"? true:false );
			this.m_chkAuris_36.Checked=(m_objAgreed.strAuris_36=="1"? true:false );
			
			this.m_chkAuris_37.Checked=(m_objAgreed.strAuris_37=="1"? true:false );
			this.m_chkAuris_38.Checked=(m_objAgreed.strAuris_38=="1"? true:false );
			
			this.chkFauces_1.Checked=(m_objAgreed.strFauces_1=="1"? true:false );
			this.chkFauces_2.Checked=(m_objAgreed.strFauces_2=="1"? true:false );
			this.chkFauces_3.Checked=(m_objAgreed.strFauces_3=="1"? true:false );
			
			this.chkFauces_4.Checked=(m_objAgreed.strFauces_4=="1"? true:false );
			this.chkFauces_5.Checked=(m_objAgreed.strFauces_5=="1"? true:false );
			this.chkFauces_6.Checked=(m_objAgreed.strFauces_6=="1"? true:false );
			
			this.chkFauces_7.Checked=(m_objAgreed.strFauces_7=="1"? true:false );
			this.chkFauces_8.Checked=(m_objAgreed.strFauces_8=="1"? true:false );
			this.chkFauces_9.Checked=(m_objAgreed.strFauces_9=="1"? true:false );
			
			this.chkFauces_10.Checked=(m_objAgreed.strFauces_10=="1"? true:false );
			this.chkFauces_11.Checked=(m_objAgreed.strFauces_11=="1"? true:false );
			this.chkFauces_12.Checked=(m_objAgreed.strFauces_12=="1"? true:false );
			
			this.m_chkFauces_13.Checked=(m_objAgreed.strFauces_13=="1"? true:false );
			this.chkFauces_14.Checked=(m_objAgreed.strFauces_14=="1"? true:false );
			this.chkFauces_15.Checked=(m_objAgreed.strFauces_15=="1"? true:false );
			
			this.chkFauces_16.Checked=(m_objAgreed.strFauces_16=="1"? true:false );
			this.chkFauces_17.Checked=(m_objAgreed.strFauces_17=="1"? true:false );
			this.chkFauces_18.Checked=(m_objAgreed.strFauces_18=="1"? true:false );
			
			this.chkFauces_19.Checked=(m_objAgreed.strFauces_19=="1"? true:false );
			this.chkFauces_20.Checked=(m_objAgreed.strFauces_20=="1"? true:false );
			this.chkFauces_21.Checked=(m_objAgreed.strFauces_21=="1"? true:false );
			
			this.chkFauces_22.Checked=(m_objAgreed.strFauces_22=="1"? true:false );
			this.chkFauces_23.Checked=(m_objAgreed.strFauces_23=="1"? true:false );
			this.chkFauces_24.Checked=(m_objAgreed.strFauces_24=="1"? true:false );
			
			this.chkHead_1.Checked=(m_objAgreed.strHead_1=="1"? true:false );
			
			this.chkHead_2.Checked=(m_objAgreed.strHead_2=="1"? true:false );
			this.chkHead_3.Checked=(m_objAgreed.strHead_3=="1"? true:false );
			this.chkHead_4.Checked=(m_objAgreed.strHead_4=="1"? true:false );
			
			this.chkHead_5.Checked=(m_objAgreed.strHead_5=="1"? true:false );
			this.chkHead_6.Checked=(m_objAgreed.strHead_6=="1"? true:false );
			this.chkHead_7.Checked=(m_objAgreed.strHead_7=="1"? true:false );
			
			this.chkHead_8.Checked=(m_objAgreed.strHead_8=="1"? true:false );
			this.chkHead_9.Checked=(m_objAgreed.strHead_9=="1"? true:false );
			this.chkHead_10.Checked=(m_objAgreed.strHead_10=="1"? true:false );

			this.m_chkHead_11.Checked=(m_objAgreed.strHead_11=="1"? true:false );
			this.m_chkHead_12.Checked=(m_objAgreed.strHead_12=="1"? true:false );
			this.chkHead_13.Checked=(m_objAgreed.strHead_13=="1"? true:false );
			
			this.chkHead_14.Checked=(m_objAgreed.strHead_14=="1"? true:false );
			this.chkHead_15.Checked=(m_objAgreed.strHead_15=="1"? true:false );
			this.chkHead_16.Checked=(m_objAgreed.strHead_16=="1"? true:false );
			
			this.chkHead_17.Checked=(m_objAgreed.strHead_17=="1"? true:false );
			this.chkHead_18.Checked=(m_objAgreed.strHead_18=="1"? true:false );
			this.m_chkLarynxGullet_1.Checked=(m_objAgreed.strLarynxGullet_1=="1"? true:false );
			
			this.m_chkLarynxGullet_2.Checked=(m_objAgreed.strLarynxGullet_2=="1"? true:false );
			this.m_chkLarynxGullet_3.Checked=(m_objAgreed.strLarynxGullet_3=="1"? true:false );
			this.m_chkLarynxGullet_4.Checked=(m_objAgreed.strLarynxGullet_4=="1"? true:false );
			
			this.m_chkLarynxGullet_5.Checked=(m_objAgreed.strLarynxGullet_5=="1"? true:false );
			this.m_chkLarynxGullet_6.Checked=(m_objAgreed.strLarynxGullet_6=="1"? true:false );
			this.m_chkLarynxGullet_7.Checked=(m_objAgreed.strLarynxGullet_7=="1"? true:false );
			
			this.m_chkLarynxGullet_8.Checked=(m_objAgreed.strLarynxGullet_8=="1"? true:false );
			this.m_chkLarynxGullet_9.Checked=(m_objAgreed.strLarynxGullet_9=="1"? true:false );
			this.m_chkLarynxGullet_10.Checked=(m_objAgreed.strLarynxGullet_10=="1"? true:false );
			
			this.chkLarynxGullet_11.Checked=(m_objAgreed.strLarynxGullet_11=="1"? true:false );
			this.chkLarynxGullet_12.Checked=(m_objAgreed.strLarynxGullet_12=="1"? true:false );
			this.chkLarynxGullet_13.Checked=(m_objAgreed.strLarynxGullet_13=="1"? true:false );
			
			this.chkLarynxGullet_14.Checked=(m_objAgreed.strLarynxGullet_14=="1"? true:false );
			this.chkLarynxGullet_15.Checked=(m_objAgreed.strLarynxGullet_15=="1"? true:false );
			this.chkLarynxGullet_16.Checked=(m_objAgreed.strLarynxGullet_16=="1"? true:false );
			
			this.chkLarynxGullet_17.Checked=(m_objAgreed.strLarynxGullet_17=="1"? true:false );
			this.chkLarynxGullet_18.Checked=(m_objAgreed.strLarynxGullet_18=="1"? true:false );
			this.chkLarynxGullet_19.Checked=(m_objAgreed.strLarynxGullet_19=="1"? true:false );
			
			this.chkLarynxGullet_20.Checked=(m_objAgreed.strLarynxGullet_20=="1"? true:false );
			this.chkLarynxGullet_21.Checked=(m_objAgreed.strLarynxGullet_21=="1"? true:false );
			this.m_chkNose_1.Checked=(m_objAgreed.strNose_1=="1"? true:false );
			
			this.m_chkNose_2.Checked=(m_objAgreed.strNose_2=="1"? true:false );
			this.m_chkNose_3.Checked=(m_objAgreed.strNose_3=="1"? true:false );
			this.m_chkNose_4.Checked=(m_objAgreed.strNose_4=="1"? true:false );
			
			this.m_chkNose_5.Checked=(m_objAgreed.strNose_5=="1"? true:false );
			this.m_chkNose_6.Checked=(m_objAgreed.strNose_6=="1"? true:false );
			this.m_chkNose_7.Checked=(m_objAgreed.strNose_7=="1"? true:false );
			
			this.m_chkNose_8.Checked=(m_objAgreed.strNose_8=="1"? true:false );
			this.m_chkNose_9.Checked=(m_objAgreed.strNose_9=="1"? true:false );
			this.m_chkNose_10.Checked=(m_objAgreed.strNose_10=="1"? true:false );
			
			this.m_chkNose_11.Checked=(m_objAgreed.strNose_11=="1"? true:false );
			this.m_chkNose_12.Checked=(m_objAgreed.strNose_12=="1"? true:false );
			this.m_chkNose_13.Checked=(m_objAgreed.strNose_13=="1"? true:false );
			
			this.m_chkNose_14.Checked=(m_objAgreed.strNose_14=="1"? true:false );
			this.m_chkNose_15.Checked=(m_objAgreed.strNose_15=="1"? true:false );
			this.m_chkNose_16.Checked=(m_objAgreed.strNose_16=="1"? true:false );
			
			this.m_chkNose_17.Checked=(m_objAgreed.strNose_17=="1"? true:false );
			this.m_chkNose_18.Checked=(m_objAgreed.strNose_18=="1"? true:false );
			this.m_chkNose_19.Checked=(m_objAgreed.strNose_19=="1"? true:false );
			
			this.m_chkNose_20.Checked=(m_objAgreed.strNose_20=="1"? true:false );
			this.m_chkNose_21.Checked=(m_objAgreed.strNose_21=="1"? true:false );
			this.m_chkNose_22.Checked=(m_objAgreed.strNose_22=="1"? true:false );
			
			this.m_chkNose_23.Checked=(m_objAgreed.strNose_23=="1"? true:false );
			this.m_chkNose_24.Checked=(m_objAgreed.strNose_24=="1"? true:false );
			this.m_chkNose_25.Checked=(m_objAgreed.strNose_25=="1"? true:false );
			
			this.m_chkNose_26.Checked=(m_objAgreed.strNose_26=="1"? true:false );
			this.m_chkNose_27.Checked=(m_objAgreed.strNose_27=="1"? true:false );
			this.m_chkNose_28.Checked=(m_objAgreed.strNose_28=="1"? true:false );
			
			this.m_chkNose_29.Checked=(m_objAgreed.strNose_29=="1"? true:false );
			this.m_chkNose_30.Checked=(m_objAgreed.strNose_30=="1"? true:false );
			this.m_chkNose_31.Checked=(m_objAgreed.strNose_31=="1"? true:false );

			#endregion 
			
			this.m_txtOperationName.Text=m_objAgreed.strOperationName;
			this.m_txtRelation.Text=m_objAgreed.strRelation;
			this.m_txtRelationID.Text=m_objAgreed.strRelationID;

			this.m_txtRelationSufferer.Text=m_objAgreed.strRelationSufferer;
			this.m_txtBeforeDisgone.Text=m_objAgreed.strBeforeDisgone;
			this.lblTalkDoctor.Text = new clsEmployee( m_objAgreed.strTalkDoc).m_StrFirstName ;

			this.m_txtWriter.Text=m_objAgreed.strSignatory ;
			this.m_txtPhone.Text=m_objAgreed.strPhone ;

			m_objSignTool.m_mtSetSpecialEmployee(m_objAgreed.strCreateUserID);
		}

		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Print()
		{
			m_lngPrint();
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
	
		#endregion

	
		private clsOperationAgreed  objOperationAgreedContent(bool blnIsAddNew)
		{					
			m_objAgreed.strCreateUserID = ((clsEmployee)m_txtSign.Tag).m_StrEmployeeID;

			if(blnIsAddNew==true)
			{					
				m_objAgreed.strTalkDoc=MDIParent.OperatorID;
				m_objAgreed.strInPatientDate = this.txtInPatientID.Tag.ToString();
				m_objAgreed.strInPatientID=this.txtInPatientID.Text.Trim() ;
				m_objAgreed.strCreateDate =this.dtpSignatoryTime.Value.ToString("yyyy-MM-dd HH:mm:ss"); 
			}
			
			m_objAgreed.strStatus ="0";
			m_objAgreed.strIfConfirm  ="0";
			
			#region CheckBox
			m_objAgreed.strAuris_1=(this.m_chkAuris_1.Checked ==true? "1":"0");
			m_objAgreed.strAuris_2=(this.m_chkAuris_2.Checked ==true? "1":"0");
			m_objAgreed.strAuris_3=(this.m_chkAuris_3.Checked ==true? "1":"0");

			m_objAgreed.strAuris_4=(this.m_chkAuris_4.Checked ==true? "1":"0");
			m_objAgreed.strAuris_5=(this.m_chkAuris_5.Checked ==true? "1":"0");
			m_objAgreed.strAuris_6=(this.m_chkAuris_6.Checked ==true? "1":"0");

			m_objAgreed.strAuris_7=(this.m_chkAuris_7.Checked ==true? "1":"0");
			m_objAgreed.strAuris_8=(this.m_chkAuris_8.Checked ==true? "1":"0");
			m_objAgreed.strAuris_9=(this.m_chkAuris_9.Checked ==true? "1":"0");

			m_objAgreed.strAuris_10=(this.m_chkAuris_10.Checked ==true? "1":"0");
			m_objAgreed.strAuris_11=(this.m_chkAuris_11.Checked ==true? "1":"0");
			m_objAgreed.strAuris_12=(this.m_chkAuris_12.Checked ==true? "1":"0");
			
			m_objAgreed.strAuris_13=(this.m_chkAuris_13.Checked ==true? "1":"0");
			m_objAgreed.strAuris_14=(this.m_chkAuris_14.Checked ==true? "1":"0");
			m_objAgreed.strAuris_15=(this.m_chkAuris_15.Checked ==true? "1":"0");

			m_objAgreed.strAuris_16=(this.m_chkAuris_16.Checked ==true? "1":"0");
			m_objAgreed.strAuris_17=(this.m_chkAuris_17.Checked ==true? "1":"0");
			m_objAgreed.strAuris_18=(this.m_chkAuris_18.Checked ==true? "1":"0");

			m_objAgreed.strAuris_19=(this.m_chkAuris_19.Checked ==true? "1":"0");
			m_objAgreed.strAuris_20=(this.m_chkAuris_20.Checked ==true? "1":"0");
			m_objAgreed.strAuris_21=(this.m_chkAuris_21.Checked ==true? "1":"0");

			m_objAgreed.strAuris_22=(this.m_chkAuris_22.Checked ==true? "1":"0");
			m_objAgreed.strAuris_23=(this.m_chkAuris_23.Checked ==true? "1":"0");
			m_objAgreed.strAuris_24=(this.m_chkAuris_24.Checked ==true? "1":"0");

			m_objAgreed.strAuris_25=(this.m_chkAuris_25.Checked ==true? "1":"0");
			m_objAgreed.strAuris_26=(this.m_chkAuris_26.Checked ==true? "1":"0");
			m_objAgreed.strAuris_27=(this.m_chkAuris_27.Checked ==true? "1":"0");

			m_objAgreed.strAuris_28=(this.m_chkAuris_28.Checked ==true? "1":"0");
			m_objAgreed.strAuris_29=(this.m_chkAuris_29.Checked ==true? "1":"0");
			m_objAgreed.strAuris_30=(this.m_chkAuris_30.Checked ==true? "1":"0");

			m_objAgreed.strAuris_31=(this.m_chkAuris_31.Checked ==true? "1":"0");
			m_objAgreed.strAuris_32=(this.m_chkAuris_32.Checked ==true? "1":"0");
			m_objAgreed.strAuris_33=(this.m_chkAuris_33.Checked ==true? "1":"0");

			m_objAgreed.strAuris_34=(this.m_chkAuris_34.Checked ==true? "1":"0");
			m_objAgreed.strAuris_35=(this.m_chkAuris_35.Checked ==true? "1":"0");
			m_objAgreed.strAuris_36=(this.m_chkAuris_36.Checked ==true? "1":"0");

			m_objAgreed.strAuris_37=(this.m_chkAuris_37.Checked ==true? "1":"0");
			m_objAgreed.strAuris_38=(this.m_chkAuris_38.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_1=(this.m_chkLarynxGullet_1.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_2=(this.m_chkLarynxGullet_2.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_3=(this.m_chkLarynxGullet_3.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_4=(this.m_chkLarynxGullet_4.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_5=(this.m_chkLarynxGullet_5.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_6=(this.m_chkLarynxGullet_6.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_7=(this.m_chkLarynxGullet_7.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_8=(this.m_chkLarynxGullet_8.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_9=(this.m_chkLarynxGullet_9.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_10=(this.m_chkLarynxGullet_10.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_11=(this.chkLarynxGullet_11.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_12=(this.chkLarynxGullet_12.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_13=(this.chkLarynxGullet_13.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_14=(this.chkLarynxGullet_14.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_15=(this.chkLarynxGullet_15.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_16=(this.chkLarynxGullet_16.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_17=(this.chkLarynxGullet_17.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_18=(this.chkLarynxGullet_18.Checked ==true? "1":"0");

			m_objAgreed.strLarynxGullet_19=(this.chkLarynxGullet_19.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_20=(this.chkLarynxGullet_20.Checked ==true? "1":"0");
			m_objAgreed.strLarynxGullet_21=(this.chkLarynxGullet_21.Checked ==true? "1":"0");

			m_objAgreed.strNose_1=(this.m_chkNose_1.Checked ==true? "1":"0");
			m_objAgreed.strNose_2=(this.m_chkNose_2.Checked ==true? "1":"0");
			m_objAgreed.strNose_3=(this.m_chkNose_3.Checked ==true? "1":"0");

			m_objAgreed.strNose_4=(this.m_chkNose_4.Checked ==true? "1":"0");
			m_objAgreed.strNose_5=(this.m_chkNose_5.Checked ==true? "1":"0");
			m_objAgreed.strNose_6=(this.m_chkNose_6.Checked ==true? "1":"0");

			m_objAgreed.strNose_7=(this.m_chkNose_7.Checked ==true? "1":"0");
			m_objAgreed.strNose_8=(this.m_chkNose_8.Checked ==true? "1":"0");
			m_objAgreed.strNose_9=(this.m_chkNose_9.Checked ==true? "1":"0");

			m_objAgreed.strNose_10=(this.m_chkNose_10.Checked ==true? "1":"0");
			m_objAgreed.strNose_11=(this.m_chkNose_11.Checked ==true? "1":"0");
			m_objAgreed.strNose_12=(this.m_chkNose_12.Checked ==true? "1":"0");

			m_objAgreed.strNose_13=(this.m_chkNose_13.Checked ==true? "1":"0");
			m_objAgreed.strNose_14=(this.m_chkNose_14.Checked ==true? "1":"0");
			m_objAgreed.strNose_15=(this.m_chkNose_15.Checked ==true? "1":"0");

			m_objAgreed.strNose_16=(this.m_chkNose_16.Checked ==true? "1":"0");
			m_objAgreed.strNose_17=(this.m_chkNose_17.Checked ==true? "1":"0");
			m_objAgreed.strNose_18=(this.m_chkNose_18.Checked ==true? "1":"0");

			m_objAgreed.strNose_19=(this.m_chkNose_19.Checked ==true? "1":"0");
			m_objAgreed.strNose_20=(this.m_chkNose_20.Checked ==true? "1":"0");
			m_objAgreed.strNose_21=(this.m_chkNose_21.Checked ==true? "1":"0");

			m_objAgreed.strNose_22=(this.m_chkNose_22.Checked ==true? "1":"0");
			m_objAgreed.strNose_23=(this.m_chkNose_23.Checked ==true? "1":"0");
			m_objAgreed.strNose_24=(this.m_chkNose_24.Checked ==true? "1":"0");

			m_objAgreed.strNose_25=(this.m_chkNose_25.Checked ==true? "1":"0");
			m_objAgreed.strNose_26=(this.m_chkNose_26.Checked ==true? "1":"0");
			m_objAgreed.strNose_27=(this.m_chkNose_27.Checked ==true? "1":"0");

			m_objAgreed.strNose_28=(this.m_chkNose_28.Checked ==true? "1":"0");
			m_objAgreed.strNose_29=(this.m_chkNose_29.Checked ==true? "1":"0");
			m_objAgreed.strNose_30=(this.m_chkNose_30.Checked ==true? "1":"0");
			m_objAgreed.strNose_31=(this.m_chkNose_31.Checked ==true? "1":"0");
			
			m_objAgreed.strHead_1=(this.chkHead_1.Checked ==true? "1":"0");
			m_objAgreed.strHead_2=(this.chkHead_2.Checked ==true? "1":"0");
			m_objAgreed.strHead_3=(this.chkHead_3.Checked ==true? "1":"0");
			
			m_objAgreed.strHead_4=(this.chkHead_4.Checked ==true? "1":"0");
			m_objAgreed.strHead_5=(this.chkHead_5.Checked ==true? "1":"0");
			m_objAgreed.strHead_6=(this.chkHead_6.Checked ==true? "1":"0");

			m_objAgreed.strHead_7=(this.chkHead_7.Checked ==true? "1":"0");
			m_objAgreed.strHead_8=(this.chkHead_8.Checked ==true? "1":"0");
			m_objAgreed.strHead_9=(this.chkHead_9.Checked ==true? "1":"0");

			m_objAgreed.strHead_10=(this.chkHead_10.Checked ==true? "1":"0");
			m_objAgreed.strHead_11=(this.m_chkHead_11.Checked ==true? "1":"0");
			m_objAgreed.strHead_12=(this.m_chkHead_12.Checked ==true? "1":"0");

			m_objAgreed.strHead_13=(this.chkHead_13.Checked ==true? "1":"0");
			m_objAgreed.strHead_14=(this.chkHead_14.Checked ==true? "1":"0");
			m_objAgreed.strHead_15=(this.chkHead_15.Checked ==true? "1":"0");

			m_objAgreed.strHead_16=(this.chkHead_16.Checked ==true? "1":"0");
			m_objAgreed.strHead_17=(this.chkHead_17.Checked ==true? "1":"0");
			m_objAgreed.strHead_18=(this.chkHead_18.Checked ==true? "1":"0");

			m_objAgreed.strFauces_1=(this.chkFauces_1.Checked ==true? "1":"0");
			m_objAgreed.strFauces_2=(this.chkFauces_2.Checked ==true? "1":"0");
			m_objAgreed.strFauces_3=(this.chkFauces_3.Checked ==true? "1":"0");

			m_objAgreed.strFauces_4=(this.chkFauces_4.Checked ==true? "1":"0");
			m_objAgreed.strFauces_5=(this.chkFauces_5.Checked ==true? "1":"0");
			m_objAgreed.strFauces_6=(this.chkFauces_6.Checked ==true? "1":"0");

			m_objAgreed.strFauces_7=(this.chkFauces_7.Checked ==true? "1":"0");
			m_objAgreed.strFauces_8=(this.chkFauces_8.Checked ==true? "1":"0");
			m_objAgreed.strFauces_9=(this.chkFauces_9.Checked ==true? "1":"0");

			m_objAgreed.strFauces_10=(this.chkFauces_10.Checked ==true? "1":"0");
			m_objAgreed.strFauces_11=(this.chkFauces_11.Checked ==true? "1":"0");
			m_objAgreed.strFauces_12=(this.chkFauces_12.Checked ==true? "1":"0");

			m_objAgreed.strFauces_13=(this.m_chkFauces_13.Checked ==true? "1":"0");
			m_objAgreed.strFauces_14=(this.chkFauces_14.Checked ==true? "1":"0");
			m_objAgreed.strFauces_15=(this.chkFauces_15.Checked ==true? "1":"0");

			m_objAgreed.strFauces_16=(this.chkFauces_16.Checked ==true? "1":"0");
			m_objAgreed.strFauces_17=(this.chkFauces_17.Checked ==true? "1":"0");
			m_objAgreed.strFauces_18=(this.chkFauces_18.Checked ==true? "1":"0");

			m_objAgreed.strFauces_19=(this.chkFauces_19.Checked ==true? "1":"0");
			m_objAgreed.strFauces_20=(this.chkFauces_20.Checked ==true? "1":"0");
			m_objAgreed.strFauces_21=(this.chkFauces_21.Checked ==true? "1":"0");

			m_objAgreed.strFauces_22=(this.chkFauces_22.Checked ==true? "1":"0");
			m_objAgreed.strFauces_23=(this.chkFauces_23.Checked ==true? "1":"0");
			m_objAgreed.strFauces_24=(this.chkFauces_24.Checked ==true? "1":"0");
			#endregion 

            m_objAgreed.strSignatory=this.m_txtWriter.Text.Trim();
			m_objAgreed.strBeforeDisgone=this.m_txtBeforeDisgone.Text.Trim() ;
			m_objAgreed.strOperationName=this.m_txtOperationName.Text.Trim() ;
			m_objAgreed.strRelation=this.m_txtRelation.Text.Trim() ;
			m_objAgreed.strRelationID=this.m_txtRelationID.Text.Trim() ;
			m_objAgreed.strRelationSufferer=this.m_txtRelationSufferer.Text.Trim() ;
			m_objAgreed.strPhone=this.m_txtPhone.Text.Trim();

			return m_objAgreed;
		}


		private void frmOperationAgreedRecord_Load(object sender, System.EventArgs e)
		{
			m_mthSetQuickKeys();

			this.m_lsvInPatientID.Visible=false;
			TreeNode trnNode=new TreeNode("签名日期");
			trnNode.Tag ="0";
			this.trvTime.Nodes.Add(trnNode);

			this.dtpSignatoryTime.m_EnmVisibleFlag=MDIParent.s_ObjRecordDateTimeInfo.m_enmGetRecordTimeFlag(this.Name);
			this.dtpSignatoryTime.m_mthResetSize();

			m_txtBeforeDisgone.Focus();
		}

        protected bool m_blnCanShowDiseaseTrack = true;
		private void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			m_mthRecordChangedToSave();

			m_mthClearUpSheet();
			m_objAgreed =null;
			if(this.trvTime.SelectedNode.Tag ==null) return ;
			this.dtpSignatoryTime.Enabled =true;
			if(this.trvTime.SelectedNode.Tag.ToString()!="0")
			{
                if (!m_blnCanShowDiseaseTrack)
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				Display(txtInPatientID.Text.Trim(),txtInPatientID.Tag.ToString(),trvTime.SelectedNode.Tag.ToString());
				m_mthEnableApplicationForm();
				this.dtpSignatoryTime.Text =this.trvTime.SelectedNode.Tag.ToString();
				this.dtpSignatoryTime.Enabled =false;

				m_strCurrentOpenDate = this.trvTime.SelectedNode.Tag.ToString();

				//当前处于修改记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.Modify );
			}
			else
			{
				m_mthEnableApplicationForm();
				this.dtpSignatoryTime.Value=DateTime.Now;
				this.lblTalkDoctor.Text=MDIParent.OperatorName;
				this.dtpSignatoryTime.Enabled =true;

				m_mthSetDefaultValue(m_objBaseCurrentPatient);

				//当前处于新增记录状态
				MDIParent.m_mthChangeFormText(this,MDIParent.enmFormEditStatus.AddNew);
			}
		
			m_mthAddFormStatusForClosingSave();
		}

		private void m_mthEnableApplicationForm()
		{		
			bool blnEnable= (lblTalkDoctor.Text == MDIParent.OperatorName);
			foreach(Control ctlControl in this.Controls)
			{
				string strTypeName = ctlControl.GetType().Name;				
				if( strTypeName == "CheckBox" || strTypeName == "ctlTimePicker")
				{
					ctlControl.Enabled = blnEnable;
				}				
				else if(strTypeName =="ctlBorderTextBox" && ctlControl.Name!="txtInPatientID" && ctlControl.Name!="m_txtBedNO" && ctlControl.Name!="m_txtPatientName")
					((ctlBorderTextBox)ctlControl).ReadOnly= ! blnEnable;
				else if(strTypeName =="RichTextBox")
					((RichTextBox)ctlControl).ReadOnly=! blnEnable;
				else if(strTypeName =="ctlRichTextBox")
					((ctlRichTextBox)ctlControl).m_BlnReadOnly=! blnEnable;
			}
		}
		
		
		private void m_mthLoadAllTimeOfAPatient(string p_strInPatientID,string p_strInPatientDate)
		{
			
			if(p_strInPatientID ==null || p_strInPatientDate =="") return ;
			DateTime [] m_dtmArr=
				m_objDomain .m_dtmGetTimeInfoOfAPatientArr(p_strInPatientID ,p_strInPatientDate);
			if(m_dtmArr==null) 
			{
				m_mthSetDefaultValue(m_objCurrentPatient);
				return ;
			}

			this.trvTime.Nodes[0].Nodes .Clear();
			for(int i=0;i<m_dtmArr.Length ;i++)
			{		
				string strDate=m_dtmArr[i].ToString("yyyy年MM月dd日 HH:mm:ss");
				TreeNode trnDate=new TreeNode(strDate);
				trnDate.Tag =m_dtmArr[i];
				this.trvTime.Nodes[0].Nodes.Add(trnDate );				
			}

			//对时间节点进行倒序排序
			new clsSortTool().m_mthSortTreeNode(trvTime.Nodes[0],true);
			
			this.trvTime.ExpandAll();

			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[0];
		}
		
		
		private void m_mthClearUpSheet()
		{
			m_strCurrentOpenDate = "";

//			string strTemp="";
//			foreach(Control ctlTemp in this.Controls)
//			{
//				if((ctlTemp.GetType().Name=="ctlBorderTextBox" || ctlTemp.GetType().Name=="RichTextBox" ) && ctlTemp.Name!="txtInPatientID" && ctlTemp.Name != "m_txtBedNO" && ctlTemp.Name != "m_txtPatientName")
//					ctlTemp.Text="";
//				else if(ctlTemp.GetType().Name=="ctlRichTextBox")
//					((ctlRichTextBox)ctlTemp).m_mthClearText();
//				else if(ctlTemp.GetType().Name =="CheckBox")
//				{
//					((CheckBox)ctlTemp).Checked=false;
//					strTemp=strTemp + ctlTemp.Text+ "";
//				}
//			}
			m_mthClear_Recursive(this,new Control[]{txtInPatientID,m_txtBedNO,m_txtPatientName});

			this.dtpSignatoryTime.Value=DateTime.Now;
			this.lblTalkDoctor.Text = MDIParent.strOperatorName;

			if(m_objCurrentPatient!=null)
				this.m_txtWriter.Text=m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName;

			m_objSignTool.m_mthSetDefaulEmployee();
		}
		
		
		private void m_mthAddNodeToTrv(DateTime p_dtmAdd)
		{
			string strDate=p_dtmAdd.ToString("yyyy年MM月dd日 HH:mm:ss");
			TreeNode trnDate=new TreeNode(strDate);
			trnDate.Tag =p_dtmAdd;
			
			int intIndex = trvTime.Nodes[0].Nodes.Count;
			for(int i = 0; i < trvTime.Nodes[0].Nodes.Count; i++)
			{
				if(((DateTime)trvTime.Nodes[0].Nodes[i].Tag) < p_dtmAdd)
				{
					intIndex = i;
					break;
				}
			}

			this.trvTime.Nodes[0].Nodes.Insert(intIndex,trnDate );
			this.trvTime.ExpandAll();
			this.trvTime.SelectedNode = this.trvTime.Nodes[0].Nodes[intIndex];
			
		}
		
		private void m_txtRelationID_LostFocus(object sender, System.EventArgs e)
		{
			try
			{
				if(this.m_txtRelationID.Text!="")
				{
					if( this.m_txtRelationID.Text.Length!=15 && this.m_txtRelationID.Text.Length!=18)
					{
						clsPublicFunction.ShowInformationMessageBox("请输入正确的身份证号码(15位或18位)！" );
						this.m_txtRelationID.Focus();
					}
				}
			}
			catch{}
		}
		private void m_txtWriter_LostFocus(object sender, System.EventArgs e)
		{
			if((m_txtWriter.Text.Trim()!=this.m_txtPatientName.Text) && (m_txtWriter.Text.Trim() !=""))
			{
				clsPublicFunction.ShowInformationMessageBox("患者本人签名不正确");
				m_txtWriter.Text ="";
			}
			    
		}

		#region 添加键盘快捷键
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter					
					break;
					
					//				case 38:
					//				case 40:					
					//				if(sender.GetType().Name=="ctlBorderTextBox" && ((ctlBorderTextBox)sender).Name=="txtInPatientID")
					//				{
					//					m_lsvInPatientID.Visible=true;
					//					SendKeys.Send(  "{tab}");
					//					if( m_lsvInPatientID.Items.Count>0)
					//					{
					//						m_lsvInPatientID.Items[0].Selected=true;
					//						m_lsvInPatientID.Items[0].Focused=true;
					//					}							
					//				}
					//				break;	
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
					blnCanSearch =false;
					this.txtInPatientID.Text ="";
					blnCanSearch =true;
					m_mthClearPatientBaseInfo();
					m_mthClearUpSheet();
					m_objAgreed =null;
					m_objCurrentPatient=null;
					this.trvTime.Nodes[0].Nodes .Clear ();
					this.m_txtWriter.Text ="";
					this.lblTalkDoctor.Text = MDIParent.strOperatorName;
					m_mthEnableApplicationForm();

					break;
				case 117://Search					
					break;
			}	
		}

		#endregion

		#region 打印
		/*
		* DataSet : dtsOperationAgreed
		* DataTable : OperationAgreed
		* 	DataColumn : PatientName(string)
		* 	DataColumn : PatientSex(string)
		* 	DataColumn : PatientAge(string)
		* 	DataColumn : PatientArea(string)
		* 	DataColumn : PatientBed(string)
		* 	DataColumn : InPatientID(string)
		* 	DataColumn : BeforeDisgone(string)
		* 	DataColumn : OperationName(string)
		* 	DataColumn : Auris_1(string)
		* 	DataColumn : Auris_2(string)
		* 	DataColumn : Auris_3(string)
		* 	DataColumn : Auris_4(string)
		* 	DataColumn : Auris_5(string)
		* 	DataColumn : Auris_6(string)
		* 	DataColumn : Auris_7(string)
		* 	DataColumn : Auris_8(string)
		* 	DataColumn : Auris_9(string)
		* 	DataColumn : Auris_10(string)
		* 	DataColumn : Auris_11(string)
		* 	DataColumn : Auris_12(string)
		* 	DataColumn : Auris_13(string)
		* 	DataColumn : Auris_14(string)
		* 	DataColumn : Auris_15(string)
		* 	DataColumn : Auris_16(string)
		* 	DataColumn : Auris_17(string)
		* 	DataColumn : Auris_18(string)
		* 	DataColumn : Auris_19(string)
		* 	DataColumn : Auris_20(string)
		* 	DataColumn : Auris_21(string)
		* 	DataColumn : Auris_22(string)
		* 	DataColumn : Auris_23(string)
		* 	DataColumn : Auris_24(string)
		* 	DataColumn : Auris_25(string)
		* 	DataColumn : Auris_26(string)
		* 	DataColumn : Auris_27(string)
		* 	DataColumn : Auris_28(string)
		* 	DataColumn : Auris_29(string)
		* 	DataColumn : Auris_30(string)
		* 	DataColumn : Auris_31(string)
		* 	DataColumn : Auris_32(string)
		* 	DataColumn : Auris_33(string)
		* 	DataColumn : Auris_34(string)
		* 	DataColumn : Auris_35(string)
		* 	DataColumn : Auris_36(string)
		* 	DataColumn : Auris_37(string)
		* 	DataColumn : Auris_38(string)
		* 	DataColumn : Nose_1(string)
		* 	DataColumn : Nose_2(string)
		* 	DataColumn : Nose_3(string)
		* 	DataColumn : Nose_4(string)
		* 	DataColumn : Nose_5(string)
		* 	DataColumn : Nose_6(string)
		* 	DataColumn : Nose_7(string)
		* 	DataColumn : Nose_8(string)
		* 	DataColumn : Nose_9(string)
		* 	DataColumn : Nose_10(string)
		* 	DataColumn : Nose_11(string)
		* 	DataColumn : Nose_12(string)
		* 	DataColumn : Nose_13(string)
		* 	DataColumn : Nose_14(string)
		* 	DataColumn : Nose_15(string)
		* 	DataColumn : Nose_16(string)
		* 	DataColumn : Nose_17(string)
		* 	DataColumn : Nose_18(string)
		* 	DataColumn : Nose_19(string)
		* 	DataColumn : Nose_20(string)
		* 	DataColumn : Nose_21(string)
		* 	DataColumn : Nose_22(string)
		* 	DataColumn : Nose_23(string)
		* 	DataColumn : Nose_24(string)
		* 	DataColumn : Nose_25(string)
		* 	DataColumn : Nose_26(string)
		* 	DataColumn : Nose_27(string)
		* 	DataColumn : Nose_28(string)
		* 	DataColumn : Nose_29(string)
		* 	DataColumn : Nose_30(string)
		* 	DataColumn : Nose_31(string)
		* 	DataColumn : Fauces_1(string)
		* 	DataColumn : Fauces_2(string)
		* 	DataColumn : Fauces_3(string)
		* 	DataColumn : Fauces_4(string)
		* 	DataColumn : Fauces_5(string)
		* 	DataColumn : Fauces_6(string)
		* 	DataColumn : Fauces_7(string)
		* 	DataColumn : Fauces_8(string)
		* 	DataColumn : Fauces_9(string)
		* 	DataColumn : Fauces_10(string)
		* 	DataColumn : Fauces_11(string)
		* 	DataColumn : Fauces_12(string)
		* 	DataColumn : Fauces_13(string)
		* 	DataColumn : Fauces_14(string)
		* 	DataColumn : Fauces_15(string)
		* 	DataColumn : Fauces_16(string)
		* 	DataColumn : Fauces_17(string)
		* 	DataColumn : Fauces_18(string)
		* 	DataColumn : Fauces_19(string)
		* 	DataColumn : Fauces_20(string)
		* 	DataColumn : Fauces_21(string)
		* 	DataColumn : Fauces_22(string)
		* 	DataColumn : Fauces_23(string)
		* 	DataColumn : Fauces_24(string)
		* 	DataColumn : Head_1(string)
		* 	DataColumn : Head_2(string)
		* 	DataColumn : Head_3(string)
		* 	DataColumn : Head_4(string)
		* 	DataColumn : Head_5(string)
		* 	DataColumn : Head_6(string)
		* 	DataColumn : Head_7(string)
		* 	DataColumn : Head_8(string)
		* 	DataColumn : Head_9(string)
		* 	DataColumn : Head_10(string)
		* 	DataColumn : Head_11(string)
		* 	DataColumn : Head_12(string)
		* 	DataColumn : Head_13(string)
		* 	DataColumn : Head_14(string)
		* 	DataColumn : Head_15(string)
		* 	DataColumn : Head_16(string)
		* 	DataColumn : Head_17(string)
		* 	DataColumn : Head_18(string)
		* 	DataColumn : LarynxGullet_1(string)
		* 	DataColumn : LarynxGullet_2(string)
		* 	DataColumn : LarynxGullet_3(string)
		* 	DataColumn : LarynxGullet_4(string)
		* 	DataColumn : LarynxGullet_5(string)
		* 	DataColumn : LarynxGullet_6(string)
		* 	DataColumn : LarynxGullet_7(string)
		* 	DataColumn : LarynxGullet_8(string)
		* 	DataColumn : LarynxGullet_9(string)
		* 	DataColumn : LarynxGullet_10(string)
		* 	DataColumn : LarynxGullet_11(string)
		* 	DataColumn : LarynxGullet_12(string)
		* 	DataColumn : LarynxGullet_13(string)
		* 	DataColumn : LarynxGullet_14(string)
		* 	DataColumn : LarynxGullet_15(string)
		* 	DataColumn : LarynxGullet_16(string)
		* 	DataColumn : LarynxGullet_17(string)
		* 	DataColumn : LarynxGullet_18(string)
		* 	DataColumn : LarynxGullet_19(string)
		* 	DataColumn : LarynxGullet_20(string)
		* 	DataColumn : LarynxGullet_21(string)
		* 	DataColumn : Relation(string)
		* 	DataColumn : Writer(string)
		* 	DataColumn : Phone(string)
		* 	DataColumn : TalkDoc(string)
		* 	DataColumn : RelationSufferer(string)
		* 	DataColumn : RelationID(string)
		* 	DataColumn : CreateDate(string)
		*/ 
		private DataSet m_dtsInitdtsOperationAgreedDataSet()
		{
			DataSet dsdtsOperationAgreed = new DataSet("dtsOperationAgreed");

			DataTable dtOperationAgreed = new DataTable("OperationAgreed");

			DataColumn dcOperationAgreedPatientName = new DataColumn("PatientName",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedPatientName);

			DataColumn dcOperationAgreedPatientSex = new DataColumn("PatientSex",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedPatientSex);

			DataColumn dcOperationAgreedPatientAge = new DataColumn("PatientAge",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedPatientAge);

			DataColumn dcOperationAgreedPatientArea = new DataColumn("PatientArea",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedPatientArea);

			DataColumn dcOperationAgreedPatientBed = new DataColumn("PatientBed",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedPatientBed);

			DataColumn dcOperationAgreedInPatientID = new DataColumn("InPatientID",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedInPatientID);

			DataColumn dcOperationAgreedBeforeDisgone = new DataColumn("BeforeDisgone",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedBeforeDisgone);

			DataColumn dcOperationAgreedOperationName = new DataColumn("OperationName",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedOperationName);

			DataColumn dcOperationAgreedAuris_1 = new DataColumn("Auris_1",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_1);

			DataColumn dcOperationAgreedAuris_2 = new DataColumn("Auris_2",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_2);

			DataColumn dcOperationAgreedAuris_3 = new DataColumn("Auris_3",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_3);

			DataColumn dcOperationAgreedAuris_4 = new DataColumn("Auris_4",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_4);

			DataColumn dcOperationAgreedAuris_5 = new DataColumn("Auris_5",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_5);

			DataColumn dcOperationAgreedAuris_6 = new DataColumn("Auris_6",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_6);

			DataColumn dcOperationAgreedAuris_7 = new DataColumn("Auris_7",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_7);

			DataColumn dcOperationAgreedAuris_8 = new DataColumn("Auris_8",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_8);

			DataColumn dcOperationAgreedAuris_9 = new DataColumn("Auris_9",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_9);

			DataColumn dcOperationAgreedAuris_10 = new DataColumn("Auris_10",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_10);

			DataColumn dcOperationAgreedAuris_11 = new DataColumn("Auris_11",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_11);

			DataColumn dcOperationAgreedAuris_12 = new DataColumn("Auris_12",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_12);

			DataColumn dcOperationAgreedAuris_13 = new DataColumn("Auris_13",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_13);

			DataColumn dcOperationAgreedAuris_14 = new DataColumn("Auris_14",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_14);

			DataColumn dcOperationAgreedAuris_15 = new DataColumn("Auris_15",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_15);

			DataColumn dcOperationAgreedAuris_16 = new DataColumn("Auris_16",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_16);

			DataColumn dcOperationAgreedAuris_17 = new DataColumn("Auris_17",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_17);

			DataColumn dcOperationAgreedAuris_18 = new DataColumn("Auris_18",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_18);

			DataColumn dcOperationAgreedAuris_19 = new DataColumn("Auris_19",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_19);

			DataColumn dcOperationAgreedAuris_20 = new DataColumn("Auris_20",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_20);

			DataColumn dcOperationAgreedAuris_21 = new DataColumn("Auris_21",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_21);

			DataColumn dcOperationAgreedAuris_22 = new DataColumn("Auris_22",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_22);

			DataColumn dcOperationAgreedAuris_23 = new DataColumn("Auris_23",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_23);

			DataColumn dcOperationAgreedAuris_24 = new DataColumn("Auris_24",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_24);

			DataColumn dcOperationAgreedAuris_25 = new DataColumn("Auris_25",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_25);

			DataColumn dcOperationAgreedAuris_26 = new DataColumn("Auris_26",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_26);

			DataColumn dcOperationAgreedAuris_27 = new DataColumn("Auris_27",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_27);

			DataColumn dcOperationAgreedAuris_28 = new DataColumn("Auris_28",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_28);

			DataColumn dcOperationAgreedAuris_29 = new DataColumn("Auris_29",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_29);

			DataColumn dcOperationAgreedAuris_30 = new DataColumn("Auris_30",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_30);

			DataColumn dcOperationAgreedAuris_31 = new DataColumn("Auris_31",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_31);

			DataColumn dcOperationAgreedAuris_32 = new DataColumn("Auris_32",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_32);

			DataColumn dcOperationAgreedAuris_33 = new DataColumn("Auris_33",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_33);

			DataColumn dcOperationAgreedAuris_34 = new DataColumn("Auris_34",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_34);

			DataColumn dcOperationAgreedAuris_35 = new DataColumn("Auris_35",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_35);

			DataColumn dcOperationAgreedAuris_36 = new DataColumn("Auris_36",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_36);

			DataColumn dcOperationAgreedAuris_37 = new DataColumn("Auris_37",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_37);

			DataColumn dcOperationAgreedAuris_38 = new DataColumn("Auris_38",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedAuris_38);

			DataColumn dcOperationAgreedNose_1 = new DataColumn("Nose_1",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_1);

			DataColumn dcOperationAgreedNose_2 = new DataColumn("Nose_2",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_2);

			DataColumn dcOperationAgreedNose_3 = new DataColumn("Nose_3",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_3);

			DataColumn dcOperationAgreedNose_4 = new DataColumn("Nose_4",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_4);

			DataColumn dcOperationAgreedNose_5 = new DataColumn("Nose_5",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_5);

			DataColumn dcOperationAgreedNose_6 = new DataColumn("Nose_6",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_6);

			DataColumn dcOperationAgreedNose_7 = new DataColumn("Nose_7",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_7);

			DataColumn dcOperationAgreedNose_8 = new DataColumn("Nose_8",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_8);

			DataColumn dcOperationAgreedNose_9 = new DataColumn("Nose_9",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_9);

			DataColumn dcOperationAgreedNose_10 = new DataColumn("Nose_10",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_10);

			DataColumn dcOperationAgreedNose_11 = new DataColumn("Nose_11",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_11);

			DataColumn dcOperationAgreedNose_12 = new DataColumn("Nose_12",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_12);

			DataColumn dcOperationAgreedNose_13 = new DataColumn("Nose_13",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_13);

			DataColumn dcOperationAgreedNose_14 = new DataColumn("Nose_14",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_14);

			DataColumn dcOperationAgreedNose_15 = new DataColumn("Nose_15",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_15);

			DataColumn dcOperationAgreedNose_16 = new DataColumn("Nose_16",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_16);

			DataColumn dcOperationAgreedNose_17 = new DataColumn("Nose_17",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_17);

			DataColumn dcOperationAgreedNose_18 = new DataColumn("Nose_18",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_18);

			DataColumn dcOperationAgreedNose_19 = new DataColumn("Nose_19",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_19);

			DataColumn dcOperationAgreedNose_20 = new DataColumn("Nose_20",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_20);

			DataColumn dcOperationAgreedNose_21 = new DataColumn("Nose_21",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_21);

			DataColumn dcOperationAgreedNose_22 = new DataColumn("Nose_22",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_22);

			DataColumn dcOperationAgreedNose_23 = new DataColumn("Nose_23",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_23);

			DataColumn dcOperationAgreedNose_24 = new DataColumn("Nose_24",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_24);

			DataColumn dcOperationAgreedNose_25 = new DataColumn("Nose_25",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_25);

			DataColumn dcOperationAgreedNose_26 = new DataColumn("Nose_26",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_26);

			DataColumn dcOperationAgreedNose_27 = new DataColumn("Nose_27",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_27);

			DataColumn dcOperationAgreedNose_28 = new DataColumn("Nose_28",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_28);

			DataColumn dcOperationAgreedNose_29 = new DataColumn("Nose_29",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_29);

			DataColumn dcOperationAgreedNose_30 = new DataColumn("Nose_30",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_30);

			DataColumn dcOperationAgreedNose_31 = new DataColumn("Nose_31",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedNose_31);

			DataColumn dcOperationAgreedFauces_1 = new DataColumn("Fauces_1",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_1);

			DataColumn dcOperationAgreedFauces_2 = new DataColumn("Fauces_2",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_2);

			DataColumn dcOperationAgreedFauces_3 = new DataColumn("Fauces_3",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_3);

			DataColumn dcOperationAgreedFauces_4 = new DataColumn("Fauces_4",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_4);

			DataColumn dcOperationAgreedFauces_5 = new DataColumn("Fauces_5",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_5);

			DataColumn dcOperationAgreedFauces_6 = new DataColumn("Fauces_6",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_6);

			DataColumn dcOperationAgreedFauces_7 = new DataColumn("Fauces_7",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_7);

			DataColumn dcOperationAgreedFauces_8 = new DataColumn("Fauces_8",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_8);

			DataColumn dcOperationAgreedFauces_9 = new DataColumn("Fauces_9",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_9);

			DataColumn dcOperationAgreedFauces_10 = new DataColumn("Fauces_10",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_10);

			DataColumn dcOperationAgreedFauces_11 = new DataColumn("Fauces_11",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_11);

			DataColumn dcOperationAgreedFauces_12 = new DataColumn("Fauces_12",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_12);

			DataColumn dcOperationAgreedFauces_13 = new DataColumn("Fauces_13",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_13);

			DataColumn dcOperationAgreedFauces_14 = new DataColumn("Fauces_14",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_14);

			DataColumn dcOperationAgreedFauces_15 = new DataColumn("Fauces_15",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_15);

			DataColumn dcOperationAgreedFauces_16 = new DataColumn("Fauces_16",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_16);

			DataColumn dcOperationAgreedFauces_17 = new DataColumn("Fauces_17",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_17);

			DataColumn dcOperationAgreedFauces_18 = new DataColumn("Fauces_18",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_18);

			DataColumn dcOperationAgreedFauces_19 = new DataColumn("Fauces_19",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_19);

			DataColumn dcOperationAgreedFauces_20 = new DataColumn("Fauces_20",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_20);

			DataColumn dcOperationAgreedFauces_21 = new DataColumn("Fauces_21",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_21);

			DataColumn dcOperationAgreedFauces_22 = new DataColumn("Fauces_22",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_22);

			DataColumn dcOperationAgreedFauces_23 = new DataColumn("Fauces_23",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_23);

			DataColumn dcOperationAgreedFauces_24 = new DataColumn("Fauces_24",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedFauces_24);

			DataColumn dcOperationAgreedHead_1 = new DataColumn("Head_1",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_1);

			DataColumn dcOperationAgreedHead_2 = new DataColumn("Head_2",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_2);

			DataColumn dcOperationAgreedHead_3 = new DataColumn("Head_3",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_3);

			DataColumn dcOperationAgreedHead_4 = new DataColumn("Head_4",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_4);

			DataColumn dcOperationAgreedHead_5 = new DataColumn("Head_5",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_5);

			DataColumn dcOperationAgreedHead_6 = new DataColumn("Head_6",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_6);

			DataColumn dcOperationAgreedHead_7 = new DataColumn("Head_7",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_7);

			DataColumn dcOperationAgreedHead_8 = new DataColumn("Head_8",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_8);

			DataColumn dcOperationAgreedHead_9 = new DataColumn("Head_9",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_9);

			DataColumn dcOperationAgreedHead_10 = new DataColumn("Head_10",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_10);

			DataColumn dcOperationAgreedHead_11 = new DataColumn("Head_11",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_11);

			DataColumn dcOperationAgreedHead_12 = new DataColumn("Head_12",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_12);

			DataColumn dcOperationAgreedHead_13 = new DataColumn("Head_13",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_13);

			DataColumn dcOperationAgreedHead_14 = new DataColumn("Head_14",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_14);

			DataColumn dcOperationAgreedHead_15 = new DataColumn("Head_15",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_15);

			DataColumn dcOperationAgreedHead_16 = new DataColumn("Head_16",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_16);

			DataColumn dcOperationAgreedHead_17 = new DataColumn("Head_17",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_17);

			DataColumn dcOperationAgreedHead_18 = new DataColumn("Head_18",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedHead_18);

			DataColumn dcOperationAgreedLarynxGullet_1 = new DataColumn("LarynxGullet_1",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_1);

			DataColumn dcOperationAgreedLarynxGullet_2 = new DataColumn("LarynxGullet_2",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_2);

			DataColumn dcOperationAgreedLarynxGullet_3 = new DataColumn("LarynxGullet_3",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_3);

			DataColumn dcOperationAgreedLarynxGullet_4 = new DataColumn("LarynxGullet_4",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_4);

			DataColumn dcOperationAgreedLarynxGullet_5 = new DataColumn("LarynxGullet_5",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_5);

			DataColumn dcOperationAgreedLarynxGullet_6 = new DataColumn("LarynxGullet_6",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_6);

			DataColumn dcOperationAgreedLarynxGullet_7 = new DataColumn("LarynxGullet_7",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_7);

			DataColumn dcOperationAgreedLarynxGullet_8 = new DataColumn("LarynxGullet_8",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_8);

			DataColumn dcOperationAgreedLarynxGullet_9 = new DataColumn("LarynxGullet_9",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_9);

			DataColumn dcOperationAgreedLarynxGullet_10 = new DataColumn("LarynxGullet_10",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_10);

			DataColumn dcOperationAgreedLarynxGullet_11 = new DataColumn("LarynxGullet_11",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_11);

			DataColumn dcOperationAgreedLarynxGullet_12 = new DataColumn("LarynxGullet_12",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_12);

			DataColumn dcOperationAgreedLarynxGullet_13 = new DataColumn("LarynxGullet_13",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_13);

			DataColumn dcOperationAgreedLarynxGullet_14 = new DataColumn("LarynxGullet_14",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_14);

			DataColumn dcOperationAgreedLarynxGullet_15 = new DataColumn("LarynxGullet_15",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_15);

			DataColumn dcOperationAgreedLarynxGullet_16 = new DataColumn("LarynxGullet_16",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_16);

			DataColumn dcOperationAgreedLarynxGullet_17 = new DataColumn("LarynxGullet_17",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_17);

			DataColumn dcOperationAgreedLarynxGullet_18 = new DataColumn("LarynxGullet_18",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_18);

			DataColumn dcOperationAgreedLarynxGullet_19 = new DataColumn("LarynxGullet_19",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_19);

			DataColumn dcOperationAgreedLarynxGullet_20 = new DataColumn("LarynxGullet_20",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_20);

			DataColumn dcOperationAgreedLarynxGullet_21 = new DataColumn("LarynxGullet_21",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedLarynxGullet_21);

			DataColumn dcOperationAgreedRelation = new DataColumn("Relation",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedRelation);

			DataColumn dcOperationAgreedWriter = new DataColumn("Writer",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedWriter);

			DataColumn dcOperationAgreedPhone = new DataColumn("Phone",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedPhone);

			DataColumn dcOperationAgreedTalkDoc = new DataColumn("TalkDoc",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedTalkDoc);

			DataColumn dcOperationAgreedRelationSufferer = new DataColumn("RelationSufferer",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedRelationSufferer);

			DataColumn dcOperationAgreedRelationID = new DataColumn("RelationID",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedRelationID);

			DataColumn dcOperationAgreedCreateDate = new DataColumn("CreateDate",typeof(string));

			dtOperationAgreed.Columns.Add(dcOperationAgreedCreateDate);

			dsdtsOperationAgreed.Tables.Add(dtOperationAgreed);

			return dsdtsOperationAgreed;
		}

		/*
		* DataSet : dtsOperationAgreed
		* DataTable : OperationAgreed
		* 	DataColumn0 : PatientName(string)
		* 	DataColumn1: PatientSex(string)
		* 	DataColumn2 : PatientAge(string)
		* 	DataColumn3 : PatientArea(string)
		* 	DataColumn4 : PatientBed(string)
		* 	DataColumn5 : InPatientID(string)
		* 	DataColumn6 : BeforeDisgone(string)
		* 	DataColumn7 : OperationName(string)
		* 	DataColumn8 : Auris_1(string)
		* 	DataColumn9 : Auris_2(string)
		* 	DataColumn10 : Auris_3(string)
		* 	DataColumn11 : Auris_4(string)
		* 	DataColumn12 : Auris_5(string)
		* 	DataColumn13 : Auris_6(string)
		* 	DataColumn14 : Auris_7(string)
		* 	DataColumn15 : Auris_8(string)
		* 	DataColumn16 : Auris_9(string)
		* 	DataColumn17 : Auris_10(string)
		* 	DataColumn18 : Auris_11(string)
		* 	DataColumn19 : Auris_12(string)
		* 	DataColumn20 : Auris_13(string)
		* 	DataColumn21 : Auris_14(string)
		* 	DataColumn22 : Auris_15(string)
		* 	DataColumn23 : Auris_16(string)
		* 	DataColumn24 : Auris_17(string)
		* 	DataColumn25 : Auris_18(string)
		* 	DataColumn26 : Auris_19(string)
		* 	DataColumn27 : Auris_20(string)
		* 	DataColumn28 : Auris_21(string)
		* 	DataColumn29 : Auris_22(string)
		* 	DataColumn30 : Auris_23(string)
		* 	DataColumn31 : Auris_24(string)
		* 	DataColumn32 : Auris_25(string)
		* 	DataColumn33 : Auris_26(string)
		* 	DataColumn34 : Auris_27(string)
		* 	DataColumn35 : Auris_28(string)
		* 	DataColumn36 : Auris_29(string)
		* 	DataColumn37 : Auris_30(string)
		* 	DataColumn38 : Auris_31(string)
		* 	DataColumn39 : Auris_32(string)
		* 	DataColumn40 : Auris_33(string)
		* 	DataColumn41 : Auris_34(string)
		* 	DataColumn42 : Auris_35(string)
		* 	DataColumn43 : Auris_36(string)
		* 	DataColumn44 : Auris_37(string)
		* 	DataColumn45 : Auris_38(string)
		* 	DataColumn46 : Nose_1(string)
		* 	DataColumn47 : Nose_2(string)
		* 	DataColumn48 : Nose_3(string)
		* 	DataColumn49 : Nose_4(string)
		* 	DataColumn50 : Nose_5(string)
		* 	DataColumn51 : Nose_6(string)
		* 	DataColumn52 : Nose_7(string)
		* 	DataColumn53 : Nose_8(string)
		* 	DataColumn54: Nose_9(string)
		* 	DataColumn55 : Nose_10(string)
		* 	DataColumn56 : Nose_11(string)
		* 	DataColumn57 : Nose_12(string)
		* 	DataColumn58 : Nose_13(string)
		* 	DataColumn59 : Nose_14(string)
		* 	DataColumn60 : Nose_15(string)
		* 	DataColumn61 : Nose_16(string)
		* 	DataColumn62 : Nose_17(string)
		* 	DataColumn63 : Nose_18(string)
		* 	DataColumn64 : Nose_19(string)
		* 	DataColumn65 : Nose_20(string)
		* 	DataColumn66 : Nose_21(string)
		* 	DataColumn67 : Nose_22(string)
		* 	DataColumn68 : Nose_23(string)
		* 	DataColumn69 : Nose_24(string)
		* 	DataColumn70 : Nose_25(string)
		* 	DataColumn71 : Nose_26(string)
		* 	DataColumn72 : Nose_27(string)
		* 	DataColumn73 : Nose_28(string)
		* 	DataColumn74 : Nose_29(string)
		* 	DataColumn75 : Nose_30(string)
		* 	DataColumn76 : Nose_31(string)
		* 	DataColumn77 : Fauces_1(string)
		* 	DataColumn78 : Fauces_2(string)
		* 	DataColumn79 : Fauces_3(string)
		* 	DataColumn80 : Fauces_4(string)
		* 	DataColumn81: Fauces_5(string)
		* 	DataColumn82 : Fauces_6(string)
		* 	DataColumn83 : Fauces_7(string)
		* 	DataColumn84 : Fauces_8(string)
		* 	DataColumn85 : Fauces_9(string)
		* 	DataColumn86 : Fauces_10(string)
		* 	DataColumn87 : Fauces_11(string)
		* 	DataColumn88 : Fauces_12(string)
		* 	DataColumn89 : Fauces_13(string)
		* 	DataColumn90 : Fauces_14(string)
		* 	DataColumn91 : Fauces_15(string)
		* 	DataColumn92 : Fauces_16(string)
		* 	DataColumn93 : Fauces_17(string)
		* 	DataColumn94 : Fauces_18(string)
		* 	DataColumn95 : Fauces_19(string)
		* 	DataColumn96 : Fauces_20(string)
		* 	DataColumn97 : Fauces_21(string)
		* 	DataColumn98 : Fauces_22(string)
		* 	DataColumn99 : Fauces_23(string)
		* 	DataColumn100 : Fauces_24(string)
		* 	DataColumn101 : Head_1(string)
		* 	DataColumn102 : Head_2(string)
		* 	DataColumn103 : Head_3(string)
		* 	DataColumn104 : Head_4(string)
		* 	DataColumn105 : Head_5(string)
		* 	DataColumn106 : Head_6(string)
		* 	DataColumn107 : Head_7(string)
		* 	DataColumn108 : Head_8(string)
		* 	DataColumn109 : Head_9(string)
		* 	DataColumn110 : Head_10(string)
		* 	DataColumn111 : Head_11(string)
		* 	DataColumn112 : Head_12(string)
		* 	DataColumn113 : Head_13(string)
		* 	DataColumn114 : Head_14(string)
		* 	DataColumn115 : Head_15(string)
		* 	DataColumn116 : Head_16(string)
		* 	DataColumn117 : Head_17(string)
		* 	DataColumn118 : Head_18(string)
		* 	DataColumn119 : LarynxGullet_1(string)
		* 	DataColumn120 : LarynxGullet_2(string)
		* 	DataColumn121 : LarynxGullet_3(string)
		* 	DataColumn122 : LarynxGullet_4(string)
		* 	DataColumn123 : LarynxGullet_5(string)
		* 	DataColumn124 : LarynxGullet_6(string)
		* 	DataColumn125 : LarynxGullet_7(string)
		* 	DataColumn126 : LarynxGullet_8(string)
		* 	DataColumn127 : LarynxGullet_9(string)
		* 	DataColumn128 : LarynxGullet_10(string)
		* 	DataColumn129 : LarynxGullet_11(string)
		* 	DataColumn130 : LarynxGullet_12(string)
		* 	DataColumn131 : LarynxGullet_13(string)
		* 	DataColumn132 : LarynxGullet_14(string)
		* 	DataColumn133 : LarynxGullet_15(string)
		* 	DataColumn134 : LarynxGullet_16(string)
		* 	DataColumn135 : LarynxGullet_17(string)
		* 	DataColumn136 : LarynxGullet_18(string)
		* 	DataColumn137 : LarynxGullet_19(string)
		* 	DataColumn138: LarynxGullet_20(string)
		* 	DataColumn139 : LarynxGullet_21(string)
		* 	DataColumn140 : Relation(string)
		* 	DataColumn141 : Writer(string)
		* 	DataColumn142 : Phone(string)
		* 	DataColumn143 : TalkDoc(string)
		* 	DataColumn144 : RelationSufferer(string)
		* 	DataColumn145: RelationID(string)
		* 	DataColumn146 : CreateDate(string)
		*/ 
		private void m_mthAddNewDataFordtsOperationAgreedDataSet(DataSet dsdtsOperationAgreed)
		{
			DataTable dtOperationAgreed = dsdtsOperationAgreed.Tables["OPERATIONAGREED"];
			dtOperationAgreed.Rows.Clear();

			object [] objOperationAgreedDatas = new object[147];

			if(m_objCurrentPatient != null)
			{
				if(m_objCurrentPatient.m_ObjPeopleInfo != null)
				{
					objOperationAgreedDatas[0] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName ;
					objOperationAgreedDatas[1] = m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex;
					objOperationAgreedDatas[2] = m_objCurrentPatient.m_ObjPeopleInfo.m_IntAge.ToString()+"岁";
				}
				if(m_objCurrentPatient.m_ObjInBedInfo != null)
				{
					if(m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo != null && m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea != null)
					{
						objOperationAgreedDatas[3] = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
					}

					if(m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo != null && m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed != null)
					{
						objOperationAgreedDatas[4] = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName ;
					}
				}
				objOperationAgreedDatas[5] = m_objCurrentPatient.m_StrInPatientID;
			}

			if(m_objAgreed != null)
			{
				objOperationAgreedDatas[6] = m_objAgreed.strBeforeDisgone ;
				objOperationAgreedDatas[7] = m_objAgreed.strOperationName ;
				objOperationAgreedDatas[8] = (m_objAgreed.strAuris_1=="True"? "√":"" );
				objOperationAgreedDatas[9] = (m_objAgreed.strAuris_2=="True"? "√":"" );
					
				objOperationAgreedDatas[10] = (m_objAgreed.strAuris_3=="True"? "√":"" );
				objOperationAgreedDatas[11] = (m_objAgreed.strAuris_4=="True"? "√":"" );
				objOperationAgreedDatas[12] = (m_objAgreed.strAuris_5=="True"? "√":"" );
				objOperationAgreedDatas[13] = (m_objAgreed.strAuris_6=="True"? "√":"" );
				objOperationAgreedDatas[14] = (m_objAgreed.strAuris_7=="True"? "√":"" );
				objOperationAgreedDatas[15] = (m_objAgreed.strAuris_8=="True"? "√":"" );
				objOperationAgreedDatas[16] = (m_objAgreed.strAuris_9=="True"? "√":"" );
				objOperationAgreedDatas[17] = (m_objAgreed.strAuris_10=="True"? "√":"" );
				objOperationAgreedDatas[18] = (m_objAgreed.strAuris_11=="True"? "√":"" );
				objOperationAgreedDatas[19] = (m_objAgreed.strAuris_12=="True"? "√":"" );
				objOperationAgreedDatas[20] = (m_objAgreed.strAuris_13=="True"? "√":"" );
				objOperationAgreedDatas[21] = (m_objAgreed.strAuris_14=="True"? "√":"" );
				objOperationAgreedDatas[22] = (m_objAgreed.strAuris_15=="True"? "√":"" );
				objOperationAgreedDatas[23] = (m_objAgreed.strAuris_16=="True"? "√":"" );
				objOperationAgreedDatas[24] = (m_objAgreed.strAuris_17=="True"? "√":"" );
				objOperationAgreedDatas[25] = (m_objAgreed.strAuris_18=="True"? "√":"" );
				objOperationAgreedDatas[26] = (m_objAgreed.strAuris_19=="True"? "√":"" );
				objOperationAgreedDatas[27] = (m_objAgreed.strAuris_20=="True"? "√":"" );
				objOperationAgreedDatas[28] = (m_objAgreed.strAuris_21=="True"? "√":"" );
				objOperationAgreedDatas[29] = (m_objAgreed.strAuris_22=="True"? "√":"" );
				objOperationAgreedDatas[30] = (m_objAgreed.strAuris_23=="True"? "√":"" );
				objOperationAgreedDatas[31] = (m_objAgreed.strAuris_24=="True"? "√":"" );
				objOperationAgreedDatas[32] = (m_objAgreed.strAuris_25=="True"? "√":"" );
				objOperationAgreedDatas[33] = (m_objAgreed.strAuris_26=="True"? "√":"" );
				objOperationAgreedDatas[34] = (m_objAgreed.strAuris_27=="True"? "√":"" );
				objOperationAgreedDatas[35] = (m_objAgreed.strAuris_28=="True"? "√":"" );
				objOperationAgreedDatas[36] = (m_objAgreed.strAuris_29=="True"? "√":"" );
				objOperationAgreedDatas[37] = (m_objAgreed.strAuris_30=="True"? "√":"" );
				objOperationAgreedDatas[38] = (m_objAgreed.strAuris_31=="True"? "√":"" );
				objOperationAgreedDatas[39] = (m_objAgreed.strAuris_32=="True"? "√":"" );
				objOperationAgreedDatas[40] = (m_objAgreed.strAuris_33=="True"? "√":"" );
				objOperationAgreedDatas[41] = (m_objAgreed.strAuris_34=="True"? "√":"" );
				objOperationAgreedDatas[42] = (m_objAgreed.strAuris_35=="True"? "√":"" );
				objOperationAgreedDatas[43] = (m_objAgreed.strAuris_36=="True"? "√":"" );
				objOperationAgreedDatas[44] = (m_objAgreed.strAuris_37=="True"? "√":"" );
				objOperationAgreedDatas[45] = (m_objAgreed.strAuris_38=="True"? "√":"" );
		
				objOperationAgreedDatas[46] =(m_objAgreed.strNose_1=="True"? "√":"" );
				objOperationAgreedDatas[47] =(m_objAgreed.strNose_2=="True"? "√":"" );
				objOperationAgreedDatas[48] =(m_objAgreed.strNose_3=="True"? "√":"" );
				objOperationAgreedDatas[49] =(m_objAgreed.strNose_4=="True"? "√":"" );
				objOperationAgreedDatas[50] =(m_objAgreed.strNose_5=="True"? "√":"" );
				objOperationAgreedDatas[51] =(m_objAgreed.strNose_6=="True"? "√":"" );
				objOperationAgreedDatas[52] =(m_objAgreed.strNose_7=="True"? "√":"" );
				objOperationAgreedDatas[53] =(m_objAgreed.strNose_8=="True"? "√":"" );
				objOperationAgreedDatas[54] =(m_objAgreed.strNose_9=="True"? "√":"" );
				objOperationAgreedDatas[55] =(m_objAgreed.strNose_10=="True"? "√":"" );
				objOperationAgreedDatas[56] =(m_objAgreed.strNose_11=="True"? "√":"" );
				objOperationAgreedDatas[57] =(m_objAgreed.strNose_12=="True"? "√":"" );
				objOperationAgreedDatas[58] =(m_objAgreed.strNose_13=="True"? "√":"" );
				objOperationAgreedDatas[59] =(m_objAgreed.strNose_14=="True"? "√":"" );
				objOperationAgreedDatas[60] =(m_objAgreed.strNose_15=="True"? "√":"" );
				objOperationAgreedDatas[61] =(m_objAgreed.strNose_16=="True"? "√":"" );
				objOperationAgreedDatas[62] =(m_objAgreed.strNose_17=="True"? "√":"" );
				objOperationAgreedDatas[63] =(m_objAgreed.strNose_18=="True"? "√":"" );
				objOperationAgreedDatas[64] =(m_objAgreed.strNose_19=="True"? "√":"" );
				objOperationAgreedDatas[65] =(m_objAgreed.strNose_20=="True"? "√":"" );
				objOperationAgreedDatas[66] =(m_objAgreed.strNose_21=="True"? "√":"" );
				objOperationAgreedDatas[67] =(m_objAgreed.strNose_22=="True"? "√":"" );
				objOperationAgreedDatas[68] =(m_objAgreed.strNose_23=="True"? "√":"" );
				objOperationAgreedDatas[69] =(m_objAgreed.strNose_24=="True"? "√":"" );
				objOperationAgreedDatas[70] =(m_objAgreed.strNose_25=="True"? "√":"" );
				objOperationAgreedDatas[71] =(m_objAgreed.strNose_26=="True"? "√":"" );
				objOperationAgreedDatas[72] =(m_objAgreed.strNose_27=="True"? "√":"" );
				objOperationAgreedDatas[73] =(m_objAgreed.strNose_28=="True"? "√":"" );
				objOperationAgreedDatas[74] =(m_objAgreed.strNose_29=="True"? "√":"" );
				objOperationAgreedDatas[75] =(m_objAgreed.strNose_30=="True"? "√":"" );
				objOperationAgreedDatas[76] =(m_objAgreed.strNose_31=="True"? "√":"" );

				objOperationAgreedDatas[77] =(m_objAgreed.strFauces_1=="True"? "√":"" );
				objOperationAgreedDatas[78] =(m_objAgreed.strFauces_2=="True"? "√":"" );
				objOperationAgreedDatas[79] =(m_objAgreed.strFauces_3=="True"? "√":"" );
				objOperationAgreedDatas[80] =(m_objAgreed.strFauces_4=="True"? "√":"" );
				objOperationAgreedDatas[81] =(m_objAgreed.strFauces_5=="True"? "√":"" );
				objOperationAgreedDatas[82] =(m_objAgreed.strFauces_6=="True"? "√":"" );
				objOperationAgreedDatas[83] =(m_objAgreed.strFauces_7=="True"? "√":"" );
				objOperationAgreedDatas[84] =(m_objAgreed.strFauces_8=="True"? "√":"" );
				objOperationAgreedDatas[85] =(m_objAgreed.strFauces_9=="True"? "√":"" );
				objOperationAgreedDatas[86] =(m_objAgreed.strFauces_10=="True"? "√":"" );
				objOperationAgreedDatas[87] =(m_objAgreed.strFauces_11=="True"? "√":"" );
				objOperationAgreedDatas[88] =(m_objAgreed.strFauces_12=="True"? "√":"" );
				objOperationAgreedDatas[89] =(m_objAgreed.strFauces_13=="True"? "√":"" );
				objOperationAgreedDatas[90] =(m_objAgreed.strFauces_14=="True"? "√":"" );
				objOperationAgreedDatas[91] =(m_objAgreed.strFauces_15=="True"? "√":"" );
				objOperationAgreedDatas[92] =(m_objAgreed.strFauces_16=="True"? "√":"" );
				objOperationAgreedDatas[93] =(m_objAgreed.strFauces_17=="True"? "√":"" );
				objOperationAgreedDatas[94] =(m_objAgreed.strFauces_18=="True"? "√":"" );
				objOperationAgreedDatas[95] =(m_objAgreed.strFauces_19=="True"? "√":"" );
				objOperationAgreedDatas[96] =(m_objAgreed.strFauces_20=="True"? "√":"" );
				objOperationAgreedDatas[97] =(m_objAgreed.strFauces_21=="True"? "√":"" );
				objOperationAgreedDatas[98] =(m_objAgreed.strFauces_22=="True"? "√":"" );
				objOperationAgreedDatas[99] =(m_objAgreed.strFauces_23=="True"? "√":"" );
				objOperationAgreedDatas[100] =(m_objAgreed.strFauces_24=="True"? "√":"" );

				objOperationAgreedDatas[101] =(m_objAgreed.strHead_1=="True"? "√":"" );
				objOperationAgreedDatas[102] =(m_objAgreed.strHead_2=="True"? "√":"" );
				objOperationAgreedDatas[103] =(m_objAgreed.strHead_3=="True"? "√":"" );
				objOperationAgreedDatas[104] =(m_objAgreed.strHead_4=="True"? "√":"" );
				objOperationAgreedDatas[105] =(m_objAgreed.strHead_5=="True"? "√":"" );
				objOperationAgreedDatas[106] =(m_objAgreed.strHead_6=="True"? "√":"" );
				objOperationAgreedDatas[107] =(m_objAgreed.strHead_7=="True"? "√":"" );
				objOperationAgreedDatas[108] =(m_objAgreed.strHead_8=="True"? "√":"" );
				objOperationAgreedDatas[109] =(m_objAgreed.strHead_9=="True"? "√":"" );
				objOperationAgreedDatas[110] =(m_objAgreed.strHead_10=="True"? "√":"" );
				objOperationAgreedDatas[111] =(m_objAgreed.strHead_11=="True"? "√":"" );
				objOperationAgreedDatas[112] =(m_objAgreed.strHead_12=="True"? "√":"" );
				objOperationAgreedDatas[113] =(m_objAgreed.strHead_13=="True"? "√":"" );
				objOperationAgreedDatas[114] =(m_objAgreed.strHead_14=="True"? "√":"" );
				objOperationAgreedDatas[115] =(m_objAgreed.strHead_15=="True"? "√":"" );
				objOperationAgreedDatas[116] =(m_objAgreed.strHead_16=="True"? "√":"" );
				objOperationAgreedDatas[117] =(m_objAgreed.strHead_17=="True"? "√":"" );
				objOperationAgreedDatas[118] =(m_objAgreed.strHead_18=="True"? "√":"" );

				objOperationAgreedDatas[119] =(m_objAgreed.strLarynxGullet_1=="True"? "√":"" );
				objOperationAgreedDatas[120] =(m_objAgreed.strLarynxGullet_2=="True"? "√":"" );
				objOperationAgreedDatas[121] =(m_objAgreed.strLarynxGullet_3=="True"? "√":"" );
				objOperationAgreedDatas[122] =(m_objAgreed.strLarynxGullet_4=="True"? "√":"" );
				objOperationAgreedDatas[123] =(m_objAgreed.strLarynxGullet_5=="True"? "√":"" );
				objOperationAgreedDatas[124] =(m_objAgreed.strLarynxGullet_6=="True"? "√":"" );
				objOperationAgreedDatas[125] =(m_objAgreed.strLarynxGullet_7=="True"? "√":"" );
				objOperationAgreedDatas[126] =(m_objAgreed.strLarynxGullet_8=="True"? "√":"" );
				objOperationAgreedDatas[127] =(m_objAgreed.strLarynxGullet_9=="True"? "√":"" );
				objOperationAgreedDatas[128] =(m_objAgreed.strLarynxGullet_10=="True"? "√":"" );
				objOperationAgreedDatas[129] =(m_objAgreed.strLarynxGullet_11=="True"? "√":"" );
				objOperationAgreedDatas[130] =(m_objAgreed.strLarynxGullet_12=="True"? "√":"" );
				objOperationAgreedDatas[131] =(m_objAgreed.strLarynxGullet_13=="True"? "√":"" );
				objOperationAgreedDatas[132] =(m_objAgreed.strLarynxGullet_14=="True"? "√":"" );
				objOperationAgreedDatas[133] =(m_objAgreed.strLarynxGullet_15=="True"? "√":"" );
				objOperationAgreedDatas[134] =(m_objAgreed.strLarynxGullet_16=="True"? "√":"" );
				objOperationAgreedDatas[135] =(m_objAgreed.strLarynxGullet_17=="True"? "√":"" );
				objOperationAgreedDatas[136] =(m_objAgreed.strLarynxGullet_18=="True"? "√":"" );
				objOperationAgreedDatas[137] =(m_objAgreed.strLarynxGullet_19=="True"? "√":"" );
				objOperationAgreedDatas[138] =(m_objAgreed.strLarynxGullet_20=="True"? "√":"" );
				objOperationAgreedDatas[139] =(m_objAgreed.strLarynxGullet_21=="True"? "√":"" );
		
				objOperationAgreedDatas[140] =m_objAgreed.strRelation;
				objOperationAgreedDatas[141] =m_objAgreed.strSignatory;
				objOperationAgreedDatas[142] =m_objAgreed.strPhone;
				objOperationAgreedDatas[143] =new clsEmployee( m_objAgreed.strTalkDoc).m_StrFirstName;
				objOperationAgreedDatas[144] =m_objAgreed.strRelationSufferer;
				objOperationAgreedDatas[145] =m_objAgreed.strRelationID;
				objOperationAgreedDatas[146] =DateTime.Parse(m_objAgreed.strCreateDate).ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat(this.Name));
			}

			dtOperationAgreed.Rows.Add(objOperationAgreedDatas);
			m_rpdOrderRept.Database.Tables["OPERATIONAGREED"].SetDataSource(dtOperationAgreed);

			m_rpdOrderRept.Refresh();

			
		}
		#endregion 

		private void lblRelation_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lbldate_Click(object sender, System.EventArgs e)
		{
		
		}

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{
			if(m_objBaseCurrentPatient==null || m_objBaseCurrentPatient.m_StrInPatientID==null || m_objBaseCurrentPatient.m_DtmSelectedInDate==DateTime.MinValue|| p_dtmRecordDate==DateTime.MinValue )
			{
				clsPublicFunction.ShowInformationMessageBox("参数错误！");
				return ;
			}			
		
			this.trvTime.SelectedNode=trvTime.Nodes[0];
			m_objAgreed=m_objDomain.objGetDeletedRecord(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString ("yyyy-MM-dd HH:mm:ss"),p_dtmRecordDate.ToString ("yyyy-MM-dd HH:mm:ss"));
			if(m_objAgreed==null) 
				return ;
			#region CheckBox
			this.m_chkAuris_1.Checked=(m_objAgreed.strAuris_1=="True"? true:false );
			this.m_chkAuris_2.Checked=(m_objAgreed.strAuris_2=="True"? true:false );
			this.m_chkAuris_3.Checked=(m_objAgreed.strAuris_3=="True"? true:false );

			this.m_chkAuris_4.Checked=(m_objAgreed.strAuris_4=="True"? true:false );
			this.m_chkAuris_5.Checked=(m_objAgreed.strAuris_5=="True"? true:false );
			this.m_chkAuris_6.Checked=(m_objAgreed.strAuris_6=="True"? true:false );
			
			this.m_chkAuris_7.Checked=(m_objAgreed.strAuris_7=="True"? true:false );
			this.m_chkAuris_8.Checked=(m_objAgreed.strAuris_8=="True"? true:false );
			this.m_chkAuris_9.Checked=(m_objAgreed.strAuris_9=="True"? true:false );
			
			this.m_chkAuris_10.Checked=(m_objAgreed.strAuris_10=="True"? true:false );
			this.m_chkAuris_11.Checked=(m_objAgreed.strAuris_11=="True"? true:false );
			this.m_chkAuris_12.Checked=(m_objAgreed.strAuris_12=="True"? true:false );
			
			this.m_chkAuris_13.Checked=(m_objAgreed.strAuris_13=="True"? true:false );
			this.m_chkAuris_14.Checked=(m_objAgreed.strAuris_14=="True"? true:false );
			this.m_chkAuris_15.Checked=(m_objAgreed.strAuris_15=="True"? true:false );
			
			this.m_chkAuris_16.Checked=(m_objAgreed.strAuris_16=="True"? true:false );
			this.m_chkAuris_17.Checked=(m_objAgreed.strAuris_17=="True"? true:false );
			this.m_chkAuris_18.Checked=(m_objAgreed.strAuris_18=="True"? true:false );
			
			this.m_chkAuris_19.Checked=(m_objAgreed.strAuris_19=="True"? true:false );
			this.m_chkAuris_20.Checked=(m_objAgreed.strAuris_20=="True"? true:false );
			this.m_chkAuris_21.Checked=(m_objAgreed.strAuris_21=="True"? true:false );
			
			this.m_chkAuris_22.Checked=(m_objAgreed.strAuris_22=="True"? true:false );
			this.m_chkAuris_23.Checked=(m_objAgreed.strAuris_23=="True"? true:false );
			this.m_chkAuris_24.Checked=(m_objAgreed.strAuris_24=="True"? true:false );
			
			this.m_chkAuris_25.Checked=(m_objAgreed.strAuris_25=="True"? true:false );
			this.m_chkAuris_26.Checked=(m_objAgreed.strAuris_26=="True"? true:false );
			this.m_chkAuris_27.Checked=(m_objAgreed.strAuris_27=="True"? true:false );
			
			this.m_chkAuris_28.Checked=(m_objAgreed.strAuris_28=="True"? true:false );
			this.m_chkAuris_29.Checked=(m_objAgreed.strAuris_29=="True"? true:false );
			this.m_chkAuris_30.Checked=(m_objAgreed.strAuris_30=="True"? true:false );

			this.m_chkAuris_31.Checked=(m_objAgreed.strAuris_31=="True"? true:false );
			this.m_chkAuris_32.Checked=(m_objAgreed.strAuris_32=="True"? true:false );
			this.m_chkAuris_33.Checked=(m_objAgreed.strAuris_33=="True"? true:false );
			
			this.m_chkAuris_34.Checked=(m_objAgreed.strAuris_34=="True"? true:false );
			this.m_chkAuris_35.Checked=(m_objAgreed.strAuris_35=="True"? true:false );
			this.m_chkAuris_36.Checked=(m_objAgreed.strAuris_36=="True"? true:false );
			
			this.m_chkAuris_37.Checked=(m_objAgreed.strAuris_37=="True"? true:false );
			this.m_chkAuris_38.Checked=(m_objAgreed.strAuris_38=="True"? true:false );
			
			this.chkFauces_1.Checked=(m_objAgreed.strFauces_1=="True"? true:false );
			this.chkFauces_2.Checked=(m_objAgreed.strFauces_2=="True"? true:false );
			this.chkFauces_3.Checked=(m_objAgreed.strFauces_3=="True"? true:false );
			
			this.chkFauces_4.Checked=(m_objAgreed.strFauces_4=="True"? true:false );
			this.chkFauces_5.Checked=(m_objAgreed.strFauces_5=="True"? true:false );
			this.chkFauces_6.Checked=(m_objAgreed.strFauces_6=="True"? true:false );
			
			this.chkFauces_7.Checked=(m_objAgreed.strFauces_7=="True"? true:false );
			this.chkFauces_8.Checked=(m_objAgreed.strFauces_8=="True"? true:false );
			this.chkFauces_9.Checked=(m_objAgreed.strFauces_9=="True"? true:false );
			
			this.chkFauces_10.Checked=(m_objAgreed.strFauces_10=="True"? true:false );
			this.chkFauces_11.Checked=(m_objAgreed.strFauces_11=="True"? true:false );
			this.chkFauces_12.Checked=(m_objAgreed.strFauces_12=="True"? true:false );
			
			this.m_chkFauces_13.Checked=(m_objAgreed.strFauces_13=="True"? true:false );
			this.chkFauces_14.Checked=(m_objAgreed.strFauces_14=="True"? true:false );
			this.chkFauces_15.Checked=(m_objAgreed.strFauces_15=="True"? true:false );
			
			this.chkFauces_16.Checked=(m_objAgreed.strFauces_16=="True"? true:false );
			this.chkFauces_17.Checked=(m_objAgreed.strFauces_17=="True"? true:false );
			this.chkFauces_18.Checked=(m_objAgreed.strFauces_18=="True"? true:false );
			
			this.chkFauces_19.Checked=(m_objAgreed.strFauces_19=="True"? true:false );
			this.chkFauces_20.Checked=(m_objAgreed.strFauces_20=="True"? true:false );
			this.chkFauces_21.Checked=(m_objAgreed.strFauces_21=="True"? true:false );
			
			this.chkFauces_22.Checked=(m_objAgreed.strFauces_22=="True"? true:false );
			this.chkFauces_23.Checked=(m_objAgreed.strFauces_23=="True"? true:false );
			this.chkFauces_24.Checked=(m_objAgreed.strFauces_24=="True"? true:false );
			
			this.chkHead_1.Checked=(m_objAgreed.strHead_1=="True"? true:false );
			
			this.chkHead_2.Checked=(m_objAgreed.strHead_2=="True"? true:false );
			this.chkHead_3.Checked=(m_objAgreed.strHead_3=="True"? true:false );
			this.chkHead_4.Checked=(m_objAgreed.strHead_4=="True"? true:false );
			
			this.chkHead_5.Checked=(m_objAgreed.strHead_5=="True"? true:false );
			this.chkHead_6.Checked=(m_objAgreed.strHead_6=="True"? true:false );
			this.chkHead_7.Checked=(m_objAgreed.strHead_7=="True"? true:false );
			
			this.chkHead_8.Checked=(m_objAgreed.strHead_8=="True"? true:false );
			this.chkHead_9.Checked=(m_objAgreed.strHead_9=="True"? true:false );
			this.chkHead_10.Checked=(m_objAgreed.strHead_10=="True"? true:false );

			this.m_chkHead_11.Checked=(m_objAgreed.strHead_11=="True"? true:false );
			this.m_chkHead_12.Checked=(m_objAgreed.strHead_12=="True"? true:false );
			this.chkHead_13.Checked=(m_objAgreed.strHead_13=="True"? true:false );
			
			this.chkHead_14.Checked=(m_objAgreed.strHead_14=="True"? true:false );
			this.chkHead_15.Checked=(m_objAgreed.strHead_15=="True"? true:false );
			this.chkHead_16.Checked=(m_objAgreed.strHead_16=="True"? true:false );
			
			this.chkHead_17.Checked=(m_objAgreed.strHead_17=="True"? true:false );
			this.chkHead_18.Checked=(m_objAgreed.strHead_18=="True"? true:false );
			this.m_chkLarynxGullet_1.Checked=(m_objAgreed.strLarynxGullet_1=="True"? true:false );
			
			this.m_chkLarynxGullet_2.Checked=(m_objAgreed.strLarynxGullet_2=="True"? true:false );
			this.m_chkLarynxGullet_3.Checked=(m_objAgreed.strLarynxGullet_3=="True"? true:false );
			this.m_chkLarynxGullet_4.Checked=(m_objAgreed.strLarynxGullet_4=="True"? true:false );
			
			this.m_chkLarynxGullet_5.Checked=(m_objAgreed.strLarynxGullet_5=="True"? true:false );
			this.m_chkLarynxGullet_6.Checked=(m_objAgreed.strLarynxGullet_6=="True"? true:false );
			this.m_chkLarynxGullet_7.Checked=(m_objAgreed.strLarynxGullet_7=="True"? true:false );
			
			this.m_chkLarynxGullet_8.Checked=(m_objAgreed.strLarynxGullet_8=="True"? true:false );
			this.m_chkLarynxGullet_9.Checked=(m_objAgreed.strLarynxGullet_9=="True"? true:false );
			this.m_chkLarynxGullet_10.Checked=(m_objAgreed.strLarynxGullet_10=="True"? true:false );
			
			this.chkLarynxGullet_11.Checked=(m_objAgreed.strLarynxGullet_11=="True"? true:false );
			this.chkLarynxGullet_12.Checked=(m_objAgreed.strLarynxGullet_12=="True"? true:false );
			this.chkLarynxGullet_13.Checked=(m_objAgreed.strLarynxGullet_13=="True"? true:false );
			
			this.chkLarynxGullet_14.Checked=(m_objAgreed.strLarynxGullet_14=="True"? true:false );
			this.chkLarynxGullet_15.Checked=(m_objAgreed.strLarynxGullet_15=="True"? true:false );
			this.chkLarynxGullet_16.Checked=(m_objAgreed.strLarynxGullet_16=="True"? true:false );
			
			this.chkLarynxGullet_17.Checked=(m_objAgreed.strLarynxGullet_17=="True"? true:false );
			this.chkLarynxGullet_18.Checked=(m_objAgreed.strLarynxGullet_18=="True"? true:false );
			this.chkLarynxGullet_19.Checked=(m_objAgreed.strLarynxGullet_19=="True"? true:false );
			
			this.chkLarynxGullet_20.Checked=(m_objAgreed.strLarynxGullet_20=="True"? true:false );
			this.chkLarynxGullet_21.Checked=(m_objAgreed.strLarynxGullet_21=="True"? true:false );
			this.m_chkNose_1.Checked=(m_objAgreed.strNose_1=="True"? true:false );
			
			this.m_chkNose_2.Checked=(m_objAgreed.strNose_2=="True"? true:false );
			this.m_chkNose_3.Checked=(m_objAgreed.strNose_3=="True"? true:false );
			this.m_chkNose_4.Checked=(m_objAgreed.strNose_4=="True"? true:false );
			
			this.m_chkNose_5.Checked=(m_objAgreed.strNose_5=="True"? true:false );
			this.m_chkNose_6.Checked=(m_objAgreed.strNose_6=="True"? true:false );
			this.m_chkNose_7.Checked=(m_objAgreed.strNose_7=="True"? true:false );
			
			this.m_chkNose_8.Checked=(m_objAgreed.strNose_8=="True"? true:false );
			this.m_chkNose_9.Checked=(m_objAgreed.strNose_9=="True"? true:false );
			this.m_chkNose_10.Checked=(m_objAgreed.strNose_10=="True"? true:false );
			
			this.m_chkNose_11.Checked=(m_objAgreed.strNose_11=="True"? true:false );
			this.m_chkNose_12.Checked=(m_objAgreed.strNose_12=="True"? true:false );
			this.m_chkNose_13.Checked=(m_objAgreed.strNose_13=="True"? true:false );
			
			this.m_chkNose_14.Checked=(m_objAgreed.strNose_14=="True"? true:false );
			this.m_chkNose_15.Checked=(m_objAgreed.strNose_15=="True"? true:false );
			this.m_chkNose_16.Checked=(m_objAgreed.strNose_16=="True"? true:false );
			
			this.m_chkNose_17.Checked=(m_objAgreed.strNose_17=="True"? true:false );
			this.m_chkNose_18.Checked=(m_objAgreed.strNose_18=="True"? true:false );
			this.m_chkNose_19.Checked=(m_objAgreed.strNose_19=="True"? true:false );
			
			this.m_chkNose_20.Checked=(m_objAgreed.strNose_20=="True"? true:false );
			this.m_chkNose_21.Checked=(m_objAgreed.strNose_21=="True"? true:false );
			this.m_chkNose_22.Checked=(m_objAgreed.strNose_22=="True"? true:false );
			
			this.m_chkNose_23.Checked=(m_objAgreed.strNose_23=="True"? true:false );
			this.m_chkNose_24.Checked=(m_objAgreed.strNose_24=="True"? true:false );
			this.m_chkNose_25.Checked=(m_objAgreed.strNose_25=="True"? true:false );
			
			this.m_chkNose_26.Checked=(m_objAgreed.strNose_26=="True"? true:false );
			this.m_chkNose_27.Checked=(m_objAgreed.strNose_27=="True"? true:false );
			this.m_chkNose_28.Checked=(m_objAgreed.strNose_28=="True"? true:false );
			
			this.m_chkNose_29.Checked=(m_objAgreed.strNose_29=="True"? true:false );
			this.m_chkNose_30.Checked=(m_objAgreed.strNose_30=="True"? true:false );
			this.m_chkNose_31.Checked=(m_objAgreed.strNose_31=="True"? true:false );

			#endregion 
			
			this.m_txtOperationName.Text=m_objAgreed.strOperationName;
			this.m_txtRelation.Text=m_objAgreed.strRelation;
			this.m_txtRelationID.Text=m_objAgreed.strRelationID;

			this.m_txtRelationSufferer.Text=m_objAgreed.strRelationSufferer;
			this.m_txtBeforeDisgone.Text=m_objAgreed.strBeforeDisgone;
			this.lblTalkDoctor.Text = new clsEmployee( m_objAgreed.strTalkDoc).m_StrFirstName ;

			this.m_txtWriter.Text=m_objAgreed.strSignatory ;
			this.m_txtPhone.Text=m_objAgreed.strPhone ;			
		}

		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>
		public override int m_IntFormID
		{
			get
			{
				return 22;
			}
		}

		private void m_mthGroupCheck(object sender, System.EventArgs e)
		{
			CheckBox chkGroupCheck = sender as CheckBox;

			if(chkGroupCheck != null)
			{
				string strGroupID = chkGroupCheck.Tag.ToString();
				foreach(Crownwood.Magic.Controls.TabPage page in tabControl1.TabPages)
				{
					if(page.Name.Equals(strGroupID))
					{
						foreach(Control ctlChild in page.Controls)
						{							
							CheckBox chkGroupItem = ctlChild as CheckBox;

							if(chkGroupItem != null)
							{
//								if(strGroupID == chkGroupItem.Tag.ToString())
									chkGroupItem.Checked = chkGroupCheck.Checked;
							}
						}
					}
				}
			}
		}
	
		#region 审核
		private string m_strCurrentOpenDate = "";

		protected override string m_StrCurrentOpenDate
		{
			get
			{
//				if(m_strCurrentOpenDate=="")
//				{
//					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
//					return "";
//				}
//				return m_strCurrentOpenDate;

				if(this.trvTime.SelectedNode==null || this.trvTime.SelectedNode.Tag==null)
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择记录");
					return "";
				}
				return this.trvTime.SelectedNode.Tag.ToString();
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

		private void m_mthSetDefaultValue(clsPatient p_objPatient)
		{
			//默认值
			new clsDefaultValueTool(this,p_objPatient).m_mthSetDefaultValue();

			m_txtPhone.Text = p_objPatient.m_ObjPeopleInfo.m_StrHomePhone;

			//自动串联病名模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient);
			//自动串联手术名称模板
			m_mthSetSpecialPatientTemplateSet(p_objPatient,enmAssociate.Operation);

			//住院病历数据复用
//			clsInPatientCaseHisoryDefaultValue [] objInPatientCaseDefaultValue = new clsInPatientCaseHisoryDefaultDomain().lngGetAllInPatientCaseHisoryDefault(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString());
//			if(objInPatientCaseDefaultValue !=null && objInPatientCaseDefaultValue.Length >0)
//				this.m_txtBeforeDisgone.Text = objInPatientCaseDefaultValue[0].m_strPrimaryDiagnose;
			
//			//术前小结数据复用
//			clsBeforeOperSumShareDomain.stuShare stuValue; 
//			long lngRes = new clsBeforeOperSumShareDomain().m_lngGetShareValue(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"),out stuValue);
//			if(lngRes > 0)
//				m_txtOperationName.Text = stuValue.m_strSpecialHandle;

			//以下做法是不规范的，Domain不可以做窗体的事件，如MessageBox.Show()等,
			//lngRes的返回就是用来判断操作数据库的结果的
//			stuValue = new clsBeforeOperSumShareDomain().m_stuGetShareValue(p_objPatient.m_StrInPatientID,p_objPatient.m_DtmLastInDate.ToString("yyyy-MM-dd HH:mm:ss"));		
//			m_txtOperationName.Text = stuValue.m_strSpecialHandle;
		}

		

		


	}
}

