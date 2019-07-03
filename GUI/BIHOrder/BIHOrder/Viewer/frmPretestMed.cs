using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 预发药查询.管理
    /// </summary>
    public partial class frmPretestMed : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmPretestMed()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// 数据源
        /// </summary>
        List<EntityPretestMed> DataSource { get; set; }

        #region 科室实体
        /// <summary>
        /// 科室
        /// </summary>
        public class EntityDept
        {
            public string deptId { get; set; }
            public string deptName { get; set; }
        }
        #endregion

        /// <summary>
        /// 科室字典
        /// </summary>
        List<EntityDept> DataSourceDept { get; set; }


        #endregion

        #region 方法

        #region 外部接口

        /// <summary>
        /// 1 管理员; 2 病区
        /// </summary>
        internal int bizType { get; set; }

        /// <summary>
        /// 外部调用
        /// </summary>
        /// <param name="_bizType"></param>
        public void Show2(string _bizType)
        {
            this.bizType = Convert.ToInt32(_bizType);
            this.Show();
        }
        #endregion

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            this.plDept.Visible = (this.bizType == 1 ? true : false);
            this.btnRec.Visible = (this.bizType == 1 ? true : false);
            DataSourceDept = new List<EntityDept>();
            this.cboOrderStatus.Text = "审核停止";
            this.cboDateType.Text = "按停嘱时间";
            this.chkHsNo.Checked = true;
        }
        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        void Query()
        {
            try
            {
                if (this.dtmBegin.Text.Trim() == "" || this.dtmEnd.Text.Trim() == "")
                {
                    MessageBox.Show("请输入查询开始时间和结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DateTime beginTime = Convert.ToDateTime(this.dtmBegin.Text + " 00:00:00");
                DateTime endTime = Convert.ToDateTime(this.dtmEnd.Text + " 23:59:59");
                if (beginTime > endTime)
                {
                    MessageBox.Show("开始时间不能大于结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string isHs = string.Empty;
                string isSf = string.Empty;
                string dateType = this.cboDateType.SelectedIndex.ToString();
                this.Cursor = Cursors.WaitCursor;
                string areaId = (this.bizType == 1 ? "" : this.LoginInfo.m_strInpatientAreaID);
                string orderStatus = this.cboOrderStatus.Text.Trim();
                switch (orderStatus)
                {
                    case "审核停止":
                        orderStatus = " and b.status_int in (3, 6) ";
                        break;
                    case "未停止":
                        orderStatus = " and b.status_int not in (3, 6) ";
                        break;
                    default:
                        orderStatus = "";
                        break;
                }
                if (this.chkHsYes.Checked)
                    isHs = "1";
                else if (this.chkHsNo.Checked)
                    isHs = "0";
                else
                    isHs = "";
                if (this.chkSfYes.Checked)
                    isSf = "1";
                else if (this.chkSfNo.Checked)
                    isSf = "0";
                else
                    isSf = "";
                using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                {
                    DataSource = svc.GetPretestMed(beginTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"), areaId, orderStatus, isHs, isSf, dateType);
                    this.dgvData.DataSource = DataSource;
                    this.SetRowBackColor();
                }
                DataSourceDept.Clear();
                this.cboDept.Items.Clear();
                List<string> lstDeptId = new List<string>();
                if (DataSource != null && DataSource.Count > 0)
                {
                    DataSourceDept.Add(new EntityDept() { deptId = "00", deptName = "全 院" });
                    EntityDept vo = null;
                    foreach (EntityPretestMed item in DataSource)
                    {
                        vo = new EntityDept();
                        vo.deptId = item.deptId;
                        vo.deptName = item.deptName;
                        if (lstDeptId.IndexOf(vo.deptId) < 0)
                        {
                            lstDeptId.Add(vo.deptId);
                            DataSourceDept.Add(vo);
                        }
                    }
                }
                foreach (EntityDept item in DataSourceDept)
                {
                    this.cboDept.Items.Add(item.deptName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 汇总
        /// <summary>
        /// 汇总
        /// </summary>
        void Sum()
        {
            if (this.cboSum.SelectedIndex == 0)
            {
                this.dgvData.DataSource = this.DataSource;
                this.SetRowBackColor();
            }
            else
            {
                List<string> lstOrderDicId = new List<string>();
                EntityPretestMed vo = null;
                List<EntityPretestMed> tmpDataSource = new List<EntityPretestMed>();
                // 按患者汇总
                if (this.cboSum.SelectedIndex == 1)
                {
                    for (int i = 0; i < this.DataSource.Count - 1; i++)
                    {
                        vo = new EntityPretestMed();
                        vo.patName = this.DataSource[i].patName;
                        vo.orderDicId = this.DataSource[i].orderDicId;
                        vo.orderName = this.DataSource[i].orderName;
                        vo.preAmount = this.DataSource[i].preAmount;
                        vo.unit = this.DataSource[i].unit;
                        if (lstOrderDicId.IndexOf(vo.patName + vo.orderDicId) >= 0) continue;

                        for (int j = i + 1; j < this.DataSource.Count - 1; j++)
                        {
                            if (vo.patName == this.DataSource[j].patName && vo.orderDicId == this.DataSource[j].orderDicId)
                            {
                                vo.preAmount += this.DataSource[j].preAmount;
                            }
                        }
                        tmpDataSource.Add(vo);
                        lstOrderDicId.Add(vo.patName + vo.orderDicId);
                    }
                }
                // 按科室汇总
                else if (this.cboSum.SelectedIndex == 2)
                {
                    for (int i = 0; i < this.DataSource.Count - 1; i++)
                    {
                        vo = new EntityPretestMed();
                        vo.deptName = this.DataSource[i].deptName;
                        vo.orderDicId = this.DataSource[i].orderDicId;
                        vo.orderName = this.DataSource[i].orderName;
                        vo.preAmount = this.DataSource[i].preAmount;
                        vo.unit = this.DataSource[i].unit;
                        if (lstOrderDicId.IndexOf(vo.deptName + vo.orderDicId) >= 0) continue;

                        for (int j = i + 1; j < this.DataSource.Count - 1; j++)
                        {
                            if (vo.deptName == this.DataSource[j].deptName && vo.orderDicId == this.DataSource[j].orderDicId)
                            {
                                vo.preAmount += this.DataSource[j].preAmount;
                            }
                        }
                        tmpDataSource.Add(vo);
                        lstOrderDicId.Add(vo.deptName + vo.orderDicId);
                    }
                }
                // 按项目汇总
                else if (this.cboSum.SelectedIndex == 3)
                {
                    for (int i = 0; i < this.DataSource.Count - 1; i++)
                    {
                        vo = new EntityPretestMed();
                        vo.orderDicId = this.DataSource[i].orderDicId;
                        vo.orderName = this.DataSource[i].orderName;
                        vo.preAmount = this.DataSource[i].preAmount;
                        vo.unit = this.DataSource[i].unit;
                        if (lstOrderDicId.IndexOf(vo.orderDicId) >= 0) continue;

                        for (int j = i + 1; j < this.DataSource.Count - 1; j++)
                        {
                            if (vo.orderDicId == this.DataSource[j].orderDicId)
                            {
                                vo.preAmount += this.DataSource[j].preAmount;
                            }
                        }
                        tmpDataSource.Add(vo);
                        lstOrderDicId.Add(vo.orderDicId);
                    }
                }
                int no = 0;
                foreach (EntityPretestMed item in tmpDataSource)
                {
                    item.sortNo = ++no;
                }
                this.dgvData.DataSource = tmpDataSource;
            }
        }
        #endregion

        #region 科室选择
        /// <summary>
        /// 科室选择
        /// </summary>
        void DeptSelected(int index)
        {
            string deptId = this.DataSourceDept[index].deptId;
            if (deptId == "00")
            {
                this.dgvData.DataSource = this.DataSource;
                this.SetRowBackColor();
            }
            else
            {
                List<EntityPretestMed> tmpDataSource = this.DataSource.FindAll(t => t.deptId == deptId);
                int no = 0;
                foreach (EntityPretestMed item in tmpDataSource)
                {
                    item.sortNo = ++no;
                }
                this.dgvData.DataSource = tmpDataSource;
            }
            SetRowBackColor();
        }
        #endregion

        #region 行选择
        /// <summary>
        /// 行选择
        /// </summary>
        void RowSelected()
        {
            if (this.cboSelect.SelectedIndex == 0 || this.cboSelect.SelectedIndex == 1)
            {
                for (int i = 0; i < this.dgvData.RowCount; i++)
                {
                    this.dgvData.Rows[i].Selected = (this.cboSelect.SelectedIndex == 0 ? false : true);
                }
            }
            else if (this.cboSelect.SelectedIndex == 2)
            {
                for (int i = 0; i < this.dgvData.RowCount; i++)
                {
                    this.dgvData.Rows[i].Selected = (this.dgvData.Rows[i].Selected ? false : true);
                }
            }
        }
        #endregion

        #region 确认回收
        /// <summary>
        /// 确认回收
        /// </summary>
        void Rec()
        {
            if (this.cboSum.SelectedIndex > 0)
            {
                MessageBox.Show("请先选择药品明细.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboSum.Focus();
                return;
            }
            List<string> lstPutMedId = new List<string>();
            for (int i = 0; i < this.dgvData.RowCount; i++)
            {
                if (this.dgvData.Rows[i].Selected && !string.IsNullOrEmpty(this.dgvData.Rows[i].Cells["putMedId"].Value.ToString()) && string.IsNullOrEmpty(this.dgvData.Rows[i].Cells["recopername"].Value.ToString()) &&
                   (this.dgvData.Rows[i].Cells["isPretestCharge"].Value == null || string.IsNullOrEmpty(this.dgvData.Rows[i].Cells["isPretestCharge"].Value.ToString())) &&
                   (this.dgvData.Rows[i].Cells["orderstatus"].Value.ToString().Trim() == "停止" || this.dgvData.Rows[i].Cells["orderstatus"].Value.ToString().Trim() == "审核停止"))
                {
                    lstPutMedId.Add(this.dgvData.Rows[i].Cells["putMedId"].Value.ToString());
                }
            }
            if (lstPutMedId.Count > 0)
            {
                frmPretestMedRec frm = new frmPretestMedRec(lstPutMedId, this.LoginInfo.m_strEmpNo);
                frm.ShowDialog();
                if (frm.IsSave)
                {
                    Query();
                }
            }
            else
            {
                MessageBox.Show("请选择可以回收的药品！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 颜色
        /// <summary>
        /// 颜色
        /// </summary>
        void SetRowBackColor()
        {
            string statusName = string.Empty;
            for (int i = 0; i < this.dgvData.RowCount; i++)
            {
                statusName = this.dgvData.Rows[i].Cells["orderStatus"].Value.ToString();
                if (statusName == "停止")
                {
                    this.dgvData.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                }
                else if (statusName == "作废")
                {
                    this.dgvData.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.OrangeRed;
                }

                if (this.dgvData.Rows[i].Cells["recStatus"].Value.ToString() == "已回收")
                {
                    this.dgvData.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                }
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmPretestMed_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptSelected(this.cboDept.SelectedIndex);
        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            RowSelected();
        }

        private void cboSum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Sum();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            this.Rec();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkHsNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHsNo.Checked)
                this.chkHsYes.Checked = false;
        }

        private void chkHsYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkHsYes.Checked)
                this.chkHsNo.Checked = false;
        }

        private void chkSfNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSfNo.Checked)
                this.chkSfYes.Checked = false;
        }

        private void chkSfYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSfYes.Checked)
                this.chkSfNo.Checked = false;
        }

        #endregion

    }
}
