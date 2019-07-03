using System;
using System.Data;
using System.EnterpriseServices;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Collections;


namespace com.digitalwave.iCare.middletier.LIS
{
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsApplyPropertySv:com.digitalwave.iCare.middletier.clsMiddleTierBase//MiddleTierBase.dll
	{
        //#region 查询所有申请单元属性资料		
        //[AutoComplete]
        //public long m_lngGetAllUnitPropertyAndDetail(System.Security.Principal.IPrincipal p_objPrincipal,
        //    out clsUnitProperty_VO[] p_objPropertyArr,
        //    out clsUnitPropertyValue_VO[] p_objValueArr)
        //{
        //    long lngRes = 0;
        //    p_objPropertyArr = null;
        //    p_objValueArr = null;

        //    string strSQL1 = @"SELECT * FROM t_aid_lis_unit_property ORDER BY inuse_flag_num DESC, property_priority_num ";
        //    string strSQL2 = @"SELECT * FROM t_aid_lis_unit_property_value";
			
        //    try
        //    {
        //        DataTable dtbData = new DataTable();
        //        clsVOConstructor objVOConstructor = new clsVOConstructor();
        //        com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
        //        lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1, ref dtbData);
        //        if(lngRes > 0 && dtbData != null)
        //        {
        //            p_objPropertyArr = new clsUnitProperty_VO[dtbData.Rows.Count];
        //            for(int i=0;i<dtbData.Rows.Count;i++)
        //            {
        //                p_objPropertyArr[i] = objVOConstructor.m_objConstructUnitPropertyVO(dtbData.Rows[i]);
        //            }
        //            lngRes = 0;
        //            dtbData = new DataTable();
        //            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL2,ref dtbData);
        //            if(lngRes >0 && dtbData != null)
        //            {
        //                p_objValueArr = new clsUnitPropertyValue_VO[dtbData.Rows.Count];
        //                for(int j=0;j<dtbData.Rows.Count;j++)
        //                {
        //                    p_objValueArr[j] = objVOConstructor.m_objConstructUnitPropertyValueVO(dtbData.Rows[j]);
        //                }
        //            }
        //        }
        //        if(lngRes <=0)
        //        {
        //            p_objPropertyArr = null;
        //            p_objValueArr = null;
        //        }
        //    }
        //    catch(Exception objEx)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
        //        bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。          
        //    }
        //    return lngRes;
        //}
        //#endregion

		#region 查询所有属性值列表
//		[AutoComplete]
//		public long m_lngGetAllValueList(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable p_dtbData)
//		{
//			long lngRes = 0;
//			p_dtbData = null;
//			string strSQL=@"SELECT *
//							FROM t_aid_lis_unit_property_value 
//							";
//			
//			try
//			{
//				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref p_dtbData);    
//				objHRPSvc.Dispose();                
//			}
//			catch(Exception objEx)
//			{
//				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。          
//			}
//			return lngRes;
//		}
		#endregion

//        #region 根据申请单元ID查询得到一组使用中的 clsUnitPropertyRelate_VO
//        [AutoComplete]
//        public long m_lngGetRelatesByUnitID(System.Security.Principal.IPrincipal p_objPrincipal,
//            string p_strApplyUnitID,out clsUnitPropertyRelate_VO[] p_objVOArr)
//        {
//            long lngRes = 0;
//            p_objVOArr = null;
//            string strSQL=@"SELECT r.*
//							FROM t_aid_lis_unit_propert_relate r, 
//							t_aid_lis_unit_property p,
//							t_aid_lis_unit_property_value v
//
//							where r.UNIT_PROPERTY_ID_CHR = p.property_id_chr 
//							and r.VALUE_ID_CHR = v.vlaue_id_chr 
//							and p.inuse_flag_num = 1 
//							and v.inuse_flag_num = 1 
//							and r.APPLY_UNIT_ID_CHR = ?
//							order by r.unit_property_id_chr, PRIORITY_NUM
//							";
			
//            try
//            {
//                System.Data.IDataParameter[] objDPArr= null;

//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                objHRPSvc.CreateDatabaseParameter(1,out objDPArr);
				

//                objDPArr[0].Value = p_strApplyUnitID;

//                DataTable dtbResult = new DataTable();

//                lngRes=objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dtbResult,objDPArr);
//                if(lngRes > 0 && dtbResult != null)
//                {
//                    clsVOConstructor objVOConstructor = new clsVOConstructor();
//                    int intCount = dtbResult.Rows.Count;
//                    p_objVOArr = new clsUnitPropertyRelate_VO[intCount];
//                    for(int i=0;i<intCount;i++)
//                    {
//                        p_objVOArr[i] = objVOConstructor.m_objConstructUnitPropertyRelateVO(dtbResult.Rows[i]);
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。
//                throw objEx;
//            }
//            return lngRes;
//        }
//        #endregion

		#region 保存基本资料
		[AutoComplete]
		public long m_lngSavePropertyAndValue(System.Security.Principal.IPrincipal p_objPrincipal,
			clsApplyUnitPropertyDoc p_objDoc,out clsApplyUnitPropertyDoc p_objOutDoc)
		{
			p_objOutDoc = p_objDoc;
			long lngRes = 1;
			if(p_objDoc == null)
			{
				return 1;
			}

			try
			{
				foreach(clsApplyUnitProperty  objProperty in p_objDoc.Properties)
				{
					switch(objProperty.State)
					{
						case enmRecordState.New:
							lngRes = m_lngAddProperty(objProperty.PropertyVO);
							break;
						case enmRecordState.Modify:
							lngRes = m_lngUpdateProperty(objProperty.PropertyVO);
							break;
						default:
							break;
					}
					if(lngRes <= 0)
					{
						break;
					}
					foreach(clsPropertyValue objValue in objProperty.Values)
					{
						switch(objValue.State)
						{
							case enmRecordState.New:
								objValue.ValueVO.m_strPROPERTY_ID_CHR = objProperty.PropertyVO.m_strPROPERTY_ID_CHR;
								lngRes = m_lngAddPropertyValue(objValue.ValueVO);
								break;
							case enmRecordState.Modify:
								lngRes = m_lngUpdatePropertyValue(objValue.ValueVO);
								break;
							default:
								break;
						}
						if(lngRes <= 0)
						{
							break;
						}
					}
					if(lngRes <= 0)
					{
						break;
					}
				}
			}
			catch{}
			if(lngRes <= 0)
			{
				System.EnterpriseServices.ContextUtil.SetAbort();
			}
			return lngRes;
		}
		[AutoComplete]
		private long m_lngAddProperty(clsUnitProperty_VO p_objVO)
		{
			long lngRes = 0;
			string strSQL = @"INSERT INTO t_aid_lis_unit_property(PROPERTY_ID_CHR,
							PROPERTY_NAME_VCHR,SUMMARY_VCHR,PROPERTY_PRIORITY_NUM,INUSE_FLAG_NUM) 
							VALUES (?, ?, ?, ?, ?)";

			try
			{
				System.Data.IDataParameter[] objDPArr= null;

				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.CreateDatabaseParameter(5,out objDPArr);
				
				string strNewID=null;
				objHRPSvc.m_lngGenerateNewID("t_aid_lis_unit_property","PROPERTY_ID_CHR",out strNewID);
				if(strNewID == null || strNewID == "")
				{
					throw new Exception("不能分配ID");
				}
				p_objVO.m_strPROPERTY_ID_CHR = strNewID;

				

				objDPArr[0].Value = p_objVO.m_strPROPERTY_ID_CHR;
				objDPArr[1].Value = p_objVO.m_strPROPERTY_NAME_VCHR;
				objDPArr[2].Value = p_objVO.m_strSUMMARY_VCHR;
				objDPArr[3].Value = p_objVO.m_intPROPERTY_PRIORITY_NUM;
				objDPArr[4].Value = p_objVO.m_intINUSE_FLAG_NUM;

				long lngRecEff = -1;

				lngRes=objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDPArr);
			}
			catch(Exception objEx)
			{                
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);	
				throw objEx;
			}
			return lngRes;
		}
		[AutoComplete]
		private long m_lngAddPropertyValue(clsUnitPropertyValue_VO p_objVO)
		{
			long lngRes = 0;
			string strSQL = @"INSERT INTO t_aid_lis_unit_property_value(PROPERTY_ID_CHR,
							VLAUE_ID_CHR,VLAUE_VCHR,INUSE_FLAG_NUM) 
							VALUES (?, ?, ?, ?)";

			try
			{
				System.Data.IDataParameter[] objDPArr= null;

				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.CreateDatabaseParameter(4,out objDPArr);
				
				string strNewID=null;
				objHRPSvc.m_lngGenerateNewID("t_aid_lis_unit_property_value","VLAUE_ID_CHR",out strNewID);
				if(strNewID == null || strNewID == "")
				{
					throw new Exception("不能分配ID");
				}
				p_objVO.m_strVALUE_ID_CHR = strNewID;

				

				objDPArr[0].Value = p_objVO.m_strPROPERTY_ID_CHR;
				objDPArr[1].Value = p_objVO.m_strVALUE_ID_CHR;
				objDPArr[2].Value = p_objVO.m_strVLAUE_VCHR;
				objDPArr[3].Value = p_objVO.m_intINUSE_FLAG_NUM;

				long lngRecEff = -1;

				lngRes=objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDPArr);
			}
			catch(Exception objEx)
			{                
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);	
				throw objEx;
			}
			return lngRes;
		}
		[AutoComplete]
		private long m_lngUpdateProperty(clsUnitProperty_VO p_objVO)
		{
			long lngRes = 0;
			string strSQL = @"UPDATE t_aid_lis_unit_property  SET 
							PROPERTY_NAME_VCHR = ?,SUMMARY_VCHR = ?,
							PROPERTY_PRIORITY_NUM = ?,INUSE_FLAG_NUM = ?
							WHERE PROPERTY_ID_CHR = ?";

			try
			{
				System.Data.IDataParameter[] objDPArr= null;

				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.CreateDatabaseParameter(5,out objDPArr);
				
				objDPArr[0].Value = p_objVO.m_strPROPERTY_NAME_VCHR;
				objDPArr[1].Value = p_objVO.m_strSUMMARY_VCHR;
				objDPArr[2].Value = p_objVO.m_intPROPERTY_PRIORITY_NUM;
				objDPArr[3].Value = p_objVO.m_intINUSE_FLAG_NUM;
				objDPArr[4].Value = p_objVO.m_strPROPERTY_ID_CHR;

				long lngRecEff = -1;

				lngRes=objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDPArr);
			}
			catch(Exception objEx)
			{                
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);	
				throw objEx;
			}
			return lngRes;
		}
		[AutoComplete]
		private long m_lngUpdatePropertyValue(clsUnitPropertyValue_VO p_objVO)
		{
			long lngRes = 0;
			string strSQL = @"UPDATE t_aid_lis_unit_property_value SET
							PROPERTY_ID_CHR = ?,
							VLAUE_VCHR = ?,
							INUSE_FLAG_NUM = ?
							WHERE VLAUE_ID_CHR = ?";

			try
			{
				System.Data.IDataParameter[] objDPArr= null;

				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.CreateDatabaseParameter(4,out objDPArr);

				objDPArr[0].Value = p_objVO.m_strPROPERTY_ID_CHR;
				objDPArr[1].Value = p_objVO.m_strVLAUE_VCHR;
				objDPArr[2].Value = p_objVO.m_intINUSE_FLAG_NUM;
				objDPArr[3].Value = p_objVO.m_strVALUE_ID_CHR;

				long lngRecEff = -1;

				//往表t_opr_lis_application增加记录
				lngRes=objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDPArr);
			}
			catch(Exception objEx)
			{                
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);	
				throw objEx;
			}
			return lngRes;
		}

		#endregion

		#region 保存关联

		[AutoComplete]
		public long m_lngSaveRelate(System.Security.Principal.IPrincipal p_objPrincipal,
			string p_strApplyUnitID,
			clsUnitPropertyRelate_VO[] p_objVOArr)
		{
			long lngRes = 0;
			if(p_objVOArr != null)
			{
				lngRes = m_lngDeteleRelate(p_strApplyUnitID);
				if(lngRes >0)
				{
					foreach(clsUnitPropertyRelate_VO objRelateVO in p_objVOArr)
					{
						lngRes = 0;
						lngRes = m_lngAddRelate(objRelateVO);
						if(lngRes <=0)
							break;
					}
				}
			}
			else 
				lngRes = 1;

			if(lngRes <=0)
			{
				System.EnterpriseServices.ContextUtil.SetAbort();
			}
			return lngRes;
		}

		[AutoComplete]
		private long m_lngDeteleRelate(string p_strApplyUnitID)
		{
			long lngRes = 0;
			string strSQL=@"DELETE
							FROM t_aid_lis_unit_propert_relate
							WHERE APPLY_UNIT_ID_CHR = ?
							";
			
			try
			{
				System.Data.IDataParameter[] objDPArr= null;

				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				objHRPSvc.CreateDatabaseParameter(1,out objDPArr);
				

				objDPArr[0].Value = p_strApplyUnitID;

				long lngEff = 0;
				lngRes=objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngEff,objDPArr);	
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。     
				throw objEx;
			}
			return lngRes;
		}

		[AutoComplete]
		private long m_lngAddRelate(clsUnitPropertyRelate_VO p_objVO)
		{
			long lngRes = 0;

			string strSQL = @"INSERT INTO t_aid_lis_unit_propert_relate
										  (APPLY_UNIT_ID_CHR, UNIT_PROPERTY_ID_CHR, 
											PRIORITY_NUM,VALUE_ID_CHR
										  )
								   VALUES (?, ?,?,?)";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				System.Data.IDataParameter[] objDPArr = null;
				objHRPSvc.CreateDatabaseParameter(4,out objDPArr);

				objDPArr[0].Value = p_objVO.m_strAPPLY_UNIT_ID_CHR;
				objDPArr[1].Value = p_objVO.m_strUNIT_PROPERTY_ID_CHR;
				objDPArr[2].Value = p_objVO.m_intPRIORITY_NUM;
				objDPArr[3].Value = p_objVO.m_strVALUE_ID_CHR;

				long lngRecEff = -1;
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objDPArr);
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
				throw objEx;
			}
			return lngRes;
		}
		#endregion

