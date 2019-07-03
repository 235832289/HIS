using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{

    /******************************************
     *          质控规则实体类
     ******************************************/

    public class QualityControlRule
    {
        private string name;    //规则名称
        private string formula; //判定表达式名称
        private bool joined;    //是否要求连续
        private int number;     //符合规则的数目
        private bool isWarning; //质控规则的报警
        
        public QualityControlRule() { }

        public QualityControlRule(string name, string formula, bool joined, int number, bool isWarning) 
        {
            this.name = name;
            this.formula = formula;
            this.joined = joined;
            this.number = number;
            this.isWarning = isWarning;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Formula
        {
            get
            {
                return formula;
            }
            set
            {
                formula = value;
            }
        }

        public bool Joined
        {
            get
            {
                return joined;
            }
            set
            {
                joined = value;
            }
        }

        public int Numer
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public bool IsWarning
        {
            get { return isWarning; }
            set { isWarning = value; }
        }
      
    }
}
