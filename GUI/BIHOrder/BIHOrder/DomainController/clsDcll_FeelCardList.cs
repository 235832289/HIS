using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.BIHOrder
{
    public class clsDcl_FeelCardList : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 整体保存医嘱组套成员
        /// <summary>
        /// 整体保存医嘱组套成员
        /// </summary>
        /// <param name="p_dtDataName"></param>
        /// <param name="p_objResult"></param>
        public long m_lngGetFeelOrderByAreaID(string m_strAreaId, out DataTable m_dtExecOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetFeelOrderByAreaID(objPrincipal, m_strAreaId, out m_dtExecOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
    }
}