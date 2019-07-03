using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 收费项目辅助编辑UI
    /// </summary>
    public partial class frmAidEditItem_OutPatientDefault : Form
    {
        private clsParmItem_VO Item_VO;
        public DataTable dtbDeptsSource;
        private DataTable dtDuty;
        /// <summary>
        /// 构造
        /// </summary>
        public frmAidEditItem_OutPatientDefault(ref clsParmItem_VO vo, DataTable dt)
        {
            InitializeComponent();

            Item_VO = vo;
            dtDuty = dt;
        }        

        private void frmAidEditItem_OutPatientDefault_Load(object sender, EventArgs e)
        {
            this.cboDuty.Items.Add("全部");            
            for (int i = 0; i < dtDuty.Rows.Count; i++)
            {                
                this.cboDuty.Items.Add(dtDuty.Rows[i]["dictname_vchr"].ToString().Trim());                
            }

            this.lblItemName.Text = Item_VO.ItemName;
            this.txtAmount.Text = Item_VO.ItemAmout.ToString();
            this.cboRegStatus.Text = Item_VO.RegFlag;
            this.cboRecipeType.Text = Item_VO.RecFlag;
            this.cboDuty.Text = Item_VO.DutyName;

            this.mskBeginTime.Text = Item_VO.BeginTime;
            this.mskEndTime.Text = Item_VO.EndTime;
            this.txtDept.Text = Item_VO.DeptName;
            this.txtDept.Tag = Item_VO.DeptID;
        }

        private void frmAidEditItem_OutPatientDefault_Activated(object sender, EventArgs e)
        {
            this.txtAmount.Focus();
        }

        #region 编辑
        /// <summary>
        /// 编辑
        /// </summary>
        private void m_mthEdit()
        {
            if (this.txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("请输入数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAmount.Focus();
                return;
            }

            if (!Microsoft.VisualBasic.Information.IsNumeric(this.txtAmount.Text.Trim()))
            {
                MessageBox.Show("数量输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAmount.SelectAll();
                this.txtAmount.Focus();
                return;
            }

            string BeginTime = this.mskBeginTime.Text.Trim();
            string EndTime = this.mskEndTime.Text.Trim();

            if (BeginTime == "" || BeginTime.Length != 5)
            {
                MessageBox.Show("开始时间不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.mskBeginTime.Focus();
                return;
            }

            if (EndTime == "" || EndTime.Length != 5)
            {
                MessageBox.Show("结束时间不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.mskEndTime.Focus();
                return;
            }

            if (Item_VO.ItemAmout == clsPublic.ConvertObjToDecimal(this.txtAmount.Text.Trim()) &&
                Item_VO.RegFlag == this.cboRegStatus.Text &&
                Item_VO.RecFlag == this.cboRecipeType.Text &&
                Item_VO.DutyName == this.cboDuty.Text && 
                Item_VO.BeginTime == this.mskBeginTime.Text.Trim() &&
                Item_VO.EndTime == this.mskEndTime.Text.Trim()&&
                Item_VO.DeptID==this.txtDept.Tag.ToString() && 
                Item_VO.DeptName==this.txtDept.Text.Trim())
            {
                this.Close();
            }
            else
            {
                Item_VO.ItemAmout = clsPublic.ConvertObjToDecimal(this.txtAmount.Text.Trim());
                Item_VO.RegFlag = this.cboRegStatus.Text;
                Item_VO.RecFlag = this.cboRecipeType.Text;
                Item_VO.DutyName = this.cboDuty.Text;
                Item_VO.BeginTime = this.mskBeginTime.Text.Trim();
                Item_VO.EndTime = this.mskEndTime.Text.Trim();
                if (txtDept.Text != "" && txtDept.Tag != null && txtDept.Tag.ToString() != "0")
                {
                    Item_VO.DeptID = this.txtDept.Tag.ToString();
                    Item_VO.DeptName = this.txtDept.Text;
                }
                else
                {
                    Item_VO.DeptID = "0";
                    Item_VO.DeptName = "不指定";
                }

                this.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        private void frmAidEditItem_OutPatientDefault_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.m_mthEdit();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.m_mthEdit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataView dv = dtbDeptsSource.DefaultView;
                string key = this.txtDept.Text.Trim();
                dv.RowFilter = "deptname_vchr like '%" + key + "%' or wbcode_chr like '%" + key + "%' or pycode_chr like '%" + key + "%' or usercode_vchr like '%" + key + "%'";
                DataTable dt = dv.ToTable();
                this.dgvDept.DataSource = dt;
                dgvDept.Visible = true;
                dgvDept.BringToFront();
                dgvDept.Focus();
            }
        }

        private void dgvDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtDept.Tag = dgvDept.CurrentRow.Cells["colID"].Value.ToString();
                this.txtDept.Text = dgvDept.SelectedRows[0].Cells["colDeptName"].Value.ToString();
                dgvDept.Visible = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                dgvDept.Visible = false;
            }
        }

        private void dgvDept_Leave(object sender, EventArgs e)
        {
            dgvDept.Visible = false;
        }

        private void dgvDept_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtDept.Tag = dgvDept.SelectedRows[0].Cells["colId"].Value.ToString();
            this.txtDept.Text = dgvDept.SelectedRows[0].Cells["colDeptName"].Value.ToString();
            dgvDept.Visible = false;
        }                
    }
}