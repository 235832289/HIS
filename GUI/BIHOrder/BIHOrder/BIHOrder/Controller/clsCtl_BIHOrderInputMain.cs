using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.BIHOrder.Control;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
   public  class clsCtl_BIHOrderInputMain : com.digitalwave.GUI_Base.clsController_Base
    {
         #region 变量
       clsDcl_BIHOrderInputMain m_objManager = null;
        
        #endregion 

        #region 构造函数
        public clsCtl_BIHOrderInputMain()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            m_objManager = new clsDcl_BIHOrderInputMain();
			
		}
		#endregion 

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmReport_Treat m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReport_Treat)frmMDI_Child_Base_in;

        }
        #endregion
    }
}
