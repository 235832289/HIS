using System;
using System.Data;
using System.EnterpriseServices;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
namespace com.digitalwave.iCare.middletier.LIS
{
	/// <summary>
	/// clsReportGroupSvc 的摘要说明。
	/// 
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsReportGroupSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
	{
		#region 构造函数
		public clsReportGroupSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 更新标本组的打印顺序
		[AutoComplete]
		public long m_lngSetSampleGroupPrintOrder(System.Security.Principal.IPrincipal p_objPrincipal,clsSampleGroup_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsReportGroupSvc","m_lngSetSampleGroupPrintOrder");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_aid_lis_sample_group
								 SET print_seq_int = '"+p_objRecord.intPRINT_SEQ_INT+@"'
							   WHERE sample_group_id_chr = '"+p_objRecord.strSampleGroupID+@"'";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
			}
			return lngRes;
		}
		#endregion

        //#region 根据报告组ID获取报告组VO
        //[AutoComplete]
        //public long m_lngGetReportGroupVOByReportGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strReportGroupID,
        //    out clsReportGroup_VO p_objResultVO)
        //{
        //    long lngRes = 0;
        //    p_objResultVO = null;

        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsReportGroupSvc","m_lngGetReportGroupVOByReportGroupID");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM T_AID_LIS_REPORT_GROUP WHERE report_group_id_chr = '"+p_strReportGroupID+"'";
        //    DataTable dtbResult = new DataTable();
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
        //        objHRPSvc.Dispose();
        //        if(lngRes > 0 && dtbResult.Rows.Count > 0)
        //        {
        //            p_objResultVO = new clsReportGroup_VO();
        //            ConstructReportGroupVO(dtbResult.Rows[0],ref p_objResultVO);
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
        //    }
        //    return lngRes;
        //}
        //#endregion

//        #region 根据检验标本组ID得到它所在报告组的VO 
//        /// <summary>
//        /// 根据检验标本组ID得到它所在报告组的VO 刘彬 2004.06.1
//        /// </summary>
//        /// <param name="p_objPrincipal"></param>
//        /// <param name="p_strCheckItemID"></param>
//        /// <param name="p_objSampleGroupVO"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long m_lngGetReportGoupVOBySampleGroupID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSampleGroupID,out clsReportGroup_VO p_objReportGroupVO)
//        {
//            long lngRes = 0;
//            p_objReportGroupVO = null;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsReportGroupSvc","m_lngGetReportGoupVOBySampleGroupID");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT t1.* 
//								FROM t_aid_lis_report_group t1,t_aid_lis_report_group_detail t2
//								WHERE t1.report_group_id_chr = t2.report_group_id_chr
//								AND t2.sample_group_id_chr = '" + p_strSampleGroupID+ "'";

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
//                        p_objReportGroupVO = new clsReportGroup_VO();
						
//                        ConstructReportGroupVO(dtbRet.Rows[0],ref p_objReportGroupVO);
						
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


		#region 删除报告组及其明细 
		[AutoComplete]
		public long m_lngDelReportGroupAndDetail(System.Security.Principal.IPrincipal p_objPrincipal,string strReportGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngDelReportGroup");
			if(lngRes < 0)
			{
				return -1;
			}
			lngRes = m_lngDelReportGroupDetail(p_objPrincipal,strReportGroupID);
			if(lngRes > 0)
			{
				lngRes = m_lngDelReportGroup(p_objPrincipal,strReportGroupID);
			}
			return lngRes;
		}
		#endregion

		#region 删除报告组明细 童华 
		[AutoComplete]
		public long m_lngDelReportGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,string strReportGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngDelReportGroup");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_aid_lis_report_group_detail WHERE report_group_id_chr = '"+strReportGroupID+"'";
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

