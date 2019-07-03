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
    //need modify
    public partial class frmYBChargeZY : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBChargeZY()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBChargeZY();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// HIS医疗费用总金额
        /// </summary>
        public decimal decTotal = 0;
        /// <summary>
        /// 结算类型  1 出院结算 2 中途结算3 预结算
        /// </summary>
        public string strJslx = "1";
        /// <summary>
        /// 发票号码
        /// </summary>
        public string strInvNo = string.Empty;
        /// <summary>
        /// 医保结算返回的自费金额
        /// </summary>
        public decimal decYBSub = 0;
        /// <summary>
        /// 操作员工号
        /// </summary>
        public string strEmpNo = string.Empty;
        /// <summary>
        /// 病人住院ID
        /// </summary>
        public string strRegisterId = string.Empty;
        /// <summary>
        /// 结算起始日期
        /// </summary>
        public string strJSQSRQ = string.Empty;
        /// <summary>
        /// 结算终止日期
        /// </summary>
        public string strJSZZRQ = string.Empty;
        #region 获取药品让利开关 Add by 吴汉明 2014-12-25
        public bool m_blnDiffCostOn = false;
        #endregion

        /// <summary>
        /// 费用流水ID.中途结算
        /// </summary>
        public List<string> lstPChargeId = new List<string>();

        private void frmYBChargeZY_Load(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_YBChargeZY)this.objController).m_lngCheckDiagnose();
            if (lngRes == 0)
            {
                if (MessageBox.Show("该病人没有填写出院诊断，是否继续结算？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    ((clsCtl_YBChargeZY)this.objController).blnIfDefaultCYZD = true;
                }
                else
                {
                    this.Close();
                }
            }
            ((clsCtl_YBChargeZY)this.objController).m_mthInit();
            ((clsCtl_YBChargeZY)this.objController).m_blnDiffCostOn = this.m_blnDiffCostOn;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).m_mthUpload();
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            //strJslx = "1";//出院结算
            ((clsCtl_YBChargeZY)this.objController).m_mthYBCharge(true);
        }

        private void btnCYDJ_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).m_mthYBCydj();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChargetest_Click(object sender, EventArgs e)
        {
            //strJslx = "3";//社保试算
            ((clsCtl_YBChargeZY)this.objController).m_mthYBCharge(false);
        }

        private void lblCancelUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).m_mthCancelUpload();
        }

        private void lblCancelCharge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).m_mthCancelYBCharge();
        }

        private void btnModifyReg_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).m_mthModifyReg();
        }

        private void btnCheckPsw_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).m_mthCheckPsw();
        }

        private void llblKsydkjy_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_YBChargeZY)this.objController).Ksydkjy();
        }
    }

}