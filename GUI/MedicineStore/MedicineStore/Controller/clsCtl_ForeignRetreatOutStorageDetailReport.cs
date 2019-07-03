using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 退药出库报表    /// </summary>
    class clsCtl_ForeignRetreatOutStorageDetailReport : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsDcl_MedicineOut m_objDomain = null;
        public DataTable m_dtbOut;
         /// <summary>
         /// 当前药品出库主表信息
         /// </summary>
        public clsMS_OutStorage_VO m_objCurrentSubArr = null;

        com.digitalwave.iCare.gui.MedicineStore.frmForeignRetreatOutStorageDetailRep m_objViewer;

        public clsCtl_ForeignRetreatOutStorageDetailReport()
        {
            m_objDomain = new clsDcl_MedicineOut();
            clsCtl_ForeignRetreatOutStorageDetail clsFosD = new clsCtl_ForeignRetreatOutStorageDetail();
            clsFosD.getOutStorageDetail_VO(out m_objCurrentSubArr);
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmForeignRetreatOutStorageDetailRep)frmMDI_Child_Base_in;
        }
        #endregion

        #region 打开预览窗体
        /// <summary>
        ///打开预览窗体
        /// </summary>
        internal long m_OutPurchasePrint(clsMS_OutStorage_VO m_objCurrentSubArr)
        {
            
            if (m_objCurrentSubArr == null)
            {
                MessageBox.Show("抱歉，没有数据可打印！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            DataTable p_OutDtbVal = new DataTable();
            this.m_objDomain.m_lngGetOutStorageDetailReport(m_objCurrentSubArr.m_lngSERIESID_INT,m_objViewer.i_showType, out p_OutDtbVal,"");
            DataRow dro;
            DataTable dtb = new DataTable();
            int i_temp=0;

            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(m_objCurrentSubArr.m_strSTORAGEID_CHR, out RoomName);
            if (m_objViewer.i_showType == 0)
            {
                dtb = p_OutDtbVal.Clone();

                //DataView dtv = new DataView();
                //dtv = dtb.DefaultView;
                //dtv.Sort = "medicinetypeid_chr,medicineid_chr";
                //dtb = dtv.ToTable();

                for (int i_low = 0; i_low < p_OutDtbVal.Rows.Count; i_low++)
                {
                    i_temp++;
                    dtb.ImportRow(p_OutDtbVal.Rows[i_low]);
                    //药品和材料分开两张打

                    if (((i_low + 1) >= p_OutDtbVal.Rows.Count) || ((p_OutDtbVal.Rows[i_low]["medicinetypesetid"].ToString()) != (p_OutDtbVal.Rows[i_low + 1]["medicinetypesetid"].ToString())))
                    {
                        int ros = 8 - i_temp % 8;
                        int i_valCount = dtb.Rows.Count + ros;
                        for (int i = 0; i < ros; i++)
                        {
                            dro = dtb.NewRow();
                            dtb.Rows.Add(dro);
                        }
                        i_temp = 0;
                    }
                }

                m_objViewer.datWindow.DataWindowObject = "foreignretreatoutstorage_lj";
                m_objViewer.datWindow.Modify("t_titel.text='" + m_objComInfo.m_strGetHospitalTitle() + "退药出库单" + "'");
            }
            else
            {
                dtb = p_OutDtbVal.Copy();
                m_objViewer.datWindow.DataWindowObject = "foreignretreatoutstorage_cs";
                m_objViewer.datWindow.Modify("t_titel.text='" + m_objComInfo.m_strGetHospitalTitle() + "退货单(" + RoomName+ ")'");
                m_objViewer.datWindow.Modify("t_OUTSTORAGEID.text='" + m_objViewer.strOutputOrder + "'");
               
                
            }
            decimal decBug = Convert.ToDecimal(m_objViewer.strBug);
            string mmm = new Money(decBug).ToString();
            m_objViewer.datWindow.Modify("t_bug.text='" + mmm + "'");
            m_objViewer.datWindow.Modify("t_outDate.text='" + m_objViewer.strOutDate + "'");
            m_objViewer.datWindow.Modify("t_VENDOR.text='" + m_objViewer.strVENDOR + "'");
            m_objViewer.datWindow.Modify("m_txtroom.text='" + RoomName + "'");
            m_objViewer.datWindow.Modify("m_txtman2.text='" + m_objCurrentSubArr.m_strASKERName + "'");
            m_objViewer.datWindow.Modify("m_txtman.text='" + m_objCurrentSubArr.m_strASKERName + "'");

            int m_intShow;
            clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
            m_objDon.m_lngGetIfShowInfo(out m_intShow);
            if (m_intShow == 0)
                m_objViewer.datWindow.Modify("t_info.text=''");  

            m_objViewer.dtb = dtb;
            return 1;

        }
        #endregion
    }



}
