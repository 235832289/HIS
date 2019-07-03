using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsCtl_SingleItemDiscount 的摘要说明。
    /// </summary>
    public class clsCtl_SingleItemDiscount : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDcl_ChargeMaintenance objSvc = null;
        public clsCtl_SingleItemDiscount()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            objSvc = new clsDcl_ChargeMaintenance();
        }
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmSingleItemDiscount m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmSingleItemDiscount)frmMDI_Child_Base_in;
        }
        #endregion
        #region
        private DataTable dt;
        private string strItemID = "";
        public void m_mthFindData(string strID)
        {
            strItemID = strID;
            if (m_objViewer.m_dtbChargeItem != null && m_objViewer.m_dtbChargeItem.Rows.Count > 0)
            {
                this.m_objViewer.dataGrid1.DataSource = m_objViewer.m_dtbChargeItem;
            }
            else
            {
                long ret = objSvc.m_mthFindData(strID, out dt);
                dt.TableName = "Table1";
                this.m_objViewer.dataGrid1.DataSource = dt;
                if (m_objViewer.m_blnUseByAddingNewMedicine)
                    m_objViewer.m_dtbChargeItem = dt.Copy();
            }
        }
        #endregion
        #region 保存数据
        public void m_mthSave()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i].RowState == DataRowState.Modified)
                {
                    this.m_mthUpdateData(strItemID, dt.Rows[i]["COPAYID_CHR"].ToString().Trim(), dt.Rows[i]["DECDISCOUNT"].ToString().Trim());
                }
            }
            this.m_objViewer.Cursor = Cursors.Default;
            dt.AcceptChanges();
        }
        private void m_mthUpdateData(string strItemID, string strCopayID, string strValue)
        {
            objSvc.m_mthUpdateData(strItemID, strCopayID, strValue);
        }
        #endregion
    }
}
