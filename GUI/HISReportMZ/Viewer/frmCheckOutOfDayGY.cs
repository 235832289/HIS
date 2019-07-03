using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmCheckOutOfDayGY : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmCheckOutOfDayGY()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置窗体控制器
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControlCheckOutOfDayGY();
            this.objController.Set_GUI_Apperance(this);
        }

        /// <summary>
        /// 病人身份ID
        /// </summary>
        public System.Collections.ArrayList PayTypeArr = new System.Collections.ArrayList();
        public string strReportTitle = "";
        private void frmCheckOutOfDayGY_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strParam = clsPublic.m_strGetSysparm("0040");
                PayTypeArr = clsPublic.m_ArrGettoken(strParam, ";");
                starDate.Value = Convert.ToDateTime(starDate.Value.Year.ToString() + "-" + starDate.Value.Month.ToString() + "-" + "01");
                this.m_dwShow.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
                this.m_dwShow.DataWindowObject = "d_op_checkoutofday";
                strReportTitle = this.objController.m_objComInfo.m_strGetHospitalTitle() + "     " + this.m_dwShow.Describe("t_title.text");
                this.m_dwShow.Modify("t_title.text = '" + strReportTitle + "'");
                ((clsControlCheckOutOfDayGY)this.objController).Reset();
            }
            catch (Exception)
            {
            }
            this.Cursor = Cursors.Default;
        }

        bool blisDoctorDean = false;
        public bool isDoctorDean
        {
            set
            {
                blisDoctorDean = value;
            }
            get
            {
                return blisDoctorDean;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ((clsControlCheckOutOfDayGY)this.objController).Reset();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void starDate_ValueChanged(object sender, System.EventArgs e)
        {
            ((clsControlCheckOutOfDayGY)this.objController).findhistory();
        }

        private void EndDate_ValueChanged(object sender, System.EventArgs e)
        {
            ((clsControlCheckOutOfDayGY)this.objController).findhistory();
        }

        private void ctlDgFind_m_evtClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (ctlDgFind.RowCount == 1)
                ((clsControlCheckOutOfDayGY)this.objController).dgSelect();
        }

        private void ctlDgFind_m_evtCurrentCellChanged(object sender, System.EventArgs e)
        {
            ((clsControlCheckOutOfDayGY)this.objController).dgSelect();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.m_dwShow.Print(true);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("注意：结帐后不能修改数据，是否要结帐？", "Icare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                ((clsControlCheckOutOfDayGY)this.objController).CheckData();
            }
        }
    }
}