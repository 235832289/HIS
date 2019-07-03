using System;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 特定病种对应收费项目维护业务控制层
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-24
    /// </summary>
    class  clsDclYbdeaDefChargeItem : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDclYbdeaDefChargeItem()
        {
            //
        }

        #region 取医保特种病
        public long GetSpecialDisease(out DataTable p_dtResult)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc));
            lngRes = objSvc.GetSpecialDisease(objPrincipal, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 取收费项目
        public long GetChargeItem(out DataTable p_dtResult)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc));
            lngRes = objSvc.GetChargeItem(objPrincipal, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 根据医保大病取对应的收费项目
        public long GetChargeItemByDeaCode(string p_strDeaCode, out DataTable p_dtResult)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc));
            lngRes = objSvc.GetChargeItemByDeaCode(objPrincipal, p_strDeaCode, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region 保存
        public long SaveDeaDefChargeItem(string p_strDeaCode, ArrayList p_newArr, ArrayList p_removeArr)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeaDefChargeitemSvc));
            lngRes = objSvc.SaveDeaDefChargeItem(objPrincipal, p_strDeaCode, p_removeArr, p_newArr);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

       
    }

}
