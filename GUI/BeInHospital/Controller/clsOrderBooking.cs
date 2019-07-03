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
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsOrderBooking : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclOrderBooking m_objDomain;
        private frmOrderBooking m_objViewer;
        private DataView m_dvFilter;
        private clsBrithdayToAge m_objAge;

        //住院登记号列表
        private Hashtable m_hasRegId;
        private string m_strBedId = "";

        public clsOrderBooking()
        {
            this.m_objDomain = new clsDclOrderBooking();
            m_objAge = new clsBrithdayToAge();
        }

       #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOrderBooking)frmMDI_Child_Base_in;
        }
        #endregion

        internal DataStore dsPrint;
        internal DataStore dsPrintPat;

        public void m_mthInit()
        {
            dsPrint = null;
            dsPrint = new DataStore();
            dsPrint.LibraryList = clsPublic.PBLPath;
            dsPrint.DataWindowObject = "d_orderbooking_print";

            dsPrintPat = null;
            dsPrintPat = new DataStore();
            dsPrintPat.LibraryList = clsPublic.PBLPath;
            dsPrintPat.DataWindowObject = "d_orderbooking_pat";
        }

        /// <summary>
        /// 
        /// </summary>
        public void SeachData()
        {
            string strAreaId = this.m_objViewer.m_txtArea.Value;
            if(strAreaId == "" || strAreaId == null)
                return;

            string strBeginDate = this.m_objViewer.m_dtpBeginDate.Text;
            string strEndDate = this.m_objViewer.m_dtpEndDate.Text;

            this.m_dvFilter = null;
                      
            this.m_hasRegId = null;
            DataTable dtResult;
            long lngRes = this.m_objDomain.GetOrderBook(strAreaId, strBeginDate, strEndDate, out dtResult);

            if (lngRes > 0 && dtResult != null)
            {
                //DataColumn ageCol = dtResult.Columns.Add("age_chr", typeof(string));
                //ageCol.AllowDBNull = true;

                this.m_dvFilter = new DataView(dtResult);
                
                //取入院登记Id
                //this.m_hasRegId = new Hashtable();
                //string regId;
                //for (int i = 0; i < m_dvFilter.Count; i++)
                //{
                //    regId = m_dvFilter[i]["REGISTERID_CHR"].ToString();
                //    if (!this.m_hasRegId.Contains(regId))
                //    {
                //        this.m_hasRegId.Add(regId, regId);
                //    }
                //}

                //显示
                DwRetrieve();
            }
        }

        internal void DwRetrieve()
        {
            this.m_objViewer.m_dgvBookingList.Rows.Clear();

            if (this.m_dvFilter == null) return;

            string filter;
            filter = "1=1";
            
            int status = this.m_objViewer.m_cmbStatus.SelectedIndex - 1;
            if (status > -1)
            {
                filter += " and BOOKSTATUS_INT = " + status.ToString();
            }

            if (this.m_objViewer.m_cmbPrintFlag.SelectedIndex == 1)
            {
                //未打印
                filter += " and PRINT_FLAG is null";
            }
            else if (this.m_objViewer.m_cmbPrintFlag.SelectedIndex == 2)
            {
                //已打印
                filter += " and PRINT_FLAG = '1'";
            }

            if (this.m_strBedId != "")
            {
                filter += " and registerid_chr in (" + this.m_strBedId + ")";
            }

            this.m_dvFilter.RowFilter = filter;
            if (this.m_dvFilter.Count == 0)
                return;

            for (int i = 0; i < this.m_dvFilter.Count; i++)
            {
                string[] s = new string[14];
                s[0] = this.m_dvFilter[i]["BOOKID_INT"].ToString();
                s[1] = this.m_dvFilter[i]["CURAREA"].ToString();
                s[2] = this.m_dvFilter[i]["code_chr"].ToString();
                s[3] = this.m_dvFilter[i]["lastname_vchr"].ToString();
                s[4] = this.m_dvFilter[i]["inpatientid_chr"].ToString();
                s[5] = this.m_dvFilter[i]["sex_chr"].ToString();
                s[6] = this.m_dvFilter[i]["ORDERNAME_VCHR"].ToString();

                if (this.m_dvFilter[i]["BOOKSTATUS_INT"].ToString() == "0")
                {
                    s[7] = "预约未确认";
                }
                else if (this.m_dvFilter[i]["BOOKSTATUS_INT"].ToString() == "1")
                {
                    s[7] = "预约通过";
                }
                else
                {
                    s[7] = "预约未通过";
                }

                s[8] = this.m_dvFilter[i]["BOOK_DAT"].ToString();
                s[9] = this.m_dvFilter[i]["REMARK_VCHR"].ToString();

                if (this.m_dvFilter[i]["PRINT_FLAG"].ToString() == "1")
                {
                    s[10] = "已打印";
                }
                else
                {
                    s[10] = "未打印";
                }
                s[11] = this.m_dvFilter[i]["OPERATE_DAT"].ToString();
                s[12] = this.m_dvFilter[i]["SENDER"].ToString();
                s[13] = this.m_dvFilter[i]["ORDERID_CHR"].ToString();

                m_dvFilter[i]["age_chr"] = m_objAge.m_strGetAge(m_dvFilter[i]["BIRTH_DAT"]);

                this.m_objViewer.m_dgvBookingList.Rows.Add(s);
            }

            try
            {
                if (this.dsPrint == null || this.dsPrintPat == null)
                {
                    this.m_mthInit();
                }

                this.dsPrint.Retrieve(this.m_dvFilter.ToTable());
                this.dsPrintPat.Retrieve(this.m_dvFilter.ToTable());

                this.dsPrint.Modify("st_date.Text='" + this.m_objViewer.m_dtpBeginDate.Text + "-" + this.m_objViewer.m_dtpEndDate.Text + "'");
            }
            catch (Exception obj)
            {
                MessageBox.Show("Error: " + obj.Message);
            }            
        }

        internal void BedFilter()
        {
            //ArrayList arr = new ArrayList();
            //frmBedPatientList objForm = new frmBedPatientList(this.m_hasRegId);
            //objForm.m_txtArea.Tag = this.m_objViewer.m_txtArea.Value;
            //objForm.m_txtArea.Text = this.m_objViewer.m_txtArea.Text;
            //if (objForm.ShowDialog() == DialogResult.OK)
            //{
            //    arr = objForm.m_arrBedId;
            //    this.m_strBedId = "";
            //    for (int i = 0; i < arr.Count; i++)
            //    {
            //        m_strBedId += "'" + arr[i] + "',";
            //    }
            //    this.m_strBedId = m_strBedId.TrimEnd(",".ToCharArray());
              
            //}
            //else
            //{
            //    this.m_strBedId = "";
            //}
            ArrayList arr = new ArrayList();
            frmPatientList objForm = new frmPatientList(this.m_dvFilter);

            if (objForm.ShowDialog() == DialogResult.OK)
            {
                arr = objForm.m_arrRegId;
                string strRegId = "";
                for (int i = 0; i < arr.Count; i++)
                {
                    strRegId += "'" + arr[i] + "',";
                }
                this.m_strBedId = strRegId.TrimEnd(",".ToCharArray());
                //m_cmdQuery_Click(null, null);
                //if (strRegId == "") return;

               
            }
            else
            {
                this.m_strBedId = "";
            }
            DwRetrieve();
        }

        /// <summary>
        /// 
        /// </summary>
        public void PrintPat()
        {
            //int currentRow = this.m_objViewer.dw_seach.CurrentRow;
            //if (currentRow <=0)
            //    return;
            //Sybase.DataWindow.SelectedData sData =  this.m_objViewer.dw_seach.SelectedData;
            if (this.m_objViewer.m_dgvBookingList.SelectedRows == null || this.m_objViewer.m_dgvBookingList.SelectedRows.Count == 0)
                return;
            
            string strBookId = "";

            for (int i = 0; i < this.m_objViewer.m_dgvBookingList.SelectedRows.Count; i++)
            {
                strBookId += this.m_objViewer.m_dgvBookingList.SelectedRows[i].Cells["bookId"].Value.ToString() + ",";
            }
            
            if(strBookId == "") return;

            strBookId = strBookId.TrimEnd(",".ToCharArray());
            //decimal bookId = this.m_objViewer.dw_seach.GetItemDecimal(currentRow, "t_opr_bih_order_booking_bookid_int");
            this.dsPrintPat.SetFilter("t_opr_bih_order_booking_bookid_int in (" + strBookId + ")");
            this.dsPrintPat.Filter();
            if (this.dsPrintPat.RowCount > 0)
            {                
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.dsPrintPat.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.dsPrintPat.Print(false, false);

                    this.m_objDomain.UpdataPrintFlagById(strBookId);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void PrintAll()
        {            
            if (this.dsPrintPat.RowCount < 1)
                return;

            string strBookId = "";
            for (int i = 0; i < this.m_objViewer.m_dgvBookingList.Rows.Count; i++)
            {
                strBookId += this.m_objViewer.m_dgvBookingList.Rows[i].Cells["bookId"].Value.ToString() + ",";
             }

            if (strBookId == "") return;

            strBookId = strBookId.TrimEnd(",".ToCharArray());            
            System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

            //选择打印机
            if (pDialog.ShowDialog() == DialogResult.OK)
            {
                this.dsPrintPat.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                this.dsPrintPat.Print(false, false);

                this.m_objDomain.UpdataPrintFlagById(strBookId);
            }
        }

        internal void OpentApplyForm()
        {
            //Sybase.DataWindow.SelectedData sData = this.m_objViewer.dw_seach.SelectedData;
            if (this.m_objViewer.m_dgvBookingList.SelectedRows == null || this.m_objViewer.m_dgvBookingList.SelectedRows.Count == 0)
                return;

            //int currentRow = 0;
            string strOrderId = "";
            //for (int i = 1; i < this.m_objViewer.dw_seach.RowCount + 1; i++)
            //{
                //if (this.m_objViewer.dw_seach.IsSelected(i))
                //{
            strOrderId = this.m_objViewer.m_dgvBookingList.SelectedRows[0].Cells["orderId"].Value.ToString();

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
                //}
            //}
            
        }
    }
}
