using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.DataCollection
{
    /// <summary>
    /// kenny created in 2008.10.14
    /// </summary>
    public partial class frmUploadMain : Form
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmUploadMain()
        {
            InitializeComponent();
        }

        public frmUploadMain(object[] args)
        {
            InitializeComponent();
            m_arrParameters = ((string[])args);
        }
        #endregion        

        #region 变量
        /// <summary>
        /// 打开参数
        /// </summary>
        private string[] m_arrParameters;
        /// <summary>
        /// 逻辑控制类
        /// </summary>
        private clsCtl_UploadMain objController;
        #endregion        

        private void frmUploadMain_Load(object sender, EventArgs e)
        {
            //默认读取前一天的数据上传
            dtpTime.Value = DateTime.Now.AddDays(-1);
            //dtpTime.Value = DateTime.Now;
            objController = new clsCtl_UploadMain();
            objController.m_objViewer = this;            
            if (m_arrParameters.Length > 0)
            {
                this.Show();
                Application.DoEvents();
                for (int i1 = 0; i1 < m_arrParameters.Length; i1++)
                {
                    // 自动上传昨天数据
                    if (m_arrParameters[i1].Trim().ToLower() == "-a")
                    {
                        //上传门诊
                        this.btnOPInfoUpload_Click(btnOPInfoUpload, null);
                        //上传住院
                        this.cmdTran_Click(cmdTran, null);
                        //上传检验数据
                        this.btnLisUpload_Click(null, null);
                        //上传检查数据
                        m_cmdCheckRecordUpload_Click(null, null);
                        //病案首页和手术数据
                        this.btnEmrUpload_Click(null, null);
                        //上传药品
                        this.cmdDrugUpload_Click(null, null);
                        // TODO: 添加其他接口
                        this.Close();
                    }
                    // TODO: 请在此添加其他参数
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOPInfoUpload_Click(object sender, EventArgs e)
        {
            this.btnOPInfoUpload.Enabled = false;
            this.btnDiagInfoUpload_Click(btnDiagInfoUpload, null);
            System.Threading.Thread.Sleep(300);
            this.btnOpfeeUpload_Click(btnOpfeeUpload, null);
            System.Threading.Thread.Sleep(300);
            this.btnRecInfoUpload_Click(btnRecInfoUpload, null);
            System.Threading.Thread.Sleep(300);
            ((clsCtl_UploadMain)this.objController).m_lngUploadChargeStd();
            System.Threading.Thread.Sleep(300);
            ((clsCtl_UploadMain)this.objController).m_lngUploadItemControlInfo();
            this.btnOPInfoUpload.Enabled = true;
            //this.objController.m_lngUploadDrugInfo();
        }

        private void btnDiagInfoUpload_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadDiagInfo();
            m_mthShowMessage(lngRes);
        }

        private void btnOpfeeUpload_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadOpfee();
            m_mthShowMessage(lngRes);
        }

        private void btnRecInfoUpload_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadRecInfo();
            m_mthShowMessage(lngRes);
        }

        private void cmdTran_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.cmdTran.Enabled = false;
            this.lsvInfor.Items.Clear();
            this.lblCurrentInfo.Text = "准备上传.....";

            clsReceiveData objRece = new clsReceiveData();
            timer1.Start();
            //objRece.m_lngUpload(this.dtpTime.Value, this.lblCurrentInfo, this.lsvInfor);
            objRece.m_lngUpload(this.dtpTime.Value, this.lblCurrentInfo);
            this.cmdTran.Enabled = true;
            timer1.Stop();
            this.Refresh();
            this.Cursor = Cursors.Default;
        }

        private void m_mthShowMessage(long p_flag)
        {
            if (p_flag > 0)
            {
                lblCurrentInfo.Text = "上传成功!";                
            }
            else
            {
                lblCurrentInfo.Text = "上传失败!";
            }
        }

        private void grouper1_MouseDown(object sender, MouseEventArgs e)
        {
            clsPublic.MoveForm(this.Handle);
        }

        int intFlash = 3;
        int intCurrentFlash = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (intCurrentFlash == intFlash)
            {
                this.Refresh();
                intCurrentFlash = 0;
            }
            else
            {
                intCurrentFlash++;
            }
        }

        private void btnLisUpload_Click(object sender, System.EventArgs e)  //检验
        {
            long lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadLisInfo();
            m_mthShowMessage(lngRes);
            pgbTask.Value = 100;
        }

        private void btnEmrUpload_Click(object sender, System.EventArgs e)
        {
            //住院系统，病案首页与检查数据暂时不用，先屏蔽掉，用的时候去掉注释即可。qinhong
            long lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadInHospitalInfo();
            m_mthShowMessage(lngRes);
            pgbTask.Value = 100;
        }

        private void m_cmdCheckRecordUpload_Click(object sender, EventArgs e) //检查
        {
            long lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadCheckInfo();
            m_mthShowMessage(lngRes);
            pgbTask.Value = 100;
        }

        private void cmdDrugUpload_Click(object sender, EventArgs e)
        {
            long lngRes = ((clsCtl_UploadMain)this.objController).m_lngUploadDrugInfo();
            m_mthShowMessage(lngRes);
        }

    }
}