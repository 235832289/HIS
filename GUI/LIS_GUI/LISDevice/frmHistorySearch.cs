using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmHistorySearch : Form
    {
        public frmHistorySearch()
        {
            InitializeComponent();
        }

        private string m_boardNo;

        public string BoardNo
        {
            get { return m_boardNo; }
        }


        private void m_cmdSubmit_Click(object sender, EventArgs e)
        {
            DateTime dtBegin=this.m_dtpBeginTime.Value;
            DateTime begin = new DateTime(dtBegin.Year, dtBegin.Month, dtBegin.Day, 0, 0,0);

            DateTime dtEnd = this.m_dtpEndTime.Value;
            DateTime end = new DateTime(dtEnd.Year, dtEnd.Month, dtEnd.Day, 23, 59,59);

           string[] arrBoardNo = null;
            clsST360CheckResultSmp.s_object.m_lngFindBoardName(out arrBoardNo, begin, end);

            this.m_lstBoxBoardNo.Items.Clear();
            m_lstBoxBoardNo.BeginUpdate();
            foreach (string boardNo in arrBoardNo)
            {
                this.m_lstBoxBoardNo.Items.Add(boardNo);
            }
            m_lstBoxBoardNo.EndUpdate();
        }

        private void m_lstBoxBoardNo_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult= DialogResult.Yes;
        }

        private void m_lstBoxBoardNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_boardNo = m_lstBoxBoardNo.SelectedItem as string;
            if (m_boardNo==null)
            {
                m_boardNo = string.Empty;
            }
        }
    }
}