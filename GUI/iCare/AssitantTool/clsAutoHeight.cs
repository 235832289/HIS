using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace iCare
{
	/// <summary>
	/// clsAutoHeight 的摘要说明。
	/// </summary>
	public class clsAutoHeight:DataGridTextBoxColumn
	{
		public clsAutoHeight()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
	
		private int currentIteration = 0;

		protected override int GetMinimumHeight()
		{
			try
			{
				StackFrame frame = new StackFrame(4);
				MethodBase method = frame.GetMethod();
				string s = method.DeclaringType.FullName;
				if(s.EndsWith("DataGridAddNewRow"))
				{
					return base.GetMinimumHeight();
				}
				else
				{
				
					CurrencyManager cur = (CurrencyManager)this.DataGridTableStyle.DataGrid.BindingContext
						[this.DataGridTableStyle.DataGrid.DataSource,this.DataGridTableStyle.DataGrid.DataMember];
					if(cur == null || cur.Count == 0)
						return base.GetMinimumHeight();
					
					this.currentIteration++;
			
					int retVal = base.GetMinimumHeight();
					retVal = this.m_intGetStringHeight(GetColumnValueAtRow(cur,currentIteration - 1).ToString());
					if(currentIteration ==	cur.Count)
						this.ResetHeight();	
					return retVal;
				}
			}
			catch
			{
				return base.GetMinimumHeight();
			}
		}
		/// <summary>
		/// Reset the iteration count to 0.
		/// </summary>
		public void ResetHeight()
		{
			currentIteration = 0;
		}
		protected virtual int m_intGetStringHeight(string s)
		{
			try
			{
				System.Drawing.Graphics g = this.TextBox.CreateGraphics();
				((TextBox)this.TextBox).TextAlign=HorizontalAlignment.Center;
				return (int)g.MeasureString(s,this.TextBox.Font).Height + 4;
			}
			catch
			{
				return base.GetMinimumHeight();
			}
		}	
	}

	public class clsAutoHeightScroll:clsAutoHeight
	{
		public clsAutoHeightScroll()
		{
		}
		
	
		protected override int m_intGetStringHeight(string s)
		{
			((TextBox)this.TextBox).ScrollBars=ScrollBars.None;
			((TextBox)this.TextBox).WordWrap=false;
			return base.m_intGetStringHeight (s);
		}
	}
}
