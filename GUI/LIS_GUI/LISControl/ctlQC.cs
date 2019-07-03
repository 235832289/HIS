using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using com.digitalwave.GUI_Base; //GUI_Base.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ctlQC:PictureBox
	{		

		#region 标签
		private const string c_strXChar="X";

		private const string c_strTitle="广 东 省 医 学 检 验 质 量 控 制 图";
		private const string c_strHospital="单位:";
		private const string c_strLabNo="实验室编号:";
		private const string c_strQCDate="日期:";
		private const string c_strCheckItem="试验项目:";
		private const string c_strMethod="方法:";
		private const string c_strDeviceType="仪器型号:";
		private const string c_strWaveLenth="使用波长:";
		private const string c_strQCSourceAndBatch="质控物来源及批号:";
		private const string c_strButtValue="你室测的靶值" + c_strXChar + ":";
		private const string c_strChroma="浓度:";
		private const string c_strVendorAndQCSampleLot="试剂厂家及批号:";
		private const string c_strReagentExpiration="试剂有效期:";

		private const string c_strUseExplain="使 用 说 明";
		private string [] c_strExplainArr=new String[7] {
														   "    ①  在图左侧标尺",
														   "上注明靶值" + c_strXChar + "，±2s 、",
														   "±3s的数值。",
														   "    ②  图中日期是实",
														   "际操作日期，未作测定",
														   "的星期日和节假日不留",
														   "空格"
													   };

		private const string c_strLostControlReason="失控原因及处理情况:";

		private const string c_strMarkDate		="日  期";
		private const string c_strMarkValue		="测定值";
		private const string c_strMarkOperator	="操作者";

		private const string c_strThisMonthX="本月的" + c_strXChar + ":" ;
		private const string c_strBottomTitle="广东省临床检验中心制";    		

		#endregion

		#region 画图参数定义

		//字体
		public Font m_fntTitle=new Font("宋体",20,FontStyle.Bold);			//标题
		public Font m_fntTitle2= new Font("楷体_GB2312",14,FontStyle.Regular);	//标题2(底部)
		public Font m_fntNormal=new Font("宋体",11,FontStyle.Regular);		//普通
		public Font m_fntBold=new Font("宋体",10,FontStyle.Bold);			//加粗
		public Font m_fntBigBold=new Font("宋体",12,FontStyle.Bold  );			//大号加粗
		public Font m_fntSmall=new Font("宋体",9,FontStyle.Regular);		//小号
		public Font m_fntExplainText=new Font("楷体_GB2312",10,FontStyle.Regular);	//说明文字字体

		//画笔
		private Pen m_LinePen = new Pen(Color.Black,1);
		private Pen m_GridLinePen=Pens.Black;
		private Pen m_BlackPen=Pens.Black;
		private Pen m_DataLinePen=Pens.Black;

		//文本位置
		private float m_fltRow1Top=20;
		private float m_fltRow2Top=65;
		private float m_fltRow3Top=95;
		private float m_fltRow4Top=125;
		private float m_fltRow5Top=155;

		private float m_fltValue1Top ;
		private float m_fltValue2Top;
		private float m_fltValue3Top;

		//控件宽度
		private float m_fltThisWidth=1000;
		private float m_fltThisHeight=650;

		//表格位置
		private PointF m_objGridLeftTop = new PointF(100,180);
		private float m_fltCellWidth =23;				//网格宽度
		private float m_fltCellHeight=5;				//网格高度
		private int m_intRowCount=70;
		private int m_intColCount=31;					//网格列
		private float m_fltNumCellHeight=22;			//底部数据格的高度
		private int m_intNumRowCount=3;					//底部数据格的行数

		private	PointF m_objButtPos;				//靶值(0,0)位置

		private float m_fltUnderLineWidth=100;		//下划线的基准值

		#endregion

		#region 需赋值显示的文本参数
		public string m_strHospital="";
		public string m_strLabNo="";
		public string m_strQCDate="";

		public string m_strCheckItem="";
		public string m_strMethod="";
		public string m_strDeviceType="";
		public string m_strWaveLenght="";

		public string m_strQCSourceAndBatch="";
		public string m_strChroma="";

		public string m_strVendorANDQCSampleLot="";     //试剂厂家、批号及有效期
		public string m_strReagentExpiration="";

		public string m_strLostControlReason="";        //失控原因


		private string m_strRealValue_X="";     //实测的靶值
		private string m_strRealValue_S="";
		private string m_strRealValue_CV="";

		private string m_strButtValue_X="";		//靶值
		private string m_strButtValue_S="";
		private string m_strButtValue_CV="";

		private float m_fltButtValue_X=0;		//表头数值
		private float m_fltButtValue_S=1;
		private float m_fltButtValue_CV=0;

		private float m_fltThisMonth_X=0;		//底部数值(本月)
		private float m_fltThisMonth_S=1;
		private float m_fltThisMonth_CV=0;

		private string m_strThisMonth_X="";
		private string m_strThisMonth_S="";
		private string m_strThisMonth_CV="";

		private string[] m_strMarkValue =new string[7]{ "","","","","","",""};		//坐标右侧数值,从下到上

		#endregion

		//保存文本元素
		private clsTextItem[] m_arrTextItem=null;

		//保存表格元素
		private clsGridItem[] m_arrGridItem=null;

		//Line Item
		private clsLineItem[] m_arrLineItem=null;

		//Print Doc
		public System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintDialog m_printDlg;

		//Print Preview Dialog
		public System.Windows.Forms.PrintPreviewDialog m_printPrevDlg;

		//Creator
		public ctlQC()
		{
			InitializeComponent();

			m_mthInit();
		}

		#region Init 
	
		//初始化
		private void m_mthInit()
		{
			//靶值(0,0)的位置
			m_objButtPos=new PointF(m_objGridLeftTop.X,m_objGridLeftTop.Y + m_fltCellHeight * 35);

			m_fltValue1Top = m_objGridLeftTop.Y + m_intRowCount * m_fltCellHeight ;
			m_fltValue2Top = m_fltValue1Top + m_fltNumCellHeight;
			m_fltValue3Top = m_fltValue2Top + m_fltNumCellHeight ;

			//Init Line Item
			m_mthInitLineItem();

			//Init Grid Item
			m_mthInitGridItem();

			//Init Text Item
			Graphics objThisGrp = this.CreateGraphics();
			using(objThisGrp)
			{
				m_mthInitTextItem(objThisGrp);
			}


		}


		#region 初始化文本元素 m_mthInitTextItem

		private void m_mthInitTextItem(Graphics g)
		{
			m_arrTextItem=new clsTextItem[100];
			for(int i=0;i<m_arrTextItem.Length;i++) m_arrTextItem[i]=null;

			//Row1 (0-4)
			m_arrTextItem[0]=new clsTextItem(c_strTitle,m_fntTitle,g);				//标题
			m_arrTextItem[0].SetPosition((m_fltThisWidth-m_arrTextItem[0].m_objSize.Width)/2 ,m_fltRow1Top);

			//Row2 (5-10)
			m_arrTextItem[5]=new clsTextItem(c_strHospital,m_fntNormal,g);			//单位
			m_arrTextItem[5].SetPosition(m_fltThisWidth * 0.03f , m_fltRow2Top);
			m_arrTextItem[6]=new clsTextItem(m_strHospital,m_fntNormal,g);
			m_arrTextItem[6].SetPosition(m_fltThisWidth * 0.03f + m_arrTextItem[5].m_objSize.Width , m_fltRow2Top);

			m_arrLineItem[0]=new clsLineItem(m_arrTextItem[6],3.4f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[7]=new clsTextItem(c_strLabNo,m_fntNormal,g);				//实验室编号
			m_arrTextItem[7].SetPosition(m_fltThisWidth * 0.46f , m_fltRow2Top);
			m_arrTextItem[8]=new clsTextItem(m_strLabNo,m_fntNormal,g);
			m_arrTextItem[8].SetPosition(m_fltThisWidth * 0.46f + m_arrTextItem[7].m_objSize.Width , m_fltRow2Top);

			m_arrLineItem[1]=new clsLineItem(m_arrTextItem[8],1 * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[9]=new clsTextItem(c_strQCDate,m_fntNormal,g);			//日期
			m_arrTextItem[9].SetPosition(m_fltThisWidth * 0.68f , m_fltRow2Top);
			m_arrTextItem[10]=new clsTextItem(m_strQCDate,m_fntNormal,g);
			m_arrTextItem[10].SetPosition(m_fltThisWidth * 0.68f +m_arrTextItem[9].m_objSize.Width, m_fltRow2Top);

			//Row3 (15-30)
			m_arrTextItem[15]=new clsTextItem(c_strCheckItem,m_fntNormal,g);		//试验项目
			m_arrTextItem[15].SetPosition(m_fltThisWidth * 0.03f , m_fltRow3Top);
			m_arrTextItem[16]=new clsTextItem(m_strCheckItem,m_fntNormal,g);
			m_arrTextItem[16].SetPosition(m_fltThisWidth * 0.03f + m_arrTextItem[15].m_objSize.Width, m_fltRow3Top);

			m_arrLineItem[2]=new clsLineItem(m_arrTextItem[16],1.7f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[17]=new clsTextItem(c_strMethod,m_fntNormal,g);			//方法
			m_arrTextItem[17].SetPosition(m_fltThisWidth * 0.28f , m_fltRow3Top);
			m_arrTextItem[18]=new clsTextItem(m_strMethod,m_fntNormal,g);
			m_arrTextItem[18].SetPosition(m_fltThisWidth * 0.28f + m_arrTextItem[17].m_objSize.Width, m_fltRow3Top);

			m_arrLineItem[3]=new clsLineItem(m_arrTextItem[18],1 * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[19]=new clsTextItem(c_strDeviceType ,m_fntNormal,g);		//仪器型号
			m_arrTextItem[19].SetPosition(m_fltThisWidth * 0.46f , m_fltRow3Top);
			m_arrTextItem[20]=new clsTextItem(m_strDeviceType,m_fntNormal,g);
			m_arrTextItem[20].SetPosition(m_fltThisWidth * 0.46f + m_arrTextItem[19].m_objSize.Width, m_fltRow3Top);

			m_arrLineItem[4]=new clsLineItem(m_arrTextItem[20],1 * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[21]=new clsTextItem(c_strWaveLenth,m_fntNormal,g);		//使用波长
			m_arrTextItem[21].SetPosition(m_fltThisWidth * 0.68f , m_fltRow3Top);
			m_arrTextItem[22]=new clsTextItem(m_strWaveLenght,m_fntNormal,g);
			m_arrTextItem[22].SetPosition(m_fltThisWidth * 0.68f + m_arrTextItem[21].m_objSize.Width, m_fltRow3Top);

			m_arrLineItem[5]=new clsLineItem(m_arrTextItem[22],0.5f * m_fltUnderLineWidth,m_fntNormal );


			//Row4 (31 - 40)(1 - 4)
			m_arrTextItem[31]=new clsTextItem(c_strQCSourceAndBatch,m_fntNormal,g);		//质控物
			m_arrTextItem[31].SetPosition(m_fltThisWidth * 0.03f , m_fltRow4Top);
			m_arrTextItem[32]=new clsTextItem(m_strQCSourceAndBatch,m_fntNormal,g);
			m_arrTextItem[32].SetPosition(m_fltThisWidth * 0.03f + m_arrTextItem[31].m_objSize.Width, m_fltRow4Top);
			
			m_arrLineItem[6]=new clsLineItem(m_arrTextItem[32],2.2f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[33]=new clsTextItem(c_strChroma ,m_fntNormal,g);				//浓度
			m_arrTextItem[33].SetPosition(m_fltThisWidth * 0.39f , m_fltRow4Top);
			m_arrTextItem[34]=new clsTextItem(m_strChroma,m_fntNormal,g);
			m_arrTextItem[34].SetPosition(m_fltThisWidth * 0.39f + m_arrTextItem[33].m_objSize.Width, m_fltRow4Top);

			m_arrLineItem[7]=new clsLineItem(m_arrTextItem[34],0.6f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[35]=new clsTextItem( c_strButtValue,m_fntNormal,g);			//你室测的靶值X
			m_arrTextItem[35].SetPosition(m_fltThisWidth * 0.49f , m_fltRow4Top);

			m_arrTextItem[36]=new clsTextItem( m_strRealValue_X  ,m_fntNormal,g);
			m_arrTextItem[36].SetPosition(m_fltThisWidth * 0.49f + m_arrTextItem[35].m_objSize.Width, m_fltRow4Top);

			m_arrLineItem[8]=new clsLineItem(m_arrTextItem[36], 0.5f * m_fltUnderLineWidth,m_fntNormal );
			m_arrLineItem[13]=new clsLineItem(new PointF(m_arrTextItem[35].m_objPosition.X + 92,m_arrTextItem[35].m_objPosition.Y),new PointF(m_arrTextItem[35].m_objPosition.X + 100,m_arrTextItem[35].m_objPosition.Y));			//X头的上线


			m_arrTextItem[37]=new clsTextItem( "s:",m_fntNormal,g);			// S
			m_arrTextItem[37].SetPosition(m_fltThisWidth * 0.65f , m_fltRow4Top);
			m_arrTextItem[38]=new clsTextItem( m_strRealValue_S ,m_fntNormal,g);
			m_arrTextItem[38].SetPosition(m_fltThisWidth * 0.65f + m_arrTextItem[37].m_objSize.Width, m_fltRow4Top);

			m_arrLineItem[9]=new clsLineItem(m_arrTextItem[38],0.5f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[39]=new clsTextItem( "CV:" ,m_fntNormal,g);			//CV
			m_arrTextItem[39].SetPosition( m_fltThisWidth * 0.72f , m_fltRow4Top);
			m_arrTextItem[40]=new clsTextItem( m_strRealValue_CV  ,m_fntNormal,g);
			m_arrTextItem[40].SetPosition(m_fltThisWidth * 0.72f + m_arrTextItem[39].m_objSize.Width, m_fltRow4Top);
	
			m_arrLineItem[10]=new clsLineItem(m_arrTextItem[40],0.5f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[1]=new clsTextItem( c_strVendorAndQCSampleLot,m_fntNormal,g);       //试剂厂家及批号
			m_arrTextItem[1].SetPosition(m_fltThisWidth * 0.03f,m_fltRow5Top);
			m_arrTextItem[2]=new clsTextItem(m_strVendorANDQCSampleLot,m_fntNormal,g);
			m_arrTextItem[2].SetPosition(m_fltThisWidth * 0.03f + m_arrTextItem[1].m_objSize.Width,m_fltRow5Top);

			m_arrLineItem[17]=new clsLineItem(m_arrTextItem[2],1.5f * m_fltUnderLineWidth,m_fntNormal );

			m_arrTextItem[3]=new clsTextItem( c_strReagentExpiration,m_fntNormal,g);
			m_arrTextItem[3].SetPosition( m_fltThisWidth * 0.33f,m_fltRow5Top);
			m_arrTextItem[4]=new clsTextItem(m_strReagentExpiration,m_fntNormal,g);
			m_arrTextItem[4].SetPosition(m_fltThisWidth * 0.33f + m_arrTextItem[3].m_objSize.Width,m_fltRow5Top);

			m_arrLineItem[18]=new clsLineItem(m_arrTextItem[4],1.5f * m_fltUnderLineWidth,m_fntNormal );

			
			//右侧 +s 坐标  (41- 60)
			float fltMarkX = m_objGridLeftTop.X - 30;

			for(int i=-3;i<=3;i++)
			{
				float fltY= m_objButtPos.Y - i * 10 * m_fltCellHeight - 5 ;
				string strMark= ( i==0 ? c_strXChar.PadLeft(3,' '):i.ToString().Trim().PadLeft(2,' ') + "s");

				m_arrTextItem[45 + i]=new clsTextItem(strMark,m_fntNormal,g);
				m_arrTextItem[45 + i].SetPosition(fltMarkX,fltY);

				m_arrTextItem[55 + i]=new clsTextItem(m_strMarkValue[i+3],m_fntNormal,g);
				m_arrTextItem[55 + i].SetPosition(fltMarkX-40,fltY);
			}
			m_arrLineItem[15]=new clsLineItem(new PointF(m_arrTextItem[45].m_objPosition.X + 16,m_arrTextItem[45].m_objPosition.Y),new PointF(m_arrTextItem[45].m_objPosition.X + 25,m_arrTextItem[45].m_objPosition.Y));			//X头的上线

	
			//文本坐标 ( 61 - 69 )
			fltMarkX= m_objGridLeftTop.X-50;
			string[] strMarkText=new string[3]{c_strMarkDate,c_strMarkValue ,c_strMarkOperator };
			for(int i=0;i<strMarkText.Length;i++)
			{
				float fltY= m_objGridLeftTop.Y + m_fltCellHeight * m_intRowCount + i * m_fltNumCellHeight +5 ;
				m_arrTextItem[61 + i]=new clsTextItem(strMarkText[i],m_fntSmall,g);
				m_arrTextItem[61 + i].SetPosition(fltMarkX,fltY);
			}


			//本月数值 (70-75)
			float fltBottomY=m_objGridLeftTop.Y + m_fltCellHeight * m_intRowCount + m_intNumRowCount * m_fltNumCellHeight + 10;
			string []strBottomText=new string[3]{ c_strThisMonthX + m_strThisMonth_X,"s:" + m_strThisMonth_S, "CV:" + m_strThisMonth_CV};
			for(int i=0;i<strBottomText.Length;i++)
			{
				m_arrTextItem[70 + i]=new clsTextItem(strBottomText[i],m_fntNormal,g);
				m_arrTextItem[70 + i].SetPosition( m_fltThisWidth * (i+1)/6,fltBottomY);
			}
			SizeF objSize = g.MeasureString("本月的",m_fntNormal);
			m_arrLineItem[14]=new clsLineItem(new PointF(m_arrTextItem[70].m_objPosition.X + objSize.Width-5,m_arrTextItem[70].m_objPosition.Y),new PointF(m_arrTextItem[70].m_objPosition.X + objSize.Width + 4,m_arrTextItem[70].m_objPosition.Y));			//X头的上线


			//底部标题 (76- 79)
			m_arrTextItem[76]=new clsTextItem(c_strBottomTitle,m_fntTitle2 ,g);				
			m_arrTextItem[76].SetPosition((m_fltThisWidth-m_arrTextItem[70].m_objSize.Width)/2 ,fltBottomY + 30 );
		
			//使用说明 ( 80 - 90 )
			float fltTextX= m_objGridLeftTop.X + m_intColCount * m_fltCellWidth + m_fltCellWidth/2;
			float fltTextHedith=m_fltNumCellHeight;

			m_arrTextItem[80]=new clsTextItem(c_strUseExplain, m_fntBigBold ,g);			//使用说明
			m_arrTextItem[80].SetPosition(fltTextX + m_fltCellWidth , m_fltRow3Top);

			m_arrLineItem[11]=new clsLineItem(m_arrTextItem[80], m_arrTextItem[80].m_objSize.Width,m_fntBigBold );

			for(int i=0;i<c_strExplainArr.Length;i++)
			{
				m_arrTextItem[81 + i ]=new clsTextItem(c_strExplainArr[i],m_fntExplainText,g);										//详细说明
				m_arrTextItem[81 + i ].SetPosition(fltTextX, m_objGridLeftTop.Y + fltTextHedith * i );
			}
	
			m_arrLineItem[16]=new clsLineItem(new PointF(m_arrTextItem[82].m_objPosition.X + 70,m_arrTextItem[82].m_objPosition.Y),new PointF(m_arrTextItem[82].m_objPosition.X + 79,m_arrTextItem[82].m_objPosition.Y));			//X头的上线

			m_arrTextItem[90 ]=new clsTextItem(c_strLostControlReason,m_fntBigBold,g);					//失控原因					
			m_arrTextItem[90 ].SetPosition(fltTextX, m_objGridLeftTop.Y + fltTextHedith * (c_strExplainArr.Length + 1) );

			m_arrLineItem[12]=new clsLineItem(m_arrTextItem[90],m_arrTextItem[90].m_objSize.Width,m_fntBigBold);

		}


		public void m_mthRefreshTextItem()
		{
			//
			Graphics objThisGrp = this.CreateGraphics();
			using(objThisGrp)
			{
				m_mthInitTextItem(objThisGrp);
			}
		}
		#endregion

		//初始化表格元素
		private void m_mthInitGridItem()
		{
			m_arrGridItem=new clsGridItem[31];
			for(int i=0;i<m_arrGridItem.Length;i++) m_arrGridItem[i]=null;
		}

		//Init Line Item
		private void m_mthInitLineItem()
		{
			m_arrLineItem=new clsLineItem[20];
			for(int i=0;i<m_arrLineItem.Length;i++) m_arrLineItem[i]=null;
		}

		#endregion


		#region  Public Function

		//设置本月数值
		public void m_mthSetThisMonthButtValue(float fltX,float fltS,float fltCV)
		{
			if(fltS==0) fltS=1;

			m_fltThisMonth_X=fltX;
			m_fltThisMonth_S=fltS;
			m_fltThisMonth_CV=fltCV;

			m_strThisMonth_X=fltX.ToString();
			m_strThisMonth_S=fltS.ToString();
			m_strThisMonth_CV=((float)fltCV*100).ToString() + " %" ;
		}

		//设置靶值
		public void m_mthSetButtValue(float fltX,float fltS,float fltCV)
		{
			if(fltS==0) fltS=1;

			//刷新表头数据
			m_fltButtValue_X=fltX;
			m_strButtValue_X=fltX.ToString("0.00");

			m_fltButtValue_S=fltS;
			m_strButtValue_S=fltS.ToString("0.00");
	
			m_fltButtValue_CV=fltCV;
			m_strButtValue_CV=((float)fltCV*100).ToString("0.00") + " %" ;

			//刷新左侧坐标值
			for(int i=-3;i<=3;i++)
			{
				m_strMarkValue[i+3]= ((float)(i*m_fltButtValue_S + m_fltButtValue_X)).ToString("0.00");
			}

			//更新所有点的位置
			for(int i=0;i<m_arrGridItem.Length;i++)
			{
				if(m_arrGridItem[i]==null)
				{
					continue;
				}
				else
				{
					m_arrGridItem[i].SetButtValue(fltX,fltS);
					m_arrGridItem[i].RefreshPosition(m_objButtPos,m_fltCellWidth,m_fltCellHeight);
				}
			}
		}

		//设置实测的X,S,CV
		public void m_mthSetRealButtValue(float fltX,float fltS,float fltCV)
		{
			m_strRealValue_X = fltX.ToString("0.00");
			m_strRealValue_S = fltS.ToString("0.00");
			m_strRealValue_CV = fltCV.ToString("0.00");
		}

		//添加表格元素
		public bool m_blnAddGridItem(DateTime dtDate,float fltValue,string strOperator)
		{
			bool blnOk=false;
			
			int intIndex=1;
			for(int i=0;i<m_arrGridItem.Length;i++)
			{
				if(m_arrGridItem[i]==null)
				{
					m_arrGridItem[i]=new clsGridItem(dtDate,fltValue,strOperator,intIndex);
					m_arrGridItem[i].SetButtValue(m_fltButtValue_X,m_fltButtValue_S);
					m_arrGridItem[i].RefreshPosition(m_objButtPos,m_fltCellWidth,m_fltCellHeight);
					blnOk=true;
					break;
				}
				else
				{
					intIndex++;
				}
			}
			return blnOk;
		}

		//清空表格元素
		public void m_mthClearGridItem()
		{
			for(int i=0;i<m_arrGridItem.Length;i++)
			{
				m_arrGridItem[i]=null;
			}
		}
	
		//打印
		public void ToPrint()
		{
			DialogResult objDlgRes = m_printDlg.ShowDialog();
			if(objDlgRes == DialogResult.Yes)
			{
				printDocument1.Print();
			}
		}

		#region 清空
		//清空
		public void m_mthClear()
		{
			m_mthClearGridItem();
			m_strHospital="";
			m_strLabNo="";
			m_strQCDate="";

			m_strCheckItem="";
			m_strMethod="";
			m_strDeviceType="";
			m_strWaveLenght="";

			m_strQCSourceAndBatch="";
			m_strChroma="";

			m_strVendorANDQCSampleLot="";     //试剂厂家、批号及有效期
			m_strReagentExpiration="";

			m_strLostControlReason="";        //失控原因


			m_strRealValue_X="";     //实测的靶值
			m_strRealValue_S="";
			m_strRealValue_CV="";

			m_strButtValue_X="";		//靶值
			m_strButtValue_S="";
			m_strButtValue_CV="";

			m_strThisMonth_X="";
			m_strThisMonth_S="";
			m_strThisMonth_CV="";

			for(int i=-3;i<=3;i++)
			{
				m_strMarkValue[i+3]= "";
			}

			m_mthRefreshTextItem();
		}
		#endregion

		public void ToPrintReview()
		{
		
		}

		#endregion

		private void ShowErrorMessage(Graphics g,string  strMsg)
		{
			g.DrawString("1",m_fntSmall,Brushes.Black,new Point(0,0));
		}

		//OnPaint
		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
			if(m_blnShow)
			{
				try
				{
					m_mthDrawTextItem(e.Graphics);
				}
				catch(Exception ee)
				{
					ShowErrorMessage(e.Graphics,"1");
				}

				try
				{
					m_mthDrawGridLine(e.Graphics);
				}
				catch(Exception ee){
					ShowErrorMessage(e.Graphics,"2");
				}

				try
				{
					m_mthDrawGridItem(e.Graphics);
				}
				catch(Exception ee){
					ShowErrorMessage(e.Graphics,"3");
				}

				try
				{

					m_mthDrawLineItem(e.Graphics);
				}
				catch(Exception ee){
					ShowErrorMessage(e.Graphics,"4");
				}
				
			}
		}

		#region  Draw Item

		//画文本元素
		private void m_mthDrawTextItem(Graphics g)
		{
			Brush  objBursh=Brushes.Black;

			for(int i=0;i<m_arrTextItem.Length;i++)
			{
				if(m_arrTextItem[i]==null)
				{
					continue;
				}
				else
				{
					g.DrawString(m_arrTextItem[i].m_strValue,m_arrTextItem[i].m_objFont,m_arrTextItem[i].m_objBursh,m_arrTextItem[i].m_objPosition);
				}
			}

			//失控原因
			float fltTextX= m_objGridLeftTop.X + m_intColCount * m_fltCellWidth + m_fltCellWidth/2;
			float fltBlockStartY = m_arrTextItem[90].m_objPosition.Y+m_arrTextItem[90].m_objSize.Height + 20;            
			RectangleF rectLostControlReasonBlock = new RectangleF(fltTextX,fltBlockStartY,m_arrTextItem[90].m_objSize.Width,m_fntExplainText.Height*12+18);
			g.DrawString(m_strLostControlReason,m_fntExplainText,Brushes.Black,rectLostControlReasonBlock);

		}



		//画表格线
		private void m_mthDrawGridLine(Graphics g)
		{
			float fltLeft=m_objGridLeftTop.X;
			float fltTop = m_objGridLeftTop.Y;
			float fltRight=m_objGridLeftTop.X + m_fltCellWidth * m_intColCount;
			float fltBottom=m_objGridLeftTop.Y+ m_fltCellHeight * m_intRowCount + m_fltNumCellHeight * m_intNumRowCount ;

			//横线
			for(int i=0;i<=m_intRowCount;i++)
			{
				float fltY= fltTop + i * m_fltCellHeight;
				if(((i-5)% 10)==0)
				{
					if(i==5 || i==65)
					{
						m_GridLinePen = Pens.Red;
					}
					if(i==15 || i==55)
					{
						m_GridLinePen = Pens.Orange;
					}
					if(i==25 || i==45)
					{
						m_GridLinePen = Pens.LawnGreen;
					}
					if(i==35)
					{
						m_GridLinePen = Pens.Blue;
					}
					g.DrawLine(m_GridLinePen,fltLeft-5,fltY,fltRight,fltY);
					m_GridLinePen = Pens.Black;
				}
				else
				{
					g.DrawLine(m_GridLinePen,fltLeft,fltY,fltRight,fltY);
				}
			}
			//底部
			for(int i=1;i<=m_intNumRowCount;i++)
			{
				float fltY=fltTop + m_fltCellHeight * m_intRowCount + i * m_fltNumCellHeight;
				g.DrawLine(m_GridLinePen,fltLeft,fltY,fltRight,fltY);
			}
			//竖线
			for(int i=0;i<=m_intColCount;i++)
			{
				float fltX= fltLeft + i * m_fltCellWidth;
				g.DrawLine(m_GridLinePen,fltX,fltTop,fltX,fltBottom);
			}
		}


		//画表格元素
		private void m_mthDrawGridItem(Graphics g)
		{
			ArrayList objArr =new ArrayList();
			for(int i=0;i<m_arrGridItem.Length;i++)
			{
				if(m_arrGridItem[i]==null)
				{
					continue;
				}
				else
				{
					objArr.Add(m_arrGridItem[i].GetItemPosition());		//添加到数组
					
					//
					float fltX= (m_arrGridItem[i].m_intIndex -1) * m_fltCellWidth + m_objGridLeftTop.X;
					m_mthDrawGridItemInfo(g,m_arrGridItem[i],fltX);
				}
			}
		
			if(objArr.Count>1)
			{
			
				PointF[] objPoints = new  PointF[objArr.Count];
				for(int i=0;i<objArr.Count;i++)
				{
					objPoints[i]=(PointF)(objArr[i]);
				}
					
				g.DrawLines(m_DataLinePen,objPoints);
				
			}
		}


		//画点信息
		private void m_mthDrawGridItemInfo(Graphics g,clsGridItem objItem,float fltX)
		{
			StringFormat objFormat=new StringFormat();
			objFormat.Alignment=StringAlignment.Center;

			Brush objBrush=Brushes.Black;

			PointF objPoint=objItem.GetItemPosition();
			g.FillRectangle(Brushes.Black,objPoint.X-1,objPoint.Y-1,3,3);

			//g.DrawString(objItem.m_strDate ,m_fntSmall,objBrush,fltX,m_fltValue1Top + 5);

			g.DrawString(objItem.m_dtDate.Day.ToString() ,m_fntSmall,objBrush,fltX,m_fltValue1Top + 1);
			g.DrawString(objItem.m_dtDate.Month.ToString() ,m_fntSmall,objBrush,fltX + 9 ,m_fltValue1Top + 10);
			g.DrawLine( m_BlackPen,fltX + m_fltCellWidth - 5  ,m_fltValue1Top  + 4 ,fltX + 4 ,m_fltValue1Top + m_fltNumCellHeight - 4 );

			g.DrawString(objItem.m_fltValue.ToString("0.0").Trim(),m_fntSmall,objBrush,fltX,m_fltValue2Top+5);

			g.DrawString(objItem.m_strOperator.Trim(),m_fntSmall,objBrush,fltX,m_fltValue3Top+5);
		
		}


		//Draw Line
		private void m_mthDrawLineItem(Graphics g)
		{
			for(int i=0;i<m_arrLineItem.Length;i++)
			{
				if(m_arrLineItem[i]==null)
				{
					continue;
				}
				else
				{
					g.DrawLine(m_BlackPen,m_arrLineItem[i].m_objStart,m_arrLineItem[i].m_objEnd);
				}
			}
		}



		#endregion

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ctlQC));
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.m_printPrevDlg = new System.Windows.Forms.PrintPreviewDialog();
			this.m_printDlg = new System.Windows.Forms.PrintDialog();
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// m_printPrevDlg
			// 
			this.m_printPrevDlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.m_printPrevDlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.m_printPrevDlg.ClientSize = new System.Drawing.Size(400, 300);
			this.m_printPrevDlg.Enabled = true;
			this.m_printPrevDlg.Icon = ((System.Drawing.Icon)(resources.GetObject("m_printPrevDlg.Icon")));
			this.m_printPrevDlg.Location = new System.Drawing.Point(17, 17);
			this.m_printPrevDlg.MinimumSize = new System.Drawing.Size(375, 250);
			this.m_printPrevDlg.Name = "m_printPrevDlg";
			this.m_printPrevDlg.TransparencyKey = System.Drawing.Color.Empty;
			this.m_printPrevDlg.Visible = false;

		}


		//打印
		private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			this.OnPaint(new PaintEventArgs(e.Graphics,e.PageBounds));
		}

		//打印预览
		public void m_mthprintPreview()
		{
			#region 打印设置	
			PaperSize PS = null;
			foreach(PaperSize objPs in ((System.Drawing.Printing.PrintDocument)printDocument1).PrinterSettings.PaperSizes)
			{
				if(objPs.PaperName == "LIS_QC")
				{
					PS = objPs;
					break;
				}
			}
			if(PS != null)
			{
				((System.Drawing.Printing.PrintDocument)printDocument1).DefaultPageSettings.PaperSize = PS;
			}
			else
			{
				try
				{
					string strWidth = "26";
					string strHeight = "18.4";
					if(	Microsoft.VisualBasic.Information.IsNumeric(strWidth) 
						&& Microsoft.VisualBasic.Information.IsNumeric(strHeight))
					{
						double dblWidth_cm = double.Parse(strWidth);//double.Parse(this.m_txtPaperWidth.Text.Trim());
						double dblHeight_cm = double.Parse(strHeight);//double.Parse(this.m_txtPaperHeight.Text.Trim());
						int intWidth_01mm =  (int)(dblWidth_cm * 100);
						int intHeight_01mm = (int)(dblHeight_cm * 100);
						int intWidth_001inc = System.Drawing.Printing.PrinterUnitConvert.Convert(intWidth_01mm,PrinterUnit.TenthsOfAMillimeter,PrinterUnit.Display);
						int intHeight_001inc = System.Drawing.Printing.PrinterUnitConvert.Convert(intHeight_01mm,PrinterUnit.TenthsOfAMillimeter,PrinterUnit.Display);
						PageSettings ps = printDocument1.DefaultPageSettings;
						ps.PaperSize = new PaperSize("LIS_QC",intWidth_001inc,intHeight_001inc);
					}
				}
				catch
				{
					MessageBox.Show("打印机故障！","iCare",MessageBoxButtons.OK,MessageBoxIcon.Information);

				}
			}
		#endregion
		m_printPrevDlg.Document = printDocument1;
			m_printPrevDlg.ShowDialog();
		}

		#region 属性 m_blnEnabled ,设置控件是否有效

		private bool m_blnShow=false;


		public bool m_blnEnabled 
		{
			get
			{
				return m_blnShow;
			}
			set
			{
				m_blnShow=value;
				Invalidate();
			}
		}

		#endregion


	}

	#region Text Item Class

	/// <summary>
	/// 文本元素
	/// </summary>
	class clsTextItem
	{
		public string m_strValue;
		public PointF m_objPosition;
		public SizeF m_objSize;
		public Font m_objFont;
		public Brush m_objBursh=Brushes.Black;

		public clsTextItem (string strValue,Font objFont,Graphics g)
		{
			m_strValue=strValue;
			m_objFont=objFont;
			MeasureSize(g);
		}

		public void MeasureSize(Graphics g)
		{
			m_objSize=g.MeasureString(m_strValue,m_objFont);
		}

		public void SetPosition(float X, float Y)
		{
			m_objPosition=new PointF( X,Y);			
		}
	}

	#endregion

	#region Grid Item Class

	/// <summary>
	/// 网格元素
	/// </summary>
	class clsGridItem
	{
		//基准值
		private float m_fltButtValueX=0;		//靶值

		private float m_fltButtValueS=1;		//S

		//数据
		public DateTime m_dtDate=DateTime.Now;

		public float m_fltValue=0;

		public string m_strOperator;

		public int m_intIndex=0;		//序号(从1开始递增)

		//构造函数
		public clsGridItem(DateTime dtDate,float fltValue,string strOperator,int Index)
		{
			m_dtDate=dtDate;
			m_fltValue=fltValue;
			m_strOperator=strOperator;
			m_intIndex=Index;
		}

		//设置靶值(0,0)
		public void SetButtValue(float fltValueX,float fltValueS)
		{
			if(fltValueS!=0) m_fltButtValueS=fltValueS;
			
			m_fltButtValueX=fltValueX;
		}

		//实际位置
		private float m_fltXPosition=0;
		private float m_fltYPosition=0;

		//刷新元素位置
		public void RefreshPosition(PointF ButtXPos,float fltCellWidth,float fltCellHeight)
		{
			float fltS= (m_fltValue - m_fltButtValueX)/m_fltButtValueS;
			m_fltYPosition= ButtXPos.Y - fltS * 10 * fltCellHeight;

			m_fltXPosition= ButtXPos.X + (m_intIndex - 0.5f) * fltCellWidth;
		}
		
		public PointF GetItemPosition()
		{
			return new PointF(m_fltXPosition,m_fltYPosition);
		}

		public string m_strDate
		{
			get
			{
				return m_dtDate.Day.ToString().Trim() + "/" + m_dtDate.Month.ToString().Trim();
			}
		}
	
	}

	#endregion

	#region Line Item Class
	
	class clsLineItem
	{
		public PointF m_objStart=new PointF(0,0);
		public PointF m_objEnd=new PointF(0,0);

		public clsLineItem(PointF StartPoint,PointF EndPoint)
		{
			m_objStart=StartPoint;
			m_objEnd=EndPoint;
		}

		public clsLineItem(clsTextItem objText,float fltWidth,Font objfnt)
		{
			m_objStart=new PointF(objText.m_objPosition.X,objText.m_objPosition.Y + objfnt.Height );
			m_objEnd=new PointF(objText.m_objPosition.X + fltWidth ,m_objStart.Y);

		}
	}
	#endregion

}
