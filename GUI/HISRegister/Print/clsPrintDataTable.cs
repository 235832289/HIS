using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsPrintDataTable 的摘要说明。
	/// </summary>
	public class clsPrintDataTable
	{
		#region 全局变量
		/// <summary>
		/// 报表名称
		/// </summary>
		public string strReportName ="";
		/// <summary>
		/// 医院名称
		/// </summary>
		public string strHospitalName ="";
		/// <summary>
		/// 开始时间
		/// </summary>
		public string strBeginTime ="";
		/// <summary>
		/// 结束时间
		/// </summary>
		public string strEndTime="";
		/// <summary>
		/// 打印人
		/// </summary>
		public string strPrinter="";
		/// <summary>
		/// 当前页数
		/// </summary>
		private int intPageLocation=1;
		/// <summary>
		/// 标题字体1
		/// </summary>
		Font objFontTitle1;
		/// <summary>
		/// 标题字体2
		/// </summary>
		Font objFontTitle2;
		/// <summary>
		/// 正常字体
		/// </summary>
		Font objFontNormal;
		/// <summary>
		/// 左边距
		/// </summary>
		float fltLeftIndentProp=0.07f;
		/// <summary>
		/// 右边距
		/// </summary>
		float fltRightIndentProp=0.07f;
		/// <summary>
		/// 行间隔
		/// </summary>
		private  float  fltRowHeight=0;
		/// <summary>
		///列宽
		/// </summary>
		private  float  fltRowWidth=0.055f;
		/// <summary>
		/// 纵坐标
		/// </summary>
		private float  Y;
		/// <summary>
		/// 横坐标
		/// </summary>
		private float  X;
		/// <summary>
		/// 记录最搞的Y坐标
		/// </summary>
		private float Y2=0;
		/// <summary>
		/// 当前打列到的行号
		/// </summary>
		private int row=0;
		/// <summary>
		/// 当前打印的列
		/// </summary>
		private int Col =0;
		/// <summary>
		/// 数据表
		/// </summary>
		private DataTable dt;
		/// <summary>
		/// 数据源
		/// </summary>
		public DataTable SetDataSource
		{
			set
			{
			dt =value;
			}
		}
		
		#endregion
		public clsPrintDataTable()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			objFontTitle1=new Font("SimSun",12,FontStyle.Bold);
			objFontTitle2=new Font("SimSun",16,FontStyle.Bold);
			objFontNormal=new Font("SimSun",10);
		}
		#region 获取总的页数和每页的行数	
		/// <summary>
		/// 每页的行数
		/// </summary>
		/// <param name="e"></param>
		private int intRowCount =0;
		/// <summary>
		/// 总的页数
		/// </summary>
		/// <param name="e"></param>
		private int intPageCount =0;
		/// <summary>
		/// 每页可以打印的列数
		/// </summary>
		private int intPageTemp =0;
		private void m_mthGetPageCount(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(intRowCount!=0)
			{
				return;
			}
			//每行能打印的列数fltLeftIndentProp*2是为了第一列加宽
			double d1 =(1-this.fltLeftIndentProp-this.fltRightIndentProp)/this.fltRowWidth;
			double intPageTemp1=Math.Floor(d1);
			intPageTemp =(int)intPageTemp1;
//			 intPageTemp=(int)Math.Floor((1-this.fltLeftIndentProp-this.fltRightIndentProp)/this.fltRowWidth);
			//获取总的列数要几的页数
			double d2 =this.dt.Columns.Count/intPageTemp1;
			double intPageCountTemp =Math.Ceiling(d2);
			//总的高度
			float fltPageHeight =e.PageBounds.Height;
			//获取每页能打多少行.
			double d3 =(fltPageHeight -Y-this.fltRowHeight)/this.fltRowHeight;
			double intRowCount1 =Math.Floor(d3);
			intRowCount=(int)intRowCount1;
			//获取总的行数要打的页数
			double d4 =this.dt.Rows.Count/intRowCount1;
			double intRowCountTemp =Math.Ceiling(d4);
			for(int i=1;i<intRowCountTemp;i++)
			{
			Object[] oTemp =dt.Rows[0].ItemArray;
			DataRow drTemp =dt.NewRow();
			drTemp.ItemArray =oTemp;
			this.dt.Rows.InsertAt(drTemp,i*intRowCount);
			}
			double d5 =this.dt.Rows.Count/intRowCount1;
			 intRowCountTemp =Math.Ceiling(d5);
//			intRowCountTemp =Math.Ceiling(this.dt.Rows.Count/intRowCount);
			//总的页数等于总的行分页乘总的列分页数
			intPageCount =(int)(intRowCountTemp*intPageCountTemp);
		

		}
		#endregion
		#region 打印

		public void m_mthPrintMultWorkLoad(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(dt==null)
			{
			return;
			}
			Pen objPen =new Pen(Color.Black,1);
			this.m_mthPrintTitle(e);
//			this.m_mthGetPageCount(e);//获取页数
			this.m_mthPrintColumn(e);
//			//			    X+=e.PageBounds.Width*this.fltRowWidth;
////			if(this.m_objViewer.radioButton4.Checked)
////			{
//				X+=30;
////			}
//			Y=Y2;
//			if(this.intPageLocation==0)
//			{
//				X+=e.PageBounds.Width*this.fltRowWidth;
//				this.m_mthPrintColumn(1,e);
//			}
//			for(int i=row;i<dt.Columns.Count;i++)
//			{
//				if(X>e.PageBounds.Width*(1-this.fltRowWidth-this.fltRightIndentProp))
//				{
//					e.HasMorePages =true;
//					intPageLocation+=1;
//					float temp =X+e.PageBounds.Width*this.fltRowWidth;
//					e.Graphics.DrawLine(objPen,temp,Y2,temp,Y2+fltRowHeight*dt.Rows.Count);
//					break;
//				}
//				X+=e.PageBounds.Width*this.fltRowWidth;//把坐标复位
//				Y=Y2;
//				this.m_mthPrintColumn(i,e);
//				row =i;//记录当前画到那一列
//			}
//			X+=e.PageBounds.Width*this.fltRowWidth;//定位在最后一条线上
//			e.Graphics.DrawLine(objPen,X,Y2,X,Y2+fltRowHeight*dt.Rows.Count);//画最后一条线
//			objPen.Dispose();
//			objPen=null;
		}
		#endregion
		#region 打印标题
		private void m_mthPrintTitle(System.Drawing.Printing.PrintPageEventArgs objDraw)
		{
			//标题
			//医院名称
			SizeF objFontSize =objDraw.Graphics.MeasureString(this.strHospitalName+this.strReportName,this.objFontTitle1);
			X=(objDraw.PageBounds.Width-objFontSize.Width)/2;
			Y=objDraw.PageBounds.Height*0.047f-(objFontSize.Height/2);
			objDraw.Graphics.DrawString(this.strHospitalName+this.strReportName,objFontTitle1,Brushes.Black,X,Y);
			Y+=objFontSize.Height+15;
			//日期
			X=objDraw.PageBounds.Width*fltLeftIndentProp;
			objFontSize =objDraw.Graphics.MeasureString("统计时间:"+this.strBeginTime+" ~ "+this.strEndTime,this.objFontNormal);
			fltRowHeight =objFontSize.Height+2;	//获取行高
			objDraw.Graphics.DrawString("统计时间:"+this.strBeginTime+" ~ "+this.strEndTime,objFontNormal,Brushes.Black,X,Y);

			X+=objFontSize.Width+20;
			//打印时间
			objFontSize =objDraw.Graphics.MeasureString("打印时间:"+DateTime.Now.ToString("yyyy-MM-dd hh:mm"),this.objFontNormal);
			objDraw.Graphics.DrawString("打印时间:"+DateTime.Now.ToString("yyyy-MM-dd hh:mm"),objFontNormal,Brushes.Black,X,Y);
			//页码
			objFontSize =objDraw.Graphics.MeasureString("第1 页共 10 页",this.objFontNormal);
			X =objDraw.PageBounds.Width*(1-this.fltRightIndentProp)-objFontSize.Width;
			this.m_mthGetPageCount(objDraw);//获取页数
			objDraw.Graphics.DrawString("第"+this.intPageLocation.ToString()+" 页共 "+intPageCount.ToString()+" 页",objFontNormal,Brushes.Black,X,Y);
			Y+=objFontSize.Height+2;
			Y2=Y;
			fltRowHeight =objFontSize.Height+2;	

		}
		#endregion
		#region 打印指定的列
		private void m_mthPrintColumn(System.Drawing.Printing.PrintPageEventArgs objDraw)
		{
			X=objDraw.PageBounds.Width*fltLeftIndentProp;
			Pen objPen =new Pen(Color.Black,1);
//			float RX=X+objDraw.PageBounds.Width*this.fltRowWidth;
//			if(columnNo==0)
//			{
//				RX +=30;
//			}
			//要循环的次数
			int iniLimint=0;
			if(this.row+this.intRowCount>=this.dt.Rows.Count)
			{
				iniLimint  =this.dt.Rows.Count -this.row;
			}
			else
			{
				iniLimint =this.intRowCount;
			}
			int intColmnsLimint =0;
			//列循环次
			if(this.Col+this.intPageTemp>=this.dt.Columns.Count)
			{
				intColmnsLimint  =this.dt.Columns.Count -this.Col;
			}
			else
			{
				intColmnsLimint =this.intPageTemp;
			}
		    float RX=X+this.fltRowWidth*intColmnsLimint*objDraw.PageBounds.Width;
			if(Col==0)
			{
				RX+=30;
			}
			X=objDraw.PageBounds.Width*fltLeftIndentProp;
//			objDraw.Graphics.DrawLine(objPen,X,Y,X,Y+fltRowHeight*iniLimint);//画左竖线
			//记录
			int intColTemp =Col;
			for(int i =0;i<iniLimint;i++)
			{
				X=objDraw.PageBounds.Width*fltLeftIndentProp;
				objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);//画横线
				Col =intColTemp;
				for(int i2=0;i2<intColmnsLimint;i2++)
				{
					if(i==0)
					{
						objDraw.Graphics.DrawLine(objPen,X,Y,X,Y+fltRowHeight*iniLimint);//画左竖线
					}
					objDraw.Graphics.DrawString(dt.Rows[row][Col].ToString(),objFontNormal,Brushes.Black,X+1,Y+3);
					X+=this.fltRowWidth*objDraw.PageBounds.Width;
					if(Col==0)
					{
						X+=30;
					}
					Col++;
				}
				if(i==0)
				{
					objDraw.Graphics.DrawLine(objPen,X,Y,X,Y+fltRowHeight*iniLimint);//画左竖线
				}
				row++;
				
//				objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
//				objDraw.Graphics.DrawString(dt.Rows[i][columnNo].ToString(),objFontNormal,Brushes.Black,X+1,Y+2);
				Y+=fltRowHeight;

			}
			X=objDraw.PageBounds.Width*fltLeftIndentProp;
			objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);//画最后一条横线
			objPen.Dispose();
			objPen =null;
			if(Col<this.dt.Columns.Count)
			{
				objDraw.HasMorePages =true;
				row =row2;
				this.intPageLocation++;
				return;
			}
			row2=row;
			if(row<this.dt.Rows.Count)
			{
				objDraw.HasMorePages =true;
				Col =0;
				this.intPageLocation++;
				return;
			}
		}
		private int row2 =0;
		#endregion
	
	}
}
