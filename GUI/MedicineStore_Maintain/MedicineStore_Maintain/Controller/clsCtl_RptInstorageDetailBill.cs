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
    public class clsCtl_RptInstorageDetailBill : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RptInstorageDetailBill m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmRptInstorageDetaiBilll m_objViewer = null;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 入库类别id
        /// </summary>
        private string m_strTypeid;
        /// <summary>
        /// 供货商ID
        /// </summary>
        private string m_strVendorid;
        /// <summary>
        /// 供货商缓存表
        /// </summary>
        private DataTable m_dtVendor;
        /// <summary>
        /// 单据数据表
        /// </summary>
        private DataTable m_dtResult;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string strHospitalName;
        /// <summary>
        /// 药库名
        /// </summary>
        private string m_strStorageName;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_RptInstorageDetailBill()
        {
            m_objDomain = new clsDcl_RptInstorageDetailBill();
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
            m_objViewer = (frmRptInstorageDetaiBilll)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取入库类别名
        /// <summary>
        /// 获取入库类别名
        /// </summary>
        internal void m_mthGetInstorageName(out DataTable m_objTable)
        {
            long lngRes = this.m_objDomain.m_mthGetInstorageName(out m_objTable);
        }
        #endregion

        #region 初始化报表
        /// <summary>
        /// 初始化报表
        /// </summary>
        internal void m_mthInitdw(int intDsOrMs)
        {
            strHospitalName = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle();
            string strName =strHospitalName+ "药品入库凭证";
            this.m_objViewer.dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_ms.pbl";
            if (intDsOrMs == 0)
            {
                this.m_objViewer.dw.DataWindowObject = "ms_rptmedinstoragedetailbill";
            }
            else
            {
                this.m_objViewer.dw.DataWindowObject = "ms_rptinstoragedetailbill";
            }
            this.m_objViewer.dw.Modify("texttitlename.text='" + strName + "'");
        }
        #endregion

        #region 供货商表
        /// <summary>
        /// 供货商表
        /// </summary>
        internal void m_mthGetVendorTable(int intDsOrMs)
        {
            long lngRes = this.m_objDomain.m_mthGetVendorName(intDsOrMs, out m_dtVendor);
        }
        #endregion

        #region 供货商
        /// <summary>
        /// 供货商
        /// </summary>
        /// <param name="p_strSearchCon">条件</param>
        internal void m_mthGetVendorName(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_ctlQueryVendor = new ctlQueryVendor(m_dtVendor);
                this.m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = this.m_objViewer.panel1.Location.X + this.m_objViewer.m_txtVendor.Location.X;
                int Y = this.m_objViewer.panel1.Location.Y + this.m_objViewer.m_txtVendor.Location.Y + this.m_objViewer.m_txtVendor.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(m_ctlQueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void m_ctlQueryVendor_ReturnInfo(clsMS_Vendor MS_VO)
        {
            this.m_objViewer.m_txtVendor.Tag = null;
            if (MS_VO == null)
            {
                return;
            }
            this.m_objViewer.m_txtVendor.Tag = MS_VO.m_strVendorID;
            this.m_objViewer.m_txtVendor.Text = MS_VO.m_strVendorName;

            //this.m_objViewer.m_cmdQuery.Focus();
        }
        #endregion

        #region 绑定明细数据
        /// <summary>
        /// 绑定明细数据
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        public void m_mthSelectInstorageDetailBill(int intDsOrMs)
        {
            long lngRes = -1;
            string m_strStorageid = m_objViewer.m_cboStorageName.SelectItemValue.ToString();
            m_strTypeid = this.m_objViewer.m_cboInStorageType.SelectItemValue.ToString();
            //DateTime p_dtBegin = this.m_objViewer.m_dtpBeginDat.Value;
            //DateTime p_dtEnd = this.m_objViewer.m_dtpEndDat.Value;
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
            if (this.m_objViewer.m_txtVendor.Text == null || this.m_objViewer.m_txtVendor.Text.ToString().Trim() == "")
            {
                m_strVendorid = "0000";
            }
            else
            {
                bool m_blnExist = false;
                string m_strVendoridExist = "";
                string m_strVendor = this.m_objViewer.m_txtVendor.Text.ToString().Trim();
                for (int iExist = 0; iExist < m_dtVendor.Rows.Count; iExist++)
                {
                    if (m_dtVendor.Rows[iExist]["name"].ToString().Trim().Equals(m_strVendor))
                    {
                        m_blnExist = true;
                        m_strVendoridExist = this.m_objViewer.m_txtVendor.Tag.ToString();
                        break;
                    }
                }
                if (m_blnExist)
                {
                    m_strVendorid = m_strVendoridExist;
                }
                else
                {
                    MessageBox.Show("对不起！没有找到供货商：" + m_objViewer.m_txtVendor.Text.ToString() + "！请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }
            }

            lngRes = this.m_objDomain.m_lngGetInstorageDetailBillInfo(intDsOrMs, p_dtBegin, p_dtEnd, m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
            if (lngRes > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("medicinename_vchr", typeof(String));
                dt.Columns.Add("medspec_vchr", typeof(String));
                dt.Columns.Add("ipunit_chr", typeof(String));
                dt.Columns.Add("productorid_chr", typeof(String));
                dt.Columns.Add("ipamount_int", typeof(Double));
                dt.Columns.Add("ipretailprice_int", typeof(Double));
                dt.Columns.Add("allprice", typeof(Double));
                dt.Columns.Add("lotno_vchr", typeof(String));

                DataRow dr = null;
                DataRow dr2 = null;
                double dblamount = 0d;
                double dblretailprice = 0d;
                dr = dt.NewRow();
                int iRowCount = m_dtResult.Rows.Count;
                for (int i = 0; i < iRowCount; i++)
                {
                    dr2 = m_dtResult.Rows[i];
                    double.TryParse(Convert.ToString(dr2["ipamount_int"]),out dblamount);
                    double.TryParse(Convert.ToString(dr2["ipretailprice_int"]),out dblretailprice);

                    dr["medicinename_vchr"] = dr2["medicinename_vchr"];
                    dr["medspec_vchr"] = dr2["medspec_vchr"];
                    dr["ipunit_chr"] = dr2["ipunit_chr"];
                    dr["productorid_chr"] = dr2["productorid_chr"];
                    dr["ipamount_int"] = dblamount;
                    dr["ipretailprice_int"] = dblretailprice;
                    dr["allprice"] = dblamount * dblretailprice;
                    dr["lotno_vchr"] = dr2["lotno_vchr"];

                    dt.Rows.Add(dr.ItemArray);
                }
                dt.AcceptChanges();
                dr = null;
                dr2 = null;
                this.m_objViewer.m_dgvInstorageDetail.DataSource = dt;

                m_strStorageName = this.m_objViewer.m_cboStorageName.SelectItemText.ToString().Trim();
                
                string m_strVendorName = this.m_objViewer.m_txtVendor.Text.ToString().Trim();
                if (this.m_objViewer.m_txtVendor.Text.ToString().Trim() == "")
                {
                    m_strVendorName = "全部";
                }
                string m_strLoginName = this.m_objViewer.LoginInfo.m_strEmpName.ToString().Trim();
                m_mthInitdw(intDsOrMs);
                this.m_objViewer.dw.SetRedrawOff();
                this.m_objViewer.dw.Modify("t_loginname.text='" + m_strLoginName + "'");
                this.m_objViewer.dw.Modify("textinstoragetype.text='" + this.m_objViewer.m_cboInStorageType.SelectItemText.ToString() + "'");
                this.m_objViewer.dw.Modify("textvendorname.text='" + m_strVendorName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd") + "'");
                this.m_objViewer.dw.Modify("t_storage.text='" + m_strStorageName + "'");
                this.m_objViewer.dw.Retrieve(m_dtResult);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();
            }
            if (m_dtResult.Rows.Count == 0)
            {
                MessageBox.Show("没有找到记录,请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
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
            if (this.m_objViewer.m_dgvInstorageDetail.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(this.m_objViewer.m_dgvInstorageDetail);
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        internal void m_mthPrint()
        {
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public clsPub = new com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public();
            clsPub.ChoosePrintDialog(this.m_objViewer.dw, true);
        }
        #endregion

        #region 库房名称
        /// <summary>
        /// 库房名称
        /// </summary>
        /// <param name="m_dtStorageName"></param>
        internal void m_mthGetStorageName(int intDsOrMs, out DataTable m_dtStorageName)
        {
            long lngRes = this.m_objDomain.m_mthGetStorageName(intDsOrMs, out m_dtStorageName);
        }
        #endregion
    }
}
