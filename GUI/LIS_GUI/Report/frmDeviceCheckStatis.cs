using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// frmDeviceCheckStatis 的摘要说明
    /// baojian.mo Create
    /// </summary>
    public partial class frmDeviceCheckStatis : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmDeviceCheckStatis()
        {
            InitializeComponent();
        }

        private clsController_StatReport m_objController;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DateTime datStart = DateTime.Parse(this.m_dtpStartDat.Value.ToShortDateString() + " 00:00:00");
            DateTime datEnd = DateTime.Parse(this.m_dtpEndDat.Value.ToShortDateString() + " 23:59:59");
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.m_cboStatisType.Text == "")
                {
                    MessageBox.Show(this, "请先选择一个统计类型", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_cboStatisType.Focus();
                }
                else if (DateTime.Compare(this.m_dtpEndDat.Value, this.m_dtpStartDat.Value) < 0)
                {
                    MessageBox.Show(this, "起始日期不能大于结束日期", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (this.m_cboStatisType.Text == "仪器工作量统计")
                {
                    DataTable dtDevice = null;
                    this.m_objController.m_mthGetDeviceCheckTotal(datStart, datEnd, ref dtDevice);
                    if (dtDevice.Rows.Count > 0)
                    {
                        this.m_mthPreviewReport(dtDevice);
                    }
                    else
                    {
                        MessageBox.Show(this, "\r\n找到0个结果！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                { }
            }
            catch (Exception)
            {
                this.Cursor = Cursors.Default;
                throw;
            }
            this.Cursor = Cursors.Default;
        }

        private void frmDeviceCheckStatis_Load(object sender, EventArgs e)
        {
            m_objController = new clsController_StatReport();
            this.m_cboStatisType.SelectedIndex = 0;
            m_mthInitReport("0");
            foreach (System.Windows.Forms.Control obj in this.panel1.Controls)
            {
                if (obj.AccessibleName != null)
                {
                    obj.KeyPress += new KeyPressEventHandler(m_mthEnter2Tab);
                }
            }
        }

        private void m_mthEnter2Tab(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void m_mthPreviewReport(DataTable p_dtResult)
        {
            dwReport.Reset();
            dwReport.SetRedrawOff();
            dwReport.Modify("t_7.text = '" + this.m_dtpStartDat.Value.ToString("yyy.MM.dd") + "'");
            dwReport.Modify("t_9.text = '" + this.m_dtpEndDat.Value.ToString("yyyy.MM.dd") + "'");
            dwReport.Modify("t_operator.text = '" + this.LoginInfo.m_strEmpName + "'");
            dwReport.Retrieve(p_dtResult);
            dwReport.SetRedrawOn();
            dwReport.Refresh();
        }

        private void m_mthInitReport(string strFlag)
        {
            switch (strFlag.Trim())
            {
                case "0":
                    dwReport.LibraryList = Application.StartupPath + "\\pbreport.pbl";
                    dwReport.DataWindowObject = "d_opr_lis_devicestatis";
                    int NewRow = dwReport.InsertRow(0);
                    break;
                default:
                    break;
            };
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.dwReport.DataWindowObject))
            {
                this.dwReport.Print(false);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwReport.PrintProperties.Preview = !this.dwReport.PrintProperties.Preview;
        }
    }
}