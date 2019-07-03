using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品入库
    /// </summary>
    public class clsDcl_Purchase : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 获取入库主表内容
        /// <summary>
        /// 获取入库主表内容
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        internal long m_lngGetInStorage(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetInStorage(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, out p_dtbValue);
            return lngRes;
        }

        /// <summary>
        /// 获取入库主表内容
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicinePreptype">药品剂型</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        internal long m_lngGetInStorage(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName, string p_strInStorageID,string p_strMedicinePreptype, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetInStorage(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, p_strMedicineName,p_strVendorName,p_strInStorageID,p_strMedicinePreptype,out p_dtbValue);
            return lngRes;
        }

        /// <summary>
        /// 获取入库主表内容（多类型）
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicinePreptype">药品剂型</param>
        /// <param name="p_intInStorageTypeID">入库类型</param>
        /// <param name="p_dtbValue">主表内容</param>
        /// <returns></returns>
        internal long m_lngGetInStorage(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName, string p_strInStorageID, string p_strMedicinePreptype,int p_intInStorageTypeID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetInStorage(objPrincipal, p_dtmBeginDate, p_dtmEndDate, p_strStorageID, p_strMedicineName, p_strVendorName, p_strInStorageID, p_strMedicinePreptype,p_intInStorageTypeID, out p_dtbValue);
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

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        /// <param name="p_objMPVO">药品制剂类型</param>
        /// <returns></returns>
        internal long m_lngGetMedicinePreptype(out clsMEDICINEPREPTYPE_VO[] p_objMPVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetMedicinePreptype(objPrincipal, out p_objMPVO);
            return lngRes;
        }
        #endregion

        #region 获取指定仓库的药品类型

        /// <summary>
        /// 获取指定仓库的药品类型

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMTVO">药品制剂类型</param>
        /// <returns></returns>
        internal long m_lngGetStorageMedicineType(string p_strStorageID, out clsMS_MedicineType_VO[] p_objMTVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStorageMedicineType(objPrincipal,p_strStorageID, out p_objMTVO);
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
            lngRes = objSvc.m_lngCheckEmpHasRole(objPrincipal, p_strEmpID,"药库管理", out p_blnHasRole);
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
            lngRes = objSvc.m_lngUnCommit(objPrincipal,  p_lngSeq);
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
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetStoreRoomName(objPrincipal, p_strStoreRoomID, out p_strStoreRoomName);
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
        /// <param name="p_dtbMoney">金额</param>
        /// <returns></returns>
        internal long m_lngGetAllInMoney(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out DataTable p_dtbMoney)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetAllInMoney(objPrincipal, p_dtmBegin, p_dtmEnd, p_strStorageID, out p_dtbMoney);
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

        /// <summary>
        /// 检查入库后是否对该批药品作出库操作
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnHasDone">是否有作出库操作</param>
        /// <param name="p_strID">单据号</param>
        /// <returns></returns>
        internal long m_lngCheckHasOutAfterInStorage(string p_strInStorageID, out bool p_blnHasDone, out string p_strID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngCheckHasOutAfterInStorage(objPrincipal, p_strInStorageID, out p_blnHasDone, out p_strID);
            return lngRes;
        }
        #endregion

        #region 审核入库单


        /// <summary>
        /// 审核入库单
        /// </summary>
        /// <param name="p_objStDetailArr">库存明细表内容</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_lngOutSEQ">入库主表序列</param>
        /// <param name="p_intFormType">入库类型</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngCommitInStorage(clsMS_StorageDetail[] p_objStDetailArr, string p_strEmpID, DateTime p_dtmCommitDate, long p_lngOutSEQ, int p_intFormType,string p_strInStorageID, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngCommitInStorage(objPrincipal, p_objStDetailArr, p_strEmpID, p_dtmCommitDate, p_lngOutSEQ, p_intFormType, p_strInStorageID,p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region 审核入库单(即入即出)


        /// <summary>
        /// 审核入库单
        /// </summary>
        /// <param name="p_objStDetailArr">库存明细表内容</param>
        /// <param name="p_strEmpID">审核人ID</param>
        /// <param name="p_dtmCommitDate">审核日期</param>
        /// <param name="p_lngOutSEQ">入库主表序列</param>
        /// <param name="p_intFormType">入库类型</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngCommitInStorage(clsMS_StorageDetail[] p_objStDetailArr, string p_strEmpID, DateTime p_dtmCommitDate, long p_lngOutSEQ, int p_intFormType,string p_strInStorageID, bool p_blnIsImmAccount, ref clsMS_OutStorage_VO p_objOutMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewOutDetailArr, bool p_lngIsAddNew)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngCommitInStorage(objPrincipal, p_objStDetailArr, p_strEmpID, p_dtmCommitDate, p_lngOutSEQ, p_intFormType, p_strInStorageID, p_blnIsImmAccount, ref p_objOutMain, null, ref p_objNewOutDetailArr, p_lngIsAddNew);
            return lngRes;
        }
        #endregion

       
        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strChittyIDArr">入库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与入库单据号一一对应)</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        internal long m_lngInAccount(string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_strChittyIDArr, p_lngMainSEQ, p_strStorageID, p_strEmpID, p_dtmAccountDate);
            return lngRes;
        }
        #endregion
        #region 入帐(即入即出)
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strChittyIDArr">入库单据号(须与主表序列一一对应)</param>
        /// <param name="p_lngMainSEQ">主表序列(须与入库单据号一一对应)</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strEmpID">入帐员工ID</param>
        /// <param name="p_dtmAccountDate">入帐日期</param>
        /// <returns></returns>
        internal long m_lngInAccount(string[] p_strChittyIDArr, long[] p_lngMainSEQ, string p_strStorageID, string p_strEmpID, DateTime p_dtmAccountDate,bool isInOut)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngInAccount(objPrincipal, p_strChittyIDArr, p_lngMainSEQ, p_strStorageID, p_strEmpID, p_dtmAccountDate, isInOut);
            return lngRes;
        }
        #endregion
        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngMainSEQArr">入库主表序列</param>
        /// <param name="p_strInStorageIDArr">入库单据号</param>
        /// <param name="p_objSTDetailArr">入库相关库存明细</param>
        /// <returns></returns>
        internal long m_lngUnCommit(string p_strStorageID, long[] p_lngMainSEQArr, string[] p_strInStorageIDArr, clsMS_StorageDetail[] p_objSTDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngUnCommitInStorage(objPrincipal, p_strStorageID, p_lngMainSEQArr, p_strInStorageIDArr, p_objSTDetailArr);
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
        #region 获取出入库类型信息表
        public long m_mthGetImpExpTypeInfo(out DataTable m_dtImpExpType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetImpExpTypeInfo(objPrincipal, out m_dtImpExpType);
            return lngRes;
        }
        #endregion

        #region 取回所有的药品类型
        /// <summary>
        /// 取回所有的药品类型
        /// </summary>
        /// <param name="objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetMedType(out clsMedicineType_VO[] objResultArr)
        {
            objResultArr = new clsMedicineType_VO[0];
            long lngRes = 0;
            System.Security.Principal.IPrincipal objPrincipal = null;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetStorageCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetStorageCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetStorageCheckMedicineSVC));
            lngRes = objSvc.m_lngFindAllMedicineType(objPrincipal, out objResultArr);

            return lngRes;
        }

        /// <summary>
        /// 获取所有的药品类型
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetMedType(out DataTable dtbResult)
        {

            long lngRes = 0;
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsGetStorageCheckMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsGetStorageCheckMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsGetStorageCheckMedicineSVC));
            lngRes = objSvc.m_lngGetMedType(p_objPrincipal, out dtbResult);
            return lngRes;
        }
        #endregion



        #region 检查单据状态值

        /// <summary>
        /// 检查单据状态值

        /// </summary>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, 0, p_lngSeq, out m_intStatus);//单据类别：0为药库入库单
            return lngRes;
        }
        #endregion
    }
}
