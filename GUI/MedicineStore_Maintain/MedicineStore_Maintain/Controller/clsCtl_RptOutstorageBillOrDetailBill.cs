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
    /// 出库单据/出库单据明细表
    /// </summary>
    public class clsCtl_RptOutstorageBillOrDetailBill : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RptOutstorageBillOrDetailBill m_objDomain = null;
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        private frmRptOutstorageBillOrDetailBill m_objViewer = null;
        /// <summary>
        /// 查询供货商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 出库类别id
        /// </summary>
        private string m_strTypeid;
        /// <summary>
        /// 供货商ID
        /// </summary>
        private string m_strVendorid;
        /// <summary>
        /// 供货商缓存表
        /// </summary>
        private DataTable m_objVendorTable;
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
        public clsCtl_RptOutstorageBillOrDetailBill()
        {
            m_objDomain = new clsDcl_RptOutstorageBillOrDetailBill();
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
            m_objViewer = (frmRptOutstorageBillOrDetailBill)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化报表
        /// <summary>
        /// 初始化报表
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        /// <param name="m_strBillid">0-出库单据 默认值;1-出库单据明细表</param>
        internal void m_mthGetInitDw(int intDsOrMs, int m_strBillid)
        {
            if (m_strBillid == 1)
            {
                strHospitalName = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle();
                string strName = strHospitalName + "药品出库凭证";
                this.m_objViewer.dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\pb_ms.pbl";
                if (intDsOrMs == 0)
                {
                    this.m_objViewer.dw.DataWindowObject = "ms_rptmedinstoragedetailbill";
                    string m_strOuttypelabel = "出库类别：";
                    this.m_objViewer.dw.Modify("t_4.text='" + m_strOuttypelabel + "'");
                }
                else
                {
                    this.m_objViewer.dw.DataWindowObject = "ms_rptoutstoragedetailbill";
                }
                this.m_objViewer.dw.Modify("texttitlename.text='" + strName + "'");
            }
            else
            {
                strHospitalName = this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle();
                this.m_objViewer.dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\pb_ms.pbl";
                this.m_objViewer.dw.DataWindowObject = "ms_rptoutstoragebill";
                this.m_objViewer.dw.Modify("texttitlename.text='" + strHospitalName + "'");
            }
        }
        #endregion

        #region 供货商缓存表
        /// <summary>
        /// 供货商缓存表
        /// </summary>
        internal void m_mthGetVendorTable(int intDsOrMs)
        {
            long lngRes=this.m_objDomain.m_mthGetVendorTable(intDsOrMs, out m_objVendorTable);
        }
        #endregion

        #region 出库类别
        /// <summary>
        /// 出库类别
        /// </summary>
        /// <param name="m_objTable"></param>
        internal void m_mthGetOutstorageType(out DataTable m_objTable)
        {
            long lngRes=this.m_objDomain.m_mthGetOutstorageType(out m_objTable);
        }
        #endregion

        #region 供货商
        /// <summary>
        /// 供货商
        /// </summary>
        /// <param name="p_strSearchCon"></param>
        internal void m_mthGetVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_ctlQueryVendor = new ctlQueryVendor(m_objVendorTable);
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

        #region 绑定单据数据
        /// <summary>
        /// 绑定单据数据
        /// </summary>
        /// <param name="intDsOrMs">0-药房;1-药库</param>
        /// <param name="m_strBillid">0-出库单据 默认值;1-出库单据明细表</param>
        internal void m_mthSelectOutstorageBill(int intDsOrMs, int m_strBillid)
        {
            if (m_strBillid == 1)
            {
                long lngRes = -1;
                string m_strStorageid = m_objViewer.m_cboStorageName.SelectItemValue.ToString();
                m_strTypeid = this.m_objViewer.m_cboOutStorageType.SelectItemValue.ToString();
                DateTime p_dtBegin = this.m_objViewer.m_dtpBeginDat.Value;
                DateTime p_dtEnd = this.m_objViewer.m_dtpEndDat.Value;
                if (this.m_objViewer.m_txtVendor.Text == null || this.m_objViewer.m_txtVendor.Text.ToString().Trim() == "")
                {
                    m_strVendorid = "0000";
                }
                else
                {
                    bool m_blnExist = false;
                    string m_strVendoridExist = "";
                    string m_strVendor = this.m_objViewer.m_txtVendor.Text.ToString().Trim();
                    for (int iExist = 0; iExist < m_objVendorTable.Rows.Count; iExist++)
                    {
                        if (m_objVendorTable.Rows[iExist]["name"].ToString().Trim().Equals(m_strVendor))
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

                lngRes = this.m_objDomain.m_lngGetOutstorageDetailBillInfo(intDsOrMs, p_dtBegin, p_dtEnd, m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
                if (lngRes > 0)
                {
                    m_strStorageName = this.m_objViewer.m_cboStorageName.SelectItemText.ToString().Trim();
                    string m_strVendorName = this.m_objViewer.m_txtVendor.Text.ToString().Trim();
                    if (this.m_objViewer.m_txtVendor.Text.ToString().Trim() == "")
                    {
                        m_strVendorName = "全部";
                    }
                    m_mthGetInitDw(intDsOrMs, m_strBillid);
                    string m_strLoginName = this.m_objViewer.LoginInfo.m_strEmpName.ToString().Trim();
                    this.m_objViewer.dw.SetRedrawOff();
                    this.m_objViewer.dw.Modify("t_loginname.text='" + m_strLoginName + "'");
                    this.m_objViewer.dw.Modify("t_storage.text='" + m_strStorageName + "'");
                    if (intDsOrMs == 0)
                    {
                        this.m_objViewer.dw.Modify("textinstoragetype.text='" + this.m_objViewer.m_cboOutStorageType.SelectItemText.ToString() + "'");
                    }
                    else
                    {
                        this.m_objViewer.dw.Modify("textoutstoragetype.text='" + this.m_objViewer.m_cboOutStorageType.SelectItemText.ToString() + "'");
                    }
                    this.m_objViewer.dw.Modify("textvendorname.text='" + m_strVendorName + "'");
                    this.m_objViewer.dw.Modify("begindatetext.text='" + p_dtBegin.ToString("yyyy-MM-dd") + "'");
                    this.m_objViewer.dw.Modify("enddatetext.text='" + p_dtEnd.ToString("yyyy-MM-dd") + "'");
                    this.m_objViewer.dw.Retrieve(m_dtResult);
                    this.m_objViewer.dw.SetRedrawOn();
                    this.m_objViewer.dw.Refresh();
                }
                if (m_dtResult.Rows.Count == 0)
                {
                    MessageBox.Show("没有找到记录,请重新输入！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else
            {
                long lngRes = -1;
                string m_strStorageid = m_objViewer.m_cboStorageName.SelectItemValue.ToString();
                m_strTypeid = this.m_objViewer.m_cboOutStorageType.SelectItemValue.ToString();
                DateTime p_dtBegin = this.m_objViewer.m_dtpBeginDat.Value;
                DateTime p_dtEnd = this.m_objViewer.m_dtpEndDat.Value;
                if (this.m_objViewer.m_txtVendor.Text == null || this.m_objViewer.m_txtVendor.Text.ToString().Trim() == "")
                {
                    m_strVendorid = "0000";
                }
                else
                {
                    bool m_blnExist = false;
                    string m_strVendoridExist = "";
                    string m_strVendor = this.m_objViewer.m_txtVendor.Text.ToString().Trim();
                    for (int iExist = 0; iExist < m_objVendorTable.Rows.Count; iExist++)
                    {
                        if (m_objVendorTable.Rows[iExist]["name"].ToString().Trim().Equals(m_strVendor))
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

                lngRes = this.m_objDomain.m_lngGetOutstorageBillInfo(intDsOrMs, p_dtBegin, p_dtEnd, m_strTypeid, m_strVendorid, m_strStorageid, out m_dtResult);
                if (lngRes > 0)
                {
                    m_strStorageName = this.m_objViewer.m_cboStorageName.SelectItemText.ToString().Trim();
                    m_mthGetInitDw(intDsOrMs, m_strBillid);
                    this.m_objViewer.dw.SetRedrawOff();
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
        }
        #endregion

        #region 导出
        /// <summary>
        /// 导出
        /// </summary>
        internal void m_mthExploreData()
        {
            if (this.m_objViewer.dw.RowCount > 0)
            {
                SaveFileDialog FD = new SaveFileDialog();
                FD.Filter = "Excel 文档|*.xls";
                FD.Title = "导出";
                FD.ShowDialog();

                if (FD.FileName.Trim() != "")
                {
                    this.m_objViewer.dw.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                }
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        internal void m_mthPrint()
        {
            com.digitalwave.iCare.gui.HIS.clsPublic.ChoosePrintDialog(this.m_objViewer.dw,true);
        }
        #endregion

        #region 库名
        /// <summary>
        /// 库名
        /// </summary>
        /// <param name="intDsOrMs"></param>
        /// <param name="m_dtStorageName"></param>
        internal void m_mthGetStorageName(int intDsOrMs, out DataTable m_dtStorageName)
        {
            long lngRes = this.m_objDomain.m_mthGetStorageName(intDsOrMs,out m_dtStorageName);
        }
        #endregion
    }
}
