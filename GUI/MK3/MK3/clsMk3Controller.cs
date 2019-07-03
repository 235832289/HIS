using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System.IO.Ports;
using System.Data;

namespace com.digitalwave.iCare.gui.LIS
{
    internal  class clsMk3Controller
    {
        #region 变量
        /// <summary>
        /// 窗体类
        /// </summary>
        frmMK3Operation m_objViewer;
        /// <summary>
        /// 串口
        /// </summary>
        internal SerialPort SerialCom = new SerialPort();
        /// <summary>
        /// 接收数据数组
        /// </summary>
        string[] strDataArr = null;
        /// <summary>
        /// 时间控制
        /// </summary>
        private System.Timers.Timer m_objTimers;
        /// <summary>
        /// 发送数据数组
        /// </summary>
        byte[] bytStart;
        /// <summary>
        /// 返回状态
        /// </summary>
        int intOk = 0;
        List<string> lstReceiveData;
        string m_strData_Holder = null;
        clsDataTreatment m_objController;
        clsCtl_MK3ItemSet m_objDomain;
        internal DataTable m_dtResult = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_objViewer"></param>
        public clsMk3Controller(frmMK3Operation p_objViewer,clsDataTreatment p_objController)
        {
            m_objViewer = p_objViewer;
            m_objController = p_objController;
            m_objDomain = new clsCtl_MK3ItemSet();
           
        }
        #endregion

        #region 获取与本计算机相关的仪器的设定信息
        /// <summary>
        /// 获取与本计算机相关的仪器的设定信息
        /// </summary>
        public void GetInstrumentSerialSetting()
        {
            SerialCom.PortName = m_objViewer.m_strPortName;
            SerialCom.BaudRate = 9600;
            SerialCom.DataBits = 8;
            SerialCom.StopBits = StopBits.One;
            SerialCom.Parity = Parity.None;
            SerialCom.DtrEnable = true;
            //SerialCom.WriteTimeout = 500;
            //SerialCom.ReadTimeout = 1000;
            //SerialCom.ReceivedBytesThreshold = 1;
        }
        #endregion

