using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 血球仪ADVIA2120摘要说明
    /// baojian.mo Create in 2007-10-18
    /// </summary>
    public partial class frmADVIA2120 : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmADVIA2120()
        {
            InitializeComponent();
        }
        #endregion

        private frmAdvia2120Config objFrm;

        #region 创建窗体控制器
        /// <summary>
        /// 创建窗体控制器
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsAdvia2120();
            objController.Set_GUI_Apperance(this);
        }
        #endregion         

        private void frmADVIA2120_Load(object sender, EventArgs e)
        {
            this.m_dtpCheckDate.Text = DateTime.Now.ToLongDateString();
            foreach (Control objCtl in this.panel1.Controls)
            {
                if (objCtl.AccessibleName != null)
                {
                    objCtl.KeyPress += new KeyPressEventHandler(Control_Enter);
                }
            }
            objFrm = new frmAdvia2120Config();
            if (((clsAdvia2120)this.objController).blnSetDataPath())
            {
                ((clsAdvia2120)this.objController).m_mthInit();
            }
            else
            {
                MessageBox.Show(this, "初始化失败，请设置好数据库路径！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                this.listView2.Items.Clear();
                DateTime datInputDate;
                Int64 intSampleID;
                if (!string.IsNullOrEmpty(listView1.SelectedItems[0].SubItems[4].Text.Trim()))
                {
                    datInputDate = DateTime.Parse(listView1.SelectedItems[0].SubItems[4].Text);
                }
                else
                {
                    return;
                }

                if (!string.IsNullOrEmpty(listView1.SelectedItems[0].SubItems[0].Text.Trim()))
                {
                    intSampleID = Int64.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                }
                else
                {
                    return;
                }
                ((clsAdvia2120)this.objController).m_mthReadReport(datInputDate, intSampleID);
            }
        }

        private void Control_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
                return;
            }
            //只能输入数字、退格   
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {            
            this.Cursor = Cursors.WaitCursor;
            ((clsAdvia2120)this.objController).m_mthQuery();
            this.Cursor=Cursors.Default;
        }

        private void cmdConfig_Click(object sender, EventArgs e)
        {
            objFrm.strDataPath = ((clsAdvia2120)this.objController).strDataBasePath;
            objFrm.strPicPath = ((clsAdvia2120)this.objController).strPicturePath;
            if (objFrm.ShowDialog() == DialogResult.OK)
            {
                ((clsAdvia2120)this.objController).strDataBasePath = objFrm.strDataPath;
                ((clsAdvia2120)this.objController).strPicturePath = objFrm.strPicPath;
                ((clsAdvia2120)this.objController).m_mthInit();
            }
            
        }

        private void cboPatientType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboPatientType.Tag != null)
            {
                DataView dv = ((DataTable)this.cboPatientType.Tag).DefaultView;
                dv.RowFilter = "chr_name= '" + this.cboPatientType.Text + "'";
                ((clsAdvia2120)this.objController).intPatientType = int.Parse(dv[0]["num_typeid"].ToString());
            }
        }

        private void cboPatientType_Enter(object sender, EventArgs e)
        {
            cboPatientType.DroppedDown = true;
        }

        private void cboPatientType_Leave(object sender, EventArgs e)
        {
            cboPatientType.DroppedDown = false;
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboDept.Tag != null)
            {
                DataView dv = ((DataTable)this.cboDept.Tag).DefaultView;
                dv.RowFilter = "chr_name= '" + this.cboDept.Text + "'";
                ((clsAdvia2120)this.objController).intDetpID = int.Parse(dv[0]["num_departid"].ToString());
            }
        }        

        private void cboDept_Enter(object sender, EventArgs e)
        {
            cboDept.DroppedDown = true;
        }

        private void cboDept_Leave(object sender, EventArgs e)
        {
            cboDept.DroppedDown = false;
        }

        private void cmdInsertReport_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsAdvia2120)this.objController).m_mthInsertReport();
            this.Cursor = Cursors.Default;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}