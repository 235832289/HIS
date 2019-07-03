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
    public class clsCtl_RptGoWayStat : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmRptGoWayStat m_objViewer;
        private clsDcl_RptGoWayStat m_objDomain;
        private DataView dtvMedType;
        public clsCtl_RptGoWayStat()
        {
            m_objDomain = new clsDcl_RptGoWayStat();
        }

        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptGoWayStat)frmMDI_Child_Base_in;
        }

        public void m_mthInit()
        {
            this.m_objViewer.dw.LibraryList = clsPublic.PBLPath;
            this.m_objViewer.dw.DataWindowObject = "ms_gowaystat";
            this.m_objViewer.dw.InsertRow(0);
            
            DataTable dtMedType;
            long lngRes = m_objDomain.m_lngGetMedicineType(out dtMedType);
            this.dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = null;
        }

        public void m_mthSearch()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            //DateTime dtm1 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchBeginDate.Text);
            //DateTime dtm2 = Convert.ToDateTime(this.m_objViewer.m_dtpSearchEndDate.Text);
            DateTime dtm1, dtm2;
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchBeginDate.Text, out dtm1))
            {
                MessageBox.Show("请输入查询开始时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpSearchEndDate.Text, out dtm2))
            {
                MessageBox.Show("请输入查询结束时间", "入库明细报表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable dt;
                       
            string strMedTypeCode = "";        
            
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }


            long lngRes = m_objDomain.m_lngGetGoWayStat(m_objViewer.m_strDeptID, dtm1, dtm2, strMedTypeCode,out dt,out m_objViewer.m_dblSumMoney);
            if (lngRes > 0)
            {
                DataTable dtdgv = new DataTable();
                dtdgv.Columns.Add("deptname_vchr", typeof(String));
                dtdgv.Columns.Add("outamount", typeof(Double));
                dtdgv.Columns.Add("opramount", typeof(Double));
                dtdgv.Columns.Add("putamount", typeof(Double));
                dtdgv.Columns.Add("outallamount", typeof(Double));

                int iRowCount = dt.Rows.Count;
                DataRow dr = null;
                DataRow dr2 = null;
                double dbloutamount = 0d;
                double dblopramount = 0d;
                double dblputamount = 0d;
                dr = dtdgv.NewRow();
                for (int i = 0; i < iRowCount; i++)
                {
                    dr2 = dt.Rows[i];
                    double.TryParse(Convert.ToString(dr2["outamount"]), out dbloutamount);
                    double.TryParse(Convert.ToString(dr2["opramount"]), out dblopramount);
                    double.TryParse(Convert.ToString(dr2["putamount"]), out dblputamount);
                    dr["deptname_vchr"] = dr2["deptname_vchr"];
                    dr["outamount"] = dbloutamount;
                    dr["opramount"] = dblopramount;
                    dr["putamount"] = dblputamount;
                    dr["outallamount"] = dbloutamount + dblopramount + dblputamount;
                    dtdgv.Rows.Add(dr.ItemArray);
                }
                dtdgv.AcceptChanges();
                dr = null;
                dr2 = null;

                this.m_objViewer.m_dgvGoWayStat.DataSource = dtdgv;

                double dbloutamount2 = 0d;
                double dbloutamountSum = 0d;
                double dblopramount2 = 0d;
                double dblopramountSum = 0d;
                double dbloutallamount = 0d;
                double dbloutallamountSum = 0d;
                int iRowCount2 = dtdgv.Rows.Count;
                DataRow drTemp = null;
                for (int i = 0; i < iRowCount2; i++)
                {
                    drTemp = dtdgv.Rows[i];
                    double.TryParse(Convert.ToString(drTemp["outamount"]), out dbloutamount2);
                    double.TryParse(Convert.ToString(drTemp["opramount"]), out dblopramount2);
                    double.TryParse(Convert.ToString(drTemp["outallamount"]), out dbloutallamount);
                    dbloutamountSum += Convert.ToDouble(dbloutamount2.ToString("0.0000"));
                    dblopramountSum += Convert.ToDouble(dblopramount2.ToString("0.0000"));
                    dbloutallamountSum += Convert.ToDouble(dbloutallamount.ToString("0.0000"));
                }
                this.m_objViewer.m_lboutamountSum.Text = dbloutamountSum.ToString("#,##0.0000");
                this.m_objViewer.m_lblopramount.Text = dblopramountSum.ToString("#,##0.0000");
                this.m_objViewer.lblOutall.Text = dbloutallamountSum.ToString("#,##0.0000");
                drTemp = null;

                if (dt == null || dt.Rows.Count == 0)
                {
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    MessageBox.Show(this.m_objViewer, "未能找到出库数据。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
                
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.SetRedrawOff();

                this.m_objViewer.dw.Modify("t_title.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "'");
                this.m_objViewer.dw.Modify("m_strdate.text='" + dtm1.ToString("yyyy-MM-dd HH:mm:ss") + " ---- " + dtm2.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("m_strstoragename.text='" +  m_objViewer.m_strDrugStoreName + "'");
                this.m_objViewer.dw.Modify("t_summoney.text='" + m_objViewer.m_dblSumMoney.ToString("F4") + "'");
                if (strMedTypeCode == "-1" || strMedTypeCode == "")
                {
                    this.m_objViewer.dw.Modify("t_strmedicinetypename.text='全部'");
                }
                else
                {
                    this.m_objViewer.dw.Modify("t_strmedicinetypename.text='" + m_objViewer.txtTypecode.Text+ "'");
                }
                this.m_objViewer.dw.Retrieve(dt);                
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();

                if (!dtdgv.Columns.Contains("SortRowNo"))
                {
                    dtdgv.Columns.Add("SortRowNo", typeof(long));
                }
                m_mthAddTotalSumRow(dtdgv);
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "检索数据出错，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.m_objViewer.Cursor = Cursors.Default;
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
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "opramount")
                    {
                        drAdd[i1] = m_objViewer.m_dblSumMoney;
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "outamount")//出库金额
                    {
                        m_objViewer.m_dblOutMoney = 0;
                        for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                        {
                            m_objViewer.m_dblOutMoney += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                        }
                        drAdd[i1] = m_objViewer.m_dblOutMoney;
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "putamount")
                    {
                        m_objViewer.m_dblPutMoney = 0;
                        for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                        {
                            m_objViewer.m_dblPutMoney += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                        }
                        drAdd[i1] = m_objViewer.m_dblPutMoney;
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "outallamount")
                    {
                        m_objViewer.m_dblDiffMoney = m_objViewer.m_dblOutMoney + m_objViewer.m_dblSumMoney + m_objViewer.m_dblPutMoney;
                        drAdd[i1] = m_objViewer.m_dblDiffMoney;
                    }
                    //else if (p_dtbResult.Columns[i1].ColumnName.ToLower() != "instoredept_chr" && p_dtbResult.Columns[i1].ColumnName.ToLower() != "sortrowno")
                    //{
                    //    for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                    //    {
                    //        dblTempSum += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                    //    }
                    //    drAdd[i1] = dblTempSum;
                    //}

                    m_objViewer.dw.Modify("t_outmoney.text = '" + m_objViewer.m_dblOutMoney.ToString("F4") + "'");
                    m_objViewer.dw.Modify("t_diffmoney.text = '" + m_objViewer.m_dblDiffMoney.ToString("F4") + "'");
                    m_objViewer.dw.Refresh();
                }
                p_dtbResult.Rows.Add(drAdd);
                p_dtbResult.AcceptChanges();
            }
        }

        public void m_mthFillMedType()
        {
            this.m_objViewer.txtTypecode.m_listView.Items.Clear();           
            DataTable dtValue = dtvMedType.ToTable();
            DataRow drTmp = dtValue.NewRow();
            drTmp["medicinetypeid_chr"] = "-1";
            drTmp["medicinetypename_vchr"] = "全部";
            dtValue.BeginLoadData();
            dtValue.Rows.Add(drTmp);
            dtValue.EndLoadData();

            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtValue;
            this.m_objViewer.txtTypecode.m_mthFillData();
        }

        internal long m_lngGetStoreNameByID(string p_strId, out string p_strName)
        {
            return m_objDomain.m_lngGetStoreNameByID(p_strId, out p_strName);
        }

        internal long m_lngGetDeptIDByDrugID(string m_strDrugID, out string m_strDeptID)
        {
            return m_objDomain.m_lngGetDeptIDByDrugID(m_strDrugID, out m_strDeptID);
        }
    }
}
