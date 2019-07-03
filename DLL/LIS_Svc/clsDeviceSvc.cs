using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.middletier.LIS
{
    [Transaction(TransactionOption.Supported)]
    [ObjectPooling(Enabled = true)]
    public class clsDeviceSvc : com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
    {
        #region 查询所有当前可用检验仪器列表
        /// <summary>
        /// 查询所有当前可用检验仪器列表,
        /// 停用日期为NULL 或 大于 当前日期 且 起用日期 小于等于当前日期,  
        /// 
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_dtbDeviceList">
        /// table:t_bse_lis_device
        /// column:
        /// deviceid_chr
        /// device_model_id_chr
        /// dataacquisitioncomputerip_chr
        /// begin_date_dat
        /// end_date_dat
        /// devicename_vchr
        /// place_vchr
        /// deptid_chr
        /// isdatatrans_int
        /// </param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetDeviceList(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbDeviceList)
        {
            long lngRes = 0;
            p_dtbDeviceList = null;
            string strSQL = @"SELECT deviceid_chr,device_model_id_chr,dataacquisitioncomputerip_chr,
							begin_date_dat,end_date_dat,devicename_vchr,place_vchr,deptid_chr,isdatatrans_int 
							FROM t_bse_lis_device 
							WHERE 
							(end_date_dat is null 
							OR  end_date_dat > sysdate) 
							AND begin_date_dat <= sysdate";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceList);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。          
            }
            return lngRes;
        }
        #endregion



        #region 查询所有的仪器类型名称
        [AutoComplete]
        public long m_lngGetDeviceModelNameByDeviceID(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable dtbAllDeciveName)
        {
            long lngRes = 0;
            string strSQL = @"SELECT t1.deviceid_chr, t2.device_model_desc_vchr
								FROM t_bse_lis_device t1, t_bse_lis_device_model t2
								WHERE t1.device_model_id_chr = t2.device_model_id_chr";
            dtbAllDeciveName = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbAllDeciveName);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 查询某台仪器所有能做的质控项目
        [AutoComplete]
        public long m_lngGetQCCheckItemByDeviceID(System.Security.Principal.IPrincipal p_objPrincipal, string strDeviceID, out DataTable dtbQCCheckItem)
        {
            long lngRes = 0;
            string strSQL = @"SELECT a.rptno_chr, a.pycode_chr, a.unit_chr, a.check_item_name_vchr,
									 a.is_sex_related_chr, a.check_item_english_name_vchr,
									 a.is_age_related_chr, a.is_sample_related_chr, a.formula_vchr,
									 a.test_methods_vchr, a.clinic_meaning_vchr, a.check_item_id_chr,
									 a.shortname_chr, a.is_qc_required_chr, a.resulttype_chr,
									 a.ref_value_range_vchr, a.wbcode_chr, a.assist_code01_chr,
									 a.assist_code02_chr, a.is_no_food_required_chr,
									 a.is_physical_exam_required_chr, a.is_reservation_required_chr,
									 a.sample_valid_time_dec, a.sample_valid_time_unit_chr, a.modify_dat,
									 a.operatorid_chr, a.check_category_id_chr,
									 c.device_check_item_name_vchr
							 FROM t_bse_lis_check_item a,
								  t_bse_lis_device b,
								  t_bse_lis_device_check_item c,
								  t_bse_lis_check_item_dev_item d
							 WHERE b.device_model_id_chr = c.device_model_id_chr
							   AND c.device_model_id_chr = d.device_model_id_chr
							   AND a.is_qc_required_chr = '1'
							   AND c.device_check_item_id_chr = d.device_check_item_id_chr
                               AND d.check_item_id_chr = a.check_item_id_chr
                               AND b.deviceid_chr = '" + strDeviceID + "'";
            dtbQCCheckItem = null;
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbQCCheckItem);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
            }
            return lngRes;
        }
        #endregion

        #region 根据检验项目号，查询可以做该检验项目的仪器列表
        [AutoComplete]
        public long m_lngGetDeviceListByCheckGroup(System.Security.Principal.IPrincipal p_objPrincipal, string p_strCheckGroupId, out DataTable p_dtbDeviceList)
        {
            long lngRes = 0;
            p_dtbDeviceList = null;
            string strSQL = @"SELECT deviceid_chr, device_model_id_chr, dataacquisitioncomputerip_chr,
							begin_date_dat, end_date_dat, devicename_vchr, place_vchr, deptid_chr,
							isdatatrans_int
							FROM t_bse_lis_device
							WHERE device_model_id_chr IN (
									SELECT   tb1.device_model_id_chr
										FROM (SELECT t2.device_check_item_id_chr,
													t2.device_model_id_chr
												FROM t_aid_lis_check_group_detail t1,
													t_bse_lis_check_item_dev_item t2
												WHERE t1.check_item_id_chr = t2.check_item_id_chr
												AND t1.groupid_chr = '" + p_strCheckGroupId + @"') tb2,
											(SELECT t3.device_model_id_chr,
													t3.device_check_item_id_chr
												FROM t_bse_lis_device_check_item t3) tb1
										WHERE tb1.device_check_item_id_chr = tb2.device_check_item_id_chr
										 AND tb1.device_model_id_chr = tb2.device_model_id_chr	
										HAVING COUNT (*) =
												(SELECT COUNT (*)
													FROM (SELECT distinct t2.device_check_item_id_chr
															FROM t_aid_lis_check_group_detail t1,
																t_bse_lis_check_item_dev_item t2
															WHERE t1.check_item_id_chr =
																					t2.check_item_id_chr
															AND t1.groupid_chr = '" + p_strCheckGroupId + @"'))
									GROUP BY tb1.device_model_id_chr)";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceList);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。          
            }
            return lngRes;
        }
        #endregion


        #region 查询某台仪器所有可能的检验项目
        [AutoComplete]
        public long m_lngGetDeviceCheckGroupList(System.Security.Principal.IPrincipal p_objPrincipal, string strDeviceId, out DataTable p_dtbDeviceCheckGroupList)
        {
            long lngRes = 0;
            p_dtbDeviceCheckGroupList = null;
            string strSQL = @"SELECT DISTINCT g.groupid_chr, g.groupname_vchr
				FROM t_aid_lis_check_group g,
						t_aid_lis_check_group_detail gd,
						(SELECT device_model_id_chr, check_item_id_chr
						FROM t_bse_lis_check_item_dev_item
						WHERE (check_item_id_chr,
								device_check_item_id_chr,
								device_model_id_chr,
								modify_dat
								) IN (
								SELECT   check_item_id_chr,
											device_check_item_id_chr,
											device_model_id_chr, MAX (modify_dat)
									FROM t_bse_lis_check_item_dev_item
								GROUP BY check_item_id_chr,
											device_check_item_id_chr,
											device_model_id_chr)) di,
						t_bse_lis_device d
				WHERE g.groupid_chr = gd.groupid_chr
					AND gd.check_item_id_chr = di.check_item_id_chr
					AND di.device_model_id_chr = d.device_model_id_chr
					AND d.deviceid_chr = '" + strDeviceId + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDeviceCheckGroupList);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。          
            }
            return lngRes;
        }
        #endregion

        #region 查询所有的仪器类型
        [AutoComplete]
        public long m_lngQueryAllDevType(System.Security.Principal.IPrincipal p_objPrincipal, out System.Data.DataTable p_dtbDevType)
        {
            long lngRes = 0;
            p_dtbDevType = null;
            string strSQL = @"SELECT device_category_id_chr, device_category_name_vchr
							FROM t_bse_lis_device_category";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDevType);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 查询某一类的所有具体仪器
        [AutoComplete]
        public long m_lngQueryAllDev(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDevType, out System.Data.DataTable p_dtbDev)
        {
            long lngRes = 0;
            p_dtbDev = null;
            string strSQL = @"SELECT t1.deviceid_chr, t1.device_model_id_chr,
							t1.dataacquisitioncomputerip_chr, t1.begin_date_dat, t1.end_date_dat,
							t1.devicename_vchr, t1.place_vchr, t1.deptid_chr, t1.isdatatrans_int
							FROM t_bse_lis_device t1,
								t_bse_lis_device_model t2,
								t_bse_lis_device_category t3
							WHERE t2.device_category_id_chr = t3.device_category_id_chr
							AND t1.device_model_id_chr = t2.device_model_id_chr 
							AND t3.device_category_id_chr ='" + p_strDevType + @"'";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbDev);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 根据某台仪器ID查询该仪器所能做的所有检验单项信息
        [AutoComplete]
        public long m_lngGetCheckItemsByDevID(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDevID, out System.Data.DataTable p_dtbCheckItem)
        {
            long lngRes = 0;
            p_dtbCheckItem = null;
            string strSQL = @"SELECT a.rptno_chr, a.pycode_chr, a.unit_chr, a.check_item_name_vchr,
							a.is_sex_related_chr, a.check_item_english_name_vchr,
							a.is_age_related_chr, a.is_sample_related_chr, a.formula_vchr,
							a.test_methods_vchr, a.clinic_meaning_vchr, a.check_item_id_chr,
							a.shortname_chr, a.is_qc_required_chr, a.resulttype_chr,
							a.ref_value_range_vchr, a.wbcode_chr, a.assist_code01_chr,
							a.assist_code02_chr, a.is_no_food_required_chr,
							a.is_physical_exam_required_chr, a.is_reservation_required_chr,
							a.sample_valid_time_dec, a.sample_valid_time_unit_chr, a.modify_dat,
							a.operatorid_chr, a.check_category_id_chr,c.device_check_item_name_vchr
							FROM t_bse_lis_check_item a,
								t_bse_lis_device b,
								t_bse_lis_device_check_item c,
								t_bse_lis_check_item_dev_item d
							WHERE b.device_model_id_chr = c.device_model_id_chr 
							and c.device_model_id_chr=d.device_model_id_chr
							AND b.deviceid_chr = '" + p_strDevID + @"'
							AND c.device_check_item_id_chr = d.device_check_item_id_chr
							and d.check_item_id_chr=a.check_item_id_chr";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbCheckItem);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
    }
}
