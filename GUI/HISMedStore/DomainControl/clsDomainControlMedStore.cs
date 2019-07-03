using System;
using System.Data;
using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ҩ��ҵ�����
	/// Create by kong 2004-07-08
	/// </summary>
	public class clsDomainControlMedStore : clsDomainController_Base
	{
		#region ���캯��
		/// <summary>
		/// 
		/// </summary>
		public clsDomainControlMedStore()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		#region ҩ������ҩ

		#region ��ϵͳ�ķ���

		#region ���ҩ����Ϣ(2005-6-24)
        ///// <summary>
		/// ���ҩ����Ϣ
		/// </summary>
		/// <returns></returns>
		public long m_lngGetStore(out DataTable  dtStore)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objChangPrice.m_lngGetStore(objPrincipal,out dtStore);
			return lngRes;
		}
		#endregion

		#region ���ҩ����Ϣ(2005-6-24)
		/// <summary>
		/// ���ҩ����Ϣ
		/// </summary>
		/// <returns></returns>
		public long m_lngGetMedStore(out DataTable  dtMedStore)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetMedStore(objPrincipal,out dtMedStore);

			return lngRes;
		}
		#endregion
		#region ���ҩ������Դ���ݺ�(2005-6-24)
		/// <summary>
		/// ���ҩ������Դ���ݺ�
		/// </summary>
		/// <returns></returns>
		public long m_lngGetScrNO(out string ScrNO)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetScrNO(objPrincipal,out ScrNO);

			return lngRes;
		}
		#endregion

		#region ��ȡҩƷ������Ϣ(11-10)
		/// <summary>
		/// ��ȡҩƷ������Ϣ
		/// </summary>
		/// <returns></returns>
		public long m_lngGetAllMedicine(out DataTable dtbMedicine)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetAllMedicine(objPrincipal,out dtbMedicine);

			return lngRes;
		}
		#endregion

		#region ����ҩ������п���ҩƷ
		/// <summary>
		/// ����ҩ������п���ҩƷ
		/// </summary>
		/// <param name="dtbMedicine"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		public long m_lngGetMedicineByID(out DataTable dtbMedicine,string strID)
		{
			long lngRes = 0;

			clsMedStoreSvc objChangPrice= (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objChangPrice.m_lngGetMedicineByID(objPrincipal,out dtbMedicine,strID);
			return lngRes;
		}
		#endregion

		#region ���ҩ��������͡�ҩ����Ϣ(11-10)
		/// <summary>
		/// ���ҩ��������͡�ҩ����Ϣ
		/// </summary>
		/// <param name="strTypeName">�����������</param>
		/// <param name="intSIGN_INT">�����־��2-����,1-���,3-����</param>
		/// <param name="StorageName">ҩ������</param>
		///  <param name="strTypeID">�������ID</param>
		///  <param name="StorageID">ҩ��ID</param>
		/// <returns></returns>
		public long m_lngGetTypeAndStorage(string strTypeID,string StorageID,out string strTypeName,out int intSIGN_INT,out string StorageName)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetTypeAndStorage(objPrincipal,strTypeID,StorageID,out strTypeName,out intSIGN_INT,out StorageName);

			return lngRes;
		}
		#endregion

		#region ���ҩ����ⵥ������Ϣ(11-10)
		/// <summary>
		/// ���ҩ����ⵥ������Ϣ
		/// </summary>
		/// <param name="dtbResult"></param>
		///  <param name="nowPriod">������ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrd(string strTypeID,out DataTable dtbResult,string nowPriod,string strStorageID,string strOutFlan)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreOrd(objPrincipal,strTypeID,out dtbResult,nowPriod,strStorageID,strOutFlan);

			return lngRes;
		}
		#endregion

		#region ������ⵥ�Ż����ⵥ��ϸ(11-10)
		/// <summary>
		/// ������ⵥ�Ż����ⵥ��ϸ
		/// </summary>
		/// <param name="strID"></param>
		/// <param name="p_dtbResultArr"></param>
		/// <returns></returns>
		public long m_lngGetStoreOrdDeByOrdID(string strID,out DataTable p_dtbResultArr,bool blCenter,string storageID)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetStoreOrdDeByOrdID(objPrincipal,strID,out p_dtbResultArr,blCenter,storageID);
			return lngRes;
		}
		#endregion

		#region ������ⵥ����(11-10)
        /// <summary>
        /// ������ⵥ����
        /// </summary>
        /// <param name="DtrStorage"></param>
        /// <param name="dtbStorageDe"></param>
        /// <param name="newID"></param>
        /// <param name="intSign">�����־��2-����,1-���,3-���γ��⣬4�������</param>
        /// <returns></returns>
		public long m_lngSave(DataRow DtrStorage,DataTable dtbStorageDe,out string newID,int intSign)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngSave(objPrincipal,DtrStorage,dtbStorageDe,out newID,intSign);
			return lngRes;
		}
		#endregion

		#region ������ⵥ����(11-10)
		/// <summary>
		/// ������ⵥ����
		/// </summary>
		/// <param name="DtrStorage"></param>
		/// <param name="dtbStorageDe"></param>
		/// <param name="newID"></param>
		/// <returns></returns>
		public long m_lngSaveOut(DataRow DtrStorage,DataTable dtbStorageDe,out string newID)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngSaveOut(objPrincipal,DtrStorage,dtbStorageDe,out newID);
			return lngRes;
		}
		#endregion

		#region ɾ������(11-10)
		/// <summary>
		/// ɾ������(11-10)
		/// </summary>
		/// <param name="strID">��ⵥID</param>
		/// <param name="strDeID">��ⵥ��ϸID,��Ϊnullֻɾ����ϸ����</param>
		/// <param name="TolMoney">�����ܽ��</param>
		/// <param name="DelDeMoney">Ҫɾ����ϸ���ݵĽ��</param>
		/// <returns></returns>
		public long m_lngDelete(string strID,string strDeID,double TolMoney,double DelDeMoney)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngDelete(objPrincipal,strID,strDeID,TolMoney,DelDeMoney);
			return lngRes;
		}
		#endregion

		#region �޸�����(11-10)
		/// <summary>
		/// �޸�����
		/// </summary>
		/// <param name="UpOrdDe">��ϸ�����У���Ϊnull�����޸�</param>
		/// <param name="UpOrd">��ⵥ����</param>
		/// <returns></returns>
		public long m_lngModifiy(DataRow UpOrdDe,DataRow UpOrd)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngModifiy(objPrincipal,UpOrdDe,UpOrd);
			return lngRes;
		}
		#endregion

		#region ������ϸ��������(11-10)
		/// <summary>
		/// ������ϸ
		/// </summary>
		/// <param name="strOrdID">���ݺ�ID</param>
		/// <param name="tolMoney">���ݵ��ܽ��</param>
		/// <param name="ModifiyMoney">�������Ӻ�ĵ����ܽ��</param>
		/// <param name="dtbStorageDe">��ϸ����</param>
		/// <param name="strOrdDeID">������������ϸID</param>
		/// <returns></returns>
		public long m_lngAddNewDe(string strOrdID,double tolMoney,DataRow dtbStorageDe,out string strOrdDeID,out double ModifiyMoney)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAddNewDe(objPrincipal,strOrdID,tolMoney,dtbStorageDe,out strOrdDeID,out ModifiyMoney);
			return lngRes;
		}
		#endregion

		#region ��˹���(11-10)
		/// <summary>
		/// ��˹���
		/// </summary>
		/// <param name="stroageID">ҩ��ID</param>
		/// <param name="GrearName">�����ID</param>
		/// <param name="strID">����ID</param>
		/// <param name="OrdDeTable">��ⵥ��ϸ</param>
		/// <param name="intFlan">�����־��2-����,1-���,3-���γ��⣬4�������</param>
		/// <param name="blisAutoInsert">�Ƿ�Ҫ�Զ�������Ӧ����ⵥ</param>
		/// <param name="OrdTableRow">���ⵥ����</param>
		/// <returns></returns>
		public long m_lngAduiTemp(string strID,string stroageID,string GrearName,DataTable OrdDeTable,int intFlan,bool blisAutoInsert,DataRow OrdTableRow)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAduiTemp(objPrincipal,strID,stroageID,GrearName,OrdDeTable,intFlan,blisAutoInsert,OrdTableRow);
			return lngRes;
		}
		#endregion

		#region �����Ӧ�ĵ��ݺ��Ƿ����
		/// <summary>
		/// �����Ӧ�ĵ��ݺ��Ƿ����
		/// </summary>
		/// <param name="ordTypeName"></param>
		/// <param name="ordTypeID"></param>
		///  <param name="intFlan">0-ҩ����1-ҩ��</param>
		/// <returns></returns>
		public long m_lngGetOrdTypeID(out string ordTypeID,int intFlan)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetOrdTypeID(objPrincipal,out  ordTypeID,intFlan);
			return lngRes;
		}
		#endregion


		#region ���ҩ����ҩ���͡�ҩ����Ϣ
		/// <summary>
		/// ���ҩ����ҩ���͡�ҩ����Ϣ
		/// </summary>
		/// <param name="dtbType">��ҩ����</param>
		/// <param name="dtbStorage">ҩ��</param>
		/// <returns></returns>
		public long m_lngGetTypeAndStorageOut(string strTypeID,out string strTypeName,out DataTable dtbStorage)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetTypeAndStorageOut(objPrincipal,strTypeID,out strTypeName,out dtbStorage);
			return lngRes;
		}
		#endregion

		#region ������еĳ�ҩ����
        /// <summary>
        /// ������еĳ�ҩ����
        /// </summary>
        /// <param name="dtbResult"></param>
        ///  <param name="nowPriod">������ID</param>
        ///  <param name="strTypeID">����ID</param>
        /// <returns></returns>
		public long m_lngGetMedStoreOrdOut(string strTypeID,out DataTable dtbResult,string nowPriod)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreOrdOut(objPrincipal,strTypeID,out dtbResult,nowPriod);
			return lngRes;
		}
		#endregion

		#region ����ҩƷ�Ŀ��
		/// <summary>
		/// ����ҩƷ�Ŀ��
		/// </summary>
		/// <param name="StoreNumber"></param>
		/// <returns></returns>
		public long m_lngGetAllStorage(string strstogeId,string Medid,out int StoreNumber)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetAllStorage(objPrincipal,strstogeId,Medid,out StoreNumber);
			return lngRes;
		}
		#endregion

		#region ��˹���(��ҩ)
		/// <summary>
		/// ��˹���(��ҩ)
		/// </summary>
		/// <param name="stroageID"></param>
		/// <param name="GrearName"></param>
		/// <param name="strID"></param>
		/// <param name="OrdDeTable"></param>
		/// <returns></returns>
		public long m_lngAduiTempOut(string strID,string stroageID,string GrearName,DataTable OrdDeTable)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAduiTempOut(objPrincipal,strID,stroageID,GrearName,OrdDeTable);
			return lngRes;
		}
		#endregion

		#endregion

		#region ����ҩ������ҩ��¼��
		/// <summary>
		/// ����ҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_objItem">ҩ��������¼������</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region �޸�ҩ������ҩ��¼��
		/// <summary>
		/// �޸�ҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_objItem">ҩ��������¼������</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region �޸�ҩ������ҩ��¼��״̬��־
		/// <summary>
		/// �޸�ҩ������ҩ��¼��״̬��־
		/// </summary>
		/// <param name="strID">ҩ��������¼��ID</param>
		/// <param name="intStatus">״̬��־</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreOrdStatus(string strID,int intStatus)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreOrdStatus(objPrincipal,strID,intStatus);

			return lngRes;

		}
		#endregion

		#region ɾ��ҩ������ҩ��¼��
		/// <summary>
		/// ɾ��ҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strID">ҩ��������¼��ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreOrd(string p_strID)
		{
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngDeleteMedStoreOrd(objPrincipal,p_strID);
			return lngRes;
		}
		#endregion

		#region ���ҩ������ҩ��¼��
		/// <summary>
		/// ҩ������ҩ��¼�����
		/// </summary>
		/// <param name="p_objItem">ҩ��������¼������</param>
		/// <returns></returns>
		public long m_lngAduitMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAduitMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region ���ҩ������ҩ��¼������Ŀ��
		/// <summary>
		/// ҩ������ҩ��¼����˺���Ŀ��
		/// </summary>
		/// <param name="p_strID">ҩ��������¼��ID</param>
		/// <param name="p_intFlag">��ʶ��1���ɹ���0��ʧ�ܣ�-1���쳣</param>
		/// <returns></returns>
		public long m_lngChangeStorageAfterAduitMedStoreOrd(string p_strID,out int p_intFlag)
		{
			long lngRes = 0;
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeStorageAfterAduitMedStoreOrd(objPrincipal,p_strID,out p_intFlag);

			return lngRes;
		}
		#endregion

		#region ҩ������ҩ��¼������
		/// <summary>
		/// ҩ������ҩ��¼������
		/// </summary>
		/// <param name="p_objItem">ҩ��������¼������</param>
		/// <returns></returns>
		public long m_lngAcctMedStoreOrd(clsMedStoreOrd_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAcctMedStoreOrd(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region ҩ������ҩ��¼�����ʺ��������
		/// <summary>
		/// ҩ������ҩ��¼�����ʺ��������
		/// </summary>
		/// <param name="p_strID">ҩ��������¼��ID</param>
		/// <param name="p_intFlag">��ʶ��1���ɹ���0��ʧ�ܣ�-1���쳣</param>
		/// <returns></returns>
		public long m_lngChangeFinAfterAcctMedStoreOrd(string p_strID,out int p_intFlag)
		{
			long lngRes = 0;
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeFinAfterAcctMedStoreOrd(objPrincipal,p_strID,out p_intFlag);

			return lngRes;
		}
		#endregion

		#region ����ҩ������ҩ��ϸ����¼
		/// <summary>
		/// ����ҩ������ҩ��ϸ����¼
		/// </summary>
		/// <param name="p_objItem">ҩ������ҩ��ϸ����</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreOrdDe(clsMedStoreOrdDe_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreOrdDe(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region �޸�ҩ������ҩ��ϸ����¼
		/// <summary>
		/// �޸�ҩ������ҩ��ϸ����¼
		/// </summary>
		/// <param name="p_objItem">ҩ������ҩ��ϸ����</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreOrdDe(clsMedStoreOrdDe_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreOrdDe(objPrincipal,p_objItem);

			return lngRes;
		}
		#endregion

		#region ɾ��ҩ������ҩ��ϸ����¼
		/// <summary>
		/// ɾ��ҩ������ҩ��ϸ����¼
		/// </summary>
		/// <param name="p_strID">ҩ������ҩ��ϸID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreOrdDe(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedStoreOrdDe(objPrincipal,p_strID);

			return lngRes;
		}
		#endregion

		#region ģ����ѯҩ������ҩ��¼��
		/// <summary>
		/// ģ����ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByAny(string p_strSQL,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByAny(objPrincipal,p_strSQL,out p_objResultArr);

			return lngRes;	
		}
		#endregion

		#region ����¼��ID��ѯҩ������ҩ��¼��
		/// <summary>
		/// ����¼��ID��ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByID(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByID(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;	
		}
		#endregion

		#region ���������Ͳ�ѯҩ������ҩ��¼��
		/// <summary>
		/// ���������Ͳ�ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strID">��������ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByOrdType(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByOrdType(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ��ҩ����ѯҩ������ҩ��¼��
		/// <summary>
		/// ��ҩ����ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strID">ҩ��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByMedStore(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByMedStore(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ������ʱ���ѯҩ������ҩ��¼��
		/// <summary>
		/// ������ʱ���ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strStartDate">��ʼʱ��</param>
		/// <param name="p_strEndDate">����ʱ��</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByDate(string p_strStartDate,string p_strEndDate,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByDate(objPrincipal,p_strStartDate,p_strEndDate,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region �������ڲ�ѯҩ������ҩ��¼��
		/// <summary>
		/// �������ڲ�ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_strID">������ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByPeriod(string p_strID,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByPeriod(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ��״̬��־��ѯҩ������ҩ��¼��
		/// <summary>
		/// ��״̬��־��ѯҩ������ҩ��¼��
		/// </summary>
		/// <param name="p_intStatus">״̬��ʶ</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdByStatus(int p_intStatus,out clsMedStoreOrd_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrd_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdByStatus(objPrincipal,p_intStatus,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ģ����ѯҩ������ҩ��ϸ��
		/// <summary>
		/// ģ����ѯҩ������ҩ��ϸ��
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeByAny(string p_strSQL,out clsMedStoreOrdDe_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeByAny(objPrincipal,p_strSQL,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ��ҩ������ҩ��¼��ID��ѯҩ������ҩ��ϸ��
		/// <summary>
		/// ��ҩ������ҩ��¼��ID��ѯҩ������ҩ��ϸ��
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeByOrdID(string p_strID,out clsMedStoreOrdDe_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeByOrdID(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ��ҩƷ��ѯҩ������ҩ��ϸ��
		/// <summary>
		/// ��ҩƷ��ѯҩ������ҩ��ϸ��
		/// </summary>
		/// <param name="p_strID">ҩƷID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeByMedicine(string p_strID,out clsMedStoreOrdDe_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreOrdDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeByMedicine(objPrincipal,p_strID,out p_objResultArr);

			return lngRes;
		}
		#endregion

		#region ��ȡ��ǰ����ҩ������ҩ��¼��ID
		/// <summary>
		/// ��ȡ��ǰ����ҩ������ҩ��¼��ID
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdID(out string p_strID)
		{
			long lngRes = 0;	
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdID(objPrincipal,out p_strID);

			return lngRes;
		}
		#endregion

		#region ��ȡ��ǰ����ҩ����ʾ��ҩ��ϸ��ID
		/// <summary>
		/// ��ȡ��ǰ����ҩ����ʾ��ҩ��ϸ��ID
		/// </summary>
		/// <param name="p_strID">��ϸ��ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreOrdDeID(out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreOrdDeID(objPrincipal,out p_strID);

			return lngRes;
		}
		#endregion

		#endregion

		#region ҩ����ҩ����

		#region ��ϵͳ�ķ���

		#region ��ȡ��ǰ����ҩ����ҩ�����¼��ID
		/// <summary>
		/// ��ȡ��ǰ����ҩ����ҩ�����¼��ID
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <returns></returns>
		public long m_lngGetMedApplID(out string p_strID)
		{			
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplID(objPrincipal,out p_strID);

			return lngRes;	
		}
		#endregion

		#region ���ҩ�⡢ҩ����Ϣ
		/// <summary>
		/// ���ҩ�⡢ҩ����Ϣ
		/// </summary>
		/// <param name="dtbStorage">ҩ����Ϣ��</param>
		/// <param name="dtbStore">ҩ����Ϣ</param>
		/// <returns></returns>
		public long m_lngGetStoreAndStorage(out DataTable dtbStorage,out DataTable dtbStore)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetStoreAndStorage(objPrincipal,out dtbStorage,out dtbStore);

			return lngRes;	
		}
		#endregion

		#region ���ҩ����ҩ�����¼��
        /// <summary>
        /// ���ҩ����ҩ�����¼��
        /// </summary>
        /// <param name="p_objResultArr">�������</param>
        /// <param name="storageID">����ҩ��</param>
        /// <returns></returns>
		public long m_lngGetMedApplAll(out DataTable p_objResultArr,string storageID)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplAll(objPrincipal,out p_objResultArr,storageID);

			return lngRes;	
		}
		#endregion

		#region �������뵥
		/// <summary>
		/// �������뵥
		/// </summary>
		/// <param name="DtrAppl">���뵥��</param>
		/// <param name="dtbApplDe">��ϸ������</param>
		/// <param name="newid"></param>
		/// <returns></returns>
		public long m_lngApplSave(DataRow DtrAppl,DataTable dtbApplDe,out string newid)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngApplSave(objPrincipal,DtrAppl,dtbApplDe,out newid);
			

			return lngRes;	
		}
		#endregion

        #region �������뵥
        /// <summary>
        /// �������뵥
        /// </summary>
        /// <param name="DtrAppl">����</param>
        /// <param name="dtbApplDe">��ϸ������</param>
        /// <param name="newid"></param>
        /// <returns></returns>
        public long m_lngApplSave(DataTable DtrAppl, DataTable dtbApplDe, out string newid)
        {
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

            lngRes = objSvc.m_lngApplSave(objPrincipal, DtrAppl, dtbApplDe, out newid);


            return lngRes;
        }
        #endregion

		#region ���ݵ��Ż����ϸ
        /// <summary>
        /// ���ݵ��Ż����ϸ
        /// </summary>
        /// <param name="strID">���뵥ID</param>
        /// <param name="dtbApplDe">����������ϸ</param>
        /// <param name="strStorageID">ҩ��ID</param>
        /// <returns></returns>
		public long m_lngGetMedApplDeById(string strID,out DataTable  dtbApplDe,string strStorageID)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeById(objPrincipal,strID,out dtbApplDe,strStorageID);
			
			return lngRes;	
		}
		#endregion

		#region �޸����뵥����
		/// <summary>
		/// �޸����뵥����
		/// </summary>
		/// <param name="RowApplDe"></param>
		/// <param name="RowAppl"></param>
		/// <returns></returns>
		public long m_lngModifiyAppl(DataRow RowApplDe,DataRow RowAppl)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngModifiyAppl(objPrincipal,RowApplDe,RowAppl);
			
			return lngRes;	
		}
		#endregion

		#region ɾ������
		/// <summary>
		/// ɾ������
		/// </summary>
		/// <param name="strDeId"></param>
		/// <param name="strId"></param>
		/// <returns></returns>
		public long m_lngDeleAppl(string strDeId,string strId)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngDeleAppl(objPrincipal,strDeId,strId);
			
			return lngRes;	
		}
		#endregion


        #region �ύ���뵥
        /// <summary>
        /// �ύ���뵥
        /// </summary>
        /// <param name="strId"></param>
        /// <returns></returns>
        public long m_lngPutinAppll(string strId)
        {
            long lngRes = 0;
            clsMedStoreSvc objSvc =
                (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngPutinAppll(objPrincipal,strId);

            return lngRes;
        }
        #endregion

		#region �����뵥����һ����ϸ
		/// <summary>
		/// �����뵥����һ����ϸ
		/// </summary>
		/// <param name="strId"></param>
		/// <param name="RowDe"></param>
		/// <param name="newDeid">����ID</param>
		/// <returns></returns>
		public long m_lngAddApplDe(string strId,DataRow RowDe,out string newDeid)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAddApplDe(objPrincipal,strId,RowDe,out newDeid);
			
			return lngRes;	
		}
		#endregion

		#region �Զ�������ҩ���뵥
		/// <summary>
		/// �Զ�������ҩ���뵥
		/// </summary>
		/// <param name="dtbResult">�����������ݱ�</param>
		///  <param name="stroageID">ҩ��ID</param>
		/// <returns></returns>
		public long m_lngAutoGetMedAppl(out DataTable dtbResult,string stroageID)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngAutoGetMedAppl(objPrincipal,out dtbResult,stroageID);
			
			return lngRes;	
		}
		#endregion
		
		#region ���ҩ����Ϣ
		/// <summary>
		/// ���ҩ����Ϣ
		/// </summary>
		/// <param name="StoreID"></param>
		/// <param name="StoreName"></param>
		/// <returns></returns>
		public long m_lngGetMedStoreName(string StoreID,out string StoreName)
		{			
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreName(objPrincipal,StoreID,out StoreName);
			
			return lngRes;	
		}
		#endregion
		#endregion

		#region ����ҩ����ҩ�����¼��
		/// <summary>
		/// ����ҩ����ҩ�����¼��
		/// </summary>
		/// <param name="p_objItem">ҩ����ҩ�����¼������</param>
		/// <returns></returns>
		public long m_lngAddNewMedAppl(clsMedStoreMedAppl_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedAppl(objPrincipal,p_objItem);
			

			return lngRes;
		}
		#endregion

		#region �޸�ҩ����ҩ�����¼��
		/// <summary>
		/// �޸�ҩ����ҩ�����¼��
		/// </summary>
		/// <param name="p_objItem">ҩ����ҩ�����¼������</param>
		/// <returns></returns>
		public long m_lngUpdateMedAppl(clsMedStoreMedAppl_VO p_objItem)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedAppl(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region ɾ��ҩ����ҩ�����¼��
		/// <summary>
		/// ɾ��ҩ����ҩ�����¼��
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedAppl(string p_strID)
		{
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedAppl(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region ����ҩ����ҩ������ϸ����¼
		/// <summary>
		/// ����ҩ����ҩ������ϸ����¼
		/// </summary>
		/// <param name="p_objItem">ҩ����ҩ������ϸ����</param>
		/// <returns></returns>
		public long m_lngAddNewMedApplDe(clsMedStoreMedApplDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedApplDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region �޸�ҩ����ҩ������ϸ����¼
		/// <summary>
		/// �޸�ҩ����ҩ������ϸ����¼
		/// </summary>
		/// <param name="p_objItem">ҩ����ҩ������ϸ����</param>
		/// <returns></returns>
		public long m_lngUpdateMedApplDe(clsMedStoreMedApplDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedApplDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region ɾ��ҩ����ҩ������ϸ����¼
		/// <summary>
		/// ɾ��ҩ����ҩ������ϸ����¼
		/// </summary>
		/// <param name="p_strID">��ϸ��ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedApplDe(string p_strID)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedApplDe(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region ģ����ѯҩ����ҩ�����¼��
		/// <summary>
		/// ģ����ѯҩ����ҩ�����¼��
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplByAny(string p_strSQL,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ����¼��ID��ѯҩ����ҩ�����¼��
		/// <summary>
		/// ����¼��ID��ѯҩ����ҩ�����¼��
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplByID(string p_strID,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ҩ����ѯҩ����ҩ�����¼��
		/// <summary>
		/// ��ҩ����ѯҩ����ҩ�����¼��
		/// </summary>
		/// <param name="p_strID">ҩ��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplByMedStore(string p_strID,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByMedStore(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ������ҩ���ѯҩ����ҩ���뵥
		/// <summary>
		/// ������ҩ���ѯҩ����ҩ���뵥
		/// </summary>
		/// <param name="p_strID">�ⷿID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplByStorage(string p_strID,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByStorage(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ������ʱ���ѯҩ����ҩ���뵥
		/// <summary>
		/// ������ʱ���ѯҩ����ҩ���뵥
		/// </summary>
		/// <param name="p_strStartDate">��ʼʱ��</param>
		/// <param name="p_strEndDate">����ʱ��</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplByDate(string p_strStartDate,string p_strEndDate,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByDate(objPrincipal,p_strStartDate,p_strEndDate,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��״̬��־��ѯҩ����ҩ���뵥
		/// <summary>
		/// ��״̬��־��ѯҩ����ҩ���뵥
		/// </summary>
		/// <param name="p_intStatus">״̬��ʶ</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplByStatus(int p_intStatus,out clsMedStoreMedAppl_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedAppl_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplByStatus(objPrincipal,p_intStatus,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ģ����ѯҩ����ҩ������ϸ��
		/// <summary>
		/// ģ����ѯҩ����ҩ������ϸ��
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeByAny(string p_strSQL,out clsMedStoreMedApplDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ����ҩ�����¼��ID��ѯҩ����ҩ������ϸ��
		/// <summary>
		/// ����ҩ�����¼��ID��ѯҩ����ҩ������ϸ��
		/// </summary>
		/// <param name="p_strID">��¼��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeByApplID(string p_strID,out clsMedStoreMedApplDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeByApplID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ҩƷ��ѯҩ����ҩ������ϸ��
		/// <summary>
		/// ��ҩƷ��ѯҩ����ҩ������ϸ��
		/// </summary>
		/// <param name="p_strID">ҩƷID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeByMedicine(string p_strID,out clsMedStoreMedApplDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedApplDeByMedicine(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ȡ��ǰ����ҩ����ҩ������ϸ��ID
		/// <summary>
		/// ��ȡ��ǰ����ҩ����ҩ������ϸ��ID
		/// </summary>
		/// <param name="p_strID">��ϸ��ID</param>
		/// <returns></returns>
		public long m_lngGetMedApplDeID(out string p_strID)
		{			
			long lngRes = 0;	
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

//			lngRes = objSvc.m_lngGetMedApplDeID(objPrincipal,out p_strID);

			return lngRes;
		}
		#endregion

		#region �Զ������ҩ���뵥
		/// <summary>
		/// �Զ����ɲɹ���
		/// </summary>
		/// <param name="p_strID">ҩ��ID</param>
		/// <param name="p_objResult">�������</param>
		/// <returns></returns>
		public long m_lngAutoCalcMedAppl(string p_strID,out clsMedStoreMedApplDe_VO[] p_objResult)
		{
			long lngRes = 0;
			p_objResult = new clsMedStoreMedApplDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAutoCalcMedAppl(objPrincipal,p_strID,out p_objResult);
			
			return lngRes;
		}
		#endregion


		#endregion

		#region ҩ���̵�

		#region ��ϵͳ
		#region ������е��̵�����
        /// <summary>
        /// ������е��̵�����
        /// </summary>
        /// <param name="dtStorData"></param>
        /// <returns></returns>
		public long m_lngGetCheckStore(out DataTable dtStorData)
		{			
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetCheckStore(objPrincipal,out dtStorData);
			
			return lngRes;
		}
		#endregion

		#region �Զ����ɳ���ⵥ
		/// <summary>
		/// �Զ����ɳ���ⵥ
		/// </summary>
		/// <param name="dtStorCheckData"></param>
		/// <returns></returns>
		public long m_lngGetAutoGreat(DataTable dtStorCheckData)
		{			
			long lngRes = 0;			
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetAutoGreat(objPrincipal,dtStorCheckData);
			
			return lngRes;
		}
		#endregion

		#region �ж��Ƿ��������̵��������ĵ�������
		/// <summary>
		/// �ж��Ƿ��������̵��������ĵ�������
		/// </summary>
		/// <param name="typeName">�������������</param>
		/// <param name="typeID">���ص�������ID</param>
		/// <returns>2�У�3���Ǹ������ڸ��¿�����в�����</returns>
		public long m_lngisCheckType(string  typeName,out string typeID)
		{
			long lngRes = 0;
			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngisCheckType(objPrincipal,typeName,out typeID);
			
			return lngRes;
		}
		#endregion

		#endregion

		#region ����ҩ���̵��¼��
		/// <summary>
		/// ����ҩ���̵��¼��
		/// </summary>
		/// <param name="p_objItem">ҩ���̵��¼����</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region �޸�ҩ���̵��¼��
		/// <summary>
		/// �޸�ҩ���̵��¼��
		/// </summary>
		/// <param name="p_objItem">ҩ���̵��¼����</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region ɾ��ҩ���̵��¼��
		/// <summary>
		/// ɾ��ҩ���̵��¼��
		/// </summary>
		/// <param name="p_strID">ҩ���̵��¼��ID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreCheck(string p_strID)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedStoreCheck(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region ���ҩ���̵��¼��
		/// <summary>
		/// ���ҩ���̵��¼��
		/// </summary>
		/// <param name="p_objItem">ҩ���̵��¼������</param>
		/// <returns></returns>
		public long m_lngAduitMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAduitMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region ���ҩ���̵��¼������Ŀ��
		/// <summary>
		/// ���ҩ���̵��¼������Ŀ��
		/// </summary>
		/// <param name="p_strID">ҩ���̵��¼��ID</param>
		/// <param name="p_intFlag">��ʶ��1���ɹ���0��ʧ�ܣ�-1���쳣</param>
		/// <returns></returns>
		public long m_lngChangeStorageAfterAduitMedStoreCheck(string p_strID,out int p_intFlag)
		{			
			long lngRes = 0;	
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeStorageAfterAduitMedStoreCheck(objPrincipal,p_strID,out p_intFlag);
			
			return lngRes;
		}
		#endregion

		#region ҩ���̵��¼������
		/// <summary>
		/// ҩ���̵��¼������
		/// </summary>
		/// <param name="p_objItem">ҩ���̵��¼������</param>
		/// <returns></returns>
		public long m_lngAcctMedStoreCheck(clsMedStoreCheck_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAcctMedStoreCheck(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region ҩ���̵��¼�����ʺ��������
		/// <summary>
		/// ҩ���̵��¼�����ʺ��������
		/// </summary>
		/// <param name="p_strID">ҩ���̵��¼��ID</param>
		/// <param name="p_intFlag">��ʶ��1���ɹ���0��ʧ�ܣ�-1���쳣</param>
		/// <returns></returns>
		public long m_lngChangeFinAfterAcctMedStoreCheck(string p_strID,out int p_intFlag)
		{			
			long lngRes = 0;
			p_intFlag = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngChangeFinAfterAcctMedStoreCheck(objPrincipal,p_strID,out p_intFlag);
			
			return lngRes;
		}
		#endregion

		#region ����ҩ���̵���ϸ����¼
		/// <summary>
		/// ����ҩ���̵���ϸ����¼
		/// </summary>
		/// <param name="p_objItem">ҩ���̵���ϸ����</param>
		/// <returns></returns>
		public long m_lngAddNewMedStoreCheckDe(clsMedStoreCheckDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngAddNewMedStoreCheckDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region �޸�ҩ���̵���ϸ����¼
		/// <summary>
		/// �޸�ҩ���̵���ϸ����¼
		/// </summary>
		/// <param name="p_objItem">ҩ���̵���ϸ����</param>
		/// <returns></returns>
		public long m_lngUpdateMedStoreCheckDe(clsMedStoreCheckDe_VO p_objItem)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngUpdateMedStoreCheckDe(objPrincipal,p_objItem);
			
			return lngRes;
		}
		#endregion

		#region ɾ��ҩ���̵���ϸ����¼
		/// <summary>
		/// ɾ��ҩ���̵���ϸ����¼
		/// </summary>
		/// <param name="p_strID">ҩ���̵���ϸID</param>
		/// <returns></returns>
		public long m_lngDeleteMedStoreCheckDe(string p_strID)
		{			
			long lngRes = 0;			

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngDeleteMedStoreCheckDe(objPrincipal,p_strID);
			
			return lngRes;
		}
		#endregion

		#region ģ����ѯҩ���̵��¼��
		/// <summary>
		/// ģ����ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByAny(string p_strSQL,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;	
		}
		#endregion

		#region ���̵㵥ID��ѯҩ���̵��¼��
		/// <summary>
		/// ���̵㵥ID��ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_strID">�̵㵥ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByID(string p_strID,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ҩ����ѯҩ���̵��¼��
		/// <summary>
		/// ��ҩ����ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_strID">ҩ��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByMedStore(string p_strID,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;	
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByMedStore(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ���̵�ʱ���ѯҩ���̵��¼��
		/// <summary>
		/// ���̵�ʱ���ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_strStartDate">��ʼʱ��</param>
		/// <param name="p_strEndDate">����ʱ��</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByDate(string p_strStartDate,string p_strEndDate,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByDate(objPrincipal,p_strStartDate,p_strEndDate,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region �������ڲ�ѯҩ���̵��¼��
		/// <summary>
		/// �������ڲ�ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_strID">������ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByPeriod(string p_strID,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByPeriod(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;	
		}
		#endregion

		#region �����ݱ�־��ѯҩ���̵��¼��
		/// <summary>
		/// �����ݱ�־��ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_intStatus">״̬��־</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckByStatus(int p_intStatus,out clsMedStoreCheck_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheck_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckByStatus(objPrincipal,p_intStatus,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ģ����ѯҩ���̵���ϸ��
		/// <summary>
		/// ģ����ѯҩ���̵��¼��
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeByAny(string p_strSQL,out clsMedStoreCheckDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;	
			p_objResultArr = new clsMedStoreCheckDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ����¼��ID��ѯҩ���̵���ϸ��
		/// <summary>
		/// ����¼��ID��ѯҩ���̵���ϸ��
		/// </summary>
		/// <param name="p_strID">�̵��¼��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeByCheckID(string p_strID,out clsMedStoreCheckDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;	
			p_objResultArr = new clsMedStoreCheckDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeByCheckID(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ҩƷ��ѯҩ���̵���ϸ��
		/// <summary>
		/// ��ҩƷ��ѯҩ���̵���ϸ��
		/// </summary>
		/// <param name="p_strID">ҩƷID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeByMedicine(string p_strID,out clsMedStoreCheckDe_VO[] p_objResultArr)
		{			
			long lngRes = 0;
			p_objResultArr = new clsMedStoreCheckDe_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeByMedicine(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ȡ��ǰ����ҩ���̵��¼��ID
		/// <summary>
		/// ��ȡ��ǰ����ҩ���̵��¼��ID
		/// </summary>
		/// <param name="p_strID">ҩ���̵��¼��ID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckID(out string p_strID)
		{			
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckID(objPrincipal,out p_strID);
			
			return lngRes;	
		}
		#endregion

		#region ��ȡ��ǰ�����̵���ϸ��ID
		/// <summary>
		/// ��ȡ��ǰ�����̵���ϸ��ID
		/// </summary>
		/// <param name="p_strID">ҩ���̵���ϸID</param>
		/// <returns></returns>
		public long m_lngGetMedStoreCheckDeID(out string p_strID)
		{			
			long lngRes = 0;
			p_strID = "";

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));

			lngRes = objSvc.m_lngGetMedStoreCheckDeID(objPrincipal,out p_strID);
			
			return lngRes;
		}
		#endregion

		#endregion

		#region ҩ�����
		
		#region ģ����ѯҩ����ϸ���
		/// <summary>
		/// ģ����ѯҩ����ϸ���
		/// </summary>
		/// <param name="p_strSQL">SQL���</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreDetailByAny(string p_strSQL,out clsMedStoreDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreDetail_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreDetailByAny(objPrincipal,p_strSQL,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ҩ����ѯҩ����ϸ���
		/// <summary>
		/// ��ҩ����ѯҩ����ϸ���
		/// </summary>
		/// <param name="p_strID">ҩ��ID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreDetailByMedStore(string p_strID,out clsMedStoreDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreDetail_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreDetailByMedStore(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region ��ҩƷ��ѯҩ����ϸ���
		/// <summary>
		/// ��ҩƷ��ѯҩ����ϸ���
		/// </summary>
		/// <param name="p_strID">ҩƷID</param>
		/// <param name="p_objResultArr">�������</param>
		/// <returns></returns>
		public long m_lngGetMedStoreDetailByMedicine(string p_strID,out clsMedStoreDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr = new clsMedStoreDetail_VO[0];

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedStoreDetailByMedicine(objPrincipal,p_strID,out p_objResultArr);
			
			return lngRes;
		}
		#endregion

		#region �����շ���ĿID����ҩƷ���
		/// <summary>
		/// �����շ���ĿID����ҩƷ���
		/// </summary>
		/// <param name="p_strID">�շ���ĿID</param>
		/// <param name="p_decQty">ҩƷ����</param>
		/// <param name="p_blnResult">����Ƿ��㣺trueΪ����falseΪ��治�����������</param>
		/// <param name="p_decResult"></param>
		/// <returns></returns>
		public long m_lngCheckMedStoreMedicineStorageByID(string p_strID,decimal p_decQty,
			out bool p_blnResult,out decimal p_decResult)
		{
			long lngRes = 0;
			p_blnResult = false;
			p_decResult = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngCheckMedStoreMedicineStorageByID(objPrincipal,p_strID,p_decQty,
				out p_blnResult,out p_decResult);
			
			return lngRes;
		}
		#endregion

		#endregion

		#region ����Ա������
		/// <summary>
		/// ����Ա������
		/// </summary>
		/// <param name="p_strID">Ա��ID</param>
		/// <param name="p_strName">���Ա����</param>
		public long m_lngfinedata(string p_strID,out string p_strName,out string empID)
		{
			long lngRes = 0;

			clsOPMedStoreSvc objSvc = 
				(clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
			lngRes = objSvc.m_lngfinedata(objPrincipal,p_strID,out p_strName,out empID);
			
			return lngRes;
		}
		#endregion

		#region ����ģ��ķ���
		/// <summary>
		/// ����ģ��ķ���
		/// </summary>
		public long m_lngGetMedicine(out DataTable dtbResult)
		{
			long lngRes = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
			lngRes = objSvc.m_lngGetMedicine(objPrincipal,out dtbResult);
			
			return lngRes;
		}
		#endregion

		#region ����ҩ��ID����ҩ����Ϣ��������Ϣ
		/// <summary>
		/// ����ģ��ķ���
		/// </summary>
		public long m_lngGetStorageMessage(string strID,out DataTable dtstroageMessage ,out DataTable dtwindowsMessage,int intStatus)
		{
			long lngRes = 0;

			clsMedStoreSvc objSvc = 
				(clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = objSvc.m_lngGetStorageMessage(objPrincipal, strID, out dtstroageMessage, out dtwindowsMessage, intStatus);
			return lngRes;
		}
		#endregion
        #region ��ӡ������Ϣ
        /// <summary>
        /// ��ȡ��ӡ������Ϣ
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        public long m_lngGetRecipeDetail(string m_strRecipeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            clsDoctorWorkStationSvc m_objSvc = (clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDoctorWorkStationSvc));
            lngRes = m_objSvc.m_lngGetOutpatientRecipeDetail(objPrincipal, m_strRecipeID, out  obj_VO);
            return lngRes;
        }
        #endregion 
        #region ��ӡ������Ϣ
        /// <summary>
        /// ��ȡ��ӡ������Ϣ
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="obj_VO"></param>
        /// <returns></returns>
        public long m_lngGetOutpatientRecipeDetail(string m_strRecipeID, out clsOutpatientPrintRecipe_VO obj_VO)
        {
            long lngRes = 0;
            clsOPMedStoreSvc m_objSvc = (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = m_objSvc.m_lngGetOutpatientRecipeDetail(objPrincipal, m_strRecipeID, out  obj_VO);
            return lngRes;
        }
            #endregion 
        #region ��ȡ����������Ϣ
        /// <summary>
        /// ��ȡ����������Ϣ
        /// </summary>
        /// <param name="m_strRecipeID"></param>
        /// <param name="m_objRTVO"></param>
        /// <returns></returns>
        public long m_lngGetRecipeTypeInfo( string m_strRecipeID, out clsRecipeType_VO m_objRTVO)
        {
            long lngRes = 0;
            clsDoctorWorkStationSvc m_objSvc = (clsDoctorWorkStationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsDoctorWorkStationSvc));
            lngRes = m_objSvc.m_lngGetRecipeTypeInfo(objPrincipal, m_strRecipeID, out  m_objRTVO);
            return lngRes;
        }
       #endregion

        #region ����
        /// <summary>
        /// ҩ���½ᱨ��
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="arrPrID">Ҫͳ�ƵĲ������б�</param>
        /// <param name="strUpPr">Ҫͳ�Ƶĵ�һ��������</param>
        /// <param name="dt">������Ӧ�Ĳ�����ͳ������</param>
        /// <param name="strStorageID">�ֿ�ɣ�</param>
        /// <returns></returns>
        public long m_lngGetReportmoth(System.Collections.ArrayList arrPrID, string strUpPr, out DataTable dt, string strStorageID)
        {
            long lngRes = 0;
            clsMedStoreSvc m_objSvc = (clsMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsMedStoreSvc));
            lngRes = m_objSvc.m_lngGetReportmoth(objPrincipal, arrPrID, strUpPr, out  dt, strStorageID);
            return lngRes;
        }
        #endregion
        #region  ��ȡ����ID��ȡ������Ϣ
        /// <summary>
        ///  ��ȡ����ID��ȡ������Ϣ
        /// </summary>
        /// <param name="m_strCaseHistoryID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetCaseHistoryByID(string m_strCaseHistoryID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc m_objSvc = (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = m_objSvc.m_lngGetCaseHistoryByID(objPrincipal, m_strCaseHistoryID, out m_objTable);
            return lngRes;
        }
        #endregion
        #region  ��ȡ����ID��ȡ��Ŀ��Ϣ
        /// <summary>
        /// ��ȡ����ID��ȡ��Ŀ��Ϣ
        /// </summary>
        /// <param name="m_strCaseHistoryID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetItemsInformationByID(string m_strCaseHistoryID, out DataTable m_objTable)
        {
            long lngRes = 0;
            clsOPMedStoreSvc m_objSvc = (clsOPMedStoreSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsOPMedStoreSvc));
            lngRes = m_objSvc.m_lngGetItemsInformationByID(objPrincipal, m_strCaseHistoryID, out m_objTable);
            return lngRes;
        }
        #endregion
        #region  ��ȡע�䵥��Ϣ
        /// <summary>
        /// ��ȡ����ID��ȡ��Ŀ��Ϣ
        /// </summary>
        /// <param name="m_strCaseHistoryID"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetInjectionInfoByID(string m_strSid, out ArrayList m_objList1, out ArrayList m_objList2, out ArrayList m_objListGroup, out clsOutpatientPrintRecipe_VO m_objVo)
        {
            long lngRes = 0;
            clsCalPatientChargeSvc m_objSvc = (clsCalPatientChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCalPatientChargeSvc));
            lngRes = m_objSvc.m_lngGetPrintData(m_strSid,out m_objList1,out m_objList2,out m_objListGroup,out m_objVo);
            return lngRes;
        }
                #endregion
    }
}
