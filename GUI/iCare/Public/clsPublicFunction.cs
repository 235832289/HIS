using System;
using System.Windows.Forms;
using iCareData;
using PrivilegeData;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.HospitalManagerService;
using System.Data;

namespace iCare
{
	/// <summary>
	/// 提供一些公用函数
	/// </summary>
	public class clsPublicFunction
	{
		public clsPublicFunction()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region MessageBox
	
		/// <summary>
		/// 电子签名不成功提示message
		/// </summary>
		/// <returns></returns>
		public static DialogResult ShowDigitalSignMessageBox()
		{
			return MessageBox.Show("电子签名不成功，请确认是否插入key盘","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		/// <summary>
		/// 电子签名验证不成功提示message
		/// </summary>
		/// <returns></returns>
		public static DialogResult ShowVerifySignMessageBox()
		{
			return MessageBox.Show("电子签名验证不成功，请确认是否插入key盘","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
		}


		public static DialogResult ShowInformationMessageBox(string strMessage)
		{
			return ShowInformationMessageBox(strMessage,MessageBoxButtons.OK);
		}

		public static DialogResult ShowInformationMessageBox(string strMessage,Form p_frmBase)
		{
			return ShowInformationMessageBox(strMessage,MessageBoxButtons.OK,p_frmBase);
		}

		public static DialogResult ShowInformationMessageBox(string strMessage,MessageBoxButtons buttons)
		{
            return MessageBox.Show(strMessage, "iCare Message", buttons, MessageBoxIcon.Information);
		}

		public static DialogResult ShowInformationMessageBox(string strMessage,MessageBoxButtons buttons,Form p_frmBase)
		{
            return MessageBox.Show(p_frmBase, strMessage, "iCare Message", buttons, MessageBoxIcon.Information);
		}

		public static DialogResult ShowQuestionMessageBox(string strMessage)
		{
			return ShowQuestionMessageBox(strMessage,MessageBoxButtons.YesNo);
		}

		public static DialogResult ShowQuestionMessageBox(string strMessage,MessageBoxButtons buttons)
		{
            return MessageBox.Show(strMessage, "iCare Message", buttons, MessageBoxIcon.Question);
		}

		public static DialogResult ShowQuestionMessageBox(IWin32Window p_owner,string strMessage)
		{
            return MessageBox.Show(p_owner, strMessage, "iCare Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public static void s_mthShowNotPermitMessage()
		{
			ShowInformationMessageBox("对不起，您的权限不足！");
		}

		public static DialogResult ShowDetailExceptionDialog(Exception err)
		{
			return ShowInformationMessageBox(err.Message.ToString() + "\r\n" + err.StackTrace.ToString());
		}

		public static bool s_blnAskForModify()
		{
			//			return ShowQuestionMessageBox(clsHRPMessage.c_strAskForModify) == DialogResult.Yes;
			return true;
		}

		public static bool s_blnAskForDelete()
		{
			return ShowQuestionMessageBox(clsHRPMessage.c_strAskForDelete) == DialogResult.Yes;
			//			return true;
		}

		#endregion

		#region 调整ListView的列宽，不显示横向滚动条
		/// <summary>
		/// 当显示的行数大于6时，减小最后一列的宽度，不显示横向滚动条,Jacky-2003-7-21
		/// </summary>
		/// <param name="p_lsvControl"></param>
		public static void s_mthChangeListViewLastColumnWidth(ListView p_lsvControl)
		{
			if(p_lsvControl.Columns.Count>0)
			{
				int intLastColumnWidth=p_lsvControl.Width;
				for(int i=0;i<p_lsvControl.Columns.Count-1;i++)
				{
					intLastColumnWidth -= p_lsvControl.Columns[i].Width;
				}
				if(p_lsvControl.Items.Count>6)
					intLastColumnWidth -=18;

				p_lsvControl.Columns[p_lsvControl.Columns.Count-1].Width =intLastColumnWidth;
			}
		}

		/// <summary>
		/// 当显示的行数大于指定行数时，减小最后一列的宽度，不显示横向滚动条
		/// </summary>
		/// <param name="p_lsvControl"></param>
		/// <param name="p_intRows">指定的行数</param>
		public static void s_mthChangeListViewLastColumnWidth(ListView p_lsvControl,int p_intRows)
		{
			if(p_lsvControl.Columns.Count>0)
			{
				int intLastColumnWidth=p_lsvControl.Width;
				for(int i=0;i<p_lsvControl.Columns.Count-1;i++)
				{
					//使最后一列右边那条线刚好贴到右边框
					intLastColumnWidth -= p_lsvControl.Columns[i].Width;
				}
				if(p_lsvControl.Items.Count>p_intRows)
					intLastColumnWidth -=18;//18就是滚动条的宽度

				p_lsvControl.Columns[p_lsvControl.Columns.Count-1].Width =intLastColumnWidth;
			}
		}
		#endregion 调整ListView的列宽，不显示横向滚动条

		#region 检查当前用户的操作权限
		/// <summary>
		/// 检查当前用户的操作权限
		/// </summary>
		/// <param name="p_enmSF"></param>
		/// <param name="p_enmOperation"></param>
		/// <returns>如果有操作权限返回true，否则返回false</returns>
		public static bool s_blnCheckCurrentPrivilege(enmPrivilegeSF p_enmSF,enmPrivilegeOperation p_enmOperation)
		{
			return true;//s_blnCheckCurrentPrivilege(clsSystemContext.s_ObjCurrentContext.m_ObjDepartment.m_StrDeptID,p_enmSF,p_enmOperation);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_strDeptID"></param>
		/// <param name="p_enmSF"></param>
		/// <param name="p_enmOperation"></param>
		/// <returns>如果有操作权限返回true，否则返回false</returns>
		public static bool s_blnCheckCurrentPrivilege(string p_strDeptID,enmPrivilegeSF p_enmSF,enmPrivilegeOperation p_enmOperation)
		{
//			clsPrivilegeInfo [] objPIArr = clsLoginContext.s_ObjLoginContext.m_ObjPIArr;
//
//			if(objPIArr == null)
//				return false;
//
//			for(int i=0;i<objPIArr.Length;i++)
//			{
//				if(objPIArr[i] == null)
//					continue;
//
//				//DeptID需改为每张单当前病人的所在部门
//				if(objPIArr[i].m_objGetOISF(p_strDeptID,(int)p_enmSF,(int)p_enmOperation) != null)
//					return true;
//			}

			return true;
		}
		#endregion 检查当前用户的操作权限

		#region 文本框按回车跳至下一控件
		/// <summary>
		/// 文本框按回车跳至下一控件
		/// </summary>
		/// <param name="p_txtBox"></param>
		public void m_mthSetControlEnter2Tab(System.Windows.Forms.Control p_ctlSender)
		{
			p_ctlSender.KeyDown += new KeyEventHandler(Control_KeyDown);
		}

		public void m_mthSetControlEnter2Tab(System.Windows.Forms.Control[] p_ctlSenderArr)
		{
			foreach(System.Windows.Forms.Control ctl in p_ctlSenderArr)
				ctl.KeyDown += new KeyEventHandler(Control_KeyDown);
		}

		private void Control_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				SendKeys.Send("{tab}");
			}
		}
		#endregion

		public static void s_mthTextBoxOnlyDigit(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = !(char.IsDigit(e.KeyChar) || (int)e.KeyChar == 8);
		}
		#region Date Format
		private static readonly DateTime s_dtmEmptyDate = DateTime.Parse("1900-1-1");
		/// <summary>
		/// 默认日期"1900-1-1"
		/// </summary>
		public static DateTime S_DtmEmptyDate
		{
			get{return s_dtmEmptyDate;}
		}
		/// <summary>
		/// 获取时间格式
		/// 0 = "yyyy年MM月dd日 HH时mm分ss秒"
		/// 1 = "yyyy年"
		/// 2 = "yyyy年MM月"
		/// 3 = "yyyy年MM月dd日"
		/// 4 = "yyyy年MM月dd日 HH时"
		/// 5 = "yyyy年MM月dd日 HH时mm分"
		/// 6 = "HH时mm分ss秒"
		/// 7 = "HH时mm分"
		/// 10 = "yyyy"
		/// 11 = "MM"
		/// 12 = "dd"
		/// 13 = "yyyy-MM"
		/// 14 = "yyyy-MM-dd"
		/// 15 = "yyyy-MM-dd HH"
		/// 16 = "yyyy-MM-dd HH:mm"
		/// 17 = "HH:mm:ss"
		/// 默认 = "yyyy-MM-dd HH:mm:ss"
		/// </summary>
		/// <param name="p_intType"></param>
		/// <returns></returns>
		public static string s_strGetDateTimeFormat(int p_intType)
		{
			switch(p_intType)
			{
				case 0:
					return "yyyy年MM月dd日 HH时mm分ss秒";
				case 1:
					return "yyyy年";
				case 2:
					return "yyyy年MM月";
				case 3:
					return "yyyy年MM月dd日";
				case 4:
					return "yyyy年MM月dd日 HH时";
				case 5:
					return "yyyy年MM月dd日 HH时mm分";
				case 6:
					return "HH时mm分ss秒";
				case 7:
					return "HH时mm分";
				case 10:
					return "yyyy";
				case 11:
					return "MM";
				case 12:
					return "dd";
				case 13:
					return "yyyy-MM";
				case 14:
					return "yyyy-MM-dd";
				case 15:
					return "yyyy-MM-dd HH";
				case 16:
					return "yyyy-MM-dd HH:mm";
				case 17:
					return "HH:mm:ss";
				default:
					break;
			}
			return "yyyy-MM-dd HH:mm:ss";
		}
		#endregion Date Format

        /// <summary>
        /// 判断表单是否可以有权限删除操作
        /// 适用于验证上级
        /// 对于返回实际操作者，暂时只是返回一个验证，而不记录到数据库中，有待完善
        /// </summary>
        /// <param name="pDeptID">科室ID</param>
        /// <param name="pCreateUserID">记录创建者</param>
        /// <param name="pOperatorID">记录删除者</param>
        /// <param name="pType">记录类型 1医生工作站单据 2护士工作站单据</param>
        /// <returns>返回 允许为真 拒绝为false</returns>
         public static bool IsAllowDelete(string pDeptID,string pCreateUserID,clsEmrEmployeeBase_VO pOperator,int pType)
        {  
             //检查参数
            if (pDeptID == null || pDeptID.Trim().Length == 0 || pOperator == null  )
            {
                MessageBox.Show("验证参数有误，不能继续操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
             //初始化
             bool IsAllow=true;
           


             //验证本人
             //考虑保存的既有ID又有shortno，故下策。两个一起比较，有一个匹配则认为
             if (pCreateUserID.Trim() == pOperator.m_strEMPID_CHR.Trim() || pCreateUserID.Trim() == pOperator.m_strEMPNO_CHR.Trim())
             {

                 //验证删除
                 clsDeleteVerify objDeleteVerify = new clsDeleteVerify();
                 if (objDeleteVerify.m_mthIsDelete(null, pOperator) == false)
                 {
                     MessageBox.Show("Key盘验证失败，不能继续操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return false;
                 }

             }
             else
             {
                 #region 根据工号或ID获取名字
                 string strTempEemployeeName = pCreateUserID;

                 clsHospitalManagerService objService =
                     (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));

                 try
                 {
                     DataTable dt = new DataTable();
                     long lngRes = 0;
                     if (pCreateUserID.Trim().Length < 7)//如果长度少于7位则认为工号
                     {
                         lngRes = objService.m_lngGetEmpByNO(null, pCreateUserID.Trim(), out dt);
                         if (dt.Rows.Count > 0)
                         {
                             strTempEemployeeName = dt.Rows[0][1].ToString();
                         }
                     }
                     else
                     {
                         lngRes = objService.m_lngGetEmpByID(null, pCreateUserID.Trim(), out dt);
                         if (dt.Rows.Count > 0)
                         {
                             strTempEemployeeName = dt.Rows[0][1].ToString();
                         }
                     }
                 }
                 catch (Exception exp)
                 {
                     string strMsg = exp.Message;
                     //throw;
                 }
                 finally
                 {
                     objService = null;
                 } 
                 #endregion

                 if ((MessageBox.Show("只能由创建者【" + strTempEemployeeName.Trim() + "】进行该操作，若要继续操作需要上级领导确定\n                            要继续请单击【确定】", "iCare Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)) == DialogResult.Cancel)
                 {
                     return false;
                 }
                 else
                 {
                     //验证科主任/护士长
                     frmValidateByDirector frm = new frmValidateByDirector(pType, pDeptID);
                     frm.ShowDialog();
                     if (!frm.BlnValidateResult)
                     {
                         return false;
                     }

                 }
             }
            
             return IsAllow;
        }

        /// <summary>
        /// 实现DataTable的distinct功能
        /// </summary>
        /// <param name="source"></param>
        /// <param name="Columns"></param>
        /// <returns></returns>
        public DataTable Distinct(DataTable source, DataColumn[] Columns)
        {
            DataTable table = source.Clone();

            object[] currentrow = null;

            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            table.BeginLoadData();

            foreach (DataRow row in source.Rows)
            {

                int hash = string.Concat(row.ItemArray).GetHashCode();
                if (ht.Contains(hash))
                    continue;
                ht.Add(hash, hash);
                //Insert a copy of current row 
                currentrow = new object[Columns.Length];
                Array.Copy(row.ItemArray, currentrow, Columns.Length);
                table.LoadDataRow(currentrow, true);

            }

            table.EndLoadData();
            return table;

        }

        #region 默认签名
		/// <summary>
		/// 默认签名
		/// </summary>
		/// <param name="p_ctl"></param>
		public static void m_mthSetDefaulEmployee(Control p_ctl)
        {
            if (p_ctl is TextBoxBase)
            {
                p_ctl.Text = clsEMRLogin.LoginEmployee.m_strGetTechnicalRankAndName;//.m_strTECHNICALRANK_CHR.Trim() + " " + clsEMRLogin.LoginEmployee.m_strLASTNAME_VCHR.Trim();// +"(" + clsEMRLogin.LoginEmployee.m_strTECHNICALRANK_CHR.Trim();
                p_ctl.Tag = clsEMRLogin.LoginEmployee;
                p_ctl.Enabled = true;
            }
            else if (p_ctl is ListView)
            {
                ListView lsvSign = (ListView)p_ctl;
                lsvSign.Items.Clear();
                //默认签名
                ListViewItem lviNewItem = new ListViewItem(clsEMRLogin.LoginEmployee.m_strGetTechnicalRankAndName);// + "(" + clsEMRLogin.LoginEmployee.m_strTECHNICALRANK_CHR.Trim() );
                //ID 检查重复用
                lviNewItem.SubItems.Add(clsEMRLogin.LoginEmployee.m_strEMPID_CHR);
                //级别 排序用
                lviNewItem.SubItems.Add(clsEMRLogin.LoginEmployee.m_strLEVEL_CHR);
                //tag均为对象
                lviNewItem.Tag = clsEMRLogin.LoginEmployee;
                lsvSign.Items.Add(lviNewItem);
            }
		}
		#endregion 

        public bool m_blnCheckForOpenForm(Form p_frmOpen)
        {
            clsMainMenuFunction objMemu = new clsMainMenuFunction();
            if (objMemu.m_blnIsSaveBeforeNewForm())
                return true;

            if (objMemu.m_blnCheckSamePatientForm(p_frmOpen))
                return true;

            if (objMemu.m_blnCheckForFormOpen(p_frmOpen, false))
                return true;
            return false;
        }
        /// <summary>
        /// 检查是否有打印的权限
        /// </summary>
        /// <param name="p_strNameSpace"></param>
        /// <param name="p_strClassName"></param>
        /// <param name="p_strRoles"></param>
        /// <returns>true ＝ 有；false ＝ 无</returns>
        public static bool m_blnCheckCanPrint( string p_strNameSpace, string p_strClassName, string[] p_strRoles)
        { 
            com.digitalwave.Emr.ConfigService.clsConfigService objServ =
                (com.digitalwave.Emr.ConfigService.clsConfigService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.Emr.ConfigService.clsConfigService));
            return objServ.m_blnCheckCanPrint(null,p_strNameSpace, p_strClassName, p_strRoles);
        }
	}
}
