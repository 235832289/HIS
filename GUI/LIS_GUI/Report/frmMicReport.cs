using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using com.digitalwave.iCare.gui.HIS;


namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmMicReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
       
        public frmMicReport()
        {
            InitializeComponent();
        }
        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsController_MicReport m_objController;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.LIS.clsController_MicReport();
            m_objController = (clsController_MicReport)m_objController;
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmMicReport_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInti();
            this.dwResult.LibraryList = Application.StartupPath + "\\pb_lis.pbl";
            this.m_cboCondition.SelectedIndex = 0;
            
        }

        private void m_cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int intTem = this.m_cboCondition.SelectedIndex;
            if (intTem == 0)
            {
                m_objController.strQuery = 0;
                this.dwResult.DataWindowObject = "d_lis_atb_micdistributiontendency";
            }
            if (intTem == 1)
            {
                m_objController.strQuery = 1;
                this.dwResult.DataWindowObject = "d_lis_atb_s_rate";
            }
            if (intTem == 2)
            {
                m_objController.strQuery = 2;
                this.dwResult.DataWindowObject = "d_lis_atb_sensitivetend";
            }
            if (intTem == 3)
            {
                m_objController.strQuery = 3;
                this.dwResult.DataWindowObject = "d_lis_atb_sensitivity";   
            }
            if (intTem == 4)
            {
                m_objController.strQuery = 4;
                this.dwResult.DataWindowObject = "d_lis_atb_miccumulative";
                
            }
            if (intTem == 5)
            {
                m_objController.strQuery = 5;
                this.dwResult.DataWindowObject = "d_lis_atb_bacdistribution";
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            btnCount.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.dwResult.Reset();
            m_objController.dtDateFrom = DateTime.Parse(m_dtpDatFrom.Value.ToString("yyyy-MM-dd 00:00:00"));
            m_objController.dtDateTo = DateTime.Parse(m_dtpDatTo.Value.ToString("yyyy-MM-dd 23:59:59"));
            m_objController.SamtNo = cbxSampleType.Text.Trim().ToString();
            if (cbxDistrict.Text != string.Empty)
            {
                m_objController.DisNo = cbxDistrict.SelectedIndex.ToString();
            }
            else
            {
                m_objController.DisNo = null;
            }
            if (dgv_anti.Rows.Count > 1)
            {
                m_objController.strTempAntiID = dgv_anti.Rows[0].Cells[0].Value.ToString();
            }
            else
            {
                m_objController.strTempAntiID = null;
            }
           // m_objController.TestMethod = cbxTestMethod.Text.ToString();
            m_objController.TestMethod = null;
            m_objController.Sex = cbxSex.Text.ToString();
            m_objController.AgeFrom = txtAgeFrom.Text.ToString();
            m_objController.AgeTo = txtAgeTo.Text.ToString();
            try
            {
                switch (m_objController.strQuery)
                {
                    case 0:
                        m_objController.m_mthGetMicdistributiontend();
                        break;
                    case 1:
                        m_objController.m_mthGetSensitiveRate();
                        break;
                    case 2:
                        m_objController.m_mthGetSensitiveTend();
                        break;
                    case 3:
                        m_objController.m_mthGetMicSensitive();
                        break;
                    case 4:
                        m_objController.m_mthGetMicCumulative();
                        break;
                    case 5:
                        m_objController.m_mthGetBacStatstic();
                        break;
                    default:
                        break;
                }
            }
            catch
            {
            }
            this.Cursor = Cursors.Default;
            btnCount.Enabled = true;

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            cmdExport.Enabled = false;
            
            try
            {
                if (dwResult == null || dwResult.RowCount <= 0)
                {
                    cmdExport.Enabled = true;
                    return;
                }

                this.sfdSave.ShowDialog();
                sfdSave.AddExtension = true;

                if (sfdSave.FileName == null)
                {
                    cmdExport.Enabled = true;
                    MessageBox.Show("文件名不能为空！");
                    return;
                }
                this.dwResult.SaveAs(sfdSave.FileName, Sybase.DataWindow.FileSaveAsType.Excel);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            cmdExport.Enabled = true;
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dwResult == null || dwResult.RowCount < 0)
            {
                return;
            }
            com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.dwResult, false);
        }

        private void m_rdbAll_CheckedChanged(object sender, EventArgs e)
        {
           this.tabContorl.Visible = false;
           this.dgv_anti.Rows.Clear();
        }

        private void m_rdbAnti_CheckedChanged(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择的抗生素";
            m_objController.m_mthListAnti();
        }

        private void m_rdbAllMic_CheckedChanged(object sender, EventArgs e)
        {
          this.tabContorl.Visible = false;
          this.dgv_mic.Rows.Clear();
        }

        private void m_rdbMic_CheckedChanged(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择的细菌";
            m_objController.m_mthListMic();
        }

        private void dgvItem_DoubleClick(object sender, EventArgs e)
        {
            
            if (this.dgvItem.CurrentRow != null)
            {
                {
                    object[] value = new object[dgvItem.Columns.Count];
                    for (int i = 0; i < dgvItem.Columns.Count; i++)
                    {
                        value[i] = dgvItem.CurrentRow.Cells[i].Value;
                    }
                    if (this.tabContorl.SelectedTab.Text == "选择的抗生素")
                    {
                        dgv_anti.Rows.Clear();
                        dgv_anti.Rows.Add(value);
                    }
                    else
                    {
                        dgv_mic.Rows.Clear();
                        dgv_mic.Rows.Add(value);
                    }
                }
            }

            this.tabContorl.Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = false;
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            if (this.tabContorl.SelectedTab.Text == "选择的抗生素")
            {
                m_objController.m_mthtxtChangeQueryAnti();
            }
            else
            {
                m_objController.m_mthtxtChangeQueryMic();
            }
        }

        private void m_rdbMic_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择的细菌";
            m_objController.m_mthListMic();
        }

        private void m_rdbAnti_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = true;
            this.tabContorl.SelectedTab.Text = "选择的抗生素";
            m_objController.m_mthListAnti();
        }
 
        private void btnPreview_Click(object sender, EventArgs e)
        {

            this.dwResult.PrintProperties.Preview = !this.dwResult.PrintProperties.Preview;
            this.dwResult.PrintProperties.ShowPreviewRulers = this.dwResult.PrintProperties.Preview;
        }
    
    }
}