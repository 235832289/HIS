using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 呆帐结算逻辑控制类
    /// </summary>
    public class clsCtl_BadCharge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_BadCharge()
        {
            objSvc = new clsDcl_Charge();
        }
        #endregion

        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Charge objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmBadCharge m_objViewer;
        /// <summary>
        /// 费用源
        /// </summary>
        private DataTable dtSource = new DataTable();
        /// <summary>
        /// 是否已计算分摊
        /// </summary>
        private bool IsCompute = false;
        /// <summary>
        /// 差值项科室ID
        /// </summary>
        private string DiffValDeptID = "";
        /// <summary>
        /// 差值项核算分类ID
        /// </summary>
        private string DiffValCatID = "";
        /// <summary>
        /// 母婴合并结算开关,0为关,1为开
        /// </summary>
        private int intBabyParm = 0;
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBadCharge)frmMDI_Child_Base_in;
        }
        #endregion

        #region 快捷
        /// <summary>
        /// 快捷
        /// </summary>
        /// <param name="key"></param>
        public void m_mthShortCut(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.F3:
                    this.m_mthFind();
                    break;
                case Keys.F8:
                    this.m_mthCharge();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            frmCommonFind f = new frmCommonFind("查找出院病人资料", this.m_objViewer.ucPatientInfo.Status);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthFind(f.RegisterID, 3);
                if (this.m_objViewer.ucPatientInfo.IsChanged)
                {
                    this.m_blnChargePatch();
                    if (this.m_objViewer.cboDeptClass.SelectedIndex == 0)
                    {
                        this.m_mthShowFeeCat(this.m_objViewer.ucPatientInfo.RegisterID, 1);
                    }
                    else
                    {
                        this.m_objViewer.cboDeptClass.SelectedIndex = 0;
                    }
                }
            }
        }
        #endregion

        #region 补收连续性费用
        /// <summary>
        /// 补收连续性费用
        /// </summary>
        /// <returns>true 成功 false 失败</returns>
        public bool m_blnChargePatch()
        {
            bool ret = true;

            try
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                ret = clsPublic.m_blnChargeContinueItem(this.m_objViewer.ucPatientInfo.RegisterID, this.m_objViewer.LoginInfo.m_strEmpID);
            }
            finally
            {
                this.m_objViewer.Cursor = Cursors.Default;
            }

            return ret;
        }
        #endregion

        #region 显示分类费用
        /// <summary>
        /// 显示分类费用
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="DeptClass">1 开单科室 2 执行科室 3 所在病区</param>
        public void m_mthShowFeeCat(string RegID, int DeptClass)
        {
            DataTable dt = this.objSvc.GetPatientCheckFee(RegID);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ischeckfee"].ToString() == "1")
            { }
            else
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("病区还未对病人费用进行最终核对，不能进行结算。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.m_objViewer.btnCompute.Enabled = true;
            this.m_objViewer.btnCharge.Enabled = true;

            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.PrepayMoney >= (this.m_objViewer.ucPatientInfo.BihPatient_VO.WaitChargeFee + this.m_objViewer.ucPatientInfo.BihPatient_VO.WaitClearFee))
            {
                MessageBox.Show("该病人的预交金大于总费用金额，请使用正常出院结算！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int FeeStatus = this.m_objViewer.ucPatientInfo.BihPatient_VO.FeeStatus;
            if (FeeStatus == 4)
            {
                this.m_objViewer.btnCompute.Enabled = false;
                this.m_objViewer.btnCharge.Enabled = false;
            }
            else if (FeeStatus == 3)
            {
                this.m_objViewer.lblPrepayMoney.Text = "【非呆帐病人】";
                this.m_objViewer.dtgDetail.Rows.Clear();
                return;
            }

            this.m_objViewer.Cursor = Cursors.WaitCursor;
            this.m_objViewer.dtgDetail.Rows.Clear();

            int Status = (FeeStatus == 4 ? 1 : 0);
            if (Status == 1)
            {
                this.m_objViewer.lblPrepayMoney.Text = "【呆帐结算】";
            }
            else
            {
                this.m_objViewer.lblPrepayMoney.Text = this.m_objViewer.ucPatientInfo.BihPatient_VO.PrepayMoney.ToString("0.00");
            }

            dtSource = null;
            //母婴合并结算参数开关判断 
            intBabyParm = clsPublic.m_intGetSysParm("1119");
            long lngRes;
            if (intBabyParm == 1)
            {
                //母婴费用一起拿
                lngRes = this.objSvc.m_lngGetFeeCatByDeptClassForMortherBaby(RegID, DeptClass, Status, out dtSource);

            }
            else
            {
                //只拿母亲费用

                lngRes = this.objSvc.m_lngGetFeeCatByDeptClass(RegID, DeptClass, Status, out dtSource);
            }
            if (lngRes > 0)
            {
                decimal decTotalmny = 0;
                decimal decComputemny = 0;
                int intDelRow = 0;
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    DataRow dr = dtSource.Rows[i];
                    //判断是否有婴儿费用一起拿出来，中间件里用空出一行来区分
                    if (dr["catsum"].ToString() == "")
                    {
                        //插入一行字表示以下为婴儿费用
                        this.m_mthInsertBlankRow(decTotalmny, decComputemny);
                        intDelRow = m_intInsertBabyRow();
                        continue;
                    }
                    decimal d = Convert.ToDecimal(dr["catsum"].ToString());

                    string[] sarr = new string[7];

                    sarr[0] = Convert.ToString(i + 1);
                    if (i > 0)
                    {
                        if (dtSource.Rows[i]["deptname_vchr"].ToString().Trim() == dtSource.Rows[i - 1]["deptname_vchr"].ToString().Trim())
                        {
                            decTotalmny += d;
                            if (Status == 1)
                            {
                                decComputemny += d;
                            }

                            sarr[1] = "";
                        }
                        else
                        {
                            this.m_mthInsertBlankRow(decTotalmny, decComputemny);
                            decTotalmny = 0;
                            decComputemny = 0;

                            decTotalmny += d;
                            if (Status == 1)
                            {
                                decComputemny += d;
                            }

                            sarr[1] = dr["deptname_vchr"].ToString().Trim();
                        }
                    }
                    else
                    {
                        decTotalmny += d;
                        if (Status == 1)
                        {
                            decComputemny += d;
                        }
                        sarr[1] = dr["deptname_vchr"].ToString().Trim();
                    }
                    sarr[2] = dr["calccateid_chr"].ToString().Trim();
                    sarr[3] = dr["typename_vchr"].ToString().Trim();
                    sarr[4] = d.ToString("###,##0.00");
                    if (Status == 1)
                    {
                        sarr[5] = d.ToString("###,##0.00");
                    }
                    else
                    {
                        sarr[5] = "";
                    }
                    sarr[6] = dr["deptid"].ToString();

                    int row = this.m_objViewer.dtgDetail.Rows.Add(sarr);
                    this.m_objViewer.dtgDetail.Rows[row].Tag = dr;

                    if (sarr[1].ToString().Trim() != "")
                    {
                        this.m_objViewer.dtgDetail.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }
                }

                this.m_mthInsertBlankRow(decTotalmny, decComputemny);
                if (intDelRow > 0)
                {
                    this.m_objViewer.dtgDetail.Rows.RemoveAt(intDelRow + 1);
                }
            }

            this.m_objViewer.Cursor = Cursors.Default;

            IsCompute = false;
        }
        #endregion

        #region 插空行
        /// <summary>
        /// 插空行
        /// </summary>
        private void m_mthInsertBlankRow(decimal p_totalmny, decimal p_computemny)
        {
            string[] sarr = new string[7];
            sarr[3] = "科室小计:";
            sarr[4] = p_totalmny.ToString("###,##0.00");
            if (p_computemny == 0)
            {
                sarr[5] = "";
            }
            else
            {
                sarr[5] = p_computemny.ToString("###,##0.00");
            }

            int row = this.m_objViewer.dtgDetail.Rows.Add(sarr);
            this.m_objViewer.dtgDetail.Rows[row].Cells["colhjje"].Style.ForeColor = Color.Blue;
            this.m_objViewer.dtgDetail.Rows[row].Cells["colftje"].Style.ForeColor = Color.Blue;
        }

        /// <summary>
        /// 插入空行提示婴儿费用
        /// </summary>
        /// <returns></returns>
        private int m_intInsertBabyRow()
        {
            string[] sarr = new string[7];
            sarr[1] = "婴儿费用";
            sarr[2] = "--------";
            sarr[3] = "--------";



            int intRow = this.m_objViewer.dtgDetail.Rows.Add(sarr);
            //this.m_objViewer.dtgDetail.Rows[intRow].Tag = p_strDeptID;
            this.m_objViewer.dtgDetail.Rows[intRow].DefaultCellStyle.BackColor = SystemColors.Control;
            return intRow;

        }
        #endregion

        #region 分摊计算
        /// <summary>
        /// 分摊计算
        /// </summary>
        public bool m_mthCompute()
        {
            if (this.m_objViewer.ucPatientInfo.RegisterID.Trim() == "" || this.m_objViewer.dtgDetail.Rows.Count == 0)
            {
                return false;
            }

            decimal decPrepayMny = this.m_objViewer.ucPatientInfo.BihPatient_VO.PrepayMoney;
            decimal decDeptMny = this.m_objViewer.ucPatientInfo.BihPatient_VO.WaitChargeFee + this.m_objViewer.ucPatientInfo.BihPatient_VO.WaitClearFee;

            if (decPrepayMny == 0)
            {
                MessageBox.Show("预交金为0，不能进行费用分摊。", "系统提示", MessageBoxButtons.OK);
                return false;
            }

            if (decDeptMny == 0)
            {
                MessageBox.Show("没有未清的科室费用，不需要进行费用分摊。", "系统提示", MessageBoxButtons.OK);
                return false;
            }

            DiffValDeptID = "";
            DiffValCatID = "";

            int rowcount = this.m_objViewer.dtgDetail.Rows.Count;
            decimal d = 0;
            decimal decDiff = 0;
            decimal decComputemny = 0;
            decimal scale = decPrepayMny / decDeptMny;

            for (int i = 0; i < rowcount; i++)
            {
                if (this.m_objViewer.dtgDetail.Rows[i].Cells["colflmc"].Value.ToString().IndexOf("科室小计") >= 0)
                {
                    this.m_objViewer.dtgDetail.Rows[i].Cells["colftje"].Value = decComputemny.ToString("###,##0.00");
                    decComputemny = 0;
                    continue;
                }

                d = clsPublic.Round(clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgDetail.Rows[i].Cells["colhjje"].Value) * scale, 2);

                this.m_objViewer.dtgDetail.Rows[i].Cells["colftje"].Value = d.ToString("###,##0.00");

                decDiff += d;
                decComputemny += d;
            }

            if (scale < 1)
            {
                //将差值放在最后一项(分项)
                d = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgDetail.Rows[rowcount - 2].Cells["colftje"].Value) + (decPrepayMny - decDiff);
                this.m_objViewer.dtgDetail.Rows[rowcount - 2].Cells["colftje"].Value = d.ToString("###,##0.00");
                //(科室小计)
                d = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgDetail.Rows[rowcount - 1].Cells["colftje"].Value) + (decPrepayMny - decDiff);
                this.m_objViewer.dtgDetail.Rows[rowcount - 1].Cells["colftje"].Value = d.ToString("###,##0.00");


                DiffValDeptID = this.m_objViewer.dtgDetail.Rows[rowcount - 2].Cells["colksid"].Value.ToString();
                DiffValCatID = this.m_objViewer.dtgDetail.Rows[rowcount - 2].Cells["colfldm"].Value.ToString();
            }

            IsCompute = true;

            return true;
        }
        #endregion

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        public void m_mthCharge()
        {
            #region 校验
            if (this.m_objViewer.ucPatientInfo.RegisterID.Trim() == "" || this.m_objViewer.dtgDetail.Rows.Count == 0)
            {
                return;
            }

            if (this.m_objViewer.cboDeptClass.SelectedIndex != 0)
            {
                this.m_objViewer.cboDeptClass.SelectedIndex = 0;
            }

            //是否有预交金 (true 有 false 无)
            bool IsHavePrepayMoney = false;
            if (this.m_objViewer.ucPatientInfo.BihPatient_VO.PrepayMoney > 0)
            {
                IsHavePrepayMoney = true;

                if (!IsCompute)
                {
                    if (!this.m_mthCompute())
                    {
                        return;
                    }
                }
            }
            #endregion

            #region 生成结算分类VO
            //核算分类
            ArrayList ChargeCatArr = new ArrayList();
            if (IsHavePrepayMoney)
            {
                if (intBabyParm == 0)
                {
                    #region 普通模式
                    for (int i = 0; i < this.m_objViewer.dtgDetail.Rows.Count; i++)
                    {
                        if (this.m_objViewer.dtgDetail.Rows[i].Cells["colflmc"].Value.ToString().IndexOf("科室小计") >= 0)
                        {
                            continue;
                        }

                        DataRow dr = this.m_objViewer.dtgDetail.Rows[i].Tag as DataRow;

                        if (dr["typename_vchr"].ToString().Trim() == "")
                        {
                            MessageBox.Show("收费明细存在住院核算分类为空，操作终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        clsBihChargeCat_VO ChargeCat_VO = new clsBihChargeCat_VO();
                        ChargeCat_VO.DeptID = dr["deptid"].ToString();
                        ChargeCat_VO.ItemCatID = dr["calccateid_chr"].ToString();
                        ChargeCat_VO.TotalSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgDetail.Rows[i].Cells["colftje"].Value);
                        ChargeCat_VO.AcctSum = 0;

                        ChargeCatArr.Add(ChargeCat_VO);
                    }
                    #endregion
                }
                else
                {
                    #region 母婴合并结算生成结算类VO
                    int intTempRows = 0;
                    DataTable dtbMater = new DataTable();
                    DataTable dtbBaby = new DataTable();
                    dtbMater.Columns.Add("deptid");
                    dtbMater.Columns.Add("calccateid_chr");
                    dtbMater.Columns.Add("TotalSum");

                    dtbBaby.Columns.Add("deptid");
                    dtbBaby.Columns.Add("calccateid_chr");
                    dtbBaby.Columns.Add("TotalSum");

                    string[] sarr = new string[3];
                    for (int i = 0; i < this.m_objViewer.dtgDetail.Rows.Count; i++)
                    {
                        if (this.m_objViewer.dtgDetail.Rows[i].Cells["colflmc"].Value.ToString().IndexOf("科室小计") >= 0)
                        {
                            continue;
                        }
                        else if (this.m_objViewer.dtgDetail.Rows[i].Cells["colflmc"].Value.ToString().IndexOf("--------") >= 0)
                        {
                            intTempRows = i + 1;
                            break;
                        }

                        DataRow dr = this.m_objViewer.dtgDetail.Rows[i].Tag as DataRow;

                        if (dr["typename_vchr"].ToString().Trim() == "")
                        {
                            MessageBox.Show("收费明细存在住院核算分类为空，操作终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }

                        sarr[0] = dr["deptid"].ToString();
                        sarr[1] = dr["calccateid_chr"].ToString();
                        sarr[2] = this.m_objViewer.dtgDetail.Rows[i].Cells["colhjje"].Value.ToString();

                        dtbMater.Rows.Add(sarr);
                        //clsBihChargeCat_VO ChargeCat_VO = new clsBihChargeCat_VO();
                        //ChargeCat_VO.DeptID = dr["deptid"].ToString();
                        //ChargeCat_VO.ItemCatID = dr["calccateid_chr"].ToString();
                        //ChargeCat_VO.TotalSum = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgDetail.Rows[i].Cells["colhjje"].Value);
                        //ChargeCat_VO.AcctSum = 0;

                        //ChargeCatArr.Add(ChargeCat_VO);

                    }
                    //如果有婴儿费用，也分出来计算
                    if (intTempRows > 0)
                    {

                        for (int i2 = intTempRows; i2 < this.m_objViewer.dtgDetail.Rows.Count; i2++)
                        {
                            if (this.m_objViewer.dtgDetail.Rows[i2].Cells["colflmc"].Value.ToString().IndexOf("科室小计") >= 0)
                            {
                                continue;
                            }


                            DataRow dr = this.m_objViewer.dtgDetail.Rows[i2].Tag as DataRow;

                            if (dr["typename_vchr"].ToString().Trim() == "")
                            {
                                MessageBox.Show("收费明细存在住院核算分类为空，操作终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }

                            sarr[0] = dr["deptid"].ToString();
                            sarr[1] = dr["calccateid_chr"].ToString();
                            sarr[2] = this.m_objViewer.dtgDetail.Rows[i2].Cells["colhjje"].Value.ToString();

                            dtbBaby.Rows.Add(sarr);
                        }
                        DataRow drwMater = null;
                        DataRow drwBaby = null;
                        for (int i3 = 0; i3 < dtbMater.Rows.Count; i3++)
                        {
                            drwMater = dtbMater.Rows[i3];
                            for (int i4 = 0; i4 < dtbBaby.Rows.Count; i4++)
                            {
                                drwBaby = dtbBaby.Rows[i4];
                                if (drwMater["deptid"].ToString() == drwBaby["deptid"].ToString() && drwMater["calccateid_chr"].ToString() == drwBaby["calccateid_chr"].ToString())
                                {
                                    dtbMater.Rows[i3]["TotalSum"] = Convert.ToDecimal(drwMater["TotalSum"].ToString()) + Convert.ToDecimal(drwBaby["TotalSum"].ToString());
                                    dtbBaby.Rows.RemoveAt(i4);
                                    i4--;
                                }
                            }
                        }
                        drwMater = null;
                        drwBaby = null;
                        //将婴儿有的费用类型，母亲没有的也添加进费用分类总表去
                        if (dtbBaby.Rows.Count > 0)
                        {

                            object[] objarr = null; ;
                            for (int i6 = 0; i6 < dtbBaby.Rows.Count; i6++)
                            {
                                objarr = dtbBaby.Rows[i6].ItemArray;
                                dtbMater.Rows.Add(objarr);
                            }
                            objarr = null;

                        }
                    }
                    //所有的费用表生成结算分类费用VO
                    DataRow drwMater2 = null;
                    for (int i5 = 0; i5 < dtbMater.Rows.Count; i5++)
                    {
                        drwMater2 = dtbMater.Rows[i5];
                        clsBihChargeCat_VO ChargeCat_VO = new clsBihChargeCat_VO();
                        ChargeCat_VO.DeptID = drwMater2["deptid"].ToString();
                        ChargeCat_VO.ItemCatID = drwMater2["calccateid_chr"].ToString();
                        ChargeCat_VO.TotalSum = Convert.ToDecimal(drwMater2["TotalSum"].ToString());
                        ChargeCat_VO.AcctSum = 0;

                        ChargeCatArr.Add(ChargeCat_VO);
                    }
                    #endregion
                }
            }
            #endregion

            #region 生成发票分类VO
            //发票分类
            ArrayList ChargeInvArr = new ArrayList();
            if (IsHavePrepayMoney)
            {
                string RegID = this.m_objViewer.ucPatientInfo.RegisterID.Trim();
                DataTable dtFee;
                long l = 0;
                if (intBabyParm == 1)
                {
                    l = this.objSvc.m_lngGetBadChargeFeeInfoMotherBaby(RegID, out dtFee);
                }
                else
                {
                    l = this.objSvc.m_lngGetBadChargeFeeInfo(RegID, out dtFee);
                }
                if (l > 0)
                {
                    DataView dv = new DataView(dtFee);
                    DataTable dtCat = new DataTable();

                    l = this.objSvc.m_lngGetChargeItemCat(4, out dtCat);
                    if (l > 0 && dtCat.Rows.Count > 0)
                    {
                        decimal decPrepayMny = this.m_objViewer.ucPatientInfo.BihPatient_VO.PrepayMoney;
                        decimal decDeptMny = this.m_objViewer.ucPatientInfo.BihPatient_VO.WaitChargeFee + this.m_objViewer.ucPatientInfo.BihPatient_VO.WaitClearFee;
                        decimal scale = decPrepayMny / decDeptMny;
                        decimal decSum = 0;

                        for (int i = 0; i < dtCat.Rows.Count; i++)
                        {
                            string catid = dtCat.Rows[i]["typeid_chr"].ToString().Trim();
                            string catname = dtCat.Rows[i]["typename_vchr"].ToString().Trim();

                            decimal dtotal = 0;

                            dv.RowFilter = "invcateid_chr = '" + catid + "'";
                            foreach (DataRowView drv in dv)
                            {
                                catid = drv["invcateid_chr"].ToString().Trim();
                                if (catid == "")
                                {
                                    MessageBox.Show("收费明细存在住院发票分类为空，结算终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return;
                                }

                                decimal dc = clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]) * scale, 2);
                                dtotal += dc;
                            }

                            if (dtotal == 0)
                            {
                                continue;
                            }

                            clsBihInvoiceCat_VO InvoiceCat_VO = new clsBihInvoiceCat_VO();
                            InvoiceCat_VO.ItemCatID = catid;
                            InvoiceCat_VO.ItemCatName = catname;
                            InvoiceCat_VO.TotalSum = dtotal;
                            InvoiceCat_VO.AcctSum = 0;

                            decSum += dtotal;

                            if (i == dtCat.Rows.Count - 1)
                            {
                                if (decSum != decPrepayMny)
                                {
                                    InvoiceCat_VO.TotalSum = InvoiceCat_VO.TotalSum + decPrepayMny - decSum;
                                }
                            }

                            ChargeInvArr.Add(InvoiceCat_VO);
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            #endregion

            frmReckoning frec = new frmReckoning(this.m_objViewer.InvoNo);
            frec.ChargeType = 3;
            frec.objPatient = this.m_objViewer.ucPatientInfo;
            frec.BadChargeCatArr = ChargeCatArr;
            frec.BadChargeInvArr = ChargeInvArr;
            frec.BadChargeDiffValDeptID = DiffValDeptID;
            frec.BadChargeDiffValCatID = DiffValCatID;
            frec.DirectChargeFlag = !IsHavePrepayMoney;
            if (frec.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.btnCompute.Enabled = false;
                this.m_objViewer.btnCharge.Enabled = false;
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
        }
        #endregion

    }
}
