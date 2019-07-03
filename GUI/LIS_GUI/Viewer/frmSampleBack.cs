using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 标本反馈窗体层
    /// </summary>
    public partial class frmSampleBack : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 控制层
        /// </summary>
        clsCtl_SampleBack m_objController;
        DataTable m_dtSampleBack = null;
        DataTable m_dtResult = null;
        #endregion

        #region 构造函数
        public frmSampleBack()
        {
            InitializeComponent();
        }
        public override void CreateController()
        {
            m_objController = new clsCtl_SampleBack();
            this.objController = m_objController;
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            m_dgSampleBack.DataSource = null;
            string m_strFromDate = m_dtFromDate.Value.ToString("yyyy-MM-dd 00:00:00");
            string m_strToDate = m_dtToDate.Value.ToString("yyyy-MM-dd 23:59:59");
            string m_strPatientName = m_txtPatientName.Text;
            string m_strInHospitalNO = m_txtInHospitalNo.Text;
            string m_strAppDeptID = m_txtAppDept.m_StrDeptID;
            long lngRes = m_objController.m_lngQuerySampleBack(m_strFromDate, m_strToDate, m_strPatientName, m_strInHospitalNO, m_strAppDeptID, out m_dtSampleBack);
            if (lngRes > 0 && m_dtSampleBack != null && m_dtSampleBack.Rows.Count > 0)
            {
                m_dgSampleBack.DataSource = m_dtSampleBack;
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            if (m_dtSampleBack == null || m_dtSampleBack.Rows.Count <= 0)
            {
                return;
            }
            m_dtResult.Rows.Clear();
            DataRow drTemp = null;
            DataRow drTemp2 = null;
            for (int i = 0; i < m_dtSampleBack.Rows.Count; i++)
            {
                drTemp = m_dtSampleBack.Rows[i];
                drTemp2 = m_dtResult.NewRow();
                drTemp2["日期"] = drTemp["feedback_date_date"].ToString().Trim();
                drTemp2["姓名"] = drTemp["patient_name_vchr"].ToString().Trim();
                drTemp2["住院号"] = drTemp["patient_inhospitalno_vchr"].ToString().Trim();
                drTemp2["床号"] = drTemp["bedno_chr"].ToString().Trim();
                drTemp2["科室"] = drTemp["deptname_vchr"].ToString().Trim();                
                drTemp2["条码号"] = drTemp["barCode"].ToString().Trim();
                drTemp2["检验内容"] = drTemp["checkContent"].ToString().Trim();
                drTemp2["拒收标本原因"] = drTemp["sample_back_reason_vchr"].ToString().Trim();
                m_dtResult.Rows.Add(drTemp2);
            }
            try
            {
                m_dwPrint.SetRedrawOff();
                m_dwPrint.Refresh();
                m_dwPrint.Retrieve(m_dtResult);
                if (m_dwPrint.RowCount > 0)
                {
                    m_dwPrint.Print();
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }

        private void frmSampleBack_Load(object sender, EventArgs e)
        {
            m_dgSampleBack.AutoGenerateColumns = false;
            m_dtResult = new DataTable();
            DataColumn[] drColumnArr = new DataColumn[] {new DataColumn("日期",typeof(string)),new DataColumn("姓名",typeof(string)),new DataColumn("住院号",typeof(string))
            ,new DataColumn("床号",typeof(string)),new DataColumn("科室",typeof(string)), new DataColumn("条码号",typeof(string)),new DataColumn("检验内容",typeof(string)), new DataColumn("拒收标本原因",typeof(string))};
            m_dtResult.Columns.AddRange(drColumnArr);
            m_dwPrint.LibraryList = Application.StartupPath + @"\pb_lis.pbl";
            m_dwPrint.DataWindowObject = "d_lis_sampleback";
        }

        private void m_btnExprot_Click(object sender, EventArgs e)
        {
            if (m_dtSampleBack == null || m_dtSampleBack.Rows.Count <= 0)
            {
                return;
            }
            m_dtResult.Rows.Clear();
            DataRow drTemp = null;
            DataRow drTemp2 = null;
            for (int i = 0; i < m_dtSampleBack.Rows.Count; i++)
            {
                drTemp = m_dtSampleBack.Rows[i];
                drTemp2 = m_dtResult.NewRow();
                drTemp2["日期"] = drTemp["feedback_date_date"].ToString().Trim();
                drTemp2["姓名"] = drTemp["patient_name_vchr"].ToString().Trim();
                drTemp2["住院号"] = drTemp["patient_inhospitalno_vchr"].ToString().Trim();
                drTemp2["床号"] = drTemp["bedno_chr"].ToString().Trim();
                drTemp2["科室"] = drTemp["deptname_vchr"].ToString().Trim();               
                drTemp2["条码号"] = drTemp["barCode"].ToString().Trim();
                drTemp2["检验内容"] = drTemp["checkContent"].ToString().Trim();
                drTemp2["拒收标本原因"] = drTemp["sample_back_reason_vchr"].ToString().Trim();
                m_dtResult.Rows.Add(drTemp2);
            }
            try
            {
                m_dwPrint.SetRedrawOff();
                m_dwPrint.Refresh();
                m_dwPrint.Retrieve(m_dtResult);

                com.digitalwave.iCare.gui.HIS.clsPublic.ExportDataWindow(m_dwPrint);

                //if (m_dwPrint.RowCount > 0)
                //{
                //    m_sfExport.ShowDialog();
                //    if (m_sfExport.FileName == null)
                //    {
                //        MessageBox.Show("文件名不能为空");
                //        Cursor.Current = Cursors.Default;
                //        return;
                //    }
                //    m_dwPrint.SaveAs(m_sfExport.FileName, Sybase.DataWindow.FileSaveAsType.Xml);
                //}
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }

        }

    }
}