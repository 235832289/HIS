using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using ExpressionEvaluation;

namespace com.digitalwave.iCare.gui.LIS
{  
    public class QualityControlRulesParser
    {
        private QualityControlData data;
        private QualityControlRule rule;
        private List<int> result;

        #region 已定义的Pattern
        private string valuePattern = @"$VALUE";
        private string prevValuePattern = @"$PREVVALUE";
        private string maxPattern = @"$MAX";
        private string minPattern = @"$MIN";
        private string xPattern = @"$X";
        private string sPattern = @"$S";    
        
        #endregion

        #region 把已经定义的字符串转化为具体的数值
        /// <summary>
        /// 替换方程中定义的变量
        /// </summary>
        /// <param name="formula">方程字符串</param>
        /// <param name="value">值</param>
        /// <param name="prevValue">下一个值</param>
        /// <returns>数学表达式的比较表达式字符串</returns>
        private string ReplaceFormulaDefinedVariable(string formula, string value, string prevValue)
        {
            StringBuilder sb = new StringBuilder(formula);
            sb.Replace(maxPattern, data.Max.ToString());
            sb.Replace(minPattern, data.Min.ToString());
            sb.Replace(xPattern, data.X.ToString());
            sb.Replace(sPattern, data.SD.ToString());
            sb.Replace(valuePattern, value);
            sb.Replace(prevValuePattern, prevValue);
            return sb.ToString();
        }

