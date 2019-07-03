using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 参照值类
    /// </summary>
    internal class clsSTConstract
    {

        #region 私有成员
        
        private float m_fltPositiveValue;
        private float m_fltNegativeValue;
        private float m_fltStandardValue;
        private float m_fltQuality;
        private float m_fltBlank;

        private List<clsSTConstractRule> m_lstNegativeRules = new List<clsSTConstractRule>();
        private List<clsSTConstractRule> m_lstPositiveRules = new List<clsSTConstractRule>();

        #endregion

        #region 属    性
        /// <summary>
        /// 阳性参照值
        /// </summary>
        public float PositiveValue
        {
            get { return m_fltPositiveValue; }
            set { m_fltPositiveValue = value; }
        }

        /// <summary>
        /// 阴性参照值
        /// </summary>
        public float NegativeValue
        {
            get { return m_fltNegativeValue; }
            set { m_fltNegativeValue = value; }
        }

        /// <summary>
        /// 标准参照值
        /// </summary>
        public float StandardValue
        {
            get { return m_fltStandardValue; }
            set { m_fltStandardValue = value; }
        }

        /// <summary>
        /// 质控参照值
        /// </summary>
        public float QualityValue
        {
            get { return m_fltQuality; }
            set { m_fltQuality = value; }
        }

        /// <summary>
        /// 空白值
        /// </summary>
        public float BlankValue
        {
            get { return m_fltBlank; }
            set { m_fltBlank = value; }
        }

        public void Analysis(List<clsSTBoardItem> boardItems) 
        {
            List<clsSTBoardItem> lstNegative = new List<clsSTBoardItem>();
            List<clsSTBoardItem> lstPositive = new List<clsSTBoardItem>();
            List<clsSTBoardItem> lstBlank = new List<clsSTBoardItem>();
            foreach (clsSTBoardItem boardItem in boardItems)
            {
                if (boardItem.BoardStyle.SampleStyle==enmSTSampleStyle.Negative)
                {
                    lstNegative.Add(boardItem);
                }
                if (boardItem.BoardStyle.SampleStyle==enmSTSampleStyle.Positive)
                {
                    lstPositive.Add(boardItem);
                }
                if (boardItem.BoardStyle.SampleStyle==enmSTSampleStyle.Blank)
                {
                    lstBlank.Add(boardItem);
                }
            }

            List<clsSTConstractRule> lstNegativeRules = clsST360Config.CurrentConfig.NegativeRules;
            List<clsSTConstractRule> lstPositiveRules = clsST360Config.CurrentConfig.PositiveRules;

            List<float> lstNegativeVaules=new List<float>();
            List<float> lstPositiveValues = new List<float>();

            foreach (clsSTBoardItem nBoardItem in lstNegative)
            {
                bool isChanged = false;
                float data = float.Parse(nBoardItem.DataNum);
                foreach (clsSTConstractRule nRule in lstNegativeRules)
                {
                    if (nRule.BiggerThan)
                    {
                        if (data > nRule.ReferenceValue)
                        {
                            isChanged = true;
                            lstNegativeVaules.Add(nRule.ActualValue);
                        }
                    }
                    else 
                    {
                        if (data<nRule.ReferenceValue)
                        {
                            isChanged = true;
                            lstNegativeVaules.Add(nRule.ActualValue);
                        }
                    }
                }
                if (!isChanged)
                {
                    lstNegativeVaules.Add(data);
                }
            }


            foreach (clsSTBoardItem nBoardItem in lstPositive)
            {
                bool isChanged = false;
                float data = float.Parse(nBoardItem.DataNum);
                foreach (clsSTConstractRule nRule in lstPositiveRules)
                {
                    if (nRule.BiggerThan)
                    {
                        if (data > nRule.ReferenceValue)
                        {
                            isChanged = true;
                            lstPositiveValues.Add(nRule.ActualValue);
                        }
                    }
                    else
                    {
                        if (data < nRule.ReferenceValue)
                        {
                            isChanged = true;
                            lstPositiveValues.Add(nRule.ActualValue);
                        }
                    }
                }
                if (!isChanged)
                {
                    lstPositiveValues.Add(data);
                }
            }


            float nagtiveSum = 0;
            float positiveSum = 0;
            float blankSum = 0;
            for (int i = 0; i < lstNegativeVaules.Count; i++)
            {
                nagtiveSum+=lstNegativeVaules[i];
            }

            for (int i = 0; i < lstPositiveValues.Count; i++)
            {
                positiveSum += lstPositiveValues[i];
            }

            for (int i = 0; i < lstBlank.Count; i++)
            {
                blankSum+=float.Parse(lstBlank[i].DataNum);
            }

            nagtiveSum /= lstNegativeVaules.Count; 
            positiveSum /= lstPositiveValues.Count;
            blankSum /= lstBlank.Count;

            this.m_fltNegativeValue = (float)(((int)(nagtiveSum * 1000)) * 1.0 / 1000);
            this.m_fltPositiveValue = (float)(((int)(positiveSum * 1000)) * 1.0 / 1000);
            this.m_fltBlank = (float)(((int)(blankSum * 1000)) * 1.0 / 1000);
        }
        #endregion
    }
}
