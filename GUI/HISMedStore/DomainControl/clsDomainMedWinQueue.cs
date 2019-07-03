using System;
using System.Data;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房业务操作
    /// Create by xgpeng 2006-02-20
    /// </summary>
    class clsDomainMedWinQueue : clsDomainController_Base
    {

        #region 构造函数
		/// <summary>
		/// 
		/// </summary>
        public clsDomainMedWinQueue()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

        #region 获得药房信息(名称)
        /// <summary>
        /// 获得药房信息(名称)
        /// </summary>
        /// <param name="p_dtable"></param>
        /// <returns></returns>
        public long m_lngGetMedStoreInfo(out DataTable p_dtable)
        {
            long lngRes = 0;
            clsMedSendConfigRelation_SVC objSvc =
                (clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

            lngRes = objSvc.m_lngGetMedStoreInfo(objPrincipal, out p_dtable);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获得窗口队列信息
       /// <summary>
        /// 获得窗口队列信息
       /// </summary>
       /// <param name="p_strID"></param>
       /// <param name="flage"></param>
       /// <param name="p_dtimeBegin"></param>
       /// <param name="p_dtimeEnd"></param>
       /// <param name="p_DataTableQueue"></param>
       /// <returns></returns>
        public long m_lngGetWinQueueByMedStoreID(string p_strID,int flage,DateTime p_dtimeBegin,DateTime p_dtimeEnd,out DataTable p_DataTableQueue)
        {
            long lngRes = 0;
            clsMedSendConfigRelation_SVC objSvc =
                (clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

            lngRes = objSvc.m_lngGetWinQueueByMedStoreID(objPrincipal, p_strID, flage, p_dtimeBegin, p_dtimeEnd, out  p_DataTableQueue);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 判断是否旧数据
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Seq"></param>
        /// <param name="p_WinStyle"></param>
        /// <param name="p_Status"></param>
        /// <returns></returns>
        public long m_thJudgeIsOldData(int p_Seq,int p_WinStyle,out int p_Status)
        {
            long lngRes = 0;
            clsMedSendConfigRelation_SVC objSvc =
                (clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

            lngRes = objSvc.m_thJudgeIsOldData(objPrincipal,p_Seq,p_WinStyle,out p_Status);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 保存垂直拖动记录
        /// <summary>
        /// 获得药房信息(名称)
        /// </summary>
        /// <param name="p_dtable"></param>
        /// <returns></returns>
        public long  m_lngVerichDropRecord(int p_Seq,int p_Order)
        {
            long lngRes = 0;
            clsMedSendConfigRelation_SVC objSvc =
                (clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

            lngRes = objSvc.m_lngVerichDropRecord(objPrincipal, p_Seq, p_Order);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 保存斜向拖动记录
       /// <summary>
        ///  保存斜向拖动记录
       /// </summary>
       /// <param name="p_Seq"></param>
       /// <param name="p_WinID"></param>
       /// <param name="p_WinType"></param>
       /// <param name="p_Order"></param>
       /// <returns></returns>
        public long m_lngHorDropRecord(int p_Seq, string p_WinID, int p_WinType, int p_Order)
        {
            long lngRes = 0;
            clsMedSendConfigRelation_SVC objSvc =
                (clsMedSendConfigRelation_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedSendConfigRelation_SVC));

            lngRes = objSvc.m_lngHorDropRecord(objPrincipal, p_Seq, p_WinID, p_WinType, p_Order);
            objSvc.Dispose();
            return lngRes;
        }
         #endregion
    }
}
