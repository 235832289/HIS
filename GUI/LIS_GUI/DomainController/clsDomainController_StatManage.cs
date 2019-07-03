using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainController_StatManage ��ժҪ˵����
	/// </summary>
	public class clsDomainController_StatManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		public clsDomainController_StatManage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ����������ѯѧ��ͳ�Ƶ���Ϣ ͯ�� 2005.01.17
		public long m_lngGetScienceStatByCondition(string p_strDatFrom,string p_strDatTo,string p_strAgeFrom,string p_strAgeTo,
			string p_strSex,clsLisScienceStatItemQueryCondition[] p_objRecordArr,out DataTable dtbHead,out DataTable dtbDetail)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetScienceStatByCondition(objPrincipal,p_strDatFrom,p_strDatTo,p_strAgeFrom,p_strAgeTo,p_strSex,
				p_objRecordArr,out dtbHead,out dtbDetail);
			//			objSvc.Dispose();

			return lngRes;
		}
		#endregion

		#region ����������ѯѧ��ͳ�Ƶ���Ϣ 2004.12.16
		public long m_lngGetScienceStatByCondition(string p_strDatFrom,string p_strDatTo,string p_strAgeFrom,string p_strAgeTo,
			string p_strSex,clsLisScienceStatItemQueryCondition[] p_objRecordArr,out DataTable dtbResult)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetScienceStatByCondition(objPrincipal,p_strDatFrom,p_strDatTo,p_strAgeFrom,p_strAgeTo,p_strSex,
				p_objRecordArr,out dtbResult);
			//			objSvc.Dispose();

			return lngRes;
		}
		#endregion

		#region ����������ѯѧ��ͳ�Ƶ���Ϣ ͯ�� 2004.12.03
		public long m_lngGetScienceStatByCondition(string p_strDatFrom,string p_strDatTo,string p_strCheckItemID,string p_strResultFrom,
			string p_strResultTo,string p_strAgeFrom,string p_strAgeTo,string p_strSex,string p_strLowCompare,string p_strCondition,
			string p_strUpCompare,out DataTable p_DataTable)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                (typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetScienceStatByCondition(objPrincipal,p_strDatFrom,p_strDatTo,p_strCheckItemID,p_strResultFrom,p_strResultTo,
				p_strAgeFrom,p_strAgeTo,p_strSex,p_strLowCompare,p_strCondition,p_strUpCompare,out p_DataTable);
			//			objSvc.Dispose();

			return lngRes;
		}
		#endregion

		#region ������û���ͳ�� ͯ�� 2004.09.23
		public long m_lngGetCheckPriceTotalReport(string p_strDatFrom,string p_strDatTo,string p_strOprID,out DataTable p_dtbResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetCheckPriceTotalReport(objPrincipal,p_strDatFrom,p_strDatTo,p_strOprID,out p_dtbResult);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �������ϸͳ�� ͯ�� 2004.09.23
		public long m_lngGetCheckPriceDetailReport(string p_strDatFrom,string p_strDatTo,string p_strOprID,out DataTable p_dtbResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetCheckPriceDetailReport(objPrincipal,p_strDatFrom,p_strDatTo,p_strOprID,out p_dtbResult);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ������ͳ����ϸ ͯ�� 2004.09.23
		public long m_lngGetStatDetailReport(string p_strDatFrom,string p_strDatTo,string p_strOprID,out DataTable p_dtbResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetStatDetailReport(objPrincipal,p_strDatFrom,p_strDatTo,p_strOprID,out p_dtbResult);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ������ͳ�ƻ��� ͯ�� 2004.09.22
		public long m_lngGetStatTotalReport(string p_strDatFrom,string p_strDatTo,string p_strOprID,out DataTable p_dtbResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetStatTotalReport(objPrincipal,p_strDatFrom,p_strDatTo,p_strOprID,out p_dtbResult);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ������ģ��

		#region ��ѯ���еĹ�������Ϣ ͯ�� 2004.09.17
		public long m_lngGetAllWorkGroupInfo(out DataTable p_dtbResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetAllWorkGroupInfo(objPrincipal,out p_dtbResult);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ѯ���еĹ�������Ϣ ͯ�� 2004.09.16
		public long m_lngGetAllWorkGroupInfo(out clsLisWorkGroup_VO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetAllWorkGroupInfo(objPrincipal,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ���������� ͯ�� 2004.09.16
		public long m_lngAddNewWorkGroup(clsLisWorkGroup_VO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsStatSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsStatSvc));
			lngRes = objSvc.m_lngAddNewWorkGroup(objPrincipal,p_objRecord);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ���¹�������Ϣ ͯ�� 2004.09.16
		public long m_lngModifyWorkGroup(clsLisWorkGroup_VO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsStatSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsStatSvc));
			lngRes = objSvc.m_lngModifyWorkGroup(objPrincipal,p_objRecord);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ����������Ϣ ͯ�� 2004.09.16
		public long m_lngDelWorkGroup(string p_strWorkGroupID,string p_strStatus)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsStatSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsStatSvc));
			lngRes = objSvc.m_lngDelWorkGroup(objPrincipal,p_strWorkGroupID,p_strStatus);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#endregion

		#region ͳ����ģ��
		#region ��ȡ���е�ͳ������Ϣ ͯ�� 2004.09.17
		public long m_lngGetAllStatGroupInfo(out clsLisStatGroup_VO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetAllStatGroupInfo(objPrincipal,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ���е�ͳ�������뵥Ԫ��Ϣ ͯ�� 2004.09.17
		public long m_lngGetAllStatGroupUnitInfo(out clsLisStatGroupUnit_VO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetAllStatGroupUnitInfo(objPrincipal,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ����ͳ���鼰����ϸ ͯ�� 2004.09.20
		public long m_lngAddNewStatGroup(clsLisStatGroup_VO p_objStatGroup,clsLisStatGroupUnit_VO[] p_objStatGroupUnitArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsStatSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsStatSvc));
			lngRes = objSvc.m_lngAddNewStatGroup(objPrincipal,p_objStatGroup,p_objStatGroupUnitArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ����ͳ����ID��ȡ�����µ����뵥Ԫ��Ϣ ͯ�� 2004.09.20
		public long m_lngGetApplUnitByStatGroupID(string p_strStatGroupID,out clsApplUnit_VO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
			lngRes = objSvc.m_lngGetApplUnitByStatGroupID(objPrincipal,p_strStatGroupID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ����ͳ���鼰��ϸ ͯ�� 2004.09.20
		public long m_lngModifyStatGroup(clsLisStatGroup_VO p_objStatGroup,clsLisStatGroupUnit_VO[] p_objStatGroupUnitArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsStatSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsStatSvc));
			lngRes = objSvc.m_lngModifyStatGroup(objPrincipal,p_objStatGroup,p_objStatGroupUnitArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ��ͳ���� ͯ�� 2004.09.20
		public long m_lngDelStatGroup(string p_strStatGroupID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsStatSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
				objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsStatSvc));
			lngRes = objSvc.m_lngDelStatGroup(objPrincipal,p_strStatGroupID);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion

        #region ͳ������������
        /// <summary>
        /// ͳ������������
        /// </summary>
        /// <param name="p_datStart"></param>
        /// <param name="p_datEnd"></param>
        /// <param name="p_dtStatisResult"></param>
        public void m_mthGetDeviceCheckStatis(DateTime p_datStart, DateTime p_datEnd, ref DataTable p_dtStatisResult)
        {
            com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc)com.digitalwave.iCare.common.clsObjectGenerator.
                objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryStatSvc));
            objSvc.m_mthGetDeviceCheckStatis(p_datStart, p_datEnd, ref p_dtStatisResult);
        }
        #endregion
    }
}
