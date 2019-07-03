using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// ST360的配置类
    /// </summary>
    internal class clsST360Config
    {

        private clsST360Config() { }

        #region 静态成员

        private static clsST360Config m_config = new clsST360Config();
        public static clsST360Config CurrentConfig
        {
            get { return m_config; }
        } 
        #endregion

        #region 私有成员

        private const string ItemPath = @".\LIS_DataAnalyse\ST360\CheckItems.config";
        private const string TemplatePath = @".\LIS_DataAnalyse\ST360\Templates.config";

        private List<clsSTCheckProject> m_lstProjects = new List<clsSTCheckProject>();
        private List<clsSTCheckSample> m_lstSamples = new List<clsSTCheckSample>();
        private List<clsBoardTemplate> m_lstTemplates = new List<clsBoardTemplate>();
        private List<clsSTConstractRule> m_lstPositiveRules = new List<clsSTConstractRule>();
        private List<clsSTConstractRule> m_lstNegativeRules = new List<clsSTConstractRule>();
        
        #endregion

        #region 属  性
        /// <summary>
        /// 检验项目列表
        /// </summary>
        public List<clsSTCheckProject> Projects
        {
            get { return m_lstProjects; }
        }

        /// <summary>
        /// 检验试剂列表
        /// </summary>
        public List<clsSTCheckSample> Samples
        {
            get { return m_lstSamples; }
        }

        /// <summary>
        /// 模板列表
        /// </summary>
        public List<clsBoardTemplate> Templates
        {
            get { return m_lstTemplates; }
        }

        public List<clsSTConstractRule> PositiveRules 
        {
            get { return m_lstPositiveRules; }
        }

        public List<clsSTConstractRule> NegativeRules 
        {
            get { return m_lstNegativeRules; }
        }


        #endregion

        #region 读取配置

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <param name="message"></param>
        public bool Load(out string message)
        {
            message = string.Empty;

            this.m_lstProjects.Clear();
            this.m_lstSamples.Clear();
            this.m_lstTemplates.Clear();

            if (!LoadProjects(out message))
            {
                return false;
            }
            if (!LoadSamples(out message))
            {
                return false;
            }
            if (!LoadTemplates(out message))
            {
                return false;
            }

            //if (!LoadConstractRules(out message) )
            //{
            //    return false;
            //}
            return true;
        }

        private bool LoadProjects(out string message)
        {
            message = string.Empty;

            if (!System.IO.File.Exists(ItemPath))
            {
                message = "未找到配置文件.";
                return false;
            }

            System.Xml.XmlDocument xmlConfig = new System.Xml.XmlDocument();
            try
            {
                xmlConfig.Load(ItemPath);
                XmlNodeList itemNodes = xmlConfig["Configs"]["Items"].SelectNodes("Item");
                if (itemNodes == null || itemNodes.Count == 0)
                {
                    message = "配置文件中没有项目！";
                    return false;
                }
                foreach (XmlNode node in itemNodes)
                {
                    clsSTCheckProject item = new clsSTCheckProject();
                    foreach (XmlNode xn in node.ChildNodes)
                    {
                        switch (xn.Name)
                        {
                            case "Name": item.Name = xn.InnerText; break;
                            case "EnglishName": item.EnglishName = xn.InnerText; break;
                            case "TestWaveLength": item.TestWaveLength = xn.InnerText; break;
                            case "RefWaveLength": item.RefWaveLength = xn.InnerText; break;
                            case "BoardFrequence": item.BoardFrequence = xn.InnerText; break;
                            case "BoardTime": item.BoardTime = xn.InnerText; break;
                            case "BoardWay": item.BoardWay = xn.InnerText; break;
                            case "Formula": item.Formula = xn.InnerText; break;
                            case "ConstractValue": item.ConstractRules = LoadConnstractRules(xn); break;
                            default:
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(item.Name))
                    {
                        this.m_lstProjects.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            return true;
        }

        private bool LoadSamples(out string message)
        {
            message = string.Empty;

            if (!System.IO.File.Exists(ItemPath))
            {
                message = "未找到配置文件.";
                return false;
            }

            System.Xml.XmlDocument xmlConfig = new System.Xml.XmlDocument();
           
            try
            {
                xmlConfig.Load(ItemPath);
                XmlNodeList sampleNodes = xmlConfig["Configs"]["Samples"].SelectNodes("Sample");
                if (sampleNodes == null || sampleNodes.Count == 0)
                {
                    message = "配置文件中没有试剂厂商信息！";
                    return false;
                }
                foreach (XmlNode node in sampleNodes)
                {
                    clsSTCheckSample sample = new clsSTCheckSample();
                    foreach (XmlNode xn in node.ChildNodes)
                    {
                        switch (xn.Name)
                        {
                            case "BatchNo": sample.BatchNo = xn.InnerText; break;
                            case "DeadLine": sample.DeadLine = xn.InnerText; break;
                            case "Company": sample.Company = xn.InnerText; break;
                            default:
                                break;
                        }
                    }
                    if (!string.IsNullOrEmpty(sample.BatchNo))
                    {
                        this.m_lstSamples.Add(sample);
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            return true;
        }

        private bool LoadTemplates(out string message)
        {
            message = string.Empty;
            if (!System.IO.File.Exists(TemplatePath))
            {
                message = "未找到配置文件.";
                return false;
            }

            System.Xml.XmlDocument xmlConfig = new System.Xml.XmlDocument();
            try
            {
                xmlConfig.Load(TemplatePath);
                XmlNodeList nodeList = xmlConfig["Templates"].SelectNodes("Template");
                foreach (XmlNode node in nodeList)
                {
                    string templateName = node.Attributes["name"].Value;
                    List<clsSTBoardItem> lstBoardItem = new List<clsSTBoardItem>();
                    foreach (XmlNode xn in node.ChildNodes)
                    {
                        if (xn.Name == "BoardItem")
                        {
                            clsSTBoardItem boardItem = new clsSTBoardItem();

                            int sampleNo = 0;
                            try { sampleNo = int.Parse(xn.Attributes["pos"].Value); }
                            catch { sampleNo = -1; }

                            int typeId = 0;
                            try { typeId = int.Parse(xn.Attributes["type"].Value); }
                            catch { typeId = 0; }

                            int sampleStyleNo = 0;
                            try { sampleStyleNo = int.Parse(xn.Attributes["SampleNo"].Value); }
                            catch { sampleStyleNo = 0; }

                            boardItem.Sequence = sampleNo;
                            boardItem.BoardStyle.SampleStyle = GetSampleType(typeId);
                            boardItem.BoardStyle.SampleStyleNo = sampleStyleNo;
                            if (boardItem.Sequence > 0)
                            {
                                lstBoardItem.Add(boardItem);
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(templateName) && lstBoardItem.Count > 0)
                    {
                        clsBoardTemplate template = new clsBoardTemplate(templateName, lstBoardItem);
                        m_lstTemplates.Add(template);
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            return true;
        }

        private bool LoadConstractRules(out string message) 
        {
            message = string.Empty;
            if (!System.IO.File.Exists(ItemPath))
            {
                message = "未找到配置文件.";
                return false;
            }

            System.Xml.XmlDocument xmlConfig = new System.Xml.XmlDocument();
            try
            {
                xmlConfig.Load(ItemPath);
                XmlNodeList nodeList = xmlConfig["Configs"]["ConstractValue"].SelectNodes("N");
                foreach (XmlNode node in nodeList)
                {
                    foreach (XmlNode xn in node.ChildNodes)
                    {
                        if (xn.Name == "Rule" && xn.Attributes["Used"].Value=="1")
                        {
                            clsSTConstractRule constractRule = new clsSTConstractRule();

                            if (xn.Attributes["BigerThan"].Value == "1")
                            {
                                constractRule.BiggerThan = true;
                            }
                            else { constractRule.BiggerThan = false; }


                            float referenceValue = 0;
                            try { referenceValue = float.Parse(xn.Attributes["Reference"].Value); }
                            catch { referenceValue = float.MinValue; }

                            float actualValue = 0;
                            try { actualValue = float.Parse(xn.Attributes["actual"].Value); }
                            catch { actualValue = float.MinValue; }

                            if (referenceValue!=float.MinValue &&actualValue!=float.MinValue)
                            {
                                constractRule.ReferenceValue = referenceValue;
                                constractRule.ActualValue = actualValue;
                                m_lstNegativeRules.Add(constractRule);
                            }
                        }
                    }
                }


                XmlNodeList nodePositiveList = xmlConfig["Configs"]["ConstractValue"].SelectNodes("P");
                foreach (XmlNode node in nodeList)
                {
                    foreach (XmlNode xn in node.ChildNodes)
                    {
                        if (xn.Name == "Rule" && xn.Attributes["Used"].Value == "1")
                        {
                            clsSTConstractRule constractRule = new clsSTConstractRule();

                            if (xn.Attributes["BigerThan"].Value == "1")
                            {
                                constractRule.BiggerThan = true;
                            }
                            else { constractRule.BiggerThan = false; }


                            float referenceValue = 0;
                            try { referenceValue = float.Parse(xn.Attributes["Reference"].Value); }
                            catch { referenceValue = float.MinValue; }

                            float actualValue = 0;
                            try { actualValue = float.Parse(xn.Attributes["actual"].Value); }
                            catch { actualValue = float.MinValue; }

                            if (referenceValue != float.MinValue && actualValue != float.MinValue)
                            {
                                constractRule.ReferenceValue = referenceValue;
                                constractRule.ActualValue = actualValue;
                                m_lstPositiveRules.Add(constractRule);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
            return true;
        }

        private List<clsSTConstractRule> LoadConnstractRules(XmlNode xmlElement) 
        {
            List<clsSTConstractRule> lstRules = new List<clsSTConstractRule>();
            foreach (XmlNode xn in xmlElement.ChildNodes)
            {
                if (xn.Name=="Rule")
                {
                    if (xn.Attributes["Used"].Value == "1")
                    {
                        clsSTConstractRule rule = new clsSTConstractRule();
                        if (xn.Attributes["type"].Value == "P")
                        {
                            rule.Positive = true;
                        }
                        else { rule.Positive = false; }

                        if (xn.Attributes["BigerThan"].Value == "1")
                        {
                            rule.BiggerThan = true;
                        }
                        else { rule.BiggerThan = false; }

                        if (xn.Attributes["Reference"].Value == "1")
                        {
                            rule.BiggerThan = true;
                        }
                        else { rule.BiggerThan = false; }


                        float referenceValue = 0;
                        try { referenceValue = float.Parse(xn.Attributes["Reference"].Value); }
                        catch { referenceValue = float.MinValue; }

                        float actualValue = 0;
                        try { actualValue = float.Parse(xn.Attributes["actual"].Value); }
                        catch { actualValue = float.MinValue; }

                        if (referenceValue != float.MinValue && actualValue != float.MinValue)
                        {
                            rule.ReferenceValue = referenceValue;
                            rule.ActualValue = actualValue;
                            lstRules.Add(rule);
                        }
                    }
                }
            }

            return lstRules;
        }
        #endregion

        #region 辅助方法

        private enmSTSampleStyle GetSampleType(int typeId)
        {
            enmSTSampleStyle result = enmSTSampleStyle.NONE;
            switch (typeId)
            {
                case 0: result = enmSTSampleStyle.NONE; break;
                case 1: result = enmSTSampleStyle.Common; break;
                case 2: result = enmSTSampleStyle.Blank; break;
                case 3: result = enmSTSampleStyle.Negative; break;
                case 4: result = enmSTSampleStyle.Positive; break;
                case 5: result = enmSTSampleStyle.Standard; break;
                case 6: result = enmSTSampleStyle.Quality; break;
                default:
                    break;
            }
            return result;
        }
        #endregion
    }
}
