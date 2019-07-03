using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using System.Collections;
using System.Drawing;


	namespace com.digitalwave.iCare.gui.HIS
	{
		/// <summary>
		/// clsControlRegister 的摘要说明。
		/// </summary>
		public class clsControlReturnReg:com.digitalwave.GUI_Base.clsController_Base
		{
			public clsControlReturnReg()
			{
				//
				// TODO: 在此处添加构造函数逻辑
				//

				clsDomain=new clsDomainControl_Register();
				clsRegister=new clsPatientRegister_VO();
		
				//	OperatorID=this.m_objViewer.LoginInfo.m_strEmpID;
			}
			clsDomainControl_Register clsDomain;
			clsPatientRegister_VO clsRegister;
			string OperatorID;
			private enum enumlvwSel:byte
			{
				PatType=1,
				Dept=2,
				RegType=3,
				Doc=4
			}
			#region 设置窗体对象
			com.digitalwave.iCare.gui.HIS.frmReturnReg m_objViewer;
			/// <summary>
			/// 设置窗体对象
			/// </summary>
			/// <param name="frmMDI_Child_Base_in"></param>
			public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
			{
				base.Set_GUI_Apperance(frmMDI_Child_Base_in);
				m_objViewer = (frmReturnReg)frmMDI_Child_Base_in;
			}
			#endregion
			#region 清空窗体数据
			public void m_Clear()
			{
				clsRegister=new clsPatientRegister_VO();
				clsRegister.m_objDiagDept=new clsDepartmentVO();
				clsRegister.m_objDiagDoctor=new clsEmployeeVO();
				clsRegister.m_strPayType=new clsPatientType_VO();
				clsRegister.m_strRegisterType=new clsRegisterType_VO();
				clsRegister.m_objPatientCard=new clsPatientCard_VO();
				clsRegister.m_objRegisterEmp=new clsEmployeeVO();
				clsRegister.m_objRegisterEmp.strEmpID=this.OperatorID;
				m_objViewer.m_cboSex.SelectedIndex=-1;
				m_objViewer.m_cboSex.Text="";
				this.m_objViewer.m_txtChangeCharge.Text = "0";
				this.m_objViewer.m_txtChangeDisCount.Text = "0";
				m_objViewer.m_dtpBirth.Value=DateTime.Now.Date;
				m_objViewer.m_dtpPreTime.Value=m_ServDate();
				m_objViewer.m_cboSeg.SelectedIndex=this.m_GetSerPerio();
				m_objViewer.m_lbEnd.Text="";
				m_objViewer.m_lbRoom.Text="";
				m_objViewer.m_lbStart.Text="";
				m_objViewer.m_txtAmount.Clear();
				m_objViewer.m_txtCard.Clear();
				m_objViewer.m_txtDept.Clear();
				m_objViewer.m_txtDiagFee.Clear();
				m_objViewer.m_txtDoc.Clear();
				m_objViewer.m_txtName.Clear();
				m_objViewer.m_txtPatType.Clear();
				m_objViewer.m_txtRegFee.Clear();
				m_objViewer.m_txtRegType.Clear();
				m_objViewer.m_txtCard.Focus();
				m_objViewer.m_lvItem.Clear();
				m_objViewer.m_txtRegisterNo.Clear();
				//m_objViewer.m_lsvRegDetail.Clear();
				for(int i1=0;i1<this.m_objViewer.m_lsvRegDetail.Items.Count;i1++)
				{
					this.m_objViewer.m_lsvRegDetail.Items[i1].SubItems[3].Text = "0";
					this.m_objViewer.m_lsvRegDetail.Items[i1].SubItems[4].Text = "0";
				}
			
			}
			//当前服务器日期
			/// <summary>
			/// 当前服务器日期
			/// </summary>
			/// <returns></returns>
			public DateTime m_ServDate()
			{
				DateTime DTP;
				DTP=clsDomain.m_GetServTime();
				return DTP;
			}
			#endregion
			#region 取得当前服务器时间段
			/// <summary>
			/// 取得当前服务器时间段
			/// </summary>
			/// <returns></returns>
			public int m_GetSerPerio()
			{
				int intPerio=0;
				int sevTime=clsDomain.m_GetServTime().Hour;
				if(sevTime>=12 && sevTime<18)
					intPerio=1; //下午
				else
				{
					if(sevTime>=18)
						intPerio=2; //晚上
					else
						intPerio=0; //上午
				}
				return intPerio;
			}
			#endregion
			#region 填充各ComboBox
			public void m_FillComboBox()
			{
				//时间段
				m_objViewer.m_cboSeg.Items.Clear();
				m_objViewer.m_cboSeg.Items.Add("上午");
				m_objViewer.m_cboSeg.Items.Add("下午");
				m_objViewer.m_cboSeg.Items.Add("晚上");
				//性别
				m_objViewer.m_cboSex.Items.Clear();
				m_objViewer.m_cboSex.Items.Add("男");
				m_objViewer.m_cboSex.Items.Add("女");
			}
			#endregion
			#region 检查是否有当前时段的排班
			public void m_CheckPlan()
			{
				bool isExits=false;
				isExits=clsDomain.m_bnlCheckPlanByDatePerio(m_objViewer.m_dtpPreTime.Value.ToShortDateString(),m_objViewer.m_cboSeg.Text);
				if(!isExits)
					MessageBox.Show(m_objViewer.m_cboSeg.Text + " 没有排班记录，请到相应模块维护！","提示");

			}
			#endregion

			#region 填充lvwItem
			public void m_GetlvwItem()
			{
				m_objViewer.Cursor=Cursors.WaitCursor;
				m_objViewer.m_lvItem.Tag=m_objViewer.ActiveControl.Name;
				switch(m_objViewer.ActiveControl.Name)
				{
					case "m_txtPatType":
						this.FillPatType();
						break;
					case "m_txtRegType":
						this.FillRegType();
						break;
					case "m_txtDept":
						this.FillDept();
						break;
					case "m_txtDoc":
						this.FillDoc();
						break;
				}
				if(m_objViewer.m_lvItem.Items.Count>0)
					m_objViewer.m_lvItem.Items[0].Selected=true;
				m_objViewer.Cursor=Cursors.Default;
			}
			private void FillPatType()
			{
				clsPatientType_VO[] objResultArr=null;
				m_objViewer.m_lvItem.Columns.Clear();
				m_objViewer.m_lvItem.Columns.Add("编号",60,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.Columns.Add("病人类型",100,HorizontalAlignment.Center);
				//m_objViewer.m_lvItem.Columns.Add("自付比例",100,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.Items.Clear();
				long lngRes = clsDomain.m_lngGetPatType(out objResultArr);

				if((lngRes>0)&&(objResultArr != null))
				{
					if (objResultArr.Length > 0)
					{
						ListViewItem lvw=null;
						for(int i1=0; i1<objResultArr.Length;i1++)
						{
							lvw=new ListViewItem(objResultArr[i1].m_strPayTypeID);
							lvw.SubItems.Add(objResultArr[i1].m_strPayTypeName);
							//						decimal decDis=objResultArr[i1].m_decDiscount*100;
							//						lvw.SubItems.Add(decDis.ToString().Trim()+"%");
							lvw.Tag=objResultArr[i1];
							m_objViewer.m_lvItem.Items.Add(lvw);
						}
					}
				}
			}
			private void FillRegType()
			{
				clsRegisterType_VO[] objResultArr=null;
			
				m_objViewer.m_lvItem.Columns.Clear();
				m_objViewer.m_lvItem.Columns.Add("编号",60,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.Columns.Add("挂号类型",100,HorizontalAlignment.Center);
				//			m_objViewer.m_lvItem.Columns.Add("挂号费",60,HorizontalAlignment.Center);
				//			m_objViewer.m_lvItem.Columns.Add("诊金",60,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.ResumeLayout(false);
				m_objViewer.m_lvItem.Items.Clear();
				long lngRes = clsDomain.m_lngGetRegType(out objResultArr);

				if((lngRes>0)&&(objResultArr != null))
				{
					if (objResultArr.Length > 0)
					{
						ListViewItem lvw=null;
						for(int i1=0; i1<objResultArr.Length;i1++)
						{
							lvw=new ListViewItem(objResultArr[i1].m_strRegisterTypeID);
							lvw.SubItems.Add(objResultArr[i1].m_strRegisterTypeName);
							//						lvw.SubItems.Add(objResultArr[i1].m_decRegPay.ToString());
							//						lvw.SubItems.Add(objResultArr[i1].m_decDiagPay.ToString());
							lvw.Tag=objResultArr[i1];
							m_objViewer.m_lvItem.Items.Add(lvw);
						}
					}
				}
			}
			private void FillDept()
			{
				clsDepartmentVO[] objResultArr=null;
				m_objViewer.m_lvItem.Columns.Clear();
				m_objViewer.m_lvItem.Columns.Add("编号",60,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.Columns.Add("科室名称",100,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.ResumeLayout(false);
				m_objViewer.m_lvItem.Items.Clear();
				long lngRes = clsDomain.m_lngGetPlanDepByDate(clsRegister.m_strRegisterDate,m_objViewer.m_cboSeg.Text,out objResultArr);

				if((lngRes>0)&&(objResultArr != null))
				{
					if (objResultArr.Length > 0)
					{
						ListViewItem lvw=null;
						for(int i1=0; i1<objResultArr.Length;i1++)
						{
							lvw=new ListViewItem(objResultArr[i1].strDeptID);
							lvw.SubItems.Add(objResultArr[i1].strDeptName);
							lvw.Tag=objResultArr[i1];
							m_objViewer.m_lvItem.Items.Add(lvw);
						}
					}
				}
			}
			private void FillDoc()
			{
				clsEmployeeVO[] objResultArr=null;
				m_objViewer.m_lvItem.Columns.Clear();
				m_objViewer.m_lvItem.Columns.Add("编号",60,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.Columns.Add("医生姓名",100,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.Columns.Add("限号",60,HorizontalAlignment.Center);
				m_objViewer.m_lvItem.ResumeLayout(false);
				m_objViewer.m_lvItem.Items.Clear();
				string strDate=clsMain.IsNullToString(clsRegister.m_strRegisterDate,null);
				string strDeptID=clsRegister.m_objDiagDept.strDeptID;
				string strRegType=clsRegister.m_strRegisterType.m_strRegisterTypeID;
				long lngRes=0;
				if(strDeptID=="")
					strDeptID=null;
				lngRes = clsDomain.m_lngGetOPDoctorList(strDeptID,out objResultArr);

				if((lngRes>0)&&(objResultArr != null))
				{
					if (objResultArr.Length > 0)
					{
						ListViewItem lvw=null;
						for(int i1=0; i1<objResultArr.Length;i1++)
						{
							lvw=new ListViewItem(objResultArr[i1].strEmpID);
							lvw.SubItems.Add(objResultArr[i1].strName);
							lvw.SubItems.Add(objResultArr[i1].intStatus.ToString());
							lvw.Tag=objResultArr[i1];
							m_objViewer.m_lvItem.Items.Add(lvw);
						
						}
					}
				}
			}
			#endregion

			#region 点击lvwItem触发的事件
			public void m_lvwItemClick()
			{
				if(m_objViewer.m_lvItem.Items.Count==0 || m_objViewer.m_lvItem.SelectedItems.Count==0)
					return;
				if(m_objViewer.m_lvItem.SelectedItems[0].Tag==null)
					return;
				switch(m_objViewer.m_lvItem.Tag.ToString())
				{
					case "m_txtPatType":
						clsRegister.m_strPayType=(clsPatientType_VO)m_objViewer.m_lvItem.SelectedItems[0].Tag;
						this.m_objViewer.m_txtPatType.Tag = clsRegister.m_strPayType.m_strPayTypeID;
						m_objViewer.m_txtPatType.Text=clsRegister.m_strPayType.m_strPayTypeName;
						if(clsMain.IsNullToString(clsRegister.m_strRegisterType.m_strRegisterTypeID,null)!="")						
							m_GetCurPay();
						m_objViewer.m_txtDept.Focus();
						break;
					case "m_txtRegType":
						clsRegister.m_strRegisterType = (clsRegisterType_VO)m_objViewer.m_lvItem.SelectedItems[0].Tag;
						this.m_objViewer.m_txtRegType.Tag = clsRegister.m_strRegisterType.m_strRegisterTypeID;
						this.m_objViewer.m_txtRegType.Text = clsRegister.m_strRegisterType.m_strRegisterTypeName;
						if(clsMain.IsNullToString(clsRegister.m_strPayType.m_strPayTypeID,null)!="")
						{
							//this.CalFee();
							m_GetCurPay();
							m_objViewer.m_txtDoc.Focus();
						}
						else
							m_objViewer.m_txtDoc.Focus();//m_objViewer.m_txtPatType.Focus();
						break;
					case "m_txtDept":
						clsRegister.m_objDiagDept=(clsDepartmentVO)m_objViewer.m_lvItem.SelectedItems[0].Tag;
						m_objViewer.m_txtDept.Text=clsRegister.m_objDiagDept.strDeptName;
						m_objViewer.m_txtRegType.Focus();
						break;
					case "m_txtDoc":
						if(FilltxtByDoc())
							m_objViewer.m_btnSave.Focus();
						break;
				}
			}
			private void CalFee()
			{
				m_objViewer.m_txtRegType.Text=clsRegister.m_strRegisterType.m_strRegisterTypeName;
				string RegTypeID=clsRegister.m_strRegisterType.m_strRegisterTypeID;
				string PatTypeID=clsRegister.m_strPayType.m_strPayTypeID;
				if(clsMain.IsNullToString(PatTypeID,null)=="" || clsMain.IsNullToString(RegTypeID,null)=="")
				{
					m_objViewer.m_txtRegFee.Clear();              
					m_objViewer.m_txtDiagFee.Clear();
					m_objViewer.m_txtAmount.Clear();
					clsRegister.m_decRegisterPay=0;
					clsRegister.m_decDiagPay=0;
					return;
				}
				clsPatRegFee_VO clsVO;
				long lngRes=clsDomain.m_lngFindPatRegFeeByID(PatTypeID,RegTypeID,out clsVO);
				if(clsVO.m_strRegisterTypeID==null || clsVO.m_strRegisterTypeID=="")
				{
					m_objViewer.m_txtRegFee.Clear();              
					m_objViewer.m_txtDiagFee.Clear();
					m_objViewer.m_txtAmount.Clear();
					clsRegister.m_decRegisterPay=0;
					clsRegister.m_decDiagPay=0;
					return;
				}
				else
				{
					m_objViewer.m_txtRegFee.Text=clsVO.m_decRegFee.ToString();
					m_objViewer.m_txtDiagFee.Text=clsVO.m_decDiagFee.ToString();
					clsRegister.m_decRegisterPay=clsVO.m_decRegFee;
					clsRegister.m_decDiagPay=clsVO.m_decDiagFee;
					m_objViewer.m_txtAmount.Text=Convert.ToString(clsVO.m_decRegFee+clsVO.m_decDiagFee);
				}
			}
			private bool FilltxtByDoc()
			{
				long lngRes=0;
				if(m_objViewer.m_lvItem.SelectedItems[0].Tag==null)
					return false;
				clsOPDoctorPlan_VO objResult=new clsOPDoctorPlan_VO();
				clsRegister.m_objDiagDoctor=(clsEmployeeVO)m_objViewer.m_lvItem.SelectedItems[0].Tag;
				int lngLimitNo=clsRegister.m_objDiagDoctor.intStatus;
				if(lngLimitNo==0)
				{
					if(MessageBox.Show("该医生已达到限号，继续挂号吗？","",MessageBoxButtons.YesNo)==DialogResult.No)
						return false;
				}
				else
				{
					int intTakeCount=clsDomain.m_GetDocTakeCout(clsRegister.m_objDiagDoctor.strEmpID,
						clsRegister.m_strRegisterDate);
					if(intTakeCount>=lngLimitNo)
					{
						if(MessageBox.Show("该医生已达到限号，继续挂号吗？","",MessageBoxButtons.YesNo)==DialogResult.No)
							return false;
					}
				}
				m_objViewer.m_txtDoc.Text=clsRegister.m_objDiagDoctor.strName;
				lngRes=clsDomain.m_lngGetDocPlan(clsRegister.m_strRegisterDate,m_objViewer.m_cboSeg.Text,
					clsRegister.m_objDiagDoctor.strEmpID,out objResult);

				if(lngRes>0 && clsMain.IsNullToString(objResult.m_strOPDrPlanID,null)!="")
				{
					if(clsMain.IsNullToString(clsRegister.m_objDiagDept.strDeptID,null)=="") //没有填充科室
					{
						clsRegister.m_objDiagDept=objResult.m_objOPDept;
						m_objViewer.m_txtDept.Text=clsRegister.m_objDiagDept.strDeptName;
						clsRegister.m_strRegisterType=objResult.m_objRegisterType;
						m_objViewer.m_txtRegType.Text=clsRegister.m_strRegisterType.m_strRegisterTypeName;
					}
					m_objViewer.m_lbStart.Text=objResult.m_strStartTime;
					m_objViewer.m_lbEnd.Text=objResult.m_strEndTime;
					m_objViewer.m_lbRoom.Text=objResult.m_strOPAddress;
					//this.CalFee();
				}
				else
				{
					clsRegister.m_objDiagDept.strDeptID="";
					m_objViewer.m_txtDept.Clear();
					clsRegister.m_strRegisterType.m_strRegisterTypeID="";
					m_objViewer.m_txtRegType.Clear();
					m_objViewer.m_txtDept.Focus();
					return false;
				}
				return true;
			}
			#endregion

			#region 文本框改变时触发的事件
			public void m_txtChange()
			{
				if(m_objViewer.ActiveControl==null)
					return;

				if(m_objViewer.ActiveControl.Name=="m_txtRegFee" || m_objViewer.ActiveControl.Name=="m_txtDiagFee")
				{
					decimal decReg=decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtRegFee.Text,"0"));
					decimal decDiag=decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtDiagFee.Text,"0"));
					decimal decAmount=decReg+decDiag;
					clsRegister.m_decRegisterPay=decReg;
					clsRegister.m_decDiagPay=decDiag;
					if(decAmount!=0)
						m_objViewer.m_txtAmount.Text=decAmount.ToString();
					else
						m_objViewer.m_txtAmount.Clear();
					return;
				}
            
				switch(m_objViewer.ActiveControl.Name)
				{
					case "m_txtPatType":
						if(m_objViewer.ActiveControl.Text=="")
							clsRegister.m_strPayType.m_strPayTypeID="";
						else
							//m_GetCurPay();
							this.m_FindLvw(m_objViewer.m_txtPatType.Text);
						break;
					case "m_txtRegType":
						if(m_objViewer.ActiveControl.Text=="")
							clsRegister.m_strRegisterType.m_strRegisterTypeID="";
						else
							this.m_FindLvw(m_objViewer.m_txtRegType.Text);
						//m_GetCurPay();
						break;
					case "m_txtDept":
						if(m_objViewer.ActiveControl.Text=="")
							clsRegister.m_objDiagDept.strDeptID="";
						else
							this.m_FindLvw(m_objViewer.m_txtDept.Text);
						break;
					case "m_txtDoc":
						if(m_objViewer.ActiveControl.Text=="")
							clsRegister.m_objDiagDoctor.strEmpID="";
						else
							this.m_FindLvw(m_objViewer.m_txtDoc.Text);
						break;
				}
			}
			#endregion

			#region 文本框得到焦点
			public void m_txtFocus()
			{
				switch(m_objViewer.m_lvItem.Tag.ToString())
				{
					case "m_txtPatType":
						m_objViewer.m_txtPatType.Focus();
						break;
					case "m_txtRegType":
						m_objViewer.m_txtRegType.Focus();
						break;
					case "m_txtDept":
						m_objViewer.m_txtDept.Focus();
						break;
					case "m_txtDoc":
						m_objViewer.m_txtDoc.Focus();
						break;
				}
			}
			#endregion

			#region 查找Lvw中的值
			public void m_FindLvw(string strValues)
			{
				if(m_objViewer.m_lvItem.Items.Count==0)
					return;
				int i=0;
				if(clsMain.IsNumber(strValues))
					i=clsMain.FindItemByValues(m_objViewer.m_lvItem,0,strValues);
				else
					i=clsMain.FindItemByValues(m_objViewer.m_lvItem,1,strValues);
				m_objViewer.m_lvItem.SelectedItems[0].Selected=false;
				if(i>0)
					m_objViewer.m_lvItem.Items[i].Selected=true;
				else
					m_objViewer.m_lvItem.Items[0].Selected=true;
			}
			#endregion

			#region 获取当前病人类型的挂号费用
			/// <summary>
			/// 获取当前病人类型的挂号费用
			/// </summary>
			public void m_GetCurPay()
			{
				//			decimal mny = 0;
				//			this.m_objViewer.m_lsvRegDetail.Items.Clear();
				//			for(int i=0;i<this.m_clsRegisterPayVO.Length;i++)
				//			{
				//				if(this.m_clsRegisterPayVO[i].m_strPAYTYPEID_CHR.Trim() == this.m_objViewer.m_txtPatType.Tag.ToString().Trim()
				//					&& this.m_clsRegisterPayVO[i].m_strREGISTERTYPEID_CHR.Trim() == this.m_objViewer.m_txtRegType.Tag.ToString().Trim())
				//				{
				//					ListViewItem lvi = new ListViewItem();
				//					lvi.Text = "0";
				//					lvi.SubItems.Add(this.m_clsRegisterPayVO[i].m_strCHARGEID_CHR);
				//					lvi.SubItems.Add(this.m_clsRegisterPayVO[i].m_strCHARGENAME_CHR);
				//					lvi.SubItems.Add(Convert.ToString(this.m_clsRegisterPayVO[i].m_dblPAYMENT_MNY));
				//					lvi.SubItems.Add(Convert.ToString(this.m_clsRegisterPayVO[i].m_fltDISCOUNT_DEC));
				//					lvi.SubItems.Add(Convert.ToString(this.m_clsRegisterPayVO[i].m_strMEMO_VCHR));
				//					this.m_objViewer.m_lsvRegDetail.Items.Add(lvi);
				//					mny += decimal.Parse(this.m_clsRegisterPayVO[i].m_dblPAYMENT_MNY.ToString())*decimal.Parse(this.m_clsRegisterPayVO[i].m_fltDISCOUNT_DEC.ToString());
				//				}
				//			}
				//			if(this.m_objViewer.m_lsvRegDetail.Items.Count>0)
				//			{
				//				this.m_objViewer.m_lsvRegDetail.Items[0].Selected = true;
				//			}
				//			
				//			m_objViewer.m_txtRegFee.Text = mny.ToString();
				this.m_Calculate();
			}
			/// <summary>
			/// 总计金额
			/// </summary>
			public void m_FigureUpPay()
			{
				decimal mny = 0;
				for(int i=0;i<this.m_objViewer.m_lsvRegDetail.Items.Count;i++)
				{
					try
					{
						mny += decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text)*decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text);
					}
					catch{}
				}
				m_objViewer.m_txtRegFee.Text = mny.ToString();
				m_Calculate();
			}
			/// <summary>
			/// 计算余额
			/// </summary>
			public void m_Calculate()
			{
				if(m_objViewer.m_txtAmount.Text.Trim() == "" || m_objViewer.m_txtRegFee.Text.Trim() == "") return;
				m_objViewer.m_txtDiagFee.Text = Convert.ToString(decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtAmount.Text,"0")) - decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtRegFee.Text,"0")));
			}
			#endregion
			#region 查找并填充病人的资料
			public void m_FindPat()
			{
				if(m_objViewer.m_txtCard.Text=="")
					return;
				long lngRes=0;
				clsPatient_VO objResult=new clsPatient_VO();
				string DepName=null;
				string doctorName=null;
				string registerDate=null;
				lngRes=clsDomain.m_lngGetPatByCard(m_objViewer.m_txtCard.Text,out objResult,DateTime.Now.ToShortDateString(),out DepName,out doctorName,out registerDate);
				if(lngRes>0 && clsMain.IsNullToString(objResult.strPatientID,null)!="")
				{
					m_objViewer.m_txtName.Text=objResult.strName;
					if(clsMain.IsNullToString(objResult.strBirthDate,null)!="")
						m_objViewer.m_dtpBirth.Value=Convert.ToDateTime(objResult.strBirthDate);
					m_objViewer.m_txtPatType.Text=objResult.objPatType.m_strPayTypeName;
					m_objViewer.m_txtPatType.Tag = (object)objResult.objPatType.m_strPayTypeID;
					clsRegister.m_strPayType=objResult.objPatType;
					clsRegister.m_objPatientCard.m_strCardID=objResult.strPatientCardID;
					clsRegister.strOptimes = objResult.m_strOPTIMES_INT;
					m_objViewer.m_cboSex.Text=objResult.strSex;
					m_objViewer.m_txtDept.Focus();
				}
				else
				{
					if(MessageBox.Show("查无该卡号病人信息！是否新增？","提示",MessageBoxButtons.YesNo)==DialogResult.Yes)
					{
						m_NewCard();
					}
					else
					{
						m_objViewer.m_txtCard.Focus();
					}

					//m_objViewer.m_txtCard.Text="";
				}
			}
			#endregion
			#region 新增卡号 zlc 2004-7-27
			public void m_NewCard()
			{
				//			string patientcardid = "";
				//			if(new com.digitalwave.iCare.gui.Patient.frmPatient().m_diaGetPatientCardID("1",out patientcardid,this.m_objViewer.m_txtCard.Text.Trim()) == DialogResult.OK)
				//			{
				//				this.m_objViewer.m_txtCard.Text = patientcardid;
				//				this.m_FindPat();
				//			}
				//			else
				//			{
				//				m_objViewer.m_txtCard.Focus();
				//			}
			}
			#endregion

			#region 获取费用表 zlc 2004-8-3
			public clsRegisterPay[] m_clsRegisterPayVO;
			public void m_GetPay()
			{
				m_clsRegisterPayVO = new clsRegisterPay[0];
				clsDomain.m_lngGetPay(out m_clsRegisterPayVO);
			}
			#endregion

			#region 新增一挂号记录
			private string strOrderNo="";
			public long m_lngAddRegister()
			{
				string strID="";
				string strNo="";
			
				if(clsRegister==null)
					return -1;
				long lngRes=0;
				if(!this.m_bolCheckValuePass())
					return -1;
				if(m_objViewer.m_chkPre.Checked) //预约
					clsRegister.m_intFlag="2";
				clsRegister.m_strPiod=m_objViewer.m_cboSeg.Text;
				clsRegister.m_decRegisterPay=decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtRegFee.Text,"0"));
				clsRegister.m_decDiagPay=decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtDiagFee.Text,"0"));
				//lngRes=clsDomain.m_lngAddRegister(clsRegister,out strID,out strNo,out strOrderNo,out );
				if(lngRes>0)
				{
					this.m_strRegisterID = clsRegister.m_strRegisterID=strID;
					clsRegister.m_strRegisterNo=strNo;	
					m_lngAddRegisterDetail();
					this.m_AddListPat();
				}
				else
					MessageBox.Show("挂号失败，请联系管理员！","提示");
				return lngRes;
			}
			public long m_lngAddRegisterDetail()
			{
				int DetailCount = m_objViewer.m_lsvRegDetail.Items.Count;
				long lngarg = 0;
				for(int i=0;i<DetailCount;i++)
				{
					if(decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) == 0
						|| decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) == 0) continue;
					clsPatientDetail_VO clsPatientDetail = new clsPatientDetail_VO();
					clsPatientDetail.m_strREGISTERID_CHR = this.m_strRegisterID;
					clsPatientDetail.m_strCHARGEID_CHR = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[1].Text;
					clsPatientDetail.m_dblPAYMENT_MNY = double.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text);
					clsPatientDetail.m_fltDISCOUNT_DEC = float.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text);
					lngarg = clsDomain.m_lngAddRegisterDegail(clsPatientDetail);
					if(lngarg<=0)
					{
						return lngarg;
					}
				}
				return lngarg;
			}
		
			private void m_AddListPat()
			{
			
				if (clsMain.IsNullToString(clsRegister.m_strRegisterID,null)!="")
				{
					ListViewItem lvw=null;
					lvw=new ListViewItem(long.Parse(clsRegister.m_strRegisterNo).ToString());
					lvw.SubItems.Add(clsRegister.m_strRegisterDate);
					lvw.SubItems.Add(m_objViewer.m_cboSeg.Text);
					lvw.SubItems.Add(m_objViewer.m_txtName.Text);
					lvw.SubItems.Add(clsRegister.m_objDiagDept.strDeptName);
					lvw.SubItems.Add(clsRegister.m_strRegisterType.m_strRegisterTypeName);
					lvw.SubItems.Add(clsRegister.m_objDiagDoctor.strName);
					lvw.Tag=clsRegister;
					//m_objViewer.m_lvPat.Items.Add(lvw);
				}
			
			}
		
			#endregion

			#region 修改金额和优惠
			public int m_intModifyPrice()
			{
				for(int i=0;i<this.m_objViewer.m_lsvRegDetail.Items.Count;i++)
				{
					if(this.m_objViewer.m_lsvRegDetail.Items[i].Selected == true)
					{
						if(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[5].Text.IndexOf("不可修改")>=0) 
						{					
							return i;
						}
						this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text =Convert.ToString(decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtChangeCharge.Text,"0")));
						this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text = Convert.ToString(decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtChangeDisCount.Text,"0")));
						m_FigureUpPay();
						return i;
					}
				}
			
				return 0;
			}
			public void m_getCurPrice()
			{
				for(int i=0;i<this.m_objViewer.m_lsvRegDetail.Items.Count;i++)
				{
					if(this.m_objViewer.m_lsvRegDetail.Items[i].Selected == true)
					{
						if(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[5].Text.IndexOf("不可修改")>=0) 
						{					
							m_objViewer.m_txtChangeCharge.ReadOnly = true;
							m_objViewer.m_txtChangeDisCount.ReadOnly = true;
						}
						else
						{
							m_objViewer.m_txtChangeCharge.ReadOnly = false;
							m_objViewer.m_txtChangeDisCount.ReadOnly = false;
						}
						m_objViewer.m_txtChangeCharge.Text = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text ;
						m_objViewer.m_txtChangeDisCount.Text = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text;
						return ;
					}
				}
			
			}
			public void m_UpDown(int index,System.Windows.Forms.KeyEventArgs e)
			{
				if(index == this.m_objViewer.m_lsvRegDetail.Items.Count-1 && e.KeyCode == Keys.Down)
				{
					this.m_objViewer.m_lsvRegDetail.Items[index].Selected = false;
					this.m_objViewer.m_lsvRegDetail.Items[0].Selected = true;
				}
				if(index == 0 && e.KeyCode == Keys.Up)
				{
					this.m_objViewer.m_lsvRegDetail.Items[0].Selected = false;
					this.m_objViewer.m_lsvRegDetail.Items[this.m_objViewer.m_lsvRegDetail.Items.Count-1].Selected = true;
				}
				if(index>0 && index<=this.m_objViewer.m_lsvRegDetail.Items.Count-1 && e.KeyCode == Keys.Up)
				{
					this.m_objViewer.m_lsvRegDetail.Items[index].Selected = false;
					this.m_objViewer.m_lsvRegDetail.Items[index-1].Selected = true;
				}
				if(index>=0 && index<this.m_objViewer.m_lsvRegDetail.Items.Count-1 && e.KeyCode == Keys.Down)
				{
					this.m_objViewer.m_lsvRegDetail.Items[index].Selected = false;
					this.m_objViewer.m_lsvRegDetail.Items[index+1].Selected = true;
				}
			}
			#endregion
			#region 不须发卡时的费用
			public void m_MoveCardPay(CheckBox chk)
			{
				//			switch(chk.Name)
				//			{
				//				case "m_chkNeedNotCard":
				//					if(chk.Checked)
				//					{
				//						this.m_objViewer.m_ls
				//					}
				//					break;
				//				case "m_chkNeedNotfalill":
				//					break;
				//			}
			}
			#endregion
		
			#region 打印挂号票 zlc 2004-7-28
			private string m_strRegisterID="";
			public void m_PrintRegister()
			{
				if(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Count == 0) return;
				if(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号状态"].ToString() == "退号")
				{
					MessageBox.Show("该号已退，不能打印！");
					return;
				}
				System.Data.DataTable dtbSource = new System.Data.DataTable("printtemptable");
				dtbSource.Columns.Add("varchar1");
				dtbSource.Columns.Add("patientname");
				dtbSource.Columns.Add("date");
				dtbSource.Columns.Add("orderno");
				dtbSource.Columns.Add("registerno");
				dtbSource.Columns.Add("address");
				dtbSource.Columns.Add("registertype");
				dtbSource.Columns.Add("strDiagdept");
				dtbSource.Columns.Add("strEmpt");
				dtbSource.Columns.Add("decimal1",typeof(decimal));
				dtbSource.Columns.Add("decimal2",typeof(decimal));
				for(int i=0;i<this.m_objViewer.m_lsvRegDetail.Items.Count;i++)
				{
					//				if(decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) == 0
					//					|| decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) == 0) continue;
					dtbSource.Rows.Add(new object[] {this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text,
														((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人名称"].ToString(),
														Convert.ToDateTime(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号日期"].ToString()).ToShortDateString()+" "+m_objViewer.m_cboSeg.Text.Trim(),
														((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["候诊号"].ToString(),
														((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["流水号"].ToString(),
														this.m_objViewer.m_lbRoom.Text,this.m_objViewer.m_txtRegType.Text,
														this.m_objViewer.m_txtDept.Text,
														((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号人工号"].ToString(),
														this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text,
														this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text});
				}
				switch(this.m_objViewer.m_cobSetPrint.SelectedIndex)
				{
					case 0 :
						clsControlPrint clsCtrPrint = new clsControlPrint();
						clsCtrPrint.m_PrintRegister1(dtbSource);
						break;
					case 1 :
						new FrmShowPrint().m_PrintRegister(dtbSource);
						break;
					case 2:
						break;
					default :
						break;
				}
				this.m_Clear();
			}
			#endregion
			#region 检查当前的数据是否有效
			private bool m_bolCheckValuePass()
			{
				bool bolReturn = true;

				//			if(clsMain.IsNullToString(clsRegister.m_objPatientCard.m_strCardID,null)=="")
				//			{
				//				m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
				//				bolReturn = false;
				//			}
				if(m_objViewer.m_txtName.Text.Trim() == "")
				{
					if(bolReturn)
						m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
					bolReturn = false;
				}

				if(m_objViewer.m_cboSex.SelectedIndex<0)
				{
					m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSex,"请选择性别");
					bolReturn = false;
				}
				if(clsMain.IsNullToString(clsRegister.m_strPayType.m_strPayTypeID,null) == "")
				{
					m_ephHandler.m_mthAddControl(m_objViewer.m_txtPatType);
					bolReturn = false;
				}
				if(m_objViewer.m_cboSeg.SelectedIndex<0)
				{
					m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg,"请选择时间段");
					bolReturn = false;
				}
				if(!bnlChekcBirth()) //出生日期
					bolReturn=false;
				if(clsMain.IsNullToString(clsRegister.m_objDiagDept.strDeptID,null) == "")
				{
					m_ephHandler.m_mthAddControl(m_objViewer.m_txtDept);
					bolReturn = false;
				}
				if(clsMain.IsNullToString(clsRegister.m_objDiagDoctor.strEmpID,null) == "" && clsMain.IsNullToString(clsRegister.m_objDiagDept.strDeptID,null) == "0002")
				{
					m_ephHandler.m_mthAddControl(m_objViewer.m_txtDoc);
					bolReturn = false;
				}
				if(clsMain.IsNullToString(clsRegister.m_strRegisterType.m_strRegisterTypeID,null) == "")
				{
					m_ephHandler.m_mthAddControl(m_objViewer.m_txtRegType);
					bolReturn = false;
				}
				bool bnlChk=this.bnlCheckDate();
				if(!bnlChk)
					bolReturn=false;
				if(!bolReturn)
				{
					m_ephHandler.m_mthShowControlsErrorProvider();
					m_ephHandler.m_mthClearControl();
				}
				return bolReturn;
			}
			public bool bnlCheckDate()
			{
				bool bolReturn=true;
				if(m_objViewer.m_chkPre.Checked) //预约
				{
					DateTime PreTime=Convert.ToDateTime(m_objViewer.m_dtpPreTime.Value.ToShortDateString());
					DateTime sevTime=Convert.ToDateTime(clsDomain.m_GetServTime().ToShortDateString());
					if(PreTime<sevTime) //不能预约以前
					{
						m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime,"不能预约当天之前的号");
						bolReturn=false;
					}
					else
					{
						if(sevTime==PreTime)//如果是当天，可以预约下午或晚上的
						{
							m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime,"");
							if(this.m_GetSerPerio()>m_objViewer.m_cboSeg.SelectedIndex) //不能挂前一个时间段的
							{
								m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg,"不能预约当前时间段之前的号");
								bolReturn=false;
							}
						}
					}
					if(bolReturn)
					{
						this.clsRegister.m_strRegisterDate=PreTime.ToShortDateString();
						m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime,"");
						m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg,"");
					}
				}
				else
				{
					m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime,"");
					m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg,"");
					this.clsRegister.m_strRegisterDate=clsDomain.m_GetServTime().ToShortDateString();
				}
				return bolReturn;
			}
			public bool bnlChekcBirth()
			{
				bool bolReturn=true;
				if(m_objViewer.m_dtpBirth.Value>clsDomain.m_GetServTime())
				{
					m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpBirth,"出生日期不能大于当前的时间");
					bolReturn = false;
				}
				else
					m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpBirth,"");
				return bolReturn;   
			}
			#endregion

			#region 查询挂号票 zlc 2004-7-30
			public void m_lngQuy()
			{
			}
			#endregion

			#region VO填充TEXTBOX zlc
			public void m_FillTextbox(clsPatientRegister_VO objreg)
			{
				this.m_objViewer.m_txtCard.Text    = objreg.m_objPatientCard.m_strCardID;
				this.m_objViewer.m_txtCard.Tag     = objreg.m_objPatientCard.m_strCardID;
				this.m_objViewer.m_txtName.Text    = objreg.m_clsPatientVO.strName;
				this.m_objViewer.m_txtName.Tag     = objreg.m_clsPatientVO.strPatientID;
				this.m_objViewer.m_cboSex.Text     =  objreg.m_clsPatientVO.strSex;
				this.m_objViewer.m_dtpBirth.Value  = Convert.ToDateTime(objreg.m_clsPatientVO.strBirthDate);
			
				this.m_objViewer.m_txtPatType.Text = objreg.m_strPayType.m_strPayTypeName;
				this.m_objViewer.m_txtPatType.Tag  = objreg.m_strPayType.m_strPayTypeID;

				this.m_objViewer.m_txtDept.Text    = objreg.m_objDiagDept.strDeptName;
				this.m_objViewer.m_txtDept.Tag     = objreg.m_objDiagDept.strDeptID;
				this.m_objViewer.m_txtRegType.Text = objreg.m_strRegisterType.m_strRegisterTypeName;
				this.m_objViewer.m_txtRegType.Tag  = objreg.m_strRegisterType.m_strRegisterTypeID;
				this.m_objViewer.m_txtDoc.Text     = objreg.m_objDiagDoctor.strFirstName;
				this.m_objViewer.m_txtDoc.Tag      = objreg.m_objDiagDoctor.strEmpID;
			
				this.m_objViewer.m_lbStart.Text    = objreg.m_clsOPDoctorPlanVO.m_strStartTime;
				this.m_objViewer.m_lbEnd.Text      = objreg.m_clsOPDoctorPlanVO.m_strEndTime;
				this.m_objViewer.m_lbRoom.Text     = objreg.m_clsOPDoctorPlanVO.m_strOPAddress;			
			}
			#endregion

			#region DATAGRID填充TEXTBOX
			public void m_DtgFillTXT()
			{
				try
				{
					this.m_objViewer.m_txtRegisterNo.Text    = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["流水号"].ToString() ;
					this.m_objViewer.m_txtCard.Text    = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["诊疗卡号"].ToString() ;
					this.m_objViewer.m_txtCard.Tag     = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["诊疗卡号"].ToString() ;
					this.m_objViewer.m_txtName.Text    = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人名称"].ToString() ;
					this.m_objViewer.m_txtName.Tag     = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人编号ID"].ToString() ;
					this.m_objViewer.m_cboSex.Text     = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人性别"].ToString() ;
					this.m_objViewer.m_dtpBirth.Value  = 	Convert.ToDateTime(((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["出生日期"].ToString()) ;
					this.m_objViewer.m_txtPatType.Text = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人身份"].ToString() ;
					this.m_objViewer.m_txtPatType.Tag  = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["身份类型ID"].ToString() ;
					this.m_objViewer.m_txtDept.Text    = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["科室名称"].ToString() ;
					this.m_objViewer.m_txtDept.Tag     = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["科室ID"].ToString() ;
					this.m_objViewer.m_txtRegType.Text = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号类型"].ToString() ;
					this.m_objViewer.m_txtRegType.Tag  = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号类型ID"].ToString() ;
					this.m_objViewer.m_txtDoc.Text     = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["医生名称"].ToString() ;
					this.m_objViewer.m_txtDoc.Tag      = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["医生ID"].ToString() ;
			
					this.m_objViewer.m_lbStart.Text    = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["开始时间"].ToString() ;
					this.m_objViewer.m_lbEnd.Text      = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["截止时间"].ToString() ;
					this.m_objViewer.m_lbRoom.Text     = 	((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["就诊地址"].ToString() ;
					this.m_objViewer.m_cboSeg.Text     =    ((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["就诊时间段"].ToString() ;
				}
				catch{}
			}
			#endregion

			#region 修改DATAGRID
			public System.Data.DataView m_dvRegister = new System.Data.DataView();
			public void m_ModifyDatagrid()
			{
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["诊疗卡号"] = this.m_objViewer.m_txtCard.Text   ;
				//((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)[""] = this.m_objViewer.m_txtCard.Tag    ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人名称"] = this.m_objViewer.m_txtName.Text   ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人编号ID"] = this.m_objViewer.m_txtName.Tag    ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人性别"] = this.m_objViewer.m_cboSex.Text    ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["出生日期"] = this.m_objViewer.m_dtpBirth.Value ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["病人身份"] = this.m_objViewer.m_txtPatType.Text;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["身份类型ID"] = this.m_objViewer.m_txtPatType.Tag ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["科室名称"] = this.m_objViewer.m_txtDept.Text   ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["科室ID"] = this.m_objViewer.m_txtDept.Tag    ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号类型"] = this.m_objViewer.m_txtRegType.Text;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号类型ID"] = this.m_objViewer.m_txtRegType.Tag ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["医生名称"] = this.m_objViewer.m_txtDoc.Text    ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["医生ID"] = this.m_objViewer.m_txtDoc.Tag     ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["开始时间"] = this.m_objViewer.m_lbStart.Text;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["截止时间"] = this.m_objViewer.m_lbEnd.Text  ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["就诊地址"] = this.m_objViewer.m_lbRoom.Text ;
				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["就诊时间段"] = this.m_objViewer.m_cboSeg.Text;
				//				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)[""] = ;
				//				((System.Data.DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)[""] = ;
			}
			#endregion

			#region 填充VO
			public void m_FillVO(out clsPatientRegister_VO objreg)
			{
				objreg = new clsPatientRegister_VO();
				objreg.m_objDiagDept=new clsDepartmentVO();
				objreg.m_objDiagDoctor=new clsEmployeeVO();
				objreg.m_strPayType=new clsPatientType_VO();
				objreg.m_strRegisterType=new clsRegisterType_VO();
				objreg.m_objPatientCard=new clsPatientCard_VO();
				objreg.m_objRegisterEmp=new clsEmployeeVO();
				objreg.m_clsPatientVO=new clsPatientVO();
				objreg.m_clsOPDoctorPlanVO=new clsOPDoctorPlan_VO();
				if(this.m_dvRegister.Count == 0) return;
				objreg.m_strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号ID"].ToString();
				objreg.m_objPatientCard.m_strCardID           			= this.m_objViewer.m_txtCard.Text;
				objreg.m_objPatientCard.m_strCardID           			= this.m_objViewer.m_txtCard.Tag.ToString()    ; 
				objreg.m_clsPatientVO.strName                 			= this.m_objViewer.m_txtName.Text   ;
				objreg.m_clsPatientVO.strPatientID            			= this.m_objViewer.m_txtName.Tag.ToString()    ;
				objreg.m_clsPatientVO.strSex                  			= this.m_objViewer.m_cboSex.Text    ; 
				objreg.m_clsPatientVO.strBirthDate                      = this.m_objViewer.m_dtpBirth.Value.ToShortDateString()  ;
		
				objreg.m_strPayType.m_strPayTypeName         			= this.m_objViewer.m_txtPatType.Text ;
				objreg.m_strPayType.m_strPayTypeID           			= this.m_objViewer.m_txtPatType.Tag.ToString()  ;
	
				objreg.m_objDiagDept.strDeptName             			= this.m_objViewer.m_txtDept.Text   ;
				objreg.m_objDiagDept.strDeptID               			= this.m_objViewer.m_txtDept.Tag.ToString()     ;
				objreg.m_strRegisterType.m_strRegisterTypeName          = this.m_objViewer.m_txtRegType.Text ;
				objreg.m_strRegisterType.m_strRegisterTypeID  			= this.m_objViewer.m_txtRegType.Tag.ToString() ;
				objreg.m_objDiagDoctor.strFirstName           			= this.m_objViewer.m_txtDoc.Text     ;
				objreg.m_objDiagDoctor.strEmpID               			= this.m_objViewer.m_txtDoc.Tag.ToString()      ;
		
				objreg.m_clsOPDoctorPlanVO.m_strStartTime     			=	this.m_objViewer.m_lbStart.Text    ;
				objreg.m_clsOPDoctorPlanVO.m_strEndTime       			= this.m_objViewer.m_lbEnd.Text     ;
				objreg.m_clsOPDoctorPlanVO.m_strOPAddress     			=	this.m_objViewer.m_lbRoom.Text    ;
				objreg.m_clsOPDoctorPlanVO.m_strPlanPeriod     			=	this.m_objViewer.m_cboSeg.Text    ;
			}
			#endregion

			#region 查找挂号表
			public void m_QulReg()
			{
				this.m_objViewer.m_cmbQulType.Text = "全部";
				this.m_objViewer.m_dtgRegister.DataBindings.Clear();
				try
				{
					this.m_dvRegister.Table.Clear();
				}
				catch{}
				System.Data.DataTable dtSource = new System.Data.DataTable();
				clsDomain.m_lngQulRegByDate(this.m_objViewer.m_datFirstdate.Value.ToShortDateString(),this.m_objViewer.m_datLastdate.Value.ToShortDateString(),out dtSource);
				if(dtSource.Rows.Count ==0)return;
				dtSource.Columns[0].ColumnName = "挂号ID";
				dtSource.Columns[1].ColumnName = "诊疗卡号";
				dtSource.Columns[2].ColumnName = "挂号日期";
				dtSource.Columns[3].ColumnName = "科室ID";
				dtSource.Columns[4].ColumnName = "医生ID";
				dtSource.Columns[5].ColumnName = "科室名称";
				dtSource.Columns[6].ColumnName = "医生名称";
				dtSource.Columns[7].ColumnName = "挂号人ID";
				dtSource.Columns[8].ColumnName = "过程状态";
				dtSource.Columns[9].ColumnName = "挂号类型ID";
				dtSource.Columns[10].ColumnName = "身份类型ID";
				dtSource.Columns[11].ColumnName = "流水号";
				dtSource.Columns[12].ColumnName = "挂号状态";
				dtSource.Columns[13].ColumnName = "退号人ID";
				dtSource.Columns[14].ColumnName = "退号日期";
				dtSource.Columns[15].ColumnName = "记录日期";
				dtSource.Columns[16].ColumnName = "支付类型";
				dtSource.Columns[17].ColumnName = "病人身份";
				dtSource.Columns[18].ColumnName = "挂号类型";
				dtSource.Columns[19].ColumnName = "病人名称";
				dtSource.Columns[20].ColumnName = "病人性别";
				dtSource.Columns[21].ColumnName = "出生日期";
				dtSource.Columns[22].ColumnName = "病人编号ID";
			
				dtSource.Columns[23].ColumnName = "病人年纪";
				dtSource.Columns[24].ColumnName = "就诊时间段";
				dtSource.Columns[25].ColumnName = "开始时间";
				dtSource.Columns[26].ColumnName = "截止时间";
				dtSource.Columns[27].ColumnName = "就诊地址";
				dtSource.Columns[28].ColumnName = "挂号人工号";
				dtSource.Columns[29].ColumnName = "候诊号";
				this.m_dvRegister = dtSource.DefaultView;
				this.m_objViewer.m_dtgRegister.SetDataBinding(this.m_dvRegister,null);
				this.m_objViewer.m_dtgRegister.m_SetDgrStyle();
				this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].PositionChanged +=new EventHandler(m_dtRegister_PositionChanged);
				this.m_objViewer.m_OmnipotenceQul.m_SetData(this.m_objViewer.m_dtgRegister,this.m_dvRegister,"流水号");
				m_dtRegister_PositionChanged(null,null);
			}

			private void m_dtRegister_PositionChanged(object send,System.EventArgs e)
			{
				this.m_DtgFillTXT();
				m_FillDetail();
				m_GetCurPay();
			
				//m_getCurPrice();
			}
			#endregion
			#region 填充明细
			public void m_FillDetail()
			{
				DataTable dtRegisterDetail = new DataTable();
				string strRegister = "";
				strRegister = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号ID"].ToString();
				clsDomain.m_lngQulRegDetail(strRegister,out dtRegisterDetail);
				this.m_objViewer.m_lsvRegDetail.Items.Clear();
				decimal mny = 0;
				for(int i1=0;i1<dtRegisterDetail.Rows.Count;i1++)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = dtRegisterDetail.Rows[i1][0].ToString().Trim();
					lvi.SubItems.Add(dtRegisterDetail.Rows[i1][1].ToString().Trim());
					lvi.SubItems.Add(dtRegisterDetail.Rows[i1][2].ToString().Trim());
					lvi.SubItems.Add(Convert.ToString(dtRegisterDetail.Rows[i1][3].ToString().Trim()));
					lvi.SubItems.Add(Convert.ToString(dtRegisterDetail.Rows[i1][4].ToString().Trim()));
					lvi.SubItems.Add(Convert.ToString(dtRegisterDetail.Rows[i1][5].ToString().Trim()));
					this.m_objViewer.m_lsvRegDetail.Items.Add(lvi);
					try
					{
						mny += decimal.Parse(this.m_clsRegisterPayVO[i1].m_dblPAYMENT_MNY.ToString())*decimal.Parse(this.m_clsRegisterPayVO[i1].m_fltDISCOUNT_DEC.ToString());
					}
					catch{}
					m_objViewer.m_txtRegFee.Text = mny.ToString();
					//				if(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[1].Text.Trim() == dtRegisterDetail.Rows[i1][1].ToString().Trim())
					//				{
					//					this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text = dtRegisterDetail.Rows[i1][3].ToString().Trim();
					//					this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text = dtRegisterDetail.Rows[i1][4].ToString().Trim();
					//					break;
					//				}
					//				else
					//				{
					//					this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text = "0";
					//					this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text = "0";
					//
					//				}
				}
			
				m_FigureUpPay();
			}
			#endregion

			#region 任意字段查询
			public void m_FindRegCol(object sender)
			{
				DataTable dtSource = new DataTable();
				switch(((TextBox)sender).Name)
				{
					case "m_txtCard":
						clsDomain.m_lngQulRegByCol(out dtSource,"CARDID",this.m_objViewer.m_txtCard.Text,"1");
						break;
					case "m_txtName":
						clsDomain.m_lngQulRegByCol(out dtSource,"NAME",this.m_objViewer.m_txtName.Text,"1");
						break;
					case "m_txtRegisterNo":
						clsDomain.m_lngQulRegByCol(out dtSource,"REGNO",this.m_objViewer.m_txtRegisterNo.Text,"1");
						break;
				}
				if(dtSource.Rows.Count ==0)return;
				dtSource.Columns[0].ColumnName = "挂号ID";
				dtSource.Columns[1].ColumnName = "诊疗卡号";
				dtSource.Columns[2].ColumnName = "挂号日期";
				dtSource.Columns[3].ColumnName = "科室ID";
				dtSource.Columns[4].ColumnName = "医生ID";
				dtSource.Columns[5].ColumnName = "科室名称";
				dtSource.Columns[6].ColumnName = "医生名称";
				dtSource.Columns[7].ColumnName = "挂号人ID";
				dtSource.Columns[8].ColumnName = "过程状态";
				dtSource.Columns[9].ColumnName = "挂号类型ID";
				dtSource.Columns[10].ColumnName = "身份类型ID";
				dtSource.Columns[11].ColumnName = "流水号";
				dtSource.Columns[12].ColumnName = "挂号状态";
				dtSource.Columns[13].ColumnName = "退号人ID";
				dtSource.Columns[14].ColumnName = "退号日期";
				dtSource.Columns[15].ColumnName = "挂号类型";
				dtSource.Columns[16].ColumnName = "病人身份";
				dtSource.Columns[17].ColumnName = "支付类型";
				dtSource.Columns[18].ColumnName = "病人名称";
				dtSource.Columns[19].ColumnName = "病人性别";
				dtSource.Columns[20].ColumnName = "出生日期";
				dtSource.Columns[21].ColumnName = "病人编号ID";
				dtSource.Columns[22].ColumnName = "病人年纪";
			
				dtSource.Columns[23].ColumnName = "挂号工ID";
				dtSource.Columns[24].ColumnName = "就诊时间段";
				dtSource.Columns[25].ColumnName = "开始时间";
				dtSource.Columns[26].ColumnName = "就诊地址";
				dtSource.Columns[27].ColumnName = "挂号人工号";
				dtSource.Columns[28].ColumnName = "候诊号";

				
				this.m_dvRegister = dtSource.DefaultView;
				this.m_objViewer.m_dtgRegister.SetDataBinding(this.m_dvRegister,null);
				this.m_objViewer.m_dtgRegister.m_SetDgrStyle();
				this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].PositionChanged +=new EventHandler(m_dtRegister_PositionChanged);
				this.m_DtgFillTXT();
				m_GetCurPay();
				m_FillDetail();
				m_getCurPrice();	
			}
			#endregion
			#region 在结果中查找
			public void m_FindRecord(object sender)
			{
				for(int i=0;i<this.m_dvRegister.Count;i++)
				{
					switch(((TextBox)sender).Name)
					{
						case "m_txtCard":
							if(this.m_dvRegister[i]["诊疗卡号"].ToString().Trim() == this.m_objViewer.m_txtCard.Text.Trim())
							{
								this.m_objViewer.m_dtgRegister.UnSelect(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position);
								this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position = i;
								this.m_objViewer.m_dtgRegister.Select(i);
								return;
							}
							break;
						case "m_txtName":
							if(this.m_dvRegister[i]["病人名称"].ToString().Trim() == this.m_objViewer.m_txtName.Text.Trim())
							{
								this.m_objViewer.m_dtgRegister.UnSelect(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position);
								this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position = i;
								this.m_objViewer.m_dtgRegister.Select(i);
								return;
							}
							break;
						case "m_txtRegisterNo":
							if(this.m_dvRegister[i]["流水号"].ToString().Trim() == this.m_objViewer.m_txtRegisterNo.Text.Trim())
							{
								this.m_objViewer.m_dtgRegister.UnSelect(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position);
								this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position = i;
								this.m_objViewer.m_dtgRegister.Select(i);
								return;
							}
							break;
					}
				}
			}
			#endregion

			#region 修改挂号
			public long m_lngModifyRegister()
			{
				clsPatientRegister_VO objreg = null;
				clsPatientDetail_VO clsPatientDetail = new clsPatientDetail_VO();
				m_FillVO(out objreg);
			
				long lngarg = clsDomain.m_lngModifyRegister(objreg);
				if(lngarg >0)
				{
					m_ModifyDatagrid();
					int DetailCount = m_objViewer.m_lsvRegDetail.Items.Count;
					for(int i=0;i<DetailCount;i++)
					{
						//					if(decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) == 0
						//						|| decimal.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) == 0) continue;
					
						clsPatientDetail.m_strREGISTERID_CHR = objreg.m_strRegisterID;
						clsPatientDetail.m_strCHARGEID_CHR = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[1].Text;
						clsPatientDetail.m_dblPAYMENT_MNY = double.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text);
						clsPatientDetail.m_fltDISCOUNT_DEC = float.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text);
						lngarg = clsDomain.m_lngModifyRegisterDetail(clsPatientDetail);
					}
				}
				else
				{
					m_DtgFillTXT();
				}
				return lngarg;
			}
			#endregion
			#region 还原退号
			public void m_ResetReg()
			{
				string strRegisterID="";
				DateTime regdate = clsDomain.m_GetServTime().Date;
				try
				{
					strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号ID"].ToString();
				}
				catch
				{
					return;
				}
				int k1=0;//退号次数
				int k2=0;//还原次数
				string strNO=m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["流水号"].ToString();//保存当前选中挂号数据的流水号
				for(int i1=0;i1<m_dvRegister.Count;i1++)
				{
					if(m_dvRegister[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegister[i1]["挂号状态"].ToString().Trim()=="退号")
					{
						k1++;
					}
					if(m_dvRegister[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegister[i1]["挂号状态"].ToString().Trim()=="还原")
					{
						k2++;
					}

				}
				if(k1==0||k2>=k1)
				{
					MessageBox.Show("该挂号已经己还原，不能再还原！","提示");
					return;
				}
				string strReSetRegDate = regdate.ToShortDateString();
				clsController_Security clsSe=new clsController_Security();
				string strResetRegEmpno =  this.m_objViewer.LoginInfo.m_strEmpID;
				string newID="";
				int waitNO=0;
				if(clsDomain.m_lngResetReg(strRegisterID,strResetRegEmpno,strReSetRegDate,out newID,out waitNO)==0) return;
				DataRowView addRow=m_dvRegister.AddNew();
				DataRowView seleRow=(DataRowView)m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex];
				addRow["挂号ID"]=newID;
				addRow["诊疗卡号"]=seleRow["诊疗卡号"];
				addRow["流水号"]=seleRow["流水号"];
				addRow["候诊号"]=waitNO.ToString();
				addRow["挂号类型"]=seleRow["挂号类型"];
				addRow["病人名称"]=seleRow["病人名称"];
				addRow["病人性别"]=seleRow["病人性别"];
				addRow["支付类型"]=seleRow["支付类型"];
				addRow["挂号日期"]=seleRow["挂号日期"];
				addRow["科室名称"]=seleRow["科室名称"];
				addRow["医生名称"]=seleRow["医生名称"];
				addRow["过程状态"]=seleRow["过程状态"];
				addRow["挂号状态"]="还原";
				addRow["病人身份"]=seleRow["病人身份"];
				addRow["就诊地址"]=seleRow["就诊地址"];
				addRow["挂号人工号"]=seleRow["挂号人工号"];
				//			int index = this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position;
				//			this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].RemoveAt(index);
				if(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Count>0)
				{				
					//this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position = index;
					this.m_DtgFillTXT();
					m_GetCurPay();
					m_FillDetail();
					m_getCurPrice();				
				}
			}
			#endregion

		

			#region 退号
			public void m_CancelReg()
			{
				string strRegisterID="";
				try
				{
					strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号ID"].ToString();
				}
				catch
				{
					return;
				}
				int k1=0;//退号次数
				int k2=0;//还原次数
				string strNO=m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["流水号"].ToString();//保存当前选中挂号数据的流水号
				for(int i1=0;i1<m_dvRegister.Count;i1++)
				{
					if(m_dvRegister[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegister[i1]["挂号状态"].ToString().Trim()=="退号")
					{
						k1++;
					}
					if(m_dvRegister[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegister[i1]["挂号状态"].ToString().Trim()=="还原")
					{
						k2++;
					}

				}
				if(k1!=0||k1>k2)
				{
					MessageBox.Show("该挂号已经退号，不能退号！","提示");
					return;
				}
				bool isReMoney;
				string outstr="";
				if(clsDomain.m_lngCheckRegister(strRegisterID,out isReMoney,out outstr)==0)
				{
					if(outstr=="0")
					{
						if(MessageBox.Show("系统检测不到该挂号是否开过处方，是否要断续退号？","退号提示",MessageBoxButtons.YesNo)==DialogResult.No)
							return;
					}
					else
					{
						if(MessageBox.Show("系统检测不到该挂号是否被收过费，是否要断续退号？","退号提示",MessageBoxButtons.YesNo)==DialogResult.No)
							return;
					}
				}
				if(isReMoney)
				{
					if(outstr=="0")
					{
						MessageBox.Show("该挂号已经开过处方，不能再退号！","退号提示");
							return;
					}
					else
					{
						MessageBox.Show("该挂号已经交过费，不能再退号！","退号提示");
							return;
					}
				}
				int index = this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Position;
				string strReturnDate = clsDomain.m_GetServTime().ToShortDateString();
				string strReturnEmpno = this.m_objViewer.LoginInfo.m_strEmpID;
				string newID="";

                string ConfirmID = "";
                frmOPSConfirm fc = new frmOPSConfirm();
                if (fc.ShowDialog() == DialogResult.OK)
                {
                    ConfirmID = fc.Empid;
                }
                else
                {
                    return;
                }

                if (clsDomain.m_lngCancelReg(strRegisterID, strReturnEmpno, strReturnDate, ConfirmID, out newID) == 0)
                {
                    return;
                }

				DataRowView addRow=m_dvRegister.AddNew();
				DataRowView seleRow=(DataRowView)m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex];
				addRow["挂号ID"]=newID;
				addRow["诊疗卡号"]=seleRow["诊疗卡号"];
				addRow["流水号"]=seleRow["流水号"];
				addRow["候诊号"]=seleRow["候诊号"];
				addRow["挂号类型"]=seleRow["挂号类型"];
				addRow["病人名称"]=seleRow["病人名称"];
				addRow["病人性别"]=seleRow["病人性别"];
				addRow["支付类型"]=seleRow["支付类型"];
				addRow["挂号日期"]=seleRow["挂号日期"];
				addRow["科室名称"]=seleRow["科室名称"];
				addRow["医生名称"]=seleRow["医生名称"];
				addRow["过程状态"]=seleRow["过程状态"];
				addRow["挂号状态"]="退号";
				addRow["病人身份"]=seleRow["病人身份"];
				addRow["就诊地址"]=seleRow["就诊地址"];
				addRow["挂号人工号"]=seleRow["挂号人工号"];
			}
			#endregion

			public void m_Filter()
			{
//				switch(this.m_objViewer.m_cmbQulType.SelectedIndex)
//				{
//					case 0 :
//						this.m_dvRegister.RowFilter = "";
//						break;
//					case 1 :
//						this.m_dvRegister.RowFilter = "挂号状态='退号'";
//						break;
//					case 2 :
//						this.m_dvRegister.RowFilter = "过程状态='候诊' and 挂号状态<>'退号'";
//						break;
//					case 3 :				
//						this.m_dvRegister.RowFilter = "挂号状态='预约'";
//						break;
//					case 4 :
//						this.m_dvRegister.RowFilter = "过程状态<>'已结帐'";
//						break;
//					case 5 :
//						this.m_dvRegister.RowFilter = "过程状态='已结帐'";
//						break;
//					case 6 :
//						this.m_dvRegister.RowFilter = "过程状态='取消'";
//						break;
//				}
//				if(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Count != 0)
//				{
//					m_dtRegister_PositionChanged(null,null);
//				}
//				else
//				{
//					this.m_Clear();
//				}
			}

		
		}
	
	
	}


