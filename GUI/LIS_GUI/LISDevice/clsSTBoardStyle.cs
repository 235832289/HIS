using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    #region 酶标板微孔样式类

    /// <summary>
    /// 酶标板微孔样式类
    /// </summary>
    internal class clsSTBoardStyle
    {
        public clsSTBoardStyle()
        {

        }

        #region 私有成员

        private enmSTSampleStyle sampleStyle = enmSTSampleStyle.NONE;
        private int sampleStyleNo;

        #endregion

        #region 属 性

        ///// <summary>
        ///// 样本的序号
        ///// </summary>
        //public int SampleNo
        //{
        //    get { return sampleNo; }
        //    set { sampleNo = value; }
        //}

        /// <summary>
        /// 样本类型
        /// </summary>
        public enmSTSampleStyle SampleStyle
        {
            get { return sampleStyle; }
            set { sampleStyle = value; }
        }

        /// <summary>
        /// 样本在同类型样本中的序号
        /// </summary>
        public int SampleStyleNo
        {
            get { return sampleStyleNo; }
            set { sampleStyleNo = value; }
        }
        #endregion
    }

    #endregion
}
