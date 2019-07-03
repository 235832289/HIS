using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 药房请领明细
    /// </summary>
    public class clsDcl_AskForMedDetail : com.digitalwave.GUI_Base.clsDomainController_Base
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsDcl_AskForMedDetail()
        {
        }
        /// <summary>
        /// 获取基本药品信息
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfo(string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfo(objPrincipal,m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }

        /// <summary>
        /// 获取基本药品信息(带请领信息)
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfoForAsk(string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfoForAsk(objPrincipal, m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }

        /// <summary>
        /// 获取基本药品信息(带请领信息)(显示库存信息)
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfoForAskWithStorageInfo(bool p_blnIsHospital,string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfoForAskWithStorageInfo(objPrincipal, p_blnIsHospital,m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }
        
        /// <summary>
        /// 获取药房出库药品基本信息
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetOutStorageMedicineInfo(bool p_blnIsHospital,string m_strMedStoreid, out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetOutStorageMedicineInfo(objPrincipal,p_blnIsHospital, m_strMedStoreid, out m_dtMedicine);
            return lngRes;
        }
        /// <summary>
        /// 根据序列号删除药品id
        /// </summary>
        /// <param name="m_strSeqid"></param>
        /// <returns></returns>
        public long m_lngDelMedDetail(long m_lngSeqid)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngDelAskMedDetail(objPrincipal, m_lngSeqid);
            return lngRes;
        }
        /// <summary>
        /// 插入药房请领主表和明细表数据
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngAddNewAskMedInfo(ref clsDS_Ask_VO m_objMainVo, ref clsDS_Ask_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngAddNewAskMedInfo(objPrincipal,ref m_objMainVo,ref m_objDetailArr);
            return lngRes;
        }
        /// <summary>
        /// 更新药房请领主表和明细表数据
        /// </summary>
        /// <param name="m_objMainVo"></param>
        /// <param name="m_objDetailArr"></param>
        /// <returns></returns>
        public long m_lngUpdateAskMedInfo(clsDS_Ask_VO m_objMainVo, ref clsDS_Ask_Detail_VO[] m_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngUpdateAskMedInfo(objPrincipal, m_objMainVo, ref m_objDetailArr);
            return lngRes;
        }

        /// <summary>
        /// 获取基本药品信息
        /// </summary>
        /// <param name="m_dtMedicine"></param>
        /// <returns></returns>
        public long m_lngGetMedicineInfoWithStorageID(string m_strMedStoreid, string p_strStorageID,out DataTable m_dtMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetMedicineInfoWithStorageID(objPrincipal, m_strMedStoreid,p_strStorageID, out m_dtMedicine);
            return lngRes;
        }
       
        /// <summary>
        /// 获取请领单状态是否“提交”
        /// </summary>
        /// <param name="p_strAskID"></param>
        /// <returns></returns>
        public long m_lngCheckStatus(string p_strAskID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_strAskID);
            return lngRes;
        }

        /// <summary>
        /// 获取数据库服务器当前时间
        /// </summary>
        /// <param name="p_dtmDateTime"></param>
        /// <returns></returns>
        public long m_lngGetSystemDateTime(out DateTime p_dtmDateTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objDomain =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objDomain.m_lngGetSystemDateTime(out p_dtmDateTime);
            return lngRes;
        }

        /// <summary>
        /// 获取中间件服务器当前时间
        /// </summary>
        /// <param name="p_dtmDateTime"></param>
        /// <returns></returns>
        public long m_lngGetCurrentDateTime(out DateTime p_dtmDateTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objDomain =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objDomain.m_lngGetCurrentDateTime(out p_dtmDateTime);
            return lngRes;
        }

        /// <summary>
        /// 作废请领主表单据的状态
        /// </summary>
        /// <param name="lngArr"></param>
        /// <returns></returns>
        public long m_lngDeleteBill(string p_strBillID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngDeleAskInfo(objPrincipal, p_strBillID);
            return lngRes;
        }

        /// <summary>
        /// 查询请领单状态
        /// </summary>
        /// <param name="p_strSeq">请领单序列号</param>
        /// <param name="p_intQueryStyle">查询方式:0-以主表序列号查询,1-以子表序列号查询</param>
        /// <param name="p_strStatus">请领单状态</param>
        /// <returns></returns>
        public long m_lngQueryAskMedStatus(string p_strSeq, int p_intQueryStyle, out string p_strStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngQueryAskMedStatus(p_strSeq, p_intQueryStyle, out p_strStatus);
            return lngRes;
        }

    }
}
