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
		#region �ֶ�
		/// <summary>
		/// ǩ���ؼ�
		/// </summary>
		private Control m_ctlTarget;
		/// <summary>
		/// �Ƿ������֤
		/// </summary>
		private bool m_blnVerify;
	
		/// <summary>
		/// ����ID
		/// </summary>
		private string m_strDeptID;
        /// <summary>
        /// Ա��ID
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


        //add by haozhong.liu 2008-11-11 �Ƿ���ʾְ��
        private bool m_blnIsShowLevel = true;
        /// <summary>
        /// �Ƿ���ʾְ��
        /// </summary>
        public bool m_BlnIsShowLevel
        {
            get { return m_blnIsShowLevel; }
            set { m_blnIsShowLevel = value; }
        }
		#endregion
		
		#region ���캯��
		/// <summary>
		/// ���캯��
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
			mnuDeletesign.Text = "ɾ��ǩ��";
			mnuDeletesign.Click += new System.EventHandler(mnuDeletesign_Click);
			#endregion
		}
		#endregion

		#region �󶨷���
		/// <summary>
		/// ��ǩ������ֵǩ��
		/// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ����ؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
		/// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
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
		/// ���ض�����ǩ������ֵǩ��
		/// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ����ؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
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
        /// ���ض�Ա����������ǩ������ֵǩ��
        /// </summary>
        /// <param name="p_ctlCall">��ť�ؼ� ͨ��PinkieControls</param>
        /// <param name="p_ctlTarget">ǩ����ؼ� ͨ��textbox��listview</param>
        /// <param name="p_intType">ǩ���б�����ͣ�1Ϊҽ��ǩ����2Ϊ��ʿǩ��</param>
        /// <param name="p_blnVerify">�Ƿ������֤ true=��Ҫ false=����Ҫ</param>
        /// <param name="p_employeeID">Ա��ID</param>
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

		#region ��ʾ����
		/// <summary>
		/// ��ʾҽ��ǩ���б�
		/// </summary>
		private void m_mthShowDocSign(object sender,System.EventArgs e )
        {
            m_mthShowSignForm((Control)sender, -1);
		}
		/// <summary>
		/// ��ʾ��ʿǩ���б�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_mthShowNurSign(object sender,System.EventArgs e )
        {
            m_mthShowSignForm((Control)sender, -2);
		}
		/// <summary>
		/// ��ʾ�ض����ŵ�ҽ��ǩ��
		/// </summary>
		public void m_mthShowSpecialDeptDocSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -3);
		}
		/// <summary>
		/// ��ʾ�ض����ŵĻ�ʿǩ��
		/// </summary>
		public void m_mthShowSpecialDeptNurSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -4);
		}
		/// <summary>
		/// ��ʾȫ��Ա��
		/// </summary>
		public void m_mthShowAllSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -5);
		}
		/// <summary>
		/// ��ʾ�ض�����Ա��
		/// </summary>
		public void m_mthShowSpecialDeptAllSign(object sender,System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -6);
		}

        /// <summary>
        /// ��ʾ����Ա������ҽ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptDocSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -7);
        }

        /// <summary>
        /// ��ʾ����Ա�����Ż�ʿ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptNurSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -8);
        }
        /// <summary>
        /// ��ʾ����Ա����������ҽʦ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptDocDirectorSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -9);
        }
        /// <summary>
        /// ��ʾ����Ա�����Ż�ʿ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthShowEmployeelDeptNurDirectorSign(object sender, System.EventArgs e)
        {
            m_mthShowSignForm((Control)sender, -10);
        }

        /// <summary>
        /// ��ʾ����Ա����������Ա��
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
                MessageBox.Show("�Բ���ǩ�������޸ģ�", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
		/// �Ҽ�ɾ���¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mnuDeletesign_Click(object sender, System.EventArgs e)
		{
			if(!m_ctlTarget.Enabled)
			{
				MessageBox.Show("�Բ���ǩ�������޸ģ�","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
					MessageBox.Show("�Բ���ǩ�������޸ģ�","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
				{
					lsv.Items.Remove(lsv.SelectedItems[0]);

				}
			}
    
		}
		#endregion

		#region Ա������ֵǩ��������
		/// <summary>
		/// Ա������ֵǩ��������
		/// </summary>
		public enum enmEmployeeType
		{
			/// <summary>
			/// ��ǰ���ŵ�ҽ������ֵ
			/// </summary>
			CurrentDoctor = -1,
			/// <summary>
			/// ��ǰ���ŵĻ�ʿ����ֵ
			/// </summary>
			CurrentNurse = -2,
			/// <summary>
			/// �ض����ŵ�ҽ������ֵ
			/// </summary>
			SpecialDeptDoctor = -3,
			/// <summary>
			///  �ض����ŵĻ�ʿ����ֵ
			/// </summary>
			SpecialDeptNurse = -4,
			/// <summary>
			/// �ض����ŵ�����Ա��
			/// </summary>
			SpecialDeptAllEmployees = -5,
            /// <summary>
            /// Ա���������ŵ�ҽ��
            /// </summary>
            EmployeelDeptDoctor = -6,
            /// <summary>
            /// Ա���������ŵĻ�ʿ
            /// </summary>
            EmployeeDeptNurse = -7,
            /// <summary>
            /// Ա���������ŵ�����Ա��
            /// </summary>
            EmployeelDeptAllEmployees = -8,
            /// <summary>
            /// Ա���������ŵĿ�����
            /// </summary>
            EmployeelDeptDirectorDoc = -9,
            /// <summary>
            /// Ա���������ŵĻ�ʿ��
            /// </summary>
            EmployeelDeptDirectorNur = -10,
		}
		#endregion

	

	}	
	#region Listview������
	/// <summary>
	/// ListViewColumn������
	/// </summary>
	public class clsListViewColumnSorter : IComparer
	{
		//������
		private int m_intColumn = 0;
		//�Ƿ�����
		private bool m_blnAsc;
		/// <summary>
		/// ������������
		/// </summary>
		/// <param name="p_blnAsc"></param>
		public clsListViewColumnSorter(bool p_blnAsc)
		{
			m_blnAsc = p_blnAsc;
		}
		/// <summary>
		/// ����������
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
		/// ����
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
