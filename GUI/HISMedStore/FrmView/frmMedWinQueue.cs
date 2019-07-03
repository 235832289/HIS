using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房窗口队列  Create By xgpeng 2006-2-20
    /// </summary>
    public partial class frmMedWinQueue : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMedWinQueue()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsContorlMedWinQueue();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmMedWinQueue_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.timer1.Interval = Convert.ToInt32(this.m_dtBrush.Value.ToString("mm"))*1000;
            ((clsContorlMedWinQueue)this.objController).m_GetMedStoreInfo();
            this.m_cboWinStyle.SelectedIndex=0;
             ((clsContorlMedWinQueue)this.objController).m_GetWinQueueByMedStoreID();
         }
         int dndMouseDownRow = -1;
         int dndMouseDownCol = -1;

    

        private void timer1_Tick(object sender, EventArgs e)
        {
             ((clsContorlMedWinQueue)this.objController).m_GetWinQueueByMedStoreID();
        }

        private void m_dtBrush_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Interval = Convert.ToInt32(this.m_dtBrush.Value.ToString("mm")) * 1000;
                //if (m_dtBrush.Value.Millisecond == 0)
                //    return;
            }
            catch
            {
                MessageBox.Show("刷新时间必须大于零","系统提示");
            }
            
        }

        private void m_cboMedStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_datGridView.DataSource = null;
            ((clsContorlMedWinQueue)this.objController).m_GetWinQueueByMedStoreID();

        }

        private void m_cboWinStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_datGridView.DataSource = null;
            ((clsContorlMedWinQueue)this.objController).m_GetWinQueueByMedStoreID();

        }

        private void m_dataGrid_DragEnter(object sender, DragEventArgs e)
        {
      
            
            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Move;
        }

        private void m_dataGrid_DragLeave(object sender, EventArgs e)
        {

           
            //     m_dataGrid.UnSelect(Drow);
            //m_dataGrid.b
            //     Drow = 0;

      
            
           
        }

        private void m_cboMedStore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void m_cboWinStyle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }
        int i1 = 0;
        private void m_dtPickBegin_KeyDown(object sender, KeyEventArgs e)
        {
          
            if (e.KeyCode == Keys.Enter)
            {
                if (i1 != 2)
                {
                    SendKeys.Send("{Right}");
                    i1++;
                }
                else
                {
                    i1 = 0;
                    SendKeys.Send("{Tab}");
                }
            }
        }
        int i2=0;
        private void m_dtPickEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (i2 != 2)
                {
                    SendKeys.Send("{Right}");
                    i2++;
                }
                else
                {
                    i2 = 0;
                    SendKeys.Send("{Tab}");
                }
            }
        }

        private void m_dtPickBegin_ValueChanged(object sender, EventArgs e)
        {
            this.m_datGridView.DataSource = null;
            ((clsContorlMedWinQueue)this.objController).m_GetWinQueueByMedStoreID();

        }

        private void m_dtPickEnd_ValueChanged(object sender, EventArgs e)
        {
            this.m_datGridView.DataSource = null;
            ((clsContorlMedWinQueue)this.objController).m_GetWinQueueByMedStoreID();

        }
        #region 拖动单元格 (m_dataGridView)
        private void m_datGridView_MouseMove(object sender, MouseEventArgs e)
        {
          //  System.Windows.Forms.DataGridView.HitTestInfo ht = m_datGridView.HitTest(m_datGridView.PointToClient(new Point(e.X, e.Y)).X, m_datGridView.PointToClient(new Point(e.X, e.Y)).Y);

           System.Windows.Forms.DataGridView.HitTestInfo ht = m_datGridView.HitTest(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                if (dndMouseDownRow == -1 || dndMouseDownCol == -1 ||
                    (ht.RowIndex == dndMouseDownRow && ht.ColumnIndex == dndMouseDownCol))
                {
                    return;
                }
                if (m_datGridView.Rows[this.dndMouseDownRow].Cells[dndMouseDownCol].Value.ToString() == "")
                    return;
                String data = m_datGridView.Rows[this.dndMouseDownRow].Cells[dndMouseDownCol].Value.ToString();
                this.DoDragDrop(data, DragDropEffects.Move);
                
                this.dndMouseDownRow = -1;
                this.dndMouseDownCol = -1;
            }
        }

        private void m_datGridView_MouseDown(object sender, MouseEventArgs e)
        {
            System.Windows.Forms.DataGridView.HitTestInfo ht = m_datGridView.HitTest(e.X, e.Y);
            this.dndMouseDownRow = ht.RowIndex;
            this.dndMouseDownCol = ht.ColumnIndex;
        }

        private void m_datGridView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
            {
                System.Windows.Forms.DataGridView.HitTestInfo ht = m_datGridView.HitTest(m_datGridView.PointToClient(new Point(e.X, e.Y)).X, m_datGridView.PointToClient(new Point(e.X, e.Y)).Y);
                //  System.Windows.Forms.DataGridView.HitTestInfo ht = dataGridView1.HitTest(e.X,e.Y);
                if (ht.RowIndex == -1 || ht.ColumnIndex == -1)
                    return;
                //else
                //{
                //    m_datGridView.Rows[ht.RowIndex].Cells[ht.ColumnIndex].Value = (string)e.Data.GetData("Text");
                //    MessageBox.Show(ht.RowIndex.ToString(), ht.ColumnIndex.ToString());
                //}
                if (((clsContorlMedWinQueue)this.objController).m_JudgeIsOldData(dndMouseDownRow, dndMouseDownCol))//判断是否是旧数据
                    return;
                else
                    ((clsContorlMedWinQueue)this.objController).m_DropData(dndMouseDownRow, dndMouseDownCol, ht.RowIndex, ht.ColumnIndex);

            }
        }
        private void m_datGridView_DragOver(object sender, DragEventArgs e)
        {
            System.Windows.Forms.DataGridView.HitTestInfo ht = m_datGridView.HitTest(m_datGridView.PointToClient(new Point(e.X, e.Y)).X, m_datGridView.PointToClient(new Point(e.X, e.Y)).Y);
            // System.Windows.Forms.DataGridView.HitTestInfo ht = dataGridView1.HitTest(e.X,e.Y);
            //Console.WriteLine(ht.ToString());
            if ((ht.RowIndex == this.dndMouseDownRow && ht.ColumnIndex == this.dndMouseDownCol)
                || !e.Data.GetDataPresent("Text"))
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
            
                e.Effect = DragDropEffects.Move;
               
                m_datGridView.Rows[ht.RowIndex].Cells[ht.ColumnIndex].Selected = true;
               
            }
        }

        private void m_datGridView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Text"))
                e.Effect = DragDropEffects.Move;
        }

        private void m_datGridView_MouseUp(object sender, MouseEventArgs e)
        {
            this.dndMouseDownRow = -1;
            this.dndMouseDownCol = -1;
        }
        #endregion

        



    }
}