		#region 删除报告组 
		[AutoComplete]
		public long m_lngDelReportGroup(System.Security.Principal.IPrincipal p_objPrincipal,string strReportGroupID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngDelReportGroup");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_aid_lis_report_group WHERE report_group_id_chr = '"+strReportGroupID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				//				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcute(strSQL);//,ref lngRecEff);
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

		#region 保存报告组及其明细 
		[AutoComplete]
		public long m_lngAddReportGroupAndDetail(System.Security.Principal.IPrincipal p_objPrincipal,ref clsReportGroup_VO objReportGroupVO,
			ref clsReportGroupDetail_VO[] objReportGroupDetailVO)//,clsSampleGroup_VO[] p_objSampleGroupArr)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngAddReportGroupDetail");
			if(lngRes < 0)
			{
				return -1;
			}

			if(objReportGroupVO.strReportGroupID == null)
			{
				lngRes = m_lngAddReportGroup(p_objPrincipal,ref objReportGroupVO);
			}
			else
			{
				lngRes = m_lngModifyReportGroup(p_objPrincipal,ref objReportGroupVO);
//				if(lngRes > 0)
//				{
//					for(int i=0;i<p_objSampleGroupArr.Length;i++)
//					{
//						if(lngRes > 0)
//						{
//							lngRes = m_lngSetSampleGroupPrintOrder(p_objPrincipal,p_objSampleGroupArr[i]);
//						}
//					}
//				}
			}
			if(lngRes > 0)
			{
				lngRes = m_lngDelReportGroupDetail(p_objPrincipal,objReportGroupVO.strReportGroupID);
				if(lngRes > 0)
				{
					for(int i=0;i<objReportGroupDetailVO.Length;i++)
					{
						objReportGroupDetailVO[i].strReportGroupID = objReportGroupVO.strReportGroupID;
						lngRes = m_lngAddReportGroupDetail(p_objPrincipal,ref objReportGroupDetailVO[i]);
					}
				}
			}
			return lngRes;
		}
		#endregion

