using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    #region 参照值的规则类

    /// <summary>
    /// 参照值的规则类
    /// </summary>
    internal class clsSTConstractRule
    {
        private bool m_blnBiggerThan;
        private float m_fltActual;
        private float m_fltReference;
        private bool m_isPositive;

        /// <summary>
        /// (true 阳性,Flase 阴性)参考规则
        /// </summary>
        public bool Positive
        {
            get { return m_isPositive; }
            set { m_isPositive = value; }
        }


        /// <summary>
        /// 是否大于
        /// </summary>
        public bool BiggerThan
        {
            get { return m_blnBiggerThan; }
            set { m_blnBiggerThan = value; }
        }

        /// <summary>
        /// 临界值
        /// </summary>
        public float ReferenceValue
        {
            get { return m_fltReference; }
            set { m_fltReference = value; }
        }

        /// <summary>
        /// 转换后的实际值
        /// </summary>
        public float ActualValue
        {
            get { return m_fltActual; }
            set { m_fltActual = value; }
        }

    }
    #endregion
}
