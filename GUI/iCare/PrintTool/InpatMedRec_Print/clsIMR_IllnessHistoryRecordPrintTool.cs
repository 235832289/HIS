using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;
using System.Resources ;
using RS = iCare.Properties;

namespace iCare
{
	/// <summary>
	/// 耳鼻喉科病历记录 打印 的摘要说明。
	/// </summary>
	public class clsIMR_IllnessHistoryRecordPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_IllnessHistoryRecordPrintTool(string p_strTypeID) :base(p_strTypeID)
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private clsPrintInPatMedRecItem[] m_objPrintOneItemArr;
		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		private clsPrintInPatMedRecSign[] m_objPrintSignArr;
		protected override void m_mthSetPrintLineArr()
		{
			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
																		   new clsPrintPatientFixInfo("耳鼻喉科病历记录",295),
																		   m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],m_objPrintOneItemArr[2],m_objPrintOneItemArr[3],
																		   m_objPrintOneItemArr[4],
																		   m_objPrintMultiItemArr[0],m_objPrintMultiItemArr[1],
                                                                           //new clsPrintSubInf(),new clsPrintSubInf1(),
                                                                           //new clsPrintSubInf2(),
																		   m_objPrintMultiItemArr[2],
																		   m_objPrintSignArr[0],
                                                                            m_objPrintOneItemArr[5], m_objPrintSignArr[1],  m_objPrintOneItemArr[6],  m_objPrintSignArr[2]
																	   });
		}

		private void m_mthInitPrintLineArr()
		{
			  m_objPrintOneItemArr = new clsPrintInPatMedRecItem[7];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[3];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();
 
			m_objPrintSignArr = new clsPrintInPatMedRecSign[3];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}
		
		protected override void m_mthSetSubPrintInfo()
		{
			#region 开头部分信息
//			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"日龄","日龄","入院日期","出生时间",
//																		 "父姓名","父工作单位","父职业","父电话",
//																		 "母姓名","母工作单位","母职业","母电话"},
//				new string[]{"日龄：","#天","入院日期：","出生时间：",
//								"\n父姓名：","工作单位：","职业：","联系电话：",
//								"\n母姓名：","工作单位：","职业：","联系电话："});
//

			#endregion

			#region 单个项目
			m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉","主诉：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史","现病史：");
			m_objPrintOneItemArr[2].m_mthSetPrintValue("既往史","既往史：");
			m_objPrintOneItemArr[3].m_mthSetPrintValue("个人史","个人史：");
			m_objPrintOneItemArr[4].m_mthSetPrintValue("家族史","家族史：");
			#endregion	

			#region 体格检查
			m_objPrintMultiItemArr[0].m_mthSetSpecialTitleValue("体 格 检 查");
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"","一般情况>>T","一般情况>>T",
																		 "一般情况>>P","一般情况>>P",
																		 "一般情况>>R","一般情况>>R",
																		 "一般情况>>BP","一般情况>>BP"},
				new string[]{"一般情况：","T：","#℃","P：","#次/分","R：","#次/分","BP：","#/"});

			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"一般情况>>BP>>mmHg","一般情况>>BP>>mmHg",
																		"一般情况>>身高>>cm","一般情况>>身高>>cm","一般情况>>体重>>g","一般情况>>体重>>g","皮肤粘膜","淋巴结",
																		 "头部及其器官","颈部",""},
				new string[]{"","#mmHg","身高：","#cm","体重：","#Kg","\n皮肤粘膜：","\n淋巴结：","\n头部及其器官：","\n颈部：","\n胸部："});
			
			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"胸部>>胸廓","胸部>>肺脏","胸部>>心脏"},
				new string[]{"\n         胸廓：","\n         肺脏：","\n         心脏："});

			m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[]{"血管","腹部",
																		 "外生殖器、肛门、会阴","脊柱四肢","神经系统","体格检查>>其它"},
				new string[]{"\n血管：","\n腹部：","\n外生殖器、肛门、会阴:","\n脊柱四肢:","\n神经系统:","\n其它:"});
			#endregion
		
			#region  专科检查
            m_objPrintMultiItemArr[1].m_mthSetSpecialTitleValue("专 科 检 查");
			m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[]{"专科检查>>外鼻","专科检查>>鼻粘摸","专科检查>>鼻中隔"},
				new string[]{"外鼻：","\n鼻粘摸：","\n鼻中隔："});
			
			#endregion

			#region  辅助检查
			m_objPrintMultiItemArr[2].m_mthSetSpecialTitleValue("辅 助 检 查");
			m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[]{"辅助检查","初步诊断"},
				new string[]{"\n辅助检查：","\n初步诊断："});
			
			#endregion

			#region 签名和日期
            m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[] { "主治医生", "主治医师签名日期" }, new string[] { "主治医师：", "签名日期：" });
			//m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"住院医师签名"},new string[]{"住院医师签名："});
			//			m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[]{"康复治疗计划>>医师","康复治疗计划>>时间"},new string[]{"医师：","日期："});
			#endregion

            #region 修正/补充诊断以及签名
            m_objPrintOneItemArr[5].m_mthSetPrintValue("修正诊断", "修正诊断：");
            m_objPrintOneItemArr[6].m_mthSetPrintValue("补充诊断", "补充诊断：");
            m_objPrintSignArr[1].m_mthSetPrintSignValue(new string[] { "修正诊断医师签名", "修正诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            m_objPrintSignArr[2].m_mthSetPrintSignValue(new string[] { "补充诊断医师签名", "补充诊断医师签名日期" }, new string[] { "医师签名：", "签名日期：" });
            #endregion
        }
		
		#region Print Class

		/// <summary>
		/// 项目打印
		/// </summary>
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));

			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
			private bool m_blnIsFirstPrint = true;
			private string m_strSpecialTitle = "";
			private string m_strTitle = "";
			private string m_strText = "";
			private string m_strTextXml = "";
			private bool m_blnNoContent = false;
			private bool m_blnNoPrint = true;
			private clsInpatMedRec_Item m_objItemContent = null;

			public clsPrintInPatMedRecItem()
			{}

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(m_blnNoContent == true && m_blnNoPrint == true)
				{
					m_blnHaveMoreLine = false;

					return;
				}

				if(m_blnIsFirstPrint)
				{
					if(m_strTitle != "")
					{
						p_objGrp.DrawString(m_strTitle,p_fntNormalText,Brushes.Black,m_intRecBaseX+10,p_intPosY);
						p_intPosY += 20;
                        //判断是否修正/补充诊断
                        if (m_strTitle == "修正诊断：" || m_strTitle == "补充诊断：")
                            m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, m_objItemContent != null,Color.Red);
                        else
						    m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent==null ? "" : m_objItemContent.m_strItemContent)  ,(m_objItemContent==null ? "<root />" : m_objItemContent.m_strItemContentXml),m_dtmFirstPrintTime,m_objItemContent != null);
						m_mthAddSign2(m_strTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_intPosY += 20;
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_HerbalismPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
							p_intPosY += 40;
						}
						m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText ,m_strTextXml,m_dtmFirstPrintTime,m_blnNoPrint == false);
						m_mthAddSign2(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
					}
					//(m_objPrintInfo.m_objContent.m_objPics[0]==1)
					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					if(m_strTitle != "")
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth,m_intRecBaseX+50,p_intPosY,p_objGrp);
					else
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2,m_intRecBaseX+10,p_intPosY,p_objGrp);
					p_intPosY += 20;

					intLine++;
				}			

				if(m_objPrintContext.m_BlnHaveNextLine())
					m_blnHaveMoreLine = true;
				else
				{
					m_blnHaveMoreLine = false;
				}
			}

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();

				m_blnHaveMoreLine = true;

				m_blnIsFirstPrint = true;
			}
			/// <summary>
			/// 设置多项打印内容
			/// </summary>
			/// <param name="p_strKeyArr">打印内容的哈希键数组</param>
			/// <param name="p_strTitleArr">小标题数组(即对应于窗体Lable但不存储于数据库的需打印的内容)</param>
			public void m_mthSetPrintValue(string[] p_strKeyArr,string[] p_strTitleArr)
			{
				if(p_strKeyArr == null || p_strTitleArr == null || p_strKeyArr.Length != p_strTitleArr.Length)
				{
					m_blnNoContent = true;
					return;
				}
				m_blnNoPrint = false;
				if(m_blnHavePrintInfo(p_strKeyArr) == true)
					m_mthMakeText(p_strTitleArr,p_strKeyArr,ref m_strText,ref m_strTextXml);
			}
			/// <summary>
			/// 设置单项打印内容
			/// </summary>
			/// <param name="p_strKey">哈希键</param>
			/// <param name="p_strTitle">小标题</param>
			public void m_mthSetPrintValue(string p_strKey,string p_strTitle)
			{
				if(m_hasItems != null && p_strKey != null)
					if(m_hasItems.Contains(p_strKey))
						m_objItemContent = m_hasItems[p_strKey] as clsInpatMedRec_Item;
				m_strTitle = p_strTitle;
			}
			/// <summary>
			/// 设置大标题如“体格检查”
			/// </summary>
			/// <param name="p_strTitle"></param>
			public void m_mthSetSpecialTitleValue(string p_strTitle)
			{
				m_strSpecialTitle = p_strTitle;
			}

		}

		/// <summary>
		/// 签名和日期
		/// </summary>
		private class clsPrintInPatMedRecSign : clsIMR_PrintLineBase
		{
			private clsInpatMedRec_Item[] objSignContent = null;
			private string[] m_strTitleArr = null;
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				if(objSignContent == null)
				{
					m_blnHaveMoreLine = false;
					return;
				}
				p_intPosY += 40;
				for(int i=0; i<objSignContent.Length; i++)
				{
					if(m_strTitleArr[i].IndexOf("日期") < 0)
					{
						p_objGrp.DrawString(m_strTitleArr[i]+(objSignContent[i]==null ? "" : objSignContent[i].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
					else
					{
						p_objGrp.DrawString(m_strTitleArr[i]+ (objSignContent[i] == null ? "" :DateTime.Parse( objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+500,p_intPosY);
						p_intPosY += 20;
					}
				}
				m_blnHaveMoreLine = false;
			}

			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
			}
			/// <summary>
			/// 设置签名和日期值
			/// </summary>
			/// <param name="p_strkeyArr">值</param>
			/// <param name="p_strTitleArr">标题</param>
			public void m_mthSetPrintSignValue(string[] p_strkeyArr,string[] p_strTitleArr)
			{
				if(p_strkeyArr == null || p_strTitleArr == null || p_strkeyArr.Length != p_strTitleArr.Length)
					return;
				objSignContent = m_objGetContentFromItemArr(p_strkeyArr);
				m_strTitleArr = p_strTitleArr;
			}

		}

		#endregion
        /*
		#region 图象--文字打印 画第一幅图
		/// <summary>
		/// 图象--文字打印
		/// </summary>
		private class clsPrintSubInf : clsIMR_PrintLineBase
		{
			#region Define
			private bool m_IsPrintLeftCol1=false;
			private bool m_IsPrintLeftCol2=false;
			private bool m_IsPrintLeftCol3=false;
			private bool m_IsPrintLeftCol4=false;
			private bool m_IsPrintLeftCol5=false;
			private bool m_IsPrintLeftCol6=false;
			private bool m_IsPrintRightCol1=false;
			private bool m_IsPrintRightCol2=false;
			private bool m_IsPrintRightCol3=false;
			private bool m_IsPrintRightCol4=false;
			private bool m_IsPrintRightCol5=false;
			private bool m_IsPrintRightCol6=false;
			private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black,new Font("",10));
			//			private string m_strTitle = "";
			//			private string[] m_strTitleArr = null;
		//	private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";

			#endregion

			public clsPrintSubInf()
			{}
			private void m_mthPrintDioa(ref bool flage,float leftX,float Width,ref float m_floatPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,string p_strText)
			{
				//new Rectangle(m_intRecBaseX+20,p_intPosY,620,20)

				RectangleF rtg = new RectangleF(leftX,m_floatPosY,Width,20);
				//RectangleF rtg = new RectangleF(m_intRecBaseX+15,m_floatPosY,285,20);
				string strText = p_strText;
				SizeF szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				if(m_floatPosY+szfText.Height+5>(int)enmRectangleInfo.BottomY-60)
				{
					flage=true;
					m_blnHaveMoreLine = true;
					return;
				}
				rtg.Y = m_floatPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				m_floatPosY += Convert.ToInt32(rtg.Height);
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				string p_strText="";
				 bool flage=false;
                float m_floatLPosY=(float)(p_intPosY);
				float m_floatRPosY=(float)p_intPosY;
				float RightX=0;
				int PosY=p_intPosY;
				m_floatRPosY+=3;
				
				int m_Lenth=clsPrintPosition.c_intRightX-clsPrintPosition.c_intLeftX;
                float m_leftLenth = 0;
                float m_RightLenth = 0;
                //float m_leftLenth=(m_Lenth-m_objPrintInfo.m_objContent.m_objPics[4].intWidth-52)/2;
                //float m_RightLenth=(m_Lenth-m_objPrintInfo.m_objContent.m_objPics[4].intWidth)/2;
				
				

                int PicWidth = 0;
                int PicHeight = 0;
                Image imgPrint = null;
                if (m_objPrintInfo.m_objContent.m_objPics !=null)
                {
                    for (int j1 = 0; j1 < m_objPrintInfo.m_objContent.m_objPics.Length; j1++)
                    {
                        if (m_objPrintInfo.m_objContent.m_objPics[j1].m_StrPictureBoxName == "m_picNose")
                        {
                            System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[j1].m_bytImage);
					        imgPrint = new Bitmap(objStream);
                            m_leftLenth = (m_Lenth - m_objPrintInfo.m_objContent.m_objPics[j1].intWidth - 52) / 2;
                            m_RightLenth = (m_Lenth - m_objPrintInfo.m_objContent.m_objPics[j1].intWidth) / 2;
                            PicWidth = m_objPrintInfo.m_objContent.m_objPics[j1].intWidth;
                            PicHeight = m_objPrintInfo.m_objContent.m_objPics[j1].intHeight;                          
                        }
                    }
                }
                if (imgPrint == null)
                {
                    imgPrint = RS::Resources.NasalVestibule;
                    m_leftLenth = (m_Lenth - RS::Resources.NasalVestibule.Width - 52) / 2;
                    m_RightLenth = (m_Lenth - RS::Resources.NasalVestibule.Width) / 2;
                    PicWidth = RS::Resources.NasalVestibule.Width;
                    PicHeight = RS::Resources.NasalVestibule.Height;			       
                }
                int m_Right = clsPrintPosition.c_intRightX - (int)m_RightLenth - 22;
                RightX = m_Right + 20;

                p_objGrp.DrawImage(imgPrint, m_leftLenth + 42, p_intPosY + 5, PicWidth, PicHeight);

                if (m_floatLPosY + PicHeight > (int)enmRectangleInfo.BottomY - 50)
                {
                    p_intPosY += 600;
                    return;
                }

				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightX ,m_floatLPosY);//画最上面的线
                m_floatLPosY+=3;
				p_objGrp.DrawString ("左",p_fntNormalText,Brushes.Black,(float)(m_intRecBaseX-7),m_floatLPosY+60);
				p_objGrp.DrawString ("右",p_fntNormalText,Brushes.Black,(float)(m_Right),m_floatRPosY+60);
				
				clsInpatMedRec_Item[] objItemContentArr = null;
				objItemContentArr = m_objGetContentFromItemArr(new string[]{"左>>鼻前庭","右>>鼻前庭","左>>中鼻甲","右>>中鼻甲",
                                                                              "左>>中鼻道","右>>中鼻道","左>>下鼻甲","右>>下鼻甲",
																			    "左>>下鼻道","右>>下鼻道","左>>嗅裂","右>>嗅裂"});
						
				if(objItemContentArr != null)
				{
					#region
					if(m_IsPrintLeftCol1==false)  //画第一行左边内容
					{
						if(objItemContentArr[0] != null)
						{
							p_strText=objItemContentArr[0].m_strItemContent;	
						}
						else
							p_strText="";
							m_mthPrintDioa(ref flage,m_intRecBaseX+15,m_leftLenth,ref m_floatLPosY, p_objGrp, p_fntNormalText, "鼻前庭:"+p_strText);
						if(flage==true)
						{
						
								p_intPosY+=1500;
								return;
						}
							m_IsPrintLeftCol1=true;
					}
					if(m_IsPrintRightCol1==false)  //画第一行右边内容
					{
						if(objItemContentArr[1] != null)
						{
							p_strText=objItemContentArr[1].m_strItemContent;		
						}
						else
                           p_strText="";
						m_mthPrintDioa(ref flage,m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "鼻前庭:"+p_strText);
						if(flage==true)
						{
							
							p_intPosY+=1500;
							return;
						}
						m_IsPrintRightCol1=true;
					}
					if(m_IsPrintLeftCol2==false)  //画第二行左边内容
					{
						if(objItemContentArr[2] != null)
						{
							p_strText=objItemContentArr[2].m_strItemContent;	
						}
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_intRecBaseX+15,m_leftLenth,ref m_floatLPosY, p_objGrp, p_fntNormalText, "中鼻甲:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatLPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,m_leftLenth+41,PosY,m_leftLenth+41,m_floatLPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintLeftCol2=true;
					}
					if(m_IsPrintRightCol2==false)  //画第二行右边内容
					{
						if(objItemContentArr[3] != null)
						p_strText=objItemContentArr[3].m_strItemContent;		
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "中鼻甲:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatRPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);

							p_intPosY+=1500;
							return;
						}m_IsPrintRightCol2=true;
					}
					if(m_IsPrintLeftCol3==false)  //画第三行左边内容
					{
						if(objItemContentArr[4] != null)
						{
							p_strText=objItemContentArr[4].m_strItemContent;	
						}
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_intRecBaseX+15,m_leftLenth,ref m_floatLPosY, p_objGrp, p_fntNormalText, "中鼻道:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatLPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,m_leftLenth+41,PosY,m_leftLenth+41,m_floatLPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintLeftCol3=true;
					}
					if(m_IsPrintRightCol3==false)  //画第三行右边内容
					{
						if(objItemContentArr[5] != null)
							p_strText=objItemContentArr[5].m_strItemContent;		
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "中鼻道:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatRPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintRightCol3=true;
					}

					if(m_IsPrintLeftCol4==false)  //画第四行左边内容
					{
						if(objItemContentArr[6] != null)
						{
							p_strText=objItemContentArr[6].m_strItemContent;	
						}
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_intRecBaseX+15,m_leftLenth,ref m_floatLPosY, p_objGrp, p_fntNormalText, "下鼻甲:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatLPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,m_leftLenth+41,PosY,m_leftLenth+41,m_floatLPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintLeftCol4=true;
					}
					if(m_IsPrintRightCol4==false)  //画第四行右边内容
					{
						if(objItemContentArr[7] != null)
							p_strText=objItemContentArr[7].m_strItemContent;		
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "下鼻甲:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatRPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintRightCol4=true;
					}

					if(m_IsPrintLeftCol5==false)  //画第五行左边内容
					{
						if(objItemContentArr[8] != null)
						{
							p_strText=objItemContentArr[8].m_strItemContent;	
						}
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_intRecBaseX+15,m_leftLenth,ref m_floatLPosY, p_objGrp, p_fntNormalText, "下鼻道:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatLPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,m_leftLenth+41,PosY,m_leftLenth+41,m_floatLPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintLeftCol5=true;
					}
					if(m_IsPrintRightCol5==false)  //画第五行右边内容
					{
						if(objItemContentArr[9] != null)
							p_strText=objItemContentArr[9].m_strItemContent;		
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "下鼻道:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatRPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintRightCol5=true;
					}
					if(m_IsPrintLeftCol6==false)  //画第六行左边内容
					{
						if(objItemContentArr[10] != null)
						{
							p_strText=objItemContentArr[10].m_strItemContent;	
						}
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_intRecBaseX+15,m_leftLenth,ref m_floatLPosY, p_objGrp, p_fntNormalText, "嗅裂:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,PosY,clsPrintPosition.c_intRightLineX-25,PosY);

							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatLPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
							p_objGrp.DrawLine (Pens.Black,m_leftLenth+41,PosY,m_leftLenth+41,m_floatLPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintLeftCol6=true;
					}
					if(m_IsPrintRightCol6==false)  //画第六行右边内容
					{
						if(objItemContentArr[11] != null)
							p_strText=objItemContentArr[11].m_strItemContent;		
						else
							p_strText="";
						m_mthPrintDioa(ref flage,m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "嗅裂:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,m_floatRPosY);	
							p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatRPosY);
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);

							p_intPosY+=1500;
							return;
						}
						m_IsPrintRightCol6=true;
					}
					#endregion
				}
             
			// m_mthPrintRightContent(ref m_floatRPosY, p_objGrp, p_fntNormalText,ref RightX);//打印右边的内容
				if(m_floatRPosY>=m_floatLPosY)
				{
					p_intPosY= (int)m_floatRPosY;
				}
				else
					p_intPosY=(int)m_floatLPosY;
				if(p_intPosY-PosY<PicHeight)
                    p_intPosY = PosY + PicHeight + 2;
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+15,PosY,clsPrintPosition.c_intLeftX+15 ,p_intPosY);	
				p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,p_intPosY);
				p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,p_intPosY);
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
				p_objGrp.DrawLine (Pens.Black,m_leftLenth+41,PosY,m_leftLenth+41,p_intPosY);
				
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,PosY,clsPrintPosition.c_intRightLineX-25,PosY);


//				if(m_blnHavePrintInfo(m_strKeysArr1) != false)
//					p_objGrp.DrawString ("左",p_fntNormalText,Brushes.Black,(float)(m_intRecBaseX+20),(float)p_intPosY);
//					
//				else
//					m_mthMakeCheckText(m_strKeysArr01,ref strAllText,ref strXml);

				//if (m_mthIsPage(p_intPosY,ColHeight)) {return;}
				//				#region 最上面得线
				////				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY-10);
				//				#endregion
//				System.Drawing.Font p_TsFont=new Font (p_fntNormalText.Name ,p_fntNormalText.Size -3);
//				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.LeftX+80) ,(float)p_intPosY+ColHeight+10);
				
				
			
				
//				#region 画底线
//				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
//				#endregion
				m_blnHaveMoreLine = false;
			}
			#region 画右边内容
//		public  void m_mthPrintRightContent(ref float m_floatRPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,ref float RightX)
//		{
//			string p_strText="";
//			float PosY=m_floatRPosY;
//               m_floatRPosY+=3;
//
//			int m_Lenth=clsPrintPosition.c_intRightX-clsPrintPosition.c_intLeftX;
//			
//			float m_RightLenth=(m_Lenth-m_objPrintInfo.m_objContent.m_objPics[4].intWidth)/2;
//			int m_Right=clsPrintPosition.c_intRightX-(int)m_RightLenth-22;
//			RightX=m_Right+20;
//			p_objGrp.DrawString ("右",p_fntNormalText,Brushes.Black,(float)(m_Right),m_floatRPosY+60);
//			clsInpatMedRec_Item[] objItemContentArr = null;
//			objItemContentArr = m_objGetContentFromItemArr(new string[]{"右>>鼻前庭","右>>中鼻甲","右>>中鼻道","右>>下鼻甲"
//																		   ,"右>>下鼻道","右>>嗅裂"});		
//			if(objItemContentArr != null)
//			{
//				#region
//				if(objItemContentArr[0] != null)
//				{
//					p_strText=objItemContentArr[0].m_strItemContent;
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "鼻前庭:"+p_strText);
//				}
//				else
//				{
//					p_objGrp.DrawString("鼻前庭:",p_fntNormalText,Brushes.Black,(float)(m_Right+15),m_floatRPosY);	
//                    m_floatRPosY+=20;
//				}
//
//				if(objItemContentArr[1] != null)
//				{
//					p_strText=objItemContentArr[1].m_strItemContent;
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "中鼻甲:"+p_strText);
//				}
//				else
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "中鼻甲:");
//					
//				if(objItemContentArr[2] != null)
//				{
//					p_strText=objItemContentArr[2].m_strItemContent;
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "中鼻道:"+p_strText);
//				}
//				else
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "中鼻道:");
//					
//				if(objItemContentArr[3] != null)
//				{
//					p_strText=objItemContentArr[3].m_strItemContent;
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "下鼻甲:"+p_strText);
//				}
//				else
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "下鼻甲:");
//				if(objItemContentArr[4] != null)
//				{
//					p_strText=objItemContentArr[4].m_strItemContent;
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "下鼻道:"+p_strText);
//				}
//				else
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "下鼻道:");
//				if(objItemContentArr[5] != null)
//				{
//					p_strText=objItemContentArr[5].m_strItemContent;
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "嗅裂:"+p_strText);
//				}
//				else
//					m_mthPrintDioa(m_Right+20,m_Right-162,ref m_floatRPosY, p_objGrp, p_fntNormalText, "嗅裂:");
//				
//	
//      
//				#endregion
//			}
//		
//		}
			#endregion
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
             m_IsPrintLeftCol1=false;
			 m_IsPrintLeftCol2=false;
			 m_IsPrintLeftCol3=false;
			 m_IsPrintLeftCol4=false;
			 m_IsPrintLeftCol5=false;
			 m_IsPrintLeftCol6=false;
			 m_IsPrintRightCol1=false;
			 m_IsPrintRightCol2=false;
			 m_IsPrintRightCol3=false;
			 m_IsPrintRightCol4=false;
			 m_IsPrintRightCol5=false;
			 m_IsPrintRightCol6=false;
				m_objDiagnoseR.m_mthRestartPrint();	
				m_objDiagnoseL.m_mthRestartPrint();	
			}

//			private bool m_mthIsPage(int p_intPosY,int p_ColHeight)
//			{
//				if(p_intPosY+40+p_ColHeight > ((int)enmRectangleInfo.BottomY -50))
//				{
//					m_blnHaveMoreLine = true;
//					
//					p_intPosY += 500;
//					return true;
//				}
//				else
//				{
//					return false;
//				}
//
//			}

		}

		#endregion
		#region 图象--文字打印 画中间的图与文字
		/// <summary>
		/// 图象--文字打印
		/// </summary>
		private class clsPrintSubInf1 : clsIMR_PrintLineBase
		{
			#region Define

			private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black,new Font("",10));
			//private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";
			private bool m_IsPrintCol1=false;
			private bool m_IsPrintCol2=false;
			private bool m_IsPrintCol3=false;
			private bool m_IsPrintCol4=false;
			private bool m_IsPrintCol5=false;
			private bool m_IsPrintCol6=false;
			private bool m_IsPrintCol7=false;
			private bool m_IsPrintCol8=false;
			private bool m_IsPrintCol9=false;
			private bool m_IsPrintCol10=false;
			private bool m_IsPrintCol11=false;
			private bool m_IsPrintCol12=false;
			private bool m_IsPrintCol13=false;
			private bool m_IsPrintCol14=false;
			private bool m_IsPrintCol15=false;
			private bool m_IsPrintCol16=false;
			private bool m_IsPrintCol17=false;
			private bool m_IsPrintCol18=false;
			private bool m_IsPrintCol19=false;
			

			//private Pen PrintPenInf =new Pen(Color.Black ,1);
			/// <summary>
			/// i=0 标记第2个图；i=1 标记第3个图 ；i=2 标记第4个图
			/// </summary>
			int i=0;
		#endregion
			public clsPrintSubInf1()
			{}
			private void m_mthPrintDioa(ref bool flage, float leftX,float Width,ref int m_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,string p_strText)
			{
				//new Rectangle(m_intRecBaseX+20,p_intPosY,620,20)

				RectangleF rtg = new RectangleF(leftX,m_intPosY,Width,20);
				//RectangleF rtg = new RectangleF(m_intRecBaseX+15,m_floatPosY,285,20);
				string strText = p_strText;
				SizeF szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				if(m_intPosY+Convert.ToInt32(szfText.Height+5)>(int)enmRectangleInfo.BottomY-60)
				{
				  flage=true;
                   m_blnHaveMoreLine = true;
					return;
				}
				
				rtg.Y = m_intPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				m_intPosY += Convert.ToInt32(rtg.Height);
              
			}
			private void m_mthPrintDioa(float leftX,float Width,ref int m_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,string p_strText)
			{
				//new Rectangle(m_intRecBaseX+20,p_intPosY,620,20)

				RectangleF rtg = new RectangleF(leftX,m_intPosY,Width,20);
				//RectangleF rtg = new RectangleF(m_intRecBaseX+15,m_floatPosY,285,20);
				string strText = p_strText;
				SizeF szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				
				rtg.Y = m_intPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				m_intPosY += Convert.ToInt32(rtg.Height);
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				int m_LeftPosY;

                int NasalEndoscopeHeight = RS::Resources.NasalEndoscope.Height;
                int PharynxHeigth = RS::Resources.Pharynx.Height;
                int LingualTonsilHeight = RS::Resources.LingualTonsil.Height;
                clsPictureBoxValue objNasalEndoscopeHeight = null;
                clsPictureBoxValue objPharynxHeigth = null;
                clsPictureBoxValue objLingualTonsilHeight = null;

                if (m_objPrintInfo.m_objContent.m_objPics != null)
                {
                    for (int j1 = 0; j1 < m_objPrintInfo.m_objContent.m_objPics.Length; j1++)
                    {
                        if (m_objPrintInfo.m_objContent.m_objPics[j1].m_StrPictureBoxName == "m_picNose1")
                        {
                            NasalEndoscopeHeight = m_objPrintInfo.m_objContent.m_objPics[j1].intHeight;
                            objNasalEndoscopeHeight = m_objPrintInfo.m_objContent.m_objPics[j1];
                        }
                        else if (m_objPrintInfo.m_objContent.m_objPics[j1].m_StrPictureBoxName == "m_picFauces")
                        {
                            PharynxHeigth = m_objPrintInfo.m_objContent.m_objPics[j1].intHeight;
                            objPharynxHeigth = m_objPrintInfo.m_objContent.m_objPics[j1];
                        }
                        else if (m_objPrintInfo.m_objContent.m_objPics[j1].m_StrPictureBoxName == "m_picTongue")
                        {
                            LingualTonsilHeight = m_objPrintInfo.m_objContent.m_objPics[j1].intHeight;
                            objLingualTonsilHeight = m_objPrintInfo.m_objContent.m_objPics[j1];
                        }
                    }
                }

                m_LeftPosY = p_intPosY + NasalEndoscopeHeight;
				if(m_LeftPosY>(int)enmRectangleInfo.BottomY-60)
				{

					p_intPosY+=500;
					return;
					
				}
				if(i==0)
                    m_mthPrintSecondContent(ref p_intPosY, p_objGrp, p_fntNormalText, objNasalEndoscopeHeight);//画第二幅图与内容
			    if(p_intPosY>(int)enmRectangleInfo.BottomY-60)
					return;
                m_LeftPosY = p_intPosY + PharynxHeigth;
				if(m_LeftPosY>(int)enmRectangleInfo.BottomY-60)
				{

					p_intPosY+=500;
					i=1;
					return;
					
				}
				if(i==1||i==0)
                    m_mthPrintThirdContent(ref p_intPosY, p_objGrp, p_fntNormalText, objPharynxHeigth);//画第三幅图与内容
				if(p_intPosY>(int)enmRectangleInfo.BottomY-60)
					return;

                m_LeftPosY = p_intPosY + 2 * LingualTonsilHeight - 60;
				if(m_LeftPosY>(int)enmRectangleInfo.BottomY-60)
				{

					p_intPosY+=500;
					i=2;
					return;
					
				}
				if(i==1||i==0||i==2)
                    m_mthPrintFourthContent(ref p_intPosY, p_objGrp, p_fntNormalText, objLingualTonsilHeight);//画第四幅图与内容
				if(p_intPosY>(int)enmRectangleInfo.BottomY-60)
					return;

  
				//				string p_strText="";
//				float m_floatPosY=(float)(p_intPosY);
//				int PosY=p_intPosY;
//				int ColHeight=0;
//				int m_Lenth=clsPrintPosition.c_intRightX-clsPrintPosition.c_intLeftX;
//				float m_leftLenth=(m_Lenth-m_objPrintInfo.m_objContent.m_objPics[4].intWidth-47)/2;
//				m_floatPosY=m_floatPosY;
//				if(m_floatPosY+m_objPrintInfo.m_objContent.m_objPics[3].intHeight>(int)enmRectangleInfo.BottomY-50)
//				{
//					p_intPosY+=500;
//					return;
//				}
//				if(m_objPrintInfo.m_objContent.m_objPics[3].intImgID==0)//
//				{
//					System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[3].m_bytImage);
//					Image imgPrint = new Bitmap(objStream);
//					p_objGrp.DrawImage(imgPrint,m_intRecBaseX,p_intPosY,m_objPrintInfo.m_objContent.m_objPics[3].intWidth,m_objPrintInfo.m_objContent.m_objPics[3].intHeight);
//					p_objGrp.DrawString((objItemContentArr[3] == null ? "" :(objItemContentArr[3].m_strItemContent == null ? "" : objItemContentArr[3].m_strItemContent)),p_fntNormalText,Brushes.Black,(float)(m_intRecBaseX+20),m_floatPosY);
//				}
//				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatPosY,clsPrintPosition.c_intRightX ,m_floatPosY);//画最上面的线
//				m_floatPosY+=3;
//				clsInpatMedRec_Item[] objItemContentArr = null;
//				objItemContentArr = m_objGetContentFromItemArr(new string[]{"左>>鼻前庭","左>>中鼻甲","左>>中鼻道","左>>下鼻甲"
//																			   ,"左>>下鼻道","左>>嗅裂"});
//				
//				if(objItemContentArr != null)
//				{
//					#region
//					if(objItemContentArr[0] != null)
//					{
//						p_strText=objItemContentArr[0].m_strItemContent;
//						m_mthPrintDioa(m_intRecBaseX+15,m_leftLenth,ref m_floatPosY, p_objGrp, p_fntNormalText, "鼻前庭:"+p_strText);
//					}
//					else
//					{
//						p_objGrp.DrawString("鼻前庭:",p_fntNormalText,Brushes.Black,(float)(m_intRecBaseX+15),m_floatPosY);	
//						m_floatPosY+=20;
//					}
//					
//					
//					#endregion
//				}
//				float m_floatRPosY=(float)p_intPosY;
//				float RightX=0;
//				m_mthPrintRightContent(ref m_floatRPosY, p_objGrp, p_fntNormalText,ref RightX);//打印右边的内容
//				if(m_floatRPosY>=m_floatPosY)
//				{
//					p_intPosY= (int)m_floatRPosY;
//				}
//				else
//					p_intPosY=(int)m_floatPosY;
//				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX+17,PosY,clsPrintPosition.c_intLeftX+17 ,p_intPosY);	
//				p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,p_intPosY);
//				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX,p_intPosY);
//
//
//				//				if(m_blnHavePrintInfo(m_strKeysArr1) != false)
//				//					p_objGrp.DrawString ("左",p_fntNormalText,Brushes.Black,(float)(m_intRecBaseX+20),(float)p_intPosY);
//				//					
//				//				else
//				//					m_mthMakeCheckText(m_strKeysArr01,ref strAllText,ref strXml);
//
//				if (m_mthIsPage(p_intPosY,ColHeight)) {return;}
//				//				#region 最上面得线
//				////				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY-10);
//				//				#endregion
//				//				System.Drawing.Font p_TsFont=new Font (p_fntNormalText.Name ,p_fntNormalText.Size -3);
//				//				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.LeftX+80) ,(float)p_intPosY+ColHeight+10);
//				
//				ColHeight=80;
//			
//				
//				//				#region 画底线
//				//				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
//				//				#endregion
				m_blnHaveMoreLine = false;
			}
			#region 画第二个图与文字
			public void  m_mthPrintSecondContent(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,
                clsPictureBoxValue p_objPicValue)
			{
				string p_strText="";
				bool flage=false;
				int PosY=p_intPosY;

                int m_LeftPosY = p_intPosY + RS::Resources.NasalEndoscope.Height;
                int m_RightPosY = p_intPosY + 5;
                float m_lelftX = clsPrintPosition.c_intLeftX + RS::Resources.NasalEndoscope.Width;
                float m_thLength = clsPrintPosition.c_intRightLineX - clsPrintPosition.c_intLeftX - RS::Resources.NasalEndoscope.Width - 30;
                Image imgPrint = RS::Resources.NasalEndoscope;
                int PicHeight = RS::Resources.NasalEndoscope.Height;
                int PicWidth = RS::Resources.NasalEndoscope.Width;

                if (p_objPicValue != null)
                {
                    m_LeftPosY = p_intPosY + p_objPicValue.intHeight;
                    m_RightPosY = p_intPosY + 5;
                    m_lelftX = clsPrintPosition.c_intLeftX + p_objPicValue.intWidth;
                    m_thLength = clsPrintPosition.c_intRightLineX - clsPrintPosition.c_intLeftX - p_objPicValue.intWidth - 30;
                    PicHeight = p_objPicValue.intHeight;
                    PicWidth = p_objPicValue.intWidth;

                    System.IO.MemoryStream objStream = new System.IO.MemoryStream(p_objPicValue.m_bytImage);
                    imgPrint = new Bitmap(objStream);
                }
                if (m_LeftPosY > (int)enmRectangleInfo.BottomY - 50)
                {
                    p_intPosY += 500;
                    return;
                }
                p_objGrp.DrawImage(imgPrint, m_intRecBaseX - 5, p_intPosY + 5, PicWidth, PicHeight);
				//p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatPosY,clsPrintPosition.c_intRightX ,m_floatPosY);//画最上面的线
				clsInpatMedRec_Item[] objItemArr = null;
				objItemArr = m_objGetContentFromItemArr(new string[]{"鼻内窥镜检查","后鼻孔","鼻咽部"});
			 if(objItemArr!=null)
				{
				 if(objItemArr[0]!=null)
				 {
					 p_strText=objItemArr[0].m_strItemContent;
					 if(m_IsPrintCol1==false)
						 m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "鼻内窥镜检查:"+p_strText);
					 if(flage==true)
					 {
						 i=0;
						 p_intPosY+=500;
						 return;
					 }
					 m_IsPrintCol1=true;
				 }
				 else
				 {
					 m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "鼻内窥镜检查:");
					 if(flage==true)
					 {
						 i=0;
						 p_intPosY+=500;
						 return;
					 }
					 m_IsPrintCol1=true;
				 }
				 if(objItemArr[1]!=null)
				 {
					 p_strText=objItemArr[1].m_strItemContent;
					 if(m_IsPrintCol2==false)
						 m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "后鼻孔:"+p_strText);
					 if(flage==true)
					 {
						 i=0;
						 p_intPosY+=500;
						 return;
					 }
					 m_IsPrintCol2=true;
				 }
				 else
				 {
					 m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "后鼻孔:");
					 if(flage==true)
					 {
						 i=0;
						 p_intPosY+=500;
						 return;
					 }
					 m_IsPrintCol2=true; 
				 }
				 if(objItemArr[2]!=null)
				 {
					 p_strText=objItemArr[2].m_strItemContent;
					 if(m_IsPrintCol3==false)
						 m_mthPrintDioa(m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "鼻咽部:"+p_strText);
					 if(flage==true)
					 {
						 i=0;
						 p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						 p_intPosY+=4;
						 p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						 p_intPosY+=500;
						 return;
					 }
					 m_IsPrintCol3=true;
					
				 }
				 else
				 {
					 m_mthPrintDioa(m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "鼻咽部:");
					 if(flage==true)
					 {
						 i=0;
						 p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						 p_intPosY+=4;
						 p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						 p_intPosY+=500;
						 return;
					 }
					 m_IsPrintCol3=true;
				 }
					
			   }
				if(m_RightPosY>m_LeftPosY)
					p_intPosY=m_RightPosY;
				else 
					p_intPosY=m_LeftPosY;
				p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,p_intPosY);
                   p_intPosY+=4;
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,PosY,clsPrintPosition.c_intRightLineX-25,PosY);

			}
			#endregion

			#region 画第三个图与文字
			public void  m_mthPrintThirdContent(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,
                clsPictureBoxValue p_objPicValue)
			{				
				string p_strText="";
				int PosY=p_intPosY;
				bool flage=false;

                int m_LeftPosY = p_intPosY + RS::Resources.Pharynx.Height;
                int m_RightPosY = p_intPosY + 5;
                float m_lelftX = clsPrintPosition.c_intLeftX + RS::Resources.Pharynx.Width;
                float m_thLength = clsPrintPosition.c_intRightLineX - clsPrintPosition.c_intLeftX - RS::Resources.Pharynx.Width - 30;
                Image imgPrint = RS::Resources.Pharynx;
                int PicHeight = RS::Resources.Pharynx.Height;
                int PicWidth = RS::Resources.Pharynx.Width;

                if (p_objPicValue != null)
                {
                    m_LeftPosY = p_intPosY + p_objPicValue.intHeight;
                    m_RightPosY = p_intPosY + 5;
                    m_lelftX = clsPrintPosition.c_intLeftX + p_objPicValue.intWidth;
                    m_thLength = clsPrintPosition.c_intRightLineX - clsPrintPosition.c_intLeftX - p_objPicValue.intWidth - 30;
                    PicHeight = p_objPicValue.intHeight;
                    PicWidth = p_objPicValue.intWidth;

                    System.IO.MemoryStream objStream = new System.IO.MemoryStream(p_objPicValue.m_bytImage);
                    imgPrint = new Bitmap(objStream);
                }

                if (m_LeftPosY > (int)enmRectangleInfo.BottomY - 60)
                {

                    p_intPosY += 500;

                }
                p_objGrp.DrawImage(imgPrint, m_intRecBaseX - 5, p_intPosY + 5, PicWidth, PicHeight);

				//p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatPosY,clsPrintPosition.c_intRightX ,m_floatPosY);//画最上面的线
				clsInpatMedRec_Item[] objItemArr = null;
				objItemArr = m_objGetContentFromItemArr(new string[]{"咽部粘膜","腭扁桃体","软腭","悬雍垂","咽后壁","咽侧索"});
				if(objItemArr!=null)
				{
					if(objItemArr[0]!=null)
					{
						p_strText=objItemArr[0].m_strItemContent;
						if(m_IsPrintCol4==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "咽部粘膜:"+p_strText);
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						m_IsPrintCol4=true;
					}
					else
					{
						if(m_IsPrintCol4==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "咽部粘膜:");
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
					    	p_intPosY+=500;
							i=1;
							return;
						}
							m_IsPrintCol4=true;
					}
					if(objItemArr[1]!=null)
					{
						p_strText=objItemArr[1].m_strItemContent;
						if(m_IsPrintCol5==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "腭扁桃体:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							i=1;
							return;
						}
						m_IsPrintCol5=true;
					}
					else
					{
						if(m_IsPrintCol5==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "腭扁桃体:");
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						m_IsPrintCol5=true;
					}
					if(objItemArr[2]!=null)
					{
						p_strText=objItemArr[2].m_strItemContent;
						if(m_IsPrintCol6==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "软腭:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							i=1;
							return;
						}
						m_IsPrintCol6=true;
					}
					else
					{
						if(m_IsPrintCol6==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "软腭:");
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						m_IsPrintCol6=true;
					}
					if(objItemArr[3]!=null)
					{
						p_strText=objItemArr[3].m_strItemContent;
						if(m_IsPrintCol7==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "悬雍垂:"+p_strText);
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							i=1;
							return;
						}
						m_IsPrintCol7=true;
					}
					else
					{
						if(m_IsPrintCol7==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "悬雍垂:");
						if(flage==true)
						{
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							i=1;
							return;
						} 
						m_IsPrintCol7=true;
					}
					if(objItemArr[4]!=null)
					{
						p_strText=objItemArr[4].m_strItemContent;
						if(m_IsPrintCol8==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "咽后壁:"+p_strText);
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						m_IsPrintCol8=true;
					}
					else
					{
						if(m_IsPrintCol8==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "咽后壁:");
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						m_IsPrintCol8=true;
					}
					if(objItemArr[5]!=null)
					{
						p_strText=objItemArr[5].m_strItemContent;

						if(m_IsPrintCol9==false)
							m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "咽侧索:"+p_strText);
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						else
							m_IsPrintCol9=true;
							
						
					}
					else
					{
						if(m_IsPrintCol9==false)
						 m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "咽侧索:");
						if(flage==true)
						{
							i=1;
							p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
							p_intPosY+=4;
							p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
							return;
						}
						else
							m_IsPrintCol9=true;
					}
					
					
					
				}
				if(m_RightPosY>m_LeftPosY)
					p_intPosY=m_RightPosY;
				else 
					p_intPosY=m_LeftPosY;
				p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,p_intPosY);
				p_intPosY+=4;
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,PosY,clsPrintPosition.c_intRightLineX-25,PosY);

			}
			#endregion
			#region 画第四个图与文字
            public void m_mthPrintFourthContent(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,
                clsPictureBoxValue p_objPicValue)
			{
				
				string p_strText="";
				bool flage=false;
				int PosY=p_intPosY;

                int m_LeftPosY = p_intPosY + RS::Resources.LingualTonsil.Height;
                int m_RightPosY = p_intPosY + 5;
                float m_lelftX = clsPrintPosition.c_intLeftX + RS::Resources.LingualTonsil.Width;
                float m_thLength = clsPrintPosition.c_intRightLineX - clsPrintPosition.c_intLeftX - RS::Resources.LingualTonsil.Width - 30;
                Image imgPrint = RS::Resources.LingualTonsil;
                int PicHeight = RS::Resources.LingualTonsil.Height;
                int PicWidth = RS::Resources.LingualTonsil.Width;

                if (p_objPicValue != null)
                {
                    m_LeftPosY = p_intPosY + p_objPicValue.intHeight;
                    m_RightPosY = p_intPosY + 5;
                    m_lelftX = clsPrintPosition.c_intLeftX + p_objPicValue.intWidth;
                    m_thLength = clsPrintPosition.c_intRightLineX - clsPrintPosition.c_intLeftX - p_objPicValue.intWidth - 30;
                    PicHeight = p_objPicValue.intHeight;
                    PicWidth = p_objPicValue.intWidth;

                    System.IO.MemoryStream objStream = new System.IO.MemoryStream(p_objPicValue.m_bytImage);
                    imgPrint = new Bitmap(objStream);
                }
                p_objGrp.DrawImage(imgPrint, m_intRecBaseX - 5, p_intPosY + 5, PicWidth, PicHeight);
				//p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatPosY,clsPrintPosition.c_intRightX ,m_floatPosY);//画最上面的线
				clsInpatMedRec_Item[] objItemArr = null;
				objItemArr = m_objGetContentFromItemArr(new string[]{"舌扁桃体","会厌","会厌骨","披带","室带","室间沟","声带","前连合","声门下","梨状窝"});
				if(objItemArr!=null)
				{	
					if(objItemArr[0]!=null)
					p_strText=objItemArr[0].m_strItemContent;
					else
                    p_strText="";
                    if(m_IsPrintCol10==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "舌扁桃体:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol10=true;

					if(objItemArr[1]!=null)	
					p_strText=objItemArr[1].m_strItemContent;
					else
						p_strText="";
					 if(m_IsPrintCol11==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "会厌:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol11=true;

					if(objItemArr[2]!=null)
					p_strText=objItemArr[2].m_strItemContent;
					else
                    p_strText="";
                   if(m_IsPrintCol12==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "会厌骨:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol12=true;

					if(objItemArr[3]!=null)
					p_strText=objItemArr[3].m_strItemContent;
					else
                    p_strText="";
                     if(m_IsPrintCol13==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "披带:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol13=true;
					
					if(objItemArr[4]!=null)
					p_strText=objItemArr[4].m_strItemContent;
					else
						p_strText="";
					if(m_IsPrintCol14==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "室带:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol14=true;
					
					if(objItemArr[5]!=null)
					p_strText=objItemArr[5].m_strItemContent;
					else
                     p_strText="";
					if(m_IsPrintCol15==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "室间沟:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						flage=false;
						return;
					}
					else
						m_IsPrintCol15=true;

					if(objItemArr[6]!=null)
					p_strText=objItemArr[6].m_strItemContent;
					else
                      p_strText="";
					if(m_IsPrintCol16==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "声带:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
                       p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol16=true;
					
					if(objItemArr[7]!=null)
					p_strText=objItemArr[7].m_strItemContent;
					else
                     p_strText="";
					if(m_IsPrintCol17==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "前连合:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
							p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol17=true;
					
					if(objItemArr[8]!=null)
					p_strText=objItemArr[8].m_strItemContent;
					else
                     p_strText="";
                  if(m_IsPrintCol18==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "声门下:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol18=true;
					
					if(objItemArr[9]!=null)
					p_strText=objItemArr[9].m_strItemContent;
					else
                    p_strText="";
                    if(m_IsPrintCol19==false)
					m_mthPrintDioa(ref flage,m_lelftX,m_thLength,ref m_RightPosY, p_objGrp, p_fntNormalText, "梨状窝:"+p_strText);
					if(flage==true)
					{
						i=2;
						p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,m_RightPosY);
						p_intPosY+=4;
						p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_RightPosY,clsPrintPosition.c_intRightLineX-25,m_RightPosY);
				
						p_intPosY+=500;
						return;
					}
					else
						m_IsPrintCol19=true;
					
				}
				if(m_RightPosY>m_LeftPosY)
					p_intPosY=m_RightPosY;
				else 
					p_intPosY=m_LeftPosY;
				
					p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,p_intPosY);
					p_intPosY+=4;
					p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,PosY,clsPrintPosition.c_intRightLineX-25,PosY);
				
			}
			#endregion
//		private void m_DrawLine(float m_lelftX,int PosY,float )
//		{
//			p_objGrp.DrawLine (Pens.Black,m_lelftX-5,PosY,m_lelftX-5,p_intPosY);
//			p_intPosY+=4;
//			p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
//		}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
				i=0;
			 m_IsPrintCol1=false;
			 m_IsPrintCol2=false;
			 m_IsPrintCol3=false;
		     m_IsPrintCol4=false;
			 m_IsPrintCol5=false;
			 m_IsPrintCol6=false;
			 m_IsPrintCol7=false;
			 m_IsPrintCol8=false;
			 m_IsPrintCol9=false;
			 m_IsPrintCol10=false;
			 m_IsPrintCol11=false;
			 m_IsPrintCol12=false;
			 m_IsPrintCol13=false;
			 m_IsPrintCol14=false;
			 m_IsPrintCol15=false;
			 m_IsPrintCol16=false;
			 m_IsPrintCol17=false;
			 m_IsPrintCol18=false;
			 m_IsPrintCol19=false;
		
				m_objDiagnoseR.m_mthRestartPrint();	
				m_objDiagnoseL.m_mthRestartPrint();	
			}

			private bool m_mthIsPage(int p_intPosY,int p_ColHeight)
			{
				if(p_intPosY+40+p_ColHeight > ((int)enmRectangleInfo.BottomY -50))
				{
					m_blnHaveMoreLine = true;
					
					p_intPosY += 500;
					return true;
				}
				else
				{
					return false;
				}

			}

		}

		#endregion

		#region 图象--文字打印 画第五、六幅图
		/// <summary>
		/// 图象--文字打印
		/// </summary>
		private class clsPrintSubInf2 : clsIMR_PrintLineBase
		{
			#region Define
			private bool m_IsPrintLeftCol1=false;
			private bool m_IsPrintLeftCol2=false;
			private bool m_IsPrintLeftCol3=false;
			private bool m_IsPrintLeftCol4=false;
			private bool m_IsPrintLeftCol5=false;
			private bool m_IsPrintRightCol1=false;
			private bool m_IsPrintRightCol2=false;
			private bool m_IsPrintRightCol3=false;
			private bool m_IsPrintRightCol4=false;
			private bool m_IsPrintRightCol5=false;
			private clsPrintRichTextContext m_objDiagnoseR = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsPrintRichTextContext m_objDiagnoseL = new clsPrintRichTextContext(Color.Black,new Font("",10));
			//			private string m_strTitle = "";
			//			private string[] m_strTitleArr = null;
			private string m_strImagePath = Directory.GetParent(Directory.GetParent(Application.StartupPath).ToString()) + "\\picture\\Ophthalmology\\";

			#endregion
            int i1=0;
			public clsPrintSubInf2()
			{}
			private void m_mthPrintDioa(ref bool flage,float leftX,float Width,ref float m_floatPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,string p_strText)
			{
				RectangleF rtg = new RectangleF(leftX,m_floatPosY,Width,20);
				//RectangleF rtg = new RectangleF(m_intRecBaseX+15,m_floatPosY,285,20);
				string strText = p_strText;
				SizeF szfText = p_objGrp.MeasureString(strText,p_fntNormalText,Convert.ToInt32(rtg.Width));
				rtg.Height = szfText.Height+5;
				if(m_floatPosY+szfText.Height+5>(int)enmRectangleInfo.BottomY-60)
				{
					flage=true;
					m_blnHaveMoreLine = true;
					return;
				}
				rtg.Y = m_floatPosY;
				p_objGrp.DrawString(strText,p_fntNormalText,Brushes.Black,rtg);
				m_floatPosY += Convert.ToInt32(rtg.Height);
			}
			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				string p_strText="";
				bool flage=false;
				float m_floatLPosY=(float)(p_intPosY);
				int PosY=p_intPosY; 
				float m_floatRPosY=(float)p_intPosY;
				 m_floatRPosY+=3;		
				float RightX=0;
				int m_Lenth=clsPrintPosition.c_intRightX-clsPrintPosition.c_intLeftX;

                int LeftPinnaWidth = RS::Resources.LeftPinna.Width;
                int LeftPinnaHeight = RS::Resources.LeftPinna.Height;
                int RightPinnaWidth = RS::Resources.RightPinna.Width;
                int RightPinnaHeight = RS::Resources.RightPinna.Height;

                Image imgLeftPrint = RS::Resources.LeftPinna;
                Image imgRightPrint = RS::Resources.RightPinna;

                if (m_objPrintInfo.m_objContent.m_objPics != null)
                {
                    for (int j1 = 0; j1 < m_objPrintInfo.m_objContent.m_objPics.Length; j1++)
                    {
                        if (m_objPrintInfo.m_objContent.m_objPics[j1].m_StrPictureBoxName == "m_picLeftEarPicture")
                        {
                            System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[j1].m_bytImage);
                            imgLeftPrint = new Bitmap(objStream);
                            LeftPinnaWidth = m_objPrintInfo.m_objContent.m_objPics[j1].intWidth;
                            LeftPinnaHeight = m_objPrintInfo.m_objContent.m_objPics[j1].intHeight;
                        }
                        else if (m_objPrintInfo.m_objContent.m_objPics[j1].m_StrPictureBoxName == "m_picRightEarPicture")
                        {
                            System.IO.MemoryStream objStream = new System.IO.MemoryStream((byte[])m_objPrintInfo.m_objContent.m_objPics[j1].m_bytImage);
                            imgRightPrint = new Bitmap(objStream);
                            RightPinnaWidth = m_objPrintInfo.m_objContent.m_objPics[j1].intWidth;
                            RightPinnaHeight = m_objPrintInfo.m_objContent.m_objPics[j1].intHeight;
                        }
                    }
                }
                int m_line = clsPrintPosition.c_intRightLineX - RightPinnaWidth - 25;

                float m_leftLenth = (m_Lenth - LeftPinnaWidth - RightPinnaWidth - 30) / 2;
                float m_RightLenth = (m_Lenth - LeftPinnaWidth - RightPinnaWidth - 25) / 2;

                int m_Right = clsPrintPosition.c_intRightX - (int)m_RightLenth - LeftPinnaWidth - 10;
				RightX=m_Right+15;

                if (m_floatLPosY + LeftPinnaHeight > (int)enmRectangleInfo.BottomY - 20)
				{
					p_intPosY+=500;
					return;
				}
				if(i1==0)
				{
					p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightX ,m_floatLPosY);//画最上面的线
					m_floatLPosY+=3;
                    p_objGrp.DrawImage(imgLeftPrint, clsPrintPosition.c_intLeftX - 5, p_intPosY + 5, LeftPinnaWidth, LeftPinnaHeight);

                    p_objGrp.DrawImage(imgRightPrint, clsPrintPosition.c_intRightLineX - RightPinnaWidth - 27, p_intPosY + 5, RightPinnaWidth, RightPinnaHeight);

                    p_objGrp.DrawString("左", p_fntNormalText, Brushes.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 10), m_floatLPosY + 60);
					p_objGrp.DrawString ("右",p_fntNormalText,Brushes.Black,(float)(m_Right-2),m_floatRPosY+60);
					
					clsInpatMedRec_Item[] objItemContentArr = null;
                    objItemContentArr = m_objGetContentFromItemArr(new string[]{"左>>耳廓","右>>耳廓","左>>乳突出","右>>乳突出","左>>外耳道","右>>外耳道","左>>鼓膜","右>>鼓膜"
																				   ,"左>>鼓室","右>>鼓室"});	
					if(objItemContentArr != null)
					{
						#region
						if(m_IsPrintLeftCol1==false) //画第一行左边的内容
						{
							if(objItemContentArr[0] != null)
							{
								p_strText=objItemContentArr[0].m_strItemContent;
								
							}
							else
                                p_strText="";
                            m_mthPrintDioa(ref flage, m_intRecBaseX + LeftPinnaWidth + 10, m_leftLenth, ref m_floatLPosY, p_objGrp, p_fntNormalText, "耳廓:" + p_strText);
							if(flage==true)
							{
								p_intPosY+=1500;
								return;
							}
                            m_IsPrintLeftCol1=true;
						}
						if(m_IsPrintRightCol1==false) //画第一行右边的内容
						{
							if(objItemContentArr[1] != null)
							{
								p_strText=objItemContentArr[1].m_strItemContent;	
							}
							else
								p_strText="";
							m_mthPrintDioa(ref flage,m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "耳廓:"+p_strText);
							if(flage==true)
							{
								p_intPosY+=1500;
								return;
							}
							m_IsPrintRightCol1=true;
						}


						if(m_IsPrintLeftCol2==false) //画第二行左边的内容
						{
							if(objItemContentArr[2] != null)
							{
								p_strText=objItemContentArr[2].m_strItemContent;
								
							}
							else
								p_strText="";
                            m_mthPrintDioa(ref flage, m_intRecBaseX + LeftPinnaWidth + 10, m_leftLenth, ref m_floatLPosY, p_objGrp, p_fntNormalText, "乳突出:" + p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatLPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatLPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-20,PosY,RightX-20,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintLeftCol2=true;
						}
						if(m_IsPrintRightCol2==false) //画第二行右边的内容
						{
							if(objItemContentArr[3] != null)
							{
								p_strText=objItemContentArr[3].m_strItemContent;	
							}
							else
								p_strText="";
							m_mthPrintDioa(ref flage,m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "乳突出:"+p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatRPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatRPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintRightCol2=true;
						}
						if(m_IsPrintLeftCol3==false) //画第三行左边的内容
						{
							if(objItemContentArr[4] != null)
							{
								p_strText=objItemContentArr[4].m_strItemContent;
								
							}
							else
								p_strText="";
                            m_mthPrintDioa(ref flage, m_intRecBaseX + LeftPinnaWidth + 10, m_leftLenth, ref m_floatLPosY, p_objGrp, p_fntNormalText, "外耳道:" + p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatLPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatLPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintLeftCol3=true;
						}
						if(m_IsPrintRightCol3==false) //画第三行右边的内容
						{
							if(objItemContentArr[5] != null)
							{
								p_strText=objItemContentArr[5].m_strItemContent;	
							}
							else
								p_strText="";
							m_mthPrintDioa(ref flage,m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "外耳道:"+p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatRPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatRPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);
								p_intPosY+=1500;
								return;
							}
							m_IsPrintRightCol3=true;
						}
						if(m_IsPrintLeftCol4==false) //画第四行左边的内容
						{
							if(objItemContentArr[6] != null)
							{
								p_strText=objItemContentArr[6].m_strItemContent;
								
							}
							else
								p_strText="";
                            m_mthPrintDioa(ref flage, m_intRecBaseX + LeftPinnaWidth + 10, m_leftLenth, ref m_floatLPosY, p_objGrp, p_fntNormalText, "鼓膜:" + p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatLPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatLPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintLeftCol4=true;
						}
						if(m_IsPrintRightCol4==false) //画第四行右边的内容
						{
							if(objItemContentArr[7] != null)
							{
								p_strText=objItemContentArr[7].m_strItemContent;	
							}
							else
								p_strText="";
                            m_mthPrintDioa(ref flage, m_Right + 20, m_Right - 185, ref m_floatRPosY, p_objGrp, p_fntNormalText, "鼓膜:" + p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatRPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatRPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintRightCol4=true;
						}
						if(m_IsPrintLeftCol5==false) //画第五行左边的内容
						{
							if(objItemContentArr[8] != null)
							{
								p_strText=objItemContentArr[8].m_strItemContent;
								
							}
							else
								p_strText="";
                            m_mthPrintDioa(ref flage, m_intRecBaseX + LeftPinnaWidth + 10, m_leftLenth, ref m_floatLPosY, p_objGrp, p_fntNormalText, "鼓室:" + p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatLPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatLPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatLPosY,clsPrintPosition.c_intRightLineX-25,m_floatLPosY);
								p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintLeftCol5=true;
						}
						if(m_IsPrintRightCol5==false) //画第五行右边的内容
						{
							if(objItemContentArr[9] != null)
							{
								p_strText=objItemContentArr[9].m_strItemContent;	
							}
							else
								p_strText="";
							m_mthPrintDioa(ref flage,m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "鼓室:"+p_strText);
							if(flage==true)
							{
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), m_floatRPosY);
                                p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), m_floatRPosY);	
								p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,m_floatRPosY,clsPrintPosition.c_intRightLineX-25,m_floatRPosY);
								p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
								
								p_intPosY+=1500;
								return;
							}
							m_IsPrintRightCol5=true;
						}
						#endregion
					}
					
					//m_mthPrintRightContent(ref m_floatRPosY, p_objGrp, p_fntNormalText,ref RightX);//打印右边的内容
					if(m_floatRPosY>=m_floatLPosY)
					{
						p_intPosY= (int)m_floatRPosY;
					}
					else
						p_intPosY=(int)m_floatLPosY;
                    if (p_intPosY - PosY < LeftPinnaHeight)
                        p_intPosY = PosY + LeftPinnaHeight + 2;
                    //画线
                    p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth + 10), p_intPosY);
                    p_objGrp.DrawLine(Pens.Black, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), PosY, (float)(clsPrintPosition.c_intLeftX + LeftPinnaWidth - 5), p_intPosY);	
					p_objGrp.DrawLine (Pens.Black,RightX,PosY,RightX,p_intPosY);
					p_objGrp.DrawLine (Pens.Black,RightX-18,PosY,RightX-18,p_intPosY);
					p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
					p_objGrp.DrawLine (Pens.Black,m_line,PosY,m_line,p_intPosY);
					
					p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,PosY,clsPrintPosition.c_intRightLineX-25,PosY);
				
				}
				#region 画 音叉检查
                    clsInpatMedRec_Item[] objItemArr = null;
				objItemArr = m_objGetContentFromItemArr(new string[]{"音叉检查"});
					float floatPosY=0;
				if(objItemArr != null)
				{
                    floatPosY=p_intPosY+5;
					if(p_intPosY>(int)enmRectangleInfo.BottomY-50)
					{
						i1=1;
					 p_intPosY+=500;
						return;
					}
					if(objItemArr[0] != null)
					{
						p_strText=objItemArr[0].m_strItemContent;
						m_mthPrintDioa(ref flage,m_intRecBaseX,m_Lenth-80,ref floatPosY, p_objGrp, p_fntNormalText, "音叉检查:"+p_strText);
					}
					else
						m_mthPrintDioa(ref flage,m_intRecBaseX,m_Lenth-80,ref floatPosY, p_objGrp, p_fntNormalText, "音叉检查:");
				}
                    p_intPosY= (int)floatPosY-1;
				p_objGrp.DrawLine (Pens.Black,clsPrintPosition.c_intLeftX-10,p_intPosY,clsPrintPosition.c_intRightLineX-25,p_intPosY);
				#endregion


				//				if(m_blnHavePrintInfo(m_strKeysArr1) != false)
				//					p_objGrp.DrawString ("左",p_fntNormalText,Brushes.Black,(float)(m_intRecBaseX+20),(float)p_intPosY);
				//					
				//				else
				//					m_mthMakeCheckText(m_strKeysArr01,ref strAllText,ref strXml);

				//if (m_mthIsPage(p_intPosY,ColHeight)) {return;}
				//				#region 最上面得线
				////				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY-10);
				//				#endregion
				//				System.Drawing.Font p_TsFont=new Font (p_fntNormalText.Name ,p_fntNormalText.Size -3);
				//				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY-10 ,(float)(enmRectangleInfo.LeftX+80) ,(float)p_intPosY+ColHeight+10);
				
			
			
				
				//				#region 画底线
				//				p_objGrp.DrawLine (PrintPenInf,(float)(enmRectangleInfo.LeftX+15),(float)p_intPosY ,(float)(enmRectangleInfo.RightX-20) ,(float)p_intPosY);
				//				#endregion
				m_blnHaveMoreLine = false;
			}
			#region 画右边内容
			public  void m_mthPrintRightContent(ref float m_floatRPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText,ref float RightX)
			{
//				string p_strText="";
//				float PosY=m_floatRPosY;
//				m_floatRPosY+=3;
//
//				int m_Lenth=clsPrintPosition.c_intRightX-clsPrintPosition.c_intLeftX;
//			
//				float m_RightLenth=(m_Lenth-m_objPrintInfo.m_objContent.m_objPics[1].intWidth-m_objPrintInfo.m_objContent.m_objPics[2].intWidth-25)/2;
//			
//				int m_Right=clsPrintPosition.c_intRightX-(int)m_RightLenth-m_objPrintInfo.m_objContent.m_objPics[1].intWidth-10;
//				RightX=m_Right+15;
//				p_objGrp.DrawString ("右",p_fntNormalText,Brushes.Black,(float)(m_Right-2),m_floatRPosY+60);
//				clsInpatMedRec_Item[] objItemContentArr = null;		
//				objItemContentArr = m_objGetContentFromItemArr(new string[]{"右>>耳廓","右>>乳突出","右>>外耳道","右>>骨膜"
//																			   ,"右>>鼓室"});	
//				if(objItemContentArr != null)
//				{
//					#region
//					
//
//					if(objItemContentArr[0] != null)
//					{
//						p_strText=objItemContentArr[0].m_strItemContent;
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "耳廓:"+p_strText);
//					}
//					else
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "耳廓:");
//					if(objItemContentArr[1] != null)
//					{
//						p_strText=objItemContentArr[1].m_strItemContent;
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "乳突出:"+p_strText);
//					}
//					else
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "乳突出:");
//					if(objItemContentArr[2] != null)
//					{
//						p_strText=objItemContentArr[2].m_strItemContent;
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "外耳道:"+p_strText);
//					}
//					else
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "外耳道:");
//					if(objItemContentArr[3] != null)
//					{
//						p_strText=objItemContentArr[3].m_strItemContent;
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "骨膜:"+p_strText);
//					}
//					else
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "骨膜:");
//
//					if(objItemContentArr[4] != null)
//					{
//						p_strText=objItemContentArr[4].m_strItemContent;
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "鼓室:"+p_strText);
//					}
//					else
//						m_mthPrintDioa(m_Right+20,m_Right-185,ref m_floatRPosY, p_objGrp, p_fntNormalText, "鼓室:");

//					#endregion
//				}
		
			}
			#endregion
			public override void m_mthReset()
			{
				i1=0;
				m_blnHaveMoreLine = true;
				m_IsPrintLeftCol1=false;
				m_IsPrintLeftCol2=false;
				m_IsPrintLeftCol3=false;
				m_IsPrintLeftCol4=false;
				m_IsPrintLeftCol5=false;
				
				m_IsPrintRightCol1=false;
				m_IsPrintRightCol2=false;
				m_IsPrintRightCol3=false;
				m_IsPrintRightCol4=false;
				m_IsPrintRightCol5=false;
				
				m_objDiagnoseR.m_mthRestartPrint();	
				m_objDiagnoseL.m_mthRestartPrint();	
			}

			//			private bool m_mthIsPage(int p_intPosY,int p_ColHeight)
			//			{
			//				if(p_intPosY+40+p_ColHeight > ((int)enmRectangleInfo.BottomY -50))
			//				{
			//					m_blnHaveMoreLine = true;
			//					
			//					p_intPosY += 500;
			//					return true;
			//				}
			//				else
			//				{
			//					return false;
			//				}
			//
			//			}

		}

		#endregion
        */
	}

}