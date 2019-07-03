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
    /// 药品调价记录查询
    /// </summary>
    public class clsCtl_RptAdjustpriceRecord : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类        /// </summary>
        private clsDcl_RptAdjustpriceRecord m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmRptAdjustpriceRecord m_objViewer = null;
        /// <summary>
        /// 调价数据表        /// </summary>
        private DataTable m_dtTable;
        /// <summary>
        /// 药库名        /// </summary>
        private string m_strStorageName;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string strHospitalName;
        /// <summary>
        /// 药品名称
        /// </summary>
        private DataTable dt;
        /// <summary>
        /// 药品id
        /// </summary>
        private string Medid;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_RptAdjustpriceRecord()
        {
            m_objDomain = new clsDcl_RptAdjustpriceRecord();
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
            m_objViewer = (frmRptAdjustpriceRecord)frmMDI_Child_Base_in;
        }
        #endregion

        #region 库房名称
        /// <summary>
        /// 库房名称
        /// </summary>
        /// <param name="m_dtResult"></param>
        internal void m_mthGetStorageName(int intDsOrMs, out DataTable m_dtResult)
        {
            long lngRes = this.m_objDomain.m_mthGetStorageName(intDsOrMs, out m_dtResult);
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
            this.m_objViewer.dw.DataWindowObject = "ms_rptadjustpricerecord";
            this.m_objViewer.dw.Modify("texttitlename.text='" + strHospitalName + "'");
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        internal void m_mthSelectAdjustpriceRecord(int intDsOrMs)
        {
            long lngRes = -1;
            string strMedName = this.m_objViewer.m_txtMedicineCode.Text.Trim();
            //m_strStorageName = this.m_objViewer.m_cboStorageName.SelectItemText;
            //string m_strStorageid = this.m_objViewer.m_cboStorageName.SelectItemValue.ToString();

            //DateTime p_dtBegin = Convert.ToDateTime(this.m_objViewer.m_dtpBeginDat.Text);
            //DateTime p_dtEnd = Convert.ToDateTime(this.m_objViewer.m_dtpEndDat.Text);
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
                    m_objViewer.m_dgvAdjustPrice.DataSource = null;
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    MessageBox.Show("没有找到记录,请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }
            }
            else
            {
                strMedName = "全部";
                Medid = null;
            }

            lngRes = this.m_objDomain.m_mthSelectAdjustData(intDsOrMs, p_dtBegin, p_dtEnd, Medid, out m_dtTable);
            //lngRes = this.m_objDomain.m_mthSelectAdjustData(intDsOrMs, p_dtBegin, p_dtEnd, m_strStorageid, out m_dtTable);
            if (lngRes > 0)
            {
                m_objViewer.m_dgvAdjustPrice.DataSource = m_dtTable;

                m_mthInitdw();
                this.m_objViewer.dw.SetRedrawOff();
                //this.m_objViewer.dw.Modify("t_storagename.text='" + m_strStorageName + "'");
                this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                this.m_objViewer.dw.Retrieve(m_dtTable);
                this.m_objViewer.dw.SetRedrawOn();
                this.m_objViewer.dw.Refresh();
            }
            if (m_dtTable.Rows.Count == 0)
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
            if (m_objViewer.m_dgvAdjustPrice.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(m_objViewer.m_dgvAdjustPrice);
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

        internal void m_mthGetMedicine()
        {
            dt = new DataTable();
            long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty, out dt);
        }

        internal void m_mthShowMedince(string strMedid)
        {
            if (m_ctlMedQuery == null)
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    m_mthGetMedicine();
                }
                this.m_objViewer.m_dtMedince = dt;
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(dt);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_txtMedicineCode.Location.X-450;
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
