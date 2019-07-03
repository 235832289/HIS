using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmDemandPayment : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        private com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo = null;
        private bool m_bolAllArea = false;
        internal bool m_blnInHospitalFlag = true;

        public frmDemandPayment()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// 外部接口
        /// </summary>
        /// <param name="p_strInHospitalFlag">在院标志 1 在院病人 0 出院病人</param>
        /// <param name="p_strAllAreaFlag">全区标志 1 全区 0 当前病区</param>
        public void m_mthShow(string p_strInHospitalFlag, string p_strAllAreaFlag)
        {
            if (p_strInHospitalFlag != "1")
            {
                this.m_blnInHospitalFlag = false;
            }

            if (p_strAllAreaFlag == "1")
            {
                this.m_bolAllArea = true;
            }
            
            this.Show();
        }

        public void ShowIncAllArea(string flag)
        {
            if(flag == "1")
            {
                this.m_bolAllArea =  true;
                this.Show();
            }
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlDemandPayment();
            objController.Set_GUI_Apperance(this);
        }        

        private void frmDemandPayment_Load(object sender, EventArgs e)
        {
            this.dw_1.LibraryList = clsPublic.PBLPath;
            this.dw_1.DataWindowObject = "d_demandpayment";
            this.dwEveryDayBill.LibraryList = clsPublic.PBLPath;
            //this.dwEveryDayBill.DataWindowObject = "d_everydaybill";
            this.dwEveryDayBill.DataWindowObject = "d_bih_everydaybill_entry2";

            // 病区列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
            };
            this.m_txtArea.m_strSQL = @"SELECT   a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                        FROM t_bse_deptdesc a, T_BSE_DEPTEMP b
                                        WHERE a.deptid_chr = b.deptid_chr and
                                             a.attributeid = '0000003' AND a.status_int = 1
                                            and b.EMPID_CHR = '" + this.LoginInfo.m_strEmpID + "' ORDER BY code_vchr";

            if (this.m_bolAllArea == true)
            {
                this.m_txtArea.m_strSQL = @"SELECT '%' deptid_chr, '全院' deptname_vchr, 'qy' pycode_chr, '00' code_vchr
                                        FROM t_bse_deptdesc
                                        WHERE rownum = 1
                                        union all
                                        SELECT   a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                        FROM t_bse_deptdesc a
                                        WHERE
                                             a.attributeid = '0000003' AND a.status_int = 1
                                             ORDER BY code_vchr";
            }
            
            this.m_txtArea.m_mthInitListView(columArr);

            this.m_txtArea.Focus();
            this.m_txtArea.SelectAll();
            //设置默认病区
            this.m_txtArea.Value = this.LoginInfo.m_strInpatientAreaID;
            this.m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName;

            this.m_cmbStatus.SelectedIndex = 0;

            TimeSpan ts = new TimeSpan(1, 0, 0, 0);
            this.m_dtpDate.Value = DateTime.Now.Subtract(ts);

            if (this.m_blnInHospitalFlag)
            {
                this.Text = "催款查询-【在院病人】";
            }
            else
            {
                this.Text = "催款查询-【出院病人】";
                this.lblCysj.Visible = true;
                this.lblToDate.Visible = true;
                this.dteBeginDate.Visible = true;
                this.dteEndDate.Visible = true;
                this.dteBeginDate.Value = DateTime.Now;
                this.dteEndDate.Value = DateTime.Now;
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtlDemandPayment)this.objController).GetAreaDemandPayment();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            if (this.m_dgvDetail.Rows.Count == 0)
                return;

            try
            {
                dw_1.Reset();
                int newRow;
                for (int i = 0; i < this.m_dgvDetail.Rows.Count; i++)
                {
                    newRow = dw_1.InsertRow();
                    dw_1.SetItemString(newRow, "areaname", this.m_dgvDetail.Rows[i].Cells["AreaName"].Value.ToString());
                    dw_1.SetItemString(newRow, "name", this.m_dgvDetail.Rows[i].Cells["LASTNAME_VCHR"].Value.ToString());
                    dw_1.SetItemString(newRow, "bedno", this.m_dgvDetail.Rows[i].Cells["CODE_CHR"].Value.ToString());
                    dw_1.SetItemString(newRow, "inpatientid", this.m_dgvDetail.Rows[i].Cells["INPATIENTID_CHR"].Value.ToString());
                    dw_1.SetItemString(newRow, "paycarddesc", this.m_dgvDetail.Rows[i].Cells["PAYCARDDESC_VCHR"].Value.ToString());
                    dw_1.SetItemDecimal(newRow, "waitclearfee", decimal.Parse(this.m_dgvDetail.Rows[i].Cells["WaitClearFee"].Value.ToString()));
                    dw_1.SetItemDecimal(newRow, "prepaymoney", decimal.Parse(this.m_dgvDetail.Rows[i].Cells["PrepayMoney"].Value.ToString()));
                    dw_1.SetItemDecimal(newRow, "balancefee", decimal.Parse(this.m_dgvDetail.Rows[i].Cells["BalanceFee"].Value.ToString()));
                    dw_1.SetItemDecimal(newRow, "limitrate", decimal.Parse(this.m_dgvDetail.Rows[i].Cells["LIMITRATE_MNY"].Value.ToString()));
                    dw_1.SetItemString(newRow, "remarkname", this.m_dgvDetail.Rows[i].Cells["REMARKNAME_VCHR"].Value.ToString());
                    dw_1.SetItemString(newRow, "casedoctor", this.m_dgvDetail.Rows[i].Cells["CaseDoctor"].Value.ToString());
                    dw_1.SetItemString(newRow, "des_vchr", this.m_dgvDetail.Rows[i].Cells["des"].Value.ToString());
                }
               
                dw_1.Modify("st_operator.text = '" + this.LoginInfo.m_strEmpName + "'");
                //dw_1.Sort();
                dw_1.CalculateGroups();
                dw_1.Refresh();
                //dw_1.Visible = true;
                //dw_1.BringToFront();
                //dw_1.Print(true);
                
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();
                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    dw_1.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    dw_1.Print(false, false);
                }
                
                //打印预览
                //DWPrintPreview printPreview = new DWPrintPreview(dw_1);
                //printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
         }

        private void m_cmdPrtOne_Click(object sender, EventArgs e)
        {
            ((clsCtlDemandPayment)this.objController).PrintProVioce();
        }

        private void m_cmdPrtAll_Click(object sender, EventArgs e)
        {
            ((clsCtlDemandPayment)this.objController).PrintAllVioce();
        }

        private void m_ckbLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_ckbLeft.Checked)
            {
                this.m_lblStatus.Visible = false;
                this.m_cmbStatus.Visible = false;
            }
            else
            {
                this.m_lblStatus.Visible = true;
                this.m_cmbStatus.Visible = true;
            }
        }

        private void m_cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.m_txtMaxMoney.Focus();
        }

        private void m_txtMaxMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.m_cmdSearch.Focus();
        }

        private void m_txtMaxMoney_Enter(object sender, EventArgs e)
        {
            this.m_txtMaxMoney.SelectAll();
        }

        private void frmDemandPayment_Layout(object sender, LayoutEventArgs e)
        {
            //this.m_txtArea.Focus();
            //this.m_txtArea.SelectAll();
            //设置默认病区
            //this.m_txtArea.Value = this.LoginInfo.m_strInpatientAreaID;
            //this.m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName;

            //this.m_cmbStatus.SelectedIndex = 0;
        }

        private void m_cmdEveryDayBill_Click(object sender, EventArgs e)
        {
            clsCtl_Report objReport = new clsCtl_Report();

            string areaId = this.m_txtArea.Value.Trim();

            if (areaId == null || areaId == "")
            {
                MessageBox.Show("请选择病区！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            string billDate = this.m_dtpDate.Value.ToString("yyyy-MM-dd");

            clsPublic.PlayAvi("findFILE.avi", "正在生成清单信息，请稍候...");

            //objReport.m_mthRptEveryDayBill("0003", areaId, billDate, 1, this.dwEveryDayBill);
            objReport.m_mthRptEveryDayBillEntry2(areaId, billDate, 1, 1, this.dwEveryDayBill);
            
            clsPublic.CloseAvi();

            if (this.dwEveryDayBill.RowCount > 0)
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();
                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.dwEveryDayBill.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.dwEveryDayBill.Print(false, false);
                }
            }
            else
            {
                MessageBox.Show("无清单数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //打印预览
            //DWPrintPreview printPreview = new DWPrintPreview(this.dwEveryDayBill);
            //printPreview.ShowDialog();
        }

        private void m_cmdEveryDayBillForPer_Click(object sender, EventArgs e)
        {
            clsCtl_Report objReport = new clsCtl_Report();

            string areaId = this.m_txtArea.Value.Trim();

            if (areaId == null || areaId == "")
            {
                MessageBox.Show("请选择病区！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            int row = this.m_dgvDetail.SelectedRows.Count;
            if (row == 0)
            {
                MessageBox.Show("请选择病人！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string registerId = this.m_dgvDetail.SelectedRows[0].Cells["registerId"].Value.ToString();
            

            string billDate = this.m_dtpDate.Value.ToString("yyyy-MM-dd");

            clsPublic.PlayAvi("findFILE.avi", "正在生成清单信息，请稍候...");

            //objReport.m_mthRptEveryDayBill("0003", registerId, billDate, 2, this.dwEveryDayBill);
            objReport.m_mthRptEveryDayBillEntry2(registerId, billDate, 2, 1, this.dwEveryDayBill);

            clsPublic.CloseAvi();

            if (this.dwEveryDayBill.RowCount > 0)
            {
                //this.dwEveryDayBill.Print(true);
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();
                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.dwEveryDayBill.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.dwEveryDayBill.Print(false, false);
                }
            }
            else
            {
                MessageBox.Show("无清单数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //打印预览
            //DWPrintPreview printPreview = new DWPrintPreview(this.dwEveryDayBill);
            //printPreview.ShowDialog();
        }

       
    }
}