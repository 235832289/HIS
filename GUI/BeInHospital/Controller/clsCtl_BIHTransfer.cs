using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ��ת����������Ʋ�
	/// ���ߣ� ����
	/// ����ʱ�䣺 2004-09-06
	/// </summary>
	public class clsCtl_BIHTransfer: com.digitalwave.GUI_Base.clsController_Base
	{
		#region ����
		clsDcl_BedAdmin m_objBedAdmin = null;
		clsDcl_Register m_objRegister =null;
		public string m_strReportID;
		public string m_strOperatorID;
		#endregion 

		#region ���캯��
		public clsCtl_BIHTransfer()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			m_objBedAdmin =new clsDcl_BedAdmin();
			m_objRegister = new clsDcl_Register();
			m_strReportID = null;
			m_strOperatorID = "0000001";
		}
		#endregion 

		#region ���ô������
		com.digitalwave.iCare.gui.HIS.frmBIHTransfer m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmBIHTransfer)frmMDI_Child_Base_in;
		}
		#endregion

		#region ��ʼ�����ҡ�����������
//		#region �������
//		/// <summary>
//		/// �������
//		/// </summary>
//		public void LoadDeptID()
//		{
//			m_objViewer.lsvDeptInfo.Items.Clear();
//			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr =null;
//			string strFilter = "WHERE ATTRIBUTEID = '0000002' AND STATUS_INT = 1 AND SHORTNO_CHR LIKE '"+m_objViewer.m_txtDEPTID_CHR.Text.ToString().Trim()+"%'";
//			System.Windows.Forms.ListViewItem FindItem;
//			long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter,out DataResultArr);
//			if(lngRes>0&&DataResultArr.Length >0)
//			{
//				for(int i = 0;i<DataResultArr.Length;i++)
//				{
//					FindItem = new ListViewItem(DataResultArr[i].m_strDEPTNAME_VCHR);
//					FindItem.Tag = DataResultArr[i];
//					m_objViewer.lsvDeptInfo.Items.Add(FindItem);
//				}
//			}
//		}
//		#endregion
		#region ������Ҷ�Ӧ�Ĳ���
		/// <summary>
		/// ������Ҷ�Ӧ�Ĳ���
		/// </summary>
		public void LoadAreaID()
		{
			m_objViewer.lsvAreaInfo.Items.Clear();
			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr =null;
			string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or DEPTNAME_VCHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or PYCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or WBCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%')";
			System.Windows.Forms.ListViewItem FindItem;
			long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter,out DataResultArr);
			if(lngRes>0&&DataResultArr.Length >0)
			{
				for(int i = 0;i<DataResultArr.Length;i++)
				{
					FindItem = new ListViewItem(DataResultArr[i].m_strDEPTNAME_VCHR);
					FindItem.Tag = DataResultArr[i];
					m_objViewer.lsvAreaInfo.Items.Add(FindItem);
				}
			}
		}
		#endregion
