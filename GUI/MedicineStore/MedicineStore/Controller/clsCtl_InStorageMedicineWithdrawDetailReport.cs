using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
   public class clsCtl_InStorageMedicineWithdrawDetailReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDcl_InStorageMedicineWithdrawDetailReport m_objDomain = null;
        private frmInStorageMedicineWithdrawDetailReport m_objViewer;

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInStorageMedicineWithdrawDetailReport)frmMDI_Child_Base_in;
        }
        #endregion

        public clsCtl_InStorageMedicineWithdrawDetailReport()
        {
            m_objDomain = new clsDcl_InStorageMedicineWithdrawDetailReport();
        }

        public void m_mthPring(string strID)
        {
            DataTable dtb = new DataTable();
            m_objDomain.m_lngGetMedicineInnerWithdrawDetailDataReport(strID, out dtb);
            frmInStorageMedicineWithdrawDetailReport frmRepot = new frmInStorageMedicineWithdrawDetailReport();
            frmRepot.m_dtbDetail = dtb.Clone();
            frmRepot.ShowDialog();
        }
       public string getLogo()
       {
           return this.m_objComInfo.m_strGetHospitalTitle();
       }
       public void getPrinttype(out int printType)
       {
           //0伦教 1茶山 2佛二
           this.m_objDomain.m_lngGetPrinType(out printType);
       }
    }
}
