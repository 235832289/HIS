using System;
using System.Data;
using System.Collections;
using System.EnterpriseServices;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
	/// <summary>
	/// clsSampleGroupSvc 的摘要说明。
	/// 
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsSampleGroupSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
	{
		#region 构造函数
		public clsSampleGroupSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

        //#region 根据申请单元ID查询标本组与申请单元的关系 
        //[AutoComplete]
        //public long m_lngGetSampleGroupUnitByApplUnitID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strApplUnitID,
        //    out DataTable p_dtbResult)
        //{
        //    long lngRes=0;
        //    p_dtbResult = null;
        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetSampleGroupUnitByApplUnitID");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM T_AID_LIS_SAMPLE_GROUP_UNIT WHERE APPLY_UNIT_ID_CHR = '"+p_strApplUnitID+@"'";
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbResult);
        //        objHRPSvc.Dispose();
        //    }
        //    catch(Exception objEx)
        //    {
        //        string strTmp=objEx.Message;
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

		#region 批量更新标本组下申请单元的检验项目的打印顺序
		[AutoComplete]
		public long m_lngSetApplUnitItemPrintSeqArr(System.Security.Principal.IPrincipal p_objPrincipal,clsApplUnitDetail_VO[] p_objRecordArr)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngSetApplUnitItemPrintSeqArr");
			if(lngRes < 0)
			{
				return -1;
			}

			if(p_objRecordArr != null)
			{
				for(int i=0;i<p_objRecordArr.Length;i++)
				{
					lngRes = m_lngSetApplUnitItemPrintSeq(p_objPrincipal,p_objRecordArr[i]);
				}
			}
			return lngRes;
		}
		#endregion

		#region 更新标本组下申请单元的检验项目的打印顺序 
		[AutoComplete]
		public long m_lngSetApplUnitItemPrintSeq(System.Security.Principal.IPrincipal p_objPrincipal,clsApplUnitDetail_VO  p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngSetApplUnitItemPrintSeq");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_aid_lis_apply_unit_detail
								 SET print_seq_int = '"+p_objRecord.intPrintSeq+@"'
							   WHERE check_item_id_chr = '"+p_objRecord.strCheckItemID+@"' 
								 AND apply_unit_id_chr = '"+p_objRecord.strApplUnitID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
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

		#region 根据样本组ID删除样本组下的申请单元 
		[AutoComplete]
		public long m_lngDelSampleGroupUnitBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelSampleGroupUnitBySampleGroupID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_aid_lis_sample_group_unit
							   WHERE sample_group_id_chr = '"+p_strSampleGroupID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
				if(lngRecEff > -1)
				{
					lngRes = 1;
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

		#region 批量新增样本组下的申请单元 
		[AutoComplete]
		public long m_lngAddNewSampleGroupUnitArr(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,
			clsLisSampleGroupUnit_VO[] p_objRecordArr)
		{
			long lngRes = 0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddNewSampleGroupUnitArr");
			if(lngRes < 0)
			{
				return -1;
			}

			if(p_objRecordArr != null)
			{
				for(int i=0;i<p_objRecordArr.Length;i++)
				{
					p_objRecordArr[i].m_strSAMPLE_GROUP_ID_CHR = p_strSampleGroupID;
					lngRes = m_lngAddNewSampleGroupUnit(p_objPrincipal,p_objRecordArr[i]);
				}
			}
			return lngRes;
		}
		#endregion

		#region 新增样本组下的申请单元
		[AutoComplete]
		public long m_lngAddNewSampleGroupUnit(System.Security.Principal.IPrincipal p_objPrincipal,clsLisSampleGroupUnit_VO p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddNewSampleGroupUnit");
			if(lngRes < 0)
			{
				return -1;
			}

			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL = "INSERT INTO T_AID_LIS_SAMPLE_GROUP_UNIT (APPLY_UNIT_ID_CHR,SAMPLE_GROUP_ID_CHR) VALUES (?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(2,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_objRecord.m_strAPPLY_UNIT_ID_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strSAMPLE_GROUP_ID_CHR;
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

//        #region 根据样本组ID查询该样本组下包含的申请单元
//        /// <summary>
//        /// 根据样本组ID查询该样本组下包含的申请单元
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="p_strSampleGroupID">＝"" || =null为查询全部</param>
//        /// <param name="p_objResultArr"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetApplUnitBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,
//            out clsLisSampleGroupUnit_VO[] p_objResultArr)
//        {
//            long lngRes = 0;
//            p_objResultArr = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetApplUnitBySampleGroupID");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT a.*, b.apply_unit_name_vchr
//								FROM t_aid_lis_sample_group_unit a, t_aid_lis_apply_unit b
//							   WHERE a.apply_unit_id_chr = b.apply_unit_id_chr";
//            if(p_strSampleGroupID != null && p_strSampleGroupID != "")
//            {
//                 strSQL += @" AND a.sample_group_id_chr = '"+p_strSampleGroupID+@"'";
//            }
//            try
//            {
//                DataTable dtbResult = new DataTable();
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
//                {
//                    p_objResultArr = new clsLisSampleGroupUnit_VO[dtbResult.Rows.Count];
//                    for(int i=0;i<p_objResultArr.Length;i++)
//                    {
//                        p_objResultArr[i] = new clsLisSampleGroupUnit_VO();
//                        p_objResultArr[i].m_strAPPLY_UNIT_DESC_VCHR = dtbResult.Rows[i]["apply_unit_name_vchr"].ToString().Trim();
//                        p_objResultArr[i].m_strAPPLY_UNIT_ID_CHR = dtbResult.Rows[i]["apply_unit_id_chr"].ToString().Trim();
//                        p_objResultArr[i].m_strSAMPLE_GROUP_ID_CHR = dtbResult.Rows[i]["sample_group_id_chr"].ToString().Trim();
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                string strTmp=objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion

		#region 根据sample_group_id删除标本组的标本类型 
		[AutoComplete]
		public long m_lngDelGroupSampleTypeBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelGroupSampleTypeBySampleGroupID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM T_AID_LIS_GROUP_SAMPLE_TYPE
							   WHERE SAMPLE_GROUP_ID_CHR = '"+p_strSampleGroupID+@"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
				if(lngRecEff > -1)
				{
					lngRes = 1;
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

		#region 批量修改标本组的标本类型列表 
		[AutoComplete]
		public long m_lngModifyGroupSampleTypeArr(System.Security.Principal.IPrincipal p_objPrincipal,ArrayList p_arlAdd,ArrayList p_arlRemove)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngModifyGroupSampleTypeArr");
			if(lngRes < 0)
			{
				return -1;
			}

			if(p_arlAdd.Count > 0)
			{
				for(int i=0;i<p_arlAdd.Count;i++)
				{
					lngRes = m_lngAddNewGroupSampleType(p_objPrincipal,(clsLisGroupSampleType_VO)p_arlAdd[i]);
				}
			}
			if(p_arlRemove.Count > 0)
			{
				for(int i=0;i<p_arlRemove.Count;i++)
				{
					lngRes = m_lngDelGroupSampleTypeByCondition(p_objPrincipal,((clsLisGroupSampleType_VO)p_arlRemove[i]).m_strSAMPLE_GROUP_ID_CHR,
						((clsLisGroupSampleType_VO)p_arlRemove[i]).m_strSAMPLE_TYPE_ID_CHR);
				}
			}
			return lngRes;
		}
		#endregion

		#region 批量新增标本组的标本类型列表 
		[AutoComplete]
		public long m_lngAddNewGroupSampleTypeArr(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,ArrayList p_arlAdd)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddNewGroupSampleArr");
			if(lngRes < 0)
			{
				return -1;
			}

			for(int i=0;i<p_arlAdd.Count;i++)
			{
				((clsLisGroupSampleType_VO)p_arlAdd[i]).m_strSAMPLE_GROUP_ID_CHR = p_strSampleGroupID;
				lngRes = m_lngAddNewGroupSampleType(p_objPrincipal,(clsLisGroupSampleType_VO)p_arlAdd[i]);
			}
			return lngRes;
		}
		#endregion

//        #region 根据标本组ID获取该组的标本类型 
//        [AutoComplete]
//        public long m_lngGetGroupSampleTypeBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,
//            out clsLisGroupSampleType_VO[] p_objResultArr)
//        {
//            long lngRes = 0;
//            p_objResultArr = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetGroupSampleTypeBySampleGroupID");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT t1.sample_type_desc_vchr, t2.sample_group_id_chr,
//									 t2.sample_type_id_chr
//								FROM t_aid_lis_sampletype t1, t_aid_lis_group_sample_type t2
//							   WHERE t1.sample_type_id_chr = t2.sample_type_id_chr
//								 AND t2.sample_group_id_chr = '"+p_strSampleGroupID+"'";
//            try
//            {
//                DataTable dtbResult = new DataTable();
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbResult.Rows.Count > 0)
//                {
//                    p_objResultArr = new clsLisGroupSampleType_VO[dtbResult.Rows.Count];
//                    for(int i=0;i<dtbResult.Rows.Count;i++)
//                    {
//                        p_objResultArr[i] = new clsLisGroupSampleType_VO();
//                        p_objResultArr[i].m_strSAMPLE_GROUP_ID_CHR = dtbResult.Rows[i]["sample_group_id_chr"].ToString().Trim();
//                        p_objResultArr[i].m_strSAMPLE_TYPE_DESC_VCHR = dtbResult.Rows[i]["sample_type_desc_vchr"].ToString().Trim();
//                        p_objResultArr[i].m_strSAMPLE_TYPE_ID_CHR = dtbResult.Rows[i]["sample_type_id_chr"].ToString().Trim();
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                string strTmp=objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion

		#region 新增标本组的标本类型 
		[AutoComplete]
		public long m_lngAddNewGroupSampleType(System.Security.Principal.IPrincipal p_objPrincipal,clsLisGroupSampleType_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddNewGroupSampleType");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = "INSERT INTO T_AID_LIS_GROUP_SAMPLE_TYPE (SAMPLE_GROUP_ID_CHR,SAMPLE_TYPE_ID_CHR) VALUES (?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.CreateDatabaseParameter(2,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_objRecord.m_strSAMPLE_GROUP_ID_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strSAMPLE_TYPE_ID_CHR;
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

		#region 删除标本组的标本类型
		[AutoComplete]
		public long m_lngDelGroupSampleTypeByCondition(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,
			string p_strSampleTypeID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelGroupSampleTypeByCondition");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM T_AID_LIS_GROUP_SAMPLE_TYPE
							   WHERE SAMPLE_GROUP_ID_CHR = '"+p_strSampleGroupID+@"'
								 AND SAMPLE_TYPE_ID_CHR = '"+p_strSampleTypeID+@"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				if(lngRecEff > -1)
				{
					lngRes = 1;
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

		#region 根据sample_group_id删除表T_AID_LIS_SAMPLE_GROUP_MODEL的记录 
		[AutoComplete]
		public long m_lngDelSampleGroupModelBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelSampleGroupModelBySampleGroupID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_aid_lis_sample_group_model
									WHERE sample_group_id_chr = ?";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(1,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_strSampleGroupID;
				long lngRecEff = -1;
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

		#region 批量新增标本组的仪器型号列表 
		[AutoComplete]
		public long m_lngAddNewSampleGroupModelArr(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupNo,ArrayList p_arlAdd)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddNewSampleGroupModelArr");
			if(lngRes < 0)
			{
				return -1;
			}

			for(int i=0;i<p_arlAdd.Count;i++)
			{
				((clsLisSampleGroupModel_VO)p_arlAdd[i]).m_strSAMPLE_GROUP_ID_CHR = p_strSampleGroupNo;
				lngRes = m_lngAddNewSampleGroupModel(p_objPrincipal,(clsLisSampleGroupModel_VO)p_arlAdd[i]);
			}
			return lngRes;
		}
		#endregion

		#region 批量修改标本组的仪器型号列表
		[AutoComplete]
		public long m_lngSetSampleGroupModelArr(System.Security.Principal.IPrincipal p_objPrincipal,ArrayList p_arlAdd,ArrayList p_arlRemove)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngSetSampleGroupModelArr");
			if(lngRes < 0)
			{
				return -1;
			}

			if(p_arlAdd.Count > 0)
			{
				for(int i=0;i<p_arlAdd.Count;i++)
				{
					lngRes = m_lngAddNewSampleGroupModel(p_objPrincipal,(clsLisSampleGroupModel_VO)p_arlAdd[i]);
				}
			}
			if(p_arlRemove.Count > 0)
			{
				for(int i=0;i<p_arlRemove.Count;i++)
				{
					lngRes = m_lngDelSampleGroupModel(p_objPrincipal,(clsLisSampleGroupModel_VO)p_arlRemove[i]);
				}
			}
			return lngRes;
		}
		#endregion

		#region 删除表T_AID_LIS_SAMPLE_GROUP_MODEL的记录 
		[AutoComplete]
		public long m_lngDelSampleGroupModel(System.Security.Principal.IPrincipal p_objPrincipal,clsLisSampleGroupModel_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelSampleGroupModel");
			if(lngRes < 0)
			{
				return -1;
			}
			
			string strSQL = @"DELETE FROM t_aid_lis_sample_group_model
									WHERE device_model_id_chr = ? 
									  AND sample_group_id_chr = ?";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(2,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_objRecord.m_strDEVICE_MODEL_ID_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strSAMPLE_GROUP_ID_CHR;
				long lngRecEff = -1;
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

		#region 新增记录到表T_AID_LIS_SAMPLE_GROUP_MODEL 
		[AutoComplete]
		public long m_lngAddNewSampleGroupModel(System.Security.Principal.IPrincipal p_objPrincipal,clsLisSampleGroupModel_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddNewSampleGroupModel");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"INSERT INTO T_AID_LIS_SAMPLE_GROUP_MODEL (SAMPLE_GROUP_ID_CHR,DEVICE_MODEL_ID_CHR) VALUES (?,?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(2,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_objRecord.m_strSAMPLE_GROUP_ID_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strDEVICE_MODEL_ID_CHR;
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

//        #region 根据样本组ID 得到样本组对应的仪器型号列表 
//        /// <summary>
//        /// 根据样本组ID 得到样本组对应的仪器型号列表
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="p_strSampleGroupID"></param>
//        /// <param name="p_strSampleGroupModelArr"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetSampleGroupModelArr(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,out string[] p_strSampleGroupModelArr)
//        {
//            long lngRes = 0;
//            p_strSampleGroupModelArr = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetSampleGroupModelArr");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT *
//								FROM t_aid_lis_sample_group_model t1
//								WHERE sample_group_id_chr = ?
//								";
//            DataTable dtbResult = null;
//            lngRes = 0;
//            try
//            {
//                System.Data.IDataParameter[] objParamArr = clsIDataParameterCreator.m_objConstructIDataParameterArr(p_strSampleGroupID);
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objParamArr);
//                if(dtbResult != null && dtbResult.Rows.Count >0)
//                {
//                    p_strSampleGroupModelArr = new string[dtbResult.Rows.Count];
//                    for(int i=0;i<dtbResult.Rows.Count;i++)
//                    {
//                        p_strSampleGroupModelArr[i] = dtbResult.Rows[i]["device_model_id_chr"].ToString().Trim();
//                    }
//                }
//                objHRPSvc.Dispose();
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 根据标本组ID获取对应的仪器型号列表 
//        [AutoComplete]
//        public long m_lngGetDeviceModelArrBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,
//            out clsLisSampleGroupModel_VO[] p_objResultArr)
//        {
//            long lngRes = 0;
//            p_objResultArr = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetDeviceModelArrBySampleGroupID");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT b.DEVICE_MODEL_DESC_VCHR,a.*
//								FROM t_aid_lis_sample_group_model a,
//									 t_bse_lis_device_model b
//							   WHERE a.device_model_id_chr = b.device_model_id_chr
//								 AND a.sample_group_id_chr = '"+p_strSampleGroupID+@"'";

//            try
//            {
//                DataTable dtbResult = null;
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
//                {
//                    p_objResultArr = new clsLisSampleGroupModel_VO[dtbResult.Rows.Count];
//                    for(int i=0;i<dtbResult.Rows.Count;i++)
//                    {
//                        p_objResultArr[i] = new clsLisSampleGroupModel_VO();
//                        p_objResultArr[i].m_strDEVICE_MODEL_ID_CHR = dtbResult.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
//                        p_objResultArr[i].m_strDEVICE_MODEL_DESC_VCHR = dtbResult.Rows[i]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
//                        p_objResultArr[i].m_strSAMPLE_GROUP_ID_CHR = dtbResult.Rows[i]["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 得到样本组的列表 
//        /// <summary>
//        /// 得到样本组的列表
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="p_strCategory"></param>
//        /// <param name="p_strSampleType"></param>
//        /// <param name="p_dtpResult"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetSampleGroupList(System.Security.Principal.IPrincipal p_objPrincipal,
//            string p_strCategory,string p_strSampleType,out DataTable p_dtpResult)
//        {
//            long lngRes = 0;
//            p_dtpResult = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetSampleGroupList");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            #region SQL 
//            string strSQL = @"SELECT t1.*
//								FROM t_aid_lis_sample_group t1, 
//									 t_aid_lis_group_sample_type t2
//							   WHERE t1.sample_group_id_chr = t2.sample_group_id_chr ";

//            string strSQL_Category = " AND t1.CHECK_CATEGORY_ID_CHR = ? ";
//            string strSQL_TYPE = " AND t2.SAMPLE_TYPE_ID_CHR = ? ";
//            #endregion

//            ArrayList arlSQL = new ArrayList();
//            ArrayList arlParm = new ArrayList();

//            #region 构造
//            if(p_strCategory != null && p_strCategory.ToString().Trim() != "")
//            {
//                arlSQL.Add(strSQL_Category);
//                arlParm.Add(p_strCategory.Trim());
//            }
//            if(p_strSampleType != null && p_strSampleType.ToString().Trim() != "")
//            {
//                arlSQL.Add(strSQL_TYPE);
//                arlParm.Add(p_strSampleType.Trim());
//            }
//            #endregion

//            foreach(object obj in arlSQL)
//            {
//                strSQL += obj.ToString();
//            }

//            int intParmCount = arlSQL.Count;

//            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

//            IDataParameter[] objDPArr = null;
//            objHRPSvc.CreateDatabaseParameter(intParmCount,out objDPArr);

//            for(int i=0;i< intParmCount;i++)
//            {
//                objDPArr[i].Value = arlParm[i];
//            }

//            try
//            {
//                lngRes = 0;
//                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtpResult,objDPArr);
//                objHRPSvc.Dispose();
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 根据标本ID获取标本组VO 
//        [AutoComplete]
//        public long m_lngGetSampleGroupVOBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,
//            out clsSampleGroup_VO p_objResultVO)
//        {
//            long lngRes = 0;
//            p_objResultVO = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetSampleGroupVOBySampleGroupID");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"select t2.sample_type_id_chr, t1.sample_group_id_chr, t1.py_code_chr,
//                                   t1.wb_code_chr, t1.assist_code01_chr, t1.assist_code02_chr,
//                                   t1.is_hand_work_int, t1.device_model_id_chr, t1.remark_vchr,
//                                   t1.check_category_id_chr, t1.sample_type_id_chr,
//                                   t1.sample_group_name_chr, t1.print_title_vchr, t1.print_seq_int
//                              from t_aid_lis_sample_group t1, t_aid_lis_group_sample_type t2
//                             where t1.sample_group_id_chr = t2.sample_group_id_chr
//                               and t1.sample_group_id_chr = '" + p_strSampleGroupID + "'";
//            DataTable dtbResult = new DataTable();
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbResult.Rows.Count > 0)
//                {
//                    p_objResultVO = new clsSampleGroup_VO();
//                    ConstructSampleGroupVO(dtbResult.Rows[0],ref p_objResultVO);
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 根据申请单元ID得到它所在标本组的VO 
//        /// <summary>
//        /// 根据检验项目ID得到它所在标本组的VO,及打印顺序  
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="p_strCheckItemID"></param>
//        /// <param name="p_intPrintSeq"></param>
//        /// <param name="p_objSampleGroupVO"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetSampleGoupVOByApplyUnitID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strApplyUnitID,out clsSampleGroup_VO p_objSampleGroupVO)
//        {
//            long lngRes = 0;
//            p_objSampleGroupVO = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetSampleGoupVOByApplyUnitID");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"select t1.sample_group_id_chr, t1.py_code_chr, t1.wb_code_chr,
//                                   t1.assist_code01_chr, t1.assist_code02_chr, t1.is_hand_work_int,
//                                   t1.device_model_id_chr, t1.remark_vchr, t1.check_category_id_chr,
//                                   t1.sample_type_id_chr, t1.sample_group_name_chr, t1.print_title_vchr,
//                                   t1.print_seq_int
//                              from t_aid_lis_sample_group t1, t_aid_lis_sample_group_unit t2
//                             where t1.sample_group_id_chr = t2.sample_group_id_chr
//                               and t2.apply_unit_id_chr = '" + p_strApplyUnitID + "'";

//            DataTable dtbRet = null;
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbRet);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbRet != null)
//                {
//                    if(dtbRet.Rows.Count > 0)
//                    {
//                        p_objSampleGroupVO = new clsSampleGroup_VO();
						
//                        ConstructSampleGroupVO(dtbRet.Rows[0],ref p_objSampleGroupVO);
						
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion

		#region 更新标本组的基本信息 
		[AutoComplete]
		public long m_lngSetSampleGroupInfo(System.Security.Principal.IPrincipal p_objPrincipal,ref clsSampleGroup_VO objSampleGroupVO)
		{
			long lngRes = 0;
			
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngSetSampleGroupInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_aid_lis_sample_group
								 SET py_code_chr = '"+objSampleGroupVO.strPYCode+@"',
									 wb_code_chr = '"+objSampleGroupVO.strWBCode+@"',
									 assist_code01_chr = '"+objSampleGroupVO.strAssistCode01+@"',
									 assist_code02_chr = '"+objSampleGroupVO.strAssistCode02+@"',
									 is_hand_work_int = '"+objSampleGroupVO.strIsHandWork+@"',
									 device_model_id_chr = '"+objSampleGroupVO.strDeviceModleID+@"',
									 remark_vchr = '"+objSampleGroupVO.strRemark+@"',
									 check_category_id_chr = '"+objSampleGroupVO.strCheckCategoryID+@"',
									 sample_type_id_chr = '"+objSampleGroupVO.strSampleTypeID+@"',
									 sample_group_name_chr = '"+objSampleGroupVO.strSampleGroupName+@"',
									 PRINT_TITLE_VCHR = '"+objSampleGroupVO.strPRINT_TITLE_VCHR+@"'
							   WHERE sample_group_id_chr = '"+objSampleGroupVO.strSampleGroupID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除标本组及其明细
		[AutoComplete]
		public long m_lngDelSampleGroupAndDetail(System.Security.Principal.IPrincipal p_objPrincipal,string strSampleGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelSampleGroupAndDetail");
			if(lngRes < 0)
			{
				return -1;
			}
			lngRes = m_lngDelSampleGroupModelBySampleGroupID(p_objPrincipal,strSampleGroupID);
			if(lngRes > 0)
			{
				lngRes = m_lngDelGroupSampleTypeBySampleGroupID(p_objPrincipal,strSampleGroupID);
				if(lngRes > 0)
				{
//					lngRes = m_lngDelSampleGroupDetail(p_objPrincipal,strSampleGroupID);
					lngRes = m_lngDelSampleGroupUnitBySampleGroupID(p_objPrincipal,strSampleGroupID);
					if(lngRes > 0)
					{
						lngRes = m_lngDelSampleGroup(p_objPrincipal,strSampleGroupID);
					}
				}
			}
			return lngRes;
		}
		#endregion

		#region 删除标本组明细 
		[AutoComplete]
		public long m_lngDelSampleGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,string strSampleGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelSampleGroupDetail");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_aid_lis_sample_group_detail WHERE sample_group_id_chr = '"+strSampleGroupID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
				if(lngRecEff > -1)
				{
					lngRes = 1;
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

		#region 删除标本组 
		[AutoComplete]
		public long m_lngDelSampleGroup(System.Security.Principal.IPrincipal p_objPrincipal,string strSampleGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngDelSampleGroup");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_aid_lis_sample_group WHERE sample_group_id_chr = '"+strSampleGroupID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 保存标本组及其明细
		[AutoComplete]
		public long m_lngAddSampleGroupAndDetail(System.Security.Principal.IPrincipal p_objPrincipal,ref clsSampleGroup_VO objSampleGroup,
			ref clsLisSampleGroupUnit_VO[] objSampleGroupUnitList,clsApplUnitDetail_VO[] p_objApplUnitDetailArr,ArrayList p_arlAdd,
			ArrayList p_arlRemove,ArrayList p_arlAddSampleType,ArrayList p_arlRemoveSampleType)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddSampleGroupAndDetail");
			if(lngRes < 0)
			{
				return -1;
			}

			if(objSampleGroup.strSampleGroupID == null)
			{
				//1.保存到t_aid_lis_sample_group
				lngRes = m_lngAddSampleGroup(p_objPrincipal,ref objSampleGroup);
				if(lngRes > 0)
				{
					lngRes = m_lngAddNewSampleGroupModelArr(p_objPrincipal,objSampleGroup.strSampleGroupID,p_arlAdd);
					lngRes = m_lngAddNewGroupSampleTypeArr(p_objPrincipal,objSampleGroup.strSampleGroupID,p_arlAddSampleType);
				}
			}
			else
			{
//				lngRes = m_lngDelSampleGroupDetail(p_objPrincipal,objSampleGroup.strSampleGroupID);
				lngRes = m_lngDelSampleGroupUnitBySampleGroupID(p_objPrincipal,objSampleGroup.strSampleGroupID);
				if(lngRes > 0)
				{
					lngRes = m_lngSetSampleGroupInfo(p_objPrincipal,ref objSampleGroup);
					if(lngRes > 0)
					{
						lngRes = m_lngSetSampleGroupModelArr(p_objPrincipal,p_arlAdd,p_arlRemove);
						lngRes = m_lngModifyGroupSampleTypeArr(p_objPrincipal,p_arlAddSampleType,p_arlRemoveSampleType);
					}
				}
			}
			if(lngRes > 0)
			{
				lngRes = m_lngSetApplUnitItemPrintSeqArr(p_objPrincipal,p_objApplUnitDetailArr);
				if(lngRes > 0)
				{
					lngRes = m_lngAddNewSampleGroupUnitArr(p_objPrincipal,objSampleGroup.strSampleGroupID,objSampleGroupUnitList);
				}
			}
//			if(lngRes > 0)
//			{
//				for(int i=0;i<objSampleGroupDetailVOList.Length;i++)
//				{
//					objSampleGroupDetailVOList[i].strSampleGroupID = objSampleGroup.strSampleGroupID;
//					lngRes = m_lngAddSampleGroupDetail(p_objPrincipal,objSampleGroupDetailVOList[i]);
//				}
//			}
			return lngRes;
		}
		#endregion

		#region 保存记录到t_aid_lis_sample_group表
		[AutoComplete]
		public long m_lngAddSampleGroup(System.Security.Principal.IPrincipal p_objPrincipal,ref clsSampleGroup_VO objSampleGroupVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddSampleGroup");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"INSERT INTO t_aid_lis_sample_group
										  (sample_group_id_chr, py_code_chr, wb_code_chr,
										   assist_code01_chr, assist_code02_chr, is_hand_work_int,
										   device_model_id_chr, remark_vchr, check_category_id_chr,
										   sample_type_id_chr,sample_group_name_chr,PRINT_TITLE_VCHR
										  )
								  VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objSampleGroupArr= null;
				objHRPSvc.CreateDatabaseParameter(12,out objSampleGroupArr);
				if(objSampleGroupVO.strSampleGroupID == null)
				{
					objSampleGroupVO.strSampleGroupID = objHRPSvc.m_strGetNewID("t_aid_lis_sample_group","SAMPLE_GROUP_ID_CHR",6);
				}
				objSampleGroupArr[0].Value = objSampleGroupVO.strSampleGroupID;
				objSampleGroupArr[1].Value = objSampleGroupVO.strPYCode;
				objSampleGroupArr[2].Value = objSampleGroupVO.strWBCode;
				objSampleGroupArr[3].Value = objSampleGroupVO.strAssistCode01;
				objSampleGroupArr[4].Value = objSampleGroupVO.strAssistCode02;
				objSampleGroupArr[5].Value = objSampleGroupVO.strIsHandWork;
				objSampleGroupArr[6].Value = objSampleGroupVO.strDeviceModleID;
				objSampleGroupArr[7].Value = objSampleGroupVO.strRemark;
				objSampleGroupArr[8].Value = objSampleGroupVO.strCheckCategoryID;
				objSampleGroupArr[9].Value = objSampleGroupVO.strSampleTypeID;
				objSampleGroupArr[10].Value = objSampleGroupVO.strSampleGroupName;
				objSampleGroupArr[11].Value = objSampleGroupVO.strPRINT_TITLE_VCHR;

				long lngRecEff = -1;

				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objSampleGroupArr);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

//        #region 获取某一标本组下的明细资料 
//        [AutoComplete]
//        public long m_lngGetAllSampleGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,string strSampleGroupID,ref clsSampleGroupDetail_VO[] objSampleGroupDetailVOList)
//        {
//            long lngRes = 0;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetAllSampleGroupDetail");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT   t1.sample_group_id_chr, t2.check_item_id_chr, t2.print_seq_int
//									FROM t_aid_lis_sample_group_unit t1, t_aid_lis_apply_unit_detail t2
//								WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr  AND T1.sample_group_id_chr = '" + strSampleGroupID + @"' 
//								ORDER BY print_seq_int";
//            DataTable dtbSampleGroupDetail = null;
//            objSampleGroupDetailVOList = null;
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbSampleGroupDetail);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 &&  dtbSampleGroupDetail != null)
//                {
//                    if(dtbSampleGroupDetail.Rows.Count > 0)
//                    {
//                        if(dtbSampleGroupDetail.Rows.Count > 0)
//                        {
//                            objSampleGroupDetailVOList = new clsSampleGroupDetail_VO[dtbSampleGroupDetail.Rows.Count];
//                            for(int i=0;i<dtbSampleGroupDetail.Rows.Count;i++)
//                            {
//                                objSampleGroupDetailVOList[i] = new clsSampleGroupDetail_VO();
//                                ConstructSampleGroupDetailVO(dtbSampleGroupDetail.Rows[i],ref objSampleGroupDetailVOList[i]);
//                            }
//                        }
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 获取所有的标本组 
//        [AutoComplete]
//        public long m_lngGetAllSampleGroup(System.Security.Principal.IPrincipal objPrincipal,ref clsSampleGroup_VO[] objSampleGroupVOList)
//        {
//            long lngRes = 0;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetAllSampleGroup");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"select   sample_group_id_chr, py_code_chr, wb_code_chr, assist_code01_chr,
//                                     assist_code02_chr, is_hand_work_int, device_model_id_chr,
//                                     remark_vchr, check_category_id_chr, sample_type_id_chr,
//                                     sample_group_name_chr, print_title_vchr, print_seq_int
//                                from t_aid_lis_sample_group
//                            order by sample_group_id_chr";
//            DataTable dtbSampleGroup = null;
//            objSampleGroupVOList = null;
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbSampleGroup);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbSampleGroup != null)
//                {
//                    if(dtbSampleGroup.Rows.Count > 0)
//                    {
//                        objSampleGroupVOList = new clsSampleGroup_VO[dtbSampleGroup.Rows.Count];
//                        for(int i=0;i<dtbSampleGroup.Rows.Count;i++)
//                        {
//                            objSampleGroupVOList[i] = new clsSampleGroup_VO();
//                            ConstructSampleGroupVO(dtbSampleGroup.Rows[i],ref objSampleGroupVOList[i]);
//                        }
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion

//        #region 构造clsSampleGroupVO 
//        [AutoComplete]
//        private void ConstructSampleGroupVO(System.Data.DataRow objRow, ref com.digitalwave.iCare.ValueObject.clsSampleGroup_VO p_objSampleGroupVO)
//        {
//            p_objSampleGroupVO.strSampleGroupID = objRow["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strPYCode = objRow["PY_CODE_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strWBCode = objRow["WB_CODE_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strAssistCode01 = objRow["ASSIST_CODE01_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strAssistCode02 = objRow["ASSIST_CODE02_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strRemark = objRow["REMARK_VCHR"].ToString().Trim();
//            p_objSampleGroupVO.strIsHandWork = objRow["IS_HAND_WORK_INT"].ToString().Trim();
//            p_objSampleGroupVO.strDeviceModleID = objRow["DEVICE_MODEL_ID_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strCheckCategoryID = objRow["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strSampleTypeID = objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strSampleGroupName = objRow["SAMPLE_GROUP_NAME_CHR"].ToString().Trim();
//            p_objSampleGroupVO.strPRINT_TITLE_VCHR = objRow["PRINT_TITLE_VCHR"].ToString().Trim();
//    }
//        #endregion

//        #region 构造clsSampleGroupVODetail 
//        [AutoComplete]
//        private void ConstructSampleGroupDetailVO(System.Data.DataRow objRow,ref clsSampleGroupDetail_VO objSampleGroupDetailVO)
//        {
//            objSampleGroupDetailVO.strSampleGroupID = objRow["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
//            objSampleGroupDetailVO.strCheckItemID = objRow["CHECK_ITEM_ID_CHR"].ToString().Trim();
//            objSampleGroupDetailVO.strPrintSeq = objRow["PRINT_SEQ_INT"].ToString().Trim();
//        }
//        #endregion

//        #region 获取所有的标本组明细
//        [AutoComplete]
//        public long m_lngGetAllSampleGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,out clsSampleGroupDetail_VO[] objSampleGroupDetailVOList)
//        {
//            long lngRes = 0;
//            objSampleGroupDetailVOList = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngGetAllSampleGroupDetail");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT   t1.sample_group_id_chr, t2.check_item_id_chr, t2.print_seq_int
//									FROM t_aid_lis_sample_group_unit t1, t_aid_lis_apply_unit_detail t2
//								WHERE t1.apply_unit_id_chr = t2.apply_unit_id_chr
//								ORDER BY sample_group_id_chr, print_seq_int";
//            DataTable dtbSampleGroupDetail = null;

//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbSampleGroupDetail);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 &&  dtbSampleGroupDetail != null)
//                {
//                    if(dtbSampleGroupDetail.Rows.Count > 0)
//                    {
//                        if(dtbSampleGroupDetail.Rows.Count > 0)
//                        {
//                            objSampleGroupDetailVOList = new clsSampleGroupDetail_VO[dtbSampleGroupDetail.Rows.Count];
//                            for(int i=0;i<dtbSampleGroupDetail.Rows.Count;i++)
//                            {
//                                objSampleGroupDetailVOList[i] = new clsSampleGroupDetail_VO();
//                                ConstructSampleGroupDetailVO(dtbSampleGroupDetail.Rows[i],ref objSampleGroupDetailVOList[i]);
//                            }
//                        }
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//            }
//            return lngRes;
//        }
//        #endregion


		#region 保存记录到t_aid_lis_sample_group_detail表  ******作废***************
//		[AutoComplete]
//		public long m_lngAddSampleGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,clsSampleGroupDetail_VO objSampleGroupDetailVO)
//		{
//			long lngRes = 0;
//
//			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsSampleGroupSvc","m_lngAddSampleGroupDetail");
//			if(lngRes < 0)
//			{
//				return -1;
//			}
//
//			string strSQL = @"INSERT INTO t_aid_lis_sample_group_detail
//									      (sample_group_id_chr, check_item_id_chr, print_seq_int)
//								   VALUES (?, ?, ?)";
//			try
//			{
//				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//				System.Data.IDataParameter[] objSampleGroupDetailArr= null;
//				objHRPSvc.CreateDatabaseParameter(3,out objSampleGroupDetailArr);
//				objSampleGroupDetailArr[0].Value = objSampleGroupDetailVO.strSampleGroupID;
//				objSampleGroupDetailArr[1].Value = objSampleGroupDetailVO.strCheckItemID;
//				objSampleGroupDetailArr[2].Value = objSampleGroupDetailVO.strPrintSeq;
//
//				long lngRecEff = -1;
//
//				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objSampleGroupDetailArr);
//				objHRPSvc.Dispose();
//			}
//			catch(Exception objEx)
//			{
//				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//				bool blnRes = objLogger.LogError(objEx);
//			}
//			return lngRes;
//		}
		#endregion
	}
}
