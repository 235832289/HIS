using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace iCare.PACS
{
	/// <summary>
	/// PACS接口控件的封装调用类
	/// </summary>
	public class clsPACSTool
	{
		/// <summary>
		/// 显示影像
		/// </summary>
		/// <param name="p_objPatient">病人</param>
		/// <param name="p_frmCaller">调用影像的窗体</param>
		public static void s_mthShowPACS(clsPatient p_objPatient,Form p_frmCaller)
		{
			StreamWriter objSW = null;
			try
			{				
				objSW = new StreamWriter("c:\\veepacs\\Img_Temp.txt",false);
				//I:住院号；P:门诊卡号；C:过往检验号（可能多个）
				objSW.WriteLine("I:"+p_objPatient.m_StrInPatientID);
				if(p_objPatient.m_ObjPeopleInfo.m_Strhic_no != null && p_objPatient.m_ObjPeopleInfo.m_Strhic_no != "")
				{
					objSW.WriteLine("P:"+p_objPatient.m_ObjPeopleInfo.m_Strhic_no);
				}
//				objSW.WriteLine("");
				objSW.Flush();				
			}
			catch
			{
				if(objSW != null)
					objSW.Close();
				return;
			}
			
			if(objSW != null)
				objSW.Close();

			System.Threading.Thread.Sleep(500);
				
			try
			{
				Process objPacsImg = Process.Start("c:\\veepacs\\Img.exe");	
//				p_frmCaller.WindowState = FormWindowState.Minimized;//解决标题重复的问题
//				p_frmCaller.MdiParent.ShowInTaskbar = false;
//				p_frmCaller.MdiParent.Visible = false;
//				objPacsImg.WaitForExit();
//				p_frmCaller.MdiParent.ShowInTaskbar = true;
//				p_frmCaller.MdiParent.Visible = true;
//				p_frmCaller.WindowState = FormWindowState.Maximized;//解决标题重复的问题
			}
			catch
			{
				clsPublicFunction.ShowInformationMessageBox("调用影像查询出错，请检查是否已经安装。");
			}
		}

		public static bool s_blnSendBookingMSG(string p_strToWorkStation,string p_strMSG)
		{
//			StreamWriter objSW = null;
//			try
//			{				
//				objSW = new StreamWriter("c:\\veepacs\\Msg_Temp.txt",false,System.Text.Encoding.Default);
//				objSW.WriteLine(p_strToWorkStation);
//				objSW.WriteLine(p_strMSG);
//				objSW.Flush();				
//			}
//			catch
//			{
//				if(objSW != null)
//					objSW.Close();
//				return false;
//			}
//			
//			if(objSW != null)
//				objSW.Close();			
//
//			System.Threading.Thread.Sleep(500);
//
//			try
//			{
//				Process objPacsImg = Process.Start("c:\\veepacs\\Msg.exe");					
//			}
//			catch
//			{
//				return false;
//			}
			
			return true;
		}

		private static Hashtable s_hasStationName = null;
		/// <summary>
		/// 获取指定预约工作站的名称
		/// </summary>
		/// <param name="p_strStationType"></param>
		/// <returns></returns>
		public static string s_strGetStationName(int p_strStationType)
		{
			if(s_hasStationName == null)
			{
				try
				{
					System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();

					string [] strFilePathAll =  Application.ExecutablePath.Split('\\') ;
					string strFilePathHeader="";
					if(strFilePathAll!=null)
						for(int i=0;i<strFilePathAll.Length-3;i++)
							strFilePathHeader+=strFilePathAll[i]+"\\\\";
					string strStationXml = strFilePathHeader + "Templates\\\\PACSStation.xml" ;	

					xmlDoc.Load(strStationXml);

					s_hasStationName = new Hashtable();
                    
					foreach(XmlNode xndStationName in xmlDoc.DocumentElement.ChildNodes)
					{
						s_hasStationName.Add(xndStationName.Attributes["TYPEID"].Value,xndStationName.Attributes["NAME"].Value);
					}
				}
				catch
				{
					return "";
				}
			}

			return (string)s_hasStationName[p_strStationType.ToString()];
		}
	}
}
