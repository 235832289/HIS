using System;
using System.Data;
using System.EnterpriseServices;
using System.Security.Principal;
using System.Collections;
using System.Text;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.security;//PrivilegeSystemService.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsWorkStatsticSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase
    {
        public clsWorkStatsticSvc()
        {

        }

        #region
        /// <summary>
        /// 获取开单医生或检验者
        /// </summary>
        /// <param name="dtbEmp"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetEmployee(out DataTable dtbEmp)
        {
            dtbEmp = null;
            string strSQL = @"select t.empid_chr, t.lastname_vchr,t.empno_chr,t.pycode_chr from t_bse_employee t where t.status_int = '1'";
            clsHRPTableService objHEPSvc = new clsHRPTableService();
            long lngRes = objHEPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbEmp);
            objHEPSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region
        /// <summary>
        /// 获取部门
        /// </summary>
        /// <param name="dtbDept"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetDept(out DataTable dtbDept)
        {
            dtbDept = null;
            string strSQL = @"select t.deptid_chr,t.deptname_vchr from  t_bse_deptdesc t where t.attributeid='0000002' or t.attributeid='0000003' and t.status_int='1' order by t.deptid_chr";
            clsHRPTableService objHEPSvc = new clsHRPTableService();
            long lngRes = objHEPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbDept);
            objHEPSvc.Dispose();
            return lngRes;
        }
        #endregion


        #region
//        /// <summary>
//        /// 工作量统计
//        /// </summary>
//        /// <param name="p_intQueryType">0 = 审核时间，1 = 申请时间</param>
//        /// <param name="p_dtDateFrom"></param>
//        /// <param name="p_dtDateTO"></param>
//        /// <param name="p_strQuery"> 0 = 按开单科室，1=按开单医生，2=检验人员，3=检验科（全院）</param>
//        /// <param name="p_strCondition"></param>
//        /// <param name="dtbResult"></param>
//        /// <returns></returns>
//        [AutoComplete]
//        public long lngGetWorkStatstic(int p_intQueryType, DateTime p_dtDateFrom, DateTime p_dtDateTO, int p_strQuery, string p_strCondition, out DataTable dtbResult)
//        {
//            dtbResult = null;
//            long lngRes = 0;
//            string strDateTime = "dc.confirm_dat";
//            if (p_intQueryType == 1)
//            {
//                strDateTime = "db.application_dat";
//            }

//            string strSQL = @"select b.check_category_desc_vchr,
//       a.apply_unit_name_vchr,
//       a.price_num,
//       c.itemcount,
//       d.appcount
//  from t_aid_lis_apply_unit a,
//       t_bse_lis_check_category b,
//       (select ca.apply_unit_id_chr,
//               count(ca.check_item_id_chr) as itemcount
//          from t_aid_lis_apply_unit_detail ca
//         group by ca.apply_unit_id_chr) c,
//       (select da.apply_unit_id_chr,
//               count(db.application_id_chr) as appcount
//          from t_opr_lis_app_apply_unit da,
//               t_opr_lis_application    db,
//               t_opr_lis_sample         dc
//         where da.application_id_chr = db.application_id_chr
//           and db.application_id_chr = dc.application_id_chr
//           and db.pstatus_int = 2
//";
//            if (p_intQueryType == 0)
//            {
//                strSQL += @"           and dc.status_int = 6
//";
//            }
//            else
//            {
//                strSQL += @"           and dc.status_int >= 1
//";
//            }
//            switch (p_strQuery)
//            {
//                case 0:
//                    strSQL += @"           and db.appl_deptid_chr = ?
//           and " + strDateTime + @" between ? and ?
//         group by da.apply_unit_id_chr) d
// where a.check_category_id_chr = b.check_category_id_chr
//   and a.apply_unit_id_chr = c.apply_unit_id_chr
//   and a.apply_unit_id_chr = d.apply_unit_id_chr";
//                    break;

