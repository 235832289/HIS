using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using Sybase.DataWindow;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsSealedLisApplyReportPrint 的摘要说明。
    /// </summary>
    public class clsSealedBIHLisApplyReportPrint
    {
        #region initalParameter
        PrintDocument m_printDoc;
        PrintDocument printDocBarcode;
        PrintDialog m_printDlg;
        PrintPreviewDialog m_printPrev;
        clsBIHApplySinglePrintTool m_objReportPrint;
        clsLisApplyReportInfo_VO m_objReportInfo = null;
        /// <summary>
        /// 打印机名称
        /// </summary>
        string strPrinterName = null;

        bool m_blnPrintShowDialog = false;
        public bool m_BlnPrintWithDialog
        {
            get
            {
                return m_blnPrintShowDialog;
            }
            set
            {
                m_blnPrintShowDialog = value;
            }
        }

        //xing.chen add for print barcode
        string m_strBarCode = "";
        #endregion

        #region 构造函数
        public clsSealedBIHLisApplyReportPrint()
        {
            m_mthInit();
        }

        public clsSealedBIHLisApplyReportPrint(string p_strApplicationID)
        {
            m_mthInit();
            m_mthGetPrintContent(p_strApplicationID);
        }
        #endregion

        #region Init
        private void m_mthInit()
        {
            m_printDoc = new PrintDocument();
            printDocBarcode = new PrintDocument();
            try
            {
                string strdtPat = Application.StartupPath + @"\LIS_GUI.dll.config";
                System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
                appConfig.Load(strdtPat);
                strPrinterName = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"PrinterName\"]").Attributes["value"].Value;
                if (!string.IsNullOrEmpty(strPrinterName))
                {
                    m_printDoc.PrinterSettings.PrinterName = strPrinterName;
                    //printDocBarcode.PrinterSettings.PrinterName = strPrinterName;
                }
            }
            catch
            { }

            m_objReportPrint = new clsBIHApplySinglePrintTool();
            m_printDoc.PrintController = new System.Drawing.Printing.StandardPrintController();
            m_printDoc.BeginPrint += new PrintEventHandler(m_printDoc_BeginPrint);
            m_printDoc.PrintPage += new PrintPageEventHandler(m_printDoc_PrintPage);
            m_printDoc.EndPrint += new PrintEventHandler(m_printDoc_EndPrint);

            printDocBarcode.BeginPrint += new PrintEventHandler(printDocBarcode_BeginPrint);
            printDocBarcode.PrintPage += new PrintPageEventHandler(printDocBarcode_PrintPage);
        }
        #endregion

        #region SetPrintContent
        public void m_mthGetPrintContent(string p_strApplicationID)
        {
            long lngRes = 0;
            clsDomainController_ApplicationManage objManage = new clsDomainController_ApplicationManage();
            lngRes = objManage.m_lngGetApplicationReportInfo(p_strApplicationID, out m_objReportInfo);

            #region 取得收费状态 lyoubing (在申请单打印时不用打印收费状态 modified by lyoubing 2005.08.04)
            //			if(lngRes > 0 && m_objReportInfo != null)
            //			{
            //				lngRes = 0;
            //				lngRes = clsDomainController_ApplicationManage.m_lngGetChargeState(p_strApplicationID);
            //				switch(lngRes)
            //				{
            //					case 0:
            //						m_objReportInfo.m_strChargeState = "";
            //						break;
            //					case 1:
            //						m_objReportInfo.m_strChargeState = "未 付费";
            //						break;
            //					case 2:
            //						m_objReportInfo.m_strChargeState = "已 付费";
            //						break;
            //					default:
            //						m_objReportInfo.m_strChargeState = "";
            //						break;
            //				}
            //			}
            #endregion
        }
        public void m_mthGetPrintContent(string p_strApplicationID, string p_strBarCode)
        {
            long lngRes = 0;
            clsDomainController_ApplicationManage objManage = new clsDomainController_ApplicationManage();
            lngRes = objManage.m_lngGetApplicationReportInfo(p_strApplicationID, out m_objReportInfo);
            this.m_strBarCode = p_strBarCode;

            long lngResExt = 0;

            #region 取得收费状态 lyoubing (在申请单打印时不用打印收费状态 modified by lyoubing 2005.08.04)
            //			if(lngRes > 0 && m_objReportInfo != null)
            //			{
            //				lngRes = 0;
            //				lngRes = clsDomainController_ApplicationManage.m_lngGetChargeState(p_strApplicationID);
            //				switch(lngRes)
            //				{
            //					case 0:
            //						m_objReportInfo.m_strChargeState = "";
            //						break;
            //					case 1:
            //						m_objReportInfo.m_strChargeState = "未 付费";
            //						break;
            //					case 2:
            //						m_objReportInfo.m_strChargeState = "已 付费";
            //						break;
            //					default:
            //						m_objReportInfo.m_strChargeState = "";
            //						break;
            //				}
            //			}
            #endregion
        }
        #endregion

        #region printDocumentEvent
        private void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_objReportPrint.m_mthInitPrintTool(m_printDoc);
            if (this.m_strBarCode != null && this.m_strBarCode.Trim() != "")
            {
                m_objReportPrint.m_mthBeginPrint(m_objReportInfo, this.m_strBarCode);
            }
            else
            {
                m_objReportPrint.m_mthBeginPrint(m_objReportInfo);
            }
        }

        private void m_printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_objReportPrint.m_mthPrintPage(e);
        }

        private void m_printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_objReportPrint.m_mthEndPrint(e);
        }
        #endregion

        #region publicMethod
        public void m_mthPrintPreview()
        {
            try
            {
                //m_printDlg = new PrintDialog();
                //DialogResult dlgRes = m_printDlg.ShowDialog();
                //if (dlgRes == DialogResult.OK)
                //{

                m_printPrev = new PrintPreviewDialog();
                m_printPrev.PrintPreviewControl.Zoom = 1;
                m_printPrev.Document = m_printDoc;
                //m_printPrev.Document.PrinterSettings = m_printDlg.PrinterSettings;
                m_printPrev.ShowDialog();
                //}
            }
            catch
            {
                MessageBox.Show("打印预览失败！");
            }
        }

        public void m_mthPrint()
        {
            try
            {
                if (m_blnPrintShowDialog)
                {
                    m_printDlg = new PrintDialog();
                    m_printDlg.Document = m_printDoc;
                    DialogResult dlgRes = m_printDlg.ShowDialog();
                    if (dlgRes == DialogResult.OK)
                    {
                        m_printDoc.Print();
                    }
                }
                else
                {
                    m_printDoc.Print();
                }
            }
            catch
            {
                MessageBox.Show("打印失败！");
            }
        }

        public void m_mthPrint(string printName)
        {
            try
            {
                m_printDoc.PrinterSettings.PrinterName = printName;
                m_printDoc.Print();
            }
            catch
            {
                MessageBox.Show("打印失败！");
            }
        }
        #endregion

        #region 申请单预览和打印
        /// <summary>
        /// 申请单预览和打印
        /// </summary>
        /// <param name="Moudle">0 直接打印 1 预览</param>
        public void m_mthReport(int Moudle, string p_strPrinterName)
        {
            //修改打印机设置
            if (!string.IsNullOrEmpty(p_strPrinterName))
            {
                printDocBarcode.PrinterSettings.PrinterName = p_strPrinterName;
            }
            else
            {
                if (!string.IsNullOrEmpty(strPrinterName))
                {
                    printDocBarcode.PrinterSettings.PrinterName = p_strPrinterName;
                }
                else
                {
                    printDocBarcode.PrinterSettings.PrinterName = "lis_applybill";
                }
            }
            if (Moudle == 0)
            {
                printDocBarcode.Print();
            }
            else if (Moudle == 1)
            {
                m_printPrev = null;
                m_printPrev = new PrintPreviewDialog();
                m_printPrev.PrintPreviewControl.Zoom = 1;
                m_printPrev.Document = printDocBarcode;
                m_printPrev.ShowDialog();
            }
        }
        #endregion

        #region 申请单预览和打印
        /// <summary>
        /// 申请单预览和打印
        /// </summary>
        /// <param name="Moudle">0 直接打印 1 预览</param>
        public void m_mthReport_bak(int Moudle, string p_strPrinterName)
        {
            DataStore dsApplyBill = new DataStore();
            dsApplyBill.LibraryList = Application.StartupPath + @"\pb_lis.pbl";
            dsApplyBill.DataWindowObject = "d_lis_applybill";
            dsApplyBill.InsertRow(0);

            if (this.m_strBarCode != null && this.m_strBarCode.Trim() != "")
            {
                string BmpFile = "";
                //Barcode.clsBarcodeBmp bcode = new Barcode.clsBarcodeBmp();
                ////bcode.GetBarcode_Code39(this.m_strBarCode, out BmpFile);
                //bcode.GetBarcode_Code128(this.m_strBarCode, out BmpFile);
                //bcode = null;

                clsBarcodeMaker objBarcode = new clsBarcodeMaker();
                objBarcode.CreateBarcodeBMP(this.m_strBarCode, out BmpFile);
                objBarcode = null;

                dsApplyBill.Modify("p_barcode.filename = '" + BmpFile + "'");
                dsApplyBill.Modify("t_barcode.text = '" + this.m_strBarCode + "'");
            }

            if (this.m_objReportInfo.m_strEmergency == "1")
            {
                dsApplyBill.Modify("t_emergency.text = '急'");
            }
            else
            {
                dsApplyBill.Modify("t_emergency.text = ''");
            }

            if (m_objReportInfo.m_strPatientType == "1" || m_objReportInfo.m_strPatientType == "3")
            {
                dsApplyBill.Modify("t_inpatidorcardid.text = '" + m_objReportInfo.m_strPatientInHospitalNO + "'");
            }
            else
            {
                dsApplyBill.Modify("t_inpatidorcardid.text = '" + m_objReportInfo.m_strOutPatientNO + "'");
            }

            dsApplyBill.Modify("t_patname.text = '" + m_objReportInfo.m_strPatientName + "'");
            dsApplyBill.Modify("t_age.text = '" + m_objReportInfo.m_strAge + "'");
            dsApplyBill.Modify("t_sex.text = '" + m_objReportInfo.m_strSex + "'");
            dsApplyBill.Modify("t_deptname.text = '" + m_objReportInfo.m_strApplyDept + "'");
            dsApplyBill.Modify("t_bedno.text = '" + m_objReportInfo.m_strBedNO + "'");
            dsApplyBill.Modify("t_sample.text = '" + m_objReportInfo.m_strSampleType + "'");
            if (!string.IsNullOrEmpty(m_objReportInfo.m_strColor))
            {
                dsApplyBill.Modify("t_color.text = '" + m_objReportInfo.m_strColor + "'");
            }

            string ItemName = m_mthAutoHeight(m_objReportInfo.m_strCheckContent.Trim());

            dsApplyBill.Modify("t_itemname.text = '" + ItemName + "'");
            dsApplyBill.Modify("t_applytime.text = '" + m_objReportInfo.m_strCollectDat + "'");

            //修改打印机设置
            if (!string.IsNullOrEmpty(p_strPrinterName))
            {
                dsApplyBill.PrintProperties.PrinterName = p_strPrinterName;
            }
            else
            {
                if (!string.IsNullOrEmpty(strPrinterName))
                {
                    dsApplyBill.PrintProperties.PrinterName = strPrinterName;
                }
                else
                {
                    dsApplyBill.PrintProperties.PrinterName = "lis_applybill";
                }
            }
            if (Moudle == 0)
            {
                dsApplyBill.Print(true);
            }
            else if (Moudle == 1)
            {
                clsPublic.PrintDialog(dsApplyBill);
            }

            dsApplyBill = null;
        }
        #endregion

        #region printDocBarcode_BeginPrint
        /// <summary>
        /// printDocBarcode_BeginPrint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void printDocBarcode_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            System.Drawing.Printing.PaperSize ps = new System.Drawing.Printing.PaperSize("标本条码", 196, 118);
            this.printDocBarcode.DefaultPageSettings.PaperSize = ps;
        }
        #endregion

        #region printDocBarcode_PrintPage
        /// <summary>
        /// printDocBarcode_PrintPage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void printDocBarcode_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float currY = 8;
            float diff = 14;
            //SpireLamella.BarCode128 bar128 = new SpireLamella.BarCode128();
            Image imgbarCode = null;

            string barCode = this.m_strBarCode;
            string ipNo = string.Empty;
            if (m_objReportInfo.m_strPatientType == "1" || m_objReportInfo.m_strPatientType == "3")
            {
                ipNo = m_objReportInfo.m_strPatientInHospitalNO;
            }
            else
            {
                ipNo = m_objReportInfo.m_strOutPatientNO;
            }
            string patName = m_objReportInfo.m_strPatientName;
            string age = m_objReportInfo.m_strAge;
            string sex = m_objReportInfo.m_strSex;
            string deptName = m_objReportInfo.m_strApplyDept;
            string bedNo = m_objReportInfo.m_strBedNO + "床";
            string sampleType = m_objReportInfo.m_strSampleType;
            string applyTime = m_objReportInfo.m_strCollectDat;
            string colorAmont = m_objReportInfo.m_strColor;
            string itemName = m_objReportInfo.m_strCheckContent.Trim();
            string emergency = (this.m_objReportInfo.m_strEmergency == "1" ? "急" : "");

            System.Drawing.Font TextFont = new Font("宋体", 8);
            System.Drawing.Font TextWideFont = new Font("宋体", 8, FontStyle.Bold);
            float currX = 8;

            currX = 15;
            imgbarCode = SpireLamella.BarCode128New.BuildBarCode(this.m_strBarCode, 25); //bar128.EncodeBarcode(this.m_strBarCode, 178, 25, false);   // 179
            e.Graphics.DrawImage(imgbarCode, currX - 5, currY);
            //bar128 = null;
            currX += imgbarCode.Width + 5;
            e.Graphics.DrawString(emergency, TextFont, Brushes.Black, currX, currY);

            currX = 6;
            currY += diff + 15;
            e.Graphics.DrawString(barCode, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(barCode, TextFont).Width + 5;
            e.Graphics.DrawString(ipNo, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(ipNo, TextFont).Width + 25;
            e.Graphics.DrawString(sampleType, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(sampleType, TextFont).Width + 5;

            currX = 6;
            currY += diff;
            e.Graphics.DrawString(bedNo, TextWideFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(bedNo, TextWideFont).Width + 2;
            //if (patName.Length > 3) patName = patName.Substring(0, 3);
            e.Graphics.DrawString(patName, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(patName, TextFont).Width + 2;
            e.Graphics.DrawString(sex, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(sex, TextFont).Width + 2;
            e.Graphics.DrawString(age, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(age, TextFont).Width + 2;
            e.Graphics.DrawString(deptName, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(deptName, TextFont).Width + 2;

            currX = 6;
            int subCount = 17;
            int k = itemName.Length / subCount;
            for (int p = 0; p < k; p++)
            {
                currY += diff;
                e.Graphics.DrawString(itemName.Substring(subCount * p, subCount), TextFont, Brushes.Black, currX, currY);
            }

            if (itemName.Length - (k * subCount) > 0)
            {
                currY += diff;
                e.Graphics.DrawString(itemName.Substring(subCount * k, itemName.Length - (k * subCount)), TextFont, Brushes.Black, currX, currY);
            }

            currX = 6;
            currY = 105;
            e.Graphics.DrawString(applyTime, TextFont, Brushes.Black, currX, currY);
            currX += e.Graphics.MeasureString(applyTime, TextFont).Width + 10;
            e.Graphics.DrawString(colorAmont, TextFont, Brushes.Black, currX, currY);

        }
        #endregion

        private string m_mthAutoHeight(string p_ItemName)
        {
            string p_Result = "";
            if (p_ItemName.Length > 15)
            {
                int i1 = p_ItemName.Length / 15;
                for (int i2 = 0; i2 < i1; i2++)
                {
                    p_Result += p_ItemName.Substring(0, 15) + @"~r~n";
                    p_ItemName = p_ItemName.Substring(15);
                }
                if (!string.IsNullOrEmpty(p_ItemName))
                {
                    p_Result += p_ItemName;
                }
            }
            else
            {
                return p_ItemName;
            }
            return p_Result;
        }
    }
}
