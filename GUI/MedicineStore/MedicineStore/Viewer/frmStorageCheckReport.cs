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
    public partial class frmStorageCheckReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public DataTable dtb = new DataTable();
        public string strStorageName;
        public string strCheckDate;
        public string strAskerName;
        public string strFhr;
        public string strExamerName;
        /// <summary>
        /// 是否药房使用，默认是药库使用
        /// </summary>
        public bool m_blnUseByDS = false;
        /// <summary>
        /// 药房使用的总金额
        /// </summary>
        public double m_dblTotalPrice = 0d;
        public string m_strHospitalName = string.Empty;

        /// <summary>
        /// 药库打印类型
        /// </summary>
        public int m_intPrintType = 2;
        public frmStorageCheckReport()
        {
            InitializeComponent();
            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            //datWindow.Print();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
        }

        private void frmStorageCheckReport_Load(object sender, EventArgs e)
        {
            DataTable dtPrint = dtb.Copy();
            if (datWindow.DataWindowObject == "storagecheck_lj")
            {
                dtPrint.Columns.Add();
                dtPrint.Columns.Add();
            }

            if (!m_blnUseByDS)
            {
                if (m_intPrintType == 1)//cs
                {
                    //取得购入总金额和零售总金额
                    double m_dblCallsum = 0d;
                    double m_dblRetailsum = 0d;
                    double dblTemp = 0d;
                    if (!dtPrint.Columns.Contains("rowno"))
                        dtPrint.Columns.Add("rowno", typeof(Int32));
                    for (int i1 = 0; i1 < dtPrint.Rows.Count; i1++)
                    {
                        dtPrint.Rows[i1]["rowno"] = i1 + 1;
                        if (double.TryParse(dtPrint.Rows[i1]["checkgross_int"].ToString(), out dblTemp))
                        {
                            if (double.TryParse(dtPrint.Rows[i1]["callprice_int"].ToString(), out dblTemp))
                            {
                                m_dblCallsum += Convert.ToDouble(dtPrint.Rows[i1]["checkgross_int"]) * Convert.ToDouble(dtPrint.Rows[i1]["callprice_int"]);
                            }
                            if (double.TryParse(dtPrint.Rows[i1]["retailprice_int"].ToString(), out dblTemp))
                            {
                                m_dblRetailsum += Convert.ToDouble(dtPrint.Rows[i1]["checkgross_int"]) * Convert.ToDouble(dtPrint.Rows[i1]["retailprice_int"]);
                            }
                        }
                    }

                    datWindow.Modify("t_title.text='" + m_strHospitalName + "(" + strStorageName + ")'");
                    datWindow.Modify("t_strStorageName.text='" + strStorageName + "'");
                    datWindow.Modify("t_callsum.text='" + m_dblCallsum.ToString("F2") + "'");
                    datWindow.Modify("t_retailsum.text='" + m_dblRetailsum.ToString("F2") + "'");
                }
            }
            datWindow.Modify("t_strStorageName.text='" + strStorageName + "'");
            datWindow.Modify("t_CheckDate.text='" + strCheckDate + "'");
            datWindow.Modify("t_AskerName.text='" + strAskerName + "'");
            datWindow.Modify("t_fhr.text='" + strFhr + "'");
            datWindow.Modify("t_ExamerName.text='" + strExamerName + "'");
            datWindow.SetRedrawOff();
            datWindow.Retrieve(dtPrint);
            datWindow.PrintProperties.Preview = true;
            datWindow.SetRedrawOn();
            datWindow.Refresh();
            
           // datWindow.PrintProperties.Preview = true;
        }
    }
}