using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmtest : Form
    {
        //private ImeTool objIme = new ImeTool();

        public frmtest()
        {
            InitializeComponent();           
        }

        private void frmtest_Activated(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //Process[] ps = Process.GetProcesses();
            //for (int i = 0; i < ps.Length; i++)
            //{
            //    ProcessThreadCollection threads = ps[i].Threads;
            //    for (int j = 0; j < threads.Count; j++)
            //    {
            //        int id = threads[j].Id;
            //        objIme.CloseFullShape(id);
            //    }
            //}
        }
    }
}