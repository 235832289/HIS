using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsDcl_OPCharge 的摘要说明。
    /// </summary>
    public class clsDcl_OPCharge : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        public clsDcl_OPCharge()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_mthSetPara();
        }
        private string m_strNeedCheck = string.Empty;
        private void m_mthSetPara()
        {
            try
            {
                m_strNeedCheck = m_strGetSysparm("1200");
                string[] TmpArr = m_strNeedCheck.Split(';');
                for (int intI = 0; intI < TmpArr.Length; intI++)
                {
                    if (TmpArr[intI] != null)
                    {
                        if (intI == 0)
                        {
                            m_strNeedCheck = "'" + TmpArr[intI] + "'";
                        }
                        else
                        {
                            m_strNeedCheck += "," + "'" + TmpArr[intI] + "'";
                        }
                    }
                }
            }
            catch (Exception objex)
            {
                m_strNeedCheck = "'1','2'";
                com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
                objLog.LogError("获取参数1200失败！" + objex.Message);
            }
        }
        /// <summary>
        /// 获取新系统参数
        /// </summary>
        /// <param name="parmcode">参数代码</param>
        /// <returns>参数值</returns>
        private string m_strGetSysparm(string parmcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                                       (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            string ret = objSvc.m_strGetSysparm(parmcode);
            objSvc.Dispose();

            return ret;
        }
        /// <summary>
        /// 查找药品
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindMedicineByID(string strType, string ID, string strPatientTypeID, out DataTable dt, string strEmployID)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthFindMedicineByID(strType, ID.ToUpper(), strPatientTypeID, out dt, objPrincipal, strEmployID, this.m_strNeedCheck);
            objSvc.Dispose();
            return lngRes;
        }
        /// <summary>
        /// 查找药品
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindMedicineByID(string ID, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthFindMedicineByID(ID, out dt, objPrincipal);
            objSvc.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 判断是某个药品的药品类型是否在9003中
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool blMedicine9003(string p_strMedID)
        {
            bool blMedicine = false;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            blMedicine = objSvc.blMedicine9003(p_strMedID);
            objSvc.Dispose();
            return blMedicine;
        }

        #region 获取当日流水号
        /// <summary>
        /// 获取当日流水号
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strSerNo"></param>
        /// <returns></returns>
        public long m_mthGetSerNO(out string m_strSerNo)
        {
            m_strSerNo = string.Empty;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthGetSerNO(objPrincipal, out m_strSerNo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 插入药品发送表
        /// <summary>
        /// 插入药品发送表
        /// </summary>
        /// <param name="objVOMainArr"></param>
        /// <param name="objWMedicineSend"></param>
        /// <param name="objCMedicineSend"></param>
        /// <returns></returns>
        public long m_mthSaveMedicineSend(ref ArrayList objVOMainArr, ref  ArrayList objWMedicineSend, ref ArrayList objCMedicineSend)
        {

            long lngRes = 0;
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                    (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
                lngRes = objSvc.m_mthSaveMedicineSend(objPrincipal, ref objVOMainArr, ref objWMedicineSend, ref objCMedicineSend);
                objSvc.Dispose();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return lngRes;

        }
        #endregion
        #region 保存数据
        public long m_mthSaveAllData(ArrayList clsVOMain, out string strRecipeNo,
            clsRecipeDetail_VO[] objRD_VO, decimal times, clsInvoice_VO[] objInvoice_VOArr, ArrayList[] objArr1, ArrayList[] objArr2, ArrayList objMedicineSend, string strOpChargeDeptId, bool blnFlag)
        {
            long lngRes = 0;
            strRecipeNo = "";
            try
            {
                com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                    (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
                lngRes = objSvc.m_mthSaveAllData(objPrincipal, clsVOMain, out strRecipeNo, objRD_VO, times, objInvoice_VOArr, objArr1, objArr2, objMedicineSend, strOpChargeDeptId, blnFlag);
                objSvc.Dispose();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            return lngRes;
        }
        #endregion
        public long m_mthAddRecipeMain(clsOutPatientRecipe_VO clsVO, out string p_strID)
        {
            p_strID = "";
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            long lngRes = objSvc.m_mthAddRecipeMain(objPrincipal, clsVO, out p_strID);
            objSvc.Dispose();
            return lngRes;
        }
        public void m_mthSaveRecipeDetial(string strRecipeNo, clsRecipeDetail_VO[] objRD_VO, decimal times)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            objSvc.m_mthSaveRecipeDetial(objPrincipal, strRecipeNo, objRD_VO, times);
            objSvc.Dispose();
        }
        public void m_mthSaveRecipeChargeItemDetial(string strRecipeNo, clsRecipeDetail_VO[] objRD_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            objSvc.m_mthSaveRecipeChargeItemDetial(objPrincipal, strRecipeNo, objRD_VO);
            objSvc.Dispose();
        }
        public void m_mthSaveRecipeSend(clsMedrecipesend_VO objMRS_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            objSvc.m_mthSaveRecipeSend(objPrincipal, objMRS_VO);
            objSvc.Dispose();

        }
        public long m_mthSaveInvoicInfo(clsInvoice_VO obj)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            long lngRes = objSvc.m_mthSaveInvoicInfo(objPrincipal, obj);
            objSvc.Dispose();
            return lngRes;
        }
        public void m_mthSaveInvoiceDetail(ArrayList objArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            objSvc.m_mthSaveInvoiceDetail(objPrincipal, objArr);
            objSvc.Dispose();
        }
        public void m_mthSaveInvoiceDetail2(ArrayList objArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
            objSvc.m_mthSaveInvoiceDetail2(objPrincipal, objArr);
            objSvc.Dispose();
        }
        //		public long m_mthFindRecipeNoByPatientID(string ID,out clsRecipeInfo_VO[] objRI_VO)
        //		{
        //			objRI_VO=null;
        //			com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc = 
        //				(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
        //		long lngRes=	objSvc.m_mthFindRecipeNoByPatientID(objPrincipal,ID, out objRI_VO,"");
        //			objSvc.Dispose();
        //			return lngRes;
        //			
        //		}
        public long m_mthFindMaxRecipeNoByPatientID(string ID, out string strRecipe, out string strSeqid, out string strstatus, out int RecipeCount, out DataTable dt, out string strISgreen)
        {
            strRecipe = "";
            RecipeCount = 0;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthFindMaxRecipeNoByPatientID(ID, out strRecipe, out strSeqid, out strstatus, out RecipeCount, out dt, out strISgreen);
            objSvc.Dispose();
            return lngRes;

        }

        public long m_mthFindTreatRecipeNoByPatientID(string ID, out string strRecipe, out string strSeqid, out string strstatus, out int RecipeCount, out DataTable dt)
        {
            strRecipe = "";
            strSeqid = "";
            RecipeCount = 0;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthFindTreatRecipeNoByPatientID(ID, out strRecipe, out strSeqid, out strstatus, out RecipeCount, out dt);
            objSvc.Dispose();
            return lngRes;

        }

        public long m_mthFindRecipeByID(string ID, out DataTable dt, bool flag)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthFindRecipeByID(ID, out dt, objPrincipal, flag);
            objSvc.Dispose();
            return lngRes;
        }
        #region 检查发票号是否已用
        public bool m_mthCheckInvoice(string strInvoiceNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            bool lngRes = objSvc.m_mthCheckInvoice(objPrincipal, strInvoiceNo);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 查找对应表信息
        public long m_mthRelationInfo(out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthRelationInfo(out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region 查找处方医生
        public long m_mthFindRecipeDoctor(string strPatientID, string strRecipeNO, out clsRecipeInfo_VO[] objRI_VO)
        {
            objRI_VO = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            return objSvc.m_mthFindRecipeNoByPatientID(null, strPatientID, out objRI_VO, strRecipeNO, 1);
        }
        #endregion
        public long m_mthGetDefaultItem(string strPatientTypeID, string strRegister, string strRecipeflag, string strExpert, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthGetDefaultItem(strPatientTypeID, strRegister, strRecipeflag, strExpert, out dt);
            objSvc.Dispose();
            return lngRes;
        }

        #region 带出默认项目
        /// <summary>
        /// 带出默认项目
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strPatientTypeID"></param>
        /// <param name="strRecipeflag"></param>
        /// <param name="strDuty"></param>
        /// <param name="strRecipeID"></param>
        /// <returns></returns>     
        public long m_mthGetDefaultItem(out DataTable dt, string strPatientTypeID, string strRecipeflag, string strDuty, string strRecipeID, string strRegID, string strDeptID)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthGetDefaultItem(out dt, strPatientTypeID, strRecipeflag, strDuty, strRecipeID, strRegID, strDeptID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        public void m_mthGetChooseHospitalInfo(out clsChargeHospitalInfoVO[] objCHInfoVOArr)
        {
            objCHInfoVOArr = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            objSvc.m_mthGetChooseHospitalInfo(out objCHInfoVOArr);
            objSvc.Dispose();
        }
        public int m_mthIsCanDo(string p_flag)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            return objSvc.m_mthIsCanDo(p_flag);

        }
        #region 查找用法
        public long m_mthFindUsage(string ID, out DataTable dt)
        {

            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindUsage2(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        public long m_mthFindFreq(string ID, out DataTable dt)
        {

            dt = null;
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));
            long lngRes = objSvc.m_mthFindFrequency2(objPrincipal, ID, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 取得科室编号
        /// <summary>
        /// 取得科室编号
        /// </summary>
        /// <param name="p_strDeptID"></param>
        /// <returns></returns>
        public string m_strGetDeptNO(string p_strDeptID)
        {
            System.Data.DataTable dtRecord = null;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            objSvc.m_mthGetDeptNO(p_strDeptID, out dtRecord);
            if (dtRecord != null)
            {
                if (dtRecord.Rows.Count == 1)
                {
                    return dtRecord.Rows[0][0].ToString().Trim();
                }
            }
            return "";
        }
        #endregion

        #region 判断是否材料
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strChrgItem"></param>
        /// <returns></returns>
        public bool m_blnCheckMaterial(string strChrgItem)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            bool lngRes = objSvc.m_blnCheckMaterial(strChrgItem);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取药房分类
        /// <summary>
        /// 获取药房分类
        /// </summary>
        /// <param name="strChrgItem"></param>
        /// <returns></returns>
        public string m_strGetOutSendMedStoretype(string strChrgItem)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            string strMedStoretype = objSvc.m_strGetOutSendMedStoretype(strChrgItem);
            //objSvc.Dispose();
            return strMedStoretype;
        }
        #endregion

        #region 判断收费项目是否有子项
        /// <summary>
        /// 判断收费项目是否有子项
        /// </summary>
        /// <param name="p_strChargeItem"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>		
        public bool m_blnCheckSubChargeItem(string p_strPatientTypeID, string p_strChargeItem, out DataTable dtRecord)
        {
            long lngRes = 0;
            bool blnRet = false;
            dtRecord = new DataTable();

            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            try
            {
                lngRes = objSvc.m_lngGetSubChargeItem(p_strPatientTypeID, p_strChargeItem, out dtRecord);
                if (lngRes > 0 && dtRecord.Rows.Count > 0)
                {
                    blnRet = true;
                }
            }
            catch
            {
                blnRet = false;
            }
            return blnRet;
        }
        #endregion

        #region 判断医生是否为专家
        /// <summary>
        /// 判断医生是否为专家
        /// </summary>
        /// <param name="strEmpID"></param>
        /// <returns></returns>
        public bool m_blnCheckExpert(string strEmpID)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            bool lngRes = objSvc.m_blnCheckExpert(strEmpID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 判断是否正常挂号
        /// <summary>
        /// 判断是否正常挂号
        /// </summary>
        /// <param name="strEmpID"></param>
        /// <returns></returns>
        public bool m_blnCheckNormalReg(string strRegID)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            bool lngRes = objSvc.m_blnCheckNormalReg(strRegID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 查找默认项目
        /// <summary>
        /// 查找默认项目
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="strPatType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthFindChrgItemByID(string strItemID, string strPatType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_mthGetDefaultItem(strItemID, strPatType, out dt);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 显示支付卡类型列表
        /// <summary>
        /// 显示支付卡类型列表
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetPaycardtype(out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_lngGetPaycardtype(out dtRecord);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取患者结算卡卡号列表
        /// <summary>
        /// 获取患者结算卡卡号列表
        /// </summary>
        /// <param name="dtRecord"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public long m_lngGetPaycardno(out DataTable dtRecord, string pid)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_lngGetPaycardno(out dtRecord, pid);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据药房ID获取最优窗口号
        /// <summary>
        /// 根据药房ID获取最优窗口号
        /// </summary>
        /// <param name="storageID"></param>
        /// <param name="windowsID"></param>
        /// <returns></returns>
        public long lngGetWindowIDByStorage(string storageID, out string windowsID, out int sortno, bool CheckScope)
        {
            com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol));

            long lngRes = objSvc.lngGetWindowIDByStorage(objPrincipal, storageID, out windowsID, out sortno, CheckScope);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取药房的窗口
        public long m_mthGetMedWindows(string p_strMedstoreID, out DataTable dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol));

            long lngRes = objSvc.m_mthGetMedWindows(p_strMedstoreID, out dtbResult);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 判断下班后发药： 普通药房转急诊药房
        /// <summary>
        /// 判断下班后发药： 普通药房转急诊药房
        /// </summary>
        /// <param name="strOldStorageID"></param>
        /// <param name="strNewStorageID"></param>
        /// <returns></returns>
        public long m_lngGetWorkStorage(string strOldStorageID, out string strNewStorageID)
        {
            com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol));

            long lngRes = objSvc.m_lngGetWorkStorage(objPrincipal, strOldStorageID, out strNewStorageID);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 生成患者身份对应号表
        /// <summary>
        /// 生成患者身份对应号表
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="paytypeid"></param>
        /// <param name="idno"></param>
        /// <returns></returns>
        public long m_lngGenpatientidentityno(string pid, string paytypeid, string idno)
        {
            if (paytypeid.Trim() == "")
            {
                return 0;
            }

            if (idno.Trim() == "")
            {
                idno = " ";
            }

            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                   (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            long lngRes = objSvc.m_lngGenpatientidentityno(pid, paytypeid, idno);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据患者ID，和身份ID获取身份所对应号
        /// <summary>
        /// 根据患者ID，和身份ID获取身份所对应号
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="paytypeid"></param>
        /// <returns></returns>
        public string m_strGetpatientidentityno(string pid, string paytypeid)
        {
            com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc objSvc =
                               (com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorWorkStationSvc));

            string idno = objSvc.m_strGetpatientidentityno(pid, paytypeid);
            objSvc.Dispose();
            return idno;
        }
        #endregion

        #region 根据患者ID统计当天内所有未收费处方信息
        /// <summary>
        /// 根据患者ID统计当天内所有未收费处方信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="recsum"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetAllrecinfoBypid(string pid, out int recsum, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long ret = objSvc.m_lngGetAllrecinfoBypid(pid, out recsum, out dtRecord);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 根据患者ID统计该病人所有先诊疗后结算的未收费处方信息
        /// <summary>
        /// 根据患者ID统计该病人所有先诊疗后结算的未收费处方信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="recsum"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetTreatRecinfoBypid(string pid, out int recsum, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long ret = objSvc.m_lngGetTreatRecinfoBypid(pid, out recsum, out dtRecord);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 根据PID获取患者当天发药信息
        /// <summary>
        /// 根据PID获取患者当天发药信息
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetsendmedinfoBypid(string pid, string medid, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long ret = objSvc.m_lngGetsendmedinfoBypid(pid, medid, out dtRecord);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 判断传入的窗口是否在工作状态
        /// <summary>
        /// 判断传入的窗口是否在工作状态
        /// </summary>
        /// <param name="winid"></param>
        /// <returns></returns>
        public bool m_blnGetmedwinstatus(string winid)
        {
            com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsWindowsCortrol));

            bool b = false;
            long ret = objSvc.m_lngWindowsWork(objPrincipal, winid, out b);

            return b;
        }
        #endregion

        #region 根据处方号判断一张处方是否是医生工作站所开并且为已收费处方
        /// <summary>
        /// 根据处方号判断一张处方是否是医生工作站所开并且为已收费处方
        /// </summary>
        /// <param name="recno"></param>
        /// <returns></returns>
        public bool m_blnCheckRecipeProperty(string recno)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            bool lngRes = objSvc.m_blnCheckRecipeProperty(recno);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据处方号判断一张处方是否已收费
        /// <summary>
        /// 根据处方号判断一张处方是否已收费
        /// </summary>
        /// <param name="recno"></param>
        /// <returns></returns>
        public bool CheckRecipeIsCharge(string recno)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            bool lngRes = objSvc.CheckRecipeIsCharge(recno);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 根据接诊科室、药房获取专用窗口信息
        /// <summary>
        /// 根据接诊科室、药房获取专用窗口信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="medin"></param>
        /// <param name="winid"></param>
        /// <returns></returns>
        public long m_lngGetespecialwin(string deptid, string medid, out string winid, out int waitno)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long ret = objSvc.m_lngGetespecialwin(deptid, medid, out winid, out waitno);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region 根据诊疗卡号获得门诊病人基本挂号信息
        /// <summary>
        /// 根据诊疗卡号获得门诊病人基本挂号信息
        /// </summary>
        /// <param name="CardID">诊疗卡号</param>
        /// <param name="dt">输出信息</param>
        /// <returns></returns>        
        public long m_lngGetPatientInfoByCard(string CardID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsHisBase objSvc =
                                                        (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));

            long l = objSvc.s_lngGetPatientInfoByCard(CardID, out dt, "PATIENTCARDID_CHR");

            objSvc.Dispose();

            return l;
        }
        #endregion

        #region 独立保存处方
        /// <summary>
        /// 独立保存处方
        /// </summary>
        /// <param name="objVOMainArr"></param>
        /// <param name="objRD_VO"></param>
        /// <param name="times"></param>        
        /// <returns></returns>        
        public long m_lngSaveRecipe(ArrayList objVOMainArr, clsRecipeDetail_VO[] objRD_VO, decimal times)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));

            long ret = objSvc.m_lngSaveRecipe(objVOMainArr, objRD_VO, times);
            objSvc.Dispose();
            return ret;
        }
        #endregion


        #region (医保)根据处方号获取记帐单号
        /// <summary>
        /// (医保)根据处方号获取记帐单号
        /// </summary>
        /// <param name="Recno"></param>
        /// <param name="Billno"></param>
        /// <returns></returns>
        public long m_lngGetybbillno(string Recno, ref string Billno)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            long lngRes = objSvc.m_lngGetybbillno(Recno, ref Billno);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region (医保)传送门诊收费数据到医保前置机
        /// <summary>
        /// (医保)传送门诊收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objRecipeArr"></param>
        /// <param name="objYBArr"></param>
        /// <param name="BillNO"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, ArrayList objRecipeArr, ArrayList objYBArr, ref string BillNO)
        {
            long lngRes = 0;

            lngRes = this.m_lngSendybdata(DSN, objYBArr, ref BillNO);
            if (lngRes == 1)
            {
                com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));
                lngRes = objSvc.m_lngSendybdata(objRecipeArr, BillNO);
                if (lngRes == 0)
                {
                    lngRes = this.m_lngDelybdata(DSN, BillNO);
                }
            }

            return lngRes;
        }
        #endregion

        #region (医保)传送门诊收费数据到医保前置机
        /// <summary>
        /// (医保)传送门诊收费数据到医保前置机
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngSendybdata(string DSN, ArrayList objYBArr, ref string BillNO)
        {
            com.digitalwave.iCare.middletier.HIS.clsYB objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYB));
            long lngRes = objSvc.m_lngSendybdata(DSN, objYBArr, ref BillNO);
            return lngRes;
        }
        #endregion

        #region (医保)传送时HIS事务失败，手工删除传送数据
        /// <summary>
        /// (医保)传送时HIS事务失败，手工删除传送数据
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="billno"></param>
        /// <returns></returns>
        public long m_lngDelybdata(string DSN, string billno)
        {
            com.digitalwave.iCare.middletier.HIS.clsYB objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYB));
            long lngRes = objSvc.m_lngDelybdata(DSN, billno);
            return lngRes;
        }
        #endregion

        #region (医保)获取医保结算明细
        /// <summary>
        /// (医保)获取医保结算明细
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="Billno"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetybjsmx(string DSN, string Hospcode, string Billno, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsYB objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYB));
            long lngRes = objSvc.m_lngGetybjsmx(DSN, Hospcode, Billno, out dtRecord);
            return lngRes;
        }
        #endregion

        #region (医保)检测结算自费项目表是否存在指定的BILLNO
        /// <summary>
        /// (医保)检测结算自费项目表是否存在指定的BILLNO
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public bool m_blnCheckBillNo(string DSN, string Hospcode, string BillNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYB objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYB));
            bool b = objSvc.m_blnCheckBillNo(DSN, Hospcode, BillNo);
            return b;
        }
        #endregion

        #region (医保)查询传送收费项目是否成功
        /// <summary>
        /// (医保)查询传送收费项目是否成功
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="Hospcode"></param>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public bool m_blnCheckSendRes(string DSN, string Hospcode, string BillNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYB objSvc =
                                                    (com.digitalwave.iCare.middletier.HIS.clsYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYB));
            bool b = objSvc.m_blnCheckSendRes(DSN, Hospcode, BillNo);
            return b;
        }
        #endregion

        #region (医保)手工更改记帐单号
        /// <summary>
        /// (医保)手工更改记帐单号
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="OldBillNo"></param>
        /// <param name="NewBillNo"></param>
        /// <returns></returns>
        public long m_lngModifyBillNo(string DSN, string OldBillNo, string NewBillNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsYB objSvc =
                                        (com.digitalwave.iCare.middletier.HIS.clsYB)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsYB));
            long lngRes = objSvc.m_lngModifyBillNo(DSN, OldBillNo, NewBillNo);
            return lngRes;
        }
        #endregion

        #region (医保)生成新的记帐单号
        /// <summary>
        /// (医保)生成新的记帐单号
        /// </summary>
        /// <param name="BillNo"></param>
        public void m_mthGenBillNo(out string BillNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            objSvc.m_mthGenBillNo(out BillNo);
            objSvc.Dispose();
        }
        #endregion

        #region (医保)手工更新记帐单号
        /// <summary>
        /// (医保)手工更新记帐单号
        /// </summary>
        /// <param name="OldBillNo"></param>
        /// <param name="NewBillNo"></param>
        /// <returns></returns>
        public long m_lngModifyBillNo(string OldBillNo, string NewBillNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));

            long l = objSvc.m_lngModifyBillNo(OldBillNo, NewBillNo);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region (顺德特定医保)
        /// <summary>
        /// (顺德特定医保)
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="InsuranceID"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>
        public long m_lngSDTDMZYB(string DSN, string RecipeID, string DeptID, string EmpID, string InsuranceID, ArrayList objYBArr, out decimal YBMoney, out string OutMsg)
        {
            com.digitalwave.iCare.middletier.HIS.clsLunJiao objSvc =
                                                            (com.digitalwave.iCare.middletier.HIS.clsLunJiao)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsLunJiao));

            long l = objSvc.m_lngSDTDMZYB(DSN, RecipeID, DeptID, EmpID, InsuranceID, objYBArr, out YBMoney, out OutMsg);
            //objSvc.Dispose();
            return l;
        }
        #endregion

        #region 获取凑整费项目
        /// <summary>
        /// 获取凑整费项目
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetRoundingItem(string ItemID, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long l = objSvc.m_lngGetRoundingItem(ItemID, out dt);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 根据医生ID获取其职称
        /// <summary>
        /// 根据医生ID获取其职称
        /// </summary>
        /// <param name="DoctID"></param>
        /// <returns></returns>        
        public string m_strGetTechnicalRank(string DoctID)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            string s = objSvc.m_strGetTechnicalRank(DoctID);
            objSvc.Dispose();
            return s;
        }
        #endregion

        #region (体检)获取体检人收费项目
        /// <summary>
        /// (体检)获取体检人收费项目
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPEChargeItem(string CardNo, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long l = objSvc.m_lngGetPEChargeItem(CardNo, out dt);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region (体检)根据体检收费项目ID获取相关收费信息
        /// <summary>
        /// (体检)根据体检收费项目ID获取相关收费信息  
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="PatType"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPEChargeItemInfo(string ItemID, string PatType, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long l = objSvc.m_lngGetPEChargeItemInfo(ItemID, PatType, out dt);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region (体检)获取体检人检验申请单元
        /// <summary>
        /// (体检)获取体检人检验申请单元
        /// </summary>
        /// <param name="CardNo"></param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetPELisItem(string CardNo, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long l = objSvc.m_lngGetPELisItem(CardNo, out dt);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region (体检)更新体检收费标志
        /// <summary>
        /// (体检)更新体检收费标志
        /// </summary>
        /// <param name="RegNoArr"></param>
        /// <returns></returns>        
        public long m_lngUpdatePEChargeFlag(ArrayList RegNoArr, ArrayList objAttach, System.Collections.Generic.List<clsPERegGroup_VO> glstRegGroup)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));

            long l = objSvc.m_lngUpdatePEChargeFlag(RegNoArr, objAttach, glstRegGroup);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region (体检)获取体检套餐信息
        /// <summary>
        /// (体检)获取体检套餐信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPeCluster()
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            DataTable dt = objSvc.GetPeCluster();
            objSvc.Dispose();
            return dt;
        }
        #endregion

        #region (体检)获取体检组合信息
        /// <summary>
        /// (体检)获取体检组合信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetPeComb()
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));
            DataTable dt = objSvc.GetPeComb();
            objSvc.Dispose();
            return dt;
        }
        #endregion

        #region m_lngGetPEDoctor
        public long m_lngGetPEDoctor(string CardNo, out clsEmployeeVO objDoctor)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long l = objSvc.m_lngGetPEDoctor(CardNo, out objDoctor);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region (茶山医保)生成DBF文件
        /// <summary>
        /// (茶山医保)生成DBF文件
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="objYBArr"></param>
        /// <returns></returns>  
        public long m_lngCreateDbf_OutPatient(string DSN, string DbfName, ArrayList objYBArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsChaShan objSvc = new clsChaShan();
            //(com.digitalwave.iCare.middletier.HIS.clsChaShan)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChaShan));

            long l = objSvc.m_lngCreateDbf_OutPatient(DSN, DbfName, objYBArr);

            return l;
        }
        #endregion

        #region (医保)获取结果
        /// <summary>
        /// (医保)获取结果
        /// </summary>
        /// <param name="DSN"></param>
        /// <param name="DbfName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetResult_OutPatient(string DSN, string DbfName, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsChaShan objSvc = new clsChaShan();
            // (com.digitalwave.iCare.middletier.HIS.clsChaShan)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsChaShan));

            long l = objSvc.m_lngGetResult_OutPatient(DSN, DbfName, out dtRecord);

            return l;
        }
        #endregion

        #region 获取项目住院发票分类
        /// <summary>
        /// 获取项目住院发票分类
        /// </summary>
        /// <param name="p_strItemID"></param>
        /// <param name="p_hasCat"></param>
        /// <returns></returns>
        public long m_lngGetIPInvoCat(string p_strItemID, out Hashtable p_hasCat)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            long l = objSvc.m_lngGetIPInvoCat(p_strItemID, out p_hasCat);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 更新医保结算号
        /// <summary>
        /// 更新医保结算号
        /// </summary>
        /// <param name="p_strRecipeID"></param>
        /// <param name="p_strChargeNo"></param>
        /// <returns></returns>
        public long m_lngUpdateYBChargeNo(string p_strRecipeID, string p_strChargeNo)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));

            long l = objSvc.m_lngUpdateYBChargeNo(p_strRecipeID, p_strChargeNo);
            objSvc.Dispose();
            return l;
        }
        #endregion

        #region 验证某一医生当天是否给某一病人开过处方
        /// <summary>
        /// 验证某一医生当天是否给某一病人开过处方
        /// </summary>
        /// <param name="p_strPatientId"></param>
        /// <param name="p_strDoctorId"></param>
        /// <param name="p_blnResult"></param>
        /// <returns></returns>
        public bool m_blnValidatePatientRecipeByDoctor(string p_strPatientId, string p_strDoctorId)
        {
            bool blnResult = false;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            blnResult = objSvc.m_blnValidatePatientRecipeByDoctor(p_strPatientId, p_strDoctorId);
            objSvc.Dispose();
            objSvc = null;
            return blnResult;
        }
        #endregion

        #region 验证发票是否是当前医生所领
        /// <summary>
        /// 验证发票是否是当前医生所领
        /// </summary>
        /// <param name="p_strEmpId"></param>
        /// <param name="p_strInvoiceNo"></param>
        /// <returns></returns>
        public bool m_blnCheckInvoice(string p_strEmpId, string p_strInvoiceNo)
        {
            bool blnResult = false;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            blnResult = objSvc.m_blnCheckInvoice(p_strEmpId, p_strInvoiceNo);
            objSvc.Dispose();
            objSvc = null;
            return blnResult;
        }
        #endregion

        #region 处理选择性交费
        /// <summary>
        /// 处理选择性交费
        /// </summary>
        /// <param name="p_dtbChargeItem"></param>
        /// <param name="p_oprVO"></param>
        /// <param name="p_strOriginalRepiceId"></param>
        /// <returns></returns>
        public long m_lngSelectFeeDispose(Dictionary<string, List<string>> p_dicItemID, clsOutPatientRecipe_VO p_oprVO, string p_strOriginalRepiceId)
        {
            long lngRes = -1;

            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));

            lngRes = objSvc.m_lngSelectFeeDispose(p_dicItemID, p_oprVO, p_strOriginalRepiceId);
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="medid"></param>
        /// <param name="blnCmRecipe"></param>
        /// <param name="m_objMedStoreVo"></param>
        /// <returns></returns>
        public long m_lngGetsendmedinfoBypid(string pid, string medid, out clsMedStoreWindowsVo m_objMedStoreVo)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc));

            lngRes = objSvc.m_lngGetsendmedinfoBypid(pid, medid, false, out m_objMedStoreVo);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 根据PID获取患者当天发药信息(只要普通窗，合并药房之后用到)
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="medid"></param>
        /// <param name="blnCmRecipe"></param>
        /// <param name="m_objMedStoreVo"></param>
        /// <returns></returns>
        public long m_lngGetsendgeneralmedinfoBypid(string pid, string medid, out clsMedStoreWindowsVo m_objMedStoreVo)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc));

            lngRes = objSvc.m_lngGetsendgeneralmedinfoBypid(pid, medid, false, out m_objMedStoreVo);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        public long m_lngGetespecialwinNew(string deptid, string medid, out clsMedStoreWindowsVo objMedStoreVo)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc));

            lngRes = objSvc.m_lngGetespecialwin(objPrincipal, deptid, medid, out objMedStoreVo);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        /// <summary>
        /// 获取当前的配药窗口和发药窗口(也就是检查药房配药窗口中配药队列最小的窗口）
        /// </summary> 
        /// <param name="storageID">药房id</param>
        /// <param name="m_objWindowsVo">如果找不到合适的配药窗口和发药窗口，返回null</param>
        /// <param name="CheckScope">药房专用窗口是否可以接收所有科室处方 true 接收 false 禁止 参数：0057</param>
        /// <param name="m_blnWindowType">是否草药窗口标志：false-否；true-是</param>
        /// <param name="m_blnWindowRelation">配、发药窗口是否存在联系</param>
        /// <returns></returns>
        public long lngGetWindowIDByStorage(string storageID, out clsMedStoreWindowsVo m_objWindowsVo)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc));

            lngRes = objSvc.lngGetWindowIDByStorage(objPrincipal, storageID, out m_objWindowsVo, false, false, false);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        /// <summary>
        /// 获取窗口名
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long m_mthGetWindowName(out DataTable dtbResult)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc));

            lngRes = objSvc.m_mthGetWindowName(out dtbResult);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        public long lngOnlyGetSendWindowInfo(string m_strMedStoreid, out clsMedStoreWindowsVo m_objWindowsVo, bool m_blnWindowType)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPMedStore_Supported_Svc));

            lngRes = objSvc.lngOnlyGetSendWindowInfo(objPrincipal, m_strMedStoreid, out m_objWindowsVo, false);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #region 查询口服类用药用法ID
        /// <summary>
        /// 查询口服类用药用法ID
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        public long m_lngGetMedUsageID(string p_strParmCode, ref DataTable dtResult)
        {
            long lngRes = 0;

            #region 中间件操作
            clsOPChargeQuerySvc objServ = null;
            try
            {
                objServ = (clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPChargeQuerySvc));
                lngRes = objServ.m_lngGetMedUsageID(p_strParmCode, ref dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 先诊疗后结算调处方结算时，查出以前缴费的流水号
        /// <summary>
        /// 先诊疗后结算调处方结算时，查出以前缴费的流水号
        /// </summary>
        /// <param name="p_Recipe"></param>
        /// <param name="strseqid"></param>
        /// <returns></returns>
        public long m_lngGetRecipeByRecipeNo(string p_Recipe, out string strseqid)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                                                                (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            lngRes = objSvc.m_lngGetRecipeByRecipeNo(p_Recipe, out strseqid);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

        #region 根据病人ID查询病人是否符合先诊疗后结算
        /// <summary>
        /// 根据病人ID查询病人是否符合先诊疗后结算
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="dtResult"></param>
        /// <returns></returns>
        internal long m_lngGetIfVipByPatientID(string p_strPatientID, ref DataTable dtResult)
        {
            long lngRes = 0;

            #region 中间件操作
            clsOPChargeQuerySvc objServ = null;
            try
            {
                objServ = (clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPChargeQuerySvc));
                lngRes = objServ.m_lngGetIfVipByPatientID(p_strPatientID, ref dtResult);
            }
            catch (Exception exp)
            {
                Utility.clsLogText objLogger = new Utility.clsLogText();
                objLogger.LogError("连接中间件操作异常，" + exp.Message);
            }
            finally
            {
                if (objServ != null)
                {
                    objServ.Dispose();
                    objServ = null;
                }
            }
            #endregion
            return lngRes;
        }
        #endregion

        #region 社保患者查找当日就诊编号
        /// <summary>
        /// 社保患者查找当日就诊编号
        /// </summary>
        /// <param name="regDate"></param>
        /// <param name="deptId"></param>
        /// <param name="doctId"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public DataTable GetOpRegNo(string regDate, string deptId, string doctId, string pid)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeQuerySvc));

            DataTable dt = objSvc.GetOpRegNo(regDate, deptId, doctId, pid);
            objSvc.Dispose();
            return dt;
        }
        #endregion

        #region 社保患者写入当日就诊编号
        /// <summary>
        /// 社保患者写入当日就诊编号
        /// </summary>
        /// <param name="regNo"></param>
        /// <param name="regDate"></param>
        /// <param name="pid"></param>
        /// <param name="deptId"></param>
        /// <param name="doctId"></param>
        /// <param name="diagCode"></param>
        /// <returns></returns>
        public long SaveOpRegNo(string regNo, string regDate, string pid, string deptId, string doctId, string diagCode)
        {
            com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPChargeSvc));

            long ret = objSvc.SaveOpRegNo(regNo, regDate, pid, deptId, doctId, diagCode);
            objSvc.Dispose();
            return ret;
        }
        #endregion
    }
}
