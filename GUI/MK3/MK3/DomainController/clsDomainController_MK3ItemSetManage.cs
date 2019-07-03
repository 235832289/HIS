using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;


namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 酶标仪项目设置Domain层
    /// </summary>
    public class clsDomainController_MK3ItemSetManage:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取所有的检验项目
        /// <summary>
        /// 获取所有的检验项目
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngGetAllCheckItem(string p_strDeviceModelID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngGetAllCheckItem(objPrincipal,p_strDeviceModelID, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 获取所有自定义项目的信息
        /// <summary>
        /// 获取所有自定义项目的信息
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngGetAllCheckItemCustomInfo(out clsLisCheckItemCustom[] p_objCheckItemCustomVO,out DataTable p_dtResult)
        {
            p_objCheckItemCustomVO = null;
            p_dtResult = null;
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngGetAllCheckItemCustomInfo(objPrincipal, out p_objCheckItemCustomVO, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 修改自定义项目
        /// <summary>
        /// 修改自定义项目
        /// </summary>
        /// <param name="p_objCheckItemCustomVO"></param>
        /// <returns></returns>
        public long m_lngUpdateCheckItemCustom(clsLisCheckItemCustom p_objCheckItemCustomVO)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngUpdateCheckItemCustom(objPrincipal, p_objCheckItemCustomVO);
            return lngRes;
        }
        #endregion

        #region 删除自定义项目
        /// <summary>
        /// 删除自定义项目
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <returns></returns>
        public long m_lngDelteCheckItemCustom(string p_strCheckItemID)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngDelteCheckItemCustom(objPrincipal, p_strCheckItemID);
            return lngRes;
        }
        #endregion

        #region 添加自定义项目
        /// <summary>
        /// 添加自定义项目
        /// </summary>
        /// <param name="p_objCheckItemCustomVO"></param>
        /// <returns></returns>
        public long m_lngInsertCheckItemCustom(clsLisCheckItemCustom p_objCheckItemCustomVO)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngInsertCheckItemCustom(objPrincipal, p_objCheckItemCustomVO);
            return lngRes;
        }
        #endregion

        #region 获取自定义项目的结果判断
        /// <summary>
        /// 获取自定义项目的结果判断
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objCheckItemCustomRes"></param>
        /// <returns></returns>
        public long m_lngQueryCheckItemCustomRes(string p_strCheckItemID, out clsLisCheckItemCustomRes[] p_objCheckItemCustomRes)
        {
            long lngRes = 0;
            p_objCheckItemCustomRes = null;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngQueryCheckItemCustomRes(objPrincipal, p_strCheckItemID, out p_objCheckItemCustomRes);
            return lngRes;
        }
        #endregion

        #region 添加自定义结果判断
        /// <summary>
        /// 添加自定义结果判断
        /// </summary>
        /// <param name="p_objCheckItemCustomResVO"></param>
        /// <returns></returns>
        public long m_lngInsertCheckItemCustomRes(clsLisCheckItemCustomRes p_objCheckItemCustomResVO)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngInsertCheckItemCustomRes(objPrincipal, p_objCheckItemCustomResVO);
            return lngRes;
        }
        #endregion

        #region 修改自定义结果判断
        /// <summary>
        /// 修改自定义结果判断
        /// </summary>
        /// <param name="p_objCheckItemCustomResVO"></param>
        /// <returns></returns>
        public long m_lngUpdateCheckItemCustomRes(clsLisCheckItemCustomRes p_objCheckItemCustomResVO)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngUpdateCheckItemCustomRes(objPrincipal, p_objCheckItemCustomResVO);
            return lngRes;
        }
        #endregion

        #region 删除自定义结果判断
        /// <summary>
        /// 删除自定义结果判断
        /// </summary>
        /// <param name="p_objCheckItemCustomResVO"></param>
        /// <returns></returns>
        public long m_lngDeleteCheckItemCustomRes(clsLisCheckItemCustomRes p_objCheckItemCustomResVO)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngDeleteCheckItemCustomRes(objPrincipal, p_objCheckItemCustomResVO);
            return lngRes;
        }
        #endregion

        #region 增加检验仪器结果, 多样本
        /// <summary>
        /// 增加检验仪器结果, 多样本
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_objOutResultArr"></param>
        /// <returns></returns>
        public long lngAddLabResult(clsLIS_Device_Test_ResultVO[] p_objResultArr, bool p_blnMuiltySample, out clsLIS_Device_Test_ResultVO[] p_objOutResultArr)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.lngAddLabResult(p_objResultArr,true,out p_objOutResultArr);
            return lngRes;
        }
        #endregion

        #region 增加检验仪器结果
        /// <summary>
        /// 增加检验仪器结果
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_objOutResultArr"></param>
        /// <returns></returns>
        public long lngAddLabResult(clsLIS_Device_Test_ResultVO[] p_objResultArr, out clsLIS_Device_Test_ResultVO[] p_objOutResultArr)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.lngAddLabResult(p_objResultArr, out p_objOutResultArr);
            return lngRes;
        }
        #endregion

        #region 获取仪器项目名称
        /// <summary>
        /// 获取仪器项目名称
        /// </summary>
        /// <param name="p_strDevicModelID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQueryDevceCheckItem(string p_strDevicModelID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngQueryDevceCheckItem(objPrincipal, p_strDevicModelID, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 获取布局名称和布局信息
        /// <summary>
        /// 获取布局名称和布局信息
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <param name="p_dtLayoutInfo"></param>
        /// <returns></returns>
        public long m_lngGetAllItemLayout(out DataTable p_dtResult, out DataTable p_dtLayoutInfo)
        {
            p_dtLayoutInfo = null;
            p_dtLayoutInfo = null;
            long lngRes = 0;
            clsItemSetSvc objSvc =
               (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngGetAllItemLayout(objPrincipal, out p_dtResult, out p_dtLayoutInfo);
            return lngRes;
        }
        #endregion

        #region 插入新的布局
        /// <summary>
        /// 插入新的布局
        /// </summary>
        /// <param name="p_objLisItemLayoutVO"></param>
        /// <returns></returns>
        public long m_lngAddItemLayout(clslisItemLayout[] p_objLisItemLayoutVO)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngAddItemLayout(objPrincipal, p_objLisItemLayoutVO);
            return lngRes;
        }
        #endregion

        #region 删除布局
        /// <summary>
        /// 删除布局
        /// </summary>
        /// <param name="p_strLayoutName"></param>
        /// <returns></returns>
        public long m_lngDeleteItemLayout(string p_strLayoutName)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngDeleteItemLayout(objPrincipal, p_strLayoutName);
            return lngRes;
        }
        #endregion

        #region 根据板子结果名称查询相关板子结果名称
        /// <summary>
        /// 根据板子结果名称查询相关板子结果名称
        /// </summary>
        /// <param name="p_strPlateName"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQueryPlateName(string p_strPlateName,string p_strStartDate,string p_strEndDate, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngQueryPlateName(objPrincipal, p_strPlateName,p_strStartDate,p_strEndDate, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 根据板子名称ID查询板子结果
        /// <summary>
        /// 根据板子名称ID查询板子结果
        /// </summary>
        /// <param name="p_strPlateNameID"></param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQueryPlateResult(string p_strPlateNameID, out DataTable p_dtResult)
        {
            p_dtResult = null;
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngQueryPlateResult(objPrincipal, p_strPlateNameID, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 插入板子布局结果
        /// <summary>
        /// 插入板子布局结果
        /// </summary>
        /// <param name="p_strPlateName"></param>
        /// <param name="p_objPlateResultArr"></param>
        /// <returns></returns>
        public long m_lngInsertPlateResult(string p_strPlateName, string p_strPlateChName, clslisPlateResult[] p_objPlateResultArr, out string p_strPlateResultID)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngInsertPlateResult(objPrincipal, p_strPlateName,p_strPlateChName, p_objPlateResultArr,out p_strPlateResultID);
            return lngRes;
        }
        #endregion

        #region 删除板子结果
        /// <summary>
        /// 删除板子结果
        /// </summary>
        /// <param name="p_strPlateNameID"></param>
        /// <returns></returns>
        public long m_lngDeletePlateResult(string p_strPlateNameID)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngDeletePlateResult(objPrincipal, p_strPlateNameID);
            return lngRes;
        }
        #endregion

        #region 获取所有板子结果
        /// <summary>
        /// 获取所有板子结果
        /// </summary>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngGetAllPlateResult(out DataTable p_dtResult)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngGetAllPlateResult(objPrincipal, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 插入检验结果
        /// <summary>
        /// 插入检验结果
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngInsertDeviceResult(clsLIS_Device_Test_ResultVO[] p_objResultArr)
        {
            long lngRes = 0;
            clsItemSetSvc objSvc =
                (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngInsertDeviceResult(objPrincipal,p_objResultArr);
            return lngRes;
        }
        #endregion


        #region 获取自定义项目的结果判断公式   
        /// <summary>
        /// 获取自定义项目的结果判断
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objCheckItemCustomRes"></param>
        /// <returns></returns>
        public long m_lngQueryCheckItemCustomRes(string p_strCheckItemID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_dtResult = null;
            clsItemSetSvc objSvc = (clsItemSetSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsItemSetSvc));
            lngRes = objSvc.m_lngQueryCheckItemCustomRes(objPrincipal, p_strCheckItemID, out p_dtResult);
            return lngRes;
        }
        #endregion
    }
}
