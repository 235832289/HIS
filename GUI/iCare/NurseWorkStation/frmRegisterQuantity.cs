using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using System.Drawing.Printing ;
using com.digitalwave.controls;
using com.digitalwave.clsRecordsService;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.common.ICD10.Tool;

namespace iCare
{
	/// <summary>
	/// frmRegisterQuantity 的摘要说明。
	/// </summary>
	public class frmRegisterQuantity :  iCare.frmBaseCaseHistory
	{
		private System.Windows.Forms.GroupBox m_grpRegister1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private  System.Windows.Forms.TextBox  m_txtInColumnName1;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem48;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem46;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem45;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem44;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem43;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem42;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem41;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem38;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem36;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem35;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem34;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem33;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem32;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem31;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem28;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem26;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem25;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem24;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem23;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem22;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem21;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem18;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem16;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem15;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem14;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem12;
		private  System.Windows.Forms.TextBox  m_txtOutColumnName1;

		private string _strEmployeeNo=clsEMRLogin.LoginInfo.m_strEmpNo;
		private string _strEmployeeName=clsEMRLogin.LoginInfo.m_strEmpName; 
		private int iCurrentPage=0;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtmRegisterDate2;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtmRegisterDate1;
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
		private System.Windows.Forms.Label m_lblFourthPeriod;
		private System.Windows.Forms.Label m_lblThirdPeriod;
		private System.Windows.Forms.Label m_lblSecondPeriod;
		private System.Windows.Forms.Label m_lblFirstPeriod;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label m_lblPage;
		private System.Windows.Forms.Button m_cmdLast;
		private System.Windows.Forms.Button m_cmdNextPage;
		private System.Windows.Forms.Button m_cmdPrevious;
		private System.Windows.Forms.Button m_cmdFirst;

		
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label29;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem11;
		protected com.digitalwave.controls.ctlRichTextBox m_txtItem13;
		private com.digitalwave.controls.ctlRichTextBox m_txtNureSummary1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private com.digitalwave.controls.ctlRichTextBox m_txtInSummary1;
		private System.Windows.Forms.Label label7;
		private PinkieControls.ButtonXP m_cmdSign;
		private TextBox m_txtSign1;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Button m_cmdNew;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem416;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem414;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem413;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem412;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem411;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem316;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem314;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem313;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem312;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem311;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem216;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem214;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem213;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem212;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem211;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem116;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem114;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem113;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem112;
		private com.digitalwave.controls.ctlRichTextBox m_txtItem111;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label32;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutSummaryRate1;
		private com.digitalwave.controls.ctlRichTextBox m_txtOutSummary1;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.Button m_cmdSummary1;
		private int m_intRegID=0;
		
		private bool m_blnNewRecord=false;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem410;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem49;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem415;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem315;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem215;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem310;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem39;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem210;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem29;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem110;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem19;

		private bool m_blnFirstShow=true;

		public clsRegisterQuantity_PrintTool_GX m_objPrintTool;
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocumentNew;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem17;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem27;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem37;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem47;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboItem115;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmRegisterQuantity()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			m_mthSetNavButton(false);
			//m_objBorderTool=new clsBorderTool(Color.White);

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdSign, m_txtSign1, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);

