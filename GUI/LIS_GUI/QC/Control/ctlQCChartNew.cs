using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using ZedGraph;

namespace com.digitalwave.iCare.gui.LIS.QC.Control
{
    public partial class ctlQCChartNew : UserControl
    {
        private clsQCBatchNew m_objBatch = new clsQCBatchNew();
        private List<clsQCDataPairItem> m_lstQCDataPairItem = null;
        private ContextMenuStrip m_cmsQCAnalysis;
        /// <summary>
        /// 所选浓度(同一质控批)
        /// </summary>
        private List<clsLisQCConcentrationVO> m_lstChoiceConcentration = new List<clsLisQCConcentrationVO>();

        public ctlQCChartNew()
        {
            InitializeComponent();
            InitializeZedChart();
        }

        internal clsQCBatchNew ObjBatch
        {
            set
            {
                if (value != null)
                {
                    m_objBatch_Reseted(this,EventArgs.Empty);
                    m_objBatch = value;
                    m_objBatch.Reseted += new EventHandler(m_objBatch_Reseted);
                    m_objBatch.Loaded += new EventHandler(m_objBatch_Loaded);
                    m_objBatch.Reloaded += new EventHandler(m_objBatch_Reloaded);
                    m_objBatch.SetChanged += new EventHandler(m_objBatch_SetChanged);
                    m_objBatch.DataChanged += new EventHandler(m_objBatch_DataChanged);
                    m_objBatch.ConcentrationChanged += new EventHandler(m_objBatch_ConcentrationChanged);

                    m_mthConstructDataPairList();
                    List<clsLisQCConcentrationVO> list = this.m_objBatch.GetConcentrations();
                    if (list != null && list.Count > 0)
                    {
                        this.m_lstChoiceConcentration.Add(list[0]);
                    }
                    m_mthDrawLeveyChart();
                }
                else 
                {
                    throw new System.ArgumentNullException();
                }

            }
        }

        private void m_mthConstructDataPairList()
        {
            if (!m_objBatch.IsNull)
                m_lstQCDataPairItem = clsQCDataPairItem.GetQCDataPairItemList(m_objBatch.GetDatas());
        }

        #region == 事件实现 ==
        void m_objBatch_Reseted(object sender, EventArgs e)
        {
            m_lstChoiceConcentration.Clear();
            m_lstQCDataPairItem = null;
            m_lsvQCResult.Items.Clear();

            // 默认样式
            m_gpbChartStyle.Visible = true;
            m_pnlControl.Visible = true;

            m_rdbLeveyChart.CheckedChanged -= new EventHandler(m_rdbLevey_CheckedChanged);
            this.m_rdbLeveyChart.Checked = true;
            m_rdbLeveyChart.CheckedChanged += new EventHandler(m_rdbLevey_CheckedChanged);
            m_cmdAnalysis.Enabled = true;
            m_mthDrawLeveyChart();
        }

        void m_objBatch_SetChanged(object sender, EventArgs e)
        {
            if (this.m_rdbLeveyChart.Checked)
            {
                m_mthDrawLeveyChart();
            }
            else if (this.m_rdbZChart.Checked)
            {
                m_mthDrawZChart();
            }
            else if (this.m_rdbYoudenChart.Checked)
            {
                m_mthDrawYouDenChart();
            }
            this.m_lsvQCResult.Items.Clear();
        }

        void m_objBatch_Reloaded(object sender, EventArgs e)
        {
            this.m_lsvQCResult.Items.Clear();
            m_mthConstructDataPairList();
            if (this.m_rdbLeveyChart.Checked)
            {
                m_mthDrawLeveyChart();
            }
            else if (this.m_rdbZChart.Checked)
            {
                m_mthDrawZChart();
            }
            else if (this.m_rdbYoudenChart.Checked)
            {
                m_mthDrawYouDenChart();
            }
        }

        void m_objBatch_Loaded(object sender, EventArgs e)
        {
            m_lstChoiceConcentration.Clear();
            m_lstQCDataPairItem = null;
            m_lsvQCResult.Items.Clear();

            m_rdbLeveyChart.CheckedChanged -= new EventHandler(m_rdbLevey_CheckedChanged);
            this.m_rdbLeveyChart.Checked = true;
            m_rdbLeveyChart.CheckedChanged += new EventHandler(m_rdbLevey_CheckedChanged);

            m_mthConstructDataPairList();
            List<clsLisQCConcentrationVO> list = this.m_objBatch.GetConcentrations();
            if (list.Count > 0)
            {
                this.m_lstChoiceConcentration.Add(list[0]);
            }
             m_mthDrawLeveyChart();
        }

        //浓度改变事件
        void m_objBatch_ConcentrationChanged(object sender, EventArgs e)
        {
            m_lstQCDataPairItem = null;
            m_lsvQCResult.Items.Clear();

            m_mthConstructDataPairList();
            List<clsLisQCConcentrationVO> list = this.m_objBatch.GetConcentrations();
            if(m_blnChoicedInNewConcentrations(m_lstChoiceConcentration,m_objBatch.GetConcentrations()))
            {
                m_mthFreshChoiceConcentration(m_lstChoiceConcentration,m_objBatch.GetConcentrations());
                if (m_rdbLeveyChart.Checked) 
                {
                    m_mthDrawLeveyChart();
                    this.m_cmdAnalysis.Enabled = true;
                }
                if (m_rdbZChart.Checked) 
                {
                    m_mthDrawZChart();
                    this.m_cmdAnalysis.Enabled = true;
                }
                if (m_rdbYoudenChart.Checked) 
                {
                    m_mthDrawYouDenChart();
                }
            }
            else if (list.Count > 0)
            {
                m_rdbLeveyChart.CheckedChanged -= new EventHandler(m_rdbLevey_CheckedChanged);
                this.m_rdbLeveyChart.Checked = true;
                m_rdbLeveyChart.CheckedChanged += new EventHandler(m_rdbLevey_CheckedChanged);

                m_lstChoiceConcentration.Clear();
                this.m_lstChoiceConcentration.Add(list[0]);
                this.m_cmdAnalysis.Enabled = true;
                m_mthDrawLeveyChart();
            }
        }

