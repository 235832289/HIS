using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using com.digitalwave.iCare.middletier.common;
using com.digitalwave.EMR_EmployeeManagerService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public class clsDcl_Purchase_Detail : com.digitalwave.GUI_Base.clsDomainController_Base
    {
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

        #region 获取最近一次的中标单位及批准文号

        /// <summary>
        /// 获取最近一次的中标单位及批准文号

        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批准文号</param>
        /// <param name="p_strBidCompanyID">中标单位</param>
        /// <returns></returns>
        internal long m_lngGetLatestBidCompany(string p_strMedicineID, out string p_strLotNO, out string p_strBidCompanyID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetLatestBidCompany(objPrincipal, p_strMedicineID, out p_strLotNO, out p_strBidCompanyID);
            return lngRes;
        } 
        #endregion 

        #region 获取是否显示包装/基本单位换算
        /// <summary>
        /// 获取是否显示包装/基本单位换算
        /// </summary>
        /// <param name="p_blnIsSetDefault">是否显示</param>
        /// <returns></returns>
        internal long m_lngGetIsShowUnitConviersionSetting(out bool p_blnIsSetDefault)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetCollocate(objPrincipal, out p_blnIsSetDefault, "5002");
            return lngRes;
        }
        #endregion

        #region 获取是否审核即入帐

        /// <summary>
        /// 获取是否审核即入帐

        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <returns></returns>
        internal long m_lngGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetCollocate(objPrincipal, out p_blnIsImmAccount, "5016");
            return lngRes;
        }
        #endregion

        #region 获取是否显示中标验货信息
        /// <summary>
        /// 获取是否显示中标验货信息
        /// </summary>
        /// <param name="p_blnIsSetDefault">是否显示</param>
        /// <returns></returns>
        internal long m_lngGetIsShowAcceptanceCheck(out bool p_blnIsSetDefault)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.common.clsCommonInfoSvc objSvc =
                (com.digitalwave.iCare.middletier.common.clsCommonInfoSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.common.clsCommonInfoSvc));
            lngRes = objSvc.m_lngGetCollocate(objPrincipal, out p_blnIsSetDefault, "5003");
            return lngRes;
        }
        #endregion

        #region 获取生成零售价方式

        /// <summary>
        /// 获取生成零售价方式
        /// </summary>
        /// <param name="p_intRetailMethod">生成零售价方式</param>
        /// <returns></returns>
        internal long m_lngGetRetailMethod(out int p_intRetailMethod)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal,  "5004", out p_intRetailMethod);
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

        #region 删除指定入库明细
        /// <summary>
        /// 删除指定入库明细
        /// </summary>
        /// <param name="p_lngSeq"></param>
        /// <returns></returns>
        internal long m_lngDeleteInStorage( long p_lngSeq)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngDeleteInStorage(objPrincipal, p_lngSeq);
            return lngRes;
        }

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
        /// 删除指定入库明细
        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <param name="p_lngSeqArr">序列</param>
        /// <returns></returns>
        internal long m_lngDeleteInStorage(int p_intStatus, long[] p_lngSeqArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngUpdateInStorageStatus(objPrincipal, p_intStatus, p_lngSeqArr);
            return lngRes;
        }

        /// <summary>
        /// 删除指定入库明细
        /// </summary>
        /// <param name="p_lngSeq">药品序列</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_strLotNO">批号</param>
        /// <param name="p_strInStroageID">入库单据号</param>
        /// <param name="p_dtmValidDate">有效期</param>
        /// <param name="p_dblInPrice">购入价</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_objStMed">库存药品信息</param>
        /// <returns></returns>
        internal long m_lngDeleteSelectedMedicine(long p_lngSeq, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStroageID, DateTime p_dtmValidDate, double p_dblInPrice, bool p_blnIsCommit, clsMS_Storage p_objStMed)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngDeleteSelectedMedicine(objPrincipal, p_lngSeq, p_strStorageID, p_strMedicineID, p_strLotNO, p_strInStroageID, p_dtmValidDate, p_dblInPrice,p_blnIsCommit, p_objStMed);
            return lngRes;
        }
        #endregion

        #region 获取最近一次的相关人员信息
        /// <summary>
        /// 获取最近一次的相关人员信息
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strBuyerID">采购员ID</param>
        /// <param name="p_strBuyerName">采购员</param>
        /// <param name="p_strStoragerID">仓管员ID</param>
        /// <param name="p_strStoragerName">仓管员</param>
        /// <param name="p_strAccounterID">会计员ID</param>
        /// <param name="p_strAccounterName">会计员</param>
        /// <returns></returns>
        internal long m_lngGetLatestEmpInfo(string p_strStorageID, out string p_strBuyerID, out string p_strBuyerName,
            out string p_strStoragerID, out string p_strStoragerName, out string p_strAccounterID, out string p_strAccounterName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetLatestEmpInfo(objPrincipal,p_strStorageID, out p_strBuyerID, out p_strBuyerName, out p_strStoragerID, out p_strStoragerName, out p_strAccounterID, out p_strAccounterName);
            return lngRes;
        }
        #endregion

        #region 获取最近一次的价格
        /// <summary>
        /// 获取最近一次的价格
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dcmAvgPrice">平均入价</param>
        /// <param name="p_dcmLastBuyIn">上一次购入</param>
        /// <param name="p_dcmLastWholeSale">上一次批发</param>
        /// <param name="p_dcmLastRetail">上一次零售</param>
        /// <returns></returns>
        internal long m_lngGetLatestPrice(string p_strMedicineID, out decimal p_dcmAvgPrice, out decimal p_dcmLastBuyIn, out decimal p_dcmLastWholeSale, out decimal p_dcmLastRetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetLatestPrice(objPrincipal, p_strMedicineID, out p_dcmAvgPrice, out p_dcmLastBuyIn, out p_dcmLastWholeSale, out p_dcmLastRetail);
            return lngRes;
        }

        /// <summary>
        /// 获取最近一次的包装购入价格
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dcmLastBuyIn">上一次购入</param>
        /// <returns></returns>
        internal long m_lngGetLatestPackBuyInPrice(string p_strMedicineID, out decimal p_dcmLastBuyIn)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetLatestPackBuyInPrice(objPrincipal, p_strMedicineID, out p_dcmLastBuyIn);
            return lngRes;
        }
        #endregion

        #region 获取药品毛利率

        /// <summary>
        /// 获取药品毛利率

        /// </summary>
        /// <param name="p_strMedicineTypeID">药品类型ID</param>
        /// <param name="p_dblRate">毛利率</param>
        /// <returns></returns>
        internal long m_lngGetGrossProfitRate(string p_strMedicineTypeID, out double p_dblRate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetGrossProfitRate(objPrincipal, p_strMedicineTypeID, out p_dblRate);
            return lngRes;
        }
        #endregion

        #region 获取最近一次入库的验收员

        /// <summary>
        /// 获取最近一次入库的验收员

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strExaminer">验收员ID</param>
        /// <param name="p_strExaminerName">验收员Name</param>
        /// <returns></returns>
        internal long m_lngGetLatestExaminer(string p_strStorageID, out string p_strExaminer, out string p_strExaminerName)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetLatestExaminer(objPrincipal, p_strStorageID, out p_strExaminer, out p_strExaminerName);
            return lngRes;
        }
        #endregion

        #region 获取药品最基本信息
        /// <summary>
        /// 获取药品最基本信息
        /// </summary>
        /// <param name="p_strAssistCode">查询条件</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">返回结果</param>
        /// <returns></returns>
        internal long m_lngGetBaseMedicine(string p_strAssistCode,string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetBaseMedicineWithGross(objPrincipal, p_strAssistCode,p_strStorageID, out p_dtbMedicine);
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

        #region 获取打印行数设置
        /// <summary>
        /// 获取打印行数设置
        /// </summary>
        /// <param name="p_intCommitFolw">打印行数设置</param>
        /// <returns></returns>
        internal long m_lngGetPrinRow(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5006", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 获取入库单报表类型

        /// <summary>
        /// 获取入库单报表类型

        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5007", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 获取是否可修改毛利率

        /// <summary>
        /// 获取是否可修改毛利率
        /// </summary>
        internal long m_lngGetGrossproFitrate(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5011", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 获取是否显示国家限价

        /// <summary>
        /// 获取是否显示国家限价
        /// </summary>
        /// limitunitprice_mny
        internal long m_lngGetLimitunitPrice(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5013", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region 获取药品入库时是否可修改零售价


        /// <summary>
        /// 获取药品入库时是否可修改零售价

        /// </summary>
        /// UNITPRICE_MNY
        internal long m_lngGetUnitpriceType(out int p_intUnitpriceType)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5012", out p_intUnitpriceType);
            return lngRes;
        }
        #endregion

        #region 采购入库是否显示上次购入价、上次批发价、上次零售价、平均购入价、毛利率等信息
        /// <summary>
        /// 采购入库是否显示上次购入价、上次批发价、上次零售价、平均购入价、毛利率等信息
        /// </summary>
        /// <param name="ShosFlag"></param>
        /// <returns></returns>
        internal long m_lngShowLastBuyInUnitPrice(out int ShowFlag)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5031", out ShowFlag);
            return lngRes;
        }
        #endregion 

        #region 保存入库
        /// <summary>
        /// 保存入库
        /// </summary>
        /// <param name="p_objMain">入库主记录</param>
        /// <param name="p_objNewDetailArr">新增的入库明细</param>
        /// <param name="p_objModifyDetailArr">修改的入库明细</param>
        /// <param name="p_objAllDetailArr">所有入库明细</param>
        /// <param name="p_objStDetailArr">库存明细</param>
        /// <param name="p_blnIsAddNew">是否新添入库</param>
        /// <param name="p_blnHasCommit">是否已审核</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <returns></returns>
        internal long m_lngSaveInStorage(clsMS_InStorage_VO p_objMain, ref clsMS_InStorageDetail_VO[] p_objNewDetailArr, clsMS_InStorageDetail_VO[] p_objModifyDetailArr, clsMS_InStorageDetail_VO[] p_objAllDetailArr,
            clsMS_StorageDetail[] p_objStDetailArr, bool p_blnIsAddNew, bool p_blnHasCommit, bool p_blnIsCommit, bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strInStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngSaveInStorage(objPrincipal, p_objMain, ref p_objNewDetailArr, p_objModifyDetailArr, p_objAllDetailArr, p_objStDetailArr, p_blnIsAddNew, p_blnHasCommit, p_blnIsCommit, p_blnIsImmAccount, out p_lngMainSEQ, out p_strInStorageID);
            return lngRes;
        } 
        #endregion

        #region 保存入库(即入即出)
        /// <summary>
        /// 保存入库(即入即出)
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_objMain">入库主记录</param>
        /// <param name="p_objNewDetailArr">新增的入库明细</param>
        /// <param name="p_objModifyDetailArr">修改的入库明细</param>
        /// <param name="p_objAllDetailArr">所有入库明细</param>
        /// <param name="p_objStDetailArr">库存明细</param>
        /// <param name="p_blnIsAddNew">是否新添入库</param>
        /// <param name="p_blnHasCommit">是否已审核</param>
        /// <param name="p_blnIsCommit">是否保存即审核</param>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_objOutMain">出库主表内容</param>
        /// <param name="p_objOldDetailArr">旧出库明细</param>
        /// <param name="p_objNewOutDetailArr">新出库明细</param>
        /// <param name="p_lngIsAddNew">是否新添记录</param>
        /// <returns></returns>
        internal long m_lngSaveInStorage(clsMS_InStorage_VO p_objMain, ref clsMS_InStorageDetail_VO[] p_objNewDetailArr, clsMS_InStorageDetail_VO[] p_objModifyDetailArr, clsMS_InStorageDetail_VO[] p_objAllDetailArr,
            clsMS_StorageDetail[] p_objStDetailArr, bool p_blnIsAddNew, bool p_blnHasCommit, bool p_blnIsCommit, bool p_blnIsImmAccount, out long p_lngMainSEQ, out string p_strInStorageID, ref clsMS_OutStorage_VO p_objOutMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewOutDetailArr, bool p_lngIsAddNew)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngSaveInStorage(objPrincipal, p_objMain, ref p_objNewDetailArr, p_objModifyDetailArr, p_objAllDetailArr, p_objStDetailArr, p_blnIsAddNew, p_blnHasCommit, p_blnIsCommit, p_blnIsImmAccount, out p_lngMainSEQ, out p_strInStorageID, ref p_objOutMain, p_objOldDetailArr, ref p_objNewOutDetailArr, p_lngIsAddNew);
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

        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_lngMainSEQArr">入库主表序列</param>
        /// <param name="p_strInStorageIDArr">入库单据号</param>
        /// <returns></returns>
        internal long m_lngUnCommit(string p_strStorageID, long[] p_lngMainSEQArr, string[] p_strInStorageIDArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngUnCommitInStorage(objPrincipal, p_strStorageID, p_lngMainSEQArr, p_strInStorageIDArr);
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
        internal long m_lngGetMedicineTypeVisionm(string p_strMedicineTypeID,out clsMS_MedicineTypeVisionmSet p_objTypeVO)
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

        #region 打印时是否显示额外信息

        /// <summary>
        /// 打印时是否显示额外信息

        /// </summary>
        /// <param name="p_intShowInfo">是否显示额外信息帐</param>
        /// <returns></returns>
        internal long m_lngGetIfShowInfo(out int p_intShowInfo)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5029", out p_intShowInfo);
            return lngRes;        
        }
        #endregion

        /// <summary>
        /// 是否显示批发价
        /// </summary>
        /// <param name="m_intShowWholePrice"></param>
        internal long m_lngGetShowWholePrice(out int m_intShowWholePrice)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5028", out m_intShowWholePrice);
            return lngRes; 
        }

        /// <summary>
        /// 获取默认包装值
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="m_dtbPack">包装数据</param>
        internal long m_lngGetPack(string p_strMedicineID, out DataTable m_dtbPack)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetPack(objPrincipal, p_strMedicineID, out m_dtbPack);
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

        public long m_lngGetCanModifyAutoExam(out int m_intCanModifyAutoExam)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5025", out m_intCanModifyAutoExam);
            return lngRes; 
        }

        /// <summary>
        /// 获取上次入库厂家
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_strProductor"></param>
        /// <returns></returns>
        internal long m_lngGetLastProductor(string p_strStorageID, string p_strMedicineID, out string p_strProductor)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsInStorageSVC));
            lngRes = objSvc.m_lngGetLastProductor(objPrincipal, p_strStorageID, p_strMedicineID, out p_strProductor);
            return lngRes; 
        }

        /// <summary>
        /// 20090721:保存、删除、审核单据时，均判断是否新制状态
        /// </summary>
        /// <param name="p_intBillType"></param>
        /// <param name="p_strBillNo"></param>
        /// <param name="p_blnNewState"></param>
        /// <returns></returns>
        internal long m_lngCheckBillState(int p_intBillType, string p_strBillNo, out bool p_blnNewState)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_Public_Supported_SVC));
            lngRes = objSvc.m_lngCheckBillState(objPrincipal, p_intBillType, p_strBillNo, out p_blnNewState);
            return lngRes;
        }

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
