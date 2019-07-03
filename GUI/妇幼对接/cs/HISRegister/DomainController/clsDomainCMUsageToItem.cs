using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
   public class clsDomainCMUsageToItem:com.digitalwave.GUI_Base.clsDomainController_Base
    {  
       /// <summary>
       /// 整剂用法带出项目域控制层
       /// </summary>
       public clsDomainCMUsageToItem()
       {   
       }
       #region 获取整剂用法信息
       /// <summary>
       /// 获取整剂用法信息
       /// </summary>
       /// <param name="m_objTable"></param>
       /// <returns></returns>
       public long m_lngGetCMUsageInformation(out DataTable m_objTable)
       {
           long lngRes = 0;
           com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc));
           lngRes = objSvc.m_lngGetCMUsageInformation(objPrincipal, out m_objTable);
           objSvc.Dispose();
           return lngRes;
       }
       #endregion
       #region 根据用法ID获取带出项目的信息
       /// <summary>
       /// 根据用法ID获取带出项目的信息
       /// </summary>
       /// <param name="m_strUsageID"></param>
       /// <param name="m_objTable"></param>
       /// <returns></returns>
       public long m_lngGetRelationItemInformationByUsageID(string m_strUsageID, out DataTable m_objTable)
       {
           long lngRes = 0;
           com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc));
           lngRes = objSvc.m_lngGetRelationItemInformationByUsageID(objPrincipal,m_strUsageID, out m_objTable);
           objSvc.Dispose();
           return lngRes;
       }
       #endregion
       #region 根据行号ID,用法ID和项目ID删除关联表信息
        /// <summary>
       /// 根据行号ID,用法ID和项目ID删除关联表信息
        /// </summary>
        /// <param name="m_strRowNo"></param>
        /// <param name="m_strUsageID"></param>
        /// <param name="m_strItemID"></param>
        /// <returns></returns>
       public long m_lngDelRelationItemInformationByID(string m_strRowNo, string m_strUsageID, string m_strItemID)
       {
           long lngRes = 0;
           com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc));
           lngRes = objSvc.m_lngDelRelationItemInformationByID(objPrincipal,m_strRowNo,m_strUsageID,m_strItemID);
           objSvc.Dispose();
           return lngRes;
       }
       #endregion
       #region 新增一条关联表信息
       /// <summary>
       /// 新增一条关联表信息
       /// </summary>
       /// <param name="p_strRecordID"></param>
       /// <param name="p_objRecord"></param>
       /// <returns></returns>
       public long m_lngDoAddNewChargeItemUsageGroup(out string p_strRecordID, clsChargeItemUsageGroup_VO p_objRecord)
       {
           long lngRes = 0;
           com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc));
           lngRes = objSvc.m_lngDoAddNewChargeItemUsageGroup(objPrincipal, out p_strRecordID,p_objRecord);
           objSvc.Dispose();
           return lngRes;
       }
       #endregion
       #region 修改关联表信息
       /// <summary>
       /// 修改关联表信息
       /// </summary>
       /// <param name="objResult"></param>
       /// <returns></returns>
       public long m_lngDoModifyChargeItemUsageGroup(clsChargeItemUsageGroup_VO objResult)
       {
           long lngRes = 0;
           com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc));
           lngRes = objSvc.m_lngDoModifyChargeItemUsageGroup(objPrincipal,objResult);
           objSvc.Dispose();
           return lngRes;
       }
       #endregion
       #region 删除关联表信息
       /// <summary>
       /// 删除关联表信息
       /// </summary>
       /// <param name="objResult"></param>
       /// <returns></returns>
       public long m_lngDelUsageGroupByID(clsChargeItemUsageGroup_VO objResult)
       {
           long lngRes = 0;
           com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCmCookingMethodItemGroupSvc));
           lngRes = objSvc.m_lngDelUsageGroupByID(objPrincipal, objResult);
           objSvc.Dispose();
           return lngRes;

       }
       #endregion
    }
}
