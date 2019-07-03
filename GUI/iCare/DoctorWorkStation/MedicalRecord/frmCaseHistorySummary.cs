using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Drawing.Printing;
using iCareData;
using com.digitalwave.Utility.Controls;
using System.Data;
using HRP;
//using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility.SQLConvert;
using com.digitalwave.InHospitalMainRecord;

namespace iCare
{
	/// <summary>
	/// 病历摘要
	/// </summary>
	public class frmCaseHistorySummary : iCare.frmInpatMedRecBase
	{
        //private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private com.digitalwave.controls.ctlRichTextBox m_txtCaseHistorySummary;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        public clsCaseHistorySummary objRecordContent = null;
        public clsPatient objPatient = null;
		public frmCaseHistorySummary()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			m_mthSetRichTextBoxAttribInControl(this);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaseHistorySummary));
            this.m_txtCaseHistorySummary = new com.digitalwave.controls.ctlRichTextBox();
            this.m_pnlContent.SuspendLayout();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmdCreateID
            // 
            this.m_cmdCreateID.Location = new System.Drawing.Point(310, 145);
            this.m_cmdCreateID.Size = new System.Drawing.Size(10, 28);
            this.m_cmdCreateID.Visible = false;
            // 
            // m_pnlContent
            // 
            this.m_pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_pnlContent.Controls.Add(this.m_txtCaseHistorySummary);
            this.m_pnlContent.Location = new System.Drawing.Point(1, 69);
            this.m_pnlContent.Size = new System.Drawing.Size(836, 389);
            // 
            // trvTime
            // 
            this.trvTime.LineColor = System.Drawing.Color.Black;
            this.trvTime.Location = new System.Drawing.Point(202, 123);
            this.trvTime.Size = new System.Drawing.Size(10, 10);
            this.trvTime.Visible = false;
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(246, 121);
            this.m_dtpCreateDate.Size = new System.Drawing.Size(10, 22);
            this.m_dtpCreateDate.Visible = false;
            // 
            // lblCreateDate
            // 
            this.lblCreateDate.Location = new System.Drawing.Point(199, 140);
            this.lblCreateDate.Visible = false;
            // 
            // lblNativePlace
            // 
            this.lblNativePlace.Location = new System.Drawing.Point(-122, 172);
            this.lblNativePlace.Visible = false;
            // 
            // m_lblNativePlace
            // 
            this.m_lblNativePlace.Location = new System.Drawing.Point(258, 165);
            this.m_lblNativePlace.Size = new System.Drawing.Size(10, 24);
            this.m_lblNativePlace.Visible = false;
            // 
            // lblOccupation
            // 
            this.lblOccupation.Location = new System.Drawing.Point(214, 140);
            this.lblOccupation.Visible = false;
            // 
            // m_lblOccupation
            // 
            this.m_lblOccupation.Location = new System.Drawing.Point(254, 180);
            this.m_lblOccupation.Size = new System.Drawing.Size(97, 24);
            this.m_lblOccupation.Visible = false;
            // 
            // m_lblMarriaged
            // 
            this.m_lblMarriaged.Location = new System.Drawing.Point(246, 145);
            this.m_lblMarriaged.Visible = false;
            // 
            // lblMarriaged
            // 
            this.lblMarriaged.Location = new System.Drawing.Point(-90, 140);
            this.lblMarriaged.Visible = false;
            // 
            // m_lblLinkMan
            // 
            this.m_lblLinkMan.Location = new System.Drawing.Point(280, 174);
            this.m_lblLinkMan.Size = new System.Drawing.Size(56, 10);
            this.m_lblLinkMan.Visible = false;
            // 
            // lblLinkMan
            // 
            this.lblLinkMan.Location = new System.Drawing.Point(228, 129);
            this.lblLinkMan.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(214, 172);
            this.lblAddress.Visible = false;
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Location = new System.Drawing.Point(262, 202);
            this.m_lblAddress.Size = new System.Drawing.Size(51, 24);
            this.m_lblAddress.Visible = false;
            // 
            // lblRepresentor
            // 
            this.lblRepresentor.Location = new System.Drawing.Point(304, 136);
            this.lblRepresentor.Visible = false;
            // 
            // lblCredibility
            // 
            this.lblCredibility.Location = new System.Drawing.Point(302, 116);
            this.lblCredibility.Visible = false;
            // 
            // m_cboRepresentor
            // 
            this.m_cboRepresentor.Location = new System.Drawing.Point(296, 121);
            this.m_cboRepresentor.Size = new System.Drawing.Size(10, 23);
            this.m_cboRepresentor.Visible = false;
            // 
            // m_cboCredibility
            // 
            this.m_cboCredibility.Location = new System.Drawing.Point(300, 131);
            this.m_cboCredibility.Size = new System.Drawing.Size(10, 23);
            this.m_cboCredibility.Visible = false;
            // 
            // m_lsvEmployee
            // 
            this.m_lsvEmployee.Location = new System.Drawing.Point(194, 136);
            // 
            // lsvSign
            // 
            this.lsvSign.Visible = false;
            // 
            // m_txtSign
            // 
            this.m_txtSign.Location = new System.Drawing.Point(324, 94);
            this.m_txtSign.Size = new System.Drawing.Size(10, 23);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(225, 158);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(201, 164);
            this.lblAge.Size = new System.Drawing.Size(120, 24);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(268, 202);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(327, 149);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(254, 104);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(205, 144);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(271, 172);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(221, 158);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(258, 164);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(10, 24);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(227, 135);
            this.txtInPatientID.Size = new System.Drawing.Size(10, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(311, 121);
            this.m_txtPatientName.Size = new System.Drawing.Size(10, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(289, 165);
            this.m_txtBedNO.Size = new System.Drawing.Size(10, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(253, 172);
            this.m_cboArea.Size = new System.Drawing.Size(10, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(210, 158);
            this.m_lsvPatientName.Size = new System.Drawing.Size(10, 10);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(258, 139);
            this.m_lsvBedNO.Size = new System.Drawing.Size(10, 10);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(253, 127);
            this.m_cboDept.Size = new System.Drawing.Size(10, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(214, 140);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(246, 162);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(10, 10);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(324, 176);
            this.m_cmdNext.Size = new System.Drawing.Size(10, 24);
            this.m_cmdNext.Visible = false;
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(253, 124);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(227, 123);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(193, 124);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(762, 35);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(65, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(1, 4);
            this.m_pnlNewBase.Size = new System.Drawing.Size(793, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowHomePlace = true;
            this.m_ctlPatientInfo.m_BlnIsShowMarriage = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowRace = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(791, 29);
            // 
            // m_txtCaseHistorySummary
            // 
            this.m_txtCaseHistorySummary.AccessibleDescription = "病理摘要";
            this.m_txtCaseHistorySummary.BackColor = System.Drawing.Color.White;
            this.m_txtCaseHistorySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCaseHistorySummary.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCaseHistorySummary.ForeColor = System.Drawing.Color.Black;
            this.m_txtCaseHistorySummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtCaseHistorySummary.Location = new System.Drawing.Point(0, 0);
            this.m_txtCaseHistorySummary.m_BlnIgnoreUserInfo = false;
            this.m_txtCaseHistorySummary.m_BlnPartControl = false;
            this.m_txtCaseHistorySummary.m_BlnReadOnly = false;
            this.m_txtCaseHistorySummary.m_BlnUnderLineDST = false;
            this.m_txtCaseHistorySummary.m_ClrDST = System.Drawing.Color.Black;
            this.m_txtCaseHistorySummary.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtCaseHistorySummary.m_IntCanModifyTime = 2400;
            this.m_txtCaseHistorySummary.m_IntPartControlLength = 0;
            this.m_txtCaseHistorySummary.m_IntPartControlStartIndex = 0;
            this.m_txtCaseHistorySummary.m_StrUserID = "";
            this.m_txtCaseHistorySummary.m_StrUserName = "";
            this.m_txtCaseHistorySummary.MaxLength = 600;
            this.m_txtCaseHistorySummary.Name = "m_txtCaseHistorySummary";
            this.m_txtCaseHistorySummary.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtCaseHistorySummary.Size = new System.Drawing.Size(836, 389);
            this.m_txtCaseHistorySummary.TabIndex = 1401;
            this.m_txtCaseHistorySummary.Text = "";
            // 
            // frmCaseHistorySummary
            // 
            this.AccessibleDescription = "病历摘要";
            this.ClientSize = new System.Drawing.Size(793, 537);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "frmCaseHistorySummary";
            this.Text = "病历摘要";
            this.m_pnlContent.ResumeLayout(false);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		protected override long m_lngSubPrint()
		{
			m_mthStartPrint();
			return 1;
		}

		public override int m_IntFormID
		{
			get
			{
				return 53;
			}
		}

		private bool blnIsSave = true;
        public bool blnIsOutPrint = false;
		protected override DialogResult m_dlgHandleSaveBeforePrint()
		{
			DialogResult dlgResult = DialogResult.None;
			if(!MDIParent.s_ObjSaveCue.m_blnCheckStatusSame(this))
			{
				dlgResult = clsPublicFunction.ShowQuestionMessageBox("[" + this.Text+ "]做了改动，是否保存？",MessageBoxButtons.YesNoCancel);

				if(dlgResult==DialogResult.Yes)
				{
					blnIsSave = true;
					m_lngSave();
				}
				else
					blnIsSave = false;
			}
			return dlgResult;
		}

		protected void m_mthSetDeletedGUIFromContent(clsInpatMedRecContent p_objContent)
		{
			if(p_objContent ==null)
				return;
			this.m_txtCaseHistorySummary.Text = p_objContent.m_objItemContents[0].m_strItemContent;
		}

		#region 打印的定义
		StringFormat m_sfmPrint = new StringFormat(StringFormatFlags.FitBlackBox);
		/// <summary>
		/// 医院标题
		/// </summary>
		private Font m_fotHosTilFont = new Font("SimSun",14);


		/// <summary>
		/// 标题的字体(20 bold)
		/// </summary>
		private Font m_fotTitleFont = new Font("SimSun", 16,FontStyle.Bold);
		/// <summary>
		/// 表内容的字体(11)
		/// </summary>
		private Font m_fotSmallFont = new Font("SimSun",12);
		/// <summary>
		/// 刷子
		/// </summary>
		private SolidBrush m_slbBrush = new SolidBrush(Color.Black);

		private Pen m_penDash = new Pen(Color.Black);

		protected RectangleF m_rtfHosTitle = new RectangleF(clsPrintPosition.c_intLeftX,clsPrintPosition.c_intHospitalTitleY,clsPrintPosition.c_intRightLineX-clsPrintPosition.c_intLeftX,40);
		protected RectangleF m_rtfFormTitle = new RectangleF(clsPrintPosition.c_intLeftX,clsPrintPosition.c_intFormTitleY,clsPrintPosition.c_intRightLineX-clsPrintPosition.c_intLeftX,60);
		
		private int m_intYPos = 0;

		#endregion

		#region 打印
        protected override void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            return;
        }

        protected override void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            return;
        }

        protected override void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_mthSubPrintTitle(e);

			if(blnIsSave == true)
				m_mthSubPrintDB(objRecordContent,e);
			else
				m_mthSubPrintForm(e);
			
			m_intYPos = 180;
		}
		private void m_mthSubPrintDB(clsCaseHistorySummary p_CurrentRecord,System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_sfmPrint.Alignment = StringAlignment.Near;
			int intPosX = clsPrintPosition.c_intLeftX;
			int intPosY = clsPrintPosition.c_intTopLineY - 10;

			int intHeight = 30;
			int intWidth = 40;
			intPosY += 40;
			e.Graphics.DrawString(p_CurrentRecord.m_strCaseHistorySummary,new Font("SimSun",11),Brushes.Black,new RectangleF(intPosX+6,intPosY+4,clsPrintPosition.c_intRightX-intPosX-4,793),m_sfmPrint);
			e.Graphics.DrawLine(m_penDash,intPosX,intPosY-5,clsPrintPosition.c_intRightX,intPosY-5);
			e.Graphics.DrawLine(m_penDash,intPosX,intPosY-5,intPosX,intPosY+800);
			e.Graphics.DrawLine(m_penDash,clsPrintPosition.c_intRightX,intPosY-5,clsPrintPosition.c_intRightX,intPosY+800);
			e.Graphics.DrawLine(m_penDash,intPosX,intPosY+800,clsPrintPosition.c_intRightX,intPosY+800);
		}

		private void m_mthSubPrintForm(System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_sfmPrint.Alignment = StringAlignment.Near;
			int intPosX = clsPrintPosition.c_intLeftX;
			int intPosY = clsPrintPosition.c_intTopLineY - 10;

			int intHeight = 30;
			int intWidth = 40;
			intPosY += 40;
			e.Graphics.DrawLine(m_penDash,intPosX,intPosY-5,clsPrintPosition.c_intRightX,intPosY-5);
			e.Graphics.DrawString(m_txtCaseHistorySummary.Text,m_fotSmallFont,Brushes.Black,new RectangleF(intPosX,intPosY+2,clsPrintPosition.c_intRightX-intPosX,795),m_sfmPrint);
			e.Graphics.DrawLine(m_penDash,intPosX,intPosY-5,intPosX,intPosY+800);
			e.Graphics.DrawLine(m_penDash,clsPrintPosition.c_intRightX,intPosY-5,clsPrintPosition.c_intRightX,intPosY+800);
			e.Graphics.DrawLine(m_penDash,intPosX,intPosY+800,clsPrintPosition.c_intRightX,intPosY+800);
		}

		private void m_mthSubPrintTitle(System.Drawing.Printing.PrintPageEventArgs e)
		{
			m_sfmPrint.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle, m_fotHosTilFont, m_slbBrush, m_rtfHosTitle, m_sfmPrint);
			e.Graphics.DrawString("病  历  摘  要" ,m_fotTitleFont,m_slbBrush,m_rtfFormTitle,m_sfmPrint);

			m_sfmPrint.Alignment = StringAlignment.Near;
			int intPosX = clsPrintPosition.c_intLeftX;
			int intPosY = clsPrintPosition.c_intTopLineY - 5;
			int intHeight = 30;
			int intWidth = 45;
            if (!blnIsOutPrint)
            {
                e.Graphics.DrawString("姓名：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(m_objCurrentPatient == null ? "" : m_objCurrentPatient.m_StrName, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 100;
                e.Graphics.DrawString("性别：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(m_objCurrentPatient == null ? "" : m_objCurrentPatient.m_StrSex, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 40;
                e.Graphics.DrawString("年龄：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(m_objCurrentPatient == null ? "" : m_objCurrentPatient.m_ObjPeopleInfo.m_StrAge, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 80;
                e.Graphics.DrawString("病区：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(m_objCurrentPatient == null ? "" : m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByInDate(m_objCurrentPatient.m_DtmSelectedInDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 120;
                e.Graphics.DrawString("床号：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(m_objCurrentPatient == null ? "" : m_objCurrentPatient.m_strBedCode, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 40;
                e.Graphics.DrawString("住院号：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                e.Graphics.DrawString(m_objCurrentPatient == null ? "" : m_objCurrentPatient.m_StrEMRInPatientID, m_fotSmallFont, Brushes.Black, intPosX + 60, intPosY + 2);
            }
            else
            {
                e.Graphics.DrawString("姓名：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(objPatient == null ? "" : objPatient.m_StrName, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 100;
                e.Graphics.DrawString("性别：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(objPatient == null ? "" : objPatient.m_StrSex, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 40;
                e.Graphics.DrawString("年龄：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(objPatient == null ? "" : objPatient.m_ObjPeopleInfo.m_StrAge, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 80;
                e.Graphics.DrawString("病区：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(objPatient == null ? "" : objPatient.m_ObjInBedInfo.m_objGetSessionByInDate(objPatient.m_DtmSelectedInDate).m_ObjLastDept.m_ObjLastArea.m_ObjArea.m_StrAreaName, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 120;
                e.Graphics.DrawString("床号：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                intPosX += intWidth;
                e.Graphics.DrawString(objPatient == null ? "" : objPatient.m_strBedCode, m_fotSmallFont, Brushes.Black, intPosX + 5, intPosY + 2);
                intPosX += 40;
                e.Graphics.DrawString("住院号：", m_fotSmallFont, Brushes.Black, intPosX, intPosY + 2);
                e.Graphics.DrawString(objPatient == null ? "" : objPatient.m_StrEMRInPatientID, m_fotSmallFont, Brushes.Black, intPosX + 60, intPosY + 2);
            }
		}


		private void m_mthStartPrint()
        {
            long lngRef = -1;

            if (m_objCurrentPatient != null)
            {
                DateTime dtmInPatientDate = m_ctlAreaPatientSelection.CurrentSessionInfo.m_dtmEMRInpatientDate;

                clsInHospitalMainRecordServ objServ =
                    (clsInHospitalMainRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ));

                lngRef = objServ.m_lngGetAllergicValue("frmCaseHistorySummary", m_objCurrentPatient.m_StrInPatientID, dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"),false, out objRecordContent);
                //m_objServ.Dispose();
            }
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
				ppdPrintPreview.Document = m_pdcPrintDocument;
//				ppdPrintPreview.TopLevel = true;
				ppdPrintPreview.ShowDialog();
			}
		}

        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
        }
        private void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {
            try
            {
                p_objPrintPageArg.HasMorePages = false;
                m_mthSubPrintTitle(p_objPrintPageArg);
                if(blnIsSave == true)
                    m_mthSubPrintDB(objRecordContent, p_objPrintPageArg);
			    else
                    m_mthSubPrintForm(p_objPrintPageArg);
			
			    m_intYPos = 180;
            }
            catch (Exception err)
            {
                clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

            }
        }


		#endregion


		/// <summary>
		/// 屏蔽RichTextBox的用户修改信息
		/// </summary>
        public override bool m_blnGetCanModifyLast(string p_strModifyUserID, int p_intMarkStatus)
		{
			return true;
		}

        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, com.digitalwave.emr.AssistModuleVO.clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            long lngRef = -1;

            if (m_objCurrentPatient != null && p_objSelectedValue != null)
            {
                clsInHospitalMainRecordServ objServ =
                    (clsInHospitalMainRecordServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ));
                clsCaseHistorySummary objTempContent = objRecordContent;
                lngRef = objServ.m_lngGetAllergicValue(this.Name, p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), true, out objRecordContent);
                //m_objServ.Dispose();
                blnIsOutPrint = false;
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.m_mthCoverPrinter();
                ppdPrintPreview.ShowDialog(p_infOwner);
                objRecordContent = objTempContent;
                objTempContent = null;
            }
        }
	}	
}
