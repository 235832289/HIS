using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;

using iCareData;
using com.digitalwave.Utility;
using com.digitalwave.Utility.Controls;


namespace iCare
{
	public class frmLabCheckReport : iCare.frmHRPBaseForm,PublicFunction
	{
		#region Control Define

		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		protected System.Windows.Forms.ListView lsvBarCode;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ListView lsvCheckResult;
		private System.Windows.Forms.ListView lsvCheckItem;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label m_lblDiagnose;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label m_lbldoct;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label m_lblIname;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label m_lblchk;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label m_lblsname;
		private System.Windows.Forms.Label label6;
		public com.digitalwave.Utility.Controls.ctlBorderTextBox txtBarCode;
		private System.Windows.Forms.Label m_lblRemark;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label m_lblResultDate;
		private com.digitalwave.controls.ctlRichTextBox m_txtLabCheckResult;
		private PinkieControls.ButtonXP cmdCancel;
		private PinkieControls.ButtonXP cmdConfirm;
		private System.Windows.Forms.ContextMenu ctmPickUp;
		private System.Windows.Forms.MenuItem mniPickUp;
		private System.Windows.Forms.MenuItem mniPickUpAll;
		private System.Windows.Forms.Label lblCheckResult;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label m_lblCheckOrder;
		private System.Windows.Forms.Label m_lblbarname;
		private System.Windows.Forms.Label m_lblbcnt;
		private System.Windows.Forms.Label m_lblDesription;
		private PinkieControls.ButtonXP m_cmdClear;
		private System.ComponentModel.IContainer components = null;
		#endregion

		#region Constructor
		public frmLabCheckReport()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			m_objLabAnalysisOrderDomain = new clsLabAnalysisOrderDomain();

            //m_objBorderTool = new clsBorderTool(Color.White);

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{lsvCheckItem,lsvCheckResult});

			m_mthSetQuickKeys();

