using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using System.Collections;
using System.Text;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_AccordRecipe 的摘要说明。
	/// </summary>
	public class clsCtl_AccordRecipe:com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_AccordRecipe objSvc=null;
		public clsCtl_AccordRecipe()
		{
			objSvc=new clsDcl_AccordRecipe();
			objArr=new System.Collections.ArrayList();
			m_mthLoadCat();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmAccordRecipe m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmAccordRecipe)frmMDI_Child_Base_in;
		}
		#endregion
		#region  选择主处方号
		DataTable m_dtAll =null;
		private bool m_mthSetMainItem(string str)
		{
			 bool ret =true;
			if(this.m_objViewer.listView2.Items.Count==0&&str=="")
			{
			return false;
			}
			for(int i=0;i<this.m_objViewer.listView2.Items.Count;i++)
			{
				if(str ==this.m_objViewer.listView2.Items[i].Text.Trim()||str=="")
				{
				ret =false;
				break;
				}	
			}
			return ret;
		}
		public void m_mthGetAccordRecipeDetail()
		{
			AccordRecipeTarget objTemp =this.m_objViewer.treeView1.Tag as AccordRecipeTarget;
			if(objTemp==null)
			{
				this.m_objViewer.Text ="门诊临床路径" + this.m_objViewer.HintMsg; 
				return ;
			}
			else
			{
                this.m_objViewer.Text = "门诊临床路径  " + objTemp.RECIPENAME_CHR + "  " + objTemp.USERCODE_CHR + "  " + objTemp.PYCODE_CHR + "  " + objTemp.WBCODE_CHR + this.m_objViewer.HintMsg; 
				if(objTemp.Remark.Length>74)
				{
					this.m_objViewer.txtRemark.ScrollBars=ScrollBars.Vertical;
				}
				else
				{
					this.m_objViewer.txtRemark.ScrollBars=ScrollBars.None;
				}
			this.m_objViewer.txtRemark.Text =objTemp.Remark;
			}
			long strRet =objSvc.m_mthGetAccordRecipeDetail(objTemp.RECIPEID_CHR,out m_dtAll);//查找并显示明细
			this.m_objViewer.m_dtMain.Rows.Clear();
			this.m_objViewer.listView2.Items.Clear();
			m_dtAll.Columns.Add("SubMoney");
			if( strRet>0&&m_dtAll.Rows.Count>0)
			{
				ListViewItem lv;
				double TolMoney = 0;
				double SubMoney = 0;
				for(int i =0;i<m_dtAll.Rows.Count;i++)
				{
//					lv=new ListViewItem(m_dt.Rows[i]["rowno_chr"].ToString().Trim());
					lv = new ListViewItem();
					lv.SubItems.Add(m_dtAll.Rows[i]["rowno_chr"].ToString().Trim());
					lv.SubItems.Add(m_dtAll.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());
					lv.SubItems.Add(m_dtAll.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());
					lv.SubItems.Add(m_dtAll.Rows[i]["QTY_DEC"].ToString().Trim());
					lv.SubItems.Add(m_dtAll.Rows[i]["FREQNAME_CHR"].ToString().Trim());
					lv.SubItems.Add(m_dtAll.Rows[i]["USAGENAME_VCHR"].ToString().Trim());
					string strTemp =m_mthRelationInfo(m_dtAll.Rows[i]["itemopinvtype_chr"].ToString());
					
					lv.Checked=true;
					if(strTemp == "0001"||strTemp == "0002")
					{	
						strTemp ="";
                        //if(m_dtAll.Rows[i]["NOQTYFLAG_INT"].ToString().Trim()!="0")
                        //{
                        //    lv.ForeColor =System.Drawing.Color.Red;
                        //    strTemp ="缺药";
                        //    lv.Checked=false;                            
                        //}
						if(m_dtAll.Rows[i]["IFSTOP_INT"].ToString().Trim()!="0")
						{
							lv.ForeColor =System.Drawing.Color.Gray;
							strTemp ="停用";
							lv.Checked=false;
						}
					}
					else
					{
						strTemp ="";
					}
					lv.SubItems.Add(strTemp);
					lv.SubItems.Add(m_dtAll.Rows[i]["ITEMID_CHR"].ToString().Trim());
					double money=0;
					try
					{
						money=double.Parse(m_dtAll.Rows[i]["itemprice_mny"].ToString())*double.Parse(m_dtAll.Rows[i]["QTY_DEC"].ToString());
						m_dtAll.Rows[i]["SubMoney"]=money.ToString();
					}
					catch
					{
						money=0;
					}

					TolMoney += money;
					if( lv.Checked )
					{
						SubMoney += money;	
					}

					lv.SubItems.Add(money.ToString().Trim());
					
					if(m_mthSetMainItem(m_dtAll.Rows[i]["rowno_chr"].ToString().Trim()))
					{
						lv.BackColor =System.Drawing.Color.FromArgb(((System.Byte)(250)), ((System.Byte)(255)), ((System.Byte)(200)));
					}
					else
					{
					lv.BackColor = System.Drawing.Color.White;
					}
					this.m_objViewer.listView2.Items.Add(lv);

//				DataRow dr=this.m_objViewer.m_dtMain.NewRow();
//				
//				dr[0]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
//				dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
//				dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
//				dr[3]=m_dt.Rows[i]["QTY_DEC"].ToString();
//				dr[4]=m_dt.Rows[i]["ITEMCATID_CHR"].ToString();
//				dr[5]=m_dt.Rows[i]["FREQNAME_CHR"].ToString();
//				dr[6]=m_dt.Rows[i]["USAGENAME_VCHR"].ToString();
//				dr[7]=true;
//				this.m_objViewer.m_dtMain.Rows.Add(dr);
				}
				this.m_objViewer.label2.Text = TolMoney.ToString() + " 元";
				this.m_objViewer.label3.Text = SubMoney.ToString() + " 元";
			}
		}
		#endregion
		
		#region 确认选择模板
		private System.Collections.ArrayList objArr;
		public void m_mthSelectTemp()
		{
			objArr.Clear();
			for(int i=0;i<this.m_objViewer.listView2.CheckedItems.Count;i++)
			{
                if (!this.m_objViewer.LackMedicine)
                {
                    if (this.m_objViewer.listView2.CheckedItems[i].SubItems[7].Text.Trim() == "缺药")
                    {
                        continue;
                    }
                }

                if (this.m_objViewer.listView2.CheckedItems[i].SubItems[7].Text.Trim() == "停用")
                {
                    continue;
                }                               

				objArr.Add(this.m_objViewer.listView2.CheckedItems[i].SubItems[8].Text.Trim()+this.m_objViewer.listView2.CheckedItems[i].SubItems[1].Text.Trim().PadLeft(5,'0'));				
			}
            ArrayList arrDele = new ArrayList();
            for (int i = 0; i < this.m_objViewer.listView2.Items.Count; i++)
			{
                if (this.m_objViewer.listView2.Items[i].Checked == false)
                {
                    arrDele.Add(i);
                }
                else
                {
                    if (!this.m_objViewer.LackMedicine)
                    {
                        if (this.m_objViewer.listView2.Items[i].SubItems[7].Text.Trim() == "缺药")
                        {                            
                            arrDele.Add(i);                          
                        }
                    }

                    if (this.m_objViewer.listView2.Items[i].SubItems[7].Text.Trim() == "停用")
                    {                        
                        arrDele.Add(i);                        
                    }                     
                }
			}
            if (arrDele.Count > 0)
            {
                for (int i1 = 0; i1 < arrDele.Count; i1++)
                {
                    m_dtAll.Rows[int.Parse(arrDele[i1].ToString())].Delete();                   
                }
                m_dtAll.AcceptChanges();
            }
																		 
			AccordRecipeTarget objTemp =this.m_objViewer.treeView1.Tag as AccordRecipeTarget;
			if(objTemp==null)
			{
			return;
			}
			string ID=objTemp.RECIPEID_CHR;
//			if(this.m_objViewer.listView1.SelectedItems.Count>0)
//			{
//				ID =this.m_objViewer.listView1.SelectedItems[0].SubItems[4].Text.Trim();
//
//			}
//			else
//			{
//			return;
//			}
			this.m_objViewer.GetTableAll=m_dtAll;
			this.m_mthFindOtherRecipeDetail(ID);
			this.m_mthFindWMRecipeDetail(ID);
			this.m_mthFindCMRecipeDetail(ID);
			this.m_objViewer.DialogResult=DialogResult.OK;
		}
		
		#region 查找西药处方明细
		private bool m_mthUnSelect(string strID,string strrow)
		{
			bool ret =false;
			if(objArr.IndexOf(strID+strrow.Trim().PadLeft(5,'0'))<0)
			{
			ret =true;
			}
			return ret;
		}
		private void m_mthFindWMRecipeDetail(string ID)
		{
			DataTable m_dt =null;
			long strRet =objSvc.m_mthFindWMRecipeDetail(ID,out m_dt);//查找并显示明细
			this.m_objViewer.dataTable1.Rows.Clear();
			if( strRet>0&&m_dt.Rows.Count>0)
			{
				for(int i =0;i<m_dt.Rows.Count;i++)
				{
					if(m_mthUnSelect(m_dt.Rows[i]["ITEMID_CHR"].ToString().Trim(),m_dt.Rows[i]["ROWNO_CHR"].ToString()))
					{
					continue;
					}
					DataRow dr=this.m_objViewer.dataTable1.NewRow();
					dr[0]=m_dt.Rows[i]["QTY_DEC"].ToString();
					dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
					dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
					dr[3]=m_dt.Rows[i]["DOSAGEUNIT_CHR"].ToString();
					dr[4]=m_dt.Rows[i]["SUBMONEY"].ToString();
					dr[5]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
					dr[6]=m_dt.Rows[i]["PACKQTY_DEC"].ToString();
					dr[7]=m_dt.Rows[i]["ITEMPRICE_MNY"].ToString();
					dr[8]=m_dt.Rows[i]["opchargeflg_int"].ToString();
					dr[9]=m_dt.Rows[i]["DOSETYPE_CHR"].ToString();
					dr[10]=m_dt.Rows[i]["USAGENAME_VCHR"].ToString();
					dr[11]=m_dt.Rows[i]["FREQID_CHR"].ToString();
					dr[12]=m_dt.Rows[i]["FREQNAME_CHR"].ToString();
					dr[13]=m_dt.Rows[i]["TIMES_INT"].ToString();
					dr[14]=m_dt.Rows[i]["DAYS_INT"].ToString();//频率天数
					dr[15]=m_dt.Rows[i]["ITEMIPUNIT_CHR"].ToString();//小单位
					dr[16]=m_dt.Rows[i]["ITEMOPUNIT_CHR"].ToString();//大单位
					dr[17]=m_dt.Rows[i]["DOSAGEQTY_DEC"].ToString();//剂量
					dr[18]=m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString();//发票分类
					dr[19]=m_dt.Rows[i]["DOSAGE_DEC"].ToString();//剂量比例
					dr[20]=m_dt.Rows[i]["Days"].ToString();//天数
					dr[21]=m_dt.Rows[i]["ITEMCODE_VCHR"].ToString();//编号
					dr[22]=m_dt.Rows[i]["itemengname_vchr"].ToString();//英文名
					dr[23]=m_dt.Rows[i]["ROWNO_CHR"].ToString();
					dr[24]=m_dt.Rows[i]["hype_int"].ToString();//皮试标志
                    dr[25] = m_dt.Rows[i]["deptprep_int"].ToString();//科备标志
					this.m_objViewer.dataTable1.Rows.Add(dr);
				}
			}
		}
		#endregion
		#region 查找中药处方明细
		private void m_mthFindCMRecipeDetail(string ID)
		{
			DataTable m_dt =null;
			long strRet =objSvc.m_mthFindCMRecipeDetail(ID,out m_dt);//查找并显示明细
			this.m_objViewer.dataTable2.Rows.Clear();
			if( strRet>0&&m_dt.Rows.Count>0)
			{
				for(int i =0;i<m_dt.Rows.Count;i++)
				{
					if(m_mthUnSelect(m_dt.Rows[i]["ITEMID_CHR"].ToString().Trim(),m_dt.Rows[i]["ROWNO_CHR"].ToString()))
					{
						continue;
					}
					DataRow dr=this.m_objViewer.dataTable2.NewRow();
					dr[0]=m_dt.Rows[i]["QTY_DEC"].ToString();
					dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
					dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
					dr[3]=m_dt.Rows[i]["DOSAGEUNIT_CHR"].ToString();
					dr[4]=m_dt.Rows[i]["SUBMONEY"].ToString();
					dr[5]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
					dr[6]=m_dt.Rows[i]["PACKQTY_DEC"].ToString();
					dr[7]=m_dt.Rows[i]["ITEMPRICE_MNY"].ToString();
					dr[8]=m_dt.Rows[i]["opchargeflg_int"].ToString();
					dr[9]=m_dt.Rows[i]["DOSETYPE_CHR"].ToString();
					dr[10]=m_dt.Rows[i]["dosage_dec"].ToString();
					dr[11]=m_dt.Rows[i]["DOSAGEQTY_DEC"].ToString();//剂量
					dr[12]=m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString();//发票分类
					dr[13]=m_dt.Rows[i]["DOSETYPE_CHR"].ToString();//用法ID
					dr[14]=m_dt.Rows[i]["USAGENAME_VCHR"].ToString();//用法名称
					dr[15]=m_dt.Rows[i]["ITEMCODE_VCHR"].ToString();//编号
					dr[16]=m_dt.Rows[i]["itemengname_vchr"].ToString();//英文名
                    dr[17] = m_dt.Rows[i]["deptprep_int"].ToString();//科备标志
					this.m_objViewer.dataTable2.Rows.Add(dr);
				}
			}
		}
		#endregion
		#region 查找其他处方明细
		private void m_mthFindOtherRecipeDetail(string ID)
		{
			DataTable m_dt =null;
			long strRet =objSvc.m_mthFindOtherRecipeDetail(ID,out m_dt);//查找并显示明细
			this.m_objViewer.dataTable2.Rows.Clear();
			this.m_objViewer.dataTable3.Rows.Clear();
			this.m_objViewer.dataTable4.Rows.Clear();
			this.m_objViewer.dataTable5.Rows.Clear();
			this.m_objViewer.dataTable6.Rows.Clear();
			if( strRet>0&&m_dt.Rows.Count>0)
			{
				for(int i =0;i<m_dt.Rows.Count;i++)
				{
					DataRow dr=null;
					if(m_mthUnSelect(m_dt.Rows[i]["ITEMID_CHR"].ToString().Trim(),m_dt.Rows[i]["ROWNO_CHR"].ToString()))
					{
						continue;
					}
					switch(m_mthRelationInfo(m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()))
					{
						case "0003"://检验
							 dr=this.m_objViewer.dataTable3.NewRow();
							dr[0]=m_dt.Rows[i]["QTY_DEC"].ToString();
							dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
							dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
							dr[3]=m_dt.Rows[i]["ITEMUNIT_CHR"].ToString();
							dr[4]=m_dt.Rows[i]["ITEMPRICE_MNY"].ToString();
							dr[5]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
							dr[6]=m_dt.Rows[i]["SELFDEFINE_INT"].ToString();
							dr[7]=m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString();//发票分类
							dr[8]=m_dt.Rows[i]["ITEMCODE_VCHR"].ToString();//编号
							dr[9]=m_dt.Rows[i]["itemengname_vchr"].ToString();//英文名
//							dr[10]=m_dt.Rows[i]["SAMPLE_TYPE_DESC_VCHR"].ToString();//样本类型
//							dr[11]=m_dt.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString();//样本类型ID
							dr[11]=m_dt.Rows[i]["PARTORTYPE_VCHR"].ToString();//样本类型
							dr[10]=m_dt.Rows[i]["PARTORTYPENAME_VCHR"].ToString();//样本类型ID
							this.m_objViewer.dataTable3.Rows.Add(dr);
							break;
						case "0004"://治疗
							 dr=this.m_objViewer.dataTable4.NewRow();
							dr[0]=m_dt.Rows[i]["QTY_DEC"].ToString();
							dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
							dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
							dr[3]=m_dt.Rows[i]["ITEMUNIT_CHR"].ToString();
							dr[4]=m_dt.Rows[i]["ITEMPRICE_MNY"].ToString();
							dr[5]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
							dr[6]=m_dt.Rows[i]["SELFDEFINE_INT"].ToString();
							dr[7]=m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString();//发票分类
							dr[8]=m_dt.Rows[i]["ITEMCODE_VCHR"].ToString();//编号
							dr[9]=m_dt.Rows[i]["itemengname_vchr"].ToString();//英文名							
							dr[10]=m_dt.Rows[i]["PARTORTYPENAME_VCHR"].ToString();//部位ID
                            dr[11] = m_dt.Rows[i]["PARTORTYPE_VCHR"].ToString();//部位名称
							dr[12] = m_dt.Rows[i]["usageid_chr"].ToString(); //用法ID
							this.m_objViewer.dataTable4.Rows.Add(dr);
							break;
						case "0006"://手术
							 dr=this.m_objViewer.dataTable5.NewRow();
							dr[0]=m_dt.Rows[i]["QTY_DEC"].ToString();
							dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
							dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
							dr[3]=m_dt.Rows[i]["ITEMUNIT_CHR"].ToString();
							dr[4]=m_dt.Rows[i]["ITEMPRICE_MNY"].ToString();
							dr[5]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
							dr[6]=m_dt.Rows[i]["SELFDEFINE_INT"].ToString();
							dr[7]=m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString();//发票分类
							dr[8]=m_dt.Rows[i]["ITEMCODE_VCHR"].ToString();//编号
							dr[9]=m_dt.Rows[i]["itemengname_vchr"].ToString();//英文名
                            dr[10] = m_dt.Rows[i]["usageid_chr"].ToString(); //用法ID
							this.m_objViewer.dataTable5.Rows.Add(dr);
							break;
						default://其他
							dr=this.m_objViewer.dataTable6.NewRow();
							dr[0]=m_dt.Rows[i]["QTY_DEC"].ToString();
							dr[1]=m_dt.Rows[i]["ITEMNAME_VCHR"].ToString();
							dr[2]=m_dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
							dr[3]=m_dt.Rows[i]["ITEMUNIT_CHR"].ToString();
							dr[4]=m_dt.Rows[i]["ITEMPRICE_MNY"].ToString();
							dr[5]=m_dt.Rows[i]["ITEMID_CHR"].ToString();
							dr[6]=m_dt.Rows[i]["SELFDEFINE_INT"].ToString();
							dr[7]=m_dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString();//发票分类
							dr[8]=m_dt.Rows[i]["ITEMCODE_VCHR"].ToString();//编号
							dr[9]=m_dt.Rows[i]["itemengname_vchr"].ToString();//英文名
                            dr[10] = m_dt.Rows[i]["deptprep_int"].ToString();//科备标志
							this.m_objViewer.dataTable6.Rows.Add(dr);
							break;
					
					}
					
					}
			}
		}
		#endregion
		#endregion
		#region 加载项目分类
		public void m_mthLoadCat()
		{
			clsDcl_DoctorWorkstation clsDomain=new clsDcl_DoctorWorkstation();
			
			long l=clsDomain.m_mthRelationInfo(out this.dt_RelationInfo);
			if(l<0)
			{
				MessageBox.Show("加载关系表失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion
		#region 查找对应表信息
		private DataTable dt_RelationInfo;
		private string m_mthRelationInfo(string strCatID)
		{
			string str="0005";//默认其他
			for(int i=0;i<this.dt_RelationInfo.Rows.Count;i++)
			{
				if(strCatID==this.dt_RelationInfo.Rows[i]["CATID_CHR"].ToString().Trim())
				{
					str=this.dt_RelationInfo.Rows[i]["GROUPID_CHR"].ToString().Trim();
					break;
				}
			}
			return str;
		}
		#endregion
		#region 查找主处方列表
		public void m_mthFindAccordRecipe(int p_flag)
		{
			clsDcl_DoctorWorkstation objDW =new clsDcl_DoctorWorkstation();
			DataTable m_dt;
			long strRet=objDW.m_mthFindAccordRecipe(this.m_objViewer.txtFind.Tag.ToString()+this.m_objViewer.txtFind.Text.Trim(),this.m_objViewer.cmbFind.Tag.ToString(),this.m_objViewer.LoginInfo.m_strEmpID,out m_dt,p_flag);
			this.m_objViewer.treeView1.BeginUpdate();
			this.m_objViewer.treeView1.Nodes.Clear();
			if(strRet>0&&m_dt.Rows.Count>0)
			{
				ArrayList objArrayList =new ArrayList();
				for(int i=0;i<m_dt.Rows.Count;i++)
				{
					AccordRecipeTarget oTemp =new AccordRecipeTarget();
					oTemp.PYCODE_CHR =m_dt.Rows[i]["PYCODE_CHR"].ToString().Trim();
					oTemp.RECIPEID_CHR =m_dt.Rows[i]["RECIPEID_CHR"].ToString().Trim();
					oTemp.RECIPENAME_CHR =m_dt.Rows[i]["RECIPENAME_CHR"].ToString().Trim();
					oTemp.USERCODE_CHR =m_dt.Rows[i]["USERCODE_CHR"].ToString().Trim();
					oTemp.WBCODE_CHR =m_dt.Rows[i]["WBCODE_CHR"].ToString().Trim();
					oTemp.Remark =m_dt.Rows[i]["DISEASENAME_VCHR"].ToString().Trim();
					objArrayList.Add(oTemp);
				}
			
				objArrayList.Sort();
                int intCount =0;
				TreeNode FirstNode=null;
				this.m_objViewer.treeView1.Nodes.Add("模板列表");
				TreeNode FindNode=this.m_objViewer.treeView1.Nodes[0];
				bool blnIsExists=false;//默认当前要添加的节点不存在
				foreach(AccordRecipeTarget objTemplateInfo in objArrayList)
				{
					FindNode=this.m_objViewer.treeView1.Nodes[0];
					string[] strSplitArry=objTemplateInfo.strArr;
					for (int j=0;j<strSplitArry.Length;j++)
					{
						blnIsExists=false;
						for(int i2 =0;i2<FindNode.Nodes.Count;i2++)
						{
							if(strSplitArry[j]==FindNode.Nodes[i2].Text)
							{
								blnIsExists =true;//找到
								FindNode =FindNode.Nodes[i2];
								break;
							}
						}
						if(blnIsExists)//找到
						{
							if(j==strSplitArry.Length-1)
							{
								TreeNode trAdd =new TreeNode(strSplitArry[j].Trim());
								FindNode.Parent.Nodes.Add(trAdd);
								trAdd.Tag=objTemplateInfo;
								trAdd.ImageIndex =2;
								trAdd.SelectedImageIndex =2;
							}
							continue;
						}
						else//找不到增加一个节点
						{
							TreeNode trAdd =new TreeNode(strSplitArry[j].Trim());
							FindNode.Nodes.Add(trAdd);
							if(j==strSplitArry.Length-1)
							{
								trAdd.Tag=objTemplateInfo;
								trAdd.ImageIndex =2;
								trAdd.SelectedImageIndex =2;
								if(intCount==0)
								{
									FirstNode =trAdd;
									intCount++;
								}
							}
							FindNode =trAdd;
						}
					}
				}

			this.m_objViewer.treeView1.EndUpdate();
			this.m_objViewer.treeView1.SelectedNode =FirstNode;
				
			}
		}

		private class AccordRecipeTarget:IComparable
		{
			public string USERCODE_CHR;
			/// <summary>
			/// 模板名称
			/// </summary>
			public string RECIPENAME_CHR
			{
				set
				{
					strArr =value.Replace(">>","-").Split('-');
					strName =strArr[strArr.Length-1];
					StringBuilder sb =new StringBuilder();
					for(int i=0;i<strArr.Length;i++)
					{
						sb.Append(strArr[i]);
					}
					strIndexID =sb.ToString();
				}
				get
				{
				return strName;
				}
			}
			public string PYCODE_CHR;
			public string WBCODE_CHR;
			public string Remark;
			/// <summary>
			/// ID
			/// </summary>
			public string RECIPEID_CHR;
			private string strName;
			public string strIndexID;
			/// <summary>
			/// 组别层
			/// </summary>
			public string[] strArr; 
			public override string ToString()
			{
//				string ret ="";
//				char [] charArr =new char[2];
//				charArr[0]='-';
//				charArr[1]='>';
//				string[] strArr =RECIPENAME_CHR.Split(charArr,3);
//				if(strArr.Length>1)
//				{
//					ret =strArr[0];
//					if(strArr.Length>2)
//					{
//						strName=strArr[2]+strArr[2]; 
//					}
//					else
//					{
//						strName=strArr[1]; 
//					}
//				}
				return strName;
			}
			#region IComparable 成员

			public int CompareTo(object obj)
			{
				AccordRecipeTarget objTemp =obj as AccordRecipeTarget;
				return this.strIndexID.CompareTo(objTemp.strIndexID);
			}

			#endregion
		}
		#endregion

		#region 动态显示金额
		/// <summary>
		/// 动态显示金额
		/// </summary>
		/// <param name="CurrentRow"></param>
		public void m_mthComputeSum(int CurrentRow)
		{
			if(this.m_objViewer.listView2.Items.Count > 0)
			{                   
				double SumMoney = 0;

				for(int i=0; i<this.m_objViewer.listView2.Items.Count; i++)
				{
					if(this.m_objViewer.listView2.Items[i].Checked)
					{
						SumMoney += Double.Parse(this.m_objViewer.listView2.Items[i].SubItems[9].Text);
					}					
				}

				//全选或反选 999
				if(CurrentRow != 999)
				{                    
                    if (this.m_objViewer.listView2.Items[CurrentRow].Checked)
                        SumMoney -= Double.Parse(this.m_objViewer.listView2.Items[CurrentRow].SubItems[9].Text);
                    else
                        SumMoney += Double.Parse(this.m_objViewer.listView2.Items[CurrentRow].SubItems[9].Text);                    
				}

				this.m_objViewer.label3.Text = SumMoney.ToString() + " 元";
			}
		}
		#endregion

	}
}
