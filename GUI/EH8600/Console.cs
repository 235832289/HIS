using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;

namespace EH8600
{
    /// <summary>
    /// EH8600
    /// </summary>
    public partial class Console : Form
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public Console()
        {
            InitializeComponent();
        }
        #endregion

        #region 属性.变量

        /// <summary>
        /// 与本计算机相关的仪器的设定信息
        /// </summary>
        clsLIS_Equip_ConfigVO[] EquipConfig;

        /// <summary>
        /// 通道号配置数据
        /// </summary>
        Dictionary<string, string> ChannelConfig { get; set; }

        /// <summary>
        /// 接收到的数据
        /// </summary>
        StringBuilder ReceiveData { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        string DeviceID { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            // 通道号配置信息
            DataSet ds = new DataSet();
            ChannelConfig = new Dictionary<string, string>();
            ds.ReadXml(Application.StartupPath + "\\eh8600.xml");
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        ChannelConfig.Add(dt.Columns[i].ColumnName, dt.Rows[0][dt.Columns[i].ColumnName].ToString());
                    }
                }
            }

            if (this.ChannelConfig.ContainsKey("IP"))
            {
                this.txtIpAddr.Text = this.ChannelConfig["IP"];
            }

            if (this.ChannelConfig.ContainsKey("PORT"))
            {
                this.txtPortNo.Text = this.ChannelConfig["PORT"];
            }

            // 接收数据
            ReceiveData = new StringBuilder();
        }
        #endregion

        #region Socket服务监听
        /// <summary>
        /// 是否启动监听
        /// </summary>
        bool isListenStart { get; set; }
        /// <summary>
        /// 负责侦听的套接字
        /// </summary>
        TcpListener listener;
        /// <summary>
        /// 初始化SocketListen
        /// </summary>
        void InitSocketListen()
        {
            string hostName = System.Net.Dns.GetHostName();

            //using (clsLIS_Svc2 svc = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2)))
            using (clsQueryLIS_Svc svc = (clsQueryLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryLIS_Svc)))
            //using(clsQueryLIS_Svc svc = (clsQueryLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc)))
            {
                long ret = svc.lngGetInstrumentSerialSetting(hostName, out EquipConfig);
                if (ret == 1)
                {
                    if (EquipConfig != null && EquipConfig.Length > 0)
                    {
                        this.lblEquipName.Text = EquipConfig[0].strLIS_Instrument_Name;
                        this.DeviceID = EquipConfig[0].strLIS_Instrument_ID;
                    }
                }
            }

            string ipAddr = this.txtIpAddr.Text.Trim();
            string portNo = this.txtPortNo.Text.Trim();

            if (ipAddr == string.Empty)
            {
                MessageBox.Show("请输入IP地址", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (portNo == string.Empty)
            {
                MessageBox.Show("请输入端口号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //服务器启动侦听
            try
            {
                IPEndPoint localep = new IPEndPoint(IPAddress.Parse(ipAddr), Convert.ToInt32(portNo));
                listener = new TcpListener(localep);
                listener.Start(10);
            }
            catch (Exception ex)
            {
                this.SetSocketInfo("OM设备监听端口错误，请修改后重试！\r\n\r\n" + ex.Message);
                return;
            }
            listener.BeginAcceptSocket(new AsyncCallback(AcceptCallback), listener);
            isListenStart = true;

            // 监听服务运行中...
            this.SetSocketInfo("监听服务运行中...                         " + "地址: " + ipAddr + "  端口: " + portNo);
        }

        void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                //完成异步接受连接请求的异步调用
                //将连接信息添加到列表和下拉列表框中
                Socket handle = listener.EndAcceptSocket(ar);
                SocketTool frd = new SocketTool(handle);
                //继续调用异步方法接收连接请求
                if (isListenStart)
                {
                    listener.BeginAcceptSocket(new AsyncCallback(AcceptCallback), listener);
                }
                //开始在连接上进行异步的数据接收
                frd.ClearBuffer();
                frd.socket.BeginReceive(frd.Rcvbuffer, 0, frd.Rcvbuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), frd);
            }
            catch (Exception ex)
            {
                //在调用EndAcceptSocket方法时可能引发异常
                //——套接字Listener被关闭，则设置为未启动侦听状态
                isListenStart = false;
                this.SetSocketInfo(ex.Message);
            }
        }

        void ReceiveCallback(IAsyncResult ar)
        {
            SocketTool frd = (SocketTool)ar.AsyncState;
            try
            {
                int i = frd.socket.EndReceive(ar);
                if (i == 0)
                {
                    return;
                }
                else
                {
                    string data = System.Text.Encoding.UTF8.GetString(frd.Rcvbuffer, 0, i);
                    try
                    {
                        Log.Output(data);
                        LisDataAnalysis(data);
                    }
                    catch { }
                    frd.ClearBuffer();
                    frd.socket.BeginReceive(frd.Rcvbuffer, 0, frd.Rcvbuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), frd);
                }
            }
            catch (Exception ex)
            {
                this.SetSocketInfo(ex.Message);
                Log.Output(ex.Message);
            }
        }

        void SetSocketInfo(string val)
        {
            this.lblStatus.Text = val;
        }
        #endregion

        #region 仪器结果分析

        string chrStart = "";
        string chrEnd = "";
        void LisDataAnalysis(string _data)
        {
            this.ReceiveData.Append(_data);
            string data = this.ReceiveData.ToString();

            int idxStart = data.IndexOf(chrStart);
            int idxEnd = data.IndexOf(chrEnd);
            if (idxStart < 0 || idxEnd < 0) return;
            if (idxEnd - idxStart - 100 < 0)
            {
                this.ReceiveData.Remove(0, idxEnd + 1);
                return;
            }

            List<string> lstData = new List<string>();
            do
            {
                if (idxEnd - idxStart - 100 > 0)
                {
                    string tmpData = data.Substring(idxStart + 1, idxEnd - idxStart - 1);
                    if (lstData.IndexOf(tmpData) < 0) lstData.Add(tmpData);
                }
                this.ReceiveData.Remove(0, idxEnd + 1);

                data = data.Substring(idxEnd + 1);
                idxStart = data.IndexOf(chrStart);
                idxEnd = data.IndexOf(chrEnd);
            } while (idxStart > 0 && idxEnd > 0);
            this.ReceiveData.Remove(0, idxEnd + 1);

            if (lstData.Count > 0)
            {
                foreach (string sampleData in lstData)
                {
                    string[] dataArr = sampleData.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (dataArr == null || dataArr.Length <= 0) return;

                    string sampleID = string.Empty;
                    string checkDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    List<clsLIS_Device_Test_ResultVO> lstResultData = new List<clsLIS_Device_Test_ResultVO>();
                    clsLIS_Device_Test_ResultVO vo = null;

                    foreach (string lineData in dataArr)
                    {
                        string[] fieldsArr = null;
                        string[] fieldNameArr = null;
                        // 数据格式: OBX|22|NM|789-8^RBC^LN||4.80|10*12/L|3.80-5.80|~N|||F
                        if (lineData.StartsWith("OBX"))
                        {
                            fieldsArr = lineData.Split('|');
                            if (fieldsArr.Length > 5)
                            {
                                fieldNameArr = fieldsArr[3].Split('^');
                                if (fieldNameArr.Length >= 3)
                                {
                                    vo = new clsLIS_Device_Test_ResultVO();
                                    vo.strDevice_Sample_ID = sampleID;
                                    vo.strCheck_Date = checkDate;
                                    vo.strDevice_Check_Item_Name = fieldNameArr[0]; // +fieldNameArr[2];            // 789;  789-8LN         
                                    vo.strResult = fieldsArr[5];                                                    // 4.80
                                    if (this.ChannelConfig.ContainsKey("F" + vo.strDevice_Check_Item_Name))
                                    {
                                        vo.strDevice_Check_Item_Name = this.ChannelConfig["F" + vo.strDevice_Check_Item_Name];
                                        lstResultData.Add(vo);
                                    }
                                }
                            }
                        }
                        else if (lineData.StartsWith("OBR"))
                        {
                            fieldsArr = lineData.Split('|');
                            if (fieldsArr.Length > 5)
                            {
                                sampleID = fieldsArr[3];
                            }
                        }
                    }
                    if (lstResultData.Count > 0 && sampleID != string.Empty && !string.IsNullOrEmpty(this.DeviceID))
                    {
                        #region 写入数据
                        try
                        {
                            using (clsLIS_Svc svc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc)))
                            {
                                clsLIS_Device_Test_ResultVO[] resultArr = null;
                                foreach (clsLIS_Device_Test_ResultVO item in lstResultData)
                                {
                                    item.strDevice_ID = this.DeviceID;
                                    item.strDevice_Sample_ID = sampleID;
                                }
                                svc.lngAddLabResult(lstResultData.ToArray(), out resultArr);
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Output(ex.Message);
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion

        #endregion

        #region 事件

        private void Console_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Console_SizeChanged(object sender, EventArgs e)
        {
            //判断是否选择的是最小化按钮 
            if (this.WindowState == FormWindowState.Minimized)
            {
                // 隐藏任务栏区图标 
                // this.ShowInTaskbar = false;
                this.Visible = false;
                // 图标显示在托盘区 
                this.notifyIcon.Visible = true;
            }
        }

        private void Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.None)
            {
                e.Cancel = true;
            }
            else
            {
                if (MessageBox.Show("确定退出EH8600 控制台？？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否已经最小化于托盘 
            if (WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                //还原窗体显示 
                WindowState = FormWindowState.Normal;
                //激活窗体并给予它焦点 
                this.Activate();
                //任务栏区显示图标 
                //this.ShowInTaskbar = true;
                //托盘区图标隐藏 
                this.notifyIcon.Visible = false;
            }
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            InitSocketListen();
        }

        #endregion

    }

    #region SocketTool
    /// <summary>
    /// SocketTool
    /// </summary>
    class SocketTool
    {
        public Socket socket;
        public byte[] Rcvbuffer;
        public SocketTool(Socket s)
        {
            socket = s;
        }
        public void ClearBuffer()
        {
            Rcvbuffer = new byte[1024];
        }
        public void Dispose()
        {
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            finally
            {
                socket = null;
                Rcvbuffer = null;
            }
        }
    }
    #endregion

    #region Log
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
        public static void Output(string txt)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            string strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + ".txt";
            bool blnAllWaysNew = false;
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(strFile);
                if (fi.Exists)
                {
                    if (fi.Length >= 2000000)
                    {
                        fi.CopyTo(System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + "-" + DateTime.Now.ToString("HHmm") + ".txt", true);
                        sw = fi.CreateText();
                    }
                    else
                    {
                        if (blnAllWaysNew)
                        {
                            sw = fi.CreateText();
                        }
                        else
                        {
                            sw = fi.AppendText();
                        }
                    }
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
                sw.WriteLine("-->>>>> " + strTime);
                sw.WriteLine(txt);
                sw.WriteLine();
            }
            catch (Exception e)
            {
                //throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
    #endregion
}
