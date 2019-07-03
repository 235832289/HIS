using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Data;
namespace com.digitalwave.iCare.middletier.HIS.Reports
{
    [Transaction(TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsWindowsCortrol : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取当前的配药窗口(也就是检查药房配药窗口中配药队列最小的窗口）
        /// <summary>
        /// 获取当前的配药窗口(也就是检查药房配药窗口中配药队列最小的窗口）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="storageID">传入药房</param>
        /// <param name="windowsID">返回配药窗口</param>
        /// <param name="WaiteNO">返回窗口队列</param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetWindowIDByStorage(System.Security.Principal.IPrincipal p_objPrincipal, string storageID, out string windowsID,out int WaiteNO, bool CheckScope)
        {
            windowsID = "";
            WaiteNO = 1;
            long lngRegs = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsReckoningReport", "lngGetWindowIDByStorage");
            if (lngRegs < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            if (CheckScope)
            {
                strSQL = @"select   a.windowid_chr, a.medstoreid_chr,
         decode (k.intcount, null, 0, k.intcount) as intcount1,
         decode (k.intcount3, null, 0, k.intcount3) as intcount4
    from t_bse_medstorewin a,
         (select intcount, intcount3, b.windowid_chr, b.medstoreid_chr
            from (select   max (order_int) as intcount, windowid_chr,
                           medstoreid_chr
                      from t_opr_medstorewinque
                     where medstoreid_chr = ?
                       and windowtype_int = 1
                       and outpatrecipeid_chr like ?
                  group by medstoreid_chr, windowid_chr) b,
                 (select   count (order_int) as intcount3, windowid_chr,
                           medstoreid_chr
                      from t_opr_medstorewinque
                     where medstoreid_chr = ?
                       and windowtype_int = 1
                       and outpatrecipeid_chr like ?
                  group by medstoreid_chr, windowid_chr) c
           where b.medstoreid_chr = c.medstoreid_chr
             and b.windowid_chr = c.windowid_chr) k
   where a.medstoreid_chr = ?
     and a.windowtype_int = 1
     and a.workstatus_int = 1
     and a.medstoreid_chr = k.medstoreid_chr(+)
     and a.windowid_chr = k.windowid_chr(+)
order by intcount4
";
            }
            else
            {
                strSQL = @"select   a.windowid_chr, a.medstoreid_chr,
         decode (k.intcount, null, 0, k.intcount) as intcount1,
          decode (k.intcount3, null, 0, k.intcount3) as intcount4
    from t_bse_medstorewin a,
         (select intcount, intcount3, b.windowid_chr, b.medstoreid_chr
            from (select   max (order_int) as intcount, windowid_chr,
                           medstoreid_chr
                      from t_opr_medstorewinque
                     where medstoreid_chr = ?
                       and windowtype_int = 1
                       and outpatrecipeid_chr like ?
                  group by medstoreid_chr, windowid_chr) b,
                 (select   count (order_int) as intcount3, windowid_chr,
                           medstoreid_chr
                      from t_opr_medstorewinque
                     where medstoreid_chr = ?
                       and windowtype_int = 1
                       and outpatrecipeid_chr like ?
                  group by medstoreid_chr, windowid_chr) c
           where b.medstoreid_chr = c.medstoreid_chr
             and b.windowid_chr = c.windowid_chr) k
   where a.medstoreid_chr = ?
     and a.winproperty_int = 0
     and a.windowtype_int = 1
     and a.workstatus_int = 1
     and a.medstoreid_chr = k.medstoreid_chr(+)
     and a.windowid_chr = k.windowid_chr(+)
order by intcount4";
            }
            com.digitalwave.iCare.middletier.HIS.Reports.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyyMMdd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
  
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                paramArr[0].Value = storageID;
                paramArr[1].Value = strDateTime+"%";
                paramArr[2].Value = storageID;
                paramArr[3].Value = strDateTime+"%";
                paramArr[4].Value = storageID;
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);

                if (p_dtWindow.Rows.Count > 0)
                {
                    windowsID = p_dtWindow.Rows[0]["WINDOWID_CHR"].ToString();
                    WaiteNO = int.Parse(p_dtWindow.Rows[0]["intcount1"].ToString()) + 1;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }
        #endregion

        #region 判断传入的窗口是否在工作状态
        /// <summary>
        ///  判断传入的窗口是否在工作状态
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strWindowsID">窗口ID</param>
        /// <param name="isWork">是否在工作中</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngWindowsWork(System.Security.Principal.IPrincipal p_objPrincipal, string strWindowsID,out bool isWork)
        {
            isWork = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngWindowsWork");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;
            string strSQL = @"SELECT   a.WORKSTATUS_INT
                              FROM t_bse_medstorewin a
                              WHERE a.WINDOWID_CHR = '" + strWindowsID + "'";
            DataTable dt= new DataTable();
            try
            {
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if (dt.Rows.Count > 0)
            {
                try
                {
                    if (int.Parse(dt.Rows[0]["WORKSTATUS_INT"].ToString()) == 1)
                    {
                        isWork = true;
                    }
                    else
                    {
                        isWork = false;
                    }
                }
                catch
                {
                    isWork = false;
                }
            }
            return lngRes;
        }
        #endregion

        #region 获取当前工作中的药房
       /// <summary>
        ///获取当前工作中的药房 
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="strOldStorageID"></param>
       /// <param name="strNewStorageID"></param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngGetWorkStorage(System.Security.Principal.IPrincipal p_objPrincipal, string strOldStorageID,out string strNewStorageID)
        {
            long lngRes = 0;
            strNewStorageID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNew");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;
            com.digitalwave.iCare.middletier.HIS.Reports.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyy-MM-dd HH:mm:ss");
            int weekDay_int = 0;//星期几 (1-周一\7-周日)
            clsGetServerDate getServerDate = new clsGetServerDate();
            switch (getServerDate.m_GetServerDate().DayOfWeek.ToString())
            {
                case "Monday":
                    weekDay_int = 1;
                    break;
                case "Tuesday":
                    weekDay_int = 2;
                    break;
                case "Wednesday":
                    weekDay_int = 3;
                    break;
                case "Thursday":
                    weekDay_int = 4;
                    break;
                case "Friday":
                    weekDay_int = 5;
                    break;
                case "Saturday":
                    weekDay_int = 6;
                    break;
                case "Sunday":
                    weekDay_int = 7;
                    break;
            }

            string strSQL = @"select a.seq_int, a.typeid_int, a.deptid_vchr, a.weekday_int, a.worktime_vchr,
       a.objectdeptid_vchr, a.remark_vchr
  from t_bse_deptduty a
 where a.deptid_vchr = ? and a.weekday_int = ?";
            DataTable dtDuty = new DataTable();
            try
            {
            
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(2, out paramArr);
                paramArr[0].Value = strOldStorageID;
                paramArr[1].Value = weekDay_int;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtDuty, paramArr);
            }
            catch
            {
            }
            DateTime _serverDate = getServerDate.m_GetServerDate();
            if (dtDuty.Rows.Count > 0)
            {
                if (dtDuty.Rows[0]["WORKTIME_VCHR"] != System.DBNull.Value && dtDuty.Rows[0]["WORKTIME_VCHR"].ToString() != "")
                {
                    string _split = "|";
                    string[] objstr = dtDuty.Rows[0]["WORKTIME_VCHR"].ToString().Split(_split.ToCharArray());
                    for (int f2 = 0; f2 < objstr.Length; f2++)
                    {
                        _split = "-";
                        string[] objstr1 = objstr[f2].Split(_split.ToCharArray());
                        if (objstr1.Length == 2)
                        {
                            string date1 = _serverDate.Date.ToString("yyyy-MM-dd") + " " + objstr1[0];
                            string date2 = _serverDate.Date.ToString("yyyy-MM-dd") + " " + objstr1[1];
                            if (_serverDate >= DateTime.Parse(date1) && _serverDate <= DateTime.Parse(date2))
                            {
                                strNewStorageID = strOldStorageID;
                                return 1;
                            }
                        }
                    }
                }
            }
            else
            {
                strNewStorageID = strOldStorageID;
                return 1;
            }
            strNewStorageID = dtDuty.Rows[0]["OBJECTDEPTID_VCHR"].ToString();
            return lngRes;
        }
        #endregion

        #region 写入队列信息
        /// <summary>
        /// 写入队列信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewWinque(System.Security.Principal.IPrincipal p_objPrincipal, clsmedstorewinque p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNew");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"insert into t_opr_medstorewinque (seq_int, windowid_chr, windowtype_int, medstoreid_chr, outpatrecipeid_chr, recipetype_chr, order_int, sid_int) 
                                                                 values (seq_medstore.nextval, ?, ?, ?, ?, ?, ?, ?)";
            try
            {
               

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out paramArr);
                paramArr[0].Value = p_objRecord.m_strWINDOWID_CHR;
                paramArr[1].Value = p_objRecord.m_intWINDOWTYPE_INT;
                paramArr[2].Value = p_objRecord.m_strMEDSTOREID_CHR;
                paramArr[3].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
                paramArr[4].Value = p_objRecord.m_strRECIPETYPE_CHR;
                paramArr[5].Value = p_objRecord.m_intWaitNO;
                paramArr[6].Value = p_objRecord.m_intWaitNO;
             
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 删除队列信息
        /// <summary>
        /// 删除队列信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleWinque(System.Security.Principal.IPrincipal p_objPrincipal, clsmedstorewinque p_objRecord)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNew");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = @"delete  t_opr_medstorewinque
      where medstoreid_chr = ?
        and windowid_chr = ?
        and outpatrecipeid_chr = ?
        and windowtype_int = ?";
            try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = p_objRecord.m_strMEDSTOREID_CHR ;
                paramArr[1].Value = p_objRecord.m_strWINDOWID_CHR;
                paramArr[2].Value = p_objRecord.m_strOUTPATRECIPEID_CHR;
                paramArr[3].Value = p_objRecord.m_intWINDOWTYPE_INT;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
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

        #region 获取发药窗口
        /// <summary>
        /// 获取发药窗口
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="TreatwinID">配药窗口</param>
        /// <param name="windowsID">返回发药窗口</param>
        /// <param name="WaitNO">返回队列数</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetGiveWindID(System.Security.Principal.IPrincipal p_objPrincipal, string TreatwinID, out string windowsID, out int WaitNO)
        {
            long lngRegs = 0;
            windowsID = "";
            WaitNO = 1;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngAddNew");
            if (lngRegs < 0)
            {
                return -1;
            }
            if (lngRegs < 0)
                return lngRegs;
            com.digitalwave.iCare.middletier.HIS.Reports.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyyMMdd");
            string strSQL = @"select a.givewinid_chr,decode(b.intcount,null,0,b.intcount) as intcount
  from (select t1.*
          from (select   min (order_int) as df, a.givewinid_chr
                    from t_opr_medstorewinrlt a, t_bse_medstorewin b
                   where a.treatwinid_chr = ?
                     and a.givewinid_chr = b.windowid_chr
                     and b.workstatus_int = 1
                group by givewinid_chr) t1,
               (select   min (order_int) as df
                    from t_opr_medstorewinrlt a, t_bse_medstorewin b
                   where a.treatwinid_chr = ?
                     and a.givewinid_chr = b.windowid_chr
                     and b.workstatus_int = 1
                group by treatwinid_chr) t2
         where t1.df = t2.df) a,
       (select   max (order_int) as intcount, windowid_chr
            from t_opr_medstorewinque
           where outpatrecipeid_chr like ?
        group by windowid_chr) b
 where a.givewinid_chr = b.windowid_chr(+)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
          
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = TreatwinID;
                paramArr[1].Value = TreatwinID;
                paramArr[2].Value = strDateTime+"%";
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);
                if (p_dtWindow.Rows.Count > 0)
                {
                    windowsID = p_dtWindow.Rows[0]["GIVEWINID_CHR"].ToString();
                    WaitNO = int.Parse(p_dtWindow.Rows[0]["intcount"].ToString()) + 1;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }
        #endregion

    }

}
