using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
namespace com.digitalwave.iCare.middletier.HIS.Reports
{
	/// <summary>
	/// clsChargeMaintenanceSvc ��ժҪ˵����
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsChargeMaintenanceSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsChargeMaintenanceSvc()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ��ȡ���˷��������Ϣ
		[AutoComplete]
		public void m_mthGetPatientCatInfo(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_dt)
		{
			p_dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetPatientCatInfo");
			if(lngRes < 0)
			{
				return ;
			}
            string strSQL = @"select PAYTYPEID_CHR COPAYID_CHR, PAYTYPENAME_VCHR COPAYNAME_CHR,payflag_dec from T_BSE_PATIENTPAYTYPE order by payflag_dec";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dt);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			
			
		}
		#endregion
		#region �����շ���Ŀ
		[AutoComplete]
		public long m_mthFindChargeItem(System.Security.Principal.IPrincipal p_objPrincipal,string strType,string ID,out DataTable p_dt,string strCatID)
		{
			p_dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindChargeItem");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select A.itemid_chr,A.itemname_vchr,A.itemcode_vchr,A.ITEMPRICE_MNY,B.copayid_chr,B.precent_dec from T_BSE_CHARGEITEM A,T_AID_INSCHARGEITEM B
where A.itemid_chr(+)=B.itemid_chr";
			if(strType.Trim()!=""&&ID.Trim()!="")
			{
				strSQL+=" and A."+strType.Trim()+" Like '"+ID+"%' order by A.itemcode_vchr desc";
			}
			else
			{
			strSQL+="  order by A.itemcode_vchr desc";
			}
			if(strCatID.Trim()!="")
			{
			strSQL = @"SELECT   a.itemid_chr, a.itemname_vchr, a.itemcode_vchr, a.itemprice_mny,
         b.copayid_chr, b.precent_dec
    FROM t_aid_inschargeitem b, t_bse_chargeitem a, t_bse_chargecatmap d
   WHERE b.itemid_chr = a.itemid_chr(+)
     AND a.itemopinvtype_chr = d.catid_chr(+)
     AND d.groupid_chr = '"+strCatID+@"'
     AND a."+strType.Trim()+@" Like '"+ID+@"%'
ORDER BY a.itemcode_vchr DESC";
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dt);
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
		#region ��������
		[AutoComplete]
		public void m_mthUpdateData(System.Security.Principal.IPrincipal p_objPrincipal,string strItemID,string strCopayID,string strValue)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthUpdateData");
			if(lngRes < 0)
			{
				return ;
			}
			string strSQL = "";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				strSQL =" select * from T_AID_INSCHARGEITEM   WHERE itemid_chr = '"+strItemID+"' AND copayid_chr = '"+strCopayID+"' ";
				DataTable dt=new DataTable();
				lngRes =objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				if(lngRes>0)
				{
					if(dt.Rows.Count==0)
					{
					strSQL="insert into T_AID_INSCHARGEITEM (ITEMID_CHR,COPAYID_CHR,PRECENT_DEC) values('"+strItemID+"','"+strCopayID+"','"+strValue+"')";
					}
					else
					{
					strSQL = @"update T_AID_INSCHARGEITEM set PRECENT_DEC='"+strValue+"' where ITEMID_CHR='"+strItemID+"' and COPAYID_CHR='"+strCopayID+"'";
					}
				
				lngRes = objHRPSvc.DoExcute(strSQL);
				}
				dt.Dispose();
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
		}
		#endregion
	}
/// <summary>
/// �����б�����м��
/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsWaitDiagListManageSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsWaitDiagListManageSvc()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ��ȡԱ����������
		[AutoComplete]
		public long m_mthGetDepartmentByID(System.Security.Principal.IPrincipal p_objPrincipal,string strEmpID,out DataTable p_dt)
		{
			p_dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetDepartmentByID");
			if(lngRes < 0)
			{
				return lngRes;
			}
			string strSQL = @" select deptid_chr,deptname_vchr  from t_bse_deptdesc
  where INPATIENTOROUTPATIENT_INT=0 and 
  -- ATTRIBUTEID ='0000002' and
  CATEGORY_INT =0 order by DEPTNAME_VCHR";
			if(strEmpID.Trim()!="")
			{
				strSQL = @"SELECT a.deptid_chr, b.deptname_vchr
  FROM t_bse_deptemp a, t_bse_deptdesc b
 WHERE a.deptid_chr = b.deptid_chr(+) AND A.end_dat IS NULL and b.INPATIENTOROUTPATIENT_INT=0 and
-- ATTRIBUTEID ='0000002' and 
CATEGORY_INT =0 AND A.empid_chr = '"+strEmpID+"' ";
			}
      
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dt);
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
		#region ���ݲ���ID����ҽ��,
		[AutoComplete]
		public long m_mthGetDocByDepID(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out DataTable p_dt)
		{
			p_dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetDocByDepID");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT distinct b.empid_chr, b.lastname_vchr,b.ISEXPERT_CHR,b.EMPNO_CHR
  FROM  t_bse_employee b ,T_BSE_DEPTEMP A
 WHERE b.status_int = 1
 and b.empid_chr=a.empid_chr(+) and b.HASPRESCRIPTIONRIGHT_CHR =1 ";
			if(ID.Trim()!="")
			{
			strSQL+= " and a.deptid_chr='"+ID+"'";
			}
			strSQL +=" order by b.empno_chr ";
 
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dt);
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
		#region ���ݲ���ID��ҽ��ID���Һ��ﲡ��
		[AutoComplete]
		public long m_mthGetWaitListByID(System.Security.Principal.IPrincipal p_objPrincipal,string strDocID,string strDepID,out DataTable p_dt,DateTime date,DateTime date2)
		{
			p_dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetWaitListByID");
			if(lngRes < 0)
			{
				return -1;
			}
			string strDoctorID =" = '"+strDocID+"'";
			if(strDocID.Trim()=="****")
			{
			strDoctorID =" is null";
			}
            string strSQL = @"select a.waitdiaglistid_chr, a.order_int, b.patientid_chr, c.lastname_vchr,
       c.sex_chr, c.birth_dat, b.patientcardid_chr
  from t_opr_waitdiaglist a, t_opr_patientregister b, t_bse_patient c
 where a.registerid_chr = b.registerid_chr(+)
   and b.patientid_chr = c.patientid_chr(+)
   and a.pstatus_int = 1
   and a.waitdiagdept_chr = ?
   and a.waitdiagdr_chr  " + strDoctorID + @"
   and a.registerdate_dat between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                              and to_date (?, 'yyyy-mm-dd hh24:mi:ss')";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objDataParaArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out m_objDataParaArr);
                m_objDataParaArr[0].Value = strDepID;
                m_objDataParaArr[1].Value = date.ToString("yyyy-MM-dd 00:00:00");
                m_objDataParaArr[2].Value = date2.ToString("yyyy-MM-dd 23:59:59");
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref p_dt,m_objDataParaArr);
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
		#region ���
		/// <summary>
		/// ���
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strDocID">ҽ��ID</param>
		/// <param name="strDepID">����ID</param>
		/// <param name="rowNo">����Ӻ�</param>
		/// <param name="strListID">����ID(Ψһ)</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthPrecedence(System.Security.Principal.IPrincipal p_objPrincipal,string strDocID,string strDepID,int rowNo,string strListID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthPrecedence");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"update t_opr_waitdiaglist
   set order_int = order_int + 1
 where waitdiagdept_chr = '"+strDepID+@"'
   and waitdiagdr_chr = '"+strDocID+@"'
   and order_int <= '"+rowNo.ToString()+@"'
