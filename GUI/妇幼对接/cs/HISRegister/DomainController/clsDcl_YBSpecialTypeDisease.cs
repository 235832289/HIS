using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 医保特种病维护域控制层
    /// </summary>
   public class clsDcl_YBSpecialTypeDisease:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_YBSpecialTypeDisease()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

        #region 根据特种病ID获取特种病信息
        /// <summary>
        /// 根据特种病ID获取特种病信息
        /// </summary>
        /// <param name="m_strDieaseCode">疾病代码</param>
        /// <param name="m_objYBSpeTypeDiease_VO"></param>
        /// <returns></returns>
        public long m_mthGetYBSpecialTypeDiseaseByID(string m_strDieaseCode, out clsYBSpecialTypeDisease_VO m_objYBSpeTypeDiease_VO)
        {
            long lngres = 0;
            m_objYBSpeTypeDiease_VO = null;
            try
            {

                com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC));

                lngres = objSvc.m_mthGetYBSpecialTypeDiseaseByID(objPrincipal, m_strDieaseCode, out  m_objYBSpeTypeDiease_VO);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                return 0;
            }
            return lngres;

        }
        #endregion
        #region 获取特种病信息
        /// <summary>
        /// 获取特种病信息
        /// </summary>
        /// <param name="m_strDieaseCode">疾病代码</param>
        /// <param name="m_objYBSpeTypeDiease_VO"></param>
        /// <returns></returns>
        public long m_mthGetTableForYBSpecialTypeDisease(out DataTable m_objTable)
        {
            long lngres = 0;
            m_objTable = null;
            try
            {

                com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC));

                lngres = objSvc.m_mthGetTableForYBSpecialTypeDisease(objPrincipal, out m_objTable);
                objSvc.Dispose();
                objSvc = null;

            }
            catch
            {
                return 0;
            }
            return lngres;

        }
        #endregion
        #region 删除特种病信息
        /// <summary>
        /// 通过疾病代码删除特种病信息
        /// </summary>
        /// <param name="m_strDiseCode"></param>
        /// <returns></returns>
        public long m_mthDelectYBSpecialTypeDiseaseByDiseaseCode(string m_strDiseCode)
        {
            long lngres = 0;
            try
            {

                com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC));

                lngres = objSvc.m_mthDelectYBSpecialTypeDiseaseByDiseaseCode(objPrincipal, m_strDiseCode);
                objSvc.Dispose();
                objSvc = null;
               
            }
            catch (Exception e)
            {  
                
                return 0;
            }
            return lngres;

        }
        #endregion
        #region 增加或更新医保特种病信息
        /// <summary>
        /// 增加或更新医保特种病信息
        /// </summary>
        /// <param name="m_objYBSpeTypeDise_VO"></param>
        /// <returns></returns>
        public long m_mthModifyYBSpecialTypeDiseaseInfo(clsYBSpecialTypeDisease_VO m_objYBSpeTypeDise_VO)
        {
            long lngres = 0;
            try
            {

                com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC));

                lngres = objSvc.m_mthModifyYBSpecialTypeDiseaseInfo(objPrincipal, m_objYBSpeTypeDise_VO);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                return 0;
            }
            return lngres;

        }
        #endregion

        #region  根据查询条件和查找内容获取特种病信息
        /// <summary>
        /// 根据查询条件和查找内容获取特种病信息,返回医保特种表
        /// </summary>
        /// <param name="m_objTable"></param>
        ///  <param name="m_intCondition"></param>
        ///  <param name="m_strContent"></param>
        /// <returns></returns>
       public long m_mthGetTableForYBSpeTypeDiseByCondition(int m_intCondition, string m_strContent, out DataTable m_objTable)
        {
            long lngres = 0;
            m_objTable = null;
            try
            {

                com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC objSvc = (com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBSpecialTypeDisease_SVC));

                lngres = objSvc.m_mthGetTableForYBSpeTypeDiseByCondition(objPrincipal, m_intCondition, m_strContent, out m_objTable);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                return 0;
            }
            return lngres;

        }
        #endregion
    }
}
