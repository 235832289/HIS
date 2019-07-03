using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// Summary description for ctlDataGridBaseTool.
	/// </summary>
	public class ctlDataGridBaseTool : System.Windows.Forms.DataGrid
	{
		protected System.Data.DataSet dtsGrid;
		protected System.Windows.Forms.DataGridTableStyle m_dgsBase;
		protected System.Data.DataTable m_dtbGrid;

		#region 内部实现ListView与Column绑定功能
		/// <summary>
		/// 内部实现ListView与Column绑定功能
		/// </summary>
		protected class clsGridListViewExt
		{		
			private DataGrid m_dtgBase;
			private DataGridTextBoxColumn m_dtxtcText;
			private DataGridTextBox m_txtText;

			private ListView m_lsvShow;			

			/// <summary>
			/// 第几列
			/// </summary>
			private int m_intColumnIndex;

			/// <summary>
			/// 当前的Cell
			/// </summary>
			private DataGridCell m_objCurrentCell;

			public delegate void d_mthBeforeListViewShowHandler(clsGridListViewExt p_objSender,ListView p_lsvList);

			public event d_mthBeforeListViewShowHandler m_evtBeforeListViewShow;

			public delegate void d_mthListViewDoubleClickHandler(clsGridListViewExt p_objSender,ListViewItem p_lsvClickItem);

			public event d_mthListViewDoubleClickHandler m_evtListViewDoubleClick;

			/// <summary>
			/// 构造函数
			/// </summary>
			/// <param name="p_dtxtcText">与ListView绑定的列</param>
			/// <param name="p_intColumnIndex">列的索引</param>
			/// <param name="p_lsvShow">ListView</param>
			public clsGridListViewExt(DataGridTextBoxColumn p_dtxtcText,int p_intColumnIndex,ListView p_lsvShow)
			{
				m_dtgBase = p_dtxtcText.DataGridTableStyle.DataGrid;
				m_dtxtcText = p_dtxtcText;

				m_lsvShow = p_lsvShow;				

				m_txtText = (DataGridTextBox)p_dtxtcText.TextBox;
				m_txtText.KeyDown += new KeyEventHandler(m_mthTextKeyDown);
				m_txtText.KeyPress += new KeyPressEventHandler(m_mthTextKeyPress);

				m_txtText.LostFocus += new EventHandler(m_mthLostFocus);
				m_lsvShow.LostFocus += new EventHandler(m_mthLostFocus);

				m_lsvShow.KeyDown += new KeyEventHandler(m_mthListViewKeyDown);

				m_lsvShow.DoubleClick += new EventHandler(m_mthListViewDoubleClick);
				
				m_intColumnIndex = p_intColumnIndex;
			}

			#region 事件处理
			private bool m_blnListViewShowed = false;
			/// <summary>
			/// 判断是否当前的ListView事件
			/// </summary>
			/// <returns></returns>
			private bool m_blnIsThisListViewCall()
			{
				//由于ListView会被多个实例共用，需要判断当前调用是否在本实例处理。
				return m_dtgBase.CurrentCell.ColumnNumber == m_intColumnIndex && (m_blnListViewShowed || m_txtText.Focus());				
			}
			private void m_mthListViewKeyDown(object sender,KeyEventArgs e)
			{
				if(!m_blnIsThisListViewCall())
					return;

				switch(e.KeyCode)
				{
					case Keys.Space:
					case Keys.Enter:						
						m_mthListViewSelected();
						break;
					case Keys.Escape:
						m_mthHideListView();
						break;
				}
			}

			private void m_mthTextKeyPress(object sender,KeyPressEventArgs e)
			{
				if(e.KeyChar == ' ')
					e.Handled = true;
			}
			private void m_mthTextKeyDown(object sender,KeyEventArgs e)
			{
				if(!m_blnIsThisListViewCall())
					return;

				if(e.KeyCode != Keys.Space)
					return;

				if(!m_bolIfResponseSpaceBar)
				{
					if(m_strGetCurrentText() == "")
						return;
				}

				//用户按了空格，显示ListView，并选择第一项
				m_mthBeforeListViewShow();
				m_mthShowListView();
				m_lsvShow.Focus();
				if(m_lsvShow.Items.Count > 0)
				{
					m_lsvShow.Items[0].Selected = true;
				}			
			}
            
			/// <summary>
			/// 设置DataGird中的DatagridTextBox是否响应空格键出ListView
			/// (默认是True)
			/// </summary>
			private bool m_bolIfResponseSpaceBar = true;
			/// <summary>
			/// 设置DataGird中的DatagridTextBox是否响应空格键出ListView(默认是True)
			/// </summary>
			protected bool m_BolIfResponseSpaceBar
			{
				get
				{
					return m_bolIfResponseSpaceBar;
				}
				set
				{
					m_bolIfResponseSpaceBar = value;
				}
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void m_mthLostFocus(object sender,EventArgs e)
			{
				if(!m_blnIsThisListViewCall())
					return;

				if(sender.Equals(m_lsvShow) && !m_txtText.Focus())
				{
					m_mthHideListView();
				}
				else if(sender.Equals(m_txtText) && !m_lsvShow.Focused)
				{
					m_mthHideListView();
				}
			}

			/// <summary>
			/// ListView双击
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void m_mthListViewDoubleClick(object sender,EventArgs e)
			{
				if(!m_blnIsThisListViewCall())
					return;
				
				m_mthListViewSelected();
			}

			/// <summary>
			/// 用户选择了项目
			/// </summary>
			private void m_mthListViewSelected()
			{
				if(!m_blnIsThisListViewCall())
					return;

				if(m_evtListViewDoubleClick != null && m_lsvShow.SelectedItems.Count > 0)
					m_evtListViewDoubleClick(this,m_lsvShow.SelectedItems[0]);

				m_mthHideListView();
			}
			#endregion

			#region ListView的显示和隐藏
			/// <summary>
			/// ListView显示之前
			/// </summary>
			private void m_mthBeforeListViewShow()
			{
				m_objCurrentCell = m_dtgBase.CurrentCell;

				if(m_evtBeforeListViewShow!=null)
					m_evtBeforeListViewShow(this,m_lsvShow);			
			}

			/// <summary>
			/// 显示ListView
			/// </summary>
			private void m_mthShowListView()
			{
				int x = m_txtText.Location.X + m_dtgBase.Location.X;
				int y = m_txtText.Location.Y + m_dtgBase.Location.Y + m_txtText.Height;
			
				Control ctlForm = m_dtgBase.Parent;
				while(ctlForm != null && !(ctlForm is System.Windows.Forms.Form))
				{
					x += ctlForm.Left;
					y += ctlForm.Top;
					ctlForm = ctlForm.Parent;
				}

				if(x != m_dtgBase.Location.X)
				{
					Point p = new Point(x,y);
					m_lsvShow.Location = p;
					m_lsvShow.Width = m_txtText.Width ;
					m_lsvShow.BringToFront();
					m_lsvShow.Visible = true;
					m_blnListViewShowed = true;
				}			
			}

			/// <summary>
			/// 隐藏ListView
			/// </summary>
			private void m_mthHideListView()
			{
				/*
				 * 令ListView的TabIndex与DataGrid的一致，才可以在ListView
				 * 隐藏后选择DataGrid。
				 */
				int intTempTabIndex = m_lsvShow.TabIndex;
				m_lsvShow.TabIndex = m_dtgBase.TabIndex;
						
				m_lsvShow.Visible = false;

				m_txtText.Focus();
				m_txtText.SelectionStart = m_txtText.Text.Length;
				m_txtText.SelectionLength = 0;			
				m_lsvShow.TabIndex = intTempTabIndex;				
			
				m_blnListViewShowed = false;
			}
			#endregion ListView的显示和隐藏

			/// <summary>
			/// 获取用户输入的内容
			/// </summary>
			/// <returns></returns>
			public string m_strGetCurrentText()
			{
				return m_txtText.Text;
			}

			/// <summary>
			/// 当前的Cell
			/// </summary>
			/// <returns></returns>
			public DataGridCell m_objGetCurrentCell()
			{
				return m_objCurrentCell;
			}

			/// <summary>
			/// 当前工具绑定的列的索引
			/// </summary>
			/// <returns></returns>
			public int m_intGetColumnIndex()
			{
				return m_intColumnIndex;
			}
		}
		#endregion

		#region Initalize
		private void InitializeComponent()
		{
			this.dtsGrid = new System.Data.DataSet();
			this.m_dtbGrid = new System.Data.DataTable();
			this.m_dgsBase = new System.Windows.Forms.DataGridTableStyle();
			((System.ComponentModel.ISupportInitialize)(this.dtsGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dtbGrid)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// dtsGrid
			// 
			this.dtsGrid.DataSetName = "TempData";
			this.dtsGrid.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.dtsGrid.Tables.AddRange(new System.Data.DataTable[] {
																		 this.m_dtbGrid});
			// 
			// m_dtbGrid
			// 
			this.m_dtbGrid.TableName = "DataContainer";
			// 
			// m_dgsBase
			// 
			this.m_dgsBase.DataGrid = this;
			this.m_dgsBase.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dgsBase.MappingName = "DataContainer";
			// 
			// ctlDataGridBaseTool
			// 
			this.DataSource = this.m_dtbGrid;
			this.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																						this.m_dgsBase});
			((System.ComponentModel.ISupportInitialize)(this.dtsGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.m_dtbGrid)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}
		#endregion Initalize
	
		public ctlDataGridBaseTool()
		{
			//
			// TODO: Add constructor logic here
			//
			InitializeComponent();

			this.TableStyles.Remove(m_dgsBase);

			m_dtbGrid.RowDeleting += new DataRowChangeEventHandler(m_mthBeforeRowDelete);
		}

		private ArrayList m_arlTempBuffer = new ArrayList();

		#region 使用ListView进行模糊查询
		protected void m_mthAddListViewColumn(ListView p_lsvList)
		{
			p_lsvList.Columns.Add("",100,HorizontalAlignment.Left);
		}
		private ListView m_lsvGridShow;
		private ArrayList m_arlGridListTools = new ArrayList();

		/// <summary>
		/// DataGrid文字内容改变时出现的ListView
		/// </summary>
		public ListView m_LsvGridShow
		{
			get
			{
				return m_lsvGridShow;
			}
			set
			{
				if(m_lsvGridShow != null)
				{
					m_lsvGridShow.Visible = true;
				}

				m_lsvGridShow = value;
				if(m_lsvGridShow != null)
				{
					m_lsvGridShow.View = View.Details;					
					m_lsvGridShow.Visible = false;
					m_lsvGridShow.HeaderStyle = ColumnHeaderStyle.None;
					m_lsvGridShow.FullRowSelect = true;
				}
			}
		}	
		
		/// <summary>
		/// 添加TextChange中显示的ListView
		/// </summary>
		/// <param name="p_intColumnIndex">列的索引，从0开始</param>
		/// <param name="p_evtBeforeListViewShow">显示ListView之前的事件</param>
		/// <param name="p_evtListViewDoubleClick">ListView双击的事件</param>
		protected void m_mthAddColumnWithListView(int p_intColumnIndex,clsGridListViewExt.d_mthBeforeListViewShowHandler p_evtBeforeListViewShow,clsGridListViewExt.d_mthListViewDoubleClickHandler p_evtListViewDoubleClick)
		{
			if(m_lsvGridShow == null || p_evtBeforeListViewShow == null || p_evtListViewDoubleClick == null || p_intColumnIndex <0 || p_intColumnIndex > this.TableStyles[0].GridColumnStyles.Count-1)
				return;

			DataGridTextBoxColumn objColumn = this.TableStyles[0].GridColumnStyles[p_intColumnIndex] as DataGridTextBoxColumn;

			if(objColumn == null)
				return;

			clsGridListViewExt objGridListView = new clsGridListViewExt(objColumn,p_intColumnIndex,m_lsvGridShow);
			objGridListView.m_evtBeforeListViewShow += p_evtBeforeListViewShow;
			objGridListView.m_evtListViewDoubleClick += p_evtListViewDoubleClick;
			m_arlGridListTools.Add(objGridListView);
		}
		#endregion 使用ListView进行模糊查询

		#region ListView模糊查询的统一实现
		/// <summary>
		/// 初始化ListView的列
		/// </summary>
		/// <param name="p_intColumnIndex">列的索引，从0开始</param>
		/// <param name="p_lsvList">ListView</param>
		protected virtual void m_mthInitListViewColumnExt(int p_intColumnIndex,ListView p_lsvList)
		{
		}
		/// <summary>
		/// 初始化ListView的内容
		/// </summary>
		/// <param name="p_intColumnIndex">列的索引，从0开始</param>
		/// <param name="p_strText">用户输入的内容</param>
		/// <param name="p_lsvList">ListView</param>
		protected virtual void m_mthInitListViewItemExt(int p_intColumnIndex,string p_strText,ListView p_lsvList)
		{
		}
		/// <summary>
		/// 在ListView双击后，获取一行数据
		/// </summary>
		/// <param name="p_intColumnIndex">列的索引，从0开始</param>
		/// <param name="p_lviSelectedItem">用户选择的ListView的内容</param>
		/// <returns>放入DataTable的内容</returns>
		protected virtual object[] m_objMakeDataExt(int p_intColumnIndex,ListViewItem p_lviSelectedItem)
		{
			return null;
		}

		/// <summary>
		/// 添加列与ListView绑定。使用此统一操作，必须实现各个Ext结尾的函数。		
		/// </summary>
		/// <param name="p_intColumnIndex">列的索引，从0开始</param>
		protected void m_mthAddColumnWithListViewExt(int p_intColumnIndex)
		{
			m_mthAddColumnWithListView(p_intColumnIndex,new clsGridListViewExt.d_mthBeforeListViewShowHandler(m_mthBeforeShow),new clsGridListViewExt.d_mthListViewDoubleClickHandler(m_mthDoubleClick));
		}

		/// <summary>
		/// 之前ListView所绑定的列
		/// </summary>
		private int m_intPreColumnIndexExt = -1;
		private void m_mthBeforeShow(clsGridListViewExt p_objGridTool,ListView p_lsvList)
		{
			//清空ListView内容
			p_lsvList.Items.Clear();

			//如果不是同一列，初始化列
			if(p_objGridTool.m_intGetColumnIndex() != m_intPreColumnIndexExt)
			{
				p_lsvList.Columns.Clear();
				m_mthInitListViewColumnExt(p_objGridTool.m_intGetColumnIndex(),p_lsvList);
				m_intPreColumnIndexExt = p_objGridTool.m_intGetColumnIndex();
			}

			//初始化列标内容
			m_mthInitListViewItemExt(p_objGridTool.m_intGetColumnIndex(),p_objGridTool.m_strGetCurrentText(),p_lsvList);
		}
		private void m_mthDoubleClick(clsGridListViewExt p_objGridTool,ListViewItem p_lviClickItem)
		{
			//获取内容
			object []objvalue = m_objMakeDataExt(p_objGridTool.m_intGetColumnIndex(),p_lviClickItem);
			
			if(objvalue == null)
				return;

			//放入内容：如果是新的内容，添加新行。
			int intRowNum = p_objGridTool.m_objGetCurrentCell().RowNumber;

			if(intRowNum >= m_dtbGrid.Rows.Count)
			{
				m_mthAddRow(objvalue);
			}
			else
			{
				m_mthUpdateRow(intRowNum,objvalue);
			}

		}
		#endregion 统一实现的基本操作

		/// <summary>
		/// 初始化，必须在窗体的Load事件中调用
		/// </summary>
		public void m_mthInitGrid()
		{
			this.TableStyles.Add(m_dgsBase);

			m_mthAddList();			
		}
		/// <summary>
		/// 添加列与ListView的关联
		/// </summary>
		protected virtual void m_mthAddList()
		{			
		}

		#region 提供CellChanged功能
		private DataGridCell m_dgcPreCell = new DataGridCell(-1,-1);
		protected override void OnCurrentCellChanged(System.EventArgs e)
		{
			if(m_dgcPreCell.RowNumber >= m_dtbGrid.Rows.Count)
				m_dgcPreCell.RowNumber = -1;

			if(m_dgcPreCell.ColumnNumber != -1 && m_dgcPreCell.RowNumber != -1)
			{
				m_mthHandleCellChanged(m_dgcPreCell,this.CurrentCell);
			}
			m_dgcPreCell = this.CurrentCell;
			base.OnCurrentCellChanged(e);			
		}

		protected virtual void m_mthHandleCellChanged(DataGridCell p_dgcOldCell,DataGridCell p_dgcNewCell)
		{
		}
		#endregion 提供CellChanged功能

		#region 删除功能
		private void m_mthBeforeRowDelete(object p_objSender,DataRowChangeEventArgs p_objArg)
		{
			m_mthHandleRowDelete(this.CurrentRowIndex,p_objArg.Row.ItemArray);
		}

		protected virtual void m_mthHandleRowDelete(int p_intRowIndex,object [] p_objRowData)
		{
		}
		#endregion

		#region 对数据的基本功能（添加、获取、更新、删除、清空所有记录）
		/// <summary>
		/// 添加行
		/// </summary>
		/// <param name="p_objDataArr">行的数据</param>
		protected void m_mthAddRow(object [] p_objDataArr)
		{
			m_dtbGrid.Rows.Add(p_objDataArr);
		}
		/// <summary>
		/// 获取数据的数量
		/// </summary>
		/// <returns></returns>
		protected int m_intRowCount()
		{
			return m_dtbGrid.Rows.Count;
		}
		/// <summary>
		/// 获取行的数据
		/// </summary>
		/// <param name="p_intRowIndex">行的索引，如果索引不正确，返回null</param>
		/// <returns></returns>
		protected object[] m_objGetRow(int p_intRowIndex)
		{
			if(p_intRowIndex < 0 && p_intRowIndex >= m_dtbGrid.Rows.Count)
				return null;

			return m_dtbGrid.Rows[p_intRowIndex].ItemArray;
		}
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns></returns>
		protected object[][] m_objGetRowAll()
		{
			object [][] objValueArr = new object[m_dtbGrid.Rows.Count][];

			for(int i=0;i<m_dtbGrid.Rows.Count;i++)
			{
				objValueArr[i] = m_dtbGrid.Rows[i].ItemArray;
			}

			return objValueArr;
		}
		/// <summary>
		/// 更新行数据
		/// </summary>
		/// <param name="p_intRowIndex">行的索引，如果索引不正确，不做更新</param>
		/// <param name="p_objDataArr">行的数据</param>
		protected void m_mthUpdateRow(int p_intRowIndex,object [] p_objDataArr)
		{
			if(p_intRowIndex < 0 && p_intRowIndex >= m_dtbGrid.Rows.Count)
				return;

			m_dtbGrid.Rows[p_intRowIndex].ItemArray = p_objDataArr;
		}
		/// <summary>
		/// 删除行
		/// </summary>
		/// <param name="p_intRowIndex">行的索引，如果索引不正确，不做删除</param>
		protected void m_mthDeleteRow(int p_intRowIndex)
		{
			if(p_intRowIndex < 0 && p_intRowIndex >= m_dtbGrid.Rows.Count)
				return;

			m_dtbGrid.Rows.RemoveAt(p_intRowIndex);			
		}
		#endregion

		#region 插入功能
		/// <summary>
		/// 插入功能
		/// </summary>
		/// <param name="p_intRowIndex">插入到的索引，新数据将在此索引</param>
		/// <param name="p_objDataArr">插入的数据</param>
		protected void m_mthInsertRow(int p_intRowIndex,object [] p_objDataArr)
		{
			/*
			 * 基本算法：移去指定索引及其后的数据，添加新数据，在添加原来的数据
			 */

			if(p_intRowIndex < 0 || p_objDataArr == null)
				return;

			m_arlTempBuffer.Clear();

			while(p_intRowIndex<m_dtbGrid.Rows.Count)
			{
				m_arlTempBuffer.Add(m_objGetRow(p_intRowIndex));			
				m_mthDeleteRow(p_intRowIndex);
			}			

			m_mthAddRow(p_objDataArr);

			for(int i=0;i<m_arlTempBuffer.Count;i++)
			{
				m_mthAddRow((object[])m_arlTempBuffer[i]);
			}

			m_arlTempBuffer.Clear();
		}
		#endregion 插入功能

		#region 清空功能
		/// <summary>
		/// 清空所有Row
		/// </summary>
		protected void m_mthClearRow()
		{
			this.CurrentRowIndex = 0;

			m_dtbGrid.Rows.Clear();
		}
		#endregion

		#region 提供使某一个Cell选中的功能
		/// <summary>
		/// 提供使某一个Cell选中的功能
		/// </summary>
		/// <param name="p_intRowIndex"></param>
		/// <param name="p_intColumnIndex"></param>
		protected void m_mthSetCellSelected(int p_intRowIndex,int p_intColumnIndex)
		{
			this.CurrentCell = new DataGridCell(p_intRowIndex,p_intColumnIndex);
		}

		#endregion 
	}
}
