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
    /// �ض����ֶ�Ӧ�շ���Ŀά��ҵ����Ʋ�
    /// ���ߣ�He Guiqiu
    /// ����ʱ��:2006-06-24
    /// </summary>
    class  clsDclYbdeaDefChargeItem : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDclYbdeaDefChargeItem()
        {
            //
        }

        #region ȡҽ�����ֲ�
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

        #region ȡ�շ���Ŀ
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

        #region ����ҽ����ȡ��Ӧ���շ���Ŀ
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

        #region ����
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
