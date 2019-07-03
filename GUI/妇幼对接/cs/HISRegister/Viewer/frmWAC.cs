using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmWAC : Form
    {
        /// <summary>
        /// 服务器IP
        /// </summary>
        string ServerIp = "http://10.10.2.109";

        /// <summary>
        /// PID
        /// </summary>
        string PatientId { get; set; }

        public frmWAC(string _pid)
        {
            InitializeComponent();
            PatientId = _pid;
            this.WindowState = FormWindowState.Maximized;
        }

        private void frmWAC_Load(object sender, EventArgs e)
        {
            try
            {
                int n = -1;
                object[] objs = new object[5];
                objs[++n] = "763709818";
                objs[++n] = "A74CC68F-B009-4264-A880-FBE87DD91E56";
                objs[++n] = "0001";
                objs[++n] = this.PatientId;
                objs[++n] = DateTime.Now.ToString("yyyy-MM-dd");
                clsPublic.PlayAvi("加载妇幼平台界面，请稍候...");
                string uri = string.Format(this.ServerIp + "/W_Fubao/AspCode/JiBenXinXi/HIS/Default.aspx?AUTHORID={0}&INFOID={1}&USER={2}&page=ChanJianTab&HISID={3}&DATE={4}&BARCODE=&HDSB0101005=&DEP=", objs);
                this.webBrowser.Navigate(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
    }
}
