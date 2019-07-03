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
    /// 出院结算UI
    /// </summary>
    public partial class frmLeaveCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmLeaveCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_LeaveCharge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLeaveCharge_Load(object sender, EventArgs e)
        {
            this.ucPatientInfo.m_mthSetRedraw();
            this.ucPatientInfo.Status = 8;

            //if (clsPublic.m_strGetSysparm("1000") == "001")
            //{
            //    this.btnYb.Visible = true;
            //}
            //else
            //{
                  this.btnYb.Visible = false;
            //}
            this.dtgDetail.AutoGenerateColumns = false;
            ((clsCtl_LeaveCharge)this.objController).m_mthInt();
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            { 
                ((clsCtl_LeaveCharge)this.objController).m_mthShowAllFeeDetail(this.ucPatientInfo.RegisterID);               
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthFind();
        }

        private void frmLeaveCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthShortCut(e);
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {                
                ((clsCtl_LeaveCharge)this.objController).m_mthShowAllFeeDetail(this.ucPatientInfo.RegisterID);                
            }
        }
              
        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthCharge();
        }              

        private void btnRepeatPrt_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthRepeatPrt();
        }

        private void btnRefundment_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthRefundment();
        }

        private void btnYb_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthDownLoadYBData();
        }

        private void dtgDetail_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthSetRowColor();
        }

        private void btnYBCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_LeaveCharge)this.objController).m_mthYBPrintBillDet();
        }
    }
}