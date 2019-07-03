using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using Barcode;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.LIS
{
   
    #region ListView比较排序类


    /// <summary>
    /// ListView比较排序类

    /// </summary>
    internal class ListViewItemComparer : IComparer
    {
        private int col;
        private bool IsAsc = false; //是否为升序

        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column, bool IsAsc, ListView objListView)
        {
            string strColTxt = "";
            for (int i = 0; i < objListView.Columns.Count; i++)
            {
                strColTxt = objListView.Columns[i].Text;
                //↓↑
                strColTxt = strColTxt.Replace(" ↑", "");
                strColTxt = strColTxt.Replace(" ↓", "");
                objListView.Columns[i].Text = strColTxt;
            }

            col = column;
            this.IsAsc = IsAsc;
            strColTxt = objListView.Columns[col].Text;
            if (IsAsc == true)//如果是升序

                objListView.Columns[col].Text = strColTxt + " ↑";
            else
                objListView.Columns[col].Text = strColTxt + " ↓";
        }
        //不出现箭头

        public ListViewItemComparer(int column, bool IsAsc)
        {
            col = column;
            this.IsAsc = IsAsc;
        }

        // created by Sam
        // modify by Cameron Wong on Aug 13, 2004
        // there is a bug in the origional version!
        public int Compare(object x, object y)
        {
            int i = 0;
            i = String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

            // the following line is added by Cameron Wong on Aug 13, 2004
            if (!IsAsc) i = -i;
            #region 不用的
            /* commented by Cameron Wong on Aug 13, 2004
 
                        if(i>0)//strA大于strB
                        {
                            if(IsAsc==true)//如果是升序

                                i=1;
                            else
                                i=-1;
                        }
                        if(i<0)//strA小于strB
                        {
                            if(IsAsc==true)//如果是升序

                                i=-1;
                            else
                                i=1;
                        }
                        else //相等
                        {
                            i=0;
                        }
            */
            #endregion
            return i;
        }
    }
    

    #endregion

    #region 提供各种自定义转换的类

    /// <summary>
    /// 提供各种自定义转换的类

    /// </summary>
    public class clsLIS_Converter
    {
        #region 将原始字串根据自定义的规则转换为用户友好的字串形式

        /// <summary>
        /// 将原始字串根据自定义的规则转换为用户友好的字串形式。

        /// </summary>
        /// <param name="p_strOriginal">要转换的字串</param>
        /// <returns>
        /// 如果 p_strOriginal 为 null 则返回 null;
        /// 如果 在转换过程中出现异常，则返回 null;
        /// 如果 p_strOriginal 不在规则定义中 则返回 p_strOriginal;
        /// 如果 p_strOriginal 在规则定义中且转换成功，则返回转换后的结果；
        /// </returns>
        public static string s_strConvertToFriendlyString(string p_strOriginal)
        {
            if (p_strOriginal == null)
                return null;

            string strOriginal = p_strOriginal.ToLower();
            string strRet = null;
            try
            {
                #region 转换
                switch (strOriginal)
                {
                    case "positive":
                        strRet = "阳性";
                        break;
                    case "pos":
                        strRet = "阳性";
                        break;
                    case "neg":
                        strRet = "阴性";
                        break;
                    case "negative":
                        strRet = "阴性";
                        break;
                    case "norm":
                        strRet = "正常";
                        break;
                    case "normal":
                        strRet = "正常";
                        break;


                    case "trace":
                        strRet = "微量";
                        break;
                    case "small":
                        strRet = "少量";
                        break;
                    case "modera":
                        strRet = "中量";
                        break;
                    case "large":
                        strRet = "大量";
                        break;

                    case "moderate":
                        strRet = "中量";
                        break;
                    default:
                        strRet = p_strOriginal;
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                strRet = null;
                new com.digitalwave.Utility.clsLogText().LogError(ex);
            }
            return strRet;
        }
        #endregion xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
    }
    #endregion

    #region 封装参考值的类

    /// <summary>
    /// 封装参考值的类

    /// </summary>
    public class clsReferenceValue
    {
        private object m_objMinValue = null;
        private object m_objMaxValue = null;
        private object m_objRefValue = null;
        private string m_strRefRange = "";
        private bool m_blnIsSingleType = false;

        public bool m_BlnIsSingleType
        {
            get { return m_blnIsSingleType; }
        }
        public object m_ObjRefValue
        {
            get { return m_objRefValue; }
            set
            {
                m_objRefValue = value;
                if (m_objRefValue == null)
                {
                    m_blnIsSingleType = false;
                }
                else
                {
                    m_blnIsSingleType = true;
                }
                m_mthSetRefRamge();
            }
        }
        public object m_ObjMinValue
        {
            get { return m_objMinValue; }
            set
            {
                m_objMinValue = value;
                m_mthSetRefRamge();
            }
        }
        public object m_ObjMaxValue
        {
            get { return m_objMaxValue; }
            set
            {
                m_objMaxValue = value;
                m_mthSetRefRamge();
            }
        }
        public string m_StrRefRange
        {
            set { m_strRefRange = value; }
            get { return m_strRefRange; }
        }
        public override string ToString()
        {
            return m_strRefRange;
        }


        public clsReferenceValue() { }
        public clsReferenceValue(object objRefValue)
        {
            this.m_ObjRefValue = objRefValue;
        }
        public clsReferenceValue(object objMinValue, object objMaxValue)
        {
            m_ObjMinValue = objMinValue;
            m_ObjMaxValue = objMaxValue;
        }
        private void m_mthSetRefRamge()
        {
            if (m_blnIsSingleType)
            {
                m_strRefRange = m_objRefValue.ToString();
            }
            else
            {
                if ((m_objMinValue == null || m_objMinValue.ToString() == "") && m_objMaxValue != null && m_objMaxValue.ToString() != "")
                {
                    m_strRefRange = "<" + m_objMaxValue.ToString();
                }
                else if (m_objMinValue != null && m_objMinValue.ToString() != "" && (m_objMaxValue == null || m_objMaxValue.ToString() == ""))
                {
                    m_strRefRange = ">" + m_objMinValue.ToString();
                }
                else if (m_objMinValue != null && m_objMinValue.ToString() != "" && m_objMaxValue != null && m_objMaxValue.ToString() != "")
                {
                    m_strRefRange = m_objMinValue.ToString() + "-" + m_objMaxValue.ToString();
                }
                else
                {
                    m_strRefRange = "";
                }
            }
        }
    }
    #endregion

    #region 封装年龄的类
    /// <summary>
    /// 封装年龄的类
    /// </summary>
    public class clsAgeConverter
    {
        /// <summary>
        /// 根据生日和当前系统时间计算出实际年龄（注：每个月以30天为基准）
        /// </summary>
        /// <param name="p_dtmBirth">生日</param>
        /// <param name="strFormating">格式化字串如"/y|/m|/d" 或 " 岁| 月| 天" </param>
        /// <returns>
        /// 大于366天的以年为单位"/y"，
        /// 大于等于30天的以月为单位"/m"，
        /// 小于30天的以天为单位"/d",
        /// 返回“0”，如果生日大于等于现在的系统时间
        /// </returns>
        public static string s_strToAge(DateTime p_dtmBirth, string strFormating)
        {
            if (p_dtmBirth >= DateTime.Now)
                return "0";
            string strAge = null;

            string[] strUnitArr = s_strGetUnit(strFormating);
            string strYear = strUnitArr[0];
            string strMonth = strUnitArr[1];
            string strDay = strUnitArr[2];
            TimeSpan tspAge = DateTime.Now - p_dtmBirth;
            if (tspAge.Days < 30)
            {
                if (tspAge.Days == 0)
                {
                    strAge = "1" + strDay;
                }
                else
                {
                    strAge = tspAge.Days.ToString() + strDay;
                }
            }
            else if (tspAge.Days <= 366)
            {
                strAge = ((int)(tspAge.Days / 30)).ToString() + strMonth;
            }
            else
            {
                strAge = ((int)(DateTime.Now.Year - p_dtmBirth.Year)).ToString() + strYear;
            }
            return strAge;
        }
        /// <summary>
        /// 根据生日和当前系统时间计算出实际年龄（注：每个月以30天为基准）

        /// </summary>
        /// <param name="p_dtmBirth">生日</param>
        /// <returns>
        /// 大于366天的以年为单位"/y"，

        /// 大于等于30天的以月为单位"/m"，

        /// 小于30天的以天为单位"/d",
        /// 返回“0”，如果生日大于等于现在的系统时间

        /// </returns>
        public static string s_strToAge(DateTime p_dtmBirth)
        {

            return s_strToAge(p_dtmBirth, "/y|/m|/d");
        }
        /// <summary>
        /// 根据复合年龄字串得到年龄大小
        /// </summary>
        /// <param name="strAge"></param>
        /// <returns>
        /// null:非法的复合年龄字串
        /// </returns>
        public static string m_strGetAgeNum(string strAge)
        {

            try
            {
                int intAgeNum = 0;
                int idx = 0;
                if (strAge.Contains("岁"))
                {
                    idx = strAge.IndexOf("岁");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    return strAge.Substring(0, idx).Trim();
                }
                else if (strAge.Contains("月"))
                {
                    idx = strAge.IndexOf("月");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    return strAge.Substring(0, idx).Trim();

                }
                else if (strAge.Contains("天"))
                {
                    idx = strAge.IndexOf("天");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    return strAge.Substring(0, idx).Trim();

                }
                else if (strAge.Contains("小时"))
                {
                    idx = strAge.IndexOf("小时");
                    intAgeNum = Convert.ToInt32(strAge.Substring(0, idx).Trim());
                    return strAge.Substring(0, idx).Trim();

                }

            }
            catch
            {

            }

            //string[] strArr = strAge.Split(new char[] { ' ' });
            //if (strArr != null && strArr.Length == 2 && Microsoft.VisualBasic.Information.IsNumeric(strArr[0]))
            //{
            //    return strArr[0];
            //}


            return null;
        }
        /// <summary>
        /// 根据复合年龄字串得到年龄单位
        /// </summary>
        /// <param name="strAge"></param>
        /// <returns>
        /// null:非法的复合年龄字串
        /// </returns>
        public static string m_strGetAgeUnit(string strAge)
        {
            try
            {
                if (strAge.Contains("岁"))
                {
                    return "岁";
                }
                else if (strAge.Contains("月"))
                {
                    return "月";
                }
                else if (strAge.Contains("天"))
                {
                    return "天";
                }
                else if (strAge.Contains("小时"))
                {
                    return "小时";
                }
                else
                {
                    return "天";
                }
            }
            catch
            {
            }
            return null;
        }

        #region 年龄转换
        /// <summary>
        /// * 表示为* 岁 比如: 23 = 23 岁
        /// *岁*月 表示为* 岁 比如:10岁5月 = 10 岁
        /// *月*天 表示为* 月 比如:3月15天 = 3 月
        /// *天*小时 表示为* 天 比如:15天6小时 = 15 天
        /// *小时*分钟 表示为* 小时 比如:6小时30分钟 = 6 小时
        /// </summary>
        /// <param name="p_strAge"></param>
        /// <returns></returns>
        public static string m_strAgeToAge(string p_strAge)
        {
            string strRes = "";
            if (string.IsNullOrEmpty(p_strAge))
                return strRes;

            string strYear = "岁";
            string strMonth = "月";
            string strDay = "天";
            string strHour = "小时";

            int idxUnit = 0;

            bool blnIsNum = int.TryParse(p_strAge, out idxUnit);
            if (blnIsNum && idxUnit > 0)
            {
                strRes = p_strAge + " " + strYear;
                return strRes;
            }

            try
            {
                if (p_strAge.Contains(strYear))
                {
                    idxUnit = p_strAge.IndexOf(strYear);
                    if (idxUnit <= 0)
                        return p_strAge;

                    strRes = p_strAge.Substring(0, idxUnit).Trim();
                    if (string.IsNullOrEmpty(strRes))
                        return p_strAge;

                    strRes += " " + strYear;
                    return strRes;
                }
                else if (p_strAge.Contains(strMonth))
                {
                    idxUnit = p_strAge.IndexOf(strMonth);
                    if (idxUnit <= 0)
                        return p_strAge;

                    strRes = p_strAge.Substring(0, idxUnit).Trim();
                    if (string.IsNullOrEmpty(strRes))
                        return p_strAge;

                    strRes += " " + strMonth;
                    return strRes;
                }
                else if (p_strAge.Contains(strDay))
                {
                    idxUnit = p_strAge.IndexOf(strDay);
                    if (idxUnit <= 0)
                        return p_strAge;

                    strRes = p_strAge.Substring(0, idxUnit).Trim();
                    if (string.IsNullOrEmpty(strRes))
                        return p_strAge;

                    strRes += " " + strDay;
                    return strRes;
                }
                else if (p_strAge.Contains(strHour))
                {
                    idxUnit = p_strAge.IndexOf(strHour);
                    if (idxUnit <= 0)
                        return p_strAge;

                    strRes = p_strAge.Substring(0, idxUnit).Trim();
                    if (string.IsNullOrEmpty(strRes))
                        return p_strAge;

                    strRes += " " + strHour;
                    return strRes;
                }
                else
                {
                    strRes = "1 " + strHour;
                    return strRes;
                }
            }
            catch (Exception objEx)
            {
                strRes = p_strAge;
            }
            return strRes;
        } 
        #endregion

        private static string[] s_strGetUnit(string strFormating)
        {
            string[] strUnitArr = strFormating.Split(new char[] { '|' });
            if (strUnitArr == null || strUnitArr.Length != 3)
                strUnitArr = new string[] { "/y", "/m", "/d" };
            return strUnitArr;
        }

        // add zhu.w.t 2007.4.23
        /// <summary>
        /// 根据生日计算出实际年龄(婴儿可精确到分钟)
        /// </summary>
        /// <param name="datBirth">出生时间</param>
        /// <returns></returns>
        public static string s_strGetAge(DateTime datBirth)
        {
            DateTime datNow = DateTime.Now;
            string strResult = "";
            int years = datNow.Year - datBirth.Year;
            int months = datNow.Month - datBirth.Month;
            int days = datNow.Day - datBirth.Day;
            int hours = datNow.Hour - datBirth.Hour;
            int minutes  = datNow.Minute - datBirth.Minute;

            TimeSpan compare = datNow.Date - datBirth.Date;
            //int hours = (int)(compare.TotalHours) % 24;
            //int minutes = (int)compare.TotalMinutes % 60;

            if (minutes < 0)
            {
                hours--;
                minutes += 60;
            }

            if (hours < 0)
            {
                days--;
                hours += 24;
            }

            if (days < 0)
            {
                months--;
                days += 30;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            if (years >= 15)
            {
                strResult = years.ToString() + "岁";
            }
            else if (years >= 1)
            {
                    strResult = years.ToString() + "岁" + months.ToString() + "月";
            }
            else if (months >= 1)
            {
                    strResult = months.ToString() + "月" + days.ToString() + "天";
            }
            else if (days >= 1)
            {
                    strResult = compare.Days.ToString() + "天" + hours.ToString() + "小时";
            }
            else if (hours >= 1)
            {
                    strResult = hours.ToString() + "小时" + minutes.ToString() + "分钟";
            }
            else
                strResult = minutes.ToString() + "分钟";

            return strResult;
        }
    }
    #endregion

    #region 检验编号解析器
    public class clsCheckNODecoder
    {
         /* ===============================================================================
         * CheckNO:检验编号;
         * SampleCode:包含在 CheckNO 中的代表仪器样本的信息,其中包含仪器代号和仪器样本号;
         * DeviceCode: 仪器代号
         * DRVO: 即 DeviceRelation_VO,用于存放从 SampleCode 中解析出来的仪器ID和仪器样本号;
         * lngRes 返回值,只有为 1 是表示成功

         * ===============================================================================
         */

        #region 私有成员

        private System.Collections.Hashtable m_hasDeviceCode = new System.Collections.Hashtable();
        private bool m_blnIsSampleCodeSeparator;
        private bool m_blnIsDeviceCodeSeparator;
        private string m_strSampleCodeSeparator = "";
        private string m_strDeviceCodeSeparator = "";
        private int m_intSampleCodeLength;
        private int m_intDeviceCodeLength;
        private int m_intDeviceSampleIDLength;
        
        #endregion

        #region 构造函数

        public clsCheckNODecoder()
        {
            m_mthLoadCodeRule();
            m_mthLoadDeviceCode();
        }
        #endregion

        public void m_mthGetNextCheckNO(string p_strCurrCheckNO, out string p_strNextCheckNO)
        {
            p_strNextCheckNO = null;
            if (!m_blnIsRegularCheckNO(p_strCurrCheckNO))
            {
                return;
            }
            string[] strSampleCodes = null;
            m_lngGetSampleCodes(p_strCurrCheckNO, out strSampleCodes);
            if (strSampleCodes != null)
            {
                for (int i = 0; i < strSampleCodes.Length; i++)
                {
                    string strNextSampleCode = null;
                    string strDeviceCode = null;
                    string strSampleID = null;
                    string strNextSampleID = null;

                    m_lngGetDeviceCodeAndSampleIDFromSampleCode(strSampleCodes[i], out strDeviceCode, out strSampleID);
                    strNextSampleID = m_strGetNextNO(strSampleID);
                    if (m_blnIsDeviceCodeSeparator)
                    {
                        strNextSampleCode = strDeviceCode + m_strDeviceCodeSeparator + strSampleID;
                    }
                    else
                    {
                        strNextSampleCode = strDeviceCode + strNextSampleID;
                    }
                    if (p_strNextCheckNO != null && p_strNextCheckNO.Trim() != "")
                    {
                        if (m_blnIsSampleCodeSeparator)
                        {
                            p_strNextCheckNO = p_strNextCheckNO + m_strSampleCodeSeparator + strNextSampleCode;
                        }
                        else
                        {
                            p_strNextCheckNO = p_strNextCheckNO + strNextSampleCode;
                        }
                    }
                    else
                    {
                        p_strNextCheckNO = strNextSampleCode;
                    }
                }
            }
        }

        public bool m_blnIsRegularDeviceCode(string p_strDeviceCode)
        {
            if (this.m_hasDeviceCode.Contains(p_strDeviceCode))
            {
                return true;
            }
            return false;
        }

        public long m_lngDecodeDeviceCode(string p_strDeviceCode, out string p_strDeviceID)
        {
            p_strDeviceID = null;
            try
            {
                if (this.m_hasDeviceCode.Contains(p_strDeviceCode))
                {
                    p_strDeviceID = this.m_hasDeviceCode[p_strDeviceCode].ToString().Trim();
                    return 1;
                }
            }
            catch
            {
                return 0;
            }
            return -1;
        }

        public bool m_blnIsRegularSampleCode(string p_strSampleCode)
        {
            clsT_LIS_DeviceRelationVO objDRVO = null;
            long lngRes = this.m_lngGetDRVOFromSampleCode(p_strSampleCode, out objDRVO);
            if (lngRes == 1)
                return true;
            else
                return false;
        }

        public bool m_blnIsRegularCheckNO(string p_strCheckNO)
        {
            clsT_LIS_DeviceRelationVO[] objDRVOArr = null;
            long lngRes = this.m_lngDecode(p_strCheckNO, out objDRVOArr);
            if (lngRes == 1)
                return true;
            else
                return false;
        }

        public long m_lngDecode(string p_strCheckNO, out clsT_LIS_DeviceRelationVO[] p_objDRVOArr)
        {
            System.Collections.Hashtable hasDevices = new System.Collections.Hashtable();
            p_objDRVOArr = null;
            System.Collections.ArrayList arlTemp = new System.Collections.ArrayList();
            string[] strSampleCodeArr = null;
            long lngRes = m_lngGetSampleCodes(p_strCheckNO, out strSampleCodeArr);
            if (lngRes == 1 && strSampleCodeArr != null)
            {
                for (int i = 0; i < strSampleCodeArr.Length; i++)//循环解析每个 SampleCode 
                {
                    clsT_LIS_DeviceRelationVO objDRVO = null;
                    lngRes = -1;
                    lngRes = m_lngGetDRVOFromSampleCode(strSampleCodeArr[i], out objDRVO);
                    if (lngRes == 1 && objDRVO != null)
                    {
                        arlTemp.Add(objDRVO);
                        if (hasDevices.ContainsKey(objDRVO.m_strDEVICEID_CHR))
                        {
                            lngRes = -2;//重复仪器
                            break;
                        }
                        hasDevices.Add(objDRVO.m_strDEVICEID_CHR, null);
                    }
                    else if (lngRes != 1)
                    {
                        break;
                    }
                }
                if (arlTemp.Count != 0)
                {
                    p_objDRVOArr = (clsT_LIS_DeviceRelationVO[])arlTemp.ToArray(typeof(clsT_LIS_DeviceRelationVO));
                }
            }
            if (lngRes != 1)
            {
                p_objDRVOArr = null;
            }
            return lngRes;
        }

        public long m_lngGetSampleCodes(string p_strCheckNO, out string[] p_strSampleCodeArr)
        {
            p_strSampleCodeArr = null;
            if (p_strCheckNO == null)
                return -1;

            long lngRes = -1;
            if (m_blnIsSampleCodeSeparator)
            {
                try
                {
                    p_strSampleCodeArr = p_strCheckNO.Split(m_strSampleCodeSeparator.ToCharArray());
                    System.Collections.ArrayList arl = new System.Collections.ArrayList();
                    for (int i = 0; i < p_strSampleCodeArr.Length; i++)
                    {
                        if (p_strSampleCodeArr[i] != null && p_strSampleCodeArr[i] != "")
                        {
                            arl.Add(p_strSampleCodeArr[i]);
                        }
                    }
                    arl.TrimToSize();
                    p_strSampleCodeArr = (string[])arl.ToArray(typeof(string));

                    lngRes = 1;
                }
                catch (Exception ex)
                {
                    lngRes = 0;
                    p_strSampleCodeArr = null;
                }
            }
            else
            {
                try
                {
                    int intCehckNOLength = p_strCheckNO.Length;
                    if (System.Math.IEEERemainder(intCehckNOLength, m_intSampleCodeLength) != 0)
                        return -1;
                    int intCount = intCehckNOLength / m_intSampleCodeLength;
                    p_strSampleCodeArr = new string[intCount];
                    for (int i = 0; i < intCount; i++)
                    {
                        p_strSampleCodeArr[i] = p_strCheckNO.Substring(i * m_intSampleCodeLength, m_intSampleCodeLength);
                    }
                    lngRes = 1;
                }
                catch (Exception ex)
                {
                    lngRes = 0;
                    p_strSampleCodeArr = null;
                }
            }
            return lngRes;
        }

        public long m_lngGetDRVOFromSampleCode(string p_strSampleCode, out clsT_LIS_DeviceRelationVO p_objDRVO)
        {
            p_objDRVO = null;
            if (p_strSampleCode == null)
                return -1;

            long lngRes = -1;
            if (m_blnIsDeviceCodeSeparator)
            {
                try
                {
                    string[] strCodeArr = p_strSampleCode.Split(m_strDeviceCodeSeparator.ToCharArray());
                    if (strCodeArr == null || strCodeArr.Length != 2)
                        return -1;
                    string strDeviceID = null;
                    object objValue = m_hasDeviceCode[strCodeArr[0]];
                    if (objValue != null)
                    {
                        strDeviceID = objValue.ToString();
                    }

                    if (strDeviceID != null)
                    {
                        p_objDRVO = new clsT_LIS_DeviceRelationVO();
                        p_objDRVO.m_strDEVICEID_CHR = strDeviceID;
                        p_objDRVO.m_strDEVICE_SAMPLEID_CHR = strCodeArr[1];
                    }
                    lngRes = 1;
                }
                catch (Exception ex)
                {
                    lngRes = 0;
                    p_objDRVO = null;
                }
            }
            else
            {
                try
                {
                    if (p_strSampleCode.Length < m_intDeviceCodeLength)
                    {
                        return -1;
                    }
                    string strDeviceCode = p_strSampleCode.Substring(0, m_intDeviceCodeLength);
                    string strDeviceSampleID = p_strSampleCode.Substring(m_intDeviceCodeLength, p_strSampleCode.Length - m_intDeviceCodeLength);
                    object objValue = m_hasDeviceCode[strDeviceCode];
                    string strDeviceID = null;
                    if (objValue != null)
                    {
                        strDeviceID = objValue.ToString();
                    }
                    if (strDeviceID != null)
                    {
                        p_objDRVO = new clsT_LIS_DeviceRelationVO();
                        p_objDRVO.m_strDEVICEID_CHR = strDeviceID;
                        p_objDRVO.m_strDEVICE_SAMPLEID_CHR = strDeviceSampleID;
                    }
                    lngRes = 1;
                }
                catch (Exception ex)
                {
                    lngRes = 0;
                    p_objDRVO = null;
                }
            }
            return lngRes;
        }

        public long m_lngGetDeviceCodeAndSampleIDFromSampleCode(string p_strSampleCode, out string p_strDeviceCode, out string p_strDeviceSampleID)
        {
            p_strDeviceCode = null;
            p_strDeviceSampleID = null;
            if (p_strSampleCode == null)
                return -1;

            long lngRes = -1;
            if (m_blnIsDeviceCodeSeparator)
            {
                try
                {
                    string[] strCodeArr = p_strSampleCode.Split(m_strDeviceCodeSeparator.ToCharArray());
                    if (strCodeArr == null || strCodeArr.Length != 2)
                        return -1;
                    p_strDeviceCode = strCodeArr[0];
                    p_strDeviceSampleID = strCodeArr[1];

                    lngRes = 1;
                }
                catch (Exception ex)
                {
                    p_strDeviceCode = null;
                    p_strDeviceSampleID = null;
                }
            }
            else
            {
                try
                {
                    if (p_strSampleCode.Length < m_intDeviceCodeLength)
                        return -1;
                    p_strDeviceCode = p_strSampleCode.Substring(0, m_intDeviceCodeLength);
                    p_strDeviceSampleID = p_strSampleCode.Substring(m_intDeviceCodeLength, p_strSampleCode.Length - m_intDeviceCodeLength);
                    lngRes = 1;
                }
                catch (Exception ex)
                {
                    p_strDeviceCode = null;
                    p_strDeviceSampleID = null;
                }
            }
            return lngRes;
        }
        
        private void m_mthLoadCodeRule()
        {
            this.m_blnIsDeviceCodeSeparator = false;
            this.m_blnIsSampleCodeSeparator = true;
            this.m_intDeviceCodeLength = 2;
            this.m_strSampleCodeSeparator = "+";
        }

        private void m_mthLoadDeviceCode()
        {
            clsDomainController_LisDeviceManage objDeviceManage = new clsDomainController_LisDeviceManage();
            clsLisDevice_VO[] objDeviceVOArr = null;
            try
            {
                long lngRes = objDeviceManage.m_lngGetAllDevice(out objDeviceVOArr);
                if (objDeviceVOArr != null)
                {
                    for (int i = 0; i < objDeviceVOArr.Length; i++)
                    {
                        if ((
                                objDeviceVOArr[i].m_strEndDate == null
                                || objDeviceVOArr[i].m_strEndDate.Trim() == ""
                                || (DateTime.Parse(objDeviceVOArr[i].m_strEndDate) > DateTime.Now)
                            )
                            && DateTime.Parse(objDeviceVOArr[i].m_strBeginDate) <= DateTime.Now
                            && objDeviceVOArr[i].m_strDeviceCode != null
                            && objDeviceVOArr[i].m_strDeviceCode.Trim() != ""
                            )
                        {
                            this.m_hasDeviceCode.Add(objDeviceVOArr[i].m_strDeviceCode.Trim(), objDeviceVOArr[i].m_strDeviceID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string m_strGetNextNO(string p_strNO)
        {
            if (p_strNO == null || p_strNO.Trim() == "")
                return p_strNO;
            string strNextNO = "";
            int i = p_strNO.Length - 1;
            string strNumList = "0123456789";
            while (i >= 0)
            {
                string strCurrChar = p_strNO.Substring(i, 1);
                if (strNumList.IndexOf(strCurrChar) >= 0)
                {
                    i--;
                }
                else
                {
                    break;
                }
            }
            int intNumLenght = p_strNO.Length - 1 - i;
            int intNumStart = i + 1;
            if (intNumLenght > 0)
            {
                Int64 intNum = Int64.Parse(p_strNO.Substring(intNumStart, intNumLenght));
                Int64 intNextNum = intNum + 1;
                string strNextNum = intNextNum.ToString();
                if (strNextNum != null && strNextNum.Trim() != "")
                {
                    if (strNextNum.Length < intNumLenght)
                    {
                        strNextNum = strNextNum.PadLeft(intNumLenght, '0');
                    }
                }
                string strHead = p_strNO.Substring(0, p_strNO.Length - intNumLenght);
                strNextNO = strHead + strNextNum;
            }
            return strNextNO;
        }

    }
    #endregion

    #region 封装公共方法
    /// <summary>
    /// 封装公共方法 
    /// </summary>
    public class clsLISPublic
    {
        ///// <summary>
        ///// 打开检验采集控制台以及自动连接检验仪器
        ///// </summary>
        //public static void m_mthOpenLisDataController(Form p_frmMdiParent)
        //{
        //    Form[] frmChildren = null;
        //    com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller objDataController = null;

        //    if (p_frmMdiParent != null)
        //    {
        //        frmChildren = p_frmMdiParent.MdiChildren;
        //        foreach (Form frmChild in frmChildren)
        //        {
        //            objDataController = frmChild as com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller;
        //            if (objDataController != null)
        //            {
        //                break;
        //            }
        //        }

        //        if (objDataController == null)
        //        {
        //            objDataController = new com.digitalwave.iCare.gui.LIS_Data_Acquisition_Controller.frmLIS_Data_Acquisition_Controller();
        //            objDataController.MdiParent = p_frmMdiParent;
        //            objDataController.WindowState = FormWindowState.Maximized;
        //            objDataController.Show();
        //        }
        //    }
        //}
        /// <summary>
        /// 计算均值、标准差、变异系数
        /// </summary>
        /// <param name="p_dblSourceDate"></param>
        /// <param name="p_dblX"></param>
        /// <param name="p_dblSD"></param>
        /// <param name="p_dblCV">%</param>
        /// <returns></returns>
        public static long m_lngCalculateSDXCV(double[] p_dblSourceDate, out double p_dblX, out double p_dblSD, out double p_dblCV)
        {
            p_dblX = 0;
            p_dblSD = 0;
            p_dblCV = 0;
            if (p_dblSourceDate == null || p_dblSourceDate.Length <= 0)
            {
                return -1L;
            }

            double X = 0;
            double SD = 0;
            foreach (double d in p_dblSourceDate)
            {
                X += d;
            }
            p_dblX = X / p_dblSourceDate.Length;

            foreach (double d in p_dblSourceDate)
            {
                SD += Math.Pow((d - p_dblX), 2);
            }
            SD = SD / p_dblSourceDate.Length;

            p_dblSD = Math.Sqrt(SD);

            p_dblCV = (p_dblSD / p_dblX) * 100;//(SD / p_dblX) * 100;

            return 1L;
        }

    }

    #endregion

    #region 条码生成器
    /// <summary>
    /// 条码生成器
    /// </summary>
    public class clsBarcodeMaker
    {
        static bool m_blnHasInitBarcodeParm = false;
        static string m_strBarcodeParm;
        static BarcodeXStyle m_BarcodeStyle = BarcodeXStyle.None;

        public clsBarcodeMaker()
        {
            m_mthGetBarcodeParm();
        }
        /// <summary>
        /// 创建条码
        /// </summary>
        /// <param name="p_strCode"></param>
        /// <param name="p_strBMPFile"></param>
        public void CreateBarcodeBMP(string p_strCode, out string p_strBMPFile)
        {
            clsCreateBarcode objBarcode = new clsCreateBarcode();
            objBarcode.CreateBarcodeBMP(p_strCode, m_BarcodeStyle, out p_strBMPFile);
        }

        private void m_mthGetBarcodeParm()
        {
            if (!m_blnHasInitBarcodeParm)
            {
                try
                {
                    clsLisMainSmp.s_obj.m_lngGetSysParm("6006", out m_strBarcodeParm);
                    m_blnHasInitBarcodeParm = true;

                    if (!string.IsNullOrEmpty(m_strBarcodeParm))
                    {
                        switch (m_strBarcodeParm)
                        {
                            case "Code39":
                                m_BarcodeStyle = BarcodeXStyle.Code39;
                                break;
                            case "Code39Ext":
                                m_BarcodeStyle = BarcodeXStyle.Code39Ext;
                                break;
                            case "Code128":
                                m_BarcodeStyle = BarcodeXStyle.Code128;
                                break;
                            case "Code128A":
                                m_BarcodeStyle = BarcodeXStyle.Code128A;
                                break;
                            case "Code128B":
                                m_BarcodeStyle = BarcodeXStyle.Code128B;
                                break;
                            case "Code128C":
                                m_BarcodeStyle = BarcodeXStyle.Code128C;
                                break;
                            case "ENA128":
                                m_BarcodeStyle = BarcodeXStyle.EAN_128;
                                break;
                            case "ISSN":
                                m_BarcodeStyle = BarcodeXStyle.ISSN;
                                break;
                            case "ISBN":
                                m_BarcodeStyle = BarcodeXStyle.ISBN;
                                break;
                            case "Codebar":
                                m_BarcodeStyle = BarcodeXStyle.Codebar;
                                break;
                            case "Custom":
                                m_BarcodeStyle = BarcodeXStyle.Custom;
                                break;

                            default:
                                m_BarcodeStyle = BarcodeXStyle.EAN_128;
                                break;
                        }
                    }
                }
                catch (Exception objEx)
                {
                    clsLogText objLogger = new clsLogText();
                    objLogger.LogDetailError(objEx, false);
                    objLogger = null;

                    m_blnHasInitBarcodeParm = false;
                }
            }
        }
    }

    #endregion

}