//                case 1:
//                    strSQL += @"           and db.appl_empid_chr = ?
//           and " + strDateTime + @" between ? and ?
//         group by da.apply_unit_id_chr) d
// where a.check_category_id_chr = b.check_category_id_chr
//   and a.apply_unit_id_chr = c.apply_unit_id_chr
//   and a.apply_unit_id_chr = d.apply_unit_id_chr";
//                    break;

//                case 2:
//                    strSQL += @"           and dc.checker_id_chr = ?
//           and " + strDateTime + @" between ? and ?
//         group by da.apply_unit_id_chr) d
// where a.check_category_id_chr = b.check_category_id_chr
//   and a.apply_unit_id_chr = c.apply_unit_id_chr
//   and a.apply_unit_id_chr = d.apply_unit_id_chr";
//                    break;

//                case 3:
//                    strSQL += @"           and " + strDateTime + @" between ? and ?
//         group by da.apply_unit_id_chr) d
// where a.check_category_id_chr = b.check_category_id_chr
//   and a.apply_unit_id_chr = c.apply_unit_id_chr
//   and a.apply_unit_id_chr = d.apply_unit_id_chr";
//                    break;
//                default:
//                    break;
//            }

//            clsHRPTableService objHRPServ = null;
//            try
//            {
//                IDataParameter[] objDPArr = null;
//                objHRPServ = new clsHRPTableService();
//                if (p_strQuery == 3)
//                {
//                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
//                    objDPArr[0].DbType = DbType.DateTime;
//                    objDPArr[0].Value = p_dtDateFrom;
//                    objDPArr[1].DbType = DbType.DateTime;
//                    objDPArr[1].Value = p_dtDateTO;
//                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
//                    objHRPServ.Dispose();
//                }
//                else
//                {
//                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
//                    objDPArr[0].Value = p_strCondition;
//                    objDPArr[1].DbType = DbType.DateTime;
//                    objDPArr[1].Value = p_dtDateFrom;
//                    objDPArr[2].DbType = DbType.DateTime;
//                    objDPArr[2].Value = p_dtDateTO;
//                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
//                    objHRPServ.Dispose();
//                }

//                DataColumn dcTotalItems = new DataColumn("totalitem", typeof(decimal));
//                dcTotalItems.Expression = "itemcount * appcount";

//                DataColumn dcTotalMoney = new DataColumn("totalmoney", typeof(decimal));
//                dcTotalMoney.Expression = "appcount * price_num";

//                DataColumn[] dcArr = new DataColumn[] { dcTotalItems, dcTotalMoney };
//                dtbResult.Columns.AddRange(dcArr);

