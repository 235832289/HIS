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
    /// ҩ������ʼ��
    /// </summary>
    public partial class frmInitialDS : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// ҩ��ID
        /// </summary>
        internal string m_strDrugStoreID = string.Empty;
        /// <summary>
        /// ҩ������ʼ��ҩƷ��Ϣ
        /// </summary>
        internal DataTable m_dtbMedicineDetail = null;
        /// <summary>
        /// ��ǰ������ʾҩƷ����
        /// </summary>
        internal DataView m_dtvCurrentView = null;
        /// <summary>
        /// ҩƷ�ֵ�
        /// </summary>
        internal DataTable m_dtbMedicineDict = null;
        /// <summary>
        /// ��ҩ���Ӧ�Ĳ��ź�
        /// </summary>
        internal string m_strDeptID = string.Empty;
        /// <summary>
        /// �Ƿ񱣴漴���
        /// </summary>
        internal bool m_blnIsImmAccount = false;
        /// <summary>
        /// �Ƿ�סԺ��λ
        /// </summary>
        internal bool m_blnIsHospital;
        /// <summary>
        /// ҩ������ʼ��
        /// </summary>
        public frmInitialDS()
        {
            InitializeComponent();

            m_dtgvMedicineDetail.AutoGenerateColumns = false;
            m_cboCommitInfo.SelectedIndex = 0;
        }


        /// <summary>
        /// ����ҵ�������
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_InitialDS();
            objController.Set_GUI_Apperance(this);
        }

        #region ��ȡ��¼��ҩƷ��Ϣ

        /// <summary>
        /// ��ȡ��¼��ҩƷ��Ϣ
        /// </summary>
        private void m_mthGetMedicineDetail()
        {
            ((clsCtl_InitialDS)objController).m_mthGetInitilaMedicine(m_strDeptID, out m_dtbMedicineDetail);

            if (m_dtbMedicineDetail == null || m_dtbMedicineDetail.Columns.Count == 0)
            {
                ((clsCtl_InitialDS)objController).m_mthInitMedicineTalbe(ref m_dtbMedicineDetail);
            }
            else
            {
                if (!m_dtbMedicineDetail.Columns.Contains("status"))
                {
                    m_dtbMedicineDetail.Columns.Add("status");
                }
            }

            if (m_dtbMedicineDetail != null && m_dtbMedicineDetail.Rows.Count > 0)
            {
                int intRowsCount = m_dtbMedicineDetail.Rows.Count;
                DataRow drCurrent = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drCurrent = m_dtbMedicineDetail.Rows[iRow];
                    if (drCurrent["INACCOUNTERID_CHR"] == DBNull.Value)//������ID
                    {
                        if (drCurrent["EXAMERID"] == DBNull.Value)//�����ID
                        {
                            drCurrent["status"] = "δ���";
                        }
                        else
                        {
                            drCurrent["status"] = "�����";
                        }
                    }
                    else
                    {
                        drCurrent["status"] = "������";
                    }
                }
                m_dtbMedicineDetail.AcceptChanges();
            }
        }
        #endregion

        /// <summary>
        /// ���ⲿ���ã���ʾ������
        /// </summary>
        /// <param name="p_strDrugStoreID">ҩ��ID</param>
        public void ShowThis(string p_strDrugStoreID)
        {
            m_strDrugStoreID = p_strDrugStoreID;
            string m_strFormCaption = string.Empty;
            ((clsCtl_InitialDS)objController).m_mthGetStoreInfo(m_strDrugStoreID, out m_strFormCaption,out m_strDeptID);
            ((clsCtl_InitialDS)objController).m_lngCheckIsHospital(m_strDrugStoreID, out m_blnIsHospital);
            this.Text = m_strFormCaption + "����ʼ��";
            this.Show();

            m_pnlWaiting.Visible = true;
            m_mthSetUICannotEdit();
            //this.m_mthGetInitialData();
            m_bgwGetMedicineDetail.RunWorkerAsync();
        }

        #region ɾ��ѡ����ҩƷ

        /// <summary>
        /// ɾ��ѡ����ҩƷ
        /// </summary>
        private void m_mthDeleteSelecedMedicine()
        {
            if (m_dtgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_dtgvMedicineDetail.SelectedCells[0].RowIndex;
            DataRowView drSelected = m_dtvCurrentView[intRowIndex];

            if (drSelected["SERIESID_INT"] == DBNull.Value)//δ��������ݿ������
            {
                if (intRowIndex == m_dtgvMedicineDetail.Rows.Count - 1 && intRowIndex - 1 >= 0)
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex - 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                else if (intRowIndex + 1 < m_dtgvMedicineDetail.Rows.Count)
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex + 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                m_dtvCurrentView.Delete(intRowIndex);
            }
            else if (((clsCtl_InitialDS)objController).m_lngDeleteMedicineInitial(Convert.ToInt64(drSelected["SERIESID_INT"])) > 0)//�ѱ�������ݿ������
            {
                if (intRowIndex == m_dtgvMedicineDetail.Rows.Count - 1 && intRowIndex - 1 >= 0)
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex - 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                else if (intRowIndex + 1 < m_dtgvMedicineDetail.Rows.Count)
                {
                    m_dtgvMedicineDetail.Focus();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[intRowIndex + 1].Cells[0];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
                m_dtvCurrentView.Delete(intRowIndex);

                if (m_dtgvMedicineDetail.Rows.Count == 0)
                {
                    ((clsCtl_InitialDS)objController).m_mthInsertNewMedicine();
                }
            }
        }
        #endregion

        #region ˢ����¼��ҩƷ��Ϣ

        /// <summary>
        /// ˢ����¼��ҩƷ��Ϣ
        /// </summary>
        private void m_mthRefreshMedicineDetail()
        {
            m_pnlWaiting.Visible = true;

            m_txtCommitMan.Text = string.Empty;
            m_txtInputMan.Text = string.Empty;
            m_txtMedName.Text = string.Empty;
            m_cboCommitInfo.SelectedIndex = 0;

            m_mthSetUICannotEdit();
            m_mthGetMedicineDetail();
            m_dtvCurrentView = new DataView(m_dtbMedicineDetail);
            m_dtgvMedicineDetail.DataSource = m_dtvCurrentView;
            if (m_dtgvMedicineDetail.RowCount > 0)
            {
                m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[0, m_dtgvMedicineDetail.RowCount - 1];
            }
            m_mthSetUICanEdit();
            m_pnlWaiting.Visible = false;
            ((clsCtl_InitialDS)this.objController).m_mthSetTotalMoney();
        }
        #endregion

        #region ʹ���治�ɱ༭

        /// <summary>
        /// ʹ���治�ɱ༭
        /// </summary>
        private void m_mthSetUICannotEdit()
        {
            m_btnNew.Enabled = false;
            m_btnSave.Enabled = false;
            m_btnRefresh.Enabled = false;
            m_btnDelete.Enabled = false;
            m_btnExam.Enabled = false;
            m_btnAccount.Enabled = false;
            m_btnUnExam.Enabled = false;
        }
        #endregion

        #region ʹ����ɱ༭
        /// <summary>
        /// ʹ����ɱ༭
        /// </summary>
        private void m_mthSetUICanEdit()
        {
            m_btnNew.Enabled = true;
            m_btnSave.Enabled = true;
            m_btnRefresh.Enabled = true;
            m_btnDelete.Enabled = true;
            m_btnExam.Enabled = true;
            m_btnAccount.Enabled = true;
            m_btnUnExam.Enabled = true;
        }
        #endregion

        private void m_dtgvMedicineDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dtgvMedicineDetail.Rows.Count; iRow++)
            {
                m_dtgvMedicineDetail.Rows[iRow].Cells[0].Value = iRow + 1;

                if (m_dtgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtStatus"].Value.ToString() == "δ���"
                    || m_dtgvMedicineDetail.Rows[iRow].Cells["m_dgvtxtStatus"].Value.ToString() == "")
                {
                    m_dtgvMedicineDetail.Rows[iRow].DefaultCellStyle.BackColor = SystemColors.Info;
                    m_dtgvMedicineDetail.Rows[iRow].ReadOnly = false;
                }
                else
                {
                    m_dtgvMedicineDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.LightGray;
                    m_dtgvMedicineDetail.Rows[iRow].ReadOnly = true;
                }
            }
        }

        private void m_dtgvMedicineDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dtgvMedicineDetail.Rows.Count; iRow++)
            {
                m_dtgvMedicineDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dtgvMedicineDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;

            if (!m_dtgvMedicineDetail.EndEdit())
            {
                return;
            }
            DataRowView drvCurrent;
            double dblPack = 0d;//��װ��
            double dblAmount = 0d;//���������ۼۡ������
            string strValue = string.Empty;
            if (CurrentCell.Value != null)
            {
                strValue = CurrentCell.Value.ToString();
            }

            if (CurrentCell.ColumnIndex == 1)
            {
                CancelJump = true;
                if (this.m_dtbMedicineDict == null || this.m_dtbMedicineDict.Rows.Count == 0)
                {
                    ((clsCtl_InitialDS)objController).m_mthInitMedicineInfo(m_strDrugStoreID, ref m_dtbMedicineDict);
                }
                ((clsCtl_InitialDS)objController).m_mthShowQueryMedicineForm(strValue, m_dtbMedicineDict);
            }
            else if (CurrentCell.ColumnIndex == m_dtgvMedicineDetail.Columns["amount"].Index)
            {
                CancelJump = true;                
                if (double.TryParse(strValue, out dblAmount))
                {
                    drvCurrent = m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].DataBoundItem as DataRowView;
                    
                    if (drvCurrent != null && double.TryParse(drvCurrent["PACKQTY_DEC"].ToString(), out dblPack))
                    {
                        if (m_blnIsHospital)
                        {
                            if (Convert.ToInt16(drvCurrent["ipchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount;
                                drvCurrent["IPAMOUNT"] = dblAmount * dblPack;
                            }
                            else
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount / dblPack;
                                drvCurrent["IPAMOUNT"] = dblAmount;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount;
                                drvCurrent["IPAMOUNT"] = dblAmount * dblPack;
                            }
                            else
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount / dblPack;
                                drvCurrent["IPAMOUNT"] = dblAmount;
                            }
                        }
                    }
                    
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].Cells["retailprice_int"];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                    //((clsCtl_InitialDS)this.objController).m_mthSetTotalMoney();
                }                
            }
            else if (CurrentCell.ColumnIndex == m_dtgvMedicineDetail.Columns["retailprice_int"].Index)
            {
                CancelJump = true;
                if (double.TryParse(strValue, out dblAmount))
                {
                    drvCurrent = m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].DataBoundItem as DataRowView;
                    if (drvCurrent != null && double.TryParse(drvCurrent["PACKQTY_DEC"].ToString(), out dblPack))
                    {
                        if (m_blnIsHospital)
                        {
                            if (Convert.ToInt16(drvCurrent["ipchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["opretailprice_int"] = dblAmount;
                                drvCurrent["ipretailprice_int"] = dblAmount / dblPack;
                            }
                            else
                            {
                                drvCurrent["opretailprice_int"] = dblAmount * dblPack;
                                drvCurrent["ipretailprice_int"] = dblAmount;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["opretailprice_int"] = dblAmount;
                                drvCurrent["ipretailprice_int"] = dblAmount / dblPack;
                            }
                            else
                            {
                                drvCurrent["opretailprice_int"] = dblAmount * dblPack;
                                drvCurrent["ipretailprice_int"] = dblAmount;
                            }
                        }
                    }
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].Cells["wholesaleprice_int"];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }  
            }
            else if (CurrentCell.ColumnIndex == m_dtgvMedicineDetail.Columns["wholesaleprice_int"].Index)
            {
                CancelJump = true;
                if (double.TryParse(strValue, out dblAmount))
                {
                    drvCurrent = m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].DataBoundItem as DataRowView;
                    if (drvCurrent != null && double.TryParse(drvCurrent["PACKQTY_DEC"].ToString(), out dblPack))
                    {
                        if (m_blnIsHospital)
                        {
                            if (Convert.ToInt16(drvCurrent["ipchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["opwholesaleprice_int"] = dblAmount;
                                drvCurrent["ipwholesaleprice_int"] = dblAmount / dblPack;
                            }
                            else
                            {
                                drvCurrent["opwholesaleprice_int"] = dblAmount * dblPack;
                                drvCurrent["ipwholesaleprice_int"] = dblAmount;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["opwholesaleprice_int"] = dblAmount;
                                drvCurrent["ipwholesaleprice_int"] = dblAmount / dblPack;
                            }
                            else
                            {
                                drvCurrent["opwholesaleprice_int"] = dblAmount * dblPack;
                                drvCurrent["ipwholesaleprice_int"] = dblAmount;
                            }
                        }
                        
                    }
                }
                m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].Cells["m_dgvtxtLOTNO_VCHR"];
                m_dtgvMedicineDetail.CurrentCell.Selected = true;
            }
            else if (CurrentCell.ColumnIndex == m_dtgvMedicineDetail.Columns["m_dgvtxtValidity"].Index)//m_dgvtxtStatus
            {
                CancelJump = true;
                if (CurrentCell.RowIndex == m_dtgvMedicineDetail.Rows.Count - 1)
                {
                    ((clsCtl_InitialDS)objController).m_mthInsertNewMedicine();
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[0, m_dtgvMedicineDetail.RowCount - 1];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;       
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[1, m_dtgvMedicineDetail.RowCount - 1];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;                    
                }
                else
                {
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[0, CurrentCell.RowIndex + 1];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;  
                    m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[1, CurrentCell.RowIndex + 1];
                    m_dtgvMedicineDetail.CurrentCell.Selected = true;
                }
            }
            //Ӧ�Զ�������
        }

        private void m_dtgvMedicineDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            this.m_txtMedName.Clear();
            ((clsCtl_InitialDS)objController).m_mthInsertNewMedicine();
        }
        private void m_mthGetInitialData()
        {
            m_mthGetMedicineDetail();

          
        }
        private void m_bgwGetMedicineDetail_DoWork(object sender, DoWorkEventArgs e)
        {
            m_mthGetMedicineDetail();
        }

        private void m_bgwGetMedicineDetail_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_dtvCurrentView = new DataView(m_dtbMedicineDetail);
            m_dtgvMedicineDetail.DataSource = m_dtvCurrentView;

            ((clsCtl_InitialDS)this.objController).m_mthSetTotalMoney();

            if (m_dtvCurrentView != null && m_dtvCurrentView.Count == 0)
            {
                ((clsCtl_InitialDS)objController).m_mthInsertNewMedicine();
            }

            if (m_dtgvMedicineDetail.RowCount > 0)
            {
                m_dtgvMedicineDetail.Focus();
                m_dtgvMedicineDetail.CurrentCell = m_dtgvMedicineDetail[1, m_dtgvMedicineDetail.RowCount - 1];
                m_dtgvMedicineDetail.CurrentCell.Selected = true;
            }

            m_pnlWaiting.Visible = false;
            m_mthSetUICanEdit();

            Application.DoEvents();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (m_dtgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            if (m_dtgvMedicineDetail.Rows[m_dtgvMedicineDetail.SelectedCells[0].RowIndex].ReadOnly)
            {
                MessageBox.Show("������������ˣ�����ɾ��", "����ʼ��", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult drResult = MessageBox.Show("�Ƿ�ɾ��ѡ���У�", "����ʼ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                m_mthDeleteSelecedMedicine();
            }
        }        

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_dtgvMedicineDetail.EndEdit();
            m_txtInputMan.Focus();//��DataView�������ύ��DataTable
            ((clsCtl_InitialDS)objController).m_lngSaveMedicineInfo(false);
        }

        private void m_btnExam_Click(object sender, EventArgs e)
        {
            DialogResult drResult = MessageBox.Show("�Ƿ������ˣ�", "����ʼ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    m_mthCommitMedicineDetail();
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }     
        }

        #region ���ҩƷ��Ϣ
        /// <summary>
        /// ���ҩƷ��Ϣ
        /// </summary>
        private void m_mthCommitMedicineDetail()
        {
            long lngRes = m_lngSaveMedicineInfo(true);
            
            if (lngRes < 0)
            {
                return;
            }

            DataView dtbSource = m_dtgvMedicineDetail.DataSource as DataView;
            DataTable dtbTemp = dtbSource.Table;

            m_pnlWaiting.Visible = true;
            this.label14.Text = "������ˣ����Ժ�..........";

            m_mthSetUICannotEdit();
            m_btnPrint.Enabled = false;
            m_btnExit.Enabled = false;
            gradientPanel2.Enabled = false;

            if (!m_bgwCommit.IsBusy)
            {
                m_bgwCommit.RunWorkerAsync(dtbTemp);
            }
        }
        #endregion

        #region ����ҩƷ��Ϣ
        /// <summary>
        /// ����ҩƷ��Ϣ
        /// </summary>
        /// <param name="p_blnIsCommit">�Ƿ����ǰ����</param>
        private long m_lngSaveMedicineInfo(bool p_blnIsCommit)
        {
            m_dtgvMedicineDetail.EndEdit();
            long lngRes = ((clsCtl_InitialDS)objController).m_lngSaveMedicineInfo(p_blnIsCommit);
            if (lngRes > 0)
            {
                //((clsCtl_InitialDS)objController).m_mthGetAllMoney();
            }
            return lngRes;
        }
        #endregion

        private void m_btnUnExam_Click(object sender, EventArgs e)
        {
            ((clsCtl_InitialDS)objController).m_mthUnCommit();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            if (((clsCtl_InitialDS)objController).m_blnHasUnSaveData())
            {
                DialogResult drResult = MessageBox.Show("����������޸ĵ�����δ���棬�Ƿ������", "����ʼ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            this.Close();
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            if (((clsCtl_InitialDS)objController).m_blnHasUnSaveData())
            {
                DialogResult drResult = MessageBox.Show("����������޸ĵ�����δ���棬ˢ�½��ᶪʧ��Щ���ݣ��Ƿ������", "����ʼ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            m_mthRefreshMedicineDetail();
        }

        private void m_dtgvMedicineDetail_ArriveLastColoumn()
        {
            DataView dtbSource = m_dtgvMedicineDetail.DataSource as DataView;
            if (dtbSource != null && dtbSource.Count > 0)
            {
                DataRowView drCurrent = dtbSource[m_dtgvMedicineDetail.CurrentCell.RowIndex];
                DataRow[] drArr = new DataRow[] { drCurrent.Row };

                if (!((clsCtl_InitialDS)objController).m_blnIsAllAvailabileVO(drArr, null))
                {
                    return;
                }

                ((clsCtl_InitialDS)objController).m_mthInsertNewMedicine();
            }
        }

        private void m_txtInputMan_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_InitialDS)objController).m_mthFilter();
        }

        private void m_txtCommitMan_TextChanged(object sender, EventArgs e)
        {
            ((clsCtl_InitialDS)objController).m_mthFilter();
        }

        private void m_cboCommitInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_InitialDS)objController).m_mthFilter();
        }

        private void m_txtMedName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (m_dtbMedicineDict == null || m_dtbMedicineDict.Rows.Count == 0)
                {
                    ((clsCtl_InitialDS)objController).m_mthInitMedicineInfo(m_strDrugStoreID, ref m_dtbMedicineDict);
                }
                ((clsCtl_InitialDS)objController).m_mthShowQueryMedicineFormForFilter(m_txtMedName.Text, m_dtbMedicineDict);
            }
        }

        private void m_txtMedName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtMedName.Text))
            {
                ((clsCtl_InitialDS)objController).m_mthFilter();
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void m_bgwCommit_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
            {
                return;
            }

            DataTable dtbSource = e.Argument as DataTable;
            if (dtbSource == null)
            {
                return;
            }

            long lngRes = ((clsCtl_InitialDS)objController).m_lngCommitToStorageDetail(dtbSource);
            e.Result = lngRes;
        }

        private void m_bgwCommit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_pnlWaiting.Visible = false;
            this.label14.Text = "���ڻ�ȡ���ݣ����Ժ�..........";

            m_mthSetUICanEdit();
            m_btnPrint.Enabled = true;
            m_btnExit.Enabled = true;
            gradientPanel2.Enabled = true;

            long lngRes = (long)e.Result;
            if (lngRes > 0)
            {
                System.Windows.Forms.MessageBox.Show("������", "ԭʼ����ʼ��", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else if (lngRes == 0)
            {
                MessageBox.Show("û������˵ļ�¼", "ԭʼ����ʼ��", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("���ʧ��", "ԭʼ����ʼ��", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

            if (lngRes != 0)
            {
                m_mthRefreshMedicineDetail();
            }            
        }

        private void frmInitialDS_Load(object sender, EventArgs e)
        {
           
        }

        private void m_btnAccount_Click(object sender, EventArgs e)
        {
            ((clsCtl_InitialDS)objController).m_mthInAccount();
        }

        private void m_dtgvMedicineDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && m_dtgvMedicineDetail[e.ColumnIndex, e.RowIndex].Value != null)
            {
                double dblAmount = 0d;
                double dblPack = 0d;
                if (double.TryParse(m_dtgvMedicineDetail[e.ColumnIndex,e.RowIndex].Value.ToString(), out dblAmount))
                {
                    DataRowView drvCurrent = m_dtgvMedicineDetail.Rows[e.RowIndex].DataBoundItem as DataRowView;

                    if (drvCurrent != null && double.TryParse(drvCurrent["PACKQTY_DEC"].ToString(), out dblPack))
                    {
                        if (m_blnIsHospital)
                        {
                            if (Convert.ToInt16(drvCurrent["ipchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount;
                                drvCurrent["IPAMOUNT"] = dblAmount * dblPack;
                            }
                            else
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount / dblPack;
                                drvCurrent["IPAMOUNT"] = dblAmount;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//������λ
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount;
                                drvCurrent["IPAMOUNT"] = dblAmount * dblPack;
                            }
                            else
                            {
                                drvCurrent["OPAMOUNT"] = dblAmount / dblPack;
                                drvCurrent["IPAMOUNT"] = dblAmount;
                            }
                        }
                    }
                }
            }
        }
    }
}