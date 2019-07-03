using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmTranBed : Form
    {
        clsBedManageVO m_objBedVO;
        string m_strAreaId;
        
        internal string m_strBedId;

        public frmTranBed(string p_strAreaId, clsBedManageVO p_objBedVO)
        {
            this.m_objBedVO = p_objBedVO;
            this.m_strAreaId = p_strAreaId;
            InitializeComponent();
        }

        private void frmTranBed_Load(object sender, EventArgs e)
        {
            this.m_lbInpatientId.Text = m_objBedVO.m_strINPATIENTID_CHR;
            this.m_lbName.Text = m_objBedVO.m_strNAME_VCHR;
            this.m_lbSex.Text = m_objBedVO.m_strSEX_CHR;
            this.m_lbSouBed.Text = m_objBedVO.m_strCODE_CHR;

            long lngRes = 0;
            clsT_Bse_Bed_VO[] objBedArr;
            lngRes = new clsDcl_BIHTransfer().m_lngGetBedShortInfoByAreaID(this.m_strAreaId, "1,6", out objBedArr);
            if (lngRes > 0)
            {
                m_cmbBed.DataSource = objBedArr;
                m_cmbBed.DisplayMember = "m_strGetBedCODE";
                m_cmbBed.ValueMember = "m_strGetBedID";
                if (m_cmbBed.Items.Count > 0)
                {
                    this.m_cmbBed.SelectedIndex = 0;
                }
            }
        }

        private void m_cmdOk_Click(object sender, EventArgs e)
        {
            clsT_Bse_Bed_VO bedVO = (clsT_Bse_Bed_VO)this.m_cmbBed.SelectedItem;
            this.m_strBedId = bedVO.m_strGetBedID;

            string strAsk = "确定将" + this.m_lbName.Text + " 转到" + this.m_cmbBed.Text + "床吗？";
            if (MessageBox.Show(strAsk, "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}