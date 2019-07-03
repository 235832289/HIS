using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPSFindreport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmOPSFindreport()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void frmOPSFindreport_Load(object sender, EventArgs e)
        {
            m_mthSetDeptList();
            m_mthGetDoctorBYdeptData("");
        }
        #region 获取根据部门取医生数据,赋值给控件
        /// <summary>
        /// 获取根据部门取医生数据
        /// </summary>
        private void m_mthGetDoctorBYdeptData(string p_strdeptID)
        {
            DataTable dt = null;
            com.digitalwave.iCare.gui.PACS.clsControlPacsBooking objCls = new com.digitalwave.iCare.gui.PACS.clsControlPacsBooking();
            long lngres = objCls.m_lngGetDoctorBYdeptData(out dt, p_strdeptID);
            if (lngres > 0)
            {
                if (dt != null)
                {
                    this.m_txtFinddoct.m_GetDataTable = dt;
                }
            }
        }
        #endregion
        #region 获取科室数据,赋值给控件
        /// <summary>
        /// 获取科室数据
        /// </summary>
        private void m_mthSetDeptList()
        {
            DataTable dt = null;
            com.digitalwave.iCare.gui.PACS.clsControlPacsBooking objCls = new com.digitalwave.iCare.gui.PACS.clsControlPacsBooking();
            long lngres = objCls.m_lngGetdeptdescData(out dt);
            if (lngres > 0)
            {
                if (dt != null)
                {
                    this.txtDept.m_GetDataTable = dt;
                }
            }
        }
        #endregion

        #region 条件控件Enabled控制
        /// <summary>
        /// 条件控件Enabled控制
        /// </summary>
        private void m_mthSetenabled(TextBox Tx, bool Enabled)
        {
            if (Enabled)
            {
                Tx.Enabled = true;
                Tx.Focus();
            }
            else
            {
                Tx.Text = "";
                Tx.Enabled = false;
            }
        }

        private void m_mthSetenabled(ComboBox Cb, bool Enabled)
        {
            if (Enabled)
            {
                Cb.Enabled = true;
                Cb.Focus();
            }
            else
            {
                Cb.Text = "";
                Cb.Enabled = false;
            }
        }
        #endregion

        private void chkCardno_CheckedChanged(object sender, EventArgs e)
        {
            this.m_mthSetenabled(this.txtCardno, ((CheckBox)sender).Checked);
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            this.m_mthSetenabled(this.txtName, ((CheckBox)sender).Checked);
        }        

        private void chkDept_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.txtDept.Enabled = true;
                this.txtDept.Focus();
            }
            else
            {
                this.txtDept.Enabled = false;
                this.txtDept.txtValuse = "";
            }
        }

        private void chkOPSName_CheckedChanged(object sender, EventArgs e)
        {
            this.m_mthSetenabled(this.txtOPSName, ((CheckBox)sender).Checked);
        }        

        private void chkDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                this.m_txtFinddoct.Enabled = true;
                this.m_txtFinddoct.Focus();
            }
            else
            {
                this.m_txtFinddoct.Enabled = false;
                this.m_txtFinddoct.txtValuse = "";
            }
        }        

        private void chkSex_CheckedChanged(object sender, EventArgs e)
        {
            this.m_mthSetenabled(this.cboSex, ((CheckBox)sender).Checked);
        }

        private void chkOPSDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOPSDate.Checked)
            {
                this.dtpBegindate.Enabled = true;
                this.dtpEnddate.Enabled = true;
            }
            else
            {
                this.dtpBegindate.Enabled = false;
                this.dtpEnddate.Enabled = false;
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_mthFind();
            this.Cursor = Cursors.Default;
        }

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        private void m_mthFind()
        {
            //查询条件
            string sqlwhere = "";
            //条件组合逻辑
            string Jion = "";
            if (this.rdoAnd.Checked)
            {
                Jion = " and ";
            }
            else if (this.rdoOr.Checked)
            {
                Jion = " or ";
            }

            //卡号
            if (this.txtCardno.Enabled && this.txtCardno.Text.Trim() != "")
            {
                sqlwhere += "(f.patientcardid_chr = '" + this.txtCardno.Text.Trim() + "') " + Jion;
            }

            //姓名
            if (this.txtName.Enabled && this.txtName.Text.Trim() != "")
            {
                sqlwhere += "(b.name_vchr like '" + this.txtName.Text.Trim() + "%') " + Jion;
            }

            //性别
            if (this.cboSex.Enabled && this.cboSex.Text.Trim() != "")
            {
                sqlwhere += "(b.sex_chr = '" + this.cboSex.Text.Trim() + "') " + Jion;
            }

            //手术者
            if (this.m_txtFinddoct.Enabled && this.m_txtFinddoct.txtValuse.Trim() != "")
            {
                sqlwhere += "(h.opsdoctor_chr like '" + this.m_txtFinddoct.txtValuse.Trim() + "%') " + Jion;
            }

            //手术科室
            if (this.txtDept.Enabled && this.txtDept.txtValuse.Trim() != "")
            {
                sqlwhere += "(e.deptname_vchr like '" + this.txtDept.txtValuse.Trim() + "%') " + Jion;
            }

            //手术名称
            if (this.txtOPSName.Enabled && this.txtOPSName.Text.Trim() != "")
            {
                sqlwhere += "(h.opsname_vchr like '%" + this.txtOPSName.Text.Trim() + "%') " + Jion;
            }

            //手术时间
            if (this.dtpBegindate.Enabled)
            {
                sqlwhere += "(to_char(h.opsdate_dat,'yyyy-mm-dd') between '" + this.dtpBegindate.Value.ToString("yyyy-MM-dd") + "' and '" + this.dtpEnddate.Value.ToString("yyyy-MM-dd") + "')";
            }

            if ((sqlwhere = sqlwhere.Trim()) == "")
            {
                return;
            }
            else
            {
                if (sqlwhere.Substring(sqlwhere.Length - 3, 3).ToLower() == "and" || sqlwhere.Substring(sqlwhere.Length - 3, 3).ToLower() == " or")
                {
                    sqlwhere = sqlwhere.Substring(0, sqlwhere.Length - 3).Trim();
                }
            }

            sqlwhere = " and (" + sqlwhere + ") order by applyid_vchr";

            DataTable dtRecord = new DataTable();
            clsDcl_DoctorWorkstation objSvc = new clsDcl_DoctorWorkstation();
            long ret = objSvc.m_lngGetopsreports(sqlwhere, out dtRecord);
            if (ret > 0)
            {
                this.Column1.DataPropertyName = "applyid_vchr";
                this.Column2.DataPropertyName = "name_vchr";
                this.Column3.DataPropertyName = "sex_chr";
                this.Column4.DataPropertyName = "birth_dat";
                this.Column5.DataPropertyName = "patientcardid_chr";
                this.Column6.DataPropertyName = "deptname_vchr";
                this.Column7.DataPropertyName = "opsname_vchr";
                this.Column8.DataPropertyName = "opsdate_dat";
                this.Column9.DataPropertyName = "opsdoctor_chr";
                this.Column10.DataPropertyName = "opsresult_vchr";

                this.dataGridView.DataSource = dtRecord;
            }          
        }
        #endregion

        private string applyid = "";
        public string Applyid
        {
            get
            {
                return applyid;
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row < 0)
            {
                return;
            }
            applyid = dataGridView.Rows[row].Cells[0].Value.ToString();

            if (applyid == null || applyid == "")
            {
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            com.digitalwave.GLS_WS.clsCtl_Base cls = new com.digitalwave.GLS_WS.clsCtl_Base();
            string Hospitalname = new com.digitalwave.iCare.common.clsCommmonInfo().m_strGetHospitalTitle();
            cls.m_mthPrintPreviewFromDataGridView(dataGridView, 0, Hospitalname +"门诊手术报告单汇总表");
            cls = null;
        }

        private void txtCardno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = this.txtCardno.Text.Trim();
                this.txtCardno.Text = s.PadLeft(10, '0');
            }
        }
    }
}