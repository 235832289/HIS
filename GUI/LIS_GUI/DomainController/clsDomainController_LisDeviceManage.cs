using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainControl_LisDevice ��ժҪ˵����
	/// Alex 2004-5-6
	/// </summary>
	public class clsDomainController_LisDeviceManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsDomainController_LisDeviceManage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			
		}
		#endregion

		#region �������������Ŀ�������Ŀ��Ӧ��ϵ ͯ�� 2004.07.20
		public long m_lngAddNewCheckItemDeviceCheckItem(clsLisCheckItemDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngAddNewCheckItemDeviceCheckItem(objPrincipal,p_objRecord);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸�����������Ŀ�������Ŀ��Ӧ��ϵ ͯ�� 2004.07.20
		public long m_lngModifyCheckItemDeviceCheckItem(string p_strSourceCheckItemID,clsLisCheckItemDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngModifyCheckItemDeviceCheckItem(objPrincipal,p_strSourceCheckItemID,p_objRecord);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ������������Ŀ�������Ŀ��Ӧ��ϵ ͯ�� 2004.07.20
		public long m_lngDelCheckItemDeviceCheckItem(string p_strSourceCheckItemID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngDelCheckItemDeviceCheckItem(objPrincipal,p_strSourceCheckItemID);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��������������ĿID��ѯ��Ӧ������������Ŀ�������Ŀ�Ĺ�ϵ ͯ�� 2004.07.20
		public long m_lngGetCheckItemDeviceCheckItem(string p_strDeviceCheckItemID,
			string p_strDeviceModelID,out clsLisCheckItemDeviceCheckItem_VO[] p_objCheckItemDeviceCheckItem)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetCheckItemDeviceCheckItem(objPrincipal,p_strDeviceCheckItemID,p_strDeviceModelID,out p_objCheckItemDeviceCheckItem);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ������������Ŀ ͯ�� 2004.07.19
		public long m_lngDelDeviceCheckItem(clsLisDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngDelDeviceCheckItem(objPrincipal,p_objRecord);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸�����������Ŀ ͯ�� 2004.07.19
		public long m_lngModifyDeviceCheckItem(clsLisDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngModifyDeviceCheckItem(objPrincipal,p_objRecord);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �������������Ŀ ͯ�� 2004.07.19
		public long m_lngAddNewDeviceItem(clsLisDeviceCheckItem_VO p_objRecord)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngAddNewDeviceItem(objPrincipal,p_objRecord);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ѯ���е�����������Ŀ�������Ŀ�Ķ�Ӧ��ϵ ͯ�� 2004.06.16
		public long m_lngGetCheckItemDeviceCheckItem(out clsLisCheckItemDeviceCheckItem_VO[] p_objCheckItemDeviceCheckItem)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetCheckItemDeviceCheckItem(objPrincipal,out p_objCheckItemDeviceCheckItem);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ�������豸 ͯ�� 2004.06.16
		public long m_lngDelDevice(string p_strDeviceID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngDelDevice(objPrincipal,p_strDeviceID);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸������豸 ͯ�� 2004.06.16
		public long m_lngModifyDevice(ref clsLisDevice_VO p_objDeviceVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngModifyDevice(objPrincipal,ref p_objDeviceVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��������豸 ͯ�� 2004.06.16
		public long m_lngAddDevice(ref clsLisDevice_VO p_objDeviceVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngAddDevice(objPrincipal,ref p_objDeviceVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ���е������豸�б� ͯ�� 2004.06.16
		public long m_lngGetAllDevice(out clsLisDevice_VO[] p_objLisDeviceListVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetAllDevice(objPrincipal,out p_objLisDeviceListVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ����������ͨѶ���� ͯ�� 2004.06.16
		public long m_lngDelDeviceSerial(string strDeviceModelID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngDelDeviceSerial(objPrincipal,strDeviceModelID);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸���������ͨѶ���� ͯ�� 2004.06.16
		public long m_lngModifyDeviceSerial(ref clsLisDeviceSerialSetUp_VO p_objDeviceSerialVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngModifyDeviceSerial(objPrincipal,ref p_objDeviceSerialVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �����������ͨѶ���� ͯ�� 2004.06.16
		public long m_lngAddDeviceSerial(ref clsLisDeviceSerialSetUp_VO p_objDeviceSerialVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngAddDeviceSerial(objPrincipal,ref p_objDeviceSerialVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ���е���������ͨѶ���� ͯ�� 2004.06.15
		public long m_lngGetAllDeviceSerial(out clsLisDeviceSerialSetUp_VO[] p_objDeviceSerialVOList)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetAllDeviceSerial(objPrincipal,out p_objDeviceSerialVOList);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ɾ�������ͺ� ͯ�� 2004.06.15
		public long m_lngDelDeviceModel(string strDeviceModelID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngDelDeviceModel(objPrincipal,strDeviceModelID);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸������ͺ� ͯ�� 2004.06.15
		public long m_lngModifyDeviceModel(ref clsLisDeviceModel_VO p_objDeviceModelVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngModifyDeviceModel(objPrincipal,ref p_objDeviceModelVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��������ͺ� ͯ�� 2004.06.15
		public long m_lngAddDeviceModel(ref clsLisDeviceModel_VO p_objDeviceModelVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngAddDeviceModel(objPrincipal,ref p_objDeviceModelVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ���е������ͺ�VO�б� ͯ�� 2004.06.15
		public long m_lngGetAllDeviceModelVOList(out clsLisDeviceModel_VO[] p_objDeviceModelVOList)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetAllDeviceModel(objPrincipal,out p_objDeviceModelVOList);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ����check_item_id��ѯ��Ӧ��Device_check_item�������Ϣ ͯ�� 2004.06.10
		public long m_lngGetDeviceCheckItemInfoByCheckItemID(string p_strCheckItemID,out clsLisDeviceCheckItem_VO objLisDeviceCheckItemVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetDeviceCheckItemInfoByCheckItemID(objPrincipal,p_strCheckItemID,out objLisDeviceCheckItemVO);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ������еļ����豸�ͺ� ͯ�� 2004.05.25
		public long m_lngGetDeviceModel(out DataTable dtbDeviceModel)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetAllDeviceModel(objPrincipal,out dtbDeviceModel);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ѯ����豸ID������ ���� 2004-4-8
		/// <summary>
		/// ��ѯ����豸ID������
		/// </summary>
		/// <param name="p_dtbDeviceID_Name"></param>
		/// <returns></returns>
		public long m_lngGetDeviceID_Name(out DataTable p_dtbDeviceID_Name)
		{
			long lngRes=0;
			p_dtbDeviceID_Name=null;
			com.digitalwave.iCare.middletier.LIS.clsDeviceSvc objDeviceSvc=null;
			objDeviceSvc=(com.digitalwave.iCare.middletier.LIS.clsDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsDeviceSvc));
			lngRes=objDeviceSvc.m_lngGetDeviceModelNameByDeviceID(objPrincipal,out p_dtbDeviceID_Name);			
			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ���������ͺ�ID�������п��õľ������� ���� 2004.05.07
		/// <summary>
		///  ���������ͺ�ID�������еľ������� ���� 2004.05.07
		/// </summary>
		/// <param name="p_objPrinipal"></param>
		/// <param name="p_strDeviceModelID"></param>
		/// <param name="p_dtbDevice"></param>
		/// <returns>
		/// DEVICEID_CHR
		/// DEVICENAME_VCHR
		/// </returns>
		public long m_lngGetDeviceByDeviceModelID(string[] p_strDeviceModelIDArr,out System.Data.DataTable p_dtbDevice)
		{
			long lngRes = 0;
			p_dtbDevice = null;
			System.Security.Principal.IPrincipal objPrincipal = null;
			

			
				com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
					(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
				lngRes = objSvc.m_lngGetDeviceByDeviceModelID(objPrincipal,p_strDeviceModelIDArr,out p_dtbDevice);
			
			return lngRes;
		}
		#endregion

		#region ������������ȡ�����ͺ��б�  ͯ�� 2004.07.19
		public long m_lngGetDeviceModelArrByDeviceCategoryID(string p_strDeviceCategoryID,out clsLisDeviceModel_VO[] p_objResultArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes = objSvc.m_lngGetDeviceModelArrByDeviceCategoryID(p_objPrincipal,p_strDeviceCategoryID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ü����豸�������б�
		/// <summary>
		/// ��ü����豸�������б�
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetLisDeviceCategory(out clsLisDeviceCategory_VO[] p_objResultArr)
		{
			p_objResultArr = new clsLisDeviceCategory_VO[0];
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes = objSvc.m_lngGetLisDeviceCategory(p_objPrincipal,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �õ����п��õļ����豸�б� ���� 2004.05.10	
		/// <summary>
		/// ��ѯ���е�ǰ���ü��������б�,
		/// ͣ������ΪNULL �� ���� ��ǰ���� �� �������� С�ڵ��ڵ�ǰ����,  
		/// ���� 2004.05.26
		/// </summary>
		/// <param name="p_dtbDeviceList">
		/// table:t_bse_lis_device
		/// column:
		/// deviceid_chr
		/// device_model_id_chr
		/// dataacquisitioncomputerip_chr
		/// begin_date_dat
		/// end_date_dat
		/// devicename_vchr
		/// place_vchr
		/// deptid_chr
		/// isdatatrans_int
		/// </param>
		/// <returns></returns>
		public long m_lngGetDeviceList(out DataTable p_dtbDeviceList)
		{
			long lngRes = 0;
			p_dtbDeviceList = null;
			System.Security.Principal.IPrincipal objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes = objDeviceSvc.m_lngGetDeviceList(objPrincipal,out p_dtbDeviceList);
//			objDeviceSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ͨ����������ü����豸
		/// <summary>
		/// ͨ����������ü����豸
		/// </summary>
		/// <param name="p_strDeviceCategoryID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetListDeviceByCategoryID(string p_strDeviceCategoryID,out clsLisDevice_VO[]  p_objResultArr)
		{
			p_objResultArr = new clsLisDevice_VO[0];
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes = objSvc.m_lngGetListDevice(p_objPrincipal,p_strDeviceCategoryID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ø��ͺż����豸�ļ�����Ŀ
		/// <summary>
		/// ��ø��ͺż����豸�ļ�����Ŀ
		/// </summary>
		/// <param name="p_strModelID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetCheckItemByModelID(string p_strModelID,out clsCheckItemAndDeviceItem_VO[] p_objResultArr)
		{
			p_objResultArr = new clsCheckItemAndDeviceItem_VO[0];
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
//			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = new com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc();
			lngRes = objSvc.m_lngGetCheckItemByModelID(p_objPrincipal,p_strModelID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ���������ͺŻ�ȡ�豸�ļ�����Ŀ
		public long m_lngGetCheckItemByModelID(string p_strModelID,out clsLisDeviceCheckItem_VO[] p_objResultArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
			lngRes = objSvc.m_lngGetCheckItemByModelID(p_objPrincipal,p_strModelID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ����豸������Ŀ
		/// <summary>
		/// ����豸������Ŀ
		/// </summary>
		/// <param name="p_strModelID"></param>
		/// <param name="p_intGraphFlag"></param>
		/// <param name="p_objItem"></param>
		public void m_mthDoAddNew(string p_strModelID,int p_intGraphFlag,clsCheckItemAndDeviceItem_VO p_objItem)
		{
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
//			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = new com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc();
			long lngRes = objSvc.m_lngDoAddNewDeviceItem(p_objPrincipal,p_strModelID,p_intGraphFlag,p_objItem);
//			objSvc.Dispose();
		}
		#endregion

		#region �޸��豸������Ŀ
		/// <summary>
		/// �޸��豸������Ŀ
		/// </summary>
		/// <param name="p_strModelID"></param>
		/// <param name="p_intGraphFlag"></param>
		/// <param name="p_objItem"></param>
		public void m_mthDoModify(string p_strModelID,int p_intGraphFlag,clsCheckItemAndDeviceItem_VO p_objItem)
		{
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
//			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = new com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc();
			long lngRes = objSvc.m_lngDoModifyDeviceItem(p_objPrincipal,p_strModelID,p_intGraphFlag,p_objItem);
//			objSvc.Dispose();
		}
		#endregion

		#region ɾ���豸������Ŀ
		/// <summary>
		/// ɾ���豸������Ŀ
		/// </summary>
		/// <param name="p_strModelID"></param>
		/// <param name="p_objItem"></param>
		public void m_mthDoDelete(string p_strModelID,clsCheckItemAndDeviceItem_VO p_objItem)
		{
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
//			com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objSvc = new com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc();
			long lngRes = objSvc.m_lngDeleteDeviceCheckItem(p_objPrincipal,p_strModelID,p_objItem);
//			objSvc.Dispose();
		}
		#endregion

        #region ��ӻ��޸������������� 2011-12-5
        /// <summary>
        /// ��ӻ��޸�������������
        /// </summary>
        /// <param name="p_objEquipVo"></param>
        /// <param name="p_blnAdd"></param>
        /// <returns></returns>
        public long m_lngAddSpecialDevice(clsLIS_Equip_DB_ConfigVO p_objEquipVo, bool p_blnAdd)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc = null;
            objDeviceSvc = (com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
            lngRes = objDeviceSvc.m_lngAddSpecialDevice(objPrincipal, p_objEquipVo, p_blnAdd);
            //			objDeviceSvc.Dispose();
            return lngRes;
        }
        #endregion
        #region ��ȡ������������������Ϣ 2011-12-5 shichun.chen
        /// <summary>
        /// ��ȡ������������������Ϣ
        /// </summary>
        /// <param name="p_objEquipVOArr"></param>
        /// <returns></returns>
        public long m_lngQuerySepcialDeviceInfo(out clsLIS_Equip_DB_ConfigVO[] p_objEquipVOArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc = null;
            objDeviceSvc = (com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
            lngRes = objDeviceSvc.m_lngQuerySepcialDeviceInfo(objPrincipal, out p_objEquipVOArr);
            return lngRes;
        }
       #endregion
        #region ɾ�������������� 2011-12-5
        /// <summary>
        /// ɾ��������������
        /// </summary>
        /// <param name="p_strDeviceModelID"></param>
        /// <returns></returns>
        public long m_lngDeleteSpecialDevice(string p_strDeviceModelID)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc objDeviceSvc = null;
            objDeviceSvc = (com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc));
            lngRes = objDeviceSvc.m_lngDeleteSpecialDevice(objPrincipal, p_strDeviceModelID);
            return lngRes;
        }
        #endregion
	}
}
