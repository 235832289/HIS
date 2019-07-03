using System;
using System.Collections;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// Summary description for clsCheckReportWithAnnotation.
    /// </summary>
    public class clsCheckReportWithAnnotation : infPrintRecord
    {
        private long m_lngWidthPage;//打印页的宽度
        private long m_lngY;//当前Y方向坐标

        private float m_fltLeftIndentProp;//左缩进比例
        private float m_fltRightIndentProp;//右缩进比例

        private Font m_fntTitle;
        private Font m_fntSmallBold;
        private Font m_fntSmallNotBold;
        private Font m_fntSmall2NotBold;
        private Font m_fntHeadNotBold;

        public float m_fltItemSpace;//检验项目的间距



        public System.Data.DataTable m_dtbSample = null;//基本信息及评语
        public System.Data.DataTable m_dtbResult;//检验结果
        public System.Data.DataTable m_dtbDeviceID_Name;//检验设备ID到项目名字的映射
        public bool m_bolFinishPrint = false;

        public string strComment = "";//评语
        public string strComment_XML = "";//评语XML

        public string m_strTitle;//报告单标题

        private int m_intPageCount;//打印的总页数
        private int m_intCurrentPage;//打印的当前页
        private int m_intEachSideCount;//每列打印项目的个数
        private int m_intEachPageSideCount;//每列的页打印个数
        private int m_intEachSideItemHeight;//每列打印项目的总高度
        private int m_intEachPageSideItemHeight;//每列页打印项目的总高度

        public bool m_blnDocked = true;//判断报告单底部信息位置是否固定
        public long m_lngEndPosition;//报告单底部打印的位置
        public bool m_blnHasTwoPart = false;//判断报告单结果打印是否有两边
        public bool m_blnPrintSummary = true;//判断是否打印实验室提示
        private bool m_blnHasPrintGroup = false;//判断是否打印了项目

        public float m_fltItemAndResultSpace;//项目名称和结果之间的距离
        public float m_fltResultAndRefSpace;//结果和参考范围之间的距离

        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;

        #region 打印报告起始部分
        /// <summary>
        /// 打印报告起始部分
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthPrintStart(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            //			if(m_dtbSample != null)
            //			{
            //				TransactdtbSampleToSampleVO();
            //			}

            m_lngWidthPage = p_objPrintArg.PageBounds.Width;

            m_strTitle = m_dtbSample.Rows[0]["print_title_vchr"].ToString().Trim();//"佛山市第二人民医院检验报告单";
            SizeF szTitle = p_objPrintArg.Graphics.MeasureString(m_strTitle, m_fntTitle);
            float fltCurrentX = m_lngWidthPage / 2 - (long)szTitle.Width / 2;//标题文本左上角的X轴坐标
            m_lngY = 10;//标题文本左上角Y轴坐标
            p_objPrintArg.Graphics.DrawString(m_strTitle, m_fntTitle, Brushes.Black, fltCurrentX, m_lngY);

            m_lngY = 20 + (int)szTitle.Height;
            SizeF szTmp = p_objPrintArg.Graphics.MeasureString("姓名:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("姓名:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["patient_name_vchr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("住院号:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.85f / 4);
            p_objPrintArg.Graphics.DrawString("住院号:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["PATIENT_INHOSPITALNO_CHR"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("样本类型:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.95f / 2);
            p_objPrintArg.Graphics.DrawString("样本类型:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            szTmp = p_objPrintArg.Graphics.MeasureString("样本号:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2.9f / 4);
            p_objPrintArg.Graphics.DrawString("样本号:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["sample_id_chr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            m_lngY = 25 + (int)szTitle.Height + (int)m_fntSmallBold.Height;
            szTmp = p_objPrintArg.Graphics.MeasureString("性别:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("性别:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["sex_chr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("科  室:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.85f / 4);
            p_objPrintArg.Graphics.DrawString("科  室:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["deptname_vchr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("送检医生:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.95f / 2);
            p_objPrintArg.Graphics.DrawString("送检医生:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["applyer"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("检验编号:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2.9f / 4);
            p_objPrintArg.Graphics.DrawString("检验编号:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["check_no_chr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);


            m_lngY = 30 + (int)szTitle.Height + (int)m_fntSmallBold.Height * 2;
            szTmp = p_objPrintArg.Graphics.MeasureString("年龄:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * m_fltLeftIndentProp;
            p_objPrintArg.Graphics.DrawString("年龄:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["age_chr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("床  号:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.85f / 4);
            p_objPrintArg.Graphics.DrawString("床  号:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["bedno_chr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("临床诊断:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 0.95f / 2);
            p_objPrintArg.Graphics.DrawString("临床诊断:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["diagnose_vchr"].ToString().Trim(), m_fntHeadNotBold, Brushes.Black,
                fltCurrentX, m_lngY);

            szTmp = p_objPrintArg.Graphics.MeasureString("送检日期:", m_fntSmallBold);
            fltCurrentX = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2.9f / 4);
            p_objPrintArg.Graphics.DrawString("送检日期:", m_fntSmallBold, Brushes.Black, fltCurrentX, m_lngY);
            fltCurrentX += szTmp.Width + 4;
            string strAcceptDate = "";
            if (Microsoft.VisualBasic.Information.IsDate(m_dtbSample.Rows[0]["accept_dat"].ToString().Trim()))
            {
                strAcceptDate = DateTime.Parse(m_dtbSample.Rows[0]["accept_dat"].ToString().Trim()).ToString("yyyy-MM-dd");
            }
            else
            {
                strAcceptDate = "";
            }
            p_objPrintArg.Graphics.DrawString(strAcceptDate,
                m_fntHeadNotBold, Brushes.Black, fltCurrentX, m_lngY);

        }

        private void m_mthPrintLine(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            m_lngY += 2 + m_fntSmallBold.Height;
            long intYStart = m_lngY;

            //画横线
            p_objPrintArg.Graphics.DrawLine(m_GridPen, m_lngWidthPage * 0.08f, intYStart, m_lngWidthPage * 0.92f, intYStart);
            //			p_objPrintArg.Graphics.DrawString(intYStart.ToString(),m_fntSmallNotBold,Brushes.Black,m_lngWidthPage*0.92f,intYStart);
            //			long intYMiddle=intYStart+8+m_fntSmallBold.Height;
            //			p_objPrintArg.Graphics.DrawLine(m_GridPen,m_lngWidthPage*0.08f,intYMiddle,m_lngWidthPage*0.92f,intYMiddle);

        }
        #endregion


        #region 打印正文
        /// <summary>
        /// 打印报告单中间部分
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthPrintMiddle(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            #region old
            //			m_lngY+=6;
            //			float[] fltColumnXArr=new float[4];
            //			fltColumnXArr[0]=m_lngWidthPage*m_fltLeftIndentProp;
            //			p_objPrintArg.Graphics.DrawString("项目名称",m_fntSmallBold,Brushes.Black,fltColumnXArr[0],m_lngY);
            //
            //			fltColumnXArr[1]=m_lngWidthPage*(m_fltLeftIndentProp+(1-m_fltLeftIndentProp-m_fltRightIndentProp)/4+0.07f);
            //			p_objPrintArg.Graphics.DrawString(" 结果",m_fntSmallBold,Brushes.Black,fltColumnXArr[1],m_lngY);
            //
            //			fltColumnXArr[2]=m_lngWidthPage*(m_fltLeftIndentProp+(1-m_fltLeftIndentProp-m_fltRightIndentProp)/2+0.04f);
            //			p_objPrintArg.Graphics.DrawString("参考范围",m_fntSmallBold,Brushes.Black,fltColumnXArr[2],m_lngY);
            //
            //			fltColumnXArr[3]=m_lngWidthPage*(m_fltLeftIndentProp+(1-m_fltLeftIndentProp-m_fltRightIndentProp)*3/4+0.07f);
            //			p_objPrintArg.Graphics.DrawString("单位",m_fntSmallBold,Brushes.Black,fltColumnXArr[3],m_lngY);
            //
            //			//定位Y轴坐标
            //			float fltCurrentY = m_lngY;
            //			for(int i=0;i<m_dtbResult.Rows.Count;i++)
            //			{
            //				string strResult=m_dtbResult.Rows[i]["result_vchr"].ToString().Trim();
            //				string strAbnormal = m_dtbResult.Rows[i]["ABNORMAL_FLAG_CHR"].ToString().Trim();
            //				string strRefRange=m_dtbResult.Rows[i]["refrange_vchr"].ToString();
            //				string strMinVal = m_dtbResult.Rows[i]["MIN_VAL_DEC"].ToString().Trim();
            //				string strMaxVal = m_dtbResult.Rows[i]["MAX_VAL_DEC"].ToString().Trim();
            //				string strCheckItemName = m_dtbResult.Rows[i]["CHECK_ITEM_NAME_VCHR"].ToString().Trim();
            //				string strDeviceCheckItemName = m_dtbResult.Rows[i]["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
            //				string strUnit = m_dtbResult.Rows[i]["UNIT_VCHR"].ToString().Trim();
            //				double doubleResult = -1; //当结果为文字型时，此值默认为－1
            //				double doubleMinVal = -1;
            //				double doubleMaxVal = -1;
            //
            //				fltCurrentY += 8+m_fntSmallBold.Height;
            //				p_objPrintArg.Graphics.DrawString(strCheckItemName+"("+strDeviceCheckItemName+")",m_fntSmallNotBold,Brushes.Black,fltColumnXArr[0],fltCurrentY);
            //				//1.根据异常标志判断,此处认为异常标志只有"H"(高)和"L"(低)两种情况
            //				if(strAbnormal !=null)
            //				{
            //					if(strAbnormal == "H")
            //					{
            //						p_objPrintArg.Graphics.DrawString("↑"+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //					}
            //					else if(strAbnormal == "L")
            //					{
            //						p_objPrintArg.Graphics.DrawString("↓"+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //					}
            //					else
            //					{
            //						p_objPrintArg.Graphics.DrawString("  "+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //					}
            //				}
            //				else
            //				{
            //					//2.根据最大值最小值判断
            //					try
            //					{
            //						doubleResult = double.Parse(strResult);
            //						doubleMinVal = double.Parse(strMinVal);
            //						doubleMaxVal = double.Parse(strMaxVal);
            //					}
            //					catch(Exception objEx)
            //					{
            //						//throw objEx;
            //					}
            //					finally
            //					{
            //						if(doubleResult != -1)
            //						{
            //							if(doubleResult < doubleMinVal)
            //							{
            //								p_objPrintArg.Graphics.DrawString("↓"+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //							}
            //							else if(doubleResult > doubleMaxVal)
            //							{
            //								p_objPrintArg.Graphics.DrawString("↑"+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //							}
            //							else
            //							{
            //								p_objPrintArg.Graphics.DrawString("  "+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //							}
            //						}
            //						else
            //						{
            //							p_objPrintArg.Graphics.DrawString("  "+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
            //						}
            //					}
            //				}
            //				p_objPrintArg.Graphics.DrawString(strRefRange,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[2],fltCurrentY);
            //				p_objPrintArg.Graphics.DrawString(strUnit,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[3],fltCurrentY);
            //			}
            //			m_lngY = (long)fltCurrentY;
            #endregion

            //			if(m_dtbDeviceID_Name == null) 
            //				return;

            //			m_lngY+=10+m_fntSmallBold.Height;

            try
            {
                ArrayList arlTempLeft = new ArrayList();//存放打印在左栏的Group
                ArrayList arlTempRight = new ArrayList();//存放打印在右栏的Group

                //对标本组排序
                DataView dtvResult = new DataView(m_dtbResult);
                dtvResult.Sort = "REPORT_PRINT_SEQ_INT ASC,SAMPLE_PRINT_SEQ_INT ASC";

                #region 根据设备映射表从结果集表中得到各个 Group 并暂时放在 arlTempLeft 中
                //				for(int i=0;i<m_dtbDeviceID_Name.Rows.Count;i++)
                //				{
                //					DataView dtvGroupData = new DataView(this.m_dtbResult);
                //
                //					dtvGroupData.RowFilter = "DEVICEID_CHR = '" + m_dtbDeviceID_Name.Rows[i][0].ToString().Trim() + "'";
                //					if(dtvGroupData.Count != 0)
                //					{
                //						clsGroup objGroup = new clsGroup();
                //						objGroup.m_dtvGroupData = dtvGroupData;
                //						objGroup.m_strGroupName = m_dtbDeviceID_Name.Rows[i][1].ToString().Trim();
                //						arlTempLeft.Add(objGroup);
                //					}
                //				}
                #endregion

                #region 根据GROUPID_CHR从结果集表中得到各个Group并暂时放在 arlTempLeft 中
                //获取所有的报告组标题
                //				ArrayList arlGroupID = new ArrayList();
                //				for(int i=0;i<dtvResult.Count;i++)
                //				{
                //					bool blnHasSameGroup = false;
                //					for(int j=0;j<arlGroupID.Count;j++)
                //					{
                //						if(dtvResult[i]["GROUPID_CHR"].ToString().Trim() == arlGroupID[j].ToString().Trim())
                //						{
                //							blnHasSameGroup = true;
                //							break;
                //						}
                //					}
                //					if(!blnHasSameGroup)
                //					{
                //						string strGroupID = dtvResult[i]["GROUPID_CHR"].ToString().Trim();
                //						arlGroupID.Add(strGroupID);
                //					}
                //				}
                //				//存放各报告组
                //				for(int i=0;i<arlGroupID.Count;i++)
                //				{
                //					DataView dtvGroupData = new DataView(this.m_dtbResult);
                //
                //					dtvGroupData.RowFilter = "GROUPID_CHR = '"+arlGroupID[i].ToString().Trim()+"'";
                //					if(dtvGroupData.Count > 0)
                //					{
                //						clsGroup objGroup = new clsGroup();
                //						objGroup.m_dtvGroupData = dtvGroupData;
                //						objGroup.m_dtvGroupData.Sort = "SAMPLE_PRINT_SEQ_INT ASC";
                //						objGroup.m_strGroupName = arlGroupID[i].ToString().Trim();
                //						arlTempLeft.Add(objGroup);
                //					}
                //				}
                #endregion

                //				this.m_mthAdmeasureGroup(ref arlTempLeft,ref arlTempRight);

                //				this.m_mthDistributeGroup(ref arlTempLeft,ref arlTempRight);
                ArrayList arlPage;
                //				m_mthPrintDistribute(dtvResult,out arlPage);
                m_mthAutoDistribute(dtvResult, out arlPage);

                float fltLeftX = m_lngWidthPage * m_fltLeftIndentProp - 10f;//左栏打印的 X 起始点
                float fltRightX = m_lngWidthPage * 0.5f;//右栏打印的 X 起始点
                float fltLeftY = m_lngY;//左栏打印的 Y 起始点
                float fltRightY = m_lngY;//右栏打印的 Y 起始点
                float fltWidth = m_lngWidthPage * (1 - m_fltLeftIndentProp * 2) / 2 + 10f;// 分栏的宽度 
                string strGroupName;

                #region 打印Group
                bool blnIsTop = true;
                for (int j = 0; j < arlPage.Count; j++)
                {
                    if (j == m_intCurrentPage - 1)
                    {
                        ArrayList[] arlResult = (ArrayList[])arlPage[j];
                        if (arlResult[0] != null)
                        {
                            if (m_intCurrentPage == arlPage.Count - 1)
                            {
                                m_blnHasPrintGroup = true;
                            }
                            for (int i = 0; i < arlResult[0].Count; i++)
                            {
                                if (i > 0)
                                {
                                    blnIsTop = false;
                                }
                                else
                                {
                                    blnIsTop = true;
                                }
                                clsGroup objGroup = (clsGroup)arlResult[0][i];//arlTempLeft[i];
                                float fltEndY;
                                strGroupName = objGroup.m_dtvGroupData[0].Row["PRINT_TITLE_VCHR"].ToString().Trim();//objGroup.m_strGroupName + "机测项目";
                                this.m_mthPrintGroup(p_objPrintArg, objGroup.m_dtvGroupData, strGroupName, fltLeftX, fltLeftY, fltWidth, out fltEndY, blnIsTop);
                                fltLeftY = fltEndY;
                                //					p_objPrintArg.Graphics.DrawString((fltEndY-4 - m_fntSmallBold.Height+m_fltItemSpace).ToString().Trim(),m_fntSmallBold,Brushes.Black,m_lngWidthPage*0.8f,fltEndY-4 - m_fntSmallBold.Height+m_fltItemSpace);
                            }
                        }
                        if (arlResult[1] != null)
                        {
                            for (int i = 0; i < arlResult[1].Count; i++)
                            {
                                if (i > 0)
                                {
                                    blnIsTop = false;
                                }
                                else
                                {
                                    blnIsTop = true;
                                }
                                clsGroup objGroup = (clsGroup)arlResult[1][i];//arlTempRight[i];
                                float fltEndY;
                                strGroupName = objGroup.m_dtvGroupData[0].Row["PRINT_TITLE_VCHR"].ToString().Trim();//objGroup.m_strGroupName + "机测项目";
                                this.m_mthPrintGroup(p_objPrintArg, objGroup.m_dtvGroupData, strGroupName, fltRightX, fltRightY, fltWidth, out fltEndY, blnIsTop);
                                fltRightY = fltEndY;
                            }
                        }
                    }
                }
                #endregion

                float fltBodyEndY = 0;
                if (fltLeftY >= fltRightY)
                {
                    fltBodyEndY = fltLeftY;
                }
                else
                {
                    fltBodyEndY = fltRightY;
                }
                //				if(arlTempRight.Count != 0)//有两栏则打印一竖线
                //					p_objPrintArg.Graphics.DrawLine(m_GridPen,m_lngWidthPage*0.5f,m_lngY,m_lngWidthPage*0.5f,fltBodyEndY);

                this.m_lngY = (long)fltBodyEndY;//- m_fntSmallNotBold.Height;
            }
            catch { }
        }

        #region unuse
        /// <summary>
        /// 以近似平衡分配算法来分配左右两边要打印的 Group
        /// </summary>
        /// <param name="p_arlLeft"></param>
        /// <param name="p_arlRight"></param>
        private void m_mthAdmeasureGroup(ref ArrayList p_arlLeft, ref ArrayList p_arlRight)
        {
            try
            {
                #region 合并到 p_arlLeft,置空 p_arlRight

                p_arlLeft.AddRange(p_arlRight);
                p_arlRight.Clear();

                #endregion

                if (p_arlLeft.Count == 0)
                    return;

                #region 排序到 p_arlRight,置空 p_arlLeft

                for (int i1 = 0; i1 < p_arlLeft.Count; i1++)
                {
                    for (int j2 = 0; j2 <= p_arlRight.Count; j2++)
                    {
                        if (j2 == p_arlRight.Count)
                        {
                            p_arlRight.Add(p_arlLeft[i1]);
                            break;
                        }
                        if (((clsGroup)p_arlLeft[i1]).m_dtvGroupData.Count > ((clsGroup)p_arlRight[j2]).m_dtvGroupData.Count)
                        {
                            p_arlRight.Insert(j2, p_arlLeft[i1]);
                            break;
                        }
                    }
                }
                p_arlLeft.Clear();
                #endregion

                #region 近似平衡分配算法

                int intLeft = 0;
                int intRight = 0;

                ArrayList arlRightTemp = new ArrayList();
                for (int i = 0; i < p_arlRight.Count; i++)
                {
                    if (intLeft <= intRight)
                    {
                        p_arlLeft.Add(p_arlRight[i]);
                        intLeft += ((clsGroup)p_arlRight[i]).m_dtvGroupData.Count;
                    }
                    else
                    {
                        arlRightTemp.Add(p_arlRight[i]);
                        intRight += ((clsGroup)p_arlRight[i]).m_dtvGroupData.Count;
                    }
                }

                p_arlRight = arlRightTemp;

                #endregion
            }
            catch { }
        }

        /// <summary>
        /// 暂时只考虑到一个报告组的情况
        /// </summary>
        /// <param name="p_arlLeft"></param>
        /// <param name="p_arlRight"></param>
        private void m_mthDistributeGroup(ref ArrayList p_arlLeft, ref ArrayList p_arlRight)
        {
            try
            {
                #region 合并到 p_arlLeft,置空 p_arlRight

                p_arlLeft.AddRange(p_arlRight);
                p_arlRight.Clear();

                #endregion

                if (p_arlLeft.Count == 0)
                    return;

                ArrayList arlLeftTemp = new ArrayList();

                for (int i = 0; i < p_arlLeft.Count; i++)
                {
                    clsGroup objRightGroup = new clsGroup();
                    clsGroup objLeftGroup = new clsGroup();

                    DataTable dtbLeft = ((clsGroup)p_arlLeft[i]).m_dtvGroupData.Table.Clone();
                    DataTable dtbRight = ((clsGroup)p_arlLeft[i]).m_dtvGroupData.Table.Clone();

                    if (((clsGroup)p_arlLeft[0]).m_dtvGroupData.Count > (m_intCurrentPage - 1) * m_intEachSideCount * 2 + m_intEachSideCount)
                    {
                        m_blnHasTwoPart = true;
                        //左边的列
                        for (int j = (m_intCurrentPage - 1) * m_intEachSideCount * 2; j < (m_intCurrentPage - 1) * m_intEachSideCount * 2 + m_intEachSideCount; j++)
                        {
                            DataRow dr = dtbLeft.NewRow();
                            dr.ItemArray = ((clsGroup)p_arlLeft[i]).m_dtvGroupData[j].Row.ItemArray;
                            dtbLeft.Rows.Add(dr);
                        }

                        //右边的列
                        int intEnd;
                        if ((m_intCurrentPage - 1) * m_intEachSideCount * 2 + 2 * m_intEachSideCount < ((clsGroup)p_arlLeft[i]).m_dtvGroupData.Count)
                        {
                            intEnd = (m_intCurrentPage - 1) * m_intEachSideCount * 2 + 2 * m_intEachSideCount;
                        }
                        else
                        {
                            intEnd = ((clsGroup)p_arlLeft[i]).m_dtvGroupData.Count;
                        }
                        for (int j = (m_intCurrentPage - 1) * m_intEachSideCount * 2 + m_intEachSideCount; j < intEnd; j++)
                        {
                            DataRow dr = dtbRight.NewRow();
                            dr.ItemArray = ((clsGroup)p_arlLeft[i]).m_dtvGroupData[j].Row.ItemArray;
                            dtbRight.Rows.Add(dr);
                        }

                        DataView dtvLeftGroup = new DataView(dtbLeft);
                        objLeftGroup.m_dtvGroupData = dtvLeftGroup;
                        objLeftGroup.m_strGroupName = ((clsGroup)p_arlLeft[i]).m_strGroupName;
                        arlLeftTemp.Add(objLeftGroup);

                        DataView dtvRightGroup = new DataView(dtbRight);
                        objRightGroup.m_dtvGroupData = dtvRightGroup;
                        objRightGroup.m_strGroupName = ((clsGroup)p_arlLeft[i]).m_strGroupName;
                        p_arlRight.Add(objRightGroup);

                    }
                    else
                    {
                        for (int j = (m_intCurrentPage - 1) * m_intEachSideCount * 2; j < ((clsGroup)p_arlLeft[i]).m_dtvGroupData.Count; j++)
                        {
                            DataRow dr = dtbLeft.NewRow();
                            dr.ItemArray = ((clsGroup)p_arlLeft[i]).m_dtvGroupData[j].Row.ItemArray;
                            dtbLeft.Rows.Add(dr);
                        }

                        DataView dtvLeftGroup = new DataView(dtbLeft);
                        objLeftGroup.m_dtvGroupData = dtvLeftGroup;
                        objLeftGroup.m_strGroupName = ((clsGroup)p_arlLeft[i]).m_strGroupName;
                        arlLeftTemp.Add(objLeftGroup);
                        if (p_arlLeft.Count > 1)
                        {
                            m_blnHasTwoPart = true;
                            p_arlRight.Add(p_arlLeft[i + 1]);
                            i++;
                        }
                    }
                }
                p_arlLeft = arlLeftTemp;
                //				for(int i=1;i<p_arlLeft.Count;i++)
                //				{
                //					p_arlRight.Add(p_arlLeft[i]);
                //				}
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }

        public void m_mthPrintDistribute(DataView p_dtvResult, out ArrayList p_arlPage)
        {
            p_arlPage = new ArrayList(m_intPageCount);
            p_dtvResult.Sort = "REPORT_PRINT_SEQ_INT ASC,groupid_chr ASC,SAMPLE_PRINT_SEQ_INT ASC";
            int intLeftEnd = 0;
            int intRightEnd = 0;

            for (int i = 0; i < m_intPageCount; i++)
            {
                ArrayList p_arlLefGroup = new ArrayList();
                ArrayList p_arlRightGroup = new ArrayList();

                DataTable dtbLeft = p_dtvResult.Table.Clone();
                DataTable dtbRight = p_dtvResult.Table.Clone();

                intLeftEnd = intRightEnd + m_intEachSideCount;
                //理想状态的左侧打印的项目个数
                int intLeftIdearLength = intRightEnd + m_intEachSideCount;

                if (intLeftEnd < p_dtvResult.Count)
                {
                    intLeftEnd = intRightEnd + m_intEachSideCount;
                }
                else
                {
                    intLeftEnd = p_dtvResult.Count;
                }

                ArrayList arlGroupID = new ArrayList();
                int intLeftDropRowCount = 0;
                for (int j = intRightEnd; j < intLeftEnd; j++)
                {
                    bool blnLeftEndAndChange = false;
                    if (j > intRightEnd)
                    {
                        if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                        {
                            //							arlGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                            if (j < intLeftEnd - 2)
                            {
                                arlGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                //								intLeftEnd = intLeftEnd-2;
                                //								if(intLeftIdearLength-2<p_dtvResult.Count)
                                //								{
                                //									intLeftEnd = intLeftEnd-1;
                                //								}
                                //								intLeftIdearLength = intLeftIdearLength-1;
                            }
                            else
                            {
                                blnLeftEndAndChange = true;
                                intLeftDropRowCount = intLeftEnd - j;
                            }
                        }
                    }
                    else
                    {
                        arlGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                    }
                    if (!blnLeftEndAndChange)
                    {
                        DataRow dr = dtbLeft.NewRow();
                        dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                        dtbLeft.Rows.Add(dr);
                    }
                    //					}
                }

                intLeftEnd = intLeftEnd - intLeftDropRowCount;

                for (int j = 0; j < arlGroupID.Count; j++)
                {
                    clsGroup objLeftGroup = new clsGroup();
                    DataView dtvLeft = new DataView(dtbLeft);
                    dtvLeft.RowFilter = "groupid_chr = '" + arlGroupID[j].ToString().Trim() + "'";
                    objLeftGroup.m_dtvGroupData = dtvLeft;
                    objLeftGroup.m_strGroupName = dtbLeft.Rows[0]["print_title_vchr"].ToString().Trim();
                    p_arlLefGroup.Add(objLeftGroup);
                }

                if (intLeftEnd < p_dtvResult.Count)
                {
                    m_blnHasTwoPart = true;
                    //理想状态的右侧打印的项目个数
                    int intRightIdearLength = intLeftEnd + m_intEachSideCount;
                    if (intLeftEnd + m_intEachSideCount < p_dtvResult.Count)
                    {
                        intRightEnd = intLeftEnd + m_intEachSideCount;
                    }
                    else
                    {
                        intRightEnd = p_dtvResult.Count;
                    }

                    ArrayList arlRightGroupID = new ArrayList();
                    int intRightDropRowCount = 0;
                    for (int j = intLeftEnd; j < intRightEnd; j++)
                    {
                        bool blnRightEndAndChange = false;
                        if (j > intLeftEnd)
                        {
                            if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                            {
                                if (j < intRightEnd - 2)
                                {
                                    arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                    //									intRightIdearLength = intRightIdearLength-2;
                                    //									if(intRightIdearLength<intRightEnd)
                                    //									{
                                    //										intRightEnd = intRightEnd-2;
                                    //									}
                                }
                                else
                                {
                                    blnRightEndAndChange = true;
                                    intRightDropRowCount += intRightEnd - j;
                                }
                            }
                        }
                        else
                        {
                            arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                        }

                        if (!blnRightEndAndChange)
                        {
                            DataRow dr = dtbRight.NewRow();
                            dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                            dtbRight.Rows.Add(dr);
                        }
                    }

                    intRightEnd = intRightEnd - intRightDropRowCount;

                    for (int j = 0; j < arlRightGroupID.Count; j++)
                    {
                        clsGroup objRightGroup = new clsGroup();
                        DataView dtvRightGroup = new DataView(dtbRight);
                        dtvRightGroup.RowFilter = "groupid_chr = '" + arlRightGroupID[j].ToString().Trim() + "'";
                        objRightGroup.m_dtvGroupData = dtvRightGroup;
                        objRightGroup.m_strGroupName = dtbRight.Rows[0]["print_title_vchr"].ToString().Trim();
                        p_arlRightGroup.Add(objRightGroup);
                    }
                    if (intRightEnd < p_dtvResult.Count && m_intPageCount <= i + 1)
                    {
                        m_intPageCount++;
                    }
                }
                ArrayList[] arlTemp = new ArrayList[2];
                arlTemp[0] = p_arlLefGroup;
                arlTemp[1] = p_arlRightGroup;
                p_arlPage.Add(arlTemp);
            }
        }
        #endregion


        //1.判断打印的记录是否能按标准格式在一页打完
        //1.1 Y 打印
        //1.1.1 打印完一个group
        //1.1.1.1 判断余下的记录能否在另一边打完,并且当前已经打印的记录个数必须大于或等于单列打印个数的1/2
        //1.1.1.1.1 Y 转到另一边打印
        //1.1.1.1.2 N 判断该列还可以打印的记录个数是否>3
        //1.1.1.1.2.1 Y 继续打印
        //1.1.1.1.2.2.N 转到另一边打印
        //1.2 N GoTo 2
        //2.判断打印的记录是否能按极限格式在一页打完
        //2.1 Y 打印
        //2.1.1 打印完一个group判断，余下的记录能否在另一边打完,并且当前已经打印的记录个数必须大于或等于单列打印个数的1/2
        //2.1.1.1 Y 转到另一边打印
        //2.1.1.2 N 继续打印
        //2.2 N 打印 换页

        public void m_mthAutoDistribute(DataView p_dtvResult, out ArrayList p_arlPage)
        {
            p_arlPage = new ArrayList(m_intPageCount);
            p_dtvResult.Sort = "REPORT_PRINT_SEQ_INT ASC,groupid_chr ASC,SAMPLE_PRINT_SEQ_INT ASC";
            int intLeftEnd = 0;
            int intRightEnd = 0;

            for (int i = 0; i < m_intPageCount; i++)
            {
                //1
                if (p_dtvResult.Count <= intRightEnd + 2 * m_intEachSideCount)
                {
                    //1.1
                    #region 打印左边
                    ArrayList arlLeftGroupID = new ArrayList();
                    ArrayList arlLeftGroup = new ArrayList();

                    DataTable dtbLeft = p_dtvResult.Table.Clone();

                    if (p_dtvResult.Count <= (intRightEnd + m_intEachSideCount))
                    {
                        intLeftEnd = p_dtvResult.Count;
                    }
                    else
                    {
                        intLeftEnd = intRightEnd + m_intEachSideCount;
                    }
                    for (int j = intRightEnd; j < intLeftEnd; j++)
                    {
                        if (j > intRightEnd)
                        {
                            if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                            {
                                if (j >= (intRightEnd + m_intEachSideCount / 2 - 1) && (p_dtvResult.Count - j + 1) < m_intEachSideCount)
                                {
                                    intLeftEnd = j;
                                    break;
                                }
                                else
                                {
                                    if (intLeftEnd - j > 3)
                                    {
                                        arlLeftGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                    }
                                    else
                                    {
                                        intLeftEnd = j;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            arlLeftGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                        }

                        DataRow dr = dtbLeft.NewRow();
                        dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                        dtbLeft.Rows.Add(dr);
                    }

                    //构造打印的Group
                    for (int j = 0; j < arlLeftGroupID.Count; j++)
                    {
                        clsGroup objLeftGroup = new clsGroup();
                        DataView dtvLeft = new DataView(dtbLeft);
                        dtvLeft.RowFilter = "groupid_chr = '" + arlLeftGroupID[j].ToString().Trim() + "'";
                        objLeftGroup.m_dtvGroupData = dtvLeft;
                        objLeftGroup.m_strGroupName = dtbLeft.Rows[0]["print_title_vchr"].ToString().Trim();
                        arlLeftGroup.Add(objLeftGroup);
                    }
                    #endregion
                    #region 打印右边
                    if (intLeftEnd < p_dtvResult.Count)
                    {
                        //分边打印
                        m_blnHasTwoPart = true;

                        ArrayList arlRightGroupID = new ArrayList();
                        ArrayList arlRightGroup = new ArrayList();

                        DataTable dtbRight = p_dtvResult.Table.Clone();

                        intRightEnd = intLeftEnd + m_intEachSideCount;
                        if (intRightEnd > p_dtvResult.Count)
                        {
                            intRightEnd = p_dtvResult.Count;
                        }
                        for (int j = intLeftEnd; j < intRightEnd; j++)
                        {
                            if (j > intLeftEnd)
                            {
                                if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                                {
                                    arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                }
                            }
                            else
                            {
                                arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                            }

                            DataRow dr = dtbRight.NewRow();
                            dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                            dtbRight.Rows.Add(dr);
                        }

                        //构造打印的RightGroup
                        for (int j = 0; j < arlRightGroupID.Count; j++)
                        {
                            clsGroup objRightGroup = new clsGroup();
                            DataView dtvRight = new DataView(dtbRight);
                            dtvRight.RowFilter = "groupid_chr = '" + arlRightGroupID[j].ToString().Trim() + "'";
                            objRightGroup.m_dtvGroupData = dtvRight;
                            objRightGroup.m_strGroupName = dtbRight.Rows[0]["print_title_vchr"].ToString().Trim();
                            arlRightGroup.Add(objRightGroup);
                        }
                        ArrayList[] arlTemp = new ArrayList[2];
                        arlTemp[0] = arlLeftGroup;
                        arlTemp[1] = arlRightGroup;
                        p_arlPage.Add(arlTemp);
                    }
                    else
                    {
                        intRightEnd = intLeftEnd;
                        ArrayList[] arlTemp = new ArrayList[2];
                        arlTemp[0] = arlLeftGroup;
                        arlTemp[1] = null;
                        p_arlPage.Add(arlTemp);
                    }
                    #endregion
                    if (intRightEnd >= p_dtvResult.Count)
                    {
                        m_intPageCount = i;
                    }
                }
                else if (p_dtvResult.Count <= intRightEnd + 2 * m_intEachPageSideCount)
                {
                    //2.1
                    #region 打印左边
                    ArrayList arlLeftGroupID = new ArrayList();
                    ArrayList arlLeftGroup = new ArrayList();

                    DataTable dtbLeft = p_dtvResult.Table.Clone();
                    //					int intLeftEnd = 0;

                    if (p_dtvResult.Count <= intRightEnd + m_intEachPageSideCount)
                    {
                        intLeftEnd = p_dtvResult.Count;
                    }
                    else
                    {
                        intLeftEnd = intRightEnd + m_intEachPageSideCount;
                    }
                    for (int j = intRightEnd; j < intLeftEnd; j++)
                    {
                        if (j > intRightEnd)
                        {
                            if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                            {
                                if (j >= (intRightEnd + m_intEachPageSideCount / 2 - 1) && (p_dtvResult.Count - j + 1) < m_intEachPageSideCount)
                                {
                                    intLeftEnd = j;
                                    break;
                                }
                                else
                                {
                                    if (intLeftEnd - j > 3)
                                    {
                                        arlLeftGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                        intLeftEnd--;
                                    }
                                    else
                                    {
                                        intLeftEnd = j;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            arlLeftGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                        }

                        DataRow dr = dtbLeft.NewRow();
                        dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                        dtbLeft.Rows.Add(dr);
                    }

                    //构造打印的Group
                    for (int j = 0; j < arlLeftGroupID.Count; j++)
                    {
                        clsGroup objLeftGroup = new clsGroup();
                        DataView dtvLeft = new DataView(dtbLeft);
                        dtvLeft.RowFilter = "groupid_chr = '" + arlLeftGroupID[j].ToString().Trim() + "'";
                        objLeftGroup.m_dtvGroupData = dtvLeft;
                        objLeftGroup.m_strGroupName = dtbLeft.Rows[0]["print_title_vchr"].ToString().Trim();
                        arlLeftGroup.Add(objLeftGroup);
                    }
                    #endregion
                    #region 打印右边
                    if (intLeftEnd < p_dtvResult.Count)
                    {
                        //分边打印
                        m_blnHasTwoPart = true;

                        ArrayList arlRightGroupID = new ArrayList();
                        ArrayList arlRightGroup = new ArrayList();

                        DataTable dtbRight = p_dtvResult.Table.Clone();

                        intRightEnd = intLeftEnd + m_intEachPageSideCount;
                        if (intRightEnd > p_dtvResult.Count)
                        {
                            intRightEnd = p_dtvResult.Count;
                        }
                        for (int j = intLeftEnd; j < intRightEnd; j++)
                        {
                            if (j > intLeftEnd)
                            {
                                if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                                {
                                    if (intRightEnd - j > 3)
                                    {
                                        arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                        intRightEnd--;
                                    }
                                    else
                                    {
                                        intRightEnd = j;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                            }

                            DataRow dr = dtbRight.NewRow();
                            dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                            dtbRight.Rows.Add(dr);
                        }

                        //构造打印的RightGroup
                        for (int j = 0; j < arlRightGroupID.Count; j++)
                        {
                            clsGroup objRightGroup = new clsGroup();
                            DataView dtvRight = new DataView(dtbRight);
                            dtvRight.RowFilter = "groupid_chr = '" + arlRightGroupID[j].ToString().Trim() + "'";
                            objRightGroup.m_dtvGroupData = dtvRight;
                            objRightGroup.m_strGroupName = dtbRight.Rows[0]["print_title_vchr"].ToString().Trim();
                            arlRightGroup.Add(objRightGroup);
                        }
                        ArrayList[] arlTemp = new ArrayList[2];
                        arlTemp[0] = arlLeftGroup;
                        arlTemp[1] = arlRightGroup;
                        p_arlPage.Add(arlTemp);
                    }
                    else
                    {
                        intRightEnd = intLeftEnd;
                        ArrayList[] arlTemp = new ArrayList[2];
                        arlTemp[0] = arlLeftGroup;
                        arlTemp[1] = null;
                        p_arlPage.Add(arlTemp);
                    }
                    #endregion
                    if (i == m_intPageCount - 1 && intRightEnd < p_dtvResult.Count)
                    {
                        m_intPageCount++;
                    }
                    if (intRightEnd >= p_dtvResult.Count)
                    {
                        m_intPageCount = i;
                    }
                }
                else if (p_dtvResult.Count > intRightEnd)
                {
                    //2.2
                    #region 打印左边
                    ArrayList arlLeftGroupID = new ArrayList();
                    ArrayList arlLeftGroup = new ArrayList();

                    DataTable dtbLeft = p_dtvResult.Table.Clone();
                    //					int intLeftEnd = 0;

                    if (p_dtvResult.Count <= intRightEnd + m_intEachPageSideCount)
                    {
                        intLeftEnd = p_dtvResult.Count;
                    }
                    else
                    {
                        intLeftEnd = intRightEnd + m_intEachPageSideCount;
                    }
                    for (int j = intRightEnd; j < intLeftEnd; j++)
                    {
                        if (j > intRightEnd)
                        {
                            if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                            {
                                if (intLeftEnd - j > 3)
                                {
                                    arlLeftGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                    intLeftEnd--;
                                }
                                else
                                {
                                    intLeftEnd = j;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            arlLeftGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                        }

                        DataRow dr = dtbLeft.NewRow();
                        dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                        dtbLeft.Rows.Add(dr);
                    }

                    //构造打印的Group
                    for (int j = 0; j < arlLeftGroupID.Count; j++)
                    {
                        clsGroup objLeftGroup = new clsGroup();
                        DataView dtvLeft = new DataView(dtbLeft);
                        dtvLeft.RowFilter = "groupid_chr = '" + arlLeftGroupID[j].ToString().Trim() + "'";
                        objLeftGroup.m_dtvGroupData = dtvLeft;
                        objLeftGroup.m_strGroupName = dtbLeft.Rows[0]["print_title_vchr"].ToString().Trim();
                        arlLeftGroup.Add(objLeftGroup);
                    }
                    #endregion
                    #region 打印右边
                    if (intLeftEnd < p_dtvResult.Count)
                    {
                        //分边打印
                        m_blnHasTwoPart = true;

                        ArrayList arlRightGroupID = new ArrayList();
                        ArrayList arlRightGroup = new ArrayList();

                        DataTable dtbRight = p_dtvResult.Table.Clone();

                        intRightEnd = intLeftEnd + m_intEachPageSideCount;
                        if (intRightEnd > p_dtvResult.Count)
                        {
                            intRightEnd = p_dtvResult.Count;
                        }
                        for (int j = intLeftEnd; j < intRightEnd; j++)
                        {
                            if (j > intLeftEnd)
                            {
                                if (p_dtvResult[j]["groupid_chr"].ToString().Trim() != p_dtvResult[j - 1]["groupid_chr"].ToString().Trim())
                                {
                                    if (intRightEnd - j > 3)
                                    {
                                        arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                                        intRightEnd--;
                                    }
                                    else
                                    {
                                        intRightEnd = j;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                arlRightGroupID.Add(p_dtvResult[j]["groupid_chr"].ToString().Trim());
                            }

                            DataRow dr = dtbRight.NewRow();
                            dr.ItemArray = p_dtvResult[j].Row.ItemArray;
                            dtbRight.Rows.Add(dr);
                        }

                        //构造打印的RightGroup
                        for (int j = 0; j < arlRightGroupID.Count; j++)
                        {
                            clsGroup objRightGroup = new clsGroup();
                            DataView dtvRight = new DataView(dtbRight);
                            dtvRight.RowFilter = "groupid_chr = '" + arlRightGroupID[j].ToString().Trim() + "'";
                            objRightGroup.m_dtvGroupData = dtvRight;
                            objRightGroup.m_strGroupName = dtbRight.Rows[0]["print_title_vchr"].ToString().Trim();
                            arlRightGroup.Add(objRightGroup);
                        }
                        ArrayList[] arlTemp = new ArrayList[2];
                        arlTemp[0] = arlLeftGroup;
                        arlTemp[1] = arlRightGroup;
                        p_arlPage.Add(arlTemp);
                    }
                    else
                    {
                        intRightEnd = intLeftEnd;
                        ArrayList[] arlTemp = new ArrayList[2];
                        arlTemp[0] = arlLeftGroup;
                        arlTemp[1] = null;
                        p_arlPage.Add(arlTemp);
                    }
                    #endregion
                    if (i == m_intPageCount - 1 && intRightEnd < p_dtvResult.Count)
                    {
                        m_intPageCount++;
                    }
                    if (intRightEnd >= p_dtvResult.Count)
                    {
                        m_intPageCount = i;
                    }
                }
            }
        }

        /// <summary>
        /// 打印 Group
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        /// <param name="p_dtvGroupData"></param>
        /// <param name="p_strGroupName"></param>
        /// <param name="p_fltX"></param>
        /// <param name="p_fltY"></param>
        /// <param name="p_fltWidth"></param>
        /// <param name="p_fltEndY"></param>
        private void m_mthPrintGroup(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg, System.Data.DataView p_dtvGroupData,
            string p_strGroupName, float p_fltX, float p_fltY, float p_fltWidth, out float p_fltEndY, bool p_blnIsTop)
        {
            p_fltEndY = 0;
            try
            {
                //				p_objPrintArg.Graphics.DrawLine(m_GridPen,p_fltX,p_fltY,p_fltX+p_fltWidth,p_fltY);

                if (p_blnIsTop)
                {
                    p_fltY += 6;
                }
                float[] fltColumnXArr = new float[3];

                if (m_blnHasTwoPart)
                {
                    fltColumnXArr[0] = p_fltX + 8f;
                    fltColumnXArr[1] = p_fltX + p_fltWidth * 0.36f + 8f;
                    fltColumnXArr[2] = p_fltX + p_fltWidth * 0.60f;// + 15f;
                }
                else
                {
                    fltColumnXArr[0] = p_fltX + 8f;
                    fltColumnXArr[1] = p_fltX + fltColumnXArr[0] + m_fltItemAndResultSpace;
                    fltColumnXArr[2] = p_fltX + fltColumnXArr[1] + m_fltResultAndRefSpace;// + 15f;
                }

                p_objPrintArg.Graphics.DrawString(p_strGroupName, m_fntSmallBold, Brushes.Black, fltColumnXArr[0], p_fltY);
                p_objPrintArg.Graphics.DrawString(" 结果", m_fntSmallBold, Brushes.Black, fltColumnXArr[1], p_fltY);
                p_objPrintArg.Graphics.DrawString("参考范围", m_fntSmallBold, Brushes.Black, fltColumnXArr[2], p_fltY);

                //				fltColumnXArr[3]=p_fltX + p_fltWidth*0.85f;
                //				p_objPrintArg.Graphics.DrawString("单位",m_fntSmallBold,Brushes.Black,fltColumnXArr[3],p_fltY);


                //				p_objPrintArg.Graphics.DrawLine(m_GridPen,p_fltX,p_fltY+2+m_fntSmallBold.Height,p_fltX+p_fltWidth,p_fltY+2+m_fntSmallBold.Height);

                //打印标本项目排序 2004.06.03
                p_dtvGroupData.Sort = "REPORT_PRINT_SEQ_INT ASC,SAMPLE_PRINT_SEQ_INT ";

                //打印结果的宽度
                SizeF ResultPrintWidthSF = p_objPrintArg.Graphics.MeasureString(" 结果 1", m_fntSmallBold);
                float fltResultPrintWidth = ResultPrintWidthSF.Width;
                //fltColumnXArr[2] - fltColumnXArr[1] + 12;

                //定位Y轴坐标
                float fltCurrentY = p_fltY + 2;
                #region 逐条打印记录
                for (int i = 0; i < p_dtvGroupData.Count; i++)
                {
                    string strResult = p_dtvGroupData[i].Row["result_vchr"].ToString().Trim();
                    string strAbnormal = p_dtvGroupData[i].Row["ABNORMAL_FLAG_CHR"].ToString().Trim();
                    string strUnit = p_dtvGroupData[i].Row["UNIT_VCHR"].ToString().Trim();
                    string strRefRange = p_dtvGroupData[i].Row["refrange_vchr"].ToString() + " " + strUnit;
                    string strMinVal = p_dtvGroupData[i].Row["MIN_VAL_DEC"].ToString().Trim();
                    string strMaxVal = p_dtvGroupData[i].Row["MAX_VAL_DEC"].ToString().Trim();
                    string strCheckItemName = p_dtvGroupData[i].Row["RPTNO_CHR"].ToString().Trim();//CHECK_ITEM_NAME_VCHR"].ToString().Trim();
                    //					string strDeviceCheckItemName = p_dtvGroupData[i].Row["DEVICE_CHECK_ITEM_NAME_VCHR"].ToString().Trim();
                    //					double doubleResult = -1; //当结果为文字型时，此值默认为－1
                    //					double doubleMinVal = -1;
                    //					double doubleMaxVal = -1;

                    fltCurrentY += m_fltItemSpace;

                    //					if(i==0)
                    //						p_objPrintArg.Graphics.DrawString((fltCurrentY).ToString().Trim(),m_fntSmallBold,Brushes.Black,m_lngWidthPage*0.9f,fltCurrentY);

                    p_objPrintArg.Graphics.DrawString(strCheckItemName, m_fntSmall2NotBold, Brushes.Black, fltColumnXArr[0], fltCurrentY);
                    //打印结果X轴的位置
                    //					fltColumnXArr[1]=p_fltX + p_fltWidth*0.36f-10f;
                    #region 打印 指示箭头
                    //1.根据异常标志判断,此处认为异常标志只有"H"(高)和"L"(低)两种情况
                    if (strAbnormal != null)
                    {
                        System.Drawing.Font objBoldFont = new Font("SimSun", 9, FontStyle.Bold);
                        string strPR;

                        strPR = strResult + " " + "↑";
                        SizeF objBoldSF = p_objPrintArg.Graphics.MeasureString(strPR, objBoldFont);
                        SizeF objNotBoldSF = p_objPrintArg.Graphics.MeasureString(strPR, objBoldFont);

                        if (strAbnormal == "H")
                        {
                            strPR = strResult + " " + "↑";
                            objBoldSF = p_objPrintArg.Graphics.MeasureString(strPR, objBoldFont);
                            float fltStartPos = fltColumnXArr[1] + fltResultPrintWidth - objBoldSF.Width;
                            //							strPR = strPR.PadLeft(10);
                            p_objPrintArg.Graphics.DrawString(strPR, objBoldFont, Brushes.Black, fltStartPos, fltCurrentY);
                        }
                        else if (strAbnormal == "L")
                        {
                            if (strResult.Contains(">") || strResult.Contains("<"))
                                strPR = strResult + " " + "↑";
                            else
                                strPR = strResult + " " + "↓";
                            float fltStartPos = fltColumnXArr[1] + fltResultPrintWidth - objBoldSF.Width;
                            //							strPR = strPR.PadLeft(10);
                            p_objPrintArg.Graphics.DrawString(strPR, objBoldFont, Brushes.Black, fltStartPos, fltCurrentY);
                        }
                        else
                        {
                            strPR = strResult + " " + " ";
                            float fltStartPos = fltColumnXArr[1] + fltResultPrintWidth - objNotBoldSF.Width;
                            //							strPR = strPR.PadLeft(10);

                            p_objPrintArg.Graphics.DrawString(strPR, m_fntSmall2NotBold, Brushes.Black, fltStartPos, fltCurrentY);
                        }
                    }
                    else
                    {
                        #region old 刘彬 2004.4.21 14:10
                        //						//2.根据最大值最小值判断
                        //						try
                        //						{
                        //							doubleResult = double.Parse(strResult);
                        //							doubleMinVal = double.Parse(strMinVal);
                        //							doubleMaxVal = double.Parse(strMaxVal);
                        //						}
                        //						catch(Exception objEx)
                        //						{
                        //							//throw objEx;
                        //						}
                        //						finally
                        //						{
                        //							if(doubleResult != -1)
                        //							{
                        //								if(doubleResult < doubleMinVal)
                        //								{
                        //									p_objPrintArg.Graphics.DrawString("↓"+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
                        //								}
                        //								else if(doubleResult > doubleMaxVal)
                        //								{
                        //									p_objPrintArg.Graphics.DrawString("↑"+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
                        //								}
                        //								else
                        //								{
                        //									p_objPrintArg.Graphics.DrawString("  "+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
                        //								}
                        //							}
                        //							else
                        //							{
                        //								p_objPrintArg.Graphics.DrawString("  "+strResult,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[1],fltCurrentY);
                        //							}
                        //						}
                        #endregion
                    }
                    #endregion

                    p_objPrintArg.Graphics.DrawString(strRefRange, m_fntSmallNotBold, Brushes.Black, fltColumnXArr[2], fltCurrentY);
                    //					p_objPrintArg.Graphics.DrawString(strUnit,m_fntSmallNotBold,Brushes.Black,fltColumnXArr[3],fltCurrentY);
                }
                #endregion
                fltCurrentY += m_fntSmallNotBold.Height;
                p_fltEndY = fltCurrentY;
            }
            catch { }
        }

        #endregion

        #region 评语部分
        //评语部分
        private void m_mthPrintSummary(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            //			if(m_lngY < 366)
            //			{
            //				m_lngY = 366;
            //			}
            string strSummary = m_dtbSample.Rows[0]["SUMMARY_VCHR"].ToString().Trim();
            SizeF sfSummary = p_objPrintArg.Graphics.MeasureString(strSummary, m_fntSmallNotBold);
            long lngTemp = m_lngY + (long)sfSummary.Height + (long)m_fntSmallBold.Height + 4;
            if (lngTemp > m_lngEndPosition)
            {
                if (m_blnHasPrintGroup)
                {
                    m_intPageCount++;
                    m_blnPrintSummary = false;
                }
                else
                {
                    m_blnPrintSummary = false;
                }
            }
            else
            {
                m_blnPrintSummary = true;
            }

            if (!m_blnPrintSummary)
                return;

            //			int count = strSummary.Length;
            SizeF szPerWord = p_objPrintArg.Graphics.MeasureString("三", m_fntSmallNotBold);//获取一个字符的宽度
            //			int intWordCount = strSummary.Length;//(int)(szSummary.Width/szPerWord.Width) + 1;
            //			int intWordCountPerLine = (int)((m_lngWidthPage - (m_lngWidthPage*(this.m_fltLeftIndentProp + this.m_fltRightIndentProp) + szPerWord.Width + 4 + 4 + 4))/szPerWord.Width);//每一行的字符个数
            //			int intRowCount = intWordCount/intWordCountPerLine;


            p_objPrintArg.Graphics.DrawString("实验室提示：", m_fntSmallBold, Brushes.Black, m_lngWidthPage * 0.08f, m_lngY + 6);
            //			p_objPrintArg.Graphics.DrawString(m_lngY.ToString().Trim(),m_fntSmallBold,Brushes.Black,m_lngWidthPage*0.8f,m_lngY+4);
            m_lngY = m_lngY + m_fntSmallBold.Height + 4;

            long CurrentY = m_lngY;
            if (strSummary != null)
            {
                float fltLeftX = m_lngWidthPage * m_fltLeftIndentProp + szPerWord.Width + 8;
                float fltRightX = m_lngWidthPage * 0.92f - fltLeftX;
                CurrentY += 4;
                long lngEndY = CurrentY + m_fntSmallNotBold.Height * 2 + 3;
                Rectangle rectSummary = new Rectangle((int)fltLeftX, (int)CurrentY, (int)fltRightX, (int)lngEndY);
                new com.digitalwave.controls.clsPrintRichTextContext(Color.Black, m_fntSmallNotBold).m_mthPrintText(m_dtbSample.Rows[0]["SUMMARY_VCHR"].ToString().Trim(),
                    m_dtbSample.Rows[0]["XML_SUMMARY_VCHR"].ToString().Trim(), m_fntSmallNotBold, Color.Black, rectSummary, p_objPrintArg.Graphics);
                //				p_objPrintArg.Graphics.DrawString(strSummary,m_fntSmallNotBold,Brushes.Black,new RectangleF(fltLeftX,CurrentY,fltRightX,lngEndY));
                CurrentY = lngEndY;
            }
            m_lngY += m_fntSmallNotBold.Height * 2 + 4;
        }
        #endregion

        #region 打印报告单结尾部分
        /// <summary>
        /// 打印报告单结尾部分
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        private void m_mthPrintEnd(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            if (m_blnDocked)
            {
                if (m_lngY < m_lngEndPosition)
                {
                    m_lngY = m_lngEndPosition;
                }
            }
            // 检验医生
            string strCheckEmp = m_dtbSample.Rows[0]["reportor"].ToString().Trim();//m_dtbResult.Rows[0]["checkPerson"].ToString().Trim();
            // 审核医生 （暂时是检验医生）
            string strConfirmEmp = m_dtbSample.Rows[0]["reportor"].ToString().Trim();//m_dtbResult.Rows[0]["confirmPerson"].ToString().Trim();

            //			p_objPrintArg.Graphics.DrawString(m_lngY.ToString(),m_fntSmallNotBold,Brushes.Black,m_lngWidthPage*0.8f,m_lngY);
            m_lngY += 10;

            float fltCurrent = m_lngWidthPage * m_fltLeftIndentProp;
            SizeF sf = p_objPrintArg.Graphics.MeasureString("(检验结果仅供临床诊疗参考，只对该检测的标本负责!)附注:", m_fntSmallNotBold);
            p_objPrintArg.Graphics.DrawString("(检验结果仅供临床诊疗参考，只对该检测的标本负责!)附注:", m_fntSmallNotBold, Brushes.Black, fltCurrent, m_lngY);
            p_objPrintArg.Graphics.DrawString(m_dtbSample.Rows[0]["ANNOTATION_VCHR"].ToString().Trim(), m_fntSmallNotBold, Brushes.Black,
                fltCurrent + sf.Width, m_lngY);//
            //			p_objPrintArg.Graphics.DrawString(m_lngY.ToString(),m_fntSmallNotBold,Brushes.Black,m_lngWidthPage*0.8f,m_lngY);
            m_lngY += m_fntSmallNotBold.Height + 6;
            //画线
            p_objPrintArg.Graphics.DrawLine(m_GridPen, m_lngWidthPage * 0.08f, m_lngY, m_lngWidthPage * 0.92f, m_lngY);

            m_lngY += 6;
            p_objPrintArg.Graphics.DrawString("报告日期:", m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);
            string strReportDate = "";
            if (Microsoft.VisualBasic.Information.IsDate(m_dtbSample.Rows[0]["CONFIRM_DAT"]))
            {
                strReportDate = ((DateTime)m_dtbSample.Rows[0]["CONFIRM_DAT"]).ToString().Trim();//DateTime.Now.Date.ToString("yyyy-MM-dd");
            }
            SizeF szTmp = p_objPrintArg.Graphics.MeasureString("报告日期:", m_fntSmallBold);
            fltCurrent += szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(strReportDate, m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);


            p_objPrintArg.Graphics.DrawString("检验医生:", m_fntSmallBold, Brushes.Black, m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 1.3f / 3), m_lngY);

            fltCurrent = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 1.3f / 3) + szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(strCheckEmp, m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);

            fltCurrent = m_lngWidthPage * (m_fltLeftIndentProp + (1 - m_fltLeftIndentProp - m_fltRightIndentProp) * 2 / 3) + szTmp.Width * 3 / 4 + 4;
            p_objPrintArg.Graphics.DrawString("审核者:", m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);
            szTmp = p_objPrintArg.Graphics.MeasureString("审核者:", m_fntSmallBold);
            fltCurrent = fltCurrent + szTmp.Width + 4;
            p_objPrintArg.Graphics.DrawString(strCheckEmp, m_fntSmallBold, Brushes.Black, fltCurrent, m_lngY);
            m_lngY += m_fntSmallBold.Height + 6;
            //			p_objPrintArg.Graphics.DrawString(m_lngY.ToString(),m_fntSmallBold,Brushes.Black,fltCurrent,m_lngY);
            //			p_objPrintArg.Graphics.DrawString(((int)(m_lngY+m_fntSmallBold.Height)).ToString(),m_fntSmallBold,Brushes.Black,fltCurrent,m_lngY+m_fntSmallBold.Height);


        }
        #endregion


        private void m_mthPrintPageSub(System.Drawing.Printing.PrintPageEventArgs p_objPrintArg)
        {
            m_mthPrintStart(p_objPrintArg);
            m_mthPrintLine(p_objPrintArg);
            m_mthPrintMiddle(p_objPrintArg);
            if (m_intCurrentPage >= m_intPageCount)
            {
                m_mthPrintSummary(p_objPrintArg);
            }
            m_mthPrintEnd(p_objPrintArg);
            m_bolFinishPrint = true;
        }


        #region 继承打印接口
        /// <summary>
        /// 初始化打印变量
        /// </summary>
        /// <param name="p_objArg">外部需要初始化的变量，根据不同的实现使用</param>
        public void m_mthInitPrintTool(object p_objArg)
        {
            m_fntTitle = new Font("SimSun", 18, FontStyle.Bold);
            m_fntSmallBold = new Font("SimSun", 11, FontStyle.Bold);
            m_fntSmallNotBold = new Font("SimSun", 10f, FontStyle.Regular);
            m_fntSmall2NotBold = new Font("SimSun", 9f, FontStyle.Regular);
            m_fntHeadNotBold = new Font("SimSun", 11f, FontStyle.Regular);

            m_GridPen = new Pen(Color.Black, 1);

            m_fltItemSpace = m_fntSmall2NotBold.Height / 4 + m_fntSmall2NotBold.Height;

            m_fltLeftIndentProp = 0.1f;
            m_fltRightIndentProp = 0.1f;

            #region 打印设置
            try
            {
                //				System.Configuration.AppSettingsReader objAppSettingReader = new System.Configuration.AppSettingsReader();
                //				string strWidth = objAppSettingReader.GetValue("LISReportPrintPaperWidth",typeof(double)).ToString().Trim();
                //				string strHeight = objAppSettingReader.GetValue("LISReportPrintPaperHeight",typeof(double)).ToString().Trim();
                //				if(	Microsoft.VisualBasic.Information.IsNumeric(strWidth) 
                //					&& Microsoft.VisualBasic.Information.IsNumeric(strHeight))
                //				{
                //					double dblWidth_cm = double.Parse(strWidth);//double.Parse(this.m_txtPaperWidth.Text.Trim());
                //					double dblHeight_cm = double.Parse(strHeight);//double.Parse(this.m_txtPaperHeight.Text.Trim());
                //					int intWidth_01mm =  (int)(dblWidth_cm * 100);
                //					int intHeight_01mm = (int)(dblHeight_cm * 100);
                //					int intWidth_001inc = System.Drawing.Printing.PrinterUnitConvert.Convert(intWidth_01mm,PrinterUnit.TenthsOfAMillimeter,PrinterUnit.Display);
                //					int intHeight_001inc = System.Drawing.Printing.PrinterUnitConvert.Convert(intHeight_01mm,PrinterUnit.TenthsOfAMillimeter,PrinterUnit.Display);
                //					ps.PaperSize = new PaperSize("LIS",intWidth_001inc,intHeight_001inc);
                PaperSize ps = null;
                //				foreach(PaperSize objPs in ((System.Drawing.Printing.PrintDocument)p_objArg).PrinterSettings.PaperSizes)
                //				{
                //					if(objPs.PaperName == "LIS_Report")
                //					{
                //						ps = objPs;
                //						break;
                //					}
                //				}
                //				if(ps != null)
                //				{
                //					((System.Drawing.Printing.PrintDocument)p_objArg).DefaultPageSettings.PaperSize = ps;
                //				}
                ps = ((System.Drawing.Printing.PrintDocument)p_objArg).PrinterSettings.DefaultPageSettings.PaperSize;
                m_intEachSideItemHeight = ps.Height - 311;
                m_lngEndPosition = ps.Height - 123;
                m_intEachPageSideItemHeight = ps.Height - 123 - 114;
                //				}
            }
            catch
            {
                MessageBox.Show("打印机故障！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //				MessageBox.Show(ex.Message);

            }
            #endregion

        }

        /// <summary>
        /// 从数据库初始化打印内容。如果没有记录，打印空报表。
        /// </summary>
        public void m_mthInitPrintContent()
        {

        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        /// <param name="p_objArg">外部使用到的变量，根据不同的实现使用</param>
        public void m_mthDisposePrintTools(object p_objArg)
        {
        }

        /// <summary>
        /// 打印开始
        /// </summary>
        /// <param name="p_objPrintArg">打印文档</param>
        public void m_mthBeginPrint(object p_objPrintArg)
        {
            #region 初始化打印数据
            m_dtbSample = ((clsPrintValuePara)p_objPrintArg).m_dtbBaseInfo;
            m_dtbResult = ((clsPrintValuePara)p_objPrintArg).m_dtbResult;
            m_strTitle = ((clsPrintValuePara)p_objPrintArg).m_strTitle;
            //			m_lngEndPosition = 448;
            m_fltItemAndResultSpace = 80;//项目名称和结果之间的距离
            m_fltResultAndRefSpace = 30;//结果和参考范围之间的距离

            m_intEachSideCount = (int)(m_intEachSideItemHeight / m_fltItemSpace);
            m_intEachPageSideCount = (int)(m_intEachPageSideItemHeight / m_fltItemSpace);

            m_intCurrentPage = 1;

            if ((m_dtbResult.Rows.Count) % (2 * m_intEachSideCount) > 0)
            {
                m_intPageCount = (m_dtbResult.Rows.Count) / (2 * m_intEachSideCount) + 1;
            }
            else
            {
                m_intPageCount = (m_dtbResult.Rows.Count) / (2 * m_intEachSideCount);
            }
            #endregion
        }


        /// <summary>
        /// 打印中
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthPrintPage(object p_objPrintArg)
        {
            m_mthPrintPageSub((PrintPageEventArgs)p_objPrintArg);
            if (m_intCurrentPage < m_intPageCount)
            {
                ((PrintPageEventArgs)p_objPrintArg).HasMorePages = true;
            }
            else
            {
                ((PrintPageEventArgs)p_objPrintArg).HasMorePages = false;
            }
            m_intCurrentPage++;
        }

        /// <summary>
        /// 打印结束。一般使用它来更新数据库信息。
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        public void m_mthEndPrint(object p_objPrintArg)
        {

        }
        #endregion

    }

}

