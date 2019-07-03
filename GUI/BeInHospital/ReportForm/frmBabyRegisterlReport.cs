using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class  frmBabyRegisterlReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        clsDcl_Report m_objManage;
        /// <summary>
        /// 报表文档,用于读入水晶报表
        /// </summary>
        ReportDocument m_repotDoc;
        private string strStartPatch = "";
        public frmBabyRegisterlReport()
        {
            InitializeComponent();
            m_objManage = new clsDcl_Report();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DataTable p_dtbResult;
                long lngRes = m_objManage.m_lngBabyRegisterReport((string)m_txtAREAID_CHR.Tag,m_dtFromTime.Value.Date, m_dtToTime.Value.AddDays(1).Date, out p_dtbResult);
                m_repotDoc = new ReportDocument();
                m_repotDoc.Load(strStartPatch + "\\report\\rptBabyRegister.rpt");
                m_repotDoc.SetDataSource(p_dtbResult);
                ((TextObject)m_repotDoc.ReportDefinition.ReportObjects["m_labDateTime"]).Text = m_dtFromTime.Value.ToShortDateString() + " 至 " + m_dtToTime.Value.ToShortDateString();
                ((TextObject)m_repotDoc.ReportDefinition.ReportObjects["m_labArea"]).Text = m_txtAREAID_CHR.Text;
                ((TextObject)m_repotDoc.ReportDefinition.ReportObjects["m_labMan"]).Text = LoginInfo.m_strEmpName;
                m_crystalReportViewer.ReportSource = m_repotDoc;
            }
            catch (EvaluateException ex)
            {
                MessageBox.Show(ex.Message, "获取报表数据", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #region 加载病区列表
        private void frmBabyRegisterlReport_Shown(object sender, EventArgs e)
        {
            clsListViewColumns_VO[] m_objColumnsArr = new clsListViewColumns_VO[]{
                new clsListViewColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                new clsListViewColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsListViewColumns_VO("名称","deptname_vchr",HorizontalAlignment.Left,70)
            };
            m_txtAREAID_CHR.m_mthInitListView(m_objColumnsArr);
            m_txtAREAID_CHR.m_strSQL = @"SELECT   '0' AS deptid_chr, '全院' AS deptname_vchr, 'QY' AS pycode_chr,
         '0' AS code_vchr
    FROM DUAL
UNION ALL
SELECT   deptid_chr, deptname_vchr, pycode_chr, code_vchr
    FROM t_bse_deptdesc t1
   WHERE TRIM (attributeid) = '0000003' AND status_int = 1
ORDER BY code_vchr";
            m_txtAREAID_CHR.m_mthGetData();
            m_txtAREAID_CHR.Tag = "0";
            m_txtAREAID_CHR.Text = "全院";
        }
        #endregion

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBabyRegisterlReport_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                                    if (MessageBox.Show("是否确定退出", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.None) == DialogResult.Yes)
                    {
                        this.Close();
                    }
            }
        }

        private void frmBabyRegisterlReport_Load(object sender, EventArgs e)
        {
            this.strStartPatch = Application.StartupPath;
        }
    }
}