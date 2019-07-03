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
using System.IO;
using LEDInterface.LianCheng;
using com.digitalwave.iCare.LEDManager.LianChen;


namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// 发药显示小窗口

    /// </summary>
    public partial class frmSmallScreen : Form
    {   
        
        internal  static frmSmallScreen SmallScreenFrm;
        /// <summary>
        /// 判断是否创建窗体
        /// </summary>
        /// <param name="p_text"></param>
        /// <returns></returns>
        public static frmSmallScreen SmallScreenForm(string p_text)
        {
            if (SmallScreenFrm == null)
            {
                SmallScreenFrm = new frmSmallScreen(p_text);
                return SmallScreenFrm;
            }
            else
            {
                SmallScreenFrm.m_strPatientName = p_text;
            }
            return SmallScreenFrm;
        }
        private frmSmallScreen (string text)
        {
            InitializeComponent();
            m_objLEDManager = new com.digitalwave.iCare.LEDManager.LianChen.LEDManager();
            this.m_strPatientName = text;
        }
        /// <summary>
        /// 构造函数

        /// </summary>
        public frmSmallScreen()
        {
            InitializeComponent();
           
        }
        /// <summary>
        /// 动态生成显示屏图片
        /// </summary>
        public Bitmap[] m_objBmpArr;
        private string XMLFile = System.Windows.Forms.Application.StartupPath + "\\" + "LoginFile.xml";
        private LEDManager.LianChen.LEDManager m_objLEDManager;
        /// <summary>
        /// 屏幕配置属性Vo
        /// </summary>
        public clsMedStoreScreenConfigVo m_objVo = null;
        /// <summary>
        /// 是否显示预览显示屏

        /// </summary>
        public bool m_blnShowPreviewLED = false;
        private clsDomainControlMedStoreBseInfo m_objDomain = new clsDomainControlMedStoreBseInfo();
        /// <summary>
        /// 药房id
        /// </summary>
        public string m_strMedStoreID = "";
        /// <summary>
        /// 窗口id
        /// </summary>
        public string m_strWindowID="";
        /// <summary>
        /// 病人名称
        /// </summary>
        public string m_strPatientName = "";
        #region 获取发药窗口显示屏配置属性Vo
        /// <summary>
        /// 获取发药窗口显示屏配置属性Vo
        /// </summary>
        public void m_mthGetMedStoreScreenConfigVo()
        {
            #region old
            //m_objVo = null;
            //try
            //{

            //    if (File.Exists(XMLFile))
            //    {
            //        XmlDocument m_objXmlDoc = new XmlDocument();
            //        m_objXmlDoc.Load(XMLFile);
            //        XmlNode m_objXmlParentNode = m_objXmlDoc.DocumentElement.SelectNodes("register")[0];
            //        XmlNode m_objXmlCNScreenHeight = m_objXmlParentNode.SelectSingleNode("MedStoreScreenHeight");
            //        XmlNode m_objXmlCNScreenWidth = m_objXmlParentNode.SelectSingleNode("MedStoreScreenWidth");
            //        XmlNode m_objXmlCNScreenComm = m_objXmlParentNode.SelectSingleNode("MedStoreScreenComm");
            //        XmlNode m_objXmlCNScreenMode = m_objXmlParentNode.SelectSingleNode("MedStoreScreenMode");
            //        XmlNode m_objXmlCNScreenSpeed = m_objXmlParentNode.SelectSingleNode("MedStoreScreenSpeed");
            //        XmlNode m_objXmlCNScreenDelayTime = m_objXmlParentNode.SelectSingleNode("MedStoreScreenDelayTime");
            //        XmlNode m_objXmlCNScreenColorSwap = m_objXmlParentNode.SelectSingleNode("MedStoreScreenColorSwap");
            //        XmlNode m_objXmlCNScreenRgSwap = m_objXmlParentNode.SelectSingleNode("MedStoreScreenRgSwap");
            //        XmlNode m_objXmlCNScreenID = m_objXmlParentNode.SelectSingleNode("MedStoreScreenID ");

            //        XmlNode m_objXmlCNScreenFontSize = m_objXmlParentNode.SelectSingleNode("MedStoreScreenFontSize");

            //        if (m_objXmlParentNode != null)
            //        {
            //            try
            //            {
            //                m_objVo = new clsMedStoreScreenConfigVo();
            //                m_objVo.m_strScreenID = int.Parse(m_objXmlCNScreenID.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intSpeed = int.Parse(m_objXmlCNScreenSpeed.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intScreenWidth = int.Parse(m_objXmlCNScreenWidth.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intScreenHeight = int.Parse(m_objXmlCNScreenHeight.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intRgSwap = int.Parse(m_objXmlCNScreenRgSwap.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intMode = int.Parse(m_objXmlCNScreenMode.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intDelayTime = int.Parse(m_objXmlCNScreenDelayTime.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intComm = int.Parse(m_objXmlCNScreenComm.Attributes["value"].Value.ToString().Trim());
            //                m_objVo.m_intColorSwap = int.Parse(m_objXmlCNScreenColorSwap.Attributes["value"].Value.ToString().Trim());

            //                m_objVo.m_intFontSize = int.Parse(m_objXmlCNScreenFontSize.Attributes["value"].Value.ToString().Trim());
            //            }
            //            catch (Exception Ex)
            //            {
            //                MessageBox.Show(Ex.Message.ToString());
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
            #endregion
            
            string strMsg = string.Empty;
            m_objVo = new clsMedStoreScreenConfigVo();
            bool res = this.m_objLEDManager.Load("MedstoreSendWindow", out strMsg);

            System.Drawing.Size m_objTempSize;
            if (!res)
            {
                throw new ApplicationException(strMsg);
            }
            System.Collections.Specialized.NameValueCollection nv = m_objLEDManager.GetMasterCustomStyle(0);
            try
            {
                m_objVo.m_objUpFont = new System.Drawing.Font(nv["Font"], float.Parse(nv["UpFontSize"]),FontStyle.Bold);

                m_objVo.m_objDownFont = new System.Drawing.Font(nv["Font"], float.Parse(nv["DownFontSize"]),FontStyle.Bold);
          
                m_objVo.m_strDescription = nv["Description"].ToString();
                m_objTempSize = m_objLEDManager.GetSize(0);
                m_objVo.m_intScreenWidth = m_objTempSize.Width;
                m_objVo.m_intScreenHeight = m_objTempSize.Height;
               
            }
            catch
            {
            }
        }
        #region 执行插入呼叫内容操作同时显示操作
        /// <summary>
         /// 执行插入呼叫内容操作同时显示操作
         /// </summary>
        /// <param name="m_strcbWindowsID">窗口ID</param>
        /// <param name="m_strPatientCardID">病人诊疗卡号</param>
        /// <param name="m_objListView">病人取药队列</param>
        public void m_mthShowContent(string m_strcbWindowsID,ListView m_objListView,ArrayList m_objArrayList)
        {
            this.ShowInTaskbar = false;
            this.Opacity = this.m_blnShowPreviewLED ? 100 : 0;
            this.Show();
            try
            {
               
                float m_fltPosY = 0;
                string m_strWindowNo = m_strcbWindowsID.Substring(2, 1).Trim();
                string m_strPrintContentUp = m_strWindowNo + "号 窗口";
                string m_strPrintContentDown ="";
                this.timer1.Enabled = true;
                #region 把病人信息发送到发药窗口的显示屏
                try
                {

                    clsCallPatientVo m_objTempVo;
                    Bitmap bmp=null ;
                    Graphics g=null ;
                    for (int i = 0; i < m_objArrayList.Count; i++)
                    {
                        if (i % 12 == 0)
                        {
                            bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
                            g = Graphics.FromImage(bmp);
                            g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);
                            m_fltPosY = 2;
                            g.DrawString(m_strPrintContentUp, this.m_objVo.m_objUpFont, Brushes.Red, bmp.Width * 0.34f, m_fltPosY);
                            m_fltPosY = this.m_objVo.m_objUpFont.Size + 10;
                        }
                        if (i < 4 + (i / 12) * 12)
                        {
                            m_objTempVo = (clsCallPatientVo)m_objArrayList[i];
                            //m_strPrintContentDown = m_objTempVo.m_strServerNo + " " + m_objTempVo.m_strPatientName;
                            m_strPrintContentDown =m_objTempVo.m_strPatientName;
                            g.DrawString(m_strPrintContentDown, this.m_objVo.m_objDownFont, Brushes.Red,4, m_fltPosY);
                            m_fltPosY += this.m_objVo.m_objDownFont.Size+7;
                            if (i-(i/12)*12==3)
                            {
                                m_fltPosY = this.m_objVo.m_objUpFont.Size + 10;
                            }
                        }
                        else if (i < 8 + (i / 12) * 12)
                        {
                            m_objTempVo = (clsCallPatientVo)m_objArrayList[i];
                           // m_strPrintContentDown = m_objTempVo.m_strServerNo + " " + m_objTempVo.m_strPatientName;
                            m_strPrintContentDown =m_objTempVo.m_strPatientName;
                            g.DrawString(m_strPrintContentDown, this.m_objVo.m_objDownFont, Brushes.Red,bmp.Width*0.35f+4, m_fltPosY);
                            m_fltPosY += this.m_objVo.m_objDownFont.Size+7;
                            if (i - (i / 12) * 12 == 7)
                            {
                                m_fltPosY = this.m_objVo.m_objUpFont.Size + 10;
                            }
                        }
                        else if (i < 12 + (i / 12) * 12)
                        {
                            m_objTempVo = (clsCallPatientVo)m_objArrayList[i];
                            // m_strPrintContentDown = m_objTempVo.m_strServerNo + " " + m_objTempVo.m_strPatientName;
                            m_strPrintContentDown = m_objTempVo.m_strPatientName;
                            g.DrawString(m_strPrintContentDown, this.m_objVo.m_objDownFont, Brushes.Red, bmp.Width * 0.7f+4, m_fltPosY);
                            m_fltPosY += this.m_objVo.m_objDownFont.Size + 7;
                        }
                        m_objBmpArr[i /12] = bmp;

                    }

                    if (m_objArrayList.Count == 0)
                    {
                        bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
                        g = Graphics.FromImage(bmp);
                        g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);
                        m_fltPosY = 2;
                        g.DrawString(m_strPrintContentUp, this.m_objVo.m_objUpFont, Brushes.Red, bmp.Width * 0.34f, m_fltPosY);
                        m_objBmpArr = new Bitmap[1];
                        m_objBmpArr[0] = bmp;
                    }
                    if (g != null)
                    {
                        g.Dispose();
                    }
          
               
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
            if (!m_blnShowPreviewLED)
            {
                this.Hide();
            }
     

        }
        #endregion
        #region 发药完成后电子屏清除该病人姓名和刷新等待取药的病人队列



        /// <summary>
        ///  发药完成后电子屏清除该病人姓名和刷新等待取药的病人队列



        /// </summary>
        /// <param name="m_strcbWindowsID">窗口ID</param>
        /// <param name="m_objListView">病人取药队列</param>
        public void m_mthShowContentAfterSendMedicine(string m_strcbWindowsID, ListView m_objListView)
        {
            this.ShowInTaskbar = false;
            this.Opacity = this.m_blnShowPreviewLED ? 100 : 0;
            this.Show();
            try
            {
               
                string m_strTemp = "\n\n\n" + m_objVo.m_strDescription + "\n";
                string m_strWindowNo = m_strcbWindowsID.Substring(2, 1).Trim();
                string m_strPrintContent = "\n" + "         " + m_strWindowNo + "号 窗口\n";
                //m_strPrintContent += "---------------------------------\n";
                //for (int i = m_objListView.Items.Count - 1; i >= 0; i--)
                //{
                //    if (i < m_objListView.Items.Count - 6) break;
                //    m_strTemp += this.m_mthFillForName(m_objListView.Items[i].Text.Trim()) + "  ";

                //    if (i == m_objListView.Items.Count - 3)
                //        m_strTemp += "\n";

                //}

                
                #region 把病人信息发送到发药窗口的显示屏
                try
                {


                    Bitmap bmp = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
                    Graphics g = Graphics.FromImage(bmp);

                    g.FillRectangle(Brushes.Black, 0, 0, bmp.Width, bmp.Height);
                    g.DrawString(m_strPrintContent, this.m_objVo.m_objUpFont, Brushes.Red, 0, 0);
                    //g.DrawString(m_strTemp, this.m_objVo.m_objDownFont, Brushes.Red, 0, 0);
                    g.Dispose();
                    this.pictureBox1.Image = bmp;
                    this.pictureBox1.Refresh();
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
            if (!m_blnShowPreviewLED)
            {
                this.Hide();
            }


        }
        #endregion

        private void frmSmallScreen_Load(object sender, EventArgs e)
        {
            this.m_mthGetMedStoreScreenConfigVo();
            this.m_mthInitialData();

        }
        private void m_mthInitialData()
        {
            if (m_objVo != null)
            {
          
                this.Width = this.m_objVo.m_intScreenWidth + 4 + 6;
                this.Height = this.m_objVo.m_intScreenHeight + 4 + 25;
            }
        }
        #endregion

        private void frmSmallScreen_FormClosing(object sender, FormClosingEventArgs e)
        {   
            //if(this.m_objLEDManager!=null)
            //this.m_objLEDManager.Unload();
            frmSmallScreen.SmallScreenFrm = null;
            this.Dispose();
        }
        /// <summary>
        /// 关闭窗口显示黑屏
        /// </summary>
        public void m_mthCloseLED()
        {
            this.m_objLEDManager.ShowBlack(true);
            if (frmSmallScreen.SmallScreenFrm != null)
            {
                frmSmallScreen.SmallScreenFrm.Close();
                frmSmallScreen.SmallScreenFrm = null;
            }
        }
        /// <summary>
        /// 暂停服务
        /// </summary>
        public void m_mthPauseServer()
        {
            this.m_objLEDManager.ShowFunction("Wait", 0, true);

            try
            {
                Image m_imageTemp = Image.FromFile(Application.StartupPath + @"\LEDImage\192_80_wait.bmp");
                this.pictureBox1.Image = m_imageTemp;
                this.timer1.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
    　  
        /// <summary>
        /// 继续服务，程序屏显示黑屏
        /// </summary>
        public void m_mthGoOnServer()
        {
            this.m_objLEDManager.Unlock();
            //this.pictureBox1.Image = null;
            this.timer1.Enabled = true;
        }
        /// <summary>
        /// 显示黑屏
        /// </summary>
        public void m_mthShowBlackScreen()
        {
            this.m_objLEDManager.ShowBlack(true);
        }
        #region 补位--默认情况设病人的姓名为4个中文字
        private string m_mthFillForName(string m_strPatientName)
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
        #endregion
        /// <summary>
        /// 图片索引
        /// </summary>
        public int m_intIndex = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(m_objBmpArr!=null)
            if (m_intIndex < this.m_objBmpArr.Length)
            {
                if (this.m_objBmpArr[m_intIndex] != null)
                {
                    this.pictureBox1.Image = this.m_objBmpArr[m_intIndex];
                    this.pictureBox1.Refresh();
                    this.m_objLEDManager.Show(this.m_objBmpArr[m_intIndex], 0, false);
                }
                m_intIndex++;
                if (m_intIndex == this.m_objBmpArr.Length)
                {
                    m_intIndex = 0;
                }
            }
           
        }
    }
}