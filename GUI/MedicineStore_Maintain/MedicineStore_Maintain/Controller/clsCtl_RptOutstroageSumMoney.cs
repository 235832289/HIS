using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ControlLibrary;
using Sybase.DataWindow;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsCtl_RptOutstroageSumMoney:com.digitalwave.GUI_Base.clsController_Base
    {

        private frmRptOutstroageSumMoney m_objViewer;
        private clsDcl_OutStorageDetailReport objSvc;
        private DataTable dtMedType;
        public clsCtl_RptOutstroageSumMoney()
        {
            objSvc = new clsDcl_OutStorageDetailReport();
        }
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptOutstroageSumMoney)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            m_objViewer.m_dtpSearchBeginDate.Text = clsPublic.SysDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            this.m_objViewer.m_dtpSearchEndDate.Text = clsPublic.SysDateTimeNow.ToString("yyyy年MM月dd日 HH时mm分ss秒");

            this.m_objViewer.dw.LibraryList = clsPublic.PBLPath;
            this.m_objViewer.dw.DataWindowObject = "outstroage_summonery_3yuna";
            this.m_objViewer.dw.PrintProperties.Preview = true;
            this.m_objViewer.dw.PrintProperties.ShowPreviewRulers = true;
            //this.m_objViewer.dw.InsertRow(0);
            DataTable dtStorge;
            long lngRes = objSvc.m_lngGetMedStroge(out dtStorge);
            lngRes = objSvc.m_lngGetMedType(out dtMedType);

            clsColumns_VO[] column3 = new clsColumns_VO[] { new clsColumns_VO("库房名称", "medicineroomname", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtStoreroom.m_mthInitListView(column3);
            this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtStorge;
            this.m_objViewer.txtStoreroom.m_mthFillData();


            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtMedType;
        }

        public void m_mthChooseMedType(string MedStorgeID)
        {
            this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            if (MedStorgeID.Trim() == "")
            {
                return;
            }

            DataTable dt = this.m_objViewer.txtTypecode.m_dtbDataSourse;
            DataView dtv = new DataView(dt);

            dtv.RowFilter = "medicineroomid='" + MedStorgeID + "'";

            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtv.ToTable();
            this.m_objViewer.txtTypecode.m_mthFillData();
        }

        public void m_mthSearch()
        {
            if (string.IsNullOrEmpty(this.m_objViewer.txtStoreroom.Value))
            {
                MessageBox.Show(this.m_objViewer, "请先选择相应的库房。", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dtResult = null;
            DateTime BegTime = DateTime.Parse(this.m_objViewer.m_dtpSearchBeginDate.Text);
            DateTime EndTime = DateTime.Parse(this.m_objViewer.m_dtpSearchEndDate.Text);
            string strTypecode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strTypecode = this.m_objViewer.txtTypecode.Value.ToString();
            }
            long lngRes = objSvc.m_lngOutStorageSumMoney(BegTime, EndTime, this.m_objViewer.txtStoreroom.Value, "", strTypecode, out dtResult);

            if (lngRes > 0)
            {
                if (dtResult.Rows.Count > 0)
                {
                    DataRow dr = null;
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.SetRedrawOff();
                    this.m_objViewer.dw.Modify("t_outdept.text='" + this.m_objViewer.txtStoreroom.Text + "'");
                    this.m_objViewer.dw.Modify("t_time.text='统计日期：" + BegTime.ToString("yyyy-MM-dd HH:mm:dd") + "---" + EndTime.ToString("yyyy-MM-dd HH:mm:dd") + "'");
                    this.m_objViewer.dw.Modify("t_strempname.text='" + this.m_objViewer.LoginInfo.m_strEmpName + "'");
                    this.m_objViewer.dw.Modify("t_hospitalname.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");

                    for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
                    {
                        dr = dtResult.Rows[i1];

                        int row = this.m_objViewer.dw.InsertRow(0);
                        this.m_objViewer.dw.SetItemString(row, "coldeptid", dr["deptid_chr"].ToString());
                        this.m_objViewer.dw.SetItemString(row, "coldept", dr["deptname_vchr"].ToString());
                        this.m_objViewer.dw.SetItemDecimal(row, "coloutmoney", decimal.Parse(dr["outmoney"].ToString()));
                        this.m_objViewer.dw.SetItemDecimal(row, "colretailmoney", decimal.Parse(dr["retailmoney"].ToString()));

                    }
                    this.m_objViewer.dw.CalculateGroups();
                    this.m_objViewer.dw.SetRedrawOn();
                    this.m_objViewer.dw.Refresh();
                }
                else
                {
                    this.m_objViewer.dw.InsertRow(0);
                }
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "检索失败！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
