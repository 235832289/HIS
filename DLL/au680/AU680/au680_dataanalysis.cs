using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AU680
{
    public class DataAnalysis_AU680 : clsLISDataAnalysisBase, infLISDataAnalysis
    {
        public System.Data.DataTable dtConfig { get; set; }

        // Methods
        public long lngDataAnalysis(string p_strRawData, out ArrayList p_arlResult)
        {
            p_arlResult = null;
            return 0L;
        }

        public string[] strGetIntactData(string p_strRawData)
        {
            return null;
        }

        public long lngDataAnalysis(string p_strRawData, out List<clsLIS_Device_Test_ResultVO> p_arlResult)
        {
            p_arlResult = null;
            if ((p_strRawData == "") || (p_strRawData == null))
            {
                return 0L;
            }
            if (p_strRawData.Length < 7) return 0L;
            p_arlResult = new List<clsLIS_Device_Test_ResultVO>();
            string strSampleID = p_strRawData.Substring(7, 4);  //Substring(9, 4);
            // 质控上机号
            if (strSampleID.ToUpper().StartsWith("Q0"))
            {
                strSampleID += "-" + Convert.ToInt32(p_strRawData.Substring(12, 3));
            }
            string strCheckDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int intCurrPos = p_strRawData.IndexOf("E0");// 38;
            // 20171028.由于检验科换试剂厂家，重装了控制软件，导致数据结构变了  --- 质控上机号还需要找时间做标本
            strSampleID = p_strRawData.Substring(intCurrPos - 8, 4);
            // <-----
            string strData = p_strRawData.Substring(intCurrPos + 1);
            List<string> lstChar = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            string strItem = string.Empty;
            clsLIS_Device_Test_ResultVO vo = null;
            int count = strData.Length / 11;    // 循环次数
            for (int i = 0; i < count; i++)
            {
                strItem = strData.Substring(0, 11);
                vo = new clsLIS_Device_Test_ResultVO();
                vo.strDevice_Sample_ID = strSampleID;
                vo.strCheck_Date = strCheckDate;
                vo.strDevice_Check_Item_Name = strItem.Substring(0, 3);
                vo.strResult = strItem.Substring(3).Trim();
                #region bak
                //if (vo.strResult.EndsWith("r")) // 重传 
                //    vo.strResult = vo.strResult.TrimEnd('r').Trim();
                //else if (vo.strResult.EndsWith("e"))
                //    vo.strResult = vo.strResult.TrimEnd('e').Trim();
                //else if (vo.strResult.EndsWith("f"))    // 报警
                //    vo.strResult = vo.strResult.TrimEnd('f').Trim();
                //if (vo.strResult.EndsWith("R"))
                //    vo.strResult = vo.strResult.TrimEnd('R').Trim();
                //else if (vo.strResult.EndsWith("E"))
                //    vo.strResult = vo.strResult.TrimEnd('E').Trim();
                //else if (vo.strResult.EndsWith("F"))
                //    vo.strResult = vo.strResult.TrimEnd('F').Trim();
                //// 如果结果无效,结果负数时报错
                //if (vo.strResult == "999999") // || vo.strResult.StartsWith("-"))
                //    vo.strResult = "***";
                //else if (vo.strResult.StartsWith("-"))
                //{
                //    if (!vo.strResult.StartsWith("- "))
                //        vo.strResult = "***";
                //    else
                //        vo.strResult = vo.strResult.Substring(1).Trim();
                //}
                //else if (string.IsNullOrEmpty(vo.strResult))
                //    vo.strResult = "0.00";
                //if (vo.strResult.IndexOf("f") >= 0) vo.strResult = vo.strResult.Replace("f", "");
                //if (vo.strResult.IndexOf("F") >= 0) vo.strResult = vo.strResult.Replace("F", "");
                #endregion

                if (vo.strResult != string.Empty)
                {
                    bool isOk = false;
                    int len = vo.strResult.Length;
                    for (int k = len - 1; k >= 0; k--)
                    {
                        if (lstChar.IndexOf(vo.strResult.Substring(k, 1)) >= 0)
                        {
                            vo.strResult = vo.strResult.Substring(0, k + 1);
                            isOk = true;
                            break;
                        }
                        //if (IsNumeric(vo.strResult.Substring(k, 1)) == false)
                        //{
                        //    vo.strResult = vo.strResult.Substring(0, k);
                        //}
                        //else
                        //{
                        //    break;
                        //}
                    }
                    if (isOk == false) vo.strResult = "";
                }

                // 重置
                strData = strData.Substring(11);

                // 读取配置
                if (this.dtConfig != null && this.dtConfig.Rows.Count > 0)
                {
                    for (int i2 = 0; i2 < this.dtConfig.Columns.Count; i2++)
                    {
                        if (this.dtConfig.Columns[i2].ColumnName == "F" + vo.strDevice_Check_Item_Name)
                        {
                            vo.strDevice_Check_Item_Name = this.dtConfig.Rows[0]["F" + vo.strDevice_Check_Item_Name].ToString().Trim();
                            break;
                        }
                    }
                }
                //vo.strDevice_Check_Item_Name = this.m_strConvertItem(vo.strDevice_Check_Item_Name);
                //vo.strResult = this.m_strConvertValue(vo.strDevice_Check_Item_Name, vo.strResult);
                p_arlResult.Add(vo);
            }
            return 1L;
        }

        private bool IsNumeric(string str)
        {
            if (str == null || str.Length == 0)
                return false;
            foreach (char c in str)
            {
                if (!Char.IsNumber(c))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
