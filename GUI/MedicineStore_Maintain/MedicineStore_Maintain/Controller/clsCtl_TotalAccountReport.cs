using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药库总帐
    /// </summary>
    public class clsCtl_TotalAccountReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_TotalAccountReport m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmTotalAccoutReport m_objViewer;
        #endregion

        #region 构造函数



        /// <summary>
        /// 药库总帐
        /// </summary>
        public clsCtl_TotalAccountReport()
        {
            m_objDomain = new clsDcl_TotalAccountReport();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmTotalAccoutReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取帐务期ID列表
        /// <summary>
        /// 获取帐务期ID列表
        /// </summary>
        /// <param name="p_objAccArr">帐务期结转</param>
        internal void m_mthGetAccountIDList(out clsMS_AccountPeriodVO[] p_objAccArr)
        {
            long lngRes = m_objDomain.m_lngGetAccountPeriod(m_objViewer.m_strStorageID, out p_objAccArr);
        }

        /// <summary>
        /// 设置帐务期列表至界面
        /// </summary>
        /// <param name="p_objAccArr">帐务期结转</param>
        internal void m_mthSetAccountPeriodToList(clsMS_AccountPeriodVO[] p_objAccArr)
        {
            if (p_objAccArr == null || p_objAccArr.Length == 0)
            {
                clsMS_AccountPeriodVO objNow = new clsMS_AccountPeriodVO();
                string strDate;
                long lngRes = m_objDomain.m_lngGetSysParm("5001", out strDate);
                objNow.m_dtmSTARTTIME_DAT = Convert.ToDateTime(strDate);
                objNow.m_dtmENDTIME_DAT = DateTime.Now;
                objNow.m_strACCOUNTID_CHR = "未结转";

                StringBuilder stbID = new StringBuilder(30);
                stbID.Append(objNow.m_strACCOUNTID_CHR);
                stbID.Append("  ");
                stbID.Append(objNow.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                stbID.Append("～");
                stbID.Append(objNow.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                ListViewItem lsiNow = new ListViewItem(stbID.ToString());
                lsiNow.Tag = objNow;
                stbID = null;
                m_objViewer.m_lsvAccountIDList.Items.Add(lsiNow);
                return;
            }

            
            try
            {
                m_objViewer.m_lsvAccountIDList.Items.Clear();
                m_objViewer.m_lsvAccountIDList.BeginUpdate();
                ListViewItem[] lsiItems = new ListViewItem[p_objAccArr.Length];
                for (int iItem = 0; iItem < p_objAccArr.Length; iItem++)
                {
                    StringBuilder stbID = new StringBuilder(30);
                    stbID.Append(p_objAccArr[iItem].m_strACCOUNTID_CHR);
                    stbID.Append("  ");
                    stbID.Append(p_objAccArr[iItem].m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    stbID.Append("～");
                    stbID.Append(p_objAccArr[iItem].m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    lsiItems[iItem] = new ListViewItem(stbID.ToString());
                    lsiItems[iItem].Tag = p_objAccArr[iItem];
                    stbID = null;
                }
                m_objViewer.m_lsvAccountIDList.Items.AddRange(lsiItems);

                //添加未结转选项
                if (DateTime.Now.Date > p_objAccArr[p_objAccArr.Length - 1].m_dtmENDTIME_DAT.Date)
                {
                    clsMS_AccountPeriodVO objNow = new clsMS_AccountPeriodVO();
                    objNow.m_dtmSTARTTIME_DAT = Convert.ToDateTime(p_objAccArr[p_objAccArr.Length - 1].m_dtmENDTIME_DAT.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss"));
                    objNow.m_dtmENDTIME_DAT = DateTime.Now;
                    objNow.m_strACCOUNTID_CHR = "未结转";

                    StringBuilder stbID = new StringBuilder(30);
                    stbID.Append(objNow.m_strACCOUNTID_CHR);
                    stbID.Append("  ");
                    stbID.Append(objNow.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    stbID.Append("～");
                    stbID.Append(objNow.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    ListViewItem lsiNow = new ListViewItem(stbID.ToString());
                    lsiNow.Tag = objNow;
                    stbID = null;
                    m_objViewer.m_lsvAccountIDList.Items.Add(lsiNow);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                m_objViewer.m_lsvAccountIDList.EndUpdate();
            }
        }
        #endregion

        #region 获取总帐数据
        internal void m_mthGetTotalAccount_Divide()
        {
            clsMS_TotalAccountVO[] accountVO = null;
            long p_lngSEQ;
            m_objDomain.m_lngGetEndAccountFirstSEQ(m_objViewer.AccouVO.m_strACCOUNTID_CHR, m_objViewer.m_strStorageID,out p_lngSEQ);
            if (p_lngSEQ > 0)
            {
                long lngRes = m_objDomain.m_lngGetTotalAccount_Divide(m_objViewer.m_strStorageID, m_objViewer.AccouVO.m_dtmSTARTTIME_DAT, m_objViewer.AccouVO.m_dtmENDTIME_DAT,
                     p_lngSEQ, m_objViewer.AccouVO.m_strACCOUNTID_CHR, m_objViewer.m_strLastStorageID, out accountVO);
            }
            else
            {
                long lngRes = m_objDomain.m_lngGetTotalAccount_DivideNoAcc(m_objViewer.m_strStorageID, m_objViewer.AccouVO.m_dtmSTARTTIME_DAT, m_objViewer.AccouVO.m_dtmENDTIME_DAT,
                 p_lngSEQ, m_objViewer.AccouVO.m_strACCOUNTID_CHR, m_objViewer.m_strLastStorageID, out accountVO);

            }
            if (accountVO == null || accountVO.Length == 0)
            {
                MessageBox.Show("抱歉，没有查到该期总帐数据。", "总帐报表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_objViewer.datWindow.Reset();
                return;
            }
            DataTable dtbAccou = new DataTable();
            dtbAccou.Columns.Add("m_strmedicinetypename", typeof(System.String));
            dtbAccou.Columns.Add("m_dblbeginwholesalemoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dblbeginretailmoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dblincallmoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dblinwholesalemoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dblinretailmoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dbloutwholesalemoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dbloutretailmoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dblendwholesalemoney", typeof(System.Double));
            dtbAccou.Columns.Add("m_dblendretailmoney", typeof(System.Double));

            for (int i = 0; i < accountVO.Length; i++)
            {
                DataRow dr = dtbAccou.NewRow();
                dr[0] = accountVO[i].m_strMedicineTypeName;
                dr[1] = accountVO[i].m_dblBeginWholesaleMoney;
                dr[2] = accountVO[i].m_dblBeginRetailMoney;

                dr[3] = accountVO[i].m_dblInCallMoney;
                dr[4] = accountVO[i].m_dblInWholesaleMoney;
                dr[5] = accountVO[i].m_dblInRetailMoney;

                dr[6] = accountVO[i].m_dblOutWholesaleMoney;
                dr[7] = accountVO[i].m_dblOutRetailMoney;
                dr[8] = accountVO[i].m_dblEndWholesaleMoney;
                dr[9] = accountVO[i].m_dblEndRetailMoney;

                dtbAccou.Rows.Add(dr);
            }
            string strStoreRoomName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStoreRoomName);
            m_objViewer.datWindow.Modify("t_storage.text='" + strStoreRoomName + "'");

            m_objViewer.datWindow.SetRedrawOff();
            m_objViewer.datWindow.Retrieve(dtbAccou);
            m_objViewer.datWindow.SetRedrawOn();
            m_objViewer.datWindow.Refresh();
               
        }
        #endregion
    }
}



