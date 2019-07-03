using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Drawing.Printing;

using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 
    /// </summary>
    public class clsCtlOerderBookingRe : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclOrderBooking m_objDomain;
        private frmOrderBookingRe m_objViewer;
        private DataTable m_dtOrderBooking;

        public clsCtlOerderBookingRe()
        {
            this.m_objDomain = new clsDclOrderBooking();
        }

       #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOrderBookingRe)frmMDI_Child_Base_in;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void SeachData()
        {
            string applyType = this.m_objViewer.m_txtApplyType.Value;
            if (applyType == "" || applyType == null)
                return;

            string strBeginDate = this.m_objViewer.m_dtpBeginDate.Text + ":00";
            string strEndDate = this.m_objViewer.m_dtpEndDate.Text + ":59";

            //DataTable dtResult;
            long lngRes = this.m_objDomain.GetOrderBookByDate(strBeginDate, strEndDate, this.m_objViewer.LoginInfo.m_strEmpID, out m_dtOrderBooking);

            //this.m_objViewer.dw_seach.ShareData(this.m_objViewer.dsPrint);

            if (lngRes > 0 && m_dtOrderBooking != null)
            {
                this.m_objViewer.dw_seach.SetRedrawOff();

                this.m_objViewer.dw_seach.Retrieve(m_dtOrderBooking);

                //this.m_objViewer.dsPrintPat.Retrieve(dtResult);

                //string applyType = this.m_objViewer.m_txtApplyType.Value;
                
                //int status = this.m_objViewer.m_cmbStatus.SelectedIndex;
                
                int status = this.m_objViewer.m_cmbStatus.SelectedIndex - 1;
                if (status > -1)
                {
                    if (applyType != "0")
                    {
                        this.m_objViewer.dw_seach.SetFilter("t_opr_bih_order_booking_bookstatus_int = " + status.ToString() + " and t_opr_bih_order_booking_apply_type_int = " + applyType);                    
                    }
                    else
                    {
                        this.m_objViewer.dw_seach.SetFilter("t_opr_bih_order_booking_bookstatus_int = " + status.ToString());
                    }
                }
                else
                {
                    //状态为全部
                    if (applyType != "0")
                    {
                        this.m_objViewer.dw_seach.SetFilter("t_opr_bih_order_booking_apply_type_int = " + applyType);
                    }
                    else
                    {
                        this.m_objViewer.dw_seach.SetFilter("");
                    }
                }

                this.m_objViewer.dw_seach.Filter();
                this.m_objViewer.dw_seach.Sort();
                this.m_objViewer.dw_seach.CalculateGroups();

                this.m_objViewer.dw_seach.SetRedrawOn();
                this.m_objViewer.dw_seach.Refresh();

                //this.m_objViewer.dsPrint.Modify("st_date.Text='" + this.m_objViewer.m_dtpBeginDate.Text + "-" + this.m_objViewer.m_dtpEndDate.Text + "'");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void PrintPat()
        {
            //int currentRow = this.m_objViewer.dw_seach.CurrentRow;
            //if (currentRow <=0)
            //    return;

            //decimal bookId = this.m_objViewer.dw_seach.GetItemDecimal(currentRow, "t_opr_bih_order_booking_bookid_int");
            //this.m_objViewer.dsPrintPat.SetFilter("t_opr_bih_order_booking_bookid_int = " + bookId.ToString());
            //this.m_objViewer.dsPrintPat.Filter();
            //if (this.m_objViewer.dsPrintPat.RowCount == 1)
            //    this.m_objViewer.dsPrintPat.Print(false, true);
        }


        /// <summary>
        /// 
        /// </summary>
        public void PrintAll()
        {
            //this.m_objViewer.dsPrintPat.SetFilter("");
            //this.m_objViewer.dsPrintPat.Filter();
            //if (this.m_objViewer.dsPrintPat.RowCount < 1)
            //    return;

            //this.m_objViewer.dsPrintPat.Print(false, true);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowBookingInf()
        {
            if (this.m_dtOrderBooking == null)
                return;

            int currentRow = this.m_objViewer.dw_seach.CurrentRow;
            if (currentRow <= 0)
                return;

            decimal bookId = this.m_objViewer.dw_seach.GetItemDecimal(currentRow, "t_opr_bih_order_booking_bookid_int");
            DataView dv = new DataView(m_dtOrderBooking);
            dv.RowFilter = "BOOKID_INT = " + bookId.ToString();
            int cnt = dv.Count;
            if (cnt < 1)
                return;

            //dv[0];
            frmOrderBookingInf obInf = new frmOrderBookingInf(dv[0]);
            obInf.ShowDialog();

            if (obInf.DialogResult == DialogResult.OK)
            {
                SeachData();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void GetBySearchSentence(string p_strSql)
        {
            this.m_objViewer.dw_seach.Reset();

            //DataTable dtResult;
            long lngRes = this.m_objDomain.GetBySearchSentence(p_strSql, out m_dtOrderBooking);

            //this.m_objViewer.dw_seach.ShareData(this.m_objViewer.dsPrint);

            if (lngRes > 0 && m_dtOrderBooking != null)
            {
                this.m_objViewer.dw_seach.SetRedrawOff();

                this.m_objViewer.dw_seach.Retrieve(m_dtOrderBooking);

                this.m_objViewer.dw_seach.Sort();
                this.m_objViewer.dw_seach.CalculateGroups();

                this.m_objViewer.dw_seach.SetRedrawOn();
                this.m_objViewer.dw_seach.Refresh();

                //this.m_objViewer.dsPrint.Modify("st_date.Text='" + this.m_objViewer.m_dtpBeginDate.Text + "-" + this.m_objViewer.m_dtpEndDate.Text + "'");
            }
        }

        internal void OpentApplyForm()
        {
            if (this.m_dtOrderBooking == null)
                return;

            int currentRow = this.m_objViewer.dw_seach.CurrentRow;
            if (currentRow <= 0)
                return;

           
            string strOrderId = "";

            strOrderId = this.m_objViewer.dw_seach.GetItemString(currentRow, "t_opr_bih_order_booking_orderid_chr").ToString();

            if (strOrderId == "")
                return;

            string strApplyId = "";
            long r = this.m_objDomain.GetApplyIdByOrderId(strOrderId, out strApplyId);
            if (r > 0 && strApplyId != "")
            {
                com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
                objfrm.OpenForm(strApplyId);
                return;
            }
        }
    }
}

