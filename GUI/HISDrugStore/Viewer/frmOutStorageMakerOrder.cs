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
    /// ҩ�������Ƶ�����
    /// </summary>
    public partial class frmOutStorageMakerOrder : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// ҩ������������
        /// </summary>
        public frmOutStorage frmMain;
        /// <summary>
        /// �����½��ı���Ϣ
        /// </summary>
        public List<clsDS_OutStorage_VO> m_objOutstorageList;
        /// <summary>
        /// ҩ��������Ϣ��
        /// </summary>
        public DataTable m_dtMedStoreInfo;      
        ///  <summary>
        /// �������ҩƷ��Ϣ
        /// </summary>
        public DataTable m_dtMedicine = null;
        /// <summary>
        /// ����ҩƷ��Ϣ
        /// </summary>
        public DataTable m_dtOutStorageMedicine = null;
        /// <summary>
        /// ҩ�������������к�
        /// </summary>
        internal long m_lngMainSEQ = 0;
        /// <summary>
        /// �Ƿ����޸ĵ�Ȩ��
        /// </summary>
        internal bool IsCanModify = true;
        /// <summary>
        /// ҩ��ID
        /// </summary>
        internal string m_strStoreid = string.Empty;
        /// <summary>
        /// ҩ������
        /// </summary>
        internal string m_strStorename = string.Empty;
        /// <summary>
        /// ��������
        /// </summary>
        public DataTable m_dtOutStoreType = null;
        /// <summary>
        /// �Ƿ񱣴漴���
        /// </summary>
        internal int m_intCommitFolow = 0;
        /// <summary>
        /// ����ʱ�Ƿ����״̬
        /// </summary>
        internal bool m_blnIsCommit = false;
        /// <summary>
        /// Ĭ�ϵ������ͣ�20080724ҩ��Ҫ���������Ĭ��Ϊ��ҩ���⣩(20081230:סԺҩ����������Ĭ�ϣ����ų���)
        /// </summary>
        internal string m_strDefaultTypeID = string.Empty;
        /// <summary>
        /// �޸�����״̬�ĳ��ⵥʱ�ĳ��ⷢ�������Ƿ�����ҩ��
        /// </summary>
        internal bool m_blnSendToDrugStore = false;
        /// <summary>
        /// �޸�ʱ�ĵ���״̬
        /// </summary>
        internal int m_intEditStatus = 0;
        DataTable m_dtDept = new DataTable();
        /// <summary>
        /// �Ƿ�סԺ��λ
        /// </summary>
        internal bool m_blnIsHospital = false;
        /// <summary>
        /// �޸�ʱ����ֵ
        /// </summary>
        internal string m_strOriginalDept = string.Empty;
        /// <summary>
        ///  �������Ʋ����
        /// </summary>        
        public override void CreateController()
        {
            this.objController = new clsCtl_OutStorageMakerOrder();
            this.objController.Set_GUI_Apperance(this);
        }
        public frmOutStorageMakerOrder()
        {
            InitializeComponent();
            m_objOutstorageList = new List<clsDS_OutStorage_VO>();
            ((clsCtl_OutStorageMakerOrder)objController).m_mthGetCommitFlow(out m_intCommitFolow);
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
                    if (Convert.ToString(m_dtbDetail.Rows[i1]["ipamount_int"]).Length == 0 || Convert.ToString(m_dtbDetail.Rows[i1]["OPRETAILPRICE_INT"]).Length == 0 || Convert.ToString(m_dtbDetail.Rows[i1]["PACKQTY_DEC"]).Length == 0)
                        continue;
                    double.TryParse(Convert.ToString(Convert.ToDouble(m_dtbDetail.Rows[i1]["ipamount_int"]) * (Convert.ToDouble(m_dtbDetail.Rows[i1]["OPRETAILPRICE_INT"]) / Convert.ToDouble(m_dtbDetail.Rows[i1]["PACKQTY_DEC"]))), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_lblRetailMoney.Text = dblTemp.ToString("F4")+"Ԫ";
            }
            else
            {
                m_lblRetailMoney.Text = "0Ԫ";
            }
        }
        private void frmOutStorageMakerOrder_Load(object sender, EventArgs e)
        {
            this.m_datValidPeriod.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd��");
            this.m_dgvDetail.AutoGenerateColumns = false;

            if (m_blnIsHospital)
            {
                m_dgvDetail.Columns["unit_chr"].HeaderText = "סԺ��λ";
            }

            //this.m_bgwGetData.RunWorkerAsync();
            this.m_mthGetInitialData();
            
            clsPub.m_mthBorrowDeptInfo(out m_dtDept);
            m_txtFromDept.m_mthInitDeptData(m_dtDept);        

            if (this.m_dtOutStorageMedicine == null)
            {
                ((clsCtl_OutStorageMakerOrder)objController).m_mthInitMedicineTable(ref m_dtOutStorageMedicine);
                this.m_dgvDetail.DataSource = m_dtOutStorageMedicine;
                this.m_txtMaker.Text = this.LoginInfo.m_strEmpName;
                this.m_txtMaker.Tag = this.LoginInfo.m_strEmpID;
                if (m_dtOutStorageMedicine != null && m_dtOutStorageMedicine.Rows.Count == 0)
                {
                    ((clsCtl_OutStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                }
                this.m_cboStatus.Enter += new EventHandler(m_cboStatus_Enter);
                this.m_cboStatus.Focus();
                this.m_cboStatus.Enter -= new EventHandler(m_cboStatus_Enter);                
            }
            else
            {
                if (!m_dtOutStorageMedicine.Columns.Contains("DSINSTOREID_VCHR"))
                {
                    m_dtOutStorageMedicine.Columns.Add("DSINSTOREID_VCHR",typeof(string));
                }
                this.m_dgvDetail.DataSource = m_dtOutStorageMedicine;
                
                if (IsCanModify == false)
                {
                    this.m_btnSave.Enabled = false;
                    this.m_btnDelete.Enabled = false;
                    this.m_btnInsert.Enabled = false;
                    m_btnImpRecipeData.Enabled = false;
                    //this.m_btnNext.Enabled = false;
                    //m_dgvDetail.ReadOnly = true;
                    m_dgvDetail.Columns[1].ReadOnly = true;
                    m_dgvDetail.Columns[7].ReadOnly = true;
                    m_dgvDetail.Columns["rejectreason"].ReadOnly = true;

                    m_dgvDetail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    m_mthShowRetailMoney();
                    //m_dgvDetail.EnterKeyPress -= new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(m_dgvDetail_EnterKeyPress);
                }
                if (m_blnIsCommit)
                {
                    this.m_cboMedStore.Enabled = false;
                    this.m_txtComment.ReadOnly = true;
                    this.m_btnSave.Enabled = true;
                }

                if (m_intEditStatus == 3)
                {
                    ((clsCtl_OutStorageMakerOrder)objController).m_lngCheckIsDrugStoreDept(m_txtFromDept.AccessibleName,out m_blnSendToDrugStore);
                    if (m_blnSendToDrugStore)
                    {
                        m_txtFromDept.Enabled = false;
                    }
                }
            }
            m_txtFromDept.Focus();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            DataRow[] drNull = null;
            if (m_dtOutStorageMedicine != null && m_btnDelete.Enabled)
            {
                drNull = m_dtOutStorageMedicine.Select("medicineid_chr is null and opamount_int is null");//ѡ�����õ�����
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_dtOutStorageMedicine.Rows.Remove(drTemp);
                    }
                }
                //DataTable dtbNew = m_dtOutStorageMedicine.GetChanges(DataRowState.Added);
                //DataTable dtbEdit = m_dtOutStorageMedicine.GetChanges(DataRowState.Modified);
                //if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                //{
                if (drNull != null && drNull.Length > 0)
                {
                    DialogResult drResult = MessageBox.Show("��ǰ�������δ������Ƶ���¼��ȷ���˳�?", "ҩ�������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                }
                //}
            }
            m_dtOutStorageMedicine = null;
            this.Close();
        }
        /// <summary>
        /// ��ȡҩƷ������Ϣ
        /// </summary>
        internal void m_mthGetMedicineData()
        {
            if (this.frmMain.m_strMedStoreArr.Length >= 1)
            {
                clsPub.m_mthGetOutStorageMedBaseInfo(m_blnIsHospital, this.frmMain.m_strMedStoreArr[0], out this.m_dtMedicine);
            }
            else
            {
                clsPub.m_mthGetMedBaseInfo(string.Empty, out m_dtMedicine);
            }
        }
        /// <summary>
        /// ��ȡ��ʼ������
        /// </summary>
        private void m_mthGetInitialData()
        {
       
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
            clsPub.m_lngGetTypeCode(1, out this.m_dtOutStoreType);
            for (int i = 0; i < this.m_dtMedStoreInfo.Rows.Count; i++)
            {
                //this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());

                if (frmMain != null && this.frmMain.m_strMedStoreArr != null)
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
            if (!string.IsNullOrEmpty(m_strStoreid))
            {
                this.m_cboMedStore.AccessibleName = m_strStoreid;
                this.m_cboMedStore.Text = m_strStorename;
            }
            else
            {
                //����
                if (this.m_cboMedStore.Items.Count > 0)
                {
                    this.m_cboMedStore.SelectedIndex = 0;
                }
            }
            this.m_cboStatus.Items.Clear();
            if (this.m_dtOutStoreType != null)
            {
                for (int i = 0; i < this.m_dtOutStoreType.Rows.Count; i++)
                {
                    if (m_blnIsHospital)
                    {
                        if (m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString() == "���ų���")
                        {
                            m_strDefaultTypeID = m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString();
                        }
                    }
                    else
                    {
                        if (m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString() == "��ҩ����")
                        {
                            m_strDefaultTypeID = m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString();
                        }
                    }
                    this.m_cboStatus.Item.Add(m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }                
            }
            if (this.m_txtBillId.Text.Length == 0)
            {
                if (m_blnIsHospital)
                {
                    m_cboStatus.Text = "���ų���";
                }
                else
                {
                    m_cboStatus.Text = "��ҩ����";
                }
                m_cboStatus.AccessibleName = m_strDefaultTypeID;
            }
        }
        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            //if (this.frmMain.m_strMedStoreArr.Length > 1)
            //{
            //    clsPub.m_mthGetMedBaseInfo(this.frmMain.m_strMedStoreArr[0], out this.m_dtMedicine);
            //}
            //else
            //{
            //    clsPub.m_mthGetMedBaseInfo(string.Empty, out m_dtMedicine);
            //}
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
            clsPub.m_lngGetTypeCode(1, out this.m_dtOutStoreType);
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
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
            if (CurrentCell == null || IsCanModify == false)
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
                if (this.m_dtMedicine == null || this.m_dtMedicine.Rows.Count == 0)
                {
                    this.m_mthGetMedicineData();
                }
                ((clsCtl_OutStorageMakerOrder)objController).m_mthShowQueryMedicineForm(strFilter, this.m_dtMedicine);
                CancelJump = true;
            }
            else if (CurrentCell.ColumnIndex == 4)
            {
                // this.m_dgvDetail.CellEnter+=new DataGridViewCellEventHandler(m_dgvDetail_CellEnter);
            }
            else if (CurrentCell.ColumnIndex == 7)
            {
                if (CurrentCell.Value != null)
                {
                    try
                    {
                        if (m_dtOutStorageMedicine.Rows[m_dgvDetail.CurrentCell.RowIndex]["amount_int"].ToString().Trim() == "")
                        {
                            return;
                        }
                        double dblTemp = 0d;
                        if (!double.TryParse(CurrentCell.Value.ToString(), out dblTemp))
                        {
                            CancelJump = true;
                            return;
                        }
                        int intRowIndex = CurrentCell.RowIndex;
                        double.TryParse(this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells["amount_int"].Value.ToString(), out dblTemp);
                        long lngRes = ((clsCtl_OutStorageMakerOrder)objController).m_lngShowMedicineSelect(dblTemp.ToString());
                        if (lngRes <= 0)
                        {
                            CancelJump = true;
                            m_dgvDetail.Focus();                           
                            CurrentCell.Selected = true;
                        }
                        else
                        {
                            m_dtOutStorageMedicine.AcceptChanges();
                            //dblTemp = 0d;
                            //if (double.TryParse(this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells[10].Value.ToString(), out dblTemp))
                            //{
                            //    this.m_dgvDetail.Rows[CurrentCell.RowIndex].Cells[8].Value = dblTemp * Convert.ToDouble(CurrentCell.Value);
                            //}
                            int intRowsCount = m_dtOutStorageMedicine.Rows.Count;
                            if (intRowsCount > 0)
                            {
                                m_mthShowRetailMoney();
                                //if (intRowsCount > intRowIndex + 1)
                                //{
                                //    m_dgvDetail.CurrentCell = m_dgvDetail.Rows[intRowIndex + 1].Cells[1];
                                //    m_dgvDetail.CurrentCell.Selected = true;
                                //}
                                //else
                                //{
                                CancelJump = true;
                                    ((clsCtl_OutStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                                //}                                
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (CurrentCell.ColumnIndex == 13)
            {
                m_mthShowRetailMoney();
                ((clsCtl_OutStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                CancelJump = true;
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
            if (!string.IsNullOrEmpty(m_strStoreid))
            {
                this.m_cboMedStore.AccessibleName = m_strStoreid;
                this.m_cboMedStore.Text = m_strStorename;
            }
            else
            {
                //����
                if (this.m_cboMedStore.Items.Count > 0)
                {
                    this.m_cboMedStore.SelectedIndex = 0;
                }
            }
            this.m_cboStatus.Items.Clear();
            if (this.m_dtOutStoreType != null)
            {
                for (int i = 0; i < this.m_dtOutStoreType.Rows.Count; i++)
                {
                    this.m_cboStatus.Item.Add(m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            //this.m_cboStatus.SelectedIndex = 0;
        }

        private void m_txtFromDept_FocusNextControl(object sender, EventArgs e)
        {
            if (m_cboMedStore.Enabled)
                this.m_cboMedStore.Focus();
            else
                m_txtComment.Focus();
        }

        private void m_dgvDetail_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 5)
            //{
            //    System.Drawing.Rectangle rect =
            //    this.m_dgvDetail.GetCellDisplayRectangle(e.ColumnIndex,
            //    e.RowIndex, true);
            //    this.m_datValidPeriod.Location = new System.Drawing.Point(rect.X + m_dgvDetail.Location.X, rect.Y + m_dgvDetail.Location.Y);
            //    this.m_datValidPeriod.Visible = true;
            //    this.m_datValidPeriod.BringToFront();
            //    this.m_datValidPeriod.Focus();
            //    this.m_datValidPeriod.Select(0, 4);
            //}
            //else
            //{
            //    this.m_datValidPeriod.Visible = false;
            //    //if (e.ColumnIndex == 6)
            //    //{
            //    //    double.TryParse(m_dtOutStorageMedicine.Rows[m_dgvDetail.CurrentCell.RowIndex]["OPAMOUNT_INT"].ToString(), out dblAmount);
            //    //}
            //}
        }

        private void m_dgvDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_txtFromDept.AccessibleName == null)
            {
                MessageBox.Show("��ѡ����ȷ�Ĳ���", "ע��...");
                m_txtFromDept.Focus();
                return;
            }
            if (m_txtFromDept.AccessibleName.Length > 0)
            {
                bool m_blnFound = false;
                for (int i1 = 0; i1 < m_dtDept.Rows.Count; i1++)
                {
                    if (Convert.ToString(m_dtDept.Rows[i1]["deptname_vchr"]) == m_txtFromDept.Text &&
                        Convert.ToString(m_dtDept.Rows[i1]["deptid_chr"]) == m_txtFromDept.AccessibleName)
                    {
                        m_blnFound = true;
                        break;
                    }
                }

                if (!m_blnFound)
                {
                    MessageBox.Show("��ѡ����ȷ�Ĳ���", "ע��...");
                    m_txtFromDept.Focus();
                    return;
                }
            }

            if (m_blnIsCommit)//ֻ�޸�������ͺ���Դ����
            {
                //����Ƿ��ѿ���ⵥ
                bool m_blnHasGenerateInstorageBill = false;
                ((clsCtl_OutStorageMakerOrder)objController).m_lngCheckIfHasGenerateInstorage(m_txtBillId.Text, out m_blnHasGenerateInstorageBill);
                if (m_blnHasGenerateInstorageBill)
                {
                    //MessageBox.Show("�ó��ⵥ��������ⵥ�������޸�!", "ҩ�������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;                   
                }
                
                long lngResult = ((clsCtl_OutStorageMakerOrder)objController).m_lngUpdateTypeAndDept(m_blnHasGenerateInstorageBill);
                
                if (lngResult > 0)
                {
                    MessageBox.Show("�޸ĳɹ�!", "ҩ�������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                long lngRes = ((clsCtl_OutStorageMakerOrder)objController).m_lngSaveOutstorageMedInfo(true);
                m_mthShowRetailMoney();
                if (lngRes > 0)
                {
                    try
                    {
                        //����excel�ļ�������
                        if (m_strExcelFileName.Length > 0)
                        {
                            System.IO.File.Move(m_strExcelFileName, m_strExcelFileName.Substring(0, m_strExcelFileName.Length - 4) + "(�ѵ�).xls");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ҩ�������Ƶ�",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    //    DialogResult drResult = MessageBox.Show("�Ƿ��ӡ��ǰ�����¼?", "ҩ�������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //    if (drResult == DialogResult.Yes)
                    //    {
                    //        ((clsCtl_OutStorageMakerOrder)objController).m_mthPrint();

                    //    }

                }
            }
        }

        private void m_btnInsert_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (this.m_dgvDetail.SelectedCells.Count > 0)
            {
                DialogResult drResult = MessageBox.Show("ȷ��ɾ��ѡ�еĳ����¼��", "ҩ�������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
                ((clsCtl_OutStorageMakerOrder)objController).m_mthDeleteDetail(true);
            }
            else
            {
                return;
            }
        }

        private void m_btnNext_Click(object sender, EventArgs e)
        {
            //DataRow[] drNull = null;
            if (m_dtOutStorageMedicine != null && m_btnDelete.Enabled)
            {
                //drNull = this.m_dtOutStorageMedicine.Select("medicineid_chr is null and opamount_int is null");//ѡ�����õ�����
                //if (drNull != null)
                //{
                //    foreach (DataRow drTemp in drNull)
                //    {
                //        m_dtOutStorageMedicine.Rows.Remove(drTemp);
                //    }
                //}
                //DataTable dtbNew = m_dtOutStorageMedicine.GetChanges(DataRowState.Added);
                //DataTable dtbEdit = m_dtOutStorageMedicine.GetChanges(DataRowState.Modified);
                //if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                //{
                DialogResult drResult = MessageBox.Show("��ǰ�������δ����ļ�¼��ȷ����ղ���д��һ�ŵ�?", "ҩ�������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return;
                    }
                //}
            }
            m_strExcelFileName = string.Empty;
            ((clsCtl_OutStorageMakerOrder)objController).m_mthClear();
            //m_dgvDetail.EnterKeyPress += new com.digitalwave.controls.MedicineStoreControls.EnterKeyPressInCurrentCell(m_dgvDetail_EnterKeyPress);
            m_dgvDetail.SelectionMode = DataGridViewSelectionMode.CellSelect;
            this.m_txtFromDept.Focus();
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
                if (this.m_dtOutStorageMedicine.Rows.Count > 0)
                {
                    DataRow drLast = m_dtOutStorageMedicine.Rows[m_dtOutStorageMedicine.Rows.Count - 1];
                    if (drLast["MEDICINEID_CHR"] == DBNull.Value)
                    {
                        this.m_dgvDetail.Focus();
                        m_dgvDetail.CurrentCell = m_dgvDetail.Rows[this.m_dtOutStorageMedicine.Rows.Count - 1].Cells[1];
                        m_dgvDetail.CurrentCell.Selected = true;
                    }
                }
                else
                {
                    ((clsCtl_OutStorageMakerOrder)objController).m_mthInsertNewMedicineInfo();
                }
            }
        }

        private void m_datValidPeriod_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                DataGridViewCell CurrentCell = this.m_dgvDetail.CurrentCell;
                this.m_datValidPeriod.Visible = false;
                this.m_dgvDetail.CurrentCell.Value = this.m_datValidPeriod.Text;
                this.m_dgvDetail.BringToFront();
                this.m_dgvDetail.Focus();
            }
        }

        private void m_cboMedStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_strStoreid = m_cboMedStore.SelectItemValue != string.Empty ? m_cboMedStore.SelectItemValue : m_cboMedStore.AccessibleName;
        }

        private void m_cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_cboStatus.AccessibleName = m_cboStatus.SelectItemValue != string.Empty ? m_cboStatus.SelectItemValue : m_cboStatus.AccessibleName;
        }

        private void m_cboMedStore_Leave(object sender, EventArgs e)
        {
            this.m_cboStatus.Enter -= new EventHandler(m_cboStatus_Enter);
            this.m_cboMedStore.Enter -= new EventHandler(m_cboStatus_Enter);
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorageMakerOrder)objController).m_mthPrint();
        }

        private void toolStripSeparator5_Click(object sender, EventArgs e)
        {

        }

        string m_strExcelFileName = string.Empty;
        private void m_btnImpMedicine_Click(object sender, EventArgs e)
        {
            if (m_ofdImportExcel.ShowDialog() == DialogResult.OK)
            {
                m_strExcelFileName = string.Empty;
                
                string strErrorInfo = string.Empty;
                DataTable dtb_FromExcel = null;
                try
                {
                    Application.DoEvents();
                    clsPublic.PlayAvi("���ڵ���סԺ�������ݣ����Ժ�...");
                    dtb_FromExcel = clsPub.m_mthShowValues(m_ofdImportExcel.FileName, out strErrorInfo);
                    if (dtb_FromExcel != null && dtb_FromExcel.Rows.Count > 0)
                    {
                        if (((clsCtl_OutStorageMakerOrder)objController).m_lngImportFromExcel(dtb_FromExcel) > 0)
                        {
                            m_strExcelFileName = m_ofdImportExcel.FileName;
                        }

                    }
                    else
                    {
                        MessageBox.Show("��ȡסԺ�������ݴ�������\n\n�����Ϣ��"+strErrorInfo, "ע��...",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }
                }
                catch (Exception ex)
                {
                    clsPublic.CloseAvi();
                    MessageBox.Show(ex.Message);
                    if (dtb_FromExcel == null)
                    {
                        MessageBox.Show(strErrorInfo, "ע��...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                finally
                {
                    clsPublic.CloseAvi();
                }
            }
        }

        private void m_txtFromDept_TextChanged(object sender, EventArgs e)
        {
            if (m_txtFromDept.Text.Length == 0)
            {
                m_txtFromDept.AccessibleName = string.Empty;
            }
        }

        private void m_txtFromDept_ItemSelectedChanged(object sender, com.digitalwave.Controls.clsItemDataEventArg e)
        {
            m_txtFromDept.AccessibleName = m_txtFromDept.StrItemId;
        }

        private void m_txtFromDept_Leave(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// ���ݵ��ݺż��ص��ݣ��������ⵥ�ݱ������ã�ֻ����ֻ������ӡ�͹رչ��ܡ�
        /// </summary>
        /// <param name="p_strBillID"></param>
        public void LoadBill(string p_strBillID)
        {
            ((clsCtl_OutStorageMakerOrder)objController).LoadBill(p_strBillID);
            m_mthShowRetailMoney();
            m_dgvDetail.ReadOnly = true;
        }

        private void m_dgvDetail_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == m_dgvDetail.Columns["amount_int"].Index)
                {
                    double dblTemp = 0;
                    if (double.TryParse(m_dgvDetail[e.ColumnIndex, e.RowIndex].Value.ToString(), out dblTemp))
                    {
                        m_dgvDetail[e.ColumnIndex, e.RowIndex].Value = dblTemp.ToString("F2");
                    }
                    else
                    {
                        m_dgvDetail[e.ColumnIndex, e.RowIndex].Value = 0;
                    }
                }
            }
            catch
            {
            }
        }

        private int m_intColIdx = 0;
        private int m_intRowIdx = 0;
        private void frmOutStorageMakerOrder_Deactivate(object sender, EventArgs e)
        {
            if (m_dgvDetail.Rows.Count > 0 && m_dgvDetail.CurrentCell != null)
            {
                m_intColIdx = m_dgvDetail.CurrentCell.ColumnIndex;
                m_intRowIdx = m_dgvDetail.CurrentCell.RowIndex;
            }
        }

        private void frmOutStorageMakerOrder_Activated(object sender, EventArgs e)
        {
            try
            {
                if (m_dgvDetail.Rows.Count > 0 && m_intColIdx != 0)
                {
                    m_dgvDetail.Focus();
                    m_dgvDetail.CurrentCell = m_dgvDetail.Rows[m_intRowIdx].Cells[m_intColIdx];
                }
            }
            catch
            {
            }
        }

    }
}