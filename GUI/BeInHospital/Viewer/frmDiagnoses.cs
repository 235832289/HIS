using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmDiagnoses : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        string m_strDiagnoses;

        DataView m_dvDiagnoses;

        //0 出院处用，1 医嘱用
        int m_intType = 0;

        string m_strRegisterId;
                
        public frmDiagnoses()
        {
            InitializeComponent();
        }

        public frmDiagnoses(string strDiagnoses, bool blnCheck)
        {
            InitializeComponent();

            if (blnCheck == true)
            {
                this.chkDiseasetype.Checked = true;
                this.chkDiseasetype.Enabled = false;
            }
        }

        public frmDiagnoses(string strDiagnoses)
        {
            this.m_strDiagnoses = strDiagnoses;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strDiagnoses">诊断内容</param>
        /// <param name="strRegisterId">住院登记Id</param>
        /// <param name="inType">0 出院处用，1 医嘱调用</param>
        public frmDiagnoses(string strDiagnoses, string strRegisterId, int inType)
        {
            this.m_strDiagnoses = strDiagnoses;
            this.m_intType = inType;
            this.m_strRegisterId = strRegisterId;
            InitializeComponent();
        }

        private void frmDiagnoses_Load(object sender, EventArgs e)
        {
            this.m_txtDiagnoses.Text = this.m_strDiagnoses;
        }

        private void m_dwDisease_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_dwDisease.RowCount < 1) return;

            int currentRow;
            currentRow = this.m_dwDisease.CurrentRow;

            string disease = this.m_dwDisease.GetItemString(currentRow, "diseasename_vchr");

            this.m_txtDiagnoses.Text = this.m_txtDiagnoses.Text + disease + ";";
        }

        private void m_cmdFind_Click(object sender, EventArgs e)
        {
            string filter = this.m_txtFind.Text.Trim();

            if (filter == null || filter == "")
            {
                return;
            }

            this.m_dwDisease.SetRedrawOff();

            this.Cursor = Cursors.WaitCursor;
            long lngReg = -1;
            DataTable dt;

            lngReg = new clsDclBihLeaHos().GetDisease(filter.ToUpper(), out dt);
            if (lngReg > 0)
            {
                this.m_dwDisease.Retrieve(dt);

                //this.m_dvDiagnoses = new DataView(dt);
            }

            this.m_dwDisease.SetRedrawOn();
            this.m_dwDisease.Refresh();
            this.Cursor = Cursors.Default;
        }

        private void m_cmdOk_Click(object sender, EventArgs e)
        {
            if (this.m_txtDiagnoses.Text == null || this.m_txtDiagnoses.Text.Trim() == "")
            {
                MessageBox.Show("不能保存空白诊断。", "提示");
                return;
            }

            if (this.m_intType == 1)
            {
                //医嘱界面调用，直接保存出院诊断到入院登记表
                //long lngReg = new clsDclBihLeaHos().UpdateRegisterOutDiagnose(this.m_strRegisterId, this.m_txtDiagnoses.Text.Trim());
                long lngReg = new clsDclBihLeaHos().UpdateRegisterOutDiagnose(this.m_strRegisterId, this.m_txtDiagnoses.Text.Trim(), this.chkDiseasetype.Checked);
                if (lngReg > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("保存出院诊断失败。","错误");
                    return;
                }
            }
            else
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

        private void m_dwDisease_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            if (e.RowNumber > 0)
            {
                this.m_dwDisease.SelectRow(0, false);
                this.m_dwDisease.SelectRow(e.RowNumber, true);
            }
        }

        private void m_dwDisease_DataWindowCreated(object sender, Sybase.DataWindow.DataWindowCreatedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            long lngReg = -1;
            DataTable dt;

            lngReg = new clsDclBihLeaHos().GetDisease(out dt);
            if (lngReg > 0)
            {
                this.m_dwDisease.Retrieve(dt);

                this.m_dvDiagnoses = new DataView(dt);
            }
            this.Cursor = Cursors.Default;
        }

    }
}