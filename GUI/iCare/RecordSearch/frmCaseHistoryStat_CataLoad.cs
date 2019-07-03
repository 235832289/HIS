using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;
using iCare.iCareBaseForm;

namespace iCare
{
    public partial class frmCaseHistoryStat_CataLoad : frmBaseForm
    {
        #region 构造方法
        /// <summary>
        /// 编目工作量统计
        /// </summary>
        public frmCaseHistoryStat_CataLoad()
        {
            InitializeComponent();
        } 
        #endregion

        #region 统计按钮Click事件
        private void m_cmdStat_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string strResult = "0";
                long lngRes = 0;
                DateTime dtBegin = Convert.ToDateTime(m_dtpOutDate1.Value.ToString("yyyy-MM-dd"));
                DateTime dtEnd = Convert.ToDateTime(m_dtpOutDate2.Value.ToString("yyyy-MM-dd"));
                clsCaseHistorySearchDomain objDomain = new clsCaseHistorySearchDomain();

                lngRes = objDomain.m_lngGetCatalogCaseNum(dtBegin, dtEnd, out strResult);
                m_lblCatalogCase.Text = strResult;

                lngRes = objDomain.m_lngGetVipPatientNum(dtBegin, dtEnd, out strResult);
                m_lblVIPCase.Text = strResult;

                lngRes = objDomain.m_lngGetDeadCaseNum(dtBegin, dtEnd, out strResult);
                m_lblDeadCase.Text = strResult;

                lngRes = objDomain.m_lngCatalogDiagDict(dtBegin, dtEnd, out strResult);
                m_lblCatalogDiag.Text = strResult;

                lngRes = objDomain.m_lngGetCatalogOpNum(dtBegin, dtEnd, out strResult);
                m_lblCatalogOp.Text = strResult;

                lngRes = objDomain.m_lngNewOpDict(dtBegin, dtEnd, out strResult);
                m_lblNewOp.Text = strResult;

                lngRes = objDomain.m_lngNewDiagDict(dtBegin, dtEnd, out strResult);
                m_lblNewDiag.Text = strResult;

                if (m_chkDetailStat.Checked)
                {
                    lngRes = objDomain.m_lngGetCatalogOpTypeNum(dtBegin, dtEnd, out strResult);
                    m_lblCatalogOpType.Text = strResult;

                    lngRes = objDomain.m_lngCatalogDiagTypeDict(dtBegin, dtEnd, out strResult);
                    m_lblCatalogDiagType.Text = strResult;
                    long lngDiagType = 0;
                    try
                    {
                        lngDiagType = Convert.ToInt64(strResult);
                    }
                    catch
                    {
                        lngDiagType = 0;
                    }

                    lngRes = objDomain.m_lngCatalogSpecifyDiagTypeDict(dtBegin, dtEnd, "M", out strResult);
                    m_lblCatalogMDiag.Text = strResult;
                    long lngDiagMType = 0;
                    try
                    {
                        lngDiagMType = Convert.ToInt64(strResult);
                    }
                    catch
                    {
                        lngDiagMType = 0;
                    }

                    lngRes = objDomain.m_lngCatalogSpecifyDiagTypeDict(dtBegin, dtEnd, "V", out strResult);
                    m_lblCatalogVDiag.Text = strResult;
                    long lngDiagVType = 0;
                    try
                    {
                        lngDiagVType = Convert.ToInt64(strResult);
                    }
                    catch
                    {
                        lngDiagVType = 0;
                    }

                    lngRes = objDomain.m_lngCatalogSpecifyDiagTypeDict(dtBegin, dtEnd, "E", out strResult);
                    m_lblCatalogEDiag.Text = strResult;
                    long lngDiagEType = 0;
                    try
                    {
                        lngDiagEType = Convert.ToInt64(strResult);
                    }
                    catch
                    {
                        lngDiagEType = 0;
                    }

                    m_lblDieaseType.Text = (lngDiagType - (lngDiagMType + lngDiagVType + lngDiagEType)).ToString();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region 清空界面
        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            m_mthClearUI();
        } 
        #endregion

        #region 关闭窗体
        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 置窗体的各个控件为初始状态
        /// <summary>
        /// 置窗体的各个控件为初始状态
        /// </summary>
        private void m_mthClearUI()
        {
            m_dtpOutDate1.Value = DateTime.Now;
            m_dtpOutDate2.Value = DateTime.Now;
            m_chkDetailStat.Checked = false;
            m_lblCatalogCase.Text = "";
            m_lblVIPCase.Text = "";
            m_lblDeadCase.Text = "";
            m_lblCatalogOp.Text = "";
            m_lblCatalogOpType.Text = "";
            m_lblNewOp.Text = "";
            m_lblCatalogDiag.Text = "";
            m_lblCatalogDiagType.Text = "";
            m_lblCatalogMDiag.Text = "";
            m_lblCatalogVDiag.Text = "";
            m_lblCatalogEDiag.Text = "";
            m_lblDieaseType.Text = "";
            m_lblNewDiag.Text = "";
        } 
        #endregion

        #region 窗体Load事件
        private void frmCaseHistoryStat_CataLoad_Load(object sender, EventArgs e)
        {
            m_mthClearUI();
        } 
        #endregion
    }
}