using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDcl_ChargeIns ��ժҪ˵����
	/// </summary>
	public class clsDcl_ChargeIns : com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_ChargeIns()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		//���չ�˾
		#region ��ȡ���չ�˾�б�	�Ź���		2004-9-22
		/// <summary>
		/// ��ȡ���չ�˾�б�
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetINSCOMPANYDataArr(out clsInsCompany_VO[] p_objResultArr)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngGetINSCOMPANYDataArr(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;

		}
		#endregion

		#region �������չ�˾	�Ź���		2004-9-24
		/// <summary>
		/// �������չ�˾
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngAddNewINSCOMPANYD( clsInsCompany_VO objResult,out string strID)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngAddNewINSCOMPANYD(objPrincipal, objResult, out strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region �޸ı��չ�˾��Ϣ	�Ź���		2004-9-24
		/// <summary>
		/// �޸ı��չ�˾��Ϣ
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
			public long m_lngModifyINSCOMPANYD( clsInsCompany_VO objResult)
			{

				com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
				long lngRes = objSvc.m_lngModifyINSCOMPANYD(objPrincipal,objResult);
                objSvc.Dispose();
                return lngRes;
			}
		#endregion

		#region ɾ�����չ�˾��Ϣ	�Ź���		2004-9-24
			/// <summary>
			/// ɾ�����չ�˾��Ϣ
			/// </summary>
			/// <param name="objResult"></param>
			/// <returns></returns>
			public long m_lngINSCOMPANYDel(string strID )
			{

				com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
                long lngRes = objSvc.m_lngINSCOMPANYDel(objPrincipal, strID);
                objSvc.Dispose();
                return lngRes;
			}
		#endregion
		
		//���ռƻ�	
		#region ��ȡ���ռƻ��б�	�Ź���		2004-9-24
			/// <summary>
			/// ��ȡ���ռƻ��б�
			/// </summary>
			/// <param name="p_objResultArr"></param>
			/// <returns></returns>
			public long m_lngGetINSPLANDataArr(out clsInsPlan_VO[] p_objResultArr)
			{

				com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
                long lngRes = objSvc.m_lngGetINSPLANDataArr(objPrincipal, out p_objResultArr);
                objSvc.Dispose();
                return lngRes;
			}
		#endregion

		#region �������ռƻ�	�Ź���		2004-9-24
		/// <summary>
		/// �������ռƻ�
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngAddNewINSPLAN( clsInsPlan_VO objResult,out string strID)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngAddNewINSPLAN(objPrincipal, objResult, out strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region �޸ı��ռƻ�	�Ź���		2004-9-24
		/// <summary>
		/// �޸ı��ռƻ�
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngModifyINSPLAN( clsInsPlan_VO objResult)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngModifyINSPLAN(objPrincipal, objResult);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region ɾ�����ռƻ�	�Ź���		2004-9-24
		/// <summary>
		/// ɾ�����ռƻ�
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngDelINSPLAN(string strID )
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngDelINSPLAN(objPrincipal, strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		//���ռƻ�	
		#region ��ȡ���������б�	�Ź���		2004-9-27
		/// <summary>
		/// ��ȡ���ռƻ��б�
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetINSCOPAYataArr(out clsInsPay_VO[] p_objResultArr)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngGetINSCOPAYataArr(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region ������������	�Ź���		2004-9-27
		/// <summary>
		/// �������ռƻ�
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngAddNewINSCOPAY( clsInsPay_VO objResult,out string strID)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngAddNewINSCOPAY(objPrincipal, objResult, out strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region �޸ı�������	�Ź���		2004-9-27
		/// <summary>
		/// �޸ı��ռƻ�
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngModifyINSCOPAY( clsInsPay_VO objResult)
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngModifyINSCOPAY(objPrincipal, objResult);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

		#region ɾ����������	�Ź���		2004-9-27
		/// <summary>
		/// ɾ�����ռƻ�
		/// </summary>
		/// <param name="objResult"></param>
		/// <returns></returns>
		public long m_lngDelINSCOPAY(string strID )
		{

			com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeInsSvc));
            long lngRes = objSvc.m_lngDelINSCOPAY(objPrincipal, strID);
            objSvc.Dispose();
            return lngRes;
		}
		#endregion

	}
}
