using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using iCareData;
using com.digitalwave.Utility.Controls;
using com.digitalwave.emr.BEDExplorer;
using com.digitalwave.Emr.Signature_gui;
using StaticObject = com.digitalwave.Emr.StaticObject;
using com.digitalwave.Emr.Initializer;
using com.digitalwave.Emr.StaticObject;

namespace iCare
{
	/// <summary>
	/// Summary description for frmConsultationSearch.
	/// </summary>
    public class frmConsultationSearch : iCare.iCareBaseForm.frmBaseForm, PublicFunction
	{
        /// <summary>
        /// 可以查看会诊病人病历时限
        /// </summary>
        private int m_intCanQreryTime = 0;

		private class clsColumnSort : IComparer
		{
			private int m_intColumn = 0;

			public int m_IntColumn
			{
				get
				{
					return m_intColumn;
				}
				set
				{
					m_intColumn = value;
				}

			}

			public int Compare(object x, object y)
			{
				ListViewItem lviX = (ListViewItem)x;
				ListViewItem lviY = (ListViewItem)y;

				if(m_intColumn==2)
				{
					return lviY.SubItems[m_intColumn].Text.CompareTo(lviX.SubItems[m_intColumn].Text);
				}
				return lviX.SubItems[m_intColumn].Text.CompareTo(lviY.SubItems[m_intColumn].Text);

			}
		}
		private System.Windows.Forms.ColumnHeader clmDept;
		private System.Windows.Forms.ColumnHeader clmTime;
		private System.Windows.Forms.ColumnHeader clmConsultationTime;
        private System.Windows.Forms.Label m_lblEmployeeInfo;
        private IContainer components;
		private System.Windows.Forms.ListView lsvConsultation;
		private com.digitalwave.controls.ctlRichTextBox m_txtDetail;

		/// <summary>
		/// 会诊记录的Domain层
		/// </summary>
		private clsConsultationSearchDomain m_objConsultationDomain = new clsConsultationSearchDomain();
		private PinkieControls.ButtonXP cmdRefresh;
		private PinkieControls.ButtonXP cmdCancel;
		private com.digitalwave.controls.ctlRichTextBox m_txtConsultationIdea;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private PinkieControls.ButtonXP m_cmdPrint;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpConsultationDate;
        private PinkieControls.ButtonXP m_cmdDoctorSign;
		protected System.Windows.Forms.ListView lsvSign;
		private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;

		//在这里声明其它方法里面都可以用
        //private clsBorderTool m_objBorderTool;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
        private PinkieControls.ButtonXP m_cmdApply;
        private clsEmrSignToolCollection m_objSign;
        private ContextMenu m_ctmExplorer;
        private MenuItem menuItem5;
        private MenuItem m_mnuInPatient;
        private MenuItem menuItem4;
        private MenuItem menuItem9;
        private MenuItem menuItem12;
        private MenuItem menuItem13;
        private MenuItem menuItem51;
        private MenuItem menuItem54;
        private MenuItem menuItem56;
        private MenuItem menuItem55;
        private MenuItem menuItem57;
        private MenuItem menuItem16;
        private MenuItem menuItem52;
        private MenuItem menuItem53;
        private MenuItem m_mtmInpatMedRec;
        private MenuItem menuItem1;
        private MenuItem menuItem38;
        private MenuItem menuItem39;
        private MenuItem menuItem40;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem6;
        private MenuItem menuItem8;
        private MenuItem menuItem10;
        private MenuItem menuItem11;
        private MenuItem menuItem14;
        private MenuItem menuItem15;
        private MenuItem menuItem17;
        private MenuItem menuItem18;
        private MenuItem menuItem19;
        private MenuItem menuItem22;
        private MenuItem menuItem23;
        private MenuItem menuItem24;
        private MenuItem menuItem20;
        private MenuItem menuItem21;
        private MenuItem menuItem25;
        private MenuItem menuItem26;
        private MenuItem mniEKGOrder;
        private MenuItem mniNuclearOrder;
        private MenuItem mniPSGOrder;
        private MenuItem mniLabAnalysisOrder;
        private MenuItem mniLabCheckReport;
        private MenuItem mniImageReport;
        private MenuItem mniImageBookingSearch;
        private MenuItem menuItem27;
        private MenuItem menuItem28;
        private MenuItem menuItem29;
        private MenuItem menuItem30;
        private MenuItem menuItem31;
        private MenuItem menuItem32;
        private MenuItem menuItem33;
        private MenuItem menuItem34;
        private MenuItem menuItem35;
        private MenuItem mniDirectionAnalisys;
        private MenuItem menuItem36;
        private MenuItem menuItem37;
        private MenuItem mniPatientInfoManage;
        private MenuItem menuItem41;
        private MenuItem menuItem7;
        private MenuItem menuItem42;
        private MenuItem menuItem43;
        private MenuItem mniICUTendRecord;
        private MenuItem menuItem44;
        private MenuItem menuItem45;
        private MenuItem menuItem46;
        private MenuItem menuItem47;
        private MenuItem menuItem48;
        private MenuItem menuItem49;
        private MenuItem menuItem50;
        private MenuItem m_mniDoctorOrder;
        private ColumnHeader clmRequestDoc;
        /// <summary>
        /// 登录员工所属的所有科室ID
        /// </summary>
        private string[] m_strDeptIDArr = null;
        private ToolTip m_ttpTextInfo;
        private ContextMenuStrip m_cmsEMRMenu;
        protected clsTemplatesetInvoke m_objTempTool;

		public frmConsultationSearch()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            new clsSortTool().m_mthSetListViewSortable(lsvConsultation);

            m_mthGetCanQreryTime();
            //m_mthInitMenu();
            m_mthInitEMRMenu();

            if (StaticObject::clsEMR_StaticObject.s_ObjEmpDeptAndAreaArr != null
                && StaticObject::clsEMR_StaticObject.s_ObjEmpDeptAndAreaArr.Length > 0)
            {
                int intDeptLength = StaticObject::clsEMR_StaticObject.s_ObjEmpDeptAndAreaArr.Length;
                m_strDeptIDArr = new string[intDeptLength];
                for (int i = 0; i < intDeptLength; i++)
                {
                    m_strDeptIDArr[i] = StaticObject::clsEMR_StaticObject.s_ObjEmpDeptAndAreaArr[i].m_strDEPTID_CHR;
                }
            }
            m_mthSetConsultationContent();

            //lsvConsultation.ListViewItemSorter = m_objColumnSort;

			new ctlHighLightFocus(clsHRPColor.s_ClrHightLight).m_mthAddControlInContainer(this);

			#region 签名控制
			//签名常用值

            m_objSign = new clsEmrSignToolCollection();
            //m_mthBindEmployeeSign(按钮,签名框,医生1or护士2,身份验证trueorfalse);
            if (m_strDeptIDArr != null && m_strDeptIDArr.Length > 0)
            {
                m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, lsvSign, 1, m_strDeptIDArr[0], true);
            }
            else
            {
                m_objSign.m_mthBindEmployeeSign(m_cmdDoctorSign, lsvSign, 1, true);
            }