			m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);

			txtBarCode.Focus();
		}
		#endregion

		#region Member

        //private clsBorderTool  m_objBorderTool;

		private bool m_blnCanSearch = true;

		private string m_strInPatientID;

		private string m_strInPatientDate;

		private clsPatient m_objSelectedPatient=null;

		private clsLabAnalysisOrderDomain m_objLabAnalysisOrderDomain;

		#endregion

		#region Dispose
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
				m_objSelectedPatient = null;
				m_objLabAnalysisOrderDomain = null;
                //m_objBorderTool = null;
				if(m_pdcPrintDocument != null)
				{
					m_pdcPrintDocument.Dispose();
					m_pdcPrintDocument = null;
				}
				m_objPrintTool = null;
				if(ppdPrintPreview != null)
				{
					ppdPrintPreview.Dispose();
					ppdPrintPreview = null;
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lsvCheckResult = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.txtBarCode = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lsvBarCode = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.lsvCheckItem = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblDiagnose = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lbldoct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblIname = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblchk = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_lblsname = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblRemark = new System.Windows.Forms.Label();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblResultDate = new System.Windows.Forms.Label();
            this.m_txtLabCheckResult = new com.digitalwave.controls.ctlRichTextBox();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.cmdConfirm = new PinkieControls.ButtonXP();
            this.ctmPickUp = new System.Windows.Forms.ContextMenu();
            this.mniPickUp = new System.Windows.Forms.MenuItem();
            this.mniPickUpAll = new System.Windows.Forms.MenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.m_lblCheckOrder = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_lblbarname = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.m_lblbcnt = new System.Windows.Forms.Label();
            this.m_lblDesription = new System.Windows.Forms.Label();
            this.m_cmdClear = new PinkieControls.ButtonXP();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(628, 72);
            this.lblSex.Size = new System.Drawing.Size(60, 19);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(768, 72);
            this.lblAge.Size = new System.Drawing.Size(56, 19);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(256, 72);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(828, 72);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(388, 72);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(552, 72);
            this.lblSexTitle.Size = new System.Drawing.Size(63, 14);
            this.lblSexTitle.Text = "性   别:";
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(696, 72);
            this.lblAgeTitle.Size = new System.Drawing.Size(56, 14);
            this.lblAgeTitle.Text = "年  龄:";
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(12, 68);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(900, 92);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(892, 68);
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(444, 68);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(304, 68);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(64, 64);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(448, 96);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(308, 92);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(64, 32);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(12, 36);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.AutoSize = true;
            this.m_lblForTitle.Location = new System.Drawing.Point(392, 16);
            this.m_lblForTitle.Size = new System.Drawing.Size(105, 14);
            this.m_lblForTitle.Text = "检 验 报 告 单";
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(743, 20);
            // 
            // lsvCheckResult
            // 
            this.lsvCheckResult.BackColor = System.Drawing.Color.White;
            this.lsvCheckResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lsvCheckResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCheckResult.ForeColor = System.Drawing.Color.Black;
            this.lsvCheckResult.FullRowSelect = true;
            this.lsvCheckResult.GridLines = true;
            this.lsvCheckResult.Location = new System.Drawing.Point(12, 324);
            this.lsvCheckResult.Name = "lsvCheckResult";
            this.lsvCheckResult.Size = new System.Drawing.Size(980, 260);
            this.lsvCheckResult.TabIndex = 501;
            this.lsvCheckResult.TabStop = false;
            this.lsvCheckResult.UseCompatibleStateImageBehavior = false;
            this.lsvCheckResult.View = System.Windows.Forms.View.Details;
            this.lsvCheckResult.DoubleClick += new System.EventHandler(this.lsvCheckResult_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "组合项目名称";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "结    果";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "单   位";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "参  考  值";
            this.columnHeader5.Width = 350;
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.Color.White;
            this.txtBarCode.BorderColor = System.Drawing.Color.Transparent;
            this.txtBarCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBarCode.ForeColor = System.Drawing.Color.Black;
            this.txtBarCode.Location = new System.Drawing.Point(88, 96);
            this.txtBarCode.MaxLength = 7;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(156, 21);
            this.txtBarCode.TabIndex = 520;
            this.txtBarCode.Leave += new System.EventHandler(this.txtBarCode_Leave);
            // 
            // lsvBarCode
            // 
            this.lsvBarCode.BackColor = System.Drawing.Color.White;
            this.lsvBarCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvBarCode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.lsvBarCode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvBarCode.ForeColor = System.Drawing.Color.Black;
            this.lsvBarCode.FullRowSelect = true;
            this.lsvBarCode.GridLines = true;
            this.lsvBarCode.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvBarCode.Location = new System.Drawing.Point(88, 118);
            this.lsvBarCode.Name = "lsvBarCode";
            this.lsvBarCode.Size = new System.Drawing.Size(156, 104);
            this.lsvBarCode.TabIndex = 29253;
            this.lsvBarCode.UseCompatibleStateImageBehavior = false;
            this.lsvBarCode.View = System.Windows.Forms.View.Details;
            this.lsvBarCode.Visible = false;
            this.lsvBarCode.DoubleClick += new System.EventHandler(this.lsvBarCode_DoubleClick);
            this.lsvBarCode.Leave += new System.EventHandler(this.lsvBarCode_Leave);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 200;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 29254;
            this.label7.Text = "检验号：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lsvCheckItem
            // 
            this.lsvCheckItem.BackColor = System.Drawing.Color.White;
            this.lsvCheckItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lsvCheckItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCheckItem.ForeColor = System.Drawing.Color.Black;
            this.lsvCheckItem.FullRowSelect = true;
            this.lsvCheckItem.GridLines = true;
            this.lsvCheckItem.HideSelection = false;
            this.lsvCheckItem.Location = new System.Drawing.Point(12, 132);
            this.lsvCheckItem.Name = "lsvCheckItem";
            this.lsvCheckItem.Size = new System.Drawing.Size(516, 160);
            this.lsvCheckItem.TabIndex = 10000000;
            this.lsvCheckItem.TabStop = false;
            this.lsvCheckItem.UseCompatibleStateImageBehavior = false;
            this.lsvCheckItem.View = System.Windows.Forms.View.Details;
            this.lsvCheckItem.SelectedIndexChanged += new System.EventHandler(this.lsvCheckItem_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "组合项目";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "样本号";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "仪器代码";
            this.columnHeader8.Width = 120;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "送检日期";
            this.columnHeader9.Width = 160;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(256, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 16);
            this.label4.TabIndex = 10000002;
            this.label4.Text = "诊断:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDiagnose
            // 
            this.m_lblDiagnose.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblDiagnose.Location = new System.Drawing.Point(308, 98);
            this.m_lblDiagnose.Name = "m_lblDiagnose";
            this.m_lblDiagnose.Size = new System.Drawing.Size(300, 21);
            this.m_lblDiagnose.TabIndex = 10000001;
            this.m_lblDiagnose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(528, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 10000004;
            this.label1.Text = "送检医师:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lbldoct
            // 
            this.m_lbldoct.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lbldoct.Location = new System.Drawing.Point(612, 168);
            this.m_lbldoct.Name = "m_lbldoct";
            this.m_lbldoct.Size = new System.Drawing.Size(92, 21);
            this.m_lbldoct.TabIndex = 10000003;
            this.m_lbldoct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(816, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 10000006;
            this.label2.Text = "检验者:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblIname
            // 
            this.m_lblIname.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblIname.Location = new System.Drawing.Point(900, 168);
            this.m_lblIname.Name = "m_lblIname";
            this.m_lblIname.Size = new System.Drawing.Size(92, 21);
            this.m_lblIname.TabIndex = 10000005;
            this.m_lblIname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(528, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 10000008;
            this.label3.Text = "审核者：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblchk
            // 
            this.m_lblchk.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblchk.Location = new System.Drawing.Point(612, 200);
            this.m_lblchk.Name = "m_lblchk";
            this.m_lblchk.Size = new System.Drawing.Size(92, 21);
            this.m_lblchk.TabIndex = 10000007;
            this.m_lblchk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(816, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 10000010;
            this.label5.Text = "样本名:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblsname
            // 
            this.m_lblsname.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblsname.Location = new System.Drawing.Point(900, 200);
            this.m_lblsname.Name = "m_lblsname";
            this.m_lblsname.Size = new System.Drawing.Size(92, 21);
            this.m_lblsname.TabIndex = 10000009;
            this.m_lblsname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.Location = new System.Drawing.Point(528, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 10000012;
            this.label6.Text = "备注:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblRemark
            // 
            this.m_lblRemark.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblRemark.Location = new System.Drawing.Point(612, 232);
            this.m_lblRemark.Name = "m_lblRemark";
            this.m_lblRemark.Size = new System.Drawing.Size(376, 21);
            this.m_lblRemark.TabIndex = 10000011;
            this.m_lblRemark.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.AutoSize = true;
            this.lblCheckResult.Font = new System.Drawing.Font("宋体", 12F);
            this.lblCheckResult.Location = new System.Drawing.Point(12, 300);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(80, 16);
            this.lblCheckResult.TabIndex = 10000013;
            this.lblCheckResult.Text = "检验结果:";
            this.lblCheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(528, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 20);
            this.label9.TabIndex = 10000015;
            this.label9.Text = "报告日期:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblResultDate
            // 
            this.m_lblResultDate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblResultDate.Location = new System.Drawing.Point(612, 264);
            this.m_lblResultDate.Name = "m_lblResultDate";
            this.m_lblResultDate.Size = new System.Drawing.Size(148, 21);
            this.m_lblResultDate.TabIndex = 10000014;
            this.m_lblResultDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtLabCheckResult
            // 
            this.m_txtLabCheckResult.AccessibleDescription = "提取检验结果";
            this.m_txtLabCheckResult.BackColor = System.Drawing.Color.White;
            this.m_txtLabCheckResult.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtLabCheckResult.ForeColor = System.Drawing.Color.Black;
            this.m_txtLabCheckResult.Location = new System.Drawing.Point(12, 596);
            this.m_txtLabCheckResult.m_BlnPartControl = false;
            this.m_txtLabCheckResult.m_BlnReadOnly = false;
            this.m_txtLabCheckResult.m_BlnUnderLineDST = false;
            this.m_txtLabCheckResult.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtLabCheckResult.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtLabCheckResult.m_IntCanModifyTime = 6;
            this.m_txtLabCheckResult.m_IntPartControlLength = 0;
            this.m_txtLabCheckResult.m_IntPartControlStartIndex = 0;
            this.m_txtLabCheckResult.m_StrUserID = "";
            this.m_txtLabCheckResult.m_StrUserName = "";
            this.m_txtLabCheckResult.Name = "m_txtLabCheckResult";
            this.m_txtLabCheckResult.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtLabCheckResult.Size = new System.Drawing.Size(444, 100);
            this.m_txtLabCheckResult.TabIndex = 10000016;
            this.m_txtLabCheckResult.Text = "";
            this.m_txtLabCheckResult.Visible = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(460, 668);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(64, 32);
            this.cmdCancel.TabIndex = 10000018;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Visible = false;
            // 
            // cmdConfirm
            // 
            this.cmdConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdConfirm.DefaultScheme = true;
            this.cmdConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdConfirm.Hint = "";
            this.cmdConfirm.Location = new System.Drawing.Point(460, 596);
            this.cmdConfirm.Name = "cmdConfirm";
            this.cmdConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdConfirm.Size = new System.Drawing.Size(64, 32);
            this.cmdConfirm.TabIndex = 10000017;
            this.cmdConfirm.Text = "确定";
            this.cmdConfirm.Visible = false;
            this.cmdConfirm.Click += new System.EventHandler(this.cmdConfirm_Click);
            // 
            // ctmPickUp
            // 
            this.ctmPickUp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniPickUp,
            this.mniPickUpAll});
            // 
            // mniPickUp
            // 
            this.mniPickUp.Index = 0;
            this.mniPickUp.Text = "提        取";
            this.mniPickUp.Click += new System.EventHandler(this.mniPickUp_Click);
            // 
            // mniPickUpAll
            // 
            this.mniPickUpAll.Index = 1;
            this.mniPickUpAll.Text = "全部提取";
            this.mniPickUpAll.Click += new System.EventHandler(this.mniPickUpAll_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(616, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 16);
            this.label8.TabIndex = 10000020;
            this.label8.Text = "检查目的:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblCheckOrder
            // 
            this.m_lblCheckOrder.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblCheckOrder.Location = new System.Drawing.Point(704, 98);
            this.m_lblCheckOrder.Name = "m_lblCheckOrder";
            this.m_lblCheckOrder.Size = new System.Drawing.Size(288, 21);
            this.m_lblCheckOrder.TabIndex = 10000019;
            this.m_lblCheckOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F);
            this.label10.Location = new System.Drawing.Point(532, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 16);
            this.label10.TabIndex = 10000022;
            this.label10.Text = "菌  名:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblbarname
            // 
            this.m_lblbarname.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblbarname.Location = new System.Drawing.Point(612, 136);
            this.m_lblbarname.Name = "m_lblbarname";
            this.m_lblbarname.Size = new System.Drawing.Size(200, 21);
            this.m_lblbarname.TabIndex = 10000021;
            this.m_lblbarname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F);
            this.label12.Location = new System.Drawing.Point(816, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 16);
            this.label12.TabIndex = 10000024;
            this.label12.Text = "菌落计数:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblbcnt
            // 
            this.m_lblbcnt.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblbcnt.Location = new System.Drawing.Point(900, 135);
            this.m_lblbcnt.Name = "m_lblbcnt";
            this.m_lblbcnt.Size = new System.Drawing.Size(92, 21);
            this.m_lblbcnt.TabIndex = 10000023;
            this.m_lblbcnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblDesription
            // 
            this.m_lblDesription.Font = new System.Drawing.Font("宋体", 12F);
            this.m_lblDesription.Location = new System.Drawing.Point(720, 600);
            this.m_lblDesription.Name = "m_lblDesription";
            this.m_lblDesription.Size = new System.Drawing.Size(264, 20);
            this.m_lblDesription.TabIndex = 10000025;
            this.m_lblDesription.Text = "(说明：S-敏感，R-耐药，I-中介)";
            this.m_lblDesription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmdClear
            // 
            this.m_cmdClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClear.DefaultScheme = true;
            this.m_cmdClear.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdClear.Hint = "";
            this.m_cmdClear.Location = new System.Drawing.Point(460, 632);
            this.m_cmdClear.Name = "m_cmdClear";
            this.m_cmdClear.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClear.Size = new System.Drawing.Size(64, 32);
            this.m_cmdClear.TabIndex = 10000026;
            this.m_cmdClear.Text = "清空";
            this.m_cmdClear.Visible = false;
            this.m_cmdClear.Click += new System.EventHandler(this.m_cmdClear_Click);
            // 
            // frmLabCheckReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(856, 625);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.m_cmdClear);
            this.Controls.Add(this.m_lblDesription);
            this.Controls.Add(this.m_lblbcnt);
            this.Controls.Add(this.m_lblbarname);
            this.Controls.Add(this.m_lblCheckOrder);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdConfirm);
            this.Controls.Add(this.m_txtLabCheckResult);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_lblResultDate);
            this.Controls.Add(this.m_lblRemark);
            this.Controls.Add(this.m_lblsname);
            this.Controls.Add(this.m_lblchk);
            this.Controls.Add(this.m_lblIname);
            this.Controls.Add(this.m_lbldoct);
            this.Controls.Add(this.m_lblDiagnose);
            this.Controls.Add(this.lsvCheckItem);
            this.Controls.Add(this.lsvCheckResult);
            this.Controls.Add(this.lsvBarCode);
            this.Name = "frmLabCheckReport";
            this.Text = "检验报告单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLabCheckReport_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.lsvBarCode, 0);
            this.Controls.SetChildIndex(this.lsvCheckResult, 0);
            this.Controls.SetChildIndex(this.lsvCheckItem, 0);
            this.Controls.SetChildIndex(this.m_lblDiagnose, 0);
            this.Controls.SetChildIndex(this.m_lbldoct, 0);
            this.Controls.SetChildIndex(this.m_lblIname, 0);
            this.Controls.SetChildIndex(this.m_lblchk, 0);
            this.Controls.SetChildIndex(this.m_lblsname, 0);
            this.Controls.SetChildIndex(this.m_lblRemark, 0);
            this.Controls.SetChildIndex(this.m_lblResultDate, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.m_txtLabCheckResult, 0);
            this.Controls.SetChildIndex(this.cmdConfirm, 0);
            this.Controls.SetChildIndex(this.cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_lblCheckOrder, 0);
            this.Controls.SetChildIndex(this.m_lblbarname, 0);
            this.Controls.SetChildIndex(this.m_lblbcnt, 0);
            this.Controls.SetChildIndex(this.m_lblDesription, 0);
            this.Controls.SetChildIndex(this.m_cmdClear, 0);
            this.Controls.SetChildIndex(this.txtBarCode, 0);
            this.Controls.SetChildIndex(this.label7, 0);
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
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.lblCheckResult, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Override Function
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_objSelectedPatient = p_objSelectedPatient;

			m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
            m_strInPatientDate = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");

//			m_lblBedNo.Text = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName;
//			m_lblName.Text = p_objSelectedPatient.m_StrName;

			//查找检验项目
			clsJY_BRZL[] p_objPatientArr;
			
			long lngRes = m_objLabAnalysisOrderDomain.m_lngGetCheckItem(m_strInPatientID, out p_objPatientArr);

			if(p_objPatientArr == null || p_objPatientArr.Length == 0)
				return;

			lsvCheckItem.Items.Clear();

			//检验项目第一列的标题
//			lsvCheckItem.Columns[0].Text = p_objPatientArr[0].m_strPat_c_name;

			for(int i = 0; i < p_objPatientArr.Length; i++)
			{
				if(p_objPatientArr[i] == null)
					continue;

				if(p_objPatientArr[i].m_strPat_c_name=="")
					p_objPatientArr[i].m_strPat_c_name = p_objPatientArr[i].m_strPat_CheckOrder;

				ListViewItem lviNewItem = new ListViewItem(new string[]{p_objPatientArr[i].m_strPat_c_name,p_objPatientArr[i].m_strPat_sid,p_objPatientArr[i].m_strPat_mid,p_objPatientArr[i].m_dtmPat_sdate.ToString("yyyy-MM-dd 00:00:00")});

				lviNewItem.Tag = p_objPatientArr[i];
			
				lsvCheckItem.Items.Add(lviNewItem);
			}

			lsvCheckItem.Items[0].Selected = true;

		}



		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return m_blnCanSearch;
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}
		#endregion

		#region 键盘快捷键
		/// <summary>
		/// 是否处理检验号的TextChanged事件
		/// </summary>
		private bool m_blnCanBarCodeTextChanged = true;

		private void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
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
		
		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case 13:// enter				
					
					//					if(sender.GetType().Name!="ctlRichTextBox")
					//						SendKeys.Send(  "{tab}");
					if(((Control)sender).Name=="txtBarCode")
					{
//						m_mthGetBarCodeList(txtBarCode.Text);
						m_mthGetBarCodeList_Pat_ID(txtBarCode.Text);
			
						if(this.lsvBarCode .Items.Count==1 && (txtBarCode.Text==lsvBarCode.Items[0].SubItems[0].Text))
						{
							lsvBarCode.Items[0].Selected=true;
							lsvBarCode_DoubleClick(null,null);
							break;
						}
					}
					else if(((Control)sender).Name=="lsvBarCode")
					{
						lsvBarCode_DoubleClick(null,null);						
					}

					break;

				case 38:
				case 40:
					if(((Control)sender).Name=="txtBarCode" && lsvBarCode.Visible == true)
					{
						lsvBarCode.Focus();
						if(lsvBarCode.Items != null && lsvBarCode.Items.Count != 0)
						{
							lsvBarCode.Items[0].Selected = true;
							lsvBarCode.Items[0].Focused = true;
						}
					}
					break;	

				
				case 113://save
					break;
				case 114://del
					break;
				case 115://print
					this.m_lngPrint();
					break;
				case 116://refresh
					m_mthClearAll();
					break;
				case 117://Search					
					break;
			}	
		}

		#region old
		/// <summary>
		/// 显示列表
		/// </summary>
		/// <param name="p_strDoctorNameLike">医生号</param>
		private void m_mthGetBarCodeList(string p_strBarCodeLike)
		{
			if(!m_blnCanBarCodeTextChanged)
				return;

			if(p_strBarCodeLike.Length == 0)
			{
				lsvBarCode.Visible = false;
				return;
			}

			string[] strBarCodeArr ;
			long lngRes = m_objLabAnalysisOrderDomain.m_lngGetBarCodeList(p_strBarCodeLike, out strBarCodeArr);

			if(strBarCodeArr == null)
			{
				lsvBarCode.Visible = false;
				return;
			}

			lsvBarCode.Items.Clear();

			for(int i=0;i<strBarCodeArr.Length;i++)
			{
				ListViewItem lviBarCode = new ListViewItem(
					new string[]{
									strBarCodeArr[i]
								});
				lviBarCode.Tag = strBarCodeArr[i];

				lsvBarCode.Items.Add(lviBarCode);
			}

			lsvBarCode.BringToFront();
			lsvBarCode.Visible = true;
		}
		#endregion old

		/// <summary>
		/// 显示检验号列表，这里的BarCode相当于检验号Pat_ID
		/// </summary>
		/// <param name="p_strDoctorNameLike">检验号</param>
		private void m_mthGetBarCodeList_Pat_ID(string p_strBarCodeLike)
		{
			if(!m_blnCanBarCodeTextChanged)
				return;

			if(p_strBarCodeLike.Length == 0)
			{
				lsvBarCode.Visible = false;
				return;
			}

			string[] strBarCodeArr,strDeptNameArr; 
			long lngRes = m_objLabAnalysisOrderDomain.m_lngGetBarCodeList_Pat_ID(p_strBarCodeLike, out strBarCodeArr,out strDeptNameArr);

			if(strBarCodeArr == null)
			{
				lsvBarCode.Visible = false;
				return;
			}

			lsvBarCode.Items.Clear();

			for(int i=0;i<strBarCodeArr.Length;i++)
			{
				if(strDeptNameArr[i]==clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptName.Trim())
				{
					ListViewItem lviBarCode = new ListViewItem(
						new string[]{
										strBarCodeArr[i]
									});
					lviBarCode.Tag = strBarCodeArr[i];

					lsvBarCode.Items.Add(lviBarCode);
				}
			}

			lsvBarCode.BringToFront();
			lsvBarCode.Visible = true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lsvBarCode_DoubleClick(object sender, System.EventArgs e)
		{
			lsvCheckItem.Items.Clear();			

			m_mthClearAll();

			if(lsvBarCode.SelectedItems.Count <= 0)
				return;

			m_blnCanBarCodeTextChanged = false;
 
			txtBarCode.Text = lsvBarCode.SelectedItems[0].SubItems[0].Text;

			lsvBarCode.Visible = false;

			m_blnCanBarCodeTextChanged = true;

			//查找检验结果
			clsJY_BRZL p_objPatient;
			clsJY_JG[] p_objResultArr;
			clsJY_QXJG[] p_objQXResultArr;
			clsJY_DYJG[] p_objDYResultArr;

			long lngRes = m_objLabAnalysisOrderDomain.m_lngGetReportInfomation(txtBarCode.Text, out p_objPatient, out p_objResultArr, out p_objQXResultArr, out p_objDYResultArr);

//			lblMessage.Text = "";

			#region 显示结果
			if(lngRes <= 0 || p_objPatient == null)
			{
//				lblMessage.Text = "该检验单的检验结果尚未送回,请与检验科联系！";
//				lblMessage.ForeColor = Color.Red;
				return;
			}

			#region 病人资料
			m_txtBedNO.Text = p_objPatient.m_strPat_bed_no;
			m_txtPatientName.Text = p_objPatient.m_strPat_name;
		    txtInPatientID.Text = p_objPatient.m_strPat_in_no;
			lblSex.Text = p_objPatient.m_strPat_sex;
			lblAge.Text = p_objPatient.m_strPat_age;
			txtBarCode.Text = p_objPatient.m_strPat_id;
			m_lbldoct.Text = p_objPatient.m_strPat_doct;
			m_lblIname.Text = p_objPatient.m_strPat_I_name;
			m_lblchk.Text = p_objPatient.m_strPat_chk;
			m_lblsname.Text = p_objPatient.m_strPat_s_name;
			m_lblDiagnose.Text = p_objPatient.m_strPat_diag;
			m_lblRemark.Text = p_objPatient.m_strPat_rem;
			#endregion 病人资料

			#region 该病人所有检验项目
			clsJY_BRZL[] p_objPatientArr;
			
			lngRes = m_objLabAnalysisOrderDomain.m_lngGetCheckItem(txtInPatientID.Text, out p_objPatientArr);

			if(p_objPatientArr == null || p_objPatientArr.Length == 0)
				return;

			lsvCheckResult.Columns[0].Text = p_objPatientArr[0].m_strPat_c_name;

			for(int i = 0; i < p_objPatientArr.Length; i++)
			{
				if(p_objPatientArr[i] == null)
					continue;

				if(p_objPatientArr[i].m_strPat_c_name=="")
					p_objPatientArr[i].m_strPat_c_name = p_objPatientArr[i].m_strPat_CheckOrder;

				ListViewItem lviNewItem = new ListViewItem(new string[]{p_objPatientArr[i].m_strPat_c_name,p_objPatientArr[i].m_strPat_sid,p_objPatientArr[i].m_strPat_mid,p_objPatientArr[i].m_dtmPat_sdate.ToString("yyyy-MM-dd 00:00:00")});

				lviNewItem.Tag = p_objPatientArr[i];
			
				lsvCheckItem.Items.Add(lviNewItem);

				if(p_objPatientArr[i].m_strPat_id==txtBarCode.Text)
					lsvCheckItem.Items[i].Selected = true;
			}

			#endregion 该病人所有检验项目
	
//			if(p_objResultArr == null || p_objResultArr.Length == 0)
//				return;
//
//			string strCheckItem = "";
//			string strExp = "";
//			string strResult = "";
//			string strUnit = "";
//			string strRef = "";
//
//			for(int i = 0; i < p_objResultArr.Length; i++)
//			{
//				if(p_objResultArr[i] == null)
//					continue;
//
//				strCheckItem = p_objResultArr[i].m_strRes_name + "  (" + p_objResultArr[i].m_strRes_it_ecd + ")";
//				strExp = (p_objResultArr[i].m_strRes_exp == "") ? " " : p_objResultArr[i].m_strRes_exp;
//				strResult = p_objResultArr[i].m_strRes_chr + "  " + p_objResultArr[i].m_strRes_chr1;
//				strUnit = p_objResultArr[i].m_strRes_unit;
//				strRef = p_objResultArr[i].m_strRes_ref1 + " " + p_objResultArr[i].m_strRes_ref2 + " " + p_objResultArr[i].m_strRes_ref3 + " " + p_objResultArr[i].m_strRes_ref4;
//				ListViewItem lviResult = new ListViewItem(new string[]{strCheckItem,strExp + " " + strResult,strUnit,strRef});
//
//				lsvCheckResult.Items.Add(lviResult);
//			}
//			if(p_objResultArr.Length>0)
//			{
//				m_lblResultDate.Text = p_objResultArr[0].m_dtmRes_date.ToString("yyyy-MM-dd 00:00:00");
//			}
			#endregion
			
		}
		#endregion

		#region 打印
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;

		private clsLabAnalysisReportPrintTool m_objPrintTool;

		protected override long m_lngSubPrint()
		{
			m_mthPrintFromDataSource();
			return 0;
		}

		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_objPrintTool.m_mthBeginPrint(e);				
		}

		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
		{
			m_objPrintTool.m_mthEndPrint(e);
		}

		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			m_objPrintTool.m_mthPrintPage(e);
		}	

		private void m_mthPrintFromDataSource()
		{	
			m_objPrintTool = new clsLabAnalysisReportPrintTool();

			m_objPrintTool.m_mthInitPrintTool(null);

			m_objPrintTool.m_mthSetPrintInfo(txtBarCode.Text.Trim());				
									
			m_objPrintTool.m_mthInitPrintContent();	
	
			//保存到文件
			//			object objtemp=objPrintTool.m_objGetPrintInfo();
			//			IFormatter objForm = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
			//		
			//			Stream objStream = new System.IO.FileStream("d:\\code\\Tese.bin",FileMode.Create);
			//		
			//			objForm.Serialize(objStream,objtemp);
			//		
			//			objStream.Flush();
			//			objStream.Close();
				
			m_mthStartPrint();
		}
		private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
		private void m_mthStartPrint()
		{
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}
		#endregion

		#region Public Function
		public void Copy()
		{
		
		}

		public void Cut()
		{
		
		}

		public void Delete()
		{
		
		}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		public void Display()
		{
		
		}

		public void Display(string cardno, string sendcheckdate)
		{
		
		}

		public void Paste()
		{
		
		}

		public void Print()
		{
			this.m_lngPrint();
		}

		public void Redo()
		{
		
		}

		public void Save()
		{
		
		}

		public void Undo()
		{
		
		}
		#endregion

		private void cmdViewReport_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.m_lngPrint();
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message + "\r\n" + err.StackTrace);
			}
		}

		private void frmLabCheckReport_Load(object sender, System.EventArgs e)
		{
//			m_txtPatientName.Visible = false;
//			m_cboArea.Visible = false;
//			m_txtBedNO.Visible = false;
//			lblAreaTitle.Visible = false;
//			lblInHospitalNoTitle.Visible = false;
//			txtInPatientID.Visible = false;
			lsvCheckItem.Focus();
		}

		private void txtBarCode_Leave(object sender, System.EventArgs e)
		{
			if(!lsvBarCode.Focused)
				lsvBarCode.Visible = false;
		}

		private void lsvBarCode_Leave(object sender, System.EventArgs e)
		{
			lsvBarCode.Visible = false;
		}

		private void m_mthClearAll()
		{
			txtBarCode.Text = "";
			m_lbldoct.Text = "";
			m_lblIname.Text = "";
			m_lblchk.Text = "";
			m_lblsname.Text = "";
			m_lblDiagnose.Text = "";
			m_lblRemark.Text = "";
			m_lblCheckOrder.Text = "";
			m_lblbarname.Text = "";
			m_lblbcnt.Text = "";
		}

		private void lsvCheckItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
