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
	/// 耳鼻喉科住院病历打印 的摘要说明。
	/// </summary>
	public class clsIMR_HeartVasSurgeryRecordPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_HeartVasSurgeryRecordPrintTool(string p_strTypeID) :base(p_strTypeID)
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
																		   new clsPrintPatientFixInfo("心血管外科入院记录",295),
																		   m_objPrintOneItemArr[0],m_objPrintOneItemArr[1],
																		   m_objPrintMultiItemArr[0],m_objPrintMultiItemArr[1],
                                                                           m_objPrintMultiItemArr[19],
                                                                           m_objPrintMultiItemArr[2],m_objPrintMultiItemArr[18],m_objPrintMultiItemArr[3],m_objPrintMultiItemArr[4],
                                                                           m_objPrintMultiItemArr[5],m_objPrintMultiItemArr[6],m_objPrintMultiItemArr[7],
                                                                           m_objPrintMultiItemArr[8],m_objPrintMultiItemArr[9],m_objPrintMultiItemArr[10],
                                                                           m_objPrintMultiItemArr[11],m_objPrintMultiItemArr[12],m_objPrintMultiItemArr[13],
                                                                           m_objPrintMultiItemArr[14],m_objPrintMultiItemArr[15],m_objPrintMultiItemArr[20],m_objPrintMultiItemArr[16],
                                                                           m_objPrintMultiItemArr[17],m_objPrintOneItemArr[2],m_objPrintOneItemArr[3],
                                                                           m_objPrintMultiItemArr[21],m_objPrintMultiItemArr[22]
																	   });
		}

		private void m_mthInitPrintLineArr()
		{
			  m_objPrintOneItemArr = new clsPrintInPatMedRecItem[4];
			for(int i1=0;i1<m_objPrintOneItemArr.Length;i1++)
				m_objPrintOneItemArr[i1] = new clsPrintInPatMedRecItem();

			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[23];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();
 
			m_objPrintSignArr = new clsPrintInPatMedRecSign[1];
			for(int k3=0;k3<m_objPrintSignArr.Length;k3++)
				m_objPrintSignArr[k3] = new clsPrintInPatMedRecSign();
		}
		
		protected override void m_mthSetSubPrintInfo()
		{

			#region 主诉-现病史-耳鼻喉专科检查
			m_objPrintOneItemArr[0].m_mthSetPrintValue("主诉","主  诉：");
			m_objPrintOneItemArr[1].m_mthSetPrintValue("现病史","现病史：");
            m_objPrintOneItemArr[2].m_mthSetPrintValue("辅助检查", "辅助检查：");
            m_objPrintOneItemArr[3].m_mthSetPrintValue("初步诊断", "初步诊断：");

			#endregion	
            #region 过去史
            m_objPrintMultiItemArr[0].m_mthSetPrintValue("","过去史：");
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "过去史>>传染病及传染病接触史", "过去史>>按计划预防接种", 
                "过去史>>药物及食物过敏史", "过去史>>外伤与手术史", "过去史>>输血及血制品史", "过去史>>其他" },
                new string[] { "传染病或慢性病史：$$", "\n按计划预防接种：$$", "\n药物或食物过敏史：$$", "\n外伤与手术史：$$", 
                    "\n输血及血制品史：$$", "\n其他：$$" });
            #endregion
            #region 个人史
            m_objPrintMultiItemArr[1].m_mthSetPrintValue("","个人史：");
            m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[] { "个人史>>出生地", "个人史>>地方病情况", "个人史>>习惯及嗜好",
                "个人史>>疫水接触史", "个人史>>食生鱼史", "个人史>>其他" },
                new string[] { "出生地：$$", "地方病地区居住情况：", "\n不良嗜好：$$", "\n疫水接触史：$$", "食鱼生史：", "\n其他：$$" });
            #endregion
            #region 婚姻史
            m_objPrintMultiItemArr[19].m_mthSetPrintValue("", "婚姻史：");
            m_objPrintMultiItemArr[19].m_mthSetPrintValue(new string[] { "婚姻史>>结婚年龄", "婚姻史>>配偶情况" },
                new string[] { "结婚年龄：$$", "配偶情况："});
            #endregion
            #region 家族史
            m_objPrintMultiItemArr[2].m_mthSetPrintValue("","家族史：");
            m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[] { "家族史>>父", "家族史>>母"},
                new string[] { "父：$$", "\n母：$$" });
            #endregion
            #region 体格检查
            #region 体温
            m_objPrintMultiItemArr[3].m_mthSetSpecialTitleValue("体 格 检 查");
			m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[]{"一般情况>>T","一般情况>>T",
																		 "一般情况>>P","一般情况>>P",
																		 "一般情况>>R","一般情况>>R",
																		 "一般情况>>BP","一般情况>>BP",
                                                                         "一般情况>>BP>>mmHg", "一般情况>>BP>>mmHg",
                                                                         },
                new string[] { "     T：", "#℃", "              P：$$", "#次/分", "              R：$$", "#次/分", "              BP：$$", "#/","$$","#mmHg"});
            #endregion
            #region 一般情况
            m_objPrintMultiItemArr[4].m_mthSetPrintValue("","一般情况：");
            m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[]{"体格检查>>神智","体格检查>>体位","体格检查>>发育","体格检查>>营养",
																		 "体格检查>>面容表情"},
                new string[] {  "神志：$$", "体位：", "发育：", "营养：", "面容：" });
            #endregion
            #region 皮肤
        m_objPrintMultiItemArr[5].m_mthSetPrintValue("", "皮  肤：");
        m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"体格检查>>粘膜","体格检查>>紫绀","体格检查>>黄染","体格检查>>苍白",
																	 "体格检查>>出血点及部位"},
            new string[] { "粘膜：$$", "紫绀(十一)：", "黄染(十一)：", "苍白(十一)：", "出血点及部位：" });
            #endregion
            #region 淋巴结
        m_objPrintMultiItemArr[6].m_mthSetPrintValue("", "淋巴结：");
        m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"体格检查>>淋巴结"},
            new string[] { "全身浅表淋巴结：" });
        #endregion
            #region 头部
        m_objPrintMultiItemArr[7].m_mthSetPrintValue("", "头  部：");
        m_objPrintMultiItemArr[7].m_mthSetPrintValue(new string[]{"体格检查>>头颅","体格检查>>眼","体格检查>>瞳孔","体格检查>>耳","体格检查>>鼻",
																	 "体格检查>>唇","体格检查>>咽","体格检查>>舌","体格检查>>齿","体格检查>>扁桃体"},
            new string[] { "头颅：$$", "眼：", "瞳孔：", "耳：", "鼻：","唇：","咽：","舌：","齿：","扁桃体：" });
        #endregion
            #region 颈部
        m_objPrintMultiItemArr[8].m_mthSetPrintValue("", "颈  部：");
        m_objPrintMultiItemArr[8].m_mthSetPrintValue(new string[]{"体格检查>>气管","体格检查>>颈抵抗","体格检查>>颈静脉怒张","体格检查>>肝颈征",
																	 "体格检查>>颈动脉搏动","体格检查>>血管杂音","体格检查>>甲状腺"},
            new string[] { "气管：$$", "颈抵抗(十一)：", "颈静脉怒张(十一)：", "肝颈征(十一)：", "颈动脉搏动：", "血管杂音：", "甲状腺：" });
            #endregion
            #region 胸部
        m_objPrintMultiItemArr[9].m_mthSetPrintValue("", "胸  部：");
        m_objPrintMultiItemArr[9].m_mthSetPrintValue(new string[]{"体格检查>>胸部","体格检查>>肺脏","体格检查>>心脏","胸部>>其他"},
            new string[] { "胸廓：$$", "\n    肺：$$", "\n    心：$$", "\n其他：$$"});
        #endregion
            #region 腹部
        m_objPrintMultiItemArr[10].m_mthSetPrintValue("", "腹  部：");
        m_objPrintMultiItemArr[10].m_mthSetPrintValue(new string[]{"体格检查>>腹形","体格检查>>柔软度","体格检查>>压痛","体格检查>>反跳痛",
																	 "体格检查>>腹水征","体格检查>>肝","体格检查>>胆囊","体格检查>>脾","体格检查>>肾",
                                                   "体格检查>>输尿管","体格检查>>腹部肿块","体格检查>>腹部血管搏动","体格检查>>血管杂音","体格检查>>肠鸣","腹部>>其他" },
            new string[] { "腹形：$$", "柔软度：", "压痛：", "反跳痛：", "腹水征(十一)：", "肝：", "胆囊：", "脾：", "肾：", "输尿管：",
                            "腹部肿块：","腹部血管搏动：","血管杂音：","肠鸣：","其他："});
        #endregion
            #region 肛门及外生殖器
        m_objPrintMultiItemArr[11].m_mthSetPrintValue("", "肛门及外生殖器：");
        m_objPrintMultiItemArr[11].m_mthSetPrintValue(new string[]{"体格检查>>肛门及外生殖器"},
            new string[] { "" });
           #endregion
            #region 脊柱、四肢
        m_objPrintMultiItemArr[12].m_mthSetPrintValue("", "脊柱、四肢：");
        m_objPrintMultiItemArr[12].m_mthSetPrintValue(new string[]{"体格检查>>杵状指","体格检查>>下肢浮肿","体格检查>>肌张力","体格检查>>肌力",
																	 "体格检查>>肌力","体格检查>>关节","体格检查>>肢体畸形"},
            new string[] { "杵状指/趾(十一)：$$", "下肢浮肿(十一)：", "肌张力：", "肌力：", "#级$$","关节：","肢体畸形：" });
        #endregion
            #region 神经反射
        m_objPrintMultiItemArr[13].m_mthSetPrintValue("", "神经反射：");
        m_objPrintMultiItemArr[13].m_mthSetPrintValue(new string[] { "体格检查>>神经反射" },
            new string[] { "" });
        #endregion
            #region 视诊
        m_objPrintMultiItemArr[14].m_mthSetPrintValue("", "视  诊：");
        m_objPrintMultiItemArr[14].m_mthSetPrintValue(new string[]{"体格检查>>心前区隆起","体格检查>>心尖搏动位置","体格检查>>其他部位搏动"},
            new string[] { "心前区隆起(十一)：$$", "心尖搏动位置：", "\n其他部位搏动：$$" });
        #endregion
            #region 触诊
        m_objPrintMultiItemArr[15].m_mthSetPrintValue("", "触  诊：");
        m_objPrintMultiItemArr[15].m_mthSetPrintValue(new string[] { "触诊>>心尖搏动位置", "体格检查>>抬举性搏动", "体格检查>>震颤位置", "体格检查>>时期", "体格检查>>心包摩擦感", "触诊>>时期" },
            new string[] { "心尖搏动位置：$$", "抬举性搏动：", "\n震颤位置：$$","时期：","\n心包摩擦感(十一)位置：$$","时期：" });
        #endregion
            #region 听诊
        m_objPrintMultiItemArr[16].m_mthSetPrintValue("", "听  诊：");
        m_objPrintMultiItemArr[16].m_mthSetPrintValue(new string[] { "体格检查>>心率", "体格检查>>心率","体格检查>>心律", "体格检查>>第一音", //4
            "体格检查>>第一音>>响度", "体格检查>>第二音", "体格检查>>第二音>>响度","体格检查>>第二音>>分裂",//9
            "体格检查>>第三音","体格检查>>第三音>>性质","体格检查>>第四音","体格检查>>第四音>>开瓣音","体格检查>>奔马律",//15
            "体格检查>>奔马律>>期","体格检查>>喀喇音>>部位","体格检查>>喀喇音>>期","体格检查>>喀喇音>>性质","体格检查>>二尖瓣区>>收缩期",//20
            "体格检查>>二尖瓣区>>性质","体格检查>>二尖瓣区>>方向","体格检查>>二尖瓣区>>方向","体格检查>>二尖瓣区>>舒张期","体格检查>>二尖瓣区>>性质1","体格检查>>二尖瓣区>>方向2","体格检查>>二尖瓣区>>方向2",//27
            "体格检查>>主动脉瓣区>>收缩期","体格检查>>主动脉瓣区>>性质","体格检查>>主动脉瓣区>>方向","体格检查>>主动脉瓣区>>方向","体格检查>>主动脉瓣区>>舒张期","体格检查>>主动脉瓣区>>性质1",//33
            "体格检查>>主动脉瓣区>>方向1","体格检查>>主动脉瓣区>>方向1","体格检查>>肺动脉瓣区","体格检查>>三尖瓣区","体格检查>>胸骨左缘","体格检查>>胸骨左缘>>时间及性质","体格检查>>心包摩擦音" },//40
            new string[] { "心率：$$", "#次/分$$","心律：", "\n心音：第一音：$$", "区，响度：$$", "\n            第二音：", "区，响度：A2($$",")P2，分裂：$$",//8
                "\n            第三音：$$","区，性质：$$","\n            第四音：$$","区，开瓣音(十一)：$$","\n            奔马律：$$","区，$$","期，喀喇音：$$",//17
            "部位，$$","期，性质：$$","\n杂音：二尖瓣区：收缩期：$$","级，性质：$$","向","#传导$$","\n                                 舒张期：$$","级，性质$$","向","#传导$$",//27
            "\n        主动脉瓣区：收缩期：$$","级，性质：$$","向","#传导$$","\n                                 舒张期：$$","级，性质：$$","向","#传导$$","\n            肺动脉区：$$","\n            三尖瓣区：$$","\n   胸骨左缘第$$",//38
            "肋间，时期及性质：$$","\n  心包摩擦音(十一)：$$"});
            #endregion
            #region 周围血管征
            m_objPrintMultiItemArr[17].m_mthSetPrintValue("", "周围血管征：");
            m_objPrintMultiItemArr[17].m_mthSetPrintValue(new string[] { "体格检查>>毛细血管搏动征", "体格检查>>水冲脉", "体格检查>>枪击音", "体格检查>>脉搏短拙", "体格检查>>奇脉", "体格检查>>毛细血管征>>其他" },
                new string[] { "毛细血管搏动征：$$", "水冲脉：", "枪击音：", "脉搏短拙：", "奇脉：", "\n其他：" });
            #endregion
            #region 月经生育史
            m_objPrintMultiItemArr[18].m_mthSetPrintValue("", "月经生育史：");
            m_objPrintMultiItemArr[18].m_mthSetPrintValue(new string[] { "体格检查>>月经生育史" },
                new string[] { "" });
            #endregion
            #region 叩诊
            m_objPrintMultiItemArr[20].m_mthSetPrintValue("", "叩  诊：相对浊音界(如右图)");
            #endregion
			#endregion
            #region 签名和日期
            string strDoctor = "";
            string strDirectorDoctor = "";
            if (m_hasItems != null)
            {
                if (m_hasItems.Contains("医师"))
                {
                    strDoctor = "医师：" + ((clsInpatMedRec_Item)m_hasItems["医师"]).m_strItemContent + "\n" + ((clsInpatMedRec_Item)m_hasItems["医师签名日期"]).m_strItemContent;
                } if (m_hasItems.Contains("主任医师"))
                {
                    strDirectorDoctor = "主任或主治医师：" + ((clsInpatMedRec_Item)m_hasItems["主任医师"]).m_strItemContent + "\n" + ((clsInpatMedRec_Item)m_hasItems["主任医师签名日期"]).m_strItemContent;
                }
            }
            m_objPrintMultiItemArr[21].m_mthSetPrintValue("", strDoctor);
            m_objPrintMultiItemArr[22].m_mthSetPrintValue("", strDirectorDoctor);
            //m_objPrintSignArr[0].m_mthSetPrintSignValue(new string[] { "医师", "医师签名日期", "主任医师", "主任医师签名日期" }, new string[] { "医师：", "签名日期：","主任或主治医师：","签名日期：" });
            
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
            private int intLine = 0;
            private int intOffSetX = 70;
            private int intOffSetWidth = 0;
            private int m_intLineYPos = 0;
            
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
                        if (m_strTitle == "视  诊：")
                        {
                            m_intLineYPos = p_intPosY;
                            m_mthDrawline(p_objGrp, p_fntNormalText);
                        }
                        if (m_objItemContent != null)
                        {
                            p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(m_objItemContent.m_strItemContent, m_objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, true);
                            m_mthAddSign2(m_strTitle, m_objPrintContext.m_ObjModifyUserArr);
                        }
                        else if (m_strText != "")
                        {
                            p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_blnNoPrint == false);
                            m_mthAddSign2(m_strSpecialTitle, m_objPrintContext.m_ObjModifyUserArr);
                        }
                        else if (m_strTitle.IndexOf("医师") >= 0)
                        {
                            p_intPosY += 20;
                            p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, m_intRecBaseX + 500, p_intPosY);
                            p_intPosY += 20;
                        }
                        else
                        {
                            p_objGrp.DrawString(m_strTitle, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                            p_intPosY += 20;
                        }
					}
					else
					{
                        p_intPosY += 20;
						if(m_strSpecialTitle != "")
						{
                            p_objGrp.DrawString(m_strSpecialTitle, clsIMR_HerbalismPrintTool.m_fotItemHead, Brushes.Black, m_intRecBaseX + 300, p_intPosY);
							p_intPosY += 40;
						}
						m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText ,m_strTextXml,m_dtmFirstPrintTime,m_blnNoPrint == false);
						m_mthAddSign2(m_strSpecialTitle,m_objPrintContext.m_ObjModifyUserArr);
					}

					m_blnIsFirstPrint = false;					
				}
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
                    if (m_strTitle != "")
                    {
                        if (m_strTitle == "一般情况：" || m_strTitle == "神经反射：" || m_strTitle == "辅助检查：" || m_strTitle == "初步诊断：")
                        {
                            intOffSetX = 85;
                            intOffSetWidth = -20;
                        }
                        else if (m_strTitle == "肛门及外生殖器：")
                        {
                            intOffSetX = 140;
                            intOffSetWidth = -60;
                        }
                        else if (m_strTitle == "脊柱、四肢：" || m_strTitle == "周围血管征：")
                        {
                            intOffSetX = 105;
                            intOffSetWidth = -40;
                        }
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth + intOffSetWidth, m_intRecBaseX + intOffSetX, p_intPosY, p_objGrp);
                    }
                    else
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    }
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
                intLine = 0;
                intOffSetX = 70;
                intOffSetWidth = 0;
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
            /// <summary>
            /// 打印叩诊
            /// </summary>
            /// <param name="p_objGrp"></param>
            /// <param name="p_fntNormalText"></param>
            private void m_mthDrawline(System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                clsInpatMedRec_Item[] objItemContentArr = null;
                clsInpatMedRec_Item objItemContent = null;
                objItemContentArr = m_objGetContentFromItemArr(new string[]{"叩诊>>左1","叩诊>>左2","叩诊>>左3","叩诊>>左4"
																		   ,"叩诊>>左5","叩诊>>右1","叩诊>>右2","叩诊>>右3"
																		   ,"叩诊>>右4","叩诊>>右5"});
                if (objItemContentArr != null)
                {
                    #region 打印心电图表
                    p_objGrp.DrawLine(Pens.Black, 625, m_intLineYPos + 20, 775, m_intLineYPos + 20);
                    p_objGrp.DrawString((objItemContentArr[0] == null ? "" : (objItemContentArr[0].m_strItemContent == null ? "" : objItemContentArr[0].m_strItemContent)), p_fntNormalText, Brushes.Black, 625, m_intLineYPos + 22);
                    p_objGrp.DrawString("Ⅱ", p_fntNormalText, Brushes.Black, 687, m_intLineYPos + 22);
                    p_objGrp.DrawString((objItemContentArr[1] == null ? "" : (objItemContentArr[1].m_strItemContent == null ? "" : objItemContentArr[1].m_strItemContent)), p_fntNormalText, Brushes.Black, 716, m_intLineYPos + 22);

                    p_objGrp.DrawLine(Pens.Black, 625, m_intLineYPos + 40, 775, m_intLineYPos + 40);
                    p_objGrp.DrawString((objItemContentArr[2] == null ? "" : (objItemContentArr[2].m_strItemContent == null ? "" : objItemContentArr[2].m_strItemContent)), p_fntNormalText, Brushes.Black, 625, m_intLineYPos + 42);
                    p_objGrp.DrawString("Ⅲ", p_fntNormalText, Brushes.Black, 687, m_intLineYPos + 42);
                    p_objGrp.DrawString((objItemContentArr[3] == null ? "" : (objItemContentArr[3].m_strItemContent == null ? "" : objItemContentArr[3].m_strItemContent)), p_fntNormalText, Brushes.Black, 716, m_intLineYPos + 42);

                    p_objGrp.DrawLine(Pens.Black, 625, m_intLineYPos + 60, 775, m_intLineYPos + 60);
                    p_objGrp.DrawString((objItemContentArr[4] == null ? "" : (objItemContentArr[4].m_strItemContent == null ? "" : objItemContentArr[4].m_strItemContent)), p_fntNormalText, Brushes.Black, 625, m_intLineYPos + 62);
                    p_objGrp.DrawString("Ⅳ", p_fntNormalText, Brushes.Black, 687, m_intLineYPos + 62);
                    p_objGrp.DrawString((objItemContentArr[5] == null ? "" : (objItemContentArr[5].m_strItemContent == null ? "" : objItemContentArr[5].m_strItemContent)), p_fntNormalText, Brushes.Black, 716, m_intLineYPos + 62);

                    p_objGrp.DrawLine(Pens.Black, 625, m_intLineYPos + 80, 775, m_intLineYPos + 80);
                    p_objGrp.DrawString((objItemContentArr[6] == null ? "" : (objItemContentArr[6].m_strItemContent == null ? "" : objItemContentArr[6].m_strItemContent)), p_fntNormalText, Brushes.Black, 625, m_intLineYPos + 82);
                    p_objGrp.DrawString("Ⅴ", p_fntNormalText, Brushes.Black, 687, m_intLineYPos + 82);
                    p_objGrp.DrawString((objItemContentArr[7] == null ? "" : (objItemContentArr[7].m_strItemContent == null ? "" : objItemContentArr[7].m_strItemContent)), p_fntNormalText, Brushes.Black, 716, m_intLineYPos + 82);

                    p_objGrp.DrawLine(Pens.Black, 625, m_intLineYPos + 100, 775, m_intLineYPos + 100);
                    p_objGrp.DrawString((objItemContentArr[8] == null ? "" : (objItemContentArr[8].m_strItemContent == null ? "" : objItemContentArr[8].m_strItemContent)), p_fntNormalText, Brushes.Black, 625, m_intLineYPos + 102);
                    p_objGrp.DrawString("Ⅵ", p_fntNormalText, Brushes.Black, 687, m_intLineYPos + 102);
                    p_objGrp.DrawString((objItemContentArr[9] == null ? "" : (objItemContentArr[9].m_strItemContent == null ? "" : objItemContentArr[9].m_strItemContent)), p_fntNormalText, Brushes.Black, 716, m_intLineYPos + 102);

                    p_objGrp.DrawLine(Pens.Black, 625, m_intLineYPos + 120, 775, m_intLineYPos + 120);
                    p_objGrp.DrawLine(Pens.Black, 685, m_intLineYPos + 20, 685, m_intLineYPos + 120);
                    p_objGrp.DrawLine(Pens.Black, 715, m_intLineYPos + 20, 715, m_intLineYPos + 120);

                    if (m_hasItems != null)
                        if (m_hasItems.Contains("体格检查>>第二音>>锁骨中线"))
                            objItemContent = m_hasItems["体格检查>>第二音>>锁骨中线"] as clsInpatMedRec_Item;
                    p_objGrp.DrawString(objItemContent == null ? "" : "锁骨中线距前正中线" + objItemContent.m_strItemContent + "cm",new Font("Simsun",9.5f), Brushes.Black, 620, m_intLineYPos + 130);
                    #endregion
                }
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
				p_intPosY += 20;
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
 	}

}