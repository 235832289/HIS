using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmFindPatient : com.digitalwave.GUI_Base.frmMDI_Child_Base 
    {
        #region 变量
        public clsPatient_VO m_objPatientVO;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmFindPatient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="clsPatient_VO"></param>
        public frmFindPatient(ref clsPatient_VO p_objPatientVO)
        {
            InitializeComponent();

            this.m_objPatientVO = p_objPatientVO;
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlFindPatient();
            objController.Set_GUI_Apperance(this);
        }

        private void frmCommonFind_Load(object sender, EventArgs e)
        {
              
        }
   

        //private void lsvPatient_DoubleClick(object sender, EventArgs e)
        //{
        //    ((clsCtl_CommonFind)this.objController).m_mthGetPatientinfo();
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public long InitView()
        {
            long ret = ((clsCtlFindPatient)this.objController).GetHisPatientByName(this.m_objPatientVO);
            return ret;
        }

        private void lsvPatient_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                return;
            }
            else
            {
                lsvPatient.Sorting = (lsvPatient.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
                lsvPatient.ListViewItemSorter = new ListViewItemSort(e.Column, lsvPatient.Sorting, lsvPatient);
                lsvPatient.Sort();

                for (int i = 1; i <= lsvPatient.Items.Count; i++)
                {
                    lsvPatient.Items[i - 1].SubItems[0].Text = i.ToString();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.lsvPatient.Items.Count == 0 || this.lsvPatient.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = (DataRow)(this.lsvPatient.SelectedItems[0].Tag);

            this.m_objPatientVO.m_strINPATIENTTEMPID_VCHR = dr["inpatientid_chr"].ToString();
            this.m_objPatientVO.m_strPATIENTID_CHR = dr["patientid_chr"].ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmFindPatient_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                
                default:
                    break;
            }
        }

        private void lsvPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.lsvPatient.Items.Count == 0 || this.lsvPatient.SelectedItems.Count == 0)
                {
                    return;
                }

                DataRow dr = (DataRow)(this.lsvPatient.SelectedItems[0].Tag);

                this.m_objPatientVO.m_strINPATIENTTEMPID_VCHR = dr["inpatientid_chr"].ToString();
                this.m_objPatientVO.m_strPATIENTID_CHR = dr["patientid_chr"].ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
     }
}