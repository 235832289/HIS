using System;
using com.digitalwave.AssistantToolService;
using System.Data;
using iCareData;

namespace iCare.AssitantTool
{
	/// <summary>
	/// 特殊符号业务逻辑层
	/// </summary>
	public class clsSpecialSymbolDomain
	{
        //private clsSpecialSymbolServ m_objServ = new clsSpecialSymbolServ();
		
		public clsSpecialSymbolDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public long m_lngGetAlSpecialSymbolValue(out clsSpecialSymbolValue[] p_objSpecialSymbolValueArr)
		{
			p_objSpecialSymbolValueArr = null;
            long lngRes = 0;
            clsSpecialSymbolServ m_objServ =
                (clsSpecialSymbolServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSpecialSymbolServ));

            try
            {
                DataTable dtbResult;
                lngRes = m_objServ.m_lngGetAllSpecialSymbolValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentArea.m_strDEPTID_CHR, out dtbResult);
                if (lngRes >= 0 && dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    p_objSpecialSymbolValueArr = new clsSpecialSymbolValue[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        p_objSpecialSymbolValueArr[i] = new clsSpecialSymbolValue();
                        p_objSpecialSymbolValueArr[i].m_strDeptID = clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID;
                        p_objSpecialSymbolValueArr[i].m_strSpecialSymbolValue = dtbResult.Rows[i][0].ToString();
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
		public  long m_lngAddNewRecord2DB(clsSpecialSymbolValue p_objRecordContent)
		{					
			long lngRes = 0;
            clsSpecialSymbolServ m_objServ =
                (clsSpecialSymbolServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSpecialSymbolServ));

            try
            {
                lngRes = m_objServ.m_lngAddNewRecord2DB(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objRecordContent);
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
		public  long m_lngModifyRecord2DB(clsSpecialSymbolValue p_objOldRecordContent,clsSpecialSymbolValue p_objNewRecordContent)
		{
			long lngRes = 0;
            clsSpecialSymbolServ m_objServ =
                 (clsSpecialSymbolServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSpecialSymbolServ));

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
		public  long m_lngDeleteRecord2DB(clsSpecialSymbolValue p_objRecordContent)
		{
			long lngRes = 0;
            clsSpecialSymbolServ m_objServ =
                (clsSpecialSymbolServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSpecialSymbolServ));

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
