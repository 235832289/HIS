using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmWorkStatstic : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        public frmWorkStatstic()
        {
            InitializeComponent();
        }
        #region
        /// <summary>
        /// 窗体设计器
        /// </summary>
        private clsController_WorkStatstic m_objController;
        private string strEmpno;
        public override void CreateController()
        {
            this.m_objController = new com.digitalwave.iCare.gui.LIS.clsController_WorkStatstic();
            m_objController = (clsController_WorkStatstic)m_objController;
            this.m_objController.Set_GUI_Apperance(this);
        }
        #endregion
        #region
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="e"></param>
        private void m_mthShortCutKey(Keys e)
        {
            if (e == Keys.F3)
            {
                if (this.cmdQuery.Enabled == true
                    && this.cmdQuery.Visible == true)
                {
                    this.cmdQuery_Click(this.cmdQuery, null);
                }
            }

            if (e == Keys.F4)
            {
                if (this.cmdPrint.Enabled == true
                    && this.cmdPrint.Visible == true)
                {
                    this.cmdPrint_Click(this.cmdPrint, null);
                }
            }

            if (e == Keys.F5)
            {
                if (this.cmdExport.Enabled == true
                    && this.cmdExport.Visible == true)
                {
                    this.cmdExport_Click(this.cmdExport, null);
                }
            }

            if (e == Keys.Escape)
            {
                if (this.cmdExit.Enabled == true
                    && this.cmdExit.Visible == true)
                {
                    this.cmdExit_Click(this.cmdExit, null);
                }
            }
        }
        #endregion
        #region
        /// <summary>
        /// 事件响应
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            if (dwResult == null || dwResult.RowCount < 0)
            {
                return;
            }
            com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.dwResult, false);
        }

        private void frmWorkStatstic_KeyDown(object sender, KeyEventArgs e)
        {
            this.m_mthShortCutKey(e.KeyCode);
        }

        private void frmWorkStatstic_Load(object sender, EventArgs e)
        {
            m_dtpFromDate.Value = DateTime.Now.AddMonths(-1);
            m_dtpToDate.Value = DateTime.Now;

            m_objController.m_mthInti();
            this.cboCondition.SelectedIndex = 0;
            this.dwResult.LibraryList = Application.StartupPath + "\\pb_lis.pbl";
            this.dwResult.DataWindowObject = "d_lis_workstatstic";
            this.dwResult.Reset();
        }

        private void cboCondition_SelectedIndexChanged(object sender, EventArgs e)
        {
            int intTem = this.cboCondition.SelectedIndex;
            if (intTem == 0)
            {
                txtCondition.Text = "";
                this.txtCondition.Visible = false;
                this.lblNotice.Visible = false;
                this.cboDept.Visible = true;
                //objController.m_mthGetDept();
                this.cboDept.SelectedIndex = 0;
                m_objController.strQuery = 0;
            }
            if (intTem == 1)
            {
                //ddgvName.Visible = true;
                this.cboDept.Visible = false;
                this.txtCondition.Visible = true;
                this.lblNotice.Visible = true;
                this.txtCondition.Text = null;
                m_objController.strQuery = 1;
            }
            if (intTem == 2)
            {
                //ddgvName.Visible = true;
                this.cboDept.Visible = false;
                this.txtCondition.Visible = true;
                this.lblNotice.Visible = true;
                txtCondition.Text = null;
                m_objController.strQuery = 2;
            }
            if (intTem == 3)
            {
                this.cboDept.Visible = false;
                this.txtCondition.Visible = false;
                this.lblNotice.Visible = false;
                m_objController.strQuery = 3;
            }
        }

        //private void txtCondition_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode==Keys.Enter)
        //    {
        //        if (this.txtCondition.Text == null) { return; }
        //        objController.m_mthGetEmployee();
        //    }
        //}

        private void cmdQuery_Click(object sender, EventArgs e)
        {
            this.dwResult.Reset();
            if (this.txtCondition.Visible && txtCondition.Text == null) { return; }
            m_objController.m_mthGetWorkStatstic(txtCondition.m_StrEmployeeID);
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
                this.dwResult.SaveAs(sfdSave.FileName, Sybase.DataWindow.FileSaveAsType.Xml);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
            cmdExport.Enabled = true;
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion

        private void m_rdbConfig_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbConfig.Checked)
            {
                lblDateFrom.Text = "审核日期";
            }
        }

        private void m_rdbAppDat_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbAppDat.Checked)
            {
                lblDateFrom.Text = "申请日期";
            }
        }

        //private void ddgvName_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    DataRow dr = ((DataRowView)ddgvName.SelectedRows[0].DataBoundItem).Row;
        //    txtCondition.Text = dr["lastname_vchr"].ToString();
        //    strEmpno = dr["empid_chr"].ToString();
        //    ddgvName.Visible = false;
        //}

        //private void txtCondition_Click(object sender, EventArgs e)
        //{
        //    ddgvName.Visible = true;
        //    objController.m_mthGetEmployee();
        //}



        //private void txtCondition_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        DataRow dr = ((DataRowView)ddgvName.SelectedRows[0].DataBoundItem).Row;
        //        txtCondition.Text = dr["lastname_vchr"].ToString();
        //        strEmpno = dr["empid_chr"].ToString();
        //        ddgvName.Visible = false;
        //    }
        //}

        //private void txtCondition_Leave(object sender, EventArgs e)
        //{
        //    this.ddgvName.Visible = false;
        //}

    }
}