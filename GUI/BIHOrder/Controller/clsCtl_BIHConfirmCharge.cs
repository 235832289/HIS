using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder.Control;
using System.Collections;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.BIHOrder
{
    class clsCtl_BIHConfirmCharge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声名
        clsDcl_ExecuteOrder m_objManage = null;
        DataTable m_dtChargeList = new DataTable();
        DataTable m_dtOrderExecute = new DataTable();
        /// <summary>
        /// 费用合计列表
        /// </summary>
        Hashtable m_HtSumList = new Hashtable();
        /// <summary>
        /// 当前病人登记流水号
        /// </summary>
        public string m_strCurrentRegisterID = "";
        #endregion

         #region 构造函数
        public clsCtl_BIHConfirmCharge()
        {
            m_objManage = new clsDcl_ExecuteOrder();
        }
        #endregion

         #region 设置窗体对象
        com.digitalwave.iCare.BIHOrder.frmBIHConfirmCharge m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBIHConfirmCharge)frmMDI_Child_Base_in;

        }
        #endregion

        internal void IniTheForm()
        {
            this.m_objViewer.m_dtvChangeList.Rows.Clear();

            if (this.m_objViewer.m_strView.Equals("2"))
            {
                long lngRes = m_objManage.m_lngGetComfirmThChargeData(m_strCurrentRegisterID, out m_dtOrderExecute, out m_dtChargeList);
          
            }
            else
            {
                long lngRes = m_objManage.m_lngGetComfirmChargeData(m_strCurrentRegisterID, out m_dtOrderExecute, out m_dtChargeList);
            }
           
            TheChargeSumInit();
            BindTheOrderList();
            TheCheckedChargeSum();
            ControlTheButton();
            
        }

        /// <summary>
        /// 当前选中的项目费用总和
        /// </summary>
        private void TheSelectChargeSum()
        {
           
        }

        /// <summary>
        /// 费用合计分类合计
        /// </summary>
        private void TheChargeSumInit()
        {
            m_HtSumList.Clear();
            decimal allSum = 0;
            for (int i = 0; i < m_dtChargeList.Rows.Count; i++)
            {
                if (m_dtChargeList.Rows[i]["STATUS_INT"].ToString().Trim().Equals("0"))//已经作费的收费项目不计费
                {
                    continue;
                }
                if (this.m_objViewer.m_strView.Equals("2"))//直接的材料费不显示
                {
                    if (m_dtChargeList.Rows[i]["flag_int"].ToString().Trim().Equals("2"))
                    {
                        continue;
                    }
                }                
                string m_strORDEREXECID = clsConverter.ToString(m_dtChargeList.Rows[i]["ORDEREXECID_CHR"].ToString().Trim());
                if (!m_HtSumList.Contains(m_strORDEREXECID))
                {
                    decimal k=0;
                    m_HtSumList.Add(m_strORDEREXECID,k);
                }
                allSum = (decimal)m_HtSumList[m_strORDEREXECID];
                allSum += clsConverter.ToDecimal(m_dtChargeList.Rows[i]["AMOUNT_DEC"].ToString().Trim()) * clsConverter.ToDecimal(m_dtChargeList.Rows[i]["UNITPRICE_DEC"].ToString().Trim());
                m_HtSumList[m_strORDEREXECID] = allSum;
            }
        }

        private void BindTheChargeList(string ORDEREXECID_CHR)
        {
            this.m_objViewer.m_dtvChangeList.Rows.Clear();
            DataView myDataView = new DataView(m_dtChargeList);
            myDataView.RowFilter = "ORDEREXECID_CHR='" + ORDEREXECID_CHR + "'";
            myDataView.Sort = "CREATE_DAT";
            if (myDataView.Count <= 0)
            {
                return;
            }
            decimal allSum = 0;//单项合计
            for (int i = 0; i < myDataView.Count; i++)
            {
                 if (this.m_objViewer.m_strView.Equals("2"))//直接的材料费不显示
                {
                    if (myDataView[i]["flag_int"].ToString().Trim().Equals("2"))
                    {
                        continue;
                    }
                }
                this.m_objViewer.m_dtvChangeList.Rows.Add();
                DataGridViewRow row = this.m_objViewer.m_dtvChangeList.Rows[this.m_objViewer.m_dtvChangeList.RowCount-1];
                row.Cells["c_no"].Value = clsConverter.ToString(i+1);
                row.Cells["c_CHARGEITEMNAME"].Value = clsConverter.ToString(myDataView[i]["CHARGEITEMNAME_CHR"].ToString().Trim());
                row.Cells["c_UNITPRICE"].Value = clsConverter.ToString(myDataView[i]["UNITPRICE_DEC"].ToString().Trim()) + clsConverter.ToString(myDataView[i]["UNIT_VCHR"].ToString().Trim());
                row.Cells["c_AMOUNT"].Value = clsConverter.ToString(myDataView[i]["AMOUNT_DEC"].ToString().Trim());
                string PSTATUS_CHR="";
                switch (clsConverter.ToString(myDataView[i]["PSTATUS_INT"].ToString().Trim()))
                {
                    case "0":
                        PSTATUS_CHR = "待确认";
                        break;
                    case "1":
                        PSTATUS_CHR = "待结";
                        break;
                    case "2":
                        PSTATUS_CHR = "待清";
                        break;
                     case "3":
                         PSTATUS_CHR = "已清";
                        break;
                     case "4":
                         PSTATUS_CHR = "直收";
                        break;

                }
                row.Cells["c_PSTATUS_INT"].Value = PSTATUS_CHR;
                if (myDataView[i]["STATUS_INT"].ToString().Trim().Equals("0"))//显示为作废
                {
                    row.Cells["c_PSTATUS_INT"].Value = "作废";
                   
                }
                if (clsConverter.ToString(myDataView[i]["ISRICH_INT"].ToString().Trim()).Equals("0"))
                {
                    row.Cells["c_ISRICH"].Value = "";
                }
                else
                {
                    row.Cells["c_ISRICH"].Value = "是";
                }
                if (clsConverter.ToString(myDataView[i]["NEEDCONFIRM_INT"].ToString().Trim()).Equals("0"))
                {
                    row.Cells["c_NEEDCONFIRM"].Value = "0";
                }
                else
                {
                    row.Cells["c_NEEDCONFIRM"].Value = "1";
                }
                if (clsConverter.ToString(myDataView[i]["ISMEPAY_INT"].ToString().Trim()).Equals("0"))
                {
                    row.Cells["c_ISMEPAY_INT"].Value = "";
                }
                else
                {
                    row.Cells["c_ISMEPAY_INT"].Value = "是";
                }
                row.Cells["c_CONFIRMER_VCHR"].Value = clsConverter.ToString(myDataView[i]["CONFIRMER_VCHR"].ToString().Trim());
                row.Cells["c_CONFIRM_DAT"].Value = clsConverter.ToString(myDataView[i]["CONFIRM_DAT"].ToString().Trim());
                row.Cells["c_Sum"].Value =decimal.Round(clsConverter.ToDecimal(myDataView[i]["AMOUNT_DEC"].ToString().Trim()) * clsConverter.ToDecimal(myDataView[i]["UNITPRICE_DEC"].ToString().Trim()),2).ToString("0.00");
                row.Cells["c_INSURACEDESC_VCHR"].Value = clsConverter.ToString(myDataView[i]["INSURACEDESC_VCHR"].ToString().Trim());
                row.Cells["c_SPEC_VCHR"].Value = clsConverter.ToString(myDataView[i]["SPEC_VCHR"].ToString().Trim());
              
                allSum +=decimal.Round( clsConverter.ToDecimal(myDataView[i]["AMOUNT_DEC"].ToString().Trim()) * clsConverter.ToDecimal(myDataView[i]["UNITPRICE_DEC"].ToString().Trim()),2);
                
            }
          
            /*
            CLACAREA_NAME 核算病区id{=部门.id}
            CREATEAREA_NAME 开单地点id{=部门.id}

            CHARGEITEMNAME_CHR 收费项目名称{=收费项目.名称}
            UNITPRICE_DEC 住院单价{=收费项目.住院单价}
            UNIT_VCHR  住院单位{=收费项目.住院单位}
            AMOUNT_DEC 领量
            PSTATUS_INT 费用状态{0=待确认;1=待结;2=待清;3=已清;4=直收}
            ISRICH_INT 是否贵重{1/0}
            NEEDCONFIRM_INT 是否需要费用审核 0-否 1-是
            CONFIRMER_VCHR 审核人名称
            CONFIRM_DAT 审核时间


            c_no
            c_CHARGEITEMNAME
            c_UNITPRICE
            c_AMOUNT
            c_PSTATUS_INT
            c_ISRICH
            c_NEEDCONFIRM
            c_CONFIRMER_VCHR
            c_CONFIRM_DAT
             */
        }

        private void BindTheOrderList()
        {
            this.m_objViewer.m_dtvOrderList.Rows.Clear();
            int j = 0;

            for (int i = 0; i < m_dtOrderExecute.Rows.Count; i++)
            {
                if (this.m_objViewer.m_rdoYET.Checked)
                {
                    if (m_dtOrderExecute.Rows[i]["CONFIRM_DAT"].ToString().Trim().Equals(""))
                    {
                        continue;
                    }
                }
                else if (this.m_objViewer.m_rdoNOT.Checked)
                {
                    if (!m_dtOrderExecute.Rows[i]["CONFIRM_DAT"].ToString().Trim().Equals(""))
                    {
                        continue;
                    }
                    
                }
                this.m_objViewer.m_dtvOrderList.Rows.Add();
                DataGridViewRow row = this.m_objViewer.m_dtvOrderList.Rows[this.m_objViewer.m_dtvOrderList.RowCount - 1];
                if (this.m_objViewer.m_chkSelectAll.Checked)
                {
                    row.Cells["m_clmselectCheck"].Value = "1";
                }
                else
                {
                    row.Cells["m_clmselectCheck"].Value = "0";
                }
                j++;
                row.Cells["m_clmNO"].Value = Convert.ToString(j);
                row.Cells["m_clmrecipeno_int"].Value = m_dtOrderExecute.Rows[i]["recipeno_int"].ToString().Trim();
                row.Cells["m_clmname_vchr"].Value = m_dtOrderExecute.Rows[i]["name_vchr"].ToString().Trim();
                row.Cells["m_clmDOCTOR_VCHR"].Value = m_dtOrderExecute.Rows[i]["DOCTOR_VCHR"].ToString().Trim();
                row.Cells["m_clmCREATOR_CHR"].Value = m_dtOrderExecute.Rows[i]["CREATOR_CHR"].ToString().Trim();
                row.Cells["m_clmCREATEDATE_DAT"].Value = m_dtOrderExecute.Rows[i]["CREATEDATE_DAT"].ToString().Trim();
                row.Cells["m_clmCONFIRMER_VCHR"].Value = m_dtOrderExecute.Rows[i]["CONFIRMER_VCHR"].ToString().Trim();
                row.Cells["m_clmCONFIRM_DAT"].Value = m_dtOrderExecute.Rows[i]["CONFIRM_DAT"].ToString().Trim();
                row.Cells["m_clmORDEREXECID_CHR"].Value = m_dtOrderExecute.Rows[i]["ORDEREXECID_CHR"].ToString().Trim();
                row.Cells["m_clmSTATUS_INT"].Value = m_dtOrderExecute.Rows[i]["STATUS_INT"].ToString().Trim();
                /*
                m_clmselectCheck
                m_clmNO
                m_clmrecipeno_int
                m_clmname_vchr
                m_clmDOCTOR_VCHR
                m_clmCREATOR_CHR
                m_clmCREATEDATE_DAT
                m_clmCONFIRMER_VCHR
                m_clmCONFIRM_DAT
                m_clmORDEREXECID_CHR
                 */
                if (j==1)
                {
                    this.m_objViewer.m_dtvOrderList.CurrentCell = this.m_objViewer.m_dtvOrderList.Rows[0].Cells[0];
                }
            }
            if (this.m_objViewer.m_dtvOrderList.RowCount > 0)
            {
                this.m_objViewer.m_dtvOrderList.CurrentCell = this.m_objViewer.m_dtvOrderList.Rows[0].Cells[1];
            }
        }

        internal void binTheChargeList()
        {
            if (this.m_objViewer.m_dtvOrderList.CurrentRow != null)
            {
                int i=this.m_objViewer.m_dtvOrderList.CurrentRow.Index;
                if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmORDEREXECID_CHR"].Value != null)
                {
                    decimal oneSum=0;
                    BindTheChargeList(this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmORDEREXECID_CHR"].Value.ToString().Trim());
                    string ORDEREXECID_CHR=this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmORDEREXECID_CHR"].Value.ToString().Trim();
                    if(m_HtSumList.Contains(ORDEREXECID_CHR))
                    {
                        oneSum = decimal.Round( (decimal)m_HtSumList[ORDEREXECID_CHR],2);
                    
                    }
                    this.m_objViewer.m_txtOneSum.Text = "当前合计：" + oneSum.ToString("0.00");
                }
            }
        }

        #region 选项框事件处理
        /// <summary>
        /// 选项框事件处理
        /// </summary>
        internal void SelectAll()
        {
            if (m_objViewer.m_chkSelectAll.Checked == true)
            {
                for (int i = 0; i < m_objViewer.m_dtvOrderList.Rows.Count; i++)
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value = "1";
                }
            }
            else
            {
                for (int i = 0; i < m_objViewer.m_dtvOrderList.Rows.Count; i++)
                {
                    m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value = "0";
                }
            }
        }
        #endregion



        internal void ChangeTheSelectState(int rowNum,int colNum)
        {
            if (this.m_objViewer.m_dtvOrderList.Rows.Count > 0 && rowNum >= 0 && colNum==0)
            {
                if (this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_clmselectCheck"].Value.ToString().Trim().Equals("0"))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_clmselectCheck"].Value = "1";
                }
                else if (this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_clmselectCheck"].Value.ToString().Trim().Equals("1"))
                {
                    this.m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_clmselectCheck"].Value = "0";
                }
                TheCheckedChargeSum();
                ControlTheButton();
            }
           
        }

        private void TheChargeSum(int rowNum)
        {
           string ORDEREXECID_CHR= m_objViewer.m_dtvOrderList.Rows[rowNum].Cells["m_clmORDEREXECID_CHR"].Value.ToString().Trim();
           if (m_HtSumList.Contains(ORDEREXECID_CHR))
           {
               this.m_objViewer.m_txtOneSum.Text = "当前合计：" +((decimal)m_HtSumList[ORDEREXECID_CHR]).ToString("0.00");
           }
           
        }

        /// <summary>
        /// 当前选中费用合计
        /// </summary>
        public void TheCheckedChargeSum()
        {
            decimal allSum = 0;
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
            {
                if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value.ToString().Trim().Equals("1"))
                {
                    if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmSTATUS_INT"].Value.ToString().Trim().Equals("0"))//已经作费的收费项目不计费
                    {
                        continue;
                    }
                    string ORDEREXECID_CHR = m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmORDEREXECID_CHR"].Value.ToString().Trim();
                    if (m_HtSumList.Contains(ORDEREXECID_CHR))
                    {
                        allSum += (decimal)m_HtSumList[ORDEREXECID_CHR];
                    }
                }
            }
            this.m_objViewer.m_txtAllSum.Text = "选中合计："+allSum.ToString("0.00");

        }

        private void ControlTheButton()
        {
            int m_intStatus = 0;
            this.m_objViewer.m_cmdComfirm.Enabled = true;
            this.m_objViewer.m_btnDable.Enabled = true;
            if (this.m_objViewer.m_dtvOrderList.Rows.Count > 0)
            {
                for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
                {
                    if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value == null)
                    {
                        return;
                    }
                    if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value.ToString().Trim().Equals("1"))
                    {
                        if (!this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmCONFIRM_DAT"].Value.ToString().Trim().Equals(""))
                        {
                            this.m_objViewer.m_cmdComfirm.Enabled = false;
                            this.m_objViewer.m_btnDable.Enabled = false;
                            return;
                        }
                    }
                }

            }
           
        }

        internal void UpdateBihOrderConfirmer()
        {

            string m_strOrderExecuteID_Arr = "";
            m_strOrderExecuteID_Arr = GetTheSelectItem();
            if (m_strOrderExecuteID_Arr.Trim().Equals(""))
            {
                MessageBox.Show("请先选择待确认的执行单!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //DotorComfirmBox comfirmBox1=new DotorComfirmBox();
            //if (comfirmBox1.ShowDialog() == DialogResult.OK)
            if (MessageBox.Show("确认进行此操作?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                long lngRes = 0;
                if(this.m_objViewer.m_strView.Equals("2"))
                {
                   // lngRes = m_objManage.m_lngBihOrderExecuteThChargeConfirmer(m_strOrderExecuteID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);
                    frmReckoning frec = new frmReckoning("");
                    
                    //frec.txtInvono.Text = clsPublic.m_strGetCurrInvoiceNo();
                    frec.ChargeType = 5;
                    DataView myDataView = new DataView(m_dtChargeList);
                    string ORDEREXECID_Arr = "";//非材料
                    string ORDEREXECID_Arr2 = "";//材料
                    for (int i = 0; i < this.m_objViewer.m_dtvOrderList.RowCount; i++)
                    {
                        if (this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value.ToString().Trim().Equals("0"))
                        {
                            continue;
                        }
                        ORDEREXECID_Arr+=  " ORDEREXECID_CHR='" +this.m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmORDEREXECID_CHR"].Value.ToString().TrimEnd() + "' ";
                        if(i<this.m_dtOrderExecute.Rows.Count-1)
                        {
                            ORDEREXECID_Arr += "OR";
                        }
                    }
                    ORDEREXECID_Arr=ORDEREXECID_Arr.TrimEnd("OR".ToCharArray());
                    if (!ORDEREXECID_Arr.Trim().Equals(""))
                    {
                        ORDEREXECID_Arr = " (flag_int<>2) and (" + ORDEREXECID_Arr+")";
                        ORDEREXECID_Arr2 = " (flag_int=2) and (" + ORDEREXECID_Arr + ")";
                    }
                    myDataView.RowFilter = ORDEREXECID_Arr;
                    DataTable m_dtChargeList2= m_dtChargeList.Clone();
                    for (int i = 0; i < myDataView.Count; i++)
                    {
                        m_dtChargeList2.Rows.Add(myDataView[i].Row.ItemArray);
                        //string a1= myDataView[i]["UNITPRICE_DEC"].ToString().Trim();
                        //string a2 = myDataView[i]["AMOUNT_DEC"].ToString().Trim();
                        //string a3 = myDataView[i]["precent_dec"].ToString().Trim();
                    }
                    
                    frec.ChargeDetail = m_dtChargeList2;
                    frec.objPatient = this.m_objViewer.ucPatientInfo1;
                    frec.ConfirmID = this.m_objViewer.LoginInfo.m_strEmpID; //comfirmBox1.empid_chr ;
                    frec.ConfirmName = this.m_objViewer.LoginInfo.m_strEmpName; //comfirmBox1.lastname_vchr;
                    frec.DayChrgType = 2;
                    frec.DayAccountsArr = null;
                    if (frec.ShowDialog() == DialogResult.OK)
                    {
                        myDataView.RowFilter = ORDEREXECID_Arr;
                        ArrayList m_arrPCHARGEID_CHR = new ArrayList();
                        for (int i = 0; i < myDataView.Count; i++)
                        {
                            m_arrPCHARGEID_CHR.Add(myDataView[i]["PCHARGEID_CHR"].ToString().Trim());
                        }
                        if (m_arrPCHARGEID_CHR.Count > 0)
                        {
                            lngRes = m_objManage.m_lngBihOrderExecuteChargeConfirmerTh(m_arrPCHARGEID_CHR, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                        }
                        ArrayList arr = new ArrayList();
                        arr.Add(this.m_objViewer.ucPatientInfo1.RegisterID);

                        IPutMadicine put = PutMadicineFactory.GetInstanceForRecipeMed();
                        //put.CreatePutMedDetail(arr, comfirmBox1.empid_chr);
                        put.CreatePutMedDetail(arr, this.m_objViewer.LoginInfo.m_strEmpID);
                        this.m_objViewer.ucPatientInfo1.m_mthFind(this.m_objViewer.ucPatientInfo1.BihPatient_VO.Zyh, 2);
                        this.m_objViewer.ucPatientInfo1_ZyhChanged();
                    }
                   
                }
                else
                {
                  //  lngRes = m_objManage.m_lngBihOrderExecuteChargeConfirmer(m_strOrderExecuteID_Arr, comfirmBox1.empid_chr, comfirmBox1.lastname_vchr);
                    lngRes = m_objManage.m_lngBihOrderExecuteChargeConfirmer(m_strOrderExecuteID_Arr, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("审核成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //LoadTheDate();
                        sendTheBill();
                        this.m_objViewer.ucPatientInfo1.m_mthFind(this.m_objViewer.ucPatientInfo1.BihPatient_VO.Zyh, 2);
                        this.m_objViewer.ucPatientInfo1_ZyhChanged();
                    }
                }
               
               
                
            }
           // comfirmBox1.Close();
            
        
        }

        internal void UpdateBihOrderDenableConfirmer()
        {

            string m_strOrderExecuteID_Arr = "";
            m_strOrderExecuteID_Arr = GetTheSelectItem();
            if (m_strOrderExecuteID_Arr.Trim().Equals(""))
            {
                MessageBox.Show("请先选择待确认的执行单!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            //DotorComfirmBox comfirmBox1 = new DotorComfirmBox();
            //if (comfirmBox1.ShowDialog() == DialogResult.OK)
             if( MessageBox.Show("确定进行作废操作?", "提示框！", MessageBoxButtons.YesNo, MessageBoxIcon.Information)==DialogResult.Yes)
            {
                long lngRes = 0;
                lngRes = m_objManage.m_lngBihOrderExecuteDenableConfirmer(m_strOrderExecuteID_Arr, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                if (lngRes > 0)
                {
                    MessageBox.Show("作废成功!", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //LoadTheDate();
                    //sendTheBill();
                    this.m_objViewer.ucPatientInfo1.m_mthFind(this.m_objViewer.ucPatientInfo1.BihPatient_VO.Zyh, 2);
                    this.m_objViewer.ucPatientInfo1_ZyhChanged();
                }
            }
            //comfirmBox1.Close();
            
            //IniTheForm();

        }

        private string GetTheSelectItem()
        {
            string orderArr = "";
            for (int i = 0; i < this.m_objViewer.m_dtvOrderList.Rows.Count; i++)
            {
                if (m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmselectCheck"].Value.ToString().Equals("1"))
                {
                    orderArr += "'" + m_objViewer.m_dtvOrderList.Rows[i].Cells["m_clmORDEREXECID_CHR"].Value + "',";

                }
            }
            orderArr = orderArr.TrimEnd(',');
            return orderArr;
        }

       
        internal void sendTheBill()
        {
            bool m_blhave=false;
            //检查当前是否有还没有已确认是否需要费用审核 0-否 1-是的但已审核但还没有发送的医嘱申请单
            long lngRes = m_objManage.m_lngCheckTheExecuteBill(m_strCurrentRegisterID, out m_blhave);
            if (m_blhave)
            {
                IPutMadicine madicine;
                ArrayList m_arrRegisterid = new ArrayList();
                m_arrRegisterid.Add(m_strCurrentRegisterID);
                madicine = PutMadicineFactory.GetInstance();
                long ret = madicine.CreatePutMedDetail(m_arrRegisterid, this.m_objViewer.LoginInfo.m_strEmpID);
                if (ret > 0)
                {
                    
                        MessageBox.Show("已成功发送完毕！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }                
            }
            //else
            //{
            //    MessageBox.Show("当前没有已审核但还没有发送的医嘱申请单！", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;   
            //}
          
        }
    }
}
