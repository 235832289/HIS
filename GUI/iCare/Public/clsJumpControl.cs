using System;
using System.Windows.Forms;
using System.Reflection;

namespace iCare
{
	/// <summary>
	/// 跳转控制
	/// </summary>
	public class clsJumpControl
	{
		Form m_frmParent=null;
		Control[] m_ctlControls=null;
		Keys m_keyTabKey=Keys.Enter;

		private bool m_blnCanCycle = true;
		public bool m_BlnCanCycle
		{
			set{m_blnCanCycle = value;}
		}

		/// <summary>
		/// 指定窗口,以及要进行控制的控件
		/// </summary>
		/// <param name="frmParent"></param>
		/// <param name="ctlControls"></param>
		public  clsJumpControl(System.Windows.Forms.Form frmParent,System.Windows.Forms.Control[] ctlControls,Keys keyTabKey)
		{
			m_mthSetJumpControl(frmParent,ctlControls,keyTabKey);
		}

		/// <summary>
		/// 按Tab顺序跳转
		/// </summary>
		/// <param name="frmParent"></param>
		/// <param name="keyTabKey"></param>
		public clsJumpControl(Form frmParent,Keys keyTabKey)
		{
			if(frmParent==null) return;

			m_frmParent=frmParent;
			m_keyTabKey=keyTabKey;

			m_frmParent.KeyPreview=true;
			m_frmParent.KeyDown += new KeyEventHandler(frmParent_KeyDown2);

		}
		/// <summary>
		/// 默认
		/// </summary>
		public clsJumpControl()
		{}
		public void m_mthSetJumpControl(System.Windows.Forms.Form frmParent,System.Windows.Forms.Control[] ctlControls,Keys keyTabKey)
		{
			if((frmParent==null)||(ctlControls==null)) return;

			m_frmParent=frmParent;
			m_ctlControls=ctlControls;
			m_keyTabKey=keyTabKey;

			for(int i=0;i<m_ctlControls.Length;i++)
			{
				if(m_ctlControls[i] is DateTimePicker)
				{
					m_ctlControls[i].KeyPress += new KeyPressEventHandler(m_mthTime_KeyPress);
					m_ctlControls[i].Leave += new EventHandler(m_dtp_Leave);
				}
				else
					m_ctlControls[i].KeyDown += new KeyEventHandler(this.frmParent_KeyDown);
			}
		}
		/// <summary>
		/// 查找控件
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		private int m_intFoundControl(object sender)
		{
			int intIndex = -1;
			for(int i=0;i<m_ctlControls.Length;i++)
			{
				if(m_ctlControls[i]==sender)
				{
					intIndex=i;
					break;
				}
			}
			return intIndex;
		}
		/// <summary>
		/// 选择下个控件
		/// </summary>
		/// <param name="intCur"></param>
		private void m_mthSelectNextControl(int intCur)
		{
			intCur++;
			if(intCur<m_ctlControls.Length)
			{
				bool blnFind=false;
				for(int i=intCur;i<m_ctlControls.Length;i++)
				{
					if(((m_ctlControls[i].Enabled) && (m_ctlControls[i].CanFocus)) || m_ctlControls[i] is TabPage)
					{
						if((m_ctlControls[i] is TextBoxBase) && (((TextBoxBase)(m_ctlControls[i])).ReadOnly))
						{
							continue;
						}
						if(m_ctlControls[i] is TabPage)
							m_ctlControls[i].Select();
						else
							m_ctlControls[i].Focus();
						blnFind=true;
						break;
					}
					else if(!m_ctlControls[i].Enabled)
						continue;
				}
				if(!blnFind)
				{
					if(m_blnCanCycle)
						m_ctlControls[0].Focus();
					else
						SendKeys.Send("{tab}");
				}
			}
			else if(m_blnCanCycle)
			{
				m_ctlControls[0].Focus();
			}
			else
				SendKeys.Send("{tab}");
		}

		private void frmParent_KeyDown(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==m_keyTabKey)
			{
				try
				{
					if(m_ctlControls==null) return;

					int intCur=0;
//					for(int i=0;i<m_ctlControls.Length;i++)
//					{
//						if(m_ctlControls[i]==sender)
//						{
//							intCur=i;
//							blnFind=true;
//							break;
//						}
//					}
//					if(!blnFind) return;
					intCur = m_intFoundControl(sender);
					if(intCur == -1) return;
					
					if(m_ctlControls[intCur] is TextBoxBase)
					{
						if(!e.Control && ((TextBoxBase)m_ctlControls[intCur]).Multiline)
							return;
					}
					
					m_mthSelectNextControl(intCur);
//					intCur++;
					
//					if(intCur<m_ctlControls.Length)
//					{
//						blnFind=false;
//						for(int i=intCur;i<m_ctlControls.Length;i++)
//						{
//							if(((m_ctlControls[i].Enabled) && (m_ctlControls[i].CanFocus)) || m_ctlControls[i] is TabPage)
//							{
//								if((m_ctlControls[i] is TextBoxBase) && (((TextBoxBase)(m_ctlControls[i])).ReadOnly))
//								{
//									continue;
//								}
//								if(m_ctlControls[i] is TabPage)
//									m_ctlControls[i].Select();
//								else
//									m_ctlControls[i].Focus();
//								blnFind=true;
//								break;
//							}
//						}
//						if(!blnFind && m_blnCanCycle)
//						{
//							m_ctlControls[0].Focus();
//						}
//					}
//					else if(m_blnCanCycle)
//					{
//						m_ctlControls[0].Focus();
//					}
					e.Handled=true;
				}
				catch{}
			}
		}

		private void frmParent_KeyDown2(object sender,System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==m_keyTabKey)
			{
				m_frmParent.SelectNextControl(m_frmParent.ActiveControl,true,true,true,true);
			}
		}
		#region DateTime
		protected void m_mthTime_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar == (char)13)
			{
				int intCount = 0;
				if(((Control)sender).Tag == null)
					intCount = 0;
				else
				{
					try
					{
						intCount = Convert.ToInt32(((Control)sender).Tag);
					}
					catch{intCount = 0;}
				}
				if(intCount++ < 5)
					SendKeys.Send("{RIGHT}");
				else if(m_ctlControls != null)
				{
					intCount = 0;
					int intCur = m_intFoundControl(sender);
					if(intCur == -1) return;
					m_mthSelectNextControl(intCur);
				}
				else 
				{
					intCount = 0;
					SendKeys.Send("{tab}");
				}
				((Control)sender).Tag = intCount;
			}
		}
		private void m_dtp_Leave(object sender, System.EventArgs e)
		{
			((Control)sender).Tag = 0;
		}
		public void m_mthSetTimeJumps(DateTimePicker[] p_dtpSenders)
		{
			foreach(DateTimePicker dtp in p_dtpSenders)
			{
				dtp.KeyPress += new KeyPressEventHandler(m_mthTime_KeyPress);
				dtp.Leave += new EventHandler(m_dtp_Leave);
			}
		}

		#endregion DateTime

		/// <summary>
		/// 释放所有本层对象所锁定的资源
		/// 注意：请确保您再也不须要使用此对象
		/// </summary>
		public void Release()
		{
//			m_frmParent.KeyDown -= new KeyEventHandler(frmParent_KeyDown2);
			m_ctlControls = null;
			m_frmParent = null;
		}

	}
}
