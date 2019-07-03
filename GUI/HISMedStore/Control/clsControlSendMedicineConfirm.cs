using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 发药确认窗口界面的控制类
    /// </summary>
    public class clsControlSendMedicineConfirm : com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// 
        /// </summary>
        public clsControlSendMedicineConfirm()
        {
            m_objDomain = new clsDomainControlOPMedStore();
        }
        #region 设置窗体对象
        clsDomainControlOPMedStore m_objDomain;
        /// <summary>
        /// 
        /// </summary>
        public frmSendMedicineConfirm m_objViewer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmSendMedicineConfirm)frmMDI_Child_Base_in;
        }
        #endregion
        public void m_mthJudgeEMP(string m_strDeptID, string m_strDeptSelfCode, ref string m_strEMPNO, ref string m_strEMPName)
        {
           
            long lngRes = -1;
            lngRes = m_objDomain.m_lngJudgeEmpByIDAndCode(m_strDeptID, m_strDeptSelfCode, out m_strEMPNO, out m_strEMPName) ;
        
        }
        public void m_mthJudgeEMPByEMPNO(string m_strEMPNO, ref string m_strEMPid, ref string m_strEMPName)
        {

            long lngRes = -1;
            lngRes = m_objDomain.m_lngJudgeEmpByEmpNo(m_strEMPNO, out m_strEMPid, out m_strEMPName);

        }
    }
}