        private void m_objBatch_DataChanged(object sender, EventArgs e)
        {
            this.m_lsvQCResult.Items.Clear();
            m_mthConstructDataPairList();
            if (this.m_rdbLeveyChart.Checked)
            {
                m_mthDrawLeveyChart();
            }
            else if (this.m_rdbZChart.Checked)
            {
                m_mthDrawZChart();
            }
            else if (this.m_rdbYoudenChart.Checked)
            {
                m_mthDrawYouDenChart();
            }
        }

        private bool m_blnChoicedInNewConcentrations(List<clsLisQCConcentrationVO> p_choiced, List<clsLisQCConcentrationVO> p_newCons)
        {
            if (p_newCons.Count < p_choiced.Count)
                return false;
            bool bExist = false;
            foreach (clsLisQCConcentrationVO choice in p_choiced)
            {
                foreach (clsLisQCConcentrationVO con in p_newCons)
                {
                    if (choice.m_intConcentrationSeq == con.m_intConcentrationSeq)
                    {
                        bExist = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (bExist == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void m_mthFreshChoiceConcentration(List<clsLisQCConcentrationVO> p_choiced, List<clsLisQCConcentrationVO> p_newCons)
        {
            if (m_blnChoicedInNewConcentrations(p_choiced, p_newCons))
            {
                for (int i = 0; i < p_choiced.Count; i++)
                {
                    for (int j = 0; j < p_newCons.Count; j++)
                    {
                        if (p_choiced[i].m_intConcentrationSeq == p_newCons[j].m_intConcentrationSeq)
                        {
                            p_choiced[i] = p_newCons[j];
                        }
                    }
                }
            }
        }
        #endregion

        #region == 质控图形 ==

        private void InitializeZedChart()
        {
            m_zedChart.GraphPane = new GraphPane(m_zedChart.GraphPane.PaneRect, "", "", "");
            GraphPane myPane = m_zedChart.GraphPane;
            myPane.MarginRight = 30F;
            m_zedChart.IsPrintFillPage=true;
            m_zedChart.IsPrintKeepAspectRatio=false;

            myPane.IsFontsScaled = false;
            myPane.IsPenWidthScaled = false;
            myPane.PaneBorder.IsVisible = false;
            myPane.IsShowTitle = false;

            myPane.IsShowTitle = false;
            myPane.FontSpec.Size = 10.5F;
            myPane.FontSpec.Family = "宋体";


            myPane.XAxis.IsZeroLine = false;
            myPane.XAxis.IsShowTitle = false;
            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Step = 1;

            myPane.XAxis.MajorUnit = DateUnit.Day;
            myPane.XAxis.ScaleFontSpec.Angle = 90;
            myPane.XAxis.ScaleFontSpec.IsBold = true;
            myPane.XAxis.ScaleFontSpec.Size = 12;
            //myPane.XAxis.ScaleFormat = "d MMM";
            myPane.XAxis.ScaleFormat = "M/dd";
            myPane.XAxis.ScaleFontSpec.Family = "宋体";
            myPane.XAxis.ScaleFontSpec.Size = 12F;
            myPane.XAxis.ScaleFontSpec.IsBold = false;


            myPane.YAxis.IsShowTitle = false;
            myPane.YAxis.IsShowGrid = false;
            myPane.YAxis.IsZeroLine = false;

        }

        private void InitializeChartNull()
        {
            m_zedChart.GraphPane = new GraphPane(m_zedChart.GraphPane.PaneRect, "", "", "");
            GraphPane myPane = m_zedChart.GraphPane;

            XDate xdtBegin = XDate.DateTimeToXLDate(m_objBatch.DateBegin);
            XDate xdtEnd = XDate.DateTimeToXLDate(m_objBatch.DateEnd);
          
            myPane.XAxis.Min = (double)xdtBegin;
            myPane.XAxis.Max = (double)xdtEnd;
            myPane.XAxis.BaseTic = (double)xdtBegin;
            myPane.XAxis.IsShowGrid = false;

            myPane.AxisFill = new Fill(Color.White, Color.LightGray, 45.0f);

            myPane.MarginRight = 30F;
            myPane.IsFontsScaled = true;
            myPane.IsPenWidthScaled = true;
            myPane.PaneBorder.IsVisible = false;
            myPane.IsShowTitle = false;

            myPane.IsShowTitle = false;
            myPane.FontSpec.Size = 10.5F;
            myPane.FontSpec.Family = "宋体";
            myPane.YAxis.IsShowTitle = false;

            myPane.XAxis.IsZeroLine = false;
            myPane.YAxis.IsZeroLine = false;
            myPane.XAxis.IsShowTitle = false;

            myPane.XAxis.Type = AxisType.Date;
            myPane.XAxis.Step = 1;
            myPane.XAxis.MajorUnit = DateUnit.Day;
            myPane.XAxis.ScaleFontSpec.Angle = 90;
            myPane.XAxis.ScaleFontSpec.IsBold = true;
            myPane.XAxis.ScaleFormat = "M/dd";
            myPane.XAxis.ScaleFontSpec.Family = "宋体";
            myPane.XAxis.ScaleFontSpec.Size = 12F;
            myPane.XAxis.ScaleFontSpec.IsBold = false;

            myPane.YAxis.IsShowGrid = false;

            m_zedChart.AxisChange();
            m_zedChart.Refresh();
        }

        #region Draw Levey
        private void m_mthDrawLeveyChart()
        {
            //if (!m_objBatch.IsNull && m_objBatch.Count == 1)
            //{
            //    InitializeZedChart();
            //    if (m_lstChoiceConcentration.Count > 0)
            //    {
            //        m_mthDrawLeveyStyle(m_lstChoiceConcentration[0]);
            //        m_zedChart.GraphPane.CurveList.Clear();
            //        AddLeveyLineItems();
            //        AddAssistLine((float)m_lstChoiceConcentration[0].m_dblAVG, (float)m_lstChoiceConcentration[0].m_dblSD);

            //        m_zedChart.AxisChange();
            //        m_zedChart.Refresh();

            //        m_cmdAnalysis_Click(null, null);
            //    }
            //    else 
            //    {
            //        InitializeChartNull();
            //    }
            //}
            //else
            //{
            //    InitializeChartNull();
            //}
            if (!this.m_objBatch.IsNull && this.m_objBatch.Count == 1)
            {
                this.InitializeZedChart();
                if (this.m_lstChoiceConcentration.Count > 0)
                {
                    this.m_mthDrawLeveyStyle(this.m_lstChoiceConcentration[0]);
                    this.m_zedChart.GraphPane.CurveList.Clear();
                    this.AddLeveyLineItems();
                    this.AddAssistLine((float)this.m_lstChoiceConcentration[0].m_dblAVG, (float)this.m_lstChoiceConcentration[0].m_dblSD);
                    this.m_zedChart.AxisChange();
                    this.m_zedChart.Refresh();
                    this.m_mthSetAnalysisClick();
                }
                else
                {
                    this.InitializeChartNull();
                }
            }
            else
            {
                this.InitializeChartNull();
            }

        }

        private void m_mthSetAnalysisClick()
        {
            if (!this.m_objBatch.IsNull && this.m_objBatch.Count == 1)
            {
                if (this.m_rdbLeveyChart.Checked)
                {
                    this.m_mthShowAnalysisList(false);
                }
                else
                {
                    this.m_mthShowAnalysisList(true);
                }
            }
        }
        
        // 添加Levey的曲线


        private void AddLeveyLineItems()
        {
            List<clsLisQCDataVO> QCDataList = m_lstDataListByConcentration();

            PointPairList pointsPair = new PointPairList();
            foreach (clsLisQCDataVO vo in QCDataList)
            {
                double x = (double)XDate.DateTimeToXLDate(vo.m_datQCDate);
                double y = vo.m_dlbResult;
                pointsPair.Add(x, y);
            }
            LineItem itemCurve = m_zedChart.GraphPane.AddCurve(m_lstChoiceConcentration[0].m_strConcentration, pointsPair, Color.Red, SymbolType.Diamond);
            itemCurve.Symbol.Fill = new Fill(Color.White);
        }
        /// <summary>
        /// 根据浓度的真值与SD值画Levery曲线样式
        /// </summary>
        /// <param name="p_con"></param>
        private void m_mthDrawLeveyStyle(clsLisQCConcentrationVO p_con)
        {
            GraphPane myPane = m_zedChart.GraphPane;

            float X = (float)p_con.m_dblAVG;
            float SD = (float)p_con.m_dblSD;

            XDate xdtBegin = XDate.DateTimeToXLDate(m_objBatch.DateBegin);
            XDate xdtEnd = XDate.DateTimeToXLDate(m_objBatch.DateEnd);

            myPane.YAxis.Max = X + 4f * SD;
            myPane.YAxis.Min = X - 4f * SD;
            myPane.YAxis.BaseTic = myPane.YAxis.Min;

            myPane.YAxis.MinorStep = (double)SD;

            myPane.YAxis.Step = (double)SD;
            myPane.YAxis.ScaleFormat="0.00";


            myPane.XAxis.Min = (double)xdtBegin;
            myPane.XAxis.Max = (double)xdtEnd;
            myPane.XAxis.BaseTic = (double)xdtBegin;
            myPane.XAxis.IsShowGrid = false;

            myPane.AxisFill = new Fill(Color.White, Color.LightGray, 45.0f);
        }
        #endregion

        #region Draw Zscore
        // 添加Z-Score的曲线


        private void m_mthDrawZChart()
        {
            if (!m_objBatch.IsNull)
            {
                if (m_lstChoiceConcentration.Count > 0)
                {
                    InitializeZedChart();
                    m_mthDrawZStyle();
                    m_zedChart.GraphPane.CurveList.Clear();
                    AddZLineItems();
                    AddAssistLine(0, 1);

                    m_zedChart.AxisChange();
                    m_zedChart.Refresh();

                    m_cmdAnalysis_Click(null, null);
                }
                else 
                {
                    InitializeChartNull();
                }
            }
            else
            {
                InitializeChartNull();
            }
        }

        private void AddZLineItems()
        {
            List<clsLisQCDataVO> QCDataList = m_lstDataListByConcentration();

            //List<clsLisQCDataVO>[] arrQCDataList = m_lstDataListByConcentration();
            PointPairList[] arrPointPair = new PointPairList[m_lstChoiceConcentration.Count];

            for (int i = 0; i < m_lstChoiceConcentration.Count; i++)
            {
                clsLisQCConcentrationVO con = m_lstChoiceConcentration[i];
                double X = con.m_dblAVG;
                double SD = con.m_dblSD;
                if (SD == 0)
                {
                    SD = double.MaxValue;
                }
                PointPairList pointsPair = new PointPairList();
                foreach (clsLisQCDataVO vo in QCDataList)
                {
                    double x = (double)XDate.DateTimeToXLDate(vo.m_datQCDate);
                    double y = (vo.m_dlbResult - X) / SD;
                    pointsPair.Add(x, y);
                }
                arrPointPair[i] = pointsPair;
            }

            Color[] colors = new Color[] { Color.Red, Color.Green, Color.Purple, Color.RosyBrown, Color.Yellow,Color.Blue, Color.Black, Color.Brown };

            for (int i = 0; i < arrPointPair.Length; i++)
            {
                Color color;
                if (i < colors.Length)
                    color = colors[i];
                else
                {
                    color = Color.Red;
                }

                LineItem itemCurve = m_zedChart.GraphPane.AddCurve(m_lstChoiceConcentration[i].m_strConcentration, arrPointPair[i], color, SymbolType.Diamond);
                itemCurve.Symbol.Fill = new Fill(Color.White);
            }
        }

        private void m_mthDrawZStyle()
        {
            GraphPane myPane = m_zedChart.GraphPane;

            float X = 0f;
            float SD = 1f;

            XDate xdtBegin = XDate.DateTimeToXLDate(m_objBatch.DateBegin);
            XDate xdtEnd = XDate.DateTimeToXLDate(m_objBatch.DateEnd);

            myPane.YAxis.Max = X + 4f * SD;
            myPane.YAxis.Min = X - 4f * SD;
            myPane.YAxis.BaseTic = myPane.YAxis.Min;
            myPane.XAxis.IsShowGrid = false;


            myPane.XAxis.Min = (double)xdtBegin;
            myPane.XAxis.Max = (double)xdtEnd;
            myPane.XAxis.BaseTic = (double)xdtBegin;
            myPane.YAxis.MinorStep = SD;

            myPane.AxisFill = new Fill(Color.White, Color.LightGray, 45.0f);
        } 
        #endregion

        #region Draw YouDen
        //Draw YouDen
        private void m_mthDrawYouDenChart()
        {
            if (!m_objBatch.IsNull)
            {
                if (m_lstChoiceConcentration.Count==2)
                {
                    #region Init
                    m_zedChart.GraphPane = new GraphPane(m_zedChart.GraphPane.PaneRect, "", "XAxis", "YAxis");
                    // print set
                    m_zedChart.IsPrintFillPage = true;
                    m_zedChart.IsPrintKeepAspectRatio = false;
                    GraphPane myPane = m_zedChart.GraphPane;

                    myPane.MarginRight = 50F;
                    myPane.MarginTop = 50F;
                    myPane.IsFontsScaled = true;
                    myPane.IsPenWidthScaled = true;
                    myPane.PaneBorder.IsVisible = false;
                    myPane.IsShowTitle = false;

                    myPane.IsShowTitle = false;
                    myPane.FontSpec.Size = 10.5F;
                    myPane.FontSpec.Family = "宋体";
                    myPane.YAxis.IsShowTitle = false;
                    myPane.YAxis.IsZeroLine = false;

                    myPane.XAxis.IsZeroLine = false;
                    myPane.XAxis.IsShowTitle = false;
                    myPane.YAxis.IsShowGrid = true;
                    myPane.XAxis.IsShowGrid = true;

                    myPane.AxisFill = new Fill(Color.White, Color.LightGray, 45.0f);
                    #endregion

                    myPane.CurveList.Clear();
                    m_mthDrawYouDenBaseStyle();

                    AddYouDenLineItems();
                    AddYouDenAssistLine();

                    m_zedChart.AxisChange();
                    m_zedChart.Refresh(); 
                }
                else 
                {
                    InitializeChartNull();
                }

            }
            else
            {
                InitializeChartNull();
            }

        }

        private void m_mthDrawYouDenBaseStyle()
        {
            GraphPane myPane = m_zedChart.GraphPane;

            float X = 0f;
            float SD = 1f;

            myPane.YAxis.Max = X + 4f * SD;
            myPane.YAxis.Min = X - 4f * SD;
            myPane.YAxis.BaseTic = myPane.YAxis.Min;
            myPane.YAxis.Step = SD;
            myPane.YAxis.IsZeroLine = false;
            myPane.YAxis.IsShowGrid = false;

            //myPane.YAxis.IsTicsBetweenLabels = true;
            //myPane.YAxis.TextLabels = new string[] { "-4SD", "-3SD", "-2SD", "X", "SD", "2SD", "4SD" };
            //myPane.YAxis.Type = AxisType.Text;

            myPane.XAxis.Min = X - 4f * SD;
            myPane.XAxis.Max = X + 4f * SD;
            myPane.XAxis.BaseTic = myPane.XAxis.Min;
            myPane.XAxis.Step = SD;
            myPane.XAxis.IsShowGrid = false;
            myPane.XAxis.IsZeroLine = false;

            //test
            //myPane.XAxis.IsTicsBetweenLabels = false;
            //myPane.XAxis.TextLabels = new string[] { "-4SD", "-3SD", "-2SD", "X", "SD", "2SD", "4SD" };
            //myPane.XAxis.Type = AxisType.Text;

        }

        private void AddYouDenLineItems()
        {
            PointPairList lstPairYouDen = new PointPairList();
            if (m_lstQCDataPairItem != null && m_lstQCDataPairItem.Count > 0)
            {
                double X1 = m_lstChoiceConcentration[0].m_dblAVG;
                double X2 = m_lstChoiceConcentration[1].m_dblAVG;
                double SD1 = m_lstChoiceConcentration[0].m_dblSD;
                double SD2 = m_lstChoiceConcentration[1].m_dblSD;
                if (SD1 == 0)
                {
                    SD1 = double.MaxValue;
                }
                if (SD2 == 0)
                {
                    SD2 = double.MaxValue;
                }
                foreach (clsQCDataPairItem pair in m_lstQCDataPairItem)
                {
                    clsLisQCDataVO conQCData = pair[m_lstChoiceConcentration[0].m_intQCBatchSeq];
                    if (conQCData != null)
                    {
                        lstPairYouDen.Add((conQCData.m_dlbResult - X1) / SD1, (conQCData.m_dlbResult - X2) / SD2);
                    }
                    else
                    {
                        continue;
                    }
                }

                //foreach (clsQCDataPairItem pair in m_lstQCDataPairItem)
                //{
                //    clsLisQCDataVO conQCData1 = pair[m_lstChoiceConcentration[0].m_intConcentrationSeq];
                //    clsLisQCDataVO conQCData2 = pair[m_lstChoiceConcentration[1].m_intConcentrationSeq];
                //    if (conQCData1 != null && conQCData2 != null)
                //    {

                //        lstPairYouDen.Add((conQCData1.m_dlbResult - X1)/SD1 , (conQCData2.m_dlbResult - X2)/SD2);
                //    }
                //    else
                //    {
                //        continue;
                //    }
                //}
            }

            if (lstPairYouDen != null && lstPairYouDen.Count > 0)
            {
                LineItem itemCurve = m_zedChart.GraphPane.AddCurve("", lstPairYouDen, Color.Red, SymbolType.Diamond);
                itemCurve.Line.IsVisible = false;
                itemCurve.Symbol.Fill = new Fill(Color.Red);
            }
        }

        private void AddYouDenAssistLine()
        {
            float X = 0f;
            float SD = 1f;

            double[] x1SD ={ X - 4f * SD, X + 4f * SD };
            double[] X1 ={ X, X };
            double[] y1SD ={ X + SD, X + SD };
            double[] y1SDF ={ X - SD, X - SD };
            double[] y2SD ={ X + 2f * SD, X + 2f * SD };
            double[] y2SDF ={ X - 2f * SD, X - 2f * SD };
            double[] y3SD ={ X + 3f * SD, X + 3f * SD };
            double[] y3SDF ={ X - 3f * SD, X - 3f * SD };

            GraphPane myPane = m_zedChart.GraphPane;
            AddLine(x1SD, X1, myPane, Color.Black);
            AddLine(x1SD, y2SD, myPane, Color.Blue);
            AddLine(x1SD, y2SDF, myPane, Color.Blue);
            AddLine(x1SD, y1SD, myPane, Color.Green);
            AddLine(x1SD, y1SDF, myPane, Color.Green);
            AddLine(x1SD, y3SD, myPane, Color.Red);
            AddLine(x1SD, y3SDF, myPane, Color.Red);

            AddLabel(" X", X + 4f * SD, X, myPane);
            AddLabel("-SD", X + 4f * SD, X - SD, myPane);
            AddLabel("+SD", X + 4f * SD, X + SD, myPane);
            AddLabel("-2SD", X + 4f * SD, X - 2f * SD, myPane);
            AddLabel("+2SD", X + 4f * SD, X + 2f * SD, myPane);
            AddLabel("-3SD", X + 4f * SD, X - 3f * SD, myPane);
            AddLabel("+3SD", X + 4f * SD, X + 3f * SD, myPane);
            //*****************************************************************//


            AddLine(X1,x1SD,  myPane, Color.Black);
            AddLine(y2SD, x1SD, myPane, Color.Blue);
            AddLine(y2SDF, x1SD, myPane, Color.Blue);
            AddLine(y1SD, x1SD, myPane, Color.Green);
            AddLine(y1SDF, x1SD, myPane, Color.Green);
            AddLine(y3SD, x1SD, myPane, Color.Red);
            AddLine(y3SDF, x1SD, myPane, Color.Red);

            AddLabel("X", X - 0.1f * SD, X + 4f * SD + 0.2f * SD, myPane);
            AddLabel("-SD", X - SD - 0.2f * SD, X + 4f * SD + 0.2f * SD, myPane);
            AddLabel("+SD", X + SD - 0.2f * SD, X + 4f * SD + 0.2f * SD, myPane);
            AddLabel("-2SD", X - 2f * SD - 0.2f * SD, X + 4f * SD + 0.2f * SD, myPane);
            AddLabel("+2SD", X + 2f * SD - 0.2f * SD, X + 4f * SD + 0.2f * SD, myPane);
            AddLabel("-3SD", X - 3f * SD - 0.2f * SD, X + 4f * SD + 0.2f * SD, myPane);
            AddLabel("+3SD", X + 3f * SD - 0.2f * SD, X + 4f * SD + 0.2f * SD, myPane);


            AddLine(x1SD, x1SD, myPane, Color.Black);

        }
        #endregion

        #region == 辅助方法 ==
        // 画参考线
        private void AddAssistLine(float p_X,float p_SD)
        {
            float X = p_X;
            float SD = p_SD;

            XDate xdtBegin = XDate.DateTimeToXLDate(m_objBatch.DateBegin);
            XDate xdtEnd = XDate.DateTimeToXLDate(m_objBatch.DateEnd);

            double[] x1SD ={ (double)xdtBegin, (double)xdtEnd };
            double[] X1 ={ X, X };
            double[] y1SD ={ X + SD, X + SD };
            double[] y1SDF ={ X - SD, X - SD };
            double[] y2SD ={ X + 2f * SD, X + 2f * SD };
            double[] y2SDF ={ X - 2f * SD, X - 2f * SD };
            double[] y3SD ={ X + 3f * SD, X + 3f * SD };
            double[] y3SDF ={ X - 3f * SD, X - 3f * SD };

            GraphPane myPane = m_zedChart.GraphPane;
            AddLine(x1SD, X1, myPane, Color.Black);
            AddLine(x1SD, y2SD, myPane, Color.Blue);
            AddLine(x1SD, y2SDF, myPane, Color.Blue);
            AddLine(x1SD, y1SD, myPane, Color.Green);
            AddLine(x1SD, y1SDF, myPane, Color.Green);
            AddLine(x1SD, y3SD, myPane, Color.Red);
            AddLine(x1SD, y3SDF, myPane, Color.Red);

            AddLabel(" X", (float)xdtEnd, X, myPane);
            AddLabel("-SD", (float)xdtEnd, X - SD, myPane);
            AddLabel("+SD", (float)xdtEnd, X + SD, myPane);
            AddLabel("-2SD", (float)xdtEnd, X - 2f * SD, myPane);
            AddLabel("+2SD", (float)xdtEnd, X + 2f * SD, myPane);
            AddLabel("-3SD", (float)xdtEnd, X - 3f * SD, myPane);
            AddLabel("+3SD", (float)xdtEnd, X + 3f * SD, myPane);
        }

        private static void AddLabel(string label, float x, float y, GraphPane myPane)
        {
            TextItem myText1 = new TextItem(label, x, y);
            myText1.Location.CoordinateFrame = CoordType.AxisXYScale;
            myText1.Location.AlignH = AlignH.Left;
            myText1.Location.AlignV = AlignV.Center;
            myText1.FontSpec.IsItalic = true;
            myText1.FontSpec.Fill.IsVisible = false;
            myText1.FontSpec.Border.IsVisible = false;
            myText1.FontSpec.FontColor = Color.Teal;
            myPane.GraphItemList.Add(myText1);
        }

        private static void AddLine(double[] x1SD, double[] y1SD, GraphPane myPane, Color color)
        {
            LineItem sdLine1 = myPane.AddCurve("", x1SD, y1SD, color, SymbolType.None);
            sdLine1.Symbol.IsVisible = false;
            sdLine1.Line.Width = 0.5F;
        }

        #endregion

        // 根据浓度给DataPair相对值

        private List<clsLisQCDataVO> m_lstDataListByConcentration()
        {
            List<clsQCDataPairItem> lstQCDataPair = m_lstQCDataPairItem;

            int intQCBatch = m_lstChoiceConcentration[0].m_intQCBatchSeq;

            List<clsLisQCDataVO> lst = new List<clsLisQCDataVO>();
            clsLisQCDataVO objVOTemp = null;

            foreach (clsQCDataPairItem pair in lstQCDataPair)
            {
                objVOTemp = pair[intQCBatch];

                if (objVOTemp != null)
                {
                    lst.Add(objVOTemp);
                }
            }

            return lst;
        }

        // Levey
        private void m_rdbLevey_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbLeveyChart.Checked)
            {
                List<clsLisQCConcentrationVO> lstQCCon = m_objBatch.GetConcentrations();
                if (lstQCCon == null || lstQCCon.Count <= 0)
                    return;

                if (lstQCCon.Count == 1)
                {
                    m_lstChoiceConcentration = lstQCCon;
                    this.m_lsvQCResult.Items.Clear();
                    m_cmdAnalysis.Enabled = true;
                    m_mthDrawLeveyChart();
                }
                else
                {
                    frmQCConcentrationSelector frm = new frmQCConcentrationSelector(lstQCCon, 1, 1);
                    Point p = m_rdbLeveyChart.Parent.PointToScreen(m_rdbLeveyChart.Location);
                    frm.Location = new Point(p.X, p.Y + 15);

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        m_lstChoiceConcentration = frm.Concentrations;
                        this.m_lsvQCResult.Items.Clear();
                        m_cmdAnalysis.Enabled = true;
                        m_mthDrawLeveyChart();
                    }
                }
            }
        }

        private void m_rdbZ_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbZChart.Checked)
            {
                List<clsLisQCConcentrationVO> lstQCCon = m_objBatch.GetConcentrations();
                if (lstQCCon == null || lstQCCon.Count <= 0)
                    return;
                if (lstQCCon.Count == 1)
                {
                    m_lstChoiceConcentration = lstQCCon;
                    m_cmdAnalysis.Enabled = true;
                    this.m_lsvQCResult.Items.Clear();
                    m_mthDrawZChart();
                }
                else
                {
                    frmQCConcentrationSelector frm = new frmQCConcentrationSelector(lstQCCon, 1, m_objBatch.GetConcentrations().Count);
                    Point p = m_rdbZChart.Parent.PointToScreen(m_rdbZChart.Location);
                    frm.Location = new Point(p.X, p.Y + 15);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        m_lstChoiceConcentration = frm.Concentrations;
                        m_cmdAnalysis.Enabled = true;
                        this.m_lsvQCResult.Items.Clear();
                        m_mthDrawZChart();
                    }
                }
            }
        }

