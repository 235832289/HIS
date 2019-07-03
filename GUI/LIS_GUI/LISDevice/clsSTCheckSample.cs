using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    #region 酶标仪试剂

    /// <summary>
    /// 酶标仪试剂
    /// </summary>
    internal class clsSTCheckSample
    {
        private string m_BatchNo;
        private string m_company;
        private string m_deadLine;

        /// <summary>
        /// 试剂批号
        /// </summary>
        public string BatchNo
        {
            get { return m_BatchNo; }
            set { m_BatchNo = value; }
        }

        /// <summary>
        /// 结束日期
        /// </summary>
        public string DeadLine
        {
            get { return m_deadLine; }
            set { m_deadLine = value; }
        }

        /// <summary>
        /// 生产厂商
        /// </summary>
        public string Company
        {
            get { return m_company; }
            set { m_company = value; }
        }

        public override string ToString()
        {
            return m_BatchNo;
        }
    }
    #endregion
}
