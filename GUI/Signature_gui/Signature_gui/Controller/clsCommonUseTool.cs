using System;
using System.Windows.Forms;
using iCareData;
using System.Collections;

namespace com.digitalwave.Emr.Signature_gui
{	
	/// <summary>
	/// Summary description for clsCommonUseTool.
	/// </summary>
	public class clsCommonUseTool
	{
		#region 字段
		/// <summary>
		/// 签名控件
		/// </summary>
		private Control m_ctlTarget;
		/// <summary>
		/// 是否身份验证
		/// </summary>
		private bool m_blnVerify;
	
		/// <summary>
		/// 科室ID
		/// </summary>
		private string m_strDeptID;
        /// <summary>
        /// 员工ID
        /// </summary>
        private string m_strEmployeeID;
		/// <summary>
		/// contextMenu
		/// </summary>
		private System.Windows.Forms.ContextMenu ctmDeleteSign;
		/// <summary>
		/// MenuItem
		/// </summary>
		private System.Windows.Forms.MenuItem mnuDeletesign;


        //add by haozhong.liu 2008-11-11 是否显示职称
        private bool m_blnIsShowLevel = true;
        /// <summary>
        /// 是否显示职称
        /// </summary>
        public bool m_BlnIsShowLevel
        {
            get { return m_blnIsShowLevel; }
            set { m_blnIsShowLevel = value; }
        }
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsCommonUseTool()
		{

			#region contextMenu
			ctmDeleteSign = new System.Windows.Forms.ContextMenu();
			mnuDeletesign = new System.Windows.Forms.MenuItem();
			// 
			// ctmDeleteSign
			// 
			ctmDeleteSign.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { mnuDeletesign});
			mnuDeletesign.Text = "删除签名";
			mnuDeletesign.Click += new System.EventHandler(mnuDeletesign_Click);
			#endregion
		}
		#endregion

