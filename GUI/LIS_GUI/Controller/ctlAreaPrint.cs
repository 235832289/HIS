using System;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Collections.Generic;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.LIS
{
    public class ctlAreaPrint : com.digitalwave.GUI_Base.clsController_Base
    {
        #region override

        private frmAreaPrint viewer { get; set; }

        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.viewer = (frmAreaPrint)frmMDI_Child_Base_in;
        }

        #endregion

        #region 变量

        string DeptIdArr { get; set; }

        bool IsChecked { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        internal void Init()
        {
            viewer.txtDeptName.Text = viewer.LoginInfo.m_strInpatientAreaName;
            viewer.txtDeptName.ReadOnly = true;
            viewer.btnDept.Enabled = true; //viewer.LoginInfo.m_strEmpNo == "0001" ? true : false;
            viewer.txtIpNo.Text = string.Empty;
            this.DeptIdArr = viewer.LoginInfo.m_strInpatientAreaID;

            foreach (string item in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                viewer.cboPrinter.Items.Add(item);
            }
            if (viewer.cboPrinter.Items.Count > 0)
            {
                viewer.cboPrinter.SelectedIndex = 0;
            }
        }
        #endregion

        #region ChooseDepts
        /// <summary>
        /// ChooseDepts
        /// </summary>
        internal void ChooseDepts()
        {
            frmAidChooseDept fDept = new frmAidChooseDept();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIdArr = fDept.DeptIDArr;
            }
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        internal void Query()
        {
            try
            {
                clsPublic.PlayAvi("正在查询报告单，请稍候...");
                viewer.dataGridView.Rows.Clear();
                viewer.dataGridView.Refresh();
                clsDomainController_ApplicationManage domain = new clsDomainController_ApplicationManage();
                if (this.DeptIdArr.IndexOf(",") < 0)
                {
                    this.DeptIdArr = this.DeptIdArr.Replace("'", "");
                }
                DataTable dt = domain.QueryAreaReport(this.DeptIdArr, viewer.dteRq1.Value.ToString("yyyy-MM-dd"), viewer.dteRq2.Value.ToString("yyyy-MM-dd"), viewer.txtIpNo.Text.Trim());
                domain = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    string itemName = string.Empty;
                    string reportGroupId = string.Empty;
                    string applicationId = string.Empty;
                    DataTable dtData = new DataTable();
                    dtData.Columns.Add("bedNo", typeof(string));
                    dtData.Columns.Add("ipNo", typeof(string));
                    dtData.Columns.Add("barCode", typeof(string));
                    dtData.Columns.Add("patName", typeof(string));
                    dtData.Columns.Add("sex", typeof(string));
                    dtData.Columns.Add("age", typeof(string));
                    dtData.Columns.Add("name", typeof(string));
                    dtData.Columns.Add("appDate", typeof(string));
                    dtData.Columns.Add("rptDate", typeof(string));
                    dtData.Columns.Add("rptGroupId", typeof(string));
                    dtData.Columns.Add("applicationId", typeof(string));
                    foreach (DataRow dr in dt.Rows)
                    {
                        itemName = dr["name_vchr"].ToString();
                        reportGroupId = dr["report_group_id_chr"].ToString();
                        applicationId = dr["application_id_chr"].ToString();
                        DataRow[] drr = dtData.Select("rptGroupId = '" + reportGroupId + "' and applicationId = '" + applicationId + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            drr[0]["name"] += "," + itemName;
                        }
                        else
                        {
                            DataRow drData = dtData.NewRow();
                            drData["bedNo"] = dr["bedno_chr"].ToString();
                            drData["ipNo"] = dr["patient_inhospitalno_chr"].ToString();
                            drData["barCode"] = dr["barcode_vchr"].ToString();
                            drData["patName"] = dr["patient_name_vchr"].ToString();
                            drData["sex"] = dr["sex_chr"].ToString();
                            drData["age"] = dr["age_chr"].ToString();
                            drData["name"] = itemName;
                            drData["appDate"] = Convert.ToDateTime(dr["appl_dat"]).ToString("yyyy-MM-dd HH:mm");
                            drData["rptDate"] = Convert.ToDateTime(dr["report_dat"]).ToString("yyyy-MM-dd HH:mm");
                            drData["rptGroupId"] = reportGroupId;
                            drData["applicationId"] = applicationId;
                            dtData.BeginLoadData();
                            dtData.LoadDataRow(drData.ItemArray, true);
                            dtData.EndLoadData();
                        }
                    }

                    int n = -1;
                    int no = 0;
                    string[] arr = null;
                    foreach (DataRow dr in dtData.Rows)
                    {
                        n = -1;
                        arr = new string[13];
                        arr[++n] = Convert.ToString(++no);
                        arr[++n] = dr["bedNo"].ToString();
                        arr[++n] = dr["ipNo"].ToString();
                        arr[++n] = dr["barCode"].ToString();
                        arr[++n] = dr["patName"].ToString();
                        arr[++n] = dr["sex"].ToString();
                        arr[++n] = dr["age"].ToString();
                        arr[++n] = dr["name"].ToString();
                        arr[++n] = "";  // dr["apply_unit_id_chr"].ToString();
                        arr[++n] = dr["appDate"].ToString();
                        arr[++n] = dr["rptDate"].ToString();
                        arr[++n] = dr["rptGroupId"].ToString();
                        arr[++n] = dr["applicationId"].ToString();
                        viewer.dataGridView.Rows.Add(arr);
                    }
                    viewer.dataGridView.Refresh();
                }
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        internal void Print()
        {
            if (viewer.dataGridView.RowCount == 0) return;
            if (this.viewer.cboPrinter.Text == string.Empty)
            {
                MessageBox.Show("请选择打印机");
                return;
            }
            bool isPrint = false;
            string reportGroupId = string.Empty;
            string applicationId = string.Empty;
            List<string> lstReportGroupId = new List<string>();
            clsPrintReport print = new clsPrintReport();
            for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
            {
                if (viewer.dataGridView.Rows[i].Selected)
                {
                    reportGroupId = viewer.dataGridView.Rows[i].Cells["reportgroupid"].Value.ToString();
                    applicationId = viewer.dataGridView.Rows[i].Cells["applicationId"].Value.ToString();
                    if (lstReportGroupId.IndexOf(reportGroupId + applicationId) < 0)
                    {
                        lstReportGroupId.Add(reportGroupId + applicationId);
                    }
                    else
                    {
                        continue;
                    }
                    print.m_mthGetPrintContentFromDB(reportGroupId, applicationId, true);
                    print.m_mthPrint(this.viewer.cboPrinter.Text);
                    isPrint = true;
                }
            }
            if (isPrint == false)
            {
                MessageBox.Show("请选择需要打印的的检验报告记录.");
            }
        }
        #endregion

        #region 选择
        /// <summary>
        /// 选择
        /// </summary>
        internal void Choose()
        {
            if (viewer.dataGridView.RowCount == 0) return;
            IsChecked = !IsChecked;
            for (int i = 0; i < viewer.dataGridView.Rows.Count; i++)
            {
                viewer.dataGridView.Rows[i].Selected = true;
            }
        }
        #endregion

        #endregion

    }
}
