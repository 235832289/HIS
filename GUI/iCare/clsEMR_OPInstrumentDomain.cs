using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.DiseaseTrackService;
using iCareData;

namespace iCare
{
    public class clsEMR_OPInstrumentDomain
    {
        #region 添加项目至字典表
        /// <summary>
        /// 添加项目至字典表
        /// </summary>
        /// <param name="p_strItemName">项目名称</param>
        /// <returns></returns>
        public long m_lngAddNewToDict(string p_strItemName)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngAddNewToDict(p_strItemName);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 修改字典表项目
        /// <summary>
        /// 修改字典表项目
        /// </summary>
        /// <param name="p_intOPInstrumentID">项目ID</param>
        /// <param name="p_strOPInstrumentName">项目名称</param>
        /// <returns></returns>
        public long m_lngModifyToDisc(int p_intOPInstrumentID, string p_strOPInstrumentName)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngModifyToDisc(p_intOPInstrumentID, p_strOPInstrumentName);
            objService = null;
            return lngRes;
        }
        #endregion

        #region 停用字典表项目
        /// <summary>
        /// 停用字典表项目
        /// </summary>
        /// <param name="p_intOPInstrumentID">项目ID</param>
        /// <returns></returns>
        public long m_lngDeActiveItemFromDict(int p_intOPInstrumentID)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngDeActiveItemFromDict(p_intOPInstrumentID);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 启用字典表项目
        /// <summary>
        /// 启用字典表项目
        /// </summary>
        /// <param name="p_intOPInstrumentID">项目ID</param>
        /// <returns></returns>
        public long m_lngActiveItemFromDict(int p_intOPInstrumentID)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngActiveItemFromDict(p_intOPInstrumentID);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 设置已启用项目顺序
        /// <summary>
        /// 设置已启用项目顺序
        /// </summary>
        /// <param name="p_intOPInstrumentID">项目ID</param>
        /// <param name="p_intOrderID">顺序号</param>
        /// <returns></returns>
        public long m_lngUpdateOrderID(int p_intOPInstrumentID, int p_intOrderID)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngUpdateOrderID(p_intOPInstrumentID, p_intOrderID);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 获取所有字典表项目
        /// <summary>
        /// 获取所有字典表项目
        /// </summary>
        /// <param name="p_obDictItems">所有项目</param>
        /// <returns></returns>
        public long m_lngGetAllItemsFromDict(out clsEMR_OPInstrument_Dict[] p_obDictItems)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngGetAllItemsFromDict(out p_obDictItems);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 获取已启用字典表项目
        /// <summary>
        /// 获取已启用字典表项目
        /// </summary>
        /// <param name="p_obDictItems">已启用项目</param>
        /// <returns></returns>
        public long m_lngGetActiveItemsFromDict(out clsEMR_OPInstrument_Dict[] p_obDictItems)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngGetActiveItemsFromDict(out p_obDictItems);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 检查字典表是否已有该项目
        /// <summary>
        /// 检查字典表是否已有该项目
        /// </summary>
        /// <param name="p_strOPInstrumentName">项目名称</param>
        /// <param name="p_intOPInstrumentID">项目ID</param>
        /// <returns></returns>
        public long m_lngCheckSameItemID(string p_strOPInstrumentName, out int p_intOPInstrumentID)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = objService.m_lngCheckSameItemID(p_strOPInstrumentName, out p_intOPInstrumentID);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 获取指定记录的内容
        /// <summary>
        /// 获取指定记录的内容。
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院日期</param>
        /// <param name="p_strOpenDate">记录时间</param>
        /// <param name="p_objRecordContent">返回的记录内容</param>
        /// <returns></returns>
        public long m_lngGetRecordContent(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strOpenDate,
            out clsTrackRecordContent p_objRecordContent)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = 0;
            lngRes = objService.m_lngGetRecordContent(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, out p_objRecordContent);
            objService = null;
            return lngRes;
        } 
        #endregion

        #region 更新数据库中的首次打印时间
        /// <summary>
        /// 更新数据库中的首次打印时间。
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院日期</param>
        /// <param name="p_strOpenDate">记录时间</param>
        /// <param name="p_dtmFirstPrintDate">首次打印时间</param>
        /// <returns></returns>
        public long m_lngUpdateFirstPrintDate(string p_strInPatientID,
            string p_strInPatientDate,
            string p_strOpenDate,
            DateTime p_dtmFirstPrintDate)
        {
            clsEMR_OPInstrumentService objService =
                (clsEMR_OPInstrumentService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_OPInstrumentService));

            long lngRes = 0;
            lngRes = objService.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strOpenDate, p_dtmFirstPrintDate);
            objService = null;
            return lngRes;
        } 
        #endregion
    }
}
