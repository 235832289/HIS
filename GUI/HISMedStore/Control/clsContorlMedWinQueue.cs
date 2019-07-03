using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 控制层 xgpeng Create By xgpeng 2006-2-20
    /// </summary>
    public class clsContorlMedWinQueue : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 构造函数逻辑
        /// </summary>
        public clsContorlMedWinQueue()
        {
            m_objManage = new clsDomainMedWinQueue();
        }
        #region 变量
        clsDomainMedWinQueue m_objManage;
        DataTable m_dtable = new DataTable();
        DataTable p_dtable;
        #endregion

        #region 设置窗体对象
        frmMedWinQueue m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmMedWinQueue)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取 药房信息(名称)
        /// <summary>
        /// 获取 药房信息(名称)
        /// </summary>
        public void m_GetMedStoreInfo()
        {

            long lngRes = this.m_objManage.m_lngGetMedStoreInfo(out m_dtable);
            this.m_objViewer.m_cboMedStore.Items.Clear();
            for (int i1 = 0; i1 < m_dtable.Rows.Count; i1++)
            {
                this.m_objViewer.m_cboMedStore.Items.Add(m_dtable.Rows[i1]["medstorename_vchr"].ToString().Trim());
            }
            if (this.m_objViewer.m_cboMedStore.Items.Count != 0)
            {
                this.m_objViewer.m_cboMedStore.SelectedIndex = 0;
            }
        }
        #endregion

        #region 获得药房窗口队列
        /// <summary>
        /// 获得药房窗口队列
        /// </summary>
        public void m_GetWinQueueByMedStoreID()
        {
            string p_strID="";
            DateTime dtimeBegin = Convert.ToDateTime(this.m_objViewer.m_dtPickBegin.Value.ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtimeEnd = Convert.ToDateTime(this.m_objViewer.m_dtPickEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
           
            DataTable p_DataTableQueue = new DataTable();
            //if (m_objViewer.m_cboMedStore.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请选择药房名称","提示");
            //    m_objViewer.m_cboMedStore.Focus();
            //    return;
            //}
            //if (m_objViewer.m_cboWinStyle.SelectedIndex == -1)
            //{
            //    MessageBox.Show("请选择窗口类型","提示");

            //    m_objViewer.m_cboWinStyle.Focus();
            //    return;
            //}

            p_strID= m_GetMedstoreID(this.m_objViewer.m_cboMedStore.Text.ToString().Trim());//获得药房ID
            int flage=this.m_objViewer.m_cboWinStyle.SelectedIndex;
            long lngRes = this.m_objManage.m_lngGetWinQueueByMedStoreID(p_strID, flage,dtimeBegin,dtimeEnd,out  p_DataTableQueue);
            if (lngRes <= 0 || p_DataTableQueue.Rows.Count == 0)
                return;
            m_OverData(p_DataTableQueue);  
        }
        #endregion

        #region 根据药房名获取 药房ID
        /// <summary>
        /// 根据药房名获取 药房ID
        /// </summary>
        /// <param name="p_str"></param>
        /// <returns></returns>
        private string m_GetMedstoreID(string p_str)
        {
            string p_strID="";
            for (int i1 = 0; i1 < this.m_dtable.Rows.Count; i1++)
            {
                if (this.m_dtable.Rows[i1]["medstorename_vchr"].ToString().Trim() == this.m_objViewer.m_cboMedStore.Text.Trim())
                {
                    p_strID = m_dtable.Rows[i1]["medstoreid_chr"].ToString().Trim();
                    return p_strID;
                }
            
            }
            return p_strID;
        }

        #endregion

        #region 加载数据 
       
         private void m_OverData(DataTable p_DataTableQueue)
          {
              DataColumn dtColumn;
              DataRow dtRow;
              p_dtable= new DataTable("Queue");
              dtColumn = new DataColumn();
              dtColumn.ColumnName = p_DataTableQueue.Rows[0]["windowname_vchr"].ToString();
              p_dtable.Columns.Add(dtColumn);
              dtColumn = new DataColumn();
              dtColumn.ColumnName = p_DataTableQueue.Rows[0]["WINDOWID_CHR"].ToString();

           //   dtColumn.DataType = TypeOf(System.String);
              p_dtable.Columns.Add(dtColumn);
              for (int i1 = 1; i1 < p_DataTableQueue.Rows.Count; i1++) //加载列
              {
                  int j1=0;
                      for (j1 = 0; j1 < i1;j1++ )
                      {
                          if (p_DataTableQueue.Rows[j1]["WINDOWID_CHR"].ToString().Trim() == p_DataTableQueue.Rows[i1]["WINDOWID_CHR"].ToString().Trim())
                              break;
                          else if (j1 == i1 - 1)
                          {
                              dtColumn = new DataColumn();
                              dtColumn.ColumnName = p_DataTableQueue.Rows[i1]["windowname_vchr"].ToString();
                              p_dtable.Columns.Add(dtColumn);
                              dtColumn = new DataColumn();
                              dtColumn.ColumnName = p_DataTableQueue.Rows[i1]["WINDOWID_CHR"].ToString();
                              p_dtable.Columns.Add(dtColumn);
                           }
                        
                        }   
                  
              }
              int [] m_Arry=new int[p_dtable.Columns.Count];
             for(int j=0;j<p_dtable.Columns.Count;j++)  //初始化数组
             {
              m_Arry[j]=0;
             }        
            for (int i3 = 1; i3 < p_dtable.Columns.Count;)
            {
                
                 for (int i2 = 0; i2 < p_DataTableQueue.Rows.Count; i2++)
                {
                    if (p_dtable.Columns[i3].ColumnName.ToString().Trim() == p_DataTableQueue.Rows[i2]["WINDOWID_CHR"].ToString().Trim())
                    {
                      m_Arry[i3]++;
                    }
                 }
                 i3 += 2;
            }
            if (m_Arry.Length == 0)
                return;
            int k = m_thGetMaxRowCount(m_Arry);// 生成最大行数
            for (int m = 0; m < k+1; m++)  
            {
                dtRow = p_dtable.NewRow();
                p_dtable.Rows.Add(dtRow);
            }
            for (int k3 = 1; k3 < p_dtable.Columns.Count;)
            {  
                int n=0;
                
                for (int k2 = 0; k2 < p_DataTableQueue.Rows.Count; k2++)
                {
                    if (p_dtable.Columns[k3].ColumnName.ToString().Trim() == p_DataTableQueue.Rows[k2]["WINDOWID_CHR"].ToString().Trim())
                    {
                        if (p_DataTableQueue.Rows[k2]["lastname_vchr"].ToString().Trim()!="")
                        p_dtable.Rows[n][k3-1] = p_DataTableQueue.Rows[k2]["lastname_vchr"].ToString().Trim() + "/" + p_DataTableQueue.Rows[k2]["sex_chr"].ToString().Trim();
                        p_dtable.Rows[n][k3] = p_DataTableQueue.Rows[k2]["SEQ_INT"].ToString().Trim() ;
                        
                        n++;
                    
                    }
                    else if (n < p_dtable.Rows.Count)
                        p_dtable.Rows[n][k3] = "";
                    if (n >= p_dtable.Rows.Count)
                        break;

                }
                k3 += 2;
            }
            m_thOverDataGridView();//加载 DataGridView
            #region 无用代码
            //DataGridTableStyle dgts = new DataGridTableStyle();
            // dgts.ReadOnly=true;
            // dgts.AllowSorting = false;
            // dgts.RowHeaderWidth = 0;
            //dgts.MappingName = "Queue";
            //dgts.RowHeadersVisible = false;

            
            //DataGridTextBoxColumn dgtbc ;
            //this.m_objViewer.m_dataGrid.TableStyles.Clear();
            //for (int a = 0; a < p_dtable.Columns.Count; )
            //{
            //    dgtbc = new DataGridTextBoxColumn();
            //    dgtbc.MappingName = p_dtable.Columns[a].ColumnName.ToString();
            //    dgtbc.HeaderText = p_dtable.Columns[a].ColumnName.ToString();
            //    dgtbc.NullText = "";
                
            //    dgtbc.ReadOnly = true;
    
            //    dgtbc.Width = 100;
            //    dgts.GridColumnStyles.Add(dgtbc);
            //    a += 2;
            //}
            //this.m_objViewer.m_dataGrid.TableStyles.Add(dgts);
            //    this.m_objViewer.m_dataGrid.DataSource = p_dtable;
            #endregion

            }
        #endregion

        #region  获取最大行数
        private int m_thGetMaxRowCount(int[] m_Arry)
        {
            int m_Maxth = 0;
            if (m_Arry.Length == 1)
                return m_Arry[0];
            m_Maxth = m_Arry[0];
            for (int i1 = 1; i1 < m_Arry.Length; i1++)
            {
                if (m_Maxth <m_Arry[i1])
                    m_Maxth = m_Arry[i1];
                
            }
            return m_Maxth;
        }
          #endregion

        #region //判断是否旧数据
        /// <summary>
        /// 判断是否旧数据
        /// </summary>
        /// <param name="p_RowNum"></param>
        /// <param name="colNum"></param>
        /// <returns></returns>
        public bool m_JudgeIsOldData(int p_RowNum,int colNum)
        {
            bool flag = true;
            long lngRes=-1;
            int p_Status;//状态 1-新建 2-已配药 3-已发药 -1-退回
            int p_intSeq = Convert.ToInt32(this.p_dtable.Rows[p_RowNum][colNum + 1].ToString());
            int p_WinStyle=this.m_objViewer.m_cboWinStyle.SelectedIndex;
            lngRes=this.m_objManage.m_thJudgeIsOldData(p_intSeq,p_WinStyle,out p_Status);
            if (lngRes < 1&&p_Status<-1)
            {
                return true;
            }
            if (p_Status == 2)
            {
                MessageBox.Show("该记录已过时，建议：缩短刷新时间", "系统提示");
                return true;
            }
            else if (p_Status == 3)
            {
                MessageBox.Show("该记录已过时，建议：缩短刷新时间","系统提示");
                return true;
            }
            else
                return false;

        }
        #endregion

        #region 拖动记录
        /// <summary>
        /// 拖动记录 
        /// </summary>
        /// <param name="SourceRow">源行号</param>
        /// <param name="SourceCol"></param>
        /// <param name="ObjRow">目标行号</param>
        /// <param name="ObjCol"></param>
        public void m_DropData(int SourceRow, int SourceCol, int ObjRow, int ObjCol)
        {
            if (SourceCol == ObjCol)//纵向拖动记录
            {
                if (SourceRow == ObjRow)
                    return;
               m_DropVerData(SourceRow,SourceCol,ObjRow); 
             }
            else  
            {
                m_DropHorData(SourceRow, SourceCol, ObjRow, ObjCol);
             }

        }
        #endregion

        #region //纵向拖动记录
        private void m_DropVerData(int SourceRow, int SourceCol, int ObjRow)
        {
            DataRow dtRow=null ;
            int colnum = SourceCol;//对应数据源所在的列
            dtRow = p_dtable.NewRow();
            dtRow[colnum] = p_dtable.Rows[SourceRow][colnum].ToString().Trim();
            dtRow[colnum+1] = p_dtable.Rows[SourceRow][colnum + 1].ToString().Trim();
            if(SourceRow<ObjRow) //向下拖动
            {
                for (int i1 = SourceRow; i1 < ObjRow; i1++)
                {
                    p_dtable.Rows[i1][colnum] = p_dtable.Rows[i1+1][colnum].ToString().Trim();
                    p_dtable.Rows[i1][colnum + 1] = p_dtable.Rows[i1 + 1][colnum+1].ToString().Trim();
                }
                //int i6 = 0;
                //for (i6 = ObjRow ; i6 > SourceRow; i6--)
                //{
                //    if (p_dtable.Rows[i6-1][colnum] != null)
                //    {
                //        if (p_dtable.Rows[i6-1][colnum].ToString()!= "")
                //        {
                //            p_dtable.Rows[i6][colnum] = dtRow[colnum].ToString().Trim();
                //            p_dtable.Rows[i6][colnum + 1] = dtRow[colnum + 1].ToString().Trim();
                //        }
                //    }
                //}    
                if (p_dtable.Rows[ObjRow - 1][colnum].ToString() == "")
                {
                    p_dtable.Rows[ObjRow - 1][colnum] = dtRow[colnum].ToString().Trim();
                    p_dtable.Rows[ObjRow - 1][colnum + 1] = dtRow[colnum + 1].ToString().Trim();
                }
                else
                {
                    p_dtable.Rows[ObjRow][colnum] = dtRow[colnum].ToString().Trim();
                    p_dtable.Rows[ObjRow][colnum + 1] = dtRow[colnum + 1].ToString().Trim();
                }
                    
                
               
             }
            else  //向上拖动记录
            {
                for (int i = SourceRow; i > ObjRow; i--)
                {
                    p_dtable.Rows[i][colnum] = p_dtable.Rows[i - 1][colnum].ToString().Trim();
                    p_dtable.Rows[i][colnum + 1] = p_dtable.Rows[i - 1][colnum + 1].ToString().Trim();
                }
                p_dtable.Rows[ObjRow][colnum] = dtRow[colnum].ToString().Trim();
                p_dtable.Rows[ObjRow][colnum + 1] = dtRow[colnum + 1].ToString().Trim();  
        
            }
         
            //this.m_objViewer.m_datGridView.DataSource = null;
            // m_thOverDataGridView();
            for (int j3 = 0; j3 < p_dtable.Columns[colnum + 1].Table.Rows.Count; j3++) //保存到数据库
            {
                if (p_dtable.Rows[j3][colnum + 1].ToString() != null)
                {
                    if (p_dtable.Rows[j3][colnum + 1].ToString() != "")
                        this.m_objManage.m_lngVerichDropRecord(Convert.ToInt32(p_dtable.Rows[j3][colnum + 1].ToString().Trim()), j3 + 1);
                }
            }

        }
        #endregion

        #region //横向拖动记录
        private void m_DropHorData(int SourceRow, int SourceCol, int ObjRow, int ObjCol)
        {
            DataRow dt = p_dtable.NewRow(); 
            DataRow dtRowSource = null;
            string p_strObjWinID = "";
            int p_SourceCol = SourceCol;
            int p_ObjCol = ObjCol;

            dtRowSource = p_dtable.NewRow();
            dtRowSource[p_SourceCol]=p_dtable.Rows[SourceRow][p_SourceCol].ToString().Trim(); //保存源记录
            dtRowSource[p_SourceCol+1]=p_dtable.Rows[SourceRow][p_SourceCol+1].ToString().Trim();
            int i1;
            for(i1=SourceRow;i1<p_dtable.Columns[p_SourceCol].Table.Rows.Count-1;i1++)
            {
              p_dtable.Rows[i1][p_SourceCol] = p_dtable.Rows[i1+1][p_SourceCol].ToString().Trim();
              p_dtable.Rows[i1][p_SourceCol+1] = p_dtable.Rows[i1+1][p_SourceCol+1].ToString().Trim();   
            }
            p_dtable.Rows[i1][p_SourceCol] = "";
            p_dtable.Rows[i1][p_SourceCol+1] = "";
            for (int j3 = 0; j3 < p_dtable.Columns[p_SourceCol + 1].Table.Rows.Count; j3++)　//保存到数据库
            {
                if (p_dtable.Rows[j3][p_SourceCol + 1].ToString() != null)
                {
                    if (p_dtable.Rows[j3][p_SourceCol + 1].ToString() != "")
                     this.m_objManage.m_lngVerichDropRecord(Convert.ToInt32(p_dtable.Rows[j3][p_SourceCol + 1].ToString().Trim()), j3 + 1);
                }
            }
            if (p_dtable.Rows[p_dtable.Rows.Count - 1][p_ObjCol] != null)
            {
                if (p_dtable.Rows[p_dtable.Rows.Count - 1][p_ObjCol].ToString() != "")
                    p_dtable.Rows.Add(dt);//增加一行保存记录
            }
            for (int i2 = p_dtable.Columns[p_ObjCol].Table.Rows.Count-1; i2 > ObjRow; i2--)　//向下移动一行
            {
                p_dtable.Rows[i2][p_ObjCol] = p_dtable.Rows[i2-1][p_ObjCol].ToString().Trim();
                p_dtable.Rows[i2][p_ObjCol+1] = p_dtable.Rows[i2-1][p_ObjCol+1].ToString().Trim();
            }
            for (int j3 = ObjRow; j3 < p_dtable.Columns[p_ObjCol + 1].Table.Rows.Count; j3++)　//保存到数据库
            {
                if (p_dtable.Rows[j3][p_ObjCol + 1].ToString() != null)
                {
                    if (p_dtable.Rows[j3][p_ObjCol + 1].ToString() != "")
                        this.m_objManage.m_lngVerichDropRecord(Convert.ToInt32(p_dtable.Rows[j3][p_ObjCol + 1].ToString().Trim()), j3 + 1);
                }
            }
            p_dtable.Rows[ObjRow][p_ObjCol] = dtRowSource[p_SourceCol].ToString().Trim();　//添加源记录
            p_dtable.Rows[ObjRow][p_ObjCol+1] = dtRowSource[p_SourceCol+1].ToString().Trim();
            p_strObjWinID= p_dtable.Columns[p_ObjCol + 1].ColumnName.ToString().Trim();
            if (p_dtable.Rows[ObjRow][p_ObjCol+1] != null)
            {
                if (p_dtable.Rows[ObjRow][p_ObjCol + 1].ToString() != "")
                    this.m_objManage.m_lngHorDropRecord(Convert.ToInt32(p_dtable.Rows[ObjRow][p_ObjCol + 1].ToString().Trim()),p_strObjWinID,
                        this.m_objViewer.m_cboWinStyle.SelectedIndex, ObjRow+1);
                      
            }

        
        }
        #endregion

        #region  加载 DataGridView
        /// <summary>
        /// 加载 DataGridView
        /// </summary>
        public void m_thOverDataGridView()
        {
                this.m_objViewer.m_datGridView.Columns.Clear();
                this.m_objViewer.m_datGridView.DataSource = p_dtable;
                m_objViewer.m_datGridView.Font = new System.Drawing.Font("宋体",12);
                m_objViewer.m_datGridView.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
                m_objViewer.m_datGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 12, FontStyle.Bold);
            
                for (int L= 1; L< m_objViewer.m_datGridView.Columns.Count;)//隐藏偶数列
                {
                    m_objViewer.m_datGridView.Columns[L].Visible = false;
                   L += 2;
                }
                for (int L = 0; L < m_objViewer.m_datGridView.Columns.Count; )
                {
                    m_objViewer.m_datGridView.Columns[L].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
               
                    L += 2;
                }
        }
         #endregion
    }
}
