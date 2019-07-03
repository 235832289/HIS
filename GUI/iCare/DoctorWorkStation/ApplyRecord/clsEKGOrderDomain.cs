using System;
using System.Collections ;
using com.digitalwave.CheckOrderService ;
using iCareData ;

namespace iCare
{
	/// <summary>
	/// Summary description for clsEKGOrderDomain.
	/// </summary>
	public class clsEKGOrderDomain
	{
        //private clsEKGOrderService m_objService;
		//		public ArrayList m_objEKGOrders=new ArrayList();

		public clsEKGOrderDomain()
		{
            //m_objService=new clsEKGOrderService();

		}

	
		/// <summary>
		/// 根据病人ID返回一个心电图对象数组
		/// </summary>
		/// <param name="p_strPatientID">病人ID</param>
		/// <param name="p_objEKGOrderArr">心电图对象数组，out型的</param>
		/// <returns>返回对象的个数</returns>
		public string[] strGetEKGOrderArrByPatientID(string p_strPatientID,string p_strPatientDate)
		{
			string[] m_strAllDateTime=new string[0];

            clsEKGOrderService m_objService =
                (clsEKGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEKGOrderService));

            try
            {
                m_objService.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strPatientID, p_strPatientDate, ref m_strAllDateTime);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return m_strAllDateTime ;

				
			#region 测试数据
//			try
//			{
//				
//				clsEKGOrder[] m_objResult=new clsEKGOrder[m_objEKGOrders.Count];
//                
//				for(int m_lngRe=0;m_lngRe<m_objEKGOrders.Count;m_lngRe++)
//				{
//					m_objResult[m_lngRe]=(clsEKGOrder)m_objEKGOrders[m_lngRe];
//				}
//					
//				p_objEKGOrderArr=m_objResult;
//
//				return p_objEKGOrderArr.GetLength(0);
//				
//			}
//
//			catch(System.Exception ex)
//			{
//				p_objEKGOrderArr=new clsEKGOrder[1];
//				throw ex;
//				return 0;
//			}
			#endregion 
		}

		/// <summary>
		/// 保存对象
		/// </summary>
		/// <param name="p_objEKGOrderArr">要保存的对象</param>
		/// <returns>返回1表示保存成功，返回0表示保存失败</returns>
		public long lngSave(bool p_bnlIsNew,clsEKGOrder p_objEKGOrder)
		{

            clsEKGOrderService m_objService =
                    (clsEKGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEKGOrderService));

            long lngRes = 0;
            try
            {
			    if(p_bnlIsNew==true)
                    lngRes = m_objService.m_lngUpdateEKGOrder(p_objEKGOrder, enmUpdateAction.enmAddNew);
			    else
                    lngRes = m_objService.m_lngUpdateEKGOrder(p_objEKGOrder, enmUpdateAction.enmEdit);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
			#region 测试数据
//			clsEKGOrder[] m_objResult;
//
//			try
//			{
//				
//				if(p_bnlIsNew==true)
//				{
//					m_objResult=new clsEKGOrder[m_objEKGOrders.Count+1];
//				
//					m_objEKGOrders.Add(p_objEKGOrder);
//      			
//				}
//				else
//				{
//					m_objResult=new clsEKGOrder[m_objEKGOrders.Count];
//					
//					for(int n=0;n<m_objEKGOrders.Count ;n++)
//					{
//						if(((clsEKGOrder)m_objEKGOrders[n]).strInPatientID==p_objEKGOrder.strInPatientID && 
//							((clsEKGOrder)m_objEKGOrders[n]).strInPatientDate==p_objEKGOrder.strInPatientDate && 
//							DateTime.Parse(((clsEKGOrder)m_objEKGOrders[n]).strCreateDate)==DateTime.Parse(p_objEKGOrder.strCreateDate))
//						{
//							m_objEKGOrders[n]=p_objEKGOrder;
//							break;
//						}
//
//					}
//
//				}
//				for(int m_lngRe=0;m_lngRe<m_objEKGOrders.Count;m_lngRe++)
//				{
//					m_objResult[m_lngRe]=(clsEKGOrder)m_objEKGOrders[m_lngRe];
//				}
//
//				p_objEKGOrderArr=m_objResult;
//
//                return 1;
//				
//			}
//			catch(System.Exception ex)
//			{	throw ex;
//
//				p_objEKGOrderArr=m_objResult;
//				return 0;
//			}
			#endregion

		}

		public long lngDelete(clsEKGOrder p_objEKGOrder)
		{
            clsEKGOrderService m_objService =
                (clsEKGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEKGOrderService));

            long lngRes = 0;
            try
            {
                lngRes =  m_objService.m_lngUpdateEKGOrder(p_objEKGOrder,enmUpdateAction.enmDelete);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;

			#region 测试数据
//			clsEKGOrder[] m_objResult=new clsEKGOrder[m_objEKGOrders.Count-1];
//			try
//			{
//				
//				m_objEKGOrders.Remove(p_objEKGOrder);
//
//				for(int m_lngRe=0;m_lngRe<m_objEKGOrders.Count;m_lngRe++)
//				{
//					m_objResult[m_lngRe]=(clsEKGOrder)m_objEKGOrders[m_lngRe];
//				}
//
//				p_objEKGOrderArr=m_objResult;
//				return 1;
//			}
//			catch(System.Exception ex)
//			{throw ex;
//				p_objEKGOrderArr=m_objResult;
//				
//				return 0;
//			}
			#endregion

		}

		public long lngGetEKGOrder(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate,out clsEKGOrder p_objEKGOrder)
		{

            clsEKGOrderService m_objService =
                (clsEKGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEKGOrderService));

            long lngRes = 0;
            try
            {
                lngRes =   m_objService.m_lngGetEKGOrder(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_objEKGOrder);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
			#region 测试数据
//			try
//			{
//				foreach(clsEKGOrder m_objEKGOrder in p_objEKGOrderArr)
//				{
//					if(m_objEKGOrder.strInPatientID==p_strInPatientID && m_objEKGOrder.strInPatientDate==p_strInPatientDate && DateTime.Parse(m_objEKGOrder.strCreateDate)==DateTime.Parse(p_strCreateDate))
//						return m_objEKGOrder;
//				}
//
//				return null;
//			}
//			catch(System.Exception ex)
//			{
//				clsPublicFunction.ShowInformationMessageBox(ex.Message);
//				return null;
//			}
			
			#endregion

		}

	}


}
