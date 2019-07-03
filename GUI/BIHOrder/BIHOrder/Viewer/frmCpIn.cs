using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 入径
    /// </summary>
    public partial class frmCpIn : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmCpIn(clsBIHPatientInfo _patVo)
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
        /// ICD.DataSource
        /// </summary>
        internal DataTable CpIcdDataSource { get; set; }

        /// <summary>
        /// Path.DataSource
        /// </summary>
        internal DataTable PathDataSource { get; set; }

        /// <summary>
        /// Path.DataSource
        /// </summary>
        internal DataTable PathDataSourceFilter { get; set; }

        /// <summary>
        /// Syn.DataSource
        /// </summary>
        internal DataTable SynDataSource { get; set; }

        /// <summary>
        /// 是否入径成功
        /// </summary>
        internal bool IsSuccess { get; set; }

        /// <summary>
        /// 路径名称
        /// </summary>
        internal string PathName { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.lblPatName.Text = this.patVo.m_strPatientName;
            this.lsvItemICD.Height = 0;
            this.lsvItemPath.Height = 0;
            this.lsvItemSyn.Height = 0;

            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            string deptCode = svc.GetCpDeptCode(patVo.m_strDeptID);
            //deptCode = "0327";
            PathDataSource = svc.GetCpListByDeptCode(deptCode);
            SynDataSource = svc.GetSyndrome();

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
        }
        #endregion

        #region 查找主要诊断
        /// <summary>
        /// 查找主要诊断
        /// </summary>
        /// <param name="findCode"></param>
        void FindICD(string findCode)
        {
            if (CpIcdDataSource == null || CpIcdDataSource.Rows.Count == 0) return;

            DataRow[] drr = null;
            if (findCode.Trim() == "")
            {
                drr = new DataRow[CpIcdDataSource.Rows.Count];
                for (int i = 0; i < CpIcdDataSource.Rows.Count; i++)
                {
                    drr[i] = CpIcdDataSource.Rows[i];
                }
            }
            else
            {
                string exp = "icdcode like '{0}%' or icdname like '{0}%' or pycode like '{0}%' or wbcode like '{0}%' ";
                exp = string.Format(exp, new string[4] { findCode, findCode, findCode, findCode });
                drr = CpIcdDataSource.Select(exp);
                if (drr == null || drr.Length == 0)
                {
                    MessageBox.Show("查无数据");
                    return;
                }
            }

            string icdCode = string.Empty;
            List<string> lstIcdCode = new List<string>();
            this.lsvItemICD.BeginUpdate();
            this.lsvItemICD.Items.Clear();
            foreach (DataRow dr in drr)
            {
                icdCode = dr["icdcode"].ToString();
                if (lstIcdCode.IndexOf(icdCode) < 0)
                {
                    lstIcdCode.Add(icdCode);
                    ListViewItem lv = new ListViewItem(icdCode);
                    lv.SubItems.Add(dr["icdname"].ToString());
                    lv.Tag = dr;
                    this.lsvItemICD.Items.Add(lv);
                }
            }
            if (this.lsvItemICD.Items.Count > 0)
            {
                this.lsvItemICD.Height = 266;
                this.lsvItemICD.Items[0].Selected = true;
                this.lsvItemICD.Focus();
            }

            this.lsvItemICD.EndUpdate();
        }
        #endregion

        #region 选择主要诊断
        /// <summary>
        /// 选择主要诊断
        /// </summary>
        void SelectICD()
        {
            if (this.lsvItemICD.Items.Count == 0 || this.lsvItemICD.SelectedItems.Count == 0)
            {
                return;
            }
            DataRow dr = this.lsvItemICD.SelectedItems[0].Tag as DataRow;
            this.txtMainDiag.Text = dr["icdname"].ToString();
            this.txtMainDiag.Tag = dr;
            this.txtMainDiag.Focus();

            if (PathDataSource != null && PathDataSource.Rows.Count > 0)
            {
                DataRow[] drr = PathDataSource.Select("icdcode = '" + dr["icdcode"].ToString() + "'");
                if (drr != null && drr.Length > 0)
                {
                    this.txtPathName.Text = drr[0]["cpname"].ToString();
                    this.txtPathName.Tag = drr[0];
                    this.txtPathName.Focus();
                }
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
                this.lsvItemPath.Height = 266;
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

        #region 查找症型
        /// <summary>
        /// 查找症型
        /// </summary>
        /// <param name="findCode"></param>
        void FindSyn(string findCode)
        {
            if (SynDataSource == null || SynDataSource.Rows.Count == 0) return;

            DataRow[] drr = null;
            if (findCode.Trim() == "")
            {
                drr = new DataRow[SynDataSource.Rows.Count];
                for (int i = 0; i < SynDataSource.Rows.Count; i++)
                {
                    drr[i] = SynDataSource.Rows[i];
                }
            }
            else
            {

            }

            this.lsvItemSyn.BeginUpdate();
            this.lsvItemSyn.Items.Clear();
            foreach (DataRow dr in drr)
            {
                ListViewItem lv = new ListViewItem(dr["synname"].ToString());
                lv.Tag = dr;
                this.lsvItemSyn.Items.Add(lv);
            }
            if (this.lsvItemSyn.Items.Count > 0)
            {
                this.lsvItemSyn.Height = 266;
                this.lsvItemSyn.Items[0].Selected = true;
                this.lsvItemSyn.Focus();
            }

            this.lsvItemSyn.EndUpdate();
        }
        #endregion

        #region 选择症型
        /// <summary>
        /// 选择症型
        /// </summary>
        void SelectSyn()
        {
            if (this.lsvItemSyn.Items.Count == 0 || this.lsvItemSyn.SelectedItems.Count == 0)
            {
                return;
            }
            DataRow dr = this.lsvItemSyn.SelectedItems[0].Tag as DataRow;
            this.txtZyzx.Text = dr["synname"].ToString();
            this.txtZyzx.Tag = dr;
            this.txtZyzx.Focus();
        }
        #endregion

        #region Save
        /// <summary>
        /// Save
        /// </summary>
        void Save()
        {
            if (this.txtMainDiag.Tag == null)
            {
                MessageBox.Show("请输入主要诊断。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMainDiag.Focus();
                return;
            }
            if (this.txtPathName.Tag == null)
            {
                MessageBox.Show("请输入路径名称。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtPathName.Focus();
                return;
            }
            if (this.clstDiagRef.CheckedItems.Count == 0)
            {
                MessageBox.Show("请选择诊断依据。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.clstDiagRef.Focus();
                return;
            }
            string refStr = string.Empty;
            for (int i = 0; i < this.clstDiagRef.CheckedItems.Count; i++)
            {
                refStr += this.clstDiagRef.CheckedItems[i].ToString() + ";";
            }

            DateTime dtmCp = Convert.ToDateTime(this.dtpCp.Text);
            EntityCpExecPlan execVo = new EntityCpExecPlan();
            execVo.registerid = patVo.m_strRegisterID;
            execVo.deptid = patVo.m_strDeptID;
            execVo.areaid = patVo.m_strAreaID;
            execVo.bedid = patVo.m_strBedID;
            execVo.doctid = patVo.m_strDOCTORID_CHR;
            execVo.indesc = this.txtRemark.Text.Trim();
            execVo.currdate = dtmCp;
            execVo.begindate = dtmCp;
            execVo.status = 1;
            execVo.recorder = this.LoginInfo.m_strEmpID;
            execVo.recorddate = DateTime.Now;
            execVo.othexam = refStr.TrimEnd(',');
            execVo.synname = this.txtZyzx.Text.Trim();

            DataRow dr = this.txtMainDiag.Tag as DataRow;
            execVo.cpmainicdcode = dr["icdcode"].ToString();
            execVo.cpmainicdname = dr["icdname"].ToString();

            dr = this.txtPathName.Tag as DataRow;
            execVo.cpid = Convert.ToDecimal(dr["cpid"].ToString());
            execVo.cpname = dr["cpname"].ToString();

            decimal execId = 0;
            if (this.btnOK.Tag != null) execId = Convert.ToDecimal(this.btnOK.Tag.ToString());
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            if (svc.CpIn(execVo, ref execId) > 0)
            {
                this.PathName = execVo.cpname;
                this.IsSuccess = true;
                this.btnOK.Tag = execId.ToString();
                MessageBox.Show("入径成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("入径失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Save2
        /// <summary>
        /// Save2
        /// </summary>
        void Save2()
        {
            if (this.txtPathName.Text.Trim() == string.Empty || this.txtPathName.Tag == null)
            {
                MessageBox.Show("请选择路径(名称)", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPathName.Focus();
                return;
            }
            DataRow dr = this.txtPathName.Tag as DataRow;
            int isFit = this.rdoYes.Checked ? 1 : 0;
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            if (svc.SaveIsFitCp(patVo.m_strRegisterID, isFit, dr["cpname"].ToString()) > 0)
            {
                MessageBox.Show("保存成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmCpIn_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save2();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 主要诊断

        private void txtMainDiag_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.FindICD(this.txtMainDiag.Text.Trim());
            }
        }

        private void txtMainDiag_DoubleClick(object sender, EventArgs e)
        {
            this.FindICD(this.txtMainDiag.Text.Trim());
        }

        private void lsvItemICD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectICD();
            }
        }

        private void lsvItemICD_Leave(object sender, EventArgs e)
        {
            this.lsvItemICD.Height = 0;
        }

        private void lsvItemICD_DoubleClick(object sender, EventArgs e)
        {
            this.SelectICD();
        }

        #endregion

        #region 路径名

        private void txtPathName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.FindPathName(this.txtPathName.Text.Trim());
            }
        }

        private void txtPathName_DoubleClick(object sender, EventArgs e)
        {
            this.FindPathName(this.txtPathName.Text.Trim());
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

        private void lsvItemPath_DoubleClick(object sender, EventArgs e)
        {
            this.SelectPathName();
        }

        #endregion

        #region 中医症型

        private void txtZyzx_DoubleClick(object sender, EventArgs e)
        {
            this.FindSyn("");
        }

        private void txtZyzx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.FindSyn("");
            }
        }

        private void lsvItemSyn_DoubleClick(object sender, EventArgs e)
        {
            this.SelectSyn();
        }

        private void lsvItemSyn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectSyn();
            }
        }

        private void lsvItemSyn_Leave(object sender, EventArgs e)
        {
            this.lsvItemSyn.Height = 0;
        }

        #endregion

        #endregion

    }
}
