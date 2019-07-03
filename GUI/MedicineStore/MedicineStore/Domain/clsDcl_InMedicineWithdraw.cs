using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.common;
using com.digitalwave.EMR_EmployeeManagerService;


namespace com.digitalwave.iCare.gui.MedicineStore
{
    class clsDcl_InMedicineWithdraw : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        internal long m_lngGetBaseMedicine(string p_strAssistCode, string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInventoryRecordSVC));
            lngRes = objSvc.m_lngGetBaseMedicine(objPrincipal, p_strAssistCode, p_strStorageID, out p_dtbMedicine);
            return lngRes;
        }
        #endregion

        #region 查找员工
        /// <summary>
        /// 查找员工
        /// </summary>
        /// <param name="p_strSearch">搜索字符</param>
        /// <param name="p_dtbEMP">员工</param>
        /// <returns></returns>
        internal long m_lngGetEMP(string p_strSearch, out DataTable p_dtbEMP)
        {
            long lngRes = 0;
            clsEMR_EmployeeManagerService objSvc =
                (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService));
            lngRes = objSvc.m_lngGetEmpArrByIDOrNameLike(p_strSearch, out p_dtbEMP);
            return lngRes;
        }
        #endregion

        #region 获取药品类型信息

        public long m_lngGetResultByMedicineType(out clsValue_MedicineType_VO[] p_objData)
        {
            long lngRes = 0;
            //com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC objSvc =(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDemoMiddleTierSVC));

            //创建中间件COM对象
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetMedicineTypeData(objPrincipal, out p_objData);
            return lngRes;
        }
        #endregion

        #region 获取仓库名


        /// <summary>
        /// 获取仓库名


        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <param name="p_strStoreRoomName">仓库名</param>
        /// <returns></returns>
        internal long m_lngGetStoreRoomName(string p_strStoreRoomID, out string p_strStoreRoomName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStoreRoomID, out p_strStoreRoomName);
            return lngRes;
        }
        #endregion

        #region 获取当前员工是否有药库管理角色


        /// <summary>
        /// 获取当前员工是否有药库管理角色


        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有药库管理角色</param>
        /// <returns></returns>
        internal long m_lngCheckEmpHasRole(string p_strEmpID, out bool p_blnHasRole)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngCheckEmpHasRole(objPrincipal, p_strEmpID, "药库管理", out p_blnHasRole);
            return lngRes;
        }
        #endregion

        #region 获取药品内退数据

        /// <summary>
        /// 获取药品内退数据

        /// </summary>
        /// <param name="objvalue_Param">查询条件D</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        internal long m_lngGetMedicineInnerWithdrawData(ref clsMs_InMedicineWithdrawQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetMedicineInnerWithdrawData(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_intFormID">单据类型</param>
        /// <param name="p_dtbMoney">金额</param>
        /// <returns></returns>
        internal long m_lngGetAllInMoney(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, int p_intFormID, out DataTable p_dtbMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngGetAllInMoney(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, p_intFormID, out p_dtbMoney);
            return lngRes;
        }
        #endregion

        #region 获取药品内退明细数据

        /// <summary>
        /// 获取药品内退明细数据

        /// </summary>
        /// <param name="objvalue_Param">查询条件D</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        internal long m_lngGetMedicineInnerWithdrawDetailData(ref clsMs_MedicineWithdrawDetailQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetMedicineInnerWithdrawDetailData(objPrincipal,ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 审核时获取药品内退明细数据

        /// <summary>
        /// 审核时获取药品内退明细数据

        /// </summary>
        /// <param name="objvalue_Param">查询条件D</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        internal long m_lngDclGetWithdrawDetailData(long lngSEQ, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetWithdrawDetailData(objPrincipal, lngSEQ, ref dtbResult);
            return lngRes;
        }
        #endregion


        #region 获取入库明细表内容


        /// <summary>
        /// 获取入库明细表内容


        /// </summary>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal long m_lngGetInstorageDetal(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetInstorageDetal(objPrincipal, p_lngSeries2ID, out p_dtbValue);
            return lngRes;
        }
        #endregion


        #region 获取药品出库数据

        /// <summary>
        /// 获取药品出库数据

        /// </summary>
        /// <param name="objvalue_Param">查询条件D</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageMainData(ref clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetOutStorageMainData(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取出库明细数据

        /// <summary>
        /// 获取出库明细数据

        /// </summary>
        /// <param name="objvalue_Param">查询条件D</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailData(ref clsMs_OutStorageDetailQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetOutStorageDetailData(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion


        #region 制单时获取出库明细数据


        /// <summary>
        /// 制单时获取出库明细数据


        /// </summary>
        /// <param name="objvalue_Param">查询条件D</param>
        /// <param name="dtbResult">结果集</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailData_MakerBill(ref clsMs_MedicineWithdrawOutStorageQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));

            lngRes = objSvc.m_lngGetOutStorageDetailData_MadkerBill(objPrincipal, ref objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取已退药数量

        /// <summary>
        /// 获取已退药数量

        /// </summary>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="m_objMedicineWithdrawSum">退药数量</param>
        /// <returns></returns>
        internal long m_lngGetMedicineWithdrawSum(ref clsMs_MedicineWithdrawNumQueryCondition_VO objvalue_Param, ref DataTable m_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngGetMedicineWithdrawSum(objPrincipal, ref  objvalue_Param, ref m_dtbResult);
            return lngRes;
        }
        #endregion

        #region 获取药品当前库存
        /// <summary>
        /// 获取药品当前库存
        /// </summary>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="m_objMedicineWithdrawSum">结果集</param>
        /// <returns></returns>
        internal long m_lngGetMedicineRealGross(ref clsMs_MedicineWithdrawNumQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngGetMedicineRealGross(objPrincipal, ref  objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 退审时获取当前库存、实际库存、可用库存

        /// <summary>
        /// 退审时获取当前库存、实际库存、可用库存

        /// </summary>
        /// <param name="objvalue_Param"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        internal long m_lngDclGetMedicineGross(ref clsMs_MedicineWithdrawNumQueryCondition_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngGetMedicineGross(objPrincipal, ref  objvalue_Param, ref dtbResult);
            return lngRes;
        }
        #endregion

        #region 添加入库主表
        /// <summary>
        /// 添加入库主表
        /// </summary>
        /// <param name="p_objISVO">入库主表</param>
        /// <param name="p_lngSEQ">序列号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <returns></returns>
        internal long m_lngAddNewInStorage(clsMS_InStorage_VO p_objISVO, out long p_lngSEQ, out string p_strInStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngAddNewInStorage(objPrincipal, p_objISVO, out p_lngSEQ, out p_strInStorageID);
            return lngRes;
        }
        #endregion

        #region 修改入库主表
        /// <summary>
        /// 修改入库主表
        /// </summary>
        /// <param name="p_objISVO">入库主表内容</param>
        /// <returns></returns>
        internal long m_lngModifyInStorage(clsMS_InStorage_VO p_objISVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngModifyInStorage(objPrincipal, p_objISVO);
            return lngRes;
        }
        #endregion

        #region 添加入库明细
        /// <summary>
        /// 添加入库明细
        /// </summary>
        /// <param name="p_objDetailArr">入库明细内容</param>
        /// <returns></returns>
        internal long m_lngAddInStorageDetail(ref clsMS_InStorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngAddInStorageDetail(objPrincipal, ref p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region 修改入库明细
        /// <summary>
        /// 修改入库明细
        /// </summary>
        /// <param name="p_objDetailArr">入库明细</param>
        /// <returns></returns>
        internal long m_lngModifyInStorageDetail(clsMS_InStorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngModifyInStorageDetail(objPrincipal, p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region 删除指定入库主表信息
        /// <summary>
        /// 删除指定入库主表信息
        /// </summary>
        /// <param name="p_lngSeriesID">入库主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteMainInStorage(long p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngDeleteMainInStorage(objPrincipal, p_lngSeriesID);
            return lngRes;
        }

        /// <summary>
        /// 删除指定入库主表信息
        /// </summary>
        /// <param name="p_lngSeriesID">入库主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteMainInStorage(long[] p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngDeleteMainInStorage(objPrincipal, p_lngSeriesID);
            return lngRes;
        }
        #endregion

        #region 删除指定入库明细
        /// <summary>
        /// 删除指定入库明细
        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <param name="p_lngSeq">序列</param>
        /// <returns></returns>
        internal long m_lngDeleteInStorage(int p_intStatus, long p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngUpdateInStorageStatus(objPrincipal, p_intStatus, p_lngSeq);
            return lngRes;
        }

        /// <summary>
        /// 删除选定药品
        /// </summary>
        /// <param name="p_lngSEQ">明细表序列</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">药品批号</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_dcmCallPrice">购入单价</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <returns></returns>
        internal long m_lngDeleteInStorage(long p_lngSEQ, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, string p_strStorageID, string p_strVendorID, decimal p_dcmCallPrice, bool p_blnIsCommit)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngDelete(objPrincipal, p_lngSEQ, p_strMedicineID, p_strLotNO, p_strInStorageID, p_strStorageID, p_strVendorID, p_dcmCallPrice, p_blnIsCommit);
            return lngRes;
        }
        #endregion

        #region 增加库存主表当前库存
        internal long m_lngModifyStorageMain(clsMS_StorageGrossForOut p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageGross(objPrincipal, p_objRecord);
            return lngRes;
        }

        #endregion

        #region 减少库存主表当前库存
        internal long m_lngSubModifyStorageMain(clsMS_StorageGrossForOut p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageGross(objPrincipal, p_objRecord);
            return lngRes;
        }

        #endregion

        #region 添加库存明细表库存数量(实际库存)
        internal long m_lngDclAddStorageDetailRealGross(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailRealGross(objPrincipal, p_objOutArr);
            return lngRes;
        }

        #endregion

        #region 减少库存明细表库存数量(实际库存)
        internal long m_lngDclSubStorageDetailRealGross(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailRealGross(objPrincipal, p_objOutArr);
            return lngRes;
        }

        #endregion

        #region 添加库存明细表库存数量(出库删除未审核记录时只添加可用库存)
        /// <summary>
        /// 添加库存明细表库存数量(出库删除未审核记录时只添加可用库存)
        /// </summary>
        /// <param name="p_objISVO">库存明细表内容</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailAvailaGrossDcl(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailAvailaGross(objPrincipal,p_objOutArr);
            return lngRes;
        }
        #endregion

        #region 减少库存明细表库存数量(保存出库时只对可用库存作修改)
        /// <summary>
        /// 减少库存明细表库存数量(保存出库时只对可用库存作修改)
        /// </summary>
        /// <param name="p_objISVO">库存明细表内容</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailAvailaGrossDcl(clsMS_StorageDetail[] p_objDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailAvailaGross(objPrincipal, p_objDetail);
            return lngRes;
        }
        #endregion


        #region 检查入库后是否对该批药品作其它操作，如出库，外退，内退
        /// <summary>
        /// 检查入库后是否对该批药品作其它操作，如出库，外退，内退
        /// </summary>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnHasDone">是否已做其它操作</param>
        /// <param name="p_strID">单据号</param>
        /// <returns></returns>
        internal long m_lngCheckHasDoneAfterInStorage(string p_strInStorageID, out bool p_blnHasDone, out string p_strID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngCheckHasDoneAfterInStorage(objPrincipal, p_strInStorageID, out p_blnHasDone, out p_strID);
            return lngRes;
        }
        #endregion

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal long m_lngGetCommitFlow(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5005", out p_intCommitFolw);
            return lngRes;
        }
        #endregion


        #region 设置审核者


        /// <summary>
        /// 设置审核者


        /// </summary>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        internal long m_lngSetCommitUser(string p_strEmpID, long[] p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngSetCommitUser(objPrincipal, p_strEmpID, p_lngSeq);
            return lngRes;
        }
        #endregion

        #region 退审


        /// <summary>
        /// 退审


        /// </summary>
        /// <param name="p_lngSeq">序列号</param>
        /// <returns></returns>
        internal long m_lngUnCommit(long[] p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, p_lngSeq);
            return lngRes;
        }
        #endregion


        //获取内退明细表 (报表打印)
        public long m_lngGetOutStorageDetailData_report(string id, out DataTable dtb)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailData_report(id,out dtb);
            
            return lngRes;
        }

        #region 审核内退
        /// <summary>
        /// 审核内退
        /// </summary>
        /// <param name="p_objStGross">库存信息</param>
        /// <param name="p_objAccDetailArr">药品入帐明细</param>
        /// <param name="p_strEmpID">员工ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_lngInSEQ">主表序列</param>
        /// <param name="p_strInStorageID">内退单据号</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        public long m_lngCommit(clsMS_StorageDetail[] p_objStGross, clsMS_AccountDetail_VO[] p_objAccDetailArr, string p_strEmpID, DateTime p_dtmCommitDate, long p_lngInSEQ, string p_strInStorageID, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngCommit(objPrincipal, p_objStGross, p_objAccDetailArr, p_strEmpID, p_dtmCommitDate, p_lngInSEQ, p_strInStorageID, p_blnIsImmAccount);

            return lngRes;
        } 
        #endregion

        #region 退审

        /// <summary>
        /// 退审

        /// </summary>
        /// <param name="p_objStGross">药品库存信息</param>
        /// <param name="p_lngInSEQ">内退主表序列</param>
        /// <param name="p_strInStorageID">内退单据号</param>
        /// <returns></returns>
        public long m_lngUnCommit(clsMS_StorageDetail[] p_objStGross, long p_lngInSEQ, string p_strInStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngUnCommit(objPrincipal, p_objStGross, p_lngInSEQ, p_strInStorageID);

            return lngRes;
        }
        #endregion

        #region 保存内退
        /// <summary>
        /// 保存内退
        /// </summary>
        /// <param name="p_objMain">主表记录</param>
        /// <param name="p_objOldDetailArr">旧记录药品信息</param>
        /// <param name="p_objNewDetailArr">新增药品</param>
        /// <param name="p_objModifyDetailArr">修改药品</param>
        /// <param name="p_objAccDetailArr">帐本明细</param>
        /// <param name="p_objStDetailArr">当前药品库存信息</param>
        /// <param name="p_blnIsAddNew">是否新增</param>
        /// <param name="p_blnHasCommit">是否已审核</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strInStorageID">内退单据号</param>
        /// <returns></returns>
        public long m_lngSave(clsMS_InStorage_VO p_objMain, clsMS_StorageDetail[] p_objOldDetailArr, ref clsMS_InStorageDetail_VO[] p_objNewDetailArr, clsMS_InStorageDetail_VO[] p_objModifyDetailArr, clsMS_AccountDetail_VO[] p_objAccDetailArr,
            clsMS_StorageDetail[] p_objStDetailArr, bool p_blnIsAddNew, bool p_blnHasCommit, bool p_blnIsCommit, bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strInStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMiddletier_InStorageMedicineWithdrawSVC));
            lngRes = objSvc.m_lngSaveMedicine(objPrincipal, p_objMain, p_objOldDetailArr, ref p_objNewDetailArr, p_objModifyDetailArr, p_objAccDetailArr, p_objStDetailArr, p_blnIsAddNew, p_blnHasCommit, p_blnIsCommit, p_blnIsImmAccount, out p_lngMainSEQ, out p_strInStorageID);

            return lngRes;
        }        
        #endregion

        #region 获取药品类型批号,有效期控制信息

        /// <summary>
        /// 获取药品类型批号,有效期控制信息

        /// </summary>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_objTypeVO"></param>
        /// <returns></returns>
        internal long m_lngGetMedicineTypeVisionm(string p_strMedicineTypeID, out clsMS_MedicineTypeVisionmSet p_objTypeVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMedicineTypeVisionmSetSVC));
            lngRes = objSvc.m_lngGetMedicineTypeVisionm(objPrincipal, p_strMedicineTypeID, out p_objTypeVO);
            return lngRes;
        }
        #endregion

        #region  获取最后帐务结转的结束日期
        /// <summary>
        ///  获取最后帐务结转的结束日期
        /// </summary>
        /// <returns></returns>
        public long m_mthGetAccountperiodTime(out DateTime datAccountperiodTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetAccountperiodTime(objPrincipal, out datAccountperiodTime);
            return lngRes;
        }
        #endregion

        #region 获取内退单报表类型


        /// <summary>
        /// 获取内退单报表类型


        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5020", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 杨镇伟09-10-30:添加查询内退单据状态
        /// <summary>
        /// 查询内退单据状态
        /// </summary>
        /// <param name="p_strSerId">单据号</param>
        /// <param name="p_strStatus">返回的状态</param>
        public long m_lngReturnInStroageStatus(string p_strSerId, out string p_strStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngReturnInStroageStatus(p_strSerId, out p_strStatus);
            return lngRes;
        }
        #endregion
    }
}
