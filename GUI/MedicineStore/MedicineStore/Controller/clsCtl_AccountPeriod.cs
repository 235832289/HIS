using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 帐务期结转
    /// </summary>
    public class clsCtl_AccountPeriod : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_AccountPeriod m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmAccountPeriod m_objViewer;

        /// <summary>
        /// 帐务期结转
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
        /// 获取帐务期结转数据        /// </summary>
        internal void m_mthGetAccountPeriodData()
        {
            long lngRes = m_objDomain.m_lngGetAccountPeriod(m_objViewer.m_strStorageID, out m_objViewer.m_dtbAccountData);
        }
        #endregion

        #region 显示帐务期结转内容
        /// <summary>
        /// 显示帐务期结转内容        /// </summary>
        internal clsMS_AccountPeriodVO m_objGetAccount()
        {
            if (m_objViewer.m_dgvAccountData.SelectedRows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvAccountData.SelectedRows[0].DataBoundItem).Row;

            if (drCurrent == null)
            {
                return null;
            }

            clsMS_AccountPeriodVO objAP = new clsMS_AccountPeriodVO();
            objAP.m_dtmENDTIME_DAT = Convert.ToDateTime(drCurrent["endtime_dat"]);
            objAP.m_dtmSTARTTIME_DAT = Convert.ToDateTime(drCurrent["starttime_dat"]);
            objAP.m_dtmTRANSFERTIME_DAT = Convert.ToDateTime(drCurrent["transfertime_dat"]);
            objAP.m_lngSERIESID_INT = Convert.ToInt64(drCurrent["seriesid_int"]);
            objAP.m_strACCOUNTID_CHR = drCurrent["accountid_chr"].ToString();
            objAP.m_strCOMMENT_VCHR = drCurrent["comment_vchr"].ToString();
            objAP.m_strSTORAGEID_CHR = drCurrent["storageid_chr"].ToString();
            return objAP;
        }
        #endregion

        #region 获取帐务结转开始时间
        /// <summary>
        /// 获取帐务结转开始时间        /// </summary>
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

        #region 取消结转
        /// <summary>
        /// 取消结转
        /// </summary>
        internal void m_mthCancelAccount()
        {
            if (m_objViewer.m_dgvAccountData.SelectedRows.Count == 0)
            {
                return ;
            }

            long lngRes = 0;
            try
            {
                DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvAccountData.SelectedRows[0].DataBoundItem).Row;
                if (drCurrent == null)
                {
                    return ;
                }

                DateTime dtmEnd = Convert.ToDateTime(drCurrent["endtime_dat"]);
                bool blnCanCancel = true;
                lngRes = m_objDomain.m_lngCheckCanCancelAccount(dtmEnd, m_objViewer.m_strStorageID, out blnCanCancel);
                if (!blnCanCancel)
                {
                    System.Windows.Forms.MessageBox.Show("本期帐务结转后已存在下一期的业务单据，不允许取消结转","帐务期结转",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Stop);
                    return;
                }

                long lngSEQ = Convert.ToInt64(drCurrent["SERIESID_INT"]);
                string strAccount = drCurrent["accountid_chr"].ToString();

                lngRes = m_objDomain.m_lngCancelAccount(lngSEQ, strAccount, m_objViewer.m_strStorageID);

                if (lngRes > 0)
                {
                    m_objViewer.m_dtbAccountData.Rows.Remove(drCurrent);
                    System.Windows.Forms.MessageBox.Show("取消帐务结转成功！", "帐务期结转", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("取消帐务结转失败！", "帐务期结转", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show("取消帐务结转失败！", "帐务期结转", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }         
            
        } 
        #endregion

        internal void m_mthPrint()
        {
            
            DataTable dtbPrint = new DataTable();
            long lngRes = m_objDomain.m_lngGetAccout(m_objViewer.m_strStorageID, m_objViewer.m_dgvAccountData.Rows[m_objViewer.m_dgvAccountData.CurrentCell.RowIndex].Cells[0].Value.ToString().Trim(), out dtbPrint);
            frmAccountPeriodReport frmPrint = new frmAccountPeriodReport();
            frmPrint.dtb = dtbPrint;
            frmPrint.strBeginDate = m_objViewer.m_dgvAccountData.Rows[m_objViewer.m_dgvAccountData.CurrentCell.RowIndex].Cells[1].Value.ToString().Trim();
            frmPrint.strEndDate = m_objViewer.m_dgvAccountData.Rows[m_objViewer.m_dgvAccountData.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim();
            string strStoreRoomName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID,out strStoreRoomName);

            frmPrint.strTitel = m_objComInfo.m_strGetHospitalTitle();
            
            frmPrint.strStorageName = strStoreRoomName;

            frmPrint.ShowDialog();
            //datWindow.Retrieve(dtbPrint);

            
        }
        


    }
}
