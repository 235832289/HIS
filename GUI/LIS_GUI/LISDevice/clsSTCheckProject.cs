using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    #region 酶标仪检验项目
    /// <summary>
    ///  酶标仪检验项目
    /// </summary>
    internal class clsSTCheckProject
    {

        #region 内部成员

        private string m_name;
        private string m_englishName;
        private string m_testWaveLength;
        private string m_refWaveLength;
        private string m_boardFrequence;
        private string m_boardTime;
        private string m_boardWay;
        private string m_formula;

        #endregion

        private List<clsSTConstractRule> m_lstConstractRules;

        /// <summary>
        /// 计算阴阳对照值的规则
        /// </summary>
        public List<clsSTConstractRule> ConstractRules
        {
            get { return m_lstConstractRules; }
            set { m_lstConstractRules = value; }
        }


        #region 属　性

        /// <summary>
        /// ST360项目中文名称
        /// </summary>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        /// <summary>
        /// ST360项目英文名称
        /// </summary>
        public string EnglishName
        {
            get { return m_englishName; }
            set { m_englishName = value; }
        }

        /// <summary>
        /// 测试波长
        /// </summary>
        public string TestWaveLength
        {
            get { return m_testWaveLength; }
            set { m_testWaveLength = value; }
        }

        /// <summary>
        /// 参考波长
        /// </summary>
        public string RefWaveLength
        {
            get { return m_refWaveLength; }
            set { m_refWaveLength = value; }
        }

        /// <summary>
        /// 振板频率
        /// </summary>
        public string BoardFrequence
        {
            get { return m_boardFrequence; }
            set { m_boardFrequence = value; }
        }

        /// <summary>
        /// 振板时间
        /// </summary>
        public string BoardTime
        {
            get { return m_boardTime; }
            set { m_boardTime = value; }
        }

        /// <summary>
        /// 进板方式
        /// </summary>
        public string BoardWay
        {
            get { return m_boardWay; }
            set { m_boardWay = value; }
        }

        /// <summary>
        /// 阳性公式
        /// </summary>
        public string Formula
        {
            get { return m_formula; }
            set { m_formula = value; }
        }

        #endregion

        public override string ToString()
        {
            return m_name;
        }
    }
    #endregion
}
