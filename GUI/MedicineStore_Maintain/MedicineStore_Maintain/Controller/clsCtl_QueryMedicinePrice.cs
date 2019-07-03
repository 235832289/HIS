using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using System.IO;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品价格查询
    /// </summary>
    public class clsCtl_QueryMedicinePrice : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_QueryMedicinePrice m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmQueryMedicinePrice m_objViewer = null;
        /// <summary>
        /// 绑定数据表
        /// </summary>
        private DataTable m_dtTable;
        /// <summary>
        /// 获取数据
        /// </summary>
        private DataTable m_dtResult;
        private DataTable dt;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string strHospitalName;
        private string m_strMedicineName;
        private DateTime p_dtBegin;
        private DateTime p_dtEnd;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_QueryMedicinePrice()
        {
            m_objDomain = new clsDcl_QueryMedicinePrice();
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
            m_objViewer = (frmQueryMedicinePrice)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化报表
        /// <summary>
        /// 初始化报表
        /// </summary>
        internal void m_mthInitdw()
        {
            strHospitalName = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle();
            this.m_objViewer.dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_ms.pbl";
            this.m_objViewer.dw.DataWindowObject = "ms_querymedicineprice";
            this.m_objViewer.dw.Modify("texttitlename.text='" + strHospitalName + "'");
        }
        #endregion

        #region 药品名称
        /// <summary>
        /// 药品名称
        /// </summary>
        /// <param name="p_strMedName"></param>
        internal void m_mthShowMedName(string p_strMedName)
        {
            //dt = new DataTable();
            //long lng = m_objDomain.m_mthShowMedName(p_strMedName, out dt);
            if (m_ctlMedQuery == null)
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    m_mthGetMidicine();
                }
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(dt);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_txtMedicineName.Location.X-300;
                int Y = this.m_objViewer.m_txtMedicineName.Location.Y + this.m_objViewer.m_txtMedicineName.Size.Height + 46;
                m_ctlMedQuery.Location = new Point(X, Y);

                m_ctlMedQuery.ReturnInfo += new ReturnMedicineInfo(m_ctlRetureInfo);
                m_ctlMedQuery.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlMedQuery.RefreshMedicine += new RefreshMedicineInfo(m_ctlMedQuery_RefreshMedicine);
            }
            m_ctlMedQuery.Visible = true;
            m_ctlMedQuery.BringToFront();
            m_ctlMedQuery.Focus();
            m_ctlMedQuery.m_mthSetSearchText(p_strMedName);
        }

        private void m_ctlMedQuery_RefreshMedicine()
        {
            m_mthGetMidicine();
            m_ctlMedQuery.m_dtbMedicineInfo = dt;
        }
        #endregion

        #region 名称控件方法
        internal void m_ctlQueryMedicint_CancelResult()
        {
            this.m_objViewer.m_txtMedicineName.Focus();
            m_ctlMedQuery.Visible = false;
        }

        internal void m_ctlRetureInfo(clsMS_MedicintLeastElement_VO objVO)
        {
            this.m_objViewer.m_txtMedicineName.Text = objVO.m_strMedicineName;
            this.m_objViewer.m_txtMedicineName.Tag = objVO.m_strMedicineID;
        }
        #endregion

        #region 绑定数据
        internal void m_mthQuery()
        {
            m_strMedicineName = this.m_objViewer.m_txtMedicineName.Text.Trim();
            DateTime p_dtBegin = Convert.ToDateTime(this.m_objViewer.m_dtpBeginDat.Text);
            DateTime p_dtEnd = Convert.ToDateTime(this.m_objViewer.m_dtpEndDat.Text);
            string strMedicineid = "";
            bool blnExist = false;
            if (this.m_objViewer.m_txtMedicineName.Tag != null&&m_objViewer.m_txtMedicineName.Text!="")
            {
                int iRowCount=dt.Rows.Count;
                DataRow dr=null;
                for (int i = 0; i < iRowCount; i++)
                {
                    dr = dt.Rows[i];
                    if (dr["medicinename_vchr"].ToString().Trim().Equals(m_strMedicineName))
                    {
                        strMedicineid = Convert.ToString(this.m_objViewer.m_txtMedicineName.Tag);
                        blnExist = true;
                        break;
                    }
                }
            }
            if (!blnExist)
            {
                m_dtResult = null;
                this.m_objViewer.m_dgvMedPrice.DataSource = m_dtResult;
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.Refresh();
                this.m_objViewer.dw.InsertRow(0);
                this.m_objViewer.dw.Modify("t_medicinename.text='" + m_strMedicineName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                MessageBox.Show(this.m_objViewer, "没有符合条件数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }
            long lngR = 0;
            lngR = m_objDomain.m_mthGetMedicine(p_dtBegin, p_dtEnd, strMedicineid, out m_dtTable);            
            //m_mthSortTable(ref m_dtTable, out m_dtResult);
            if (lngR > 0)
            {               
                this.m_objViewer.m_dgvMedPrice.DataSource = m_dtTable;

                if (m_dtTable == null || m_dtTable.Rows.Count == 0)
                {

                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    this.m_objViewer.dw.Modify("t_medicinename.text='" + m_strMedicineName + "'");
                    this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    MessageBox.Show(this.m_objViewer, "没有符合条件数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }

                if (m_strMedicineName == "")
                {
                    m_strMedicineName = "全部";
                }

                m_mthInitdw();
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.SetRedrawOff();
                this.m_objViewer.dw.Modify("t_medicinename.text='" + m_strMedicineName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Retrieve(m_dtTable);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();
            }
            else
            {
                this.m_objViewer.m_dgvMedPrice.DataSource = m_dtTable;
                this.m_objViewer.dw.Reset();
                this.m_objViewer.dw.Refresh();
                this.m_objViewer.dw.InsertRow(0);
                this.m_objViewer.dw.Modify("t_medicinename.text='" + m_strMedicineName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                MessageBox.Show(this.m_objViewer, "没有符合条件数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }
        }
        #endregion

        #region 筛选数据
        private void m_mthSortTable(ref DataTable m_dtTable, out DataTable m_dtResult)
        {
            DataRow dr = null;
            m_dtResult = new DataTable();
            m_dtResult.Columns.Add("medicinename_vch", typeof(string));
            m_dtResult.Columns.Add("medspec_vchr", typeof(string));
            m_dtResult.Columns.Add("opunit_vchr", typeof(string));
            m_dtResult.Columns.Add("productorid_chr", typeof(string));
            m_dtResult.Columns.Add("newretailprice_int", typeof(double));
            m_dtResult.Columns.Add("packqty_dec", typeof(double));
            m_dtResult.Columns.Add("examdate_dat", typeof(DateTime));
            m_dtResult.Columns.Add("endexamdate_dat", typeof(DateTime));
            m_dtResult.Columns.Add("reason_vchr", typeof(string));
            int intRowCount = m_dtTable.Rows.Count;
            DataRow drTemp = null;
            DataRow drTemp2 = null;
            DateTime dTimeTemp = new DateTime();
            int intIsFirst = 0;
            //com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(
            for (int i = 0; i < intRowCount; i++)
            {
                bool blnExist = false;
                dr = m_dtResult.NewRow();
                drTemp = m_dtTable.Rows[i];

                dr["medicinename_vch"] = drTemp["medicinename_vch"];
                dr["medspec_vchr"] = drTemp["medspec_vchr"];
                dr["opunit_vchr"] = drTemp["opunit_vchr"];
                dr["productorid_chr"] = drTemp["productorid_chr"];
                dr["newretailprice_int"] = drTemp["newretailprice_int"];
                dr["packqty_dec"] = drTemp["packqty_dec"];
                dr["examdate_dat"] = drTemp["examdate_dat"];

                for (int j = i + 1; j < intRowCount; )
                {
                    drTemp2 = m_dtTable.Rows[j];
                    if (drTemp["medicineid_chr"].ToString() == drTemp2["medicineid_chr"].ToString())
                    {
                        blnExist = true;
                    }
                    if (blnExist)
                    {
                        if (intIsFirst != 0) //是否是第一条
                        {
                            dr["endexamdate_dat"] = Convert.ToDateTime(dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            dr["endexamdate_dat"] = DBNull.Value;
                        }
                        intIsFirst = 1;
                        dTimeTemp = Convert.ToDateTime(dr["examdate_dat"].ToString());
                        break;
                    }
                    else
                    {
                        if (intIsFirst != 0) //不是只有一条且是最后一条
                        {
                            dr["endexamdate_dat"] = Convert.ToDateTime(dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else
                        {
                            dr["endexamdate_dat"] = DBNull.Value;
                        }
                        intIsFirst = 0;
                        dTimeTemp = Convert.ToDateTime(dr["examdate_dat"].ToString());
                        break;
                    }
                }

                if (i == intRowCount - 1)
                {
                    if (i == 0)
                    {
                        dr["endexamdate_dat"] = DBNull.Value;
                    }
                    else
                    {
                        dr["endexamdate_dat"] = Convert.ToDateTime(dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                }

                dr["reason_vchr"] = drTemp["reason_vchr"];
                if (blnExist) //是否还有相同id存在
                {
                    m_dtResult.Rows.Add(dr);
                }
                else
                {
                    ///同一id的最后一条记录
                   
                    m_dtResult.Rows.Add(dr.ItemArray);

                    if (intRowCount > 1)
                    {
                        dr["medicinename_vch"] = dr["medicinename_vch"];
                        dr["medspec_vchr"] = dr["medspec_vchr"];
                        dr["opunit_vchr"] = dr["opunit_vchr"];
                        dr["productorid_chr"] = dr["productorid_chr"];
                        dr["newretailprice_int"] = drTemp["oldretailprice_int"];
                        dr["packqty_dec"] = dr["packqty_dec"];
                        dr["examdate_dat"] = dr["examdate_dat"];
                        dr["endexamdate_dat"] = Convert.ToDateTime(dTimeTemp.AddSeconds(-1).ToString("yyyy-MM-dd HH:mm:ss"));
                        dr["reason_vchr"] = dr["reason_vchr"];
                        m_dtResult.Rows.Add(dr.ItemArray);
                    }
                }
            }
            drTemp = null;
            drTemp2 = null;
        }
        #endregion

        #region 打印
        internal void m_mthPrint()
        {
            if (this.m_objViewer.dw.RowCount > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.m_objViewer.dw, true);
            }
        }
        #endregion

        #region 导出
        internal void m_mthExcel()
        {
            //SaveFileDialog FD = new SaveFileDialog();
            //FD.Filter = "Excel 文档|*.xls";
            //FD.Title = "导出";
            //FD.ShowDialog();

            //if (FD.FileName.Trim() != "")
            //{
            //    this.m_objViewer.dw.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
            //}
            if (this.m_objViewer.m_dgvMedPrice.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_objViewer.m_dgvMedPrice);
            }
        }
        #endregion

        #region 获取药品信息
        /// <summary>
        /// 获取药品信息
        /// </summary>
        internal void m_mthGetMidicine()
        {
            string p_strMedName = string.Empty;
            dt = new DataTable();
            long lng = m_objDomain.m_mthShowMedName(p_strMedName, out dt);
        }
        #endregion
    }
}
