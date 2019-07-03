using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmInHospitalPatient : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public frmInHospitalPatient(DataTable p_dtbRecord)
        {
            InitializeComponent();
            ListViewItem tempItem;
            clsBrithdayToAge m_objAge = new clsBrithdayToAge();
            foreach (DataRow dr in p_dtbRecord.Rows)
            {
                tempItem = new ListViewItem(dr["inpatientid_chr"].ToString().Trim());
                tempItem.SubItems.Add(dr["lastname_vchr"].ToString().Trim());
                tempItem.SubItems.Add(dr["sex_chr"].ToString().Trim());
                tempItem.SubItems.Add(m_objAge.m_strGetAge(dr["birth_dat"]));
                tempItem.SubItems.Add(dr["status"].ToString().Trim());
                tempItem.SubItems.Add(dr["icd10diagtext_vchr"].ToString().Trim());
                tempItem.SubItems.Add(Convert.ToDateTime(dr["inpatient_dat"]).ToString("yyyy-MM-dd HH:mm"));
                tempItem.SubItems.Add(dr["inpatientcount_int"].ToString().Trim());
                tempItem.SubItems.Add(dr["pstatus"].ToString().Trim());
                tempItem.SubItems.Add(dr["phone"].ToString().Trim());
                tempItem.SubItems.Add(dr["address"].ToString().Trim());
                tempItem.Tag = dr["registerid_chr"].ToString().Trim();
                tempItem.SubItems[0].Tag = dr["patientid_chr"].ToString().Trim();
                m_lsvPatientInfo.Items.Add(tempItem);
            }
            if (m_lsvPatientInfo.Items.Count > 0)
            {
                m_lsvPatientInfo.Items[0].Selected = true;
            }
        }

        private void m_cmdCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void frmInHospitalPatient_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.No;
                    break;
                case Keys.Enter:
                    this.DialogResult = DialogResult.No;
                    break;
                default :
                    break;
            }
        }
    }
}