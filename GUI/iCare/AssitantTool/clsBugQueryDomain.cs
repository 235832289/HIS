using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using com.digitalwave.emr.HospitalManagerService;

namespace iCare
{
	/// <summary>
	/// clsControlBugQuery 的摘要说明。
	/// </summary>
	public class clsBugQueryDomain//:com.digitalwave.GUI_Base.clsController_Base
	{
		private string m_strDeptNameString = "deptname_vchr";
		private string m_strDeptshortnString = "shortno_chr";
		private string m_strDeptattributeidString = "attributeid";
		private string m_strDeptIDString = "deptid_chr";
		private string m_strParentDeptIDString = "parentid";

		private const string c_strSql = @"select a.*
  from INPATIENTCASE_GRADE a
 inner join T_OPR_BIH_REGISTER b on a.inpatientid = b.inpatientid_chr
                                and a.inpatientdate = b.inpatient_dat
 inner join T_OPR_BIH_LEAVE le on b.registerid_chr = le.registerid_chr
                              and le.status_int = 1
 where 1=1 ";

		private ArrayList m_arlFlawed;
		public clsBugQueryDomain()
		{
			m_arlFlawed = new ArrayList(30);
		}
		internal frmBugQuery m_objViewer;

		private void m_mthFillDept()
		{
			DataTable deptDt=new DataTable();
            clsHospitalManagerService objHospitalServ =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));

			DataTable dtbDept = new DataTable();
			long lngRes = objHospitalServ.m_lngGetAllDeptInfo(null,out dtbDept);
			if(lngRes > 0 && dtbDept.Rows.Count > 0)
			{
				m_objViewer.m_lsvFind.Tag = dtbDept;
				DataRow[] objRows = new DataRow[dtbDept.Rows.Count];
				dtbDept.Rows.CopyTo(objRows,0);
				m_mthAddToDept(objRows);
			}
		}
		private void m_mthAddToDept(DataRow[] p_objRows)
		{
			m_objViewer.m_lsvFind.Items.Clear();
			DataRow objRow = null;
			string strAttribute = "";
			for(int i=0;i<p_objRows.Length;i++)
			{
				objRow = p_objRows[i];
				ListViewItem item = new ListViewItem(objRow[m_strDeptNameString].ToString());
				item.SubItems.Add(objRow[m_strDeptshortnString].ToString().Trim());
				strAttribute = objRow[m_strDeptattributeidString].ToString().Trim();
				if(strAttribute == "0000002")
					item.SubItems.Add("科室");
				else if(strAttribute == "0000003")
					item.SubItems.Add("病区");
				item.SubItems.Add(objRow[m_strDeptIDString].ToString());
				m_objViewer.m_lsvFind.Items.Add(item);
			}
		}
		internal void m_mthFindDepts(string p_strLikeString)
		{
			if(m_objViewer.m_lsvFind.Tag is DataTable)
			{
				DataTable dtb = (DataTable)m_objViewer.m_lsvFind.Tag;
				if(p_strLikeString == string.Empty)
				{
					DataRow[] objRows = new DataRow[dtb.Rows.Count];
					dtb.Rows.CopyTo(objRows,0);
					m_mthAddToDept(objRows);
				}
				else
				{
					DataRow[] objRows = dtb.Select(m_strDeptNameString+" like '%"+p_strLikeString+"%' or "+m_strDeptshortnString + " like '%"+p_strLikeString+"%'",m_strDeptNameString);
					if(objRows.Length > 0)
						m_mthAddToDept(objRows);
				}
			}
		}
		public void m_mthFillTree()
		{
			m_mthFillDept();
			frmCaseGrade frmCaseGrade = new frmCaseGrade();
			if(frmCaseGrade.Controls.Count>0)
			{
				Control ctlTab = null;
				for(int i1=0;i1<frmCaseGrade.Controls.Count;i1++)
				{
					ctlTab = frmCaseGrade.Controls[i1];
					if(ctlTab is Crownwood.Magic.Controls.TabControl)
					{
						Crownwood.Magic.Controls.TabControl  tabObj=(Crownwood.Magic.Controls.TabControl)frmCaseGrade.Controls[i1];
						System.Windows.Forms.TreeNode node=null;
						System.Windows.Forms.CheckBox checkbox=null;
						if(tabObj.TabPages.Count>0)
						{
							Crownwood.Magic.Controls.TabPage tabPage = null;
							for(int f2=0;f2<tabObj.TabPages.Count-1;f2++)
							{
								tabPage = tabObj.TabPages[f2];
								node = new TreeNode();
								if(tabPage.Tag is String)
									node.Text = tabPage.Tag.ToString();
								else
									node.Text = tabPage.Title+"有缺陷";
								if(tabPage.AccessibleName != null)
									if(tabPage.AccessibleName == "1")
										node.Checked = true;
								node.Tag = tabPage.AccessibleDescription;
								this.m_objViewer.m_trvItems.Nodes.Add(node);
								Control ctlItems = null;
								for(int f3=0;f3<tabPage.Controls.Count;f3++)
								{
									ctlItems = tabPage.Controls[f3];
									switch(ctlItems.GetType().Name)
									{
										case "CheckBox":
											checkbox=(System.Windows.Forms.CheckBox)ctlItems;
											node = new TreeNode();
											node.Text=checkbox.Text;
											node.Tag=checkbox.Name;
											if(checkbox.AccessibleName != null)
												if(checkbox.AccessibleName == "1")
													node.Checked = true;
											this.m_objViewer.m_trvItems.Nodes[this.m_objViewer.m_trvItems.Nodes.Count-1].Nodes.Add(node);
											break;
										case "Panel":
											System.Windows.Forms.Panel panel=(System.Windows.Forms.Panel)ctlItems;
											for(int f4=0;f4<panel.Controls.Count;f4++)
											{
												ctlItems = panel.Controls[f4];
												if(ctlItems.GetType().Name=="CheckBox")
												{
													checkbox=(System.Windows.Forms.CheckBox)ctlItems;
													node = new TreeNode();
													node.Text=checkbox.Text;
													node.Tag=checkbox.Name;
													if(checkbox.AccessibleName != null)
														if(checkbox.AccessibleName == "1")
															node.Checked = true;
													this.m_objViewer.m_trvItems.Nodes[this.m_objViewer.m_trvItems.Nodes.Count-1].Nodes.Add(node);
												}
											}
											break;
									}
								}
							}
						}
						break;
					}
				}
			}
			if(m_objViewer.m_trvItems.Nodes.Count > 0)
				m_objViewer.m_trvItems.Nodes[0].Expand();
		}

		#region Old
