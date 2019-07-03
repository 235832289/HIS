using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    #region 酶标板微孔描述类

    /// <summary>
    /// 酶标板微孔描述类
    /// </summary>
    internal class clsSTBoardItem
    {

        #region 私有成员

        private int sequence;
        private clsSTBoardStyle boardStyle = new clsSTBoardStyle();
        private string data;

        #endregion

        private bool m_isPositive;

        #region 属   性

        /// <summary>
        /// 微孔序号
        /// </summary>
        public int Sequence
        {
            get { return sequence; }
            set { sequence = value; }
        }

        /// <summary>
        /// 微孔样式
        /// </summary>
        public clsSTBoardStyle BoardStyle
        {
            get { return boardStyle; }
            set
            {
                boardStyle = value;
                //if (StyleChanged != null)
                //{
                //    StyleChanged(this, EventArgs.Empty);
                //}
            }
        }

        /// <summary>
        /// 微孔数据
        /// </summary>
        public string DataNum
        {
            get { return data; }
            set
            { data = value; }
        }

        /// <summary>
        /// 微孔数据定性分析结果（+,-）
        /// </summary>
        public bool IsPositive
        {
            get { return m_isPositive; }
            set { m_isPositive = value; }
        }

        #endregion
    }

    #endregion
}
