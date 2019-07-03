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
    public partial class frmRptCriticalDeal : Form
    {
        public frmRptCriticalDeal()
        {
            InitializeComponent();
        }


        private void frmRptCriticalDeal_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = Application.StartupPath + "\\criticalreport.pbl";//clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "t_criticaldeal_stat";
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");
        }

        #region
        public class EntityCriticalDeal
        {
            public string appdeptname { get; set; }
            public long cvmSum { get; set; }
            public long unres { get; set; }
            public string unresPer { get; set; }
            public long undeal { get; set; }
            public string undealPer { get; set; }
        }
        #endregion

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DateTime? recorddate = null;
            DateTime? responsedate = null;
            DateTime? doctadvicedate = null;
            bool flg = false;
            string appdeptname = string.Empty;
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            List<EntityCriticalDeal> data = new List<EntityCriticalDeal>();

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在项目信息，请稍候...");
                dwRep.Reset();
                clsHISReportZy_Supported_Svc svc = (clsHISReportZy_Supported_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHISReportZy_Supported_Svc));
                DataTable dt = svc.GetCriticalDeal(BeginDate, EndDate);

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        flg = false;
                        appdeptname = dr["appdeptname"].ToString();
                        if (string.IsNullOrEmpty(appdeptname))
                            continue;
                        if (dr["recorddate"].ToString() != "")
                                recorddate = Convert.ToDateTime(dr["recorddate"].ToString());
                        else 
                            continue;

                        if (dr["responsedate"].ToString() != "")
                            responsedate = Convert.ToDateTime(dr["responsedate"].ToString());
                        else
                            responsedate = System.DateTime.Now;

                        if (dr["doctadvicedate"].ToString() != "")
                            doctadvicedate = Convert.ToDateTime(dr["doctadvicedate"].ToString());
                        else
                            doctadvicedate = System.DateTime.Now;

                        TimeSpan tsRespon = responsedate.Value - recorddate.Value;
                        TimeSpan tsDeal = doctadvicedate.Value - recorddate.Value;
                       

                        if (data.Count > 0)
                        {
                            for (int i = 0; i < data.Count; i++)
                            {
                                if (appdeptname == data[i].appdeptname)
                                {
                                    if (tsRespon.TotalMinutes >= 360)
                                    {
                                        data[i].unres++;
                                        data[i].unresPer = Math.Round(((double)data[i].unres / (double)data[i].cvmSum) * 100, 1).ToString() + "%";
                                    }
                                
                                    if (tsDeal.TotalMinutes >= 360)
                                    {
                                        data[i].undeal++;
                                        data[i].undealPer = Math.Round(((double)data[i].undeal / (double)data[i].cvmSum) * 100, 1).ToString() + "%";
                                    }

                                    flg = true;
                                    break;
                                }
                            }
                        }
                        if (!flg)
                        {
                            EntityCriticalDeal vo = new EntityCriticalDeal();
                            vo.appdeptname = appdeptname;
                            vo.unres = 0;
                            vo.undeal = 0;
                            vo.undealPer = " ";
                            vo.unresPer = " ";
                            DataRow[] drr = dt.Select("appdeptname = '" + appdeptname + "' and recorddate is not null");
                            vo.cvmSum = drr.Length;

                            if (tsRespon.TotalMinutes >= 360)
                            {
                                vo.unres++;
                                vo.unresPer = Math.Round(((double)vo.unres / (double)vo.cvmSum) * 100, 1).ToString() + "%";
                            }

                            if (tsDeal.TotalMinutes >= 360)
                            {
                                vo.undeal++;
                                vo.undealPer = Math.Round(((double)vo.undeal / (double)vo.cvmSum) * 100, 1).ToString() + "%";
                            }

                            data.Add(vo);
                        }
                    }
                }

                if (data != null && data.Count > 0)
                {
                    int row = 0;
                    dwRep.SetRedrawOff();
                    for (int i = 0; i < data.Count; i++)
                    {
                        row = dwRep.InsertRow(0);
                        dwRep.SetItemString(row, "appdeptname", data[i].appdeptname);
                        dwRep.SetItemString(row, "cvm_total", data[i].cvmSum.ToString());
                        dwRep.SetItemString(row, "unres_total", data[i].unres.ToString() == "0" ? "" : data[i].unres.ToString());
                        dwRep.SetItemString(row, "unres_per", data[i].unresPer.ToString());
                        dwRep.SetItemString(row, "undeal_total", data[i].undeal.ToString() == "0" ? "" : data[i].undeal.ToString());
                        dwRep.SetItemString(row, "undeal_per", data[i].undealPer);
                    }
                    dwRep.SetRedrawOn();
                }
                else
                {
                    dwRep.InsertRow(0);
                }
               
                dwRep.Modify("t_date.text = '" + BeginDate + " ~ " + EndDate + "'");
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
