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
    public partial class frmMedicineOutReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 0：表示不显示预览窗直接打印，1：表示显示预览窗
        /// </summary>
        public int i_showType;
        public DataTable dtb = new DataTable();
        public string ReceiveDept;
        public string OutputOrder;
        public string zDate;
        public string Man;
        public string RoomName;
        public string strAllInMoney;
        public string strBigwrith;
        public frmMedicineOutReport()
        {
            InitializeComponent();
            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
        }
 
        private void frmMedicineOutReport_Load(object sender, EventArgs e)
        {
            
            this.objController = new clsCtl_MedicineOut();
            //datWindow.DataWindowObject = "outstorage_detailreport_cs";
            if (datWindow.DataWindowObject == "outstorage_detailreport_cs")
            {
                datWindow.Modify("t_titel.text='" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "出库单(" + RoomName + ")'");
              
                datWindow.Modify("t_bigwrith.text='" + strBigwrith + "'");
                               
                dtb.Columns.Add("validperiod_chr", typeof(System.String));
                dtb.Columns.Add("group_int", typeof(System.Int32));
                int intGroup = 0;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (i % 15 == 0)
                    {
                        intGroup++;
                    }
                    dtb.Rows[i]["group_int"] = intGroup;
                    if(dtb.Rows[i]["validperiod_dat"].ToString().StartsWith("0001"))
                    {
                        dtb.Rows[i]["validperiod_chr"] = DBNull.Value;
                    }
                    else
                    {
                        dtb.Rows[i]["validperiod_chr"] = Convert.ToDateTime(dtb.Rows[i]["validperiod_dat"]).ToString("yyyy-MM-dd");
                    }
                }
                dtb.Columns.Remove("validperiod_dat");
            }
            else
            {
                datWindow.Modify("t_titel.text='" + this.objController.m_objComInfo.m_strGetHospitalTitle() + "药品调拔单'");
            }
            datWindow.Modify("m_storagename.text='" + RoomName + "'");
            datWindow.Modify("m_txtreceivedept.text='" + ReceiveDept + "'");
            datWindow.Modify("m_txtman.text='" + Man + "'");
            datWindow.Modify("m_txtman2.text='" + Man + "'");
            datWindow.Modify("m_dtpdate.text='" + zDate + "'");
            datWindow.Modify("m_txtoutputorder.text='" + OutputOrder + "'");

            int m_intShow;
            clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
            m_objDon.m_lngGetIfShowInfo(out m_intShow);
            if (m_intShow == 0)
                datWindow.Modify("t_info.text=''");  
            datWindow.PrintProperties.Preview = true;
            datWindow.Retrieve(dtb);
            datWindow.CalculateGroups();
            datWindow.Refresh();

            if (i_showType == 0)
            {
                this.Visible = false;
                clsCtl_Public clsPub = new clsCtl_Public();
                clsPub.ChoosePrintDialog(datWindow, true);
               
                this.Close();
            }
            
     
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
         
        }
    }
}