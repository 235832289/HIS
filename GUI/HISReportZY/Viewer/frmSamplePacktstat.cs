using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS.Report;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmSamplePacktstat : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmSamplePacktstat()
        {
            InitializeComponent();
        }

        public string deptStr { get; set; }
        frmCritialDeptList frm;

        #region 事件

        private void frmSamplePacktstat_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_samppack_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy年MM月dd日") + "00时00分");
            init();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Query();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsVolDatawindowToExcel[] volExcel = new clsVolDatawindowToExcel[2];

                volExcel[0] = new clsVolDatawindowToExcel(1);
                volExcel[0].m_rowheight[0] = 20;
                volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
                volExcel[0].m_HorizontalAlignment[0] = "0";
                volExcel[0].m_firstcommn[0] = "A1";
                volExcel[0].m_endcommn[0] = "ALL";

                volExcel[1] = new clsVolDatawindowToExcel(1);
                volExcel[1].m_rowheight[0] = 20;
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "ALL";

                clsPublic.ExportDataWindow(this.dwRep, volExcel);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnDeptSelect_Click(object sender, EventArgs e)
        {
            frm = new frmCritialDeptList(0);
            frm.ShowDialog();
        }

        private void chkChecked_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkChecked.Checked)
            {
                chkUnchecked.Checked = false;
                chkRefuseCheck.Checked = false;
            }
        }

        private void chkUnchecked_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUnchecked.Checked)
            {
                chkChecked.Checked = false;
                chkRefuseCheck.Checked = false;
            }
        }

        private void chkRefuseCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRefuseCheck.Checked)
            {
                chkUnchecked.Checked = false;
                chkChecked.Checked = false;
            }
        }
        #endregion

        #region 方法

        #region
        internal void Query()
        {
            List<string> lstParam = new List<string>();
            string beginDate = string.Empty;
            string endDate = string.Empty;
            string sampleType= string.Empty;
            string patName= string.Empty;
            string barCode= string.Empty; 
            string peno= string.Empty;
            string ownerDept = string.Empty;
            //string deptStr= string.Empty;
            int checkState = 0;

            getdeptstr();
            if (!chkDeptSelect.Checked)
            {
                lstParam.Add("ownerDept");
                deptStr = "('" + this.LoginInfo.m_strDepartmentID + "','" + this.LoginInfo.m_strInpatientAreaID+ "')";
            }
            else
            {
                lstParam.Add("deptStr");
            }

           //this.LoginInfo.m_strDepartmentID

            beginDate = this.dteRq1.Value.ToString("yyyy-MM-dd HH:mm");
            endDate = this.dteRq2.Value.ToString("yyyy-MM-dd HH:mm");
            int timeType = this.cboTimeType.SelectedIndex;
            
            lstParam.Add("queryDate");

            if (Convert.ToDateTime(beginDate + " :01") > Convert.ToDateTime(endDate + ":59"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.cboSampleType.Text.Trim() != string.Empty)
            {
                lstParam.Add("sampleType");
                sampleType = cboSampleType.Text.Trim();
            }

            if (this.txtBarcode.Text.Trim() != string.Empty)
            {
                lstParam.Add("barCode");
                barCode = this.txtBarcode.Text;
            }

            if (this.txtPatName.Text.Trim() != string.Empty)
            {
                lstParam.Add("patName");
                patName = this.txtPatName.Text;
            }

            if (this.txtPeno.Text.Trim() != string.Empty)
            {
                lstParam.Add("peno");
                peno = this.txtPeno.Text;
            }

            if (this.chkChecked.Checked == true)
            {
                lstParam.Add("check");
                checkState = 1;
            }

            if (this.chkUnchecked.Checked == true)
            {
                lstParam.Add("check");
                checkState = 2;
            }

            if (this.chkRefuseCheck.Checked == true)
            {
                lstParam.Add("check");
                checkState = 3;
            }

             try
                {
                    clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                    dwRep.Reset();
                    clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                    DataTable dt = svc.GetSamplePackStat(lstParam, beginDate, endDate, sampleType, patName, barCode, peno, deptStr, checkState, timeType);

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int row = 0;
                        dwRep.SetRedrawOff();
                        foreach (DataRow dr in dt.Rows)
                        {
                            row = dwRep.InsertRow(0);
                            dwRep.SetItemString(row, "barcode", dr["barcode"].ToString());
                            dwRep.SetItemString(row, "patcardno", dr["patcardno"].ToString().Trim());
                            if (dr["peno"].ToString().Trim().Length < 12)
                                dwRep.SetItemString(row, "inpatno", dr["peno"].ToString().Trim());
                            else
                                dwRep.SetItemString(row, "peno", dr["peno"].ToString().Trim());
                            dwRep.SetItemString(row, "pattype", dr["pattype"].ToString());
                            dwRep.SetItemString(row, "patname", dr["patname"].ToString());
                            dwRep.SetItemString(row, "sampletype", dr["sampletype"].ToString());
                            dwRep.SetItemString(row, "checkcontent", dr["checkcontent"].ToString());
                            dwRep.SetItemString(row, "applyername", dr["applyername"].ToString());
                            dwRep.SetItemString(row, "deptname", dr["deptname"].ToString());
                            dwRep.SetItemString(row, "packtime", dr["packtime"] != DBNull.Value ? Convert.ToDateTime(dr["packtime"].ToString()).ToString("yyyy-MM-dd HH:mm") : "");
                            dwRep.SetItemString(row, "packname", dr["packname"].ToString());
                            dwRep.SetItemString(row, "checktime", dr["checktime"] != DBNull.Value ? Convert.ToDateTime(dr["checktime"].ToString()).ToString("yyyy-MM-dd HH:mm") : "");
                            dwRep.SetItemString(row, "checkname", dr["checkname"].ToString());
                            dwRep.SetItemString(row, "rechecktime", dr["rechecktime"] != DBNull.Value ? Convert.ToDateTime(dr["rechecktime"].ToString()).ToString("yyyy-MM-dd HH:mm") : "");
                            dwRep.SetItemString(row, "recheckreason", dr["recheckreason"].ToString());
                        }
                        dwRep.SetRedrawOn();
                    }
                    else
                    {
                        dwRep.InsertRow(0);
                    }

                    dwRep.Modify("t_date.text = '" + beginDate + " ~ " + endDate + "'");
                }
                finally
                {
                    lstParam = null;
                    clsPublic.CloseAvi();
                }
                this.dwRep.Refresh();

        }
        #endregion

        public void init()
        {
            //标本类型绑定数据
            #region
            clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
            DataTable dt = svc.GetSampleType();
            this.cboSampleType.Items.Add("全部");
            this.cboTimeType.Items.Add("核收时间");
            this.cboTimeType.Items.Add("开单时间");
            this.cboTimeType.SelectedIndex = 0;

            try
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        this.cboSampleType.Items.Add(dr["sample_type_desc_vchr"].ToString());
                    }
                }
            }
            finally
            {
                svc = null;
            }
            #endregion
        }

        public void getdeptstr()
        {
            if (frm != null)
                deptStr = frm.deptStr;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
