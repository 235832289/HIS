using System.Drawing;
using System.Windows.Forms;
using System;
using com.digitalwave.Utility.Controls;
namespace iCare
{
	/// <summary>
	/// 
	/// </summary>
	public class clsRichTextListView
	{
		private ctlRichTextBox m_dtxtText;

		private ListView m_lsvShow;

		private int m_intCheck;

		private EventHandler m_evhBeforeListViewShow;

		public clsRichTextListView(ctlRichTextBox dtxtText,ListView lsvShow,EventHandler evhBeforeListViewShow)
		{
			m_dtxtText = dtxtText;

			m_lsvShow = lsvShow;

			m_evhBeforeListViewShow = evhBeforeListViewShow;

			m_dtxtText = (ctlRichTextBox)dtxtText;
			m_dtxtText.KeyDown += new KeyEventHandler(ShowListView);
			m_dtxtText.TextChanged += new EventHandler(BeforeListViewShow);

			m_dtxtText.LostFocus += new EventHandler(HideListView);
			m_dtxtText.GotFocus += new EventHandler(TxtGotFocus);
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
			int x = m_dtxtText.Location.X;
			int y = m_dtxtText.Location.Y + m_dtxtText.Height;
			
//			if(x != m_dtgBase.Location.X)
//			{
				Point p = new Point(x,y);
				m_lsvShow.Location = p;
				m_lsvShow.Width = m_dtxtText.Width ;
				m_lsvShow.Visible = true;

				m_intCheck++;
//			}			
		}

		private void HideListView(object sender,EventArgs e)
		{
			if(sender.Equals(m_lsvShow))
			{
				m_lsvShow.Visible = false;
				m_intCheck++;
			}
			else if(sender.Equals(m_dtxtText) && !m_lsvShow.Focused)
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
			return m_dtxtText.Text;
		}
	}
}
