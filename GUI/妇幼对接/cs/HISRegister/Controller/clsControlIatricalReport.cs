using System;
using System.Data;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlIatricalReport 的摘要说明。
	/// </summary>
	public class clsControlIatricalReport: com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlIatricalReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmIatricalReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmIatricalReport)frmMDI_Child_Base_in;
		}
		#endregion

		#region 统计数据
		clsDomainControl_Register doMain=new clsDomainControl_Register();
		private DataTable dtEmp=new DataTable();
		private DataTable dtPayType=new DataTable();
		private string startDate;
		private string EndDate;
		/// <summary>
		/// 标志收费类型0-自费，1-公费，2-医保，3-其它,4-公费自费部分,5-医保及刷卡
		/// </summary>
		private string strIsOur="0";
		/// <summary>
		/// -1,统计慢病红会数据，0-统计慢病数据，1-统计红会数据。
		/// </summary>
		private string strIsMB="-1";
		public void m_getData()
		{
			DataTable dtCheckOut;
			DataTable dtCheckOutDe;
			startDate=this.m_objViewer.startDate.Value.ToShortDateString();
			EndDate=this.m_objViewer.endDate.Value.ToShortDateString();
			doMain.m_lngGetIatrical(startDate,EndDate,out dtPayType,out dtCheckOut,out dtCheckOutDe,out dtEmp,this.m_objViewer.m_CboSeleChargeMan.Item.sValue[this.m_objViewer.m_CboSeleChargeMan.SelectedIndex].ToString(),this.m_objViewer.m_getData);
			switch(this.m_objViewer.m_getData)
			{
				case "-1":
					strIsOur="2";
					strIsMB="-1";
					this.m_objViewer.Text="医保统计报表";
					break;
				case "0":
					strIsMB="0";
					strIsOur="2";
					this.m_objViewer.Text="医保统计报表(慢病)";
					break;
				case "1":
					strIsMB="1";
					strIsOur="2";
					this.m_objViewer.Text="医保统计报表(红会)";
					break;

				case "2":
					strIsMB="-1";
					strIsOur="1";
					this.m_objViewer.Text="公费统计报表";
					break;
				case "3":
					strIsMB="0";
					strIsOur="1";
					this.m_objViewer.Text="公费统计报表(慢病)";
					break;
				case "4":
					strIsMB="1";
					strIsOur="1";
					this.m_objViewer.Text="公费统计报表(红会)";
					break;

				case "5":
					strIsMB="-1";
					strIsOur="0";
					this.m_objViewer.Text="自费统计报表";
					break;
				case "6":
					strIsMB="0";
					strIsOur="0";
					this.m_objViewer.Text="自费统计报表(慢病)";
					break;
				case "7":
					strIsMB="1";
					strIsOur="0";
					this.m_objViewer.Text="自费统计报表(红会)";
					break;

				case "8":
					strIsMB="-1";
					strIsOur="3";
					this.m_objViewer.Text="其它统计报表";
					break;

				case "9":
					strIsMB="0";
					this.m_objViewer.Text="其它统计报表(慢病)";
					strIsOur="3";
					break;
				case "10":
					strIsMB="1";
					strIsOur="3";
					this.m_objViewer.Text="其它统计报表(红会)";
					break;

				case "11":
					strIsMB="-1";
					strIsOur="4";
					this.m_objViewer.Text="公费(自费部分)报表";
					break;

				case "12":
					strIsMB="0";
					this.m_objViewer.Text="公费(自费部分)报表(慢病)";
					strIsOur="4";
					break;
				case "13":
					strIsMB="1";
					strIsOur="4";
					this.m_objViewer.Text="公费(自费部分)报表(红会)";
					break;


				case "14":
					strIsMB="-1";
					strIsOur="5";
					this.m_objViewer.Text="医保记帐及刷卡报表";
					break;

				case "15":
					strIsMB="0";
					this.m_objViewer.Text="医保记帐及刷卡报表";
					strIsOur="5";
					break;
				case "16":
					strIsMB="1";
					strIsOur="5";
					this.m_objViewer.Text="医保记帐及刷卡报表";
					break;
			}
			#region 统计各种收费类型的金额
			dtPayType.Columns.Add("tolMoney");
			double data3;
			double data4;
			if(dtCheckOutDe.Rows.Count>=0)
			{
				for(int i1=0;i1<dtPayType.Rows.Count;i1++)
				{
					Double tolMoney=0;
					for(int f2=0;f2<dtCheckOutDe.Rows.Count;f2++)
					{
						
						if(dtCheckOutDe.Rows[f2]["ITEMOPCALCTYPE_CHR"].ToString().Trim()==dtPayType.Rows[i1]["TYPEID_CHR"].ToString().Trim())
						{
							if(strIsOur=="1"||strIsOur=="2"||strIsOur=="3")
							{
								data3=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLPRICE_MNY"].ToString().Trim());
								data4=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLFEE_MNY"].ToString().Trim());
								tolMoney=tolMoney+data4-data3;
					
							}
							else if(strIsOur=="5")
							{
								if(dtCheckOutDe.Rows[f2]["PAYTYPE_INT"].ToString()=="1")
								{
									tolMoney+=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLPRICE_MNY"].ToString().Trim());
								}
								if(dtCheckOutDe.Rows[f2]["INTERNALFLAG_INT"].ToString()=="2")
								{
									data3=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLPRICE_MNY"].ToString().Trim());
									data4=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLFEE_MNY"].ToString().Trim());
									tolMoney=tolMoney+data4-data3;
								}
								

							}
							else
							{
								if(strIsOur=="0")
								{
									if(dtCheckOutDe.Rows[f2]["PAYTYPE_INT"].ToString()!="1"&&dtCheckOutDe.Rows[f2]["PAYTYPE_INT"].ToString()!="3")
										tolMoney+=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLPRICE_MNY"].ToString().Trim());
								}
								else
								{
									if(dtCheckOutDe.Rows[f2]["PAYTYPE_INT"].ToString()!="1"&&dtCheckOutDe.Rows[f2]["PAYTYPE_INT"].ToString()!="3")
										tolMoney+=Convert.ToDouble(dtCheckOutDe.Rows[f2]["TOLPRICE_MNY"].ToString().Trim());
								}
							}
						}
					}
					dtPayType.Rows[i1]["tolMoney"]=tolMoney.ToString("0.00");
				}
			}
			#endregion
			dtEmp.Columns.Add("医保记帐合计金额");
			dtEmp.Columns.Add("医保人次数");
			decimal data1;
			decimal data2;
			for(int i1=0;i1<dtCheckOut.Rows.Count;i1++)
			{
					for(int f2=0;f2<dtEmp.Rows.Count;f2++)
					{
						if(dtEmp.Rows[f2]["医保记帐合计金额"].ToString()=="")
						{
							dtEmp.Rows[f2]["医保记帐合计金额"]=0;
						}
						if(dtEmp.Rows[f2]["医保人次数"].ToString()=="")
						{
							dtEmp.Rows[f2]["医保人次数"]=0;
						}
						if(dtCheckOut.Rows[i1]["BALANCEEMP_CHR"].ToString()==dtEmp.Rows[f2]["BALANCEEMP_CHR"].ToString())
						{
							if(strIsOur=="1"||strIsOur=="2"||strIsOur=="3")
							{
								data1=decimal.Parse(dtEmp.Rows[f2]["医保记帐合计金额"].ToString());
								data2=decimal.Parse(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								dtEmp.Rows[f2]["医保记帐合计金额"]=data1+data2;
							}
							else if(strIsOur=="5")
							{
								if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()=="1")
								{
									data1=decimal.Parse(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString().Trim());
									data2=decimal.Parse(dtEmp.Rows[f2]["医保记帐合计金额"].ToString());
									dtEmp.Rows[f2]["医保记帐合计金额"]=data1+data2;
								}
								if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString()=="2")
								{
									data1=decimal.Parse(dtEmp.Rows[f2]["医保记帐合计金额"].ToString());
									data2=decimal.Parse(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
									dtEmp.Rows[f2]["医保记帐合计金额"]=data1+data2;
								}
								

							}
							else
							{
								if(strIsOur=="0")
								{
									if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()!="1"&&dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()!="3")
									{
										data1=decimal.Parse(dtEmp.Rows[f2]["医保记帐合计金额"].ToString());
										data2=decimal.Parse(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
										dtEmp.Rows[f2]["医保记帐合计金额"]=data1+data2;
									}
								}
								else
								{
									if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()!="1"&&dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()!="3")
									{
										data1=decimal.Parse(dtEmp.Rows[f2]["医保记帐合计金额"].ToString());
										data2=decimal.Parse(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
										dtEmp.Rows[f2]["医保记帐合计金额"]=data1+data2;
									}
								}
							}
							dtEmp.Rows[f2]["医保人次数"]=Convert.ToInt32(dtEmp.Rows[f2]["医保人次数"])+1;
						}
					}
			}

			#region 添加合计行
			int totalNumber=0;
			double tolalMoney=0;
			if(dtEmp.Rows.Count>0)
			{
				for(int i1=0;i1<dtEmp.Rows.Count;i1++)
				{
					if(dtEmp.Rows[i1]["医保记帐合计金额"].ToString()!="0")
					{
						tolalMoney+=Convert.ToDouble(dtEmp.Rows[i1]["医保记帐合计金额"]);
						totalNumber+=Convert.ToInt32(dtEmp.Rows[i1]["医保人次数"]);
					}
				}
			}
			DataRow newRow=dtEmp.NewRow();
			newRow["BALANCEEMP_CHR"]="11111";
			newRow["LASTNAME_VCHR"]="统计行";
			newRow["医保记帐合计金额"]=tolalMoney;
			newRow["医保人次数"]=totalNumber;
			dtEmp.Rows.Add(newRow);
			#endregion
		}
		#endregion


		public void printPageFS(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=0;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",15);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",11);//文字使用的字体
			System.Drawing.Font TextFontBold=new Font("宋体",11,System.Drawing.FontStyle.Bold);//文字使用的字体(加粗）
			const float RowHight=25F;//项的高度
			const float LeftWith=30F;//左右宿进的长度
			const float Uphight=15F;//上下宿进的长度
			const float fontHight=7;//字在表格中显示的位置
			float SaveStartHight=0;
			#endregion

			#region 头部
			Pen penLine=new Pen(Brushes.Black,1);
			curRowY=RowHight+Uphight+10;
			curRowX+=LeftWith;
			string strName=this.m_objComInfo.m_strGetHospitalTitle();
			string strTilName="";
			string strMoneyName="";
			string strCountMan="0";
			switch(strIsOur)
			{
				case "0":
					if(strIsMB=="-1")
						strTilName="自费统计报表";
					if(strIsMB=="0")
						strTilName="自费统计报表（慢病）";
					if(strIsMB=="1")
						strTilName="自费统计报表（红会）";
					strMoneyName="自费合计金额";
					strCountMan="自费人次数";
					break;
				case "1":
					if(strIsMB=="-1")
						strTilName="公费统计报表";
					if(strIsMB=="0")
						strTilName="公费统计报表（慢病）";
					if(strIsMB=="1")
						strTilName="公费统计报表（红会）";
					strMoneyName="记帐合计金额";
					strCountMan="公费人次数";
					break;
				case "2":
					if(strIsMB=="-1")
						strTilName="医保统计报表";
					if(strIsMB=="0")
						strTilName="医保统计报表（慢病）";
					if(strIsMB=="1")
						strTilName="医保统计报表（红会）";
					strMoneyName="记帐合计金额";
					strCountMan="医保人次数";
					break;
				case "3":
					if(strIsMB=="-1")
						strTilName="其它统计报表";
					if(strIsMB=="0")
						strTilName="其它统计报表（慢病）";
					if(strIsMB=="1")
						strTilName="其它统计报表（红会）";
					strMoneyName="记帐合计金额";
					strCountMan="其它人次数";
					break;
				case "4":
					if(strIsMB=="-1")
						strTilName="公费(自费部分)报表";
					if(strIsMB=="0")
						strTilName="公费(自费部分)报表（慢病）";
					if(strIsMB=="1")
						strTilName="公费(自费部分)报表（红会）";
					strMoneyName="自费合计金额";
					strCountMan="自费人次数";
					break;
				case "5":
					if(strIsMB=="-1")
						strTilName="医保记帐及刷卡统计报表";
					if(strIsMB=="0")
						strTilName="医保记帐及刷卡统计报表（慢病）";
					if(strIsMB=="1")
						strTilName="医保记帐及刷卡统计报表（红会）";
					strMoneyName="合计金额";
					strCountMan="人次数";
					break;
			}
			SizeF tilWith= e.Graphics.MeasureString(strName+strTilName,m_fntTitle);
			e.Graphics.DrawString(strName+strTilName,m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,Uphight);


			e.Graphics.DrawString("结帐日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("结帐日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString("从"+startDate+"到"+EndDate,TextFont,Brushes.Black,curRowX,curRowY);
			e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,PageWidth-250,curRowY);
			tilWith= e.Graphics.MeasureString("打印日期：",TextFont);
			string NowDate=DateTime.Now.ToShortDateString();
			e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,PageWidth-250+tilWith.Width,curRowY);
			#endregion
			curRowX=LeftWith;
			curRowY+=18;
			SaveStartHight=curRowY;
			#region 正文
			int totalnumber=0;
			for(int i1=0;i1<dtEmp.Rows.Count;i1++)
			{
				if(dtEmp.Rows[i1]["医保记帐合计金额"].ToString()!="0"||dtEmp.Rows[i1]["LASTNAME_VCHR"].ToString()=="统计行")
				{
					totalnumber++;
					curRowX=LeftWith;
					e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-LeftWith,curRowY);
					e.Graphics.DrawLine(penLine,curRowX,curRowY+RowHight,PageWidth-LeftWith,curRowY+RowHight);
					e.Graphics.DrawLine(penLine,curRowX,curRowY+RowHight*2,PageWidth-LeftWith,curRowY+RowHight*2);
					if(i1==dtEmp.Rows.Count-1)
					{
						int totail=totalnumber-1;
						e.Graphics.DrawString("缴款人数",TextFont,Brushes.Black,curRowX+5,curRowY+5);
						tilWith=e.Graphics.MeasureString("缴款人 数",TextFont);
						curRowX+=tilWith.Width;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
						curRowX+=5;
						e.Graphics.DrawString(totail.ToString()+" 人",TextFont,Brushes.Black,curRowX,curRowY+5);
					}
					else
					{
						e.Graphics.DrawString("缴 款 人",TextFont,Brushes.Black,curRowX+5,curRowY+5);
						tilWith=e.Graphics.MeasureString("缴款人 数",TextFont);
						curRowX+=tilWith.Width;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
						curRowX+=5;
						e.Graphics.DrawString(dtEmp.Rows[i1]["LASTNAME_VCHR"].ToString(),TextFont,Brushes.Black,curRowX,curRowY+5);
					}
					curRowX+=70;
					e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
					curRowX+=5;
					if(i1==dtEmp.Rows.Count-1)
					{
						e.Graphics.DrawString("全部合计金额",TextFont,Brushes.Black,curRowX,curRowY+5);
					}
					else
					{
						e.Graphics.DrawString(strMoneyName,TextFont,Brushes.Black,curRowX,curRowY+5);
					}
					tilWith=e.Graphics.MeasureString("记帐合计金额",TextFont);
					curRowX+=tilWith.Width;
					e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
					curRowX+=5;
					float ChMoney=float.Parse(dtEmp.Rows[i1]["医保记帐合计金额"].ToString());
					string strChMoney=clsMain.CurrencyToString(Math.Abs(ChMoney));
					e.Graphics.DrawString(strChMoney,TextFont,Brushes.Black,curRowX,curRowY+5);
					curRowX+=255;
					e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
					e.Graphics.DrawString("￥"+dtEmp.Rows[i1]["医保记帐合计金额"].ToString(),TextFont,Brushes.Black,curRowX,curRowY+5);
					curRowX+=100;
					e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
					curRowX+=5;
					if(i1==dtEmp.Rows.Count-1)
					{
						e.Graphics.DrawString("合计人次数",TextFont,Brushes.Black,curRowX,curRowY+5);
					}
					else
					{
						e.Graphics.DrawString(strCountMan,TextFont,Brushes.Black,curRowX,curRowY+5);
					}
					tilWith=e.Graphics.MeasureString("合计人次数",TextFont);
					curRowX+=tilWith.Width;
					e.Graphics.DrawLine(penLine,curRowX,curRowY,curRowX,curRowY+RowHight);
					e.Graphics.DrawString(dtEmp.Rows[i1]["医保人次数"].ToString()+"人",TextFont,Brushes.Black,curRowX,curRowY+5);
					curRowY+=RowHight*2;
				}
			}
			#endregion

			#region 填充收费类型数据
			if(dtPayType.Rows.Count>0)
			{
				curRowY+=7;
				float tmpWith=LeftWith+2;
				for(int f2=0;f2<dtPayType.Rows.Count;f2++)
				{
					if(f2%5==0&&f2!=0)
					{
						tmpWith=LeftWith+2;
						curRowY+=RowHight+5;
					}
					tilWith= e.Graphics.MeasureString("打印日期",TextFont);
					if(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length>4)
					{
						string star=dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0,4);
						string end=dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
						e.Graphics.DrawString(star,TextFont,Brushes.Black,tmpWith,curRowY-5);
						e.Graphics.DrawString(end+"：",TextFont,Brushes.Black,tmpWith,curRowY+10);
						e.Graphics.DrawString(Convert.ToDouble(dtPayType.Rows[f2]["tolMoney"].ToString()).ToString("0.00")+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
					}
					else
					{
						e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim()+"：",TextFont,Brushes.Black,tmpWith,curRowY);
						e.Graphics.DrawString(Convert.ToDouble(dtPayType.Rows[f2]["tolMoney"].ToString()).ToString("0.00")+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
					}
					tmpWith+=150;
				}
			}
			curRowY+=RowHight;
			curRowX=LeftWith;
			e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-LeftWith,curRowY);
			curRowX+=2;
			curRowY+=7;
			e.Graphics.DrawString("统计人：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("统计人： ",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,curRowX,curRowY);
			curRowX+=200;
			e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,curRowX,curRowY);
			curRowX+=200;
			e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,curRowX,curRowY);
			curRowY+=RowHight-7;
			e.Graphics.DrawLine(penLine,LeftWith,curRowY,PageWidth-LeftWith,curRowY);

			e.Graphics.DrawLine(penLine,LeftWith,SaveStartHight,LeftWith,curRowY);
			e.Graphics.DrawLine(penLine,PageWidth-LeftWith,SaveStartHight,PageWidth-LeftWith,curRowY);
			#endregion

		}

	}
}
