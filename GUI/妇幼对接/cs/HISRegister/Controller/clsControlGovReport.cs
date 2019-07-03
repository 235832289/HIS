using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Drawing.Printing;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlGovReport 的摘要说明。
	/// </summary>
	public class clsControlGovReport: com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlGovReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmGovReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmGovReport)frmMDI_Child_Base_in;
		}
		#endregion

		#region 变量
		clsDomainControl_Register Domain=new clsDomainControl_Register();
		/// <summary>
		/// 统计表
		/// </summary>
		private DataTable dtStat=new DataTable();
		/// <summary>
		/// 返回每一种类型所包含的发票类型
		/// </summary>
		private DataTable dtCheck=new DataTable();
//		/// <summary>
//		/// 身份类型ID—自付比例
//		/// </summary>
//		private string[,] arrPatType=new string[,] {{"0014","10"},{"0015","20"},{"0016","0"},{"0017","10"},{"0018","20"},{"0019","0"},{"0020","10"},{"0021","20"},{"0022","0"},{"0023","10"},{"0024","20"},{"0025","0"},{"0026","10"},{"0027","20"},{"0028","0"},{"0029","10"},{"0030","20"},{"0031","0"},{"0032","10"},{"0033","20"},{"0034","0"},{"0035","10"},{"0036","20"},{"0037","0"},{"0038","10"},{"0039","20"},{"0040","0"},{"0041","10"},{"0042","20"},{"0043","0"},{"0044","10"},{"0045","20"},{"0046","0"}};
		/// <summary>
		/// 保存发票号所属的公医办
		/// </summary>
		private string[,] arrType=new string[,] {{"30","荔湾区公医办"},{"31","荔湾区公医办"},{"32","荔湾区公医办"},{"A0","荔湾区公医办"},{"A1","荔湾区公医办"},{"A2","荔湾区公医办"},{"40","海珠区公医办"},{"41","海珠区公医办"},{"42","海珠区公医办"},{"B0","芳村区公医办"},{"B1","芳村区公医办"},{"B2","芳村区公医办"},{"50","白云区公医办"},{"51","白云区公医办"},{"52","白云区公医办"},{"00","市公医办"},{"01","市公医办"},{"02","市公医办"},{"10","东山区公医办"},{"11","东山区公医办"},{"12","东山区公医办"},{"20","越秀区公医办"},{"21","越秀区公医办"},{"22","越秀区公医办"},{"83","省公医办"},{"90","省公医办"}};
		/// <summary>
		/// 保存报表字段维护表中的字段信息
		/// </summary>
		private string[,] arrAllMoney=new string[,] {{"0001","西药"},{"0002","中成药"},{"0003","中药"},{"0004","检查"},{"0005","治疗"},{"0006","诊金"}};
		/// <summary>
		/// 保存报表字段维护表中的报表ID
		/// </summary>
		private string strReportID="0010";
		#endregion

		#region 统计数据
		public void m_getGovData(string StarDate,string EndDate)
		{
			DataTable dtGovData=new DataTable();
			Domain.m_lngGetPublicMoney(StarDate,EndDate,out dtGovData);
			dtStat.Clear();
			try
			{
				dtStat.Columns.Add("公费号");
				dtStat.Columns.Add("中药");
				dtStat.Columns.Add("中成药");
				dtStat.Columns.Add("西药");
				dtStat.Columns.Add("检查");
				dtStat.Columns.Add("治疗");
				dtStat.Columns.Add("诊金");
				dtStat.Columns.Add("自付比例");
			}
			catch
			{
			}
			#region 统计数据
			if(dtGovData.Rows.Count>0)
			{
				Domain.m_lngGetGopRla(out dtCheck);
				string filter="";
				DataRow[] objRow;
//				string strPercent="";//当前发票的自付比例
				for(int i1=0;i1<dtGovData.Rows.Count;i1++)
				{
//					#region 获取当前发票的自付比例
//					for(int L4=0;L4<arrPatType.Length/2;L4++)
//					{
//						if(arrPatType[L4,0]==dtGovData.Rows[i1]["PAYTYPEID_CHR"].ToString().Trim())
//						{
//							strPercent=arrPatType[L4,1];
//							break;
//						}
//					}
//					#endregion
					string strType=dtGovData.Rows[i1]["GOVCARD_CHR"].ToString().Substring(0,2).ToUpper();
					for(int t1=0;t1<arrAllMoney.Length/2;t1++)
					{
						filter="RPTID_CHR ='"+strReportID+"' and GROUPID_CHR ='"+arrAllMoney[t1,0]+"'";
						objRow=dtCheck.Select(filter);
						if(objRow.Length>0)
						{
							for(int f2=0;f2<objRow.Length;f2++)
							{
								if(dtGovData.Rows[i1]["ITEMCATID_CHR"].ToString().Trim()==objRow[f2]["TYPEID_CHR"].ToString().Trim())
								{
									if(dtStat.Rows.Count>0)
									{
										//判断统计表中是否己经存在相同类型的数据
										for(int k3=0;k3<dtStat.Rows.Count;k3++)
										{
											if(dtStat.Rows[k3]["公费号"].ToString()==strType&&dtStat.Rows[k3]["自付比例"].ToString()==dtGovData.Rows[i1]["CHARGEPERCENT_DEC"].ToString().Trim())
											{
												//如果存在修改原来的数据
												dtStat.Rows[k3][arrAllMoney[t1,1]]=Convert.ToDouble(dtStat.Rows[k3][arrAllMoney[t1,1]])+Convert.ToDouble(dtGovData.Rows[i1]["TOLFEE_MNY"]);
												break;
											}
											//如果不存在插入一项数据
											if(k3==dtStat.Rows.Count-1)
											{
												DataRow newRow=dtStat.NewRow();
												newRow["中药"]=0;
												newRow["中成药"]=0;
												newRow["西药"]=0;
												newRow["检查"]=0;
												newRow["治疗"]=0;
												newRow["诊金"]=0;
												newRow["公费号"]=strType;
												newRow["自付比例"]=dtGovData.Rows[i1]["CHARGEPERCENT_DEC"].ToString().Trim();
												newRow[arrAllMoney[t1,1]]=dtGovData.Rows[i1]["TOLFEE_MNY"];
												dtStat.Rows.Add(newRow);
												break;
											}
										}
									}
										//如果统计表中没有任何的数据插入一项数据
									else
									{
										DataRow newRow=dtStat.NewRow();
										newRow["中药"]=0;
										newRow["中成药"]=0;
										newRow["西药"]=0;
										newRow["检查"]=0;
										newRow["治疗"]=0;
										newRow["诊金"]=0;
										newRow["公费号"]=strType;
										newRow["自付比例"]=dtGovData.Rows[i1]["CHARGEPERCENT_DEC"].ToString().Trim();
										newRow[arrAllMoney[t1,1]]=dtGovData.Rows[i1]["TOLFEE_MNY"];
										dtStat.Rows.Add(newRow);
									}

								}
							}
						}
					}
				}
			}

			#endregion
		}
		#endregion


		#region 打印报表
		public void m_printRePort(System.Drawing.Printing.PrintPageEventArgs e)
		{
			float X=30.0F;//定义横向开始的坐标
			float Y=30.0F;//定义纵向开始的坐标
			System.Drawing.Font tilFont=new Font("宋体",16,System.Drawing.FontStyle.Bold);//标题的字体
			System.Drawing.Font  textFont=new Font("宋体",10);//文本的字体
			Pen penLine=new Pen(Brushes.Black,1);//定义画笔
			float pageWith=e.PageBounds.Width;//获取页面的宽度
			float RowHigth=23;
			float RowWith=62;
			#region 表头
			SizeF tilwith=e.Graphics.MeasureString("公费统计报表",tilFont);
			e.Graphics.DrawString("公费统计报表",tilFont,Brushes.Black,pageWith/2-tilwith.Width/2,Y);
			Y+=RowHigth+5;
			e.Graphics.DrawLine(penLine,X,Y,pageWith-X,Y);
			X+=RowWith-20;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
			e.Graphics.DrawString("中药",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

			e.Graphics.DrawString("中成药",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
			e.Graphics.DrawString(" ",textFont,Brushes.Black,X,Y+7);



			e.Graphics.DrawString("合计",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);


			e.Graphics.DrawString("西药",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);


			e.Graphics.DrawString("检查",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);


			e.Graphics.DrawString("治疗",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);


			e.Graphics.DrawString("诊金",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
			

			e.Graphics.DrawString("合计",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);


			e.Graphics.DrawString("自付比例",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

			e.Graphics.DrawString("实报",textFont,Brushes.Black,X+3,Y+7);
			X+=RowWith+20;
			e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);


			e.Graphics.DrawString("所属类别",textFont,Brushes.Black,X+3,Y+7);
			X=30.0F;
			Y+=RowHigth;
			e.Graphics.DrawLine(penLine,X,Y,pageWith-X,Y);
			#endregion
			DataView myDataView= dtStat.DefaultView;
			myDataView.Sort="公费号 ASC";
			#region 画表格
			if(myDataView.Count>0)
			{
				for(int i1=0;i1<myDataView.Count;i1++)
				{
//					if(i1+1==myDataView.Count)
//					{
						e.Graphics.DrawString(myDataView.Table.Rows[i1]["公费号"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith-20;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
						e.Graphics.DrawString(myDataView.Table.Rows[i1]["中药"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

						e.Graphics.DrawString(myDataView.Table.Rows[i1]["中成药"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
						//中药费合计
						double tolMoneyCh=Convert.ToDouble(myDataView.Table.Rows[i1]["中成药"].ToString())+Convert.ToDouble(myDataView.Table.Rows[i1]["中药"].ToString());
						e.Graphics.DrawString(tolMoneyCh.ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

						e.Graphics.DrawString(myDataView.Table.Rows[i1]["西药"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

						e.Graphics.DrawString(myDataView.Table.Rows[i1]["检查"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

						e.Graphics.DrawString(myDataView.Table.Rows[i1]["治疗"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

						e.Graphics.DrawString(myDataView.Table.Rows[i1]["诊金"].ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
						//全部金额合计
						double tolAllMoney=tolMoneyCh+Convert.ToDouble(myDataView.Table.Rows[i1]["西药"].ToString())+Convert.ToDouble(myDataView.Table.Rows[i1]["检查"].ToString())+Convert.ToDouble(myDataView.Table.Rows[i1]["治疗"].ToString())+Convert.ToDouble(myDataView.Table.Rows[i1]["诊金"].ToString());
						e.Graphics.DrawString(tolAllMoney.ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);

						e.Graphics.DrawString(myDataView.Table.Rows[i1]["自付比例"].ToString()+"%",textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
						//实报金额

						double isTrueMoney=tolAllMoney*(1-Convert.ToDouble(myDataView.Table.Rows[i1]["自付比例"].ToString())/100);
						e.Graphics.DrawString(isTrueMoney.ToString(),textFont,Brushes.Black,X+3,Y+7);
						X+=RowWith+20;
						e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth);
						string strType="";
						for(int f2=0;f2<arrType.Length/2;f2++)
						{
							if(arrType[f2,0]==myDataView.Table.Rows[i1]["公费号"].ToString())
							{
								strType=arrType[f2,1];
								break;
							}

						}
					e.Graphics.DrawString(strType,textFont,Brushes.Black,X+3,Y+7);
					 X=30.0F;
					e.Graphics.DrawLine(penLine,X,Y+RowHigth,pageWith-X,Y+RowHigth);
					Y+=RowHigth;
						//										X=30.0F;

//					}
//					else
//					{
//
//					}


				}
				X=30.0F;
				Y=30.0F;
				Y+=RowHigth+5;
				e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth*(myDataView.Count+1));
				e.Graphics.DrawLine(penLine,pageWith-X,Y,pageWith-X,Y+RowHigth*(myDataView.Count+1));
				
			}
			else
			{
				X=30.0F;
				Y=30.0F;
				Y+=RowHigth+5;
				e.Graphics.DrawLine(penLine,X,Y,X,Y+RowHigth*2);
				e.Graphics.DrawLine(penLine,pageWith-X,Y,pageWith-X,Y+RowHigth*2);
				e.Graphics.DrawLine(penLine,X,Y+RowHigth*2,pageWith-X,Y+RowHigth*2);
			}


			#endregion


		}
		#endregion


	}
}
