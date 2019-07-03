using System;
using System.Collections ;
using iCareData ;
using com.digitalwave.CheckOrderService ;



namespace iCare
{
	/// <summary>
	/// Summary description for clsNuclearOrderDomain.
	/// </summary>
	public class clsNuclearOrderDomain
	{
        //private clsNuclearOrderService m_objService;

		public clsNuclearOrderDomain()
		{
            //m_objService=new clsNuclearOrderService();
			//
			// TODO: Add constructor logic here
			//
		}
		
		/// <summary>
		/// 根据病人ID返回一个电脑多导睡眠图检查申请单对象数组
		/// </summary>
		/// <param name="p_strPatientID">病人ID</param>
		/// <param name="p_objEKGOrderArr">检查申请单对象数组，out型的</param>
		/// <returns>返回对象的个数</returns>
		public string[] lngGetNuclearOrderArrByPatientID(string p_strPatientID,string p_strPatientDate)
		{
            clsNuclearOrderService m_objService =
                (clsNuclearOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsNuclearOrderService));

			string[] m_strRe=new String[0];
            try
            {
                m_objService.m_lngGetTimeInfoOfAPatient(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strPatientID,p_strPatientDate,ref m_strRe);
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
		public long lngSave(bool p_bnlIsNew,clsNuclearOrder p_objNuclearOrder)
		{
            clsNuclearOrderService m_objService =
                (clsNuclearOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsNuclearOrderService));

            long lngRes = 0;
            try
            {
                if (p_bnlIsNew == true)
                    lngRes = m_objService.m_lngUpdateNuclearOrder(p_objNuclearOrder, enmUpdateAction.enmAddNew);
                else
                    lngRes = m_objService.m_lngUpdateNuclearOrder(p_objNuclearOrder, enmUpdateAction.enmEdit);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		public long lngDelete(clsNuclearOrder p_objNuclearOrder)
		{
            clsNuclearOrderService m_objService =
                (clsNuclearOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsNuclearOrderService));

            long lngRes = 0;
            try
            {
			    lngRes =  m_objService.m_lngUpdateNuclearOrder(p_objNuclearOrder,enmUpdateAction.enmDelete);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		public long GetNuclearOrder(string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate, out clsNuclearOrder p_objNuclearOrder)
		{
            clsNuclearOrderService m_objService =
                (clsNuclearOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsNuclearOrderService));

            long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetNuclearOrder(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strInPatientID, p_strInPatientDate, p_strCreateDate, out p_objNuclearOrder);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}
	}


	
}
