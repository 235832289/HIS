using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using System.Text.RegularExpressions;

namespace iCare
{
    /// <summary>
    /// 手术器械、敷料项目维护
    /// </summary>
    public partial class frmOPInstrumentSet : iCare.iCareBaseForm.frmBaseForm
    {
        #region 全局变量
        /// <summary>
        /// 所有字典表项目
        /// </summary>
        clsEMR_OPInstrument_Dict[] m_objAllItems = null;
        /// <summary>
        /// 已启用字典表项目
        /// </summary>
        clsEMR_OPInstrument_Dict[] m_objActiveItems = null;
        /// <summary>
        /// 当前待修改项目
        /// </summary>
        clsEMR_OPInstrument_Dict m_objCurrentItem = null;
        /// <summary>
        /// 所有字典表项目
        /// </summary>
        DataTable m_dtbAllItems = new DataTable();
        /// <summary>
        /// 已启用字典表项目
        /// </summary>
        DataTable m_dtbActiveItems = new DataTable();
        #endregion

        #region 构造函数
        public frmOPInstrumentSet()
        {
            InitializeComponent();

            m_dtbAllItems.Columns.Add("Name");
            m_dtbAllItems.Columns.Add("Index");

            m_dtbActiveItems.Columns.Add("OrderID");
            m_dtbActiveItems.Columns.Add("Name");
        } 
        #endregion

        #region 事件
        #region 停用项目
        private void m_miDeActiveItem_Click(object sender, EventArgs e)
        {
            if (m_lsvActiveItem.SelectedItems.Count <= 0)
                return;

            long lngRes = 0;
            clsEMR_OPInstrumentDomain objDomain = new clsEMR_OPInstrumentDomain();
            ListViewItem[] selectedItem = new ListViewItem[m_lsvActiveItem.SelectedItems.Count];
            for (int i = 0; i < m_lsvActiveItem.SelectedItems.Count; i++)
            {
                clsEMR_OPInstrument_Dict objDict = m_lsvActiveItem.SelectedItems[i].Tag as clsEMR_OPInstrument_Dict;
                if (objDict == null)
                    continue;
                lngRes = objDomain.m_lngDeActiveItemFromDict(objDict.m_intOPInstrumentID);

                if (lngRes <= 0)
                {
                    clsPublicFunction.ShowInformationMessageBox("修改失败");
                    return;
                }
                selectedItem[i] = m_lsvActiveItem.SelectedItems[i];
            }

            for (int i = 0; i < selectedItem.Length; i++)
            {
                m_lsvActiveItem.Items.Remove(selectedItem[i]);
            }

            for (int i = 0; i < m_lsvActiveItem.Items.Count; i++)
            {
                clsEMR_OPInstrument_Dict objDict = m_lsvActiveItem.Items[i].Tag as clsEMR_OPInstrument_Dict;
                objDict.m_intOrderID = i + 1;
                m_lsvActiveItem.Items[i].SubItems[0].Text = (i + 1).ToString();
            }
            m_mthLoadAllItems();

            m_cmdSaveModify_Click(null, null);
        } 
        #endregion

        #region 启用项目
        private void m_miActiveItem_Click(object sender, EventArgs e)
        {
            if (m_lsvDict.SelectedItems.Count <= 0)
                return;

            long lngRes = 0;
            clsEMR_OPInstrumentDomain objDomain = new clsEMR_OPInstrumentDomain();
            for (int i = 0; i < m_lsvDict.SelectedItems.Count; i++)
            {
                int intIdx = m_lsvDict.SelectedItems[i].Index;
                clsEMR_OPInstrument_Dict objDict = m_lsvDict.SelectedItems[i].Tag as clsEMR_OPInstrument_Dict;
                if (objDict == null)
                    continue;
                lngRes = objDomain.m_lngActiveItemFromDict(objDict.m_intOPInstrumentID);

                if (lngRes <= 0)
                {
                    clsPublicFunction.ShowInformationMessageBox("修改失败");
                    return;
                }

                ListViewItem ActiveItem = new ListViewItem((m_lsvActiveItem.Items.Count + 1).ToString());
                ActiveItem.SubItems.Add(objDict.m_strOPInstrumentName);
                ActiveItem.Tag = objDict;
                m_lsvActiveItem.Items.Add(ActiveItem);
            }

            m_mthLoadAllItems();
            m_cmdSaveModify_Click(null, null);
        } 
        #endregion

