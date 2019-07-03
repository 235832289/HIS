using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmQCReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private bool m_blnNew = false;
        private bool m_blnOK = false;

        private clsLisQCReportVO m_objReport;
        private int m_intQCBatchSeq;
        private string m_strBrokenRules;

        internal bool m_blIsDate = true;
        internal DateTime m_dtMonth;
        private clsTmdQCDataSmp m_objDomain = new clsTmdQCDataSmp();

        public string BrokenRules
        {
            set { m_strBrokenRules = value; }
        }

        public clsLisQCReportVO Report
        {
            get { return m_objReport; }
        }

        public frmQCReport()
        {
            InitializeComponent();
        }

        public frmQCReport(clsLisQCReportVO report)
        {
            InitializeComponent();
            this.m_objReport = report;
            this.m_dtMonth = report.m_dtReport;
            this.m_intQCBatchSeq = report.m_intQCBatchSeq;

        }
        public frmQCReport(int p_intQCBatchSeq)
        {
            InitializeComponent();
            this.m_intQCBatchSeq = p_intQCBatchSeq;
            this.m_blnNew = true;
        }

        public frmQCReport(int p_intQCBatchSeq, DateTime p_dtMonth)
        {
            InitializeComponent();
            this.m_intQCBatchSeq = p_intQCBatchSeq;
            this.m_dtMonth = p_dtMonth;
            this.m_blnNew = true;
        }

        #region == 一般设置 ==

        #region 快捷键设置

        #region m_mthShortCutKey
        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            if (p_eumKeyCode == Keys.Escape)
            {
                if (this.m_btnCancel.Enabled && this.m_btnCancel.Visible)
                {
                    this.m_btnCancel_Click(this.m_btnCancel, null);
                }
            }
        }
        #endregion

        #endregion

        #region  frm_KeyDown
        private void frm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            base.m_mthSetKeyTab(e);
        }
        #endregion

        #endregion

        #region frmQCReport_Load
        /// <summary>
        /// frmQCReport_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmQCReport_Load(object sender, EventArgs e)
        {
            //m_mthControlsDisplayVOValue(m_objReport);
            //if (this.m_blnNew)
            //{
            //    this.m_txtUnmatchedRule.Text = this.m_strBrokenRules;
            //}

            if (!this.m_blIsDate)
            {
                this.Text = "质控月报告";
                this.label8.Text = "报告月份";
                this.m_dtpReport.CustomFormat = "yyyy-MM";
                this.m_dtpReport.Value = Convert.ToDateTime(this.m_dtMonth.ToString("yyyy-MM"));
                this.m_dtpReport.Enabled = false;
            }
            else
            {
                this.Text = "质控报告";
                this.label8.Text = "报告日期";
                this.m_dtpReport.CustomFormat = "yyyy-MM-dd";
                this.m_dtpReport.Enabled = true;
            }
            this.m_mthControlsDisplayVOValue(this.m_objReport);
            if (this.m_blnNew)
            {
                this.m_txtUnmatchedRule.Text = this.m_strBrokenRules;
            }
        }
        #endregion

        #region  m_btnSave_Click
        /// <summary>
        /// m_btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            //long lngRes = 0;
            //clsLisQCReportVO var = null;

            //if (this.m_blnNew)
            //{//新增
            //    var = new clsLisQCReportVO();
            //    this.m_mthBindControlValueToObj(var);
            //    var.m_intSeq = DBAssist.NullInt;
            //    var.m_intQCBatchSeq = this.m_intQCBatchSeq;
            //    var.m_enmStatus = enmQCStatus.Natrural;

            //    lngRes = clsTmdQCReportSmp.s_object.m_lngInsert(var);
            //    if (lngRes > 0)
            //    {
            //        this.m_objReport = var;
            //        this.m_blnNew = false;
            //    }
            //}
            //else
            //{//修改
            //    var = new clsLisQCReportVO();
            //    this.m_objReport.m_mthCopyTo(var);
            //    this.m_mthBindControlValueToObj(var);

            //    lngRes = clsTmdQCReportSmp.s_object.m_lngUpdate(var);
            //    if (lngRes > 0)
            //    {
            //        var.m_mthCopyTo(this.m_objReport);
            //    }
            //}
            //if (lngRes <= 0)
            //{
            //    clsCommonDialog.m_mthShowDBError();
            //    return;
            //}
            //this.m_blnOK = true;
            //this.Close();

            long num = 0L;
            if (this.m_blnNew)
            {
                if (this.m_blIsDate)
                {
                    clsLisQCReportVO QCReportVO = new clsLisQCReportVO();
                    this.m_mthBindControlValueToObj(QCReportVO);
                    QCReportVO.m_intSeq = -2147483648;
                    QCReportVO.m_intQCBatchSeq = this.m_intQCBatchSeq;
                    QCReportVO.m_enmStatus = enmQCStatus.Natrural;
                    QCReportVO.m_intReportStats = 0;
                    num = this.m_objDomain.m_lngInsertQCReport(QCReportVO, out QCReportVO.m_intSeq);
                    if (num > 0L)
                    {
                        this.m_objReport = QCReportVO;
                        this.m_blnNew = false;
                    }
                }
                else
                {
                    clsLisQCReportVO QCReportVO = new clsLisQCReportVO();
                    this.m_mthBindControlValueToObj(QCReportVO);
                    QCReportVO.m_intSeq = -2147483648;
                    QCReportVO.m_intQCBatchSeq = this.m_intQCBatchSeq;
                    QCReportVO.m_enmStatus = enmQCStatus.Natrural;
                    QCReportVO.m_intReportStats = 1;
                    num = this.m_objDomain.m_lngInsertQCReport(QCReportVO, out QCReportVO.m_intSeq);
                    if (num > 0L)
                    {
                        this.m_objReport = QCReportVO;
                        this.m_blnNew = false;
                    }
                }
            }
            else
            {
                clsLisQCReportVO QCReportVO = new clsLisQCReportVO();
                this.m_objReport.m_mthCopyTo(QCReportVO);
                this.m_mthBindControlValueToObj(QCReportVO);
                QCReportVO.m_intReportStats = this.m_objReport.m_intReportStats;
                num = this.m_objDomain.m_lngUpdateQCReport(QCReportVO);
                if (num > 0L)
                {
                    QCReportVO.m_mthCopyTo(this.m_objReport);
                }
            }
            if (num <= 0L)
            {
                clsCommonDialog.m_mthShowDBError();
            }
            else
            {
                this.m_blnOK = true;
                this.Close();
            }
        }
        #endregion

        #region m_mthControlsDisplayVOValue
        /// <summary>
        /// m_mthControlsDisplayVOValue
        /// </summary>
        /// <param name="objReport"></param>
        private void m_mthControlsDisplayVOValue(clsLisQCReportVO objReport)
        {
            if (objReport != null)
            {
                m_lblBatchNO.Text = DBAssist.ToString(objReport.m_intQCBatchSeq);
                this.m_chkLost.Checked = objReport.m_enmQCControlStatus == enmQCControlStatus.Control ? false : true;
                m_txtAppDoct.m_StrEmployeeID = objReport.m_strReportorId;
                m_txtUnmatchedRule.Text = objReport.m_strUnmatchedRule;
                m_txtReason.Text = objReport.m_strReason;
                m_txtProcess.Text = objReport.m_strProcess;
                m_txtSummary.Text = objReport.m_strSummary;
                m_dtpReport.Value = objReport.m_dtReport;
            }
        }
        #endregion

        #region m_mthBindControlValueToObj
        /// <summary>
        /// 控件赋值给Vo
        /// </summary>
        /// <param name="objRule">赋值的实例</param>
        private void m_mthBindControlValueToObj(clsLisQCReportVO objReport)
        {
            try
            {
                //objReport.m_intQCBatchSeq = int.Parse(m_lblBatchNO.Text);
                objReport.m_enmQCControlStatus = !this.m_chkLost.Checked ? enmQCControlStatus.Control : enmQCControlStatus.UnControl;
            }
            catch { }
            objReport.m_strReportorId = m_txtAppDoct.m_StrEmployeeID;
            objReport.m_strUnmatchedRule = m_txtUnmatchedRule.Text;
            objReport.m_strReason = m_txtReason.Text;
            objReport.m_strProcess = m_txtProcess.Text;
            objReport.m_strSummary = m_txtSummary.Text;
            objReport.m_dtReport = DateTime.Parse(m_dtpReport.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            objReport.m_strReportorName = m_txtAppDoct.m_StrEmployeeName;
        }
        #endregion

        #region frmQCReport_FormClosed
        private void frmQCReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.m_blnOK)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region m_cmdAddBrokenRules_Click
        private void m_cmdAddBrokenRules_Click(object sender, EventArgs e)
        {
            if (this.m_strBrokenRules != null)
            {
                this.m_txtUnmatchedRule.Text = this.m_strBrokenRules;
            }
        }

        #endregion

        #region m_btnCancel_Click
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}