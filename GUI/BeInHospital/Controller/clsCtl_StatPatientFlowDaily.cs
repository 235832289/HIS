using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.Utility;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 病人流动日报——界面控制层
    /// 作者： 徐斌辉
    /// 创建时间： 2004-09-23
    /// </summary>
    public class clsCtl_StatPatientFlowDaily : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_StatQuery m_objStatQuery = null;
        clsDcl_BedAdmin m_objBedAdmin = null;
        clsDcl_Register m_objRegister = null;
        private DataTable dtbResult1 = null;
        public string m_strReportID;
        //public string m_strOperatorID;

        /// <summary>
        /// 入院
        /// </summary>
        DataTable m_dtbTemp1;
        /// <summary>
        /// 转入
        /// </summary>
        DataTable m_dtbTemp2;
        /// <summary>
        /// 转出
        /// </summary>
        DataTable m_dtbTemp3;
        /// <summary>
        /// 出院
        /// </summary>
        DataTable m_dtbTemp4;

        #endregion

        #region 构造函数
        public clsCtl_StatPatientFlowDaily()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objStatQuery = new clsDcl_StatQuery();
            m_objBedAdmin = new clsDcl_BedAdmin();
            m_objRegister = new clsDcl_Register();
            m_strReportID = null;
            //m_strOperatorID = "0000001";

            m_mthInitPrintSet();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmStatPatientFlowDaily m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmStatPatientFlowDaily)frmMDI_Child_Base_in;
        }
        #endregion

        #region 载入科室
        /// <summary>
        /// 载入科室
        /// </summary>
        public void LoadAreaID()
        {
            dtbResult1 = new DataTable();
            m_objBedAdmin.m_lngGetsickArea(out dtbResult1);
            //            clsListViewColumns_VO[] m_objColumnsArr = new clsListViewColumns_VO[]{
            //                new clsListViewColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
            //                new clsListViewColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
            //                new clsListViewColumns_VO("名称","deptname_vchr",HorizontalAlignment.Left,70)
            //            };
            //            m_objViewer.m_txtAREAID_CHR.m_mthInitListView(m_objColumnsArr);
            //            m_objViewer.m_txtAREAID_CHR.m_strSQL = @"SELECT   '0' AS deptid_chr, '全院' AS deptname_vchr, 'QY' AS pycode_chr,
            //         '0' AS code_vchr
            //    FROM DUAL
            //UNION ALL
            //SELECT   deptid_chr, deptname_vchr, pycode_chr, code_vchr
            //    FROM t_bse_deptdesc t1
            //   WHERE TRIM (attributeid) = '0000003' AND status_int = 1
            //ORDER BY code_vchr";
            //            //AND t1.deptid_chr IN (" +strAreaID+@")";
            //            m_objViewer.m_txtAREAID_CHR.m_mthGetData();
            //            m_objViewer.m_txtAREAID_CHR.Tag = "0";
            //            m_objViewer.m_txtAREAID_CHR.m_listView.Items[0].SubItems[1].Text = "";
            //            m_objViewer.m_txtAREAID_CHR.Text = "全院";

            // 病区列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
            };


            if (this.m_objViewer.m_bolAllArea == true)
            {
                this.m_objViewer.m_txtAREAID_CHR.m_strSQL = @"select '0' deptid_chr, '全院' deptname_vchr, 'qy' pycode_chr, '00' code_vchr
                                        from t_bse_deptdesc
                                        where rownum = 1
                                        union all
                                        select   a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                        from t_bse_deptdesc a
                                        where
                                             a.attributeid = '0000003' and a.status_int = 1
                                        order by code_vchr";

                this.m_objViewer.m_txtAREAID_CHR.m_mthInitListView(columArr);

                this.m_objViewer.m_txtAREAID_CHR.Focus();
                this.m_objViewer.m_txtAREAID_CHR.SelectAll();
                //设置默认病区
                this.m_objViewer.m_txtAREAID_CHR.Value = "0";
                this.m_objViewer.m_txtAREAID_CHR.Text = "全院";
            }
            else
            {
                this.m_objViewer.m_txtAREAID_CHR.m_strSQL = @"SELECT   a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                        FROM t_bse_deptdesc a, T_BSE_DEPTEMP b
                                        WHERE a.deptid_chr = b.deptid_chr and
                                             a.attributeid = '0000003' AND a.status_int = 1
                                            and b.EMPID_CHR = '" + this.m_objViewer.LoginInfo.m_strEmpID + "' ORDER BY code_vchr";

                this.m_objViewer.m_txtAREAID_CHR.m_mthInitListView(columArr);

                this.m_objViewer.m_txtAREAID_CHR.Focus();
                this.m_objViewer.m_txtAREAID_CHR.SelectAll();
                //设置默认病区
                this.m_objViewer.m_txtAREAID_CHR.Value = this.m_objViewer.LoginInfo.m_strInpatientAreaID;
                this.m_objViewer.m_txtAREAID_CHR.Text = this.m_objViewer.LoginInfo.m_strInpatientAreaName;
            }

        }
        #endregion

        #region 打印表头
        /// <summary>
        /// 打印表头
        /// </summary>
        /// <param name="g"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        private bool Drawing1(System.Drawing.Graphics g, DataTable dtbResult)
        {
            System.Drawing.PointF CurrentPoint = new System.Drawing.PointF(0, 0);

            #region	全院病人流动信息报表表头	glzhang		2005.07.27
            if (m_objViewer.m_txtAREAID_CHR.Value == "0" || m_objViewer.m_txtAREAID_CHR.Value == null)
            {
                int intBedCount = 0;
                for (int i = 0; i < dtbResult1.Rows.Count; i++)
                {
                    try
                    {
                        intBedCount += Convert.ToInt16(dtbResult1.Rows[i]["BedCount"]);
                    }
                    catch { }
                }
                m_drawpoint.Y = 80.0f;
                g.DrawString(m_objViewer.m_txtAREAID_CHR.Text, m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = m_fltPrintWidth * m_fltMarginLeft + g.MeasureString(m_objViewer.m_txtAREAID_CHR.Text, m_fntSmallNotBold).Width;
                CurrentPoint.Y = 80.0f;
                m_drawpoint.X = CurrentPoint.X + 20.0f;
                m_drawpoint.Y = CurrentPoint.Y;
                g.DrawString("查询时间:", m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = m_drawpoint.X + g.MeasureString("查询时间:", m_fntSmallNotBold).Width;
                m_drawpoint.X = CurrentPoint.X + 5.0f;
                g.DrawString(this.m_objViewer.m_dtpDateTime.Text, m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = m_drawpoint.X + g.MeasureString(this.m_objViewer.m_dtpDateTime.Text, m_fntSmallNotBold).Width;
                m_drawpoint.X = CurrentPoint.X + 20.0f;
                g.DrawString("打印时间:", m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = m_drawpoint.X + g.MeasureString("查询时间:", m_fntSmallNotBold).Width;
                m_drawpoint.X = CurrentPoint.X + 5.0f;
                g.DrawString(System.DateTime.Now.ToShortDateString(), m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = m_drawpoint.X + g.MeasureString(System.DateTime.Now.ToShortDateString(), m_fntSmallNotBold).Width;
                m_drawpoint.X = CurrentPoint.X + 20.0f;
                g.DrawString("开放床位数", m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = m_drawpoint.X + g.MeasureString("开放床位数", m_fntSmallNotBold).Width;
                m_drawpoint.X = CurrentPoint.X + 20.0f;
                g.DrawString(intBedCount.ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);
                CurrentPoint.X = CurrentPoint.X + g.MeasureString(intBedCount.ToString(), m_fntSmallNotBold).Width;
                m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
                m_drawpoint.Y = CurrentPoint.Y + g.MeasureString(intBedCount.ToString(), m_fntSmallNotBold).Height + 5.0f;
                m_drawLinePoint.Y = CurrentPoint.Y + g.MeasureString(intBedCount.ToString(), m_fntSmallNotBold).Height + 5.0f;

            }
            #endregion
            else
            {
                for (int i = 0; i < dtbResult1.Rows.Count; i++)
                {
                    if (dtbResult1.Rows[i]["deptid_chr"].ToString() == m_objViewer.m_txtAREAID_CHR.Value)
                    {
                        m_drawpoint.Y = 80.0f;
                        g.DrawString(m_objViewer.m_txtAREAID_CHR.Text, m_fntSmallNotBold, m_brush, m_drawpoint);
                        CurrentPoint.X = m_fltPrintWidth * m_fltMarginLeft + g.MeasureString(m_objViewer.m_txtAREAID_CHR.Text, m_fntSmallNotBold).Width;
                        CurrentPoint.Y = 80.0f;
                        m_drawpoint.X = CurrentPoint.X + 20.0f;
                        m_drawpoint.Y = CurrentPoint.Y;
                        g.DrawString("查询时间:", m_fntSmallNotBold, m_brush, m_drawpoint);
                        CurrentPoint.X = m_drawpoint.X + g.MeasureString("查询时间:", m_fntSmallNotBold).Width;
                        m_drawpoint.X = CurrentPoint.X + 5.0f;
                        g.DrawString(this.m_objViewer.m_dtpDateTime.Text, m_fntSmallNotBold, m_brush, m_drawpoint);
                        CurrentPoint.X = m_drawpoint.X + g.MeasureString(this.m_objViewer.m_dtpDateTime.Text, m_fntSmallNotBold).Width;
                        m_drawpoint.X = CurrentPoint.X + 20.0f;
                        g.DrawString("打印时间:", m_fntSmallNotBold, m_brush, m_drawpoint);
                        //CurrentPoint.X = m_drawpoint.X + g.MeasureString(this.m_objViewer.m_dtpDateTime.Text, m_fntSmallNotBold).Width;
                        CurrentPoint.X = m_drawpoint.X + g.MeasureString("查询时间", m_fntSmallNotBold).Width;
                        m_drawpoint.X = CurrentPoint.X + 5.0f;
                        g.DrawString(System.DateTime.Now.ToShortDateString(), m_fntSmallNotBold, m_brush, m_drawpoint);
                        CurrentPoint.X = m_drawpoint.X + g.MeasureString(System.DateTime.Now.ToShortDateString(), m_fntSmallNotBold).Width;
                        m_drawpoint.X = CurrentPoint.X + 20.0f;
                        g.DrawString("开放床位数", m_fntSmallNotBold, m_brush, m_drawpoint);
                        CurrentPoint.X = m_drawpoint.X + g.MeasureString("开放床位", m_fntSmallNotBold).Width;
                        m_drawpoint.X = CurrentPoint.X + 20.0f;
                        g.DrawString(dtbResult1.Rows[i]["BedCount"].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);
                        CurrentPoint.X = CurrentPoint.X + g.MeasureString(dtbResult1.Rows[i]["BedCount"].ToString(), m_fntSmallNotBold).Width;
                        m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
                        m_drawpoint.Y = CurrentPoint.Y + g.MeasureString(dtbResult1.Rows[i]["BedCount"].ToString(), m_fntSmallNotBold).Height + 5.0f;
                        m_drawLinePoint.Y = CurrentPoint.Y + g.MeasureString(dtbResult1.Rows[i]["BedCount"].ToString(), m_fntSmallNotBold).Height + 5.0f;
                    }
                }
            }
            //划线
            m_drawLinePoint.X = m_fltPrintWidth - m_fltPrintWidth * m_fltMarginLeft;
            g.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);
            //打印总数据
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y = m_drawpoint.Y + 3.0f;
            g.DrawString("昨日人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("昨日人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 3.0f;
            g.DrawString("入院人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("入院人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 3.0f;
            g.DrawString("转入人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("转入人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 3.0f;
            g.DrawString("转出人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("转出人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 40.0f;
            g.DrawString("出院人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("出院人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 48.0f;
            g.DrawString("今日在院人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("今日在院人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 3.0f;
            g.DrawString("今日陪人数", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("今日陪人数", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 3.0f;
            g.DrawString("母婴同室数", m_fntSmallNotBold, m_brush, m_drawpoint);
            //出院分类
            m_drawpoint.X = 320.0f;
            m_drawpoint.Y = CurrentPoint.Y + g.MeasureString("今日陪人数", m_fntSmallNotBold).Height;
            g.DrawString("出院", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("出院", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 8.0f;
            g.DrawString("死亡", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("死亡", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 5.0f;
            g.DrawString("24小时死亡", m_fntSmallNotBold, m_brush, m_drawpoint);
            CurrentPoint.X = m_drawpoint.X + g.MeasureString("小时死亡", m_fntSmallNotBold).Width;
            CurrentPoint.Y = m_drawpoint.Y;
            m_drawpoint.X = CurrentPoint.X + 5.0f;
            //划线
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y = m_drawpoint.Y + g.MeasureString("今", m_fntSmallNotBold).Height;
            m_drawLinePoint.Y = m_drawpoint.Y;
            g.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

            //写数据
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft + 5.0f;
            m_drawpoint.Y = m_drawpoint.Y + 2.0f;
            //昨日人数
            g.DrawString(dtbResult.Rows[0][0].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 70.0f;
            //入院人数
            g.DrawString(dtbResult.Rows[0][1].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 65.0f;
            //转入人数
            g.DrawString(dtbResult.Rows[0][2].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 68.0f;
            //转出人数
            g.DrawString(dtbResult.Rows[0][3].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 65.0f;
            //出院人数
            g.DrawString(dtbResult.Rows[0][4].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 50.0f;
            //死亡
            g.DrawString(dtbResult.Rows[0][5].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 55.0f;
            //24小时死亡
            g.DrawString(dtbResult.Rows[0][6].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 90.0f;
            //今日在院人数
            g.DrawString(dtbResult.Rows[0][7].ToString(), m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 95.0f;
            //今日陪人数
            g.DrawString("0", m_fntSmallNotBold, m_brush, m_drawpoint);

            m_drawpoint.X = m_drawpoint.X + 90.0f;
            //母婴同室数
            g.DrawString("0", m_fntSmallNotBold, m_brush, m_drawpoint);
            m_drawpoint.X = m_drawpoint.X + 65.0f;

            //回车换行
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y += g.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;
            return false;
        }
        #endregion

        #region 统计
        /// <summary>
        /// 统计
        /// </summary>
        public void preview()
        {
            m_blnTatlePrinted = false;
            m_blnTatlePrinted2 = false;
            m_blnTatlePrinted3 = false;
            m_blnTatlePrinted4 = false;

            m_blnFlagPrinted = false;
            m_blnFlagPrinted2 = false;
            m_blnFlagPrinted3 = false;
            m_blnFlagPrinted4 = false;
            m_blnFlagPrinted5 = false;
            m_blnFlagPrinted6 = false;
            m_intNowRow = 0;

            m_mthGetPrintDate();
            this.m_objViewer.printDialog.Document = this.m_objViewer.m_pdSickRoomLog;
            if (this.m_objViewer.m_pdSickRoomLog.PrinterSettings.PrinterName == "<无默认打印机>")
            {
                MessageBox.Show(this.m_objViewer, "请确认打印机安装正确", "错误");
                return;
            }
            try
            {
                //this.m_objViewer.printPreviewDialog.ShowDialog();
            }
            catch
            {
                MessageBox.Show(this.m_objViewer, "请确认打印机配置正确", "错误");
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void Print()
        {
            try
            {
                m_blnTatlePrinted = false;
                m_blnTatlePrinted2 = false;
                m_blnTatlePrinted3 = false;
                m_blnTatlePrinted4 = false;

                m_blnFlagPrinted = false;
                m_blnFlagPrinted2 = false;
                m_blnFlagPrinted3 = false;
                m_blnFlagPrinted4 = false;
                m_blnFlagPrinted5 = false;
                m_blnFlagPrinted6 = false;
                this.m_objViewer.m_pdSickRoomLog.Print();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(this.m_objViewer, ex.ToString());
            }
        }
        #endregion

        #region	打印报表	glzhang	2005.09.29
        /// <summary>
        /// 打印报表	glzhang	2005.09.29
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public void PrintPage(Object Sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (m_blnFlagPrinted == false)
            {

                m_fltPrintWidth = e.PageBounds.Width;
                m_fltPrintHeight = e.PageBounds.Height;
                m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
                m_drawpoint.Y = m_fltPrintHeight * m_fltUpColse;
                m_blnFlagPrinted = true;
            }

            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y = m_fltPrintHeight * m_fltUpColse;
            m_mthPrintTitle(e);

            //打印表头汇总
            if (m_blnFlagPrinted2 == false)
            {
                DataTable dtbResult = new DataTable();
                long lngRes = 0;
                if ((string)m_objViewer.m_txtAREAID_CHR.Value == "0" || m_objViewer.m_txtAREAID_CHR.Value == null)
                {
                    lngRes = m_objStatQuery.m_lngRepAllDeptByDate("", m_objViewer.m_dtpDateTime.Text, out dtbResult);
                    m_objViewer.m_txtAREAID_CHR.Text = "全院";
                }
                else
                {
                    lngRes = m_objStatQuery.m_lngRepDeptByDate(m_objViewer.m_txtAREAID_CHR.Value, m_objViewer.m_dtpDateTime.Value, m_objViewer.m_dtpDateTime.Value, out dtbResult);
                }
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    this.Drawing1(e.Graphics, dtbResult);
                }
                m_blnFlagPrinted2 = true;
            }

            //打印入院表
            if (m_blnFlagPrinted3 == false && m_dtbTemp1.Rows.Count > 0)
            {
                e.Graphics.DrawString("入院表:", m_fntSmallBold, m_brush, m_drawpoint);
                m_drawpoint.Y += e.Graphics.MeasureString("行高", m_fntSmallBold).Height + m_fltRowClose;
            }
            if (m_blnTatlePrinted == false && m_dtbTemp1.Rows.Count > 0)
            {
                m_blnTatlePrinted = m_mthPrintDataTable(e, m_dtbTemp1);
                if (m_blnTatlePrinted == true)
                {
                    m_blnFlagPrinted3 = true;
                }
            }
            if (m_dtbTemp1.Rows.Count < 1)
            {
                m_blnTatlePrinted = true;
                m_blnFlagPrinted3 = true;
            }

            //打印转入表
            if (m_blnFlagPrinted4 == false
                && m_blnTatlePrinted == true 
                && m_dtbTemp2.Rows.Count > 0)
            {
                e.Graphics.DrawString("转入表:", m_fntSmallBold, m_brush, m_drawpoint);
                m_drawpoint.Y += e.Graphics.MeasureString("行高", m_fntSmallBold).Height + m_fltRowClose;
            }
            if (m_blnTatlePrinted2 == false 
                && m_blnTatlePrinted == true 
                && m_dtbTemp2.Rows.Count > 0)
            {
                m_blnTatlePrinted2 = m_mthPrintDataTable(e, m_dtbTemp2);
                if (m_blnTatlePrinted2 == true)
                {
                    m_blnFlagPrinted4 = true;
                }
            }
            if (m_dtbTemp2.Rows.Count < 1)
            {
                m_blnTatlePrinted2 = true;
                m_blnFlagPrinted4 = true;
            }

            //打印转出表
            if (m_blnFlagPrinted5 == false 
                && m_blnTatlePrinted == true 
                && m_blnTatlePrinted2 == true 
                && m_dtbTemp3.Rows.Count > 0)
            {
                e.Graphics.DrawString("转出表:", m_fntSmallBold, m_brush, m_drawpoint);
                m_drawpoint.Y += e.Graphics.MeasureString("行高", m_fntSmallBold).Height + m_fltRowClose;
            }
            if (m_blnTatlePrinted3 == false 
                && m_blnTatlePrinted == true 
                && m_blnTatlePrinted2 == true 
                && m_dtbTemp3.Rows.Count > 0)
            {
                m_blnTatlePrinted3 = m_mthPrintDataTable(e, m_dtbTemp3);
                if (m_blnTatlePrinted3 == true)
                {
                    m_blnFlagPrinted5 = true;
                }
            }
            if (m_dtbTemp3.Rows.Count < 1)
            {
                m_blnTatlePrinted3 = true;
                m_blnFlagPrinted5 = true;
            }

            //打印出院表
            if (m_blnFlagPrinted6 == false 
                && m_blnTatlePrinted == true 
                && m_blnTatlePrinted2 == true 
                && m_blnTatlePrinted3 == true 
                && m_dtbTemp4.Rows.Count > 0)
            {
                e.Graphics.DrawString("出院表:", m_fntSmallBold, m_brush, m_drawpoint);
                m_drawpoint.Y += e.Graphics.MeasureString("行高", m_fntSmallBold).Height + m_fltRowClose;

            }
            if (m_blnTatlePrinted4 == false 
                && m_blnTatlePrinted == true 
                && m_blnTatlePrinted2 == true 
                && m_blnTatlePrinted3 == true 
                && m_dtbTemp4.Rows.Count > 0)
            {
                m_blnTatlePrinted4 = m_mthPrintDataTable(e, m_dtbTemp4);
                if (m_blnTatlePrinted4 == true)
                {
                    m_blnFlagPrinted6 = true;
                }
            }
            if (m_dtbTemp4.Rows.Count < 1)
            {
                m_blnTatlePrinted4 = true;
                m_blnFlagPrinted6 = true;
            }

        }

        #endregion

        #region	打印模块	glzhang 2005.09.28

        #region 打印设置
        /// <summary>
        /// 左边距
        /// </summary>
        float m_fltMarginLeft = 0.07f;
        /// <summary>
        /// 上边距
        /// </summary>
        float m_fltUpColse = 0.03f;
        /// <summary>
        /// 行间隔
        /// </summary>
        private float m_fltRowClose = 5;
        /// <summary>
        ///列间隔
        /// </summary>
        private float m_fltColumnClose = 10;
        /// <summary>
        /// 当前打列到的行号
        /// </summary>
        private int m_intNowRow = 0;
        /// <summary>
        /// 标题字体格式
        /// </summary>
        private Font m_fntTitle;
        /// <summary>
        /// 字体格式:10.5pt加粗字体,一般用于表头
        /// </summary>
        private Font m_fntSmallBold;
        /// <summary>
        /// 字体格式:9pt加粗字体
        /// </summary>
        private Font m_fntSmall2Bold;
        /// <summary>
        /// 字体格式:10.5pt普通字体,一般用于报表明细
        /// </summary>
        private Font m_fntSmallNotBold;
        /// <summary>
        /// 字体格式:9pt普通字体
        /// </summary>
        private Font m_fntSmall2NotBold;

        /// <summary>
        /// 边框画笔
        /// </summary>
        private Pen m_GridPen;

        /// <summary>
        /// 打印页的宽度
        /// </summary>
        float m_fltPrintWidth;
        /// <summary>
        /// 打印页的高度
        /// </summary>
        float m_fltPrintHeight;
        /// <summary>
        /// 画笔坐标
        /// </summary>
        private System.Drawing.PointF m_drawpoint;
        /// <summary>
        /// 画线坐标
        /// </summary>
        private System.Drawing.PointF m_drawLinePoint;
        /// <summary>
        /// 画笔颜色
        /// </summary>
        System.Drawing.SolidBrush m_brush;
        /// <summary>
        /// 数据表是否打印完毕
        /// </summary>
        private bool m_blnTatlePrinted = false, m_blnTatlePrinted2 = false, m_blnTatlePrinted3 = false, m_blnTatlePrinted4 = false;
        /// <summary>
        /// 用于标记只打印一次的文本
        /// </summary>
        private bool m_blnFlagPrinted = false, m_blnFlagPrinted2 = false, m_blnFlagPrinted3 = false, m_blnFlagPrinted4 = false, m_blnFlagPrinted5 = false, m_blnFlagPrinted6 = false;
        /// <summary>
        /// 报表标题
        /// </summary>
        private string m_strReportTitle = "病室工作日志";

        #endregion

        #region 初始化打印设置
        /// <summary>
        /// 初始化打印设置
        /// </summary>
        private void m_mthInitPrintSet()
        {
            m_fntTitle = new Font("SimSun", 20);
            m_fntSmallBold = new Font("SimSun", 10.5f, FontStyle.Bold);
            m_fntSmall2Bold = new Font("SimSun", 9f, FontStyle.Bold);
            m_fntSmallNotBold = new Font("SimSun", 10.5f, FontStyle.Regular);
            m_fntSmall2NotBold = new Font("SimSun", 9f, FontStyle.Regular);
            m_GridPen = new Pen(Color.Black, 1);
            m_drawpoint = new System.Drawing.PointF(0.0f, 0.0f);
            m_drawLinePoint = new System.Drawing.PointF(0.0f, 0.0f);
            m_brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        }
        #endregion

        #region	打印标题
        /// <summary>
        /// 打印标题
        /// </summary>
        /// <param name="p_printPage"></param>
        private void m_mthPrintTitle(System.Drawing.Printing.PrintPageEventArgs p_printPage)
        {
            System.Drawing.Graphics m_graphics = p_printPage.Graphics;
            m_drawpoint.X = m_fltPrintWidth / 2 - m_graphics.MeasureString(m_strReportTitle, m_fntTitle).Width / 2;
            m_graphics.DrawString(m_strReportTitle, m_fntTitle, m_brush, m_drawpoint);

            //回车换行
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y += m_graphics.MeasureString("行高", m_fntTitle).Height + m_fltRowClose;

            //打印时间
            //			m_graphics.DrawString("打印时间: "+DateTime.Now.ToString("yyyy-MM-dd hh:mm"),m_fntSmallNotBold,m_brush,m_drawpoint);
            //			//回车换行
            //			m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            //			m_drawpoint.Y += m_graphics.MeasureString("行高",m_fntSmallNotBold).Height + m_fltRowClose;
        }
        #endregion

        #region 打印数据表
        /// <summary>
        /// 打印数据表
        /// </summary>
        private bool m_mthPrintDataTable(System.Drawing.Printing.PrintPageEventArgs p_printPage, DataTable p_dtbTemp)
        {
            System.Drawing.Graphics m_graphics = p_printPage.Graphics;
            //打印列名
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            for (int intIndex = 0; intIndex < p_dtbTemp.Columns.Count; intIndex++)
            {
                //画横线
                m_drawLinePoint.X = m_drawpoint.X + m_graphics.MeasureString(p_dtbTemp.Columns[intIndex].ColumnName, m_fntSmallBold).Width + m_fltColumnClose * 2;
                m_drawLinePoint.Y = m_drawpoint.Y;
                m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

                //画竖线
                m_drawLinePoint.X = m_drawpoint.X;
                m_drawLinePoint.Y = m_drawpoint.Y + m_graphics.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;
                m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

                m_drawpoint.X += m_fltColumnClose;
                m_drawpoint.Y += m_fltRowClose;

                m_graphics.DrawString(p_dtbTemp.Columns[intIndex].ColumnName, m_fntSmallBold, m_brush, m_drawpoint);
                m_drawpoint.X += m_graphics.MeasureString(p_dtbTemp.Columns[intIndex].ColumnName, m_fntSmallBold).Width + m_fltColumnClose;
                m_drawpoint.Y -= m_fltRowClose;
            }

            //画表头最后一条竖线
            m_drawLinePoint.X = m_drawpoint.X;
            m_drawLinePoint.Y = m_drawpoint.Y + m_graphics.MeasureString("行高", m_fntSmallBold).Height + m_fltRowClose;
            m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y += m_graphics.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;


            int intTemp;
            if (m_intNowRow == 0)
            {
                intTemp = 0;
            }
            else
            {
                intTemp = m_intNowRow;
            }
            //打印数据
            for (int intRowIndex = intTemp; intRowIndex < p_dtbTemp.Rows.Count; intRowIndex++)
            {
                for (int intColumnIndex = 0; intColumnIndex < p_dtbTemp.Columns.Count; intColumnIndex++)
                {
                    //画横线
                    m_drawLinePoint.X = m_drawpoint.X + m_graphics.MeasureString(p_dtbTemp.Columns[intColumnIndex].ColumnName, m_fntSmallBold).Width + m_fltColumnClose * 2;
                    m_drawLinePoint.Y = m_drawpoint.Y;
                    m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);


                    //画竖线
                    m_drawLinePoint.X = m_drawpoint.X;
                    m_drawLinePoint.Y = m_drawpoint.Y + m_graphics.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;
                    m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

                    m_drawpoint.X += m_fltColumnClose;
                    m_drawpoint.Y += m_fltRowClose;

                    m_graphics.DrawString(p_dtbTemp.Rows[intRowIndex][intColumnIndex].ToString().Trim(), m_fntSmallNotBold, m_brush, m_drawpoint);
                    m_drawpoint.X += m_graphics.MeasureString(p_dtbTemp.Columns[intColumnIndex].ColumnName, m_fntSmallBold).Width + m_fltColumnClose;
                    m_drawpoint.Y -= m_fltRowClose;
                }

                //画每行最后一条竖线
                m_drawLinePoint.X = m_drawpoint.X;
                m_drawLinePoint.Y = m_drawpoint.Y + m_graphics.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;
                m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

                //回车换行
                m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
                m_drawpoint.Y += m_graphics.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;

                m_intNowRow++;
                if (m_drawpoint.Y > (m_fltPrintHeight - m_fltPrintHeight * m_fltUpColse))
                {
                    //画底线
                    m_drawLinePoint.Y = m_drawpoint.Y;
                    m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

                    p_printPage.HasMorePages = true;
                    m_drawpoint.Y = m_fltPrintHeight * m_fltUpColse;
                    return false;
                }
            }
            //画底线
            m_drawLinePoint.Y = m_drawpoint.Y;
            m_graphics.DrawLine(m_GridPen, m_drawpoint, m_drawLinePoint);

            //回车换行
            m_drawpoint.X = m_fltPrintWidth * m_fltMarginLeft;
            m_drawpoint.Y += m_graphics.MeasureString("行高", m_fntSmallNotBold).Height + m_fltRowClose;

            m_intNowRow = 0;
            return true;
        }
        #endregion

        #endregion

        #region 获取打印数据	glzhang	2005.09.28
        /// <summary>
        /// 获取打印数据	glzhang	2005.09.28
        /// </summary>
        public void m_mthGetPrintDate()
        {
            long lngRes = 0;
            //入院人数
            m_dtbTemp1 = null;
            lngRes = m_objStatQuery.GetAllSickRoomLogDetail(m_objViewer.m_txtAREAID_CHR.Value, m_objViewer.m_dtpDateTime.Value, m_objViewer.m_dtpDateTime.Value, 0, out m_dtbTemp1);
            m_dtbTemp1.Columns[0].ColumnName = "住 院 号";
            m_dtbTemp1.Columns[1].ColumnName = "姓    名";
            m_dtbTemp1.Columns[2].ColumnName = "性  别";
            m_dtbTemp1.Columns[3].ColumnName = "转入床号";
            m_dtbTemp1.Columns[4].ColumnName = " 入  院  科  室  ";
            m_dtbTemp1.Columns[5].ColumnName = "    入    院     诊     断    .";
            //m_dtbTemp1.Columns[6].ColumnName = " 转  出  科  室   ";
            //打印详细信息
            //转入表：

            m_dtbTemp2 = null;
            lngRes = m_objStatQuery.GetAllSickRoomLogDetail(m_objViewer.m_txtAREAID_CHR.Value, m_objViewer.m_dtpDateTime.Value, m_objViewer.m_dtpDateTime.Value, 1, out m_dtbTemp2);
            m_dtbTemp2.Columns[0].ColumnName = "住 院 号";
            m_dtbTemp2.Columns[1].ColumnName = "姓    名";
            m_dtbTemp2.Columns[2].ColumnName = "性  别";
            m_dtbTemp2.Columns[3].ColumnName = "转入床号";
            m_dtbTemp2.Columns[4].ColumnName = " 转  入  科  室  ";
            m_dtbTemp2.Columns[5].ColumnName = " 原床号";
            m_dtbTemp2.Columns[6].ColumnName = "    原  科  室   ";

            //打印详细信息
            //转出表;
            m_dtbTemp3 = null;
            lngRes = m_objStatQuery.GetAllSickRoomLogDetail(m_objViewer.m_txtAREAID_CHR.Value, m_objViewer.m_dtpDateTime.Value, m_objViewer.m_dtpDateTime.Value, 2, out m_dtbTemp3);
            m_dtbTemp3.Columns[0].ColumnName = "住 院 号";
            m_dtbTemp3.Columns[1].ColumnName = "姓    名";
            m_dtbTemp3.Columns[2].ColumnName = "性  别";
            m_dtbTemp3.Columns[3].ColumnName = "转往床号";
            m_dtbTemp3.Columns[4].ColumnName = " 转  往  科  室   ";
            m_dtbTemp3.Columns[5].ColumnName = "转出床号";
            m_dtbTemp3.Columns[6].ColumnName = " 转  出  科  室   ";
            //出院表
            m_dtbTemp4 = null;
            lngRes = m_objStatQuery.GetAllSickRoomLogDetail(m_objViewer.m_txtAREAID_CHR.Value, m_objViewer.m_dtpDateTime.Value, m_objViewer.m_dtpDateTime.Value, 3, out m_dtbTemp4);
            m_dtbTemp4.Columns[0].ColumnName = "住 院 号";
            m_dtbTemp4.Columns[1].ColumnName = "姓    名";
            m_dtbTemp4.Columns[2].ColumnName = "性  别";
            //m_dtbTemp4.Columns[3].ColumnName = "转入床号";
            //m_dtbTemp4.Columns[4].ColumnName = " 转  入  科  室   ";
            m_dtbTemp4.Columns[3].ColumnName = " 出 院 情 况  ";
            m_dtbTemp4.Columns[4].ColumnName = "转出床号";
            m_dtbTemp4.Columns[5].ColumnName = " 转  出  科  室   ";
        }
        #endregion

        #region 设置文档预览百分比	glzhang	2005.09.26
        /// <summary>
        /// 设置文档预览百分比	glzhang	2005.09.26
        /// </summary>
        public void m_mthSetPrintPecent()
        {
            m_mthFindControl(m_objViewer.printDialog);
        }

        private void m_mthFindControl(System.Windows.Forms.Control controls)
        {
            foreach (System.Windows.Forms.Control con in controls.Controls)
            {
                if (con.Controls.Count > 1)
                {
                    m_mthFindControl(con);
                }
                if (con is System.Windows.Forms.PrintPreviewControl)
                {

                    System.Windows.Forms.PrintPreviewControl tempControl = (System.Windows.Forms.PrintPreviewControl)con;
                    tempControl.Zoom = 1;
                    break;
                }
            }
        }
        #endregion

    }
}
