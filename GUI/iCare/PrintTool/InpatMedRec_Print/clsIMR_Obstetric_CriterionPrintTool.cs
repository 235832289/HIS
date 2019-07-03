using System;
using iCareData;
using System.Collections;
using System.Drawing.Printing;
using com.digitalwave.controls;
using System.Drawing;

namespace iCare
{
	/// <summary>
	/// Summary description for clsIMR_Obstetric_CriterionPrintTool.产科入院记录
	/// </summary>
	public class clsIMR_Obstetric_CriterionPrintTool: clsInpatMedRecPrintBase
	{
		public clsIMR_Obstetric_CriterionPrintTool(string p_strTypeID) :base(p_strTypeID)
		{}


		protected override void m_mthSetPrintLineArr()
		{

			m_objPrintLineContext = new com.digitalwave.Utility.Controls.clsPrintContext(
				new com.digitalwave.Utility.Controls.clsPrintLineBase[]{
                                        new clsPrintPatientFixInfo("产科入院记录",320),
										new clsPrinDetail1(), 
                                        new clsPrinDetail2(),
                                        new clsPrintSubInf(),                   
                                        new clsPrinDetail3(1),                                       
										new clsPrinDetail4(),
                                        new clsPrintHomeHistroy(), 
                                        new clsPrint10(), 
                                        new clsPrint11(),
                                        new clsPrintDate(),
                                        new clsPrintHomeHistroy2(),
                                        new clsPrint12(), 
                                        new clsPrint13(),
                                        new clsPrintLastDate(),
                    new clsPrintInPatMedRecDia2(),
                    new clsPrintInPatMedRecDia3()

			});
		}

		/// <summary>
		/// 孕产史表格打印
		/// </summary>
		private class clsPrintSubInf : clsIMR_PrintLineBase
		{
			/// <summary>
			/// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
			/// </summary>
//			private bool m_blnIsFirstPrint = true;
			private clsInpatMedRec_Item[][] m_objItemArr = new clsInpatMedRec_Item[3][];
			private int m_intYPos = 10;
			private int m_intXPos = (int)enmRectangleInfo.LeftX - 10;
			private int m_intWidth = (int)enmRectangleInfo.LeftX+(int)enmRectangleInfoInPatientCaseInfo.PrintWidth2+21;
			private string[] m_strItemArr1 = {"孕产史>>1>>孕次","孕产史>>1>>年","孕产史>>1>>月","孕产史>>1>>流产>>自然","孕产史>>1>>流产>>人工","孕产史>>1>>引产","孕产史>>1>>死胎","孕产史>>1>>死产","孕产史>>1>>早产","孕产史>>1>>足月产","孕产史>>1>>分娩方式>>顺产","孕产史>>1>>分娩方式>>臀位","孕产史>>1>>分娩方式>>手术方式","孕产史>>1>>分娩方式>>其它","孕产史>>1>>产后情况>>出血","孕产史>>1>>产后情况>>产褥热","孕产史>>1>>合并症或并发症","孕产史>>1>>小孩情况>>性别","孕产史>>1>>小孩情况>>生存","孕产史>>1>>小孩情况>>死 亡>>时间","孕产史>>1>>小孩情况>>死 亡>>原因","孕产史>>1>>小孩情况>>后遗症","孕产史>>1>>出生体重","孕产史>>1>>畸形"};
			private string[] m_strItemArr2 = {"孕产史>>2>>孕次","孕产史>>2>>年","孕产史>>2>>月","孕产史>>2>>流产>>自然","孕产史>>2>>流产>>人工","孕产史>>2>>引产","孕产史>>2>>死胎","孕产史>>2>>死产","孕产史>>2>>早产","孕产史>>2>>足月产","孕产史>>2>>分娩方式>>顺产","孕产史>>2>>分娩方式>>臀位","孕产史>>2>>分娩方式>>手术方式","孕产史>>2>>分娩方式>>其它","孕产史>>2>>产后情况>>出血","孕产史>>2>>产后情况>>产褥热","孕产史>>2>>合并症或并发症","孕产史>>2>>小孩情况>>性别","孕产史>>2>>小孩情况>>生存","孕产史>>2>>小孩情况>>死 亡>>时间","孕产史>>2>>小孩情况>>死 亡>>原因","孕产史>>2>>小孩情况>>后遗症","孕产史>>2>>出生体重","孕产史>>2>>畸形"};
			private string[] m_strItemArr3 = {"孕产史>>3>>孕次","孕产史>>3>>年","孕产史>>3>>月","孕产史>>3>>流产>>自然","孕产史>>3>>流产>>人工","孕产史>>3>>引产","孕产史>>3>>死胎","孕产史>>3>>死产","孕产史>>3>>早产","孕产史>>3>>足月产","孕产史>>3>>分娩方式>>顺产","孕产史>>3>>分娩方式>>臀位","孕产史>>3>>分娩方式>>手术方式","孕产史>>3>>分娩方式>>其它","孕产史>>3>>产后情况>>出血","孕产史>>3>>产后情况>>产褥热","孕产史>>3>>合并症或并发症","孕产史>>3>>小孩情况>>性别","孕产史>>3>>小孩情况>>生存","孕产史>>3>>小孩情况>>死 亡>>时间","孕产史>>3>>小孩情况>>死 亡>>原因","孕产史>>3>>小孩情况>>后遗症","孕产史>>3>>出生体重","孕产史>>3>>畸形"};

			public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
//				if(m_blnHavePrintInfo(m_strItemArr1) == false && m_blnHavePrintInfo(m_strItemArr2) == false && m_blnHavePrintInfo(m_strItemArr3) == false  || m_hasItems == null)
//				{
//					m_blnHaveMoreLine = false;
//					return;
//				}
                m_intYPos = p_intPosY + 25;
				m_objItemArr[0] = m_objGetContentFromItemArr(m_strItemArr1);
				m_objItemArr[1] = m_objGetContentFromItemArr(m_strItemArr2);
				m_objItemArr[2] = m_objGetContentFromItemArr(m_strItemArr3);

               
				m_mthDrawTitle(p_intPosY,p_objGrp, p_fntNormalText);
                m_mthPrintContent(p_intPosY, p_objGrp, this.m_objItemArr);

				p_intPosY+= 245;

