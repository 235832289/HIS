using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 仪器通讯设置Domain层
    /// </summary>
    public class clsDomainController_MK3DeviceCommunications:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取自定义项目的发送命令
        /// <summary>
        /// 获取自定义项目的发送命令
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objCheckItemCustomOrderArr"></param>
        /// <returns></returns>
        public long m_lngQueryChcekItemCustomOrder(string p_strCheckItemID, out clsLisCheckItemCustomOrder p_objCheckItemCustomOrder)
        {
            p_objCheckItemCustomOrder = null;
            long lngRes = 0;
            clsMK3DeviceCommunications objSvc =
                (clsMK3DeviceCommunications)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMK3DeviceCommunications));
            lngRes = objSvc.m_lngQueryChcekItemCustomOrder(objPrincipal, p_strCheckItemID, out p_objCheckItemCustomOrder);
            return lngRes;
        }
        #endregion

        #region 修改自定义项目发送给仪器的命令
        /// <summary>
        /// 修改自定义项目发送给仪器的命令
        /// </summary>
        /// <param name="p_objCheckItemCustomOrderVO"></param>
        /// <returns></returns>
        public long m_lngUpdateChcekItemCustomOrder(clsLisCheckItemCustomOrder p_objCheckItemCustomOrderVO)
        {
            long lngRes = 0;
            clsMK3DeviceCommunications objSvc =
                (clsMK3DeviceCommunications)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMK3DeviceCommunications));
            lngRes = objSvc.m_lngUpdateChcekItemCustomOrder(objPrincipal, p_objCheckItemCustomOrderVO);
            return lngRes;
        }
        #endregion

        #region 添加自定义项目的发送命令
        /// <summary>
        /// 添加自定义项目的发送命令
        /// </summary>
        /// <param name="p_objCheckItemCustomOrderVO"></param>
        /// <returns></returns>
        public long m_lngInsertCheckItemCustomOrder(clsLisCheckItemCustomOrder p_objCheckItemCustomOrderVO)
        {
            long lngRes = 0;
            clsMK3DeviceCommunications objSvc =
               (clsMK3DeviceCommunications)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMK3DeviceCommunications));
            lngRes = objSvc.m_lngInsertCheckItemCustomOrder(objPrincipal, p_objCheckItemCustomOrderVO);
            return lngRes;
        }
        #endregion

        #region 删除自定义项目的命令
        /// <summary>
        /// 删除自定义项目的命令
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <returns></returns>
        public long m_lngDeleteCheckItemCustomOrder(string p_strCheckItemID)
        {
            long lngRes = 0;
            clsMK3DeviceCommunications objSvc =
                (clsMK3DeviceCommunications)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMK3DeviceCommunications));
            lngRes = objSvc.m_lngDeleteCheckItemCustomOrder(objPrincipal, p_strCheckItemID);
            return lngRes;
        }
        #endregion
    }
}