        #region Load窗体
        private void frmOPInstrumentSet_Load(object sender, EventArgs e)
        {
            m_mthLoadAllItems();
            m_mthLoadActiveItems();
        } 
        #endregion

        #region 保存字典表项目
        private void m_cmdSaveItem_Click(object sender, EventArgs e)
        {
            if (m_txtItem.Text.Trim() == string.Empty)
            {
                clsPublicFunction.ShowInformationMessageBox("请先输入手术器械、敷料名称！");
                return;
            }
            clsEMR_OPInstrumentDomain objDomain = new clsEMR_OPInstrumentDomain();
            long lngRes = 0;

            int intInstrumentID = -1;
            lngRes = objDomain.m_lngCheckSameItemID(m_txtItem.Text.Trim(), out intInstrumentID);

            if (m_objCurrentItem == null)
            {
                if (intInstrumentID > 0)
                {
                    clsPublicFunction.ShowInformationMessageBox("已存在该项目！");
                    return;
                }
                lngRes = objDomain.m_lngAddNewToDict(m_txtItem.Text.Trim());
            }
            else
            {
                if (intInstrumentID > 0 && intInstrumentID != m_objCurrentItem.m_intOPInstrumentID)
                {
                    clsPublicFunction.ShowInformationMessageBox("已存在该项目！");
                    return;
                }
                lngRes = objDomain.m_lngModifyToDisc(m_objCurrentItem.m_intOPInstrumentID, m_txtItem.Text.Trim());
            }

            if (lngRes > 0)
            {
                m_mthLoadAllItems();

                int intIdx = m_intGetAllItemsRowNum(m_txtItem.Text.Trim());
                if (intIdx >= 0)
                {
                    m_lsvDict.Items[intIdx].EnsureVisible();
                }
                m_objCurrentItem = null;
                m_txtItem.Text = string.Empty;
                m_cmdSaveItem.Text = "保存项目";
            }
        } 
        #endregion