        /// <summary>
        /// 替换方程中定义的变量
        /// </summary>
        /// <param name="formula">方程字符串</param>
        /// <returns>比较表达式字符串</returns>
        private string ReplaceFormulaDefinedVariable(string formula)
        {
            StringBuilder sb = new StringBuilder(formula.ToUpper());
            sb.Replace(maxPattern, data.Max.ToString());
            sb.Replace(minPattern, data.Min.ToString());
            sb.Replace(xPattern, data.X.ToString());
            sb.Replace(sPattern, data.SD.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// 替换方程中定义的变量
        /// </summary>
        /// <param name="formula">方程字符串</param>
        /// <returns>比较表达式字符串</returns>
        private string ReplaceFormulaDefinedVariable(string formula, string value)
        {
            StringBuilder sb = new StringBuilder(formula.ToUpper());
            sb.Replace(maxPattern, data.Max.ToString());
            sb.Replace(minPattern, data.Min.ToString());
            sb.Replace(xPattern, data.X.ToString());
            sb.Replace(sPattern, data.SD.ToString());
            sb.Replace(valuePattern, value);
            return sb.ToString();
        }
        #endregion

        /// <summary>
        /// 构造解析器
        /// </summary>
        /// <param name="rule">规则</param>
        /// <param name="data">质控数据</param>
        public QualityControlRulesParser(QualityControlRule rule,QualityControlData data) 
        {
            this.rule = rule;
            this.data = data;
            FillResult();
        }

        #region 处理代码

        /// <summary>
        /// 解析方程字符串为一个方程的集合
        /// </summary>
        /// <returns>方程集合</returns>
        private string[] GetRuleFormulaArray()
        {
            return rule.Formula.Trim().Split('|');
        }

        /// <summary>
        /// 集合中的值在表达式中做运算，得出得结果Bool集合
        /// </summary>
        /// <param name="arr">数组集</param>
        /// <returns>Bool集合</returns>
        private List<bool> ProcessDataToBoolArray(string formulaRule)
        {
            string formula = formulaRule;
            ExpressionEval eval = new ExpressionEval();
            List<bool> contented = new List<bool>();
            if (data!=null)
            {
                if (data.Data!=null)
                {
                    for (int i = 0; i < data.Data.Length; i++)
                    {
                        if (!formula.ToUpper().Contains("$PREVVALUE")&&!formula.ToUpper().Contains("$MAX"))
                        {
                            eval.Expression = ReplaceFormulaDefinedVariable(formula, data.Data[i].ToString());
                            contented.Add(eval.EvaluateBool());
                        }

                        //处理包含最大最小值
                        if (formula.ToUpper().Contains("$MAX"))
                        {
                            eval.Expression = ReplaceFormulaDefinedVariable(formula, data.Data[i].ToString());
                            //contented.Add(eval.EvaluateBool());
                            if (eval.EvaluateBool())
                            {
                                if (data.Data[i] == data.Max || data.Data[i] == data.Min)
                                {
                                    contented.Add(true);
                                }
                                else 
                                {
                                    contented.Add(false);
                                }
                            }
                        }

                        //处理上升或下降趋势
                        if (formula.ToUpper().Contains("$PREVVALUE") && i != 0)
                        {
                            eval.Expression = ReplaceFormulaDefinedVariable(formula, data.Data[i].ToString(), data.Data[i - 1].ToString());
                            contented.Add(eval.EvaluateBool());
                        }
                        if (formula.ToUpper().Contains("$PREVVALUE") && i == 0)
                        {
                            contented.Add(true);
                        }
                    } 
                }
            }
            return contented;
        }

        //获取不符合数据的位置集合
        private List<int> GetUnmatchedDataPosList(string formulaRule)
        {
            string formula = formulaRule;
            List<int> posList =new List<int>();

            //转化为Bool类型数组
            List<bool> lstAccordData = ProcessDataToBoolArray(formula);
            int trueNum = 0;

            for (int i = 0; i < lstAccordData.Count; i++)
            {
                if (lstAccordData[i])
                {
                    posList.Add(i);
                    trueNum++;
                }

            }

            //如果不要求连续，并且数目超过限定值
            if (!rule.Joined && trueNum >= rule.Numer&&!rule.Formula.ToUpper().Contains("$MAX"))
            {
                return posList;
            }

            if (trueNum >= rule.Numer && rule.Formula.ToUpper().Contains("$MAX")) 
            {
                return posList;
            }

            //如果连续
            if (rule.Joined)
            {
                int startPos = 0;   //连续集合起始位
                int joinedNum = 0;  //连续的数目
                posList.Clear();

                for (int i = 0; i < lstAccordData.Count; i++)
                {
                    if (lstAccordData[i])
                    {
                        startPos = joinedNum == 0 ? i : startPos;
                        joinedNum++;
                    }
                    // 当判定为假，或者最后一个的时候
                    if (!lstAccordData[i] || (i == lstAccordData.Count-1&&lstAccordData[i]))
                    {
                        if (joinedNum >= rule.Numer)
                        {
                            for (int j = startPos; j < startPos+joinedNum; j++)
                            {
                                posList.Add(j);
                            }
                        }
                        joinedNum = 0;
                    }
                }
                return posList;
            }
            return null;
        }

        /// <summary>
        /// 根据Rule的多条方程。产生符合规则的数据
        /// </summary>
        /// <returns>HasTable,formula为Key</returns>
        private Hashtable GetProcessData()
        {
            Hashtable hasAccordFormulaData = new Hashtable();
            foreach (string formula in GetRuleFormulaArray())
            {
                if (GetUnmatchedDataPosList(formula) != null)
                    hasAccordFormulaData.Add(formula, GetUnmatchedDataPosList(formula));
            }
            return hasAccordFormulaData;
        }

        //填充结果
        public void FillResult()
        {
            List<int> lstPos = new List<int>();
            Hashtable result = GetProcessData();
            if (result != null)
            {
                foreach (DictionaryEntry dic in result)
                {
                    List<int> posList=(List<int>)dic.Value;
                    foreach (int pos in posList)
                    {
                        lstPos.Add(pos);
                    }
                }
                this.result = lstPos;
            }
        }

        /// <summary>
        /// 计算单独的表达式子
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        private double EvalExpression()
        {
            string formula = rule.Formula;
            string expression = ReplaceFormulaDefinedVariable(formula);
            ExpressionEval eval = new ExpressionEval(expression);
            return eval.EvaluateDouble();
        } 
        #endregion

        public List<int> GetResult()
        {
            return result;
        }

        public static Hashtable GetRulesDataResult(List<QualityControlRule> rules, QualityControlData qcData) 
        {
            Hashtable result = new Hashtable();
            if (rules!=null)
            {
                foreach (QualityControlRule rule in rules)
                {
                    QualityControlRulesParser parser = new QualityControlRulesParser(rule, qcData);
                    if (parser.GetResult().Count > 0)
                    {
                        result.Add(rule.Name, parser.GetResult());
                    }
                }
            }
            return result; 
        }

        public static Hashtable GetRulesDataResult(List<QualityControlRule> rules, List<QualityControlData> qcDatas)
        {
            Hashtable result = new Hashtable();
            if (rules != null&&qcDatas!=null)
            {
                foreach (QualityControlRule rule in rules)
                {
                    foreach (QualityControlData qcData in qcDatas)
                    {
                        QualityControlRulesParser parser = new QualityControlRulesParser(rule, qcData);
                        if (parser.GetResult().Count > 0)
                        {
                            result.Add(rule.Name, parser.GetResult());
                        }
                    }
                }
            }
            return result;
        }

    }
}
