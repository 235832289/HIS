using System;
using System.Collections ;
using iCareData ;
using com.digitalwave.CheckOrderService;


namespace iCare
{
	/// <summary>
	/// Summary description for clsPSGOrderDomain.
	/// </summary>
	public class clsPSGOrderDomain
	{
        //private clsPSGOrderService  m_objService;

		public clsPSGOrderDomain()
		{
             //m_objService =new clsPSGOrderService();
			//
			// TODO: Add constructor logic here
			//
		}

			
		public ArrayList m_objPSGOrders=new ArrayList();

		/// <summary>
		/// 根据病人ID返回一个核医学检查申请单对象数组
		/// </summary>
		/// <param name="p_strPatientID">病人ID</param>
		/// <param name="p_objEKGOrderArr">检查申请单对象数组，out型的</param>
		/// <returns>返回对象的个数</returns>
		public string[] lngGetPSGOrderArrByPatientID(string p_strPatientID,string p_strPatientDate)
		{
			string[] m_strRe=new String[0];

            clsPSGOrderService m_objService =
                (clsPSGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPSGOrderService));

            try
            {
                m_objService.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strPatientID, p_strPatientDate, ref m_strRe);
            }
            finally
            {
                ////m_objService.Dispose();
            }
			return m_strRe;
		}

		/// <summary>
		/// 保存对象
		/// </summary>
		/// <param name="p_objEKGOrderArr">要保存的对象</param>
		/// <returns>返回1表示保存成功，返回0表示保存失败</returns>
		public long lngSave(bool p_bnlIsNew,clsPSGOrder p_objPSGOrder)
		{
            long lngRes = 0;
            clsPSGOrderService m_objService =
                (clsPSGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPSGOrderService));

            try
            {
			    if(p_bnlIsNew==true)
				    lngRes = m_objService.m_lngUpdatePSGOrder(p_objPSGOrder,enmUpdateAction.enmAddNew);
			    else
				    lngRes = m_objService.m_lngUpdatePSGOrder(p_objPSGOrder,enmUpdateAction.enmEdit);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		public long lngDelete(clsPSGOrder p_objPSGOrder)
		{
            long lngRes = 0;
            clsPSGOrderService m_objService =
                (clsPSGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPSGOrderService));

            try
            {
			    lngRes =  m_objService.m_lngUpdatePSGOrder(p_objPSGOrder,enmUpdateAction.enmDelete);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;

		}

		public long GetPSGOrder(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate, out clsPSGOrder p_objPSGOrder)
		{
			long lngRes = 0;
            clsPSGOrderService m_objService =
                (clsPSGOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPSGOrderService));

            try
            {
			    lngRes =   m_objService.m_lngGetPSGOrder(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPatientID,p_strInPatientDate,p_strCreateDate,out p_objPSGOrder);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
	}
	

}
