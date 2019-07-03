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
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsControlCheckOutOfDay 的摘要说明。
	/// </summary>
	public class clsControlCheckOutOfDay: com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlCheckOutOfDay()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        /// <summary>
        /// 重打发票号数组
        /// </summary>
        public string[] m_strInvoArr = null;
        public decimal[] m_decInvoMny = null;
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.Reports.frmCheckOutOfDay m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmCheckOutOfDay)frmMDI_Child_Base_in;
		}
		#endregion

		DataTable dtCheckOut=new DataTable();
		DataTable dtPayType=new DataTable();
		clsDomainControl_Register Domain=new clsDomainControl_Register();
		private DataTable dtStatistics=new DataTable();
		private DataRow StatisticsRow;
		private ArrayList SaveINVOICENO=new ArrayList();
		/// <summary>
		/// 0-未结帐1-结帐
		/// </summary>
		int intcomand=0;
		string strCheckDate="";
		private ArrayList arrList;
		private ArrayList arrReList=new ArrayList();
		string strCheckManID="";
        string strName = "";        

		public  void getData()
		{
			if(this.m_objViewer.isDoctorDean==true)
			{
				intcomand=1;
				strCheckManID=this.m_objViewer.m_cboCheckMan.SelectItemValue.ToString();
			}
			else
			{
				strCheckManID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			arrReList.Clear();
			SaveINVOICENO.Clear();
			if(intcomand==0)
			{
                com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
				string checkDate=HisBase.s_GetServerDate().ToString();
				Domain.m_lngGetPayTypeAndCheckOutData(strCheckManID,checkDate,out dtPayType,out dtCheckOut);
                Domain.m_mthGetbalancerepeatinvoinfo(strCheckManID, checkDate, out this.m_strInvoArr, intcomand, out m_decInvoMny);
				strCheckDate=this.m_objViewer.DateCheckOut.Value.ToShortDateString();
				this.m_objViewer.btnPrint.Enabled=false;
				this.m_objViewer.buttonXP3.Enabled=false;
				this.m_objViewer.buttonXP2.Enabled=false;
				this.m_objViewer.buttonXP4.Enabled=false;               
			}
			else
			{
				strCheckDate=this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.CurrentCell.RowNumber,0].ToString();
				string BALANCEEMP=this.m_objViewer.LoginInfo.m_strEmpID;
				string CheckDate=this.m_objViewer.DateCheckOut.Value.ToShortDateString();
				Domain.m_lngGetPayTypeAndCheckOutDatahistory(strCheckDate,strCheckManID,out dtPayType,out dtCheckOut);
                Domain.m_mthGetbalancerepeatinvoinfo(strCheckManID, strCheckDate, out this.m_strInvoArr, intcomand, out m_decInvoMny);
				this.m_objViewer.btnCheck.Enabled=false;
				this.m_objViewer.btnPrint.Enabled=true;
				this.m_objViewer.buttonXP3.Enabled=true;
				this.m_objViewer.buttonXP2.Enabled=true;
				this.m_objViewer.buttonXP4.Enabled=true;
			}            

			arrList=new ArrayList();
			DataTable dt=new DataTable();
			dt.Columns.Add("OPREMP_CHR");
			dt.Columns.Add("STATUS_INT");
			dt.Columns.Add("invoiceno_vchr");
			for(int k1=0;k1<dtCheckOut.Rows.Count;k1++)
			{
				DataRow newRow=dt.NewRow();
				newRow["OPREMP_CHR"]=dtCheckOut.Rows[k1]["OPREMP_CHR"];
				newRow["STATUS_INT"]=dtCheckOut.Rows[k1]["STATUS_INT"];
				newRow["invoiceno_vchr"]=dtCheckOut.Rows[k1]["invoiceno_vchr"];
				dt.Rows.Add(newRow);
			}
			for(int i1=0;i1<dt.Rows.Count;i1++)
			{
				if(dt.Rows[i1]["STATUS_INT"].ToString()=="2"||dt.Rows[i1]["STATUS_INT"].ToString()=="3")
				{
					dt.Rows[i1].Delete();
					i1--;
					dt.AcceptChanges();
				}
			}
			dt.AcceptChanges();
			clsMain.m_Detach(dt,"INVOICENO_VCHR",out arrList);
			#region 生成一个统计表
//			DataTable dtStatistics=new DataTable();
			dtStatistics=new DataTable();
			dtStatistics.Columns.Add("开票数");
			dtStatistics.Columns.Add("开票金额");
			dtStatistics.Columns.Add("退票数");
			dtStatistics.Columns.Add("退票金额合计");
			dtStatistics.Columns.Add("恢复票数");
			dtStatistics.Columns.Add("恢复金额合计");
			dtStatistics.Columns.Add("有效票数");
			dtStatistics.Columns.Add("实收金额合计");
			dtStatistics.Columns.Add("实收现金合计");
			dtStatistics.Columns.Add("刷卡金额合计");
			dtStatistics.Columns.Add("支票金额合计");
			dtStatistics.Columns.Add("医保记账金额");
			dtStatistics.Columns.Add("公费记账金额");
			dtStatistics.Columns.Add("自费上缴金额");
			dtStatistics.Columns.Add("医保人次");
			dtStatistics.Columns.Add("公费人次");
			dtStatistics.Columns.Add("自费及其它人次");
			dtStatistics.Columns.Add("自费人次");
			dtStatistics.Columns.Add("其它记帐金额");
			dtStatistics.Columns.Add("开始发票号");
			dtStatistics.Columns.Add("结束发票号");
			dtStatistics.Columns.Add("第一张发票时间");
			dtStatistics.Columns.Add("最后一张发票时间");
           
			dtStatistics.Columns.Add("其它金额合计");
			dtStatistics.Columns.Add("IC卡金额合计");
			dtStatistics.Columns.Add("特困记帐");
			dtStatistics.Columns.Add("离休记帐");
			dtStatistics.Columns.Add("本院记帐");
			dtStatistics.Columns.Add("其它记帐");
            dtStatistics.Columns.Add("门诊合作医疗记帐");
			#endregion

			#region 统计各种收费类型的金额
			dtPayType.Columns.Add("tolMoney");
			if(dtCheckOut.Rows.Count>=0)
			{
				if(intcomand==0)
				{
					this.m_objViewer.btnCheck.Enabled=true;
				}
//				this.m_objViewer.btnPrint.Enabled=true;
				for(int i1=0;i1<dtPayType.Rows.Count;i1++)
				{
					Double tolMoney=0;
					for(int f2=0;f2<dtCheckOut.Rows.Count;f2++)
					{
						if(dtCheckOut.Rows[f2]["ITEMCATID_CHR"].ToString().Trim()==dtPayType.Rows[i1]["TYPEID_CHR"].ToString().Trim())
						{
							tolMoney+=Convert.ToDouble(dtCheckOut.Rows[f2]["TOLFEE_MNY"].ToString().Trim());
						}
					}
					dtPayType.Rows[i1]["tolMoney"]=tolMoney.ToString("0.00");
				}
			}
			else
			{
					this.m_objViewer.btnCheck.Enabled=false;
					this.m_objViewer.btnPrint.Enabled=false;
				this.m_objViewer.buttonXP3.Enabled=false;
				this.m_objViewer.buttonXP2.Enabled=false;
			}

			#endregion

			#region 统计数据
			StatisticsRow=dtStatistics.NewRow();
			StatisticsRow["开票数"]=0;
			StatisticsRow["开票金额"]=0.00;
			StatisticsRow["退票数"]=0;
			StatisticsRow["退票金额合计"]=0.00;
			StatisticsRow["恢复票数"]=0;
			StatisticsRow["恢复金额合计"]=0.00;

			StatisticsRow["实收现金合计"]=0.00;
			StatisticsRow["刷卡金额合计"]=0.00;

			StatisticsRow["支票金额合计"]=0.00;
			StatisticsRow["医保记账金额"]=0.00;
			StatisticsRow["公费记账金额"]=0.00;
			StatisticsRow["自费上缴金额"]=0.00;

			StatisticsRow["实收金额合计"]=0.00;
			StatisticsRow["其它记帐金额"]=0.00;
			StatisticsRow["医保人次"]=0;
			StatisticsRow["公费人次"]=0;
			StatisticsRow["自费及其它人次"]=0;
			StatisticsRow["自费人次"]=0;
			StatisticsRow["其它金额合计"]=0;
			StatisticsRow["IC卡金额合计"]=0;
			StatisticsRow["特困记帐"]=0;
			StatisticsRow["离休记帐"]=0;
			StatisticsRow["本院记帐"]=0;
			StatisticsRow["其它记帐"]=0;
			StatisticsRow["第一张发票时间"]="";
			StatisticsRow["最后一张发票时间"]="";
            StatisticsRow["门诊合作医疗记帐"] = 0;
			DateTime startDateTime=new DateTime();
			DateTime endDateTime=new DateTime();
			if(dtCheckOut.Rows.Count>0)
			{
				StatisticsRow["开始发票号"]=dtCheckOut.Rows[0]["INVOICENO_VCHR"].ToString();
				StatisticsRow["结束发票号"]=dtCheckOut.Rows[dtCheckOut.Rows.Count-1]["INVOICENO_VCHR"].ToString();
				for(int i1=0;i1<dtCheckOut.Rows.Count;i1++)
				{
					//计算发票的第一张和最后一张
					if(i1==0)
					{
						StatisticsRow["第一张发票时间"]=Convert.ToDateTime(dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString());
						StatisticsRow["最后一张发票时间"]=Convert.ToDateTime(dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString());
					}
					else
					{
						if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())<Convert.ToDateTime(StatisticsRow["第一张发票时间"].ToString()))
						{
							StatisticsRow["第一张发票时间"]=Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString());
						}
						if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())>Convert.ToDateTime(StatisticsRow["最后一张发票时间"].ToString()))
						{
							StatisticsRow["最后一张发票时间"]=Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString());
						}
					}

					//-----------------------

					//统计开票数,开票金额

					if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="1")//统计开票数,开票金额
					{
						if(i1==0)
						{
							StatisticsRow["开票数"]=Convert.ToInt16(StatisticsRow["开票数"].ToString())+1;
							StatisticsRow["开票金额"]=Convert.ToDouble(StatisticsRow["开票金额"].ToString())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								StatisticsRow["开票数"]=Convert.ToInt16(StatisticsRow["开票数"].ToString())+1;
								StatisticsRow["开票金额"]=Convert.ToDouble(StatisticsRow["开票金额"].ToString())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
							}
						}

					}

					//-------------------------


					//退票数,退票金额合计,所有的退票号
					if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")//退票数,退票金额合计,所有的退票号
					{
						if(i1==0)
						{
							StatisticsRow["退票数"]=Convert.ToInt16(StatisticsRow["退票数"].ToString())+1;
							StatisticsRow["退票金额合计"]=Convert.ToDouble(StatisticsRow["退票金额合计"].ToString())-Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
							SaveINVOICENO.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								StatisticsRow["退票数"]=Convert.ToInt16(StatisticsRow["退票数"].ToString())+1;
								StatisticsRow["退票金额合计"]=Convert.ToDouble(StatisticsRow["退票金额合计"].ToString())-Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
								SaveINVOICENO.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
							}
							
						}
						
					}

					//--------------------------

					//恢复票数,恢复金额合计
					if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="3")//恢复票数,恢复金额合计
					{
						if(i1==0)
						{
							StatisticsRow["恢复票数"]=Convert.ToInt16(StatisticsRow["恢复票数"].ToString())+1;
							StatisticsRow["恢复金额合计"]=Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
							arrReList.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
							
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								StatisticsRow["恢复票数"]=Convert.ToInt16(StatisticsRow["恢复票数"].ToString())+1;
								StatisticsRow["恢复金额合计"]=Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
								arrReList.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
							}
						}
					}

					//----------------------



					//统计现金合计

					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="0")//统计现金合计
					{
						if(i1==0)
						{
								StatisticsRow["实收现金合计"]=Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());

						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
									StatisticsRow["实收现金合计"]=Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
							}
						}

					}

					//-----------------------


					//刷卡合计
					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="1")//刷卡合计
					{
						if(i1==0)
						{

//							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
//							    StatisticsRow["刷卡金额合计"]=Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim())-Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
//							else
								StatisticsRow["刷卡金额合计"]=Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
									StatisticsRow["刷卡金额合计"]=Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
							}
						}

					}

					//---------------


					//支票
					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="2")//支票
					{
						if(i1==0)
						{
//							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
//							{
//								StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())-Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
//							}
//							else
//							{
								StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
//							}
					     }
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
//								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
//								{
//									StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
//								}
//								else
//								{
									StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
//								}
							}
						}
						
					}
					//------------------
                    //门诊合作医疗记账金额

                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "6")//门诊合作医疗记账
                    {
                        if (i1 == 0)
                        {
                            if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                            {

                                StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                            else
                            {

                                StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                if (dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim() == "2")
                                {

                                    StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                                else
                                {

                                    StatisticsRow["门诊合作医疗记帐"] = Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                                }
                            }
                        }
                    }
					//医保记账金额及人次
				
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="2")//医保记账金额及人次
					{
						if(i1==0)
						{
							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
							{
								StatisticsRow["医保人次"]=Convert.ToInt32(StatisticsRow["医保人次"].ToString())-1;
								StatisticsRow["医保记账金额"]=Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
							else
							{
								StatisticsRow["医保人次"]=Convert.ToInt32(StatisticsRow["医保人次"].ToString())+1;
								StatisticsRow["医保记账金额"]=Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
								{
									StatisticsRow["医保人次"]=Convert.ToInt32(StatisticsRow["医保人次"].ToString())-1;
									StatisticsRow["医保记账金额"]=Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
								else
								{
									StatisticsRow["医保人次"]=Convert.ToInt32(StatisticsRow["医保人次"].ToString())+1;
									StatisticsRow["医保记账金额"]=Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
							}
						}
					}
					//-------------
					if(this.m_objViewer.Hospital_No == "00001")
					{
						//其它记帐金额及人次
						if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="3"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="6")
						{
							if(i1==0)
							{
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
								{
									StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())-1;
									StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
								else
								{
									StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())+1;
									StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}

							}
							else
							{
								if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
								{
							
								}
								else
								{
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
									{
										StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())-1;
										StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
									}
									else
									{
										StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())-1;
										StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
									}
								}
							}
						}
					}
					else
					{
						if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="6")
						{
							if(i1==0)
							{
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
								{
									StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())-1;
									StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
								else
								{
									StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())+1;
									StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}

							}
							else
							{
								if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
								{
							
								}
								else
								{
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
									{
										StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())-1;
										StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
									}
									else
									{
										StatisticsRow["自费及其它人次"]=Convert.ToInt32(StatisticsRow["自费及其它人次"].ToString())-1;
										StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
									}
								}
							}
						}
					}


					//公费记账金额及人次
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="1")//公费记账金额及人次
					{
						if(i1==0)
						{
							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
							{
								StatisticsRow["公费人次"]=Convert.ToInt32(StatisticsRow["公费人次"].ToString())-1;
								StatisticsRow["公费记账金额"]=Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
							else
							{
								StatisticsRow["公费人次"]=Convert.ToInt32(StatisticsRow["公费人次"].ToString())+1;
								StatisticsRow["公费记账金额"]=Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}

						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
								{
									StatisticsRow["公费人次"]=Convert.ToInt32(StatisticsRow["公费人次"].ToString())-1;
									StatisticsRow["公费记账金额"]=Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
								else
								{
									StatisticsRow["公费人次"]=Convert.ToInt32(StatisticsRow["公费人次"].ToString())+1;
									StatisticsRow["公费记账金额"]=Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
							}
						}
					}

					//-------------------
						
					//自费上缴金额及人次
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="0")//自费上缴金额及人次
					{
						if(i1==0)
						{
							if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
							{
								StatisticsRow["自费人次"]=Convert.ToInt32(StatisticsRow["自费人次"].ToString())-1;
								StatisticsRow["自费上缴金额"]=Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
							}
							else
							{
								StatisticsRow["自费人次"]=Convert.ToInt32(StatisticsRow["自费人次"].ToString())+1;
								StatisticsRow["自费上缴金额"]=Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
							}
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")
								{
									StatisticsRow["自费人次"]=Convert.ToInt32(StatisticsRow["自费人次"].ToString())-1;
									StatisticsRow["自费上缴金额"]=Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
								}
								else
								{
									StatisticsRow["自费人次"]=Convert.ToInt32(StatisticsRow["自费人次"].ToString())+1;
									StatisticsRow["自费上缴金额"]=Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
								}
							}
						}
						
					}
					#region 特困记账金额
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="3")
					{
						if(i1==0)
						{

							StatisticsRow["特困记帐"]=Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{

								StatisticsRow["特困记帐"]=Convert.ToDouble(StatisticsRow["特困记帐"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
						}
					}

					#endregion

					#region 离休记账金额
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="4")
					{
						if(i1==0)
						{

							StatisticsRow["离休记帐"]=Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{

								StatisticsRow["离休记帐"]=Convert.ToDouble(StatisticsRow["离休记帐"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
						}
					}

					#endregion

					#region 本院记账金额
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="5")
					{
						if(i1==0)
						{

							StatisticsRow["本院记帐"]=Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{

								StatisticsRow["本院记帐"]=Convert.ToDouble(StatisticsRow["本院记帐"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
						}
					}

					#endregion

					#region IC卡支付
				
					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="3")
					{
						if(i1==0)
						{
							StatisticsRow["IC卡金额合计"]=Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
						}
						else
						{
							if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
							{
							
							}
							else
							{
								StatisticsRow["IC卡金额合计"]=Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
							}
						}

					}

					#endregion

					#region 其它金额合计
                    //if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="0"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="3"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5")
                    //{
                    //    if(i1==0)
                    //    {
                    //        StatisticsRow["其它金额合计"]=Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                    //    }
                    //    else
                    //    {
                    //        if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
                    //        {
							
                    //        }
                    //        else
                    //        {
                    //            StatisticsRow["其它金额合计"]=Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
                    //        }
                    //    }
                    //}

                    ////佛二：其它支付－>其它记帐
                    if (dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim() == "0")
                    {
                        if (i1 == 0)
                        {

                            StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());

                        }
                        else
                        {
                            if (dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["INVOICENO_VCHR"].ToString().Trim() && dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim() == dtCheckOut.Rows[i1 - 1]["SEQID_CHR"].ToString().Trim())
                            {

                            }
                            else
                            {
                                StatisticsRow["其它金额合计"] = Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim()) + Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
                            }
                        }
                    }

					#endregion
				}
			}

			//---------------------

			//计算有效票数
			int intAvailability=Convert.ToInt32(StatisticsRow["开票数"].ToString().Trim())-Convert.ToInt32(StatisticsRow["退票数"].ToString().Trim())+Convert.ToInt32(StatisticsRow["恢复票数"].ToString().Trim());

			//计算有效金额
			Double AvailabilityMoney=Convert.ToDouble(StatisticsRow["开票金额"].ToString().Trim())-Convert.ToDouble(StatisticsRow["退票金额合计"].ToString().Trim())+Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString().Trim());

			StatisticsRow["有效票数"]=intAvailability.ToString();
			StatisticsRow["实收金额合计"]=AvailabilityMoney.ToString();
			#endregion

			#region 设置打印
			this.m_objViewer.printDocument1.DefaultPageSettings.Landscape=false;
//			foreach(PaperSize ps in this.m_objViewer.printDocument1.PrinterSettings.PaperSizes)
//			{
//				if(ps.PaperName=="日结算报表")
//				{
            if (this.m_objViewer.Hospital_No != "00001")
            {
                PaperSize ps = new PaperSize("日结算报表", 900, 512);
                this.m_objViewer.printDocument1.DefaultPageSettings.PaperSize = ps;
            }
            else
            {
                PaperSize ps = new PaperSize("日结算报表", 900, 700);
                this.m_objViewer.printDocument1.DefaultPageSettings.PaperSize = ps;
            }
//					break;
//				}
//			}
			#endregion
		}

		#region 各类发票打印
		/// <summary>
		/// 统计发票
		/// </summary>
		/// <param name="intsta"></param>
		/// <param name="arrCheck"></param>
		/// <param name="arrReturn"></param>
		/// <param name="arrBreck"></param>
		/// <param name="totailMoney"></param>
		private void m_mthCheckNO(int intsta,out ArrayList arrCheck,out ArrayList arrReturn,out ArrayList arrBreck,out string totailMoney,out string  minCheckDate,out string maxCheckDate,out DataTable dtCheckNo)
		{
		
				int Rowint=0;
				arrReturn=new ArrayList();
				arrBreck=new ArrayList();
			    
				arrCheck=new ArrayList();
				minCheckDate="";
				maxCheckDate="";
				double momey=0;
				totailMoney="0";
				dtCheckNo=new DataTable();
				dtCheckNo.Columns.Add("CheckNo");
				if(dtCheckOut.Rows.Count>0)
				{
					for(int i1=0;i1<dtCheckOut.Rows.Count;i1++)
					{
						#region 统计现金发票
						if(intsta==1&&dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()=="0")
						{
							//计算发票的第一张和最后一张
							if(Rowint==0)
							{
								minCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
								maxCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
							}
							else
							{
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())<Convert.ToDateTime(minCheckDate))
								{
									minCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())>Convert.ToDateTime(maxCheckDate))
								{
									maxCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
							}
							Rowint++;
							DataRow newRow=dtCheckNo.NewRow();
							newRow["CheckNo"]=dtCheckOut.Rows[i1]["INVOICENO_VCHR"];
							dtCheckNo.Rows.Add(newRow);
							int INTERNALFLAG=int.Parse(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim());
							if(i1==0)
							{
						
								arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
								{
									arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
								{
									arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
							
								if(INTERNALFLAG==1||INTERNALFLAG==2||(INTERNALFLAG<0||INTERNALFLAG>2))
								{
									momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
								}
								else
								{
									momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
								}
							}
							else
							{
								if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
								{
							
								}
								else
								{
									arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
									{
										arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
									{
										arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(INTERNALFLAG==1||INTERNALFLAG==2||(INTERNALFLAG<0||INTERNALFLAG>2))
									{
										momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
									}
									else
									{
										momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
									}
								}
							
							}
						}
						#endregion
					
						#region 统计医保及刷卡发票
						if(intsta==2&&(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString()=="2"||dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString()=="1"))
						{
							DataRow[] objRow=dtCheckOut.Select("INTERNALFLAG_INT=2 or PAYTYPE_INT=1");

							//计算发票的第一张和最后一张
							if(Rowint==0)
							{
								minCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
								maxCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
							}
							else
							{
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())<Convert.ToDateTime(minCheckDate))
								{
									minCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())>Convert.ToDateTime(maxCheckDate))
								{
									maxCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
							}
							Rowint++;
							if(i1==0)
							{
								arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
								{
									arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
								{
									arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
								{
									arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="2")
								{
									momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}

								if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="1")
								{
									momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
								}
							}
							else
							{
								if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
								{
							
								}
								else
								{
									arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
									{
										arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
									{
										arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
									{
										arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="2")
									{
										momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
									}
									if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="1")
									{
										momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
									}
								}
							
							}
						}
						#endregion

						#region 统计公费发票
						if(intsta==3&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString()=="1")
						{
							//计算发票的第一张和最后一张
							if(Rowint==0)
							{
								minCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
								maxCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
							}
							else
							{
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())<Convert.ToDateTime(minCheckDate))
								{
									minCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())>Convert.ToDateTime(maxCheckDate))
								{
									maxCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
							}
							Rowint++;
							if(i1==0)
							{
								arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
								{
									arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
								{
									arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
							else
							{
								if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
								{
							
								}
								else
								{
									arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
									{
										arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
									{
										arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
							
							}
						}
						#endregion

						#region 统计其它发票
						if(intsta==4&&dtCheckOut.Rows[i1]["internalflag_int"].ToString()!="1"&&dtCheckOut.Rows[i1]["internalflag_int"].ToString()!="2"&&dtCheckOut.Rows[i1]["internalflag_int"].ToString()!="0")
						{

							//计算发票的第一张和最后一张
							if(Rowint==0)
							{
								minCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
								maxCheckDate=dtCheckOut.Rows[0]["RECORDDATE_DAT"].ToString();
							}
							else
							{
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())<Convert.ToDateTime(minCheckDate))
								{
									minCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
								if(Convert.ToDateTime(dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString())>Convert.ToDateTime(maxCheckDate))
								{
									maxCheckDate=dtCheckOut.Rows[i1]["RECORDDATE_DAT"].ToString();
								}
							}
							Rowint++;
							if(i1==0)
							{
								arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
								{
									arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
								{
									arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
								}
								momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
							}
							else
							{
								if(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["INVOICENO_VCHR"].ToString().Trim()&&dtCheckOut.Rows[i1]["SEQID_CHR"].ToString().Trim()==dtCheckOut.Rows[i1-1]["SEQID_CHR"].ToString().Trim())
								{
							
								}
								else
								{
									arrCheck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="3")
									{
										arrBreck.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString()=="2")
									{
										arrReturn.Add(dtCheckOut.Rows[i1]["INVOICENO_VCHR"].ToString());
									}
									momey+=Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
								}
							
							}
						}
						#endregion

					}
				}
				else
				{
					return;
				}
				totailMoney=momey.ToString();
		}
		#region 打印分类票
		/// <summary>
		/// 打印分类票
		/// </summary>
		/// <param name="e"></param>
		public void printPageCheckNoMB(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=0;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",14);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",10);//文字使用的字体
			const float RowHight=23F;//项的高度
			const float LeftWith=10F;//左宿进的长度
			const float RightWith=50F;//右宿进的长度
			ArrayList arrCheck=null;//发票号
			ArrayList arrReturn=null;//退票发票号
			string totailMoney="0";//总金额
			ArrayList arrBreck=null;//还原发票号
			string minCheckDate="";//开始发票号
			string  maxCheckDate="";//结束发票号
		
			DataTable dtCheckNo=null;//保存现金发票号表
			//发票分组
			ArrayList arr1=new ArrayList();
			#endregion
			for(int f1=1;f1<5;f1++)
			{
				#region 头部
				Pen penLine=new Pen(Brushes.Black,1);
				curRowY+=15;
				curRowX=LeftWith;
				SizeF tilWith= e.Graphics.MeasureString("收费员医保及刷卡日结报表",m_fntTitle);
				string strTiteName="";
				switch(f1)
				{
					case 1:
							strTiteName="收费员现金发票日结报表";
							m_mthCheckNO(1,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
							clsMain.m_Detach(dtCheckNo,"CheckNo",out arr1);
						break;
					case 2:
							strTiteName="收费员医保及刷卡发票日结报表";
							m_mthCheckNO(2,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						break;
					case 3:
						strTiteName="收费员公费发票日结报表";
						m_mthCheckNO(3,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						break;
					case 4:
							strTiteName="收费员其它发票日结报表";
							m_mthCheckNO(4,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						break;
				}
				e.Graphics.DrawString(strTiteName,m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,curRowY);
				curRowY+=25;
				e.Graphics.DrawString("实收日期：",TextFont,Brushes.Black,curRowX,curRowY);
				tilWith= e.Graphics.MeasureString("实收日期：",TextFont);
				curRowX+=tilWith.Width;
				e.Graphics.DrawString(strCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
				curRowX+=150;
				e.Graphics.DrawString("发票日期：",TextFont,Brushes.Black,curRowX,curRowY);
				tilWith= e.Graphics.MeasureString("发票日期：",TextFont);
				curRowX+=tilWith.Width;

				e.Graphics.DrawString(minCheckDate+" ~ "+maxCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
				curRowX+=300;
				e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,curRowX+5,curRowY);
				tilWith= e.Graphics.MeasureString("打印日期： ",TextFont);
				string NowDate=DateTime.Now.ToShortDateString();
				e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,curRowX+tilWith.Width,curRowY);
				#endregion
				curRowX=LeftWith;
				curRowY+=15;
				float strLine=curRowY;
			
				#region 画表格
				for(int i1=0;i1<4;i1++)
				{
					float tmpWith=20;//X轴
					
					switch(i1)
					{
						case 0:
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							curRowY+=5;
							e.Graphics.DrawString("合计金额大写",TextFont,Brushes.Black,curRowX+5,curRowY);
							e.Graphics.DrawLine(penLine,curRowX+100,strLine,curRowX+100,curRowY+20);
							e.Graphics.DrawString(clsMain.CurrencyToString(Math.Abs(float.Parse(totailMoney))),TextFont,Brushes.Black,curRowX+100,curRowY);
							
							e.Graphics.DrawLine(penLine,PageWidth-250,strLine,PageWidth-250,curRowY+20);
							e.Graphics.DrawString("合计金额小写",TextFont,Brushes.Black,PageWidth-245,curRowY);

							e.Graphics.DrawLine(penLine,PageWidth-145,strLine,PageWidth-145,curRowY+20);
							e.Graphics.DrawString("￥"+totailMoney,TextFont,Brushes.Black,PageWidth-140,curRowY);
							curRowY+=20;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 1:
							curRowY+=50;
							float temY=0;
							if(f1==1)
							{
								
								if(arr1.Count>0)
								{
									curRowY-=50;
									int intRow=0;
									int tolRow=0;
									for(int f2=0;f2<arr1.Count;f2++)
									{
										if(arr1[f2].ToString()==",")
											tolRow++;
									}
									if(tolRow>=4)
									{
										temY=5;
									}
									else
									{
										temY=10;
									}
									
									e.Graphics.DrawString(arr1[0].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
									int intCount=0;
									for(int j2=0;j2<arr1.Count;j2++)
									{
						
										if(intRow==4&&intCount==0)
										{
											intCount++;
											curRowY=temY+10+curRowY;
											tmpWith=20;
										}
										try
										{
											if(arr1[j2].ToString()==",")
											{
												intRow++;
												tilWith=e.Graphics.MeasureString("- "+arr1[0].ToString(),TextFont);
												tmpWith+=tilWith.Width;
											
												e.Graphics.DrawString("- "+arr1[j2-1].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
												if(j2!=arr1.Count-1)
												{
													tilWith= e.Graphics.MeasureString("- "+arr1[0].ToString(),TextFont);
													tmpWith+=tilWith.Width;
													e.Graphics.DrawString(","+arr1[j2+1].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
												}	
											}
										}
										catch
										{
										}
									}
									tilWith=e.Graphics.MeasureString("- "+arr1[0].ToString(),TextFont);
									tmpWith+=tilWith.Width;
									e.Graphics.DrawString("- "+arr1[arr1.Count-1].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
									curRowY+=(intCount+3)*temY;
								}
							}
							else
							{
								
								float tempX;
								float tempY;
								if(arrCheck.Count>0)
								{
									curRowY-=50;
									tempX=tmpWith;
									tempY=curRowY+10;
									int RowCount=1;
									for(int k1=0;k1<arrCheck.Count;k1++)
									{
										if(k1==0)
										{
											e.Graphics.DrawString(arrCheck[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(arrCheck[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										else
										{
											e.Graphics.DrawString(","+arrCheck[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(","+arrCheck[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										if(k1!=arrCheck.Count&&tempX+tilWith.Width>=PageWidth-RightWith)
										{
											RowCount++;
											tempX=tmpWith;
											tempY=curRowY+15*RowCount;
											
										}
									}
									curRowY=tempY+20;
								}
								
							}
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 2:
							try
							{
							float tempX=0;
							float tempY=0;
							e.Graphics.DrawString("退票发票号",TextFont,Brushes.Black,curRowX+5,curRowY+5);
							e.Graphics.DrawLine(penLine,curRowX+100,curRowY,curRowX+100,curRowY+20);
							
							if(arrReturn.Count>0)
							{
								tempX=curRowX+105;
								tempY=curRowY+5;
								int RowCount=1;
								for(int k1=0;k1<arrReturn.Count;k1++)
								{
									if(k1==0)
									{
										e.Graphics.DrawString(arrReturn[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
										tilWith=e.Graphics.MeasureString(arrReturn[k1].ToString(),TextFont);
										tempX+=tilWith.Width;
									}
									else
									{
			
										e.Graphics.DrawString(","+arrReturn[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
										tilWith=e.Graphics.MeasureString(","+arrReturn[k1].ToString(),TextFont);
										tempX+=tilWith.Width;
									}
									if(k1!=arrReturn.Count&&tempX+tilWith.Width>=PageWidth-300)
									{
										RowCount++;
										tempX=curRowX+105;
										tempY=curRowY+10*RowCount;
									}
								}
							}
							e.Graphics.DrawLine(penLine,PageWidth-350,curRowY,PageWidth-350,curRowY+20);
							e.Graphics.DrawString("恢复发票号",TextFont,Brushes.Black,PageWidth-345,curRowY+5);
							e.Graphics.DrawLine(penLine,PageWidth-250,curRowY,PageWidth-250,curRowY+20);
							
							if(arrBreck.Count>0)
							{
								tempX=PageWidth-255;
								tempY=curRowY+5;
								int RowCount=1;
								for(int k1=0;k1<arrBreck.Count;k1++)
								{
									if(k1==0)
									{
										e.Graphics.DrawString(arrBreck[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
										tilWith=e.Graphics.MeasureString(arrBreck[k1].ToString(),TextFont);
										tempX+=tilWith.Width;
									}
									else
									{
										e.Graphics.DrawString(","+arrBreck[k1].ToString(),TextFont,Brushes.Black,PageWidth-200,tempY);
										tilWith=e.Graphics.MeasureString(","+arrBreck[k1].ToString(),TextFont);
										tempX+=tilWith.Width;
									}
									if(k1!=arrBreck.Count&&tempX+tilWith.Width>=PageWidth-RightWith)
									{
										RowCount++;
										tempX=PageWidth-200;
										tempY=curRowY+10*RowCount;
									}
								}
								curRowY=tempY+5;
					
							}
							}
							catch
							{
								MessageBox.Show("2");
							}

							curRowY+=20;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 3:
							try
							{
								tmpWith=LeftWith+4;
								e.Graphics.DrawString("缴款人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
								tilWith= e.Graphics.MeasureString("缴款人：",TextFont);
								tmpWith+=tilWith.Width;
								
						
								if(this.m_objViewer.isDoctorDean==true)
								{
									e.Graphics.DrawString(this.m_objViewer.m_cboCheckMan.SelectItemText.ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
								}
								else
								{
									e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,tmpWith,curRowY+7);
								}

								tmpWith+=200;
								e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
								tmpWith+=200;
								e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,tmpWith,curRowY+7);
								curRowY+=RowHight;
								e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							}
							catch
							{
								MessageBox.Show("3");
							}
							break;
					}
				}
				e.Graphics.DrawLine(penLine,curRowX,strLine,curRowX,curRowY);
				e.Graphics.DrawLine(penLine,PageWidth-RightWith,strLine,PageWidth-RightWith,curRowY);
				#endregion
			}

		}
		#endregion

		#endregion

		public void printPage(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=0;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",14);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",10);//文字使用的字体
			const float RowHight=23F;//项的高度
			const float LeftWith=45F;//左宿进的长度
			const float RightWith=130F;//右宿进的长度
			const float Uphight=10F;//上下宿进的长度
			#endregion

			#region 头部
			Pen penLine=new Pen(Brushes.Black,1);
			curRowY=RowHight+Uphight+10;
			curRowX+=LeftWith;
			SizeF tilWith= e.Graphics.MeasureString(strName+"收费员日结报表",m_fntTitle);
			e.Graphics.DrawString(strName+"收费员日结报表",m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,Uphight);
			e.Graphics.DrawString("实收日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("实收日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(strCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString(strCheckDate,TextFont);
			curRowX+=tilWith.Width+20;
			e.Graphics.DrawString("发票日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("发票日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(StatisticsRow["第一张发票时间"].ToString()+" ~ "+StatisticsRow["最后一张发票时间"].ToString(),TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString(StatisticsRow["第一张发票时间"].ToString()+" ~ "+StatisticsRow["最后一张发票时间"].ToString(),TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,curRowX+5,curRowY);
			tilWith= e.Graphics.MeasureString("打印日期： ",TextFont);
			string NowDate=DateTime.Now.ToShortDateString();
			e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,curRowX+tilWith.Width,curRowY);
			#endregion
			curRowX=LeftWith;
			float strLine=curRowY;
			
			#region 画表格
			for(int i1=0;i1<12;i1++)
			{
				float tmpWith;//X轴
				const int with=4;
				switch(i1)
				{
					case 10:
						#region 填充收费类型数据
						if(dtPayType.Rows.Count>0)
						{
							tmpWith=LeftWith+2;
							curRowY+=10;
							for(int f2=0;f2<dtPayType.Rows.Count;f2++)
							{
								if(f2%5==0&&f2!=0)
								{
									tmpWith=LeftWith+2;
									curRowY+=RowHight+5;
								}
								tilWith= e.Graphics.MeasureString("打印日期",TextFont);
								if(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length>4)
								{
									string star=dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0,4);
									string end=dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
									e.Graphics.DrawString(star,TextFont,Brushes.Black,tmpWith,curRowY-5);
									e.Graphics.DrawString(end+"：",TextFont,Brushes.Black,tmpWith,curRowY+10);
									e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
								}
								else
								{
									e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim()+"：",TextFont,Brushes.Black,tmpWith,curRowY);
									e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
								}
								tmpWith+=146;
							}
						}
						curRowY+=RowHight;
						#endregion
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 0:
						#region 第一列
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tmpWith=LeftWith+with;
						e.Graphics.DrawString("开  票  数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["开票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//开票数
						e.Graphics.DrawString("实收金额合计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*2);//实收金额合计
						e.Graphics.DrawString("实收现金合计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//实收现金合计
						e.Graphics.DrawString("医保记账金额",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//医保记账金额
						e.Graphics.DrawString("人 次 统  计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*5);//人次统计
						e.Graphics.DrawString("发  票  号",TextFont,Brushes.Black,tmpWith,curRowY+10+RowHight*6);//发票号
						e.Graphics.DrawString("退票发票号",TextFont,Brushes.Black,tmpWith,curRowY+15+RowHight*7);//退票发票号
						e.Graphics.DrawString("恢复发票号",TextFont,Brushes.Black,tmpWith,curRowY+15+RowHight*8);//退票发票号
						tilWith= e.Graphics.MeasureString("开  票  数：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*9+10);

						#endregion
						

						#region 第二列
						tmpWith+=with;
						e.Graphics.DrawString("开 票 合 计 金 额",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("开 票 合 计 金 额:",TextFont);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["开票金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//开票金额
						float tolMoney=float.Parse(StatisticsRow["实收金额合计"].ToString());
						
						string strMoney=clsMain.CurrencyToString(Math.Abs(tolMoney));
						e.Graphics.DrawString(strMoney,m_fntTitle,Brushes.Black,tmpWith+10,curRowY+3+RowHight*2);//实收金额

						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["实收现金合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+3+RowHight*3);//实收现金合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["医保记账金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+3+RowHight*4);//实收现金合计
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);

						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);

						#endregion
						
						#region 第三列
						tmpWith+=with;
						e.Graphics.DrawString("退   票   数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["退票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//退票数
						e.Graphics.DrawString("刷卡金额合计",TextFont,Brushes.Black,tmpWith+5,curRowY+7+RowHight*3);//刷卡金额合计
						e.Graphics.DrawString("公费记帐金额",TextFont,Brushes.Black,tmpWith+5,curRowY+7+RowHight*4);//退票数
						tilWith= e.Graphics.MeasureString("退   票   数:",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);
						#endregion

						#region 第四列
						tmpWith+=with;
						e.Graphics.DrawString("退 票 金 额 合 计",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//退票金额合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//刷卡金额合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["公费记账金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//刷卡金额合计
						tilWith= e.Graphics.MeasureString("退 票 金 额 合 计",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);

						#endregion

						#region 第五列
						tmpWith+=with;
						e.Graphics.DrawString("恢复票数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["恢复票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//恢复票数
						e.Graphics.DrawString("支 票 金 额 合 计",TextFont,Brushes.Black,tmpWith+10,curRowY+7+RowHight*3);//支票金额合计
						tilWith= e.Graphics.MeasureString("恢复票数",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						#endregion


						#region 第六列

						tmpWith+=with;
						e.Graphics.DrawString("恢复金额合计",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//恢复金额合计
						tilWith= e.Graphics.MeasureString("恢复金额合计",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*4);

						tmpWith+=with;
						e.Graphics.DrawString("有  效  票  数",TextFont,Brushes.Black,tmpWith,curRowY+7);
		
						e.Graphics.DrawString(StatisticsRow["有效票数"].ToString()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//有效票数
						e.Graphics.DrawString("￥"+Convert.ToDouble(tolMoney.ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*2);//有效金额
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["支票金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//支票金额合计
						#endregion

						break;
					case 1:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 9:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 2:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 3:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 4:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 5:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						e.Graphics.DrawString("医保人次：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("医保人次：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(StatisticsRow["医保人次"].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);

						tmpWith+=50;
						e.Graphics.DrawString("公费人次：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("公费人次：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(StatisticsRow["公费人次"].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
						tmpWith+=50;
						e.Graphics.DrawString("自费及其它人次：",TextFont,Brushes.Black,tmpWith,curRowY+7);

						tilWith= e.Graphics.MeasureString("自费及其它人次：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(StatisticsRow["自费人次"].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
						break;
					case 6:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);

						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(arrList.Count>0)
						{
							float temY=0;
							float newWith=tmpWith;
							float temcurRowY=curRowY;
							int intRow=0;
							int tolRow=0;
							for(int f2=0;f2<arrList.Count;f2++)
							{
								if(arrList[f2].ToString()==",")
									tolRow++;
							}
							if(tolRow>=3)
							{
								temY=3;
							}
							else
							{
								temY=10;
							}
								e.Graphics.DrawString(arrList[0].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
							int intCount=0;
							for(int j2=0;j2<arrList.Count;j2++)
							{
								
								if(intRow==3&&intCount==0)
								{
									intCount++;
									temcurRowY=temY+10+temcurRowY;
									tmpWith=newWith-90;
								}
								if(arrList[j2].ToString()==",")
								{
									intRow++;
									tilWith=e.Graphics.MeasureString("- "+arrList[j2-1].ToString(),TextFont);
									tmpWith+=tilWith.Width;
									e.Graphics.DrawString("- "+arrList[j2-1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
									if(j2!=arrList.Count-1)
									{
										tilWith= e.Graphics.MeasureString("- "+arrList[j2-1].ToString(),TextFont);
										tmpWith+=tilWith.Width;
										e.Graphics.DrawString(","+arrList[j2+1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
									}	
								}
							}
							tilWith=e.Graphics.MeasureString("- "+arrList[0].ToString(),TextFont);
							tmpWith+=tilWith.Width;
							e.Graphics.DrawString("- "+arrList[arrList.Count-1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
						}
						break;
					case 7:
						curRowY+=RowHight+10;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(SaveINVOICENO.Count>0)
						{
								for(int k2=0;k2<SaveINVOICENO.Count;k2++)
								{
										e.Graphics.DrawString(SaveINVOICENO[k2].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
										tilWith= e.Graphics.MeasureString(SaveINVOICENO[k2].ToString()+",",TextFont);
										tmpWith+=tilWith.Width;

								}

						}

						break;
					case 8:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(arrReList.Count>0)
						{
							for(int k2=0;k2<arrReList.Count;k2++)
							{
								e.Graphics.DrawString(arrReList[k2].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
								tilWith= e.Graphics.MeasureString(arrReList[k2].ToString()+",",TextFont);
								tmpWith+=tilWith.Width;
							}

						}
						break;
					case 11:
       
						tmpWith=LeftWith+4;
						e.Graphics.DrawString("缴款人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("缴款人：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,tmpWith,curRowY+7);
						
					
						tmpWith+=200;
						e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tmpWith+=200;
						e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);

						
						break;
					case 12:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
				}
			}
			e.Graphics.DrawLine(penLine,curRowX,strLine+RowHight,curRowX,curRowY);
			e.Graphics.DrawLine(penLine,PageWidth-RightWith,strLine+RowHight,PageWidth-RightWith,curRowY);
			#endregion

		}


		public void printPageMB(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=0;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",14);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",10);//文字使用的字体
			const float RowHight=23F;//项的高度
			const float LeftWith=45F;//左宿进的长度
			const float RightWith=130F;//右宿进的长度
			const float Uphight=10F;//上下宿进的长度
			#endregion

			#region 头部
			Pen penLine=new Pen(Brushes.Black,1);
			curRowY=RowHight+Uphight+10;
			curRowX+=LeftWith;
			SizeF tilWith= e.Graphics.MeasureString(strName+"收费员日结报表",m_fntTitle);
			e.Graphics.DrawString(strName+"收费员日结报表",m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,Uphight);
			e.Graphics.DrawString("实收日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("实收日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(strCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString(strCheckDate,TextFont);
			curRowX+=tilWith.Width+20;
			e.Graphics.DrawString("发票日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("发票日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(StatisticsRow["第一张发票时间"].ToString()+" ~ "+StatisticsRow["最后一张发票时间"].ToString(),TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString(StatisticsRow["第一张发票时间"].ToString()+" ~ "+StatisticsRow["最后一张发票时间"].ToString(),TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,curRowX+5,curRowY);
			tilWith= e.Graphics.MeasureString("打印日期： ",TextFont);
			string NowDate=DateTime.Now.ToShortDateString();
			e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,curRowX+tilWith.Width,curRowY);
			#endregion
			curRowX=LeftWith;
			float strLine=curRowY;
			
			#region 画表格
			for(int i1=0;i1<12;i1++)
			{
				float tmpWith;//X轴
				const int with=4;
				switch(i1)
				{
					case 10:
						#region 填充收费类型数据
						if(dtPayType.Rows.Count>0)
						{
							tmpWith=LeftWith+2;
							curRowY+=10;
							for(int f2=0;f2<dtPayType.Rows.Count;f2++)
							{
								if(f2%5==0&&f2!=0)
								{
									tmpWith=LeftWith+2;
									curRowY+=RowHight+5;
								}
								tilWith= e.Graphics.MeasureString("打印日期",TextFont);
								if(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length>4)
								{
									string star=dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0,4);
									string end=dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
									e.Graphics.DrawString(star,TextFont,Brushes.Black,tmpWith,curRowY-5);
									e.Graphics.DrawString(end+"：",TextFont,Brushes.Black,tmpWith,curRowY+10);
									e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
								}
								else
								{
									e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim()+"：",TextFont,Brushes.Black,tmpWith,curRowY);
									e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
								}
								tmpWith+=146;
							}
						}
						curRowY+=RowHight;
						#endregion
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 0:
						#region 第一列
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tmpWith=LeftWith+with;
						e.Graphics.DrawString("开  票  数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["开票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//开票数
						e.Graphics.DrawString("实收金额合计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*2);//实收金额合计
						e.Graphics.DrawString("实收现金合计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//实收现金合计
						e.Graphics.DrawString("医保记账金额",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//医保记账金额
						e.Graphics.DrawString("人 次 统  计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*5);//人次统计
						e.Graphics.DrawString("发  票  号",TextFont,Brushes.Black,tmpWith,curRowY+10+RowHight*6);//发票号
						e.Graphics.DrawString("退票发票号",TextFont,Brushes.Black,tmpWith,curRowY+15+RowHight*7);//退票发票号
						e.Graphics.DrawString("恢复发票号",TextFont,Brushes.Black,tmpWith,curRowY+15+RowHight*8);//退票发票号
						tilWith= e.Graphics.MeasureString("开  票  数：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*9+10);

						#endregion
						

						#region 第二列
						tmpWith+=with;
						e.Graphics.DrawString("开 票 合 计 金 额",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("开 票 合 计 金 额:",TextFont);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["开票金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//开票金额
						float tolMoney=float.Parse(StatisticsRow["实收金额合计"].ToString());
						string strMoney=clsMain.CurrencyToString(Math.Abs(tolMoney));
						e.Graphics.DrawString(strMoney,m_fntTitle,Brushes.Black,tmpWith+10,curRowY+3+RowHight*2);//实收金额

						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["实收现金合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+3+RowHight*3);//实收现金合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["医保记账金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+3+RowHight*4);//实收现金合计
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);

						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);

						#endregion
						
						#region 第三列
						tmpWith+=with;
						e.Graphics.DrawString("退   票   数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["退票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//退票数
						e.Graphics.DrawString("刷卡金额合计",TextFont,Brushes.Black,tmpWith+5,curRowY+7+RowHight*3);//刷卡金额合计
						e.Graphics.DrawString("公费记帐金额",TextFont,Brushes.Black,tmpWith+5,curRowY+7+RowHight*4);//公费记帐金额
						
						tilWith= e.Graphics.MeasureString("退   票   数:",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);
						#endregion

						#region 第四列
						tmpWith+=with;
						e.Graphics.DrawString("退 票 金 额 合 计",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["退票金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//退票金额合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//刷卡金额合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["公费记账金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//刷卡金额合计
						tilWith= e.Graphics.MeasureString("退 票 金 额 合 计",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);

						#endregion

						#region 第五列
						tmpWith+=with;
						e.Graphics.DrawString("恢复票数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["恢复票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//恢复票数
						e.Graphics.DrawString("支 票 金 额 合 计",TextFont,Brushes.Black,tmpWith+10,curRowY+7+RowHight*3);//支票金额合计
						e.Graphics.DrawString("其 它 记 帐 金 额",TextFont,Brushes.Black,tmpWith+10,curRowY+7+RowHight*4);//其它记帐金额
						tilWith= e.Graphics.MeasureString("恢复票数",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						#endregion


						#region 第六列

						tmpWith+=with;
						e.Graphics.DrawString("恢复金额合计",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//恢复金额合计
						tilWith= e.Graphics.MeasureString("恢复金额合计",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*5);

						tmpWith+=with;
						e.Graphics.DrawString("有  效  票  数",TextFont,Brushes.Black,tmpWith,curRowY+7);
		
						e.Graphics.DrawString(StatisticsRow["有效票数"].ToString()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//有效票数
						e.Graphics.DrawString("￥"+Convert.ToDouble(tolMoney.ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*2);//有效金额
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["支票金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//支票金额合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//支票金额合计
						#endregion

						break;
					case 1:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 9:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 2:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 3:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 4:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 5:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						e.Graphics.DrawString("医保人次：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("医保人次：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(StatisticsRow["医保人次"].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);

						tmpWith+=50;
						e.Graphics.DrawString("公费人次：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("公费人次：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(StatisticsRow["公费人次"].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
						tmpWith+=50;
						e.Graphics.DrawString("自费及其它人次：",TextFont,Brushes.Black,tmpWith,curRowY+7);

						tilWith= e.Graphics.MeasureString("自费及其它人次：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(StatisticsRow["自费人次"].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
						break;
					case 6:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);

						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(arrList.Count>0)
						{
							float temY=0;
							
							float newWith=tmpWith;
							float temcurRowY=curRowY;
							int intRow=0;
							int tolRow=0;
							for(int f2=0;f2<arrList.Count;f2++)
							{
								if(arrList[f2].ToString()==",")
									tolRow++;
							}
							if(tolRow>=3)
							{
								temY=3;
							}
							else
							{
								temY=10;
							}
							e.Graphics.DrawString(arrList[0].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
							int intCount=0;
							for(int j2=0;j2<arrList.Count;j2++)
							{
								
								if(intRow==3&&intCount==0)
								{
									intCount++;
									temcurRowY=temY+10+temcurRowY;
									tmpWith=newWith-90;
								}
								if(arrList[j2].ToString()==",")
								{
									intRow++;
									tilWith=e.Graphics.MeasureString("- "+arrList[j2-1].ToString(),TextFont);
									tmpWith+=tilWith.Width;
									e.Graphics.DrawString("- "+arrList[j2-1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
									if(j2!=arrList.Count-1)
									{
										tilWith= e.Graphics.MeasureString("- "+arrList[j2-1].ToString(),TextFont);
										tmpWith+=tilWith.Width;
										e.Graphics.DrawString(","+arrList[j2+1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
									}	
								}
							}
							tilWith=e.Graphics.MeasureString("- "+arrList[0].ToString(),TextFont);
							tmpWith+=tilWith.Width;
							e.Graphics.DrawString("- "+arrList[arrList.Count-1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
						}
						break;
					case 7:
						curRowY+=RowHight+10;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(SaveINVOICENO.Count>0)
						{
							for(int k2=0;k2<SaveINVOICENO.Count;k2++)
							{
								e.Graphics.DrawString(SaveINVOICENO[k2].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
								tilWith= e.Graphics.MeasureString(SaveINVOICENO[k2].ToString()+",",TextFont);
								tmpWith+=tilWith.Width;

							}

						}

						break;
					case 8:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复  票  数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(arrReList.Count>0)
						{
							for(int k2=0;k2<arrReList.Count;k2++)
							{
								e.Graphics.DrawString(arrReList[k2].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
								tilWith= e.Graphics.MeasureString(arrReList[k2].ToString()+",",TextFont);
								tmpWith+=tilWith.Width;
		
							}

						}
						break;
					case 11:
       
						tmpWith=LeftWith+4;
						e.Graphics.DrawString("缴款人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("缴款人：",TextFont);
						tmpWith+=tilWith.Width;
						
						if(this.m_objViewer.isDoctorDean==true)
						{
							e.Graphics.DrawString(this.m_objViewer.m_cboCheckMan.SelectItemText.ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
						}
						else
						{
							e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,tmpWith,curRowY+7);
						}
					
						tmpWith+=200;
						e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tmpWith+=200;
						e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);

						
						break;
					case 12:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
				}
			}
			e.Graphics.DrawLine(penLine,curRowX,strLine+RowHight,curRowX,curRowY);
			e.Graphics.DrawLine(penLine,PageWidth-RightWith,strLine+RowHight,PageWidth-RightWith,curRowY);
			#endregion

		}


		public void printPageFS(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=0;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",14);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",10);//文字使用的字体
			const float RowHight=23F;//项的高度
			const float LeftWith=45F;//左宿进的长度
			const float RightWith=130F;//右宿进的长度
			const float Uphight=10F;//上下宿进的长度
			#endregion

			#region 头部
			Pen penLine=new Pen(Brushes.Black,1);
			curRowY=RowHight+Uphight+10;
			curRowX+=LeftWith;
			SizeF tilWith= e.Graphics.MeasureString(strName+"收费员日结报表",m_fntTitle);
			e.Graphics.DrawString(strName+"收费员日结报表",m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,Uphight);
			e.Graphics.DrawString("实收日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("实收日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(strCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString(strCheckDate,TextFont);
			curRowX+=tilWith.Width+20;
			e.Graphics.DrawString("发票日期：",TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString("发票日期：",TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString(StatisticsRow["第一张发票时间"].ToString()+" ~ "+StatisticsRow["最后一张发票时间"].ToString(),TextFont,Brushes.Black,curRowX,curRowY);
			tilWith= e.Graphics.MeasureString(StatisticsRow["第一张发票时间"].ToString()+" ~ "+StatisticsRow["最后一张发票时间"].ToString(),TextFont);
			curRowX+=tilWith.Width;
			e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,curRowX+5,curRowY);
			tilWith= e.Graphics.MeasureString("打印日期： ",TextFont);
			string NowDate=DateTime.Now.ToShortDateString();
			e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,curRowX+tilWith.Width,curRowY);
			#endregion
			curRowX=LeftWith;
			float strLine=curRowY;
			
			#region 画表格
			for(int i1=0;i1<12;i1++)
			{
				float tmpWith;//X轴
				const int with=4;
				switch(i1)
				{
					case 10:
                        if (this.m_objViewer.m_blnSimple == false)
                        {
                            #region 填充收费类型数据
                            if (dtPayType.Rows.Count > 0)
                            {
                                tmpWith = LeftWith + 2;
                                curRowY += 10;
                                for (int f2 = 0; f2 < dtPayType.Rows.Count; f2++)
                                {
                                    if (f2 % 5 == 0 && f2 != 0)
                                    {
                                        tmpWith = LeftWith + 2;
                                        curRowY += RowHight + 5;
                                    }
                                    tilWith = e.Graphics.MeasureString("打印日期", TextFont);
                                    if (dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length > 4)
                                    {
                                        string star = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0, 4);
                                        string end = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
                                        e.Graphics.DrawString(star, TextFont, Brushes.Black, tmpWith, curRowY - 5);
                                        e.Graphics.DrawString(end + "：", TextFont, Brushes.Black, tmpWith, curRowY + 10);
                                        if (dtPayType.Rows[f2]["tolMoney"].ToString() != "0.00")
                                            e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                                    }
                                    else
                                    {
                                        e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim() + "：", TextFont, Brushes.Black, tmpWith, curRowY);
                                        if (dtPayType.Rows[f2]["tolMoney"].ToString() != "0.00")
                                            e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                                    }
                                    tmpWith += 146;
                                }
                            }
                            curRowY += RowHight;
                            #endregion
                            e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        }
						break;
					case 0:
						#region 第一列
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tmpWith=LeftWith+with;
						e.Graphics.DrawString("开 票 数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["开票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//开票数
						e.Graphics.DrawString("实收合计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*2);//实收金额合计
						e.Graphics.DrawString("现金支付",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//实收现金合计
						e.Graphics.DrawString("公费记账",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//医保记账金额
//						e.Graphics.DrawString("人 次 统  计",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*5);//人次统计
						e.Graphics.DrawString("发 票 号",TextFont,Brushes.Black,tmpWith,curRowY+10+RowHight*5);//发票号
						e.Graphics.DrawString("退票发票",TextFont,Brushes.Black,tmpWith,curRowY+15+RowHight*6);//退票发票号
						e.Graphics.DrawString("恢复发票",TextFont,Brushes.Black,tmpWith,curRowY+15+RowHight*7);//退票发票号
						tilWith= e.Graphics.MeasureString("开 票 数",TextFont);

                        e.Graphics.DrawString("重打发票", TextFont, Brushes.Black, tmpWith, curRowY + 20 + RowHight * 8);//重打发票发票号
                        e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 9 + 20, PageWidth - RightWith, curRowY + RowHight * 9 + 20);

                        #region 重打发票号数组
                     //   m_strInvoArr = new string[] { "DW9038844", "DW9038844", "DW9038844", "DW9038844", "DW9038844", "DW9038844", "DW9038844" };
                        string strInvoPrintstrUp = "";
                        string strInvoPrintstrDown = "";
                        SizeF sizeFtemp;
                        float fltWith = PageWidth - RightWith - 100;// RightWith - curRowX - tmpWith - tilWith.Width - 10;
                        if (m_strInvoArr != null)
                        {
                            for (int j = 0; j < m_strInvoArr.Length; j++)
                            {
                                sizeFtemp = e.Graphics.MeasureString(strInvoPrintstrUp + m_strInvoArr[j].Trim() + " ", TextFont);
                                if (fltWith > sizeFtemp.Width)
                                {
                                    strInvoPrintstrUp += m_strInvoArr[j].Trim()+" ";
                                }
                                else
                                {
                                    strInvoPrintstrDown += m_strInvoArr[j].Trim()+" ";
                                }
                            }
                            if (strInvoPrintstrDown != "")
                            {
                                e.Graphics.DrawString(strInvoPrintstrUp + strInvoPrintstrDown, TextFont, Brushes.Black, new RectangleF(tmpWith + tilWith.Width + 10, curRowY + 12 + RowHight * 8, PageWidth - RightWith - 100, curRowY + 12 + RowHight * 8));
                            }
                            else
                            {
                                e.Graphics.DrawString(strInvoPrintstrUp + strInvoPrintstrDown, TextFont, Brushes.Black, new RectangleF(tmpWith + tilWith.Width + 10, curRowY + 20 + RowHight * 8, PageWidth - RightWith - 100, curRowY + 20 + RowHight * 8));
                            }
                        }
                        #endregion 

                        tmpWith +=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*9+20);

						#endregion
						

						#region 第二列
						tmpWith+=with;
						e.Graphics.DrawString("开 票 合 计 金 额",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("开 票 合 计 金 额",TextFont);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["开票金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//开票金额
						float tolMoney=float.Parse(StatisticsRow["实收金额合计"].ToString());
						string strMoney=clsMain.CurrencyToString(Math.Abs(tolMoney));
						e.Graphics.DrawString(strMoney,m_fntTitle,Brushes.Black,tmpWith+2,curRowY+3+RowHight*2);//实收金额

						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["实收现金合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//实收现金合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["公费记账金额"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//公费记账金额
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);

						e.Graphics.DrawLine(penLine,tmpWith-50,curRowY+RowHight*3,tmpWith-50,curRowY+RowHight*5);
						e.Graphics.DrawString("IC 卡",TextFont,Brushes.Black,tmpWith-50,curRowY+7+RowHight*3);
						e.Graphics.DrawString("特 困",TextFont,Brushes.Black,tmpWith-50,curRowY+7+RowHight*4);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);

						#endregion
						
						#region 第三列
						tmpWith+=with;
						e.Graphics.DrawString("退  票  数",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["退票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//退票数
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//IC卡金额合计
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["特困记帐"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//特困记帐金额
						
						tilWith= e.Graphics.MeasureString("退  票  数",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);
						#endregion

						#region 第四列
						tmpWith+=with;
						e.Graphics.DrawString("  退 票 金 额 合 计",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString("￥"+"-"+Math.Abs(Convert.ToDouble(StatisticsRow["退票金额合计"].ToString())).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//退票金额合计
//						
						e.Graphics.DrawString("银行卡",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);
						e.Graphics.DrawString("离  休",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);

						tilWith= e.Graphics.MeasureString("银行卡",TextFont);
						e.Graphics.DrawLine(penLine,tmpWith+tilWith.Width,curRowY+RowHight*3,tmpWith+tilWith.Width,curRowY+RowHight*5);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY+7+RowHight*3);//刷卡金额合计


						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["离休记帐"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY+7+RowHight*4);//特困记帐

						tilWith= e.Graphics.MeasureString(" 退  票  金  额  合  计",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);
						e.Graphics.DrawLine(penLine,tmpWith-30,curRowY+RowHight*3,tmpWith-30,curRowY+RowHight*5);
						e.Graphics.DrawString("支票",TextFont,Brushes.Black,tmpWith-30,curRowY+7+RowHight*3);
						e.Graphics.DrawString("本院",TextFont,Brushes.Black,tmpWith-30,curRowY+7+RowHight*4);
						#endregion

						#region 第五列
						tmpWith+=with;
						e.Graphics.DrawString(" 恢复票数 ",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString(StatisticsRow["恢复票数"].ToString().Trim()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//恢复票数

						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["支票金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);//支票金额合计

							e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["本院记帐"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);//本院记帐
						tilWith= e.Graphics.MeasureString("恢 复 票数",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*2);
						e.Graphics.DrawLine(penLine,tmpWith,curRowY+RowHight*3,tmpWith,curRowY+RowHight*5);
						#endregion


						#region 第六列

						tmpWith+=with;
						e.Graphics.DrawString("恢复金额合计",TextFont,Brushes.Black,tmpWith,curRowY+7);
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//恢复金额合计
                        //佛二：其它支付－>其它记帐
                        if(this.m_objViewer.m_blnSimple==false)
                        e.Graphics.DrawString("其它记帐", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);
                        else
                        e.Graphics.DrawString("折扣比例", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);
                        //e.Graphics.DrawString("其 它 支 付",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);                      
						e.Graphics.DrawString("特定医保记帐",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*4);
						tilWith= e.Graphics.MeasureString("恢复金额合计",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawLine(penLine,tmpWith,curRowY,tmpWith,curRowY+RowHight*5);
						tmpWith+=with;
						e.Graphics.DrawString(" 有 效 票 数",TextFont,Brushes.Black,tmpWith,curRowY+7);
		
						e.Graphics.DrawString(StatisticsRow["有效票数"].ToString()+"张",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight);//有效票数
						e.Graphics.DrawString("￥"+Convert.ToDouble(tolMoney.ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*2);//有效金额
						e.Graphics.DrawString("￥"+Convert.ToDouble(StatisticsRow["其它金额合计"].ToString()).ToString("0.00"),TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);

                        ////佛二将医保费打印到其他记帐
                        //double hj = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString()) + Convert.ToDouble(StatisticsRow["医保记账金额"].ToString());
                        //佛二将其它记帐改为特定医保记帐
                        double hj = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString());
                        e.Graphics.DrawString("￥" + hj.ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//其它记帐金额
                         
                        #endregion

                       
						break;
					case 1:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 9:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
                        curRowY += RowHight+15;

						break;
					case 2:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 3:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 4:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
					case 6:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);

						tilWith= e.Graphics.MeasureString("恢  复票数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(arrList.Count>0)
						{
							float temY=0;
							
							float newWith=tmpWith;
							float temcurRowY=curRowY;
							int intRow=0;
							int tolRow=0;
							for(int f2=0;f2<arrList.Count;f2++)
							{
								if(arrList[f2].ToString()==",")
									tolRow++;
							}
							if(tolRow>=3)
							{
								temY=3;
							}
							else
							{
								temY=10;
							}
							e.Graphics.DrawString(arrList[0].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
							int intCount=0;
							for(int j2=0;j2<arrList.Count;j2++)
							{
								
								if(intRow==3&&intCount==0)
								{
									intCount++;
									temcurRowY=temY+10+temcurRowY;
									tmpWith=newWith-90;
								}
								if(arrList[j2].ToString()==",")
								{
									intRow++;
									tilWith=e.Graphics.MeasureString("- "+arrList[j2-1].ToString(),TextFont);
									tmpWith+=tilWith.Width;
									e.Graphics.DrawString("- "+arrList[j2-1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
									if(j2!=arrList.Count-1)
									{
										tilWith= e.Graphics.MeasureString("- "+arrList[j2-1].ToString(),TextFont);
										tmpWith+=tilWith.Width;
										e.Graphics.DrawString(","+arrList[j2+1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
									}	
								}
							}
							tilWith=e.Graphics.MeasureString("- "+arrList[0].ToString(),TextFont);
							tmpWith+=tilWith.Width;
							e.Graphics.DrawString("- "+arrList[arrList.Count-1].ToString(),TextFont,Brushes.Black,tmpWith,temcurRowY+temY);
						}

						break;
					case 7:
						curRowY+=RowHight+10;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢  复票数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(SaveINVOICENO.Count>0)
						{
							for(int k2=0;k2<SaveINVOICENO.Count;k2++)
							{
								e.Graphics.DrawString(SaveINVOICENO[k2].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
								tilWith= e.Graphics.MeasureString(SaveINVOICENO[k2].ToString()+",",TextFont);
								tmpWith+=tilWith.Width;
							}
						}

						break;
					case 8:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						tilWith= e.Graphics.MeasureString("恢 复 票数",TextFont);
						tmpWith=LeftWith+tilWith.Width;
						if(arrReList.Count>0)
						{
							for(int k2=0;k2<arrReList.Count;k2++)
							{
								e.Graphics.DrawString(arrReList[k2].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+7);
								tilWith= e.Graphics.MeasureString(arrReList[k2].ToString()+",",TextFont);
								tmpWith+=tilWith.Width;
							}
						}

						break;
					case 11:
						tmpWith=LeftWith+4;
						e.Graphics.DrawString("缴款人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tilWith= e.Graphics.MeasureString("缴款人：",TextFont);
						tmpWith+=tilWith.Width;
						e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,tmpWith,curRowY+7);
						tmpWith+=200;
						e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						tmpWith+=200;
						e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,tmpWith,curRowY+7);
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);

						
						break;
					case 12:
						curRowY+=RowHight;
						e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
						break;
				}
			}
			e.Graphics.DrawLine(penLine,curRowX,strLine+RowHight,curRowX,curRowY);
			e.Graphics.DrawLine(penLine,PageWidth-RightWith,strLine+RowHight,PageWidth-RightWith,curRowY);
			#endregion

		}
        public void printPageLJ(System.Drawing.Printing.PrintPageEventArgs e)
        {
            #region 变量
            float PageWidth = e.PageBounds.Width;//获得页面的宽度
            float PageHight = e.PageBounds.Height;//获得页面的高度
            float curRowY = 0;//当前行的Y坐标
            float curRowX = 0;//当前行的X坐标
            System.Drawing.Font m_fntTitle = new Font("宋体", 14);//标题使用的字体
            System.Drawing.Font TextFont = new Font("宋体", 10);//文字使用的字体
            const float RowHight = 23F;//项的高度
            const float LeftWith = 45F;//左宿进的长度
            const float RightWith = 130F;//右宿进的长度
            const float Uphight = 10F;//上下宿进的长度
            #endregion

            #region 头部
            Pen penLine = new Pen(Brushes.Black, 1);
            curRowY = RowHight + Uphight + 10;
            curRowX += LeftWith;
            SizeF tilWith = e.Graphics.MeasureString(strName + "收费员日结报表", m_fntTitle);
            e.Graphics.DrawString(strName + "收费员日结报表", m_fntTitle, Brushes.Black, (PageWidth - tilWith.Width) / 2, Uphight);
            e.Graphics.DrawString("实收日期：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("实收日期：", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(strCheckDate, TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString(strCheckDate, TextFont);
            curRowX += tilWith.Width + 20;
            e.Graphics.DrawString("发票日期：", TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString("发票日期：", TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString(StatisticsRow["第一张发票时间"].ToString() + " ~ " + StatisticsRow["最后一张发票时间"].ToString(), TextFont, Brushes.Black, curRowX, curRowY);
            tilWith = e.Graphics.MeasureString(StatisticsRow["第一张发票时间"].ToString() + " ~ " + StatisticsRow["最后一张发票时间"].ToString(), TextFont);
            curRowX += tilWith.Width;
            e.Graphics.DrawString("打印日期：", TextFont, Brushes.Black, curRowX + 5, curRowY);
            tilWith = e.Graphics.MeasureString("打印日期： ", TextFont);
            string NowDate = DateTime.Now.ToShortDateString();
            e.Graphics.DrawString(NowDate, TextFont, Brushes.Black, curRowX + tilWith.Width, curRowY);
            #endregion
            curRowX = LeftWith;
            float strLine = curRowY;

            #region 画表格
            for (int i1 = 0; i1 < 12; i1++)
            {
                float tmpWith;//X轴
                const int with = 4;
                switch (i1)
                {
                    case 10:
                        #region 填充收费类型数据
                        if (dtPayType.Rows.Count > 0)
                        {
                            tmpWith = LeftWith + 2;
                            curRowY += 10;
                            for (int f2 = 0; f2 < dtPayType.Rows.Count; f2++)
                            {
                                if (f2 % 5 == 0 && f2 != 0)
                                {
                                    tmpWith = LeftWith + 2;
                                    curRowY += RowHight + 5;
                                }
                                tilWith = e.Graphics.MeasureString("打印日期", TextFont);
                                if (dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length > 4)
                                {
                                    string star = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0, 4);
                                    string end = dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
                                    e.Graphics.DrawString(star, TextFont, Brushes.Black, tmpWith, curRowY - 5);
                                    e.Graphics.DrawString(end + "：", TextFont, Brushes.Black, tmpWith, curRowY + 10);
                                    if (dtPayType.Rows[f2]["tolMoney"].ToString() != "0.00")
                                        e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                                }
                                else
                                {
                                    e.Graphics.DrawString(dtPayType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim() + "：", TextFont, Brushes.Black, tmpWith, curRowY);
                                    if (dtPayType.Rows[f2]["tolMoney"].ToString() != "0.00")
                                        e.Graphics.DrawString(dtPayType.Rows[f2]["tolMoney"].ToString() + "元", TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY);
                                }
                                tmpWith += 146;
                            }
                        }
                        curRowY += RowHight;
                        #endregion
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 0:
                        #region 第一列
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        tmpWith = LeftWith + with;
                        e.Graphics.DrawString("开 票 数", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString(StatisticsRow["开票数"].ToString().Trim() + "张", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//开票数
                        e.Graphics.DrawString("实收合计", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 2);//实收金额合计
                        e.Graphics.DrawString("现金支付", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//实收现金合计
                        e.Graphics.DrawString("公费记账", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//医保记账金额
                        e.Graphics.DrawString("合作记帐", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 5);//医保记账金额
                        e.Graphics.DrawString("发 票 号", TextFont, Brushes.Black, tmpWith, curRowY + 13 + RowHight * 6);//发票号
                        e.Graphics.DrawString("退票发票", TextFont, Brushes.Black, tmpWith, curRowY + 15 + RowHight * 7);//退票发票号
                        e.Graphics.DrawString("恢复发票", TextFont, Brushes.Black, tmpWith, curRowY + 15 + RowHight * 8);//退票发票号
                        tilWith = e.Graphics.MeasureString("开 票 数", TextFont);
                        e.Graphics.DrawLine(penLine, curRowX, curRowY + 15 + RowHight * 8+17, PageWidth - RightWith, curRowY + 15 + RowHight * 8+17);
                        e.Graphics.DrawString("重打发票", TextFont, Brushes.Black, tmpWith, curRowY + 15 + RowHight * 9);//重打发票发票号
                        e.Graphics.DrawLine(penLine, curRowX, curRowY + RowHight * 10 + 10, PageWidth - RightWith, curRowY + RowHight * 10+ 10);

                        #region 重打发票号数组
                        //   m_strInvoArr = new string[] { "DW9038844", "DW9038844", "DW9038844", "DW9038844", "DW9038844", "DW9038844", "DW9038844" };
                        string strInvoPrintstrUp = "";
                        string strInvoPrintstrDown = "";
                        SizeF sizeFtemp;
                        float fltWith = PageWidth - RightWith - 100;// RightWith - curRowX - tmpWith - tilWith.Width - 10;
                        if (m_strInvoArr != null)
                        {
                            for (int j = 0; j < m_strInvoArr.Length; j++)
                            {
                                sizeFtemp = e.Graphics.MeasureString(strInvoPrintstrUp + m_strInvoArr[j].Trim() + " ", TextFont);
                                if (fltWith > sizeFtemp.Width)
                                {
                                    strInvoPrintstrUp += m_strInvoArr[j].Trim() + " ";
                                }
                                else
                                {
                                    strInvoPrintstrDown += m_strInvoArr[j].Trim() + " ";
                                }
                            }
                            if (strInvoPrintstrDown != "")
                            {
                                e.Graphics.DrawString(strInvoPrintstrUp + strInvoPrintstrDown, TextFont, Brushes.Black, new RectangleF(tmpWith + tilWith.Width + 10, curRowY + 10 + RowHight * 9, PageWidth - RightWith - 100, curRowY + 10 + RowHight * 9));
                            }
                            else
                            {
                                e.Graphics.DrawString(strInvoPrintstrUp + strInvoPrintstrDown, TextFont, Brushes.Black, new RectangleF(tmpWith + tilWith.Width + 10, curRowY + 15 + RowHight * 9, PageWidth - RightWith - 100, curRowY + 15 + RowHight * 9));
                            }
                        }
                        #endregion

                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 10 + 10);

                        #endregion


                        #region 第二列
                        tmpWith += with;
                        e.Graphics.DrawString("开 票 合 计 金 额", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        tilWith = e.Graphics.MeasureString("开 票 合 计 金 额", TextFont);
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["开票金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//开票金额
                        float tolMoney = float.Parse(StatisticsRow["实收金额合计"].ToString());
                        string strMoney = clsMain.CurrencyToString(Math.Abs(tolMoney));
                        e.Graphics.DrawString(strMoney, m_fntTitle, Brushes.Black, tmpWith + 2, curRowY + 3 + RowHight * 2);//实收金额

                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["实收现金合计"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//实收现金合计
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["公费记账金额"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//公费记账金额
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["门诊合作医疗记帐"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 5);//门诊合作医疗记帐
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);

                        e.Graphics.DrawLine(penLine, tmpWith - 50, curRowY + RowHight * 3, tmpWith - 50, curRowY + RowHight * 5);
                        e.Graphics.DrawString("IC 卡", TextFont, Brushes.Black, tmpWith - 50, curRowY + 7 + RowHight * 3);
                        e.Graphics.DrawString("特 困", TextFont, Brushes.Black, tmpWith - 50, curRowY + 7 + RowHight * 4);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);

                        #endregion

                        #region 第三列
                        tmpWith += with;
                        e.Graphics.DrawString("退  票  数", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString(StatisticsRow["退票数"].ToString().Trim() + "张", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//退票数
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["IC卡金额合计"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//IC卡金额合计
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["特困记帐"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//特困记帐金额

                        tilWith = e.Graphics.MeasureString("退  票  数", TextFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);
                        #endregion

                        #region 第四列
                        tmpWith += with;
                        e.Graphics.DrawString("  退 票 金 额 合 计", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString("￥" + "-" + Math.Abs(Convert.ToDouble(StatisticsRow["退票金额合计"].ToString())).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//退票金额合计
                        //						
                        e.Graphics.DrawString("银行卡", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);
                        e.Graphics.DrawString("离  休", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);

                        tilWith = e.Graphics.MeasureString("银行卡", TextFont);
                        e.Graphics.DrawLine(penLine, tmpWith + tilWith.Width, curRowY + RowHight * 3, tmpWith + tilWith.Width, curRowY + RowHight * 5);
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY + 7 + RowHight * 3);//刷卡金额合计


                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["离休记帐"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith + tilWith.Width, curRowY + 7 + RowHight * 4);//特困记帐

                        tilWith = e.Graphics.MeasureString(" 退  票  金  额  合  计", TextFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);
                        e.Graphics.DrawLine(penLine, tmpWith - 30, curRowY + RowHight * 3, tmpWith - 30, curRowY + RowHight * 5);
                        e.Graphics.DrawString("支票", TextFont, Brushes.Black, tmpWith - 30, curRowY + 7 + RowHight * 3);
                        e.Graphics.DrawString("本院", TextFont, Brushes.Black, tmpWith - 30, curRowY + 7 + RowHight * 4);
                        #endregion

                        #region 第五列
                        tmpWith += with;
                        e.Graphics.DrawString(" 恢复票数 ", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString(StatisticsRow["恢复票数"].ToString().Trim() + "张", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//恢复票数

                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["支票金额合计"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);//支票金额合计

                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["本院记帐"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//本院记帐
                        tilWith = e.Graphics.MeasureString("恢 复 票数", TextFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 2);
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY + RowHight * 3, tmpWith, curRowY + RowHight * 5);
                        #endregion


                        #region 第六列

                        tmpWith += with;
                        e.Graphics.DrawString("恢复金额合计", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//恢复金额合计
                        //佛二：其它支付－>其它记帐
                        e.Graphics.DrawString("其它记帐", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);
                        //e.Graphics.DrawString("其 它 支 付",TextFont,Brushes.Black,tmpWith,curRowY+7+RowHight*3);                      
                        e.Graphics.DrawString("特定医保记帐", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);
                        tilWith = e.Graphics.MeasureString("恢复金额合计", TextFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawLine(penLine, tmpWith, curRowY, tmpWith, curRowY + RowHight * 5);
                        tmpWith += with;
                        e.Graphics.DrawString(" 有 效 票 数", TextFont, Brushes.Black, tmpWith, curRowY + 7);

                        e.Graphics.DrawString(StatisticsRow["有效票数"].ToString() + "张", TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight);//有效票数
                        e.Graphics.DrawString("￥" + Convert.ToDouble(tolMoney.ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 2);//有效金额
                        e.Graphics.DrawString("￥" + Convert.ToDouble(StatisticsRow["其它金额合计"].ToString()).ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 3);

                        ////佛二将医保费打印到其他记帐
                        //double hj = Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString()) + Convert.ToDouble(StatisticsRow["医保记账金额"].ToString());
                        //佛二将其它记帐改为特定医保记帐
                        double hj = Convert.ToDouble(StatisticsRow["医保记账金额"].ToString());
                        e.Graphics.DrawString("￥" + hj.ToString("0.00"), TextFont, Brushes.Black, tmpWith, curRowY + 7 + RowHight * 4);//其它记帐金额

                        #endregion


                        break;
                    case 1:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 9:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        curRowY += RowHight + 15;

                        break;
                    case 2:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 3:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 4:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                    case 6:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);

                        tilWith = e.Graphics.MeasureString("恢  复票数", TextFont);
                        tmpWith = LeftWith + tilWith.Width;
                        if (arrList.Count > 0)
                        {
                            float temY = 0;

                            float newWith = tmpWith;
                            float temcurRowY = curRowY;
                            int intRow = 0;
                            int tolRow = 0;
                            for (int f2 = 0; f2 < arrList.Count; f2++)
                            {
                                if (arrList[f2].ToString() == ",")
                                    tolRow++;
                            }
                            if (tolRow >= 3)
                            {
                                temY = 3;
                            }
                            else
                            {
                                temY = 10;
                            }
                            e.Graphics.DrawString(arrList[0].ToString(), TextFont, Brushes.Black, tmpWith, curRowY + temY+23);
                            int intCount = 0;
                            for (int j2 = 0; j2 < arrList.Count; j2++)
                            {

                                if (intRow == 3 && intCount == 0)
                                {
                                    intCount++;
                                    temcurRowY = temY + 10 + temcurRowY;
                                    tmpWith = newWith - 90;
                                }
                                if (arrList[j2].ToString() == ",")
                                {
                                    intRow++;
                                    tilWith = e.Graphics.MeasureString("- " + arrList[j2 - 1].ToString(), TextFont);
                                    tmpWith += tilWith.Width;
                                    e.Graphics.DrawString("- " + arrList[j2 - 1].ToString(), TextFont, Brushes.Black, tmpWith, temcurRowY + temY+23);
                                    if (j2 != arrList.Count - 1)
                                    {
                                        tilWith = e.Graphics.MeasureString("- " + arrList[j2 - 1].ToString(), TextFont);
                                        tmpWith += tilWith.Width;
                                        e.Graphics.DrawString("," + arrList[j2 + 1].ToString(), TextFont, Brushes.Black, tmpWith, temcurRowY + temY+23);
                                    }
                                }
                            }
                            tilWith = e.Graphics.MeasureString("- " + arrList[0].ToString(), TextFont);
                            tmpWith += tilWith.Width;
                            e.Graphics.DrawString("- " + arrList[arrList.Count - 1].ToString(), TextFont, Brushes.Black, tmpWith, temcurRowY + temY+23);
                        }

                        break;
                    case 7:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        tilWith = e.Graphics.MeasureString("恢  复票数", TextFont);
                        tmpWith = LeftWith + tilWith.Width;
                        if (SaveINVOICENO.Count > 0)
                        {
                            for (int k2 = 0; k2 < SaveINVOICENO.Count; k2++)
                            {
                                e.Graphics.DrawString(SaveINVOICENO[k2].ToString(), TextFont, Brushes.Black, tmpWith, curRowY + 7+33);
                                tilWith = e.Graphics.MeasureString(SaveINVOICENO[k2].ToString() + ",", TextFont);
                                tmpWith += tilWith.Width;
                            }
                        }

                        break;
                    case 8:
                        curRowY += RowHight+10;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        tilWith = e.Graphics.MeasureString("恢 复 票数", TextFont);
                        tmpWith = LeftWith + tilWith.Width;
                        if (arrReList.Count > 0)
                        {
                            for (int k2 = 0; k2 < arrReList.Count; k2++)
                            {
                                e.Graphics.DrawString(arrReList[k2].ToString(), TextFont, Brushes.Black, tmpWith, curRowY + 7+23);
                                tilWith = e.Graphics.MeasureString(arrReList[k2].ToString() + ",", TextFont);
                                tmpWith += tilWith.Width;
                            }
                        }

                        break;
                    case 11:
                        tmpWith = LeftWith + 4;
                        e.Graphics.DrawString("缴款人：", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        tilWith = e.Graphics.MeasureString("缴款人：", TextFont);
                        tmpWith += tilWith.Width;
                        e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName, TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        tmpWith += 200;
                        e.Graphics.DrawString("审核人：", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        tmpWith += 200;
                        e.Graphics.DrawString("出纳：", TextFont, Brushes.Black, tmpWith, curRowY + 7);
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);


                        break;
                    case 12:
                        curRowY += RowHight;
                        e.Graphics.DrawLine(penLine, curRowX, curRowY, PageWidth - RightWith, curRowY);
                        break;
                }
            }
            e.Graphics.DrawLine(penLine, curRowX, strLine + RowHight, curRowX, curRowY);
            e.Graphics.DrawLine(penLine, PageWidth - RightWith, strLine + RowHight, PageWidth - RightWith, curRowY);
            #endregion

        }
		#region 统计各种收费类型的金额
		private void m_mthDe(ref DataTable dtType,DataTable dtCheckOut)
		{
			
			if(dtCheckOut.Rows.Count>=0)
			{
				for(int i1=0;i1<dtType.Rows.Count;i1++)
				{
					Double tolMoney=0;
					for(int f2=0;f2<dtCheckOut.Rows.Count;f2++)
					{
						if(dtCheckOut.Rows[f2]["ITEMCATID_CHR"].ToString().Trim()==dtType.Rows[i1]["TYPEID_CHR"].ToString().Trim())
						{
							try
							{
								tolMoney+=Convert.ToDouble(dtCheckOut.Rows[f2]["SBSUM_MNY"].ToString().Trim());
							}
							catch
							{
								MessageBox.Show(dtCheckOut.Rows[f2]["SBSUM_MNY"].ToString());
							}
						}
					}
					dtType.Rows[i1]["tolMoney"]=tolMoney.ToString("0.00");
				}
			}
		}
		#endregion
		#region 获取数据
		/// <summary>
		/// 现金日结报表
		/// </summary>
		DataTable dt1=null;
		/// <summary>
		/// 现金日结报表(明细)
		/// </summary>
		DataTable dtDe1=null;
		/// <summary>
		/// 医保及刷卡日结报表
		/// </summary>
		DataTable dt2=null;
		/// <summary>
		/// 医保及刷卡日结报表(明细)
		/// </summary>
		DataTable dtDe2=null;
		/// <summary>
		/// 公费日结报表
		/// </summary>
		DataTable dt3=null;
		/// <summary>
		/// 公费日结报表(明细)
		/// </summary>
		DataTable dtDe3=null;
		/// <summary>
		/// 其它日结报表
		/// </summary>
		DataTable dt4=null;
		/// <summary>
		/// 其它日结报表(明细)
		/// </summary>
		DataTable dtDe4=null;
		/// <summary>
		/// 收费类型
		/// </summary>
		DataTable dtCheckType=null;
		public void m_mthGetData()
		{
			if(this.m_objViewer.isDoctorDean==true)
			{
				intcomand=1;
				strCheckManID=this.m_objViewer.m_cboCheckMan.SelectItemValue.ToString();
			}
			else
			{
				strCheckManID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			if(	intcomand==1)
			{
				strCheckDate=this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.CurrentCell.RowNumber,0].ToString();
				string BALANCEEMP=this.m_objViewer.LoginInfo.m_strEmpID;
				string CheckDate=this.m_objViewer.DateCheckOut.Value.ToShortDateString();
				Domain.m_lngGetPayTypeAndCheckOutDatahistory(strCheckDate,strCheckManID,out dtPayType,out dtCheckOut);
				this.m_objViewer.btnCheck.Enabled=false;
				this.m_objViewer.btnPrint.Enabled=true;
				this.m_objViewer.buttonXP3.Enabled=true;
				this.m_objViewer.buttonXP2.Enabled=true;

			}
			Domain.m_lngGetDataAllOfStat(strCheckDate,strCheckManID,out dt1,out dtDe1,out dt2,out dtDe2,out dt3,out dtDe3,out dt4,out dtDe4,out dtCheckType); 

			#region 设置打印
			this.m_objViewer.printDocument2.DefaultPageSettings.Landscape=false;
			foreach(PaperSize ps in this.m_objViewer.printDocument2.PrinterSettings.PaperSizes)
			{
				if(ps.PaperName=="A4")
				{
					this.m_objViewer.printDocument2.DefaultPageSettings.PaperSize=ps;
					break;
				}
			}
			#endregion
		}

		#endregion

		#region 分类收费
		/// <summary>
		/// 分类收费
		/// </summary>
		/// <param name="e"></param>
		public void printPageCheckMB(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=0;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",14);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",10);//文字使用的字体
			const float RowHight=23F;//项的高度
			const float LeftWith=10F;//左宿进的长度
			const float RightWith=40F;//右宿进的长度
			#endregion

			DataTable dtCheck=null;
			for(int f1=0;f1<4;f1++)
			{
				#region 头部
				Pen penLine=new Pen(Brushes.Black,1);
				curRowY+=5;
				curRowX=LeftWith;
				try
				{

					dtCheckType.Columns.Add("tolMoney");
				}
				catch
				{
					dtCheckType.Columns.RemoveAt(dtCheckType.Columns.Count-1);
					dtCheckType.Columns.Add("tolMoney");
	
				}
				SizeF tilWith= e.Graphics.MeasureString("收费员医保及刷卡日结报表",m_fntTitle);
				string strTiteName="";
				switch(f1)
				{
					case 0:
						strTiteName="收费员现金日结报表";
						dtCheck=dt1;
						m_mthDe(ref dtCheckType,dtDe1);
						break;
					case 1:
						strTiteName="收费员医保及刷卡日结报表";
						dtCheck=dt2;
						m_mthDe(ref dtCheckType,dtDe2);
						break;
					case 2:
						strTiteName="收费员公费日结报表";
						dtCheck=dt3;
						m_mthDe(ref dtCheckType,dtDe3);
						break;
					case 3:
						strTiteName="收费员其它日结报表";
						dtCheck=dt4;
						m_mthDe(ref dtCheckType,dtDe4);
						break;
				}
				e.Graphics.DrawString(strTiteName,m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,curRowY);
				curRowY+=25;
				e.Graphics.DrawString("实收日期：",TextFont,Brushes.Black,curRowX,curRowY);
				tilWith= e.Graphics.MeasureString("实收日期：",TextFont);
				curRowX+=tilWith.Width;
				e.Graphics.DrawString(strCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
				curRowX+=150;
				e.Graphics.DrawString("发票日期：",TextFont,Brushes.Black,curRowX,curRowY);
				tilWith= e.Graphics.MeasureString("发票日期：",TextFont);
				curRowX+=tilWith.Width;
				if(dtCheck.Rows.Count!=0)
				{
					e.Graphics.DrawString(dtCheck.Rows[0]["minrecorddate_dat"].ToString()+" ~ "+dtCheck.Rows[0]["maxrecorddate_dat"].ToString(),TextFont,Brushes.Black,curRowX,curRowY);
				}
				curRowX+=300;
				e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,curRowX+5,curRowY);
				tilWith= e.Graphics.MeasureString("打印日期： ",TextFont);
				string NowDate=DateTime.Now.ToShortDateString();
				e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,curRowX+tilWith.Width,curRowY);
				#endregion
				curRowX=LeftWith;
				curRowY+=15;
				float strLine=curRowY;
			
				#region 画表格
				for(int i1=0;i1<3;i1++)
				{
					float tmpWith;//X轴
					switch(i1)
					{
						case 0:
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							curRowY+=5;
							e.Graphics.DrawString("合计金额大写",TextFont,Brushes.Black,curRowX+5,curRowY);
							e.Graphics.DrawLine(penLine,curRowX+100,strLine,curRowX+100,curRowY+20);
							try
							{
								if(dtCheck.Rows[0]["totalmoney"].ToString()=="")
									dtCheck.Rows[0]["totalmoney"]=0;

								e.Graphics.DrawString(clsMain.CurrencyToString(Math.Abs(float.Parse(dtCheck.Rows[0]["totalmoney"].ToString()))),TextFont,Brushes.Black,curRowX+105,curRowY);
							}
							catch
							{
								
							}
							
							e.Graphics.DrawLine(penLine,PageWidth-260,strLine,PageWidth-260,curRowY+20);
							e.Graphics.DrawString("合计金额小写",TextFont,Brushes.Black,PageWidth-255,curRowY);
							e.Graphics.DrawLine(penLine,PageWidth-160,strLine,PageWidth-160,curRowY+20);
							
							e.Graphics.DrawString("￥"+dtCheck.Rows[0]["totalmoney"].ToString(),TextFont,Brushes.Black,PageWidth-160,curRowY);
							curRowY+=20;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 1:
							#region 填充收费类型数据
							if(dtPayType.Rows.Count>0)
							{
								tmpWith=LeftWith+2;
								curRowY+=10;
								for(int f2=0;f2<dtCheckType.Rows.Count;f2++)
								{
									if(f2%6==0&&f2!=0)
									{
										tmpWith=LeftWith+2;
										curRowY+=RowHight+5;
									}
									tilWith= e.Graphics.MeasureString("打印日期",TextFont);
									if(dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length>4)
									{
										string star=dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0,4);
										string end=dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
										e.Graphics.DrawString(star,TextFont,Brushes.Black,tmpWith,curRowY-5);
										e.Graphics.DrawString(end+"：",TextFont,Brushes.Black,tmpWith,curRowY+10);
                                        if (this.m_objViewer.Hospital_No == "00001")
										{
											if(dtCheckType.Rows[f2]["tolMoney"].ToString()!="0.00")
											{
												e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
											}
										}
										else
										{
											e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
										}
									}
									else
									{
										e.Graphics.DrawString(dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim()+"：",TextFont,Brushes.Black,tmpWith,curRowY);
                                        if (this.m_objViewer.Hospital_No == "00001")
										{
											if(dtCheckType.Rows[f2]["tolMoney"].ToString()!="0.00")
											{
												e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
											}
										}
										else
										{
											e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
										}
									}
									tmpWith+=130;
								}
							}
							curRowY+=RowHight;
							#endregion
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 2:
       
							tmpWith=LeftWith+4;
							e.Graphics.DrawString("缴款人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
							tilWith= e.Graphics.MeasureString("缴款人：",TextFont);
							tmpWith+=tilWith.Width;
							e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,tmpWith,curRowY+7);
						
					
							tmpWith+=200;
							e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
							tmpWith+=200;
							e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,tmpWith,curRowY+7);
							curRowY+=RowHight;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
					}
				}
				e.Graphics.DrawLine(penLine,curRowX,strLine,curRowX,curRowY);
				e.Graphics.DrawLine(penLine,PageWidth-RightWith,strLine,PageWidth-RightWith,curRowY);
				#endregion
			}

		}
		#endregion 


		#region 合并分类打印
		/// <summary>
		/// 合并分类打印
		/// </summary>
		/// <param name="e"></param>
		int intRow1=0;
		public void printPageCheckUnit(System.Drawing.Printing.PrintPageEventArgs e)
		{
			#region 变量
			float PageWidth=e.PageBounds.Width;//获得页面的宽度
			float PageHight=e.PageBounds.Height;//获得页面的高度
			float curRowY=20F;//当前行的Y坐标
			float curRowX=0;//当前行的X坐标
			System.Drawing.Font m_fntTitle=new Font("宋体",14);//标题使用的字体
			System.Drawing.Font TextFont=new Font("宋体",10);//文字使用的字体
			const float RowHight=23F;//项的高度
			const float LeftWith=10F;//左宿进的长度
			const float RightWith=40F;//右宿进的长度
			#endregion
			DataTable dtCheck=null;
			

			for(int f1=intRow1;f1<4;f1++)
			{
				if(intRow1==2)
				{
					intRow1=0;
				}
				#region 头部
				Pen penLine=new Pen(Brushes.Black,1);
				curRowY+=50;
				curRowX=LeftWith;
				try
				{

					dtCheckType.Columns.Add("tolMoney");
				}
				catch
				{
					dtCheckType.Columns.RemoveAt(dtCheckType.Columns.Count-1);
					dtCheckType.Columns.Add("tolMoney");
	
				}
				SizeF tilWith= e.Graphics.MeasureString("收费员医保及刷卡日结报表",m_fntTitle);
				string strTiteName="";
				ArrayList arrCheck=new ArrayList();
				ArrayList arrReturn=new ArrayList();
				ArrayList arrBreck=new ArrayList();
				string  totailMoney="0";
				string  minCheckDate="0";
				string  maxCheckDate="0";
				DataTable   dtCheckNo=new DataTable();
				ArrayList arr1=new ArrayList();
				switch(f1)
				{
					case 0:
						strTiteName="收费员现金日结报表";
						dtCheck=dt1;
						m_mthDe(ref dtCheckType,dtDe1);
						m_mthCheckNO(1,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						clsMain.m_Detach(dtCheckNo,"CheckNo",out arr1);
						break;
					case 1:
						strTiteName="收费员医保及刷卡日结报表";
						dtCheck=dt2;
						m_mthDe(ref dtCheckType,dtDe2);
						m_mthCheckNO(2,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						break;
					case 2:
						strTiteName="收费员公费日结报表";
						dtCheck=dt3;
						m_mthDe(ref dtCheckType,dtDe3);
						m_mthCheckNO(3,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						break;
					case 3:
						strTiteName="收费员其它日结报表";
						dtCheck=dt4;
						m_mthDe(ref dtCheckType,dtDe4);
						m_mthCheckNO(4,out arrCheck,out arrReturn,out arrBreck,out totailMoney,out minCheckDate,out maxCheckDate,out dtCheckNo);
						break;
				}
				e.Graphics.DrawString(strTiteName,m_fntTitle,Brushes.Black,(PageWidth-tilWith.Width)/2,curRowY);
				curRowY+=25;
				e.Graphics.DrawString("实收日期：",TextFont,Brushes.Black,curRowX,curRowY);
				tilWith= e.Graphics.MeasureString("实收日期：",TextFont);
				curRowX+=tilWith.Width;
				e.Graphics.DrawString(strCheckDate,TextFont,Brushes.Black,curRowX,curRowY);
				curRowX+=150;
				e.Graphics.DrawString("发票日期：",TextFont,Brushes.Black,curRowX,curRowY);
				tilWith= e.Graphics.MeasureString("发票日期：",TextFont);
				curRowX+=tilWith.Width;
				if(dtCheck.Rows.Count!=0)
				{
					e.Graphics.DrawString(dtCheck.Rows[0]["minrecorddate_dat"].ToString()+" ~ "+dtCheck.Rows[0]["maxrecorddate_dat"].ToString(),TextFont,Brushes.Black,curRowX,curRowY);
				}
				curRowX+=300;
				e.Graphics.DrawString("打印日期：",TextFont,Brushes.Black,curRowX+5,curRowY);
				tilWith= e.Graphics.MeasureString("打印日期： ",TextFont);
				string NowDate=DateTime.Now.ToShortDateString();
				e.Graphics.DrawString(NowDate,TextFont,Brushes.Black,curRowX+tilWith.Width,curRowY);
				#endregion
				curRowX=LeftWith;
				curRowY+=15;
				float strLine=curRowY;
			
				#region 画表格
				for(int i1=0;i1<5;i1++)
				{
					float tmpWith=20;//X轴
					switch(i1)
					{
						case 0:
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							curRowY+=5;
							e.Graphics.DrawString("合计金额大写",TextFont,Brushes.Black,curRowX+5,curRowY);
							e.Graphics.DrawLine(penLine,curRowX+100,strLine,curRowX+100,curRowY+20);
							try
							{
								if(dtCheck.Rows[0]["totalmoney"].ToString()=="")
									dtCheck.Rows[0]["totalmoney"]=0;

								e.Graphics.DrawString(clsMain.CurrencyToString(Math.Abs(float.Parse(dtCheck.Rows[0]["totalmoney"].ToString()))),TextFont,Brushes.Black,curRowX+105,curRowY);
							}
							catch
							{
								
							}
							
							e.Graphics.DrawLine(penLine,PageWidth-260,strLine,PageWidth-260,curRowY+20);
							e.Graphics.DrawString("合计金额小写",TextFont,Brushes.Black,PageWidth-255,curRowY);
							e.Graphics.DrawLine(penLine,PageWidth-160,strLine,PageWidth-160,curRowY+20);
							
							e.Graphics.DrawString("￥"+dtCheck.Rows[0]["totalmoney"].ToString(),TextFont,Brushes.Black,PageWidth-160,curRowY);
							curRowY+=20;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 1:
							#region 填充收费类型数据
							if(dtPayType.Rows.Count>0)
							{
								tmpWith=LeftWith+2;
								curRowY+=10;
								for(int f2=0;f2<dtCheckType.Rows.Count;f2++)
								{
									if(f2%6==0&&f2!=0)
									{
										tmpWith=LeftWith+2;
										curRowY+=RowHight+5;
									}
									tilWith= e.Graphics.MeasureString("打印日期",TextFont);
									if(dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Length>4)
									{
										string star=dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(0,4);
										string end=dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim().Substring(4);
										e.Graphics.DrawString(star,TextFont,Brushes.Black,tmpWith,curRowY-5);
										e.Graphics.DrawString(end+"：",TextFont,Brushes.Black,tmpWith,curRowY+10);
                                        if (this.m_objViewer.Hospital_No == "00001")
										{
											if(dtCheckType.Rows[f2]["tolMoney"].ToString()!="0.00")
											{
												e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
											}
										}
										else
										{
											e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
										}
									}
									else
									{
										e.Graphics.DrawString(dtCheckType.Rows[f2]["TYPENAME_VCHR"].ToString().Trim()+"：",TextFont,Brushes.Black,tmpWith,curRowY);
                                        if (this.m_objViewer.Hospital_No == "00001")
										{
											if(dtCheckType.Rows[f2]["tolMoney"].ToString()!="0.00")
											{
												e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
											}
										}
										else
										{
											e.Graphics.DrawString(dtCheckType.Rows[f2]["tolMoney"].ToString()+"元",TextFont,Brushes.Black,tmpWith+tilWith.Width,curRowY);
										}
									}
									tmpWith+=130;
								}
							}
							curRowY+=RowHight;
							#endregion
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 2:
							curRowY+=50;
							float temY=0;
							if(f1==1)
							{
								
								if(arr1.Count>0)
								{
									curRowY-=50;
									int intRow=0;
									int tolRow=0;
									for(int f2=0;f2<arr1.Count;f2++)
									{
										if(arr1[f2].ToString()==",")
											tolRow++;
									}
									if(tolRow>=4)
									{
										temY=5;
									}
									else
									{
										temY=10;
									}
									
									e.Graphics.DrawString(arr1[0].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
									int intCount=0;
									for(int j2=0;j2<arr1.Count;j2++)
									{
						
										if(intRow==4&&intCount==0)
										{
											intCount++;
											curRowY=temY+10+curRowY;
											tmpWith=20;
										}
										try
										{
											if(arr1[j2].ToString()==",")
											{
												intRow++;
												tilWith=e.Graphics.MeasureString("- "+arr1[0].ToString(),TextFont);
												tmpWith+=tilWith.Width;
											
												e.Graphics.DrawString("- "+arr1[j2-1].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
												if(j2!=arr1.Count-1)
												{
													tilWith= e.Graphics.MeasureString("- "+arr1[0].ToString(),TextFont);
													tmpWith+=tilWith.Width;
													e.Graphics.DrawString(","+arr1[j2+1].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
												}	
											}
										}
										catch
										{
										}
									}
									tilWith=e.Graphics.MeasureString("- "+arr1[0].ToString(),TextFont);
									tmpWith+=tilWith.Width;
									e.Graphics.DrawString("- "+arr1[arr1.Count-1].ToString(),TextFont,Brushes.Black,tmpWith,curRowY+temY);
									curRowY+=(intCount+3)*temY;
								}
							}
							else
							{
								
								float tempX;
								float tempY;
								if(arrCheck.Count>0)
								{
									curRowY-=50;
									tempX=tmpWith;
									tempY=curRowY+10;
									int RowCount=1;
									for(int k1=0;k1<arrCheck.Count;k1++)
									{
										if(k1==0)
										{
											e.Graphics.DrawString(arrCheck[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(arrCheck[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										else
										{
											e.Graphics.DrawString(","+arrCheck[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(","+arrCheck[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										if(k1!=arrCheck.Count&&tempX+tilWith.Width>=PageWidth-RightWith)
										{
											RowCount++;
											tempX=tmpWith;
											tempY=curRowY+15*RowCount;
											
										}
									}
									curRowY=tempY+20;
								}
								
							}
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 3:
							try
							{
								float tempX=0;
								float tempY=0;
								e.Graphics.DrawString("退票发票号",TextFont,Brushes.Black,curRowX+5,curRowY+5);
								e.Graphics.DrawLine(penLine,curRowX+100,curRowY,curRowX+100,curRowY+20);
							
								if(arrReturn.Count>0)
								{
									tempX=curRowX+105;
									tempY=curRowY+5;
									int RowCount=1;
									for(int k1=0;k1<arrReturn.Count;k1++)
									{
										if(k1==0)
										{
											e.Graphics.DrawString(arrReturn[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(arrReturn[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										else
										{
			
											e.Graphics.DrawString(","+arrReturn[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(","+arrReturn[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										if(k1!=arrReturn.Count&&tempX+tilWith.Width>=PageWidth-300)
										{
											RowCount++;
											tempX=curRowX+105;
											tempY=curRowY+10*RowCount;
										}
									}
								}
								e.Graphics.DrawLine(penLine,PageWidth-350,curRowY,PageWidth-350,curRowY+20);
								e.Graphics.DrawString("恢复发票号",TextFont,Brushes.Black,PageWidth-345,curRowY+5);
								e.Graphics.DrawLine(penLine,PageWidth-250,curRowY,PageWidth-250,curRowY+20);
							
								if(arrBreck.Count>0)
								{
									tempX=PageWidth-255;
									tempY=curRowY+5;
									int RowCount=1;
									for(int k1=0;k1<arrBreck.Count;k1++)
									{
										if(k1==0)
										{
											e.Graphics.DrawString(arrBreck[k1].ToString(),TextFont,Brushes.Black,tempX,tempY);
											tilWith=e.Graphics.MeasureString(arrBreck[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										else
										{
											e.Graphics.DrawString(","+arrBreck[k1].ToString(),TextFont,Brushes.Black,PageWidth-200,tempY);
											tilWith=e.Graphics.MeasureString(","+arrBreck[k1].ToString(),TextFont);
											tempX+=tilWith.Width;
										}
										if(k1!=arrBreck.Count&&tempX+tilWith.Width>=PageWidth-RightWith)
										{
											RowCount++;
											tempX=PageWidth-200;
											tempY=curRowY+10*RowCount;
										}
									}
									curRowY=tempY+5;
					
								}
							}
							catch
							{
								MessageBox.Show("2");
							}

							curRowY+=20;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
						case 4:
       
							tmpWith=LeftWith+4;
							e.Graphics.DrawString("缴款人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
							tilWith= e.Graphics.MeasureString("缴款人：",TextFont);
							tmpWith+=tilWith.Width;
							e.Graphics.DrawString(this.m_objViewer.LoginInfo.m_strEmpName,TextFont,Brushes.Black,tmpWith,curRowY+7);
						
					
							tmpWith+=200;
							e.Graphics.DrawString("审核人：",TextFont,Brushes.Black,tmpWith,curRowY+7);
							tmpWith+=200;
							e.Graphics.DrawString("出纳：",TextFont,Brushes.Black,tmpWith,curRowY+7);
							curRowY+=RowHight;
							e.Graphics.DrawLine(penLine,curRowX,curRowY,PageWidth-RightWith,curRowY);
							break;
					}

				}
				e.Graphics.DrawLine(penLine,curRowX,strLine,curRowX,curRowY);
				e.Graphics.DrawLine(penLine,PageWidth-RightWith,strLine,PageWidth-RightWith,curRowY);
				if(f1==1)
				{
					e.HasMorePages=true;
					intRow1=2;
					return;
				}
				#endregion
			}

		}
		#endregion 

		#region 结帐
		string checkDate;
		public void CheckData()
		{
            long l = Domain.m_lngCheckData(this.m_objViewer.LoginInfo.m_strEmpID, out checkDate);
            if (l > 0)
            {
                this.m_objViewer.ctlDgFind.m_mthAppendRow();
                this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.RowCount - 1, 0] = checkDate;
                this.m_objViewer.ctlprintShow2.setDocument = this.m_objViewer.printDocument1;
                this.m_objViewer.ctlDgFind.m_mthSelectARow(this.m_objViewer.ctlDgFind.RowCount - 1);
            }
		}

        public void CheckDataByDate(string p_strCheckDate)
        {
            long l = Domain.CheckDataByDate(this.m_objViewer.LoginInfo.m_strEmpID, p_strCheckDate, out checkDate);
            if (l > 0)
            {
                this.m_objViewer.ctlDgFind.m_mthAppendRow();
                this.m_objViewer.ctlDgFind[this.m_objViewer.ctlDgFind.RowCount - 1, 0] = checkDate;
                this.m_objViewer.ctlprintShow2.setDocument = this.m_objViewer.printDocument1;
                this.m_objViewer.ctlDgFind.m_mthSelectARow(this.m_objViewer.ctlDgFind.RowCount - 1);
            } 
        }
		#endregion

		#region 查找数据
		DataTable dthistory=new DataTable();
		public void findhistory()
		{
			string startDate=this.m_objViewer.starDate.Value.ToShortDateString();
			string endDate=this.m_objViewer.EndDate.Value.ToShortDateString();
			string checkMan="";
			if(this.m_objViewer.isDoctorDean==false)
				checkMan=this.m_objViewer.LoginInfo.m_strEmpID;
			else
			{
				if(this.m_objViewer.m_cboCheckMan.SelectItemValue!=null)
					checkMan=this.m_objViewer.m_cboCheckMan.SelectItemValue.ToString();
			}
			long lngRes=Domain.m_lngGetHistory(startDate,endDate,checkMan,out dthistory);
			this.m_objViewer.ctlDgFind.m_mthDeleteAllRow();
			if(lngRes==1)
			{
				for(int i1=0;i1<dthistory.Rows.Count;i1++)
				{
					this.m_objViewer.ctlDgFind.m_mthAppendRow();
					this.m_objViewer.ctlDgFind[i1,0]=dthistory.Rows[i1]["BALANCE_DAT"].ToString();
				}
				this.m_objViewer.ctlDgFind.CurrentCell=new DataGridCell(0,0);
				this.m_objViewer.ctlDgFind.m_mthSelectARow(0);
			}

		}
		#endregion

		public void dgSelect()
		{
			
			intcomand=1;
			this.m_objViewer.ctlprintShow2.setDocument=this.m_objViewer.printDocument1;
		}

		public void Reset()
		{
				intcomand=0;
				this.m_objViewer.ctlprintShow2.setDocument=this.m_objViewer.printDocument1;
		}
	}
}
