using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �޸�סԺ��Ϣ - �߼�����
    /// </summary>
    class clsCtl_UpdateHospitalInfo : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ��������
        clsDcl_BIHTransfer m_objManage = null;
        /// <summary>
        /// ����סԺ��ϢVO
        /// </summary>
        clsBIHpatientVO p_objRrecord;
        /// <summary>
        /// Ԥ�������
        /// </summary>
        decimal decBalance = 0;
        /// <summary>
        /// δ�����
        /// </summary>
        decimal decUnclearCharge = 0;

        private frmCommonFind m_commonFind = new frmCommonFind();

        #endregion

        #region ���캯��
        public clsCtl_UpdateHospitalInfo()
        {
            m_objManage = new clsDcl_BIHTransfer();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmUpdateHospitalInfo m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmUpdateHospitalInfo)frmMDI_Child_Base_in;
        }
        #endregion

        #region ������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ
        /// <summary>
        /// ������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        public void m_mthGetBIHPatientInfo(string p_strRegisterID)
        {
            p_objRrecord = null;
            decBalance = 0;
            decUnclearCharge = 0;
            long lngRes = m_objManage.m_lngGetBIHPatientInfoAndCharge(p_strRegisterID, out p_objRrecord);
            if (lngRes > 0 && p_objRrecord != null)
            {
                if (p_objRrecord.m_strUnclearCharge != "" && p_objRrecord.m_strUnclearCharge == null)
                {
                    decUnclearCharge = Convert.ToDecimal(p_objRrecord.m_strUnclearCharge);
                }
                if (p_objRrecord.m_strBalance != "" && p_objRrecord.m_strBalance == null)
                {
                    decBalance = Convert.ToDecimal(p_objRrecord.m_strBalance);
                }

                //this.m_objViewer.cmdCancle.Enabled = true;
                //m_objViewer.m_txtName.Text = p_objRrecord.m_strNAME_VCHR;
                //m_objViewer.m_txtInHospitalID.Text = p_objRrecord.m_strINPATIENTID_CHR;
                //m_objViewer.m_txtSex.Text = p_objRrecord.m_strSEX_CHR;
                //m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(p_objRrecord.m_strBIRTH_DAT);
                //m_objViewer.m_txtArear.Text = p_objRrecord.m_strAREANAME;
                //m_objViewer.m_txtBalance.Text = decBalance.ToString("0.00");
                //m_objViewer.m_txtBedCode.Text = p_objRrecord.m_strCODE_CHR;
                //m_objViewer.m_txtStatus.Text = p_objRrecord.m_strSTATUS;
                //m_objViewer.m_txtPstatus.Text = p_objRrecord.m_strPSTATUS;
                //m_objViewer.m_txtUnclearCharge.Text = decUnclearCharge.ToString("0.00");
                //m_objViewer.m_txtDese.Text = p_objRrecord.m_strICD10DIAGTEXT_VCHR;
                //m_objViewer.m_txtInHospitalTime.Text = p_objRrecord.m_strINPATIENT_DAT;
                //m_objViewer.m_txtInTime.Text = p_objRrecord.m_strINPATIENTCOUNT_INT;
                //if (p_objRrecord.m_strINPATIENTNOTYPE_INT == "2")
                //{
                //    m_objViewer.m_txtInType.Text = "����";
                //}
                //else
                //{
                //    m_objViewer.m_txtInType.Text = "��ʽ";
                //}
            }
            else
            {
                MessageBox.Show("�Բ���,�Ҳ����ò�����Ϣ��", "���Ҳ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region ������Ժ
        /// <summary>
        /// ������Ժ
        /// </summary>
        public void m_mthCancleInHospital()
        {
            if (this.m_objViewer.m_ucPatientInfo.RegisterID == "")
            {
                MessageBox.Show("�����벡����Ϣ��", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Status.ToString().Trim() == "3")
            {
                MessageBox.Show("�ò����Ѿ���Ժ��", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.m_objViewer.m_ucPatientInfo.Status == -1)
            {
                MessageBox.Show("�ò����Ѿ�������Ժ��", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //����Ƿ������Ϊִ�е�����
            int count;

            long l = leaHosDomain.m_lngGetNotStopOrderByRegID(this.m_objViewer.m_ucPatientInfo.RegisterID, out count);

            if (count > 0)
            {
                if (MessageBox.Show(m_objViewer, "�ò������¿���ҽ�����Ƿ����������Ժ������", "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }     

            if (this.m_objViewer.m_ucPatientInfo.BihPatient_VO.WaitChargeFee > 0 || this.m_objViewer.m_ucPatientInfo.BihPatient_VO.WaitClearFee > 0)
            {
                MessageBox.Show("�з���δ��,���ܳ�����Ժ������", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.m_objViewer.m_ucPatientInfo.BalancePrepayMoney > 0)
            {
                MessageBox.Show("��Ԥ����δ��,������������Ժ������", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("ȷ�ϳ�����Ժô?", "������Ժ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                p_objRrecord = new clsBIHpatientVO();
                p_objRrecord.m_strREGISTERID_CHR = this.m_objViewer.m_ucPatientInfo.RegisterID;
                p_objRrecord.m_strINPATIENTID_CHR = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Zyh;
                p_objRrecord.m_strPSTATUS = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Status.ToString().Trim();
                p_objRrecord.m_strRemark = m_objViewer.m_txtRemark.Text.Trim();
                //p_objRrecord.m_strINPATIENTCOUNT_INT = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.InsuredZycs.ToString();
                p_objRrecord.m_strINPATIENTCOUNT_INT = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Zycs.ToString();//סԺ���� 
                p_objRrecord.m_strPATIENTID_CHR = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.PatientID;
                p_objRrecord.m_strINPATIENTNOTYPE_INT = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.InType;
                try
                {
                    p_objRrecord.m_strOpearID = m_objViewer.LoginInfo.m_strEmpID;
                    if (p_objRrecord.m_strOpearID == "" || p_objRrecord.m_strOpearID == null)
                    {
                        p_objRrecord.m_strOpearID = "0000001";
                    }
                    long lngRes = m_objManage.m_lngCancleBeInHospital(p_objRrecord);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("������Ժ�ɹ���", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.m_objViewer.m_ucPatientInfo.m_mthReset();
                        //this.m_objViewer.cmdCancle.Enabled = false;
                        m_mthClearControl();
                        decBalance = 0;
                        decUnclearCharge = 0;
                        p_objRrecord = null;
                    }
                    else
                    {
                        MessageBox.Show("������Ժʧ�ܣ�", "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "������Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
            }
        }
        #endregion

        #region ��տؼ��ı�
        /// <summary>
        /// ��տؼ��ı�
        /// </summary>
        private void m_mthClearControl()
        {
            foreach (object obj in m_objViewer.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = "";
                }
            }
        }
        #endregion

        #region ��ͨ��->���ۺ�
        /// <summary>
        /// ��ͨ��->���ۺ�
        /// </summary>
        internal void m_mthChangePatientIDOth()
        {
            int k=0;
            int status_int = -1; 
            try
            {
                k=int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k == 0||k==2)
            {
                MessageBox.Show(m_objViewer, "��ǰ���˲�����ͨסԺ�ţ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "��ǰ����סԺ���ѱ�������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int count=0;//��Ժ����
            try
            {
                count = int.Parse(p_objRrecord.m_strINPATIENTCOUNT_INT);
            }
            catch
            {
            }
            if (count!=1)
            {
                MessageBox.Show(m_objViewer, "�״���Ժ�Ĳ��˲ſɽ���ֹ������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //�������ۺ�
            CreateInpatientNo newNo = new CreateInpatientNo(2);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
               //��סԺ��ͷ��ʶ
                string m_strhead = "";
                //��סԺ��
                string m_strInpatientid_chr = "";
                //1,�����ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����
                int m_intSour = 0;
                //��סԺ���������ֲ���
                string m_strMain = "";

                m_strInpatientid_chr= newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR,p_objRrecord.m_strINPATIENTID_CHR,1,2,m_strhead,m_strMain,m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("�����ɹ���", "��ͨ��-->���ۺ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "��ͨ��-->���ۺ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ��ͨ��->��ͨ��
        /// <summary>
        /// ��ͨ��->��ͨ��
        /// </summary>
        internal void m_mthChangePatientIDOth2()
        {
            int k = 0;
            int status_int = -1;
            try
            {
                k = int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k == 0 || k == 2)
            {
                MessageBox.Show(m_objViewer, "��ǰ���˲�����ͨסԺ�ţ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "��ǰ����סԺ���ѱ�������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //������ͨ��
            CreateInpatientNo newNo = new CreateInpatientNo(1);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
                //��סԺ��ͷ��ʶ
                string m_strhead = "";
                //��סԺ��
                string m_strInpatientid_chr = "";
                //1,�����ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����
                int m_intSour = 0;
                //��סԺ���������ֲ���
                string m_strMain = "";

                m_strInpatientid_chr = newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR, p_objRrecord.m_strINPATIENTID_CHR,1, 1, m_strhead, m_strMain, m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("�����ɹ���", "��ͨ��-->��ͨ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "��ͨ��-->��ͨ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ���ۺ�->��ͨ��
        /// <summary>
        /// ���ۺ�->��ͨ��
        /// </summary>
        internal void m_mthChangePatientIDOth3()
        {
            int k = 0;
            int status_int = -1;
            try
            {
                k = int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k != 2)
            {
                MessageBox.Show(m_objViewer, "��ǰ���˲�������סԺ�ţ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "��ǰ����סԺ���ѱ�������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int count = 0;//��Ժ����
            try
            {
                count = int.Parse(p_objRrecord.m_strINPATIENTCOUNT_INT);
            }
            catch
            {
            }
            if (count != 1)
            {
                MessageBox.Show(m_objViewer, "�״���Ժ�Ĳ��˲ſɽ���ֹ������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //������ͨ��
            CreateInpatientNo newNo = new CreateInpatientNo(1);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
                //��סԺ��ͷ��ʶ
                string m_strhead = "";
                //��סԺ��
                string m_strInpatientid_chr = "";
                //1,�����ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����
                int m_intSour = 0;
                //��סԺ���������ֲ���
                string m_strMain = "";

                m_strInpatientid_chr = newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR, p_objRrecord.m_strINPATIENTID_CHR, 2, 1, m_strhead, m_strMain, m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("�����ɹ���", "���ۺ�->��ͨ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "���ۺ�->��ͨ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ���ۺ�-> ���ۺ�
        /// <summary>
        /// ���ۺ�-> ���ۺ�
        /// </summary>
        internal void m_mthChangePatientIDOth4()
        {
            int k = 0;
            int status_int = -1;
            try
            {
                k = int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k != 2)
            {
                MessageBox.Show(m_objViewer, "��ǰ���˲�������סԺ�ţ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "��ǰ����סԺ���ѱ�������", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //������ͨ��
            CreateInpatientNo newNo = new CreateInpatientNo(2);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
                //��סԺ��ͷ��ʶ
                string m_strhead = "";
                //��סԺ��
                string m_strInpatientid_chr = "";
                //1,�����ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����
                int m_intSour = 0;
                //��סԺ���������ֲ���
                string m_strMain = "";

                m_strInpatientid_chr = newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR, p_objRrecord.m_strINPATIENTID_CHR, 2, 2, m_strhead, m_strMain, m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("�����ɹ���", "���ۺ�->��ͨ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "���ۺ�->��ͨ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

                if (status == "3")
                {
                    MessageBox.Show("�ò����ѳ�Ժ�����ܳ�����Ժ��", "��ʾ");
                    this.m_objViewer.cmdCancle.Visible = false;
                    FindPatient();
                    return;
                }

            }
            else
            {
                //this.m_objViewer.Hide();
                this.m_objViewer.m_cancle = true;
                return;
            }
        }
        #endregion
    }
}
