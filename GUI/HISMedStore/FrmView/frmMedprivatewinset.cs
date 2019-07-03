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
    public partial class frmMedprivatewinset :  com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmMedprivatewinset()
        {
            InitializeComponent();
        }

        private void frmMedprivatewinset_Load(object sender, EventArgs e)
        {

            #region 取得所有科室
            clsDomainControlMedStoreBseInfo clsDomain = new clsDomainControlMedStoreBseInfo();
            DataTable dt = null;
            long lngRes = clsDomain.m_lngGeDataTableInfo("select DEPTID_CHR,CODE_VCHR, DEPTNAME_VCHR from t_bse_deptdesc order by CODE_VCHR ", out dt);
            if (lngRes > 0)
            {
                if (dt != null)
                {
                    ListViewItem li =null ;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        li = new ListViewItem(dt.Rows[i]["DEPTID_CHR"].ToString().Trim());
                        li.SubItems.Add(dt.Rows[i]["CODE_VCHR"].ToString().Trim());
                        li.SubItems.Add(dt.Rows[i]["DEPTNAME_VCHR"].ToString().Trim());
                        lvDepts.Items.Add(li);
                    }
                    if (lvDepts.Items.Count > 0)
                    {
                        lvDepts.Items[0].Selected = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("数据访问出错,请联系系统管理员.");
            }
            #endregion

            #region 取得药房窗口
            clsOPMedStoreWin_VO[] objVO = null;
             lngRes = clsDomain.m_lngGetMedStoreWinByAny(" AND a.winproperty_int = 1 ORDER BY a.medstoreid_chr ", out objVO);
            if (lngRes > 0)
            {
                if (objVO != null)
                {
                    ListViewItem li = null;
                    for (int i = 0; i < objVO.Length; i++)
                    {
                        li = new ListViewItem(objVO[i].m_objMedStore.m_strMedStoreName.Trim());
                        li.SubItems.Add(objVO[i].m_strWindowName.Trim());
                        li.Tag = objVO[i];
                        lvwin.Items.Add(li);
                    }
                    if (lvwin.Items.Count>0)
                    {
                        lvwin.Items[0].Selected = true;
                    }
                }
                clsDomain = null;
            }
            else
            {
                MessageBox.Show("数据访问出错,请联系系统管理员.");
            }
            #endregion
        }

        private void lvwin_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataNewMethod();
        }

        private void GetDataNewMethod()
        {
            #region 药房专用窗口与科室对应表内容
            clsDomainControlMedStoreBseInfo clsDomain = new clsDomainControlMedStoreBseInfo();
            clsOPMedStoreWin_VO objVO = null;
            lvContaindept.Items.Clear();
            if (lvwin.Items.Count > 0)
            {
                if (lvwin.SelectedItems.Count > 0)
                {
                    DataTable dt = null;
                    objVO = (clsOPMedStoreWin_VO)lvwin.SelectedItems[0].Tag;
                    long lngRes = clsDomain.m_lngGetMedStoreWinDeptDefInfo(objVO.m_objMedStore.m_strMedStoreID, objVO.m_strWindowID, out dt);
                    if (lngRes > 0)
                    {
                        if (dt != null)
                        {
                            ListViewItem li = null;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                li = new ListViewItem(dt.Rows[i]["CODE_VCHR"].ToString().Trim());
                                li.SubItems.Add(dt.Rows[i]["DEPTNAME_VCHR"].ToString().Trim());
                                li.Tag = dt.Rows[i]["DEPTID_CHR"].ToString().Trim();
                                lvContaindept.Items.Add(li);
                            }
                            if (lvContaindept.Items.Count > 0)
                            {
                                lvContaindept.Items[0].Selected = true;
                            }
                        }
                        clsDomain = null;
                    }
                    else
                    {
                        MessageBox.Show("数据访问出错,请联系系统管理员.");
                    }
                }
            }

            #endregion
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewMethod();
        }

        private void AddNewMethod()
        {
            #region add
            clsOPMedStoreWin_VO objVO = null;
            clsMEDSTOREWINDEPTDEF_VO[] clsVO = null;
            if (lvwin.Items.Count > 0)
            {
                if (lvwin.SelectedItems.Count > 0)
                {
                    objVO = (clsOPMedStoreWin_VO)lvwin.SelectedItems[0].Tag;
                    if (lvDepts.Items.Count > 0)
                    {
                        if (lvDepts.SelectedItems.Count > 0)
                        {
                            clsVO = new clsMEDSTOREWINDEPTDEF_VO[lvDepts.SelectedItems.Count];
                            clsDomainControlMedStoreBseInfo clsDomain = new clsDomainControlMedStoreBseInfo();
                            bool blnExist = false;
                            for (int i = 0; i < lvDepts.SelectedItems.Count; i++)
                            {
                                for (int j = 0; j < lvContaindept.Items.Count; j++)
                                {
                                    if (lvContaindept.Items[j].Tag.ToString().Trim() == lvDepts.SelectedItems[i].SubItems[0].Text.Trim())
                                    {
                                        blnExist = true;
                                        MessageBox.Show(lvDepts.SelectedItems[i].SubItems[2].Text + "已存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        lvContaindept.Items[j].Selected = true;
                                    }
                                }
                                if (blnExist == false)
                                {
                                    clsVO[i] = new clsMEDSTOREWINDEPTDEF_VO();
                                    clsVO[i].m_strDEPTID_CHR = lvDepts.SelectedItems[i].SubItems[0].Text;
                                    clsVO[i].m_strWINDOWID_CHR = objVO.m_strWindowID;
                                    clsVO[i].m_strMEDSTOREID_CHR = objVO.m_objMedStore.m_strMedStoreID;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            long lngRes = clsDomain.m_lngInsertMEDSTOREWINDEPT(clsVO);
                            if (lngRes > 0)
                            {
                                GetDataNewMethod();
                            }
                            else
                            {
                                MessageBox.Show("数据访问出错,请联系系统管理员.");
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DELNewMethod();
        }

        private void DELNewMethod()
        {
            #region del
            clsOPMedStoreWin_VO objVO = null;
            clsMEDSTOREWINDEPTDEF_VO[] clsVO = null;
            if (lvwin.Items.Count > 0)
            {
                if (lvwin.SelectedItems.Count > 0)
                {
                    if (DialogResult.Cancel == MessageBox.Show("确认删除?", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                        return;

                    objVO = (clsOPMedStoreWin_VO)lvwin.SelectedItems[0].Tag;
                    if (lvContaindept.Items.Count > 0)
                    {
                        if (lvContaindept.SelectedItems.Count > 0)
                        {
                            clsVO = new clsMEDSTOREWINDEPTDEF_VO[lvContaindept.SelectedItems.Count];
                            clsDomainControlMedStoreBseInfo clsDomain = new clsDomainControlMedStoreBseInfo();
                            for (int i = 0; i < lvContaindept.SelectedItems.Count; i++)
                            {
                                clsVO[i] = new clsMEDSTOREWINDEPTDEF_VO();
                                clsVO[i].m_strDEPTID_CHR = lvContaindept.SelectedItems[i].Tag.ToString().Trim();
                                clsVO[i].m_strWINDOWID_CHR = objVO.m_strWindowID;
                                clsVO[i].m_strMEDSTOREID_CHR = objVO.m_objMedStore.m_strMedStoreID;
                            }
                            long lngRes = clsDomain.m_lngDeleteMEDSTOREWINDEPT(clsVO);
                            if (lngRes > 0)
                            {
                                GetDataNewMethod();
                            }
                            else
                            {
                                MessageBox.Show("数据访问出错,请联系系统管理员.");
                            }
                        }
                    }
                }
            }
            #endregion
        }

        private void lvDepts_DoubleClick(object sender, EventArgs e)
        {
            AddNewMethod();
        }

        private void lvContaindept_DoubleClick(object sender, EventArgs e)
        {
            DELNewMethod();
        }

        private void lvwin_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvwin.Sorting = lvwin.Sorting == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
            lvwin.Sort();
            lvwin.ListViewItemSorter = new ListViewItemComparer(e.Column, lvwin.Sorting, lvwin);
       
        }
        #region ListView排序类
        /// <summary>
        /// 排序类
        /// ListView.Sorting = ListView.Sorting == SortOrder.Descending?SortOrder.Ascending:SortOrder.Descending;
        /// ListView.Sort();
        /// ListView.ListViewItemSorter=new ListViewItemComparer(e.Column,ListView.Sorting,ListView);
        /// </summary>
        public class ListViewItemComparer : System.Collections.IComparer
        {
            private int col;
            private SortOrder _order;
            private ListView objListView;
            public ListViewItemComparer()
            {
                col = 0;
                this._order = SortOrder.Ascending;
            }
            public ListViewItemComparer(int column, SortOrder order, ListView objListView)
            {
                col = column;
                this._order = order;

                string strColTxt = "";
                this.objListView = objListView;

                if (objListView != null)
                {
                    for (int i = 0; i < objListView.Columns.Count; i++)
                    {
                        strColTxt = objListView.Columns[i].Text;
                        //↓↑
                        strColTxt = strColTxt.Replace(" ↑", "");
                        strColTxt = strColTxt.Replace(" ↓", "");
                        objListView.Columns[i].Text = strColTxt;
                    }

                    col = column;
                    strColTxt = objListView.Columns[col].Text;
                    if (order == SortOrder.Ascending)//如果是升序
                        objListView.Columns[col].Text = strColTxt + " ↑";
                    else
                        objListView.Columns[col].Text = strColTxt + " ↓";
                }
            }
            #region 原版式
            //		public int Compare(object x, object y) 
            //		{
            //			int returnVal=-1;
            //			returnVal=String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
            //			if(_order==SortOrder.Descending)
            //			{
            //				returnVal *=-1;
            //			}
            //			return returnVal;
            //		}
            #endregion
            public int Compare(object x, object y)
            {
                int i = 0;
                string objStr1 = "";
                string objStr2 = "";
                if (((ListViewItem)x).SubItems.Count > col)
                {
                    objStr1 = ((ListViewItem)x).SubItems[col].Text;
                }
                if (((ListViewItem)y).SubItems.Count > col)
                {
                    objStr2 = ((ListViewItem)y).SubItems[col].Text;
                }
                try
                {
                    if (objStr1.IndexOf(".") >= 0 || objStr2.IndexOf(".") >= 0)
                    {
                        i = Convert.ToDouble(objStr1) > Convert.ToDouble(objStr2) ? 1 : -1;
                    }
                    else
                    {
                        i = Convert.ToInt32(objStr1) > Convert.ToInt32(objStr2) ? 1 : -1;
                    }
                }
                catch
                {
                    i = String.Compare(objStr1, objStr2);//转换有错,说明比较的两者类型不同.
                }
                if (_order != SortOrder.Ascending) i = -i;
                return i;
            }
        }

        #endregion

        private void lvContaindept_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvContaindept.Sorting = lvContaindept.Sorting == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
            lvContaindept.Sort();
            lvContaindept.ListViewItemSorter = new ListViewItemComparer(e.Column, lvContaindept.Sorting, lvContaindept);
       
        }

        private void lvDepts_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvDepts.Sorting = lvDepts.Sorting == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
            lvDepts.Sort();
            lvDepts.ListViewItemSorter = new ListViewItemComparer(e.Column, lvDepts.Sorting, lvDepts);
      
        }
    }
}