//		public void m_mthQuery(DateTime startDate,DateTime EndDate)
//		{
//			DataTable deptDt=new DataTable();
//			string anyWhere="";
//			if(this.m_objViewer.m_rdbAllDept.Checked)
//			{
//				bugQuery.m_lngGetDept(out deptDt,"");
//			}
//			if(this.m_objViewer.m_rdbMedical.Checked)
//			{
//				bugQuery.m_lngGetDept(out deptDt,this.m_objViewer.m_rdbMedical.Text);
//			}
//			if(this.m_objViewer.m_rdbSurgery.Checked)
//			{
//				bugQuery.m_lngGetDept(out deptDt,this.m_objViewer.m_rdbSurgery.Text);
//			}
//			if(deptDt.Rows.Count>0)
//			{
//				for(int i1=0;i1<deptDt.Rows.Count;i1++)
//				{
//					if(i1==0)
//						anyWhere+=deptDt.Rows[i1]["DEPTID_CHR"].ToString();
//					else
//						anyWhere+=","+deptDt.Rows[i1]["DEPTID_CHR"].ToString();
//				}
//			}
//			if(this.m_objViewer.m_rdbAllDept.Checked)
//			{
//				anyWhere=(string)this.m_objViewer.m_txtDept.Tag;
//			}
//			string strSQL="select count(*) as totailcounts from (select DISTINCT a.INPATIENTID,a.INPATIENTDATE from INPATIENTCASE_GRADE a,"+@"
//				T_OPR_BIH_REGISTER b,T_OPR_BIH_LEAVE c  where a.INPATIENTID=b.INPATIENTID_CHR and a.INPATIENTDATE=b.MODIFY_DAT "+@"
//                and b.REGISTERID_CHR=c.LEAVEID_CHR and c.OUTHOSPITAL_DAT between '"+startDate.ToShortDateString()+" 00:00:00' "+@"
//				and '"+EndDate.ToShortDateString()+" 23:59:59' and c.OUTDEPTID_CHR in("+anyWhere+") left join";
//			string strSQL1="";
//			if(this.m_objViewer.m_trvItems.Nodes.Count>0)
//			{
//				for(int i1=0;i1<this.m_objViewer.m_trvItems.Nodes.Count;i1++)
//				{
//					if(this.m_objViewer.m_trvItems.Nodes[i1].Checked)
//					{
//						if(this.m_objViewer.m_trvItems.Nodes[i1].Nodes.Count>0)
//						{
//							strSQL+="select count(*) as counts from (select DISTINCT INPATIENTID,INPATIENTDATE from INPATIENTCASE_GRADE where ";
//							for(int f2=0;f2<this.m_objViewer.m_trvItems.Nodes[i1].Nodes.Count;f2++)
//							{
//								if(f2==0)
//								{
//									strSQL+="ITEMID='"+this.m_objViewer.m_trvItems.Nodes[i1].Nodes[f2].Tag.ToString()+"'";
//								}
//								else
//								{
//									if(f2==this.m_objViewer.m_trvItems.Nodes[i1].Nodes.Count-1)
//										strSQL+=" or ITEMID='"+this.m_objViewer.m_trvItems.Nodes[i1].Nodes[f2].Tag.ToString()+"')";
//									else
//										strSQL+=" or ITEMID='"+this.m_objViewer.m_trvItems.Nodes[i1].Nodes[f2].Tag.ToString()+"'";
//								}
//								if(this.m_objViewer.m_trvItems.Nodes[i1].Nodes[f2].Checked)
//								{
//									if(strSQL1=="")
//									{
//										strSQL1=" select count(*) as counts from (select DISTINCT INPATIENTID,INPATIENTDATE from INPATIENTCASE_GRADE where ITEMID='"+this.m_objViewer.m_trvItems.Nodes[i1].Nodes[f2].Tag.ToString()+"')";
//									}
//									else
//									{
//										strSQL1+="  left join select count(*) as counts from (select DISTINCT INPATIENTID,INPATIENTDATE from INPATIENTCASE_GRADE where ITEMID='"+this.m_objViewer.m_trvItems.Nodes[i1].Nodes[f2].Tag.ToString()+"')";
//									}
//								}
//							}
//							strSQL+=" left join";
//						}
//					}
//				}
//			}
//			strSQL=strSQL+strSQL1;
//		}
		#endregion Old

		internal void m_mthQuery()
		{
			m_arlFlawed.Clear();
			string strWhere = "";
			ArrayList arlParam = new ArrayList(4);
			if(m_objViewer.m_rdbSingleDept.Checked && m_objViewer.m_txtDept.Tag is String)
			{
				strWhere = " and b.deptid_chr = ?";
				arlParam.Add(m_objViewer.m_txtDept.Tag.ToString());
			}
			else if(m_objViewer.m_lsvFind.Tag is DataTable)
			{
				if(m_objViewer.m_rdbMedical.Checked)
				{
					string strDeptId = m_strGetDeptId("0000002",(DataTable)m_objViewer.m_lsvFind.Tag);
					if(strDeptId != "")
						strWhere = strDeptId;
				}
				else if(m_objViewer.m_rdbSurgery.Checked)
				{
					string strDeptId = m_strGetDeptId("0000027",(DataTable)m_objViewer.m_lsvFind.Tag);
					if(strWhere == "" || strDeptId == "")
						strWhere = strDeptId;
					else
						strWhere += ","+strDeptId;
				}
				if(strWhere != "")
				{
					if(strWhere[0] == ',')
						strWhere = strWhere.Remove(0,1);
					string[] strArr = strWhere.Split(',');
					string str1 = "?";
					arlParam.Add(strArr[0]);
					for(int i=1;i<strArr.Length;i++)
					{
						str1 += ",?";
						arlParam.Add(strArr[i]);
					}
					strWhere = "and b.deptid_chr in ("+str1+") ";
				}
			}
//			strWhere += " and le.modify_dat between '"+m_objViewer.m_dtpStart.Value.ToShortDateString()+" 00:00:00' and '"+m_objViewer.m_dtpEnd.Value.ToShortDateString()+" 23:59:59'";
			strWhere += " and le.modify_dat between ? and ?";
			arlParam.Add(m_objViewer.m_dtpStart.Value.Date);
			arlParam.Add(m_objViewer.m_dtpEnd.Value.AddDays(1).Date);

            com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objServ =
                (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

			DataTable dtb = new DataTable();
			object[] objArr = arlParam.ToArray();
			
			long lngRes = objServ.m_lngGetDataWithParam(c_strSql + strWhere,objArr,ref dtb);
			if(lngRes <= 0 || dtb.Rows.Count == 0) return ;

			m_mthBeginCalculation(dtb);
			dtb.Clear();
			dtb.Dispose();
		}
		private void m_mthBeginCalculation(DataTable p_dtbValues)
		{
			int intTotle = 0;
			int intA = 0;
			int intB = 0;
			int intC = 0;
			DataRow[] objRowArr = p_dtbValues.Select("itemid = 'm_txtAllResult'");
			intTotle = objRowArr.Length;
			objRowArr = p_dtbValues.Select("itemid = 'm_txtAllResult' and itemcontent = '甲级'");
			intA = objRowArr.Length;
			objRowArr = p_dtbValues.Select("itemid = 'm_txtAllResult' and itemcontent = '乙级'");
			intB = objRowArr.Length;
			objRowArr = p_dtbValues.Select("itemid = 'm_txtAllResult' and itemcontent = '丙级'");
			intC = objRowArr.Length;
			clsFlawedRecord.m_intTotal = intTotle;
			clsFlawedRecord.m_intA = intA;
			clsFlawedRecord.m_intB = intB;
			clsFlawedRecord.m_intC = intC;
			foreach(TreeNode node in m_objViewer.m_trvItems.Nodes)
			{
				m_mthCalculationSub(node,p_dtbValues);
			}
			clsFlawedRecord.m_intTotal = intTotle;
			objRowArr = null;
		}
		private void m_mthCalculationSub(TreeNode p_trnParent,DataTable p_dtbValues)
		{
			if(p_trnParent.Checked && p_trnParent.Tag != null)
			{
				DataRow[] objRowArr = p_dtbValues.Select("itemid = '"+p_trnParent.Tag.ToString()+"' and itemcontent <> '0'");
				clsFlawedRecord objFlawedRecord = new clsFlawedRecord(p_trnParent.Text,objRowArr.Length);
				m_arlFlawed.Add(objFlawedRecord);
			}
			if(p_trnParent.Nodes.Count > 0)
			{
				foreach(TreeNode node in p_trnParent.Nodes)
				{
					m_mthCalculationSub(node,p_dtbValues);
				}
			}
		}
		private string m_strGetDeptId(string p_strParentDeptId,DataTable p_dtbDepts)
		{
			string strId = "";
			DataRow[] objRows = p_dtbDepts.Select(m_strParentDeptIDString+" = '"+p_strParentDeptId+"' ");
			if(objRows.Length > 0)
			{
				DataRow objRow = null;
				for(int i=0;i<objRows.Length;i++)
				{
					objRow = objRows[i];
					string strAttributeid = objRow[m_strDeptattributeidString].ToString();
					if(objRow["inpatientoroutpatient_int"].ToString() == "1" && strAttributeid == "0000002")
						strId += "," + objRow[m_strDeptIDString].ToString().Trim();
					string strSql = "";
					if(strAttributeid != "0000003")
					{
						strSql = m_strGetDeptId(objRow[m_strDeptIDString].ToString(),p_dtbDepts);
					}
					if(strSql != "")
					{
						if(strSql[0] == ',')
							strSql.Remove(0,1);
						strId += "," + strSql;
					}
				}
			}
			return strId;
		}
		#region Print
		private bool m_blnIsFirstPrint = true;
		private int m_intPrintIndex = 0;
		private int m_intPrintPage = 1;
		private const int m_intLeft = 60;
		private const int m_intWidth = 670;
		private const int m_intLeft2 = 490;
		private const int m_intLeft3 = 610;
		private const int m_intHeight = 40;
		private const int m_intBottom = 1050;
		internal void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
		{
			if(m_arlFlawed.Count > 0)
			{
				Brush bruBlack = new SolidBrush(Color.Black);
				StringFormat sf = new StringFormat(StringFormatFlags.FitBlackBox);
				sf.LineAlignment = StringAlignment.Center;
				sf.Alignment = StringAlignment.Center;
				Font fntTitle = new Font("黑体",15F);
				e.Graphics.DrawString("出院病历缺陷分类统计表",fntTitle,bruBlack,new Rectangle(m_intLeft,100,m_intWidth,m_intHeight),sf);
				if(m_intPrintPage == 1)
					e.Graphics.DrawString(m_objViewer.m_dtpStart.Value.ToString("yyyy年MM月dd日")+"至"+m_objViewer.m_dtpEnd.Value.ToString("yyyy年MM月dd日")+clsFlawedRecord.m_intTotal+"份病历统计",fntTitle,bruBlack,new Rectangle(m_intLeft,140,m_intWidth,m_intHeight),sf);

				int intYPos = 190;
				if(m_intPrintPage != 1)
					intYPos = 150;
				e.Graphics.DrawLine(Pens.Black,m_intLeft,intYPos,m_intLeft+m_intWidth,intYPos);
				e.Graphics.DrawString("缺陷分类",fntTitle,bruBlack,new Rectangle(m_intLeft,intYPos,m_intLeft2-m_intLeft,m_intHeight),sf);
				e.Graphics.DrawString("例数",fntTitle,bruBlack,new Rectangle(m_intLeft2,intYPos,m_intLeft3-m_intLeft2,m_intHeight),sf);
				e.Graphics.DrawString("百分率(%)",fntTitle,bruBlack,new Rectangle(m_intLeft3,intYPos,m_intLeft+m_intWidth-m_intLeft3,m_intHeight),sf);
				m_mthPrintLine( e,ref intYPos,null,sf);
				for(int i=m_intPrintIndex;i<m_arlFlawed.Count;i++)
				{
					clsFlawedRecord obj = (clsFlawedRecord)m_arlFlawed[i];
					m_mthPrintLine( e,ref intYPos,obj,sf);
					if((i+1)%20 == 0 && i != 0)
					{
						e.Graphics.DrawString("第 "+m_intPrintPage+" 页",fntTitle,bruBlack,new Rectangle(m_intLeft3,m_intBottom,120,m_intHeight),sf);
						m_intPrintPage++;
						e.HasMorePages = true;
						m_intPrintIndex++;
						return;
					}
					m_intPrintIndex++;
				}
				sf.Alignment = StringAlignment.Near;
				e.Graphics.DrawString("甲级病历",fntTitle,bruBlack,new Rectangle(m_intLeft,intYPos,m_intLeft2-m_intLeft,m_intHeight),sf);
				sf.Alignment = StringAlignment.Far;
				e.Graphics.DrawString(clsFlawedRecord.m_intA.ToString(),fntTitle,bruBlack,new Rectangle(m_intLeft2,intYPos,m_intLeft3-m_intLeft2,m_intHeight),sf);
				float flt = (float)clsFlawedRecord.m_intA/(float)clsFlawedRecord.m_intTotal*100;
				string str = flt.ToString("00.0")+"%";
				if(str[0] == '0')
					str = str.Remove(0,1);
				e.Graphics.DrawString(str,fntTitle,bruBlack,new Rectangle(m_intLeft3,intYPos,m_intLeft+m_intWidth-m_intLeft3,m_intHeight),sf);
				m_mthPrintLine( e,ref intYPos,null,sf);

				sf.Alignment = StringAlignment.Near;
				e.Graphics.DrawString("乙级病历",fntTitle,bruBlack,new Rectangle(m_intLeft,intYPos,m_intLeft2-m_intLeft,m_intHeight),sf);
				sf.Alignment = StringAlignment.Far;
				e.Graphics.DrawString(clsFlawedRecord.m_intB.ToString(),fntTitle,bruBlack,new Rectangle(m_intLeft2,intYPos,m_intLeft3-m_intLeft2,m_intHeight),sf);
				flt = (float)clsFlawedRecord.m_intB/(float)clsFlawedRecord.m_intTotal*100;
				str = flt.ToString("00.0")+"%";
				if(str[0] == '0')
					str = str.Remove(0,1);
				e.Graphics.DrawString(str,fntTitle,bruBlack,new Rectangle(m_intLeft3,intYPos,m_intLeft+m_intWidth-m_intLeft3,m_intHeight),sf);
				m_mthPrintLine( e,ref intYPos,null,sf);

				if(intYPos < m_intBottom) intYPos = m_intBottom;
				else intYPos += 10;
				sf.Alignment = StringAlignment.Center;
				e.Graphics.DrawString("第 "+m_intPrintPage+" 页",fntTitle,bruBlack,new Rectangle(m_intLeft3,intYPos,120,m_intHeight),sf);
				e.HasMorePages = false;

				fntTitle.Dispose();
				bruBlack.Dispose();
				sf.Dispose();
			}
		}
		private void m_mthPrintLine(System.Drawing.Printing.PrintPageEventArgs e,ref int p_intYPos,clsFlawedRecord p_objFlawedRecord,StringFormat sf)
		{
			Pen penLine = new Pen(Color.Black);
			Font fntItem = new Font("宋体",15F);
			Brush bruBlack = new SolidBrush(Color.Black);
			if(p_objFlawedRecord != null)
			{
				SizeF sz = e.Graphics.MeasureString(p_objFlawedRecord.m_strText,fntItem,m_intLeft2-m_intLeft,sf);
				if(sz.Height > m_intHeight)
					fntItem = new Font("宋体",12F);
				sf.Alignment = StringAlignment.Near;
				e.Graphics.DrawString(p_objFlawedRecord.m_strText.Replace("★",""),fntItem,bruBlack,new Rectangle(m_intLeft,p_intYPos,m_intLeft2-m_intLeft,m_intHeight),sf);
				sf.Alignment = StringAlignment.Far;
				fntItem = new Font("宋体",15F);
				e.Graphics.DrawString(p_objFlawedRecord.m_intCount.ToString(),fntItem,bruBlack,new Rectangle(m_intLeft2,p_intYPos,m_intLeft3-m_intLeft2,m_intHeight),sf);
				e.Graphics.DrawString(p_objFlawedRecord.m_StrGetPercentString,fntItem,bruBlack,new Rectangle(m_intLeft3,p_intYPos,m_intLeft+m_intWidth-m_intLeft3,m_intHeight),sf);
			}
			e.Graphics.DrawLine(penLine,m_intLeft,p_intYPos,m_intLeft,p_intYPos+m_intHeight);
			e.Graphics.DrawLine(penLine,m_intLeft2,p_intYPos,m_intLeft2,p_intYPos+m_intHeight);
			e.Graphics.DrawLine(penLine,m_intLeft3,p_intYPos,m_intLeft3,p_intYPos+m_intHeight);
			e.Graphics.DrawLine(penLine,m_intLeft+m_intWidth,p_intYPos,m_intLeft+m_intWidth,p_intYPos+m_intHeight);
			p_intYPos+= m_intHeight;
			e.Graphics.DrawLine(penLine,m_intLeft,p_intYPos,m_intLeft+m_intWidth,p_intYPos);

			penLine.Dispose();
			fntItem.Dispose();
			bruBlack.Dispose();
		}
		internal void m_mthBeginPrint()
		{
			m_blnIsFirstPrint = true;
			m_intPrintIndex = 0;
			m_intPrintPage = 1;
		}
		#endregion Print
	}
	public class clsFlawedRecord
	{
		public static int m_intTotal = 0;
		public static int m_intA = 0;
		public static int m_intB = 0;
		public static int m_intC = 0;
		public clsFlawedRecord(string p_strText,int p_intCount)
		{
			m_strText = p_strText;
			m_intCount = p_intCount;
		}
		public string m_strText = "";
		public int m_intCount = 0;
		public float m_FltGetPercent
		{
			get
			{
				return (float)m_intCount/(float)m_intTotal;
			}
		}
		public string m_StrGetPercentString
		{
			get
			{
				float flt = m_FltGetPercent*100;
				string str = flt.ToString("00.0")+"%";
				if(str[0] == '0')
					str = str.Remove(0,1);
				return str;
			}
		}
	}
}
