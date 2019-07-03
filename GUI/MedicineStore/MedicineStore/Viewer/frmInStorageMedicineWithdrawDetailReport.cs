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
    public partial class frmInStorageMedicineWithdrawDetailReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 药品内退明细查询条件
        /// </summary>
        public clsMs_MedicineWithdrawDetailQueryCondition_VO m_objDetail_Param = null;
        /// <summary>
        /// 内退主表VO
        /// </summary>
        public clsMS_InnerWithdrawVO m_iwVo = new clsMS_InnerWithdrawVO();
        public DataTable m_dtbDetail;

        public string strInstorageid_vchr;
        public string strStoragename_chr;
        public string strExam_dat;
        public string strReturndept_chr;
        public string strMakername_chr;
        public string strInaccountername_chr;
        public string strCommnet_vchr;
        public string decBug;
        public string strTitle;
        public int intInitial=0;//1为初始化

        public frmInStorageMedicineWithdrawDetailReport()
        {
            InitializeComponent();
            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
        }

        private void frmInStorageMedicineWithdrawDetailReport_Load(object sender, EventArgs e)
        {  
            int intGetPrintType;
            ((clsCtl_InStorageMedicineWithdrawDetailReport)objController).getPrinttype(out intGetPrintType);

            m_objDetail_Param = new clsMs_MedicineWithdrawDetailQueryCondition_VO();
            m_objDetail_Param.m_strStorageID = strInstorageid_vchr;
            strTitle = ((clsCtl_InStorageMedicineWithdrawDetailReport)objController).getLogo();
            datWindow.Modify("t_titel.text='" + strTitle + "'");
            int m_intShow;
            clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
            m_objDon.m_lngGetIfShowInfo(out m_intShow);
             

            if (intInitial == 0)
            {
                if (intGetPrintType == 1)
                {
                    //使用External格式的报表打印
                    datWindow.SetRedrawOff();
                    datWindow.DataWindowObject = null;
                    datWindow.DataWindowObject = "instoragemedicinewithdraw_cs";
                    datWindow.Modify("t_titel.text='" + strTitle + "退库单(" + strStoragename_chr + ")'");
                    datWindow.Modify("t_bug.text='" + decBug + "'");
                    datWindow.Modify("m_storagename.text='" + strStoragename_chr + "'");
                    datWindow.Modify("m_txtoutputorder.text='" + strInstorageid_vchr + "'");
                    datWindow.Modify("m_dtpdate.text='" + strExam_dat + "'");
                    datWindow.Modify("m_txtreceivedept.text='" + strReturndept_chr + "'");
                    datWindow.Modify("m_txtman.text='" + strMakername_chr + "'");
                    datWindow.Modify("m_txtman2.text='" + strMakername_chr + "'");
                    datWindow.Modify("m_txtprovidername.text='" + strInaccountername_chr + "'");
                    datWindow.Modify("t_commnet.text='" + strCommnet_vchr + "'");
                    if (m_intShow == 0)
                        datWindow.Modify("t_info.text=''"); 
                    for (int i = 0; i < m_dtbDetail.Rows.Count; i++)
                    {
                        DataRow dtr = m_dtbDetail.Rows[i];
                        int row = this.datWindow.InsertRow();

                        this.datWindow.SetItemString(row, "assistcode_chr", dtr["assistcode_chr"].ToString());
                        this.datWindow.SetItemString(row, "medicinename_vch", dtr["medicinename_vch"].ToString());
                        this.datWindow.SetItemString(row, "medspec_vchr", dtr["medspec_vchr"].ToString());
                        this.datWindow.SetItemString(row, "opunit_chr", dtr["opunit_chr"].ToString());
                        this.datWindow.SetItemSqlDouble(row, "AMOUNT",Convert.ToDouble(dtr["AMOUNT"]));
                        this.datWindow.SetItemSqlDouble(row, "callprice_int", Convert.ToDouble(dtr["callprice_int"]));
                        this.datWindow.SetItemSqlDouble(row, "callsum", Convert.ToDouble(dtr["callsum"]));
                        this.datWindow.SetItemSqlDouble(row, "retailprice_int", Convert.ToDouble(dtr["retailprice_int"]));
                        this.datWindow.SetItemSqlDouble(row, "retailsum", Convert.ToDouble(dtr["retailsum"]));
                    }
    
                    //if (m_dtbDetail.Rows.Count % 6 != 0)
                    //{
                    //    int ros = 6 - m_dtbDetail.Rows.Count % 6;
                    //    int i_valCount = m_dtbDetail.Rows.Count + ros;
                    //    for (int i = 0; i < ros; i++)
                    //    {
                    //        int row = this.datWindow.InsertRow();
                    //        this.datWindow.SetItemString(row, "assistcode_chr", "");
                    //    }
                    //}
                    datWindow.SetRedrawOn();
                    datWindow.Refresh();
                    datWindow.PrintProperties.Preview = true;
                    return;
                }
                else
                {
                    datWindow.DataWindowObject = null;
                    datWindow.DataWindowObject = "instoragemedicinewithdraw_lj";

                    //按药品ID排序
                    DataView dtv = new DataView();
                    dtv = m_dtbDetail.DefaultView;
                    dtv.Sort = "assistcode_chr";
                    m_dtbDetail = dtv.ToTable();

                    datWindow.Modify("t_titel.text='" + strTitle + "退药单'");
                    if (m_intShow == 0)
                        datWindow.Modify("t_info.text=''"); 
                }
               
            }
            
            datWindow.Modify("t_bug.text='" + decBug + "'");
            datWindow.Modify("m_storagename.text='" + strStoragename_chr + "'");
            datWindow.Modify("m_txtoutputorder.text='" + strInstorageid_vchr + "'");
            datWindow.Modify("m_dtpdate.text='" + strExam_dat + "'");
            datWindow.Modify("m_txtreceivedept.text='" + strReturndept_chr + "'");
            datWindow.Modify("m_txtman.text='" + strMakername_chr + "'");
            datWindow.Modify("m_txtman2.text='" + strMakername_chr + "'");
            datWindow.Modify("m_txtprovidername.text='" + strInaccountername_chr + "'");
            datWindow.Modify("t_commnet.text='" + strCommnet_vchr + "'");
            if (m_intShow == 0)
                datWindow.Modify("t_info.text=''"); 
            if (intGetPrintType == 0)
            {
                DataRow dro;
                if (m_dtbDetail.Rows.Count % 6 != 0)
                {
                    int ros = 6 - m_dtbDetail.Rows.Count % 6;
                    int i_valCount = m_dtbDetail.Rows.Count + ros;
                    for (int i = 0; i < ros; i++)
                    {
                        dro = m_dtbDetail.NewRow();
                        m_dtbDetail.Rows.Add(dro);
                    }
                }
            }
            datWindow.Retrieve(m_dtbDetail);
            datWindow.PrintProperties.Preview = true;
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
        public override void CreateController()
        {
            this.objController = new clsCtl_InStorageMedicineWithdrawDetailReport();
            objController.Set_GUI_Apperance(this);
        } 
    }
}