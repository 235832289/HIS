using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;
using System.Drawing.Printing;
using System.IO;
using System.Xml;
namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPChargeRight : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 门诊收费导引屏
        /// </summary>
        public frmOPChargeRight()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置一个布尔值，指示是否显示合计金额
        /// </summary>
        public bool IsShowAmount
        {
            set
            {
                m_lblAmount.Visible = value;
                if (!value)
                {
                    m_lblAmount.Text = "";
                }
            }
        }
        /// <summary>
        /// 收费窗口主界面
        /// </summary>
        public frmOPCharge m_objFormViewer;
        clsLedConfigVo m_objConfigVo = new clsLedConfigVo();
        /// <summary>
        /// 当前显示消息
        /// </summary>
        private string m_strCurShow = "请到此窗口交费";
        private string m_strFontName = "黑体";
        private float m_fltFontSize = 8.5f;
        public string m_strSumFontName = "黑体";
        public float m_fltSumFontSize = 8.5f;
        private string XMLFile = System.Windows.Forms.Application.StartupPath + "\\" + "LoginFile.xml";
        /// <summary>
        /// 读取电子屏配置属性
        /// </summary>
        public void m_mthReadXml()
        {
            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument m_objXmlDoc = new XmlDocument();
                    m_objXmlDoc.Load(XMLFile);
                    XmlNode m_objXmlParentNode = m_objXmlDoc.DocumentElement.SelectNodes("OPCharge")[0];
                    XmlNode LEDRefreshTime = m_objXmlParentNode.SelectSingleNode("LEDIdleTime");
                    XmlNode LEDWelcome = m_objXmlParentNode.SelectSingleNode("LEDWelcome");
                    XmlNode LEDTitleBar = m_objXmlParentNode.SelectSingleNode("LEDTitleBar");
                    XmlNode LEDPosX = m_objXmlParentNode.SelectSingleNode("LEDPosX");
                    XmlNode LEDPosY = m_objXmlParentNode.SelectSingleNode("LEDPosY");
                    XmlNode LEDWidth = m_objXmlParentNode.SelectSingleNode("LEDWidth");
                    XmlNode LEDHeight = m_objXmlParentNode.SelectSingleNode("LEDHeight");
                    XmlNode LEDShow = m_objXmlParentNode.SelectSingleNode("LEDShow");
                    XmlNode LEDFontSize = m_objXmlParentNode.SelectSingleNode("TipsFont");
                    XmlNode LedSumSize = m_objXmlParentNode.SelectSingleNode("SumFont");
                    if (m_objXmlParentNode != null)
                    {
                        try
                        {
                            m_objConfigVo.m_intIdleTime = int.Parse(LEDRefreshTime.Attributes["value"].Value.ToString().Trim());
                            m_objConfigVo.m_strWelcome = LEDWelcome.Attributes["value"].Value.ToString().Trim();
                            m_objConfigVo.m_intPosX = int.Parse(LEDPosX.Attributes["value"].Value.ToString().Trim());
                            m_objConfigVo.m_intPosY = int.Parse(LEDPosY.Attributes["value"].Value.ToString().Trim());
                            m_objConfigVo.m_intHeight = int.Parse(LEDHeight.Attributes["value"].Value.ToString().Trim());
                            m_objConfigVo.m_intWidth = int.Parse(LEDWidth.Attributes["value"].Value.ToString().Trim());
                            m_objConfigVo.m_strLEDBarVisble = LEDTitleBar.Attributes["value"].Value.ToString().Trim();
                            m_strCurShow = LEDShow.Attributes["value"].Value.ToString().Trim();
                            m_strFontName = LEDFontSize.Attributes["name"].Value.ToString();
                            m_fltFontSize = float.Parse(LEDFontSize.Attributes["value"].Value.ToString());
                            m_strSumFontName = LedSumSize.Attributes["name"].Value.ToString();
                            m_fltSumFontSize = float.Parse(LedSumSize.Attributes["value"].Value.ToString());
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
        /// <summary>
        /// 保存自定义设置
        /// </summary>
        public void m_mthWriteXml()
        {
            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument m_objXmlDoc = new XmlDocument();
                    m_objXmlDoc.Load(XMLFile);
                    XmlNode m_objXmlParentNode = m_objXmlDoc.DocumentElement.SelectNodes("OPCharge")[0];
                    XmlNode LEDPosX = m_objXmlParentNode.SelectSingleNode("LEDPosX");
                    XmlNode LEDPosY = m_objXmlParentNode.SelectSingleNode("LEDPosY");
                    XmlNode LEDWidth = m_objXmlParentNode.SelectSingleNode("LEDWidth");
                    XmlNode LEDHeight = m_objXmlParentNode.SelectSingleNode("LEDHeight");
                    XmlNode LEDShow = m_objXmlParentNode.SelectSingleNode("LEDShow");


                    if (m_objXmlParentNode != null)
                    {
                        try
                        {
                            LEDPosX.Attributes["value"].Value = this.DesktopLocation.X.ToString();
                            LEDPosY.Attributes["value"].Value = this.DesktopLocation.Y.ToString();
                            LEDHeight.Attributes["value"].Value = this.Height.ToString();
                            LEDWidth.Attributes["value"].Value = this.Width.ToString();
                            LEDShow.Attributes["value"].Value = m_strCurShow;
                            m_objXmlDoc.Save(XMLFile);
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
        public string m_strHosTitle = string.Empty;
        private void frmOPChargeRight_Load(object sender, EventArgs e)
        {
            this.m_mthReadXml();
            this.m_mthInitial();
            this.label3.Text = m_strCurShow;
            this.m_mthLoadContextMenu();
            IsShowAmount = false;
            this.m_lblBestWish.Text = GlobalParm.HospitalName + "医疗信息平台";
        }
        private void m_mthInitial()
        {
            this.WindowState = FormWindowState.Normal;
            this.Width = this.m_objConfigVo.m_intWidth;
            this.Height = this.m_objConfigVo.m_intHeight;
            this.SetDesktopLocation(this.m_objConfigVo.m_intPosX, this.m_objConfigVo.m_intPosY);
            //this.m_lblHosTitle.Text = m_strHosTitle;
            //this.m_lblHosTitle.Text = "";
            this.m_lblBestWish.Text = m_strHosTitle;
            this.timer1.Interval = this.m_objConfigVo.m_intIdleTime * 1000;
            if (this.m_objConfigVo.m_strLEDBarVisble.Trim() == "0")
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            this.m_lblAmount.Font = new Font(this.m_strSumFontName, this.m_fltSumFontSize);
        }
        #region 载入右键菜单
        /// <summary>
        /// 载入右键菜单
        /// </summary>
        private void m_mthLoadContextMenu()
        {
            System.Collections.Generic.Dictionary<string, string> dictStatus = null;
            System.Collections.Generic.Dictionary<string, string> dictLeisureMsg = new System.Collections.Generic.Dictionary<string, string>();
            System.Collections.Generic.Dictionary<string, string> dictPauseMsg = new System.Collections.Generic.Dictionary<string, string>();
            frmOpChargeLEDConfig.m_mthReadXML(out dictStatus, out dictLeisureMsg, out dictPauseMsg);

            int i1 = 0;
            foreach (System.Collections.Generic.KeyValuePair<string, string> kvp in dictStatus)
            {
                ToolStripMenuItem objItem = new ToolStripMenuItem();
                objItem.Name = "tsmItem" + (i1 + 1).ToString();
                objItem.Size = new System.Drawing.Size(152, 22);
                objItem.Text = kvp.Value;
                objItem.Image = imageList1.Images[1];
                this.cmsContext.Items.Add(objItem);
                if (kvp.Key == "LeisureMessage")
                {
                    int j1 = 0;
                    foreach (string s in dictLeisureMsg.Values)
                    {
                        ToolStripMenuItem objChild = new ToolStripMenuItem();
                        objChild.Name = "tsmChildItem" + (j1 + 1).ToString();
                        objChild.Size = new System.Drawing.Size(152, 22);
                        objChild.Text = s;
                        objChild.Click += new EventHandler(tsmChildItem_Click);
                        objItem.DropDownItems.Add(objChild);
                    }
                }
                else if (kvp.Key == "PauseMessage")
                {
                    int j2 = 0;
                    foreach (string s in dictPauseMsg.Values)
                    {
                        ToolStripMenuItem objChild = new ToolStripMenuItem();
                        objChild.Name = "tsmChildItem2" + (j2 + 1).ToString();
                        objChild.Size = new System.Drawing.Size(152, 22);
                        objChild.Text = s;
                        objChild.Click += new EventHandler(tsmChildItem_Click);
                        objItem.DropDownItems.Add(objChild);
                    }
                }

                ToolStripSeparator tssLine = new ToolStripSeparator();
                tssLine.Name = "toolStripSeparator" + (i1 + 1).ToString();
                tssLine.Size = new System.Drawing.Size(149, 6);
                this.cmsContext.Items.Add(tssLine);
                i1++;
            }
            // 设置
            ToolStripMenuItem objlast = new ToolStripMenuItem();
            objlast.Name = "tsmConfig";
            objlast.Size = new System.Drawing.Size(152, 22);
            objlast.Text = "设置";
            objlast.Image = imageList1.Images[0];
            objlast.Click += new EventHandler(tsmConfig_Click);
            this.cmsContext.Items.Add(objlast);
        }

        private void tsmConfig_Click(object sender, EventArgs e)
        {
            frmOpChargeLEDConfig frmConfig = new frmOpChargeLEDConfig();
            this.TopMost = false;
            if (frmConfig.ShowDialog() == DialogResult.OK)
            {
                this.TopMost = true;
                this.cmsContext.Items.Clear();
                m_mthLoadContextMenu();
            };
        }

        private void tsmChildItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedItem = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in ((ToolStripMenuItem)selectedItem.OwnerItem).DropDownItems)
            {
                item.Image = null;
            }
            selectedItem.Image = imageList1.Images[4];
            this.m_strCurShow = selectedItem.Text;
            this.label3.Text = this.m_strCurShow;
        }

        /// <summary>
        /// 显示提醒消息
        /// </summary>
        public void m_mthsetNotice()
        {
            this.label5.Font = new System.Drawing.Font(m_strFontName, m_fltFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Text = "请当面点清钞票，离台恕不负责！";
            this.label6.Font = new System.Drawing.Font(m_strFontName, m_fltFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Text = "请保留红色票据到药房取药！";
        }
        #endregion
        private void frmOPChargeRight_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult m_objDR = MessageBox.Show(this, "是否保存当前导引屏的大小和高度设置？", "系统提示信息：", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (m_objDR == DialogResult.OK)
            {
                try
                {
                    this.m_mthWriteXml();
                }
                catch
                {
                    MessageBox.Show(this, "查看LoginFile.xml文件是否为只读？", "系统提示信息：", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.m_objFormViewer.m_PatientBasicInfo.txtCardID.Text.Trim() == string.Empty)
            {
                //this.lable1.Text = "";
                this.label2.Text = "";
                this.label3.Text = m_strCurShow;
                this.label4.Text = "";
                this.label1.Text = "";
                this.label5.Text = "";
                this.label6.Text = "";
                this.label7.Text = "";
                this.label7.Visible = false;
                IsShowAmount = false;
            }
        }
    }
    public class clsLedConfigVo
    {
        /// <summary>
        ///　空闲刷新时间
        /// </summary>
        public int m_intIdleTime = 20;
        /// <summary>
        /// 屏水平位置
        /// </summary>
        public int m_intPosY = 0;
        /// <summary>
        /// 屏垂直位置
        /// </summary>
        public int m_intPosX = 0;
        /// <summary>
        /// 屏高度
        /// </summary>
        public int m_intHeight = 0;
        /// <summary>
        /// 屏宽度
        /// </summary>
        public int m_intWidth = 0;
        /// <summary>
        /// 祝福信息
        /// </summary>
        public string m_strWelcome = "祝你身体健康！";
        /// <summary>
        /// 窗体标题可视化
        /// </summary>
        public string m_strLEDBarVisble = "1";
    }
}