        #region 保存启用项目顺序
        private void m_cmdSaveModify_Click(object sender, EventArgs e)
        {
            if (m_lsvActiveItem.Items.Count <= 0)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsEMR_OPInstrumentDomain objDomain = new clsEMR_OPInstrumentDomain();
                clsEMR_OPInstrument_Dict objDict = null;
                long lngRes = 0;
                for (int i = 0; i < m_lsvActiveItem.Items.Count; i++)
                {
                    objDict = m_lsvActiveItem.Items[i].Tag as clsEMR_OPInstrument_Dict;
                    if (objDict != null)
                    {
                        if (objDict.m_intOrderID == i)
                            continue;
                        lngRes = objDomain.m_lngUpdateOrderID(objDict.m_intOPInstrumentID, i);
                    }
                }
                if (lngRes > 0)
                {
                    m_mthLoadActiveItems();
                    clsPublicFunction.ShowInformationMessageBox("修改成功！");
                }
                else
                {
                    clsPublicFunction.ShowInformationMessageBox("修改失败！");
                }
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox("发生如下错误\r\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region 选择的已启用项目向上移动
        private void m_cmdUp_Click(object sender, EventArgs e)
        {
            if (m_lsvActiveItem.SelectedItems.Count <= 0)
                return;

            ListViewItem[] lsiArr = new ListViewItem[m_lsvActiveItem.SelectedItems.Count];
            for (int i = 0; i < m_lsvActiveItem.SelectedItems.Count; i++)
            {
                int idx = m_lsvActiveItem.SelectedItems[i].Index;
                lsiArr[i] = m_lsvActiveItem.Items[idx];
            }

            for (int i = 0; i < lsiArr.Length; i++)
            {
                int idx = lsiArr[i].Index;
                if (idx > 0)
                {
                    ListViewItem itemLast = m_lsvActiveItem.Items[idx - 1];
                    ListViewItem itemCurrent = lsiArr[i].Clone() as ListViewItem;
                    m_lsvActiveItem.Items[idx - 1] = itemCurrent;
                    m_lsvActiveItem.Items[idx] = itemLast;
                    m_lsvActiveItem.Focus();
                    m_lsvActiveItem.Items[idx - 1].Selected = true;
                    m_lsvActiveItem.Items[idx - 1].EnsureVisible();
                }
            }

            m_mthReSetAcitveItemOrderID();
        } 
        #endregion

        #region 选择的已启用项目向下移动
        private void m_cmdDown_Click(object sender, EventArgs e)
        {
            if (m_lsvActiveItem.SelectedItems.Count <= 0)
                return;

            ListViewItem[] lsiArr = new ListViewItem[m_lsvActiveItem.SelectedItems.Count];
            for (int i = 0; i < m_lsvActiveItem.SelectedItems.Count; i++)
            {
                int idx = m_lsvActiveItem.SelectedItems[i].Index;
                lsiArr[i] = m_lsvActiveItem.Items[idx];
            }

            for (int i = lsiArr.Length - 1; i >= 0; i--)
            {
                int idx = lsiArr[i].Index;
                if (idx < m_lsvActiveItem.Items.Count - 1)
                {
                    ListViewItem itemNext = m_lsvActiveItem.Items[idx + 1];
                    ListViewItem itemCurrent = lsiArr[i].Clone() as ListViewItem;
                    m_lsvActiveItem.Items[idx + 1] = itemCurrent;
                    m_lsvActiveItem.Items[idx] = itemNext;
                    m_lsvActiveItem.Focus();
                    m_lsvActiveItem.Items[idx + 1].Selected = true;
                    m_lsvActiveItem.Items[idx + 1].EnsureVisible();
                }
            }

            m_mthReSetAcitveItemOrderID();
        } 
        #endregion

        #region 通过项目名称搜索所有项目
        private void m_txtSearchDict_TextChanged(object sender, EventArgs e)
        {
            int intIdx = m_intGetAllItemsRowNum(m_txtSearchDict.Text.Trim());
            if (intIdx >= 0)
            {
                m_lsvDict.Focus();
                m_lsvDict.Items[intIdx].EnsureVisible();
                m_lsvDict.Items[intIdx].Selected = true;
            }
        } 
        #endregion

        #region 通过项目名称搜索已启用项目
        private void m_txtSearchActiveItem_TextChanged(object sender, EventArgs e)
        {
            int intIdx = m_intGetActiveItemsRowNum(m_txtSearchActiveItem.Text.Trim());
            if (intIdx >= 0)
            {
                m_lsvActiveItem.Focus();
                m_lsvActiveItem.Items[intIdx].EnsureVisible();
                m_lsvActiveItem.Items[intIdx].Selected = true;
            }
        } 
        #endregion

        #region 双击选择项目以修改
        private void m_lsvDict_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvDict.Items.Count <= 0 || m_lsvDict.SelectedItems.Count != 1)
                return;

            m_objCurrentItem = m_lsvDict.SelectedItems[0].Tag as clsEMR_OPInstrument_Dict;
            if (m_objCurrentItem != null)
            {
                m_cmdSaveItem.Text = "修改项目";
                m_txtItem.Text = m_objCurrentItem.m_strOPInstrumentName;
            }
        } 
        #endregion

