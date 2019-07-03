using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
namespace com.digitalwave.iCare.middletier.LIS
{
	/// <summary>
	/// clsLisDeviceSvc 的摘要说明。
	/// Alex 2004-5-6
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsLisDeviceSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{

		/// <summary>
		/// 
		/// </summary>
		private const string m_strGetLisDeviceByDeviceID = @"SELECT * FROM T_BSE_LIS_DEVICE";

		#region 删除仪器检验项目与检验项目对应关系 童华 2004.07.20
		[AutoComplete]
		public long m_lngDelCheckItemDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSourceCheckItemID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDelCheckItemDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_bse_lis_check_item_dev_item
									WHERE check_item_id_chr = '"+p_strSourceCheckItemID+@"'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
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

		#region 修改仪器检验项目与检验项目对应关系 童华 2004.07.20
		[AutoComplete]
		public long m_lngModifyCheckItemDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strSourceCheckItemID,
			clsLisCheckItemDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyCheckItemDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

			p_objRecord.m_strMODIFY_DAT = System.DateTime.Now.ToString().Trim();
			string strSQL = @"UPDATE t_bse_lis_check_item_dev_item
								 SET check_item_id_chr = '"+p_objRecord.m_strCHECK_ITEM_ID_CHR+@"',
									 modify_dat = TO_DATE('"+p_objRecord.m_strMODIFY_DAT+@"','yyyy-mm-dd hh24:mi:ss'),
									 operatorid_chr = '"+p_objRecord.m_strOPERATORID_CHR+@"',
									 groupid_chr = '"+p_objRecord.m_strGROUPID_CHR+@"'
							   WHERE check_item_id_chr = '"+p_strSourceCheckItemID+@"'";
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

		#region 添加仪器检验项目与检验项目对应关系 童华 2004.07.20
		[AutoComplete]
		public long m_lngAddNewCheckItemDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,clsLisCheckItemDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddNewCheckItemDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}
			
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			p_objRecord.m_strMODIFY_DAT = strDateTime;
			string strSQL = "INSERT INTO T_BSE_LIS_CHECK_ITEM_DEV_ITEM (CHECK_ITEM_ID_CHR,MODIFY_DAT,OPERATORID_CHR,DEVICE_CHECK_ITEM_ID_CHR,DEVICE_MODEL_ID_CHR,GROUPID_CHR) VALUES (?,?,?,?,?,?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(6,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_objRecord.m_strCHECK_ITEM_ID_CHR;
				objLisAddItemRefArr[1].Value = DateTime.Parse(p_objRecord.m_strMODIFY_DAT);
				objLisAddItemRefArr[2].Value = p_objRecord.m_strOPERATORID_CHR;
				objLisAddItemRefArr[3].Value = p_objRecord.m_strDEVICE_CHECK_ITEM_ID_CHR;
				objLisAddItemRefArr[4].Value = p_objRecord.m_strDEVICE_MODEL_ID_CHR;
				objLisAddItemRefArr[5].Value = p_objRecord.m_strGROUPID_CHR;
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