//			TimeSpan ts;
//            DateTime dtStart = DateTime.Now;
				
			lsvCheckResult.Items.Clear();			
			m_mthClearAll();

			//加上lsvCheckItem.SelectedItems.Count>0这个条件是因为：
			//从一行转到另一行，中间会经历一个从有到无，再从无到有的过程
			//也就是SelectedItems.Count会出现为0的情况
			if(lsvCheckItem.SelectedItems.Count>0  && lsvCheckItem.SelectedItems[0].Tag!=null)
			{				
				clsJY_BRZL objConent = (clsJY_BRZL)lsvCheckItem.SelectedItems[0].Tag;

				#region 病人资料
				txtBarCode.Text = objConent.m_strPat_id;
				m_lbldoct.Text = objConent.m_strPat_doct;
				m_lblIname.Text = objConent.m_strPat_I_name;
				m_lblchk.Text = objConent.m_strPat_chk;
				m_lblsname.Text = objConent.m_strPat_s_name;
				m_lblDiagnose.Text = objConent.m_strPat_diag;
				m_lblRemark.Text = objConent.m_strPat_rem;
				m_lblCheckOrder.Text = objConent.m_strPat_CheckOrder;
				#endregion 病人资料

//				ts = DateTime.Now - dtStart;
//				dtStart = DateTime.Now;
			
				switch(objConent.m_strPat_rep_form)
				{
					#region 检验结果
					case "1":
						if(this.WindowState == FormWindowState.Normal)
						{
							lsvCheckResult.Columns[0].Width = 280;
							lsvCheckResult.Columns[1].Width = 230;
							lsvCheckResult.Columns[2].Width = 0;
							lsvCheckResult.Columns[3].Width = 0;
						}
						else
						{
							lsvCheckResult.Columns[0].Width = 280;
							lsvCheckResult.Columns[1].Width = 230;
							lsvCheckResult.Columns[2].Width = 120;
							lsvCheckResult.Columns[3].Width = 350;
						}
						lsvCheckResult.Columns[0].Text =  objConent.m_strPat_c_name;
						lsvCheckResult.Columns[1].Text = "结果";
						lsvCheckResult.Columns[2].Text = "单位";
						lsvCheckResult.Columns[3].Text = "参考值";
						m_lblDesription.Visible = false;

//						ts = DateTime.Now - dtStart;
//						dtStart = DateTime.Now;

						clsJY_JG[] p_objResultArr = null;
						long lngRes = m_objLabAnalysisOrderDomain.m_lngGetCheckResult(txtBarCode.Text,out p_objResultArr);
						if(lngRes <= 0 || p_objResultArr == null)
						{
							return;
						}

//						ts = DateTime.Now - dtStart;
//						dtStart = DateTime.Now;

						string strCheckItem = "";
						string strExp = "";
						string strResult = "";
						string strUnit = "";
						string strRef = "";

						ArrayList arlTemp = new ArrayList();

						for(int i = 0; i < p_objResultArr.Length; i++)
						{
							if(p_objResultArr[i] == null)
								continue;

							strCheckItem = p_objResultArr[i].m_strRes_name + "(" + p_objResultArr[i].m_strRes_it_ecd + ")";
							strExp = (p_objResultArr[i].m_strRes_exp == "") ? "" : p_objResultArr[i].m_strRes_exp + " ";
							strResult = p_objResultArr[i].m_strRes_chr + "  " + p_objResultArr[i].m_strRes_chr1;
							strUnit = p_objResultArr[i].m_strRes_unit;
							strRef = p_objResultArr[i].m_strRes_ref1 + "   " + p_objResultArr[i].m_strRes_ref2 + "   " + p_objResultArr[i].m_strRes_ref3 + "   " + p_objResultArr[i].m_strRes_ref4;
							ListViewItem lviResult = new ListViewItem(new string[]{strCheckItem,strExp+strResult,strUnit,strRef});

//							lsvCheckResult.Items.Add(lviResult);
							arlTemp.Add(lviResult);
						}

						ListViewItem[] lviArr = (ListViewItem[])arlTemp.ToArray(typeof(ListViewItem));
						lsvCheckResult.Items.AddRange(lviArr);

//						ts = DateTime.Now - dtStart;
//						dtStart = DateTime.Now;

						if(p_objResultArr.Length>0)
						{
							m_lblResultDate.Text = p_objResultArr[0].m_dtmRes_date.ToString("yyyy-MM-dd 00:00:00");
						}
						break;
					#endregion 检验结果
					#region 描述结果
					case "4":
						lsvCheckResult.Columns[0].Width = lsvCheckResult.Width;
						lsvCheckResult.Columns[1].Width = 0;
						lsvCheckResult.Columns[2].Width = 0;
						lsvCheckResult.Columns[3].Width = 0;
						lsvCheckResult.Columns[0].Text = "描述结果";
						m_lblDesription.Visible = false;

						clsJY_MSJG[] p_objMSJGArr;
						lngRes = m_objLabAnalysisOrderDomain.m_lngGetJY_MSJG(txtBarCode.Text,out p_objMSJGArr);
						if(lngRes <= 0 || p_objMSJGArr == null)
						{
							return;
						}

						for(int i = 0; i < p_objMSJGArr.Length; i++)
						{
							if(p_objMSJGArr[i] == null)
								continue;
							
							ListViewItem lviResult = new ListViewItem(new string[]{p_objMSJGArr[i].m_strRes_cname});

							lsvCheckResult.Items.Add(lviResult);
						}
						if(p_objMSJGArr.Length>0)
						{
							m_lblResultDate.Text = p_objMSJGArr[0].m_dtmRes_date.ToString("yyyy-MM-dd 00:00:00");
						}
						break;
					#endregion 描述结果

					#region 药敏结果
					case "5":	
						if(this.WindowState == FormWindowState.Normal)
						{
							lsvCheckResult.Columns[0].Width = 150;
							lsvCheckResult.Columns[1].Width = 150;
							lsvCheckResult.Columns[2].Width = 150;
							lsvCheckResult.Columns[3].Width = 60;
						}
						else
						{
							lsvCheckResult.Columns[0].Width = 300;
							lsvCheckResult.Columns[1].Width = 300;
							lsvCheckResult.Columns[2].Width = 190;
							lsvCheckResult.Columns[3].Width = 190;
							m_lblDesription.Visible = true;
						}
						lsvCheckResult.Columns[0].Text = "Antimicrobic";
						lsvCheckResult.Columns[1].Text = "抗  生  素";
						lsvCheckResult.Columns[2].Text = "药敏";
						lsvCheckResult.Columns[3].Text = "Disk";						

						clsJY_YMJG[] p_objYMJGArr;
						lngRes = m_objLabAnalysisOrderDomain.m_lngGetJY_YMJG(txtBarCode.Text,out p_objYMJGArr);
						if(lngRes <= 0 || p_objYMJGArr == null)
						{
							return;
						}

						for(int i = 0; i < p_objYMJGArr.Length; i++)
						{
							if(p_objYMJGArr[i] == null)
								continue;
							
							ListViewItem lviResult = new ListViewItem(new string[]{p_objYMJGArr[i].m_strRes_antiname,p_objYMJGArr[i].m_strRes_anticname,p_objYMJGArr[i].m_strRes_smic,p_objYMJGArr[i].m_strRes_mic});

							lsvCheckResult.Items.Add(lviResult);
						}
						if(p_objYMJGArr.Length>0)
						{
							m_lblbarname.Text = p_objYMJGArr[0].m_strRec_barcname+"("+p_objYMJGArr[0].m_strRes_barname+")";
							m_lblbcnt.Text = p_objYMJGArr[0].m_strRes_bcnt;
							m_lblResultDate.Text = p_objYMJGArr[0].m_dtmRes_date.ToString("yyyy-MM-dd 00:00:00");
						}
						break;
					#endregion 药敏结果
				}
			}
		}

		/// <summary>
		/// 传入的控件
		/// </summary>
		private Control m_objSelectedControl;

		public void m_mthInitLabCheckResult(Control p_objSelectedControl)
		{
			this.StartPosition = FormStartPosition.CenterParent;

			m_objSelectedControl = p_objSelectedControl;

			foreach(Control subControl in this.Controls)
			{
				subControl.Top -=120;

				if(subControl.GetType().Name!="ListView")
				{
					subControl.Visible = false;
				}
			}
			m_txtLabCheckResult.Visible = true;
			cmdConfirm.Visible = true;
			cmdCancel.Visible = true;
			lblCheckResult.Visible = true;

			lsvCheckResult.ContextMenu = ctmPickUp;
			lsvCheckResult.Width = lsvCheckItem.Width;

			this.Width -= 370;
			this.Height -= 100;
			this.WindowState = FormWindowState.Normal;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;

            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_txtLabCheckResult});			
		}

		/// <summary>
		/// 提取检验结果
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniPickUp_Click(object sender, System.EventArgs e)
		{
			if(lsvCheckResult.SelectedItems.Count>0)
			{
				switch(lsvCheckResult.Columns[0].Text)
				{
					case "Antimicrobic" :
						if(m_txtLabCheckResult.Text=="")
							m_txtLabCheckResult.Text = lsvCheckResult.SelectedItems[0].SubItems[0].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[1].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[2].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[3].Text.Trim();				
						else
							m_txtLabCheckResult.Text += "," + lsvCheckResult.SelectedItems[0].SubItems[0].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[1].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[2].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[3].Text.Trim();
						break;
					case "描述结果" :
						if(m_txtLabCheckResult.Text=="")
							m_txtLabCheckResult.Text = lsvCheckResult.SelectedItems[0].SubItems[0].Text.Trim();				
						else
							m_txtLabCheckResult.Text += "," + lsvCheckResult.SelectedItems[0].SubItems[0].Text.Trim();
						break;
					default :
						if(m_txtLabCheckResult.Text=="")
							m_txtLabCheckResult.Text = lsvCheckResult.SelectedItems[0].SubItems[0].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[1].Text.Trim();				
						else
							m_txtLabCheckResult.Text += "," + lsvCheckResult.SelectedItems[0].SubItems[0].Text.Trim() + lsvCheckResult.SelectedItems[0].SubItems[1].Text.Trim();
						break;
				}
				
			}
		}

		private void mniPickUpAll_Click(object sender, System.EventArgs e)
		{
			if(lsvCheckResult.Items.Count>0)
			{
				for(int i=0;i<lsvCheckResult.Items.Count;i++)
				{
					switch(lsvCheckResult.Columns[0].Text)
					{
						case "Antimicrobic" :
							if(m_txtLabCheckResult.Text=="")
								m_txtLabCheckResult.Text = lsvCheckResult.Items[i].SubItems[0].Text.Trim() + lsvCheckResult.Items[i].SubItems[1].Text.Trim() + lsvCheckResult.Items[i].SubItems[2].Text.Trim() + lsvCheckResult.Items[i].SubItems[3].Text.Trim();				
							else
								m_txtLabCheckResult.Text += "," + lsvCheckResult.Items[i].SubItems[0].Text.Trim() + lsvCheckResult.Items[i].SubItems[1].Text.Trim() + lsvCheckResult.Items[i].SubItems[2].Text.Trim() + lsvCheckResult.Items[i].SubItems[3].Text.Trim();				
							break;
						case "描述结果" :
							if(m_txtLabCheckResult.Text=="")
								m_txtLabCheckResult.Text = lsvCheckResult.Items[i].SubItems[0].Text.Trim();
							else
								m_txtLabCheckResult.Text += "," + lsvCheckResult.Items[i].SubItems[0].Text.Trim();
							break;
						default :
							if(m_txtLabCheckResult.Text=="")
								m_txtLabCheckResult.Text = lsvCheckResult.Items[i].SubItems[0].Text.Trim() + lsvCheckResult.Items[i].SubItems[1].Text.Trim();				
							else
								m_txtLabCheckResult.Text += "," + lsvCheckResult.Items[i].SubItems[0].Text.Trim() + lsvCheckResult.Items[i].SubItems[1].Text.Trim();
							break;
					}					
				}
			}
		}

		private void cmdConfirm_Click(object sender, System.EventArgs e)
		{
			//frmGeneralDisease窗体只是一个类
			//必须先创建这个窗体的实例，才能访问它。相当于创建一个指针指向该窗体。
//			frmGeneralDisease frmgeneraldisease = new frmGeneralDisease();
//			frmgeneraldisease.m_txtRecordContent.Text += m_txtLabCheckResult.Text;		
//			frmgeneraldisease.m_StrRecordContent = m_txtLabCheckResult.Text;

//			m_objSelectedControl.Text += m_txtLabCheckResult.Text;
			TextBoxBase txtTarget = (TextBoxBase)m_objSelectedControl;
			txtTarget.Text = txtTarget.Text.Insert(txtTarget.SelectionStart,m_txtLabCheckResult.Text);
			this.Close();
		}

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}

		private void lsvCheckResult_DoubleClick(object sender, System.EventArgs e)
		{
			mniPickUp_Click(null,EventArgs.Empty);
		}

		private void m_cmdClear_Click(object sender, System.EventArgs e)
		{
			m_txtLabCheckResult.Text = "";
		}

		/// <summary>
		/// 不需要归档提示
		/// </summary>
		/// <param name="p_blnIfReadOnly"></param>
		/// <param name="p_strTimeRemaing"></param>
		protected override void m_mthPromtForArchiving(bool p_blnIfReadOnly,string p_strTimeRemaing)
		{
		}
		/// <summary>
		/// 提供子窗体的手动资源释放
		/// </summary>
//		protected override void m_mthReleaseSub()
//		{
//			if(m_objBorderTool != null)
//				m_objBorderTool.m_mthClear();
//			base.m_mthReleaseSub();
//		}
	}
}

