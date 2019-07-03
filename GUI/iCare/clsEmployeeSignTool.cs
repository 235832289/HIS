using System;
using System.Windows.Forms;

namespace iCare
{
	/*
	 * 使用说明：
	 * 1）在界面添加ListView，并设置各个显示属性。
	 * 2）在窗体添加：
	 *    private clsEmployeeSignTool m_objSignTool;
	 * 3）在窗体构造函数添加：
	 *    m_objSignTool = new clsEmployeeSignTool(lsvLike);
	 *    m_objSignTool.m_mthAddControl(文本控件);
	 * 4）在TreeView的AfterSelected事件处理函数中，在根结点处理段添加：
	 *    m_objSignTool.m_mthSetDefaulEmployee();
	 * 5）在清空函数添加：
	 *    m_objSignTool.m_mthClearEmplyee();
	 */

	/// <summary>
	/// Summary description for clsEmployeeSignTool
	/// 签名通用工具类
	/// </summary>
	public class clsEmployeeSignTool : com.digitalwave.Utility.Controls.clsTextLikeTool
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_lsvLike">查询结果列表</param>
		public clsEmployeeSignTool(ListView p_lsvLike):base(p_lsvLike)
		{
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_lsvLike"></param>
		/// <param name="p_blnNeedPwd"></param>
		public clsEmployeeSignTool(ListView p_lsvLike,bool p_blnNeedPwd):base(p_lsvLike)
		{
			m_blnNeedPwd = p_blnNeedPwd;
		}
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsEmployeeSignTool()
		{
		}
		/// <summary>
		/// 签名是否需要密码
		/// </summary>
		private bool m_blnNeedPwd = true;
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strText"></param>
		/// <param name="p_lsvLike"></param>
		/// <returns></returns>
		protected override long m_lngInitListItemSub(string p_strText, System.Windows.Forms.ListView p_lsvLike)
		{
			m_mthSetDoctorList(p_strText,p_lsvLike);
			return 1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_ctlCurrent"></param>
		/// <param name="p_lviSelected"></param>
		protected override void m_mthSetSelectValueSub(System.Windows.Forms.Control p_ctlCurrent, System.Windows.Forms.ListViewItem p_lviSelected)
		{
			try
			{
				clsEmployee objEmp = (clsEmployee)p_lviSelected.Tag;

				if(objEmp == null)
					return;

				if(m_blnNeedPwd)
					if(!m_blnCheckEmployeeSign(p_ctlCurrent.FindForm(),objEmp.m_StrEmployeeID,objEmp.m_StrLastName))
						return;

				p_ctlCurrent.Text=objEmp.m_StrLastName;
				p_ctlCurrent.Tag= objEmp;
			}
			catch (Exception ex)
			{
				
			}
		}

		/// <summary>
		/// 验证员工签名
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSign(Form p_frmParent,string p_strEmployeeID,string p_strEmployeeName)
		{
//			frmCheckSign objCheck = new frmCheckSign(p_strEmployeeID,p_strEmployeeName);
//
//			objCheck.ShowDialog(p_frmParent);
//
//			if(objCheck.m_LngRes > 0 && objCheck.m_BlnIsPass)
//			{
//				return true;
//			}
//			else if(objCheck.m_LngRes > 0 && !objCheck.m_BlnIsPass)
//			{
//				clsPublicFunction.ShowInformationMessageBox("验证失败，该员工不能签名。");
//				return false;
//			}
//			else
//			{
//				return false;
//			}

			return true;
		}

		/// <summary>
		/// 显示医生列表
		/// </summary>
		/// <param name="p_strDoctorNameLike">医生号</param>
		private void m_mthSetDoctorList(string p_strDoctorNameLike,System.Windows.Forms.ListView p_lsvLike)
		{			
			/*
			 * 获取所有医生号和姓名。
			 */			

			if(p_strDoctorNameLike.Length == 0)
			{				
				return;
			}

			clsEmployee [] objDoctorArr = clsSystemContext.s_ObjCurrentContext.m_ObjEmployeeManager.m_objGetEmployeeIDLikeArr(p_strDoctorNameLike,clsSystemContext.s_ObjCurrentContext.m_ObjDepartment);

			for(int i=0;i<objDoctorArr.Length;i++)
			{
				ListViewItem lviDoctor = new ListViewItem(
					new string[]{
									objDoctorArr[i].m_StrEmployeeID,
									objDoctorArr[i].m_StrLastName
								});
				lviDoctor.Tag = objDoctorArr[i];

				p_lsvLike.Items.Add(lviDoctor);
			}
		}

		/// <summary>
		/// 设置默认员工
		/// </summary>
		public void m_mthSetDefaulEmployee()
		{
			//clsEmployee objLoginEmployee = clsSystemContext.s_ObjCurrentContext.m_ObjEmployee;
			//modify by tfzhang 2005年11月15日
			string _strEmployeeName =clsEMRLogin.LoginInfo.m_strEmpName;
			string _strEmployeeNo=clsEMRLogin.LoginInfo.m_strEmpNo;
			clsEmployee objLoginEmployee=new clsEmployee(_strEmployeeNo); 
			for(int i=0;i<m_arlControls.Count;i++)
			{
				Control ctlControl = (Control)m_arlControls[i];
				ctlControl.Text =_strEmployeeName;
				ctlControl.Tag = objLoginEmployee;
				ctlControl.Enabled = true;
			}
		}

		/// <summary>
		/// 设置指定员工
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		public void m_mtSetSpecialEmployee(string p_strEmployeeID)
		{
			if(p_strEmployeeID != null && p_strEmployeeID.Trim() != "")
			{
				clsEmployee objEmp = new clsEmployee(p_strEmployeeID);

				for(int i=0;i<m_arlControls.Count;i++)
				{
					Control ctlControl = (Control)m_arlControls[i];
					ctlControl.Text = objEmp.m_StrLastName;
					ctlControl.Tag = objEmp;
					ctlControl.Enabled = false;
				}
			}
		}

		/// <summary>
		/// 设置指定员工
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_ctl"></param>
		public void m_mtSetSpecialEmployee(string p_strEmployeeID,Control p_ctl)
		{
			if(p_strEmployeeID != null && p_strEmployeeID.Trim() != "")
			{
				clsEmployee objEmp = new clsEmployee(p_strEmployeeID);
				p_ctl.Text =objEmp.m_StrLastName;
				p_ctl.Tag = objEmp;
				p_ctl.Enabled = false;
			}
		}

		/// <summary>
		/// 设置默认员工：简化版
		/// </summary>
		/// <param name="p_ctl"></param>
		public static void s_mthSetDefaulEmployee(Control p_ctl)
		{
			//clsEmployee objLoginEmployee = clsSystemContext.s_ObjCurrentContext.m_ObjEmployee;
			string _strEmployeeName =clsEMRLogin.LoginInfo.m_strEmpName;
			string _strEmployeeNo=clsEMRLogin.LoginInfo.m_strEmpNo;
			
			switch(p_ctl.GetType().Name)
			{
				case "ctlBorderTextBox" :
 					p_ctl.Text =_strEmployeeName;
					p_ctl.Tag = _strEmployeeNo;
					p_ctl.Enabled = true;
					break;
				case "ListView" :
					ListView lsvControl = (ListView)p_ctl;
					lsvControl.Items.Clear();
 					ListViewItem lsvItem = lsvControl.Items.Add(_strEmployeeName);
					lsvItem.SubItems.Add(_strEmployeeNo);
					break;
			}
		}	
	
		public static void s_mthDeleteListViewItem(ListView p_lsv)
		{
			while(p_lsv.SelectedItems.Count>0)
				p_lsv.SelectedItems[0].Remove();
		}

		/// <summary>
		/// 签名ListView上的右键删除
		/// </summary>
		/// <param name="p_lsvArr"></param>
		public void m_mthAddListViewDeleteMenu(ListView[] p_lsvArr)
		{
			ContextMenu ctm = new ContextMenu();
			ctm.MenuItems.Add("删除",new EventHandler(m_mthDeleteListViewItem));
			for(int i = 0; i < p_lsvArr.Length; i++)
				p_lsvArr[i].ContextMenu = ctm;
		}

		private void m_mthDeleteListViewItem(object sender,System.EventArgs e)
		{
			ListView lsv = (ListView)(((MenuItem)sender).GetContextMenu().SourceControl);
			
			while(lsv.SelectedItems.Count>0)
				lsv.SelectedItems[0].Remove();
		}

		public bool m_blnCheckSignRight = true;
		/// <summary>
		/// 检测用户签名是否有误
		/// </summary>
		/// <param name="p_ctl"></param>
		/// <returns></returns>
		public bool m_blnCheckSignRightMethod(Control p_ctl)
		{			
			if(p_ctl.Name=="m_txtSign" && p_ctl.Tag != null && p_ctl.Text.Trim()!= ((clsEmployee)p_ctl.Tag).m_StrFirstName.Trim())
			{
				clsPublicFunction.ShowInformationMessageBox(clsHRPMessage.c_strAskForSign);
				p_ctl.Focus();
				m_blnCheckSignRight = false;
			}

			if(p_ctl.HasChildren)
			{
				foreach(Control ctlSub in p_ctl.Controls)
				{
					m_blnCheckSignRightMethod(ctlSub);
				}			
			}
			return m_blnCheckSignRight;
		}

		/// <summary>
		/// 清空员工签名
		/// </summary>
		public void m_mthClearEmplyee()
		{
			try
			{
				for(int i=0;i<m_arlControls.Count;i++)
				{
					Control ctlControl = (Control)m_arlControls[i];
					ctlControl.Text = "";
					ctlControl.Tag = null;
				}
			}
			catch (Exception ex)
			{
				
			}
		}
	}
}
