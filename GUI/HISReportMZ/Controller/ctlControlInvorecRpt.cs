using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 门诊业务收入收据业务层
    /// baojian.mo add in 2008.02.28
    /// </summary>
    public class ctlControlInvorecRpt : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public ctlControlInvorecRpt()
        {

        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInvorecReoport)frmMDI_Child_Base_in;
        }
        #endregion

        private frmInvorecReoport m_objViewer = null;

        private clsDomainControl_Register objDomain = new clsDomainControl_Register();
        /// <summary>
        /// 0-未审核 1-已审核
        /// </summary>
        public int intISConfirm = 0;

        #region 初始化报表
        /// <summary>
        /// 初始化报表
        /// </summary>
        /// <param name="dw"></param>
        public void m_mthInitRpt(Sybase.DataWindow.DataWindowControl dw)
        {
            dw.LibraryList = System.Windows.Forms.Application.StartupPath + "\\PB_OP.pbl";
            dw.DataWindowObject = "d_op_invoicereceipt";
            dw.InsertRow(0);
            string strDate = DateTime.Today.ToString("yyyy-MM-dd");
            this.m_objViewer.m_dwShow.Modify("t_yy.text = '" + strDate.Substring(0, 4) + "'");
            this.m_objViewer.m_dwShow.Modify("t_mm.text = '" + strDate.Substring(5, 2) + "'");
            this.m_objViewer.m_dwShow.Modify("t_dd.text = '" + strDate.Substring(8, 2) + "'");
            this.m_objViewer.m_dwShow.Modify("t_cn.text = '" + this.m_objViewer.LoginInfo.m_strEmpName + "'");
        }
        #endregion

        #region 填充下拉框
        /// <summary>
        /// 填充下拉框
        /// </summary>
        public void m_mthFillBox()
        {
            DataTable dtEmp = null;
            long lngRes = this.objDomain.m_lngGetAllCheckMan(out dtEmp);
            if (lngRes > 0)
            {
                this.m_objViewer.ctfEmpNo.m_GetDataTable = dtEmp;
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "获取收费员列表失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthQuery()
        {
            if (this.m_objViewer.ctfEmpNo.Tag == null || this.m_objViewer.ctfEmpNo.Tag.ToString() == "")
            {
                MessageBox.Show(this.m_objViewer, "请先选择一个收费员...", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.ctfEmpNo.Focus();
                return;
            }
            string strDateForm = this.m_objViewer.dtpStart.Value.ToString("yyyy-MM-dd 00:00:00");
            string strDateTo = this.m_objViewer.dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59");
            string strEmpNo = this.m_objViewer.ctfEmpNo.Tag.ToString();
            com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[] objReceiptVoArr = null;
            if (this.m_objViewer.rdbyes.Checked)//已审核
            {
                this.objDomain.m_lngGetInvoRecData(intISConfirm, strDateForm, strDateTo, this.m_objViewer.LoginInfo.m_strEmpID, out objReceiptVoArr);
            }
            else//未审核
            {
                this.objDomain.m_lngGetInvoRecData(intISConfirm, strDateForm, strDateTo, strEmpNo, out objReceiptVoArr);
                objReceiptVoArr = this.m_objContructData(objReceiptVoArr);
            }
            this.m_mthFillGrid(intISConfirm, objReceiptVoArr);
        }

        /// <summary>
        /// 处理未审核结果
        /// </summary>
        /// <param name="objReceiptVoArr"></param>
        /// <returns></returns>
        private com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[] m_objContructData(com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[] objReceiptVoArr)
        {
            com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objRecVo = null;
            System.Collections.ArrayList arrRes = new System.Collections.ArrayList();
            string strInvleft = "";
            string strInvright = "";
            if (objReceiptVoArr != null)
            {
                for (int i1 = 0; i1 < objReceiptVoArr.Length; i1++)
                {
                    if (i1 == 0)
                    {
                        objRecVo = new com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO();
                        objRecVo.strCollectDate = objReceiptVoArr[i1].strCollectDate;
                        objRecVo.decReceiptSum += objReceiptVoArr[i1].decReceiptSum;
                        objRecVo.arrInvoice.Add(objReceiptVoArr[i1].strReceiptNo);
                        strInvleft = objReceiptVoArr[i1].strReceiptNo;
                    }
                    else
                    {
                        if (objReceiptVoArr[i1].strCollectDate == objRecVo.strCollectDate)
                        {
                            objRecVo.decReceiptSum += objReceiptVoArr[i1].decReceiptSum;
                            if (objRecVo.arrInvoice.IndexOf(objReceiptVoArr[i1].strReceiptNo) < 0)
                            {
                                objRecVo.arrInvoice.Add(objReceiptVoArr[i1].strReceiptNo);
                                strInvright = objReceiptVoArr[i1 - 1].strReceiptNo;
                            }
                        }
                        else
                        {
                            objRecVo.strReceiptInvoNO = strInvleft + "-" + strInvright;
                            arrRes.Add(objRecVo);//添加一条最终结果

                            objRecVo = new com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO();
                            objRecVo.strCollectDate = objReceiptVoArr[i1].strCollectDate;
                            objRecVo.decReceiptSum += objReceiptVoArr[i1].decReceiptSum;
                            objRecVo.arrInvoice.Add(objReceiptVoArr[i1].strReceiptNo);
                            strInvleft = objReceiptVoArr[i1].strReceiptNo;
                        }
                    }
                }
                if (objRecVo != null)//添加最后一条结果
                {
                    objRecVo.strReceiptInvoNO = strInvleft + "-" + strInvright;
                    arrRes.Add(objRecVo);
                }
            }
            objReceiptVoArr = (com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[])arrRes.ToArray(typeof(com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO));
            return objReceiptVoArr;
        }
        #endregion

        #region 填充DataGridView
        /// <summary>
        /// 填充DataGridView
        /// </summary>
        /// <param name="intFlag"></param>
        /// <param name="objInvoArr"></param>
        public void m_mthFillGrid(int intFlag, com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO[] objInvoArr)
        {
            this.m_objViewer.tabControl1.SelectedIndex = intFlag;
            string[] sarr = null;
            if (intFlag == 0)
            {
                this.m_objViewer.m_dgnotConfirm.Rows.Clear();
                if (objInvoArr != null)
                {
                    for (int i1 = 0; i1 < objInvoArr.Length; i1++)
                    {
                        sarr = new string[2];
                        sarr[0] = "F";
                        sarr[1] = objInvoArr[i1].strCollectDate;
                        int n = this.m_objViewer.m_dgnotConfirm.Rows.Add(sarr);
                        this.m_objViewer.m_dgnotConfirm.Rows[n].Tag = objInvoArr[i1];
                    }
                }
            }
            else
            {
                this.m_objViewer.m_dgvConfirm.Rows.Clear();
                if (objInvoArr != null)
                {
                    for (int i2 = 0; i2 < objInvoArr.Length; i2++)
                    {
                        sarr = new string[1];
                        sarr[0] = objInvoArr[i2].strOperDate;
                        int n = this.m_objViewer.m_dgvConfirm.Rows.Add(sarr);
                        this.m_objViewer.m_dgvConfirm.Rows[n].Tag = objInvoArr[i2];
                    }
                }
            }
            return;
        }
        #endregion

        #region 变更报表数据
        /// <summary>
        /// 变更报表数据
        /// </summary>
        /// <param name="Flag"></param>
        public void m_mthUpdateRpt(int Flag)
        {
            if (Flag == 0)
            {
                decimal decTotalMny = 0;
                com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo = null;
                DataTable dtRec = new DataTable();//发票表
                DataRow dr = null;
                dtRec.Columns.Add("invoiceno_vchr", typeof(System.String));
                for (int i1 = 0; i1 < this.m_objViewer.m_dgnotConfirm.Rows.Count; i1++)
                {
                    if (this.m_objViewer.m_dgnotConfirm.Rows[i1].Cells[0].Value.ToString() == "T")
                    {
                        if (this.m_objViewer.m_dgnotConfirm.Rows[i1].Tag != null)
                        {
                            objReceiptVo = (com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO)this.m_objViewer.m_dgnotConfirm.Rows[i1].Tag;
                            decTotalMny += objReceiptVo.decReceiptSum;
                            //构建发票表
                            for (int i2 = 0; i2 < objReceiptVo.arrInvoice.Count; i2++)
                            {
                                dr = dtRec.NewRow();
                                dr["invoiceno_vchr"] = objReceiptVo.arrInvoice[i2];
                                dtRec.Rows.Add(dr);
                            }
                        }
                    }
                }
                decimal decw = Math.Truncate(decTotalMny / 10000);
                decimal decq = Math.Truncate((decTotalMny - decw * 10000) / 1000);
                decimal decb = Math.Truncate((decTotalMny - decw * 10000 - decq * 1000) / 100);
                decimal decs = Math.Truncate((decTotalMny - decw * 10000 - decq * 1000 - decb * 100) / 10);
                decimal decy = Math.Truncate((decTotalMny - decw * 10000 - decq * 1000 - decb * 100 - decs * 10));
                decimal decj = Math.Truncate((decTotalMny - Math.Truncate(decTotalMny)) * 10);
                decimal decf = Math.Truncate((decTotalMny - Math.Truncate(decTotalMny)) * 100 - decj * 10);
                string s = com.digitalwave.iCare.gui.HIS.clsMain.CurrencyToString(float.Parse(decTotalMny.ToString("F2")));
                this.m_objViewer.m_dwShow.SetRedrawOff();
                this.m_objViewer.m_dwShow.SetItemString(1, "col1", "");
                this.m_objViewer.m_dwShow.SetItemString(1, "col2", this.m_objViewer.ctfEmpNo.txtValuse);
                this.m_objViewer.m_dwShow.SetItemString(1, "col3", DateTime.Today.ToString("MM"));
                this.m_objViewer.m_dwShow.SetItemString(1, "col4", DateTime.Today.ToString("dd"));
                this.m_objViewer.m_dwShow.Modify("t_18.text = '" + decw.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_19.text = '" + decq.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_20.text = '" + decb.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_21.text = '" + decs.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_22.text = '" + decy.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_23.text = '" + decj.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_24.text = '" + decf.ToString() + "'");
                this.m_objViewer.m_dwShow.Modify("t_total.text = '" + decTotalMny.ToString("F2") + "'");
                this.m_objViewer.m_dwShow.Modify("t_dx.text = '" + s + "'");
                //填充单据号码
                string strAllRec = "";
                if (dtRec.Rows.Count > 0)
                {
                    DataView dv = new DataView(dtRec);
                    dv.Sort = "invoiceno_vchr asc";
                    DataTable dtSortRec = dv.ToTable();
                    dtRec = null;
                    System.Collections.ArrayList arrList = new System.Collections.ArrayList();
                    com.digitalwave.iCare.gui.HIS.clsMain.m_Detach(dtSortRec, "invoiceno_vchr", out arrList);
                    if (arrList.Count > 0)
                    {
                        strAllRec += arrList[0];
                        for (int i3 = 1; i3 < arrList.Count; i3++)
                        {
                            if (arrList[i3].ToString() == ",")
                            {
                                strAllRec += arrList[i3].ToString();
                                continue;
                            }
                            if (strAllRec.Substring(strAllRec.Length - 1, 1) == ",")
                            {
                                strAllRec += arrList[i3].ToString();
                            }
                            else if (strAllRec.Substring(strAllRec.Length - 1, 1) != "-")
                            {
                                strAllRec += "-";
                                if (i3 == arrList.Count - 1)
                                {
                                    strAllRec += arrList[i3].ToString();
                                }
                            }
                            else if (strAllRec.Substring(strAllRec.Length - 1, 1) == "-" && (i3 == arrList.Count - 1 || arrList[i3 + 1].ToString() == ","))
                            {
                                strAllRec += arrList[i3].ToString();
                            }
                            else
                            { }
                        }
                    }
                    if (strAllRec.Length > 200)
                    {
                        strAllRec = strAllRec.Substring(0, 200);
                    }
                }
                this.m_objViewer.m_dwShow.Modify("t_invorec.text = '" + strAllRec + "'");
                this.m_objViewer.m_dwShow.CalculateGroups();
                this.m_objViewer.m_dwShow.SetRedrawOn();
                this.m_objViewer.m_dwShow.Refresh();
                this.m_objViewer.m_dwShow.Tag = null;
            }
            else
            {
                if (this.m_objViewer.m_dgvConfirm.SelectedCells.Count > 0)
                {
                    DataGridViewRow dgvRow = this.m_objViewer.m_dgvConfirm.Rows[this.m_objViewer.m_dgvConfirm.SelectedCells[0].RowIndex];
                    if (dgvRow.Tag != null)
                    {
                        com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objInvoRecVo = (com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO)dgvRow.Tag;
                        decimal decTotalMny = Convert.ToDecimal(objInvoRecVo.decReceiptSum);
                        decimal decw = Math.Truncate(decTotalMny / 10000);
                        decimal decq = Math.Truncate((decTotalMny - decw * 10000) / 1000);
                        decimal decb = Math.Truncate((decTotalMny - decw * 10000 - decq * 1000) / 100);
                        decimal decs = Math.Truncate((decTotalMny - decw * 10000 - decq * 1000 - decb * 100) / 10);
                        decimal decy = Math.Truncate((decTotalMny - decw * 10000 - decq * 1000 - decb * 100 - decs * 10));
                        decimal decj = Math.Truncate((decTotalMny - Math.Truncate(decTotalMny)) * 10);
                        decimal decf = Math.Truncate((decTotalMny - Math.Truncate(decTotalMny)) * 100 - decj * 10);
                        string s = com.digitalwave.iCare.gui.HIS.clsMain.CurrencyToString(float.Parse(decTotalMny.ToString("F2")));

                        this.m_objViewer.m_dwShow.Reset();
                        this.m_objViewer.m_dwShow.SetRedrawOff();
                        int NewRow = this.m_objViewer.m_dwShow.InsertRow(0);
                        this.m_objViewer.m_dwShow.SetItemString(NewRow, "col1", objInvoRecVo.strReceiptNo);
                        this.m_objViewer.m_dwShow.SetItemString(NewRow, "col2", objInvoRecVo.strCollecterName);
                        try
                        {
                            this.m_objViewer.m_dwShow.SetItemString(NewRow, "col3", Convert.ToDateTime(objInvoRecVo.strCollectDate).ToString("MM"));
                        }
                        catch (Exception)
                        {
                            int pos1 = objInvoRecVo.strCollectDate.IndexOf('-') + 1;
                            int pos2 = objInvoRecVo.strCollectDate.IndexOf("月");
                            string strD = objInvoRecVo.strCollectDate.Substring(pos1, pos2 - pos1);
                            this.m_objViewer.m_dwShow.SetItemString(NewRow, "col3", strD);
                        }
                        try
                        {
                            this.m_objViewer.m_dwShow.SetItemString(NewRow, "col4", Convert.ToDateTime(objInvoRecVo.strCollectDate).ToString("dd"));
                        }
                        catch (Exception)
                        {
                            int pos3 = objInvoRecVo.strCollectDate.IndexOf('-');
                            string strD1 = objInvoRecVo.strCollectDate.Substring(0, pos3);
                            this.m_objViewer.m_dwShow.SetItemString(NewRow, "col4", strD1);
                        }
                        this.m_objViewer.m_dwShow.Modify("t_18.text = '" + decw.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_19.text = '" + decq.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_20.text = '" + decb.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_21.text = '" + decs.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_22.text = '" + decy.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_23.text = '" + decj.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_24.text = '" + decf.ToString() + "'");
                        this.m_objViewer.m_dwShow.Modify("t_invorec.text = '" + objInvoRecVo.strReceiptInvoNO + "'");
                        this.m_objViewer.m_dwShow.Modify("t_total.text = '" + decTotalMny.ToString("F2") + "'");
                        this.m_objViewer.m_dwShow.Modify("t_dx.text = '" + s + "'");
                        this.m_objViewer.m_dwShow.Modify("t_cn.text = '" + objInvoRecVo.strOperName + "'");
                        this.m_objViewer.m_dwShow.CalculateGroups();
                        this.m_objViewer.m_dwShow.SetRedrawOn();
                        this.m_objViewer.m_dwShow.Refresh();
                        this.m_objViewer.btnSave.Tag = objInvoRecVo.strReceiptNo;
                    }
                }
            }
        }
        #endregion

        #region 审核收据
        /// <summary>
        /// 审核收据
        /// </summary>
        public void m_mthConfirmRec()
        {
            System.Collections.ArrayList arrConDate = new System.Collections.ArrayList();
            System.Collections.ArrayList arrRemoveRowNO = new System.Collections.ArrayList();
            com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo = null;
            for (int i1 = 0; i1 < this.m_objViewer.m_dgnotConfirm.Rows.Count; i1++)
            {
                if (this.m_objViewer.m_dgnotConfirm.Rows[i1].Cells[0].Value.ToString() == "T")
                {
                    if (this.m_objViewer.m_dgnotConfirm.Rows[i1].Tag != null)
                    {
                        arrRemoveRowNO.Add(i1);
                        objReceiptVo = (com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO)this.m_objViewer.m_dgnotConfirm.Rows[i1].Tag;
                        arrConDate.Add(objReceiptVo.strCollectDate);
                    }
                }
            }
            if (arrConDate.Count > 0)
            {
                try
                {
                    if (this.m_objViewer.m_dwShow.RowCount == 0)
                    {
                        return;
                    }
                    int CurrRow = this.m_objViewer.m_dwShow.CurrentRow;
                    this.m_objViewer.m_dwShow.AcceptText();
                    #region 生成数据

                    objReceiptVo = new com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO();
                    if (!this.m_mthGenerateVO(CurrRow, ref objReceiptVo))
                        return;
                    
                    #endregion
                }
                catch (Exception)
                {
                    MessageBox.Show(this.m_objViewer, "即将审核的内容不完整，请补充完整再审核！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (objReceiptVo.strReceiptNo.Trim() == "")
                {
                    //MessageBox.Show(this.m_objViewer, "请输入收据号码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                long lngRes = objDomain.m_lngConfirmRecord(arrConDate, objReceiptVo);
                if (lngRes > 0)
                {
                    int intRowNO = 0;
                    this.m_mthUpdateDataGrid(arrRemoveRowNO, objReceiptVo, ref intRowNO);
                    this.m_objViewer.tabControl1.SelectedIndex = 1;
                    this.m_objViewer.m_dgvConfirm.Rows[intRowNO].Cells[0].Selected = true;
                    this.m_objViewer.btnSave.Tag = objReceiptVo.strReceiptNo;
                }
                else if (lngRes == -2)
                {
                    MessageBox.Show(this.m_objViewer, "已有数据号，请重新输入一个新的收据号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "未选中任何未审核记录", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 刷新DataGrid
        /// </summary>
        /// <param name="arrDelRow"></param>
        /// <param name="objReceiptVo"></param>
        private void m_mthUpdateDataGrid(System.Collections.ArrayList arrDelRow, com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo, ref int NewRowNO)
        {
            int DelRow = 0;
            for (int i1 = 0; i1 < arrDelRow.Count; i1++)
            {
                DelRow = int.Parse(arrDelRow[arrDelRow.Count - i1 - 1].ToString());
                this.m_objViewer.m_dgnotConfirm.Rows.RemoveAt(DelRow);
            }
            if (objReceiptVo != null)
            {
                string[] sarr = new string[1];
                sarr[0] = objReceiptVo.strOperDate;
                int n = this.m_objViewer.m_dgvConfirm.Rows.Add(sarr);
                this.m_objViewer.m_dgvConfirm.Rows[n].Tag = objReceiptVo;
                NewRowNO = n;
            }
        }
        #endregion

        #region 修改收据
        /// <summary>
        /// 修改收据
        /// </summary>
        public void m_mthModifyReceive()
        {
            if (this.m_objViewer.m_dwShow.RowCount == 0 || this.m_objViewer.btnSave.Tag == null)
            {
                return;
            }
            this.m_objViewer.m_dwShow.AcceptText();
            int CurrRow = this.m_objViewer.m_dwShow.CurrentRow;
            com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo = new com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO();
            if (!this.m_mthGenerateVO(CurrRow, ref objReceiptVo))
                return;
            if (this.m_objViewer.btnSave.Tag != null)
            {
                long lngRes = this.objDomain.m_lngModifyRecord(this.m_objViewer.btnSave.Tag.ToString(), objReceiptVo);
                if (lngRes == 2)
                {
                    MessageBox.Show(this.m_objViewer, "保存失败，收据号已存在！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (lngRes > 0)
                {
                    MessageBox.Show(this.m_objViewer, "保存成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.m_dgvConfirm.Rows[this.m_objViewer.m_dgvConfirm.SelectedCells[0].RowIndex].Tag = objReceiptVo;
                    this.m_objViewer.btnSave.Tag = objReceiptVo.strReceiptNo;
                }
                else
                {
                    MessageBox.Show(this.m_objViewer, "保存失败，请与系统管理员联系", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// 生成收据信息
        /// </summary>
        /// <param name="CurrRow"></param>
        /// <param name="objReceiptVo"></param>
        private bool m_mthGenerateVO(int CurrRow, ref com.digitalwave.iCare.ValueObject.clsInvoceRecBill_VO objReceiptVo)
        {
            //收据号码
            string strTemp = this.m_objViewer.m_dwShow.GetItemString(CurrRow, "col1");
            if (strTemp.Trim() == "")
            {
                MessageBox.Show(this.m_objViewer, "请输入收据号码！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (strTemp.Length > 10)
            {
                MessageBox.Show(this.m_objViewer, "只能输入少于或等于10位的收据号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            objReceiptVo.strReceiptNo = strTemp;
            //交款人姓名
            strTemp = this.m_objViewer.m_dwShow.GetItemString(CurrRow, "col2");
            if (strTemp.Trim() == "")
            {
                MessageBox.Show(this.m_objViewer, "请输入交款人姓名！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            objReceiptVo.strCollecterName = strTemp;
            //交款日期
            string strMonth = this.m_objViewer.m_dwShow.GetItemString(CurrRow, "col3");
            if (strMonth.Trim() == "")
            {
                MessageBox.Show(this.m_objViewer, "请输入交款日期(月份)！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            string strDay = this.m_objViewer.m_dwShow.GetItemString(CurrRow, "col4");
            if (strDay.Trim() == "")
            {
                MessageBox.Show(this.m_objViewer, "请输入交款日期(日)！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            objReceiptVo.strCollectDate = DateTime.Now.ToString("yyyy") + "-" + strMonth + "-" + strDay;
            try
            {
                DateTime.Parse(objReceiptVo.strCollectDate);
            }
            catch (Exception)
            {
                MessageBox.Show(this.m_objViewer, "交款人日期格式不正确，请重新输入", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //交款人金额
            strTemp = this.m_objViewer.m_dwShow.Describe("t_total.text");
            if (strTemp.Trim() == "")
            {
                MessageBox.Show(this.m_objViewer, "交款人金额不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            objReceiptVo.decReceiptSum = Convert.ToDecimal(strTemp);
            //单据号码
            strTemp = this.m_objViewer.m_dwShow.Describe("t_invorec.text");
            if (strTemp.Trim() == "")
            {
                MessageBox.Show(this.m_objViewer, "单据号码不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            objReceiptVo.strReceiptInvoNO = strTemp;
            //交款人ID
            objReceiptVo.strCollecterID = this.m_objViewer.ctfEmpNo.Tag.ToString();
            //操作时间
            objReceiptVo.strOperDate = DateTime.Now.ToString();
            //操作员ID
            objReceiptVo.strOperID = this.m_objViewer.LoginInfo.m_strEmpID;
            //操作员姓名
            objReceiptVo.strOperName = this.m_objViewer.LoginInfo.m_strEmpName;
            return true;
        }
        #endregion
    }
}
