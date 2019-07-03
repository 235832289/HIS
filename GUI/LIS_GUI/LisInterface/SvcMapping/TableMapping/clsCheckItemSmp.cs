using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 检验项目Smp
    /// </summary>
    internal class clsCheckItemSmp : clsDomainController_Base
    {
        #region 构  造

        private clsCheckItemSmp()
        {
            objSvc = (clsQueryCheckItemSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryCheckItemSvc));
        }
        private clsQueryCheckItemSvc objSvc;
        public static clsCheckItemSmp s_obj
        {
            get
            {
                return new clsCheckItemSmp();
            }
        }

        #endregion

        #region 根据申请单元ID查询所有的检验项目信息 

        /// <summary>
        /// 根据申请单元ID查询所有的检验项目信息
        /// </summary>
        /// <param name="strApplUnitID"></param>
        /// <param name="dtbCheckItem"></param>
        /// <returns></returns>
        public long m_lngGetCheckItem(string strApplUnitID, out clsCheckItem_VO[] arrCheckItems)
        {
            long lngRes = 0;
            arrCheckItems = null;

            try
            {
                lngRes = objSvc.m_lngGetCheckItemByApplUnitID(objPrincipal, strApplUnitID, out arrCheckItems);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

    }
}