		#region 添加仪器检验项目 童华 2004.07.19
		[AutoComplete]
		public long m_lngAddNewDeviceItem(System.Security.Principal.IPrincipal p_objPrincipal,clsLisDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddNewDeviceItem");
			if(lngRes < 0)
			{
				return -1;
			}

			lngRes = m_lngGetDeviceCheckItemID(p_objRecord.strDeviceModelID,out p_objRecord.strDeviceCheckItemID);

			if(lngRes <= 0)
			{
				return lngRes;
			}
			
			string strSQL = @"insert into t_bse_lis_device_check_item
  (device_model_id_chr,
   device_check_item_id_chr,
   device_check_item_name_vchr,
   has_graph_result_int,
   is_qc_item_int)
values
  (?, ?, ?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_objRecord.strDeviceModelID;
				objLisAddItemRefArr[1].Value = p_objRecord.strDeviceCheckItemID;
				objLisAddItemRefArr[2].Value = p_objRecord.strDeviceCheckItemName;
				objLisAddItemRefArr[3].Value = p_objRecord.strHasGraphResult;
                objLisAddItemRefArr[4].Value = p_objRecord.strIsQCItem == "1" ? 1 : 0;
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

		#region 修改仪器检验项目 童华 2004.07.19
		[AutoComplete]
		public long m_lngModifyDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,clsLisDeviceCheckItem_VO p_objRecord)
		{
			long lngRes=0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

            string strSQL = @"update t_bse_lis_device_check_item
   set device_check_item_name_vchr = ?,
       has_graph_result_int        = ?,
       is_qc_item_int              = ?
 where device_model_id_chr = ?
   and device_check_item_id_chr = ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] objDPArr = null;
                objHRPSvc.CreateDatabaseParameter(5, out objDPArr);
                objDPArr[0].Value = p_objRecord.strDeviceCheckItemName;
                objDPArr[1].Value = p_objRecord.strHasGraphResult;
                objDPArr[2].Value = p_objRecord.strIsQCItem == "1" ? 1 : 0;
                objDPArr[3].Value = p_objRecord.strDeviceModelID;
                objDPArr[4].Value = p_objRecord.strDeviceCheckItemID;

                long lngAffect = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngAffect, objDPArr);
                objHRPSvc = null;
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            return lngRes;
		}
		#endregion

		#region 删除仪器检验项目 童华 2004.07.19
		[AutoComplete]
		public long m_lngDelDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,clsLisDeviceCheckItem_VO p_objRecord)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDelDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE T_BSE_LIS_DEVICE_CHECK_ITEM WHERE device_check_item_id_chr='"+p_objRecord.strDeviceCheckItemID+"' and device_model_id_chr='"+p_objRecord.strDeviceModelID+"'";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);	
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


		#region 根据 DeviceModelID, DeviceCheckItemName 得到对应的 CheckItem 刘彬 2004.07.15		
		/// <summary>
		/// 根据 DeviceModelID, CheckItemID 得到对应的 CheckItemID
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_strDeviceItemName"></param>
		/// <param name="p_objCheckItemVO"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetCheckItemByDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDeviceID,string p_strDeviceItemName,out clsCheckItem_VO[] p_objCheckItemVOArr)
		{
			long lngRes = 0;
			p_objCheckItemVOArr = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetCheckItemByDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

			DataTable dtbItem = null;
            string strSQL = @"SELECT t1.rptno_chr, t1.pycode_chr, t1.unit_chr, t1.check_item_name_vchr,
                                   t1.is_sex_related_chr, t1.check_item_english_name_vchr,
                                   t1.is_age_related_chr, t1.is_sample_related_chr, t1.formula_vchr,
                                   t1.test_methods_vchr, t1.clinic_meaning_vchr, t1.check_item_id_chr,
                                   t1.shortname_chr, t1.is_qc_required_chr, t1.resulttype_chr,
                                   t1.ref_value_range_vchr, t1.wbcode_chr, t1.assist_code01_chr,
                                   t1.assist_code02_chr, t1.is_no_food_required_chr,
                                   t1.is_physical_exam_required_chr, t1.is_reservation_required_chr,
                                   t1.sample_valid_time_dec, t1.sample_valid_time_unit_chr, t1.modify_dat,
                                   t1.operatorid_chr, t1.check_category_id_chr, t1.ref_max_val_vchr,
                                   t1.ref_min_val_vchr, t1.sampletype_vchr, t1.is_menses_related_chr,
                                   t1.is_calculated_chr, t1.formula_user_vchr, t1.alarm_low_val_vchr,
                                   t1.alarm_up_val_vchr, t1.alert_value_range_vchr
								FROM t_bse_lis_check_item t1,
									t_bse_lis_check_item_dev_item t2,
									t_bse_lis_device_check_item t3,
									t_bse_lis_device t4
								WHERE t1.check_item_id_chr = t2.check_item_id_chr
								AND t2.device_check_item_id_chr = t3.device_check_item_id_chr
								AND t2.device_model_id_chr = t3.device_model_id_chr
								AND t3.device_model_id_chr = t4.device_model_id_chr
								AND t4.deviceid_chr = ?'
								AND t3.device_check_item_name_vchr = ?";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				IDataParameter[] objDPArr = null;
				objHRPSvc.CreateDatabaseParameter(2,out objDPArr);
				objDPArr[0].Value = p_strDeviceID;
				objDPArr[1].Value = p_strDeviceItemName;


				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbItem,objDPArr);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbItem != null)
				{
					if(dtbItem.Rows.Count > 0)
					{
						p_objCheckItemVOArr = new clsCheckItem_VO[dtbItem.Rows.Count];
						for(int i=0;i<dtbItem.Rows.Count;i++)
						{
							p_objCheckItemVOArr[i] = new clsCheckItem_VO();
                            new clsQueryCheckItemSvc().ConstructCheckItemVO(dtbItem.Rows[i], ref p_objCheckItemVOArr[i]);
						}
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
				p_objCheckItemVOArr = null;
			}
			return lngRes;
		}
		#endregion

		#region 得到所有的仪器项目及对应的检验项目信息 刘彬 2004.07.15		
		/// <summary>
		/// 得到所有的仪器项目及对应的检验项目信息
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_dtbResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetDeviceCheckItemInfo(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbResult)
		{
			long lngRes = 0;
			p_dtbResult = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetDeviceCheckItemInfo");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT t4.deviceid_chr,t3.*, t1.check_item_id_chr, t1.check_item_name_vchr,
									t1.check_item_english_name_vchr, t1.rptno_chr, t1.shortname_chr
								FROM t_bse_lis_check_item t1,
									t_bse_lis_check_item_dev_item t2,
									t_bse_lis_device_check_item t3,
									t_bse_lis_device t4
								WHERE t1.check_item_id_chr = t2.check_item_id_chr
								AND t2.device_check_item_id_chr = t3.device_check_item_id_chr
								AND t2.device_model_id_chr = t3.device_model_id_chr
								AND t4.device_model_id_chr = t3.device_model_id_chr";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();				

				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbResult);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion


		#region 根据仪器检验项目ID查询对应的仪器检验项目与检验项目的关系 童华 2004.07.20
		[AutoComplete]
		public long m_lngGetCheckItemDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDeviceCheckItemID,
			string p_strDeviceModelID,out clsLisCheckItemDeviceCheckItem_VO[] p_objCheckItemDeviceCheckItem)
		{
			long lngRes = 0;
			p_objCheckItemDeviceCheckItem = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetCheckItemDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT a.*, b.check_item_name_vchr, b.check_item_english_name_vchr,
									 b.shortname_chr, c.device_check_item_name_vchr,
									 d.device_model_desc_vchr
								FROM t_bse_lis_check_item_dev_item a,
									 t_bse_lis_check_item b,
									 t_bse_lis_device_check_item c,
									 t_bse_lis_device_model d
							   WHERE a.check_item_id_chr = b.check_item_id_chr
								 AND a.device_check_item_id_chr = c.device_check_item_id_chr
								 AND a.device_model_id_chr = c.device_model_id_chr
								 AND a.device_model_id_chr = d.device_model_id_chr
								 AND a.device_model_id_chr = '"+p_strDeviceModelID+@"'
								 AND a.device_check_item_id_chr = '"+p_strDeviceCheckItemID+@"'";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objCheckItemDeviceCheckItem = new clsLisCheckItemDeviceCheckItem_VO[dtbResult.Rows.Count];
					for(int i=0;i<dtbResult.Rows.Count;i++)
					{
						p_objCheckItemDeviceCheckItem[i] = new clsLisCheckItemDeviceCheckItem_VO();
						p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_ENGLISH_NAME_VCHR = dtbResult.Rows[i]["check_item_english_name_vchr"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_ID_CHR = dtbResult.Rows[i]["check_item_id_chr"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_NAME_VCHR = dtbResult.Rows[i]["check_item_name_vchr"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strDEVICE_CHECK_ITEM_ID_CHR = dtbResult.Rows[i]["device_check_item_id_chr"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strDEVICE_CHECK_ITEM_NAME_CHR = dtbResult.Rows[i]["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strDEVICE_MODEL_ID_CHR = dtbResult.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strGROUPID_CHR = dtbResult.Rows[i]["GROUPID_CHR"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strMODIFY_DAT = dtbResult.Rows[i]["MODIFY_DAT"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strOPERATORID_CHR = dtbResult.Rows[i]["OPERATORID_CHR"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strSHORTNAME_CHR = dtbResult.Rows[i]["SHORTNAME_CHR"].ToString().Trim();
						p_objCheckItemDeviceCheckItem[i].m_strDEVICE_MODEL_DESC_VCHR = dtbResult.Rows[i]["device_model_desc_vchr"].ToString().Trim();
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 查询所有的仪器检验项目与检验项目的对应关系 童华 2004.06.16
		[AutoComplete]
		public long m_lngGetCheckItemDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,out clsLisCheckItemDeviceCheckItem_VO[] p_objCheckItemDeviceCheckItem)
		{
			long lngRes = 0;
			p_objCheckItemDeviceCheckItem = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetCheckItemDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}
			DataTable dtbItem = null;
			string strSQL = @"SELECT * FROM T_BSE_LIS_CHECK_ITEM_DEV_ITEM";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbItem);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbItem != null)
				{
					if(dtbItem.Rows.Count > 0)
					{
						p_objCheckItemDeviceCheckItem = new clsLisCheckItemDeviceCheckItem_VO[dtbItem.Rows.Count];
						for(int i=0;i<dtbItem.Rows.Count;i++)
						{
							p_objCheckItemDeviceCheckItem[i] = new clsLisCheckItemDeviceCheckItem_VO();
							p_objCheckItemDeviceCheckItem[i].m_strCHECK_ITEM_ID_CHR = dtbItem.Rows[i]["CHECK_ITEM_ID_CHR"].ToString().Trim();
							p_objCheckItemDeviceCheckItem[i].m_strDEVICE_CHECK_ITEM_ID_CHR = dtbItem.Rows[i]["DEVICE_CHECK_ITEM_ID_CHR"].ToString().Trim();
							p_objCheckItemDeviceCheckItem[i].m_strDEVICE_MODEL_ID_CHR = dtbItem.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
							p_objCheckItemDeviceCheckItem[i].m_strGROUPID_CHR = dtbItem.Rows[i]["GROUPID_CHR"].ToString().Trim();
							p_objCheckItemDeviceCheckItem[i].m_strMODIFY_DAT = dtbItem.Rows[i]["MODIFY_DAT"].ToString().Trim();
							p_objCheckItemDeviceCheckItem[i].m_strOPERATORID_CHR = dtbItem.Rows[i]["OPERATORID_CHR"].ToString().Trim();
						}
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 删除仪器设备 童华 2004.06.16
		[AutoComplete]
		public long m_lngDelDevice(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDeviceID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDelDevice");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_bse_lis_device
									WHERE deviceid_chr = '"+p_strDeviceID+@"'";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

				long lngRecEff = -1;

				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 修改仪器信息 童华 2004.06.16
		[AutoComplete]
		public long m_lngModifyDevice(System.Security.Principal.IPrincipal p_objPrincipal,ref clsLisDevice_VO p_objLisDeviceVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyDevice");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_bse_lis_device
								 SET device_model_id_chr = '"+p_objLisDeviceVO.m_objModel.m_strModelID+@"',
									 dataacquisitioncomputerip_chr = '"+p_objLisDeviceVO.m_strDataAcquistionComputerIP+@"',
									 begin_date_dat = TO_DATE('"+p_objLisDeviceVO.m_strBeginDate+@"','yyyy-mm-dd'),
									 end_date_dat = TO_DATE('"+p_objLisDeviceVO.m_strEndDate+@"','yyyy-mm-dd'),
									 devicename_vchr = '"+p_objLisDeviceVO.m_strDeviceName+@"',
									 place_vchr = '"+p_objLisDeviceVO.m_strPlace+@"',
									 deptid_chr = '"+p_objLisDeviceVO.m_strDeptID+@"',
									 isdatatrans_int = '"+p_objLisDeviceVO.m_strIsDataTrans+@"',
									 deviceip_chr = '"+p_objLisDeviceVO.m_strDeviceIP+@"',
									 DEVICE_CODE_CHR = '"+p_objLisDeviceVO.m_strDeviceCode+@"'
							   WHERE deviceid_chr = '"+p_objLisDeviceVO.m_strDeviceID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 添加仪器信息 童华 2004.06.16
		[AutoComplete]
		public long m_lngAddDevice(System.Security.Principal.IPrincipal p_objPrincipal,ref clsLisDevice_VO p_objLisDeviceVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddDevice");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"INSERT INTO t_bse_lis_device
										  (deviceid_chr, device_model_id_chr,
										   dataacquisitioncomputerip_chr, begin_date_dat, end_date_dat,
										   devicename_vchr, place_vchr, deptid_chr, isdatatrans_int,
										   deviceip_chr,DEVICE_CODE_CHR
										   )
								   VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				p_objLisDeviceVO.m_strDeviceID = objHRPSvc.m_strGetNewID("t_bse_lis_device","deviceid_chr",6);
				System.Data.IDataParameter[] objDeviceArr = null;
				objHRPSvc.CreateDatabaseParameter(11,out objDeviceArr);

				objDeviceArr[0].Value = p_objLisDeviceVO.m_strDeviceID;
				objDeviceArr[1].Value = p_objLisDeviceVO.m_objModel.m_strModelID;
				objDeviceArr[2].Value = p_objLisDeviceVO.m_strDataAcquistionComputerIP;
				objDeviceArr[3].Value = DateTime.Parse(p_objLisDeviceVO.m_strBeginDate);
				if(p_objLisDeviceVO.m_strEndDate == null || p_objLisDeviceVO.m_strEndDate.ToString().Trim() == "")
				{
					objDeviceArr[4].Value = null;
				}
				else
				{
					objDeviceArr[4].Value = DateTime.Parse(p_objLisDeviceVO.m_strEndDate);
				}
				objDeviceArr[5].Value = p_objLisDeviceVO.m_strDeviceName;
				objDeviceArr[6].Value = p_objLisDeviceVO.m_strPlace;
				objDeviceArr[7].Value = p_objLisDeviceVO.m_strDeptID;
				objDeviceArr[8].Value = p_objLisDeviceVO.m_strIsDataTrans;
				objDeviceArr[9].Value = p_objLisDeviceVO.m_strDeviceIP;
				objDeviceArr[10].Value = p_objLisDeviceVO.m_strDeviceCode;

				long lngRecEff = -1;

				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDeviceArr);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 获得所有的仪器列表信息 童华 2004.06.16
		[AutoComplete]
		public long m_lngGetAllDevice(System.Security.Principal.IPrincipal p_objPrincipal,out clsLisDevice_VO[] p_objLisDeviceListVO)
		{
			long lngRes = 0;
			p_objLisDeviceListVO = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetAllDevice");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT t1.*, t2.device_model_desc_vchr, t3.deptname_vchr
								FROM t_bse_lis_device t1, t_bse_lis_device_model t2, t_bse_deptdesc t3
							   WHERE t1.device_model_id_chr = t2.device_model_id_chr AND t1.deptid_chr = t3.deptid_chr(+)";
			DataTable dtbDevice = null;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbDevice);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbDevice != null)
				{
					if(dtbDevice.Rows.Count > 0)
					{
						p_objLisDeviceListVO = new clsLisDevice_VO[dtbDevice.Rows.Count];
						for(int i=0;i<dtbDevice.Rows.Count;i++)
						{
							p_objLisDeviceListVO[i] = new clsLisDevice_VO();
							p_objLisDeviceListVO[i].m_objModel = new clsLisDeviceModel_VO();
							p_objLisDeviceListVO[i].m_strDeviceID = dtbDevice.Rows[i]["DEVICEID_CHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_objModel.m_strModelID = dtbDevice.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_objModel.m_strModelName = dtbDevice.Rows[i]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strBeginDate = dtbDevice.Rows[i]["BEGIN_DATE_DAT"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strEndDate = dtbDevice.Rows[i]["END_DATE_DAT"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strDataAcquistionComputerIP = dtbDevice.Rows[i]["DATAACQUISITIONCOMPUTERIP_CHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strDeviceName = dtbDevice.Rows[i]["DEVICENAME_VCHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strPlace = dtbDevice.Rows[i]["PLACE_VCHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strDeptID = dtbDevice.Rows[i]["DEPTID_CHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strIsDataTrans = dtbDevice.Rows[i]["ISDATATRANS_INT"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strDeviceIP = dtbDevice.Rows[i]["DEVICEIP_CHR"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strDeptName = dtbDevice.Rows[i]["deptname_vchr"].ToString().Trim();
							p_objLisDeviceListVO[i].m_strDeviceCode = dtbDevice.Rows[i]["DEVICE_CODE_CHR"].ToString().Trim();
						}
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 删除仪器串口通讯信息 童华 2004.06.15
		[AutoComplete]
		public long m_lngDelDeviceSerial(System.Security.Principal.IPrincipal p_objPrincipal,string strDeviceModelID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDelDeviceSerial");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"DELETE FROM t_bse_lis_serialsetup
								    WHERE device_model_id_chr = '"+strDeviceModelID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				long lngRecEff = -1;
				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 修改仪器串口通讯信息 童华 2004.06.15
		[AutoComplete]
		public long m_lngModifyDeviceSerial(System.Security.Principal.IPrincipal p_objPrincipal,ref clsLisDeviceSerialSetUp_VO objDeviceSerial)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyDeviceSerial");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_bse_lis_serialsetup
								 SET comno_chr = '"+objDeviceSerial.m_strCOMNO_CHR+@"',
									 baulrate_chr = '"+objDeviceSerial.m_strBAULRATE_CHR+@"',
									 databit_chr = '"+objDeviceSerial.m_strDATABIT_CHR+@"',
									 stopbit_chr = '"+objDeviceSerial.m_strSTOPBIT_CHR+@"',
									 parity_chr = '"+objDeviceSerial.m_strPARITY_CHR+@"',
									 flowcontrol_chr = '"+objDeviceSerial.m_strFLOWCONTROL_CHR+@"',
									 receivebuffer_chr = '"+objDeviceSerial.m_strRECEIVEBUFFER_CHR+@"',
									 sendbuffer_chr = '"+objDeviceSerial.m_strSENDBUFFER_CHR+@"',
									 sendcommand_chr = '"+objDeviceSerial.m_strSENDCOMMAND_CHR+@"',
									 sendcommandinternal_chr = '"+objDeviceSerial.m_strSENDCOMMANDINTERNAL_CHR+@"',
									 dataanalysisdll_vchr = '"+objDeviceSerial.m_strDATAANALYSISDLL_VCHR+@"',
									 dataanalysisnamespace_vchr = '"+objDeviceSerial.m_strDATAANALYSISNAMESPACE_VCHR+@"'
							   WHERE device_model_id_chr = '"+objDeviceSerial.m_strDEVICE_MODEL_ID_CHR+@"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 添加仪器串口通讯信息 童华 2004.06.15
		[AutoComplete]
		public long m_lngAddDeviceSerial(System.Security.Principal.IPrincipal p_objPrincipal,ref clsLisDeviceSerialSetUp_VO objDeviceSerialVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddDeviceSerial");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"INSERT INTO t_bse_lis_serialsetup
										  (comno_chr, baulrate_chr, databit_chr, stopbit_chr, parity_chr,
										   flowcontrol_chr, receivebuffer_chr, sendbuffer_chr,
										   sendcommand_chr, sendcommandinternal_chr, dataanalysisdll_vchr,
										   dataanalysisnamespace_vchr, device_model_id_chr
										   )
								   VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objDeviceSerialArr = null;
				objHRPSvc.CreateDatabaseParameter(13,out objDeviceSerialArr);

				objDeviceSerialArr[0].Value = objDeviceSerialVO.m_strCOMNO_CHR;
				objDeviceSerialArr[1].Value = objDeviceSerialVO.m_strBAULRATE_CHR;
				objDeviceSerialArr[2].Value = objDeviceSerialVO.m_strDATABIT_CHR;
				objDeviceSerialArr[3].Value = objDeviceSerialVO.m_strSTOPBIT_CHR;
				objDeviceSerialArr[4].Value = objDeviceSerialVO.m_strPARITY_CHR;
				objDeviceSerialArr[5].Value = objDeviceSerialVO.m_strFLOWCONTROL_CHR;
				objDeviceSerialArr[6].Value = objDeviceSerialVO.m_strRECEIVEBUFFER_CHR;
				objDeviceSerialArr[7].Value = objDeviceSerialVO.m_strSENDBUFFER_CHR;
				objDeviceSerialArr[8].Value = objDeviceSerialVO.m_strSENDCOMMAND_CHR;
				objDeviceSerialArr[9].Value = objDeviceSerialVO.m_strSENDCOMMANDINTERNAL_CHR;
				objDeviceSerialArr[10].Value = objDeviceSerialVO.m_strDATAANALYSISDLL_VCHR;
				objDeviceSerialArr[11].Value = objDeviceSerialVO.m_strDATAANALYSISNAMESPACE_VCHR;
				objDeviceSerialArr[12].Value = objDeviceSerialVO.m_strDEVICE_MODEL_ID_CHR;

				long lngRecEff = -1;

				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDeviceSerialArr);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 查询所有的仪器串口通讯参数列表 童华 2004.06.15
		[AutoComplete]
		public long m_lngGetAllDeviceSerial(System.Security.Principal.IPrincipal p_objPrincipal,out clsLisDeviceSerialSetUp_VO[] objDeviceSerialVOList)
		{
			long lngRes = 0;
			objDeviceSerialVOList = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetAllDeviceSerial");
			if(lngRes < 0)
			{
				return -1;
			}

			DataTable dtbDeviceSerial = null;
			string strSQL = @"SELECT t1.*, t2.device_model_desc_vchr
								FROM t_bse_lis_serialsetup t1, t_bse_lis_device_model t2
							   WHERE t1.device_model_id_chr = t2.device_model_id_chr";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbDeviceSerial);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbDeviceSerial != null)
				{
					if(dtbDeviceSerial.Rows.Count > 0)
					{
						objDeviceSerialVOList = new clsLisDeviceSerialSetUp_VO[dtbDeviceSerial.Rows.Count];
						for(int i=0;i<dtbDeviceSerial.Rows.Count;i++)
						{
							objDeviceSerialVOList[i] = new clsLisDeviceSerialSetUp_VO();
							objDeviceSerialVOList[i].m_strCOMNO_CHR = dtbDeviceSerial.Rows[i]["COMNO_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strBAULRATE_CHR = dtbDeviceSerial.Rows[i]["BAULRATE_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strDATABIT_CHR = dtbDeviceSerial.Rows[i]["DATABIT_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strSTOPBIT_CHR = dtbDeviceSerial.Rows[i]["STOPBIT_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strPARITY_CHR = dtbDeviceSerial.Rows[i]["PARITY_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strFLOWCONTROL_CHR = dtbDeviceSerial.Rows[i]["FLOWCONTROL_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strRECEIVEBUFFER_CHR = dtbDeviceSerial.Rows[i]["RECEIVEBUFFER_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strSENDBUFFER_CHR = dtbDeviceSerial.Rows[i]["SENDBUFFER_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strSENDCOMMAND_CHR = dtbDeviceSerial.Rows[i]["SENDCOMMAND_CHR"].ToString();
							objDeviceSerialVOList[i].m_strSENDCOMMANDINTERNAL_CHR = dtbDeviceSerial.Rows[i]["SENDCOMMANDINTERNAL_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strDATAANALYSISDLL_VCHR = dtbDeviceSerial.Rows[i]["DATAANALYSISDLL_VCHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strDATAANALYSISNAMESPACE_VCHR = dtbDeviceSerial.Rows[i]["DATAANALYSISNAMESPACE_VCHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strDEVICE_MODEL_ID_CHR = dtbDeviceSerial.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
							objDeviceSerialVOList[i].m_strDeviceModelDec = dtbDeviceSerial.Rows[i]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
						}
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。  
			}
			return lngRes;
		}
		#endregion

		#region 根据仪器类别获取仪器型号 童华 2004.07.19
		[AutoComplete]
		public long m_lngGetDeviceModelArrByDeviceCategoryID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDeviceCategoryID,
			out clsLisDeviceModel_VO[] p_objResultArr)
		{
			p_objResultArr = null;
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetDeviceModelByDeviceCategoryID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT a.*,b.device_category_name_vchr
								FROM t_bse_lis_device_model a, t_bse_lis_device_category b
							   WHERE a.device_category_id_chr = b.device_category_id_chr";
			if(p_strDeviceCategoryID != "")
			{
				strSQL += " AND a.device_category_id_chr = '"+p_strDeviceCategoryID+"'";
			}
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsLisDeviceModel_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsLisDeviceModel_VO();
						p_objResultArr[i1].m_objDeviceCategory = new clsLisDeviceCategory_VO();
						p_objResultArr[i1].m_strModelID = dtbResult.Rows[i1]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strReportTitle = dtbResult.Rows[i1]["REPORTTITLE_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strModelName = dtbResult.Rows[i1]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_objDeviceCategory.m_strDeviceCategoryID = dtbResult.Rows[i1]["DEVICE_CATEGORY_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_objDeviceCategory.m_strDeviceCategoryName = dtbResult.Rows[i1]["device_category_name_vchr"].ToString().Trim();
						p_objResultArr[i1].m_strVendorID = dtbResult.Rows[i1]["VENDOR_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strSTDCode1 = dtbResult.Rows[i1]["STD_CODE1_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strSTDCode2 = dtbResult.Rows[i1]["STD_CODE2_CHR"].ToString().Trim();
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

		#region 删除仪器型号信息 童华 2004.06.15
		[AutoComplete]
		public long m_lngDelDeviceModel(System.Security.Principal.IPrincipal p_objPrincipal,string strDeviceModelID)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyDeviceModel");
			if(lngRes < 0)
			{
				return -1;
			}
			
			string strSQL = @"DELETE FROM t_bse_lis_device_model
								    WHERE device_model_id_chr = '"+strDeviceModelID+"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

				long lngRecEff = -1;

				lngRes = objHRPSvc.DoExcuteForDelete(strSQL,ref lngRecEff);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。  
			}
			return lngRes;
		}
		#endregion

		#region 修改仪器型号信息 童华 2004.06.15
		[AutoComplete]
		public long m_lngModifyDeviceModel(System.Security.Principal.IPrincipal p_objPrincipal,ref clsLisDeviceModel_VO objDeviceModelVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngModifyDeviceModel");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_bse_lis_device_model
								 SET reporttitle_vchr = '"+objDeviceModelVO.m_strReportTitle+@"',
									 device_model_desc_vchr = '"+objDeviceModelVO.m_strModelName+@"',
									 device_category_id_chr = '"+objDeviceModelVO.m_objDeviceCategory.m_strDeviceCategoryID+@"',
									 vendor_id_chr = '"+objDeviceModelVO.m_strVendorID+@"',
									 std_code1_chr = '"+objDeviceModelVO.m_strSTDCode1+@"',
									 std_code2_chr = '"+objDeviceModelVO.m_strSTDCode2+@"'
							   WHERE device_model_id_chr = '"+objDeviceModelVO.m_strModelID+@"'";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。    
			}
			return lngRes;
		}
		#endregion

		#region 添加仪器型号信息 童华 2004.06.15
		[AutoComplete]
		public long m_lngAddDeviceModel(System.Security.Principal.IPrincipal p_objPrincipal,ref clsLisDeviceModel_VO p_objDevcieModelVO)
		{
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngAddDeviceModel");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"INSERT INTO t_bse_lis_device_model
										  (device_model_id_chr, reporttitle_vchr, device_model_desc_vchr,
										   device_category_id_chr, vendor_id_chr, std_code1_chr,
										   std_code2_chr
										   )
								   VALUES (?, ?, ?, ?, ?, ?, ?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				p_objDevcieModelVO.m_strModelID = objHRPSvc.m_strGetNewID("t_bse_lis_device_model","device_model_id_chr",7);
				System.Data.IDataParameter[] objDeviceModelArr = null;
				objHRPSvc.CreateDatabaseParameter(7,out objDeviceModelArr);

				objDeviceModelArr[0].Value = p_objDevcieModelVO.m_strModelID;
				objDeviceModelArr[1].Value = p_objDevcieModelVO.m_strReportTitle;
				objDeviceModelArr[2].Value = p_objDevcieModelVO.m_strModelName;
				objDeviceModelArr[3].Value = p_objDevcieModelVO.m_objDeviceCategory.m_strDeviceCategoryID;
				objDeviceModelArr[4].Value = p_objDevcieModelVO.m_strVendorID;
				objDeviceModelArr[5].Value = p_objDevcieModelVO.m_strSTDCode1;
				objDeviceModelArr[6].Value = p_objDevcieModelVO.m_strSTDCode2;

				long lngRecEff = -1;

				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDeviceModelArr);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。    
			}
			return lngRes;
		}
		#endregion

		#region 根据check_item_id查询对应的Device_check_item的相关信息 童华 2004.06.10
		[AutoComplete]
		public long m_lngGetDeviceCheckItemInfoByCheckItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCheckItemID,
			out clsLisDeviceCheckItem_VO objLisDeviceCheckItemVO)
		{
			long lngRes = 0;
			objLisDeviceCheckItemVO = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetDeviceCheckItemInfoByCheckItemID");
			if(lngRes < 0)
			{
				return -1;
			}

			DataTable dtbDeviceCheckItem = null;

			string strSQL = @"SELECT t2.*
								FROM t_bse_lis_check_item_dev_item t1, t_bse_lis_device_check_item t2
							   WHERE t1.device_model_id_chr = t2.device_model_id_chr
								 AND t1.device_check_item_id_chr = t2.device_check_item_id_chr
								 AND t1.check_item_id_chr = '" + p_strCheckItemID.Trim() +"'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbDeviceCheckItem);    
				objHRPSvc.Dispose();
				if(dtbDeviceCheckItem != null && dtbDeviceCheckItem.Rows.Count > 0)
				{
					objLisDeviceCheckItemVO = new clsLisDeviceCheckItem_VO();
					objLisDeviceCheckItemVO.strDeviceCheckItemID = dtbDeviceCheckItem.Rows[0]["DEVICE_CHECK_ITEM_ID_CHR"].ToString().Trim();
					objLisDeviceCheckItemVO.strDeviceCheckItemName = dtbDeviceCheckItem.Rows[0]["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
					objLisDeviceCheckItemVO.strDeviceModelID = dtbDeviceCheckItem.Rows[0]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
					objLisDeviceCheckItemVO.strHasGraphResult = dtbDeviceCheckItem.Rows[0]["HAS_GRAPH_RESULT_INT"].ToString().Trim();
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。    
			}
			return lngRes;
		}
		#endregion

		#region 查询所有当前可用检验仪器列表 刘彬 2004.05.26
		/// <summary>
		/// 查询所有当前可用检验仪器列表,
		/// 停用日期为NULL 或 大于 当前日期 且 起用日期 小于等于当前日期,  
		/// 刘彬 2004.05.26
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
			string strSQL=@"SELECT deviceid_chr,device_model_id_chr,dataacquisitioncomputerip_chr,
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
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。          
			}
			return lngRes;
		}
		#endregion

		#region 获得所有的仪器型号列表 童华 2004.05.25
		[AutoComplete]
		public long m_lngGetAllDeviceModel(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dtbDeviceModel)
		{
			long lngRes = 0;

			dtbDeviceModel = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetAllDeviceModel");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT * FROM T_BSE_LIS_DEVICE_MODEL";
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbDeviceModel);
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

		#region 获得所有的仪器型号类别VO 童华 2004.06.15
		[AutoComplete]
		public long m_lngGetAllDeviceModel(System.Security.Principal.IPrincipal p_objPrincipal,out clsLisDeviceModel_VO[] objLisDeviceModelVOList)
		{
			long lngRes = 0;
			objLisDeviceModelVOList = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetAllDeviceModel");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT t1.*, t2.device_category_name_vchr
								FROM t_bse_lis_device_model t1, t_bse_lis_device_category t2
							   WHERE t1.device_category_id_chr = t2.device_category_id_chr";

			DataTable dtbDeviceModel = null;
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbDeviceModel);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbDeviceModel != null)
				{
					if(dtbDeviceModel.Rows.Count > 0)
					{
						objLisDeviceModelVOList = new clsLisDeviceModel_VO[dtbDeviceModel.Rows.Count];
						for(int i=0;i<dtbDeviceModel.Rows.Count;i++)
						{
							objLisDeviceModelVOList[i] = new clsLisDeviceModel_VO();
							objLisDeviceModelVOList[i].m_objDeviceCategory = new clsLisDeviceCategory_VO();
							objLisDeviceModelVOList[i].m_objDeviceCategory.m_strDeviceCategoryID = dtbDeviceModel.Rows[i]["device_category_id_chr"].ToString().Trim();
							objLisDeviceModelVOList[i].m_objDeviceCategory.m_strDeviceCategoryName = dtbDeviceModel.Rows[i]["device_category_name_vchr"].ToString().Trim();
							objLisDeviceModelVOList[i].m_strModelID = dtbDeviceModel.Rows[i]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
							objLisDeviceModelVOList[i].m_strModelName = dtbDeviceModel.Rows[i]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
							objLisDeviceModelVOList[i].m_strReportTitle = dtbDeviceModel.Rows[i]["REPORTTITLE_VCHR"].ToString().Trim();
							objLisDeviceModelVOList[i].m_strSTDCode1 = dtbDeviceModel.Rows[i]["STD_CODE1_CHR"].ToString().Trim();
							objLisDeviceModelVOList[i].m_strSTDCode2 = dtbDeviceModel.Rows[i]["STD_CODE2_CHR"].ToString().Trim();
							objLisDeviceModelVOList[i].m_strVendorID = dtbDeviceModel.Rows[i]["VENDOR_ID_CHR"].ToString().Trim();
						}
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 根据仪器型号ID查找所有可用的具体仪器 刘彬 2004.05.07
		/// <summary>
		///  根据仪器型号ID查找所有的具体仪器 刘彬 2004.05.07
		/// </summary>
		/// <param name="p_objPrinipal"></param>
		/// <param name="p_strDeviceModelID"></param>
		/// <param name="p_dtbDevice"></param>
		/// <returns>
		/// DEVICEID_CHR
		/// DEVICENAME_VCHR
		/// </returns>
		[AutoComplete]
		public long m_lngGetDeviceByDeviceModelID(System.Security.Principal.IPrincipal p_objPrinipal,string[] p_strDeviceModelIDArr,out System.Data.DataTable p_dtbDevice)
		{
			long lngRes = 0;
			p_dtbDevice = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrinipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetDeviceByDeviceModelID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL;

			if(p_strDeviceModelIDArr == null)
			{
				strSQL = @"SELECT DISTINCT t1.deviceid_chr, t1.devicename_vchr 
							FROM t_bse_lis_device t1
							WHERE  end_date_dat  is null OR end_date_dat < sysdate";
				try
				{
					com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
					lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtbDevice);  
					objHRPSvc.Dispose();
				}
				catch(Exception objEx)
				{
					com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
					bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
				}
				return lngRes;
			}
			else if(p_strDeviceModelIDArr.Length == 0)
			{
				return 1;
			}
			
			string strSQL1=@"SELECT DISTINCT t1.deviceid_chr, t1.devicename_vchr 
							FROM t_bse_lis_device t1
							WHERE t1.device_model_id_chr in(";
			string strSQL2 = @") 
							AND (end_date_dat  is null OR end_date_dat < sysdate)
						";
			string strPara = "";
			for(int i=0;i<p_strDeviceModelIDArr.Length;i++)
			{
				strPara += "?,";
			}
			strPara = strPara.Remove(strPara.Length-1,1);
			strSQL = strSQL1 + strPara + strSQL2;
			try
			{
				System.Data.IDataParameter[] objParamArr = clsIDataParameterCreator.m_objConstructIDataParameterArr(p_strDeviceModelIDArr);
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref p_dtbDevice,objParamArr);  
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 根据检验项目分类ID获得检验项目
		/// <summary>
		/// 根据检验项目分类ID获得检验项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_dtbResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetLisDeviceByDeviceID(
			System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strDeviceID,
			out DataTable p_dtbResult)
		{

			long lngRes=0;
			p_dtbResult=null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetLisDeviceByDeviceID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = m_strGetLisDeviceByDeviceID + " WHERE DEVICEID_CHR = '"+p_strDeviceID+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbResult);				
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

		#region 获得检验设备的种类列表
		/// <summary>
		/// 获得检验设备的种类列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetLisDeviceCategory(
			System.Security.Principal.IPrincipal p_objPrincipal,
			out clsLisDeviceCategory_VO[] p_objResultArr)
		{
			p_objResultArr = new clsLisDeviceCategory_VO[0];
			long lngRes=0;
			DataTable dtbResult = new DataTable();

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetLisDeviceCategory");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = "SELECT * FROM T_BSE_LIS_DEVICE_CATEGORY";
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);				
				objHRPSvc.Dispose();

				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsLisDeviceCategory_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsLisDeviceCategory_VO();
						p_objResultArr[i1].m_strDeviceCategoryID = 
							dtbResult.Rows[i1]["DEVICE_CATEGORY_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strDeviceCategoryName = 
							dtbResult.Rows[i1]["DEVICE_CATEGORY_NAME_VCHR"].ToString().Trim();
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

		#region 获得检验设备
		/// <summary>
		/// 获得检验设备
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strDeviceCategoryID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetListDevice(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strDeviceCategoryID,out clsLisDevice_VO[]  p_objResultArr)
		{
			p_objResultArr = new clsLisDevice_VO[0];

			long lngRes=0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetListDevice");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL1 = @"SELECT t3.device_category_name_vchr,t3.device_category_id_chr, t2.device_model_desc_vchr, t1.*
						FROM t_bse_lis_device t1,
							t_bse_lis_device_model t2,
							t_bse_lis_device_category t3
						WHERE t1.device_model_id_chr = t2.device_model_id_chr
						AND t2.device_category_id_chr = t3.device_category_id_chr";

			string strSQL2 = @"SELECT t3.device_category_name_vchr,t3.device_category_id_chr, t2.device_model_desc_vchr, t1.*
						FROM t_bse_lis_device t1,
							t_bse_lis_device_model t2,
							t_bse_lis_device_category t3
						WHERE t1.device_model_id_chr = t2.device_model_id_chr
						AND t2.device_category_id_chr = t3.device_category_id_chr
							AND t3.device_category_id_chr = '"+p_strDeviceCategoryID+"'";

			string strSQL = "";
			if(p_strDeviceCategoryID == "")
			{
				strSQL = strSQL1;
			}
			else
			{
				strSQL = strSQL2;
			}

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);				
				objHRPSvc.Dispose();
				
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsLisDevice_VO[dtbResult.Rows.Count];
	
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsLisDevice_VO();
						p_objResultArr[i1].m_strDeviceID = dtbResult.Rows[i1]["DEVICEID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_objModel = new clsLisDeviceModel_VO();
						p_objResultArr[i1].m_objModel.m_strModelID = dtbResult.Rows[i1]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_objModel.m_strModelName = dtbResult.Rows[i1]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_objModel.m_objDeviceCategory = new clsLisDeviceCategory_VO();
						p_objResultArr[i1].m_objModel.m_objDeviceCategory.m_strDeviceCategoryID 
							= dtbResult.Rows[i1]["DEVICE_CATEGORY_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_objModel.m_objDeviceCategory.m_strDeviceCategoryName 
							= dtbResult.Rows[i1]["DEVICE_CATEGORY_NAME_VCHR"].ToString().Trim();
						/*
						p_objResultArr[i1].m_str = dtbResult.Rows[i1]["REPORTTITLE_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_str = dtbResult.Rows[i1]["DEVICE_MODEL_DESC_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_str = dtbResult.Rows[i1]["DEVICE_CATEGORY_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_str = dtbResult.Rows[i1]["VENDOR_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_str = dtbResult.Rows[i1]["STD_CODE1_CHR"].ToString().Trim();
						p_objResultArr[i1].m_str = dtbResult.Rows[i1]["STD_CODE2_CHR"].ToString().Trim();
						*/
						p_objResultArr[i1].m_strDataAcquistionComputerIP = dtbResult.Rows[i1]["DATAACQUISITIONCOMPUTERIP_CHR"].ToString().Trim();

						p_objResultArr[i1].m_strBeginDate = dtbResult.Rows[i1]["BEGIN_DATE_DAT"].ToString().Trim();
						p_objResultArr[i1].m_strEndDate = dtbResult.Rows[i1]["END_DATE_DAT"].ToString().Trim();

						p_objResultArr[i1].m_strDeviceName = dtbResult.Rows[i1]["DEVICENAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strPlace = dtbResult.Rows[i1]["PLACE_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strDeptID = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strIsDataTrans = dtbResult.Rows[i1]["ISDATATRANS_INT"].ToString().Trim();
						p_objResultArr[i1].m_strDeviceIP = dtbResult.Rows[i1]["DEVICEIP_CHR"].ToString().Trim();
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

		#region 根据仪器型号获取设备检验项目
		[AutoComplete]
		public long m_lngGetCheckItemByModelID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strDeviceModelID,
			out clsLisDeviceCheckItem_VO[] p_objResultArr)
		{
			p_objResultArr = null;
			long lngRes = 0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetCheckItemByModelID");
			if(lngRes < 0)
			{
				return -1;
			}

            string strSQL = @"select a.device_model_id_chr,
       a.device_check_item_id_chr,
       a.device_check_item_name_vchr,
       a.has_graph_result_int,
       a.is_qc_item_int,
       b.device_model_desc_vchr
  from t_bse_lis_device_check_item a, t_bse_lis_device_model b
 where a.device_model_id_chr = b.device_model_id_chr
   and a.device_model_id_chr = ?";

			try
			{
				DataTable dtbResult = new DataTable();
                IDataParameter[] objDPArr = null;
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDeviceModelID;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsLisDeviceCheckItem_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsLisDeviceCheckItem_VO();
						p_objResultArr[i1].strDeviceModelID = dtbResult.Rows[i1]["DEVICE_MODEL_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].strDeviceCheckItemID = dtbResult.Rows[i1]["DEVICE_CHECK_ITEM_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].strDeviceCheckItemName = dtbResult.Rows[i1]["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].strHasGraphResult = dtbResult.Rows[i1]["HAS_GRAPH_RESULT_INT"].ToString().Trim();
						p_objResultArr[i1].m_strDEVICE_MODEL_DESC_VCHR = dtbResult.Rows[i1]["device_model_desc_vchr"].ToString().Trim();
                        // 新加
                        p_objResultArr[i1].strIsQCItem = dtbResult.Rows[i1]["IS_QC_ITEM_INT"].ToString().Trim();
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

		#region 获得该型号检验设备的检验项目
		/// <summary>
		/// 获得该型号检验设备的检验项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strModelID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetCheckItemByModelID(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strModelID,
			out clsCheckItemAndDeviceItem_VO[] p_objResultArr)
		{
			p_objResultArr = new clsCheckItemAndDeviceItem_VO[0];
			long lngRes=0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetCheckItemByModelID");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"SELECT t2.*, d.rptno_chr, d.pycode_chr, d.unit_chr, d.check_item_name_vchr,
									d.is_sex_related_chr, d.check_item_english_name_vchr,
									d.is_age_related_chr, d.is_sample_related_chr, d.formula_vchr,
									d.test_methods_vchr, d.clinic_meaning_vchr, d.shortname_chr,
									d.is_qc_required_chr, d.resulttype_chr, d.ref_value_range_vchr,
									d.wbcode_chr, d.assist_code01_chr, d.assist_code02_chr,
									d.is_no_food_required_chr, d.is_physical_exam_required_chr,
									d.is_reservation_required_chr, d.sample_valid_time_dec,
									d.sample_valid_time_unit_chr, d.modify_dat, d.operatorid_chr,
									d.check_category_id_chr, d.ref_max_val_vchr, d.ref_min_val_vchr
								FROM (SELECT t1.*, b.check_item_id_chr
										FROM (SELECT a.device_model_id_chr, e.device_check_item_id_chr,
													e.device_check_item_name_vchr, e.has_graph_result_int
												FROM icare.t_bse_lis_device_model a,
													icare.t_bse_lis_device_check_item e
												WHERE (a.device_model_id_chr = e.device_model_id_chr)
												AND (a.device_model_id_chr = '" + p_strModelID + @"')) t1,
											icare.t_bse_lis_check_item_dev_item b
										WHERE t1.device_model_id_chr = b.device_model_id_chr(+)
										AND t1.device_check_item_id_chr = b.device_check_item_id_chr(+)) t2,
									icare.t_bse_lis_check_item d
								WHERE t2.check_item_id_chr = d.check_item_id_chr(+)";
			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);				
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_objResultArr = new clsCheckItemAndDeviceItem_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<p_objResultArr.Length;i1++)
					{
						p_objResultArr[i1] = new clsCheckItemAndDeviceItem_VO();
						p_objResultArr[i1].m_strCheck_Item_ID = dtbResult.Rows[i1]["CHECK_ITEM_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strRPTNO = dtbResult.Rows[i1]["RPTNO_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strPycode = dtbResult.Rows[i1]["PYCODE_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strUnit = dtbResult.Rows[i1]["UNIT_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strCheck_Item_Name = dtbResult.Rows[i1]["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_Sex_Related = dtbResult.Rows[i1]["IS_SEX_RELATED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strCheck_Item_English_Name = dtbResult.Rows[i1]["CHECK_ITEM_ENGLISH_NAME_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_Age_Related = dtbResult.Rows[i1]["IS_AGE_RELATED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_Sample_Related = dtbResult.Rows[i1]["IS_SAMPLE_RELATED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strFormula = dtbResult.Rows[i1]["FORMULA_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strTest_Method = dtbResult.Rows[i1]["TEST_METHODS_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strClinic_meaning = dtbResult.Rows[i1]["CLINIC_MEANING_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strShortName = dtbResult.Rows[i1]["SHORTNAME_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_Qc_Required = dtbResult.Rows[i1]["IS_QC_REQUIRED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strResultType = dtbResult.Rows[i1]["RESULTTYPE_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strRef_Value_Range = dtbResult.Rows[i1]["REF_VALUE_RANGE_VCHR"].ToString().Trim();
						p_objResultArr[i1].m_strWbcode = dtbResult.Rows[i1]["WBCODE_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strAssist_Code01 = dtbResult.Rows[i1]["ASSIST_CODE01_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strAssist_Code02 = dtbResult.Rows[i1]["ASSIST_CODE02_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_No_Food_Required = dtbResult.Rows[i1]["IS_NO_FOOD_REQUIRED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_Physical_Exam_Required = dtbResult.Rows[i1]["IS_PHYSICAL_EXAM_REQUIRED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strIs_Reservation_Required = dtbResult.Rows[i1]["IS_RESERVATION_REQUIRED_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strSample_Valid_Time = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_DEC"].ToString().Trim();
						p_objResultArr[i1].m_strSample_Valid_Time_Unit = dtbResult.Rows[i1]["SAMPLE_VALID_TIME_UNIT_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strModify_Dat = dtbResult.Rows[i1]["MODIFY_DAT"].ToString().Trim();
						p_objResultArr[i1].m_strOperator_ID = dtbResult.Rows[i1]["OPERATORID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strCheck_Category_ID = dtbResult.Rows[i1]["CHECK_CATEGORY_ID_CHR"].ToString().Trim();
						p_objResultArr[i1].m_strDeviceCheckItemID = dtbResult.Rows[i1]["device_check_item_id_chr"].ToString().Trim();
						p_objResultArr[i1].m_strDeviceCheckItemName = dtbResult.Rows[i1]["device_check_item_name_vchr"].ToString().Trim();
						p_objResultArr[i1].m_intHasGraphResult = Convert.ToInt32 (dtbResult.Rows[i1]["HAS_GRAPH_RESULT_INT"].ToString());
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

		#region 添加设备检验项目
		/// <summary>
		/// 添加设备检验项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strModelID"></param>
		/// <param name="p_intGraphFlag"></param>
		/// <param name="p_objItem"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewDeviceItem(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strModelID,int p_intGraphFlag,clsCheckItemAndDeviceItem_VO p_objItem)
		{
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			 
			long lngRes=0;
			string strItemID = null;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewDeviceItem");
			if(lngRes < 0)
			{
				return -1;
			}

			lngRes = m_lngGetDeviceCheckItemID(p_strModelID,out strItemID);
			if(lngRes < 0)
				return lngRes;


			string strSQL1 = @"INSERT INTO t_bse_lis_device_check_item(DEVICE_MODEL_ID_CHR,DEVICE_CHECK_ITEM_ID_CHR,device_check_item_name_vchr,Has_Graph_Result_int) VALUES "+
							"('"+p_strModelID+"','"+strItemID+"','"+
							p_objItem.m_strDeviceCheckItemName+"','"+p_intGraphFlag+"')";

			string strSQL2 = @"INSERT INTO t_bse_lis_check_item_dev_item(check_item_id_chr,device_check_item_id_chr, 
                                          device_model_id_chr,modify_dat,operatorid_chr) VALUES"+
				"('"+p_objItem.m_strCheck_Item_ID+"','"+strItemID+"','"+
				p_strModelID+"',To_Date('"+strDateTime+"','yyyy-mm-dd hh24:mi:ss'),'"+p_objItem.m_strOperator_ID+"')";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL1);				
				
				if(lngRes > 0)
				{
					lngRes = objHRPSvc.DoExcute(strSQL2);	
					objHRPSvc.Dispose();
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

		#region 修改设备检验项目
		/// <summary>
		/// 修改设备检验项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strModelID"></param>
		/// <param name="p_intGraphFlag"></param>
		/// <param name="p_objItem"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoModifyDeviceItem(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strModelID,int p_intGraphFlag,clsCheckItemAndDeviceItem_VO p_objItem)
		{
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
			 
			long lngRes=0;

			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoModifyDeviceItem");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL = @"UPDATE t_bse_lis_device_check_item SET device_check_item_name_vchr='"+p_objItem.m_strDeviceCheckItemName+"'"+
					" , Has_Graph_Result_int='"+p_intGraphFlag+"' WHERE DEVICE_MODEL_ID_CHR='"+p_strModelID+"' and DEVICE_CHECK_ITEM_ID_CHR='"+p_objItem.m_strDeviceCheckItemID+"'";

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

		#region 获得最大的DeviceCheckItemID
		/// <summary>
		/// 获得最大的DeviceCheckItemID
		/// </summary>
		/// <param name="p_strModelID"></param>
		/// <param name="p_strItemID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetDeviceCheckItemID(string p_strModelID,out string p_strItemID)
		{
			p_strItemID = null;
			long lngRes=0;

			string strSQL = @"SELECT MAX (device_check_item_id_chr) AS maxid
				FROM t_bse_lis_device_check_item WHERE device_model_id_chr = '"+p_strModelID+"'";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);				
				objHRPSvc.Dispose();
				if(lngRes > 0 && dtbResult.Rows.Count > 0)
				{
					p_strItemID = dtbResult.Rows[0]["maxid"].ToString().Trim();
				}

				if(p_strItemID == null || p_strItemID == "")
				{
					p_strItemID = "0001";

				}
				else
				{
					p_strItemID = Convert.ToString(int.Parse(p_strItemID) + 1).PadLeft(4,'0');
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

		#region 删除设备检验项目
		/// <summary>
		/// 删除设备检验项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strModelID"></param>
		/// <param name="p_objItem"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteDeviceCheckItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strModelID,clsCheckItemAndDeviceItem_VO p_objItem)
		{
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDeleteDeviceCheckItem");
			if(lngRes < 0)
			{
				return -1;
			}

			string strSQL1 = @"DELETE t_bse_lis_check_item_dev_item WHERE device_check_item_id_chr='"+p_objItem.m_strDeviceCheckItemID+"' and device_model_id_chr='"+p_strModelID+"'";
			string strSQL2 = @"DELETE T_BSE_LIS_DEVICE_CHECK_ITEM WHERE device_check_item_id_chr='"+p_objItem.m_strDeviceCheckItemID+"' and device_model_id_chr='"+p_strModelID+"'";

			try
			{
				DataTable dtbResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1,ref dtbResult);				
				if(lngRes > 0)
				{
////					lngRes = objHRPSvc.lngGetDataTableWithoutParameters("commit",ref dtbResult);		
					lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2,ref dtbResult);
////					lngRes = objHRPSvc.lngGetDataTableWithoutParameters("commit",ref dtbResult);
					objHRPSvc.Dispose();
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

        #region 添加或修改特殊仪器参数 2011-12-5 shichun.chen  yongchao.li修改2012-01-18
        /// <summary>
        /// 添加或修改特殊仪器参数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objEquipVo"></param>
        /// <param name="p_blnAdd"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngAddSpecialDevice(System.Security.Principal.IPrincipal p_objPrincipal, clsLIS_Equip_DB_ConfigVO p_objEquipVo, bool p_blnAdd)
        {
            long lngRes = 0;

            //lngRes = m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceManageServ", "m_lngAddSpecialDevice");
            //if (lngRes <= 0)
            //{
            //    return lngRes;
            //}
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(9, out objDPArr);
                if (p_blnAdd)
                {
                    strSQL = @"insert into t_bse_lis_interface_online
  (device_model_id_chr,
   online_module_chr,
   online_dns_vchr,
   work_module_chr,
   work_auto_internal_vchr,
   pic_path_vchr,
   other_pram_vchr,
   dataanalysisdll_vchr,
   dataanalysisnamespace_vchr)
values
  (?, ?, ?, ?, ?, ?, ?, ?,?)";

                    objDPArr[0].Value = p_objEquipVo.strLIS_Instrument_Model;
                    objDPArr[1].Value = p_objEquipVo.strONLINE_MODULE_CHR;
                    objDPArr[2].Value = p_objEquipVo.strONLINE_DNS_VCHR;
                    objDPArr[3].Value = p_objEquipVo.strWORK_MODULE_CHR;
                    objDPArr[4].Value = p_objEquipVo.strWORK_AUTO_INTERNAL_VCHR;
                    objDPArr[5].Value = p_objEquipVo.strPIC_PATH_VCHR;
                    objDPArr[6].Value = p_objEquipVo.strOTHER_PRAM_VCHR;
                    objDPArr[7].Value = p_objEquipVo.strData_Analysis_DLL;
                    objDPArr[8].Value = p_objEquipVo.strData_Analysis_Namespace;
                }
                else
                {
                    strSQL = @"update t_bse_lis_interface_online t
   set t.online_module_chr          = ?,
       t.online_dns_vchr            = ?,
       t.work_module_chr            = ?,
       t.work_auto_internal_vchr    = ?,
       t.pic_path_vchr              = ?,
       t.other_pram_vchr            = ?,
       t.dataanalysisdll_vchr       = ?,
       t.dataanalysisnamespace_vchr = ?
 where t.device_model_id_chr = ?
";
                    objDPArr[0].Value = p_objEquipVo.strONLINE_MODULE_CHR;
                    objDPArr[1].Value = p_objEquipVo.strONLINE_DNS_VCHR;
                    objDPArr[2].Value = p_objEquipVo.strWORK_MODULE_CHR;
                    objDPArr[3].Value = p_objEquipVo.strWORK_AUTO_INTERNAL_VCHR;
                    objDPArr[4].Value = p_objEquipVo.strPIC_PATH_VCHR;
                    objDPArr[5].Value = p_objEquipVo.strOTHER_PRAM_VCHR;
                    objDPArr[6].Value = p_objEquipVo.strData_Analysis_DLL;
                    objDPArr[7].Value = p_objEquipVo.strData_Analysis_Namespace;
                    objDPArr[8].Value = p_objEquipVo.strLIS_Instrument_Model;
                }
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);

            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                //
                objHRPSvc.Dispose();
                objHRPSvc = null;
                strSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 获取所有特殊仪器参数信息
        /// <summary>
        /// 获取所有特殊仪器参数信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objEquipVOArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngQuerySepcialDeviceInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsLIS_Equip_DB_ConfigVO[] p_objEquipVOArr)
        {
            long lngRes = 0;
            p_objEquipVOArr = null;
            //
            //lngRes = m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceManageServ", "m_lngQuerySepcialDeviceInfo");
            //if (lngRes <= 0)
            //{
            //    return lngRes;
            //}
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"select t.device_model_id_chr,
       t.online_module_chr,
       t.online_dns_vchr,
       t.work_module_chr,
       t.work_auto_internal_vchr,
       t.pic_path_vchr,
       t.other_pram_vchr,
       t.dataanalysisdll_vchr,
       t.dataanalysisnamespace_vchr,
       t1.device_model_desc_vchr
  from t_bse_lis_interface_online t, t_bse_lis_device_model t1
 where t.device_model_id_chr = t1.device_model_id_chr";
                objHRPSvc = new clsHRPTableService();
                DataTable m_dtResult = null;
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_dtResult);
                if (lngRes > 0 && m_dtResult != null && m_dtResult.Rows.Count > 0)
                {
                    DataRow drTemp = null;
                    p_objEquipVOArr = new clsLIS_Equip_DB_ConfigVO[m_dtResult.Rows.Count];
                    for (int i = 0; i < m_dtResult.Rows.Count; i++)
                    {
                        drTemp = m_dtResult.Rows[i];
                        p_objEquipVOArr[i] = new clsLIS_Equip_DB_ConfigVO();
                        p_objEquipVOArr[i].strLIS_Instrument_Model = drTemp["device_model_id_chr"].ToString().Trim();
                        p_objEquipVOArr[i].strLIS_Instrument_Name = drTemp["device_model_desc_vchr"].ToString().Trim();
                        p_objEquipVOArr[i].strONLINE_MODULE_CHR = drTemp["online_module_chr"].ToString().Trim();
                        p_objEquipVOArr[i].strONLINE_DNS_VCHR = drTemp["online_dns_vchr"].ToString().Trim();
                        p_objEquipVOArr[i].strWORK_MODULE_CHR = drTemp["work_module_chr"].ToString().Trim();
                        p_objEquipVOArr[i].strWORK_AUTO_INTERNAL_VCHR = drTemp["work_auto_internal_vchr"].ToString().Trim();
                        p_objEquipVOArr[i].strPIC_PATH_VCHR = drTemp["pic_path_vchr"].ToString().Trim();
                        p_objEquipVOArr[i].strOTHER_PRAM_VCHR = drTemp["other_pram_vchr"].ToString().Trim();
                        p_objEquipVOArr[i].strData_Analysis_DLL = drTemp["dataanalysisdll_vchr"].ToString().Trim();
                        p_objEquipVOArr[i].strData_Analysis_Namespace = drTemp["dataanalysisnamespace_vchr"].ToString().Trim();
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                //
                objHRPSvc.Dispose();
                objHRPSvc = null;
                strSQL = null;
            }
            return lngRes;
        }
        #endregion

        #region 删除特殊仪器参数 2011-12-5 shichun.chen
        /// <summary>
        /// 删除特殊仪器参数
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strDeviceModelID"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDeleteSpecialDevice(System.Security.Principal.IPrincipal p_objPrincipal, string p_strDeviceModelID)
        {
            long lngRes = 0;
            //
            //lngRes = m_lngCheckCallPrivilege(p_objPrincipal, strClassName, "m_lngDeleteSpecialDevice");
            //if (lngRes <= 0)
            //    return lngRes;
            string strSQL = null;
            clsHRPTableService objHRPSvc = null;
            try
            {
                strSQL = @"delete from t_bse_lis_interface_online t where t.device_model_id_chr = ?";
                IDataParameter[] objDPArr = null;
                objHRPSvc = new clsHRPTableService();
                objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
                objDPArr[0].Value = p_strDeviceModelID;
                long lngEff = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogDetailError(objEx, true);
            }
            finally
            {
                //
                strSQL = null;
                objHRPSvc.Dispose();
                objHRPSvc = null;
            }
            return lngRes;
        }
        #endregion
	}
}
