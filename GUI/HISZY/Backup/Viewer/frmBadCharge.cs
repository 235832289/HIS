using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 呆帐结算UI
    /// </summary>
    public partial class frmBadCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmBadCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BadCharge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBadCharge_Load(object sender, EventArgs e)
        {
            this.ucPatientInfo.m_mthSetRedraw();
            this.ucPatientInfo.Status = 8;           
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                if (this.cboDeptClass.SelectedIndex == 0)
                {
                    ((clsCtl_BadCharge)this.objController).m_blnChargePatch();
                    ((clsCtl_BadCharge)this.objController).m_mthShowFeeCat(this.ucPatientInfo.RegisterID, 1);
                }
                else
                {
                    this.cboDeptClass.SelectedIndex = 0;
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthFind();
        }

        private void frmBadCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthShortCut(e);
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                if (this.cboDeptClass.SelectedIndex == 0)
                {
                    ((clsCtl_BadCharge)this.objController).m_blnChargePatch();
                    ((clsCtl_BadCharge)this.objController).m_mthShowFeeCat(this.ucPatientInfo.RegisterID, 1);
                }
                else
                {
                    this.cboDeptClass.SelectedIndex = 0;
                }
            }
        }
              
        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthCharge();            
        }

        private void cboDeptClass_SelectedIndexChanged(object sender, EventArgs e)
        { 
            if (this.ucPatientInfo.RegisterID.Trim() != "")
            {
                ((clsCtl_BadCharge)this.objController).m_mthShowFeeCat(this.ucPatientInfo.RegisterID, this.cboDeptClass.SelectedIndex + 1);
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            ((clsCtl_BadCharge)this.objController).m_mthCompute();
        }

        private void btnRepeatPrt_Click(object sender, EventArgs e)
        {
            string RegID = this.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRepeatPrt finvoprt = new frmInvoiceRepeatPrt(RegID);
            finvoprt.ShowDialog();
        }             
    }
}