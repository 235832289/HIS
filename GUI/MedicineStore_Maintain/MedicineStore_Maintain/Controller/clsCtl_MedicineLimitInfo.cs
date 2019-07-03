using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药库药品上下限明细查询 
    /// 2008.7.15 chongkun.wu
    /// </summary>
   public class clsCtl_MedicineLimitInfo:com.digitalwave .GUI_Base .clsController_Base
   {
       #region 变量声明
       /// <summary>
       /// 窗体对象
       /// </summary>
       private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmMedicineLimitInfo m_objViewer;
       /// <summary>
       /// 药品行数
       /// </summary>
       private static int s_intRow = 0;
       /// <summary>
       /// 领域层变量 
       /// </summary>
       private clsDcl_MedicineLimitInfo m_objDomain = new clsDcl_MedicineLimitInfo();
       #endregion

       #region 设置窗体对象
       /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedicineLimitInfo )frmMDI_Child_Base_in;
        }
        #endregion

        #region 气球提示
        public void m_mthShowBall()
       {
           if(s_intRow !=0)
           {
           string m_strShowInfo = s_intRow.ToString() + "种药品低于库存下限";
           this.m_objViewer.notifyIconLowMedicineNotice.ShowBalloonTip(1, "库存通知", m_strShowInfo, System.Windows.Forms.ToolTipIcon.Info);
           }
           // //
           //System.Windows.Forms.NotifyIcon m_CtlNotifyIcon = new System.Windows.Forms.NotifyIcon();
           //m_CtlNotifyIcon.Text = "药品低库存通知";
           //m_CtlNotifyIcon.Visible = true;
           //m_CtlNotifyIcon.ShowBalloonTip(1, "库存通知", "", System.Windows.Forms.ToolTipIcon.Info);

       }
        #endregion

       #region DGV填充数据
       /// <summary>
       /// 填充数据DGV
       /// </summary>
       public void m_mthFill(string p_strStoreStyle,string p_strStoreid)
       {

           DataTable dtMedicinInfo = new DataTable();
           this .m_objDomain.m_lngGetMedicineInfo(p_strStoreStyle,p_strStoreid,ref dtMedicinInfo );
           int intTempRow=dtMedicinInfo .Rows .Count ;
           if(intTempRow >0)
           {
               m_objViewer.toolStripLabelInfo.Text = "    共"+intTempRow.ToString ()+"种药品低于库存下限";
           }
           else if(intTempRow ==0)
           {
               m_objViewer.toolStripLabelInfo.Text = "没有药品低于库存下限";
           }
           this.m_objViewer.dgvMedicineInfo.DataSource = dtMedicinInfo;
           //监测到有新药品低库存提示
           if(s_intRow !=dtMedicinInfo .Rows .Count)
           {
               s_intRow = dtMedicinInfo.Rows.Count;
               m_mthShowBall();
           }
           dtMedicinInfo.Dispose();
       }

       /// <summary>
       /// 药品定位
       /// </summary>
       public void m_mthToPosition()
       {
           for (int intI = 0; intI < s_intRow;intI ++ )
           {
               int intTxtLength = this.m_objViewer.toolStripTextBox1.Text.Length;
               int intCellLingth = this.m_objViewer.dgvMedicineInfo.Rows[intI].Cells["pycode_chr"].Value.ToString().Length;
               if (intTxtLength < intCellLingth )
               {
                   if (m_objViewer.toolStripTextBox1.Text.ToUpper () == this.m_objViewer.dgvMedicineInfo.Rows[intI].Cells["pycode_chr"].Value .ToString().Remove (intTxtLength ).ToString())
                   {
                       this.m_objViewer .dgvMedicineInfo .CurrentCell =this .m_objViewer .dgvMedicineInfo[0,intI ];
                       return;
                   }
 
               }

           }
 
       }
        #endregion

   }
}
