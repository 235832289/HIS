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
	/// ��Ժ����������Ʋ�
	/// ���ߣ� ����
	/// ����ʱ�䣺 2004-09-06
	/// </summary>
	public class clsCtl_BIHLeave: com.digitalwave.GUI_Base.clsController_Base
	{
		#region ����
		clsDcl_Register m_objRegister = null;
		public string m_strReportID;
		public string m_strOperatorID;
		com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;
		#endregion 

		#region ���캯��
		public clsCtl_BIHLeave()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			m_objRegister = new clsDcl_Register();
			m_strReportID = null;
			m_strOperatorID = "0000001";
			clsController_Security clsSe=new clsController_Security();
			m_strOperatorID = clsSe.objGetCurrentLoginEmployee().strEmpID;
			objsystempower = new com.digitalwave.iCare.gui.Systempower.clsSystemPower_base(m_strOperatorID);
		}
		#endregion 

		#region ���ô������
		com.digitalwave.iCare.gui.HIS.frmBIHLeave m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmBIHLeave)frmMDI_Child_Base_in;
		}
		#endregion

		#region ��������
		/// <summary>
		/// ����סԺ��Ϣ	[������Ժ�Ǽ���ˮ��]
		/// </summary>
		public void LoadBIHInfo()
		{            
            if(m_objViewer.m_strRegisterID==string.Empty) return;

			clsT_Opr_Bih_Register_VO m_objItem =new clsT_Opr_Bih_Register_VO();
			long lngReg = m_objRegister.m_lngGetBinRegisterByRegisterID(m_objViewer.m_strRegisterID,out m_objItem);
			if(lngReg<=0 || m_objItem==null)
				return;

			//��Ժʱ��
            m_objViewer.m_lblINPATIENT_DAT.Text = Convert.ToDateTime(m_objItem.m_strINPATIENT_DAT.ToString()).ToString("yyyy��MM��dd��");
			//סԺ����
			try
			{
				System.TimeSpan diff1 =System.DateTime.Now.Subtract(Convert.ToDateTime(m_objItem.m_strINPATIENT_DAT));
                //m_objViewer.m_lblBIHDays.Text =diff1.Days.ToString();
                m_objViewer.m_lblBIHDays.Text = Convert.ToString(diff1.Days + 1);
			}
			catch
			{}

			//��Ժ���ҡ�����������
			m_objViewer.m_lblDEPTID_CHR.Text = m_objItem.m_strDeptName;
			m_objViewer.m_lblAREAID_CHR.Text = m_objItem.m_strAreaName;
			m_objViewer.m_lblBEDID_CHR.Text = m_objItem.m_strBedNo;
            
            m_objViewer.m_dtpOutDate.Text = DateTime.Now.ToString("yyyy��MM��dd��HHʱmm��");

            if (m_objViewer.m_bedManageVO.m_strINTERNALFLAG_INT == "2")
            {
                //ҽ������
                //this.m_objViewer.m_ckbDiseasType.Checked = true;
                this.m_objViewer.m_ckbDiseasType.Enabled = true;
            }
            else
            {
                //this.m_objViewer.m_ckbDiseasType.Checked = false;
                this.m_objViewer.m_ckbDiseasType.Enabled = false;
            }

            if (m_objItem.m_intDiseaseType == 1)
            {
                this.m_objViewer.m_ckbDiseasType.Enabled = false;
                this.m_objViewer.m_ckbDiseasType.Checked = true;
            }

            this.m_objViewer.m_tbDiagnose.Text = m_objItem.m_strOutDiagnose;

		}
		#endregion

		#region ��Ժ
		/// <summary>
		/// ��Ժ	{1���ճ���λ��2������һ����Ժ��¼��}
		/// </summary>
		public void m_LeaveHospital()
        {
            long lngReg = 0;
            if (!IsPassInputValidate()) return;
            clsT_Opr_Bih_Leave_VO objPatientVO;
            ValueToVoForLeave(out objPatientVO);
            //����Ƿ���Գ�Ժ
            if (objPatientVO.m_intPSTATUS_INT == 1)
            {
                if (!CheckIsMayLeaveHospital(objPatientVO.m_strREGISTERID_CHR)) return;
            }
            if (objsystempower.isHasRight("סԺ.����ת.��Ժ"))
            {
                try
                {
                    lngReg = m_objRegister.m_lngLeaveHospital(objPatientVO);
                    MessageBox.Show("�����ɹ���", "��Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;
                }
                catch (Exception e)
                {
                    MessageBox.Show(m_objViewer, e.Message, "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("��û��Ȩ��");
            }
        }
		private bool IsPassInputValidate()
		{
			if(m_objViewer.m_cbmTYPE.Text.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"��Ժ����Ϊ��ѡ��!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			if(m_objViewer.m_cbmPSTATUS_INT.SelectedIndex<=0)
			{
				MessageBox.Show(m_objViewer,"��Ժ��ʽΪ��ѡ��!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			return true;
		}

		/// <summary>
		/// ����Ƿ���Գ�Ժ
		/// ҵ��˵��: 
		///		1����δֹͣ��ҽ�������ܳ�Ժ��
		///		2����û�����ֹͣ������ҽ���������Գ�Ժ��
		///		3��������Ժ�������Ժ�Ĳ������û���մ�λ�ѣ������Գ�Ժ��
		///		4��������Ժ�������Ժ�Ĳ������û������𣬲����Գ�Ժ��
		///		5����δ��ķ��ã������Գ�Ժ!
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ���ˮ��</param>
		/// <returns>{true-���Գ�Ժ��false-���ܳ�Ժ}</returns>
		private bool CheckIsMayLeaveHospital(string p_strRegisterID)
		{
			bool blnRes =true;
			string strMessage ="";
			//1����δֹͣ��ҽ�������ܳ�Ժ��
			if(m_objRegister.m_lngIshasAdvice(p_strRegisterID))
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    ����δֹͣ��ҽ����";
			}
			//2����û�����ֹͣ������ҽ���������Գ�Ժ��
			if(m_objRegister.m_blnExistNotCheckConfreqOrder(p_strRegisterID))
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    ����δ���ֹͣ��������ҽ����";
			}
			//3��������Ժ�������Ժ�Ĳ������û���մ�λ�ѣ������Գ�Ժ��
			if(m_objRegister.m_lngChargeBedForTodayPatient(p_strRegisterID)==0)
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    û����ȡ��λ�ѣ�";
			}
			//4��������Ժ�������Ժ�Ĳ������û����ȡ��𣬲����Գ�Ժ��
			if(m_objRegister.m_lngChargeDiagnosisForTodayPatient(p_strRegisterID)==0)
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    û����ȡ���";
			}
			//5����δ��ķ��ã������Գ�Ժ!
			string strDebt = "";
			long lngRes = new clsDcl_StatQuery().m_lngGetPatientDebtByRegisterID(p_strRegisterID,out strDebt);
			if(strDebt!="" && double.Parse(strDebt)>0)
			{
				if(strMessage!="") strMessage +="\r\n";
				strMessage +="    ��"+strDebt+"Ԫδ��ķ��ã�";
			}

			if(strMessage!="")
			{
				if(MessageBox.Show(m_objViewer,"��ʾ��\r\n"+strMessage+"\r\n\r\n    �Ƿ�ǿ�Ƴ�Ժ��","���棡",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2)==DialogResult.No)			
					blnRes =false;
				else
					blnRes =true;
			}
			return blnRes;
		}
		#region �ؼ���ֵ��Vo
		/// <summary>
		/// �ؼ���ֵ��Vo  {��Ժ}
		/// </summary>
		/// <param name="objPatientVO"></param>
		private void ValueToVoForLeave(out clsT_Opr_Bih_Leave_VO objPatientVO)
		{
			objPatientVO =new clsT_Opr_Bih_Leave_VO();

			//��Ժ�Ǽ���ˮ��(200409010001)
			objPatientVO.m_strREGISTERID_CHR = m_objViewer.m_strRegisterID;
			//����{1=������Ժ2=תԺ3=����4=����}
			objPatientVO.m_strTYPE_INT = "0";
			if(m_objViewer.m_cbmTYPE.SelectedIndex!=0)
			{
				objPatientVO.m_strTYPE_INT = m_objViewer.m_cbmTYPE.SelectedIndex.ToString();
			}
			//��Ժ����
			objPatientVO.m_strOUTDEPTID_CHR = m_objViewer.m_strOutDeptID;			
			
            //��Ժ����
			objPatientVO.m_strOUTAREAID_CHR = m_objViewer.m_strOutAreaID;
            objPatientVO.m_strOutAreaName = m_objViewer.m_lblAREAID_CHR.Text;
			
            //��Ժ����
			objPatientVO.m_strOUTBEDID_CHR = m_objViewer.m_strOutBedID;
			
            //��ע
			objPatientVO.m_strDES_VCHR = m_objViewer.m_txtDES.Text;
			
            //������ID
            objPatientVO.m_strOPERATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            //������
            objPatientVO.m_strOperatorName = this.m_objViewer.LoginInfo.m_strEmpName;

            //�޸����ڣ���������
			objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			
            //״̬����1��ʷ��0-��Ч��1��Ч��
			objPatientVO.m_intSTATUS_INT = 1;	
			
            //��Ժ��ʽ	{��=Ԥ��Ժ;��=ʵ�ʳ�Ժ}
			objPatientVO.m_intPSTATUS_INT = m_objViewer.m_cbmPSTATUS_INT.SelectedIndex - 1;

            //��Ժ����	
            objPatientVO.m_strOUTHOSPITAL_DAT = Convert.ToDateTime(this.m_objViewer.m_dtpOutDate.Text).ToString("yyyy-MM-dd HH:mm:ss");

            //��Ժ���
            objPatientVO.m_strDIAGNOSE_VCHR = m_objViewer.m_tbDiagnose.Text;

            //ҽ����Ժ���
            objPatientVO.m_strINS_DIAGNOSE_VCHR = m_objViewer.m_tbInsDiagnose.Text;

            if (this.m_objViewer.m_ckbDiseasType.Checked == true)
            {
                objPatientVO.m_intDISEASETYPE_INT = 1;
            }
            else
            {
                objPatientVO.m_intDISEASETYPE_INT = 0;
            }
		}
		#endregion
		#endregion

        #region Ԥ��Ժ He Guiqiu 2006.07.12
        public void PreLeaveHospital()
        {
            
            if (!IsPassInputValidate()) return;

           
            //try
            //{
            //    DateTime outDate;
            //    outDate = Convert.ToDateTime(this.m_dtpOutDate.Text);
            //    System.TimeSpan diff1 = outDate.Subtract(DateTime.Now);
            //    if (diff1.Days > 0)
            //    {       
            //        MessageBox.Show("��Ժ���ڲ������ڽ���", "��ʾ");
            //        this.m_objViewer.m_dtpOutDate.Focus();
            //        return;
            //     }
            //}
            //catch
            //{ }

            clsT_Opr_Bih_Leave_VO objPatientVO;
            ValueToVoForLeave(out objPatientVO);
            
            try
            {

                DateTime outDate;
                outDate = Convert.ToDateTime(this.m_objViewer.m_dtpOutDate.Text).Date;
                System.TimeSpan diff1 = outDate.Subtract(DateTime.Today);
                if (diff1.Days < 0)
                {
                    MessageBox.Show("Ԥ��Ժ���ڲ������ڽ���", "��ʾ");
                    this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                if (diff1.Days > 1)
                {
                    MessageBox.Show("Ԥ��Ժ���ڲ��ܳ�������", "��ʾ");
                    this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                //������ѽӿ�
                bool charge;
                charge = clsPublic.m_blnChargeContinueItem(objPatientVO.m_strREGISTERID_CHR, objPatientVO.m_strOPERATORID_CHR);
                if (!charge)
                {
                    MessageBox.Show("���÷��ýӿ�ʧ��", "��ʾ");
                    //this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                long lngReg = -1;
                clsDclBihLeaHos domainObj = new clsDclBihLeaHos();

                //bool HasDisExcOrder;
                //domainObj.IfHasDisExcOrder(objPatientVO.m_strREGISTERID_CHR, out HasDisExcOrder);
                //if (HasDisExcOrder == true)
                //{
                //    string message = "�ò�����ҽ��δ�����봦����ϲſ��԰����Ժ�������Ƿ������";
                //    string caption = "��ʾ";
                //    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                //    DialogResult result;

                //    result = MessageBox.Show(this.m_objViewer, message, caption, buttons,
                //        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                //        MessageBoxOptions.RightAlign);

                //    if (result == DialogResult.No)
                //    {
                //        return;
                //    }

                //}
                
                
                lngReg = domainObj.PreLeaveHospital(objPatientVO);

                if (lngReg > 0)
                {
                    string msg = "�����ɹ���"
                               + this.m_objViewer.m_lblPatientName.Text + "����"
                               + this.m_objViewer.m_dtpOutDate.Text
                               + "��Ժ��";
                    MessageBox.Show(msg,"Ԥ��Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("Ԥ��Ժʧ�ܣ�", "Ԥ��Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.No;

                }
            }
            catch (Exception e)
            {
                m_objViewer.DialogResult = DialogResult.No;
                MessageBox.Show(m_objViewer, e.Message, "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            if (m_objViewer.DialogResult == DialogResult.OK && this.m_objViewer.m_ckbPrint.Checked)
            {
                // ��ӡ��Ժ֪ͨ��
                frmPrintLeaveNotice printLeaveNotice = new frmPrintLeaveNotice(this.m_objViewer.m_bedManageVO, objPatientVO);

                printLeaveNotice.Show();
                printLeaveNotice.Hide();
                printLeaveNotice.m_cmdPrint_Click(null, null);
            }           
        }
        #endregion 

        #region ֱ�ӳ�Ժ He Guiqiu 
        public void LeaveHospital()
        {

            if (!IsPassInputValidate()) return;
            clsT_Opr_Bih_Leave_VO objPatientVO;
            ValueToVoForLeave(out objPatientVO);

            try
            {

                DateTime outDate;
                outDate = Convert.ToDateTime(this.m_objViewer.m_dtpOutDate.Text);
                System.TimeSpan diff1 = outDate.Subtract(DateTime.Now);
                if (diff1.Days < 0)
                {
                    MessageBox.Show("��Ժ���ڲ������ڽ���", "��ʾ");
                    this.m_objViewer.m_dtpOutDate.Focus();
                    return;
                }

                long lngReg = -1;
                clsDclBihLeaHos domainObj = new clsDclBihLeaHos();
                lngReg = domainObj.LeaveHospital(objPatientVO);

                if (lngReg > 0)
                {
                    string msg = "�����ɹ���"
                               + this.m_objViewer.m_lblPatientName.Text + "����"
                               + this.m_objViewer.m_dtpOutDate.Text
                               + "��Ժ��";
                    MessageBox.Show(msg, "��Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("��Ժʧ�ܣ�", "��Ժ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.DialogResult = DialogResult.No;

                }
            }
            catch (Exception e)
            {
                m_objViewer.DialogResult = DialogResult.No;
                MessageBox.Show(m_objViewer, e.Message, "������ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            if (m_objViewer.DialogResult == DialogResult.OK && this.m_objViewer.m_ckbPrint.Checked)
            {
                // ��ӡ��Ժ֪ͨ��
                frmPrintLeaveNotice printLeaveNotice = new frmPrintLeaveNotice(this.m_objViewer.m_bedManageVO, objPatientVO);

                printLeaveNotice.ShowDialog();
            }
        }
        #endregion 

        internal void EditDiagnoses()
        {
            //frmDiagnoses frm = new frmDiagnoses(this.m_objViewer.m_tbDiagnose.Text);
            frmDiagnoses frm = new frmDiagnoses(this.m_objViewer.m_tbDiagnose.Text.Trim(), this.m_objViewer.m_ckbDiseasType.Checked);
            frm.m_txtDiagnoses.Text = this.m_objViewer.m_tbDiagnose.Text.Trim();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                this.m_objViewer.m_tbDiagnose.Text = frm.m_txtDiagnoses.Text;
                this.m_objViewer.m_ckbDiseasType.Checked = frm.chkDiseasetype.Checked;
            }
        }
    }
}
