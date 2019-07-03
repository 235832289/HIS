using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �����������
    /// </summary>
    public class clsDcl_MakeOutStorageOrder : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region ��ӿ����ϸ
        /// <summary>
        /// ��ӿ����ϸ
        /// </summary>
        /// <param name="p_objSDVOArr">�����ϸ</param>
        /// <returns></returns>
        internal long m_lngAddNewStorageDetail(clsMS_StorageDetail[] p_objSDVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddNewStorageDetail(objPrincipal,p_objSDVOArr);
            return lngRes;
        }
        #endregion

        #region ��ӿ������
        /// <summary>
        /// ��ӿ������
        /// </summary>
        /// <param name="p_objSDVOArr">���</param>
        /// <returns></returns>
        internal long m_lngAddNewStorage(clsMS_Storage[] p_objSDVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddNewStorage(objPrincipal, p_objSDVOArr);
            return lngRes;
        }
        /// <summary>
        /// ��ӿ������
        /// </summary>
        /// <param name="p_objSDVO">���</param>
        /// <returns></returns>
        internal long m_lngAddNewStorage(ref clsMS_Storage p_objSDVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddNewStorage(objPrincipal, ref p_objSDVO);
            return lngRes;
        }
        #endregion

        #region �������ݣ��޸Ŀ��������Ϣ
        /// <summary>
        /// �������ݣ��޸Ŀ��������Ϣ
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="p_lngSEQ"></param>
        /// <returns></returns>
        internal long m_lngModifyStorageFromInitial(clsMS_Storage p_objRecord, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngModifyStorageFromInitial(objPrincipal, p_objRecord, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region �������¿����Ϣ
        /// <summary>
        /// �������¿����Ϣ
        /// </summary>
        /// <param name="p_objRecord"></param>
        /// <param name="p_lngSEQ"></param>
        /// <returns></returns>
        internal long m_lngModifyStorageFromUnCommit(clsMS_Storage p_objRecord, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngModifyStorageFromUnCommit(objPrincipal, p_objRecord, p_lngSEQ);
            return lngRes;
        }
        #endregion

        #region �������ݣ��޸Ŀ��������Ϣ
        /// <summary>
        /// ͳ�ƿ��
        /// </summary>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <returns></returns>
        internal long m_lngStatisticsStorage(string p_strMedicineID, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngStatisticsStorage(objPrincipal, p_strMedicineID, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region ����������Ƿ��Ѵ��ڸ�ҩ
        /// <summary>
        /// ����������Ƿ��Ѵ��ڸ�ҩ
        /// </summary>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_blnHasDetail">�Ƿ����</param>
        /// <param name="p_lngSeriesID">����ڣ��������к�</param>
        /// <returns></returns>
        internal long m_lngCheckHasStorage(string p_strMedicineID, string p_strStorageID, out bool p_blnHasDetail, out long p_lngSeriesID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngCheckHasStorage(objPrincipal, p_strMedicineID, p_strStorageID, out p_blnHasDetail, out p_lngSeriesID);
            return lngRes;
        }
        #endregion

        #region ɾ��ָ����ⵥ�ŵĿ����ϸ

        /// <summary>
        /// ɾ��ָ����ⵥ�ŵĿ����ϸ

        /// </summary>
        /// <param name="p_strInStorageID">��ⵥ��</param>
        /// <param name="p_dtmInStorageDate">�������</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(string p_strInStorageID, DateTime p_dtmInStorageDate)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_strInStorageID, p_dtmInStorageDate);
            return lngRes;
        }

        /// <summary>
        /// ɾ��ָ����ⵥ�ŵĿ����ϸ

        /// </summary>
        /// <param name="p_strInStorageIDArr">��ⵥ��</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(string[] p_strInStorageIDArr, string storageid_chr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_strInStorageIDArr, storageid_chr);
            return lngRes;
        }
        #endregion

        #region ɾ��ָ����ⵥ�ŵĿ����ϸ

        /// <summary>
        /// ɾ��ָ����ⵥ�ŵĿ����ϸ

        /// </summary>
        /// <param name="p_strInStorageID">��ⵥ��</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_lngSEQ);
            return lngRes;
        }

        /// <summary>
        /// ɾ��ָ����ⵥ�ŵĿ����ϸ

        /// </summary>
        /// <param name="p_lngSEQArr">��ⵥ��</param>
        /// <returns></returns>
        internal long m_lngDeleteStorageDetail(long[] p_lngSEQArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngDeleteStorageDetail(objPrincipal, p_lngSEQArr);
            return lngRes;
        }
        #endregion

        #region ����ҩƷ��Ϣ��ȡ�����ϸ���к�

        /// <summary>
        /// ����ҩƷ��Ϣ��ȡ�����ϸ���к�

        /// </summary>
        /// <param name="p_strInStorageID">��ⵥ��</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strLotNO">ҩƷ����</param>
        /// <param name="p_dtmValidDate">��Ч��</param>
        /// <param name="p_dblInPrice">�����</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_lngSEQ">�����ϸ���к�</param>
        /// <param name="p_dblRealgross">ʵ�ʿ��</param>
        /// <param name="p_dblAvailagross">���ÿ��</param>
        /// <returns></returns>
        internal long m_lngGetDetailSEQByIndex(string p_strInStorageID, string p_strMedicineID, string p_strLotNO, DateTime p_dtmValidDate, double p_dblInPrice, string p_strStorageID, out long p_lngSEQ,
            out double p_dblRealgross, out double p_dblAvailagross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetDetailSEQByIndex(objPrincipal, p_strInStorageID, p_strMedicineID, p_strLotNO, p_dtmValidDate, p_dblInPrice, p_strStorageID, out p_lngSEQ, out p_dblRealgross, out p_dblAvailagross);
            return lngRes;
        }
        #endregion

        #region ��ȡָ��ҩƷ�����Ϣ
        /// <summary>
        /// ��ȡָ��ҩƷ�����Ϣ
        /// </summary>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_objDetailArr">�����Ϣ</param>
        /// <returns></returns>
        internal long m_lngGetStorageMedicineDetail(string p_strMedicineID, string p_strStorageID, out clsMS_StorageDetail[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetStorageMedicineDetail(objPrincipal, p_strMedicineID, p_strStorageID, out p_objDetailArr);
            return lngRes;
        }
        #endregion

        #region ��ӿ����ϸ��������

        /// <summary>
        /// ��ӿ����ϸ��������

        /// </summary>
        /// <param name="p_dblRealGross">ʵ�ʿ��</param>
        /// <param name="p_dblAvailaGross">���ÿ��</param>
        /// <param name="p_lngSEQ">����</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailGross(double p_dblRealGross, double p_dblAvailaGross, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailGross(objPrincipal, p_dblRealGross, p_dblAvailaGross, p_lngSEQ);
            return lngRes;
        }

        /// <summary>
        /// ��ӿ����ϸ��������(���ÿ��)
        /// </summary>
        /// <param name="p_objOutArr">���Ŀ��VO</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailAvailaGross(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailAvailaGross(objPrincipal, p_objOutArr);
            return lngRes;
        }

        /// <summary>
        /// ��ӿ����ϸ��������(ʵ�ʿ��)
        /// </summary>
        /// <param name="p_objOutArr">���Ŀ��VO</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailRealGross(clsMS_StorageGrossForOut[] p_objOutArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailRealGross(objPrincipal, p_objOutArr);
            return lngRes;
        }

        /// <summary>
        ///  ��ӿ����ϸ��������(����ɾ��δ��˼�¼ʱֻ��ӿ��ÿ��)
        /// </summary>
        /// <param name="p_dblAvailaGross">���ÿ��</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strLotNO">ҩƷ����</param>
        /// <param name="p_strInStorageID">��ⵥ�ݺ�</param>
        /// <param name="p_dtmValidDate">��Ч��</param>
        /// <param name="p_dblInPrice">�����</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <returns></returns>
        internal long m_lngAddStorageDetailAvailaGross(double p_dblAvailaGross, string p_strMedicineID, string p_strLotNO, string p_strInStorageID, DateTime p_dtmValidDate, double p_dblInPrice, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageDetailAvailaGross(objPrincipal, p_dblAvailaGross, p_strMedicineID, p_strLotNO, p_strInStorageID, p_dtmValidDate, p_dblInPrice, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region ���ٿ����ϸ��������

        /// <summary>
        /// ���ٿ����ϸ��������

        /// </summary>
        /// <param name="p_dblRealGross">ʵ�ʿ��</param>
        /// <param name="p_dblAvailaGross">���ÿ��</param>
        /// <param name="p_lngSEQ">����</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailGross(double p_dblRealGross, double p_dblAvailaGross, long p_lngSEQ)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailGross(objPrincipal, p_dblRealGross, p_dblAvailaGross, p_lngSEQ);
            return lngRes;
        }        

        /// <summary>
        /// ���ٿ����ϸ��������(ʵ�ʿ��)
        /// </summary>
        /// <param name="p_objDetail">��������</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailRealGross(clsMS_StorageGrossForOut[] p_objDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailRealGross(objPrincipal, p_objDetail);
            return lngRes;
        }

        /// <summary>
        /// ���ٿ����ϸ��������(�������ʱֻ�Կ��ÿ�����޸�)
        /// </summary>
        /// <param name="p_objDetail">�����ϸ������</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailAvailaGross(clsMS_StorageDetail[] p_objDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailAvailaGross(objPrincipal, p_objDetail);
            return lngRes;
        }

        /// <summary>
        ///  ���ٿ����ϸ��������

        /// </summary>
        /// <param name="p_dblAvailaGross">���ÿ��</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strLotNO">ҩƷ����</param>
        /// <param name="p_strInStorageID">��ⵥ�ݺ�</param>
        /// <param name="p_dblInPrice">���뵥��</param>
        /// <param name="p_dtmValidDate">��Ч��</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <returns></returns>
        internal long m_lngSubStorageDetailAvailaGross(double p_dblAvailaGross, string p_strMedicineID, string p_strLotNO,
            string p_strInStorageID, double p_dblInPrice, DateTime p_dtmValidDate, string p_strStorageID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageDetailAvailaGross(objPrincipal, p_dblAvailaGross, p_strMedicineID, p_strLotNO, p_strInStorageID, p_dblInPrice, p_dtmValidDate, p_strStorageID);
            return lngRes;
        }
        #endregion

        #region ���ٿ������������
        /// <summary>
        /// ���ٿ������������
        /// </summary>
        /// <param name="p_objMain">�����������</param>
        /// <returns></returns>
        internal long m_lngSubStorageGross(clsMS_Storage p_objMain)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageGross(objPrincipal, p_objMain);
            return lngRes;
        }
        #endregion

        #region ��ȡָ��ҩƷ���ÿ������
        /// <summary>
        /// ��ȡָ��ҩƷ���ÿ������
        /// </summary>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_dblGross">���ÿ������</param>
        /// <returns></returns>
        internal long m_lngGetAvailaGross(string p_strStorageID, string p_strMedicineID, out double p_dblGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetAvailaGross(objPrincipal, p_strStorageID, p_strMedicineID, out p_dblGross);
            return lngRes;
        }
        #endregion

        #region ���������ӵ�ǰ���
        /// <summary>
        /// ���������ӵ�ǰ���
        /// </summary>
        /// <param name="p_objRecord">���</param>
        /// <returns></returns>
        internal long m_lngAddStorageGross(clsMS_StorageGrossForOut p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngAddStorageGross(objPrincipal, p_objRecord);
            return lngRes;
        }
        #endregion

        #region ���������ٵ�ǰ���
        /// <summary>
        /// ���������ٵ�ǰ���
        /// </summary>
        /// <param name="p_objRecord">���</param>
        /// <returns></returns>
        internal long m_lngSubStorageGross(clsMS_StorageGrossForOut p_objRecord)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngSubStorageGross(objPrincipal, p_objRecord);
            return lngRes;
        }
        #endregion
        #region ����µ�ҩƷ����(����)
        /// <summary>
        /// ����µ�ҩƷ����(����)
        /// </summary>
        /// <param name="p_objMain">��������</param>
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

        #region  ����µ�ҩƷ����(��ϸ��)
        /// <summary>
        ///  ����µ�ҩƷ����(��ϸ��)
        /// </summary>
        /// <param name="p_objDetailArr">��ϸ������</param>
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

        #region  �޸�ҩƷ������Ϣ(����)
        /// <summary>
        ///  �޸�ҩƷ������Ϣ(����)
        /// </summary>
        /// <param name="p_objMain">��������</param>
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

        #region  �޸�ҩƷ����(��ϸ��)
        /// <summary>
        ///  �޸�ҩƷ����(��ϸ��)
        /// </summary>
        /// <param name="p_objDetailArr">��ϸ������</param>
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

        #region  ɾ��������ϸ
        /// <summary>
        ///  ɾ�����γ��ⵥ������ϸ


        /// </summary>
        /// <param name="p_intStatus">״̬</param>
        /// <param name="p_lngMainSEQ">��������</param>
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
        ///  ɾ��ָ��������ϸ
        /// </summary>
        /// <param name="p_intStatus">״̬</param>
        /// <param name="p_lngSEQ">����</param>
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

        #region ��ȡ�����ӱ�ʵ������
        /// <summary>
        /// ��ȡ�����ӱ�ʵ������
        /// </summary>
        /// <param name="p_lngSEQ">����</param>
        /// <param name="p_dblAmount">ʵ������</param>
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

        #region ��ȡָ��ҩƷ��������
        /// <summary>
        /// ��ȡָ��ҩƷ��������
        /// </summary>
        /// <param name="p_lngMainSEQ">��������</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_hstNetAmount">���ָ��ҩ�������Ϊ������������Ϊֵ�Ĺ�ϣ��</param>
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

        #region ��ȡָ�����ⵥ��ҩƷ���ܿ��


        /// <summary>
        /// ��ȡָ�����ⵥ��ҩƷ���ܿ��


        /// </summary>
        /// <param name="p_lngMainSEQ">������������</param>
        /// <param name="p_objGross">��ҩƷ���ܿ��</param>
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


        #region ��ȡ�ӱ�����(�����ӡ)
        /// <summary>
        /// ��ȡ�ӱ�����(�����ӡ)
        /// </summary>
        /// <param name="p_lngMainSEQ">�������к�</param>
        /// <param name="p_dtbValue">�ӱ�����</param>
        /// <returns></returns>
        internal long m_lngGetOutStorageDetailReport(long p_lngMainSEQ, int intType, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngGetOutStorageDetailReport(objPrincipal, p_lngMainSEQ, intType, out p_dtbValue,"");
            return lngRes;
        }
        #endregion

        #region ��ȡ�ֿ���


        /// <summary>
        /// ��ȡ�ֿ���


        /// </summary>
        /// <param name="p_strStoreRoomID">�ֿ�ID</param>
        /// <param name="p_strStoreRoomName">�ֿ���</param>
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

        #region ��������¼
        /// <summary>
        /// ��������¼
        /// </summary>
        /// <param name="p_objMain">������������</param>
        /// <param name="p_objOldDetailArr">�ɳ�����ϸ</param>
        /// <param name="p_objNewDetailArr">�³�����ϸ</param>
        /// <param name="p_blnIsCommit">�Ƿ񱣴漴���</param>
        /// <param name="p_lngIsAddNew">�Ƿ������¼</param>
        /// <param name="p_blnIsImmAccount">�Ƿ���˼�����</param>
        /// <returns></returns>
        internal long m_lngSaveOutStorageByStorage(ref clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objOldDetailArr, ref clsMS_OutStorageDetail_VO[] p_objNewDetailArr,
            bool p_blnIsCommit, bool p_lngIsAddNew, bool p_blnIsImmAccount)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngSaveOutStorageByStorage(objPrincipal, ref p_objMain, p_objOldDetailArr, ref p_objNewDetailArr, p_blnIsCommit, p_lngIsAddNew, p_blnIsImmAccount);
            return lngRes;
        }
        #endregion

        #region ��ȡ���ⵥ��������



        /// <summary>
        /// ��ȡ���ⵥ��������
        /// </summary>
        internal long m_lngGetPrinType(out int p_intCommitFolw)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_lngGetSysSetting(objPrincipal, "5015", out p_intCommitFolw);
            return lngRes;
        }
        #endregion

        #region ɾ��ָ������ҩƷ
        /// <summary>
        /// ɾ��ָ������ҩƷ
        /// </summary>
        /// <param name="p_lngSeq">ҩƷ����</param>
        /// <param name="p_strOutStorageID">���ⵥ�ݺ�</param>
        /// <param name="p_strStorageID">�ֿ�ID</param>
        /// <param name="p_strMedicineID">ҩƷID</param>
        /// <param name="p_strLotNO">����</param>
        /// <param name="p_strInStroageID">��ⵥ�ݺ�</param>
        /// <param name="p_dtmValidDate">��Ч��</param>
        /// <param name="p_dblInPrice">�����</param>
        /// <param name="p_blnIsCommit">�Ƿ񱣴漴���</param>
        /// <param name="p_objStMed">���ҩƷ��Ϣ</param>
        /// <param name="p_dblOutGross">��ҩƷ��������</param>
        /// <returns></returns>
        internal long m_lngDeleteSelectedMedicine(long p_lngSeq, string p_strOutStorageID, string p_strStorageID, string p_strMedicineID, string p_strLotNO, string p_strInStroageID, DateTime p_dtmValidDate, double p_dblInPrice, bool p_blnIsCommit, clsMS_Storage p_objStMed, double p_dblOutGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsOutStorageSVC));
            lngRes = objSvc.m_lngDeleteSelectedMedicine(objPrincipal, p_lngSeq, p_strOutStorageID, p_strStorageID, p_strMedicineID, p_strLotNO, p_strInStroageID, p_dtmValidDate, p_dblInPrice, p_blnIsCommit, p_objStMed, p_dblOutGross);
            return lngRes;
        }
        #endregion

        #region ��ȡҩƷ��������,��Ч�ڿ�����Ϣ

        /// <summary>
        /// ��ȡҩƷ��������,��Ч�ڿ�����Ϣ

        /// </summary>
        /// <param name="p_strMedicineTypeID">ҩƷ����ID</param>
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

        #region  ��ȡ��������ת�Ľ�������
        /// <summary>
        ///  ��ȡ��������ת�Ľ�������
        /// </summary>
        /// <returns></returns>
        public long m_mthGetAccountperiodTime(string p_strStorageID,out DateTime datAccountperiodTime)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsMS_PublicSVC));
            lngRes = objSvc.m_mthGetAccountperiodTime(objPrincipal,p_strStorageID, out datAccountperiodTime);
            return lngRes;
        }
        #endregion

        #region ��ȡҩƷ�Ƿ��ѵ���
        /// <summary>
        /// ��ȡҩƷ�Ƿ��ѵ���
        /// </summary>
        /// <param name="medicineid_chr">ҩƷID</param>
        /// <param name="lotno_vchr">����</param>
        /// <param name="instorageid_vchr">��ⵥ��</param>
        /// <param name="p_dtmValiDate">��Ч��</param>
        /// <param name="p_dblInPrice">�����</param>
        /// <param name="p_dblAdjustrice">�Ƿ��ѵ���</param>
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
        #region ����ҩ��������ˮ�Ż�ȡ��ϸ����Ϣ
        /// <summary>
        /// ����ҩ��������ˮ�Ż�ȡ��ϸ����Ϣ
        /// </summary>
        /// <param name="p_blnIsHospital">�Ƿ�סԺ��λ</param>
        /// <param name="p_lngSeqid"></param>
        /// <param name="p_dtOutStorageDetail"></param>
        /// <returns></returns>
        public long m_lngGetOutStorageDetailInfoByid(bool p_blnIsHospital,long p_lngSeqid, out DataTable p_dtOutStorageDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetOutStorageDetailInfoByid(objPrincipal, p_blnIsHospital,p_lngSeqid, out p_dtOutStorageDetail);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// ����������ˮ�Ż�ȡ��ϸ����Ϣ
        /// </summary>
        /// <param name="p_blnIsHospital">�Ƿ�סԺ��λ</param>
        /// <param name="p_lngSeqid">������ˮ��Ϣ</param>
        /// <param name="p_dtAskDetail">��ϸ����Ϣ</param>
        /// <returns></returns>
        internal long m_lngGetAskDetailInfoByid(bool p_blnIsHospital, long p_lngSeqid, out DataTable p_dtAskDetail)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetAskDetailInfoByid(objPrincipal, p_blnIsHospital,p_lngSeqid, out p_dtAskDetail);
            return lngRes;
        }

        /// <summary>
        /// ��ȡָ��ҩƷ�����Ϣ
        /// </summary>
        /// <param name="m_strMedicineID">ҩƷID</param>
        /// <param name="m_strStorageID">ID</param>
        /// <param name="m_strMedSpec">ҩƷ���</param>
        /// <param name="objDetail">�����Ϣ</param>
        /// <returns></returns>
        internal long m_lngGetStorageMedicineDetailInfo(string p_strMedicineID, string p_strStorageID, out clsMS_StorageDetail[] p_objDetailArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOutstorage_Supported_SVC));
            lngRes = objSvc.m_lngGetStorageMedicineDetailInfo(objPrincipal, p_strMedicineID, p_strStorageID, out p_objDetailArr);
            return lngRes;
        }

        /// <summary>
        /// �������쵥��ϸ�������״̬
        /// </summary>
        /// <param name="p_lngSeriesID">��������</param>
        /// <param name="p_hstUpdateEnough">ҩƷ�ź͡�+=����ʶ</param>
        /// <returns></returns>
        internal long m_lngUpdateEnoughState(long p_lngSeriesID,Hashtable p_hstUpdateEnough)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicineSVC));
            lngRes = objSvc.m_lngUpdateEnoughState(objPrincipal, p_lngSeriesID,p_hstUpdateEnough);
            return lngRes;
        }

        #region �����������ƻ�ȡ���������ID
        /// <summary>
        /// �����������ƻ�ȡ���������ID
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_intFlag">0-��⣻1-����</param>
        /// <param name="p_strTypeName">��������</param>
        /// <param name="p_intTypeCode">����ID</param>
        /// <returns></returns>
        internal long m_lngGetTypeCodeByName(int p_intFlag,string p_strTypeName, out int p_intTypeCode)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDS_Public_Supported_SVC));
            lngRes = objSvc.m_lngGetTypeCodeByName(objPrincipal, p_intFlag,p_strTypeName, out p_intTypeCode);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// ��ȡ���쵥״̬�Ƿ��ύ��
        /// </summary>
        /// <param name="p_strAskID"></param>
        /// <returns></returns>
        public long m_lngCheckStatus(string p_strAskID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngCheckStatus(objPrincipal, p_strAskID);
            return lngRes;
        }

        #region ��ѯ��ҩ�⵱ǰ��ҩƷ����
        /// <summary>
        /// ��ѯ��ҩ�⵱ǰ��ҩƷ����
        /// </summary>
        /// <param name="p_strStorageID"></param>
        /// <param name="p_strMedicineID"></param>
        /// <param name="p_dblGross"></param>
        /// <returns></returns>
        internal long m_lngGetAllRealGross(string p_strStorageID, string p_strMedicineID, out double p_dblGross)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC objSvc =
                (com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.MedicineStoreService.clsStorageSVC));
            lngRes = objSvc.m_lngGetAllRealGross(objPrincipal, p_strStorageID, p_strMedicineID, out p_dblGross);
            return lngRes;
        }
        #endregion
    }
}
