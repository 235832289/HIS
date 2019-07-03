using System;
using System.Windows.Forms;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// PocketDataGrid袖珍功能DataGrid
	/// </summary>
	public delegate void _EnterDown(int i);

	public class PocketDataGrid:DataGrid
	{
		public event _EnterDown EnterDown;
		DateTime gridMouseDownTime;
		public PocketDataGrid()
		{
			AddCustomDataTableStyle();
			this.CaptionVisible=false;
			this.Dock=System.Windows.Forms.DockStyle.Fill;
			this.ReadOnly=true;
			this.CurrentCellChanged+=new EventHandler(m_mthCurrentCellChanged);
			//
			// TODO: 在此处添加构造函数逻辑
			//
					
		}
		#region 更改列
		private void AddCustomDataTableStyle()
		{
			DataGridTableStyle stl = new DataGridTableStyle();
			stl.MappingName = "dt";
			// 设置属性
//			stl.AlternatingBackColor=Color.Gray;
			stl.AllowSorting=false;
			stl.ReadOnly=true;
			stl.AllowSorting=false;
			// 添加Textbox列样式，以便我们捕捉鼠标事件
			DataGridTextBoxColumn TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ITEMCODE_VCHR";
			TextCol.HeaderText = "项目编码";
			TextCol.Width = 100;

			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ITEMNAME_VCHR";
			TextCol.HeaderText = "项目名称";
			TextCol.Width = 150;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ITEMSPEC_VCHR";
			TextCol.HeaderText = "项目规格";
			TextCol.Width = 100;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);
		

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ITEMPRICE_MNY";
			TextCol.HeaderText = "项目价格";
			TextCol.Width = 100;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);


			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ITEMUNIT_CHR";
			TextCol.HeaderText = "项目单位";
			TextCol.Width = 100;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "DOSAGE_DEC";
			TextCol.HeaderText = "基本用量";
			TextCol.Width = 100;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);

			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "DOSAGEUNIT_CHR";
			TextCol.HeaderText = "用量单位";
			TextCol.Width = 100;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);


			TextCol = new DataGridTextBoxColumn();
			TextCol.MappingName = "ITEMOPCODE_CHR";
			TextCol.HeaderText = "门诊收费编码";
			TextCol.Width = 100;
			//添加事件处理器
			TextCol.TextBox.MouseDown += new MouseEventHandler(m_mthMouseDown);
			TextCol.TextBox.DoubleClick += new EventHandler(m_mthDoubleClick);
			stl.GridColumnStyles.Add(TextCol);

			this.TableStyles.Add(stl);
			
		}
	
		#endregion
		protected override void OnMouseDown(MouseEventArgs e)
		{
			gridMouseDownTime = DateTime.Now;
			if(CurrentRowIndex>-1)
			{
				this.Select(this.CurrentRowIndex);
			}
			base.OnMouseDown (e);
		}
	
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			this.Select(this.CurrentRowIndex);
			// TODO:  添加 Class2.ProcessCmdKey 实现
			if((msg.Msg==256) && (msg.WParam.ToInt32() == (int) Keys.Enter)) 
			{
				if(EnterDown!=null)
					EnterDown(this.CurrentRowIndex);
				return true;
			}
			else
			{
				return base.ProcessCmdKey (ref msg, keyData);
			}
		}
		private void m_mthCurrentCellChanged(object sender, System.EventArgs e)
		{
			if(this.CurrentRowIndex>-1)
			{
				this.Select(this.CurrentRowIndex);
			}
		}
		private void m_mthMouseDown(object sender,MouseEventArgs e)
		{
			if(DateTime.Now < gridMouseDownTime.AddMilliseconds(SystemInformation.DoubleClickTime))
			{
				if(this.CurrentRowIndex>-1)
				{
					if(EnterDown!=null)
					{
						EnterDown(this.CurrentRowIndex);
					}
				}
			}
		}
		private void m_mthDoubleClick(object sender,System.EventArgs e)
		{
			if(this.CurrentRowIndex>-1)
			{
				if(EnterDown!=null)
				{
					EnterDown(this.CurrentRowIndex);
				}
			}


		}
		
	}
}
