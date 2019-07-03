using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 酶标板微孔控件
    /// </summary>
    internal partial class ctlSTTextBox : TextBox
    {

        #region Color

        public Color COMMONCOLOR = Color.Black;
        public Color BLANKCOLOR = Color.DarkRed;
        public Color NEGATIVECOLOR = Color.Blue;
        public Color POSITIVECOLOR = Color.Red;
        public Color STANDARDCOLOR = Color.Purple;
        public Color QUALITYCOLOR = Color.Green;

        #endregion

        #region 私有成员

        private clsSTBoardItem m_boardItem;

        #endregion

        #region 属    性

        public clsSTBoardItem BoardItem
        {
            get { return m_boardItem; }
            set
            {
                m_boardItem = value;
                RefreshItem();
            }
        }

        private enmSTTextBoxShowStatus m_showStatus;

        public enmSTTextBoxShowStatus ShowStatus
        {
            get { return m_showStatus; }
            set { m_showStatus = value;}
        }

        #endregion

        #region 构造函数

        public ctlSTTextBox()
        {
            InitializeComponent();
        }

        public ctlSTTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public ctlSTTextBox(clsSTBoardItem boardItem)
        {
            InitializeComponent();
            this.m_boardItem = boardItem;
            this.Width = 60;
            this.TextAlign = HorizontalAlignment.Center;
            RefreshItem();
        }

        #endregion

        #region 方    法

        private void RefreshItem()
        {
            switch (m_boardItem.BoardStyle.SampleStyle)
            {
                case enmSTSampleStyle.NONE:
                    this.ForeColor = COMMONCOLOR;
                    break;
                case enmSTSampleStyle.Common:
                    this.ForeColor = COMMONCOLOR;
                    break;
                case enmSTSampleStyle.Blank:
                    this.ForeColor = BLANKCOLOR;
                    break;
                case enmSTSampleStyle.Negative:
                    this.ForeColor = NEGATIVECOLOR;
                    break;
                case enmSTSampleStyle.Positive:
                    this.ForeColor = POSITIVECOLOR;
                    break;
                case enmSTSampleStyle.Standard:
                    this.ForeColor = STANDARDCOLOR;
                    break;
                case enmSTSampleStyle.Quality:
                    this.ForeColor = QUALITYCOLOR;
                    break;
                default:
                    break;
            }

            if (m_boardItem.BoardStyle.SampleStyle != enmSTSampleStyle.NONE)
            {
                switch (this.m_showStatus)
                {
                    case enmSTTextBoxShowStatus.None:
                        break;
                    case enmSTTextBoxShowStatus.BoardStyle:
                        this.Text = GetBoardItemStyle(m_boardItem.BoardStyle);
                        break;
                    case enmSTTextBoxShowStatus.ResultNum:
                        this.Text = string.Format("{0}", this.m_boardItem.DataNum);
                        break;
                    case enmSTTextBoxShowStatus.ResultText:
                        this.Text = string.Format("{0}:  {1}", GetBoardItemStyle(m_boardItem.BoardStyle), this.m_boardItem.IsPositive ? "+" : "-");
                        break;
                    default:
                        break;
                }
            }
            else 
            {
                this.Text = string.Empty;
            }
        }

        /// <summary>
        /// 点击的时候发生
        /// </summary>
        public void DoClick()
        {
            RefreshItem();
            this.SelectAll();
        }

        #endregion

        /// <summary>
        /// 获取微孔板样式的文字表现形式
        /// </summary>
        /// <param name="boardStyle"></param>
        /// <returns></returns>
        private string GetBoardItemStyle(clsSTBoardStyle boardStyle)
        {
            string result = string.Empty ;
            switch (boardStyle.SampleStyle)
            {
                case enmSTSampleStyle.Blank:
                    result = "B";
                    break;
                case enmSTSampleStyle.Common:
                    result = string.Format("{0}", boardStyle.SampleStyleNo.ToString().PadLeft(2, '0'));
                    break;
                case enmSTSampleStyle.NONE:
                    result = string.Empty;
                    break;
                case enmSTSampleStyle.Negative:
                    result = "N";
                    break;
                case enmSTSampleStyle.Positive:
                    result = "P";
                    break;
                case enmSTSampleStyle.Quality:
                    result = string.Format("Q{0}",boardStyle.SampleStyleNo.ToString().PadLeft(2,'0'));
                    break;
                case enmSTSampleStyle.Standard:
                    result = string.Format("S{0}", boardStyle.SampleStyleNo.ToString().PadLeft(2, '0'));
                    break;
                default:
                    break;
            }
            return result;
        }

    }

    /// <summary>
    /// 酶标板微孔显示的状态
    /// </summary>
    internal enum enmSTTextBoxShowStatus 
    {
        /// <summary>
        /// 空样式
        /// </summary>
        None,
        /// <summary>
        /// 模板样式
        /// </summary>
        BoardStyle,
        /// <summary>
        /// 数字结果
        /// </summary>
        ResultNum,
        /// <summary>
        /// 文本结果(+,-)
        /// </summary>
        ResultText
    }
}
