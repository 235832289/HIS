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
    /// ҩ������Ƶ�����
    /// </summary>
    public partial class frmInStorageMakeOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public frmInStorageMakeOrder()
        {
            InitializeComponent();
            m_objInstorageList = new List<clsDS_Instorage_VO>();
            ((clsCtl_InStorageMakerOrder)objController).m_mthGetCommitFlow(out m_intCommitFolow);
            m_intDaysToValidDate = Convert.ToInt32(this.objController.m_objComInfo.m_lonGetModuleInfo("5032"));
        }
        /// <summary>
        /// �����½��ı���Ϣ
        /// </summary>
        public List<clsDS_Instorage_VO> m_objInstorageList;
        /// <summary>
        /// ҩ��������Ϣ��
        /// </summary>
        public DataTable m_dtMedStoreInfo;
        /// <summary>
        /// ҩ�����������;Ϊnullֵʱ��ʾ�ӡ���ⵥ�ݱ�����ȡ��ֻ������ⵥ������ִ�и��ֳ�ʼ��
        /// </summary>
        public frmInStorage frmMain;
        /// <summary>
        /// �������ҩƷ��Ϣ
        /// </summary>
        public DataTable m_dtMedicine = null;
        /// <summary>
        /// ���ҩƷ��Ϣ
        /// </summary>
        public DataTable m_dtInStorageMedicine = null;
        /// <summary>
        /// ҩ������������к�
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// �Ƿ����޸ĵ�Ȩ��
        /// </summary>
        internal bool IsCanModify = true;
        /// <summary>
        /// �Ƿ񱣴�ɹ���
        /// </summary>
        internal bool m_blnSaved = false;
        /// <summary>
        /// ҩ��ID
        /// </summary>
        internal string m_strStoreid = string.Empty;
        /// <summary>
        /// ҩ������
        /// </summary>
        internal string m_strStorename = string.Empty;
        /// <summary>
        /// �������
        /// </summary>
        public DataTable m_dtInStoreType = null;
        /// <summary>
        /// �Ƿ񱣴漴���
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// ��������
        /// </summary>
        internal int m_intFormType = -1;
        /// <summary>
        /// ����ʱ�����״̬����ֵΪ1��������Ȼ������״̬����formtype��ֵΪ3,4,6����ֵΪ2
        /// </summary>
        internal int m_intCommitStatus = 0;
        /// <summary>
        /// 'ҩ��ҩƷ��ʧЧ���ض�ʱ������',Ĭ��30����λ����
        /// </summary>
        private int m_intDaysToValidDate = 30;
        /// <summary>
        /// �Ƿ�סԺҩ��
        /// </summary>
        internal bool m_blnIsHospital = false;
        /// <summary>
        ///  �������Ʋ����
        /// </summary>        
        public override void CreateController()
        {
            this.objController = new clsCtl_InStorageMakerOrder();
            this.objController.Set_GUI_Apperance(this);
        }
        private void frmInStorageMakeOrder_Load(object sender, EventArgs e)
        {

            this.m_datValidPeriod.Clear();
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvDetail.AutoGenerateColumns = false;
            if (m_blnIsHospital)
            {
                m_dgvDetail.Columns["unit_chr"].HeaderText = "סԺ��λ";
            }
           // this.m_bgwGetData.RunWorkerAsync();
            this.m_mthGetInitialData();
            ((clsCtl_InStorageMakerOrder)objController).m_mthBorrowDeptInfo();
            this.m_cboStatus.Enter -= new System.EventHandler(this.m_cboStatus_Enter);
            if (this.m_dtInStorageMedicine == null)
            {
                ((clsCtl_InStorageMakerOrder)objController).m_mthInitMedicineTable(ref m_dtInStorageMedicine);
                this.m_dgvDetail.DataSource = m_dtInStorageMedicine;
                this.m_txtMaker.Text = this.LoginInfo.m_strEmpName;
                this.m_txtMaker.Tag = this.LoginInfo.m_strEmpID;
                if (m_dtInStorageMedicine != null && m_dtInStorageMedicine.Rows.Count == 0)
                {
                    ((clsCtl_InStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                }
                this.m_cboStatus.Enter += new System.EventHandler(this.m_cboStatus_Enter);
                this.m_cboStatus.Focus();
                this.m_cboStatus.Enter -= new System.EventHandler(this.m_cboStatus_Enter);
            }
            else
            {
                this.m_dgvDetail.DataSource = m_dtInStorageMedicine;
                m_mthShowRetailMoney();
                if (IsCanModify == false)
                {
                    this.m_btnSave.Enabled = false;
                    this.m_btnDelete.Enabled = false;
                    this.m_btnInsert.Enabled = false;
                    //this.m_btnNext.Enabled = false;
                    m_dgvDetail.ReadOnly = true;
                    m_dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    //m_dgvDetail.EnterKeyPress -= new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(m_dgvDetail_EnterKeyPress);
                    this.m_cboStatus.Focus();
                }
                if (m_intCommitStatus != 0)
                {
                    this.m_cboMedStore.Enabled = false;
                    //this.m_txtComment.ReadOnly = true;
                    this.m_btnSave.Enabled = true;
                    m_dgvDetail.ReadOnly = true;
                    m_dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.m_btnDelete.Enabled = false;
                    this.m_btnInsert.Enabled = false;
                    this.m_cboStatus.Focus();
                    if (m_intCommitStatus == 2 || m_intFormType == 6)
                        this.m_txtFromDept.Enabled = false;
                }
            }
        }
        internal bool m_blnClosed = false;
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtInStorageMedicine != null && m_btnInsert.Enabled)
            {
                drNull = m_dtInStorageMedicine.Select("medicineid_chr is null and opamount_int is null");//ѡ�����õ�����
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtInStorageMedicine.Rows.Remove(drTemp);
                    }
                }
                DataTable dtbNew = m_dtInStorageMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtInStorageMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("��ǰ�������δ������Ƶ���¼��ȷ���˳�?", "ҩ������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            m_blnClosed = true;
            this.Close();
        }
        /// <summary>
        /// ��ȡҩƷ������Ϣ
        /// </summary>
        internal void m_mthGetMedicineData()
        {
            if (frmMain == null) return;
            if (this.frmMain.m_strMedStoreArr != null && this.frmMain.m_strMedStoreArr.Length >= 1)
            {
                clsPub.m_mthGetMedBaseInfo(this.frmMain.m_strMedStoreArr[0], out this.m_dtMedicine);
            }
            else
            {
                clsPub.m_mthGetMedBaseInfo(string.Empty, out m_dtMedicine);
            }
        }
        /// <summary>
        /// ��ȡ��ʼ������
        /// </summary>
        public void m_mthGetInitialData()
        {
            if (frmMain == null) return;
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
            clsPub.m_lngGetTypeCode(0, out this.m_dtInStoreType);
            for (int i = 0; i < this.m_dtMedStoreInfo.Rows.Count; i++)
            {
                //this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());

                if (this.frmMain.m_strMedStoreArr != null)
                {
                    for (int j = 0; j < this.frmMain.m_strMedStoreArr.Length; j++)
                    {
                        if (this.frmMain.m_strMedStoreArr[j].Trim() == m_dtMedStoreInfo.Rows[i]["medstoreid_chr"].ToString())
                            this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());
                    }
                }
                else
                {
                    this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());
                }
            }
            //����
            if (this.m_cboMedStore.AccessibleName == null && this.m_cboMedStore.Items.Count > 0)
            {
                this.m_cboMedStore.SelectedIndex = 0;
            }
            this.m_cboStatus.Items.Clear();
            if (this.m_dtInStoreType != null)
            {
                for (int i = 0; i < this.m_dtInStoreType.Rows.Count; i++)
                {
                    this.m_cboStatus.Item.Add(m_dtInStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtInStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            //this.m_cboStatus.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(m_strStoreid))
            {
                this.m_cboMedStore.AccessibleName = m_strStoreid;
                this.m_cboMedStore.Text = m_strStorename;
            }
        }
        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            if (frmMain == null) return;
            if (this.frmMain.m_strMedStoreArr != null && this.frmMain.m_strMedStoreArr.Length >= 1)
            {
                clsPub.m_mthGetMedBaseInfo(this.frmMain.m_strMedStoreArr[0], out this.m_dtMedicine);
            }
            else
            {
                clsPub.m_mthGetMedBaseInfo(string.Empty, out m_dtMedicine);
            }
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
            clsPub.m_lngGetTypeCode(0, out this.m_dtInStoreType);

        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DateTime dtTemp = DateTime.MinValue;
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;

                this.m_dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (DateTime.TryParse(Convert.ToString(this.m_dgvDetail.Rows[iRow].Cells["VALIDPERIOD_DAT"].Value), out dtTemp))
                {
                    if (dtTemp < Convert.ToDateTime(m_datMakeDate.Value))
                    {
                        if (dtTemp.ToString("yyyy-MM-dd").Trim() != "0001-01-01")
                        {
                            this.m_dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.Crimson;
                        }
                    }
                    else if (dtTemp.AddDays(-m_intDaysToValidDate) < Convert.ToDateTime(m_datMakeDate.Value))
                    {
                        this.m_dgvDetail.Rows[iRow].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                    }
                }
                
            }     
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvDetail_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell == null || m_dgvDetail.ReadOnly == true)
            {
                return;
            }
            this.m_dgvDetail.EndEdit();

            if (CurrentCell.ColumnIndex == 1)
            {
                string strFilter = string.Empty;
                if (CurrentCell.Value != null)
                {
                    strFilter = CurrentCell.Value.ToString();
                }
                if (m_dtMedicine == null || m_dtMedicine.Rows.Count == 0)
                {
                    this.m_mthGetMedicineData();
                }
                ((clsCtl_InStorageMakerOrder)objController).m_mthShowQueryMedicineForm(strFilter, m_dtMedicine);
                
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 5)
            {
                //if (CurrentCell.Value.ToString() != string.Empty && CurrentCell.Value != DBNull.Value)
                //{
                for (int j = 0; j < this.m_dgvDetail.Rows.Count - 1; j++)
                {
                    if (j == CurrentCell.RowIndex) continue;
                    if (this.m_dgvDetail.Rows[j].Cells["medicineid_chr"].Value.ToString() == this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells["medicineid_chr"].Value.ToString() && Convert.ToString(this.m_dgvDetail.Rows[j].Cells[5].Value) == Convert.ToString(CurrentCell.Value))
                    {
                        MessageBox.Show(string.Format("��{0}���Ѿ�������ͬID��ͬ���ŵ�ҩƷ��¼����������ͬһ�ŵ���������ͬID��ͬ���ŵ�ҩƷ��¼��������¼�룡", j + 1), "ҩ������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CurrentCell.Value = DBNull.Value;
                        CancelJump = true;
                        this.m_dgvDetail.Focus();
                        return;
                    }
                }
                CancelJump = false;
                //}
                //else
                //{
                //    MessageBox.Show("ҩƷ���Ų���Ϊ�գ�������¼�룡", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    CancelJump = true;
                //    this.m_dgvDetail.Focus();
                //    return;
                //}
            }
            else if (CurrentCell.ColumnIndex == this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells["amount_int"].ColumnIndex)
            {
                if (CurrentCell.Value != null && CurrentCell.Value != DBNull.Value)
                {
                    try
                    {
                        int p_intRowIdex = CurrentCell.RowIndex;
                        double p_dblValue = Convert.ToDouble(CurrentCell.Value);
                        double dblTemp = 0d;
                        if (double.TryParse(this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvPackDec"].Value.ToString(), out dblTemp))//��װ��
                        {
                            //if (p_dblValue < 0)//�������ټ�����Ƿ����Գ����������Ϊ���� 20080617
                            //{
                            //    if (Convert.ToDouble(this.m_dgvDetail.Rows[p_intRowIdex].Cells["opchargeflg_int"].Value) == 0)//������λ
                            //    {
                            //        if (!((clsCtl_InStorageMakerOrder)objController).m_blnJudgeMedicineExisted(p_dblValue, 0))
                            //        {
                            //            CurrentCell.Value = DBNull.Value;
                            //            CancelJump = true;
                            //            this.m_dgvDetail.Focus();
                            //            return;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (!((clsCtl_InStorageMakerOrder)objController).m_blnJudgeMedicineExisted(0, p_dblValue))
                            //        {
                            //            CurrentCell.Value = DBNull.Value;
                            //            CancelJump = true;
                            //            this.m_dgvDetail.Focus();
                            //            return;
                            //        }
                            //    }
                            //}

                            if (m_blnIsHospital)
                            {
                                if (Convert.ToDouble(this.m_dgvDetail.Rows[p_intRowIdex].Cells["ipchargeflg_int"].Value) == 0)//������λ
                                {
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutUint"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPWHOLESALEPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPRETAILPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = dblTemp * p_dblValue;
                                }
                                else //��С����
                                {
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue / dblTemp;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInUint"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPWHOLESALEPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPRETAILPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = p_dblValue;
                                }
                            }
                            else
                            {
                                if (Convert.ToDouble(this.m_dgvDetail.Rows[p_intRowIdex].Cells["opchargeflg_int"].Value) == 0)//������λ
                                {
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutUint"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPWHOLESALEPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPRETAILPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = dblTemp * p_dblValue;
                                }
                                else //��С����
                                {
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue / dblTemp;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInUint"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPWHOLESALEPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPRETAILPRICE_INT"].Value;
                                    this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = p_dblValue;
                                }
                            }

                            m_mthShowRetailMoney();
                            if (m_dgvDetail.Rows.Count > p_intRowIdex + 1)
                            {
                                m_dgvDetail.CurrentCell = m_dgvDetail.Rows[p_intRowIdex + 1].Cells[1];
                                m_dgvDetail.CurrentCell.Selected = true;
                            }
                            else
                            {
                                ((clsCtl_InStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                            }
                            CancelJump = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (CurrentCell.Value == DBNull.Value)
                {
                    CancelJump = true;
                    return;
                }
            }
            else if (CurrentCell.ColumnIndex == 11)
            {

                ((clsCtl_InStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                CancelJump = true;
            }
        }

        internal void m_mthShowRetailMoney()
        {
            DataTable m_dtbDetail = (DataTable)this.m_dgvDetail.DataSource;
            if (m_dtbDetail != null && m_dtbDetail.Rows.Count > 0)
            {
                double dblTemp = 0d;
                double dblTmp = 0d;
                for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    if (Convert.ToString(m_dtbDetail.Rows[i1]["OPRETAILPRICE_INT"]) == string.Empty || Convert.ToString(m_dtbDetail.Rows[i1]["PACKQTY_DEC"]) == string.Empty || Convert.ToString(m_dtbDetail.Rows[i1]["IPAMOUNT_INT"]) == string.Empty)
                        continue;
                    double.TryParse(Convert.ToString((Convert.ToDouble(m_dtbDetail.Rows[i1]["OPRETAILPRICE_INT"]) / Convert.ToDouble(m_dtbDetail.Rows[i1]["PACKQTY_DEC"])) * Convert.ToDouble(m_dtbDetail.Rows[i1]["IPAMOUNT_INT"])), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_lblRetail.Text = dblTemp.ToString("F4") + "Ԫ";
            }
            else
            {
                m_lblRetail.Text = "0Ԫ";
            }
        }

        private void m_mthControls_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
            }
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (frmMain == null) return;
            for (int i = 0; i < this.m_dtMedStoreInfo.Rows.Count; i++)
            {
                //this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());

                if (this.frmMain.m_strMedStoreArr != null)
                {
                    for (int j = 0; j < this.frmMain.m_strMedStoreArr.Length; j++)
                    {
                        if (this.frmMain.m_strMedStoreArr[j].Trim() == m_dtMedStoreInfo.Rows[i]["medstoreid_chr"].ToString())
                            this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());
                    }
                }
                else
                {
                    this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());
                }
            }
            //����
            if (this.m_cboMedStore.AccessibleName == null && this.m_cboMedStore.Items.Count > 0)
            {
                this.m_cboMedStore.SelectedIndex = 0;
            }
            this.m_cboStatus.Items.Clear();
            if (this.m_dtInStoreType != null)
            {
                for (int i = 0; i < this.m_dtInStoreType.Rows.Count; i++)
                {
                    this.m_cboStatus.Item.Add(m_dtInStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtInStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            //this.m_cboStatus.SelectedIndex = 0;
            if (!string.IsNullOrEmpty(m_strStoreid))
            {
                this.m_cboMedStore.AccessibleName = m_strStoreid;
                this.m_cboMedStore.Text = m_strStorename;
            }
        }

        private void m_txtFromDept_FocusNextControl(object sender, EventArgs e)
        {
            this.m_cboMedStore.Focus();
        }

        private void m_datValidPeriod_ValueChanged(object sender, EventArgs e)
        {

        }
        DataGridViewCell CurrentCell = null;
        DateTime datTemp;
        private void m_dgvDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dgvDetail.ReadOnly) return;
            m_intRowIndex1 = e.RowIndex;
            if (e.ColumnIndex == 6)
            {
                System.Drawing.Rectangle rect =
                this.m_dgvDetail.GetCellDisplayRectangle(e.ColumnIndex,
                e.RowIndex, true);
                this.m_datValidPeriod.Location = new System.Drawing.Point(rect.X + m_dgvDetail.Location.X, rect.Y + m_dgvDetail.Location.Y);
                this.m_datValidPeriod.Visible = true;
                this.m_datValidPeriod.BringToFront();
                this.m_datValidPeriod.Focus();
                this.m_datValidPeriod.Select(0, 4);
                //m_datValidPeriod.Text = Convert.ToDateTime(this.m_dgvDetail.Rows[e.RowIndex].Cells["VALIDPERIOD_DAT"].Value).ToString("yyyy��MM��dd��");
                if (Convert.ToString(this.m_dgvDetail.Rows[e.RowIndex].Cells["VALIDPERIOD_DAT"].Value) == "")
                {
                    m_datValidPeriod.Text = "";
                }
                else if (DateTime.TryParse(Convert.ToDateTime(this.m_dgvDetail.Rows[e.RowIndex].Cells["VALIDPERIOD_DAT"].Value).ToString("yyyy��MM��dd��"), out datTemp))
                {
                    m_datValidPeriod.Text = Convert.ToDateTime(this.m_dgvDetail.Rows[e.RowIndex].Cells["VALIDPERIOD_DAT"].Value).ToString("yyyy��MM��dd��");
                }
            }
            else
            {
                CurrentCell = this.m_dgvDetail.CurrentCell;
                this.m_datValidPeriod.Visible = false;
                //if (DateTime.TryParse(this.m_datValidPeriod.Text, out datTemp))
                //{
                //    this.m_dgvDetail.Rows[e.RowIndex].Cells["VALIDPERIOD_DAT"].Value = datTemp;
                //}
            }
        }
        private void m_dgvDetail_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 6)
            //    {
            //        if (DateTime.TryParse(this.m_datValidPeriod.Text, out datTemp))
            //        {

            //            this.m_datValidPeriod.Visible = false;
            //            this.m_dgvDetail.CurrentCell.Value = datTemp;
            //            this.m_dgvDetail.EndEdit();
            //        }

            //    }
            //}
            //catch
            //{
            //}
            if (e.ColumnIndex == 7)
            {
                double dblTemp = 0d;
                if (double.TryParse(Convert.ToString(m_dgvDetail[7, e.RowIndex].EditedFormattedValue), out dblTemp))
                {                    
                    m_dgvDetail[7, e.RowIndex].Value = dblTemp;
                    m_dgvDetail.EndEdit();
                }
            }
        }

        private void m_datValidPeriod_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    //this.m_dgvDetail.CellEnter -= new DataGridViewCellEventHandler(m_dgvDetail_CellEnter);
            //    DataGridViewCell CurrentCell = this.m_dgvDetail.CurrentCell;
            //    this.m_datValidPeriod.Visible = false;
            //    this.m_dgvDetail.CurrentCell.Value = this.m_datValidPeriod.Text;
            //    this.m_dgvDetail.BringToFront();
            //    this.m_lblRetailMoney.BringToFront();
            //    m_lblRetail.BringToFront();
            //    this.m_dgvDetail.Focus();
            //}
        }

        private void m_dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_intCommitStatus != 0)//ֻ�޸�������ͺ���Դ����
            {
                long lngResult = ((clsCtl_InStorageMakerOrder)objController).m_lngUpdateTypeAndDept();
                if (lngResult > 0)
                {
                    m_blnSaved = true;
                    MessageBox.Show("�޸ĳɹ�!", "ҩ������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_dgvDetail.EndEdit();
                long lngRes = ((clsCtl_InStorageMakerOrder)objController).m_lngSaveInstorageMedInfo(true);
            }
            //if (lngRes > 0)
            //{
            //    DialogResult drResult = MessageBox.Show("�Ƿ��ӡ��ǰ�����¼?", "ҩ������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (drResult == DialogResult.Yes)
            //    {
            //        ((clsCtl_InStorageMakerOrder)objController).m_mthPrint();

            //    }

            //}
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_InStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            this.m_datValidPeriod.Visible = false;
            if (this.m_dgvDetail.SelectedCells.Count > 0)
            {
                DialogResult drResult = MessageBox.Show("ȷ��ɾ��ѡ�е�����¼��", "ҩ�����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
                ((clsCtl_InStorageMakerOrder)objController).m_mthDeleteDetail(true);
            }
            else
            {
                return;
            }
        }

        private void m_btnNext_Click(object sender, EventArgs e)
        {
            this.m_datValidPeriod.Visible = false;
            DataRow[] drNull = null;
            if (m_dtInStorageMedicine != null)
            {
                drNull = this.m_dtInStorageMedicine.Select("medicineid_chr is null and opamount_int is null");//ѡ�����õ�����
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtInStorageMedicine.Rows.Remove(drTemp);
                    }
                }
                DataTable dtbNew = m_dtInStorageMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = m_dtInStorageMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("��ǰ�������δ����ļ�¼��ȷ����ղ���д��һ�ŵ�?", "ҩ�����", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
            }
            ((clsCtl_InStorageMakerOrder)objController).m_mthClear();
            ((clsCtl_InStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();            
        }

        private void m_cboStatus_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
        }

        private void m_cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_txtFromDept.Focus();
            }
        }

        private void m_txtComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_dtInStorageMedicine.Rows.Count > 0)
                {
                    DataRow drLast = m_dtInStorageMedicine.Rows[m_dtInStorageMedicine.Rows.Count - 1];
                    if (drLast["MEDICINEID_CHR"] == DBNull.Value)
                    {
                        this.m_dgvDetail.Focus();
                        m_dgvDetail.CurrentCell = m_dgvDetail.Rows[this.m_dtInStorageMedicine.Rows.Count - 1].Cells[1];
                        m_dgvDetail.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_InStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                }
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_InStorageMakerOrder)objController).m_mthPrint();
        }

        internal void SetDetail(DataTable dtbSelected)
        {
            ((clsCtl_InStorageMakerOrder)objController).m_mthSetDetail(dtbSelected);
        }

        private void m_cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_cboStatus.AccessibleName = m_cboStatus.SelectItemValue != string.Empty ? m_cboStatus.SelectItemValue : m_cboStatus.AccessibleName;

        }

        private void m_dgvDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void m_datValidPeriod_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    //this.m_dgvDetail.CellEnter -= new DataGridViewCellEventHandler(m_dgvDetail_CellEnter);
                    CurrentCell = this.m_dgvDetail.CurrentCell;
                    if (DateTime.TryParse(this.m_datValidPeriod.Text, out datTemp))
                    {
                        //if (datTemp < clsPub.SysDateTimeNow.Date)
                        //{
                        //    MessageBox.Show("��Ч��С�ڵ�ǰ���ڣ�", "ע��...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}
                        this.m_datValidPeriod.Visible = false;
                        this.m_dgvDetail.CurrentCell.Value = datTemp;
                        this.m_dgvDetail.BringToFront();
                        this.m_lblRetail.BringToFront();
                        label11.BringToFront();
                        this.m_dgvDetail.EndEdit();
                        this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells[CurrentCell.ColumnIndex + 1];
                        this.m_dgvDetail.Focus();
                    }
                    else
                    {
                        this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells["VALIDPERIOD_DAT"].Value = null;
                        this.m_dgvDetail.CurrentCell = this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells[CurrentCell.ColumnIndex + 1];
                        this.m_dgvDetail.Focus();
                    }
                }
            }
            catch
            {
            }
        }

        private void m_cboStatus_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.SendWait("{F4}");

            }
        }

        private void m_dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            if (CurrentCell == null || CurrentCell.RowIndex == -1) return;
            if (e.ColumnIndex == this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells["amount_int"].ColumnIndex)
            {
                if (Convert.ToString(CurrentCell.Value).Length == 0) return;
                try
                {
                    int p_intRowIdex = CurrentCell.RowIndex;
                    double p_dblValue = Convert.ToDouble(CurrentCell.Value);
                    double dblTemp = 0d;
                    if (double.TryParse(this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvPackDec"].Value.ToString(), out dblTemp))//��װ��
                    {
                        //�������ټ�����Ƿ����Գ����������Ϊ���� 20080617
                        //if (p_dblValue < 0)
                        //{
                        //    if (Convert.ToDouble(this.m_dgvDetail.Rows[p_intRowIdex].Cells["opchargeflg_int"].Value) == 0)//������λ
                        //    {
                        //        if (!((clsCtl_InStorageMakerOrder)objController).m_blnJudgeMedicineExisted(p_dblValue, 0))
                        //        {
                        //            CurrentCell.Value = DBNull.Value;
                        //            this.m_dgvDetail.Focus();
                        //            return;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (!((clsCtl_InStorageMakerOrder)objController).m_blnJudgeMedicineExisted(0, p_dblValue))
                        //        {
                        //            CurrentCell.Value = DBNull.Value;
                        //            this.m_dgvDetail.Focus();
                        //            return;
                        //        }
                        //    }

                        //}

                        if (m_blnIsHospital)
                        {
                            if (Convert.ToDouble(this.m_dgvDetail.Rows[p_intRowIdex].Cells["ipchargeflg_int"].Value) == 0)//������λ
                            {
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutUint"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPWHOLESALEPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPRETAILPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = dblTemp * p_dblValue;
                            }
                            else //��С����
                            {
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue / dblTemp;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInUint"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPWHOLESALEPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPRETAILPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = p_dblValue;
                            }
                        }
                        else
                        {
                            if (Convert.ToDouble(this.m_dgvDetail.Rows[p_intRowIdex].Cells["opchargeflg_int"].Value) == 0)//������λ
                            {
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutUint"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPWHOLESALEPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColOPRETAILPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = dblTemp * p_dblValue;
                            }
                            else //��С����
                            {
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtOutAmount"].Value = p_dblValue / dblTemp;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["amount_int"].Value = p_dblValue;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["unit_chr"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInUint"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["WHOLESALEPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPWHOLESALEPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["RETAILPRICE_INT"].Value = this.m_dgvDetail.Rows[p_intRowIdex].Cells["ColIPRETAILPRICE_INT"].Value;
                                this.m_dgvDetail.Rows[p_intRowIdex].Cells["m_dgvtxtInAmount"].Value = p_dblValue;
                            }
                        }

                        m_mthShowRetailMoney();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                

                //int intRowIndex = e.RowIndex;
                //DataRowView drvCurrent = m_dgvDetail.Rows[intRowIndex].DataBoundItem as DataRowView;
                //double dblTemp = 0d;//��װ��
                //double dblAmount = 0d;
                //if (double.TryParse(Convert.ToString(this.m_dgvDetail.Rows[intRowIndex].Cells["amount_int"].Value), out dblAmount))
                //{
                //    if (double.TryParse(this.m_dgvDetail.Rows[intRowIndex].Cells["m_dgvPackDec"].Value.ToString(), out dblTemp))
                //    {
                //        if (Convert.ToInt16(drvCurrent["opchargeflg_int"]) == 0)//������λ
                //        {
                //            m_dgvDetail.Rows[intRowIndex].Cells["m_dgvtxtOutAmount"].Value = dblAmount;
                //            m_dgvDetail.Rows[intRowIndex].Cells["m_dgvtxtInAmount"].Value = dblAmount * dblTemp;
                //            //m_dgvDetail.Rows[intRowIndex].Cells["retailmoney"].Value = dblTemp * dblAmount * Convert.ToDouble(drvCurrent["RETAILPRICE_INT"]);
                //        }
                //        else
                //        {
                //            m_dgvDetail.Rows[intRowIndex].Cells["m_dgvtxtOutAmount"].Value = dblAmount / dblTemp;
                //            m_dgvDetail.Rows[intRowIndex].Cells["m_dgvtxtInAmount"].Value = dblAmount;
                //            m_dgvDetail.Rows[intRowIndex].Cells["retailmoney"].Value = dblAmount * Convert.ToDouble(drvCurrent["RETAILPRICE_INT"]);
                //        }
                //        m_mthShowRetailMoney();
                //    }
                //}
            }           
        }

        int m_intRowIndex1 = -1;
        int m_intRowIndex2 = -1;
        private void m_datValidPeriod_VisibleChanged(object sender, EventArgs e)
        {
            if (m_intRowIndex1 == -1) return;
            if (m_datValidPeriod.Visible)
            {
                m_intRowIndex2 = m_intRowIndex1;
                if (!string.IsNullOrEmpty(Convert.ToString(this.m_dgvDetail.Rows[m_intRowIndex1].Cells["VALIDPERIOD_DAT"].Value)))
                {
                    if (DateTime.TryParse(Convert.ToString(this.m_dgvDetail.Rows[m_intRowIndex1].Cells["VALIDPERIOD_DAT"].Value), out datTemp))
                    {
                        m_datValidPeriod.Text = datTemp.ToString("yyyy��MM��dd��");
                    }                    
                }
                else
                {
                    m_datValidPeriod.Text = "";
                }
            }
            else
            {
                if (DateTime.TryParse(this.m_datValidPeriod.Text, out datTemp))
                {
                    if (datTemp < clsPub.CurrentDateTimeNow.Date)
                    {
                        MessageBox.Show("��Ч��С�ڵ�ǰ���ڣ�", "ע��...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    this.m_dgvDetail.Rows[m_intRowIndex2].Cells["VALIDPERIOD_DAT"].Value = datTemp;

                    this.m_dgvDetail.Rows[m_intRowIndex2].DefaultCellStyle.ForeColor = Color.Black;
                    if (Convert.ToDateTime(this.m_dgvDetail.Rows[m_intRowIndex2].Cells["VALIDPERIOD_DAT"].Value) < Convert.ToDateTime(m_datMakeDate.Value))
                    {
                        if (Convert.ToDateTime(this.m_dgvDetail.Rows[m_intRowIndex2].Cells["VALIDPERIOD_DAT"].Value).ToString("yyyy-MM-dd").Trim() != "0001-01-01")
                        {
                            this.m_dgvDetail.Rows[m_intRowIndex2].DefaultCellStyle.ForeColor = Color.Crimson;
                        }
                    }
                    else if (Convert.ToDateTime(this.m_dgvDetail.Rows[m_intRowIndex2].Cells["VALIDPERIOD_DAT"].Value).AddDays(-m_intDaysToValidDate) < Convert.ToDateTime(m_datMakeDate.Value))
                    {
                        this.m_dgvDetail.Rows[m_intRowIndex2].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                    }
                   
                }
            }
        }

        private void m_datValidPeriod_Leave(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ���ݵ��ݺż��ص��ݣ�������ⵥ�ݱ������ã�ֻ����ֻ������ӡ�͹رչ��ܡ�
        /// </summary>
        /// <param name="p_strBillID"></param>
        public void LoadBill(string p_strBillID)
        {
            ((clsCtl_InStorageMakerOrder)objController).LoadBill(p_strBillID);
            m_mthShowRetailMoney();
            m_dgvDetail.ReadOnly = true;
        }
    }
}