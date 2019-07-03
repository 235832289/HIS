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
    /// 药品调价情况一览表
    /// </summary>
    public class clsCtl_RptAdjustpriceDetail : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RptAdjustpriceDetail m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmRptAdjustpriceDetail m_objViewer = null;
        /// <summary>
        /// 绑定数据表
        /// </summary>
        private DataTable m_dtTable;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string strHospitalName;
        /// <summary>
        /// 药品ID
        /// </summary>
        private string m_strMedicineid;
        /// <summary>
        /// 药房或药库
        /// </summary>
        private string m_strDsOrMsName;
        private DataTable dt;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_RptAdjustpriceDetail()
        {
            m_objDomain = new clsDcl_RptAdjustpriceDetail();
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
            m_objViewer = (frmRptAdjustpriceDetail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 药品类型
        /// <summary>
        /// 药品类型
        /// </summary>
        /// <param name="m_dtResult"></param>
        public void m_mthGetMedicineType(out DataTable m_dtResult)
        {
            long lngRes = this.m_objDomain.m_mthGetMedicineType(out m_dtResult);
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
            this.m_objViewer.dw.DataWindowObject = "ms_rptadjustpricedetail";
            this.m_objViewer.dw.Modify("texttitlename.text='" + strHospitalName + "'");
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        internal void m_mthSelectAdjustData(int intDsOrMs)
        {
            long lngRes = -1;
            string m_strMedicineType = this.m_objViewer.m_cboMedicineType.SelectItemValue;
            //string m_strMedicineName = this.m_objViewer.m_txtMedicineName.Text.Trim();
            //string strMedNameid = "";
            if(m_objViewer.m_txtMedicineName.Text.Trim().Length == 0)
            {
                m_strMedicineid = "";
            }
            else
            {
                m_strMedicineid = Convert.ToString(m_objViewer.m_txtMedicineName.Tag);// this.m_objViewer.m_cboMedicineType.SelectItemValue.ToString();
            } 
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
            lngRes = this.m_objDomain.m_mthSelectAdjustData(intDsOrMs,m_objViewer.m_intMakeFilm, p_dtBegin, p_dtEnd, m_strMedicineType, m_strMedicineid, out m_dtTable);
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvMedicine.DataSource = m_dtTable;

                if (m_dtTable.Rows.Count == 0 || m_dtTable == null)
                {
                    this.m_objViewer.dw.Reset();
                    this.m_objViewer.dw.Refresh();
                    this.m_objViewer.dw.InsertRow(0);
                    this.m_objViewer.dw.Modify("t_medicinename.text='" + this.m_objViewer.m_cboMedicineType.SelectItemText + "'");
                    this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                    MessageBox.Show(this.m_objViewer, "没有符合条件数据，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.Cursor = Cursors.Default;
                    return;
                }

                m_mthInitdw();
                this.m_objViewer.dw.SetRedrawOff();
                //if (intDsOrMs == 0)
                //{
                //    m_strDsOrMsName = "药房";
                //}
                //else 
                //{
                //    m_strDsOrMsName = "药库";
                //}
                //this.m_objViewer.dw.Modify("t_dsorms.text='" + m_strDsOrMsName + "'");
                this.m_objViewer.dw.Modify("t_medicinename.text='" + this.m_objViewer.m_cboMedicineType.SelectItemText + "'");
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
            //SaveFileDialog FD = new SaveFileDialog();
            //FD.Filter = "Excel 文档|*.xls";
            //FD.Title = "导出";
            //FD.ShowDialog();

            //if (FD.FileName.Trim() != "")
            //{
            //    this.m_objViewer.dw.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
            //}
            if (m_objViewer.m_dgvMedicine.Rows.Count > 0)
            {
                com.digitalwave.iCare.gui.HIS.clsPub.m_mthExportToExcel(m_objViewer.m_dgvMedicine);
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

        #region 药品名称
        internal void m_mthGetMidicine()
        {
            string p_strMedName = string.Empty;
            long lng = m_objDomain.m_mthShowMedName(p_strMedName, out dt);
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

                int X = this.m_objViewer.m_txtMedicineName.Location.X - 600;
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
    }
}
