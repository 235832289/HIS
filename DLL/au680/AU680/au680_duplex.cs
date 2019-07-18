using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AU680
{
    /// <summary>
    /// 检验结果保存成功后
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void LISResultSavedEvent(object sender, System.EventArgs e);

    public class AU680_Duplex
    {
        #region 变量
        /// <summary>
        /// 串口控制类
        /// </summary>
        public clsSerialPortIO SerialPort = null;
        /// <summary>
        /// 仪器代号
        /// </summary>
        string DeviceNO = null;
        /// <summary>
        /// 仪器ID
        /// </summary>
        string DeviceID = null;
        /// <summary>
        /// 最近一次收到的数据
        /// </summary>
        string LastReceive = null;
        /// <summary>
        /// 接收数据缓冲区
        /// </summary>
        StringBuilder ReceiveBuf = null;
        /// <summary>
        /// 
        /// </summary>
        AU680_ControlCode ControlCode = null;
        /// <summary>
        /// 数据分析类
        /// </summary>
        DataAnalysis_AU680 DateAnalysis = null;

        /// <summary>
        /// 检验结果保存成功后事件
        /// </summary>
        public event LISResultSavedEvent ShowResult;
        /// <summary>
        /// 日志处理
        /// </summary>
        com.digitalwave.Utility.clsLogText Logger = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_objConfig"></param>
        public AU680_Duplex()
        {
            ReceiveBuf = new StringBuilder(1024);
            ControlCode = new AU680_ControlCode();
            DateAnalysis = new DataAnalysis_AU680();
            Logger = new com.digitalwave.Utility.clsLogText();

            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(System.Windows.Forms.Application.StartupPath + "\\au680.xml");
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                DateAnalysis.dtConfig = ds.Tables[0];
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_objConfig"></param>
        public AU680_Duplex(clsLIS_Equip_ConfigVO p_objConfig)
            : this()
        {
            SerialPort = new clsSerialPortIO(p_objConfig);
            DeviceNO = p_objConfig.strLIS_Instrument_NO;
        }
        #endregion

        #region SetConfigVO
        /// <summary>
        /// 设置串口参数
        /// </summary>
        /// <param name="p_objConfig"></param>
        public void SetConfigVO(clsLIS_Equip_ConfigVO p_objConfig)
        {
            if (p_objConfig != null)
            {
                if (SerialPort != null && SerialPort.IsOpen)
                {
                    SerialPort.Close();
                }
                SerialPort = new clsSerialPortIO(p_objConfig);
                DeviceNO = p_objConfig.strLIS_Instrument_NO;
                DeviceID = p_objConfig.strLIS_Instrument_ID;
            }
        }
        #endregion

        #region 开始工作
        /// <summary>
        /// 打开串口，开始工作
        /// </summary>
        public long Start()
        {
            long lngRes = 0;
            SerialPort.Open();
            if (SerialPort.IsOpen)
            {
                lngRes = 1;
                SerialPort.DataComing += new DataComingEvent(SerialPort_DataComing);
            }
            return lngRes;
        }
        #endregion

        #region 关闭串口
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            SerialPort.DataComing -= new DataComingEvent(SerialPort_DataComing);
            SerialPort.Close();
        }
        #endregion

        #region 接收数据
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SerialPort_DataComing(object sender, EventArgs e)
        {
            LastReceive = SerialPort.Read();
            ReceiveBuf.Append(LastReceive);

            Logger.Log2File(@"D:\code\logData.txt", LastReceive);

            string strTemp = ReceiveBuf.ToString();
            if (strTemp.Length < 0) return;
            int idxStart = strTemp.IndexOf(AU680_ControlCode.StartCode);
            int idxEnd = strTemp.IndexOf(AU680_ControlCode.EndCode);
            if (idxStart < 0 || idxEnd < 0) return;
            if (idxEnd - idxStart - 6 < 0)
            {
                ReceiveBuf.Remove(0, idxEnd + 1);
                return;
            }
            List<string> lstResultData = new List<string>();
            do
            {
                if (idxEnd - idxStart - 6 > 0)
                {
                    string data = strTemp.Substring(idxStart + 3, idxEnd - idxStart - 3);
                    //string data = strTemp.Substring(idxStart + 7, idxEnd - idxStart - 9);
                    if (lstResultData.IndexOf(data) < 0) lstResultData.Add(data);
                }
                ReceiveBuf.Remove(0, idxEnd + 1);
                strTemp = strTemp.Substring(idxEnd + 1);
                idxStart = strTemp.IndexOf(AU680_ControlCode.StartCode);
                idxEnd = strTemp.IndexOf(AU680_ControlCode.EndCode);
            } while (idxStart > 0 && idxEnd > 0);
            ReceiveBuf.Remove(0, idxEnd + 1);

            if (lstResultData != null && lstResultData.Count > 0)
            {
                AddResult(lstResultData);
            }
        }
        #endregion

        #region AddResult
        /// <summary>
        /// AddResult
        /// </summary>
        /// <param name="p_lstResultData"></param>
        void AddResult(List<string> p_lstResultData)
        {
            long lngRes = 0;
            List<clsLIS_Device_Test_ResultVO> resultVo = null;
            try
            {
                List<string> lstChar = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                clsLIS_Svc objServ = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc));
                foreach (string data in p_lstResultData)
                {
                    lngRes = DateAnalysis.lngDataAnalysis(data, out resultVo);
                    if (lngRes > 0 && resultVo != null && resultVo.Count > 0)
                    {
                        foreach (clsLIS_Device_Test_ResultVO vo in resultVo)
                        {
                            vo.strDevice_ID = SerialPort.Name;
                            if (vo.strResult != string.Empty)
                            {
                                bool isOk = false;
                                int len = vo.strResult.Length;
                                for (int k = len - 1; k >= 0; k--)
                                {
                                    if (lstChar.IndexOf(vo.strResult.Substring(k, 1)) >= 0)
                                    {
                                        vo.strResult = vo.strResult.Substring(0, k + 1);
                                        isOk = true;
                                        break;
                                    }
                                }
                                if (isOk == false) vo.strResult = "";
                            }
                        }
                        clsLIS_Device_Test_ResultVO[] reultArr = null;
                        lngRes = objServ.lngAddLabResult(resultVo.ToArray(), out reultArr);
                        if (lngRes > 0)
                        {
                            if (ShowResult != null)
                            {
                                ShowResult(reultArr, null);
                            }
                        }
                    }
                }
            }
            catch (Exception objEx)
            {
                Logger.LogDetailError(objEx, false);
            }
        }
        #endregion

    }
}
