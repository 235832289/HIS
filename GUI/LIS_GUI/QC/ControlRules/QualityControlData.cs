using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    /***********************************************
     *              质控的数据
     * *********************************************/
    public class QualityControlData
    {
        private double[] ruleData;
        private double max;
        private double min;
        private double x;
        private double sd;

        public QualityControlData(double[] ruleData)
        {
            if (ruleData.Length > 0) 
            {
                this.ruleData = (double[])ruleData.Clone();
                min = ruleData[0];
                foreach (double num in ruleData)
                {
                    if (num < min)
                        min = num;
                }

                max = ruleData[0];
                foreach (double num in ruleData)
                {
                    if (num > max)
                    {
                        max = num;
                    }
                }
            }
        }

        /// <summary>
        /// 低质控测定值
        /// </summary>
        public double Min
        {
            get 
            {
                
                return min;
            }
        }

        /// <summary>
        ///  高质控测定值
        /// </summary>
        public double Max
        {
            get 
            {
               
                return max;
            }
        }

        /// <summary>
        /// 平均数（X）
        /// </summary>
        public double X
        {
            get 
            {
                return x;
            }
            set 
            {
                if (x >= 0) 
                {
                   x= value;
                }
            }
        }

        /// <summary>
        /// s
        /// </summary>
        public double SD 
        {
            get 
            {
                return sd;
            }
            set 
            {
                if (sd >= 0) 
                {
                    sd = value;
                }
            }
        }
        public double[] Data
        {
            get 
            {
                return ruleData;
            }
        }
    }
}
