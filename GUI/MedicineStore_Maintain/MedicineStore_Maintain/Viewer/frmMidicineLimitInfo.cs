using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品低库存提示窗
    /// </summary>
    public partial class frmMedicineLimitInfo :com.digitalwave .GUI_Base .frmMDI_Child_Base
    {
        #region  变量
        /// <summary>
        /// 窗体ID区分中西药库药房查询
        /// </summary>
        internal string m_strMedicineID = null;
        /// <summary>
        /// 类型0为药库， 1为药房
        /// </summary>
        internal string m_strStoreStyle = null;
        #endregion

        #region 窗体构造
        /// <summary>
        /// 窗体构造
        /// </summary>
        public frmMedicineLimitInfo()
        {
            InitializeComponent();
        }

        #endregion

        #region 检查是否已打开指定窗体
        /// <summary>
        /// 检查是否已打开指定窗体
        /// </summary>
        /// <param name="p_strFormName">窗体名</param>
        /// <param name="m_strMedthodName">方法名称</param>
        /// <returns></returns>
        private bool m_blnHasCurrentForm(string p_strFormName, string m_strMedthodName)
        {
            bool blnHasShow = false;

            System.Windows.Forms.Form frmParent =com.digitalwave .Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
            foreach (System.Windows.Forms.Form frmChild in frmParent.MdiChildren)
            {
                if (frmChild is com.digitalwave.GUI_Base.frmMDI_Child_Base && frmChild.Name == p_strFormName && frmChild.Tag != null && frmChild.Tag.ToString() == m_strMedthodName)
                {
                    frmChild.Activate();
                    frmChild.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                    blnHasShow = true;
                }
            }
            return blnHasShow;
        }
        #endregion
        /// <summary>
        /// 显示出库窗体
        /// </summary>
        /// <param name="p_strStorageID"></param>
        public void ShowOutStorageByType(string p_strStorageID, string m_strOutStorageType)
        {
            if (string.IsNullOrEmpty(p_strStorageID))
            {
                return;
            }
            try
            {
                string m_strMedthodName = string.Format("ShowOutStorageByType({0}{1})", p_strStorageID.Trim(), m_strOutStorageType);
                if (m_blnHasCurrentForm("frmOutStorage", m_strMedthodName))
                {
                    return;
                }

                frmMedicineLimitInfo frmIR = new frmMedicineLimitInfo();
                frmIR.Tag = m_strMedthodName;
                frmIR.Show();
                frmIR.MdiParent = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_FrmMDI;
                frmIR.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
            catch (Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message);
            }
        }


        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="p_strMedStoreID"></param>
        public void m_mthShow(string p_strStoreStyle,string p_strStoreID)
        {
            m_strMedicineID = p_strStoreID;
            m_strStoreStyle = p_strStoreStyle;
            if (p_strStoreStyle=="0"&&p_strStoreID == "0001")
            {
                this.Text = "西药库低库存提示";
                this.Show();
            }
            else if (p_strStoreStyle=="0"&&p_strStoreID == "0002")
            {
                this.Text = "中药库低库存提示";
                this.Show();
            }
            else if (p_strStoreStyle == "1" && p_strStoreID == "0001")
            {
                this.Text = "西药房低库存提示";
                this.Show();
            }
            else if (p_strStoreStyle == "1" && p_strStoreID == "0002")
            {
                this.Text = "中药房低库存提示";
                this.Show();
 
            }
        }
        #endregion

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineLimitInfo();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始设置控件
        internal void m_mthInitDgv()
        {
            //药库
            if (m_strStoreStyle=="0")
            {
                dgvMedicineInfo.Columns[0].DataPropertyName = "assistcode_chr";
                dgvMedicineInfo.Columns[1].DataPropertyName = "medicinename_vchr";
                dgvMedicineInfo.Columns[2].DataPropertyName = "medspec_vchr";
                dgvMedicineInfo.Columns[3].DataPropertyName = "opunit_vchr";
                dgvMedicineInfo.Columns[4].DataPropertyName = "currentgross_num";
                dgvMedicineInfo.Columns[5].DataPropertyName = "neaplimit_int";
                dgvMedicineInfo.Columns[6].DataPropertyName = "unitprice_mny";
                dgvMedicineInfo.Columns[7].DataPropertyName = "productorid_chr";
                dgvMedicineInfo.Columns[8].DataPropertyName = "pycode_chr";
                dgvMedicineInfo.Columns[9].DataPropertyName = "wbcode_chr";
            }
                //药房
            else if (m_strStoreStyle =="1")
            {
                dgvMedicineInfo.Columns[0].DataPropertyName = "assistcode_chr";
                dgvMedicineInfo.Columns[1].DataPropertyName = "medicinename_vchr";
                dgvMedicineInfo.Columns[2].DataPropertyName = "medspec_vchr";
                dgvMedicineInfo.Columns[3].DataPropertyName = "opunit_chr";
                dgvMedicineInfo.Columns[4].DataPropertyName = "opcurrentgross_num";
                dgvMedicineInfo.Columns[5].DataPropertyName = "neaplimit_int";
                dgvMedicineInfo.Columns[6].DataPropertyName = "unitprice_mny";
                dgvMedicineInfo.Columns[7].DataPropertyName = "productorid_chr";
                dgvMedicineInfo.Columns[8].DataPropertyName = "pycode_chr";
                dgvMedicineInfo.Columns[9].DataPropertyName = "wbcode_chr";
            }


 
        }
        #endregion

        #region 窗体事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMedicineLimitInfo_Load(object sender, EventArgs e)
        {
            m_mthInitDgv();
            this.notifyIconLowMedicineNotice.Visible = true;
            ((clsCtl_MedicineLimitInfo)objController).m_mthFill(m_strStoreStyle, m_strMedicineID);
            this.timer1.Start();
        }

        /// <summary>
        /// 双击任务栏图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIconLowMedicineNotice_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.TopMost = true;
            ((clsCtl_MedicineLimitInfo)objController).m_mthFill(m_strStoreStyle, m_strMedicineID);
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
        }
        /// <summary>
        /// 计时器刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimitInfo)objController).m_mthFill(m_strStoreStyle, m_strMedicineID);

        }

        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMedicineLimitInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            ((clsCtl_MedicineLimitInfo)objController).m_mthShowBall();
            e.Cancel = true;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimitInfo)objController).m_mthFill(m_strStoreStyle, m_strMedicineID);
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Visible = true;
            this.TopMost = true;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 设置刷新时间值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
        this.timer1.Interval = (int)numericUpDown1.Value * 1000;
        }

        /// <summary>
        /// 药品定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimitInfo)objController).m_mthToPosition();

        }

        #endregion

        private void m_cmdRefesh_Click(object sender, EventArgs e)
        {
            ((clsCtl_MedicineLimitInfo)objController).m_mthFill(m_strStoreStyle, m_strMedicineID);
        }




    }
}