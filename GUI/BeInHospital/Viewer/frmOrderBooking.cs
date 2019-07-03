using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmOrderBooking : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {    
        /// <summary>
        /// 
        /// </summary>
        public frmOrderBooking()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsOrderBooking();
            objController.Set_GUI_Apperance(this);
        }

        private void frmOrderBooking_Load(object sender, EventArgs e)
        {
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtArea });
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
            this.m_txtArea.m_mthInitListView(columArr);

            this.m_txtArea.Focus();
            this.m_txtArea.SelectAll();
            //设置默认病区
            this.m_txtArea.Value = this.LoginInfo.m_strInpatientAreaID;
            this.m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName;

            this.m_dtpBeginDate.Text = DateTime.Now.ToShortDateString() + " 00:00";
            this.m_dtpEndDate.Text = DateTime.Now.ToShortDateString() + " 23:59";

            this.m_cmbStatus.SelectedIndex = 0;
            this.m_cmbPrintFlag.SelectedIndex = 1;

            ((clsOrderBooking)this.objController).m_mthInit();

            m_cmdSearch_Click(sender, e);
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).SeachData();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void dw_seach_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        //{
        //    if (e.RowNumber == 0)
        //        return;

        //    if (this.dw_seach.IsSelected(e.RowNumber))
        //    {
        //        this.dw_seach.SelectRow(e.RowNumber, false);
        //    }
        //    else
        //    {
        //        this.dw_seach.SelectRow(e.RowNumber, true);
        //    }
        //}

       
        private void m_cmdPrint_Click(object sender, EventArgs e)
        {            
            System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

            //选择打印机
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                ((clsOrderBooking)this.objController).dsPrint.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                ((clsOrderBooking)this.objController).dsPrint.Print(false, false);
            }
        }

        private void m_cmdPrintForPat_Click(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).PrintPat();
        }

        private void m_cmdPrintForAll_Click(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).PrintAll(); 
        }

        private void frmOrderBooking_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("确认退出么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void m_cmdBed_Click(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).BedFilter(); 
        }

        private void m_cmdReplyForm_Click(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).OpentApplyForm(); 
        }

        private void m_cmbPrintFlag_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).SeachData();
        }

        private void m_cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).SeachData();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((clsOrderBooking)this.objController).PrintPat();
        }
    }
}