        #region 保存字典表项目
        private void m_txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSaveItem_Click(sender, null);
            }
        } 
        #endregion

        #region 快速移动选择的已启用项目至指定位置
        private void m_txtSpecifyLineNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_txtSpecifyLineNum.Text.Trim() == string.Empty)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                string RegexText = @"^[1-9]\d*|0$";
                if (!Regex.IsMatch(m_txtSpecifyLineNum.Text.Trim(), RegexText))
                {
                    clsPublicFunction.ShowInformationMessageBox("请填入非负整数！");
                    return;
                }

                int intSpecifyIdx = Convert.ToInt32(m_txtSpecifyLineNum.Text.Trim());

                if (intSpecifyIdx > 0)
                {
                    intSpecifyIdx -= 1;
                }

                ListViewItem[] lsiArr = new ListViewItem[m_lsvActiveItem.SelectedItems.Count];
                int[] idxArr = new int[m_lsvActiveItem.SelectedItems.Count];
                for (int i = 0; i < m_lsvActiveItem.SelectedItems.Count; i++)
                {
                    int idx = m_lsvActiveItem.SelectedItems[i].Index;
                    lsiArr[i] = m_lsvActiveItem.Items[idx];
                    idxArr[i] = idx;
                }

                for (int i = 0; i < lsiArr.Length; i++)
                {
                    if (idxArr[i] == intSpecifyIdx)
                        continue;

                    m_lsvActiveItem.Items.RemoveAt(idxArr[i]);
                    m_lsvActiveItem.Items.Insert(intSpecifyIdx + i, lsiArr[i]);
                    m_lsvActiveItem.Items[intSpecifyIdx + i].EnsureVisible();
                }

                m_mthReSetAcitveItemOrderID();
            }
        }  
        #endregion
        #endregion

        #region 方法
        #region 查询并显示字典表所有项目
        /// <summary>
        /// 查询并显示字典表所有项目
        /// </summary>
        private void m_mthLoadAllItems()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                m_lsvDict.Items.Clear();
                clsEMR_OPInstrumentDomain objDomain = new clsEMR_OPInstrumentDomain();
                long lngRes = objDomain.m_lngGetAllItemsFromDict(out m_objAllItems);

                if (m_objAllItems == null || m_objAllItems.Length <= 0)
                    return;

                m_lsvDict.BeginUpdate();
                m_dtbAllItems.BeginLoadData();
                for (int i = 0; i < m_objAllItems.Length; i++)
                {
                    ListViewItem item = new ListViewItem(m_objAllItems[i].m_strOPInstrumentName);
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(m_strGetActiveDesc(m_objAllItems[i].m_intStatus),
                        m_clrGetActiveDesc(m_objAllItems[i].m_intStatus), m_lsvDict.BackColor, m_lsvDict.Font);
                    item.Tag = m_objAllItems[i];
                    m_lsvDict.Items.Add(item);
                    object[] objRow = new object[] { m_objAllItems[i].m_strOPInstrumentName, i};
                    m_dtbAllItems.LoadDataRow(objRow, true);
                }
                m_lsvDict.EndUpdate();
                m_dtbAllItems.EndLoadData();
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox("发生如下错误\r\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region 获取使用状况说明
        /// <summary>
        /// 获取使用状况说明
        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <returns></returns>
        private string m_strGetActiveDesc(int p_intStatus)
        {
            switch (p_intStatus)
            {
                case 0:
                    return "已启用";
                case 1:
                    return "已停用";
                default:
                    return "已停用";
            }
        } 
        #endregion

        #region 获取使用状况颜色表示
        /// <summary>
        /// 获取使用状况颜色表示
        /// </summary>
        /// <param name="p_intStatus">状态</param>
        /// <returns></returns>
        private Color m_clrGetActiveDesc(int p_intStatus)
        {
            switch (p_intStatus)
            {
                case 0:
                    return Color.Blue;
                case 1:
                    return Color.Red;
                default:
                    return Color.Red;
            }
        } 
        #endregion

        #region 查询并显示字典表已启用项目
        /// <summary>
        /// 查询并显示字典表已启用项目
        /// </summary>
        private void m_mthLoadActiveItems()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                m_lsvActiveItem.Items.Clear();

                clsEMR_OPInstrumentDomain objDomain = new clsEMR_OPInstrumentDomain();
                long lngRes = objDomain.m_lngGetActiveItemsFromDict(out m_objActiveItems);

                if (m_objActiveItems == null || m_objActiveItems.Length <= 0)
                    return;

                m_lsvActiveItem.BeginUpdate();
                m_dtbActiveItems.BeginLoadData();
                for (int i = 0; i < m_objActiveItems.Length; i++)
                {
                    int intOrder = m_objActiveItems[i].m_intOrderID == -1 ? i + 1 : m_objActiveItems[i].m_intOrderID + 1;
                    ListViewItem item = new ListViewItem(intOrder.ToString());
                    item.SubItems.Add(m_objActiveItems[i].m_strOPInstrumentName);
                    item.Tag = m_objActiveItems[i];
                    m_lsvActiveItem.Items.Add(item);
                    object[] objItem = new object[] { m_objActiveItems[i].m_intOrderID, m_objActiveItems[i].m_strOPInstrumentName };
                    m_dtbActiveItems.LoadDataRow(objItem,true);
                }
                m_lsvActiveItem.EndUpdate();
                m_dtbActiveItems.EndLoadData();
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox("发生如下错误\r\n" + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region 重新设定已启用项目顺序
        /// <summary>
        /// 重新设定已启用项目顺序
        /// </summary>
        private void m_mthReSetAcitveItemOrderID()
        {
            for (int i = 0; i < m_lsvActiveItem.Items.Count; i++)
            {
                m_lsvActiveItem.Items[i].SubItems[0].Text = (i + 1).ToString();
                clsEMR_OPInstrument_Dict objDict = m_lsvActiveItem.Items[i].Tag as clsEMR_OPInstrument_Dict;
                if (objDict != null)
                {
                    objDict.m_intOrderID = i + 1;
                }
            }
        }  
        #endregion

        #region 根据项目名称返回字典表所有项目行号
        /// <summary>
        /// 根据项目名称返回字典表所有项目行号
        /// </summary>
        /// <param name="p_strInstrumentName">项目名称</param>
        /// <returns></returns>
        private int m_intGetAllItemsRowNum(string p_strInstrumentName)
        {
            if (m_dtbAllItems == null || m_dtbAllItems.Rows.Count <= 0 || p_strInstrumentName == null)
                return -1;

            int intIdex = -1;
            DataView dtvItems = m_dtbAllItems.DefaultView;

            dtvItems.RowFilter = @"Name like '" + p_strInstrumentName.Trim() + "%'";

            if (dtvItems != null)
            {
                intIdex = Convert.ToInt32(dtvItems[0][1]);
            }
            return intIdex;
        } 
        #endregion

        #region 根据项目名称返回已启用项目行号
        /// <summary>
        /// 根据项目名称返回已启用项目行号
        /// </summary>
        /// <param name="p_strInstrumentName">项目名称</param>
        /// <returns></returns>
        private int m_intGetActiveItemsRowNum(string p_strInstrumentName)
        {
            if (m_dtbActiveItems == null || m_dtbActiveItems.Rows.Count <= 0 || p_strInstrumentName == null)
                return -1;

            int intIdex = -1;
            DataView dtvItems = m_dtbActiveItems.DefaultView;

            dtvItems.RowFilter = @"Name like '" + p_strInstrumentName.Trim() + "%'";

            if (dtvItems != null)
            {
                intIdex = Convert.ToInt32(dtvItems[0][0]);
            }
            return intIdex;
        } 
        #endregion
        #endregion
    }
}