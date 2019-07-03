using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsDcl_PATSPECREMARK : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        #region 
      
        public long m_lngAddNewBed()
        {
        //    com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
        //        com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
        //    return objSvc.m_lngAddNewBed(objPrincipal, out p_strRecordID, p_objRecord);
            return 0;
        }
        #endregion

        internal long m_lngGetSPECREMARKMessage(out DataTable m_dtSpcMessage)
        {
            com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc));
            return objSvc.m_lngGetSPECREMARKMessage(objPrincipal,out m_dtSpcMessage);
        
        }

        internal long m_lngGetPatientSPECREMARK(string m_strRegisterID, out clsSpecreMark_VO m_objSpecreMark_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc));
            return objSvc.m_lngGetPatientSPECREMARK(objPrincipal, m_strRegisterID, out m_objSpecreMark_VO);
        
        }

        internal long m_lngSaveNewPatientSPECREMARK(clsSpecreMark_VO m_objSpecreMark_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc));
            return objSvc.m_lngSaveNewPatientSPECREMARK(objPrincipal, m_objSpecreMark_VO);
        }

        internal long m_lngSaveUpdatePatientSPECREMARK(clsSpecreMark_VO m_objSpecreMark_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc)
              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc));
            return objSvc.m_lngSaveUpdatePatientSPECREMARK(objPrincipal, m_objSpecreMark_VO);
        
        }

        internal long m_lngSaveDelPatientSPECREMARK(clsSpecreMark_VO m_objSpecreMark_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc));
            return objSvc.m_lngSaveDelPatientSPECREMARK(objPrincipal, m_objSpecreMark_VO);
        }
    }
}
