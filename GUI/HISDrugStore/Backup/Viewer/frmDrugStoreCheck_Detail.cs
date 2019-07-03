using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 新制盘点单
    /// </summary>
    public partial class frmDrugStoreCheck_Detail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 药房id
        /// </summary>
        public string m_strStoreID = string.Empty;
        /// <summary>
        /// 主表记录
        /// </summary>
        internal clsDS_Check_VO m_objMain = null;
        /// <summary>
        /// 明细表记录
        /// </summary>
        public DataTable dtbDrugCheck_detail = null;
        /// <summary>
        /// 实际保存到数据库的盘点明细
        /// </summary>
        internal DataTable dtbDrugCheck_TrueDetail = null;
        /// <summary>
        /// 窗体显示类型０：新制,１：修改
        /// </summary>
        public int intShowType = 0;
        /// <summary>
        /// 药房ID
        /// </summary>
        internal string m_strDrugID = string.Empty;
        /// <summary>
        /// 盘点主表序列号
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// 药品字典信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 药房对应的部门ID
        /// </summary>
        public string m_strStoreDeptID = string.Empty;
        /// <summary>
        /// 盘点模式，0为默认，1为广医三院
        /// </summary>
        internal int m_intCheckMode = 0;
        /// <summary>
        /// 过滤显示（打印用）
        /// </summary>
        internal string m_strFilter = string.Empty;
        /// <summary>
        /// 是否住院单位
        /// </summary>
        internal bool m_blnIsHospital;
        /// <summary>
        /// 是否允许保存库存数为负数（只限于保存单据）
        /// </summary>
        internal int m_intAllowNegativeStorage = 0;
        /// <summary>
        /// 一个月是否只允许生成一张盘点单据：参数5045
        /// </summary>
        internal int m_intOneBillPerMonth = 0;
        ///// <summary>
        ///// 是否允许拆分厂家 0 不拆分 1 拆分--取0时厂家列将不显示
        ///// </summary>
        //internal int m_intSplitProductor = 0;
        #endregion

        public frmDrugStoreCheck_Detail()
        {
            InitializeComponent();
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthGetCheckMode(out m_intCheckMode);
        }

        private void frmDrugStoreCheck_Detail_Load(object sender, EventArgs e)
        {
            this.m_dgvDetailInfo.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthLoad();            
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthGetAllowNegativeStorage(out m_intAllowNegativeStorage);

            m_dgvDetailInfo.Columns["LOTNO_VCHR"].Visible = false;
            m_dgvDetailInfo.Columns["opcallprice_int"].Visible = false;
            m_dgvDetailInfo.Columns["ipcallprice_int"].Visible = false;
            m_dgvDetailInfo.Columns["indrugstoreid_vchr"].Visible = false;//库存明细表dsinstoreid_vchr盘点明细表indrugstoreid_vchr


            if (m_intCheckMode == 1)
            {
                m_dgvDetailInfo.Columns["CHECKGROSS_INT"].ReadOnly = true;
                m_dgvDetailInfo.Columns["m_dgvtxtCheckReason"].ReadOnly = true;

                m_dgvDetailInfo.Columns["oprealgross_int"].ReadOnly = true;
                m_dgvDetailInfo.Columns["iprealgross_int"].ReadOnly = true;
                m_dgvDetailInfo.Columns["OPCHECKGROSS_INT"].ReadOnly = true;
                m_dgvDetailInfo.Columns["IPCHECKGROSS_INT"].ReadOnly = true;

                m_dgvDetailInfo.Columns["oprealgross_int"].Visible = false;
                m_dgvDetailInfo.Columns["iprealgross_int"].Visible = false;
                m_dgvDetailInfo.Columns["OPCHECKGROSS_INT"].Visible = false;
                m_dgvDetailInfo.Columns["IPCHECKGROSS_INT"].Visible = false;
                m_dgvDetailInfo.Columns["opcheckresult_int"].Visible = false;
                m_dgvDetailInfo.Columns["ipcheckresult_int"].Visible = false;

                m_dgvDetailInfo.Columns["opunit_chr"].Visible = false;
                m_dgvDetailInfo.Columns["ipunit_chr"].Visible = false;
                m_dgvDetailInfo.Columns["packqty_dec"].Visible = false;
            }
            else
            {
                m_dgvDetailInfo.Columns["realgross_int"].Visible = false;
                m_dgvDetailInfo.Columns["CHECKGROSS_INT"].Visible = false;

                m_dgvDetailInfo.Columns["opcheckresult_int"].ReadOnly = false;
                m_dgvDetailInfo.Columns["ipcheckresult_int"].ReadOnly = false;
            }

            m_intOneBillPerMonth = Convert.ToInt32(this.objController.m_objComInfo.m_lonGetModuleInfo("5045"));
            //this.m_intSplitProductor = int.Parse(this.objController.m_objComInfo.m_lonGetModuleInfo("5041"));
            //if (m_intSplitProductor == 0)
            //{
            //    m_dgvDetailInfo.Columns["productorid_chr"].Visible = false;
            //}
        }

        #region 药房盘点
        /// <summary>
        /// 药房盘点
        /// </summary>
        public frmDrugStoreCheck_Detail(string p_strStorageID,string p_strStoreDeptID)
        {
            InitializeComponent();
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthGetCheckMode(out m_intCheckMode);
            m_dgvDetailInfo.AutoGenerateColumns = false;
            m_txtMaker.Tag = LoginInfo.m_strEmpID;
            m_txtMaker.Text = LoginInfo.m_strEmpName;
            m_datCheck.Text = clsPub.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");

            m_strDrugID = p_strStorageID;
            m_strStoreDeptID = p_strStoreDeptID;
            //this.m_mthGetInitialData();
            //m_bgwGetData.RunWorkerAsync();
        }
        #endregion

        public override void CreateController()
        {
            this.objController = new clsCtl_DrugStoreCheck_Detail();
            objController.Set_GUI_Apperance(this);
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_dgvDetailInfo.EndEdit();

                this.Cursor = Cursors.WaitCursor;
                //一个帐务期只允许生成一张盘点表
                if (m_intOneBillPerMonth == 1)
                {
                    bool m_blnExist = false;
                    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_lngCheckExistBill(m_txtBillId.Text, out m_blnExist);
                    if (m_blnExist)
                    {
                        MessageBox.Show("一个帐务期只允许生成一张盘点表，该药房已生成盘点单，请检查。", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (m_txtBillId.Text.Length == 0)
                    {
                        if (MessageBox.Show("一个帐务期只允许生成一张盘点表，是否确定保存？", "注意...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                            return;
                    }
                }
                clsPublic.PlayAvi("正在保存，请稍候...");

                long lngRes = ((clsCtl_DrugStoreCheck_Detail)this.objController).m_lngSaveDetail();

                if (lngRes > 0)
                {
                    MessageBox.Show("保存成功", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (lngRes == -3)
                {
                    MessageBox.Show("存在未审核业务单据,不允许保存", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (lngRes == -5)
                {
                    MessageBox.Show("存在药库已经审核但药房仍未审核的请领单,不允许保存", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
                else if (lngRes == -2)
                {
                    MessageBox.Show("包含有库存数量为负数的药品,不允许保存", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (lngRes == -4)
                {
                    MessageBox.Show("存在“暂调入库“金额不为零的入库单据,不允许保存", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(lngRes == -99)
                {
                    MessageBox.Show("保存失败\r\n 该盘点单据状态已经被修改，请重新加载后再处理。", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("保存失败", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                clsPublic.CloseAvi();
                this.Cursor = Cursors.Default;
            }
        }

        private void m_btnModify_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthInsertNewMedicineData();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drResult = MessageBox.Show("确定删除选定记录？", "药房盘点", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthDeleteStoreCheck();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                m_lblMedicineType.Text = ((clsCtl_DrugStoreCheck_Detail)this.objController).m_strShowMedicineType(dtbDrugCheck_detail);
                this.Cursor = Cursors.Default;
            }
        }

        private void m_txtMaker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthSetEmpToList(m_txtMaker.Text, m_txtMaker);
            }
        }

        private void m_txtFindMedicine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbMedicineInfo == null)
                {
                    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthGetMedBaseInfo(m_strStoreID, ref m_dtbMedicineInfo);
                }
                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthShowQueryMedicineForm_lock(m_txtFindMedicine.Text, m_dtbMedicineInfo);
                //if (m_txtFindMedicine.Tag != null)
                //    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthLocalizeRow(m_txtFindMedicine.Tag.ToString());
            }
        }

        private void m_txtFindMedicine_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtFindMedicine.SelectAll();
        }

        bool m_blnLoading2 = false;
        private void m_dgvDetailInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_blnLoading || m_blnLoading2) return;
            if (m_dgvDetailInfo.CurrentCell != null)
            {
                if (e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].ColumnIndex || e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].ColumnIndex)
                {
                    try
                    {
                        m_blnLoading2 = true;
                        double dblTemp = 0d;
                        double dblOPTemp = 0d;
                        double dblIPTemp = 0d;
                        double dblRealGross = Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["realgross_int"].Value);
                        DataRow drCurrent = ((DataRowView)m_dgvDetailInfo.Rows[e.RowIndex].DataBoundItem).Row;
                        int intPackQty = Convert.ToInt32(drCurrent["packqty_dec"]);//包装量
                        if (double.TryParse(m_dgvDetailInfo.CurrentCell.FormattedValue.ToString(), out dblTemp))
                        {
                            if (e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].ColumnIndex)
                            {
                                dblOPTemp = Math.Round(dblTemp, 2, MidpointRounding.AwayFromZero);
                                dblIPTemp = Math.Round(Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value), 2, MidpointRounding.AwayFromZero);
                            }
                            else
                            {
                                dblOPTemp = Math.Round(Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value), 2, MidpointRounding.AwayFromZero);
                                dblIPTemp = Math.Round(dblTemp, 2, MidpointRounding.AwayFromZero);
                            }

                            if (m_blnIsHospital)
                            {
                                if (drCurrent["ipchargeflg_int"].ToString() == "0")
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero)).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero) - dblRealGross).ToString("0.00");
                                }
                                else
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPTemp * intPackQty + dblIPTemp).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp * intPackQty + dblIPTemp - dblRealGross).ToString("0.00");
                                }
                            }
                            else
                            {
                                if (drCurrent["opchargeflg_int"].ToString() == "0")
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero)).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero) - dblRealGross).ToString("0.00");
                                }
                                else
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPTemp * intPackQty + dblIPTemp).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp * intPackQty + dblIPTemp - dblRealGross).ToString("0.00");
                                }
                            }

                            //drCurrent["CHECKRESULT_INT"] = (dblTemp - dblRealGross).ToString("0.00");
                            drCurrent["RealMoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//实盘金额
                            //drCurrent["balance"] = Math.Round(Convert.ToDouble(drCurrent["CHECKRESULT_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//盈亏金额
                            //drCurrent["callmoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//购入金额

                            drCurrent["ipcheckresult_int"] = (dblIPTemp + dblOPTemp * intPackQty - (Convert.ToDouble(drCurrent["iprealgross_int"]) + Convert.ToDouble(drCurrent["oprealgross_int"]) * intPackQty)) % intPackQty;
                            drCurrent["opcheckresult_int"] = (int)((dblIPTemp + dblOPTemp * intPackQty - (Convert.ToDouble(drCurrent["iprealgross_int"]) + Convert.ToDouble(drCurrent["oprealgross_int"]) * intPackQty)) / intPackQty);
                            drCurrent["balance"] = Math.Round((Convert.ToDouble(drCurrent["ipcheckresult_int"]) + Convert.ToDouble(drCurrent["opcheckresult_int"]) * intPackQty) * Convert.ToDouble(drCurrent["opretailprice_int"]) / intPackQty, 8, MidpointRounding.AwayFromZero);//盈亏金额
                        }
                        else
                        {
                            MessageBox.Show("实际数量不能为空且只能为数字", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            m_dgvDetailInfo.Focus();
                            drCurrent["CHECKGROSS_INT"] = dblRealGross.ToString("0.00");
                            drCurrent["CHECKRESULT_INT"] = 0;
                            drCurrent["ipcheckresult_int"] = 0;
                            drCurrent["opcheckresult_int"] = 0;
                            drCurrent["RealMoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//实盘金额
                            //drCurrent["callmoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//购入金额
                            drCurrent["balance"] = 0;

                            if (m_blnIsHospital)
                            {
                                if (drCurrent["ipchargeflg_int"].ToString() == "0")
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = dblRealGross;
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = 0;
                                }
                                else
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = (int)(dblRealGross / intPackQty);
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = dblRealGross % intPackQty;
                                }
                            }
                            else
                            {
                                if (drCurrent["opchargeflg_int"].ToString() == "0")
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = dblRealGross;
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = 0;
                                }
                                else
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = (int)(dblRealGross / intPackQty);
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = dblRealGross % intPackQty;
                                }
                            }
                        }
                        ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthSetCheckMoney();
                        drCurrent.EndEdit();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    finally
                    {
                        m_blnLoading2 = false;
                    }
                }
                else if (e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["opcheckresult_int"].ColumnIndex || e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["ipcheckresult_int"].ColumnIndex)
                {
                    try
                    {
                        m_blnLoading2 = true;
                        double dblTemp = 0d;
                        double dblOPTemp = 0d;
                        double dblIPTemp = 0d;
                        double dblRealGross = Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["realgross_int"].Value);
                        DataRow drCurrent = ((DataRowView)m_dgvDetailInfo.Rows[e.RowIndex].DataBoundItem).Row;
                        int intPackQty = Convert.ToInt32(drCurrent["packqty_dec"]);//包装量
                        if (double.TryParse(m_dgvDetailInfo.CurrentCell.FormattedValue.ToString(), out dblTemp))
                        {
                            if (e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["opcheckresult_int"].ColumnIndex)
                            {
                                dblOPTemp = Convert.ToDouble(dblTemp.ToString("F2"));
                                if (m_dgvDetailInfo.Rows[e.RowIndex].Cells["ipcheckresult_int"].Value.ToString().Length == 0)
                                {
                                    dblIPTemp = 0;
                                }
                                else
                                {
                                    dblIPTemp = Convert.ToDouble(Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["ipcheckresult_int"].Value).ToString("F2"));
                                }
                            }
                            else
                            {
                                if (m_dgvDetailInfo.Rows[e.RowIndex].Cells["ipcheckresult_int"].Value.ToString().Length == 0)
                                {
                                    dblOPTemp = 0;
                                }
                                else
                                {
                                    dblOPTemp = Convert.ToDouble(Convert.ToDouble(m_dgvDetailInfo.Rows[e.RowIndex].Cells["opcheckresult_int"].Value).ToString("F2"));
                                }
                                dblIPTemp = Convert.ToDouble(dblTemp.ToString("F2"));
                            }
                            
                            double dblOPReal = Convert.ToDouble(drCurrent["oprealgross_int"]);
                            double dblIPReal = Convert.ToDouble(drCurrent["iprealgross_int"]);

                            if (m_blnIsHospital)
                            {
                                if (drCurrent["ipchargeflg_int"].ToString() == "0")
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPReal + dblOPTemp+Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero)).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero)).ToString("0.00");
                                }
                                else
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPReal* intPackQty+ dblOPTemp * intPackQty + dblIPTemp).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp * intPackQty + dblIPTemp).ToString("0.00");
                                }
                            }
                            else
                            {
                                if (drCurrent["opchargeflg_int"].ToString() == "0")
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPReal + dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero)).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp + Math.Round(dblIPTemp / intPackQty, 2, MidpointRounding.AwayFromZero)).ToString("0.00");
                                }
                                else
                                {
                                    drCurrent["CHECKGROSS_INT"] = (dblOPReal * intPackQty + dblOPTemp * intPackQty + dblIPTemp).ToString("0.00");
                                    drCurrent["CHECKRESULT_INT"] = (dblOPTemp * intPackQty + dblIPTemp).ToString("0.00");
                                }
                            }

                            //drCurrent["CHECKRESULT_INT"] = (dblTemp - dblRealGross).ToString("0.00");
                            drCurrent["RealMoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//实盘金额
                            //drCurrent["balance"] = Math.Round(Convert.ToDouble(drCurrent["CHECKRESULT_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//盈亏金额
                            //drCurrent["callmoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//购入金额

                            drCurrent["ipcheckgross_int"] = (Convert.ToDouble(drCurrent["oprealgross_int"]) * intPackQty + Convert.ToDouble(drCurrent["iprealgross_int"]) + dblIPTemp + dblOPTemp * intPackQty) % intPackQty;
                            drCurrent["opcheckgross_int"] = (int)((Convert.ToDouble(drCurrent["oprealgross_int"]) * intPackQty + Convert.ToDouble(drCurrent["iprealgross_int"]) + dblIPTemp + dblOPTemp * intPackQty) / intPackQty);
                            drCurrent["balance"] = Math.Round((dblIPTemp + dblOPTemp * intPackQty) * Convert.ToDouble(drCurrent["opretailprice_int"]) / intPackQty, 8, MidpointRounding.AwayFromZero);//盈亏金额
                        }
                        else
                        {
                            MessageBox.Show("实际数量不能为空且只能为数字", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            m_dgvDetailInfo.Focus();
                            drCurrent["CHECKGROSS_INT"] = dblRealGross.ToString("0.00");
                            drCurrent["CHECKRESULT_INT"] = 0;
                            drCurrent["ipcheckresult_int"] = 0;
                            drCurrent["opcheckresult_int"] = 0;
                            drCurrent["RealMoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//实盘金额
                            //drCurrent["callmoney"] = Math.Round(Convert.ToDouble(drCurrent["CHECKGROSS_INT"]) * Convert.ToDouble(drCurrent["retailprice_int"]), 4, MidpointRounding.AwayFromZero);//购入金额
                            drCurrent["balance"] = 0;

                            if (m_blnIsHospital)
                            {
                                if (drCurrent["ipchargeflg_int"].ToString() == "0")
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = dblRealGross;
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = 0;
                                }
                                else
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = (int)(dblRealGross / intPackQty);
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = dblRealGross % intPackQty;
                                }
                            }
                            else
                            {
                                if (drCurrent["opchargeflg_int"].ToString() == "0")
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = dblRealGross;
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = 0;
                                }
                                else
                                {
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["OPCHECKGROSS_INT"].Value = (int)(dblRealGross / intPackQty);
                                    m_dgvDetailInfo.Rows[e.RowIndex].Cells["IPCHECKGROSS_INT"].Value = dblRealGross % intPackQty;
                                }
                            }
                        }
                        ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthSetCheckMoney();
                        drCurrent.EndEdit();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                    finally
                    {
                        m_blnLoading2 = false;
                    }
                }
                else if (m_dgvDetailInfo.CurrentCell != null && e.ColumnIndex == m_dgvDetailInfo.Rows[e.RowIndex].Cells["m_dgvtxtCheckReason"].ColumnIndex)
                {
                    DataRow drCurrent = ((DataRowView)m_dgvDetailInfo.Rows[e.RowIndex].DataBoundItem).Row;
                    drCurrent["checkreason_vchr"] = m_dgvDetailInfo.Rows[e.RowIndex].Cells["m_dgvtxtCheckReason"].Value;
                    drCurrent.EndEdit();
                }
            }
        }

        bool m_blnLoading = false;
        private void m_dgvDetailInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                m_blnLoading = true;
                for (int iRow = 0; iRow < m_dgvDetailInfo.Rows.Count; iRow++)
                {
                    m_dgvDetailInfo.Rows[iRow].Cells[0].Value = iRow + 1;
                    if (m_dgvDetailInfo.Rows[iRow].Cells[7].Value != null && !string.IsNullOrEmpty(m_dgvDetailInfo.Rows[iRow].Cells[7].Value.ToString()))
                    {
                        m_dgvDetailInfo.Rows[iRow].Cells[2].ReadOnly = true;
                    }

                    ////自动计算电脑数、实际数
                    //if (m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value.ToString().Length > 0)
                    //{
                    //    if (m_blnIsHospital)
                    //    {
                    //        if (m_dgvDetailInfo.Rows[iRow].Cells["ipchargeflg_int"].Value.ToString() == "0")
                    //        {
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcurrentgross_int"].Value = m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value;
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcurrentgross_int"].Value = 0;
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcheckgross_int"].Value = m_dgvDetailInfo.Rows[iRow].Cells["checkgross_int"].Value;
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcheckgross_int"].Value = 0;
                    //        }
                    //        else
                    //        {
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcurrentgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value) / Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value));
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcurrentgross_int"].Value = Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value) % Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value);
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcheckgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["checkgross_int"].Value) / Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value));
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcheckgross_int"].Value = Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["checkgross_int"].Value) % Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (m_dgvDetailInfo.Rows[iRow].Cells["opchargeflg_int"].Value.ToString() == "0")
                    //        {
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcurrentgross_int"].Value = m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value;
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcurrentgross_int"].Value = 0;
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcheckgross_int"].Value = m_dgvDetailInfo.Rows[iRow].Cells["checkgross_int"].Value;
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcheckgross_int"].Value = 0;
                    //        }
                    //        else
                    //        {
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcurrentgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value) / Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value));
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcurrentgross_int"].Value = Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["realgross_int"].Value) % Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value);
                    //            m_dgvDetailInfo.Rows[iRow].Cells["opcheckgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["checkgross_int"].Value) / Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value));
                    //            m_dgvDetailInfo.Rows[iRow].Cells["ipcheckgross_int"].Value = Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["checkgross_int"].Value) % Convert.ToDouble(m_dgvDetailInfo.Rows[iRow].Cells["packqty_dec"].Value);
                    //        }
                    //    }
                    //}
                }

                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthSetCheckMoney();
            }
            catch
            {
            }
            finally
            {
                m_blnLoading = false;
            }
        }

        private void m_dgvDetailInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvDetailInfo.Rows.Count; iRow++)
            {
                m_dgvDetailInfo.Rows[iRow].Cells[0].Value = iRow + 1;
                if (m_dgvDetailInfo.Rows[iRow].Cells[7].Value != null && !string.IsNullOrEmpty(m_dgvDetailInfo.Rows[iRow].Cells[7].Value.ToString()))
                {
                    m_dgvDetailInfo.Rows[iRow].Cells[2].ReadOnly = true;
                }
            }
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthSetCheckMoney();
        }

        private void m_dgvDetailInfo_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow dgr = m_dgvDetailInfo.Rows[e.RowIndex];
            if (dgr.Cells["LOTNO_VCHR"].Value.ToString() == "UNKNOWN")
            {
                dgr.Cells["LOTNO_VCHR"].Value = "";
            }
        }

        private void m_dgvDetailInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string strEx = e.Exception.Message;
        }

        private void m_dgvDetailInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {            
            CancelJump = false;
            if (m_btnSave.Enabled == false) return;
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvDetailInfo.EndEdit();

            if (CurrentCell.ColumnIndex == m_dgvDetailInfo.Columns["assistcode_chr"].Index)//药品代码
            {
                string strSearch = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strSearch = CurrentCell.Value.ToString();
                }
                if (m_dtbMedicineInfo == null || m_dtbMedicineInfo.Rows.Count == 0)
                {
                    this.m_mthGetInitialData();
                }
                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthShowQueryMedicineForm(strSearch, m_dtbMedicineInfo);
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == m_dgvDetailInfo.Columns["OPCHECKGROSS_INT"].Index)//实际数量（基本单位）
            {
                CancelJump = true;
                try
                {
                    m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex].Cells["IPCHECKGROSS_INT"];
                    m_dgvDetailInfo.CurrentCell.Selected = true;
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
            }
            else if (CurrentCell.ColumnIndex == m_dgvDetailInfo.Columns["IPCHECKGROSS_INT"].Index)//实际数量（最小单位）
            {
                CancelJump = true;
                try
                {
                    //m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex].Cells[23];
                    //m_dgvDetailInfo.CurrentCell.Selected = true;

                    //20090507:不定位到盈亏原因，方便录入。
                    if (CurrentCell.RowIndex < m_dgvDetailInfo.Rows.Count - 1)
                    {
                        if (m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells["MEDICINENAME_VCH"].Value == DBNull.Value)
                        {
                            m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells["assistcode_chr"];
                            m_dgvDetailInfo.CurrentCell.Selected = true;
                        }
                        else
                        {
                            m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells["OPCHECKGROSS_INT"];
                            m_dgvDetailInfo.CurrentCell.Selected = true;
                        }
                    }
                    else
                    {
                        ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthInsertNewMedicineData();
                    }
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
            }
            else if (CurrentCell.ColumnIndex == m_dgvDetailInfo.Columns["m_dgvtxtCheckReason"].Index)//盈亏原因
            {
                CancelJump = true;
                if (CurrentCell.RowIndex < m_dgvDetailInfo.Rows.Count - 1)
                {
                    if (m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells["MEDICINENAME_VCH"].Value == DBNull.Value)
                    {
                        m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells["assistcode_chr"];
                        m_dgvDetailInfo.CurrentCell.Selected = true;
                    }
                    else
                    {
                        m_dgvDetailInfo.CurrentCell = m_dgvDetailInfo.Rows[CurrentCell.RowIndex + 1].Cells["OPCHECKGROSS_INT"];
                        m_dgvDetailInfo.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthInsertNewMedicineData();
                }
            }
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            //if (m_btnSave.Enabled)
            //{
            //    if (MessageBox.Show("是否关闭盘点单界面？", "灏瀚系统温馨提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    Close();
            //}
            //else
            //{
            //    Close();
            //}
        }
        
        private void m_mthGetInitialData()
        {
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthGetMedBaseInfo(this.m_strDrugID, ref m_dtbMedicineInfo);
        }
        
        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthGetMedBaseInfo(this.m_strStoreID,ref m_dtbMedicineInfo);
        }

        //internal DateTime m_dtmDateTimeNow = DateTime.MinValue;
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (m_dtmDateTimeNow == DateTime.MinValue)
        //    {
        //        m_dtmDateTimeNow = Convert.ToDateTime(clsPub.SysDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss"));
        //        this.m_datCheck.Value = m_dtmDateTimeNow;
        //    }
        //    else
        //    {
        //        m_dtmDateTimeNow = m_dtmDateTimeNow.AddSeconds(1);
        //        this.m_datCheck.Value = m_dtmDateTimeNow;
        //    }
        //}

        bool blnChecking = false;
        private void m_chkOnlyShowGrossChange_CheckedChanged(object sender, EventArgs e)
        {
            if (blnChecking) return;
            blnChecking = true;
            if (dtbDrugCheck_detail != null)
            {
                string strSubcheck = "";
                if (m_chkOnlyShowGrossChange.Checked)
                {
                    strSubcheck = "CHECKRESULT_INT <> 0";
                }
                if (((CheckBox)sender).Name == "m_chkOnlyShowCURRENTGROSS")
                {
                    m_chkOnlyShowZero.Checked = false;   
                }
                if (((CheckBox)sender).Name == "m_chkOnlyShowZero")
                {
                    m_chkOnlyShowCURRENTGROSS.Checked = false;
                }

                if (m_chkOnlyShowCURRENTGROSS.Checked)
                {
                    if (strSubcheck.Length > 3)
                    {
                        strSubcheck += " and realgross_int <> 0";
                    }
                    else
                    {
                        strSubcheck = "realgross_int <> 0";
                    }                
                }
                
                if (m_chkOnlyShowZero.Checked)
                {
                    if (strSubcheck.Length > 3)
                    {
                        strSubcheck += " and realgross_int = 0";
                    }
                    else
                    {
                        strSubcheck = "realgross_int = 0";
                    }
                }
                if (strSubcheck.Length > 3)
                {
                    if (m_strFilter.Length > 0)
                    {
                        dtbDrugCheck_detail.DefaultView.RowFilter = m_strFilter + " and " + strSubcheck;
                    }
                    else
                    {
                        dtbDrugCheck_detail.DefaultView.RowFilter = strSubcheck;
                    }
                }
                else
                {
                    if (m_strFilter.Length > 0)
                    {
                        dtbDrugCheck_detail.DefaultView.RowFilter = m_strFilter;
                    }
                    else
                    {
                        dtbDrugCheck_detail.DefaultView.RowFilter = string.Empty;
                    }
                }
            }
            blnChecking = false;
        }

        private void m_btnMissMedicine_Click(object sender, EventArgs e)
        {
            frmGetMissStoreCheckMedicine frmMiss = new frmGetMissStoreCheckMedicine(dtbDrugCheck_detail, m_strStoreDeptID);
            frmMiss.m_strStorageID = m_strStoreID;
            frmMiss.m_blnIsHospital = m_blnIsHospital;
            frmMiss.m_intCheckMode = this.m_intCheckMode;
            frmMiss.ShowDialog();

            if (frmMiss.DialogResult == DialogResult.OK)
            {
                DataRow[] drSelectedMiss = frmMiss.m_DrGetSelected;
                if (drSelectedMiss == null || drSelectedMiss.Length == 0)
                {
                    return;
                }
                DataRow[] drSelectedMissDetail = frmMiss.m_DrGetSelectedDetail;
                
                DataTable dtbStorageMedicine = drSelectedMiss[0].Table.Clone();
                DataTable drtStorageMedicineDetail = drSelectedMissDetail[0].Table.Clone();

                dtbStorageMedicine.BeginLoadData();
                for (int iRow = 0; iRow < drSelectedMiss.Length; iRow++)
                {
                    dtbStorageMedicine.LoadDataRow(drSelectedMiss[iRow].ItemArray, true);
                }
                dtbStorageMedicine.EndLoadData();

                drtStorageMedicineDetail.BeginLoadData();
                for (int iRow = 0; iRow < drSelectedMissDetail.Length; iRow++)
                {
                    drtStorageMedicineDetail.LoadDataRow(drSelectedMissDetail[iRow].ItemArray, true);
                }
                drtStorageMedicineDetail.EndLoadData();

                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthMergeDataToUI(dtbStorageMedicine, drtStorageMedicineDetail, false);          
            }
        }

        private void m_btnImpMedicine_Click(object sender, EventArgs e)
        {
            frmGetStoreCheckMedicine frmGet = new frmGetStoreCheckMedicine(m_strStoreDeptID);
            frmGet.m_strStorageID2 = m_strDrugID;
            frmGet.m_blnIsHospital = m_blnIsHospital;
            frmGet.ShowDialog();

            DataTable dtbSearchResult = null;
            DataTable dtbResultDetail = null;
            if (frmGet.DialogResult == DialogResult.OK && frmGet.m_DtbStorageMedicine != null)
            {
                if (m_intCheckMode == 1)
                {
                    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthChangeToTotal(frmGet.m_DtbStorageMedicine, out dtbSearchResult, out dtbResultDetail);
                }
                else
                {
                    DataTable dtbTemp = frmGet.m_DtbStorageMedicine.Copy();
                    DataView dv = dtbTemp.DefaultView;
                    //dv.Sort = "checkmedicineorder_chr,assistcode_chr,medicineid_chr,opretailprice_int,iprealgross_int";
                    dv.Sort = "medicineid_chr,opretailprice_int,iprealgross_int";
                    dtbTemp = dv.ToTable();

                    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthChangeToTotal(dtbTemp, out dtbSearchResult, out dtbResultDetail);

                    //dtbSearchResult = frmGet.m_DtbStorageMedicine;
                }
                if (dtbSearchResult == null || dtbSearchResult.Rows.Count == 0) return;
                ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthMergeDataToUI(dtbSearchResult, dtbResultDetail,true);
            }
        }

        private void m_btnFilterMed_Click(object sender, EventArgs e)
        {
            frmGetStoreCheckMedicine frmGet = new frmGetStoreCheckMedicine(true);
            frmGet.m_strStorageID2 = m_strDrugID;
            frmGet.ShowDialog();

            if (frmGet.DialogResult == DialogResult.OK)
            {
                m_strFilter = frmGet.m_StrSearchCondition;
                if (dtbDrugCheck_detail != null)
                {
                    string strSubcheck = "";
                    if (m_chkOnlyShowGrossChange.Checked)
                    {
                        strSubcheck = "CHECKRESULT_INT <> 0";
                    }
                    if (m_chkOnlyShowCURRENTGROSS.Checked)
                    {
                        if (strSubcheck.Length > 3)
                        {
                            strSubcheck += " and realgross_int <> 0";
                        }
                        else
                        {
                            strSubcheck = "realgross_int <> 0";
                        }
                    }
                    if (m_chkOnlyShowZero.Checked)
                    {
                        if (strSubcheck.Length > 3)
                        {
                            strSubcheck += " and realgross_int = 0";
                        }
                        else
                        {
                            strSubcheck = "realgross_int = 0";
                        }
                    }
                    if (strSubcheck.Length > 3)
                    {
                        if (m_strFilter.Length > 0)
                        {
                            dtbDrugCheck_detail.DefaultView.RowFilter = m_strFilter + " and " + strSubcheck;
                        }
                        else
                        {
                            dtbDrugCheck_detail.DefaultView.RowFilter = strSubcheck;
                        }
                    }
                    else
                    {
                        if (m_strFilter.Length > 0)
                        {
                            dtbDrugCheck_detail.DefaultView.RowFilter = m_strFilter;
                        }
                        else
                        {
                            dtbDrugCheck_detail.DefaultView.RowFilter = string.Empty;
                        }
                    }
                    DataTable dtTemp = dtbDrugCheck_detail.DefaultView.ToTable();
                    m_lblMedicineType.Text = ((clsCtl_DrugStoreCheck_Detail)this.objController).m_strShowMedicineType(dtTemp);
                    dtTemp.Dispose();
                    ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthSetCheckMoney();
                }
                else
                {
                    m_strFilter = "";
                }
            }
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck_Detail)objController).m_mthExportToExcel();
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dtTemp = dtbDrugCheck_detail.DefaultView.ToTable();
            ((clsCtl_DrugStoreCheck_Detail)this.objController).m_mthPrint(dtTemp);
            dtTemp.Dispose(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_datCheck.Value = m_datCheck.Value.AddSeconds(1);
        }

        bool blnClosing = false;
        private void frmDrugStoreCheck_Detail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (blnClosing) return;
            if (m_btnSave.Enabled)
            {
                if (MessageBox.Show("是否关闭盘点单界面？", "灏瀚系统温馨提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    blnClosing = true;
                    Close();
                }
                else
                {
                    e.Cancel = true;
                    blnClosing = false;
                }
            }
        }

        //private void m_dgvDetailInfo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    DataGridViewColumn dgvColumn = this.m_dgvDetailInfo.Columns[e.ColumnIndex];
        //    dgvColumn.Tag = (dgvColumn.Tag == null || (ListSortDirection)dgvColumn.Tag == ListSortDirection.Ascending) ? ListSortDirection.Descending : ListSortDirection.Ascending;
        //    this.m_dgvDetailInfo.Sort(dgvColumn, (ListSortDirection)dgvColumn.Tag);            
        //}
    }
}
