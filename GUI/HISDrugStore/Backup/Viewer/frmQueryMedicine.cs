                                                                                                                                                       using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ѡ�����ҩƷ
    /// </summary>
    public partial class frmQueryMedicine : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// ȷ������������ǰ���ҵ�ǰ��������Ч��Ϣʱ�����¼�
        /// </summary>
        /// <param name="p_objOutMedicinArr">����ҩƷ��Ϣ</param>
        /// <returns></returns>
        public delegate long BeforeCommitQureyMedicine(clsDS_StorageMedicineShow[] p_objOutMedicinArr);

        /// <summary>
        /// ҩƷ��������
        /// </summary>
        internal double m_dblAmount = 0d;
        /// <summary>
        /// ȫ��ѡ��ҩƷ����
        /// </summary>
        internal double m_dblAllAmount = 0d;
        /// <summary>
        /// ҩƷ��Ϣ
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        ///  ȷ������������ǰ���ҵ�ǰ��������Ч��Ϣʱ�����¼�
        /// </summary>
        public event BeforeCommitQureyMedicine BeforeCommit;
        /// <summary>
        /// ����ҩƷ��Ϣ
        /// </summary>
        private clsDS_StorageMedicineShow[] m_objOutMedicinArr = null;
        /// <summary>
        /// ��ȡ����ҩƷ��Ϣ
        /// </summary>
        public clsDS_StorageMedicineShow[] m_ObjOutMedicinArr
        {
            get
            {
                return m_objOutMedicinArr;
            }
        }
        /// <summary>
        /// ��Ӧ�ĳ��ⵥ��ϸ�����кţ��޸�ʱʹ�ã�
        /// </summary>
        public long m_lngSeriesID;
        /// <summary>
        /// ���ӵ�����
        /// </summary>
        public int m_intVisibleRowCount = 0;
        public bool m_blnIsHospital = false;
        /// <summary>
        ///  �������Ʋ����
        /// </summary>        
        public override void CreateController()
        {
            this.objController = new clsCtl_QueryMedicine();
            this.objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// ѡ�����ҩƷ
        /// </summary>
        public frmQueryMedicine()
        {
            InitializeComponent();
            m_dgvQueryMedicineInfo.AutoGenerateColumns = false;
            
        }

        /// <summary>
        /// ҩƷ����ҩƷ��Ϣ���
        /// </summary>
        /// <param name="p_dblAmount">ҩƷ��������</param>
        public frmQueryMedicine(double p_dblAmount) 
            : this()
        {
            m_dblAmount = p_dblAmount;

            ((clsCtl_QueryMedicine)objController).m_mthInitDataSouce(ref m_dtbMedicineInfo);
            m_dgvQueryMedicineInfo.DataSource = m_dtbMedicineInfo;
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            int intStatus = 1;
            m_objOutMedicinArr = ((clsCtl_QueryMedicine)objController).m_objGetVOFromTable(out intStatus);
            if (intStatus == 0)
            {
                return;
            }

            long lngRes = 1;
            if (m_objOutMedicinArr != null && m_objOutMedicinArr.Length > 0 && BeforeCommit != null)
            {
                lngRes = BeforeCommit(m_objOutMedicinArr);
            }

            if (lngRes > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }       
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        

        /// <summary>
        /// ����ҩƷ�����Ϣ
        /// </summary>
        public void m_mthSetMedicineVO(clsDS_StorageDetail_VO[] p_objSTDetail, Hashtable hstNoChange,Hashtable hstCurrent) //clsDS_UpdateStorageBySeriesID_VO[] p_objForUpdateArr)
        {
            if (p_objSTDetail == null)
            {
                return;
            }
            ((clsCtl_QueryMedicine)objController).m_mthSetDataToUI(p_objSTDetail, hstNoChange, hstCurrent);
        }

        private void frmQueryMedicine_Load(object sender, EventArgs e)
        {
            if (m_blnIsHospital)
            {
                m_dgvQueryMedicineInfo.Columns["unit_chr"].HeaderText = "סԺ��λ";
            }

            if (m_dgvQueryMedicineInfo.Rows.Count > 0)
            {
                m_dgvQueryMedicineInfo.CurrentCell = m_dgvQueryMedicineInfo.Rows[0].Cells[14];
                m_dgvQueryMedicineInfo.Focus();
                m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
            }
            bool p_blnAllZero = true;
            foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
            {
                if(Convert.ToDouble(dgvRow.Cells["realgross_int"].Value) != 0)
                    p_blnAllZero = false;
            }
            if (p_blnAllZero)
            {
                m_ckbShowZero.Text = "ֻ������";
                m_ckbShowZero.Enabled = false;
            }
            else
            {
                m_ckbShowZero.Checked = false;
            }
        }

        private void m_dgvQueryMedicineInfo_EnterKeyPress(DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = true;
            try
            {               
                if (CurrentCell != null && CurrentCell.ColumnIndex == 14)
                {
                    for(int i1 = CurrentCell.RowIndex+1;i1 < m_dgvQueryMedicineInfo.Rows.Count;i1++)
                    {
                        if (m_dgvQueryMedicineInfo[14, i1].Visible == false)
                            continue;
                        
                        this.m_dgvQueryMedicineInfo.CurrentCell = this.m_dgvQueryMedicineInfo[14, i1];
                        this.m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
                        return;                        
                    }
                    m_cmdOK.Focus();

                    //if (CurrentCell.RowIndex == m_intVisibleRowCount -1)//this.m_dgvQueryMedicineInfo.Rows.Count - 1)
                    //    m_cmdOK.Focus();
                    //else
                    //{
                    //    int iRowIndex = CurrentCell.RowIndex + 1;

                    //    while (m_dgvQueryMedicineInfo[CurrentCell.ColumnIndex, iRowIndex].Visible == false)
                    //    {
                    //        iRowIndex++;
                    //    }
                    //    this.m_dgvQueryMedicineInfo.CurrentCell = this.m_dgvQueryMedicineInfo[CurrentCell.ColumnIndex, iRowIndex];
                    //    this.m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
                    //}
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// �����������ƣ�Ĭ��"��������"
        /// </summary>
        /// <param name="p_strAmountName">��������</param>
        internal void m_mthSetAmountName(string p_strAmountName)
        {
            m_dgvtxtOutNumber.HeaderText = p_strAmountName;
        }

        /// <summary>
        /// ��ʾ�������
        /// </summary>
        internal void m_mthShowInStorageAmount()
        {
            this.Size = new Size(this.Size.Width + 91, this.Size.Height);
        }

        private void m_dgvQueryMedicineInfo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.ColumnIndex == 14)
            {
                try
                {
                    double p_dblAmount = 0d;
                    double.TryParse(Convert.ToString(m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells[14].Value), out p_dblAmount);                    
                    double p_dblPack = Convert.ToDouble(m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["packqty_dec"].Value);
                    double p_dblCharge = 0;
                    if (m_blnIsHospital)
                    {
                        p_dblCharge = Convert.ToDouble(m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["ipchargeflg_int"].Value);
                        if (p_dblCharge == 0)
                        {
                            m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["m_dgvtxtOutNumber"].Value = p_dblAmount.ToString("F2");
                        }
                        else
                        {
                            m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["m_dgvtxtOutNumber"].Value = Convert.ToDouble(p_dblAmount / p_dblPack).ToString("F2");
                        }
                    }
                    else
                    {
                        p_dblCharge = Convert.ToDouble(m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["opchargeflg_int"].Value);
                        if (p_dblCharge == 0)
                        {
                            m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["m_dgvtxtOutNumber"].Value = p_dblAmount.ToString("F2");
                        }
                        else
                        {
                            m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["m_dgvtxtOutNumber"].Value = Convert.ToDouble(p_dblAmount / p_dblPack).ToString("F2");
                        }
                    }
                }
                catch
                {
                    m_dgvQueryMedicineInfo.Rows[e.RowIndex].Cells["m_dgvtxtOutNumber"].Value = 0.00;
                }
            }
        }

        private void m_dgvQueryMedicineInfo_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_ckbShowZero_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_dtbMedicineInfo.Rows.Count == 0) return;
                if (m_ckbShowZero.Checked)
                {
                    foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
                    {
                        dgvRow.Visible = true;
                    }
                    m_intVisibleRowCount = m_dgvQueryMedicineInfo.Rows.Count;
                }
                else
                {
                    m_intVisibleRowCount = m_dgvQueryMedicineInfo.Rows.Count;
                    foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
                    {
                        if (Convert.ToDouble(dgvRow.Cells["realgross_int"].Value) != 0)
                        {
                            m_dgvQueryMedicineInfo.CurrentCell = dgvRow.Cells["amount_int"];
                            m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
                            break;
                        }
                    }
                    foreach (DataGridViewRow dgvRow in m_dgvQueryMedicineInfo.Rows)
                    {
                        if (Convert.ToDouble(dgvRow.Cells["realgross_int"].Value) == 0)
                        {
                            dgvRow.Cells["amount_int"].Value = 0;
                            dgvRow.Visible = false;
                            m_intVisibleRowCount--;
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}