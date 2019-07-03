using System;
using System.IO;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;
using System.Windows.Forms;

namespace iCare 
{
	/// <summary>
	/// 佛二引产记录单打印工具类.
	/// </summary>
	public class clsIMR_InducedLaborRecordPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_InducedLaborRecordPrintTool(string p_strTypeID) :base(p_strTypeID)
		{}


		private clsPrintInPatMedRecItem[] m_objPrintMultiItemArr;
		private clsPrintInPatMedRecSign[] m_objPrintSignArr;
       
	
		protected override void m_mthSetPrintLineArr()
		{

			m_mthInitPrintLineArr();
			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
										  new clsPrintPatientFixInfo("引 产 记 录 表",320),
                                          m_objPrintMultiItemArr[0],m_objPrintMultiItemArr[1],m_objPrintMultiItemArr[2],
                                          m_objPrintMultiItemArr[3],m_objPrintMultiItemArr[4],
                                          new clsPrintAmniotomyOdinopoeiaRecord(),
                                          m_objPrintMultiItemArr[5],
                                          new clsPrintDrugOdinopoeiaRecord(),
                                          m_objPrintMultiItemArr[6]
									  });
		}
	
		private void m_mthInitPrintLineArr()
		{
			m_objPrintMultiItemArr = new clsPrintInPatMedRecItem[7];
			for(int j2=0;j2<m_objPrintMultiItemArr.Length;j2++)
				m_objPrintMultiItemArr[j2] = new clsPrintInPatMedRecItem();
		}

        protected override void m_mthSetSubPrintInfo()
        {
            #region 主诉-体检
            m_objPrintMultiItemArr[0].m_mthSetPrintValue(new string[] { "","主诉>>停经","主诉>>停经","主诉>>哺乳期","主诉>>哺乳期","",
                "主诉>>戴环受孕>>是","主诉>>戴环受孕>>否"},
                new string[] { "主诉：", "停经：$$", "#月，$$", "哺乳期：$$", "#月，$$", "戴环受孕：$$", "#是$$", "#否$$" });
            m_objPrintMultiItemArr[1].m_mthSetPrintValue(new string[] { "","本孕情况>>末次月经","本孕情况>>胎动时间","",
                "本孕情况>>阴道出血>>有","本孕情况>>阴道出血>>无"},
                new string[] { "本孕情况：$$", "末次月经：$$", "，胎动时间：$$", "，阴道出血：$$", "#有$$", "#无$$" });
            m_objPrintMultiItemArr[2].m_mthSetPrintValue(new string[] { "","生育史>>孕","生育史>>孕","生育史>>产","生育史>>产","生育史>>年前","生育史>>年前","",
                "生育史>>男","生育史>>男","生育史>>女","生育史>>女"},
                new string[] { "生育史：", "孕$$", "#次$$", "产", "#次$$", "末次产", "#年前$$", "现有", "$$", "#男$$", "$$", "#女$$" });
            m_objPrintMultiItemArr[3].m_mthSetPrintValue(new string[] { "","过去史>>心脏病","过去史>>肾炎","过出史>>高血压",
                "过去史>>肝炎","过去史>>出血性疾病","过去史>>过敏性疾病","过去史>>其他"},
                new string[] { "过去史：", "心脏病：$$", "肾炎：", "高血压：", "肝炎：", "出血性疾病：", "过敏性疾病：", "其他：" });
            m_objPrintMultiItemArr[4].m_mthSetPrintValue(new string[] { "","体检>>皮肤>>斑","体检>>皮肤>>疹","体检>>心",
                "体检>>肺","体检>>肝","体检>>脾","","体检>>子宫底","体检>>腹围","体检>>腹围","体检>>腹围","体检>>胎位","体检>>胎心胎心仪盆测","体检>>诊断"},
                new string[] { "\n体检：皮肤：", "#斑$$", "#疹$$", "心：", "肺：", "肝：","脾：", "子宫底 X 腹围：", "$$", "#X$$","$$", "#公分$$", "胎位：", "胎心+胎心仪+盆测：", "诊断：" }); 
            #endregion
            #region 雷诺尔-记录
            m_objPrintMultiItemArr[5].m_mthSetPrintValue(new string[]{"羊膜腔穿刺引产术记录>>雷诺尔","羊膜腔穿刺引产术记录>>雷诺尔","",
				"羊膜腔穿刺引产术记录>>术后血压1","羊膜腔穿刺引产术记录>>术后血压2","羊膜腔穿刺引产术记录>>术后血压2","","羊膜腔穿刺引产术记录>>记录"},
                new string[] { "\n0.5%雷诺尔", "#毫升羊膜腔注入$$", "术后血压：", "$$", "#/$$", "$$","kPa$$", "记录：" });
            #endregion
            #region 产后血压-备注
            m_objPrintMultiItemArr[6].m_mthSetPrintValue(new string[]{"","分娩情况>>产后血压1","分娩情况>>产后血压2","分娩情况>>产后血压2",
                "","分娩情况>>产后用药","","分娩情况>>接生者","","分娩情况>>胎长","分娩情况>>胎长","","分娩情况>>胎重","分娩情况>>胎重",
                "","分娩情况>>性别","备注","","签名"},
               new string[] { "\n产后血压：", "$$", "#/$$", "$$", "kPa，产后用药：麦角、催产素、$$", "$$", "接生者：", "$$", "胎长：","$$", "#厘米$$",
                                "胎重：" ,"$$","#kg$$","性别：","$$","\n备注：","\n\n                                                                                                          签名：$$","$$"});
            #endregion

        }
	#region Print Class
        /// <summary>
        /// 打印边
        /// </summary>
        /// <param name="e"></param>
        protected override void m_mthPrintHeader(System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 40, 165, 710, clsPrintPosition.c_intBottomY - 230);
        }
        /// <summary>
        /// 标题文字部分
        /// </summary>
        /// <param name="e"></param>
        protected override  void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            SolidBrush  m_slbBrush = new SolidBrush(Color.Black);
            Font m_fotSmallFont = new Font("SimSun", 12); 
            //医院名称
            e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle.Trim(), new Font("SimSun", 15), m_slbBrush, 300,50);
            //表单名称
            e.Graphics.DrawString(m_strChildTitleName, new Font("SimSun",18,FontStyle.Bold), Brushes.Black, 300,90);

            e.Graphics.DrawString("病区：", m_fotSmallFont, m_slbBrush, 80,135);

            e.Graphics.DrawString(m_objPrintInfo.m_strAreaName, m_fotSmallFont, m_slbBrush, 130,135);

            e.Graphics.DrawString("床号：", m_fotSmallFont, m_slbBrush, 300,135);

            e.Graphics.DrawString(m_objPrintInfo.m_strBedName, m_fotSmallFont, m_slbBrush, 350,135);

            e.Graphics.DrawString("住院号：", m_fotSmallFont, m_slbBrush, 450,135);

            e.Graphics.DrawString(m_objPrintInfo.m_strHISInPatientID, m_fotSmallFont, m_slbBrush, 515,135);
        }
        /// <summary>
        /// 姓名年龄婚否
        /// </summary>
        private class clsPrintPatientFixInfo : clsIMR_PrintLineBase
        {
            public clsPrintPatientFixInfo() { }
            public clsPrintPatientFixInfo(string p_strChildTitleName, int p_intChildTitleNameOffSetX)
            {
                m_strChildTitleName = p_strChildTitleName;
                m_intChildTitleNameOffSetX = p_intChildTitleNameOffSetX;

            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                p_intPosY -= 30;
                Font m_fotSmallFont = new Font("SimSun", 10.5f);
                p_objGrp.DrawString("姓名：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strPatientName), m_fotSmallFont, Brushes.Black, m_intPatientInfoX - 20, p_intPosY);
                p_objGrp.DrawString("年龄：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strAge), m_fotSmallFont, Brushes.Black, m_intPatientInfoX + 150, p_intPosY);
                p_objGrp.DrawString("婚否：" + (m_objPrintInfo == null ? "" : m_objPrintInfo.m_strMarried), m_fotSmallFont, Brushes.Black, m_intPatientInfoX + 300, p_intPosY);
                p_intPosY += 20;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 羊膜腔穿刺引产术记录
        /// </summary>
        private class  clsPrintAmniotomyOdinopoeiaRecord: clsIMR_PrintLineBase
        {
            public clsPrintAmniotomyOdinopoeiaRecord() { }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strFirstPiqureTime = "";//穿刺时间1
                string m_strFirstPiqurePubes = "";//耻骨上1
                string m_strFirstPiqureSideOpen = "";//左、右旁开1
                string m_strFirstPiqureSucceed = "";//穿刺多少次成功1
                string m_strFirstPiqureOperator = "";//术者1
                string m_strSecondPiqureTime = "";//穿刺时间2
                string m_strSecondPiqurePubes = "";//耻骨上2
                string m_strSecondPiqureSideOpen = "";//左、右旁开2
                string m_strSecondPiqureSucceed = "";//穿刺多少次成功2
                string m_strSecondPiqureOperator = "";//术者2
                #region 
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第一次穿刺时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第一次穿刺时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFirstPiqureTime = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第一次穿刺>>耻骨上"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第一次穿刺>>耻骨上"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFirstPiqurePubes = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第一次穿刺>>左、右旁开"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第一次穿刺>>左、右旁开"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFirstPiqureSideOpen = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第一次穿刺>>穿刺多少次成功"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第一次穿刺>>穿刺多少次成功"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFirstPiqureSucceed = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第一次穿刺>>术者"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第一次穿刺>>术者"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFirstPiqureOperator = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第二次穿刺时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第二次穿刺时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strSecondPiqureTime = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第二次穿刺>>耻骨上"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第二次穿刺>>耻骨上"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strSecondPiqurePubes = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第二次穿刺>>左、右旁开"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第二次穿刺>>左、右旁开"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strSecondPiqureSideOpen = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第二次穿刺>>穿刺多少次成功"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第二次穿刺>>穿刺多少次成功"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strSecondPiqureSucceed = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("羊膜腔穿刺引产术记录>>第二次穿刺>>术者"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["羊膜腔穿刺引产术记录>>第二次穿刺>>术者"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strSecondPiqureOperator = objInpatItem.m_strItemContent;
                        }
                    }
                }
#endregion
                p_intPosY += 15;
                p_objGrp.DrawString("羊膜腔穿刺引产术记录" , p_fntNormalText, Brushes.Black, m_intPatientInfoX -10, p_intPosY);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 20, 736, p_intPosY + 20);//横1
                p_objGrp.DrawString("穿刺次数", new Font("SimSun", 10), Brushes.Black, m_intPatientInfoX - 13, p_intPosY + 24);
                p_objGrp.DrawString("时间(年、月、日、时、分)", new Font("SimSun",10), Brushes.Black, m_intPatientInfoX + 65, p_intPosY + 24);
                p_objGrp.DrawString("耻骨上：厘米", new Font("SimSun", 10), Brushes.Black, m_intPatientInfoX + 245, p_intPosY + 24);
                p_objGrp.DrawString("左、右旁开：厘米", new Font("SimSun", 10), Brushes.Black, m_intPatientInfoX + 338, p_intPosY + 24);
                p_objGrp.DrawString("穿刺多少次成功", new Font("SimSun", 10), Brushes.Black, m_intPatientInfoX + 455, p_intPosY + 24);
                p_objGrp.DrawString("术  者", new Font("SimSun", 10), Brushes.Black, m_intPatientInfoX + 588, p_intPosY + 24);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 44, 736, p_intPosY + 44);//横2
                p_objGrp.DrawString("第一次穿刺", new Font("SimSun",10), Brushes.Black, m_intPatientInfoX -16, p_intPosY + 48);
                p_objGrp.DrawString(m_strFirstPiqureTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 65, p_intPosY + 48);
                p_objGrp.DrawString(m_strFirstPiqurePubes, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 250, p_intPosY + 48);
                p_objGrp.DrawString(m_strFirstPiqureSideOpen, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 340, p_intPosY + 48);
                p_objGrp.DrawString(m_strFirstPiqureSucceed, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 455, p_intPosY + 48);
                p_objGrp.DrawString(m_strFirstPiqureOperator, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 565, p_intPosY + 48);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 68, 736, p_intPosY + 68);//横3
                p_objGrp.DrawString("第二次穿刺", new Font("SimSun", 10), Brushes.Black, m_intPatientInfoX - 16, p_intPosY + 72);
                p_objGrp.DrawString(m_strSecondPiqureTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 65, p_intPosY + 72);
                p_objGrp.DrawString(m_strSecondPiqurePubes, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 250, p_intPosY + 72);
                p_objGrp.DrawString(m_strSecondPiqureSideOpen, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 340, p_intPosY + 72);
                p_objGrp.DrawString(m_strSecondPiqureSucceed, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 455, p_intPosY + 72);
                p_objGrp.DrawString(m_strSecondPiqureOperator, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 565, p_intPosY + 72);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 92, 736, p_intPosY + 92);//横4
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20,p_intPosY + 20, m_intPatientInfoX - 20, p_intPosY + 92);//竖1
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 57, p_intPosY + 20,m_intPatientInfoX + 57, p_intPosY + 92);//竖2
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 242, p_intPosY + 20, m_intPatientInfoX + 242, p_intPosY + 92);//竖3
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 336, p_intPosY + 20, m_intPatientInfoX + 336, p_intPosY + 92);//竖4
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 450, p_intPosY + 20, m_intPatientInfoX + 450, p_intPosY + 92);//竖5
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 558, p_intPosY + 20, m_intPatientInfoX + 558, p_intPosY + 92);//竖6
                p_objGrp.DrawLine(Pens.Black, 736, p_intPosY + 20, 736, p_intPosY + 92);//竖7
                p_intPosY += 112;
                m_blnHaveMoreLine = false;
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
        }
        /// <summary>
        /// 药物引产记录、分娩情况
        /// </summary>
        private class clsPrintDrugOdinopoeiaRecord : clsIMR_PrintLineBase
        {
            public clsPrintDrugOdinopoeiaRecord() { }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strOdinopoeiaDrug1 = "";//引产用药1
                string m_strOdinopoeiaTime1 = "";//时间1
                string m_strAdministrationWay1 = "";//给药途径1
                string m_strOdinopoeiaRecord1 = "";//记录1
                string m_strOdinopoeiaDrug2 = "";//引产用药2
                string m_strOdinopoeiaTime2 = "";//时间2
                string m_strAdministrationWay2 = "";//给药途径2
                string m_strOdinopoeiaRecord2 = "";//记录2

                string m_strAfterOperationDate1 = "";//术后日期1
                string m_strBloodPressure1 = "";//血压1
                string m_strPalace1 = "";//宫缩1
                string m_strQuickening1 = "";//胎动1
                string m_strFetusHeart1 = "";//胎心1
                string m_strVaginaSecretion1 = "";//阴道分泌物1
                string m_strOther1 = "";//其他1
                string m_strOperator1 = "";//记录者1
                string m_strAfterOperationDate2 = "";//术后日期2
                string m_strBloodPressure2 = "";//血压2
                string m_strPalace2 = "";//宫缩2
                string m_strQuickening2 = "";//胎动2
                string m_strFetusHeart2 = "";//胎心2
                string m_strVaginaSecretion2 = "";//阴道分泌物2
                string m_strOther2 = "";//其他2
                string m_strOperator2 = "";//记录者2

                string m_strPalaceBeginTime = "";//宫缩开始时间
                string m_strBreakCoatTime = "";//破膜时间
                string m_strChildBirthTime = "";//胎儿娩出时间
                string m_strMazaBirthTime = "";//胎盘娩出时间
                string m_strRecordTime = "";//记录时间
     
                #region
                if (m_hasItems != null)
                {
                    #region 药物引产记录1
                    if (m_hasItems.Contains("药物引产记录>>引产用药1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>引产用药1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOdinopoeiaDrug1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>时间1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>时间1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOdinopoeiaTime1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>给药途径1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>给药途径1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strAdministrationWay1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>记录1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>记录1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOdinopoeiaRecord1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>引产用药2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>引产用药2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOdinopoeiaDrug2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>时间2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>时间2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOdinopoeiaTime2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>给药途经2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>给药途经2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strAdministrationWay2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("药物引产记录>>记录2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["药物引产记录>>记录2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOdinopoeiaRecord2 = objInpatItem.m_strItemContent;
                        }
                    }
#endregion
                    #region 药物引产记录2
                    if (m_hasItems.Contains("术后日期>>1"))
                     {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["术后日期>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strAfterOperationDate1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("血压>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["血压>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strBloodPressure1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("宫缩>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["宫缩>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strPalace1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("胎动>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["胎动>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strQuickening1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("胎心>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["胎心>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFetusHeart1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("阴道分泌物>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["阴道分泌物>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strVaginaSecretion1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("其他>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["其他>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOther1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("记录者>>1"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["记录者>>1"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOperator1 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("术后日期>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["术后日期>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strAfterOperationDate2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("血压>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["血压>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strBloodPressure2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("宫缩>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["宫缩>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strPalace2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("胎动>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["胎动>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strQuickening2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("胎心>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["胎心>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strFetusHeart2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("阴道分泌物>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["阴道分泌物>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strVaginaSecretion2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("其他>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["其他>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOther2 = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("记录者>>2"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["记录者>>2"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strOperator2 = objInpatItem.m_strItemContent;
                        }
                    }
#endregion
                    #region 分娩情况
                    if (m_hasItems.Contains("分娩情况>>宫缩开始时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>宫缩开始时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strPalaceBeginTime = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("分娩情况>>破膜时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>破膜时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strBreakCoatTime = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("分娩情况>>胎儿娩出时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>胎儿娩出时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strChildBirthTime = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("分娩情况>>胎盘娩出时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>胎盘娩出时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strMazaBirthTime = objInpatItem.m_strItemContent;
                        }
                    }
                    if (m_hasItems.Contains("分娩情况>>记录时间"))
                    {
                        clsInpatMedRec_Item objInpatItem = m_hasItems["分娩情况>>记录时间"] as clsInpatMedRec_Item;
                        if (objInpatItem != null)
                        {
                            m_strRecordTime = objInpatItem.m_strItemContent;
                        }
                    }
                    #endregion
                }
                #endregion
                #region 药物引产记录1
                p_intPosY += 10;
                p_objGrp.DrawString("药物引产记录", p_fntNormalText, Brushes.Black, m_intPatientInfoX -10, p_intPosY);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 20, 736, p_intPosY + 20);//横1
                p_objGrp.DrawString("引产用药", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 15, p_intPosY + 24);
                p_objGrp.DrawString("时间", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 200, p_intPosY + 24);
                p_objGrp.DrawString("给药途径", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 383, p_intPosY + 24);
                p_objGrp.DrawString("记 录", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 587, p_intPosY + 24);

                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 44, 736, p_intPosY + 44);//横2
                p_objGrp.DrawString(m_strOdinopoeiaDrug1, p_fntNormalText, Brushes.Black, m_intPatientInfoX -10, p_intPosY + 48);
                p_objGrp.DrawString(m_strOdinopoeiaTime1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 150, p_intPosY + 48);
                p_objGrp.DrawString(m_strAdministrationWay1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY + 48);
                p_objGrp.DrawString(m_strOdinopoeiaRecord1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 563, p_intPosY + 48);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 68, 736, p_intPosY + 68);//横3
                p_objGrp.DrawString(m_strOdinopoeiaDrug2, p_fntNormalText, Brushes.Black, m_intPatientInfoX -10, p_intPosY + 72);
                p_objGrp.DrawString(m_strOdinopoeiaTime2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 150, p_intPosY + 72);
                p_objGrp.DrawString(m_strAdministrationWay2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 300, p_intPosY + 72);
                p_objGrp.DrawString(m_strOdinopoeiaRecord2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 563, p_intPosY + 72);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 92, 736, p_intPosY + 92);//横4
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 20, m_intPatientInfoX - 20, p_intPosY + 92);//竖1
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 150, p_intPosY + 20, m_intPatientInfoX + 150, p_intPosY + 92);//竖2
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 300, p_intPosY + 20, m_intPatientInfoX + 300, p_intPosY + 92);//竖3
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 550, p_intPosY + 20, m_intPatientInfoX + 550, p_intPosY + 92);//竖4
                p_objGrp.DrawLine(Pens.Black,  736, p_intPosY + 20,  736, p_intPosY + 92);//竖5
                p_intPosY +=  106;
                #endregion
                #region 药物引产记录2
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 20, 736, p_intPosY + 20);//横1
                p_objGrp.DrawString("术后日期", p_fntNormalText, Brushes.Black, m_intPatientInfoX -10, p_intPosY + 24);
                p_objGrp.DrawString("血压：kPa", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 85, p_intPosY + 24);
                p_objGrp.DrawString("宫缩", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 190, p_intPosY + 24);
                p_objGrp.DrawString("胎动", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 255, p_intPosY + 24);
                p_objGrp.DrawString("胎心", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 315, p_intPosY + 24);
                p_objGrp.DrawString("阴道分泌物", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 385, p_intPosY + 24);
                p_objGrp.DrawString("其他", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 518 , p_intPosY + 24);
                p_objGrp.DrawString("记录者", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 595, p_intPosY + 24);

                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 44, 736, p_intPosY + 44);//横2
                p_objGrp.DrawString(m_strAfterOperationDate1, p_fntNormalText, Brushes.Black, m_intPatientInfoX - 10, p_intPosY + 48);
                p_objGrp.DrawString(m_strBloodPressure1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 90, p_intPosY + 48);
                p_objGrp.DrawString(m_strPalace1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 190, p_intPosY + 48);
                p_objGrp.DrawString(m_strQuickening1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 255, p_intPosY + 48);
                p_objGrp.DrawString(m_strFetusHeart1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 315, p_intPosY + 48);
                p_objGrp.DrawString(m_strVaginaSecretion1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 375, p_intPosY + 48);
                p_objGrp.DrawString(m_strOther1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 505, p_intPosY + 48);
                p_objGrp.DrawString(m_strOperator1, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 595, p_intPosY + 48);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 68, 736, p_intPosY + 68);//横3
                p_objGrp.DrawString(m_strAfterOperationDate2, p_fntNormalText, Brushes.Black, m_intPatientInfoX - 10, p_intPosY + 72);
                p_objGrp.DrawString(m_strBloodPressure2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 90, p_intPosY + 72);
                p_objGrp.DrawString(m_strPalace2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 190, p_intPosY + 72);
                p_objGrp.DrawString(m_strQuickening2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 255, p_intPosY + 72);
                p_objGrp.DrawString(m_strFetusHeart2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 315, p_intPosY + 72);
                p_objGrp.DrawString(m_strVaginaSecretion2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 375, p_intPosY + 72);
                p_objGrp.DrawString(m_strOther2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 505, p_intPosY + 72);
                p_objGrp.DrawString(m_strOperator2, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 595, p_intPosY + 72);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 92, 736, p_intPosY + 92);//横4
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 20, m_intPatientInfoX -20, p_intPosY + 92);//竖1
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 80, p_intPosY + 20, m_intPatientInfoX + 80, p_intPosY + 92);//竖2
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 180, p_intPosY + 20, m_intPatientInfoX + 180, p_intPosY + 92);//竖3
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 243, p_intPosY + 20, m_intPatientInfoX + 243, p_intPosY + 92);//竖4
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 305, p_intPosY + 20, m_intPatientInfoX + 305, p_intPosY + 92);//竖5
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 365, p_intPosY + 20, m_intPatientInfoX + 365, p_intPosY + 92);//横6
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 495, p_intPosY + 20, m_intPatientInfoX + 495, p_intPosY + 92);//竖7
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 585, p_intPosY + 20, m_intPatientInfoX + 585, p_intPosY + 92);//竖8
                p_objGrp.DrawLine(Pens.Black, 736, p_intPosY + 20, 736, p_intPosY + 92);//竖9

                p_intPosY += 116;
                #endregion
                #region 分娩情况
                p_objGrp.DrawString("分娩情况：", p_fntNormalText, Brushes.Black, m_intPatientInfoX -10, p_intPosY);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 20, 736, p_intPosY + 20);//横1
                p_objGrp.DrawString("项目", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 15, p_intPosY + 24);
                p_objGrp.DrawString("宫缩开始", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 100, p_intPosY + 24);
                p_objGrp.DrawString("破膜", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 193, p_intPosY + 24);
                p_objGrp.DrawString("胎儿娩出", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 250, p_intPosY + 24);
                p_objGrp.DrawString("胎盘娩出：自然娩出或徒手剥离", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 332, p_intPosY + 24);
                p_objGrp.DrawString("记 录", p_fntNormalText, Brushes.Black, m_intPatientInfoX + 598, p_intPosY + 24);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX -20, p_intPosY + 44, 736, p_intPosY + 44);//横2
                p_objGrp.DrawString("时间 年月日时分", new Font("SimSun", 9), Brushes.Black, m_intPatientInfoX - 15, p_intPosY + 48);
                p_objGrp.DrawString(m_strPalaceBeginTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 103, p_intPosY + 48);
                p_objGrp.DrawString(m_strBreakCoatTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 188, p_intPosY + 48);
                p_objGrp.DrawString(m_strChildBirthTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 255, p_intPosY + 48);
                p_objGrp.DrawString(m_strMazaBirthTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 335, p_intPosY + 48);
                p_objGrp.DrawString(m_strRecordTime, p_fntNormalText, Brushes.Black, m_intPatientInfoX + 595, p_intPosY + 48);
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 68, 736, p_intPosY + 68);//横3
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX - 20, p_intPosY + 20, m_intPatientInfoX - 20, p_intPosY + 68);//竖1
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 95, p_intPosY + 20, m_intPatientInfoX + 95, p_intPosY + 68);//竖2
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 177, p_intPosY + 20, m_intPatientInfoX + 177, p_intPosY + 68);//竖3
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 245, p_intPosY + 20, m_intPatientInfoX + 245, p_intPosY + 68);//竖4
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 325, p_intPosY + 20, m_intPatientInfoX + 325, p_intPosY + 68);//竖5
                p_objGrp.DrawLine(Pens.Black, m_intPatientInfoX + 580, p_intPosY + 20, m_intPatientInfoX + 580, p_intPosY + 68);//竖6
                p_objGrp.DrawLine(Pens.Black,  736, p_intPosY + 20,  736, p_intPosY + 68);//竖7
                p_intPosY += 80;
                m_blnHaveMoreLine = false;
                #endregion
            }

            public override void m_mthReset()
            {
                m_blnHaveMoreLine = true;
            }
        }
		/// <summary>
		/// 项目打印
		/// </summary>
		private class clsPrintInPatMedRecItem : clsIMR_PrintLineBase
		{
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10.5f));

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
				if(m_blnNoContent == true && m_blnNoPrint == true || m_hasItems == null || m_hasItems.Count == 0 || m_objContent == null)
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

                        if (m_blnIsPrintMark)
                        {
                            m_objPrintContext.m_mthSetContextWithCorrectBefore((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml), m_dtmFirstPrintTime, m_objItemContent != null);
                            m_mthAddSign2(m_strTitle, m_objPrintContext.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext.m_mthSetContextWithAllCorrect((m_objItemContent == null ? "" : m_objItemContent.m_strItemContent), (m_objItemContent == null ? "<root />" : m_objItemContent.m_strItemContentXml));
                        }

						
					}
					else
					{
						if(m_strSpecialTitle != "")
						{
							p_intPosY += 20;
							p_objGrp.DrawString(m_strSpecialTitle,clsIMR_HerbalismPrintTool.m_fotItemHead,Brushes.Black,m_intRecBaseX+300,p_intPosY);
							p_intPosY += 40;
						}

                        if (m_blnIsPrintMark)
                        {
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(m_strText, m_strTextXml, m_dtmFirstPrintTime, m_blnNoPrint == false);
                            m_mthAddSign2(m_strSpecialTitle, m_objPrintContext.m_ObjModifyUserArr);

                        }
                        else
                        {
                            m_objPrintContext.m_mthSetContextWithAllCorrect(m_strText, m_strTextXml);
                        }

						
					}

					m_blnIsFirstPrint = false;					
				}
			
				int intLine = 0;
				if(m_objPrintContext.m_BlnHaveNextLine())
				{
					if(m_strTitle != "")
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth-40,m_intRecBaseX+20,p_intPosY,p_objGrp);
					else
						m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 40,m_intRecBaseX+10,p_intPosY,p_objGrp);
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
						p_objGrp.DrawString(m_strTitleArr[i]+(objSignContent[i]==null ? "" : objSignContent[i].m_strItemContent) ,p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
						p_intPosY += 20;
					}
					else
					{
						p_objGrp.DrawString(m_strTitleArr[i]+ (objSignContent[i] == null ? "" :DateTime.Parse( objSignContent[i].m_strItemContent).ToString("yyyy年MM月dd日")),p_fntNormalText,Brushes.Black,m_intRecBaseX+400,p_intPosY);
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
