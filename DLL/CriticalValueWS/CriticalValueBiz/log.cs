using System;
using System.Diagnostics;
using System.IO;

namespace CriticalValueService
{
    public class Log
    {
        public static void OutPut(string txt)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\log\" + strDate + ".txt";
            bool blnAllWaysNew = false;
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(strFile);
                if (fi.Exists)
                {
                    if (fi.Length >= 8000000)
                    {
                        sw = fi.CreateText();
                    }
                    else
                    {
                        if (blnAllWaysNew)
                        {
                            sw = fi.CreateText();
                        }
                        else
                        {
                            sw = fi.AppendText();
                        }
                    }
                }
                else
                {
                    if (!Directory.Exists(fi.DirectoryName))
                    {
                        Directory.CreateDirectory(fi.DirectoryName);
                    }
                    sw = fi.CreateText();
                }
                sw.WriteLine("-->>>>> " + strTime);
                sw.WriteLine(txt);
                sw.WriteLine();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        #region 输出SQL.参数 日志
        /// <summary>
        /// 输出SQL.参数 日志
        /// </summary>
        /// <param name="_parms"></param>
        public static void OutPutParm(params System.Data.IDataParameter[] _parms)
        {
            if (_parms == null) return;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < _parms.Length; i++)
            {
                sb.Append(Convert.ToString(i + 1));
                sb.Append(":= ");
                sb.Append(_parms[i].Value.ToString());
                sb.Append("; ");
            }

            Log.OutPut("values: " + sb.ToString());
        }
        #endregion

    }
}
