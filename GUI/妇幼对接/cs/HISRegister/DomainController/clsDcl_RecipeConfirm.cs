using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsDcl_RecipeConfirm : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 根据卡号查询病人信息
        public long m_lngGetPatientInfo(string strCardno, out DataTable dteResult)
        {
            dteResult = new DataTable(); ;
            com.digitalwave.iCare.middletier.HIS.clsHisBase objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
            long lngRes = objSvc.m_mthGetPatientInfoByCardID(strCardno, out dteResult, false);
            return lngRes;
        }
        #endregion

        #region 加载处方
        /// <summary>
        /// 加载处方
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="objRI_VO"></param>
        /// <returns></returns>
        public long m_mthLoadRecipeNo(string strID, out clsRecipeInfo_VO[] objRI_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
            long l = objSvc.m_lngGetPatientInfoByCardID(strID, out objRI_VO);            
            return l;
        }
        ///
        #endregion

        #region 查询检验、检查、手术等信息
        /// <summary>
        /// 查询检验、检查、手术等信息
        /// </summary>
        /// <param name="p_RecipeNo"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_mthFindRecipeDetailOrder(string p_RecipeNo, out DataTable dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc objSvc =
               (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
            long l = objSvc.m_mthFindRecipeDetailOrder(p_RecipeNo, out dtResult);   
            return l;
        }
        #endregion

        #region 查询诊疗项目是否已经做好
        /// <summary>
        /// 查询诊疗项目是否已经做好
        /// </summary>
        /// <param name="p_strRecNo">处方号</param>
        /// <param name="p_strOrderDicId">诊疗项目id</param>
        /// <param name="p_intType">1-检验表 2-检查表</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngQueryDiagnosisItemStatus(string p_strRecNo, string p_strOrderDicId, int p_intType, out DataTable p_dtbResult)
        {
            long lngRes = -1;
            p_dtbResult = null;
            try
            {
                clsRecipeConfirmQuerySvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
                lngRes = objSvc.m_lngQueryDiagnosisItemStatus(p_strRecNo, p_strOrderDicId, p_intType, out p_dtbResult);

                objSvc.Dispose();
                objSvc = null;
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError("m_lngQueryDiagnosisItemStatus连接中间件错误：" + objEx.Message);
                objLogger = null;
            }
            return lngRes;
        }
        #endregion

        #region
        public long m_mthFindRecipeDetail6(string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
            long lngRes = objSvc.m_mthFindRecipeDetail6(objPrincipal, ID, out dt, flag);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 更改申请单的状态
        /// <summary>
        /// 更改申请单的状态
        /// </summary>
        /// <param name="p_reicpeNO"></param>
        /// <param name="p_listApp"></param>
        /// <returns></returns>
        public long m_lngModiffyAppStatus(clsOutpatientRecipe_VO[] objRecipeVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmOpSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmOpSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmOpSvc));
            long lngRes = objSvc.m_lngModiffyAppStatus(objRecipeVO);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据收费ID判断是否属于手术费用
        /// <summary>
        /// 根据收费ID判断是否属于手术费用
        /// </summary>
        /// <param name="chrgitemcode"></param>
        /// <returns></returns>
        public bool m_blnChkopsitem(string chrgitemcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                                     (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            bool ret = objSvc.m_blnChkopsitem(chrgitemcode);
            objSvc.Dispose();

            return ret;
        }
        #endregion

        #region 查询处方明细
        public long m_mthRecipeDetail(string p_strRecipeNO, out DataTable dtResult)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc objSvc =
              (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
            long l = objSvc.m_mthRecipeDetail(p_strRecipeNO, out dtResult);
            return l;
        }
        #endregion

        #region 查询项目明细
        /// <summary>
        /// 查询项目明细
        /// </summary>
        /// <param name="p_strRecipeNO"></param>
        /// <param name="p_strPatientID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetItemDetails(string p_strRecipeNO, string p_strPatientID, string p_strItemID,string p_strType, out DataTable dtResult)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc objSvc =
              (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
            long l = objSvc.m_lngGetItemDetails(p_strRecipeNO, p_strPatientID, p_strItemID, p_strType, out dtResult);
            return l;
        }
        #endregion

        #region 费用取消确认
        /// <summary>
        /// 费用取消确认
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public long m_lngItemsCancel(string p_strItemid,string p_strEmpid)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmOpSvc objSvc =
              (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmOpSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmOpSvc));
            long l = objSvc.m_lngItemsCancel(p_strItemid, p_strEmpid);
            return l;
        }
        #endregion

        #region 权限判断
        /// <summary>
        /// 权限判断
        /// </summary>
        /// <param name="p_strEmpid"></param>
        /// <returns></returns>
        public bool m_blnCompetence(string p_strEmpid)
        {
            bool lngRes = false;
            com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc objSvc =
              (com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRecipeConfirmQuerySvc));
            lngRes = objSvc.m_blnCompetence(p_strEmpid);
            return lngRes;
        }
        #endregion
    }
}
