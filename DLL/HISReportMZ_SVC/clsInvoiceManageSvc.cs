using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.HIS.Reports
{	
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsInvoiceManageSvc: com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函数
		public clsInvoiceManageSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion 


		//门诊发票管理
		#region 添加发票请领		
		/// <summary>
		/// 添加发票请领
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objRecord">[作废相关的字段不必添加]</param>
		/// <param name="p_strRecordID">发票请求流水号</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngDoAddNewT_opr_opinvoiceman(System.Security.Principal.IPrincipal p_objPrincipal,clsT_opr_opinvoiceman_VO p_objRecord,out string p_strRecordID)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGenerateID(10,"Appid_chr","t_opr_opinvoiceman",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			string strSQL = "INSERT INTO t_opr_opinvoiceman (APPID_CHR,INVOICENOFROM_VCHR,INVOICENOTO_VCHR,APPLY_DAT,APPUSERID_CHR,OPERATORID_CHR,STATUS_INT) VALUES (?,?,?,?,?,?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(7,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_strRecordID;//p_objRecord.m_strAPPID_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strINVOICENOFROM_VCHR;
				objLisAddItemRefArr[2].Value = p_objRecord.m_strINVOICENOTO_VCHR;
				objLisAddItemRefArr[3].Value = DateTime.Parse(p_objRecord.m_strAPPLY_DAT);
				objLisAddItemRefArr[4].Value = p_objRecord.m_strAPPUSERID_CHR;
				objLisAddItemRefArr[5].Value = p_objRecord.m_strOPERATORID_CHR;
				objLisAddItemRefArr[6].Value = 0;//0-正常 1－作废;
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
			if(lngRes <= 0) lngRes=-100;
			return lngRes;
		}
		#endregion

		#region 作废领请的发票		徐斌辉		2004-8-23
		/// <summary>
		/// 作废领请的发票
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objRecord">[只需要m_strAPPID_CHR、m_strCANCELUSERID_CHR]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngModifyT_opr_opinvoiceman(System.Security.Principal.IPrincipal p_objPrincipal,clsT_opr_opinvoiceman_VO p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			string strSQL="UPDATE  T_OPR_OPINVOICEMAN SET " +		
				"  CANCELUSERID_CHR = '" + p_objRecord.m_strCANCELUSERID_CHR + "' " + 
				" , CANCEL_DAT = TO_DATE('" + strDateTime + "','YYYY-MM-DD hh24:mi:ss') " + 
				" , STATUS_INT = 1 " + //[状态：０-正常、１-作废]
				" WHERE Appid_chr = '" + p_objRecord.m_strAPPID_CHR + "'";
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

		#region 查询请领发的票		徐斌辉		2004-8-23
		/// <summary>
		/// 查询请领发的票
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strStartapply_dat">查询条件：起始申请时间</param>
		/// <param name="p_strEndapply_dat">查询条件：结束申请时间</param>
		/// <param name="p_strAppid_chr">查询条件：工号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngGetApplyInvoice(System.Security.Principal.IPrincipal p_objPrincipal,string p_strStartapply_dat,string p_strEndapply_dat,string p_strAppuserid_chr, out clsT_opr_opinvoiceman_VO[] p_objResultArr)
		{
			//构成查询条件
			string strQueryCondition ="";
			if(p_strStartapply_dat.Trim()!="")
				strQueryCondition += " AND trunc(Apply_dat) >=TO_DATE('" + p_strStartapply_dat.Trim() + "','yyyy-mm-dd') ";// hh24:mi:ss 
			if(p_strEndapply_dat.Trim()!="")
				strQueryCondition += " AND trunc(Apply_dat) <=TO_DATE('" + p_strEndapply_dat.Trim() + "','yyyy-mm-dd') ";// hh24:mi:ss 
			if(p_strAppuserid_chr.Trim()!="")
				strQueryCondition += " AND Appuserid_chr = '" + p_strAppuserid_chr.Trim() + "' "; //直接查询
			//strQueryCondition += " AND Appuserid_chr like '%" + p_strAppuserid_chr.Trim() + "%' ";//模糊查询

			return m_lngGetApplyInvoice(p_objPrincipal,strQueryCondition, out p_objResultArr);
			/*
			SELECT a.*, b.lastname_vchr AS appusername_chr,
       c.lastname_vchr AS operatorname_chr,
       d.lastname_vchr AS cancelusername_chr
  FROM t_opr_opinvoiceman a,
       t_bse_employee b,
       t_bse_employee c,
       t_bse_employee d
 WHERE a.appuserid_chr = b.empid_chr(+)
   AND a.operatorid_chr = c.empid_chr(+)
   AND a.canceluserid_chr = d.empid_chr(+)
   AND appuserid_chr = '0000001' 
			*/
		}
		/// <summary>
		/// 根据发票请求流水号查找对应记录信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strAppid_chr">发票请求流水号</param>
		/// <param name="p_objResult"></param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngGetApplyInvoice(System.Security.Principal.IPrincipal p_objPrincipal,string p_strAppid_chr, out clsT_opr_opinvoiceman_VO p_objResult)
		{
			p_objResult =null;
			//构成查询条件
			string strQueryCondition =" And appid_chr='" + p_strAppid_chr.Trim() + "' ";
			clsT_opr_opinvoiceman_VO[] p_objResultArr;
			long iReturn =m_lngGetApplyInvoice(p_objPrincipal,strQueryCondition, out p_objResultArr);
			if(iReturn>0 && p_objResultArr.Length>0)
				p_objResult =p_objResultArr[0];
			return iReturn;
		}
		/// <summary>
		/// 查询请领的发票
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strQueryCondition">查询条件</param>
		/// <param name="p_objResultArr"></param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngGetApplyInvoice(System.Security.Principal.IPrincipal p_objPrincipal,string p_strQueryCondition, out clsT_opr_opinvoiceman_VO[] p_objResultArr)
		{
			p_objResultArr = new clsT_opr_opinvoiceman_VO[0];
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetApplyInvoice");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL="SELECT appid_chr, invoicenofrom_vchr, invoicenoto_vchr," + 
				//" (invoicenoto_vchr-invoicenofrom_vchr)invoicenumber_int," + //发票张数
				" apply_dat, appuserid_chr," + 
				" (select LastName_vchr FROM T_BSE_EMPLOYEE WHERE EMPID_CHR=t_opr_opinvoiceman.appuserid_chr) appusername_chr," + //请领人
				" operatorid_chr, " + 
				" (select LastName_vchr FROM T_BSE_EMPLOYEE WHERE EMPID_CHR=t_opr_opinvoiceman.operatorid_chr) operatorname_chr," + //操作人
				" canceluserid_chr, " + 
				" (select LastName_vchr FROM T_BSE_EMPLOYEE WHERE EMPID_CHR=t_opr_opinvoiceman.canceluserid_chr) cancelusername_chr," + //作废人
				" cancel_dat, status_int" + 
				" FROM t_opr_opinvoiceman WHERE 1=1 " + p_strQueryCondition;
				
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsT_opr_opinvoiceman_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsT_opr_opinvoiceman_VO();
						p_objResultArr[i1].m_strAPPID_CHR = dtbResult.Rows[i1]["APPID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strINVOICENOFROM_VCHR = dtbResult.Rows[i1]["INVOICENOFROM_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strINVOICENOTO_VCHR = dtbResult.Rows[i1]["INVOICENOTO_VCHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["APPLY_DAT"]!=null && dtbResult.Rows[i1]["APPLY_DAT"].ToString().Trim()!="")
							p_objResultArr[i1].m_strAPPLY_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["APPLY_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						else
							p_objResultArr[i1].m_strAPPLY_DAT = "";
						p_objResultArr[i1].m_strAPPUSERID_CHR = dtbResult.Rows[i1]["APPUSERID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strAPPUSERNAME_CHR = dtbResult.Rows[i1]["appusername_chr"].ToString().Trim();//请领人
						p_objResultArr[i1].m_strOPERATORID_CHR = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strOPERATORNAME_CHR = dtbResult.Rows[i1]["operatorname_chr"].ToString().Trim();//操作人
						p_objResultArr[i1].m_strCANCELUSERID_CHR = dtbResult.Rows[i1]["CANCELUSERID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strCANCELUSERNAME_CHR = dtbResult.Rows[i1]["cancelusername_chr"].ToString().Trim();//作废人
						p_objResultArr[i1].m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[i1]["STATUS_INT"].ToString().Trim());
						if(dtbResult.Rows[i1]["CANCEL_DAT"]!=null && dtbResult.Rows[i1]["CANCEL_DAT"].ToString().Trim()!="")
							p_objResultArr[i1].m_strCANCEL_DAT = Convert.ToDateTime(dtbResult.Rows[i1]["CANCEL_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
						else
							p_objResultArr[i1].m_strCANCEL_DAT = "";
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

		#region 获取员工流水号	-根据职工号
		/// <summary>
		/// 获取员工流水号	-根据职工号
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strEmployeeNO">职工号</param>
		/// <param name="p_strEmployeeID">职工流水号 [out参数]</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetEmployeeIDByNO(System.Security.Principal.IPrincipal p_objPrincipal,string p_strEmployeeNO, out string p_strEmployeeID)
		{
			p_strEmployeeID = "";
			DataTable dtResult = new DataTable();
			long lngResult =m_lngGetApplyName(p_objPrincipal,p_strEmployeeNO,out dtResult);
			if(lngResult>0 && dtResult.Rows.Count>0 && dtResult.Rows[0]["EMPID_CHR"]!=null)
				p_strEmployeeID = dtResult.Rows[0]["EMPID_CHR"].ToString();
			return lngResult;
		}
		#endregion
		#region 获取员工名称	-根据工号		徐斌辉		2004-8-23
		/// <summary>
		/// 根据工号求得员工名称
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strNO">工号</param>
		/// <param name="p_strName">名称　[out　参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		/// <remarks>注意：p_strApplyName为字符串型</remarks>
		[AutoComplete]
		public long m_lngGetApplyName(System.Security.Principal.IPrincipal p_objPrincipal,string p_strNO, out string p_strName)
		{
			p_strName = "";
			DataTable dtResult = new DataTable();
			long lngResult =m_lngGetApplyName(p_objPrincipal,p_strNO,out dtResult);
			if(lngResult>0 && dtResult.Rows.Count>0)
				p_strName = dtResult.Rows[0]["AppuserName_chr"].ToString();
			return lngResult;
		}
		/// <summary>
		/// 根据工号求得员工名称
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strEmployeeNO">工号</param>
		/// <param name="p_dtResult">工号、名称表　[out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		/// <remarks>注意：p_dtResult为DataTable型</remarks>
		[AutoComplete]
		public long m_lngGetApplyName(System.Security.Principal.IPrincipal p_objPrincipal,string p_strEmployeeNO, out DataTable p_dtResult)
		{
			long lngRes = 0;
			p_dtResult = null;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngGetEmployeeNameByNO");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="select EMPID_CHR,Empno_chr As Appuserid_chr,LastName_vchr AS AppuserName_chr FROM T_BSE_EMPLOYEE WHERE Trim(Empno_chr) = '" + p_strEmployeeNO.Trim() + "'";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtResult);				
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
		#region 获取职工名称 -根据流水号
		/// <summary>
		/// 根据流水号求得员工名称
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strID">流水号</param>
		/// <param name="p_strEmployeeName">职工名称　[out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngGetEmployeeNameByID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strID, out string p_strEmployeeName)
		{
			long lngRes = 0;
			p_strEmployeeName = "";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngGetEmployeeNameByID");
			if(lngRes < 0) 
			{
				return -1;
			}
			string strSQL="select LastName_vchr AS EmployeeName FROM T_BSE_EMPLOYEE WHERE Trim(EMPID_CHR) = '" + p_strID.Trim() + "'";

			try
			{
				DataTable dtResult =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);	
				if(lngRes>0 && dtResult.Rows.Count>0 && dtResult.Rows[0]["EmployeeName"]!=null)
				{
					p_strEmployeeName =dtResult.Rows[0]["EmployeeName"].ToString();
				}
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

		#region	检查发票区间是否已经被申请		徐斌辉		2004-8-23	[注意：已经作废的发票可以重新申请]
		/// <summary>
		/// 检查发票区间是否已经被申请
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strMinInvoiceNo">起始发票号</param>
		/// <param name="p_strMaxInvoiceNo">结束发票号</param>
		/// <param name="IsUsed">是否备用的标志 [out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		/// <remarks>
		/// 注意：
		///		如果操作错误，则默认是已经占用；
		///		即 IsUsed = true
		/// </remarks>
		[AutoComplete]
		public long m_lngCheckInvoiceNOIsUsed(System.Security.Principal.IPrincipal p_objPrincipal,string p_strMinInvoiceNo,string p_strMaxInvoiceNo,out bool p_blnIsUsed)
		{
			p_blnIsUsed = true;
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngCheckInvoiceNOIsUsed");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}

			/* Get查询条件字符串 
			 * 首先：必须是没有被标记作废的发票号	[状态：０-正常、１-作废]
			 * A1：起始号字段、A2结束号字段、Min起始号参数、Max结束号参数
			 * Min <= A2 <= Max
			 * Min >= A1 AND Max <= A2
			 * Min <= A1 <= Max
			*/

			//string strSQL="SELECT appid_chr " + 
            //    " FROM t_opr_opinvoiceman WHERE invoicenofrom_vchr >='"+p_strMinInvoiceNo+"'  and  invoicenofrom_vchr <='"+p_strMaxInvoiceNo+"'" ;
            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                string strSQL;

                strSQL = "SELECT appid_chr " +
                " FROM t_opr_opinvoiceman WHERE STATUS_INT =0 and '" + p_strMinInvoiceNo + "' >=invoicenofrom_vchr and  '"
                + p_strMinInvoiceNo + "'<= INVOICENOTO_VCHR and length(invoicenofrom_vchr) = " + p_strMinInvoiceNo.Length.ToString();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);

                if (dtResult.Rows.Count > 0)
                    p_blnIsUsed = true;
                else
                {
                    strSQL = "SELECT appid_chr " +
                    " FROM t_opr_opinvoiceman WHERE STATUS_INT =0 and '" + p_strMaxInvoiceNo + "' >=invoicenofrom_vchr and  '"
                    + p_strMaxInvoiceNo + "'<= INVOICENOTO_VCHR and length(invoicenofrom_vchr) = " + p_strMaxInvoiceNo.Length.ToString();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
                    if (dtResult.Rows.Count > 0)
                        p_blnIsUsed = true;
                    else
                        p_blnIsUsed = false;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
			return lngRes;		
		}
		#endregion 

		#region 检查对应发票请求流水号是否被作废
		/// <summary>
		/// 检查对应发票请求流水号是否被作废
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strAppid_chr">发票请求流水号</param>
		/// <param name="p_blnIsUsed">是否被作废 [out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		[AutoComplete]
		public long m_lngCheckInvoiceNOIsCancel(System.Security.Principal.IPrincipal p_objPrincipal,string p_strAppid_chr,out bool p_blnIsUsed)
		{
			p_blnIsUsed = true;
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsHISInfoDefineSvc","m_lngCheckInvoiceNOIsCancel");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}

			/* Get查询条件字符串*/
			string strQueryCondition =" status_int = 1  AND rownum<= 1 ";
			strQueryCondition +=" AND appid_chr='" + p_strAppid_chr.Trim() + "' ";

			string strSQL="SELECT appid_chr " + 
				" FROM t_opr_opinvoiceman WHERE " + strQueryCondition;
			try
			{
				DataTable dtResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);	
				if(dtResult.Rows.Count > 0)
					p_blnIsUsed = true;
				else
					p_blnIsUsed = false;
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

		//门诊发票退回
		#region 获得发票信息		徐斌辉		2004-8-27
		/// <summary>
		/// 根据发票号获得门诊处方发票信息 [正常有效的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetInfoByNoForReturn(System.Security.Principal.IPrincipal p_objPrincipal,string p_strINVOICENO_VCHR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			p_objResult = new clsT_opr_outpatientrecipeinv_VO();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetInfoByNoForReturn");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM V_opr_outpatientrecipeinvret where SEQID_CHR= '" + p_strINVOICENO_VCHR + "' And status_int = 1";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResult = new clsT_opr_outpatientrecipeinv_VO();
					p_objResult.m_strINVOICENO_VCHR = dtbResult.Rows[0]["INVOICENO_VCHR"].ToString().Trim();
					p_objResult.m_strOUTPATRECIPEID_CHR = dtbResult.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
					p_objResult.m_strINVDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["INVDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_dblACCTSUM_MNY = Convert.ToDouble(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString().Trim());
					p_objResult.m_dblSBSUM_MNY = Convert.ToDouble(dtbResult.Rows[0]["SBSUM_MNY"].ToString().Trim());
					p_objResult.m_strOPREMP_CHR = dtbResult.Rows[0]["OPREMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDEMP_CHR = dtbResult.Rows[0]["RECORDEMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					p_objResult.m_strSEQID_CHR = dtbResult.Rows[0]["SEQID_CHR"].ToString().Trim();
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
		/// <summary>
		/// 根据物理号获得发票信息 [正常有效的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_NO_STR">物理号 [最大三位]</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetInfoBySeqidForReturn(System.Security.Principal.IPrincipal p_objPrincipal,string p_NO_STR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			p_objResult = new clsT_opr_outpatientrecipeinv_VO();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetInfoBySeqidForReturn");
			if(lngRes < 0)
			{
				return -1;
			}
			//			//确保物理号为3位   [系统流水号 命名方式：20040812000]
			//			while (p_NO_STR.Trim().Length < 3)
			//			{
			//				p_NO_STR = "0" + p_NO_STR.Trim();
			//			}
			//			p_NO_STR = System.DateTime.Now.ToString("yyyyMMdd") + p_NO_STR;

			string strSQL = @"SELECT * FROM t_opr_outpatientrecipeinv where seqid_chr= '" + p_NO_STR + "' And status_int = 1";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResult = new clsT_opr_outpatientrecipeinv_VO();
					p_objResult.m_strINVOICENO_VCHR = dtbResult.Rows[0]["INVOICENO_VCHR"].ToString().Trim();
					p_objResult.m_strOUTPATRECIPEID_CHR = dtbResult.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
					p_objResult.m_strINVDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["INVDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_dblACCTSUM_MNY = Convert.ToInt32(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString().Trim());
					p_objResult.m_dblSBSUM_MNY = Convert.ToInt32(dtbResult.Rows[0]["SBSUM_MNY"].ToString().Trim());
					p_objResult.m_strOPREMP_CHR = dtbResult.Rows[0]["OPREMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDEMP_CHR = dtbResult.Rows[0]["RECORDEMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					p_objResult.m_strSEQID_CHR = dtbResult.Rows[0]["SEQID_CHR"].ToString().Trim();
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
		#region 发票退回		徐斌辉		2004-8-27
		/// <summary>
		/// 发票ID
		/// </summary>
		private string strSEQID="";
		/// <summary>
		/// 发票退回[退票]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_strOPREMP_CHR">操作者ID</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngReturnTicket(System.Security.Principal.IPrincipal p_objPrincipal,string p_strINVOICENO_VCHR,string p_strOPREMP_CHR, ref string Seqid)
		{			
			clsOPChargeSvc obj =new clsOPChargeSvc();
            Seqid = DateTime.Now.ToString("yyMMddHHmmssffffff");
            strSEQID = Seqid;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngReturnTicket");
			if(lngRes < 0)
			{
				return -1;
			}
			
			string strSQL = @"insert into t_opr_outpatientrecipeinv (INVOICENO_VCHR,OUTPATRECIPEID_CHR,
INVDATE_DAT,ACCTSUM_MNY,SBSUM_MNY,OPREMP_CHR,RECORDEMP_CHR,RECORDDATE_DAT,
STATUS_INT,SEQID_CHR,TOTALSUM_MNY
,PAYTYPE_INT,PATIENTID_CHR,PATIENTNAME_CHR,DEPTID_CHR,DEPTNAME_CHR,DOCTORID_CHR,
DOCTORNAME_CHR,CONFIRMEMP_CHR,PAYTYPEID_CHR,  INTERNALFLAG_INT, BASESEQID_CHR, GROUPID_CHR, confirmdeptid_chr, split_int) 
select INVOICENO_VCHR,OUTPATRECIPEID_CHR,
to_date('" + DateTime.Now.ToString("yyyy-MM-dd")+@"','yyyy-mm-dd'),-ACCTSUM_MNY,-SBSUM_MNY,OPREMP_CHR,'"+p_strOPREMP_CHR+@"',to_date('"+DateTime.Now.ToString()+@"','yyyy-mm-dd hh24:mi:ss'),
'2','" + Seqid + @"',-TOTALSUM_MNY
,PAYTYPE_INT,PATIENTID_CHR,PATIENTNAME_CHR,DEPTID_CHR,DEPTNAME_CHR,DOCTORID_CHR,
DOCTORNAME_CHR,CONFIRMEMP_CHR,PAYTYPEID_CHR,  INTERNALFLAG_INT, BASESEQID_CHR, GROUPID_CHR, confirmdeptid_chr, split_int
from t_opr_outpatientrecipeinv where SEQID_CHR ='" + p_strINVOICENO_VCHR+"'";//发票状态：1-有效、0-作废、2-退票
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);

                strSQL = @"insert into t_opr_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny)
                           select '" + Seqid + @"',
                                  paytype_int,
                                  null,
                                  null,
                                  -sbsum_mny,
                                  0
                            from  t_opr_outpatientrecipeinv
                            where seqid_chr = '" + p_strINVOICENO_VCHR + "'";
                lngRes = objHRPSvc.DoExcute(strSQL);                            

				strSQL =@"UPDATE t_opr_outpatientrecipe
   SET pstauts_int = -2
 WHERE outpatrecipeid_chr IN (
          SELECT a.outpatrecipeid_chr
            FROM t_opr_reciperelation a, t_opr_outpatientrecipeinv b
           WHERE a.seqid = b.outpatrecipeid_chr
             AND b.seqid_chr = '"+p_strINVOICENO_VCHR+"')";
				
				lngRes = objHRPSvc.DoExcute(strSQL);
				if(lngRes>0)
				{
					this.m_mthInsertData("T_OPR_OUTPATIENTRECIPEINVDE",p_strINVOICENO_VCHR,"-",objHRPSvc);
					this.m_mthInsertData("T_OPR_OUTPATIENTRECIPESUMDE",p_strINVOICENO_VCHR,"-",objHRPSvc);
				
					//根据处方号更新检验、检查等项目收费标志(退款)
					strSQL = @"update t_opr_attachrelation 
									set status_int = 2 
								where sourceitemid_vchr in (
															select a.outpatrecipeid_chr
															  from t_opr_reciperelation a, t_opr_outpatientrecipeinv b
															 where a.seqid = b.outpatrecipeid_chr
															   and b.seqid_chr = '" + p_strINVOICENO_VCHR + "')";
					lngRes = objHRPSvc.DoExcute(strSQL);
					
					//退款时将通用申请单改写为已退款
					strSQL = @"update ar_common_apply 
								set chargestatus_int = 3 
								where applyid in (													
													select distinct c.attachid_vchr
													  from t_opr_reciperelation a, 
														   t_opr_outpatientrecipeinv b,
														   t_tmp_outpatienttestrecipede c
													 where a.seqid = b.outpatrecipeid_chr
													   and a.outpatrecipeid_chr = c.outpatrecipeid_chr
													   and b.seqid_chr = '" + p_strINVOICENO_VCHR + "')";
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
			
			//增加退回发票操作痕记录  [操作痕迹 1-添加新发票 2-作废发票 3-退回发票 4-恢复发票]
//			return m_lngAddNewT_opr_outpatientrecipeinvop(p_strINVOICENO_VCHR,p_strOPREMP_CHR,3);
		}
		#endregion

		//门诊发票恢复
		#region 获得发票信息		
		/// <summary>
		/// 根据发票号获得门诊处方发票信息 [已经退票的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetInfoByNoForResume(System.Security.Principal.IPrincipal p_objPrincipal,string p_strINVOICENO_VCHR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			p_objResult = new clsT_opr_outpatientrecipeinv_VO();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetInfoByNoForResume");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT * FROM t_opr_outpatientrecipeinv where SEQID_CHR= '" + p_strINVOICENO_VCHR + "' And status_int = 2";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResult = new clsT_opr_outpatientrecipeinv_VO();
					p_objResult.m_strINVOICENO_VCHR = dtbResult.Rows[0]["INVOICENO_VCHR"].ToString().Trim();
					p_objResult.m_strOUTPATRECIPEID_CHR = dtbResult.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
					p_objResult.m_strINVDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["INVDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_dblACCTSUM_MNY = Convert.ToDouble(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString().Trim());
					p_objResult.m_dblSBSUM_MNY = Convert.ToDouble(dtbResult.Rows[0]["SBSUM_MNY"].ToString().Trim());
					p_objResult.m_strOPREMP_CHR = dtbResult.Rows[0]["OPREMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDEMP_CHR = dtbResult.Rows[0]["RECORDEMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					p_objResult.m_strSEQID_CHR = dtbResult.Rows[0]["SEQID_CHR"].ToString().Trim();
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
		/// <summary>
		/// 根据物理号获得发票信息 [已经退票的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_NO_STR">物理号 [最大三位]</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetInfoBySeqidForResume(System.Security.Principal.IPrincipal p_objPrincipal,string p_NO_STR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			p_objResult = new clsT_opr_outpatientrecipeinv_VO();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetInfoBySeqidForResume");
			if(lngRes < 0)
			{
				return -1;
			}
			//确保物理号为3位   [系统流水号 命名方式：20040812000]
			//			while (p_NO_STR.Trim().Length < 3)
			//			{
			//				p_NO_STR = "0" + p_NO_STR.Trim();
			//			}
			//			p_NO_STR = System.DateTime.Now.ToString("yyyyMMdd") + p_NO_STR;

			string strSQL = @"SELECT * FROM t_opr_outpatientrecipeinv where seqid_chr= '" + p_NO_STR + "' And status_int = 2";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResult = new clsT_opr_outpatientrecipeinv_VO();
					p_objResult.m_strINVOICENO_VCHR = dtbResult.Rows[0]["INVOICENO_VCHR"].ToString().Trim();
					p_objResult.m_strOUTPATRECIPEID_CHR = dtbResult.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
					p_objResult.m_strINVDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["INVDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_dblACCTSUM_MNY = Convert.ToInt32(dtbResult.Rows[0]["ACCTSUM_MNY"].ToString().Trim());
					p_objResult.m_dblSBSUM_MNY = Convert.ToInt32(dtbResult.Rows[0]["SBSUM_MNY"].ToString().Trim());
					p_objResult.m_strOPREMP_CHR = dtbResult.Rows[0]["OPREMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDEMP_CHR = dtbResult.Rows[0]["RECORDEMP_CHR"].ToString().Trim();
					p_objResult.m_strRECORDDATE_DAT = Convert.ToDateTime(dtbResult.Rows[0]["RECORDDATE_DAT"]).ToString("yyyy-MM-dd HH:mm:ss").Trim();
					p_objResult.m_intSTATUS_INT = Convert.ToInt32(dtbResult.Rows[0]["STATUS_INT"].ToString().Trim());
					p_objResult.m_strSEQID_CHR = dtbResult.Rows[0]["SEQID_CHR"].ToString().Trim();
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
		#region 发票恢复		
		/// <summary>
		/// 发票恢复
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_strOPREMP_CHR">操作者ID</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngResumeTicket(System.Security.Principal.IPrincipal p_objPrincipal,string p_strINVOICENO_VCHR,string p_strOPREMP_CHR, ref string Seqid)
		{
			
			clsOPChargeSvc obj =new clsOPChargeSvc();
            Seqid = DateTime.Now.ToString("yyMMddHHmmssffffff");
            strSEQID = Seqid;
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngReturnTicket");
			if(lngRes < 0)
			{
				return -1;
			}
		
			string strSQL = @"insert into t_opr_outpatientrecipeinv (INVOICENO_VCHR,OUTPATRECIPEID_CHR,
                            INVDATE_DAT,ACCTSUM_MNY,SBSUM_MNY,OPREMP_CHR,RECORDEMP_CHR,RECORDDATE_DAT,
                            STATUS_INT,SEQID_CHR,TOTALSUM_MNY
                            ,PAYTYPE_INT,PATIENTID_CHR,PATIENTNAME_CHR,DEPTID_CHR,DEPTNAME_CHR,DOCTORID_CHR,
                            DOCTORNAME_CHR,CONFIRMEMP_CHR,PAYTYPEID_CHR, INTERNALFLAG_INT, BASESEQID_CHR, GROUPID_CHR, confirmdeptid_chr, split_int) 
                            select INVOICENO_VCHR,OUTPATRECIPEID_CHR,
                            to_date('" + DateTime.Now.ToString("yyyy-MM-dd")+@"','yyyy-mm-dd'),-ACCTSUM_MNY,-SBSUM_MNY,OPREMP_CHR,'"+p_strOPREMP_CHR+@"',to_date('"+DateTime.Now.ToString()+@"','yyyy-mm-dd hh24:mi:ss'),
                            '3','" + Seqid + @"',-TOTALSUM_MNY
                            ,PAYTYPE_INT,PATIENTID_CHR,PATIENTNAME_CHR,DEPTID_CHR,DEPTNAME_CHR,DOCTORID_CHR,
                            DOCTORNAME_CHR,CONFIRMEMP_CHR,PAYTYPEID_CHR,  INTERNALFLAG_INT, BASESEQID_CHR, GROUPID_CHR, confirmdeptid_chr, split_int
                            from t_opr_outpatientrecipeinv where SEQID_CHR ='" + p_strINVOICENO_VCHR+"'";//发票状态：1-有效、0-作废、2-退票
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);

                strSQL = @"insert into t_opr_payment(chargeno_vchr, paytype_int, paycardtype_int, paycardno_vchr, paysum_mny, refusum_mny)
                           select '" + strSEQID + @"',
                                  paytype_int,
                                  null,
                                  null,
                                  -sbsum_mny,
                                  0
                            from  t_opr_outpatientrecipeinv
                            where seqid_chr = '" + p_strINVOICENO_VCHR + "'";
                lngRes = objHRPSvc.DoExcute(strSQL); 

				strSQL =@"UPDATE t_opr_outpatientrecipe
                           SET pstauts_int = 3
                         WHERE outpatrecipeid_chr IN (
                                  SELECT a.outpatrecipeid_chr
                                    FROM t_opr_reciperelation a, t_opr_outpatientrecipeinv b
                                   WHERE a.seqid = b.outpatrecipeid_chr
                                     AND b.seqid_chr = '"+p_strINVOICENO_VCHR+"')";
				lngRes = objHRPSvc.DoExcute(strSQL);
				if(lngRes>0)
				{
					this.m_mthInsertData("T_OPR_OUTPATIENTRECIPEINVDE",p_strINVOICENO_VCHR,"-",objHRPSvc);
					this.m_mthInsertData("T_OPR_OUTPATIENTRECIPESUMDE",p_strINVOICENO_VCHR,"-",objHRPSvc);
//					
                    //根据处方号更新检验、检查等项目收费标志(恢复－>收费)
                    strSQL = @"update t_opr_attachrelation 
									set status_int = 1 
								where sourceitemid_vchr in (
															select a.outpatrecipeid_chr
															  from t_opr_reciperelation a, t_opr_outpatientrecipeinv b
															 where a.seqid = b.outpatrecipeid_chr
															   and b.seqid_chr = '" + p_strINVOICENO_VCHR + "')";
                    lngRes = objHRPSvc.DoExcute(strSQL);

                    //恢复时将通用申请单改写为已收费
                    strSQL = @"update ar_common_apply 
								set chargestatus_int = 2
								where applyid in (													
													select distinct c.attachid_vchr
													  from t_opr_reciperelation a, 
														   t_opr_outpatientrecipeinv b,
														   t_tmp_outpatienttestrecipede c
													 where a.seqid = b.outpatrecipeid_chr
													   and a.outpatrecipeid_chr = c.outpatrecipeid_chr
													   and b.seqid_chr = '" + p_strINVOICENO_VCHR + "')";
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
			
			return lngRes;;
		}
		#endregion
		#region 
        [AutoComplete]
        private void m_mthInsertData(string strTable, string Invoice, string flag, com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc)
        {
            string strSQL = "select * from " + strTable + " where SEQID_CHR ='" + Invoice + "'";
            DataTable dt = new DataTable();
            long l = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                //				string ID;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //					l =objHRPSvc.lngGenerateID(15,"SEQID_CHR",strTable,out ID);
                    if (l > 0)
                    {
                        decimal temp = 0;
                        decimal temp2 = 0;
                        try
                        {
                            //temp=Math.Abs(decimal.Parse(dt.Rows[i]["TOLFEE_MNY"].ToString()));
                            //temp2=Math.Abs(decimal.Parse(dt.Rows[i]["SBSUM_MNY"].ToString()));
                            temp = decimal.Parse(dt.Rows[i]["TOLFEE_MNY"].ToString());
                            temp2 = decimal.Parse(dt.Rows[i]["SBSUM_MNY"].ToString());
                        }
                        catch
                        {

                        }
                        if (flag.Trim() != "")
                        {
                            temp = temp * -1;
                            temp2 = temp2 * -1;
                        }
                        strSQL = "insert into " + strTable + "(ITEMCATID_CHR,TOLFEE_MNY,INVOICENO_VCHR,SEQID_CHR,SBSUM_MNY) values ('" + dt.Rows[i]["ITEMCATID_CHR"].ToString().Trim() + "','" + temp.ToString("0.00") + "',(select INVOICENO_VCHR from  t_opr_outpatientrecipeinv where SEQID_CHR ='" + Invoice + "'),'" + strSEQID + "','" + temp2.ToString() + "')";
                        l = objHRPSvc.DoExcute(strSQL);
                    }
                }
            }
        }
		#endregion
		#region 增加发票操作痕		
		/// <summary>
		/// 增加发票操作痕
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_strOPREMP_CHR">操作人ID</param>
		/// <param name="p_intState">[操作痕迹 1-添加新发票 2-作废发票 3-退回发票 4-恢复发票]</param>
		/// <returns></returns>
		[AutoComplete]
		private long m_lngAddNewT_opr_outpatientrecipeinvop(string p_strINVOICENO_VCHR,string p_strOPREMP_CHR,int p_intState)
		{
			long lngRes=0;			
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//增加发票操作痕记录  [操作痕迹 1-添加新发票 2-作废发票 3-退回发票 4-恢复发票]
			string strSQL = "INSERT INTO T_opr_outpatientrecipeinvop (INVOICENO_VCHR,SYS_DAT,OPREMP_CHR,OPRFLAG_INT) VALUES (?,?,?,?)";
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(4,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_strINVOICENO_VCHR;
				objLisAddItemRefArr[1].Value = DateTime.Parse(strDateTime);
				objLisAddItemRefArr[2].Value = p_strOPREMP_CHR;
				objLisAddItemRefArr[3].Value = p_intState;
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

		#region 根据卡号查出发票号
		/// <summary>
		/// 根据卡号查出发票号
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strCardID">卡号</param>
		/// <param name="dt"></param>
		/// <param name="flag">标志(为扩展用)</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthFindInvoiceByCardID(System.Security.Principal.IPrincipal p_objPrincipal,string strCardID, out DataTable dt,int flag,int p_FindFlag)
		{
			dt = new DataTable();
			long lngRes=0;
            string strSQL = "";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc","m_mthFindInvoiceByCardID");
			if(lngRes < 0)
			{
				return -1;
			}

            if (flag == 1)
            {
                strSQL = @"select a.* from V_OPR_OUTPATIENTRECIPEINVRET A ,T_BSE_PATIENTCARD B 
                            where a.patientid_chr =b.patientid_chr(+)
                            and b.patientcardid_chr='" + strCardID + @"'
                            and a.STATUS_INT =" + flag.ToString();
            }
            else
            {
                strSQL = @"select a.* from T_OPR_OUTPATIENTRECIPEINV A ,T_BSE_PATIENTCARD B 
                            where a.patientid_chr =b.patientid_chr(+)
                            and a.invoiceno_vchr IN ((SELECT DISTINCT invoiceno_vchr
                                                                   FROM t_opr_outpatientrecipeinv
                                                               GROUP BY invoiceno_vchr
                                                                 HAVING COUNT (invoiceno_vchr) = 2))
                            and b.patientcardid_chr='" + strCardID + @"'
                            and a.STATUS_INT =" + flag.ToString();
            }

			if(p_FindFlag==1)
			{
                if (flag == 1)
                {
                    strSQL = @"select a.* from V_OPR_OUTPATIENTRECIPEINVRET A where a.INVOICENO_VCHR like '" + strCardID + @"%'
and a.STATUS_INT =" + flag.ToString();
                }
                else
                {
                    strSQL = @"select a.* from T_OPR_OUTPATIENTRECIPEINV A 
                                        where a.invoiceno_vchr IN ((SELECT DISTINCT invoiceno_vchr
                                                                           FROM t_opr_outpatientrecipeinv
                                                                       GROUP BY invoiceno_vchr
                                                                         HAVING COUNT (invoiceno_vchr) = 2))
                                            and a.INVOICENO_VCHR like '" + strCardID + @"%'
                                            and a.STATUS_INT =" + flag.ToString();
                }
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 获取审核信息
		[AutoComplete]
		public long m_mthGetInvoiceAuditingInfo(System.Security.Principal.IPrincipal p_objPrincipal,string strID, out DataTable dt,int flag)
		{
			dt = new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc","m_mthGetInvoiceAuditingInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT a.*, b.lastname_vchr
  FROM t_opr_opri_confirm a, t_bse_employee b
 WHERE a.cfempid_chr = b.empid_chr(+)
 and A.SEQID_CHR ='"+strID+"' and A.STATUS_INT = "+flag.ToString() ;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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
		#region 增加审核信息
		[AutoComplete]
		public long m_mthAddInvoiceAuditingInfo(System.Security.Principal.IPrincipal p_objPrincipal,clsInvAuditing_VO objResult)
		{
			long lngRes = 0;
			string p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_mthAddInvoiceAuditingInfo");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes=objHRPSvc.lngGenerateID(20,"BASESEQID_CHR","T_OPR_OPRI_CONFIRM",out p_strID);
			if(lngRes<0)
				return -1;
			string strSQL=@"insert into t_opr_opri_confirm
            (baseseqid_chr, seqid_chr, status_int, cfempid_chr, cf_dat
            )
     values (?, ?, ?, ?, to_date (?, 'yyyy-mm-dd hh24:mi:ss')
            )";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(5,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = p_strID;
				objLisAddItemRefArr[1].Value = objResult.strSEQID_CHR;
				objLisAddItemRefArr[2].Value = objResult.strSTATUS_INT;
				objLisAddItemRefArr[3].Value = objResult.strCFEMPID_CHR;
				objLisAddItemRefArr[4].Value = objResult.strCF_DAT;
							
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
							 
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 验证密码

		[AutoComplete]
		public long m_mthGetEmployeeInfo(System.Security.Principal.IPrincipal p_objPrincipal,string strID, out DataTable dt,string strEx)
		{
			dt = new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc","m_mthGetEmployeeInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select * from t_bse_employee WHERE status_int = '1' AND empno_chr = '"+strID.Replace("'","‘")+"'" ;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
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

        #region 根据内部序列号判断是否为分票
        /// <summary>
        /// 根据内部序列号判断是否为分票
        /// </summary>
        /// <param name="seqid"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnChecksplit(string seqid)
        {
            long lngRes = 0;
            bool blnRet = false;
            string SQL = "select split_int from t_opr_outpatientrecipeinv where seqid_chr = '" + seqid + "'";
            DataTable dtRecord = new DataTable();

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (lngRes > 0 && dtRecord.Rows.Count == 1)
            {
                if (dtRecord.Rows[0][0].ToString() == "1")
                {
                    blnRet = true;
                }
            }
            return blnRet;
        }
        #endregion

        #region 根据内部序列号获取同组分发票数据
        /// <summary>
        /// 根据内部序列号获取同组分发票数据
        /// </summary>
        /// <param name="invono"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetsplitinvoinfo(string seqid, out DataTable dtRecord)
        {
            dtRecord = new DataTable();
            long lngRes = 0;

            string SQL = @" select distinct a.invoiceno_vchr
                              from t_opr_outpatientrecipeinv a
                             where a.baseseqid_chr in (
                                                         select baseseqid_chr
                                                           from t_opr_outpatientrecipeinv
                                                          where seqid_chr = '" + seqid + "')";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dtRecord);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
    }
}
