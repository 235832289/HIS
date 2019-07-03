using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 帐务期结转界面控制层
    /// </summary>
    public class clsCtl_AccountPeriod : com.digitalwave.GUI_Base.clsController_Base
    {
       #region 全局变量
        private clsDcl_AccountPeriod m_objDomain;
        private frmAccountPeriod m_objViewer;
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_AccountPeriod()
        {
            m_objDomain = new clsDcl_AccountPeriod();
        }
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAccountPeriod)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取帐务期结转数据

        /// <summary>
        /// 获取帐务期结转数据
        /// </summary>
        internal void m_mthGetAccountPeriodData()
        {
            long lngRes = m_objDomain.m_lngGetAccountPeriod(m_objViewer.m_strDrugStoreid, out m_objViewer.m_dtbAccountData);
        }
        #endregion
        #region 获取帐务结转开始时间

        /// <summary>
        /// 获取帐务结转开始时间
        /// </summary>
        /// <returns></returns>
        internal DateTime m_dtmGetBeginDate()
        {
            DateTime dtmBeginDate = DateTime.MinValue;
            if (m_objViewer.m_dtbAccountData == null || m_objViewer.m_dtbAccountData.Rows.Count == 0)
            {
                string strDate = string.Empty;
                long lngRes = m_objDomain.m_lngGetSysParm("5001", out strDate);
                if (!DateTime.TryParse(strDate, out dtmBeginDate))
                {
                    dtmBeginDate = DateTime.MinValue;
                }
            }
            else
            {
                int intRowsCount = m_objViewer.m_dtbAccountData.Rows.Count;

                dtmBeginDate = Convert.ToDateTime(m_objViewer.m_dtbAccountData.Rows[intRowsCount - 1]["endtime_dat"]).AddSeconds(1);
            }
            return dtmBeginDate;
        }
        #endregion
        #region 显示帐务期结转内容
        /// <summary>
        /// 显示帐务期结转内容
        /// </summary>
        internal clsDS_AccountPeriodVO m_objGetAccount()
        {
            if (m_objViewer.m_dgvAccountPeriod.SelectedRows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvAccountPeriod.SelectedRows[0].DataBoundItem).Row;

            if (drCurrent == null)
            {
                return null;
            }

            clsDS_AccountPeriodVO objAP = new clsDS_AccountPeriodVO();
            objAP.m_dtmENDTIME_DAT = Convert.ToDateTime(drCurrent["endtime_dat"]);
            objAP.m_dtmSTARTTIME_DAT = Convert.ToDateTime(drCurrent["starttime_dat"]);
            objAP.m_dtmTRANSFERTIME_DAT = Convert.ToDateTime(drCurrent["transfertime_dat"]);
            objAP.m_lngSERIESID_INT = Convert.ToInt64(drCurrent["seriesid_int"]);
            objAP.m_strACCOUNTID_CHR = drCurrent["accountid_chr"].ToString();
            objAP.m_strCOMMENT_VCHR = drCurrent["comment_vchr"].ToString();
            objAP.m_strDrugStoreid = drCurrent["drugstoreid_chr"].ToString();
            return objAP;
        }
        #endregion
    }
}
