using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 标本反馈控制层
    /// </summary>
    public class clsCtl_SampleBack:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// 界面层
        /// </summary>
        frmSampleBack m_objViewer;
        /// <summary>
        /// Domain层
        /// </summary>
        clsDcl_SampleBack m_objDomain;
        #endregion

        #region 构造函数
        /// <summary>
        /// 设置界面层
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmSampleBack)frmMDI_Child_Base_in;
        }
        public clsCtl_SampleBack()
        {
            m_objDomain = new clsDcl_SampleBack();
        }
        #endregion

        #region 获取样本反馈信息
        /// <summary>
        /// 获取样本反馈信息
        /// </summary>
        /// <param name="p_strFromDate">开始日期</param>
        /// <param name="p_strToDate">结束日期</param>
        /// <param name="p_strPatientName">病人姓名</param>
        /// <param name="p_strInHospitalNO">住院号</param>
        /// <param name="p_strAppDeptID">申请科室ID</param>
        /// <param name="p_dtResult">返回结果表</param>
        /// <returns>大于0成功，小于或等于0失败</returns>
        public long m_lngQuerySampleBack(string p_strFromDate, string p_strToDate, string p_strPatientName, string p_strInHospitalNO, string p_strAppDeptID, out DataTable p_dtResult)
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngQuerySampleBack(p_strFromDate, p_strToDate, p_strPatientName, p_strInHospitalNO, p_strAppDeptID, out p_dtResult);
            return lngRes;
        }
        #endregion
    }
}
