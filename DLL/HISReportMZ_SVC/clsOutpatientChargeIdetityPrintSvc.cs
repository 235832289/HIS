using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.HIS.Reports
{
	#region 门诊收费按身份分类统计报表业务处理中间件 ：created by weiling.huang  at 2005-9-16
	/// <summary>
	///门诊收费按身份分类统计报表业务处理中间件：created by weiling.huang  at 2005-9-16
	/// <summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsOutpatientChargeIdetityPrintSvc: com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函�?
		public clsOutpatientChargeIdetityPrintSvc()
		{

		}
		#endregion

		#region 门诊收费按身份分类统计报表中间件方法

		#region 方法：获取病人分类的列信�?分类ID，分类名称）：created by weiling.huang  at 2005-9-16
		/// <summary>
		/// 方法：获取病人分类的列信�?分类ID，分类名称）：created by weiling.huang  at 2005-9-16
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败�?1 ，成功：所影响的结果数</returns>
		[AutoComplete]
		public long m_mthGetPatientCatInfo(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsPType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsPType_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOutpatientChargeIdetityPrintSvc","m_mthGetPatientCatInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"select distinct ta.PAYTYPEID_CHR , ta.PAYTYPENAME_VCHR  from T_BSE_PATIENTPAYTYPE TA,t_opr_outpatientrecipeinv TB Where TA.PAYTYPEID_CHR=TB.PAYTYPEID_CHR And BALANCEFLAG_INT=1 order by ta.PAYTYPEID_CHR";
			
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new com.digitalwave.iCare.ValueObject.clsPType_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsPType_VO();
						p_objResultArr[i1].m_strPAYTYPEID_CHR = dtbResult.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strPAYTYPENAME_VCHR = dtbResult.Rows[i1]["PAYTYPENAME_VCHR"].ToString().Trim();
						
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

		#region 方法：获取对已结账记录的收费员的ID与姓名信息：created by weiling.huang  at 2005-9-16
		/// <summary>
		/// 方法：获取对已结账记录的收费员的ID与姓名信息：created by weiling.huang  at 2005-9-16
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败�?1 ，成功：所影响的结果数</returns>
		[AutoComplete]
		public long m_mthGetChargeManInfo(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsEChargeInfo_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsEChargeInfo_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOutpatientChargeIdetityPrintSvc","m_mthGetChargeManInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT distinct te.lastname_vchr, te.empid_chr
									FROM t_bse_employee te, t_opr_outpatientrecipeinv tp
									WHERE te.empid_chr = tp.opremp_chr AND tp.balanceflag_int = 1";			
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new com.digitalwave.iCare.ValueObject.clsEChargeInfo_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsEChargeInfo_VO();
						p_objResultArr[i1].m_strEmpid_chr = dtbResult.Rows[i1]["empid_chr"].ToString().Trim();
						p_objResultArr[i1].m_strLastname_vchr = dtbResult.Rows[i1]["lastname_vchr"].ToString().Trim();
						
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

		#region 方法：获得系统时间：created by weiling.huang  at 2005-9-16
		/// <summary>
		/// 获取数据库服务器时间
		/// </summary>
		/// <returns>DateTime</returns>
		[AutoComplete]
//        public  DateTime m_dtmGetServerDate()
//        {
//            long lngRes = 0;
//            System.DateTime datResult = System.DateTime.Now;

//            string strSQL = @"select sysdate
//                              from dual";
//            System.Data.DataTable dtbResult = new System.Data.DataTable();
//            try
//            {
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult);


//                if (lngRes > 0 && dtbResult != null)
//                {
//                    datResult = System.DateTime.Parse(dtbResult.Rows[0]["sysdate"].ToString());

//                }
//                objHRPSvc.Dispose();
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return datResult;
//        }
        public string m_dtmGetServerDate()
        {
            long lngRes = 0;
            //System.DateTime datResult = System.DateTime.Now;
            string datResult = "";
            string strSQL = @"select sysdate
                              from dual";
            System.Data.DataTable dtbResult = new System.Data.DataTable();
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult);


                if (lngRes > 0 && dtbResult != null)
                {
                    datResult = dtbResult.Rows[0]["sysdate"].ToString();

                }
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return datResult;
        }
		#endregion

		#region 方法：根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息等：created by weiling.huang  at 2005-9-19
		/// <summary>
		/// 根据用户所选择时间,病人身份和操作员名称获取发票的结帐信息等
		/// </summary>
		/// <param name="p_objPrincipal">安全标识</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <param name="p_strdtmBegin">查询条件：就诊起始日�?/param>
		/// <param name="p_strdtmEnd">查询条件：就诊终止日�?/param>
		/// <param name="p_strPatientTypeId">查询条件：病人身份类型ID</param>
		/// <param name="p_strEmployeeID">查询条件：收费员ID</param>
		/// <returns></returns>
		[AutoComplete]
		public  long m_lngGetDataByTimeIndetityOp(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsOutPatientTableInfo_VO[] p_objResultArr, string p_strdtmBegin, string p_strdtmEnd, string p_strPatientTypeId, string p_strEmployeeID)
		{
			long lngRes = 0;
			p_objResultArr = new clsOutPatientTableInfo_VO[0];

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsOutpatientChargeIdetityPrintSvc","m_lngGetDataByTimeIndetityOp");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT td.patientcardid_chr, ta.recorddate_dat, ta.patientname_chr, ta.invoiceno_vchr, ta.acctsum_mny, ta.sbsum_mny,
									 ta.totalsum_mny, te.lastname_vchr
										FROM t_opr_outpatientrecipeinv ta,  t_bse_employee te,   t_bse_patientpaytype tp, t_bse_patientcard td
										WHERE ta.balanceflag_int = 1
												AND ta.opremp_chr = te.empid_chr(+)
												AND ta.paytypeid_chr = tp.paytypeid_chr(+)
												AND ta.patientid_chr = td.patientid_chr (+)";
					strSQL +=                "  AND ta.recorddate_dat BETWEEN to_date('"+p_strdtmBegin+" 00:00:00"+"','yyyy-mm-dd hh24:mi:ss')";
					strSQL	+=                " AND to_date('"+p_strdtmEnd+" 23:59:59"+"','yyyy-mm-dd hh24:mi:ss')";

			if(p_strPatientTypeId != null)
			{
				    strSQL +=                 " AND ta.PAYTYPEID_CHR = '"+ p_strPatientTypeId + "'";					
			}

			if(p_strEmployeeID != null)
			{
				    strSQL +=                 " AND te.EMPID_CHR = '"+ p_strEmployeeID + "'";					
			}

					strSQL +=                " order by te.EMPID_CHR,ta.recorddate_dat,ta.INVOICENO_VCHR";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoGetDataTable(strSQL,ref dtbResult);
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new com.digitalwave.iCare.ValueObject.clsOutPatientTableInfo_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new com.digitalwave.iCare.ValueObject.clsOutPatientTableInfo_VO();
						p_objResultArr[i1].m_strLastname_vchr = dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strPatientCardId = dtbResult.Rows[i1]["PATIENTCARDID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strPatientName = dtbResult.Rows[i1]["PATIENTNAME_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strRecordDataTime = Convert.ToDateTime(dtbResult.Rows[i1]["RECORDDATE_DAT"].ToString()).Date;
						p_objResultArr[i1].m_strInvoiceNo = dtbResult.Rows[i1]["INVOICENO_VCHR"].ToString();
						p_objResultArr[i1].m_strTOTALSUM_MNY = float.Parse(dtbResult.Rows[i1]["TOTALSUM_MNY"].ToString().Trim());
						p_objResultArr[i1].m_strSBSUM_MNY = float.Parse(dtbResult.Rows[i1]["SBSUM_MNY"].ToString().Trim());
						p_objResultArr[i1].m_strACCTSUM_MNY = float.Parse(dtbResult.Rows[i1]["ACCTSUM_MNY"].ToString().Trim());
						
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
		
		#endregion		

	}
	#endregion
}
