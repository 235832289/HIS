using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmMBY2010 : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmMBY2010()
        {
            InitializeComponent();
        }

        private void frmMBY2010_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            m_mthInit();
            ((clsController_MBY2010)this.objController).m_mthInitFrom();
            this.Cursor = Cursors.Default;
        }

        public override void CreateController()
        {
            this.objController = new clsController_MBY2010();
            objController.Set_GUI_Apperance(this);
        }

        #region 控件自动跳转
        /// <summary>
        /// 控件自动跳转
        /// </summary>
        private void m_mthInit()
        {
            foreach (Control m_objControl in this.panel1.Controls)
            {
                if (m_objControl.AccessibleName != null)
                {
                    m_objControl.KeyDown += new KeyEventHandler(Ctrl_KeyPress);
                }
            }
        }

        private void Ctrl_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.txtMachineCode.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsController_MBY2010)this.objController).m_mthInsertReport(this.txtMachineCode.Text.Trim());
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("请输入仪器代号", "系统提示");
                this.txtMachineCode.Focus();
            }
        }

        private void btnReflesh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.m_lsvResult.Items.Clear();
            ((clsController_MBY2010)this.objController).blnSch = true;
            DataTable dt = ((clsController_MBY2010)this.objController).m_mthReadData();
            ((clsController_MBY2010)this.objController).m_mthFillSampleList(dt);
            this.Cursor = Cursors.Default;
        }

        private void cboItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (this.cboItem.Text != "" && this.cboItem.Tag != null)
                {
                    DataView dv = ((DataTable)this.cboItem.Tag).DefaultView;
                    try
                    {
                        int intTsNum = int.Parse(this.cboItem.Text.Trim());
                        dv.RowFilter = "testnumber = " + intTsNum;
                    }
                    catch (Exception)
                    {
                        dv.RowFilter = "testname like '" + this.cboItem.Text.Trim() + "%'";
                    }

                    if (dv.Count > 0)
                    {
                        this.cboItem.Text = dv[0]["testname"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("你查找的项目不存在，请重新确定", "系统提示");
                    }
                    this.cboItem.SelectAll();
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvPatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsvPatList.SelectedItems.Count > 0)
            {
                List<com.digitalwave.iCare.ValueObject.clsMBY2010VO> objReslist = (List<com.digitalwave.iCare.ValueObject.clsMBY2010VO>)this.lsvPatList.SelectedItems[0].Tag;
                com.digitalwave.iCare.ValueObject.clsMBY2010VO[] objResArr = objReslist.ToArray();
                ((clsController_MBY2010)this.objController).m_mthShowResult(objResArr);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            ((clsController_MBY2010)this.objController).blnSch = false;
            ((clsController_MBY2010)this.objController).m_mthFilterData();
        }
    }

    #region ListView排序类
    /// <summary>
    /// 继承自IComparer
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// 指定按照哪个列排序
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// 指定排序的方式
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// 声明CaseInsensitiveComparer类对象
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ListViewColumnSorter()
        {
            // 默认按第一列排序
            ColumnToSort = 3;

            // 排序方式为不排序
            OrderOfSort = SortOrder.None;

            // 初始化CaseInsensitiveComparer类对象
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// 重写IComparer接口.
        /// </summary>
        /// <param name="x">要比较的第一个对象</param>
        /// <param name="y">要比较的第二个对象</param>
        /// <returns>比较的结果.如果相等返回0，如果x大于y返回1，如果x小于y返回-1</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // 将比较对象转换为ListViewItem对象
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // 比较
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // 根据上面的比较结果返回正确的比较结果
            if (OrderOfSort == SortOrder.Ascending)
            {
                // 因为是正序排序，所以直接返回结果
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // 如果是反序排序，所以要取负值再返回
                return (-compareResult);
            }
            else
            {
                // 如果相等返回0
                return 0;
            }
        }

        /// <summary>
        /// 获取或设置按照哪一列排序.
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// 获取或设置排序方式.
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
    #endregion    
}
