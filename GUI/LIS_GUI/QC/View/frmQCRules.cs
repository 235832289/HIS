using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmQCRules : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        #region Contruct
        public frmQCRules()
        {
            InitializeComponent();
        }
        #endregion

        #region 一般设置

        #region 快捷键设置

        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            //if (p_eumKeyCode == Keys.F4)
            //{
            //    if (this.m_btnQuery.Enabled == true
            //        && this.m_btnQuery.Visible == true)
            //    {
            //        this.m_btnQuery_Click(this.m_btnQuery, null);
            //    }
            //}
            //else if (p_eumKeyCode == Keys.F8)
            //{
            //    if (this.btnPrint.Enabled == true
            //        && this.btnPrint.Visible == true)
            //    {
            //        this.btnPrint_Click(this.btnPrint, null);
            //    }
            //}
            //else if (p_eumKeyCode == Keys.F3 && this.m_btnPreference.Enabled && m_btnPreference.Visible)//保存
            //{
            //    this.m_btnPreference_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F5 && this.m_btnPrintReport.Enabled && m_btnPrintReport.Visible)//读卡
            //{
            //    this.m_btnPrintReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F6 && this.m_btnPreviewReport.Enabled && m_btnPreviewReport.Visible)		//退出
            //{
            //    this.m_btnPreviewReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F9 && this.m_btnConfirmReport.Enabled && m_btnConfirmReport.Visible)		//清除
            //{
            //    this.m_btnConfirmReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F10 && this.m_btnSaveReport.Enabled && m_btnSaveReport.Visible)//手输和读卡机切换
            //{
            //    this.m_btnSaveReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F12 && this.m_btnDelete.Enabled && m_btnDelete.Visible)//手输和读卡机切换
            //{
            //    this.m_btnDelete_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F8 && this.m_btnNewApp.Enabled && m_btnNewApp.Visible)//手输和读卡机切换
            //{
            //    this.m_btnNewApp_Click(null, null);
            //}
            //			else if(p_eumKeyCode==Keys.F12 && this.m_btnInputSwitch.Enabled && m_btnInputSwitch.Visible)//手输和读卡机切换
            //			{
            //				this.m_btnInputSwitch_Click(null,null);
            //			}
        }

        #endregion

        private void frmQCRules_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            base.m_mthSetKeyTab(e);
        }

        #endregion

        private void frmQCRules_Load(object sender, EventArgs e)
        {
            m_mthLoadRules();
            this.m_cboTypeFlag.SelectedIndex = 0;
            this.m_mthSetEnter2Tab(new Control[] { this.m_txtFormula });
        }

        bool m_blnNewRule = false;

        //加载数据和填充列表
        private void m_mthLoadRules()
        {
            Cursor.Current = Cursors.WaitCursor;

            //加载数据
            clsLisQCRuleVO[] objRulesArr = null;
            clsTmdQCRulesSmp.s_object.m_lngFind(out objRulesArr);
            if (objRulesArr == null)
                objRulesArr = new clsLisQCRuleVO[0];
            m_lsvRules.Tag = objRulesArr;

            //填充列表
            m_mthShowRulesList(objRulesArr);

            Cursor.Current = Cursors.Default;
        }

        //填充列表
        private void m_mthShowRulesList(clsLisQCRuleVO[] objRulesArr)
        {
            this.m_lsvRules.BeginUpdate();//开始更新列表
            this.m_lsvRules.Items.Clear();

            foreach (clsLisQCRuleVO rule in objRulesArr)
            {
                ListViewItem item = m_mthlsvItemAddObject(rule);
                item.Tag = rule;
                this.m_lsvRules.Items.Add(item);
            }

            //重置状态标志
            this.m_blnNewRule = false;
            //清空明细
            m_mthRulesDetailClear();

            this.m_lsvRules.EndUpdate();//结束更新列表
        }

        //列表选定项变更
        private void m_lsvRules_Click(object sender, EventArgs e)
        {
            if (this.m_lsvRules.FocusedItem == null)
                return;
            //变更状态标志
            this.m_blnNewRule = false;

            clsLisQCRuleVO objRule = (clsLisQCRuleVO)this.m_lsvRules.FocusedItem.Tag;

            m_mthControlsDisplayVOValue(objRule);
        }

        //清空明细
        private void m_mthRulesDetailClear()
        {
            this.m_txtRuleName.Clear();
            this.m_txtRuleAliasName.Clear();
            this.m_txtRuleDesc.Clear();
            this.m_txtFormula.Clear();
            this.m_txtSummary.Clear();
            this.m_chkDefaultFlag.Checked = false;
            this.m_cboTypeFlag.SelectedIndex = 0;
        }

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            //使当前ListView具有焦点的行失去焦点
            if (this.m_lsvRules.FocusedItem != null)
            {
                this.m_lsvRules.FocusedItem.Selected = false;
                this.m_lsvRules.FocusedItem.Focused = false;
            }

            //清空明细
            m_mthRulesDetailClear();

            //设置光标焦点
            this.m_txtRuleName.Focus();

            //设置新增标志
            this.m_blnNewRule = true;
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
             if (this.m_lsvRules.FocusedItem == null
                && !this.m_blnNewRule)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_btnNew.Enabled = false;

            if (this.m_blnNewRule)
            {//新增的保存
                clsLisQCRuleVO objRule = new clsLisQCRuleVO();
                m_mthBindControlValueToObj(objRule);
                long lngRes = clsTmdQCRulesSmp.s_object.m_lngInsert(objRule);
                if (lngRes > 0)
                {//成功
                    //更新状态标志
                    this.m_blnNewRule = false;
                    //加入到集合
                    clsLisQCRuleVO[] objRuleArr = (clsLisQCRuleVO[])this.m_lsvRules.Tag;
                    clsLisQCRuleVO[] objRuleNewArr = new clsLisQCRuleVO[objRuleArr.Length + 1];
                    objRuleArr.CopyTo(objRuleNewArr, 0);
                    objRuleNewArr[objRuleNewArr.Length - 1] = objRule;
                    this.m_lsvRules.Tag = objRuleNewArr;
                    //添加新项
                    ListViewItem item = new ListViewItem(objRule.m_strName);
                    //item中展示
                    item=m_mthlsvItemAddObject(objRule);
                    item.Tag = objRule;
                    this.m_lsvRules.Items.Add(item);
                    item.Selected = true;
                    item.Focused = true;
                    this.m_lsvRules_Click(null, null);
                }
                else
                {//失败
                    clsCommonDialog.m_mthShowDBError();
                }
                this.m_btnNew.Enabled = true;
            }
            else
            {//修改的保存
                clsLisQCRuleVO objRule = (clsLisQCRuleVO)this.m_lsvRules.FocusedItem.Tag;

                clsLisQCRuleVO objNewRule = new clsLisQCRuleVO();
                objRule.m_mthCopyTo(objNewRule);

                //Vo获取控件的值
                m_mthBindControlValueToObj(objNewRule);
                
                long lngRes = clsTmdQCRulesSmp.s_object.m_lngUpdate(objNewRule);

                if (lngRes > 0)
                {//成功
                    objNewRule.m_mthCopyTo(objRule);
                    m_mthlsvItemDisplayObject(this.m_lsvRules.FocusedItem,objRule);
                }
                else
                {//失败
                    clsCommonDialog.m_mthShowDBError();
                }
            }
            this.m_btnNew.Enabled = true;
            this.m_btnSave.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (this.m_lsvRules.FocusedItem == null)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_lsvRules.Enabled = false;

            clsLisQCRuleVO objRule = (clsLisQCRuleVO)this.m_lsvRules.FocusedItem.Tag;

            long lngRes = clsTmdQCRulesSmp.s_object.m_lngDelete(objRule.m_intSeq);

            if (lngRes > 0)
            {//成功
                int intIdx = this.m_lsvRules.FocusedItem.Index;
                this.m_lsvRules.FocusedItem.Remove();

                //设置新的具有焦点的 ListView 项
                if (intIdx < this.m_lsvRules.Items.Count)
                {
                    this.m_lsvRules.Items[intIdx].Selected = true;
                    this.m_lsvRules.Items[intIdx].Focused = true;
                    this.m_lsvRules_Click(null, null);
                }
                else if (intIdx - 1 >= 0)
                {
                    this.m_lsvRules.Items[intIdx - 1].Selected = true;
                    this.m_lsvRules.Items[intIdx - 1].Focused = true;
                    this.m_lsvRules_Click(null, null);
                }
            }
            else
            {//失败
                clsCommonDialog.m_mthShowDBError();
            }

            //m_mthLoadRules();
            this.m_lsvRules.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        #region 辅助方法
        /// <summary>
        /// 控件展示VO中的值
        /// </summary>
        /// <param name="objRule">一个VO的实例</param>
        private void m_mthControlsDisplayVOValue(clsLisQCRuleVO objRule)
        {
            this.m_txtRuleName.Text = objRule.m_strName;
            this.m_txtRuleAliasName.Text = objRule.m_strAlias;
            this.m_txtRuleDesc.Text = objRule.m_strDesc;
            this.m_txtFormula.Text = objRule.m_strFormula;
            this.m_txtSummary.Text = objRule.m_strSummary;
            this.m_chkDefaultFlag.Checked = objRule.m_enmDefaultflag == enmQCRuleDefault.YEA ? true : false;
            this.m_cboTypeFlag.SelectedIndex = objRule.m_enmWarnType == enmQCRuleWarnLevel.Error ? 0 : 1;
        }

        /// <summary>
        /// listView中的子项展示VO
        /// </summary>
        /// <param name="rule">一个规则实例</param>
        /// <returns></returns>
        private static ListViewItem m_mthlsvItemAddObject(clsLisQCRuleVO rule)
        {
            ListViewItem item = new ListViewItem(rule.m_strName);
            item.SubItems.Add(rule.m_strAlias);
            item.SubItems.Add(rule.m_strDesc);
            item.SubItems.Add(rule.m_strFormula);
            item.SubItems.Add(rule.m_strSummary);
            item.SubItems.Add(rule.m_enmDefaultflag == enmQCRuleDefault.YEA ? "是" : "否");
            item.SubItems.Add(rule.m_enmWarnType == enmQCRuleWarnLevel.Error ? "失控" : "警告");
            return item;
        }

        /// <summary>
        /// 控件赋值给Vo
        /// </summary>
        /// <param name="objRule">赋值的实例</param>
        private void m_mthBindControlValueToObj(clsLisQCRuleVO objRule)
        {
            objRule.m_strName = this.m_txtRuleName.Text.Trim();
            objRule.m_strAlias = this.m_txtRuleAliasName.Text.Trim();
            objRule.m_strDesc = this.m_txtRuleDesc.Text.Trim();
            objRule.m_strFormula = this.m_txtFormula.Text.Trim();
            objRule.m_strSummary = this.m_txtSummary.Text.Trim();
            objRule.m_enmDefaultflag = (enmQCRuleDefault)Convert.ToInt32(this.m_chkDefaultFlag.Checked);
            objRule.m_enmWarnType = m_cboTypeFlag.SelectedIndex == 0 ? enmQCRuleWarnLevel.Error : enmQCRuleWarnLevel.Warning;
        }

        /// <summary>
        /// ListView中的ListViewItem中展示
        /// VO
        /// </summary>
        /// <param name="item"></param>
        /// <param name="objRule"></param>
        private void m_mthlsvItemDisplayObject(ListViewItem item, clsLisQCRuleVO objRule)
        {
            item.Text = objRule.m_strName;
            item.SubItems[1].Text = objRule.m_strAlias;
            item.SubItems[2].Text = objRule.m_strDesc;
            item.SubItems[3].Text = objRule.m_strFormula;
            item.SubItems[4].Text = objRule.m_strSummary;
            item.SubItems[5].Text = objRule.m_enmDefaultflag == enmQCRuleDefault.YEA ? "是" : "否";
            item.SubItems[6].Text = objRule.m_enmWarnType == enmQCRuleWarnLevel.Error ? "失控" : "警告";
        } 
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}