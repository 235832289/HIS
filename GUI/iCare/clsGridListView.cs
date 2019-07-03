using System.Drawing;
using System.Windows.Forms;
using System;

namespace iCare
{
	/// <summary>
	/// 
	/// </summary>
	public class clsGridListView
	{
		private DataGrid m_dtgBase;
		private DataGridTextBoxColumn m_dtxtcText;
		private DataGridTextBox m_txtText;

		private ListView m_lsvShow;

		private int m_intCheck;

		private EventHandler m_evhBeforeListViewShow;

		public clsGridListView(DataGrid dtgBase,DataGridTextBoxColumn dtxtcText,ListView lsvShow,EventHandler evhBeforeListViewShow)
		{
			m_dtgBase = dtgBase;
			m_dtxtcText = dtxtcText;

			m_lsvShow = lsvShow;

			m_evhBeforeListViewShow = evhBeforeListViewShow;

			m_txtText = (DataGridTextBox)dtxtcText.TextBox;
			m_txtText.KeyDown += new KeyEventHandler(ShowListView);
			m_txtText.TextChanged += new EventHandler(BeforeListViewShow);

			m_txtText.LostFocus += new EventHandler(HideListView);
			m_txtText.GotFocus += new EventHandler(TxtGotFocus);
			m_lsvShow.LostFocus += new EventHandler(HideListView);

			m_intCheck = 0;
		}

		private void BeforeListViewShow(object sender,EventArgs e)
		{
			if(m_evhBeforeListViewShow!=null)
				m_evhBeforeListViewShow(sender,e);

			m_intCheck = 0;
		}

		private void ShowListView(object sender,KeyEventArgs e)
		{
			int x = m_txtText.Location.X + m_dtgBase.Location.X;
			int y = m_txtText.Location.Y + m_dtgBase.Location.Y + m_txtText.Height;
			
			if(x != m_dtgBase.Location.X)
			{
				Point p = new Point(x,y);
				m_lsvShow.Location = p;
				m_lsvShow.Width = m_txtText.Width ;
				m_lsvShow.Visible = true;
				
				m_lsvShow.BringToFront();
				m_intCheck++;
			}			
		}

		private void HideListView(object sender,EventArgs e)
		{
			if(sender.Equals(m_lsvShow))
			{
				m_lsvShow.Visible = false;
				m_intCheck++;
			}
			else if(sender.Equals(m_txtText) && !m_lsvShow.Focused)
			{
				m_lsvShow.Visible = false;
				m_intCheck++;
			}
		}

		private void TxtGotFocus(object sender,EventArgs e)
		{
			if(m_intCheck == 2)
				ShowListView(sender,null);
			m_intCheck = 0;
			
		}

		public string strGetCurrentText()
		{
			return m_txtText.Text;
		}
	}
}
