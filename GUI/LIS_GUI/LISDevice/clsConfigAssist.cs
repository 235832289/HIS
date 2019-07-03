using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.LIS
{
    internal class clsConfigAssist
    {
        private const string ItemPath = @".\LIS_DataAnalyse\ST360\CheckItems.config";
        private const string TemplatePath = @".\LIS_DataAnalyse\ST360\Templates.config";

        public void AddTemplate(string templateName,List<clsSTBoardItem> lstBoardItem,out string message)
        {
            message = string.Empty;

            XmlDocument xmlDoc = new XmlDocument();
            if (!System.IO.File.Exists(TemplatePath))
            {
                System.IO.File.Create(ItemPath);
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "", "");
                xmlDoc.AppendChild(xmlDeclaration);

                XmlElement xmlElement = xmlDoc.CreateElement("Templates");
                xmlDoc.AppendChild(xmlElement);
                xmlDoc.Save(TemplatePath);
            }

            try
            {
                xmlDoc.Load(TemplatePath);
                XmlNode root = xmlDoc.SelectSingleNode("Templates");

                XmlElement xmlTemplate = xmlDoc.CreateElement("Template");
                xmlTemplate.SetAttribute("name", templateName);
                root.AppendChild(xmlTemplate);

                foreach (clsSTBoardItem boardItem in lstBoardItem)
                {
                    XmlElement xmlBoardItem = xmlDoc.CreateElement("BoardItem");
                    xmlBoardItem.SetAttribute("pos",boardItem.Sequence.ToString());
                    xmlBoardItem.SetAttribute("type",((int)boardItem.BoardStyle.SampleStyle).ToString());
                    xmlBoardItem.SetAttribute("SampleNo", boardItem.BoardStyle.SampleStyleNo.ToString());
                    xmlTemplate.AppendChild(xmlBoardItem);
                }

                xmlDoc.Save(TemplatePath);
            }
            catch (Exception ex)
            {
                message = ex.Message;
                new clsLogText().LogError(ex.Message);
            }
        }
    }
}