//        #region		返回所有的使用的属性id
//        /// <summary>
//        /// 返回所有的使用的属性id
//        /// </summary>
//        /// <param name="p_objPrincipal">是否有权限</param>
//        /// <param name="p_objResultArr">结果集合</param>
//        /// <returns>是否成功</returns>
//        [AutoComplete]
//        public long m_lngGetAllPropertyId(System.Security.Principal.IPrincipal p_objPrincipal, out string[] p_strResultArr)
//        {
//            p_strResultArr = null;
//            long lngRes=0;

////			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
////			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetAllPropertyId");
////			if(lngRes < 0)
////			{
////				return -1;
////			}

//            string strSQL = @"SELECT * FROM t_aid_lis_unit_property WHERE inuse_flag_num = 1 ORDER BY property_priority_num";
//            try
//            {
//                DataTable dtbResult = new DataTable();
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
//                if(lngRes > 0 && dtbResult.Rows.Count > 0)
//                {
//                    p_strResultArr = new string[dtbResult.Rows.Count];
//                    for(int i1=0;i1<p_strResultArr.Length;i1++)
//                    {
//                        p_strResultArr[i1] = dtbResult.Rows[i1]["PROPERTY_ID_CHR"].ToString();
//                    }
//                }
//            }
//            catch(Exception objEx)
//            {
//                string strTmp=objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion

