using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmRptOwnCastBill : Form
    {
        private string strTypeList = "";

        public frmRptOwnCastBill()
        {
            InitializeComponent();
        }

        private void frmRptOwnCastBill_Load(object sender, EventArgs e)
        {
            this.dwReport.LibraryList = clsPublic.PBLPath;
            this.dwReport.DataWindowObject = "d_bill_owncastbill";
            this.dwReport.PrintProperties.Preview = true;
            this.dwReport.PrintProperties.ShowPreviewRulers = true;
            this.dwReport.InsertRow(0);

            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("流水号","registerid_chr",HorizontalAlignment.Left,120),                                                            
                                                            new clsColumns_VO("入院时间","inpatient_dat",HorizontalAlignment.Left,80),
                                                            new clsColumns_VO("状态","status",HorizontalAlignment.Left,70)
                                                          };

            this.txtRegisterID.m_mthInitListView(columArr);
            this.txtRegisterID.m_listView.Font = new System.Drawing.Font("宋体", 11.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRegisterID.m_dtbDataSourse = null;

            ArrayList tmplist = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("0045"), ";");

            foreach (Object obj in tmplist)
            {
                strTypeList += "'" + obj.ToString() + "',";
            }
            strTypeList = strTypeList.TrimEnd(',');

            this.cobSelect.SelectedIndex = 0;
        }

        private void txtInpatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                clsCtl_ReportZY obj=new clsCtl_ReportZY();
                this.txtRegisterID.m_dtbDataSourse = obj.m_dtInitText(this.txtInpatientID.Text.Trim(), this.cobSelect.SelectedIndex);
                this.txtRegisterID.m_mthFillData();
                this.txtRegisterID.Focus();
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtRegisterID.Value) || this.txtRegisterID.m_dtbDataSourse == null || this.txtRegisterID.m_listView.Items.Count == 0)
            {
                return;
            }

            clsCtl_ReportZY obj = new clsCtl_ReportZY();
            obj.m_lngOwnCast(this.txtRegisterID.Value.Trim(), strTypeList, this.dwReport);
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            //clsPublic.PrintDialog(this.dwReport);
            clsPublic.ChoosePrintDialog(this.dwReport, true);
        }

        private void cobSelect_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.txtInpatientID.Focus();
        }

        private void cobSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtInpatientID.Text = "";
            this.txtRegisterID.m_dtbDataSourse = null;
            this.txtRegisterID.m_listView.Items.Clear();
        }

        private void txtRegisterID_ItemSelectedOK(object s, EventArgs e)
        {
            this.btnPreview_Click(null, null);
        }
    }
}