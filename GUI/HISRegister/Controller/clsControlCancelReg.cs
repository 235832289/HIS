using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using System.Collections;
using System.Drawing;
using com.digitalwave.iCare.middletier.HI;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlRegister 的摘要说明。
	/// </summary>
	public class clsControlCancelReg:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlCancelReg()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDomainControl_Register();
			clsRegister=new clsPatientRegister_VO();
            m_objChargeCal = new clsCalcPatientCharge(string.Empty, string.Empty, 0, this.m_objComInfo.m_strGetHospitalTitle(), 0, 0);
		//	OperatorID=this.m_objViewer.LoginInfo.m_strEmpID;
		}
//		int intcommand=null;
		clsDomainControl_Register clsDomain;
		clsPatientRegister_VO clsRegister;
        private clsCalcPatientCharge m_objChargeCal;
		private enum enumlvwSel:byte
		{
			PatType=1,
			Dept=2,
			RegType=3,
			Doc=4
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmCancelRegister m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmCancelRegister)frmMDI_Child_Base_in;
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
            DTP = DateTime.Now;
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
			int sevTime=DateTime.Now.Hour;
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
		
		#region 打印挂号票 
		private string m_strRegisterID="";
        /// <summary>
        /// 打印挂号票 
        /// </summary>
		public void m_PrintRegister()
		{
            if ((string)this.m_objViewer.m_dtgRegister.Tag == "m_dvRegister")
            {
                if (this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Count == 0) return;
                if (((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["挂号人工号"].ToString() == "总金额")
                {
                    MessageBox.Show("不是有效的挂号数据！");
                    return;
                }
            }
            else
            {
                if (this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Count == 0) return;
                if (((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["挂号人工号"].ToString() == "总金额")
                {
                    MessageBox.Show("不是有效的挂号数据！");
                    return;
                }
 
            }

            #region new code
            string OldNo = "";

            if ((string)this.m_objViewer.m_dtgRegister.Tag == "m_dvRegisterfind")
            {
                OldNo = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["发票号"].ToString();
            }
            else
            {
                OldNo = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["发票号"].ToString();
            }

            frmRegisterRepeatPrt f = new frmRegisterRepeatPrt(OldNo);
            if (f.ShowDialog() == DialogResult.OK)
            {
                DataTable dtbSource = new DataTable("printtemptable");
                dtbSource.Columns.Add("varchar1");
                dtbSource.Columns.Add("patientname");
                dtbSource.Columns.Add("date");
                dtbSource.Columns.Add("orderno");
                dtbSource.Columns.Add("registerno");
                dtbSource.Columns.Add("address");
                dtbSource.Columns.Add("registertype");
                dtbSource.Columns.Add("strDiagdept");
                dtbSource.Columns.Add("strEmpt");
                dtbSource.Columns.Add("doctorName");
                dtbSource.Columns.Add("patienCard");
                dtbSource.Columns.Add("txtNO");
                dtbSource.Columns.Add("decimal1", typeof(decimal));
                dtbSource.Columns.Add("decimal2", typeof(decimal));
                dtbSource.Columns.Add("txtAvailDays");
                dtbSource.Columns.Add("txtRepeatNo");
                dtbSource.Rows.Add(new object[] { });
                dtbSource.Rows[0][12] = 0;
                dtbSource.Rows[0][13] = 0;

                if ((string)this.m_objViewer.m_dtgRegister.Tag == "m_dvRegisterfind")
                {
                    Decimal meney = 0;
                    Decimal meney2 = 0;
                    meney = Convert.ToDecimal(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)[21].ToString());
                    meney2 = Convert.ToDecimal(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)[22].ToString());
                    string strDate = "";
                    if (((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["预约日期"].ToString().Trim() != "")
                    {
                        strDate = "预约" + ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["预约日期"].ToString().Trim();
                    }
                    else
                    {
                        strDate = Convert.ToDateTime(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["挂号日期"].ToString()).ToShortDateString();
                    }

                    dtbSource.Rows[0][0] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["病人名称"].ToString();
                    dtbSource.Rows[0][1] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["病人名称"].ToString();
                    dtbSource.Rows[0][2] = strDate;
                    dtbSource.Rows[0][3] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["候诊号"].ToString();
                    dtbSource.Rows[0][4] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["流水号"].ToString();
                    dtbSource.Rows[0][5] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["就诊地址"].ToString();
                    dtbSource.Rows[0][6] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["挂号类型"].ToString();
                    dtbSource.Rows[0][7] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["科室名称"].ToString();
                    dtbSource.Rows[0][8] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["挂号人工号"].ToString();
                    dtbSource.Rows[0][9] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["医生名称"].ToString();
                    dtbSource.Rows[0][10] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["诊疗卡号"].ToString();

                    dtbSource.Rows[0][12] = meney;
                    dtbSource.Rows[0][13] = meney2;
                    dtbSource.Rows[0][14] = AvailDays;

                    if (f.PrnType == "1")
                    {
                        dtbSource.Rows[0][11] = OldNo;
                        dtbSource.Rows[0][15] = "";
                    }
                    else if (f.PrnType == "2")
                    {
                        dtbSource.Rows[0][11] = f.NewNo;
                        dtbSource.Rows[0][15] = "*REPEAT(" + OldNo + ")*";

                        long l = clsDomain.m_lngSaveinvorepeatprninfo("2", ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind, null].Current)["挂号ID"].ToString(), OldNo, f.NewNo, this.m_objViewer.LoginInfo.m_strEmpID);
                        if (l <= 0)
                        {
                            MessageBox.Show("保存重打挂号发票信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                else
                {
                    Decimal meney = 0;
                    Decimal meney2 = 0;
                    meney = Convert.ToDecimal(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)[21].ToString());
                    if (((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)[22].ToString().Trim() != string.Empty)
                    {
                        meney2 = Convert.ToDecimal(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)[22].ToString());
                    }
                    string strDate = "";
                    if (((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["预约日期"].ToString().Trim() != "")
                    {
                        strDate = "预约" + ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["预约日期"].ToString().Trim();
                    }
                    else
                    {
                        strDate = Convert.ToDateTime(((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["挂号日期"].ToString()).ToShortDateString();
                    }

                    dtbSource.Rows[0][0] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["病人名称"].ToString();
                    dtbSource.Rows[0][1] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["病人名称"].ToString();
                    dtbSource.Rows[0][2] = strDate;
                    dtbSource.Rows[0][3] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["候诊号"].ToString();
                    dtbSource.Rows[0][4] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["流水号"].ToString();
                    dtbSource.Rows[0][5] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["就诊地址"].ToString();
                    dtbSource.Rows[0][6] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["挂号类型"].ToString();
                    dtbSource.Rows[0][7] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["科室名称"].ToString();
                    dtbSource.Rows[0][8] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["挂号人工号"].ToString();
                    dtbSource.Rows[0][9] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["医生名称"].ToString();
                    dtbSource.Rows[0][10] = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["诊疗卡号"].ToString();

                    dtbSource.Rows[0][12] = meney;
                    dtbSource.Rows[0][13] = meney2;
                    dtbSource.Rows[0][14] = AvailDays;

                    if (f.PrnType == "1")
                    {
                        dtbSource.Rows[0][11] = OldNo;
                        dtbSource.Rows[0][15] = "";
                    }
                    else if (f.PrnType == "2")
                    {
                        dtbSource.Rows[0][11] = f.NewNo;
                        dtbSource.Rows[0][15] = "*REPEAT(" + OldNo + ")*";

                        long l = clsDomain.m_lngSaveinvorepeatprninfo("2", ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister, null].Current)["挂号ID"].ToString(), OldNo, f.NewNo, this.m_objViewer.LoginInfo.m_strEmpID);
                        if (l <= 0)
                        {
                            MessageBox.Show("保存重打挂号发票信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }

                new FrmShowPrint().m_PrintRegister11(dtbSource);
            }
            #endregion
        }
		#endregion

        #region 获取挂号有效天数
        /// <summary>
        /// 获取挂号有效天数
        /// </summary>
        private string AvailDays = "一";
        /// <summary>
        /// 获取挂号有效天数
        /// </summary>
        public void m_mthGetAvailDays()
        {
            clsDcl_DoctorWorkstation objDoctor = new clsDcl_DoctorWorkstation();
            DataTable dt;
            long ret = objDoctor.m_lngGetWSParm("0058", out dt);		//0058 挂号有效天数

            if (ret > 0 && dt.Rows.Count > 0)
            {
                string[] bs = new string[10] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

                AvailDays = bs[Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]) - 1];
            }
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
				DateTime sevTime=Convert.ToDateTime(DateTime.Now.ToShortDateString());
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
				this.clsRegister.m_strRegisterDate=DateTime.Now.ToShortDateString();
			}
			return bolReturn;
		}
		public bool bnlChekcBirth()
		{
			bool bolReturn=true;
			if(m_objViewer.m_dtpBirth.Value>DateTime.Now)
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
		/// <summary>
		/// 查找挂号表
		/// </summary>
		System.Data.DataTable dtSource = new System.Data.DataTable();
		public void m_QulReg()
		{
			if(this.m_dvRegister!=null||this.m_dvRegister.Table.Rows.Count==0)
			{
				this.m_objViewer.m_cmbQulType.Text = "全部";
				this.m_objViewer.m_dtgRegister.DataBindings.Clear();
				try
				{
					this.m_dvRegister.Table.Clear();
				}
				catch
                {
                }

                if (this.m_objViewer.Scope == "0")
                {
                    clsDomain.m_lngQulRegByDateNew(this.m_objViewer.m_datFirstdate.Value.ToShortDateString(), this.m_objViewer.m_datLastdate.Value.ToShortDateString(), out dtSource, this.m_objViewer.LoginInfo.m_strEmpID, "0");
                }
                else if (this.m_objViewer.Scope == "1")
                {
                    clsDomain.m_lngQulRegByDateNew(this.m_objViewer.m_datFirstdate.Value.ToShortDateString(), this.m_objViewer.m_datLastdate.Value.ToShortDateString(), out dtSource, this.m_objViewer.LoginInfo.m_strEmpID, "1");
                }
                //if(dtSource.Rows.Count ==0)
                //{
                //    MessageBox.Show("没有找到符合条件的挂号记录！","查询提示");
                //    return;
                //}
				dtSource.Columns[0].ColumnName = "挂号ID";
				dtSource.Columns[1].ColumnName = "诊疗卡号";
				dtSource.Columns[2].ColumnName = "发票号";
				dtSource.Columns[3].ColumnName = "流水号";
				dtSource.Columns[4].ColumnName = "候诊号";
				dtSource.Columns[5].ColumnName = "挂号类型";
				dtSource.Columns[6].ColumnName = "病人名称";
				dtSource.Columns[7].ColumnName = "病人性别";
				dtSource.Columns[8].ColumnName = "支付类型";
				dtSource.Columns[9].ColumnName = "挂号日期";
                dtSource.Columns[10].ColumnName = "预约日期";
				dtSource.Columns[11].ColumnName = "科室名称";
				dtSource.Columns[12].ColumnName = "医生名称";
				dtSource.Columns[13].ColumnName = "过程状态";
				dtSource.Columns[14].ColumnName = "挂号状态";
				dtSource.Columns[15].ColumnName = "退号人工号";
				dtSource.Columns[16].ColumnName = "退号日期";
				dtSource.Columns[17].ColumnName = "记录日期";
				dtSource.Columns[18].ColumnName = "病人身份";
				dtSource.Columns[19].ColumnName = "就诊地址";
				dtSource.Columns[20].ColumnName = "挂号人工号";
				dtSource.Columns[21].ColumnName = "挂号费";
				dtSource.Columns[22].ColumnName = "诊疗费";
				dtSource.Columns[25].ColumnName = "工本费";
				dtSource.Columns[23].ColumnName = "挂号费优惠ID";
                dtSource.Columns[24].ColumnName = "诊疗费优惠ID";
                dtSource.Columns[26].ColumnName = "工本费优惠ID";
				#region 统计金额
				dtSource.Columns.Add("合计金额");
				for(int j2=0;j2<dtSource.Rows.Count;j2++)
				{
					try 
					{
						double toMoney=0;

							if(dtSource.Rows[j2]["挂号状态"].ToString()=="退号")
							{
								if(dtSource.Rows[j2]["挂号费"].ToString()!=""&&dtSource.Rows[j2]["挂号费"].ToString()!="0")
									dtSource.Rows[j2]["挂号费"]="-"+dtSource.Rows[j2]["挂号费"].ToString();
								if(dtSource.Rows[j2]["诊疗费"].ToString()!=""&&dtSource.Rows[j2]["诊疗费"].ToString()!="0")
									dtSource.Rows[j2]["诊疗费"]="-"+dtSource.Rows[j2]["诊疗费"].ToString();
								if(dtSource.Rows[j2]["工本费"].ToString()!=""&&dtSource.Rows[j2]["工本费"].ToString()!="0")
									dtSource.Rows[j2]["工本费"]="-"+dtSource.Rows[j2]["工本费"].ToString();
								toMoney=Convert.ToDouble(dtSource.Rows[j2]["挂号费"])+Convert.ToDouble(dtSource.Rows[j2]["诊疗费"])+Convert.ToDouble(dtSource.Rows[j2]["工本费"]);
							}
							else
							{
								toMoney=Convert.ToDouble(dtSource.Rows[j2]["挂号费"])+Convert.ToDouble(dtSource.Rows[j2]["诊疗费"])+Convert.ToDouble(dtSource.Rows[j2]["工本费"]);
							}
						dtSource.Rows[j2]["合计金额"]=toMoney;

					}
					catch
					{

					}
				}
                if (dtSource.Rows.Count > 0)
                {
                    #region 加入统计行
                    DataRow newRow = dtSource.NewRow();
                    newRow["挂号人工号"] = "总金额";
                    DataTable tolTb = new DataTable();
                    tolTb.Columns.Add("money");
                    for (int k4 = 0; k4 < 4; k4++)
                    {
                        if (k4 == 3)
                        {
                            k4 += 3;
                        }
                        DataRow newRow1 = tolTb.NewRow();
                        double tolMoney = 0;
                        for (int f6 = 0; f6 < dtSource.Rows.Count; f6++)
                        {
                            if (dtSource.Rows[f6][21 + k4].ToString() != "")
                            {
                                tolMoney += Convert.ToDouble(dtSource.Rows[f6][21 + k4].ToString());
                            }
                        }
                        newRow1["money"] = tolMoney;
                        tolTb.Rows.Add(newRow1);
                        newRow[21 + k4] = tolMoney;
                    }
                    dtSource.Rows.Add(newRow);
                    #endregion
                }

                #endregion
                    this.m_dvRegister = dtSource.DefaultView;
                    //				dtSource.Clear();
                    this.m_objViewer.m_dtgRegister.SetDataBinding(this.m_dvRegister, null);
                    this.m_objViewer.m_dtgRegister.Tag = "m_dvRegister";
                    this.m_objViewer.m_dtgRegister.m_SetDgrStyle();
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["诊疗卡号"].Width = 80;
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["流水号"].Width = 100;
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["发票号"].Width = 90;
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["候诊号"].Width = 50;
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["挂号日期"].Width = 80;
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["预约日期"].Width = 110;
                    this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["记录日期"].Width = 130;
                    //				this.m_objViewer.m_OmnipotenceQul.m_SetData(this.m_objViewer.m_dtgRegister,this.m_dvRegister,"流水号");
                
				#region 填充Combox
				if(this.m_objViewer.comboBoxField.Items.Count==0)
				{
					int j6=0;
					foreach(DataColumn dc in dtSource.Columns)
					{
						j6++;
						if(dc.ColumnName.IndexOf("ID")>=0)
						{
							continue;
						}
						if(dc.ColumnName=="就诊地址"||dc.ColumnName=="病人性别"||dc.ColumnName=="候诊号"||dc.ColumnName=="支付类型")
							continue;
						else if(j6<=21)
							this.m_objViewer.comboBoxField.Items.Add(dc.ColumnName);
						if(this.m_objViewer.comboBoxField.Items.Count>0)
							this.m_objViewer.comboBoxField.SelectedIndex=0;
					}
				}
				#endregion
				m_dtRegister_PositionChanged(null,null);
			}

        }
        //#region 根据字段查找挂号表
        //public void m_mthQueryReg(string[] m_strArr)
        //{
        //    if (this.m_dvRegister != null || this.m_dvRegister.Table.Rows.Count == 0)
        //    {
              
        //        this.m_objViewer.m_dtgRegister.DataBindings.Clear();
        //        try
        //        {
        //            this.m_dvRegister.Table.Clear();
        //        }
        //        catch
        //        {
        //        }
        //        clsDomain.m_lngQulRegByFieldNew(m_strArr, out dtSource);
        //        dtSource.Columns[0].ColumnName = "挂号ID";
        //        dtSource.Columns[1].ColumnName = "诊疗卡号";
        //        dtSource.Columns[2].ColumnName = "发票号";
        //        dtSource.Columns[3].ColumnName = "流水号";
        //        dtSource.Columns[4].ColumnName = "候诊号";
        //        dtSource.Columns[5].ColumnName = "挂号类型";
        //        dtSource.Columns[6].ColumnName = "病人名称";
        //        dtSource.Columns[7].ColumnName = "病人性别";
        //        dtSource.Columns[8].ColumnName = "支付类型";
        //        dtSource.Columns[9].ColumnName = "挂号日期";
        //        dtSource.Columns[10].ColumnName = "预约日期";
        //        dtSource.Columns[11].ColumnName = "科室名称";
        //        dtSource.Columns[12].ColumnName = "医生名称";
        //        dtSource.Columns[13].ColumnName = "过程状态";
        //        dtSource.Columns[14].ColumnName = "挂号状态";
        //        dtSource.Columns[15].ColumnName = "退号人工号";
        //        dtSource.Columns[16].ColumnName = "退号日期";
        //        dtSource.Columns[17].ColumnName = "记录日期";
        //        dtSource.Columns[18].ColumnName = "病人身份";
        //        dtSource.Columns[19].ColumnName = "就诊地址";
        //        dtSource.Columns[20].ColumnName = "挂号人工号";
        //        dtSource.Columns[21].ColumnName = "挂号费";
        //        dtSource.Columns[22].ColumnName = "诊疗费";
        //        dtSource.Columns[25].ColumnName = "工本费";
        //        dtSource.Columns[23].ColumnName = "挂号费优惠ID";
        //        dtSource.Columns[24].ColumnName = "诊疗费优惠ID";
        //        dtSource.Columns[26].ColumnName = "工本费优惠ID";
        //        #region 统计金额
        //        dtSource.Columns.Add("合计金额");
        //        for (int j2 = 0; j2 < dtSource.Rows.Count; j2++)
        //        {
        //            try
        //            {
        //                double toMoney = 0;

        //                if (dtSource.Rows[j2]["挂号状态"].ToString() == "退号")
        //                {
        //                    if (dtSource.Rows[j2]["挂号费"].ToString() != "" && dtSource.Rows[j2]["挂号费"].ToString() != "0")
        //                        dtSource.Rows[j2]["挂号费"] = "-" + dtSource.Rows[j2]["挂号费"].ToString();
        //                    if (dtSource.Rows[j2]["诊疗费"].ToString() != "" && dtSource.Rows[j2]["诊疗费"].ToString() != "0")
        //                        dtSource.Rows[j2]["诊疗费"] = "-" + dtSource.Rows[j2]["诊疗费"].ToString();
        //                    if (dtSource.Rows[j2]["工本费"].ToString() != "" && dtSource.Rows[j2]["工本费"].ToString() != "0")
        //                        dtSource.Rows[j2]["工本费"] = "-" + dtSource.Rows[j2]["工本费"].ToString();
        //                    toMoney = Convert.ToDouble(dtSource.Rows[j2]["挂号费"]) + Convert.ToDouble(dtSource.Rows[j2]["诊疗费"]) + Convert.ToDouble(dtSource.Rows[j2]["工本费"]);
        //                }
        //                else
        //                {
        //                    toMoney = Convert.ToDouble(dtSource.Rows[j2]["挂号费"]) + Convert.ToDouble(dtSource.Rows[j2]["诊疗费"]) + Convert.ToDouble(dtSource.Rows[j2]["工本费"]);
        //                }
        //                dtSource.Rows[j2]["合计金额"] = toMoney;

        //            }
        //            catch
        //            {

        //            }
        //        }
        //        if (dtSource.Rows.Count > 0)
        //        {
        //            #region 加入统计行
        //            DataRow newRow = dtSource.NewRow();
        //            newRow["挂号人工号"] = "总金额";
        //            DataTable tolTb = new DataTable();
        //            tolTb.Columns.Add("money");
        //            for (int k4 = 0; k4 < 4; k4++)
        //            {
        //                if (k4 == 3)
        //                {
        //                    k4 += 3;
        //                }
        //                DataRow newRow1 = tolTb.NewRow();
        //                double tolMoney = 0;
        //                for (int f6 = 0; f6 < dtSource.Rows.Count; f6++)
        //                {
        //                    if (dtSource.Rows[f6][21 + k4].ToString() != "")
        //                    {
        //                        tolMoney += Convert.ToDouble(dtSource.Rows[f6][21 + k4].ToString());
        //                    }
        //                }
        //                newRow1["money"] = tolMoney;
        //                tolTb.Rows.Add(newRow1);
        //                newRow[21 + k4] = tolMoney;
        //            }
        //            dtSource.Rows.Add(newRow);
        //            #endregion
        //        }

        //        #endregion
        //        this.m_dvRegister = dtSource.DefaultView;
        //        //				dtSource.Clear();
        //        this.m_objViewer.m_dtgRegister.SetDataBinding(this.m_dvRegister, null);
        //        this.m_objViewer.m_dtgRegister.Tag = "m_dvRegister";
        //        this.m_objViewer.m_dtgRegister.m_SetDgrStyle();
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["诊疗卡号"].Width = 80;
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["流水号"].Width = 100;
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["发票号"].Width = 90;
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["候诊号"].Width = 50;
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["挂号日期"].Width = 80;
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["预约日期"].Width = 110;
        //        this.m_objViewer.m_dtgRegister.TableStyles[0].GridColumnStyles["记录日期"].Width = 130;
        //        //				this.m_objViewer.m_OmnipotenceQul.m_SetData(this.m_objViewer.m_dtgRegister,this.m_dvRegister,"流水号");

        //        #region 填充Combox
        //        if (this.m_objViewer.comboBoxField.Items.Count == 0)
        //        {
        //            int j6 = 0;
        //            foreach (DataColumn dc in dtSource.Columns)
        //            {
        //                j6++;
        //                if (dc.ColumnName.IndexOf("ID") >= 0)
        //                {
        //                    continue;
        //                }
        //                if (dc.ColumnName == "就诊地址" || dc.ColumnName == "病人性别" || dc.ColumnName == "候诊号" || dc.ColumnName == "支付类型"||dc.ColumnName=="挂号状态")
        //                    continue;
        //                else if (j6 <= 21)
        //                    this.m_objViewer.comboBoxField.Items.Add(dc.ColumnName);
        //                if (this.m_objViewer.comboBoxField.Items.Count > 0)
        //                    this.m_objViewer.comboBoxField.SelectedIndex = 0;
        //            }
        //        }
        //        #endregion
        //        m_dtRegister_PositionChanged(null, null);
        //    }

        //}
        //#endregion 
        #region 查找数据
        DataTable findTB=new DataTable();
		DataView  m_dvRegisterfind=new DataView();
		public void m_lngFindDate()
		{
			if(this.m_objViewer.TextBoxValue.Text=="") return;
			if(this.m_dvRegister.Count>0)
			{
				#region 初始化查找数据表
				try
				{
					findTB=dtSource.Clone();
				}
				catch
				{
				}
				#endregion
				findTB.Clear();
				for(int i1=0;i1<this.m_dvRegister.Count;i1++)
				{
						if(this.m_dvRegister[i1][this.m_objViewer.comboBoxField.Text.Trim()].ToString().IndexOf(this.m_objViewer.TextBoxValue.Text.Trim(),0)==0)
						{
							DataRow newRow=findTB.NewRow();
							newRow["挂号ID"]=this.m_dvRegister[i1]["挂号ID"];
							newRow["诊疗卡号"]=this.m_dvRegister[i1]["诊疗卡号"];
							newRow["发票号"]=this.m_dvRegister[i1]["发票号"];
							newRow["流水号"]=this.m_dvRegister[i1]["流水号"];
							newRow["候诊号"]=this.m_dvRegister[i1]["候诊号"];
							newRow["挂号类型"]=this.m_dvRegister[i1]["挂号类型"];
							newRow["病人名称"]=this.m_dvRegister[i1]["病人名称"];
							newRow["病人性别"]=this.m_dvRegister[i1]["病人性别"];
							newRow["支付类型"]=this.m_dvRegister[i1]["支付类型"];
							newRow["挂号日期"]=this.m_dvRegister[i1]["挂号日期"];
                            newRow["预约日期"] = this.m_dvRegister[i1]["预约日期"];
							newRow["科室名称"]=this.m_dvRegister[i1]["科室名称"];
							newRow["医生名称"]=this.m_dvRegister[i1]["医生名称"];
							newRow["过程状态"]=this.m_dvRegister[i1]["过程状态"];
							newRow["挂号状态"]=this.m_dvRegister[i1]["挂号状态"];
							newRow["退号人工号"]=this.m_dvRegister[i1]["退号人工号"];
							newRow["退号日期"]=this.m_dvRegister[i1]["退号日期"];
							newRow["记录日期"]=this.m_dvRegister[i1]["记录日期"];
							newRow["病人身份"]=this.m_dvRegister[i1]["病人身份"];
							newRow["就诊地址"]=this.m_dvRegister[i1]["就诊地址"];
							newRow["挂号人工号"]=this.m_dvRegister[i1]["挂号人工号"];
							newRow["挂号费"]=this.m_dvRegister[i1]["挂号费"];
							newRow["诊疗费"]=this.m_dvRegister[i1]["诊疗费"];
							newRow["工本费"]=this.m_dvRegister[i1]["工本费"];
							newRow["挂号费优惠ID"]=this.m_dvRegister[i1]["挂号费优惠ID"];
							newRow["诊疗费优惠ID"]=this.m_dvRegister[i1]["诊疗费优惠ID"];
							newRow["工本费优惠ID"]=this.m_dvRegister[i1]["工本费优惠ID"];
							newRow["合计金额"]=this.m_dvRegister[i1]["合计金额"];
							findTB.Rows.Add(newRow);
						}
					}
					#region 加入统计行
					DataRow newRow1=findTB.NewRow();
					newRow1["挂号人工号"]="总金额";
				    double AllMoney=0;
					for(int k4=0;k4<4;k4++)
					{
						if(k4==3)
							k4+=3;
						double tolMoney=0;
						for(int f6=0;f6<findTB.Rows.Count;f6++)
						{
							try
							{
								double kk=Convert.ToDouble(findTB.Rows[f6][21+k4].ToString());
								tolMoney+=kk;
							}
							catch
							{
							}
						}
						newRow1[21+k4]=tolMoney;
						AllMoney+=tolMoney;
					}
					findTB.Rows.Add(newRow1);
					#endregion
					m_dvRegisterfind=findTB.DefaultView;
					this.m_objViewer.m_dtgRegister.SetDataBinding(m_dvRegisterfind,null);
					this.m_objViewer.m_dtgRegister.Tag="m_dvRegisterfind";
				}
			this.m_objViewer.TextBoxValue.Clear();
		}
		#endregion
		private void m_dtRegister_PositionChanged(object send,System.EventArgs e)
		{
//			this.m_DtgFillTXT();
//			m_FillDetail();
//			m_GetCurPay();
			
			//m_getCurPrice();
		}
		#endregion

		#region 填充明细
		/// <summary>
		/// 填充明细
		/// </summary>
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
			DataTable dt = new DataTable();
			switch(((TextBox)sender).Name)
			{
				case "m_txtCard":
					clsDomain.m_lngQulRegByCol(out dt,"CARDID",this.m_objViewer.m_txtCard.Text,"1");
					break;
				case "m_txtName":
					clsDomain.m_lngQulRegByCol(out dt,"NAME",this.m_objViewer.m_txtName.Text,"1");
					break;
				case "m_txtRegisterNo":
					clsDomain.m_lngQulRegByCol(out dt,"REGNO",this.m_objViewer.m_txtRegisterNo.Text,"1");
					break;
			}
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
		/// <summary>
		/// 还原退号
		/// </summary>
		public void m_ResetReg()
		{
			if(intSetStatus==-2)
			{
				clsDomain.m_lngGetSetStatus(out intSetStatus);
			}
			string strRegisterID="";
			DateTime regdate = DateTime.Now.Date;
			try
			{
				if((string)this.m_objViewer.m_dtgRegister.Tag=="m_dvRegister")
					strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号ID"].ToString();
				else
					strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind,null].Current)["挂号ID"].ToString();
			}
			catch
			{
				return;
			}
			if((string)this.m_objViewer.m_dtgRegister.Tag=="m_dvRegister")
			{
//				if(intSetStatus==0)
//				{
//					if(m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["挂号人工号"].ToString().Trim()==this.m_objViewer.LoginInfo.m_strEmpNo||m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["退号人工号"].ToString().Trim()==this.m_objViewer.LoginInfo.m_strEmpNo)
//					{
//						MessageBox.Show("禁止还原它人的退号！","非法操作");
//						return;
//					}
//				}
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
			}
			else
			{
//				if(m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["挂号人工号"].ToString().Trim()==this.m_objViewer.LoginInfo.m_strEmpNo||m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["退号人工号"].ToString().Trim()==this.m_objViewer.LoginInfo.m_strEmpNo)
//				{
//					MessageBox.Show("禁止还原它人的退号！","非法操作");
//					return;
//				}
				int k1=0;//退号次数
				int k2=0;//还原次数
				string strNO=m_dvRegisterfind[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["流水号"].ToString();//保存当前选中挂号数据的流水号
				for(int i1=0;i1<m_dvRegisterfind.Count;i1++)
				{
					if(m_dvRegisterfind[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegisterfind[i1]["挂号状态"].ToString().Trim()=="退号")
					{
						k1++;
					}
					if(m_dvRegisterfind[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegisterfind[i1]["挂号状态"].ToString().Trim()=="还原")
					{
						k2++;
					}

				}
				if(k1==0||k2>=k1)
				{
					MessageBox.Show("该挂号已经己还原，不能再还原！","提示");
					return;
				}
			}
			string strReSetRegDate = regdate.ToShortDateString();
			clsController_Security clsSe=new clsController_Security();
			string strResetRegEmpno =  this.m_objViewer.LoginInfo.m_strEmpID;
			string newID="";
			int waitNO=0;
			if(clsDomain.m_lngResetReg(strRegisterID,strResetRegEmpno,strReSetRegDate,out newID,out waitNO)==0) return;

			if((string)this.m_objViewer.m_dtgRegister.Tag=="m_dvRegister")
			{
				for(int f2=0;f2<m_dvRegister.Count;f2++)
				{
					if(m_dvRegister[f2]["挂号人工号"].ToString().Trim()=="总金额")
					{
						m_dvRegister.Delete(f2);
					}
				}
				DataRowView addRow=m_dvRegister.AddNew();
				DataRowView seleRow=(DataRowView)m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex];
				addRow["挂号ID"]=newID;
				addRow["诊疗卡号"]=seleRow["诊疗卡号"];
				addRow["发票号"]=seleRow["发票号"];
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
				addRow["退号人工号"]="";
				addRow["记录日期"]=seleRow["记录日期"];
				addRow["病人身份"]=seleRow["病人身份"];
				addRow["就诊地址"]=seleRow["就诊地址"];
				addRow["挂号人工号"]=this.m_objViewer.LoginInfo.m_strEmpNo;
				int i1;
				try
				{
					for(i1=20;i1<m_dvRegister.Table.Columns.Count;i1++)
					{
						addRow[i1]=Math.Abs(Convert.ToInt32(seleRow[i1].ToString()));
					}
					DataRowView addRowTol=m_dvRegister.AddNew();
					for(int j3=19;j3<i1;j3++)
					{
						double tolMoney=0;
						for(int f2=0;f2<m_dvRegister.Table.Rows.Count;f2++)
						{
							tolMoney+=Convert.ToDouble(m_dvRegister.Table.Rows[f2][j3].ToString());
						}
						addRowTol[j3]=tolMoney;
					}
					addRowTol["挂号人工号"]="总金额";
				}
				catch
				{
				}
			}
			else
			{
				for(int f2=0;f2<m_dvRegisterfind.Count;f2++)
				{
					if(m_dvRegisterfind[f2]["挂号人工号"].ToString().Trim()=="总金额")
					{
						m_dvRegisterfind.Delete(f2);
					}
				}
				DataRowView addRow=m_dvRegisterfind.AddNew();
				DataRowView seleRow=(DataRowView)m_dvRegisterfind[this.m_objViewer.m_dtgRegister.CurrentRowIndex];
				addRow["挂号ID"]=newID;
				addRow["诊疗卡号"]=seleRow["诊疗卡号"];
				addRow["发票号"]=seleRow["发票号"];
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
				addRow["退号人工号"]="";
				addRow["记录日期"]=seleRow["记录日期"];
				addRow["病人身份"]=seleRow["病人身份"];
				addRow["就诊地址"]=seleRow["就诊地址"];
				addRow["挂号人工号"]=seleRow["挂号人工号"];
				int i1;
				for(i1=20;i1<m_dvRegisterfind.Table.Columns.Count;i1++)
				{
					addRow[i1]=Math.Abs(Convert.ToInt32(seleRow[i1].ToString()));
				}
				DataRowView addRowTol=m_dvRegisterfind.AddNew();
				for(int j3=20;j3<i1;j3++)
				{
					double tolMoney=0;
					for(int f2=0;f2<m_dvRegisterfind.Table.Rows.Count;f2++)
					{
						tolMoney+=Convert.ToDouble(m_dvRegisterfind.Table.Rows[f2][j3].ToString());
					}
					addRowTol[j3]=tolMoney;
				}
				addRowTol["挂号人工号"]="总金额";

			}
		}
		#endregion

		#region 退号
		/// <summary>
		/// 保存退号的状态
		/// </summary>
		int intSetStatus=-2;
		/// <summary>
		/// 退号
		/// </summary>
		public void m_CancelReg()
		{
			if(intSetStatus==-2)
			{
				clsDomain.m_lngGetSetStatus(out intSetStatus);
			}
			string strRegisterID="";
			try
			{
				if((string)this.m_objViewer.m_dtgRegister.Tag=="m_dvRegister")
				    strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Current)["挂号ID"].ToString();
				else
					strRegisterID = ((DataRowView)this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegisterfind,null].Current)["挂号ID"].ToString();
			}
			catch
			{
				return;
			}
			if((string)this.m_objViewer.m_dtgRegister.Tag=="m_dvRegister")
			{
				if(intSetStatus==0)
				{
					if(m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["挂号人工号"].ToString().Trim()!=this.m_objViewer.LoginInfo.m_strEmpNo)
					{
						MessageBox.Show("禁止退其他人的挂号！","非法操作");
						return;
					}
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
				if(k1>0&&k1>k2)
				{
					MessageBox.Show("该挂号已经退号，不能退号！","提示");
					return;
				}
			}
			else
			{
				if(m_dvRegisterfind[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["挂号人工号"].ToString().Trim()!=this.m_objViewer.LoginInfo.m_strEmpNo)
				{
					MessageBox.Show("不可以退别人的号！","非法操作");
					return;
				}
				int k1=0;//退号次数
				int k2=0;//还原次数
				string strNO=m_dvRegisterfind[this.m_objViewer.m_dtgRegister.CurrentRowIndex]["流水号"].ToString();//保存当前选中挂号数据的流水号
				for(int i1=0;i1<m_dvRegisterfind.Count;i1++)
				{
					if(m_dvRegisterfind[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegisterfind[i1]["挂号状态"].ToString().Trim()=="退号")
					{
						k1++;
					}
					if(m_dvRegisterfind[i1]["流水号"].ToString().Trim()==strNO.Trim()&&m_dvRegisterfind[i1]["挂号状态"].ToString().Trim()=="还原")
					{
						k2++;
					}

				}
				if(k1>0&&k1>k2)
				{
					MessageBox.Show("该挂号已经退号，不能退号！","提示");
					return;
				}
			}
			bool isReMoney;
			string outstr="";
			if(clsDomain.m_lngCheckRegister(strRegisterID,out isReMoney,out outstr)==0)
			{
				if(outstr=="0")
				{
					if(MessageBox.Show("系统检测不到该挂号是否被收过费，是否要断续退号？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
						return;
				}
				else
				{
					if(MessageBox.Show("系统检测不到该挂号是否被收过费，是否要断续退号？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
						return;
				}
			}
			if(isReMoney)
			 {
				if(outstr=="0")
				{
					MessageBox.Show("该挂号已经开过处方，不能再退号！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
				}
				else
				{
					MessageBox.Show("该挂号已经交过费，不能再退号！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
						return;
				}
			 }

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

			string strReturnDate = DateTime.Now.ToShortDateString();
			string strReturnEmpno = this.m_objViewer.LoginInfo.m_strEmpID;
			string strReturnno= this.m_objViewer.LoginInfo.m_strEmpNo;
			string newID="";
            if (clsDomain.m_lngCancelReg(strRegisterID, strReturnEmpno, strReturnDate, ConfirmID, out newID) == 0)
            {
                return;
            }

			if((string)this.m_objViewer.m_dtgRegister.Tag=="m_dvRegister")
			{
				for(int f2=0;f2<m_dvRegister.Count;f2++)
				{
					if(m_dvRegister[f2]["挂号人工号"].ToString().Trim()=="总金额")
					{
						m_dvRegister.Delete(f2);
					}
				}
				DataRowView addRow=m_dvRegister.AddNew();
                try
                {
					DataRowView seleRow=(DataRowView)m_dvRegister[this.m_objViewer.m_dtgRegister.CurrentRowIndex];
					addRow["挂号ID"]=newID;
					addRow["诊疗卡号"]=seleRow["诊疗卡号"];
					addRow["发票号"]=seleRow["发票号"];
					addRow["流水号"]=seleRow["流水号"];
					addRow["挂号类型"]=seleRow["挂号类型"];
					addRow["病人名称"]=seleRow["病人名称"];
					addRow["病人性别"]=seleRow["病人性别"];
					addRow["支付类型"]=seleRow["支付类型"];
					addRow["挂号日期"]=seleRow["挂号日期"];
					addRow["科室名称"]=seleRow["科室名称"];
					addRow["医生名称"]=seleRow["医生名称"];
					addRow["过程状态"]=seleRow["过程状态"];
					addRow["挂号状态"]="退号";
					addRow["退号人工号"]=strReturnno;
					addRow["退号日期"]=strReturnDate;
					addRow["记录日期"]=seleRow["记录日期"];
					addRow["病人身份"]=seleRow["病人身份"];
					addRow["就诊地址"]=seleRow["就诊地址"];
					addRow["挂号人工号"]=seleRow["挂号人工号"];
					int i1;
					for(i1=21;i1<m_dvRegister.Table.Columns.Count;i1++)
					{
						addRow[i1]="-"+Math.Abs(Convert.ToDouble(seleRow[i1].ToString()));
					}
					DataRowView addRowTol=m_dvRegister.AddNew();
					try
					{
						for(int j3=20;j3<i1;j3++)
						{
							double tolMoney=0;
							for(int f2=0;f2<m_dvRegister.Table.Rows.Count;f2++)
							{
								tolMoney+=Convert.ToDouble(m_dvRegister.Table.Rows[f2][j3].ToString());
							}
							addRowTol[j3]=tolMoney;
						}
					}
					catch
					{
					}
					addRowTol["挂号人工号"]="总金额";
                }
                catch
                {
                    MessageBox.Show("退号系统出错！", "系统提示");
                    return;
                }

                //设置当前行
                for (int i = 0; i < m_dvRegister.Count; i++)
                {
                    if (m_dvRegister[i]["挂号ID"].ToString() == newID)
                    {
                        this.m_objViewer.m_dtgRegister.CurrentRowIndex = i;
                        break;
                    }
                }
			}
			else
			{
				for(int f2=0;f2<m_dvRegisterfind.Count;f2++)
				{
					if(m_dvRegisterfind[f2]["挂号人工号"].ToString().Trim()=="总金额")
					{
						m_dvRegisterfind.Delete(f2);
					}
				}
				DataRowView addRow=m_dvRegisterfind.AddNew();                
				try
				{
					DataRowView seleRow=(DataRowView)m_dvRegisterfind[this.m_objViewer.m_dtgRegister.CurrentRowIndex];
					addRow["挂号ID"]=newID;
					addRow["诊疗卡号"]=seleRow["诊疗卡号"];
					addRow["发票号"]=seleRow["发票号"];
					addRow["流水号"]=seleRow["流水号"];
					addRow["挂号类型"]=seleRow["挂号类型"];
					addRow["病人名称"]=seleRow["病人名称"];
					addRow["病人性别"]=seleRow["病人性别"];
					addRow["支付类型"]=seleRow["支付类型"];
					addRow["挂号日期"]=seleRow["挂号日期"];
					addRow["科室名称"]=seleRow["科室名称"];
					addRow["医生名称"]=seleRow["医生名称"];
					addRow["过程状态"]=seleRow["过程状态"];
					addRow["挂号状态"]="退号";
					addRow["退号人工号"]=strReturnno;
					addRow["退号日期"]=strReturnDate;
					addRow["记录日期"]=seleRow["记录日期"];
					addRow["病人身份"]=seleRow["病人身份"];
					addRow["就诊地址"]=seleRow["就诊地址"];
					addRow["挂号人工号"]=seleRow["挂号人工号"];
					int i1;
					for(i1=20;i1<m_dvRegisterfind.Table.Columns.Count;i1++)
					{
						addRow[i1]="-"+seleRow[i1].ToString();
					}
					DataRowView addRowTol=m_dvRegisterfind.AddNew();
					for(int j3=20;j3<i1;j3++)
					{
						double tolMoney=0;
						for(int f2=0;f2<m_dvRegisterfind.Table.Rows.Count;f2++)
						{
							tolMoney+=Convert.ToDouble(m_dvRegisterfind.Table.Rows[f2][j3].ToString());
						}
						addRowTol[j3]=tolMoney;
					}
					addRowTol["挂号人工号"]="总金额";

                    //设置当前行
                    for (int i = 0; i < m_dvRegisterfind.Count; i++)
                    {
                        if (m_dvRegisterfind[i]["挂号ID"].ToString() == newID)
                        {
                            this.m_objViewer.m_dtgRegister.CurrentRowIndex = i;
                            break;
                        }
                    }
				}
				catch
				{
					MessageBox.Show("退号出错！","系统提示");
				}                
			}

            /***新增***/
            this.m_PrintRegister();
            /***/
		}
		#endregion

		public void m_Filter()
		{
			switch(this.m_objViewer.m_cmbQulType.SelectedIndex)
			{
				case 0 :
					this.m_dvRegister.RowFilter = "";
					break;
				case 1 :
					this.m_dvRegister.RowFilter = "挂号状态='退号'";
					break;
				case 2 :
					this.m_dvRegister.RowFilter = "过程状态='候诊' and 挂号状态<>'退号'";
					break;
				case 3 :				
					this.m_dvRegister.RowFilter = "挂号状态='预约'";
					break;
				case 4 :
					this.m_dvRegister.RowFilter = "过程状态<>'已结帐'";
					break;
				case 5 :
					this.m_dvRegister.RowFilter = "过程状态='已结帐'";
					break;
				case 6 :
					this.m_dvRegister.RowFilter = "过程状态='取消'";
					break;
			}
			if(this.m_objViewer.m_dtgRegister.BindingContext[this.m_dvRegister,null].Count != 0)
			{
				m_dtRegister_PositionChanged(null,null);
			}
			else
			{
				this.m_Clear();
			}
		}

		
	}
	
	
}
