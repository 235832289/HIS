using System;
using System.Collections.Generic;
using System.Text;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 获取检验设置


    /// </summary>
    public static class clsLisSetting
    {
        /// <summary>
        /// 4004开关:检验审核的时候是否需要审核人登录
        /// </summary>
        /// <returns></returns>
        public static bool IsComfirmNeedLoginIn()
        {
            int setNum = GetSetting("4004");
            return setNum == 1 ? true : false;
        }

        /// <summary>
        /// 9000开关:门诊医生工作站采用何种模式(0:收费项目 1:诊疗项目)
        /// </summary>
        /// <remarks>OT:门诊缩写</remarks>
        /// <returns>true:诊疗项目 false:收费项目</returns>
        public static bool IsOTOrderMode()
        {
            int setNum = GetSetting("9000");
            return setNum == 1 ? true : false;
        }

        /// <summary>
        /// 9001开关:住院采用何种模式(0:收费项目 1:诊疗项目)
        /// </summary>
        /// <returns>true:诊疗项目 false:收费项目</returns>
        public static bool IsBIHOrderMode()
        {
            int setNum = GetSetting("9001");
            return setNum == 1 ? true : false;
        }

        /// <summary>
        /// 4002开关:是否跳过样本采集和核收

        /// </summary>
        /// <returns>1:跳过 0:不跳过 2:跳过采集不跳过核收</returns>
        public static int IsSkipCollectionReceive()
        {
            int setNum = GetSetting("4002");
            return setNum;
        }
        /// <summary>
        /// 4012开关:检验报告录入界面是否允许修改送检时间
        /// </summary>
        /// <returns></returns>
        public static bool BlnCanModifyAcceptDat()
        {
            int setNum = GetSetting("4012");
            if (setNum == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region 4023开关 0表示当天，1表示昨天到今天
        /// <summary>
        /// 4023开关 0表示当天，1表示昨天到今天
        /// </summary>
        /// <returns></returns>
        public static int IsShelfHelpDays()
        {
            int setNum = GetSetting("4023");
            return setNum;
        }
        #endregion

        private static int GetSetting(string setId)
        {
            int setNum = 0;
            long lngRes = clsLisMainSmp.s_obj.GetSystemSetting(setId, out setNum);
            return setNum;
        }
    }
}