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
    /// <summary>
    /// 
    /// </summary>
    public class clsCtl_RptAdjustpricefullloss : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RptAdjustpricefullloss m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmRptAdjustpricefullloss m_objViewer = null;
        /// <summary>
        /// 药品类别id
        /// </summary>
        private string m_strTypeid;
        /// <summary>
        /// 获取数据表
        /// </summary>
        private DataTable m_dtResult;
        /// <summary>
        /// 药库名称id
        /// </summary>
        private string m_strStorageid;
        /// <summary>
        /// 药库名
        /// </summary>
        private string m_strStorageName;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string strHospitalName;
        /// <summary>
        /// 绑定数据表
        /// </summary>
        private DataTable m_objTable;
        /// <summary>
        /// 药品名称
        /// </summary>
        private DataTable dt;
        /// <summary>
        /// 药品id
        /// </summary>
        private string Medid;
        private string strMedName;
        private string strTypeName;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_RptAdjustpricefullloss()
        {
            m_objDomain = new clsDcl_RptAdjustpricefullloss();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRptAdjustpricefullloss)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药库名称
        /// <summary>
        /// 获取药库名称
        /// </summary>
        /// <param name="m_dtStorageName"></param>
        internal void m_mthGetStorageName(out DataTable m_dtStorageName)
        {
            long lngRes = m_objDomain.m_mthGetStorageName(out m_dtStorageName);
        }
        #endregion

        #region 药品类型
        /// <summary>
        /// 药品类型
        /// </summary>
        /// <param name="m_objTable"></param>
        internal void m_mthGetMedicineType(out DataTable m_objTable)
        {
            long lngRes = m_objDomain.m_mthGetMedicineType(out m_objTable);
        }
        #endregion

        #region 初始化报表
        /// <summary>
        /// 初始化报表
        /// </summary>
        internal void m_mthGetInitdw()
        {
            strHospitalName = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle();
            this.m_objViewer.dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_ms.pbl";
            this.m_objViewer.dw.DataWindowObject = "ms_rptadjustpricefullloss";
            //this.m_objViewer.dw.DataWindowObject = "ms_rptadjustpricefulls";
            this.m_objViewer.dw.Modify("texttitlename.text='" + strHospitalName + "'");
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        internal void m_mthSelectAdjustprice()
        {
            long lngRes = -1;
            strMedName = m_objViewer.m_txtMedicineCode.Text.ToString().Trim();
            m_strStorageName = this.m_objViewer.m_cboStorageName.SelectItemText;
            m_strStorageid = this.m_objViewer.m_cboStorageName.SelectItemValue.ToString();
            m_strTypeid = m_objViewer.m_cboMedicineType.SelectItemValue.ToString();
            strTypeName = m_objViewer.m_cboMedicineType.Text;
            DateTime p_dtBegin, p_dtEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpBeginDat.Text, out p_dtBegin))
            {
                MessageBox.Show("请输入查询开始时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpEndDat.Text, out p_dtEnd))
            {
                MessageBox.Show("请输入查询结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool blnExist = false;
            if (this.m_objViewer.m_txtMedicineCode.Tag != null && m_objViewer.m_txtMedicineCode.Text != "")
            {
                int iRowCount = dt.Rows.Count;
                DataRow dr = null;
                for (int i = 0; i < iRowCount; i++)
                {
                    dr = dt.Rows[i];
                    if (dr["medicinename_vchr"].ToString().Trim().Equals(strMedName))
                    {
                        Medid = Convert.ToString(this.m_objViewer.m_txtMedicineCode.Tag);
                        blnExist = true;
                        break;
                    }
                }
                if (!blnExist)
                {
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    string t_loginname = m_objViewer.LoginInfo.m_strEmpName.ToString();
                    this.m_objViewer.dw.Modify("t_typename.text='" + strTypeName + "'");
                    this.m_objViewer.dw.Modify("t_loginname.text='" + t_loginname + "'");
                    this.m_objViewer.dw.Modify("t_storage.text='" + m_strStorageName + "'");
                    this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    MessageBox.Show("没有找到记录,请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    m_objViewer.m_dgvAdjustFullloss.DataSource = null;
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
            }
            else
            {
                strMedName = "全部";
                //strTypeName = "全部";
                Medid = null;
            }
            


            lngRes = m_objDomain.m_mthSelectAdjustprice(p_dtBegin, p_dtEnd, m_strStorageid, m_strTypeid, Medid, out m_dtResult);
            DataView dvResult = m_dtResult.DefaultView;
            dvResult.RowFilter = "Isnull(currentgross_int,0) <> 0";
            m_dtResult = dvResult.ToTable();
            if (m_dtResult.Rows.Count == 0)
            {
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.Refresh();
                this.m_objViewer.dw.InsertRow(0);
                string t_loginname = m_objViewer.LoginInfo.m_strEmpName.ToString();
                this.m_objViewer.dw.Modify("t_typename.text='" + strTypeName + "'");
                this.m_objViewer.dw.Modify("t_loginname.text='" + t_loginname + "'");
                this.m_objViewer.dw.Modify("t_storage.text='" + m_strStorageName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                MessageBox.Show("没有找到记录,请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                m_objViewer.m_dgvAdjustFullloss.DataSource = null;
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }
            m_objTable = new DataTable();
            m_mthGetAdjustpriceInfo(ref m_dtResult, out m_objTable);
            if (m_strStorageid == "0000")
            {
                m_strStorageName = m_strStorageName + "库存单位";
            }

            if (lngRes > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("medicineid_chr", typeof(String));
                dt.Columns.Add("storagename", typeof(String));
                dt.Columns.Add("medicinename_vch", typeof(String));
                dt.Columns.Add("medspec_vchr", typeof(String));
                dt.Columns.Add("opunit_vchr", typeof(String));
                dt.Columns.Add("productorid_chr", typeof(String));
                dt.Columns.Add("currentgross_int", typeof(Double));
                dt.Columns.Add("oldprice", typeof(Double));
                dt.Columns.Add("newprice", typeof(Double));
                dt.Columns.Add("pricefullloss", typeof(Double));
                dt.Columns.Add("examdate_dat", typeof(DateTime));
                dt.Columns.Add("reason_vchr", typeof(String));
                dt.Columns.Add("assistcode_chr", typeof(string));

                DataView dv = new DataView(m_objTable);
                dv.Sort = "examdate_dat,storagename asc";
                int iRowCount = m_objTable.Rows.Count;
                DataRow dr = null;
                DataRow dr2 = null;
                double opoldretailprice_int = 0d;
                double opnewretailprice_int = 0d;
                double packqty_dec = 0d;
                double ipcurrentgross_int = 0d;
                double dblopoldprice = 0d;
                double dblopnewprice = 0d;

                double grossTemp = 0d;
                double oldprice = 0d;
                double newprice = 0d;
                dr = dt.NewRow();
                for (int i = 0; i < iRowCount; i++)
                {
                    dr2 = m_objTable.Rows[i];

                    double.TryParse(Convert.ToString(dr2["opoldretailprice_int"]), out opoldretailprice_int);
                    double.TryParse(Convert.ToString(dr2["opnewretailprice_int"]), out opnewretailprice_int);
                    double.TryParse(Convert.ToString(dr2["packqty_dec"]), out packqty_dec);
                    double.TryParse(Convert.ToString(dr2["ipcurrentgross_int"]), out ipcurrentgross_int);
                    double.TryParse(Convert.ToString(dr2["currentgross_int"]), out grossTemp);
                    double.TryParse(Convert.ToString(dr2["oldprice"]), out oldprice);
                    double.TryParse(Convert.ToString(dr2["newprice"]), out newprice);

                    if (!(Convert.ToInt32(packqty_dec) == 0))
                    {
                        if (Convert.ToInt32(dr2["usebyds"]) == 1)
                        {
                            dblopoldprice = Convert.ToDouble(Math.Round((opoldretailprice_int / packqty_dec) * ipcurrentgross_int,4));
                            dblopnewprice = Convert.ToDouble(Math.Round((opnewretailprice_int / packqty_dec) * ipcurrentgross_int,4));
                        }
                        else
                        {
                            dblopoldprice = opoldretailprice_int * grossTemp;
                            dblopnewprice = opnewretailprice_int * grossTemp;
                        }
                    }                    

                    dr["medicineid_chr"] = dr2["medicineid_chr"];
                    dr["storagename"] = dr2["storagename"];
                    dr["medicinename_vch"] = dr2["medicinename_vch"];
                    dr["medspec_vchr"] = dr2["medspec_vchr"];
                    dr["opunit_vchr"] = dr2["opunit_vchr"];
                    dr["productorid_chr"] = dr2["productorid_chr"];
                    dr["currentgross_int"] = grossTemp;
                    dr["oldprice"] = oldprice;
                    dr["newprice"] = newprice;

                    if (Convert.ToInt32(dr2["usebyds"]) == 1)
                    {
                        dr["pricefullloss"] = dblopnewprice - dblopoldprice;
                    }
                    else
                    {
                        dr["pricefullloss"] = Math.Round((newprice - oldprice) * grossTemp,4);
                    }
                    
                    dr["examdate_dat"] = Convert.ToDateTime(dr2["examdate_dat"].ToString());
                    dr["reason_vchr"] = dr2["reason_vchr"];
                    dr["assistcode_chr"] = dr2["assistcode_chr"];
                    dt.Rows.Add(dr.ItemArray);
                }
                dt.AcceptChanges();
                m_objViewer.m_dgvAdjustFullloss.DataSource = dt;

                m_mthGetInitdw();
                string t_loginname = m_objViewer.LoginInfo.m_strEmpName.ToString();
                this.m_objViewer.dw.SetRedrawOff();
                this.m_objViewer.dw.Modify("t_typename.text='" + strTypeName + "'");
                this.m_objViewer.dw.Modify("t_loginname.text='" + t_loginname + "'");
                this.m_objViewer.dw.Modify("t_storage.text='" + m_strStorageName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Retrieve(dt);
                //this.m_objViewer.dw.Retrieve(m_objTable);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();

                if (!dt.Columns.Contains("SortRowNo"))
                {
                    dt.Columns.Add("SortRowNo", typeof(long));
                }
                m_mthAddTotalSumRow(dt);
            }
            if (m_dtResult.Rows.Count == 0)
            {
                m_objViewer.m_dgvAdjustFullloss.DataSource = null;
                //MessageBox.Show("没有找到记录,请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "medicinename_vch")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "pricefullloss")
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

        private void m_mthGetAdjustpriceInfo(ref DataTable m_dtResult, out DataTable m_objTable)
        {
            m_objTable = new DataTable();

            DataTable m_objTemp = new DataTable();
            if (m_dtResult.Rows.Count > 0)
            {
                m_objTable = m_dtResult.Clone();
                m_objTemp = m_dtResult.Clone();
            }
            DataRow[] drArr = m_dtResult.Select("", "examdate_dat,storagename,medicineid_chr asc");
            int intRowLength = drArr.Length;
            m_objTemp.BeginLoadData();
            for (int i = 0; i < intRowLength; i++)
            {
                m_objTemp.LoadDataRow(drArr[i].ItemArray, true);
            }
            m_objTemp.EndLoadData();
            m_objTemp.AcceptChanges();

            DataRow dr1 = null;
            DataRow dr2 = null;
            double dbSum;
            int iRowCount = m_objTemp.Rows.Count;
            double dblTemp2 = 0d;
            for (int i1 = 0; i1 < iRowCount; i1++)
            {
                dbSum = 0d;
                DataRow drRow = m_objTable.NewRow();
                dr1 = m_objTemp.Rows[i1];
                if (m_blnExist(dr1["examdate_dat"], dr1["storagename"], dr1["medicineid_chr"], ref m_objTable))
                {
                    continue;
                }

                double.TryParse(Convert.ToString(dr1["currentgross_int"]), out dbSum);
                for (int j2 = i1+1; j2 < iRowCount; j2++)
                {
                    dr2 = m_objTemp.Rows[j2];
                    if (dr1["examdate_dat"].ToString().Trim().Equals(dr2["examdate_dat"].ToString().Trim()))
                    {
                        if (dr1["storagename"].ToString().Trim().Equals(dr2["storagename"].ToString().Trim()))
                        {
                            if (dr1["medicineid_chr"].ToString().Trim().Equals(dr2["medicineid_chr"].ToString().Trim()))
                            {
                                double.TryParse(Convert.ToString(dr2["currentgross_int"]), out dblTemp2);
                                dbSum += dblTemp2;
                                dr1["currentgross_int"] = dbSum;
                            }
                        }
                    }
                }

                drRow["medicineid_chr"] = dr1["medicineid_chr"];
                drRow["storagename"] = dr1["storagename"];
                drRow["medicinename_vch"] = dr1["medicinename_vch"];
                drRow["medspec_vchr"] = dr1["medspec_vchr"];
                drRow["opunit_vchr"] = dr1["opunit_vchr"];
                drRow["productorid_chr"] = dr1["productorid_chr"];
                drRow["opoldretailprice_int"] = dr1["opoldretailprice_int"];
                drRow["opnewretailprice_int"] = dr1["opnewretailprice_int"];
                drRow["packqty_dec"] = dr1["packqty_dec"];
                drRow["ipcurrentgross_int"] = dr1["ipcurrentgross_int"];
                drRow["currentgross_int"] = dr1["currentgross_int"];
                drRow["oldprice"] = dr1["oldprice"];
                drRow["newprice"] = dr1["newprice"];
                drRow["examdate_dat"] = dr1["examdate_dat"];
                drRow["reason_vchr"] = dr1["reason_vchr"];
                drRow["usebyds"] = dr1["usebyds"];
                drRow["assistcode_chr"] = dr1["assistcode_chr"];
                m_objTable.Rows.Add(drRow);
            }

            m_objTable.AcceptChanges();
        }

        private bool m_blnExist(object p_dat, object p_sname, object p_medicineid, ref DataTable m_objTable)
        {
            bool blnExist = false;
            //DataRow[] drArr = m_objTable.Select("examdate_dat=p_dat and storagename=p_sname and medicineid_chr=p_medicineid","");
            //if (drArr.Length > 0)
            //{
            //    blnExist = true;
            //}
            int intRowCount = m_objTable.Rows.Count;
            for (int i = 0; i < intRowCount; i++)
            {
                DataRow dr = m_objTable.Rows[i];
                if (p_dat.ToString().Trim().Equals(dr["examdate_dat"].ToString().Trim()) && p_sname.ToString().Trim().Equals(dr["storagename"].ToString().Trim()) && p_medicineid.ToString().Trim().Equals(dr["medicineid_chr"].ToString().Trim()))
                {
                    blnExist = true;
                    break;
                }
            }
            return blnExist;
        }
        #endregion

        #region 获取数据 不用
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="dtResult"></param>
        //private void m_mthGetAdjustpriceInfo(out DataTable dtResult)
        //{
        //    dtResult = new DataTable();
        //    dtResult.Columns.Add("storagename", typeof(String));
        //    dtResult.Columns.Add("medicinename_vch", typeof(String));
        //    dtResult.Columns.Add("medspec_vchr", typeof(String));
        //    dtResult.Columns.Add("opunit_vchr", typeof(String));
        //    dtResult.Columns.Add("productorid_chr", typeof(String));
        //    dtResult.Columns.Add("currentgross_int", typeof(Double));
        //    dtResult.Columns.Add("oldprice", typeof(Double));
        //    dtResult.Columns.Add("newprice", typeof(Double));
        //    dtResult.Columns.Add("lastprice", typeof(Double));
        //    dtResult.Columns.Add("examdate_dat", typeof(DateTime));
        //    dtResult.Columns.Add("reason_vchr", typeof(String));
        //    clsRptAdjustpricefullloss_VO m_objvo = new clsRptAdjustpricefullloss_VO();
        //    DataRow dr = null;
        //    DataView dv = new DataView(m_dtResult);
        //    dv.Sort="examdate_dat,storagename asc";
        //    for (int i = 0; i < m_dtResult.Rows.Count; i++)
        //    {
        //        if (m_dtResult.Rows[i]["oldprice"].ToString() != "")
        //        {
        //            m_objvo.oldprice = Convert.ToDouble(m_dtResult.Rows[i]["oldprice"].ToString());
        //        }
        //        if (m_dtResult.Rows[i]["newprice"].ToString() != "")
        //        {
        //            m_objvo.newprice = Convert.ToDouble(m_dtResult.Rows[i]["newprice"].ToString());
        //        }
        //        if (m_dtResult.Rows[i]["currentgross_int"].ToString() != "")
        //        {
        //            m_objvo.currentgross = Convert.ToDouble(m_dtResult.Rows[i]["currentgross_int"].ToString());
        //        }
        //        dr = dtResult.NewRow();
        //        dr["storagename"] = m_dtResult.Rows[i]["storagename"].ToString();
        //        dr["medicinename_vch"] = m_dtResult.Rows[i]["medicinename_vch"].ToString();
        //        dr["medspec_vchr"] = m_dtResult.Rows[i]["medspec_vchr"].ToString();
        //        dr["opunit_vchr"] = m_dtResult.Rows[i]["opunit_vchr"].ToString();
        //        dr["productorid_chr"] = m_dtResult.Rows[i]["productorid_chr"].ToString();
        //        dr["currentgross_int"] = m_objvo.currentgross;
        //        dr["oldprice"] = m_objvo.oldprice;
        //        dr["newprice"] = m_objvo.newprice;
        //        dr["lastprice"] = m_objvo.lastprice.ToString();
        //        dr["examdate_dat"] = Convert.ToDateTime(m_dtResult.Rows[i]["examdate_dat"].ToString());
        //        dr["reason_vchr"] = m_dtResult.Rows[i]["reason_vchr"].ToString();
        //        dtResult.Rows.Add(dr);
        //    }
        //    dtResult.AcceptChanges();
        //}
        #endregion

        #region 导出
        /// <summary>
        /// 导出
        /// </summary>
        internal void m_mthExploreData()
        {
            //if (this.m_objViewer.dw.RowCount > 0)
            //{
            //    SaveFileDialog FD = new SaveFileDialog();
            //    FD.Filter = "Excel 文档|*.xls";
            //    FD.Title = "导出";
            //    FD.ShowDialog();

            //    if (FD.FileName.Trim() != "")
            //    {
            //        this.m_objViewer.dw.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
            //    }
            //}
            if (m_objViewer.m_dgvAdjustFullloss.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(m_objViewer.m_dgvAdjustFullloss);
            }
        }
        #endregion

        #region 打印
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
        #endregion

        internal void m_mthGetMedicine()
        {
            dt = new DataTable();
            long lngRes = m_objDomain.m_lngGetBaseMedicine("", out dt);
        }

        internal void m_mthShowMedince(string strMedid)
        {
            if (m_ctlMedQuery == null && dt.Rows.Count > 0)
            {
                this.m_objViewer.m_dtMedince = dt;
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(dt);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_txtMedicineCode.Location.X;
                int Y = this.m_objViewer.m_txtMedicineCode.Location.Y + this.m_objViewer.m_txtMedicineCode.Size.Height + 45;
                m_ctlMedQuery.Location = new Point(X, Y);

                m_ctlMedQuery.ReturnInfo += new ReturnMedicineInfo(m_ctlRetureInfo);
                m_ctlMedQuery.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlMedQuery.RefreshMedicine += new RefreshMedicineInfo(m_ctlMedQuery_RefreshMedicine);
            }
            m_ctlMedQuery.Visible = true;
            m_ctlMedQuery.BringToFront();
            m_ctlMedQuery.Focus();
            m_ctlMedQuery.m_mthSetSearchText(strMedid);
        }

        private void m_ctlMedQuery_RefreshMedicine()
        {
            m_mthGetMedicine();
            m_ctlMedQuery.m_dtbMedicineInfo = dt;
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            this.m_objViewer.m_txtMedicineCode.Focus();
            m_ctlMedQuery.Visible = false;
            //this.m_objViewer.m_cmdSearch.Focus();
        }

        internal void m_ctlRetureInfo(clsMS_MedicintLeastElement_VO objVO)
        {
            this.m_objViewer.m_txtMedicineCode.Text = objVO.m_strMedicineName;
            this.m_objViewer.m_txtMedicineCode.Tag = objVO.m_strMedicineID;
            ///this.m_objViewer.m_cmdSearch.Focus();
        }
    }
}
