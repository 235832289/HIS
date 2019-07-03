using System;

using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsLabCheckItemAdminDomain.
	/// </summary>
	public class clsLabCheckItemAdminDomain
	{
		public clsLabCheckItemAdminDomain()
		{

		}		

		/// <summary>
		/// 获取所有检验项目的名称和ID
		/// </summary>
		/// <param name="p_objLabCheckItemArr"></param>
		/// <returns></returns>
		public long m_lngGetLabCheckItems(out clsLabCheckItem[] p_objLabCheckItemArr)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetLabCheckItems(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,out p_objLabCheckItemArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		/// <summary>
		/// 获取所有检验项目分组
		/// </summary>
		/// <param name="p_objLabCheckGroupArr"></param>
		/// <returns></returns>
		public long m_lngGetLabCheckGroups(out clsLabCheckGroup[] p_objLabCheckGroupArr)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetLabCheckGroups(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,out p_objLabCheckGroupArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strGroupID"></param>
		/// <returns></returns>
		public long m_lngGetMaxGroupID(out string p_strGroupID)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetMaxGroupID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,out p_strGroupID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objLabCheckGroup"></param>
		/// <returns></returns>
		public long m_lngAddNewGroup(clsLabCheckGroup p_objLabCheckGroup)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngAddNewGroup(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objLabCheckGroup);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}	

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_objLabCheckGroupItemArr"></param>
		/// <returns></returns>
		public long m_lngAddNewGroupItem(clsLabCheckGroupItem[] p_objLabCheckGroupItemArr)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngAddNewGroupItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objLabCheckGroupItemArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strGroupID"></param>
		/// <returns></returns>
		public long m_lngModifyGroupItem(string p_strGroupID)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngModifyGroupItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strGroupID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strGroupID"></param>
		/// <returns></returns>
		public long m_lngDeleteGroup(string p_strGroupID)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngDeleteGroupItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strGroupID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strGroupID"></param>
		/// <returns></returns>
		public long m_lngModifyGroupDesc(string p_strGroupID,clsLabCheckGroup p_objLabCheckGroup)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngModifyGroupDesc(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strGroupID,p_objLabCheckGroup);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		public long m_lngGetLabCheckGroupItem(string p_strGroupID,out clsLabCheckItem[] p_objRecordContentArr)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetLabCheckGroupItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strGroupID,out p_objRecordContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		public long m_lngGetUnGroupLabCheckItems(out clsLabCheckItem[] p_objRecordContentArr)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetUnGroupLabCheckItems(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,out p_objRecordContentArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		public long m_lngGetLabCheckItemsSpecial(string p_strItemID, out clsLabCheckItem p_objRecordContent)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetLabCheckItemsSpecial(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strItemID, out p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}

		public long m_lngGetLabCheckGroupSpecial(string p_strGroupID, out clsLabCheckGroup p_objRecordContent)
		{
            com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService m_objServ =
                (com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.LabCheckItemAdminService.clsLabCheckItemAdminService));

			long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetLabCheckGroupSpecial(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strGroupID, out p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
		}
	}
}
