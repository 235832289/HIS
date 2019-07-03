using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmPretestMedRec : Form
    {
        List<string> lstPutMedId { get; set; }

        public bool IsSave { get; set; }

        string empNo { get; set; }

        public frmPretestMedRec(List<string> _lstPutMedId, string _empNo)
        {
            InitializeComponent();
            lstPutMedId = _lstPutMedId;
            empNo = _empNo;
        }

        private void frmPretestMedRec_Load(object sender, EventArgs e)
        {

        }

        private void btnRec_Click(object sender, EventArgs e)
        {
            string empId = string.Empty;
            if (clsPublic.m_dlgConfirm(this.empNo, out empId) == DialogResult.Yes)
            {
                EntityPretestMedRec vo = null;
                List<EntityPretestMedRec> lstRec = new List<EntityPretestMedRec>();
                foreach (string putMedId in lstPutMedId)
                {
                    vo = new EntityPretestMedRec();
                    vo.putMedId = putMedId;
                    vo.recOperId = empId;
                    vo.recDate = this.dtmRec.Text;
                    vo.recRemark = this.txtRemark.Text.Trim();
                    vo.recStatus = 1;
                    lstRec.Add(vo);
                }
                using (clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject())
                {
                    if (svc.SavePretestMedRec(lstRec) > 0)
                    {
                        MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.IsSave = true;
                        this.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
