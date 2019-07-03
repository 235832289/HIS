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
    /// ҩ������ѯ����
    /// </summary>
    public partial class frmDrugStorageQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region ����
        /// <summary>
        /// ��������
        /// </summary>
        private string m_strReportName = string.Empty;        
        /// <summary>
        /// ��¼�����ֶ�
        /// </summary>
        private int m_intRecordCount = 0;
        /// <summary>
        /// ��¼��������
        /// </summary>
        public int intRecordCount
        {
            get
            {
                return m_intRecordCount;
            }
            set
            {
                m_intRecordCount = value;
            }
        }
        /// <summary>
        /// ҩƷ������Ϣ��
        /// </summary>
        internal DataTable m_dtMedicineInfo = null;
        /// <summary>
        /// ����
        /// </summary>
        internal DataGridViewComboBoxColumn comculumn = new DataGridViewComboBoxColumn();
        /// <summary>
        /// �ɹ���ʶ
        /// </summary>
        internal DataGridViewComboBoxColumn comculumnprovide = new DataGridViewComboBoxColumn();
        /// <summary>
        /// �ɹ���־
        /// </summary>
        private DataTable m_dtbStorageProvide = new DataTable();
        /// <summary>
        /// �Ƿ�����װ������
        /// </summary>
        private bool m_blnIsLoading = false;
        /// <summary>
        /// ҩƷ������Ϣ
        /// </summary>
        internal clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();
       /// <summary>
       /// ��Ҫ�޸Ļ��ܵļ�¼
       /// </summary>
        private Dictionary<string, string> m_dicStorageRack = new Dictionary<string, string>();
        /// <summary>
        /// �ܷ��޸Ŀ��������0�����ԣ�1���ԡ�
        /// </summary>
        internal int m_intCanModifyAmount = 0;
        /// <summary>
        /// ���洫���ҩ��id
        /// </summary>
        public string[] m_strMedStoreArr = null;
        /// <summary>
        /// �Ƿ�סԺ��λ
        /// </summary>
        private bool m_blnHospital = false;
        internal DataTable m_dtbAmount = new DataTable();
        /// <summary>
        /// ��λ���ܵ�С����
        /// </summary>
        internal frmQueryNavigator fqn = null;
        /// <summary>
        /// 20081030 ��ҩƷ������ҩƷ�󣬲�ѯҩƷ�����û�ҵ�������ʾ
        /// </summary>
        internal bool m_blnFound = false;
        #endregion

        #region �����ʼ��
        /// <summary>
        /// ���췽��
        /// </summary>
        public frmDrugStorageQuery()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��д���෽��
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_DrugStorageQuery();
            objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// ������ʾ����
        /// </summary>
        /// <param name="p_strCanModifyAmount">0�����޸ģ�1���޸�</param>
        /// <param name="m_strMedStordid">��ʾ��ҩ��id</param>
        public void m_mthShow(string p_strCanModifyAmount, string m_strMedStordid)
        {
            m_intCanModifyAmount = Convert.ToInt16(p_strCanModifyAmount);
            m_strMedStoreArr = m_strMedStordid.Split('*');
            Show();
        }

        #endregion

        #region ��ʼ�����ݱ�
        /// <summary>
        /// ��ʼ��DataGridView
        /// </summary>
        internal void m_mthInitDataTable(bool p_blnIsHospital)
        {
            m_blnHospital = p_blnIsHospital;
            #region ����DataGridView��������

            m_dgvDrugStorage.Columns.Clear();

            m_lblCallSum.Text = "0.0000";//������
            m_lblRetailSum.Text = "0.0000";//���۽��

            m_dgvDrugStorage.Columns.Add("colMedicineID", "ҩƷID");
            m_dgvDrugStorage.Columns[0].Width = 56;
            m_dgvDrugStorage.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[0].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            m_dgvDrugStorage.Columns[0].Visible = false;
            m_dgvDrugStorage.Columns[0].Frozen = true;

            m_dgvDrugStorage.Columns.Add("colStorageID", "ҩ��");
            m_dgvDrugStorage.Columns[1].Width = 80;
            m_dgvDrugStorage.Columns[1].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[1].Visible = false;
            m_dgvDrugStorage.Columns[1].Frozen = true;

            m_dgvDrugStorage.Columns.Add("colAssistCode", "����");
            m_dgvDrugStorage.Columns[2].Width = 82;
            m_dgvDrugStorage.Columns[2].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[2].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[2].Frozen = true;

            m_dgvDrugStorage.Columns.Add("colMedicineName", "����");
            m_dgvDrugStorage.Columns[3].Width = 160;
            m_dgvDrugStorage.Columns[3].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[3].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[3].Frozen = true;

            m_dgvDrugStorage.Columns.Add("colMedSpec", "���");
            m_dgvDrugStorage.Columns[4].Width = 60;
            m_dgvDrugStorage.Columns[4].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[4].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[4].Frozen = true;

            m_dgvDrugStorage.Columns.Add("productorid_chr", "��������");
            m_dgvDrugStorage.Columns[5].Width = 90;
            m_dgvDrugStorage.Columns[5].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[5].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[5].Frozen = true;
            m_dgvDrugStorage.Columns[5].Visible = false;

            m_dgvDrugStorage.Columns.Add("colLotNo", "����");
            m_dgvDrugStorage.Columns[6].Width = 70;
            m_dgvDrugStorage.Columns[6].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[6].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[6].Frozen = true;
            
            comculumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comculumn.Name = "colStorageRackID";
            comculumn.HeaderText = "����";
            m_dgvDrugStorage.Columns.Add(comculumn);
            m_dgvDrugStorage.Columns[7].Width = 100;
            m_dgvDrugStorage.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[7].SortMode = DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[7].Frozen = true;
            m_dgvDrugStorage.Columns[7].Visible = false;//20080417 ���ܸ�Ϊ���أ���ͣȱ��־����ά�� 

            comculumnprovide.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            comculumnprovide.Name = "colStorageProvide";
            comculumnprovide.HeaderText = "�ɹ���־";
            m_dgvDrugStorage.Columns.Add(comculumnprovide);
            m_dgvDrugStorage.Columns[8].Width = 100;
            m_dgvDrugStorage.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[8].Frozen = true;
           
            m_dgvDrugStorage.Columns.Add("colMedicineTypeName", "����");
            m_dgvDrugStorage.Columns[9].Width = 90;
            m_dgvDrugStorage.Columns[9].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[9].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[9].Frozen = true;

            if (p_blnIsHospital)
            {
                m_dgvDrugStorage.Columns.Add("colIPRealGross", "ʵ�ʿ��\nסԺ��λ");
            }
            else
            {
                m_dgvDrugStorage.Columns.Add("colIPRealGross","ʵ�ʿ��");// "ʵ�ʿ��\n���ﵥλ");
            }
            m_dgvDrugStorage.Columns[10].Width = 100;
            m_dgvDrugStorage.Columns[10].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[10].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[10].DefaultCellStyle.Format = "0.00";

            if (p_blnIsHospital)
            {
                m_dgvDrugStorage.Columns.Add("colIPAvailaGross", "���ÿ��\nסԺ��λ");
            }
            else
            {
                m_dgvDrugStorage.Columns.Add("colIPAvailaGross","���ÿ��");// "���ÿ��\n���ﵥλ");
            }
            m_dgvDrugStorage.Columns[11].Width = 100;
            m_dgvDrugStorage.Columns[11].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[11].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[11].DefaultCellStyle.Format = "0.00";

            if (p_blnIsHospital)
            {
                m_dgvDrugStorage.Columns.Add("colIPUnit", "סԺ\n��λ");
            }
            else
            {
                m_dgvDrugStorage.Columns.Add("colIPUnit", "��λ");                //"����\n��λ");                
            }
            m_dgvDrugStorage.Columns[12].Width = 45;
            m_dgvDrugStorage.Columns[12].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            m_dgvDrugStorage.Columns[12].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            
            m_dgvDrugStorage.Columns.Add("colRealGross", "ʵ�ʿ��\n��װ��λ");           
            m_dgvDrugStorage.Columns[13].Width = 72;
            m_dgvDrugStorage.Columns[13].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[13].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[13].DefaultCellStyle.Format = "0.00";
            m_dgvDrugStorage.Columns[13].Visible = false;

            m_dgvDrugStorage.Columns.Add("colAvailaGross", "���ÿ��\n��װ��λ");
            m_dgvDrugStorage.Columns[14].Width = 72;
            m_dgvDrugStorage.Columns[14].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[14].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[14].DefaultCellStyle.Format = "0.00";
            m_dgvDrugStorage.Columns[14].Visible = false;

            m_dgvDrugStorage.Columns.Add("colOPUnit", "��װ\n��λ");
            m_dgvDrugStorage.Columns[15].Width = 45;
            m_dgvDrugStorage.Columns[15].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[15].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[15].Visible = false;

            m_dgvDrugStorage.Columns.Add("colWholesalePrice", "���뵥��");
            m_dgvDrugStorage.Columns[16].Width = 88;
            m_dgvDrugStorage.Columns[16].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[16].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[16].DefaultCellStyle.Format = "0.0000";

            m_dgvDrugStorage.Columns.Add("colWholesaleSum", "������");
            m_dgvDrugStorage.Columns[17].Width = 88;
            m_dgvDrugStorage.Columns[17].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[17].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[17].DefaultCellStyle.Format = "0.0000";

            m_dgvDrugStorage.Columns.Add("colRetailPrice", "���۵���");
            m_dgvDrugStorage.Columns[18].Width = 88;
            m_dgvDrugStorage.Columns[18].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[18].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[18].DefaultCellStyle.Format = "0.0000";

            m_dgvDrugStorage.Columns.Add("colRetailSum", "���۽��");
            m_dgvDrugStorage.Columns[19].Width = 88;
            m_dgvDrugStorage.Columns[19].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            m_dgvDrugStorage.Columns[19].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            m_dgvDrugStorage.Columns[19].DefaultCellStyle.Format = "N4";

            m_dgvDrugStorage.Columns.Add("colDate", "ʧЧ����");
            m_dgvDrugStorage.Columns[20].Width = 92;
            m_dgvDrugStorage.Columns[20].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[20].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("colMedicinePrepTypeName", "����");
            m_dgvDrugStorage.Columns[21].Width = 70;
            m_dgvDrugStorage.Columns[21].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[21].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;           

            m_dgvDrugStorage.Columns.Add("ifstop_int", "ͣ��");
            m_dgvDrugStorage.Columns[22].Width = 70;
            m_dgvDrugStorage.Columns[22].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[22].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("noqtyflag_int", "ȱҩ");
            m_dgvDrugStorage.Columns[23].Width = 70;
            m_dgvDrugStorage.Columns[23].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[23].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns.Add("pycode_chr", "ƴ����");
            m_dgvDrugStorage.Columns[24].Width = 70;
            m_dgvDrugStorage.Columns[24].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[24].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;


            m_dgvDrugStorage.Columns.Add("wbcode_chr", "�����");
            m_dgvDrugStorage.Columns[25].Width = 70;
            m_dgvDrugStorage.Columns[25].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            m_dgvDrugStorage.Columns[25].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;

            m_dgvDrugStorage.Columns[16].Visible = false;
            m_dgvDrugStorage.Columns[17].Visible = false;
            m_dgvDrugStorage.Columns[22].Visible = false;
            m_dgvDrugStorage.Columns[23].Visible = false;
            m_dgvDrugStorage.Columns[24].Visible = false;
            m_dgvDrugStorage.Columns[25].Visible = false;

            if (m_rdbTotal.Checked == true)
            {
                m_dgvDrugStorage.Columns[6].Visible = false;
               // m_dgvDrugStorage.Columns[7].Visible = false;
                m_dgvDrugStorage.Columns[8].Visible = false;
                m_dgvDrugStorage.Columns[21].Visible = false;
            }
            else
            {
                m_dgvDrugStorage.Columns[6].Visible = true;
                //m_dgvDrugStorage.Columns[7].Visible = true;
                m_dgvDrugStorage.Columns[8].Visible = true;
                m_dgvDrugStorage.Columns[21].Visible = true;
            }


            #endregion


            for (int i1 = 0; i1 < m_dgvDrugStorage.ColumnCount - 1; i1++)
            {
                m_dgvDrugStorage.Columns[i1].SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                if (i1 != 7 && i1 != 8)
                    m_dgvDrugStorage.Columns[i1].ReadOnly = true;               
            }

            //if (m_intCanModifyAmount == 1 && m_rdbTotal.Checked == false)
            //{
            //    m_dgvDrugStorage.Columns["colAvailaGross"].ReadOnly = false;
            //    m_dgvDrugStorage.Columns["colIPAvailaGross"].ReadOnly = false;
            //}

            #region ����DataGride�ġ�DataPropertyName������
            m_dgvDrugStorage.Columns[0].DataPropertyName = "MEDICINEID_CHR";
            m_dgvDrugStorage.Columns[1].DataPropertyName = "MEDICINEROOMNAME";
            m_dgvDrugStorage.Columns[2].DataPropertyName = "ASSISTCODE_CHR";
            m_dgvDrugStorage.Columns[3].DataPropertyName = "MEDICINENAME_VCHR";
            m_dgvDrugStorage.Columns[4].DataPropertyName = "MEDSPEC_VCHR";
            m_dgvDrugStorage.Columns[5].DataPropertyName = "productorid_chr";
            m_dgvDrugStorage.Columns[6].DataPropertyName = "LOTNO_VCHR";
            m_dgvDrugStorage.Columns[7].DataPropertyName = "storagerackid_chr";
            m_dgvDrugStorage.Columns[8].DataPropertyName = "canprovide_int";    
            m_dgvDrugStorage.Columns[9].DataPropertyName = "MEDICINETYPENAME_VCHR";            
            m_dgvDrugStorage.Columns[10].DataPropertyName = "REALGROSS_INT";
            m_dgvDrugStorage.Columns[11].DataPropertyName = "AVAILAGROSS_INT";
            m_dgvDrugStorage.Columns[12].DataPropertyName = "UNIT_CHR";
            m_dgvDrugStorage.Columns[13].DataPropertyName = "OPREALGROSS_INT";
            m_dgvDrugStorage.Columns[14].DataPropertyName = "OPAVAILAGROSS_INT";
            m_dgvDrugStorage.Columns[15].DataPropertyName = "OPUNIT_CHR";
            m_dgvDrugStorage.Columns[16].DataPropertyName = "WHOLESALEPRICE_INT";
            m_dgvDrugStorage.Columns[17].DataPropertyName = "WHOLESALESUM";
            m_dgvDrugStorage.Columns[18].DataPropertyName = "RETAILPRICE_INT";
            m_dgvDrugStorage.Columns[19].DataPropertyName = "RETAILSUM";            
            m_dgvDrugStorage.Columns[20].DataPropertyName = "VALIDPERIOD_DAT";
            m_dgvDrugStorage.Columns[21].DataPropertyName = "MEDICINEPREPTYPENAME_VCHR";            
            m_dgvDrugStorage.Columns[22].DataPropertyName = "ifstop_int";
            m_dgvDrugStorage.Columns[23].DataPropertyName = "noqtyflag_int";
            m_dgvDrugStorage.Columns[24].DataPropertyName = "pycode_chr";
            m_dgvDrugStorage.Columns[25].DataPropertyName = "wbcode_chr";
            //m_dgvDrugStorage.AutoResizeColumnHeadersHeight();
            #endregion
        }
        #endregion
        
        #region �����¼�
        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            if (m_blnChecking) return;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ((clsCtl_DrugStorageQuery)objController).m_mthQuery();
                ((clsCtl_DrugStorageQuery)objController).m_mthBindStorageRack();
                //m_mthBindStorageProvide();
                //m_dgvDrugStorage.AutoResizeColumns();
                //m_dicStorageRack.Clear();
                
            }
            catch(Exception objEx)
            {
                MessageBox.Show(objEx.Message, "��ѯ����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStorageQuery)objController).m_mthPrint();
        }

        private void m_btnExport_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStorageQuery)objController).m_mthExportToExcel();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.Collect();
        }

        private void m_rdbNotZero_CheckedChanged(object sender, EventArgs e)
        {
            m_btnQuery.PerformClick();
        }

        bool m_blnChecking = false;
        private void m_rdbTotal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                m_blnChecking = true;
                if (m_rdbTotal.Checked == true)
                {
                    lblList.Text = "ҩƷͳ���б�";
                    m_rbtAllProvide.Checked = true;
                    groupBox3.Enabled = false;
                }
                else
                {
                    lblList.Text = "ҩƷ��ϸ�б�";
                    groupBox3.Enabled = true;
                }

                if (m_dgvDrugStorage.RowCount > 0)
                {
                    m_dgvDrugStorage.DataSource = null;
                }

                m_lblRecordNo.Left = lblList.Left + lblList.Width + 10;
                intRecordCount = 0;
                displayRecordNo();
                m_blnChecking = false;
                m_btnQuery.PerformClick();
            }
            catch
            {
            }
            finally
            {
                m_blnChecking = false;
            }
        }

        private void frmDrugStorageQuery_Load(object sender, EventArgs e)
        {
            m_objMedicineBase.m_strMedicineID = "";
            m_objMedicineBase.m_strAssistCode = "";
            m_objMedicineBase.m_strMedicineName = "";
            m_objMedicineBase.m_strMedSpec = "";

            m_datBeginDate.Text = clsPub.CurrentDateTimeNow.Date.ToString("yyyy��MM��dd��");
            m_datEndDate.Text = clsPub.CurrentDateTimeNow.Date.AddYears(3).ToString("yyyy��MM��dd��");

            this.m_dgvDrugStorage.AutoGenerateColumns = false;
            m_dgvDrugStorage.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            ((clsCtl_DrugStorageQuery)objController).m_mthShowStorage();
            ((clsCtl_DrugStorageQuery)objController).m_mthShowMedicineType();
            ((clsCtl_DrugStorageQuery)objController).m_mthShowMedicinePreptype();
            this.m_datBeginDate.Focus();

           // clsPub.m_mthGetMedBaseInfo(m_strMedStoreArr[0],out m_dtMedicineInfo);
            m_mthBindStorageProvide();
            this.Text = "ҩ������ѯ(" + m_cboStorage.Text + ")";
        }

        private void m_cboStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_DrugStorageQuery)objController).m_mthShowMedicineType();            
        }

        private void m_dgvDrugStorage_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            m_blnIsLoading = true;
            displayRecordNo();
            m_blnIsLoading = false;
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_dtMedicineInfo == null || this.m_dtMedicineInfo.Rows.Count == 0)
                {
                    clsPub.m_mthGetMedBaseInfo(m_strMedStoreArr[0], out m_dtMedicineInfo);
                }
                ((clsCtl_DrugStorageQuery)objController).m_mthShowQueryMedicineForm(this.m_txtMedicineCode.Text,m_dtMedicineInfo);
            }
        }
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_dgvDrugStorage.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);

            if (((clsCtl_DrugStorageQuery)objController).m_lngSaveProvide(m_dtbAmount) > 0)
            {
                m_btnQuery.PerformClick();
                m_dtbAmount.Clear();
            }            
        }

        internal bool m_blnEditing = false;
        private void m_dgvDrugStorage_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //ȡ���ϲ�����
            //if (!string.IsNullOrEmpty(Convert.ToString(m_dgvDrugStorage[0, e.RowIndex].Value))//ҩƷ��
            //    //&& !string.IsNullOrEmpty(Convert.ToString(m_dgvDrugStorage[5,e.RowIndex].Value))//����
            //    && !string.IsNullOrEmpty(Convert.ToString(m_dgvDrugStorage[6, e.RowIndex].Value)))//����
            //{
            //    if (!m_dicStorageRack.ContainsKey(m_dgvDrugStorage[0, e.RowIndex].Value.ToString() + m_dgvDrugStorage[5, e.RowIndex].Value.ToString()))
            //    {
            //        m_dicStorageRack.Add(m_dgvDrugStorage[0, e.RowIndex].Value.ToString() + m_dgvDrugStorage[5, e.RowIndex].Value.ToString(), Convert.ToString(m_dgvDrugStorage[6, e.RowIndex].Value));
            //    }
            //    else
            //    {
            //        m_dicStorageRack[m_dgvDrugStorage[0, e.RowIndex].Value.ToString() + m_dgvDrugStorage[5, e.RowIndex].Value.ToString()] = Convert.ToString(m_dgvDrugStorage[6, e.RowIndex].Value);
            //    }
            //}          
            if (m_blnEditing) return;
            //if (e.ColumnIndex == m_dgvDrugStorage.Columns["colStorageProvide"].Index )
            //{
                ((clsCtl_DrugStorageQuery)objController).m_mthEdit(e.ColumnIndex);
            //}
        }

        private void m_dgvDrugStorage_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if ((e.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[e.RowIndex].ErrorText = "����";
                view.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "����";

                e.ThrowException = false;
            }
        }

        private void m_dgvDrugStorage_Sorted(object sender, EventArgs e)
        {
            m_mthChangeForeColor();
        }
        #endregion

        #region ��ʾ��¼��
        /// <summary>
        /// ��ʾ��¼��
        /// </summary>
        internal void displayRecordNo()
        {
            if (m_blnIsLoading) return;
            if ((intRecordCount > 0) && (m_dgvDrugStorage.RowCount > 0))
                m_lblRecordNo.Text = (m_dgvDrugStorage.CurrentRow.Index + 1).ToString() + "/" + m_dgvDrugStorage.RowCount.ToString();
            else
                m_lblRecordNo.Text = "0/0";
            m_mthChangeForeColor();
        }
        #endregion    

        /// <summary>
        /// ��־��ɫ���ٶȽ�����
        /// </summary>
        private void m_mthChangeForeColor()
        { 
            for (int i1 = 0; i1 < m_dgvDrugStorage.Rows.Count; i1++)
            {

                if (m_dgvDrugStorage["noqtyflag_int", i1].Value.ToString() != "" && Convert.ToInt16(m_dgvDrugStorage["noqtyflag_int", i1].Value) == 1)
                {
                    m_dgvDrugStorage.Rows[i1].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (m_dgvDrugStorage["ifstop_int", i1].Value.ToString() != "" && Convert.ToInt16(m_dgvDrugStorage["ifstop_int", i1].Value) == 1)
                {
                    m_dgvDrugStorage.Rows[i1].DefaultCellStyle.ForeColor = Color.Olive;
                }
                //ͣ����ȱҩͬʱ���ڵ������
            }
        }

        /// <summary>
        /// ��־��ɫ���·������᲻�����Ч�ʣ�δ�⣩
        /// </summary>
        private void m_mthChangeForeColor2()
        {
            foreach (DataGridViewRow row in m_dgvDrugStorage.Rows)
            {

                if (Convert.ToString(m_dgvDrugStorage["noqtyflag_int", row.Index].Value) == "1")
                {
                    m_dgvDrugStorage.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Red;
                }
                if (Convert.ToString(m_dgvDrugStorage["ifstop_int", row.Index].Value) == "1")
                {
                    m_dgvDrugStorage.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Olive;
                }
                //ͣ����ȱҩͬʱ���ڵ������
            }
        }

        private void m_dgvDrugStorage_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if(e.ColumnIndex == 22)
            //if (e.Value == null) return;
            //m_mthChangeForeColor2();
        }

        private void m_dgvDrugStorage_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (Convert.ToString(m_dgvDrugStorage["ifstop_int", e.RowIndex].Value) == "1")
            //{
            //    m_dgvDrugStorage.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Olive;
            //}

            //if (Convert.ToString(m_dgvDrugStorage["noqtyflag_int", e.RowIndex].Value) == "1")
            //{
            //    m_dgvDrugStorage.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
            //}
        }

        private void m_dgvDrugStorage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            displayRecordNo();
        }

        private void m_btnLocate_Click(object sender, EventArgs e)
        {
            if(fqn == null || fqn.IsDisposed)
            {
                fqn = new frmQueryNavigator(m_txtMedicineCode.Text);
                fqn.m_dtbMedicinDict = this.m_dtMedicineInfo;
                fqn.OnLocateMedicine += new LocateMedicine(fqn_OnLocateMedicine);
                fqn.Deactivate += new EventHandler(fqn_Deactivate);
                fqn.Location = new Point(510, 95);
                fqn.ShowInTaskbar = false;
                fqn.TopMost = true;
                fqn.Show();
            }
            else
            {
                fqn.Visible = true;
                fqn.m_txtMedicine.Text = m_txtMedicineCode.Text;
            }    
        }

        void fqn_Deactivate(object sender, EventArgs e)
        {
            fqn.Visible = false;
        }

        internal bool blnRestart = false;
        internal void fqn_OnLocateMedicine(string p_strMedicineName, short p_intDirection)
        {
            if(m_dgvDrugStorage.Rows.Count == 0)
                return;
            if(p_strMedicineName == string.Empty)
                return;

            int intStartIndex;
            if(blnRestart)
                intStartIndex = 0;
            else
                intStartIndex = 1;
            switch(p_intDirection)
            {
                case 1:
                    for(int i1 = intStartIndex; i1 < m_dgvDrugStorage.Rows.Count; i1++)
                    {
                        if(m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            m_blnFound = true;
                            break;
                        }
                    }
                    break;
                case 2:
                    for(int i1 = m_dgvDrugStorage.SelectedRows[0].Index - 1; i1 > 0; i1--)
                    {
                        if(m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            m_blnFound = true;
                            break;
                        }
                    }
                    break;
                case 3:
                    if(m_dgvDrugStorage.SelectedRows[0].Index == m_dgvDrugStorage.Rows.Count - 1)
                        return;
                    for(int i1 = m_dgvDrugStorage.SelectedRows[0].Index + 1; i1 < m_dgvDrugStorage.Rows.Count; i1++)
                    {
                        if(m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            m_blnFound = true;
                            break;
                        }
                    }
                    break;
                case 4:
                    for(int i1 = m_dgvDrugStorage.Rows.Count - 1; i1 > 0; i1--)
                    {
                        if(m_dgvDrugStorage["colAssistCode", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                            m_dgvDrugStorage["colMedicineName", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["pycode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0 ||
                        m_dgvDrugStorage["wbcode_chr", i1].Value.ToString().ToUpper().IndexOf(p_strMedicineName.ToUpper()) == 0)
                        {
                            m_dgvDrugStorage.Rows[i1].Selected = true;
                            m_dgvDrugStorage.CurrentCell = m_dgvDrugStorage.Rows[i1].Cells["colMedicineName"];
                            m_blnFound = true;
                            break;
                        }
                    }
                    break;
            }
        }

        private void frmDrugStorageQuery_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }

        private void m_chkValidDate_CheckedChanged(object sender, EventArgs e)
        {
            this.m_datBeginDate.Enabled=this.m_datEndDate.Enabled=this.m_chkValidDate.Checked;
        }

        #region �󶨿ɹ���־
        /// <summary>
        /// �󶨿ɹ���־
        /// </summary>
        internal void m_mthBindStorageProvide()
        {
            comculumnprovide.DataSource = null;
            m_dtbStorageProvide = new DataTable();
            try
            {
                m_dtbStorageProvide.Columns.Add("canprovide_int", typeof(Int16));
                m_dtbStorageProvide.Columns.Add("canprovidename", typeof(string));
                m_dtbStorageProvide.Rows.Add(1, "�ɹ�");
                m_dtbStorageProvide.Rows.Add(0, "���ɹ�");

                comculumnprovide.DataSource = m_dtbStorageProvide;
                comculumnprovide.ValueMember = "canprovide_int";
                comculumnprovide.DisplayMember = "canprovidename";

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "�ɹ���־���س���", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        #endregion

        private void m_txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicineCode.Text.Trim().Length == 0)
            {
                m_txtMedicineCode.Tag = "";
            }
        }
        private void m_dgvDrugStorage_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (m_dgvDrugStorage.CurrentCell == null) return;
            if (m_intCanModifyAmount == 1 && e.ColumnIndex == m_dgvDrugStorage.Columns["colIPAvailaGross"].Index && m_rdbDetail.Checked == true)
            {
                frmEditAvailableStorage frmEAS = new frmEditAvailableStorage();
                frmEAS.OnSaveAmount += new OnSave(frmEAS_OnSaveAmount);
                DataRow drvSelectedRow = ((DataRowView)(m_dgvDrugStorage.CurrentCell.OwningRow.DataBoundItem)).Row;
                frmEAS.m_strMedicineID = drvSelectedRow["medicineid_chr"].ToString();
                frmEAS.m_intOPChargeFlage = Convert.ToInt16(drvSelectedRow["opchargeflg_int"]);
                frmEAS.m_intIPChargeFlage = Convert.ToInt16(drvSelectedRow["ipchargeflg_int"]);
                frmEAS.m_dblPackQty = Convert.ToDouble(drvSelectedRow["packqty_dec"]);
                frmEAS.m_txtMedicineName.Text = drvSelectedRow["MEDICINENAME_VCHR"].ToString();
                frmEAS.m_txtLotno.Text = drvSelectedRow["LOTNO_VCHR"].ToString();
                frmEAS.m_txtUnit.Text = drvSelectedRow["unit_chr"].ToString();
                frmEAS.m_blnIsHospital = m_blnHospital;
                clsDS_StorageHistory_VO objHistory = null;
                ((clsCtl_DrugStorageQuery)objController).m_lngGetAmountBySeriesID(Convert.ToInt64(drvSelectedRow["seriesid_int"]), out objHistory);
                objHistory.m_strMODIFYUSERID_CHR = LoginInfo.m_strEmpID;
                if (m_blnHospital)
                {
                    if (frmEAS.m_intIPChargeFlage == 0)
                        frmEAS.m_txtOldAmount.Text = objHistory.m_dblOPAVAILABLEGROSS_NUM.ToString();
                    else
                        frmEAS.m_txtOldAmount.Text = objHistory.m_dblIPAVAILABLEGROSS_NUM.ToString();
                }
                else
                {
                    if (frmEAS.m_intOPChargeFlage == 0)
                        frmEAS.m_txtOldAmount.Text = objHistory.m_dblOPAVAILABLEGROSS_NUM.ToString();
                    else
                        frmEAS.m_txtOldAmount.Text = objHistory.m_dblIPAVAILABLEGROSS_NUM.ToString();
                }   
                frmEAS.m_objHistory = objHistory;
                if (frmEAS.ShowDialog() == DialogResult.None)
                    frmEAS.Visible = true;
            }
        }

        void frmEAS_OnSaveAmount(clsDS_StorageHistory_VO objHistory)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (((clsCtl_DrugStorageQuery)objController).m_lngSaveAmount(objHistory) > 0)
                {                    
                    ((clsCtl_DrugStorageQuery)objController).m_mthQuery();
                    ((clsCtl_DrugStorageQuery)objController).m_mthBindStorageRack();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        private void m_txtMedicineCode_MouseDown(object sender, MouseEventArgs e)
        {
            m_txtMedicineCode.SelectAll();
        }

        private void m_lsbMediciePreptype_Enter(object sender, EventArgs e)
        {
            m_lsbMediciePreptype.Size = new Size(106, 86);
        }

        private void m_lsbMediciePreptype_Leave(object sender, EventArgs e)
        {
            m_lsbMediciePreptype.Size = new Size(106, 18);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            m_lsbMediciePreptype.Size = new Size(106, 18);
        }

        private void m_lsbMediciePreptype_MouseClick(object sender, MouseEventArgs e)
        {
            m_lsbMediciePreptype.Size = new Size(106, 86);
        }
    }
}