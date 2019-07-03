using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_ChargeList : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_InputOrder m_objManage = null;

        #endregion

        public clsCtl_ChargeList()
        {
            m_objManage = new clsDcl_InputOrder();
        }

        #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmChargeList m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmChargeList)frmMDI_Child_Base_in;

        }
        #endregion

        internal void m_lngGetOrderDicChargeByCode(string strFindCode, int m_intClass, string m_strORDERCATEID_CHR, bool m_blLessMedControl, string p_strMedDeptId, out clsBIHOrderDic[] arrDic, out DataSet m_dsDicChargeSet)
        {
            long lngRes = m_objManage.m_lngGetOrderDicChargeByCode(strFindCode, m_intClass, m_strORDERCATEID_CHR, m_blLessMedControl, p_strMedDeptId, out  arrDic, out  m_dsDicChargeSet, m_objViewer.isChildPrice);
        }
    }
}
