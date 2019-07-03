using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
namespace iCare 
{
	/// <summary>
	/// 重写ColumnStyle类，实现颜色标识.
	/// </summary>
	public class ColumnStyle:DataGridTextBoxColumn
	{
		public ColumnStyle(PropertyDescriptor pcol)
		{
			//
			// TODO: Add constructor logic here
			//
		}

		protected override void Abort(int RowNum) 
		{
		}

		protected override bool Commit(CurrencyManager DataSource,int RowNum) 
		{
			return true;
		}
		protected override void Edit(CurrencyManager Source ,int Rownum,Rectangle Bounds, bool ReadOnly,string InstantText, bool CellIsVisible) 
		{
		}

		protected override int GetMinimumHeight() 
		{
			//
			// return here your minimum height
			//
			return 16;
		}

		protected override int GetPreferredHeight(Graphics g ,object Value) 
		{
			//
			// return here your preferred height
			//
			return 16;
		}

		protected override Size GetPreferredSize(Graphics g, object Value) 
		{
			//
			// return here your preferred size
			//
			Size cellSize = new Size(75 ,16 );
			return cellSize;
		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum) 
		{
			Brush BackBrush = new SolidBrush(Color.White);
			if( GetColumnValueAtRow(Source, RowNum)is System.DBNull)
			{
				BackBrush = Brushes.White;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
				return;
			}


			string strTemp = (string) GetColumnValueAtRow(Source, RowNum);

			if(strTemp.Trim().Length !=0)
			{
				BackBrush = Brushes.Blue;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

				System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
				g.DrawString( strTemp.ToString() ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );

			}

				

			else
			{
				BackBrush = Brushes.White;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
			}
		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum,bool AlignToRight) 
		{
			Brush BackBrush = new SolidBrush(Color.White);
			if( GetColumnValueAtRow(Source, RowNum)is System.DBNull)
			{
				BackBrush = Brushes.White;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
				return;
			}

			string strTemp = (string) GetColumnValueAtRow(Source, RowNum);

			if(strTemp.Trim().Length !=0)
			{
				BackBrush = Brushes.Blue;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

				System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
				g.DrawString( strTemp.ToString() ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );

			}

				

			else
			{
				BackBrush = Brushes.White;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

			}
		}

		protected override void Paint(Graphics g,Rectangle Bounds,CurrencyManager Source,int RowNum, Brush BackBrush ,Brush ForeBrush ,bool AlignToRight) 
		{
			if( GetColumnValueAtRow(Source, RowNum) is System.DBNull)
			{
				BackBrush = Brushes.White;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);
				return;
			}
			string strTemp = (string) GetColumnValueAtRow(Source, RowNum);
			//			DataTable dt=(DataTable)Source.DataSource;
			//根据行号获取记录号
			if(strTemp.Trim()=="1")
			{
				BackBrush = Brushes.Blue;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

				System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
				//				g.DrawString( strTemp.ToString() ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );

			}
			else
			{
				BackBrush = Brushes.White;
				g.FillRectangle(BackBrush, Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height);

				//				System.Drawing.Font font = new Font(System.Drawing.FontFamily.GenericSansSerif , (float)8.25 );
				//				g.DrawString( strTemp.ToString() ,font ,Brushes.Black ,Bounds.X ,Bounds.Y );
			}	

		} 
	}
}