        private void m_rdbYouDen_CheckedChanged(object sender, EventArgs e)
        {
            if (m_rdbYoudenChart.Checked)
            {
                frmQCConcentrationSelector frm = new frmQCConcentrationSelector(m_objBatch.GetConcentrations(), 2, 2);
                Point p = m_rdbYoudenChart.Parent.PointToScreen(m_rdbYoudenChart.Location);
                frm.Location = new Point(p.X, p.Y + 15);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    m_lstChoiceConcentration = frm.Concentrations;
                    this.m_lsvQCResult.Items.Clear();
                    m_cmdAnalysis.Enabled = false;
                    m_mthDrawYouDenChart();
                }
            }
        }

        #endregion

        #region == 质控分析 ==
        /// <summary>
        /// 分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdAnalysis_Click(object sender, EventArgs e)  
        {
            if (this.m_objBatch == null)
            {
                MessageBox.Show("数据读取失败！", "质控管理");
            }
            else
            {
                if (this.m_objBatch.Count == 1)
                {
                    if (this.m_cmdAnalysis.ContextMenuStrip == null)
                    {
                        this.m_mthQCAnalysisMonth(this.m_objBatch.DateBegin);
                    }
                    else
                    {
                        this.m_cmsQCAnalysis.Show(this.m_cmdAnalysis, 10, 10);
                    }
                }
            }
           
        }
    
        /// <summary>
        /// 显示质控分析结果
        /// </summary>
        /// <param name="p_blnChange"></param>
        private void m_mthShowAnalysisList(bool p_blnChange)
        {
            List<QualityControlRule> m_ruls = new List<QualityControlRule>();
            QualityControlData m_qcData;
            List<clsLisQCDataVO> m_lstQCAnalysisVO = new List<clsLisQCDataVO>();
            Hashtable m_hasAnalysisResult = new Hashtable();
            QcParserXmlRules parser = new QcParserXmlRules(m_objBatch.GetQCBatchSet()[0].m_strQCRules);
            m_ruls = parser.RuleList;

            List<clsQCDataPairItem> lstQCDataPair = m_lstQCDataPairItem;

            foreach (clsQCDataPairItem pair in lstQCDataPair)
            {
                foreach (clsLisQCConcentrationVO con in m_lstChoiceConcentration)
                {
                    if (pair[con.m_intQCBatchSeq] != null)
                    {
                        clsLisQCDataVO temp = pair[con.m_intQCBatchSeq];
                        if (p_blnChange)
                        {
                            temp = new clsLisQCDataVO();
                            pair[con.m_intQCBatchSeq].m_mthCopyTo(temp);
                            double X = con.m_dblAVG;
                            double SD = con.m_dblSD;
                            if (SD == 0)
                            {
                                SD = double.MaxValue;
                            }
                            temp.m_dlbResult = (temp.m_dlbResult - X) / SD;
                        }
                        m_lstQCAnalysisVO.Add(temp);
                    }
                }
            }

            double[] arrResult = new double[m_lstQCAnalysisVO.Count];
            for (int i = 0; i < m_lstQCAnalysisVO.Count; i++)
            {
                arrResult[i] = m_lstQCAnalysisVO[i].m_dlbResult;
            }

            m_qcData = new QualityControlData(arrResult);
            if (p_blnChange)
            {
                m_qcData.X = 0f;
                m_qcData.SD = 1f;
            }
            else if (m_lstChoiceConcentration.Count>0)
            {
                m_qcData.X = m_lstChoiceConcentration[0].m_dblAVG;
                m_qcData.SD = m_lstChoiceConcentration[0].m_dblSD;
            }

            m_hasAnalysisResult = QualityControlRulesParser.GetRulesDataResult(m_ruls, m_qcData);

            this.m_lsvQCResult.BeginUpdate();
            this.m_lsvQCResult.Items.Clear();
            if (m_hasAnalysisResult != null)
            {
                string ruleReport=string.Empty;
                foreach (DictionaryEntry dic in m_hasAnalysisResult)
                {
                    List<clsLisQCDataVO> lstUnmatchedData = new List<clsLisQCDataVO>();
                    ruleReport += dic.Key.ToString()+"、";
                    ListViewItem item = new ListViewItem(dic.Key.ToString());
                    StringBuilder sb = new StringBuilder();
                    List<int> lstPos = (List<int>)dic.Value;
                    foreach (int pos in lstPos)
                    {
                        // 填充不符合规则列表


                        lstUnmatchedData.Add(m_lstQCAnalysisVO[pos]);
                        sb.Append("|");
                        sb.Append(m_lstQCAnalysisVO[pos].m_dlbResult);
                    }
                    item.Tag = lstUnmatchedData;
                    item.SubItems.Add(sb.ToString());
                    this.m_lsvQCResult.Items.Add(item);
                }
                if (ruleReport != string.Empty) 
                {
                    m_objBatch.BrokenRules = ruleReport.Remove(ruleReport.Length-1,1);
                }
            }
            this.m_lsvQCResult.EndUpdate();//结束更新列表
        }

        //图形显示选择的违反规则数据


        private void m_lsvQCResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lsvQCResult.FocusedItem == null)
            {
                return;
            }
            // 不符合规则数据


            List<clsLisQCDataVO> lstUnmatched = (List<clsLisQCDataVO>)m_lsvQCResult.FocusedItem.Tag;
            PointPairList lstPoints = new PointPairList();
            foreach (clsLisQCDataVO vo in lstUnmatched)
            {
                lstPoints.Add(XDate.DateTimeToXLDate(vo.m_datQCDate), vo.m_dlbResult);
            }

            if (lstPoints.Count > 0)
            {
                if (m_rdbLeveyChart.Checked)
                {
                    m_zedChart.GraphPane.CurveList.Clear();

                    LineItem itemCurveUnmatched = m_zedChart.GraphPane.AddCurve("违规数据", lstPoints, Color.Blue, SymbolType.Circle);
                    itemCurveUnmatched.Symbol.Fill = new Fill(Color.Blue);
                    itemCurveUnmatched.Line.IsVisible = false;

                    m_mthDrawLeveyStyle(m_lstChoiceConcentration[0]);
                    AddLeveyLineItems();
                    AddAssistLine((float)m_lstChoiceConcentration[0].m_dblAVG, (float)m_lstChoiceConcentration[0].m_dblSD);
                    m_zedChart.AxisChange();
                    m_zedChart.Refresh();

                }
                else if(m_rdbZChart.Checked)
                {
                    m_zedChart.GraphPane.CurveList.Clear();
                    LineItem itemCurveUnmatched = m_zedChart.GraphPane.AddCurve("违规数据", lstPoints, Color.Blue, SymbolType.Circle);
                    itemCurveUnmatched.Symbol.Fill = new Fill(Color.Blue);
                    itemCurveUnmatched.Line.IsVisible = false;

                    m_mthDrawZStyle();
                    AddZLineItems();
                    AddAssistLine(0, 1);
                    m_zedChart.AxisChange();
                    m_zedChart.Refresh();

                }
               
            }
        }
        #endregion

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsLisQCConcentrationVO objTemp = null;
            if(m_lstChoiceConcentration != null && m_lstChoiceConcentration.Count == 1)
            {
                objTemp = m_lstChoiceConcentration[0];
            }
            
            clsQCChartToolStrategy print = new clsQCChartToolStrategy(m_zedChart, this.m_objBatch, objTemp);
            print.m_mthPrintPreview();
        }


        #region m_mthQCAnalysisMonth
        /// <summary>
        /// m_mthQCAnalysisMonth
        /// </summary>
        /// <param name="p_dtMonth"></param>
        private void m_mthQCAnalysisMonth(DateTime p_dtMonth)
        {
            if (!this.m_objBatch.IsNull)
            {
                if (this.m_objBatch.Count == 1)
                {
                    DateTime t = Convert.ToDateTime(p_dtMonth.ToString("yyyy-MM"));
                    DateTime t2 = p_dtMonth.AddMonths(1).AddSeconds(-1.0);
                    List<clsLisQCReportVO> objReports = this.m_objBatch.m_objReports;
                    clsLisQCReportVO clsLisQCReportVO = null;
                    for (int i = 0; i < objReports.Count; i++)
                    {
                        clsLisQCReportVO clsLisQCReportVO2 = objReports[i];
                        if (objReports[i].m_intReportStats == 1)
                        {
                            if (clsLisQCReportVO2.m_dtReport >= t && clsLisQCReportVO2.m_dtReport <= t2)
                            {
                                clsLisQCReportVO = clsLisQCReportVO2;
                                break;
                            }
                        }
                    }
                    frmQCReport frmQCReport;
                    if (clsLisQCReportVO != null)
                    {
                        frmQCReport = new frmQCReport(clsLisQCReportVO);
                        frmQCReport.m_blIsDate = false;
                    }
                    else
                    {
                        frmQCReport = new frmQCReport(this.m_objBatch.SeqArr[0], p_dtMonth);
                        frmQCReport.m_blIsDate = false;
                        frmQCReport.BrokenRules = this.m_objBatch.BrokenRules;
                        frmQCReport.m_lblSeq.Text = "质控批序号:" + this.m_objBatch.SeqArr[0].ToString();
                    }
                    if (frmQCReport.ShowDialog() == DialogResult.OK)
                    {
                        clsLisQCReportVO report = frmQCReport.Report;
                        if (clsLisQCReportVO == null)
                        {
                            this.m_objBatch.m_objReports.Add(report);
                        }
                        else
                        {
                            report.m_mthCopyTo(clsLisQCReportVO);
                        }
                    }
                }
            }
        }
        #endregion

        #region m_mthAnalysisContext
        /// <summary>
        /// m_mthAnalysisContext
        /// </summary>
        private void m_mthAnalysisContext()
        {
            this.m_cmdAnalysis.ContextMenuStrip = null;
            if (!this.m_objBatch.IsNull && this.m_objBatch.Count == 1)
            {
                List<string> list = new List<string>();
                DateTime t = this.m_objBatch.m_datBegin.Date;
                while (t <= this.m_objBatch.m_datEnd.Date)
                {
                    list.Add(t.ToString("yyyy-MM"));
                    t = t.AddMonths(1);
                }
                if (list.Count > 1)
                {
                    this.m_cmsQCAnalysis.Items.Clear();
                    for (int i = 0; i < list.Count; i++)
                    {
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(list[i]);
                        toolStripMenuItem.Click += new EventHandler(this.QCAnalysisMonth_Click);
                        this.m_cmsQCAnalysis.Items.Add(toolStripMenuItem);
                    }
                    this.m_cmdAnalysis.ContextMenuStrip = this.m_cmsQCAnalysis;
                }
            }
        }
        #endregion

        #region QCAnalysisMonth_Click
        /// <summary>
        /// QCAnalysisMonth_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QCAnalysisMonth_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null)
            {
                DateTime p_dtMonth = DateTime.MinValue;
                try
                {
                    p_dtMonth = Convert.ToDateTime(toolStripMenuItem.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "质控管理", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                this.m_mthQCAnalysisMonth(p_dtMonth);
            }
        }
        #endregion


    }
}
