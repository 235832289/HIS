using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
//新增下面的

using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using System.Collections;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    public class clsDcl_GetSvcObject : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        /// <summary>
        /// 返回clsBIHOrderService 中间件

        /// </summary>
        /// <returns></returns>
        public clsBIHOrderService m_GetOrderSvcObject()
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            return objSvc;
        }
        /// <summary>
        /// 返回clsBIHOrderGroupService 中间件

        /// </summary>
        /// <returns></returns>
        internal clsBIHOrderGroupService m_GetOrderGroupSvcObject()
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            return objSvc;
        }
         /// <summary>
        /// 返回clsBIHChargeSvc 中间件

        /// </summary>
        /// <returns></returns>
        internal com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc m_GetBIHChargeSvc()
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =
             (com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            return objSvc;
        }
         /// <summary>
        /// clsBIHORDERCHARGEDService
        /// </summary>
        /// <returns></returns>
        internal com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService m_GetBIHORDERCHARGEDSvc()
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService));
            return objSvc;
        }

        /// <summary>
        /// clsBIHOrderExecuteService
        /// </summary>
        /// <returns></returns>
        internal com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService m_GetBIHOrderExecuteSvc()
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            return objSvc;
        }

        /// <summary>
        /// clsBIHOrderExecuteService
        /// </summary>
        /// <returns></returns>
        internal com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHChargeItemService m_GetBIHChargeItemSvc()
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHChargeItemService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHChargeItemService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHChargeItemService));
            return objSvc;
        }

       
        
    }
}
