using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Data;
using com.digitalwave.iCare.middletier.BIHOrderServer;


namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmBedPatientList : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// 选择的病人登记号
        /// </summary>
        public ArrayList m_arrPersionID = new ArrayList();
        /// <summary>
        /// 病人数组
        /// </summary>
        public clsBIHCanExecOrder[] arrBed;
        /// <summary>
        /// 不允许执行的欠费的病人id
        /// </summary>
        public ArrayList m_arrPatient = new ArrayList();
        /// <summary>
        /// 需要皮试的但不是阴性的将要提交的医嘱的病人id
        /// </summary>
        public ArrayList m_arrFeelTest = new ArrayList();
        /// <summary>
        /// 状态为0-转抄用（皮试过滤），1-执行用（欠费过滤)
        /// </summary>
        public int m_intStatus = -1;
        public frmBedPatientList()
        {
            InitializeComponent();
        }

        public frmBedPatientList(ArrayList m_arr,int status)
        {
            if (status == 0)
            {
                m_arrFeelTest = m_arr;
            }
            else if (status == 1)
            {
                m_arrPatient = m_arr;
            }
            m_intStatus = status;
            InitializeComponent();
        }


        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_BedPatientList();
            objController.Set_GUI_Apperance(this);
        }

        

        private void m_cmdToCommit_Click(object sender, EventArgs e)
        {
            ((clsCtl_BedPatientList)this.objController).sendTheBill();
            this.DialogResult = DialogResult.OK;
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderExecedPatientList_Load(object sender, EventArgs e)
        {
            ((clsCtl_BedPatientList)this.objController).IniTheForm();
        }

        private void m_chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_BedPatientList)this.objController).SelectAll();
        }

        private void m_dtvPersonList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtl_BedPatientList)this.objController).ChangeTheSelectState(e.RowIndex);
        }

        private void m_dtvPersonList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (m_dtvPersonList.Columns[e.ColumnIndex].Name.Equals("ISINCEPT_INT"))
            {
                ((clsCtl_BedPatientList)this.objController).ChangeTheSelectState(e.RowIndex);
            }
            else
            {
                this.m_dtvPersonList.Rows[e.RowIndex].Cells["ISINCEPT_INT"].Value = "1";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void m_txtArea_TextChanged(object sender, EventArgs e)
        {

        }
    }
}