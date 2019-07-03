using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 疗程用药审核
    /// </summary>
    public partial class frmConfirmCureDays : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmConfirmCureDays()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// 数据源
        /// </summary>
        List<EntityCureMed> DataSource { get; set; }

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
                this.Cursor = Cursors.WaitCursor;
                using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                {
                    DataSource = svc.GetCureMed(beginTime.ToString("yyyy-MM-dd HH:mm:ss"), endTime.ToString("yyyy-MM-dd HH:mm:ss"));
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
                    foreach (EntityCureMed item in DataSource)
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
                EntityCureMed vo = null;
                List<EntityCureMed> tmpDataSource = new List<EntityCureMed>();
                // 按患者汇总
                if (this.cboSum.SelectedIndex == 1)
                {
                    for (int i = 0; i < this.DataSource.Count - 1; i++)
                    {
                        vo = new EntityCureMed();
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
                        vo = new EntityCureMed();
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
                        vo = new EntityCureMed();
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
                foreach (EntityCureMed item in tmpDataSource)
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
                List<EntityCureMed> tmpDataSource = this.DataSource.FindAll(t => t.deptId == deptId);
                int no = 0;
                foreach (EntityCureMed item in tmpDataSource)
                {
                    item.sortNo = ++no;
                }
                this.dgvData.DataSource = tmpDataSource;
            }
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

        #region 确认
        /// <summary>
        /// 确认 
        /// </summary>
        void Confirm()
        {
            if (this.cboSum.SelectedIndex > 0)
            {
                MessageBox.Show("请先选择药品明细.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboSum.Focus();
                return;
            }
            EntityCureMed vo = null;
            List<EntityCureMed> lstOrder = new List<EntityCureMed>();
            for (int i = 0; i < this.dgvData.RowCount; i++)
            {
                if (this.dgvData.Rows[i].Selected && !string.IsNullOrEmpty(this.dgvData.Rows[i].Cells["orderId"].Value.ToString()) && string.IsNullOrEmpty(this.dgvData.Rows[i].Cells["checkOperName"].Value.ToString()))
                {
                    vo = new EntityCureMed();
                    vo.orderId = this.dgvData.Rows[i].Cells["orderId"].Value.ToString();
                    vo.orderName = this.dgvData.Rows[i].Cells["orderName"].Value.ToString();
                    vo.execDeptId = this.dgvData.Rows[i].Cells["execDeptId"].Value.ToString();
                    vo.preAmount = Convert.ToDecimal(this.dgvData.Rows[i].Cells["preAmount"].Value.ToString());
                    vo.registerId = this.dgvData.Rows[i].Cells["registerId"].Value.ToString();
                    lstOrder.Add(vo);
                }
            }
            if (lstOrder.Count > 0)
            {
                frmConfirmCureDaysPopup frm = new frmConfirmCureDaysPopup(lstOrder);
                frm.ShowDialog();
                if (frm.IsSave)
                {
                    Query();
                }
            }
            else
            {
                MessageBox.Show("请选择需要确认的疗程用药.药品！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                statusName = this.dgvData.Rows[i].Cells["checkState"].Value.ToString();
                if (statusName == "通过")
                {
                    this.dgvData.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.PaleGreen;
                }
                else if (statusName == "不通过")
                {
                    this.dgvData.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.Tomato;
                }
            }
        }
        #endregion

        #endregion

        #region 事件

        private void frmConfirmCureDays_Load(object sender, EventArgs e)
        {
            this.DataSourceDept = new List<EntityDept>();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Confirm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DeptSelected(this.cboDept.SelectedIndex);
        }

        private void cboSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.RowSelected();
        }

        private void cboSum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Sum();
        }




        #endregion

    }
}
