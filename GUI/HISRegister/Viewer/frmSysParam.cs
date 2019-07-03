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
    /// 系统参数设置
    /// </summary>
    public partial class frmSysParam : Form
    {

        public frmSysParam()
        {
            InitializeComponent();
        }

        #region 一般设置

        #region 快捷键设置

        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            //if (m_tabControl.SelectedIndex == 2)
            //{
            //    if (p_eumKeyCode == Keys.F4)
            //    {
            //        m_cmdCDelete_Click(this.m_cmdCMDelete, EventArgs.Empty);
            //    }
            //}
        }

        #endregion

        #endregion

        #region SysParams

        bool m_blnNewSysParams = false;

        //加载数据和填充列表
        private void m_mthLoadSysParams()
        {
            Cursor.Current = Cursors.WaitCursor;

            //加载数据
            clsSysParamVO[] arrSysParams = null;
            clsDcl_SysParamSmp.s_object.m_lngFind(out arrSysParams);
            if (arrSysParams == null)
            {
                arrSysParams = new clsSysParamVO[0];
            }
            m_lsvSysParams.Tag = arrSysParams;

            //填充列表
            m_mthShowSysParamsList(arrSysParams, this.m_chkShowDeleted.Checked);

            Cursor.Current = Cursors.Default;
        }

        //填充列表
        private void m_mthShowSysParamsList(clsSysParamVO[] arrSysParams, bool p_blnDeleted)
        {
            this.m_lsvSysParams.BeginUpdate();//开始更新列表
            this.m_lsvSysParams.Items.Clear();
            if (arrSysParams != null)
            {
                foreach (clsSysParamVO sysParam in arrSysParams)
                {
                    //根据类别过滤需要填充的项
                    if ((p_blnDeleted && (sysParam.m_intStatus == 0))
                        || (!p_blnDeleted && (sysParam.m_intStatus ==1)))
                    {
                        ListViewItem item = new ListViewItem(GetModuleName(sysParam.m_intSysCode));

                        item.SubItems.Add(sysParam.m_strParamCode);
                        item.SubItems.Add(sysParam.m_strParamDesc);
                        item.SubItems.Add(sysParam.m_strParamValue);
                        item.SubItems.Add(sysParam.m_strNote);
                        item.Tag = sysParam;
                        this.m_lsvSysParams.Items.Add(item);
                    }
                }
            }
            //重置状态标志
            this.m_blnNewSysParams = false;
            //清空明细
            m_mthDetailClear();

            this.m_lsvSysParams.EndUpdate();//结束更新列表
        }
       
        //列表选定项变更
        private void m_lsvSysParams_Click(object sender, EventArgs e)
        {
            if (this.m_lsvSysParams.FocusedItem == null)
                return;
            //变更状态标志
            this.m_blnNewSysParams = false;
            this.m_txtPramCode.Enabled = false;

            clsSysParamVO objSysParam = (clsSysParamVO)this.m_lsvSysParams.FocusedItem.Tag;

             this.m_txtPramCode.Text=objSysParam.m_strParamCode;
             this.m_txtParamDesc.Text = objSysParam.m_strParamDesc;
             this.m_txtParamValue.Text = objSysParam.m_strParamValue;
             this.m_txtNote.Text = objSysParam.m_strNote;
             this.m_cboSysModule.SelectedIndex = objSysParam.m_intSysCode;
        }

        //类别变更
        private void m_chkShowDeleted_CheckedChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            m_chkShowDeleted.Enabled = false;

            //为列表填充选定的类别数据
            this.m_mthShowSysParamsList((clsSysParamVO[])this.m_lsvSysParams.Tag, this.m_chkShowDeleted.Checked);

            //根据类别设置控件状态
            this.m_cmdCancelDelete.Visible = this.m_chkShowDeleted.Checked;
            this.m_cmdNew.Visible = !this.m_chkShowDeleted.Checked;
            this.m_cmdSave.Visible = !this.m_chkShowDeleted.Checked;
            this.m_cmdDelete.Visible = !this.m_chkShowDeleted.Checked;
            this.panel1.Enabled = !this.m_chkShowDeleted.Checked;

            if (m_chkShowDeleted.Checked)
            {
                this.m_cmdClose.Location = new Point(77, 73);
            }
            else
            {
                this.m_cmdClose.Location = new Point(142, 73);
            }

            m_chkShowDeleted.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        //恢复
        private void m_cmdCancelDelete_Click(object sender, EventArgs e)
        {
            if (this.m_lsvSysParams.FocusedItem == null
                || this.m_lsvSysParams.FocusedItem.Tag == null)
                return;

            Cursor.Current = Cursors.WaitCursor;
            m_cmdCancelDelete.Enabled = false;

            clsSysParamVO objSysParam = (clsSysParamVO)this.m_lsvSysParams.FocusedItem.Tag;
            clsSysParamVO objCopy = new clsSysParamVO();
            objSysParam.m_mthCopyTo(objCopy);//拷贝到另一个对象
            objCopy.m_intStatus = 1;

            //更新到数据库
            long lngRes = clsDcl_SysParamSmp.s_object.m_lngUpdate(objCopy);

            if (lngRes > 0)
            {//更新成功
                objSysParam.m_intStatus =0;
                int intIdx = this.m_lsvSysParams.FocusedItem.Index;

                this.m_lsvSysParams.FocusedItem.Remove();

                //设置新的具有焦点的 ListView 项
                if (intIdx < this.m_lsvSysParams.Items.Count)
                {
                    this.m_lsvSysParams.Items[intIdx].Selected = true;
                    this.m_lsvSysParams.Items[intIdx].Focused = true;
                    this.m_lsvSysParams_Click(null, null);
                }
                else if (intIdx - 1 >= 0)
                {
                    this.m_lsvSysParams.Items[intIdx - 1].Selected = true;
                    this.m_lsvSysParams.Items[intIdx - 1].Focused = true;
                    this.m_lsvSysParams_Click(null, null);
                }
            }
            else
            {//更新失败
                //clsCommonDialog.m_mthShowDBError();
                MessageBox.Show("删除失败！");
            }

            m_cmdCancelDelete.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        //新增
        private void m_cmdNew_Click(object sender, EventArgs e)
        {
            //使当前ListView具有焦点的行失去焦点
            if (this.m_lsvSysParams.FocusedItem != null)
            {
                this.m_lsvSysParams.FocusedItem.Selected = false;
                this.m_lsvSysParams.FocusedItem.Focused = false;
                this.m_txtPramCode.Enabled = true;
            }

            //清空明细
            m_mthDetailClear();

            //设置光标焦点
            this.m_cboSysModule.Focus();

            //设置新增标志
            this.m_blnNewSysParams = true;
        }

        //清空明细
        private void m_mthDetailClear()
        {
            this.m_cboSysModule.SelectedIndex = 1;
            this.m_txtParamDesc.Text = string.Empty;
            this.m_txtParamValue.Text = string.Empty;
            this.m_txtPramCode.Text = string.Empty;
            this.m_txtNote.Text = string.Empty;

        }

        //保存
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (this.m_lsvSysParams.FocusedItem == null
                && !this.m_blnNewSysParams)
                return;
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdSave.Enabled = false;

            if (this.m_blnNewSysParams)
            {//新增的保存
                clsSysParamVO objSysParam = new clsSysParamVO();

                objSysParam.m_intSysCode = this.m_cboSysModule.SelectedIndex;

                objSysParam.m_strParamCode = this.m_txtPramCode.Text.Trim();
                objSysParam.m_strParamDesc=this.m_txtParamDesc.Text.Trim();
                objSysParam.m_strParamValue=this.m_txtParamValue.Text.Trim();
                objSysParam.m_strNote = this.m_txtNote.Text.Trim();
                objSysParam.m_intStatus = 1;

                long lngRes = clsDcl_SysParamSmp.s_object.m_lngInsert(objSysParam);
                if (lngRes > 0)
                {//成功
                    //更新状态标志
                    this.m_blnNewSysParams = false;
                    //加入到集合
                    clsSysParamVO[] objGroupArr = (clsSysParamVO[])this.m_lsvSysParams.Tag;
                    clsSysParamVO[] objGroupNewArr = new clsSysParamVO[objGroupArr.Length + 1];
                    objGroupArr.CopyTo(objGroupNewArr, 0);
                    objGroupNewArr[objGroupNewArr.Length - 1] = objSysParam;
                    this.m_lsvSysParams.Tag = objGroupNewArr;

                    //添加新项
                    ListViewItem item = new ListViewItem(GetModuleName(objSysParam.m_intSysCode));

                    item.SubItems.Add(objSysParam.m_strParamCode);
                    item.SubItems.Add(objSysParam.m_strParamDesc);
                    item.SubItems.Add(objSysParam.m_strParamValue);
                    item.SubItems.Add(objSysParam.m_strNote);
                    item.Tag = objSysParam;
                    this.m_lsvSysParams.Items.Add(item);

                    item.Selected = true;
                    item.Focused = true;
                    this.m_txtPramCode.Enabled = false;
                    this.m_lsvSysParams_Click(null, null);

                }
                else
                {//失败
                    MessageBox.Show("新增数据失败！");
                }
            }
            else
            {//修改的保存
                clsSysParamVO objSysParams = (clsSysParamVO)this.m_lsvSysParams.FocusedItem.Tag;

                clsSysParamVO objGroup = new clsSysParamVO();
                objSysParams.m_mthCopyTo(objGroup);

                objGroup.m_intSysCode = this.m_cboSysModule.SelectedIndex; 
                objGroup.m_strParamCode = this.m_txtPramCode.Text.Trim();
                objGroup.m_strParamDesc = this.m_txtParamDesc.Text.Trim();
                objGroup.m_strParamValue = this.m_txtParamValue.Text.Trim();
                objGroup.m_strNote = this.m_txtNote.Text.Trim();
                objGroup.m_intStatus = 1;

                long lngRes = clsDcl_SysParamSmp.s_object.m_lngUpdate(objGroup);

                if (lngRes > 0)
                {//成功
                    objGroup.m_mthCopyTo(objSysParams);
                    this.m_lsvSysParams.FocusedItem.Text = GetModuleName(objSysParams.m_intSysCode);
                    this.m_lsvSysParams.FocusedItem.SubItems[1].Text = objSysParams.m_strParamCode;
                    this.m_lsvSysParams.FocusedItem.SubItems[2].Text = objSysParams.m_strParamDesc;
                    this.m_lsvSysParams.FocusedItem.SubItems[3].Text = objSysParams.m_strParamValue;
                    this.m_lsvSysParams.FocusedItem.SubItems[4].Text = objSysParams.m_strNote;

                }
                else
                {//失败
                    MessageBox.Show("修改数据失败！");
                }
                this.m_txtPramCode.Enabled = false;
            }
            this.m_cmdSave.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.m_lsvSysParams.FocusedItem == null)
                return;

            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdDelete.Enabled = false;

            clsSysParamVO objSysParams = (clsSysParamVO)this.m_lsvSysParams.FocusedItem.Tag;
            clsSysParamVO objCopy = new clsSysParamVO();
            objSysParams.m_mthCopyTo(objCopy);
            objCopy.m_intStatus = 0;

            long lngRes = clsDcl_SysParamSmp.s_object.m_lngUpdate(objCopy);

            if (lngRes > 0)
            {//成功
                objSysParams.m_intStatus = 0;
                int intIdx = this.m_lsvSysParams.FocusedItem.Index;

                this.m_lsvSysParams.FocusedItem.Remove();

                //设置新的具有焦点的 ListView 项
                if (intIdx < this.m_lsvSysParams.Items.Count)
                {
                    this.m_lsvSysParams.Items[intIdx].Selected = true;
                    this.m_lsvSysParams.Items[intIdx].Focused = true;
                    this.m_lsvSysParams_Click(null, null);
                }
                else if (intIdx - 1 >= 0)
                {
                    this.m_lsvSysParams.Items[intIdx - 1].Selected = true;
                    this.m_lsvSysParams.Items[intIdx - 1].Focused = true;
                    this.m_lsvSysParams_Click(null, null);
                }
            }
            else
            {//失败
                MessageBox.Show("删除失败！");
            }

            this.m_cmdDelete.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void frmSysParam_Load(object sender, EventArgs e)
        {
            this.m_mthLoadSysParams();
            this.m_txtPramCode.Enabled = false;
        }

        public string GetModuleName(int sysCodeNum)
        {
            string result = string.Empty;
            switch (sysCodeNum)
            {
                case 0: result = "公用"; break;
                case 1: result = "门诊"; break;
                case 2: result = "住院"; break;
                case 3: result = "图文工作站"; break;
                case 4: result = "影像"; break;
                default:
                    break;
            }
            return result;
        }

        private void m_lsvSysParams_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool isAsc = false;
            ListView lsvTemp = m_lsvSysParams;
            if (lsvTemp.Sorting == SortOrder.Ascending)
            {
                lsvTemp.Sorting = SortOrder.Descending;
            }
            else
            {
                lsvTemp.Sorting = SortOrder.Ascending;
                isAsc = true;
            }
            lsvTemp.ListViewItemSorter = new ListViewItemComparer(e.Column, isAsc, lsvTemp);
            lsvTemp.Sort();
        }

        #endregion

        private void buttonXP5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}