using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsDomainControl_OPDoctor ��ժҪ˵����
	/// </summary>
	public class clsDomainControl_OPDoctor:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainControl_OPDoctor()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ���غ����б�
		/// <summary>
		/// ���غ����б�
		/// </summary>
		public long m_lngGetWaitList(string strDocID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindWaitDiagList(objPrincipal,strDocID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ����
		/// <summary>
		/// ����
		/// </summary>
		public long m_lngTakeWait(string strWaitID,string strRegID,string DepID,string DocID)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngTakeDiag(objPrincipal,strWaitID,strRegID,DepID,DocID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��������
		/// <summary>
		/// ��������
		/// </summary>
		public long m_lngUndoTakeWait(string strID,string strRegID)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngUndoTakeDiag(objPrincipal,strID,strRegID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
        
		#region ���ؽ����б�
		/// <summary>
		/// ���ؽ����б�
		/// </summary>
		public long m_lngGetTakeList(string strDocID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindTakeDiagList(objPrincipal,strDocID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ��ҩ����
		/// <summary>
		/// ��ѯ��ҩ����
		/// </summary>
		public long m_lngGetWestRec(string strRegID,string strRecID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindWestRecipe(objPrincipal,strRegID,strRecID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ��ҩ����
		/// <summary>
		/// ��ѯ��ҩ����
		/// </summary>
		public long m_lngGetCMRec(string strRegID,string strRecID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindCMRecipe(objPrincipal,strRegID,strRecID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ�������뵥
		/// <summary>
		/// ��ѯ�������뵥
		/// </summary>
		public long m_lngGetCHKRec(string strRegID,string strRecID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindCHKRecipe(objPrincipal,strRegID,strRecID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ������뵥
		/// <summary>
		/// ��ѯ������뵥
		/// </summary>
		public long m_lngGetTestRec(string strRegID,string strRecID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindTestRecipe(objPrincipal,strRegID,strRecID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ�������뵥
		/// <summary>
		/// ��ѯ�������뵥
		/// </summary>
		public long m_lngGetOPSRec(string strRegID,string strRecID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindOPSRecipe(objPrincipal,strRegID,strRecID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ��������
		/// <summary>
		/// ��ѯ��������
		/// </summary>
		public long m_lngGetOtherRec(string strRegID,string strRecID,ref DataTable p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindOtherRecipe(objPrincipal,strRegID,strRecID,ref p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ������
		/// <summary>
		/// ��ѯ������
		/// </summary>
		public long m_lngGetMainRec(string strRegID,out clsOutpatientRecipe_VO[] clsVO)
		{
			long lngRes = 0;
			clsVO=new clsOutpatientRecipe_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindMainRecipe(objPrincipal,strRegID,out clsVO);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ѯ��������
		/// <summary>
		/// ��ѯ��������
		/// </summary>
		public long m_lngGetRecDesc(string strRecID,out clsOutpatientRecipeDesc_VO clsVO)
		{
			long lngRes = 0;
			clsVO=new clsOutpatientRecipeDesc_VO();
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindRecipeDesc(objPrincipal,strRecID,out clsVO);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		//���洦��
		#region ��ҩ
		public long m_lngSaveWest(clsOutpatientRecipe_VO clsRec,clsOutpatientPWMRecipeDe_VO[] clsVO,bool IsNew)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			if(IsNew)
				lngRes = objSvc.m_lngAddWestRecipe(objPrincipal,clsVO,clsRec);
			else
			{
				lngRes = objSvc.m_lngUPDWestRecipe(objPrincipal,clsVO);
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ҩ
		public long m_lngSaveCM(clsOutpatientRecipe_VO clsRec,clsOutpatientCMRecipeDe_VO[] clsVO,bool IsNew)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			if(IsNew)
				lngRes = objSvc.m_lngAddCMRecipe(objPrincipal,clsVO,clsRec);
			else
			{
				lngRes = objSvc.m_lngUPDCMRecipe(objPrincipal,clsVO);
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ����
		public long m_lngSaveChk(clsOutpatientRecipe_VO clsRec,clsOutpatientCHKRecipeDe_VO[] clsVO,bool IsNew)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			if(IsNew)
				lngRes = objSvc.m_lngAddCHKRecipe(objPrincipal,clsVO,clsRec);
			else
			{
				lngRes = objSvc.m_lngUPDCHKRecipe(objPrincipal,clsVO);
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ���
		public long m_lngSaveTest(clsOutpatientRecipe_VO clsRec,clsOutpatientTestRecipeDe_VO[] clsVO,bool IsNew)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			if(IsNew)
				lngRes = objSvc.m_lngAddTestRecipe(objPrincipal,clsVO,clsRec);
			else
			{
				lngRes = objSvc.m_lngUPDTestRecipe(objPrincipal,clsVO);
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��������
		public long m_lngSaveOPS(clsOutpatientRecipe_VO clsRec,clsOutpatientOPSRecipeDe_VO[] clsVO,bool IsNew)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			if(IsNew)
				lngRes = objSvc.m_lngAddOPSRecipe(objPrincipal,clsVO,clsRec);
			else
			{
				lngRes = objSvc.m_lngUPDOPSRecipe(objPrincipal,clsVO);
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��������
		public long m_lngSaveOther(clsOutpatientRecipe_VO clsRec,clsOutpatientOtherRecipeDe_VO[] clsVO,bool IsNew)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			if(IsNew)
				lngRes = objSvc.m_lngAddOtherRecipe(objPrincipal,clsVO,clsRec);
			else
			{
				lngRes = objSvc.m_lngUPDOtherRecipe(objPrincipal,clsVO);
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��������
		public long m_lngSaveDesc(clsOutpatientRecipe_VO[] clsVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngUPDRecipeDesc(objPrincipal,clsVO);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region ɾ��������ϸ
		public long m_lngDelRecipeDet(string strID,string RecID,int RecType)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			switch(RecType)
			{
				case 1: //��ҩ
					lngRes=objSvc.m_lngDelWestRecipe(objPrincipal,strID,RecID);
					break;
				case 2: //��ҩ
					lngRes=objSvc.m_lngDelCMRecipe(objPrincipal,strID,RecID);
					break;
				case 3: //����
					lngRes=objSvc.m_lngDelCHKRecipe(objPrincipal,strID,RecID);
					break;
				case 4: //���
					lngRes=objSvc.m_lngDelTestRecipe(objPrincipal,strID,RecID);
					break;
				case 5: //��������
					lngRes=objSvc.m_lngDelOPSRecipe(objPrincipal,strID,RecID);
					break;
                case 6: //����
					lngRes=objSvc.m_lngDelOtherRecipe(objPrincipal,strID,RecID);
					break; 
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��鲡���Ƿ���ڴ���
		public long m_lngCheckMainRecipe(string strRegID)
		{
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			long lngRes = objSvc.m_lngCheckMainRecipe(objPrincipal,strRegID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ����Ƿ��ܲ鿴���˴���
		/// <summary>
		/// ����Ƿ��ܲ鿴���˴���
		/// </summary>
		public long m_lngCheckPatRecipe(string strRegID,string DocID,ref DataTable dtResult)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngCheckPatRecipe(objPrincipal,strRegID,DocID,ref dtResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �鿴����
		/// <summary>
		/// �鿴����
		/// </summary>
		public long m_lngFindPatCase(string strRegID,
			out clsOutpatientCaseHis_VO clsCase,out clsOutpatientDiagRec_VO clsDiag)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngFindCaseAndCure(objPrincipal,strRegID,out clsCase,out clsDiag);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ���没��
		/// <summary>
		/// ���没��
		/// </summary>
		public long m_lngSavePatCase(clsOutpatientCaseHis_VO clsCase)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngSaveCase(objPrincipal,clsCase);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region �������Ƽ�¼
		/// <summary>
		/// �������Ƽ�¼
		/// </summary>
		public long m_lngSaveCureRec(clsOutpatientDiagRec_VO clsVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorSvc));
			lngRes = objSvc.m_lngSaveCure(objPrincipal,clsVO);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
