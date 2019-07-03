using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �޸�סԺ��Ϣ - �߼�����
    /// </summary>
    class clsCtlModifyOutDate : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ��������
        clsDclBihLeaHos m_objManage = null;
        /// <summary>
        /// ���˳�Ժ��ϢVO
        /// </summary>
        clsT_Opr_Bih_Leave_VO p_objRrecord;
       
        private frmCommonFind m_commonFind = new frmCommonFind();

        #endregion

        #region ���캯��
        public clsCtlModifyOutDate()
        {
            m_objManage = new clsDclBihLeaHos();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmModifyOutDate m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmModifyOutDate)frmMDI_Child_Base_in;
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ����Ԥ��Ժ��Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ����Ԥ��Ժ��Ϣ
        /// </summary>
        public void GetPatientPreLeaveInfo()
        {
            if (this.m_objViewer.m_ucPatientInfo.BihPatient_VO.RegisterID == "" || this.m_objViewer.m_ucPatientInfo.Status != 2)
            {
                this.m_objViewer.m_ucPatientInfo.m_mthReset();
                return;
            }

            p_objRrecord = null;
            long lngRes = m_objManage.GetPreLeaveByRegisterID(this.m_objViewer.m_ucPatientInfo.BihPatient_VO.RegisterID, out p_objRrecord);
            if (lngRes > 0 && p_objRrecord != null)
            {
                if (p_objRrecord.m_strOUTHOSPITAL_DAT != null && p_objRrecord.m_strOUTHOSPITAL_DAT != "")
                {
                    this.m_objViewer.m_dtpOldDate.Value = Convert.ToDateTime(p_objRrecord.m_strOUTHOSPITAL_DAT);
                    this.m_objViewer.m_txtRemark.Text = p_objRrecord.m_strDES_VCHR;
                }
                
            }
            else
            {
                MessageBox.Show("�Բ���,�Ҳ����ò��˵�Ԥ��Ժ��Ϣ��", "���Ҳ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ������Ϣ
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public void SavePreLeaveInfo()
        {
            if (p_objRrecord == null)
            {
                return;
            }

            DateTime newDate = this.m_objViewer.m_dtpNewDate.Value;
            if (newDate < Convert.ToDateTime(this.m_objViewer.m_ucPatientInfo.BihPatient_VO.InHospitalDate))
            {
                MessageBox.Show("��Ժ���ڲ���������Ժ���ڣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_dtpNewDate.Focus();
                return;
            }

            if (newDate > DateTime.Now)
            {
                MessageBox.Show("��Ժ���ڲ��ܴ��ڴ��ڵ�ǰʱ�䣡", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_dtpNewDate.Focus();
                return;
            }

            if (this.m_objViewer.m_txtRemark.Text == null || this.m_objViewer.m_txtRemark.Text.Trim() == "")
            {
                MessageBox.Show("��ע��Ϣ����Ϊ�գ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtRemark.Focus();
                return;
            }

            bool hasCharge = false;
            m_objManage.IfHasCharge(this.m_objViewer.m_ucPatientInfo.BihPatient_VO.RegisterID,
                                    newDate.ToString(),
                                    p_objRrecord.m_strOUTHOSPITAL_DAT,
                                    out hasCharge);
            if (hasCharge)
            {
                if (MessageBox.Show("�����ڶ��Ѳ������ã��Ƿ��޸�Ԥ��Ժ���ڣ�", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    this.m_objViewer.m_dtpNewDate.Focus();
                    return;
                }
            }

            p_objRrecord.m_strOPERATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            p_objRrecord.m_strDES_VCHR = this.m_objViewer.m_txtRemark.Text.Trim();
            long lngRes = m_objManage.ModifyLeaveDate(newDate, p_objRrecord);
            if (lngRes > 0 )
            {
                if (hasCharge)
                {
                    MessageBox.Show("��Ժ���ڳɹ��޸�Ϊ��" + newDate.ToShortDateString() + "; �뼰ʱ������˷��ã�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("��Ժ���ڳɹ��޸�Ϊ��" + newDate.ToShortDateString(), "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                SaveEditLog();

                ResetView();
            }
            else
            {
                MessageBox.Show("����ʧ�ܣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        private void ResetView()
        {
            this.m_objViewer.m_ucPatientInfo.m_mthReset();
            this.m_objViewer.m_txtRemark.Text = "";
            this.m_objViewer.m_dtpNewDate.Value = DateTime.Now;
            this.m_objViewer.m_dtpOldDate.Value = DateTime.Now;
        }

        private void SaveEditLog()
        {
            clsPatientInfLog patientLogVo = new clsPatientInfLog();
            patientLogVo.operatorId = this.m_objViewer.LoginInfo.m_strEmpID;
            patientLogVo.registerId = this.m_objViewer.m_ucPatientInfo.RegisterID;
            patientLogVo.desc = "";

            clsDcl_BIHTransfer m_objTran = new clsDcl_BIHTransfer();

            patientLogVo.detail = "��Ժ���ڣ�" + this.m_objViewer.m_dtpOldDate.Value.ToShortDateString() + "--> " + this.m_objViewer.m_dtpNewDate.Value.ToShortDateString()
                + "; " + this.m_objViewer.m_txtRemark.Text.Trim();

            m_objTran.AddPatienInfLog(patientLogVo);
           
        }
    }
}
