using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPCrytalReport : Form
    {
        /// <summary>
        /// 把两张报表文件(OPCrystalReport.rpt,CrystalReportOPSRoom.rpt)放于Debug\REPORT文件下
        /// </summary>
        /// <param name="p_intType">1: 手术申请单, 2:为记录单</param>
        public frmOPCrytalReport(int p_intType)
        {
            m_intType = p_intType;
            InitializeComponent();
        }
        #region 手术申请单(对应于窗体上每个控件的值)
        public string TextName = "";
        public string TextSex = "";
        public string TextAge = "";
        public string TextCard = "";
        public string TextDept = "";
        public string TextOP = "";
        public string Textyear = "";
        public string Textmonth = "";
        public string Textday = "";
        public string Texttime = "";
        public string Textsecond = "";
        public string TextTip = "";
        public string TextSinature = "";
        public string Textkaidantime = "";
        #endregion

        #region 为记录单(对应于窗体上每个控件的值)
        public string TextYearRoom = "";
        public string TextMonthRoom = "";
        public string TextdayRoom = "";
        public string TextNameRoom = "";
        public string Text1SexRoom = "";
        public string Text1AgeRoom = "";
        public string TextInPNoRoom = "";
        public string Text1CardRoom = "";
        public string TextDeptRoom = "";
        public string TextDiagoseRoom = "";
        public string TextDialogseAfterRoom = "";
        public string TextOPERRoom = "";
        public string TextHelperRoom = "";
        public string TextCarRoom = "";
        public string TextWayRoom = "";
        public string TextWayERRoom = "";
        public string TextStepRoom = "";
        public string TextDocNameRoom = "";
        public string TextTimeRoom = "";
        public string TextOPNameRoom = "";
        
        #endregion
        private int m_intType = 0;
        private void frmOPCrytalReport_Load(object sender, EventArgs e)
        {
            string strPath = "";
            if (m_intType == 1)
            {
                strPath = System.Windows.Forms.Application.StartupPath + "\\REPORT\\OPCrystalReport.rpt";
                reportDocument1.Load(strPath);
                #region get values  
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextName"]).Text = TextName;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextSex"]).Text = TextSex;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextAge"]).Text = TextAge;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextCard"]).Text = TextCard;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextDept"]).Text = TextDept;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextOP"]).Text = TextOP;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Textyear"]).Text = Textyear;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Textmonth"]).Text = Textmonth;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Textday"]).Text = Textday;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Texttime"]).Text = Texttime;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Textsecond"]).Text = Textsecond;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextTip"]).Text = TextTip;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextSinature"]).Text = TextSinature;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Textkaidantime"]).Text = Textkaidantime;
                #endregion              
                reportDocument1.Refresh();
 
            }
            else if (m_intType == 2)
            {
                strPath = System.Windows.Forms.Application.StartupPath + "\\REPORT\\CrystalReportOPSRoom.rpt";
                reportDocument1.Load(strPath);
                #region get values
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextOPNameRoom"]).Text = TextOPNameRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextYearRoom"]).Text = TextYearRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextMonthRoom"]).Text = TextMonthRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextdayRoom"]).Text = TextdayRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextNameRoom"]).Text = TextNameRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Text1SexRoom"]).Text = Text1SexRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Text1AgeRoom"]).Text = Text1AgeRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextInPNoRoom"]).Text = TextInPNoRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["Text1CardRoom"]).Text = Text1CardRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextDeptRoom"]).Text = TextDeptRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextDiagoseRoom"]).Text = TextDiagoseRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextDialogseAfterRoom"]).Text = TextDialogseAfterRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextOPERRoom"]).Text = TextOPERRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextHelperRoom"]).Text = TextHelperRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextCarRoom"]).Text = TextCarRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextWayRoom"]).Text = TextWayRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextWayERRoom"]).Text = TextWayERRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextStepRoom"]).Text = TextStepRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextDocNameRoom"]).Text = TextDocNameRoom;
                ((TextObject)reportDocument1.ReportDefinition.ReportObjects["TextTimeRoom"]).Text = TextTimeRoom;
                #endregion 
                reportDocument1.Refresh();
            }
            crystalReportViewer1.ReportSource = reportDocument1;
        }
    }
}