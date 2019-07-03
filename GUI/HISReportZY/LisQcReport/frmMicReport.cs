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
using com.digitalwave.iCare.gui.HIS.Reports;


namespace com.digitalwave.iCare.gui.HIS
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
        private clsCtl_MicReport m_objController;

        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.HIS.clsCtl_MicReport();
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion

        private void frmMicReport_Load(object sender, EventArgs e)
        {
            m_objController.m_mthInti();
            this.m_cboCondition.SelectedIndex = 0;
            
        }

        private void m_cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTem = this.m_cboCondition.SelectedIndex;

            if (intTem == 0)//细菌分布趋势报告
            {
                m_objController.strQuery = 0;
                this.dgvMicdistributiontend.Visible = true;
                this.dgvSenRate.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = true;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
            if (intTem == 1)//----敏感率报告
            {
                m_objController.strQuery = 1;
                this.dgvSenRate.Visible = true;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = true;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
            if (intTem == 2)//----敏感率趋势报告
            {
                m_objController.strQuery = 2;
                this.dgvSensitiveTend.Visible = true;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = true;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
            if (intTem == 3)//累计敏感性报告
            {
                m_objController.strQuery = 3;
                this.dgvSensitiveRate.Visible = true;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = true;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
            if (intTem == 4)//累计MIC报告
            {
                m_objController.strQuery = 4;
                this.dgvMicCumulative.Visible = true;
                this.dgvXjfbbbg.Visible = true;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = true;
                this.lblBacStatstic.Visible = false;
                
            }
            if (intTem == 5)//细菌分布报告
            {
                m_objController.strQuery = 5; 
                this.dgvXjfbbbg.Visible = true;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = true;
            }
            if (intTem == 6)
            {
                m_objController.strQuery = 6;
                this.dgvSampleType.Visible = true;
                this.dgvDetail.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
            if (intTem == 7)
            {
                m_objController.strQuery = 7;
                this.dgvAntiByDept.Visible = true;
                this.dgvSampleType.Visible = false;
                this.dgvDetail.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
            if (intTem == 8)
            {
                m_objController.strQuery = 8;
                this.dgvDetail.Visible = true;
                this.dgvXjfbbbg.Visible = false;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;
                this.dgvSampleSum.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }

            if (intTem == 9)
            {
                m_objController.strQuery = 9;
                this.dgvSampleSum.Visible = true;
                this.dgvDetail.Visible = false;
                this.dgvXjfbbbg.Visible = false;
                this.dgvMicdistributiontend.Visible = false;
                this.dgvSenRate.Visible = false;
                this.dgvSensitiveRate.Visible = false;
                this.dgvMicCumulative.Visible = false;
                this.dgvSensitiveTend.Visible = false;
                this.dgvSampleType.Visible = false;
                this.dgvAntiByDept.Visible = false;

                this.lblMicdistributiontend.Visible = false;
                this.lblSensitiveRate.Visible = false;
                this.lblSensitiveTend.Visible = false;
                this.lblMicSensitive.Visible = false;
                this.lblMicCumulative.Visible = false;
                this.lblBacStatstic.Visible = false;
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            btnCount.Enabled = false;
            this.lblMicdistributiontend.Visible = false;
            this.lblSensitiveRate.Visible = false;
            this.lblSensitiveTend.Visible = false;
            this.lblMicSensitive.Visible = false;
            this.lblMicCumulative.Visible = false;
            this.lblBacStatstic.Visible = false;

            this.Cursor = Cursors.WaitCursor;
            m_objController.dtDateFrom = DateTime.Parse(m_dtpDatFrom.Value.ToString("yyyy-MM-dd 00:00:00"));
            m_objController.dtDateTo = DateTime.Parse(m_dtpDatTo.Value.ToString("yyyy-MM-dd 23:59:59"));
            m_objController.sampleId = cbxSampleType.Text.Trim().ToString();
            //m_objController.chkCritical = chkCritical.Checked == true ? "1": "0";
            if (rdoCriticalP.Checked == true)
                m_objController.CriticalStr = "1";
            if (rdoCriticalN.Checked == true)
                m_objController.CriticalStr = "0";
            if (rdoCriticalAll.Checked == true)
                m_objController.CriticalStr = string.Empty;

            if (rdoGlP.Checked == true)
                m_objController.GlFlgStr = "1";
            if (rdoGlN.Checked == true)
                m_objController.GlFlgStr = "0";
            if (rdoGlAll.Checked == true)
                m_objController.GlFlgStr = string.Empty;

            if (cbxDistrict.Text != string.Empty)
            {
                m_objController.DisNo = cbxDistrict.SelectedIndex.ToString();
            }
            else
            {
                m_objController.DisNo = null;
            }
            //if (dgv_anti.Rows.Count > 1)
            //{
            //    m_objController.strTempAntiID = dgv_anti.Rows[0].Cells[0].Value.ToString();
            //}
            //else
            //{
            //    m_objController.strTempAntiID = null;
            //}

            //if (this.dgvItem.Rows.Count > 1)
            //{
            //    m_objController.strTempAnti = dgv_anti.Rows[0].Cells[0].Value.ToString();
            //}
            //else
            //{
            //    m_objController.strTempAnti = null;
            //}

            m_objController.TestMethod = null;
            m_objController.Sex = cbxSex.Text.ToString();
            m_objController.AgeFrom = txtAgeFrom.Text.ToString();
            m_objController.AgeTo = txtAgeTo.Text.ToString();
            try
            {
                switch (m_objController.strQuery)
                {
                    case 0:
                        m_objController.m_mthGetMicdistributiontend();//细菌分布趋势报告
                        break;
                    case 1:
                        m_objController.m_mthGetSensitiveRate();//----敏感率报告
                        break;
                    case 2:
                        m_objController.m_mthGetSensitiveTend();//----敏感率趋势报告
                        break;
                    case 3:
                        m_objController.m_mthGetMicSensitive();//累计敏感性报告
                        break;
                    case 4:
                        m_objController.m_mthGetMicCumulative();//累计MIC报告
                        break;
                    case 5:
                        m_objController.m_mthGetBacStatstic(); //细菌分布报告
                        break;
                    case 6:
                        m_objController.m_mthGetDgvSampleType(); //微生物 标本类型
                        break;
                    case 7:
                        m_objController.m_mthGetDgvAntiByDept(); //微生物 科室
                        break;
                    case 8:
                        m_objController.m_mthGetAntiDetail(); //微生物明细统计
                        break;
                    case 9:
                        m_objController.m_mthGetDgvSampleSum();//阳性标本来源表
                        break;
                    default:
                        break;
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.ToString());
            }
            this.Cursor = Cursors.Default;
            btnCount.Enabled = true;

        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        //dgv_mic.Rows.Clear();
                        dgv_mic.Rows.Add(value);
                    }
                }
            }

            //this.tabContorl.Visible = false;
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
            //this.dwResult.PrintProperties.Preview = !this.dwResult.PrintProperties.Preview;
            //this.dwResult.PrintProperties.ShowPreviewRulers = this.dwResult.PrintProperties.Preview;
        }

        private void cmdExport_Click(object sender, EventArgs e)
        {
            try
            {
                switch (m_objController.strQuery)
                {
                    case 0:
                        m_objController.m_mthExportToExcel(this.dgvMicdistributiontend, "细菌分布趋势报告",this.lblMicdistributiontend.Text);//细菌分布趋势报告
                        break;
                    case 1:
                        m_objController.m_mthExportToExcel(this.dgvSenRate, "敏感率报告", this.lblSensitiveRate.Text);//----敏感率报告
                        break;
                    case 2:
                        m_objController.m_mthExportToExcel(this.dgvSensitiveTend, "敏感率趋势报告",this.lblSensitiveTend.Text);//----敏感率趋势报告
                        break;
                    case 3:
                        m_objController.m_mthExportToExcel(this.dgvSensitiveRate, "累计敏感性报告", this.lblMicSensitive.Text);//累计敏感性报告
                        break;
                    case 4:
                        m_objController.m_mthExportToExcel(this.dgvMicCumulative, "累计MIC报告", this.lblMicCumulative.Text);//累计MIC报告
                        break;
                    case 5:
                        m_objController.m_mthExportToExcel(this.dgvXjfbbbg, "细菌分布报告", this.lblBacStatstic.Text); //细菌分布报告
                        break;
                    case 6:
                        m_objController.m_mthExportToExcel(this.dgvSampleType, "细菌分布统计按标本类型", ""); //细菌分布报告
                        break;
                    case 7:
                        m_objController.m_mthExportToExcel(this.dgvAntiByDept, "细菌分布统计按科室", ""); //细菌分布报告
                        break;
                    case 8:
                        m_objController.m_mthExportToExcel(this.dgvDetail, "微生物明细统计", ""); //微生物报表明细
                        break;
                    case 9:
                        m_objController.m_mthExportToExcel(this.dgvSampleSum, "阳生标本来源表", ""); //阳生标本来源表
                        break;
                    default:
                        break;
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.ToString());
            }
        }

        private void dgvDetail_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = (e.Row.Index + 1).ToString();  
        }

        private void btnByDept_Click(object sender, EventArgs e)
        {
            frmByDept frmAidChooseDept = new frmByDept();

            if (frmAidChooseDept.ShowDialog() == DialogResult.OK)
            {
                m_objController.DeptIdArr = frmAidChooseDept.DeptIDArr;
            }

            if (!string.IsNullOrEmpty(m_objController.DeptIdArr))
                m_objController.DeptIdArr = "(" + m_objController.DeptIdArr + ")";
        }

        private void btnTabClose_Click(object sender, EventArgs e)
        {
            this.tabContorl.Visible = false;
        }



    }
}