//        #region		返回满足条件的属性值集合
//        /// <summary>
//        /// 返回满足条件的属性值集合
//        /// </summary>
//        /// <param name="p_objPrincipal">是否有权限</param>
//        /// <param name="p_strPropertyId">属性id</param>
//        /// <param name="p_strApplyUnitId">申请单元id</param>
//        /// <param name="p_arlResult">返回结果集合</param>
//        /// <returns>是否成功</returns>
//        [AutoComplete]
//        public long m_lngGetPropertyValue(System.Security.Principal.IPrincipal p_objPrincipal,string p_strPropertyId,string p_strApplyUnitId,out ArrayList p_arlResult)
//        {
//            p_arlResult = null;
//            long lngRes=0;
//            //change by wjqin(06-4-23)
////			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
////			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngGetPropertyValue");
////			if(lngRes < 0)
////			{
////				return -1;
////			}

////            string strSQL = @"SELECT b.vlaue_vchr
////								FROM t_aid_lis_unit_propert_relate a, t_aid_lis_unit_property_value b,t_aid_lis_unit_property c
////								WHERE a.apply_unit_id_chr = '" + p_strApplyUnitId + @"'
////								AND a.unit_property_id_chr = '" + p_strPropertyId + @"'
////								AND a.value_id_chr = b.vlaue_id_chr
////								AND b.inuse_flag_num = 1
////								AND a.unit_property_id_chr = c.property_id_chr
////								AND c.inuse_flag_num = 1
////								ORDER BY a.priority_num";
////            try
////            {
////                DataTable dtbResult = new DataTable();
////                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
////                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
////                objHRPSvc.Dispose();
////                if(lngRes > 0 && dtbResult.Rows.Count > 0)
////                {
////                    p_arlResult = new ArrayList();
////                    for(int i1=0;i1<dtbResult.Rows.Count;i1++)
////                    {
////                        p_arlResult.Add(dtbResult.Rows[i1]["VLAUE_VCHR"].ToString());
////                    }
////                }
////            }
////            catch(Exception objEx)
////            {
////                string strTmp=objEx.Message;
////                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
////                bool blnRes = objLogger.LogError(objEx);
////            }
////            return lngRes;

