using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房帐务期结转界面
    /// </summary>
    public partial class frmAccount : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strDrugStoreid = string.Empty;
        /// <summary>
        /// 帐务期结转内容
        /// </summary>
        internal clsDS_AccountPeriodVO m_objAccPe = null;
        /// <summary>
        /// 当前帐表内容
        /// </summary>
        internal clsDS_Account m_objCurrentAccount = null;
        /// <summary>
        /// 是否已获取结转数据
        /// </summary>
        private bool m_blnHasGenerated = false;
        /// <summary>
        /// 提示必须对未审核单据审核后，是否有重新查询生成帐本金额
        /// </summary>
        private bool m_blhHasReSearch = false;
        /// <summary>
        /// 0-库存模式；1-盘点模式
        /// </summary>
        public int m_intTransferMode = 0;
        /// <summary>
        /// 本期盘点单据序列号
        /// </summary>
        public long m_lngCheckSeqid = 0;
        #endregion
        #region 构造函数

        /// <summary>
        /// 帐务期结转

        /// </summary>
        private frmAccount()
        {
            InitializeComponent();
            DateTime m_dtmNow = clsPub.CurrentDateTimeNow;
            this.m_txtEndTime.Text = m_dtmNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            this.m_txtBeginTime.Text = m_dtmNow.AddMonths(-1).ToString("yyyy年MM月dd日 HH:mm:ss");            
        }

        /// <summary>
        /// 帐务期结转
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtmBeginDate">帐务期开始时间</param>
        public frmAccount(string p_strStorageID, DateTime p_dtmBeginDate)
            : this()
        {
            DateTime m_dtmAccountEndTime = DateTime.MinValue;
            m_strDrugStoreid = p_strStorageID;
            ((clsCtl_Account)objController).m_lngGetAccountEndTime(m_strDrugStoreid,p_dtmBeginDate,out m_dtmAccountEndTime,out m_lngCheckSeqid);
            this.m_txtBeginTime.Text = p_dtmBeginDate.ToString("yyyy年MM月dd日 HH:mm:ss");
            if (m_dtmAccountEndTime == DateTime.MinValue)
            {
                if (DialogResult.OK == MessageBox.Show("本期没有生成任何盘点单,是否继续进行帐务期结转？", "药房帐务期结转", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                {
                    this.m_txtEndTime.Text = clsPub.ServerDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.m_txtEndTime.Text = m_dtmAccountEndTime.ToString("yyyy年MM月dd日 HH:mm:ss");
                this.m_intTransferMode = 1;
            }
        }

        /// <summary>
        /// 帐务期结转

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objAP">帐务期结转内容</param>
        public frmAccount(string p_strStorageID, clsDS_AccountPeriodVO p_objAP)
            : this()
        {
            m_strDrugStoreid = p_strStorageID;
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
        #endregion
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_bgwGenerateAccount_DoWork_1(object sender, DoWorkEventArgs e)
        {
            clsDS_Account objAccount = null;
            ((clsCtl_Account)objController).m_mthGenerateAccount(out objAccount);
            e.Result = objAccount;
        }

        private void m_bgwGenerateAccount_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Result == null)
            {
                MessageBox.Show("帐务结转失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsDS_Account objAccount = e.Result as clsDS_Account;
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

        private void m_btnGenerate_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("是否确定要进行帐务期结转？", "帐务期结转", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
            {
                long lngRes = 0;
                if (this.m_btnQuery.Enabled)
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
                            string strHintText = string.Empty;
                            ((clsCtl_Account)objController).m_mthCheckHasUnCommitRecord(out strHintText);
                            if (!string.IsNullOrEmpty(strHintText))
                            {
                                m_blhHasReSearch = false;
                                MessageBox.Show("本帐务期内以下单据存在未审核记录，不能继续帐务结转操作" + Environment.NewLine + strHintText, "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            string[] strChittyID = null;
                            ((clsCtl_Account)objController).m_mthCheckHasUnConfirmAccount(out strChittyID);
                            if (strChittyID != null && strChittyID.Length > 0)
                            {
                                DialogResult drResult = MessageBox.Show("在此帐务期内存在未入帐记录，是否入帐?", "帐务期结转", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (drResult == DialogResult.No)
                                {
                                    MessageBox.Show("结转失败", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                lngRes = ((clsCtl_Account)objController).m_lngSetAccount(strChittyID);
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
                            this.m_btnGenerate.Enabled = false;
                            DialogResult drResult = MessageBox.Show("保存帐表成功，是否关闭当前窗体?", "帐务期结转", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (drResult == DialogResult.No)
                            {
                                this.m_btnGenerate.Enabled = false;
                                return;
                            }
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                }

                this.Close();
            }
           
        }

        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            DateTime dtmBegin = Convert.ToDateTime(this.m_txtBeginTime.Text);
            DateTime dtmEnd = Convert.ToDateTime(this.m_txtEndTime.Text);

            if (dtmBegin > dtmEnd)
            {
                MessageBox.Show("帐务期开始日期不能大于帐务期结束日期", "帐务期结转", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Application.DoEvents();
            if (!m_bgwGenerateAccount.IsBusy)
            {
                m_bgwGenerateAccount.RunWorkerAsync();
            }
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {

        }

        private void m_btnValid_Click(object sender, EventArgs e)
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

        private void m_lblINSTORAGERETAILFIGURE_INT_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_Account)objController).m_mthPrint();
        }
    }
}