				m_blnHaveMoreLine = false;
			}
			public override void m_mthReset()
			{
				m_blnHaveMoreLine = true;
//				m_blnIsFirstPrint = true;
			}
			/// <summary>
			/// 打印标题与网格
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
			private void m_mthDrawTitle(int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
			{
				StringFormat stfTitle = new StringFormat(StringFormatFlags.FitBlackBox);
				int intRowWidth = 30;
				int intRow = 20;
				int intHeight = 200;
                m_intXPos = (int)enmRectangleInfo.LeftX - 10;

				#region Print Titles and Line
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intWidth,m_intYPos);
				p_objGrp.DrawLine(Pens.Black,m_intXPos+intRow,m_intYPos,m_intXPos+intRow,m_intYPos+intHeight);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intHeight,m_intWidth,m_intYPos+intHeight);
				p_objGrp.DrawString(" 孕  产  史",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,intHeight),stfTitle);
				m_intXPos += intRow;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+80,m_intWidth+1,m_intYPos+80);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+120,m_intWidth+1,m_intYPos+120);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+160,m_intWidth+1,m_intYPos+160);

				p_objGrp.DrawString(" 孕  次",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRow;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("   年",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += 36;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("   月",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRow;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("流产",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos+5,m_intYPos+2,40,intRow),stfTitle);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos+60,m_intYPos+intRow);
				p_objGrp.DrawString(" 自然",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString(" 人工",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString(" 引  产",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString(" 死  胎",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString(" 死  产",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString(" 早  产",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString(" 足月产",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,intRow,80),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("  分娩方式",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+2,115,intRow),stfTitle);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos+130,m_intYPos+intRow);
				p_objGrp.DrawString(" 顺产",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString(" 臀位",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString("手术方式",new Font("SimSun",8),Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,40,30),stfTitle);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+50,m_intXPos+40,m_intYPos+50);
				p_objGrp.DrawString("吸、钳、剖",new Font("SimSun",8),Brushes.Black,new RectangleF(m_intXPos,m_intYPos+50,40,30),stfTitle);
				m_intXPos += 40;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString(" 其  它",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += 35;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("产后情况",new Font("SimSun",8),Brushes.Black,new RectangleF(m_intXPos,m_intYPos+2,50,intRow),stfTitle);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos+60,m_intYPos+intRow);
				p_objGrp.DrawString(" 出  血",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString("产褥热",new Font("SimSun",10),Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow+2,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);

				p_objGrp.DrawString("合并症或并发症",new Font("SimSun",10),Brushes.Black,new RectangleF(m_intXPos,m_intYPos+2,40,80),stfTitle);
				m_intXPos += 40;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);

				p_objGrp.DrawString("  小孩情况",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+2,140,intRow),stfTitle);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos+140,m_intYPos+intRow);
				p_objGrp.DrawString(" 性  别",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += 20;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString(" 生  存",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString("死亡",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow+2,50,intRow),stfTitle);
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow*2,m_intXPos+60,m_intYPos+intRow*2);
				p_objGrp.DrawString("时间",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+40,25,40),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow*2,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString("原因",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+42,25,40),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos+intRow,m_intXPos,m_intYPos+intHeight);
				p_objGrp.DrawString(" 后遗症",new Font("SimSun",10),Brushes.Black,new RectangleF(m_intXPos,m_intYPos+intRow,25,60),stfTitle);
				m_intXPos += intRowWidth;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("出生体重",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos+2,25,80),stfTitle);
				m_intXPos += 25;
				p_objGrp.DrawLine(Pens.Black,m_intXPos,m_intYPos,m_intXPos,m_intYPos+intHeight);
				
				p_objGrp.DrawString("  畸  形",p_fntNormalText,Brushes.Black,new RectangleF(m_intXPos,m_intYPos,25,80),stfTitle);
				m_intXPos += intRowWidth;
				#endregion
			}
			/// <summary>
			/// 
			/// </summary>
			/// <param name="p_intPosY"></param>
			/// <param name="p_objGrp"></param>
			/// <param name="p_fntNormalText"></param>
            private void m_mthPrintContent(int p_intPosY, System.Drawing.Graphics p_objGrp, clsInpatMedRec_Item[][] m_objItemArr)
			{
				int intYPos = p_intPosY+107;
				int intRowHeight = 40;
				m_intXPos = (int)enmRectangleInfo.LeftX+10;
                if (m_objItemArr[0] != null || m_objItemArr[1] != null || m_objItemArr[2] != null)
                {
                    for (int i = 0; i < m_objItemArr.Length; i++)
                    {
                        int j2 = 0;
                        #region Print Content
                        RectangleF rtgf = new RectangleF(m_intXPos, intYPos, 20, intRowHeight);
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 36;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 20;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        for (; j2 < 12; j2++)
                        {
                            rtgf.X += rtgf.Width;
                            rtgf.Width = 30;
                            m_mthPrintSubContent(m_objItemArr[i][j2], rtgf, p_objGrp);
                        }
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 40;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 35;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 30;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 30;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 40;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        rtgf.X += rtgf.Width;
                        rtgf.Width = 20;
                        m_mthPrintSubContent(m_objItemArr[i][j2++], rtgf, p_objGrp);
                        for (; j2 < 24; j2++)
                        {
                            rtgf.X += rtgf.Width;
                            rtgf.Width = 30;
                            m_mthPrintSubContent(m_objItemArr[i][j2], rtgf, p_objGrp);
                        }
                        #endregion
                        intYPos += intRowHeight;
                    }
                }
			}
			private void m_mthPrintSubContent(clsInpatMedRec_Item p_objItem,RectangleF p_rtgContent,System.Drawing.Graphics p_objGrp)
			{
				if(p_objItem == null)
					return ;
				if(p_objItem.m_strItemContent == null || p_objItem.m_strItemContent == "")
					return ;
				Font fnt = new Font("SimSun",9);
				StringFormat stfTitle = new StringFormat(StringFormatFlags.FitBlackBox);
				p_objGrp.DrawString(p_objItem.m_strItemContent,fnt,Brushes.Black,p_rtgContent,stfTitle);
			}
		}

        /// <summary>
        /// 主诉,现病史
        /// </summary>
		private class clsPrinDetail1 : clsIMR_PrintLineBase
		{
            private bool m_blnIsFirstPrint = true;
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsInpatMedRec_Item[][] m_objItemArr = new clsInpatMedRec_Item[1][];
			private string[] m_strItemArr = {"主诉","现病史>>孕","现病史>>产","现病史>>末次月经",
											  "现病史>>预产期","现病史>>早孕反应","现病史>>持续时间",
											  "现病史>>胎动出现时间","现病史>>产检次数","现病史>>产检地点","现病史>>其他情况"};

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                try
                {
                    int PostX = m_intPatientInfoX;
                    int intRowWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth2;
                    int intHeight = 50;
                    Font fnt = new Font("SimSun", 10.5f);
                    Font fnt1 = new Font("SimSun", 12, FontStyle.Bold);

                    m_objItemArr[0] = m_objGetContentFromItemArr(m_strItemArr);

                    if (m_objContent == null || m_objContent.m_objItemContents == null)
                    {
                        m_blnHaveMoreLine = false;
                        return;
                    }
                    if (m_blnIsFirstPrint)
                    {
                        #region 主诉
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("主诉：", fnt1, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[0] != null && m_objItemArr[0][0] != null)
                            p_objGrp.DrawString(m_objItemArr[0][0].m_strItemContent, fnt, Brushes.Black, new RectangleF(PostX + 50, p_intPosY + 1, intRowWidth - 30, intHeight - 50));
                        #endregion

                        #region 现病史
                        p_intPosY += intHeight + 10;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("现病史： ", fnt1, Brushes.Black, PostX, p_intPosY);
                        p_objGrp.DrawString("孕_______  产_______  末次月经___________________  预产期__________________", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[0] != null && m_objItemArr[0][1] != null)
                            p_objGrp.DrawString(m_objItemArr[0][1].m_strItemContent, fnt, Brushes.Black, PostX + 95, p_intPosY);//孕
                        if (m_objItemArr[0] != null && m_objItemArr[0][2] != null)
                            p_objGrp.DrawString(m_objItemArr[0][2].m_strItemContent, fnt, Brushes.Black, PostX + 170, p_intPosY);//产
                        if (m_objItemArr[0] != null && m_objItemArr[0][3] != null)
                            p_objGrp.DrawString(DateTime.Parse(m_objItemArr[0][3].m_strItemContent).ToString("yyyy年MM月dd日"), fnt, Brushes.Black, PostX + 300, p_intPosY);//末次月经
                        if (m_objItemArr[0] != null && m_objItemArr[0][4] != null)
                            p_objGrp.DrawString(DateTime.Parse(m_objItemArr[0][4].m_strItemContent).ToString("yyyy年MM月dd日"), fnt, Brushes.Black, PostX + 495, p_intPosY);//预产期

                        p_intPosY += 25;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("早孕反应___________________  持续时间___________________  胎动出现时间__________________", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[0] != null && m_objItemArr[0][5] != null)
                            p_objGrp.DrawString(m_objItemArr[0][5].m_strItemContent, fnt, Brushes.Black, PostX + 135, p_intPosY);//早孕反应
                        if (m_objItemArr[0] != null && m_objItemArr[0][6] != null)
                            p_objGrp.DrawString(m_objItemArr[0][6].m_strItemContent, fnt, Brushes.Black, PostX + 350, p_intPosY);//持续时间
                        if (m_objItemArr[0] != null && m_objItemArr[0][7] != null)
                            p_objGrp.DrawString(m_objItemArr[0][7].m_strItemContent, fnt, Brushes.Black, PostX + 590, p_intPosY);//胎动出现时间

                        p_intPosY += 25;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("产检次数________  地点_________________________________________________________________", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[0] != null && m_objItemArr[0][8] != null)
                            p_objGrp.DrawString(m_objItemArr[0][8].m_strItemContent, fnt, Brushes.Black, PostX + 140, p_intPosY);//产检次数
                        if (m_objItemArr[0] != null && m_objItemArr[0][9] != null)
                            p_objGrp.DrawString(m_objItemArr[0][9].m_strItemContent, fnt, Brushes.Black, PostX + 240, p_intPosY);//地点
                        #endregion
                        p_intPosY += 25;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("其他情况：", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (clsIMR_Obstetric_CriterionPrintTool.m_blnIsPrintMark)
                        {
                            m_objPrintContext.m_mthSetContextWithCorrectBefore(((m_objItemArr[0] == null || m_objItemArr[0][10] == null || m_objItemArr[0][10].m_strItemContent == null) ? "" : m_objItemArr[0][10].m_strItemContent), ((m_objItemArr[0] == null || m_objItemArr[0][10] == null || m_objItemArr[0][10].m_strItemContentXml == null) ? "<root />" : m_objItemArr[0][10].m_strItemContentXml), m_dtmFirstPrintTime, (m_objItemArr[0] == null || m_objItemArr[0][10] == null));
                            m_mthAddSign2("其他情况：", m_objPrintContext.m_ObjModifyUserArr);
                        }
                        else
                        {
                            m_objPrintContext.m_mthSetContextWithAllCorrect(((m_objItemArr[0] == null || m_objItemArr[0][10] == null || m_objItemArr[0][10].m_strItemContent == null) ? "" : m_objItemArr[0][10].m_strItemContent), ((m_objItemArr[0] == null || m_objItemArr[0][10] == null || m_objItemArr[0][10].m_strItemContentXml == null) ? "<root />" : m_objItemArr[0][10].m_strItemContentXml));
                        }
                        m_blnIsFirstPrint = false;

                    }

                    if (m_objPrintContext.m_BlnHaveNextLine())
                    {
                        m_objPrintContext.m_mthPrintLine(intRowWidth - 140, 185, p_intPosY, p_objGrp);
                        p_intPosY += 20;
                    }
                    if (m_objPrintContext.m_BlnHaveNextLine())
                    {
                        m_blnHaveMoreLine = true;
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                        p_intPosY += 15;
                    }
                }
                catch (Exception ex)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    objLogger.LogError(ex);
                }
                
            }

			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
				m_blnIsFirstPrint = true;
			}


		}

        /// <summary>
        /// 月经史
        /// </summary>
        private class clsPrinDetail2 : clsIMR_PrintLineBase
        {
            private bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private clsInpatMedRec_Item[][] m_objItemArr = new clsInpatMedRec_Item[1][];
            private string[] m_strItemArr = {"月经史>>初潮","月经史>>周期","月经史>>量>>少","月经史>>量>>中","月经史>>量>>多","月经史>>痛经>>无",
                                                 "月经史>>痛经>>轻","月经史>>痛经>>中","月经史>>痛经>>重",
                                                 "月经史>>血块>>有","月经史>>血块>>无"};

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                int PostX = m_intPatientInfoX;
                int intRowWidth = (int)enmRectangleInfoInPatientCaseInfo.PrintWidth2;
                int intHeight = 50;
                Font fnt = new Font("SimSun", 10.5f);
                Font fnt1 = new Font("SimSun", 12, FontStyle.Bold);

                m_objItemArr[0] = m_objGetContentFromItemArr(m_strItemArr);

                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    #region 月经史
                    PostX = m_intPatientInfoX - 30;
                    p_objGrp.DrawString("月经史：", fnt1, Brushes.Black, PostX, p_intPosY);
                    p_objGrp.DrawString("初潮     岁，周期       天，量（少  中  多），痛经（无  轻  中  重），血块（有  无）", fnt, Brushes.Black, PostX  + 70, p_intPosY);

                    if (m_objItemArr[0] != null && m_objItemArr[0][0] != null)
                        p_objGrp.DrawString(m_objItemArr[0][0].m_strItemContent,fnt,Brushes.Black,PostX + 110,p_intPosY);

                    if (m_objItemArr[0] != null && m_objItemArr[0][1] != null)
                        p_objGrp.DrawString(m_objItemArr[0][1].m_strItemContent,fnt,Brushes.Black,PostX+198,p_intPosY);

                    if (m_objItemArr[0] != null && m_objItemArr[0][2] != null && m_objItemArr[0][2].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 305, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][3] != null && m_objItemArr[0][3].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 335, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][4] != null && m_objItemArr[0][4].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 365, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][5] != null && m_objItemArr[0][5].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 450, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][6] != null && m_objItemArr[0][6].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 480, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][7] != null && m_objItemArr[0][7].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 510, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][8] != null && m_objItemArr[0][8].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 540, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][9] != null && m_objItemArr[0][9].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 630, p_intPosY );

                    if (m_objItemArr[0] != null && m_objItemArr[0][10] != null && m_objItemArr[0][10].m_strItemContent == "True")
                        p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 660, p_intPosY );

                    #endregion

                    m_blnIsFirstPrint = false;

                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine(intRowWidth - 140, 185, p_intPosY, p_objGrp);
                    p_intPosY += 35;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_blnHaveMoreLine = true;
                }
                else
                {
                    m_blnHaveMoreLine = false;
                    p_intPosY += 15;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }


        }

        /// <summary>
        /// 婚姻，过去，个人家族史    
        /// </summary>
        private class clsPrinDetail3 : clsIMR_PrintLineBase
        {
            private bool m_blnIsFirstPrint = true;
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            private clsInpatMedRec_Item[][] m_objItemArr = new clsInpatMedRec_Item[4][];
            private int m_intPart;
            private string[] m_strItemArr1 = {"个人史>>长期生活所在地","个人史>>嗜好>>烟","个人史>>嗜好>>酒","个人史>>嗜好>>其它嗜好"};
												 
            private string[] m_strItemArr2 = {"过去史>>过敏史","过去史>>输血史","过去史>>手术史","过去史>>心脏病",
												 "过去史>>高血压","过去史>>肝病","过去史>>肾病","过去史>>糖尿病",
												 "过去史>>血液病","过去史>>结核病","过去史>>骨关节病","过去史>>其他病","过去史>>(需说明的问题)"};

            private string[] m_strItemArr3 =  {"婚姻史>>结婚年龄","婚姻史>>配偶姓名","婚姻史>>配偶年龄",
                                                 "婚姻史>>配偶籍贯","婚姻史>>配偶职业","婚姻史>>配偶嗜好",
                                                 "婚姻史>>健康情况","婚姻史>>治疗情况"};

            private string[] m_strItemArr4 = { "家族史>>高血压","家族史>>结核病","家族史>>糖尿病",
                                                 "家族史>>精神病","家族史>>多胎","家族史>>遗传病史","家族史>>其他"};

            private void m_mthPrintData(System.Drawing.Graphics p_objGrp, int p_intX1, int p_intY1, int p_intX2, int p_intY2, System.Drawing.Font p_fnt, int p_intArryPost1, int p_intArryPost2, int p_intType)
            {
                if (m_objItemArr[p_intArryPost1] != null && m_objItemArr[p_intArryPost1][p_intArryPost2] != null)
                {
                    if (p_intType == 0)
                        p_objGrp.DrawString(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent, p_fnt, Brushes.Black, new RectangleF(p_intX1, p_intY1, p_intX2, p_intY2));
                    else if (p_intType == 1)
                        p_objGrp.DrawString(Convert.ToDateTime(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent).ToString(), p_fnt, Brushes.Black, new RectangleF(p_intX1, p_intY1, p_intX2, p_intY2));
                    else if (p_intType == 2)
                        p_objGrp.DrawString(Convert.ToDateTime(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent).ToString("yyyy年MM月dd日"), p_fnt, Brushes.Black, new RectangleF(p_intX1, p_intY1, p_intX2, p_intY2));
                }
            }

            public clsPrinDetail3(int p_intPart)
            {
                m_intPart = p_intPart;
            }
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                int PostX = m_intPatientInfoX - 30;
                int intRowWidth = 770;
                int intHeight;
                int intPostY1;
                int intPostY2;
                int intPostY3;
                int intPostY4;

                Font fnt = new Font("SimSun", 10.5f);
                Font fnt1 = new Font("SimSun", 12, FontStyle.Bold);
                Font fnt2 = new Font("SimSun", 7);

                m_objItemArr[0] = m_objGetContentFromItemArr(m_strItemArr1);
                m_objItemArr[1] = m_objGetContentFromItemArr(m_strItemArr2);
                m_objItemArr[2] = m_objGetContentFromItemArr(m_strItemArr3);
                m_objItemArr[3] = m_objGetContentFromItemArr(m_strItemArr4);


                if (m_blnIsFirstPrint)
                {
                    #region
                    if (m_intPart == 1)
                    {
                        intHeight = 20;
                        #region 过去史
                        p_objGrp.DrawString("过去史：", fnt1, Brushes.Black, PostX, p_intPosY);
                        p_objGrp.DrawString("过敏史、输血史、手术史、心脏病、高血压、肝病、肾病、糖尿病、血液病、结核病、骨关节病", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[1] != null)
                        {
                            if (m_objItemArr[1][0] != null)
                                if (m_objItemArr[1][0].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 90, p_intPosY);
                            if (m_objItemArr[1][1] != null)
                                if (m_objItemArr[1][1].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 143, p_intPosY);
                            if (m_objItemArr[1][2] != null)
                                if (m_objItemArr[1][2].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 205, p_intPosY);
                            if (m_objItemArr[1][3] != null)
                                if (m_objItemArr[1][3].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 266, p_intPosY);
                            if (m_objItemArr[1][4] != null)
                                if (m_objItemArr[1][4].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 320, p_intPosY);
                            if (m_objItemArr[1][5] != null)
                                if (m_objItemArr[1][5].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 370, p_intPosY);
                            if (m_objItemArr[1][6] != null)
                                if (m_objItemArr[1][6].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 415, p_intPosY);
                            if (m_objItemArr[1][7] != null)
                                if (m_objItemArr[1][7].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 470, p_intPosY);
                            if (m_objItemArr[1][8] != null)
                                if (m_objItemArr[1][8].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 530, p_intPosY);
                            if (m_objItemArr[1][9] != null)
                                if (m_objItemArr[1][9].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 580, p_intPosY);
                            if (m_objItemArr[1][10] != null)
                                if (m_objItemArr[1][10].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 650, p_intPosY);
                        }
                        //换行
                        p_intPosY += intHeight;
                        PostX +=  70;

                        RectangleF m_rtgF = new RectangleF(PostX + 55, p_intPosY, intRowWidth, intHeight);
                        StringFormat m_sf = new StringFormat();
                        m_sf.Alignment = StringAlignment.Near;
                        p_objGrp.DrawString("其他病：", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1] != null && m_objItemArr[1][11] != null && !string.IsNullOrEmpty(m_objItemArr[1][11].m_strItemContent))
                        {
                            SizeF m_sizeF = p_objGrp.MeasureString(m_objItemArr[1][11].m_strItemContent, fnt, intRowWidth - PostX - 55, m_sf);
                            m_rtgF.X = PostX + 55;
                            m_rtgF.Y = p_intPosY;
                            m_rtgF.Width = intRowWidth - PostX - 55;
                            m_rtgF.Height = m_sizeF.Height;
                            p_objGrp.DrawString(m_objItemArr[1][11].m_strItemContent, fnt, Brushes.Black, m_rtgF, m_sf);
                            p_intPosY += Convert.ToInt32(m_sizeF.Height);
                        }
                        else
                        {

                            //换行	
                            p_intPosY += intHeight;
                        }
                        p_objGrp.DrawString("需说明的问题：", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1] != null && m_objItemArr[1][12] != null && !string.IsNullOrEmpty(m_objItemArr[1][12].m_strItemContent))
                        {
                            SizeF m_sizeF = p_objGrp.MeasureString(m_objItemArr[1][12].m_strItemContent, fnt, intRowWidth - PostX - 100, m_sf);
                            m_rtgF.X = PostX + 100;
                            m_rtgF.Y = p_intPosY;
                            m_rtgF.Width = intRowWidth - PostX - 100;
                            m_rtgF.Height = m_sizeF.Height;
                            p_objGrp.DrawString(m_objItemArr[1][12].m_strItemContent, fnt, Brushes.Black, m_rtgF, m_sf);
                            p_intPosY += Convert.ToInt32(m_sizeF.Height);
                        }
                        else
                        {
                            p_intPosY += intHeight + 5;
                        }
                        #endregion

                        #region 个人史
                        //p_intPosY += intHeight + 5;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("个人史：", fnt1, Brushes.Black, PostX, p_intPosY);
                        p_objGrp.DrawString("长期生活所在地：                                         嗜好： 烟、酒，其他：", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[0] != null)
                        {
                            if (m_objItemArr[0][0] != null)
                                p_objGrp.DrawString(m_objItemArr[0][0].m_strItemContent, fnt, Brushes.Black, PostX + 185, p_intPosY);
                            if (m_objItemArr[0][1] != null && m_objItemArr[1][1] != null)
                            {
                                if (m_objItemArr[1][1].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 540, p_intPosY);
                            }
                                
                            if (m_objItemArr[0][2] != null)
                                if (m_objItemArr[0][2].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 565, p_intPosY);
                        }
                        if (m_objItemArr[0] != null && m_objItemArr[0][3] != null)
                            p_objGrp.DrawString(m_objItemArr[0][3].m_strItemContent, fnt, Brushes.Black, PostX + 635, p_intPosY);
                        #endregion
                        #region 婚姻史
                        //换行
                        p_intPosY += intHeight +5;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("婚姻史：", fnt1, Brushes.Black, PostX, p_intPosY);
                        p_objGrp.DrawString("结婚年龄：   岁，配偶姓名：           年龄：    岁，籍贯：                  职业：", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[2] != null)
                        {
                            if (m_objItemArr[2][0] != null)
                                p_objGrp.DrawString(m_objItemArr[2][0].m_strItemContent, fnt, Brushes.Black, PostX + 138, p_intPosY);
                            if (m_objItemArr[2][1] != null)
                                p_objGrp.DrawString(m_objItemArr[2][1].m_strItemContent, fnt, Brushes.Black, PostX + 258, p_intPosY);
                            if (m_objItemArr[2][2] != null)
                                p_objGrp.DrawString(m_objItemArr[2][2].m_strItemContent, fnt, Brushes.Black, PostX + 385, p_intPosY);
                            if (m_objItemArr[2][3] != null)
                                p_objGrp.DrawString(m_objItemArr[2][3].m_strItemContent, fnt, Brushes.Black, PostX + 488, p_intPosY);
                            if (m_objItemArr[2][4] != null)
                                p_objGrp.DrawString(m_objItemArr[2][4].m_strItemContent, fnt, Brushes.Black, PostX + 662, p_intPosY);
                        }
                        //换行	
                        p_intPosY += intHeight;
                        p_objGrp.DrawString("嗜好：                        健康状况：                         治疗状况：", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[3] != null)
                        {
                            if (m_objItemArr[2][5] != null)
                                p_objGrp.DrawString(m_objItemArr[2][5].m_strItemContent, fnt, Brushes.Black, PostX + 106, p_intPosY);
                            if (m_objItemArr[2][6] != null)
                                p_objGrp.DrawString(m_objItemArr[2][6].m_strItemContent, fnt, Brushes.Black, PostX + 356, p_intPosY);
                            if (m_objItemArr[2][7] != null)
                                p_objGrp.DrawString(m_objItemArr[2][7].m_strItemContent, fnt, Brushes.Black, PostX + 608, p_intPosY);
                        }
                        //换行	
                        p_intPosY += intHeight;
                        p_objGrp.DrawString("其他：", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[2] != null && m_objItemArr[2][7] != null)
                            p_objGrp.DrawString(m_objItemArr[2][7].m_strItemContent, fnt, Brushes.Black, PostX + 106, p_intPosY);
                        #endregion
                        #region 家族史
                        //换行	
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 30;
                        p_objGrp.DrawString("家族史：", fnt1, Brushes.Black, PostX, p_intPosY);
                        p_objGrp.DrawString("高血压、结核病、糖尿病、精神病、多胎、遗传病史，其他：", fnt, Brushes.Black, PostX + 70, p_intPosY);
                        if (m_objItemArr[3] != null)
                        {
                            if (m_objItemArr[3][0] != null)
                                if (m_objItemArr[3][0].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 90, p_intPosY);
                            if (m_objItemArr[3][1] != null)
                                if (m_objItemArr[3][1].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 145, p_intPosY);
                            if (m_objItemArr[3][2] != null)
                                if (m_objItemArr[3][2].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 205, p_intPosY);
                            if (m_objItemArr[3][3] != null)
                                if (m_objItemArr[3][3].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 257, p_intPosY);
                            if (m_objItemArr[3][4] != null)
                                if (m_objItemArr[3][4].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 317, p_intPosY);
                            if (m_objItemArr[3][5] != null)
                                if (m_objItemArr[3][5].m_strItemContent == "True")
                                    p_objGrp.DrawString("√", fnt1, Brushes.Black, PostX + 370, p_intPosY);
                            if (m_objItemArr[3][6] != null)
                                p_objGrp.DrawString(m_objItemArr[3][6].m_strItemContent, fnt, Brushes.Black, PostX +462, p_intPosY);
                        }

                        #endregion
                    }
                    #endregion
                    m_blnIsFirstPrint = false;
                }


                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                }
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_blnHaveMoreLine = true;
                }
                else
                {
                    m_blnHaveMoreLine = false;
                    p_intPosY += 2000;//换页
                }
            }
                

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }

        }

        /// <summary>
        /// 体检，产科检查，检查结果，诊断
        /// </summary>
        private class clsPrinDetail4 : clsIMR_PrintLineBase
		{
            private bool m_blnIsFirstPrint = true;
			private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black,new Font("",10));
			private clsInpatMedRec_Item[][] m_objItemArr = new clsInpatMedRec_Item[3][];
            private string[] m_strItemArr1 = {"体检>>体温","体检>>脉搏","体检>>脉搏整","体检>>脉搏不整",
												 "体检>>呼吸","体检>>收缩压","体检>>舒张压","体检>>身高","体检>>体重","体检>>发育",
												 "体检>>营养","体检>>神志","体检>>检查合作否","体检>>皮肤","体检>>表浅淋巴结",
												 "体检>>头部","体检>>五官","体检>>颈部","体检>>胸部","体检>>乳房","体检>>心脏",
												 "体检>>肺脏","体检>>肝脏","体检>>脾脏","体检>>肾脏","体检>>脊柱","体检>>膝反射",
												 "体检>>下肢>>水肿","体检>>下肢>>静脉曲张","体检>>外阴>>水肿","体检>>外阴>>静脉曲张",
												 "体检>>外阴>>外痔","体检>>其他"};

            private string[] m_strItemArr2 = {"产科检查>>宫高","产科检查>>腹围","产科检查>>胎方位","产科检查>>胎心音+","产科检查>>胎心音规则",
                                                 "产科检查>>胎心音不规则","产科检查>>胎先露","产科检查>>衔接>>未",
											     "产科检查>>衔接>>部分","产科检查>>衔接>>已","产科检查>>跨耻征",
                                                 "产科检查>>宫缩>>强","产科检查>>宫缩>>中","产科检查>>宫缩>>弱","产科检查>>(肛、阴)检>>宫颈Bishop评分",
												 "产科检查>>(肛、阴)检>>宫口开张","产科检查>>(肛、阴)检>>先露高低","产科检查>>(肛、阴)检>>阴道流水>>有",
                                                 "产科检查>>(肛、阴)检>>阴道流水>>无","产科检查>>(肛、阴)检>>胎膜破裂>>已","产科检查>>(肛、阴)检>>胎膜破裂>>未",
												 "产科检查>>(肛、阴)检>>羊水性状>>色","产科检查>>(肛、阴)检>>羊水性状>>PH",
												 "产科检查>>(肛、阴)检>>羊水性状>>性质","产科检查>>胎儿估计体重","产科检查>>骨盆外测量>>髂前上棘间径","产科检查>>骨盆外测量>>髂嵴间径",
												 "产科检查>>骨盆外测量>>骶耻外径","产科检查>>坐骨结节间径" };

            private string[] m_strItemArr3 = {"检验结果>>血色素",
												 "检验结果>>红血球","检验结果>>白血球","检验结果>>血小板","检验结果>>Hct",
												 "检验结果>>血型","检验结果>>尿蛋白","检验结果>>B超",
                                                 "检验结果>>肝功","检验结果>>乙肝两对半","检验结果>>其它"};//,"诊断","主治医师","住院医师","日期","最后诊断","最后诊断主治医师","最后诊断住院医师","最后诊断日期"};

            private void m_mthPrintData(System.Drawing.Graphics p_objGrp, int p_intX1, int p_intY1, System.Drawing.Font p_fnt, int p_intArryPost1, int p_intArryPost2, int p_intType)
            {
                if (m_objItemArr[p_intArryPost1] != null && m_objItemArr[p_intArryPost1][p_intArryPost2] != null)
                {
                    if (p_intType == 0)
                        p_objGrp.DrawString(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent, p_fnt, Brushes.Black, new RectangleF(p_intX1, p_intY1, 200, 200));
                    else if (p_intType == 1)
                        p_objGrp.DrawString(Convert.ToDateTime(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent).ToString(), p_fnt, Brushes.Black, new RectangleF(p_intX1, p_intY1, 200, 200));
                    else if (p_intType == 2)
                        p_objGrp.DrawString(Convert.ToDateTime(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent).ToString("yyyy年MM月dd日"), p_fnt, Brushes.Black, p_intX1, p_intY1);
                    else if(p_intType == 3)
                        p_objGrp.DrawString(m_objItemArr[p_intArryPost1][p_intArryPost2].m_strItemContent, p_fnt, Brushes.Black, p_intX1, p_intY1);
                }
            }

			public clsPrinDetail4()
			{

			}
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                int PostX = m_intPatientInfoX - 30;
                int intRowWidth = 770;
                int intHeight;
                int intPostY1;
                int intPostY2;
                int intPostY3;
                int intPostY4;

                Font fnt = new Font("SimSun", 10.5f);
                Font fnt1 = new Font("SimSun", 12, FontStyle.Bold);
                Font fnt2 = new Font("SimSun", 7);

                m_objItemArr[0] = m_objGetContentFromItemArr(m_strItemArr1);
                m_objItemArr[1] = m_objGetContentFromItemArr(m_strItemArr2);
                m_objItemArr[2] = m_objGetContentFromItemArr(m_strItemArr3);
                if (m_blnIsFirstPrint)
                {

                    #region 体检
                    if (m_objItemArr[0] != null)
                    {
                        #region 体检
                        #region 第一行
                        intHeight = 20;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("体    检", fnt1, Brushes.Black, PostX + intRowWidth / 2 - 50, p_intPosY);
                        p_intPosY += 25;
                        p_objGrp.DrawString("体温：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 0, 3);
                        PostX += 90;
                        p_objGrp.DrawString("℃", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 25;
                        p_objGrp.DrawString("脉搏：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 1, 3);
                        PostX += 60;
                        p_objGrp.DrawString("次/分(", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 45;
                        p_objGrp.DrawString("整、", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[0][2] != null)
                            if (m_objItemArr[0][2].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 30;
                        p_objGrp.DrawString("不整)", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[0][3] != null)
                            if (m_objItemArr[0][3].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 3, p_intPosY + 2, 40, intHeight));
                        PostX += 50;
                        p_objGrp.DrawString("呼吸：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 4, 3);
                        PostX += 60;
                        p_objGrp.DrawString("次/分", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 50;
                        p_objGrp.DrawString("血压：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 5, 3);
                        PostX += 60;
                        p_objGrp.DrawString("/", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 10, p_intPosY, fnt, 0, 6, 3);
                        PostX += 40;
                        p_objGrp.DrawString("(mmHg)", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 60;
                        p_objGrp.DrawString("身高：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 7, 3);
                        PostX += 60;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 30;
                        p_objGrp.DrawString("体重：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 8, 3);
                        PostX += 60;
                        p_objGrp.DrawString("kg", fnt, Brushes.Black, PostX, p_intPosY);
                        #endregion
                        #region 第二行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("发育：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 9, 3);
                        PostX += 150;
                        p_objGrp.DrawString("营养：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 10, 3);
                        PostX += 150;
                        p_objGrp.DrawString("神志：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 11, 3);
                        PostX += 150;
                        p_objGrp.DrawString("检查合作否：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 80, p_intPosY, fnt, 0, 12, 3);
                        PostX += 150;
                        p_objGrp.DrawString("皮肤：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 13, 3);
                        #endregion
                        #region 第三行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("表浅淋巴结：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 80, p_intPosY, fnt, 0, 14, 3);
                        PostX += 150;
                        p_objGrp.DrawString("头部：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 15, 3);
                        PostX += 150;
                        p_objGrp.DrawString("五官：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 16, 3);
                        PostX += 150;
                        p_objGrp.DrawString("颈部：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 17, 3);
                        PostX += 150;
                        p_objGrp.DrawString("胸部：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 18, 3);
                        #endregion
                        #region 第四行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("乳房：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 19, 3);
                        PostX += 150;
                        p_objGrp.DrawString("心脏：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 20, 3);
                        PostX += 300;
                        p_objGrp.DrawString("肺脏：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 21, 3);
                     
                        #endregion
                        #region 第五行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("肝脏：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 22, 3);
                        PostX += 300;
                        p_objGrp.DrawString("脾脏：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 23, 3);

                        #endregion
                        #region 第六行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("肾脏：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 24, 3);
                        PostX += 300;
                        p_objGrp.DrawString("脊柱：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 0, 25, 3);
                        PostX += 100;
                        p_objGrp.DrawString("膝反射：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 0, 26, 3);
                        PostX += 100;
                        p_objGrp.DrawString("下肢：水肿：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 80, p_intPosY, fnt, 0, 27, 3);
                        
                        #endregion
                        #region 第七行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("静脉曲张：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 65, p_intPosY, fnt, 0, 28, 3);
                        PostX += 140;
                        p_objGrp.DrawString("外阴：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 60;
                        p_objGrp.DrawString("水肿、", fnt, Brushes.Black, PostX, p_intPosY);

                        if (m_objItemArr[0][29] != null)
                            if (m_objItemArr[0][29].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 6, p_intPosY + 2, 40, intHeight));

                        PostX += 40;
                        p_objGrp.DrawString("静脉曲张、", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[0][30] != null)
                            if (m_objItemArr[0][30].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 25, p_intPosY + 2, 40, intHeight));

                        PostX += 70;
                        p_objGrp.DrawString("外痔", fnt, Brushes.Black, PostX + 5, p_intPosY);
                        if (m_objItemArr[0][31] != null)
                            if (m_objItemArr[0][31].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 10, p_intPosY + 2, 40, intHeight));
                        PostX += 70;
                        p_objGrp.DrawString("其他：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 45, p_intPosY, fnt, 0, 32, 3);
                        #endregion
                        #endregion
                    }
                    #endregion

                    #region 产科检查
                    if (m_objItemArr[1] != null)
                    {
                        #region 第一行
                        intHeight = 20;
                        p_intPosY += 20;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("产科检查", fnt1, Brushes.Black, PostX + intRowWidth / 2 - 50, p_intPosY);
                        p_intPosY += 26;
                        p_objGrp.DrawString("宫高：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 1, 0, 3);
                        PostX += 60;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 30;
                        p_objGrp.DrawString("腹围：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 1, 1, 3);
                        PostX += 60;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 30;
                        p_objGrp.DrawString("胎方位：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 1, 2, 3);
                        PostX += 130;
                        p_objGrp.DrawString("胎心音＋：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 67, p_intPosY, fnt, 1, 3, 3);
                        PostX += 100;
                        p_objGrp.DrawString("分/次", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 60;
                        p_objGrp.DrawString("规则", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][4] != null)
                            if (m_objItemArr[1][4].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 5, p_intPosY + 2, 40, intHeight));
                        PostX += 40;
                        p_objGrp.DrawString("不规则", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][5] != null)
                            if (m_objItemArr[1][5].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 15, p_intPosY + 2, 40, intHeight));
                        #endregion
                        #region 第二行
                        PostX = m_intPatientInfoX - 20;
                        p_intPosY += intHeight;
                        p_objGrp.DrawString("胎先露：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 1, 6, 3);
                        PostX += 90;
                        p_objGrp.DrawString("衔接：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 40;
                        p_objGrp.DrawString("未、", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][7] != null)
                            if (m_objItemArr[1][7].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));

                        PostX += 30;
                        p_objGrp.DrawString("部分、", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][8] != null)
                            if (m_objItemArr[1][8].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX + 3, p_intPosY + 2, 40, intHeight));

                        PostX += 40;
                        p_objGrp.DrawString("已", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][9] != null)
                            if (m_objItemArr[1][9].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 40;
                        p_objGrp.DrawString("跨耻征：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 55, p_intPosY, fnt, 1, 10, 3);
                        PostX += 90;
                        p_objGrp.DrawString("宫缩：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 40;
                        p_objGrp.DrawString("强、", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][11] != null)
                            if (m_objItemArr[1][11].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 20;
                        p_objGrp.DrawString("中、", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][12] != null)
                            if (m_objItemArr[1][12].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 20;
                        p_objGrp.DrawString("弱", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][13] != null)
                            if (m_objItemArr[1][13].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 40;
                        p_objGrp.DrawString("(肛、阴)检：宫颈Bishop评分：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 110;
                        m_mthPrintData(p_objGrp, PostX + 90, p_intPosY, fnt, 1, 14, 3);
                        PostX += 125;
                        p_objGrp.DrawString("分", fnt, Brushes.Black, PostX, p_intPosY);
                        #endregion
                        #region 第三行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20; ;
                        p_objGrp.DrawString("宫口开张：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 65, p_intPosY, fnt, 1, 15, 3);
                        PostX += 90;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 40;
                        p_objGrp.DrawString("先露高低：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 65;
                        p_objGrp.DrawString("S=", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 23, p_intPosY, fnt, 1, 16, 3);
                        PostX += 70;
                        p_objGrp.DrawString("阴道流水：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 75;
                        p_objGrp.DrawString("有", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][17] != null)
                            if (m_objItemArr[1][17].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 20;
                        p_objGrp.DrawString("无", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][18] != null)
                            if (m_objItemArr[1][18].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 40;
                        p_objGrp.DrawString("胎膜早破：", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 73;
                        p_objGrp.DrawString("已", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][19] != null)
                            if (m_objItemArr[1][19].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 30;
                        p_objGrp.DrawString("未", fnt, Brushes.Black, PostX, p_intPosY);
                        if (m_objItemArr[1][20] != null)
                            if (m_objItemArr[1][20].m_strItemContent == "True")
                                p_objGrp.DrawString("√", fnt1, Brushes.Black, new RectangleF(PostX, p_intPosY + 2, 40, intHeight));
                        PostX += 40;
                        p_objGrp.DrawString("羊水形状：色：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 98, p_intPosY, fnt, 1, 21, 3);
                        #endregion
                        #region 第四行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("PH：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 25, p_intPosY, fnt, 1, 22, 3);
                        PostX += 60;
                        p_objGrp.DrawString("性质：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 1, 23, 3);
                        PostX += 90;
                        p_objGrp.DrawString("胎儿体重估计：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 95, p_intPosY, fnt, 1, 24, 3);
                        PostX += 130;
                        p_objGrp.DrawString("kg", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 40;
                        p_objGrp.DrawString("盆骨外侧量：额前上棘间径：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 180, p_intPosY, fnt, 1, 25, 3);
                        PostX += 216;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 40;
                        p_objGrp.DrawString("骼嵴间径：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 70, p_intPosY, fnt, 1, 26, 3);
                        PostX += 100;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        
                        #endregion
                        #region 第五行
                        p_intPosY += intHeight;
                        PostX = m_intPatientInfoX - 20;
                        p_objGrp.DrawString("骶耻外径：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 70, p_intPosY, fnt, 1, 27, 3);
                        PostX += 90;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        PostX += 40;
                        p_objGrp.DrawString("坐骨结节间径：", fnt, Brushes.Black, PostX, p_intPosY);
                        m_mthPrintData(p_objGrp, PostX + 100, p_intPosY, fnt, 1, 28, 3);
                        PostX += 120;
                        p_objGrp.DrawString("cm", fnt, Brushes.Black, PostX, p_intPosY);
                        
                        #endregion

                    #endregion

                        #region 检查结果
                        if (m_objItemArr[2] != null)
                        {
                            #region 第一行
                            p_intPosY += 35;
                            PostX = m_intPatientInfoX - 20;
                            p_objGrp.DrawString("检查结果", fnt1, Brushes.Black, PostX + intRowWidth / 2 - 50, p_intPosY);
                            p_intPosY += 25;
                            p_objGrp.DrawString("血色素：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 2, 0, 3);
                            PostX += 80;
                            p_objGrp.DrawString("g/L", fnt, Brushes.Black, PostX, p_intPosY);
                            PostX += 40;
                            p_objGrp.DrawString("红血球：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 2, 1, 3);
                            PostX += 80;
                            p_objGrp.DrawString("×10", fnt, Brushes.Black, PostX, p_intPosY);
                            PostX += 27;
                            p_objGrp.DrawString("12", fnt2, Brushes.Black, PostX, p_intPosY - 3);
                            PostX += 10;
                            p_objGrp.DrawString("/L", fnt, Brushes.Black, PostX, p_intPosY);
                            PostX += 40;
                            p_objGrp.DrawString("白血球：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 2, 2, 3);
                            PostX += 80;
                            p_objGrp.DrawString("×10", fnt, Brushes.Black, PostX, p_intPosY);
                            PostX += 29;
                            p_objGrp.DrawString("9", fnt2, Brushes.Black, PostX, p_intPosY - 3);
                            PostX += 10;
                            p_objGrp.DrawString("/L", fnt, Brushes.Black, PostX, p_intPosY);
                            PostX += 40;
                            p_objGrp.DrawString("血小板：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 2, 3, 3);
                            PostX += 80;
                            p_objGrp.DrawString("×10", fnt, Brushes.Black, PostX, p_intPosY);
                            PostX += 28;
                            p_objGrp.DrawString("9", fnt2, Brushes.Black, PostX, p_intPosY - 3);
                            PostX += 10;
                            p_objGrp.DrawString("/L   Hct：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 73, p_intPosY, fnt, 2, 4, 3);
                            p_objGrp.DrawString("%", fnt, Brushes.Black, PostX + 113, p_intPosY);
                            #endregion
                            #region 第二行
                            p_intPosY += intHeight;
                            PostX = m_intPatientInfoX - 20;
                            p_objGrp.DrawString("血型：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 2, 5, 3);
                            PostX += 100;
                            p_objGrp.DrawString("尿蛋白：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 50, p_intPosY, fnt, 2, 6, 3);
                            PostX += 120;
                            p_objGrp.DrawString("B超：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 40, p_intPosY, fnt, 2, 7, 3);
                            #endregion
                            #region 第三行
                            p_intPosY += intHeight;
                            PostX = m_intPatientInfoX - 20;
                            p_objGrp.DrawString("", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 56, p_intPosY, fnt, 2, 8, 3);
                          //  PostX += 10;
                            p_objGrp.DrawString("乙肝两对半：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX +90, p_intPosY, fnt, 2, 9, 3);
                            PostX += 340;
                            p_objGrp.DrawString("其他：", fnt, Brushes.Black, PostX, p_intPosY);
                            m_mthPrintData(p_objGrp, PostX + 45, p_intPosY, fnt, 2, 10, 3);
                            p_intPosY += intHeight;
                            #endregion
                        }

                        #endregion

                        #region 诊断
                        //    p_intPosY += 35;
                        //    PostX = 35;



                        //    p_objGrp.DrawString("诊断：", fnt1, Brushes.Black, PostX, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 55, p_intPosY, fnt, 2, 12, 0);
                        //    p_intPosY += 170;
                        //    p_objGrp.DrawString("住院医师：", fnt, Brushes.Black, PostX + 250, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 530 , p_intPosY, fnt, 2, 13, 3);
                        //    p_intPosY += 20;
                        //    p_objGrp.DrawString("主治医师：", fnt, Brushes.Black, PostX + 250, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 530, p_intPosY, fnt, 2, 14, 3);
                        //    p_intPosY += 20;
                        //    p_objGrp.DrawString("日    期：", fnt, Brushes.Black, PostX + 250, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 530, p_intPosY, fnt, 2, 15, 2);
                        //    intPostY2 = p_intPosY;

                        //    PostX = 35;
                        //    p_intPosY = p_intPosY + 10;
                        //    p_objGrp.DrawString("最后诊断：", fnt1, Brushes.Black, PostX, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 92, p_intPosY, fnt, 2, 16, 0);
                        //    p_intPosY += 170;
                        //    p_objGrp.DrawString("住院医师：", fnt, Brushes.Black, PostX + 250, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 530, p_intPosY, fnt, 2, 17, 3);
                        //    p_intPosY += 20;
                        //    p_objGrp.DrawString("主治医师：", fnt, Brushes.Black, PostX + 250, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 530, p_intPosY, fnt, 2, 18, 3);
                        //    p_intPosY += 20;
                        //    p_objGrp.DrawString("日    期：", fnt, Brushes.Black, PostX + 250, p_intPosY);
                        //    m_mthPrintData(p_objGrp, PostX + 530, p_intPosY, fnt, 2, 19, 2);
                        //    intPostY2 = p_intPosY;
                        //}
                        #endregion
                    }
                    if (m_objPrintContext.m_BlnHaveNextLine())
                    {
                        m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                        p_intPosY += 20;
                    }
                    if (m_objPrintContext.m_BlnHaveNextLine())
                    {
                        m_blnHaveMoreLine = true;
                    }
                    else
                    {
                        m_blnHaveMoreLine = false;
                    }
                }
            }
			public override void m_mthReset()
			{
				m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
			}

		}

        /// <summary>
        /// 诊断
        /// </summary>
        private class clsPrintHomeHistroy : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {

                if (m_hasItems != null)
                    if (m_hasItems.Contains("诊断"))
                        objItemContent = m_hasItems["诊断"] as clsInpatMedRec_Item;
                if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}
                    p_intPosY += 20;
                    p_objGrp.DrawString("诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                    p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                    m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
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
        }

        /// <summary>
        /// 主治医师
        /// </summary>
        private class clsPrint10 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string m_strPrint = string.Empty;
                    p_objGrp.DrawString("主治医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY+2);
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("主治医师签名"))
                            m_strPrint += (m_hasItems["主治医师签名"] as clsInpatMedRec_Item).m_strItemContent;
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (!string.IsNullOrEmpty(m_strPrint))
                        m_strPrint = m_strPrint.Replace("副主任医师", "").Replace("主治医师", "").Replace("副主任中医师", "").Replace("主任医师", "").Replace("中医师", "").Replace("医师", "").Trim();
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    Image imgEmpSig = ImageSignature.GetEmpSigImage(m_strPrint);
                    if (imgEmpSig != null)
                    {
                        p_objGrp.DrawImage(imgEmpSig, m_intRecBaseX + 130, p_intPosY-2, 70, 30);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                    }
                    p_intPosY += 30;
                    //string strOperations = "        ";
                    //string strAllText = "        ";
                    //string strXml = "";
                    //for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    //{
                    //    if (m_objContent.objSignerArr[i].controlName == "m_lsvhelper")
                    //        strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    //}
                    //if (strOperations != "")
                    //{
                    //    p_objGrp.DrawString("主治医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    //    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    //    m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    //}
                
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //    return;
                //}
                //m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                m_blnIsFirstPrint = false;
                m_blnHaveMoreLine = false;
                }

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_blnHaveMoreLine = true;
                //}
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        /// <summary>
        /// 住院医师
        /// </summary>
        private class clsPrint11 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string m_strPrint = string.Empty ;
                    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY+2);
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("住院医师签名"))
                            m_strPrint += (m_hasItems["住院医师签名"] as clsInpatMedRec_Item).m_strItemContent;
                    if (!string.IsNullOrEmpty(m_strPrint))
                        m_strPrint = m_strPrint.Replace("副主任医师", "").Replace("主治医师", "").Replace("副主任中医师", "").Replace("主任医师", "").Replace("中医师","").Replace("医师","").Trim();
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    Image imgEmpSig = ImageSignature.GetEmpSigImage(m_strPrint);
                    if (imgEmpSig != null)
                    {
                        p_objGrp.DrawImage(imgEmpSig, m_intRecBaseX + 130, p_intPosY-2, 70, 30);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                    }
                    p_intPosY += 30;
                    //string strOperations = "        ";
                    //string strAllText = "        ";
                    //string strXml = "";
                    //for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    //{
                    //    if (m_objContent.objSignerArr[i].controlName == "m_lsvOperation")
                    //        strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    //}
                    //if (strOperations != "")
                    //{
                    //    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    //    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    //    m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    //}
                    //else
                    //{
                    //    m_blnHaveMoreLine = false;
                    //    return;
                    //}
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_blnHaveMoreLine = true;
                //}
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        /// <summary>
        /// 日期

        /// </summary>
        private class clsPrintDate : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strPrint = "日期：";
                if (m_hasItems != null)
                    if (m_hasItems.Contains("日期"))
                        m_strPrint += (m_hasItems["日期"] as clsInpatMedRec_Item).m_strItemContent;
                p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                p_intPosY += 20;

                m_blnIsFirstPrint = false;
                m_blnHaveMoreLine = false;

                //if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                //{
                //    m_blnHaveMoreLine = false;
                //    return;
                //}
                //if (m_blnIsFirstPrint)
                //{
                //    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                //    //{
                //    //    m_blnHaveMoreLine = true;
                //    //    return;
                //    //}

                //    p_objGrp.DrawString("日期:", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                //    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                //    //{
                //    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                //  //  p_intPosY += 20;
                //    //}
                //    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                //    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                //    //p_fntNormal.Dispose();
                //    m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                //    m_blnIsFirstPrint = false;
                //}

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                //    p_intPosY += 20;

                //    intLine++;
                //}

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }

        /// <summary>
        /// 诊断

        /// </summary>
        private class clsPrintHomeHistroy2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString("最后诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                    p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();

                    if (m_hasItems != null)
                        if (m_hasItems.Contains("最后诊断"))
                            objItemContent = m_hasItems["最后诊断"] as clsInpatMedRec_Item;
                    if (objItemContent == null || objItemContent.m_strItemContent == "" || objItemContent.m_strItemContent == null)
                    {
                        p_intPosY += 20;
                        m_blnHaveMoreLine = false;
                        return;
                    }


                    m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                    p_intPosY += 20;

                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
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
        }


        /// <summary> 
        /// 主治医师
        /// </summary>
        private class clsPrint12 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;

                }
                if (m_blnIsFirstPrint)
                {
                    string m_strPrint = string.Empty;
                    p_objGrp.DrawString("主治医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY+2);
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("最后主治医师签名"))
                            m_strPrint += (m_hasItems["最后主治医师签名"] as clsInpatMedRec_Item).m_strItemContent;
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (!string.IsNullOrEmpty(m_strPrint))
                        m_strPrint = m_strPrint.Replace("副主任医师", "").Replace("主治医师", "").Replace("副主任中医师", "").Replace("主任医师", "").Replace("中医师", "").Replace("医师", "").Trim();
                    Image imgEmpSig = ImageSignature.GetEmpSigImage(m_strPrint);
                    if (imgEmpSig != null)
                    {
                        p_objGrp.DrawImage(imgEmpSig, m_intRecBaseX + 130, p_intPosY-2, 70, 30);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                    }
                    p_intPosY += 30;
                    //string strOperations = "        ";
                    //string strAllText = "        ";
                    //string strXml = "";
                    //for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    //{
                    //    if (m_objContent.objSignerArr[i].controlName == "m_lsvOperations")
                    //        strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    //}
                    //if (strOperations != "")
                    //{
                    //    p_objGrp.DrawString("主治医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    //    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    //    m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    //}
                    //else
                    //{
                    //    m_blnHaveMoreLine = false;
                    //    return;
                    //}
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_blnIsFirstPrint = false;
                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_blnHaveMoreLine = true;
                //}
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        /// <summary>
        /// 住院医师
        /// </summary>
        private class clsPrint13 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private clsInpatMedRec_Item objItemContent = null;
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_objContent == null || m_objContent.m_objItemContents == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }
                if (m_blnIsFirstPrint)
                {
                    string m_strPrint = string.Empty;
                    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY+2);
                    if (m_hasItems != null)
                        if (m_hasItems.Contains("最后住院医师签名"))
                            m_strPrint += (m_hasItems["最后住院医师签名"] as clsInpatMedRec_Item).m_strItemContent;
                    //p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    if (!string.IsNullOrEmpty(m_strPrint))
                        m_strPrint = m_strPrint.Replace("副主任医师", "").Replace("主治医师", "").Replace("副主任中医师", "").Replace("主任医师", "").Replace("中医师", "").Replace("医师", "").Trim();
                    Image imgEmpSig = ImageSignature.GetEmpSigImage(m_strPrint);
                    if (imgEmpSig != null)
                    {
                        p_objGrp.DrawImage(imgEmpSig, m_intRecBaseX + 130, p_intPosY-2, 70, 30);
                    }
                    else
                    {
                        p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 130, p_intPosY);
                    }
                    p_intPosY += 30;
                    //string strOperations = "        ";
                    //string strAllText = "        ";
                    //string strXml = "";
                    //for (int i = 0; i < m_objContent.objSignerArr.Length; i++)
                    //{
                    //    if (m_objContent.objSignerArr[i].controlName == "m_lsvhelpers")
                    //        strOperations += m_objContent.objSignerArr[i].objEmployee.m_strGetTechnicalRankAndName + "   ";
                    //}
                    //if (strOperations != "")
                    //{
                    //    p_objGrp.DrawString("住院医师签名：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);

                    //    string strFirstName = new clsEmployee(m_objContent.m_strCreateUserID).m_StrFirstName;
                    //    m_mthMakeText(new string[] { strOperations }, new string[] { "" }, ref strAllText, ref strXml);
                    //}
                    //else
                    //{
                    //    m_blnHaveMoreLine = false;
                    //    return;
                    //}
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(strAllText, strXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);
                    //m_blnIsFirstPrint = false;
                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2 - 50, m_intRecBaseX + 60, p_intPosY, p_objGrp);
                //    p_intPosY += 20;
                //}
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_blnHaveMoreLine = true;
                //}
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
            }
        }

        /// <summary>
        /// 最后诊断日期

        /// </summary>
        private class clsPrintLastDate : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;
            private string strPrintText = "  　";
            private clsInpatMedRec_Item objItemContent = null;
            private Font p_fntNormal = new Font("SimSun", 12, FontStyle.Bold);
            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                string m_strPrint = "日期：";
                if (m_hasItems != null)
                    if (m_hasItems.Contains("最后诊断日期"))
                        m_strPrint += (m_hasItems["最后诊断日期"] as clsInpatMedRec_Item).m_strItemContent;
                
                if (m_blnIsFirstPrint)
                {
                    //if (m_blnCheckBottom(ref p_intPosY, 40, p_intPosY))
                    //{
                    //    m_blnHaveMoreLine = true;
                    //    return;
                    //}

                    p_objGrp.DrawString(m_strPrint, p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    //if (m_hasItemDetail != null && m_hasItemDetail.Contains("病史>>家族史"))
                    //{
                    //    strPrintText += m_hasItemDetail["病史>>家族史"];
                  //  p_intPosY += 20;
                    //}
                    //if (strPrintText != "  　") strPrintText = strPrintText.Remove(strPrintText.Length - 1, 1) + "。";
                    //m_mthPrintInBlock(ref p_intPosY, p_objGrp, p_fntNormalText, strPrintText);
                    //p_fntNormal.Dispose();
                    //m_objPrintContext.m_mthSetContextWithCorrectBefore(objItemContent.m_strItemContent, objItemContent.m_strItemContentXml, m_dtmFirstPrintTime, m_objContent.m_objItemContents != null);

                    m_blnIsFirstPrint = false;
                    m_blnHaveMoreLine = false;
                }

                //int intLine = 0;
                //if (m_objPrintContext.m_BlnHaveNextLine())
                //{
                //    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth, m_intRecBaseX + 70, p_intPosY, p_objGrp);

                //    p_intPosY += 20;

                //    intLine++;
                //}

                //if (m_objPrintContext.m_BlnHaveNextLine())
                //    m_blnHaveMoreLine = true;
                //else
                //{
                //    m_blnHaveMoreLine = false;
                //}

            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();

                m_blnHaveMoreLine = true;

                m_blnIsFirstPrint = true;
            }
        }


        internal static Hashtable m_hasItemDetail;
        /// <summary>
        /// 把所有项按描述为键放入Hastable
        /// </summary>
        /// <param name="p_hasItem"></param>
        /// <param name="p_ctlItem"></param>
        /// <param name="p_objItemArr"></param>
        /// <returns></returns>
        protected override Hashtable m_mthSetHashItem(clsInpatMedRec_Item[] p_objItemArr)
        {
            if (p_objItemArr == null)
                return null;
            Hashtable hasItem = new Hashtable(400);
            m_hasItemDetail = new Hashtable(400);
            foreach (clsInpatMedRec_Item objItem in p_objItemArr)
            {
                try
                {
                    if (objItem.m_strItemContent == null || objItem.m_strItemContent == "" || objItem.m_strItemContent == "False")
                    {
                        continue;
                    }
                    else
                    {
                        m_hasItemDetail.Add(objItem.m_strItemName, objItem.m_strItemContent);
                        hasItem.Add(objItem.m_strItemName, objItem);

                    }
                }
                catch { continue; }
            }
            return hasItem;
        }
    

        /// <summary>
        /// 修正诊断
        /// </summary>
        private class clsPrintInPatMedRecDia2 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("修正诊断"))
                        objItemContent1 = m_hasItems["修正诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("修正诊断医师签名"))
                        objItemContent2 = m_hasItems["修正诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("修正诊断医师签名日期"))
                        objItemContent3 = m_hasItems["修正诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("修正诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("修正诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) +
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }

        /// <summary>
        /// 补充诊断
        /// </summary>
        private class clsPrintInPatMedRecDia3 : clsIMR_PrintLineBase
        {
            private clsPrintRichTextContext m_objPrintContext = new clsPrintRichTextContext(Color.Black, new Font("", 10));

            private clsInpatMedRec_Item objItemContent1 = null;
            private clsInpatMedRec_Item objItemContent2 = null;
            private clsInpatMedRec_Item objItemContent3 = null;
            /// <summary>
            /// 相同的内容只打印一次(而不是首次打印时间对应的m_blnIsFirstPrint)
            /// </summary>
            private bool m_blnIsFirstPrint = true;

            public override void m_mthPrintNextLine(ref int p_intPosY, System.Drawing.Graphics p_objGrp, System.Drawing.Font p_fntNormalText)
            {
                if (m_hasItems != null)
                {
                    if (m_hasItems.Contains("补充诊断"))
                        objItemContent1 = m_hasItems["修正诊断"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("补充诊断医师签名"))
                        objItemContent2 = m_hasItems["补充诊断医师签名"] as clsInpatMedRec_Item;
                    if (m_hasItems.Contains("补充诊断医师签名日期"))
                        objItemContent3 = m_hasItems["补充诊断医师签名日期"] as clsInpatMedRec_Item;
                }
                if (objItemContent1 == null)
                {
                    m_blnHaveMoreLine = false;
                    return;
                }

                if (m_blnIsFirstPrint)
                {
                    p_objGrp.DrawString("补充诊断：", p_fntNormalText, Brushes.Black, m_intRecBaseX + 10, p_intPosY);
                    p_intPosY += 20;
                    m_objPrintContext.m_mthSetContextWithCorrectBefore((objItemContent1 == null ? "" : objItemContent1.m_strItemContent), (objItemContent1 == null ? "<root />" : objItemContent1.m_strItemContentXml), m_dtmFirstPrintTime, objItemContent1 != null);
                    m_mthAddSign2("补充诊断：", m_objPrintContext.m_ObjModifyUserArr);
                    m_blnIsFirstPrint = false;
                }

                int intLine = 0;
                if (m_objPrintContext.m_BlnHaveNextLine())
                {
                    m_objPrintContext.m_mthPrintLine((int)enmRectangleInfoInPatientCaseInfo.PrintWidth2, m_intRecBaseX + 10, p_intPosY, p_objGrp);
                    p_intPosY += 20;
                    intLine++;
                }

                if (m_objPrintContext.m_BlnHaveNextLine())
                    m_blnHaveMoreLine = true;
                else
                {
                    p_objGrp.DrawString("医师签名：  " + ((objItemContent2 == null || objItemContent2.m_strItemContent == null) ? "" : objItemContent2.m_strItemContent) +
                        "  签名日期：  " + ((objItemContent3 == null || objItemContent3.m_strItemContent == null) ? "" : objItemContent3.m_strItemContent), p_fntNormalText, Brushes.Black, m_intRecBaseX + 200, p_intPosY);
                    p_intPosY += 20;
                    m_blnHaveMoreLine = false;
                }
            }

            public override void m_mthReset()
            {
                m_objPrintContext.m_mthRestartPrint();
                m_blnHaveMoreLine = true;
                m_blnIsFirstPrint = true;
                objItemContent1 = null;
                objItemContent2 = null;
                objItemContent3 = null;
            }
        }
	}
}
