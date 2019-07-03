using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 病历借阅修改角色设置
    /// </summary>
    public partial class frmProxySetCaseRole : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmProxySetCaseRole()
        {
            InitializeComponent();
        }
        #endregion

        #region 属性.变量

        List<string> lstRoleId { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        internal void Init()
        {
            lstRoleId = new List<string>();
            string parm = clsPublic.m_strGetSysparm("9009");
            if (!string.IsNullOrEmpty(parm))
            {
                string[] arr = parm.Split(';');
                if (arr != null && arr.Length > 0)
                {
                    lstRoleId.AddRange(arr);
                }
            }
        }
        #endregion

        #region 填充角色
        /// <summary>
        /// 填充角色
        /// </summary>
        void FillRole()
        {
            string strRole = this.txtRole.Text.Trim();
            //if (strRole == string.Empty)
            //{
            //    MessageBox.Show("请选择角色", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.txtRole.Focus();
            //    return;
            //}
            this.lsvQueryRole.Items.Clear();
            com.digitalwave.iCare.ValueObject.clsT_SYS_ROLE[] objResult = null;
            com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc objSvc =
                (com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.baseInfo.clsEmployeeSvc));
            long lngRes = objSvc.m_lngGetRole(null, strRole, out objResult);
            if (lngRes > 0 && objResult.Length > 0)
            {
                foreach (com.digitalwave.iCare.ValueObject.clsT_SYS_ROLE item in objResult)
                {
                    if (lstRoleId.IndexOf(item.m_strROLEID_CHR) >= 0)
                    {
                        System.Windows.Forms.ListViewItem lsvitem = new ListViewItem(item.m_strNAME_VCHR);
                        lsvitem.SubItems.Add(item.m_strDESC_VCHR);
                        lsvitem.Tag = item;
                        this.lsvQueryRole.Items.Add(lsvitem);
                    }
                }
            }
            this.lsvQueryRole.Visible = true;
            this.lsvQueryRole.BringToFront();
            this.lsvQueryRole.Focus();
        }
        #endregion

        #region 添加角色
        /// <summary>
        /// 添加角色
        /// </summary>
        void AddRole()
        {
            EntityLogSetCaseRole vo = new EntityLogSetCaseRole();
            if (this.txtRole.Tag != null)
            {
                vo.roleId = this.txtRole.Tag.ToString();
            }
            else
            {
                MessageBox.Show("必须选择角色", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtRole.Focus();
                return;
            }
            vo.empNo = this.txtDoctCode.Text.Trim();
            if (vo.empNo == string.Empty)
            {
                MessageBox.Show("请先输入医师工号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDoctCode.Focus();
                return;
            }
            clsDcl_Charge svc = new clsDcl_Charge();
            DataTable dtEmp = svc.GetEmpInfo(vo.empNo);
            if (dtEmp == null || dtEmp.Rows.Count == 0)
            {
                MessageBox.Show("医师工号无效，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDoctCode.Focus();
                return;
            }
            DataRow drEmp = dtEmp.Rows[0];
            foreach (DataRow dr in dtEmp.Rows)
            {
                if (dr["default_inpatient_dept_int"] != DBNull.Value && Convert.ToInt32(dr["default_inpatient_dept_int"]) == 1)
                {
                    drEmp = dr;
                    break;
                }
            }
            DataTable dtRole = svc.QueryCaseRole("", "", vo.empNo);
            if (dtRole != null && dtRole.Rows.Count > 0)
            {
                foreach (DataRow dr in dtRole.Rows)
                {
                    if (dr["roleid"].ToString() == vo.roleId && Convert.ToInt32(dr["status"]) == 1)
                    {
                        MessageBox.Show("角色: " + dr["rolename"].ToString() + ", 已添加。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtRole.Focus();
                        return;
                    }
                }
            }

            vo.empId = drEmp["empid_chr"].ToString();
            vo.areaId = drEmp["deptid_chr"].ToString();
            vo.giveOperId = this.LoginInfo.m_strEmpID;

            if (svc.AddCaseRole(vo) > 0)
            {
                MessageBox.Show("添加角色成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.QueryRole();
            }
            else
            {
                MessageBox.Show("添加角色失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 删除角色
        /// <summary>
        /// 删除角色
        /// </summary>
        void DelRole()
        {
            if (this.gvRole.SelectedRows.Count == 0)
            {
                MessageBox.Show("请在列表中选择要【回收角色】的医师。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string empName = this.gvRole.SelectedRows[0].Cells["empname"].Value.ToString();
            string roleName = this.gvRole.SelectedRows[0].Cells["rolename"].Value.ToString();
            if (Convert.ToInt32(this.gvRole.SelectedRows[0].Cells["status"].Value) == 2)
            {
                MessageBox.Show("医师 【" + empName + "】 角色 【" + roleName + "】 已回收。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确认回收：医师 【" + empName + "】 角色 【" + roleName + "】 ??", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            EntityLogSetCaseRole vo = new EntityLogSetCaseRole();
            vo.mapId = this.gvRole.SelectedRows[0].Cells["mapid"].Value.ToString();
            vo.recycleOperId = this.LoginInfo.m_strEmpID;
            vo.serNo = Convert.ToDecimal(this.gvRole.SelectedRows[0].Cells["serno"].Value.ToString());

            clsDcl_Charge svc = new clsDcl_Charge();
            if (svc.DelCaseRole(vo) > 0)
            {
                MessageBox.Show("回收角色成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.gvRole.Rows.Remove(this.gvRole.SelectedRows[0]);
            }
            else
            {
                MessageBox.Show("回收角色失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            svc = null;
        }
        #endregion

        #region 查询角色
        /// <summary>
        /// 查询角色
        /// </summary>
        void QueryRole()
        {
            try
            {
                string startDate = this.dteStart.Value.ToString("yyyy-MM-dd");
                string endDate = this.dteEnd.Value.ToString("yyyy-MM-dd");
                if (Convert.ToDateTime(startDate + " 00:00:00") > Convert.ToDateTime(endDate + " 00:00:00"))
                {
                    MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                clsPublic.PlayAvi("查询数据，请稍候...");
                clsDcl_Charge svc = new clsDcl_Charge();
                this.gvRole.DataSource = svc.QueryCaseRole(startDate, endDate, "");
                svc = null;
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmProxySetCaseRole_Load(object sender, EventArgs e)
        {
            this.Init();
        }

        private void txtRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.FillRole();
            }
        }

        private void lsvQueryRole_DoubleClick(object sender, EventArgs e)
        {
            if (this.lsvQueryRole.SelectedItems.Count > 0)
            {
                this.txtRole.Text = ((com.digitalwave.iCare.ValueObject.clsT_SYS_ROLE)this.lsvQueryRole.SelectedItems[0].Tag).m_strNAME_VCHR;
                this.txtRole.Tag = ((com.digitalwave.iCare.ValueObject.clsT_SYS_ROLE)this.lsvQueryRole.SelectedItems[0].Tag).m_strROLEID_CHR;
            }
            this.lsvQueryRole.Visible = false;
        }

        private void lsvQueryRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.lsvQueryRole_DoubleClick(null, null);
            }
        }

        private void lsvQueryRole_Leave(object sender, EventArgs e)
        {
            this.lsvQueryRole.Visible = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.QueryRole();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddRole();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.DelRole();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
