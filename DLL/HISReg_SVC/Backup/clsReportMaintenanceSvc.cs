using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
	/// <summary>
	/// 报告字段与发费类别对应维护中间件 gphuang 
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]

	public class clsReportMaintenanceSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsReportMaintenanceSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 查找报表信息
		/// <summary>
		/// 查找报表信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="str"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetReportInfo(System.Security.Principal.IPrincipal p_objPrincipal,
			string str,out clsReportMain_VO[] objResult)
		{
			long lngRes = 0;
			objResult=null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthGetReportInfo");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Select * From T_AID_RPT_DEF ";
			
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);				
				objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsReportMain_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsReportMain_VO();
						objResult[i1].strReportID=dtResult.Rows[i1]["RPTID_CHR"].ToString().Trim();
						objResult[i1].strReportName=dtResult.Rows[i1]["RPTNAME_CHR"].ToString().Trim();
						
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 根据报表ID查找报表字段
		/// <summary>
		/// 根据报表ID查找报表字段
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="str"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetGroupByID(System.Security.Principal.IPrincipal p_objPrincipal,
			string strID,out clsReportDetail_VO[] objResult)
		{
			long lngRes = 0;
			objResult=null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthGetGroupByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Select * From T_AID_RPT_GOP_DEF ";
			if(strID.Trim()!="")
			{
			strSQL+=" where RPTID_CHR = '"+strID+"'";
			}
			
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);				
			objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsReportDetail_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsReportDetail_VO();
						objResult[i1].strReportID=dtResult.Rows[i1]["RPTID_CHR"].ToString().Trim();
						objResult[i1].strGroupID=dtResult.Rows[i1]["GROUPID_CHR"].ToString().Trim();
						objResult[i1].strGroupName=dtResult.Rows[i1]["GROUPNAME_CHR"].ToString().Trim();
						
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 根据报表ID,字段ID,分类标志查找分类信息
		/// <summary>
		/// 根据报表ID,字段ID,分类标志查找分类信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="str"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetGroupDetailByID(System.Security.Principal.IPrincipal p_objPrincipal,
			string strReportID,string strGroupID,string strflag,out clsGroupDetail_VO[] objResult)
		{
			long lngRes = 0;
			objResult=null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthGetGroupDetailByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="select * from T_AID_RPT_GOP_RLA where RPTID_CHR ='"+strReportID+"' and GROUPID_CHR ='"+strGroupID+"'and FLAG_INT like '"+strflag+"%'";
			
			
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);				
			objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsGroupDetail_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsGroupDetail_VO();
						objResult[i1].strReportID=dtResult.Rows[i1]["RPTID_CHR"].ToString().Trim();
						objResult[i1].strGroupID=dtResult.Rows[i1]["GROUPID_CHR"].ToString().Trim();
						objResult[i1].strTypeID=dtResult.Rows[i1]["TYPEID_CHR"].ToString().Trim();
						objResult[i1].intFlag=int.Parse(dtResult.Rows[i1]["FLAG_INT"].ToString().Trim());
						
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 保存报表信息
	[AutoComplete]
		public long m_mthAddNewReportInfo(System.Security.Principal.IPrincipal p_objPrincipal,clsReportMain_VO obj_VO)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthAddNewReportInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL = "INSERT INTO T_AID_RPT_DEF (RPTID_CHR,RPTNAME_CHR) VALUES (?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(2,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = obj_VO.strReportID;//p_objRecord.m_strAPPID_CHR;
				objLisAddItemRefArr[1].Value = obj_VO.strReportName;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
			[AutoComplete]
		public long m_mthUpdateReportInfo(System.Security.Principal.IPrincipal p_objPrincipal,string strID,clsReportMain_VO obj_VO,bool flag)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthUpdateReportInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL = "update T_AID_RPT_DEF set RPTID_CHR =?,RPTNAME_CHR =? where RPTID_CHR =?";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(3,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = obj_VO.strReportID;//p_objRecord.m_strAPPID_CHR;
				objLisAddItemRefArr[1].Value = obj_VO.strReportName;
				objLisAddItemRefArr[2].Value = strID;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				if(flag)	
				{
				strSQL ="update T_AID_RPT_GOP_DEF set RPTID_CHR = '"+obj_VO.strReportID+"' where RPTID_CHR = '"+strID+"'";
				lngRes = objHRPSvc.DoExcute(strSQL);
				strSQL ="update T_AID_RPT_GOP_RLA set RPTID_CHR = '"+obj_VO.strReportID+"' where RPTID_CHR = '"+strID+"'";
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
				}
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
				return lngRes;
		}
			[AutoComplete]
		public long m_mthDeleteReportByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthDeleteReportByID");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL = "delete T_AID_RPT_DEF where RPTID_CHR ='"+strID+"'";
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);
				strSQL = "delete T_AID_RPT_GOP_DEF where RPTID_CHR ='"+strID+"'";
				lngRes = objHRPSvc.DoExcute(strSQL);
				strSQL = "delete T_AID_RPT_GOP_RLA where RPTID_CHR ='"+strID+"'";
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region
		[AutoComplete]
		public long m_mthAddNewReportInfo2(System.Security.Principal.IPrincipal p_objPrincipal,clsReportDetail_VO obj_VO)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthAddNewReportInfo2");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL = "INSERT INTO T_AID_RPT_GOP_DEF (RPTID_CHR,GROUPID_CHR,GROUPNAME_CHR) VALUES (?,?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(3,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = obj_VO.strReportID;//p_objRecord.m_strAPPID_CHR;
				objLisAddItemRefArr[1].Value = obj_VO.strGroupID;
				objLisAddItemRefArr[2].Value = obj_VO.strGroupName;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		[AutoComplete]
		public long m_mthUpdateReportInfo2(System.Security.Principal.IPrincipal p_objPrincipal,string strID,clsReportDetail_VO obj_VO,bool flag)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthUpdateReportInfo2");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL = "update T_AID_RPT_GOP_DEF set GROUPID_CHR =?,GROUPNAME_CHR =? where RPTID_CHR =? and GROUPID_CHR =?";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(4,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = obj_VO.strGroupID;//p_objRecord.m_strAPPID_CHR;
				objLisAddItemRefArr[1].Value = obj_VO.strGroupName;
				objLisAddItemRefArr[2].Value = obj_VO.strReportID;
				objLisAddItemRefArr[3].Value = strID;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				if(flag)	
				{
					strSQL ="update T_AID_RPT_GOP_RLA set GROUPID_CHR ='"+obj_VO.strGroupID+"' where RPTID_CHR ='"+obj_VO.strReportID+"' and GROUPID_CHR='"+strID+"'";
					lngRes = objHRPSvc.DoExcute(strSQL);
					
				}
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		[AutoComplete]
		public long m_mthDeleteReportByID2(System.Security.Principal.IPrincipal p_objPrincipal,string strID,string strReportID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthDeleteReportByID2");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL = "delete T_AID_RPT_GOP_DEF where GROUPID_CHR ='"+strID+"' and RPTID_CHR ='"+strReportID+"'";
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);
				strSQL = "delete T_AID_RPT_GOP_RLA where RPTID_CHR ='"+strReportID+"' and GROUPID_CHR ='"+strID+"'";
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
						
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		[AutoComplete]
		public long m_mthSaveGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,clsGroupDetail_VO[] obj_VO)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsReportMaintenanceSvc","m_mthSaveGroupDetail");
			if(lngRes < 0)
			{
				return -1;
			}
//			this.m_mthDeleteGroupDetail(obj_VO[0]);
			
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
		
			string strSQL="delete T_AID_RPT_GOP_RLA where RPTID_CHR ='"+obj_VO[0].strReportID+"' and GROUPID_CHR ='"+obj_VO[0].strGroupID+"' and FLAG_INT='"+obj_VO[0].intFlag+"'";
			lngRes = objHRPSvc.DoExcute(strSQL);
			if(obj_VO.Length==1&&obj_VO[0].strTypeID==null)
			{
				return lngRes;
			}
			try
			{
				for(int i=0;i<obj_VO.Length;i++)
				{
				 strSQL = "INSERT INTO T_AID_RPT_GOP_RLA (RPTID_CHR,GROUPID_CHR,TYPEID_CHR,FLAG_INT) VALUES ('"+obj_VO[i].strReportID+"','"+obj_VO[i].strGroupID+"','"+obj_VO[i].strTypeID+"','"+obj_VO[i].intFlag+"')";
				lngRes = objHRPSvc.DoExcute(strSQL);
				}
			
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		[AutoComplete]
		private void m_mthDeleteGroupDetail(clsGroupDetail_VO obj_VO)
		{
			string strSQL = "INSERT INTO T_AID_RPT_GOP_DEF (RPTID_CHR,GROUPID_CHR,GROUPNAME_CHR) VALUES (?,?,?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			long lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
		
		}
	}
}
