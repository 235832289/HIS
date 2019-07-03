using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 帐务期结转

    /// </summary>
    public class clsCtl_Account : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_Account m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmAccount m_objViewer;
        /// <summary>
        /// 当前结转帐本明细序列
        /// </summary>
        private long[] m_lngSEQArr = null;

        public clsCtl_Account()
        {
            m_objDomain = new clsDcl_Account();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAccount)frmMDI_Child_Base_in;
        }
        #endregion

        #region 设置数据至界面

        /// <summary>
        /// 设置数据至界面
        /// </summary>
        /// <param name="p_objAccPe">帐务期结转内容</param>
        internal void m_mthSetDataToUI(clsMS_AccountPeriodVO p_objAccPe)
        {
            if (p_objAccPe == null)
            {
                return;
            }

            m_objViewer.m_txtBeginDate.Text = p_objAccPe.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_objViewer.m_txtEndDate.Text = p_objAccPe.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_objViewer.m_txtComment.Text = p_objAccPe.m_strCOMMENT_VCHR;

            //m_objViewer.m_dtpEndDate.ReadOnly = true;
            m_objViewer.m_txtComment.ReadOnly = true;
            m_objViewer.m_cmdAccount.Enabled = false;
            m_objViewer.m_cmdOK.Enabled = false;

            clsMS_Account objAcc = null;
            long lngRes = m_objDomain.m_lngGetAccout(m_objViewer.m_strStorageID, p_objAccPe.m_strACCOUNTID_CHR, out objAcc);
            if (objAcc == null)
            {
                return;
            }

            m_objViewer.m_objCurrentAccount = objAcc;
            m_mthSetAccountToUI(objAcc);
        } 
        #endregion

        #region 设置帐表内容至界面

        /// <summary>
        /// 设置帐表内容至界面

        /// </summary>
        /// <param name="p_objAccount"></param>
        internal void m_mthSetAccountToUI(clsMS_Account p_objAccount)
        {
            if (p_objAccount == null)
            {
                return;
            }

            m_objViewer.m_txtADJUSTCALLFIGURE.Text = p_objAccount.m_dblADJUSTCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtADJUSTRETAILFIGURE.Text = p_objAccount.m_dblADJUSTRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtADJUSTWHOLESALEFIGURE.Text = p_objAccount.m_dblADJUSTWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtBEGINCALLFIGURE.Text = p_objAccount.m_dblBEGINCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtBEGINRETAILFIGURE.Text = p_objAccount.m_dblBEGINRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtBEGINWHOLESALEFIGURE.Text = p_objAccount.m_dblBEGINWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtCHECKCALLFIGURE.Text = p_objAccount.m_dblCHECKCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtCHECKRETAILFIGURE.Text = p_objAccount.m_dblCHECKRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtCHECKWHOLESALEFIGURE.Text = p_objAccount.m_dblCHECKWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtENDCALLFIGURE.Text = p_objAccount.m_dblENDCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtENDRETAILFIGURE.Text = p_objAccount.m_dblENDRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtENDWHOLESALEFIGURE.Text = p_objAccount.m_dblENDWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtINRETURNCALLFIGURE.Text = p_objAccount.m_dblINRETURNCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtINRETURNRETAILFIGURE.Text = p_objAccount.m_dblINRETURNRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtINRETURNWHOLESALEFIGURE.Text = p_objAccount.m_dblINRETURNWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtINSTORAGECALLFIGURE.Text = p_objAccount.m_dblINSTORAGECALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtINSTORAGERETAILFIGURE.Text = p_objAccount.m_dblINSTORAGERETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtINSTORAGWHOLESALEFIGURE.Text = p_objAccount.m_dblINSTORAGWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtOUTRETURNCALLFIGURE.Text = p_objAccount.m_dblOUTRETURNCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtOUTRETURNRETAILFIGURE.Text = p_objAccount.m_dblOUTRETURNRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtOUTRETURNWHOLESALEFIGURE.Text = p_objAccount.m_dblOUTRETURNWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtOUTSTORAGECALLFIGURE.Text = p_objAccount.m_dblOUTSTORAGECALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtOUTSTORAGERETAILFIGURE.Text = p_objAccount.m_dblOUTSTORAGERETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtOUTSTORAGEWHOLESALEFIGURE.Text = p_objAccount.m_dblOUTSTORAGEWHOLESALEFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtREPEALCALLFIGURE.Text = p_objAccount.m_dblREPEALCALLFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtREPEALRETAILFIGURE.Text = p_objAccount.m_dblREPEALRETAILFIGURE_INT.ToString("0.0000");
            m_objViewer.m_txtREPEALWHOLESALEFIGURE.Text = p_objAccount.m_dblREPEALWHOLESALEFIGURE_INT.ToString("0.0000");
        } 
        #endregion

        #region 生成帐务
        /// <summary>
        /// 生成帐务
        /// </summary>
        /// <param name="p_objAccount">帐表内容</param>
        internal void m_mthGenerateAccount(out clsMS_Account p_objAccount)
        {
            p_objAccount = null;
            m_lngSEQArr = null;

            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginDate.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndDate.Text);

            long lngRes = m_objDomain.m_lngGenarateAccount(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, out p_objAccount, out m_lngSEQArr);
        } 
        #endregion

        #region 保存帐表
        /// <summary>
        /// 保存帐表
        /// </summary>
        internal long m_lngSaveAccount()
        {
            if (m_objViewer.m_objCurrentAccount == null)
            {
                MessageBox.Show("请先生成帐务结转数据", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginDate.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndDate.Text);

            if (dtmBegin > dtmEnd)
            {
                MessageBox.Show("帐务期开始日期不能大于帐务期结束日期", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            clsMS_AccountPeriodVO objApVO = new clsMS_AccountPeriodVO();
            objApVO.m_dtmENDTIME_DAT = dtmEnd;
            objApVO.m_dtmSTARTTIME_DAT = dtmBegin;
            objApVO.m_dtmTRANSFERTIME_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            objApVO.m_strCOMMENT_VCHR = m_objViewer.m_txtComment.Text;
            objApVO.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            m_objViewer.m_objCurrentAccount.m_strCOMMENT_VCHR = m_objViewer.m_txtComment.Text;

            long lngRes = 0;
            try
            {
                string strAccountID = string.Empty;
                long lngMainSEQ = 0;
                long lngSubSEQ = 0;
                lngRes = m_objDomain.m_lngSaveAccount(objApVO, m_objViewer.m_objCurrentAccount,m_lngSEQArr,m_objViewer.LoginInfo.m_strEmpID, out strAccountID, out lngMainSEQ, out lngSubSEQ);

                if (lngRes > 0)
                {
                    objApVO.m_strACCOUNTID_CHR = strAccountID;
                    objApVO.m_lngSERIESID_INT = lngMainSEQ;
                    m_objViewer.m_objAccPe = objApVO;

                    m_objViewer.m_objCurrentAccount.m_strACCOUNTID = strAccountID;
                    m_objViewer.m_objCurrentAccount.m_lngSERIESID_INT = lngSubSEQ;
                }
            }
            catch (Exception ex)
            {
                lngRes = -1;
            }            

            return lngRes;
        } 
        #endregion

        #region 检查是否有未确定入帐的记录
        /// <summary>
        /// 检查是否有未确定入帐的记录
        /// </summary>
        /// <param name="p_strChittyIDArr">单据号</param>
        internal void m_mthCheckHasUnConfirmAccount(out string[] p_strChittyIDArr, out Int64[] p_intSeriesIDArr)
        {
            p_strChittyIDArr = null;

            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginDate.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndDate.Text);

            long lngRes = m_objDomain.m_lngCheckHasUnConfirmAccount(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, out p_strChittyIDArr, out p_intSeriesIDArr);
        } 
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        /// <param name="p_strChittyIDArr">单据号</param>
        /// <param name="p_intSeriesIDArr">序列号</param>
        internal long m_lngSetAccount(string[] p_strChittyIDArr,Int64[] p_intSeriesIDArr)
        {
            if (p_strChittyIDArr == null || p_strChittyIDArr.Length == 0)
            {
                return -1;
            }

            long lngRes = 0;

            try
            {
                lngRes = m_objDomain.m_lngSetAccount(m_objViewer.LoginInfo.m_strEmpID, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")), p_strChittyIDArr, m_objViewer.m_strStorageID, p_intSeriesIDArr);
            }
            catch (Exception objEx)
            {
                lngRes = -1;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            } 
            
            return lngRes;
        } 
        #endregion

        #region 验证数据
        /// <summary>
        /// 验证数据
        /// </summary>
        internal void m_mthValidateData()
        {
            double dblTemp = 0d;
            string strCallHint = string.Empty;//购入金额是否正确

            string strWholeHint = string.Empty;//批发金额是否正确

            string strRetailHint = string.Empty;//零售金额是否正确

            #region 购入金额比较
            double dblCallMoney = 0d;//购入金额
            if (double.TryParse(m_objViewer.m_txtADJUSTCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtBEGINCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtCHECKCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtINRETURNCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtINSTORAGECALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtOUTRETURNCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtOUTSTORAGECALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtREPEALCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtENDCALLFIGURE.Text, out dblTemp))
            {
                dblCallMoney = Math.Round(dblCallMoney, 4);
                dblTemp = Math.Round(dblTemp, 4);
                if (dblCallMoney == dblTemp)
                {
                    strCallHint = "相等";
                }
                else
                {
                    strCallHint = "不等，期末金额与帐本明细相差" + (dblTemp - dblCallMoney).ToString("0.0000");
                }
            }
            else
            {
                strCallHint = "不等";
            } 
            #endregion

            #region 批发金额比较
            double dblWholeMoney = 0d;
            if (double.TryParse(m_objViewer.m_txtADJUSTWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtBEGINWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtCHECKWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtINRETURNWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtINSTORAGWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtOUTRETURNWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtOUTSTORAGEWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtREPEALWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtENDWHOLESALEFIGURE.Text, out dblTemp))
            {
                dblWholeMoney = Math.Round(dblWholeMoney, 4);
                dblTemp = Math.Round(dblTemp, 4);
                if (dblWholeMoney == dblTemp)
                {
                    strWholeHint = "相等";
                }
                else
                {
                    strWholeHint = "不等，期末金额与帐本明细相差" + (dblTemp - dblWholeMoney).ToString("0.0000");
                }
            }
            else
            {
                strWholeHint = "不等";
            } 
            #endregion

            #region 零售金额比较
            double dblRetailMoney = 0d;
            if (double.TryParse(m_objViewer.m_txtADJUSTRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtBEGINRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtCHECKRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtINRETURNRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtINSTORAGERETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney += dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtOUTRETURNRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtOUTSTORAGERETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtREPEALRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney -= dblTemp;
            }
            if (double.TryParse(m_objViewer.m_txtENDRETAILFIGURE.Text, out dblTemp))
            {
                dblRetailMoney = Math.Round(dblRetailMoney, 4);
                dblTemp = Math.Round(dblTemp, 4);
                if (dblRetailMoney == dblTemp)
                {
                    strRetailHint = "相等";
                }
                else
                {
                    strRetailHint = "不等，期末金额与帐本明细相差" + (dblTemp - dblRetailMoney).ToString("0.0000");
                }
            }
            else
            {
                strRetailHint = "不等";
            } 
            #endregion

            StringBuilder stbHint = new StringBuilder(50);
            stbHint.Append("购入金额：");
            stbHint.Append(strCallHint);
            stbHint.Append(Environment.NewLine);
            stbHint.Append("批发金额：");
            stbHint.Append(strWholeHint);
            stbHint.Append(Environment.NewLine);
            stbHint.Append("零售金额：");
            stbHint.Append(strRetailHint);
            MessageBox.Show(stbHint.ToString(), "帐务金额验证", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 检查开帐务期内是否存在未审核的记录
        /// <summary>
        /// 检查开帐务期内是否存在未审核的记录
        /// </summary>
        /// <param name="p_strHintText">存在未审核记录的单据名称(类型)</param>
        internal void m_mthCheckHasUnCommitRecord(out string p_strHintText)
        {
            DateTime dtmBegin = Convert.ToDateTime(m_objViewer.m_txtBeginDate.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_objViewer.m_txtEndDate.Text);

            long lngRes = m_objDomain.m_lngCheckHasUnCommitRecord(dtmBegin,dtmEnd, m_objViewer.m_strStorageID, out p_strHintText);
        } 
        #endregion

        internal int m_lngGetAccountDate(out int p_intGetAccountDate)
        {
            m_objDomain.m_lngGetAccountDate(out p_intGetAccountDate);
            return p_intGetAccountDate;
        }
    }
}
