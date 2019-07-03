using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HI;
using System.Xml;
using LEDInterface.LianCheng;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 药房大液晶显示屏窗口
    /// </summary>
    public partial class frmBigScreen : Form
    {

        private string XMLFile = System.Windows.Forms.Application.StartupPath + "\\" + "LoginFile.xml";
        private clsDomainControlMedStoreBseInfo m_objDomain;
        private LEDManager.LianChen.LEDManager m_objLEDManager =null;
        private bool m_objBlnRunThread = true;
        #region 获取大液晶显示屏配置属性Vo
        /// <summary>
        /// 获取大液晶窗口显示屏配置属性Vo
        /// </summary>
        /// <param name="m_objVo"></param>
        public void m_mthGetMedStoreScreenConfigVo(out clsMedStoreScreenConfigVo m_objVo)
        {
            m_objVo = null;
            try
            {
                string strMsg = string.Empty;
                m_objVo = new clsMedStoreScreenConfigVo();
                bool res = this.m_objLEDManager.Load("MedstoreBigScreen", out strMsg);

                System.Drawing.Size m_objTempSize;
                if (!res)
                {
                    throw new ApplicationException(strMsg);
                }
                System.Collections.Specialized.NameValueCollection nv = m_objLEDManager.GetMasterCustomStyle(0);
                try
                {
                    m_objVo.m_objBigScreenFont = new System.Drawing.Font(nv["Font"], float.Parse(nv["FontSize"]));
                    m_objVo.m_intCallTime = int.Parse(nv["CallTime"]);
                    m_objTempSize = m_objLEDManager.GetSize(0);
                    m_objVo.m_intScreenWidth = m_objTempSize.Width;
                    m_objVo.m_intScreenHeight = m_objTempSize.Height;

                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        /// <summary>
        /// constructor
        /// </summary>
        public frmBigScreen()
        {
            InitializeComponent();
            this.m_objDomain = new clsDomainControlMedStoreBseInfo();
            m_objLEDManager = new com.digitalwave.iCare.LEDManager.LianChen.LEDManager();
        }
      
        private System.Threading.Thread m_ThreadRefreshScreen = null;
        /// <summary>
        /// 大显示屏配置属性
        /// </summary>
        public clsMedStoreScreenConfigVo m_objScreenConfigVo=null;
        private void frmBigScreen_Load(object sender, EventArgs e)
        {

            this.m_mthGetMedStoreScreenConfigVo(out m_objScreenConfigVo);
            if (m_objScreenConfigVo != null)
            {
               
                this.Width = m_objScreenConfigVo.m_intScreenWidth + 10 + 4;
                this.Height = m_objScreenConfigVo.m_intScreenHeight + 29 + 4;
              
            }
        }
        /// <summary>
        /// 药房ｉｄ
        /// </summary>
        public string m_strMedStoreID = "";
        /// <summary>
        /// 药房发药窗口1
        /// </summary>
        public string m_strSendWindowID1= "";
        /// <summary>
        /// 药房发药窗口2
        /// </summary>
        public string m_strSendWindowID2 = "";
        /// <summary>
        /// 药房发药窗口3
        /// </summary>
        public string m_strSendWindowID3 = "";
        /// <summary>
        /// 药房发药窗口4
        /// </summary>
        public string m_strSendWindowID4 = "";
        /// <summary>
        /// 药房发药窗口5
        /// </summary>
        public string m_strSendWindowID5 = "";
    /// <summary>
    /// 显示窗口
    /// </summary>
    /// <param name="m_strMedStoreNO"></param>
    /// <param name="m_strWindowID1"></param>
    /// <param name="m_strWindowID2"></param>
    /// <param name="m_strWindowID3"></param>
    /// <param name="m_strWindowID4"></param>
    /// <param name="m_strWindowID5"></param>
        public void m_mthShow(string m_strMedStoreNO, string m_strWindowID1, string m_strWindowID2, string m_strWindowID3, string m_strWindowID4,string m_strWindowID5)
        {
            if (m_strMedStoreNO.Trim() == string.Empty)
            {
                MessageBox.Show(this, "请先正确配置药房ID！", "iCare系统温馨提示：", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }
            m_strMedStoreID = m_strMedStoreNO.Trim();
            this.m_strSendWindowID1 = m_strWindowID1.Trim();
            this.m_strSendWindowID2 = m_strWindowID2.Trim();
            this.m_strSendWindowID3 = m_strWindowID3.Trim();
            this.m_strSendWindowID4 = m_strWindowID4.Trim();
            this.m_strSendWindowID5 = m_strWindowID5.Trim();
            this.ShowInTaskbar = false;
            this.Opacity = 0;
            this.Show();
            m_ThreadRefreshScreen = new System.Threading.Thread(new System.Threading.ThreadStart(m_mthCallAndShowToScreen));
            m_ThreadRefreshScreen.IsBackground = true;
            m_ThreadRefreshScreen.Start();

          
        }
        private void m_mthCallAndShowToScreen()
        {
            while (m_objBlnRunThread)
            {
                try
                {
                    this.m_mthCallPatient();
                    this.m_mthShowToScreen();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                System.Threading.Thread.Sleep(m_objScreenConfigVo.m_intCallTime * 1000);
            }
      
        }
        private void m_CallTimer_Tick(object sender, EventArgs e)
        {
            this.m_mthCallAndShowToScreen();

        }
        #region 按一定的时间间隔呼叫病人
        /// <summary>
        /// 按一定的时间间隔呼叫病人
        /// </summary>
        public void m_mthCallPatient()
        {
            try
            {
             
                string m_strCallContent = "";
                string m_strWindowID = "";
                long lngRes = -1;
                DataTable m_objTable;
                lngRes = this.m_objDomain.m_lngGetMedStoreCallInfoByID(m_strMedStoreID, out m_objTable);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strCallContent = m_objTable.Rows[0]["CALLDESC_VCHR"].ToString().Trim();
                    m_strWindowID = m_objTable.Rows[0]["WINDOWID_CHR"].ToString().Trim();
                }
                if (m_strCallContent.Trim() != string.Empty)
                {
                    TTSClient.TTSClient.PlaySound(m_strCallContent);
                    lngRes = this.m_objDomain.m_lngDelMedStoreCallInfoByID(m_strMedStoreID, m_strWindowID);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion
        #region 将该病房的所有未发药显示到大显示屏
        /// <summary>
        /// 将该病房的所有未发药显示到大液晶显示屏
        /// </summary>
        public void m_mthShowToScreen()
        {
            try
            {
                long lngRes = -1;
                DataTable m_objTable;
                lngRes = this.m_objDomain.m_lngGetMedStoreSendInfo(DateTime.Now.ToString("yyyy-MM-dd"), m_strMedStoreID, out m_objTable);
                if (lngRes <= 0)
                {
                    return;
                }
                ArrayList m_objPatientName1 = new ArrayList();
                ArrayList m_objPatientName2 = new ArrayList();
                ArrayList m_objPatientName3 = new ArrayList();
                ArrayList m_objPatientName4 = new ArrayList();
                ArrayList m_objPatientName5 = new ArrayList();
                string m_strPrintContent = "";
                string m_strScreenContent = string.Format("{0,-5}{1,-5}{2,-5}{3,-5}{4,-1}", "1号窗口 　", "2号窗口 　", "3号窗口 　", "4号窗口 　","5号窗口\n");
                int m_intRowNO = 0;
                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    if (m_objTable.Rows[i]["SENDWINDOWID"].ToString().Trim() == m_strSendWindowID1)
                    {
                        m_objPatientName1.Add(m_objTable.Rows[i]["NAME_VCHR"].ToString().Trim());
                    }
                    else if (m_objTable.Rows[i]["SENDWINDOWID"].ToString().Trim() == m_strSendWindowID2)
                    {
                        m_objPatientName2.Add(m_objTable.Rows[i]["NAME_VCHR"].ToString().Trim());
                    }
                    else if (m_objTable.Rows[i]["SENDWINDOWID"].ToString().Trim() == m_strSendWindowID3)
                    {
                        m_objPatientName3.Add(m_objTable.Rows[i]["NAME_VCHR"].ToString().Trim());
                    }
                    else if (m_objTable.Rows[i]["SENDWINDOWID"].ToString().Trim() == m_strSendWindowID4)
                    {
                        m_objPatientName4.Add(m_objTable.Rows[i]["NAME_VCHR"].ToString().Trim());
                    }
                    else if (m_objTable.Rows[i]["SENDWINDOWID"].ToString().Trim() == m_strSendWindowID5)
                    {
                        m_objPatientName5.Add(m_objTable.Rows[i]["NAME_VCHR"].ToString().Trim());
                    }

                }
                for (int j = 0; j < m_objTable.Rows.Count; j++)
                {
                    string m_strTemp = "";
                    m_intRowNO++;
                    if (j < m_objPatientName1.Count && m_objPatientName1[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + "." + this.m_mthFillForName(m_objPatientName1[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-3}", m_strTemp);
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-3}", m_strTemp);

                    }
                    if (j < m_objPatientName2.Count && m_objPatientName2[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + "." + this.m_mthFillForName(m_objPatientName2[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-3}{1,-3}", m_strPrintContent, m_strTemp);
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-3}{1,-3}", m_strPrintContent, m_strTemp);

                    }
                    if (j < m_objPatientName3.Count && m_objPatientName3[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + "." + this.m_mthFillForName(m_objPatientName3[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-3}{1,-3}", m_strPrintContent, m_strTemp);
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-3}{1,-3}", m_strPrintContent, m_strTemp);

                    }
                    if (j < m_objPatientName4.Count && m_objPatientName4[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + "." + this.m_mthFillForName(m_objPatientName4[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-3}{1,-3}", m_strPrintContent, m_strTemp);
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-3}{1,-3}", m_strPrintContent, m_strTemp);

                    }
                    if (j < m_objPatientName5.Count && m_objPatientName5[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + this.m_mthFillForName(m_objPatientName5[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-3}{1,-1}", m_strPrintContent, m_strTemp) + "\n";
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-3}{1,-1}", m_strPrintContent, m_strTemp) + "\n";

                    }
                    m_strScreenContent += m_strPrintContent;

                }

                #region 把病人信息发送到发药窗口的显示屏
                try
                {
            
                    Bitmap bmp = new Bitmap(this.m_PbBigScreen.Width, this.m_PbBigScreen.Height);
                    
                    Graphics g = Graphics.FromImage(bmp);
                    g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);

                    g.DrawString(m_strScreenContent,this.m_objScreenConfigVo.m_objBigScreenFont, Brushes.Red, 0, 0);
                    g.Dispose();
                   
                    this.m_PbBigScreen.Image = bmp;
                   
                    this.m_objLEDManager.Show(bmp, 0, false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                #endregion

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion
        #region 补位--默认情况设病人的姓名为4个中文字
        private string m_mthFillForName(string m_strPatientName)
        {
            if (m_strPatientName != string.Empty)
            {
                if (m_strPatientName.Length == 2)
                {
                    m_strPatientName += "　　";
                }
                else if (m_strPatientName.Length == 3)
                {
                    m_strPatientName += "　";

                }
                return m_strPatientName;
            }
            else
            {
                m_strPatientName = "　　　　";

            }
            return m_strPatientName;

        }
        #endregion

        private void MenuItem_Exit_Click(object sender, EventArgs e)
        {
            try
            {   
               
                this.m_ThreadRefreshScreen.Abort();
                if (this.m_objLEDManager != null)
                {
                    this.m_objLEDManager.ShowBlack(true);
                    this.m_objLEDManager.Unload();
                }
            }
            catch (Exception ex)
            {
            }
            this.Dispose();
        }

        private void frmBigScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.m_ThreadRefreshScreen.Abort();
                if (this.m_objLEDManager != null)
                {
                    this.m_objLEDManager.ShowBlack(true);
                    this.m_objLEDManager.Unload();
                }

            }
            catch (Exception ex)
            {
            }
            this.Dispose();
        }
    }
}