using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Collections;
using com.digitalwave.iCare.gui.HIS;
using System.Xml;
using System.IO;
using System.Drawing.Printing;
using com.digitalwave.iCare.middletier.HI;
using LEDInterface.LianCheng;


namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 药房大液晶屏窗口的控制类
    /// </summary>
    public class clsControllBigScreen : com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsControllBigScreen()
        {
            m_objDomain = new clsDomainControlMedStoreBseInfo();
        }
        private clsDomainControlMedStoreBseInfo m_objDomain;
        /// <summary>
        /// 显示屏
        /// </summary>
        public frmBigScreen m_objViewer;
        //#region 设置窗体对象
        ///// <summary>
        ///// 设置窗体对象
        ///// </summary>
        ///// <param name="frmMDI_Child_Base_in"></param>
        //public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        //{
        //    base.Set_GUI_Apperance(frmMDI_Child_Base_in);
        //    m_objViewer = (frmBigScreen)frmMDI_Child_Base_in;
        //}
        //#endregion
        private string XMLFile = System.Windows.Forms.Application.StartupPath + "\\" + "LoginFile.xml";
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

                if (File.Exists(XMLFile))
                {
                    XmlDocument m_objXmlDoc = new XmlDocument();
                    m_objXmlDoc.Load(XMLFile);

                    XmlNode m_objXmlParentNode = m_objXmlDoc.DocumentElement.SelectNodes("register")[0];
                    XmlNode m_objXmlCNScreenHeight = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenHeight");
                    XmlNode m_objXmlCNScreenWidth = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenWidth");
                    XmlNode m_objXmlCNScreenComm = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenComm");
                    XmlNode m_objXmlCNScreenMode = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenMode");
                    XmlNode m_objXmlCNScreenSpeed = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenSpeed");
                    XmlNode m_objXmlCNScreenDelayTime = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenDelayTime");
                    XmlNode m_objXmlCNScreenColorSwap = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenColorSwap");
                    XmlNode m_objXmlCNScreenRgSwap = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenRgSwap");
                    XmlNode m_objXmlCNScreenID = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenID ");
                    XmlNode m_objXmlCNScreenCallTime = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenCallTime");
                    XmlNode m_objXmlCNScreenFontSize = m_objXmlParentNode.SelectSingleNode("MedStoreBScreenFontSize");

                    if (m_objXmlParentNode != null)
                    {
                        try
                        {
                            m_objVo = new clsMedStoreScreenConfigVo();
                            m_objVo.m_strScreenID = int.Parse(m_objXmlCNScreenID.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intSpeed = int.Parse(m_objXmlCNScreenSpeed.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intScreenWidth = int.Parse(m_objXmlCNScreenWidth.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intScreenHeight = int.Parse(m_objXmlCNScreenHeight.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intRgSwap = int.Parse(m_objXmlCNScreenRgSwap.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intMode = int.Parse(m_objXmlCNScreenMode.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intDelayTime = int.Parse(m_objXmlCNScreenDelayTime.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intComm = int.Parse(m_objXmlCNScreenComm.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intColorSwap = int.Parse(m_objXmlCNScreenColorSwap.Attributes["value"].Value.ToString().Trim());
                            m_objVo.m_intCallTime = int.Parse(m_objXmlCNScreenCallTime.Attributes["value"].Value.ToString().Trim());
                            //m_objVo.m_intFontSize = int.Parse(m_objXmlCNScreenFontSize.Attributes["value"].Value.ToString().Trim());
                        }
                        catch (Exception Ex)
                        {
                            MessageBox.Show(Ex.Message.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
        #region 按一定的时间间隔呼叫病人
        /// <summary>
        /// 按一定的时间间隔呼叫病人
        /// </summary>
        public void m_mthCallPatient(string m_strMedStoreId)
        {
            try
            {
                string m_strMedStorID = m_strMedStoreId;
                string m_strCallContent = "";
                string m_strWindowID = "";
                long lngRes = -1;
                DataTable m_objTable;
                lngRes = this.m_objDomain.m_lngGetMedStoreCallInfoByID(m_strMedStorID,out m_objTable);
                if (lngRes > 0 && m_objTable.Rows.Count > 0)
                {
                    m_strCallContent = m_objTable.Rows[0]["CALLDESC_VCHR"].ToString().Trim();
                    m_strWindowID = m_objTable.Rows[0]["WINDOWID_CHR"].ToString().Trim();
                }
                if (m_strCallContent.Trim() != string.Empty)
                {
                    TTSClient.TTSClient.PlaySound(m_strCallContent);
                    lngRes = this.m_objDomain.m_lngDelMedStoreCallInfoByID(m_strMedStorID, m_strWindowID);
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
        #region 将该病房的所有未发药显示到大液晶显示屏
        /// <summary>
        /// 将该病房的所有未发药显示到大液晶显示屏
        /// </summary>
        public void m_mthShowToScreen(string m_strMedStoreID, string m_strSendWindowID1, string m_strSendWindowID2, string m_strSendWindowID3, string m_strSendWindowID4)
        {
            try
            {
                long lngRes = -1;
                DataTable m_objTable;
                lngRes = this.m_objDomain.m_lngGetMedStoreSendInfo(DateTime.Now.ToString("yyyy-MM-dd"), m_strMedStoreID, out m_objTable);
                if (lngRes <=0)
                {
                    return;
                }
                ArrayList m_objPatientName1 = new ArrayList();
                ArrayList m_objPatientName2 = new ArrayList();
                ArrayList m_objPatientName3 = new ArrayList();
                ArrayList m_objPatientName4 = new ArrayList();
                string m_strPrintContent = "";
                string m_strScreenContent = string.Format("{0,-5}{1,-5}{2,-5}{3,-1}", "1号窗口 　", "2号窗口 　", "3号窗口 　", "4号窗口\n");
                int m_intRowNO=0;
                for (int i=0;i<m_objTable.Rows.Count;i++)
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
                  
                }
                for (int j = 0; j < m_objTable.Rows.Count; j++)
                {  
                    string m_strTemp="";
                    m_intRowNO++;
                    if (j < m_objPatientName1.Count&&m_objPatientName1[j] != null)
                    {   
                        m_strTemp=m_intRowNO.ToString().Trim()+" "+this.m_mthFillForName(m_objPatientName1[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-5}",m_strTemp);
                    }
                    else
                    {   
                        m_strTemp="  "+this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-5}", m_strTemp);

                    }
                    if (j < m_objPatientName2.Count&&m_objPatientName2[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + " " + this.m_mthFillForName(m_objPatientName2[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-5}{1,-5}",m_strPrintContent,m_strTemp);
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-5}{1,-5}", m_strPrintContent,m_strTemp);

                    }
                    if (j < m_objPatientName3.Count&&m_objPatientName3[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + " " + this.m_mthFillForName(m_objPatientName3[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-5}{1,-5}", m_strPrintContent, m_strTemp);
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-5}{1,-5}", m_strPrintContent,m_strTemp);

                    }
                    if (j < m_objPatientName4.Count&&m_objPatientName4[j] != null)
                    {
                        m_strTemp = m_intRowNO.ToString().Trim() + " " + this.m_mthFillForName(m_objPatientName4[j].ToString().Trim());
                        m_strPrintContent = string.Format("{0,-5}{1,-1}", m_strPrintContent, m_strTemp) +"\n";
                    }
                    else
                    {
                        m_strTemp = "  " + this.m_mthFillForName(string.Empty);
                        m_strPrintContent = string.Format("{0,-5}{1,-1}", m_strPrintContent,m_strTemp) + "\n";

                    }
                    m_strScreenContent += m_strPrintContent;
                    
                }
               
                #region 把病人信息发送到发药窗口的显示屏
                try
                {

                  
                 
                    Bitmap bmp = new Bitmap(this.m_objViewer.m_PbBigScreen.Width, this.m_objViewer.m_PbBigScreen.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.DrawString(string.Empty, this.m_objViewer.Font, Brushes.Red, 0, 0);
                    g.Dispose();
                    Image m_ojbImage = this.m_objViewer.m_PbBigScreen.Image;
                    this.m_objViewer.m_PbBigScreen.Image = bmp;
                    if (m_ojbImage != null)
                    {
                        m_ojbImage.Dispose();
                    }
                    this.m_objViewer.m_PbBigScreen.Refresh();
                    this.m_objViewer.m_PbBigScreen.Show();
                    g = Graphics.FromHwnd(this.m_objViewer.m_PbBigScreen.Handle);
                    IntPtr hdc = g.GetHdc();
                    byte res = Introp.sendtwp(hdc, (byte)1, (byte)2, 320, 112, (byte)0, (byte)0, (byte)0, (byte)0, (byte)0);
                    g.ReleaseHdc();
                    g.Dispose();
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
    }
}