        #region 连接仪器
        /// <summary>
        /// 连接仪器
        /// </summary>
        /// <returns></returns>
        public virtual long m_lngStartWork()
        {
            lstReceiveData = new List<string>();
            bytStart = null;
            if (SerialCom.IsOpen)
            {
                MessageBox.Show(m_objViewer,"指定的串口已经打开", "酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                try
                {
                    SerialCom.Open();
                    SerialCom.DataReceived += new SerialDataReceivedEventHandler(SerialCom_DataReceived);
                    
                }
                catch(Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    SerialCom.Dispose();
                    return 0;
                }
                return 1;
            }
        }

        void SerialCom_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            bool blnSure=true;
            string inPutData = SerialCom.ReadExisting();
            if (bytStart == null)
            {
                return;
            }
            if (bytStart[0] != 80)
            {
                if (!string.IsNullOrEmpty(inPutData))
                {
                    strDataArr = null;
                    strDataArr = inPutData.Split(new char[] { '\r', '\n', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strDataArr[0] == "OK" || strDataArr[0] == "ER3" || strDataArr[0] == "ER1")
                    {
                        switch (bytStart[0])
                        {
                            case clsDPEMessage.m_bytAirBlank:
                                m_mthReplyJudge(strDataArr[0], "空气空白设置不对，是否继续", out blnSure);
                                if (!blnSure)
                                    return;
                                m_mthX2Order();
                                break;
                            case clsDPEMessage.m_bytShock:
                                m_mthReplyJudge(strDataArr[0], "振荡模式设置不对，是否继续", out blnSure);
                                if (!blnSure)
                                    return;
                                m_mthZ5Order();
                                break;
                            case clsDPEMessage.m_bytShockTime:
                                m_mthReplyJudge(strDataArr[0], "振荡速度设置不对，是否继续", out blnSure);
                                if (!blnSure)
                                    return;
                                m_mthE0Order();
                                break;
                            case clsDPEMessage.m_bytContinueWay:
                                m_mthReplyJudge(strDataArr[0], "进版方式设置不对，是否继续", out blnSure);
                                if (!blnSure)
                                    return;
                                m_mthF2Order();
                                break;
                            case clsDPEMessage.m_bytSelectFilter:
                                m_mthReplyJudge(strDataArr[0], "滤光片设置不对，是否继续", out blnSure);
                                if (!blnSure)
                                    return;
                                m_mthPOrder();
                                break;
                            case clsDPEMessage.m_bytStart:
                                //m_objViewer.m_txtState.Text = "成功启动计算机控制";
                                break;
                        }
                    }
                }
            }
            else
            {

                m_strData_Holder += inPutData;
                if (m_strData_Holder != null)
                {
                    if (m_strData_Holder.Length == 592)
                    {
                        m_mthDataTreatment();
                    }
                }
            } 
        }
 
        #endregion

        #region 停止连机
        /// <summary>
        /// 停止连机
        /// </summary>
        /// <returns></returns>
        public virtual long m_lngFinishWork()
        {
            intOk = 0;
            if (SerialCom != null)
            {
                SerialCom.Close();
                SerialCom.Dispose();
                return 1;
            }
            return 0;
        }
        #endregion

        #region 启动计算机控制
        /// <summary>
        /// 启动计算机控制
        /// </summary>
        /// <returns></returns>
        public virtual void m_lngStratComputer()
        {
            bytStart = null;
            bytStart = new byte[3];
            bytStart[0] = clsDPEMessage.m_bytStart;
            bytStart[1] = clsDPEMessage.m_bytCR;
            bytStart[2] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
        }

  
   
        #endregion

        #region 发送命令
        /// <summary>
        /// 发送命令
        /// </summary>
        /// <param name="buffer"></param>
        protected virtual void m_mthSend(byte[] buffer)
        {
            intOk = 0;
            SerialCom.Write(buffer, 0, buffer.Length);
        }
        #endregion

        #region 等待接收数据
        /// <summary>
        /// 等待接收数据
        /// </summary>
        public void m_mthWait()
        {
            while (intOk == 0)
            {
            }
            return;
        }
        #endregion

        #region 读板
        /// <summary>
        /// 读板
        /// </summary>
        public virtual void m_mthReadPlate()
        {
            bool blnSure = false;

            #region 发送A命令
           
            m_mthWait();
            //m_thInstrumentReply("空气空白设置不对", out blnSure);
            if (!blnSure)
            {
                return;
            }
            #endregion

            #region 发送X2
            blnSure=false;
            bytStart = null;
            bytStart = new byte[4];
            bytStart[0] = 88;
            bytStart[1] = 50;
            bytStart[2] = clsDPEMessage.m_bytCR;
            bytStart[3] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
            m_mthWait();
            //m_thInstrumentReply("振荡模式设置不对", out blnSure);
            if (!blnSure)
            {
                return;
            }
            #endregion

            #region 发送Z05命令
            bytStart = null;
            bytStart = new byte[5];
            bytStart[0] = 90;
            bytStart[1] = 32;
            bytStart[2] = 53;
            bytStart[3] = clsDPEMessage.m_bytCR;
            bytStart[4] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
            m_mthWait();
            //m_thInstrumentReply("振荡速度设置不对", out blnSure);
            //if (!blnSure)
            //{
            //    return;
            //}
            #endregion

            #region 发送EO命令
            bytStart = null;
            bytStart = new byte[4];
            bytStart[0] = clsDPEMessage.m_bytContinueWay;
            bytStart[1] = clsDPEMessage.m_bytContinueModel;
            bytStart[2] = clsDPEMessage.m_bytCR;
            bytStart[3] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
            m_mthWait();
            //m_thInstrumentReply("进版方式设置不对", out blnSure);
            if (!blnSure)
            {
                return;
            }
            #endregion

            #region 发送F2命令
            bytStart = null;
            bytStart = new byte[4];
            bytStart[0] = clsDPEMessage.m_bytSelectFilter;
            bytStart[1] = clsDPEMessage.m_bytSelectFilterModel;
            bytStart[2] = clsDPEMessage.m_bytCR;
            bytStart[3] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
            m_mthWait();
            //m_thInstrumentReply("选择滤光片方式不对", out blnSure);
            if (!blnSure)
            {
                return;
            }
            #endregion

            #region 发送P命令
            bytStart = null;
            bytStart = new byte[3];
            bytStart[0] = clsDPEMessage.m_bytMeasurement;
            bytStart[1] = clsDPEMessage.m_bytCR;
            bytStart[2] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
            m_mthWait();
            //m_thInstrumentReply("测量模式设置不对", out blnSure);
            if (!blnSure)
            {
                return;
            }
            #endregion
        }
        #endregion

        #region 发送A命令
        /// <summary>
        /// 发送A命令
        /// </summary>
        public virtual void m_mthAOrder()
        {
            lstReceiveData = new List<string>();
            bytStart = null;
            bytStart = new byte[3];
            bytStart[0] = clsDPEMessage.m_bytAirBlank;
            bytStart[1] = clsDPEMessage.m_bytCR;
            bytStart[2] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
        }
        #endregion

        #region 发送X2命令
        /// <summary>
        /// 发送X2命令
        /// </summary>
        public virtual void m_mthX2Order()
        {
            bytStart = null;
            bytStart = new byte[4];
            bytStart[0] = 88;
            bytStart[1] = 50;
            bytStart[2] = clsDPEMessage.m_bytCR;
            bytStart[3] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
        }
        #endregion

        #region 发送Z 5命令
        /// <summary>
        /// 发送Z 5命令
        /// </summary>
        public virtual void m_mthZ5Order()
        {
            bytStart = null;
            bytStart = new byte[5];
            bytStart[0] = 90;
            bytStart[1] = 32;
            bytStart[2] = 53;
            bytStart[3] = clsDPEMessage.m_bytCR;
            bytStart[4] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
        }
        #endregion

        #region 发送EO命令
        /// <summary>
        /// 发送EO命令
        /// </summary>
        public virtual void m_mthE0Order()
        {
            bytStart = null;
            bytStart = new byte[4];
            bytStart[0] = clsDPEMessage.m_bytContinueWay;
            bytStart[1] = clsDPEMessage.m_bytContinueModel;
            bytStart[2] = clsDPEMessage.m_bytCR;
            bytStart[3] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
        }
        #endregion

        #region 发送F2命令
        /// <summary>
        /// 发送F2命令
        /// </summary>
        public virtual void m_mthF2Order()
        {
            bytStart = null;
            bytStart = new byte[4];
            bytStart[0] = clsDPEMessage.m_bytSelectFilter;
            bytStart[1] = clsDPEMessage.m_bytSelectFilterModel;
            bytStart[2] = clsDPEMessage.m_bytCR;
            bytStart[3] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
        }
        #endregion

        #region 发送P命令
        /// <summary>
        /// 发送P命令
        /// </summary>
        public virtual void m_mthPOrder()
        {
            bytStart = null;
            bytStart = new byte[3];
            bytStart[0] = clsDPEMessage.m_bytMeasurement;
            bytStart[1] = clsDPEMessage.m_bytCR;
            bytStart[2] = clsDPEMessage.m_bytLF;
            m_mthSend(bytStart);
         
        }
        #endregion

        #region 数据分析
        /// <summary>
        /// 数据分析
        /// </summary>
        public void m_mthDataTreatment()
        {
            if (string.IsNullOrEmpty(m_strData_Holder))
            {
                return;
            }
            int j = m_strData_Holder.Length;
            string[] strReviceDataArr = m_strData_Holder.Split(new char[] { '\r', '\n', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            m_strData_Holder = null;
            List<clsLIS_Device_Test_ResultVO> p_lstResult = new List<clsLIS_Device_Test_ResultVO>();
            clsLIS_Svc objServ = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc));
            clsLIS_Device_Test_ResultVO[] objOutResultArr = null;
            string[] strSampleId = new string[96];
            string strCheckDate = null;
            string strDeviceId = null;
            string strCheckItemName = null;
            long lngRes = 0;
            strDeviceId = m_objViewer.m_strDeviceId;
            strCheckDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            strCheckItemName = m_objViewer.m_strCheckItemName;
            double dblCO;
            double dblTemp = 0;
            switch (strCheckItemName.ToLower())
            {
                case "hbeab":
                case "hbcab":
                    double.TryParse(strReviceDataArr[1], out dblTemp);
                    dblCO = dblTemp * 0.5;
                    break;
                default:
                    double.TryParse(strReviceDataArr[1], out dblCO);
                    if (dblCO < 0.05)
                    {
                        dblCO = 0.05;
                    }
                    dblCO = 2.1 * dblCO;
                    break;

            }
            if (strReviceDataArr == null)
            {
                return;
            }
            clsLIS_Device_Test_ResultVO objTemp = null;
            for (int i = 0; i < m_objViewer.m_strSampleArr.Length; i++)
            {
                objTemp = new clsLIS_Device_Test_ResultVO();
                objTemp.strDevice_Sample_ID = m_objViewer.m_strSampleArr[i];
                objTemp.strDevice_Check_Item_Name = strCheckItemName;
                objTemp.strCheck_Date = strCheckDate;
                objTemp.strDevice_ID = strDeviceId;
                double.TryParse(strReviceDataArr[i], out dblTemp);
                switch (strCheckItemName.ToLower())
                {
                    case "hbeab":
                    case "hbcab":
                        if (dblTemp > dblCO)
                        {
                            objTemp.strResult = "阴性";
                        }
                        else
                        {
                            objTemp.strResult = "阳性";
                        }
                        break;
                    default:
                        if (dblTemp < dblCO)
                        {
                            objTemp.strResult = "阴性";
                        }
                        else
                        {
                            objTemp.strResult = "阳性";
                        }
                        break;
                }
                p_lstResult.Add(objTemp);
            }
            if (p_lstResult.Count > 0)
            {
                //lngRes = lngAddLabResult(p_lstResult.ToArray(), true, out objOutResultArr);
                lngRes = objServ.lngAddLabResult(p_lstResult.ToArray(), true, out objOutResultArr);
                if (lngRes > 0 && objOutResultArr != null)
                {
                    m_mthDataShow(p_lstResult.ToArray());
                }
            }
        }
        #endregion

        #region 数据显示
        /// <summary>
        /// 数据显示
        /// </summary>
        /// <param name="objOutResultArr"></param>
        public void m_mthDataShow(clsLIS_Device_Test_ResultVO[] objOutResultArr)
        {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("strDevice_Sample_ID", typeof(string));
            dtResult.Columns.Add("strResult", typeof(string));
            DataRow dtRow = null;
            for (int i = 0; i < objOutResultArr.Length; i++)
            {
                dtRow = dtResult.NewRow();
                dtRow["strDevice_Sample_ID"] = objOutResultArr[i].strDevice_Sample_ID;
                dtRow["strResult"] = objOutResultArr[i].strResult;
                dtResult.Rows.Add(dtRow);
            }
            //m_objViewer.m_dgvResult.Invoke(new MethodInvoker(delegate()
            //{
            //    m_objViewer.m_dgvResult.DataSource = dtResult;
            //}));
        }
        #endregion

        #region 增加检验仪器结果, 多样本
        /// <summary>
        /// 增加检验仪器结果, 多样本
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <param name="p_blnMuiltySample"> TRUE = 多样本</param>
        /// <param name="p_objOutResultArr"></param>
        /// <returns></returns>
        public long lngAddLabResult(clsLIS_Device_Test_ResultVO[] p_objResultArr, bool p_blnMuiltySample, out clsLIS_Device_Test_ResultVO[] p_objOutResultArr)
        {
            p_objOutResultArr = null;
            clsLIS_Svc objServ = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc));
            long lngRes = 0;
            if (p_objResultArr == null || p_objResultArr.Length <= 0)
            {
                return lngRes;
            }

