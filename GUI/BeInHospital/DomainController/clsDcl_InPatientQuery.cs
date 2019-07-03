using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsDcl_InPatientQuery : com.digitalwave.GUI_Base.clsDomainController_Base
    {

        internal long m_lngFindArea(string strFindCode, out clsBIHArea[] objItemArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc));
            return objSvc.m_lngFindArea(strFindCode, out objItemArr);
        }

        internal long m_lngGetSPECREMARKMessage(out DataTable m_dtSpcMessage)
        {
            com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsSpecreMarkSvc));
            return objSvc.m_lngGetSPECREMARKMessage(objPrincipal, out m_dtSpcMessage);

        }

        #region 初始化费用类别下拉框
        /// <summary>
        /// 初始化费用类别下拉框
        /// </summary>
        /// <param name="p_cboName">下拉框ID</param>
        public void m_FillCboPatientType(ComboBox p_cboName)
        {
            p_cboName.Items.Clear();
            long lngRes;
            clsPatientPayTypeVO[] objPatientTypeVO;
            clsPatientSvc objSvc = (clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
            try
            {
                lngRes = objSvc.m_GetBIHPatientType(objPrincipal, out objPatientTypeVO);
            }
            catch
            {
                return;
            }
            if (lngRes <= 0)
                return;
            p_cboName.Items.Add(new clsComboBoxTextValue("",-1));
            for (int i = 0; i < objPatientTypeVO.Length; i++)
            {
                p_cboName.Items.Add(new clsComboBoxTextValue(objPatientTypeVO[i].m_strPAYTYPENAME_VCHR.ToString(),i));
            }
            p_cboName.Tag=objPatientTypeVO;
            objSvc.Dispose();
        }
        #endregion		
    
        internal long m_lngGetPatientByCondition(string InPatientID_Chr, string Name_VChr, string AreaID_Chr, string DOCTORID_CHR, string PSTATUS_INT, string STATE_INT, string PayTypeID_Chr, string REMARKID_CHR, DateTime m_dtStart, DateTime m_dtFinish, out clsBIHPatientInfo[] m_ArrobjPatient)
        {
            com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc));
            return objSvc.m_lngGetPatientByCondition(InPatientID_Chr, Name_VChr, AreaID_Chr, DOCTORID_CHR, PSTATUS_INT, STATE_INT, PayTypeID_Chr, REMARKID_CHR, m_dtStart, m_dtFinish,out m_ArrobjPatient);
        }
    }
}
