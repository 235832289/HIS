using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HIS;
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.HI;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmInvoiceBulkPrint : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmInvoiceBulkPrint()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkInvoDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpInvoDate_Start.Enabled = chkInvoDate.Checked;
            dtpInvoDate_End.Enabled = chkInvoDate.Checked;
        }

        private void dgvInvoList_NotPrint_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,

                e.RowBounds.Location.Y,

                dgvInvoList_NotPrint.RowHeadersWidth - 4,

                e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),

                dgvInvoList_NotPrint.RowHeadersDefaultCellStyle.Font,

                rectangle,

                dgvInvoList_NotPrint.RowHeadersDefaultCellStyle.ForeColor,

                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBulkPrint_Click(object sender, EventArgs e)
        {
            if (dgvInvoList_NotPrint.Rows.Count == 0)
            {
                return;
            }

            string strEmpId = this.LoginInfo.m_strEmpID;// iCareBase.Global.Info.clsGlobalValueTool.m_ObjGlobalEmployee.m_strEMPID_CHR;
            string strEmpName = this.LoginInfo.m_strEmpName;// iCare.Base.Global.Info.clsGlobalValueTool.m_ObjGlobalEmployee.m_strLASTNAME_VCHR;
            string strHospitalId = ""; //iCare.Base.Global.Info.clsGlobalValueTool.m_OblGlobalHospital.m_strHOSPITALID_CHR;
            Dictionary<string, string> dictRePrint = new Dictionary<string, string>();
            foreach (DataGridViewRow dgvrTemp in dgvInvoList_NotPrint.Rows)
            {
                if (dgvrTemp.Tag == null)
                {
                    continue;
                }
                DataRow dtrTemp = dgvrTemp.Tag as DataRow;
                string strSeqId = dtrTemp["seqid"].ToString().Trim();
                string strOldInvoNo = dtrTemp["invono"].ToString().Trim();
                if (!dictRePrint.ContainsKey(strSeqId))
                {
                    dictRePrint.Add(strSeqId, strOldInvoNo);
                }
            }
            if (dictRePrint.Count == 0)
            {
                return;
            }

            frmInvoiceBulkPrint_SetInvoRange objForm = new frmInvoiceBulkPrint_SetInvoRange(strHospitalId, strEmpId, strEmpName, dictRePrint.Count);
            if (objForm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            if (objForm.NewRePrintInvoList.Count == 0)
            {
                return;
            }

            clsPublic.PlayAvi("findFILE.avi", "正在打印，请稍候...");
            try
            {
               // iCare.Opd.Base.Gui.clsOpdInvoice objInvo = new iCare.Opd.Base.Gui.clsOpdInvoice();
             //   iCare.Opd.Print.Invoice.Gui.clsChargeInvoicePrinter objInvo_prt = new iCare.Opd.Print.Invoice.Gui.clsChargeInvoicePrinter();
                string strCurrentNewRePrintInvo = "";
                int intHavePrintCount = 0;
                int intIndex = -1;
                foreach (string strSeqId in dictRePrint.Keys)
                {
                    ++intIndex;
                    if (intIndex >= objForm.NewRePrintInvoList.Count)
                    {
                        break;
                    }
                    string strOldInvo = dictRePrint[strSeqId];
                    string strNewRePrintInvo = objForm.NewRePrintInvoList[intIndex];
                   // clsOPChargeSvc objOpchar = new clsOPChargeSvc();
                  //  long l = objOpchar.m_lngSaveinvorepeatprninfo("1", strSeqId, strOldInvo, strNewRePrintInvo, strEmpId);
                  ////  long l = objInvo.m_lngSaveRepeatPrintInoviceNo(strHospitalId, 1, strSeqId, strOldInvo, strNewRePrintInvo, strEmpId);
                  //  if (l != 1)
                  //  {
                  //      MessageBox.Show("保存发票重打信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  //      break;
                  //  }

                    try
                    {
                        if (strNewRePrintInvo == "" || strNewRePrintInvo == null)
                        {
                           // objInvo_prt.RepeatNo = "+";//+代表重打发票
                        }
                        else
                        {
                          //  objInvo_prt.RepeatNo = strNewRePrintInvo;
                        }
                        clsOPChargeQuerySvc objChar = new clsOPChargeQuerySvc();
                        clsCalcPatientCharge objCalPatientCharge = new clsCalcPatientCharge(objChar.m_mthGetHospitalName());                        
                        objCalPatientCharge.m_mthBulkReprintinvoice(strSeqId, strEmpId, 0, strOldInvo, strNewRePrintInvo);

                      //  objInvo_prt.m_mthPrint(strOldInvo, false);
                    }
                    catch
                    {
                        MessageBox.Show("新发票号(" + strNewRePrintInvo + ")已保存发票重打信息成功，但打印失败，请凭该发票号使用重打发票功能重打该发票。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    strCurrentNewRePrintInvo = strNewRePrintInvo;
                    ++intHavePrintCount;
                }

                if (strCurrentNewRePrintInvo != "")
                {
                  //  bool blnSuccess = objInvo.m_blnSaveCurrInvoiceNo(strEmpId, strCurrentNewRePrintInvo, 3);
                    //if (!blnSuccess)
                    //{
                    //    MessageBox.Show("保存当前发票号码失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }

             //   iCare.Pub.Utility.clsMessageBox.Show("已成功打印" + intHavePrintCount + "张发票，尚未打印" + (dictRePrint.Count - intHavePrintCount) + "张发票。");

               //objInvo = null;
               // objInvo_prt = null;
            }
            finally
            {
                clsPublic.CloseAvi();
            }

            btnQuery_Click(null, null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            lblInvoCount.Text = "";
            lblInvoMoney.Text = "";
            dgvInvoList_NotPrint.Rows.Clear();
            bool blnHavePirnt = chkHavePrint.Checked;
            DateTime dtmInvoDate_Start = DateTime.MinValue;
            DateTime dtmInvoDate_End = DateTime.MinValue;
            if (chkInvoDate.Checked)
            {
                dtmInvoDate_Start = dtpInvoDate_Start.Value.Date;
                dtmInvoDate_End = dtpInvoDate_End.Value.Date.AddDays(1).AddSeconds(-1);
            }

            clsPublic.PlayAvi("findFILE.avi", "正在查询，请稍候...");
            try
            {
                DataTable dtbResult = null;

                #region 中间件操作
                clsOPChargeQuerySvc objServ = null;
                long lngRes = -1;
                try
                {
                    objServ = (clsOPChargeQuerySvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsOPChargeQuerySvc));
                    //to do
                    lngRes = objServ.m_lngGetSelfHelpInvo_NotPrint(blnHavePirnt, dtmInvoDate_Start, dtmInvoDate_End, this.txtEmpNo.Text.ToString().Trim(), out dtbResult);
                }
                catch (Exception exp)
                {
                    clsLogText objLogger = new clsLogText();
                    objLogger.LogError("连接中间件clsOPCharge_SupportedSvc)操作异常，" + exp.Message);
                }
                finally
                {
                    if (objServ != null)
                    {
                        objServ.Dispose();
                        objServ = null;
                    }
                }
                #endregion

                if (dtbResult != null && dtbResult.Rows.Count > 0)
                {
                    int intRowsCount = dtbResult.Rows.Count;
                    dgvInvoList_NotPrint.Rows.Add(intRowsCount);
                    decimal decTotalMoney = 0;
                    for (int i1 = 0; i1 < intRowsCount; i1++)
                    {
                        DataRow dtrTemp = dtbResult.Rows[i1];
                        dgvInvoList_NotPrint.Rows[i1].Cells[colInvoDate.Name].Value = dtrTemp["invodate"].ToString().Trim();
                        dgvInvoList_NotPrint.Rows[i1].Cells[colInvoNo.Name].Value = dtrTemp["invono"].ToString().Trim();
                        dgvInvoList_NotPrint.Rows[i1].Cells[colChargeEmpName.Name].Value = dtrTemp["chargeempname"].ToString().Trim();
                        dgvInvoList_NotPrint.Rows[i1].Cells[colPatientCard.Name].Value = dtrTemp["patientcard"].ToString().Trim();
                        dgvInvoList_NotPrint.Rows[i1].Cells[colPatientName.Name].Value = dtrTemp["patientname"].ToString().Trim();
                        dgvInvoList_NotPrint.Rows[i1].Cells[colPayTypeName.Name].Value = dtrTemp["paytpyename"].ToString().Trim();
                        decimal decTemp = ConvertObjToDecimal(dtrTemp["invomoney"].ToString().Trim());
                        decTotalMoney += decTemp;
                        dgvInvoList_NotPrint.Rows[i1].Cells[colInvoMoney.Name].Value = decTemp.ToString();
                        dgvInvoList_NotPrint.Rows[i1].Cells[colRepInvoNo.Name].Value = dtrTemp["repinvono"].ToString().Trim();
                        dgvInvoList_NotPrint.Rows[i1].Tag = dtrTemp;
                    }
                    lblInvoCount.Text = intRowsCount.ToString();
                    lblInvoMoney.Text = decTotalMoney.ToString();
                }
            }
            finally
            {
              //  iCare.Opd.Base.Gui.ProgressBar.Hide();
                clsPublic.CloseAvi();//.PlayAvi("findFILE.avi", "正在查询，请稍候...");
            }
        }

        private void frmInvoiceBulkPrint_Shown(object sender, EventArgs e)
        {
            DateTime dtmNow = DateTime.Now; //iCare.Opd.Base.Gui.clsOpdPublic.m_dtGetCurrentTime();
            dtpInvoDate_Start.Value = dtmNow.Date;
            dtpInvoDate_End.Value = dtmNow.AddDays(1).AddSeconds(-1);
            btnQuery.Focus();
        }

        private void chkHavePrint_CheckedChanged(object sender, EventArgs e)
        {
            lblInvoCount.Text = "";
            lblInvoMoney.Text = "";
            dgvInvoList_NotPrint.Rows.Clear();
            if (chkHavePrint.Checked)
            {
                groupBox1.Text = "自助机已打印的凭证列表";
                colRepInvoNo.Visible = true;
                btnBulkPrint.Enabled = false;
                chkInvoDate.Checked = true;
                chkInvoDate.Enabled = false;
            }
            else
            {
                groupBox1.Text = "自助机尚未打印的凭证列表";
                colRepInvoNo.Visible = false;
                btnBulkPrint.Enabled = true;
                chkInvoDate.Checked = true;
                chkInvoDate.Enabled = true;
            }
        }

        #region 转换成数字
        private decimal ConvertObjToDecimal(object obj)
        {
            if (obj != null && obj.ToString() != "")
            {
                return Convert.ToDecimal(obj.ToString());

            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
