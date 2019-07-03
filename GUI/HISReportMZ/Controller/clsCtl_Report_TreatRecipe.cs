using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 门诊药房配药工作量统计报表
    /// </summary>
    public class clsCtl_Report_TreatRecipe : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_Report_TreatRecipe m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmTreatRecipeReport m_objViewer = null;
        /// <summary>
        /// 配药员工ID
        /// </summary>
        private string p_strTreatEmp;
        /// <summary>
        /// 药房ID
        /// </summary>
        private string p_strMedstoreid;
        /// <summary>
        /// 配药员工数据表

        /// </summary>
        private DataTable m_dtData = null;
        /// <summary>
        /// 配药信息返回数据
        /// </summary>
        private DataTable m_dtbResult;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_Report_TreatRecipe()
		{
            m_objDomain = new clsDcl_Report_TreatRecipe();
		}
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmTreatRecipeReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 配药处方信息
        /// <summary>
        /// 配药处方信息
        /// </summary>
        public void m_mthSelectTreatRecipe()
        {
            long lngRes = 0;
            p_strMedstoreid = this.m_objViewer.m_strDrugStoreID;
            if (this.m_objViewer.m_ctbEmpList.txtValuse.ToString() == "" || this.m_objViewer.m_ctbEmpList.txtValuse == null)
            {
                p_strTreatEmp = "10000";
            }
            else
            {
                string m_strTag = "";
                bool m_blnExist = false;
                string m_strEmpValuse = m_objViewer.m_ctbEmpList.txtValuse.ToString().Trim();
                for (int iExist = 0; iExist < m_dtData.Rows.Count; iExist++)
                {
                    if (m_dtData.Rows[iExist]["姓    名"].ToString().Equals(m_strEmpValuse))
                    {
                        m_blnExist = true;
                        m_strTag = m_dtData.Rows[iExist]["员工ID"].ToString();
                    }
                }
                if (m_blnExist)
                {
                    p_strTreatEmp = m_strTag;
                }
                else
                {
                    p_strTreatEmp = "0000000";
                }
            }
            DateTime p_dtpBegin = this.m_objViewer.m_dtpBegin.Value;
            DateTime p_dtpEnd = this.m_objViewer.m_dtpEnd.Value;
            lngRes = this.m_objDomain.m_lngSelectTreatRecipe(p_dtpBegin, p_dtpEnd,p_strMedstoreid,p_strTreatEmp,m_objViewer.m_intMedicineType, out m_dtbResult);
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvTreatRecipe.DataSource = m_dtbResult;

                this.m_objViewer.m_dwReport.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_OP.pbl";
                this.m_objViewer.m_dwReport.SetRedrawOff();
                this.m_objViewer.m_dwReport.Modify("begindatetext.text='" + this.m_objViewer.m_dtpBegin.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.m_dwReport.Modify("enddatetext.text='" + this.m_objViewer.m_dtpEnd.Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.m_dwReport.Modify("medicinename.text='" + this.m_objViewer.m_cboMedStore.SelectItemText.ToString() + "'");
                this.m_objViewer.m_dwReport.Retrieve(m_dtbResult);
                this.m_objViewer.m_dwReport.SetRedrawOn();
                this.m_objViewer.m_dwReport.Refresh();
            }
        }
        #endregion

        #region 获取药房名称
        /// <summary>
        /// 获取药房名称
        /// </summary>
        /// <param name="m_objTable"></param>
        public long m_mthGetTreatRecipe(out DataTable m_objTable)
        {
            long lngRes = 0;
            lngRes = this.m_objDomain.m_lngGetTreatRecipe(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 导出报表
        /// <summary>
        /// 导出报表
        /// </summary>
        public void m_mthExploreData()
        {
            //if (this.m_objViewer.m_dwReport.RowCount > 0)
            //{
            //    SaveFileDialog FD = new SaveFileDialog();
            //    FD.Filter = "Excel 文档|*.xls";
            //    FD.Title = "导出";
            //    FD.ShowDialog();
            //    if (FD.FileName.Trim() != "")
            //    {
            //        this.m_objViewer.m_dwReport.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
            //    }
            //}
            if (this.m_objViewer.m_dgvTreatRecipe.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_objViewer.m_dgvTreatRecipe);
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void m_mthPrint()
        {
            com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.m_objViewer.m_dwReport,true);
        }
        #endregion

        #region 配药员工数据
        /// <summary>
        /// 配药员工数据
        /// </summary>
        internal void m_mthGetEmpData()
        {
            //string strMedNameid = this.m_objViewer.m_cboMedStore.SelectItemValue.ToString();
            DataTable m_objResult = null;
            long lngRes = 0;
            lngRes = this.m_objDomain.m_mthGetSendEmp(m_objViewer.m_strDrugStoreID, out m_objResult);

            if (lngRes > 0 && m_objResult.Rows.Count > 0)
            {
                m_dtData = new DataTable();
                m_dtData.Columns.Add("员 工 号");
                m_dtData.Columns.Add("姓    名");
                m_dtData.Columns.Add("员工ID");
                DataRow m_newRow = null;
                //m_newRow = m_dtData.NewRow();
                //m_newRow["员 工 号"] = "0000";
                //m_newRow["姓    名"] = "全部";
                //m_newRow["员工ID"] = "10000";
                //m_dtData.Rows.Add(m_newRow);
                DataRow m_dr = null;
                for (int iRow = 0; iRow < m_objResult.Rows.Count; iRow++)
                {
                    m_dr = m_objResult.Rows[iRow];
                    m_newRow = m_dtData.NewRow();
                    m_newRow["员 工 号"] = m_dr["empno_chr"].ToString();
                    m_newRow["姓    名"] = m_dr["lastname_vchr"].ToString();
                    m_newRow["员工ID"] = m_dr["empid_chr"].ToString();
                    m_dtData.Rows.Add(m_newRow);
                }
                m_dtData.AcceptChanges();
                this.m_objViewer.m_ctbEmpList.m_GetDataTable = m_dtData;
            }
        }
        #endregion

        internal long m_lngGetMedicineType(string p_strDrugStoreID, out int m_intMedicineType)
        {
            return this.m_objDomain.m_lngGetMedicineType(p_strDrugStoreID, out m_intMedicineType);
        }
    }
}