		#region 修改报告组 
		[AutoComplete]
		public long m_lngModifyReportGroup(System.Security.Principal.IPrincipal p_objPrincipal,ref  clsReportGroup_VO objReportGroupVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngModifyReportGroup");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_aid_lis_report_group
								 SET report_group_name_vchr = '"+objReportGroupVO.strReportGroupName+@"',
									 py_code_chr = '"+objReportGroupVO.strPYCode+@"',
									 print_title_vchr = '"+objReportGroupVO.strPrintTitle+@"',
									 wb_code_chr = '"+objReportGroupVO.strWBCode+@"',
									 assist_code01_chr = '"+objReportGroupVO.strAssistCode01+@"',
									 assist_code02_chr = '"+objReportGroupVO.strAssistCode02+@"',
									 print_category_id_chr = '"+objReportGroupVO.strPrintCategoryID+@"'
							   WHERE report_group_id_chr = '"+objReportGroupVO.strReportGroupID+@"'";
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

		#region 保存记录到t_aid_lis_report_group_detail
		[AutoComplete]
		public long m_lngAddReportGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,ref clsReportGroupDetail_VO objReportGroupDetailVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngAddReportGroupDetail");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"INSERT INTO t_aid_lis_report_group_detail
										  (sample_group_id_chr, report_group_id_chr, print_seq_int
										  )
								   VALUES (?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objReportGroupDetailArr = null;
				objHRPSvc.CreateDatabaseParameter(3,out objReportGroupDetailArr);

				objReportGroupDetailArr[0].Value = objReportGroupDetailVO.strSampleGroupID;
				objReportGroupDetailArr[1].Value = objReportGroupDetailVO.strReportGroupID;
				objReportGroupDetailArr[2].Value = objReportGroupDetailVO.strPrintSeq;

				long lngRecEff = -1;

				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objReportGroupDetailArr);
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

		#region 保存记录到t_aid_lis_report_group 
		[AutoComplete]
		public long m_lngAddReportGroup(System.Security.Principal.IPrincipal p_objPrincipal,ref clsReportGroup_VO objReportGroupVO)
		{
			long lngRes = 0;
			
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngAddReportGroup");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"INSERT INTO t_aid_lis_report_group
										  (report_group_id_chr, report_group_name_vchr, py_code_chr,
										   print_title_vchr, wb_code_chr, assist_code01_chr,
										   assist_code02_chr, print_category_id_chr
										  )
								  VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objReportGroupArr = null;
				objHRPSvc.CreateDatabaseParameter(8,out objReportGroupArr);
				
				if(objReportGroupVO.strReportGroupID == null)
				{
					objReportGroupVO.strReportGroupID = objHRPSvc.m_strGetNewID("t_aid_lis_report_group","REPORT_GROUP_ID_CHR",6);
				}

				objReportGroupArr[0].Value = objReportGroupVO.strReportGroupID;
				objReportGroupArr[1].Value = objReportGroupVO.strReportGroupName;
				objReportGroupArr[2].Value = objReportGroupVO.strPYCode;
				objReportGroupArr[3].Value = objReportGroupVO.strPrintTitle;
				objReportGroupArr[4].Value = objReportGroupVO.strWBCode;
				objReportGroupArr[5].Value = objReportGroupVO.strAssistCode01;
				objReportGroupArr[6].Value = objReportGroupVO.strAssistCode02;
				objReportGroupArr[7].Value = objReportGroupVO.strPrintCategoryID;

				long lngRecEff = -1;
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objReportGroupArr);
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

        //#region 获取所有的报告组明细 
        //[AutoComplete]
        //public long m_lngGetAllReportGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,out clsReportGroupDetail_VO[] objReportGroupVOList)
        //{
        //    long lngRes = 0;
        //    objReportGroupVOList = null;

        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngGetAllReportGroupDetail");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM t_aid_lis_report_group_detail";
        //    DataTable dtbReportDetail = null;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbReportDetail);
        //        objHRPSvc.Dispose();
        //        if(dtbReportDetail != null && dtbReportDetail.Rows.Count > 0)
        //        {
        //            objReportGroupVOList = new clsReportGroupDetail_VO[dtbReportDetail.Rows.Count];
        //            for(int i=0;i<dtbReportDetail.Rows.Count;i++)
        //            {
        //                objReportGroupVOList[i] = new clsReportGroupDetail_VO();
        //                ConstructReportGroupDetail(dtbReportDetail.Rows[i],ref objReportGroupVOList[i]);
        //            }
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 构造ReportGroupDetailVO 
        //[AutoComplete]
        //private void ConstructReportGroupDetail(System.Data.DataRow objRow,ref clsReportGroupDetail_VO objReportGroupDetailVO)
        //{
        //    objReportGroupDetailVO.strReportGroupID = objRow["REPORT_GROUP_ID_CHR"].ToString().Trim();
        //    objReportGroupDetailVO.strSampleGroupID = objRow["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
        //    objReportGroupDetailVO.strPrintSeq = objRow["PRINT_SEQ_INT"].ToString().Trim();
        //}
        //#endregion

        //#region 获取所有的报告组
        //[AutoComplete]
        //public long m_lngGetAllReportGroup(System.Security.Principal.IPrincipal p_objPrincipal,ref clsReportGroup_VO[] objReportGroupList)
        //{
        //    long lngRes = 0;

        //    clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
        //    lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngGetAllReportGroup");
        //    if(lngRes < 0)
        //    {
        //        return -1;
        //    }

        //    string strSQL = @"SELECT * FROM T_AID_LIS_REPORT_GROUP ORDER BY REPORT_GROUP_ID_CHR";
        //    DataTable dtbReportGroup = null;
        //    objReportGroupList = null;
        //    try
        //    {
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbReportGroup);
        //        objHRPSvc.Dispose();
        //        if(lngRes > 0 && dtbReportGroup != null)
        //        {
        //            if(dtbReportGroup.Rows.Count > 0)
        //            {
        //                objReportGroupList = new clsReportGroup_VO[dtbReportGroup.Rows.Count];
        //                for(int i=0;i<dtbReportGroup.Rows.Count;i++)
        //                {
        //                    objReportGroupList[i] = new clsReportGroup_VO();
        //                    ConstructReportGroupVO(dtbReportGroup.Rows[i],ref objReportGroupList[i]);
        //                    m_lngGetReportGroupDetail(p_objPrincipal,objReportGroupList[i].strReportGroupID,ref objReportGroupList[i].objSampleGroupVO);
        //                }
        //            }
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);
        //    }
        //    return lngRes;
        //}
        //#endregion

        //#region 构造ReportGroupVO 
        //[AutoComplete]
        //private void ConstructReportGroupVO(System.Data.DataRow objRow,ref clsReportGroup_VO objReportGroupVO)
        //{
        //    objReportGroupVO.strReportGroupID = objRow["REPORT_GROUP_ID_CHR"].ToString().Trim();
        //    objReportGroupVO.strReportGroupName = objRow["REPORT_GROUP_NAME_VCHR"].ToString().Trim();
        //    objReportGroupVO.strPYCode = objRow["PY_CODE_CHR"].ToString().Trim();
        //    objReportGroupVO.strPrintTitle = objRow["PRINT_TITLE_VCHR"].ToString().Trim();
        //    objReportGroupVO.strWBCode = objRow["WB_CODE_CHR"].ToString().Trim();
        //    objReportGroupVO.strAssistCode01 = objRow["ASSIST_CODE01_CHR"].ToString().Trim();
        //    objReportGroupVO.strAssistCode02 = objRow["ASSIST_CODE02_CHR"].ToString().Trim();
        //    objReportGroupVO.strPrintCategoryID = objRow["PRINT_CATEGORY_ID_CHR"].ToString().Trim();
        //}
        //#endregion

