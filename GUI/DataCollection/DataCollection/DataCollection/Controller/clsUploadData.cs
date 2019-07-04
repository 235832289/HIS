using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data;
using System.IO;
using System.Xml;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public class clsUploadData
    {
        /// <summary>
        /// LOG文件路径
        /// </summary>
        private string LogFilepath = @"d:\code\log.txt";

        /// <summary>
        /// LOG文件正常标题
        /// </summary>
        private string LogNortitle = "Function Called in lngExecuteSQL \r\n";

        /// <summary>
        /// LOG文件异常标题
        /// </summary>
        private string LogExctitle = "Exception Detail  \r\n";

        public clsUploadData()
        {
            //this.m_strHospitalID = m_strReadXML("DONGGUAN.CHASHANCommunity", "CSHospitalNO", "AnyOne");
            this.m_strHospitalID = clsPublic.m_strConvertValue("DSN", "hospitalcode", "457226325");
        }

        public long m_lngUploadDataTest(List<string> p_glsSQL)
        {
            clsLogText log = new clsLogText();
            int intLen = p_glsSQL.Count;
            for (int i = 0; i < intLen; i++)
            {
                log.Log2File(LogFilepath, LogNortitle + p_glsSQL[i].ToString());
            }
            return 1;
        }

        public long m_lngUploadData(List<string> p_glsSQL)
        {
            long lngRes=-1;
            //OracleConnection conn = new OracleConnection(this.m_strGetDBConnetionString());
            OracleConnection conn = new OracleConnection(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc.m_strGetDbConnection());
            
            OracleCommand oraCmd = conn.CreateCommand();  
            OracleTransaction oraTran = null;
            clsLogText log = new clsLogText();

            try
            {
                conn.Open();
                oraTran = conn.BeginTransaction();
                oraCmd.Transaction = oraTran;  
                int intLen = p_glsSQL.Count;
                for (int i = 0; i < intLen; i++)
                {
                    log.Log2File(LogFilepath, LogNortitle + p_glsSQL[i].ToString());
                    oraCmd.CommandTimeout = 30000;
                    oraCmd.CommandText = p_glsSQL[i].ToString();
                    lngRes = oraCmd.ExecuteNonQuery();
                    
                    if (lngRes < 1)
                    {
                        p_glsSQL = null;
                        oraTran.Rollback();
                        conn.Close();
                        conn.Dispose();
                        return lngRes;
                    }
                    System.Threading.Thread.Sleep(100);
                }
                oraTran.Commit();
            }
            catch (Exception Exp)
            {
                log.Log2File(LogFilepath, LogExctitle + Exp.Message);
                oraTran.Rollback();
                MessageBox.Show(Exp.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return lngRes;
        }

        private const string XMLFile = "HISYB.xml";
        private string m_strHospitalID = string.Empty;

        private string m_strGetDBConnetionString()
        {
            string DNS = m_strReadXML("DONGGUAN.CHASHANCommunity", "OraDSN ", "AnyOne");
            string User = m_strReadXML("DONGGUAN.CHASHANCommunity", "OraUserID", "AnyOne");
            string Psw = m_strReadXML("DONGGUAN.CHASHANCommunity", "OraPassWord", "AnyOne");

            return "Data Source =" + DNS + ";User ID=" + User + ";Password=" + Psw;
        }

        #region HisYB.XML读写操作
        /// <summary>
        /// 读操作
        /// </summary>
        /// <param name="parentnode"></param>
        /// <param name="childnode"></param>
        /// <param name="key"></param>
        public static string m_strReadXML(string parentnode, string childnode, string key)
        {
            string strRet ="";

            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);

                    XmlNode xndP = xdoc.DocumentElement.SelectNodes(@"//" + parentnode)[0];
                    XmlNode xndC = xndP.SelectSingleNode(@"//" + childnode + @"[@key='" + key + @"']");

                    if (xndP != null)
                    {
                        strRet = xndC.Attributes["value"].Value.ToString().Trim();
                    }
                }
            }
            catch
            {
                strRet = "";
            }
            return strRet;
        }
        #endregion 
    }
}