//            string strSQL = @"SELECT b.vlaue_vchr
//								FROM t_aid_lis_unit_propert_relate a, t_aid_lis_unit_property_value b,t_aid_lis_unit_property c
//								WHERE a.apply_unit_id_chr = ?
//								AND a.unit_property_id_chr = ?
//								AND a.value_id_chr = b.vlaue_id_chr
//								AND b.inuse_flag_num = 1
//								AND a.unit_property_id_chr = c.property_id_chr
//								AND c.inuse_flag_num = 1
//								ORDER BY a.priority_num";
//            try
//            {
//                System.Data.IDataParameter[] objDPArr = null;
//                DataTable dtbResult = new DataTable();
//                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
//                objHRPSvc.CreateDatabaseParameter(2, out objDPArr);
//                objDPArr[0].Value = p_strApplyUnitId.PadRight(6,' ');
//                objDPArr[1].Value = p_strPropertyId.PadRight(5,' ');
             
//                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtbResult, objDPArr);
			
//                objHRPSvc.Dispose();
//                if (lngRes > 0 && dtbResult.Rows.Count > 0)
//                {
//                    p_arlResult = new ArrayList();
//                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
//                    {
//                        p_arlResult.Add(dtbResult.Rows[i1]["VLAUE_VCHR"].ToString());
//                    }
//                }
//            }
//            catch (Exception objEx)
//            {
//                string strTmp = objEx.Message;
//                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
//                bool blnRes = objLogger.LogError(objEx);
//            }
//            return lngRes;
//        }
//        #endregion
	}
}
