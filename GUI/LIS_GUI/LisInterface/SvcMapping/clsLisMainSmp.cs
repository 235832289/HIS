using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    internal class clsLisMainSmp
    {
        #region 构造


        private clsLisMainSmp()
        {
            objSvc = (clsLisMainSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsLisMainSvc));
        }
        private clsLisMainSvc objSvc;
        public static clsLisMainSmp s_obj
        {
            get
            {
                return new clsLisMainSmp();
            }
        }

        #endregion

        #region 获取系统设置

        /// <summary>
        /// 获取系统设置
        /// </summary>
        /// <param name="setResult">设置结果</param>
        /// <param name="setId">设置的Id</param>
        /// <returns></returns>
        public long GetSystemSetting(string setId, out int setResult)
        {
            long lngRes = 0;
            setResult = -1;

            try
            {
                lngRes = objSvc.m_lngGetSystemSetting(out setResult, setId);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        public long GetSystemSetting(string setId, out bool setResult)
        {
            int result=-1;
            setResult = false;
            long lngRes = GetSystemSetting(setId, out result);
            if (result == 1)
            {
                setResult = true;
            }
            else 
            {
                setResult = false;
            }

            return lngRes;
        }
       
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="p_strParmValue"></param>
        /// <returns></returns>
        public void m_lngGetSysParm(string p_strParmCode, out string p_strParmValue)
        {
            p_strParmValue = "";
            long lngRes = 0;
            lngRes = objSvc.m_lngGetSysParm(p_strParmCode, out p_strParmValue);
        }
        #endregion
    }
}
