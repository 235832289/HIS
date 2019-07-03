using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections.Generic;
//新增下面的
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 医嘱执行	逻辑控制层
    /// 作者： 徐斌辉
    /// 创建时间： 2004-12-23
    /// </summary>
    public class clsDcl_ExecuteOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造函数
        public clsDcl_ExecuteOrder()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        //执行医嘱
        #region 获取医嘱-全部
        /// <summary>
        /// 获取医嘱 [数组=包括“1:可以执行   2:频率不需执行   3:已执行	4:已停止”]	
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单ID [out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetCanExecuteOrder(string p_strAreaID, string p_strBedIDs, DateTime dtExecuteDate, out clsBIHCanExecOrder[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetCanExecuteOrder(p_strAreaID, p_strBedIDs, dtExecuteDate, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 获取医嘱 [数组=包括“1:可以执行   2:频率不需执行   3:已执行	4:已停止”]	
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_strOrderType">用逗号分隔的医嘱类型	{如果为空则不作为查询条件}</param>
        /// <param name="p_strOrderStatus">用逗号分隔的执行状态	{如果为空则不作为查询条件}</param>
        /// <param name="p_strOrderCate">用逗号分隔的诊疗项目类型	{如果为空则不作为查询条件}</param>
        /// <param name="p_blnNeedFeel">仅显皮试</param>
        /// <param name="p_blnTakeMedicine">出院带药</param>
        /// <param name="p_blnOnlyToday">仅显当天	{提交时间}</param>
        /// <param name="strCreatorID">创建者ID</param>
        /// <param name="dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单ID [out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetCanExecuteOrder(string p_strAreaID, string p_strBedIDs, string p_strOrderType, string p_strOrderStatus, string p_strOrderCate, bool p_blnNeedFeel, bool p_blnTakeMedicine, bool p_blnOnlyToday, string strCreatorID, DateTime dtExecuteDate, out clsBIHCanExecOrder[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetCanExecuteOrder(p_strAreaID, p_strBedIDs, p_strOrderType, p_strOrderStatus, p_strOrderCate, p_blnNeedFeel, p_blnOnlyToday, p_blnTakeMedicine, strCreatorID, dtExecuteDate, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱-执行
        /// <summary>
        /// 获取医嘱 [数组=包括“1:可以执行”]
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单ID [out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetCanExecuteOrderOnlyCan(string p_strAreaID, string p_strBedIDs, DateTime dtExecuteDate, out clsBIHCanExecOrder[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetCanExecuteOrderOnlyCan(p_strAreaID, p_strBedIDs, dtExecuteDate, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 获取医嘱 [数组=包括“1:可以执行”]
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_strOrderType">用逗号分隔的医嘱类型	{如果为空则不作为查询条件}</param>
        /// <param name="p_strOrderStatus">用逗号分隔的执行状态	{如果为空则不作为查询条件}</param>
        /// <param name="p_strOrderCate">用逗号分隔的诊疗项目类型	{如果为空则不作为查询条件}</param>
        /// <param name="p_blnNeedFeel">仅显皮试</param>
        /// <param name="p_blnTakeMedicine">出院带药</param>
        /// <param name="p_blnOnlyToday">仅显当天	{提交时间}</param>
        /// <param name="strCreatorID">创建者ID</param>
        /// <param name="dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单ID [out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetCanExecuteOrderOnlyCan(string p_strAreaID, string p_strBedIDs, string p_strOrderType, string p_strOrderStatus, string p_strOrderCate, bool p_blnNeedFeel, bool p_blnTakeMedicine, bool p_blnOnlyToday, string strCreatorID, DateTime dtExecuteDate, out clsBIHCanExecOrder[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetCanExecuteOrderOnlyCan(p_strAreaID, p_strBedIDs, p_strOrderType, p_strOrderStatus, p_strOrderCate, p_blnNeedFeel, p_blnOnlyToday, p_blnTakeMedicine, strCreatorID, dtExecuteDate, out p_objResultArr);

            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱-审核提交
        /// <summary>
        /// 获取医嘱-审核提交	{执行状态=1-提交;}
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单Vo[out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetOrderForAuditingExecute(string p_strAreaID, string p_strBedIDs, DateTime p_dtExecuteDate, out clsBIHCanExecOrder[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderForAuditingExecute(p_strAreaID, p_strBedIDs, p_dtExecuteDate, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱-审核提交(判断当前病区是否存在已提交的医嘱)
        /// <summary>
        /// 获取医嘱-审核提交	{执行状态=1-提交;}
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单Vo[out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetOrderForAuditingExecute(string p_strAreaID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));

            lngRes = objSvc.m_lngGetOrderForAuditingExecute(p_strAreaID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱-审核停止
        /// <summary>
        /// 获取医嘱-审核停止	{执行状态=3-停止;}
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_strBedIDs">用逗号分隔的病床ID	{如果为空则不作为查询条件}</param>
        /// <param name="p_dtExecuteDate">执行时间</param>
        /// <param name="p_objResultArr">可执行医嘱单Vo[out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetOrderForAuditingStop(string p_strAreaID, string p_strBedIDs, DateTime p_dtExecuteDate, out clsBIHCanExecOrder[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderForAuditingStop(p_strAreaID, p_strBedIDs, p_dtExecuteDate, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 执   行、审核提交、审核停止
        /// <summary>
        /// 执行医嘱	[单条医嘱]
        /// </summary>
        /// <param name="strOrderID">医嘱ID</param>
        /// <param name="strOrderExecID">执行单记录ID [out 参数，如果返回多个ID则有逗号“，”分割，为空执行失败。]</param>
        /// <param name="blnIsRecruit">指定是否补次(即执行两次)</param>
        /// <param name="strEmpID">执行医生流水号</param>
        /// <param name="strEmpName">执行医生姓名</param>
        /// <param name="dtExecDate">执行日期</param>
        /// <returns></returns>
        /// <remarks>
        ///		1、作为Com+事务：如果执行医嘱失败，则报错“医嘱执行错误！”，并回滚。
        ///		2、调本方法，注意要做异常处理；
        ///	</remarks>
        public long m_lngExecuteOrder(string strOrderID, out string strOrderExecID, bool blnIsRecruit, string strEmpID, string strEmpName, DateTime dtExecDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngExecuteOrder(objPrincipal, strOrderID, out strOrderExecID, blnIsRecruit, strEmpID, strEmpName, dtExecDate);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        ///  执行医嘱	[多条医嘱]	事务
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_strOrderExecIDArr">执行单记录ID [数组] [out 参数，如果返回多个ID则有逗号“，”分割，为空执行失败。]</param>
        /// <param name="p_blnIsRecruitArr">指定是否补次(即执行两次) [数组] </param>
        /// <param name="p_strEmpID">执行医生流水号 [数组] </param>
        /// <param name="p_strEmpName">执行医生姓名 [数组] </param>
        /// <param name="p_dtExecDate">执行日期 [数组] </param>
        /// <param name="p_strParentIDArr">父级医嘱ID [数组] </param>
        /// <returns>返回{-1=不能作执行操作；、0=执行出错；、1=成功；}</returns>
        public long m_lngExecuteOrder(string[] p_strOrderIDArr, out string[] p_strOrderExecIDArr, bool[] p_blnIsRecruitArr, string p_strEmpID, string p_strEmpName, DateTime p_dtExecDate, string[] p_strParentIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngExecuteOrder(objPrincipal, p_strOrderIDArr, out p_strOrderExecIDArr, p_blnIsRecruitArr, p_strEmpID, p_strEmpName, p_dtExecDate, p_strParentIDArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        ///  执行医嘱	[多条医嘱]	事务
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_strRegisterIDArr">入院登记ID [数组]</param>
        /// <param name="p_intRecipenNoArr">方号 [数组]</param>
        /// <param name="p_strOrderExecIDArr">执行单记录ID [数组] [out 参数，如果返回多个ID则有逗号“，”分割，为空执行失败。]</param>
        /// <param name="p_blnIsRecruitArr">指定是否补次(即执行两次) [数组] </param>
        /// <param name="p_strEmpID">执行医生流水号 [数组] </param>
        /// <param name="p_strEmpName">执行医生姓名 [数组] </param>
        /// <param name="p_dtExecDate">执行日期 [数组] </param>
        /// <param name="p_strParentIDArr">父级医嘱ID [数组] </param>
        /// <returns>返回{-1=不能作执行操作；、0=执行出错；、1=成功；}</returns>
        public long m_lngExecuteOrder(string[] p_strOrderIDArr, string[] p_strRegisterIDArr, int[] p_intRecipenNoArr, out string[] p_strOrderExecIDArr, bool[] p_blnIsRecruitArr, string p_strEmpID, string p_strEmpName, DateTime p_dtExecDate, string[] p_strParentIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngExecuteOrder(objPrincipal, p_strOrderIDArr, p_strRegisterIDArr, p_intRecipenNoArr, out p_strOrderExecIDArr, p_blnIsRecruitArr, p_strEmpID, p_strEmpName, p_dtExecDate, p_strParentIDArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 审核提交
        /// </summary>
        /// <param name="p_strOrderIDArr">[数组]	医嘱ID</param>
        /// <param name="p_strHandlersID">操作者ID</param>
        /// <param name="p_strHandlers">操作者名称</param>
        /// <returns></returns>
        public long m_lngAuditingForExecute(string[] p_strOrderIDArr, string p_strHandlersID, string p_strHandlers)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngAuditingForExecute(objPrincipal, p_strOrderIDArr, p_strHandlersID, p_strHandlers);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 退回医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：2-执行、5-已审核提交
        /// </summary>
        /// <param name="p_strReturnOrderID">退回医嘱ID</param>
        /// <param name="p_strReturnReason">原因</param>
        /// <param name="strDoctorID">操作者ID</param>
        /// <param name="strDoctorName">操作者名称</param>
        /// <returns></returns>
        public long m_lngReturnOrder(string p_strReturnOrderID, string p_strReturnReason, string strDoctorID, string strDoctorName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngReturnOrder(p_strReturnOrderID, p_strReturnReason, strDoctorID, strDoctorName);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 退回医嘱	
        /// 执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 已审核提交;6-审核停止;7-退回;}
        /// 业务说明：	只针对状态：2-执行、5-已审核提交
        /// </summary>
        /// <param name="p_strReturnOrderID">退回医嘱ID</param>
        /// <param name="p_strReturnReason">原因</param>
        /// <param name="strDoctorID">操作者ID</param>
        /// <param name="strDoctorName">操作者名称</param>
        /// <param name="p_blnInfectSon">是否梯归退回子级医嘱</param>
        /// <returns></returns>
        public long m_lngReturnOrder(string p_strReturnOrderID, string p_strReturnReason, string strDoctorID, string strDoctorName, bool p_blnInfectSon)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngReturnOrder(p_strReturnOrderID, p_strReturnReason, strDoctorID, strDoctorName, p_blnInfectSon);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 审核停止
        /// </summary>
        /// <param name="p_strOrderIDArr">[数组]	医嘱ID</param>
        /// <param name="p_strHandlersID">操作者ID</param>
        /// <param name="p_strHandlers">操作者名称</param>
        /// <returns></returns>
        public long m_lngAuditingForStop(string[] p_strOrderIDArr, string p_strHandlersID, string p_strHandlers)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngAuditingForStop(objPrincipal, p_strOrderIDArr, p_strHandlersID, p_strHandlers);
                objSvc.Dispose();
                objSvc = null;
            }
            catch { }
            return lngRes;
        }
        #endregion
        #region 判断是否可以执行医嘱
        /// <summary>
        /// 判断是否可以执行医嘱
        /// 业务说明：	子级医嘱不能单独执行，必须和其父级医嘱一起执行
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_strParentIDArr">父级医嘱ID [数组]</param>
        /// <param name="p_blnIsCanExecute">是否可以执行医嘱　[out 参数]</param>
        /// <returns></returns>
        public long m_lngCheckIsCanExecute(string[] p_strOrderIDArr, string[] p_strParentIDArr, out bool p_blnIsCanExecute)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngCheckIsCanExecute(objPrincipal, p_strOrderIDArr, p_strParentIDArr, out p_blnIsCanExecute);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱	[方号-提交用]
        /// <summary>
        /// 返回医嘱ID	[数组]
        /// 作用: 保证同方号的医嘱一起操作	{提交医嘱、停止医嘱、重整医嘱、作废医嘱}
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_intStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;}</param>
        /// <returns></returns>
        public string[] GetOrderIDSameRecipeNOForCommit(string[] p_strOrderIDArr, int p_intStatus)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            return objSvc.GetOrderIDSameRecipeNOForCommit(p_strOrderIDArr, p_intStatus);
        }
        #endregion
        #region 获取医嘱	[方号-执行用]
        /// <summary>
        /// 返回医嘱ID	数组
        /// 作用: 以便确保同方号的医嘱执行一起执行；
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID [数组]</param>
        /// <param name="p_intStatus">执行状态{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-重整;5- 审核提交;6-审核停止;}</param>
        /// <returns></returns>
        public string[] GetOrderIDSameRecipeNOForExecute(string[] p_strOrderIDArr)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            return objSvc.GetOrderIDSameRecipeNOForExecute(objPrincipal, p_strOrderIDArr);
        }
        #endregion

        //T_Opr_Bih_OrderFeel(医嘱皮试结果)
        #region 查找
        /// <summary>
        /// 查找皮试结果	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_objResult">医嘱皮试结果Vo对象	[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetOrderFeelByID(string p_strID, out clsT_Opr_Bih_OrderFeel_VO p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderFeelByID(objPrincipal, p_strID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 查找皮试结果	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_objResult">医嘱皮试结果Vo对象	[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetOrderFeelByOrderID(string p_strOrderID, out clsT_Opr_Bih_OrderFeel_VO p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderFeelByOrderID(objPrincipal, p_strOrderID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 增加
        /// <summary>
        /// 增加皮试结果
        /// </summary>
        /// <param name="p_strRecordID">流水好	[out 参数]</param>
        /// <param name="p_objRecord">医嘱皮试结果Vo对象</param>
        /// <returns></returns>
        public long m_lngAddNewOrderFeel(out string p_strRecordID, clsT_Opr_Bih_OrderFeel_VO p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngAddNewOrderFeel(objPrincipal, out p_strRecordID, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 修改
        /// <summary>
        /// 修改皮试结果
        /// </summary>
        /// <param name="p_strOrderFeelID">流水好</param>
        /// <param name="p_objRecord">医嘱皮试结果Vo对象</param>
        /// <returns></returns>
        public long m_lngModifyOrderFeel(clsT_Opr_Bih_OrderFeel_VO p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngModifyOrderFeel(objPrincipal, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        //附加单据影射
        #region 增加附加单据影射
        /// <summary>
        /// 增加附加单据影射
        /// </summary>
        /// <param name="strOrderID">医嘱ID</param>
        /// <param name="strAttachID">医嘱附加单据ID</param>
        /// <returns></returns>
        public long m_lngAddAttachOrder(string strOrderID, string strAttachID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngAddAttachOrder(strOrderID, strAttachID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion
        #region 删除附加单据影射
        /// <summary>
        /// 删除附加单据影射
        /// </summary>
        /// <param name="strID">附加单据影射ID</param>
        /// <returns></returns>
        public long m_lngDeleteAttachOrder(string strID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngDeleteAttachOrder(strID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion
        #region 获取病人基本信息
        /// <summary>
        /// 获取病人基本信息	根据病人ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfoByPatientID(string p_strPatientID, out clsPatient_VO p_objResult)
        {
            p_objResult = null;
            long lngRes = 0;
            string strSQL = @"select a.* FROM t_bse_patient a where Trim(a.PATIENTID_CHR) = '" + p_strPatientID.Trim() + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsPatient_VO();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strNAME_VCHR = dtbResult.Rows[0]["NAME_VCHR"].ToString().Trim();
                    p_objResult.m_strSEX_CHR = dtbResult.Rows[0]["SEX_CHR"].ToString().Trim();
                    p_objResult.m_strINPATIENTID_CHR = dtbResult.Rows[0]["INPATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strIDCARD_CHR = dtbResult.Rows[0]["IDCARD_CHR"].ToString().Trim();
                }

            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 获取医嘱类型ＩＤ
        /// <summary>
        /// 获取医嘱类型ＩＤ	根据医嘱ＩＤ
        /// </summary>
        /// <param name="p_strOrderID">医嘱ＩＤ</param>
        /// <returns>医嘱类型ＩＤ</returns>
        public string m_strGetOrderCateIDByOrderID(string p_strOrderID)
        {
            string strOrderCateID = "";
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderCateIDByOrderID(p_strOrderID, out strOrderCateID);
            objSvc.Dispose();
            objSvc = null;
            return strOrderCateID;
        }
        #endregion

        //T_Opr_Bih_OrderAttach_Transfer(医嘱附加单据-转区)
        #region 查找
        /// <summary>
        /// 获取医嘱附加单据-转区	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetOrderAttachTransferByID(string p_strID, out clsT_Opr_Bih_OrderAttach_Transfer_Vo p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderAttachTransferByID(objPrincipal, p_strID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 增加
        /// <summary>
        /// 增加医嘱附加单据-转区
        /// </summary>
        /// <param name="p_strRecordID">流水号 [out 参数]</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngAddNewOrderAttachTransfer(out string p_strRecordID, clsT_Opr_Bih_OrderAttach_Transfer_Vo p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngAddNewOrderAttachTransfer(objPrincipal, out p_strRecordID, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 修改
        /// <summary>
        /// 修改医嘱附加单据-转区
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngModifyOrderAttachTransfer(clsT_Opr_Bih_OrderAttach_Transfer_Vo p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngModifyOrderAttachTransfer(objPrincipal, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 修改转区附加单据状态	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_intStatus">状态标志{0=未发送;1=已发送;2=已经有结果了;}</param>
        /// <returns></returns>
        public long m_lngChangeOrderAttachTransferState(string p_strID, int p_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngChangeOrderAttachTransferState(objPrincipal, p_strID, p_intStatus);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 生效转区附加单据状态	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_strActiveEmpID">生效人ID</param>
        /// <returns></returns>
        public long m_lngBecomeEffectiveOrderAttachTransfer(string p_strID, string p_strActiveEmpID, clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngBecomeEffectiveOrderAttachTransfer(objPrincipal, p_strID, p_strActiveEmpID, p_objRecord);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除医嘱附加单据-转区
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <returns></returns>
        public long m_lngDeleteOrderAttachTransfer(string p_strID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngDeleteOrderAttachTransfer(objPrincipal, p_strID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        //T_Opr_Bih_OrderAttach_Leave(医嘱附加单据-出院)
        #region 查找
        /// <summary>
        /// 获取出院附加单据	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetOrderAttachLeaveByID(string p_strID, out clsT_Opr_Bih_OrderAttach_Leave_Vo p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderAttachLeaveByID(objPrincipal, p_strID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 增加
        /// <summary>
        /// 增加出院附加单据
        /// </summary>
        /// <param name="p_strRecordID">流水号	[out 参数]</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngAddNewOrderAttachLeave(out string p_strRecordID, clsT_Opr_Bih_OrderAttach_Leave_Vo p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngAddNewOrderAttachLeave(objPrincipal, out p_strRecordID, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 修改
        /// <summary>
        /// 修改出院附加单据
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngModifyOrderAttachLeave(clsT_Opr_Bih_OrderAttach_Leave_Vo p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngModifyOrderAttachLeave(objPrincipal, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 修改出院附加单据状态	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_intStatus">状态标志{0=未发送;1=已发送;2=已经有结果了;}</param>
        /// <returns></returns>
        public long m_lngChangeOrderAttachLeaveState(string p_strID, int p_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngChangeOrderAttachLeaveState(objPrincipal, p_strID, p_intStatus);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 生效转区附加单据状态	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_strActiveEmpID">生效人ID</param>
        /// <returns></returns>
        public long m_lngBecomeEffectiveOrderAttachLeave(string p_strID, string p_strActiveEmpID, clsT_Opr_Bih_Leave_VO p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngBecomeEffectiveOrderAttachLeave(objPrincipal, p_strID, p_strActiveEmpID, p_objRecord);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除出院附加单据	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <returns></returns>
        public long m_lngDeleteOrderAttachLeave(string p_strID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngDeleteOrderAttachLeave(objPrincipal, p_strID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        //获取病人费用信息
        #region 获取累计费用
        /// <summary>
        /// 获取累计费用	根据入院登记流水号
        /// </summary>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <returns></returns>
        public double m_dblGetSumMoneyByRegisterID(string p_strRegisterID)
        {
            long lngRes = 0;
            double dblSumMoney = 0;
            com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            lngRes = objSvc.m_lngGetSumMoneyByRegisterID(p_strRegisterID, out dblSumMoney);
            objSvc.Dispose();
            objSvc = null;
            return dblSumMoney;
        }
        #endregion
        #region 获取结余费用
        /// <summary>
        /// 获取结余费用	根据入院登记流水号
        /// </summary>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <returns></returns>
        public double m_dblGetBalanceMoneyByRegisterID(string p_strRegisterID)
        {
            long lngRes = 0;
            double dblBalanceMoney = 0;
            com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            lngRes = objSvc.m_lngGetBalanceMoneyByRegisterID(p_strRegisterID, out dblBalanceMoney);
            objSvc.Dispose();
            objSvc = null;
            return dblBalanceMoney;
        }
        /// <summary>
        /// 获取费用下限	根据入院登记流水号
        /// </summary>
        /// <param name="p_strRegisterID">入院登记流水号</param>
        /// <returns></returns>
        public double m_dblGetLowerLimitMoneyByRegisterID(string p_strRegisterID)
        {
            long lngRes = 0;
            double dblLowerLimitMoney = 0;
            com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
            lngRes = objSvc.m_lngGetLowerLimitMoneyByRegisterID(p_strRegisterID, out dblLowerLimitMoney);
            objSvc.Dispose();
            objSvc = null;
            return dblLowerLimitMoney;
        }
        #endregion

        //连续性医嘱滚费	
        #region 连续性医嘱滚费
        /// <summary>
        /// 连续性医嘱滚费
        /// 业务说明: 
        ///		1、滚费时刻已经执行过；
        ///		2、滚费时刻还没有停止；
        ///		3、针对全部病人的全部连续性医嘱；
        ///		4、滚的是滚费时刻的当天的费用；
        ///		5、是一个事务；
        /// </summary>
        /// <param name="p_strHandlers">操作人姓名</param>
        /// <param name="p_strHandlersID">操作人ID</param>
        /// <param name="p_dtAuToExecDataTime">操作时间</param>
        /// <returns>{零=失败;大于零=成功{999则没有需要滚费的连续医嘱或已经滚过费了}}</returns>
        public long m_lngAuToCumulateMoneyForContinuousOrder(string p_strHandlers, string p_strHandlersID, DateTime p_dtAuToExecDataTime)
        {
            string textsucceed = "	连续性医嘱手工滚帐成功	滚费时刻{" + p_dtAuToExecDataTime.ToString("yyyy-MM-dd HH:mm:ss") + "}";
            string strNoRecord = "	没有要滚费的连续性医嘱	滚费时刻{" + p_dtAuToExecDataTime.ToString("yyyy-MM-dd HH:mm:ss") + "}";
            string textfailure = "	连续性医嘱手工滚帐失败	滚费时刻{" + p_dtAuToExecDataTime.ToString("yyyy-MM-dd HH:mm:ss") + "}";
            long lngRes = 0;
            digitalwaveHisAutoCharge.digitalwaveHisAutoCharge objSvc = (digitalwaveHisAutoCharge.digitalwaveHisAutoCharge)clsObjectGenerator.objCreatorObjectByType(typeof(digitalwaveHisAutoCharge.digitalwaveHisAutoCharge));
            try
            {
                lngRes = objSvc.m_lngAuToCumulateMoneyForContinuousOrder(objPrincipal, p_strHandlers, p_strHandlersID, p_dtAuToExecDataTime);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                try
                {
                    new digitalwaveHisAutoCharge.AppLog().WriteFile(textfailure);
                }
                catch { }
                return lngRes;
            }
            try
            {
                if (lngRes == 999)
                    new digitalwaveHisAutoCharge.AppLog().WriteFile(strNoRecord);
                else
                    new digitalwaveHisAutoCharge.AppLog().WriteFile(textsucceed);
            }
            catch { }
            return lngRes;
        }

        #endregion

        //事务
        #region 修改医嘱附加单据-转区的状态
        /// <summary>
        /// 提交医嘱附加单据-出院	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_intPStatus">状态标志{0=未发送;1=已发送;2=已经有结果了;}</param>
        /// <returns></returns>
        public long m_lngCommitAttachOrder_Transfer(string p_strOrderID, int p_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngCommitAttachOrder_Transfer(objPrincipal, p_strOrderID, p_intStatus);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion
        #region 修改医嘱附加单据-出院的状态
        /// <summary>
        /// 提交医嘱附加单据-出院	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_intPStatus">状态标志{0=未发送;1=已发送;2=已经有结果了;}</param>
        /// <returns></returns>
        public long m_lngCommitAttachOrder_Leave(string p_strOrderID, int p_intPStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngCommitAttachOrder_Leave(objPrincipal, p_strOrderID, p_intPStatus);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion

        //综合
        #region	获取医嘱信息、患者信息、住院信息	根据医嘱ID
        /// <summary>
        /// 获取医嘱信息、患者信息、住院信息	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_dtResult">DataTable	[out 参数]</param>
        /// <returns></returns>
        public long lngGetOrderPatientBIHInfo(string p_strOrderID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.lngGetOrderPatientBIHInfo(objPrincipal, p_strOrderID, out p_dtResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取当前时间可以执行的医嘱
        /// <summary>
        /// 获取当前时间可以执行的医嘱	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_strOrderIDArr">可执行医嘱ID [out 参数 数组]</param>
        /// <returns></returns>
        public long m_lngGetCanExecuteOrderByOrderID(string p_strOrderID, out string[] p_strOrderIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetCanExecuteOrderByOrderID(objPrincipal, p_strOrderID, out p_strOrderIDArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱类型-出院
        /// <summary>
        /// 获取医嘱类型-出院
        /// </summary>
        /// <returns>返回医嘱类型-出院</returns>
        public string m_strGetORDERCATEID_LEAVE_CHR()
        {
            DataTable dtbResult = new DataTable();
            long lngRes = new com.digitalwave.iCare.middletier.HIS.clsBedManageSvc().m_lngGetSpChargeItemIDType(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                return dtbResult.Rows[0]["ORDERCATEID_LEAVE_CHR"].ToString();
            }
            return "";
        }
        #endregion
        #region 获取医嘱类型-转科
        /// <summary>
        /// 获取医嘱类型-转科
        /// </summary>
        /// <returns>返回医嘱类型-转科</returns>
        public string m_strGetORDERCATEID_TRANSFER_CHR()
        {
            DataTable dtbResult = new DataTable();
            long lngRes = new com.digitalwave.iCare.middletier.HIS.clsBedManageSvc().m_lngGetSpChargeItemIDType(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                return dtbResult.Rows[0]["ORDERCATEID_TRANSFER_CHR"].ToString();
            }
            return "";
        }
        #endregion
        #region 获取临时医嘱类型ID
        /// <summary>
        /// 获取临时医嘱类型ID
        ///		注意：表中字段名为“FREQID_CHR”
        /// </summary>
        /// <returns></returns>
        public string m_strGetTemOrderRecipefreqID()
        {
            DataTable dtbResult = new DataTable();
            long lngRes = new com.digitalwave.iCare.middletier.HIS.clsBedManageSvc().m_lngGetSpChargeItemIDType(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                return dtbResult.Rows[0]["FREQID_CHR"].ToString();
            }
            return "";
        }
        #endregion
        #region 获取医嘱类型ID {药品}
        /// <summary>
        /// 获取医嘱类型ID {药品}
        ///		注意：表中字段名为“ORDERCATEID_MEDICINE_CHR”
        /// </summary>
        /// <returns></returns>
        public string m_strGetMedicineOrderTypeID()
        {
            DataTable dtbResult = new DataTable();
            long lngRes = new com.digitalwave.iCare.middletier.HIS.clsBedManageSvc().m_lngGetSpChargeItemIDType(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                return dtbResult.Rows[0]["ORDERCATEID_MEDICINE_CHR"].ToString();
            }
            return "";
        }
        #endregion
        #region 获取连续性医嘱频率ID
        /// <summary>
        /// 获取医嘱类型ID {药品}
        ///		注意：表中字段名为“CONFREQID_CHR”
        /// </summary>
        /// <returns></returns>
        public string m_strGetConfreqID()
        {
            DataTable dtbResult = new DataTable();
            long lngRes = new com.digitalwave.iCare.middletier.HIS.clsBedManageSvc().m_lngGetSpChargeItemIDType(out dtbResult);
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                return dtbResult.Rows[0]["CONFREQID_CHR"].ToString();
            }
            return "";
        }
        #endregion
        #region	判断医嘱是否排斥
        #region Old
        /// <summary>
        /// 判断医嘱(数组)内是否存在排斥	并返回排斥医嘱ID
        /// </summary>
        /// <param name="p_strOrderIDArr">医嘱ID</param>
        /// <param name="p_intActiveType">排斥生效类型{0=不作条件;1=提交时生效;2=执行时生效}</param>
        /// <param name="blnIsExclude">是否排斥	[out 参数]</param>
        /// <param name="p_strExcludeOrderID">排斥医嘱ID	[out 参数]</param>
        /// <returns></returns>
        public long m_lngIsExcludeOrder(string[] p_strOrderIDArr, int p_intActiveType, out bool blnIsExclude, out string[] p_strExcludeOrderIDArr)
        {
            long lngRes = 0;
            blnIsExclude = false;
            p_strExcludeOrderIDArr = null;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngIsExcludeOrder(objPrincipal, p_strOrderIDArr, p_intActiveType, out blnIsExclude, out p_strExcludeOrderIDArr);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = -1;
            }
            return lngRes;
        }
        /// <summary>
        /// 判断医嘱是否存在排斥
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_strOrderIDBaseArr">用来判断的医嘱</param>
        /// <param name="p_intActiveType">排斥生效类型{0=不作条件;1=提交时生效;2=执行时生效}</param>
        /// <param name="blnIsExclude">是否排斥	[out 参数]</param>
        /// <param name="p_strExcludeOrderID">排斥医嘱ID	[out 参数]</param>
        /// <returns></returns>
        public long m_lngIsExcludeOrder(string p_strOrderID, string[] p_strOrderIDBaseArr, int p_intActiveType, out bool blnIsExclude)
        {
            long lngRes = 0;
            blnIsExclude = false;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngIsExcludeOrder(objPrincipal, p_strOrderID, p_strOrderIDBaseArr, p_intActiveType, out blnIsExclude);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = -1;
            }
            return lngRes;
        }
        /// <summary>
        /// 判断医嘱(数组)内是否存在排斥	[事务]	并返回排斥医嘱ID
        /// 注意: “要判断的医嘱”必须在“用来判断的医嘱”内，否则返回执行失败！
        /// </summary>
        /// <param name="p_strOrderIDAimArr">要判断的医嘱</param>
        /// <param name="p_strOrderIDBaseArr">用来判断的医嘱</param>
        /// <param name="p_intActiveType">排斥生效类型{0=不作条件;1=提交时生效;2=执行时生效}</param>
        /// <param name="blnIsExclude">是否排斥	[out 参数]</param>
        /// <param name="p_strExcludeOrderIDArr">排斥医嘱ID	[out 参数]</param>
        /// <returns></returns>
        public long m_lngIsExcludeOrder(string[] p_strOrderIDAimArr, string[] p_strOrderIDBaseArr, int p_intActiveType, out bool blnIsExclude, out string[] p_strExcludeOrderIDArr)
        {
            long lngRes = 0;
            blnIsExclude = false;
            p_strExcludeOrderIDArr = null;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            try
            {
                lngRes = objSvc.m_lngIsExcludeOrder(objPrincipal, p_strOrderIDAimArr, p_strOrderIDBaseArr, p_intActiveType, out blnIsExclude, out p_strExcludeOrderIDArr);
                objSvc.Dispose();
                objSvc = null;
            }
            catch
            {
                lngRes = -1;
            }
            return lngRes;
        }
        #endregion
        #region New	徐斌辉	2005-02-18
        /// <summary>
        /// 判断医嘱是否存在排斥
        /// 注意：	
        ///		1、判断优先级	[全排斥(全、长、临)-普通排斥]；
        /// </summary>
        /// <param name="p_strOrderIDArr">要判断的医嘱	[数组]</param>
        /// <param name="p_intActiveType">排斥生效类型{0=不作条件;1=提交时生效;2=执行时生效}</param>
        /// <param name="p_intExcludeType">[out 参数]	排斥类型{0=没排斥；1=全排斥临时医嘱；2=全排斥长期医嘱；3=全排斥临常医嘱；4=普通排斥；}</param>
        /// <param name="p_strExcludeOrderIDArr">[out 参数]	“目标医嘱”中存在排斥的医嘱ID</param>
        /// <param name="p_strExcludeOrderIDArr">[out 参数]	“目标医嘱”中存在排斥的医嘱名称</param>
        /// <returns></returns>
        public long m_lngJudgeExcludeOrder(string[] p_strOrderIDArr, int p_intActiveType, out int p_intExcludeType, out string[] p_strExcludeOrderIDArr, out string[] p_strExcludeOrderNameArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngJudgeExcludeOrder(objPrincipal, p_strOrderIDArr, p_intActiveType, out p_intExcludeType, out p_strExcludeOrderIDArr, out p_strExcludeOrderNameArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 判断医嘱是否存在排斥
        /// 注意：	
        ///		1、判断优先级	[全排斥(全、长、临)-普通排斥]；
        ///		2、这里没有判断目标医嘱自身的排斥；
        /// </summary>
        /// <param name="p_strOrderIDAimArr">要判断的“目标医嘱”</param>
        /// <param name="p_strOrderIDBaseArr">用来判断的“参照医嘱”</param>
        /// <param name="p_intActiveType">排斥生效类型{0=不作条件;1=提交时生效;2=执行时生效}</param>
        /// <param name="p_intExcludeType">[out 参数]	排斥类型{0=没排斥；1=全排斥临时医嘱；2=全排斥长期医嘱；3=全排斥临常医嘱；4=普通排斥；}</param>
        /// <param name="p_strExcludeOrderIDArr">[out 参数]	“目标医嘱”中存在排斥的医嘱ID</param>
        /// <param name="p_strExcludeOrderIDArr">[out 参数]	“目标医嘱”中存在排斥的医嘱名称</param>
        /// <returns></returns>
        public long m_lngJudgeExcludeOrder(string[] p_strOrderIDAimArr, string[] p_strOrderIDBaseArr, int p_intActiveType, out int p_intExcludeType, out string[] p_strExcludeOrderIDArr, out string[] p_strExcludeOrderNameArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngJudgeExcludeOrder(objPrincipal, p_strOrderIDAimArr, p_strOrderIDBaseArr, p_intActiveType, out p_intExcludeType, out p_strExcludeOrderIDArr, out p_strExcludeOrderNameArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #endregion
        #region 检查病人是否请假
        /// <summary>
        /// 检查病人是否存在请假的
        /// </summary>
        /// <param name="p_strRegisterIDs">入院登记ID	{多个,用逗号分隔.如: “'00001','0002','0006'”}</param>
        /// <param name="p_blnIsLeave">[out参数]	请假</param>
        /// <returns></returns>
        public long m_lngCheckPatientIsLeave(string p_strRegisterIDs, out bool p_blnIsLeave)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngCheckPatientIsLeave(objPrincipal, p_strRegisterIDs, out p_blnIsLeave);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找医嘱附加单据	根据ID
        /// </summary>
        /// <param name="p_strID">流水号</param>
        /// <param name="p_objResult">医嘱附加单据Vo对象	[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetTemfororderByID(string p_strID, out clsT_Opr_Bih_Temfororder_VO p_objResult)
        {
            p_objResult = null;
            long lngRes = 0;
            string strSQL = @"SELECT * FROM T_opr_bih_temfororder WHERE ID_CHR = '" + p_strID + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult = new clsT_Opr_Bih_Temfororder_VO();
                    p_objResult.m_strID_CHR = dtbResult.Rows[0]["ID_CHR"].ToString().Trim();
                    p_objResult = new clsT_Opr_Bih_Temfororder_VO();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strPATIENTNAME_CHR = dtbResult.Rows[0]["PATIENTNAME_CHR"].ToString().Trim();
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    p_objResult.m_strMAZUI_CHR = dtbResult.Rows[0]["MAZUI_CHR"].ToString().Trim();
                    p_objResult.m_fltPSTATUS_CHR = Convert.ToInt32(dtbResult.Rows[0]["PSTATUS_CHR"].ToString().Trim());
                    p_objResult.m_strDESC_VCHR = dtbResult.Rows[0]["DESC_VCHR"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 查找医嘱附加单据	根据ID
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">医嘱附加单据Vo对象	[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetTemfororderByPatientIDRegisterID(string p_strPatientID, string p_strRegisterID, out clsT_Opr_Bih_Temfororder_VO p_objResult)
        {
            p_objResult = new clsT_Opr_Bih_Temfororder_VO();
            long lngRes = 0;
            string strSQL = @"SELECT * FROM T_opr_bih_temfororder WHERE Trim(PATIENTID_CHR) = '" + p_strPatientID.Trim() + "' and Trim(REGISTERID_CHR) = '" + p_strRegisterID.Trim() + "'";
            try
            {
                DataTable dtbResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
                objHRPSvc.Dispose();
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResult.m_strID_CHR = dtbResult.Rows[0]["ID_CHR"].ToString().Trim();
                    p_objResult = new clsT_Opr_Bih_Temfororder_VO();
                    p_objResult.m_strPATIENTID_CHR = dtbResult.Rows[0]["PATIENTID_CHR"].ToString().Trim();
                    p_objResult.m_strPATIENTNAME_CHR = dtbResult.Rows[0]["PATIENTNAME_CHR"].ToString().Trim();
                    p_objResult.m_strREGISTERID_CHR = dtbResult.Rows[0]["REGISTERID_CHR"].ToString().Trim();
                    p_objResult.m_strMAZUI_CHR = dtbResult.Rows[0]["MAZUI_CHR"].ToString().Trim();
                    p_objResult.m_fltPSTATUS_CHR = Convert.ToInt32(dtbResult.Rows[0]["PSTATUS_CHR"].ToString().Trim());
                    p_objResult.m_strDESC_VCHR = dtbResult.Rows[0]["DESC_VCHR"].ToString().Trim();
                }
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 增加
        /// <summary>
        /// 增加医嘱附加单据
        /// </summary>
        /// <param name="p_strRecordID">流水好	[out 参数]</param>
        /// <param name="p_objRecord">医嘱附加单据Vo对象</param>
        /// <returns></returns>
        public long m_lngAddNewTemfororder(out string p_strRecordID, clsT_Opr_Bih_Temfororder_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";

            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGenerateID(8, "ID_CHR", "T_opr_bih_temfororder", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO T_opr_bih_temfororder (PATIENTID_CHR,PATIENTNAME_CHR,REGISTERID_CHR,MAZUI_CHR,ID_CHR,PSTATUS_CHR,DESC_VCHR) VALUES (?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_objRecord.m_strPATIENTID_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strPATIENTNAME_CHR;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strREGISTERID_CHR;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strMAZUI_CHR;
                objLisAddItemRefArr[4].Value = p_strRecordID;
                objLisAddItemRefArr[5].Value = p_objRecord.m_fltPSTATUS_CHR;
                objLisAddItemRefArr[6].Value = p_objRecord.m_strDESC_VCHR;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 修改
        /// <summary>
        /// 修改医嘱附加单据
        /// </summary>
        /// <param name="p_objRecord">医嘱附加单据Vo</param>
        /// <returns></returns>
        public long m_lngModifyTemfororder(clsT_Opr_Bih_Temfororder_VO p_objRecord)
        {
            long lngRes = 0;

            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "";
            strSQL += " UPDATE T_OPR_BIH_TEMFORORDER A";
            strSQL += " SET";
            strSQL += "    A.PATIENTID_CHR ='" + p_objRecord.m_strPATIENTID_CHR.Trim() + "'";
            strSQL += "  , A.PATIENTNAME_CHR ='" + p_objRecord.m_strPATIENTNAME_CHR.Trim() + "'";
            strSQL += "  , A.REGISTERID_CHR ='" + p_objRecord.m_strREGISTERID_CHR.Trim() + "'";
            strSQL += "  , A.MAZUI_CHR = '" + p_objRecord.m_strMAZUI_CHR.Trim() + "'";
            strSQL += "  , A.PSTATUS_CHR = '" + p_objRecord.m_fltPSTATUS_CHR.ToString().Trim() + "'";
            strSQL += "  , A.DESC_VCHR = '" + p_objRecord.m_strDESC_VCHR.Trim() + "'";
            strSQL += " Where A.ID_CHR = '" + p_objRecord.m_strID_CHR.Trim() + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 删除
        /// <summary>
        /// 删除医嘱附加单据
        /// </summary>
        /// <param name="strID">医嘱附加单据ID</param>
        /// <returns></returns>
        public long m_lngDeleteTemfororder(string strID)
        {
            long lngRes = 0;
            string strSQL = "Delete T_OPR_BIH_TEMFORORDER where Trim(ID_CHR) = '" + strID.Trim() + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 提交
        /// <summary>
        /// 提交医嘱附加单据	根据附加单据ID
        /// </summary>
        /// <param name="strID">医嘱附加单据ID</param>
        /// <returns></returns>
        public long m_lngCommitTemfororder(string strID)
        {
            long lngRes = 0;
            string strSQL = "UPDATE T_OPR_BIH_TEMFORORDER A SET A.PSTATUS_CHR = '1' Where A.PSTATUS_CHR<>'1' and A.ID_CHR = '" + strID.Trim() + "'";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        /// <summary>
        /// 提交医嘱附加单据	[事务]	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 作为一个事物处理
        /// </remarks>
        public long m_lngCommitAttachOrder(string p_strOrderID)
        {
            long lngRes = 0;
            string[] strAttachIDArr;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objTem = new com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService();
            lngRes = objTem.m_lngGetAttachOrder(p_strOrderID, out strAttachIDArr);
            for (int i1 = 0; i1 < strAttachIDArr.Length; i1++)
            {
                if (lngRes > 0) lngRes = m_lngCommitTemfororder(strAttachIDArr[i1]);
            }
            if (lngRes <= 0)
            {
                throw (new System.Exception("附加单据提交失败！"));
            }
            return lngRes;
        }
        #endregion

        #region 获取医嘱-根据病区ID

        public long m_lngGetOrderByArea(string m_strAreaid_chr, int m_intState, out DataTable m_dtExecOrder, out DataTable m_dtPatients, out DataTable m_dtChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderByArea(m_strAreaid_chr, m_intState, out m_dtExecOrder, out m_dtPatients, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        public long m_lngGetOrderByArea(string m_strAreaid_chr, int m_intState, out DataTable m_dtExecOrder, out DataTable m_dtChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderByArea(m_strAreaid_chr, m_intState, out m_dtExecOrder, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        public long m_lngGetPatientInfoVo(string registerid_chr, out DataTable m_dtPatients)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetPatientInfoVo(registerid_chr, out  m_dtPatients);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngUpdateBihOrderConfirmer(List<EntityConfirmOrder> lstOrder, string CONFIRMERID_CHR, string CONFIRMER_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateBihOrderConfirmer(lstOrder, CONFIRMERID_CHR, CONFIRMER_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngUpdateBihOrderRedraw(ArrayList m_strORDERID_Arr, string RETRACTORID_CHR, string RETRACTOR_CHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateBihOrderRedraw(m_strORDERID_Arr, RETRACTORID_CHR, RETRACTOR_CHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngUpdateBihOrderBack(string m_strORDERID_Arr, string SENDBACKID_CHR, string SENDBACKER_CHR, string m_strBACKREASON)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateBihOrderBack(m_strORDERID_Arr, SENDBACKID_CHR, SENDBACKER_CHR, m_strBACKREASON);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 出院医嘱更新过嘱者
        /// </summary>
        /// <param name="m_strOrderID"></param>
        /// <param name="confirmerid"></param>
        /// <param name="confirmer"></param>
        /// <returns></returns>
        internal long m_lngUpdateLeaveConfiemer(string m_strOrderID, string confirmerid, string confirmer)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateLeaveConfiemer(m_strOrderID, confirmerid, confirmer);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #region 获取医嘱-根据病区ＩＤ

        public long m_lngGetExecOrderByArea(string m_strAreaid_chr, int m_intState, out DataTable m_dtExecOrder, out DataTable m_dtPatients, out DataTable m_dtChargeList, out DataTable m_dtChargeSum, out DataTable m_dtChargeMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetExecOrderByArea(m_strAreaid_chr, out m_dtExecOrder, out m_dtPatients, out m_dtChargeList, out  m_dtChargeSum, out  m_dtChargeMoney);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 获取需要进行确认记帐的数据

        public long m_lngGetComfirmChargeData(string m_strRegisterID, out DataTable m_dtOrderExecute, out DataTable m_dtChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetComfirmChargeData(m_strRegisterID, out  m_dtOrderExecute, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 获取医嘱-根据病区ＩＤ 及床位ID

        public long m_lngGetExecOrderByAreaBed(string m_strAreaid_chr, string m_strRegisterID, out DataTable m_dtExecOrder, out DataTable m_dtPatients, out DataTable m_dtChargeList, out DataTable m_dtChargeSum, out DataTable m_dtChargeMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetExecOrderByAreaBed(m_strAreaid_chr, m_strRegisterID, out m_dtExecOrder, out m_dtPatients, out m_dtChargeList, out  m_dtChargeSum, out  m_dtChargeMoney);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion


        //internal long m_lngUpdateBihOrderExecConfirmer(ArrayList m_strORDERID_Arr, string CONFIRMERID_CHR, string CONFIRMER_VCHR)
        //{
        //    long lngRes = 0;
        //    com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
        //    lngRes = objSvc.m_lngUpdateBihOrderExecConfirmer(m_strORDERID_Arr, CONFIRMERID_CHR, CONFIRMER_VCHR);
        //    objSvc.Dispose();
        //    objSvc = null;
        //    return lngRes;
        //}

        internal long m_lngGetPersonListByArea(string m_strAreaid_chr, out DataTable m_dtPatients)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetPersonListByArea(m_strAreaid_chr, out m_dtPatients);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 医嘱执行单待确认费用确认并发送
        /// </summary>
        /// <param name="m_strOrderExecuteID_Arr"></param>
        /// <param name="CONFIRMERID_CHR"></param>
        /// <param name="CONFIRMER_VCHR"></param>
        /// <returns></returns>
        internal long m_lngBihOrderExecuteChargeConfirmer(string m_strOrderExecuteID_Arr, string CONFIRMERID_CHR, string CONFIRMER_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngBihOrderExecuteChargeConfirmer(m_strOrderExecuteID_Arr, CONFIRMERID_CHR, CONFIRMER_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 医嘱执行单待确认费用作废
        /// </summary>
        /// <param name="m_strOrderExecuteID_Arr"></param>
        /// <param name="CONFIRMERID_CHR"></param>
        /// <param name="CONFIRMER_VCHR"></param>
        /// <returns></returns>
        internal long m_lngBihOrderExecuteDenableConfirmer(string m_strOrderExecuteID_Arr, string CONFIRMERID_CHR, string CONFIRMER_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngBihOrderExecuteDenableConfirmer(m_strOrderExecuteID_Arr, CONFIRMERID_CHR, CONFIRMER_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// /检查当前是否有还没有已确认是否需要费用审核 0-否 1-是的但已审核但还没有发送的医嘱申请单
        /// </summary>
        /// <param name="m_strCurrentRegisterID"></param>
        /// <param name="m_blhave"></param>
        /// <returns></returns>
        internal long m_lngCheckTheExecuteBill(string m_strCurrentRegisterID, out bool m_blhave)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngCheckTheExecuteBill(m_strCurrentRegisterID, out m_blhave);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        /// <summary>
        /// 新增或修改收费项目时重新提交收费数据
        /// </summary>
        /// <param name="p"></param>
        /// <param name="m_intState"></param>
        /// <param name="m_dtChargeList"></param>
        /// <returns></returns>
        internal long m_lngrefreshTheChargeDate(string m_strAreaid_chr, int m_intState, out DataTable m_dtChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngrefreshTheChargeDate(m_strAreaid_chr, m_intState, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetComfirmThChargeData(string m_strRegisterID, out DataTable m_dtOrderExecute, out DataTable m_dtChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetComfirmThChargeData(m_strRegisterID, out  m_dtOrderExecute, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        internal long m_lngCheckTheChanged(string m_strAreaid_chr, int m_intState, out DataTable m_dtExecOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngCheckTheChanged(m_strAreaid_chr, m_intState, out m_dtExecOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 生成医嘱执行预约表记录(检查申请单)
        /// </summary>
        /// <param name="m_OrderBookingVO">医嘱执行预约表</param>
        /// <returns></returns>
        internal long m_lngUpdateOrderBookingArr(clsOrderBooking[] m_OrderBookingVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateOrderBookingArr(objPrincipal, m_OrderBookingVO);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 整批生成申请单对应表(检查申请单)
        /// </summary>
        /// <param name="m_OrderBookingVO">生成申请单对应表</param>
        /// <returns></returns>
        internal long m_lngUpdateOrderAttachRelation(clsATTACHRELATION_VO[] m_arATTACHRELATION)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateOrderAttachRelation(objPrincipal, m_arATTACHRELATION);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_mthGetCheckByID2(string m_strOrderDicID, out bool isHave)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_mthGetCheckByID2(m_strOrderDicID, out isHave);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_mthGetApplyTypeByID(string m_strChargeITEMID_CHR, out DataTable dt)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_mthGetApplyTypeByID(m_strChargeITEMID_CHR, out  dt);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #region 获取医嘱-根据病区ＩＤ  多线程启动
        /// <summary>
        /// 通过病区ID，找出该病区需要执行的医嘱
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtExecOrder"></param>
        /// <returns></returns>
        public long m_lngGetExecOrderDTByArea(string m_strAreaid_chr, out DataTable m_dtExecOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetExecOrderDTByArea(m_strAreaid_chr, out m_dtExecOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 医嘱数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtExecOrder"></param>
        /// <returns></returns>
        public long m_lngGetExecOrderDTByAreaBed(string m_strAreaid_chr, string m_strRegisterID, out DataTable m_dtExecOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetExecOrderDTByAreaBed(m_strAreaid_chr, m_strRegisterID, out m_dtExecOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 病人数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtPatients"></param>
        /// <returns></returns>

        public long m_lngGetPatientDTByArea(string m_strAreaid_chr, out DataTable m_dtPatients)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetPatientDTByArea(m_strAreaid_chr, out m_dtPatients);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 病人数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtPatients"></param>
        /// <returns></returns>
        /// 根据上一个函数获得的没有重复病人流水号的病人号数组，获取病人相关信息，这些病人均有医嘱可能需要执行
        //原来正确的代码,需要保留 public long m_lngGetPatientDTByArea(ArrayList m_arrRegisterid_chr, out DataTable m_dtPatients)
        public long m_lngGetPatientDTByArea(System.Collections.Generic.List<string> m_glstRegisterid_chr, out DataTable m_dtPatients)
        {
            long lngRes = 0;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetPatientDTByArea(m_glstRegisterid_chr, out m_dtPatients);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }

        /// <summary>
        /// 病人数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtPatients"></param>
        /// <returns></returns>
        public long m_lngGetPatientDTByAreaBed(string m_strAreaid_chr, string m_strRegisterID, out DataTable m_dtPatients)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetPatientDTByAreaBed(m_strAreaid_chr, m_strRegisterID, out m_dtPatients);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 费用数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtChargeList"></param>
        /// <param name="m_dtChargeSum"></param>
        /// <param name="m_dtChargeMoney"></param>
        /// <returns></returns>
        public long m_lngGetChargeByArea(string m_strAreaid_chr, System.Collections.Generic.List<string> m_glstRegisterid_chr, out DataTable m_dtChargeList, out DataTable m_dtChargeMoney, out DataTable m_dtPrepay)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetChargeByArea(m_strAreaid_chr, m_glstRegisterid_chr, out m_dtChargeList, out  m_dtChargeMoney, out  m_dtPrepay);
            return lngRes;
        }

        /// <summary>
        /// 费用数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtChargeList"></param>
        /// <param name="m_dtChargeSum"></param>
        /// <param name="m_dtChargeMoney"></param>
        /// <returns></returns>
        //原来的正确代码,需要保留 public long m_lngGetChargeByRegisterids(ArrayList m_arrRegisterid_chr, out DataTable m_dtChargeMoney, out DataTable m_dtPrepay)
        public long m_lngGetChargeByRegisterids(System.Collections.Generic.List<string> m_glstRegisterid_chr, out DataTable m_dtChargeMoney, out DataTable m_dtPrepay)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetChargeByRegisterids(m_glstRegisterid_chr, out  m_dtChargeMoney, out  m_dtPrepay);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 费用数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtChargeList"></param>
        /// <param name="m_dtChargeSum"></param>
        /// <param name="m_dtChargeMoney"></param>
        /// <returns></returns>
        public long m_lngGetChargeByArea(string m_strAreaid_chr, out DataTable m_dtChargeList, out DataTable m_dtChargeMoney, out DataTable m_dtPrepay)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetChargeByArea(m_strAreaid_chr, out m_dtChargeList, out  m_dtChargeMoney, out  m_dtPrepay);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 费用数据
        /// </summary>
        /// <param name="m_strAreaid_chr"></param>
        /// <param name="m_dtChargeList"></param>
        /// <param name="m_dtChargeSum"></param>
        /// <param name="m_dtChargeMoney"></param>
        /// <returns></returns>
        public long m_lngGetChargeByAreaBed(string m_strAreaid_chr, string m_strRegisterID, out DataTable m_dtChargeList, out DataTable m_dtChargeMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetChargeByAreaBed(m_strAreaid_chr, m_strRegisterID, out m_dtChargeList, out  m_dtChargeMoney);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        internal long m_lngGetBihExecOrderControls(out decimal m_dmlMedOCMin, out decimal m_dmlNoMedOCMin, out decimal m_dmlMedICMin, out decimal m_dmlNoMedICMin, out int m_intMoneyControl)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetBihExecOrderControls(out  m_dmlMedOCMin, out  m_dmlNoMedOCMin, out  m_dmlMedICMin, out  m_dmlNoMedICMin, out  m_intMoneyControl);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 医嘱执行，生成执行单及插入收费明细
        /// </summary>
        /// <param name="m_arrExecOrder"></param>
        /// <param name="m_objCare">等级护理级别</param>
        /// <param name="m_objEat">饮食护理</param>
        /// <returns></returns>
        internal long m_lngUpdateBihOrderExecConfirmer(System.Collections.Generic.List<clsExecOrderVO> m_glstExecutablePhysicianOrderList, ArrayList glstNurseVO, List<EntityCureMed> lstCureMed, List<EntityCureSubStock> lstSubStock, out List<clsT_Bih_Opr_Putmeddetail_VO> lstPutMedCfkl, out string error)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngUpdateBihOrderExecConfirmer(m_glstExecutablePhysicianOrderList, glstNurseVO, lstCureMed, lstSubStock, out lstPutMedCfkl, out error);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long GetTheComfirmControl(out int m_intNeedConfirm, out int m_intExeConfirm)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.GetTheComfirmControl(out  m_intNeedConfirm, out  m_intExeConfirm);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngFindArea(string strFindCode, out clsBIHArea[] objItemArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInPatientQuerySvc));
            lngRes = objSvc.m_lngFindArea(strFindCode, out objItemArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        internal long m_lngGetBihBedByArea(string strAreaID, string strInputCode, out clsBIHBed[] arrBed)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsReport_d_bihSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsReport_d_bihSvc)
              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsReport_d_bihSvc));
            lngRes = objSvc.m_lngGetBihBedByArea(objPrincipal, strAreaID, strInputCode, out  arrBed);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;


        }

        internal long m_lngModifyOrderFeelEnd(clsT_Opr_Bih_OrderFeel_VO p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngModifyOrderFeelEnd(objPrincipal, p_objRecord);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngStopBihOrderConfirmer(ArrayList m_strORDERID_Arr, string CONFIRMERID_CHR, string CONFIRMER_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngStopBihOrderConfirmer(m_strORDERID_Arr, CONFIRMERID_CHR, CONFIRMER_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngExecDrawOrderByOrderID(ArrayList m_arrExecOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngExecDrawOrderByOrderID(m_arrExecOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderMessageByTimer(string m_strAreaid_chr, out DataTable m_dtExecOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetOrderMessageByTimer(m_strAreaid_chr, out m_dtExecOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /*原来的正确代码，需要保留
        internal long GetTheHisControl(ArrayList m_arrControl, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.GetTheHisControl(m_arrControl, out  dtbResult);
            return lngRes;
        }
        */
        //以下是新代码
        internal long GetTheHisControl(System.Collections.Generic.List<string> m_glstControl, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.GetTheHisControl(m_glstControl, out  dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        //以上是新代码
        internal long m_lngSaveTheEntrust(string m_strRegisterID, int m_intRecipenNo, string m_strEntrust)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngSaveTheEntrust(m_strRegisterID, m_intRecipenNo, m_strEntrust);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngSaveTheATTACHTIMES_INT(string m_strRegisterID, int m_intRecipenNo, int ATTACHTIMES_INT)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngSaveTheATTACHTIMES_INT(m_strRegisterID, m_intRecipenNo, ATTACHTIMES_INT);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        //查找医嘱执行表t_opr_bih_orderexecute里面记录的每条医嘱的已执行次数
        internal long m_lngGetReExecute(string m_strAreaid_chr, out DataTable m_dtReExecute)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetReExecute(m_strAreaid_chr, out m_dtReExecute);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long IsAllPatSend(string m_strAreaid_chr, out bool ifAll)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.IsAllPatSend(objPrincipal, m_strAreaid_chr, out ifAll);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long LoadThePARMVALUE(string PARMCODE_CHR, out string m_strPARMVALUE_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.LoadThePARMVALUE(PARMCODE_CHR, out  m_strPARMVALUE_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long LoadThePARMVALUE(ArrayList PARMCODE_CHR, out DataTable m_dtPARMVALUE_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.LoadThePARMVALUE(PARMCODE_CHR, out  m_dtPARMVALUE_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 直接材料的确认
        /// </summary>
        /// <param name="m_arrPCHARGEID_CHR"></param>
        /// <param name="p"></param>
        /// <param name="p_3"></param>
        /// <returns></returns>
        internal long m_lngBihOrderExecuteChargeConfirmerTh(ArrayList m_arrPCHARGEID_CHR, string CONFIRMERID_CHR, string CONFIRMER_VCHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngBihOrderExecuteChargeConfirmerTh(m_arrPCHARGEID_CHR, CONFIRMERID_CHR, CONFIRMER_VCHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        //原来的代码
        internal long m_lngConfirmCurrentOrder(string[] m_arrORDERID, out DataTable m_dtOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngConfirmCurrentOrder(m_arrORDERID, out  m_dtOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        public long m_lngGetOrderStopSign(string[] m_arrOrders, out DataTable m_dtOrderSign)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetOrderStopSign(m_arrOrders, out  m_dtOrderSign);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 获取活动标识号（m_arrREGISTERID_CHR，m_arrORDERID_CHR只能有一个数组数目>0）
        /// </summary>
        /// <param name="m_arrREGISTERID_CHR">病人流水号数组</param>
        /// <param name="m_arrORDERID_CHR">医嘱流水号数组</param>
        /// <param name="motion_id_int">本次操作标识</param>
        /// <returns></returns>
        public long m_lngGetMotionID(ArrayList m_arrREGISTERID_CHR, ArrayList m_arrORDERID_CHR, out long motion_id_int)
        {
            long lngRes = 0;
            motion_id_int = 0;
            if (m_arrREGISTERID_CHR == null)
            {
                m_arrREGISTERID_CHR = new ArrayList();
            }
            if (m_arrORDERID_CHR == null)
            {
                m_arrORDERID_CHR = new ArrayList();
            }
            if (m_arrREGISTERID_CHR.Count <= 0 && m_arrORDERID_CHR.Count <= 0)
            {
                return lngRes;
            }
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetMotionID(m_arrREGISTERID_CHR, m_arrORDERID_CHR, out motion_id_int);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderLisSign(string[] m_arrOrders, out DataTable m_dtOrderSign)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            lngRes = objSvc.m_lngGetOrderLisSign(m_arrOrders, out m_dtOrderSign);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #region 皮试费用的收取
        /// <summary>
        /// 皮试费用的收取
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <param name="strChargeItemID"></param>
        /// <param name="ExecuteType_Int"></param>
        /// <param name="CURAREAID_CHR"></param>
        /// <param name="CURBEDID_CHR"></param>
        /// <param name="CONFIRMERID_CHR"></param>
        /// <returns></returns>
        public long m_lngFeelCharge(string strOrderID, string strChargeItemID, int ExecuteType_Int, string CURAREAID_CHR, string CURBEDID_CHR, string CONFIRMERID_CHR)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngFeelCharge(strOrderID, strChargeItemID, ExecuteType_Int, CURAREAID_CHR, CURBEDID_CHR, CONFIRMERID_CHR);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 删除皮试费用
        /// </summary>
        /// <param name="strOrderID"></param>
        /// <returns></returns>
        public long m_lngDeleteFeelCharge(string strOrderID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngDeleteFeelCharge(strOrderID);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 检查申请对照表
        /// <summary>
        /// 检查申请对照表
        /// </summary>
        /// <param name="objTmp"></param>
        /// <returns></returns>
        internal long m_lngGetAPPLY_RLT(out System.Collections.Generic.Dictionary<string, string> objTmp)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
           (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            lngRes = objSvc.m_lngGetAPPLY_RLT(out objTmp);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 获取药品库存量
        /// <summary>
        /// 获取药品库存量
        /// </summary>
        /// <param name="p_dtnMedID">药品ID (药房ID,(药品ID))</param>
        /// <param name="p_dtnKCL">药品库存量(药房ID*药品ID,库存量)</param>

        /// <returns></returns>
        public long m_lngGetMedicineKC(System.Collections.Generic.Dictionary<string, List<string>> p_dtnMedID, out System.Collections.Generic.Dictionary<string, double> p_dtnKCL, out clsDsStorageVO[] p_objDsStorageVOArr)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            long lngRes = objSvc.m_lngGetMedicineKC(p_dtnMedID, out p_dtnKCL, out p_objDsStorageVOArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion
    }
    //T_opr_bih_temfororder(医嘱附加单据)临时用
    #region	T_opr_bih_temfororder(医嘱附加单据流水号)
    /// <summary>
    ///	clsT_Opr_Bih_Temfororder_VO(医嘱附加单据流水号)
    /// </summary>
    public class clsT_Opr_Bih_Temfororder_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        ///	流水号
        /// </summary>
        public string m_strID_CHR;
        /// <summary>
        ///	病人ID
        /// </summary>
        public string m_strPATIENTID_CHR;
        /// <summary>
        ///	病人姓名
        /// </summary>
        public string m_strPATIENTNAME_CHR;
        /// <summary>
        ///	入院登记流水号
        /// </summary>
        public string m_strREGISTERID_CHR;
        /// <summary>
        ///	麻醉方法
        /// </summary>
        public string m_strMAZUI_CHR;
        /// <summary>
        ///	状态标志{0=未发送;1=已发送;2=已经有结果了;}
        /// </summary>
        public float m_fltPSTATUS_CHR;
        /// <summary>
        ///	备注
        /// </summary>
        public string m_strDESC_VCHR;
    }
    #endregion
}
