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
    public partial class frmHolday : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        clsDcl_BIHTransfer m_objManage;
        /// <summary>
        /// 床位管理VO
        /// </summary>
        clsBedManageVO m_objBed;

        #region 构造函数
        /// <summary>
        /// 床位管理信息VO
        /// </summary>
        /// <param name="p_objBed"></param>
        public frmHolday(clsBedManageVO p_objBed)
        {
            InitializeComponent();
            m_objManage = new clsDcl_BIHTransfer();
            m_objBed = p_objBed;
            m_txtBedCode.Text = m_objBed.m_strCODE_CHR;
            m_txtInPatientID.Text = m_objBed.m_strINPATIENTID_CHR;
            m_txtName.Text = m_objBed.m_strNAME_VCHR;
            m_txtSex.Text = m_objBed.m_strSEX_CHR;
            m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(m_objBed.m_strBIRTH_DAT);
        }
        #endregion

        #region 请假
        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            clsHolidayRecord_VO p_objRecord = new clsHolidayRecord_VO();
            try
            {
                p_objRecord.m_intHOLIDAYS_INT = Convert.ToInt16(m_cmbDays.Text.Trim());
                if (p_objRecord.m_intHOLIDAYS_INT < 1)
                {
                    MessageBox.Show("请假天数必须大于1", "请假", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_cmbDays.Focus();
                    return;
                }
            }
            catch
            {
                MessageBox.Show("请输入有效数字", "请假", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_cmbDays.Focus();
                return;
            }

            p_objRecord.m_strREGISTERID_CHR = m_objBed.m_strREGISTERID_CHR;
            p_objRecord.m_strBedID = m_objBed.m_strBEDID_CHR;
            p_objRecord.m_datSTART_DAT = m_dtStartTime.Value;
            p_objRecord.m_intSTATUS_INT = 1;
            if (LoginInfo.m_strEmpID != "")
            {
                p_objRecord.m_strCREATORID_CHR = LoginInfo.m_strEmpID;
            }
            else
            {
                p_objRecord.m_strCREATORID_CHR = "0000001";
            }
            try
            {
                m_objManage.m_lngHoliday(p_objRecord);
                MessageBox.Show("请假成功！", "请假", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "请假失败");
            }
        }
        #endregion
    }
}