			#endregion
            m_objTempTool = new clsTemplatesetInvoke();
            m_mthAddRichTemplateInContainer(this);
            m_mthSetRichTextBoxAttribInControl(m_txtConsultationIdea);
		}

        //private clsColumnSort m_objColumnSort = new clsColumnSort();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultationSearch));
            this.lsvConsultation = new System.Windows.Forms.ListView();
            this.clmConsultationTime = new System.Windows.Forms.ColumnHeader();
            this.clmDept = new System.Windows.Forms.ColumnHeader();
            this.clmRequestDoc = new System.Windows.Forms.ColumnHeader();
            this.clmTime = new System.Windows.Forms.ColumnHeader();
            this.m_txtDetail = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmsEMRMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_ctmExplorer = new System.Windows.Forms.ContextMenu();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.m_mnuInPatient = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem51 = new System.Windows.Forms.MenuItem();
            this.menuItem54 = new System.Windows.Forms.MenuItem();
            this.menuItem56 = new System.Windows.Forms.MenuItem();
            this.menuItem55 = new System.Windows.Forms.MenuItem();
            this.menuItem57 = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.menuItem52 = new System.Windows.Forms.MenuItem();
            this.menuItem53 = new System.Windows.Forms.MenuItem();
            this.m_mtmInpatMedRec = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem38 = new System.Windows.Forms.MenuItem();
            this.menuItem39 = new System.Windows.Forms.MenuItem();
            this.menuItem40 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.menuItem18 = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItem22 = new System.Windows.Forms.MenuItem();
            this.menuItem23 = new System.Windows.Forms.MenuItem();
            this.menuItem24 = new System.Windows.Forms.MenuItem();
            this.menuItem20 = new System.Windows.Forms.MenuItem();
            this.menuItem21 = new System.Windows.Forms.MenuItem();
            this.menuItem25 = new System.Windows.Forms.MenuItem();
            this.menuItem26 = new System.Windows.Forms.MenuItem();
            this.mniEKGOrder = new System.Windows.Forms.MenuItem();
            this.mniNuclearOrder = new System.Windows.Forms.MenuItem();
            this.mniPSGOrder = new System.Windows.Forms.MenuItem();
            this.mniLabAnalysisOrder = new System.Windows.Forms.MenuItem();
            this.mniLabCheckReport = new System.Windows.Forms.MenuItem();
            this.mniImageReport = new System.Windows.Forms.MenuItem();
            this.mniImageBookingSearch = new System.Windows.Forms.MenuItem();
            this.menuItem27 = new System.Windows.Forms.MenuItem();
            this.menuItem28 = new System.Windows.Forms.MenuItem();
            this.menuItem29 = new System.Windows.Forms.MenuItem();
            this.menuItem30 = new System.Windows.Forms.MenuItem();
            this.menuItem31 = new System.Windows.Forms.MenuItem();
            this.menuItem32 = new System.Windows.Forms.MenuItem();
            this.menuItem33 = new System.Windows.Forms.MenuItem();
            this.menuItem34 = new System.Windows.Forms.MenuItem();
            this.menuItem35 = new System.Windows.Forms.MenuItem();
            this.mniDirectionAnalisys = new System.Windows.Forms.MenuItem();
            this.menuItem36 = new System.Windows.Forms.MenuItem();
            this.menuItem37 = new System.Windows.Forms.MenuItem();
            this.mniPatientInfoManage = new System.Windows.Forms.MenuItem();
            this.menuItem41 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem42 = new System.Windows.Forms.MenuItem();
            this.menuItem43 = new System.Windows.Forms.MenuItem();
            this.mniICUTendRecord = new System.Windows.Forms.MenuItem();
            this.menuItem44 = new System.Windows.Forms.MenuItem();
            this.menuItem45 = new System.Windows.Forms.MenuItem();
            this.menuItem46 = new System.Windows.Forms.MenuItem();
            this.menuItem47 = new System.Windows.Forms.MenuItem();
            this.menuItem48 = new System.Windows.Forms.MenuItem();
            this.menuItem49 = new System.Windows.Forms.MenuItem();
            this.menuItem50 = new System.Windows.Forms.MenuItem();
            this.m_mniDoctorOrder = new System.Windows.Forms.MenuItem();
            this.m_lblEmployeeInfo = new System.Windows.Forms.Label();
            this.cmdRefresh = new PinkieControls.ButtonXP();
            this.cmdCancel = new PinkieControls.ButtonXP();
            this.m_txtConsultationIdea = new com.digitalwave.controls.ctlRichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtpConsultationDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_cmdPrint = new PinkieControls.ButtonXP();
            this.m_cmdDoctorSign = new PinkieControls.ButtonXP();
            this.lsvSign = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_cmdApply = new PinkieControls.ButtonXP();
            this.m_ttpTextInfo = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lsvConsultation
            // 
            this.lsvConsultation.BackColor = System.Drawing.Color.White;
            this.lsvConsultation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmConsultationTime,
            this.clmDept,
            this.clmRequestDoc,
            this.clmTime});
            this.lsvConsultation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvConsultation.ForeColor = System.Drawing.Color.Black;
            this.lsvConsultation.FullRowSelect = true;
            this.lsvConsultation.GridLines = true;
            this.lsvConsultation.HideSelection = false;
            this.lsvConsultation.Location = new System.Drawing.Point(16, 4);
            this.lsvConsultation.MultiSelect = false;
            this.lsvConsultation.Name = "lsvConsultation";
            this.lsvConsultation.Size = new System.Drawing.Size(642, 156);
            this.lsvConsultation.TabIndex = 100;
            this.lsvConsultation.UseCompatibleStateImageBehavior = false;
            this.lsvConsultation.View = System.Windows.Forms.View.Details;
            this.lsvConsultation.SelectedIndexChanged += new System.EventHandler(this.lsvConsultation_SelectedIndexChanged);
            this.lsvConsultation.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvEmployeeInfo_ColumnClick);
            this.lsvConsultation.TabIndexChanged += new System.EventHandler(this.lsvEmployeeInfo_TabIndexChanged);
            // 
            // clmConsultationTime
            // 
            this.clmConsultationTime.Text = "申请会诊时间";
            this.clmConsultationTime.Width = 185;
            // 
            // clmDept
            // 
            this.clmDept.Text = "申请会诊科室";
            this.clmDept.Width = 185;
            // 
            // clmRequestDoc
            // 
            this.clmRequestDoc.Text = "申请者";
            this.clmRequestDoc.Width = 75;
            // 
            // clmTime
            // 
            this.clmTime.Text = "申请日期";
            this.clmTime.Width = 180;
            // 
            // m_txtDetail
            // 
            this.m_txtDetail.AccessibleDescription = "简要病历";
            this.m_txtDetail.BackColor = System.Drawing.Color.White;
            this.m_txtDetail.ContextMenuStrip = this.m_cmsEMRMenu;
            this.m_txtDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDetail.ForeColor = System.Drawing.Color.Black;
            this.m_txtDetail.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtDetail.Location = new System.Drawing.Point(16, 179);
            this.m_txtDetail.m_BlnIgnoreUserInfo = true;
            this.m_txtDetail.m_BlnPartControl = false;
            this.m_txtDetail.m_BlnReadOnly = true;
            this.m_txtDetail.m_BlnUnderLineDST = false;
            this.m_txtDetail.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtDetail.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtDetail.m_IntCanModifyTime = 6;
            this.m_txtDetail.m_IntPartControlLength = 0;
            this.m_txtDetail.m_IntPartControlStartIndex = 0;
            this.m_txtDetail.m_StrUserID = "";
            this.m_txtDetail.m_StrUserName = "";
            this.m_txtDetail.Name = "m_txtDetail";
            this.m_txtDetail.ReadOnly = true;
            this.m_txtDetail.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtDetail.Size = new System.Drawing.Size(642, 145);
            this.m_txtDetail.TabIndex = 110;
            this.m_txtDetail.Text = "";
            // 
            // m_cmsEMRMenu
            // 
            this.m_cmsEMRMenu.Name = "m_cmsEMRMenu";
            this.m_cmsEMRMenu.Size = new System.Drawing.Size(61, 4);
            this.m_cmsEMRMenu.Opening += new System.ComponentModel.CancelEventHandler(this.m_cmsEMRMenu_Opening);
            // 
            // m_ctmExplorer
            // 
            this.m_ctmExplorer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.m_mnuInPatient,
            this.menuItem4,
            this.menuItem9,
            this.menuItem12,
            this.menuItem13,
            this.menuItem51,
            this.menuItem54,
            this.menuItem56,
            this.menuItem55,
            this.menuItem57,
            this.menuItem16,
            this.menuItem52,
            this.menuItem53,
            this.m_mtmInpatMedRec,
            this.menuItem1,
            this.menuItem38,
            this.menuItem39,
            this.menuItem40,
            this.menuItem2,
            this.menuItem3,
            this.menuItem37,
            this.m_mniDoctorOrder});
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.Text = "住院病案首页";
            // 
            // m_mnuInPatient
            // 
            this.m_mnuInPatient.Index = 1;
            this.m_mnuInPatient.Text = "住院病历";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "住院病历(自由录入风格)";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 3;
            this.menuItem9.Text = "病程记录";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 4;
            this.menuItem12.Text = "术前小结";
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 5;
            this.menuItem13.Text = "手术记录单";
            // 
            // menuItem51
            // 
            this.menuItem51.Index = 6;
            this.menuItem51.Text = "手术通知单";
            // 
            // menuItem54
            // 
            this.menuItem54.Index = 7;
            this.menuItem54.Text = "术前术后访视单";
            // 
            // menuItem56
            // 
            this.menuItem56.Index = 8;
            this.menuItem56.Text = "麻醉记录单";
            // 
            // menuItem55
            // 
            this.menuItem55.Index = 9;
            this.menuItem55.Text = "24小时内入出院记录";
            // 
            // menuItem57
            // 
            this.menuItem57.Index = 10;
            this.menuItem57.Text = "入院24小时内死亡记录";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 11;
            this.menuItem16.Text = "出院记录";
            // 
            // menuItem52
            // 
            this.menuItem52.Index = 12;
            this.menuItem52.Text = "死亡记录";
            // 
            // menuItem53
            // 
            this.menuItem53.Index = 13;
            this.menuItem53.Text = "死亡病例讨论记录";
            // 
            // m_mtmInpatMedRec
            // 
            this.m_mtmInpatMedRec.Index = 14;
            this.m_mtmInpatMedRec.Text = "专科病历";
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 15;
            this.menuItem1.Text = "-";
            // 
            // menuItem38
            // 
            this.menuItem38.Index = 16;
            this.menuItem38.Text = "入院病人评估";
            // 
            // menuItem39
            // 
            this.menuItem39.Index = 17;
            this.menuItem39.Text = "三 测 表";
            // 
            // menuItem40
            // 
            this.menuItem40.Index = 18;
            this.menuItem40.Text = "一般护理记录";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 19;
            this.menuItem2.Text = "-";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 20;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem19,
            this.menuItem27,
            this.mniDirectionAnalisys,
            this.menuItem36});
            this.menuItem3.Text = "医生工作站";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem8,
            this.menuItem10,
            this.menuItem11,
            this.menuItem14,
            this.menuItem15,
            this.menuItem17,
            this.menuItem18});
            this.menuItem6.Text = "病案生成";
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 0;
            this.menuItem8.Text = "住院病历模式2";
            this.menuItem8.Visible = false;
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "会诊记录";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 2;
            this.menuItem11.Text = "手术知情同意书";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "ICU转入记录";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 4;
            this.menuItem15.Text = "ICU转出记录";
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 5;
            this.menuItem17.Text = "住院病案首页";
            // 
            // menuItem18
            // 
            this.menuItem18.Index = 6;
            this.menuItem18.Text = "病案质量评分表";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 1;
            this.menuItem19.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem22,
            this.menuItem23,
            this.menuItem24,
            this.menuItem20,
            this.menuItem21,
            this.menuItem25,
            this.menuItem26,
            this.mniEKGOrder,
            this.mniNuclearOrder,
            this.mniPSGOrder,
            this.mniLabAnalysisOrder,
            this.mniLabCheckReport,
            this.mniImageReport,
            this.mniImageBookingSearch});
            this.menuItem19.Text = "申  请  单";
            // 
            // menuItem22
            // 
            this.menuItem22.Index = 0;
            this.menuItem22.Text = "B型超声显像检查申请单";
            // 
            // menuItem23
            // 
            this.menuItem23.Index = 1;
            this.menuItem23.Text = "CT检查申请单";
            // 
            // menuItem24
            // 
            this.menuItem24.Index = 2;
            this.menuItem24.Text = "X线申请单";
            // 
            // menuItem20
            // 
            this.menuItem20.Index = 3;
            this.menuItem20.Text = "SPECT检查申请单";
            // 
            // menuItem21
            // 
            this.menuItem21.Index = 4;
            this.menuItem21.Text = "高压氧治疗申请单";
            // 
            // menuItem25
            // 
            this.menuItem25.Index = 5;
            this.menuItem25.Text = "病理活体组织送检单";
            // 
            // menuItem26
            // 
            this.menuItem26.Index = 6;
            this.menuItem26.Text = "MRI申请单";
            // 
            // mniEKGOrder
            // 
            this.mniEKGOrder.Index = 7;
            this.mniEKGOrder.Text = "心电图申请单";
            // 
            // mniNuclearOrder
            // 
            this.mniNuclearOrder.Index = 8;
            this.mniNuclearOrder.Text = "电脑多导睡眠图检查申请单";
            // 
            // mniPSGOrder
            // 
            this.mniPSGOrder.Index = 9;
            this.mniPSGOrder.Text = "核医学检查申请单";
            // 
            // mniLabAnalysisOrder
            // 
            this.mniLabAnalysisOrder.Index = 10;
            this.mniLabAnalysisOrder.Text = "实验室检验申请单";
            this.mniLabAnalysisOrder.Visible = false;
            // 
            // mniLabCheckReport
            // 
            this.mniLabCheckReport.Index = 11;
            this.mniLabCheckReport.Text = "实验室检验报告单";
            // 
            // mniImageReport
            // 
            this.mniImageReport.Index = 12;
            this.mniImageReport.Text = "影像报告单";
            // 
            // mniImageBookingSearch
            // 
            this.mniImageBookingSearch.Index = 13;
            this.mniImageBookingSearch.Text = "影像预约查询";
            this.mniImageBookingSearch.Visible = false;
            // 
            // menuItem27
            // 
            this.menuItem27.Index = 2;
            this.menuItem27.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem28,
            this.menuItem29,
            this.menuItem30,
            this.menuItem31,
            this.menuItem32,
            this.menuItem33,
            this.menuItem34,
            this.menuItem35});
            this.menuItem27.Text = "智能评分系统";
            // 
            // menuItem28
            // 
            this.menuItem28.Index = 0;
            this.menuItem28.Text = "SIRS诊断评分";
            // 
            // menuItem29
            // 
            this.menuItem29.Index = 1;
            this.menuItem29.Text = "改良Glasgow昏迷评分";
            // 
            // menuItem30
            // 
            this.menuItem30.Index = 2;
            this.menuItem30.Text = "急性肺损伤评分";
            // 
            // menuItem31
            // 
            this.menuItem31.Index = 3;
            this.menuItem31.Text = "新生儿危重病例评分";
            // 
            // menuItem32
            // 
            this.menuItem32.Index = 4;
            this.menuItem32.Text = "小儿危重病例评分";
            // 
            // menuItem33
            // 
            this.menuItem33.Index = 5;
            this.menuItem33.Text = "APACHEII 评分";
            // 
            // menuItem34
            // 
            this.menuItem34.Index = 6;
            this.menuItem34.Text = "APACHEIII 评分";
            // 
            // menuItem35
            // 
            this.menuItem35.Index = 7;
            this.menuItem35.Text = "TISS-28评分";
            // 
            // mniDirectionAnalisys
            // 
            this.mniDirectionAnalisys.Index = 3;
            this.mniDirectionAnalisys.Text = "趋势分析";
            // 
            // menuItem36
            // 
            this.menuItem36.Index = 4;
            this.menuItem36.Text = "全套病历";
            this.menuItem36.Visible = false;
            // 
            // menuItem37
            // 
            this.menuItem37.Index = 21;
            this.menuItem37.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniPatientInfoManage,
            this.menuItem41,
            this.menuItem7,
            this.menuItem42,
            this.menuItem43,
            this.mniICUTendRecord,
            this.menuItem44,
            this.menuItem45,
            this.menuItem46,
            this.menuItem47,
            this.menuItem48,
            this.menuItem49,
            this.menuItem50});
            this.menuItem37.Text = "护士工作站";
            // 
            // mniPatientInfoManage
            // 
            this.mniPatientInfoManage.Index = 0;
            this.mniPatientInfoManage.Text = "病人基本资料维护";
            // 
            // menuItem41
            // 
            this.menuItem41.Index = 1;
            this.menuItem41.Text = "观察项目记录表";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "一般患者护理记录";
            // 
            // menuItem42
            // 
            this.menuItem42.Index = 3;
            this.menuItem42.Text = "危重患者护理记录";
            // 
            // menuItem43
            // 
            this.menuItem43.Index = 4;
            this.menuItem43.Text = "危重症监护中心特护记录单";
            // 
            // mniICUTendRecord
            // 
            this.mniICUTendRecord.Index = 5;
            this.mniICUTendRecord.Text = "ICU危重患者护理记录";
            this.mniICUTendRecord.Visible = false;
            // 
            // menuItem44
            // 
            this.menuItem44.Index = 6;
            this.menuItem44.Text = "手术护理记录";
            // 
            // menuItem45
            // 
            this.menuItem45.Index = 7;
            this.menuItem45.Text = "手术器械、敷料点数表";
            // 
            // menuItem46
            // 
            this.menuItem46.Index = 8;
            this.menuItem46.Text = "中心ICU呼吸机治疗监护记录单";
            // 
            // menuItem47
            // 
            this.menuItem47.Index = 9;
            this.menuItem47.Text = "ICU护理记录";
            // 
            // menuItem48
            // 
            this.menuItem48.Index = 10;
            this.menuItem48.Text = "心血管外科护理记录";
            // 
            // menuItem49
            // 
            this.menuItem49.Index = 11;
            this.menuItem49.Text = "快速微量血糖检测记录表";
            // 
            // menuItem50
            // 
            this.menuItem50.Index = 12;
            this.menuItem50.Text = "外科ICU监护记录";
            // 
            // m_mniDoctorOrder
            // 
            this.m_mniDoctorOrder.Index = 22;
            this.m_mniDoctorOrder.Text = "医嘱";
            this.m_mniDoctorOrder.Click += new System.EventHandler(this.m_mniDoctorOrder_Click);
            // 
            // m_lblEmployeeInfo
            // 
            this.m_lblEmployeeInfo.AutoSize = true;
            this.m_lblEmployeeInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblEmployeeInfo.ForeColor = System.Drawing.Color.Black;
            this.m_lblEmployeeInfo.Location = new System.Drawing.Point(20, 163);
            this.m_lblEmployeeInfo.Name = "m_lblEmployeeInfo";
            this.m_lblEmployeeInfo.Size = new System.Drawing.Size(70, 14);
            this.m_lblEmployeeInfo.TabIndex = 6106;
            this.m_lblEmployeeInfo.Text = "详细信息:";
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdRefresh.DefaultScheme = true;
            this.cmdRefresh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdRefresh.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdRefresh.ForeColor = System.Drawing.Color.Black;
            this.cmdRefresh.Hint = "";
            this.cmdRefresh.Location = new System.Drawing.Point(510, 463);
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdRefresh.Size = new System.Drawing.Size(45, 28);
            this.cmdRefresh.TabIndex = 120;
            this.cmdRefresh.Text = "刷新";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.cmdCancel.DefaultScheme = true;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmdCancel.ForeColor = System.Drawing.Color.Black;
            this.cmdCancel.Hint = "";
            this.cmdCancel.Location = new System.Drawing.Point(561, 463);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdCancel.Size = new System.Drawing.Size(45, 28);
            this.cmdCancel.TabIndex = 130;
            this.cmdCancel.Text = "取消";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // m_txtConsultationIdea
            // 
            this.m_txtConsultationIdea.AccessibleDescription = "会诊意见";
            this.m_txtConsultationIdea.BackColor = System.Drawing.Color.White;
            this.m_txtConsultationIdea.Font = new System.Drawing.Font("宋体", 10.5F);
            this.m_txtConsultationIdea.ForeColor = System.Drawing.Color.Black;
            this.m_txtConsultationIdea.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtConsultationIdea.Location = new System.Drawing.Point(16, 352);
            this.m_txtConsultationIdea.m_BlnIgnoreUserInfo = true;
            this.m_txtConsultationIdea.m_BlnPartControl = false;
            this.m_txtConsultationIdea.m_BlnReadOnly = false;
            this.m_txtConsultationIdea.m_BlnUnderLineDST = false;
            this.m_txtConsultationIdea.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtConsultationIdea.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtConsultationIdea.m_IntCanModifyTime = 6;
            this.m_txtConsultationIdea.m_IntPartControlLength = 0;
            this.m_txtConsultationIdea.m_IntPartControlStartIndex = 0;
            this.m_txtConsultationIdea.m_StrUserID = "";
            this.m_txtConsultationIdea.m_StrUserName = "";
            this.m_txtConsultationIdea.Name = "m_txtConsultationIdea";
            this.m_txtConsultationIdea.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtConsultationIdea.Size = new System.Drawing.Size(640, 108);
            this.m_txtConsultationIdea.TabIndex = 29161;
            this.m_txtConsultationIdea.Text = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(20, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 29162;
            this.label3.Text = "会诊答复:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(392, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 29163;
            this.label5.Text = "会诊日期:";
            // 
            // m_dtpConsultationDate
            // 
            this.m_dtpConsultationDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpConsultationDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpConsultationDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.m_dtpConsultationDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpConsultationDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpConsultationDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpConsultationDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpConsultationDate.ForeColor = System.Drawing.Color.Black;
            this.m_dtpConsultationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpConsultationDate.Location = new System.Drawing.Point(468, 327);
            this.m_dtpConsultationDate.m_BlnOnlyTime = false;
            this.m_dtpConsultationDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpConsultationDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpConsultationDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpConsultationDate.Name = "m_dtpConsultationDate";
            this.m_dtpConsultationDate.ReadOnly = false;
            this.m_dtpConsultationDate.Size = new System.Drawing.Size(188, 22);
            this.m_dtpConsultationDate.TabIndex = 29160;
            this.m_dtpConsultationDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpConsultationDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_cmdPrint
            // 
            this.m_cmdPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdPrint.DefaultScheme = true;
            this.m_cmdPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdPrint.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdPrint.ForeColor = System.Drawing.Color.Black;
            this.m_cmdPrint.Hint = "";
            this.m_cmdPrint.Location = new System.Drawing.Point(612, 463);
            this.m_cmdPrint.Name = "m_cmdPrint";
            this.m_cmdPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdPrint.Size = new System.Drawing.Size(45, 28);
            this.m_cmdPrint.TabIndex = 29164;
            this.m_cmdPrint.Text = "套打";
            this.m_cmdPrint.Click += new System.EventHandler(this.m_cmdPrint_Click);
            // 
            // m_cmdDoctorSign
            // 
            this.m_cmdDoctorSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDoctorSign.DefaultScheme = true;
            this.m_cmdDoctorSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDoctorSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdDoctorSign.ForeColor = System.Drawing.Color.Black;
            this.m_cmdDoctorSign.Hint = "";
            this.m_cmdDoctorSign.Location = new System.Drawing.Point(17, 463);
            this.m_cmdDoctorSign.Name = "m_cmdDoctorSign";
            this.m_cmdDoctorSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDoctorSign.Size = new System.Drawing.Size(84, 28);
            this.m_cmdDoctorSign.TabIndex = 10000030;
            this.m_cmdDoctorSign.Text = "会诊医师:";
            // 
            // lsvSign
            // 
            this.lsvSign.BackColor = System.Drawing.Color.White;
            this.lsvSign.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lsvSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvSign.ForeColor = System.Drawing.Color.Black;
            this.lsvSign.FullRowSelect = true;
            this.lsvSign.GridLines = true;
            this.lsvSign.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvSign.Location = new System.Drawing.Point(104, 465);
            this.lsvSign.Name = "lsvSign";
            this.lsvSign.Size = new System.Drawing.Size(350, 26);
            this.lsvSign.TabIndex = 10000032;
            this.lsvSign.UseCompatibleStateImageBehavior = false;
            this.lsvSign.View = System.Windows.Forms.View.SmallIcon;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.m_pdcPrintDocument;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // m_pdcPrintDocument
            // 
            this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
            // 
            // m_cmdApply
            // 
            this.m_cmdApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdApply.DefaultScheme = true;
            this.m_cmdApply.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdApply.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdApply.ForeColor = System.Drawing.Color.Black;
            this.m_cmdApply.Hint = "";
            this.m_cmdApply.Location = new System.Drawing.Point(460, 463);
            this.m_cmdApply.Name = "m_cmdApply";
            this.m_cmdApply.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdApply.Size = new System.Drawing.Size(45, 28);
            this.m_cmdApply.TabIndex = 120;
            this.m_cmdApply.Text = "回复";
            this.m_cmdApply.Click += new System.EventHandler(this.m_cmdApply_Click);
            // 
            // m_ttpTextInfo
            // 
            this.m_ttpTextInfo.AutomaticDelay = 200;
            // 
            // frmConsultationSearch
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(670, 495);
            this.Controls.Add(this.m_txtDetail);
            this.Controls.Add(this.m_cmdDoctorSign);
            this.Controls.Add(this.m_cmdPrint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_lblEmployeeInfo);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.m_cmdApply);
            this.Controls.Add(this.cmdRefresh);
            this.Controls.Add(this.lsvSign);
            this.Controls.Add(this.m_txtConsultationIdea);
            this.Controls.Add(this.m_dtpConsultationDate);
            this.Controls.Add(this.lsvConsultation);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsultationSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会诊通知";
            this.Load += new System.EventHandler(this.frmConsultationSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmConsultationSearch_Load(object sender, System.EventArgs e)
		{
			lsvConsultation.Focus();

			this.m_dtpConsultationDate.m_EnmVisibleFlag=ctlTimePicker.enmDateTimeFlag.Minute;
			this.m_dtpConsultationDate.m_mthResetSize();
		}

		private void lsvEmployeeInfo_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
            //m_objColumnSort.m_IntColumn = e.Column;
            //lsvConsultation.Sort();
		}

		private void lsvEmployeeInfo_TabIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void m_lblForTitle_Click(object sender, System.EventArgs e)
		{
		
		}

        private clsPatient CurrentPatient = null;
        private string m_strApplyTime = "";
		private void lsvConsultation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            CurrentPatient = null;
            lsvSign.Items.Clear();
			if(lsvConsultation.SelectedItems.Count <= 0)
				return;

			clsConsultationRecordContent objRecord = ((clsConsultationRecordContent)lsvConsultation.SelectedItems[0].Tag);

			//查新表，打开相应表单同步病人信息
            string strHISID = "";

            com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                    (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

            long lngRes = objServ.m_lngGetHISIDByEMRID(objRecord.m_strInPatientID,out strHISID);
            objServ = null;

            if(string.IsNullOrEmpty(strHISID))
            {
                clsPublicFunction.ShowInformationMessageBox("获取病人信息出错！");
                return;
            }

			clsPatient objNew = new clsPatient(objRecord.m_strInPatientID,strHISID,null);
			clsPatientInBedInfo objNewBed = new clsPatientInBedInfo(objNew);
			string strNewDept = "";
			string strNewArea = "";
			string strNewBed = "";
			if(objNewBed != null && objNewBed.m_ObjLastSessionInfo != null)
			{
				strNewDept = objNewBed.m_strNewDeptIDForSearch;
				strNewArea = objNewBed.m_strNewAreaIDForSearch;
				if(objNewBed.m_ObjLastRoomInfo.m_intGetBedCount() > 0)
					strNewBed = objNewBed.m_ObjLastRoomInfo.m_objGetBedByIndex(0).m_ObjBed.m_StrBedName;
			}

            clsPatient objPatient = new clsPatient(objRecord.m_strInPatientID, strHISID, null);
			objPatient.m_strDeptNewID = strNewDept;
			objPatient.m_strAreaNewID = strNewArea;
			objPatient.m_strBedCode = strNewBed;

            CurrentPatient = objPatient;

            if (CurrentPatient != null)
            {                
                clsHospitalManagerDomain objDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO objDeptNew;
                objDomain.m_lngGetSpecialDeptInfo(CurrentPatient.m_strDeptNewID, out objDeptNew);
                MDIParent.m_objCurrentDepartment = objDeptNew;
                com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentDepartment = objDeptNew;
                MDIParent.s_ObjCurrentPatient = CurrentPatient;
            }

            m_strApplyTime = lsvConsultation.SelectedItems[0].SubItems[3].Text;

			string strAge = objPatient.m_ObjPeopleInfo.m_StrAge;

            string strDeptInfo = "";
            if (objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName == objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName)
            {
                strDeptInfo = objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName;
            }
            else
            {
                strDeptInfo = objPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName
                + " " + objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaName;
            }

            m_txtDetail.Text = "病人信息：" + objPatient .m_StrHISInPatientID + "  " + objPatient.m_ObjPeopleInfo.m_StrLastName + " " + objPatient.m_ObjPeopleInfo.m_StrSex + " " + strAge
                + " " + strDeptInfo
				+" "+objPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName+"床"
                + "\r\n请求会诊科室:" + objRecord.m_strApplyConsultationDeptName
				+ "\r\n\r\n简要病历及会诊目的："+objRecord.m_strCaseHistory_Right
				+"\r\n\r\n目前诊断："+objRecord.m_strConsultationOrder_Right;

            if (objRecord.m_strConsultationDoctorIDArr != null && objRecord.m_strConsultationDoctorIDArr.Length > 0)
            {
                m_txtConsultationIdea.Text = objRecord.m_strConsultationIdea_Right;

                com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                clsEmrEmployeeBase_VO objEmpVO = new clsEmrEmployeeBase_VO();
                for (int i = 0; i < objRecord.m_strConsultationDoctorIDArr.Length; i++)
                {
                    objEmployeeSign.m_lngGetEmpByNO(objRecord.m_strConsultationDoctorIDArr[i], out objEmpVO);
                    ListViewItem lviNewItem = new ListViewItem(objEmpVO.m_strGetTechnicalRankAndName);
                    lviNewItem.SubItems.Add(objEmpVO.m_strEMPID_CHR);
                    lviNewItem.SubItems.Add(objEmpVO.m_strLEVEL_CHR);
                    lviNewItem.Tag = objEmpVO;
                    lsvSign.Items.Add(lviNewItem);
                }

                m_cmdApply.Enabled = false;
                m_cmdDoctorSign.Enabled = false;
                m_txtConsultationIdea.ReadOnly = true;
            }
            else
            {
                lsvSign.Items.Clear();
                m_txtConsultationIdea.Clear();
                m_cmdApply.Enabled = true;
                m_cmdDoctorSign.Enabled = true;
                m_txtConsultationIdea.ReadOnly = false;
            }
		}

		private void cmdRefresh_Click(object sender, System.EventArgs e)
		{
            m_mthSetConsultationContent();
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter
					break;
				case 38:
				case 40:						
					break;	
			}	
		}	
        		

		private void m_cmdPrint_Click(object sender, System.EventArgs e)
		{
			if(lsvConsultation.SelectedItems.Count <= 0)
				return;

			if(lsvSign.Items.Count == 0)
			{
				clsPublicFunction.ShowInformationMessageBox("请至少一个医生签名！");
				return;
			}

			if(m_txtConsultationIdea.Text.Trim() == "")
			{
				clsPublicFunction.ShowInformationMessageBox("请先填写会诊答复！");
				return;
			}

            m_mthPrintReply();
            this.Close();
            //if(m_lngSaveReply() > 0)
            //{
            //    m_mthPrintReply();

            //    this.Close();
            //}
		}

		/// <summary>
		/// 保存答复内容
		/// </summary>
		private long m_lngSaveReply()
		{
			clsConsultationRecordContent objOldRecord = ((clsConsultationRecordContent)lsvConsultation.SelectedItems[0].Tag);			            
			clsConsultationRecordContent objNewRecord = new clsConsultationRecordContent();
			objNewRecord = (clsConsultationRecordContent)objOldRecord.Clone();

			//获取服务器时间
			string strTimeNow=new clsPublicDomain().m_strGetServerTime();
			objNewRecord.m_dtmModifyDate=DateTime.Parse(strTimeNow);
			objNewRecord.m_dtmConsultationDate = m_dtpConsultationDate.Value;
			objNewRecord.m_strConsultationIdea_Right = m_txtConsultationIdea.m_strGetRightText();	
			objNewRecord.m_strConsultationIdea = m_txtConsultationIdea.Text;
			objNewRecord.m_strConsultationIdeaXml = m_txtConsultationIdea.m_strGetXmlText();
			if(lsvSign.Items.Count>0)
			{			
				objNewRecord.m_strConsultationDoctorIDArr=new string[lsvSign.Items.Count];
				objNewRecord.m_strConsultationDoctorNameArr=new string[lsvSign.Items.Count];
				for(int i=0;i<lsvSign.Items.Count;i++)
				{
					objNewRecord.m_strConsultationDoctorIDArr[i]=lsvSign.Items[i].SubItems[1].Text;
					objNewRecord.m_strConsultationDoctorNameArr[i]=lsvSign.Items[i].SubItems[0].Text;
				}
			}

			//修改记录
			clsPreModifyInfo objModifyInfo=null;
            //return clsDiseaseTrackDomainFactory.s_objGetDiseaseTrackDomain(enmDiseaseTrackType.Consultation).m_lngModifyRecord(objOldRecord,objNewRecord,out objModifyInfo);		  
            return new clsDiseaseTrackDomain(enmDiseaseTrackType.Consultation).m_lngModifyRecord(objOldRecord, objNewRecord, out objModifyInfo);	
		}

		/// <summary>
		/// 打印答复内容
		/// </summary>
		private void m_mthPrintReply()
		{
//			printPreviewDialog1.ShowDialog();
			m_pdcPrintDocument.Print();
		}

		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			string strTime = m_dtpConsultationDate.Value.ToString("yyyy年M月d日 H时m分");
			string strIdea = m_txtConsultationIdea.Text;
			string strIdeaXml = m_txtConsultationIdea.m_strGetXmlText();
			string strDoctor = "";
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for(int i=0;i<lsvSign.Items.Count;i++)
			{
				sb.Append(lsvSign.Items[i].SubItems[0].Text);
				sb.Append(" ");
			}
			strDoctor = sb.ToString();

			Graphics g = e.Graphics;
			Font fntTitle = new Font("SimSun",12);

			g.DrawString(strTime,fntTitle,Brushes.Black,480,695 - 30);

			int intRealHeight;
			Rectangle rtgDianose = new Rectangle(135,695,640,240);//位置从会诊打印Debug中得来
			rtgDianose.Height = 8*(int)enmRectangleInfo.RowStep;
			clsPrintRichTextContext objDiagnose = new clsPrintRichTextContext(Color.Black,fntTitle);
			objDiagnose.m_mthSetContextWithCorrectBefore(strIdea,strIdeaXml,DateTime.Now);
			objDiagnose.m_blnPrintAllBySimSun(11,rtgDianose,g,out intRealHeight,false);

			g.DrawString(strDoctor,fntTitle,Brushes.Black,40+500+(int)(5f*17.5f),970);
			
			fntTitle.Dispose();
            g.Dispose();
		}

        #region m_cmdApply_Click点击回复事件
        private void m_cmdApply_Click(object sender, EventArgs e)
        {
            if (lsvConsultation.Items.Count == 0 || lsvConsultation.SelectedItems.Count == 0)
            {
                return;
            }

            if (lsvSign.Items.Count == 0)
            {
                clsPublicFunction.ShowInformationMessageBox("请会诊医师签名！");
                return;
            }

            if (string.IsNullOrEmpty(m_txtConsultationIdea.m_strGetRightText()))
            {
                clsPublicFunction.ShowInformationMessageBox("回复信息不能为空");
                return;
            }
            clsConsultationRecordContent objContent = lsvConsultation.SelectedItems[0].Tag as clsConsultationRecordContent;
            if (objContent == null)
                return;
            objContent.m_strConsultationIdea = m_txtConsultationIdea.Text;
            objContent.m_strConsultationIdea_Right = m_txtConsultationIdea.m_strGetRightText();
            objContent.m_strConsultationIdeaXml = m_txtConsultationIdea.m_strGetXmlText();
            objContent.m_intHASREPLIED = 1;

            objContent.m_strConsultationDoctorIDArr = new string[lsvSign.Items.Count];
            objContent.m_strConsultationDoctorNameArr = new string[lsvSign.Items.Count];
            objContent.m_dtmConsultationDate = m_dtpConsultationDate.Value;
            clsEmrEmployeeBase_VO objEmp = null;
            for (int i = 0; i < lsvSign.Items.Count; i++)
            {
                objEmp = (clsEmrEmployeeBase_VO)(lsvSign.Items[i].Tag);
                if (objEmp == null)
                    continue;
                objContent.m_strConsultationDoctorIDArr[i] = objEmp.m_strEMPNO_CHR;
                objContent.m_strConsultationDoctorNameArr[i] = objEmp.m_strLASTNAME_VCHR;
            }
            objEmp = null;

            long lngRes = m_objConsultationDomain.m_lngModifyRecord2DB(objContent);
            if (lngRes > 0)
            {
                m_txtConsultationIdea.Text = string.Empty;
                lsvSign.Items.Clear();
                cmdRefresh_Click(null, null);
                clsPublicFunction.ShowInformationMessageBox("会诊通知已回复！");
            }
        } 
        #endregion

        /// <summary>
        /// 获取能查看会诊病人病历时限
        /// </summary>
        private void m_mthGetCanQreryTime()
        {
            try
            {
                m_intCanQreryTime = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3008");
            }
            catch
            {
                m_intCanQreryTime = 0;
            }
        }

        /// <summary>
        /// 查询并设置会诊通知至界面
        /// </summary>
        private void m_mthSetConsultationContent()
        {
            lsvConsultation.Items.Clear();
            CurrentPatient = null;
            lsvConsultation.BeginUpdate();
            this.Cursor = Cursors.WaitCursor;
            try
            {
                m_txtDetail.Text = "";
                clsConsultationRecordContent[] objContentArr;
                m_objConsultationDomain.m_lngGetRecordContentWithServ(m_strDeptIDArr, out objContentArr);
                string strConsultationTime;
                if (objContentArr != null)
                {
                    clsConsultationRecordContent objConsultationRecord = null;
                    for (int i = 0; i < objContentArr.Length; i++)
                    {
                        objConsultationRecord = objContentArr[i];
                        if (m_blnIsTimeOutForQrery(objConsultationRecord.m_dtmConsultationDate))
                            continue;

                        if (objConsultationRecord.m_intConsultationTime == 1)
                            strConsultationTime = "请即时会诊";
                        else if (objConsultationRecord.m_intConsultationTime == 2)
                            strConsultationTime = "请在二十四小时内会诊";
                        else
                            strConsultationTime = "一般会诊";
                        ListViewItem lviNewItem;

                        lviNewItem = new ListViewItem(new string[] { strConsultationTime, objConsultationRecord.m_strAskConsultationDeptName, objConsultationRecord.m_strMainDoctorName, objConsultationRecord.m_dtmConsultationDate.ToString() });

                        if (objConsultationRecord.m_strConsultationDoctorIDArr != null
                            && objConsultationRecord.m_strConsultationDoctorIDArr.Length > 0)
                        {
                            lviNewItem.ForeColor = Color.Blue;
                        }
                        lviNewItem.Tag = objConsultationRecord;
                        lsvConsultation.Items.Add(lviNewItem);
                    }
                    if (lsvConsultation.Items.Count > 0)
                    {
                        lsvConsultation.Items[0].Selected = true;
                    }
                    clsPublicFunction.s_mthChangeListViewLastColumnWidth(lsvConsultation, 10);
                }
            }
            finally
            {
                lsvConsultation.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        }

        #region 设置右键菜单
        private clsInpatMedRec_Type[] m_objTypeArr = null;
        /// <summary>
        /// 条件专科病历菜单并关联事件
        /// </summary>
        private void m_mthInitMenu()
        {
            m_objTypeArr = StaticObject::clsEMR_StaticObject.s_ObjInpatMedRec_DataShare.m_objTypeArr;
            if (m_objTypeArr != null)
            {
                for (int i = 0; i < m_objTypeArr.Length; i++)
                {
                    MenuItem item = new MenuItem(m_objTypeArr[i].m_strTypeName);
                    m_mtmInpatMedRec.MenuItems.Add(i, item);
                }
            }
            foreach (MenuItem mniSub in m_ctmExplorer.MenuItems)
                m_mthAssociateItemEvent(mniSub);
        }

        /// <summary>
        /// 关联菜单事件
        /// </summary>
        /// <param name="p_mniParent"></param>
        private void m_mthAssociateItemEvent(MenuItem p_mniParent)
        {
            if (p_mniParent.Text == "医嘱")
            {
                return;
            }
                    
            if (p_mniParent.MenuItems.Count == 0)
                p_mniParent.Click += new EventHandler(m_mthMenuItem_Click);

            for (int i = 0; i < p_mniParent.MenuItems.Count; i++)
            {
                m_mthAssociateItemEvent(p_mniParent.MenuItems[i]);
            }
        }

        /// <summary>
        /// 是否已超过浏览病历的时限
        /// </summary>
        /// <param name="p_dtmApplyDate">申请时间</param>
        /// <returns></returns>
        private bool m_blnIsTimeOutForQrery(DateTime p_dtmApplyDate)
        {
            TimeSpan ts = DateTime.Now - p_dtmApplyDate;

            if (ts.TotalHours > m_intCanQreryTime)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void m_mthMenuItem_Click(object sender, System.EventArgs e)
        {
            if (CurrentPatient == null)
                return;

            if (string.IsNullOrEmpty(m_strApplyTime))
            {
                return;
            }

            try
            {
                DateTime dtApplyTime = DateTime.Parse(m_strApplyTime);

                if (m_blnIsTimeOutForQrery(dtApplyTime))
                {
                    clsPublicFunction.ShowInformationMessageBox("已超过浏览病人 " + CurrentPatient.m_StrName + " 病历的时限!");
                    return;
                }
            }
            catch
            {
                return;
            }

            Form frmRecord = null;
            iCare.RecordSearch.clsRecordSearchDomain objDomain = new iCare.RecordSearch.clsRecordSearchDomain();
            frmRecord = objDomain.m_frmGetForm((MenuItem)sender);
            if (frmRecord == null)
            {
                string strTypeID = m_strGetTypeId(((MenuItem)sender).Text);
                try
                {
                    Assembly objAsm = Assembly.LoadFrom("Emr_InpatMedRec.dll");
                    object obj = objAsm.CreateInstance("iCare." + strTypeID);
                    frmRecord = (Form)obj;
                }
                catch { }
            }
            objDomain = null;
            m_mthOpenForm(frmRecord);
        }

        /// <summary>
        /// 获取表单ID
        /// </summary>
        /// <param name="p_strFormName"></param>
        /// <returns></returns>
        private string m_strGetTypeId(string p_strFormName)
        {
            if (m_objTypeArr != null)
            {
                for (int i = 0; i < m_objTypeArr.Length; i++)
                {
                    if (m_objTypeArr[i].m_strTypeName == p_strFormName)
                        return m_objTypeArr[i].m_strTypeID;
                }
            }
            return null;
        }

        /// <summary>
        /// 打开记录单
        /// </summary>
        /// <param name="p_frmRecord"></param>
        private void m_mthOpenForm(Form p_frmRecord)
        {
            if (CurrentPatient == null)
                return;
            
            clsMainMenuFunction m_objMainMenuFunction = new clsMainMenuFunction();
            if (m_objMainMenuFunction.m_blnIsSaveBeforeNewForm())
                return;
            if (m_objMainMenuFunction.m_blnCheckSamePatientForm(p_frmRecord, CurrentPatient.m_StrInPatientID))
                return;
            if (m_objMainMenuFunction.m_blnCheckForFormOpen(p_frmRecord, false))
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                p_frmRecord.MdiParent = clsEMRLogin.s_FrmMDI;
                p_frmRecord.WindowState = FormWindowState.Maximized;
                p_frmRecord.Show();
                frmHRPBaseForm frmRecord = p_frmRecord as frmHRPBaseForm;
                if (frmRecord != null)
                {
                    CurrentPatient.m_IntCharacter = 1;
                    frmRecord.m_mthSetPatient(CurrentPatient);

                    MDIParent.s_ObjSaveCue.m_mthRemoveForm(frmRecord);                    
                }
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            { string str = ex.Message; }
        } 
        #endregion

        /// <summary>
        /// 外部调用打开表单，并定位至指定病人
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        public void m_mthOpenThis(string p_strInPatientID)
        {
            m_mthOpenThis();

            if (!string.IsNullOrEmpty(p_strInPatientID))
            {
                if (lsvConsultation.Items.Count > 0)
                {
                    for (int i = 0; i < lsvConsultation.Items.Count; i++)
                    {
                        if (((clsConsultationRecordContent)lsvConsultation.Items[i].Tag).m_strInPatientID.Trim() == p_strInPatientID.Trim())
                        {
                            lsvConsultation.Items[i].EnsureVisible();
                            lsvConsultation.Items[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }
      
        /// <summary>
        /// 外部调用打开表单
        /// </summary>
        public void m_mthOpenThis()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Show();
        }

        #region 初始化菜单
        /// <summary>
        /// 初始化菜单
        /// </summary>
        private void m_mthInitEMRMenu()
        {
            clsEmrModuleMemuItem objMenu = new clsEmrModuleMemuItem();
            objMenu.m_mthGetEmrModuleMemu(this.m_cmsEMRMenu);
            objMenu = null;
        }
        #endregion

        private void m_cmsEMRMenu_Opening(object sender, CancelEventArgs e)
        {
            if (CurrentPatient != null)
            {
                CurrentPatient.m_IntCharacter = 1;

                DateTime dtApplyTime = DateTime.Now;
                if (DateTime.TryParse(m_strApplyTime, out dtApplyTime))
                {
                    if (m_blnIsTimeOutForQrery(dtApplyTime))
                    {
                        foreach (ToolStripMenuItem tsm in m_cmsEMRMenu.Items)
                        {
                            tsm.Enabled = false;
                        }
                    }
                    else
                    {
                        foreach (ToolStripMenuItem tsm in m_cmsEMRMenu.Items)
                        {
                            tsm.Enabled = true;
                        }
                    }
                }
            }
        }

        #region 打开医嘱
        private void m_mniDoctorOrder_Click(object sender, EventArgs e)
        {
            if (CurrentPatient == null)
				return;

            MDIParent.s_ObjCurrentPatient = CurrentPatient;
            if (clsEMR_StaticObject.s_StrCurrentHospitalNO == "450101001")//南宁
            {
                com.digitalwave.iCare.gui.HIS.frmDoctorOrder frmOrder = new com.digitalwave.iCare.gui.HIS.frmDoctorOrder();
                frmOrder.MdiParent = clsEMRLogin.s_FrmMDI;
                frmOrder.WindowState = FormWindowState.Maximized;
                frmOrder.Show();
                //frmOrder.m_mthGetSpecifyPatientForm(CurrentPatient.m_StrHISInPatientID);
                frmOrder.m_mthSetIfCanSelectPatient(false);
            }
            else if (clsEMR_StaticObject.s_StrCurrentHospitalNO == "440104001")//市一
            {
                //Do later
            }
            else
            {
                com.digitalwave.iCare.BIHOrder.frmBIHOrderInput objBIHO = new com.digitalwave.iCare.BIHOrder.frmBIHOrderInput();

                if (new clsMainMenuFunction().m_blnCheckForFormOpen(objBIHO, false))
                    return;

                //objBIHO.LoginInfo = clsEMRLogin.LoginInfo;
                //objBIHO.m_mthSetCurrentPatient(MDIParent.s_ObjCurrentPatient.m_StrInPatientID);
                //objBIHO.MdiParent = clsEMRLogin.s_FrmMDI;
                
                objBIHO.m_mthShow("3");
            }
        } 
        #endregion

        #region 设置ctlRichTextBox属性
        private void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
        {
            m_mthAddRichTemplate(m_txtConsultationIdea);
            m_mthAddRichTextInfo(m_txtConsultationIdea);
        }

        private void m_mthAddRichTemplate(RichTextBox p_txtControl)
        {
            m_objTempTool.m_mthAddTextBox(this, p_txtControl, "", p_txtControl.Name);
        }

        protected void m_mthAddRichTextInfo(Control p_ctlTextBox)
        {
            if (p_ctlTextBox.Name == "m_txtConsultationIdea")
            {
                m_txtConsultationIdea.m_evtMouseEnterDeleteText += new EventHandler(m_mthHandleMouseEnterDeleteText);
                m_txtConsultationIdea.m_evtMouseEnterInsertText += new EventHandler(m_mthHandleMouseEnterInsertText);
                m_txtConsultationIdea.MouseLeave += new EventHandler(m_mthHandleMouseLeaveControl);
                int intCanModifyTime = 6;
                if (int.TryParse(clsEMRLogin.StrCanModifyTime, out intCanModifyTime))
                {
                    m_txtConsultationIdea.m_IntCanModifyTime = intCanModifyTime;
                }
                else
                {
                    m_txtConsultationIdea.m_IntCanModifyTime = 6;
                }
            }
        }

        private void m_mthHandleMouseLeaveControl(object p_objSender, EventArgs p_objArg)
        {
            m_ttpTextInfo.RemoveAll();
        }

        private readonly DateTime m_dtmEmptyDate = new DateTime(1900, 1, 1);
        private void m_mthHandleMouseEnterDeleteText(object p_objSender, EventArgs p_objArg)
        {
            string strName = "";
            DateTime dtmDeleteTime = DateTime.MinValue;
            if (p_objArg is com.digitalwave.controls.clsDoubleStrikeThoughEventArg)
            {
                com.digitalwave.controls.clsDoubleStrikeThoughEventArg objarg = p_objArg as com.digitalwave.controls.clsDoubleStrikeThoughEventArg;
                strName = objarg.m_strUserName;
                dtmDeleteTime = objarg.m_dtmDeleteTime;
            }

            string strInfo = "用户姓名 : " +
                strName + "\r\n删除时间 : ";

            if (dtmDeleteTime != m_dtmEmptyDate && dtmDeleteTime != DateTime.MinValue)
            {
                strInfo += dtmDeleteTime.ToLongDateString() + " " + dtmDeleteTime.ToLongTimeString();
            }
            else
            {
                strInfo += "----年--月--日 --:--:--";
            }

            m_ttpTextInfo.SetToolTip((Control)p_objSender, strInfo);
        }

        private void m_mthHandleMouseEnterInsertText(object p_objSender, EventArgs p_objArg)
        {
            string strName = "";
            DateTime dtmInsertTime = DateTime.MinValue;
            int intUserSeq = -1;
            if (p_objArg is com.digitalwave.controls.clsInsertEventArg)
            {
                com.digitalwave.controls.clsInsertEventArg objarg = p_objArg as com.digitalwave.controls.clsInsertEventArg;
                strName = objarg.m_strUserName;
                dtmInsertTime = objarg.m_dtmInsertTime;
                intUserSeq = objarg.m_intUserSeq;
            }

            if (intUserSeq == 1)
            {
                return;
            }

            string strInfo = "用户姓名 : " +
                strName + "\r\n添加时间 : ";

            if (dtmInsertTime != m_dtmEmptyDate && dtmInsertTime != DateTime.MinValue)
            {
                strInfo += dtmInsertTime.ToLongDateString() + " " + dtmInsertTime.ToLongTimeString();
            }
            else
            {
                strInfo += "----年--月--日 --:--:--";
            }

            m_ttpTextInfo.SetToolTip((Control)p_objSender, strInfo);
        }

        private void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
        {
            if (p_ctlControl.Name == "m_txtConsultationIdea")
            {
                m_txtConsultationIdea.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

                //设置其他属性			
                m_txtConsultationIdea.m_StrUserID = MDIParent.strOperatorID.Trim();
                m_txtConsultationIdea.m_StrUserName = MDIParent.strOperatorName.Trim();

                m_txtConsultationIdea.m_ClrOldPartInsertText = Color.Black;
                m_txtConsultationIdea.m_ClrDST = Color.Red;
            }
        }

        private Control m_txtFocusedRichTextBox = null;//存放当前获得焦点的RichTextBox
        private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
        {
            m_txtFocusedRichTextBox = ((Control)(sender));
        }
        #endregion
        

        #region PublicFunction 成员
        public void Copy()
        {
            Control ctlControl = this.ActiveControl;

            if (ctlControl.Name == "m_txtConsultationIdea")
            {
                m_txtConsultationIdea.Copy();
            }
        }

        public void Paste()
        {
            Control ctlControl = this.ActiveControl;

            if (ctlControl.Name == "m_txtConsultationIdea")
            {
                m_txtConsultationIdea.Paste();
            }
        }

        public void Save()
        {
            return;
        }

        public void Cut()
        {
            return;
        }

        public void Delete()
        {
            return;
        }

        public void Display(string cardno, string sendcheckdate)
        {
            return;
        }

        public void Display()
        {
            return;
        }

        public void Print()
        {
            return;
        }

        public void Redo()
        {
            return;
        }

        public void Undo()
        {
            return;
        }

        public void Verify()
        {
            return;
        }

        #endregion
    }
}
