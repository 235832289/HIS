using System;
using System.Xml;
using com.digitalwave.PhysicianOrderService  ;
using System.IO;
using System.Text;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsPhysicianOrderDomain.
	/// </summary>
	public class clsPhysicianOrderDomain
	{
		public clsPhysicianOrderDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		

		#region 成员变量,刘颖源,2003-6-27 10:57:35

            //clsPhysicianOrderService m_objPhysicianOrderService =
            //    (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

		#endregion

		public long m_lngGetAllPhysicianOrderType(out clsPhysicianOrderTypeValue[] p_objPhysicianOrderTypeValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetAllPhysicianOrderType (out p_objPhysicianOrderTypeValue ));
		}

		public long m_lngGetAllPhysicianOrderUsage(out clsPhysicianOrderUsageValue [] p_objPhysicianOrderUsageValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetAllPhysicianOrderUsage (out p_objPhysicianOrderUsageValue ));
		}

		public long m_lngGetAllPhysicianOrderAddInInfo(out clsPhysicianOrderAddInInfoValue [] p_objPhysicianOrderAddInInfoValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetAllPhysicianOrderAddInInfo (out p_objPhysicianOrderAddInInfoValue ));
		}

		public long m_lngGetAllPhysicianOrderFrequencyInfo(out clsPhysicianOrderFrequencyInfoValue[] p_objPhysicianOrderFrequencyInfoValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetAllPhysicianOrderFrequencyInfo (out p_objPhysicianOrderFrequencyInfoValue ));
		}
		public long m_lngGetPhysicianOrderTypeDetail(string p_strOrderTypeID,out clsPhysicianOrderTypeDetailValue [] p_objPhysicianOrderTypeDetailValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetPhysicianOrderTypeDetail(p_strOrderTypeID ,out p_objPhysicianOrderTypeDetailValue )); 
		}

		public long m_lngCommitPhysicianOrder(clsPhysicianOrderBaseValue [] p_objPhysicianOrderBaseValueArr,clsPhysicianOrderContentValue [] p_objPhysicianOrderContentValueArr,clsPhysicianOrderAddInValue [] p_objPhysicianOrderAddInValueArr )
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngCommitPhysicianOrder (p_objPhysicianOrderBaseValueArr ,p_objPhysicianOrderContentValueArr ));			
		}
		public long m_lngCancelPhysicianOrder(string p_strInPatientID,string p_strInPatientDate, string p_strOpenDate,string p_strOrderID, string p_strCancelUserID)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngCancelPhysicianOrder (p_strInPatientID ,p_strInPatientDate ,p_strOpenDate ,p_strOrderID ,p_strCancelUserID ));
		}

		public long m_lngGetPhysicainOrderUnconfirmList(string p_strInPatientID,string p_strInPatientDate,out clsPhysicianOrderDetailListValue  [] p_objPhysicianOrderDetailListValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			long lngRes=(m_objPhysicianOrderService.m_lngGetPhysicainOrderUnconfirmList (p_strInPatientID ,p_strInPatientDate ,out p_objPhysicianOrderDetailListValue));
			return(lngRes );
		}

		public long m_lngPerformPhysicianOrders(clsPhysicianOrderPerformedListValue [] p_objPhysicianOrderPerformedListArr,clsPhysicianOrderPerformedAddInValue [] p_objPhysicianOrderPerformedAddInArr)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngPerformPhysicianOrders(p_objPhysicianOrderPerformedListArr,p_objPhysicianOrderPerformedAddInArr  ));
		}
		public long m_lngGetAllCombinationPhysicianOrder(string p_strInPatientID,string p_strInPatientDate,
			int p_intOrderFlag,int p_intIfConfirm,int p_intIfCancel,int p_intIfEnd,int p_intIfPerformed, 
			string p_strFromDate,string p_strToDate,
			out clsPhysicianOrderDetailListValue  [] p_objPhysicianOrderDetailListValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetAllCombinationPhysicianOrder(p_strInPatientID ,p_strInPatientDate ,p_intOrderFlag ,p_intIfConfirm ,p_intIfCancel ,p_intIfEnd ,p_intIfPerformed ,p_strFromDate,p_strToDate,out p_objPhysicianOrderDetailListValue ));
		}
		public long m_lngGetMedicineNameByPingYinCode(string p_strPingYinCode, out clsPhysicianOrderMedicineNameValue  [] p_objPhysicianOrderMedicineNameValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetMedicineNameByPingYinCode (p_strPingYinCode ,out p_objPhysicianOrderMedicineNameValue ));
		}
		public long m_lngGetMedicineNameByLatinCode(string p_strCode, out clsPhysicianOrderMedicineNameValue  [] p_objPhysicianOrderMedicineNameValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetMedicineNameByLatinCode(p_strCode ,out p_objPhysicianOrderMedicineNameValue )); 
		}
		public long m_lngGetMedicineType(string p_strMedicineID, out clsPhysicianOrderMedicineTypeValue [] p_objPhysicianOrderMedicineTypeValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetMedicineType (p_strMedicineID ,out p_objPhysicianOrderMedicineTypeValue ));
		}
		public long m_lngGetMedicineNameByEnglishCode(string p_strCode, out clsPhysicianOrderMedicineNameValue  [] p_objPhysicianOrderMedicineNameValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetMedicineNameByEnglishCode (p_strCode ,out p_objPhysicianOrderMedicineNameValue ));
		}

		public long m_lngGetMedicineNameByMedicineID(string p_strCode, out clsPhysicianOrderMedicineNameValue  [] p_objPhysicianOrderMedicineNameValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetMedicineNameByMedicineID (p_strCode ,out p_objPhysicianOrderMedicineNameValue ));
		}
		public long m_lngGetMedicineStandard(string p_strMedicineID,string p_strMedicineTypeID, out clsPhysicianOrderMedicineStandardValue [] p_objPhysicianOrderMedicineStandardValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetMedicineStandard (p_strMedicineID ,p_strMedicineTypeID ,out p_objPhysicianOrderMedicineStandardValue ));
		}

		public long m_lngConfirmPhysicianOrder(string p_strInPatientID,string p_strInPatientDate, string p_strOpenDate,string p_strOrderID, string p_strConfirmUserID,clsPhysicianOrderAddInValue [] p_objPhysicianOrderAddInValueArr)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngConfirmPhysicianOrder (p_strInPatientID ,p_strInPatientDate  ,p_strOpenDate ,p_strOrderID ,p_strConfirmUserID ,p_objPhysicianOrderAddInValueArr ));
		}
		public long m_lngStopPhysicianOrder(string p_strInPatientID,string p_strInPatientDate, string p_strOpenDate,string p_strOrderID, string p_strEndUserID)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngStopPhysicianOrder (p_strInPatientID ,p_strInPatientDate ,p_strOpenDate ,p_strOrderID ,p_strEndUserID ));
		}
		public long m_lngGetWaitToPerformOrders(string p_strInPatientID,string p_strInPatientDate,out clsPhysicianOrderDetailListValue  [] p_objPhysicianOrderDetailListValue)
		{
            clsPhysicianOrderService m_objPhysicianOrderService =
                (clsPhysicianOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPhysicianOrderService));

			return(m_objPhysicianOrderService.m_lngGetWaitToPerformOrders (p_strInPatientID ,p_strInPatientDate ,out p_objPhysicianOrderDetailListValue ));
		}
	}
}
