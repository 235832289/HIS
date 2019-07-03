using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药库窗体工厂类

    /// </summary>
    public class clsMedicineStoreFormFactory
    {
        /// <summary>
        /// 报表名称
        /// </summary>
        public string m_strReportName = string.Empty;

        #region 显示原始库存初始化窗体

        
        /// <summary>
        /// 显示原始库存初始化窗体

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strReportName">报表名称</param>
        public void ShowInventoryRecord(string p_strStorageID,string p_strReportName)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowInventoryRecord({0},{1})", p_strStorageID.Trim(), p_strReportName.Trim());
                if (m_blnHasCurrentForm("frmInventoryRecord",m_strMedthodName))
                {
                    return;
                }
                
                frmInventoryRecord frmIR = new frmInventoryRecord(p_strStorageID,p_strReportName);
                frmIR.Tag = m_strMedthodName;
                frmIR.Show();
                frmIR.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmIR.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        } 
        #endregion

        #region 显示入库窗体
        /// <summary>
        /// 显示入库窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowInStorage(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowInStorage({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmPurchase", m_strMedthodName))
                {
                    return;
                }

                frmPurchase frmIR = new frmPurchase(p_strStorageID);
                frmIR.Tag = m_strMedthodName;
                frmIR.Show();
                frmIR.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmIR.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        /// <summary>
        /// 显示入库窗体
        /// </summary>
        /// <param name="p_strStorageID"></param>
        public void ShowInStorageByType(string p_strStorageID, string m_strInStorageType)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowInStorageByType({0}{1})", p_strStorageID.Trim(), m_strInStorageType);
                if (m_blnHasCurrentForm("frmPurchase", m_strMedthodName))
                {
                    return;
                }

                frmPurchase frmIR = new frmPurchase(p_strStorageID, m_strInStorageType);
                frmIR.Tag = m_strMedthodName;
                frmIR.Show();
                frmIR.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmIR.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示出库窗体
        /// <summary>
        /// 显示出库窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowOutStorage(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowOutStorage({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmOutStorage", m_strMedthodName))
                {
                    return;
                }

                frmOutStorage frmIR = new frmOutStorage(p_strStorageID);
                frmIR.Tag = m_strMedthodName;
                frmIR.Show();
                frmIR.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmIR.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
       

        /// <summary>
        /// 显示出库窗体
        /// </summary>
        /// <param name="p_strStorageID"></param>
        public void ShowOutStorageByType(string p_strStorageID, string m_strOutStorageType)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowOutStorageByType({0}{1})", p_strStorageID.Trim(), m_strOutStorageType);
                if (m_blnHasCurrentForm("frmOutStorage", m_strMedthodName))
                {
                    return;
                }

                frmOutStorage frmIR = new frmOutStorage(p_strStorageID, m_strOutStorageType);
                frmIR.Tag = m_strMedthodName;
                frmIR.Show();
                frmIR.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmIR.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示报废出库
        /// <summary>
        /// 显示报废出库
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowRejectOutStorage(string p_strStorageID, string p_strReportName)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowRejectOutStorage({0},{1})", p_strStorageID.Trim(), p_strReportName.Trim());
                if (m_blnHasCurrentForm("frmRejectOutStorage_Main", m_strMedthodName))
                {
                    return;
                }

                frmRejectOutStorage_Main frmROS = new frmRejectOutStorage_Main(p_strStorageID, p_strReportName);
                frmROS.Tag = m_strMedthodName;
                frmROS.Show();
                frmROS.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmROS.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示退药出库

        /// <summary>
        /// 显示退药出库

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowForeignRetreat(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowForeignRetreat({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmForeignRetreatOutStorage", m_strMedthodName))
                {
                    return;
                }

                frmForeignRetreatOutStorage frmROS = new frmForeignRetreatOutStorage(p_strStorageID);
                frmROS.Tag = m_strMedthodName;
                frmROS.Show();
                frmROS.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmROS.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 检查是否已打开指定窗体
        /// <summary>
        /// 检查是否已打开指定窗体
        /// </summary>
        /// <param name="p_strFormName">窗体名</param>
        /// <param name="m_strMedthodName">方法名称</param>
        /// <returns></returns>
        private bool m_blnHasCurrentForm(string p_strFormName,string m_strMedthodName)
        {
            bool blnHasShow = false;

            System.Windows.Forms.Form frmParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
            foreach (System.Windows.Forms.Form frmChild in frmParent.MdiChildren)
            {
                if (frmChild is com.digitalwave.GUI_Base.frmMDI_Child_Base && frmChild.Name == p_strFormName &&frmChild.Tag!=null&& frmChild.Tag.ToString() == m_strMedthodName)
                {
                    frmChild.Activate();
                    frmChild.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    blnHasShow = true;
                }
            }
            return blnHasShow;
        } 
        #endregion

        #region 显示药品内退窗体
        /// <summary>
        /// 入库类：显示药品内退窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowMedicineInnerWithdraw(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowMedicineInnerWithdraw({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmInStorageMedicineInnerWithdraw", m_strMedthodName))
                {
                    return;
                }

                frmInStorageMedicineInnerWithdraw frmInMedicineWithdraw = new frmInStorageMedicineInnerWithdraw(p_strStorageID);
                frmInMedicineWithdraw.Tag = m_strMedthodName;
                frmInMedicineWithdraw.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmInMedicineWithdraw.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmInMedicineWithdraw.Show();

            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示药品盘点窗体
        /// <summary>
        /// 显示药品盘点窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowStorageCheck(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowStorageCheck({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmStorageCheck", m_strMedthodName))
                {
                    return;
                }

                frmStorageCheck frmSC = new frmStorageCheck(p_strStorageID);
                frmSC.Tag = m_strMedthodName;
                frmSC.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmSC.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmSC.Show();

            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示药品调价窗体
        /// <summary>
        /// 显示药品调价窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowAdjustPrice(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowAdjustPrice({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmAdjustment", m_strMedthodName))
                {
                    return;
                }

                frmAdjustment frmAd = new frmAdjustment(p_strStorageID);
                frmAd.Tag = m_strMedthodName;
                frmAd.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmAd.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmAd.Show();
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示帐务期结转

        /// <summary>
        /// 显示帐务期结转

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowAccountPeriod(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowAccountPeriod({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmAccountPeriod", m_strMedthodName))
                {
                    return;
                }

                frmAccountPeriod frmAc = new frmAccountPeriod(p_strStorageID);
                frmAc.Tag = m_strMedthodName;
                frmAc.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmAc.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frmAc.Show();
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion

        #region 显示采购计划窗体
        /// <summary>
        /// 显示采购计划窗体
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        public void ShowStockPlan(string p_strStorageID)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowStockPlan({0})", p_strStorageID.Trim());
                if (m_blnHasCurrentForm("frmStockPlan", m_strMedthodName))
                {
                    return;
                }

                frmStockPlan frmSP = new frmStockPlan(p_strStorageID);
                frmSP.Tag = m_strMedthodName;
                frmSP.Show();
                frmSP.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmSP.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }
        #endregion
        //#region 显示药库总帐
        ///// <summary>
        ///// 显示药库总帐
        ///// </summary>
        ///// <param name="p_strStorageID">仓库ID</param>
        //public void ShowTotalAccountReport(string p_strStorageID)
        //{
        //    if (string.IsNullOrEmpty(p_strStorageID))
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        if (m_blnHasCurrentForm("frmTotalAccoutReport"))
        //        {
        //            return;
        //        }

        //        frmTotalAccoutReport frmAc = new frmTotalAccoutReport(p_strStorageID);
        //        frmAc.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
        //        frmAc.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        //        frmAc.Show();
        //    }
        //    catch (Exception Ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(Ex.Message);
        //    }
        //}
        //#endregion
        
        /// <summary>
        /// PB报表库文件路径
        /// </summary>
        public static string PBLPath = Application.StartupPath + "\\pb_ms.pbl";

        #region 获取数据库服务器当前时间
        /// <summary>
        /// 获取数据库服务器当前时间
        /// </summary>
        public static DateTime SysDateTimeNow
        {
            get
            {
                DateTime m_dtmDateTime = DateTime.Now;
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.m_lngGetSysDateTimeNow(out m_dtmDateTime);
                return m_dtmDateTime;
            }
        }
        #endregion

        #region 获取中间件服务器当前时间
        /// <summary>
        /// 获取中间件服务器当前时间
        /// </summary>
        public static DateTime CurrentDateTimeNow
        {
            get
            {
                DateTime m_dtmDateTime = DateTime.Now;
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.m_lngGetCurrentDateTime(out m_dtmDateTime);
                return m_dtmDateTime;
            }
        }
        #endregion
    }
}
