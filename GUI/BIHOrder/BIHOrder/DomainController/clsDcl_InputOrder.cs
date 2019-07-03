using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 医嘱录入	逻辑控制层
    /// 作者： 徐斌辉
    /// 创建时间： 2004-12-23
    /// </summary>
    public class clsDcl_InputOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造函数
        public clsDcl_InputOrder()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        //获取名称
        #region 诊疗项目名
        /// <summary>
        /// 获取诊疗项目名	根据诊疗项目ID
        /// </summary>
        /// <param name="p_strID">诊疗项目ID</param>
        /// <returns></returns>
        public string m_strGetOrderdicNameByID(string p_strID)
        {
            clsT_bse_bih_orderdic_VO objReslut = new clsT_bse_bih_orderdic_VO();
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            long lngRes = objSvc.m_lngGetOrderdicByOrdericid(objPrincipal, p_strID, out objReslut);
            objSvc.Dispose();
            objSvc = null;
            if (lngRes > 0 && objReslut != null)
                return objReslut.m_strNAME_CHR;
            else
                return "";
        }
        #endregion
        #region 执行频率
        /// <summary>
        /// 获取执行频率	根据执行频率ID
        /// </summary>
        /// <param name="p_strID">执行频率ID</param>
        /// <returns></returns>
        public string m_strGetFreqNameByID(string p_strID)
        {
            clsT_aid_recipefreq_VO objReslut = new clsT_aid_recipefreq_VO();
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            long lngRes = objSvc.m_lngGetAidRecipefreqByID(objPrincipal, p_strID, out objReslut);
            objSvc.Dispose();
            objSvc = null;
            if (lngRes > 0 && objReslut != null)
                return objReslut.m_strFREQNAME_CHR;
            else
                return "";
        }
        #endregion
        #region 查询用药频率
        /// <summary>
        /// 查询用药频率
        /// </summary>
        /// <param name="p_strID">用药频率ID</param>
        /// <param name="p_objResult">用药频率对象</param>
        /// <returns></returns>
        public long m_lngGetAidRecipefreqByID(string p_strID, out clsT_aid_recipefreq_VO p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            lngRes = objSvc.m_lngGetAidRecipefreqByID(objPrincipal, p_strID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱类型
        /// <summary>
        /// 获取医嘱类型
        /// </summary>
        /// <param name="p_objResultArr">医嘱类型对象</param>
        /// <returns></returns>
        public long m_lngGetAidOrderCate(out clsT_aid_bih_ordercate_VO[] p_objResultArr)
        {
            p_objResultArr = new clsT_aid_bih_ordercate_VO[0];
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            long lngRes = objSvc.m_lngGetAidOrderCate(objPrincipal, "", out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 查询住院基本配置表VO

        internal long m_lngAddGetSPECORDERCATE(out clsSPECORDERCATE m_objSpecateVo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngAddGetSPECORDERCATE(out m_objSpecateVo);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region 查询当前医生是否有处方权

        internal long m_lngAddGetAccessPower(string m_strEmpID, out bool m_blAcess)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngAddGetAccessPower(m_strEmpID, out  m_blAcess);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region 用药方式
        /// <summary>
        /// 获取用药方式	根据用法ID
        /// </summary>
        /// <param name="p_strID">用法ID</param>
        /// <returns></returns>
        public string m_strGetUsageTypeNameByID(string p_strID)
        {
            clsBSEUsageType objReslut = new clsBSEUsageType();
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            long lngRes = objSvc.m_lngGetUsageTypeByID(objPrincipal, p_strID, out objReslut);
            objSvc.Dispose();
            objSvc = null;
            if (lngRes > 0 && objReslut != null)
                return objReslut.m_strUsageName;
            else
                return "";
        }
        #endregion
        #region 获取用药方式
        /// <summary>
        /// 获取用药方式对象
        /// </summary>
        /// <param name="p_strFindString">查询字符串</param>
        /// <param name="p_objResultArr">用药方式对象</param>
        /// <returns></returns>
        public long m_lngGetUsageType(string p_strFindString, out clsBSEUsageType[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetUsageType(p_strFindString, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 重整医嘱相关
        //获取医嘱
        /// <summary>
        /// 获取可以重整的医嘱	根据入院登记ID	
        /// 包括:	
        ///		1、状态为3-停止;6-审核停止的长期医嘱;
        ///		2、执行状态的临时医嘱
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetCanReformingOrder(string p_strRegisterID, out clsBIHOrder[] p_objResultArr )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetCanReformingOrder(objPrincipal, p_strRegisterID, out p_objResultArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 重整
        /// </summary>
        /// <param name="p_objItem">医嘱对象</param>
        /// <param name="p_strDoctorID">操作医生ID</param>
        /// <param name="p_strDoctorName">操作医生名称</param>
        /// <param name="p_blnInfectSon">是否重整子医嘱</param>
        /// <returns></returns>
        public long m_lngRetractOrder(clsBIHOrder p_objItem, string p_strDoctorID, string p_strDoctorName, bool p_blnInfectSon, bool isChildPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngRetractOrder(p_objItem, p_strDoctorID, p_strDoctorName, p_blnInfectSon, isChildPrice);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="p_objItem">医嘱对象</param>
        /// <param name="p_strDoctorID">操作医生ID</param>
        /// <param name="p_strDoctorName">操作医生名称</param>
        /// <param name="p_blnInfectSon">是否停止子医嘱</param>
        /// <returns></returns>
        public long m_lngStopOrder(clsBIHOrder p_objItem, string p_strDoctorID, string p_strDoctorName, bool p_blnInfectSon, bool isChildPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngStopOrder(p_objItem, p_strDoctorID, p_strDoctorName, p_blnInfectSon, DateTime.MinValue, isChildPrice);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取可停止的医嘱
        //获取医嘱
        /// <summary>
        /// 获取可以停止的医嘱	根据入院登记ID	
        /// 业务说明:	只能停止执行状态的长期医嘱
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResultArr">[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetCanStopOrder(string p_strRegisterID, out clsBIHOrder[] p_objResultArr )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetCanStopOrder(objPrincipal, p_strRegisterID, out p_objResultArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
 
        #region 修改医嘱
        /// <summary>
        /// 医生修改未提交医嘱的内容
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        public long m_lngModifyOrder(clsBIHOrder objOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngModifyOrder(objOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 将当前医嘱置为新开医嘱的修改(主要针对修改方号及父医嘱标志置为空 -- 该方法不再使用20180403
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        public long m_lngModifyNewRecipenNoOrder(clsBIHOrder objOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngModifyNewRecipenNoOrder(objOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 医生修改未提交医嘱的内容	带有子医嘱，子医嘱只更改频率和用法
        /// 注意：这里是个事务
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        public long m_lngModifyOrderWithSon(clsBIHOrder objOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            try
            {
                lngRes = objSvc.m_lngModifyOrderWithSon(objOrder);
                objSvc.Dispose();
                objSvc = null;
            }
            catch { }
            return lngRes;
        }

        #endregion
        /// <summary>
        /// 获取医保信息	根据诊疗项目ID
        /// </summary>
        /// <param name="p_strOrderdicID">诊疗项目ID</param>
        /// <param name="p_dtbResult">[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetMedicareByOrderdicID(string p_strOrderdicID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetMedicareByOrderdicID(objPrincipal, p_strOrderdicID, out p_dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 获取医保信息	根据诊疗项目编码
        /// </summary>
        /// <param name="p_strUserCode">诊疗项目编码</param>
        /// <param name="p_dtbResult">[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetMedicareByUserCode(string p_strUserCode, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetMedicareByUserCode(objPrincipal, p_strUserCode, out p_dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /** @add by xzf (05-09-21 */
        /// <summary>
        /// 获取用户编码,根据诊疗项目id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string getOrderDicUserCodeById(string id)
        {
            string userCode = "";
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            userCode = objSvc.getOrderDicUserCodeById(id);
            objSvc.Dispose();
            objSvc = null;
            return userCode;

        }
        //收费
        #region 非主收费项目计费
        /// <summary>
        /// 计算非主收费项目费用
        /// </summary>
        /// <param name="p_objRecipeFreq">用药频率辅助表对象</param>
        /// <param name="p_objOrderdicCharge">诊疗项目|收费项目对象</param>
        /// <param name="p_dmlGet">单位频率天数的领量	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public decimal m_dmlGetChargeNotMainItem(string p_strFreqID, clsT_aid_bih_orderdic_charge_VO p_objOrderdicCharge)
        {
            decimal dmlGet = 0;
            clsT_aid_recipefreq_VO objItem = new clsT_aid_recipefreq_VO();
            long lngRes = m_lngGetAidRecipefreqByID(p_strFreqID, out objItem);
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            lngRes = objSvc.m_lngGetChargeNotMainItem(objItem, p_objOrderdicCharge, out dmlGet);
            objSvc.Dispose();
            objSvc = null;
            return dmlGet;
        }
        /// <summary>
        /// 计算非主收费项目费用
        /// </summary>
        /// <param name="p_objRecipeFreq">用药频率辅助表对象</param>
        /// <param name="p_objOrderdicCharge">诊疗项目|收费项目对象</param>
        /// <param name="p_dmlGet">单位频率天数的领量	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public decimal m_dmlGetChargeNotMainItem(clsT_aid_recipefreq_VO p_objRecipeFreq, clsT_aid_bih_orderdic_charge_VO p_objOrderdicCharge)
        {
            decimal dmlGet = 0;
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            long lngRes = objSvc.m_lngGetChargeNotMainItem(p_objRecipeFreq, p_objOrderdicCharge, out dmlGet);
            objSvc.Dispose();
            objSvc = null;
            return dmlGet;
        }
        /// <summary>
        /// 计算非主收费项目费用
        /// </summary>
        /// <param name="p_intTIMES">周期用药次数</param>
        /// <param name="p_objOrderdicCharge">诊疗项目|收费项目对象</param>
        /// <param name="p_dmlGet">单位频率天数的领量	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public decimal m_lngGetChargeNotMainItem(int p_intTIMES, clsT_aid_bih_orderdic_charge_VO p_objOrderdicCharge)
        {
            decimal dmlGet = 0;
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            long lngRes = objSvc.m_lngGetChargeNotMainItem(p_intTIMES, p_objOrderdicCharge, out dmlGet);
            objSvc.Dispose();
            objSvc = null;
            return dmlGet;
        }
        /// <summary>
        /// 计算非主收费项目费用
        /// </summary>
        /// <param name="p_intTIMES">周期用药次数</param>
        /// <param name="m_intQTY">用量</param>
        /// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
        /// <param name="p_dmlDosage">医生下的剂量</param>
        /// <param name="p_dmlUnitDosage">剂量单位</param>
        /// <param name="p_dmlGet">单位频率天数的领量	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=算法如算主收费项目；}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public decimal m_lngGetChargeNotMainItem(int p_intTIMES, int p_intQTY, int p_intType, decimal p_dmlDosage, decimal p_dmlUnitDosage)
        {
            decimal dmlGet = 0;
            com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            long lngRes = objSvc.m_lngGetChargeNotMainItem(p_intTIMES, p_intQTY, p_intType, p_dmlDosage, p_dmlUnitDosage, out dmlGet);
            objSvc.Dispose();
            objSvc = null;
            return dmlGet;
        }
        #endregion
        #region 住院用法单位频率天数的领量
        /// <summary>
        /// 获取住院用法单位频率天数的领量
        /// </summary>
        /// <param name="p_intTIMES">周期用药次数</param>
        /// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
        /// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
        /// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public double m_dblGetMeasureBIHUsage(int p_intTIMES, double p_dblQTY, int p_intType, double p_dblUnitDosage)
        {
            double dblGet = 0;
            long lngRes = m_lngGetMeasureBIHUsage(p_intTIMES, p_dblQTY, p_intType, p_dblUnitDosage, out dblGet);
            return dblGet;
        }
        /// <summary>
        /// 获取住院用法单位频率天数的领量
        /// </summary>
        /// <param name="p_intTIMES">周期用药次数</param>
        /// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
        /// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
        /// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
        /// <param name="p_dblGet">单位频率天数的领量	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public long m_lngGetMeasureBIHUsage(int p_intTIMES, double p_dblQTY, int p_intType, double p_dblUnitDosage, out double p_dblGet)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc objSvc =(com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc));
            //lngRes = objSvc.m_lngGetMeasureBIHUsage(objPrincipal,p_intTIMES,p_dblQTY,p_intType,p_dblUnitDosage,out p_dblGet);
            p_dblGet = 0;
            if (p_intType == 2)//剂量单位
            {
                double dblUse = p_dblQTY / p_dblUnitDosage;
                p_dblGet = dblUse * p_intTIMES;	//用量*次数
            }
            else if (p_intType == 1)//领量单位
            {
                p_dblGet = p_dblQTY * p_intTIMES;
            }
            return lngRes;
        }
        #endregion
        #region 住院用法收费
        /// <summary>
        /// 获取住院用法收费
        /// </summary>
        /// <param name="strITEMID_CHR">收费项目ID</param>
        /// <param name="strUSAGEID_CHR">用法ID</param>
        /// <returns></returns>
        public double m_dblGetChargeBIHUsage(string strITEMID_CHR, string strUSAGEID_CHR)
        {
            double dblMoney = 0;
            long lngRes = m_lngGetChargeBIHUsage(strITEMID_CHR, strUSAGEID_CHR, out dblMoney);
            return dblMoney;
        }
        /// <summary>
        /// 获取住院用法收费
        /// </summary>
        /// <param name="p_dblPrice">价格</param>
        /// <param name="p_intTIMES">周期用药次数</param>
        /// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
        /// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
        /// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public double m_dblGetChargeBIHUsage(double p_dblPrice, int p_intTIMES, double p_dblQTY, int p_intType, double p_dblUnitDosage)
        {
            double dblMoney = 0;
            long lngRes = m_lngGetChargeBIHUsage(p_dblPrice, p_intTIMES, p_dblQTY, p_intType, p_dblUnitDosage, out dblMoney);
            return dblMoney;
        }
        /// <summary>
        /// 获取住院用法收费
        /// </summary>
        /// <param name="p_dblPrice">价格</param>
        /// <param name="p_intTIMES">周期用药次数</param>
        /// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
        /// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
        /// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
        /// <param name="p_dblMoney">单位频率天数总价	[out 参数]</param>
        /// <returns></returns>
        /// <remarks>
        /// 业务描述：
        ///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
        ///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
        /// 业务描述：[领量、用量、频率]
        ///		领量 = 用量 * 周期用药次数
        ///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
        /// </remarks>
        public long m_lngGetChargeBIHUsage(double p_dblPrice, int p_intTIMES, double p_dblQTY, int p_intType, double p_dblUnitDosage, out double p_dblMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc objSvc = (com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc));
            lngRes = objSvc.m_lngGetChargeBIHUsage(objPrincipal, p_dblPrice, p_intTIMES, p_dblQTY, p_intType, p_dblUnitDosage, out p_dblMoney);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        /// <summary>
        /// 获取住院用法收费
        /// </summary>
        /// <param name="strITEMID_CHR">收费项目ID</param>
        /// <param name="strUSAGEID_CHR">用法ID</param>
        /// <param name="p_dblMoney">收费	[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetChargeBIHUsage(string strITEMID_CHR, string strUSAGEID_CHR, out double p_dblMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc objSvc = (com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAccountCharge_Svc));
            lngRes = objSvc.m_lngGetChargeBIHUsage(objPrincipal, strITEMID_CHR, strUSAGEID_CHR, out p_dblMoney);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取用法对应的项目
        /// <summary>
        /// 获取用法对应的项目	根据用法ID
        /// </summary>
        /// <param name="p_strUsageID">用法ID</param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_GetItemByUsageID(string p_strOrderID, out clsChargeItem_VO[] p_objResultArr )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderChangeService));
            lngRes = objSvc.m_GetItemByUsageID(objPrincipal, p_strOrderID, out p_objResultArr );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 住院收费
        /// <summary>
        /// 显示费用信息	{药品费用、用法费用}
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_intIsSonOrder">是否子级医嘱	{0=非子级医嘱;1=子级医嘱}</param>
        /// <param name="p_dblDraw">主收费项目的领量</param>
        /// <param name="p_strFreqID">执行频率ID</param>
        /// <param name="p_strUsageID">用法ID</param>
        /// <param name="p_objResultArr">[out 参数] 费用描述对象</param>
        /// <returns></returns>
        public long m_lngGetBIHCharge(string p_strOrderID, int p_intIsSonOrder, double p_dblDraw, string p_strFreqID, string p_strUsageID, out clsChargeForDisplay[] p_objResultArr, bool isChildPrice)
        {
            long lngRes = 0;
            p_objResultArr = new clsChargeForDisplay[0];
            ArrayList alItem = new ArrayList();
            clsChargeForDisplay objItem;

            //是否连续性医嘱
            bool blnIsConOrder = false;
            string strConfreqID = new clsDcl_ExecuteOrder().m_strGetConfreqID();
            if (strConfreqID.Trim() == p_strFreqID) blnIsConOrder = true;

            //获取用药频率对象
            clsT_aid_recipefreq_VO objRecipeFreq = new clsT_aid_recipefreq_VO();
            lngRes = m_lngGetAidRecipefreqByID(p_strFreqID, out objRecipeFreq);
            if (lngRes <= 0) return 0;

            //获取诊疗项目-收费项目对象	{自费|嘱托的医嘱不收药品费用}
            clsBIHOrder objBIHOrder;
            lngRes = m_lngGetOrderByOrderID(p_strOrderID, out objBIHOrder );
            if (lngRes > 0 && objBIHOrder != null && objBIHOrder.RateType != 1 /* && objBIHOrder.m_intRateType != 2*/)
            {
                clsT_aid_bih_orderdic_charge_VO[] objMedicineItemArr;
                lngRes = new clsDcl_CommitOrder().m_lngGetOrderdicChargeByOrderID(p_strOrderID, out objMedicineItemArr );
                #region 药品费用
                if (lngRes > 0 && objMedicineItemArr != null && objMedicineItemArr.Length > 0)
                {
                    for (int i1 = 0; i1 < objMedicineItemArr.Length; i1++)
                    {
                        objItem = new clsChargeForDisplay();
                        objItem.m_strChargeID = objMedicineItemArr[i1].m_strITEMID_CHR;
                        //收费项目名称
                        objItem.m_strName = objMedicineItemArr[i1].m_strItemName;
                        double dblNum = 0;
                        if (objMedicineItemArr[i1].m_objChargeItem.m_strITEMID_CHR.Trim() == objMedicineItemArr[i1].m_strChiefItemID.Trim())//是否主收费项目
                        {
                            dblNum = p_dblDraw;
                            //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                            objItem.m_intType = 2;
                        }
                        else
                        {
                            dblNum = System.Convert.ToDouble(m_dmlGetChargeNotMainItem(objRecipeFreq, objMedicineItemArr[i1]));
                            //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                            objItem.m_intType = 1;
                        }
                        //单价
                        objItem.m_dblPrice = objMedicineItemArr[i1].m_objChargeItem.m_dblMinPrice;
                        //   修改单价及领量来源

                        objItem.m_dblPrice = (double)objMedicineItemArr[i1].m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec;
                        dblNum = (double)objMedicineItemArr[i1].m_objORDERCHARGEDEPT_VO.m_decAmount_dec;
                        /*<---------------------------------*/
                        //领量
                        objItem.m_dblDrawAmount = dblNum;

                        //合计金额
                        objItem.m_dblMoney = objMedicineItemArr[i1].m_objChargeItem.m_dblMinPrice * dblNum;
                        //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                        objItem.m_intCONTINUEUSETYPE_INT = -1;
                        //是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
                        objItem.m_intIsContinueOrder = (blnIsConOrder) ? (1) : (0);
                        //是否缺药
                        objItem.m_strNoqtyFLag = objMedicineItemArr[i1].m_strNoqtyFLag;
                        // 加上科室名称
                        objItem.m_strClacarea_chr = objMedicineItemArr[i1].m_objChargeItem.m_strITEMPYCODE_CHR;
                        objItem.m_strClacareaName_chr = objMedicineItemArr[i1].m_objChargeItem.m_strITEMWBCODE_CHR;
                        //暂存住院诊疗项目收费项目执行客户表的流水号
                        objItem.m_strSeq_int = objMedicineItemArr[i1].m_strOCMAPID_CHR;

                        // 住院诊疗项目收费项目执行客户表VO
                        objItem.m_objORDERCHARGEDEPT_VO = objMedicineItemArr[i1].m_objORDERCHARGEDEPT_VO;

                        alItem.Add(objItem);
                    }
                }
                #endregion
            }

            //获取用法对应的项目对象
            if (p_intIsSonOrder != 1 && p_strUsageID != null && p_strUsageID.Trim() != "")
            {
                clsChargeItem_VO[] objUsageResultArr;
                //lngRes =m_GetItemByUsageID(p_strUsageID,out objUsageResultArr);
                lngRes = m_GetItemByUsageID(p_strOrderID, out objUsageResultArr );

                #region 用法费用
                if (lngRes > 0 && objUsageResultArr != null && objUsageResultArr.Length > 0)
                {
                    for (int i1 = 0; i1 < objUsageResultArr.Length; i1++)
                    {
                        objItem = new clsChargeForDisplay();
                        objItem.m_strChargeID = objUsageResultArr[i1].m_strItemID;
                        //收费项目名称
                        objItem.m_strName = objUsageResultArr[i1].m_strItemName;
                        //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                        objItem.m_intType = 3;
                        //单价 decode(a.IPCHARGEFLG_INT,1,Round(a.ItemPrice_Mny/a.PackQty_Dec,4),0,a.ItemPrice_Mny,Round(a.ItemPrice_Mny/a.PackQty_Dec,4)) MinPrice
                        double dblPrice = 0;
                        try
                        {
                            //住院收费单位 0 －基本单位 1－最小单位
                            if (objUsageResultArr[i1].m_intOPCHARGEFLG_INT == 0)//门诊收费单位 0 －基本单位 1－最小单位
                                dblPrice = double.Parse(objUsageResultArr[i1].m_fltItemPrice.ToString());
                            else
                            {
                                double dblItemPrice = double.Parse(objUsageResultArr[i1].m_fltItemPrice.ToString());
                                double dblPACKQTY_DEC = double.Parse(objUsageResultArr[i1].m_decPACKQTY_DEC.ToString());
                                dblPrice = double.Parse((dblItemPrice / dblPACKQTY_DEC).ToString("0.0000"));
                            }
                        }
                        catch { }
                        objItem.m_dblPrice = dblPrice;
                        //医生下的剂量
                        double dblDosage = 0;
                        try
                        {
                            dblDosage = double.Parse(objUsageResultArr[i1].m_strDosage.ToString());
                        }
                        catch { }
                        //领量					
                        double dblNum = 0;
                        dblNum = m_dblGetMeasureBIHUsage(objRecipeFreq.m_intTIMES_INT, objUsageResultArr[i1].m_dblBIHQTY_DEC, objUsageResultArr[i1].m_intBIHTYPE_INT, dblDosage);
                        // 修改单价及领量来源

                        objItem.m_dblPrice = (double)objUsageResultArr[i1].m_objORDERCHARGEDEPT_VO.m_decUnitprice_dec;
                        dblNum = (double)objUsageResultArr[i1].m_objORDERCHARGEDEPT_VO.m_decAmount_dec;
                        /*<---------------------------------*/
                        objItem.m_dblDrawAmount = dblNum;
                        //合计金额
                        objItem.m_dblMoney = dblPrice * dblNum;
                        //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                        objItem.m_intCONTINUEUSETYPE_INT = objUsageResultArr[i1].m_intCONTINUEUSETYPE_INT;
                        //是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
                        objItem.m_intIsContinueOrder = (blnIsConOrder) ? (1) : (0);
                        // 加上科室名称
                        objItem.m_strClacarea_chr = objUsageResultArr[i1].m_strItemPYCode;
                        objItem.m_strClacareaName_chr = objUsageResultArr[i1].m_strItemWBCode;
                        /*<----------------------------*/
                        //暂存住院诊疗项目收费项目执行客户表的流水号
                        objItem.m_strSeq_int = objUsageResultArr[i1].m_strItemCode;
                        // 住院诊疗项目收费项目执行客户表VO
                        objItem.m_objORDERCHARGEDEPT_VO = objUsageResultArr[i1].m_objORDERCHARGEDEPT_VO;
                        alItem.Add(objItem);
                    }
                }
                #endregion
            }
            p_objResultArr = (clsChargeForDisplay[])(alItem.ToArray(typeof(clsChargeForDisplay)));
            return lngRes;
        }
        #endregion

        #region 医嘱收费信息(来源于T_OPR_BIH_ORDERCHARGEDEPT住院诊疗项目收费项目执行客户表)

        public long m_lngGetBIHChargeFromDEPT(string m_strOrderid_chr, out DataTable m_dtChargeList)
        {
            long lngRes;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetBIHChargeFromDEPT(m_strOrderid_chr, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 显示费用信息
        /// <summary>
        /// 显示费用信息	{药品费用、用法费用}
        /// </summary>
        /// <param name="objItemArr">费用描述对象</param>
        /// <param name="p_dgDataGrid"></param>
        public void DisplayCharge(clsChargeForDisplay[] objItemArr, com.digitalwave.controls.datagrid.ctlDataGrid p_dgDataGrid)
        {
            ////药品费用颜色
            //System.Drawing.Color clMedicineBackColor =System.Drawing.SystemColors.Window;
            //System.Drawing.Color clMedicineForeColor =System.Drawing.SystemColors.WindowText;
            ////用法费用颜色
            //System.Drawing.Color clUsageBackColor =System.Drawing.Color.LightGreen;
            //System.Drawing.Color clUsageForeColor =System.Drawing.SystemColors.WindowText;

            p_dgDataGrid.BeginUpdate();
            p_dgDataGrid.m_mthDeleteAllRow();
            p_dgDataGrid.m_mthFormatReset();

            if (objItemArr != null && objItemArr.Length > 0)
            {
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    DataRow objRow = p_dgDataGrid.NewRow();
                    //序号
                    objRow[0] = (i1 + 1).ToString();
                    //收费项目名称
                    objRow[1] = objItemArr[i1].m_strName;
                    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                    switch (objItemArr[i1].m_intType)
                    {
                        case 1:
                            objRow[2] = "辅助收费";
                            break;
                        case 2:
                            objRow[2] = "主收费";
                            break;
                        case 3:
                            objRow[2] = "用法收费";
                            break;
                        default:
                            objRow[2] = "";
                            break;
                    }
                    //单价		
                    if (!double.IsInfinity(objItemArr[i1].m_dblPrice))
                        objRow[3] = objItemArr[i1].m_dblPrice.ToString("0.0000");
                    else
                        objRow[3] = "0.0000";
                    if (objItemArr[i1].m_intIsContinueOrder == 1 && objItemArr[i1].m_intType != 3)
                    {
                        //领量					
                        objRow[4] = "-";
                        //合计金额
                        objRow[5] = "-";
                    }
                    else
                    {
                        //领量					
                        objRow[4] = objItemArr[i1].m_dblDrawAmount.ToString();
                        //合计金额
                        if (!double.IsInfinity(objItemArr[i1].m_dblMoney))
                            objRow[5] = objItemArr[i1].m_dblMoney.ToString("0.00");
                        else
                            objRow[5] = "0.00";
                    }
                    //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                    switch (objItemArr[i1].m_intCONTINUEUSETYPE_INT)
                    {
                        case -1:
                            objRow[6] = "-";
                            break;
                        case 0:
                            objRow[6] = "不续用";
                            break;
                        case 1:
                            objRow[6] = "全部续用";
                            break;
                        case 2:
                            objRow[6] = "长嘱续用";
                            break;
                        default:
                            objRow[6] = "";
                            break;
                    }
                    // 增加执行科室
                    objRow[7] = objItemArr[i1].m_strClacareaName_chr;
                    /*<---------------------------*/
                    //暂存住院诊疗项目收费项目执行客户表的流水号
                    objRow["seq_int"] = objItemArr[i1].m_strSeq_int;
                    /*<------------------------------------*/
                    // 收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                    objRow["m_intType"] = objItemArr[i1].m_intType.ToString();
                    /*<---------------------------*/
                    p_dgDataGrid.m_mthAppendRow(objRow);
                    //填充颜色
                    #region 填充颜色
                    switch (objItemArr[i1].m_intType)//{1=普通药品收费；2=主收费；3=用法收费}
                    {
                        case 1:
                            //for(int intCol=0;intCol<p_dgDataGrid.Columns.Count;intCol++)
                            //{
                            //	p_dgDataGrid.m_mthFormatCell(p_dgDataGrid.RowCount-1,intCol,p_dgDataGrid.Font,clMedicineBackColor,clMedicineForeColor);
                            //}
                            break;
                        case 2:
                            //for(int intCol=0;intCol<p_dgDataGrid.Columns.Count;intCol++)
                            //{
                            //	p_dgDataGrid.m_mthFormatCell(p_dgDataGrid.RowCount-1,intCol,p_dgDataGrid.Font,clMedicineBackColor,clMedicineForeColor);
                            //}
                            break;
                        case 3:
                            //for(int intCol=0;intCol<p_dgDataGrid.Columns.Count;intCol++)
                            //{
                            //	p_dgDataGrid.m_mthFormatCell(p_dgDataGrid.RowCount-1,intCol,p_dgDataGrid.Font,clUsageBackColor,clUsageForeColor);
                            //}
                            break;
                    }
                    #endregion
                }
            }
            p_dgDataGrid.EndUpdate();
        }
        /// <summary>
        /// 显示费用信息	{药品费用、用法费用}
        /// </summary>
        /// <param name="objItemArr">费用描述对象</param>
        /// <param name="p_dgDataGrid"></param>
        public void DisplayCharge(clsChargeForDisplay[] objItemArr, ListView p_lsvListView)
        {
            //药品费用颜色
            System.Drawing.Color clMedicineBackColor = System.Drawing.SystemColors.Window;
            System.Drawing.Color clMedicineForeColor = System.Drawing.SystemColors.WindowText;
            //用法费用颜色
            System.Drawing.Color clUsageBackColor = System.Drawing.Color.LightGreen;
            System.Drawing.Color clUsageForeColor = System.Drawing.SystemColors.WindowText;
            p_lsvListView.Items.Clear();

            if (objItemArr != null && objItemArr.Length > 0)
            {
                ListViewItem lviTemp = null;
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    //序号
                    lviTemp = new ListViewItem((i1 + 1).ToString());
                    //收费项目编码
                    lviTemp.SubItems.Add(objItemArr[i1].m_strITEMCODE_VCHR);
                    //收费项目名称
                    lviTemp.SubItems.Add(objItemArr[i1].m_strName);
                    //收费类别	{1=普通药品收费；2=主收费；3=用法收费}
                    switch (objItemArr[i1].m_intType)
                    {
                        case 0:
                            lviTemp.SubItems.Add("主项目");
                            break;
                        case 1:
                            lviTemp.SubItems.Add("辅助项目");
                            break;
                        case 2:
                            lviTemp.SubItems.Add("用法带出");
                            break;
                        case 3:
                            lviTemp.SubItems.Add("补充录入项目");
                            break;
                        default:
                            lviTemp.SubItems.Add("");
                            break;
                    }
                    //单价			
                    if (!double.IsInfinity(objItemArr[i1].m_dblPrice))
                        lviTemp.SubItems.Add(objItemArr[i1].m_dblPrice.ToString("0.00"));
                    else
                        lviTemp.SubItems.Add("0.00");
                    //if(objItemArr[i1].m_intIsContinueOrder==1 && objItemArr[i1].m_intType!=3)
                    //{
                    //    //领量					
                    //    lviTemp.SubItems.Add("-");
                    //    //合计金额
                    //    lviTemp.SubItems.Add("-");
                    //}
                    //else
                    //{
                    //    //领量					
                    //    lviTemp.SubItems.Add(objItemArr[i1].m_dblDrawAmount.ToString());
                    //    //合计金额
                    //    if(!double.IsInfinity(objItemArr[i1].m_dblMoney))
                    //        lviTemp.SubItems.Add(objItemArr[i1].m_dblMoney.ToString("0.00"));
                    //    else
                    //        lviTemp.SubItems.Add("0.00");
                    //}
                    //领量					
                    lviTemp.SubItems.Add(objItemArr[i1].m_dblDrawAmount.ToString() + "(" + objItemArr[i1].m_strUNIT_VCHR + ")");
                    //合计金额
                    if (!double.IsInfinity(objItemArr[i1].m_dblMoney))
                        lviTemp.SubItems.Add(objItemArr[i1].m_dblMoney.ToString("0.00"));
                    else
                        lviTemp.SubItems.Add("0.00");
                    //续用类型 {-1=非用法收费（药品收费等）;0=不续用;1=全部续用;2-长嘱续用}
                    //switch(objItemArr[i1].m_intCONTINUEUSETYPE_INT)
                    //{
                    //    case -1:
                    //        lviTemp.SubItems.Add("-");
                    //        break;
                    //    case 0:
                    //        lviTemp.SubItems.Add("不续用");
                    //        break;
                    //    case 1:
                    //        lviTemp.SubItems.Add("全部续用");
                    //        break;
                    //    case 2:
                    //        lviTemp.SubItems.Add("长嘱续用");
                    //        break;
                    //    default:
                    //        lviTemp.SubItems.Add("");
                    //        break;
                    //}
                    switch (objItemArr[i1].m_intCONTINUEUSETYPE_INT)
                    {
                        case 1:
                            lviTemp.SubItems.Add("  首次用　");
                            break;
                        case 0:
                            lviTemp.SubItems.Add("  连续用　");
                            break;
                        default:
                            lviTemp.SubItems.Add(" -- ");
                            break;
                    }
                    // 增加执行科室
                    lviTemp.SubItems.Add(objItemArr[i1].m_strClacareaName_chr);

                    lviTemp.SubItems.Add(objItemArr[i1].m_strYBClass);
                    lviTemp.Tag = objItemArr[i1];
                    #region 填充颜色
                    switch (objItemArr[i1].m_intType)//{1=普通药品收费；2=主收费；3=用法收费}
                    {
                        case 1:
                            //lviTemp.BackColor =clMedicineBackColor;
                            //lviTemp.ForeColor =clMedicineForeColor;
                            break;
                        case 2:
                            //lviTemp.BackColor =clMedicineBackColor;
                            //lviTemp.ForeColor =clMedicineForeColor;
                            break;
                        case 3:
                            //lviTemp.BackColor =clUsageBackColor;
                            //lviTemp.ForeColor =clUsageForeColor;
                            break;
                    }
                    #endregion

                    #region 突出显示缺药项目	glzhang	2005.10.14
                    if (objItemArr[i1].m_strNoqtyFLag == "1")
                    {
                        lviTemp.ForeColor = System.Drawing.Color.Red;
                        lviTemp.SubItems.Add("缺药");
                    }
                    #endregion

                    p_lsvListView.Items.Add(lviTemp);
                    //填充颜色
                }
            }
        }
        #endregion
        #region 获取连续性领量
        /// <summary>
        /// 获取连续性领量
        /// 业务说明：	计费(领量单位:小时):
        ///				a.第一天计费,领量 = 开始时间 -- {滚费时间};
        ///				b.期间计费,领量 = {上一次滚费时间} -- {滚费时间)	(时间:在滚费时);
        ///				c.停止计费,领量 = {上一次滚费时间} -- {停止时间}	(时间:在审核停止时)
        ///				滚费时刻：	23:59:59
        /// </summary>
        /// <param name="p_strOrderID"></param>
        /// <param name="p_dtStartTime">开始时刻</param>
        /// <param name="p_dtBalanceTime">结算时刻</param>
        /// <param name="p_intReturnType">返回类型{1=分钟;2小时;默认为小时}</param>
        /// <returns>返回领量数据</returns>
        public int m_intGetMeasureForConOrder(DateTime p_dtStartTime, DateTime p_dtBalanceTime, int p_intReturnType)
        {
            int intGetMeasure = 0;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.m_lngGetMeasureForConOrder(p_dtStartTime, p_dtBalanceTime, p_intReturnType, out intGetMeasure);
            objSvc.Dispose();
            objSvc = null;
            return intGetMeasure;
        }
        #endregion

        #region 填充医嘱的停止时间
        /// <summary>
        /// 填充医嘱的停止时间
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_dtStopTime">停止时间</param>
        /// <returns></returns>
        public long m_lngFillConOrderStopTime(string p_strOrderID, DateTime p_dtStopTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFillConOrderStopTime(objPrincipal, p_strOrderID, p_dtStopTime);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 获取医嘱类型Ｖｏ
        /// <summary>
        /// 查询医嘱类型对象	根据医嘱类型ID
        /// </summary>
        /// <param name="p_strID">医嘱类型ID</param>
        /// <param name="p_objResult">医嘱类型对象</param>
        /// <returns></returns>
        public long m_lngGetAidOrderCateByID(string p_strID, out clsT_aid_bih_ordercate_VO p_objResult)
        {
            //long lngRes=0;
            //com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOrderdicChargeSvc));
            //lngRes = objSvc.m_lngGetAidOrderCateByID(objPrincipal,p_strID,out p_objResult);
            //return lngRes;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetAidOrderCateByID(objPrincipal, p_strID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion
        #region 是否存在附加单据
        /// <summary>
        /// 是否存在附加单据	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 这里只是根据附加单据影射表来判断，影射表里有则有。
        /// </remarks>
        public bool m_blnExistAttchOrder(string p_strOrderID)
        {
            long lngRes = 0;
            bool blnExist = false;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngExistAttchOrder(objPrincipal, p_strOrderID, out blnExist);
            objSvc.Dispose();
            objSvc = null;
            return blnExist;
        }
        #endregion

        #region 查找病区
        /// <summary>
        /// 查找病区	根据输入字符串
        /// </summary>
        /// <param name="strCode">输入字符串</param>
        /// <param name="p_objResultArr">病区对象	[out 参数]</param>
        public long m_lngFindArea(string strCode, out clsBIHArea[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFindArea(strCode, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 查找病床
        /// <summary>
        /// 查找占床病床及其病人信息	根据病区ID
        /// </summary>
        /// <param name="p_strID">病区ID</param>
        /// <returns></returns>
        public long m_lngGetBedInfoByAreaID(string p_strAreaID, out clsT_Bse_Bed_VO[] p_objResultArr)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));

            //病床状态(为空则不作为查询条件，多个则用逗号分隔。如: “1,2,3”) {1=空床;2=占床;3=预约占床;4=包房占床}
            /* 优化床位查询*/
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderBedManager objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderBedManager)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderBedManager));

            lngRes = objSvc.m_lngGetBedInfoByAreaID(objPrincipal, p_strAreaID, "2", out p_objResultArr, true);
            objSvc.Dispose();
            objSvc = null;
            /*<===============================================*/
            return lngRes;
        }
        #endregion
        #region 查找病人卡号
        /// <summary>
        /// 获取病人卡号 根据病人ID
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <returns></returns>
        public string m_strGetCardIDByID(string p_strPatientID)
        {
            string strCardID = "";
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetCardIDByID(objPrincipal, p_strPatientID, out strCardID);
            objSvc.Dispose();
            objSvc = null;
            return strCardID;
        }
        #endregion

        #region 访问权限
        /// <summary>
        /// 过滤出有权限的病区
        /// </summary>
        /// <param name="p_objArea">病区对象</param>
        /// <param name="p_ilUsableAreaID">有权访问的病区ID集合</param>
        /// <returns>有权访问的病区对象集合</returns>
        public ArrayList GetUsableAreaObject(clsBIHArea[] p_objArea, IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objArea == null || p_objArea.Length <= 0) return ilRes;

            //全部的可访问的病区对象
            for (int i1 = 0; i1 < p_objArea.Length; i1++)
            {
                if (p_objArea[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objArea[i1].m_strAreaID.Trim()))
                {
                    if (!(ilRes.Contains(p_objArea[i1])))
                        ilRes.Add(p_objArea[i1]);
                }
            }
            return ilRes;
        }

        /// <summary>
        /// 过滤出有权限的住院号
        /// </summary>
        /// <param name="p_objItemArr">入院登记对象	[数组]</param>
        /// <param name="p_ilUsableAreaID">有权访问的病区ID集合</param>
        /// <returns>有权访问的入院登记对象集合</returns>
        public ArrayList GetUsableRegisterObject(clsT_Opr_Bih_Register_VO[] p_objItemArr, IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objItemArr == null || p_objItemArr.Length <= 0) return ilRes;

            //全部的可访问的病区对象
            for (int i1 = 0; i1 < p_objItemArr.Length; i1++)
            {
                if (p_objItemArr[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objItemArr[i1].m_strAREAID_CHR.Trim()))
                {
                    if (!(ilRes.Contains(p_objItemArr[i1])))
                        ilRes.Add(p_objItemArr[i1]);
                }
            }
            return ilRes;
        }
        #endregion

        //T_Opr_Bih_Order (医嘱单)
        #region 查找
        /// <summary>
        /// 获取医嘱记录Vo		根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <param name="p_objResult">医嘱记录Vo	[out 参数]</param>
        /// <returns></returns>
        public long m_lngGetOrderByID(string p_strOrderID, out clsBIHOrder p_objResult )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderByID(objPrincipal, p_strOrderID, out p_objResult );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取病人信息
        /// <summary>
        /// 获取病人信息	根据入院ID
        /// </summary>
        /// <param name="registerid">入院ID</param>
        /// <param name="dtbResult">DataTable </param>
        /// <returns></returns>
        public long m_lngGetPatientInfoByRegisterid(string registerid, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            lngRes = objSvc.m_lngGetPatientInfoByRegisterid(objPrincipal, registerid, out dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取患者护理类型
        public long m_lngGetPatientCareInfo(string p_strResgisterID, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            lngRes = objSvc.m_lngGetPatientCareInfo(objPrincipal, p_strResgisterID, out dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region 获取医嘱对象	根据医嘱ID
        /// <summary>
        /// 获取有效医嘱	根据医嘱ID
        /// </summary>
        /// <param name="p_strOrderID">医嘱ID</param>
        /// <returns></returns>
        public long m_lngGetOrderByOrderID(string p_strOrderID, out clsBIHOrder p_objResult )
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderByOrderID(p_strOrderID, out p_objResult );
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion
        #region
        public long m_lngGetSpChargeItemIDType(out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            lngRes = objSvc.m_lngGetSpChargeItemIDType(out dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 获取药品详细信息	glzhang	2005.10.13
        /// <summary>
        /// 获取药品详细信息	glzhang	2005.10.13
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strText"></param>
        public void m_mthGetMedicineInfo(string ID, out string strText)
        {
            strText = "";
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            objSvc.m_mthGetMedicineInfo(objPrincipal, ID, out strText);
            objSvc.Dispose();
            objSvc = null;
        }
        #endregion



        #region 保存组套医嘱
        /// <summary>
        /// 保存组套医嘱(blnIsSameNO-true同方,false 不同方)
        /// </summary>
        internal long SaveTheGroup(out string[] strRecordIDArr, clsBIHOrder[] arrOrder, bool blnIsSameNO, bool isChildPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngAddNewOrder(out strRecordIDArr, arrOrder, blnIsSameNO, isChildPrice);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region 保存组套医嘱（新）
        /// <summary>
        /// 保存组套医嘱(blnIsSameNO-true同方,false 不同方)
        /// </summary>
        internal long m_lngAddNewOrderByGroup(out string[] p_strRecordIDArr, ArrayList p_RecordArr, bool isChildPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngAddNewOrderByGroup(out p_strRecordIDArr, p_RecordArr, isChildPrice);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        internal long m_lngGetOrderGroupByID(string m_strGroupID, out clsT_aid_bih_ordergroup_VO p_objResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
              (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.m_lngGetOrderGroupByID(objPrincipal, m_strGroupID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderGroupDetailByGroupID(string m_strGroupID, out DataTable m_dtOrderGroupDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.m_lngGetOrderGroupDetailByGroupID(objPrincipal, m_strGroupID, out m_dtOrderGroupDetail, true);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngDellORDERCHARGEDEPT(string m_strSeq_int)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHORDERCHARGEDService));
            lngRes = objSvc.m_lngDellORDERCHARGEDEPT(objPrincipal, m_strSeq_int);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #region 功能开关用来控制是否允许修改医嘱诊疗项目名称 1017
        /// <summary>
        /// 功能开关用来控制是否允许修改医嘱诊疗项目名称 1017
        /// </summary>
        /// <param name="m_blOpen"></param>
        /// <returns></returns>
        public long m_lngGetBihOrderNameControl(out bool m_blOpen)
        {

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            long lngRes = objSvc.m_lngGetBihOrderNameControl(out m_blOpen);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        internal long m_lngFindSendArea(string m_strAreaID, out DataTable m_dtItem)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngFindSendArea(m_strAreaID, out m_dtItem);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 将当前医嘱置某子医嘱的修改
        /// </summary>
        /// <param name="objOrder"></param>
        /// <returns></returns>
        internal long m_lngModifyCurrentSubOrder(clsBIHOrder objOrder)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngModifyCurrentSubOrder(objOrder);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 功能开关用来控制是否允许修改医嘱作废 1017
        /// </summary>
        /// <param name="m_blOpen"></param>
        /// <returns></returns>
        internal long m_lngGetm_cmdBlankOutControl(out bool m_blOpen)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            long lngRes = objSvc.m_lngGetm_cmdBlankOutControl(out m_blOpen);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        #region 根据项目ID查找申请分类
        /// <summary>
        /// 根据项目ID查找申请分类
        /// </summary>
        /// <param name="strID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetApplyTypeByID(string strID, out DataTable dt)
        {
            long ret = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            ret = objSvc.m_mthGetApplyTypeByID(strID, out dt);
            objSvc.Dispose();
            objSvc = null;
            return ret;
        }
        #endregion

        internal long m_lngGetOrderDicChargeByCode(string strFindCode, int m_intClass, string m_strORDERCATEID_CHR, bool m_blLessMedControl, string p_strMedDeptId, out clsBIHOrderDic[] arrDic, out DataSet m_dsDicChargeSet, bool isChildPrice)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            long lngRes = objSvc.m_lngGetOrderDicChargeByCode(strFindCode, m_intClass, m_strORDERCATEID_CHR, m_blLessMedControl, p_strMedDeptId, out  arrDic, out  m_dsDicChargeSet, isChildPrice);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetRecipeFreq(string strFindCode, out clsAIDRecipeFreq[] arrFreq)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            long lngRes = objSvc.m_lngGetRecipeFreq(strFindCode, out arrFreq);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngModifyOrder(clsBIHOrder objOrder, clsBIHOrder[] arrOrder, bool isChildPrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngModifyOrder(objOrder, arrOrder, isChildPrice);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetChargeListByGroupDetail(clsBIHOrder order, out ArrayList m_arrChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.m_lngGetChargeListByGroupDetail(objPrincipal, order, out  m_arrChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        public long m_lngGetFeelListbyOrderDic(ArrayList m_arrOrderDic, out ArrayList m_arrFeelList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.m_lngGetFeelListbyOrderDic(objPrincipal, m_arrOrderDic, out  m_arrFeelList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        #region 费用统计方法
        /// <summary>
        /// 当前同方医嘱费用总计
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        internal decimal GetTheSameChargeSum(clsBIHCanExecOrder order, DataTable m_dtChargeList)
        {
            decimal m_decSum = 0;
            if (m_dtChargeList != null && m_dtChargeList.Rows.Count <= 0)
            {
                return m_decSum;
            }
            DataView myDataView = new DataView(m_dtChargeList);
            myDataView.RowFilter = "REGISTERID_CHR='" + order.m_strRegisterID + "' and RECIPENO_INT=" + order.m_intRecipenNo.ToString();
            if (myDataView.Count <= 0)
            {
                return m_decSum;
            }
            for (int i = 0; i < myDataView.Count; i++)
            {
                DataRowView row = myDataView[i];
                m_decSum += clsConverter.ToDecimal(row["UNITPRICE_DEC"].ToString()) * clsConverter.ToDecimal(row["AMOUNT_DEC"].ToString());
            }
            return m_decSum;
        }

        //当前医嘱费用合计
        internal decimal GettheChargeSum(clsBIHCanExecOrder order, DataTable m_dtChargeList)
        {
            decimal m_decSum = 0;
            if (m_dtChargeList != null && m_dtChargeList.Rows.Count <= 0)
            {
                return m_decSum;
            }
            DataView myDataView = new DataView(m_dtChargeList);
            myDataView.RowFilter = "orderid_chr='" + order.m_strOrderID + "'";
            myDataView.Sort = "FLAG_INT";
            if (myDataView.Count <= 0)
            {
                return m_decSum;
            }
            for (int i = 0; i < myDataView.Count; i++)
            {
                DataRowView row = myDataView[i];
                m_decSum += clsConverter.ToDecimal(row["UNITPRICE_DEC"].ToString()) * clsConverter.ToDecimal(row["AMOUNT_DEC"].ToString());
            }
            return m_decSum;
        }
        #endregion

        //原来使用ArrayList正确的代码
        //internal long GetTheHisControl(ArrayList m_arrControl, out DataTable dtbResult)
        //{
        //    long lngRes = 0;
        //    com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
        //    lngRes = objSvc.GetTheHisControl(m_arrControl, out  dtbResult);
        //    return lngRes;
        //}
        //现在使用List<T>的代码
        internal long GetTheHisControl(System.Collections.Generic.List<string> m_arrControl, out DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
            lngRes = objSvc.GetTheHisControl(m_arrControl, out  dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngFindGroup(string m_strFindCode, string m_strEmpId, string m_strInpatientAreaID, int m_intClass, out clsBIHOrderGroup[] arrGroup)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.m_lngFindGroup(m_strFindCode, m_strEmpId, m_strInpatientAreaID, m_intClass, out arrGroup);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderStopSignByRegisterId(string m_strRegisterID, out DataTable m_dtOrderSign)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderStopSignByRegisterId(m_strRegisterID, out m_dtOrderSign);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetOrderStopByRECIPENO_INT(ArrayList m_arrRecipenNo, string m_strRegisterID, out clsBIHOrder[] arrOrder, out DataTable m_dtChargeList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
             (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngGetOrderStopByRECIPENO_INT(m_arrRecipenNo, m_strRegisterID, out arrOrder, out m_dtChargeList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngStopOrder(string[] p_strBlankOutOrderIDArr, string strDoctorID, string strDoctorName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngStopOrder(p_strBlankOutOrderIDArr, strDoctorID, strDoctorName);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngDeleteOrder(string[] p_strDeleteOrderIDArr, string[] p_strDeleteContinueIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.m_lngDeleteOrder(p_strDeleteOrderIDArr, p_strDeleteContinueIDArr);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        internal long m_lngGetSignByEmpID(string m_strEmpID, ref object m_objSign)
        {
            long lngRes = 0;
            clsBIHOrderService objSvc = (clsBIHOrderService)clsObjectGenerator.objCreatorObjectByType(typeof(clsBIHOrderService));
            lngRes = objSvc.m_lngGetSignByEmpID(m_strEmpID, ref m_objSign);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
    }
    #region 费用描述类
    /// <summary>
    /// 费用描述类	{用于显示费用信息}	 
    /// </summary>
    public class clsChargeForDisplay
    {
        public clsChargeForDisplay()
        { }
        /// <summary>
        /// 收费项目所在的医嘱ID
        /// </summary>
        public string strOrderID = "";
        /// <summary>
        /// 流水号--对应(住院诊疗项目收费项目执行客户表的流水号-T_OPR_BIH_ORDERCHARGEDEPT)
        /// </summary>
        public string m_strSeq_int = "";
        /// <summary>
        /// 收费项目ID
        /// </summary>
        public string m_strChargeID = "";
        /// <summary>
        /// 收费项目编码
        /// </summary>
        public string m_strITEMCODE_VCHR = "";
        /// <summary>
        /// 收费项目名称
        /// </summary>
        public string m_strName = "";
        /// <summary>
        /// 收费类别 0-主项目 1-辅助项目 2-用法带出 3-补充录入项目
        /// </summary>
        public int m_intType = 1;
        /// <summary>
        /// 单价
        /// </summary>
        public double m_dblPrice = 0;
        /// <summary>
        /// 领量
        /// </summary>
        public double m_dblDrawAmount = 0;
        /// <summary>
        /// 合计金额
        /// </summary>
        public double m_dblMoney = 0;
        /// <summary>
        /// 批发单价 
        /// </summary>
        public double m_dblTradePrice = 0;
        /// <summary>
        /// 合计药品让利金额 
        /// </summary>
        public double m_dblDiffCostMoney = 0;
        /// <summary>
        /// 续用类型 续用类型 {0=连续用;1=首次用}
        /// </summary>
        public int m_intCONTINUEUSETYPE_INT = -1;
        /// <summary>
        /// 是否连续性医嘱	{0=否；1=是} 连续性医嘱不提示药品费用信息；
        /// </summary>
        public int m_intIsContinueOrder = 0;
        /// <summary>
        /// 药房缺药标志 0-有药 1－缺药
        /// </summary>
        public string m_strNoqtyFLag = "";
        /// <summary>
        /// 是否医保（0/1)
        /// </summary>
        public int m_strIsYB = 0;
        /// <summary>
        /// 医保类型
        /// </summary>
        public string m_strYBClass = "";
        /// <summary>
        /// 执行类别ID
        /// </summary>
        public string m_strOrdercateid_chr = "";
        /// <summary>
        /// 执行科室ID
        /// </summary>
        public string m_strClacarea_chr = "";
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string m_strClacareaName_chr = "";
        /// <summary>
        /// 住院诊疗项目收费项目执行客户表
        /// </summary>
        public clsORDERCHARGEDEPT_VO m_objORDERCHARGEDEPT_VO;
        /// <summary>
        /// 项目来源类型这里会根据来源表来确定值范围，内部使用。例如1－药品表，2－材料表等。
        /// </summary>
        public int m_intITEMSRCTYPE_INT;
        /// <summary>
        /// 中心药房缺药标志 0-有药 1－缺药
        /// </summary>
        public int m_intIPNOQTYFLAG_INT;
        /// <summary>
        /// 规格{=this.get诊疗项目.get收费项目.规格}
        /// </summary>
        public string m_strSPEC_VCHR = "";
        /// <summary>
        /// 领量单位
        /// </summary>
        public string m_strUNIT_VCHR = "";
        /* <<======================================= */
        /// <summary>
        /// 停用标志 1-停用 0-正常
        /// </summary>
        public int m_intIFSTOP_INT = 0;

    }
    #endregion
}
