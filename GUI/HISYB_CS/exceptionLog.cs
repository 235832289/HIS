using System;
using System.Diagnostics;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    public class ExceptionLog
    {
        public static void OutPutException(System.Exception e)
        {
            OutPutException(e.Message);
            Debug.WriteLine("程序运行异常: " + e.Message);
            throw e;
        }

        /// <summary>
        /// 写SQL
        /// </summary>
        /// <param name="p_strText"></param>
        /// <returns></returns>
        public static void OutPutException(string ex)
        {
            string strDate = DateTime.Now.ToString("yyyy-MM-dd");
            string strTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\exception\" + strDate + ".txt";

            bool blnAllWaysNew = false;
            StreamWriter sw = null;
            try
            {
                FileInfo fi = new FileInfo(strFile);
                if (fi.Exists)
                {
                    if (fi.Length >= 2000000)
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
                sw.WriteLine(ex);
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

    }
}
