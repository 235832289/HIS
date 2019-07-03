 using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;//Utility.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    internal static class clsTip 
    {
        public static string ErrorMessageTip = "请与管理员联系!";
    }

    /// <summary>
    /// 检验公共服务类
    /// </summary>
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsPublicSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        #region 获取序列
        /// <summary>
        /// 获取一个序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeqName"></param>
        /// <param name="p_intSeqId"></param>
        /// <returns></returns>
        [AutoComplete]
        public static long m_lngGetSequence(string p_strSeqName, out int p_intSeqId)
        {
            p_intSeqId = 0;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strSeqName))
                return lngRes;
            try
            {
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select " + p_strSeqName + ".nextval from dual";
                    clsHRPTableService objHRPServ = new clsHRPTableService();

                    DataTable dtResult = null;
                    lngRes = objHRPServ.DoGetDataTable(strSQL, ref dtResult);
                    if (dtResult != null && dtResult.Rows.Count == 1)
                    {
                        p_intSeqId = Convert.ToInt32(dtResult.Rows[0][0]);
                    }
                    else
                    {
                        p_intSeqId = 1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }
        /// <summary>
        /// 获取一个序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeqName"></param>
        /// <param name="p_lngSeqId"></param>
        /// <returns></returns>
        public static long m_lngGetSequence(string p_strSeqName, out long p_lngSeqId)
        {
            p_lngSeqId = 0;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strSeqName))
                return lngRes;
            try
            {

                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select " + p_strSeqName + ".nextval from dual";
                    clsHRPTableService objHRPServ = new clsHRPTableService();

                    DataTable dtResult = null;
                    lngRes = objHRPServ.DoGetDataTable(strSQL, ref dtResult);
                    if (dtResult != null && dtResult.Rows.Count == 1)
                    {
                        p_lngSeqId = Convert.ToInt64(dtResult.Rows[0][0]);
                    }
                    else
                    {
                        p_lngSeqId = 1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取多个序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeqName">序列名</param>
        /// <param name="p_intNumber">数量</param>
        /// <param name="p_lngSeqIdArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public static long m_lngGetSequenceArr(string p_strSeqName, int p_intNumber, out int[] p_intSeqIdArr)
        {
            p_intSeqIdArr = null;
            long lngRes = 0;
            if (p_intNumber <= 0 || string.IsNullOrEmpty(p_strSeqName))
            {
                return lngRes;
            }

            try
            {
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select getseq(?,?) from dual";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    DataTable dtValue = null;

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);

                    objDPArr[0].Value = p_strSeqName;
                    objDPArr[1].Value = p_intNumber;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objDPArr);
                    if (lngRes > 0 && dtValue != null && dtValue.Rows.Count == 1)
                    {
                        p_intSeqIdArr = new int[p_intNumber];
                        int m_intSeqId = Convert.ToInt32(dtValue.Rows[0][0]);
                        for (int index = p_intNumber - 1; index >= 0; index--)
                        {
                            p_intSeqIdArr[index] = m_intSeqId--;
                        }
                    }
                    else
                    {
                        p_intSeqIdArr = new int[1];
                        p_intSeqIdArr[0] = 1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取多个序列号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strSeqName">序列名</param>
        /// <param name="p_intNumber">数量</param>
        /// <param name="p_lngSeqIdArr">序列号</param>
        /// <returns></returns>
        [AutoComplete]
        public static long m_lngGetSequenceArr(string p_strSeqName, int p_intNumber, out long[] p_lngSeqIdArr)
        {
            p_lngSeqIdArr = null;
            long lngRes = 0;
            if (p_intNumber <= 0 || string.IsNullOrEmpty(p_strSeqName))
            {
                return lngRes;
            }

            try
            {
                if (clsHRPTableService.bytDatabase_Selector == (byte)clsHRPTableService.enumDatabase_Selector.bytOracle)
                {
                    string strSQL = "select getseq(?,?) from dual";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    DataTable dtValue = null;

                    IDataParameter[] objDPArr = null;
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);

                    objDPArr[0].Value = p_strSeqName;
                    objDPArr[1].Value = p_intNumber;

                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtValue, objDPArr);
                    if (lngRes > 0 && dtValue != null && dtValue.Rows.Count == 1)
                    {
                        p_lngSeqIdArr = new long[p_intNumber];
                        long m_lngSeqId = Convert.ToInt64(dtValue.Rows[0][0]);
                        for (int index = p_intNumber - 1; index >= 0; index--)
                        {
                            p_lngSeqIdArr[index] = m_lngSeqId--;
                        }
                    }
                    else
                    {
                        p_lngSeqIdArr = new long[1];
                        p_lngSeqIdArr[0] = 1;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 获取科室部门信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeptMentInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsPublicSvc", "m_lngGetDeptMentInfo");
            objPrivilege = null;
            if (lngRes <= 0)
                return lngRes;

            try
            {
                string strSQL = @"select t.deptid_chr,
       t.createdate_dat,
       t.status_int,
       t.deactivate_dat,
       t.deptname_vchr,
       t.pycode_chr,
       t.shortno_chr
  from t_bse_deptdesc t
 where t.status_int = 1";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref p_dtResult);
                objHRPServ = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
        }

        #region 创建参数
        /// <summary>
        /// 创建参数
        /// </summary>
        /// <param name="p_objParamArr"></param>
        /// <returns></returns>
        public static IDataParameter[] m_objConstructIDataParameterArr(params object[] p_objParamArr)
        {
            if (p_objParamArr.Length == 0)
            {
                return null;
            }
            int length = p_objParamArr.Length;
            IDataParameter[] objDPArr = null;
            clsHRPTableService service = new clsHRPTableService();
            service.CreateDatabaseParameter(length, out objDPArr);
            service.Dispose();
            for (int i = 0; i < length; i++)
            {
                objDPArr[i].Value = p_objParamArr[i];
            }
            return objDPArr;
        }
        #endregion
    }

}
