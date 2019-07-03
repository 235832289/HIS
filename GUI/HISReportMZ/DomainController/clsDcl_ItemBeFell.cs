using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
  public  class clsDcl_ItemBeFell : com.digitalwave.GUI_Base.clsDomainController_Base
    {
     

        #region 得到项目发生明细
        public long m_lngGetItemEntry(int DatType,int p_intRecipeType,string starDat,string endDat,string ItemId, out DataTable dat)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell kk =
                                                (com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell));
            lngRes = kk.GetItemByDate(DatType,p_intRecipeType, starDat, endDat, ItemId, out dat);
            return lngRes;

        }
        #endregion

        #region 查询项目列表
        public long m_GetItem(string ItemName, out DataTable dt)
        {
            long lngRes = 0;
            dt = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell kk =
                                                (com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell));
           lngRes = kk.GetItem(ItemName, out dt);
            return lngRes;

        }
        #endregion

        #region 查询项目汇总列表

      public long m_lngGetItemCollect(int DatType, int p_intRecipeType, string starDat, string endDat, string ItemId, out DataTable dat)
        {
            long lngRes = 0;
            // com.digitalwave.iCare.middletier.HIS.clsAreaMed2Query kk = new com.digitalwave.iCare.middletier.HIS.clsAreaMed2Query();
            com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell kk =
                                                (com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsItemBefell));
            lngRes = kk.GetItemCollect(DatType,p_intRecipeType, starDat, endDat, ItemId, out dat);
            return lngRes;

        }
       
        #endregion
    }
}
