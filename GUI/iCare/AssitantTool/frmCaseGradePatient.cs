using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.emr.BEDExplorer;

namespace iCare
{
    /// <summary>
    /// 病历评分与统计选择病人的窗体
    /// </summary>
    public partial class frmCaseGradePatient : Form
    {
        public frmCaseGradePatient()
        {
            InitializeComponent();
            new clsSortTool().m_mthSetListViewSortable(m_lsvPatient);
            m_mthInit();
        }
        private void m_mthInit()
        {
            clsHospitalManagerDomain objDeptDomain = new clsHospitalManagerDomain();
            clsEmrDept_VO[] objDeptInfoArr = null;
            long lngRes = objDeptDomain.m_lngGetAllDeptInfo("0000002",1, out objDeptInfoArr);
            if (lngRes <= 0 || objDeptInfoArr == null)
            {
                MessageBox.Show("数据库连接失败!");
                return;
            }
            if (objDeptInfoArr.Length > 0)
            {
                m_cboDept.Items.AddRange(objDeptInfoArr);
                m_cboDept.SelectedIndex = 0;
            }
        }

        private void m_cboDept_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (m_cboDept.SelectedItem != null)
            {
                clsHospitalManagerDomain objDeptDomain = new clsHospitalManagerDomain();
                clsEmrDept_VO[] objAreaInfoArr = null;
                long lngRes = objDeptDomain.m_lngGetAreaInfo(((clsEmrDept_VO)(m_cboDept.SelectedItem)).m_strDEPTID_CHR, out objAreaInfoArr);

                if (lngRes <= 0 || objAreaInfoArr == null)
                {
                    MessageBox.Show("数据库连接失败!");
                    return;
                }
                if (objAreaInfoArr.Length > 0)
                {
                    m_cboArea.Items.Clear();
                    m_cboArea.Items.Add("");
                    m_cboArea.Items.AddRange(objAreaInfoArr);
                    m_cboArea.SelectedIndex = 1;
                }
            }
            m_cmdFind_Click(null, System.EventArgs.Empty);
        }

        private void m_rdbInpatientId_CheckedChanged(object sender, System.EventArgs e)
        {
            m_txtInpatientId.Enabled = m_rdbInpatientId.Checked;
            if (!m_rdbInpatientId.Checked)
                m_txtInpatientId.Text = "";
        }

        private void m_rdbPatientName_CheckedChanged(object sender, System.EventArgs e)
        {
            m_txtInpatientName.Enabled = m_rdbPatientName.Checked;
            if (!m_rdbPatientName.Checked)
                m_txtInpatientName.Text = "";
        }

        private void m_cmdFind_Click(object sender, System.EventArgs e)
        {
            this.Text = "住院病历评分与统计 - 正在查询病人,请稍候......";
            clsCaseGradeDomain objDomain = new clsCaseGradeDomain();
            string strDeptId = "";
            string strAreaid = "";
            if (m_cboDept.SelectedItem != null)
                strDeptId = ((clsEmrDept_VO)(m_cboDept.SelectedItem)).m_strDEPTID_CHR;
            if (m_cboArea.SelectedItem is clsEmrDept_VO)
                strAreaid = ((clsEmrDept_VO)(m_cboArea.SelectedItem)).m_strDEPTID_CHR;
            DataTable dtb = null;
            long lngRes = objDomain.m_lngGetPatient(strDeptId.Trim(), strAreaid.Trim(), m_txtInpatientId.Text.Trim(), m_txtInpatientName.Text.Trim(), out dtb);
            if (lngRes <= 0 || dtb.Rows.Count == 0) return;
            m_lsvPatient.Tag = null;
            m_mthAddData(dtb);
            m_lsvPatient.Tag = dtb;

            this.Text = "住院病历评分与统计";
        }

        private void m_cmdStatistics_Click(object sender, System.EventArgs e)
        {
            //打开评分统计界面
        }

