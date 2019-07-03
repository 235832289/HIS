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
    public partial class frmAccount : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// 帐务期结转内容

        /// </summary>
        internal clsMS_AccountPeriodVO m_objAccPe = null;
        /// <summary>
        /// 当前帐表内容
        /// </summary>
        internal clsMS_Account m_objCurrentAccount = null;
        /// <summary>
        /// 是否已获取结转数据

        /// </summary>
        private bool m_blnHasGenerated = false;
        /// <summary>
        /// 提示必须对未审核单据审核后，是否有重新查询生成帐本金额

        /// </summary>
        private bool m_blhHasReSearch = false;
        #endregion

        #region 构造函数

        /// <summary>
        /// 帐务期结转

        /// </summary>
        private frmAccount()
        {
            InitializeComponent();

            m_txtBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
           
            m_txtEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_txtEndDate.Enabled = false;

            m_mthInitJumpControls();
        }

        /// <summary>
        /// 帐务期结转

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBeginDate">帐务期开始时间</param>
        public frmAccount(string p_strStorageID, DateTime p_dtmBeginDate)
            : this()
        {
            int intGetAccountDate;
            m_strStorageID = p_strStorageID;
            ((clsCtl_Account)objController).m_lngGetAccountDate(out intGetAccountDate);
            m_txtBeginDate.Text = p_dtmBeginDate.ToString("yyyy年MM月dd日 HH:mm:ss");
            //m_txtEndDate.Text = p_dtmBeginDate.AddMonths(intGetAccountDate).AddSeconds(-1).ToString("yyyy年MM月dd日") + DateTime.Now.ToString(" HH:mm:ss");
            m_txtEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        /// <summary>
        /// 帐务期结转

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAP">帐务期结转内容</param>
        public frmAccount(string p_strStorageID, clsMS_AccountPeriodVO p_objAP)
            : this()
        {
            m_strStorageID = p_strStorageID;
            m_objAccPe = p_objAP;

            ((clsCtl_Account)objController).m_mthSetDataToUI(p_objAP);
            m_blnHasGenerated = true;
        } 
        #endregion

        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_Account();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 控件跳转及活动背景色
        /// </summary>
        private void m_mthInitJumpControls()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthJumpControl(this, new Control[] {
                m_txtBEGINCALLFIGURE,m_txtBEGINWHOLESALEFIGURE,m_txtBEGINRETAILFIGURE,m_txtINSTORAGECALLFIGURE,m_txtINSTORAGWHOLESALEFIGURE,m_txtINSTORAGERETAILFIGURE,
                m_txtOUTSTORAGECALLFIGURE,m_txtOUTSTORAGEWHOLESALEFIGURE,m_txtOUTSTORAGERETAILFIGURE,m_txtOUTRETURNCALLFIGURE,m_txtOUTRETURNWHOLESALEFIGURE,m_txtOUTRETURNRETAILFIGURE,
                m_txtINRETURNCALLFIGURE,m_txtINRETURNWHOLESALEFIGURE,m_txtINRETURNRETAILFIGURE,m_txtREPEALCALLFIGURE,m_txtREPEALWHOLESALEFIGURE,m_txtREPEALRETAILFIGURE,
                m_txtCHECKCALLFIGURE,m_txtCHECKWHOLESALEFIGURE,m_txtCHECKRETAILFIGURE,m_txtADJUSTCALLFIGURE,m_txtADJUSTWHOLESALEFIGURE,m_txtADJUSTRETAILFIGURE,
                m_txtENDCALLFIGURE,m_txtENDWHOLESALEFIGURE,m_txtENDRETAILFIGURE}, Keys.Enter, true);

            objCtl.m_mthSetControlHighLight(this, Color.Moccasin);
            objCtl.m_mthSelectAllText(this);
        } 
        #endregion

        #region 事件
        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            if (m_cmdAccount.Enabled)
            {
                if (!m_blnHasGenerated)
                {
                    MessageBox.Show("请先查询获取帐表所需数据", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        string strHintText= string.Empty;
                        ((clsCtl_Account)objController).m_mthCheckHasUnCommitRecord(out strHintText);
                        if (!string.IsNullOrEmpty(strHintText))
                        {
                            m_blhHasReSearch = false;
                            MessageBox.Show("本帐务期内以下单据存在未审核记录，不能继续帐务结转操作" + Environment.NewLine + strHintText, "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        string[] strChittyID = null;
                        Int64[] intSeriesID = null;
                        ((clsCtl_Account)objController).m_mthCheckHasUnConfirmAccount(out strChittyID, out intSeriesID);
                        if (strChittyID != null && strChittyID.Length > 0)
                        {
                            DialogResult drResult = MessageBox.Show("在此帐务期内存在未入帐记录，是否入帐?", "帐务期结转", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (drResult == DialogResult.No)
                            {
                                MessageBox.Show("结转失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            lngRes = ((clsCtl_Account)objController).m_lngSetAccount(strChittyID, intSeriesID);
                            if (lngRes <= 0)
                            {
                                MessageBox.Show("结转失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }

                        if (!m_blhHasReSearch)//提示必须对未审核单据审核后，未重新查询生成帐本金额

                        {
                            MessageBox.Show("重新审核单据后帐本金额发生改变，请重新查询生成帐本", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        this.Cursor = Cursors.WaitCursor;
                        lngRes = ((clsCtl_Account)objController).m_lngSaveAccount();
                    }
                    catch (Exception Ex)
                    {
                        string strEx = Ex.Message;
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }

                    if (lngRes <= 0)
                    {
                        MessageBox.Show("保存帐表失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        m_cmdAccount.Enabled = false;
                        DialogResult drResult = MessageBox.Show("保存帐表成功，是否关闭当前窗体?", "帐务期结转", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (drResult == DialogResult.No)
                        {
                            m_cmdOK.Enabled = false;
                            return;
                        }
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }

            this.Close();
        }

        private void m_cmdAccount_Click(object sender, EventArgs e)
        {
            DateTime dtmBegin = Convert.ToDateTime(m_txtBeginDate.Text);
            DateTime dtmEnd = Convert.ToDateTime(m_txtEndDate.Text);

            if (dtmBegin > dtmEnd)
            {
                MessageBox.Show("帐务期开始日期不能大于帐务期结束日期", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            m_pnlWaiting.Visible = true;
            Application.DoEvents();
            m_bgwGenerateAccount.RunWorkerAsync();
        }

        private void m_bgwGenerateAccount_DoWork(object sender, DoWorkEventArgs e)
        {
            clsMS_Account objAccount = null;
            ((clsCtl_Account)objController).m_mthGenerateAccount(out objAccount);
            e.Result = objAccount;
        }

        private void m_bgwGenerateAccount_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_pnlWaiting.Visible = false;
            if (e.Result == null)
            {
                MessageBox.Show("帐务结转失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsMS_Account objAccount = e.Result as clsMS_Account;
            if (objAccount == null)
            {
                MessageBox.Show("帐务结转失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            m_objCurrentAccount = objAccount;
            ((clsCtl_Account)objController).m_mthSetAccountToUI(objAccount);
            m_blnHasGenerated = true;
            m_blhHasReSearch = true;
        }

        private void m_cmdValidate_Click(object sender, EventArgs e)
        {
            if (m_blnHasGenerated)
            {
                ((clsCtl_Account)objController).m_mthValidateData();
            }
            else
            {
                MessageBox.Show("请先查询获取帐表所需数据", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        } 
        #endregion

        private void frmAccount_Load(object sender, EventArgs e)
        {

        }
    }
}