using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.common;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmCheckOutOfDaySumByCate : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 门诊收费员分类汇总日结报表

        /// </summary>
        public frmCheckOutOfDaySumByCate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 报表ID
        /// </summary>
        public string m_strRPTID = "1006";

        /// <summary>
        /// 分院收费处科室ID--1100参数
        /// </summary>
        public ArrayList FenyuanSFCdeptIDArr = new ArrayList();
        /// <summary>
        /// 设置具体统计报表
        /// </summary>
        /// <param name="m_strRptID"></param>
        public void m_mthShow(string m_strRptID)
        {
            m_strRPTID = m_strRptID;
            this.Show();
        }
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControllCheckOutOfDaySumCate();
            this.objController.Set_GUI_Apperance(this);
        }

        private void m_btnExport_Click(object sender, EventArgs e)
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

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            this.m_dwShow.PrintProperties.Preview = !this.m_dwShow.PrintProperties.Preview;
            this.m_dwShow.PrintProperties.ShowPreviewRulers = this.m_dwShow.PrintProperties.Preview;
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.PrintDialog(this.m_dwShow);
        }

        private void m_btnStat_Click(object sender, EventArgs e)
        {
            if (Convert.ToDateTime(this.m_datBeginTime.Value.ToShortDateString()) > Convert.ToDateTime(this.m_datEndTime.Value.ToShortDateString()))
            {
                MessageBox.Show("开始统计时间不能大于统计结束时间!", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                return;
            }
            clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
            ((clsControllCheckOutOfDaySumCate)this.objController).m_mthBeginStat();
            clsPublic.CloseAvi();
        }

        private void frmCheckOutOfDaySumByCate_Load(object sender, EventArgs e)
        {
            this.m_cboStatDateType.SelectedIndex = 1;
            #region 收费员列表
            DataTable dt;
            //clsDomainControl_Register domain = new clsDomainControl_Register();

            //domain.m_lngGetCheckMan(out dt, "0");
            this.m_mthGetCheckManByXML(out dt, "0"); // 优化打开速度 by kenny
            if (dt != null)
            {
                this.m_cboCheckMan.Items.Clear();

                if (dt.Rows.Count > 0)
                {
                    this.m_cboCheckMan.Item.Add("全部", "1000");
                    this.m_cboCheckMan.Item.Add("大院", "2000");
                    for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                    {
                        this.m_cboCheckMan.Item.Add(dt.Rows[i1]["LASTNAME_VCHR"].ToString(), dt.Rows[i1]["BALANCEEMP_CHR"].ToString());
                    }
                    this.m_cboCheckMan.SelectedIndex = 0;
                }

            }
            #endregion

            #region 获取收费员所在部门
            DataTable dtdept = null;
            string strEmpId = this.LoginInfo.m_strEmpID.ToString().Trim();
            clsDomainControl_Register domain = new clsDomainControl_Register();
            domain.m_lngGetRegdept(out dtdept,strEmpId);
            if (dtdept != null)
            {
                this.m_cbodept.Items.Clear();

                if (dtdept.Rows.Count > 0)
                {
                    this.m_cbodept.Item.Add("全部", "1000");                    
                    for (int i = 0; i < dtdept.Rows.Count; i++)
                    {
                        this.m_cbodept.Item.Add(dtdept.Rows[i]["deptname_vchr"].ToString(), dtdept.Rows[i]["deptid_chr"].ToString());
                    }
                    this.m_cbodept.SelectedIndex = 0;
                }
            }
            #endregion

            this.m_dwShow.LibraryList = Application.StartupPath + "\\pb_op.pbl";
            this.m_dwShow.DataWindowObject = "d_op_checkoutofdaysumcate";
            string m_strTitle = this.objController.m_objComInfo.m_strGetHospitalTitle() + "门诊收费员分类汇总日结报表";
            this.m_dwShow.Modify("t_title.text='" + m_strTitle + "'");
            this.m_dwShow.PrintProperties.Preview = true;
            this.m_dwShow.PrintProperties.ShowPreviewRulers = true;

            // add by zxm  11-9-20
            string strParam = clsPublic.m_strGetSysparm("1100");
            this.FenyuanSFCdeptIDArr = clsPublic.m_ArrGettoken(strParam, ";");

            ((clsControllCheckOutOfDaySumCate)this.objController).BirthPayTypeID = clsPublic.m_strGetSysparm("0084");
        }

        private void m_mthGetCheckManByXML(out DataTable dtbResult, string internalFlag)
        {
            dtbResult = null;
            // 读取本地
            if (System.IO.File.Exists("dictCheckMan.xml"))
            {
                dtbResult = new DataTable();
                dtbResult.ReadXml("dictCheckMan.xml");
                this.m_mthUpdateLocal("dictCheckMan.xml"); // 异步更新本地XML
            }
            // 没数据则读取数据库
            if (dtbResult == null || dtbResult.Rows.Count == 0)
            {
                clsDomainControl_Register domain = new clsDomainControl_Register();
                domain.m_lngGetCheckMan(out dtbResult, "0");
                this.m_mthWriteXML("dictCheckMan.xml", dtbResult);
            }
        }

        private void m_mthUpdateLocal(string strFileName)
        {
            System.Threading.Thread thrRead = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(m_mthWriteFromDataBase));
            thrRead.IsBackground = true;
            thrRead.Start(strFileName);
        }

        private void m_mthWriteFromDataBase(object sender)
        {
            string strXMLFile = (string)sender;
            DataTable dt = null;
            clsDomainControl_Register domain = new clsDomainControl_Register();
            domain.m_lngGetCheckMan(out dt, "0");
            m_mthWriteXML(strXMLFile, dt);
        }

        private void m_mthWriteXML(string strXMLFile, DataTable dt)
        {
            if (dt != null)
            {
                dt.TableName = "dtbCheckMan";
                dt.WriteXml(strXMLFile, XmlWriteMode.WriteSchema);
            }
        }

        private void m_cbodept_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string strdeptId = this.m_cbodept.SelectItemValue.ToString();
            //DataTable dt;
            //com.digitalwave.iCare.gui.HIS.Reports.clsDomainControl_Register m_objviewer = new com.digitalwave.iCare.gui.HIS.Reports.clsDomainControl_Register();
            //m_objviewer.m_lngGetCheckManByDeptId(out dt, strdeptId);
            //if (dt != null)
            //{
            //    this.m_cboCheckMan.Items.Clear();

            //    if (dt.Rows.Count > 0)
            //    {
            //        this.m_cboCheckMan.Item.Add("全部", "1000");
            //        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            //        {
            //            this.m_cboCheckMan.Item.Add(dt.Rows[i1]["LASTNAME_VCHR"].ToString(), dt.Rows[i1]["BALANCEEMP_CHR"].ToString());
            //        }
            //        this.m_cboCheckMan.SelectedIndex = 0;
            //    }

            //}
        }
                
    }
}