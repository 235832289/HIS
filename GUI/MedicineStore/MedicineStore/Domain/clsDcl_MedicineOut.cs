using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.EMR_EmployeeManagerService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药库出库
    /// </summary>
    public class clsDcl_MedicineOut : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 添加新的药品出库(主表)
        /// <summary>
        /// 添加新的药品出库(主表)
        /// </summary>
        /// <param name="p_objMain">主表内容</param>
        /// <returns></returns>
        internal long m_lngAddNewOutStorage(ref clsMS_OutStorage_VO p_objMain)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngAddNewOutStorage(objPrincipal, ref p_objMain);
            return lngRes;
        }
        #endregion

        #region  添加新的药品出库(明细表)
        /// <summary>
        ///  添加新的药品出库(明细表)
        /// </summary>
        /// <param name="p_objDetailArr">明细表内容</param>
        /// <returns></returns>
        internal long m_lngAddNewOutStorageDetail(ref clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngAddNewOutStorageDetail(objPrincipal, ref p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region  修改药品出库信息(主表)
        /// <summary>
        ///  修改药品出库信息(主表)
        /// </summary>
        /// <param name="p_objMain">主表内容</param>
        /// <returns></returns>
        internal long m_lngModifyOutStorage(clsMS_OutStorage_VO p_objMain)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngModifyOutStorage(objPrincipal, p_objMain);
            return lngRes;
        }
        #endregion

        #region  修改药品出库(明细表)
        /// <summary>
        ///  修改药品出库(明细表)
        /// </summary>
        /// <param name="p_objDetailArr">明细表内容</param>
        /// <returns></returns>
        internal long m_lngModifyOutStorageDetail(clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngModifyOutStorageDetail(objPrincipal, p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region  删除出库明细
        /// <summary>
        ///  删除本次出库单出库明细

        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        internal long m_lngDeleteOutStorageDetail(int p_intStatus, long p_lngMainSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUpdateStorageDetailStatusByMainSEQ(objPrincipal, p_intStatus, p_lngMainSEQ);
            return lngRes;
        }

        /// <summary>
        ///  删除指定出库明细
        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <param name="p_lngSEQ">序列</param>
        /// <returns></returns>
        internal long m_lngDeleteSpecOutStorageDetail(int p_intStatus, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUpdateStorageDetailStatus(objPrincipal, p_intStatus, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region 获取出库子表实发数量
        /// <summary>
        /// 获取出库子表实发数量
        /// </summary>
        /// <param name="p_lngSEQ">序列</param>
        /// <param name="p_dblAmount">实发数量</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailGross(long p_lngSEQ, out double p_dblAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailGross(objPrincipal, p_lngSEQ, out p_dblAmount);
            return lngRes;
        }
        #endregion

        #region 获取指定药品出库数量
        /// <summary>
        /// 获取指定药品出库数量
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_hstNetAmount">针对指定药物，以批号为键，出库数量为值的哈希表</param>
        /// <returns></returns>
        internal long m_lngGetNetAmount(long p_lngMainSEQ, string p_strMedicineID, out Hashtable p_hstNetAmount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetNetAmount(objPrincipal, p_lngMainSEQ, p_strMedicineID, out p_hstNetAmount);
            return lngRes;
        }
        #endregion

        #region 获取指定出库单各药品的总库存

        /// <summary>
        /// 获取指定出库单各药品的总库存

        /// </summary>
        /// <param name="p_lngMainSEQ">出库主表序列</param>
        /// <param name="p_objGross">各药品的总库存</param>
        /// <returns></returns>
        internal long m_lngGetMedicineAllGross(long p_lngMainSEQ, out clsMS_MedicineGross[] p_objGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetMedicineAllGross(objPrincipal, p_lngMainSEQ, out p_objGross);
            return lngRes;
        }
        #endregion


        #region 获取子表内容(报表打印)
        /// <summary>
        /// 获取子表内容(报表打印)
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailReport(long p_lngMainSEQ,int intType, out DataTable p_dtbValue,string p_strDBConfig)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailReport(objPrincipal, p_lngMainSEQ, intType, out p_dtbValue, p_strDBConfig);
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

        #region 保存出库记录
        /// <summary>
        /// 保存出库记录
        /// </summary>
        /// <param name="p_objMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewDetailArr">新出库明细</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngSaveOutStorage(ref clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewDetailArr, bool p_blnIsCommit, bool p_lngIsAddNew, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngSaveOutStorage(objPrincipal, ref p_objMain, p_objOldDetailArr, ref p_objNewDetailArr, p_blnIsCommit, p_lngIsAddNew, p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region 获取出库单报表类型


        /// <summary>
        /// 获取出库单报表类型        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5015", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 删除指定出库药品
        /// <summary>
        /// 删除指定出库药品
        /// </summary>
        /// <param name="p_lngSeq">药品序列</param>
        /// <param name="p_strOutStorageID">出库单据号</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStroageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_objStMed">库存药品信息</param>
        /// <param name="p_dblOutGross">此药品出库数量</param>
        /// <returns></returns>
        internal long m_lngDeleteSelectedMedicine(long p_lngSeq, string p_strOutStorageID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStroageID, DateTime p_dtmValidDate, double p_dblInPrice, bool p_blnIsCommit, clsMS_Storage p_objStMed, double p_dblOutGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngDeleteSelectedMedicine(objPrincipal, p_lngSeq, p_strOutStorageID, p_strStorageID, p_strMedicineID, p_strLotNO, p_strInStroageID,p_dtmValidDate,p_dblInPrice, p_blnIsCommit, p_objStMed, p_dblOutGross);
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

        #region 获取药品是否已调价

        /// <summary>
        /// 获取药品是否已调价
        /// </summary>
        /// <param name="medicineid_chr">药品ID</param>
        /// <param name="lotno_vchr">批号</param>
        /// <param name="instorageid_vchr">入库单号</param>
        /// <param name="p_dtmValiDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_dblAdjustrice">是否已调价</param>
        /// <returns></returns>
        public long m_mthGetAdjustrice(string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, DateTime datNewdate, out bool p_dblAdjustrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetAdjustrice(objPrincipal, medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, datNewdate, out p_dblAdjustrice);
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

        #region 查找员工
        /// <summary>
        /// 查找员工
        /// </summary>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strSearch">搜索字符</param>
        /// <param name="p_dtbEMP">员工</param>
        /// <returns></returns>
        internal long m_lngGetEMP(string p_strDeptID, string p_strSearch, out DataTable p_dtbEMP)
        {
            long lngRes = 0;
            clsEMR_EmployeeManagerService objSvc =
                (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.EMR_EmployeeManagerService.clsEMR_EmployeeManagerService));
            lngRes = objSvc.m_lngGetEmpArrByIDOrNameLikeInDept(p_strDeptID, p_strSearch, out p_dtbEMP);
            return lngRes;
        }
        #endregion

        #region 是否显示领用人

        /// <summary>
        /// 是否显示领用人
        /// </summary>
        /// <param name="p_blnIsShowReceiptor">是否显示领用人</param>
        /// <returns></returns>
        internal long m_lngGetIsShowReceiptor(out bool p_blnIsShowReceiptor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetCollocate(objPrincipal, out p_blnIsShowReceiptor, "5025");
            return lngRes;
        }
        #endregion


        internal long m_mthGetBillDate(string p_strOrderID, out DateTime dtAskDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_mthGetBillDate(objPrincipal, p_strOrderID,out dtAskDate);
            return lngRes;
        }

        #region 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// </summary>
        /// <param name="m_intCanModifyMakeDate">是否允许修改</param>
        /// <returns></returns>
        internal long m_lngGetCanModifyMakeDate(out int m_intCanModifyMakeDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5026", out m_intCanModifyMakeDate);
            return lngRes;
        }
        #endregion

        #region 获取单据类型
        /// <summary>
        /// 获取单据类型
        /// </summary>
        /// <param name="p_intBillTypeID"></param>
        /// <param name="m_strBillTypeName"></param>
        internal long m_lngGetBillTypeName(int p_intBillTypeID, out string p_strBillTypeName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetBillTypeName(objPrincipal, p_intBillTypeID, out p_strBillTypeName);
            return lngRes;
        }
        #endregion

        internal long m_lngGetCanModifyAutoExam(out int m_intCanModifyAutoExam)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5025", out m_intCanModifyAutoExam);
            return lngRes;
        }
        #region 获取子表内容 (广医三院报表打印)
        /// <summary>
        /// 获取子表内容 (广医三院报表打印)
        /// </summary>
        /// <param name="p_lngMainSEQ">主表序列号</param>
        /// <param name="p_dtbValue">子表内容</param>
        /// <returns></returns>
        public long m_lngGetOutStorageDetailReportForGY3Y(long p_lngMainSEQ, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorage_Supported_SVC));
            lngRes = objSvc.m_lngGetOutStorageDetailReportForGY3Y(objPrincipal, p_lngMainSEQ, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 建立第二个数据库连接
        /// <summary>
        /// 建立第二个数据库连接
        /// </summary>
        /// <param name="p_strConfig">参数</param>
        internal long m_lngEstablishConnection(string p_strConfig)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsConnectToSecondDB_SVC objSVC=
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsConnectToSecondDB_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsConnectToSecondDB_SVC));
            lngRes = objSVC.m_lngEstablishConnection(objPrincipal, p_strConfig);
            return lngRes;
        }
        #endregion


        #region 杨镇伟添加,修改出库主表单据状态
        /// <summary>
        /// 修改出库主表单据状态
        /// </summary>
        /// <param name="p_strPattern">修改模式：0-接根据主表ID修改,1-根据子表ID修改</param>
        /// <param name="p_strStatus">状态</param>
        /// <param name="p_strSeriesId">单据ID</param>
        /// <returns></returns>
        public long m_lngUpdStorageStatus(string p_strPattern, string p_strStatus, long p_lngSeriesId)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngUpdStorageStatus(p_strPattern, p_strStatus, p_lngSeriesId);
            return lngRes;
        }
        #endregion
    }
}