//        #region 获取某一报告组下的标本组明细 
//        [AutoComplete]
//        public long m_lngGetReportGroupDetail(System.Security.Principal.IPrincipal p_objPrincipal,string strReportGroupID,ref clsSampleGroup_VO[] objSampleGroupList)
//        {
//            long lngRes = 0;

//            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
//            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsCheckGroupSvc","m_lngGetAllReportGroupDetail");
//            if(lngRes < 0)
//            {
//                return -1;
//            }

//            string strSQL = @"SELECT t2.*
//							    FROM t_aid_lis_report_group_detail t1,
//									 t_aid_lis_sample_group t2 
//							   WHERE t1.SAMPLE_GROUP_ID_CHR = t2.SAMPLE_GROUP_ID_CHR
//								 AND t1.REPORT_GROUP_ID_CHR = '"+strReportGroupID+@"'
//							   ORDER BY t1.PRINT_SEQ_INT";
//            DataTable dtbReportGroupDetail = null;
//            objSampleGroupList = null;
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbReportGroupDetail);
//                objHRPSvc.Dispose();
//                if(lngRes > 0 && dtbReportGroupDetail != null)
//                {
//                    if(dtbReportGroupDetail.Rows.Count > 0)
//                    {
//                        objSampleGroupList = new clsSampleGroup_VO[dtbReportGroupDetail.Rows.Count];
//                        for(int i=0;i<dtbReportGroupDetail.Rows.Count;i++)
//                        {
//                            objSampleGroupList[i] = new clsSampleGroup_VO();
//                            ConstructSampleGroupVO(dtbReportGroupDetail.Rows[i],ref objSampleGroupList[i]);
//                        }
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion

        //#region 构造clsReportGroupDetail_VO 
        //[AutoComplete]
        //private void ConstructReportGroupDetailVO(System.Data.DataRow objRow,ref clsReportGroupDetail_VO objReportGroupDetail)
        //{
        //    objReportGroupDetail.strReportGroupID = objRow["REPORT_GROUP_ID_CHR"].ToString().Trim();
        //    objReportGroupDetail.strSampleGroupID = objRow["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
        //    objReportGroupDetail.strPrintSeq = objRow["PRINT_SEQ_INT"].ToString().Trim();
        //}
        //#endregion

        //#region 构造clsSampleGroupVO 
        //[AutoComplete]
        //private void ConstructSampleGroupVO(System.Data.DataRow objRow, ref com.digitalwave.iCare.ValueObject.clsSampleGroup_VO p_objSampleGroupVO)
        //{
        //    p_objSampleGroupVO.strSampleGroupID = objRow["SAMPLE_GROUP_ID_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strPYCode = objRow["PY_CODE_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strAssistCode01 = objRow["ASSIST_CODE01_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strAssistCode02 = objRow["ASSIST_CODE02_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strRemark = objRow["REMARK_VCHR"].ToString().Trim();
        //    p_objSampleGroupVO.strIsHandWork = objRow["IS_HAND_WORK_INT"].ToString().Trim();
        //    p_objSampleGroupVO.strDeviceModleID = objRow["DEVICE_MODEL_ID_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strCheckCategoryID = objRow["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strSampleTypeID = objRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
        //    p_objSampleGroupVO.strSampleGroupName = objRow["SAMPLE_GROUP_NAME_CHR"].ToString().Trim();
        //    if(objRow["PRINT_SEQ_INT"].ToString().Trim() != "")
        //    {
        //        p_objSampleGroupVO.intPRINT_SEQ_INT = int.Parse(objRow["PRINT_SEQ_INT"].ToString().Trim());
        //    }
        //    else
        //    {
        //        p_objSampleGroupVO.intPRINT_SEQ_INT = -1;
        //    }
        //}
        //#endregion

	}
}
