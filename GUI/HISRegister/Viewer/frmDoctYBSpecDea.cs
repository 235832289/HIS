using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.common.ICD10.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmDoctYBSpecDea : Form
    {
        public frmDoctYBSpecDea()
        {
            InitializeComponent();
        }

        private string diseasename = "";
        /// <summary>
        /// 特种病名称
        /// </summary>
        public string DiseaseName
        {
            get
            {
                return diseasename;
            }
        }

        private clsICD10Inf[] p_objICD10;
        /// <summary>
        /// 特种病所对应ICD10
        /// </summary>
        public clsICD10Inf[] ObjICD10
        {
            get
            {
                return p_objICD10;
            }
        }
        #region 获取特种病信息
        /// <summary>
        /// 获取特种病信息
        /// </summary>
        public void m_mthLoadYBSpeDea()
        {
            clsDcl_DoctorWorkstation objDoct = new clsDcl_DoctorWorkstation();

            DataTable dt;

            long l = objDoct.m_lngGetYBSpeciaTypeDisease(out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];
                    string[] s = new string[2];
                    s[0] = Convert.ToString(i + 1);
                    s[1] = dr["deadesc_vchr"].ToString();

                    int row = this.dtgDea.Rows.Add(s);
                    this.dtgDea.Rows[row].Tag = dr;
                }
            }
            else
            {
                MessageBox.Show("无门诊医保特种病信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        private void frmDoctYBSpecDea_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dtgDea_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
            {
                return;
            }
                        
            DataRow dr = this.dtgDea.Rows[row].Tag as DataRow;
            string deacode = dr["deacode_chr"].ToString();
            diseasename = dr["deadesc_vchr"].ToString().Trim();

            clsDcl_DoctorWorkstation objDoct = new clsDcl_DoctorWorkstation();

            DataTable dt;

            long l = objDoct.m_lngGetICD10ByDeacode(deacode, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                ArrayList arrICD10 = new ArrayList();                                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    clsICD10Inf ICD10 = new clsICD10Inf();

                    ICD10.ICD10_Code = dt.Rows[i]["icdcode_chr"].ToString().Trim();
                    ICD10.ICD10_Name = dt.Rows[i]["icdname_vchr"].ToString().Trim();
                    arrICD10.Add(ICD10);
                }
                p_objICD10 = arrICD10.ToArray(typeof(clsICD10Inf)) as clsICD10Inf[];
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("获取ICD10信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmDoctYBSpecDea_Load(object sender, EventArgs e)
        {
            this.m_mthLoadYBSpeDea();
        }
    }
}