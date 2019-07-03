using System;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.ValueObject; //iCareData.dll
using com.digitalwave.iCare.middletier.LIS; //ILISDataAnalysis.dll --- data analysis interface; LIS_Svc.dll --- middle tier
using System.Net;
using System.Net.Sockets;

namespace com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller
{

	public class clsDataReceivedEventArgs : System.EventArgs
	{
		private string m_strReceiveData;
		public string ReceiveData
		{
			get
			{
				return this.m_strReceiveData;
			}
		}
		public clsDataReceivedEventArgs(string p_strReceiveData)
		{
			this.m_strReceiveData = p_strReceiveData;
		}
	}
	public delegate void DataReceivedEventHandler(object sender,clsDataReceivedEventArgs e);//申明委托

	/// <summary>
	/// 
	/// </summary>
	public class clsInstrument_Connection_Info
	 {
		public com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO objInstrument_Config_VO = null;
        //2012-01-19李泳潮修改
        public com.digitalwave.iCare.ValueObject.clsLIS_Equip_Base objInstrument_Config_VO2 = null;
        public com.digitalwave.iCare.ValueObject.clsLIS_Equip_DB_ConfigVO objInstrument_Config_DB = null;
		public com.digitalwave.iCare.middletier.LIS.infLISDataAnalysis objDataAnalyzer = null;
		public System.Windows.Forms.Timer objTimer = null;
	 }
	

	/// <summary>
	/// frmLIS_Data_Acquisition_Controller窗体逻辑控制类	xing.chen添加注释
	/// </summary>
	public class clsController_LIS_Data_Acquisition
	{
//		public com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO[] objConfig_List = null;

		//xing.chen add test code
		private com.digitalwave.Utility.clsLogText testLog = new com.digitalwave.Utility.clsLogText();

		public frmLIS_Data_Acquisition_Controller m_objViewer;
		public clsController_LIS_Data_Acquisition()
		{
			//
			// TODO: Add constructor logic here
			//

		}
		
		/// <summary>
		/// 获取与本计算机相关的仪器的设定信息	xing.chen添加注释
		/// </summary>
		/// <param name="frmLIS_Controller">frmLIS_Data_Acquisition_Controller对象</param>
		/// <param name="objConfig_List">设备详细设置信息（VO）</param>
        public void GetInstrumentSerialSetting(com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller frmLIS_Controller, ref com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO[] objConfig_List)
        {
            string strHost_Name = System.Net.Dns.GetHostName();
            System.Net.IPAddress objHost_IP = System.Net.Dns.Resolve(strHost_Name).AddressList[0];
            string strHost_IP = objHost_IP.ToString();

            com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc objLIS_Svc = (clsQueryLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc));
            long lngRes = objLIS_Svc.lngGetInstrumentSerialSetting(strHost_Name, out objConfig_List);
            if (lngRes == 1)
            {
                if (objConfig_List != null)
                {
                    int intCount = objConfig_List.Length;
                    if (intCount > 0)
                    {
                        frmLIS_Controller.m_cboInstrument.AddRangeItems(objConfig_List);
                    }
                }
            }
        }
        
        
        /// <summary>
        /// 获取与本计算机相关的仪器的设定信息	yongchao.li添加注释 2012-01-19
        /// </summary>
        /// <param name="frmLIS_Controller"></param>
        /// <param name="objConfig_List"></param>
        public void GetInstrumentSerialSetting2(com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller frmLIS_Controller, ref com.digitalwave.iCare.ValueObject.clsLIS_Equip_Base[] objConfig_List)
        {
            string strHost_Name = System.Net.Dns.GetHostName();
            System.Net.IPAddress objHost_IP = System.Net.Dns.Resolve(strHost_Name).AddressList[0];
            string strHost_IP = objHost_IP.ToString();

            com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc objLIS_Svc = (clsQueryLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc));

