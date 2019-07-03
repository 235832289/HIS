using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBChargeAutoUpData
    {
        clsDcl_YB objDomain = null;

        clsDGExtra_VO objDgextraVo = null;
        #region 获取药品让利开关 Add by 吴汉明 2014-12-25
        public bool m_blnDiffCostOn = false;
        #endregion
        public clsCtl_YBChargeAutoUpData()
        {
            objDomain = new clsDcl_YB();

        }

        #region 数据上传

        /// <summary>
        /// 数据上传
        /// </summary>
        /// <param name="p_dateBegin"></param>
        /// <param name="p_dateEnd"></param>
        /// <returns></returns>
        public long m_mthUpload(DateTime p_dateBegin, DateTime p_dateEnd)
        {
            return m_mthUpload(p_dateBegin, p_dateEnd, string.Empty);
        }

        /// <summary>
        /// 数据上传
        /// </summary>
        public long m_mthUpload(DateTime p_dateBegin, DateTime p_dateEnd, string jzjlh)
        {
            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
            long lngRes = -1;
            List<clsDGZyxmcs_VO> lstDgzyxmcsVo = null;
            if (string.IsNullOrEmpty(jzjlh))
                lngRes = this.objDomain.m_lngGetDgzyxmcs(p_dateBegin, p_dateEnd, out lstDgzyxmcsVo, true /*m_blnDiffCostOn*/);
            else
                lngRes = this.objDomain.m_lngGetDgzyxmcs(p_dateBegin, p_dateEnd, out lstDgzyxmcsVo, true /*m_blnDiffCostOn*/, jzjlh);
            if (lngRes < 0 || lstDgzyxmcsVo == null || lstDgzyxmcsVo.Count == 0)
            {
                return lngRes;
            }
            try
            {
                string strUser = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
                string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
                lngRes = clsYBPublic_cs.m_lngUserLoin(strUser, strPwd, false);
                if (lngRes > 0)
                {
                    objDgextraVo = new clsDGExtra_VO();
                    objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
                    objDgextraVo.JBR = "0001";// 操作员工号
                    System.Text.StringBuilder strValue = null;
                    lngRes = clsYBPublic_cs.m_lngFunSP3002(lstDgzyxmcsVo, objDgextraVo, ref strValue);
                    if (lngRes > 0)
                    {
                        lngRes = this.objDomain.m_lngUpdateDgzyxmcs(lstDgzyxmcsVo);
                        bool blnRes = false;
                        if (strValue.ToString().Trim().Equals("1"))
                        {
                            blnRes = objLogger.LogError("明细上传成功，时间" + System.DateTime.Now.ToString() + "正确信息:" + strValue.ToString());
                        }
                        else
                        {
                            blnRes = objLogger.LogError("明细上传失败，时间" + System.DateTime.Now.ToString() + "错误信息:" + strValue.ToString());
                        }
                        //MessageBox.Show("明细上传成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                }
            }
            catch (Exception ex)
            {
                objLogger.LogError("明细上传失败，时间" + System.DateTime.Now.ToString() + "异常信息:" + ex.ToString());
                return -1;
            }
            return lngRes;
        }
        #endregion
    }
}
