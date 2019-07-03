using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml;
using System.Net;
using System.IO;

namespace CriticalValueService
{
    /// <summary>
    /// CriticalValueService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://dgcs.hospital.cn/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [SoapDocumentService(RoutingStyle = SoapServiceRoutingStyle.RequestElement)]
    public class Api : System.Web.Services.WebService
    {
        #region Register
        [WebMethod]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://dgcs.hospital.cn/Register", RequestNamespace = "http://dgcs.hospital.cn/", ResponseNamespace = "http://dgcs.hospital.cn/")]
        public string Register(string xmlIn)
        {
            Log.OutPut("PACS传入:\r\n" + xmlIn);
            string xmlOut = string.Empty;
            using (Biz biz = new Biz())
            {
                xmlOut = biz.Register(xmlIn);
            }
            Log.OutPut("医院返回:\r\n" + xmlOut);
            return xmlOut;
        }
        #endregion

        #region Notice
        [WebMethod]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://dgcs.hospital.cn/Notice", RequestNamespace = "http://dgcs.hospital.cn/", ResponseNamespace = "http://dgcs.hospital.cn/")]
        public void Notice(string xmlIn)
        {
            Log.OutPut("PACS传入:\r\n" + xmlIn);
            string xmlData = string.Empty;
            using (Biz biz = new Biz())
            {
                try
                {
                    string pid = string.Empty;
                    string WechatWebUrl = string.Empty;
                    Dictionary<string, string> dicKey = biz.ReadXmlNodes(xmlIn, "Request");
                    if (biz.GetNoticeParm(dicKey["cardNo"], out pid, out WechatWebUrl))
                    {
                        xmlData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
                        xmlData += "<req>" + Environment.NewLine;
                        xmlData += string.Format("<eventNo>{0}</eventNo>", "41332004415") + Environment.NewLine;
                        xmlData += string.Format("<eventType>{0}</eventType>", "pacsReportCompleted") + Environment.NewLine;
                        xmlData += "<eventData>" + Environment.NewLine;
                        xmlData += string.Format("<healthCardNo>{0}</healthCardNo>", dicKey["cardNo"]) + Environment.NewLine;
                        xmlData += string.Format("<patientId>{0}</patientId>", pid) + Environment.NewLine;
                        xmlData += string.Format("<inpatientId>{0}</inpatientId>", "") + Environment.NewLine;
                        xmlData += string.Format("<clinicSeq>{0}</clinicSeq>", pid + DateTime.Now.ToString("yyyyMMdd")) + Environment.NewLine;
                        xmlData += string.Format("<exameDate>{0}</exameDate>", dicKey["exameDate"]) + Environment.NewLine;
                        xmlData += string.Format("<reportDate>{0}</reportDate>", dicKey["reportDate"]) + Environment.NewLine;
                        xmlData += string.Format("<reportId>{0}</reportId>", dicKey["reportId"]) + Environment.NewLine;
                        xmlData += string.Format("<reportTitle>{0}</reportTitle>", dicKey["reportTitle"]) + Environment.NewLine;
                        xmlData += "</eventData>" + Environment.NewLine;
                        xmlData += "</req>" + Environment.NewLine;

                        byte[] dataArray = System.Text.Encoding.Default.GetBytes(xmlData);
                        //创建请求
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(WechatWebUrl);
                        request.Method = "POST";
                        request.ContentLength = dataArray.Length;
                        //创建输入流
                        Stream dataStream = null;
                        try
                        {
                            dataStream = request.GetRequestStream();
                        }
                        catch
                        {
                        }
                        //发送请求
                        dataStream.Write(dataArray, 0, dataArray.Length);
                        dataStream.Close();
                    }
                    else
                    {
                        Log.OutPut("不满足微信通知条件");
                    }
                }
                catch (Exception ex)
                {
                    Log.OutPut(ex.Message);
                }
            }
            Log.OutPut("医院返回:\r\n" + xmlData);
        }
        #endregion

        #region PACS.Itf
        /// <summary>
        /// PACS申请单接口服务
        /// </summary>
        /// <param name="xmlIn"></param>
        /// <returns></returns>
        [WebMethod]
        [SoapRpcMethod(Use = SoapBindingUse.Literal, Action = "http://dgcs.hospital.cn/PacsApplication", RequestNamespace = "http://dgcs.hospital.cn/", ResponseNamespace = "http://dgcs.hospital.cn/")]
        public string PacsApplication(string xmlIn)
        {
            Log.OutPut("PACS传入:\r\n" + xmlIn);
            string xmlOut = string.Empty;
            using (Biz biz = new Biz())
            {
                xmlOut = biz.PacsApp(xmlIn);
            }
            Log.OutPut("医院返回:\r\n" + xmlOut);
            return xmlOut;
        }
        #endregion
         
    }
}