		#region 绑定方法
		/// <summary>
		/// 绑定签名常用值签名
		/// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名框控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
		/// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType,bool p_blnVerify)
		{
            if (p_ctlCall is System.Windows.Forms.ButtonBase || p_ctlCall is System.Windows.Forms.IButtonControl || p_ctlCall.GetType().FullName == "System.Windows.Forms.LinkLabel")
            {
                    if(p_intType == 1)
					{
						p_ctlCall.Click += new System.EventHandler(m_mthShowDocSign);
						p_ctlTarget.ContextMenu=ctmDeleteSign;

					}
					else if(p_intType == 2)
					{
                        p_ctlCall.Click += new System.EventHandler(m_mthShowNurSign);
						p_ctlTarget.ContextMenu=ctmDeleteSign;

					}
                    else if (p_intType == 10)
                    {
                        p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptDocDirectorSign);
                        p_ctlTarget.ContextMenu = ctmDeleteSign;

                    }
                    else if (p_intType == 20)
                    {
                        p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptNurDirectorSign);
                        p_ctlTarget.ContextMenu = ctmDeleteSign;

                    }
					else
					{
						p_ctlCall.Click += new System.EventHandler(m_mthShowAllSign);
						p_ctlTarget.ContextMenu=ctmDeleteSign;					
					}                
            }
			m_ctlTarget = p_ctlTarget;
			m_blnVerify=p_blnVerify;
		}

		/// <summary>
		/// 绑定特定部门签名常用值签名
		/// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名框控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
		public void m_mthBindEmployeeSign(Control p_ctlCall,Control p_ctlTarget,int p_intType,string p_strDeptID,bool p_blnVerify)
		{
            if (p_ctlCall is System.Windows.Forms.ButtonBase || p_ctlCall is System.Windows.Forms.IButtonControl || p_ctlCall.GetType().FullName == "System.Windows.Forms.LinkLabel")
            {
                if (p_intType == 1)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowSpecialDeptDocSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;
                }
                else if (p_intType == 2)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowSpecialDeptNurSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }
                else if (p_intType == 10)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptDocDirectorSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }
                else if (p_intType == 20)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptNurDirectorSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }

                else
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowSpecialDeptAllSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;
                }
            }
		 

			m_strDeptID = p_strDeptID;
			m_ctlTarget = p_ctlTarget;
			m_blnVerify=p_blnVerify;
		}

        /// <summary>
        /// 绑定特定员工所属部门签名常用值签名
        /// </summary>
        /// <param name="p_ctlCall">按钮控件 通常PinkieControls</param>
        /// <param name="p_ctlTarget">签名框控件 通常textbox、listview</param>
        /// <param name="p_intType">签名列表的类型：1为医生签名；2为护士签名</param>
        /// <param name="p_blnVerify">是否身份验证 true=需要 false=不需要</param>
        /// <param name="p_employeeID">员工ID</param>
        public void m_mthBindEmployeeSign(Control p_ctlCall, Control p_ctlTarget, int p_intType, bool p_blnVerify, string p_employeeID)
        {
            if (p_ctlCall is System.Windows.Forms.ButtonBase || p_ctlCall is System.Windows.Forms.IButtonControl || p_ctlCall.GetType().FullName == "System.Windows.Forms.LinkLabel")
            {
                if (p_intType == 1)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptDocSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }
                else if (p_intType == 2)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptNurSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }
                else if (p_intType == 10)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptDocDirectorSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }
                else if (p_intType == 20)
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptNurDirectorSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;

                }

                else
                {
                    p_ctlCall.Click += new System.EventHandler(m_mthShowEmployeelDeptAllSign);
                    p_ctlTarget.ContextMenu = ctmDeleteSign;
                }
            }
           
            m_ctlTarget = p_ctlTarget;
            m_blnVerify = p_blnVerify;
            m_strEmployeeID = p_employeeID;
        }

		#endregion

		#region 显示方法
		/// <summary>
		/// 显示医生签名列表
		/// </summary>
		private void m_mthShowDocSign(object sender,System.EventArgs e )
        {
            m_mthShowSignForm((Control)sender, -1);
		}
		/// <summary>
		/// 显示护士签名列表
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthShowNurSign(object sender,System.EventArgs e )
        {
            m_mthShowSignForm((Control)sender, -2);
		}
		/// <summary>
		/// 显示特定部门的医生签名
		/// </summary>
		public void m_mthShowSpecialDeptDocSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -3);
		}
		/// <summary>
		/// 显示特定部门的护士签名
		/// </summary>
		public void m_mthShowSpecialDeptNurSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -4);
		}
		/// <summary>
		/// 显示全部员工
		/// </summary>
		public void m_mthShowAllSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -5);
		}
		/// <summary>
		/// 显示特定部门员工
		/// </summary>
		public void m_mthShowSpecialDeptAllSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -6);
		}

        /// <summary>
        /// 显示所属员工部门医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptDocSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -7);
        }

        /// <summary>
        /// 显示所属员工部门护士
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptNurSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -8);
        }
        /// <summary>
        /// 显示所属员工部门主任医师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptDocDirectorSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -9);
        }
        /// <summary>
        /// 显示所属员工部门护士长
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptNurDirectorSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -10);
        }

        /// <summary>
        /// 显示所属员工部门所有员工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptAllSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender,-11);
        }

        private void m_mthShowSignForm(Control p_ctlCall,int p_intCommonUserType)
        { 
            if (!m_ctlTarget.Enabled)
            {
                MessageBox.Show("对不起，签名不能修改！", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmCommonUsePanel frmcommonusepanel = new frmCommonUsePanel();
            frmcommonusepanel.m_BlnIsShowLevel = m_blnIsShowLevel;
            frmcommonusepanel.m_mthSetParentForm(m_ctlTarget, m_blnVerify);
            frmcommonusepanel.m_mthSetCommonUserType(p_intCommonUserType);
            frmcommonusepanel.m_StrEmployeeID = m_strEmployeeID;
            frmcommonusepanel.m_StrDeptID = m_strDeptID;
            if (p_ctlCall.Tag != null)
            {
                bool blnTemp = false;
                if (bool.TryParse(p_ctlCall.Tag.ToString(), out blnTemp))
                    frmcommonusepanel.m_BlnIsMultiSignAndNoTag = blnTemp;
            }
            //frmcommonusepanel.TopMost = true;
            frmcommonusepanel.ShowDialog(p_ctlCall.FindForm());
        }

		/// <summary>
		/// 右键删除事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuDeletesign_Click(object sender, System.EventArgs e)
		{
			if(!m_ctlTarget.Enabled)
			{
				MessageBox.Show("对不起，签名不能修改！","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			if (ctmDeleteSign.SourceControl is TextBoxBase)
			{
				ctmDeleteSign.SourceControl.Tag=null;
				ctmDeleteSign.SourceControl.Text="";
			}
			if (ctmDeleteSign.SourceControl.GetType().FullName=="System.Windows.Forms.ListView")
			{
				ListView lsv =(ListView)(ctmDeleteSign.SourceControl);
				if (lsv.SelectedItems.Count==0)
					return;
				clsEmrEmployeeBase_VO m_objPloyee=(clsEmrEmployeeBase_VO)(lsv.SelectedItems[0].Tag);
				if (m_objPloyee.m_intSTATUS_INT==1&& m_blnVerify==true)
				{
					MessageBox.Show("对不起，签名不能修改！","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
				{
					lsv.Items.Remove(lsv.SelectedItems[0]);

				}
			}
    
		}
		#endregion

		#region 员工常用值签名的类型
		/// <summary>
		/// 员工常用值签名的类型
		/// </summary>
		public enum enmEmployeeType
		{
			/// <summary>
			/// 当前部门的医生常用值
			/// </summary>
			CurrentDoctor = -1,
			/// <summary>
			/// 当前部门的护士常用值
			/// </summary>
			CurrentNurse = -2,
			/// <summary>
			/// 特定部门的医生常用值
			/// </summary>
			SpecialDeptDoctor = -3,
			/// <summary>
			///  特定部门的护士常用值
			/// </summary>
			SpecialDeptNurse = -4,
			/// <summary>
			/// 特定部门的所有员工
			/// </summary>
			SpecialDeptAllEmployees = -5,
            /// <summary>
            /// 员工所属部门的医生
            /// </summary>
            EmployeelDeptDoctor = -6,
            /// <summary>
            /// 员工所属部门的护士
            /// </summary>
            EmployeeDeptNurse = -7,
            /// <summary>
            /// 员工所属部门的所有员工
            /// </summary>
            EmployeelDeptAllEmployees = -8,
            /// <summary>
            /// 员工所属部门的科主任
            /// </summary>
            EmployeelDeptDirectorDoc = -9,
            /// <summary>
            /// 员工所属部门的护士长
            /// </summary>
            EmployeelDeptDirectorNur = -10,
		}
		#endregion

	

	}	
	#region Listview排序器
	/// <summary>
	/// ListViewColumn排序器
	/// </summary>
	public class clsListViewColumnSorter : IComparer
	{
		//排序列
		private int m_intColumn = 0;
		//是否升序
		private bool m_blnAsc;
		/// <summary>
		/// 排序升降属性
		/// </summary>
		/// <param name="p_blnAsc"></param>
		public clsListViewColumnSorter(bool p_blnAsc)
		{
			m_blnAsc = p_blnAsc;
		}
		/// <summary>
		/// 排序列属性
		/// </summary>
		public int m_IntColumn
		{
			get
			{
				return m_intColumn;
			}
			set
			{
				m_intColumn = value;
			}

		}
		/// <summary>
		/// 排序
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int Compare(object x, object y)
		{
			ListViewItem lviX = (ListViewItem)x;
			ListViewItem lviY = (ListViewItem)y;

			if(m_blnAsc)
				return lviX.SubItems[m_intColumn].Text.CompareTo(lviY.SubItems[m_intColumn].Text);
			else
				return -(lviX.SubItems[m_intColumn].Text.CompareTo(lviY.SubItems[m_intColumn].Text));

		}
	}
	#endregion

}