//		#region ���벡���Ķ�Ӧ�մ�
//		/// <summary>
//		/// ���벡���Ķ�Ӧ�մ�
//		/// </summary>
//		public void LoadBedID()
//		{
//			m_objViewer.m_txtBEDID_CHR.lsvContext.Items.Clear();
//			//����IDΪ���򷵻�
//			if(((string)m_objViewer.m_txtAREAID_CHR.Tag)=="") return;
//
//			DataTable dtbResult =new DataTable();
//			m_objBedAdmin.m_lngGetAreaBedInfoByStatus_int((string)m_objViewer.m_txtAREAID_CHR.Tag,1,out dtbResult);
//			if(dtbResult.Rows.Count >0)
//			{
//				m_objViewer.m_txtBEDID_CHR.DataSource =dtbResult;
//				m_objViewer.m_txtBEDID_CHR.BindData();
//			}
//		}
//		#endregion
		#endregion

		#region ��ת
		public void m_cmdTransfer()
		{
			long lngReg =0;

			if(!IsPassInputValidate())
				return;

			clsT_Opr_Bih_Transfer_VO objPatientVO;
			ValueToVoForTransfer(out objPatientVO);


			try
			{
				lngReg =m_objRegister.m_lngTransferInHospital(objPatientVO);
			}
			catch (Exception e)
			{
				MessageBox.Show(m_objViewer,e.Message,"������ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Error);	
				return;
			}			

			//���������ʾ
			if(lngReg>0)
			{
				MessageBox.Show(m_objViewer,"�ɹ���ת!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);	
				m_objViewer.m_IsOK =true;
				m_objViewer.Close();
			}
			else
			{
				MessageBox.Show(m_objViewer,"��תʧ��!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);	
			}
		}
		/// <summary>
		/// ������֤
		/// </summary>
		/// <returns></returns>
		private bool IsPassInputValidate()
		{
//			if(m_objViewer.m_cbmTYPE.SelectedIndex<=0)
//			{
//				MessageBox.Show(m_objViewer,"��ת����Ϊ��ѡ��!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
//				m_objViewer.m_cbmTYPE.Focus();
//				return false;
//			}
//			if(((string)m_objViewer.m_txtDEPTID_CHR.Tag)=="")
//			{
//				MessageBox.Show(m_objViewer,"Ŀ�����Ϊ��ѡ��!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
//				m_objViewer.m_txtDEPTID_CHR.Focus();
//				return false;
//			}
			if(((string)m_objViewer.m_txtAREAID_CHR.Tag)=="")
			{
				MessageBox.Show(m_objViewer,"Ŀ�겡��Ϊ��ѡ��!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
				m_objViewer.m_txtAREAID_CHR.Focus();
				return false;
			}
			if(m_objViewer.m_strRegisterID.Trim()=="")
			{
				MessageBox.Show(m_objViewer,"δ֪��Ժ�Ǽǣ����ܵ�ת!","��ʾ��",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}

			return true;
		}

		#region �ؼ���ֵ��Vo
		/// <summary>
		/// �ؼ���ֵ��Vo  {��ת}
		/// </summary>
		/// <param name="objPatientVO"></param>
		private void ValueToVoForTransfer(out clsT_Opr_Bih_Transfer_VO objPatientVO)
		{
			objPatientVO =new clsT_Opr_Bih_Transfer_VO();
			//Դ����id
			objPatientVO.m_strSOURCEDEPTID_CHR =m_objViewer.m_strSourceDeptID;
			//Դ����id
			objPatientVO.m_strSOURCEAREAID_CHR =m_objViewer.m_strSourceAreaID;
			//Դ����id
			objPatientVO.m_strSOURCEBEDID_CHR =m_objViewer.m_strSourceBedID;
			//Ŀ�����id
//			objPatientVO.m_strTARGETDEPTID_CHR =(string)m_objViewer.m_txtDEPTID_CHR.Tag;
			//Ŀ�겡��id
			objPatientVO.m_strTARGETAREAID_CHR =(string)m_objViewer.m_txtAREAID_CHR.Tag;
			//Ŀ�겡��id
//			objPatientVO.m_strTARGETBEDID_CHR =m_objViewer.m_txtBEDID_CHR.Value;
			objPatientVO.m_strTARGETBEDID_CHR = "";
			//��������{1=ת��2=����3=ת��+����4=��Ժ����}
			objPatientVO.m_intTYPE_INT =3;
			//��ע
			objPatientVO.m_strDES_VCHR =m_objViewer.m_txtDES.Text;
			//������
			objPatientVO.m_strOPERATORID_CHR =m_strOperatorID;
			//��Ժ�Ǽ���ˮ��(200409010001)
			objPatientVO.m_strREGISTERID_CHR =m_objViewer.m_strRegisterID;
			//�޸����ڣ���������
			objPatientVO.m_strMODIFY_DAT =System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");	
		}
		#endregion
		#endregion

//		#region ��ת�����¼�
//		/// <summary>
//		/// ��ת�����¼�
//		/// </summary>
//		public void m_TYPETextChanged()
//		{
//			if(m_objViewer.m_cbmTYPE.Text.Trim()=="")
//			{
//				m_objViewer.m_txtDEPTID_CHR.Enabled =true;
//				m_objViewer.m_txtAREAID_CHR.Enabled =true;
//				return;
//			}
//			switch(m_objViewer.m_cbmTYPE.SelectedIndex)
//			{
//				case 1://"2-����":
//					m_objViewer.m_txtDEPTID_CHR.Text =m_objViewer.m_lblDEPTID_CHR.Text;
//					m_objViewer.m_txtDEPTID_CHR.Tag =m_objViewer.m_strSourceDeptID;
//					LoadAreaID();
//					m_objViewer.m_txtAREAID_CHR.Text =m_objViewer.m_lblAREAID_CHR.Text;
//					m_objViewer.m_txtAREAID_CHR.Tag =m_objViewer.m_strSourceAreaID;
//					m_objViewer.m_txtDEPTID_CHR.Enabled =false;
//					m_objViewer.m_txtAREAID_CHR.Enabled =false;
//	
//					break;
//				case 2://ת��
//					m_objViewer.m_txtDEPTID_CHR.Text =m_objViewer.m_lblDEPTID_CHR.Text;
//					m_objViewer.m_txtDEPTID_CHR.Tag =m_objViewer.m_strSourceDeptID;
//					LoadAreaID();
//					m_objViewer.m_txtAREAID_CHR.Text =m_objViewer.m_lblAREAID_CHR.Text;
//					m_objViewer.m_txtAREAID_CHR.Tag =m_objViewer.m_strSourceAreaID;
//					m_objViewer.m_txtDEPTID_CHR.Enabled =true;
//					m_objViewer.m_txtAREAID_CHR.Enabled =true;
//					break;
//			}
//		}
//		#endregion
	}
}
