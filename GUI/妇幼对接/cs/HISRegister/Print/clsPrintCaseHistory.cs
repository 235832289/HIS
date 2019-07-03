using System;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsPrintCaseHistory 的摘要说明。
	/// </summary>
	public class clsPrintCaseHistory
	{		
		private System.Collections.ArrayList objSign =new System.Collections.ArrayList();
		/// <summary>
		/// 画图对象
		/// </summary>
		private System.Drawing.Printing.PrintPageEventArgs objDraw;
		private clsOutpatientPrintCaseHis_VO obj_VO;
		/// <summary>
		/// 标题字体
		/// </summary>
		Font objFontTitle;
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
		private  float  fltRowHeight;
		/// <summary>
		/// 纵坐标
		/// </summary>
		private float  Y;
		public clsPrintCaseHistory(clsOutpatientPrintCaseHis_VO VO)
		{
			objFontTitle=new Font("SimSun",16,FontStyle.Bold);
			objFontNormal=new Font("SimSun",10);
			obj_VO=VO;
			this.m_mthInit();
			this.objDoct.m_mthRelationInfo(out dt_RelationInfo);
		}
		private string strDiagMain ="主    诉:";
		private string strDiagCurr ="现 病 史:";
		private string strTitleEx ="";
		private void m_mthInit()
		{
			if(this.obj_VO.strParentID.Trim()!="")
			{
				strDiagMain ="复诊时间:";
				strDiagCurr ="病情变化:";
				strTitleEx="(复诊)";
			}
			objSign.Add(",");
			objSign.Add("，");
			objSign.Add("。");
			objSign.Add("、");
			objSign.Add(".");			
		}

		private	clsDcl_DoctorWorkstation objDoct = new clsDcl_DoctorWorkstation();
		private System.Data.DataTable dt_RelationInfo = null;
		private string m_mthRelationInfo(string strCatID)
		{
			string str="0005";//默认其他
			for(int i=0;i<this.dt_RelationInfo.Rows.Count;i++)
			{
				if(strCatID==this.dt_RelationInfo.Rows[i]["CATID_CHR"].ToString().Trim())
				{
					str=this.dt_RelationInfo.Rows[i]["GROUPID_CHR"].ToString().Trim();
					break;
				}
			}
			return str;
		}

		#region 打印标题
//		private void m_mth
		private void m_mthPrintTitle()
		{
			//标题
			SizeF objFontSize =objDraw.Graphics.MeasureString(obj_VO.m_strHospitalName+"门诊病历信息"+strTitleEx,this.objFontTitle);
			float X=(this.objDraw.PageBounds.Width-objFontSize.Width)/2;
			Y=this.objDraw.PageBounds.Height*0.05f-(objFontSize.Height/2);
			objDraw.Graphics.DrawString(obj_VO.m_strHospitalName+"门诊病历信息"+strTitleEx,objFontTitle,Brushes.Black,X,Y);
//			//页面
//			Y+=objFontSize.Height/2-5;
//			objFontSize =objDraw.Graphics.MeasureString("第1页/共1页",this.objFontNormal);
//			fltRowHeight=objFontSize.Height;
//			X=this.objDraw.PageBounds.Width*(1-fltRightIndentProp)-objFontSize.Width;
//			objDraw.Graphics.DrawString("第1页/共1页",objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=objFontSize.Height;
			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,X+objFontSize.Width,Y);
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
//			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
			//就诊卡号
			Y+=this.fltRowHeight/2+5;
			objFontSize =objDraw.Graphics.MeasureString("就诊卡号:",this.objFontNormal);
			objDraw.Graphics.DrawString("就诊卡号:",objFontNormal,Brushes.Black,X,Y);
			fltRowHeight=objFontSize.Height;
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strCardID,objFontNormal,Brushes.Black,X,Y);
			//流水号
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("流水号:",this.objFontNormal);
			objDraw.Graphics.DrawString("流水号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width-2;
			objDraw.Graphics.DrawString(obj_VO.m_strRegisterID,objFontNormal,Brushes.Black,X,Y);
			//处方ID
			X=this.objDraw.PageBounds.Width*0.60f;
			objFontSize =objDraw.Graphics.MeasureString("病历编号:",this.objFontNormal);
			objDraw.Graphics.DrawString("病历编号:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width;
			objDraw.Graphics.DrawString(obj_VO.m_strRecipeID,objFontNormal,Brushes.Black,X,Y);
			//姓名
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			Y+=this.fltRowHeight;
			objFontSize =objDraw.Graphics.MeasureString("姓    名:",this.objFontNormal);
			objDraw.Graphics.DrawString("姓    名:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strPatientName,objFontNormal,Brushes.Black,X,Y);
			//性别
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("性  别:",this.objFontNormal);
			objDraw.Graphics.DrawString("性  别:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width-2;
			objDraw.Graphics.DrawString(obj_VO.m_strSex,objFontNormal,Brushes.Black,X,Y);
			//处方ID
			X=this.objDraw.PageBounds.Width*0.60f;
			objFontSize =objDraw.Graphics.MeasureString("年    龄:",this.objFontNormal);
			objDraw.Graphics.DrawString("年    龄:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strAge,objFontNormal,Brushes.Black,X,Y);
			//就诊科室
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			Y+=this.fltRowHeight;
			objFontSize =objDraw.Graphics.MeasureString("就诊科室:",this.objFontNormal);
			objDraw.Graphics.DrawString("就诊科室:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strDiagDeptID,objFontNormal,Brushes.Black,X,Y);
			//诊疗医生
			X=this.objDraw.PageBounds.Width*0.34f;
			objFontSize =objDraw.Graphics.MeasureString("医生:",this.objFontNormal);
			objDraw.Graphics.DrawString("医生:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strDiagDrName,objFontNormal,Brushes.Black,X,Y);
			//就诊时间
			X=this.objDraw.PageBounds.Width*0.60f;
			objFontSize =objDraw.Graphics.MeasureString("就诊时间:",this.objFontNormal);
			objDraw.Graphics.DrawString("就诊时间:",objFontNormal,Brushes.Black,X,Y);
			X+=objFontSize.Width+2;
			objDraw.Graphics.DrawString(obj_VO.m_strPrintDate,objFontNormal,Brushes.Black,X,Y);
			//画线
			Y+=this.fltRowHeight;
			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
			Y+=this.fltRowHeight/2;
					
		}
		#endregion
		#region 打印内容
		/// <summary>
		/// 打到那一个位置
		/// </summary>
		private int location =0;
		private float MaxLength =0;
		private int subRow =0;
		/// <summary>
		/// 获取每行打印的长度
		/// </summary>
		/// <param name="length"></param>
		private void m_mthGetMaxLength()
		{
//			if(MaxLength>0)
//			{
//				return;
//			}
//			SizeF objFontSize =objDraw.Graphics.MeasureString("字",this.objFontNormal);
//			double temp  =(double)(length/objFontSize.Width);
//			MaxLength =(int)Math.Floor(temp);
			MaxLength =this.objDraw.PageBounds.Width*(1-fltRightIndentProp-this.fltLeftIndentProp)+10;
		}
//		private bool m_mthDrawString(string strText,float X)
//		{
//			bool ret =false;
//			string[] strArr =strText.Split('\n');
//			strText ="";
//
//			for(int i=0;i<strArr.Length-1;i++)
//			{
//			strText+=strArr[i].PadRight(MaxLength,' ');
//			}
//			strText+=strArr[strArr.Length-1];
//			if(MaxLength*(subRow+1)<=strText.Length)
//			{
//				objDraw.Graphics.DrawString(strText.Substring(MaxLength*subRow,MaxLength),objFontNormal,Brushes.Black,X,Y);
//				Y+=this.fltRowHeight;
//				subRow++;
//				if(this.Y+this.fltRowHeight+20>this.objDraw.PageBounds.Height)
//				{
//					objDraw.HasMorePages =true;
//					return true;
//				}
//				m_mthDrawString(strText,X);
//			}
//			else
//			{
//				objDraw.Graphics.DrawString(strText.Substring(MaxLength*subRow,strText.Length-MaxLength*subRow),objFontNormal,Brushes.Black,X,Y);
//				Y+=this.fltRowHeight;
//				this.location++;
//				subRow=0;
//			}
//			if(this.Y+this.fltRowHeight+20>this.objDraw.PageBounds.Height)
//			{
//				objDraw.HasMorePages =true;
//				ret = true;
//			}
//			return ret;
//		}
		private bool m_mthDrawString(string strText,float X)
		{
			bool ret =false;
			if(strText==null)
			{
				strText ="";
			}
			string[] strArr =strText.Split('\n');
			float tempX =X;
			SizeF size;
			for(int i=subRow;i<strArr.Length;i++)
			{
				size =objDraw.Graphics.MeasureString(strArr[i],this.objFontNormal);
				tempX =X;
				if(size.Width>this.MaxLength)
				{
					for(int i2=0;i2<strArr[i].Length;i2++)
					{
						size =objDraw.Graphics.MeasureString(strArr[i][i2].ToString().Trim(),this.objFontNormal);
						objDraw.Graphics.DrawString(strArr[i][i2].ToString().Trim(),objFontNormal,Brushes.Black,tempX,Y);
						if(size.Width>2.1f)
						{
							tempX+=size.Width-2.2f;
						}
						if(i2<strArr[i].Length-1)
						{
							if(tempX>=this.MaxLength&&objSign.IndexOf(strArr[i][i2+1].ToString().Trim())==-1)
							{
								Y+=this.fltRowHeight;
								tempX =X;
							}
						}
					}
				}
				else
				{
					objDraw.Graphics.DrawString(strArr[i],objFontNormal,Brushes.Black,X,Y);
					
				}
				Y+=this.fltRowHeight;
				subRow++;
				if(this.Y+this.fltRowHeight+20>this.objDraw.PageBounds.Height)
				{
					objDraw.HasMorePages =true;
					return true;
				}
				
			}
			this.location++;
			subRow=0;
			
			return ret;
		}
		private void m_mthPrintText()
		{
			SizeF objFontSize =objDraw.Graphics.MeasureString(this.strDiagMain,this.objFontNormal);
//			float fltRFTemp =this.objDraw.PageBounds.Width*(1-fltLeftIndentProp)-objFontSize.Width-2;
		
			float X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);			
			int ipos = 0;		

			while(location<14)
			{
				switch(location)
				{
					case 0:
						if(subRow==0)
						objDraw.Graphics.DrawString(this.strDiagMain,objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
						if(m_mthDrawString(obj_VO.strDiagMain,X))
						{
						return;
						}
//						RectangleF RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strDiagMain,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight;
//						location++;
						break;
					case 1://现 病 史
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						objFontSize =objDraw.Graphics.MeasureString(this.strDiagCurr,this.objFontNormal);
						if(subRow==0)
						objDraw.Graphics.DrawString(this.strDiagCurr,objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight*2);
//						objDraw.Graphics.DrawString(obj_VO.strDiagCurr,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight*2;
						if(m_mthDrawString(obj_VO.strDiagCurr,X))
						{
							return;
						}
						if(this.obj_VO.strParentID.Trim()!="")
						{
							location =5;
						}
						
						break;
					case 2:
						//既 病 史
						objFontSize =objDraw.Graphics.MeasureString("既 病 史:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("既 病 史:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strDiagHis,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight;
//						location++;
						if(m_mthDrawString(obj_VO.strDiagHis,X))
						{
							return;
						}
						break;
					case 3:
						//过敏史
						objFontSize =objDraw.Graphics.MeasureString("过 敏 史:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("过 敏 史:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strAnaPhyLaXis,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight;
//						location++;
						if(m_mthDrawString(obj_VO.strAnaPhyLaXis,X))
						{
							return;
						}
						break;
					case 4:
						//个人史
						objFontSize =objDraw.Graphics.MeasureString("个 人 史:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("个 人 史:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						objDraw.Graphics.DrawString(obj_VO.m_strPRIHIS_VCHR,objFontNormal,Brushes.Black,X,Y);
//						Y+=this.fltRowHeight;
//						location++;
						if(m_mthDrawString(obj_VO.m_strPRIHIS_VCHR,X))
						{
							return;
						}
						break;
					case 5:
						//体格检查
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						//			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp)-X;
						objFontSize =objDraw.Graphics.MeasureString("体格检查:",this.objFontNormal);
						if(subRow==0)
						objDraw.Graphics.DrawString("体格检查:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight*2);
//						objDraw.Graphics.DrawString(obj_VO.strExamineResult,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight*2;
//						location++;
						if(m_mthDrawString(obj_VO.strExamineResult,X))
						{
							return;
						}
						break;
					case 6:
						//转科情况
						objFontSize =objDraw.Graphics.MeasureString("转科情况:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("专科情况:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strChangeDeparement,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight;
//						location++;
						if(m_mthDrawString(obj_VO.strChangeDeparement,X))
						{
							return;
						}
						break;
					case 7:
						//辅助检查
						objFontSize =objDraw.Graphics.MeasureString("辅助检查:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("辅助检查:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strAidCheck,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight;
//						location++;
						if(m_mthDrawString(obj_VO.strAidCheck,X))
						{
							return;
						}
						break;
					case 8:
						//处方2
						#region 排序
						ipos = subRow;
						for(int i=subRow;i<obj_VO.objItemArr2.Count;i++)
						{							
							clsOutpatientPrintRecipeDetail_VO objTemp = obj_VO.objItemArr2[i] as clsOutpatientPrintRecipeDetail_VO;
							if(objTemp == null)
							{
								if(i > ipos)
								{
                                    if (i - ipos <= obj_VO.objItemArr.Count)
                                    {
                                        obj_VO.objItemArr.Sort(ipos, i - ipos, null);
                                    }
                                    
									ipos = i + 1;																		
								}
								continue; 
							}
							switch(this.m_mthRelationInfo(objTemp.m_strInvoiceCat))
							{
								case "0001":
									objTemp.m_strRowNo = "1" + objTemp.m_strRowNo;
									break;
								case "0002":
									objTemp.m_strRowNo = "2" + objTemp.m_strRowNo;
									break;
								case "0003":
									objTemp.m_strRowNo = "3" + objTemp.m_strRowNo;
									break;
								case "0004":
									objTemp.m_strRowNo = "4" + objTemp.m_strRowNo;
									break;
								case "0005":
									objTemp.m_strRowNo = "6" + objTemp.m_strRowNo;
									break;
								case "0006":
									objTemp.m_strRowNo = "5" + objTemp.m_strRowNo;
									break;
								default:
									objTemp.m_strRowNo = "6" + objTemp.m_strRowNo;
									break;
							}
						}						
						obj_VO.objItemArr2.Sort(ipos,obj_VO.objItemArr2.Count-ipos,null);
						
						#endregion

						for(int i=subRow;i<obj_VO.objItemArr2.Count;i++)
						{
							clsOutpatientPrintRecipeDetail_VO objtemp =obj_VO.objItemArr2[i] as clsOutpatientPrintRecipeDetail_VO;
							
							X=this.objDraw.PageBounds.Width*fltLeftIndentProp+objFontSize.Width+2;
							if(objtemp==null)
							{
								using(Pen pen =new Pen(Color.Black,1))
								{
									pen.DashStyle =System.Drawing.Drawing2D.DashStyle.Dot;
									objDraw.Graphics.DrawLine(pen,X,Y,RX,Y);
								}
							}
							else
							{								
								//名称
								objDraw.Graphics.DrawString(objtemp.m_strChargeName,objFontNormal,Brushes.Black,X,Y);
								//规格
								X=this.objDraw.PageBounds.Width*0.33f+objFontSize.Width+2;
								objDraw.Graphics.DrawString(objtemp.m_strSpec,objFontNormal,Brushes.Black,X,Y);
								//总量
								X=this.objDraw.PageBounds.Width*0.52f+objFontSize.Width+2;
								objDraw.Graphics.DrawString(objtemp.m_strCount,objFontNormal,Brushes.Black,X,Y);
								//频率 
								X=this.objDraw.PageBounds.Width*0.58f+objFontSize.Width+2;
								objDraw.Graphics.DrawString(m_mthStringOperator(objtemp),objFontNormal,Brushes.Black,X,Y);
								//								//频率 
//								X=this.objDraw.PageBounds.Width*0.7f+objFontSize.Width+2;
//								objDraw.Graphics.DrawString(objtemp.m_strUsage,objFontNormal,Brushes.Black,X,Y);
//								//天数
//								X=this.objDraw.PageBounds.Width*0.65f+objFontSize.Width+2;
//								objDraw.Graphics.DrawString(objtemp.m_strDays,objFontNormal,Brushes.Black,X,Y);
//								//频率
//								X=this.objDraw.PageBounds.Width*0.75f+objFontSize.Width+2;
//								objDraw.Graphics.DrawString(objtemp.m_strFrequency,objFontNormal,Brushes.Black,X,Y);
							}
							Y+=this.fltRowHeight+3;	
							if(this.Y+this.fltRowHeight+20>this.objDraw.PageBounds.Height)
							{
								objDraw.HasMorePages =true;
								return;
							}
							subRow++;
						}
						subRow=0;
						location++;
						break;
					case 9:
						//诊    断
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						//			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp)-X;
						objFontSize =objDraw.Graphics.MeasureString("诊    断:",this.objFontNormal);
						if(subRow==0)
						objDraw.Graphics.DrawString("诊    断:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight*2);
//						objDraw.Graphics.DrawString(obj_VO.strDiag,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight*2;
//						location++;
						if(m_mthDrawString(obj_VO.strDiag,X))
						{
							return;
						}
						break;
					case 10:
						//处    置
						objFontSize =objDraw.Graphics.MeasureString("处    置:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("处    置:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strTreatMent,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight;
//						location++;
						if(m_mthDrawString(obj_VO.strTreatMent,X))
						{
							return;
						}
						break;
					case 11:						
						#region 排序
						ipos = subRow;						
						for(int i=subRow;i<obj_VO.objItemArr.Count;i++)
						{							
							clsOutpatientPrintRecipeDetail_VO objTemp = obj_VO.objItemArr[i] as clsOutpatientPrintRecipeDetail_VO;
							if(objTemp == null)
							{
								if(i > ipos)
								{
									obj_VO.objItemArr.Sort(ipos, i-ipos, null);
									ipos = i + 1;																		
								}
								continue; 
							}
							switch(this.m_mthRelationInfo(objTemp.m_strInvoiceCat))
							{
								case "0001":
									objTemp.m_strRowNo = "1" + objTemp.m_strRowNo;
									break;
								case "0002":
									objTemp.m_strRowNo = "2" + objTemp.m_strRowNo;
									break;
								case "0003":
									objTemp.m_strRowNo = "3" + objTemp.m_strRowNo;
									break;
								case "0004":
									objTemp.m_strRowNo = "4" + objTemp.m_strRowNo;
									break;
								case "0005":
									objTemp.m_strRowNo = "6" + objTemp.m_strRowNo;
									break;
								case "0006":
									objTemp.m_strRowNo = "5" + objTemp.m_strRowNo;
									break;
								default:
									objTemp.m_strRowNo = "6" + objTemp.m_strRowNo;
									break;
							}
						}	
						obj_VO.objItemArr.Sort(ipos, obj_VO.objItemArr.Count-ipos, null);
						
						#endregion

						for(int i=subRow;i<obj_VO.objItemArr.Count;i++)
						{
							clsOutpatientPrintRecipeDetail_VO objtemp =obj_VO.objItemArr[i] as clsOutpatientPrintRecipeDetail_VO;
							X=this.objDraw.PageBounds.Width*fltLeftIndentProp+objFontSize.Width+2;
							if(objtemp==null)
							{
								using(Pen pen =new Pen(Color.Black,1))
								{
									pen.DashStyle =System.Drawing.Drawing2D.DashStyle.Dot;
									objDraw.Graphics.DrawLine(pen,X,Y,RX,Y);
								}
							}
							else
							{
                                if (objtemp.m_strInvoiceCat.IndexOf("材料") >= 0)
                                {
                                    continue;
                                }

								//方号								
								if(objtemp.m_strRowNo.StartsWith("1") && int.Parse(objtemp.m_strRowNo.Substring(1,objtemp.m_strRowNo.Length-1)) > 0)
								{
									objDraw.Graphics.DrawString(objtemp.m_strRowNo.Substring(1,objtemp.m_strRowNo.Length-1),objFontNormal,Brushes.Black,X,Y);
								}
								//名称
								X=this.objDraw.PageBounds.Width*0.1f+objFontSize.Width+2;
								objDraw.Graphics.DrawString(objtemp.m_strChargeName,objFontNormal,Brushes.Black,X,Y);
								//规格
								X=this.objDraw.PageBounds.Width*0.33f+objFontSize.Width+2;
								objDraw.Graphics.DrawString(objtemp.m_strSpec,objFontNormal,Brushes.Black,X,Y);
								//总量
								X=this.objDraw.PageBounds.Width*0.52f+objFontSize.Width+2;
								objDraw.Graphics.DrawString(objtemp.m_strCount,objFontNormal,Brushes.Black,X,Y);
								//频率 
								X=this.objDraw.PageBounds.Width*0.58f+objFontSize.Width+2;
//								objDraw.Graphics.DrawString(m_mthStringOperator(objtemp),objFontNormal,Brushes.Black,X,Y);
								objDraw.Graphics.DrawString(objtemp.m_strDosage+"/次,"+objtemp.m_strUsage+","+objtemp.m_strFrequency+"*"+objtemp.m_strDays,objFontNormal,Brushes.Black,X,Y);

//								//天数
//								X=this.objDraw.PageBounds.Width*0.65f+objFontSize.Width+2;
//								objDraw.Graphics.DrawString(objtemp.m_strDays,objFontNormal,Brushes.Black,X,Y);
//								//频率
//								X=this.objDraw.PageBounds.Width*0.75f+objFontSize.Width+2;
//								objDraw.Graphics.DrawString(objtemp.m_strFrequency,objFontNormal,Brushes.Black,X,Y);
							}
							Y+=this.fltRowHeight+3;	
							subRow++;
							if(this.Y+this.fltRowHeight+20>this.objDraw.PageBounds.Height)
							{
								objDraw.HasMorePages =true;
								return;
							}
			
						}
						subRow=0;
						location++;
						break;
					case 12:
						//备注
						objFontSize =objDraw.Graphics.MeasureString("备    注:",this.objFontNormal);
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						if(subRow==0)
						objDraw.Graphics.DrawString("备    注:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+2;
//						RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//						objDraw.Graphics.DrawString(obj_VO.strReMark,objFontNormal,Brushes.Black,RF);
//						Y+=this.fltRowHeight+10;
//						location++;
						if(m_mthDrawString(obj_VO.strReMark,X))
						{
							return;
						}
						break;
					case 13:
						//画线
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
						Pen objPen=new Pen(Color.Black,1);
						//			objPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
						objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
						Y+=this.fltRowHeight/2;
						//打印时间
						objDraw.Graphics.DrawString("打印时间:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm"),objFontNormal,Brushes.Black,X,Y);
						//医生签名
						X=this.objDraw.PageBounds.Width*0.65f;
						objFontSize =objDraw.Graphics.MeasureString("医生签名:",objFontNormal);
						objDraw.Graphics.DrawString("医生签名:",objFontNormal,Brushes.Black,X,Y);
						X+=objFontSize.Width+5;	
						if(this.obj_VO.objDocImage!=null)
						{
							RectangleF RF=new RectangleF(X,Y-5,100,60);
							objDraw.Graphics.DrawImage(this.obj_VO.objDocImage,RF);
						}
						else
						{
							objDraw.Graphics.DrawString(obj_VO.m_strDiagDrName,objFontNormal,Brushes.Black,X,Y);
						}
						Y+=this.fltRowHeight*1.5f;
						X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//						objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
						location++;
						break;

				}
			}
			

		
//			//现 病 史
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
//			objFontSize =objDraw.Graphics.MeasureString(this.strDiagCurr,this.objFontNormal);
//			
//			objDraw.Graphics.DrawString(this.strDiagCurr,objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight*2);
//			objDraw.Graphics.DrawString(obj_VO.strDiagCurr,objFontNormal,Brushes.Black,RF);
//			Y+=this.fltRowHeight*2;
//			if(this.obj_VO.strParentID.Trim()=="")
//			{
//		
//				//既 病 史
//				objFontSize =objDraw.Graphics.MeasureString("既 病 史:",this.objFontNormal);
//				X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//				objDraw.Graphics.DrawString("既 病 史:",objFontNormal,Brushes.Black,X,Y);
//				X+=objFontSize.Width+2;
//				RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//				objDraw.Graphics.DrawString(obj_VO.strDiagHis,objFontNormal,Brushes.Black,RF);
//				Y+=this.fltRowHeight;
//				//过敏史
//				objFontSize =objDraw.Graphics.MeasureString("过 敏 史:",this.objFontNormal);
//				X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//				objDraw.Graphics.DrawString("过 敏 史:",objFontNormal,Brushes.Black,X,Y);
//				X+=objFontSize.Width+2;
//				RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//				objDraw.Graphics.DrawString(obj_VO.strAnaPhyLaXis,objFontNormal,Brushes.Black,RF);
//				Y+=this.fltRowHeight;
//				//个人史
//				objFontSize =objDraw.Graphics.MeasureString("个 人 史:",this.objFontNormal);
//				X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//				objDraw.Graphics.DrawString("个 人 史:",objFontNormal,Brushes.Black,X,Y);
//				X+=objFontSize.Width+2;
//				objDraw.Graphics.DrawString(obj_VO.m_strPRIHIS_VCHR,objFontNormal,Brushes.Black,X,Y);
//				Y+=this.fltRowHeight;
//			}
//			//体格检查
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
////			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp)-X;
//			objFontSize =objDraw.Graphics.MeasureString("体格检查:",this.objFontNormal);
//			objDraw.Graphics.DrawString("体格检查:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight*2);
//			objDraw.Graphics.DrawString(obj_VO.strExamineResult,objFontNormal,Brushes.Black,RF);
//			Y+=this.fltRowHeight*2;
//			//辅助检查
//			objFontSize =objDraw.Graphics.MeasureString("辅助检查:",this.objFontNormal);
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			objDraw.Graphics.DrawString("辅助检查:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//			objDraw.Graphics.DrawString(obj_VO.strAidCheck,objFontNormal,Brushes.Black,RF);
//			Y+=this.fltRowHeight;
//			//诊    断
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
////			RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp)-X;
//			objFontSize =objDraw.Graphics.MeasureString("诊    断:",this.objFontNormal);
//			objDraw.Graphics.DrawString("诊    断:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight*2);
//			objDraw.Graphics.DrawString(obj_VO.strDiag,objFontNormal,Brushes.Black,RF);
//			Y+=this.fltRowHeight*2;
//			//处    置
//			objFontSize =objDraw.Graphics.MeasureString("处    理:",this.objFontNormal);
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			objDraw.Graphics.DrawString("处    理:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//			objDraw.Graphics.DrawString(obj_VO.strTreatMent,objFontNormal,Brushes.Black,RF);
//			Y+=this.fltRowHeight;
//			
//			for(int i=0;i<obj_VO.objItemArr.Count;i++)
//			{
//				clsOutpatientPrintRecipeDetail_VO objtemp =obj_VO.objItemArr[i] as clsOutpatientPrintRecipeDetail_VO;
//				X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			
//				//名称
//				objDraw.Graphics.DrawString(objtemp.m_strChargeName,objFontNormal,Brushes.Black,X,Y);
//				//总量
//				X=this.objDraw.PageBounds.Width*0.4f;
//				objDraw.Graphics.DrawString(objtemp.m_strCount,objFontNormal,Brushes.Black,X,Y);
//				//频率 
//				X=this.objDraw.PageBounds.Width*0.5f;
//				objDraw.Graphics.DrawString(objtemp.m_strUsage,objFontNormal,Brushes.Black,X,Y);
//				//天数
//				X=this.objDraw.PageBounds.Width*0.65f;
//				objDraw.Graphics.DrawString(objtemp.m_strDays,objFontNormal,Brushes.Black,X,Y);
//				//频率
//				X=this.objDraw.PageBounds.Width*0.75f;
//				objDraw.Graphics.DrawString(objtemp.m_strFrequency,objFontNormal,Brushes.Black,X,Y);
//				Y+=this.fltRowHeight+3;	
//			
//			}
//
//			//备注
//			objFontSize =objDraw.Graphics.MeasureString("备    注:",this.objFontNormal);
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			objDraw.Graphics.DrawString("备    注:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			RF=new RectangleF(X,Y,fltRFTemp,this.fltRowHeight);
//			objDraw.Graphics.DrawString(obj_VO.strReMark,objFontNormal,Brushes.Black,RF);
//			Y+=this.fltRowHeight+10;
//			//画线
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			Pen objPen=new Pen(Color.Black,2);
////			objPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
//			objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
//			Y+=this.fltRowHeight/2;
//			//打印时间
//			objDraw.Graphics.DrawString("打印时间:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm"),objFontNormal,Brushes.Black,X,Y);
//			//医生签名
//			X=this.objDraw.PageBounds.Width*0.65f;
//			objFontSize =objDraw.Graphics.MeasureString("医生签名:",objFontNormal);
//			objDraw.Graphics.DrawString("医生签名:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+5;	
//			if(this.obj_VO.objDocImage!=null)
//			{
//				RF=new RectangleF(X,Y-5,100,60);
//				objDraw.Graphics.DrawImage(this.obj_VO.objDocImage,RF);
//			}
//			else
//			{
//				objDraw.Graphics.DrawString(obj_VO.m_strDiagDrName,objFontNormal,Brushes.Black,X,Y);
//			}
//			Y+=this.fltRowHeight*1.5f;
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			objDraw.Graphics.DrawLine(objPen,X,Y,RX,Y);
		
		}
		private string m_mthStringOperator(clsOutpatientPrintRecipeDetail_VO objtemp)
		{
			string ret ="";
			if(objtemp.m_strUsage!="")
			{
				ret+=objtemp.m_strUsage+"/次";
			}
			if(objtemp.m_strFrequency!="")
			{
				if(ret.Trim()!="")
				{
				ret+=",";
				}
				ret+=objtemp.m_strFrequency;
			}
			if(objtemp.m_strDays!="")
			{
				if(ret.Trim()!="")
				{
					ret+=",";
				}
				ret+=objtemp.m_strDays;
			}
			return ret;
		}
		#endregion
		#region 打印页脚
		private void m_mthPrintEnd()
		{
//			//画线
//			Y=this.objDraw.PageBounds.Height*0.82f;
//			float X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			float RX=this.objDraw.PageBounds.Width*(1-fltRightIndentProp);
//			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
//			//盖章
//			Y+=this.fltRowHeight/2;
//			X=this.objDraw.PageBounds.Width*0.65f;
//			objDraw.Graphics.DrawString(obj_VO.m_strHospitalName+"(盖章)",objFontNormal,Brushes.Black,X,Y);
//			//画线
//			Y+=this.fltRowHeight;
//			X=this.objDraw.PageBounds.Width*fltLeftIndentProp;
//			objDraw.Graphics.DrawLine(new Pen(Color.Black,1),X,Y,RX,Y);
//			Y+=this.fltRowHeight/2;
//			SizeF objFontSize =objDraw.Graphics.MeasureString("打印次数:",this.objFontNormal);
//			objDraw.Graphics.DrawString("打印次数:",objFontNormal,Brushes.Black,X,Y);
//			objDraw.Graphics.DrawString("次",objFontNormal,Brushes.Black,X+objFontSize.Width+15,Y);
//			//操作员工号
//			X=this.objDraw.PageBounds.Width*0.35f;
//			objFontSize =objDraw.Graphics.MeasureString("打印员工号:",this.objFontNormal);
//			objDraw.Graphics.DrawString("打印员工号:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			objDraw.Graphics.DrawString(obj_VO.m_strRecordEmpID,objFontNormal,Brushes.Black,X,Y);
//			//打印时间
//			X=this.objDraw.PageBounds.Width*0.65f;
//			objFontSize =objDraw.Graphics.MeasureString("打印时间:",this.objFontNormal);
//			objDraw.Graphics.DrawString("打印时间:",objFontNormal,Brushes.Black,X,Y);
//			X+=objFontSize.Width+2;
//			objDraw.Graphics.DrawString(DateTime.Now.ToString("yyyy.MM.dd HH:mm"),objFontNormal,Brushes.Black,X,Y);
		}
		#endregion
		#region 开始打印
		public void m_mthBegionPrint(System.Drawing.Printing.PrintPageEventArgs p_obj)
		{
			objDraw=p_obj;
			this.m_mthGetMaxLength();
			if(location==0)
			{
				this.m_mthPrintTitle();
			}
			else
			{
				Y=10;
			}
			this.m_mthPrintText();
			this.m_mthPrintEnd();
		}
		#endregion
	}
}
