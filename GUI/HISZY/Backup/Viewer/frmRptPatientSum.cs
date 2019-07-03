using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;
using ControlLibrary;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 住院病人阶段费用一览表
    /// </summary>
    public partial class frmRptPatientSum : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptPatientSum()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }
        #endregion

        #region 变量
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;
        #endregion              

        private void frmRptPatientSum_Load(object sender, EventArgs e)
        {
            #region 两层事务处理，稍后改回三层。
            string ServerName = "";
            string UserID = "";
            string Pwd = "";
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);

            pbTrans = new Transaction();
            pbTrans.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;
            pbTrans.ServerName = ServerName;
            pbTrans.UserId = UserID;
            pbTrans.Password = Pwd;
            pbTrans.AutoCommit = true;
            pbTrans.Connect();
            #endregion                    
            
            #region 初始化病区
            // 病区列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                                            new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
                                                          };

            this.txtAREAID.m_strSQL = @"select '00' as deptid_chr,
                                               '全院科室' as deptname_vchr,  
                                               'qy' as pycode_chr,
                                               '00' as code_vchr   
                                          from dual
                                        union all              
                                        select a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                          from t_bse_deptdesc a
                                         where a.status_int = 1 
                                           and a.attributeid = '0000003'";

            this.txtAREAID.m_mthInitListView(columArr);
            this.txtAREAID.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            #endregion

            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_patientsum";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "住院病人阶段费用一览表'"); 
        }                   

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.txtAREAID.Value == null || this.txtAREAID.Value.ToString().Trim()=="")
            {
                MessageBox.Show("请选择科室(病区)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;               
            }

            clsPublic.PlayAvi("findFILE.avi", "正在统计费用数据，请稍候...");
            this.dwRep.DataWindowObject = null;
            this.dwRep.DataWindowObject = "d_bih_patientsum";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "住院病人阶段费用一览表'");
            this.dwRep.Modify("t_dept.text = '科别： " + this.txtAREAID.Text.Trim() + "'"); 
            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.SetTransaction(pbTrans);          
            this.objReport.m_mthRptPatientSum(this.txtAREAID.Value.ToString().Trim(), this.dwRep);
            clsPublic.CloseAvi();

            this.dwRep.Refresh();  
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
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_dept.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "ALL";

                clsPublic.ExportDataWindow(this.dwRep, volExcel);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
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