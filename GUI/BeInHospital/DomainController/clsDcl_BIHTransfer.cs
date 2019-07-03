using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 住院进出转逻辑控制层
    /// </summary>
    class clsDcl_BIHTransfer : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        // 入院登记
        #region 获得辅助字典信息
        /// <summary>
        /// 获得辅助字典信息
        /// </summary>
        /// <param name="p_intCat">辅助字典类别</param>
        /// <param name="p_objResultArr">辅助字典信息</param>
        /// <returns></returns>
        public long m_lngGetAID_DICTArr(int p_intCat, out clsAIDDICT_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                    com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetAID_DICTArr(objPrincipal, p_intCat, out p_objResultArr);
        }
        #endregion

        #region 根据诊疗卡号或住院号获取病人ID
        /// <summary>
        /// 根据诊疗卡号或住院号获取病人ID
        /// </summary>
        /// <param name="p_intFindType">查找标识:0-诊疗卡号,1-住院号</param>
        /// <param name="p_strFindText">查找本文</param>
        /// <param name="p_strPatientID">病人ID</param>
        /// <returns></returns>
        public long m_lngGetPatientIDByCarIDOrInPatientID(int p_intFindType, string p_strFindText, out string p_strPatientID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                 com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetPatientIDByCarIDOrInPatientID(objPrincipal, p_intFindType, p_strFindText, out p_strPatientID);
        }
        #endregion

        #region 根据病人ID和入院类型获取在院记录数和入院次数
        /// <summary>
        /// 根据病人ID和入院类型获取在院记录数和入院次数
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_intInType">入院类型:1-正式,2-留观</param>
        /// <param name="p_objResult">病人最近一次住院信息</param>
        /// <returns></returns>
        public long m_lngGetLatestInHospitalInfo(string p_strPatientID, int p_intInType, out clsBIHpatientVO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetLatestInHospitalInfo(objPrincipal, p_strPatientID, p_intInType, out p_objResult);
        }
        #endregion

        #region 根据病人ID获取病人基本信息
        /// <summary>
        /// 根据病人ID获取病人基本信息
        /// </summary>
        /// <param name="p_strPatientid_chr">病人ID</param>
        /// <param name="p_objResult">人基本信息VO</param>
        /// <returns></returns>
        public long m_lngFindPatientInfoByPatientID(string p_strPatientid_chr, out clsPatient_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetPatientInfoByPatientID(objPrincipal, p_strPatientid_chr, out p_objResult);
        }

        /// <summary>
        /// 根据病人登记ID获取病人基本信息
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetPatientINfoByRegisterID(string p_strRegisterID, out clsPatient_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
       com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetPatientINfoByRegisterID(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region 根据入院登记ID获取病人住院信息
        /// <summary>
        /// 根据入院登记ID获取病人住院信息
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">病人住院信息</param>
        /// <returns></returns>
        public long m_lngGetBIHPatientInfoByRegID(string p_strRegisterID, out clsBIHpatientVO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBIHPatientInfoByRegID(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region 根据入院登记ID获取病人住院信息和收费信息
        /// <summary>
        /// 根据入院登记ID获取病人住院信息和收费信息
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_objResult">病人住院信息</param>
        /// <returns></returns>
        public long m_lngGetBIHPatientInfoAndCharge(string p_strRegisterID, out clsBIHpatientVO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBIHPatientInfoAndCharge(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region 根据病人ID获取病人入院登记信息(用于修改登记资料)
        /// <summary>
        /// 根据病人ID获取病人入院登记信息(用于修改登记资料)
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_objResult">入院登记信息</param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByPatientID(string p_strPatientID, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                      com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByPatientID(objPrincipal, p_strPatientID, out p_objResult);
        }
        /// <summary>
        /// 根据入院登号获取病人入院登记信息(用于修改登记资料)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_objResult"></param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByRegisterID(string p_strRegisterID, out clsT_Opr_Bih_Register_VO p_objRegisterVo)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByRegisterID(objPrincipal, p_strRegisterID, out p_objRegisterVo);
        }
        #endregion

        #region 根据病人ID获取病人入院登记信息(出院病人)
        /// <summary>
        /// 根据病人ID获取病人入院登记信息(出院病人)
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_objResult">入院登记信息</param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByPatientID(string p_strPatientID, string p_strPStatus, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                      com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByPatientID(objPrincipal, p_strPatientID, p_strPStatus, out p_objResult);
        }
        #endregion

        #region 病人入院登记
        /// <summary>
        /// 病人入院登记
        /// </summary>
        /// <param name="p_objParaVo">参数VO</param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="p_objPay">预交金信息</param>
        /// <param name="objBIHVO">病人住院信息</param>
        /// <returns></returns>
        public long m_lngPatientRegister(clsRegisterParameterVO p_objParaVo, clsPatient_VO objPatientVO, clsT_opr_bih_prepay_VO p_objPay, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngPatientRegister(objPrincipal, p_objParaVo, objPatientVO, p_objPay, ref objBIHVO);

        }
        #endregion

        #region 婴儿入院登记(新增)
        /// <summary>
        /// 婴儿入院登记（新增）
        /// </summary>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="objBIHVO">病人住院信息</param>
        /// <returns></returns>
        public long m_lngBabyRegister(clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngBabyRegister(objPrincipal, objPatientVO, objBIHVO);

        }
        #endregion

        #region 婴儿入院登记(修改)
        /// <summary>
        /// 婴儿入院登记（修改）
        /// </summary>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="objBIHVO">病人住院信息</param>
        /// <returns></returns>
        public long m_lngChangeBabyRegister(clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngChangeBabyRegister(objPrincipal, objPatientVO, objBIHVO);

        }
        #endregion

        #region 撤消入院
        /// <summary>
        /// 撤消入院
        /// </summary>
        /// <param name="p_objRecord">病人住院信息</param>
        /// <returns></returns>
        public long m_lngCancleBeInHospital(clsBIHpatientVO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngCancleBeInHospital(objPrincipal, p_objRecord);
        }
        #endregion

        #region 获取住院收费类别
        /// <summary>
        /// 获取住院收费类别
        /// </summary>
        /// <param name="p_objResultArr">费类别</param>
        /// <returns></returns>
        public long m_GetBIHPatientType(out com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_GetBIHPatientType(objPrincipal, out p_objResultArr);
        }
        #endregion

        #region 获取病人身份类别
        /// <summary>
        /// 获取病人身份类别
        /// </summary>
        /// <param name="p_objResultArr">身份类别</param>
        /// <returns></returns>
        public long m_GetPatientType(out com.digitalwave.iCare.ValueObject.clsPatientPayTypeVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_GetPatientType(objPrincipal, out p_objResultArr);
        }
        #endregion

        #region 根据入院登记ID获取登记信息
        /// <summary>
        /// 根据入院登记ID获取登记信息
        /// </summary>
        /// <param name="p_strRegisterID">根据入院登记ID</param>
        /// <param name="p_objResult">院登记信息</param>
        /// <returns></returns>
        public long m_lngGetRegisterInfoByID(string p_strRegisterID, out clsT_Opr_Bih_Register_VO p_objResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetRegisterInfoByID(objPrincipal, p_strRegisterID, out p_objResult);
        }
        #endregion

        #region 根据关联入院登记ID获取婴儿登记信息
        /// <summary>
        /// 根据关联入院登记ID获取婴儿登记信息
        /// </summary>
        /// <param name="p_strRegisterID">根据入院登记ID</param>
        /// <param name="p_objResult">院登记信息</param>
        /// <returns></returns>
        public long m_lngGetBabyRegisterInfoByID(string p_strRelateRegisterID, int p_intBornNum, out DataTable dtbBabyInfo)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBabyRegisterInfoByID(objPrincipal, p_strRelateRegisterID, p_intBornNum, out dtbBabyInfo);
        }
        #endregion

        #region 根据关联入院登记ID获取婴儿胎次
        /// <summary>
        /// 根据关联入院登记ID获取婴儿胎次
        /// </summary>
        /// <param name="p_strRegisterID">根据入院登记ID</param>
        /// <param name="p_objResult">院登记信息</param>
        /// <returns></returns>
        public long m_lngGetBabyBornNumByID(string p_strRelateRegisterID, ref int p_intBornNum)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBabyBornNumByID(objPrincipal, p_strRelateRegisterID, ref p_intBornNum);
        }

        public long m_lngGetBabyBornNumByID(string p_strRelateRegisterID, ref ArrayList arrBornNum)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBabyBornNumByID(objPrincipal, p_strRelateRegisterID, ref arrBornNum);
        }
        #endregion


        #region 根据ID号获取系统设置
        /// <summary>
        /// 根据ID号获取系统设置
        /// </summary>
        /// <param name="p_strSetingID">系统设置ID号</param>
        /// <param name="p_intSetstatus">状态</param>
        /// <returns></returns>
        public long m_lngGetSetingByID(string p_strSetingID, out int p_intSetstatus)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                        com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetSetingByID(objPrincipal, p_strSetingID, out p_intSetstatus);
        }
        #endregion

        #region 修改入院登记资料
        /// <summary>
        /// 修改入院登记资料
        /// </summary>
        /// <param name="p_intFlag">操作标识:0-不用修改调转表,1-需修改调转表</param>
        /// <param name="objPatientVO">病人基本信息</param>
        /// <param name="objBIHVO">入院登记信息</param>
        /// <returns></returns>
        public long m_lngEditRegister(int p_intFlag, clsPatient_VO objPatientVO, clsT_Opr_Bih_Register_VO objBIHVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngEditRegister(objPrincipal, p_intFlag, objPatientVO, objBIHVO);
        }
        #endregion

        // 床位管理

        #region 增加床位
        /// <summary>
        /// 增加床位
        /// </summary>
        /// <param name="p_strRecordID">床位流ID</param>
        /// <param name="p_objRecord">床位信息VO</param>
        /// <returns></returns>
        public long m_lngAddNewBed(out string p_strRecordID, clsT_Bse_Bed_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngAddNewBed(objPrincipal, out p_strRecordID, p_objRecord);
        }
        #endregion

        #region 根据床位ID修改床位信息
        /// <summary>
        /// 根据床位ID修改床位信息
        /// </summary>
        /// <param name="p_strRecordID">床位ID</param>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long m_lngModefyBedByID(clsT_Bse_Bed_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngModefyBedByID(objPrincipal, p_objRecord);
        }
        #endregion

        #region 根据床位ID删除床位
        /// <summary>
        ///  根据床位ID删除床位
        /// </summary>
        /// <param name="p_Bedid_chr">床位流水号</param>
        /// <returns></returns>
        public long m_lngDeleteBedInfoByByBedID(string p_Bedid_chr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngDeleteBedInfoByByBedID(objPrincipal, p_Bedid_chr);
        }
        #endregion

        #region 根据病区ID和床位状态获取病区床位简短信息
        /// <summary>
        /// 根据病区ID和床位状态获取病区床位简短信息
        /// </summary>
        /// <param name="p_strAreaid_chr">病区ID</param>
        /// <param name="p_strStatus">1=空床;2=占床;3=预约占床;4=包房占床</param>
        /// <returns></returns>
        public long m_lngGetBedShortInfoByAreaID(string p_strAreaid_chr, string p_strStatus, out clsT_Bse_Bed_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBedShortInfoByAreaID(objPrincipal, p_strAreaid_chr, p_strStatus, out p_objResultArr);
        }
        #endregion

        #region 根据床位ID获取床位信息
        /// <summary>
        /// 根据床位ID获取床位信息
        /// </summary>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_objResult">位信息VO</param>
        /// <returns></returns>
        public long m_lngGetBedInfoByBedID(string p_strBedID, out clsT_Bse_Bed_VO p_objResul)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetBedInfoByBedID(objPrincipal, p_strBedID, out p_objResul);
        }
        #endregion

        #region 获取有权限使用的病区信息列表
        /// <summary>
        /// 获取有权限使用的病区信息列表
        /// </summary>
        /// <param name="p_strAreaIDs">有权限使用的病区ID</param>
        /// <param name="p_objResultArr">有权限使用的病区信息列表ID</param>
        /// <returns></returns>
        public long m_lngGetAreaList(string p_strEmpID, out clsAreaInfoVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetAreaList(objPrincipal, p_strEmpID, out p_objResultArr);
        }
        #endregion

        #region 根据病区ID查询详细床位信息
        /// <summary>
        /// 根据病区ID查询详细床位信息
        /// </summary>
        /// <param name="p_strArearID">病区ID</param>
        /// <param name="p_ojbResultArr">床位详细信息</param>
        /// <returns></returns>
        public long m_lngGetBidInfoByArearID(string p_strArearID, out clsBedManageVO[] p_ojbResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));

            return objSvc.m_lngGetBedInfoByArearID(objPrincipal, p_strArearID, out p_ojbResultArr);
        }
        #endregion

        #region 根据病区ID查询未安排床位的病人信息
        /// <summary>
        /// 根据病区ID查询未安排床位的病人信息
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnInNA(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnInNA(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region 根据病区ID查询病区转入已接收病人
        /// <summary>
        /// 根据病区ID查询病区转入已接收病人
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnInA(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnInA(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region 根据病区ID查询病区转出未接收病人
        /// <summary>
        /// 根据病区ID查询病区转出未接收病人
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnOutNA(string p_strAreaID, out clsTransferVO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnOutNA(objPrincipal, p_strAreaID, out p_objResultArr);
        }
        #endregion

        #region 根据病区ID查询病区转出已接收病人
        /// <summary>
        /// 根据病区ID查询病区转出已接收病人
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetTurnOutA(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetTurnOutA(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region 获取除当前病区外全院未安排床位的病人
        /// <summary>
        /// 获取除当前病区外全院未安排床位的病人
        /// </summary>
        /// <param name="p_strAreaID">病区ID</param>
        /// <param name="p_dtbResult">查询结果</param>
        /// <returns></returns>
        public long m_lngGetAllUnArrangeBedPatient(string p_strAreaID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                    com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetAllUnArrangeBedPatient(objPrincipal, p_strAreaID, out p_dtbResult);
        }
        #endregion

        #region 判断新增床号已经存在
        /// <summary>
        /// 判断新增床号已经存在
        /// </summary>
        /// <param name="p_strAreaID_chr">病区号</param>
        /// <param name="p_strBedId">床号ID(可为空)</param>
        /// <param name="p_strCode_chr">床号</param>
        /// <returns></returns>
        public long IsExistBedByAreaIDAndCode(string p_strAreaID_chr, string p_strBedId, string p_strCode_chr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngCheckBedCode(objPrincipal, p_strAreaID_chr, p_strBedId, p_strCode_chr);
        }
        #endregion

        #region 安排床位
        /// <summary>
        /// 安排床位
        /// </summary>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        public long m_lngArrangeBed(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngArrangeBed(objPrincipal, p_objRecord);
        }

        public long m_lngArrangeBed(clsT_Opr_Bih_Transfer_VO p_objRecord, clsT_Opr_Bih_Register_VO p_objRegisterVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngArrangeBed(objPrincipal, p_objRecord, p_objRegisterVO);
        }
        #endregion

        #region 设置主治医生和诊断(在床位编辑时用到)
        /// <summary>
        /// 设置主治医生和诊断(在床位编辑时用到)
        /// </summary>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        public long m_lngModifyRegInfo(clsT_Opr_Bih_Register_VO objPatientVO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngModifyRegInfo(objPrincipal, objPatientVO);
        }
        #endregion

        #region 查找入院诊断(ICD10)信息
        /// <summary>
        /// 查找入院诊断(ICD10)信息
        /// </summary>
        /// <param name="p_strName">姓名</param>
        /// <param name="p_dtbRecord">结果</param>
        /// <returns></returns>
        public long m_lngFindICD10(string p_strFind, out DataTable p_dtbRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngFindICD10(objPrincipal, p_strFind, out p_dtbRecord);
        }
        #endregion

        #region 转出
        /// <summary>
        /// 转出
        /// </summary>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        public long m_lngTurnOut(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngTurnOut(objPrincipal, p_objRecord);
        }
        #endregion

        #region 撤消转区
        /// <summary>
        /// 撤消转区
        /// </summary>
        /// <param name="p_objRecord">调转信息</param>
        /// <returns></returns>
        public long m_lngUnDoTurnOut(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                      com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUnDoTurnOut(objPrincipal, p_objRecord);
        }
        #endregion

        #region 转床
        /// <summary>
        /// 转床
        /// </summary>
        /// <param name="p_objRecord">修改信息</param>
        /// <returns></returns>
        public long m_lngTurnBed(clsT_Opr_Bih_Transfer_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngTurnBed(objPrincipal, p_objRecord);
        }
        #endregion

        #region 包床
        /// <summary>
        /// 包床
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_strOperateID">操作员ID</param>
        /// <returns></returns>
        public long m_lngWarpBed(string p_strRegisterID, string p_strBedID, string p_strOperateID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                         com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngWarpBed(objPrincipal, p_strRegisterID, p_strBedID, p_strOperateID);
        }
        #endregion

        #region 撤消包床
        /// <summary>
        /// 撤消包床
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_strBedID">床位ID</param>
        /// <param name="p_strOperateID">操作人ID</param>
        /// <returns></returns>
        public long m_lngUndoWarpBed(string p_strBedID, string p_strOperateID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                              com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUndoWarpBed(objPrincipal, p_strBedID, p_strOperateID);
        }
        #endregion

        #region 请假
        /// <summary>
        /// 请假
        /// </summary>
        /// <param name="p_objRecord">请假VO</param>
        /// <returns></returns>
        public long m_lngHoliday(clsHolidayRecord_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngHoliday(objPrincipal, p_objRecord);
        }
        #endregion

        #region 撤消请假
        /// <summary>
        /// 撤消请假
        /// </summary>
        /// <param name="p_objRecord">请假VO</param>
        /// <returns></returns>
        public long m_lngUndoHoliday(clsHolidayRecord_VO p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                     com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUndoHoliday(objPrincipal, p_objRecord);
        }
        #endregion

        #region 查询包床
        public long m_lngQueryPatientInfoByOccupiedBedid(string Bedid, out DataTable dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
            return objSvc.m_lngQueryPatientInfoByOccupiedBedid(Bedid, out dtbResult);
        }
        #endregion

        #region 普通号->留观号
        /// <summary>
        /// 普通号->留观号
        /// </summary>
        /// <param name="m_strRegisterid_chr">原登记流水号</param>
        /// <param name="oldInpatientid_chr">原住院号</param>
        /// <param name="oldinpatientnotype_int">旧登记类型(1-正常,2-留观)</param>
        /// <param name="newinpatientnotype_int">新登记类型(1-正常,2-留观)</param>
        /// <param name="m_strHead">新住院号头标识</param>
        /// <param name="m_strMain">新住院号数字部份</param>
        /// <param name="m_intSour">1,新最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <returns></returns>
        public long m_lngChangePatientIDOth(string m_strRegisterid_chr, string oldInpatientid_chr, int oldinpatientnotype_int, int newinpatientnotype_int, string m_strHead, string m_strMain, int m_intSour)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngChangePatientIDOth(objPrincipal, m_strRegisterid_chr, oldInpatientid_chr, oldinpatientnotype_int, newinpatientnotype_int, m_strHead, m_strMain, m_intSour);


        }
        #endregion

        #region 留观号->普通号
        /// <summary>
        /// 普通号->留观号
        /// </summary>
        /// <param name="m_strRegisterid_chr">原登记流水号</param>
        /// <param name="oldInpatientid_chr">原住院号</param>
        /// <param name="oldinpatientnotype_int">旧登记类型(1-正常,2-留观)</param>
        /// <param name="newinpatientnotype_int">新登记类型(1-正常,2-留观)</param>
        /// <param name="m_strHead">新住院号头标识</param>
        /// <param name="m_strMain">新住院号数字部份</param>
        /// <param name="m_intSour">1,新最大值来源于历史记录，2来源于最大值,0其它</param>
        /// <returns></returns>
        public long m_lngChangePatientIDNor(string m_strRegisterid_chr, string oldInpatientid_chr, int oldinpatientnotype_int, int newinpatientnotype_int, string m_strHead, string m_strMain, int m_intSour)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngChangePatientIDNor(objPrincipal, m_strRegisterid_chr, oldInpatientid_chr, oldinpatientnotype_int, newinpatientnotype_int, m_strHead, m_strMain, m_intSour);


        }
        #endregion

        #region 根据病人姓名、性别查找历史信息
        public long GetHisPatientByName(string name, string sex, out DataTable dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetHisPatientByName(objPrincipal, name, sex, out dtbResult);
        }
        #endregion

        #region  根据入院登记ID判断病人是否存在转区或出院记录
        /// <summary>
        ///  根据入院登记ID判断病人是否存在转区或出院记录
        /// </summary>
        /// <param name="p_strRegisterID_chr">入院登记号</param>
        /// <returns></returns>
        public long CheckTranOrOut(string p_strRegisterID_chr)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.CheckTranOrOut(objPrincipal, p_strRegisterID_chr);
        }
        #endregion

        #region  根据入院登记ID获取病人最早的医嘱时间
        /// <summary>
        ///  根据入院登记ID获取病人最早的医嘱时间
        /// </summary>
        /// <param name="p_strRegisterID_chr">入院登记号</param>
        /// <param name="p_strFirstOrderDate"></param>
        /// <returns></returns>
        public long GetFirstOrderDateByRegId(string p_strRegisterID_chr, out string p_strFirstOrderDate)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetFirstOrderDateByRegId(objPrincipal, p_strRegisterID_chr, out p_strFirstOrderDate);
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
            return lngRes;
        }
        #endregion

        #region 根据入院登记ID获取病人病情信息
        /// <summary>
        /// 根据入院登记ID获取病人病情信息
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long GetPatientStateByRegID(string p_strRegisterID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetPatientStateByRegID(objPrincipal, p_strRegisterID, out p_dtbResult);
        }
        #endregion

        #region 根据入院登记ID获取病人有效饮食护理信息
        /// <summary>
        /// 根据入院登记ID获取病人有效饮食护理信息
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long GetPatientNurseByRegID(string p_strRegisterID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetPatientNurseByRegID(objPrincipal, p_strRegisterID, out p_dtbResult);
        }
        #endregion

        #region 根据员工ID获取默认的科室
        /// <summary>
        /// 根据员工ID获取默认的科室
        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtbResult">默认科室信息</param>
        /// <returns></returns>
        public long GetDeptByEmpID(string p_strEmpID, out DataTable p_dtbResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetDeptByEmpID(objPrincipal, p_strEmpID, out p_dtbResult);
        }
        #endregion

        #region 根据病区Id获取父级部门ID
        /// <summary>
        /// 根据病区Id获取父级部门ID
        /// </summary>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strParentId">父级部门ID</param>
        /// <returns></returns>
        public long GetParentIdByDeptId(string p_strDeptID, out string p_strParentId)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.GetParentIdByDeptId(objPrincipal, p_strDeptID, out p_strParentId);
        }
        #endregion

        #region 增加资料变动记录
        /// <summary>
        /// 增加资料变动记录
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long AddPatienInfLog(clsPatientInfLog p_objRecord)
        {
            com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc));
            return objSvc.AddPatienInfLog(objPrincipal, p_objRecord);
        }
        #endregion

        #region 查询资料变动信息
        /// <summary>
        /// 查询资料变动信息
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <returns></returns>
        public long GetPatienInfLog(DateTime p_dtStartDate, DateTime p_dtEndDate, out DataTable p_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatienInfLogSvc));
            return objSvc.GetLogByDate(objPrincipal, p_dtStartDate, p_dtEndDate, out p_dtResult);
        }
        #endregion


        //////////////////////////////////////////////////
        //转出时对包床进行操作 2007.09.03 谢云杰添加
        /////////////////////////////////////////////////

        #region 检查病人转出时还是否存在包床
        /// <summary>
        /// 检查病人转出时还是否存在包床
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="intRowCount"></param>
        /// <returns></returns>
        public long m_lngGetWarpBedByRegID(string p_strRegisterID, ref int intRowCount)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                  com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngGetWarpBedByRegID(p_strRegisterID, ref intRowCount);
        }
        #endregion

        #region 撤消病人的所有包床
        /// <summary>
        /// 撤消病人的所有包床
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strOperateID"></param>
        /// <returns></returns>
        public long m_lngUndoWarpBedByRegID(string p_strRegisterID, string p_strOperateID)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            return objSvc.m_lngUndoWarpBedByRegID(p_strRegisterID, p_strOperateID);
        }
        #endregion


        #region 获取病人在门诊未交费处方
        /// <summary>
        /// 获取病人在门诊未交费处方
        /// </summary>
        /// <param name="p_strPaitneNo">病人住院号或诊疗号</param>
        /// <param name="p_intType">1-住院号查询，2-诊疗号查询</param>
        /// <param name="p_lstRecipeNoPay_VO">返回结果VO</param>
        /// <returns></returns>
        public long m_lngGetPatientRecipeNopay(string p_strPaitneNo, int p_intType, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngGetPatientRecipeNopay(p_strPaitneNo,p_intType,out p_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion


        #region 查询病人在门诊未交费处方
        /// <summary>
        /// 获取病人在门诊未交费处方
        /// </summary>
        /// <param name="p_strPaitneNo">病人住院号或诊疗号</param>
        /// <param name="p_intType">1-住院号查询，2-诊疗号查询</param>
        /// <param name="p_lstRecipeNoPay_VO">返回结果VO</param>
        /// <returns></returns>
        public long m_lngGetPatientRecipeNopayZY(string p_strPaitneNo, int p_intType, out System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngGetPatientRecipeNopayZY(p_strPaitneNo, p_intType, out p_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion
        #region 关联未交费用处方号到住院信息表里
        /// <summary>
        /// 关联未交费用处方号到住院信息表里
        /// </summary>
        /// <param name="p_lstRecipeNoPay_VO">需关联的数据VO LIST</param>
        /// <returns></returns>
        public long m_lngInsertPatientNopayRecipeZY(System.Collections.Generic.List<clsRecipeNoPay_VO> p_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngInsertPatientNopayRecipeZY(p_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion

        #region 重算病人门诊未交费用处方
        /// <summary>
        /// 重算病人门诊未交费用处方
        /// </summary>
        /// <param name="p_strPatientNO">住院号或诊疗号</param>
        /// <param name="p_intType">1为住院号,2为诊疗号查询</param>
        /// <param name="p_lstNoPayRecipe">处方ID</param>
        /// <param name="p_lstRecipeNoPay_VO">新的未交费处方VO</param>
        /// <returns></returns>
        public long m_lngReSetPatientNoPayRecipe(string p_strPatientNO,int p_intType,System.Collections.Generic.List<string> p_lstNoPayRecipe, out System.Collections.Generic.List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO)
        {
            com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHTransferSvc));
            long lngRes = objSvc.m_lngReSetPatientNoPayRecipe(p_strPatientNO, p_intType, p_lstNoPayRecipe, out m_lstRecipeNoPay_VO);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;
        }
        #endregion
    }
}
