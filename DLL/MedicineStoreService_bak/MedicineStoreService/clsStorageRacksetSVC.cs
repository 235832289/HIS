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
    [System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
    [ObjectPooling(true)]
   public class clsStorageRacksetSVC : com.digitalwave.iCare.middletier.clsMiddleTierBase
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

       #region 插入货架记录
       /// <summary>
       /// 插入货架记录
       /// </summary>
       /// <param name="m_Stor">货架信息VO</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngInsertStoreInfo(clsMS_StorInfoVo m_Stor)
       {
           IDataParameter[] objDPArr = null;
           clsHRPTableService objHRPServ = new clsHRPTableService();

           string strSQL = @"insert into t_ms_storagerackset
                (storagerackid_chr, storagerackcode_vchr,storageid_chr 
                ,typeid_int ,storagerackname_vchr, pycode_chr,wbcode_chr)
                values
                (?,?,?,?,?,?,?)";
           objHRPServ.CreateDatabaseParameter(7, out objDPArr);
           objDPArr[0].Value = m_lngGetMaxId();
           objDPArr[1].Value = m_Stor.m_storId;
           objDPArr[2].Value = m_Stor.m_ageID;
           objDPArr[3].Value = m_Stor.m_intTypeid;
           objDPArr[4].Value = m_Stor.m_storName;
           objDPArr[5].Value = m_Stor.m_pycode;
           objDPArr[6].Value = m_Stor.m_wbcode;
           
           long lngEff = -1;
           long lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
           return lngRes;
       }
       #endregion

       #region 修改货架记录
       /// <summary>
       /// 插入货架记录
       /// </summary>
       /// <param name="m_Stor">货架信息VO</param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngEditStoreInfo(clsMS_StorInfoVo m_Stor)
       {
           IDataParameter[] objDPArr = null;
           clsHRPTableService objHRPServ = new clsHRPTableService();

           string strSQL = @"update t_ms_storagerackset set 
                    storagerackcode_vchr= ? ,
                    storageid_chr= ? ,
                    typeid_int= ? ,
                    storagerackname_vchr= ? ,
                    pycode_chr= ? ,
                    wbcode_chr= ?
                    where storagerackid_chr = ?";
           objHRPServ.CreateDatabaseParameter(7, out objDPArr);
           objDPArr[0].Value = m_Stor.m_storId;
           objDPArr[1].Value = m_Stor.m_ageID;
           objDPArr[2].Value = m_Stor.m_intTypeid;
           objDPArr[3].Value = m_Stor.m_storName;
           objDPArr[4].Value = m_Stor.m_pycode;
           objDPArr[5].Value = m_Stor.m_wbcode;
           objDPArr[6].Value = m_Stor.m_ID;

           long lngEff = -1;
           long lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
           return lngRes;
       }
       #endregion

       #region 删除货架记录
       /// <summary>
       /// 删除货架记录
       /// </summary>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngDelStoreInfo(string m_strStorId)
       {
           IDataParameter[] objDPArr = null;
           clsHRPTableService objHRPServ = new clsHRPTableService();
           string strSQL = @"delete t_ms_storagerackset where storagerackid_chr = ?";
           objHRPServ.CreateDatabaseParameter(1, out objDPArr);
           objDPArr[0].Value = m_strStorId;
           long lngEff = -1;
           long lngRes = objHRPServ.lngExecuteParameterSQL(strSQL, ref lngEff, objDPArr);
           return lngRes;
       }
       #endregion

       #region 查询货架编码是否已存在
       /// <summary>
       /// 查询货架编码是否已存在.不存在返回True,存在返回False
       /// </summary>
       /// <param name="m_strStorId"></param>
       /// <returns></returns>
       [AutoComplete]
       public bool m_lngFindStoreId(string m_strStorgeType,string m_strStorId)
       {

           clsHRPTableService objHRPServ = new clsHRPTableService();
           string strSql = @"select count(storagerackid_chr) as idNo from t_ms_storagerackset where storagerackcode_vchr = ? and typeid_int=?";
           DataTable m_dtb = new DataTable();
           IDataParameter[] objDPArr = null;
           objHRPServ.CreateDatabaseParameter(2, out objDPArr);
           objDPArr[0].Value = m_strStorId;
           objDPArr[1].Value = m_strStorgeType;
           objHRPServ.lngGetDataTableWithParameters(strSql, ref m_dtb, objDPArr);
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

       #region 保存货架
       /// <summary>
       /// 保存货架
       /// </summary>
       /// <param name="p_objPrincipal">权限</param>
       /// <param name="p_dtbModify"></param>
       /// <returns></returns>
       [AutoComplete]
       public long m_lngSaveStorageShelf(System.Security.Principal.IPrincipal p_objPrincipal, DataTable p_dtbModify)
       {
           long lngRes = 0;
           try
           {
               string strSQL = @"update t_ms_storage a set a.storagerackid_chr = ? where a.seriesid_int = ?";

               clsHRPTableService objHRPServ = new clsHRPTableService();
               DbType[] dbTypes = new DbType[] { DbType.String, DbType.Int64 };

               object[][] objValues = new object[2][];

               int intItemCount = p_dtbModify.Rows.Count;
               for (int j = 0; j < objValues.Length; j++)
               {
                   objValues[j] = new object[intItemCount];//初始化

               }

               for (int i1 = 0; i1 < p_dtbModify.Rows.Count; i1++)
               {
                   objValues[0][i1] = Convert.ToString(p_dtbModify.Rows[i1]["storagerackid_chr"]);
                   objValues[1][i1] = Convert.ToInt64(p_dtbModify.Rows[i1]["seriesid_int"]);
               }

               lngRes = objHRPServ.m_lngSaveArrayWithParameters(strSQL, objValues, dbTypes);
               objHRPServ.Dispose();
               objHRPServ = null;
           }
           catch (Exception objEx)
           {
               com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
               bool blnRes = objLogger.LogError(objEx);
           }
           return lngRes;
       }
       #endregion 
   }
}
