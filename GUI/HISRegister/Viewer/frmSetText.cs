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
    public partial class frmSetText : Form
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        /// <param name="messageType">消息类型</param>
        /// <param name="MaxValue">最大值</param>
        /// <param name="objKvp">消息组合</param>
        public frmSetText(string filePath, string messageType, int MaxValue, object objKvp)
        {
            InitializeComponent();
            m_strFilePath = filePath;
            m_strMessageType = messageType;
            m_intMaxValue = MaxValue;
            if (objKvp != null)
                m_kvpData = (KeyValuePair<string, string>)objKvp;
        }
        #endregion

        #region 变量
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string m_strFilePath = string.Empty;
        /// <summary>
        /// 消息类型
        /// </summary>
        private string m_strMessageType = string.Empty;
        /// <summary>
        /// 最大值
        /// </summary>
        private int m_intMaxValue = 0;
        /// <summary>
        /// 消息组合
        /// </summary>
        private KeyValuePair<string, string> kvp;
        /// <summary>
        /// 消息组合
        /// </summary>
        public KeyValuePair<string, string> m_kvpData
        {
            set
            {
                kvp = value;
                this.txtContent.Text = value.Value;
                this.txtContent.SelectionStart = this.txtContent.Text.Length;
            }
            get
            {
                return kvp;
            }
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtContent.Text.Trim()))
            {
                MessageBox.Show("编辑框内容不能为空", "系统提示");
                this.txtContent.Focus();
                return;
            }

            XmlDocument xmldoc = new XmlDocument();
            try
            {
                xmldoc.Load(m_strFilePath);
                XmlNode xn = xmldoc["Main"].SelectSingleNode(m_strMessageType);
                if (kvp.Key == null && kvp.Value == null)
                {
                    //增加
                    string nodeName = "message" + (m_intMaxValue + 1).ToString();
                    XmlElement xe = xmldoc.CreateElement(nodeName);
                    xe.SetAttribute("key", (m_intMaxValue + 1).ToString());
                    xe.SetAttribute("value", this.txtContent.Text);
                    xn.AppendChild(xe); //追加子节点
                }
                else
                {
                    //修改
                    foreach (XmlElement element in xn.ChildNodes)
                    {
                        if (element.GetAttribute("key") == kvp.Key && element.GetAttribute("value") == kvp.Value)
                        {
                            element.SetAttribute("value", this.txtContent.Text);
                        }
                    }
                }
                xmldoc.Save(m_strFilePath);
            }
            finally
            {
                xmldoc = null;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}