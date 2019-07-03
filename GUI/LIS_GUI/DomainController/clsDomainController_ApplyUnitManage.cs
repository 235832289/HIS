using System;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainController_ApplyUnitManage ��ժҪ˵����
	/// ���� 2004.05.26
	/// </summary>
	public class clsDomainController_ApplyUnitManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsDomainController_ApplyUnitManage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ����һ�����뵥ԪID�õ���������������ID�б� 
		public long m_lngGetSampleTypeIDList(
			string[] p_strApplyUnitIDArr,
			out string[] p_strSampleTypeIDArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc));
			lngRes = objSvc.m_lngGetSampleTypeIDList(objPrincipal,p_strApplyUnitIDArr,out p_strSampleTypeIDArr);
			//			clsApplyUnitSvc.Dispose();
			
			return lngRes;
		}
		#endregion


		#region �������뵥Ԫ ͯ�� 2004.11.13
		public long m_lngSetApplyUnit(clsApplUnit_VO p_objApplyUnit,ArrayList p_arlAddDetail,ArrayList p_arlRemoveDetail)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc));
			lngRes = objSvc.m_lngSetApplyUnit(objPrincipal,p_objApplyUnit,p_arlAddDetail,p_arlRemoveDetail);
			//			clsApplyUnitSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region ���ݼ�������ȡ���뵥Ԫ ͯ�� 2004.09.17
		public long m_lngGetApplUnitByCheckCategory(string p_strCheckCategory,out clsApplUnit_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc));
			lngRes = objSvc.m_lngGetApplUnitByCheckCategory(objPrincipal,p_strCheckCategory,out p_objResultArr);
			//			clsApplyUnitSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region �������뵥ԪID�õ����뵥ԪVO  ���� 2004.05.28
		/// <summary>
		///  �������뵥ԪID�õ����뵥ԪVO 
		/// </summary>
		/// <param name="p_strApplyUnitID"></param>
		/// <param name="p_objApplUnit"></param>
		/// <returns></returns>
		public long m_lngGetApplyUnitVOByApplyUnitID(string p_strApplyUnitID,out clsApplUnit_VO p_objApplUnit)
		{
			long lngRes = 0;
			p_objApplUnit = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc));
			lngRes = objSvc.m_lngGetApplyUnitVOByApplyUnitID(objPrincipal,p_strApplyUnitID,out p_objApplUnit);
			//			clsApplyUnitSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region ��ȡ���е����뵥Ԫ ͯ�� 2004.05.26
		public long m_lngGetAllApplUnit(out clsApplUnit_VO[] objApplUnitVOList)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc));
			lngRes = objSvc.m_lngGetAllApplUnit(objPrincipal,out objApplUnitVOList);
//			clsApplyUnitSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ�����뵥Ԫ��ϸ ͯ�� 2004.05.28
		public long m_lngDelApplUnitDetail(string strApplUnitID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc objApplyUnitSvc = (com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc));
			lngRes = objApplyUnitSvc.m_lngDelApplUnitDetail(objPrincipal,strApplUnitID);
//			objApplyUnitSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ�����뵥Ԫ������ϸ ͯ�� 2004.05.27
		public long m_lngDelApplUnitAndDetail(string strApplUnitID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc objApplyUnitSvc = (com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc));
			lngRes = objApplyUnitSvc.m_lngDelApplUnitAndDetail(objPrincipal,strApplUnitID);
//			objApplyUnitSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �������뵥Ԫ������ϸ ͯ�� 2004.05.27
		public long m_lngAddApplUnitAndDetail(ref clsApplUnit_VO objApplUnitVO,ref clsApplUnitDetail_VO[] objApplUnitDetailVOList)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc objApplyUnitSvc = (com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc)
				com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplyUnitSvc));
			lngRes = objApplyUnitSvc.m_lngAddApplUnitAndDetail(objPrincipal,ref objApplUnitVO,ref objApplUnitDetailVOList);
//			objApplyUnitSvc.Disposed();
			return lngRes;
		}
		#endregion

		#region �������뵥ԪID��ѯ���еļ�����Ŀ��Ϣ ͯ�� 2004.05.26
		public long m_lngGetCheckItemByApplUnitID(string strApplUnitID,out DataTable dtbCheckItem)
		{
			long lngRes = 0;
			dtbCheckItem = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemByApplUnitID(objPrincipal,strApplUnitID,out dtbCheckItem);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �������뵥ԪID��ѯ���еļ�����Ŀ��Ϣ ͯ�� 2004.05.26
		public long m_lngGetCheckItemByApplUnitID(string strApplUnitID,out clsCheckItem_VO[] p_objCheckItemVOArr)
		{
			long lngRes = 0;
			p_objCheckItemVOArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetCheckItemByApplUnitID(objPrincipal,strApplUnitID,out p_objCheckItemVOArr);
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region ��ȡ���뵥Ԫ����
        /// <summary>
        /// ��ȡ���뵥Ԫ����
        /// </summary>
        /// <param name="p_strAppUnitArr"></param>
        /// <param name="p_strOutAppUnitArr"></param>
        /// <returns></returns>
        public long m_lngQueryAppUnitSeq(string[] p_strAppUnitArr, out string[] p_strOutAppUnitArr)
        {
            long lngRes = 0;
            p_strOutAppUnitArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyUnitSvc));
            lngRes = objSvc.m_lngQueryAppUnitSeq(p_strAppUnitArr, out p_strOutAppUnitArr);
            //			clsApplyUnitSvc.Dispose();

            return lngRes;
        }
        #endregion
    }
}
