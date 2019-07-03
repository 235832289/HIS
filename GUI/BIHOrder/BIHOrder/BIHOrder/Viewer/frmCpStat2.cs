using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmCpStat2 : Form
    {
        public frmCpStat2()
        {
            InitializeComponent();
        }

        DataTable PathDataSourceFilter { get; set; }

        #region Stat
        /// <summary>
        /// Stat
        /// </summary>
        void Stat()
        {
            string BeginDate = this.dteBegin.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteEnd.Value.ToString("yyyy-MM-dd");
            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtPathName.Tag == null)
            {
                MessageBox.Show("请选择统计的路径。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DataRow dr = txtPathName.Tag as DataRow;
            string d1 = this.dteBegin.Value.ToString("yyyy年MM月");
            string d2 = this.dteEnd.Value.ToString("yyyy年MM月");
            string title = string.Empty;        // "临床路径病例登记表";
            if (d1 == d2)
            {
                title = d1 + dr["cpname"].ToString() + "病例登记表";
            }
            else
            {
                title = d1 + "至" + d2 + dr["cpname"].ToString() + "病例登记表";
            }
            clsPublic.PlayAvi("findFILE.avi", "统计临床路径单病种统计报表，请稍候...");
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable dt = svc.GetCpStat2(BeginDate, EndDate, Convert.ToInt32(dr["cpid"].ToString()));
            dwRep.SetRedrawOff();
            dwRep.Modify("t_title.text = '" + title + "'");
            dwRep.Retrieve(dt);
            if (dwRep.RowCount == 0)
            {
                dwRep.InsertRow(0);
            }
            dwRep.SetRedrawOn();
            clsPublic.CloseAvi();
            this.dwRep.Refresh();
        }
        #endregion

        private void frmCpStat2_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_cp_stat2";
            this.dwRep.Reset();
            this.dwRep.InsertRow(0);
            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.Refresh();

            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable PathDataSource = svc.GetCpListByDeptCode("");
            if (PathDataSource != null && PathDataSource.Rows.Count > 0)
            {
                PathDataSourceFilter = PathDataSource.Clone();
                PathDataSourceFilter.BeginLoadData();
                List<string> lstCpId = new List<string>();
                foreach (DataRow dr in PathDataSource.Rows)
                {
                    if (lstCpId.IndexOf(dr["cpid"].ToString()) < 0)
                    {
                        lstCpId.Add(dr["cpid"].ToString());
                        PathDataSourceFilter.LoadDataRow(dr.ItemArray, true);
                    }
                }
                PathDataSourceFilter.EndLoadData();
            }
        }

        private void btnStat_Click(object sender, EventArgs e)
        {
            this.Stat();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPathName_DoubleClick(object sender, EventArgs e)
        {
            txtPathName.Text = "";
            SendKeys.Send("{ENTER}");
        }

        private void txtPathName_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            if (PathDataSourceFilter != null && PathDataSourceFilter.Rows.Count > 0)
            {
                foreach (DataRow dr in PathDataSourceFilter.Rows)
                {
                    ListViewItem lvi = lvwList.Items.Add(dr["cpid"].ToString());
                    lvi.SubItems.Add(dr["cpname"].ToString());
                    lvi.Tag = dr;
                }
            }
        }

        private void txtPathName_m_evtInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("路径编号", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("路径名称", 200, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 280;
        }

        private void txtPathName_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                txtPathName.Text = lviSelected.SubItems[1].Text;
                txtPathName.Tag = lviSelected.Tag;
            }
        }


    }
}
