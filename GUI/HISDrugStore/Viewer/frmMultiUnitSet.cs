using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;


namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmMultiUnitSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private bool blnisCmdNewOpen = false;
        /// <summary>
        /// 当前修改的药品ID
        /// </summary>
        public string m_strMedicineID = string.Empty;
        public string m_strMedicineName = string.Empty;
        public string m_strMedicineSpec = string.Empty;
        public string m_strProductor = string.Empty;

        public string m_strItemID = string.Empty;

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMultiUnitSet()
        {
            InitializeComponent();

        }
        #endregion

        #region 创建控制层

        /// <summary>
        /// 创建控制层
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_MultiUnitSet();
            this.objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMultiunit_drug_Load(object sender, EventArgs e)
        {
            if (blnisCmdNewOpen)
            {
                blnisCmdNewOpen = false;
                //关闭txtUnitName
                //this.txtUnitName.ReadOnly = true;
            }

            ((clsCtl_MultiUnitSet)objController).m_mthShowSeledMedName();
            ((clsCtl_MultiUnitSet)this.objController).m_mthLoadDvMultiUnit();
            ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
            if (this.dtgMultiUnitList.Rows.Count > 0)
            {
                this.dtgMultiUnitList.Rows[0].Selected = true;
            }
            ((clsCtl_MultiUnitSet)this.objController).m_mthTxtLoadData();

            m_mthSetBtnStatus();
            
        }
        #endregion 
        

        #region 作设置"删除"，"保存"按钮的状态
        /// <summary>
        /// 作设置"删除"，"保存"按钮的状态
        /// </summary>
        private void m_mthSetBtnStatus()
        {
            if (this.dtgMultiUnitList.Rows.Count > 0)
            {
                this.cmdNew.Enabled = true;
                this.cmdDelete.Enabled = true;
                this.cmdSave.Enabled = true;
            }
            else
            {
                this.cmdNew.Enabled = true;
                this.cmdDelete.Enabled = false;
                this.cmdSave.Enabled = false;
            }
        }
        #endregion

        #region 新增按钮事件
        /// <summary>
        /// 新增按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdNew_Click(object sender, EventArgs e)
        {
            if (m_strItemID.Length == 0)
            {
                return;
            }

            if (dtgMultiUnitList.DataSource != null)
            {

                if (!blnisCmdNewOpen)
                {
                    //清空两个textbox的数据
                    ((clsCtl_MultiUnitSet)objController).m_mthClearTXT();
                    //设现在为新增挂起状态
                    this.blnisCmdNewOpen = true;
                    //打开txtUnitName
                    // this.txtUnitName.ReadOnly = false;
                    //打开cmdSave
                    this.cmdSave.Enabled = true;
                    //关闭cmdNew、cmdDelete
                    this.cmdNew.Enabled = false;
                    this.cmdDelete.Enabled = false;
                    this.txtUnitName.Focus();
                }
                else
                {

                }
            }
        }
        #endregion

        #region 点击单位表行事件
        /// <summary>
        /// 点击单位表行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgMultiUnitList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (blnisCmdNewOpen)
            {
                blnisCmdNewOpen = false;
                //关闭txtUnitName
                //this.txtUnitName.ReadOnly = true;
            }
            if (e.RowIndex > -1)
            {               
                this.dtgMultiUnitList.Rows[e.RowIndex].Selected = true;
                ((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
            }
            m_mthSetBtnStatus();
        }
        #endregion

        

        #region 点击放弃按钮事件
        /// <summary>
        /// 点击放弃按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, EventArgs e)
        {

            //关闭新增状态
            this.blnisCmdNewOpen = false;
            //关闭txtUnitName
            //this.txtUnitName.ReadOnly = true;
            ((clsCtl_MultiUnitSet)this.objController).m_mthLoadDvMultiUnit();
            //重新为单位列表绑定数据
            ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
            //重新把单位列表的选择行数据显示在textbox上
            //((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
            m_mthSetBtnStatus();
            ((clsCtl_MultiUnitSet)this.objController).m_mthClearTXT();
            ((clsCtl_MultiUnitSet)this.objController).m_mthTxtLoadData();

        }
        #endregion

        #region 点击退出按钮事件
        /// <summary>
        /// 点击退出按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.dtgMultiUnitList.Dispose();
            this.Close();
            //if (blnisCmdNewOpen)
            //{
            //    MessageBox.Show("现在为新增状态！\n请保存后才离开！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    this.dtgMedicineList.Dispose();
            //    this.dtgMultiUnitList.Dispose();
            //    this.Close();
            //}
        }
        #endregion

        #region 点击删除按钮事件
        /// <summary>
        /// 点击删除按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.cmdSave.Tag == null)
            {
                return;
            }
            if (ckbCurruseFlag.Checked == true)
            {
                MessageBox.Show("该单位是当前药品单位\n请更改药品当前单位后再进行删除操作", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult drIsDel = MessageBox.Show("确实删除该单位?", "删除询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (drIsDel == DialogResult.Cancel)
            {
                return;
            }

            if (((clsCtl_MultiUnitSet)objController).m_blnDeleteMultiUnit())
            {
                //重新为单位列表绑定数据
                ((clsCtl_MultiUnitSet)this.objController).m_mthLoadDvMultiUnit();
                ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
                //重新把单位列表的选择行数据显示在textbox上
                //if (this.dtgMultiUnitList.Rows.Count > 0)
                //{
                //    //this.dtgMultiUnitList.Rows[0].Selected = true;
                //    //((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
                //}
                ((clsCtl_MultiUnitSet)this.objController).m_mthClearTXT();
                m_mthSetBtnStatus();
                this.cmdSave.Tag = null;
                blnisCmdNewOpen = true;
            }
        }
        #endregion

        #region 点击保存按钮事件
        /// <summary>
        /// 点击保存按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, EventArgs e)
        {
            //如果是新增状态
            if (this.blnisCmdNewOpen)
            {
                bool blnIsNum = ((clsCtl_MultiUnitSet)this.objController).m_blnIsNum();
                //判断textbox是否为空,是否符合数据类型
                if (txtUnitName.Text.ToString().Trim().Equals("") || txtPackage.Text.ToString().Trim().Equals("") || blnIsNum)
                {
                    MessageBox.Show("填入信息不完整或者数据格式错误!\n请填写完整", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPackage.Focus();
                }
                else
                {
                    //判断是否设为当前药品单位
                    if (ckbCurruseFlag.Checked == true)
                    {
                        if (((clsCtl_MultiUnitSet)this.objController).m_BlnQueryByIndex() == false)
                        {
                            return;
                        }

                        //把其他的药品设为非当前药品
                        if (((clsCtl_MultiUnitSet)objController).m_lngSetAllCurruseFlag_0ByItemId() > -1)
                        {
                            //调用增新
                            if (((clsCtl_MultiUnitSet)objController).m_blnAddMultiUnit())
                            {
                                //关闭新增状态
                                this.blnisCmdNewOpen = false;
                                //关闭txtUnitName
                                //this.txtUnitName.ReadOnly = true;
                                //重新为单位列表绑定数据
                                ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
                                //重新把单位列表的选择行数据显示在textbox上
                                ((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
                                m_mthSetBtnStatus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("把其他药品单位设为非当前单位失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (((clsCtl_MultiUnitSet)this.objController).m_BlnQueryByIndex() == false)
                        {
                            return;
                        }

                        //如果新增为第1个药品单位，而用户却没有把它设为当前药品。把新增单位设为默认当前药品单位
                        if (this.dtgMultiUnitList.Rows.Count <= 0)
                        {
                            ckbCurruseFlag.Checked = true;
                        }
                        //调用增新
                        if (((clsCtl_MultiUnitSet)objController).m_blnAddMultiUnit())
                        {
                            //关闭新增状态
                            this.blnisCmdNewOpen = false;
                            //关闭txtUnitName
                            //this.txtUnitName.ReadOnly = true;
                            //重新为单位列表绑定数据
                            ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
                            //重新把单位列表的选择行数据显示在textbox上
                            ((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
                            m_mthSetBtnStatus();
                        }
                    }

                }

            }
            //更新数据
            else
            {
                clsMultiunit_drug_VO objTmp = this.cmdSave.Tag as clsMultiunit_drug_VO;
                bool blnCurr = false;
                if (objTmp.m_intCurruseFlag_Int == 1)
                {
                    blnCurr = true;
                }
                else
                {
                    blnCurr = false;
                }
                if (objTmp.m_strUnit == this.txtUnitName.Text.Trim() && objTmp.m_intPackage.ToString() == this.txtPackage.Text
                    && blnCurr == this.ckbCurruseFlag.Checked && objTmp.m_intStauts == this.cboStatus.SelectedIndex)
                {
                    return;
                }

                //作数据判断
                //判断是否设为当前药品单位
                if (ckbCurruseFlag.Checked == true)
                {
                    //if (dtgMultiUnitList.Rows.Count != 1)
                    //{
                        //处理:发生在更新时，当txtUnitName与其中当前药品使用单位相同时引发异常（违反唯一约束）
                        //// 正在处理ing ///////////////////

                        //// 正在处理ing ///////////////////
                        //把其他的药品设为非当前药品
                        if (((clsCtl_MultiUnitSet)objController).m_lngSetAllCurruseFlag_0ByItemId() > -1)
                        {
                            if (((clsCtl_MultiUnitSet)objController).m_blnUpdateMultiUnit())
                            {
                                //更新成功
                                MessageBox.Show("更新成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //重新为单位列表绑定数据
                                ((clsCtl_MultiUnitSet)this.objController).m_mthLoadDvMultiUnit();
                                ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
                                //重新把单位列表的选择行数据显示在textbox上
                                if (this.dtgMultiUnitList.Rows.Count > 0)
                                {
                                    this.dtgMultiUnitList.Rows[0].Selected = true;
                                    ((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
                                }

                                m_mthSetBtnStatus();
                            }
                            else
                            {
                                //更新失败
                                MessageBox.Show("更新失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("把其他药品单位设为非当前单位失败", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                    }
                    else
                    {
                        MessageBox.Show("当前是唯一单位\n不能设为非当前药品单位", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    //if (dtgMultiUnitList.Rows.Count != 1)
                    //{
                        //调用更新
                        if (((clsCtl_MultiUnitSet)objController).m_blnUpdateMultiUnit())
                        {
                            //更新成功
                            MessageBox.Show("更新成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //重新为单位列表绑定数据
                            ((clsCtl_MultiUnitSet)this.objController).m_mthLoadDvMultiUnit();
                            ((clsCtl_MultiUnitSet)this.objController).m_mthDgvMultiUnitDataBind();
                            //重新把单位列表的选择行数据显示在textbox上
                            if (this.dtgMultiUnitList.Rows.Count > 0)
                            {
                                this.dtgMultiUnitList.Rows[0].Selected = true;
                                ((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
                            }

                            m_mthSetBtnStatus();
                        }
                        else
                        {
                            //更新失败
                            MessageBox.Show("更新失败！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("当前是唯一单位\n不能设为非当前药品单位", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }

            }
        }
        #endregion

        #region 在单位列表中移动上、下键
        private void dtgMultiUnitList_KeyDown(object sender, KeyEventArgs e)
        {
            //关闭新增状态
            this.blnisCmdNewOpen = false;
            //关闭txtUnitName
            //this.txtUnitName.ReadOnly = true;
            int index = this.dtgMultiUnitList.SelectedRows[0].Index;
            if (e.KeyCode == Keys.Up)
            {
                index -= 1;
                if (index < 0)
                    return;
            }
            if (e.KeyCode == Keys.Down)
            {
                index += 1;
                if (index > this.dtgMultiUnitList.Rows.Count - 1)
                    return;
            }
            this.dtgMultiUnitList.Rows[index].Selected = true;
            ((clsCtl_MultiUnitSet)objController).m_mthTxtLoadData();
        }
        #endregion

        private void txtUnitName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPackage.Focus();
            }
        }

        private void txtPackage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                cmdSave.Focus();
            }
        }

        private void dtgMultiUnitList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgMultiUnitList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.dtgMultiUnitList.Rows.Count; iRow++)
            {
                this.dtgMultiUnitList.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (Convert.ToString(dtgMultiUnitList[4, iRow].Value) == "停用")
                {
                    dtgMultiUnitList.Rows[iRow].DefaultCellStyle.ForeColor = Color.Red;
                }
                else
                {
                    dtgMultiUnitList.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        internal void dtgMultiUnitList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataRowView drvCurrent = null;
            for (int iRow = 0; iRow < dtgMultiUnitList.Rows.Count; iRow++)
            {
                drvCurrent = dtgMultiUnitList.Rows[iRow].DataBoundItem as DataRowView;
                if (drvCurrent != null && drvCurrent["status_int"].ToString() == "停用")
                {
                    dtgMultiUnitList.Rows[iRow].DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                else
                {
                    dtgMultiUnitList.Rows[iRow].DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }
    }
}