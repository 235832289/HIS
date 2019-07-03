using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;
using System.Collections;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// DATAWINDOW通用打印对话窗口
    /// </summary>
    public partial class frmPrintDialog : Form
    {
        /// <summary>
        /// 数据源对象语法
        /// </summary>
        private string DataSourceSyntax = "";
        /// <summary>
        /// 数据源对象数据状态
        /// </summary>
        private DataWindowFullState DataFullState;
        /// <summary>
        /// 打印类型
        /// </summary>
        public string strType = "";
        /// <summary>
        /// 中心药房收取药袋费用数量字段
        /// </summary>
        Dictionary<string, int> dicMedBagNum = new Dictionary<string, int>();
        /// <summary>
        /// 中心药房打药袋时的摆药数据
        /// </summary>
        DataTable dtPutMed = null;
        /// <summary>
        /// 当前登录员工ID
        /// </summary>
        public string strEmpID = "";
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPrintDialog(DataWindowControl dw)
        {
            InitializeComponent();
            DataSourceSyntax = dw.Describe("datawindow.syntax");
            DataFullState = dw.GetFullState();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPrintDialog(DataStore ds)
        {
            InitializeComponent();
            DataSourceSyntax = ds.Describe("datawindow.syntax");
            DataFullState = ds.GetFullState();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmPrintDialog(DataStore ds, string p_strType, DataTable p_dtPutMed, string p_strEmpID)
        {
            InitializeComponent();
            DataSourceSyntax = ds.Describe("datawindow.syntax");
            DataFullState = ds.GetFullState();
            this.strType = p_strType;
            this.dtPutMed = p_dtPutMed;
            this.strEmpID = p_strEmpID;
        }

        private void frmPrintDialog_Load(object sender, EventArgs e)
        {
            this.dwRep.Create(DataSourceSyntax);
            this.dwRep.SetFullState(DataFullState);
            this.dwRep.CalculateGroups();
            this.dwRep.Refresh();

            this.dwRep.Modify("datawindow.print.preview = yes");
            this.dwRep.Modify("datawindow.print.preview.rulers = yes");

            if (this.strType == "中心药房打印药袋")
            {
                int intCurrentPage = 0;
                for (int intI = 1; intI <= dwRep.RowCount; intI++)
                {
                    string strInPatientID = dwRep.GetItemString(intI, "card");
                    string strNextInPatientID = "";
                    if (intI < dwRep.RowCount)
                    {
                        strNextInPatientID = dwRep.GetItemString(intI + 1, "card");
                    }

                    if (strInPatientID != strNextInPatientID)
                    {
                        intCurrentPage = Convert.ToInt32(dwRep.GetItemString(intI, "currentpage")) - intCurrentPage;
                        dicMedBagNum.Add(strInPatientID, intCurrentPage);
                        intCurrentPage = Convert.ToInt32(dwRep.GetItemString(intI, "currentpage"));
                    }
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            clsPublic.ExportDataWindow(this.dwRep, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
            this.dwRep.Modify("datawindow.print.preview = yes");
            this.dwRep.Modify("datawindow.print.preview.rulers = yes");

            if (this.strType == "中心药房打印药袋")
            {
                m_mthChargeMedBag();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void m_mthChargeMedBag()
        {
            if (this.dtPutMed != null)
            {
                List<string> lisNeedChargePatient = new List<string>();
                List<string> lisOrderCreateAreaID = new List<string>();
                clsDcl_CommonFind objDcl = new clsDcl_CommonFind();
                for (int intI = 0; intI < dtPutMed.Rows.Count; intI++)
                {
                    string strPutMedDetailID = dtPutMed.Rows[intI]["putmeddetailid_chr"].ToString();
                    string strInpatientID = dtPutMed.Rows[intI]["inpatientid_chr"].ToString();
                    bool blnIfCharge = false;

                    if (!lisNeedChargePatient.Contains(strInpatientID))
                    {
                        string strOrderCreateAreaID = "";
                        objDcl.m_lngQueryIfChargeMedBag(strPutMedDetailID, ref blnIfCharge, ref strOrderCreateAreaID);
                        if (blnIfCharge == false)
                        {
                            lisNeedChargePatient.Add(strInpatientID);
                            lisOrderCreateAreaID.Add(strOrderCreateAreaID);
                        }
                    }
                }

                ArrayList alsOrderDic = new ArrayList();
                ArrayList alsPatientCharge = new ArrayList();
                string strOrderID = "";
                
                for (int intI = 0; intI < lisNeedChargePatient.Count; intI++)
                {
                    string strInPatientID = lisNeedChargePatient[intI];
                    string strOrderCreateAreaID = lisOrderCreateAreaID[intI];
                    int intBagNum = dicMedBagNum[strInPatientID];

                    clsBihOrderDic_VO objOrderDicVO = new clsBihOrderDic_VO();
                    clsBihPatientCharge_VO objPatientChargeVO = new clsBihPatientCharge_VO();
                    m_mthCreateChargeVO(ref objOrderDicVO, ref objPatientChargeVO, strInPatientID, intBagNum, strOrderCreateAreaID);
                    alsOrderDic.Add(objOrderDicVO);
                    alsPatientCharge.Add(objPatientChargeVO);
                }
                clsDcl_Charge objDcl1 = new clsDcl_Charge();
                objDcl1.m_lngGenPatientChargeByDir(alsOrderDic, alsPatientCharge, 9, ref strOrderID);

                for (int intI = 0; intI < dtPutMed.Rows.Count; intI++)
                {
                    string strPutMedDetailID = dtPutMed.Rows[intI]["putmeddetailid_chr"].ToString();
                    string strInpatientID = dtPutMed.Rows[intI]["inpatientid_chr"].ToString();

                    if (lisNeedChargePatient.Contains(strInpatientID))
                    {
                        objDcl.m_lngUpdateIfChargeMedBag(strPutMedDetailID, 1);
                    }
                }
            }
        }

        public void m_mthCreateChargeVO(ref clsBihOrderDic_VO p_objOrderDicVO, ref clsBihPatientCharge_VO p_objPatientChargeVO, string p_strInPatientID, int p_intBagNum, string p_strOrderCreateAreaID)
        {
            clsDcl_CommonFind objDcl = new clsDcl_CommonFind();
            DataTable dtOrderDicInfo = new DataTable();
            DataTable dtPatientInfo = new DataTable();
            objDcl.m_lngQueryInfoForChargeMedBag("0001039661", p_strInPatientID, ref dtOrderDicInfo, ref dtPatientInfo);
            
            clsDcl_Charge objDcl1 = new clsDcl_Charge();
            DataTable dtItemInfo = new DataTable();
            objDcl1.m_lngGetChargeItemByOrderID("0001039661", dtPatientInfo.Rows[0]["paytypeid_chr"].ToString(), out dtItemInfo);
            DataRow dr = dtItemInfo.Rows[0];

            //p_objOrderDicVO
            p_objOrderDicVO.Type = 1;
            p_objOrderDicVO.OrderQue = 1;
            p_objOrderDicVO.OrderDicID = "0001039661";
            p_objOrderDicVO.OrderDicName = dtOrderDicInfo.Rows[0][0].ToString();
            p_objOrderDicVO.Spec = dtOrderDicInfo.Rows[0][1].ToString();
            p_objOrderDicVO.Qty = 0;
            p_objOrderDicVO.PriceMny = 0;
            p_objOrderDicVO.TotalMny = 0;
            p_objOrderDicVO.AttachOrderID = "1->0001039661";
            p_objOrderDicVO.SbBaseMny = 0;
            
            
            //p_objPatientChargeVO
            p_objPatientChargeVO.PatientID = dtPatientInfo.Rows[0]["patientid_chr"].ToString();
            p_objPatientChargeVO.RegisterID = dtPatientInfo.Rows[0]["registerid_chr"].ToString();
            p_objPatientChargeVO.ClacArea = dtPatientInfo.Rows[0]["areaid_chr"].ToString();
            p_objPatientChargeVO.CreateArea = p_strOrderCreateAreaID;
            p_objPatientChargeVO.CalcCateID = dr["itemipcalctype_chr"].ToString();
            p_objPatientChargeVO.InvCateID = dr["itemipinvtype_chr"].ToString();
            p_objPatientChargeVO.ChargeItemID = dr["itemid_chr"].ToString();
            p_objPatientChargeVO.ChargeItemName = dr["itemname_vchr"].ToString();

            if (dr["ipchargeflg_int"].ToString().Trim() == "1")
            {
                p_objPatientChargeVO.Unit = dr["itemipunit_chr"].ToString().Trim();
                p_objPatientChargeVO.UnitPrice = clsPublic.ConvertObjToDecimal(dr["submoney"]);
            }
            else
            {
                p_objPatientChargeVO.Unit = dr["itemunit_chr"].ToString().Trim();
                p_objPatientChargeVO.UnitPrice = clsPublic.ConvertObjToDecimal(dr["itemprice_mny"]);
            }

            p_objPatientChargeVO.Amount = clsPublic.ConvertObjToDecimal(p_intBagNum);
            p_objPatientChargeVO.Discount = Convert.ToDecimal(dr["precent_dec"]);
            p_objPatientChargeVO.Ismepay = 0;
            p_objPatientChargeVO.Des = "";
            p_objPatientChargeVO.CreateType = 4;
            p_objPatientChargeVO.Creator = this.strEmpID;
            p_objPatientChargeVO.Operator = this.strEmpID;
            p_objPatientChargeVO.PStatus = 1;
            p_objPatientChargeVO.Activator = this.strEmpID;
            p_objPatientChargeVO.ActivateType = 2;
            p_objPatientChargeVO.IsRich = int.Parse(dr["isrich_int"].ToString());
            p_objPatientChargeVO.CurAreaID = dtPatientInfo.Rows[0]["areaid_chr"].ToString();
            p_objPatientChargeVO.CurBedID = dtPatientInfo.Rows[0]["bedid_chr"].ToString();
            p_objPatientChargeVO.DoctorID = dtPatientInfo.Rows[0]["casedoctor_chr"].ToString();
            p_objPatientChargeVO.Doctor = dtPatientInfo.Rows[0]["lastname_vchr"].ToString();
            p_objPatientChargeVO.DoctorGroupID = "";
            p_objPatientChargeVO.NeedConfirm = 0;
            p_objPatientChargeVO.ActiveDat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            p_objPatientChargeVO.TotalMoney_dec = clsPublic.Round(p_objPatientChargeVO.UnitPrice * p_objPatientChargeVO.Amount, 2);
            p_objPatientChargeVO.AcctMoney_dec = p_objPatientChargeVO.TotalMoney_dec - clsPublic.Round(p_objPatientChargeVO.UnitPrice * p_objPatientChargeVO.Amount * p_objPatientChargeVO.Discount / 100, 2);
            p_objPatientChargeVO.AttachOrderID = "1->0001039661";
            p_objPatientChargeVO.AttachOrderBaseNum = 0;
            p_objPatientChargeVO.SPEC_VCHR = dr["itemspec_vchr"].ToString();
            p_objPatientChargeVO.PutMedicineFlag = 0;
            p_objPatientChargeVO.CHARGEDOCTORID_CHR = dtPatientInfo.Rows[0]["casedoctor_chr"].ToString();
            p_objPatientChargeVO.CHARGEDOCTOR_VCHR = dtPatientInfo.Rows[0]["lastname_vchr"].ToString();
            p_objPatientChargeVO.CHARGEDOCTORGROUPID_CHR = "";
        }
    }
}