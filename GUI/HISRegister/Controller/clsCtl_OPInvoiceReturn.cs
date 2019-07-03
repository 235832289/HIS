using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.HI;
using System.Data;
using System.Collections.Generic;
using com.digitalwave.iCare.middletier.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_OPInvoiceReturn : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_InvoiceManage m_objManage = null;
        public string m_strReportID;
        public string m_strOperatorID;
        private string m_strOperateLevel = string.Empty;
        /// <summary>
        /// 发票创建人ID
        /// </summary>
        private string m_strCreatInvoEmpID = string.Empty;
        #endregion

        #region 构造函数
        public clsCtl_OPInvoiceReturn()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_InvoiceManage();
            m_strReportID = null;
            m_strOperatorID = "0000001";
            this.m_strOperateLevel = clsMain.m_strGetCollocate("3101");

        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmOPInvoiceReturn m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOPInvoiceReturn)frmMDI_Child_Base_in;
        }
        #endregion

        #region 发票退回
        /// <summary>
        /// 发票退回
        /// </summary>
        public void m_ReturnTicket()
        {
            //如果发票号为空则返回
            if (m_objViewer.txtInvoice.Text.Trim() == "")
            {
                MessageBox.Show("请输入发票号！", "错误提示框");
                return;
            }

            if (this.m_objViewer.LoginInfo != null)
            {
                m_strOperatorID = this.m_objViewer.LoginInfo.m_strEmpID;
            }
            //验证发票是否存在
            clsT_opr_outpatientrecipeinv_VO objResult = null;
            long lngRet = m_objManage.m_lngGetInfoByNoForReturn(m_objViewer.txtInvoice.Text.Trim(), out objResult);
            if (lngRet <= 0)
            {
                //退票失败！
                MessageBox.Show(m_objViewer, "退票失败!", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (objResult == null || objResult.m_intSTATUS_INT != 1)
            {
                //发票不是有效的发票，退票失败！
                MessageBox.Show(m_objViewer, "此发票不是有效的发票，退票失败!", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //发票未审核,不能退票
            DataTable dt;
            lngRet = m_objManage.m_mthGetInvoiceAuditingInfo(m_objViewer.txtInvoice.Text.Trim(), out dt, 1);
            if (dt.Rows.Count == 0)
            {
                //发票未审核,不能退票
                MessageBox.Show(m_objViewer, "发票未审核,不能退票!", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //			else
            //			{
            //			this.m_objViewer.lbeAuding.Text ="审核人:"+dt.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
            //			}
            // by huafeng.xiao\
            //添加对药品退药的检测
            string m_strStatus = string.Empty;
            lngRet = m_objManage.m_lngReturnTicketCheckOutSendMed(m_objViewer.txtInvoice.Text.Trim(), out m_strStatus);
            if (lngRet > 0)
            {
                if (m_strStatus.Trim() == "1" || m_strStatus.Trim() == "2")
                {

                }
                else
                {
                    MessageBox.Show(m_objViewer, "当前发票已经配发药，请先退药！", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "检测药品信息失败，请与管理员联系！", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Seqid = "";
            int intFlag = 0;
            lngRet = m_objManage.m_lngReturnTicket(m_objViewer.txtInvoice.Text.Trim(), m_strOperatorID, ref Seqid, intFlag);
            if (lngRet <= 0)
            {
                //退票失败！
                MessageBox.Show(m_objViewer, "退票失败！", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //新增嵌入式社保退费，函数里有查询到社保数据才去作退费接口的调用
                //自助机的经办人由于是 711014_ZZZD03  --- 711014_ZZZD01 ，而系统的登录号是截取后面6位，所以在退费的时候要将这些补充完整
                string strEmpNo = this.m_objViewer.LoginInfo.m_strEmpNo;
                if (this.m_objViewer.LoginInfo.m_strEmpNo.Contains("ZZZD"))
                {
                    strEmpNo = "711014_" + strEmpNo;
                }
                clsCtl_YBChargeMZCancel clsYbChargeMZCancel = new clsCtl_YBChargeMZCancel();
                clsYbChargeMZCancel.m_lngCSYBChargeCancel(m_objViewer.txtCardID.Text.Trim(), strEmpNo);
                //退票成功！
                MessageBox.Show(m_objViewer, "退票成功！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (IsPrintInvoice)
                {
                    this.m_objViewer.Cursor = Cursors.WaitCursor;
                    clsCalcPatientCharge objCalPatientCharge = new clsCalcPatientCharge(this.m_objComInfo.m_strGetHospitalTitle());
                    objCalPatientCharge.m_mthReprintinvoice(Seqid, this.m_objViewer.LoginInfo.m_strEmpID, 1);
                    this.m_objViewer.Cursor = Cursors.Default;
                }

            }
            //清空发票号
            m_EmptyInput();
        }

        #endregion

        #region 根据发票号显示物理号
        /// <summary>
        /// 根据发票号显示物理号
        /// </summary>
        public void DisplaySeqNo()
        {
            //			m_objViewer.m_txtSEQID_CHR.Text ="";
            //
            //			//如果发票号为空则返回
            //			if(m_objViewer.m_txtINVOICENO_VCHR.Text.Trim()=="")
            //				return;
            //
            //			clsT_opr_outpatientrecipeinv_VO objResult = null;
            //			long lngRet = m_objManage.m_lngGetInfoByNoForReturn(m_objViewer.m_txtINVOICENO_VCHR.Text.Trim(),out objResult);
            //			if(lngRet>0 && objResult.m_strSEQID_CHR!=null)
            //			{
            //				m_objViewer.m_txtSEQID_CHR.Text = objResult.m_strSEQID_CHR;
            //			}
        }
        #endregion

        #region 根据物理号显示发票号
        public void DisplayInvoiceNo()
        {
            //			m_objViewer.m_txtINVOICENO_VCHR.Text="";
            //
            //			//如果物理号为空则返回
            //			if(m_objViewer.m_txtSEQID_CHR.Text.Trim()=="")
            //				return;
            //
            //			clsT_opr_outpatientrecipeinv_VO objResult = null;
            //			long lngRet = m_objManage.m_lngGetInfoBySeqidForReturn(m_objViewer.m_txtSEQID_CHR.Text.Trim(),out objResult);
            //			if(lngRet>0 && objResult.m_strINVOICENO_VCHR!=null)
            //			{
            //				m_objViewer.m_txtINVOICENO_VCHR.Text = objResult.m_strINVOICENO_VCHR;
            //			}
        }
        #endregion

        #region 显示发票信息
        public void m_DisplayInvoiceInfo()
        {
            //没有发票号则，不显示发票——返回
            if (m_objViewer.txtInvoice.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请选择发票号", "系统提示");
                return;
            }

            //分票不能退票
            if (m_objManage.m_blnChecksplit(m_objViewer.txtInvoice.Text.Trim()))
            {
                string invoinfo = "";
                DataTable dt1 = new DataTable();
                long l = m_objManage.m_lngGetsplitinvoinfo(m_objViewer.txtInvoice.Text.Trim(), out dt1);
                if (dt1.Rows.Count > 1)
                {
                    for (int i = 0; i < dt1.Rows.Count; i++)
                    {
                        invoinfo += "\r\n\r\n发票" + (i + 1).ToString() + "号码是：" + dt1.Rows[i]["INVOICENO_VCHR"].ToString();
                    }

                    if (MessageBox.Show("该张发票为分发票打印, 发票数共" + dt1.Rows.Count.ToString() + "张, 明细如下: " + invoinfo + "\r\n\r\n是否继续办理退票？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        this.m_objViewer.cmdReturn.Enabled = false;
                        this.m_objViewer.buttonXP1.Enabled = false;
                        return;
                    }
                }
            }

            //发票未审核,不能退票
            DataTable dt;
            m_objManage.m_mthGetInvoiceAuditingInfo(m_objViewer.txtInvoice.Text.Trim(), out dt, 1);
            if (dt.Rows.Count > 0)
            {
                this.m_objViewer.lbeAuding.Text = "审核人:" + dt.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
            }
            else
            {
                this.m_objViewer.lbeAuding.Text = "未审核";
            }
            m_mthShowInfoByInvoiceNO(m_objViewer.txtInvoice.Text.ToString().Trim());
            this.m_strCreatInvoEmpID = string.Empty;
            long lngRes = this.m_objManage.m_mthFindInvoiceByInvoNo(m_objViewer.txtInvoice.Text.ToString().Trim(), out this.m_strCreatInvoEmpID);
        }
        #endregion

        #region 清空
        public void m_EmptyInput()
        {
            this.m_objViewer.txtCardID.Clear();
            this.m_objViewer.txtInvoice.Text = "";
            this.m_objViewer.m_repInvoiceInfo.ReportSource = null;
            this.m_objViewer.m_lstItemsInfo.Items.Clear();
            this.m_objViewer.txtCardID.Focus();
            this.m_objViewer.lbeAuding.Text = "";
        }
        #endregion
        #region 根据卡号查出发票号
        public void m_mthFindInvoiceByCardID()
        {
            if (this.m_objViewer.txtCardID.Text.Trim() == "")
            {
                return;
            }
            DataTable dt;
            long lngRet = m_objManage.m_mthFindInvoiceByCardID(m_objViewer.txtCardID.Text.Trim(), out dt, 1, this.m_objViewer.cmbFind.SelectedIndex);
            this.m_objViewer.listView1.Items.Clear();
            if (lngRet > 0 && dt.Rows.Count > 0)
            {

                if (dt.Rows.Count == 1)
                {
                    this.m_objViewer.txtInvoice.Text = dt.Rows[0]["SEQID_CHR"].ToString().Trim();
                    this.m_objViewer.txtInvoice.Focus();
                    //在这里加入调用发票号的代码
                }
                else
                {
                    ListViewItem lv;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lv = new ListViewItem(dt.Rows[i]["INVOICENO_VCHR"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["SEQID_CHR"].ToString().Trim());
                        if (dt.Rows[i]["repprninvono_vchr"] == DBNull.Value)
                            lv.SubItems.Add("");
                        else
                            lv.SubItems.Add(dt.Rows[i]["repprninvono_vchr"].ToString().Trim());
                        this.m_objViewer.listView1.Items.Add(lv);

                    }
                    this.m_objViewer.listView1.Show();
                    this.m_objViewer.listView1.BringToFront();
                    this.m_objViewer.listView1.Items[0].Selected = true;
                    this.m_objViewer.listView1.Focus();

                }
            }

        }
        #endregion
        #region 根据发票号显示信息
        private clsPatientChargeCal objPC;
        private void m_mthShowInfoByInvoiceNO(string strInvoiceNO)
        {
            clsCalcPatientCharge objCalcPatienCharge = null;
            objCalcPatienCharge = new clsCalcPatientCharge("", "", 1, this.m_objComInfo.m_strGetHospitalTitle(), 0, 100);

            int setValue = clsPublic.m_intGetSysParm("0320");
            //显示发票明细信息
            objCalcPatienCharge.m_mthGetChargeItemByInvoiceID(strInvoiceNO, m_objViewer.m_lstItemsInfo, "1");
            if (setValue == 0)
            {

                //显示发票信息			
                m_objViewer.m_repInvoiceInfo.ReportSource = objCalcPatienCharge.m_mthPrintChargePreview(strInvoiceNO, "1", out objPC);
                if (objPC.Reprintprninfo.Trim() != "")
                    objPC.Reprintprninfo = "*REPEAT(" + objPC.Reprintprninfo + ")*";
                m_objViewer.dwInvoice.Visible = false;
            }
            else
            {
                objCalcPatienCharge.m_mthPrintChargePreview(strInvoiceNO, "1", out objPC);

                //com.digitalwave.iCare.middletier.HIS.clsCalPatientChargeSvc domain =
                //    (clsCalPatientChargeSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsCalPatientChargeSvc));

                DataTable chargeType = null;
                DataTable computation = null;
                if (objPC.Reprintprninfo.Trim() == "")
                    m_objManage.m_lngChargeItemTypeByInvoice(objPC.m_strInvoiceNO, out chargeType);
                else
                    m_objManage.m_lngChargeItemTypeByInvoice(objPC.Reprintprninfo, out chargeType);
                if (objPC.Reprintprninfo.Trim() != "")
                    objPC.Reprintprninfo = "*REPEAT(" + objPC.Reprintprninfo + ")*";
                m_objManage.m_lngComputationByScope("8", out computation);
                //domain.Dispose();
                //domain = null;

                m_objViewer.dwInvoice.LibraryList = Application.StartupPath + "\\pb_Invioce.pbl";
                m_objViewer.dwInvoice.DataWindowObject = "d_op_invoice_prt_new_diff";
                m_objViewer.dwInvoice.SetRedrawOff();
                m_objViewer.dwInvoice.Reset();
                m_objViewer.dwInvoice.InsertRow(0);


                List<String> arryText = clsNewInvoicPrint.s_arryGetInvoiceInfo(objPC, objCalcPatienCharge.ObjMain.m_mthCreatDataTable(objPC), chargeType, computation, -1);
                foreach (String text in arryText)
                {
                    m_objViewer.dwInvoice.Modify(text);
                }

                m_objViewer.dwInvoice.Visible = true;
            }
        }
        #endregion
        #region 是否打印发票
        private bool IsPrintInvoice = false;
        public void m_mthIsPrintInvoice()
        {
            clsDcl_OPCharge objTemp = new clsDcl_OPCharge();
            IsPrintInvoice = objTemp.m_mthIsCanDo("0006") == 1;
        }
        #endregion
        #region 审核
        public void m_mthAudingInvoice()
        {
            //验证发票是否存在
            clsT_opr_outpatientrecipeinv_VO objResult = null;
            long lngRet = m_objManage.m_lngGetInfoByNoForReturn(m_objViewer.txtInvoice.Text.Trim(), out objResult);
            if (objResult == null || objResult.m_intSTATUS_INT != 1)
            {
                //发票不是有效的发票，退票失败！
                MessageBox.Show(m_objViewer, "此发票不是有效的发票!", "错误提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (!string.IsNullOrEmpty(this.m_strCreatInvoEmpID) && m_strCreatInvoEmpID.Trim().CompareTo(this.m_objViewer.LoginInfo.m_strEmpID) !=0)
            //{
            //    switch (this.m_strOperateLevel)
            //    {
            //        case "0":
            //            break;
            //        case "1":
            //           if( MessageBox.Show("发票不属于当前登录用户所开，是否确认审核?","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) !=DialogResult.Yes)
            //            {
            //                return;
            //            }
            //            break;
            //        case "2":
            //            MessageBox.Show("发票不属于当前登录用户所开，不能审核当前发票", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            return;
            //            //break;
            //        default:
            //            break;
            //    }
            //}

            frmAudingInvoice frmObj = new frmAudingInvoice(m_objViewer.txtInvoice.Text.Trim(), "1");
            frmObj.DataServer = this.m_objManage;
            frmObj.m_blnUseByInvoReturn = true;
            frmObj.m_strInvoCreatorID = m_strCreatInvoEmpID;
            frmObj.m_strLimitLevel = this.m_strOperateLevel;
            if (frmObj.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.lbeAuding.Text = "审核人:" + frmObj.AudingName;
            }
        }
        #endregion
    }
}
