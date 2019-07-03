using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	///门诊挂号医生收入报表
	///张国良	 2004-9-9
	/// </summary>
	public class clsControRegisterReport:com.digitalwave.GUI_Base.clsController_Base
	{
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_rptRpt;
		/// <summary>
		///开始日期
		/// </summary>
		private string str_firstDate;
		/// <summary>
		///截止日期
		/// </summary>
		private string str_lasttDate;
		public clsControRegisterReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			
			clsDomain = new clsDomainConrol_Print();
			
		}
		clsDomainConrol_Print clsDomain;
		#region 设置窗体对象	张国良	 2004-9-9
        com.digitalwave.iCare.gui.HIS.Reports.frmRegisterReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmRegisterReport)frmMDI_Child_Base_in;
		}
		#endregion
				
		#region 初始化数据 张国良	 2004-9-14
		public void m_mthInitData()
		{
			m_objViewer.Text =m_objViewer.m_cboReport.Text;	
//			m_objViewer.m_datFirstdate.Value=System.Convert.ToDateTime(System.DateTime.Now.Year.ToString()+"-"+System.DateTime.Now.Month.ToString()+"-1");		
			m_rptRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			
		}
		#endregion 

		#region 生成报表  张国良	 2004-9-14
		/// <summary>
        /// 生成报表
		/// </summary>
		public  void m_mthFindByDateReport()
		{
			str_firstDate=m_objViewer.m_datFirstdate.Value.ToShortDateString();
			str_lasttDate=m_objViewer.m_datLastdate.Value.ToShortDateString();
			m_objViewer.Text =m_objViewer.m_cboReport.Text;
			if(m_objViewer.m_cboReport.SelectedIndex==5)
			{  
				m_rptRpt.Load("Report\\rptDepIncome.rpt");
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle()+this.m_objViewer.m_cboReport.Text;
				m_mthDepIncomrpt();
				return;
			}
			TimeSpan tspTemp =m_objViewer.m_datLastdate.Value-m_objViewer.m_datFirstdate.Value;
			int int_dates=tspTemp.Days/7;

			if(m_objViewer.m_cboReport.SelectedIndex==0)
			{  
				m_rptRpt.Load("Report\\registerDayReport.rpt");
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle()+this.m_objViewer.m_cboReport.Text;
                m_mthGetRegisterReportData();
                return;
			}
			else if(m_objViewer.m_cboReport.SelectedIndex==1)
			{
                if (this.m_objViewer.m_cboRptPic.SelectedIndex == 0)//显示表
                {
                    m_rptRpt.Load("Report\\registNumByDoc.rpt");
                    ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle() + this.m_objViewer.m_cboReport.Text;
                    m_mthGetRegisterDocReportData("diagdoctor_chr", "lastname_vchr");
                    return;
                }
                else //显示图
                {
                    m_rptRpt.Load("Report\\CrystalReportDoctorPicture.rpt");

                    Statistic();
                }
			}
			else if(m_objViewer.m_cboReport.SelectedIndex==2)
			{
                if (this.m_objViewer.m_cboRptPic.SelectedIndex == 0)//显示表
                {
                    m_rptRpt.Load("Report\\regiteNumByDep.rpt");
                    ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle() + this.m_objViewer.m_cboReport.Text;
                    m_mthGetRegisterDocReportData("diagdept_chr", "deptname_vchr");
                    return;
                }
                else//显示图
                {
                    m_rptRpt.Load("Report\\CrystalReportRoomPicture.rpt");
                    Statistic();
                }

			}
			else if(m_objViewer.m_cboReport.SelectedIndex==3)
			{  
				m_rptRpt.Load("Report\\registeNumByTime.rpt");
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle()+this.m_objViewer.m_cboReport.Text;
                m_mthGetHourData();
                return;
			}
			else if(m_objViewer.m_cboReport.SelectedIndex==4)
			{  
				m_rptRpt.Load("Report\\registNumByWeek.rpt");
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle()+this.m_objViewer.m_cboReport.Text;
                m_mthGetWeekData();
                return;
			}
		}
		#endregion

		#region 门诊挂号人次日报表 张国良		2006-04-19
		private void m_mthDepIncomrpt()
		{
			DataTable p_dtbRpt = new DataTable();
            DataTable p_depdt = new DataTable();
			long lngRes =clsDomain.m_lngDepIncomerpt(m_objViewer.m_datFirstdate.Value.ToShortDateString(),m_objViewer.m_datLastdate.Value.ToShortDateString(),out p_dtbRpt,out p_depdt);
			if (lngRes >0)
            {
                int DaySum = 0;
                int NightSum = 0;
                int ExpertSum = 0;
                int QuickSum = 0;

                int intParentDay = 0, intParentNight = 0, intParentExport = 0, intParentQuick = 0;
                int intDay = 0, intNight = 0, intExport = 0, intQuick = 0;
				((TextObject)m_rptRpt.ReportDefinition.ReportObjects["fDate"]).Text ="统计日期:"+str_firstDate+" 至  " + str_lasttDate;

                DataTable m_dtbSource = new DataTable();
                m_dtbSource.Columns.Add("strComm1");
                m_dtbSource.Columns.Add("decComm1", typeof(int));
                m_dtbSource.Columns.Add("decComm2", typeof(int));
                m_dtbSource.Columns.Add("decComm3", typeof(int));
                m_dtbSource.Columns.Add("decComm4", typeof(int));
                m_dtbSource.Columns.Add("decComm5", typeof(int));
                int intPatienRow = 0;
                if (p_depdt.Rows.Count > 0)
                {
                    string tempDep = "";
                    for (int i1 = 0; i1 < p_depdt.Rows.Count;i1++)
                    {
                        if (p_depdt.Rows[i1]["code_vchr"].ToString().Trim() != "1" || p_depdt.Rows[i1]["code_vchr"].ToString().Trim() == "1")
                        {
                            #region 

                            if (p_depdt.Rows[i1]["parentname_vchr"].ToString().Trim()!= tempDep.Trim())
                            {
                                tempDep = p_depdt.Rows[i1]["parentname_vchr"].ToString();
                                if (i1 != 0)
                                {
                                    m_dtbSource.Rows[intPatienRow]["decComm1"] = intParentDay;
                                    m_dtbSource.Rows[intPatienRow]["decComm2"] = intParentNight;
                                    m_dtbSource.Rows[intPatienRow]["decComm3"] = intParentExport;
                                    m_dtbSource.Rows[intPatienRow]["decComm4"] = intParentQuick;
                                    
                                }

                                //DaySum += intParentDay;
                                //NightSum += intParentNight;
                                //ExpertSum += intParentExport;
                                //QuickSum += intParentQuick;

                                m_dtbSource.Rows.Add(new object[] { tempDep, intParentExport, intParentQuick, intParentNight, intParentDay, 1 });
                                intPatienRow = m_dtbSource.Rows.Count - 1;
                                intParentExport = 0;
                                intParentQuick = 0;
                                intParentNight = 0;
                                intParentDay = 0;
                            }
                            
                            DataRow[] ArrRow = p_dtbRpt.Select("deptname_vchr='" + p_depdt.Rows[i1]["deptname_vchr"].ToString() + "'");
                            intExport = 0;
                            intQuick = 0;
                            intNight = 0;
                            intDay = 0;
                            foreach (DataRow dr in ArrRow)
                            {
                                if (dr["registertypeid_chr"].ToString().Trim() == "0002")  //专家号
                                {
                                    #region MyRegion

                                    if (dr["flag_int"].ToString().Trim() == "3")  //退票
                                    {
                                        intExport--;                                            
                                    }
                                    else  //正常 还原
                                    {
                                        intExport++;                                            
                                    }
                                    #endregion

                                }
                                else if (dr["registertypeid_chr"].ToString().Trim() == "0003")  //急诊号
                                {
                                    #region MyRegion

                                    if (dr["flag_int"].ToString().Trim() == "3")  //退票
                                    {
                                        intQuick--;                                            
                                    }
                                    else  //正常 还原
                                    {
                                        intQuick++;                                            
                                    }
                                    #endregion

                                }
                                else  //普通号
                                {
                                    #region MyRegion

                                    if (dr["flag_int"].ToString().Trim() == "3")  //退票
                                    {
                                        if (dr["planperiod_chr"].ToString().Trim() == "晚上")
                                        {
                                            intNight--;                                                
                                        }
                                        else
                                        {
                                            intDay--;                                                
                                        }
                                    }
                                    else  // 正常 还原
                                    {
                                        if (dr["planperiod_chr"].ToString().Trim() == "晚上")
                                        {
                                            intNight++;                                                
                                        }
                                        else
                                        {
                                            intDay++;                                                
                                        }
                                    }
                                    #endregion

                                }
                            }
                            m_dtbSource.Rows.Add(new object[] { " " + p_depdt.Rows[i1]["DEPTNAME_VCHR"].ToString(), intDay, intNight, intExport, intQuick, 0 });

                            intParentExport += intExport;
                            intParentQuick += intQuick;
                            intParentNight += intNight;
                            intParentDay += intDay;

                            DaySum += intDay;
                            NightSum += intNight;
                            ExpertSum += intExport;
                            QuickSum += intQuick;
                            #endregion
                        }
                        else
                        {
                            tempDep = "";
                            DataRow[] seleRow = p_depdt.Select("PARENTNAME_VCHR='" + p_depdt.Rows[i1]["deptname_vchr"].ToString() + "'");
                            if (seleRow.Length == 0)
                            {
                                DataRow[] ArrRow = p_dtbRpt.Select("deptname_vchr='" + p_depdt.Rows[i1]["deptname_vchr"].ToString() + "'");
                                intExport = 0;
                                intQuick = 0;
                                intNight = 0;
                                intDay = 0;
                                foreach (DataRow dr in ArrRow)
                                {
                                    if (dr["registertypeid_chr"].ToString().Trim() == "0002")  //专家号
                                    {
                                        #region MyRegion

                                        if (dr["flag_int"].ToString().Trim() == "3")  //退票
                                        {
                                            intExport--;                                            
                                        }
                                        else  //正常 还原
                                        {
                                            intExport++;                                            
                                        }
                                        #endregion

                                    }
                                    else if (dr["registertypeid_chr"].ToString().Trim() == "0003")  //急诊号
                                    {
                                        #region MyRegion

                                        if (dr["flag_int"].ToString().Trim() == "3")  //退票
                                        {
                                            intQuick--;                                            
                                        }
                                        else  //正常 还原
                                        {
                                            intQuick++;                                            
                                        }
                                        #endregion

                                    }
                                    else  //普通号
                                    {
                                        #region MyRegion

                                        if (dr["flag_int"].ToString().Trim() == "3")  //退票
                                        {
                                            if (dr["planperiod_chr"].ToString().Trim() == "晚上")
                                            {
                                                intNight--;                                                
                                            }
                                            else
                                            {
                                                intDay--;                                                
                                            }
                                        }
                                        else  // 正常 还原
                                        {
                                            if (dr["planperiod_chr"].ToString().Trim() == "晚上")
                                            {
                                                intNight++;                                                
                                            }
                                            else
                                            {
                                                intDay++;                                                
                                            }
                                        }
                                        #endregion

                                    }
                                }
                                m_dtbSource.Rows.Add(new object[] { p_depdt.Rows[i1]["DEPTNAME_VCHR"].ToString(), intDay, intNight, intExport, intQuick, 0 });

                                intParentExport += intExport;
                                intParentQuick += intQuick;
                                intParentNight += intNight;
                                intParentDay += intDay;

                                DaySum += intDay;
                                NightSum += intNight;
                                ExpertSum += intExport;
                                QuickSum += intQuick;
                            }
                        }
                    }
                }
                m_dtbSource.Rows[intPatienRow]["decComm1"] = intParentDay;
                m_dtbSource.Rows[intPatienRow]["decComm2"] = intParentNight;
                m_dtbSource.Rows[intPatienRow]["decComm3"] = intParentExport;
                m_dtbSource.Rows[intPatienRow]["decComm4"] = intParentQuick;
                m_rptRpt.SetDataSource(m_dtbSource);
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtDaySum"]).Text = DaySum.ToString();
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtNightSum"]).Text = NightSum.ToString();
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtComSum"]).Text = Convert.ToString(DaySum + NightSum);                
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtExpertSum"]).Text = ExpertSum.ToString();
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtQuickSum"]).Text = QuickSum.ToString();
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtTotal"]).Text = Convert.ToString(DaySum + NightSum + ExpertSum + QuickSum);            

				m_rptRpt.Refresh();
				m_objViewer.cryReportViewer.ReportSource=m_rptRpt;
                m_dtbSource = null;
			}
			else
				MessageBox.Show("加载数据时出错！！","iCare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			return;
		}
		#endregion

        #region 获取挂号员日报表数据 glzhang    2006.02.23
        /// <summary>
        /// 获取挂号员日报表数据 glzhang    2006.02.23
        /// </summary>
        private void m_mthGetRegisterReportData()
        {
            DataTable p_dtbRpt = new DataTable();
            DataTable m_dtbDatasourt = new DataTable();
            m_dtbDatasourt.Columns.Add("strColumn0"); //挂号员ID
            m_dtbDatasourt.Columns.Add("strColumn1"); //挂号员名称
            m_dtbDatasourt.Columns.Add("decColumn0", typeof(decimal)); //开票数
            m_dtbDatasourt.Columns.Add("decColumn1", typeof(decimal)); //开票金额
            m_dtbDatasourt.Columns.Add("decColumn2", typeof(decimal)); //退票数
            m_dtbDatasourt.Columns.Add("decColumn3", typeof(decimal)); //退票金额
            m_dtbDatasourt.Columns.Add("decColumn4", typeof(decimal)); //恢复票数
            m_dtbDatasourt.Columns.Add("decColumn5", typeof(decimal)); //恢复金额
            m_dtbDatasourt.Columns.Add("decColumn6", typeof(decimal)); //挂号费
            m_dtbDatasourt.Columns.Add("decColumn7", typeof(decimal)); //诊疗费
            m_dtbDatasourt.Columns.Add("decColumn8", typeof(decimal)); //工本费

            long lngRes = clsDomain.m_lngFindByDateReport2(m_objViewer.m_datFirstdate.Value.ToShortDateString(), m_objViewer.m_datLastdate.Value.ToShortDateString(), out p_dtbRpt);
            if (lngRes > 0)
            {
                for (int i1 = 0; i1 < p_dtbRpt.Rows.Count; i1++)
                {
                    bool blnNewRow = true;
                    decimal decSum = m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]) +
                            m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]) +
                            m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]);
                    for (int i2 = 0; i2 < m_dtbDatasourt.Rows.Count; i2++)
                    {
                        
                        if (m_dtbDatasourt.Rows[i2]["strColumn0"].ToString().Trim() == p_dtbRpt.Rows[i1]["empid"].ToString().Trim())
                        {
                            if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "1" || p_dtbRpt.Rows[i1]["flag_int"].ToString() == "2")
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) + 1;
                                m_dtbDatasourt.Rows[i2]["decColumn1"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn1"]) + decSum;
                                m_dtbDatasourt.Rows[i2]["decColumn6"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn6"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn7"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn7"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn8"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn8"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]);
                            }
                            else if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "3")
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn2"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn2"]) + 1;
                                m_dtbDatasourt.Rows[i2]["decColumn3"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn3"]) + decSum;
                                m_dtbDatasourt.Rows[i2]["decColumn6"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn6"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn7"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn7"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn8"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn8"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]);
                            }
                            else if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "4")
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn4"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn4"]) + 1;
                                m_dtbDatasourt.Rows[i2]["decColumn5"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn5"]) + decSum;
                                m_dtbDatasourt.Rows[i2]["decColumn6"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn6"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn7"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn7"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn8"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn8"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]);
                            }
                            blnNewRow = false;
                            break;
                        }
                    }
                    if (blnNewRow)
                    {
                        if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "1" || p_dtbRpt.Rows[i1]["flag_int"].ToString() == "2")
                        {
                            m_dtbDatasourt.Rows.Add(new object[] { 
                                p_dtbRpt.Rows[i1]["empid"].ToString().Trim(),
                                p_dtbRpt.Rows[i1]["lastname_vchr"].ToString().Trim(),
                                1,
                                decSum,
                                0,
                                0,
                                0,
                                0,
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"])
                             });
                        }
                        else if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "3")
                        {
                            m_dtbDatasourt.Rows.Add(new object[] { 
                                p_dtbRpt.Rows[i1]["empid"].ToString().Trim(),
                                p_dtbRpt.Rows[i1]["lastname_vchr"].ToString().Trim(),
                                0,
                                0,
                                1,
                                decSum,
                                0,
                                0,
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]),
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]),
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"])
                             });
                        }
                        else if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "4")
                        {
                            m_dtbDatasourt.Rows.Add(new object[] { 
                                p_dtbRpt.Rows[i1]["empid"].ToString().Trim(),
                                p_dtbRpt.Rows[i1]["lastname_vchr"].ToString().Trim(),
                                0,
                                0,
                                0,
                                0,
                                1,
                                decSum,
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"])
                             });
                        }
                    }
                }
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["fDate"]).Text = "统计日期:" + str_firstDate + " 至  " + str_lasttDate;
                m_rptRpt.SetDataSource(m_dtbDatasourt);
                m_rptRpt.Refresh();
                m_objViewer.cryReportViewer.ReportSource = m_rptRpt;
                p_dtbRpt = null;
            }
            else
                MessageBox.Show("加载数据时出错！！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region 获取挂号医生/科室收入报表数据 glzhang    2006.02.24
        /// <summary>
        /// 获取挂号医生/科室收入报表数据 glzhang    2006.02.24
        /// </summary>
        private void m_mthGetRegisterDocReportData(string p_strIDColumn,string p_strNameColumn)
        {
            string p_DeptName = "";
            DataTable p_dtbRpt = new DataTable();
            DataTable m_dtbDatasourt = new DataTable();
   
            m_dtbDatasourt.Columns.Add("strColumn0"); //医生ID
            m_dtbDatasourt.Columns.Add("strColumn1"); //医生名称
            m_dtbDatasourt.Columns.Add("decColumn0", typeof(decimal)); //挂号次数
            m_dtbDatasourt.Columns.Add("decColumn1", typeof(decimal)); //挂号费
            m_dtbDatasourt.Columns.Add("decColumn2", typeof(decimal)); //诊疗费
            m_dtbDatasourt.Columns.Add("decColumn3", typeof(decimal)); //工本费
            m_dtbDatasourt.Columns.Add("decColumn4", typeof(decimal)); //诊疗卡费
            m_dtbDatasourt.Columns.Add("decColumn5"); //科室名称（只用于医生门诊挂号收入报表）

            long lngRes = clsDomain.m_lngFindByDateReport(m_objViewer.m_datFirstdate.Value.ToShortDateString(), m_objViewer.m_datLastdate.Value.ToShortDateString(), out p_dtbRpt);
            if (lngRes > 0)
            {
                for (int i1 = 0; i1 < p_dtbRpt.Rows.Count; i1++)
                {
                    bool blnNewRow = true;
                    for (int i2 = 0; i2 < m_dtbDatasourt.Rows.Count; i2++)
                    {
                        if (m_dtbDatasourt.Rows[i2]["strColumn0"].ToString().Trim() == p_dtbRpt.Rows[i1][p_strIDColumn].ToString().Trim())
                        {
                            if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "3")
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) - 1;
                                m_dtbDatasourt.Rows[i2]["decColumn1"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn1"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn2"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn2"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn3"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn3"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn4"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn4"]) - m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["ccharge"]);
                            }
                            else
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) + 1;
                                m_dtbDatasourt.Rows[i2]["decColumn1"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn1"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn2"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn2"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn3"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn3"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]);
                                m_dtbDatasourt.Rows[i2]["decColumn4"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn4"]) + m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["ccharge"]);
                            }
                            blnNewRow = false;
                            break;
                        }
                    }
                    if (blnNewRow && !p_dtbRpt.Rows[i1][p_strIDColumn].Equals(DBNull.Value))
                    {
                        if (this.m_objViewer.m_cboReport.SelectedIndex == 1 && p_dtbRpt.Rows[i1]["deptname_vchr"] != null)
                        {
                            p_DeptName = p_dtbRpt.Rows[i1]["deptname_vchr"].ToString().Trim();
                        }
                        if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "3")
                        {
                            m_dtbDatasourt.Rows.Add(new object[] { 
                                p_dtbRpt.Rows[i1][p_strIDColumn].ToString().Trim(),
                                p_dtbRpt.Rows[i1][p_strNameColumn].ToString().Trim(),
                                -1,
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]),
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]),
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]),
                                -m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["ccharge"]),p_DeptName
                             });
                        }
                        else
                        {
                            m_dtbDatasourt.Rows.Add(new object[] { 
                                p_dtbRpt.Rows[i1][p_strIDColumn].ToString().Trim(),
                                p_dtbRpt.Rows[i1][p_strNameColumn].ToString().Trim(),
                                1,
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["rcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["dcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["gcharge"]),
                                m_decConvertObjToDecimal(p_dtbRpt.Rows[i1]["ccharge"]),p_DeptName
                             });
                        }
                        
                       
                    }
                }
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["fDate"]).Text = "统计日期:" + str_firstDate + " 至  " + str_lasttDate;
              
                m_rptRpt.SetDataSource(m_dtbDatasourt);
                m_rptRpt.Refresh();
                m_objViewer.cryReportViewer.ReportSource = m_rptRpt;
                p_dtbRpt = null;
            }
            else
                MessageBox.Show("加载数据时出错！！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region 挂号人数按时间段汇总数据    glzhang 2006.02.27
        /// <summary>
        /// 挂号人数按时间段汇总数据    glzhang 2006.02.27
        /// </summary>
        public void m_mthGetHourData()
        {
            DataTable p_dtbRpt = new DataTable();
            DataTable m_dtbDatasourt = new DataTable();
            m_dtbDatasourt.Columns.Add("strColumn0"); //小时 
            m_dtbDatasourt.Columns.Add("decColumn0", typeof(decimal)); //挂号人数
            for (int i1 = 0; i1 < 24; i1++)
            {
                m_dtbDatasourt.Rows.Add(new object[] { i1.ToString(), 0 });
            }

            long lngRes = clsDomain.m_lngFindByDateReport(m_objViewer.m_datFirstdate.Value.ToShortDateString(), m_objViewer.m_datLastdate.Value.ToShortDateString(), out p_dtbRpt);
            if (lngRes > 0)
            {
                for (int i1 = 0; i1 < p_dtbRpt.Rows.Count; i1++)
                {
                    bool blnNewRow = true;
                    for (int i2 = 0; i2 < m_dtbDatasourt.Rows.Count; i2++)
                    {
                        if (m_dtbDatasourt.Rows[i2]["strColumn0"].ToString() == Convert.ToDateTime(p_dtbRpt.Rows[i1]["recorddate_dat"]).Hour.ToString())
                        {
                            if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "3")
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) - 1;
                            }
                            else
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) + 1;
                            }
                            blnNewRow = false;
                            break;
                        }
                    }
                }
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["fDate"]).Text = "统计日期:" + str_firstDate + " 至  " + str_lasttDate;
                m_rptRpt.SetDataSource(m_dtbDatasourt);
                m_rptRpt.Refresh();
                m_objViewer.cryReportViewer.ReportSource = m_rptRpt;
                p_dtbRpt = null;
            }
            else
                MessageBox.Show("加载数据时出错！！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region 挂号人数按星期汇总数据    glzhang 2006.02.27
        /// <summary>
        /// 挂号人数按星期汇总数据    glzhang 2006.02.27
        /// </summary>
        public void m_mthGetWeekData()
        {
            DataTable p_dtbRpt = new DataTable();
            DataTable m_dtbDatasourt = new DataTable();
            m_dtbDatasourt.Columns.Add("strColumn0"); //星期几
            m_dtbDatasourt.Columns.Add("strColumn1"); //星期几中文名 
            m_dtbDatasourt.Columns.Add("decColumn0", typeof(decimal)); //挂号人数
            m_dtbDatasourt.Rows.Add(new object[] { "Sunday", "星期日", 0 });
            m_dtbDatasourt.Rows.Add(new object[] { "Monday", "星期一", 0 });
            m_dtbDatasourt.Rows.Add(new object[] { "Tuesday", "星期二", 0 });
            m_dtbDatasourt.Rows.Add(new object[] { "Wednesday", "星期三", 0 });
            m_dtbDatasourt.Rows.Add(new object[] { "Thursday", "星期四", 0 });
            m_dtbDatasourt.Rows.Add(new object[] { "Friday", "星期五", 0 });
            m_dtbDatasourt.Rows.Add(new object[] { "Saturday", "星期六", 0 });

            long lngRes = clsDomain.m_lngFindByDateReport(m_objViewer.m_datFirstdate.Value.ToShortDateString(), m_objViewer.m_datLastdate.Value.ToShortDateString(), out p_dtbRpt);
            if (lngRes > 0)
            {
                for (int i1 = 0; i1 < p_dtbRpt.Rows.Count; i1++)
                {
                    bool blnNewRow = true;
                    for (int i2 = 0; i2 < m_dtbDatasourt.Rows.Count; i2++)
                    {
                        if (m_dtbDatasourt.Rows[i2]["strColumn0"].ToString() == Convert.ToDateTime(p_dtbRpt.Rows[i1]["recorddate_dat"]).DayOfWeek.ToString())
                        {
                            if (p_dtbRpt.Rows[i1]["flag_int"].ToString() == "3")
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) - 1;
                            }
                            else
                            {
                                m_dtbDatasourt.Rows[i2]["decColumn0"] = m_decConvertObjToDecimal(m_dtbDatasourt.Rows[i2]["decColumn0"]) + 1;
                            }
                            blnNewRow = false;
                            break;
                        }
                    }
                }
                ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["fDate"]).Text = "统计日期:" + str_firstDate + " 至  " + str_lasttDate;
                m_rptRpt.SetDataSource(m_dtbDatasourt);
                m_rptRpt.Refresh();
                m_objViewer.cryReportViewer.ReportSource = m_rptRpt;
                p_dtbRpt = null;
            }
            else
                MessageBox.Show("加载数据时出错！！", "iCare", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region 转换成数字
        private decimal m_decConvertObjToDecimal(object obj)
        {
            if (obj != null && obj.ToString() != "")
            {
                return Convert.ToDecimal(obj.ToString());

            }
            else
            {
                return 0;
            }
        }
        #endregion


        #region 调用域控件方法返回数据集
        public void Statistic()
        {

            string m_strStartDateTimer;
            string m_strEndDateTimer;
            long lngs = 0;
            DataTable dt=null;
            m_strStartDateTimer = this.m_objViewer.m_datFirstdate.Value.ToShortDateString();
            m_strEndDateTimer = this.m_objViewer.m_datLastdate.Value.ToShortDateString();
            if(this.m_objViewer.m_cboReport.SelectedIndex==2)
            lngs = this.clsDomain.m_GetRegReportPicture(m_strStartDateTimer, m_strEndDateTimer, out dt);
        if (this.m_objViewer.m_cboReport.SelectedIndex == 1)
            lngs = this.clsDomain.m_GetRegReportDoctPicture(m_strStartDateTimer, m_strEndDateTimer, out dt);

            if (lngs < 0)
            {
                return;
            }
            if (dt.Rows.Count == 0)
            {

                this.m_objViewer.m_datFirstdate.Focus();
                MessageBox.Show("对不起，数据库无记录");
                m_showReport(dt);
                return;
            }
            else
                m_showReport(dt);
        }
        #endregion
        #region 显示报表
        public void m_showReport(DataTable dt)
        {
            // CrystalDecisions.CrystalReports.Engine.ReportDocument rpt;
            //rpt=new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //			for(int i=0;i<dt.Rows.Count;i++)
            //			{
            //				if(dt.Rows[i]["ccharge"].ToString()=="")
            //					dt.Rows[i]["ccharge"]=0;
            //			}
           // HISMedTypeManage.Rpt.CrystalReportRoomPicture rpt = new HISMedTypeManage.Rpt.CrystalReportRoomPicture();
            //rpt.Load(@"..HISMedTypeManage.Rpt.CrystalReport4");
            m_rptRpt.SetDataSource(dt);
            ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["Text6"]).Text = Convert.ToDateTime(this.m_objViewer.m_datFirstdate.Value).ToString("yyyy年 MM月dd日");
            ((TextObject)m_rptRpt.ReportDefinition.ReportObjects["Text7"]).Text = Convert.ToDateTime(this.m_objViewer.m_datLastdate.Value).ToString("yyyy年 MM月dd日");
            m_rptRpt.Refresh();
            this.m_objViewer.cryReportViewer.ReportSource = m_rptRpt;
        }

        #endregion 显示报表
    }
}
