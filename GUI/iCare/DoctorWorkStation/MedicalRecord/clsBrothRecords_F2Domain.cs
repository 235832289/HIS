using System;
using iCareData;
using com.digitalwave.BaseCaseHistorySevice;
using com.digitalwave.Utility.Controls;
using com.digitalwave.InPatientCaseHistoryServ;

namespace iCare
{
    /// <summary>
    /// 产时记录 的摘要说明。
    /// </summary>
    public class clsBrothRecords_F2Domain 
    {
        //private clsBaseCaseHistorySevice m_objBaseServ;
        //private clsNewBabyCircsRecordService m_objCircsServ;
        public clsBrothRecords_F2Domain(clsBaseCaseHistorySevice p_objProcessServ)
        {
            //m_objBaseServ =  p_objProcessServ;
        }

        public clsBrothRecords_F2Domain()
        {
            //clsNewBabyInRoomRecordService objServ = new clsNewBabyInRoomRecordService();
            //m_objBaseServ =  objServ;
            //m_objCircsServ = new clsNewBabyCircsRecordService();
        }

        // 获取病人该特殊记录的时间列表。
        public long m_lngGetRecordTimeList(string p_strInPatientID,
            out string[] p_strInPatientDateArr,
            out string[] p_strCreateRecordTimeArr,
            out string[] p_strOpenRecordTimeArr)
        {
            //参数判断
            p_strCreateRecordTimeArr = null;
            p_strOpenRecordTimeArr = null;

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngGetRecordTimeList(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, out p_strInPatientDateArr, out p_strCreateRecordTimeArr, out p_strOpenRecordTimeArr);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 获取指定记录内容。
        public long m_lngGetRecordContent(string p_strInPatientID,
            string p_strInPatientDate,/*string p_strOpenRecordTime,*/
            out clsBaseCaseHistoryInfo p_objRecordContent,
            out clsPictureBoxValue[] p_objPicValueArr)
        {
            //参数判断
            p_objRecordContent = null;

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate,/*p_strOpenRecordTime,*/out p_objRecordContent, out p_objPicValueArr);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 添加新记录。
        public long m_lngAddNewRecord(clsBaseCaseHistoryInfo p_objRecordContent, clsPictureBoxValue[] p_objPicValueArr, string p_strDiseaseID, out clsPreModifyInfo p_objModifyInfo)
        {
            //参数判断
            p_objModifyInfo = null;

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objRecordContent, p_objPicValueArr, p_strDiseaseID, clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID, out p_objModifyInfo);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 修改记录。
        public long m_lngModifyRecord(clsBrothRecords_F2 p_objOldRecordContent,
            clsBrothRecords_F2 p_objNewRecordContent, clsPictureBoxValue[] p_objPicValueArr,
            string p_strDiseaseID,
            out clsPreModifyInfo p_objModifyInfo)
        {
            //参数判断
            p_objModifyInfo = null;

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objOldRecordContent, p_objNewRecordContent, p_objPicValueArr, p_strDiseaseID, clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID, out p_objModifyInfo);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 删除记录。
        public long m_lngDeleteRecord(clsBrothRecords_F2 p_objRecordContent, out clsPreModifyInfo p_objModifyInfo)
        {
            //参数判断

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objRecordContent, out p_objModifyInfo);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 作废重做记录。
        public long m_lngReAddNewRecord(clsInPatientCaseHistoryContent m_objDelRecord,
            clsBrothRecords_F2 m_objAddNewRecord,
            out clsPreModifyInfo p_objModifyInfo)
        {
            //参数判断
            p_objModifyInfo = null;

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngReAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, m_objDelRecord, m_objAddNewRecord, out p_objModifyInfo);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 获取打印信息。
        // 1.获取打印内容：如果输入参数p_dtmModifyDate不是最新的ModifyDate，输出变量 p_objContent
        //   会存放最新的内容；否则，输出变量为null。
        // 2.获取打印时间：输出变量 p_dtmFirstPrintDate 存放首次打印时间。p_blnIsFirstPrint标记
        //   是否首次打印，如果是为true，客户端在打印后需要保存p_dtmFirstPrintDate到数据库。
        public long m_lngGetPrintInfo(string p_strInPatientID, string p_strInPatientDate,/*string p_strOpenDate,*/DateTime p_dtmModifyDate,
            out clsBaseCaseHistoryInfo p_objContent,
            out clsPictureBoxValue[] p_objPicValueArr,
            out DateTime p_dtmFirstPrintDate,
            out bool p_blnIsFirstPrint)
        {
            p_dtmFirstPrintDate = DateTime.MinValue;
            p_blnIsFirstPrint = false;
            p_objContent = null;
            p_objPicValueArr = null;

            if (p_strInPatientID == "" || p_strInPatientID == null || p_strInPatientDate == "" || p_strInPatientDate == null)//|| p_strOpenDate=="" || p_strOpenDate==null )
                return (long)enmOperationResult.Parameter_Error;


            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngGetPrintInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_dtmModifyDate, out p_objContent, out p_objPicValueArr, out p_dtmFirstPrintDate, out p_blnIsFirstPrint);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;

        }

