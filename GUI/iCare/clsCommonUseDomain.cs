using System;
using com.digitalwave.CommonUseServ;
using System.Data;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsCommonUseDomain.
	/// </summary>
	public class clsCommonUseDomain
	{
        //private clsCommonUseServ m_objServ=new clsCommonUseServ();
		public clsCommonUseDomain()
		{			
		}

		public long m_lngGetAllCommonUseType(out clsPublicIDAndName[] p_objTypeArr)
		{
			p_objTypeArr=null;
			DataTable dtbResult;

            clsCommonUseServ m_objServ =
                (clsCommonUseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonUseServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetAllCommonUseType(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out dtbResult);
                if (lngRes >= 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objTypeArr = new clsPublicIDAndName[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objTypeArr[i] = new clsPublicIDAndName();
                        p_objTypeArr[i].m_strID = dtbResult.Rows[i][0].ToString();
                        p_objTypeArr[i].m_strName = dtbResult.Rows[i][1].ToString();
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}
		public long m_lngGetAllCommonUseValue(string p_strCommonUseTypeID,out clsCommonUseValue[] p_objCommonUseValueArr)
		{
			p_objCommonUseValueArr=null;
			
			DataTable dtbResult;

            clsCommonUseServ m_objServ =
                (clsCommonUseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonUseServ));

            long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetAllCommonUseValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strCommonUseTypeID, clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID, out dtbResult);
                if (lngRes >= 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objCommonUseValueArr = new clsCommonUseValue[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objCommonUseValueArr[i] = new clsCommonUseValue();
                        p_objCommonUseValueArr[i].m_strTypeID = p_strCommonUseTypeID;
                        p_objCommonUseValueArr[i].m_strCommonUseValue = dtbResult.Rows[i][0].ToString();
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}

		public long m_lngGetAllCommonUseValue(string p_strCommonUseTypeID,out clsCommonUseValue[] p_objCommonUseValueArr,bool p_blnIsAnaSystem)
		{
			p_objCommonUseValueArr=null;
			long lngRes=0;
			DataTable dtbResult;

            clsCommonUseServ m_objServ =
                (clsCommonUseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonUseServ));

            try
            {
                if (p_blnIsAnaSystem)
                    lngRes = m_objServ.m_lngGetAllCommonUseValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strCommonUseTypeID, "9900001", out dtbResult);
                else
                    lngRes = m_objServ.m_lngGetAllCommonUseValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strCommonUseTypeID, clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID, out dtbResult);
                if (lngRes >= 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objCommonUseValueArr = new clsCommonUseValue[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objCommonUseValueArr[i] = new clsCommonUseValue();
                        p_objCommonUseValueArr[i].m_strTypeID = p_strCommonUseTypeID;
                        p_objCommonUseValueArr[i].m_strCommonUseValue = dtbResult.Rows[i][0].ToString();
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return lngRes;
		}

		/// <summary>
		/// 保存记录到数据库。
		/// </summary>
		/// <param name="p_objRecordContent">记录内容</param>
		/// <returns></returns>
		public  long m_lngAddNewRecord2DB(clsCommonUseValue p_objRecordContent)
		{
            clsCommonUseServ m_objServ =
                (clsCommonUseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonUseServ));

            long lngRes = 0;
            try
            {
                lngRes =  m_objServ.m_lngAddNewRecord2DB(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;	
		}		
		
		/// <summary>
		/// 修改记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objRecordContent"></param>
		/// <returns></returns>
		public  long m_lngModifyRecord2DB(clsCommonUseValue p_objOldRecordContent,clsCommonUseValue p_objNewRecordContent)
		{
            clsCommonUseServ m_objServ =
                (clsCommonUseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonUseServ));

            long lngRes = 0;
            try
            {
                lngRes =  m_objServ.m_lngModifyRecord2DB(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objOldRecordContent,p_objNewRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}		
		
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objRecordContent"></param>
		/// <returns></returns>
		public  long m_lngDeleteRecord2DB(clsCommonUseValue p_objRecordContent)
		{
            clsCommonUseServ m_objServ =
                (clsCommonUseServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCommonUseServ));

            long lngRes = 0;
            try
            {
                lngRes =  m_objServ.m_lngDeleteRecord2DB(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}	
		
	}
}
