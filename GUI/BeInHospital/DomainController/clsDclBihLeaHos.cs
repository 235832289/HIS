using System;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 出院管理逻辑控制层
	/// 作者： He Guiqiu
	/// 创建时间： 2006-07-12
	/// </summary>
    public class clsDclBihLeaHos : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 构造函数
        public clsDclBihLeaHos()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

        #region 预出院
        /// <summary>
        /// 预出院
        /// </summary>
        /// <param name="objPatientVO">[clsT_Opr_Bih_Leave_VO]</param>
        /// <returns></returns>
        public long PreLeaveHospital(clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngRes = 0;
           
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));
           
                lngRes = objSvc.PreLeaveHospital(objPrincipal, objPatientVO);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            } 
            
            return lngRes;
        }
        #endregion 

        #region 直接出院
        /// <summary>
        /// 直接出院
        /// </summary>
        /// <param name="objPatientVO">[clsT_Opr_Bih_Leave_VO]</param>
        /// <returns></returns>
        public long LeaveHospital(clsT_Opr_Bih_Leave_VO objPatientVO)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.LeaveHospital(objPrincipal, objPatientVO);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region 撤消预出院
        /// <summary>
        /// 撤消预出院
        /// </summary>
        /// <param name="p_RegisterId"></param>
        /// <param name="p_OperatorId"></param>
        /// <returns></returns>
        public long CancelPreLeaved(string p_RegisterId, string p_OperatorId)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.CancelPreLeaved(objPrincipal, p_RegisterId, p_OperatorId);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region 出院召回
        /// <summary>
        /// 出院召回
        /// </summary>
        /// <param name="objPatientVO"></param>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public long RecallHospital(clsT_Opr_Bih_Leave_VO objPatientVO, string operatorId)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.RecallHospital(objPrincipal, objPatientVO, operatorId);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region 根据入院登记流水号查询有效的预出院记录
        /// <summary>
        /// 根据入院登记流水号查询有效的预出院记录
        /// </summary>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetPreLeaveByRegisterID(string p_strRegisterid, out clsT_Opr_Bih_Leave_VO p_objResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetPreLeaveByRegisterID(objPrincipal, p_strRegisterid, out p_objResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 根据入院登记流水号查询有效的出院记录
        /// <summary>
        /// 根据入院登记流水号查询有效的出院记录
        /// </summary>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_pstatus">标志 0 预出院；1 正式出院</param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetLeaveByRegisterID(string p_strRegisterid, string p_pstatus, out clsT_Opr_Bih_Leave_VO p_objResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetLeaveByRegisterID(objPrincipal, p_strRegisterid, p_pstatus, out p_objResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region  查询当前是否有新开,提交,转抄,执行等(未停)的医嘱
        /// <summary>
        /// 查询当前是否有新开,提交,转抄,执行等(未停)的医嘱
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="m_intCount"></param>
        /// <returns></returns>
        public long m_lngGetNotStopOrderByRegID(string p_strRegisterID, out int m_intCount)
        {
            m_intCount = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc =
                        (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            long l = objSvc.m_lngGetNotExecuteOrderByRegID(objPrincipal, p_strRegisterID, out m_intCount);
            objSvc.Dispose();
            return l;
        }
        #endregion 

        #region 判断是否存在临嘱尚未执行
        /// <summary>
        /// 判断是否存在临嘱尚未执行
        /// </summary>
        /// <param name="p_RegisterId"></param>
        /// <param name="p_status"></param>
        /// <param name="p_has"></param>
        /// <returns></returns>
        public long GetOrderNotExc(string p_RegisterId, out int p_count, out ArrayList p_arrCreator)
        {
            long lngRes = 0;
            //p_ifHas=false;
            p_count = 0;
            try
            {
                com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc =
                        (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));

                //lngRes = objSvc.m_lngGetNotExecuteOrderByRegID(objPrincipal, p_RegisterId, out count);
                //ArrayList m_arrCreator;
                lngRes = objSvc.m_lngGetNotStopOrderByRegID(objPrincipal, p_RegisterId, out p_count, out p_arrCreator);
                //if (p_arrCreator.Count > 0)
                //{
                //    MessageBox.Show(p_arrCreator[0].ToString());
                //}
                //if (count > 0)
                //{
                //    p_ifHas = true;
                //}
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region 判断是否存在临嘱尚未执行
        /// <summary>
        /// 判断是否存在临嘱尚未执行
        /// </summary>
        /// <param name="p_RegisterId"></param>
        /// <param name="p_status"></param>
        /// <param name="p_has"></param>
        /// <returns></returns>
        public long IfHasDisExcOrder(string p_registerId, out bool HasDisExcOrder)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.IfHasDisExcOrder(objPrincipal, p_registerId, out HasDisExcOrder);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion

        #region 查询疾病字典
        /// <summary>
        /// 查询疾病字典
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetDisease(out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetInsurncedisease(objPrincipal, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 查询疾病字典
        /// <summary>
        /// 查询疾病字典
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetDisease(string p_strCode, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetInsurncedisease(objPrincipal, p_strCode, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 出院诊断统计
        /// <summary>
        /// 出院诊断统计
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long GetOutDiagnoses(string p_strCondition, out DataTable p_dtResult)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.GetOutDiagnoses(objPrincipal, p_strCondition, out p_dtResult);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 更新住院登记表出院诊断
        /// <summary>
        /// 更新住院登记表出院诊断
        /// </summary>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <param name="p_OutDiagnose">出院诊断</param>
        /// <returns></returns>
        public long UpdateRegisterOutDiagnose(string p_RegisterId, string p_OutDiagnose,bool p_blnDiseaseType)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.UpdateRegisterOutDiagnose(objPrincipal, p_RegisterId, p_OutDiagnose, p_blnDiseaseType);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 更新住院登记表出院诊断
        /// <summary>
        /// 更新住院登记表出院诊断
        /// </summary>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <param name="p_OutDiagnose">出院诊断</param>
        /// <returns></returns>
        public long UpdateRegisterOutDiagnose(string p_RegisterId, string p_OutDiagnose)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.UpdateRegisterOutDiagnose(objPrincipal, p_RegisterId, p_OutDiagnose);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 修改预出院日期
        /// <summary>
        /// 修改预出院日期
        /// </summary>
        /// <param name="p_RegisterId">住院登记号</param>
        /// <param name="p_OutDiagnose">出院诊断</param>
        /// <returns></returns>
        public long ModifyLeaveDate(DateTime p_dtNewDate, clsT_Opr_Bih_Leave_VO p_objLeave)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.ModifyLeaveDate(objPrincipal, p_dtNewDate, p_objLeave);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 

        #region 判断日期段内是否发生了费用
        /// <summary>
        /// 判断日期段内是否发生了费用
        /// </summary>
        /// <param name="p_strRegisterid_chr">入院登记流水号</param>
        /// <param name="p_strBeginDate">开始时间</param>
        /// <param name="p_strEndDate">结束时间</param>
        /// <param name="p_hasCharge"></param>
        /// <returns></returns>
        public long IfHasCharge(string p_strRegisterid_chr, string p_strBeginDate, string p_strEndDate, out bool p_hasCharge)
        {
            long lngRes = 0;

            try
            {
                com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc objSvc =
                        (com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihLeaHosSvc));

                lngRes = objSvc.IfHasCharge(p_strRegisterid_chr, p_strBeginDate, p_strEndDate, out p_hasCharge);
                objSvc.Dispose();
            }
            catch (Exception e)
            {
                throw e;
            }

            return lngRes;
        }
        #endregion 
    }
}
