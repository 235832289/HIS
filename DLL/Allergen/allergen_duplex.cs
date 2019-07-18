using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Data;
using System.Xml;

namespace Allergen
{
    /// <summary>
    /// 检验结果保存成功后
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void LISResultSavedEvent(object sender, System.EventArgs e);

    public class Allergen_Duplex
    {
        #region 变量
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
        Allergen_ControlCode ControlCode = null;
        /// <summary>
        /// 数据分析类
        /// </summary>
        DataAnalysis_Allergen DateAnalysis = null;

        /// <summary>
        /// 检验结果保存成功后事件
        /// </summary>
        public event LISResultSavedEvent ShowResult;
        /// <summary>
        /// 日志处理
        /// </summary>
        com.digitalwave.Utility.clsLogText Logger = null;

        clsLIS_Equip_ConfigVO configVo = null;

        DataTable dtConfig { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        string FilePath { get; set; }

        System.Windows.Forms.Timer timer;



        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_objConfig"></param>
        public Allergen_Duplex()
        {
            ReceiveBuf = new StringBuilder(1024);
            ControlCode = new Allergen_ControlCode();
            DateAnalysis = new DataAnalysis_Allergen();
            Logger = new com.digitalwave.Utility.clsLogText();

            System.Data.DataSet ds = new System.Data.DataSet();
            ds.ReadXml(System.Windows.Forms.Application.StartupPath + "\\allergen.xml");
            if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
            {
                FilePath = ds.Tables[0].Rows[0][0].ToString();
                if (ds.Tables.Count > 0)
                    this.dtConfig = ds.Tables[1];
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_objConfig"></param>
        public Allergen_Duplex(clsLIS_Equip_ConfigVO p_objConfig)
            : this()
        {
            configVo = p_objConfig;
            DeviceNO = p_objConfig.strLIS_Instrument_NO;
            DeviceID = p_objConfig.strLIS_Instrument_ID;
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
                configVo = p_objConfig;
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
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Enabled = true;
            this.timer.Interval = 1000 * 20;    // 60秒刷新一次
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            return 1;
        }
        #endregion

        #region 关闭串口
        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            this.timer.Enabled = false;
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
        }
        #endregion

        #region 接收数据
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void axMSComm_OnComm(object sender, EventArgs e)
        {
        }
        #endregion

        #region AddResult
        /// <summary>
        /// AddResult
        /// </summary>
        /// <param name="p_lstResultData"></param>
        void AddResult(List<string> p_lstResultData)
        {
        }
        #endregion

        #region DoResult
        /// <summary>
        /// DoResult
        /// </summary>
        /// <returns></returns>
        void DoResult()
        {
            try
            {
                #region getResult

                int count = 50;     // 暂定50行数据, 目前最大是30行。
                string tableName = string.Empty;
                string itemCode = string.Empty;
                string itemValue = string.Empty;
                string checkDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string checkStr = string.Empty;
                List<clsLIS_Device_Test_ResultVO> data = new List<clsLIS_Device_Test_ResultVO>();
                clsLIS_Device_Test_ResultVO vo = null;
                List<string> lstSampleId = new List<string>();
                List<string> lstFileName = new List<string>();
                List<string> lstCheckStr = new List<string>();

                DirectoryInfo dir = new DirectoryInfo(this.FilePath);
                FileInfo[] files = dir.GetFiles();
                clsLIS_Svc2 lisSvc2 = (clsLIS_Svc2)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc2));
                foreach (FileInfo file in files)
                {

                    if (file.FullName.Contains(".md5"))
                    {
                        continue;
                    }
                    // 判断文件是否已读取
                    if (lisSvc2.AllergenIsRead(file.FullName))
                    {
                        continue;
                    }
                   
                    XmlDocument document = new XmlDocument();
                    document.Load(file.FullName);
                    XmlNodeList nodeList = document.SelectNodes(@"Analysis/Container");
                    foreach (XmlNode node in nodeList)
                    {
                        string xmlNode = node.OuterXml;
                        DataSet ds = ReadXml(xmlNode);
                        for (int i = 0; i < count; i++)
                        {
                            vo = new clsLIS_Device_Test_ResultVO();
                            vo.strDevice_Sample_ID = node["Strip"]["Sample"]["Sample_ID"].InnerText.ToString();
                            vo.strCheck_Date = checkDate;

                            #region
                            tableName = "Row" + i.ToString();
                            if (ds.Tables.Contains(tableName) && ds.Tables[tableName].Rows.Count > 0)
                            {
                                itemCode = ds.Tables[tableName].Rows[0]["Allergenshortcut"].ToString();
                                if (this.dtConfig != null && this.dtConfig.Rows.Count > 0)
                                {
                                    for (int i2 = 0; i2 < this.dtConfig.Columns.Count; i2++)
                                    {
                                        if (this.dtConfig.Columns[i2].ColumnName == itemCode)
                                        {
                                            vo.strDevice_Check_Item_Name = this.dtConfig.Rows[0][itemCode].ToString().Trim();
                                            break;
                                        }
                                    }
                                    if (string.IsNullOrEmpty(vo.strDevice_Check_Item_Name))
                                        vo.strDevice_Check_Item_Name = itemCode;
                                }
                                else
                                {
                                    vo.strDevice_Check_Item_Name = itemCode;
                                }
                                vo.strResult = ds.Tables[tableName].Rows[0]["IU_ml"].ToString();
                                vo.strDevice_ID = DeviceID;

                                checkStr = vo.strDevice_Sample_ID + vo.strDevice_Check_Item_Name;
                                //checkStr = vo.strDevice_Check_Item_Name;
                                if (lstCheckStr.IndexOf(checkStr) < 0)
                                {
                                    if (lstSampleId.IndexOf(vo.strDevice_Sample_ID) < 0)
                                    {
                                        lstSampleId.Add(vo.strDevice_Sample_ID);
                                    }
                                    // 时间: 文件创建时间
                                    vo.strCheck_Date = (file.CreationTime < DateTime.Now) ? file.CreationTime.ToString("yyyy-MM-dd HH:mm:ss") : checkDate;
                                    data.Add(vo);
                                    lstCheckStr.Add(checkStr);
                                    if (lstFileName.IndexOf(file.FullName) < 0)
                                        lstFileName.Add(file.FullName);
                                }
                            }
                            #endregion
                        }
                    }
                }
                #endregion

                #region addResult

                if (data != null && data.Count > 0)
                {
                    long res = 0;
                    clsLIS_Svc lisSvc = (clsLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLIS_Svc));
                    clsLIS_Device_Test_ResultVO[] reultArr = null;
                    List<clsLIS_Device_Test_ResultVO> data2 = null;
                    foreach (string sampleId in lstSampleId)
                    {
                        data2 = data.FindAll(t => t.strDevice_Sample_ID == sampleId);
                        if (data2 != null && data2.Count > 0)
                        {
                            res = lisSvc.lngAddLabResult(data2.ToArray(), out reultArr);
                            if (res > 0)
                            {
                                if (ShowResult != null)
                                {
                                    System.Windows.Forms.Application.DoEvents();
                                    ShowResult(reultArr, null);
                                    System.Windows.Forms.Application.DoEvents();
                                }
                            }
                        }
                    }
                    // 写读取记录
                    if (lstFileName.Count > 0)
                    {
                        lisSvc.SaveAllergenRec(lstFileName);
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                Log.Output(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// 返回dataSet
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static DataSet ReadXml(string xml)
        {
            try
            {
                List<string> lstEncoding = new List<string>() { "encoding=\"gb2312\"", "encoding='gb2312'", "encoding=\"GBK\"", "encoding='GBK'" };
                foreach (string enc in lstEncoding)
                {
                    if (xml.IndexOf(enc) >= 0)
                    {
                        xml = xml.Replace(enc, "encoding=\"utf-8\"");
                    }
                }
                XmlReader reader = XmlReader.Create(new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xml)));
                DataSet ds = new DataSet();
                ds.ReadXml(reader);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        #region timer_Tick

        /// <summary>
        /// isDoing
        /// </summary>
        bool isDoing { get; set; }

        /// <summary>
        /// timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            if (isDoing) return;
            try
            {
                isDoing = true;
                DoResult();
            }
            catch (Exception ex)
            {
                Log.Output(ex.Message);
            }
            finally
            {
                isDoing = false;
            }
        }
        #endregion
    }

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

        public static void Output(string fileName, string txt)
        {
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(fileName);
                if (fi.Exists)
                {
                    sw = fi.AppendText();
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
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