";
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				if(lngRes>0)
				{
				strSQL=@"update t_opr_waitdiaglist
   set order_int = 1
 where waitdiaglistid_chr = '"+strListID+"'";
				lngRes = objHRPSvc.DoExcute(strSQL);
//				objHRPSvc.Dispose();
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
		#region �ƶ�λ��
		
		[AutoComplete]
		public long m_mthMoveOrder(string row1,string row2,string ID1,string ID2)
		{
			long lngRes=0;
			
			string strSQL="UPDATE t_opr_waitdiaglist SET order_int = "+row1+" WHERE waitdiaglistid_chr = '"+ID1+"'";
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
			
				if(lngRes>0)
				{
					strSQL="UPDATE t_opr_waitdiaglist SET order_int = "+row2+" WHERE waitdiaglistid_chr = '"+ID2+"'";
					lngRes = objHRPSvc.DoExcute(strSQL);
//					objHRPSvc.Dispose();
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
		#region ����ҽ��
		/// <summary>
		/// ����ҽ��
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strDocID">ҽ��ID</param>
		/// <param name="strListID">����ID</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthChangeDoc(System.Security.Principal.IPrincipal p_objPrincipal,string strDocID,string strDepID,string strListID)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthChangeDoc");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"UPDATE t_opr_waitdiaglist SET WAITDIAGDR_CHR = '"+strDocID+"',waitdiagdept_chr = '"+strDepID+"' WHERE waitdiaglistid_chr = '"+strListID+"'";
		
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
		#region ����ʱ��κ�Ա��ID������ﲡ��
		/// <summary>
		///  ����ʱ��κ�Ա��ID������ﲡ��
		/// </summary>
		/// <param name="strDocName">ҽ������ģ����ѯ</param>
		/// <param name="strDepID">����ID</param>
		/// <param name="p_dt"></param>
		/// <param name="date"></param>
		/// <param name="date2"></param>
		/// <param name="strEmpID">Ա��ID</param>
		/// <param name="flag">0�½�,1����</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetWaitListInfoByID(string strDocName,string strDepID,out DataTable p_dt,DateTime date,DateTime date2,string strEmpID,int flag)
		{
			p_dt=new DataTable();
			long lngRes=0;
				string strSQL = @"SELECT   a.waitdiaglistid_chr, a.order_int, b.patientid_chr, c.lastname_vchr,
         c.sex_chr, c.birth_dat, b.patientcardid_chr, a.waitdiagdept_chr,
         d.deptname_vchr, a.waitdiagdr_chr, e.lastname_vchr empname
    FROM t_opr_waitdiaglist a,
         t_opr_patientregister b,
         t_bse_patient c,
         t_bse_deptdesc d,
         t_bse_employee e,
         t_bse_deptemp f
   WHERE a.registerid_chr = b.registerid_chr(+)
     AND b.patientid_chr = c.patientid_chr(+)
     AND a.pstatus_int = "+flag.ToString()+@"
     AND a.waitdiagdept_chr = d.deptid_chr(+)
     AND a.waitdiagdr_chr = e.empid_chr(+)
     AND a.waitdiagdept_chr = f.deptid_chr(+)
     AND d.inpatientoroutpatient_int = 0
    -- AND d.attributeid = '0000002'
     AND d.category_int = 0
     AND f.empid_chr = '"+strEmpID+@"'
     AND f.end_dat IS NULL
	AND a.registerdate_dat BETWEEN TO_DATE('"+date.ToString("yyyy-MM-dd 00:00:00")+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+date2.ToString("yyyy-MM-dd 23:59:59")+" ','yyyy-mm-dd hh24:mi:ss')";
			if(strDepID.Trim()!="")
			{
			strSQL+=" AND a.waitdiagdept_chr ='"+strDepID+"'";
			}
			if(strDocName.Trim()!="")
			{
				strSQL+=" AND e.lastname_vchr  like '"+strDocName+"%'";
			}
            strSQL += "  ORDER BY a.order_int,a.waitdiagdr_chr";
           // strSQL += "  ORDER BY a.waitdiagdr_chr,a.order_int";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dt);
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

        #region �շ�Ա������ͳ�Ʊ��� @@@@@
        [AutoComplete]
		public long m_mthGetCheckManWorkLoad(DateTime strBeginDate,DateTime strEndDate,out clsChargeWork_VO[] objSubArr)
		{
			objSubArr =null;
			long lngRes=0;
            string strSQL = @"select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny, c.lastname_vchr
    from t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                   e.lastname_vchr
              from t_opr_outpatientrecipeinv a,
                   t_opr_outpatientrecipesumde b,
                   t_bse_employee e
             where a.seqid_chr = b.seqid_chr(+)
               and a.balanceemp_chr = e.empid_chr
               and a.balance_dat
                      between to_date
                                ('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
                                 'yyyy-mm-dd hh24:mi:ss'
                                )
                          and to_date
                                ('" + strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
                                 'yyyy-mm-dd hh24:mi:ss'
                                )
          group by e.lastname_vchr, b.itemcatid_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr(+)
     and a.rptid_chr = '0068'
     and b.rptid_chr = '0068'
group by c.lastname_vchr, a.groupid_chr, a.groupname_chr
order by a.groupid_chr
";
		
			try
			{
				DataTable dt =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				if(lngRes>0&&dt.Rows.Count>0)
				{
					objSubArr =new clsChargeWork_VO[dt.Rows.Count];
					for(int i =0;i<dt.Rows.Count;i++)
					{
						objSubArr[i]=new clsChargeWork_VO();
						objSubArr[i].m_strCatName =dt.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
						objSubArr[i].m_strCatMoney =dt.Rows[i]["TOLFEE_MNY"].ToString().Trim();
						objSubArr[i].m_strChargeName=dt.Rows[i]["LASTNAME_VCHR"].ToString().Trim();
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

        #region �շ�Ա������ͳ�Ʊ��� 
        /// <summary>
        /// �շ�Ա������ͳ�Ʊ��� 
        /// </summary>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetCheckManWorkLoad(DateTime strBeginDate, DateTime strEndDate, out DataTable dt)
        {            
            long lngRes = 0;
            dt = new DataTable();

//            string strSQL = @"select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny, c.lastname_vchr
//    from t_aid_rpt_gop_def a,
//         t_aid_rpt_gop_rla b,
//         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
//                   e.lastname_vchr
//              from t_opr_outpatientrecipeinv a,
//                   t_opr_outpatientrecipesumde b,
//                   t_bse_employee e
//             where a.seqid_chr = b.seqid_chr(+)
//               and a.balanceemp_chr = e.empid_chr
//               and a.balance_dat
//                      between to_date
//                                ('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
//                                 'yyyy-mm-dd hh24:mi:ss'
//                                )
//                          and to_date
//                                ('" + strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
//                                 'yyyy-mm-dd hh24:mi:ss'
//                                )
//          group by e.lastname_vchr, b.itemcatid_chr) c
//   where a.groupid_chr = b.groupid_chr(+)
//     and b.typeid_chr = c.itemcatid_chr(+)
//     and a.rptid_chr = '0068'
//     and b.rptid_chr = '0068'
//group by c.lastname_vchr, a.groupid_chr, a.groupname_chr
//order by c.lastname_vchr";

            string strSQL = @"select a.groupname_chr, sum (c.tolfee_mny) tolfee_mny, c.lastname_vchr
                                from t_aid_rpt_gop_def a,
                                     t_aid_rpt_gop_rla b,
                                     (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny, e.lastname_vchr
                                from t_opr_charge a, t_opr_outpatientrecipesumde b, t_bse_employee e
                               where a.chargeno_chr = b.chargeno_chr
                                 and a.recemp_chr = e.empid_chr
                                 and a.recdate_dat between to_date (?,
                                                                    'yyyy-mm-dd hh24:mi:ss'
                                                                   )
                                                       and to_date (?,
                                                                    'yyyy-mm-dd hh24:mi:ss'
                                                                   )
                            group by e.lastname_vchr, b.itemcatid_chr) c
                               where a.groupid_chr = b.groupid_chr(+)
                                 and b.typeid_chr = c.itemcatid_chr(+)
                                 and a.rptid_chr = '0068'
                                 and b.rptid_chr = '0068'
                            group by c.lastname_vchr, a.groupid_chr, a.groupname_chr
                            order by c.lastname_vchr";

            try
            {                
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = strBeginDate.ToString("yyyy-MM-dd 00:00:00");
                objParamArr[1].Value = strEndDate.ToString("yyyy-MM-dd 23:59:59");
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
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

        #region ͳ���շ�Ա������ͳ�Ʊ���Ʊ��(���������飬����շ�Աͬ����׼����ʱ��������һ���Ժ���Ҫͬһ����) @@@@@
        /// <summary>
        /// ͳ���շ�Ա������ͳ�Ʊ���Ʊ��(���������飬����շ�Աͬ����׼����ʱ��������һ���Ժ���Ҫͬһ����) @@@@@
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetCheckinvoicenums(string BeginDate, string EndDate, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;

//            string strSQL = @"select b.lastname_vchr, count(case a.status_int when 1 then 1 end) as kps, count(case a.status_int when 2 then 1 end) as tps, 
//                                     count(case a.status_int when 3 then 1 end) as hfs                               
//                                from t_opr_outpatientrecipeinv a,
//                                     t_bse_employee b
//                               where a.balanceemp_chr = b.empid_chr
//                                 and a.balanceflag_int = 1
//                                 and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                                                   AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//                            group by b.lastname_vchr  ";
            string strSQL = @"select b.lastname_vchr, count (case a.status_int
                                                                when 1
                                                                   then 1
                                                             end) as kps,
                                     count (case a.status_int
                                               when 2
                                                  then 1
                                            end) as tps, count (case a.status_int
                                                                   when 3
                                                                      then 1
                                                                end) as hfs
                                from t_opr_outpatientrecipeinv a, t_bse_employee b
                               where a.balanceemp_chr = b.empid_chr
                                 and a.balanceflag_int = 1
                                 and a.balance_dat between to_date (?,
                                                                    'yyyy-mm-dd hh24:mi:ss'
                                                                   )
                                                       and to_date (?,
                                                                    'yyyy-mm-dd hh24:mi:ss'
                                                                   )
                            group by b.lastname_vchr";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objParamArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out objParamArr);
                objParamArr[0].Value = BeginDate + " 00:00:00";
                objParamArr[1].Value = EndDate + " 23:59:59";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, objParamArr);
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

        #region
        [AutoComplete]
		public long m_mthGetSingleWorkLoad(string m_strFlag,string strID,DateTime strBeginDate,DateTime strEndDate,int flag,out clsSingleWorkLoadSubItem_VO[] objSubArr)
		{
			objSubArr =null;
            string tmep = "c.DIAGDR_CHR";
			if(flag ==2)//2������
			{
            //tmep ="a.DEPTID_CHR";
                tmep = "c.DIAGDEPT_CHR";
			}
			long lngRes=0;
//            string strSQL = @"SELECT   a.groupname_chr, SUM (c.tolfee_mny) tolfee_mny
//    FROM t_aid_rpt_gop_def a,
//         t_aid_rpt_gop_rla b,
//         (SELECT   b.itemcatid_chr, SUM (b.tolfee_mny) tolfee_mny
//              FROM t_opr_outpatientrecipeinv a, t_opr_outpatientrecipesumde b,t_opr_outpatientrecipe c
//             WHERE a.seqid_chr = b.seqid_chr(+)   AND a.balanceflag_int = 1
//                 and a.outpatrecipeid_chr=c.outpatrecipeid_chr
//             and c.pstauts_int in (2,3)   
//                   AND " + tmep+@" = '"+strID+@"'
//AND a.recorddate_dat  BETWEEN TO_DATE('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"','yyyy-mm-dd hh24:mi:ss') " +
//    " AND TO_DATE('"+strEndDate.ToString("yyyy-MM-dd 23:59:59")+@" ','yyyy-mm-dd hh24:mi:ss')
//          GROUP BY b.itemcatid_chr) c
//   WHERE a.groupid_chr = b.groupid_chr(+)
//     AND b.typeid_chr = c.itemcatid_chr(+)
//     AND a.rptid_chr = '0005'
//     AND b.rptid_chr = '0005'
//GROUP BY a.groupid_chr, a.groupname_chr
//ORDER BY a.groupid_chr";
            string strSQL = @"select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
              from t_opr_charge a,
                   t_opr_reciperelation e,
                   t_opr_outpatientrecipesumde b,
                   t_opr_outpatientrecipe c
             where a.CHARGENO_CHR = e.chargeno_chr(+)
               and e.outpatrecipeid_chr = c.outpatrecipeid_chr
               and a.chargeno_chr = b.chargeno_chr
               and a.RECFLAG_INT = 1
               and c.pstauts_int in (2, 3)
               AND " + tmep + @" = '" + strID + @"'
               and a.OPERDATE_DAT BETWEEN TO_DATE('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"','yyyy-mm-dd hh24:mi:ss') " +
    " AND TO_DATE('" + strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ','yyyy-mm-dd hh24:mi:ss')
          group by b.itemcatid_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr(+)
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr
order by a.groupid_chr";
            if (m_strFlag == "1")
            {
//                strSQL = @"SELECT   a.groupname_chr, SUM (c.tolfee_mny) tolfee_mny
//    FROM t_aid_rpt_gop_def a,
//         t_aid_rpt_gop_rla b,
//         (SELECT   b.itemcatid_chr, SUM (b.tolfee_mny) tolfee_mny
//              FROM t_opr_outpatientrecipeinv a, t_opr_outpatientrecipesumde b,t_opr_outpatientrecipe c
//             WHERE a.seqid_chr = b.seqid_chr(+)   AND a.balanceflag_int = 1
//                 and a.outpatrecipeid_chr=c.outpatrecipeid_chr
//             and c.pstauts_int in (2,3)   
//                   AND " + tmep + @" = '" + strID + @"'
//AND a.BALANCE_DAT  BETWEEN TO_DATE('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"','yyyy-mm-dd hh24:mi:ss') " +
//    " AND TO_DATE('" + strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ','yyyy-mm-dd hh24:mi:ss')
//          GROUP BY b.itemcatid_chr) c
//   WHERE a.groupid_chr = b.groupid_chr(+)
//     AND b.typeid_chr = c.itemcatid_chr(+)
//     AND a.rptid_chr = '0005'
//     AND b.rptid_chr = '0005'
//GROUP BY a.groupid_chr, a.groupname_chr
//ORDER BY a.groupid_chr";
                strSQL = @"select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny
    from t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
              from t_opr_charge a,
                   t_opr_reciperelation e,
                   t_opr_outpatientrecipesumde b,
                   t_opr_outpatientrecipe c
             where a.CHARGENO_CHR = e.chargeno_chr(+)
               and c.outpatrecipeid_chr = e.outpatrecipeid_chr 
               and a.chargeno_chr = b.chargeno_chr
               and a.RECFLAG_INT = 1
               and c.pstauts_int in (2, 3)
               AND " + tmep + @" = '" + strID + @"'
               and a.RECDATE_DAT BETWEEN TO_DATE('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"','yyyy-mm-dd hh24:mi:ss') " +
    " AND TO_DATE('" + strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ','yyyy-mm-dd hh24:mi:ss')
          group by b.itemcatid_chr) c
   where a.groupid_chr = b.groupid_chr(+)
     and b.typeid_chr = c.itemcatid_chr(+)
     and a.rptid_chr = '0005'
     and b.rptid_chr = '0005'
group by a.groupid_chr, a.groupname_chr
order by a.groupid_chr";
            }
			try
			{
				DataTable dt =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				objHRPSvc.Dispose();
				if(lngRes>0&&dt.Rows.Count>0)
				{
					objSubArr =new clsSingleWorkLoadSubItem_VO[dt.Rows.Count];
					for(int i =0;i<dt.Rows.Count;i++)
					{
						objSubArr[i]=new clsSingleWorkLoadSubItem_VO();
						objSubArr[i].m_strCatName =dt.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
						objSubArr[i].m_strCatMoney =dt.Rows[i]["TOLFEE_MNY"].ToString().Trim();
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
        #region ����Ա��ID�����ڻ�ȡ�������͸�����
        /// <summary>
        /// ����Ա��ID�����ڻ�ȡ�������͸�����
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strID">ҽ��ID</param>
        /// <param name="m_strBeginDate">��ʼʱ��</param>
        /// <param name="m_strEndDate">����ʱ��</param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetRecipeCountByIDAndDate(System.Security.Principal.IPrincipal p_objPrincipal,string m_strFlag,string m_strID, DateTime m_strBeginDate, DateTime m_strEndDate, out DataTable m_objTable)
        {
            long lngRes = 0;
            m_objTable = null;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc", "m_lngGetRecipeCountByIDAndDate");
            if (lngRes < 0)
            {
                return -1;
            }
            //��һ��Ϊ���������ڶ���Ϊ������
//            string strSQL = @"SELECT COUNT (*)
//  FROM t_opr_outpatientrecipeinv a,
//       t_opr_reciperelation b,
//       t_opr_outpatientrecipe c
// WHERE a.outpatrecipeid_chr = b.seqid
//   AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
//   AND (a.status_int = 1 OR a.status_int = 3)
//   AND a.balanceflag_int = 1 and c.pstauts_int in (2,3)   
//   AND a.recorddate_dat BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//                         AND TO_DATE ('" +m_strEndDate.ToString("yyyy-MM-dd 23:59:59")+@" ',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//   AND c.recipeflag_int = 1
//   AND a.doctorid_chr = '"+m_strID+ @"'
//UNION ALL
//SELECT COUNT (*) c
//  FROM t_opr_outpatientrecipeinv a,
//       t_opr_reciperelation b,
//       t_opr_outpatientrecipe c
// WHERE a.outpatrecipeid_chr = b.seqid and c.pstauts_int in (2,3)   
//   AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
//   AND (a.status_int = 1 OR a.status_int = 3)
//   AND a.balanceflag_int = 1
//   AND a.recorddate_dat BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//                         AND TO_DATE ('" + m_strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//   AND c.recipeflag_int = 2
//   AND a.doctorid_chr = '" +m_strID+"'";
            string strSQL = @"SELECT COUNT (*)
  FROM t_opr_outpatientrecipeinv a,
       t_opr_chargedefinv e,
       t_opr_charge f,
       t_opr_reciperelation b,
       t_opr_outpatientrecipe c
 WHERE a.outpatrecipeid_chr = e.invoiceno_vchr
   and f.chargeno_chr = e.chargeno_chr
   and f.chargeno_chr = b.chargeno_chr
   and c.outpatrecipeid_chr = c.outpatrecipeid_chr
   AND (a.status_int = 1 OR a.status_int = 3)
   AND f.recflag_int = 1 and c.pstauts_int in (2,3)   
   AND f.recdate_dat BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
                         AND TO_DATE ('" +m_strEndDate.ToString("yyyy-MM-dd 23:59:59")+@" ',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
   AND c.recipeflag_int = 1
   AND c.diagdr_chr = '"+m_strID+ @"'
UNION ALL
SELECT COUNT (*) c
    FROM t_opr_outpatientrecipeinv a,
       t_opr_chargedefinv e,
       t_opr_charge f,
       t_opr_reciperelation b,
       t_opr_outpatientrecipe c
 WHERE a.outpatrecipeid_chr = e.invoiceno_vchr
   and f.chargeno_chr = e.chargeno_chr
   and f.chargeno_chr = b.chargeno_chr
   and c.outpatrecipeid_chr = c.outpatrecipeid_chr
   AND (a.status_int = 1 OR a.status_int = 3)
   AND f.recflag_int = 1 
   AND f.OPERDATE_DAT BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
                         AND TO_DATE ('" + m_strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
   AND c.recipeflag_int = 2
   AND c.diagdr_chr = '" +m_strID+"'";
            if (m_strFlag == "1")
            {
//                strSQL = @"SELECT COUNT (*)
//  FROM t_opr_outpatientrecipeinv a,
//       t_opr_reciperelation b,
//       t_opr_outpatientrecipe c
// WHERE a.outpatrecipeid_chr = b.seqid
//   AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
//   AND (a.status_int = 1 OR a.status_int = 3)
//   AND a.balanceflag_int = 1 and c.pstauts_int in (2,3)   
//   AND a.BALANCE_DAT BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//                         AND TO_DATE ('" + m_strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//   AND c.recipeflag_int = 1
//   AND a.doctorid_chr = '" + m_strID + @"'
//UNION ALL
//SELECT COUNT (*) c
//  FROM t_opr_outpatientrecipeinv a,
//       t_opr_reciperelation b,
//       t_opr_outpatientrecipe c
// WHERE a.outpatrecipeid_chr = b.seqid and c.pstauts_int in (2,3)   
//   AND b.outpatrecipeid_chr = c.outpatrecipeid_chr
//   AND (a.status_int = 1 OR a.status_int = 3)
//   AND a.balanceflag_int = 1
//   AND a.BALANCE_DAT BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//                         AND TO_DATE ('" + m_strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
//                                      'yyyy-mm-dd hh24:mi:ss'
//                                     )
//   AND c.recipeflag_int = 2
//   AND a.doctorid_chr = '" + m_strID + "'";
                strSQL = @"SELECT COUNT (*)
  FROM t_opr_outpatientrecipeinv a,
       t_opr_chargedefinv e,
       t_opr_charge f,
       t_opr_reciperelation b,
       t_opr_outpatientrecipe c
 WHERE a.outpatrecipeid_chr = e.invoiceno_vchr
   and f.chargeno_chr = e.chargeno_chr
   and f.chargeno_chr = b.chargeno_chr
   and c.outpatrecipeid_chr = c.outpatrecipeid_chr
   AND (a.status_int = 1 OR a.status_int = 3)
   AND f.recflag_int = 1 and c.pstauts_int in (2,3)   
   AND f.recdate_dat BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
                         AND TO_DATE ('" +m_strEndDate.ToString("yyyy-MM-dd 23:59:59")+@" ',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
   AND c.recipeflag_int = 1
   AND c.diagdr_chr = '"+m_strID+ @"'
UNION ALL
SELECT COUNT (*) c
    FROM t_opr_outpatientrecipeinv a,
       t_opr_chargedefinv e,
       t_opr_charge f,
       t_opr_reciperelation b,
       t_opr_outpatientrecipe c
 WHERE a.outpatrecipeid_chr = e.invoiceno_vchr
   and f.chargeno_chr = e.chargeno_chr
   and f.chargeno_chr = b.chargeno_chr
   and c.outpatrecipeid_chr = c.outpatrecipeid_chr
   AND (a.status_int = 1 OR a.status_int = 3)
   AND f.recflag_int = 1 
   AND f.recdate_dat BETWEEN TO_DATE ('" + m_strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
                         AND TO_DATE ('" + m_strEndDate.ToString("yyyy-MM-dd 23:59:59") + @" ',
                                      'yyyy-mm-dd hh24:mi:ss'
                                     )
   AND c.recipeflag_int = 2
   AND c.diagdr_chr = '" +m_strID+"'";
            }
            try
            {
                
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                
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
        #region ȡ����������
        [AutoComplete]
		public long m_mthGetSingleWorkLoad_New(string m_strFlag,string strID,DateTime strBeginDate,DateTime strEndDate,int flag,out clsSingleWorkLoadSubItem_VO[] objSubArr,string p_identityId)
		{
			objSubArr =null;
			string tmep ="a.doctorid_chr";
			if(flag ==2)//2������
			{
				tmep ="a.DEPTID_CHR";
			}
			long lngRes=0;
			string strSQL = @"select * from 

(
SELECT   a.groupname_chr, SUM (c.tolfee_mny) tolfee_mny
    FROM t_aid_rpt_gop_def a,
         t_aid_rpt_gop_rla b,
         (SELECT   b.itemcatid_chr, SUM (b.tolfee_mny) tolfee_mny
              FROM t_opr_outpatientrecipeinv a, t_opr_outpatientrecipesumde b,t_opr_outpatientrecipe c , t_bse_patientPaytype p
             WHERE a.seqid_chr = b.seqid_chr(+)
              and a.outpatrecipeid_chr=c.outpatrecipeid_chr
              and c.pstauts_int in (2,3)
               AND " + tmep+@" = '"+strID+@"'
               and a.PAYTYPEID_CHR = p.PAYTYPEID_CHR(+) ";
			if(p_identityId != "-1")
            strSQL+="   and p.INTERNALFLAG_INT ="+ p_identityId ;

        strSQL += @"   AND a.recorddate_dat  BETWEEN TO_DATE('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"','yyyy-mm-dd hh24:mi:ss') " +
				" AND TO_DATE('"+strEndDate.ToString("yyyy-MM-dd 23:59:59")+@" ','yyyy-mm-dd hh24:mi:ss')
          GROUP BY b.itemcatid_chr) c
   WHERE a.groupid_chr = b.groupid_chr(+)
     AND b.typeid_chr = c.itemcatid_chr(+)
     AND a.rptid_chr = '0005'
     AND b.rptid_chr = '0005'
GROUP BY a.groupid_chr, a.groupname_chr
ORDER BY a.groupid_chr
)
,

(
SELECT   count(a.INVOICENO_VCHR) as NCount  --������ 
              FROM t_opr_outpatientrecipeinv a , t_bse_patientPaytype p
             WHERE  
               ";
		strSQL +=@"	   "+tmep+@" = '"+strID+@"'
                and a.PAYTYPEID_CHR = p.PAYTYPEID_CHR(+) ";
			if(p_identityId != "-1")
				strSQL+="   and p.INTERNALFLAG_INT ="+ p_identityId ;
            strSQL += @"   AND a.recorddate_dat  BETWEEN TO_DATE('" + strBeginDate.ToString("yyyy-MM-dd 00:00:00") + @"','yyyy-mm-dd hh24:mi:ss') " +
				" AND TO_DATE('"+strEndDate.ToString("yyyy-MM-dd 23:59:59")+@" ','yyyy-mm-dd hh24:mi:ss')
 
 )
 ";
            if (m_strFlag == "1")
            {
                strSQL = strSQL.Replace("recorddate_dat", "BALANCE_DAT");
            }
			try
			{
				DataTable dt =new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				objHRPSvc.Dispose();
				if(lngRes>0&&dt.Rows.Count>0)
				{
					objSubArr =new clsSingleWorkLoadSubItem_VO[dt.Rows.Count + 1];
					for(int i =0;i<dt.Rows.Count+1;i++)
					{
						objSubArr[i]=new clsSingleWorkLoadSubItem_VO();
						if(i==0)
						{
							objSubArr[i].m_strCatName ="������";
							objSubArr[i].m_strCatMoney =dt.Rows[i]["NCOUNT"].ToString().Trim();
						}
						else
						{							
							objSubArr[i].m_strCatName =dt.Rows[i-1]["GROUPNAME_CHR"].ToString().Trim();
							objSubArr[i].m_strCatMoney =dt.Rows[i-1]["TOLFEE_MNY"].ToString().Trim();
						}
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
        
		#region ��ȡ��Ĺ���������
		[AutoComplete]
		public long m_mthGetGroupWorkLoad(string strCheckManID,string strDeptID,DateTime strBeginDate,DateTime strEndDate,int flag,out clsSingleWorkLoadSubItem_VO[] objSubArr)
		{
			objSubArr =null;
			long lngRes=0;
            string strSQL = string.Empty;
            if (strCheckManID == string.Empty)
            {
                if (strDeptID == string.Empty)
                {
//                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 f.groupname_vchr, f.sort_int
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 t_bse_groupdesc f,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
//                           a.groupid_chr
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.groupid_chr is not null
//                  group by b.itemcatid_chr, a.groupid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and f.groupid_chr = c.groupid_chr
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr, f.groupname_vchr, f.sort_int
//        order by f.sort_int)
//union all
//select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 'δ������' groupname_vchr
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.groupid_chr is null
//                  group by b.itemcatid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr)
//";
                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.groupid_chr is not null
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 'δ������' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.groupid_chr is null
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)
";
                }
                else
                {
//                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 f.groupname_vchr, f.sort_int
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 t_bse_groupdesc f,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
//                           a.groupid_chr
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b,
//                           t_bse_deptdesc e,
//                           t_bse_employee f,
//                           t_bse_deptemp g
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.groupid_chr is not null
//                       and a.balanceemp_chr = f.empid_chr
//                       and f.empid_chr = g.empid_chr
//                       and g.deptid_chr = e.deptid_chr
//                       and e.deptid_chr = '" + strDeptID + @"'
//                  group by b.itemcatid_chr, a.groupid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and f.groupid_chr = c.groupid_chr
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr, f.groupname_vchr, f.sort_int
//        order by f.sort_int)
//union all
//select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 'δ������' groupname_vchr
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b,
//                           t_bse_deptdesc e,
//                           t_bse_employee f,
//                           t_bse_deptemp g
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.groupid_chr is null
//                       and a.balanceemp_chr = f.empid_chr
//                       and f.empid_chr = g.empid_chr
//                       and g.deptid_chr = e.deptid_chr
//                       and e.deptid_chr = '" + strDeptID + @"'
//                  group by b.itemcatid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr)
//";
                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                               between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.groupid_chr is not null
                       and a.recemp_chr = f.empid_chr
                       and f.empid_chr = g.empid_chr
                       and g.deptid_chr = e.deptid_chr
                       and e.deptid_chr = '" + strDeptID + @"'
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 'δ������' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                                between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.groupid_chr is null
                       and a.recemp_chr = f.empid_chr
                       and f.empid_chr = g.empid_chr
                       and g.deptid_chr = e.deptid_chr
                       and e.deptid_chr = '" + strDeptID + @"'
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)";
                }
                try
                {
                    DataTable dt = new DataTable();
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ParamArr[0].Value = strBeginDate.ToString("yyyy-MM-dd 00:00:00");
                    ParamArr[1].Value = strEndDate.ToString("yyyy-MM-dd 23:59:59"); ;
                    ParamArr[2].Value = strBeginDate.ToString("yyyy-MM-dd 00:00:00");
                    ParamArr[3].Value = strEndDate.ToString("yyyy-MM-dd 23:59:59");
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                    objHRPSvc.Dispose();
                    if (lngRes > 0 && dt.Rows.Count > 0)
                    {
                        objSubArr = new clsSingleWorkLoadSubItem_VO[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objSubArr[i] = new clsSingleWorkLoadSubItem_VO();
                            objSubArr[i].m_strCatName = dt.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
                            objSubArr[i].m_strCatMoney = dt.Rows[i]["TOLFEE_MNY"].ToString().Trim();
                            objSubArr[i].m_strGroupName = dt.Rows[i]["groupname_vchr"].ToString().Trim();
                        }

                    }
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                if (strDeptID == string.Empty)
                {
//                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 f.groupname_vchr, f.sort_int
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 t_bse_groupdesc f,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
//                           a.groupid_chr
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.balanceemp_chr = '" + strCheckManID + @"'
//                       and a.groupid_chr is not null
//                  group by b.itemcatid_chr, a.groupid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and f.groupid_chr = c.groupid_chr
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr, f.groupname_vchr, f.sort_int
//        order by f.sort_int)
//union all
//select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 'δ������' groupname_vchr
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.balanceemp_chr = '" + strCheckManID + @"'
//                       and a.groupid_chr is null
//                  group by b.itemcatid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr)
//";
                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.recemp_chr = '" + strCheckManID + @"'
                       and a.groupid_chr is not null
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 'δ������' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.recemp_chr = '" + strCheckManID + @"'
                       and a.groupid_chr is null
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)";
                }
                else
                {
//                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 f.groupname_vchr, f.sort_int
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 t_bse_groupdesc f,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
//                           a.groupid_chr
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b,
//                           t_bse_deptdesc e,
//                           t_bse_employee f,
//                           t_bse_deptemp g
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.balanceemp_chr = '" + strCheckManID + @"'
//                       and a.groupid_chr is not null
//                       and a.balanceemp_chr = f.empid_chr
//                       and f.empid_chr = g.empid_chr
//                       and g.deptid_chr = e.deptid_chr
//                       and e.deptid_chr = '" + strDeptID + @"'
//                  group by b.itemcatid_chr, a.groupid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and f.groupid_chr = c.groupid_chr
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr, f.groupname_vchr, f.sort_int
//        order by f.sort_int)
//union all
//select groupname_chr, tolfee_mny, groupname_vchr
//  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
//                 'δ������' groupname_vchr
//            from t_aid_rpt_gop_def a,
//                 t_aid_rpt_gop_rla b,
//                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
//                      from t_opr_outpatientrecipeinv a,
//                           t_opr_outpatientrecipesumde b,
//                           t_bse_deptdesc e,
//                           t_bse_employee f,
//                           t_bse_deptemp g
//                     where a.seqid_chr = b.seqid_chr(+)
//                       and a.balance_dat
//                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
//                       and a.groupid_chr is null
//                       and a.balanceemp_chr = '" + strCheckManID + @"'
//                       and a.balanceemp_chr = f.empid_chr
//                       and f.empid_chr = g.empid_chr
//                       and g.deptid_chr = e.deptid_chr
//                       and e.deptid_chr = '" + strDeptID + @"'
//                  group by b.itemcatid_chr) c
//           where a.groupid_chr = b.groupid_chr(+)
//             and b.typeid_chr = c.itemcatid_chr(+)
//             and a.rptid_chr = '0066'
//             and b.rptid_chr = '0066'
//        group by a.groupname_chr)
//
//";
                    strSQL = @"select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 f.groupname_vchr, f.sort_int
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 t_bse_groupdesc f,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny,
                           a.groupid_chr
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.recemp_chr = '" + strCheckManID + @"'
                       and a.groupid_chr is not null
                       and a.recemp_chr = f.empid_chr
                       and f.empid_chr = g.empid_chr
                       and g.deptid_chr = e.deptid_chr
                       and e.deptid_chr = '" + strDeptID + @"'
                  group by b.itemcatid_chr, a.groupid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and f.groupid_chr = c.groupid_chr
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr, f.groupname_vchr, f.sort_int
        order by f.sort_int)
union all
select groupname_chr, tolfee_mny, groupname_vchr
  from (select   a.groupname_chr, sum (c.tolfee_mny) tolfee_mny,
                 'δ������' groupname_vchr
            from t_aid_rpt_gop_def a,
                 t_aid_rpt_gop_rla b,
                 (select   b.itemcatid_chr, sum (b.tolfee_mny) tolfee_mny
                      from t_opr_charge a,
                           t_opr_outpatientrecipesumde b,
                           t_bse_deptdesc e,
                           t_bse_employee f,
                           t_bse_deptemp g
                     where a.chargeno_chr = b.chargeno_chr(+)
                       and a.recdate_dat
                              between to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                                  and to_date (?, 'yyyy-mm-dd hh24:mi:ss')
                       and a.groupid_chr is null
                       and a.recemp_chr = '" + strCheckManID + @"'
                       and a.recemp_chr = f.empid_chr
                       and f.empid_chr = g.empid_chr
                       and g.deptid_chr = e.deptid_chr
                       and e.deptid_chr = '" + strDeptID + @"'
                  group by b.itemcatid_chr) c
           where a.groupid_chr = b.groupid_chr(+)
             and b.typeid_chr = c.itemcatid_chr(+)
             and a.rptid_chr = '0066'
             and b.rptid_chr = '0066'
        group by a.groupname_chr)";

                }
                try
                {
                    DataTable dt = new DataTable();
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    IDataParameter[] ParamArr = null;
                    objHRPSvc.CreateDatabaseParameter(4, out ParamArr);
                    ParamArr[0].Value = strBeginDate.ToString("yyyy-MM-dd 00:00:00");
                    ParamArr[1].Value = strEndDate.ToString("yyyy-MM-dd 23:59:59"); ;
                    ParamArr[2].Value = strBeginDate.ToString("yyyy-MM-dd 00:00:00"); ;
                    ParamArr[3].Value = strEndDate.ToString("yyyy-MM-dd 23:59:59"); ;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, ParamArr);
                    objHRPSvc.Dispose();
                    if (lngRes > 0 && dt.Rows.Count > 0)
                    {
                        objSubArr = new clsSingleWorkLoadSubItem_VO[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            objSubArr[i] = new clsSingleWorkLoadSubItem_VO();
                            objSubArr[i].m_strCatName = dt.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
                            objSubArr[i].m_strCatMoney = dt.Rows[i]["TOLFEE_MNY"].ToString().Trim();
                            objSubArr[i].m_strGroupName = dt.Rows[i]["groupname_vchr"].ToString().Trim();
                        }

                    }
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
			return lngRes;
		}
		#endregion

		#region ��ȡ�������ļ�¼��
        /// <summary>
        /// ��ȡ�������ļ�¼��
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
		[AutoComplete]
		public long m_mthGetCount(out DataTable dt)
		{
			dt =new DataTable();
			long lngRes=0;
            string strSQL = @"select   count (case
                   when a.recipeflag_int = 1
                      then 1
                end) as ����,
         count (case
                   when a.recipeflag_int = 2
                      then 1
                end) as ����, b.groupname_vchr
    from t_opr_outpatientrecipe a, t_bse_groupdesc b
   where a.groupid_chr = b.groupid_chr and a.pstauts_int = 2
      or a.pstauts_int = 3
group by b.groupname_vchr";
		
			try
			{
			
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				
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

        #region ���ݽ���ʱ��ͳ��������������¼��    
        /// <summary>
        /// ���ݽ���ʱ��ͳ��������������¼��
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetCount(string m_strCheckManID,string m_strDeptID,string BeginDate, string EndDate, out DataTable m_dtZFS,out DataTable m_dtFFS)
        {
            m_dtFFS = new DataTable();
            m_dtZFS = new DataTable();
            long lngRes = 0;
            string strSQL;
            string strSQL1;
            if (m_strCheckManID == string.Empty)
            {
                if (m_strDeptID == string.Empty)
                {
//                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 1
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//        group by d.groupname_vchr";
                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 1
             and a.recdate_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
        group by d.groupname_vchr";
//                    strSQL1 = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 2
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//        group by d.groupname_vchr";
                    strSQL1 = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 2
             and a.recdate_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
        group by d.groupname_vchr";
                }
                else
                {
//                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d,
//                 t_bse_deptdesc e,
//                 t_bse_employee f,
//                 t_bse_deptemp g
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 1
//             and a.balance_dat  BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//             and a.balanceemp_chr = f.empid_chr
//             and f.empid_chr = g.empid_chr
//             and g.deptid_chr = e.deptid_chr
//             and e.deptid_chr = '" + m_strDeptID + @"'
//        group by d.groupname_vchr
  //";
                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d,
                 t_bse_deptdesc e,
                 t_bse_employee f,
                 t_bse_deptemp g
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 1
             and a.recdate_dat  BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
             and a.recemp_chr = f.empid_chr
             and f.empid_chr = g.empid_chr
             and g.deptid_chr = e.deptid_chr
             and e.deptid_chr = '" + m_strDeptID + @"'
        group by d.groupname_vchr";
//                    strSQL1 = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d,
//                 t_bse_deptdesc e,
//                 t_bse_employee f,
//                 t_bse_deptemp g
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 2
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//             and a.balanceemp_chr = f.empid_chr
//             and f.empid_chr = g.empid_chr
//             and g.deptid_chr = e.deptid_chr
//             and e.deptid_chr = '" + m_strDeptID + @"'
//        group by d.groupname_vchr
  //";
                    strSQL1 = @"select  decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d,
                 t_bse_deptdesc e,
                 t_bse_employee f,
                 t_bse_deptemp g
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 2
             and a.recdate_dat  BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                            AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
             and a.recemp_chr = f.empid_chr
             and f.empid_chr = g.empid_chr
             and g.deptid_chr = e.deptid_chr
             and e.deptid_chr = '" + m_strDeptID + @"'
        group by d.groupname_vchr";
                }

                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_dtZFS);
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1, ref m_dtFFS);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {

                if (m_strDeptID == string.Empty)
                {
//                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 1
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//             and a.balanceemp_chr = '" + m_strCheckManID + @"'
//        group by d.groupname_vchr";
                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 1
             and a.recdate_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
             and a.recemp_chr = '" + m_strCheckManID + @"'
        group by d.groupname_vchr";
//                    strSQL1 = @"select  decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 2
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//             and a.balanceemp_chr = '" + m_strCheckManID + @"'
//        group by d.groupname_vchr";
                    strSQL1 = @"select  decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 2
             and a.recdate_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
             and a.recemp_chr = '" + m_strCheckManID + @"'
        group by d.groupname_vchr";
                }
                else
                {
//                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d,
//                 t_bse_deptdesc e,
//                 t_bse_employee f,
//                 t_bse_deptemp g
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 1
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//             and a.balanceemp_chr = '" + m_strCheckManID + @"'
//             and a.balanceemp_chr = f.empid_chr
//             and f.empid_chr = g.empid_chr
//             and g.deptid_chr = e.deptid_chr
//             and e.deptid_chr = '" + m_strDeptID + @"'
//        group by d.groupname_vchr";
                    strSQL = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d,
                 t_bse_deptdesc e,
                 t_bse_employee f,
                 t_bse_deptemp g
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 1
             and a.recdate_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
             and a.recemp_chr = '" + m_strCheckManID + @"'
             and a.recemp_chr = f.empid_chr
             and f.empid_chr = g.empid_chr
             and g.deptid_chr = e.deptid_chr
             and e.deptid_chr = '" + m_strDeptID + @"'
        group by d.groupname_vchr";
//                    strSQL1 = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
//                                                2, -1,
//                                                1
//                                               )) as ����
//            from t_opr_outpatientrecipeinv a,
//                 t_opr_reciperelation b,
//                 t_opr_outpatientrecipe c,
//                 t_bse_groupdesc d,
//                 t_bse_deptdesc e,
//                 t_bse_employee f,
//                 t_bse_deptemp g
//           where a.outpatrecipeid_chr = b.seqid
//             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//             and c.recipeflag_int = 2
//             and a.balance_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
//                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
//             and c.groupid_chr = d.groupid_chr(+)
//             and a.balanceemp_chr = '" + m_strCheckManID + @"'
//             and a.balanceemp_chr = f.empid_chr
//             and f.empid_chr = g.empid_chr
//             and g.deptid_chr = e.deptid_chr
//             and e.deptid_chr = '" + m_strDeptID + @"'
//        group by d.groupname_vchr";
                    strSQL1 = @"select   decode(d.groupname_vchr,null,'δ������',d.groupname_vchr) as groupname_vchr, sum (decode (a.status_int,
                                                2, -1,
                                                1
                                               )) as ����
            from t_opr_charge a,
                 t_opr_reciperelation b,
                 t_opr_outpatientrecipe c,
                 t_bse_groupdesc d,
                 t_bse_deptdesc e,
                 t_bse_employee f,
                 t_bse_deptemp g
           where a.chargeno_chr = b.chargeno_chr
             and b.outpatrecipeid_chr = c.outpatrecipeid_chr
             and c.recipeflag_int = 2
             and a.recdate_dat BETWEEN TO_DATE ('" + BeginDate + @" 00:00:00', 'yyyy-mm-dd hh24:mi:ss')
                               AND TO_DATE ('" + EndDate + @" 23:59:59', 'yyyy-mm-dd hh24:mi:ss')
             and c.groupid_chr = d.groupid_chr(+)
             and a.recemp_chr = '" + m_strCheckManID + @"'
             and a.recemp_chr = f.empid_chr
             and f.empid_chr = g.empid_chr
             and g.deptid_chr = e.deptid_chr
             and e.deptid_chr = '" + m_strDeptID + @"'
        group by d.groupname_vchr";
                }

                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_dtZFS);
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1, ref m_dtFFS);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            return lngRes;
        }
        #endregion

        #region ���ݽ���ʱ��ͳ��רҵ�飭>ҽ����������
        /// <summary>
        /// ���ݽ���ʱ��ͳ��רҵ�飭>ҽ����������
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetSeeDoctorPersonNums(string m_strCheckManID,string m_strDeptID,string BeginDate, string EndDate, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            string strSQL = string.Empty;
            if (m_strCheckManID == string.Empty)
            {
                if (m_strDeptID != string.Empty)
                {
//                    strSQL = @"select   decode (d.groupname_vchr,
//                 null, 'δ������',
//                 d.groupname_vchr
//                ) as groupname_vchr,
//         sum (decode (e.status_int, 2, -1, 1)) as ��������,
//         sum (decode(e.type_int,2,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end),0)) as ����, 
//         sum (decode(e.type_int,2,0,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end))) as ���� 
//    from (select   a.balanceemp_chr, a.groupid_chr, a.patientid_chr,
//                   a.status_int,c.type_int
//              from t_opr_outpatientrecipeinv a,
//                   t_opr_reciperelation b,
//                   t_opr_outpatientrecipe c,
//                   t_bse_deptdesc e,
//                   t_bse_employee f,
//                   t_bse_deptemp g
//             where a.outpatrecipeid_chr = b.seqid
//     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//     and c.recipeflag_int = 1
//     and a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//                           and to_date ('" + EndDate + @" 23:59:59',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//     and a.balanceemp_chr = f.empid_chr
//     and f.empid_chr = g.empid_chr
//     and g.deptid_chr = e.deptid_chr
//     and e.deptid_chr = '" + m_strDeptID + @"'
//          group by a.balanceemp_chr,
//                   a.groupid_chr,
//                   a.patientid_chr,
//                   a.invdate_dat,
//                   a.status_int,c.type_int) e,
//         t_bse_groupdesc d
//   where e.groupid_chr = d.groupid_chr(+)
//group by d.groupname_vchr";
                    strSQL = @"select   decode (d.groupname_vchr,
                 null, 'δ������',
                 d.groupname_vchr
                ) as groupname_vchr,
         sum (decode (e.status_int, 2, -1, 1)) as ��������,
         sum (decode(e.type_int,2,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end),0)) as ����, 
         sum (decode(e.type_int,2,0,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end))) as ���� 
    from (select   a.recemp_chr, a.groupid_chr, a.patientid_chr,
                   a.status_int,c.type_int
              from t_opr_charge a,
                   t_opr_reciperelation b,
                   t_opr_outpatientrecipe c,
                   t_bse_deptdesc e,
                   t_bse_employee f,
                   t_bse_deptemp g
             where a.chargeno_chr = b.chargeno_chr
     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
     and c.recipeflag_int = 1
     and a.recdate_dat between to_date ('" + BeginDate + @" 00:00:00',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
                           and to_date ('" + EndDate + @" 23:59:59',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
     and a.recemp_chr = f.empid_chr
     and f.empid_chr = g.empid_chr
     and g.deptid_chr = e.deptid_chr
     and e.deptid_chr = '" + m_strDeptID + @"'
          group by a.recemp_chr,
                   a.groupid_chr,
                   a.patientid_chr,
                   a.operdate_dat,
                   a.status_int,c.type_int) e,
         t_bse_groupdesc d
   where e.groupid_chr = d.groupid_chr(+)
group by d.groupname_vchr";
                }
                else
                {
//                    strSQL = @"select   decode (d.groupname_vchr,
//                 null, 'δ������',
//                 d.groupname_vchr
//                ) as groupname_vchr,
//         sum (decode (e.status_int, 2, -1, 1)) as ��������,
//         sum (decode(e.type_int,2,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end),0)) as ����, 
//         sum (decode(e.type_int,2,0,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end))) as ���� 
//    from (select   a.balanceemp_chr, a.groupid_chr, a.patientid_chr,
//                   a.status_int,c.type_int
//              from t_opr_outpatientrecipeinv a,
//                   t_opr_reciperelation b,
//                   t_opr_outpatientrecipe c
//             where a.outpatrecipeid_chr = b.seqid
//     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//     and c.recipeflag_int = 1
//     and a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//                           and to_date ('" + EndDate + @" 23:59:59',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//          group by a.balanceemp_chr,
//                   a.groupid_chr,
//                   a.patientid_chr,
//                   a.invdate_dat,
//                   a.status_int,c.type_int) e,
//         t_bse_groupdesc d
//   where e.groupid_chr = d.groupid_chr(+)
//group by d.groupname_vchr";
                    strSQL = @"select   decode (d.groupname_vchr,
                 null, 'δ������',
                 d.groupname_vchr
                ) as groupname_vchr,
         sum (decode (e.status_int, 2, -1, 1)) as ��������,
         sum (decode(e.type_int,2,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end),0)) as ����, 
         sum (decode(e.type_int,2,0,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end))) as ���� 
    from (select   a.recemp_chr, a.groupid_chr, a.patientid_chr,
                   a.status_int,c.type_int
              from t_opr_charge a,
                   t_opr_reciperelation b,
                   t_opr_outpatientrecipe c
             where a.chargeno_chr = b.chargeno_chr
     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
     and c.recipeflag_int = 1
     and a.recdate_dat between to_date ('" + BeginDate + @" 00:00:00',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
                           and to_date ('" + EndDate + @" 23:59:59',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
          group by a.recemp_chr,
                   a.groupid_chr,
                   a.patientid_chr,
                   a.operdate_dat,
                   a.status_int,c.type_int) e,
         t_bse_groupdesc d
   where e.groupid_chr = d.groupid_chr(+)
group by d.groupname_vchr";
                }

                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
            }
            else
            {
                if (m_strDeptID != string.Empty)
                {
//                    strSQL = @"select   decode (d.groupname_vchr,
//                 null, 'δ������',
//                 d.groupname_vchr
//                ) as groupname_vchr,
//         sum (decode (a.status_int, 2, -1, 1)) as ��������
//     from t_opr_outpatientrecipeinv a,
//         t_opr_reciperelation b,
//         t_opr_outpatientrecipe c,
//         t_bse_groupdesc d,
//         t_bse_deptdesc e,
//         t_bse_employee f,
//         t_bse_deptemp g
//     where a.outpatrecipeid_chr = b.seqid
//     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//     and c.recipeflag_int = 1
//     and a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//                           and to_date ('" + EndDate + @" 23:59:59',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//     and c.groupid_chr = d.groupid_chr(+)
//     and a.balanceemp_chr = '" + m_strCheckManID + @"'
//     and a.balanceemp_chr = f.empid_chr
//     and f.empid_chr = g.empid_chr
//     and g.deptid_chr = e.deptid_chr
//     and e.deptid_chr = '" + m_strDeptID + @"'
//     group by d.groupname_vchr  ";

//                    strSQL = @"select   decode (d.groupname_vchr,
//                 null, 'δ������',
//                 d.groupname_vchr
//                ) as groupname_vchr,
//         sum (decode (e.status_int, 2, -1, 1)) as ��������,
//         sum (decode(e.type_int,2,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end),0)) as ����, 
//         sum (decode(e.type_int,2,0,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end))) as ���� 
//    from (select   a.balanceemp_chr, a.groupid_chr, a.patientid_chr,
//                   a.status_int,c.type_int
//              from t_opr_outpatientrecipeinv a,
//                   t_opr_reciperelation b,
//                   t_opr_outpatientrecipe c,
//                   t_bse_deptdesc e,
//                   t_bse_employee f,
//                   t_bse_deptemp g
//             where a.outpatrecipeid_chr = b.seqid
//     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//     and c.recipeflag_int = 1
//     and a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//                           and to_date ('" + EndDate + @" 23:59:59',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//      and a.balanceemp_chr = '" + m_strCheckManID + @"'
//     and a.balanceemp_chr = f.empid_chr
//     and f.empid_chr = g.empid_chr
//     and g.deptid_chr = e.deptid_chr
//     and e.deptid_chr = '" + m_strDeptID + @"'
//          group by a.balanceemp_chr,
//                   a.groupid_chr,
//                   a.patientid_chr,
//                   a.invdate_dat,
//                   a.status_int,c.type_int) e,
//         t_bse_groupdesc d
//   where e.groupid_chr = d.groupid_chr(+)
//group by d.groupname_vchr";
                    strSQL = @"select   decode (d.groupname_vchr,
                 null, 'δ������',
                 d.groupname_vchr
                ) as groupname_vchr,
         sum (decode (e.status_int, 2, -1, 1)) as ��������,
         sum (decode(e.type_int,2,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end),0)) as ����, 
         sum (decode(e.type_int,2,0,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end))) as ���� 
    from (select   a.recemp_chr, a.groupid_chr, a.patientid_chr,
                   a.status_int,c.type_int
              from t_opr_charge a,
                   t_opr_reciperelation b,
                   t_opr_outpatientrecipe c,
                   t_bse_deptdesc e,
                   t_bse_employee f,
                   t_bse_deptemp g
             where a.chargeno_chr = b.chargeno_chr
     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
     and c.recipeflag_int = 1
     and a.recdate_dat between to_date ('" + BeginDate + @" 00:00:00',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
                           and to_date ('" + EndDate + @" 23:59:59',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
      and a.recemp_chr = '" + m_strCheckManID + @"'
     and a.recemp_chr = f.empid_chr
     and f.empid_chr = g.empid_chr
     and g.deptid_chr = e.deptid_chr
     and e.deptid_chr = '" + m_strDeptID + @"'
          group by a.recemp_chr,
                   a.groupid_chr,
                   a.patientid_chr,
                   a.operdate_dat,
                   a.status_int,c.type_int) e,
         t_bse_groupdesc d
   where e.groupid_chr = d.groupid_chr(+)
group by d.groupname_vchr";
                }
                else
                {
//                    strSQL = @"select   decode (d.groupname_vchr,
//                 null, 'δ������',
//                 d.groupname_vchr
//                ) as groupname_vchr,
//         sum (decode (e.status_int, 2, -1, 1)) as ��������,
//         sum (decode(e.type_int,2,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end),0)) as ����, 
//         sum (decode(e.type_int,2,0,(case e.status_int 
//                                    when 2 
//                                    then -1
//                                    else 1
//                                    end))) as ���� 
//    from (select   a.balanceemp_chr, a.groupid_chr, a.patientid_chr,
//                   a.status_int,c.type_int
//              from t_opr_outpatientrecipeinv a,
//                   t_opr_reciperelation b,
//                   t_opr_outpatientrecipe c
//             where a.outpatrecipeid_chr = b.seqid
//     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
//     and c.recipeflag_int = 1
//     and a.balanceemp_chr = '" + m_strCheckManID + @"'
//     and a.balance_dat between to_date ('" + BeginDate + @" 00:00:00',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//                           and to_date ('" + EndDate + @" 23:59:59',
//                                        'yyyy-mm-dd hh24:mi;ss'
//                                       )
//          group by a.balanceemp_chr,
//                   a.groupid_chr,
//                   a.patientid_chr,
//                   a.invdate_dat,
//                   a.status_int,
//                   c.type_int) e,
//         t_bse_groupdesc d
//   where e.groupid_chr = d.groupid_chr(+)
//group by d.groupname_vchr";
                    strSQL = @"select   decode (d.groupname_vchr,
                 null, 'δ������',
                 d.groupname_vchr
                ) as groupname_vchr,
         sum (decode (e.status_int, 2, -1, 1)) as ��������,
         sum (decode(e.type_int,2,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end),0)) as ����, 
         sum (decode(e.type_int,2,0,(case e.status_int 
                                    when 2 
                                    then -1
                                    else 1
                                    end))) as ���� 
    from (select   a.recemp_chr, a.groupid_chr, a.patientid_chr,
                   a.status_int,c.type_int
              from t_opr_charge a,
                   t_opr_reciperelation b,
                   t_opr_outpatientrecipe c
             where a.chargeno_chr = b.chargeno_chr
     and b.outpatrecipeid_chr = c.outpatrecipeid_chr
     and c.recipeflag_int = 1
     and a.recemp_chr = '" + m_strCheckManID + @"'
     and a.recdate_dat between to_date ('" + BeginDate + @" 00:00:00',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
                           and to_date ('" + EndDate + @" 23:59:59',
                                        'yyyy-mm-dd hh24:mi;ss'
                                       )
          group by a.recemp_chr,
                   a.groupid_chr,
                   a.patientid_chr,
                   a.operdate_dat,
                   a.status_int,
                   c.type_int) e,
         t_bse_groupdesc d
   where e.groupid_chr = d.groupid_chr(+)
group by d.groupname_vchr";
                }

                try
                {

                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

            }
            return lngRes;
        }
        #endregion

        #region ��ȡ�����ֶε���
        [AutoComplete]
		public long m_mthReportColumns(out DataTable dt,string strEx)
		{
			dt =new DataTable();
			long lngRes=0;
			if(strEx.Trim()=="")
			{
				strEx ="0066";
			}
			string strSQL = @"Select * From T_AID_RPT_GOP_DEF  where RPTID_CHR = '"+strEx+"' order by GROUPID_CHR";
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				
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
		#region ��������������ҩ���
		[AutoComplete]
		public long m_mthGetUsingMedicine(int Flag,out DataTable dt,string strID,DateTime date,DateTime date2,string strEx)
		{
			dt =new DataTable();
			long lngRes=0;
			string strSubSQL ="";
			if(Flag ==1)
			{
			strSubSQL="	AND B.DIAGDR_CHR ='"+strID+"'"; 
			}
			if(Flag ==2)
			{
				strSubSQL="AND	B.DIAGDEPT_CHR ='"+strID+"'"; 
			}
			string strSQL = @"SELECT   *   FROM (SELECT a.*, b.itemname_vchr, b.itemcode_vchr,b.ITEMSPEC_VCHR
  FROM (SELECT   a.itemid_chr, a.unitprice_mny, a.unitid_chr,
                 SUM (a.tolqty_dec) AS COUNT, SUM (a.tolprice_mny)
                                                                  AS summoney
            FROM t_opr_outpatientpwmrecipede a, t_opr_outpatientrecipe b
           WHERE a.outpatrecipeid_chr = b.outpatrecipeid_chr
             AND b.pstauts_int = 2
            "+strSubSQL+@"
             AND b.RECORDDATE_DAT BETWEEN TO_DATE('"+date.ToString("yyyy-MM-dd 00:00:00")+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+date2.ToString("yyyy-MM-dd 23:59:59")+@" ','yyyy-mm-dd hh24:mi:ss')
        GROUP BY a.itemid_chr, a.unitprice_mny, a.unitid_chr) a,
       t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+)
UNION
SELECT a.*, b.itemname_vchr, b.itemcode_vchr,b.ITEMSPEC_VCHR
  FROM (SELECT   a.itemid_chr, a.unitprice_mny, a.unitid_chr,
                 SUM (a.qty_dec) AS COUNT, SUM (a.tolprice_mny) AS summoney
            FROM t_opr_outpatientcmrecipede a, t_opr_outpatientrecipe b
           WHERE a.outpatrecipeid_chr = b.outpatrecipeid_chr
             AND b.pstauts_int = 2
              "+strSubSQL+@"
			 AND b.RECORDDATE_DAT BETWEEN TO_DATE('"+date.ToString("yyyy-MM-dd 00:00:00")+"','yyyy-mm-dd hh24:mi:ss') "+
				" AND TO_DATE('"+date2.ToString("yyyy-MM-dd 23:59:59")+@" ','yyyy-mm-dd hh24:mi:ss')
        GROUP BY a.itemid_chr, a.unitprice_mny, a.unitid_chr) a,
       t_bse_chargeitem b
 WHERE a.itemid_chr = b.itemid_chr(+)) ORDER BY itemcode_vchr";
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				
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

		#region �����¼�¼����ʿִ�м�¼��
		/// <summary>
		/// �����¼�¼����ʿִ�м�¼��
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strRecordID"></param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddNewToT_opr_nurseexecute(System.Security.Principal.IPrincipal p_objPrincipal,out string p_strRecordID,clst_opr_nurseexecute p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngAddNewToT_opr_nurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            //lngRes = objHRPSvc.m_lngGenerateNewID("t_opr_nurseexecute","SEQ_INT",out p_strRecordID);
            //if(lngRes < 0)
            //    return lngRes;
                      

            //����ID
            DataTable dt = new DataTable();
            string SQL = @"select seq_nurseexecuteid.nextval
  from dual
";
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQL, ref dt);
            if (lngRes > 0)
            {
                p_strRecordID = dt.Rows[0][0].ToString();
            } 

			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"insert into t_opr_nurseexecute
            (seq_int, business_int, tablename_vchr, outpatrecipeid_chr,
             rowno_chr, itemid_chr, exectimes_int, operatortype_int,
             operatorid_chr, exectime_dat, systime_dat, remark1_vchr,
             remark2_vchr, status_int
            )
     values (?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?, ?, ?,
             ?, ?
            )";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(14,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = Convert.ToInt32(p_strRecordID);
				objLisAddItemRefArr[1].Value = p_objRecord.m_intBUSINESS_INT;
				objLisAddItemRefArr[2].Value = p_objRecord.m_strTABLENAME_VCHR.Trim();
				objLisAddItemRefArr[3].Value = p_objRecord.m_strOUTPATRECIPEID_CHR.Trim();
				objLisAddItemRefArr[4].Value = p_objRecord.m_strROWNO_CHR.Trim();
				objLisAddItemRefArr[5].Value = p_objRecord.m_strITEMID_CHR.Trim();
				objLisAddItemRefArr[6].Value = p_objRecord.m_intEXECTIMES_INT;
				objLisAddItemRefArr[7].Value = p_objRecord.m_intOPERATORTYPE_INT;
				objLisAddItemRefArr[8].Value = p_objRecord.m_strOPERATORID_CHR.Trim();
				objLisAddItemRefArr[9].Value = DateTime.Parse(p_objRecord.m_strEXECTIME_DAT);
				objLisAddItemRefArr[10].Value = DateTime.Parse(strDateTime);
				objLisAddItemRefArr[11].Value = p_objRecord.m_strREMARK1_VCHR.Trim();
				objLisAddItemRefArr[12].Value = p_objRecord.m_strREMARK2_VCHR.Trim();
				objLisAddItemRefArr[13].Value = p_objRecord.m_intSTATUS_INT;
				long lngRecEff = -1;
				//�������Ӽ�¼
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

		#region ����������¼����ʿִ�м�¼��
		/// <summary>
		/// ����������¼����ʿִ�м�¼��
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsDataArr"></param>
		/// <param name="p_strRecordIDArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddNewToT_opr_nurseexecute(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute[] p_clsDataArr,out string[] p_strRecordIDArr)
		{
			long lngRes=0;
			int[] intCountArr = new int[p_clsDataArr.Length];
			p_strRecordIDArr = new string[p_clsDataArr.Length];
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngAddNewToT_opr_nurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			int intCount = -1;
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				for(int i=0;i<p_clsDataArr.Length; ++i)
				{

				//��ִ�д���
				lngRes = m_lngQueryEXECTIMES_INT(p_objPrincipal,p_clsDataArr[i],out intCount);
				if(lngRes>0)
				{
					if(intCount>0)//����,
					{
						p_clsDataArr[i].m_intEXECTIMES_INT = intCount+1;
					}
					else//��һ��
					{
						p_clsDataArr[i].m_intEXECTIMES_INT = 1;
					}
				lngRes=	m_lngAddNewToT_opr_nurseexecute(p_objPrincipal,out p_strRecordIDArr[i],p_clsDataArr[i]);
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

		#region �������¼�¼����ʿִ�м�¼��
		/// <summary>
		/// �������¼�¼����ʿִ�м�¼��
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsDataArr"></param>
		/// <param name="p_strRecordIDArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpdateMoreT_opr_nurseexecute(System.Security.Principal.IPrincipal p_objPrincipal,int p_intRecordID,clst_opr_nurseexecute p_clsTempData)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngUpdateMoreT_opr_nurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				clst_opr_nurseexecute p_clsData = null;
				DataTable dt = null;
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = m_lngQueryByID(p_objPrincipal,out p_clsData,p_intRecordID);
				if(lngRes>0)
				{
					lngRes = m_lngQueryID(p_objPrincipal,p_clsData,out dt);
					if(lngRes>0)
					{
//						#region ��Ҫ���µ�����
//						p_clsData.m_strEXECTIME_DAT = p_clsTempData.m_strEXECTIME_DAT ;
//						p_clsData.m_strREMARK1_VCHR = p_clsTempData.m_strREMARK1_VCHR;
//						p_clsData.m_intOPERATORTYPE_INT = p_clsTempData.m_intOPERATORTYPE_INT ;//����������
//						p_clsData.m_strOPERATORID_CHR = p_clsTempData.m_strOPERATORID_CHR ;
//						#endregion 
//						lngRes = m_lngUpdateStateT_opr_nurseexecute(p_objPrincipal,p_intRecordID,p_clsData);
						for(int i=0;i<dt.Rows.Count; ++i)
						{
							if(dt.Rows[i]["SYSTIME_DAT"].ToString().Trim()== p_clsData.m_strSYSTIME_DAT.ToString().Trim())
							{
								p_intRecordID = Convert.ToInt32(dt.Rows[i]["SEQ_INT"].ToString().Trim());
								lngRes = m_lngQueryByID(p_objPrincipal,out p_clsData,p_intRecordID);
								#region ��Ҫ���µ�����
								p_clsData.m_strEXECTIME_DAT = p_clsTempData.m_strEXECTIME_DAT ;
								p_clsData.m_strREMARK1_VCHR = p_clsTempData.m_strREMARK1_VCHR;
								p_clsData.m_intOPERATORTYPE_INT = p_clsTempData.m_intOPERATORTYPE_INT ;//����������
								p_clsData.m_strOPERATORID_CHR = p_clsTempData.m_strOPERATORID_CHR ;
								#endregion 
								lngRes =m_lngUpdateStateT_opr_nurseexecute(p_objPrincipal,p_intRecordID,p_clsData);
							}
						}
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

		#region ����ȡID
		/// <summary>
		/// ����ȡID
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryID(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute p_clsData,out DataTable p_dt)
		{
			long lngRes=0; 
			p_dt = null;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngQueryID");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string sql = @"SELECT *
										FROM t_opr_nurseexecute
										WHERE business_int ="+p_clsData.m_intBUSINESS_INT+@" 
										AND outpatrecipeid_chr ='"+p_clsData.m_strOUTPATRECIPEID_CHR.Trim()+@"'
										AND rowno_chr = '"+p_clsData.m_strROWNO_CHR.Trim()+@"'

										AND operatortype_int ="+p_clsData.m_intOPERATORTYPE_INT +@"
										AND status_int = 1 ";
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql,ref p_dt);

				if(lngRes>0)
				{
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

		#region ��ѯִ�д���
		/// <summary>
		/// ��ѯִ�д���
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryEXECTIMES_INT(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute p_clsData,out int p_strEXECTIMES_INT)
		{
			long lngRes=0;
			p_strEXECTIMES_INT = 0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngQueryEXECTIMES_INT");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				DataTable objDt = null;
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string sql = @"SELECT max(exectimes_int) as exectimes_int
										FROM t_opr_nurseexecute
										WHERE business_int ="+p_clsData.m_intBUSINESS_INT+@" 
										AND outpatrecipeid_chr ='"+p_clsData.m_strOUTPATRECIPEID_CHR.Trim()+@"'
										AND rowno_chr = '"+p_clsData.m_strROWNO_CHR.Trim()+@"'
										AND itemid_chr = '"+p_clsData.m_strITEMID_CHR.Trim()+@"'
										AND operatortype_int ="+p_clsData.m_intOPERATORTYPE_INT +@"
										AND status_int = 1 ";
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql,ref objDt);

				if(lngRes>0)
				{
					if(objDt.Rows.Count>0)
					{
						string str = objDt.Rows[0][0].ToString().Trim();
						if(str != "")
							p_strEXECTIMES_INT = Convert.ToInt32(str);
						else
							p_strEXECTIMES_INT = 0;
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

		#region ��ѯǩ���б�
		/// <summary>
		/// ��ѯǩ���б�
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryOPERATORID_CHRAndName(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute p_clsData,out DataTable p_dtbData,bool p_blnAll)
		{
			long lngRes=0;
			p_dtbData = null;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngQueryOPERATORID_CHRAndName");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string sql = "";
				if(p_blnAll)//������
				{
					sql = @"SELECT    A.SEQ_INT,A.OPERATORID_CHR,B.LASTNAME_VCHR,A.EXECTIME_DAT,A.OPERATORTYPE_INT 
										FROM t_opr_nurseexecute A,t_bse_employee B
										WHERE A.OPERATORID_CHR = B.EMPID_CHR(+) 
										AND B.Status_int=1 
										AND A.status_int = 1 ORDER BY A.SYSTIME_DAT DESC";
				}
				else
				{
				 sql = @"SELECT  A.SEQ_INT,A.OPERATORID_CHR,B.LASTNAME_VCHR,A.EXECTIME_DAT,A.OPERATORTYPE_INT 
										FROM t_opr_nurseexecute A,t_bse_employee B
										WHERE A.OPERATORID_CHR = B.EMPID_CHR(+) 
										AND B.Status_int=1 
										AND A.business_int ="+p_clsData.m_intBUSINESS_INT+@" 
										AND A.outpatrecipeid_chr ='"+p_clsData.m_strOUTPATRECIPEID_CHR.Trim()+@"'
										AND A.rowno_chr = '"+p_clsData.m_strROWNO_CHR.Trim()+@"'
										AND A.itemid_chr = '"+p_clsData.m_strITEMID_CHR.Trim()+@"'
										AND A.status_int = 1 ORDER BY A.SYSTIME_DAT DESC";
				}
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql,ref p_dtbData);		
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

		#region ��ѯǩ��
		/// <summary>
		/// ��ѯǩ��
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryByID(System.Security.Principal.IPrincipal p_objPrincipal,out clst_opr_nurseexecute p_clsData,int p_intID )
		{
			long lngRes=0;
			p_clsData = null;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngQueryByID");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string sql = @"SELECT *	FROM t_opr_nurseexecute WHERE SEQ_INT ="+p_intID;
				DataTable dt = new DataTable();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql,ref dt);		
				if(lngRes>0)
				{
					p_clsData = new clst_opr_nurseexecute();
					if(dt.Rows.Count>0)
					{					
						p_clsData.m_intSEQ_INT = Convert.ToInt32(dt.Rows[0]["SEQ_INT"].ToString().Trim());
						p_clsData.m_intBUSINESS_INT  = Convert.ToInt32(dt.Rows[0]["BUSINESS_INT"].ToString().Trim());
						p_clsData.m_strTABLENAME_VCHR  = dt.Rows[0]["TABLENAME_VCHR"].ToString().Trim();
						p_clsData.m_strOUTPATRECIPEID_CHR  = dt.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
						p_clsData.m_strROWNO_CHR  = dt.Rows[0]["ROWNO_CHR"].ToString().Trim();
						p_clsData.m_strITEMID_CHR  = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
						p_clsData.m_intEXECTIMES_INT  = Convert.ToInt32(dt.Rows[0]["EXECTIMES_INT"].ToString().Trim());
						p_clsData.m_intOPERATORTYPE_INT  = Convert.ToInt32(dt.Rows[0]["OPERATORTYPE_INT"].ToString().Trim());
						p_clsData.m_strOPERATORID_CHR  = dt.Rows[0]["OPERATORID_CHR"].ToString().Trim();
						p_clsData.m_strEXECTIME_DAT  = dt.Rows[0]["EXECTIME_DAT"].ToString().Trim();
						p_clsData.m_strSYSTIME_DAT  = dt.Rows[0]["SYSTIME_DAT"].ToString().Trim();
						p_clsData.m_strREMARK1_VCHR  = dt.Rows[0]["REMARK1_VCHR"].ToString().Trim();
						p_clsData.m_strREMARK2_VCHR  = dt.Rows[0]["REMARK2_VCHR"].ToString().Trim();
						p_clsData.m_intSTATUS_INT  = Convert.ToInt32( dt.Rows[0]["STATUS_INT"].ToString().Trim());
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

		#region ���ϼ�¼����ʿִ�м�¼��ĳ�ֶ�,������һ����¼
		/// <summary>
		/// ���ϼ�¼����ʿִ�м�¼��ĳ�ֶβ�����һ����¼
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strRecordID"></param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngUpdateStateT_opr_nurseexecute(System.Security.Principal.IPrincipal p_objPrincipal, int p_intRecordID,clst_opr_nurseexecute p_clsData)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngUpdateStateT_opr_nurseexecute");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = "UPDATE t_opr_nurseexecute SET status_int=-1 WHERE seq_int=?";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(1,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_intRecordID;
				long lngRecEff = -1;
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				if(lngRes>0)
				{
					string strID = "";
					lngRes = m_lngAddNewToT_opr_nurseexecute(p_objPrincipal,out strID,p_clsData);
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

        /// <summary>
        /// ���ϼ�¼����ʿִ�м�¼
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateStateT_opr_nurseexecute(System.Security.Principal.IPrincipal p_objPrincipal, clst_opr_nurseexecute p_clsData)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc", "m_lngUpdateStateT_opr_nurseexecute");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSQL = "UPDATE t_opr_nurseexecute SET status_int=-1 ";
            strSQL += @"		WHERE business_int =" + p_clsData.m_intBUSINESS_INT + @" 
										AND outpatrecipeid_chr ='" + p_clsData.m_strOUTPATRECIPEID_CHR.Trim() + @"'
										AND rowno_chr = '" + p_clsData.m_strROWNO_CHR.Trim() + @"'

										AND operatortype_int =" + p_clsData.m_intOPERATORTYPE_INT + @"
										AND status_int = 1  
                                        AND SYSTIME_DAT=to_date('" + p_clsData.m_strSYSTIME_DAT+"','yyyy-MM-dd hh24:mi:ss')";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
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

		#region ��ѯǩ����������
		/// <summary>
		/// ��ѯǩ���������� 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryOPERATORID_CHRAndNameByType(System.Security.Principal.IPrincipal p_objPrincipal,clst_opr_nurseexecute p_clsData,out DataTable p_dtbData)
		{
			long lngRes=0;
			p_dtbData = null;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngQueryOPERATORID_CHRAndNameByType");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string		sql = @"SELECT  A.SEQ_INT,A.OPERATORID_CHR,B.LASTNAME_VCHR,A.EXECTIME_DAT,A.OPERATORTYPE_INT 
										FROM t_opr_nurseexecute A,t_bse_employee B
										WHERE A.OPERATORID_CHR = B.EMPID_CHR(+) 
										AND B.Status_int=1 
										AND A.business_int ="+p_clsData.m_intBUSINESS_INT+@" 
										AND A.outpatrecipeid_chr ='"+p_clsData.m_strOUTPATRECIPEID_CHR.Trim()+@"'
										AND A.rowno_chr = '"+p_clsData.m_strROWNO_CHR.Trim()+@"'
										
										AND A.status_int = 1 ORDER BY A.SYSTIME_DAT DESC";
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql,ref p_dtbData);		
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

		/// <summary>
		/// ��ѯǩ��(�����ε�,)
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryNameBybusiness_intAndrecipeid(System.Security.Principal.IPrincipal p_objPrincipal,int p_business_int,string p_outpatrecipeid_chr,int p_intOPERATORTYPE_INT,out DataTable p_dtbData)
		{
			long lngRes=0;
			p_dtbData = null;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsWaitDiagListManageSvc","m_lngQueryNameToCure");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string		sql = @"SELECT  A.SEQ_INT,A.OPERATORID_CHR,B.LASTNAME_VCHR,A.EXECTIME_DAT,A.OPERATORTYPE_INT 
										FROM t_opr_nurseexecute A,t_bse_employee B
										WHERE A.OPERATORID_CHR = B.EMPID_CHR(+) 
										AND B.Status_int=1 
										AND A.business_int ="+p_business_int+@" 
										AND A.outpatrecipeid_chr ='"+p_outpatrecipeid_chr+@"'
										AND A.OPERATORTYPE_INT="+p_intOPERATORTYPE_INT+@"
										
										AND A.status_int = 1 ORDER BY A.SYSTIME_DAT asc";
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql,ref p_dtbData);		
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


		/// <summary>
		/// ��ѯǩ��,����Ѳ�ӵ���ӡ����ǩ��
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_clsData"></param>
		/// <param name="p_strEXECTIMES_INT"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngQueryNameXUNSHI(clst_opr_nurseexecute p_clsData
			,out string p_strName1,out string p_strName2,out string p_strName3
			,out string p_strREMARK1_VCHR,out string p_strREMARK1_VCHR2
			,out string p_strREMARK1_VCHR3,out string p_strEXECTIME_DAT
			,out string p_strEXECTIME_DAT2,out string p_strEXECTIME_DAT3)
		{
			long lngRes=0;
			p_strName1 = "";
			p_strName2 = "";
			p_strName3 = "";
			p_strREMARK1_VCHR = "";
			p_strEXECTIME_DAT = "";
			p_strREMARK1_VCHR2 = "";
			p_strEXECTIME_DAT2 = "";
			p_strREMARK1_VCHR3 = "";
			p_strEXECTIME_DAT3 = "";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				string		sql = @"SELECT  A.REMARK1_VCHR,A.SEQ_INT,A.OPERATORID_CHR,B.LASTNAME_VCHR,A.EXECTIME_DAT,A.OPERATORTYPE_INT 
										FROM t_opr_nurseexecute A,t_bse_employee B
										WHERE A.OPERATORID_CHR = B.EMPID_CHR(+) 
										AND B.Status_int=1 
										AND A.business_int ="+p_clsData.m_intBUSINESS_INT+@" 
										AND A.outpatrecipeid_chr ='"+p_clsData.m_strOUTPATRECIPEID_CHR.Trim()+@"'
										AND A.rowno_chr = '"+p_clsData.m_strROWNO_CHR.Trim()+@"'
										
										AND A.status_int = 1 ";
				string strOPERATORTYPE_INT1 = " AND A.OPERATORTYPE_INT=4 ORDER BY A.SYSTIME_DAT DESC";//Ѳ��1
				string strOPERATORTYPE_INT2 = " AND A.OPERATORTYPE_INT=5 ORDER BY A.SYSTIME_DAT DESC";//Ѳ��2
				string strOPERATORTYPE_INT3 = " AND A.OPERATORTYPE_INT=6 ORDER BY A.SYSTIME_DAT DESC";//Ѳ��3
				DataTable dtbData = new DataTable();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql+strOPERATORTYPE_INT1,ref dtbData);		
				if(lngRes>0)
				{
					if(dtbData.Rows.Count>0)
					{
						p_strName1 = dtbData.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
						p_strREMARK1_VCHR = dtbData.Rows[0]["REMARK1_VCHR"].ToString().Trim();
						p_strEXECTIME_DAT = Convert.ToDateTime(dtbData.Rows[0]["EXECTIME_DAT"]).ToString("yyyy-MM-dd HH:mm");
					}
					lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql+strOPERATORTYPE_INT2,ref dtbData);
					if(lngRes>0)
					{
						if(dtbData.Rows.Count>0)
						{
								p_strName2 = dtbData.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
							p_strREMARK1_VCHR2 = dtbData.Rows[0]["REMARK1_VCHR"].ToString().Trim();
							p_strEXECTIME_DAT2 = Convert.ToDateTime(dtbData.Rows[0]["EXECTIME_DAT"]).ToString("yyyy-MM-dd HH:mm");
						}
							lngRes = objHRPSvc.lngGetDataTableWithoutParameters(sql+strOPERATORTYPE_INT3,ref dtbData);
							if(lngRes>0)
							{
								if(dtbData.Rows.Count>0)
								{
									p_strName3 = dtbData.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
									p_strREMARK1_VCHR3 = dtbData.Rows[0]["REMARK1_VCHR"].ToString().Trim();
									p_strEXECTIME_DAT3 = Convert.ToDateTime(dtbData.Rows[0]["EXECTIME_DAT"]).ToString("yyyy-MM-dd HH:mm");
								}
							}
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
	}

}
