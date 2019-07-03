using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmRptPatientSource : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 病人来源统计
        /// shichun.chen
        /// 2010\8\11
        /// </summary>
        public frmRptPatientSource()
        {
            InitializeComponent();
        }
        #region 设置控制对象
        /// <summary>
        /// 设置控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_PatientSource();
            this.objController.Set_GUI_Apperance(this);
        }
        #endregion
        private void frmRptPatientSource_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_patientsource";
            //this.dwRep.Modify("t_hospitalname.text='" + ((clsCtl_RptContractUnitPayType)this.objController).strHospitalName + "'");
            //this.dwRep.Refresh();
            
        }
        private void cmd_select_Click(object sender, EventArgs e)
        {
            string strStart = string.Empty;
            string strEnd = string.Empty;
            string strOutStart = string.Empty;
            string strOutEnd = string.Empty;
            if (this.m_chbInHospital.Checked)
            {

                strStart = this.tim_IHStart.Value.ToShortDateString() + " 00:00:00";
                strEnd = this.tim_IHEnd.Value.ToShortDateString() + " 23:59:59";
                if (Convert.ToDateTime(strStart) > Convert.ToDateTime(strEnd))
                {
                    MessageBox.Show("请选择正确时间!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (this.m_chbOutHospital.Checked)
            {

                strOutStart = this.tim_OHStart.Value.ToShortDateString() + " 00:00:00";
                strOutEnd = this.tim_OHEnd.Value.ToShortDateString() + " 23:59:59";
                if (Convert.ToDateTime(strOutStart) > Convert.ToDateTime(strOutEnd))
                {
                    MessageBox.Show("请选择正确时间!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            if (!this.m_chbInHospital.Checked && !this.m_chbOutHospital.Checked)
            {
                 MessageBox.Show("请选择查询条件!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 return;
            }
     
            ((clsCtl_PatientSource)objController).m_mthGetYbCheckBill(this.dwRep, strStart, strEnd, strOutStart, strOutEnd);
        }

        private void cmd_Preview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void cmd_Export_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void cmd_Print_Click(object sender, EventArgs e)
        {
            this.dwRep.Print(true);
        }

        private void cmd_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}