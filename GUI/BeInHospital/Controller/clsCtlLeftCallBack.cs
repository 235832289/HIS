using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtlLeftCallBack : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsT_Opr_Bih_Leave_VO m_leaveVO = new clsT_Opr_Bih_Leave_VO();
        private frmCommonFind m_commonFind = new frmCommonFind();

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmLeftCallBack m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmLeftCallBack)frmMDI_Child_Base_in;
        }
        #endregion

        #region 
        public void FindPatient()
        {
            string zyh = "";
            //frmm_commonFind f = new frmm_commonFind();
            if (m_commonFind.ShowDialog() == DialogResult.OK)
            {
                zyh = m_commonFind.Zyh;
                this.m_objViewer.m_ucPatientInfo.Status = 0;
                this.m_objViewer.m_ucPatientInfo.m_mthFind(zyh, 2);

                string status = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Status.ToString().Trim();
                string registerId = this.m_objViewer.m_ucPatientInfo.RegisterID;

                if (status != "2" && status != "3")
                {
                    MessageBox.Show("�ò�����δ��Ժ������Ҫ�ٻء�", "��ʾ");
                    this.m_objViewer.m_cmdRecall.Visible = false;
                    FindPatient();
                    return;
                }
                
                if (this.m_objViewer.m_ucPatientInfo.BihPatient_VO.FeeStatus == 3)
                {
                    MessageBox.Show("�ò��������ˣ�����ע����Ʊ��", "��ʾ");
                    this.m_objViewer.Hide();
                    this.m_objViewer.m_cancle = true;
                    return;
                }

                //��ȡ��Ժ��¼
                if (status == "2")
                {
                    //Ԥ��Ժ
                    GetLeaveByRegisterID(registerId, "0");
                }
                else
                {
                    //��ʽ��Ժ
                    GetLeaveByRegisterID(registerId, "1");
                }
            }
            else
            {
                this.m_objViewer.Hide();
                this.m_objViewer.m_cancle = true;
                return;
            }
        }
        #endregion

        #region ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч��Ԥ��Ժ��¼
        /// <summary>
        /// ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч��Ԥ��Ժ��¼
        /// </summary>
        /// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        private void GetLeaveByRegisterID(string p_strRegisterid, string p_pstatus)
        {
            clsDclBihLeaHos domain = new clsDclBihLeaHos();
            long lngRe = 0;
            lngRe = domain.GetLeaveByRegisterID(p_strRegisterid, p_pstatus, out this.m_leaveVO);
            if (lngRe < 1 || m_leaveVO == null)
            {
                MessageBox.Show("�����Ҳ������˵ĳ�Ժ��¼��", "��ʾ");
                this.m_objViewer.m_cmdRecall.Visible = false;
            }
        }
        #endregion 

        #region ��Ժ�ٻ�
        public void LeftCallBack()
        {
            long lngReg = 0;
            try
            {
                clsDclBihLeaHos domain = new clsDclBihLeaHos();

                lngReg = domain.RecallHospital(this.m_leaveVO, this.m_objViewer.LoginInfo.m_strEmpID);
            }
            catch (Exception e)
            {
                MessageBox.Show(m_objViewer, e.Message, "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //���������ʾ
            if (lngReg > 0)
            {
                MessageBox.Show(m_objViewer, "�ɹ��ٻ�!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.Close();
            }
            else
            {
                MessageBox.Show(m_objViewer, "�ٻ�ʧ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion
    }
}
