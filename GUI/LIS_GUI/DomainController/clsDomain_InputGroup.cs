using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll


namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 
    /// </summary>
    public class clsDomain_InputGroup : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region 构造函数
        public clsDomain_InputGroup()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 获取筛选后的项目列表
        public long m_lngGetFiltedItems(string[] p_strApplyUnitIDArr, string[] p_strInputGroupIDArr, out string[] p_strItemResultArr)
        {
            long lngRes = 0;
            p_strItemResultArr = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetFiltedItems(this.objPrincipal, p_strApplyUnitIDArr, p_strInputGroupIDArr, out p_strItemResultArr);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region 获取指定申请单元及其名称列表
        public long m_lngGetApplyUnitInfo(string[] p_strApplyUnitIDArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetApplyUnitInfo(this.objPrincipal, p_strApplyUnitIDArr, out p_dtbResult);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion


        #region 获取指定申请单元下可用的录入组合
        public long m_lngGetInputGroupsByUnit(string[] p_strApplyUnitIDArr, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            p_dtbResult = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetInputGroupsByUnit(this.objPrincipal, p_strApplyUnitIDArr, out p_dtbResult);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion


        #region 获取检验分类-申请单元-录入组合的的联合信息
        public long m_lngGetUnitedInputGroupInfo(out clsInputGroupUnited_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetUnitedInputGroupInfo(this.objPrincipal, out p_objResults);
            }
            catch
            {
                
            }

            return lngRes;
        }
        #endregion

        #region 获取申请单元项目明细
        public long m_lngGetApplyUnitItems(string p_strApplyUnitID,out clsCheckItemSimple_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetApplyUnitItems(this.objPrincipal, p_strApplyUnitID, out p_objResults);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region 获取录入组合及明细
        public long m_lngGetInputGroupInfo(string p_strInputGroupID,out clsInputGroupBaseInfo_VO p_objBaseInfo, out clsInputGroupDetail_VO[] p_objResults)
        {
            long lngRes = 0;
            p_objResults = null;
            p_objBaseInfo = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngGetInputGroupInfo(this.objPrincipal, p_strInputGroupID, out p_objBaseInfo, out p_objResults);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region 新增录入组合
        public long m_lngAddNewInputGroup(clsInputGroupBaseInfo_VO p_objBaseInfo, clsInputGroupDetail_VO[] p_objResults ,out string strID)
        {
            long lngRes = 0;
            strID = null;

            com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngAddNewInputGroup(this.objPrincipal, p_objBaseInfo, p_objResults,out strID);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region 更新录入组合
        public long m_lngUpdateInputGroup(clsInputGroupBaseInfo_VO p_objBaseInfo, clsInputGroupDetail_VO[] p_objResults)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngUpdateInputGroup(this.objPrincipal, p_objBaseInfo, p_objResults);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

        #region 删除录入组合
        public long m_lngDeleteInputGroup(string strGroupID)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsInputGroupSvc));
            try
            {
                lngRes = objSvc.m_lngDeleteInputGroup(this.objPrincipal, strGroupID);
            }
            catch
            {

            }

            return lngRes;
        }
        #endregion

    }

}