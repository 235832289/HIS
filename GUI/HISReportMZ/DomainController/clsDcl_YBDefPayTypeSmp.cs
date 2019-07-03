using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    internal class clsDcl_YBDefPayTypeSmp:com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构  造


        public clsDcl_YBDefPayTypeSmp()
        {
            objSvc = (clsYBDefPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsYBDefPayTypeSvc));
        }

        private clsYBDefPayTypeSvc objSvc;
        public static clsDcl_YBDefPayTypeSmp s_object
        {
            get
            {
                return new clsDcl_YBDefPayTypeSmp();
            }
        } 

        #endregion

         /// <summary>
        /// 返回所有的关系
        /// </summary>
        /// <param name="arrYBDefPayType"></param>
        /// <returns></returns>
        public long m_lngFindAll(out clsYBDefPayTypeVO[] arrYBDefPayType)
        {
            long lngRes = 0;
            arrYBDefPayType = null;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc kk =
                    (com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc));
                lngRes = kk.m_lngFindAll(out arrYBDefPayType);

            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        public long m_lngFind(string payTypeId,out clsYBDefPayTypeVO ybDefPayType)
        {
            long lngRes = 0;
            ybDefPayType = null;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc kk =
    (com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc));
                lngRes = kk.m_lngFind(payTypeId, out ybDefPayType);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 插入新记录

        /// </summary>
        /// <param name="ybDefPayTypeVO"></param>
        /// <returns></returns>
        public long m_lngInsert(clsYBDefPayTypeVO ybDefPayTypeVO) 
        {
            long lngRes = 0;
           
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc kk =
(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc));
                lngRes = kk.m_lngInsert(ybDefPayTypeVO);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        public long m_lngUpdate(clsYBDefPayTypeVO objGroup)
        {
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc kk =
(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc));
                lngRes = kk.m_lngUpdate(objGroup);
            }
            catch 
            {
                lngRes = 0;
            }

            return lngRes;
        }

        public long m_lngDelete(clsYBDefPayTypeVO objGroup)
        {
            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc kk =
(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYBDefPayTypeSvc));
                lngRes = kk.m_lngDelete(objGroup);
            }
            catch 
            {
                lngRes = 0;
            }

            return lngRes;
        }

    }

    internal class clsDcl_PatientPayTypeSmp :com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构  造


        public clsDcl_PatientPayTypeSmp()
        {
            objSvc = (clsPatientPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientPayTypeSvc));
        }

        private clsPatientPayTypeSvc objSvc;
        public static clsDcl_PatientPayTypeSmp s_object
        {
            get
            {
                return new clsDcl_PatientPayTypeSmp();
            }
        } 

        #endregion

        /// <summary>
        /// 获取所有医保对应的患者类型

        /// </summary>
        /// <param name="arrPatientType"></param>
        /// <returns></returns>
        public long m_lngGetYBPatientPayType(out clsPatientType_VO[] arrPatientType)
        {
            long lngRes = 0;
            arrPatientType = null;
           
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsPatientPayTypeSvc kk =
                                    (com.digitalwave.iCare.middletier.HIS.clsPatientPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatientPayTypeSvc));
                lngRes = kk.m_lngGetYBPatientPayType(out arrPatientType);
                //lngRes = objSvc.m_lngGetYBPatientPayType(out arrPatientType);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }

        /// <summary>
        /// 获取患者类型

        /// </summary>
        /// <param name="patientPayTypeId"></param>
        /// <param name="patientType"></param>
        /// <returns></returns>
        public long m_lngGetPatientPayType(string patientPayTypeId, out clsPatientType_VO patientType)
        {
            long lngRes = 0;
            patientType = null;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsPatientPayTypeSvc kk =
                    (com.digitalwave.iCare.middletier.HIS.clsPatientPayTypeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatientPayTypeSvc));
                lngRes = kk.m_lngGetPatientPayType(patientPayTypeId,out patientType);
            }
            catch (Exception objEx)
            {
                lngRes = 0;
                new clsLogText().LogError(objEx);
            }
            return lngRes;
        }
    }
}