        private void m_rdbInPatient_CheckedChanged(object sender, System.EventArgs e)
        {
            if (m_lsvPatient.Tag != null)
            {
                m_mthAddData((DataTable)m_lsvPatient.Tag);
            }
        }

        private void m_mthAddData(DataTable p_dtbValues)
        {
            DataRow[] objRowArr = null;
            DataRow objRow = null;

            string str = "1=1";
            if (m_rdbInPatient.Checked) str = "pstatus_int = '1'";
            else if (m_rdbOutPatient.Checked) str = "pstatus_int = '3'";

            if (m_rdbInpatientId.Checked) str += " and inpatientid_chr like '%" + m_txtInpatientId.Text.Trim() + "%'";
            else if (m_rdbPatientName.Checked) str += " and lastname_vchr like '%" + m_txtInpatientName.Text.Trim() + "%'";

            objRowArr = p_dtbValues.Select(str, "modify_dat desc");
            if (objRowArr.Length > 0)
            {
                m_lsvPatient.Items.Clear();
                for (int i = 0; i < objRowArr.Length; i++)
                {
                    objRow = objRowArr[i];
                    ListViewItem item = new ListViewItem(new string[]{objRow[0].ToString().Trim(),objRow[1].ToString().Trim(),objRow[2].ToString().Trim(),objRow[3].ToString().Trim(),objRow[4].ToString().Trim(),objRow[5].ToString().Trim(),
					objRow[6].ToString().Trim(),objRow[7].ToString().Trim(),objRow[8].ToString().Trim(),objRow[9].ToString().Trim(),objRow[10].ToString().Trim()});
                    //				item.Tag = objPatient.m_strRegisterId;
                    m_lsvPatient.Items.Add(item);
                    if (i % 200 == 0)
                        Application.DoEvents();
                }
            }
        }
        private void m_mniOpenGrade_Click(object sender, System.EventArgs e)
        {
            if (m_lsvPatient.SelectedItems.Count > 0)
            {
                ListViewItem item = m_lsvPatient.SelectedItems[0];
                frmCaseGrade frm = new frmCaseGrade();
                clsPatient objPatient = new clsPatient(item.SubItems[1].Text, item.SubItems[9].Text, item.SubItems[7].Text, item.SubItems[8].Text, "");
                //objPatient.m_IntOperationPower = 4;
                try
                {
                    objPatient.m_DtmSelectedInDate = DateTime.Parse(item.SubItems[2].Text);
                }
                catch { }
                MDIParent.s_ObjCurrentPatient = objPatient;
                if (new clsMainMenuFunction().m_blnCheckSamePatientForm(frm))
                    return;

                if (new clsMainMenuFunction().m_blnCheckForFormOpen(frm, false))
                    return;
                frm.MdiParent = this.MdiParent;
                frm.WindowState = FormWindowState.Maximized;
                frm.m_mthSetPatient(objPatient);
                frm.Show();
            }
        }

        private void m_lsvPatient_DoubleClick(object sender, System.EventArgs e)
        {
            m_mniOpenGrade_Click(null, e);
        }

        private void frmCaseGradePatient_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    m_cmdFind_Click(null, System.EventArgs.Empty);
                    break;
                case Keys.F5:
                    m_mniOpenGrade_Click(null, e);
                    break;
                case Keys.F6:
                    m_cmdStatistics_Click(null, System.EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

        private void m_txtInpatientId_TextChanged(object sender, System.EventArgs e)
        {
            if (m_lsvPatient.Tag != null)
            {
                m_mthAddData((DataTable)m_lsvPatient.Tag);
            }
        }

        private void m_rdbPatientName_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (rdb.Checked && e.Button == MouseButtons.Right)
            {
                rdb.Checked = false;
                m_txtInpatientId.Text = "";
                m_txtInpatientName.Text = "";
            }
        }
    }
}