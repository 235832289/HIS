using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.LIS
{
    public class QcParserXmlRules
    {
        private List<QualityControlRule> ruleList = null;
        private XmlReader rulesReader;

        public QcParserXmlRules(string xmlData)
        {
            ruleList=new List<QualityControlRule>();
            ParserXmlStringRules(xmlData);
        }

        private bool ParserXmlStringRules(string xmlData)
        {
            try
            {
                CreateReaderByString(xmlData);
                processXmlReader(rulesReader);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public QualityControlRule Rule
        {
            get
            {
                if(ruleList.Count>0)
                    return ruleList[0];
                return null;
            }
        }
        
        public List<QualityControlRule> RuleList
        {
            get
            {
                if (ruleList.Count > 0)
                    return ruleList;
                else
                    return null;
            }
        }

        /// <summary>
        /// 创建Xml的访问对象
        /// </summary>
        /// <returns></returns>
        private XmlReader CreateReaderByString(string xmlData)
        {
            try
            {
                return rulesReader = XmlReader.Create(new StringReader(xmlData));
            }
            catch
            {
            }
            return null;
        }

        /// <summary>
        /// 解析Xml文件成实例
        /// </summary>
        /// <param name="xmlRule"></param>
        private void processXmlReader(XmlReader xmlRule)
        {
            try
            {
                QualityControlRule oneRule = new QualityControlRule();
                while (xmlRule.Read())
                {
                    xmlRule.MoveToElement();
                    while (xmlRule.Read())
                    {
                        if (xmlRule.Name.ToLower().Trim() == "rule")
                        {
                            oneRule.Name = xmlRule.GetAttribute("name");
                        }
                        if (xmlRule.Name.ToLower().Trim() == "formula")
                        {
                            oneRule.Formula = xmlRule.ReadString();
                        }
                        if (xmlRule.Name.ToLower().Trim() == "joined")
                        {
                            oneRule.Joined = xmlRule.ReadElementContentAsBoolean();
                        }
                        if (xmlRule.Name.ToLower().Trim() == "number")
                        {
                            oneRule.Numer = xmlRule.ReadElementContentAsInt();
                        }
                        if (xmlRule.Name.ToLower().Trim() == "warning")
                        {
                            oneRule.IsWarning = xmlRule.ReadElementContentAsBoolean();
                            ruleList.Add(oneRule);
                            oneRule = new QualityControlRule();
                        }
                    }
                    break;
                }
            }
            finally
            {
                xmlRule.Close();
            }
        }

        public static string ParserOneRuleToXmlString(QualityControlRule rule)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<rule name=\"{0}\">");
            sb.AppendLine();
            sb.Append(@"  <formula>{1}</formula>");
            sb.AppendLine();
            sb.Append(@"    <joined>{2}</joined>");
            sb.AppendLine();
            sb.Append(@"     <Number>{3}</Number>");
            sb.AppendLine();
            sb.Append(@"      <warning>{4}</warning>");
            sb.AppendLine();
            sb.Append(@"</rule>");
            return
                string.Format(sb.ToString(), rule.Name, rule.Formula, Convert.ToInt32(rule.Joined), rule.Numer,
                              Convert.ToInt32(rule.IsWarning));
        }
        
        public static string ParserRuleArrToXmlString(List<QualityControlRule> rules)
        {
        //    if (rules.Count == 0)
        //        return string.Empty;
            
            StringBuilder sb=new StringBuilder();
            sb.Append("<Rules>");
            foreach (QualityControlRule rule in rules)
            {
                sb.Append(ParserOneRuleToXmlString(rule));
            }
            sb.Append("</Rules>");
            return sb.ToString();
        }
    }
}