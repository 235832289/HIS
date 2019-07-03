using System;
using System.Collections.Generic;
using System.Text;
using iCareData;
using com.digitalwave.Emr.StaticObject;

namespace iCare
{
    /// <summary>
    /// 医嘱系统-检查申请单
    /// </summary>
    public class clsEMR_HIS_CheckRequisition
    {
        #region 全局变量
        /// <summary>
        /// 入院登记号
        /// </summary>
        private string m_strRegisterID = string.Empty;
        /// <summary>
        /// 医嘱流水号
        /// </summary>
        private string m_strOrderID = string.Empty;
        /// <summary>
        /// 当前获取的检查申请单内容
        /// </summary>
        private clsEMR_HIS_CheckRequisitionValue m_objValue = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 医嘱系统-检查申请单
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_strOrderID">医嘱流水号</param>
        public clsEMR_HIS_CheckRequisition(string p_strRegisterID, string p_strOrderID)
        {
            m_strRegisterID = p_strRegisterID;
            m_strOrderID = p_strOrderID;
            m_objValue = null;
        } 
        #endregion

        #region 获取申请单内容
        /// <summary>
        /// 获取申请单内容
        /// </summary>
        /// <returns></returns>
        public clsEMR_HIS_CheckRequisitionValue m_objGetCheckRequisition()
        {
            clsEMR_HIS_CheckRequisitionValue objValue = null;

            clsEMR_HIS_CheckRequisitionDomain objDomain = new clsEMR_HIS_CheckRequisitionDomain();
            long lngRes = objDomain.m_lngGetCheckRequisitionValue(m_strRegisterID, m_strOrderID, out objValue);

            m_objValue = objValue;
            objDomain = null;

            return objValue;
        }

        /// <summary>
        /// 获取指定病人的所有申请单内容
        /// </summary>
        /// <returns></returns>
        public clsEMR_HIS_CheckRequisitionValue[] m_objGetAllCheckRequisition()
        {
            clsEMR_HIS_CheckRequisitionValue[] objValue = null;

            clsEMR_HIS_CheckRequisitionDomain objDomain = new clsEMR_HIS_CheckRequisitionDomain();
            long lngRes = objDomain.m_lngGetCheckRequisitionValue(m_strRegisterID, out objValue);

            objDomain = null;
            return objValue;
        }
        #endregion 

        #region 显示检查申请单窗体
        /// <summary>
        /// 显示检查申请单窗体
        /// </summary>
        public void m_mthShowCheckRequisitionForm()
        {
            frmEMR_HIS_CheckRequisition frmShow = null;
            if (m_objValue == null)
            {
                frmShow = new frmEMR_HIS_CheckRequisition(m_strRegisterID, m_strOrderID);
            }
            else
            {
                frmShow = new frmEMR_HIS_CheckRequisition(m_strRegisterID, m_strOrderID, m_objValue);
            }
            frmShow.Show();
        } 
        #endregion

        #region 删除检查申请单内容
        /// <summary>
        /// 删除检查申请单内容
        /// </summary>
        public void m_mthDeleteCheckRequisition()
        {
            clsEMR_HIS_CheckRequisitionDomain objDomain = new clsEMR_HIS_CheckRequisitionDomain();
            long lngRes = objDomain.m_lngDeleteRequisition(clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR, m_objValue.m_strREGISTERID_CHR, m_objValue.m_strORDERID_CHR);
            objDomain = null;

            if (lngRes > 0)
            {
                m_objValue = null;
                System.Windows.Forms.MessageBox.Show("删除成功！", "检查申请单", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("删除失败！", "检查申请单", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        } 
        #endregion
    }
}