            if (p_blnMuiltySample)
            {
                List<string> lstSampleID = new List<string>();
                List<clsLIS_Device_Test_ResultVO> lstResult = new List<clsLIS_Device_Test_ResultVO>();
                List<clsLIS_Device_Test_ResultVO> lstOutResult = new List<clsLIS_Device_Test_ResultVO>();

                string strSampleID = "";
                string strSampleIDTemp = null;
                int idx = 0;
                for (idx = 0; idx < p_objResultArr.Length; idx++)
                {
                    strSampleID = p_objResultArr[idx].strDevice_Sample_ID;
                    if (strSampleID != strSampleIDTemp)
                    {
                        if (!lstSampleID.Contains(strSampleID))
                        {
                            lstSampleID.Add(strSampleID);
                        }
                        strSampleIDTemp = strSampleID;
                    }
                }

                clsLIS_Device_Test_ResultVO[] objResultTempArr = null;
                foreach (string str in lstSampleID)
                {
                    lstResult.Clear();
                    for (idx = 0; idx < p_objResultArr.Length; idx++)
                    {
                        if (str == p_objResultArr[idx].strDevice_Sample_ID)
                        {
                            lstResult.Add(p_objResultArr[idx]);
                        }
                    }
                    if (lstResult.Count > 0)
                    {
                        lngRes = objServ.lngAddLabResult(lstResult.ToArray(), out objResultTempArr);
                        if (lngRes > 0 && objResultTempArr != null && objResultTempArr.Length > 0)
                        {
                            lstOutResult.AddRange(objResultTempArr);
                        }
                    }
                }
                p_objOutResultArr = lstOutResult.ToArray();
            }
            else
            {
                lngRes = objServ.lngAddLabResult(p_objResultArr, out p_objOutResultArr);
            }

