using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院信息
    /// </summary>
    public partial class frmUpdateHospitalInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        internal bool m_cancle = false;

        #region 构造
        public frmUpdateHospitalInfo()
        {
            InitializeComponent();
        }
        #endregion

        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_UpdateHospitalInfo();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 根据入院登记ID获取病人住院信息
        private void m_cmdfind_Click(object sender, EventArgs e)
        {
            //frmCommonFind frm = new frmCommonFind();
            //frm.ShowDialog();
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    ((clsCtl_UpdateHospitalInfo)objController).m_mthGetBIHPatientInfo(frm.RegisterID);
            //}
            ((clsCtl_UpdateHospitalInfo)this.objController).FindPatient();
        }
        #endregion

        #region 撤消入院
        private void cmdCancle_Click(object sender, EventArgs e)
        {
            ((clsCtl_UpdateHospitalInfo)objController).m_mthCancleInHospital();
        }
        #endregion

        private void buttonXP1_Click(object sender, EventArgs e)
        {
           

             ((clsCtl_UpdateHospitalInfo)objController).m_mthChangePatientIDOth();
            
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
             ((clsCtl_UpdateHospitalInfo)objController).m_mthChangePatientIDOth2();
        }

        private void buttonXP3_Click(object sender, EventArgs e)
        {
            ((clsCtl_UpdateHospitalInfo)objController).m_mthChangePatientIDOth3();
        }

        private void buttonXP4_Click(object sender, EventArgs e)
        {
            ((clsCtl_UpdateHospitalInfo)objController).m_mthChangePatientIDOth4();
        }

        private void frmUpdateHospitalInfo_Load(object sender, EventArgs e)
        {
            ((clsCtl_UpdateHospitalInfo)this.objController).FindPatient();
        }

        private void frmUpdateHospitalInfo_Layout(object sender, LayoutEventArgs e)
        {
            if (m_cancle)
                this.Close();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateHospitalInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }

        private void m_ucPatientInfo_ZyhChanged()
        {
            //this.m_objViewer.cmdCancle.Enabled = true;
        }

        private void m_ucPatientInfo_CardNOChanged()
        {
            //this.m_objViewer.cmdCancle.Enabled = true;
        }
    }
}