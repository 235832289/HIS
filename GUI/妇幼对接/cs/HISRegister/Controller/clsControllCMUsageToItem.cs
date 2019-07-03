using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsControllCMUsageToItem : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControllCMUsageToItem()
        {
            m_objDomain = new clsDomainCMUsageToItem();
        }
        private clsDomainCMUsageToItem m_objDomain = null;
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmCmUsageToItem m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCmUsageToItem)frmMDI_Child_Base_in;
        }
        #endregion
        public void m_mthGetCMUsageInformation()
        {
            long lngRes = -1;
            DataTable m_objTable = null;
            lngRes = m_objDomain.m_lngGetCMUsageInformation(out m_objTable);
            if (lngRes > 0 && m_objTable != null)
            {
                m_objViewer.m_dtgUsa.BeginUpdate();
                m_objViewer.m_dtgUsa.m_mthDeleteAllRow();
                m_objViewer.m_dtgUsa.m_mthSetDataTable(m_objTable);
                m_objViewer.m_dtgUsa.EndUpdate();
            }
        }


    }
}
