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
    public partial class frmCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmCharge()
        {
            InitializeComponent();
        }

        #region 变量
        /// <summary>
        /// 结帐类型 0 普通结帐 1 出院结帐 
        /// </summary>
        internal string ChargeType = "";
        #endregion

        #region 外部接口
        /// <summary>
        /// 外部接口
        /// </summary>
        /// <param name="p_Type"></param>
        public void m_mthShow(string p_Type)
        {
            ChargeType = p_Type;
            this.Show();
        }
        #endregion

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_Charge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCharge_Load(object sender, EventArgs e)
        {
            clsPublic.SuspendLayout(ucPatientInfo.Handle);
            ((clsCtl_Charge)this.objController).m_mthInit();

            if (ChargeType == "1")
            {
                this.Text = "结帐管理窗口 … 出院结帐";
            }
            else
            {
                this.Text = "结帐管理窗口 … 普通结帐";
            }
            this.timer.Enabled = true;
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_Charge)this.objController).m_mthGetData();
            }
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_Charge)this.objController).m_mthGetData();
            }
        }   

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_Charge)this.objController).m_mthFind();
        }

        private void frmCharge_KeyDown(object sender, KeyEventArgs e)
        {
            ((clsCtl_Charge)this.objController).m_mthShortCut(e);
        }

        private void btnInitSort_Click(object sender, EventArgs e)
        {
            if (((clsCtl_Charge)this.objController).dtSource.Rows.Count > 0)
            {
                clsPublic.PlayAvi("findFILE.avi", "正在重整顺序，请稍候...");
                ((clsCtl_Charge)this.objController).m_mthFillData(((clsCtl_Charge)this.objController).dtSource);
                clsPublic.CloseAvi();
            }
        }

        private void btnCharge_Click(object sender, EventArgs e)
        {
            ((clsCtl_Charge)this.objController).m_mthCharge();
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            if (this.ucPatientInfo.RegisterID == "")
            {
                MessageBox.Show("请选择病人。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);              
            }
            else
            {
                ((clsCtl_Charge)this.objController).m_mthPatchDayAccount();
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((clsCtl_Charge)this.objController).m_mthUpdateCheckStatus("1");
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((clsCtl_Charge)this.objController).m_mthUpdateCheckStatus("2");
        }

        private void btnCheckStatus_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(this.btnCheckStatus, new Point(this.btnCheckStatus.Width, this.btnCheckStatus.Height));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            clsPublic.ResumeLayout(ucPatientInfo.Handle);
            ucPatientInfo.Invalidate();
            ucPatientInfo.Refresh();
        }                 
       
    }
}