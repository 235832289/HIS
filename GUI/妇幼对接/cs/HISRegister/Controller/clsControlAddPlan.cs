using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 维护排班计划 Create by Sam 2004-6-4
	/// </summary>
	public class clsControlAddPlan:com.digitalwave.GUI_Base.clsController_Base
	{
		public  clsControlAddPlan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objDoMain=new clsDomainConrol_Plan();
            clsController_Security clsSec=new clsController_Security();
			strOperatorID=clsSec.objGetCurrentLoginEmployee().strEmpID;
		}
		clsDomainConrol_Plan m_objDoMain=null;
		bool IsNew=true;
		bool IsDayPlan=true;//是日计划
//		bool IsSec=true; //不进行递归
		string SaveDepID="";//要保存的科室
		string SavePlanID="";//计划号
		string SaveDate=DateTime.Now.ToShortDateString();//日期
		string SaveWeek="1";
		string strOperatorID="";
		clsControlDayPlan clsDay;
		clsControlWeekPlan clsWeek;


		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmAddPlan m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmAddPlan)frmMDI_Child_Base_in;
		}
		#endregion

		#region 变量
		/// <summary>
		/// 保存部门信息资料
		/// </summary>
		DataTable dtbResultArr=null;
		/// <summary>
		/// 保存员工信息资料
		/// </summary>
		clsEmployeeVO[] dtbResultEmp=new clsEmployeeVO[0];

		#endregion

		#region 填充科室树
		public void GetDepTV()
		{
			clsDepartmentVO[] objResultArr=null;
			long lngRes=0;
			m_objViewer.m_TVDep.Nodes.Clear();
			//取得父结点
			for(int i=1;i<3;i++)
			{
				lngRes =0;
//					m_objDoMain.m_lngGetDepList(out objResultArr);

				if((lngRes>0)&&(objResultArr != null))
				{
					if (objResultArr.Length > 0)
					{
						TreeNode TrN=null;
									
						for(int i1=0; i1<objResultArr.Length;i1++)
						{

							TrN = new TreeNode(objResultArr[i1].strDeptName);
							TrN.Tag=objResultArr[i1].strDeptID;
							m_objViewer.m_TVDep.Nodes.Add(TrN);
						}
						break;
					}
				}
			}
//			if(m_objViewer.m_TVDep.Nodes.Count==0)
//				return;
//			//填充子结点
//			foreach (TreeNode tn in m_objViewer.m_TVDep.Nodes)
//			{
//				string strDepID=tn.Tag.ToString();
//				IsSec=false;
//				this.m_FillTree(strDepID,tn);
//			}
		} 
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
//						if(IsSec==false)
//						{
//							lngRes = m_objDoMain.m_lngGetChildDepList(strDepID,out objResultArr);
//							if (objResultArr.Length > 0)//如果还有子科室
//								IsSec=false; //继续循环
//							else
//								IsSec=true;
//							this.m_FillTree(objResultArr[i1].strDeptID,TrN);
//						}
					}
				}
			}
		}
		#endregion

		#region 取得科室的医生
		public void m_GetDocByDepID()
		{
			clsEmployeeVO[] objResultArr=null;
			m_objViewer.m_lvwDoc.Items.Clear();
			if(m_objViewer.m_TVDep.Nodes.Count==0)
				return;
			if(m_objViewer.m_TVDep.SelectedNode==null)
				return;
			if(m_objViewer.m_TVDep.SelectedNode.Nodes.Count==0)
				this.m_FillTree(m_objViewer.m_TVDep.SelectedNode);
			string strDepID=m_objViewer.m_TVDep.SelectedNode.Tag.ToString();
			long lngRes = m_objDoMain.m_lngGetDocByDepID(strDepID,out objResultArr);

			if((lngRes>0)&&(objResultArr != null))
			{
				if (objResultArr.Length > 0)
				{
					ListViewItem lvw=null;
					for(int i1=0; i1<objResultArr.Length;i1++)
					{
						lvw=new ListViewItem(objResultArr[i1].strEmpID);
						lvw.SubItems.Add(objResultArr[i1].strName);
						m_objViewer.m_lvwDoc.Items.Add(lvw);
					}
				}
			}
		}
		#endregion
		
		#region 填充门诊类型和时段
		/// <summary>
		/// 填充门诊类型和时段
		/// </summary>
		public void m_FillRegType()
		{
			clsRegisterType_VO[] objResultArr=null;
			long lngRes = m_objDoMain.m_lngGetRegType(out objResultArr);
            m_objViewer.m_cboPerio.Items.Clear();
			m_objViewer.m_cboRegType.Items.Clear();
			if((lngRes>0)&&(objResultArr != null))
			{
				for(int i1=0; i1<objResultArr.Length;i1++)
				{
					m_objViewer.m_cboRegType.Items.Add(objResultArr[i1].m_strRegisterTypeName);
				}
			    m_objViewer.m_cboRegType.Tag=objResultArr;	
			}
               m_objViewer.m_cboPerio.Items.Add("上午");
			   m_objViewer.m_cboPerio.Items.Add("下午");
			   m_objViewer.m_cboPerio.Items.Add("晚上");
			   m_objViewer.m_cboPerio.Items.Add("全天");
		}
		#endregion
		
		#region 清空
		public void m_Clear()
		{
			this.IsNew=true;
			m_objViewer.m_cboPerio.SelectedIndex=-1;
			m_objViewer.m_cboPerio.Text="";
			m_objViewer.m_cboRegType.SelectedIndex=-1;
			m_objViewer.m_cboRegType.Text="";
			m_objViewer.m_txtDoc.Text="";
			m_objViewer.m_txtDoc.Tag=null;
			m_objViewer.m_txtNum.Text="";
			m_objViewer.m_txtRoom.Text="";
			m_objViewer.m_txtDoc.Enabled=true;
//			m_objViewer.txtOpdt.Clear();
			m_objViewer.txtOpdt.Focus();
		}
		#endregion

		#region 保存
		public long m_lngSave()
		{
			if(!this.m_bolCheckValuePass())
				return -1;
            clsOPDoctorPlan_VO objDayPlan=null;
			clsOPDoctorWkPlan_VO objWeekPlan=null;
			string strPlanID="";
			long lngRes=0;
			if(this.IsNew) //新增
			{
				if(this.IsDayPlan)
				{
					this.ChangeDayVO(out objDayPlan);
					lngRes=m_objDoMain.m_lngAddDayPlan(objDayPlan,out strPlanID);
					objDayPlan.m_strOPDrPlanID=strPlanID;
				}
				else
				{
					this.ChangeWeekVO(out objWeekPlan);
					lngRes=m_objDoMain.m_lngAddWeekPlan(objWeekPlan,out strPlanID);
					objWeekPlan.m_strOPDrWkPlanID=strPlanID;
				}
			}
			else
			{
				if(this.IsDayPlan)
				{
					this.ChangeDayVO(out objDayPlan);
					lngRes=m_objDoMain.m_lngUPDateDayPlan(objDayPlan);
				}
				else
				{
					this.ChangeWeekVO(out objWeekPlan);
					lngRes=m_objDoMain.m_lngUPDateWeekPlan(objWeekPlan);
				}
			}
			if(lngRes>0)
			{
				if(this.IsNew)
				{
					this.m_Clear();
				}
				else
				{
					m_objViewer.Close();
				}
				if (this.IsDayPlan)
					this.clsDay.m_RefreshDate(IsNew,objDayPlan);
				else
				{
//					for(int i1=0;i1<clsWeek.m_objViewer.m_TV.Nodes.Count;i1++)
//					{
//						if(this.clsWeek.m_objViewer.m_TV.Nodes[i1].Tag.ToString()==objWeekPlan.m_objOPDept.strDeptID)
//						{
//						    clsWeek.m_objViewer.m_TV.SelectedNode=clsWeek.m_objViewer.m_TV.Nodes[5];
							this.clsWeek.m_RefreshDate(IsNew,objWeekPlan);
//						}

//					}
				}

			}
			else
				MessageBox.Show("保存失败","提示");
			return lngRes;
		}
		private void ChangeDayVO(out clsOPDoctorPlan_VO objResult)
		{
			objResult=new clsOPDoctorPlan_VO();
			objResult.m_objOPDept=new clsDepartmentVO();
			objResult.m_objOPDept.strDeptID=(string)this.m_objViewer.txtOpdt.Tag;
			objResult.m_objOPDept.strDeptName=this.m_objViewer.txtOpdt.Text.Trim();
			objResult.m_intMaxDiagTimes=int.Parse(clsMain.IsNullToString(m_objViewer.m_txtNum.Text,"0"));
			objResult.m_objOPDoctor=new clsEmployeeVO();
			objResult.m_objOPDoctor.strEmpID=m_objViewer.m_txtDoc.Tag.ToString();
            objResult.m_objOPDoctor.strName=m_objViewer.m_txtDoc.Text;
		     objResult.m_objOPDoctor.strEmpNO=m_objViewer.m_txtNum.Tag.ToString();
			if(m_objViewer.m_cboRegType.Tag!=null)
			{
				objResult.m_objRegisterType=new clsRegisterType_VO();
				objResult.m_objRegisterType.m_strRegisterTypeName=m_objViewer.m_cboRegType.Text;
				objResult.m_objRegisterType.m_strRegisterTypeID=
					((clsRegisterType_VO[])m_objViewer.m_cboRegType.Tag)[m_objViewer.m_cboRegType.SelectedIndex].m_strRegisterTypeID;
			}
			objResult.m_strEndTime=m_objViewer.m_DtpEnd.Value.ToShortTimeString();
			objResult.m_strPlanDate=this.SaveDate;
			objResult.m_strPlanPeriod=m_objViewer.m_cboPerio.Text;
			objResult.m_strStartTime=m_objViewer.m_DtpStart.Value.ToShortTimeString();
			objResult.m_objRecordEmp=new clsEmployeeVO();
			objResult.m_objRecordEmp.strEmpID=this.strOperatorID;
			objResult.m_strOPDrPlanID=this.SavePlanID;
			objResult.m_strOPAddress=m_objViewer.m_txtRoom.Text;
		}
		private void ChangeWeekVO(out clsOPDoctorWkPlan_VO objResult)
		{
			objResult=new clsOPDoctorWkPlan_VO();
			objResult.m_objOPDept=new clsDepartmentVO();
			objResult.m_objOPDept.strDeptID=(string)this.m_objViewer.txtOpdt.Tag;
			objResult.m_objOPDept.strDeptName=this.m_objViewer.txtOpdt.Text.Trim();
			objResult.m_intMaxDiagTimes=int.Parse(clsMain.IsNullToString(m_objViewer.m_txtNum.Text,"0"));
			objResult.m_objOPDoctor=new clsEmployeeVO();
			objResult.m_objOPDoctor.strEmpID=m_objViewer.m_txtDoc.Tag.ToString();
			 objResult.m_objOPDoctor.strEmpNO=m_objViewer.m_txtNum.Tag.ToString();
			objResult.m_objOPDoctor.strName=m_objViewer.m_txtDoc.Text;
			if(m_objViewer.m_cboRegType.Tag!=null)
			{
				objResult.m_objRegisterType=new clsRegisterType_VO();
				objResult.m_objRegisterType.m_strRegisterTypeName=m_objViewer.m_cboRegType.Text;
				objResult.m_objRegisterType.m_strRegisterTypeID=
					((clsRegisterType_VO[])m_objViewer.m_cboRegType.Tag)[m_objViewer.m_cboRegType.SelectedIndex].m_strRegisterTypeID;
			}
			objResult.m_strEndTime=m_objViewer.m_DtpEnd.Value.ToShortTimeString();
			objResult.m_strPlanWeek=this.SaveWeek;
			objResult.m_strPlanPeriod=m_objViewer.m_cboPerio.Text;
			objResult.m_strStartTime=m_objViewer.m_DtpStart.Value.ToShortTimeString();
			objResult.m_objRecordEmp=new clsEmployeeVO();
			objResult.m_objRecordEmp.strEmpID=this.strOperatorID;
			objResult.m_strOPDrWkPlanID=this.SavePlanID;
			objResult.m_strOPAddress=m_objViewer.m_txtRoom.Text;
		}
		#endregion

		#region 校验输入值
		/// <summary>
		/// 校验输入值
		/// </summary>
		/// <returns></returns>
		private bool m_bolCheckValuePass()
		{
			bool bolReturn = true;

			if(m_objViewer.m_txtDoc.Text.Trim() == "")
			{
//				m_ephHandler.m_mthAddControl(m_objViewer.m_txtDoc);
				m_objViewer.errorProvider1.SetError(m_objViewer.m_txtDoc,"选择医生");
				bolReturn = false;
			}

			if(m_objViewer.m_cboRegType.SelectedIndex<0)
			{
				//m_ephHandler.m_mthAddControl(m_objViewer.m_cboRegType);
				m_objViewer.errorProvider1.SetError(m_objViewer.m_cboRegType,"选择类型");
				bolReturn = false;
			}

			if(m_objViewer.m_cboPerio.SelectedIndex<0)
			{
				//m_ephHandler.m_mthAddControl(m_objViewer.m_cboPerio);
				m_objViewer.errorProvider1.SetError(m_objViewer.m_cboPerio,"选择时段");
				bolReturn = false;
			}

			if(m_objViewer.m_DtpStart.Value>m_objViewer.m_DtpEnd.Value)
			{
				m_objViewer.errorProvider1.SetError(m_objViewer.m_DtpStart,"开诊时间不能大于结束时间");
				bolReturn = false;
			}
			if(!bolReturn)
			{
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
                return bolReturn;
			}
			if(this.IsNew)
			{
				if(this.m_bolExist())
					return false;
			}
			return bolReturn;
		}
		#endregion

		#region 校验是否存在计划 
		/// <summary>
		/// 校验是否存在计划
		/// </summary>
		/// <returns></returns>
		private bool m_bolExist()
		{
		   long lngRes=0;
		   clsOPDoctorPlan_VO objDay=new clsOPDoctorPlan_VO();
           clsOPDoctorWkPlan_VO objWeek=new clsOPDoctorWkPlan_VO();
			if(this.IsDayPlan)
			{
				lngRes=m_objDoMain.m_lngCheckDayPlan(this.SaveDate,m_objViewer.m_cboPerio.Text,
					m_objViewer.m_txtDoc.Tag.ToString(),out objDay);
				if(lngRes>0)
				{
					if(clsMain.IsNullToString(objDay.m_strOPDrPlanID,null)!="")
					{
						MessageBox.Show("该医生在该时间段已排班于 " +objDay.m_objOPDept.strDeptName+" ，请重新选择！","提示");
						return true;
					}
				}
				else 
					return false;
			}
			else
			{
				lngRes=m_objDoMain.m_lngCheckWeekPlan(this.SaveWeek,m_objViewer.m_cboPerio.Text,
					m_objViewer.m_txtDoc.Tag.ToString(),out objWeek);
				if(lngRes>0)
				{
					if(clsMain.IsNullToString(objWeek.m_strOPDrWkPlanID,null)!="")
					{
						MessageBox.Show("该医生在该时间段已排班于 " +objWeek.m_objOPDept.strDeptName+" ，请重新选择！","提示");
						return true;
					}
				}
				else 
					return false;
			}
		   return false;
		}
		#endregion

		public void ShowDayPlan(bool IsNew,clsControlDayPlan clsObject)
		{
			this.clsDay=clsObject;
			IsDayPlan=true;
			clsOPDoctorPlan_VO objPlan=null;
			clsRegisterType_VO[] clsRegType=null;
			this.IsNew=IsNew;
			SaveDate=clsObject.m_objViewer.m_DTP.Value.ToShortDateString();
			SaveDepID=clsObject.m_objViewer.m_TV.SelectedNode.Tag.ToString();
			if(!IsNew)
			{
				if((string)clsObject.m_objViewer.m_TV.SelectedNode.Tag!="0000001")
				{
					this.m_objViewer.txtOpdt.Enabled=false;
				}
				m_objViewer.m_txtDoc.Enabled=false;
				if(clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].Tag!=null)
				{
					objPlan=(clsOPDoctorPlan_VO)clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].Tag;
					this.SavePlanID=objPlan.m_strOPDrPlanID;
				}
				else
				{
					this.m_Clear();
					m_objViewer.ShowDialog();
					return;
				}
				m_objViewer.m_txtDoc.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[2].Text;
				m_objViewer.m_txtDoc.Tag=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[1].Text;
				this.m_objViewer.m_txtNum.Tag=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[0].Text;

				if(m_objViewer.m_cboRegType.Tag!=null)
					clsRegType=(clsRegisterType_VO[])m_objViewer.m_cboRegType.Tag;
				for(int i=0;i<m_objViewer.m_cboRegType.Items.Count;i++)
				{
					if(clsRegType[i].m_strRegisterTypeName== clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[3].Text)
					{
						m_objViewer.m_cboRegType.SelectedIndex=i;
						break;
					}
				}
				m_objViewer.m_cboPerio.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[4].Text;
                string strTime=clsMain.IsNullToString(clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[5].Text,DateTime.Now.ToShortTimeString());
				m_objViewer.m_DtpStart.Value=Convert.ToDateTime(strTime);
                strTime=clsMain.IsNullToString(clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[6].Text,DateTime.Now.ToShortTimeString());
                m_objViewer.m_DtpEnd.Value=Convert.ToDateTime(strTime);
				m_objViewer.m_txtRoom.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[7].Text;
				m_objViewer.m_txtNum.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[8].Text;
				this.m_objViewer.txtOpdt.Text=objPlan.m_objOPDept.strDeptName;
				this.m_objViewer.txtOpdt.Tag=objPlan.m_objOPDept.strDeptID;
			}
		    TreeNode Tr;
			if(clsObject.m_objViewer.m_TV.Nodes.Count>0)
			{
				Tr=(TreeNode)clsObject.m_objViewer.m_TV.Nodes[0].Clone();
				m_objViewer.m_TVDep.Nodes.Add(Tr);
			}
			if(IsNew)
			{
				this.m_objViewer.txtOpdt.Text=clsObject.m_objViewer.m_TV.SelectedNode.Text.Trim();
				this.m_objViewer.txtOpdt.Tag=(string)clsObject.m_objViewer.m_TV.SelectedNode.Tag;
				this.m_objViewer.m_txtDoc.Focus();
				this.m_objViewer.LisDep.Visible=false;
			}
			if((string)clsObject.m_objViewer.m_TV.SelectedNode.Tag!="0000001")
			{
				this.m_objViewer.m_txtDoc.Focus();
				this.m_objViewer.LisDep.Visible=false;
			}
			TreeNode Tr1;
			if(clsObject.m_objViewer.m_TV.Nodes.Count>0)
			{
				Tr1=(TreeNode)clsObject.m_objViewer.m_TV.Nodes[0].Clone();
				m_objViewer.m_treelisv.Nodes.Add(Tr1);
			}
			m_objViewer.Cursor=Cursors.Default;
			m_objViewer.ShowDialog();
		}
		public void ShowWeekPlan(bool IsNew,clsControlWeekPlan clsObject)
		{
			this.clsWeek=clsObject;
			clsOPDoctorWkPlan_VO objPlan=null;
			IsDayPlan=false;
			clsRegisterType_VO[] clsRegType=null;
			this.IsNew=IsNew;
			SaveWeek=clsObject.m_strGetWeek();
			SaveDepID=clsObject.m_objViewer.m_TV.SelectedNode.Tag.ToString();
			if(!IsNew)
			{
				if((string)clsObject.m_objViewer.m_TV.SelectedNode.Tag!="0000001")
				{
					this.m_objViewer.txtOpdt.Enabled=false;
				}
				m_objViewer.m_txtDoc.Enabled=false;
				if(clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].Tag!=null)
				{
					objPlan=(clsOPDoctorWkPlan_VO)clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].Tag;
					this.SavePlanID=objPlan.m_strOPDrWkPlanID;
				}
				else
				{
					this.m_Clear();
					m_objViewer.ShowDialog();
					return;
				}
				m_objViewer.m_txtDoc.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[2].Text;
				m_objViewer.m_txtDoc.Tag=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[1].Text;
				this.m_objViewer.m_txtNum.Tag=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[0].Text;
				if(m_objViewer.m_cboRegType.Tag!=null)
					clsRegType=(clsRegisterType_VO[])m_objViewer.m_cboRegType.Tag;
				for(int i=0;i<m_objViewer.m_cboRegType.Items.Count;i++)
				{
					if(clsRegType[i].m_strRegisterTypeName== clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[3].Text)
					{
						m_objViewer.m_cboRegType.SelectedIndex=i;
						break;
					}
				}
				m_objViewer.m_cboPerio.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[4].Text;
				string strTime=clsMain.IsNullToString(clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[5].Text,DateTime.Now.ToShortTimeString());
				m_objViewer.m_DtpStart.Value=Convert.ToDateTime(strTime);
				strTime=clsMain.IsNullToString(clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[6].Text,DateTime.Now.ToShortTimeString());
				m_objViewer.m_DtpEnd.Value=Convert.ToDateTime(strTime);
				m_objViewer.m_txtRoom.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[7].Text;
				m_objViewer.m_txtNum.Text=clsObject.m_objViewer.m_lvwPlan.SelectedItems[0].SubItems[8].Text;
				this.m_objViewer.txtOpdt.Text=objPlan.m_objOPDept.strDeptName;
				this.m_objViewer.txtOpdt.Tag=objPlan.m_objOPDept.strDeptID;
			}
			TreeNode Tr;
			if(clsObject.m_objViewer.m_TV.Nodes.Count>0)
			{
				Tr=(TreeNode)clsObject.m_objViewer.m_TV.Nodes[0].Clone();
				m_objViewer.m_TVDep.Nodes.Add(Tr);
			}
			if(IsNew)
			{
				this.m_objViewer.txtOpdt.Text=clsObject.m_objViewer.m_TV.SelectedNode.Text.Trim();
				this.m_objViewer.txtOpdt.Tag=(string)clsObject.m_objViewer.m_TV.SelectedNode.Tag;
			}
			if((string)clsObject.m_objViewer.m_TV.SelectedNode.Tag!="0000001")
			{
				m_objViewer.m_txtDoc.Focus();
			}
			TreeNode Tr1;
			if(clsObject.m_objViewer.m_TV.Nodes.Count>0)
			{
				Tr1=(TreeNode)clsObject.m_objViewer.m_TV.Nodes[0].Clone();
				m_objViewer.m_treelisv.Nodes.Add(Tr1);
			}
			m_objViewer.Cursor=Cursors.Default;
			m_objViewer.ShowDialog();
		}
		#region 得到时段的时间
		public void GetPerioTime()
		{
			switch(m_objViewer.m_cboPerio.SelectedIndex)
			{
                case 1:
					m_objViewer.m_DtpStart.Value=Convert.ToDateTime("12:00:00");
					m_objViewer.m_DtpEnd.Value=Convert.ToDateTime("17:59:59");
					break;
                case 2:
					m_objViewer.m_DtpStart.Value=Convert.ToDateTime("18:00:00");
					m_objViewer.m_DtpEnd.Value=Convert.ToDateTime("23:59:59");
					break;
				case 3:
					m_objViewer.m_DtpStart.Value=Convert.ToDateTime("08:00:00");
					m_objViewer.m_DtpEnd.Value=Convert.ToDateTime("17:59:59");
					break;
				default:
					m_objViewer.m_DtpStart.Value=Convert.ToDateTime("08:00:00");
					m_objViewer.m_DtpEnd.Value=Convert.ToDateTime("11:59:59");
					break;
			}
		}
		#endregion

		#region 显示科室、挂号类别、医生
		public void m_ShowDept(object sender)
		{
			if(((TextBox)sender).Name == "txtOpdt")
			{
				this.m_objViewer.LisDep.Left=this.m_objViewer.txtOpdt.Left;
				this.m_objViewer.LisDep.Top=((TextBox)sender).Top+((TextBox)sender).Height;
				string DepName=this.m_objViewer.txtOpdt.Text.Trim();
				m_lngFillLisDep(DepName);
				this.m_objViewer.txtOpdt.Focus();
				this.m_objViewer.LisDep.Visible=true;
			}
			else
			{
				this.m_objViewer.ListDor.Left=this.m_objViewer.label1.Left;
				this.m_objViewer.ListDor.Top=((TextBox)sender).Top+((TextBox)sender).Height;
				m_lngFillListDor();
				this.m_objViewer.m_txtDoc.Focus();
				this.m_objViewer.ListDor.Visible=true;
			}
		}
		#endregion

		#region 把部门信息填充到LisDep
		public void m_lngFillLisDep(string DepName)
		{
			long lngRes=0;
			if(dtbResultArr==null)
			{
				lngRes=m_objDoMain.m_lngGetDept(out dtbResultArr);
				if(lngRes<0)
				{
					return;
				}
			}
			int seleRow=0;
			if(this.m_objViewer.LisDep.Items.Count==0)
			{
				for(int i1=0;i1<dtbResultArr.Rows.Count;i1++)
				{
					ListViewItem LisTemp=null;
					LisTemp=new ListViewItem(dtbResultArr.Rows[i1]["SHORTNO_CHR"].ToString().Trim());
					if(dtbResultArr.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim()==DepName)
							seleRow=i1;
					LisTemp.SubItems.Add(dtbResultArr.Rows[i1]["DEPTNAME_VCHR"].ToString().Trim());
					LisTemp.Tag=dtbResultArr.Rows[i1];
					this.m_objViewer.LisDep.Items.Add(LisTemp);
				}
				this.m_objViewer.LisDep.Items[seleRow].Selected=true;
				this.m_objViewer.LisDep.Items[seleRow].Focused=true;
			}
		}

		#endregion

		#region 查找LisDep中的值
		/// <summary>
		///查找LisDep中的值 
		/// </summary>
		public void m_FindLisDep()
		{
			if(dtbResultArr!=null)
			{
				int i=0;
				string strValues=this.m_objViewer.txtOpdt.Text.Trim();
				if(clsMain.IsNumber(strValues))
				{
					for(int i1=0;i1<dtbResultArr.Rows.Count;i1++)
					{
						i=dtbResultArr.Rows[i1]["SHORTNO_CHR"].ToString().IndexOf(strValues,0);
						if(i==0)
						{
							this.m_objViewer.LisDep.Items[i1].Selected=true;
							this.m_objViewer.txtOpdt.Focus();
							this.m_objViewer.LisDep.Items[i1].EnsureVisible();
							return;
						}
					}
				}
				else
				{
					for(int i1=0;i1<dtbResultArr.Rows.Count;i1++)
					{
						i=dtbResultArr.Rows[i1]["PYCODE_CHR"].ToString().IndexOf(strValues.ToUpper(),0);
						if(i==0)
						{
							this.m_objViewer.LisDep.Items[i1].Selected=true;
							this.m_objViewer.LisDep.Items[i1].EnsureVisible();
							this.m_objViewer.txtOpdt.Focus();
							return;
						}
						if(dtbResultArr.Rows[i1]["DEPTNAME_VCHR"].ToString().IndexOf(strValues,0)==0)
						{
							this.m_objViewer.LisDep.Items[i1].Selected=true;
							this.m_objViewer.LisDep.Items[i1].EnsureVisible();
							this.m_objViewer.txtOpdt.Focus();
							return;
						}
					}
				}
			}
		}
		#endregion

		#region 把员工信息填充到ListDor
		public void m_lngFillListDor()
		{
			long lngRes=0;
			this.m_objViewer.ListDor.Items.Clear();
			string strDepID=this.m_objViewer.txtOpdt.Tag.ToString().Trim();
			lngRes=m_objDoMain.m_lngGetEmployee(strDepID,out dtbResultEmp);
			if(lngRes<0)
			{
				return;
			}
			if(dtbResultEmp.Length>0)
			{
				for(int i1=0;i1<dtbResultEmp.Length;i1++)
				{
					ListViewItem LisTemp=null;
					LisTemp=new ListViewItem(dtbResultEmp[i1].strEmpNO.Trim());
					LisTemp.SubItems.Add(dtbResultEmp[i1].strName.Trim());
					LisTemp.Tag=dtbResultEmp[i1];
					this.m_objViewer.ListDor.Items.Add(LisTemp);
					if(strDepID!=""&&strDepID!=null)
					{
						if(dtbResultEmp[i1].strDEPTID_CHR.Trim()==strDepID.Trim())
						{
							m_objViewer.ListDor.Items[i1].BackColor=System.Drawing.Color.DarkOrange;
						}
					}
				}
				this.m_objViewer.ListDor.Items[0].Selected=true;
			}
		}
		#endregion

		#region 查找LisDep中的值
		/// <summary>
		///查找LisDep中的值 
		/// </summary>
		public void m_FindLisDor()
		{
			if(dtbResultEmp!=null)
			{
				int i=0;
				string strValues=this.m_objViewer.m_txtDoc.Text.Trim();
				if(clsMain.IsNumber(strValues))
				{
					for(int i1=0;i1<dtbResultEmp.Length;i1++)
					{
						i=dtbResultEmp[i1].strEmpNO.ToString().IndexOf(strValues,0);
						if(i==0)
						{
							this.m_objViewer.ListDor.Items[i1].Selected=true;
							this.m_objViewer.m_txtDoc.Focus();
							this.m_objViewer.ListDor.Items[i1].EnsureVisible();
							return;
						}
					}
				}
				else
				{
					for(int i1=0;i1<dtbResultEmp.Length;i1++)
					{
						i=dtbResultEmp[i1].strPYCode.ToString().IndexOf(strValues.ToUpper(),0);
						if(i==0)
						{
							this.m_objViewer.ListDor.Items[i1].Selected=true;
							this.m_objViewer.ListDor.Items[i1].EnsureVisible();
							this.m_objViewer.m_txtDoc.Focus();
							return;
						}
						if(dtbResultEmp[i1].strName.ToString().IndexOf(strValues,0)==0)
						{
							this.m_objViewer.ListDor.Items[i1].Selected=true;
							this.m_objViewer.ListDor.Items[i1].EnsureVisible();
							this.m_objViewer.m_txtDoc.Focus();
							return;
						}
					}
				}
			}
		}
		#endregion
	}
}
