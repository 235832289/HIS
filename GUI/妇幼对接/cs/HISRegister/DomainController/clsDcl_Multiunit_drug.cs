using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.HIS
{
    class clsDcl_Multiunit_drug : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsDcl_Multiunit_drug()
        {

        }
        #endregion

        #region 获取药品列表
        /// <summary>
        /// 获取药品列表
        /// </summary>
        /// <param name="p_dtMedicineList"></param>
        /// <returns></returns>
        public long m_lngGetTableMedicineList(ref DataTable p_dtMedicineList)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            long lngRes = m_objService.m_lngGetTableMedicineList(ref p_dtMedicineList);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取单位列表
        /// <summary>
        /// 获取单位列表
        /// </summary>
        /// <param name="p_strId"></param>
        /// <param name="p_intBy"></param>
        /// <param name="p_dtAliasList"></param>
        /// <returns></returns>
        public long m_lngGetTableMultiUnitList(string p_strId, out DataTable p_dtMultiUnit)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            long lngRes = m_objService.m_lngGetTableMultiUnitList(p_strId, out p_dtMultiUnit);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        #region 删除别名信息

        /// <summary>
        /// 删除别名信息
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        public long m_lngDeleteMultiUnit(clsMultiunit_drug_VO p_objVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            long lngRes = m_objService.m_lngDeleteMultiUnit(p_objVO);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据索引查询单位
        /// <summary>
        /// 根据索引查询单位
        /// </summary>
        /// <param name="strSeledMedId">药品ID </param>
        /// <param name="p_strUnit">单位名称</param>
        /// <param name="p_intPackage_Dec">单位数量</param>
        /// <param name="p_CurruseFlag_Int">是否当前单位标记</param>
        /// <returns></returns>
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec, int p_CurruseFlag_Int)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            bool lngRes = m_objService.m_blnQueryByIndex(strSeledMedId, p_strUnit, p_intPackage_Dec, p_CurruseFlag_Int);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据索引查询是否为当前使用单位
        /// <summary>
        /// 根据索引查询是否为当前使用单位
        /// </summary>
        /// <param name="strSeledMedId">药品ID </param>
        /// <param name="p_strUnit">单位名称</param>
        /// <param name="p_intPackage_Dec">单位数量</param>
        /// <returns></returns>
        public bool m_blnQueryByIndex(string strSeledMedId, string p_strUnit, int p_intPackage_Dec)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            bool lngRes = m_objService.m_blnQueryByIndex(strSeledMedId, p_strUnit, p_intPackage_Dec);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        #region 添加单位信息
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <returns></returns>
        public long m_lngAddMultiUnit(clsMultiunit_drug_VO p_objVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            long lngRes = m_objService.m_lngAddMultiUnit(p_objVO);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        
         #region 更新单位信息
        /// <summary>
        /// 更新单位信息
        /// </summary>
        /// <param name="p_objVO"></param>
        /// <param name="p_strMedicineId"></param>
        /// <param name="p_strUnitName"></param>
        /// <param name="p_intPackAge"></param>
        /// <param name="p_intCurruseFlag"></param>
        /// <returns></returns>
        public long m_lngUpdateMultiUnit(clsMultiunit_drug_VO p_objVO, string p_strMedicineId, string p_strUnitName,int p_intPackAge, int p_intCurruseFlag,int intStatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            long lngRes = m_objService.m_lngUpdateMultiUnit(p_objVO, p_strMedicineId, p_strUnitName, p_intPackAge, p_intCurruseFlag, intStatus);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion

        #region 把所有单位设为非当前单位
        /// <summary>
        /// 把所有单位设为非当前单位
        /// </summary>
        /// <param name="p_strMedicineId"></param>
        /// <returns></returns>
        public long m_lngSetAllCurruseFlag_0ByItemId(string p_strMedicineId)
        {
            com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc m_objService =
                (com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType
                    (typeof(com.digitalwave.iCare.middletier.HIS.clsMultiunit_drug_Svc));
            long lngRes = m_objService.m_lngSetAllCurruseFlag_0ByItemId(p_strMedicineId);
            m_objService.Dispose();
            return lngRes;
        }
        #endregion
    }
}
