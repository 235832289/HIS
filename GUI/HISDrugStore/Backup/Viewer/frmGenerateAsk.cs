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
    /// 自动生成请领单
    /// </summary>
    public partial class frmGenerateAsk : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        DataTable m_dtbLimit = new DataTable();
        /// <summary>
        /// 药房ID
        /// </summary>
        internal string m_strStorageid;
        /// <summary>
        /// 是否住院单位
        /// </summary>
        internal bool m_blnIsHospital;
        /// <summary>
        /// 获取生成请领数量方法。0默认：请领量=消耗量、排序=消耗量-库存量。1：请领量=消耗量-库存量、排序=消耗量/库存量
        /// </summary>
        internal int m_intGetRequestAmount = 0;
        #region 窗体初始化
        public frmGenerateAsk()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_GenerateAsk();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 设置DataGridView的列属性
        internal void m_mthInitDataTable()
        {
            m_dgvDrugStorage.Columns.Clear();

            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            column.Name = "IfCheck";
            column.HeaderText = "";
            column.TrueValue = "T";
            column.FalseValue = "F";
            m_dgvDrugStorage.Columns.Add(column);
            m_dgvDrugStorage.Columns[0].Width = 20;
            m_dgvDrugStorage.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[0].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            m_dgvDrugStorage.Columns[0].Frozen = true;

            m_dgvDrugStorage.Columns.Add("assistcode_chr", "药品代码");
            m_dgvDrugStorage.Columns[1].Width = 80;
            m_dgvDrugStorage.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("medicineid_chr", "药品ID");
            m_dgvDrugStorage.Columns[2].Width = 82;
            m_dgvDrugStorage.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[2].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[2].Visible = false;

            m_dgvDrugStorage.Columns.Add("medicinename_vchr", "药品名称");
            m_dgvDrugStorage.Columns[3].Width = 190;
            m_dgvDrugStorage.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[3].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("medspec_vchr", "规格");
            m_dgvDrugStorage.Columns[4].Width = 100;
            m_dgvDrugStorage.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[4].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("productorid_chr", "生产厂家");
            m_dgvDrugStorage.Columns[5].Width = 100;
            m_dgvDrugStorage.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[5].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[5].Visible = false;

            m_dgvDrugStorage.Columns.Add("requestamount_int", "请领数量");
            m_dgvDrugStorage.Columns[6].Width = 80;
            m_dgvDrugStorage.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[6].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[6].DefaultCellStyle.Format = "0.00";

            m_dgvDrugStorage.Columns.Add("requestunit_chr", "请领单位");
            m_dgvDrugStorage.Columns[7].Width = 70;
            m_dgvDrugStorage.Columns[7].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[7].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("currentgross_num", "库存量");
            m_dgvDrugStorage.Columns[8].Width = 80;
            m_dgvDrugStorage.Columns[8].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[8].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[8].DefaultCellStyle.Format = "0.00";

            m_dgvDrugStorage.Columns.Add("opamount_int", "包装数量");
            m_dgvDrugStorage.Columns[9].Width = 80;
            m_dgvDrugStorage.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[9].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[9].DefaultCellStyle.Format = "0.00";
            m_dgvDrugStorage.Columns[9].Visible = false;

            m_dgvDrugStorage.Columns.Add("opunit_chr", "包装单位");
            m_dgvDrugStorage.Columns[10].Width = 70;
            m_dgvDrugStorage.Columns[10].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[10].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[10].Visible = false;

            if (m_blnIsHospital)
            {
                m_dgvDrugStorage.Columns.Add("amount_int", "住院数量");
            }
            else
            {
                m_dgvDrugStorage.Columns.Add("amount_int", "门诊数量");
            }
            m_dgvDrugStorage.Columns[11].Width = 80;
            m_dgvDrugStorage.Columns[11].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[11].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[11].DefaultCellStyle.Format = "0.00";
            m_dgvDrugStorage.Columns[11].Visible = false;

            if (m_blnIsHospital)
            {
                m_dgvDrugStorage.Columns.Add("useamount_int", "住院消耗量");
            }
            else
            {
                m_dgvDrugStorage.Columns.Add("useamount_int", "门诊消耗量");
            }
            m_dgvDrugStorage.Columns[12].Width = 100;
            m_dgvDrugStorage.Columns[12].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[12].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[12].DefaultCellStyle.Format = "0.00";


            if (m_blnIsHospital)
            {
                m_dgvDrugStorage.Columns.Add("unit_chr", "住院单位");
            }
            else
            {
                m_dgvDrugStorage.Columns.Add("unit_chr", "门诊单位");
            }
            
            m_dgvDrugStorage.Columns[13].Width = 70;
            m_dgvDrugStorage.Columns[13].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[13].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("ipamount_int", "数量(最小)");
            m_dgvDrugStorage.Columns[14].Width = 130;
            m_dgvDrugStorage.Columns[14].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[14].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[14].DefaultCellStyle.Format = "0.00";
            m_dgvDrugStorage.Columns[14].Visible = false;

            m_dgvDrugStorage.Columns.Add("ipunit_chr", "最小单位");
            m_dgvDrugStorage.Columns[15].Width = 78;
            m_dgvDrugStorage.Columns[15].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[15].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[15].Visible = false;

            m_dgvDrugStorage.Columns.Add("packqty_dec", "包装量");
            m_dgvDrugStorage.Columns[16].Width = 80;
            m_dgvDrugStorage.Columns[16].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[16].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("opchargeflg_int", "门诊单位值");
            m_dgvDrugStorage.Columns[17].Width = 110;
            m_dgvDrugStorage.Columns[17].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[17].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[17].Visible = false;

            m_dgvDrugStorage.Columns.Add("askdate_dat", "最近请领时间");
            m_dgvDrugStorage.Columns[18].Width = 130;
            m_dgvDrugStorage.Columns[18].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[18].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            //m_dgvDrugStorage.Columns[16].Visible = false;

            m_dgvDrugStorage.Columns.Add("requestpackqty_dec", "请领包装量");
            m_dgvDrugStorage.Columns[19].Width = 80;
            m_dgvDrugStorage.Columns[19].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[19].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[19].Visible = false;

            m_dgvDrugStorage.Columns.Add("ipchargeflg_int", "住院单位值");
            m_dgvDrugStorage.Columns[20].Width = 110;
            m_dgvDrugStorage.Columns[20].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[20].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[20].Visible = false;

            for (int i1 = 1; i1 < m_dgvDrugStorage.ColumnCount; i1++)
            {
                m_dgvDrugStorage.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;                
                if(i1 != 6)
                    m_dgvDrugStorage.Columns[i1].ReadOnly = true;
            }

            m_dgvDrugStorage.Columns[0].DataPropertyName = "IfCheck";
            m_dgvDrugStorage.Columns[1].DataPropertyName = "assistcode_chr";
            m_dgvDrugStorage.Columns[2].DataPropertyName = "medicineid_chr";
            m_dgvDrugStorage.Columns[3].DataPropertyName = "medicinename_vchr";
            m_dgvDrugStorage.Columns[4].DataPropertyName = "medspec_vchr";
            m_dgvDrugStorage.Columns[5].DataPropertyName = "productorid_chr";
            m_dgvDrugStorage.Columns[6].DataPropertyName = "requestamount_int";
            m_dgvDrugStorage.Columns[7].DataPropertyName = "requestunit_chr";
            m_dgvDrugStorage.Columns[8].DataPropertyName = "currentgross_num";
            m_dgvDrugStorage.Columns[9].DataPropertyName = "opamount_int";
            m_dgvDrugStorage.Columns[10].DataPropertyName = "opunit_chr";
            m_dgvDrugStorage.Columns[11].DataPropertyName = "amount_int";
            m_dgvDrugStorage.Columns[12].DataPropertyName = "useamount_int";            
            m_dgvDrugStorage.Columns[13].DataPropertyName = "unit_chr";
            m_dgvDrugStorage.Columns[14].DataPropertyName = "ipamount_int";
            m_dgvDrugStorage.Columns[15].DataPropertyName = "ipunit_chr";
            m_dgvDrugStorage.Columns[16].DataPropertyName = "packqty_dec";
            m_dgvDrugStorage.Columns[17].DataPropertyName = "opchargeflg_int";
            m_dgvDrugStorage.Columns[18].DataPropertyName = "askdate_dat";
            m_dgvDrugStorage.Columns[19].DataPropertyName = "requestpackqty_dec";
            m_dgvDrugStorage.Columns[20].DataPropertyName = "ipchargeflg_int";
        }
        #endregion

        #region 窗体事件
        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                //if (m_rbtAmount.Checked)
                //{                    
                //    ((clsCtl_GenerateAsk)objController).m_mthGetNeapData(ref m_dtbLimit);
                //    if (m_dtbLimit != null && m_dtbLimit.Rows.Count > 0)
                //    {
                //        DataView dv = m_dtbLimit.DefaultView;
                //        dv.RowFilter = "Isnull(realgross_int,0) < neaplimit_int";
                //        if (txtTypecode.Text != "全部" && txtTypecode.Text != "")
                //        {
                //            dv.RowFilter += " and medicinetypeid_chr = '" + txtTypecode.Value + "'";
                //        }
                //        dv.Sort = "assistcode_chr,medicineid_chr";
                //        m_dtbLimit = dv.ToTable();
                //    }
                //    m_dgvDrugStorage.DataSource = m_dtbLimit;
                //    this.m_lblSelected.Text = "全选";
                //}
                //else
                //{
                iCare.gui.HIS.clsPublic.PlayAvi("正在统计信息，请稍候...");
                    ((clsCtl_GenerateAsk)objController).m_mthQuery();
                    this.m_lblSelected.Text = "反选";
                    m_lblSelected_Click(null, null);                    
                //}
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "查询出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                iCare.gui.HIS.clsPublic.CloseAvi();
                this.Cursor = Cursors.Default;                
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            //((clsCtl_GenerateAsk)objController).m_mthPrint();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_btnGenerate_Click(object sender, EventArgs e)
        {
            m_dgvDrugStorage.CurrentCell = null;
            //m_dgvDrugStorage.CommitEdit(DataGridViewDataErrorContexts.Formatting);
            ((clsCtl_GenerateAsk)objController).m_mthGenerate();
        }

        private void frmGenerateAsk_Load(object sender, EventArgs e)
        {
            DateTime m_dtmNow = clsPub.CurrentDateTimeNow;
            m_datEndDate.Text = m_dtmNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            m_datBeginDate.Text = m_dtmNow.AddMonths(-1).ToString("yyyy年MM月dd日 HH:mm:ss"); ;
            

            this.m_dgvDrugStorage.AutoGenerateColumns = false;
            ((clsCtl_GenerateAsk)objController).m_mthShowStorage();
            this.m_datBeginDate.Focus();
            m_mthInitDataTable();
            ((clsCtl_GenerateAsk)objController).m_mthInitialType();

            ((clsCtl_GenerateAsk)objController).m_lngGetRequestAmount(out m_intGetRequestAmount);
            
            if (m_blnIsHospital)
            {
                //m_datBeginDate.Visible = false;
                //m_datEndDate.Visible = false;
                //lblAbateEndDate.Visible = false;
                //lblAbateBeginDate.Text = "说明：住院药房的自动请领量为库存量少于最低限量的最高限量值。";
                //lblAbateBeginDate.ForeColor = Color.Blue;
                
                //20081229:注释以下两行
                //m_cbLimit.Checked = true;
                //m_cbLimit.Enabled = false;
            }
        }

        private void m_lblSelected_Click(object sender, EventArgs e)
        {
            if (this.m_dgvDrugStorage.Rows.Count > 0)
            {
                this.m_dgvDrugStorage.CurrentCell = this.m_dgvDrugStorage.Rows[0].Cells[1];
                if (this.m_lblSelected.Text == "全选")
                {
                    m_lblSelected.Text = "反选";
                    for (int iRow = 0; iRow < m_dgvDrugStorage.Rows.Count; iRow++)
                    {
                        m_dgvDrugStorage.Rows[iRow].Cells[0].Value = "T";
                    }
                }
                else if (m_lblSelected.Text == "反选")
                {
                    m_lblSelected.Text = "全选";
                    for (int iRow = 0; iRow < m_dgvDrugStorage.Rows.Count; iRow++)
                    {
                        m_dgvDrugStorage.Rows[iRow].Cells[0].Value = "F";
                    }
                }
            }            
        }

        private void m_lblSelected_MouseEnter(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = Color.Maroon;
            this.Cursor = Cursors.Hand;
        }

        private void m_lblSelected_MouseLeave(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = SystemColors.MenuHighlight;
            this.Cursor = Cursors.Default;
        }
        #endregion


        private void m_cboStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //m_btnQuery.PerformClick();
        }

        /// <summary>
        /// 根据参数设置显示窗体
        /// </summary>
        /// <param name="p_strStorageid">p_strStorageid等于0000时，不区分药房</param>
        public void m_mthSetShow(string p_strStorageid)
        {
            if (p_strStorageid == "0000")
            {
                this.Show();
            }
            else
            {
                m_strStorageid = p_strStorageid;
                clsMedStore_VO objReturnVo = clsPub.m_mthGetMedStoreNameByid(p_strStorageid);
                if (objReturnVo == null)
                {
                    MessageBox.Show("设置的药房id不正确！");
                    return;
                }
                else
                {
                    if (objReturnVo.m_strDeptid == string.Empty)
                    {
                        MessageBox.Show(objReturnVo.m_strMedStoreName + "没有绑定领药部门,请先绑定药房部门！");
                        return;
                    }
                }
                this.Tag = objReturnVo.m_strDeptid;
                this.AccessibleName = objReturnVo.m_strDeptName;
                this.Text = string.Format("{0}自动生成请领单", objReturnVo.m_strMedStoreName);

                ((clsCtl_GenerateAsk)this.objController).m_lngCheckIsHospital(m_strStorageid, out m_blnIsHospital);

                this.Show();
            }
        }

        private void m_dgvDrugStorage_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                Color clrTemp = Color.Black;
                for (int iRow = 0; iRow < this.m_dgvDrugStorage.Rows.Count; iRow++)
                {
                    if (Convert.ToString(m_dgvDrugStorage.Rows[iRow].Cells["askdate_dat"].Value) == "")
                    {
                        m_dgvDrugStorage.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else
                    {
                        if (Convert.ToDateTime(m_dgvDrugStorage.Rows[iRow].Cells["askdate_dat"].Value).AddMonths(1) < DateTime.Now)
                            m_dgvDrugStorage.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                        else
                            m_dgvDrugStorage.Rows[iRow].DefaultCellStyle.ForeColor = Color.Red;
                    }
                    clrTemp = m_dgvDrugStorage.Rows[iRow].DefaultCellStyle.ForeColor;
                    if (Convert.ToString(m_dgvDrugStorage.Rows[iRow].Cells["requestunit_chr"].Value) != Convert.ToString(m_dgvDrugStorage.Rows[iRow].Cells["opunit_chr"].Value))
                    {
                        m_dgvDrugStorage.Rows[iRow].Cells["requestunit_chr"].Style.ForeColor = Color.Blue;
                        m_dgvDrugStorage.Rows[iRow].Cells["requestamount_int"].Style.ForeColor = Color.Blue;
                    }
                    else
                    {
                        m_dgvDrugStorage.Rows[iRow].Cells["requestunit_chr"].Style.ForeColor = clrTemp;
                        m_dgvDrugStorage.Rows[iRow].Cells["requestamount_int"].Style.ForeColor = clrTemp;
                    }
                }
            }
            catch
            {
                m_dgvDrugStorage.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void m_dgvDrugStorage_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double dblRequestAmount = 0;
            if (double.TryParse(Convert.ToString(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestamount_int"].Value), out dblRequestAmount))
            {
                dblRequestAmount = Convert.ToDouble(dblRequestAmount.ToString("F2"));
                if (m_blnIsHospital)
                {
                    if (Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["ipchargeflg_int"].Value) == 0)
                    {
                        m_dgvDrugStorage.Rows[e.RowIndex].Cells["amount_int"].Value = dblRequestAmount * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value);
                    }
                    else
                    {
                        m_dgvDrugStorage.Rows[e.RowIndex].Cells["amount_int"].Value = dblRequestAmount * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value) * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["packqty_dec"].Value);
                    }
                }
                else
                {
                    if (Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["opchargeflg_int"].Value) == 0)
                    {
                        m_dgvDrugStorage.Rows[e.RowIndex].Cells["amount_int"].Value = dblRequestAmount * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value);
                    }
                    else
                    {
                        m_dgvDrugStorage.Rows[e.RowIndex].Cells["amount_int"].Value = dblRequestAmount * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value) * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["packqty_dec"].Value);
                    }
                }
                m_dgvDrugStorage.Rows[e.RowIndex].Cells["opamount_int"].Value = dblRequestAmount * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value);
                m_dgvDrugStorage.Rows[e.RowIndex].Cells["ipamount_int"].Value = dblRequestAmount * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["requestpackqty_dec"].Value) * Convert.ToDouble(m_dgvDrugStorage.Rows[e.RowIndex].Cells["packqty_dec"].Value);
            }
        }

        private void m_dgvDrugStorage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_dgvDrugStorage_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                m_dgvDrugStorage.BeginEdit(true);
            }
        }

        private void m_cbLimit_CheckedChanged(object sender, EventArgs e)
        {
            //m_dgvDrugStorage.DataSource = null;
            //m_dgvDrugStorage.Refresh();
        }

        private void frmGenerateAsk_Shown(object sender, EventArgs e)
        {            
            SendKeys.SendWait("{TAB}");
            txtTypecode.Text = "全部";
        }
    }
}