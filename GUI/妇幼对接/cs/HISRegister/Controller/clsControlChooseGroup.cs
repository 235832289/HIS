using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
   public  class clsControlChooseGroup : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体，初始化变量
        private clsdomiandoctorworkflow m_objDomain;
        private frmAidChooseGroup m_objViewer;
        public clsControlChooseGroup()
        {
            m_objDomain = new clsdomiandoctorworkflow();
        }
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAidChooseGroup)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取专家处方信息
        /// <summary>
        /// 获取专家处方信息
        /// </summary>
        /// <param name="dtResult"></param>
        public void m_GetGroupInfo(ref DataTable dtResult)
        {
            this.m_objDomain.m_lngGetGroupInfo(ref dtResult);
        }
        #endregion
    }
    
}
