using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 收费引导屏设置
    /// 2008.07.16 莫宝健 for 茶山
    /// </summary>
    public partial class frmOpChargeLEDConfig : Form
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmOpChargeLEDConfig()
        {
            InitializeComponent();
        }
        #endregion

        #region 变量

        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string m_strConfigFilePath = Application.StartupPath + "\\MonSettings.xml";
        /// <summary>
        /// 闲置消息最大关键字
        /// </summary>
        private int maxKey1 = 0;
        /// <summary>
        /// 离开消息最大关键字
        /// </summary>
        private int maxKey2 = 0;
        /// <summary>
        /// 闲置消息元素集
        /// </summary>
        private Dictionary<string, string> dictLeisureMsg = new Dictionary<string, string>();
        /// <summary>
        /// 暂停消息元素集
        /// </summary>
        private Dictionary<string, string> dictPauseMsg = new Dictionary<string, string>();
        /// <summary>
        /// 状态值数组: 如 闲置状态, 暂停状态等
        /// </summary>
        private System.Collections.ArrayList arrStatus = new System.Collections.ArrayList();
        /// <summary>
        /// 当前消息类型
        /// </summary>
        private string m_strCurStatus = string.Empty;
        /// <summary>
        /// 当前结点最大key值
        /// 用于生成新结点名称 = message + key值
        /// </summary>
        private int m_intCurMaxNum
        {
            get
            {
                if (m_strCurStatus == "LeisureMessage")
                {
                    return maxKey1;
                }
                else if (m_strCurStatus == "PauseMessage")
                {
                    return maxKey2;
                }
                else
                {
                    return 0;
                }
            }
        }

        #endregion

        #region 加载窗体
        private void frmOpChargeLEDConfig_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(m_strConfigFilePath))
            {
                createXmlFile();
            }
            this.m_mthReadXML();
            this.m_mthInit();
        }
        #endregion        

        #region 创建配置文件
        /// <summary>
        /// 创建配置文件
        /// </summary>
        public static void createXmlFile()
        {
            XmlWriter writer = null;
            try
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                settings.Indent = true;
                settings.IndentChars = ("\t");
                writer = XmlWriter.Create(m_strConfigFilePath, settings);
                writer.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"utf-8\"");
                writer.WriteStartElement("Main");

                #region 创建默认闲置消息
                writer.WriteStartElement("LeisureMessage");
                writer.WriteAttributeString("name", "闲置状态");
                //message1
                writer.WriteStartElement("message1");
                writer.WriteAttributeString("key", "1");
                writer.WriteAttributeString("value", "门诊社保结算窗口");
                writer.WriteEndElement();
                //message2
                writer.WriteStartElement("message2");
                writer.WriteAttributeString("key", "2");
                writer.WriteAttributeString("value", "银联卡结算窗口");
                writer.WriteEndElement();
                
                writer.WriteEndElement();
                #endregion

                #region 创建默认暂停消息
                writer.WriteStartElement("PauseMessage");
                writer.WriteAttributeString("name", "暂停状态");
                //message1
                writer.WriteStartElement("message1");
                writer.WriteAttributeString("key", "1");
                writer.WriteAttributeString("value", "暂停服务");
                writer.WriteEndElement();

                writer.WriteEndElement();
                #endregion

                writer.WriteEndElement();
                writer.Flush();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
        #endregion

        #region 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void m_mthReadXML()
        {
            XmlTextReader reader = null;
            int m_intTemp =0;

            try
            {
                reader = new XmlTextReader(m_strConfigFilePath);
                arrStatus = new System.Collections.ArrayList(10);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "LeisureMessage")
                    {
                        arrStatus.Add(reader.GetAttribute("name"));
                        dictLeisureMsg = new Dictionary<string, string>();
                        //读取闲置消息
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                m_intTemp = int.Parse(reader.GetAttribute("key"));
                                if (m_intTemp > maxKey1)
                                {
                                    maxKey1 = m_intTemp;
                                }
                                dictLeisureMsg.Add(reader.GetAttribute("key"), reader.GetAttribute("value"));
                            }
                            else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "LeisureMessage")
                            {
                                break;
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PauseMessage")
                    {
                        arrStatus.Add(reader.GetAttribute("name"));
                        dictPauseMsg = new Dictionary<string, string>();
                        //读取暂停消息
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                m_intTemp = int.Parse(reader.GetAttribute("key"));
                                if (m_intTemp > maxKey2)
                                {
                                    maxKey2 = m_intTemp;
                                }
                                dictPauseMsg.Add(reader.GetAttribute("key"), reader.GetAttribute("value"));
                            }
                            else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "PauseMessage")
                            {
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
                arrStatus.TrimToSize();
            }
        }

        /// <summary>
        /// 静态方法.供外部直接调用
        /// </summary>
        /// <param name="p_arrStatus">状态值数组</param>
        /// <param name="p_dictLeisureMsg">闲置消息元素集</param>
        /// <param name="p_dictPauseMsg">暂停消息元素集</param>
        public static void m_mthReadXML(out Dictionary<string, string> p_arrStatus, out Dictionary<string, string> p_dictLeisureMsg, out Dictionary<string, string> p_dictPauseMsg)
        {
            p_arrStatus = new Dictionary<string, string>();
            p_dictLeisureMsg = new Dictionary<string, string>();
            p_dictPauseMsg = new Dictionary<string, string>();

            if (!System.IO.File.Exists(m_strConfigFilePath))
            {
                createXmlFile();
            }

            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(m_strConfigFilePath);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "LeisureMessage")
                    {
                        p_arrStatus.Add(reader.Name, reader.GetAttribute("name"));
                        //读取闲置消息
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                p_dictLeisureMsg.Add(reader.GetAttribute("key"), reader.GetAttribute("value"));
                            }
                            else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "LeisureMessage")
                            {
                                break;
                            }
                        }
                    }

                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PauseMessage")
                    {
                        p_arrStatus.Add(reader.Name, reader.GetAttribute("name"));
                        //读取暂停消息
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                p_dictPauseMsg.Add(reader.GetAttribute("key"), reader.GetAttribute("value"));
                            }
                            else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "PauseMessage")
                            {
                                break;
                            }
                        }
                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        #endregion

        #region 初始化界面
        /// <summary>
        /// 初始化界面
        /// </summary>
        private void m_mthInit()
        {
            if (arrStatus.Count > 0)
            {
                this.comboBox1.Items.AddRange(arrStatus.ToArray());
                this.comboBox1.SelectedIndex = 0;
            }
        }
        #endregion

        #region 刷新界面
        /// <summary>
        /// 刷新界面,用在新增,修改,删除操作之后
        /// </summary>
        private void m_mthRefreshUI()
        {
            this.m_mthReadXML();
            this.comboBox1_SelectedIndexChanged(this.comboBox1, null);
        }
        #endregion

        #region 事件
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 1;
            this.comboBox2.Items.Clear();
            this.listBox1.Items.Clear();
            if (this.comboBox1.SelectedIndex == 0)
            {
                m_strCurStatus = "LeisureMessage";
                foreach (string var in dictLeisureMsg.Values)
                {
                    this.comboBox2.Items.Add(count++);
                    this.listBox1.Items.Add(var);
                }
                if (this.comboBox2.Items.Count > 0)
                    this.comboBox2.SelectedIndex = 0;
            }
            else if (this.comboBox1.SelectedIndex == 1)
            {
                m_strCurStatus = "PauseMessage";
                foreach (string var in dictPauseMsg.Values)
                {
                    this.comboBox2.Items.Add(count++);
                    this.listBox1.Items.Add(var);
                }
                if (this.comboBox2.Items.Count > 0)
                    this.comboBox2.SelectedIndex = 0;
            }
            else
            {
                return;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.SelectedIndex = this.comboBox2.SelectedIndex;            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox1.Focus();
            if (this.listBox1.SelectedIndex != this.comboBox2.SelectedIndex)
                this.comboBox2.SelectedIndex = this.listBox1.SelectedIndex;
            //获取当前值
            KeyValuePair<string, string> obj = new KeyValuePair<string, string>();
            if (this.comboBox1.SelectedIndex == 0)
            {
                foreach (KeyValuePair<string, string> kvp in dictLeisureMsg)
                {
                    if (kvp.Value == this.listBox1.SelectedItem.ToString())
                    {
                        obj = kvp;
                        break;
                    }
                }
            }
            else if (this.comboBox1.SelectedIndex == 1)
            {
                foreach (KeyValuePair<string, string> kvp in dictPauseMsg)
                {
                    if (kvp.Value == this.listBox1.SelectedItem.ToString())
                    {
                        obj = kvp;
                        break;
                    }
                }
            }
            else
            {
                return;
            }
            //保存当前值在listBox1的Tag属性
            this.listBox1.Tag = obj;
        }

        private void buttonXP4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSetText frmEdit = new frmSetText(m_strConfigFilePath, m_strCurStatus, m_intCurMaxNum, null);
            if(frmEdit.ShowDialog() == DialogResult.OK)
                this.m_mthRefreshUI();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmSetText frmEdit = new frmSetText(m_strConfigFilePath, m_strCurStatus, m_intCurMaxNum, this.listBox1.Tag);
            if(frmEdit.ShowDialog() == DialogResult.OK)
                this.m_mthRefreshUI();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认要删除吗？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(m_strConfigFilePath);
                XmlNode xn = document["Main"].SelectSingleNode(m_strCurStatus);
                KeyValuePair<string, string> curKvp = (KeyValuePair<string, string>)this.listBox1.Tag;
                foreach (XmlElement element in xn.ChildNodes)
                {
                    if (element.GetAttribute("key") == curKvp.Key && element.GetAttribute("value") == curKvp.Value)
                    {
                        xn.RemoveChild(element);
                        document.Save(m_strConfigFilePath);
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("删除失败", "系统提示");
                document = null;
                return;
            }
            finally
            {
                document = null;
            }
            this.m_mthRefreshUI();
        }

        #endregion

        private void frmOpChargeLEDConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}