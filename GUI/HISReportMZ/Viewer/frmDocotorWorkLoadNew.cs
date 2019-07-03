using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.common;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmDocotorWorkLoadNew : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private DataTable m_dtResult;
        public DataTable dtResult
        {
            get { return this.m_dtResult; }
        }
        public string groupid = string.Empty;
        public frmDocotorWorkLoadNew()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 设置控制器
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControlOPDoctorWorkLoadNew();
            this.objController.Set_GUI_Apperance(this);
        }
        private string _strReportName;
        /// <summary>
        /// 报告名称
        /// </summary>
        public string StrReportName
        {
            get { return _strReportName; }
            set { _strReportName = value; }
        }
        private void frmDocotorWorkLoadNew_Load(object sender, EventArgs e)
        {
            //this.radioButton1.g
            this.m_dwShow.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            this.m_cboStatType.SelectedIndex = 1;
            if (StrStatFlag == "1")
            {
                this.m_cboDept.Visible = true; 
                this.m_dwShow.DataWindowObject = "d_op_docotorworkbydept";
                _strReportName=this.m_dwShow.Describe("t_title.text");
                this.m_dwShow.Modify("t_title.text = '" + this.objController.m_objComInfo.m_strGetHospitalTitle() + _strReportName + "'");
                ((clsControlOPDoctorWorkLoadNew)this.objController).m_mthFillDept();
                this.Text += "(按科室汇总)";
            }
            else
            {
                this.gbGroup.Visible = true;
                this.buttonXP2.Visible = true;
                this.buttonXP1.Visible = true;
                this.rbDoctor.Visible = true;
                this.rbGroup.Visible = true;
                this.m_dwShow.DataWindowObject = "d_opdoctorworkloadnewagain";
                _strReportName=this.m_dwShow.Describe("t_title.text");
                this.m_dwShow.Modify("t_title.text = '" + this.objController.m_objComInfo.m_strGetHospitalTitle() + _strReportName + "'");
                this.Text += "(按医生汇总)";
            }

            clsControlChooseGroup m_obj = new clsControlChooseGroup();
            m_obj.m_GetGroupInfo(ref m_dtResult);
        }
        /// <summary>
        /// 0-按医生汇总；1-按科室汇总
        /// </summary>
        public string StrStatFlag = "0";
        public void m_mthShow(string m_strStatFlag)
        {
            StrStatFlag = m_strStatFlag.Trim();
            this.Show();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(this.m_dwShow);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.m_dwShow.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();

                if (FD.FileName.Trim() != "")
                {
                    this.m_dwShow.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                }
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.m_dwShow.PrintProperties.Preview = !this.m_dwShow.PrintProperties.Preview;
            this.m_dwShow.PrintProperties.ShowPreviewRulers = this.m_dwShow.PrintProperties.Preview;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBegin.Value.ToShortDateString()) > Convert.ToDateTime(this.m_datEndTime.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
                if (this.StrStatFlag == "1")
                {
                    ((clsControlOPDoctorWorkLoadNew)this.objController).m_mthBeginStatByDept();
                }
                else
                {
                    ((clsControlOPDoctorWorkLoadNew)this.objController).m_mthBeginStat();
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(this, objEx.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            clsPublic.CloseAvi();
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            frmAidChooseGroup m_objForm = new frmAidChooseGroup();
            m_objForm.obj = this;
            if (m_objForm.ShowDialog() == DialogResult.OK)
            {
                
                this.groupid = m_objForm.GroupID;
            }
            else
            {
                this.groupid = string.Empty;
            }
        }

        private void rbDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbDoctor.Checked)
            {
                this.buttonXP2.Enabled = false;
            }
            else
            {
                this.buttonXP2.Enabled = true;
            }
        }

        private void rbGroup_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbGroup.Checked)
            {
                this.buttonXP1.Enabled = false;
            }
            else
            {
                this.buttonXP1.Enabled = true;
            }
        }
    }
}