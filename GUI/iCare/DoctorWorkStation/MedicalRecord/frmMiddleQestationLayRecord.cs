using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using iCareData;
using System.Drawing.Printing;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.Utility.Controls;

namespace iCare
{
    public partial class frmMiddleQestationLayRecord : iCare.frmBaseCaseHistory
    {
          #region 全局变量
        private com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objEmployeeSign = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
        private clsEmrSignToolCollection m_objSign;
          #endregion
        public frmMiddleQestationLayRecord()
        {
            m_objSign = new clsEmrSignToolCollection();
            InitializeComponent();
            m_objSign.m_mthBindEmployeeSign(m_cmdOper, m_txtOperator, 1,true, clsEMRLogin.LoginInfo.m_strEmpID);
            m_objSign.m_mthBindEmployeeSign(m_cmdDealwith, m_txtlsvDealwith, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
        }

        private void frmMiddleQestationLayRecord_Load(object sender, EventArgs e)
        {

        }
    }
}