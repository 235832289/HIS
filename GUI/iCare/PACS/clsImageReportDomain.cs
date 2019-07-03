using System;
using com.digitalwave.PACSService ;
using iCareData;
using System.Collections;

namespace iCare
{
	/// <summary>
	/// Summary description for clsImageReportDomain.
	/// </summary>
	public class clsImageReportDomain
	{
		public clsImageReportDomain()
		{
			//
			// TODO: Add constructor logic here
		}

		public void m_lngGetImageReportByPatientID(string p_strPatientID,out ImageReport[] m_ImageReportArr)
		{
            clsPACSService m_objServ =
                (clsPACSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPACSService));

			long lngResult=0;
            try
            {
                lngResult = m_objServ.m_lngGetImageReportByPatientID(p_strPatientID, out m_ImageReportArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return ;

//			if (lngResult<=0)
//			{
//				throw(new System.Exception());
			
//			}
//			else
//			{
//				m_IR=m_ImageReportArr;
//				return;
//			}
		}


		public void m_lngGetImageReportList(string p_strApplicationID,ImageReport[] m_IR,out string[] p_strApplicationIDArr)
		{
			
			ArrayList m_Return=new ArrayList();
			
			if(m_IR!=null)
			{
				foreach(ImageReport  m_Temp in m_IR)
				{	
					if (m_Temp.m_strApplicationID.Substring(0,p_strApplicationID.Length)==p_strApplicationID)
					{
						m_Return.Add(m_Temp.m_strApplicationID);

					}

				}

				p_strApplicationIDArr=(string[])m_Return.ToArray(typeof(string));	
			}
			else
			{
				p_strApplicationIDArr=new string[0];
			}
		

			return;
		
		}


		public void m_lngGetImageBookingByPatientID(string p_strPatientID,out ImageBooking[] m_ImageBookingArr)
		{
            clsPACSService m_objServ =
                (clsPACSService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPACSService));

			long lngResult=0;
            try
            {
                lngResult = m_objServ.m_lngGetImageBookingByPatientID(p_strPatientID,out m_ImageBookingArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return ;

//			if (lngResult<=0)
//			{
//				throw(new System.Exception());
//			}
//			else
//			{
//				m_IB=m_ImageBookingArr;
////				return;
//			}
		}


		public void m_lngGetImageBookingList(string p_strApplicationID,ImageBooking[] m_IB,out string[] p_strApplicationIDArr)
		{

			ArrayList m_Return=new ArrayList();
			
			if(m_IB!=null)
			{
				foreach(ImageBooking  m_Temp in m_IB)
				{	
					if (m_Temp.m_strApplicationID.Substring(0,p_strApplicationID.Length)==p_strApplicationID)
					{
						m_Return.Add(m_Temp.m_strApplicationID);

					}

				}

				p_strApplicationIDArr=(string[])m_Return.ToArray(typeof(string));
			}
			else
			{
				p_strApplicationIDArr=new string[0];
			}

			return;
		}
	}

	
}
