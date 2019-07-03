using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.IO;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    class clsCtl_StockAutoGenerate : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 窗体
        /// </summary>
        com.digitalwave.iCare.gui.MedicineStore.frmStockAutoGenerate m_objViewer;

        /// <summary>
        /// 明细数据表
        /// </summary>  
        internal DataTable dtbResult = null;
        clsDcl_StockAutoGenerate m_objDomain;

        #region 构造函数
        /// <summary>
        /// 采购入库
        /// </summary>
        public clsCtl_StockAutoGenerate()
        {
            m_objDomain = new clsDcl_StockAutoGenerate();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmStockAutoGenerate)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化子表作为DataGridView数据源的DataTable
        /// <summary>
        /// 初始化子表作为DataGridView数据源的DataTable
        /// </summary>
        public void m_mthInitMedicineTable()
        {
            dtbResult = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("IfCheck"),new DataColumn("medicineid_chr"), new DataColumn("assistcode_chr"), new DataColumn("medicinename_vchr"),
                new DataColumn("medspec_vchr"),new DataColumn("productorid_chr"),new DataColumn("amount",typeof(double)),new DataColumn("unit_vchr"),
                new DataColumn("vendorid_chr"),new DataColumn("vendorname"),new DataColumn("instoragedate_dat",typeof(DateTime)),new DataColumn("callprice_int",typeof(double)),
            new DataColumn("stocksum",typeof(double)),new DataColumn("remark_vchr"),new DataColumn("tiptoplimit_int",typeof(double)),new DataColumn("neaplimit_int",typeof(double)),new DataColumn("currentgross_num",typeof(double))};
            dtbResult.Columns.AddRange(dcColumns);
            dtbResult.PrimaryKey = new DataColumn[] { dtbResult.Columns["medicineid_chr"] };
        }
        #endregion

        internal long m_lngGetDetailForGenerate(string m_strStorageID)
        {
            long lngRes =  m_objDomain.m_lngGetDetailForGenerate(m_strStorageID, ref dtbResult);
            m_objViewer.m_dgvDrugStorage.DataSource = dtbResult;
            return lngRes;
        }

        internal void m_mthGenerate(clsMS_StockPlan_Detail_VO[] p_objDetailArr)
        {
            frmStockPlan_Detail frmDetail = new frmStockPlan_Detail(m_objViewer.m_strStorageID);           
            frmDetail.SetDetail(p_objDetailArr);
            frmDetail.ShowDialog();
        }
    }
}
