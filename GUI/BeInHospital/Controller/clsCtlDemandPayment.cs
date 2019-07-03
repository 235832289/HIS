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
    /// 病区催款界面控制
    /// </summary>
    public class clsCtlDemandPayment : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclDemandPayment m_objDomain;
        private frmDemandPayment m_objViewer;

        //病人信息
        private DataTable m_dtPatient;
        //预交款信息
        private DataTable m_dtPrepay;
        //费用信息
        private DataTable m_dtFee;

        public clsCtlDemandPayment()
        {
            m_objDomain = new clsDclDemandPayment();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDemandPayment)frmMDI_Child_Base_in;
        }
        #endregion

        public void GetAreaDemandPayment()
        {
            string areaId = this.m_objViewer.m_txtArea.Value.Trim();
            if (areaId == null || areaId == "")
            {
                return;
            }

            try
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                long lngRe;
                //lngRe = m_objDomain.GetPatientByAreaId(areaId, out m_dtPatient);
                lngRe = m_objDomain.GetPatientByAreaId(areaId, this.m_objViewer.dteBeginDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.dteEndDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_blnInHospitalFlag, out m_dtPatient);
                if (lngRe <= 0 || m_dtPatient.Rows.Count == 0)
                {
                    return;
                }

                //lngRe = m_objDomain.GetFeeByAreaIdSum(areaId, out m_dtFee);                       
                lngRe = m_objDomain.GetFeeByAreaIdSum(areaId, this.m_objViewer.dteBeginDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.dteEndDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_blnInHospitalFlag, out m_dtFee);
                if (lngRe <= 0)
                {
                    return;
                }

                //lngRe = m_objDomain.GetPrepayByAreaId(areaId, out m_dtPrepay);
                lngRe = m_objDomain.GetPrepayByAreaId(areaId, this.m_objViewer.dteBeginDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.dteEndDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_blnInHospitalFlag, out m_dtPrepay);

                FillDataGridView();

            }
            finally
            {
                this.m_objViewer.Cursor = Cursors.Default;
            }
        }

        #region 打印个人催款单
        public void PrintProVioce()
        {
            int row = this.m_objViewer.m_dgvDetail.SelectedRows.Count;
            if (row == 0)
                return;

            Sybase.DataWindow.DataStore ds = new Sybase.DataWindow.DataStore();
            try
            {
                ds.LibraryList = Application.StartupPath + "\\pbreport.pbl";
                //ds.DataWindowObject = "d_demandpayment_pro";
                ds.DataWindowObject = "d_demandpayment_cs";

                ds.Reset();
                ds.InsertRow(0);
                //ds.Modify("t_operator.text = '" + this.m_objViewer.LoginInfo.m_strEmpName + "'");
                //ds.Modify("t_paycarddesc.text = '" + this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["PAYCARDDESC_VCHR"].Value.ToString() + "'");
                //ds.Modify("t_name.text = '" + this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["LASTNAME_VCHR"].Value.ToString() + "'");
                //ds.Modify("t_inpatientid.text = '" + this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["INPATIENTID_CHR"].Value.ToString() + "'");
                //ds.Modify("t_area.text = '" + this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["AreaName"].Value.ToString() + "'");
                //ds.Modify("t_bedno.text = '" + this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["CODE_CHR"].Value.ToString() + "'");
                decimal balDecl = Math.Abs(decimal.Parse(this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["BalanceFee"].Value.ToString()));
                decimal balPre = Math.Abs(decimal.Parse(this.m_objViewer.m_dgvDetail.SelectedRows[0].Cells["PrepayMoney"].Value.ToString()));
                ds.Modify("t_prepay.text = '" + balPre.ToString("0.00") + "元" + "'");
                ds.Modify("t_balance.text = '" + balDecl.ToString("0.00") + "元" + "'");

                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();
                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    ds.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    ds.Print(false, false);
                }
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }
        #endregion

        #region 批量打印个人催款单
        public void PrintAllVioce()
        {
            int rowCount = this.m_objViewer.m_dgvDetail.Rows.Count;
            if (rowCount == 0)
                return;

            Sybase.DataWindow.DataStore ds = new Sybase.DataWindow.DataStore();
            try
            {
                ds.LibraryList = Application.StartupPath + "\\pbreport.pbl";
                //ds.DataWindowObject = "d_demandpayment_pro";
                ds.DataWindowObject = "d_demandpayment_cs";

                ds.Reset();
                ds.InsertRow(0);

                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();
                //选择打印机
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    ds.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;

                    for (int i = 0; i < rowCount; i++)
                    {
                        //ds.Modify("t_operator.text = '" + this.m_objViewer.LoginInfo.m_strEmpName + "'");
                        //ds.Modify("t_paycarddesc.text = '" + this.m_objViewer.m_dgvDetail.Rows[i].Cells["PAYCARDDESC_VCHR"].Value.ToString() + "'");
                        //ds.Modify("t_name.text = '" + this.m_objViewer.m_dgvDetail.Rows[i].Cells["LASTNAME_VCHR"].Value.ToString() + "'");
                        //ds.Modify("t_inpatientid.text = '" + this.m_objViewer.m_dgvDetail.Rows[i].Cells["INPATIENTID_CHR"].Value.ToString() + "'");
                        //ds.Modify("t_area.text = '" + this.m_objViewer.m_dgvDetail.Rows[i].Cells["AreaName"].Value.ToString() + "'");
                        //ds.Modify("t_bedno.text = '" + this.m_objViewer.m_dgvDetail.Rows[i].Cells["CODE_CHR"].Value.ToString() + "'");
                        decimal balDecl = Math.Abs(decimal.Parse(this.m_objViewer.m_dgvDetail.Rows[i].Cells["BalanceFee"].Value.ToString()));
                        decimal balPre = Math.Abs(decimal.Parse(this.m_objViewer.m_dgvDetail.Rows[i].Cells["PrepayMoney"].Value.ToString()));
                        ds.Modify("t_prepay.text = '" + balPre.ToString("0.00") + "元" + "'");
                        ds.Modify("t_balance.text = '" + balDecl.ToString("0.00") + "元" + "'");

                        ds.Print(false);
                    }
                }
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }
        #endregion

        private void FillDataGridView()
        {
            this.m_objViewer.m_dgvDetail.Rows.Clear();
            //patient view
            DataView dvPat = new DataView(this.m_dtPatient);

            if (dvPat.Count == 0)
                return;

            decimal maxMoney;
            try
            {
                maxMoney = decimal.Parse(this.m_objViewer.m_txtMaxMoney.Text.ToString());
            }
            catch
            {
                //if (this.m_objViewer.m_cmbStatus.SelectedIndex == 0)
                //{
                maxMoney = decimal.Parse("9999999999999.00");
                //}
                //else
                //{
                //    maxMoney = decimal.Parse("0.00");
                //}
            }

            if (this.m_objViewer.m_ckbWaitCharge.Checked == true)
            {
                this.m_objViewer.m_dgvDetail.Columns["WaitChargeFee"].Visible = true;
            }
            else
            {
                this.m_objViewer.m_dgvDetail.Columns["WaitChargeFee"].Visible = false;
            }

            clsBihPatient_VO patient_VO;

            //当前医保统筹金额 
            decimal insuredsum = 0;
            foreach (DataRowView drvPat in dvPat)
            {
                GetPatienFeeInfo(drvPat["REGISTERID_CHR"].ToString(), out patient_VO);

                try
                {
                    insuredsum = Decimal.Parse(drvPat["insuredsum_mny"].ToString());
                }
                catch
                {
                    insuredsum = 0;
                }

                patient_VO.BalanceMoney += insuredsum;

                //处理欠费状态 将欠
                if (this.m_objViewer.m_ckbLeft.Checked == false
                    && this.m_objViewer.m_cmbStatus.SelectedIndex == 2
                    && patient_VO.LimtRate < patient_VO.BalanceMoney)
                {
                    continue;
                }

                //处理欠费状态 已欠
                if (this.m_objViewer.m_ckbLeft.Checked == false
                    && this.m_objViewer.m_cmbStatus.SelectedIndex == 1
                    && patient_VO.BalanceMoney >= 0)
                {
                    continue;
                }

                //是否含0费用
                if (this.m_objViewer.m_ckbInclude.Checked == false && patient_VO.TotalFee <= 0)
                {
                    continue;
                }

                if (patient_VO.BalanceMoney > maxMoney)
                {
                    continue;
                }

                string[] s = new string[17];

                s[0] = drvPat["DEPTNAME_VCHR"].ToString();
                s[1] = drvPat["CASEDOCTOR"].ToString();
                s[2] = drvPat["CODE_CHR"].ToString();
                s[3] = drvPat["INPATIENTID_CHR"].ToString();
                s[4] = drvPat["PATIENTCARDID_CHR"].ToString();

                s[5] = drvPat["LASTNAME_VCHR"].ToString();
                s[6] = drvPat["PAYTYPENAME_VCHR"].ToString();
                s[7] = "";
                s[8] = patient_VO.TotalFee.ToString();
                s[9] = patient_VO.WaitClearFee.ToString();

                s[10] = patient_VO.WaitChargeFee.ToString();
                s[11] = patient_VO.PrepayMoney.ToString();
                s[12] = patient_VO.BalanceMoney.ToString();
                s[13] = patient_VO.LimtRate.ToString();
                s[14] = drvPat["REMARKNAME_VCHR"].ToString();
                s[15] = drvPat["DES_VCHR"].ToString();
                s[16] = drvPat["REGISTERID_CHR"].ToString();

                this.m_objViewer.m_dgvDetail.Rows.Add(s);
            }
        }

        private void GetPatienFeeInfo(string registerId, out clsBihPatient_VO patient_VO)
        {
            patient_VO = new clsBihPatient_VO();

            //Prepay view
            DataView dvPrepay = new DataView(this.m_dtPrepay);
            dvPrepay.RowFilter = "registerid_chr = '" + registerId + "'";
            if (dvPrepay.Count > 0)
            {
                patient_VO.PrepayMoney = Convert.ToDecimal(dvPrepay[0]["balancetotal"].ToString());
            }
            else
            {
                patient_VO.PrepayMoney = 0;
            }

            //Fee view
            DataView dvFee = new DataView(this.m_dtFee);
            dvFee.RowFilter = "REGISTERID_CHR = '" + registerId + "'";
            //if (dvFee.Count == 0)
            //    return;

            //获取总费用、待结、待清、直接收费、已清、结余
            decimal TotalFee = 0;
            decimal WaitChargeFee = 0;
            decimal WaitClearFee = 0;
            decimal DirectorFee = 0;
            decimal CompleteClearFee = 0;
            //string ClearFeeDate = "";
            //int NoChargeDays = 0;

            for (int i = 0; i < dvFee.Count; i++)
            {
                //单项总费用
                //decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dvFee[i]["UNITPRICE_DEC"]) * clsPublic.ConvertObjToDecimal(dvFee[i]["AMOUNT_DEC"]), 2);
                decimal d = clsPublic.ConvertObjToDecimal(dvFee[i]["Money"]) + clsPublic.Round(clsPublic.ConvertObjToDecimal(dvFee[i]["totaldiffcostmoney_dec"]), 2);

                //费用状态 0 待确认 1 待结 2 待清 3 已清 4 直收 
                int pstatus = Convert.ToInt32(dvFee[i]["PSTATUS_INT"].ToString());
                if (pstatus == 1)
                {
                    if (this.m_objViewer.m_ckbWaitCharge.Checked == true)
                    {
                        WaitChargeFee += d;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (pstatus == 2)
                {
                    WaitClearFee += d;
                }
                else if (pstatus == 3)
                {
                    CompleteClearFee += d;
                }
                else if (pstatus == 4)
                {
                    DirectorFee += d;
                }

                //总费用
                TotalFee += d;
            }

            //WaitChargeFee = decimal.Round(WaitChargeFee, 2);
            //WaitClearFee = decimal.Round(WaitClearFee, 2);

            //结余 ＝ 可用预交金 - 待结 - 待清
            decimal BalanceFee = patient_VO.PrepayMoney - WaitChargeFee - WaitClearFee;
            //decimal BalanceFee = patient_VO.PrepayMoney - WaitClearFee;

            patient_VO.TotalFee = TotalFee;
            patient_VO.WaitChargeFee = WaitChargeFee;
            patient_VO.WaitClearFee = WaitClearFee;
            patient_VO.DirectorFee = DirectorFee;
            patient_VO.CompleteClearFee = CompleteClearFee;
            patient_VO.BalanceMoney = BalanceFee;

            //patient_VO.ClearFeeDate = ClearFeeDate;
            //patient_VO.NoChargeDays = NoChargeDays;

            //Pat view
            DataView dvPat = new DataView(this.m_dtPatient);
            dvPat.RowFilter = "REGISTERID_CHR = '" + registerId + "'";
            if (dvPat.Count > 0)
            {
                patient_VO.LimtRate = clsPublic.ConvertObjToDecimal(dvPat[0]["LIMITRATE_MNY"]);
            }
        }


    }
}
