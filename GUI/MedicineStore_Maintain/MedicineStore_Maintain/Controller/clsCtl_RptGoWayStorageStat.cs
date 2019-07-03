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
    public class clsCtl_RptGoWayStorageStat : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 控制窗体
        /// </summary>
        private frmRptGoWayStorageStat m_objViewer;
        /// <summary>
        /// 模块控制
        /// </summary>
        private clsDcl_RptGoWayStorageStat m_objDomain;
        /// <summary>
        /// 药品类型
        /// </summary>
        private DataView dtvMedType;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string strHospitalName;
        private DataTable dtResult;
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_RptGoWayStorageStat()
        {
            m_objDomain = new clsDcl_RptGoWayStorageStat();
        }

        /// <summary>
        /// 窗体控制
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptGoWayStorageStat)frmMDI_Child_Base_in;
        }

        /// <summary>
        /// 报表初始化
        /// </summary>
        internal void m_mthInitdw()
        {
            strHospitalName = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle();
            this.m_objViewer.dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_ms.pbl";
            if (this.m_objViewer.m_blnIsDrugStore)
            {
                this.m_objViewer.dw.DataWindowObject = "ms_rptgowaystoragestat";
            }
            else
            {
                this.m_objViewer.dw.DataWindowObject = "ms_rptgowaymedstoragestat";
            }
            this.m_objViewer.dw.Modify("texttitlename.text='" + strHospitalName + "'");
        }

        /// <summary>
        /// 获取库房名称
        /// </summary>
        /// <param name="p_intMsOrDs"></param>
        /// <param name="p_dtbMedName"></param>
        internal void m_mthGetMsOrDsName(int p_intMsOrDs, out DataTable p_dtbMedName)
        {
            long lngRes = m_objDomain.m_mthGetMsOrDsName(p_intMsOrDs, out p_dtbMedName);
        }

        /// <summary>
        /// 药品类型绑定
        /// </summary>
        public void m_mthGetMedType()
        {
            DataTable dtMedType;
            long lngRes = m_objDomain.m_lngGetMedicineType(out dtMedType);
            this.dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtMedType.m_mthInitListView(column2);
            this.m_objViewer.txtMedType.m_dtbDataSourse = null;

            this.m_objViewer.txtMedType.m_listView.Items.Clear();
            DataTable dtValue = dtvMedType.ToTable();
            DataRow drTmp = dtValue.NewRow();
            drTmp["medicinetypeid_chr"] = "";
            drTmp["medicinetypename_vchr"] = "全部";
            dtValue.BeginLoadData();
            dtValue.Rows.Add(drTmp);
            dtValue.EndLoadData();

            this.m_objViewer.txtMedType.m_dtbDataSourse = dtValue;
            this.m_objViewer.txtMedType.m_mthFillData();
        }

        /// <summary>
        /// 领用部门
        /// </summary>
        /// <param name="p_intMsOrDs"></param>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetDept(out DataTable p_dtbExportDept)
        {
            if (this.m_objViewer.m_blnIsDrugStore)
            {
                m_objDomain.m_lngGetExportDeptForDrugStore(out p_dtbExportDept); //药房
            }
            else
            {
                m_objDomain.m_lngGetExportDept(out p_dtbExportDept); //药库
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        internal void m_mthPrint()
        {
            if (this.m_objViewer.dw.RowCount > 0)
            {
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public clsPub = new com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public();
                clsPub.ChoosePrintDialog(this.m_objViewer.dw, true);
            }
        }

        /// <summary>
        /// 导出
        /// </summary>
        internal void m_mthExploreData()
        {
            if (this.m_objViewer.m_blnIsDrugStore)
            {
                if (this.m_objViewer.m_dgvGoWayStorageStat.Rows.Count > 0)
                {
                    com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_objViewer.m_dgvGoWayStorageStat);
                }
            }
            else
            {
                if (this.m_objViewer.m_dgvGoWayMedStorageStat.Rows.Count > 0)
                {
                    com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_objViewer.m_dgvGoWayMedStorageStat);
                }
            }
        }

        /// <summary>
        /// 药品去向汇总统计数据
        /// </summary>
        public void m_mthSearchData()
        {
            //DateTime dtmBegin = Convert.ToDateTime(this.m_objViewer.m_dtpBeginDate.Text);
            //DateTime dtmEnd = Convert.ToDateTime(this.m_objViewer.m_dtpEndDate.Text);
            DateTime dtmBegin, dtmEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpBeginDate.Text, out dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpEndDate.Text, out dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string strMedStorageid;
            string strMedTypeid = "";
            
            strMedStorageid = this.m_objViewer.m_cboMedStorage.SelectItemValue.ToString().Trim();

            if (!string.IsNullOrEmpty(this.m_objViewer.txtMedType.Value))
            {
                strMedTypeid = this.m_objViewer.txtMedType.Value.ToString();
            }

            long lngRes = 0;

            string strDeptid = "";
            if (this.m_objViewer.m_txtReceiveDept.Text.Trim() != "")
                strDeptid = this.m_objViewer.m_txtReceiveDept.StrItemId;
            lngRes = m_objDomain.m_mthSearchData(this.m_objViewer.m_blnIsDrugStore, dtmBegin, dtmEnd, strMedStorageid, strMedTypeid, strDeptid, out dtResult);


            if (lngRes > 0)
            {
                if (this.m_objViewer.m_blnIsDrugStore)
                {
                    this.m_objViewer.m_dgvGoWayStorageStat.DataSource = dtResult;
                }
                else
                {
                    this.m_objViewer.m_dgvGoWayMedStorageStat.DataSource = dtResult;

                    double dbloutamount2 = 0d;
                    double dbloutamountSum = 0d;
                    double dblopramount2 = 0d;
                    double dblopramountSum = 0d;
                    double dbloutallamount = 0d;
                    double dbloutallamountSum = 0d;
                    int iRowCount2 = dtResult.Rows.Count;
                    DataRow drTemp = null;
                    for (int i = 0; i < iRowCount2; i++)
                    {
                        drTemp = dtResult.Rows[i];
                        double.TryParse(Convert.ToString(drTemp["outstorageprice"]), out dbloutamount2);
                        double.TryParse(Convert.ToString(drTemp["retailprice"]), out dblopramount2);
                        double.TryParse(Convert.ToString(drTemp["retailoutloss"]), out dbloutallamount);
                        dbloutamountSum += Convert.ToDouble(dbloutamount2.ToString("0.0000"));
                        dblopramountSum += Convert.ToDouble(dblopramount2.ToString("0.0000"));
                        dbloutallamountSum += Convert.ToDouble(dbloutallamount.ToString("0.0000"));
                    }
                    this.m_objViewer.m_lbloutstoragepriceSum.Text = dbloutamountSum.ToString("#,##0.0000")+"元";
                    this.m_objViewer.m_lblretailpriceSum.Text = dblopramountSum.ToString("#,##0.0000") + "元";
                    this.m_objViewer.m_lblretailoutlossSum.Text = dbloutallamountSum.ToString("#,##0.0000") + "元";
                    drTemp = null;

                }
                m_mthInitdw();
                string strMedType = this.m_objViewer.txtMedType.Text.Trim();
                if (this.m_objViewer.txtMedType.Text.Trim() == "")
                {
                    strMedType = "全部";
                }
                string strDeptName = this.m_objViewer.m_txtReceiveDept.Text.Trim();
                if (this.m_objViewer.m_txtReceiveDept.Text.Trim() == "")
                {
                    strDeptName = "全部";
                }
                string t_loginname = m_objViewer.LoginInfo.m_strEmpName.ToString();
                this.m_objViewer.dw.SetRedrawOff();
                this.m_objViewer.dw.Modify("t_storagename.text='" + "(" + this.m_objViewer.m_cboMedStorage.SelectItemText + ")" + "'");
                this.m_objViewer.dw.Modify("t_deptname.text='领用单位：" + strDeptName + "'");
                this.m_objViewer.dw.Modify("t_medtype.text='药品分类：" + strMedType + "'");
                this.m_objViewer.dw.Modify("t_loginname.text='" + t_loginname + "'");
                this.m_objViewer.dw.Modify("t_datetext.text='" + dtmBegin.ToString("yyyy-MM-dd HH:mm:ss") + "  ---  " + dtmEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Retrieve(dtResult);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();

                if (!this.m_objViewer.m_blnIsDrugStore)
                {
                    if (!dtResult.Columns.Contains("SortRowNo"))
                    {
                        dtResult.Columns.Add("SortRowNo", typeof(long));
                    }
                    m_mthAddTotalSumRow(dtResult);
                }
            }
        }

        internal void m_mthAddTotalSumRow(DataTable p_dtbResult)
        {
            if (p_dtbResult.Rows.Count > 0)
            {
                double dblTempSum = 0d;
                DataRow drAdd = p_dtbResult.NewRow();
                for (int i1 = 0; i1 < p_dtbResult.Columns.Count; i1++)
                {
                    dblTempSum = 0d;
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "deptname_vchr")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "outstorageprice" || p_dtbResult.Columns[i1].ColumnName.ToLower() == "retailprice" ||
                        p_dtbResult.Columns[i1].ColumnName.ToLower() == "retailoutloss")
                    {
                        for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                        {
                            dblTempSum += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                        }
                        drAdd[i1] = dblTempSum;
                    }
                }
                p_dtbResult.Rows.Add(drAdd);
                p_dtbResult.AcceptChanges();
            }
        }
    }
}
