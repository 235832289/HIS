using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ҩ����˳����Ƶ�����
    /// </summary>
    public partial class frmMakeOutStorageOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// �Ƿ�סԺҩ��
        /// </summary>
        internal bool m_blnIsHospital = false;
        /// <summary>
        /// ���캯��
        /// </summary>
        public frmMakeOutStorageOrder()
        {
            InitializeComponent();
            this.m_dgvMedicineOutInfo.AutoGenerateColumns = false;
            m_intDaysToValidDate = Convert.ToInt32(this.objController.m_objComInfo.m_lonGetModuleInfo("5032"));

            ((clsCtl_MakeOutStorageOrder)objController).m_mthInitMedicineTable(ref m_dtbOutMedicine);            
            this.m_dgvMedicineOutInfo.DataSource = m_dtbOutMedicine;
            this.m_bgWorker.RunWorkerAsync();
        }
        /// <summary>
        /// �󶨽��������
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MakeOutStorageOrder();
            objController.Set_GUI_Apperance(this);
        } 
        #region ȫ�ֱ���
        /// <summary>
        /// ��������id
        /// </summary>
        public long m_lngAskSeq = 0;
        /// <summary>
        /// ����ҩƷ��Ϣ
        /// </summary>
        internal DataTable m_dtbOutMedicine = null;
        /// <summary>
        /// ҩƷ�ֵ���Ϣ
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// �����������
        /// </summary>
        internal double dblNetAmount=0;
        /// <summary>
        /// ��������id
        /// </summary>
        public long m_lngMainSEQ = 0;
        /// <summary>
        /// �Ƿ�ֱ�����
        /// </summary>        
        public long m_intCommitFolow = 1;
        /// <summary>
        /// �Ƿ�������������������������쵥�ӱ���Ϣ�Ͷ�Ӧ�ĳ�����ϸ��
        /// </summary>
        internal bool m_blnNew = false;
        /// <summary>
        /// �ֿ�ID
        /// </summary>
        internal string m_strStorageID = string.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        internal DataTable m_dtOutStoreType = null;
        /// <summary>
        /// 'ҩ��ҩƷ��ʧЧ���ض�ʱ������',Ĭ��30����λ����
        /// </summary>
        private int m_intDaysToValidDate = 30;
        #endregion
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMakeOutStorageOrder_Load(object sender, EventArgs e)
        {
            try
            {
                m_datMakeOrder.Value = clsPub.CurrentDateTimeNow;
                timer1.Start();

                this.m_dgvMedicineOutInfo.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                this.m_cboStatus.Enter -= new EventHandler(m_cboStatus_Enter);
                if (m_blnNew)
                {
                    DataTable m_dtRequestDetail = new DataTable();
                    clsDcl_AskForMedicine objDomain = new clsDcl_AskForMedicine();
                    objDomain.m_lngCheckIsHospital(m_txtApplyDept.AccessibleName, out m_blnIsHospital);
                    objDomain.m_lngGetAskDetailInfoByid(m_blnIsHospital, Convert.ToInt64(m_lngAskSeq), out m_dtRequestDetail);
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthLoadMedicineData(m_lngAskSeq, m_dtRequestDetail,ref m_dtbOutMedicine);
                    this.m_mthShowRetailMoney();
                    this.m_cboStatus.Enter += new EventHandler(m_cboStatus_Enter);
                }
                if (m_dtbOutMedicine != null && m_dtbOutMedicine.Rows.Count == 0)
                {
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void m_dgvMedicineOutInfo_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                this.m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }

            for (int iRow = 0; iRow < this.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                this.m_dgvMedicineOutInfo.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (Convert.ToString(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value) == "")
                    continue;
                if (Convert.ToDateTime(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value).Date < m_datMakeOrder.Value.Date)//clsPub.SysDateTimeNow)
                {
                    if (Convert.ToDateTime(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value).ToString("yyyy-MM-dd").Trim() != "0001-01-01")
                    {
                        this.m_dgvMedicineOutInfo.Rows[iRow].DefaultCellStyle.ForeColor = Color.Crimson;
                    }
                }
                else if (Convert.ToDateTime(this.m_dgvMedicineOutInfo.Rows[iRow].Cells["m_dgvtxtEffectData"].Value).AddDays(-m_intDaysToValidDate).Date < m_datMakeOrder.Value.Date)//clsPub.SysDateTimeNow)
                {
                    this.m_dgvMedicineOutInfo.Rows[iRow].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                }

            }
        }

        private void m_dgvMedicineOutInfo_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                this.m_dgvMedicineOutInfo.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("ȷ��ɾ��ѡ�г����¼��", "ҩƷ����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            ((clsCtl_MakeOutStorageOrder)objController).m_mthDeleteDetail();
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
        }

        private void m_txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbOutMedicine.Rows.Count > 0)
                {
                    DataRow drLast = m_dtbOutMedicine.Rows[m_dtbOutMedicine.Rows.Count - 1];
                    if (drLast["MEDICINEID_CHR"] == DBNull.Value && drLast["availagross_int"] == DBNull.Value)
                    {
                        m_dgvMedicineOutInfo.Focus();
                        m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[m_dtbOutMedicine.Rows.Count - 1].Cells[1];
                        m_dgvMedicineOutInfo.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
                }
            }
        }
        internal void m_mthShowRetailMoney()
        {
            DataTable m_dtbDetail = (DataTable)this.m_dgvMedicineOutInfo.DataSource;
            //DataRow[] m_drRow = m_dtbDetail.Select("","",DataViewRowState.Deleted
            if (m_dtbDetail != null && m_dtbDetail.Rows.Count > 0)
            {
                double dblTemp = 0d;
                double dblFormat = 0d;
                for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    if (m_dtbDetail.Rows[i1].RowState == DataRowState.Deleted) continue;
                    double.TryParse(m_dtbDetail.Rows[i1]["retailmoney"].ToString(), out dblFormat);
                    //m_dtbDetail.Rows[i1]["retailmoney"] = dblFormat.ToString("F4");
                    dblTemp += dblFormat;
                }
                m_lblRetailSubMoney.Text = dblTemp.ToString("F4") + "Ԫ";
            }
            else
            {
                m_lblRetailSubMoney.Text = "0.0000Ԫ";
            }
        }

        private void m_dgvMedicineOutInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null)
            {
                return;
            }
            m_dgvMedicineOutInfo.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                if (m_dtbMedicineInfo == null || m_dtbMedicineInfo.Rows.Count == 0)
                {
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthInitMedicineInfo(ref m_dtbMedicineInfo);
                }
                
                ((clsCtl_MakeOutStorageOrder)objController).m_mthShowQueryMedicineForm(strFilter, m_dtbMedicineInfo);                
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 8)
            {
                if (m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"].ToString().Trim() == "")
                {
                    return;
                }
                if (Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"]) != dblNetAmount &&
                    m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["seriesid_int"].ToString() != "")
                {
                    bool bolAdjustrice;
                    DataGridViewRow dgr = m_dgvMedicineOutInfo.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex];
                    ((clsCtl_MakeOutStorageOrder)objController).m_mthGetAdjustrice(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["medicineid_chr"].ToString(),
                        m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["lotno_vchr"].ToString(), m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["instorageid_vchr"].ToString(),
                        Convert.ToDateTime(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["VALIDPERIOD_DAT"]), Convert.ToDouble(m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["CALLPRICE_INT"]), out bolAdjustrice);
                    if (bolAdjustrice)
                    {
                        m_dtbOutMedicine.Rows[m_dgvMedicineOutInfo.CurrentCell.RowIndex]["NETAMOUNT_INT"] = dblNetAmount;
                        MessageBox.Show("��ҩƷ�ѵ���,�����޸ĳ���������", "ҩƷ����", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_dgvMedicineOutInfo.Focus();
                        return;
                    }
                }
                double dblTemp = 0d;
                if (!double.TryParse(CurrentCell.Value.ToString(), out dblTemp))
                {
                    CancelJump = true;
                    return;
                }
                int intRowIndex = CurrentCell.RowIndex;
                long lngRes = ((clsCtl_MakeOutStorageOrder)objController).m_lngShowMedicineSelect(CurrentCell.Value.ToString());
                if (lngRes <= 0)
                {
                    m_dgvMedicineOutInfo.Focus();
                    CurrentCell.Selected = true;
                }
                else
                {                    
                    this.m_mthShowRetailMoney();
                    if (intRowIndex == m_dtbOutMedicine.Rows.Count - 1)
                    {
                        ((clsCtl_MakeOutStorageOrder)objController).m_mthInsertNewMedicineData();
                    }
                    else
                    {
                        m_dgvMedicineOutInfo.CurrentCell = m_dgvMedicineOutInfo.Rows[intRowIndex + 1].Cells[8];
                    }
                }
                CancelJump = true;
            }
        }

        private void m_dgvMedicineOutInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && m_dtbOutMedicine != null)
            {
                double dblAmount = 0d;
                DataRow drCurrent = ((DataRowView)(m_dgvMedicineOutInfo.Rows[e.RowIndex].DataBoundItem)).Row;
                if (double.TryParse(drCurrent["NETAMOUNT_INT"].ToString(), out dblAmount))
                {
                    if(dblAmount != 0)
                        drCurrent.EndEdit();
                }
            }
        }

        private void m_bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
          //  clsPub.m_mthGetMedBaseInfo(this.m_obj,out this.m_dtbMedicineInfo);
            clsPub.m_lngGetTypeCode(1, out this.m_dtOutStoreType);
        }

        private void m_dgvMedicineOutInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_btnStorageExam_Click(object sender, EventArgs e)
        {
            m_dgvMedicineOutInfo.EndEdit();
            this.m_mthShowRetailMoney();
            DialogResult drResult = MessageBox.Show("��ҩƷ���ⵥһ����˽������޸�,�Ƿ�������", "ҩƷ������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                long lngRes = ((clsCtl_MakeOutStorageOrder)objController).m_lngSaveOutStorageInfo(true);
                if (lngRes > 0)
                {
                    timer1.Stop();
                     drResult = MessageBox.Show("�Ƿ��ӡ��ǰ�����¼?", "ҩƷ����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.Yes)
                    {
                        ((clsCtl_MakeOutStorageOrder)objController).m_mthPrintDirect();
                    }

                }
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtOutStorageBillNo.Text))
            {
                MessageBox.Show("���ȱ��浥��", "ҩƷ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //((clsCtl_MakeOutStorageOrder)objController).m_mthPrintPreview();
            ((clsCtl_MakeOutStorageOrder)objController).m_purchasePrint(1);
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            if (m_txtOutStorageBillNo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("���ȱ��浥��", "ҩƷ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_MakeOutStorageOrder)objController).m_mthExportToExcel();
        }

        private void m_cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_txtComment.Focus();
            }
        }

        private void m_cboStatus_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
        }

        private void m_cboStatus_Leave(object sender, EventArgs e)
        {
            this.m_cboStatus.Enter -= new EventHandler(m_cboStatus_Enter);
        }

        private void m_cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_cboStatus.AccessibleName = m_cboStatus.SelectItemValue != string.Empty ? m_cboStatus.SelectItemValue : m_cboStatus.AccessibleName;
        }

        private void m_bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_cboStatus.Items.Clear();
            if (this.m_dtOutStoreType != null)
            {
                for (int i = 0; i < this.m_dtOutStoreType.Rows.Count; i++)
                {
                    this.m_cboStatus.Item.Add(m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            m_cboStatus.Text = "��ҩ����";//��Ժ�Ƿ��ų���
            int m_intType;
            ((clsCtl_MakeOutStorageOrder)objController).m_lngGetTypeCodeByName(out m_intType); 
            m_cboStatus.AccessibleName = m_intType.ToString();
        }

        private void m_dgvMedicineOutInfo_DataSourceChanged(object sender, EventArgs e)
        {
            this.m_mthShowRetailMoney();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_datMakeOrder.Value = m_datMakeOrder.Value.AddSeconds(1);
        }

    }
}