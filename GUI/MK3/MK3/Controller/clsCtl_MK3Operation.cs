using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO.Ports;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.LIS;
using System.Drawing;
namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 酶标仪操作控制层
    /// </summary>
    public class clsCtl_MK3Operation:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// 窗体Viewer层
        /// </summary>
        frmMK3Operation m_objViewer;
        /// <summary>
        /// Domain层
        /// </summary>
        clsDomainController_MK3ItemSetManage m_objDomain;
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
        internal DataTable m_dtResult = null;
        /// <summary>
        /// 仪器通讯VO
        /// </summary>
        internal clsLisCheckItemCustomOrder m_objCheckItemCustomOrder = null;

        int intWavelength = 0;

        Stack<double> m_staSuffix = null;
        clsLisCheckItemCustomRes[] m_objCheckItemCustomResArr = null;
        string m_strCheckItemID = null;
        /// <summary>
        /// 仪器项目信息表
        /// </summary>
        internal DataTable m_dtDeviceModel = null;

        internal int intState = 0;
        /// <summary>
        /// 布局名称
        /// </summary>
        internal DataTable m_dtLayoutName = null;
        /// <summary>
        /// 布局信息
        /// </summary>
        internal DataTable m_dtLayoutInfo = null;
        DataTable m_dtLayout = null;
        string m_strData = null;
        /// <summary>
        /// 当前查询板子结果名称表
        /// </summary>
        DataTable dtPlateName = null;
        /// <summary>
        /// 所有板子结果名称表
        /// </summary>
        DataTable m_dtAllPlateName = null;
        #endregion

        #region 创建界面层
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmMK3Operation)frmMDI_Child_Base_in;
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
        }
        #endregion

        #region 构造函数
        public clsCtl_MK3Operation()
        {
            m_objDomain = new clsDomainController_MK3ItemSetManage();
        }
        #endregion

        #region 获取与本计算机相关的仪器的设定信息
        /// <summary>
        /// 获取与本计算机相关的仪器的设定信息
        /// </summary>
        public void GetInstrumentSerialSetting()
        {
            SerialCom.PortName = m_objViewer.m_strPortName;
            //SerialCom.PortName = "COM3";
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
                MessageBox.Show(m_objViewer, "指定的串口已经打开", "酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
            else
            {
                try
                {
                    SerialCom.Open();
                    SerialCom.DataReceived += new SerialDataReceivedEventHandler(SerialCom_DataReceived);

                }
                catch (Exception objEx)
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
            bool blnSure = true;
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
                            case clsDPEMessage.m_bytStart:
                                if (strDataArr[0] == "OK")
                                {
                                    m_objViewer.m_txtState.Invoke(new MethodInvoker(delegate()
                                    {
                                        m_objViewer.m_txtState.Text = "计算机控制启动成功";
                                    }));
                                    intState = 1;
                                }
                                else
                                {
                                    intState = 0;
                                }
                                break;
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
                        if (m_objCheckItemCustomOrder.m_strWavelength_chr == "1")
                        {
                            if (intWavelength != 1)
                            {
                                m_mthDeputy_filter();
                                intWavelength = 1;
                                m_strData = m_strData_Holder;
                                m_strData_Holder = null;
                            }
                            else
                            {
                                intWavelength = 0;
                                m_mthDataTreatment();
                            }
                        }
                        else
                        {
                            intWavelength = 0;
                            m_mthDataTreatment();
                        }
                        
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
            blnSure = false;
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

        #region 发送初始命令
        /// <summary>
        /// 发送初始命令
        /// </summary>
        public virtual void m_mthAOrder()
        {
            lstReceiveData = new List<string>();
            if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strAir_blank))
            {
                bytStart = null;
                bytStart = new byte[3];
                bytStart[0] = clsDPEMessage.m_bytAirBlank;
                bytStart[1] = clsDPEMessage.m_bytCR;
                bytStart[2] = clsDPEMessage.m_bytLF;
                m_mthSend(bytStart);
            }
            else
            {
                m_mthX2Order();
            }
            
        }
        #endregion

        #region 发送震荡速度命令
        /// <summary>
        /// 发送震荡速度命令
        /// </summary>
        public virtual void m_mthX2Order()
        {
            if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strShock_speed_chr))
            {
                bytStart = null;

                string strOrider = m_objCheckItemCustomOrder.m_strShock_speed_chr.Trim().Substring(1);
                byte[] bytOrder = System.Text.Encoding.Default.GetBytes(m_objCheckItemCustomOrder.m_strShock_speed_chr.Trim());
                //bytStart[0] = 88;
                //bytStart[1] = bytOrder;
                bytStart = new byte[bytOrder.Length + 2];
                for (int i = 0; i < bytOrder.Length; i++)
                {
                    bytStart[i] = bytOrder[i];
                }
                bytStart[bytOrder.Length] = clsDPEMessage.m_bytCR;
                bytStart[bytOrder.Length + 1] = clsDPEMessage.m_bytLF;
                m_mthSend(bytStart);
            }
           
        }
        #endregion

        #region 发送震荡时间命令
        /// <summary>
        /// 发送震荡时间命令
        /// </summary>
        public virtual void m_mthZ5Order()
        {
            if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strShock_time_chr))
            {
                bytStart = null;

                string strOrder = m_objCheckItemCustomOrder.m_strShock_time_chr.Trim();
                try
                { }
                catch
                { }
                byte[] bytOrder = System.Text.Encoding.Default.GetBytes(strOrder);
                int length = bytOrder.Length;
                bytStart = new byte[length + 2];
                for (int i = 0; i < length; i++)
                {
                    bytStart[i] = bytOrder[i];
                }
                bytStart[length] = clsDPEMessage.m_bytCR;
                bytStart[length + 1] = clsDPEMessage.m_bytLF;
                m_mthSend(bytStart);
            }
            else
            {
                m_mthE0Order();
            }
           
        }
        #endregion

        #region 发送进板方式命令命令
        /// <summary>
        /// 发送进板方式命令命令
        /// </summary>
        public virtual void m_mthE0Order()
        {
            if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strJin_plate_way_chr))
            {
                byte[] bytOrder = System.Text.Encoding.Default.GetBytes(m_objCheckItemCustomOrder.m_strJin_plate_way_chr.Trim());
                bytStart = null;
                int length = bytOrder.Length;
                bytStart = new byte[length + 2];
                for (int i = 0; i < length; i++)
                {
                    bytStart[i] = bytOrder[i];
                }
                bytStart[length] = clsDPEMessage.m_bytCR;
                bytStart[length + 1] = clsDPEMessage.m_bytLF;
                m_mthSend(bytStart);
            }
            else
            {
                m_mthF2Order();
            }
        }
        #endregion

        #region 发送主滤光片命令
        /// <summary>
        /// 发送F2命令
        /// </summary>
        public virtual void m_mthF2Order()
        {
            bytStart = null;
            if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strFilter_chr))
            {
                byte[] bytOrder = System.Text.Encoding.Default.GetBytes(m_objCheckItemCustomOrder.m_strFilter_chr.Trim());
                if (bytOrder == null)
                    return;
                int length = bytOrder.Length;
                bytStart = new byte[length + 2];
                for (int i = 0; i < length; i++)
                {
                    bytStart[i] = bytOrder[i];
                }
                bytStart[length] = clsDPEMessage.m_bytCR;
                bytStart[length + 1] = clsDPEMessage.m_bytLF;
                m_mthSend(bytStart);
            }
            else
            {
                m_mthPOrder();
            }
        }
        #endregion

        #region 发送副滤光片命令
        /// <summary>
        /// 发送副滤光片命令
        /// </summary>
        public virtual void m_mthDeputy_filter()
        {
            bytStart = null;
            if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strDeputy_filter_chr))
            {
                byte[] bytOrder = System.Text.Encoding.Default.GetBytes(m_objCheckItemCustomOrder.m_strDeputy_filter_chr.Trim());
                if (bytOrder == null)
                    return;
                int length = bytOrder.Length;
                bytStart = new byte[length + 2];
                for (int i = 0; i < length; i++)
                {
                    bytStart[i] = bytOrder[i];
                }
                bytStart[length] = clsDPEMessage.m_bytCR;
                bytStart[length + 1] = clsDPEMessage.m_bytLF;
                m_mthSend(bytStart);
            }
            else
            {
                m_mthPOrder();
            }
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
            clsLIS_Device_Test_ResultVO[] objOutResultArr = null;
            string[] strSampleId = new string[96];
            string strCheckDate = null;
            string strDeviceId = null;
            string strCheckItemName = null;
            long lngRes = 0;
            strDeviceId = m_objViewer.m_strDeviceId;
            //string[] strDataArr = m_strData.Split(new char[] { '\r', '\n', '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            strCheckDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (strReviceDataArr == null)
            {
                return;
            }
            clsLIS_Device_Test_ResultVO objTemp = null;
            string m_strNC = null;
            string m_strPC=null;
            string strCheckItemID = null;
            double dblFormalResult = 0.0;
            double dblQCFormalResult = 0.0;
            DataTable dbResult = m_dtResult.Copy();
            DataView dvTemp = dbResult.DefaultView;
            string strFormula = null;
            string strResult = null;
            List<clsLIS_Device_Test_ResultVO> p_lstResult2 = new List<clsLIS_Device_Test_ResultVO>();
            m_strCheckItemID = null;
            double dblNC;
            double dblPC;
            double dblValue;
            double dblQCNC;
            double dblQCPC;
            string strQcFormula = null;
            string strQCResultFormula=null;
            double dbQCResult;
            double dbTemp;
            string strQCResult=null;
            string m_strQCNC = null;
            string m_strQCPC = null;
            string strQCNCFormula = null;
            string strQCPCFormula = null;
            string strNCFormula = null;
            string strPCFormula = null;
            string strQCCheckItemID = null;
            List<clslisPlateResult> m_lstNC = new List<clslisPlateResult>();
            List<clslisPlateResult> m_lstPC = new List<clslisPlateResult>();
            clslisPlateResult objFormula = null;
            for (int i = 0; i < m_objViewer.m_lstTextBos.Count; i++)
            {
                objTemp = new clsLIS_Device_Test_ResultVO();
                dvTemp.RowFilter = "check_item_id_chr='" + m_objViewer.m_lstTextBos[i].m_strItmeID + "'";
                switch (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower())
                {
                    case "none":
                        objTemp.strResult = "";
                        break;
                    case "neg":
                        objFormula = new clslisPlateResult();
                        m_strNC = strReviceDataArr[i];
                        m_strQCNC = strReviceDataArr[i];
                        objTemp.strResult = strReviceDataArr[i];
                        objTemp.strResult2 = strReviceDataArr[i];
                        if (strQCCheckItemID == m_objViewer.m_lstTextBos[i].m_strItmeID)
                        {
                            objFormula.m_strSample_Result_vchr = m_strNC;
                            objFormula.m_strSampleid_vchr = m_objViewer.m_lstTextBos[i].m_strSampleID;
                            m_lstNC.Add(objFormula);
                        }
                        else
                        {
                            m_lstNC.Clear();
                        }
                        break;
                    case "pos":
                        objFormula = new clslisPlateResult();
                        m_strPC = strReviceDataArr[i];
                        objTemp.strResult = strReviceDataArr[i];
                        objTemp.strResult2 = strReviceDataArr[i];
                        if (strQCCheckItemID == m_objViewer.m_lstTextBos[i].m_strItmeID)
                        {
                            objFormula.m_strSample_Result_vchr = m_strPC;
                            objFormula.m_strSampleid_vchr = m_objViewer.m_lstTextBos[i].m_strSampleID;
                            m_lstPC.Add(objFormula);
                        }
                        else
                        {
                            m_lstPC.Clear();
                        }
                        break;
                    case "blk":
                        objTemp.strResult = strReviceDataArr[i];
                        objTemp.strResult2 = strReviceDataArr[i];
                        break;
                    case "qc":
                        if (m_lstNC.Count <= 0 || m_lstPC.Count <= 0)
                        {
                            return;
                        }
                        if (dvTemp != null && dvTemp.Count > 0)
                        {
                            strQcFormula = dvTemp[0]["qcfromula_vchr"].ToString().Trim();
                            strQCResultFormula = dvTemp[0]["qc_result_vchr"].ToString().Trim();
                            strQCNCFormula = dvTemp[0]["qc_neg_formula_vchr"].ToString().Trim();
                            strQCPCFormula = dvTemp[0]["qc_pos_formula_vchr"].ToString().Trim();
                        }
                        if (strQcFormula == null)
                            return;
                      
                        m_mthCalcContrast(strQCNCFormula,m_lstNC, out dblQCNC);
                        if (!string.IsNullOrEmpty(dvTemp[0]["qc_neg_maxvalue_vchr"].ToString().Trim()))
                        {
                            m_strQCNC = dvTemp[0]["qc_neg_maxvalue_vchr"].ToString().Trim();
                            if (dblQCNC > Convert.ToDouble(m_strQCNC))
                            {
                                m_strQCNC = m_strQCNC;
                            }
                            else
                            {
                                m_strQCNC = dblQCNC.ToString();
                            }
                        }
                        if (!string.IsNullOrEmpty(dvTemp[0]["qc_neg_minvalue_vchr"].ToString().Trim()))
                        {
                            m_strQCNC = dvTemp[0]["qc_neg_minvalue_vchr"].ToString().Trim();
                            if (dblQCNC < Convert.ToDouble(m_strQCNC))
                            {
                                m_strQCNC = m_strQCNC;
                            }
                            else
                            {
                                m_strQCNC = dblQCNC.ToString();
                            }
                        }
                        m_mthCalcContrast(strQCPCFormula, m_lstPC, out dblQCPC);
                        if (!string.IsNullOrEmpty(dvTemp[0]["qc_pos_maxvalue_vchr"].ToString().Trim()))
                        {
                            m_strQCPC = dvTemp[0]["qc_pos_maxvalue_vchr"].ToString().Trim();
                            if (dblQCPC > Convert.ToDouble(m_strQCPC))
                            {
                                m_strQCPC = m_strQCPC;
                            }
                            else
                            {
                                m_strQCPC = dblQCPC.ToString();
                            }
                        }
                        if (!string.IsNullOrEmpty(dvTemp[0]["qc_pos_minvalue_vchr"].ToString().Trim()))
                        {
                            m_strQCPC = dvTemp[0]["qc_pos_minvalue_vchr"].ToString().Trim();
                            if (dblQCPC < Convert.ToDouble(m_strQCPC))
                            {
                                m_strQCPC = m_strQCPC;
                            }
                            else
                            {
                                m_strQCPC = dblQCPC.ToString();
                            }
                        }
                        m_mthCalculator(strQcFormula, m_strQCNC, m_strQCPC, out dblFormalResult);
                        dbTemp = Convert.ToDouble(strReviceDataArr[i]);
                        if (dblFormalResult == 0.0)
                            return;
                        //dbQCResult = dbTemp / dblFormalResult;
                        m_mthGetQcResult(strReviceDataArr[i], dblFormalResult.ToString(), strQCResultFormula, out strQCResult);
                        objTemp.strResult = strQCResult;
                        objTemp.strResult2 = strReviceDataArr[i];
                        break;
                    case "smp":
                        if (m_lstNC.Count <= 0 || m_lstPC.Count <= 0)
                        {
                            return;
                        }
                        if (strCheckItemID != m_objViewer.m_lstTextBos[i].m_strItmeID)
                        {
                            if (m_lstNC.Count <= 0 || m_lstPC.Count <= 0)
                                return;
                            strFormula = dvTemp[0]["check_item_formula_vchr"].ToString().Trim();
                            
                            if (string.IsNullOrEmpty(strFormula))
                            {
                                continue;
                            }
                            strNCFormula = dvTemp[0]["qc_neg_formula_vchr"].ToString().Trim();
                            strPCFormula = dvTemp[0]["qc_pos_formula_vchr"].ToString().Trim();
                            m_mthCalcContrast(strNCFormula, m_lstNC, out dblNC);
                            if (!string.IsNullOrEmpty(dvTemp[0]["neg_maxvalue_vchr"].ToString().Trim()))
                            {
                                m_strNC = dvTemp[0]["neg_maxvalue_vchr"].ToString().Trim();
                                if (dblNC > Convert.ToDouble(m_strNC))
                                {
                                    m_strNC = m_strNC;
                                }
                                else
                                {
                                    m_strNC = dblNC.ToString();
                                }
                            }
                            if (!string.IsNullOrEmpty(dvTemp[0]["neg_minvalue_vchr"].ToString().Trim()))
                            {
                                m_strNC = dvTemp[0]["neg_minvalue_vchr"].ToString().Trim();
                                if (dblNC < Convert.ToDouble(m_strNC))
                                {
                                    m_strNC = m_strNC;
                                }
                                else
                                {
                                    m_strNC = dblNC.ToString();
                                }
                            }
                            m_mthCalcContrast(strPCFormula, m_lstPC, out dblPC);
                            if (!string.IsNullOrEmpty(dvTemp[0]["pos_maxvalue_vchr"].ToString().Trim()))
                            {
                                m_strPC = dvTemp[0]["pos_maxvalue_vchr"].ToString().Trim();
                                if (dblPC > Convert.ToDouble(m_strPC))
                                {
                                    m_strPC = m_strPC;
                                }
                                else
                                {
                                    m_strPC = dblPC.ToString();
                                }
                            }
                            if (!string.IsNullOrEmpty(dvTemp[0]["pos_minvalue_vchr"].ToString().Trim()))
                            {
                                m_strPC = dvTemp[0]["pos_minvalue_vchr"].ToString().Trim();
                                if (dblPC < Convert.ToDouble(m_strPC))
                                {
                                    m_strPC = m_strPC;
                                }
                                else
                                {
                                    m_strPC = dblPC.ToString();
                                }
                            }
                            if (string.IsNullOrEmpty(m_strNC) || string.IsNullOrEmpty(m_strPC))
                            {
                                return;
                            }
                            m_mthCalculator(strFormula,m_strNC,m_strPC, out dblFormalResult);
                        }
                        m_blnResultJudge(m_objViewer.m_lstTextBos[i].m_strItmeID, strReviceDataArr[i], dblFormalResult.ToString(), out strResult);
                        objTemp.strResult = strResult;
                        objTemp.strResult2 = strReviceDataArr[i];
                        strCheckItemID = m_objViewer.m_lstTextBos[i].m_strItmeID;
                        break;
                }
                objTemp.strDevice_ID = strDeviceId;
                objTemp.strCheck_Date = strCheckDate;
                objTemp.strDevice_Check_Item_Name = m_objViewer.m_lstTextBos[i].m_strCheckItemName;
                objTemp.strDevice_Sample_ID = m_objViewer.m_lstTextBos[i].m_strSampleID;
                if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "none")
                {
                    p_lstResult2.Add(objTemp);
                }
                else
                {
                    p_lstResult.Add(objTemp);
                    p_lstResult2.Add(objTemp);
                }
                strQCCheckItemID = m_objViewer.m_lstTextBos[i].m_strItmeID;
            }
            if (p_lstResult.Count > 0)
            {
                lngRes = new clsDomainController_MK3ItemSetManage().m_lngInsertDeviceResult(p_lstResult.ToArray());
                if (lngRes > 0)
                {
                    if (p_lstResult2.Count > 0)
                    {
                        m_mthDataShow(p_lstResult2.ToArray());
                    }
                }
                //m_mthDataShow(p_lstResult2.ToArray());
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
            for (int i = 0; i < m_objViewer.m_lstTextBos.Count; i++)
            {
                m_objViewer.m_lstTextBos[i].Invoke(new MethodInvoker(delegate()
                {
                    if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "none")
                    {
                        m_objViewer.m_lstTextBos[i].Text =objOutResultArr[i].strResult2;
                        if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "smp")
                        {
                            //m_objViewer.m_lstLbl[i].Text = objOutResultArr[i].strResult;
                            if (objOutResultArr[i].strResult == "阴性(-)")
                            {
                                m_objViewer.m_lstLbl[i].Text = m_objViewer.m_lstTextBos[i].m_strSampleID + "(-)";
                                m_objViewer.m_lstLbl[i].ForeColor = System.Drawing.Color.Black;
                            }
                            else
                            {
                                m_objViewer.m_lstLbl[i].Text = m_objViewer.m_lstTextBos[i].m_strSampleID + "(+)";
                                m_objViewer.m_lstLbl[i].ForeColor = System.Drawing.Color.Red;
                            }
                        }
                        if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "qc")
                        {
                            m_objViewer.m_lstLbl[i].Text = objOutResultArr[i].strResult;
                        } 
                    }
                   
                }));
            }

            m_objViewer.m_mthCalc();



            m_mthInsertPlateResult();
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
        public virtual void m_mthReplyJudge(string p_strResult, string p_strMessage, out bool p_blnSure)
        {
            if (p_strResult == "OK")
            {
                p_blnSure = true;
            }
            else
            {
                p_blnSure = MessageBox.Show(m_objViewer, p_strMessage, "酶标仪操作提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK;

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

        #region 获取自定义项目的发送命令
        /// <summary>
        /// 获取自定义项目的发送命令
        /// </summary>
        public long m_mthGetCheckItemCustomOrder()
        {
            long lngRes = 0;
            lngRes = new clsDomainController_MK3DeviceCommunications().m_lngQueryChcekItemCustomOrder(m_objViewer.m_strCheckItemID, out m_objCheckItemCustomOrder);
            return lngRes;
        }
        #endregion


        #region 计算器算法
        /// <summary>
        /// 计算器算法
        /// </summary>
        /// <param name="strNC"></param>
        /// <param name="strPC"></param>
        /// <param name="dbResult"></param>
        public void m_mthCalculator(string p_strFormula, string m_strNC, string m_strPC, out double p_dbResult)
        {
            p_strFormula = p_strFormula.Trim();
            p_strFormula = p_strFormula.Replace("NC", m_strNC);
            p_strFormula = p_strFormula.Replace("PC", m_strPC);
            string m_strFormula = null;
            m_staSuffix = new Stack<double>();
            m_mthConversion(p_strFormula, out m_strFormula);
            p_dbResult = m_dbRun(m_strFormula);
        }
        #endregion

        #region 计算对照NC,PC值
        /// <summary>
        /// 计算对照NC,PC值
        /// </summary>
        /// <param name="p_strFormula"></param>
        /// <param name="p_lstContrast"></param>
        /// <param name="p_dbResult"></param>
        public void m_mthCalcContrast(string p_strFormula, List<clslisPlateResult> p_lstContrast, out double p_dbResult)
        {
            p_strFormula = p_strFormula.Trim();
            for (int i = 0; i < p_lstContrast.Count; i++)
            {
                p_strFormula = p_strFormula.Replace(p_lstContrast[i].m_strSampleid_vchr, p_lstContrast[i].m_strSample_Result_vchr);
            }
            string m_strFormula = null;
            m_staSuffix = new Stack<double>();
            m_mthConversion(p_strFormula, out m_strFormula);
            p_dbResult = m_dbRun(m_strFormula);
        }
        #endregion

        #region 中缀表达式转后缀表达式
        /// <summary>
        /// 中缀表达式转后缀表达式
        /// </summary>
        /// <param name="p_strFormula"></param>
        /// <param name="p_strResult"></param>
        public void m_mthConversion(string p_strFormula, out string p_strResult)
        {
            p_strResult = null;
            Stack<char> m_staChar = new Stack<char>();
            p_strFormula = p_strFormula + "#";
            m_staChar.Push('#');
            char[] m_chrCharArr = p_strFormula.ToCharArray();
            string m_strTemp = null;
            bool blnIsNum = false;
            char m_chrTemp;
            char m_chrFront;
            char m_chrBack;
            int idx;
            int idxNext;
            char chr;
            bool blnNegative = false;

            for (int i = 0; i < m_chrCharArr.Length; i++)
            {
                blnNegative = false;
                chr = m_chrCharArr[i];
                if (char.IsDigit(chr) || chr == '.')
                {
                    m_strTemp += chr.ToString();
                    blnIsNum = true;
                }
                else
                {
                    if (blnIsNum)
                    {
                        p_strResult += m_strTemp + "|";
                        m_strTemp = "";
                    }
                    blnIsNum = false;
                    if (chr == '-')
                    {
                        if (i == 0)
                        {
                            blnNegative = true;
                            m_strTemp += chr.ToString();
                        }
                        else
                        {
                            p_strResult += "|";
                            if ((i + 1) < m_chrCharArr.Length)
                            {
                                m_chrFront = m_chrCharArr[i - 1];
                                m_chrBack = m_chrCharArr[i + 1];
                                if (!char.IsDigit(m_chrFront) && char.IsDigit(m_chrBack))
                                {
                                    m_strTemp += chr.ToString();
                                    blnNegative = true;
                                }
                            }
                        }
                        if (!blnNegative)
                        {
                            for (int j = 0; j < m_staChar.Count; j++)
                            {
                                m_chrTemp = m_staChar.Pop();
                                idx = m_intLsp(m_chrTemp);
                                idxNext = m_intLsp('-');
                                if (idx >= idxNext)
                                {
                                    p_strResult += m_chrTemp.ToString();
                                }
                                else
                                {
                                    m_staChar.Push(m_chrTemp);
                                    m_staChar.Push('-');
                                }
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            //p_strResult += "|";
                            if (chr == ')')
                            {
                                for (m_chrTemp = m_staChar.Pop(); m_chrTemp != '('; m_chrTemp = m_staChar.Pop())
                                {
                                    p_strResult += m_chrTemp.ToString() + "|";
                                }
                            }
                            //else if (chr == '#')
                            //{
                            //    for (m_chrTemp = m_staChar.Pop(); m_chrTemp != '#'; m_chrTemp = m_staChar.Pop())
                            //    {
                            //        p_strResult += m_chrTemp.ToString() + "|";
                            //    }
                            //}
                            else
                            {
                                for (m_chrTemp = m_staChar.Pop(); m_intLsp(m_chrTemp) > m_intChar(chr); m_chrTemp = m_staChar.Pop())
                                {
                                    p_strResult += m_chrTemp.ToString() + "|";
                                }
                                m_staChar.Push(m_chrTemp);
                                m_staChar.Push(chr);
                            }
                        }
                        catch
                        {
                            p_strResult = "0";  //添加1111
                        }
                    }
                }
            }
        }
        #endregion

        #region 栈里的字符优先级的判断
        /// <summary>
        /// 优先级的判断
        /// </summary>
        /// <param name="p_strVariable"></param>
        /// <returns></returns>
        public int m_intLsp(char p_chrVariable)
        {
            int k = -1;
            switch (p_chrVariable)
            {
                case '#':
                    k = 0;
                    break;
                case '(':
                    k = 2;
                    break;
                case '+':
                case '-':
                    k = 4;
                    break;
                case '*':
                case '/':
                case '%':
                    k = 6;
                    break;
                case ')':
                    k = 2;
                    break;
            }
            return k;
        }
        #endregion

        #region 字符串里的字符优先级判断
        /// <summary>
        /// 字符串里的字符优先级判断
        /// </summary>
        /// <param name="p_chrValue"></param>
        /// <returns></returns>
        public int m_intChar(char p_chrValue)
        {
            int k = -1;
            switch (p_chrValue)
            {
                case '#':
                    k = 1;
                    break;
                case '+':
                case '-':
                    k = 3;
                    break;
                case '*':
                case '/':
                    k = 5;
                    break;
                case '(':
                    k = 8;
                    break;
                case ')':
                    k = 1;
                    break;
            }
            return k;
        }
        #endregion

        

        #region 后缀表达式计算结果
        /// <summary>
        /// 后缀表达式计算结果
        /// </summary>
        /// <param name="p_strFormula"></param>
        /// <returns></returns>
        public double m_dbRun(string p_strFormula)
        {
            string[] strFormulaArr = p_strFormula.Split(new char[] {'|','\r','\n'},StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strFormulaArr)
            {
                if (m_blnIsNumber(str))
                {
                    double dblTemp = Convert.ToDouble(str);
                    m_staSuffix.Push(dblTemp);
                }
                else
                {
                    m_mthDoOperator(str);
                }
            }
            try
            {
                return (double)m_staSuffix.Pop();
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 判断是否为数字
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <param name="p_str"></param>
        /// <returns></returns>
        public bool m_blnIsNumber(string p_str)
        {
            if (p_str.Length > 1)
            {
                return true;
            }
            else
            {
                return char.IsDigit(p_str[0]);
            }
        }
        #endregion

        #region 获取表达式左右两边的数字
        /// <summary>
        /// 获取表达式左右两边的数字
        /// </summary>
        /// <param name="p_dblLeft"></param>
        /// <param name="p_dblRight"></param>
        /// <returns></returns>
        private bool m_blnGet2Operands(out double p_dblLeft, out double p_dblRight)
        {
            try
            {
                p_dblRight = (double)m_staSuffix.Pop();
                p_dblLeft = (double)m_staSuffix.Pop();
            }
            catch
            {
                p_dblLeft = 0;
                p_dblRight = 0;
                return false;
            }
            return true;
        }
        #endregion

        #region 计算结果
        /// <summary>
        /// 计算结果
        /// </summary>
        /// <param name="p_str"></param>
        public void m_mthDoOperator(string p_str)
        {
            double m_dblLeft, m_dblRight;
            bool blnResult = m_blnGet2Operands(out m_dblLeft, out m_dblRight);
            if (blnResult)
            {
                switch (p_str)
                {
                    case "+":
                        m_staSuffix.Push(m_dblLeft + m_dblRight);
                        break;
                    case "-":
                        m_staSuffix.Push(m_dblLeft - m_dblRight);
                        break;
                    case "*":
                        m_staSuffix.Push(m_dblLeft * m_dblRight);
                        break;
                    case "/":
                        if (m_dblRight == 0.0)
                        {
                            m_staSuffix.Clear();
                            throw new Exception("除数不能为0");
                        }
                        else
                        {
                            m_staSuffix.Push(m_dblLeft / m_dblRight);

                        }
                        break;
                }
            }
            else
            {
                m_staSuffix.Clear();
            }
        }
        #endregion

        #region 酶标仪结果判断
        /// <summary>
        /// 酶标仪结果判断
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_strOD"></param>
        /// <param name="p_strCUTOFF"></param>
        /// <param name="p_strResult"></param>
        /// <returns></returns>
        public void m_blnResultJudge(string p_strCheckItemID,string p_strOD,string p_strCUTOFF, out string p_strResult)
        {
            p_strResult = null;
            long lngRes = 0;
            if (m_strCheckItemID != p_strCheckItemID)
            {
                m_objCheckItemCustomOrder = null;
                lngRes = new clsDomainController_MK3ItemSetManage().m_lngQueryCheckItemCustomRes(p_strCheckItemID, out m_objCheckItemCustomResArr);
            }
            if (m_objCheckItemCustomResArr != null)
            {
                if (m_objCheckItemCustomResArr.Length > 0)
                {
                    for (int i = 0; i < m_objCheckItemCustomResArr.Length; i++)
                    {
                        if (m_objCheckItemCustomResArr[i].m_strConditions.Contains("<"))
                        {
                            m_mthResult(m_objCheckItemCustomResArr[i], "<", p_strOD, p_strCUTOFF, out p_strResult);
                            if (p_strResult != null)
                                break;
                        }
                        if (m_objCheckItemCustomResArr[i].m_strConditions.Contains("<="))
                        {
                            m_mthResult(m_objCheckItemCustomResArr[i], "<=", p_strOD, p_strCUTOFF, out p_strResult);
                            if (p_strResult != null)
                                break;
                        }
                        if (m_objCheckItemCustomResArr[i].m_strConditions.Contains(">"))
                        {
                            m_mthResult(m_objCheckItemCustomResArr[i], ">", p_strOD, p_strCUTOFF, out p_strResult);
                            if (p_strResult != null)
                                break;
                        }
                        if (m_objCheckItemCustomResArr[i].m_strConditions.Contains(">="))
                        {
                            m_mthResult(m_objCheckItemCustomResArr[i], ">=", p_strOD, p_strCUTOFF, out p_strResult);
                            if (p_strResult != null)
                                break;
                        }
                    }
                }
            }
            m_strCheckItemID = p_strCheckItemID;
        }
        #endregion

        #region 阴阳性判断
        /// <summary>
        /// 阴阳性判断
        /// </summary>
        /// <param name="p_objCheckItemCustomRes"></param>
        /// <param name="p_strKey"></param>
        /// <param name="p_strOD"></param>
        /// <param name="p_strCUTOFF"></param>
        /// <param name="p_strResult"></param>
        public void m_mthResult(clsLisCheckItemCustomRes p_objCheckItemCustomRes, string p_strKey, string p_strOD, string p_strCUTOFF, out string p_strResult)
        {
            p_strResult = null;
            int idx;
            string m_strX = null;
            double dblOD = Convert.ToDouble(p_strOD);
            double dblCutoff = Convert.ToDouble(p_strCUTOFF);
            switch (p_strKey)
            {
                case "<":
                    idx = p_objCheckItemCustomRes.m_strConditions.IndexOf("<");
                    m_strX = p_objCheckItemCustomRes.m_strConditions.Substring(0, idx).Trim();
                    if (m_strX == "OD")
                    {
                        if (dblOD < dblCutoff)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    else
                    {
                        if (dblCutoff < dblOD)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    break;
                case "<=":
                    idx = p_objCheckItemCustomRes.m_strConditions.IndexOf("<=");
                    m_strX = p_objCheckItemCustomRes.m_strConditions.Substring(0, idx).Trim();
                    if (m_strX == "OD")
                    {
                        if (dblOD <= dblCutoff)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    else
                    {
                        if (dblCutoff <= dblOD)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    break;
                case">":
                    idx = p_objCheckItemCustomRes.m_strConditions.IndexOf(">");
                    m_strX = p_objCheckItemCustomRes.m_strConditions.Substring(0, idx).Trim();
                    if (m_strX == "OD")
                    {
                        if (dblOD > dblCutoff)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    else
                    {
                        if (dblCutoff > dblOD)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    break;
                case">=":
                    idx = p_objCheckItemCustomRes.m_strConditions.IndexOf(">=");
                    m_strX = p_objCheckItemCustomRes.m_strConditions.Substring(0, idx).Trim();
                    if (m_strX == "OD")
                    {
                        if (dblOD >= dblCutoff)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    else
                    {
                        if (dblCutoff >= dblOD)
                        {
                            p_strResult = p_objCheckItemCustomRes.m_strResult;
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 质控入库值计算
        /// <summary>
        /// 质控入库值计算
        /// </summary>
        /// <param name="p_strOD"></param>
        /// <param name="p_strCO"></param>
        /// <param name="p_strQCFormula"></param>
        /// <param name="p_strResult"></param>
        public void m_mthGetQcResult(string p_strOD, string p_strCO, string p_strQCFormula,out string p_strResult)
        {
            p_strResult = null;
            int idx;
            string m_strX = null;
            double dblOD = Convert.ToDouble(p_strOD);
            double dblCO = Convert.ToDouble(p_strCO);
            double dblResult;
            if (p_strQCFormula.Contains("/"))
            {
                idx = p_strQCFormula.IndexOf("/");
                m_strX = p_strQCFormula.Substring(0, idx).Trim();
                if (m_strX == "OD")
                {
                    dblResult = dblOD / dblCO;
                    p_strResult = dblResult.ToString("0.0000");
                }
                else if(m_strX=="CO")
                {
                    dblResult = dblCO / dblOD;
                    p_strResult = dblResult.ToString("0.0000");
                }
            }
            if (p_strQCFormula.Contains("*"))
            {
                dblResult = dblCO * dblOD;
                p_strResult = dblResult.ToString("0.0000");
            }
            if (p_strQCFormula.Contains("+"))
            {
                dblResult = dblCO + dblOD;
                p_strResult = dblResult.ToString("0.0000");
            }
            if (p_strQCFormula.Contains("-"))
            {
                idx = p_strQCFormula.IndexOf("-");
                m_strX = p_strQCFormula.Substring(0, idx).Trim();
                if (m_strX == "OD")
                {
                    dblResult = dblOD - dblCO;
                    p_strResult = dblResult.ToString("0.0000");
                }
                else if (m_strX == "CO")
                {
                    dblResult = dblCO - dblOD;
                    p_strResult = dblResult.ToString("0.0000");
                }
            }
            
        }
        #endregion

        #region 获取仪器项目名称
        /// <summary>
        /// 获取仪器项目名称
        /// </summary>
        public void m_mthGetDeviceCheckItem()
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngQueryDevceCheckItem(m_objViewer.m_strDeviceModelId, out m_dtDeviceModel);
        }
        #endregion

        #region 获取布局名称和布局信息
        /// <summary>
        /// 获取布局名称和布局信息
        /// </summary>
        public void m_mthGetAllItemLayoutInfo()
        {
            long lngRes = 0;
            lngRes = new clsDomainController_MK3ItemSetManage().m_lngGetAllItemLayout(out m_dtLayoutName, out m_dtLayoutInfo);
            if (lngRes > 0)
            {
                m_dtLayout = m_dtLayoutName.Copy();
                DataRow drTemp = m_dtLayout.NewRow();
                drTemp["layoutname_vchr"] = "";
                m_dtLayout.Rows.InsertAt(drTemp, 0);
                m_objViewer.m_cboLayout.DisplayMember = "layoutname_vchr";
                m_objViewer.m_cboLayout.ValueMember = "layoutname_vchr";
                m_objViewer.m_cboLayout.DataSource = m_dtLayout;
            }
        }
        #endregion

        #region 插入新的布局
        /// <summary>
        /// 插入新的布局
        /// </summary>
        /// <param name="p_objItemLayoutVOArr"></param>
        public void m_mthAddItemLayout(clslisItemLayout[] p_objItemLayoutVOArr)
        {
            long lngRes = 0;
            lngRes = new clsDomainController_MK3ItemSetManage().m_lngAddItemLayout(p_objItemLayoutVOArr);
            if (lngRes > 0)
            {
                MessageBox.Show(m_objViewer, "保存成功", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_mthGetAllItemLayoutInfo();
            }
        }
        #endregion

        #region 删除布局
        /// <summary>
        /// 删除布局
        /// </summary>
        public void m_mthDeleteItemLayout()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_cboLayout.Text))
                return;
            long lngRes = 0;
            lngRes = new clsDomainController_MK3ItemSetManage().m_lngDeleteItemLayout(m_objViewer.m_cboLayout.Text);
            if (lngRes > 0)
            {
                int j = -1;
                for (int i = 0; i < m_dtLayout.Rows.Count; i++)
                {
                    if (m_dtLayout.Rows[i]["layoutname_vchr"].ToString().Trim() == m_objViewer.m_cboLayout.Text)
                    {
                        j = i;
                        break;
                    }
                }
                if (j >= 0)
                {
                    m_dtLayout.Rows.RemoveAt(j);
                    m_objViewer.m_cboLayout.SelectedIndex = 0;
                }
                MessageBox.Show(m_objViewer, "删除成功", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 根据板子结果名称查询相关板子结果名称
        /// <summary>
        /// 根据板子结果名称查询相关板子结果名称
        /// </summary>
        public void m_mthQueryPlateName()
        {
            string m_strPlateName = m_objViewer.m_txtPlateName.Text;
            string m_strStartDate = m_objViewer.m_dtStartDate.Value.ToString("yyyy-MM-dd 00:00:00");
            string m_strEndDate = m_objViewer.m_dtEndDate.Value.ToString("yyyy-MM-dd 23:59:59");
            if (m_objViewer.intPlateResult == 1)
            {
                m_strPlateName = "";
            }
            long lngRes = 0;
            lngRes = m_objDomain.m_lngQueryPlateName(m_strPlateName,m_strStartDate,m_strEndDate, out dtPlateName);
            m_objViewer.intPlateResult = 0;
            if (lngRes > 0)
            {
                m_objViewer.m_dgPlateResult.DataSource = dtPlateName;
            }
        }
        #endregion

        #region 根据板子名称ID查询板子结果
        /// <summary>
        /// 根据板子名称ID查询板子结果
        /// </summary>
        /// <param name="p_dtResult"></param>
        public long  m_mlngQueryPlateResult(out DataTable p_dtResult)
        {
            p_dtResult = null;
            if (m_objViewer.m_dgPlateResult.SelectedRows.Count <= 0)
            {
                return -1;
            }
            string m_strPlateNameID = m_objViewer.m_dgPlateResult.SelectedRows[0].Cells["m_chPlateNameID"].Value.ToString();
            long lngRes = 0;
            lngRes = m_objDomain.m_lngQueryPlateResult(m_strPlateNameID, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 插入板子布局结果
        /// <summary>
        /// 插入板子布局结果
        /// </summary>
        /// <param name="p_strPlateName"></param>
        /// <param name="p_objPlateResultArr"></param>
        public void m_mthInsertPlateResult()
        {
            if (m_objViewer.m_lstTextBos.Count <= 0)
            {
                return;
            }
            string m_strPlateName = null;
            string m_strPlateChName = null; //增加测试项目
            string m_strCheckItemID = null;
            string m_strCheckName = null;
            int intSampleStartNO = 0;
            int intSampleEndNO = 0;
            int intTemp = 0;
            string m_strSampleStartNO = null;
            string m_strSampleEndNO = null;
            List<clslisPlateResult> m_lstPlateResultArr = new List<clslisPlateResult>();
            clslisPlateResult objTemp = null;
            int intStatus = 0;
            for (int i = 0; i <m_objViewer.m_lstTextBos.Count; i++)
            {
                if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "none")
                {
                    objTemp = new clslisPlateResult();
                    objTemp.m_strCheck_Item_Id = m_objViewer.m_lstTextBos[i].m_strItmeID;
                    objTemp.m_strCheckitemname_vchr = m_objViewer.m_lstTextBos[i].m_strCheckItemName;
                    objTemp.m_strControlidx_chr = i.ToString();
                    objTemp.m_strSample_Result_2_vchr = m_objViewer.m_lstLbl[i].Text;
                    objTemp.m_strSample_Result_vchr = m_objViewer.m_lstTextBos[i].Text;
                    objTemp.m_strSampleid_vchr = m_objViewer.m_lstTextBos[i].m_strSampleID;
                    objTemp.m_strSampletype_chr = m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString();

                    objTemp.m_strSameple_Result_sc_vchr = m_objViewer.m_lstTextBos[i].Tag.ToString(); //增加s/co值
                    objTemp.m_strSameple_Result_strCutoff_vchr = m_objViewer.m_strCutoff; //增加Cutoff值
                    objTemp.m_strSameple_Result_ContrastNC_vchr = m_objViewer.m_strContrastNC; //增加阴性对照值
                    objTemp.m_strSameple_Result_ContrastPC_vchr = m_objViewer.m_strContrastPC; //增加阳性对照值

                    m_lstPlateResultArr.Add(objTemp);

                    if (m_strCheckItemID != m_objViewer.m_lstTextBos[i].m_strItmeID)
                    {
                        switch (m_objViewer.m_lstTextBos[i].m_strCheckItemName.ToLower())
                        {
                            case "hbsag":
                                m_strCheckName = "1";
                                break;
                            case "hbsab":
                                m_strCheckName = "2";
                                break;
                            case "hbeag":
                                m_strCheckName = "3";
                                break;
                            case "hbeab":
                                m_strCheckName = "4";
                                break;
                            case "hbcab":
                                m_strCheckName = "5";
                                break;
                            default:
                                m_strCheckName = m_objViewer.m_lstTextBos[i].m_strCheckItemName;
                                break;
                        }
                        m_strPlateName = m_strPlateName + "+" + m_strCheckName;
                        m_strPlateChName = m_strPlateChName + m_objViewer.m_lstTextBos[i].m_strCheckItemName + "+"; //增加测试项目显示
                    }
                    
                    if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "smp")
                    {
                        if (m_strCheckItemID == m_objViewer.m_lstTextBos[i].m_strItmeID)
                        {
                            try
                            {
                               
                                intTemp = Convert.ToInt32(m_objViewer.m_lstTextBos[i].m_strSampleID);
                                if (intTemp < intSampleStartNO)
                                {
                                    intSampleStartNO = intTemp;
                                }
                                if (intTemp > intSampleEndNO)
                                {
                                    intSampleEndNO = intTemp;
                                }
                                if (intStatus == 0)
                                {
                                    intSampleStartNO = intTemp;
                                }
                                intStatus = 1;
                            }
                            catch
                            { }
                        }
                        if (i == 0)
                        {
                            
                            m_strSampleStartNO = m_objViewer.m_lstTextBos[i].m_strSampleID;
                            m_strSampleEndNO = m_objViewer.m_lstTextBos[i].m_strSampleID;
                            try
                            {
                                intSampleStartNO = Convert.ToInt32(m_objViewer.m_lstTextBos[i].m_strSampleID);
                                intSampleEndNO = Convert.ToInt32(m_objViewer.m_lstTextBos[i].m_strSampleID);
                            }
                            catch
                            {
                                intSampleStartNO = 0;
                                intSampleEndNO = 0;
                            }
                            intStatus = 1;
                        }
                    }
                    m_strCheckItemID = m_objViewer.m_lstTextBos[i].m_strItmeID;
                }
            }
            if (m_lstPlateResultArr.Count > 0&&!string.IsNullOrEmpty(m_strPlateName))
            {
                m_strSampleEndNO = intSampleEndNO.ToString();
                m_strSampleStartNO = intSampleStartNO.ToString();
                m_strPlateName = m_strPlateName.TrimStart('+');
                m_strPlateName = m_strPlateName.TrimEnd('+');
                m_strPlateChName = m_strPlateChName.TrimEnd('+');  //增加测试项目
                m_strPlateName = DateTime.Now.Date.ToString("yyyyMMdd") + "(" + m_strPlateName + ")" + "+" + "(" + m_strSampleStartNO + "-" + m_strSampleEndNO + ")";
                m_objViewer.intPlateResult = 1;
                long lngRes = 0;
                string m_strPlateResultID = null;
                DataView dvTemp = m_dtAllPlateName.DefaultView;
                dvTemp.RowFilter = "plate_name_vchr='" + m_strPlateName + "'";
                if (dvTemp != null && dvTemp.Count > 0)
                {
                    if (MessageBox.Show("该板已保存，是否继续", "MK3酶标仪提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
                    {
                        return;
                    }
                }
                lngRes = m_objDomain.m_lngInsertPlateResult(m_strPlateName,m_strPlateChName, m_lstPlateResultArr.ToArray(), out m_strPlateResultID);
                if (lngRes > 0)
                {
                    if (dtPlateName == null)
                    {
                        dtPlateName = new DataTable();
                        dtPlateName.Columns.Add("plate_name_id_chr", typeof(string));
                        dtPlateName.Columns.Add("plate_name_vchr", typeof(string));
                        dtPlateName.Columns.Add("plate_date", typeof(string));
                        dtPlateName.Columns.Add("plate_chaname_vchr", typeof(string));

                        m_objViewer.m_dgPlateResult.Invoke(new MethodInvoker(delegate() { m_objViewer.m_dgPlateResult.DataSource = dtPlateName; }));

                     
                    }
                    DataRow drTemp = dtPlateName.NewRow();
                    drTemp["plate_name_id_chr"] = m_strPlateResultID;
                    drTemp["plate_name_vchr"] = m_strPlateName;
                    drTemp["plate_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    drTemp["plate_chaname_vchr"] = m_strPlateChName;
                    dtPlateName.Rows.Add(drTemp);
                    DataRow drTemp1 = m_dtAllPlateName.NewRow();
                    drTemp1["plate_name_id_chr"] = m_strPlateResultID;
                    drTemp1["plate_name_vchr"] = m_strPlateName;
                    drTemp1["plate_date"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    drTemp1["plate_chaname_vchr"] = m_strPlateChName;
                    m_dtAllPlateName.Rows.Add(drTemp1);
                    m_dtAllPlateName.AcceptChanges();
                    dtPlateName.AcceptChanges();


                    m_objViewer.m_strPlanChaName = m_strPlateChName;
                       
                }
            }
        }
        #endregion

        #region 删除板子结果
        /// <summary>
        /// 删除板子结果
        /// </summary>
        public void m_mthDeletePlateResult()
        {
            if (m_objViewer.m_dgPlateResult.SelectedRows.Count <= 0)
            {
                return;
            }
            string m_strPlateNameID = m_objViewer.m_dgPlateResult.SelectedRows[0].Cells["m_chPlateNameID"].Value.ToString();
            long lngRes = 0;
            lngRes = m_objDomain.m_lngDeletePlateResult(m_strPlateNameID);
            if (lngRes > 0)
            {
                int idx = m_objViewer.m_dgPlateResult.SelectedRows[0].Index;
                m_objViewer.m_dgPlateResult.Rows.RemoveAt(idx);
            }
        }
        #endregion

        #region  重新入库
        /// <summary>
        /// 重新入库
        /// </summary>
        public void m_mthInputStock()
        {
            List<clsLIS_Device_Test_ResultVO> p_lstResult = new List<clsLIS_Device_Test_ResultVO>();
            clsLIS_Device_Test_ResultVO objResult = null;
            string strDeviceID = m_objViewer.m_strDeviceId;
            for (int i = 0; i < m_objViewer.m_lstTextBos.Count; i++)
            {
                if (m_objViewer.m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "none")
                {
                    objResult = new clsLIS_Device_Test_ResultVO();
                    objResult.strDevice_ID = strDeviceID;
                    objResult.strDevice_Sample_ID = m_objViewer.m_lstTextBos[i].m_strSampleID;
                    objResult.strCheck_Date = DateTime.Now.ToString();
                    if (m_objViewer.m_lstLbl[i].Text.Contains("+"))
                    {
                        objResult.strResult = "阳性(+)";
                    }
                    else if (m_objViewer.m_lstLbl[i].Text.Contains("-"))
                    {
                        objResult.strResult = "阴性(-)";
                    }
                    else
                    {
                        objResult.strResult = m_objViewer.m_lstLbl[i].Text;
                    }
                    objResult.strDevice_Check_Item_Name = m_objViewer.m_lstTextBos[i].m_strCheckItemName;
                    p_lstResult.Add(objResult);
                }
            }
            if (p_lstResult.Count>0)
            {
                clsLIS_Device_Test_ResultVO[] objOutResult = null;
                long lngRes = 0;
                lngRes = new clsDomainController_MK3ItemSetManage().lngAddLabResult(p_lstResult.ToArray(), true, out objOutResult);
                if (lngRes > 0)
                {
                    MessageBox.Show("入库成功", "酶标仪操作提示");
                }
            }
        }
        #endregion

        #region 获取所有板子结果
        /// <summary>
        /// 获取所有板子结果
        /// </summary>
        public void m_mthGetAllPlateResult()
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngGetAllPlateResult(out m_dtAllPlateName);
            if (m_dtAllPlateName == null)
            {
                m_dtAllPlateName = new DataTable();
                m_dtAllPlateName.Columns.Add("plate_name_id_chr", typeof(string));
                m_dtAllPlateName.Columns.Add("plate_name_vchr", typeof(string));
                m_dtAllPlateName.Columns.Add("plate_date", typeof(string));
                m_dtAllPlateName.Columns.Add("plate_chaname_vchr", typeof(string));
            }
        }
        #endregion


        #region 获取自定义项目的结果判断公式  
        /// <summary>
        /// 获取自定义项目的结果判断
        /// </summary>
        public long m_mthGetCheckItemCustomRes(out DataTable p_dtResult)
        {
            string m_strCheckItemID = m_objViewer.m_cboItem.SelectedValue.ToString();
            long lngRes = 0;
            p_dtResult = null;

            lngRes = m_objDomain.m_lngQueryCheckItemCustomRes(m_strCheckItemID, out p_dtResult);
            return lngRes;
        }
        #endregion
    }
}
