using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlMedicine:药品信息列表控制类 Create by Sam 2004-5-24
	/// </summary>
	public class clsControlDayPlan:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlDayPlan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objDoMain=new clsDomainConrol_Plan();
		}
        clsDomainConrol_Plan m_objDoMain=null;
//		private bool IsSec=true; //不进行递归

		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmDayPlan m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			m_objViewer = (frmDayPlan)frmMDI_Child_Base_in;
		}
		#endregion

//		#region 填充科室树
//		public void GetDepTV()
//		{
//
//			System.Data.DataTable dt;
//			m_objDoMain.m_lngGetDep(out dt);
//			this.createTree(dt,"",null);
//			this.m_objViewer.m_TV.Nodes[0].Expand();
//		} 
//
//
//		public void createTree(System.Data.DataTable dt,string pId,TreeNode pNode) 
//		{
//			string tnId = ""; //节点id;
//			string tnName = ""; //节点Text;
//			string rootId = ""; //根节点id;
//			string rootName = ""; //根节点Text;
//			TreeNode tnRoot = null;
//			DataView dv = new DataView(dt);
//			//加入根节点
//			if (pId == "")
//			{
//				dv.RowFilter = "parentId='0'";
//				rootId = dv[0]["DEPTID_CHR"].ToString();
//				rootName = dv[0]["DEPTNAME_VCHR"].ToString();
//				tnRoot = new TreeNode(rootName);
//				tnRoot.Tag = rootId;
//				this.m_objViewer.m_TV.Nodes.Add(tnRoot);
//				//递归
//				this.createTree(dt,rootId,tnRoot);
//			}
//				//递归循环,加入根节点的所有子节点
//			else 
//			{
//				dv.RowFilter = "parentId='" + pId + "'";
//				foreach (DataRowView drv in dv) 
//				{
//					tnId = drv["DEPTID_CHR"].ToString();
//					tnName = drv["DEPTNAME_VCHR"].ToString();
//					TreeNode tn = new TreeNode(tnName);
//					tn.Tag = tnId;
//					pNode.Nodes.Add(tn);
//					this.createTree(dt,tnId,tn);
//				}
//			}
//		}
//			#endregion


		#region 填充科室树
		/// <summary>
		/// 用递归方法生成treeView
		/// </summary>
		public void fillDepartTree() 
		{
			System.Data.DataTable dt;
			m_objDoMain.m_lngGetDep(out dt);
			this.createTree(dt,"",null);
			this.m_objViewer.m_TV.Nodes[0].Expand();
		}
		public void createTree(System.Data.DataTable dt,string pId,TreeNode pNode) 
		{
			string tnId = ""; //节点id;
			string tnName = ""; //节点Text;
			string rootId = ""; //根节点id;
			string rootName = ""; //根节点Text;
			TreeNode tnRoot = null;
			DataView dv = new DataView(dt);
			//加入根节点
			if (pId == "")
			{
				dv.RowFilter = "parentId='0'";
				rootId = dv[0]["DEPTID_CHR"].ToString();
				rootName = dv[0]["DEPTNAME_VCHR"].ToString();
				tnRoot = new TreeNode(rootName);
				tnRoot.Tag = rootId;
				this.m_objViewer.m_TV.Nodes.Add(tnRoot);
				//递归
				this.createTree(dt,rootId,tnRoot);
			}
				//递归循环,加入根节点的所有子节点
			else 
			{
				dv.RowFilter = "parentId='" + pId + "'";
				foreach (DataRowView drv in dv) 
				{
					tnId = drv["DEPTID_CHR"].ToString();
					tnName = drv["DEPTNAME_VCHR"].ToString();
					TreeNode tn = new TreeNode(tnName);
					tn.Tag = tnId;
					pNode.Nodes.Add(tn);
					this.createTree(dt,tnId,tn);
				}
			}
		}
		#endregion 

		#region 删除项目
		public void m_lngDelPlan()
		{
			if(m_objViewer.m_lvwPlan.Items.Count==0 || m_objViewer.m_lvwPlan.SelectedItems.Count==0)
				return;
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo)==DialogResult.No)
				return;
			long lngRes=0;
			clsOPDoctorPlan_VO objResult=new clsOPDoctorPlan_VO();
			if(m_objViewer.m_lvwPlan.SelectedItems[0].Tag!=null)
				objResult=(clsOPDoctorPlan_VO)m_objViewer.m_lvwPlan.SelectedItems[0].Tag;
			else
				return;
			lngRes=m_objDoMain.m_lngDelDayPlan(objResult.m_strOPDrPlanID);
			if(lngRes>0)
			{
			   this.m_lngReMoveList();
			}
		}
		//从列表中移除
		public void m_lngReMoveList()
		{
           m_objViewer.m_lvwPlan.SelectedItems[0].Tag=null;
           m_objViewer.m_lvwPlan.Items.Remove(m_objViewer.m_lvwPlan.SelectedItems[0]);
		}
		#endregion

		//填充子结点
		
		private void m_FillTree(TreeNode Tr)
		{
			string strDepID=Tr.Tag.ToString();
			clsDepartmentVO[] objResultArr=null;
			long lngRes = m_objDoMain.m_lngGetChildDepList(strDepID,out objResultArr);

			if((lngRes>0)&&(objResultArr != null))
			{
				if (objResultArr.Length > 0)
				{
					TreeNode TrN=null;
					for(int i1=0; i1<objResultArr.Length;i1++)
					{
						TrN=new TreeNode(objResultArr[i1].strDeptName);
						TrN.Tag=objResultArr[i1].strDeptID;
						Tr.Nodes.Add(TrN);
					}
				}
			}
		}
		#region 取回科室当天的排班
		public void m_GetPlanByDepID()
		{
			clsOPDoctorPlan_VO[] objResultArr=null;
			m_objViewer.m_lvwPlan.Items.Clear();
			if(m_objViewer.m_TV.Nodes.Count==0)
				return;
            if(m_objViewer.m_TV.SelectedNode==null)
				return;
//			if(m_objViewer.m_TV.SelectedNode.Nodes.Count==0)
//			      this.m_FillTree(m_objViewer.m_TV.SelectedNode);
			string strDepID=m_objViewer.m_TV.SelectedNode.Tag.ToString();
			string strDate=m_objViewer.m_DTP.Value.ToShortDateString();
			long lngRes;
			if((string)m_objViewer.m_TV.SelectedNode.Tag=="0000001")
				lngRes = m_objDoMain.m_lngGetPlanByDateAndDepAll(strDate,out objResultArr);
			else
			   lngRes = m_objDoMain.m_lngGetDayPlan(strDate,strDepID,out objResultArr);

			if((lngRes>0)&&(objResultArr != null))
			{
				if (objResultArr.Length > 0)
				{
					ListViewItem lvw=null;
					int[] strArr=new int[objResultArr.Length];
					int f2=0;
					for(int i1=0; i1<objResultArr.Length;i1++)
					{
						if(objResultArr[i1].m_strPlanPeriod.Trim()=="晚上")
						{
							strArr[f2]=i1;
							f2++;
						}
						else
						{
							lvw=new ListViewItem(objResultArr[i1].m_objOPDept.strDeptName);
							lvw.SubItems.Add(objResultArr[i1].m_objOPDoctor.strEmpNO);
							lvw.SubItems.Add(objResultArr[i1].m_objOPDoctor.strName);
							lvw.SubItems.Add(objResultArr[i1].m_objRegisterType.m_strRegisterTypeName);
							lvw.SubItems.Add(objResultArr[i1].m_strPlanPeriod);
							lvw.SubItems.Add(objResultArr[i1].m_strStartTime);
							lvw.SubItems.Add(objResultArr[i1].m_strEndTime);
							lvw.SubItems.Add(objResultArr[i1].m_strOPAddress);
							lvw.SubItems.Add(objResultArr[i1].m_intMaxDiagTimes.ToString());	
							lvw.Tag=objResultArr[i1];
							m_objViewer.m_lvwPlan.Items.Add(lvw);
							switch(objResultArr[i1].m_strPlanPeriod.Trim())
							{
								case "上午":
									m_objViewer.m_lvwPlan.Items[i1-f2].BackColor=System.Drawing.Color.LightSeaGreen;
									break;
								case "下午":
									m_objViewer.m_lvwPlan.Items[i1-f2].BackColor=System.Drawing.Color.Tan;
									break; 
								case "全天":
									m_objViewer.m_lvwPlan.Items[i1-f2].BackColor=System.Drawing.Color.LightSalmon;
									break;
							}
							}
					}
					if(f2>0)
					{
						for(int h4=0;h4<f2;h4++)
						{
							lvw=new ListViewItem(objResultArr[h4].m_objOPDept.strDeptName);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_objOPDoctor.strEmpNO);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_objOPDoctor.strName);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_objRegisterType.m_strRegisterTypeName);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_strPlanPeriod);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_strStartTime);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_strEndTime);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_strOPAddress);
							lvw.SubItems.Add(objResultArr[strArr[h4]].m_intMaxDiagTimes.ToString());	
							lvw.Tag=objResultArr[strArr[h4]];
							m_objViewer.m_lvwPlan.Items.Add(lvw);
							m_objViewer.m_lvwPlan.Items[objResultArr.Length-f2+h4].BackColor=System.Drawing.Color.Orange;
						}
					}
				}
			}
		}
		#endregion
		public void m_SetItem(bool IsNew)
		{
			m_objViewer.Cursor=Cursors.WaitCursor;
			frmAddPlan frm=new frmAddPlan();
			if(m_objViewer.m_TV.Nodes.Count==0)
				return;
			if(m_objViewer.m_TV.SelectedNode==null)
				return;
			if (!IsNew)
			{
				if(m_objViewer.m_lvwPlan.Items.Count>0 && m_objViewer.m_lvwPlan.SelectedItems.Count>0)
					IsNew=false;
				else
					IsNew=true;
			}
			frm.ShowDayPlan(IsNew,this);
			m_objViewer.Cursor=Cursors.Default;
		}
		#region 刷新数据
		public void m_RefreshDate(bool IsNew,clsOPDoctorPlan_VO objResultArr)
		{
			if(IsNew)
			{
				if(objResultArr.m_strPlanPeriod.Trim()=="晚上")
				{
					ListViewItem lvw=new ListViewItem(objResultArr.m_objOPDept.strDeptName);
					lvw.SubItems.Add(objResultArr.m_objOPDoctor.strEmpNO);
					lvw.SubItems.Add(objResultArr.m_objOPDoctor.strName);
					lvw.SubItems.Add(objResultArr.m_objRegisterType.m_strRegisterTypeName);
					lvw.SubItems.Add(objResultArr.m_strPlanPeriod);
					lvw.SubItems.Add(objResultArr.m_strStartTime);
					lvw.SubItems.Add(objResultArr.m_strEndTime);
					lvw.SubItems.Add(objResultArr.m_strOPAddress);
					lvw.SubItems.Add(objResultArr.m_intMaxDiagTimes.ToString());	
					lvw.Tag=objResultArr;
					lvw.Selected=true;
					m_objViewer.m_lvwPlan.Items.Add(lvw);
					m_objViewer.m_lvwPlan.Items[m_objViewer.m_lvwPlan.Items.Count-1].BackColor=System.Drawing.Color.Orange;
				}
				else
				{
					for(int i1=0;i1<m_objViewer.m_lvwPlan.Items.Count;i1++)
					{

						if(objResultArr.m_strPlanPeriod.Trim()=="上午")
						{
							ListViewItem lvw=new ListViewItem(objResultArr.m_objOPDept.strDeptName);
							lvw.SubItems.Add(objResultArr.m_objOPDoctor.strEmpNO);
							lvw.SubItems.Add(objResultArr.m_objOPDoctor.strName);
							lvw.SubItems.Add(objResultArr.m_objRegisterType.m_strRegisterTypeName);
							lvw.SubItems.Add(objResultArr.m_strPlanPeriod);
							lvw.SubItems.Add(objResultArr.m_strStartTime);
							lvw.SubItems.Add(objResultArr.m_strEndTime);
							lvw.SubItems.Add(objResultArr.m_strOPAddress);
							lvw.SubItems.Add(objResultArr.m_intMaxDiagTimes.ToString());	
							lvw.Tag=objResultArr;
							m_objViewer.m_lvwPlan.Items.Insert(0,lvw);
							m_objViewer.m_lvwPlan.Items[0].BackColor=System.Drawing.Color.LightSeaGreen;
							return;
						}
						else
						{
							       if(m_objViewer.m_lvwPlan.Items[i1].SubItems[4].Text.Trim()=="下午")
									{
										ListViewItem lvw=new ListViewItem(objResultArr.m_objOPDept.strDeptName);
										lvw.SubItems.Add(objResultArr.m_objOPDoctor.strEmpNO);
										lvw.SubItems.Add(objResultArr.m_objOPDoctor.strName);
										lvw.SubItems.Add(objResultArr.m_objRegisterType.m_strRegisterTypeName);
										lvw.SubItems.Add(objResultArr.m_strPlanPeriod);
										lvw.SubItems.Add(objResultArr.m_strStartTime);
										lvw.SubItems.Add(objResultArr.m_strEndTime);
										lvw.SubItems.Add(objResultArr.m_strOPAddress);
										lvw.SubItems.Add(objResultArr.m_intMaxDiagTimes.ToString());	
										lvw.Tag=objResultArr;
										m_objViewer.m_lvwPlan.Items.Insert(i1,lvw);
										m_objViewer.m_lvwPlan.Items[i1].BackColor=System.Drawing.Color.Tan;
									   return;
									}
							}
							

						}
					ListViewItem lvw1=new ListViewItem(objResultArr.m_objOPDept.strDeptName);
					lvw1.SubItems.Add(objResultArr.m_objOPDoctor.strEmpNO);
					lvw1.SubItems.Add(objResultArr.m_objOPDoctor.strName);
					lvw1.SubItems.Add(objResultArr.m_objRegisterType.m_strRegisterTypeName);
					lvw1.SubItems.Add(objResultArr.m_strPlanPeriod);
					lvw1.SubItems.Add(objResultArr.m_strStartTime);
					lvw1.SubItems.Add(objResultArr.m_strEndTime);
					lvw1.SubItems.Add(objResultArr.m_strOPAddress);
					lvw1.SubItems.Add(objResultArr.m_intMaxDiagTimes.ToString());	
					lvw1.Tag=objResultArr;
					m_objViewer.m_lvwPlan.Items.Add(lvw1);
					if(m_objViewer.m_lvwPlan.Items.Count==1)
						m_objViewer.m_lvwPlan.Items[0].BackColor=System.Drawing.Color.Tan;
					else
						m_objViewer.m_lvwPlan.Items[m_objViewer.m_lvwPlan.Items.Count-1].BackColor=System.Drawing.Color.Tan;
				}

			}
			else
			{
				if(m_objViewer.m_lvwPlan.SelectedItems.Count>0)
				{
					m_objViewer.m_lvwPlan.SelectedItems[0].Text=objResultArr.m_objOPDept.strDeptName;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[1].Text=objResultArr.m_objOPDoctor.strEmpNO;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[2].Text=objResultArr.m_objOPDoctor.strName;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[3].Text=objResultArr.m_objRegisterType.m_strRegisterTypeName;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[4].Text=objResultArr.m_strPlanPeriod;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[5].Text=objResultArr.m_strStartTime;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[6].Text=objResultArr.m_strEndTime;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[7].Text=objResultArr.m_strOPAddress;
					m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[8].Text=objResultArr.m_intMaxDiagTimes.ToString();	
					m_objViewer.m_lvwPlan.SelectedItems[0].Tag=objResultArr;
					switch(objResultArr.m_strPlanPeriod)
					{
						case "上午":
							m_objViewer.m_lvwPlan.Items[m_objViewer.m_lvwPlan.SelectedItems[0].Index].BackColor=System.Drawing.Color.LightSeaGreen;
						    break;
						case "晚上":
							m_objViewer.m_lvwPlan.Items[m_objViewer.m_lvwPlan.SelectedItems[0].Index].BackColor=System.Drawing.Color.Orange;
							break;
						case "下午":
							m_objViewer.m_lvwPlan.Items[m_objViewer.m_lvwPlan.SelectedItems[0].Index].BackColor=System.Drawing.Color.Tan;
							break;

					}
				}
			}
		}
		#endregion
	}
}
