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
    /// <summary>
    /// 发药确认窗口
    /// </summary>
    public partial class frmSendMedicineConfirm : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmSendMedicineConfirm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置窗体控制类


        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControlSendMedicineConfirm();
            this.objController.Set_GUI_Apperance(this);
        }
        private com.digitalwave.iCare.gui.HIS.clsControlOPMedStore m_objOPMedStoreControl;
        /// <summary>
        /// 配药员工号


        /// </summary>
        public string m_strDispenseNO=string.Empty;
        /// <summary>
        /// 配药员姓名

        /// </summary>
        public string m_strDispenseName=string.Empty;
        /// <summary>
        /// 发药员id
        /// </summary>
        public string m_strSendMedEMPID=string.Empty;
        /// <summary>
        /// 发药员工姓名
        /// </summary>
        public string m_strSendMedName=string.Empty;
        /// <summary>
        /// 当前登录者的部门ＩＤ
        /// </summary>
        public string m_strDeptID;

        public void m_mthGetOPMedStoreControl(clsControlOPMedStore m_objControl)
        {
            this.m_objOPMedStoreControl = m_objControl;
            this.ShowDialog();
        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSendMedicineConfirm_Load(object sender, EventArgs e)
        {
            this.m_strDeptID = this.LoginInfo.m_strDepartmentID;
            this.m_txtDispenseID.Enabled = true;
            this.m_txtSendMedID.Enabled = true;
            this.m_txtDispenseID.Focus();
        }

        private void m_txtDispenseID_KeyDown(object sender, KeyEventArgs e)
        {　　
            if (e.KeyCode == Keys.Enter)
            {
                if (((clsControlOPMedStore)this.m_objOPMedStoreControl).m_strServerNO == string.Empty)
                {
                    MessageBox.Show(this, "请先选择一个病人！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                if (this.m_txtDispenseID.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(this, "请输入配药师的科室自编码！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.m_txtDispenseID.Focus();
                    return;
                }
                ((clsControlSendMedicineConfirm)this.objController).m_mthJudgeEMP(this.m_strDeptID, this.m_txtDispenseID.Text.Trim(),ref m_strDispenseNO,ref m_strDispenseName);
                if (m_strDispenseNO.Trim() == string.Empty)
                {
                    MessageBox.Show(this, "不存在该科室自编码，请重新输入！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.m_txtDispenseID.Focus();
                    return;
                }
                this.m_txtSendMedID.Focus();
            }
        }

        private void m_txtSendMedID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_txtSendMedID.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(this, "请输入发药员的工号！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.m_txtSendMedID.Focus();
                    return;
                }
      
               ((clsControlSendMedicineConfirm)this.objController).m_mthJudgeEMPByEMPNO(this.m_txtSendMedID.Text.Trim(),ref m_strSendMedEMPID,ref m_strSendMedName);
                if (this.m_strSendMedEMPID.Trim() == string.Empty)
                {
                    MessageBox.Show(this, "不存在该员工工号，请重新输入！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.m_txtSendMedID.Focus();
                    return;
                }
                this.m_txtServerNo.Focus();
            }
        }

        private void m_txtServerNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_txtServerNo.Text.Trim() == string.Empty)
                {
                    MessageBox.Show(this, "请输入该病人的当天流水号！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.m_txtServerNo.Focus();
                    return;
                }
                this.m_txtServerNo.Text = this.m_txtServerNo.Text.Trim().PadLeft(4, '0');
                if (this.m_txtServerNo.Text != ((clsControlOPMedStore)this.m_objOPMedStoreControl).m_strServerNO)
                {
                    if (((clsControlOPMedStore)this.m_objOPMedStoreControl).m_strServerNO == string.Empty)
                    {
                        MessageBox.Show(this, "请先选择一个病人！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show(this, "输入的流水号与所选择的病人的流水号不一致，请重新输入！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    }
                    this.m_txtServerNo.Focus();
                    return;

                }
                this.m_btnConfirm.Focus();
            }
        }

        private void m_btnConfirm_Click(object sender, EventArgs e)
        {
            //if (this.m_txtDispenseID.Text.Trim() == string.Empty)
            //{
            //    MessageBox.Show(this, "请输入配药师的科室自编码！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            //    this.m_txtDispenseID.Focus();
            //    return;
            //}
            if (this.m_txtSendMedID.Text.Trim() == string.Empty)
            {
                MessageBox.Show(this, "请输入发药员的工号！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.m_txtSendMedID.Focus();
                return;
            }
            if (this.m_txtServerNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show(this, "请输入该病人的当天流水号！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.m_txtServerNo.Focus();
                return;
            }
            if (this.m_txtServerNo.Text != ((clsControlOPMedStore)this.m_objOPMedStoreControl).m_strServerNO)
            {
                if (((clsControlOPMedStore)this.m_objOPMedStoreControl).m_strServerNO == string.Empty)
                {
                    MessageBox.Show(this, "请先选择一个病人！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(this, "输入的流水号与所选择的病人的流水号不一致，请重新输入！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                this.m_txtServerNo.Focus();
                return;

            }
            //clsEmployeeVO m_objDispenseEmp = new clsEmployeeVO();
            //m_objDispenseEmp.strEmpID = this.m_strDispenseNO;
            //m_objDispenseEmp.strName = this.m_strDispenseName;
            //clsEmployeeVO m_objSendMedEmp = new clsEmployeeVO();
            //m_objSendMedEmp.strEmpID = this.m_strSendMedNO;
            //m_objSendMedEmp.strName = this.m_strSendMedName;
            //((clsControlOPMedStore)this.m_objOPMedStoreControl).m_mthGetEmployeeData(m_objDispenseEmp, m_objSendMedEmp);
            ((clsControlOPMedStore)this.m_objOPMedStoreControl).m_getData(this.m_strSendMedEMPID, this.m_strSendMedName, false, "1");
            this.Close();
        }
    }
}