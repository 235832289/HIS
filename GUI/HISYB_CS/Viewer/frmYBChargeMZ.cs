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
    public partial class frmYBChargeMZ :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmYBChargeMZ()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_YBChargeMZ();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 处方总金额 HIS
        /// </summary>
        public decimal decTotal = 0;
        /// <summary>
        /// 处方ID
        /// </summary>
        public string strRecipeID = string.Empty;
        /// <summary>
        /// 病人卡号
        /// </summary>
        public string strPatientCardNo = string.Empty;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string strPatientName = string.Empty;
        /// <summary>
        /// 操作员工
        /// </summary>
        public string strEmpNo = string.Empty;
        /// <summary>
        /// 发票号
        /// </summary>
        public string strInvNO = string.Empty;
        /// <summary>
        /// 结算序号
        /// </summary>
        public string strSDYWH = string.Empty;
        /// <summary>
        /// 就诊记录号
        /// </summary>
        public string strJZJLH = string.Empty;
        /// <summary>
        /// 处方总金额 医保返回的
        /// </summary>
        public decimal decYBTotal = 0;
        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal decAcc = 0;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal decSub = 0;
        /// <summary>
        /// 公民身份证号码
        /// </summary>
        public string strIDCardNo = string.Empty;
        /// <summary>
        /// 补充医疗（1）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF1 = 0;
        /// <summary>
        /// 补充医疗（2）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF2 = 0;
        /// <summary>
        /// 补充医疗（3）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF3 = 0;
        /// <summary>
        /// 补充医疗（4）统筹支付
        /// </summary>
        public decimal m_decBCYLTCZF4 = 0;
        /// <summary>
        /// 其他支付
        /// </summary>
        public decimal m_decQTZHIFU = 0;
        /// <summary>
        /// 医保记账发票金额
        /// </summary>
        public decimal m_decYBJZFPJE = 0;
        /// <summary>
        /// 凑整费
        /// </summary>
        public decimal m_decCZF = 0;
        /// <summary>
        /// 处方明细
        /// </summary>
        public List<clsDGMzxmcs_VO> lstDGMzxmcsVo = new List<clsDGMzxmcs_VO>();

        /// <summary>
        /// 是否生育保险
        /// </summary>
        public bool IsBirthInsurance = false;

        private void frmYBChargeMZ_Load(object sender, EventArgs e)
        {
            //need modify判断是否享受医保待遇，如不享受显示原因，并且下面除了退出按钮其他为灰色。
            ((clsCtl_YBChargeMZ)this.objController).m_mthInit();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeMZ)this.objController).m_mthRecipeUpload();
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeMZ)this.objController).m_mthMzybjs();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("成功！请进行HIS结算！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            this.DialogResult = DialogResult.OK;
        }

        private void lblCancelUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_YBChargeMZ)this.objController).m_mthUndoRecipeUpload();
        }

        private void lblCancelCharge_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ((clsCtl_YBChargeMZ)this.objController).m_mthUndoMzybjs();
        }

        private void btnCheckPsw_Click(object sender, EventArgs e)
        {
            ((clsCtl_YBChargeMZ)this.objController).m_mthCheckPsw();
        }
    }

}