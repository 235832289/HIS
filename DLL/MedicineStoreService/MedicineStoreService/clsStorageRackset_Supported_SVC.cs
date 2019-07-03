using System;
using System.Collections.Generic;
using System.Text;
using System.EnterpriseServices;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.security;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.middletier.MedicineStoreService
{
    /// <summary>
    /// 仓库设置
    /// </summary>
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Supported)]
    [ObjectPooling(true)]
    public class clsStorageRackset_Supported_SVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
   {
       #region 根据库房类型id获取相应库房基本信息
        /// <summary>
       ///  根据库房类型id获取相应库房基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
       /// <param name="m_strType">1,药库货架 2,药房货架</param>
        /// <param name="p_objMedicineStoreroomInfoArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetStorageInfoByTypeid(System.Security.Principal.IPrincipal p_objPrincipal,string m_strType, out clsMS_MedicineStoreroom_VO[] p_objMedicineStoreroomInfoArr)
        {
            p_objMedicineStoreroomInfoArr = null;
            DataTable m_dtbMedicineStoreroom = null;
            long lngRes = 0;
            try
            {
                if (m_strType == "1")
                {
                    string strSQL = @"select distinct t.medicineroomid   MedicineRoomID,
                t.medicineroomname MedicineRoomName
                  from t_ms_medicinestoreroomset t
                 order by t.medicineroomid";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtbMedicineStoreroom);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    int index = 0;
                    if (m_dtbMedicineStoreroom.Rows.Count > 0)
                    {
                        p_objMedicineStoreroomInfoArr = new clsMS_MedicineStoreroom_VO[m_dtbMedicineStoreroom.Rows.Count];

                        for (; index < m_dtbMedicineStoreroom.Rows.Count; index++)
                        {
                            p_objMedicineStoreroomInfoArr[index] = new clsMS_MedicineStoreroom_VO();
                            p_objMedicineStoreroomInfoArr[index].m_strMedicineRoomID_VCHR = m_dtbMedicineStoreroom.Rows[index]["MedicineRoomID"] as string;
                            p_objMedicineStoreroomInfoArr[index].m_strMedicineRoomName_VCHR = m_dtbMedicineStoreroom.Rows[index]["MedicineRoomName"] as string;
                            p_objMedicineStoreroomInfoArr[index].m_strMedicineTypeID_CHR = null;
                        }
                    }
                }
                else
                {
                    string strSQL = @"select a.medstoreid_chr, a.medstorename_vchr
                                      from t_bse_medstore a
                                      order by a.medstoreid_chr";

                    clsHRPTableService objHRPServ = new clsHRPTableService();
                    lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtbMedicineStoreroom);
                    objHRPServ.Dispose();
                    objHRPServ = null;
                    int index = 0;
                    if (m_dtbMedicineStoreroom.Rows.Count > 0)
                    {
                        p_objMedicineStoreroomInfoArr = new clsMS_MedicineStoreroom_VO[m_dtbMedicineStoreroom.Rows.Count];

                        for (; index < m_dtbMedicineStoreroom.Rows.Count; index++)
                        {
                            p_objMedicineStoreroomInfoArr[index] = new clsMS_MedicineStoreroom_VO();
                            p_objMedicineStoreroomInfoArr[index].m_strMedicineRoomID_VCHR = m_dtbMedicineStoreroom.Rows[index]["medstoreid_chr"] as string;
                            p_objMedicineStoreroomInfoArr[index].m_strMedicineRoomName_VCHR = m_dtbMedicineStoreroom.Rows[index]["medstorename_vchr"] as string;
                            p_objMedicineStoreroomInfoArr[index].m_strMedicineTypeID_CHR = null;
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        
       #region 获取仓库类型信息
       /// <summary>
        /// 获取仓库类型信息.
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMedicineStoreroomInfoArr">返回结果.</param>
        /// <returns></returns>
       [AutoComplete]
        public long m_lngGetMedicineStoreroomInfo(System.Security.Principal.IPrincipal p_objPrincipal, out clsMS_MedicineStoreroom_VO[] p_objMedicineStoreroomInfoArr)
        {
            p_objMedicineStoreroomInfoArr = null;
            DataTable m_dtbMedicineStoreroom = null;
            long lngRes = 0;
            try
            {
                string strSQL = @"select distinct t.medicineroomid   MedicineRoomID,
                t.medicineroomname MedicineRoomName
                  from t_ms_medicinestoreroomset t
                 order by t.medicineroomid";

                clsHRPTableService objHRPServ = new clsHRPTableService();
                lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSQL, ref m_dtbMedicineStoreroom);
                objHRPServ.Dispose();
                objHRPServ = null;
                int index = 0;
                if (m_dtbMedicineStoreroom.Rows.Count > 0)
                {
                    p_objMedicineStoreroomInfoArr = new clsMS_MedicineStoreroom_VO[m_dtbMedicineStoreroom.Rows.Count];

                    for (; index < m_dtbMedicineStoreroom.Rows.Count; index++)
                    {
                        p_objMedicineStoreroomInfoArr[index] = new clsMS_MedicineStoreroom_VO();
                        p_objMedicineStoreroomInfoArr[index].m_strMedicineRoomID_VCHR = m_dtbMedicineStoreroom.Rows[index]["MedicineRoomID"] as string;
                        p_objMedicineStoreroomInfoArr[index].m_strMedicineRoomName_VCHR = m_dtbMedicineStoreroom.Rows[index]["MedicineRoomName"] as string;
                        p_objMedicineStoreroomInfoArr[index].m_strMedicineTypeID_CHR = null;
                    }
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

       #region 获取最大的再部ID
        /// <summary>
        /// 获取最大的再部ID
        /// </summary>
        /// <returns>返回最大ID</returns>
        /// 
       [AutoComplete]
       public string m_lngGetMaxId()
       {
           DataTable m_dtb = null;
           try
           {
               string strSql = "select max(storagerackid_chr) as maxId from t_ms_storagerackset";
               clsHRPTableService objHRPServ = new clsHRPTableService();
               long lngRes = objHRPServ.lngGetDataTableWithoutParameters(strSql, ref m_dtb);
               objHRPServ.Dispose();
               objHRPServ = null;
               if (m_dtb == null || m_dtb.Rows[0]["maxId"] == DBNull.Value)
               {
                   return "0001";
               }
               int i_Id = Convert.ToInt16(m_dtb.Rows[0]["maxId"].ToString());
               string i_maxId = Convert.ToString(i_Id + 1);
               return i_maxId.PadLeft(4, '0');
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return null;
       }
        #endregion

       #region 获取货架明细
       /// <summary>
       ///  获取货架明细
       /// </summary>
       /// <param name="m_strType"></param>
       /// <param name="objSto_Vo"></param>
       [AutoComplete]
       public void m_lngGetStor(string m_strType,out clsMS_StorInfoVo[] objSto_Vo)
       {
           DataTable m_dtb = new DataTable();
           objSto_Vo = null;
           try
           {
                  string strSql = @"select distinct a.storagerackid_chr,
                                    a.storagerackcode_vchr,
                                    a.storageid_chr,
                                    a.typeid_int,
                                    a.storagerackname_vchr,
                                    a.pycode_chr,
                                    a.wbcode_chr,
                                    b.medicineroomname
                                    from t_ms_storagerackset a, t_ms_medicinestoreroomset b
                                    where a.storageid_chr = b.medicineroomid
                                    and a.typeid_int = ?
                                    order by a.storagerackid_chr";
               if(m_strType=="2")
                      strSql = @" select distinct a.storagerackid_chr,
                                  a.storagerackcode_vchr,
                                  a.storageid_chr,
                                  a.typeid_int,
                                  a.storagerackname_vchr,
                                  a.pycode_chr,
                                  a.wbcode_chr,
                                  b.medstorename_vchr as medicineroomname
                                  from t_ms_storagerackset a, t_bse_medstore b
                                  where a.storageid_chr = b.medstoreid_chr
                                  and a.typeid_int = ?
                                  order by a.storagerackid_chr";
               clsHRPTableService objHRPServ = new clsHRPTableService();
         
               System.Data.IDataParameter[] DataParas = null;
               objHRPServ.CreateDatabaseParameter(1, out DataParas);
               DataParas[0].Value = m_strType;
               objHRPServ.lngGetDataTableWithParameters(strSql, ref m_dtb, DataParas);
               objHRPServ.Dispose();
               objHRPServ = null;
               objSto_Vo = new clsMS_StorInfoVo[m_dtb.Rows.Count];
              
               for (int i = 0; i < m_dtb.Rows.Count; i++)
               {
                   objSto_Vo[i] = new clsMS_StorInfoVo();
                   objSto_Vo[i].m_ID = m_dtb.Rows[i]["storagerackid_chr"].ToString();
                   objSto_Vo[i].m_storId = m_dtb.Rows[i]["storagerackcode_vchr"].ToString();
                   objSto_Vo[i].m_ageID = m_dtb.Rows[i]["storageid_chr"].ToString();
                   objSto_Vo[i].m_intTypeid = Convert.ToInt32(m_dtb.Rows[i]["typeid_int"]);
                   objSto_Vo[i].m_storName = m_dtb.Rows[i]["storagerackname_vchr"].ToString();
                   objSto_Vo[i].m_pycode = m_dtb.Rows[i]["pycode_chr"].ToString();
                   objSto_Vo[i].m_wbcode = m_dtb.Rows[i]["wbcode_chr"].ToString();
                   objSto_Vo[i].m_ageName = m_dtb.Rows[i]["medicineroomname"].ToString();
               }
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }

       }
       #endregion
    
       #region 查询货架编码是否已存在
       /// <summary>
       /// 查询货架编码是否已存在.不存在返回True,存在返回False
       /// </summary>
       /// <param name="m_strStorId"></param>
       /// <returns></returns>
       [AutoComplete]
       public bool m_lngFindStoreId(string m_strStorgeType, string m_strStorId)
       {

           clsHRPTableService objHRPServ = new clsHRPTableService();
           string strSql = @"select count(storagerackid_chr) as idNo from t_ms_storagerackset where storagerackcode_vchr = ? and typeid_int=?";
           DataTable m_dtb = new DataTable();
           IDataParameter[] objDPArr = null;
           objHRPServ.CreateDatabaseParameter(2, out objDPArr);
           objDPArr[0].Value = m_strStorId;
           objDPArr[1].Value = m_strStorgeType;
           objHRPServ.lngGetDataTableWithParameters(strSql, ref m_dtb, objDPArr);
           objHRPServ.Dispose();
           objHRPServ = null;
           if (m_dtb.Rows[0]["idNo"].ToString() == "0")
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       #endregion
      
       #region 获取药品类型数据
       /// <summary>
       /// 表：t_aid_medicinetype 
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_dtm1"></param>
       /// <param name="p_objData"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetMedicineTypeData(System.Security.Principal.IPrincipal p_objPrincipal, out clsValue_MedicineType_VO[] p_objData)
       {
           p_objData = new clsValue_MedicineType_VO[0];
           long lngRes = 0;
           //权限控制,clsPrivilegeHandleService为权限处理服务类
           com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
           lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC", "m_lngGetMedicineTypeData");
           if (lngRes < 0)
               return -1;

           //创建COM对象
           com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
           string strSQL = @"select medicinetypeid_chr,medicinetypename_vchr from t_aid_medicinetype order by medicinetypeid_chr asc";

           DataTable dtbResult = new DataTable();
           try
           {
               lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
               if (lngRes > 0 && dtbResult != null)
               {
                   p_objData = new clsValue_MedicineType_VO[dtbResult.Rows.Count];
                   DataRow m_drDataRow = null;
                   clsValue_MedicineType_VO tmp_p_objData = null;

                   for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                   {
                       tmp_p_objData = new clsValue_MedicineType_VO();
                       m_drDataRow = dtbResult.Rows[i1];
                       tmp_p_objData.m_strMedicineTypeID = m_drDataRow["medicinetypeid_chr"].ToString();
                       tmp_p_objData.m_strMedicineTypeName = m_drDataRow["medicinetypename_vchr"].ToString();

                       p_objData[i1] = tmp_p_objData;

                   }
                   m_drDataRow = null;
               }
               objHRPSvc.Dispose();
           }
           catch (Exception objEx)
           {
               string strTmp = objEx.Message;
               com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           objHRPSvc.Dispose();
           return lngRes;
       }
       #endregion

       #region 获取货架数据
       /// <summary>
       /// 获取货架数据 
       /// </summary>
       /// <param name="p_objPrincipal">权限</param>
       /// <param name="p_strStoreID">药库名称</param>
       /// <param name="m_dtbStorageRack">货架</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_mthGetStorageShelfInfo(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStoreID, out DataTable m_dtbStorageShelf)
       {
           m_dtbStorageShelf = new DataTable();
           m_dtbStorageShelf.Columns.Add("storagerackid_chr");
           m_dtbStorageShelf.Columns.Add("storagerackname_vchr");
           long lngRes = 0;

           //权限控制,clsPrivilegeHandleService为权限处理服务类
           com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
           lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC", "m_mthGetStorageShelfInfo");
           if (lngRes < 0)
               return -1;

           com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
           string strSQL = @"select a.storagerackid_chr, a.storagerackname_vchr
	from t_ms_storagerackset a
 where a.storageid_chr = ?
	 and a.typeid_int = 1
 order by a.storagerackid_chr";

           try
           {
               IDataParameter[] objDPArr = null;
               objHRPSvc.CreateDatabaseParameter(1, out objDPArr);
               objDPArr[0].Value = p_strStoreID;
               lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref m_dtbStorageShelf, objDPArr);
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

       #region 获取药库库存货架数据
       /// <summary>
       /// 获取药库库存货架数据
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="p_dtm1"></param>
       /// <param name="p_objData"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngGetStorageShelfData(System.Security.Principal.IPrincipal p_objPrincipal, string p_strStorageID, string p_strMedicineID, string p_strAssistCode, string p_strMedicineTypeID,
           List<string> p_lstMedicineType, ref DataTable dtbResult)
       {
           long lngRes = 0;

           //权限控制,clsPrivilegeHandleService为权限处理服务类
           com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
           lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageRacksetSVC", "m_lngGetStorageShelfData");
           if (lngRes < 0)
           {
               dtbResult = null;
               return -1;
           }

           //创建COM对象
           com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

           StringBuilder strSQL = new StringBuilder(@"select a.seriesid_int,
			 a.medicineid_chr,
			 a.medicinename_vchr,
			 a.medspec_vchr,
			 a.storagerackid_chr,
			 a.opunit_vchr,
			 b.productorid_chr,
			 b.assistcode_chr,
			 b.pycode_chr,
			 b.wbcode_chr,
			 sum(d.availagross_int) availagross_int,
			 sum(d.realgross_int) realgross_int
	from t_ms_storage a
	left join t_bse_medicine b on b.medicineid_chr = a.medicineid_chr
	left join t_ms_storage_detail d on d.medicineid_chr = a.medicineid_chr
																 and d.storageid_chr = a.storageid_chr
																 and d.status = 1
 
 ");


           try
           {
               int m_intParamCount = 1;

               StringBuilder m_strbCondition = new StringBuilder("");

               clsHRPTableService objHRPServ = new clsHRPTableService();
               IDataParameter[] objDPArr = null;
               IDataParameter[] tmp_objDPArr = null;
               objHRPServ.CreateDatabaseParameter(12 + p_lstMedicineType.Count, out tmp_objDPArr);
               strSQL.Append(@" where a.storageid_chr = ? ");
               tmp_objDPArr[0].Value = p_strStorageID;

               if (p_strMedicineID.Trim().Length > 0)
               {
                   strSQL.Append(@" and (a.medicineid_chr = ?)");
                   ++m_intParamCount;
                   tmp_objDPArr[m_intParamCount - 1].Value = p_strMedicineID;
               }
               else
               {
                   if (p_strAssistCode.Length > 0)
                   {
                       strSQL.Append(@" and ((a.medicineid_chr like ?)
                                       or (b.assistcode_chr like ?) 
                                       or (a.medicinename_vchr like ?)
                                       or (b.pycode_chr like ?) 
                                       or (b.wbcode_chr like ?))");
                       for (int i1 = 0; i1 < 5; i1++)
                       {
                           tmp_objDPArr[m_intParamCount + i1].Value = p_strAssistCode;
                       }
                       m_intParamCount = m_intParamCount + 5;
                   }
               }

               if (p_lstMedicineType.Count > 0)
               {
                   strSQL.Append(@" and ((b.medicinetypeid_chr=?)");
                   ++m_intParamCount;
                   tmp_objDPArr[m_intParamCount - 1].Value = p_lstMedicineType[0].ToString();

                   for (int i1 = 1; i1 < p_lstMedicineType.Count; i1++)
                   {
                       strSQL.Append(@" or (b.medicinetypeid_chr=?)");
                       ++m_intParamCount;
                       tmp_objDPArr[m_intParamCount - 1].Value = p_lstMedicineType[i1].ToString();
                   }
                   strSQL.Append(@")");
               }
               strSQL.Append(@" group by a.seriesid_int,
					b.assistcode_chr,
					a.medicineid_chr,
					a.medicinename_vchr,
					a.medspec_vchr,
					a.storagerackid_chr,
					a.opunit_vchr,
					b.productorid_chr,
					b.pycode_chr,
					b.wbcode_chr
 order by b.assistcode_chr asc");

               objHRPServ.CreateDatabaseParameter(m_intParamCount, out objDPArr);

               for (int i1 = 0; i1 < m_intParamCount; i1++)
               {
                   objDPArr[i1].Value = tmp_objDPArr[i1].Value;
                   objDPArr[i1].DbType = tmp_objDPArr[i1].DbType;
               }


               lngRes = objHRPServ.lngGetDataTableWithParameters(strSQL.ToString(), ref dtbResult, objDPArr);
               if (dtbResult.Rows.Count > 0)
               {
                   DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                   dcPrimaryKeyArr[0] = dtbResult.Columns["seriesid_int"];
                   dtbResult.PrimaryKey = dcPrimaryKeyArr;
                   for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                   {
                       dtbResult.Rows[i1]["opunit_vchr"] = dtbResult.Rows[i1]["opunit_vchr"].ToString().Trim();
                   }
               }

               objHRPSvc.Dispose();
           }
           catch (Exception objEx)
           {
               string strTmp = objEx.Message;
               com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
               bool blnRes = objLogger.LogError(objEx);
               dtbResult = null;
           }
           objHRPSvc.Dispose();
           return lngRes;
       }
       #endregion
   }
}
