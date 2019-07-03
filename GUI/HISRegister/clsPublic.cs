using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Threading;
using System.Text.RegularExpressions;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsMZPublic
    {
        #region 将对象转换为数字
        /// <summary>
        /// 将对象转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return Convert.ToDecimal(obj.ToString());

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        #endregion

        #region 将数值四舍五入
        /// <summary>
        /// 将数值四舍五入
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        public static decimal Round(decimal d, int decimals)
        {
            try
            {
                if (decimals < 1)
                {
                    return Convert.ToDecimal(Convert.ToInt32(d));
                }
                else
                {
                    string s = "0.";
                    for (int i = 0; i < decimals; i++)
                    {
                        s += "0";
                    }
                    return Convert.ToDecimal(d.ToString(s));
                }
            }
            catch
            {
                return d;
            }
        }
        #endregion               
        
    }
}
