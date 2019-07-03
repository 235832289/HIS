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
    class clsOrderBookingInf : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmOrderBookingInf m_objViewer;
        private clsDclOrderBooking m_objDomain;
        
        private string m_bookId;

        public clsOrderBookingInf()
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
            m_objViewer = (frmOrderBookingInf)frmMDI_Child_Base_in;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataView"></param>
        public void initData(DataRowView dataView)
        {
            if (dataView == null)
                return;

            this.m_objViewer.m_lbArea.Text = dataView["CURAREA"].ToString();
            this.m_objViewer.m_lbBedNo.Text = dataView["code_chr"].ToString();
            this.m_objViewer.m_lbName.Text = dataView["lastname_vchr"].ToString();
            this.m_objViewer.m_lbOrderName.Text = dataView["ORDERNAME_VCHR"].ToString();
            this.m_objViewer.m_lbInPatientId.Text = dataView["inpatientid_chr"].ToString();

            DateTime tempDate;
            try
            {
                tempDate = Convert.ToDateTime(dataView["BIRTH_DAT"].ToString());
                this.m_objViewer.m_lbAge.Text = new clsBrithdayToAge().m_strGetAge(tempDate);
            }
            catch
            {
                this.m_objViewer.m_lbAge.Text = "";
            }
            

            m_bookId = dataView["BOOKID_INT"].ToString();

            string bookingDate = dataView["BOOK_DAT"].ToString();
            if (bookingDate == null || bookingDate == "")
            {
                this.m_objViewer.m_dtpBookDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                this.m_objViewer.m_dtpBookDate.Text = Convert.ToDateTime(bookingDate).ToString("yyyy-MM-dd HH:mm");
            }

            this.m_objViewer.m_cmbStatus.SelectedIndex = Convert.ToInt16(dataView["BOOKSTATUS_INT"].ToString()) - 1;

        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateOrderBooking()
        {
            int status = this.m_objViewer.m_cmbStatus.SelectedIndex + 1;

            long lngReg;

            if (status == 2)
            {
                lngReg = this.m_objDomain.UpdateOrderBooking(m_bookId,
                        null,
                        status.ToString(),
                        this.m_objViewer.m_txtRemark.Text,
                        this.m_objViewer.LoginInfo.m_strEmpID);
            }
            else
            {
                lngReg = this.m_objDomain.UpdateOrderBooking(m_bookId,
                        this.m_objViewer.m_dtpBookDate.Text,
                        status.ToString(),
                        this.m_objViewer.m_txtRemark.Text,
                        this.m_objViewer.LoginInfo.m_strEmpID);
            }

            if (lngReg > 0)
            {
                this.m_objViewer.DialogResult = DialogResult.OK;
                this.m_objViewer.Close();
            }
            else
            {
                MessageBox.Show("更新预约单失败！","错误");
                this.m_objViewer.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