			m_mthSetRichTextBoxAttribInControl(this);

		
		}
	

		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DataGrid" && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{										
						m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		//得到Textbox的值
		private  void m_mthGetControlValue(string strColName,GroupBox grp,out string p_strText,out string p_strXML )
		{
			p_strText=string.Empty;
			p_strXML=string.Empty;
			com.digitalwave.controls.ctlRichTextBox m_txtTemp=new ctlRichTextBox();
			com.digitalwave.Utility.Controls.ctlComboBox m_cboTemp=new com.digitalwave.Utility.Controls.ctlComboBox();
			foreach(Control subcontrol in grp.Controls)
			{										
                
				if(subcontrol  is com.digitalwave.controls.ctlRichTextBox)
				{
					m_txtTemp=(ctlRichTextBox)subcontrol;	              
					if(subcontrol.Name ==strColName)
					{
						p_strText=m_txtTemp.Text;
						p_strXML=m_txtTemp.m_strGetXmlText(); 
						return;
					}
				}
				else if(subcontrol  is com.digitalwave.Utility.Controls.ctlComboBox)
				{	 
					if(subcontrol.Name ==strColName)
					{
						m_cboTemp=(com.digitalwave.Utility.Controls.ctlComboBox)subcontrol;
						p_strText=m_cboTemp.Text;
						p_strXML=""; 
						return;
					} 
				}

				else if(subcontrol  is System.Windows.Forms.TextBox)
				{
					
					if(subcontrol.Name ==strColName)
					{
						p_strText=subcontrol.Text;
						p_strXML=""; 
						return;
					} 

				}

			} 	
			
		}
		
	
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		}
	
		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		// 获取病程记录的领域层实例
		protected override clsBaseCaseHistoryDomain  m_objGetDomain()
		{
            return new clsBaseCaseHistoryDomain(enmBaseCaseHistoryTypeInfo.RegisterQuantity_VO);
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.m_grpRegister1 = new System.Windows.Forms.GroupBox();
			this.m_cboItem17 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem27 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem37 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem47 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem19 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem110 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem115 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem29 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem210 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem39 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem310 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem215 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem315 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem415 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem49 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboItem410 = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label44 = new System.Windows.Forms.Label();
			this.label40 = new System.Windows.Forms.Label();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label39 = new System.Windows.Forms.Label();
			this.m_txtOutSummaryRate1 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtOutSummary1 = new com.digitalwave.controls.ctlRichTextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.label34 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.m_txtItem416 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem414 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem413 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem412 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem411 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem316 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem314 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem313 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem312 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem311 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem216 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem214 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem213 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem212 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem211 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem116 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem114 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem113 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem112 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem111 = new com.digitalwave.controls.ctlRichTextBox();
			this.label31 = new System.Windows.Forms.Label();
			this.label30 = new System.Windows.Forms.Label();
			this.m_txtNureSummary1 = new com.digitalwave.controls.ctlRichTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtInSummary1 = new com.digitalwave.controls.ctlRichTextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.m_cmdSign = new PinkieControls.ButtonXP();
            this.m_txtSign1 = new System.Windows.Forms.TextBox();
			this.m_txtItem13 = new com.digitalwave.controls.ctlRichTextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.label25 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.m_lblFourthPeriod = new System.Windows.Forms.Label();
			this.m_lblThirdPeriod = new System.Windows.Forms.Label();
			this.m_lblSecondPeriod = new System.Windows.Forms.Label();
			this.m_lblFirstPeriod = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_txtInColumnName1 = new System.Windows.Forms.TextBox();
			this.m_txtItem48 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem46 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem45 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem44 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem43 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem42 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem41 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem38 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem36 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem35 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem34 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem33 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem32 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem31 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem28 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem26 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem25 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem24 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem23 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem22 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem21 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem18 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem16 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem15 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem14 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem12 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtItem11 = new com.digitalwave.controls.ctlRichTextBox();
			this.m_txtOutColumnName1 = new System.Windows.Forms.TextBox();
			this.m_dtmRegisterDate2 = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.m_dtmRegisterDate1 = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.m_lblPage = new System.Windows.Forms.Label();
			this.m_cmdLast = new System.Windows.Forms.Button();
			this.m_cmdNextPage = new System.Windows.Forms.Button();
			this.m_cmdPrevious = new System.Windows.Forms.Button();
			this.m_cmdFirst = new System.Windows.Forms.Button();
			this.m_cmdNew = new System.Windows.Forms.Button();
			this.m_cmdSummary1 = new System.Windows.Forms.Button();
			this.m_pdcPrintDocumentNew = new System.Drawing.Printing.PrintDocument();
			this.m_grpRegister1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_cmdCreateID
			// 
			this.m_cmdCreateID.Location = new System.Drawing.Point(120, 196);
			this.m_cmdCreateID.Name = "m_cmdCreateID";
			this.m_cmdCreateID.Size = new System.Drawing.Size(80, 40);
			this.m_cmdCreateID.Visible = false;
			// 
			// trvTime
			// 
			this.trvTime.ForeColor = System.Drawing.Color.Black;
			this.trvTime.Location = new System.Drawing.Point(8, 12);
			this.trvTime.Name = "trvTime";
			this.trvTime.Size = new System.Drawing.Size(196, 62);
			// 
			// m_dtpCreateDate
			// 
			this.m_dtpCreateDate.Name = "m_dtpCreateDate";
			this.m_dtpCreateDate.Size = new System.Drawing.Size(14, 22);
			this.m_dtpCreateDate.Visible = false;
			// 
			// lblCreateDate
			// 
			this.lblCreateDate.Location = new System.Drawing.Point(304, 80);
			this.lblCreateDate.Name = "lblCreateDate";
			this.lblCreateDate.Visible = false;
			// 
			// m_pdcPrintDocument
			// 
			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
			// 
			// lblNativePlace
			// 
			this.lblNativePlace.Location = new System.Drawing.Point(272, 228);
			this.lblNativePlace.Name = "lblNativePlace";
			this.lblNativePlace.Visible = false;
			// 
			// m_lblNativePlace
			// 
			this.m_lblNativePlace.Location = new System.Drawing.Point(344, 224);
			this.m_lblNativePlace.Name = "m_lblNativePlace";
			this.m_lblNativePlace.Visible = false;
			// 
			// lblOccupation
			// 
			this.lblOccupation.Location = new System.Drawing.Point(216, 216);
			this.lblOccupation.Name = "lblOccupation";
			this.lblOccupation.Visible = false;
			// 
			// m_lblOccupation
			// 
			this.m_lblOccupation.Location = new System.Drawing.Point(264, 216);
			this.m_lblOccupation.Name = "m_lblOccupation";
			this.m_lblOccupation.Visible = false;
			// 
			// m_lblMarriaged
			// 
			this.m_lblMarriaged.Location = new System.Drawing.Point(328, 196);
			this.m_lblMarriaged.Name = "m_lblMarriaged";
			this.m_lblMarriaged.Visible = false;
			// 
			// lblMarriaged
			// 
			this.lblMarriaged.Location = new System.Drawing.Point(272, 196);
			this.lblMarriaged.Name = "lblMarriaged";
			this.lblMarriaged.Visible = false;
			// 
			// m_lblCreateUserName
			// 
			this.m_lblCreateUserName.Location = new System.Drawing.Point(188, 204);
			this.m_lblCreateUserName.Name = "m_lblCreateUserName";
			this.m_lblCreateUserName.Size = new System.Drawing.Size(6, 20);
			// 
			// m_lblLinkMan
			// 
			this.m_lblLinkMan.Name = "m_lblLinkMan";
			this.m_lblLinkMan.Size = new System.Drawing.Size(4, 20);
			this.m_lblLinkMan.Visible = false;
			// 
			// lblLinkMan
			// 
			this.lblLinkMan.Name = "lblLinkMan";
			this.lblLinkMan.Visible = false;
			// 
			// lblAddress
			// 
			this.lblAddress.Location = new System.Drawing.Point(216, 248);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Visible = false;
			// 
			// m_lblAddress
			// 
			this.m_lblAddress.Location = new System.Drawing.Point(264, 244);
			this.m_lblAddress.Name = "m_lblAddress";
			this.m_lblAddress.Visible = false;
			// 
			// ppdPrintPreview
			// 
			this.ppdPrintPreview.ClientSize = new System.Drawing.Size(1024, 721);
			this.ppdPrintPreview.Location = new System.Drawing.Point(-4, -4);
			// 
			// lblSex
			// 
			this.lblSex.Name = "lblSex";
			// 
			// lblAge
			// 
			this.lblAge.Name = "lblAge";
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Name = "lblNameTitle";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Name = "lblSexTitle";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Name = "lblAgeTitle";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Name = "lblAreaTitle";
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Name = "m_lsvInPatientID";
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Name = "txtInPatientID";
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Name = "m_txtPatientName";
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Name = "m_txtBedNO";
			this.m_txtBedNO.Size = new System.Drawing.Size(60, 21);
			// 
			// m_cboArea
			// 
			this.m_cboArea.Name = "m_cboArea";
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Name = "m_lsvPatientName";
			this.m_lsvPatientName.Size = new System.Drawing.Size(114, 6);
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Name = "m_lsvBedNO";
			// 
			// m_cboDept
			// 
			this.m_cboDept.Name = "m_cboDept";
			// 
			// lblDept
			// 
			this.lblDept.Name = "lblDept";
			// 
			// m_cmdNewTemplate
			// 
			this.m_cmdNewTemplate.Name = "m_cmdNewTemplate";
			this.m_cmdNewTemplate.Size = new System.Drawing.Size(84, 70);
			// 
			// m_cmdNext
			// 
			this.m_cmdNext.Location = new System.Drawing.Point(514, 15);
			this.m_cmdNext.Name = "m_cmdNext";
			this.m_cmdNext.Size = new System.Drawing.Size(19, 21);
			this.m_cmdNext.Visible = true;
			// 
			// m_cmdPre
			// 
			this.m_cmdPre.Name = "m_cmdPre";
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Name = "m_lblForTitle";
			// 
			// m_grpRegister1
			// 
			this.m_grpRegister1.Controls.Add(this.m_cboItem17);
			this.m_grpRegister1.Controls.Add(this.m_cboItem27);
			this.m_grpRegister1.Controls.Add(this.m_cboItem37);
			this.m_grpRegister1.Controls.Add(this.m_cboItem47);
			this.m_grpRegister1.Controls.Add(this.m_cboItem19);
			this.m_grpRegister1.Controls.Add(this.m_cboItem110);
			this.m_grpRegister1.Controls.Add(this.m_cboItem115);
			this.m_grpRegister1.Controls.Add(this.m_cboItem29);
			this.m_grpRegister1.Controls.Add(this.m_cboItem210);
			this.m_grpRegister1.Controls.Add(this.m_cboItem39);
			this.m_grpRegister1.Controls.Add(this.m_cboItem310);
			this.m_grpRegister1.Controls.Add(this.m_cboItem215);
			this.m_grpRegister1.Controls.Add(this.m_cboItem315);
			this.m_grpRegister1.Controls.Add(this.m_cboItem415);
			this.m_grpRegister1.Controls.Add(this.m_cboItem49);
			this.m_grpRegister1.Controls.Add(this.m_cboItem410);
			this.m_grpRegister1.Controls.Add(this.label44);
			this.m_grpRegister1.Controls.Add(this.label40);
			this.m_grpRegister1.Controls.Add(this.label41);
			this.m_grpRegister1.Controls.Add(this.label42);
			this.m_grpRegister1.Controls.Add(this.label43);
			this.m_grpRegister1.Controls.Add(this.groupBox2);
			this.m_grpRegister1.Controls.Add(this.label39);
			this.m_grpRegister1.Controls.Add(this.m_txtOutSummaryRate1);
			this.m_grpRegister1.Controls.Add(this.m_txtOutSummary1);
			this.m_grpRegister1.Controls.Add(this.label32);
			this.m_grpRegister1.Controls.Add(this.label34);
			this.m_grpRegister1.Controls.Add(this.label35);
			this.m_grpRegister1.Controls.Add(this.label36);
			this.m_grpRegister1.Controls.Add(this.label37);
			this.m_grpRegister1.Controls.Add(this.label38);
			this.m_grpRegister1.Controls.Add(this.m_txtItem416);
			this.m_grpRegister1.Controls.Add(this.m_txtItem414);
			this.m_grpRegister1.Controls.Add(this.m_txtItem413);
			this.m_grpRegister1.Controls.Add(this.m_txtItem412);
			this.m_grpRegister1.Controls.Add(this.m_txtItem411);
			this.m_grpRegister1.Controls.Add(this.m_txtItem316);
			this.m_grpRegister1.Controls.Add(this.m_txtItem314);
			this.m_grpRegister1.Controls.Add(this.m_txtItem313);
			this.m_grpRegister1.Controls.Add(this.m_txtItem312);
			this.m_grpRegister1.Controls.Add(this.m_txtItem311);
			this.m_grpRegister1.Controls.Add(this.m_txtItem216);
			this.m_grpRegister1.Controls.Add(this.m_txtItem214);
			this.m_grpRegister1.Controls.Add(this.m_txtItem213);
			this.m_grpRegister1.Controls.Add(this.m_txtItem212);
			this.m_grpRegister1.Controls.Add(this.m_txtItem211);
			this.m_grpRegister1.Controls.Add(this.m_txtItem116);
			this.m_grpRegister1.Controls.Add(this.m_txtItem114);
			this.m_grpRegister1.Controls.Add(this.m_txtItem113);
			this.m_grpRegister1.Controls.Add(this.m_txtItem112);
			this.m_grpRegister1.Controls.Add(this.m_txtItem111);
			this.m_grpRegister1.Controls.Add(this.label31);
			this.m_grpRegister1.Controls.Add(this.label30);
			this.m_grpRegister1.Controls.Add(this.m_txtNureSummary1);
			this.m_grpRegister1.Controls.Add(this.label5);
			this.m_grpRegister1.Controls.Add(this.label3);
			this.m_grpRegister1.Controls.Add(this.label1);
			this.m_grpRegister1.Controls.Add(this.m_txtInSummary1);
			this.m_grpRegister1.Controls.Add(this.label7);
			this.m_grpRegister1.Controls.Add(this.m_cmdSign);
			this.m_grpRegister1.Controls.Add(this.m_txtSign1);
			this.m_grpRegister1.Controls.Add(this.m_txtItem13);
			this.m_grpRegister1.Controls.Add(this.label29);
			this.m_grpRegister1.Controls.Add(this.label27);
			this.m_grpRegister1.Controls.Add(this.label25);
			this.m_grpRegister1.Controls.Add(this.label9);
			this.m_grpRegister1.Controls.Add(this.label8);
			this.m_grpRegister1.Controls.Add(this.label6);
			this.m_grpRegister1.Controls.Add(this.groupBox3);
			this.m_grpRegister1.Controls.Add(this.m_lblFourthPeriod);
			this.m_grpRegister1.Controls.Add(this.m_lblThirdPeriod);
			this.m_grpRegister1.Controls.Add(this.m_lblSecondPeriod);
			this.m_grpRegister1.Controls.Add(this.m_lblFirstPeriod);
			this.m_grpRegister1.Controls.Add(this.label4);
			this.m_grpRegister1.Controls.Add(this.label2);
			this.m_grpRegister1.Controls.Add(this.m_txtInColumnName1);
			this.m_grpRegister1.Controls.Add(this.m_txtItem48);
			this.m_grpRegister1.Controls.Add(this.m_txtItem46);
			this.m_grpRegister1.Controls.Add(this.m_txtItem45);
			this.m_grpRegister1.Controls.Add(this.m_txtItem44);
			this.m_grpRegister1.Controls.Add(this.m_txtItem43);
			this.m_grpRegister1.Controls.Add(this.m_txtItem42);
			this.m_grpRegister1.Controls.Add(this.m_txtItem41);
			this.m_grpRegister1.Controls.Add(this.m_txtItem38);
			this.m_grpRegister1.Controls.Add(this.m_txtItem36);
			this.m_grpRegister1.Controls.Add(this.m_txtItem35);
			this.m_grpRegister1.Controls.Add(this.m_txtItem34);
			this.m_grpRegister1.Controls.Add(this.m_txtItem33);
			this.m_grpRegister1.Controls.Add(this.m_txtItem32);
			this.m_grpRegister1.Controls.Add(this.m_txtItem31);
			this.m_grpRegister1.Controls.Add(this.m_txtItem28);
			this.m_grpRegister1.Controls.Add(this.m_txtItem26);
			this.m_grpRegister1.Controls.Add(this.m_txtItem25);
			this.m_grpRegister1.Controls.Add(this.m_txtItem24);
			this.m_grpRegister1.Controls.Add(this.m_txtItem23);
			this.m_grpRegister1.Controls.Add(this.m_txtItem22);
			this.m_grpRegister1.Controls.Add(this.m_txtItem21);
			this.m_grpRegister1.Controls.Add(this.m_txtItem18);
			this.m_grpRegister1.Controls.Add(this.m_txtItem16);
			this.m_grpRegister1.Controls.Add(this.m_txtItem15);
			this.m_grpRegister1.Controls.Add(this.m_txtItem14);
			this.m_grpRegister1.Controls.Add(this.m_txtItem12);
			this.m_grpRegister1.Controls.Add(this.m_txtItem11);
			this.m_grpRegister1.Controls.Add(this.m_txtOutColumnName1);
			this.m_grpRegister1.Controls.Add(this.m_dtmRegisterDate2);
			this.m_grpRegister1.Location = new System.Drawing.Point(8, 110);
			this.m_grpRegister1.Name = "m_grpRegister1";
			this.m_grpRegister1.Size = new System.Drawing.Size(832, 484);
			this.m_grpRegister1.TabIndex = 10000055;
			this.m_grpRegister1.TabStop = false;
			// 
			// m_cboItem17
			// 
			this.m_cboItem17.AccessibleDescription = "出入量登记>>出量>>其它1";
			this.m_cboItem17.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem17.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem17.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem17.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem17.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem17.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem17.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem17.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem17.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem17.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem17.Location = new System.Drawing.Point(566, 72);
			this.m_cboItem17.m_BlnEnableItemEventMenu = true;
			this.m_cboItem17.Name = "m_cboItem17";
			this.m_cboItem17.SelectedIndex = -1;
			this.m_cboItem17.SelectedItem = null;
			this.m_cboItem17.SelectionStart = 0;
			this.m_cboItem17.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem17.TabIndex = 10000062;
			this.m_cboItem17.Tag = "Out";
			this.m_cboItem17.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem17.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem27
			// 
			this.m_cboItem27.AccessibleDescription = "出入量登记>>出量>>其它2";
			this.m_cboItem27.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem27.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem27.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem27.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem27.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem27.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem27.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem27.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem27.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem27.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem27.Location = new System.Drawing.Point(566, 109);
			this.m_cboItem27.m_BlnEnableItemEventMenu = true;
			this.m_cboItem27.Name = "m_cboItem27";
			this.m_cboItem27.SelectedIndex = -1;
			this.m_cboItem27.SelectedItem = null;
			this.m_cboItem27.SelectionStart = 0;
			this.m_cboItem27.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem27.TabIndex = 10000082;
			this.m_cboItem27.Tag = "Out";
			this.m_cboItem27.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem27.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem37
			// 
			this.m_cboItem37.AccessibleDescription = "出入量登记>>出量>>其它3";
			this.m_cboItem37.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem37.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem37.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem37.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem37.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem37.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem37.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem37.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem37.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem37.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem37.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem37.Location = new System.Drawing.Point(566, 146);
			this.m_cboItem37.m_BlnEnableItemEventMenu = true;
			this.m_cboItem37.Name = "m_cboItem37";
			this.m_cboItem37.SelectedIndex = -1;
			this.m_cboItem37.SelectedItem = null;
			this.m_cboItem37.SelectionStart = 0;
			this.m_cboItem37.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem37.TabIndex = 10000098;
			this.m_cboItem37.Tag = "Out";
			this.m_cboItem37.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem37.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem47
			// 
			this.m_cboItem47.AccessibleDescription = "出入量登记>>出量>>其它4";
			this.m_cboItem47.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem47.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem47.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem47.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem47.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem47.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem47.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem47.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem47.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem47.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem47.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem47.Location = new System.Drawing.Point(566, 183);
			this.m_cboItem47.m_BlnEnableItemEventMenu = true;
			this.m_cboItem47.Name = "m_cboItem47";
			this.m_cboItem47.SelectedIndex = -1;
			this.m_cboItem47.SelectedItem = null;
			this.m_cboItem47.SelectionStart = 0;
			this.m_cboItem47.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem47.TabIndex = 10000114;
			this.m_cboItem47.Tag = "Out";
			this.m_cboItem47.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem47.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem19
			// 
			this.m_cboItem19.AccessibleDescription = "出入量登记>>饮水1";
			this.m_cboItem19.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem19.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem19.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem19.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem19.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem19.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem19.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem19.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem19.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem19.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem19.Location = new System.Drawing.Point(104, 272);
			this.m_cboItem19.m_BlnEnableItemEventMenu = true;
			this.m_cboItem19.Name = "m_cboItem19";
			this.m_cboItem19.SelectedIndex = -1;
			this.m_cboItem19.SelectedItem = null;
			this.m_cboItem19.SelectionStart = 0;
			this.m_cboItem19.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem19.TabIndex = 10000193;
			this.m_cboItem19.Tag = "In";
			this.m_cboItem19.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem19.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem110
			// 
			this.m_cboItem110.AccessibleDescription = "出入量登记>>食物1";
			this.m_cboItem110.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem110.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem110.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem110.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem110.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem110.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem110.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem110.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem110.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem110.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem110.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem110.Location = new System.Drawing.Point(181, 272);
			this.m_cboItem110.m_BlnEnableItemEventMenu = true;
			this.m_cboItem110.Name = "m_cboItem110";
			this.m_cboItem110.SelectedIndex = -1;
			this.m_cboItem110.SelectedItem = null;
			this.m_cboItem110.SelectionStart = 0;
			this.m_cboItem110.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem110.TabIndex = 10000194;
			this.m_cboItem110.Tag = "In";
			this.m_cboItem110.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem110.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem115
			// 
			this.m_cboItem115.AccessibleDescription = "出入量登记>>入量>>其它1";
			this.m_cboItem115.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem115.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem115.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem115.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem115.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem115.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem115.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem115.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem115.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem115.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem115.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem115.Location = new System.Drawing.Point(566, 272);
			this.m_cboItem115.m_BlnEnableItemEventMenu = true;
			this.m_cboItem115.Name = "m_cboItem115";
			this.m_cboItem115.SelectedIndex = -1;
			this.m_cboItem115.SelectedItem = null;
			this.m_cboItem115.SelectionStart = 0;
			this.m_cboItem115.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem115.TabIndex = 10000199;
			this.m_cboItem115.Tag = "In";
			this.m_cboItem115.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem115.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem29
			// 
			this.m_cboItem29.AccessibleDescription = "出入量登记>>饮水2";
			this.m_cboItem29.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem29.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem29.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem29.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem29.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem29.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem29.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem29.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem29.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem29.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem29.Location = new System.Drawing.Point(104, 310);
			this.m_cboItem29.m_BlnEnableItemEventMenu = true;
			this.m_cboItem29.Name = "m_cboItem29";
			this.m_cboItem29.SelectedIndex = -1;
			this.m_cboItem29.SelectedItem = null;
			this.m_cboItem29.SelectionStart = 0;
			this.m_cboItem29.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem29.TabIndex = 10000201;
			this.m_cboItem29.Tag = "In";
			this.m_cboItem29.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem29.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem210
			// 
			this.m_cboItem210.AccessibleDescription = "出入量登记>>食物2";
			this.m_cboItem210.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem210.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem210.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem210.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem210.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem210.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem210.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem210.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem210.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem210.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem210.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem210.Location = new System.Drawing.Point(181, 310);
			this.m_cboItem210.m_BlnEnableItemEventMenu = true;
			this.m_cboItem210.Name = "m_cboItem210";
			this.m_cboItem210.SelectedIndex = -1;
			this.m_cboItem210.SelectedItem = null;
			this.m_cboItem210.SelectionStart = 0;
			this.m_cboItem210.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem210.TabIndex = 10000202;
			this.m_cboItem210.Tag = "In";
			this.m_cboItem210.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem210.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem39
			// 
			this.m_cboItem39.AccessibleDescription = "出入量登记>>饮水3";
			this.m_cboItem39.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem39.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem39.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem39.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem39.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem39.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem39.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem39.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem39.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem39.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem39.Location = new System.Drawing.Point(104, 348);
			this.m_cboItem39.m_BlnEnableItemEventMenu = true;
			this.m_cboItem39.Name = "m_cboItem39";
			this.m_cboItem39.SelectedIndex = -1;
			this.m_cboItem39.SelectedItem = null;
			this.m_cboItem39.SelectionStart = 0;
			this.m_cboItem39.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem39.TabIndex = 10000209;
			this.m_cboItem39.Tag = "In";
			this.m_cboItem39.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem39.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem310
			// 
			this.m_cboItem310.AccessibleDescription = "出入量登记>>食物3";
			this.m_cboItem310.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem310.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem310.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem310.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem310.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem310.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem310.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem310.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem310.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem310.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem310.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem310.Location = new System.Drawing.Point(181, 348);
			this.m_cboItem310.m_BlnEnableItemEventMenu = true;
			this.m_cboItem310.Name = "m_cboItem310";
			this.m_cboItem310.SelectedIndex = -1;
			this.m_cboItem310.SelectedItem = null;
			this.m_cboItem310.SelectionStart = 0;
			this.m_cboItem310.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem310.TabIndex = 10000210;
			this.m_cboItem310.Tag = "In";
			this.m_cboItem310.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem310.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem215
			// 
			this.m_cboItem215.AccessibleDescription = "出入量登记>>入量>>其它2";
			this.m_cboItem215.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem215.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem215.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem215.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem215.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem215.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem215.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem215.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem215.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem215.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem215.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem215.Location = new System.Drawing.Point(566, 310);
			this.m_cboItem215.m_BlnEnableItemEventMenu = true;
			this.m_cboItem215.Name = "m_cboItem215";
			this.m_cboItem215.SelectedIndex = -1;
			this.m_cboItem215.SelectedItem = null;
			this.m_cboItem215.SelectionStart = 0;
			this.m_cboItem215.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem215.TabIndex = 10000207;
			this.m_cboItem215.Tag = "In";
			this.m_cboItem215.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem215.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem315
			// 
			this.m_cboItem315.AccessibleDescription = "出入量登记>>入量>>其它3";
			this.m_cboItem315.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem315.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem315.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem315.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem315.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem315.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem315.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem315.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem315.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem315.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem315.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem315.Location = new System.Drawing.Point(566, 348);
			this.m_cboItem315.m_BlnEnableItemEventMenu = true;
			this.m_cboItem315.Name = "m_cboItem315";
			this.m_cboItem315.SelectedIndex = -1;
			this.m_cboItem315.SelectedItem = null;
			this.m_cboItem315.SelectionStart = 0;
			this.m_cboItem315.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem315.TabIndex = 10000215;
			this.m_cboItem315.Tag = "In";
			this.m_cboItem315.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem315.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem415
			// 
			this.m_cboItem415.AccessibleDescription = "出入量登记>>入量>>其它4";
			this.m_cboItem415.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem415.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem415.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem415.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem415.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem415.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem415.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem415.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem415.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem415.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem415.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem415.Location = new System.Drawing.Point(566, 384);
			this.m_cboItem415.m_BlnEnableItemEventMenu = true;
			this.m_cboItem415.Name = "m_cboItem415";
			this.m_cboItem415.SelectedIndex = -1;
			this.m_cboItem415.SelectedItem = null;
			this.m_cboItem415.SelectionStart = 0;
			this.m_cboItem415.Size = new System.Drawing.Size(176, 23);
			this.m_cboItem415.TabIndex = 10000223;
			this.m_cboItem415.Tag = "In";
			this.m_cboItem415.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem415.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem49
			// 
			this.m_cboItem49.AccessibleDescription = "出入量登记>>饮水4";
			this.m_cboItem49.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem49.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem49.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem49.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem49.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem49.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem49.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem49.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem49.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem49.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem49.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem49.Location = new System.Drawing.Point(104, 384);
			this.m_cboItem49.m_BlnEnableItemEventMenu = true;
			this.m_cboItem49.Name = "m_cboItem49";
			this.m_cboItem49.SelectedIndex = -1;
			this.m_cboItem49.SelectedItem = null;
			this.m_cboItem49.SelectionStart = 0;
			this.m_cboItem49.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem49.TabIndex = 10000217;
			this.m_cboItem49.Tag = "In";
			this.m_cboItem49.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem49.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboItem410
			// 
			this.m_cboItem410.AccessibleDescription = "出入量登记>>食物4";
			this.m_cboItem410.BorderColor = System.Drawing.Color.Black;
			this.m_cboItem410.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_cboItem410.DropButtonCursor = System.Windows.Forms.Cursors.Default;
			this.m_cboItem410.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboItem410.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
			this.m_cboItem410.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem410.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboItem410.ListBackColor = System.Drawing.Color.White;
			this.m_cboItem410.ListForeColor = System.Drawing.Color.Black;
			this.m_cboItem410.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboItem410.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboItem410.Location = new System.Drawing.Point(181, 384);
			this.m_cboItem410.m_BlnEnableItemEventMenu = true;
			this.m_cboItem410.Name = "m_cboItem410";
			this.m_cboItem410.SelectedIndex = -1;
			this.m_cboItem410.SelectedItem = null;
			this.m_cboItem410.SelectionStart = 0;
			this.m_cboItem410.Size = new System.Drawing.Size(72, 23);
			this.m_cboItem410.TabIndex = 10000218;
			this.m_cboItem410.Tag = "In";
			this.m_cboItem410.TextBackColor = System.Drawing.Color.White;
			this.m_cboItem410.TextForeColor = System.Drawing.Color.Black;
			// 
			// label44
			// 
			this.label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label44.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label44.ForeColor = System.Drawing.SystemColors.Control;
			this.label44.Location = new System.Drawing.Point(96, 240);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(2, 320);
			this.label44.TabIndex = 10000239;
			// 
			// label40
			// 
			this.label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label40.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label40.ForeColor = System.Drawing.SystemColors.Control;
			this.label40.Location = new System.Drawing.Point(-16, 412);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(888, 2);
			this.label40.TabIndex = 10000238;
			// 
			// label41
			// 
			this.label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label41.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label41.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label41.ForeColor = System.Drawing.SystemColors.Control;
			this.label41.Location = new System.Drawing.Point(-16, 375);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(888, 2);
			this.label41.TabIndex = 10000237;
			// 
			// label42
			// 
			this.label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label42.ForeColor = System.Drawing.SystemColors.Control;
			this.label42.Location = new System.Drawing.Point(-16, 338);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(888, 2);
			this.label42.TabIndex = 10000236;
			// 
			// label43
			// 
			this.label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label43.ForeColor = System.Drawing.SystemColors.Control;
			this.label43.Location = new System.Drawing.Point(-16, 299);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(888, 2);
			this.label43.TabIndex = 10000235;
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(-16, 265);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(888, 2);
			this.groupBox2.TabIndex = 10000234;
			this.groupBox2.TabStop = false;
			// 
			// label39
			// 
			this.label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label39.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label39.ForeColor = System.Drawing.SystemColors.Control;
			this.label39.Location = new System.Drawing.Point(-16, 240);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(888, 2);
			this.label39.TabIndex = 10000233;
			// 
			// m_txtOutSummaryRate1
			// 
			this.m_txtOutSummaryRate1.Location = new System.Drawing.Point(352, 451);
			this.m_txtOutSummaryRate1.m_BlnIgnoreUserInfo = false;
			this.m_txtOutSummaryRate1.m_BlnPartControl = false;
			this.m_txtOutSummaryRate1.m_BlnReadOnly = false;
			this.m_txtOutSummaryRate1.m_BlnUnderLineDST = false;
			this.m_txtOutSummaryRate1.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtOutSummaryRate1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtOutSummaryRate1.m_IntCanModifyTime = 6;
			this.m_txtOutSummaryRate1.m_IntPartControlLength = 0;
			this.m_txtOutSummaryRate1.m_IntPartControlStartIndex = 0;
			this.m_txtOutSummaryRate1.m_StrUserID = "";
			this.m_txtOutSummaryRate1.m_StrUserName = "";
			this.m_txtOutSummaryRate1.MaxLength = 50;
			this.m_txtOutSummaryRate1.Multiline = false;
			this.m_txtOutSummaryRate1.Name = "m_txtOutSummaryRate1";
			this.m_txtOutSummaryRate1.Size = new System.Drawing.Size(80, 23);
			this.m_txtOutSummaryRate1.TabIndex = 10000228;
			this.m_txtOutSummaryRate1.Tag = "Summary";
			this.m_txtOutSummaryRate1.Text = "";
			// 
			// m_txtOutSummary1
			// 
			this.m_txtOutSummary1.Location = new System.Drawing.Point(184, 448);
			this.m_txtOutSummary1.m_BlnIgnoreUserInfo = false;
			this.m_txtOutSummary1.m_BlnPartControl = false;
			this.m_txtOutSummary1.m_BlnReadOnly = false;
			this.m_txtOutSummary1.m_BlnUnderLineDST = false;
			this.m_txtOutSummary1.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtOutSummary1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtOutSummary1.m_IntCanModifyTime = 6;
			this.m_txtOutSummary1.m_IntPartControlLength = 0;
			this.m_txtOutSummary1.m_IntPartControlStartIndex = 0;
			this.m_txtOutSummary1.m_StrUserID = "";
			this.m_txtOutSummary1.m_StrUserName = "";
			this.m_txtOutSummary1.MaxLength = 50;
			this.m_txtOutSummary1.Multiline = false;
			this.m_txtOutSummary1.Name = "m_txtOutSummary1";
			this.m_txtOutSummary1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtOutSummary1.Size = new System.Drawing.Size(80, 23);
			this.m_txtOutSummary1.TabIndex = 10000227;
			this.m_txtOutSummary1.Tag = "Summary";
			this.m_txtOutSummary1.Text = "";
			// 
			// label32
			// 
			this.label32.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label32.Location = new System.Drawing.Point(133, 454);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(315, 23);
			this.label32.TabIndex = 10000230;
			this.label32.Text = "总出量：           毫升   比重：       ";
			// 
			// label34
			// 
			this.label34.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label34.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label34.Location = new System.Drawing.Point(16, 248);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(48, 19);
			this.label34.TabIndex = 10000229;
			this.label34.Text = "时间段";
			// 
			// label35
			// 
			this.label35.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label35.Location = new System.Drawing.Point(8, 381);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(80, 32);
			this.label35.TabIndex = 10000228;
			this.label35.Text = "凌晨二时至上午七时";
			// 
			// label36
			// 
			this.label36.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label36.Location = new System.Drawing.Point(8, 344);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(80, 32);
			this.label36.TabIndex = 10000227;
			this.label36.Text = "下午六时至凌晨二时";
			// 
			// label37
			// 
			this.label37.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label37.Location = new System.Drawing.Point(8, 307);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(80, 32);
			this.label37.TabIndex = 10000226;
			this.label37.Text = "下午三时至下午六时";
			// 
			// label38
			// 
			this.label38.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label38.Location = new System.Drawing.Point(8, 269);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(80, 32);
			this.label38.TabIndex = 10000225;
			this.label38.Text = "上午七时至下午三时";
			// 
			// m_txtItem416
			// 
			this.m_txtItem416.Location = new System.Drawing.Point(747, 384);
			this.m_txtItem416.m_BlnIgnoreUserInfo = false;
			this.m_txtItem416.m_BlnPartControl = false;
			this.m_txtItem416.m_BlnReadOnly = false;
			this.m_txtItem416.m_BlnUnderLineDST = false;
			this.m_txtItem416.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem416.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem416.m_IntCanModifyTime = 6;
			this.m_txtItem416.m_IntPartControlLength = 0;
			this.m_txtItem416.m_IntPartControlStartIndex = 0;
			this.m_txtItem416.m_StrUserID = "";
			this.m_txtItem416.m_StrUserName = "";
			this.m_txtItem416.MaxLength = 50;
			this.m_txtItem416.Multiline = false;
			this.m_txtItem416.Name = "m_txtItem416";
			this.m_txtItem416.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem416.TabIndex = 10000224;
			this.m_txtItem416.Tag = "In";
			this.m_txtItem416.Text = "";
			// 
			// m_txtItem414
			// 
			this.m_txtItem414.Location = new System.Drawing.Point(489, 384);
			this.m_txtItem414.m_BlnIgnoreUserInfo = false;
			this.m_txtItem414.m_BlnPartControl = false;
			this.m_txtItem414.m_BlnReadOnly = false;
			this.m_txtItem414.m_BlnUnderLineDST = false;
			this.m_txtItem414.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem414.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem414.m_IntCanModifyTime = 6;
			this.m_txtItem414.m_IntPartControlLength = 0;
			this.m_txtItem414.m_IntPartControlStartIndex = 0;
			this.m_txtItem414.m_StrUserID = "";
			this.m_txtItem414.m_StrUserName = "";
			this.m_txtItem414.MaxLength = 50;
			this.m_txtItem414.Multiline = false;
			this.m_txtItem414.Name = "m_txtItem414";
			this.m_txtItem414.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem414.TabIndex = 10000222;
			this.m_txtItem414.Tag = "In";
			this.m_txtItem414.Text = "";
			// 
			// m_txtItem413
			// 
			this.m_txtItem413.Location = new System.Drawing.Point(412, 384);
			this.m_txtItem413.m_BlnIgnoreUserInfo = false;
			this.m_txtItem413.m_BlnPartControl = false;
			this.m_txtItem413.m_BlnReadOnly = false;
			this.m_txtItem413.m_BlnUnderLineDST = false;
			this.m_txtItem413.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem413.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem413.m_IntCanModifyTime = 6;
			this.m_txtItem413.m_IntPartControlLength = 0;
			this.m_txtItem413.m_IntPartControlStartIndex = 0;
			this.m_txtItem413.m_StrUserID = "";
			this.m_txtItem413.m_StrUserName = "";
			this.m_txtItem413.MaxLength = 50;
			this.m_txtItem413.Multiline = false;
			this.m_txtItem413.Name = "m_txtItem413";
			this.m_txtItem413.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem413.TabIndex = 10000221;
			this.m_txtItem413.Tag = "In";
			this.m_txtItem413.Text = "";
			// 
			// m_txtItem412
			// 
			this.m_txtItem412.Location = new System.Drawing.Point(335, 384);
			this.m_txtItem412.m_BlnIgnoreUserInfo = false;
			this.m_txtItem412.m_BlnPartControl = false;
			this.m_txtItem412.m_BlnReadOnly = false;
			this.m_txtItem412.m_BlnUnderLineDST = false;
			this.m_txtItem412.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem412.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem412.m_IntCanModifyTime = 6;
			this.m_txtItem412.m_IntPartControlLength = 0;
			this.m_txtItem412.m_IntPartControlStartIndex = 0;
			this.m_txtItem412.m_StrUserID = "";
			this.m_txtItem412.m_StrUserName = "";
			this.m_txtItem412.MaxLength = 50;
			this.m_txtItem412.Multiline = false;
			this.m_txtItem412.Name = "m_txtItem412";
			this.m_txtItem412.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem412.TabIndex = 10000220;
			this.m_txtItem412.Tag = "In";
			this.m_txtItem412.Text = "";
			// 
			// m_txtItem411
			// 
			this.m_txtItem411.Location = new System.Drawing.Point(258, 384);
			this.m_txtItem411.m_BlnIgnoreUserInfo = false;
			this.m_txtItem411.m_BlnPartControl = false;
			this.m_txtItem411.m_BlnReadOnly = false;
			this.m_txtItem411.m_BlnUnderLineDST = false;
			this.m_txtItem411.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem411.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem411.m_IntCanModifyTime = 6;
			this.m_txtItem411.m_IntPartControlLength = 0;
			this.m_txtItem411.m_IntPartControlStartIndex = 0;
			this.m_txtItem411.m_StrUserID = "";
			this.m_txtItem411.m_StrUserName = "";
			this.m_txtItem411.MaxLength = 50;
			this.m_txtItem411.Multiline = false;
			this.m_txtItem411.Name = "m_txtItem411";
			this.m_txtItem411.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem411.TabIndex = 10000219;
			this.m_txtItem411.Tag = "In";
			this.m_txtItem411.Text = "";
			// 
			// m_txtItem316
			// 
			this.m_txtItem316.Location = new System.Drawing.Point(747, 348);
			this.m_txtItem316.m_BlnIgnoreUserInfo = false;
			this.m_txtItem316.m_BlnPartControl = false;
			this.m_txtItem316.m_BlnReadOnly = false;
			this.m_txtItem316.m_BlnUnderLineDST = false;
			this.m_txtItem316.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem316.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem316.m_IntCanModifyTime = 6;
			this.m_txtItem316.m_IntPartControlLength = 0;
			this.m_txtItem316.m_IntPartControlStartIndex = 0;
			this.m_txtItem316.m_StrUserID = "";
			this.m_txtItem316.m_StrUserName = "";
			this.m_txtItem316.MaxLength = 50;
			this.m_txtItem316.Multiline = false;
			this.m_txtItem316.Name = "m_txtItem316";
			this.m_txtItem316.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem316.TabIndex = 10000216;
			this.m_txtItem316.Tag = "In";
			this.m_txtItem316.Text = "";
			// 
			// m_txtItem314
			// 
			this.m_txtItem314.Location = new System.Drawing.Point(489, 348);
			this.m_txtItem314.m_BlnIgnoreUserInfo = false;
			this.m_txtItem314.m_BlnPartControl = false;
			this.m_txtItem314.m_BlnReadOnly = false;
			this.m_txtItem314.m_BlnUnderLineDST = false;
			this.m_txtItem314.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem314.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem314.m_IntCanModifyTime = 6;
			this.m_txtItem314.m_IntPartControlLength = 0;
			this.m_txtItem314.m_IntPartControlStartIndex = 0;
			this.m_txtItem314.m_StrUserID = "";
			this.m_txtItem314.m_StrUserName = "";
			this.m_txtItem314.MaxLength = 50;
			this.m_txtItem314.Multiline = false;
			this.m_txtItem314.Name = "m_txtItem314";
			this.m_txtItem314.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem314.TabIndex = 10000214;
			this.m_txtItem314.Tag = "In";
			this.m_txtItem314.Text = "";
			// 
			// m_txtItem313
			// 
			this.m_txtItem313.Location = new System.Drawing.Point(412, 348);
			this.m_txtItem313.m_BlnIgnoreUserInfo = false;
			this.m_txtItem313.m_BlnPartControl = false;
			this.m_txtItem313.m_BlnReadOnly = false;
			this.m_txtItem313.m_BlnUnderLineDST = false;
			this.m_txtItem313.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem313.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem313.m_IntCanModifyTime = 6;
			this.m_txtItem313.m_IntPartControlLength = 0;
			this.m_txtItem313.m_IntPartControlStartIndex = 0;
			this.m_txtItem313.m_StrUserID = "";
			this.m_txtItem313.m_StrUserName = "";
			this.m_txtItem313.MaxLength = 50;
			this.m_txtItem313.Multiline = false;
			this.m_txtItem313.Name = "m_txtItem313";
			this.m_txtItem313.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem313.TabIndex = 10000213;
			this.m_txtItem313.Tag = "In";
			this.m_txtItem313.Text = "";
			// 
			// m_txtItem312
			// 
			this.m_txtItem312.Location = new System.Drawing.Point(335, 348);
			this.m_txtItem312.m_BlnIgnoreUserInfo = false;
			this.m_txtItem312.m_BlnPartControl = false;
			this.m_txtItem312.m_BlnReadOnly = false;
			this.m_txtItem312.m_BlnUnderLineDST = false;
			this.m_txtItem312.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem312.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem312.m_IntCanModifyTime = 6;
			this.m_txtItem312.m_IntPartControlLength = 0;
			this.m_txtItem312.m_IntPartControlStartIndex = 0;
			this.m_txtItem312.m_StrUserID = "";
			this.m_txtItem312.m_StrUserName = "";
			this.m_txtItem312.MaxLength = 50;
			this.m_txtItem312.Multiline = false;
			this.m_txtItem312.Name = "m_txtItem312";
			this.m_txtItem312.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem312.TabIndex = 10000212;
			this.m_txtItem312.Tag = "In";
			this.m_txtItem312.Text = "";
			// 
			// m_txtItem311
			// 
			this.m_txtItem311.Location = new System.Drawing.Point(258, 348);
			this.m_txtItem311.m_BlnIgnoreUserInfo = false;
			this.m_txtItem311.m_BlnPartControl = false;
			this.m_txtItem311.m_BlnReadOnly = false;
			this.m_txtItem311.m_BlnUnderLineDST = false;
			this.m_txtItem311.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem311.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem311.m_IntCanModifyTime = 6;
			this.m_txtItem311.m_IntPartControlLength = 0;
			this.m_txtItem311.m_IntPartControlStartIndex = 0;
			this.m_txtItem311.m_StrUserID = "";
			this.m_txtItem311.m_StrUserName = "";
			this.m_txtItem311.MaxLength = 50;
			this.m_txtItem311.Multiline = false;
			this.m_txtItem311.Name = "m_txtItem311";
			this.m_txtItem311.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem311.TabIndex = 10000211;
			this.m_txtItem311.Tag = "In";
			this.m_txtItem311.Text = "";
			// 
			// m_txtItem216
			// 
			this.m_txtItem216.Location = new System.Drawing.Point(747, 310);
			this.m_txtItem216.m_BlnIgnoreUserInfo = false;
			this.m_txtItem216.m_BlnPartControl = false;
			this.m_txtItem216.m_BlnReadOnly = false;
			this.m_txtItem216.m_BlnUnderLineDST = false;
			this.m_txtItem216.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem216.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem216.m_IntCanModifyTime = 6;
			this.m_txtItem216.m_IntPartControlLength = 0;
			this.m_txtItem216.m_IntPartControlStartIndex = 0;
			this.m_txtItem216.m_StrUserID = "";
			this.m_txtItem216.m_StrUserName = "";
			this.m_txtItem216.MaxLength = 50;
			this.m_txtItem216.Multiline = false;
			this.m_txtItem216.Name = "m_txtItem216";
			this.m_txtItem216.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem216.TabIndex = 10000208;
			this.m_txtItem216.Tag = "In";
			this.m_txtItem216.Text = "";
			// 
			// m_txtItem214
			// 
			this.m_txtItem214.Location = new System.Drawing.Point(489, 310);
			this.m_txtItem214.m_BlnIgnoreUserInfo = false;
			this.m_txtItem214.m_BlnPartControl = false;
			this.m_txtItem214.m_BlnReadOnly = false;
			this.m_txtItem214.m_BlnUnderLineDST = false;
			this.m_txtItem214.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem214.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem214.m_IntCanModifyTime = 6;
			this.m_txtItem214.m_IntPartControlLength = 0;
			this.m_txtItem214.m_IntPartControlStartIndex = 0;
			this.m_txtItem214.m_StrUserID = "";
			this.m_txtItem214.m_StrUserName = "";
			this.m_txtItem214.MaxLength = 50;
			this.m_txtItem214.Multiline = false;
			this.m_txtItem214.Name = "m_txtItem214";
			this.m_txtItem214.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem214.TabIndex = 10000206;
			this.m_txtItem214.Tag = "In";
			this.m_txtItem214.Text = "";
			// 
			// m_txtItem213
			// 
			this.m_txtItem213.Location = new System.Drawing.Point(412, 310);
			this.m_txtItem213.m_BlnIgnoreUserInfo = false;
			this.m_txtItem213.m_BlnPartControl = false;
			this.m_txtItem213.m_BlnReadOnly = false;
			this.m_txtItem213.m_BlnUnderLineDST = false;
			this.m_txtItem213.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem213.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem213.m_IntCanModifyTime = 6;
			this.m_txtItem213.m_IntPartControlLength = 0;
			this.m_txtItem213.m_IntPartControlStartIndex = 0;
			this.m_txtItem213.m_StrUserID = "";
			this.m_txtItem213.m_StrUserName = "";
			this.m_txtItem213.MaxLength = 50;
			this.m_txtItem213.Multiline = false;
			this.m_txtItem213.Name = "m_txtItem213";
			this.m_txtItem213.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem213.TabIndex = 10000205;
			this.m_txtItem213.Tag = "In";
			this.m_txtItem213.Text = "";
			// 
			// m_txtItem212
			// 
			this.m_txtItem212.Location = new System.Drawing.Point(335, 310);
			this.m_txtItem212.m_BlnIgnoreUserInfo = false;
			this.m_txtItem212.m_BlnPartControl = false;
			this.m_txtItem212.m_BlnReadOnly = false;
			this.m_txtItem212.m_BlnUnderLineDST = false;
			this.m_txtItem212.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem212.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem212.m_IntCanModifyTime = 6;
			this.m_txtItem212.m_IntPartControlLength = 0;
			this.m_txtItem212.m_IntPartControlStartIndex = 0;
			this.m_txtItem212.m_StrUserID = "";
			this.m_txtItem212.m_StrUserName = "";
			this.m_txtItem212.MaxLength = 50;
			this.m_txtItem212.Multiline = false;
			this.m_txtItem212.Name = "m_txtItem212";
			this.m_txtItem212.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem212.TabIndex = 10000204;
			this.m_txtItem212.Tag = "In";
			this.m_txtItem212.Text = "";
			// 
			// m_txtItem211
			// 
			this.m_txtItem211.Location = new System.Drawing.Point(258, 310);
			this.m_txtItem211.m_BlnIgnoreUserInfo = false;
			this.m_txtItem211.m_BlnPartControl = false;
			this.m_txtItem211.m_BlnReadOnly = false;
			this.m_txtItem211.m_BlnUnderLineDST = false;
			this.m_txtItem211.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem211.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem211.m_IntCanModifyTime = 6;
			this.m_txtItem211.m_IntPartControlLength = 0;
			this.m_txtItem211.m_IntPartControlStartIndex = 0;
			this.m_txtItem211.m_StrUserID = "";
			this.m_txtItem211.m_StrUserName = "";
			this.m_txtItem211.MaxLength = 50;
			this.m_txtItem211.Multiline = false;
			this.m_txtItem211.Name = "m_txtItem211";
			this.m_txtItem211.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem211.TabIndex = 10000203;
			this.m_txtItem211.Tag = "In";
			this.m_txtItem211.Text = "";
			// 
			// m_txtItem116
			// 
			this.m_txtItem116.Location = new System.Drawing.Point(747, 272);
			this.m_txtItem116.m_BlnIgnoreUserInfo = false;
			this.m_txtItem116.m_BlnPartControl = false;
			this.m_txtItem116.m_BlnReadOnly = false;
			this.m_txtItem116.m_BlnUnderLineDST = false;
			this.m_txtItem116.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem116.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem116.m_IntCanModifyTime = 6;
			this.m_txtItem116.m_IntPartControlLength = 0;
			this.m_txtItem116.m_IntPartControlStartIndex = 0;
			this.m_txtItem116.m_StrUserID = "";
			this.m_txtItem116.m_StrUserName = "";
			this.m_txtItem116.MaxLength = 50;
			this.m_txtItem116.Multiline = false;
			this.m_txtItem116.Name = "m_txtItem116";
			this.m_txtItem116.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem116.TabIndex = 10000200;
			this.m_txtItem116.Tag = "In";
			this.m_txtItem116.Text = "";
			// 
			// m_txtItem114
			// 
			this.m_txtItem114.Location = new System.Drawing.Point(489, 272);
			this.m_txtItem114.m_BlnIgnoreUserInfo = false;
			this.m_txtItem114.m_BlnPartControl = false;
			this.m_txtItem114.m_BlnReadOnly = false;
			this.m_txtItem114.m_BlnUnderLineDST = false;
			this.m_txtItem114.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem114.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem114.m_IntCanModifyTime = 6;
			this.m_txtItem114.m_IntPartControlLength = 0;
			this.m_txtItem114.m_IntPartControlStartIndex = 0;
			this.m_txtItem114.m_StrUserID = "";
			this.m_txtItem114.m_StrUserName = "";
			this.m_txtItem114.MaxLength = 50;
			this.m_txtItem114.Multiline = false;
			this.m_txtItem114.Name = "m_txtItem114";
			this.m_txtItem114.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem114.TabIndex = 10000198;
			this.m_txtItem114.Tag = "In";
			this.m_txtItem114.Text = "";
			// 
			// m_txtItem113
			// 
			this.m_txtItem113.Location = new System.Drawing.Point(412, 272);
			this.m_txtItem113.m_BlnIgnoreUserInfo = false;
			this.m_txtItem113.m_BlnPartControl = false;
			this.m_txtItem113.m_BlnReadOnly = false;
			this.m_txtItem113.m_BlnUnderLineDST = false;
			this.m_txtItem113.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem113.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem113.m_IntCanModifyTime = 6;
			this.m_txtItem113.m_IntPartControlLength = 0;
			this.m_txtItem113.m_IntPartControlStartIndex = 0;
			this.m_txtItem113.m_StrUserID = "";
			this.m_txtItem113.m_StrUserName = "";
			this.m_txtItem113.MaxLength = 50;
			this.m_txtItem113.Multiline = false;
			this.m_txtItem113.Name = "m_txtItem113";
			this.m_txtItem113.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem113.TabIndex = 10000197;
			this.m_txtItem113.Tag = "In";
			this.m_txtItem113.Text = "";
			// 
			// m_txtItem112
			// 
			this.m_txtItem112.Location = new System.Drawing.Point(335, 272);
			this.m_txtItem112.m_BlnIgnoreUserInfo = false;
			this.m_txtItem112.m_BlnPartControl = false;
			this.m_txtItem112.m_BlnReadOnly = false;
			this.m_txtItem112.m_BlnUnderLineDST = false;
			this.m_txtItem112.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem112.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem112.m_IntCanModifyTime = 6;
			this.m_txtItem112.m_IntPartControlLength = 0;
			this.m_txtItem112.m_IntPartControlStartIndex = 0;
			this.m_txtItem112.m_StrUserID = "";
			this.m_txtItem112.m_StrUserName = "";
			this.m_txtItem112.MaxLength = 50;
			this.m_txtItem112.Multiline = false;
			this.m_txtItem112.Name = "m_txtItem112";
			this.m_txtItem112.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem112.TabIndex = 10000196;
			this.m_txtItem112.Tag = "In";
			this.m_txtItem112.Text = "";
			// 
			// m_txtItem111
			// 
			this.m_txtItem111.Location = new System.Drawing.Point(258, 272);
			this.m_txtItem111.m_BlnIgnoreUserInfo = false;
			this.m_txtItem111.m_BlnPartControl = false;
			this.m_txtItem111.m_BlnReadOnly = false;
			this.m_txtItem111.m_BlnUnderLineDST = false;
			this.m_txtItem111.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem111.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem111.m_IntCanModifyTime = 6;
			this.m_txtItem111.m_IntPartControlLength = 0;
			this.m_txtItem111.m_IntPartControlStartIndex = 0;
			this.m_txtItem111.m_StrUserID = "";
			this.m_txtItem111.m_StrUserName = "";
			this.m_txtItem111.MaxLength = 50;
			this.m_txtItem111.Multiline = false;
			this.m_txtItem111.Name = "m_txtItem111";
			this.m_txtItem111.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem111.TabIndex = 10000195;
			this.m_txtItem111.Tag = "In";
			this.m_txtItem111.Text = "";
			// 
			// label31
			// 
			this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label31.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label31.ForeColor = System.Drawing.SystemColors.Control;
			this.label31.Location = new System.Drawing.Point(0, 30);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(888, 2);
			this.label31.TabIndex = 10000191;
			// 
			// label30
			// 
			this.label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label30.ForeColor = System.Drawing.SystemColors.Control;
			this.label30.Location = new System.Drawing.Point(96, 32);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(2, 184);
			this.label30.TabIndex = 10000190;
			// 
			// m_txtNureSummary1
			// 
			this.m_txtNureSummary1.Location = new System.Drawing.Point(288, 421);
			this.m_txtNureSummary1.m_BlnIgnoreUserInfo = false;
			this.m_txtNureSummary1.m_BlnPartControl = false;
			this.m_txtNureSummary1.m_BlnReadOnly = false;
			this.m_txtNureSummary1.m_BlnUnderLineDST = false;
			this.m_txtNureSummary1.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtNureSummary1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtNureSummary1.m_IntCanModifyTime = 6;
			this.m_txtNureSummary1.m_IntPartControlLength = 0;
			this.m_txtNureSummary1.m_IntPartControlStartIndex = 0;
			this.m_txtNureSummary1.m_StrUserID = "";
			this.m_txtNureSummary1.m_StrUserName = "";
			this.m_txtNureSummary1.MaxLength = 50;
			this.m_txtNureSummary1.Multiline = false;
			this.m_txtNureSummary1.Name = "m_txtNureSummary1";
			this.m_txtNureSummary1.Size = new System.Drawing.Size(80, 23);
			this.m_txtNureSummary1.TabIndex = 10000225;
			this.m_txtNureSummary1.Tag = "Summary";
			this.m_txtNureSummary1.Text = "";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label5.Location = new System.Drawing.Point(192, 424);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 10000188;
			this.label5.Text = "其中尿总量：";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 11F);
			this.label3.Location = new System.Drawing.Point(368, 10);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 14);
			this.label3.TabIndex = 10000187;
			this.label3.Text = "出  量";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(104, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(632, 16);
			this.label1.TabIndex = 10000183;
			this.label1.Text = "   大便       小便       胃液       胆汁       肠液       胸液           其它";
			// 
			// m_txtInSummary1
			// 
			this.m_txtInSummary1.Location = new System.Drawing.Point(600, 422);
			this.m_txtInSummary1.m_BlnIgnoreUserInfo = false;
			this.m_txtInSummary1.m_BlnPartControl = false;
			this.m_txtInSummary1.m_BlnReadOnly = false;
			this.m_txtInSummary1.m_BlnUnderLineDST = false;
			this.m_txtInSummary1.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtInSummary1.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtInSummary1.m_IntCanModifyTime = 6;
			this.m_txtInSummary1.m_IntPartControlLength = 0;
			this.m_txtInSummary1.m_IntPartControlStartIndex = 0;
			this.m_txtInSummary1.m_StrUserID = "";
			this.m_txtInSummary1.m_StrUserName = "";
			this.m_txtInSummary1.MaxLength = 50;
			this.m_txtInSummary1.Multiline = false;
			this.m_txtInSummary1.Name = "m_txtInSummary1";
			this.m_txtInSummary1.Size = new System.Drawing.Size(80, 23);
			this.m_txtInSummary1.TabIndex = 10000226;
			this.m_txtInSummary1.Tag = "Summary";
			this.m_txtInSummary1.Text = "";
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label7.Location = new System.Drawing.Point(544, 426);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(208, 23);
			this.label7.TabIndex = 10000189;
			this.label7.Text = "总入量：            毫升";
			// 
			// m_cmdSign
			// 
			this.m_cmdSign.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSign.DefaultScheme = true;
			this.m_cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSign.Hint = "";
			this.m_cmdSign.Location = new System.Drawing.Point(632, 451);
			this.m_cmdSign.Name = "m_cmdSign";
			this.m_cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSign.Size = new System.Drawing.Size(64, 23);
			this.m_cmdSign.TabIndex = 10000229;
			this.m_cmdSign.Text = "签名:";
			// 
			// m_txtSign1
			// 
			this.m_txtSign1.AccessibleName = "NoDefault";
			this.m_txtSign1.AutoSize = false;
			this.m_txtSign1.BackColor = System.Drawing.Color.White;
			this.m_txtSign1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtSign1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.m_txtSign1.Location = new System.Drawing.Point(704, 451);
			this.m_txtSign1.Name = "m_txtSign1";
            this.m_txtSign1.ReadOnly = true;
			this.m_txtSign1.Size = new System.Drawing.Size(80, 23);
			this.m_txtSign1.TabIndex = 10000230;
			this.m_txtSign1.Text = "";
			// 
			// m_txtItem13
			// 
			this.m_txtItem13.AccessibleDescription = "m_txtItem14";
			this.m_txtItem13.Location = new System.Drawing.Point(258, 72);
			this.m_txtItem13.m_BlnIgnoreUserInfo = false;
			this.m_txtItem13.m_BlnPartControl = false;
			this.m_txtItem13.m_BlnReadOnly = false;
			this.m_txtItem13.m_BlnUnderLineDST = false;
			this.m_txtItem13.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem13.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem13.m_IntCanModifyTime = 6;
			this.m_txtItem13.m_IntPartControlLength = 0;
			this.m_txtItem13.m_IntPartControlStartIndex = 0;
			this.m_txtItem13.m_StrUserID = "";
			this.m_txtItem13.m_StrUserName = "";
			this.m_txtItem13.MaxLength = 50;
			this.m_txtItem13.Multiline = false;
			this.m_txtItem13.Name = "m_txtItem13";
			this.m_txtItem13.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem13.TabIndex = 10000058;
			this.m_txtItem13.Tag = "Out";
			this.m_txtItem13.Text = "";
			// 
			// label29
			// 
			this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label29.ForeColor = System.Drawing.SystemColors.Control;
			this.label29.Location = new System.Drawing.Point(0, 213);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(888, 2);
			this.label29.TabIndex = 10000178;
			// 
			// label27
			// 
			this.label27.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label27.Location = new System.Drawing.Point(16, 440);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(48, 24);
			this.label27.TabIndex = 10000177;
			this.label27.Text = "总  结";
			// 
			// label25
			// 
			this.label25.Font = new System.Drawing.Font("宋体", 10.5F);
			this.label25.Location = new System.Drawing.Point(16, 40);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(48, 19);
			this.label25.TabIndex = 10000176;
			this.label25.Text = "时间段";
			// 
			// label9
			// 
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label9.ForeColor = System.Drawing.SystemColors.Control;
			this.label9.Location = new System.Drawing.Point(0, 176);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(888, 2);
			this.label9.TabIndex = 10000174;
			// 
			// label8
			// 
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label8.ForeColor = System.Drawing.SystemColors.Control;
			this.label8.Location = new System.Drawing.Point(0, 138);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(888, 2);
			this.label8.TabIndex = 10000173;
			// 
			// label6
			// 
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label6.ForeColor = System.Drawing.SystemColors.Control;
			this.label6.Location = new System.Drawing.Point(0, 100);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(888, 2);
			this.label6.TabIndex = 10000172;
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(1, 62);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(888, 2);
			this.groupBox3.TabIndex = 10000171;
			this.groupBox3.TabStop = false;
			// 
			// m_lblFourthPeriod
			// 
			this.m_lblFourthPeriod.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_lblFourthPeriod.Location = new System.Drawing.Point(8, 178);
			this.m_lblFourthPeriod.Name = "m_lblFourthPeriod";
			this.m_lblFourthPeriod.Size = new System.Drawing.Size(80, 32);
			this.m_lblFourthPeriod.TabIndex = 10000169;
			this.m_lblFourthPeriod.Text = "凌晨二时至上午七时";
			// 
			// m_lblThirdPeriod
			// 
			this.m_lblThirdPeriod.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_lblThirdPeriod.Location = new System.Drawing.Point(8, 143);
			this.m_lblThirdPeriod.Name = "m_lblThirdPeriod";
			this.m_lblThirdPeriod.Size = new System.Drawing.Size(80, 32);
			this.m_lblThirdPeriod.TabIndex = 10000168;
			this.m_lblThirdPeriod.Text = "下午六时至凌晨二时";
			// 
			// m_lblSecondPeriod
			// 
			this.m_lblSecondPeriod.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_lblSecondPeriod.Location = new System.Drawing.Point(8, 104);
			this.m_lblSecondPeriod.Name = "m_lblSecondPeriod";
			this.m_lblSecondPeriod.Size = new System.Drawing.Size(80, 32);
			this.m_lblSecondPeriod.TabIndex = 10000167;
			this.m_lblSecondPeriod.Text = "下午三时至下午六时";
			// 
			// m_lblFirstPeriod
			// 
			this.m_lblFirstPeriod.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_lblFirstPeriod.Location = new System.Drawing.Point(8, 64);
			this.m_lblFirstPeriod.Name = "m_lblFirstPeriod";
			this.m_lblFirstPeriod.Size = new System.Drawing.Size(80, 32);
			this.m_lblFirstPeriod.TabIndex = 10000166;
			this.m_lblFirstPeriod.Text = "上午七时至下午三时";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("宋体", 11F);
			this.label4.Location = new System.Drawing.Point(368, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 14);
			this.label4.TabIndex = 10000132;
			this.label4.Text = "入  量";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(96, 248);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(640, 16);
			this.label2.TabIndex = 10000128;
			this.label2.Text = "    饮水       食物        血        浆         糖水       盐水            其它";
			// 
			// m_txtInColumnName1
			// 
			this.m_txtInColumnName1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.m_txtInColumnName1.Location = new System.Drawing.Point(747, 243);
			this.m_txtInColumnName1.MaxLength = 7;
			this.m_txtInColumnName1.Name = "m_txtInColumnName1";
			this.m_txtInColumnName1.Size = new System.Drawing.Size(72, 23);
			this.m_txtInColumnName1.TabIndex = 10000116;
			this.m_txtInColumnName1.Tag = "col";
			this.m_txtInColumnName1.Text = "";
			// 
			// m_txtItem48
			// 
			this.m_txtItem48.Location = new System.Drawing.Point(747, 183);
			this.m_txtItem48.m_BlnIgnoreUserInfo = false;
			this.m_txtItem48.m_BlnPartControl = false;
			this.m_txtItem48.m_BlnReadOnly = false;
			this.m_txtItem48.m_BlnUnderLineDST = false;
			this.m_txtItem48.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem48.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem48.m_IntCanModifyTime = 6;
			this.m_txtItem48.m_IntPartControlLength = 0;
			this.m_txtItem48.m_IntPartControlStartIndex = 0;
			this.m_txtItem48.m_StrUserID = "";
			this.m_txtItem48.m_StrUserName = "";
			this.m_txtItem48.MaxLength = 50;
			this.m_txtItem48.Multiline = false;
			this.m_txtItem48.Name = "m_txtItem48";
			this.m_txtItem48.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem48.TabIndex = 10000115;
			this.m_txtItem48.Tag = "Out";
			this.m_txtItem48.Text = "";
			// 
			// m_txtItem46
			// 
			this.m_txtItem46.Location = new System.Drawing.Point(489, 183);
			this.m_txtItem46.m_BlnIgnoreUserInfo = false;
			this.m_txtItem46.m_BlnPartControl = false;
			this.m_txtItem46.m_BlnReadOnly = false;
			this.m_txtItem46.m_BlnUnderLineDST = false;
			this.m_txtItem46.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem46.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem46.m_IntCanModifyTime = 6;
			this.m_txtItem46.m_IntPartControlLength = 0;
			this.m_txtItem46.m_IntPartControlStartIndex = 0;
			this.m_txtItem46.m_StrUserID = "";
			this.m_txtItem46.m_StrUserName = "";
			this.m_txtItem46.MaxLength = 50;
			this.m_txtItem46.Multiline = false;
			this.m_txtItem46.Name = "m_txtItem46";
			this.m_txtItem46.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem46.TabIndex = 10000113;
			this.m_txtItem46.Tag = "Out";
			this.m_txtItem46.Text = "";
			// 
			// m_txtItem45
			// 
			this.m_txtItem45.Location = new System.Drawing.Point(412, 183);
			this.m_txtItem45.m_BlnIgnoreUserInfo = false;
			this.m_txtItem45.m_BlnPartControl = false;
			this.m_txtItem45.m_BlnReadOnly = false;
			this.m_txtItem45.m_BlnUnderLineDST = false;
			this.m_txtItem45.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem45.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem45.m_IntCanModifyTime = 6;
			this.m_txtItem45.m_IntPartControlLength = 0;
			this.m_txtItem45.m_IntPartControlStartIndex = 0;
			this.m_txtItem45.m_StrUserID = "";
			this.m_txtItem45.m_StrUserName = "";
			this.m_txtItem45.MaxLength = 50;
			this.m_txtItem45.Multiline = false;
			this.m_txtItem45.Name = "m_txtItem45";
			this.m_txtItem45.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem45.TabIndex = 10000112;
			this.m_txtItem45.Tag = "Out";
			this.m_txtItem45.Text = "";
			// 
			// m_txtItem44
			// 
			this.m_txtItem44.Location = new System.Drawing.Point(335, 183);
			this.m_txtItem44.m_BlnIgnoreUserInfo = false;
			this.m_txtItem44.m_BlnPartControl = false;
			this.m_txtItem44.m_BlnReadOnly = false;
			this.m_txtItem44.m_BlnUnderLineDST = false;
			this.m_txtItem44.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem44.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem44.m_IntCanModifyTime = 6;
			this.m_txtItem44.m_IntPartControlLength = 0;
			this.m_txtItem44.m_IntPartControlStartIndex = 0;
			this.m_txtItem44.m_StrUserID = "";
			this.m_txtItem44.m_StrUserName = "";
			this.m_txtItem44.MaxLength = 50;
			this.m_txtItem44.Multiline = false;
			this.m_txtItem44.Name = "m_txtItem44";
			this.m_txtItem44.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem44.TabIndex = 10000111;
			this.m_txtItem44.Tag = "Out";
			this.m_txtItem44.Text = "";
			// 
			// m_txtItem43
			// 
			this.m_txtItem43.Location = new System.Drawing.Point(258, 183);
			this.m_txtItem43.m_BlnIgnoreUserInfo = false;
			this.m_txtItem43.m_BlnPartControl = false;
			this.m_txtItem43.m_BlnReadOnly = false;
			this.m_txtItem43.m_BlnUnderLineDST = false;
			this.m_txtItem43.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem43.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem43.m_IntCanModifyTime = 6;
			this.m_txtItem43.m_IntPartControlLength = 0;
			this.m_txtItem43.m_IntPartControlStartIndex = 0;
			this.m_txtItem43.m_StrUserID = "";
			this.m_txtItem43.m_StrUserName = "";
			this.m_txtItem43.MaxLength = 50;
			this.m_txtItem43.Multiline = false;
			this.m_txtItem43.Name = "m_txtItem43";
			this.m_txtItem43.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem43.TabIndex = 10000110;
			this.m_txtItem43.Tag = "Out";
			this.m_txtItem43.Text = "";
			// 
			// m_txtItem42
			// 
			this.m_txtItem42.Location = new System.Drawing.Point(181, 183);
			this.m_txtItem42.m_BlnIgnoreUserInfo = false;
			this.m_txtItem42.m_BlnPartControl = false;
			this.m_txtItem42.m_BlnReadOnly = false;
			this.m_txtItem42.m_BlnUnderLineDST = false;
			this.m_txtItem42.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem42.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem42.m_IntCanModifyTime = 6;
			this.m_txtItem42.m_IntPartControlLength = 0;
			this.m_txtItem42.m_IntPartControlStartIndex = 0;
			this.m_txtItem42.m_StrUserID = "";
			this.m_txtItem42.m_StrUserName = "";
			this.m_txtItem42.MaxLength = 50;
			this.m_txtItem42.Multiline = false;
			this.m_txtItem42.Name = "m_txtItem42";
			this.m_txtItem42.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem42.TabIndex = 10000109;
			this.m_txtItem42.Tag = "Urine";
			this.m_txtItem42.Text = "";
			// 
			// m_txtItem41
			// 
			this.m_txtItem41.Location = new System.Drawing.Point(104, 183);
			this.m_txtItem41.m_BlnIgnoreUserInfo = false;
			this.m_txtItem41.m_BlnPartControl = false;
			this.m_txtItem41.m_BlnReadOnly = false;
			this.m_txtItem41.m_BlnUnderLineDST = false;
			this.m_txtItem41.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem41.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem41.m_IntCanModifyTime = 6;
			this.m_txtItem41.m_IntPartControlLength = 0;
			this.m_txtItem41.m_IntPartControlStartIndex = 0;
			this.m_txtItem41.m_StrUserID = "";
			this.m_txtItem41.m_StrUserName = "";
			this.m_txtItem41.MaxLength = 50;
			this.m_txtItem41.Multiline = false;
			this.m_txtItem41.Name = "m_txtItem41";
			this.m_txtItem41.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem41.TabIndex = 10000108;
			this.m_txtItem41.Tag = "Out";
			this.m_txtItem41.Text = "";
			// 
			// m_txtItem38
			// 
			this.m_txtItem38.Location = new System.Drawing.Point(747, 146);
			this.m_txtItem38.m_BlnIgnoreUserInfo = false;
			this.m_txtItem38.m_BlnPartControl = false;
			this.m_txtItem38.m_BlnReadOnly = false;
			this.m_txtItem38.m_BlnUnderLineDST = false;
			this.m_txtItem38.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem38.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem38.m_IntCanModifyTime = 6;
			this.m_txtItem38.m_IntPartControlLength = 0;
			this.m_txtItem38.m_IntPartControlStartIndex = 0;
			this.m_txtItem38.m_StrUserID = "";
			this.m_txtItem38.m_StrUserName = "";
			this.m_txtItem38.MaxLength = 50;
			this.m_txtItem38.Multiline = false;
			this.m_txtItem38.Name = "m_txtItem38";
			this.m_txtItem38.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem38.TabIndex = 10000099;
			this.m_txtItem38.Tag = "Out";
			this.m_txtItem38.Text = "";
			// 
			// m_txtItem36
			// 
			this.m_txtItem36.Location = new System.Drawing.Point(489, 146);
			this.m_txtItem36.m_BlnIgnoreUserInfo = false;
			this.m_txtItem36.m_BlnPartControl = false;
			this.m_txtItem36.m_BlnReadOnly = false;
			this.m_txtItem36.m_BlnUnderLineDST = false;
			this.m_txtItem36.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem36.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem36.m_IntCanModifyTime = 6;
			this.m_txtItem36.m_IntPartControlLength = 0;
			this.m_txtItem36.m_IntPartControlStartIndex = 0;
			this.m_txtItem36.m_StrUserID = "";
			this.m_txtItem36.m_StrUserName = "";
			this.m_txtItem36.MaxLength = 50;
			this.m_txtItem36.Multiline = false;
			this.m_txtItem36.Name = "m_txtItem36";
			this.m_txtItem36.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem36.TabIndex = 10000097;
			this.m_txtItem36.Tag = "Out";
			this.m_txtItem36.Text = "";
			// 
			// m_txtItem35
			// 
			this.m_txtItem35.Location = new System.Drawing.Point(412, 146);
			this.m_txtItem35.m_BlnIgnoreUserInfo = false;
			this.m_txtItem35.m_BlnPartControl = false;
			this.m_txtItem35.m_BlnReadOnly = false;
			this.m_txtItem35.m_BlnUnderLineDST = false;
			this.m_txtItem35.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem35.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem35.m_IntCanModifyTime = 6;
			this.m_txtItem35.m_IntPartControlLength = 0;
			this.m_txtItem35.m_IntPartControlStartIndex = 0;
			this.m_txtItem35.m_StrUserID = "";
			this.m_txtItem35.m_StrUserName = "";
			this.m_txtItem35.MaxLength = 50;
			this.m_txtItem35.Multiline = false;
			this.m_txtItem35.Name = "m_txtItem35";
			this.m_txtItem35.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem35.TabIndex = 10000096;
			this.m_txtItem35.Tag = "Out";
			this.m_txtItem35.Text = "";
			// 
			// m_txtItem34
			// 
			this.m_txtItem34.Location = new System.Drawing.Point(335, 146);
			this.m_txtItem34.m_BlnIgnoreUserInfo = false;
			this.m_txtItem34.m_BlnPartControl = false;
			this.m_txtItem34.m_BlnReadOnly = false;
			this.m_txtItem34.m_BlnUnderLineDST = false;
			this.m_txtItem34.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem34.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem34.m_IntCanModifyTime = 6;
			this.m_txtItem34.m_IntPartControlLength = 0;
			this.m_txtItem34.m_IntPartControlStartIndex = 0;
			this.m_txtItem34.m_StrUserID = "";
			this.m_txtItem34.m_StrUserName = "";
			this.m_txtItem34.MaxLength = 50;
			this.m_txtItem34.Multiline = false;
			this.m_txtItem34.Name = "m_txtItem34";
			this.m_txtItem34.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem34.TabIndex = 10000095;
			this.m_txtItem34.Tag = "Out";
			this.m_txtItem34.Text = "";
			// 
			// m_txtItem33
			// 
			this.m_txtItem33.Location = new System.Drawing.Point(258, 146);
			this.m_txtItem33.m_BlnIgnoreUserInfo = false;
			this.m_txtItem33.m_BlnPartControl = false;
			this.m_txtItem33.m_BlnReadOnly = false;
			this.m_txtItem33.m_BlnUnderLineDST = false;
			this.m_txtItem33.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem33.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem33.m_IntCanModifyTime = 6;
			this.m_txtItem33.m_IntPartControlLength = 0;
			this.m_txtItem33.m_IntPartControlStartIndex = 0;
			this.m_txtItem33.m_StrUserID = "";
			this.m_txtItem33.m_StrUserName = "";
			this.m_txtItem33.MaxLength = 50;
			this.m_txtItem33.Multiline = false;
			this.m_txtItem33.Name = "m_txtItem33";
			this.m_txtItem33.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem33.TabIndex = 10000094;
			this.m_txtItem33.Tag = "Out";
			this.m_txtItem33.Text = "";
			// 
			// m_txtItem32
			// 
			this.m_txtItem32.Location = new System.Drawing.Point(181, 146);
			this.m_txtItem32.m_BlnIgnoreUserInfo = false;
			this.m_txtItem32.m_BlnPartControl = false;
			this.m_txtItem32.m_BlnReadOnly = false;
			this.m_txtItem32.m_BlnUnderLineDST = false;
			this.m_txtItem32.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem32.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem32.m_IntCanModifyTime = 6;
			this.m_txtItem32.m_IntPartControlLength = 0;
			this.m_txtItem32.m_IntPartControlStartIndex = 0;
			this.m_txtItem32.m_StrUserID = "";
			this.m_txtItem32.m_StrUserName = "";
			this.m_txtItem32.MaxLength = 50;
			this.m_txtItem32.Multiline = false;
			this.m_txtItem32.Name = "m_txtItem32";
			this.m_txtItem32.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem32.TabIndex = 10000093;
			this.m_txtItem32.Tag = "Urine";
			this.m_txtItem32.Text = "";
			// 
			// m_txtItem31
			// 
			this.m_txtItem31.Location = new System.Drawing.Point(104, 146);
			this.m_txtItem31.m_BlnIgnoreUserInfo = false;
			this.m_txtItem31.m_BlnPartControl = false;
			this.m_txtItem31.m_BlnReadOnly = false;
			this.m_txtItem31.m_BlnUnderLineDST = false;
			this.m_txtItem31.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem31.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem31.m_IntCanModifyTime = 6;
			this.m_txtItem31.m_IntPartControlLength = 0;
			this.m_txtItem31.m_IntPartControlStartIndex = 0;
			this.m_txtItem31.m_StrUserID = "";
			this.m_txtItem31.m_StrUserName = "";
			this.m_txtItem31.MaxLength = 50;
			this.m_txtItem31.Multiline = false;
			this.m_txtItem31.Name = "m_txtItem31";
			this.m_txtItem31.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem31.TabIndex = 10000092;
			this.m_txtItem31.Tag = "Out";
			this.m_txtItem31.Text = "";
			// 
			// m_txtItem28
			// 
			this.m_txtItem28.Location = new System.Drawing.Point(747, 109);
			this.m_txtItem28.m_BlnIgnoreUserInfo = false;
			this.m_txtItem28.m_BlnPartControl = false;
			this.m_txtItem28.m_BlnReadOnly = false;
			this.m_txtItem28.m_BlnUnderLineDST = false;
			this.m_txtItem28.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem28.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem28.m_IntCanModifyTime = 6;
			this.m_txtItem28.m_IntPartControlLength = 0;
			this.m_txtItem28.m_IntPartControlStartIndex = 0;
			this.m_txtItem28.m_StrUserID = "";
			this.m_txtItem28.m_StrUserName = "";
			this.m_txtItem28.MaxLength = 50;
			this.m_txtItem28.Multiline = false;
			this.m_txtItem28.Name = "m_txtItem28";
			this.m_txtItem28.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem28.TabIndex = 10000083;
			this.m_txtItem28.Tag = "Out";
			this.m_txtItem28.Text = "";
			// 
			// m_txtItem26
			// 
			this.m_txtItem26.Location = new System.Drawing.Point(489, 109);
			this.m_txtItem26.m_BlnIgnoreUserInfo = false;
			this.m_txtItem26.m_BlnPartControl = false;
			this.m_txtItem26.m_BlnReadOnly = false;
			this.m_txtItem26.m_BlnUnderLineDST = false;
			this.m_txtItem26.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem26.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem26.m_IntCanModifyTime = 6;
			this.m_txtItem26.m_IntPartControlLength = 0;
			this.m_txtItem26.m_IntPartControlStartIndex = 0;
			this.m_txtItem26.m_StrUserID = "";
			this.m_txtItem26.m_StrUserName = "";
			this.m_txtItem26.MaxLength = 50;
			this.m_txtItem26.Multiline = false;
			this.m_txtItem26.Name = "m_txtItem26";
			this.m_txtItem26.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem26.TabIndex = 10000081;
			this.m_txtItem26.Tag = "Out";
			this.m_txtItem26.Text = "";
			// 
			// m_txtItem25
			// 
			this.m_txtItem25.Location = new System.Drawing.Point(412, 109);
			this.m_txtItem25.m_BlnIgnoreUserInfo = false;
			this.m_txtItem25.m_BlnPartControl = false;
			this.m_txtItem25.m_BlnReadOnly = false;
			this.m_txtItem25.m_BlnUnderLineDST = false;
			this.m_txtItem25.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem25.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem25.m_IntCanModifyTime = 6;
			this.m_txtItem25.m_IntPartControlLength = 0;
			this.m_txtItem25.m_IntPartControlStartIndex = 0;
			this.m_txtItem25.m_StrUserID = "";
			this.m_txtItem25.m_StrUserName = "";
			this.m_txtItem25.MaxLength = 50;
			this.m_txtItem25.Multiline = false;
			this.m_txtItem25.Name = "m_txtItem25";
			this.m_txtItem25.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem25.TabIndex = 10000080;
			this.m_txtItem25.Tag = "Out";
			this.m_txtItem25.Text = "";
			// 
			// m_txtItem24
			// 
			this.m_txtItem24.Location = new System.Drawing.Point(335, 109);
			this.m_txtItem24.m_BlnIgnoreUserInfo = false;
			this.m_txtItem24.m_BlnPartControl = false;
			this.m_txtItem24.m_BlnReadOnly = false;
			this.m_txtItem24.m_BlnUnderLineDST = false;
			this.m_txtItem24.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem24.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem24.m_IntCanModifyTime = 6;
			this.m_txtItem24.m_IntPartControlLength = 0;
			this.m_txtItem24.m_IntPartControlStartIndex = 0;
			this.m_txtItem24.m_StrUserID = "";
			this.m_txtItem24.m_StrUserName = "";
			this.m_txtItem24.MaxLength = 50;
			this.m_txtItem24.Multiline = false;
			this.m_txtItem24.Name = "m_txtItem24";
			this.m_txtItem24.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem24.TabIndex = 10000079;
			this.m_txtItem24.Tag = "Out";
			this.m_txtItem24.Text = "";
			// 
			// m_txtItem23
			// 
			this.m_txtItem23.Location = new System.Drawing.Point(258, 109);
			this.m_txtItem23.m_BlnIgnoreUserInfo = false;
			this.m_txtItem23.m_BlnPartControl = false;
			this.m_txtItem23.m_BlnReadOnly = false;
			this.m_txtItem23.m_BlnUnderLineDST = false;
			this.m_txtItem23.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem23.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem23.m_IntCanModifyTime = 6;
			this.m_txtItem23.m_IntPartControlLength = 0;
			this.m_txtItem23.m_IntPartControlStartIndex = 0;
			this.m_txtItem23.m_StrUserID = "";
			this.m_txtItem23.m_StrUserName = "";
			this.m_txtItem23.MaxLength = 50;
			this.m_txtItem23.Multiline = false;
			this.m_txtItem23.Name = "m_txtItem23";
			this.m_txtItem23.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem23.TabIndex = 10000078;
			this.m_txtItem23.Tag = "Out";
			this.m_txtItem23.Text = "";
			// 
			// m_txtItem22
			// 
			this.m_txtItem22.Location = new System.Drawing.Point(181, 109);
			this.m_txtItem22.m_BlnIgnoreUserInfo = false;
			this.m_txtItem22.m_BlnPartControl = false;
			this.m_txtItem22.m_BlnReadOnly = false;
			this.m_txtItem22.m_BlnUnderLineDST = false;
			this.m_txtItem22.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem22.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem22.m_IntCanModifyTime = 6;
			this.m_txtItem22.m_IntPartControlLength = 0;
			this.m_txtItem22.m_IntPartControlStartIndex = 0;
			this.m_txtItem22.m_StrUserID = "";
			this.m_txtItem22.m_StrUserName = "";
			this.m_txtItem22.MaxLength = 50;
			this.m_txtItem22.Multiline = false;
			this.m_txtItem22.Name = "m_txtItem22";
			this.m_txtItem22.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem22.TabIndex = 10000077;
			this.m_txtItem22.Tag = "Urine";
			this.m_txtItem22.Text = "";
			// 
			// m_txtItem21
			// 
			this.m_txtItem21.Location = new System.Drawing.Point(104, 109);
			this.m_txtItem21.m_BlnIgnoreUserInfo = false;
			this.m_txtItem21.m_BlnPartControl = false;
			this.m_txtItem21.m_BlnReadOnly = false;
			this.m_txtItem21.m_BlnUnderLineDST = false;
			this.m_txtItem21.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem21.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem21.m_IntCanModifyTime = 6;
			this.m_txtItem21.m_IntPartControlLength = 0;
			this.m_txtItem21.m_IntPartControlStartIndex = 0;
			this.m_txtItem21.m_StrUserID = "";
			this.m_txtItem21.m_StrUserName = "";
			this.m_txtItem21.MaxLength = 50;
			this.m_txtItem21.Multiline = false;
			this.m_txtItem21.Name = "m_txtItem21";
			this.m_txtItem21.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem21.TabIndex = 10000076;
			this.m_txtItem21.Tag = "Out";
			this.m_txtItem21.Text = "";
			// 
			// m_txtItem18
			// 
			this.m_txtItem18.Location = new System.Drawing.Point(747, 72);
			this.m_txtItem18.m_BlnIgnoreUserInfo = false;
			this.m_txtItem18.m_BlnPartControl = false;
			this.m_txtItem18.m_BlnReadOnly = false;
			this.m_txtItem18.m_BlnUnderLineDST = false;
			this.m_txtItem18.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem18.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem18.m_IntCanModifyTime = 6;
			this.m_txtItem18.m_IntPartControlLength = 0;
			this.m_txtItem18.m_IntPartControlStartIndex = 0;
			this.m_txtItem18.m_StrUserID = "";
			this.m_txtItem18.m_StrUserName = "";
			this.m_txtItem18.MaxLength = 50;
			this.m_txtItem18.Multiline = false;
			this.m_txtItem18.Name = "m_txtItem18";
			this.m_txtItem18.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem18.TabIndex = 10000063;
			this.m_txtItem18.Tag = "Out";
			this.m_txtItem18.Text = "";
			// 
			// m_txtItem16
			// 
			this.m_txtItem16.Location = new System.Drawing.Point(489, 72);
			this.m_txtItem16.m_BlnIgnoreUserInfo = false;
			this.m_txtItem16.m_BlnPartControl = false;
			this.m_txtItem16.m_BlnReadOnly = false;
			this.m_txtItem16.m_BlnUnderLineDST = false;
			this.m_txtItem16.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem16.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem16.m_IntCanModifyTime = 6;
			this.m_txtItem16.m_IntPartControlLength = 0;
			this.m_txtItem16.m_IntPartControlStartIndex = 0;
			this.m_txtItem16.m_StrUserID = "";
			this.m_txtItem16.m_StrUserName = "";
			this.m_txtItem16.MaxLength = 50;
			this.m_txtItem16.Multiline = false;
			this.m_txtItem16.Name = "m_txtItem16";
			this.m_txtItem16.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem16.TabIndex = 10000061;
			this.m_txtItem16.Tag = "Out";
			this.m_txtItem16.Text = "";
			// 
			// m_txtItem15
			// 
			this.m_txtItem15.Location = new System.Drawing.Point(412, 72);
			this.m_txtItem15.m_BlnIgnoreUserInfo = false;
			this.m_txtItem15.m_BlnPartControl = false;
			this.m_txtItem15.m_BlnReadOnly = false;
			this.m_txtItem15.m_BlnUnderLineDST = false;
			this.m_txtItem15.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem15.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem15.m_IntCanModifyTime = 6;
			this.m_txtItem15.m_IntPartControlLength = 0;
			this.m_txtItem15.m_IntPartControlStartIndex = 0;
			this.m_txtItem15.m_StrUserID = "";
			this.m_txtItem15.m_StrUserName = "";
			this.m_txtItem15.MaxLength = 50;
			this.m_txtItem15.Multiline = false;
			this.m_txtItem15.Name = "m_txtItem15";
			this.m_txtItem15.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.m_txtItem15.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem15.TabIndex = 10000060;
			this.m_txtItem15.Tag = "Out";
			this.m_txtItem15.Text = "";
			// 
			// m_txtItem14
			// 
			this.m_txtItem14.Location = new System.Drawing.Point(335, 72);
			this.m_txtItem14.m_BlnIgnoreUserInfo = false;
			this.m_txtItem14.m_BlnPartControl = false;
			this.m_txtItem14.m_BlnReadOnly = false;
			this.m_txtItem14.m_BlnUnderLineDST = false;
			this.m_txtItem14.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem14.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem14.m_IntCanModifyTime = 6;
			this.m_txtItem14.m_IntPartControlLength = 0;
			this.m_txtItem14.m_IntPartControlStartIndex = 0;
			this.m_txtItem14.m_StrUserID = "";
			this.m_txtItem14.m_StrUserName = "";
			this.m_txtItem14.MaxLength = 50;
			this.m_txtItem14.Multiline = false;
			this.m_txtItem14.Name = "m_txtItem14";
			this.m_txtItem14.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem14.TabIndex = 10000059;
			this.m_txtItem14.Tag = "Out";
			this.m_txtItem14.Text = "1234";
			// 
			// m_txtItem12
			// 
			this.m_txtItem12.Location = new System.Drawing.Point(181, 72);
			this.m_txtItem12.m_BlnIgnoreUserInfo = false;
			this.m_txtItem12.m_BlnPartControl = false;
			this.m_txtItem12.m_BlnReadOnly = false;
			this.m_txtItem12.m_BlnUnderLineDST = false;
			this.m_txtItem12.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem12.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem12.m_IntCanModifyTime = 6;
			this.m_txtItem12.m_IntPartControlLength = 0;
			this.m_txtItem12.m_IntPartControlStartIndex = 0;
			this.m_txtItem12.m_StrUserID = "";
			this.m_txtItem12.m_StrUserName = "";
			this.m_txtItem12.MaxLength = 50;
			this.m_txtItem12.Multiline = false;
			this.m_txtItem12.Name = "m_txtItem12";
			this.m_txtItem12.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem12.TabIndex = 10000057;
			this.m_txtItem12.Tag = "Urine";
			this.m_txtItem12.Text = "";
			// 
			// m_txtItem11
			// 
			this.m_txtItem11.BackColor = System.Drawing.Color.White;
			this.m_txtItem11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtItem11.ForeColor = System.Drawing.SystemColors.Window;
			this.m_txtItem11.Location = new System.Drawing.Point(104, 72);
			this.m_txtItem11.m_BlnIgnoreUserInfo = false;
			this.m_txtItem11.m_BlnPartControl = false;
			this.m_txtItem11.m_BlnReadOnly = false;
			this.m_txtItem11.m_BlnUnderLineDST = false;
			this.m_txtItem11.m_ClrDST = System.Drawing.Color.Red;
			this.m_txtItem11.m_ClrOldPartInsertText = System.Drawing.Color.Black;
			this.m_txtItem11.m_IntCanModifyTime = 6;
			this.m_txtItem11.m_IntPartControlLength = 0;
			this.m_txtItem11.m_IntPartControlStartIndex = 0;
			this.m_txtItem11.m_StrUserID = "";
			this.m_txtItem11.m_StrUserName = "";
			this.m_txtItem11.MaxLength = 50;
			this.m_txtItem11.Multiline = false;
			this.m_txtItem11.Name = "m_txtItem11";
			this.m_txtItem11.Size = new System.Drawing.Size(72, 23);
			this.m_txtItem11.TabIndex = 10000056;
			this.m_txtItem11.Tag = "Out";
			this.m_txtItem11.Text = "";
			// 
			// m_txtOutColumnName1
			// 
			this.m_txtOutColumnName1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.m_txtOutColumnName1.Location = new System.Drawing.Point(747, 34);
			this.m_txtOutColumnName1.MaxLength = 7;
			this.m_txtOutColumnName1.Name = "m_txtOutColumnName1";
			this.m_txtOutColumnName1.Size = new System.Drawing.Size(72, 23);
			this.m_txtOutColumnName1.TabIndex = 10000055;
			this.m_txtOutColumnName1.Tag = "col";
			this.m_txtOutColumnName1.Text = "";
			// 
			// m_dtmRegisterDate2
			// 
			this.m_dtmRegisterDate2.BorderColor = System.Drawing.Color.Black;
			this.m_dtmRegisterDate2.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtmRegisterDate2.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtmRegisterDate2.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtmRegisterDate2.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtmRegisterDate2.Enabled = false;
			this.m_dtmRegisterDate2.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtmRegisterDate2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtmRegisterDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtmRegisterDate2.Location = new System.Drawing.Point(80, 40);
			this.m_dtmRegisterDate2.m_BlnOnlyTime = false;
			this.m_dtmRegisterDate2.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtmRegisterDate2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtmRegisterDate2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtmRegisterDate2.Name = "m_dtmRegisterDate2";
			this.m_dtmRegisterDate2.ReadOnly = true;
			this.m_dtmRegisterDate2.Size = new System.Drawing.Size(4, 22);
			this.m_dtmRegisterDate2.TabIndex = 10000055;
			this.m_dtmRegisterDate2.TextBackColor = System.Drawing.Color.White;
			this.m_dtmRegisterDate2.TextForeColor = System.Drawing.Color.Black;
			this.m_dtmRegisterDate2.Visible = false;
			// 
			// label10
			// 
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label10.ForeColor = System.Drawing.SystemColors.Control;
			this.label10.Location = new System.Drawing.Point(0, 208);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(888, 2);
			this.label10.TabIndex = 10000175;
			// 
			// m_dtmRegisterDate1
			// 
			this.m_dtmRegisterDate1.BorderColor = System.Drawing.Color.Black;
			this.m_dtmRegisterDate1.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtmRegisterDate1.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtmRegisterDate1.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtmRegisterDate1.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtmRegisterDate1.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtmRegisterDate1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtmRegisterDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtmRegisterDate1.Location = new System.Drawing.Point(8, 88);
			this.m_dtmRegisterDate1.m_BlnOnlyTime = false;
			this.m_dtmRegisterDate1.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtmRegisterDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtmRegisterDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtmRegisterDate1.Name = "m_dtmRegisterDate1";
			this.m_dtmRegisterDate1.ReadOnly = false;
			this.m_dtmRegisterDate1.Size = new System.Drawing.Size(140, 22);
			this.m_dtmRegisterDate1.TabIndex = 10000048;
			this.m_dtmRegisterDate1.TextBackColor = System.Drawing.Color.White;
			this.m_dtmRegisterDate1.TextForeColor = System.Drawing.Color.Black;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.m_lblPage);
			this.groupBox4.Controls.Add(this.m_cmdLast);
			this.groupBox4.Controls.Add(this.m_cmdNextPage);
			this.groupBox4.Controls.Add(this.m_cmdPrevious);
			this.groupBox4.Controls.Add(this.m_cmdFirst);
			this.groupBox4.Location = new System.Drawing.Point(668, 72);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(168, 40);
			this.groupBox4.TabIndex = 10000162;
			this.groupBox4.TabStop = false;
			// 
			// m_lblPage
			// 
			this.m_lblPage.ForeColor = System.Drawing.Color.Red;
			this.m_lblPage.Location = new System.Drawing.Point(64, 16);
			this.m_lblPage.Name = "m_lblPage";
			this.m_lblPage.Size = new System.Drawing.Size(40, 16);
			this.m_lblPage.TabIndex = 10000155;
			// 
			// m_cmdLast
			// 
			this.m_cmdLast.Location = new System.Drawing.Point(136, 12);
			this.m_cmdLast.Name = "m_cmdLast";
			this.m_cmdLast.Size = new System.Drawing.Size(28, 24);
			this.m_cmdLast.TabIndex = 10000054;
			this.m_cmdLast.Text = ">|";
			this.m_cmdLast.Click += new System.EventHandler(this.m_cmdLast_Click);
			// 
			// m_cmdNextPage
			// 
			this.m_cmdNextPage.Location = new System.Drawing.Point(104, 12);
			this.m_cmdNextPage.Name = "m_cmdNextPage";
			this.m_cmdNextPage.Size = new System.Drawing.Size(28, 24);
			this.m_cmdNextPage.TabIndex = 10000053;
			this.m_cmdNextPage.Text = ">";
			this.m_cmdNextPage.Click += new System.EventHandler(this.m_cmdNextPage_Click);
			// 
			// m_cmdPrevious
			// 
			this.m_cmdPrevious.Location = new System.Drawing.Point(36, 12);
			this.m_cmdPrevious.Name = "m_cmdPrevious";
			this.m_cmdPrevious.Size = new System.Drawing.Size(28, 24);
			this.m_cmdPrevious.TabIndex = 10000052;
			this.m_cmdPrevious.Text = "<";
			this.m_cmdPrevious.Click += new System.EventHandler(this.m_cmdPrevious_Click);
			// 
			// m_cmdFirst
			// 
			this.m_cmdFirst.Location = new System.Drawing.Point(4, 12);
			this.m_cmdFirst.Name = "m_cmdFirst";
			this.m_cmdFirst.Size = new System.Drawing.Size(28, 24);
			this.m_cmdFirst.TabIndex = 10000051;
			this.m_cmdFirst.Text = "|<";
			this.m_cmdFirst.Click += new System.EventHandler(this.m_cmdFirst_Click);
			// 
			// m_cmdNew
			// 
			this.m_cmdNew.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmdNew.Location = new System.Drawing.Point(168, 84);
			this.m_cmdNew.Name = "m_cmdNew";
			this.m_cmdNew.Size = new System.Drawing.Size(52, 26);
			this.m_cmdNew.TabIndex = 10000049;
			this.m_cmdNew.Text = "新增";
			this.m_cmdNew.Click += new System.EventHandler(this.m_cmdNew_Click);
			// 
			// m_cmdSummary1
			// 
			this.m_cmdSummary1.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmdSummary1.Location = new System.Drawing.Point(232, 84);
			this.m_cmdSummary1.Name = "m_cmdSummary1";
			this.m_cmdSummary1.Size = new System.Drawing.Size(52, 26);
			this.m_cmdSummary1.TabIndex = 10000050;
			this.m_cmdSummary1.Text = "统计";
			this.m_cmdSummary1.Click += new System.EventHandler(this.m_cmdSummary1_Click_1);
			// 
			// m_pdcPrintDocumentNew
			// 
			this.m_pdcPrintDocumentNew.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocumentNew_BeginPrint);
			this.m_pdcPrintDocumentNew.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocumentNew_EndPrint);
			this.m_pdcPrintDocumentNew.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocumentNew_PrintPage);
			// 
			// frmRegisterQuantity
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(772, 441);
			this.Controls.Add(this.m_cmdSummary1);
			this.Controls.Add(this.m_cmdNew);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.m_dtmRegisterDate1);
			this.Controls.Add(this.m_grpRegister1);
			this.Name = "frmRegisterQuantity";
			this.Text = "出入量登记表";
			this.Load += new System.EventHandler(this.frmRegisterQuantity_Load);
			this.Controls.SetChildIndex(this.trvTime, 0);
			this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
			this.Controls.SetChildIndex(this.m_lblAddress, 0);
			this.Controls.SetChildIndex(this.m_lblLinkMan, 0);
			this.Controls.SetChildIndex(this.m_lblCreateUserName, 0);
			this.Controls.SetChildIndex(this.m_lblMarriaged, 0);
			this.Controls.SetChildIndex(this.m_lblOccupation, 0);
			this.Controls.SetChildIndex(this.m_lblNativePlace, 0);
			this.Controls.SetChildIndex(this.m_cmdCreateID, 0);
			this.Controls.SetChildIndex(this.lblCreateDate, 0);
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
			this.Controls.SetChildIndex(this.lblAddress, 0);
			this.Controls.SetChildIndex(this.lblLinkMan, 0);
			this.Controls.SetChildIndex(this.lblMarriaged, 0);
			this.Controls.SetChildIndex(this.lblOccupation, 0);
			this.Controls.SetChildIndex(this.lblNativePlace, 0);
			this.Controls.SetChildIndex(this.lblDept, 0);
			this.Controls.SetChildIndex(this.m_cboDept, 0);
			this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
			this.Controls.SetChildIndex(this.m_cmdNext, 0);
			this.Controls.SetChildIndex(this.m_cmdPre, 0);
			this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
			this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
			this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
			this.Controls.SetChildIndex(this.m_grpRegister1, 0);
			this.Controls.SetChildIndex(this.m_dtmRegisterDate1, 0);
			this.Controls.SetChildIndex(this.groupBox4, 0);
			this.Controls.SetChildIndex(this.m_cmdNew, 0);
			this.Controls.SetChildIndex(this.m_cmdSummary1, 0);
			this.m_grpRegister1.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private void m_mthGoToPage(string p_strPage)
		{

			try
			{
				DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text); 
			}
			catch
			{
				return;
			}

			int iPageCount;
			long m_lngRs=0;
			int iNewPageIndex=0;
			this.m_dtmRegisterDate2.Visible=false; 
	

		
			this.m_lblPage.Text ="0/0";
			

			clsRegisterQuantity_VO objContent=new clsRegisterQuantity_VO();
			objContent.m_dtmDeActivedDate= Convert.ToDateTime(DateTime.Now); 
			objContent.m_strDeActivedUserID =_strEmployeeNo;
			objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
            objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_intCurrentPage =iCurrentPage;
			objContent.m_strGoPage =p_strPage;

			m_mthClearControlValue(this.m_grpRegister1);  
			//m_mthClearControlValue(this.m_grpRegister2);  
			//Get record  id
			clsRegisterQuantity_VODataInfo[] p_objTansDataInfo;

            com.digitalwave.clsRecordsService.clsRegisterQuantityService objDB =
                (com.digitalwave.clsRecordsService.clsRegisterQuantityService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsRegisterQuantityService));

			m_lngRs=objDB.m_lngGetCustomsDataPage(objContent,out p_objTansDataInfo,out iPageCount,out iNewPageIndex);
			objDB=null;
			iCurrentPage=iNewPageIndex;
			//
			m_mthSetNavButton(false);
			if(p_objTansDataInfo==null)
			{
				
					return;
			}
			if(p_objTansDataInfo.Length==0)
			{
				
			
				return;
			}
			
			
	        
			m_mthSetNavButton(true);
			if(iPageCount==1)
			{
				this.m_cmdNextPage.Enabled =false;
				this.m_cmdPrevious.Enabled =false;
			}
			else if(iPageCount>=1)
			{
				if(iNewPageIndex==1)
				{
					
					this.m_cmdPrevious.Enabled =false;
				}
				else if(iNewPageIndex==iPageCount)
				{
                  
					this.m_cmdNextPage.Enabled =false; 
				}
				
			}
			this.m_lblPage.Text =iNewPageIndex+"/" + iPageCount;
			m_mthSetControlValueFromObj(p_objTansDataInfo[0],this.m_grpRegister1,1);
			
		
			
		//	m_mthSetControlValueFromObj(p_objTansDataInfo[1],this.m_grpRegister2,2);
			
			p_objTansDataInfo=null;

	
			m_blnNewRecord =false;
				m_mthAddFormStatusForClosingSave();

			
		}
	
		private void m_mthSetNavButton(bool p_bolEnable)
		{
			this.m_cmdPrevious.Enabled =p_bolEnable;
			this.m_cmdFirst.Enabled =p_bolEnable ;
			this.m_cmdLast.Enabled =p_bolEnable;
			this.m_cmdNextPage.Enabled =p_bolEnable; 
		}
		private void m_mthSetControlValueFromObj(clsRegisterQuantity_VODataInfo p_objTansDataInfo,GroupBox grp,Byte iType)
		{

			if( p_objTansDataInfo==null)return;
			string strTempColName="";
			if(grp.Name=="m_grpRegister1")
			{ 
				
				m_dtmRegisterDate1.Text=Convert.ToString( p_objTansDataInfo.m_objMainRecord.m_dtmRegDate);
				
				m_intRegID=p_objTansDataInfo.m_objMainRecord.m_intRegID;
				m_txtInSummary1.m_mthSetNewText(p_objTansDataInfo.m_objMainRecord.m_strInSummary,p_objTansDataInfo.m_objMainRecord.m_strInSummaryXML);
				m_txtOutSummary1.m_mthSetNewText(p_objTansDataInfo.m_objMainRecord.m_strOutSummary,p_objTansDataInfo.m_objMainRecord.m_strOutSummaryXML);
				m_txtNureSummary1.m_mthSetNewText(p_objTansDataInfo.m_objMainRecord.m_strOutUrineSummary,p_objTansDataInfo.m_objMainRecord.m_strOutUrineSummaryXML);
				m_txtOutSummaryRate1.m_mthSetNewText(p_objTansDataInfo.m_objMainRecord.m_strOutSummaryRate,p_objTansDataInfo.m_objMainRecord.m_strOutSummaryRateXML );
				m_txtInColumnName1.Text =p_objTansDataInfo.m_objMainRecord.m_strCustomInComumnName;
				m_txtOutColumnName1.Text =p_objTansDataInfo.m_objMainRecord.m_strCustomOutComumnName;


				if(p_objTansDataInfo.m_objMainRecord.m_strRecordersignID!= null && p_objTansDataInfo.m_objMainRecord.m_strRecordersignName!= "")
				{
                    clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                    objEmployeeSign.m_lngGetEmpByNO(p_objTansDataInfo.m_objMainRecord.m_strRecordersignID, out objEmpVO);
                    m_txtSign1.Tag = objEmpVO;
                    m_txtSign1.Text = p_objTansDataInfo.m_objMainRecord.m_strRecordersignName.Trim();
				}
				
			}
			else
			{
				

			}
			

		
			strTempColName="m_txtItem";
			
			for(int i1=0;i1<p_objTansDataInfo.m_objRecordArr.Length;i1++ )
			{
				int iTemp=i1+1;
				//向txtBox赋值
                strTempColName="m_txtItem";
				m_mthSetControlValue(strTempColName+iTemp+"1",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem1,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem1XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"2",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem2,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem2XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"3",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem3,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem3XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"4",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem4,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem4XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"5",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem5,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem5XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"6",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem6,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem6XML,grp); 
				
				m_mthSetControlValue(strTempColName+iTemp+"8",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem8,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem8XML,grp); 

				
				
				m_mthSetControlValue(strTempColName+iTemp+"11",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem3,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem3XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"12",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem4,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem4XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"13",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem5,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem5XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"14",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem6,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem6XML,grp); 
				
				m_mthSetControlValue(strTempColName+iTemp+"16",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem8,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem8XML,grp); 
				//向cboBox赋值
				strTempColName="m_cboItem";
				m_mthSetControlValue(strTempColName+iTemp+"9",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem1,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem1XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"10",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem2,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem2XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"15",p_objTansDataInfo.m_objRecordArr[i1].m_strInItem7,p_objTansDataInfo.m_objRecordArr[i1].m_strInItem7XML,grp); 
				m_mthSetControlValue(strTempColName+iTemp+"7",p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem7,p_objTansDataInfo.m_objRecordArr[i1].m_strOutItem7XML,grp); 


				
			}
			m_mthSetModifyControl2(p_objTansDataInfo.m_objMainRecord.m_strModifyUserID,false);
			
		}
		//清空所有的值
		private void m_mthClearControlValue(GroupBox grp)
		{
			com.digitalwave.controls.ctlRichTextBox m_txtTemp=new ctlRichTextBox();
			com.digitalwave.Utility.Controls.ctlComboBox m_cboTemp=new com.digitalwave.Utility.Controls.ctlComboBox();
			foreach(Control subcontrol in grp.Controls)
			{					
				 	
	
				if(subcontrol  is com.digitalwave.controls.ctlRichTextBox)
				{
					m_txtTemp=(ctlRichTextBox)subcontrol;
					m_txtTemp.m_mthClearText(); 
				
				}
				else if(subcontrol  is System.Windows.Forms.TextBox)
				{
					((TextBox)subcontrol).Clear();
                    subcontrol.Tag = null;
				}
				else if(subcontrol is com.digitalwave.Utility.Controls.ctlComboBox)
				{	
					m_cboTemp=(com.digitalwave.Utility.Controls.ctlComboBox)subcontrol;
                    m_cboTemp.SelectedIndex = -1;
					m_cboTemp.Text ="";
				}
			}
			m_txtTemp=null;
	        m_mthSetModifyControl(null,true);
	
		} 	
	
		//设置Textbox的值
		private void m_mthSetControlValue(string p_strColName,string p_strText,string p_strXML,GroupBox grp)
		{
			
            com.digitalwave.controls.ctlRichTextBox m_txtTemp=new ctlRichTextBox();
			com.digitalwave.Utility.Controls.ctlComboBox m_cboTemp=new com.digitalwave.Utility.Controls.ctlComboBox();
			foreach(Control subcontrol in grp.Controls)
			{										
	
				if(subcontrol.Name ==p_strColName)
				{
					if(subcontrol  is com.digitalwave.controls.ctlRichTextBox)
					{
                     m_txtTemp=(ctlRichTextBox)subcontrol;
					 m_txtTemp.m_mthSetNewText(p_strText,p_strXML);
					}
					else if(subcontrol is com.digitalwave.Utility.Controls.ctlComboBox)
					{
                         m_cboTemp=(com.digitalwave.Utility.Controls.ctlComboBox)subcontrol;
						 m_cboTemp.Text  =p_strText; 
						
					}
					else
					{
                     subcontrol.Text =p_strText;
					}
					
					return;
				}

			} 	
			m_txtTemp=null;
			m_cboTemp=null;
			
			
		}
	

	
		private void m_cmdSave1_Click(object sender, System.EventArgs e)
		{
			
		}
		private void frmRegisterQuantity_Load(object sender, System.EventArgs e)
		{
			TreeNode tndInPatientDate=new TreeNode();
			tndInPatientDate.Text ="入院日期";
			this.trvTime.Nodes.Add(tndInPatientDate); 
			m_mthSetQuickKeys();
			// m_mthGoToPage("First");

			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		

		
		}

		private void m_cmdSave1_Click_1(object sender, System.EventArgs e)
		{
          // long m_lgnRes=m_lngSubAddNew();
			
		}

		
	private void m_mthCount(GroupBox m_grpTemp)
		{
            float m_floOutSummary=0;
			float m_floIntSummary=0;
			float m_floUrineSummary=0;
		    string strTemp;
			com.digitalwave.controls.ctlRichTextBox m_txtTemp=new ctlRichTextBox();
		    com.digitalwave.Utility.Controls.ctlComboBox m_cboTemp=new  com.digitalwave.Utility.Controls.ctlComboBox ();
		try
		{
			foreach(Control subcontrol in m_grpTemp.Controls)
			{										
				if(subcontrol.Text.Trim()!=""&&subcontrol.Text!=null&&(subcontrol is com.digitalwave.controls.ctlRichTextBox)) 
				{
					m_txtTemp=(ctlRichTextBox)subcontrol;
					strTemp=m_txtTemp.m_strGetRightText(); 
					if(strTemp!=null)
					{
						if( m_bolIsNumeric(strTemp)==true)
						{
							if(subcontrol.Tag.ToString() !="Summary")
							{
								if(subcontrol.Tag.ToString() !="In")
								{
									//统计出量
							
									m_floOutSummary=m_floOutSummary+(float)Convert.ToDecimal (strTemp); 
									if(subcontrol.Tag.ToString() =="Urine")
									{
										m_floUrineSummary=m_floUrineSummary+(float)Convert.ToDecimal(strTemp ); 
									}
								}
								else
								{
									m_floIntSummary=m_floIntSummary+(float)Convert.ToDecimal(strTemp); 
								


								}
							}
						}
					}
					
				}
				else if (subcontrol is com.digitalwave.Utility.Controls.ctlComboBox) 
				{
					m_cboTemp=(com.digitalwave.Utility.Controls.ctlComboBox)subcontrol;
					strTemp=m_cboTemp.Text;
					if(strTemp!=null)
					{
						if( m_bolIsNumeric(strTemp)==true)
						{
							if(subcontrol.Tag.ToString() !="Summary")
							{
								if(subcontrol.Tag.ToString() !="In")
								{
									//统计出量
							
									m_floOutSummary=m_floOutSummary+(float)Convert.ToDecimal (strTemp); 
									if(subcontrol.Tag.ToString() =="Urine")
									{
										m_floUrineSummary=m_floUrineSummary+(float)Convert.ToDecimal(strTemp ); 
									}
								}
								else
								{
									m_floIntSummary=m_floIntSummary+(float)Convert.ToDecimal(strTemp); 
								


								}
							}
						}
					}
				}

			} 	
			if(m_grpTemp.Name=="m_grpRegister1") 
			{
				m_txtInSummary1.Text =m_floIntSummary.ToString(); 
				m_txtOutSummary1.Text  =m_floOutSummary.ToString(); 
				m_txtNureSummary1.Text  =m_floUrineSummary.ToString(); 
				
			 
			}
			else
			{
			
				
			}
		}
		catch
		{
         
		}
			return;
		}
		
		private void m_cmdDelete1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void m_cmdFirst_Click(object sender, System.EventArgs e)
		{
			m_dlgHandleSaveBeforePrint();
			m_mthGoToPage("First") ;
			m_mthAddFormStatusForClosingSave();
		
		}

		private void m_cmdPrevious_Click(object sender, System.EventArgs e)
		{
			m_dlgHandleSaveBeforePrint();
			m_mthGoToPage("Previous") ;
			 m_mthAddFormStatusForClosingSave();
		

		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			m_dlgHandleSaveBeforePrint();
		     m_mthGoToPage("Next") ;
		 	 m_mthAddFormStatusForClosingSave();
		
		}

		private void m_cmdLast_Click(object sender, System.EventArgs e)
		{
			m_dlgHandleSaveBeforePrint();
			m_mthGoToPage("Last") ;
			m_mthAddFormStatusForClosingSave();
		}

		private long m_lngSaveRecord()
		{
			
			DialogResult dlgResult = DialogResult.None;
			try
			{
				DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text);
			
			}
			catch
			{
				return 0;
			}
            
            try
			{
                DateTime dtmInDate = DateTime.Parse(this.m_dtmRegisterDate1.Text);
			
			}
			catch
			{
                clsPublicFunction.ShowInformationMessageBox("请输入正确的记录日期！");
                return 0;
                 
			}
            

			clsRegisterQuantity_VODataInfo objContent=new  clsRegisterQuantity_VODataInfo();
			clsRegisterQuantity_VO objContentDetaill=new clsRegisterQuantity_VO();
			clsRegisterQuantity_VO objMainRecordInfo=new clsRegisterQuantity_VO();
			clsRegisterQuantity_VO objChkRecordInfo=new clsRegisterQuantity_VO();

			string iTemp=string.Empty;


			objMainRecordInfo.m_strCreateUserID =_strEmployeeNo;
            objMainRecordInfo.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objMainRecordInfo.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			objMainRecordInfo.m_dtmCreateDate =Convert.ToDateTime(DateTime.Now.ToString()); 
			objMainRecordInfo.m_dtmRegDate  =Convert.ToDateTime(this.m_dtmRegisterDate1.Text).Date; 
			//objMainRecordInfo.m_intRegID=1; 从数据库中自动取得
			objMainRecordInfo.m_bytStatus= 0;
			objMainRecordInfo.m_strModifyUserID=_strEmployeeNo;; 
			objMainRecordInfo.m_dtmModifyDate =Convert.ToDateTime(DateTime.Now.ToString()); 

			objMainRecordInfo.m_dtmOpenDate=  Convert.ToDateTime(DateTime.Now.ToString()); 
			objMainRecordInfo.m_strInSummary=m_txtInSummary1.Text;
			objMainRecordInfo.m_strInSummaryXML=m_txtInSummary1.m_strGetXmlText(); 
			objMainRecordInfo.m_strOutSummary=this.m_txtOutSummary1.Text;
			objMainRecordInfo.m_strOutSummaryXML=this.m_txtOutSummary1.m_strGetXmlText();
			objMainRecordInfo.m_strOutSummaryRate =this.m_txtOutSummaryRate1.Text;
			objMainRecordInfo.m_strOutSummaryRateXML =this.m_txtOutSummaryRate1.m_strGetXmlText();
			objMainRecordInfo.m_strOutUrineSummary =this.m_txtNureSummary1.Text;
			objMainRecordInfo.m_strOutUrineSummaryXML =this.m_txtNureSummary1.m_strGetXmlText();
			objMainRecordInfo.m_strCustomInComumnName=this.m_txtInColumnName1.Text ; 
			objMainRecordInfo.m_strCustomOutComumnName =this.m_txtOutColumnName1.Text ; 
			objMainRecordInfo.m_strModifyUserName=_strEmployeeName; 
			//签名
			if(m_txtSign1.Tag != null)
			{
				objMainRecordInfo.m_strRecordersignID =((clsEmrEmployeeBase_VO)m_txtSign1.Tag).m_strEMPNO_CHR;
				objMainRecordInfo.m_strRecordersignName =m_txtSign1.Text;
			}


			objContent.m_objMainRecord =(clsRegisterQuantity_VO)objMainRecordInfo;
   
			ArrayList arlModifyData = new ArrayList();
			string m_strTempText=null;
			string m_strTempTextXML=null;
			//Get all the item value from the GUI
			for(int i1=0;i1<4;i1++)
			{
				iTemp=Convert.ToString (i1+1);
				objContentDetaill=new clsRegisterQuantity_VO(); 
				objContentDetaill.m_intPeriodID=i1+1; 
                //7,9,10,15 cboBox

				m_mthGetControlValue("m_cboItem"+iTemp+"9",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem1=m_strTempText;
				objContentDetaill.m_strInItem1XML=m_strTempTextXML;
				m_mthGetControlValue("m_cboItem"+iTemp+"10",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem2=m_strTempText;
				m_mthGetControlValue("m_cboItem"+iTemp+"15",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem7=m_strTempText;
				objContentDetaill.m_strInItem7XML=m_strTempTextXML;
				m_mthGetControlValue("m_cboItem"+iTemp+"7",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem7=m_strTempText;
				objContentDetaill.m_strOutItem7XML=m_strTempTextXML;


				objContentDetaill.m_strInItem2XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"11",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem3=m_strTempText;
				objContentDetaill.m_strInItem3XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"12",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem4=m_strTempText;
				objContentDetaill.m_strInItem4XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"13",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem5=m_strTempText;
				objContentDetaill.m_strInItem5XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"14",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem6=m_strTempText;
				objContentDetaill.m_strInItem6XML=m_strTempTextXML;
				
				m_mthGetControlValue("m_txtItem"+iTemp+"16",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strInItem8=m_strTempText;
				objContentDetaill.m_strInItem8XML=m_strTempTextXML;

				m_mthGetControlValue("m_txtItem"+iTemp+"1",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem1=m_strTempText;
				objContentDetaill.m_strOutItem1XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"2",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem2=m_strTempText;
				objContentDetaill.m_strOutItem2XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"3",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem3=m_strTempText;
				objContentDetaill.m_strOutItem3XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"4",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem4=m_strTempText;
				objContentDetaill.m_strOutItem4XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"5",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem5=m_strTempText;
				objContentDetaill.m_strOutItem5XML=m_strTempTextXML;
				m_mthGetControlValue("m_txtItem"+iTemp+"6",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem6=m_strTempText;
				objContentDetaill.m_strOutItem6XML=m_strTempTextXML;

				m_mthGetControlValue("m_txtItem"+iTemp+"8",this.m_grpRegister1,out m_strTempText,out m_strTempTextXML); 
				objContentDetaill.m_strOutItem8=m_strTempText;
				objContentDetaill.m_strOutItem8XML=m_strTempTextXML;

				arlModifyData.Add (objContentDetaill);
			 
			}
			objContent.m_objRecordArr=(clsRegisterQuantity_VO[])arlModifyData.ToArray(typeof(clsRegisterQuantity_VO));
			arlModifyData.Clear();
			  
			
			long m_lngRs=0;

            com.digitalwave.clsRecordsService.clsRegisterQuantityService objDB =
                (com.digitalwave.clsRecordsService.clsRegisterQuantityService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsRegisterQuantityService));

			m_lngRs=objDB.m_lngCheckRegisterDate((clsRegisterQuantity_VO)objContent.m_objMainRecord,m_intRegID,out objChkRecordInfo);
	        if(m_lngRs<0) return m_lngRs;
			if (objChkRecordInfo.m_strModifyUserID!=null)
			{
				
					dlgResult = clsPublicFunction.ShowQuestionMessageBox("["+objChkRecordInfo.m_strModifyUserName.Trim() +"]在["+objChkRecordInfo.m_dtmModifyDate.ToString()  +"]修改过同样的记录，是否继续保存？",MessageBoxButtons.YesNoCancel);
					if(dlgResult!=DialogResult.Yes)return 99;
			}

			//电子签名 
			//记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
			
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_objMainRecord.m_strInPatientID.Trim()+"-"+objContent.m_objMainRecord.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                return -1;


			m_lngRs=objDB.m_lngAddNewRecord2DB(objContent,m_intRegID);
			
			objDB=null;
			
			return m_lngRs;
		}
		protected override long m_lngSubAddNew()
		{
    		m_blnFirstShow=false;
			try
  			{
				DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text); 
			}
			catch
			{
				return 99;
			}

            long m_lngRs=0;

			m_lngRs=m_lngSaveRecord();
			if(m_lngRs==99)
			{
				return m_lngRs;
			}
			
			m_mthGoToPage("Refresh");
			
			m_mthAddFormStatusForClosingSave();
			m_blnNewRecord=false;
			return m_lngRs;
		}
		protected override void trvTime_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
                //m_dlgHandleSaveBeforePrint();
				m_mthClearControlValue(this.m_grpRegister1);  
				//m_mthClearControlValue(this.m_grpRegister2);  
				DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text);

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrHISInPatientID;
                
                DateTime dtmEMRInDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_DtmEMRInDate;
                string strEMRInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(trvTime.Nodes[0].Nodes.Count - trvTime.SelectedNode.Index - 1).m_StrEMRInPatientID;

                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(trvTime.SelectedNode.Text);
                if (dtmEMRInDate != new DateTime(1900, 1, 1))
                {
                    m_objBaseCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                    m_objCurrentPatient.m_DtmSelectedInDate = dtmEMRInDate;
                }

                if (string.IsNullOrEmpty(m_objBaseCurrentPatient.m_StrRegisterId))
                {
                    string strRegisterID = string.Empty;
                    long lngRes = new clsPublicDomain().m_lngGetRegisterID(m_objCurrentPatient.m_StrPatientID, Convert.ToDateTime(trvTime.SelectedNode.Text).ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                }
                
                m_mthIsReadOnly();

                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				if(m_blnFirstShow==true)
				{
					m_mthGoToPage("Last");
		
				}
				else
				{
                   m_mthGoToPage("Refresh");
				}
				
				m_blnFirstShow=true;

				m_mthAddFormStatusForClosingSave()	;
			}
			catch
			{
               return;
			}
			
                      
		}

		protected override long m_lngSubDelete()
		{
		
			//验证删除
			clsDeleteVerify objDeleteVerify=new clsDeleteVerify();
			if (objDeleteVerify.m_mthIsDelete(null,null)==false)
			{
				clsPublicFunction.ShowInformationMessageBox("验证失败不能删除！");
				return 0;
			}
			//释放
			objDeleteVerify=null;

            try
            {
                DateTime dtmInDate = DateTime.Parse(this.m_dtmRegisterDate1.Text);

            }
            catch
            {
                clsPublicFunction.ShowInformationMessageBox("请输入正确的记录日期！");
                return 0;

            }

            com.digitalwave.clsRecordsService.clsRegisterQuantityService objDB =
                (com.digitalwave.clsRecordsService.clsRegisterQuantityService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsRecordsService.clsRegisterQuantityService));

			clsRegisterQuantity_VO objMainRecordInfo=new clsRegisterQuantity_VO();
			objMainRecordInfo.m_dtmDeActivedDate= Convert.ToDateTime(DateTime.Now); 
			objMainRecordInfo.m_strDeActivedUserID =_strEmployeeNo;
            objMainRecordInfo.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate; 
			objMainRecordInfo.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			objMainRecordInfo.m_dtmRegDate  =Convert.ToDateTime(this.m_dtmRegisterDate1.Text).Date; 
			
			long m_lngRs=objDB.m_lngDeleteRecord(objMainRecordInfo);

			objDB=null;
            objMainRecordInfo=null;
			m_mthGoToPage("Refresh");
			
			 m_mthAddFormStatusForClosingSave()	;
			return m_lngRs;
		}
		private bool m_bolIsNumeric(string p_strValue)
		{
			try
			{
				double dblTemp= Convert.ToDouble(p_strValue); 
				return true;
			}
			catch
			{
				return false;
			}
			
		}

		private void m_cmdSummary1_Click_1(object sender, System.EventArgs e)
		{
		  m_mthCount(this.m_grpRegister1);
		}

		private void m_cmdNextPage_Click(object sender, System.EventArgs e)
		{
		m_dlgHandleSaveBeforePrint();
				
		  m_mthGoToPage("Next");
			
		  m_mthAddFormStatusForClosingSave() ;
		}
		protected override void m_mthAddFormStatusForClosingSave()
		{
			//记录设置窗体当前状态
			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);
		}
		
		protected override DialogResult m_dlgHandleSaveBeforePrint()
		{
			DialogResult dlgResult = DialogResult.None;
			try
			{
				DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text);
			
			}
			catch
			{
				return DialogResult.Cancel;
			}
			

			if(!MDIParent.s_ObjSaveCue.m_blnCheckStatusSame(this))
			{
				dlgResult = clsPublicFunction.ShowQuestionMessageBox("[" + this.Text+ "]做了改动，是否保存？",MessageBoxButtons.YesNoCancel);

				if(dlgResult==DialogResult.Yes)
				m_lngSaveRecord();
			}
			return dlgResult;
		}

		private void m_cmdNew_Click(object sender, System.EventArgs e)
		{
			//
			m_dlgHandleSaveBeforePrint();
			m_intRegID=0;
			m_mthClearControlValue(this.m_grpRegister1 );  
			this.m_dtmRegisterDate1.Text =DateTime.Today.ToString();
           

		}

		#region 打印
		protected override void m_mthStartPrint()
		{
			//缺省使用打印预览，子窗体重载提供新的实现
			PageSetupDialog psd=new PageSetupDialog();
			try
			{
				if (m_pdcPrintDocument.DefaultPageSettings == null) 
				{
					m_pdcPrintDocument.DefaultPageSettings =  new PageSettings();
				}	
				m_pdcPrintDocument.DefaultPageSettings.Landscape =true;
				m_pdcPrintDocument.DefaultPageSettings.PaperSize=new PaperSize("A4",1024,768);
			
				psd.PageSettings = m_pdcPrintDocument.DefaultPageSettings ;
				
				if(	psd.ShowDialog() !=DialogResult.Cancel)
				{
					m_pdcPrintDocument.DefaultPageSettings.Landscape=psd.PageSettings.Landscape;
					m_pdcPrintDocument.DefaultPageSettings.PaperSize=psd.PageSettings.PaperSize;
				}
				else 
				{
					return;
				}
				m_objPrintTool.m_mthInitPrintTool(null);
                m_objPrintTool.m_mthSetPrintInfo(m_objCurrentPatient, m_objCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
				if(m_blnDirectPrint)
				{
				   //m_mthBeginPrint(System.Drawing.Printing.PrintPageEventArgs); 
				 // m_pdcPrintDocument.Print();
					m_pdcPrintDocumentNew.DefaultPageSettings.Landscape=psd.PageSettings.Landscape;
					m_pdcPrintDocumentNew.DefaultPageSettings.PaperSize=psd.PageSettings.PaperSize;
                    m_pdcPrintDocumentNew.Print();  

				}
				else
				{

					m_objPrintTool.m_mthPrintPage(m_pdcPrintDocument.DefaultPageSettings);
				
				}
			}
			catch(Exception ex)
			{
				if(ex.Message.IndexOf("No Printers installed")>=0)
					clsPublicFunction.ShowInformationMessageBox("找不到打印机！");
				else MessageBox.Show( ex.Message);
			}
			
			//			base.m_mthStartPrint();
			
		}

		protected override long m_lngSubPrint()

		{
			try
			{
				DateTime dtmInDate = DateTime.Parse(trvTime.SelectedNode.Text); 
			}
			catch
			{
				return 1;
			}

			//			return new clsIntensiveTendMainPrintTool();
			m_objPrintTool=new clsRegisterQuantity_PrintTool_GX(); 
		    m_mthStartPrint();
			return 1;
		}
		#endregion
	
		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		private void m_mthSetModifyControl2(string p_strModifyUserID,bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_blnReset==true)
			{
				

				m_mthSetRichTextModifyColor(this,clsHRPColor.s_ClrInputFore);
				m_mthSetRichTextCanModifyLast(this,true);
		
			}
			else if(p_strModifyUserID!=null)
			{
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_strModifyUserID.Trim()));
				
			}
		}

		private void m_pdcPrintDocumentNew_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		  m_objPrintTool.m_mthBeginPrint (e);
		}

		private void m_pdcPrintDocumentNew_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
		 m_objPrintTool.m_mthEndPrint(e); 
		}

		private void m_pdcPrintDocumentNew_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_objPrintTool.m_mthPrintPage(e);
		 
		}

		
		
	}
}
