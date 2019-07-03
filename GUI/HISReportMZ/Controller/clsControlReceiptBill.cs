using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsControlReceiptBill : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        /// <summary>
        /// clsDcl_ReceiptBill
        /// </summary>
        private clsDcl_ReceiptBill objSvc;
        #endregion

        #region ����
        /// <summary>
        /// ����
        /// </summary>
        public clsControlReceiptBill()
        {
            objSvc = new clsDcl_ReceiptBill();
        }
        #endregion

        #region ��ӡ������ϸ
        /// <summary>
        /// ��ӡ������ϸ
        /// </summary>
        /// <param name="p_strChargeNo"></param>
        /// <param name="p_strHospitalName"></param>
        /// <param name="p_strPrinterName"></param>
        public void m_mthPrintChargeEntry(string p_strChargeNo, string p_strHospitalName, string p_strPrinterName)
        {
            DataTable dtPatInfo = new DataTable();
            DataTable dtChargeEntry = new DataTable();

            //��ȡ������Ϣ
            objSvc.m_lngGetPatientInfo(p_strChargeNo, ref dtPatInfo);
            //��ȡ��ϸ����
            objSvc.m_lngGetRecipeDataByChargeNo(p_strChargeNo, ref dtChargeEntry);

            if (dtChargeEntry.Rows.Count > 0)
            {
                DataRow dr = null;
                DataStore dsBill = new DataStore();
                
                dsBill.LibraryList = Application.StartupPath + "\\pb_op.pbl";
                dsBill.DataWindowObject = "d_op_receipebill";

                dr = dtPatInfo.Rows[0];
                dsBill.Modify("t_text.text='" + p_strHospitalName + "�����շ���ϸ" + "'");
                dsBill.Modify("t_time.text='" + dr["recorddate_dat"].ToString() + "'");
                dsBill.Modify("t_name.text='" + dr["patientname_chr"].ToString() + "'");
                dsBill.Modify("t_patientcardid.text='" + dr["patientcardid_chr"].ToString() + "'");
                dsBill.Modify("t_invoicenumber.text='" + dr["invoiceno_vchr"].ToString() + "'");

                int row = 1;
                for (int i = 0; i < dtChargeEntry.Rows.Count; i++)
                {
                    dr = dtChargeEntry.Rows[i];

                    row = dsBill.InsertRow(0);
                    dsBill.SetItemString(row, "name", dr["name"].ToString().Trim() + "(" + dr["dec"].ToString().Trim() + ")");
                    dsBill.SetItemString(row, "unit", dr["unit"].ToString().Trim());
                    dsBill.SetItemDecimal(row, "price", clsPublic.ConvertObjToDecimal(dr["price"]));
                    dsBill.SetItemDecimal(row, "count", clsPublic.ConvertObjToDecimal(dr["count"]));
                }

                dsBill.PrintProperties.PrinterName = p_strPrinterName;
                dsBill.Print(false);
            }
        }
        #endregion
    }
}
