using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace  com.digitalwave.iCare.middletier.HIS 
{
	/// <summary>
	/// 药房窗口配置关系
	/// Create by xgpeng 2006-02-15
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsMedSendConfigRelation_SVC : clsMiddleTierBase
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsMedSendConfigRelation_SVC()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 获得药房信息(名称)   
		/// <summary>
		/// 获得药房信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_dtable"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedStoreInfo(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable p_dtable)
		{
			long lngRes = 0;
			p_dtable=new DataTable();

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc","m_lngGetMedStoreInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"select e.medstoreid_chr,e.medstorename_vchr from t_bse_medstore e    where  e.medstoretype_int in (1, 3)";
			      
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtable);
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

		#region 根据药房ID获取药房窗口信息   
		/// <summary>
		/// 根据药房ID获取药房窗口信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_TypeID">窗口ID</param>
		/// <param name="flage">0-发药窗口 ; 1-配药窗口</param>
		/// <param name="p_objResArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedWindowInfo(System.Security.Principal.IPrincipal p_objPrincipal,string p_TypeID,int flage,out clsOPMedStoreWin_VO[] p_objResArr)
		{
			long lngRes = 0;
			p_objResArr=new clsOPMedStoreWin_VO[0];
			DataTable p_dtRes=new DataTable();

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc","m_lngGetMedWindowInfo");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL =@"select a.windowid_chr,a.windowname_vchr,a.medstoreid_chr,a.windowtype_int,a.workstatus_int,b.medstorename_vchr from T_BSE_MEDSTOREWIN a,T_bse_medStore b
            where a.medstoreid_chr=b.medstoreid_chr and a.windowtype_int=? and b.medstoreid_chr=? order by a.medstoreid_chr,a.windowname_vchr";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
			
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = flage;
                paramArr[1].Value = p_TypeID.Trim();
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtRes, paramArr);
				objHRPSvc.Dispose();
				if(lngRes>0 && p_dtRes != null)
				{
					int intRow = p_dtRes.Rows.Count;
					if(intRow>0)
					{
						p_objResArr = new clsOPMedStoreWin_VO[intRow];
						for(int i=0;i<intRow;i++)
						{
							p_objResArr[i] = new clsOPMedStoreWin_VO();
							p_objResArr[i].m_strWindowID = p_dtRes.Rows[i]["windowid_chr"].ToString().Trim();
							p_objResArr[i].m_strWindowName = p_dtRes.Rows[i]["windowname_vchr"].ToString().Trim();
							p_objResArr[i].m_intWindowType = Convert.ToInt32(p_dtRes.Rows[i]["windowtype_int"].ToString().Trim());
							p_objResArr[i].m_intWorkStatus = Convert.ToInt32(p_dtRes.Rows[i]["workstatus_int"].ToString().Trim());
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

		#region 根据配药窗口ID获取配药窗口->发药窗口 信息   
		/// <summary>
		/// 根据配药窗口ID获取配药窗口->发药窗口 信息 
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_WinID">配药窗口ID</param>
		/// <param name="p_objResArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetMedWinByID(System.Security.Principal.IPrincipal p_objPrincipal,string p_WinID,out clsMedSendConfig_VO[] p_objResArr)
		{
			long lngRes = 0;
			p_objResArr=new clsMedSendConfig_VO[0];
			DataTable p_dtRes=new DataTable();

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc","m_lngGetMedWinByID");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL =@" select c.seq_int,c.treatwinid_chr,c.givewinid_chr,c.order_int,d.windowname_vchr  
 from T_OPR_MEDSTOREWINRLT c ,T_BSE_MEDSTOREWIN d
 where c.givewinid_chr=d.windowid_chr(+) and c.treatwinid_chr='"+p_WinID.Trim()+"' order by  c.order_int";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtRes);
				objHRPSvc.Dispose();
				if(lngRes>0 && p_dtRes != null)
				{
					int intRow = p_dtRes.Rows.Count;
					if(intRow>0)
					{
						p_objResArr = new clsMedSendConfig_VO[intRow];
						for(int i=0;i<intRow;i++)
						{
							p_objResArr[i] = new clsMedSendConfig_VO();
							p_objResArr[i].m_intSeq= Convert.ToInt32(p_dtRes.Rows[i]["seq_int"].ToString().Trim());
							p_objResArr[i].m_TreatWinID_chr = p_dtRes.Rows[i]["treatwinid_chr"].ToString().Trim();
							p_objResArr[i].m_GiveWinID_chr = p_dtRes.Rows[i]["givewinid_chr"].ToString().Trim();
							p_objResArr[i].m_intOrder = Convert.ToInt32(p_dtRes.Rows[i]["order_int"].ToString().Trim());
							p_objResArr[i].m_strGiveWinName = p_dtRes.Rows[i]["windowname_vchr"].ToString().Trim();
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

		#region 新增 配药窗口->发药窗口 关系
		/// <summary>
		/// 新增 配药窗口->发药窗口 关系
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_intSeq"></param>
		/// <param name="p_objWinArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddMedSendGiveRelation(System.Security.Principal.IPrincipal p_objPrincipal,out int p_intSeq,
			clsMedSendConfig_VO p_objWinArr)
		{
			long lngRes = 0;	
			p_intSeq=0;//流水号
      
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngAddMedSendGiveRelation");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				p_intSeq =Convert.ToInt32( objHRPSvc.m_strGetNewID("T_OPR_MEDSTOREWINRLT","SEQ_INT",6));

                string strSQL = @"INSERT INTO T_OPR_MEDSTOREWINRLT
										  (SEQ_INT, TREATWINID_CHR, GIVEWINID_CHR,
										   ORDER_INT
										  )
								  VALUES (?,?,?,?)";
				

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = p_intSeq;
                paramArr[1].Value = p_objWinArr.m_TreatWinID_chr;
                paramArr[2].Value = p_objWinArr.m_GiveWinID_chr;
                paramArr[3].Value = p_objWinArr.m_intOrder;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
		

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

		#region 删除 配药窗口->发药窗口 关系
		/// <summary>
		/// 删除药房排班信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_intID"></param>
		/// <returns></returns>
		[AutoComplete]			
		public long m_thDelMedSendGiveRelation(System.Security.Principal.IPrincipal p_objPrincipal,int p_intID)
		{
			long lngRes = 0;	
			
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc","m_thDelMedSendGiveRelation");
			if(lngRes < 0)
			{
				return -1;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				string strSQL = @"delete T_OPR_MEDSTOREWINRLT  where SEQ_INT="+p_intID+"";
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

		#region 保存 批量移动记录
		/// <summary>
		/// 保存 批量移动记录
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objWinArr"></param>
		/// <returns></returns>
		[AutoComplete]			
		public long m_lngUpdateMovRecord(System.Security.Principal.IPrincipal p_objPrincipal,clsMedSendConfig_VO[] p_objWinArr)
		{
			long lngRes = 0;	
			
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc","m_thDelMedSendGiveRelation");
			
			if(lngRes < 0)
			{
				return -1;
			}

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				for(int i1=0;i1<p_objWinArr.Length;++i1)
				{
					string strSQL = @"update T_OPR_MEDSTOREWINRLT set ORDER_INT=? where SEQ_INT=? ";
					
                    System.Data.IDataParameter[] paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                    paramArr[0].Value = p_objWinArr[i1].m_intOrder;
                    paramArr[1].Value = p_objWinArr[i1].m_intSeq;
                    long lngRecordsAffected = -1;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 获得窗口队列信息（根据药房ID以及窗口类型） 2006-2-20
        /// <summary>
        /// 获得窗口队列信息（根据药房ID以及窗口类型）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strID">药房ID</param>
        /// <param name="flage">窗口类型 0-发药窗口 1-配药窗口,</param>
        /// <param name="p_DataTableQueue"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWinQueueByMedStoreID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strID, int flage, DateTime p_dtimeBegin, DateTime p_dtimeEnd, out DataTable p_DataTableQueue)
        {
            long lngRes = 0;
            p_DataTableQueue = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_thDelMedSendGiveRelation");

            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                string strSQL;

    strSQL = @"SELECT distinct  g.seq_int, f.windowid_chr, f.windowname_vchr, g.lastname_vchr,
         g.sex_chr, g.order_int
    FROM 
      (  select  b.seq_int,b.windowid_chr,b.medstoreid_chr,b.order_int,t.lastname_vchr,t.sex_chr
      from t_opr_outpatientrecipeinv h, t_bse_patient t,t_opr_outpatientrecipe a,t_opr_medstorewinque b
      where  t.patientid_chr = a.patientid_chr and  h.outpatrecipeid_chr=b.outpatrecipeid_chr and b.outpatrecipeid_chr=a.outpatrecipeid_chr  and h.recorddate_dat between to_Date(?,'yyyy-MM-dd hh24:mi:ss') and to_Date(?,'yyyy-MM-dd hh24:mi:ss') ) g,(SELECT   e.windowid_chr, e.windowname_vchr,
                 CASE
                    WHEN e.windowname_vchr LIKE '一%'
                       THEN 1
                    WHEN e.windowname_vchr LIKE '二%'
                       THEN 2
                    WHEN e.windowname_vchr LIKE '三%'
                       THEN 3
                    WHEN e.windowname_vchr LIKE '四%'
                       THEN 4
                    WHEN e.windowname_vchr LIKE '五%'
                       THEN 5
                    WHEN e.windowname_vchr LIKE '六%'
                       THEN 6
                    WHEN e.windowname_vchr LIKE '七%'
                       THEN 7
                    WHEN e.windowname_vchr LIKE '八%'
                       THEN 8
                    WHEN e.windowname_vchr LIKE '九%'
                       THEN 9
                    WHEN e.windowname_vchr LIKE '十%'
                       THEN 10
                 END AS ord
            FROM  t_bse_medstorewin e 
           WHERE e.medstoreid_chr=? and e.windowtype_int=?) f  WHERE  g.windowid_chr(+) = f.windowid_chr ORDER BY f.ord, g.order_int";


   

               System.Data.IDataParameter[] paramArr = null;
               objHRPSvc.CreateDatabaseParameter(4, out paramArr);
               paramArr[0].Value = p_dtimeBegin.ToString("yyyy-MM-dd 00:00:00");
               paramArr[1].Value = p_dtimeEnd.ToString("yyyy-MM-dd 23:59:59");
               paramArr[2].Value = p_strID;
               paramArr[3].Value = flage;
               lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_DataTableQueue, paramArr);
             
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

        #region  判断是否旧的数据
        /// <summary>
        /// 判断是否旧的数据
        /// </summary>
        /// <param name="p_Seq">流水号</param>
        /// <param name="p_WinStyle">窗口状态；0-发药窗口，1—配药窗口</param>
        /// <param name="p_Status">状态 1-新建 2-已配药 3-已发药 -1-退回</param>
        /// <param name="p_objPrincipal"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_thJudgeIsOldData(System.Security.Principal.IPrincipal p_objPrincipal,int p_Seq,int p_WinStyle,out int p_Status)
        {
            long lngRes = 0;
            p_Status = -2;
            DataTable dtable = new DataTable();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngVerichDropRecord");
            if (lngRes < 0)
            {
                return -1;
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                string strSQL = "";
                if (p_WinStyle==1)
                strSQL = @" select a.pstatus_int from t_opr_medRecipesend a,T_OPR_MEDSTOREWINQUE b
                            where b.seq_int=" + p_Seq + "and a.outpatrecipeid_chr=b.outpatrecipeid_chr and a.windowid_chr=b.windowid_chr";
                else if (p_WinStyle==0)
                strSQL = @" select a.pstatus_int from t_opr_medRecipesend a,T_OPR_MEDSTOREWINQUE b
                            where b.seq_int=" + p_Seq + "and a.outpatrecipeid_chr=b.outpatrecipeid_chr and a.sendemp_chr=b.windowid_chr";
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtable);
                if (lngRes > 0 && dtable.Rows.Count > 0)
                {
                    p_Status = Convert.ToInt32(dtable.Rows[0][0].ToString());
                }

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
        #region 保存垂直拖动记录 2006-2-22
        /// <summary>
        /// 保存垂直拖动记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_Seq"></param>
        /// <param name="p_Order"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngVerichDropRecord(System.Security.Principal.IPrincipal p_objPrincipal, int p_Seq, int p_Order)
        {
            long lngRes = 0;
    
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngVerichDropRecord");

            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                string strSQL = @" update T_OPR_MEDSTOREWINQUE set  ORDER_INT=? where SEQ_INT=?";

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = p_Order;
                paramArr[1].Value = p_Seq;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 保存水平或斜向拖动记录 2006-2-22
        /// <summary>
        /// 保存水平或斜向拖动记录
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_Seq"></param>
        /// <param name="p_WinID"></param>
        /// <param name="p_WinType"></param>
        /// <param name="p_Order"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngHorDropRecord(System.Security.Principal.IPrincipal p_objPrincipal, int p_Seq,string p_WinID,int p_WinType, int p_Order)
        {
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedStoreBseInfoSvc", "m_lngHorDropRecord");

            if (lngRes < 0)
            {
                return -1;
            }

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                string strSQL = @"  update T_OPR_MEDSTOREWINQUE a set  a.ORDER_INT=?,a.WINDOWID_CHR=?  where a.SEQ_INT=?";
            

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = p_Order;
                paramArr[1].Value = p_WinID;
                paramArr[2].Value = p_Seq;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                string p_strSQL = "";
                if (p_WinType == 0)
                {
                    p_strSQL = @"  update t_opr_medrecipesend b set  b.SENDWINDOWID=? where b.OUTPATRECIPEID_CHR in (select a.OUTPATRECIPEID_CHR from T_OPR_MEDSTOREWINQUE a where a.SEQ_INT=? )" ;
                    paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                    paramArr[0].Value = p_WinID;
                    paramArr[1].Value = p_Seq;
                 lngRecordsAffected = -1;
                    lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);
      
                }
                else if (p_WinType == 1)
                {
                    paramArr = null;
                    objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                    paramArr[0].Value = p_WinID;
                    paramArr[1].Value = p_Seq;
                   lngRecordsAffected = -1;
                   p_strSQL = @"  update t_opr_medrecipesend b set  b.WINDOWID_CHR=? where b.OUTPATRECIPEID_CHR=(select a.outpatrecipeid_chr from T_OPR_MEDSTOREWINQUE a where a.seq_int=?)";
                   lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);
                   p_strSQL = @"  update t_opr_outpatientpwmrecipede b set  b.WINDOWID_CHR=? where b.OUTPATRECIPEID_CHR=(select a.outpatrecipeid_chr from T_OPR_MEDSTOREWINQUE a where a.seq_int=?)";
                   lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);
                   p_strSQL = @"  update T_OPR_OUTPATIENTCMRECIPEDE b set  b.WINDOWID_CHR=? where b.OUTPATRECIPEID_CHR=(select a.outpatrecipeid_chr from T_OPR_MEDSTOREWINQUE a where a.seq_int=?)";
                   lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);

                   p_strSQL = @"  update T_OPR_OUTPATIENTCHKRECIPEDE b set  b.WINDOWID_CHR=? where b.OUTPATRECIPEID_CHR=(select a.outpatrecipeid_chr from T_OPR_MEDSTOREWINQUE a where a.seq_int=?)";
                   lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);

                   p_strSQL = @"  update T_OPR_OUTPATIENTTESTRECIPEDE b set  b.WINDOWID_CHR=? where b.OUTPATRECIPEID_CHR=(select a.outpatrecipeid_chr from T_OPR_MEDSTOREWINQUE a where a.seq_int=?)";
                   lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);

                   p_strSQL = @"  update T_OPR_OUTPATIENTOPSRECIPEDE b set  b.WINDOWID_CHR=? where b.OUTPATRECIPEID_CHR=(select a.outpatrecipeid_chr from T_OPR_MEDSTOREWINQUE a where a.seq_int=?)";
                   lngRes = objHRPSvc.lngExecuteParameterSQL(p_strSQL, ref lngRecordsAffected, paramArr);




                }
                
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