            return lngRes;
        }
        #endregion

        #region 仪器回复信息判断
        /// <summary>
        /// 仪器回复信息判断
        /// </summary>
        /// <param name="p_strResult"></param>
        /// <param name="p_strMessage"></param>
        /// <param name="p_blnSure"></param>
        public virtual void m_mthReplyJudge(string p_strResult,string p_strMessage, out bool p_blnSure)
        {
            if (p_strResult == "OK")
            {
                p_blnSure = true;
            }
            else
            {
                p_blnSure = MessageBox.Show(m_objViewer,p_strMessage, "酶标仪操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK;
                
            }
        }
        #endregion

        #region 获取项目信息
        /// <summary>
        /// 获取项目信息
        /// </summary>
        public void m_mthGetAllCheckItemCustomInfo()
        {
            long lngRes = 0;
            clsLisCheckItemCustom[] objCheckItemCustomArr = null;
            
            lngRes = m_objDomain.m_lngGetAllCheckItemCustomInfo(out objCheckItemCustomArr, out m_dtResult);
            if (lngRes > 0)
            {
                m_objViewer.m_cboItem.DisplayMember = "check_item_name_vchr";
                m_objViewer.m_cboItem.ValueMember = "check_item_id_chr";
                m_objViewer.m_cboItem.DataSource = m_dtResult;
            }
        }
        #endregion
    }
}
