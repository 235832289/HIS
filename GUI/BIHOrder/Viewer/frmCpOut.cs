using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 出径
    /// </summary>
    public partial class frmCpOut : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmCpOut(clsBIHPatientInfo _patVo)
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
        /// Var.DataSource
        /// </summary>
        internal DataTable OutCriterionDataSource { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        internal bool IsSuccess { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable tmp = svc.GetCpExecPlan(this.patVo.m_strRegisterID);
            ExecPlanDataSource = tmp.Rows[0];
            OutCriterionDataSource = svc.GetOutCriterion(Convert.ToInt32(this.ExecPlanDataSource["cpid"].ToString()));
            this.clstTarget.Items.Clear();
            if (OutCriterionDataSource != null && OutCriterionDataSource.Rows.Count > 0)
            {
                foreach (DataRow dr in OutCriterionDataSource.Rows)
                {
                    this.clstTarget.Items.Add(dr["criinfo"].ToString());
                }
            }
            this.lblCpName.Text = this.ExecPlanDataSource["cpname"].ToString();
            this.lblDeptName.Text = this.patVo.m_strDeptName;
            this.lblBedNo.Text = this.patVo.m_strBedName + "床";
            this.lblPatName.Text = this.patVo.m_strPatientName;
            this.lblIpNo.Text = this.patVo.m_strInHospitalNo;
        }
        #endregion

        #region Save
        /// <summary>
        /// Save
        /// </summary>
        void Save()
        {
            EntityCpOut outVo = new EntityCpOut();
            List<EntityCpOutCriDetail> lstOutCri = new List<EntityCpOutCriDetail>();

            outVo.outid = Convert.ToDecimal(ExecPlanDataSource["execid"].ToString());
            outVo.doctid = this.patVo.m_strDOCTORID_CHR;
            outVo.registerid = this.patVo.m_strRegisterID;
            outVo.outdate = Convert.ToDateTime(this.dtpOutDate.Text);
            if (this.chkOutType1.Checked)
                outVo.outtype = 1;
            else if (this.chkOutType2.Checked)
                outVo.outtype = 2;
            if (this.chkEva1.Checked)
                outVo.evaluation = 1;
            else if (this.chkEva2.Checked)
                outVo.evaluation = 2;
            else if (this.chkEva3.Checked)
                outVo.evaluation = 3;
            else if (this.chkEva4.Checked)
                outVo.evaluation = 4;
            outVo.outinfo = this.txtResult.Text.Trim();
            outVo.operid = this.LoginInfo.m_strEmpID;
            outVo.operdate = DateTime.Now;
            outVo.status = 1;

            if (outVo.outtype == 0)
            {
                MessageBox.Show("请选择出径类型。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.chkOutType1.Focus();
                return;
            }
            if (outVo.evaluation == 0)
            {
                MessageBox.Show("请选择疗效评价。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.chkEva1.Focus();
                return;
            }
            if (outVo.outinfo == string.Empty)
            {
                MessageBox.Show("请输入出径验证结果。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtResult.Focus();
                return;
            }

            List<EntityCpOutCriDetail> lstVo = new List<EntityCpOutCriDetail>();
            if (this.clstTarget.CheckedItems.Count > 0)
            {
                EntityCpOutCriDetail vo = null;
                for (int i = 0; i < this.clstTarget.CheckedItems.Count; i++)
                {
                    vo = new EntityCpOutCriDetail();
                    vo.cricontent = this.clstTarget.CheckedItems[i].ToString();
                    lstVo.Add(vo);
                }
            }

            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            if (svc.SaveCpOutEvaluation(outVo, lstVo) > 0)
            {
                this.IsSuccess = true;
                MessageBox.Show("保存出径评估成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存出径评估失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #endregion

        #region 事件

        private void frmCpOut_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkOutType1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOutType1.Checked) this.chkOutType2.Checked = false;
        }

        private void chkOutType2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOutType2.Checked) this.chkOutType1.Checked = false;
        }

        private void chkEva1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva1.Checked)
            {
                this.chkEva2.Checked = false;
                this.chkEva3.Checked = false;
                this.chkEva4.Checked = false;
            }
        }

        private void chkEva2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva2.Checked)
            {
                this.chkEva1.Checked = false;
                this.chkEva3.Checked = false;
                this.chkEva4.Checked = false;
            }
        }

        private void chkEva3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva3.Checked)
            {
                this.chkEva1.Checked = false;
                this.chkEva2.Checked = false;
                this.chkEva4.Checked = false;
            }
        }

        private void chkEva4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkEva4.Checked)
            {
                this.chkEva1.Checked = false;
                this.chkEva2.Checked = false;
                this.chkEva3.Checked = false;
            }
        }

        #endregion

    }
}