//                dtbResult.DefaultView.Sort = "check_category_desc_vchr, apply_unit_name_vchr";
//                dtbResult = dtbResult.DefaultView.ToTable();
//            }
//            catch (Exception objEx)
//            {
//                lngRes = 0;
//                clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogDetailError(objEx, true);
//            }
//            finally
//            {
//                objHRPServ = null;
//            }
//            return lngRes;
//        }
        #endregion



        #region 工作量统计
        /// <summary>
        /// 工作量统计
        /// </summary>
        /// <param name="p_intQueryType">0 = 审核时间，1 = 申请时间</param>
        /// <param name="p_dtDateFrom"></param>
        /// <param name="p_dtDateTO"></param>
        /// <param name="p_strQuery"> 0 = 按开单科室，1=按开单医生，2=检验人员，3=检验科（全院）</param>
        /// <param name="p_strCondition"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long lngGetWorkStatstic(int p_intQueryType, DateTime p_dtDateFrom, DateTime p_dtDateTO, int p_strQuery, string p_strCondition, out DataTable dtbResult)
        {
            dtbResult = null;
            long lngRes = 0;
            string strDateTime = "dc.confirm_dat";
            if (p_intQueryType == 1)
            {
                strDateTime = "db.application_dat";
            }

            string strSQL = @"select b.check_category_desc_vchr,
       a.apply_unit_name_vchr,
       a.price_num,
       c.itemcount,
       d.appcount
  from t_aid_lis_apply_unit a,
       t_bse_lis_check_category b,
       (select ca.apply_unit_id_chr,
               count(ca.check_item_id_chr) as itemcount
          from t_aid_lis_apply_unit_detail ca
         group by ca.apply_unit_id_chr) c,
       (select da.apply_unit_id_chr,
               count(db.application_id_chr) as appcount
          from t_opr_lis_app_apply_unit da,
               t_opr_lis_application    db,
               t_opr_lis_app_report     dc
         where da.application_id_chr = db.application_id_chr
           and db.application_id_chr = dc.application_id_chr
           and db.pstatus_int = 2
";
            if (p_intQueryType == 0)
            {
                strSQL += @"           and dc.status_int = 2
";
            }
            else
            {
                strSQL += @"           and dc.status_int >= 1
";
            }
            switch (p_strQuery)
            {
                case 0:
                    strSQL += @"           and db.appl_deptid_chr = ?
           and " + strDateTime + @" between ? and ?
         group by da.apply_unit_id_chr) d
 where a.check_category_id_chr = b.check_category_id_chr
   and a.apply_unit_id_chr = c.apply_unit_id_chr
   and a.apply_unit_id_chr = d.apply_unit_id_chr";
                    break;

                case 1:
                    strSQL += @"           and db.appl_empid_chr = ?
           and " + strDateTime + @" between ? and ?
         group by da.apply_unit_id_chr) d
 where a.check_category_id_chr = b.check_category_id_chr
   and a.apply_unit_id_chr = c.apply_unit_id_chr
   and a.apply_unit_id_chr = d.apply_unit_id_chr";
                    break;

                case 2:
                    strSQL += @"           and dc.reportor_id_chr = ?
           and " + strDateTime + @" between ? and ?
         group by da.apply_unit_id_chr) d
 where a.check_category_id_chr = b.check_category_id_chr
   and a.apply_unit_id_chr = c.apply_unit_id_chr
   and a.apply_unit_id_chr = d.apply_unit_id_chr";
                    break;

                case 3:
                    strSQL += @"           and " + strDateTime + @" between ? and ?
         group by da.apply_unit_id_chr) d
 where a.check_category_id_chr = b.check_category_id_chr
   and a.apply_unit_id_chr = c.apply_unit_id_chr
   and a.apply_unit_id_chr = d.apply_unit_id_chr";
                    break;
                default:
                    break;
            }

            clsHRPTableService objHRPServ = null;
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPServ = new clsHRPTableService();
                if (p_strQuery == 3)
                {
                    objHRPServ.CreateDatabaseParameter(2, out objDPArr);
                    objDPArr[0].DbType = DbType.DateTime;
                    objDPArr[0].Value = p_dtDateFrom;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtDateTO;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                    objHRPServ.Dispose();
                }
                else
                {
                    objHRPServ.CreateDatabaseParameter(3, out objDPArr);
                    objDPArr[0].Value = p_strCondition;
                    objDPArr[1].DbType = DbType.DateTime;
                    objDPArr[1].Value = p_dtDateFrom;
                    objDPArr[2].DbType = DbType.DateTime;
                    objDPArr[2].Value = p_dtDateTO;
                    lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
                    objHRPServ.Dispose();
                }

                DataColumn dcTotalItems = new DataColumn("totalitem", typeof(decimal));
                dcTotalItems.Expression = "itemcount * appcount";

                DataColumn dcTotalMoney = new DataColumn("totalmoney", typeof(decimal));
                dcTotalMoney.Expression = "appcount * price_num";

                DataColumn[] dcArr = new DataColumn[] { dcTotalItems, dcTotalMoney };
                dtbResult.Columns.AddRange(dcArr);

                dtbResult.DefaultView.Sort = "check_category_desc_vchr, apply_unit_name_vchr";
                dtbResult = dtbResult.DefaultView.ToTable();
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                objHRPServ = null;
            }
            return lngRes;
        }

        #endregion
    }
}
    