using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.HIS
{
	#region 药理分类维护业务操作
	/// <summary>	
	/// 药理分类维护业务操作
	/// Create 黄伟灵 by 2005-09-8
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsHISMedTypeManageSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsHISMedTypeManageSvc()
		{
		
		}
		#endregion

		#region 中间件方法：对药理分类维护的业务操作
		
		#region 方法：取得所有结点
		/// <summary>
		/// 方法：取得所有结点
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="strMainID">取得所有结点</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		[AutoComplete]
		public long m_lngGetMedTypeInfo(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsHISMedType_VO[] p_objResultArr, string strMainID)
		{
			long lngRes = 0;
			p_objResultArr = new clsHISMedType_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc","m_lngGetMedTypeInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"Select * From T_BSE_PHARMATYPE order by PHARMAID_CHR";
			
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new com.digitalwave.iCare.ValueObject.clsHISMedType_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsHISMedType_VO();
						p_objResultArr[i1].m_strPHARMAID_CHR = dtbResult.Rows[i1]["PHARMAID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strPHARMANAME_VCHR = dtbResult.Rows[i1]["PHARMANAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strASSISTCODE_VCHR = dtbResult.Rows[i1]["ASSISTCODE_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strPYCODE_VCHR = dtbResult.Rows[i1]["PYCODE_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strWBCODE_VCHR = dtbResult.Rows[i1]["WBCODE_VCHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["PARENTID_CHR"]!=System.DBNull.Value)
						p_objResultArr[i1].m_strPARENTID_CHR = dtbResult.Rows[i1]["PARENTID_CHR"].ToString().Trim();
						else
						p_objResultArr[i1].m_strPARENTID_CHR=null;
						
					}
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
		#endregion

		#region 药理分类维护业务操作:修改分类信息结点
		/// <summary>
		/// 药理分类维护业务操作:修改分类信息结点
		/// Create 黄伟灵 by 2005-09-8
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objRecord">VO数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		[AutoComplete]
		public long m_lngModify(System.Security.Principal.IPrincipal p_objPrincipal,clsHISMedType_VO p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc","m_lngModify");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @" UPDATE T_BSE_PHARMATYPE SET PHARMANAME_VCHR =?,ASSISTCODE_VCHR =?,PYCODE_VCHR =?,WBCODE_VCHR =? ,PARENTID_CHR = ? WHERE 
 PHARMAID_CHR =?";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				IDataParameter[] objDPArr = null;
				objHRPSvc.CreateDatabaseParameter(6,out objDPArr);
				objDPArr[0].Value = p_objRecord.m_strPHARMANAME_VCHR;
				objDPArr[1].Value = p_objRecord.m_strASSISTCODE_VCHR;
				objDPArr[2].Value = p_objRecord.m_strPYCODE_VCHR;
				objDPArr[3].Value = p_objRecord.m_strWBCODE_VCHR;
				objDPArr[4].Value = p_objRecord.m_strPARENTID_CHR;
				objDPArr[5].Value = p_objRecord.m_strPHARMAID_CHR;
				long l=0;
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref l,objDPArr);				
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

		#region 药理分类维护业务操作:增加分类信息结点
		/// <summary>
		/// 药理分类维护业务操作:增加分类信息结点
		/// Create 黄伟灵 by 2005-09-9
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objRecord">VO数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		[AutoComplete]
		public long m_lngAddNew(System.Security.Principal.IPrincipal p_objPrincipal,com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO,out com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VOReturn )
		{
			long lngRes=0;			
			string strRecordID = "";

			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc","m_lngAddNew");

			lngRes = objHRPSvc.lngGenerateID(5,"PHARMAID_CHR","T_BSE_PHARMATYPE",out strRecordID);
			objTD_VO.m_strPHARMAID_CHR = strRecordID;

			//把结果输出：
			objTD_VOReturn = objTD_VO;

			
			if(lngRes < 0)
			{
				return -1;
			}

			if(lngRes < 0)
				return lngRes;
			
			string strSQL = "INSERT INTO T_BSE_PHARMATYPE (PHARMAID_CHR,PHARMANAME_VCHR,ASSISTCODE_VCHR,PYCODE_VCHR,WBCODE_VCHR,PARENTID_CHR) VALUES (?,?,?,?,?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(6,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = objTD_VO.m_strPHARMAID_CHR;
				objLisAddItemRefArr[1].Value = objTD_VO.m_strPHARMANAME_VCHR;
				objLisAddItemRefArr[2].Value = objTD_VO.m_strASSISTCODE_VCHR;
				objLisAddItemRefArr[3].Value = objTD_VO.m_strPYCODE_VCHR;
				objLisAddItemRefArr[4].Value = objTD_VO.m_strWBCODE_VCHR;
				objLisAddItemRefArr[5].Value = objTD_VO.m_strPARENTID_CHR;
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
		#endregion

		#region 中间件方法：删除分类信息结点
		/// <summary>
		/// 药理分类维护业务操作:删除分类信息结点
		/// Create 黄伟灵 by 2005-09-9
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objRecord">VO数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		[AutoComplete]
		public long m_lngDelete(System.Security.Principal.IPrincipal p_objPrincipal,clsHISMedType_VO p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc","m_lngDelete");
			if(lngRes < 0)
			{
				return -1;
			}
			
			string strSQL = "DELETE FROM T_BSE_PHARMATYPE WHERE PHARMAID_CHR ='"+p_objRecord.m_strPHARMAID_CHR.Trim()+"'";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);				
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

		#region 方法：判断助记码是否唯一。
		/// <summary>
		/// 方法：判断助记码是否唯一
		/// </summary>
		/// <param name="blnHasThisZhujima">返回结果，已存在此助记码则返回true</param>
		/// <param name="p_strZhuJiMa">助记码数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		[AutoComplete]
		public long m_lngGetMedTypeZhuJiMaById(System.Security.Principal.IPrincipal p_objPrincipal,
			out bool blnHasThisZhujima, string p_strZhuJiMa)
		{

			long lngRes = 0;
			blnHasThisZhujima = false;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc","m_lngGetMedTypeZhuJiMaById");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"Select count(*) From T_BSE_PHARMATYPE where ASSISTCODE_VCHR='"+p_strZhuJiMa+"'";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{					
					if(Convert.ToInt32(dtbResult.Rows[0][0].ToString())!=0)
					{	
						blnHasThisZhujima = true;//存在相同
					}
					else
					{
						blnHasThisZhujima = false;
					}					
					
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
		#endregion

		#region 方法：判断某结点是否拥有子结点：（药理分类中是否有子分类）
		/// <summary>
		/// 方法：判断某结点是否拥有子结点：（药理分类中是否有子分类）
		/// </summary>
		/// <param name="blnHasSubNode">返回结果，存在子结点则返回true</param>
		/// <param name="m_strPHARMAID_CHR">数据库中自动产生的ID号</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		[AutoComplete]
		public long m_lngCheckMedTypeIsHasSubById(System.Security.Principal.IPrincipal p_objPrincipal,
			out bool blnHasSubNode, string m_strPHARMAID_CHR)
		{

			long lngRes = 0;
			blnHasSubNode = false;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc","m_lngCheckMedTypeIsHasSubById");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"Select count(*) From T_BSE_PHARMATYPE where PARENTID_CHR='"+m_strPHARMAID_CHR+"'";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{					
					if(Convert.ToInt32(dtbResult.Rows[0][0].ToString())!=0)
					{	
						blnHasSubNode = true;//存在子结点
					}
					else
					{
						blnHasSubNode = false;
					}					
					
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
		#endregion

		#endregion
	}
	#endregion
}
