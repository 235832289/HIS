using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    class clsCtl_Purchase_DatailReport : com.digitalwave.GUI_Base.clsController_Base
    {

    }
    public struct DetalReportVal
    {
        public DataTable p_dtbVal;
        public string ProviderName;
        public string IncomeBillNumber;
        public string InvoiceNumber;
        public string InComeDate;
        public string ProvidBillNo;
        public string InvoiceDate;
        public string PurchasePerson;
        public string MakeBillPerson;
        public string StroehouseManager;
        public string Accountant;
        public string Remark;
        public string StorageName;
        public string strBigWrith;
    }
}
