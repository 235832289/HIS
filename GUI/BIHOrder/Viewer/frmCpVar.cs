using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 变异
    /// </summary>
    public partial class frmCpVar : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="_patVo"></param>
        public frmCpVar(clsBIHPatientInfo _patVo)
        {
            InitializeComponent();
            this.patVo = _patVo;
        }
        #endregion


        #region 属性.变量

        /// <summary>
        /// pat.vo
        /// </summary>
        internal clsBIHPatientInfo patVo { get; set; }

        /// <summary>
        /// ExecPlan.DataSource
        /// </summary>
        internal DataRow ExecPlanDataSource { get; set; }

        /// <summary>
        /// Path.DataSource
        /// </summary>
        internal DataTable PathDataSource { get; set; }

        /// <summary>
        /// Path.DataSource
        /// </summary>
        internal DataTable PathDataSourceFilter { get; set; }

        /// <summary>
        /// Var.DataSource
        /// </summary>
        internal DataTable VarDataSource { get; set; }

        /// <summary>
        /// 是否终止路径
        /// </summary>
        internal bool IsStopCp { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.lsvItemPath.Height = 0;

            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable tmp = svc.GetCpExecPlan(this.patVo.m_strRegisterID);
            ExecPlanDataSource = tmp.Rows[0];
            string deptCode = svc.GetCpDeptCode(patVo.m_strDeptID);
            //deptCode = "0327";
            PathDataSource = svc.GetCpListByDeptCode(deptCode);
            VarDataSource = svc.GetCpVariation(Convert.ToInt32(this.ExecPlanDataSource["cpid"].ToString()));
            GetHistory(svc.GetCpExecVarList(Convert.ToDecimal(this.ExecPlanDataSource["execid"].ToString())));
            if (PathDataSource != null && PathDataSource.Rows.Count > 0)
            {
                PathDataSourceFilter = PathDataSource.Clone();
                PathDataSourceFilter.BeginLoadData();
                List<string> lstCpId = new List<string>();
                foreach (DataRow dr in PathDataSource.Rows)
                {
                    if (lstCpId.IndexOf(dr["cpid"].ToString()) < 0)
                    {
                        lstCpId.Add(dr["cpid"].ToString());
                        PathDataSourceFilter.LoadDataRow(dr.ItemArray, true);
                    }
                }
                PathDataSourceFilter.EndLoadData();
            }

            this.clstTarget.Items.Clear();
            if (VarDataSource != null && VarDataSource.Rows.Count > 0)
            {
                foreach (DataRow dr in VarDataSource.Rows)
                {
                    this.clstTarget.Items.Add(dr["varinfo"].ToString());
                }
            }

            this.lblCpName.Text = this.ExecPlanDataSource["cpname"].ToString();
            this.lblDeptName.Text = this.patVo.m_strDeptName;
            this.lblBedNo.Text = this.patVo.m_strBedName + "床";
            this.lblPatName.Text = this.patVo.m_strPatientName;
            this.lblIpNo.Text = this.patVo.m_strInHospitalNo;
        }
        #endregion

        #region GetHistory
        /// <summary>
        /// GetHistory
        /// </summary>
        void GetHistory(DataTable dt)
        {
            this.lvHistory.Items.Clear();
            if (dt != null && dt.Rows.Count > 0)
            {
                ListViewItem obj = null;
                this.lvHistory.BeginUpdate();
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new ListViewItem();
                    obj.Text = Convert.ToDateTime(dr["vardate"]).ToString("yyyy-MM-dd HH:mm");
                    obj.Tag = dr;
                    this.lvHistory.Items.Add(obj);
                }
                this.lvHistory.EndUpdate();
            }
        }
        #endregion

        #region LoadVarInfo
        /// <summary>
        /// LoadVarInfo
        /// </summary>
        /// <param name="varId"></param>
        void LoadVarInfo(decimal varId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtMain = null;
                DataTable dtDet = null;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                svc.GetCpExecVarInfo(varId, out dtMain, out dtDet);
                if (dtMain != null && dtMain.Rows.Count > 0)
                {
                    DataRow dr = dtMain.Rows[0];
                    this.dtpVar.Text = Convert.ToDateTime(dr["vardate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"); ;
                    if (dr["vartype"].ToString() == "1")
                        this.chkEva1.Checked = true;
                    else if (dr["vartype"].ToString() == "2")
                        this.chkEva2.Checked = true;
                    else if (dr["vartype"].ToString() == "3")
                        this.chkEva3.Checked = true;
                    if (Convert.ToDecimal(dr["newcpid"].ToString()) > 0)
                    {
                        decimal cpid = Convert.ToDecimal(dr["newcpid"].ToString());
                        DataRow[] drr = PathDataSource.Select("cpid = " + cpid.ToString());
                        if (drr != null && drr.Length > 0)
                        {
                            this.txtPathName.Text = drr[0]["cpname"].ToString();
                            this.txtPathName.Tag = drr[0];
                        }
                    }
                    this.txtResult.Text = dr["varcontent"].ToString();
                }

                for (int i = 0; i < this.clstTarget.Items.Count; i++)
                {
                    if (dtDet != null && dtDet.Rows.Count > 0)
                    {
                        DataRow[] drr1 = dtDet.Select("varcontent = '" + this.clstTarget.Items[i].ToString() + "'");
                        if (drr1 != null && drr1.Length > 0)
                        {
                            this.clstTarget.SetItemChecked(i, true);
                        }
                        else
                        {
                            this.clstTarget.SetItemChecked(i, false);
                        }
                    }
                    else
                    {
                        this.clstTarget.SetItemChecked(i, false);
                    }
                }
                this.btnOK.Tag = varId.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 查找路径名称
        /// <summary>
        /// 查找路径名称
        /// </summary>
        /// <param name="findCode"></param>
        void FindPathName(string findCode)
        {
            if (PathDataSourceFilter == null || PathDataSourceFilter.Rows.Count == 0) return;

            DataRow[] drr = null;
            if (findCode.Trim() == "")
            {
                drr = new DataRow[PathDataSourceFilter.Rows.Count];
                for (int i = 0; i < PathDataSourceFilter.Rows.Count; i++)
                {
                    drr[i] = PathDataSourceFilter.Rows[i];
                }
            }
            else
            {
                string exp = string.Empty;
                int id = 0;
                int.TryParse(findCode, out id);
                if (id > 0)
                {
                    exp = "cpid = '{0}'";
                    exp = string.Format(exp, findCode);
                }
                else
                {
                    exp = "cpname like '{0}%' or pycode like '{0}%' or wbcode like '{0}%' ";
                    exp = string.Format(exp, new string[3] { findCode, findCode, findCode });
                }
                drr = PathDataSourceFilter.Select(exp);
                if (drr == null || drr.Length == 0)
                {
                    MessageBox.Show("查无数据");
                    return;
                }
            }

            this.lsvItemPath.BeginUpdate();
            this.lsvItemPath.Items.Clear();
            foreach (DataRow dr in drr)
            {
                ListViewItem lv = new ListViewItem(dr["cpid"].ToString());
                lv.SubItems.Add(dr["cpname"].ToString());
                lv.Tag = dr;
                this.lsvItemPath.Items.Add(lv);
            }
            if (this.lsvItemPath.Items.Count > 0)
            {
                this.lsvItemPath.Height = this.Height / 2;
                this.lsvItemPath.Items[0].Selected = true;
                this.lsvItemPath.Focus();
            }

            this.lsvItemPath.EndUpdate();
        }
        #endregion

        #region 选择路径名称
        /// <summary>
        /// 选择路径名称
        /// </summary>
        void SelectPathName()
        {
            if (this.lsvItemPath.Items.Count == 0 || this.lsvItemPath.SelectedItems.Count == 0)
            {
                return;
            }
            DataRow dr = this.lsvItemPath.SelectedItems[0].Tag as DataRow;
            this.txtPathName.Text = dr["cpname"].ToString();
            this.txtPathName.Tag = dr;
            this.txtPathName.Focus();
        }
        #endregion

        #region Save
        /// <summary>
        /// Save
        /// </summary>
        void Save()
        {
            int varId = 0;
            if (this.btnOK.Tag != null) varId = Convert.ToInt32(this.btnOK.Tag.ToString());

            EntityCpExecPlanVar varVo = new EntityCpExecPlanVar();
            varVo.varid = varId;
            varVo.execid = Convert.ToDecimal(this.ExecPlanDataSource["execid"]);
            varVo.registerid = patVo.m_strRegisterID;
            varVo.vardate = Convert.ToDateTime(this.dtpVar.Text);
            if (this.chkEva1.Checked)
                varVo.vartype = 1;
            else if (this.chkEva2.Checked)
                varVo.vartype = 2;
            else if (this.chkEva3.Checked)
                varVo.vartype = 3;
            varVo.doctid = patVo.m_strDOCTORID_CHR;
            varVo.operid = this.LoginInfo.m_strEmpID;
            varVo.operdate = DateTime.Now;
            varVo.status = 1;
            varVo.varcontent = this.txtResult.Text.Trim();

            if (varVo.vartype == 0)
            {
                MessageBox.Show("请选择变异类型。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.chkEva1.Focus();
                return;
            }
            if (varVo.varcontent == string.Empty)
            {
                MessageBox.Show("请输入变异原因。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtResult.Focus();
                return;
            }
            if (varVo.vartype == 2)
            {
                if (this.txtPathName.Tag == null)
                {
                    MessageBox.Show("请选择新路径。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPathName.Focus();
                    return;
                }
                else
                {
                    DataRow dr = this.txtPathName.Tag as DataRow;
                    varVo.newcpid = Convert.ToDecimal(dr["cpid"].ToString());
                }
            }

            List<EntityCpExecPlanVarDetail> lstVo = new List<EntityCpExecPlanVarDetail>();
            if (this.clstTarget.CheckedItems.Count > 0)
            {
                EntityCpExecPlanVarDetail vo = null;
                for (int i = 0; i < this.clstTarget.CheckedItems.Count; i++)
                {
                    vo = new EntityCpExecPlanVarDetail();
                    vo.varcontent = this.clstTarget.CheckedItems[i].ToString();
                    lstVo.Add(vo);
                }
            }

            bool isNew = varId <= 0 ? true : false;
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            if (svc.SaveCpExecvariation(ref varId, varVo, lstVo) > 0)
            {
                this.btnOK.Tag = varId.ToString();
                if (isNew) GetHistory(svc.GetCpExecVarList(varVo.execid));
                if ((varVo.vartype == 2 || varVo.vartype == 3) && this.IsStopCp == false) this.IsStopCp = true;
                MessageBox.Show("保存变异成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存变异失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        #endregion

        #endregion

        #region 事件

        private void frmCpVar_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void txtPathName_DoubleClick(object sender, EventArgs e)
        {
            this.FindPathName(this.txtPathName.Text.Trim());
        }

        private void txtPathName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.FindPathName(this.txtPathName.Text.Trim());
            }
        }

        private void lsvItemPath_DoubleClick(object sender, EventArgs e)
        {
            this.SelectPathName();
        }

        private void lsvItemPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectPathName();
            }
        }

        private void lsvItemPath_Leave(object sender, EventArgs e)
        {
            this.lsvItemPath.Height = 0;
        }

        private void chkEva1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva1.Checked)
            {
                this.chkEva2.Checked = false;
                this.chkEva3.Checked = false;
                this.txtPathName.Text = string.Empty;
                this.txtPathName.Tag = null;
            }
        }

        private void chkEva2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva2.Checked)
            {
                this.chkEva1.Checked = false;
                this.chkEva3.Checked = false;
            }
        }

        private void chkEva3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva3.Checked)
            {
                this.chkEva1.Checked = false;
                this.chkEva2.Checked = false;
                this.txtPathName.Text = string.Empty;
                this.txtPathName.Tag = null;
            }
        }

        private void lvHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                DataRow dr = lvHistory.SelectedItems[0].Tag as DataRow;
                LoadVarInfo(Convert.ToDecimal(dr["varid"].ToString()));
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion




    }
}
