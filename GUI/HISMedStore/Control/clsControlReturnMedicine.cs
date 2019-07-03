using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Collections;
using com.digitalwave.iCare.gui.HIS;
using System.Xml;
using System.IO;
using System.Drawing.Printing;
using com.digitalwave.iCare.middletier.HI;
using LEDInterface.LianCheng;
using System.Collections.Generic;
using com.digitalwave.Utility;
using Sybase.DataWindow;


namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 退药控制层
    /// </summary>
    public class clsControlReturnMedicine : com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsControlReturnMedicine()
        {
            m_objDomain = new clsDomainControlOPMedStore();
        }
        /// <summary>
        /// 初始化界面
        /// </summary>
        /// <param name="m_strMedStoreid"></param>
        public void m_mthInitialGUI(string m_strMedStoreid)
        {
            long lngRes = -1;
            DataTable dt = new DataTable();
            lngRes = m_objDomain.m_lngGetMedStoreInfo(m_strMedStoreid, ref dt);
            if(lngRes>0)
            {
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("传入的药房ID有误，不存在该药房ID！");
                    return;
                }
                else
                {
                    m_strMedStoreName = dt.Rows[0]["medstorename_vchr"].ToString();
                    this.m_objViewer.Text += "{"+dt.Rows[0]["medstorename_vchr"].ToString()+"}";
                }
            }
        }
        private string m_strMedStoreName;
        #region 设置窗体对象
        frmReturnMedicine m_objViewer;
        clsDomainControlOPMedStore m_objDomain;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReturnMedicine)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 获取退药信息
        /// </summary>
        public void m_mthGetReturnMedicine()
        {
            DataTable m_dtTemp = new DataTable();
            DataTable  m_dtSendMed = new DataTable();
            DataTable m_dtReturnMed = new DataTable();
            long lngRes = -1;
            string m_strBeginDate=this.m_objViewer.m_dtmBeginDate.Value.ToString("yyyy-MM-dd");
            string m_strEndDate = this.m_objViewer.m_dtmEndDate.Value.ToString("yyyy-MM-dd");
            lngRes = m_objDomain.m_lngGetReturnMedicine(this.m_objViewer.m_strMedStoreid,m_strBeginDate,m_strEndDate,m_objViewer.m_intDeductFlow, out m_dtTemp);
            if (lngRes > 0 && m_dtReturnMed != null)
            {
                m_dtSendMed = m_dtTemp.Clone();
                m_dtReturnMed = m_dtTemp.Clone();
                DataRow[] drArr = m_dtTemp.Select("returnmedrecipeno is  null and pstauts_int<>-2");
                m_dtSendMed.BeginLoadData();
                for (int i = 0; i < drArr.Length; i++)
                {
                    m_dtSendMed.LoadDataRow(drArr[i].ItemArray, true);
                }
                m_dtSendMed.EndLoadData();
                drArr = m_dtTemp.Select("returnmedrecipeno is not null");
                m_dtReturnMed.BeginLoadData();
                for (int j = 0; j < drArr.Length; j++)
                {
                    m_dtReturnMed.LoadDataRow(drArr[j].ItemArray, true);
                }
                m_dtReturnMed.EndLoadData();
                this.m_objViewer.m_dgvSendMed.DataSource = m_dtSendMed;
                if (this.m_objViewer.m_dgvSendMed.Rows.Count == 0)
                    this.m_objViewer.m_dgvDetail.DataSource = null;
                this.m_objViewer.m_dgvReturnMed.DataSource = m_dtReturnMed;
                if (this.m_objViewer.m_dgvReturnMed.Rows.Count == 0)
                    this.m_objViewer.m_dgvReturnDetail.DataSource = null;
            }
        }
        /// <summary>
        ///  绑定发药/退药明细信息
        /// </summary>
        /// <param name="m_intFlag">0-已发药明细；1-退药明细</param>
        public void m_mthBindDetailData(int m_intFlag)
        {
            DataTable m_dtRecipeDetail = new DataTable();
            long lngRes = -1;
            if (m_intFlag == 0)
            {
                string m_strOutPatientRecipeid = this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtOutpatientRecipeNo"].Value.ToString();
                lngRes = m_objDomain.m_lngGetSendMedRecipeDetailByid(m_strOutPatientRecipeid, this.m_objViewer.m_strMedStoreid, out m_dtRecipeDetail);
                if (lngRes > 0)
                {
                    this.m_objViewer.m_dgvDetail.Rows.Clear();
                    int m_intIndex=-1;
                    List<DataRow> objDataRowList;
                    for(int i = 0; i < m_dtRecipeDetail.Rows.Count; i++)
                    {
                        this.m_objViewer.m_dgvDetail.Rows.Add(m_dtRecipeDetail.Rows[i].ItemArray);
                        objDataRowList = new List<DataRow>();
                        objDataRowList.Add(m_dtRecipeDetail.Rows[i]);
                        //m_intIndex = i;
                        //while (true)
                        //{
                        //    m_intIndex++;
                        //    if (m_intIndex < m_dtRecipeDetail.Rows.Count && m_dtRecipeDetail.Rows[m_intIndex]["billrowno_int"].ToString() == m_dtRecipeDetail.Rows[i]["billrowno_int"].ToString())
                        //    {
                        //        objDataRowList.Add(m_dtRecipeDetail.Rows[m_intIndex]);
                        //        i++;
                        //    }
                        //    else
                        //    {
                                this.m_objViewer.m_dgvDetail.Rows[this.m_objViewer.m_dgvDetail.Rows.Count - 1].Tag = objDataRowList;
                        //        break;
                        //    }

                        //}
                    }

                    for(int i = 0; i < this.m_objViewer.m_dgvDetail.Rows.Count; i++)
                    {
                        this.m_objViewer.m_dgvDetail.Rows[i].Cells[0].Value = "True";
                        this.m_objViewer.m_dgvDetail.CurrentCell = this.m_objViewer.m_dgvDetail.Rows[i].Cells[1];
                    }
                }
            }
            else
            {
                string m_strOutPatientRecipeid = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtReturnRecipeNo"].Value.ToString();
                lngRes = m_objDomain.m_lngGetReturnDetailInfo(m_strOutPatientRecipeid,ref m_dtRecipeDetail);
                if (lngRes > 0)
                {
                   // this.m_objViewer.m_dgvReturnDetail.DataSource = m_dtRecipeDetail;
                    int m_intIndex = -1;
                    List<DataRow> objDataRowList = new List<DataRow>(); ;
                    for (int i = 0; i < m_dtRecipeDetail.Rows.Count; i++)
                    {
                        objDataRowList.Add(m_dtRecipeDetail.Rows[i]);
                        //m_intIndex = i;
                        //while (true)
                        //{
                        //    m_intIndex++;
                        //    if (m_intIndex < m_dtRecipeDetail.Rows.Count && m_dtRecipeDetail.Rows[m_intIndex]["billrowno_int"].ToString() == m_dtRecipeDetail.Rows[i]["billrowno_int"].ToString())
                        //    {
                        //        i++;
                        //    }
                        //    else
                        //    {
                        //        break;
                        //    }

                        //}
                    }
                    DataTable m_dtSource = m_dtRecipeDetail.Clone();
                    foreach (DataRow var in objDataRowList)
                    {
                        m_dtSource.BeginLoadData();
                        m_dtSource.LoadDataRow(var.ItemArray, true);
                        m_dtSource.EndLoadData();
                    }
                    this.m_objViewer.m_dgvReturnDetail.Tag = m_dtRecipeDetail;
                    this.m_objViewer.m_dgvReturnDetail.DataSource = m_dtSource;

                }
            }
        }
        internal void m_mthShowSourceRecipeDetail()
        {
            //显示原有处方明细信息
            if (this.m_objViewer.m_dgvReturnDetail.Rows.Count > 0)
            {
                DataTable m_dtRecipeDetail = new DataTable();
                long lngRes = -1;
                string m_strOutPatientRecipeid = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtReturnRecipeNo"].Value.ToString();
                lngRes = m_objDomain.m_lngGetSendMedRecipeDetailByid(m_strOutPatientRecipeid, this.m_objViewer.m_strMedStoreid, out m_dtRecipeDetail);
                if (lngRes > 0)
                {
                  
                    int m_intIndex = -1;
                    List<DataRow> objDataRowList = new List<DataRow>(); ;
                    for (int i = 0; i < m_dtRecipeDetail.Rows.Count; i++)
                    {
                        objDataRowList.Add(m_dtRecipeDetail.Rows[i]);
                        //m_intIndex = i;
                        //while (true)
                        //{
                        //    m_intIndex++;
                        //    if (m_intIndex < m_dtRecipeDetail.Rows.Count && m_dtRecipeDetail.Rows[m_intIndex]["billrowno_int"].ToString() == m_dtRecipeDetail.Rows[i]["billrowno_int"].ToString())
                        //    {
                        //        i++;
                        //    }
                        //    else
                        //    {
                        //        break;
                        //    }

                        //}
                    }
                    DataTable m_dtSource = m_dtRecipeDetail.Clone();
                    foreach (DataRow var in objDataRowList)
                    {
                        m_dtSource.BeginLoadData();
                        m_dtSource.LoadDataRow(var.ItemArray, true);
                        m_dtSource.EndLoadData();
                    }
                    m_dtRecipeDetail.Dispose();
                    m_dtRecipeDetail = null;
                    this.m_objViewer.m_dgvSourceRecipeDetail.DataSource = m_dtSource;
                    this.m_objViewer.m_dgvSourceRecipeDetail.Visible = true;
                    this.m_objViewer.m_dgvSourceRecipeDetail.Focus();
                }
            }
        }
        #region 重打退药凭据
        /// <summary>
        /// 重打退药凭据
        /// </summary>
        public void m_mthRePrintBill()
        {

            clsReutrnMed clsMainVo = new clsReutrnMed();
            List<clsReutrnMedEntry> m_objDetailList = new List<clsReutrnMedEntry>();
            clsReutrnMedEntry m_objReturnMedEntry;
            clsMainVo.m_strDeptName = this.m_strMedStoreName;
            clsMainVo.m_strPatientCardid = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtPatientcardid1"].Value.ToString();
            clsMainVo.m_strPatientName = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtPatientName1"].Value.ToString();
            clsMainVo.m_strOUTPATRECIPEID_CHR = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtReturnRecipeNo"].Value.ToString();
            clsMainVo.m_strInvoiceNo = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtInvoiceNo1"].Value.ToString();
            clsMainVo.m_strPayTypeName = this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtpaytypename_vchr1"].Value.ToString();
            clsMainVo.m_dblTotalMoney = Convert.ToDouble(this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txttotalsum_mny1"].Value);
            if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int1"].Value.ToString() == "0")
            {
                clsMainVo.m_strInternalFlagName = "普通";
            }
            else if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int1"].Value.ToString() == "1")
            {
                clsMainVo.m_strInternalFlagName = "公费";
            }
            else if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int1"].Value.ToString() == "2")
            {
                clsMainVo.m_strInternalFlagName = "医保";
            }
            else if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int1"].Value.ToString() == "3")
            {
                clsMainVo.m_strInternalFlagName = "特困";
            }
            else if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "4")
            {
                clsMainVo.m_strInternalFlagName = "离休";
            }
            else if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int1"].Value.ToString() == "5")
            {
                clsMainVo.m_strInternalFlagName = "本院";
            }
            else if (this.m_objViewer.m_dgvReturnMed.Rows[this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int1"].Value.ToString() == "6")
            {
                clsMainVo.m_strInternalFlagName = "门诊合作医疗";
            }
            for (int i = 0; i < this.m_objViewer.m_dgvReturnDetail.Rows.Count; i++)
            {
                m_objReturnMedEntry = new clsReutrnMedEntry();
                m_objReturnMedEntry.m_strITEMNAME_VCHR = this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_dgvtxtItemName1"].Value.ToString();
                m_objReturnMedEntry.m_strOUTPATRECIPEID_CHR = clsMainVo.m_strOUTPATRECIPEID_CHR;
                m_objReturnMedEntry.m_strUnit_chr = this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_txtUnit1"].Value.ToString();
                m_objReturnMedEntry.ORGAMOUT_DEC = Convert.ToDouble(this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_txtOrgAmount1"].Value);
                m_objReturnMedEntry.PRICE_DEC = Convert.ToDouble(this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_txtPrice1"].Value);
                m_objReturnMedEntry.RETAMOUT_DEC = Convert.ToDouble(this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_dgvtextReturnAmount"].Value);

                m_objReturnMedEntry.m_strItemSpec = this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_txtMedSpec1"].Value.ToString();
                m_objReturnMedEntry.m_dblReturnPrice = m_objReturnMedEntry.RETAMOUT_DEC * Convert.ToDouble(this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_txtPrice1"].Value);
                clsMainVo.m_dblReturnMoney += m_objReturnMedEntry.m_dblReturnPrice;
                //clsMainVo.m_intTimes_int = Convert.ToInt16(this.m_objViewer.m_dgvReturnDetail.Rows[i].Cells["m_dgvtxttimes_int1"].Value);
                m_objDetailList.Add(m_objReturnMedEntry);
            }
            DataStore ds = new DataStore();
            ds.LibraryList = Application.StartupPath + @"\pb_op.pbl";
            ds.DataWindowObject = "d_op_patchmedince_report";
            if (clsMainVo.m_intTimes_int > 0)
            {
                ds.Modify("t_46.text='" + clsMainVo.m_intTimes_int.ToString() + "'");
                ds.Modify("t_strmedtype.text=草");
            }
            ds.Modify("t_strname.text='" + clsMainVo.m_strPatientName + "'");
            ds.Modify("t_strcardid.text='" + clsMainVo.m_strPatientCardid + "'");
            ds.Modify("t_strpaytype.text='" + clsMainVo.m_strPayTypeName + "'");
            ds.Modify("t_strtype.text='" + clsMainVo.m_strInternalFlagName + "'");
            ds.Modify("t_strno.text='" + clsMainVo.m_strInvoiceNo + "'");
            ds.Modify("t_strno2.text='" + clsMainVo.m_strOUTPATRECIPEID_CHR + "'");
            ds.Modify("t_strpaymoney.text='" + clsMainVo.m_dblTotalMoney.ToString("0.0000") + "'");
            ds.Modify("t_strpatchmoney.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
            ds.Modify("t_strname2.text='" + clsMainVo.m_strPatientName + "'");
            ds.Modify("t_strpatchmoney2.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
            ds.Modify("t_strdept.text='" + clsMainVo.m_strDeptName + "'");
            ds.Modify("t_strpatchmoney3.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
            ds.Modify("t_35.text='" + clsMainVo.m_strInvoiceNo + "'");
            ds.Modify("t_strpatchmoney4.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
            for (int i = 0; i < m_objDetailList.Count; i++)
            {
                int iRow = ds.InsertRow(0);
                ds.SetItemString(iRow, "medname", m_objDetailList[i].m_strITEMNAME_VCHR);
                ds.SetItemString(iRow, "medspec", m_objDetailList[i].m_strItemSpec);
                ds.SetItemString(iRow, "medunit", m_objDetailList[i].m_strUnit_chr);
                ds.SetItemString(iRow, "amout", m_objDetailList[i].ORGAMOUT_DEC.ToString());
                ds.SetItemString(iRow, "patchamout", m_objDetailList[i].RETAMOUT_DEC.ToString());
                ds.SetItemString(iRow, "patchmoney", m_objDetailList[i].m_dblReturnPrice.ToString("0.0000"));
            }
            clsPublic.PrintDialog(ds);
        }
        #endregion
        /// <summary>
        /// 撤销退药业务
        /// </summary>
        public void m_mthRollBackReturnMedicine()
        {
            if (MessageBox.Show("是否确认要对所选处方进行撤销退药？","药房退药提示信息:", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
   
                List<clsReutrnMedEntry> m_objDetailList = new List<clsReutrnMedEntry>();
                clsReutrnMedEntry m_objReturnMedEntry = new clsReutrnMedEntry();
                int m_intSelectedIndex = this.m_objViewer.m_dgvReturnMed.CurrentCell.RowIndex;
                int m_intRecipeStatus = 0;
                string m_strRecipeNo=this.m_objViewer.m_dgvReturnMed.Rows[m_intSelectedIndex].Cells["m_txtReturnRecipeNo"].Value.ToString();
                long lngRes = -1;
                lngRes = m_objDomain.m_lngGetRecipeStatus(m_strRecipeNo, out m_intRecipeStatus);
                if (lngRes > 0)
                {
                    if (m_intRecipeStatus == -1 || m_intRecipeStatus == -2)
                    {
                        MessageBox.Show("该处方已经退票或者作废，不能进行撤销退药！", "药房退药提示信息",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("不存在该处方，不能进行撤销退药！", "药房退药提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                DataRow drv;
                DataTable dt = this.m_objViewer.m_dgvReturnDetail.Tag as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_objReturnMedEntry = new clsReutrnMedEntry();

                    drv = dt.Rows[i] ;
                    m_objReturnMedEntry.m_strOUTPATRECIPEID_CHR = m_strRecipeNo;
                    m_objReturnMedEntry.m_dblIPRETAMOUT_DEC = Convert.ToDouble(drv["ipamount_dec"]);
                    m_objReturnMedEntry.m_dblOPRETAMOUT_DEC = Convert.ToDouble(drv["opamount_dec"]);
                    m_objReturnMedEntry.m_strSerialno = drv["medseriesid_int"].ToString();
                    m_objReturnMedEntry.m_strMEDICINEID_CHR = drv["itemsrcid_vchr"].ToString();
                    m_objReturnMedEntry.m_strDrugStoreid_chr = drv["drugstoreid_chr"].ToString();
                    m_objDetailList.Add(m_objReturnMedEntry);

                }

                string m_strExcp = string.Empty;
                lngRes = m_objDomain.m_lngRollBackReturnMedInfo(this.m_objViewer.LoginInfo.m_strEmpID, m_objDetailList, out m_strExcp);
                if (lngRes > 0)
                {
        
                    MessageBox.Show("撤销退药成功！", "药房退药提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetReturnMedicine();
                }
                else if (lngRes == -100)
                {
                    MessageBox.Show("操作失败，" + m_strExcp, "药房退药提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
       
                    MessageBox.Show("撤销退药失败！", "药房退药提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

        }
        /// <summary>
        /// 退药业务
        /// </summary>
        public void m_mthReturnMedicine()
        {
            frmReturnMedConfirm frmReturnMedConfirm = new frmReturnMedConfirm();
            frmReturnMedConfirm.objControllReturnMed = this;
            for (int i = 0; i < this.m_objViewer.m_dgvDetail.Rows.Count; i++)
            {

                if (this.m_objViewer.m_dgvDetail.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    string strValue = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtReturnAmount"].Value.ToString();
                    double dblResult = 0d;
                    if (double.TryParse(strValue, out dblResult))
                    {
                        if (dblResult > Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtOrgAmount"].Value))
                        {
                            MessageBox.Show(string.Format("第{0}行输入的退药数量不能大于原始发药数量！", i + 1), "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        else if (dblResult <= 0)
                        {
                            MessageBox.Show(string.Format("第{0}行输入的退药数量应大于零！", i + 1), "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show(string.Format("第{0}行请输入正确的退药数量！", i + 1), "iCare系统提示信息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            if (frmReturnMedConfirm.ShowDialog() == DialogResult.OK)
            {
                clsReutrnMed clsMainVo = new clsReutrnMed();
                //收费单位类别
                string m_strChargeType = "-1";
                List<DataRow> objDataRowList;
                //最小单位对应数量
                double m_dblTempAmout = 0d;
                List<clsReutrnMedEntry> m_objDetailList = new List<clsReutrnMedEntry>();
                clsReutrnMedEntry m_objReturnMedEntry;
                clsMainVo.m_strDrugStoreid = this.m_objViewer.m_dgvDetail.Rows[0].Cells["m_txtdrugstoreid_chr"].Value.ToString();
                clsMainVo.m_strDeptName = this.m_strMedStoreName;
                clsMainVo.m_datCONFIRMTIME_DAT = DateTime.Now;
                clsMainVo.m_strPatientCardid= this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtPatientcardid"].Value.ToString();
                clsMainVo.m_strPatientName= this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtPatientName"].Value.ToString();
                clsMainVo.m_strCONFIRMEMP_CHR = frmReturnMedConfirm.m_strEmpid;
                clsMainVo.m_datOPERTIME_DAT = DateTime.Now;
                clsMainVo.m_strOPEREMP_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                clsMainVo.m_intSTATUS_INT = 1;
                clsMainVo.m_strOUTPATRECIPEID_CHR = this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtOutpatientRecipeNo"].Value.ToString();
                clsMainVo.m_strInvoiceNo = this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtInvoiceNo"].Value.ToString();
                clsMainVo.m_strPayTypeName = this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtpaytypename_vchr"].Value.ToString();
                clsMainVo.m_dblTotalMoney = Convert.ToDouble(this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txttotalsum_mny"].Value);
                if(this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString()=="0")
                {
                    clsMainVo.m_strInternalFlagName = "普通";
                }
                else if (this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "1")
                {
                    clsMainVo.m_strInternalFlagName = "公费";
                }
                else if (this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "2")
                {
                    clsMainVo.m_strInternalFlagName = "医保";
                }
                else if (this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "3")
                {
                    clsMainVo.m_strInternalFlagName = "特困";
                }
                else if (this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "4")
                {
                    clsMainVo.m_strInternalFlagName = "离休";
                }
                else if (this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "5")
                {
                    clsMainVo.m_strInternalFlagName = "本院";
                }
                else if (this.m_objViewer.m_dgvSendMed.Rows[this.m_objViewer.m_dgvSendMed.CurrentCell.RowIndex].Cells["m_txtinternalflag_int"].Value.ToString() == "6")
                {
                    clsMainVo.m_strInternalFlagName = "门诊合作医疗";
                }
                for (int i = 0; i < this.m_objViewer.m_dgvDetail.Rows.Count; i++)
                {
                   
                    if (this.m_objViewer.m_dgvDetail.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        objDataRowList = this.m_objViewer.m_dgvDetail.Rows[i].Tag as List<DataRow>;
                        m_strChargeType = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtchargeType"].Value.ToString();
                        if(m_strChargeType=="0")
                            m_dblTempAmout = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtReturnAmount"].Value) * Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtpackqty_dec"].Value);
                        else if (m_strChargeType=="1")
                            m_dblTempAmout = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtReturnAmount"].Value);
                        else
                            m_dblTempAmout =  Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtReturnAmount"].Value)*Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtMidUnitPackage"].Value);

                        foreach (DataRow dr in objDataRowList)
                        {
                            m_objReturnMedEntry = new clsReutrnMedEntry();
                            m_objReturnMedEntry.m_strItemSpec = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtMedSpec"].Value.ToString();
                            m_objReturnMedEntry.BILLROWNO_INT = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtBillRowNo"].Value);
                            m_objReturnMedEntry.m_strITEMID_CHR = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtItemid"].Value.ToString();
                            m_objReturnMedEntry.m_strMEDICINEID_CHR = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtMedicineid"].Value.ToString();
                            m_objReturnMedEntry.m_strITEMNAME_VCHR = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtItemName"].Value.ToString();
                            m_objReturnMedEntry.m_strUnit_chr = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtUnit"].Value.ToString();
                            m_objReturnMedEntry.ORGAMOUT_DEC = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtOrgAmount"].Value);
                            m_objReturnMedEntry.PRICE_DEC = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtPrice"].Value);
                            m_objReturnMedEntry.RETAMOUT_DEC = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtReturnAmount"].Value);
                            m_objReturnMedEntry.m_dblPackage = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtpackqty_dec"].Value);
                            m_objReturnMedEntry.m_strDrugStoreid_chr = this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtdrugstoreid_chr"].Value.ToString();

                            m_objReturnMedEntry.m_intchargetype_int = Convert.ToInt32(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtchargeType"].Value);

                            m_objReturnMedEntry.m_dblReturnPrice = m_objReturnMedEntry.RETAMOUT_DEC * Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtPrice"].Value);
                            if (this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtMidUnitPackage"].Value != DBNull.Value)
                                m_objReturnMedEntry.m_dblunitscale_dec = Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtMidUnitPackage"].Value);

                            m_objReturnMedEntry.m_strOUTPATRECIPEID_CHR = clsMainVo.m_strOUTPATRECIPEID_CHR;
                            //判断退药哪一批号
                            if (Convert.ToDouble(dr["ipamount_dec"]) >= m_dblTempAmout)
                            {
                                m_objReturnMedEntry.m_strSerialno = dr["medseriesid_int"].ToString();
                                m_objReturnMedEntry.m_dblLotsReturnAmount = m_dblTempAmout;
                                m_objReturnMedEntry.m_intAdded = 1;
                                m_objDetailList.Add(m_objReturnMedEntry);
                                
                                break;
                            }
                            else
                            {
                                m_objReturnMedEntry.m_strSerialno = dr["medseriesid_int"].ToString();
                                m_objReturnMedEntry.m_dblLotsReturnAmount = Convert.ToDouble(dr["ipamount_dec"]);
                                m_dblTempAmout -= m_objReturnMedEntry.m_dblLotsReturnAmount;
                                m_objDetailList.Add(m_objReturnMedEntry);
                            }



                        }
                        clsMainVo.m_dblReturnMoney += Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtReturnAmount"].Value) * Convert.ToDouble(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_txtPrice"].Value);
                        clsMainVo.m_intTimes_int = Convert.ToInt16(this.m_objViewer.m_dgvDetail.Rows[i].Cells["m_dgvtxttimes_int"].Value);

                    }
                    else
                    {
                        clsMainVo.m_intFLAG_INT = 1;
                    }
                }
                long lngRes = -1;
                lngRes = m_objDomain.m_lngAddReturnMedInfo(clsMainVo, m_objDetailList);
                if (lngRes > 0)
                {
                    MessageBox.Show("退药成功！");
                    try
                    {
                        if (MessageBox.Show("是否打印病者退款通知及收据？", "药房退药提示信息:", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            DataStore ds = new DataStore();

                            ds.LibraryList = Application.StartupPath + @"\pb_op.pbl";
                            ds.DataWindowObject = "d_op_patchmedince_report";
                            if (clsMainVo.m_intTimes_int > 0)
                            {
                                ds.Modify("t_46.text='" + clsMainVo.m_intTimes_int.ToString() + "'");
                                ds.Modify("t_strmedtype.text='草'");
                            }
                            ds.Modify("t_strname.text='" + clsMainVo.m_strPatientName + "'");
                            ds.Modify("t_strcardid.text='" + clsMainVo.m_strPatientCardid + "'");
                            ds.Modify("t_strpaytype.text='" + clsMainVo.m_strPayTypeName + "'");
                            ds.Modify("t_strtype.text='" + clsMainVo.m_strInternalFlagName + "'");
                            ds.Modify("t_strno.text='" + clsMainVo.m_strInvoiceNo + "'");
                            ds.Modify("t_strno2.text='" + clsMainVo.m_strOUTPATRECIPEID_CHR + "'");
                            ds.Modify("t_strpaymoney.text='" + clsMainVo.m_dblTotalMoney.ToString("0.0000") + "'");
                            ds.Modify("t_strpatchmoney.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
                            ds.Modify("t_strname2.text='" + clsMainVo.m_strPatientName + "'");
                            ds.Modify("t_strpatchmoney2.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
                            ds.Modify("t_strdept.text='" + clsMainVo.m_strDeptName + "'");
                            ds.Modify("t_strpatchmoney3.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
                            ds.Modify("t_35.text='" + clsMainVo.m_strInvoiceNo + "'");
                            ds.Modify("t_strpatchmoney4.text='" + clsMainVo.m_dblReturnMoney.ToString("0.0000") + "'");
                            for (int i = 0; i < m_objDetailList.Count; i++)
                            {
                                if (m_objDetailList[i].m_intAdded == 0) continue;
                                int iRow = ds.InsertRow(0);
                                ds.SetItemString(iRow, "medname", m_objDetailList[i].m_strITEMNAME_VCHR);
                                ds.SetItemString(iRow, "medspec", m_objDetailList[i].m_strItemSpec);
                                ds.SetItemString(iRow, "medunit", m_objDetailList[i].m_strUnit_chr);
                                ds.SetItemString(iRow, "amout", m_objDetailList[i].ORGAMOUT_DEC.ToString());
                                ds.SetItemString(iRow, "patchamout", m_objDetailList[i].RETAMOUT_DEC.ToString());
                                ds.SetItemString(iRow, "patchmoney", m_objDetailList[i].m_dblReturnPrice.ToString("0.0000"));
                            }
                            clsPublic.PrintDialog(ds);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    m_mthGetReturnMedicine();
                }
                else
                {
                    MessageBox.Show("退药失败！");
                }
            }

        }
       /// <summary>
       /// 判断是否存在该确认
       /// </summary>
       /// <param name="m_strEmpNo"></param>
       /// <param name="m_strPwd"></param>
       /// <returns></returns>
        public bool m_mthJudgeExistEmp(string m_strEmpNo,string m_strPwd,ref string m_strEmpid)
        {
            DataTable dt = new DataTable();
            m_strEmpid = string.Empty;
            long lngRes = -1;
            lngRes = m_objDomain.m_lngGetEmpInfo(m_strEmpNo, m_strPwd, ref dt);
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                m_strEmpid = dt.Rows[0][0].ToString();
                return true;
            }
            else
                return false;

        }
    

    }
}
