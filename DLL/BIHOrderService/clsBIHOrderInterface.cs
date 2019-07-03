using System;
using com.digitalwave.iCare.middletier.HRPService;
using System.Data;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;
using System.Windows.Forms;

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
    /// <summary>
    /// 医嘱接口
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
    public class clsBIHOrderInterface : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 为进出转提供停医嘱接口－根据住院登记流水号查询是否有未停的长期医嘱
        /// <summary>
        /// 获取当前未停[审核]的长期医嘱	根据入院登记ID	
        /// 业务说明: {类型=1-长期; 执行状态=1-提交;2-执行;3-停止;5- 已审核提交;}
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="m_blHave">返回true-有,false-无</param>
        /// <returns></returns>
        /// <remark>
        /// 执行类型	{1=长期;2=临时;}
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngGetNotStopLongOrderByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out bool m_blHave)
        {
            m_blHave = false;
            long lngRes = 0;
            long lngAff = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService", "m_lngGetNotStopLongOrderByRegisterID3");
            if (lngRes < 0)
            {
                return -1;
            }
           
            string strSql = @"	
                SELECT COUNT (orderid_chr) orderid_chr
                FROM t_opr_bih_order a
                WHERE
                status_int IN (0,1,2,5)
                AND executetype_int = 1
                AND ((stoperid_chr IS NULL) OR (stopdate_dat IS NULL))
                AND registerid_chr = ?
			";

           
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strRegisterID;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtbResult, arrParams);
                objHRPSvc.Dispose();
                if (int.Parse(dtbResult.Rows[0]["orderid_chr"].ToString()) > 0)
                {
                    m_blHave = true;
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

        #region 为进出转提供停医嘱接口－获取当前是否存在 相应执行状态的长期/临时医嘱{根据入院登记ID,执行类型,执行状态}
        /// <summary>
        /// 获取当前是否存在 相应执行状态的长期/临时医嘱	根据入院登记ID	
        /// 业务说明: 输入 {执行类型 m_intExecutetype:1=长期;2=临时;} { 执行状态m_intStatus :-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 返回 True/False
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="m_intExecutetype">1=长期;2=临时;</param>
        /// <param name="m_intStatus">-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;</param>
        /// <param name="m_blHave">返回true-有,false-无</param>
        /// <returns></returns>
        /// <remark>
        /// 执行类型	{1=长期;2=临时;}
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngGetOrderByRegisterID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, int m_intExecutetype, int m_intStatus, out bool m_blHave)
        {
            m_blHave = false;
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngGetOrderByRegisterID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
                SELECT COUNT (orderid_chr) orderid_chr
                FROM t_opr_bih_order a
                WHERE
                status_int=[statusvalue]
                and
                executetype_int=[executetypevalue]
                AND ((stoperid_chr IS NULL) OR (stopdate_dat IS NULL))
                AND registerid_chr = '[REGISTERIDVALUE]'
			";
            strSql = strSql.Replace("[statusvalue]", m_intStatus.ToString());
            strSql = strSql.Replace("[executetypevalue]", m_intExecutetype.ToString());
            strSql = strSql.Replace("[REGISTERIDVALUE]", p_strRegisterID);
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSql, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    if (int.Parse(dtbResult.Rows[0]["orderid_chr"].ToString()) > 0)
                    {
                        m_blHave = true;
                    }
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

        #region  查询当前是否有医嘱还没有执行的
        /// <summary>
        /// 查询当前是否有医嘱还没有执行的
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">病人登记号</param>
        /// <param name="m_intCount">数目</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNotExecuteOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID,out int m_intCount)
        {

            long lngRes = 0;
            m_intCount = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            DataTable dtResult = new DataTable();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService", "m_lngStopANDAuditingOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
				select count(ORDERID_CHR) ORDERID_CHR From T_Opr_Bih_Order
				where status_int IN (0,1,5,7)
                and   REGISTERID_CHR=?
			";
            System.Data.IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = p_strRegisterID;
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        if (!dtResult.Rows[0]["ORDERID_CHR"].ToString().Trim().Equals(""))
                        {
                            m_intCount = int.Parse(dtResult.Rows[0]["ORDERID_CHR"].ToString());
                        }
                    }
                    
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

        #region  查询当前是否有新开,提交,转抄,执行等(未停)的医嘱
        /// <summary>
        /// 查询当前是否有新开,提交,转抄,执行等(未停)的医嘱
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">病人登记号</param>
        /// <param name="m_intCount">数目</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNotStopOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out int m_intCount)
        {

            long lngRes = 0;
            m_intCount = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            DataTable dtResult = new DataTable();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngGetNotStopOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
				select count(ORDERID_CHR) ORDERID_CHR From T_Opr_Bih_Order
				where
                ((status_int IN (0,1,5,7)) or (EXECUTETYPE_INT=1 and status_int=2))
                and   REGISTERID_CHR=?
			";
            System.Data.IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = p_strRegisterID;
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        if (!dtResult.Rows[0]["ORDERID_CHR"].ToString().Trim().Equals(""))
                        {
                            m_intCount = int.Parse(dtResult.Rows[0]["ORDERID_CHR"].ToString());
                        }
                    }
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

        #region  查询当前是否有新开,提交,转抄,执行等(未停)的医嘱
        /// <summary>
        /// 查询当前是否有新开,提交,转抄,执行等(未停)的医嘱
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">病人登记号</param>
        /// <param name="m_intCount">数目</param>
        /// <param name="m_arrCreator">有新开医嘱的医生列表</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetNotStopOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out int m_intCount,out ArrayList m_arrCreator)
        {

            long lngRes = 0;
            m_intCount = 0;
            string m_strCREATOR_CHR = "";
            //新开医嘱的医生姓名列表
            m_arrCreator = new ArrayList();
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            DataTable dtResult = new DataTable();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngGetNotStopOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
				select ORDERID_CHR,STATUS_INT,CREATOR_CHR From T_Opr_Bih_Order
				where
                status_int IN (0,1,5)
                and   REGISTERID_CHR=?
			";
            System.Data.IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = p_strRegisterID;
            try
            {
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        m_intCount = dtResult.Rows.Count;
                        DataView myDataView = new DataView(dtResult);
                        //统计可提交医嘱数目
                        /*<===========================*/
                        myDataView.RowFilter = "status_int=0";
                        for (int i = 0; i < myDataView.Count; i++)
                        {
                            m_strCREATOR_CHR = myDataView[i]["CREATOR_CHR"].ToString().Trim();
                            if (!m_arrCreator.Contains(m_strCREATOR_CHR.Trim()))
                            {
                                m_arrCreator.Add(m_strCREATOR_CHR);
                            }
                        }
                       
                       
                    }
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

        #region 为进出转提供停医嘱接口－根据住院登记流水号停医嘱(转区)
        /// <summary>
        /// 根据住院登记流水号停医嘱
        /// 业务说明: {类型=1-长期; 执行状态=1-提交;2-执行;3-停止;5- 已审核提交;}
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_strHandlersID">处理者ID</param>
        /// <param name="p_strHandlers">处理者名称</param>
        /// <returns></returns>
        /// <remark>
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngStopANDAuditingOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, string p_strHandlersID, string p_strHandlers)
        {

            long lngRes = 0;
            long lngAff = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService", "m_lngStopANDAuditingOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
          
            try
            {

                //同步更新执行单表
                string strSql = @"	
			    update T_Opr_Bih_Order
			    set OPERATION_INT=1
			    where
                EXECUTETYPE_INT=1
                and
                REGISTERID_CHR=?
		        ";

                System.Data.IDataParameter[] arrParams3 = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams3);
                arrParams3[0].Value = p_strRegisterID;

                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams3);
                //同步更新执行单表
                strSql = @"
			    update t_opr_bih_orderexecute b
                set b.executedate_vchr='已停止'
                where
                b.orderid_chr in (
                select a.orderid_chr from  T_Opr_Bih_Order a
				where
                a.status_int =2
                and a.EXECUTETYPE_INT=1
                and a.REGISTERID_CHR=?)";

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strRegisterID;

                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);

                strSql = @"	
				update T_Opr_Bih_Order
				set Status_Int = 6 ,StoperID_Chr=CREATORID_CHR, Stoper_Chr =CREATOR_CHR ,StopDate_Dat =sysdate,FINISHDATE_DAT =sysdate,ASSESSORIDFORSTOP_CHR=?,ASSESSORFORSTOP_CHR=?,ASSESSORFORSTOP_DAT=sysdate
				where
                EXECUTETYPE_INT=1 and status_int=2
                and   REGISTERID_CHR=?
			    ";
                System.Data.IDataParameter[] arrParams2 = null;
                objHRPSvc.CreateDatabaseParameter(3, out arrParams2);
                arrParams2[0].Value = p_strHandlersID;
                arrParams2[1].Value = p_strHandlers;
                arrParams2[2].Value = p_strRegisterID;
                
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams2);
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

        #region 为进出转提供停医嘱接口－根据住院登记流水号停止所有长期医嘱/临嘱
        /// <summary>
        /// 根据住院登记流水号停止所有长期医嘱
        /// 业务说明: {类型=1-长期;2-临嘱; 执行状态=1-提交;2-执行;3-停止;5- 已审核提交;}
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_strHandlersID">处理者ID</param>
        /// <param name="p_strHandlers">处理者名称</param>
        /// <param name="m_dtStopDate">停嘱时间</param>
        /// <param name="m_intEXECUTETYPE">1-停长嘱,2-停临嘱</param>
        /// <returns></returns>
        /// <remark>
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// </remark>
        [AutoComplete]
        public long m_lngStopOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, string p_strHandlersID, string p_strHandlers,DateTime m_dtStopDate,int m_intEXECUTETYPE)
        {

            long lngRes = 0;
            long lngAff = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngStopOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
            string strSql = @"	
				update T_Opr_Bih_Order
				set Status_Int = 3 , StoperID_Chr='[p_strHandlersID]', Stoper_Chr = '[p_strHandlers]' ,StopDate_Dat =to_date('" + m_dtStopDate.ToString("yyyy-MM-dd HH:mm:ss") + @"','yyyy-mm-dd hh24:mi:ss'),FINISHDATE_DAT =sysdate,OPERATION_INT=1
				where
                status_int IN (0,1,2,5,7)
                and EXECUTETYPE_INT=[m_intEXECUTETYPE]
                and   REGISTERID_CHR='[p_strRegisterID]'
			";
            //System.Data.IDataParameter[] arrParams = null;
            //objHRPSvc.CreateDatabaseParameter(4, out arrParams);
            //arrParams[0].Value = p_strHandlersID;
            //arrParams[1].Value = p_strHandlers;
            //arrParams[2].Value = m_intEXECUTETYPE;
            //arrParams[3].Value = p_strRegisterID;
            strSql = strSql.Replace("[p_strHandlersID]", p_strHandlersID);
            strSql = strSql.Replace("[p_strHandlers]", p_strHandlers);
            strSql = strSql.Replace("[m_intEXECUTETYPE]", m_intEXECUTETYPE.ToString());
            strSql = strSql.Replace("[p_strRegisterID]", p_strRegisterID);

            try
            {
                lngRes = 0;
               // lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);
                lngRes = objHRPSvc.DoExcute(strSql);
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

        #region 为进出转提供停长医嘱接口(出院)
        
        [AutoComplete]
        public long m_lngStopOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, string p_strHandlersID, string p_strHandlers, DateTime m_dtStopDate)
        {

            long lngRes = 0;
            long lngAff = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngStopOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }
           
            try
            {
                //同步更新执行单表
                string strSql = @"	
			    update T_Opr_Bih_Order
			    set OPERATION_INT=1
			    where
                EXECUTETYPE_INT=1
                and
                REGISTERID_CHR=?
		        ";

                System.Data.IDataParameter[] arrParams3 = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams3);
                arrParams3[0].Value = p_strRegisterID;

                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams3);
                //同步更新执行单表
                strSql = @"
			    update t_opr_bih_orderexecute b
                set b.executedate_vchr='已停止'
                where
                b.orderid_chr in (
                select a.orderid_chr from  T_Opr_Bih_Order a
				where
                a.status_int =2
                and a.EXECUTETYPE_INT=1
                and a.REGISTERID_CHR=?)";
                
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strRegisterID;
            
                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams);
              

                    strSql = @"	
			    update T_Opr_Bih_Order
			    set Status_Int = 6 , StoperID_Chr=CREATORID_CHR, Stoper_Chr =CREATOR_CHR ,StopDate_Dat =to_date('" + m_dtStopDate.ToString("yyyy-MM-dd HH:mm:ss") + @"','yyyy-mm-dd hh24:mi:ss'),FINISHDATE_DAT =sysdate,ASSESSORIDFORSTOP_CHR=?,ASSESSORFORSTOP_CHR=?,ASSESSORFORSTOP_DAT=sysdate,OPERATION_INT=1
			    where
                status_int =2
                and EXECUTETYPE_INT=1
                and   REGISTERID_CHR=?
		        ";
                System.Data.IDataParameter[] arrParams2 = null;
                objHRPSvc.CreateDatabaseParameter(3, out arrParams2);
                arrParams2[0].Value = p_strHandlersID;
                arrParams2[1].Value = p_strHandlers;
                arrParams2[2].Value = p_strRegisterID;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSql, ref lngAff, arrParams2);

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

        #region  查询当前病区是否已全区发送完毕
        /// <summary>
        /// 查询当前病区是否已全区发送完毕
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strAreaId">查询病区</param>
        /// <param name="ifAll">标志(false-全区未全发送,true-全区已发送)</param>
        /// <returns></returns>
        [AutoComplete]
        public long IsAllPatSend(System.Security.Principal.IPrincipal p_objPrincipal, string m_strAreaId,out bool ifAll)
        {

            long lngRes = 0;
            int newCount = 0;
            int needCount = 0;
            ifAll = true;
            //新开医嘱的医生姓名列表
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            DataTable dtResult = new DataTable();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngGetNotStopOrderByRegID");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSql = "";

//            string strSql = @"	
//        select(
//                select count(a.orderid_chr) from 
//                t_opr_bih_order a,
//                t_opr_bih_register b,
//                T_Opr_Bih_OrderExecute c
//                where
//                a.registerid_chr=b.registerid_chr
//                and
//                a.orderid_chr=c.orderid_chr(+)
//                and
//                a.status_int in(0,1,5) 
//                and
//                b.areaid_chr=?
//                )  newCount,
//
//                (
//                select count(a.orderid_chr) from 
//                t_opr_bih_order a,
//                t_opr_bih_register b,
//                T_Opr_Bih_OrderExecute c
//                where
//                a.registerid_chr=b.registerid_chr
//                and
//                a.orderid_chr=c.orderid_chr
//                and
//                c.NEEDCONFIRM_INT=1
//                and
//                c.isincept_int=0
//                and
//                b.areaid_chr=?
//                )  needCount
//             from dual
//			";
//            System.Data.IDataParameter[] arrParams = null;
//            objHRPSvc.CreateDatabaseParameter(2, out arrParams);
//            arrParams[0].Value = m_strAreaId;
//            arrParams[1].Value = m_strAreaId;
            try
            {
                strSql = @"select count(a.orderid_chr) as nums 
                             from t_opr_bih_order a,
                                  t_opr_bih_register b                                  
                            where a.registerid_chr = b.registerid_chr                                
                              and (a.status_int = 0 or a.status_int = 1 or a.status_int = 5) 
                              and b.areaid_chr = ?";

                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strAreaId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    newCount = int.Parse(dtResult.Rows[0][0].ToString());
                }

                strSql = @" select count (a.orderid_chr) as nums
                              from t_opr_bih_order a, 
                                   t_opr_bih_orderexecute c
                             where a.orderid_chr = c.orderid_chr
                               and c.needconfirm_int = 1
                               and c.isincept_int = 0
                               and c.exeareaid_chr = ?";

                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strAreaId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    needCount = int.Parse(dtResult.Rows[0][0].ToString());
                }

                if (newCount > 0 || needCount > 0)
                {
                    ifAll = false;
                }

                //if (lngRes > 0)
                //{
                //    if (dtResult.Rows.Count > 0)
                //    {
                //        newCount = int.Parse(dtResult.Rows[0]["newCount"].ToString().Trim());
                //        needCount = int.Parse(dtResult.Rows[0]["needCount"].ToString().Trim());
                //        if (newCount > 0 || needCount > 0)
                //        {
                //            ifAll = false;
                //        }
                //    }
                //}

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

        #region 增加医嘱嘱托
       /// <summary>
        /// 增加医嘱嘱托
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="m_arrClsOrderdescVO"></param>
       /// <returns></returns>
        [AutoComplete]
        public long m_lngAddNewOrderdescVO(System.Security.Principal.IPrincipal p_objPrincipal, clsOrderdescVO[] m_arrClsOrderdescVO)
        {

            long lngRes = 0;
            long lngAff = 0;
            try
            {
                clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.clsMiddleTierBase.clsBIHOrderInterface", "m_lngAddNewOrderdescVO");
                if (lngRes < 0)
                {
                    return -1;
                }
                int lenCount=m_arrClsOrderdescVO.Length;
                #region 获取嘱托号
                string strSQL2 = @"  
                        select GETSEQ('SEQ_ORDERDESC',[rownum]) DescID from dual
                        ";
                strSQL2 = strSQL2.Replace("[rownum]", lenCount.ToString());
                DataTable dtbResult2 = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2, ref dtbResult2);
                long SEQ_ORDERDESCID = 0;
                if (lngRes > 0)
                {
                    SEQ_ORDERDESCID = long.Parse(dtbResult2.Rows[0]["DescID"].ToString().Trim()) - lenCount;
           
                }
                for (int i = 0; i < lenCount; i++)
                {
                    SEQ_ORDERDESCID++;
                    m_arrClsOrderdescVO[i].strDescID = SEQ_ORDERDESCID.ToString();
                }
                #endregion

                string strSql = @"	
				INSERT INTO T_OPR_BIH_ORDERDESC
                 (DESCID_INT, DESC_VCHR, USERCODE_VCHR, WBCODE_VCHR, PYCODE_CHR, CREATORID_CHR, CREAT_DAT)
                  VALUES (:1, :2, :3, :4, :5, :6, SYSDATE)
			";
                DbType[] dbTypes = null;
                dbTypes = new DbType[] { 
                        DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,DbType.String,
                        };
                object[][] objValues = new object[6][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[m_arrClsOrderdescVO.Length];//初始化
                }
                int n = 0;
                for (int k1 = 0; k1 < lenCount; k1++)
                {

                    n = -1;
                    //流水号
                    objValues[++n][k1] = m_arrClsOrderdescVO[k1].strDescID;
                    objValues[++n][k1] = m_arrClsOrderdescVO[k1].strDesc;
                    objValues[++n][k1] = m_arrClsOrderdescVO[k1].strUserCode;
                    objValues[++n][k1] = m_arrClsOrderdescVO[k1].strWbCode;
                    objValues[++n][k1] = m_arrClsOrderdescVO[k1].strPyCode;
                    objValues[++n][k1] = m_arrClsOrderdescVO[k1].strEmpID;



                }

                if (m_arrClsOrderdescVO.Length > 0)
                {
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSql, objValues, dbTypes);
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

        #region 新增常用医嘱项目
        /// <summary>
        ///新增常用医嘱项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_arrOrderdic">常用医嘱项目VO</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddOrderNornal(System.Security.Principal.IPrincipal p_objPrincipal, clsComuseorderdic[] m_arrOrderdic)
        {

            long lngRes = 0;
            long lngAff = 0;
            try
            {
                clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer", "m_lngAddOrderNornal");
                if (lngRes < 0)
                {
                    return -1;
                }
                int lenCount = m_arrOrderdic.Length;
                #region 获取嘱托号
                string strSQL2 = @"  
                        select GETSEQ('seq_comuseid',[rownum]) comuseid from dual
                        ";
                strSQL2 = strSQL2.Replace("[rownum]", lenCount.ToString());
                DataTable dtbResult2 = new DataTable();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2, ref dtbResult2);
                long seq_comuseid = 0;
                if (lngRes > 0)
                {
                    seq_comuseid = long.Parse(dtbResult2.Rows[0]["comuseid"].ToString().Trim()) - lenCount;

                }
                for (int i = 0; i < lenCount; i++)
                {
                    seq_comuseid++;
                    m_arrOrderdic[i].m_strSEQID_CHR = seq_comuseid.ToString().PadLeft(10, '0');
                }
                #endregion

                string strSql = @"	
				insert into t_aid_bih_comuseorderdic
			    (seqid_chr,CREATE_DAT, DEPTID_CHR ,ORDERDICID_CHR ,CREATERID_CHR, privilege_int,TYPE_INT,DES_VCHR)
				values
				(?,sysdate,?,?,?,?,?,?)
			   ";
                DbType[] dbTypes = null;
                dbTypes = new DbType[] { 
                        DbType.String,DbType.String,DbType.String,DbType.String,DbType.Int32,DbType.Int32,DbType.String
                        };
                object[][] objValues = new object[7][];
                for (int j = 0; j < objValues.Length; j++)
                {
                    objValues[j] = new object[lenCount];//初始化
                }
                int n = 0;
                for (int k1 = 0; k1 < lenCount; k1++)
                {

                    n = -1;
                    //流水号
                    objValues[++n][k1] = m_arrOrderdic[k1].m_strSEQID_CHR;
                    objValues[++n][k1] = m_arrOrderdic[k1].m_strDEPTID_CHR;
                    objValues[++n][k1] = m_arrOrderdic[k1].m_strORDERDICID_CHR;
                    objValues[++n][k1] = m_arrOrderdic[k1].m_strCREATERID_CHR;
                    objValues[++n][k1] = m_arrOrderdic[k1].m_intPRIVILEGE_INT;
                    objValues[++n][k1] = m_arrOrderdic[k1].m_intTYPE_INT;
                    objValues[++n][k1] = m_arrOrderdic[k1].m_strDES_VCHR;


                }

                if (m_arrOrderdic.Length > 0)
                {
                    lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSql, objValues, dbTypes);
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

        #region 重整方号
        /// <summary>
        /// 重整方号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strRegisterid">病人流水登记号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngReSortOrderNO(System.Security.Principal.IPrincipal p_objPrincipal, string m_strRegisterid)
        {
            long lngRes = 0;
            long lngAff = 0;
            try
            {
                clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface", "m_lngReSortOrderNO");
                if (lngRes < 0)
                {
                    return -1;
                }
                string strSql = @"  
                        select a.orderid_chr,RECIPENO_INT from  T_Opr_Bih_Order a where  
                        EXECUTETYPE_INT=1 AND  OPERATION_INT <>1 AND STATUS_INT<>-2
                        AND REGISTERID_CHR=?
                        order by a.recipeno_int,a.orderid_chr
                        ";
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_strRegisterid;
                DataTable dtbResult = new DataTable();
                long ret = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtbResult, arrParams);
                if (ret > 0 && dtbResult.Rows.Count>0)
                {
                    string[] m_arrOrderID = new string[dtbResult.Rows.Count];
                    string[] m_arrRECIPENO = new string[dtbResult.Rows.Count];
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        m_arrOrderID[i] = dtbResult.Rows[i]["orderid_chr"].ToString().Trim();
                        m_arrRECIPENO[i] = dtbResult.Rows[i]["RECIPENO_INT"].ToString().Trim();
                    }

                    int lenCount = m_arrOrderID.Length;

                     strSql = @"	
			     	update T_Opr_Bih_Order set recipeno2_int=? where orderid_chr=?
			        ";
                    DbType[] dbTypes = null;
                    dbTypes = new DbType[] { 
                        DbType.Int32,DbType.String
                        };
                    object[][] objValues = new object[2][];
                    for (int j = 0; j < objValues.Length; j++)
                    {
                        objValues[j] = new object[lenCount];//初始化
                    }
                    int n = 0,m=1;
                    for (int k1 = 0; k1 < lenCount; k1++)
                    {
                        n = -1;
                        //流水号
                        objValues[++n][k1] = m;
                        objValues[++n][k1] = m_arrOrderID[k1];
                        if (k1>0&&m_arrRECIPENO[k1].Equals(m_arrRECIPENO[k1 - 1]))//父子医嘱
                        {
                            objValues[0][k1] = m-1;
                            continue;
                        }
                        m++;
                    }
                    if (m_arrOrderID.Length > 0)
                    {
                        lngRes = objHRPSvc.m_lngSaveArrayWithParameters(strSql, objValues, dbTypes);
                    }
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

        /// <summary>
        /// 获取需要停用或停药的待过滤的医嘱
        /// </summary>
        /// <param name="m_arrOrders"></param>
        /// <param name="m_dtOrderSign"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderStopSign(string[] m_arrOrders,  out DataTable m_dtOrderSign)
        {
            long lngRes = -1;
            m_dtOrderSign = null;
                        
            string SQL = @"select a.orderid_chr, b.status_int, d.ifstop_int, d.itemsrctype_int,
                                   e.ipnoqtyflag_int
                              from t_opr_bih_order a,
                                   t_bse_bih_orderdic b,
                                   t_opr_bih_orderchargedept c,
                                   t_bse_chargeitem d,
                                   t_bse_medicine e
                             where a.orderdicid_chr = b.orderdicid_chr
                               and a.orderid_chr = c.orderid_chr(+)
                               and c.chargeitemid_chr = d.itemid_chr(+)
                               and d.itemsrcid_vchr = e.medicineid_chr(+)
                               and a.orderid_chr in ([orderid_chr])";
            string Tmp = "";
            DataTable dt = new DataTable();

            try
            {
                clsHRPTableService HRPService = new clsHRPTableService();

                for (int i = 0; i < m_arrOrders.Length; i++)
                {
                    Tmp += "'" + m_arrOrders[i].ToString() + "',";

                    if (i > 0 && i % 100 == 0)
                    {
                        Tmp = Tmp.Substring(0, Tmp.Length - 1);
                                         
                        string s = SQL.Replace("[orderid_chr]", Tmp);
                        
                        lngRes = HRPService.lngGetDataTableWithoutParameters(s, ref dt);
                        if (m_dtOrderSign == null)
                        {
                            m_dtOrderSign = dt.Clone();
                        }

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            m_dtOrderSign.Rows.Add(dt.Rows[j].ItemArray);
                        }
                        m_dtOrderSign.AcceptChanges();

                        Tmp = "";
                    }
                }

                if (Tmp.Trim() != "")
                {
                    Tmp = Tmp.Substring(0, Tmp.Length - 1);
                    string s = SQL.Replace("[orderid_chr]", Tmp);

                    lngRes = HRPService.lngGetDataTableWithoutParameters(s, ref dt);
                    if (m_dtOrderSign == null)
                    {
                        m_dtOrderSign = dt.Clone();
                    }

                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        m_dtOrderSign.Rows.Add(dt.Rows[j].ItemArray);
                    }
                    m_dtOrderSign.AcceptChanges();
                }              

                HRPService.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;


            #region 
//            string strUnion = " union all ";
//            string strSql2 = "";
//            string strSql = @"select a.orderid_chr, b.status_int, d.ifstop_int, d.itemsrctype_int,
//                                       e.ipnoqtyflag_int
//                                  from t_opr_bih_order a,
//                                       t_bse_bih_orderdic b,
//                                       t_opr_bih_orderchargedept c,
//                                       t_bse_chargeitem d,
//                                       t_bse_medicine e
//                                 where a.orderdicid_chr = b.orderdicid_chr
//                                   and a.orderid_chr = c.orderid_chr(+)
//                                   and c.chargeitemid_chr = d.itemid_chr(+)
//                                   and d.itemsrcid_vchr = e.medicineid_chr(+)
//                                   and a.orderid_chr in ([orderid_chr])";
//            try
//            {
//                string orderid_chr = "";
//                for (int i = 0; i < m_arrOrders.Length; i++)
//                {
//                    orderid_chr += "'" + m_arrOrders[i].ToString().Trim() + "'";
//                    orderid_chr += ",";
//                    if (i>0&&i % 100 == 0)
//                    {
//                        orderid_chr = orderid_chr.TrimEnd(",".ToCharArray());
//                        strSql2 += strSql.Replace("[orderid_chr]", orderid_chr) + strUnion;
//                        orderid_chr = "";
//                    }
//                }
//                if (!orderid_chr.Trim().Equals(""))
//                {
//                    orderid_chr = orderid_chr.TrimEnd(",".ToCharArray());
//                    strSql2 += strSql.Replace("[orderid_chr]", orderid_chr);
//                }
//                 strSql2= strSql2.TrimEnd(strUnion.ToCharArray());
//                clsHRPTableService HRPService = new clsHRPTableService();
//                lngRes = 0;
//                lngRes = HRPService.lngGetDataTableWithoutParameters(strSql2,ref m_dtOrderSign);
              
//                HRPService.Dispose();

//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }

//            return lngRes;
            #endregion
        }


        /// <summary>
        /// 获取需要停用或停药的待过滤的医嘱(不用in) 2007-5-8
        /// </summary>
        /// <param name="m_lngMotion_id_int"></param>
        /// <param name="m_dtOrderSign"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderStopSign(long m_lngMotion_id_int, out DataTable m_dtOrderSign)
        {

            long lngRes = -1;
            m_dtOrderSign = null;
            string strSql = @"select a.orderid_chr, b.status_int, d.ifstop_int, d.itemsrctype_int,
                                       e.ipnoqtyflag_int
                                  from t_opr_bih_order a,
                                       t_bse_bih_orderdic b,
                                       t_opr_bih_orderchargedept c,
                                       t_bse_chargeitem d,
                                       t_bse_medicine e,
                                       t_aid_bih_motion mon
                                 where a.orderdicid_chr = b.orderdicid_chr
                                   and a.orderid_chr = c.orderid_chr(+)
                                   and c.chargeitemid_chr = d.itemid_chr(+)
                                   and d.itemsrcid_vchr = e.medicineid_chr(+)
                                   and mon.orderid_chr = a.orderid_chr
                                   and motion_id_int = ?";
            try
            {
              
                clsHRPTableService HRPService = new clsHRPTableService();
                System.Data.IDataParameter[] arrParams = null;
                HRPService.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = m_lngMotion_id_int;
                lngRes = 0;
                lngRes = HRPService.lngGetDataTableWithParameters(strSql, ref m_dtOrderSign, arrParams);
                HRPService.Dispose();

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
        /// 获取需要检验打折认证的过滤医嘱
        /// </summary>
        /// <param name="m_arrOrders"></param>
        /// <param name="m_dtOrderSign"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOrderLisSign(string[] m_arrOrders, out DataTable m_dtOrderSign)
        {

            long lngRes = -1;
            m_dtOrderSign = null;
            string orderid_chr = "";
            for (int i = 0; i < m_arrOrders.Length; i++)
            {
                orderid_chr += "'" + m_arrOrders[i].ToString().Trim() + "'";
                orderid_chr += ",";
            }
            orderid_chr = orderid_chr.TrimEnd(",".ToCharArray());

            string strSql = @"
             select 
            a.orderid_chr,
            b.AMOUNT_DEC,
            b.UNITPRICE_DEC,
            c.ItemIpInvType_Chr,
            b.FLAG_INT
            from
            t_opr_bih_order  a,
            T_OPR_BIH_ORDERCHARGEDEPT b,
            t_bse_chargeitem c
            where 
            a.orderid_chr=b.orderid_chr
            and
            b.CHARGEITEMID_CHR=c.ITEMID_CHR
            and
            a.orderid_chr in ([orderid_chr])
             ";
            try
            {
                strSql = strSql.Replace("[orderid_chr]", orderid_chr);
                clsHRPTableService HRPService = new clsHRPTableService();
                lngRes = 0;
                lngRes = HRPService.lngGetDataTableWithoutParameters(strSql, ref m_dtOrderSign);

                HRPService.Dispose();

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        #region  查询当前当前病人的出院医嘱
        /// <summary>
        /// 查询当前当前病人的出院医嘱
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID">病人登记流水号</param>
        /// <param name="m_dtOutOrder">返回出院医嘱表(字段：EXECUTETYPE 医嘱类型,NAME_VCHR   医嘱内容(名称),REMARK_VCHR 医嘱说明,RECIPENO2_INT 医嘱方号)</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetOutOrderByRegID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strRegisterID, out DataTable m_dtOutOrder)
        {

            long lngRes = 0;
            string strSql = "";
            DataTable dtResult=new DataTable();
            m_dtOutOrder = null;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            
         
            try
            {
                strSql = @"select   a.recipeno_int
                                from t_opr_bih_order a
                               where (a.type_int = 3 or a.type_int = 4)
                                 and a.status_int <> -2
                                 and a.registerid_chr = ?
                            order by recipeno_int desc";
                System.Data.IDataParameter[] arrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strRegisterID;
                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                {
                    int RECIPENO_INT = 0;
                    int.TryParse(dtResult.Rows[0]["RECIPENO_INT"].ToString().Trim(),out RECIPENO_INT);
                    if (RECIPENO_INT <= 0)
                    {
                        return lngRes;
                    }
                    strSql = @"select   sysdate, trunc (sysdate) today, trunc (a.createdate_dat) creatday,
                                     c.sample_type_desc_vchr, d.partname, e.ordercateid_chr,
                                     e.itemid_chr chargeitemid_chr, e.lisapplyunitid_chr,
                                     e.applytypeid_chr, e.name_chr dicname, a.orderid_chr,
                                     a.orderdicid_chr, a.registerid_chr, a.patientid_chr,
                                     a.executetype_int, a.recipeno_int, a.name_vchr, a.spec_vchr,
                                     a.execfreqid_chr, a.dosage_dec, a.execfreqname_chr, a.dosageunit_chr,
                                     a.get_dec, a.useunit_chr, a.getunit_chr, a.dosetypeid_chr,
                                     a.dosetypename_chr, a.startdate_dat, a.finishdate_dat,
                                     a.execdeptid_chr, a.execdeptname_chr, a.entrust_vchr, a.parentid_chr,
                                     a.status_int, a.creatorid_chr, a.creator_chr, a.createdate_dat,
                                     a.posterid_chr, a.poster_chr, a.postdate_dat, a.executorid_chr,
                                     a.executor_chr, a.executedate_dat, a.stoperid_chr, a.stoper_chr,
                                     a.stopdate_dat, a.retractorid_chr, a.retractor_chr,
                                     a.retractdate_dat, a.isrich_int, a.ratetype_int, a.isrepare_int,
                                     a.use_dec, a.isneedfeel, a.outgetmeddays_int,
                                     a.assessoridforexec_chr, a.assessorforexec_chr,
                                     a.assessorforexec_dat, a.assessoridforstop_chr,
                                     a.assessorforstop_chr, a.assessorforstop_dat, a.backreason,
                                     a.sendbackid_chr, a.sendbacker_chr, a.sendback_dat, a.isyb_int,
                                     a.sampleid_vchr, a.lisappid_vchr, a.partid_vchr, a.createareaid_chr,
                                     a.createareaname_vchr, a.ifparentid_int, a.confirmerid_chr,
                                     a.confirmer_vchr, a.confirm_dat, a.attachtimes_int, a.doctorid_chr,
                                     a.doctor_vchr, a.curareaid_chr, a.curbedid_chr, a.doctorgroupid_chr,
                                     a.deleterid_chr, a.deletername_vchr, a.delete_dat, a.sign_int,
                                     a.operation_int, a.remark_vchr, a.recipeno2_int, a.feelresult_vchr,
                                     a.feel_int, a.charge_int, a.type_int, a.singleamount_dec,
                                     a.sourcetype_int
                                from t_opr_bih_order a,
                                     t_aid_lis_sampletype c,
                                     ar_apply_partlist d,
                                     t_bse_bih_orderdic e
                               where a.sampleid_vchr = c.sample_type_id_chr(+)
                                 and a.partid_vchr = d.partid(+)
                                 and a.orderdicid_chr = e.orderdicid_chr(+)
                                 and a.status_int <> -2
                                 and a.recipeno_int > ?
                                 and a.registerid_chr = ?
                            order by recipeno_int, orderid_chr";

                    System.Data.IDataParameter[] arrParams2 = null;
                    objHRPSvc.CreateDatabaseParameter(2, out arrParams2);
                    arrParams2[0].Value = RECIPENO_INT;
                    arrParams2[1].Value = p_strRegisterID;
                    lngRes = 0;
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams2);
                    if (lngRes > 0 && dtResult.Rows.Count > 0)
                    {
                        //医嘱类型控制表
                        clsT_aid_bih_ordercate_VO[] p_objItemArr = null;
                        com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc ChargeSvc = new com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc();
                        lngRes = ChargeSvc.m_lngGetAidOrderCate(p_objPrincipal, "", out p_objItemArr);
                        Hashtable m_htOrderCate = new Hashtable();//医嘱类型控制表
                        for (int i = 0; i < p_objItemArr.Length; i++)
                        {
                            if (!m_htOrderCate.Contains(p_objItemArr[i].m_strORDERCATEID_CHR))
                            {
                                m_htOrderCate.Add(p_objItemArr[i].m_strORDERCATEID_CHR, p_objItemArr[i]);
                            }
                        }
                        /*<===================================*/
                        //医嘱特殊配置表
                        clsSPECORDERCATE m_objSpecateVo;
                        com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = new clsBIHOrderService();
                        objSvc.m_lngAddGetSPECORDERCATE(out m_objSpecateVo);
                        /*<====================================*/
                        m_dtOutOrder = new DataTable();
                        m_dtOutOrder.Columns.Add("EXECUTETYPE", typeof(string));//医嘱类型
                        m_dtOutOrder.Columns.Add("NAME_VCHR", typeof(string));//医嘱内容(名称)
                        m_dtOutOrder.Columns.Add("REMARK_VCHR", typeof(string));//医嘱说明
                        m_dtOutOrder.Columns.Add("RECIPENO2_INT", typeof(string));//医嘱方号
                        
                        
                        string EXECUTETYPE = "";
                        string m_strOrderDicCateID = "", m_strOrderDicCateName="";
                        string m_strExecFreqID = "", m_strEXECFREQNAME_CHR = "", m_strDOSAGE_DEC="", m_strDosageUnit="";
                        string m_strDOSETYPEID_CHR = "", m_strDOSETYPENAME_CHR = "";
                        string m_strGET_DEC = "", m_strGETUNIT_CHR="";
                        //出院带药天数
                        string m_strOUTGETMEDDAYS_INT = "";
                        decimal m_dmlOneUse = 0, m_dmlGet=0;
                        int m_intExecuteType = -1, m_intOUTGETMEDDAYS_INT = 0, m_intISNEEDFEEL = 0, m_intFEEL_INT = 0, m_intCHARGE_INT = 0, m_intATTACHTIMES_INT = 0, m_intRECIPENO2_INT=0;
                        string m_strSum = "",RECIPENO2_INT="", m_strNAME_VCHR = "", m_strFeel = "", m_strREMARK_VCHR = "";
                        for (int i = 0; i < dtResult.Rows.Count; i++)
                        {
                            
                            int.TryParse(dtResult.Rows[i]["EXECUTETYPE_INT"].ToString().Trim(), out m_intExecuteType);
                            //长/临/带
                            switch (m_intExecuteType)
                            {
                                case 1:
                                    EXECUTETYPE = "长期";
                                    break;
                                case 2:
                                    EXECUTETYPE = "临时";
                                    break;
                                case 3:
                                    EXECUTETYPE = "带药";
                                    break;
                                default:
                                    EXECUTETYPE = "";
                                    break;

                            }

                            m_strNAME_VCHR = dtResult.Rows[i]["NAME_VCHR"].ToString().Trim();
                            m_strREMARK_VCHR = dtResult.Rows[i]["REMARK_VCHR"].ToString().Trim();
                          
                            m_strOrderDicCateID = dtResult.Rows[i]["ordercateid_chr"].ToString().Trim();
                            m_strExecFreqID = dtResult.Rows[i]["EXECFREQID_CHR"].ToString().Trim();
                            m_strEXECFREQNAME_CHR = dtResult.Rows[i]["EXECFREQNAME_CHR"].ToString().Trim();
                          
                            m_strDOSAGE_DEC = dtResult.Rows[i]["DOSAGE_DEC"].ToString().Trim();
                            m_strDosageUnit = dtResult.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();

                            m_strDOSETYPEID_CHR = dtResult.Rows[i]["DOSETYPEID_CHR"].ToString().Trim();
                            m_strDOSETYPENAME_CHR = dtResult.Rows[i]["DOSETYPENAME_CHR"].ToString().Trim();

                            m_strGET_DEC = dtResult.Rows[i]["GET_DEC"].ToString().Trim();
                            m_strGETUNIT_CHR = dtResult.Rows[i]["GETUNIT_CHR"].ToString().Trim();

                            //m_strOUTGETMEDDAYS_INT = dtResult.Rows[i]["GETUNIT_CHR"].ToString().Trim();
                            decimal.TryParse(dtResult.Rows[i]["GET_DEC"].ToString().Trim(),out m_dmlGet);
                            decimal.TryParse(dtResult.Rows[i]["SINGLEAMOUNT_DEC"].ToString().Trim(),out m_dmlOneUse);
                            int.TryParse(dtResult.Rows[i]["OUTGETMEDDAYS_INT"].ToString().Trim(),out m_intOUTGETMEDDAYS_INT);
                            int.TryParse(dtResult.Rows[i]["ISNEEDFEEL"].ToString().Trim(),out m_intISNEEDFEEL);
                            int.TryParse(dtResult.Rows[i]["FEEL_INT"].ToString().Trim(),out m_intFEEL_INT);
                            int.TryParse(dtResult.Rows[i]["CHARGE_INT"].ToString().Trim(), out m_intCHARGE_INT);
                            int.TryParse(dtResult.Rows[i]["ATTACHTIMES_INT"].ToString().Trim(), out m_intATTACHTIMES_INT);
                            int.TryParse(dtResult.Rows[i]["RECIPENO2_INT"].ToString().Trim(), out m_intRECIPENO2_INT);


                            RECIPENO2_INT = "";
                            if (m_intRECIPENO2_INT > 0)
                            {
                                RECIPENO2_INT = m_intRECIPENO2_INT.ToString();
                            }
                            #region 医嘱类型控制列表界面
                            //医嘱类型
                            clsT_aid_bih_ordercate_VO p_objItem = (clsT_aid_bih_ordercate_VO)m_htOrderCate[m_strOrderDicCateID];
            
                            if (p_objItem != null)
                            {
                                //objOrder.m_strOrderDicCateName = p_objItem.m_strVIEWNAME_VCHR;

                                if (!m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示剂量
                                {
                                    if (p_objItem.m_intDOSAGEVIEWTYPE == 1)
                                    {
                                        m_strDOSAGE_DEC += m_strDosageUnit;
                                    }
                                    else
                                    {
                                        m_strDOSAGE_DEC = "";
                                    }
                                }
                                else
                                {
                                    m_strDOSAGE_DEC = "";
                                }
                                if (!m_strExecFreqID.Trim().Equals(m_objSpecateVo.m_strCONFREQID_CHR.Trim()))//连续性医嘱不显示用法
                                {
                                    if (p_objItem.m_intUSAGEVIEWTYPE == 1)
                                    {
                                       
                                    }
                                    else
                                    {
                                        //用法
                                        m_strDOSETYPENAME_CHR = "";
                                    }
                                }
                                else
                                {
                                    //用法
                                    m_strDOSETYPENAME_CHR = "";
                                }
                                if (m_intExecuteType == 1)//长临才显示频率，临嘱不显示
                                {
                                    if (p_objItem.m_intExecuFrenquenceType == 1)
                                    {
                                    }
                                    else
                                    {
                                        //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                                        if (m_intCHARGE_INT == 1)
                                        {
                                        }
                                        else
                                        {
                                            m_strEXECFREQNAME_CHR = "";//频率
                                        }
                                    }
                                }
                                else
                                {
                                    //当不显示时，医嘱表中的为修改标志=1时也显示出来 (0-普通状态,1-频率修改)
                                    if (m_intCHARGE_INT == 1)
                                    {
                                    }
                                    else
                                    {
                                        m_strEXECFREQNAME_CHR = "";//频率
                                    }

                                }

                                if (p_objItem.m_intAPPENDVIEWTYPE_INT == 1)
                                {
                                    //补次
                                    m_dmlOneUse = m_dmlOneUse * m_intATTACHTIMES_INT;
                                }
                                else
                                {
                                    
                                    m_dmlOneUse = 0;
                                }
                                //领量
                                if (p_objItem.m_intQTYVIEWTYPE_INT == 1)
                                {
                                    if (m_dmlGet > 0)
                                    {
                                        m_strGET_DEC += m_strGETUNIT_CHR;
                                    }
                                    else
                                    {
                                        m_strGET_DEC = "";

                                    }
                                }
                                else
                                {
                                    //领量
                                    m_strGET_DEC = "";
                                }
                            }
                            else
                            {
                                //用量
                                m_strDOSAGE_DEC = "";
                                //频率
                                m_strEXECFREQNAME_CHR = "";
                                //用法
                                m_strDOSETYPENAME_CHR = "";
                                //补次
                                //objRow.Cells["ATTACHTIMES_INT"].Value = "";
                                //领量
                                m_strGET_DEC = "";

                            }
                            #endregion
                            //皮试
                            m_strFeel = "";
                            if (m_intISNEEDFEEL == 1)
                            {

                                switch (m_intFEEL_INT)
                                {
                                    case 0:
                                        m_strFeel = " AST( ) ";
                                        break;
                                    case 1:
                                        m_strFeel = " AST(-) ";
                                        break;
                                    case 2:
                                        m_strFeel = " AST(+) ";
                                        break;
                                }

                            }
                            /*<==================================*/
                            m_strSum = "";
                            //总量字段的控制
                            if (m_strOrderDicCateID.Equals(m_objSpecateVo.m_strMID_MEDICINE_CHR))//中药类型逻辑
                            {
                                m_strSum = m_intOUTGETMEDDAYS_INT.ToString() + "服共" + Convert.ToString(m_dmlGet + m_dmlOneUse) + m_strGETUNIT_CHR;
                                m_strOUTGETMEDDAYS_INT = m_intOUTGETMEDDAYS_INT.ToString() + "服"; ;
                            }
                            else
                            {

                                if (m_intExecuteType == 3)
                                {
                                    m_strSum = m_intOUTGETMEDDAYS_INT.ToString() + "天共" + Convert.ToString(m_dmlGet + m_dmlOneUse) + m_strGETUNIT_CHR;
                                    m_strOUTGETMEDDAYS_INT = m_intOUTGETMEDDAYS_INT.ToString() + "天";
                                    //objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = objOrder.m_intOUTGETMEDDAYS_INT.ToString() + "天";
                                }
                                else
                                {
                                    m_strSum = "共" + Convert.ToString(m_dmlGet + m_dmlOneUse) + m_strGETUNIT_CHR;
                                    m_strOUTGETMEDDAYS_INT = "";
                                    //objRow.Cells["dtv_OUTGETMEDDAYS_INT"].Value = "";
                                }
                                
                            }
                            if (p_objItem.m_strVIEWNAME_VCHR.ToString().Trim() == "文字医嘱")
                            {
                                m_strSum = "";
                            }
                            //名称
                            m_strNAME_VCHR = m_strNAME_VCHR + " " + m_strDOSAGE_DEC + " " + m_strDOSETYPENAME_CHR + " " + m_strEXECFREQNAME_CHR + m_strFeel + " " + m_strSum;
                            //m_dtOutOrder.Columns.Add("EXECUTETYPE", typeof(string));//医嘱类型
                            //m_dtOutOrder.Columns.Add("NAME_VCHR", typeof(string));//医嘱内容(名称)
                            //m_dtOutOrder.Columns.Add("REMARK_VCHR", typeof(string));//医嘱说明
                            DataRow row = m_dtOutOrder.NewRow();
                            row["EXECUTETYPE"] = EXECUTETYPE;
                            row["NAME_VCHR"] = m_strNAME_VCHR;
                            row["REMARK_VCHR"] = m_strREMARK_VCHR;
                            row["RECIPENO2_INT"] = RECIPENO2_INT;
                            
                            m_dtOutOrder.Rows.Add(row);
            
                        }
                    }
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

        #region  查询系统参数表(ICARE公用)
        /// <summary>
        /// 系统参数表(ICARE公用)
         /// </summary>
        /// <param name="PARMCODE_CHR">参数代码</param>
        /// <param name="m_strPARMVALUE_VCHR">PARMVALUE_VCHR</param>
         /// <returns></returns>
        [AutoComplete]
        public long LoadThePARMVALUE(string PARMCODE_CHR, out string  m_strPARMVALUE_VCHR)
        {
            m_strPARMVALUE_VCHR = "";
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            DataTable dtResult = new DataTable();
            string strSql = @"select a.syscode_chr, a.parmcode_chr, a.parmdesc_vchr, a.parmvalue_vchr,
                                   a.status_int, a.note_vchr
                              from t_bse_sysparm a
                             where a.parmcode_chr = ? and a.status_int = 1";
            System.Data.IDataParameter[] arrParams = null;
            objHRPSvc.CreateDatabaseParameter(1, out arrParams);
            arrParams[0].Value = PARMCODE_CHR;
            try
            {

                lngRes = 0;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSql, ref dtResult, arrParams);
                if (lngRes > 0)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        m_strPARMVALUE_VCHR = dtResult.Rows[0]["PARMVALUE_VCHR"].ToString().Trim();
                    }
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


        /// <summary>
        /// 获取开关（公用）
        /// </summary>
        /// <returns></returns>
        [AutoComplete]
        public long LoadThePARMVALUE(ArrayList PARMCODE_CHR, out DataTable dtbResult)
        {
            long lngRes = -1;
            dtbResult = new DataTable();
            string strSQL = @"select a.syscode_chr, a.parmcode_chr, a.parmdesc_vchr, a.parmvalue_vchr,
                                   a.status_int, a.note_vchr
                              from t_bse_sysparm a
                             where a.status_int = 1 and a.parmcode_chr in ([control])";
            try
            {
                string m_strControl = "";
                for (int i = 0; i < PARMCODE_CHR.Count; i++)
                {
                    m_strControl += "'" + PARMCODE_CHR[i].ToString().Trim() + "'";
                    m_strControl += ",";
                }
                m_strControl = m_strControl.TrimEnd(",".ToCharArray());
                strSQL = strSQL.Replace("[control]", m_strControl);
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
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

        #region 是否适应症目录药品
        /// <summary>
        /// 是否适应症目录药品
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <returns></returns>
        [AutoComplete]
        public bool m_blnShiying(string strOrderID,out string strRemark,out string strItemName)
        {
            long lngRes = 0;
            bool blnRes = false;
            strRemark = string.Empty;
            strItemName = string.Empty;
            string strSQL = @"select a.itemname_vchr,a.xzsysm
                              from t_bse_chargeitemybrla     a,
                                   t_bse_bih_orderdic        b,
                                   t_aid_bih_orderdic_charge c,
                                   t_bse_chargeitem          d
                             where b.orderdicid_chr = c.orderdicid_chr
                               and c.itemid_chr = d.itemid_chr
                               and d.itemcode_vchr = a.hisitemcode_vchr
                               and exists (select 1
                                      from t_bse_shiying t
                                     where t.menucode_vchr = a.ybitemcode_vchr)
                               and b.orderdicid_chr = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] paraArr = null;
            
            objHRPSvc.CreateDatabaseParameter(1, out paraArr);
            paraArr[0].Value = strOrderID;
            DataTable dtResult = new DataTable();
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, paraArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    blnRes = true;
                    strItemName = dtResult.Rows[0]["itemname_vchr"].ToString();
                    strRemark = dtResult.Rows[0]["xzsysm"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(objEx);
            }
            return blnRes;
        }
        #endregion

        #region 单条医嘱适应症
        /// <summary>
        /// 单条医嘱适应症
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <param name="strItemID"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetShiying(string strOrderID,string strItemID,out string strShiying)
        {
            long lngRes = 0;
            strShiying = string.Empty;
            DataTable dtResult = new DataTable();
            string strSQL= @"select a.itemchargetype_vchr from t_opr_bih_orderchargedept a where a.chargeitemid_chr = ? and a.orderid_chr = ?";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            IDataParameter[] paraArr = null;
            objHRPSvc.CreateDatabaseParameter(2, out paraArr);
            paraArr[0].Value = strItemID;
            paraArr[1].Value = strOrderID;
            try
            {
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, paraArr);
                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    strShiying = dtResult.Rows[0]["itemchargetype_vchr"].ToString();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRet = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
    }
}
