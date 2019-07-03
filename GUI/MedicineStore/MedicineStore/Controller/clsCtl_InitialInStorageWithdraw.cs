using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 内退初始化
    /// </summary>
    public class clsCtl_InitialInStorageWithdraw : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 窗体
        /// </summary>
        com.digitalwave.iCare.gui.MedicineStore.frmInitialInStorageWithdraw m_objViewer;
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_InMedicineWithdraw m_objDomain = null;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 当前药品内退主表信息
        /// </summary>
        private clsMS_InStorage_VO m_objCurrentMain = null;
        /// <summary>
        /// 查询生产厂家控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryManufacturer = null;
        /// <summary>
        /// 生产厂家
        /// </summary>
        private DataTable m_dtbManufacturer = null;
        /// <summary>
        /// 供应商        /// </summary>
        private DataTable m_dtbVendor = null;
        /// <summary>
        /// 查询供应商控件        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 药品中的批号,有效期录入控制
        /// </summary>
        internal clsMS_MedicineTypeVisionmSet m_clsTypeVisVO;
        #endregion

        #region 构造函数
        /// <summary>
        /// 内退初始化
        /// </summary>
        public clsCtl_InitialInStorageWithdraw()
        {
            m_objDomain = new clsDcl_InMedicineWithdraw();
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
            m_objViewer = (frmInitialInStorageWithdraw)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out p_dtbMedicineInfo);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体

        /// <summary>
        /// 显示药品字典最小元素信息查询窗体        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvInitialData.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvInitialData.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvInitialData.Location.X,
                rect.Y + m_objViewer.m_dgvInitialData.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvInitialData.Location.X,
                rect.Y + m_objViewer.m_dgvInitialData.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvInitialData.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvInitialData.CurrentCell.ColumnIndex;

            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvInitialData.Rows[intRowIndex].DataBoundItem).Row;
            drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
            drCurrent["ASSISTCODE_CHR"] = MS_VO.m_strMedicineCode;
            drCurrent["MEDICINENAME_VCH"] = MS_VO.m_strMedicineName;
            drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
            drCurrent["UNIT_VCHR"] = MS_VO.m_strMedicineUnit;
            drCurrent["CALLPRICE_INT"] = MS_VO.m_dcmTradePrice;
            drCurrent["WHOLESALEPRICE_INT"] = MS_VO.m_dcmTradePrice;
            drCurrent["RETAILPRICE_INT"] = MS_VO.m_dcmRetailPrice;
            drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;
            m_objDomain.m_lngGetMedicineTypeVisionm(MS_VO.m_strMedicineTypeID,out m_clsTypeVisVO);
            m_objViewer.m_dgvInitialData.Focus();
            m_objViewer.m_dgvInitialData.CurrentCell = m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[5];
            m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[5].Selected = true;
        }
        #endregion

        #region 初始化作为DataGridView数据源的DataTable
        /// <summary>
        /// 初始化作为DataGridView数据源的DataTable
        /// </summary>
        /// <param name="p_dtbWithdrawMedicine">作为DataGridView数据源的DataTable</param>
        internal void m_mthInitMedicineTable(ref DataTable p_dtbWithdrawMedicine)
        {
            p_dtbWithdrawMedicine = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("ASSISTCODE_CHR"), new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCH"), new DataColumn("MEDSPEC_VCHR"),new DataColumn("medicinetypeid_chr"),
                new DataColumn("LOTNO_VCHR"),new DataColumn("AMOUNT",typeof(double)),new DataColumn("CALLPRICE_INT",typeof(double)),new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("VALIDPERIOD_DAT"),
                new DataColumn("UNIT_VCHR"),new DataColumn("SERIESID_INT"),new DataColumn("CallMoney"), new DataColumn("WholeSaleMoney"), new DataColumn("RetailMoney"),new DataColumn("PRODUCTORID_CHR"),
                new DataColumn("SERIESID2_INT")};
            p_dtbWithdrawMedicine.Columns.AddRange(dcColumns);
        } 
        #endregion

        #region 插入新的一行药品内退信息
        /// <summary>
        /// 插入新的一行药品内退信息
        /// </summary>
        internal void m_mthInsertNewMedicine()
        {
            if (m_objViewer.m_dtbWithdrawMedicine == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbWithdrawMedicine.NewRow();
            drNew["VALIDPERIOD_DAT"] = DateTime.Now.AddYears(2).ToString("yyyy-MM-dd");
            m_objViewer.m_dtbWithdrawMedicine.Rows.Add(drNew);

            m_objViewer.m_dgvInitialData.Focus();
            m_objViewer.m_dgvInitialData.CurrentCell = m_objViewer.m_dgvInitialData[1, m_objViewer.m_dgvInitialData.RowCount - 1];
        }
        #endregion

        #region DataGridView单元格跳转
        /// <summary>
        /// DataGridView单元格跳转
        /// </summary>
        /// <param name="CurrentCell">当前单元格</param>
        /// <param name="CancelJump">是否取消跳转</param>
        internal void m_dgvInitialData_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            m_objViewer.m_dgvInitialData.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                m_mthShowQueryMedicineForm(strFilter, m_objViewer.m_dtbMedicineDict);

                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 5)
            {
                //if (m_clsTypeVisVO != null && (CurrentCell.Value == null || string.IsNullOrEmpty(CurrentCell.Value.ToString())) && (m_clsTypeVisVO.m_intLotno == 1))
                //{
                //    MessageBox.Show("批号不能为空", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    CancelJump = true;
                //    m_objViewer.m_dgvInitialData.Focus();
                //    return;
                //}
                //else if (CurrentCell.Value == null || string.IsNullOrEmpty(CurrentCell.Value.ToString()))
                //{
                //    CurrentCell.Value = "";
                //}

                int intRowIndex = CurrentCell.RowIndex;
                if (m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[1].Value == null || string.IsNullOrEmpty(m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[1].Value.ToString()))
                {
                    MessageBox.Show("请先选择药品", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CancelJump = true;
                    m_objViewer.m_dgvInitialData.CurrentCell = m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[1];
                    m_objViewer.m_dgvInitialData.CurrentCell.Selected = true;
                    m_objViewer.m_dgvInitialData.Focus();
                    return;
                }

                try
                {
                    for (int iRow = 0; iRow < m_objViewer.m_dgvInitialData.Rows.Count; iRow++)
                    {
                        if (iRow != intRowIndex && m_objViewer.m_dgvInitialData.Rows[iRow].Cells[1].Value.ToString() == m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[1].Value.ToString()
                            && m_objViewer.m_dgvInitialData.Rows[iRow].Cells[5].Value.ToString() == m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[5].Value.ToString())
                        {
                            MessageBox.Show("已存在同一批号的此药品，请重新录入", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            CancelJump = true;
                            m_objViewer.m_dgvInitialData.Focus();
                            return;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }                
            }
            else if (CurrentCell.ColumnIndex == 6)//内退数量
            {
                CancelJump = !m_blnCheckNum(CurrentCell.Value, "内退数量",false);
                if (CancelJump)
                {
                    m_objViewer.m_dgvInitialData.Focus();
                    CurrentCell.Selected = true;
                    return;
                }

                DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvInitialData.Rows[CurrentCell.RowIndex].DataBoundItem;
                double dblPrice = 0d;
                double dblAmount = Convert.ToDouble(CurrentCell.Value);
                if (double.TryParse(drvCurrent["CALLPRICE_INT"].ToString(),out dblPrice))
                {
                    drvCurrent["CallMoney"] = (dblPrice * dblAmount).ToString("0.0000");
                }
                if (double.TryParse(drvCurrent["WHOLESALEPRICE_INT"].ToString(),out dblPrice))
                {
                    drvCurrent["WholeSaleMoney"] = (dblPrice * dblAmount).ToString("0.0000");
                }
                if (double.TryParse(drvCurrent["RETAILPRICE_INT"].ToString(), out dblPrice))
                {
                    drvCurrent["RetailMoney"] = (dblPrice * dblAmount).ToString("0.0000");
                }
            }
            else if (CurrentCell.ColumnIndex == 7)//购入单价
            {
                CancelJump = !m_blnCheckNum(CurrentCell.Value, "购入单价", false);
                if (CancelJump)
                {
                    m_objViewer.m_dgvInitialData.Focus();
                    CurrentCell.Selected = true;
                    return;
                }
                DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvInitialData.Rows[CurrentCell.RowIndex].DataBoundItem;
                double dblAmount = 0d;
                if (double.TryParse(drvCurrent["AMOUNT"].ToString(), out dblAmount))
                {
                    DataRow drCurrent = drvCurrent.Row;
                    drCurrent["CallMoney"] = (dblAmount * Convert.ToDouble(CurrentCell.Value)).ToString("0.0000");
                }
                drvCurrent["WHOLESALEPRICE_INT"] = CurrentCell.Value.ToString();
            }
            else if (CurrentCell.ColumnIndex == 8)//批发单价
            {
                CancelJump = !m_blnCheckNum(CurrentCell.Value, "批发单价", false);
                if (CancelJump)
                {
                    m_objViewer.m_dgvInitialData.Focus();
                    CurrentCell.Selected = true;
                    return;
                }
                DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvInitialData.Rows[CurrentCell.RowIndex].DataBoundItem;
                double dblAmount = 0d;
                if (double.TryParse(drvCurrent["AMOUNT"].ToString(), out dblAmount))
                {
                    DataRow drCurrent = drvCurrent.Row;
                    drCurrent["WholeSaleMoney"] = (dblAmount * Convert.ToDouble(CurrentCell.Value)).ToString("0.0000");
                }
            }
            else if (CurrentCell.ColumnIndex == 9)//零售单价
            {
                CancelJump = !m_blnCheckNum(CurrentCell.Value, "零售单价", true);
                if (CancelJump)
                {
                    m_objViewer.m_dgvInitialData.Focus();
                    CurrentCell.Selected = true;
                    return;
                }
                DataRowView drvCurrent = (DataRowView)m_objViewer.m_dgvInitialData.Rows[CurrentCell.RowIndex].DataBoundItem;
                double dblAmount = 0d;
                if (double.TryParse(drvCurrent["AMOUNT"].ToString(), out dblAmount))
                {
                    DataRow drCurrent = drvCurrent.Row;
                    drCurrent["RetailMoney"] = (dblAmount * Convert.ToDouble(CurrentCell.Value)).ToString("0.0000");
                }
            }
            else if (CurrentCell.ColumnIndex == 10)//有效期
            {
                CancelJump = true;
                m_objViewer.m_dgvInitialData.CurrentCell = m_objViewer.m_dgvInitialData.Rows[CurrentCell.RowIndex].Cells[14];
                m_objViewer.m_dgvInitialData.CurrentCell.Selected = true; ;
            }
            else if (CurrentCell.ColumnIndex == 14)//生产厂家
            {
                CancelJump = true;
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                m_mthShowManufacturer(strFilter);
            }
        } 
        #endregion

        #region 检查是否为大于零的数字
        /// <summary>
        /// 检查是否为大于零的数字
        /// </summary>
        /// <param name="p_objCheckValue">需检查的值</param>
        /// <param name="p_strHintTitle">提示标题</param>
        /// <param name="p_blnCanBeZero">是否能为零</param>
        /// <returns></returns>
        private bool m_blnCheckNum(object p_objCheckValue, string p_strHintTitle, bool p_blnCanBeZero)
        {
            bool blnIsNum = true;

            if (p_objCheckValue == null)
            {
                MessageBox.Show(p_strHintTitle + "不能为空", "内退初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
                blnIsNum = false;
            }

            double dblAmount = 0d;
            if (!double.TryParse(p_objCheckValue.ToString(), out dblAmount))
            {
                MessageBox.Show(p_strHintTitle + "必须为数字", "内退初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
                blnIsNum = false;
            }
            else
            {
                if ((dblAmount <= 0 && !p_blnCanBeZero) || (dblAmount < 0 && p_blnCanBeZero))
                {
                    MessageBox.Show(p_strHintTitle + "必须大于零", "内退初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    blnIsNum = false;
                }
            }
            return blnIsNum;
        } 
        #endregion

        #region 清空界面
        /// <summary>
        /// 清空界面
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_txtWithdrawDept.Clear();
            m_objViewer.m_txtRemark.Clear();
            m_objViewer.m_dtbWithdrawMedicine.Rows.Clear();
            m_objCurrentMain = null;
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_txtInnerWithdrawBillNo.Clear();
        } 
        #endregion

        #region 获取是否审核即入帐
        /// <summary>
        /// 获取是否审核即入帐
        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        internal void m_mthGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetIsImmAccount(out p_blnIsImmAccount);
            objPDDomain = null;
        }
        #endregion

        #region 保存内退初始化
        /// <summary>
        /// 保存内退初始化
        /// </summary>
        /// <returns></returns>
        internal long m_lngSaveWithDraw(string m_strMakName)
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1)
            {
                if (m_objCurrentMain.m_intSTATE_INT == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品内退记录已入帐，不能修改", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品内退记录已审核，不能修改", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1 && m_objCurrentMain.m_intSTATE_INT != 0)
            {
                m_objViewer.m_blnHasCommit = true;
            }

            if (m_objViewer.m_dtbWithdrawMedicine.Rows.Count == 0)
            {
                MessageBox.Show("请先录入药品信息", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (string.IsNullOrEmpty(m_objViewer.m_txtWithdrawDept.Text))
            {
                MessageBox.Show("请先选择内退科室", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtWithdrawDept.Focus();
                return -1;
            }

            long lngRes = 0;
            long lngMainSeq = 0;//主表序列

            //去除空行
            DataRow[] drNull = m_objViewer.m_dtbWithdrawMedicine.Select("MEDICINEID_CHR is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    m_objViewer.m_dtbWithdrawMedicine.Rows.Remove(dr);
                }
            }

            DataRow[] drError = m_objViewer.m_dtbWithdrawMedicine.Select("AMOUNT is null or AMOUNT <= 0 or CALLPRICE_INT is null or CALLPRICE_INT <= 0 or WHOLESALEPRICE_INT is null or WHOLESALEPRICE_INT <= 0 or RETAILPRICE_INT is null or RETAILPRICE_INT < 0");
            if (drError != null && drError.Length > 0)
            {
                DialogResult drResult = MessageBox.Show("部分药品数量或单价不合要求(小于或等于零)，是否忽略并继续保存？","药品内退",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    foreach (DataRow dr in drError)
                    {
                        m_objViewer.m_dtbWithdrawMedicine.Rows.Remove(dr);
                    }
                }
                else
                {
                    for (int iRow = 0; iRow < m_objViewer.m_dgvInitialData.Rows.Count; iRow++)
                    {
                        if (m_objViewer.m_dgvInitialData.Rows[iRow].Cells[1].Value.ToString() == drError[0]["ASSISTCODE_CHR"].ToString())
                        {
                            m_objViewer.m_dgvInitialData.Focus();
                            m_objViewer.m_dgvInitialData.Rows[iRow].Selected = true;
                            break;
                        }
                    }
                    return 0;
                }
            }

            int intRowsCount = m_objViewer.m_dtbWithdrawMedicine.Rows.Count;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                string strMedicineID = m_objViewer.m_dtbWithdrawMedicine.Rows[iRow]["MEDICINEID_CHR"].ToString();
                string strLotNO = m_objViewer.m_dtbWithdrawMedicine.Rows[iRow]["LOTNO_VCHR"].ToString();
                DataRow[] drTest = m_objViewer.m_dtbWithdrawMedicine.Select("MEDICINEID_CHR = '" + strMedicineID + "' and LOTNO_VCHR = '" + strLotNO + "'");
                if (drTest != null && drTest.Length > 1)
                {
                    string strMedicineName = m_objViewer.m_dtbWithdrawMedicine.Rows[iRow]["MEDICINENAME_VCH"].ToString();
                    MessageBox.Show("药品" + strMedicineName + ",批号为" + strLotNO + "的记录在本内退单中存在多条，不能重复录入","药品内退",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return -1;
                }
            }

            bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
            bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
            string strInStorageID = string.Empty;//入库单据号

            clsMS_InStorage_VO objMain = m_objGetMainISVO();

            DataTable dtbNew = m_objViewer.m_dtbWithdrawMedicine.GetChanges(DataRowState.Added);
            clsMS_InStorageDetail_VO[] objDetailNew = m_objGetNewDetail(dtbNew, objMain.m_strINSTORAGEID_VCHR);

            DataTable dtbModify = m_objViewer.m_dtbWithdrawMedicine.GetChanges(DataRowState.Modified);
            clsMS_InStorageDetail_VO[] objDetailModify = m_objGetNewDetail(dtbModify, objMain.m_strINSTORAGEID_VCHR);

            clsMS_StorageDetail[] objStDetail = null;
            clsMS_InStorageDetail_VO[] objDetailAll = null;
            if (m_objViewer.m_intCommitFolow == 1)
            {
                objDetailAll = m_objGetNewDetail(m_objViewer.m_dtbWithdrawMedicine, objMain.m_strINSTORAGEID_VCHR);
                objStDetail = m_objDetailVO(objDetailAll, objMain.m_strINSTORAGEID_VCHR, objMain.m_dtmINSTORAGEDATE_DAT, objMain.m_strVENDORID_CHR);
            }

            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            lngRes = objPDDomain.m_lngSaveInStorage(objMain, ref objDetailNew, objDetailModify, objDetailAll, objStDetail, blnIsAddNew, m_objViewer.m_blnHasCommit, blnIsCommit, m_objViewer.m_blnIsImmAccount, out lngMainSeq, out strInStorageID);

            if (lngRes > 0)
            {
                m_objViewer.m_lngMainSEQ = lngMainSeq;
                objMain.m_lngSERIESID_INT = lngMainSeq;
                objMain.m_strINSTORAGEID_VCHR = strInStorageID;
                m_objViewer.m_txtInnerWithdrawBillNo.Text = strInStorageID;
                m_objCurrentMain = objMain;

                if (m_objViewer.m_intCommitFolow == 1)
                {
                    m_objViewer.m_blnHasCommit = true;
                }

                DataRow[] drNew = m_objViewer.m_dtbWithdrawMedicine.Select("SERIESID_INT is null");
                if (drNew != null && drNew.Length > 0 && drNew.Length == objDetailNew.Length)
                {
                    for (int iRow = 0; iRow < drNew.Length; iRow++)
                    {
                        drNew[iRow]["SERIESID_INT"] = objDetailNew[iRow].m_lngSERIESID_INT;
                        drNew[iRow]["SERIESID2_INT"] = objDetailNew[iRow].m_lngSERIESID_INT2;
                    }
                }

                m_objViewer.m_dtbWithdrawMedicine.AcceptChanges();
                if (blnIsCommit && m_objViewer.m_blnIsImmAccount)
                {
                    if (m_objViewer.m_blnIsImmAccount)
                    {
                        m_objCurrentMain.m_intSTATE_INT = 3;

                        m_objViewer.m_cmdSave.Enabled = false;
                        m_objViewer.m_cmdInsert.Enabled = false;
                        m_objViewer.m_cmdDelete.Enabled = false;
                        m_objViewer.m_cmdNextBill.Enabled = false;
                    }
                    else
                    {
                        m_objCurrentMain.m_intSTATE_INT = 2;

                        m_objViewer.m_cmdSave.Enabled = true;
                        m_objViewer.m_cmdInsert.Enabled = true;
                        m_objViewer.m_cmdDelete.Enabled = true;
                        m_objViewer.m_cmdNextBill.Enabled = true;
                    }
                }

                //直接打印
                DialogResult drResult = MessageBox.Show("保存成功,是否打印当前窗体记录?", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    DataTable dtbPrint = new DataTable();
                    m_objDomain.m_lngGetOutStorageDetailData_report(m_objViewer.m_txtInnerWithdrawBillNo.Text, out dtbPrint);
                    Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();

                    if (m_strMakName == "")
                    {
                        m_strMakName = m_objViewer.LoginInfo.m_strEmpName;
                    }

                    dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;
                    int intPrintType = 0;
                    m_objDomain.m_lngGetPrinType(out intPrintType);
                    string strStorageName;
                    m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
                    if (intPrintType == 0)
                    {
                        dsData.DataWindowObject = "instoragemedicinewithdraw_lj_initial";

                        //按药品ID排序
                        DataView dtv = new DataView();
                        dtv = dtbPrint.DefaultView;
                        dtv.Sort = "assistcode_chr";
                        dtbPrint = dtv.ToTable();

                        dsData.Modify("t_titel.text='" + this.m_objComInfo.m_strGetHospitalTitle() + "内退单'");
                        DataRow dro;
                        if (dtbPrint.Rows.Count % 6 != 0)
                        {
                            int ros = 6 - dtbPrint.Rows.Count % 6;
                            int i_valCount = dtbPrint.Rows.Count + ros;
                            for (int i = 0; i < ros; i++)
                            {
                                dro = dtbPrint.NewRow();
                                dtbPrint.Rows.Add(dro);
                            }
                        }
                    }
                    else
                    {
                        dsData.DataWindowObject = "instoragemedicinewithdraw_cs_initial";
                        dsData.Modify("t_titel.text='" +this.m_objComInfo.m_strGetHospitalTitle() + "退库单(" + strStorageName + ")'");
                        decimal decBug = Convert.ToDecimal(m_objViewer.m_lblBugMoney.Text);
                        string mmm = new Money(decBug).ToString();
                        dsData.Modify("t_bug.text='" + mmm + "'");

                        int m_intShow;
                        clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
                        m_objDon.m_lngGetIfShowInfo(out m_intShow);
                        if(m_intShow == 0)
                            dsData.Modify("t_info.text=''"); 
                    }

                    //dsData.DataWindowObject = "initialinstoragewithdraw";

                    string strEMTname;
                    clsCtl_InMedicineWithdraw clsInwith = new clsCtl_InMedicineWithdraw();
                    dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtInnerWithdrawBillNo.Text + "'");
                    dsData.Modify("m_dtpdate.text='" + m_objViewer.m_dtpTransactDate.Text + "'");
                    dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtWithdrawDept.Text + "'");
                    dsData.Modify("m_txtman.text='" + m_strMakName + "'");
                    dsData.Modify("m_txtman2.text='" + m_strMakName + "'");



                    dsData.Retrieve(dtbPrint);
                    clsCtl_Public clsPub = new clsCtl_Public();
                    clsPub.ChoosePrintDialog_DataStore(dsData, true);
                }

                return 1;
            }
            else
            {
                MessageBox.Show("保存失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            //clsDcl_Purchase_Detail objInDomain = new clsDcl_Purchase_Detail();
            //if (m_objViewer.m_lngMainSEQ == 0)
            //{
            //    string strInStorageID = string.Empty;//内退单据号

            //    lngRes = objInDomain.m_lngAddNewInStorage(objMain, out lngMainSeq, out strInStorageID);
            //    m_objViewer.m_lngMainSEQ = lngMainSeq;
            //    objMain.m_lngSERIESID_INT = lngMainSeq;
            //    objMain.m_strINSTORAGEID_VCHR = strInStorageID;
            //    m_objViewer.m_txtInnerWithdrawBillNo.Text = strInStorageID;
            //}
            //else
            //{
            //    lngRes = objInDomain.m_lngModifyInStorage(objMain);
            //    lngMainSeq = m_objViewer.m_lngMainSEQ;
            //}

            //if (lngRes < 0)
            //{
            //    MessageBox.Show("保存失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}

            //DataTable dtbNew = m_objViewer.m_dtbWithdrawMedicine.GetChanges(DataRowState.Added);
            //clsMS_InStorageDetail_VO[] objDetailNew = m_objGetNewDetail(dtbNew, lngMainSeq, objMain.m_strINSTORAGEID_VCHR);
            //if (objDetailNew != null)
            //{
            //    lngRes = objInDomain.m_lngAddInStorageDetail(ref objDetailNew);
            //    if (lngRes > 0)
            //    {
            //        DataRow[] drNew = m_objViewer.m_dtbWithdrawMedicine.Select("SERIESID_INT is null");
            //        if (drNew != null && drNew.Length > 0 && drNew.Length == objDetailNew.Length)
            //        {
            //            for (int iRow = 0; iRow < drNew.Length; iRow++)
            //            {
            //                drNew[iRow]["SERIESID_INT"] = objDetailNew[iRow].m_lngSERIESID_INT;
            //                drNew[iRow]["SERIESID2_INT"] = objDetailNew[iRow].m_lngSERIESID_INT2;
            //            }
            //        }
            //    }
            //}

            //DataTable dtbModify = m_objViewer.m_dtbWithdrawMedicine.GetChanges(DataRowState.Modified);
            //clsMS_InStorageDetail_VO[] objDetailModify = m_objGetNewDetail(dtbModify, lngMainSeq, objMain.m_strINSTORAGEID_VCHR);
            //if (objDetailModify != null)
            //{
            //    lngRes = objInDomain.m_lngModifyInStorageDetail(objDetailModify);
            //}

            //if (lngRes > 0)
            //{
            //    if (m_objViewer.m_intCommitFolow == 1)
            //    {
            //        clsMS_InStorageDetail_VO[] objDetailAll = m_objGetNewDetail(m_objViewer.m_dtbWithdrawMedicine, lngMainSeq, objMain.m_strINSTORAGEID_VCHR);
            //        m_mthCommitMedicine(objMain, objDetailAll);
            //    }
            //    MessageBox.Show("保存成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_objViewer.m_dtbWithdrawMedicine.AcceptChanges();


            //    //直接打印
            //    DialogResult drResult = MessageBox.Show("是否打印当前窗体记录?", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (drResult == DialogResult.Yes)
            //    {
            //        DataTable dtbPrint = new DataTable();
            //        m_objDomain.m_lngGetOutStorageDetailData_report(m_objViewer.m_txtInnerWithdrawBillNo.Text, out dtbPrint);
            //        Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();

            //        if (m_strMakName == "")
            //        {
            //            m_strMakName = m_objViewer.LoginInfo.m_strEmpName;
            //        }

            //        dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            //        dsData.DataWindowObject = "initialinstoragewithdraw";
            //        string strEMTname;
            //        clsCtl_InMedicineWithdraw clsInwith = new clsCtl_InMedicineWithdraw();
            //       // dsData.Modify("m_storagename.text='" + m_objViewer.m_strStoreRoomName + "'");
            //        dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtInnerWithdrawBillNo.Text + "'");
            //        dsData.Modify("m_dtpdate.text='" + m_objViewer.m_dtpTransactDate.Text + "'");
            //        dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtWithdrawDept.Text + "'");
            //        dsData.Modify("m_txtman.text='" + m_strMakName + "'");
            //        dsData.Modify("m_txtman2.text='" + m_strMakName + "'");
            //     //   dsData.Modify("m_txtprovidername.text='" + strInaccountername_chr + "'");
            //     //   dsData.Modify("t_commnet.text='" + strCommnet_vchr + "'");
         
                    
            //        DataRow dro;
            //        if (dtbPrint.Rows.Count % 6 != 0)
            //        {
            //            int ros = 6 - dtbPrint.Rows.Count % 6;
            //            int i_valCount = dtbPrint.Rows.Count + ros;
            //            for (int i = 0; i < ros; i++)
            //            {
            //                dro = dtbPrint.NewRow();
            //                dtbPrint.Rows.Add(dro);
            //            }
            //        }

            //        dsData.Retrieve(dtbPrint);
            //        clsCtl_Public clsPub = new clsCtl_Public();
            //        clsPub.ChoosePrintDialog_DataStore(dsData, true);
            //    }


            //    return 1;
            //}
            //else
            //{
            //    MessageBox.Show("保存失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}
        }

        /// <summary>
        /// 获取主表VO
        /// </summary>
        /// <returns></returns>
        private clsMS_InStorage_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_InStorage_VO();
                m_objCurrentMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATE_INT = 1;
            }
            m_objCurrentMain.m_lngSERIESID_INT = m_objViewer.m_lngMainSEQ;

            if (!string.IsNullOrEmpty(m_objViewer.m_txtVendor.Text) && m_objViewer.m_txtVendor.Tag != null)
            {
                m_objCurrentMain.m_strVENDORID_CHR = m_objViewer.m_txtVendor.Tag.ToString() ;
                m_objCurrentMain.m_strVENDORName = m_objViewer.m_txtVendor.Text;
            }
            else
            {
                m_objCurrentMain.m_strVENDORID_CHR = string.Empty;
                m_objCurrentMain.m_strVENDORName = string.Empty;
            }            

            m_objCurrentMain.m_strINSTORAGEID_VCHR = m_objViewer.m_txtInnerWithdrawBillNo.Text;
            m_objCurrentMain.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(m_objViewer.m_dtpTransactDate.Text);
            m_objCurrentMain.m_strBUYERID_CHAR = string.Empty;
            m_objCurrentMain.m_strSTORAGERID_CHAR = string.Empty;
            m_objCurrentMain.m_strACCOUNTERID_CHAR = string.Empty;
            m_objCurrentMain.m_strMAKERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            m_objCurrentMain.m_strMAKERName = m_objViewer.LoginInfo.m_strEmpName;
            m_objCurrentMain.m_strSUPPLYCODE_VCHR = string.Empty;
            m_objCurrentMain.m_strCOMMNET_VCHR = m_objViewer.m_txtRemark.Text;
            m_objCurrentMain.m_strINVOICECODE_VCHR = string.Empty;
            m_objCurrentMain.m_dtmINVOICEDATER_DAT = DateTime.MinValue;
            m_objCurrentMain.m_intFORMTYPE_INT = 2;
            m_objCurrentMain.m_intINSTORAGETYPE_INT = 1;
            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            m_objCurrentMain.m_strRETURNDEPT_CHR = m_objViewer.m_txtWithdrawDept.StrItemId;
            return m_objCurrentMain;
        }

        /// <summary>
        /// 获取药品信息
        /// </summary>
        /// <param name="p_dtbData">数据</param>
        /// <param name="p_strMainInStorageID">主表入库单据号</param>
        /// <returns></returns>
        private clsMS_InStorageDetail_VO[] m_objGetNewDetail(DataTable p_dtbData, string p_strMainInStorageID)
        {
            if (p_dtbData == null || p_dtbData.Rows.Count == 0)
            {
                return null;
            }

            int intRowsCount = p_dtbData.Rows.Count;
            clsMS_InStorageDetail_VO[] objNewDetail = new clsMS_InStorageDetail_VO[intRowsCount];
            DataRow drCurrent = null;
            double dblTemp = 0d;
            decimal dcmTemp = 0m;
            int intTemp = 0;
            long lngTemp = 0;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                objNewDetail[iRow] = new clsMS_InStorageDetail_VO();
                drCurrent = p_dtbData.Rows[iRow];
                if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngTemp))
                {
                    objNewDetail[iRow].m_lngSERIESID_INT = lngTemp;
                }
                //objNewDetail[iRow].m_lngSERIESID_INT2 = p_lngMainSeq;
                objNewDetail[iRow].m_intStatus = 1;
                objNewDetail[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objNewDetail[iRow].m_strMEDICINENAME_VCH = drCurrent["MEDICINENAME_VCH"].ToString();
                objNewDetail[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                objNewDetail[iRow].m_dblPACKAMOUNT = 0d;
                objNewDetail[iRow].m_strPACKUNIT_VCHR = string.Empty;
                objNewDetail[iRow].m_dcmPACKCALLPRICE_INT = 0m;
                objNewDetail[iRow].m_dblPACKCONVERT_INT = 0d;

                if (drCurrent["LOTNO_VCHR"].ToString() == "")
                {
                    objNewDetail[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objNewDetail[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                }
                if (double.TryParse(drCurrent["AMOUNT"].ToString(), out dblTemp))
                {
                    objNewDetail[iRow].m_dblAMOUNT = dblTemp;
                }
                if (decimal.TryParse(drCurrent["CALLPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmCALLPRICE_INT = dcmTemp;
                }
                if (decimal.TryParse(drCurrent["WHOLESALEPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmWHOLESALEPRICE_INT = dcmTemp;
                }
                if (decimal.TryParse(drCurrent["RETAILPRICE_INT"].ToString(), out dcmTemp))
                {
                    objNewDetail[iRow].m_dcmRETAILPRICE_INT = dcmTemp;
                }
                objNewDetail[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objNewDetail[iRow].m_intACCEPTANCE_INT = 1;
                objNewDetail[iRow].m_strAPPROVECODE_VCHR = string.Empty;
                objNewDetail[iRow].m_intAPPARENTQUALITY_INT = 1;
                objNewDetail[iRow].m_intPACKQUALITY_INT = 1;
                objNewDetail[iRow].m_intEXAMRUSULT_INT = 1;
                objNewDetail[iRow].m_strEXAMINER = string.Empty;
                objNewDetail[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objNewDetail[iRow].m_strACCEPTANCECOMPANY_CHR = string.Empty;
                objNewDetail[iRow].m_strUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                objNewDetail[iRow].m_strInStorageID = p_strMainInStorageID;
                objNewDetail[iRow].m_intRUTURNNUM_INT = 1;
                objNewDetail[iRow].m_strMedicineTypeID_chr = drCurrent["medicinetypeid_chr"].ToString();
            }
            return objNewDetail;
        }
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        internal void m_mthCommitMedicine(clsMS_InStorage_VO p_objMain, clsMS_InStorageDetail_VO[] p_objSubArr)
        {

            if (p_objMain == null || p_objSubArr == null)
            {
                return;
            }

            try
            {
                long lngRes = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                
                clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO

                objDetailTemp = m_objDetailVO(p_objSubArr, p_objMain.m_strINSTORAGEID_VCHR, p_objMain.m_dtmINSTORAGEDATE_DAT, p_objMain.m_strVENDORID_CHR);
                if (objDetailTemp != null && objDetailTemp.Length > 0)
                {
                    objDetail.AddRange(objDetailTemp);
                }

                clsMS_StorageDetail[] objAllDetail = objDetail.ToArray();//全部明细VO

                if (objAllDetail == null || objAllDetail.Length == 0)
                {
                    return;
                }

                bool blnSaveComplete = true;
                if (m_objViewer.m_blnHasCommit)
                {
                    lngRes = objSTDomain.m_lngDeleteStorageDetail(p_objMain.m_strINSTORAGEID_VCHR, p_objMain.m_dtmINSTORAGEDATE_DAT);
                    if (lngRes < 0)
                    {
                        return;
                    }
                }
                lngRes = objSTDomain.m_lngAddNewStorageDetail(objAllDetail);
                if (lngRes > 0)
                {
                    blnSaveComplete = true;
                }
                else
                {
                    blnSaveComplete = false;
                }

                if (!blnSaveComplete)
                {
                    return;
                }

                System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
                clsMS_Storage objStorage = null;
                bool blnHasDetail = false;//是否已存在


                for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = objAllDetail[iRow].m_strMEDICINEID_CHR;
                    objStorage.m_strMEDICINENAME_VCHR = objAllDetail[iRow].m_strMEDICINENAME_VCHR;
                    objStorage.m_strMEDSPEC_VCHR = objAllDetail[iRow].m_strMEDSPEC_VCHR;
                    objStorage.m_strOPUNIT_VCHR = objAllDetail[iRow].m_strOPUNIT_VCHR;
                    objStorage.m_dblINSTOREGROSS_INT = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dblCURRENTGROSS_NUM = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
                    objStorage.m_dcmCALLPRICE_INT = objAllDetail[iRow].m_dcmCALLPRICE_INT;
                    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

                    if (!hstMedicine.Contains(objAllDetail[iRow].m_strMEDICINEID_CHR))
                    {
                        long lngCurrentSeriesID = 0;
                        lngRes = objSTDomain.m_lngCheckHasStorage(objAllDetail[iRow].m_strMEDICINEID_CHR, m_objViewer.m_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

                        if (blnHasDetail)
                        {
                            if (objStorage != null)
                            {
                                lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, lngCurrentSeriesID);
                            }
                        }
                        else
                        {
                            if (objStorage != null)
                            {
                                lngRes = objSTDomain.m_lngAddNewStorage(ref objStorage);
                            }
                            hstMedicine.Add(objAllDetail[iRow].m_strMEDICINEID_CHR, lngCurrentSeriesID);
                        }
                    }
                    else
                    {
                        lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, Convert.ToInt64(hstMedicine[objAllDetail[iRow].m_strMEDICINEID_CHR]));
                    }
                }
                hstMedicine = null;

                System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                {
                    if (!hstStastic.Contains(objAllDetail[iRow].m_strMEDICINEID_CHR))
                    {
                        hstStastic.Add(objAllDetail[iRow].m_strMEDICINEID_CHR, objAllDetail[iRow].m_lngSERIESID_INT);
                        lngRes = objSTDomain.m_lngStatisticsStorage(objAllDetail[iRow].m_strMEDICINEID_CHR, m_objViewer.m_strStorageID);
                    }
                }

                if (blnSaveComplete)
                {
                    m_mthUpdateUIAfterCommit(p_objMain);
                    m_mthSetCommitUser(p_objMain);
                    m_objViewer.m_blnHasCommit = true;
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }

        /// <summary>
        /// 设置审核人
        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthSetCommitUser(clsMS_InStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            clsDcl_Purchase objPur = new clsDcl_Purchase();
            long[] lngSeq = new long[] { p_objMain.m_lngSERIESID_INT };
            long lngRes = objPur.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSeq);
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthUpdateUIAfterCommit(clsMS_InStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            p_objMain.m_intSTATE_INT = 2;
        }

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_objSubArr">数据</param>
        /// <param name="p_strInID">入库单号</param>
        /// <param name="p_dtmInDate">入库日期</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(clsMS_InStorageDetail_VO[] p_objSubArr, string p_strInID, DateTime p_dtmInDate, string p_strVendorID)
        {
            if (p_objSubArr == null || p_objSubArr.Length == 0)
            {
                return null;
            }

            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_objSubArr.Length];
            for (int iRow = 0; iRow < p_objSubArr.Length; iRow++)
            {
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = p_objSubArr[iRow].m_strMEDICINEID_CHR;
                objSubVO[iRow].m_strMEDICINENAME_VCHR = p_objSubArr[iRow].m_strMEDICINENAME_VCH;
                objSubVO[iRow].m_strMEDSPEC_VCHR = p_objSubArr[iRow].m_strMEDSPEC_VCHR;
                objSubVO[iRow].m_strLOTNO_VCHR = p_objSubArr[iRow].m_strLOTNO_VCHR;
                objSubVO[iRow].m_dcmRETAILPRICE_INT = p_objSubArr[iRow].m_dcmRETAILPRICE_INT;
                objSubVO[iRow].m_dcmCALLPRICE_INT = p_objSubArr[iRow].m_dcmCALLPRICE_INT;
                objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = p_objSubArr[iRow].m_dcmWHOLESALEPRICE_INT;
                objSubVO[iRow].m_dblREALGROSS_INT = p_objSubArr[iRow].m_dblAMOUNT;
                objSubVO[iRow].m_dblAVAILAGROSS_INT = p_objSubArr[iRow].m_dblAMOUNT;
                objSubVO[iRow].m_strOPUNIT_VCHR = p_objSubArr[iRow].m_strUNIT_VCHR;
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = p_objSubArr[iRow].m_dtmVALIDPERIOD_DAT;
                objSubVO[iRow].m_strPRODUCTORID_CHR = p_objSubArr[iRow].m_strPRODUCTORID_CHR;
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_strInID;
                objSubVO[iRow].m_strMEDICINETYPEID_CHR = p_objSubArr[iRow].m_strMedicineTypeID_chr;
                if (p_dtmInDate == DateTime.MinValue || p_dtmInDate == new DateTime(1900, 1, 1))
                {
                    objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = p_dtmInDate;
                }
                objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                objSubVO[iRow].m_strVENDORName = string.Empty;


                objSubVO[iRow].m_intStatus = 1;
            }
            return objSubVO;
        }
        #endregion
        #endregion

        #region 删除内退明细
        /// <summary>
        /// 删除内退明细
        /// </summary>
        internal void m_mthDeleteWintdrawDetail()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATE_INT != 1)
            {
                if (m_objCurrentMain.m_intSTATE_INT == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品内退记录已入帐，不能删除", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品内退记录已审核，不能删除", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (m_objViewer.m_dgvInitialData.SelectedCells.Count == 0)
            {
                return;
            }

            DialogResult drResult = MessageBox.Show("确定删除选定记录？", "药品内退", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            clsDcl_Purchase_Detail objInDomain = new clsDcl_Purchase_Detail();
            int intRowIndex = m_objViewer.m_dgvInitialData.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvInitialData.SelectedCells[0].OwningRow.DataBoundItem).Row;

            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {
                bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;

                clsMS_Storage objStorage = null;
                if (blnIsCommit)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                    objStorage.m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                    objStorage.m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                    objStorage.m_strOPUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                    objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    objStorage.m_strVENDORID_CHR = m_objCurrentMain.m_strVENDORID_CHR;
                }

                clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
                long lngRes = objPDDomain.m_lngDeleteSelectedMedicine(lngSEQ, m_objViewer.m_strStorageID, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), m_objCurrentMain.m_strINSTORAGEID_VCHR, Convert.ToDateTime(drCurrent["validperiod_dat"]), Convert.ToDouble(drCurrent["CALLPRICE_INT"]), blnIsCommit, objStorage);
                objPDDomain = null;
                //long lngRes = objInDomain.m_lngDeleteInStorage(-1, lngSEQ);
                if (lngRes > 0)
                {
                    //if (m_objViewer.m_intCommitFolow == 1)
                    //{
                    //    m_mthUnCommit(drCurrent, intRowIndex);
                    //}
                    m_objViewer.m_dtbWithdrawMedicine.Rows.Remove(drCurrent);
                    MessageBox.Show("删除成功", "药品内退",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除失败", "药品内退", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                m_objViewer.m_dtbWithdrawMedicine.Rows.Remove(drCurrent);
            }
        }
        #endregion

        #region
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_drCurrent">选定药品数据</param>
        /// <param name="p_intRowIndex">第几行数据</param>
        internal void m_mthUnCommit(DataRow p_drCurrent, int p_intRowIndex)
        {
            clsMS_Storage objStorage = new clsMS_Storage();
            objStorage.m_strMEDICINEID_CHR = p_drCurrent["MEDICINEID_CHR"].ToString();
            objStorage.m_strMEDICINENAME_VCHR = p_drCurrent["MEDICINENAME_VCH"].ToString();
            objStorage.m_strMEDSPEC_VCHR = p_drCurrent["MEDSPEC_VCHR"].ToString();
            objStorage.m_strOPUNIT_VCHR = p_drCurrent["UNIT_VCHR"].ToString();
            objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drCurrent["CALLPRICE_INT"]);
            objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            bool blnHasDetail = false;
            long lngCurrentSeriesID = 0;
            long lngRes = objSTDomain.m_lngCheckHasStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID,out blnHasDetail, out lngCurrentSeriesID);

            long lngSubSEQ = 0;
            double p_dblRealgross = 0d;
            double p_dblAvailagross = 0d;
            lngRes = objSTDomain.m_lngGetDetailSEQByIndex(m_objViewer.m_txtInnerWithdrawBillNo.Text, objStorage.m_strMEDICINEID_CHR, p_drCurrent["LOTNO_VCHR"].ToString(), Convert.ToDateTime(p_drCurrent["validperiod_dat"]), Convert.ToDouble(p_drCurrent["CALLPRICE_INT"]), m_objViewer.m_strStorageID, out lngSubSEQ, out p_dblRealgross, out p_dblAvailagross);
            if (lngSubSEQ > 0)
            {
                objStorage.m_dblINSTOREGROSS_INT = p_dblRealgross;
                objStorage.m_dblCURRENTGROSS_NUM = p_dblRealgross;
                lngRes = objSTDomain.m_lngDeleteStorageDetail(lngSubSEQ);
            }

            objStorage.m_lngSERIESID_INT = lngCurrentSeriesID;
            lngRes = objSTDomain.m_lngModifyStorageFromUnCommit(objStorage, lngCurrentSeriesID);

            lngRes = objSTDomain.m_lngStatisticsStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID);
        }
        #endregion

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetExportDept(out p_dtbExportDept);
            objIRDomain = null;
        }
        #endregion

        #region 显示供应商查询
        /// <summary>
        /// 获取生产厂家信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetManufacturer(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetManufacturer(out p_dtbVendor);
        }

        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowManufacturer(string p_strSearchCon)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvInitialData.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvInitialData.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryManufacturer == null)
            {
                m_mthGetManufacturer(out m_dtbManufacturer);
                m_ctlQueryManufacturer = new ctlQueryVendor(m_dtbManufacturer);
                m_objViewer.Controls.Add(m_ctlQueryManufacturer);
                m_ctlQueryManufacturer.ReturnInfo += new ReturnVendorInfo(QueryManufacturer_ReturnInfo);
            }

            int X = rect.X + m_objViewer.m_dgvInitialData.Location.X;
            int Y = rect.Y + m_objViewer.m_dgvInitialData.Location.Y + rect.Height;
            if ((m_objViewer.Size.Height - m_ctlQueryManufacturer.Location.Y) < m_ctlQueryManufacturer.Size.Height)
            {
                Y = rect.Y + m_objViewer.m_dgvInitialData.Location.Y - m_ctlQueryManufacturer.Size.Height;
            }
            if ((m_objViewer.Size.Width - rect.X) < m_ctlQueryManufacturer.Size.Width)
            {
                X = rect.X + m_objViewer.m_dgvInitialData.Location.X - (m_ctlQueryManufacturer.Size.Width - (m_objViewer.Size.Width - rect.X));
            }
            m_ctlQueryManufacturer.Location = new System.Drawing.Point(X, Y);

            m_ctlQueryManufacturer.Visible = true;
            m_ctlQueryManufacturer.BringToFront();
            m_ctlQueryManufacturer.Focus();
            m_ctlQueryManufacturer.m_mthSetSearchText(p_strSearchCon);
        }

        internal void QueryManufacturer_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            if (MS_VO == null)
            {
                m_mthInsertNewMedicine();
                return;
            }

            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvInitialData.CurrentCell.OwningRow.DataBoundItem).Row;
            drCurrent["PRODUCTORID_CHR"] = MS_VO.m_strVendorName;

            DataGridViewCell CurrentCell = m_objViewer.m_dgvInitialData.CurrentCell;
 
            #region 该行数据是否有效，可跳转至下一行
            bool blnIsRight = true;
            int intRowIndex = CurrentCell.RowIndex;
            blnIsRight = m_blnCheckNum(m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[6].Value, "内退数量", false);
            if (!blnIsRight)
            {
                m_objViewer.m_dgvInitialData.Focus();
                m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[6].Selected = true;
                return;
            }
            blnIsRight = m_blnCheckNum(m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[7].Value, "购入单价", false);
            if (!blnIsRight)
            {
                m_objViewer.m_dgvInitialData.Focus();
                m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[7].Selected = true;
                return;
            }
            blnIsRight = m_blnCheckNum(m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[8].Value, "批发单价", false);
            if (!blnIsRight)
            {
                m_objViewer.m_dgvInitialData.Focus();
                m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[8].Selected = true;
                return;
            }
            blnIsRight = m_blnCheckNum(m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[9].Value, "零售单价", true);
            if (!blnIsRight)
            {
                m_objViewer.m_dgvInitialData.Focus();
                m_objViewer.m_dgvInitialData.Rows[intRowIndex].Cells[9].Selected = true;
                return;
            } 
            #endregion

            if (m_objViewer.m_dgvInitialData.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_dgvInitialData.Rows[m_objViewer.m_dgvInitialData.Rows.Count - 1].Cells[1].Value.ToString()))
                {
                    m_objViewer.m_dgvInitialData.Focus();
                    m_objViewer.m_dgvInitialData.CurrentCell = m_objViewer.m_dgvInitialData.Rows[m_objViewer.m_dgvInitialData.Rows.Count - 1].Cells[1];
                    m_objViewer.m_dgvInitialData.CurrentCell.Selected = true;
                }
                else
                {
                    m_mthInsertNewMedicine();
                }
            }
            else
            {
                m_mthInsertNewMedicine();
            }            
        }
        #endregion

        #region 设置药品信息至界面(外部传入VO，以进行修改)
        /// <summary>
        /// 设置药品信息至界面(外部传入VO，以进行修改)
        /// </summary>
        /// <param name="p_objISVO">主表信息</param>
        /// <param name="p_objDetailArr">子表信息</param>
        internal void m_mthSetMedicineDetailToUI(clsMS_InStorage_VO p_objISVO, clsMS_InStorageDetail_VO[] p_objDetailArr)
        {
            if (p_objISVO == null)
            {
                return;
            }

            #region 主表
            m_objViewer.m_lngMainSEQ = p_objISVO.m_lngSERIESID_INT;
            m_objViewer.m_txtInnerWithdrawBillNo.Text = p_objISVO.m_strINSTORAGEID_VCHR;
            m_objViewer.m_txtRemark.Text = p_objISVO.m_strCOMMNET_VCHR;
            m_objViewer.m_txtWithdrawDept.m_mthSelectItem(p_objISVO.m_strRETURNDEPT_CHR);
            m_objViewer.m_dtpTransactDate.Text = p_objISVO.m_dtmINSTORAGEDATE_DAT.ToString("yyyy年MM月dd日");
            m_objViewer.m_txtVendor.Text = p_objISVO.m_strVENDORName;
            m_objViewer.m_txtVendor.Tag = p_objISVO.m_strVENDORID_CHR;

            m_objCurrentMain = p_objISVO;

            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            bool blnHasDone = false;//此单入库后是否已做其它操作

            string strOtherID = string.Empty;//其它操作的单据号

            long lngRes = objPDomain.m_lngCheckHasOutAfterInStorage(p_objISVO.m_strINSTORAGEID_VCHR, out blnHasDone, out strOtherID);
            if (blnHasDone)
            {
                m_objViewer.m_cmdSave.Enabled = false;
                m_objViewer.m_cmdInsert.Enabled = false;
                m_objViewer.m_cmdDelete.Enabled = false;
                m_objViewer.m_cmdNextBill.Enabled = false;
            }
            else
            {
                if (p_objISVO.m_intSTATE_INT != 1)
                {
                    m_objViewer.m_cmdSave.Enabled = false;
                    m_objViewer.m_cmdInsert.Enabled = false;
                    m_objViewer.m_cmdDelete.Enabled = false;
                    m_objViewer.m_cmdNextBill.Enabled = false;
                }

                if (m_objViewer.m_intCommitFolow == 1 && p_objISVO.m_intSTATE_INT != 0 && p_objISVO.m_intSTATE_INT != 3)
                {
                    m_objViewer.m_cmdSave.Enabled = true;
                    m_objViewer.m_cmdInsert.Enabled = true;
                    m_objViewer.m_cmdDelete.Enabled = true;
                    m_objViewer.m_cmdNextBill.Enabled = true;
                }
            }
            #endregion

            if (p_objDetailArr == null)
            {
                return;
            }

            #region 子表
            try
            {
                m_objViewer.m_dtbWithdrawMedicine.BeginLoadData();
                DataRow[] drSub = new DataRow[p_objDetailArr.Length];
                for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                {
                    drSub[iRow] = m_objViewer.m_dtbWithdrawMedicine.NewRow();
                    drSub[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                    drSub[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT2;
                    drSub[iRow]["MEDICINEID_CHR"] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    drSub[iRow]["MEDICINENAME_VCH"] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                    drSub[iRow]["MEDSPEC_VCHR"] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;                    
                    drSub[iRow]["LOTNO_VCHR"] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                    drSub[iRow]["AMOUNT"] = p_objDetailArr[iRow].m_dblAMOUNT;
                    drSub[iRow]["CALLPRICE_INT"] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                    drSub[iRow]["WHOLESALEPRICE_INT"] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                    drSub[iRow]["RETAILPRICE_INT"] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                    drSub[iRow]["VALIDPERIOD_DAT"] = p_objDetailArr[iRow].m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");                    
                    drSub[iRow]["PRODUCTORID_CHR"] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;                   
                    drSub[iRow]["UNIT_VCHR"] = p_objDetailArr[iRow].m_strUNIT_VCHR;
                    drSub[iRow]["CallMoney"] = (Convert.ToDouble(p_objDetailArr[iRow].m_dcmCALLPRICE_INT) * p_objDetailArr[iRow].m_dblAMOUNT).ToString("0.0000");
                    drSub[iRow]["RetailMoney"] = (Convert.ToDouble(p_objDetailArr[iRow].m_dcmRETAILPRICE_INT) * p_objDetailArr[iRow].m_dblAMOUNT).ToString("0.0000");
                    drSub[iRow]["ASSISTCODE_CHR"] = p_objDetailArr[iRow].m_strMEDICINECode;
                    drSub[iRow]["WholeSaleMoney"] = (Convert.ToDouble(p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT) * p_objDetailArr[iRow].m_dblAMOUNT).ToString("0.0000");
                    drSub[iRow]["medicinetypeid_chr"] = p_objDetailArr[iRow].m_strMedicineTypeID_chr;
                    m_objViewer.m_dtbWithdrawMedicine.LoadDataRow(drSub[iRow].ItemArray, true);
                }
            }
            catch (Exception Ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(Ex);
            }
            finally
            {
                m_objViewer.m_dtbWithdrawMedicine.EndLoadData();
            }
            //m_mthGetAllMoney();
            #endregion
        }
        #endregion

        #region 计算界面金额
        /// <summary>
        /// 计算界面金额
        /// </summary>
        internal void m_mthCountMoney()
        {
            m_objViewer.m_lblBugMoney.Text = string.Empty;
            m_objViewer.m_lblSaleMoney.Text = string.Empty;

            if (m_objViewer.m_dtbWithdrawMedicine != null)
            {
                int intRowsCount = m_objViewer.m_dtbWithdrawMedicine.Rows.Count;
                double dblBuyMoney = 0d;
                double dblSaleMoney = 0d;

                double dblAmountTemp = 0d;
                double dblPriceTemp = 0d;
                DataRow drTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbWithdrawMedicine.Rows[iRow];
                    if (drTemp.RowState == DataRowState.Deleted || drTemp.RowState == DataRowState.Detached)
                    {
                        continue;
                    }
                    if (double.TryParse(drTemp["AMOUNT"].ToString(), out dblAmountTemp))
                    {
                        if (double.TryParse(drTemp["CALLPRICE_INT"].ToString(), out dblPriceTemp))
                        {
                            dblBuyMoney += dblAmountTemp * dblPriceTemp;
                        }
                        if (double.TryParse(drTemp["RETAILPRICE_INT"].ToString(), out dblPriceTemp))
                        {
                            dblSaleMoney += dblAmountTemp * dblPriceTemp;
                        }
                    }
                }
                m_objViewer.m_lblBugMoney.Text = dblBuyMoney.ToString("0.0000");
                m_objViewer.m_lblSaleMoney.Text = dblSaleMoney.ToString("0.0000");
            }
        }
        #endregion

        #region 显示供应商查询


        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }

        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);
                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.panel2.Location.X + m_objViewer.m_txtVendor.Location.X - (m_ctlQueryVendor.Size.Width - m_objViewer.m_txtVendor.Size.Width);
                int Y = m_objViewer.panel2.Location.Y + m_objViewer.m_txtVendor.Location.Y + m_objViewer.m_txtVendor.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtVendor.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtVendor.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtVendor.Text = MS_VO.m_strVendorName;

            m_objViewer.m_txtRemark.Focus();
        }
        #endregion

        public void m_mthOutStorageReport(string romID, string m_strMakName)
        {
            DataTable dtb =new DataTable();

            m_objDomain.m_lngGetOutStorageDetailData_report(m_objViewer.m_txtInnerWithdrawBillNo.Text,out dtb);
            frmInStorageMedicineWithdrawDetailReport frmReport = new frmInStorageMedicineWithdrawDetailReport();
            frmReport.intInitial = 1;
            int intPrintType = 0;

            m_objDomain.m_lngGetPrinType(out intPrintType);
            string strStorageName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID,out strStorageName);
            if (intPrintType == 0)
            {
                frmReport.datWindow.DataWindowObject = "instoragemedicinewithdraw_lj_initial";
                //按药品ID排序
                DataView dtv = new DataView();
                dtv = dtb.DefaultView;
                dtv.Sort = "assistcode_chr";
                dtb = dtv.ToTable();

                frmReport.strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "内退单";
            }
            else
            {
                frmReport.datWindow.DataWindowObject = "instoragemedicinewithdraw_cs_initial";
                frmReport.strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "退库单(" + strStorageName + ")";

                decimal decBug = Convert.ToDecimal(m_objViewer.m_lblBugMoney.Text);
                string mmm = new Money(decBug).ToString();
                frmReport.decBug = mmm;
            }
            DataTable dtbMak = new DataTable();
            m_objDomain.m_lngGetEMP(m_objCurrentMain.m_strMAKERID_CHR,out dtbMak);
            frmReport.strStoragename_chr = strStorageName;
            frmReport.strInstorageid_vchr = m_objViewer.m_txtInnerWithdrawBillNo.Text;
            frmReport.strExam_dat = m_objViewer.m_dtpTransactDate.Text;
            frmReport.strReturndept_chr =m_objViewer.m_txtWithdrawDept.Text;
            frmReport.strMakername_chr = m_strMakName;
            frmReport.m_dtbDetail = dtb;
            frmReport.ShowDialog();
        }
    }
}