            long lngRes = objLIS_Svc.lngGetInstrumentSerialSetting2(strHost_Name, out objConfig_List);
            if (lngRes == 1)
            {
                if (objConfig_List != null)
                {
                    int intCount = objConfig_List.Length;
                    if (intCount > 0)
                    {
                        frmLIS_Controller.m_cboInstrument.AddRangeItems(objConfig_List);
                    }
                }
            }
        }
      
		/// <summary>
		/// 选择设备后将设备设定信息与窗体中的控件绑定	xing.chen添加注释  2012-01-19 李泳潮修改
		/// </summary>
		/// <param name="frmLIS_Controller">frmLIS_Data_Acquisition_Controller对象</param>
        public void SelectInstrument(com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller frmLIS_Controller)
        { 
            clsLIS_Equip_ConfigVO2 objEquip_ConfigVO1 = frmLIS_Controller.m_cboInstrument.SelectedItem as clsLIS_Equip_ConfigVO2;
            if (objEquip_ConfigVO1 != null)
            {
                frmLIS_Controller.m_txtBaudRate.Text = objEquip_ConfigVO1.strBaud_Rate;
                frmLIS_Controller.m_txtComNum.Text = objEquip_ConfigVO1.strCOM_No;
                frmLIS_Controller.m_txtDataBit.Text = objEquip_ConfigVO1.strData_Bit;
                switch (objEquip_ConfigVO1.strFlow_Control)
                {
                    case "0":
                        frmLIS_Controller.m_txtFlowControl.Text = "None";
                        break;
                    case "1":
                        frmLIS_Controller.m_txtFlowControl.Text = "Software";
                        break;
                    case "2":
                        frmLIS_Controller.m_txtFlowControl.Text = "Hardware";
                        break;
                }
                switch (objEquip_ConfigVO1.strParity)
                {
                    case "0":
                        frmLIS_Controller.m_txtParity.Text = "None";
                        break;
                    case "1":
                        frmLIS_Controller.m_txtParity.Text = "Even";
                        break;
                    case "2":
                        frmLIS_Controller.m_txtParity.Text = "Odd";
                        break;
                    case "3":
                        frmLIS_Controller.m_txtParity.Text = "Mark";
                        break;
                    case "4":
                        frmLIS_Controller.m_txtParity.Text = "Space";
                        break;
                }
                frmLIS_Controller.m_txtReceiveBuffer.Text = objEquip_ConfigVO1.strReceive_Buffer;
                frmLIS_Controller.m_txtSendBuffer.Text = objEquip_ConfigVO1.strSend_Buffer;
                frmLIS_Controller.m_txtStopBit.Text = objEquip_ConfigVO1.strStop_Bit;
                //frmLIS_Controller.m_ctlRemark.Text = "";
            }
          
            else
            {
                frmLIS_Controller.m_txtBaudRate.Text = "";
                frmLIS_Controller.m_txtComNum.Text = "";
                frmLIS_Controller.m_txtDataBit.Text = "";
                frmLIS_Controller.m_txtFlowControl.Text = "";
                frmLIS_Controller.m_txtParity.Text = "";
                frmLIS_Controller.m_txtReceiveBuffer.Text = "";
                frmLIS_Controller.m_txtSendBuffer.Text = "";
                frmLIS_Controller.m_txtStopBit.Text = "";
            }

            #region 修版本模式   2012-01-19 yongchao.li 修改
            //com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO objEquip_ConfigVO = (clsLIS_Equip_ConfigVO)frmLIS_Controller.m_cboInstrument.SelectedItem;

            //frmLIS_Controller.m_txtBaudRate.Text = objEquip_ConfigVO.strBaud_Rate;
            //frmLIS_Controller.m_txtComNum.Text = objEquip_ConfigVO.strCOM_No;
            //frmLIS_Controller.m_txtDataBit.Text = objEquip_ConfigVO.strData_Bit;
            //switch (objEquip_ConfigVO.strFlow_Control)
            //{
            //    case "0":
            //        frmLIS_Controller.m_txtFlowControl.Text = "None";
            //        break;
            //    case "1":
            //        frmLIS_Controller.m_txtFlowControl.Text = "Software";
            //        break;
            //    case "2":
            //        frmLIS_Controller.m_txtFlowControl.Text = "Hardware";
            //        break;
            //}

            //switch (objEquip_ConfigVO.strParity)
            //{
            //    case "0":
            //        frmLIS_Controller.m_txtParity.Text = "None";
            //        break;
            //    case "1":
            //        frmLIS_Controller.m_txtParity.Text = "Even";
            //        break;
            //    case "2":
            //        frmLIS_Controller.m_txtParity.Text = "Odd";
            //        break;
            //    case "3":
            //        frmLIS_Controller.m_txtParity.Text = "Mark";
            //        break;
            //    case "4":
            //        frmLIS_Controller.m_txtParity.Text = "Space";
            //        break;
            //}
            //frmLIS_Controller.m_txtReceiveBuffer.Text = objEquip_ConfigVO.strReceive_Buffer;
            //frmLIS_Controller.m_txtSendBuffer.Text = objEquip_ConfigVO.strSend_Buffer;
            //frmLIS_Controller.m_txtStopBit.Text = objEquip_ConfigVO.strStop_Bit;
            #endregion
           
		}
        /// <summary>
        /// 选择设备后将设备设定信息与窗体中的控件绑定	yongchao.li添加注释  2012-01-19
        /// </summary>
        /// <param name="frmLIS_Controller"></param>

        public void SelectInstrument2(com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller frmLIS_Controller)
        {
            com.digitalwave.iCare.ValueObject.clsLIS_Equip_ConfigVO objEquip_ConfigVO = (clsLIS_Equip_ConfigVO)frmLIS_Controller.m_cboInstrument.SelectedItem;
            if (objEquip_ConfigVO != null)
            {
                frmLIS_Controller.m_txtBaudRate.Text = objEquip_ConfigVO.strBaud_Rate;
                frmLIS_Controller.m_txtComNum.Text = objEquip_ConfigVO.strCOM_No;
                frmLIS_Controller.m_txtDataBit.Text = objEquip_ConfigVO.strData_Bit;
                switch (objEquip_ConfigVO.strFlow_Control)
                {
                    case "0":
                        frmLIS_Controller.m_txtFlowControl.Text = "None";
                        break;
                    case "1":
                        frmLIS_Controller.m_txtFlowControl.Text = "Software";
                        break;
                    case "2":
                        frmLIS_Controller.m_txtFlowControl.Text = "Hardware";
                        break;
                }

                switch (objEquip_ConfigVO.strParity)
                {
                    case "0":
                        frmLIS_Controller.m_txtParity.Text = "None";
                        break;
                    case "1":
                        frmLIS_Controller.m_txtParity.Text = "Even";
                        break;
                    case "2":
                        frmLIS_Controller.m_txtParity.Text = "Odd";
                        break;
                    case "3":
                        frmLIS_Controller.m_txtParity.Text = "Mark";
                        break;
                    case "4":
                        frmLIS_Controller.m_txtParity.Text = "Space";
                        break;
                }
                frmLIS_Controller.m_txtReceiveBuffer.Text = objEquip_ConfigVO.strReceive_Buffer;
                frmLIS_Controller.m_txtSendBuffer.Text = objEquip_ConfigVO.strSend_Buffer;
                frmLIS_Controller.m_txtStopBit.Text = objEquip_ConfigVO.strStop_Bit;
            }
            

            else
            {
                frmLIS_Controller.m_txtBaudRate.Text = "";
                frmLIS_Controller.m_txtComNum.Text = "";
                frmLIS_Controller.m_txtDataBit.Text = "";
                frmLIS_Controller.m_txtFlowControl.Text = "";
                frmLIS_Controller.m_txtParity.Text = "";
                frmLIS_Controller.m_txtReceiveBuffer.Text = "";
                frmLIS_Controller.m_txtSendBuffer.Text = "";
                frmLIS_Controller.m_txtStopBit.Text = "";
            }
        }



		/// <summary>
		/// 调用仪器的数据解析文件解析数据，然后将数据入库同时实时显示数据	xing.chen添加注释
		/// </summary>
		/// <param name="objDataAnalyzer">解析文件类对象</param>
		/// <param name="strData_Received">接收的数据</param>
		/// <param name="strInstrument_ID">仪器id</param>
		/// <param name="strInstrument_Name">仪器名</param>
		public void DigitalSerial_DataComing(com.digitalwave.iCare.middletier.LIS.infLISDataAnalysis objDataAnalyzer, string strData_Received, string strInstrument_ID,string strInstrument_Name)
		{
			try
			{
				if(objDataAnalyzer != null)
				{
					string[] strIntactDataList = objDataAnalyzer.strGetIntactData(strData_Received);
					if(strIntactDataList != null)
					{
						for(int j = 0; j < strIntactDataList.Length; j++)
						{
							string strIntactData = strIntactDataList[j];
							System.Collections.ArrayList arlResult = null;

							//xing.chen add test code
							testLog.Log2File(@"D:\logInfo.txt","Data Analysis",DateTime.Now.ToLongTimeString());
                            ////testLog.Log2File(@"D:\code\log.txt", strIntactData, DateTime.Now.ToLongTimeString());
                            //testLog.Log2File(@"D:\logInfo.txt", strIntactData, DateTime.Now.ToLongTimeString());

							long lngRes = objDataAnalyzer.lngDataAnalysis(strIntactData, out arlResult);
//							int z=0;
//							while(z<arlResult.Count)
//							{
//								if(((clsLIS_Device_Test_ResultVO)arlResult[z]).intIsGraphResult == 1)
//								{
//									arlResult.RemoveAt(z);
//								}
//								else
//								{
//									z++;
//								}
//							}
							com.digitalwave.iCare.ValueObject.clsLIS_Device_Test_ResultVO[] colDevice_Test_Results = (clsLIS_Device_Test_ResultVO[])arlResult.ToArray(typeof(com.digitalwave.iCare.ValueObject.clsLIS_Device_Test_ResultVO));
							if(arlResult != null)
							{
								try
								{
                                    //string str = arlResult.Count.ToString() + " 123";
                                    //testLog.Log2File(@"D:\logInfo.txt", str, DateTime.Now.ToLongTimeString());
									for(int i = 0; i < colDevice_Test_Results.Length; i++)
									{
										colDevice_Test_Results[i].strDevice_ID = strInstrument_ID;
									}

									com.digitalwave.iCare.middletier.LIS.clsLIS_Svc objLIS_Svc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsLIS_Svc));
									lngRes = 0;
									System.Collections.ArrayList arlOut = null;

									//xing.chen add test code
                                    
                                    testLog.Log2File(@"D:\logInfo.txt", "Data insert database", DateTime.Now.ToLongTimeString());

									lngRes = objLIS_Svc.lngAddLabResult(arlResult,out arlOut);
									if(lngRes >0)
									{
										arlResult = arlOut;
									}
								}
								catch(Exception ex)
								{
									string srr = ex.Message;
								}
								#region 显示实时信息
								if(lngRes > 0)
								{
									//xing.chen add test code
									testLog.Log2File(@"D:\logInfo.txt","Data Show",DateTime.Now.ToLongTimeString());

									colDevice_Test_Results = (clsLIS_Device_Test_ResultVO[])arlResult.ToArray(typeof(com.digitalwave.iCare.ValueObject.clsLIS_Device_Test_ResultVO));
									
									clsDeviceSampleDataKey objKey = new clsDeviceSampleDataKey();
									objKey.intResultBeginIndex = colDevice_Test_Results[0].intIndex;
									objKey.intResultEndIndex = colDevice_Test_Results[colDevice_Test_Results.Length - 1].intIndex;
									objKey.strDeviceID = strInstrument_ID;
									objKey.strDeviceName = strInstrument_Name;
									objKey.strDeviceSampleID = colDevice_Test_Results[0].strDevice_Sample_ID;
									objKey.strCheckDate = colDevice_Test_Results[0].strCheck_Date;
									m_objViewer.m_mthShowMessage(objKey,colDevice_Test_Results);
								}
								#endregion
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// 返回数据解析文件对象	xing.chen添加注释
		/// </summary>
		/// <param name="strData_Analysis_DLL">数据解析文件的dll名称</param>
		/// <param name="strData_Analysis_Namespace">数据解析文件的名称空间</param>
		/// <returns></returns>
		public object objGetDataAnalyzer(string strData_Analysis_DLL, string strData_Analysis_Namespace)
		{
			System.Reflection.Assembly objAssembly = null;
			System.Type objType = null;
			try
			{
				string strFilePath = System.AppDomain.CurrentDomain.BaseDirectory;
				strFilePath += "LIS_DataAnalyse\\";
				strFilePath += strData_Analysis_DLL;
				objAssembly = System.Reflection.Assembly.LoadFrom(strFilePath);
				if(objAssembly == null)
					return null;
				objType = objAssembly.GetType(strData_Analysis_Namespace);
				if(objType == null)
					return null;
			}
			catch
			{
				return null;
			}
			return Activator.CreateInstance(objType);
		}

		/// <summary>
		/// 返回仪器数据	xing.chen添加注释
		/// </summary>
		/// <param name="p_strDeviceID">仪器id</param>
		/// <param name="p_strDeviceSampleID">仪器样本id</param>
		/// <param name="p_strCheckDate">仪器检验日期</param>
		/// <param name="p_intBeginIndex"></param>
		/// <param name="p_intEndIndex"></param>
		/// <param name="p_objDeviceResultList">仪器数据（out VO）</param>
		public void m_mthGetDeviceData(string p_strDeviceID,string p_strDeviceSampleID,string p_strCheckDate,
			int p_intBeginIndex,int p_intEndIndex, out clsDeviceReslutVO[] p_objDeviceResultList)
		{
			System.Security.Principal.IPrincipal objPrincipal = null;
			p_objDeviceResultList = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc = (clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			
			long lngRes = objSvc.m_lngGetDeviceData(objPrincipal,p_strDeviceID,p_strDeviceSampleID, p_strCheckDate,
			 p_intBeginIndex, p_intEndIndex,out  p_objDeviceResultList);

		}
	}

	/// <summary>
	/// 重写toString（）方法，返回仪器样本数据字符串 xing.chen添加注释
	/// </summary>
	public class  clsDeviceSampleDataKey
	{
		public string strDeviceID;
		public string strDeviceName;
		public string strDeviceSampleID;
		public string strCheckDate;
		public int intResultBeginIndex;
		public int intResultEndIndex;
		public string strCommingDateTime;
		public override string ToString()
		{
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			sb.Append(strDeviceID);
			sb.Append("||");
			sb.Append(strCheckDate);
			sb.Append("||");
			sb.Append(strDeviceSampleID);
			sb.Append("||");
			sb.Append(intResultBeginIndex.ToString());
			sb.Append("||");
			sb.Append(intResultEndIndex.ToString());
			sb.Append("||");
			sb.Append(strCommingDateTime);
			return sb.ToString();
		}

	}

	#region xing.chen 8/10/2005	网络udp（自定义封装的）监听数据类
	public class clsController_NetWorkListener
	{
		public event DataReceivedEventHandler DataReceived;		//申明事件
		public event DataReceivedEventHandler Info;
		private string m_strIpAddress;
		private string m_strPort;
		private com.digitalwave.Utility.clsLogText m_log = new com.digitalwave.Utility.clsLogText();
		public clsController_NetWorkListener(string p_strIpAddress,string p_strPort)
		{
			//构造函数
			this.m_strIpAddress = p_strIpAddress;
			this.m_strPort = p_strPort;
		}

		
		private Socket m_Listener;
		private Socket m_socket;
		private byte[] m_buffer = new byte[30720];
		
		public void Start()
		{
			int intLocalPort = -1;
			try
			{
				intLocalPort = int.Parse(this.m_strPort);
			
				m_Listener = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
			
				System.Net.EndPoint localEP = new System.Net.IPEndPoint(System.Net.IPAddress.Any,intLocalPort);
			
				m_Listener.Bind(localEP);


				m_Listener.Listen(10);

				while(true)
				{
					m_socket = m_Listener.Accept();
					while(true)
					{
						int count = m_socket.Receive(m_buffer);
						if( count > 0 )
						{
							if(DataReceived != null)
							{
								DataReceived(this,new clsDataReceivedEventArgs(System.Text.Encoding.ASCII.GetString(m_buffer)));
							}
						}
						else
						{
							try
							{
								m_socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
							}
							catch{}
							m_socket.Close();
							m_socket = null;
							break;
						}
					}
				}
			}
			catch(Exception ex)
			{
				if(m_Listener != null)
				{
					if(m_Listener.Connected)
					{
						try
						{
							m_Listener.Shutdown(System.Net.Sockets.SocketShutdown.Both);
						}
						catch{}
					}
					m_Listener.Close();
					m_Listener = null;
				}
				if(m_socket != null)
				{
					if(m_socket.Connected)
					{
						try
						{
							m_socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
						}
						catch{}
					}
					m_socket.Close();
					m_socket = null;
				}
				try
				{
					m_log.LogError(ex);
				}
				catch{}
				if(Info != null)
				{
					Info(this,new clsDataReceivedEventArgs("联接错误"));
				}
			}
		}

		public void Stop()
		{
			if(m_Listener != null)
			{
				if(m_Listener.Connected)
				{
					try
					{
						m_Listener.Shutdown(System.Net.Sockets.SocketShutdown.Both);
					}
					catch{}
				}
				m_Listener.Close();
				m_Listener = null;
			}
			if(m_socket != null)
			{
				if(m_socket.Connected)
				{
					try
					{
						m_socket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
					}
					catch{}
				}
				m_socket.Close();
				m_socket = null;
			}
		}
	}
	#endregion
}
