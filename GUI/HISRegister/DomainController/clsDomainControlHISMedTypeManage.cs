using System;
using System.Data;
//using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ҩ�����ά��ҵ�����
	/// Create ��ΰ�� by 2005-09-8
	/// </summary>
	public class clsDomainControlHISMedTypeManage : clsDomainController_Base//GUI_Base.dll
	{
		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsDomainControlHISMedTypeManage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ҩ�����ά��ҵ����������������
		/// <summary>
		/// ҩ�����ά��ҵ����������������
		/// Create ��ΰ�� by 2005-09-8
		/// <param name="strMainID">���ݽ���ȡ���ӽ�㣬������ʶΪ����</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns>ʧ�ܣ�-1 ���ɹ�����Ӱ��Ľ����</returns>
		/// </summary>
		public long m_lngGetMedTypeInfo(out clsHISMedType_VO[] p_objResultArr,string strMainID)
		{
			p_objResultArr=null;
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngGetMedTypeInfo(objPrincipal, out p_objResultArr, strMainID);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
			
		}

		#endregion

		#region ҩ�����ά��ҵ�����:�޸ķ�����Ϣ���
		/// <summary>
		/// ҩ�����ά��ҵ�����:�޸���Ϣ
		/// Create ��ΰ�� by 2005-09-8
		/// <param name="strMainID">�޸ķ�����Ϣ���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns>ʧ�ܣ�-1 ���ɹ�����Ӱ��Ľ����</returns>
		/// </summary>
		public long m_lngModify(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO)
		{		
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngModify(objPrincipal, objTD_VO);
            objSvc.Dispose();
            objSvc = null;				
			return lngRes;
		}
		#endregion

		#region ���
		/// <summary>
		/// ҩ�����ά��ҵ�����:�����Ϣ
		/// Create ��ΰ�� by 2005-09-9
		/// <param name="objTD_VO">��ӷ�����Ϣ���</param>
		/// <param name="objTD_VOReturn">�������</param>
		/// <returns>ʧ�ܣ�-1 ���ɹ�����Ӱ��Ľ����</returns>
		/// </summary>
		public long m_lngAddNew(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO,out com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VOReturn )
		{
			long lngRes = 0;
			objTD_VOReturn =null;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));

            lngRes = objSvc.m_lngAddNew(objPrincipal, objTD_VO, out objTD_VOReturn);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region ҩ�����ά��ҵ�����:ɾ��ҩ�����
		/// <summary>
		/// ҩ�����ά��ҵ�����:ɾ��ҩ�����
		/// Create ��ΰ�� by 2005-09-9
		/// <param name="objTD_VO">ɾ��������Ϣ���</param>
		/// <param name="objTD_VOReturn">�������</param>
		/// <returns>ʧ�ܣ�-1 ���ɹ�����Ӱ��Ľ����</returns>
		/// </summary>
		public long m_lngDelete(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngDelete(objPrincipal, objTD_VO);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region �������ж�ĳ����Ƿ�ӵ���ӽ�㣺��ҩ��������Ƿ����ӷ��ࣩ
		/// <summary>
		/// �������ж�ĳ����Ƿ�ӵ���ӽ�㣺��ҩ��������Ƿ����ӷ��ࣩ
		/// </summary>
		/// <param name="blnHasSubNode">���ؽ���������ӽ���򷵻�true</param>
		/// <param name="m_strPHARMAID_CHR">���ݿ����Զ�������ID��</param>
		/// <returns>ʧ�ܣ�-1 ���ɹ�����Ӱ��Ľ����</returns>

		public long m_lngCheckMedTypeIsHasSubById(out bool blnHasSubNode, string m_strPHARMAID_CHR)
		{
			
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngCheckMedTypeIsHasSubById(objPrincipal, out blnHasSubNode, m_strPHARMAID_CHR);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
			
		}

		#endregion

		#region �������ж��������Ƿ�Ψһ��
		/// <summary>
		/// �������ж��������Ƿ�Ψһ
		/// </summary>
		/// <param name="blnHasThisZhujima">���ؽ�����Ѵ��ڴ��������򷵻�true</param>
		/// <param name="p_strZhuJiMa">����������</param>
		/// <returns>ʧ�ܣ�-1 ���ɹ�����Ӱ��Ľ����</returns>

		public long m_lngGetMedTypeZhuJiMaById(out bool blnHasThisZhujima, string p_strZhuJiMa)
		{
			
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngGetMedTypeZhuJiMaById(objPrincipal, out blnHasThisZhujima, p_strZhuJiMa);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
			
		}
		#endregion
	}
}
