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
    /// 门诊药房Supported类
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsOPMedStore_Supported_Svc :com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        /// <summary>
        /// 门诊药房Supported类
        /// </summary>
        public clsOPMedStore_Supported_Svc()
        {
        }

        #region 收费时的窗口分配

        #region 根据PID获取患者当天发药信息
        /// <summary>
        /// 根据PID获取患者当天发药信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="medid"></param>
        /// <param name="blnCmRecipe"></param>
        /// <param name="m_objMedStoreVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetsendmedinfoBypid(string pid, string medid, bool blnCmRecipe, out clsMedStoreWindowsVo m_objMedStoreVo)
        {
            m_objMedStoreVo = null;
            long lngRes = -1;
            string SQL = @"select  a.windowid_chr, 0 as treatwindowflag_int,
                                   c.workstatus_int as treatwindowworkstatus_int,
                                   c.windowname_vchr as treatwindowname, a.pstatus_int, a.senddate_dat,
                                   a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, a.autoprint_int,
                                   a.medstoreid_chr, a.sendwindowid_chr,
                                   0 as sendwindowflag_int,
                                   e.workstatus_int as sendwindowworkstatus_int, a.autoprintyd_int, 
                                   e.windowname_vchr as sendwindowname, 0 as order_int
                              from t_opr_recipesend a, t_bse_medstorewin c, t_bse_medstorewin e,
                                   t_opr_recipesendentry f
                             where a.sid_int = f.sid_int
                               and a.pstatus_int <> -1
                               and c.windowtype_int = 1
                               and c.workstatus_int = 1
                               and e.workstatus_int = 1
                               and e.windowtype_int = 0
                               and a.medstoreid_chr = c.medstoreid_chr
                               and a.windowid_chr = c.windowid_chr
                               and a.sendwindowid_chr = e.windowid_chr 
                               and a.patientid_chr = ?
                               and a.medstoreid_chr = ?
                               and a.createdate_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);
                
                ParamArr[0].Value = pid;
                ParamArr[1].Value = medid;
                ParamArr[2].Value = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dtRecord = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
                objHRPSvc.Dispose();

                if (dtRecord != null && dtRecord.Rows.Count > 0)
                {
                    DataView dv = dtRecord.DefaultView;
                    if (blnCmRecipe)
                        dv.Sort = "treatwindowflag_int desc";
                    else
                        dv.Sort = "treatwindowflag_int";
                    dtRecord = dv.ToTable();
                    DataRow dr = null;
                    for (int i = 0; i < dtRecord.Rows.Count; i++)
                    {
                        dr = dtRecord.Rows[i];
                        if (blnCmRecipe && Convert.ToByte(dr["treatwindowflag_int"]) == 1)
                        {
                            m_objMedStoreVo = new clsMedStoreWindowsVo();
                            m_objMedStoreVo.m_intWindowOrderNo = Convert.ToInt32(dr["order_int"]) + 1;
                            m_objMedStoreVo.m_strWindowID = dr["windowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowID = dr["sendwindowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowName = dr["sendwindowname"].ToString();
                            break;
                        }
                        else if (!blnCmRecipe && Convert.ToByte(dr["treatwindowflag_int"]) == 0)
                        {
                            m_objMedStoreVo = new clsMedStoreWindowsVo();
                            m_objMedStoreVo.m_intWindowOrderNo = Convert.ToInt32(dr["order_int"]) + 1;
                            m_objMedStoreVo.m_strWindowID = dr["windowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowID = dr["sendwindowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowName = dr["sendwindowname"].ToString();
                            break;
                        }
                    }
                    dr = null;
                    dtRecord.Dispose();
                    dtRecord = null;
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 根据PID获取患者当天发药信息(只要普通窗，合并药房之后用到)
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="medid"></param>
        /// <param name="blnCmRecipe"></param>
        /// <param name="m_objMedStoreVo"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetsendgeneralmedinfoBypid(string pid, string medid, bool blnCmRecipe, out clsMedStoreWindowsVo m_objMedStoreVo)
        {
            m_objMedStoreVo = null;
            long lngRes = -1;
            string SQL = @"select  a.windowid_chr, 0 as treatwindowflag_int,
                                   c.workstatus_int as treatwindowworkstatus_int,
                                   c.windowname_vchr as treatwindowname, a.pstatus_int, a.senddate_dat,
                                   a.sendemp_chr, a.treatdate_dat, a.treatemp_chr, a.autoprint_int,
                                   a.medstoreid_chr, a.sendwindowid_chr,
                                   0 as sendwindowflag_int,
                                   e.workstatus_int as sendwindowworkstatus_int, a.autoprintyd_int, 
                                   e.windowname_vchr as sendwindowname, 0 as order_int
                              from t_opr_recipesend a, t_bse_medstorewin c, t_bse_medstorewin e,
                                   t_opr_recipesendentry f
                             where a.sid_int = f.sid_int
                               and a.pstatus_int <> -1
                               and c.windowtype_int = 1
                               and c.workstatus_int = 1
                               and e.winproperty_int = 0
                               and e.workstatus_int = 1
                               and e.windowtype_int = 0
                               and a.medstoreid_chr = c.medstoreid_chr
                               and a.windowid_chr = c.windowid_chr
                               and a.sendwindowid_chr = e.windowid_chr 
                               and a.patientid_chr = ?
                               and a.medstoreid_chr = ?
                               and a.createdate_chr = ?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out ParamArr);

                ParamArr[0].Value = pid;
                ParamArr[1].Value = medid;
                ParamArr[2].Value = DateTime.Now.ToString("yyyy-MM-dd");
                DataTable dtRecord = null;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dtRecord, ParamArr);
                objHRPSvc.Dispose();

                if (dtRecord != null && dtRecord.Rows.Count > 0)
                {
                    DataView dv = dtRecord.DefaultView;
                    if (blnCmRecipe)
                        dv.Sort = "treatwindowflag_int desc";
                    else
                        dv.Sort = "treatwindowflag_int";
                    dtRecord = dv.ToTable();
                    DataRow dr = null;
                    for (int i = 0; i < dtRecord.Rows.Count; i++)
                    {
                        dr = dtRecord.Rows[i];
                        if (blnCmRecipe && Convert.ToByte(dr["treatwindowflag_int"]) == 1)
                        {
                            m_objMedStoreVo = new clsMedStoreWindowsVo();
                            m_objMedStoreVo.m_intWindowOrderNo = Convert.ToInt32(dr["order_int"]) + 1;
                            m_objMedStoreVo.m_strWindowID = dr["windowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowID = dr["sendwindowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowName = dr["sendwindowname"].ToString();
                            break;
                        }
                        else if (!blnCmRecipe && Convert.ToByte(dr["treatwindowflag_int"]) == 0)
                        {
                            m_objMedStoreVo = new clsMedStoreWindowsVo();
                            m_objMedStoreVo.m_intWindowOrderNo = Convert.ToInt32(dr["order_int"]) + 1;
                            m_objMedStoreVo.m_strWindowID = dr["windowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowID = dr["sendwindowid_chr"].ToString();
                            m_objMedStoreVo.m_strSendWindowName = dr["sendwindowname"].ToString();
                            break;
                        }
                    }
                    dr = null;
                    dtRecord.Dispose();
                    dtRecord = null;
                }
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

        #region 根据接诊科室、药房获取专用窗口信息
        /// <summary>
        /// 根据接诊科室、药房获取专用窗口信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="medid"></param>
        /// <param name="winid"></param>
        /// <param name="waitno"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetespecialwin(System.Security.Principal.IPrincipal p_objPrincipal, string deptid, string medid, out clsMedStoreWindowsVo objMedStoreVo)
        {
            string winid = "";
            int waitno = 1;
            DataTable dt = new DataTable();
            long lngRes = 0;
            objMedStoreVo = null;
            string Recdate = DateTime.Now.ToString("yyyyMMdd");

            string SQL = @"select t1.windowid_chr, nvl(t3.ordermax,0) as ordermax, nvl(t3.ordercount,0) as ordercount
                             from t_bse_medstorewin t1,                                  
                                   (select windowid_chr
                                      from t_bse_medstorewindeptdef 
                                     where deptid_chr = ? and medstoreid_chr = ?) t2,                              
                                   (select a.medstoreid_chr, a.windowid_chr, b.ordercount, a.ordermax      
                                      from (select medstoreid_chr, windowid_chr, max(order_int) as ordermax
                                              from t_opr_medstorewinque
                                             where windowtype_int = 1
                                               and medstoreid_chr = ?
                                               and outpatrecipeid_chr like ? 
                                            group by medstoreid_chr, windowid_chr) a,
                                           (select medstoreid_chr, windowid_chr, count(order_int) as ordercount
                                              from t_opr_medstorewinque
                                             where windowtype_int = 1
                                               and medstoreid_chr = ? 
                                               and outpatrecipeid_chr like ? 
                                            group by medstoreid_chr, windowid_chr) b
                                     where a.medstoreid_chr = b.medstoreid_chr
                                       and a.windowid_chr = b.windowid_chr) t3
                              where t1.winproperty_int = 1
                                and t1.windowtype_int = 1
                                and t1.workstatus_int = 1
                                and t1.windowid_chr = t2.windowid_chr
                                and t1.windowid_chr = t3.windowid_chr(+)
                                and t1.medstoreid_chr = t3.medstoreid_chr(+)
                            order by ordercount";

            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out ParamArr);
                ParamArr[0].Value = deptid;
                ParamArr[1].Value = medid;
                ParamArr[2].Value = medid;
                ParamArr[3].Value = Recdate + "%";
                ParamArr[4].Value = medid;
                ParamArr[5].Value = Recdate + "%";

                lngRes = objHRPSvc.lngGetDataTableWithParameters(SQL, ref dt, ParamArr);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dt.Rows.Count > 0)
                {
                    winid = dt.Rows[0]["windowid_chr"].ToString();
                    waitno = Convert.ToInt32(dt.Rows[0]["ordermax"]) + 1;
                    objMedStoreVo = new clsMedStoreWindowsVo();
                    objMedStoreVo.m_intWindowOrderNo = waitno;
                    objMedStoreVo.m_strWindowID = winid;
                    //this.lngGetSendWindowInfo(System.Security.Principal.IPrincipal 
                    this.lngGetSpecialSendWindowInfo(p_objPrincipal, medid, false, ref objMedStoreVo, false);
                    dt.Dispose();
                    dt = null;
                }
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

        #region 获取窗口名
        /// <summary>
        /// 获取窗口名
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthGetWindowName(out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = -1;
            string SQL = @"select t.windowid_chr,t.windowname_vchr, t.rowid from t_bse_medstorewin t";
            try
            {
                clsHRPTableService objSvc = new clsHRPTableService();
                lngRes = objSvc.lngGetDataTableWithoutParameters(SQL, ref dtbResult);
                objSvc.Dispose();
                objSvc = null;
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

        #region 获取当前的配药窗口和发药窗口(也就是检查药房配药窗口中配药队列最小的窗口）（只检查普通窗，专窗不用考虑队列大小）
        /// <summary>
        /// 获取当前的配药窗口和发药窗口(也就是检查药房配药窗口中配药队列最小的窗口）
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="storageID">药房id</param>
        /// <param name="m_objWindowsVo">如果找不到合适的配药窗口和发药窗口，返回null</param>
        /// <param name="CheckScope">药房专用窗口是否可以接收所有科室处方 true 接收 false 禁止 参数：0057</param>
        /// <param name="m_blnWindowType">是否草药窗口标志：false-否；true-是</param>
        /// <param name="m_blnWindowRelation">配、发药窗口是否存在联系</param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetWindowIDByStorage(System.Security.Principal.IPrincipal p_objPrincipal, string storageID, out clsMedStoreWindowsVo m_objWindowsVo, bool CheckScope, bool m_blnWindowType, bool m_blnWindowRelation)
        {
            m_objWindowsVo = null;
            long lngRegs = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol", "lngGetWindowIDByStorage");
            if (lngRegs < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            if (CheckScope)
            {
                strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.windowid_chr
                                       from t_opr_recipesend b
                                      where b.pstatus_int = 1
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?) c
                             where a.windowid_chr = c.windowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 1
                               and a.workstatus_int = 1
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr";
            }
            else
            {
                strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.windowid_chr
                                       from t_opr_recipesend b
                                      where b.pstatus_int = 1
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?) c
                             where a.windowid_chr = c.windowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 1
                               and a.winproperty_int = 0
                               and a.workstatus_int = 1
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr";
            }
            com.digitalwave.iCare.middletier.HIS.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = storageID;
                paramArr[1].Value = strDateTime;
                paramArr[2].Value = storageID;
                //获取当前药房所有配药窗口的配药队列
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);


                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    DataView dv = p_dtWindow.DefaultView;
                    if (m_blnWindowType == true)//对获取的表进行排序，
                        dv.Sort = " windowflag_int desc,numcount";//将草药窗口而且队列最少的窗口排在前面
                    else
                        dv.Sort = "windowflag_int ,numcount";//将成药窗口而且队列最少的窗口排在前面
                    p_dtWindow = dv.ToTable();
                    int m_intCount = p_dtWindow.Rows.Count;
                    DataRow dtRowTemp = null;
                    for (int i = 0; i < m_intCount; i++)
                    {
                        dtRowTemp = p_dtWindow.Rows[i];
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                        m_objWindowsVo.m_strWindowID = dtRowTemp["WINDOWID_CHR"].ToString();
                        m_objWindowsVo.m_strWindowName = dtRowTemp["windowname_vchr"].ToString();
                        m_objWindowsVo.m_intWindowOrderNo = int.Parse(dtRowTemp["numcount"].ToString()) + 1;
                        if (m_blnWindowRelation == true)
                        {
                            this.lngGetSendWindowInfoByWindowid(p_objPrincipal, storageID, m_objWindowsVo.m_strWindowID, ref m_objWindowsVo);
                        }
                        else
                        {
                            this.lngGetSendWindowInfo(p_objPrincipal, storageID, CheckScope, ref m_objWindowsVo, m_blnWindowType);
                        }
                        if (m_objWindowsVo != null)//成功取到发药窗口信息
                            break;
                    }
                    dv = null;
                    p_dtWindow.Dispose();
                    p_dtWindow = null;
                    dtRowTemp = null;
                }
                else
                {
                    m_objWindowsVo = null;//返回null到收费界面，作为取不到任何配药窗口信息的标识，请药房人员配好药房窗口设置；
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }


        /// <summary>
        /// 根据配药窗口id获取发药窗口信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strWindowid">配药窗口id</param>
        /// <param name="m_objWindowsVo">发药窗口信息vo,获取发药窗口信息时返回null</param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetSendWindowInfoByWindowid(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedStoreid, string m_strWindowid, ref clsMedStoreWindowsVo m_objWindowsVo)
        {
            long lngRegs = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol", "lngGetSendWindowInfoByWindowid");
            if (lngRegs < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HIS.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
                System.Data.IDataParameter[] paramArr = null;
                strSQL = @"select windowid_chr, windowname_vchr, medstoreid_chr, 0 as windowflag_int,
       numcount
  from (select a.windowid_chr, a.windowname_vchr,
                a.medstoreid_chr, sum(decode(c.sid_int, null, 0, 1)) as numcount
           from t_bse_medstorewin a,
                (select b.sid_int, b.sendwindowid_chr
                    from t_opr_recipesend b
                   where b.createdate_chr = ?
                     and b.medstoreid_chr = ?
                     and b.pstatus_int = 2) c
          where a.windowid_chr = c.sendwindowid_chr(+)
            and a.medstoreid_chr = ?
            and a.windowtype_int = 0
            and a.workstatus_int = 1
          group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr
          order by numcount) d, t_opr_medstorewinrlt e
 where e.treatwinid_chr = ?
   and e.givewinid_chr = d.windowid_chr
 order by numcount";

                objHRPSvc.CreateDatabaseParameter(4, out paramArr);
                paramArr[0].Value = strDateTime;
                paramArr[1].Value = m_strMedStoreid;
                paramArr[2].Value = m_strMedStoreid;
                paramArr[3].Value = m_strWindowid;
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);

                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    DataRow drTemp = p_dtWindow.Rows[0];
                    if (m_objWindowsVo == null)
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                    m_objWindowsVo.m_strSendWindowID = drTemp["windowid_chr"].ToString();
                    m_objWindowsVo.m_strSendWindowName = drTemp["windowname_vchr"].ToString();
                    m_objWindowsVo.m_intSendWindowOrderNo = int.Parse(drTemp["numcount"].ToString()) + 1;

                    p_dtWindow.Dispose();
                    p_dtWindow = null;
                    drTemp = null;
                }
                else
                {
                    m_objWindowsVo = null;
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }

        /// <summary>
        /// 获取当前发药窗口信息--与配药窗口没有关联
        /// </summary>
        /// <param name="p_objPrincipal"></param> 
        /// <param name="m_objWindowsVo">发药窗口信息vo,获取发药窗口信息时返回null</param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetSendWindowInfo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedStoreid, bool CheckScope, ref clsMedStoreWindowsVo m_objWindowsVo, bool m_blnWindowType)
        {
            long lngRegs = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol", "lngGetSendWindowInfoByWindowid");
            if (lngRegs < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HIS.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
                System.Data.IDataParameter[] paramArr = null;
                if (CheckScope)
                {
                    strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.called_int = 0
                                        and b.pstatus_int in (1, 2) 
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?) c
                             where a.windowid_chr = c.sendwindowid_chr(+)
                               and a.windowid_chr = d.sendwindowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 0
                               and a.workstatus_int = 1
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr";
                }
                else
                {
                    strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.called_int = 0
                                        and b.pstatus_int in (1, 2)
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ? ) c
                             where a.windowid_chr = c.sendwindowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 0
                               and a.workstatus_int = 1 and a.winproperty_int = 0
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr";
                }


                objHRPSvc.CreateDatabaseParameter(3, out paramArr);
                paramArr[0].Value = m_strMedStoreid;
                paramArr[1].Value = strDateTime;
                paramArr[2].Value = m_strMedStoreid;
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);

                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    if (m_blnWindowType == true)
                    {
                        p_dtWindow.DefaultView.Sort = "windowflag_int desc,numcount";
                    }
                    else
                    {
                        p_dtWindow.DefaultView.Sort = " windowflag_int,numcount";
                    }
                    p_dtWindow = p_dtWindow.DefaultView.ToTable();
                    DataRow drTemp = p_dtWindow.Rows[0];
                    if (m_objWindowsVo == null)
                    {
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                    }
                    m_objWindowsVo.m_strSendWindowID = drTemp["windowid_chr"].ToString();
                    m_objWindowsVo.m_strSendWindowName = drTemp["windowname_vchr"].ToString();
                    m_objWindowsVo.m_intSendWindowOrderNo = int.Parse(drTemp["numcount"].ToString()) + 1;

                    p_dtWindow.Dispose();
                    p_dtWindow = null;
                    drTemp = null;
                }
                else
                {
                    m_objWindowsVo = null;
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }

        [AutoComplete]
        public long lngGetSpecialSendWindowInfo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedStoreid, bool CheckScope, ref clsMedStoreWindowsVo m_objWindowsVo, bool m_blnWindowType)
        {
            long lngRegs = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol", "lngGetSendWindowInfoByWindowid");
            if (lngRegs < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HIS.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
                System.Data.IDataParameter[] paramArr = null;
                if (CheckScope)
                {
                    strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount, d.lastdate
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.called_int = 0
                                        and b.pstatus_int in (1, 2) 
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?) c,
                                   (select max(b.senddate_dat) as lastdate, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.pstatus_int = 3 
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?
                                      group by b.sendwindowid_chr) d
                             where a.windowid_chr = c.sendwindowid_chr(+)
                               and a.windowid_chr = d.sendwindowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 0
                               and a.workstatus_int = 1
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr,
                                      d.lastdate";
                }
                else
                {
                    strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount, d.lastdate
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.called_int = 0
                                        and b.pstatus_int in (1, 2) 
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?) c,
                                   (select max(b.senddate_dat) as lastdate, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.pstatus_int = 3 
                                        and b.medstoreid_chr = ?
                                        and b.createdate_chr = ?
                                      group by b.sendwindowid_chr) d
                             where a.windowid_chr = c.sendwindowid_chr(+)
                               and a.windowid_chr = d.sendwindowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 0
                               and a.workstatus_int = 1 and a.winproperty_int = 1
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr,
                                      d.lastdate";
                }


                objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                paramArr[0].Value = m_strMedStoreid;
                paramArr[1].Value = strDateTime;
                paramArr[2].Value = m_strMedStoreid;
                paramArr[3].Value = strDateTime; 
                paramArr[4].Value = m_strMedStoreid;
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);

                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    if (m_blnWindowType == true)
                    {
                        p_dtWindow.DefaultView.Sort = "windowflag_int desc,numcount, lastdate";
                    }
                    else
                    {
                        p_dtWindow.DefaultView.Sort = " windowflag_int,numcount, lastdate";
                    }
                    p_dtWindow = p_dtWindow.DefaultView.ToTable();
                    DataRow drTemp = p_dtWindow.Rows[0];
                    if (m_objWindowsVo == null)
                    {
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                    }
                    m_objWindowsVo.m_strSendWindowID = drTemp["windowid_chr"].ToString();
                    m_objWindowsVo.m_strSendWindowName = drTemp["windowname_vchr"].ToString();
                    m_objWindowsVo.m_intSendWindowOrderNo = int.Parse(drTemp["numcount"].ToString()) + 1;
                    p_dtWindow.Dispose();
                    p_dtWindow = null;
                    drTemp = null;
                }
                else
                {
                    m_objWindowsVo = null;
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRegs;
        }

        [AutoComplete]
        public long lngOnlyGetSendWindowInfo(System.Security.Principal.IPrincipal p_objPrincipal, string m_strMedStoreid, out clsMedStoreWindowsVo m_objWindowsVo, bool m_blnWindowType)
        {
            m_objWindowsVo = null;
            long lngRegs = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRegs = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol", "lngGetSendWindowInfoByWindowid");
            if (lngRegs < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            com.digitalwave.iCare.middletier.HIS.clsGetServerDate objDate = new clsGetServerDate();
            string strDateTime = objDate.m_GetServerDate().ToString("yyyy-MM-dd");
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.DataTable p_dtWindow = new System.Data.DataTable();
                System.Data.IDataParameter[] paramArr = null;
                strSQL = @"select  a.windowid_chr, a.windowname_vchr, a.medstoreid_chr, 0 as windowflag_int,
                                   sum(decode(c.sid_int, null, 0, 1)) as numcount, d.lastdate
                              from t_bse_medstorewin a,
                                   (select b.sid_int, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.createdate_chr = ?
                                        and b.medstoreid_chr = ?
                                        and b.called_int = 0
                                        and b.pstatus_int in (1, 2)) c,
                                   (select max(b.senddate_dat) as lastdate, b.sendwindowid_chr
                                       from t_opr_recipesend b
                                      where b.createdate_chr = ?
                                        and b.medstoreid_chr = ?
                                        and b.pstatus_int = 3
                                      group by b.sendwindowid_chr) d
                             where a.windowid_chr = c.sendwindowid_chr(+)
                               and a.windowid_chr = d.sendwindowid_chr(+)
                               and a.medstoreid_chr = ?
                               and a.windowtype_int = 0
                               and a.workstatus_int = 1
                             group by a.windowid_chr, a.windowname_vchr, a.medstoreid_chr,
                                      d.lastdate";

                objHRPSvc.CreateDatabaseParameter(5, out paramArr);
                paramArr[0].Value = strDateTime;
                paramArr[1].Value = m_strMedStoreid;
                paramArr[2].Value = strDateTime;
                paramArr[3].Value = m_strMedStoreid;
                paramArr[4].Value = m_strMedStoreid;
                lngRegs = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref p_dtWindow, paramArr);

                if (lngRegs > 0 && p_dtWindow.Rows.Count > 0)
                {
                    if (m_blnWindowType == true)
                    {
                        p_dtWindow.DefaultView.Sort = "windowflag_int desc,numcount, lastdate";
                    }
                    else
                    {
                        p_dtWindow.DefaultView.Sort = " windowflag_int,numcount, lastdate";
                    }
                    p_dtWindow = p_dtWindow.DefaultView.ToTable();
                    DataRow drTemp = p_dtWindow.Rows[0];
                    if (m_objWindowsVo == null)
                    {
                        m_objWindowsVo = new clsMedStoreWindowsVo();
                    }
                    m_objWindowsVo.m_strSendWindowID = drTemp["windowid_chr"].ToString();
                    m_objWindowsVo.m_strSendWindowName = drTemp["windowname_vchr"].ToString();
                    m_objWindowsVo.m_intSendWindowOrderNo = int.Parse(drTemp["numcount"].ToString()) + 1;
                    p_dtWindow.Dispose();
                    p_dtWindow = null;
                    drTemp = null;
                }
                else
                {
                    m_objWindowsVo = null;
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
        #endregion 
    }
}
