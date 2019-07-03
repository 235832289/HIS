using System;
using com.digitalwave.GUI_Base;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    class clsCtlArrearsQuery : clsController_Base
    {
        clsDcl_ReceiptBill objDcl = new clsDcl_ReceiptBill();

        #region 设置窗体对象
        frmArrearsQuery m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmArrearsQuery)frmMDI_Child_Base_in;
        }
        #endregion

        #region 载入页面查询上个月的数据
        /// <summary>
        /// 载入页面查询上个月的数据
        /// </summary>
        public void m_mthLoad()
        {
            m_objViewer.dwRpt.LibraryList = Application.StartupPath + "\\pb_Invioce.pbl";
            m_objViewer.dwRpt.DataWindowObject = "d_op_treatfirst";            
            string strMouthAgoShort = objDcl.m_datGetServerDate().AddMonths(-1).ToShortDateString();
            m_objViewer.datStartDate.Value = DateTime.Parse(strMouthAgoShort + " 00:00:00");
            string strDateNowShort = objDcl.m_datGetServerDate().ToShortDateString();
            m_objViewer.datEndDate.Value = DateTime.Parse(strDateNowShort + " 23:59:59");
           // m_mthQueryArrearsPatient();
            if (m_objViewer.m_strQueryType == "缴费病人")
            {
                this.m_objViewer.dgvPatient.Columns["colinvo"].Visible = true;
            }
        }
        #endregion

        #region 根据选定的时间段查询欠费病人
        /// <summary>
        /// 根据选定的时间段查询欠费病人
        /// </summary>
        public void m_mthQueryArrearsPatient()
        {
            this.m_objViewer.dgvPatient.Rows.Clear();
            string strStartDate = m_objViewer.datStartDate.Value.ToString();
            string strEndDate = m_objViewer.datEndDate.Value.ToString();
            DataTable dtResult = new DataTable();
            long lngRes = -1;
            if (m_objViewer.m_strQueryType == "0")
            {
                lngRes = objDcl.m_lngQueryArrearsPatientByDate(strStartDate, strEndDate, out dtResult, false);
            }
            else if (m_objViewer.m_strQueryType == "1")
            {
                lngRes = objDcl.m_lngQueryPayedPatientByDate(strStartDate, strEndDate, out dtResult);
            }
            else if (m_objViewer.m_strQueryType == "2")
            {
                lngRes = objDcl.m_lngQueryArrearsPatientByDate(strStartDate, strEndDate, out dtResult, true);
            }
            if (lngRes > 0 && dtResult.Rows.Count > 0)
            {
                int row = 0;
                
                foreach (DataRow dr in dtResult.Rows)
                {
                    int i = this.m_objViewer.dgvPatient.Rows.Add();
                    this.m_objViewer.dgvPatient["colname", i].Value = dr["patientname_chr"].ToString();
                    this.m_objViewer.dgvPatient["colcard", i].Value = dr["patientcardid_chr"].ToString();
                    this.m_objViewer.dgvPatient["colsex", i].Value = dr["sex_chr"].ToString();
                    this.m_objViewer.dgvPatient["colrepice", i].Value = dr["outpatrecipeid_chr"].ToString();
                    this.m_objViewer.dgvPatient["colybcard", i].Value = dr["idcard_chr"].ToString();
                    this.m_objViewer.dgvPatient["coldept", i].Value = dr["deptname_chr"].ToString();
                    this.m_objViewer.dgvPatient["coltel", i].Value = dr["homephone_vchr"].ToString();
                    this.m_objViewer.dgvPatient["colfee", i].Value = dr["totalsum_mny"].ToString();
                    this.m_objViewer.dgvPatient["colinvo", i].Value = dr["invoiceno_vchr"].ToString();
                    //报表
                    row = this.m_objViewer.dwRpt.InsertRow();
                    this.m_objViewer.dwRpt.SetItemString(row, "name", dr["patientname_chr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "cardno", dr["patientcardid_chr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "sex", dr["sex_chr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "idcardno", dr["idcard_chr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "recipeno", dr["outpatrecipeid_chr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "deptid", dr["deptname_chr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "tel", dr["homephone_vchr"].ToString());
                    this.m_objViewer.dwRpt.SetItemString(row, "totalmny", dr["totalsum_mny"].ToString());
                }
                int k = this.m_objViewer.dgvPatient.Rows.Add();
                this.m_objViewer.dgvPatient["colybcard", k].Value = "总人数：";
                this.m_objViewer.dgvPatient["coldept", k].Value = dtResult.Rows.Count.ToString() + "人";
                this.m_objViewer.dgvPatient["coltel", k].Value = "总费用：";
                this.m_objViewer.dgvPatient["colfee", k].Value = dtResult.Compute("sum(totalsum_mny)", "").ToString() + "元";
                row = this.m_objViewer.dwRpt.InsertRow();
                this.m_objViewer.dwRpt.SetItemString(row, "idcardno", "总人数：");
                this.m_objViewer.dwRpt.SetItemString(row, "deptid", dtResult.Rows.Count.ToString() + "人");
                this.m_objViewer.dwRpt.SetItemString(row, "tel", "总费用：");
                this.m_objViewer.dwRpt.SetItemString(row, "totalmny", dtResult.Compute("sum(totalsum_mny)", "").ToString() + "元");
                if (m_objViewer.m_strQueryType == "1")
                {
                    this.m_objViewer.dwRpt.Modify("t_title.text='先诊疗后结算缴费报表'");
                }
                else
                {
                    this.m_objViewer.dwRpt.Modify("t_title.text='先诊疗后结算欠费报表'");
                }
                this.m_objViewer.dwRpt.Modify("t_datebegin.text='" + strStartDate + "'");
                this.m_objViewer.dwRpt.Modify("t_dateend.text='" + strEndDate + "'");
                this.m_objViewer.dwRpt.Modify("datawindow.print.preview=yes datawindow.print.preview.rulers=yes");
            }
            else
            {
                int k = this.m_objViewer.dgvPatient.Rows.Add();
                this.m_objViewer.dgvPatient["colybcard", k].Value = "总人数：";
                this.m_objViewer.dgvPatient["coldept", k].Value = "0人";
                this.m_objViewer.dgvPatient["coltel", k].Value = "总费用：";
                this.m_objViewer.dgvPatient["colfee", k].Value = "0元";
            }
        }
        #endregion
    }
}
