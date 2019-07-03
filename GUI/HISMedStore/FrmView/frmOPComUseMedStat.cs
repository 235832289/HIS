using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HI;
using System.Collections.Generic;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 门诊医生常用药统计报表
    /// </summary>
    public partial class frmOPComUseMedStat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmOPComUseMedStat()
        {
            InitializeComponent();
        }
        public List<string> m_objMedTypeList;
        public void SetMedTypeShow(string  m_strParams)
        {
            string[] Objects = m_strParams.Split('*');
            m_objMedTypeList = new List<string>();
            foreach (object obj in Objects)
            {
                m_objMedTypeList.Add(obj.ToString());
            }
            this.Show();
        }
        public string m_strType = string.Empty;
        public void SetStatType(string m_strParams)
        {
            string[] Objects = m_strParams.Split('*');
            for (int i = 0; i < Objects.Length; i++)
            {
                m_strType += "'" + Objects[i].ToString() + "'";
                if (i != Objects.Length - 1)
                {
                    m_strType += ",";
                }
            }
            this.Show();
        }
        private void frmOPComUseMedStat_Load(object sender, EventArgs e)
        {
            this.dwMed.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            if (m_objMedTypeList != null)
            {
                this.Text = "门诊医生常用药统计报表";
                this.m_datBegin.Value = this.m_datBegin.Value.AddDays(-this.m_datBegin.Value.Day + 1);
                ((clsControlDoctorUseMed)this.objController).m_mthGetMedTypeInfo(m_objMedTypeList);
                this.dwMed.DataWindowObject = "d_doctormed_rpt";
                this.buttonXP2.Visible = false;
            }
            else
            {
                this.Text = "门诊科室药品费用比例报表";
                this.dwMed.DataWindowObject = "d_opdeptusemedpercentstat";
                this.buttonXP1.Visible = false;
                this.numericUpDown1.Visible = false;
                this.btnClose.Visible = false;
                this.m_btnStat.Visible = false;
            }
            ((clsControlDoctorUseMed)this.objController).m_mthFillDept();
        }
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControlDoctorUseMed();
            this.objController.Set_GUI_Apperance(this);
        }

        private void m_btnStat_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBegin.Value.ToShortDateString())> Convert.ToDateTime(this.m_datEnd.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
            ((clsControlDoctorUseMed)this.objController).GetDoctorUseMedInfo(1);
            clsPublic.CloseAvi();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBegin.Value.ToShortDateString()) > Convert.ToDateTime(this.m_datEnd.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
            ((clsControlDoctorUseMed)this.objController).GetDoctorUseMedInfo(2);
            clsPublic.CloseAvi();
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.dwMed.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.dwMed.Print(false, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwMed.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();

                if (FD.FileName.Trim() != "")
                {
                    this.dwMed.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                }
            }
        }
        public string m_strStatDocotr = string.Empty;
        private void buttonXP1_Click(object sender, EventArgs e)
        {
            frmAidChooseDoct m_objForm = new frmAidChooseDoct();
            if (m_objForm.ShowDialog() == DialogResult.OK)
            {
                m_strStatDocotr = m_objForm.DoctIDArr;
            }
            else
            {
                m_strStatDocotr = string.Empty;
            }
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBegin.Value.ToShortDateString()) > Convert.ToDateTime(this.m_datEnd.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
            ((clsControlDoctorUseMed)this.objController).m_mthGetMedFeePercent();
            clsPublic.CloseAvi();
        }
    }
}