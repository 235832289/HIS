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
    /// �ض����ֶ�ӦICD10���ά��ҵ����Ʋ�
    /// ���ߣ�He Guiqiu
    /// ����ʱ��:2006-06-22
    /// </summary>
    class clsDclYbdeadeficd : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDclYbdeadeficd()
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

        #region ȡICD10
        public long GetICD(out DataTable p_dtResult)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc));
            lngRes = objSvc.GetICD(objPrincipal, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region ����ҽ����ȡ��Ӧ��ICD10
        public long GetICDByDeaCode(string p_strDeaCode, out DataTable p_dtResult)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc));
            lngRes = objSvc.GetICDByDeaCode(objPrincipal, p_strDeaCode, out p_dtResult);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

        #region ����
        public long SaveDeaDef(string p_strDeaCode, ArrayList p_newArr, ArrayList p_removeArr)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYbdeadeficdSvc));
            lngRes = objSvc.SaveDeaDef(objPrincipal, p_strDeaCode, p_removeArr, p_newArr);

            objSvc.Dispose();

            return lngRes;
        }
        #endregion

       
    }

}
