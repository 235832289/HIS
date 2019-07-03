using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsDomainSpecialRemarkDic:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取特殊注释ID
        /// <summary>
        ///  获取特殊注释ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strSpecialRemarkID"></param>
        /// <returns></returns>
        public long m_lngGetSpecialRemarkID(ref string m_strSpecialRemarkID)
        {
        
           com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService)
           com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService));
           return objSvc.m_lngGetSpecialRemarkID(objPrincipal, ref m_strSpecialRemarkID);
            
        }
        #endregion
        #region 获取特殊注释字典
        /// <summary>
        /// 获取特殊注释字典
        /// </summary>
        /// <param name="m_objTable"></param>
        public long m_lngGetSpecialRemarkDic(out DataTable m_objTable)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService)
              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService));
            return objSvc.m_lngGetSpecialRemarkDic(objPrincipal, out m_objTable);

        }
        #endregion
        #region 根据查询条件和查询内容获取特殊注释字典
        /// <summary>
        /// 根据查询条件和查询内容获取特殊注释字典
        /// </summary>
        /// <param name="m_strConditionIndex"></param>
        /// <param name="m_strSearchContent"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetSpecialRemarkDicByCondition(string m_strConditionIndex, string m_strSearchContent, out DataTable m_objTable)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService)
            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService));
            return objSvc.m_lngGetSpecialRemarkDicByCondition(objPrincipal,m_strConditionIndex,m_strSearchContent,out m_objTable);
        }
        #endregion
        #region 更新特殊注释字典
        /// <summary>
        /// 更新特殊注释字典
        /// </summary>
        /// <param name="m_objVo"></param>
        /// <param name="m_strResult"></param>
        /// <returns></returns>
        public long m_lngModifySpecialRemakDic(clsSpecialRemarkDicVo m_objVo, ref string m_strResult)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService)
            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService));
            return objSvc.m_lngModifySpecialRemakDic(objPrincipal,m_objVo,ref m_strResult);
        }
        #endregion
        #region 删除特殊注释字典
        /// <summary>
        /// 根据注释编码删除特殊注释字典
        /// </summary>
        /// <param name="m_strSpecialRemakID"></param>
        /// <returns></returns>
        public long m_lngDeleteSpecialRemarkDicByID(string m_strSpecialRemakID)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService)
            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsSpecialRemarkDicService));
            return objSvc.m_lngDeleteSpecialRemarkDicByID(objPrincipal, m_strSpecialRemakID);
        }
        #endregion 
    }
}