        // 更新数据库中的首次打印时间。
        public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strOpenDate,
            DateTime p_dtmFirstPrintDate)
        {
            //			return (long)enmOperationResult.DB_Succeed;
            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, p_dtmFirstPrintDate);
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }

        // 获取病人的已经被删除记录时间列表。
        public long m_lngGetDeleteRecordTimeList(string p_strInPatientID,
            string p_strInPatientDate,
            clsPatient p_strDeleteUserID,
            out string[] p_strCreateRecordTimeArr,
            out string[] p_strOpenRecordTimeArr)
        {
            p_strCreateRecordTimeArr = null;
            p_strOpenRecordTimeArr = null;
            return (long)enmOperationResult.DB_Succeed;
        }

        // 获取病人的已经被删除记录时间列表。
        public long m_lngGetDeleteRecordTimeListAll(string p_strInPatientID,
            string p_strInPatientDate,
            out string[] p_strCreateRecordTimeArr,
            out string[] p_strOpenRecordTimeArr)
        {
            p_strCreateRecordTimeArr = null;
            p_strOpenRecordTimeArr = null;
            return (long)enmOperationResult.DB_Succeed;
        }

        // 获取指定已经被删除记录的内容。
        public long m_lngGetDeleteRecordContent(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strOpenRecordTime,
            out clsBrothRecords_F2 p_objRecordContent)
        {
            p_objRecordContent = null;
            iCareData.clsBaseCaseHistoryInfo objRecordContent = null;

            clsBrothRecords_F2Service objServ =
                (clsBrothRecords_F2Service)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2Service));

            long m_lngRes = 0;
            try
            {
                m_lngRes = objServ.m_lngGetDeleteRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenRecordTime, out objRecordContent);
                p_objRecordContent = (clsBrothRecords_F2)objRecordContent;
            }
            finally
            {
                //objServ.Dispose();
            }
            return m_lngRes;
        }
















        /// <summary>
        /// 添加新生儿情况记录
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_objModifyInfo"></param>
        /// <returns></returns>
        public long m_lngAddNewCircsRecord(clsBrothRecords_F2Rec p_objRecordContent,
            out clsPreModifyInfo p_objModifyInfo)
        {
            p_objModifyInfo = null;

            clsBrothRecords_F2RecService m_objCircsServ =
                (clsBrothRecords_F2RecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2RecService));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objCircsServ.m_lngAddNewRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objRecordContent, out p_objModifyInfo);
            }
            finally
            {
                //m_objCircsServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 修改新生儿情况记录
        /// </summary>
        /// <param name="p_objOldRecordContent"></param>
        /// <param name="p_objNewRecordContent"></param>
        /// <param name="p_objModifyInfo"></param>
        /// <returns></returns>
        public long m_lngModifyCircsRecord(clsBrothRecords_F2Rec p_objOldRecordContent,
            clsBrothRecords_F2Rec p_objNewRecordContent,
            out clsPreModifyInfo p_objModifyInfo)
        {
            p_objModifyInfo = null;

            clsBrothRecords_F2RecService m_objCircsServ =
                (clsBrothRecords_F2RecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2RecService));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objCircsServ.m_lngModifyRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objOldRecordContent, p_objNewRecordContent, out p_objModifyInfo);
            }
            finally
            {
                //m_objCircsServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 删除新生儿情况记录
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_objModifyInfo"></param>
        /// <returns></returns>
        public long m_lngDeleteCircsRecord(clsBrothRecords_F2Rec p_objRecordContent)
        {
            clsBrothRecords_F2RecService m_objCircsServ =
                (clsBrothRecords_F2RecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2RecService));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objCircsServ.m_lngDeleteCircsRecord(p_objRecordContent);
            }
            finally
            {
                //m_objCircsServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 获取新生儿情况记录
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_objRecordContent"></param>
        /// <returns></returns>
        public long m_lngGetCircsRecordContent(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strOpenDate,
            out clsBrothRecords_F2Rec p_objRecordContent)
        {
            p_objRecordContent = null;
            clsTrackRecordContent objTemp = null;

            clsBrothRecords_F2RecService m_objCircsServ =
                (clsBrothRecords_F2RecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2RecService));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objCircsServ.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out objTemp);
                p_objRecordContent = (clsBrothRecords_F2Rec)objTemp;
            }
            finally
            {
                //m_objCircsServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 获取新生儿情况记录
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strBirthTime"></param>
        /// <param name="p_objRecordContentArr"></param>
        /// <returns></returns>
        public long m_lngGetAllCircsRecordContent(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strBirthTime,
            out clsBrothRecords_F2Rec[] p_objRecordContentArr)
        {
            p_objRecordContentArr = null;

            clsBrothRecords_F2RecService m_objCircsServ =
                (clsBrothRecords_F2RecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2RecService));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objCircsServ.m_lngGetAllContent(p_strInPatientID, p_strInPatientDate, p_strBirthTime, out p_objRecordContentArr);
            }
            finally
            {
                //m_objCircsServ.Dispose();
            }
            return m_lngRes;
        }

        /// <summary>
        /// 获取修改后所有的新生儿情况记录
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strBirthTime"></param>
        /// <param name="p_objRecordContentArr"></param>
        /// <returns></returns>
        public long m_lngGetAllModifiedCircsRecordContent(string p_strInPatientID,
            string p_strInPatientDate,            
            out clsBrothRecords_F2Rec[] p_objRecordContentArr)
        {
            p_objRecordContentArr = null;

            clsBrothRecords_F2RecService m_objCircsServ =
                (clsBrothRecords_F2RecService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsBrothRecords_F2RecService));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objCircsServ.m_lngGetAllModifiedContent(p_strInPatientID, p_strInPatientDate, out p_objRecordContentArr);
            }
            finally
            {
                //m_objCircsServ.Dispose();
            }
            return m_lngRes;
        }
    }
}
